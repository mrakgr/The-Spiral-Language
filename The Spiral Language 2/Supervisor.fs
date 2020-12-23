module Spiral.Supervisor

open System
open System.IO
open System.Threading.Tasks
open FSharpx.Collections
open System.Collections.Generic

open VSCTypes
open Spiral.Tokenize
open Spiral.Infer
open Spiral.ServerUtils
open Spiral.StreamServer
open Spiral.StreamServer.Main

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type LocalizedErrors = {|uri : string; errors : RString list|}
type SupervisorErrorSources = {
    fatal : string Src
    tokenizer : LocalizedErrors Src
    parser : LocalizedErrors Src
    typer : LocalizedErrors Src
    package : LocalizedErrors Src
    }

type SupervisorState = {
    modules : Map<string, ModuleStreamRes>
    infer_results : Map<string, InferResult Stream>
    diff_stream : PackageDiffStream
    prepass_stream : Prepass.PackageStream
    packages : PackageMaps
    package_ids : PackageIds
    }

module Build =
    open Spiral.StreamServer.Prepass
    exception PackageInputsException of string
    let inputs (s : SupervisorState) module_target =
        let er x = raise (PackageInputsException x)
        try let package_target =
                let rec loop (x : DirectoryInfo) =
                    if x = null then er "Cannot find the package file of the target module."
                    elif File.Exists(Path.Combine(x.FullName,"package.spiproj")) then x.FullName
                    else loop x.Parent
                loop (FileInfo(module_target).Directory)
            let visited = HashSet()
            let order = Queue()
            let rec dfs package_path =
                if visited.Add package_path then
                    match Map.tryFind package_path s.packages.package_schemas with
                    | Some(Ok x) when List.isEmpty x.package_errors && List.isEmpty x.schema.errors ->
                        let rec elem = function
                            | ServerUtils.File((_,path),name,_) -> 
                                match Map.tryFind path s.infer_results with
                                | Some r -> File(path,name,(None,r,None))
                                | None -> er <| sprintf "Cannot find the infer results for module at path: %s" path
                            | ServerUtils.Directory(name,l) -> Directory(name,list l,None)
                        and list l = List.map elem l
                        let hier = list x.schema.files
                        let links = package_named_links x
                        let id = 
                            if PersistentHashMap.containsKey package_path s.package_ids then s.package_ids.[package_path]
                            else er <| sprintf "Cannot find the package id. Path: %s" package_path
                        
                        List.iter (fun (k, _) -> dfs k) links
                        order.Enqueue(package_path,(hier,links,id))
                    | _ -> er <| sprintf "Package has an error. Path: %s" package_path
            dfs package_target
            let a = Map(order)
            let b = Seq.map fst order
            Ok(a,b,module_target)
        with :? PackageInputsException as e -> Error e.Data0

    let show_position (s : SupervisorState) (strb: Text.StringBuilder) (x : PartEval.Prepass.Range) =
        let line = (fst x.range).line
        let col = (fst x.range).character
        let er_code = s.modules.[x.path] |> fun ((x,_,_),_) -> x.[line]

        strb
            .AppendLine(sprintf "Error trace on line: %i, column: %i in module: %s." (line+1) (col+1) x.path)
            .AppendLine(er_code)
            .Append(' ', col)
            .AppendLine "^"
        |> ignore

    let trace_print_length = 5
    let show_trace s (x : PartEval.Main.Trace) (msg : string) =
        let error = Text.StringBuilder(1024)
        let x = 
            let rec loop l i = function
                | x :: x' when i > 0 -> loop (x :: l) (i-1) x'
                | _ -> l
            loop [] trace_print_length x
        List.iter (show_position s error) x
        error.AppendLine msg |> ignore
        error.ToString()

    type BuildResult =
        | BuildOk of string
        | BuildErrorTrace of string
        | BuildFatalError of string
    let build_file (s : SupervisorState) module_target =
        match inputs s module_target with
        | Ok x ->
            let a,prepass_stream = s.prepass_stream.Run(PackageStreamInput x)
            let s = {s with prepass_stream=prepass_stream}
            match a with
            | Some x ->
                x >>- fun x ->
                    if x.has_errors then BuildFatalError("There are type errors in at least one module.")
                    else 
                        match Map.tryFind "main" x.term with
                        | Some main ->
                            let top_env = package_to_top x
                            let prototypes_instances = Dictionary(top_env.prototypes_instances)
                            let nominals = 
                                let t = HashConsing.HashConsTable()
                                let d = Dictionary()
                                top_env.nominals |> Map.iter (fun k v -> d.Add(k, t.Add {|v with id=k|}))
                                d
                            try let (a,_),b = PartEval.Main.peval {prototypes_instances=prototypes_instances; nominals=nominals} main
                                BuildOk(Codegen.Fsharp.codegen b a)
                            with
                                | :? PartEval.Main.TypeError as e -> BuildErrorTrace(show_trace s e.Data0 e.Data1)
                                | :? Codegen.Fsharp.CodegenError as e -> BuildFatalError(e.Data0)
                                | :? Codegen.Fsharp.CodegenErrorWithPos as e -> BuildFatalError(show_trace s e.Data0 e.Data1)
                        | None -> BuildFatalError(sprintf "Cannot find the main function in module. Path: %s" module_target)
            | None -> Job.result (BuildFatalError(sprintf "Cannot find the target module in the package. Path: %s" module_target))
            |> fun x -> x,s
        | Error x -> Job.result (BuildFatalError x), s

