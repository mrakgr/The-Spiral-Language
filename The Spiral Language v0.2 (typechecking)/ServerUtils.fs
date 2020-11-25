module Spiral.ServerUtils
open System
open System.IO
open System.Collections.Generic

open VSCTypes
open Spiral.SpiProj

type Graph = Map<string,string Set>
type MirroredGraph = Graph * Graph

let mirrored_graph_empty = Map.empty, Map.empty

let add_link (abs : Graph) a b: Graph = 
    match Map.tryFind a abs with
    | Some bs -> Map.add a (Set.add b bs) abs
    | None -> Map.add a (Set.singleton b) abs
let add_link' (s : MirroredGraph) a b: MirroredGraph = add_link (fst s) a b, add_link (snd s) b a

let remove_link (abs : Graph) a b = 
    match Map.tryFind a abs with
    | Some bs -> 
        let bs = Set.remove b bs
        if Set.isEmpty bs then Map.remove a abs else Map.add a bs abs
    | None -> abs
let remove_link' (s : MirroredGraph) a b: MirroredGraph = remove_link (fst s) a b, remove_link (snd s) b a

let remove_links ((abs,bas as s) : MirroredGraph) a: MirroredGraph = 
    match Map.tryFind a abs with
    | Some bs -> Map.remove a abs, Set.fold (fun bas b -> remove_link bas b a) bas bs
    | None -> s
let add_links s a bs = List.fold (fun s b -> add_link' s a b) s bs
let replace_links (s : MirroredGraph) a bs = add_links (remove_links s a) a bs
let get_links (abs : Graph) a = Map.tryFind a abs |> Option.defaultValue Set.empty
let link_exists ((abs,bas) : MirroredGraph) x = Map.containsKey x abs || Map.containsKey x bas

let topological_sort bas dirty_nodes =
    let sort_order = Stack()
    let sort_visited = HashSet()
    let rec dfs_rev a = if sort_visited.Add(a) then Seq.iter dfs_rev (get_links bas a); sort_order.Push(a)
    Seq.iter dfs_rev dirty_nodes
    sort_order, sort_visited

let circular_nodes ((abs,bas) : MirroredGraph) dirty_nodes =
    let sort_order, sort_visited = topological_sort bas dirty_nodes
    let order = sort_order.ToArray()
    let visited = HashSet()
    let circular_nodes = HashSet()
    order |> Array.iter (fun a ->
        let ar = ResizeArray()
        let rec dfs a = if sort_visited.Contains(a) && visited.Add(a) then Seq.iter dfs (get_links abs a); ar.Add a
        dfs a
        if 1 < ar.Count then ar |> Seq.iter (fun x -> circular_nodes.Add(x) |> ignore)
        )
    order, circular_nodes

type ProjectCodeAction = 
    | CreateFile of {|filePath : string|}
    | DeleteFile of {|range: VSCRange; filePath : string|} // The range here includes the postfix operators.
    | RenameFile of {|filePath : string; target : string|}
    | CreateDirectory of {|dirPath : string|}
    | DeleteDirectory of {|range: VSCRange; dirPath : string|} // The range here is for the whole tree, not just the code action activation.
    | RenameDirectory of {|dirPath : string; target : string; validate_as_file : bool|}

let code_action_execute a =
    try match a with
        | CreateDirectory a -> Directory.CreateDirectory(a.dirPath) |> ignore; None
        | DeleteDirectory a -> Directory.Delete(a.dirPath,true); None
        | RenameDirectory a ->
            if a.validate_as_file then
                match FParsec.CharParsers.run file_verify a.target with
                | FParsec.CharParsers.ParserResult.Success _ -> Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); None
                | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Some er
            else
                Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); None
        | CreateFile a ->
            if File.Exists(a.filePath) then Some "File already exists."
            else File.Create(a.filePath).Dispose(); None
        | DeleteFile a -> File.Delete(a.filePath); None
        | RenameFile a ->
            match FParsec.CharParsers.run file_verify a.target with
            | FParsec.CharParsers.ParserResult.Success _ -> File.Move(a.filePath,Path.Combine(a.filePath,"..",a.target+Path.GetExtension(a.filePath)),false); None
            | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Some er
    with e -> Some e.Message

