module Spiral.Supervisor

open VSCTypes
open Graph
open Spiral.ServerUtils

open System
open System.IO
open System.Collections.Generic

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type LocalizedErrors = {|uri : string; errors : RString list|}
type TracedError = {|trace : string list; message : string|}
type SupervisorErrorSources = {
    fatal : string Src
    tokenizer : LocalizedErrors Src
    parser : LocalizedErrors Src
    typer : LocalizedErrors Src
    package : LocalizedErrors Src
    traced : TracedError Src
    }

type SupervisorReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileLinks of {|uri : string|} * RString list IVar
    | ProjectCodeActions of {|uri : string|} * RAction list IVar
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|} * {|result : string option|} IVar
    | FileOpen of {|uri : string; spiText : string|}
    | FileChange of {|uri : string; spiEdit : SpiEdit|}
    | FileDelete of {|uris : string []|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * int [] IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar
    | BuildFile of {|uri : string; backend : string|}

type SupervisorState = {
    packages : SchemaEnv
    modules : ModuleEnv
    packages_infer : ResultMap<PackageId,WDiff.ProjStateTC>
    packages_prepass : ResultMap<PackageId,WDiff.Prepass.ProjStatePrepass>
    graph : MirroredGraph
    package_ids : Map<string,int> * Map<int,string>
    }

let proj_validate s dirty_packages =
    let order,socs = Graph.circular_nodes s.graph dirty_packages
    let packages = ss_validate s.packages s.modules (order,socs)
    let packages_infer = wdiff_projenvr_tc (fst s.package_ids) packages s.modules s.packages_infer (dirty_packages, order)
    {s with packages_infer = packages_infer}

let proj_graph_update s dirty_packages =
    let package_ids = package_ids_update s.packages s.package_ids dirty_packages
    let graph = graph_update s.packages s.graph dirty_packages
    proj_validate {s with graph = graph; package_ids = package_ids} dirty_packages

let proj_open s (dir, text) =
    let packages,dirty_packages,modules = loader_package s.packages s.modules (dir,text)
    proj_graph_update {s with packages = packages; modules = modules} dirty_packages

let proj_revalidate_owner s file =
    let rec loop (x : DirectoryInfo) =
        if x = null then s
        elif Map.containsKey x.FullName s.packages then proj_validate s (HashSet([x.FullName]))
        elif File.Exists(Path.Combine(x.FullName,"package.spiproj")) then proj_open s (x.FullName,None)
        else loop x.Parent
    loop (Directory.GetParent(file))

let proj_delete s (files : string []) =
    let dirty_modules = HashSet()
    let dirty_packages = HashSet()
    files |> Array.iter (fun k ->
        s.packages |> Map.iter (fun k' _ ->
            if Path.Combine(k',"package.spiproj").StartsWith(k) then 
                dirty_packages.Add(k') |> ignore
                let rec delete_parent (x : DirectoryInfo) =
                    if x = null then ()
                    elif Map.containsKey x.FullName s.packages then dirty_packages.Add(x.FullName) |> ignore
                    else delete_parent x.Parent
                delete_parent (Directory.GetParent(k'))
            )
        s.modules |> Map.iter (fun k' _ ->
            if k'.StartsWith(k) then dirty_modules.Add(k') |> ignore
            )
        )
    let modules = Seq.foldBack Map.remove dirty_modules s.modules
    let packages = Seq.foldBack Map.remove dirty_packages s.packages
    proj_graph_update {s with modules = modules; packages = packages} dirty_packages


type AttentionState = {
    modules : string Set * string list
    packages : string Set * string list
    supervisor : SupervisorState
    }

let attention_server (errors : SupervisorErrorSources) req =
    let add (s,o) l = List.foldBack (fun x (s,o as z) -> if Set.contains x s then z else Set.add x s, x :: o) l (s,o)
    let rec listen (s : AttentionState) = req ^=> fun (modules,packages,supervisor) ->
        loop {modules = add s.modules modules; packages = add s.packages packages; supervisor = supervisor}
    and loop s =
        let l : WDiff.TypecheckerStateValue Stream list = failwith "TODO"
        let rec loop_modules = function
            | (path,l) :: ls ->
                let rec loop_module ers = function
                    // TODO: The current list should be zeroed out before moving to the next.
                    | x :: xs -> listen s <|> (x ^=> fun ((_,x,_) : WDiff.TypecheckerStateValue) -> loop_module (List.append x.errors ers) xs)
                    | [] -> Hopac.start (Src.value errors.typer {|uri=Utils.file_uri path; errors=ers|}); loop_modules ls
                loop_module [] l
            | [] ->
                match s.packages with
                | pdir_set,pdir :: pdirs -> loop {s with packages=Set.remove pdir pdir_set,pdirs}
                | _ -> failwith "Compiler error: The processed package cannot be empty."
                
        failwith ""
    

    Job.foreverServer (req >>= fun (modules,packages,supervisor) -> 
        loop {modules = Set.ofList modules,modules; packages = Set.ofList packages, packages; supervisor = supervisor}
        )

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let file uri = FileInfo(Uri(uri).LocalPath).FullName
let supervisor_server (errors : SupervisorErrorSources) req =
    let loop (s : SupervisorState) = req >>- function
        | ProjectFileChange x | ProjectFileOpen x -> proj_open s (dir x.uri,Some x.spiprojText)
        | FileOpen x -> 
            let file = file x.uri
            match Map.tryFind file s.modules with
            | Some m -> WDiff.wdiff_module_all m x.spiText
            | None -> WDiff.wdiff_module_init_all (is_top_down file) x.spiText
            |> fun v -> proj_revalidate_owner {s with modules = Map.add file v s.modules} file
        | FileChange x ->
            let file = file x.uri
            match Map.tryFind file s.modules with
            | None -> Hopac.start (Src.value errors.fatal "It is not possible to apply a change to a file that is not present in the environment. Try reopening it in the editor."); s
            | Some m -> 
                match WDiff.wdiff_module_edit m x.spiEdit with
                | Ok v -> proj_revalidate_owner {s with modules = Map.add file v s.modules} file
                | Error er -> Hopac.start (Src.value errors.fatal er); s
        | FileDelete x -> proj_delete s (Array.map file x.uris)
        | ProjectFileLinks(x,res) -> 
            match Map.tryFind (dir x.uri) s.packages with
            | None -> ()
            | Some x ->
                let mutable l = []
                x.schema.packages |> List.iter (fun x ->
                    let r,dir = x.dir
                    if Map.containsKey dir s.packages then l <- (r,Utils.file_uri (Path.Combine(dir,"package.spiproj"))) :: l
                    )
                let rec loop = function
                    | SpiProj.FileHierarchy.Directory(_,_,_,l) -> list l
                    | SpiProj.FileHierarchy.File(_,(r,path),_) -> if Map.containsKey path s.modules then l <- (r,path) :: l
                and list l = List.iter loop l
                list x.schema.modules
                Hopac.start (IVar.fill res l)
            s
        | ProjectCodeActions(x,res) ->
            match Map.tryFind (dir x.uri) s.packages with
            | None -> ()
            | Some x ->
                let mutable z = []
                let actions_dir (r,path) =
                    match r with
                    | None -> ()
                    | Some r ->
                        if Directory.Exists(path) then
                            z <- (r,RenameDirectory {|dirPath=path; target=null; validate_as_file=false|}) :: (r,DeleteDirectory {|dirPath=path; range=r|}) :: z
                        else
                            z <- (r,CreateDirectory {|dirPath=path|}) :: z
                actions_dir x.schema.moduleDir
                actions_dir x.schema.packageDir

                let rec actions_module = function
                    | SpiProj.FileHierarchy.Directory(r',(r,path),_,l) -> 
                        if Directory.Exists(path) then
                            z <- (r,RenameDirectory {|dirPath=path; target=null; validate_as_file=true|}) :: (r,DeleteDirectory {|dirPath=path; range=r'|}) :: z
                        else
                            z <- (r,CreateDirectory {|dirPath=path|}) :: z
                        actions_modules l
                    | SpiProj.FileHierarchy.File(r',(r,path),_) -> 
                        if Map.containsKey path s.modules then 
                            z <- (r,RenameFile {|filePath=path; target=null|}) :: (r,DeleteFile {|range=r'; filePath=path|}) :: z
                        else 
                            z <- (r,CreateFile {|filePath=path|}) :: z
                and actions_modules l = List.iter actions_module l
                actions_modules x.schema.modules
                Hopac.start (IVar.fill res z)
            s
        | ProjectCodeActionExecute(x,res) ->
            match code_action_execute x.action with
            | Error x -> Hopac.start (Src.value errors.fatal x); s
            | Ok null -> s
            | Ok path -> proj_delete s [|path|]
        | FileTokenRange(x, res) -> 
            Map.tryFind (file x.uri) s.modules
            |> Option.iter (fun v -> Hopac.start (BlockBundling.semantic_tokens v.parser >>= (Tokenize.vscode_tokens x.range >> IVar.fill res)))
            s
        | HoverAt(x,res) -> 
            let file = file x.uri
            let pos = x.pos
            let go_hover = function
                | None -> Job.unit()
                | Some (x : Infer.InferResult) ->
                    x.hovers |> Array.tryPick (fun ((a,b),r) ->
                        if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
                        )
                    |> IVar.fill res
            let go_block (x : WDiff.TypecheckerState) =
                let rec loop s (x : WDiff.TypecheckerStateValue Stream) =
                    x >>= function
                    | Nil -> Job.unit()
                    | Cons((_,x,_),b) ->
                        if x.offset <= pos.line then loop (Some x) b
                        // If the block is over the offset that means the previous one must be the right choice.
                        else go_hover s
                Hopac.start (loop None x.result)
            let rec go_file uids_file trees = 
                let rec loop = function
                    | WDiff.File(uid,file',_) -> if file = file' then go_block (Array.get uids_file uid |> fst); true else false
                    | WDiff.Directory(_,_,l) -> list l
                and list l = List.exists loop l
                list trees |> ignore
            let rec go_parent (x : DirectoryInfo) =
                if x = null then ()
                else
                    if Map.containsKey x.FullName s.packages then
                        let pid = (fst s.package_ids).[x.FullName]
                        match Map.tryFind pid s.packages_infer.ok with
                        | None -> ()
                        | Some x -> go_file x.files.uids_file x.files.files.tree
                    else 
                        go_parent x.Parent
            go_parent (Directory.GetParent(file))
            s
        | BuildFile x -> failwith ""

    Job.iterateServer {
        packages = Map.empty
        modules = Map.empty
        packages_infer = {ok=Map.empty; error=Map.empty}
        packages_prepass = {ok=Map.empty; error=Map.empty}
        graph = mirrored_graph_empty
        package_ids = Map.empty, Map.empty
        } loop