type LoadResult =
    | LoadModule of package_dir: string * path: RString * Result<ModuleStreamRes,string>
    | LoadPackage of package_dir: string * Result<ValidatedSchema,string>

let parser_error errors uri ers = Hopac.start (Src.value errors.parser {|uri=uri; errors=ers|})
let is_top_down (x : string) = Path.GetExtension x = ".spi"
let package_update errors (s : SupervisorState) package_dir text =
    let queue : LoadResult Task Queue = Queue()
    let rec load_module package_dir s l =
        List.fold (fun s -> function
            | ValidatedFileHierarchy.File((r, path as p),name,exists) ->
                match Map.tryFind path s.modules with
                | Some _ -> if exists then s else {s with modules = Map.remove path s.modules}
                | None -> 
                    if exists then 
                        File.ReadAllTextAsync(path).ContinueWith(fun (x : _ Task) ->
                            try let uri = "file:///" + path
                                let ((_,tok_res,_),_ as x) = (module' (parser_error errors uri) (is_top_down path)).Run(DocumentAll(Utils.lines x.Result))
                                Hopac.start (Src.value errors.tokenizer {|uri=uri; errors=tok_res.errors|})
                                LoadModule(package_dir,p,Ok(x))
                            with e -> LoadModule(package_dir,p,Error e.Message)
                            ) |> queue.Enqueue
                    s
            | ValidatedFileHierarchy.Directory(name,l) ->
                load_module package_dir s l
            ) s l

    let load_package s package_dir text =
        match Map.tryFind package_dir s.packages.validated_schemas, text with
        | _, Some text -> // Parse and validate the schema using the provided string.
            Task.Run(fun () -> LoadPackage(package_dir, Ok(schema_parse_then_validate package_dir text)))
            |> queue.Enqueue
            s
        | Some(Ok x), None -> // Rather than reloading from disk, just revalidate it.
            Task.Run(fun () -> LoadPackage(package_dir, Ok(schema_validate package_dir x.schema)))
            |> queue.Enqueue
            s
        | _ -> // Load from disk and validate it.
            let p = Path.Combine(package_dir,"package.spiproj")
            if File.Exists(p) then 
                File.ReadAllTextAsync(p).ContinueWith(fun (x : _ Task) ->
                    try LoadPackage(package_dir, Ok(schema_parse_then_validate package_dir x.Result))
                    with e -> LoadPackage(package_dir, Error e.Message)
                    ) |> queue.Enqueue
                s
            else {s with packages={s.packages with validated_schemas=Map.add package_dir (Error "The package file does not exist.") s.packages.validated_schemas}}

    let main (s : SupervisorState) = function
        | LoadPackage(dir,x) ->
            let s = {s with packages={s.packages with validated_schemas=Map.add dir x s.packages.validated_schemas}}
            match x with
            | Ok x -> List.fold (fun s (r,x) -> load_package s x None) (load_module dir s x.files) x.packages
            | Error _ -> s
        | LoadModule(_,(_,path),Ok x) -> {s with modules=Map.add path x s.modules}
        | LoadModule(package_dir,(r,_),Error er) ->
            match Map.tryFind package_dir s.packages.validated_schemas with
            | Some (Ok x) -> {s with packages={s.packages with validated_schemas=Map.add package_dir (Ok {x with errors = (r,er) :: x.errors}) s.packages.validated_schemas}}
            | _ -> failwith "Compiler error: The package should be present and valid in the map."
    
    let mutable s = load_package s package_dir text
    while 0 < queue.Count do s <- main s (queue.Dequeue().Result)
    s

type SupervisorReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileDelete of {|uri : string|}
    | ProjectFileLinks of {|uri : string|} * RString list IVar
    | ProjectCodeActions of {|uri : string|} * RAction list IVar
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|} * {|result : string option|} IVar
    | FileOpen of {|uri : string; spiText : string|}
    | FileChange of {|uri : string; spiEdit : SpiEdit|}
    | FileDelete of {|uri : string|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * VSCTokenArray IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar
    | BuildFile of {|uri : string|}

let package_validate_then_send_errors atten errors s dir =
    let order,packages = package_validate s.packages dir
    package_errors order packages |> Array.iter (fun er -> Hopac.start (Src.value errors.package er))
    
    match s.diff_stream.Run(order,packages.package_schemas,packages.package_links,s.modules) with
    | Some (infer_results, package_ids), diff_stream ->
        let infer_results = 
            Map.map (fun p r ->
                let rec loop ers = function
                    | Nil -> Nil
                    | Cons(a : InferResult,next) ->
                        let ers = List.append a.errors ers
                        Hopac.start (Src.value errors.typer {|uri="file:///" + p; errors=ers|})
                        Cons(a, next >>-* loop ers)
                r >>-* loop []
                ) infer_results
        let s = {s with packages=packages; package_ids=package_ids; infer_results=Map.foldBack Map.add infer_results s.infer_results; diff_stream=diff_stream}
        Hopac.start (Src.value atten (s, dir))
        s
    | None, diff_stream -> {s with packages=packages; diff_stream=diff_stream}

let package_update_validate_then_send_errors atten errors s dir text = package_validate_then_send_errors atten errors (package_update errors s dir text) dir

let token_range (r_par : ParserRes) ((a,b) : VSCRange) =
    let in_range x = min r_par.lines.Length x
    vscode_tokens (in_range a.line) (in_range (b.line+1)) r_par.lines

let hover (l : InferResult PersistentVector) (pos : VSCPos) =
    l |> PersistentVector.tryFindBack (fun x -> x.offset <= pos.line)
    |> Option.bind (fun x ->
         x.hovers |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ))