type RAction = VSCRange * ProjectCodeAction

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type ValidatedFileHierarchy =
    | File of path: RString * name: string option * exists: bool
    | Directory of name: string * ValidatedFileHierarchy list

type ValidatedSchema = {
    schema : Schema
    packages : RString list
    links : RString list
    actions : RAction list
    errors : RString list
    files : ValidatedFileHierarchy list
    }

let schema_validate project_dir x =
    let errors = ResizeArray()
    let actions = ResizeArray()
    let validate_dir dir =
        match dir with
        | Some (r,dir) ->
            try let x = DirectoryInfo(Path.Combine(project_dir,dir))
                if x = null then errors.Add (r, "Directory is rootless.")
                elif x.Exists then
                    actions.Add (r, RenameDirectory {|dirPath=x.FullName; target=null; validate_as_file=false|})
                    actions.Add (r, DeleteDirectory {|dirPath=x.FullName; range=r|})
                else
                    errors.Add (r, "Directory does not exist.")
                    actions.Add (r, CreateDirectory {|dirPath=x.FullName|})
                x.FullName
            with e -> errors.Add (r, e.Message); project_dir
        | None -> project_dir

    let moduleDir = validate_dir x.moduleDir
    let links = ResizeArray()
    if 0 = errors.Count then
        let rec validate_ownership (r,dir : DirectoryInfo) =
            if dir = null then errors.Add(r, "The directory should be a subdirectory of the current project file.")
            else 
                let p = Path.Combine(dir.FullName,"package.spiproj")
                if File.Exists(p) then
                    if dir.FullName <> project_dir then 
                        errors.Add(r, "This module directory belongs to a different project.")
                        links.Add(r, "file:///" + p)
                else validate_ownership (r,dir.Parent)
        x.moduleDir |> Option.iter (fun (r,dir) -> try validate_ownership (r,DirectoryInfo(Path.Combine(project_dir,dir))) with e -> errors.Add (r, e.Message))

    let files =
        if 0 = errors.Count then 
            let rec validate_file prefix = function
                | FileHierarchy.File(r',(r,a),is_top_down,is_include) -> 
                    try let x = FileInfo(Path.Combine(prefix,a + (if is_top_down then ".spi" else ".spir")))
                        let exists = x.Exists
                        if exists then 
                            links.Add (r, "file:///" + x.FullName)
                            actions.Add (r, RenameFile {|filePath=x.FullName; target=null|})
                            actions.Add (r, DeleteFile {|range=r'; filePath=x.FullName|})
                        else 
                            errors.Add (r, "File does not exist.")
                            actions.Add (r, CreateFile {|filePath=x.FullName|})
                        Some(File((r,x.FullName),(if is_include then None else Some a),exists))
                    with e -> errors.Add (r, e.Message); None
                | FileHierarchy.Directory(r',(r,a),b) ->
                    try let x = DirectoryInfo(Path.Combine(prefix,a))
                        let p = Path.Combine(x.FullName,"package.spiproj")
                        let l =
                            if File.Exists(p) then 
                                errors.Add(r, "This directory belongs to a different project.")
                                links.Add(r, "file:///" + p)
                                []
                            elif x.Exists then
                                actions.Add(r, RenameDirectory {|dirPath=x.FullName; target=null; validate_as_file=true|})
                                actions.Add(r, DeleteDirectory {|dirPath=x.FullName; range=r'|})
                                List.choose (validate_file x.FullName) b
                            else
                                errors.Add(r, "Directory does not exist.")
                                actions.Add(r, CreateDirectory {|dirPath=x.FullName|})
                                []
                        Some(Directory(a,l))
                    with e -> errors.Add (r, e.Message); None
            List.choose (validate_file moduleDir) x.modules
        else
            []
    let outDir = validate_dir x.outDir
    let packages =
        let packages = HashSet()
        let validate_package d (r,x) =
            try let x = DirectoryInfo(Path.Combine(d,x)).FullName
                if project_dir = x then errors.Add(r,"Self references are not allowed."); None
                // The validator needs the backwards links even for files that are currently missing, but might exist.
                elif packages.Add(x) then Some(r, x)
                else errors.Add(r,"Duplicates are not allowed."); None
            with e -> errors.Add(r, e.Message); None
        match x.packageDir with
        | Some(r,n) -> 
            try let d = DirectoryInfo(Path.Combine(project_dir,n))
                if d.Exists = false then errors.Add(r, "The directory does not exist.")
                List.choose (validate_package d.FullName) x.packages
            with e -> errors.Add (r, e.Message); []
        | None -> List.choose (validate_package (Path.Combine(project_dir,".."))) x.packages
    {schema=x; packages=packages; links=Seq.toList links; actions=Seq.toList actions; errors=Seq.toList errors; files=files}

type PackageSchema = {
    schema : ValidatedSchema
    package_links : RString list
    package_errors : RString list
    is_circular : bool
    }

type ResultMap<'a> = Map<string,Result<'a,string>>
type PackageMaps = {
    package_schemas : PackageSchema ResultMap
    package_links : MirroredGraph
    validated_schemas : ValidatedSchema ResultMap
    }

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let file uri = FileInfo(Uri(uri).LocalPath).FullName
let spiproj_link dir = sprintf "file:///%s/package.spiproj" dir
let package_validate (s : PackageMaps) project_dir =
    let potential_floating_garbage =
        project_dir ::
        match Map.tryFind project_dir s.package_schemas with
        | Some(Ok v) -> List.map snd v.schema.packages
        | _ -> []

    let schemas = Map.remove project_dir s.package_schemas
    let dirty_nodes = HashSet()
    dirty_nodes.Add(project_dir) |> ignore
    
    let rec loop links project_dir =
        match s.validated_schemas.[project_dir] with
        | Ok x -> List.fold (fun links (r,x) -> check (add_link' links project_dir x) x) links x.packages
        | Error _ -> links
    and check links project_dir = if schemas.ContainsKey(project_dir) = false && dirty_nodes.Add(project_dir) then loop links project_dir else links
    let links = loop (remove_links s.package_links project_dir) project_dir 

    let order, circular_nodes = circular_nodes links dirty_nodes
    let schemas = // Validation and error propagation across the entire graph of packages.
        Array.fold (fun schemas cur ->
            match s.validated_schemas.[cur] with
            | Ok v ->
                let is_circular = circular_nodes.Contains(cur)
                let links = ResizeArray()
                let errors = ResizeArray()
                v.packages |> List.iter (fun (r,sub) ->
                    if circular_nodes.Contains(sub) then 
                        let rest = if is_circular then " and the current package is a part of that loop." else "."
                        errors.Add(r,sprintf "This package is circular%s" rest)
                    else 
                        match Map.find sub schemas with // Note: This key index might fail if the circularity check is not done first.
                        | Ok x when x.is_circular -> errors.Add(r,"This package is circular.") 
                        | Ok x when 0 < x.schema.errors.Length || 0 < x.package_errors.Length -> errors.Add(r,"The package or the chain it is a part of has an error.") 
                        | Ok _ -> links.Add(r,spiproj_link sub)
                        | Error x -> errors.Add(r,x)
                    )
                Map.add cur (Ok {schema=v; package_links=Seq.toList links; package_errors=Seq.toList errors; is_circular=is_circular}) schemas
            | Error x ->
                Map.add cur (Error x) schemas
            ) schemas order
   
    let schemas, loads = // Cleans up the dead nodes.
        List.fold (fun (schemas,loads) project_dir ->
            match Map.find project_dir schemas with
            | Error _ when link_exists links project_dir = false -> Map.remove project_dir schemas, Map.remove project_dir loads
            | _ -> schemas,loads
            ) (schemas,s.validated_schemas) potential_floating_garbage
    order, {package_schemas=schemas; package_links=links; validated_schemas=loads}

let package_errors order (s : PackageMaps) =
    Array.choose (fun dir -> 
        match Map.tryFind dir s.package_schemas with
        | Some(Ok x) -> Some {|uri=spiproj_link dir; errors=List.append x.schema.errors x.package_errors|}
        | _ -> None
        ) order

let schema_parse_then_validate project_dir text =
    match config text with
    | Ok x -> schema_validate project_dir x
    | Error er -> {schema=schema_def; packages=[]; links=[]; actions=[]; errors=er; files=[]}