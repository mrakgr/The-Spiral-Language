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
    dirty_packages, {s with packages_infer = packages_infer}

let proj_graph_update s dirty_packages =
    let package_ids = package_ids_update s.packages s.package_ids dirty_packages
    let graph = graph_update s.packages s.graph dirty_packages
    proj_validate {s with graph = graph; package_ids = package_ids} dirty_packages

let proj_open s (dir, text) =
    let packages,dirty_packages,modules = loader_package s.packages s.modules (dir,text)
    proj_graph_update {s with packages = packages; modules = modules} dirty_packages

let proj_revalidate_owner s file =
    let rec loop (x : DirectoryInfo) =
        if x = null then HashSet(), s
        elif Map.containsKey x.FullName s.packages then proj_validate s (HashSet([x.FullName]))
        elif File.Exists(spiproj_suffix x.FullName) then proj_open s (x.FullName,None)
        else loop x.Parent
    loop (Directory.GetParent(file))

let proj_delete s (files : string []) =
    let dirty_modules = HashSet()
    let dirty_packages = HashSet()
    files |> Array.iter (fun k ->
        s.packages |> Map.iter (fun k' _ ->
            if (spiproj_suffix k').StartsWith(k) then 
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
    dirty_modules,proj_graph_update {s with modules = modules; packages = packages} dirty_packages


type AttentionState = {
    modules : string Set * string list
    packages : string Set * string list
    supervisor : SupervisorState
    }

let attention_server (errors : SupervisorErrorSources) req =
    let push path (s,o) = Set.add path s, path :: o
    let add (s,o) l = List.foldBack (fun x (s,o as z) -> if Set.contains x s then z else Set.add x s, x :: o) l (s,o)
    let update (s : AttentionState) (modules,packages,supervisor) = {modules = add s.modules modules; packages = add s.packages packages; supervisor = supervisor}
    let rec loop (s : AttentionState) =
        let clear l = l |> List.iter (fun x ->
            let uri = Utils.file_uri x
            Hopac.start (Src.value errors.tokenizer {|uri=uri; errors=[]|})
            Hopac.start (Src.value errors.parser {|uri=uri; errors=[]|})
            Hopac.start (Src.value errors.typer {|uri=uri; errors=[]|})
            )

        let inline body uri interrupt ers ers' src next = interrupt <|> (Alt.unit() ^=> fun () ->
            if List.isEmpty ers then next ers'
            else
                let ers = List.append ers ers'
                Hopac.start (Src.value src {|uri=uri; errors=ers|})
                next ers
            )

        let loop_module (s : AttentionState) mpath (m : WDiff.ModuleState) =
            let uri = Utils.file_uri mpath
            let interrupt = req ^=> fun x -> clear [mpath]; loop (update {s with modules=push mpath s.modules} x)
            let rec bundler (r : BlockBundling.BlockBundleState) ers' = r ^=> function
                | Cons((_,x),rs) -> body uri interrupt x.errors ers' errors.parser (bundler rs)
                | Nil -> loop s
            Hopac.start (Src.value errors.tokenizer {|uri=uri; errors=m.tokenizer.errors|})
            bundler m.bundler []

        let rec loop_package (s : AttentionState) pdir mpaths = function
            | (mpath,l) :: ls ->
                let uri = Utils.file_uri mpath
                let interrupt = req ^=> fun x -> clear (mpath :: mpaths); loop (update {s with packages=push pdir s.packages} x)
                let rec typer (r : WDiff.TypecheckerStateValue Stream) ers' = r ^=> function
                    | Cons((_,x,_),rs) -> body uri interrupt x.errors ers' errors.typer (typer rs)
                    | Nil -> loop_package s pdir (mpath :: mpaths) ls
                let rec bundler (r : BlockBundling.BlockBundleState) ers' = r ^=> function
                    | Cons((_,x),rs) -> body uri interrupt x.errors ers' errors.parser (bundler rs)
                    | Nil -> typer l []
                let m = s.supervisor.modules.[mpath]
                Hopac.start (Src.value errors.tokenizer {|uri=uri; errors=m.tokenizer.errors|})
                bundler m.bundler []
            | [] -> loop s

        let package s =
            match s.packages with
            | se,x :: xs -> 
                let s = {s with packages=Set.remove x se,xs}
                let package_errors = 
                    match Map.tryFind x s.supervisor.packages with 
                    | Some v -> List.concat [v.errors_parse; v.errors_modules; v.errors_packages]
                    | None -> []
                Hopac.start (Src.value errors.package ({|uri=Utils.file_uri(spiproj_suffix x); errors=package_errors|}))
                match Map.tryFind x (fst s.supervisor.package_ids) with
                | Some uid ->
                    match Map.tryFind uid s.supervisor.packages_infer.ok with
                    | Some v -> 
                        let path_tcvals =
                            let uids_file = v.files.uids_file
                            let rec loop x s = 
                                match x with
                                | WDiff.File(mid,path,_) -> (path, (fst uids_file.[mid]).result) :: s
                                | WDiff.Directory(_,_,l) -> list l s
                            and list l s = List.foldBack loop l s
                            list v.files.files.tree []
                        loop_package s x [] path_tcvals
                    | None -> loop s
                | None -> loop s
            | _, [] -> req ^=> (update s >> loop)

        match s.modules with
        | se,x :: xs -> 
            let s = {s with modules=Set.remove x se,xs}
            match Map.tryFind x s.supervisor.modules with
            | Some v -> loop_module s x v
            | None -> clear [x]; package s
        | _,[] -> package s

    Job.foreverServer (req >>= fun (modules,packages,supervisor) -> 
        loop {modules = Set.ofList modules,modules; packages = Set.ofList packages, packages; supervisor = supervisor}
        )

let show_position (s : SupervisorState) (x : PartEval.Prepass.Range) =
    let line = (fst x.range).line
    let col = (fst x.range).character
    let er_code = s.modules.[x.path].tokenizer.lines_text.[line]
    Text.StringBuilder()
        .AppendLine(sprintf "Error trace on line: %i, column: %i in module: %s." (line+1) (col+1) x.path)
        .AppendLine(er_code)
        .Append(' ',col)
        .AppendLine("^")
        .ToString()

let show_trace s (x : PartEval.Main.Trace) (msg : string) =
    let rec loop (l : PartEval.Main.Trace) = function
        | (x : PartEval.Prepass.Range) :: xs -> 
            match l with
            | x' :: _ when x.path = x'.path && fst x.range = fst x'.range -> loop l xs
            | _ -> loop (x :: l) xs
        | _ -> l
    List.map (show_position s) (loop [] x), msg

type BuildResult =
    | BuildOk of code: string * file_extension : string
    | BuildErrorTrace of string list * string
    | BuildFatalError of string

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let file uri = FileInfo(Uri(uri).LocalPath).FullName
let supervisor_server atten (errors : SupervisorErrorSources) req =
    let fatal x = Hopac.start (Src.value errors.fatal x)
    let handle_packages (dirty_packages,s) = Hopac.start (Src.value atten ([],Seq.toList dirty_packages,s)); s
    let handle_file_packages file (dirty_packages,s) = Hopac.start (Src.value atten ([file],Seq.toList dirty_packages,s)); s
    let handle_files_packages (dirty_files,(dirty_packages,s)) = Hopac.start (Src.value atten (Seq.toList dirty_files,Seq.toList dirty_packages,s)); s
    let loop (s : SupervisorState) = req >>- function
        | ProjectFileChange x | ProjectFileOpen x -> proj_open s (dir x.uri,Some x.spiprojText) |> handle_packages
        | FileOpen x -> 
            let file = file x.uri
            match Map.tryFind file s.modules with
            | Some m -> WDiff.wdiff_module_all m x.spiText
            | None -> WDiff.wdiff_module_init_all (is_top_down file) x.spiText
            |> fun v -> proj_revalidate_owner {s with modules = Map.add file v s.modules} file
            |> handle_file_packages file
        | FileChange x ->
            let file = file x.uri
            match Map.tryFind file s.modules with
            | None -> fatal "It is not possible to apply a change to a file that is not present in the environment. Try reopening it in the editor."; s
            | Some m -> 
                match WDiff.wdiff_module_edit m x.spiEdit with
                | Ok v -> proj_revalidate_owner {s with modules = Map.add file v s.modules} file |> handle_file_packages file
                | Error er -> fatal er; s
        | FileDelete x -> proj_delete s (Array.map file x.uris) |> handle_files_packages
        | ProjectFileLinks(x,res) -> 
            match Map.tryFind (dir x.uri) s.packages with
            | None -> ()
            | Some x ->
                let mutable l = []
                x.schema.packages |> List.iter (fun x ->
                    let r,dir = x.dir
                    if Map.containsKey dir s.packages then l <- (r,Utils.file_uri (spiproj_suffix dir)) :: l
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
            | Error x -> fatal x; s
            | Ok null -> s
            | Ok path -> proj_delete s [|path|] |> handle_files_packages
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
                    | Nil -> go_hover s
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
        | BuildFile x ->
            let backend = x.backend
            let file = file x.uri
            let handle_build_result = function
                | BuildOk(x,ext) -> Job.fromUnitTask (fun () -> IO.File.WriteAllTextAsync(IO.Path.ChangeExtension(file,ext), x))
                | BuildFatalError x -> Src.value errors.fatal x
                | BuildErrorTrace(a,b) -> Src.value errors.traced {|trace=a; message=b|}
            let file_build (s : SupervisorState) mid (tc : WDiff.ProjStateTC, prepass : WDiff.Prepass.ProjStatePrepass) =
                let _,b = tc.files.uids_file.[mid]
                let x,_ = prepass.files.uids_file.[mid]
                Hopac.start (b >>= fun (has_error,_) ->
                    if has_error then fatal $"File {Path.GetFileNameWithoutExtension file} has a type error somewhere in its path."; Job.unit() else 
                    Stream.foldFun (fun _ (_,_,env) -> env) PartEval.Prepass.top_env_empty x.result >>= fun env ->
                    match Map.tryFind "main" env.term with
                    | Some main ->
                        let prototypes_instances = Dictionary(env.prototypes_instances)
                        let nominals = 
                            let t = HashConsing.HashConsTable()
                            let d = Dictionary()
                            env.nominals |> Map.iter (fun k v -> d.Add(k, t.Add {|v with id=k|}))
                            d
                        try let (a,_),b = PartEval.Main.peval {prototypes_instances=prototypes_instances; nominals=nominals} main
                            match backend with
                            | "Fsharp" -> BuildOk(Codegen.Fsharp.codegen b a, "fsx")
                            | "Cython" -> BuildOk(Codegen.Cython.codegen b a, "pyx")
                            | _ -> BuildFatalError $"Cannot recognize the backend: {backend}"
                        with
                            | :? PartEval.Main.TypeError as e -> BuildErrorTrace(show_trace s e.Data0 e.Data1)
                            | :? CodegenUtils.CodegenError as e -> BuildFatalError(e.Data0)
                            | :? CodegenUtils.CodegenErrorWithPos as e -> BuildErrorTrace(show_trace s e.Data0 e.Data1)
                    | None -> BuildFatalError $"Cannot find `main` in file {Path.GetFileNameWithoutExtension file}."
                    |> handle_build_result
                    )
            let file_find (s : SupervisorState) pdir =
                let uid = (fst s.package_ids).[pdir]
                match Map.tryFind uid s.packages_infer.ok, Map.tryFind uid s.packages_prepass.ok with
                | Some a, Some b -> 
                    let rec loop = function
                        | WDiff.Directory(_,_,l) -> list l
                        | WDiff.File(mid,path,_) -> if file = path then file_build s mid (a, b); true else false
                    and list l = List.exists loop l
                    if list b.files.files.tree = false then fatal $"File {Path.GetFileNameWithoutExtension file} cannot be found in the project {spiproj_suffix pdir}"
                    s
                | None, None -> fatal $"Owner of file {Path.GetFileNameWithoutExtension file} has an error. Location: {spiproj_suffix pdir}"; s
                | _ -> failwith "Compiler error: The project status should be the same in both infer and prepass."
            let update_owner pdir =
                let order,dirty_packages = Graph.topological_sort (fst s.graph) [pdir]
                let packages_prepass = wdiff_projenvr_prepass (fst s.package_ids) s.packages s.packages_infer.ok s.packages_prepass (dirty_packages, order.ToArray())
                file_find {s with packages_prepass = packages_prepass} pdir
            let rec find_owner (x : DirectoryInfo) =
                if x = null then fatal $"Cannot find the package file of {file}"; s
                elif Map.containsKey x.FullName s.packages then update_owner x.FullName
                else find_owner x.Parent
            find_owner (Directory.GetParent(file))


    Job.iterateServer {
        packages = Map.empty
        modules = Map.empty
        packages_infer = {ok=Map.empty; error=Map.empty}
        packages_prepass = {ok=Map.empty; error=Map.empty}
        graph = mirrored_graph_empty
        package_ids = Map.empty, Map.empty
        } loop

type ClientReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileLinks of {|uri : string|}
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
    | ProjectCodeActions of {|uri : string|}
    | FileOpen of {|uri : string; spiText : string|}
    | FileChange of {|uri : string; spiEdit : SpiEdit|}
    | FileDelete of {|uris : string []|} // Also works for project files and directories.
    | FileTokenRange of {|uri : string; range : VSCRange|}
    | HoverAt of {|uri : string; pos : VSCPos|}
    | BuildFile of {|uri : string; backend : string|}
    | Ping of bool

type ClientErrorsRes =
    | FatalError of string
    | TracedError of TracedError
    | PackageErrors of {|uri : string; errors : RString list|}
    | TokenizerErrors of {|uri : string; errors : RString list|}
    | ParserErrors of {|uri : string; errors : RString list|}
    | TypeErrors of {|uri : string; errors : RString list|}

open FSharp.Json
open NetMQ
open NetMQ.Sockets

let [<EntryPoint>] main args =
    let env_def = {|
        port = 13805
        |}
    let env = (env_def, args) ||> Array.fold (fun s x -> 
        match x.Split('=') with
        | [|"port"; x|] -> {|s with port = Int32.Parse(x)|}
        | _ -> failwithf "Invalid command line argument received when starting up the server.\nGot: %A" x
        )
    let uri_server = sprintf "tcp://*:%i" env.port
    let uri_client = sprintf "tcp://*:%i" (env.port+1)
    use poller = new NetMQPoller()
    use server = new RouterSocket()
    poller.Add(server)
    server.Options.ReceiveHighWatermark <- System.Int32.MaxValue
    server.Bind(uri_server)

    use queue_server = new NetMQQueue<NetMQMessage>()
    poller.Add(queue_server)

    use queue_client = new NetMQQueue<ClientErrorsRes>()
    poller.Add(queue_client)

    let consumed_source msg =
        let x = Src.create()
        Src.tap x |> Stream.consumeFun (msg >> queue_client.Enqueue)
        x
    let errors : SupervisorErrorSources = {
        fatal = consumed_source FatalError
        package = consumed_source PackageErrors
        tokenizer = consumed_source TokenizerErrors
        parser = consumed_source ParserErrors
        typer = consumed_source TypeErrors
        traced = consumed_source TracedError
        }
    let supervisor = Ch()
    let atten = Src.create()
    Hopac.start (attention_server errors (Src.tap atten |> Stream.values))
    Hopac.start (supervisor_server atten errors supervisor)

    let mutable time = DateTimeOffset.Now
    #if !DEBUG 
    let timer = NetMQTimer(2000)
    poller.Add(timer)
    timer.EnableAndReset()
    use __ = timer.Elapsed.Subscribe(fun _ ->
        if TimeSpan.FromSeconds(2.0) < DateTimeOffset.Now - time then poller.Stop()
        )
    #endif

    use __ = server.ReceiveReady.Subscribe(fun s ->
        let msg = server.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore
        let x = Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer))
        let push_back (x : obj) = 
            match x with
            | :? Option<string> as x -> 
                match x with
                | Some x -> msg.Push(x)
                | None -> msg.PushEmptyFrame()
            | _ -> msg.Push(Json.serialize x)
            msg.PushEmptyFrame(); msg.Push(address)
        let send_back x = push_back x; server.SendMultipartMessage(msg)
        let send_back_via_queue x = push_back x; queue_server.Enqueue(msg)
        let job_null job = Hopac.start job; send_back null
        let job_val job = let res = IVar() in Hopac.start (job res >>=. IVar.read res >>- send_back_via_queue)
        match x with
        | ProjectFileOpen x -> job_null (supervisor *<+ SupervisorReq.ProjectFileOpen x)
        | ProjectFileChange x -> job_null (supervisor *<+ SupervisorReq.ProjectFileChange x)
        | ProjectCodeActionExecute x -> job_val (fun res -> supervisor *<+ SupervisorReq.ProjectCodeActionExecute(x,res))
        | ProjectFileLinks x -> job_val (fun res -> supervisor *<+ SupervisorReq.ProjectFileLinks(x,res))
        | ProjectCodeActions x -> job_val (fun res -> supervisor *<+ SupervisorReq.ProjectCodeActions(x,res))
        | FileOpen x -> job_null (supervisor *<+ SupervisorReq.FileOpen x)
        | FileChange x -> job_null (supervisor *<+ SupervisorReq.FileChange x)
        | FileDelete x -> job_null (supervisor *<+ SupervisorReq.FileDelete x)
        | FileTokenRange x -> job_val (fun res -> supervisor *<+ SupervisorReq.FileTokenRange(x,res))
        | HoverAt x -> job_val (fun res -> supervisor *<+ SupervisorReq.HoverAt(x,res))
        | BuildFile x -> job_null (supervisor *<+ SupervisorReq.BuildFile x)
        | Ping _ -> send_back null
        time <- DateTimeOffset.Now
        )

    use client = new PublisherSocket()
    client.Bind(uri_client)

    printfn "Server bound to: %s & %s" uri_server uri_client

    use __ = queue_client.ReceiveReady.Subscribe(fun x -> 
        x.Queue.Dequeue() |> Json.serialize |> client.SendFrame
        )

    use __ = queue_server.ReceiveReady.Subscribe(fun x -> x.Queue.Dequeue() |> server.SendMultipartMessage)

    poller.Run()
    0