let module_changed atten errors s p =
    let rec loop (p : DirectoryInfo) =
        if p = null then s
        else
            let x = Path.Combine(p.FullName,"package.spiproj")
            if File.Exists x then
                if Map.containsKey x s.packages.validated_schemas then s
                else package_update_validate_then_send_errors atten errors s p.FullName None
            else loop p.Parent
    loop (FileInfo(p).Directory)

let attention_server (req : (SupervisorState * string) Stream) =
    let pull_stream (s : SupervisorState) (dir : string) canc =
        match Map.tryFind dir s.packages.validated_schemas with
        | Some(Ok x) ->
            let rec elem = function
                | ValidatedFileHierarchy.File((_,path),_,_) ->
                    match Map.tryFind path s.infer_results with
                    | Some x ->
                        let rec loop x = (canc ^->. false) <|> (x ^=> function Cons(_,next) -> loop next | Nil -> Alt.always true)
                        loop x
                    | None ->
                        Alt.always false
                | ValidatedFileHierarchy.Directory(_,l) ->
                    list l
            and list = function
                | x :: xs ->
                    elem x ^=> function
                        | false -> Alt.always false
                        | true -> list xs
                | [] -> Alt.always true
            list x.files >>= function
                | false -> Job.result Set.empty
                | true ->
                    match Map.tryFind dir (snd s.packages.package_links) with
                    | Some x -> Job.result x
                    | _ -> Job.result Set.empty
        | _ -> Job.result Set.empty
    let res = Ch()
    let pull_stream a b c = Hopac.start (pull_stream a b c >>= Ch.send res)
    let rec loop (pulled,c) s canc =
        (canc ^->. c)
        <|> (res ^=> fun l ->
            Set.fold (fun (pulled,c) dir ->
                if Set.contains dir pulled then pulled, c
                else pull_stream s dir canc; Set.add dir pulled, c+1
                ) (pulled,c-1) l
            |> fun x -> loop x s canc
            )
    let rec empty c = if 0 < c then res >>= fun _ -> empty (c-1) else Job.unit()
    let rec main req =
        req >>= function
            | Cons(_,req) when req.Full ->
                main req
            | Cons((s,dir),req) ->
                pull_stream s dir req
                loop (Set.singleton dir,1) s req >>= fun c ->
                empty c >>= fun () ->
                main req
            | Nil ->
                Job.unit()

    main req

