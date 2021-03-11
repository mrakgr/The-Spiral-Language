module Spiral.ServerUtils
open System
open System.IO
open System.Collections.Generic

open VSCTypes
open Graph
open Spiral.SpiProj

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

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

open WDiff

type SchemaState = { schema : Schema; errors_parse : RString list; errors_modules : RString list; errors_packages : RString list}
type SchemaEnv = Map<string,SchemaState>
type ModuleEnv = Map<string,ModuleState>

let ss_empty = {
    schema = {moduleDir = None, null; modules = []; packageDir = None, null; packages = []}
    errors_parse = []; errors_modules = []; errors_packages = []
    }
let ss_from_result = function
    | Ok schema -> {ss_empty with schema = schema}
    | Error ers -> {ss_empty with errors_parse = ers}
let ss_validate_module (packages : SchemaEnv) (modules : ModuleEnv) (x : SchemaState) =
    let errors = ResizeArray()
    let rec loop = function
        | SpiProj.FileHierarchy.Directory(_,(r,path),_,l) -> 
            if Map.containsKey path packages then errors.Add(r,"Module directory has a package file in it.")
            list l
        | SpiProj.FileHierarchy.File(_,(r,path),_) -> if Map.containsKey path modules = false then errors.Add(r,"Module not loaded.")
    and list l = List.iter loop l
    list x.schema.modules
    Seq.toList errors
let ss_validate_modules (packages : SchemaEnv) modules order = 
    Array.fold (fun s x ->
        match Map.tryFind x s with
        | Some v -> Map.add x {v with errors_modules = ss_validate_module packages modules v} s
        | None -> s
        ) packages order

let ss_has_error x = (List.isEmpty x.errors_parse && List.isEmpty x.errors_modules && List.isEmpty x.errors_packages) = false
let ss_validate_packages (packages : SchemaEnv) (order : string [], socs : Dictionary<string,int>) : SchemaEnv =
    Array.fold (fun s path ->
        match Map.tryFind path s with
        | Some (x : SchemaState) -> 
            let c p = match socs.TryGetValue(p) with true,b -> b | false,_ -> -1
            let is_circular x = x <> -1
            let are_in_same_strong_component a b = is_circular a && is_circular b && a = b
            let ers =
                let cpath = c path
                (x.schema.packages, []) ||> List.foldBack (fun {path=r,p} ers ->
                    let cp = c p
                    if are_in_same_strong_component cpath cp then (r,"Package is circular and loops through the current one.") :: ers
                    elif path = p then (r,"Self referential links are not allowed.") :: ers
                    else
                        match Map.tryFind p s with
                        | Some s' when ss_has_error s' -> (r,"Package has an error.") :: ers
                        | Some _ -> ers
                        | None -> (r,"Package not loaded.") :: ers
                    ) 
            Map.add path {x with errors_packages=ers} s
        | _ -> s
        ) packages order

let ss_validate packages modules (order,socs) =
    let packages = ss_validate_modules packages modules order
    ss_validate_packages packages (order,socs)

type ResultMap<'a,'b> when 'a : comparison = {ok : Map<'a,'b>; error: Map<'a,'b>}
type ProjEnvTCResult = ResultMap<PackageId,ProjStateTC>

