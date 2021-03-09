module Spiral.ServerUtils
open System
open System.IO
open System.Collections.Generic

open VSCTypes
open Graph
open Spiral.SpiProj

type ProjectCodeAction = 
    | CreateFile of {|filePath : string|}
    | DeleteFile of {|range: VSCRange; filePath : string|} // The range here includes the postfix operators.
    | RenameFile of {|filePath : string; target : string|}
    | CreateDirectory of {|dirPath : string|}
    | DeleteDirectory of {|range: VSCRange; dirPath : string|} // The range here is for the whole tree, not just the code action activation.
    | RenameDirectory of {|dirPath : string; target : string; validate_as_file : bool|}

let code_action_execute a =
    try match a with
        | CreateDirectory a -> Directory.CreateDirectory(a.dirPath) |> ignore; Ok null
        | DeleteDirectory a -> Directory.Delete(a.dirPath,true); Ok a.dirPath
        | RenameDirectory a ->
            if a.validate_as_file then
                match FParsec.CharParsers.run file_verify a.target with
                | FParsec.CharParsers.ParserResult.Success _ -> Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); Ok a.dirPath
                | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Error er
            else
                Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); Ok a.dirPath
        | CreateFile a ->
            if File.Exists(a.filePath) then Error "File already exists."
            else File.Create(a.filePath).Dispose(); Ok null
        | DeleteFile a -> File.Delete(a.filePath); Ok a.filePath
        | RenameFile a ->
            match FParsec.CharParsers.run file_verify a.target with
            | FParsec.CharParsers.ParserResult.Success _ -> File.Move(a.filePath,Path.Combine(a.filePath,"..",a.target+Path.GetExtension(a.filePath)),false); Ok a.filePath
            | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Error er
    with e -> Error e.Message

type RAction = VSCRange * ProjectCodeAction

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type FileHierarchy' =
    | File of path: RString * name: string option * exists: bool
    | Directory of name: string * FileHierarchy' list

// Does only intra-package validation.
type Schema' = {
    schema : RawSchema
    packages : RString list
    links : RString list
    actions : RAction list
    errors : RString list
    files : FileHierarchy' list
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
                        links.Add(r, Utils.file_uri p)
                else validate_ownership (r,dir.Parent)
        x.moduleDir |> Option.iter (fun (r,dir) -> try validate_ownership (r,DirectoryInfo(Path.Combine(project_dir,dir))) with e -> errors.Add (r, e.Message))

    let files =
        if 0 = errors.Count then 
            let rec validate_file prefix = function
                | RawFileHierarchy.File(r',(r,a),is_top_down,is_include) -> 
                    try let x = FileInfo(Path.Combine(prefix,a + (if is_top_down then ".spi" else ".spir")))
                        let exists = x.Exists
                        if exists then 
                            links.Add (r, Utils.file_uri x.FullName)
                            actions.Add (r, RenameFile {|filePath=x.FullName; target=null|})
                            actions.Add (r, DeleteFile {|range=r'; filePath=x.FullName|})
                        else 
                            errors.Add (r, "File does not exist.")
                            actions.Add (r, CreateFile {|filePath=x.FullName|})
                        Some(File((r,x.FullName),(if is_include then None else Some a),exists))
                    with e -> errors.Add (r, e.Message); None
                | RawFileHierarchy.Directory(r',(r,a),b) ->
                    try let x = DirectoryInfo(Path.Combine(prefix,a))
                        let p = Path.Combine(x.FullName,"package.spiproj")
                        let l =
                            if File.Exists(p) then 
                                errors.Add(r, "This directory belongs to a different project.")
                                links.Add(r, Utils.file_uri p)
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
    let packages =
        let packages = HashSet()
        let validate_package d (p : SchemaPackages) =
            try let x = 
                    if p.is_in_compiler_dir then DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..",p.name)).FullName
                    else DirectoryInfo(Path.Combine(d,p.name)).FullName
                if project_dir = x then errors.Add(p.range,"Self references are not allowed."); None
                // The validator needs the backwards links even for files that are currently missing, but might exist.
                elif packages.Add(x) then Some(p.range, x)
                else errors.Add(p.range,"Duplicates are not allowed."); None
            with e -> errors.Add(p.range, e.Message); None
        match x.packageDir with
        | Some(r,n) -> 
            try let d = DirectoryInfo(Path.Combine(project_dir,n))
                if d.Exists = false then errors.Add(r, "The directory does not exist.")
                List.choose (validate_package d.FullName) x.packages
            with e -> errors.Add (r, e.Message); []
        | None -> List.choose (validate_package (Path.Combine(project_dir,".."))) x.packages
    {schema=x; packages=packages; links=Seq.toList links; actions=Seq.toList actions; errors=Seq.toList errors; files=files}

// Does circularity checking and propagates errors from linked packages. Also provides links to them.
type FullyValidatedSchema = {
    schema : Schema'
    package_links : RString list
    package_errors : RString list
    is_circular : bool
    }

type ResultMap<'a> = Map<string,Result<'a,string>>
type PackageMaps = {
    full_schemas : FullyValidatedSchema ResultMap
    package_links : MirroredGraph
    intra_schemas : Schema' ResultMap
    }

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let file uri = FileInfo(Uri(uri).LocalPath).FullName
let spiproj_link dir = Utils.file_uri (sprintf "%s/package.spiproj" dir)
let package_validate (s : PackageMaps) project_dir =
    let potential_floating_garbage =
        project_dir ::
        match Map.tryFind project_dir s.full_schemas with
        | Some(Ok v) -> List.map snd v.schema.RawSchemaPackagesages
        | _ -> []

    let schemas = Map.remove project_dir s.full_schemas
    let dirty_nodes = HashSet()
    dirty_nodes.Add(project_dir) |> ignore
    
    let rec loop links project_dir =
        match s.intra_schemas.[project_dir] with
        | Ok x -> List.fold (fun links (r,x) -> check (add_link' links project_dir x) x) links x.packages
        | Error _ -> links
    and check links project_dir = if schemas.ContainsKey(project_dir) = false && dirty_nodes.Add(project_dir) then loop links project_dir else links
    let links = loop (remove_links s.package_links project_dir) project_dir 

    let order, circular_nodes = circular_nodes links dirty_nodes
    let schemas = // Validation and error propagation across the entire graph of packages.
        Array.fold (fun schemas cur ->
            match s.intra_schemas.[cur] with
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
            ) (schemas,s.intra_schemas) potential_floating_garbage
    order, {full_schemas=schemas; package_links=links; intra_schemas=loads}

let package_errors order (s : PackageMaps) =
    Array.map (fun dir -> 
        match Map.tryFind dir s.full_schemas with
        | Some(Ok x) -> {|uri=spiproj_link dir; errors=List.append x.schema.errors x.package_errors|}
        | _ -> {|uri=spiproj_link dir; errors=[]|}
        ) order

let schema_parse_then_validate project_dir text =
    match config text with
    | Ok x -> schema_validate project_dir x
    | Error er -> {schema=schema_def; packages=[]; links=[]; actions=[]; errors=er; files=[]}