let supervisor_server atten (errors : SupervisorErrorSources) req =
    let loop s = req >>- function
        | ProjectFileChange x | ProjectFileOpen x ->
            let dir = dir x.uri
            package_update_validate_then_send_errors atten errors s dir (Some x.spiprojText)
        | ProjectFileDelete x ->
            let dir = dir x.uri
            let s = {s with packages={s.packages with validated_schemas=Map.add dir (Error "The package file does not exist.") s.packages.validated_schemas}}
            package_validate_then_send_errors atten errors s dir
        | ProjectFileLinks(x,res) -> 
            match Map.tryFind (dir x.uri) s.packages.package_schemas with
            | Some (Ok x) -> Hopac.start (IVar.fill res (List.append x.schema.links x.package_links))
            | _ -> Hopac.start (IVar.fill res [])
            s
        | ProjectCodeActions(x,res) ->
            match Map.tryFind (dir x.uri) s.packages.package_schemas with
            | Some (Ok x) -> Hopac.start (IVar.fill res x.schema.actions)
            | _ -> Hopac.start (IVar.fill res [])
            s
        | ProjectCodeActionExecute(x,res) ->
            match code_action_execute x.action with
            | Some er -> Hopac.start (IVar.fill res {|result=Some er|})
            | None -> Hopac.start (IVar.fill res {|result=None|})
            let dir = dir x.uri
            package_update_validate_then_send_errors atten errors s dir None
        | FileOpen x ->
            let p = file x.uri
            match Map.tryFind p s.modules with
            | Some _ -> s
            | None -> 
                let s = {s with modules = Map.add p ((module' (parser_error errors x.uri) (is_top_down p)).Run(DocumentAll(Utils.lines x.spiText))) s.modules}
                module_changed atten errors s p
        | FileChange x ->
            let p = file x.uri
            let _,m = s.modules.[p]
            let s = {s with modules = Map.add p (m.Run(DocumentEdit x.spiEdit)) s.modules}
            module_changed atten errors s p
        | FileDelete x ->
            let p = file x.uri
            let s = {s with modules = Map.remove p s.modules; infer_results = Map.remove p s.infer_results }
            module_changed atten errors s p
        | FileTokenRange(x, res) ->
            match Map.tryFind (file x.uri) s.modules with
            | Some((_,_,a),_) -> Hopac.start (a >>= fun a -> IVar.fill res (token_range a x.range))
            | None -> ()
            s
        | HoverAt(x,res) -> 
            Hopac.start (
                match Map.tryFind (file x.uri) s.infer_results with
                | Some a when a.Full -> a >>= fun a -> IVar.fill res (hover (cons_fulfilled a) x.pos)
                | _ -> IVar.fill res None
                )
            s
        | BuildFile x ->
            let p = file x.uri
            let x,s = Build.build_file s p
            Hopac.start (x >>= function
                | Build.BuildOk x -> Job.fromUnitTask (fun () -> IO.File.WriteAllTextAsync(IO.Path.ChangeExtension(p,"fsx"), x))
                | Build.BuildErrorTrace x // TODO: This should send a message to the content provider on the editor side.
                | Build.BuildFatalError x -> Src.value errors.fatal x
                )
            s

    Job.iterateServer {
        modules = Map.empty
        diff_stream = package_diff
        infer_results = Map.empty
        package_ids = PersistentHashMap.empty
        packages = {
            validated_schemas = Map.empty
            package_links = mirrored_graph_empty
            package_schemas = Map.empty
            }
        prepass_stream = Prepass.package
        } loop

type ClientReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileDelete of {|uri : string|}
    | ProjectFileLinks of {|uri : string|}
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
    | ProjectCodeActions of {|uri : string|}
    | FileOpen of {|uri : string; spiText : string|}
    | FileChange of {|uri : string; spiEdit : SpiEdit|}
    | FileDelete of {|uri : string|}
    | FileTokenRange of {|uri : string; range : VSCRange|}
    | HoverAt of {|uri : string; pos : VSCPos|}
    | BuildFile of {|uri : string|}
    | Ping of bool

type ClientErrorsRes =
    | FatalError of string
    | PackageErrors of {|uri : string; errors : RString list|}
    | TokenizerErrors of {|uri : string; errors : RString list|}
    | ParserErrors of {|uri : string; errors : RString list|}
    | TypeErrors of {|uri : string; errors : RString list|}

let port = 13805
let uri_server = sprintf "tcp://*:%i" port
let uri_client = sprintf "tcp://*:%i" (port+1)

open FSharp.Json
open NetMQ
open NetMQ.Sockets

let [<EntryPoint>] main _ =
    use poller = new NetMQPoller()
    use server = new RouterSocket()
    poller.Add(server)
    server.Options.ReceiveHighWatermark <- System.Int32.MaxValue
    server.Bind(uri_server)
    printfn "Server bound to: %s" uri_server

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
        }
    let supervisor = Ch()
    let atten = Src.create()
    Hopac.start (attention_server (Src.tap atten))
    Hopac.start (supervisor_server atten errors supervisor)

    let mutable time = DateTimeOffset.Now
    let timer = NetMQTimer(2000)
    poller.Add(timer)
    timer.EnableAndReset()
    use __ = timer.Elapsed.Subscribe(fun _ ->
        if TimeSpan.FromSeconds(2.0) < DateTimeOffset.Now - time then poller.Stop()
        )

    use __ = server.ReceiveReady.Subscribe(fun s ->
        let msg = server.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore
        let x = Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer))
        let push_back (x : obj) = 
            match x with
            | :? Option<string> as x -> 
                match x with
                | None -> msg.Push("null") 
                | Some x -> msg.Push(sprintf "\"%s\"" x)
            | _ -> msg.Push(Json.serialize x)
            msg.PushEmptyFrame(); msg.Push(address)
        let send_back x = push_back x; server.SendMultipartMessage(msg)
        let send_back_via_queue x = push_back x; queue_server.Enqueue(msg)
        let job_null job = Hopac.start job; send_back null
        let job_val job = let res = IVar() in Hopac.start (job res >>=. IVar.read res >>- send_back_via_queue)
        match x with
        | ProjectFileOpen x -> job_null (supervisor *<+ SupervisorReq.ProjectFileOpen x)
        | ProjectFileChange x -> job_null (supervisor *<+ SupervisorReq.ProjectFileChange x)
        | ProjectFileDelete x -> job_null (supervisor *<+ SupervisorReq.ProjectFileDelete x)
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

    use __ = queue_client.ReceiveReady.Subscribe(fun x -> 
        x.Queue.Dequeue() |> Json.serialize |> client.SendFrame
        )

    use __ = queue_server.ReceiveReady.Subscribe(fun x -> x.Queue.Dequeue() |> server.SendMultipartMessage)

    poller.Run()
    0