let wdiff_projenvr_sync_schema funs_packages funs_files (ids : Map<string, PackageId>) (packages : SchemaEnv) 
        (state : ResultMap<PackageId,ProjState<'file_input,'file,'package>>) order =
    Array.fold (fun (s : ResultMap<_,_>) x ->
        let pid = ids.[x]
        match Map.tryFind x packages with
        | Some schema ->
            match Map.tryFind pid s.ok, Map.tryFind pid s.error, ss_has_error schema with
            | Some _, Some _,_ -> failwith "Compiler error: The ok and error maps should be disjoint."
            | Some x, None, true -> {ok=Map.remove pid s.ok; error=Map.add pid x s.error}
            | None, Some x, false -> {ok=Map.add pid x s.ok; error=Map.remove pid s.error}
            | None, None, c -> 
                let x = wdiff_proj_init funs_packages funs_files pid
                if c then {s with error=Map.add pid x s.error} else {s with ok=Map.add pid x s.ok}
            | _ -> s
        | None -> {ok=Map.remove pid s.ok; error=Map.remove pid s.error}
        ) state order

let projenv_update_packages funs_packages funs_files (ids : Map<string, PackageId>) (packages : SchemaEnv)
        (state : Map<PackageId,ProjState<'a,'b,'state>>)  (dirty_packages : Dictionary<_,_>, order : string []) =
    Array.foldBack (fun x l ->
        match Map.tryFind x packages with
        | None -> l
        | Some schema when ss_has_error schema -> l
        | Some schema ->
            let pid = ids.[x]
            let packages = schema.schema.packages |> List.map (fun x -> x.name, ids.[snd x.path])
            match dirty_packages.TryGetValue(x) with
            | true, x -> UpdatePackageModule(pid,packages,x) :: l
            | false, _ -> UpdatePackage(pid,packages) :: l
        ) order []
    |> wdiff_projenv_update_packages funs_packages funs_files state

let inline proj_file_iter_file f (files : ProjFiles) =
    let rec loop = function
        | File(module_id,path,_) -> f module_id path
        | Directory(_,_,l) -> list l
    and list l = List.iter loop l
    list files.tree

let proj_file_get_input uids_file (x : ProjFiles) =
    let d = Dictionary(Array.length uids_file)
    proj_file_iter_file (fun mid path -> d.Add(path, Array.get uids_file mid |> fst)) x
    d

let proj_file_from_schema (x : Schema) : ProjFiles =
    let mutable num_files = 0
    let mutable num_dirs = 0
    let rec loop = function
        | FileHierarchy.File(_,(_,path),name) -> 
            let uid = num_files
            num_files <- num_files + 1
            File(uid,path,name)
        | FileHierarchy.Directory(_,_,name,l) ->
            let uid = num_dirs
            num_dirs <- num_dirs + 1
            Directory(uid,name,list l)
    and list l = List.map loop l
    let tree = list x.modules
    { tree = tree; num_files = num_files; num_dirs = num_dirs }

let inline proj_file_make_input f (files : ProjFiles) =
    let ar = Array.zeroCreate files.num_files
    proj_file_iter_file (fun mid path -> ar.[mid] <- f mid path) files
    ar

let inline dirty_nodes_template funs (ids : Map<string, PackageId>) (packages : SchemaEnv) modules
        (state : Map<PackageId,_>) (dirty_packages : string HashSet) =
    let d = Dictionary<string,_ [] * ProjFiles>()
    dirty_packages |> Seq.iter (fun path ->
        let pid = ids.[path]
        match Map.tryFind pid state with
        | Some x -> 
            let modules = modules pid
            let files = proj_file_from_schema packages.[path].schema
            let state = 
                let state = proj_file_get_input x.files.uids_file x.files.files
                proj_file_make_input (fun mid path ->
                    match state.TryGetValue(path) with
                    | true, x -> wdiff_file_update_input funs x (modules mid path)
                    | false, _ -> funs.init (modules mid path)
                    ) files
            d.Add(path,(state,files))
        | None ->
            ()
        )
    d

let dirty_nodes_tc (ids : Map<string, PackageId>) (packages : SchemaEnv) (modules : ModuleEnv)
        (state : Map<PackageId,ProjStateTC>) (dirty_packages : string HashSet) =
    dirty_nodes_template funs_file_tc ids packages (fun pid mid path -> pid, mid, modules.[path].bundler) state dirty_packages

open WDiff.Prepass
let dirty_nodes_prepass (ids : Map<string, PackageId>) (packages : SchemaEnv) (modules : Map<PackageId,ProjStateTC>)
        (state : Map<PackageId,ProjStatePrepass>) (dirty_packages : string HashSet) =
    let modules pid =
        let x = modules.[pid]
        let state = proj_file_get_input x.files.uids_file x.files.files
        fun (mid : ModuleId) path -> pid, mid, path, state.[path].result
    dirty_nodes_template funs_file_prepass ids packages modules state dirty_packages

let wdiff_projenvr_update_packages dirty_nodes funs_proj_package funs_proj_file 
        ids packages modules (state : ResultMap<PackageId,_>) (dirty_packages, order) =
    let state = wdiff_projenvr_sync_schema funs_proj_package funs_proj_file ids packages state order
    let dirty_packages = dirty_nodes ids packages modules state.ok dirty_packages
    {state with ok=projenv_update_packages funs_proj_package funs_proj_file ids packages state.ok (dirty_packages, order)}

let wdiff_projenvr_update_packages_tc ids packages modules state (dirty_packages, order) =
    wdiff_projenvr_update_packages dirty_nodes_tc funs_proj_package_tc funs_proj_file_tc 
        ids packages modules state (dirty_packages, order)

let wdiff_projenvr_update_packages_prepass ids packages modules state (dirty_packages, order) =
    wdiff_projenvr_update_packages dirty_nodes_prepass funs_proj_package_prepass funs_proj_file_prepass 
        ids packages modules state (dirty_packages, order)

type LoadResult =
    | LoadModule of path: string * ModuleState option
    | LoadPackage of package_dir: string * SchemaState option

open System.Threading.Tasks
let is_top_down (x : string) = Path.GetExtension x = ".spi"
let loader_package (packages : SchemaEnv) (modules : ModuleEnv) (path, text) =
    let queue = Queue()

    let load_module modules path =
        match Map.tryFind path modules with
        | Some _ -> ()
        | None ->
            File.ReadAllTextAsync(path).ContinueWith(fun (x : _ Task) ->
                try LoadModule(path,wdiff_module_all (wdiff_module_init (is_top_down path)) x.Result |> Some)
                with e -> LoadModule(path,None)
                ) |> queue.Enqueue

    let load_package packages (path,text) =
        let schema (path,text) = schema (path,text) |> fun x -> LoadPackage(path,Some (ss_from_result x))
        match text with
        | Some text -> schema (path,text) |> Task.FromResult |> queue.Enqueue
        | None ->
            match Map.tryFind path packages with
            | Some _ -> ()
            | None ->
                File.ReadAllTextAsync(path).ContinueWith(fun (x : _ Task) ->
                    try schema (path,x.Result) with e -> LoadPackage(path,None)
                    ) |> queue.Enqueue

    let mutable packages = packages
    let dirty_packages = HashSet()
    let mutable modules = modules

    load_package packages (path,text)
    while 0 < queue.Count do
        match queue.Dequeue().Result with
        | LoadPackage(pdir,Some x) -> 
            packages <- Map.add pdir x packages; dirty_packages.Add(pdir) |> ignore
            x.schema.packages |> List.iter (fun x -> load_package packages (snd x.path,None))
            let rec loop = function
                | FileHierarchy.Directory(_,_,_,l) -> list l
                | FileHierarchy.File(_,(_,path),_) -> load_module modules path
            and list l = List.iter loop l
            list x.schema.modules
        | LoadPackage(pdir,None) -> packages <- Map.remove pdir packages; dirty_packages.Add(pdir) |> ignore
        | LoadModule(mdir,Some x) -> modules <- Map.add mdir x modules
        | LoadModule(mdir,None) -> modules <- Map.remove mdir modules
    packages, dirty_packages, modules

let graph_update (packages : SchemaEnv) (g : MirroredGraph) (dirty_packages : string HashSet) =
    Seq.fold (fun g x ->
        match Map.tryFind x packages with
        | Some v -> Graph.links_replace g x (v.schema.packages |> List.map (fun x -> snd x.path))
        | None -> Graph.links_remove g x
        ) g dirty_packages

let package_ids_update (packages : SchemaEnv) package_ids (dirty_packages : string HashSet) =
    let l = dirty_packages |> Seq.toArray |> Array.filter (fun x -> Map.containsKey x packages) |> Array.mapi (fun i x -> (i,x))
    Map.fold (fun s x _ ->
        Array.mapFold (fun s x -> if s = fst x then (s+1, snd x),s+1 else x,s) x s |> fst
        ) l (snd package_ids)
    |> Array.fold (fun (a,b) (k,v) -> Map.add v k a, Map.add k v b) package_ids
