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
    modules : Map<string, TokRes * ParserRes Promise * ModuleStream>
    infer_results : Map<string, InferResult Stream>
    diff_stream : PackageDiffStream
    packages : PackageMaps
    }
type LoadResult =
    | LoadModule of package_dir: string * path: RString * Result<TokRes * ParserRes Promise * ModuleStream,string>
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
                                let (tok_res,_,_ as x) = (module' (parser_error errors uri) (is_top_down path)).Run(DocumentAll x.Result)
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
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * VSCTokenArray IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar

let package_validate_then_send_errors errors s dir =
    let order,packages = package_validate s.packages dir
    let infer_results, diff_stream = s.diff_stream.Run(order,packages.package_schemas,packages.package_links,s.modules)
    
    Map.iter (fun p r ->
        Hopac.start (
            let rec loop ers = function
                | Nil -> Job.unit ()
                | Cons(a : InferResult,next) ->
                    let ers = List.append a.errors ers
                    Src.value errors.typer {|uri="file:///" + p; errors=ers|} >>=. 
                    next >>= loop ers
            r >>= loop []
            )
        ) infer_results

    package_errors order packages |> Array.iter (fun er ->
        Hopac.start (Src.value errors.package er)
        )
    {s with packages=packages; infer_results=Map.foldBack Map.add infer_results s.infer_results; diff_stream=diff_stream}

let package_update_validate_then_send_errors errors s dir text = package_validate_then_send_errors errors (package_update errors s dir text) dir

let token_range (r_par : ParserRes) ((a,b) : VSCRange) =
    let from, near_to = min (r_par.lines.Length-1) a.line, min r_par.lines.Length (b.line+1)
    vscode_tokens from near_to r_par.lines

let hover (l : InferResult PersistentVector) (pos : VSCPos) =
    l |> PersistentVector.tryFindBack (fun x -> x.offset <= pos.line)
    |> Option.bind (fun x ->
         x.hovers |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ))

let module_changed errors s p =
    let rec loop (p : DirectoryInfo) =
        if p = null then s
        else
            let x = Path.Combine(p.FullName,"package.spiProj")
            if File.Exists x then
                if Map.containsKey x s.packages.validated_schemas then s
                else package_update_validate_then_send_errors errors s p.FullName None
            else loop p.Parent
    loop (FileInfo(p).Directory)

let supervisor_server (errors : SupervisorErrorSources) req =
    let loop s = req >>- function
        | ProjectFileChange x | ProjectFileOpen x ->
            let dir = dir x.uri
            package_update_validate_then_send_errors errors s dir (Some x.spiprojText)
        | ProjectFileDelete x ->
            let dir = dir x.uri
            let s = {s with packages={s.packages with validated_schemas=Map.add dir (Error "The package file does not exist.") s.packages.validated_schemas}}
            package_validate_then_send_errors errors s dir
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
            package_update_validate_then_send_errors errors s dir None
        | FileOpen x ->
            let p = file x.uri
            match Map.tryFind p s.modules with
            | Some _ -> s
            | None -> 
                let s = {s with modules = Map.add p ((module' (parser_error errors x.uri) (is_top_down p)).Run(DocumentAll x.spiText)) s.modules}
                module_changed errors s p
        | FileChanged x ->
            let p = file x.uri
            let _,_,m = s.modules.[p]
            let s = {s with modules = Map.add p (m.Run(DocumentEdit x.spiEdit)) s.modules}
            module_changed errors s p
        | FileTokenRange(x, res) ->
            match Map.tryFind (file x.uri) s.modules with
            | Some(_,a,_) -> Hopac.start (a >>= fun a -> IVar.fill res (token_range a x.range))
            | None -> ()
            s
        | HoverAt(x,res) -> 
            Hopac.start (
                match Map.tryFind (file x.uri) s.infer_results with
                | Some a -> a >>= fun a -> IVar.fill res (hover (cons_fulfilled a) x.pos)
                | None -> IVar.fill res None
                )
            s
    Job.iterateServer {
        modules = Map.empty
        diff_stream = package_diff
        infer_results = Map.empty
        packages = {
            validated_schemas = Map.empty
            package_links = mirrored_graph_empty
            package_schemas = Map.empty
            }
        } loop

type ClientReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileDelete of {|uri : string|}
    | ProjectFileLinks of {|uri : string|}
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
    | ProjectCodeActions of {|uri : string|}
    | FileOpen of {|uri : string; spiText : string|}
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    | FileTokenRange of {|uri : string; range : VSCRange|}
    | HoverAt of {|uri : string; pos : VSCPos|}
    | BuildFile of {|uri : string|}

type ClientErrorsRes =
    | FatalError of string
    | PackageErrors of {|uri : string; errors : RString list|}
    | TokenizerErrors of {|uri : string; errors : RString list|}
    | ParserErrors of {|uri : string; errors : RString list|}
    | TypeErrors of {|uri : string; errors : RString list|}

let port = 13805
let uri_server = sprintf "tcp://*:%i" port
let uri_client = sprintf "tcp://localhost:%i" (port+1)

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
    Hopac.start (supervisor_server errors supervisor)

    let buffer = Dictionary()
    let last_id = ref 0
    use __ = server.ReceiveReady.Subscribe(fun s ->
        let rec loop () = Utils.remove buffer !last_id (body(NetMQMessage 3)) id
        and body (msg : NetMQMessage) (address : NetMQFrame, x) =
            incr last_id
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
            | FileChanged x -> job_null (supervisor *<+ SupervisorReq.FileChanged x)
            | FileTokenRange x -> job_val (fun res -> supervisor *<+ SupervisorReq.FileTokenRange(x,res))
            | HoverAt x -> job_val (fun res -> supervisor *<+ SupervisorReq.HoverAt(x,res))
            | BuildFile x -> // TODO: This case is just a stump for now.
                let x = Uri(x.uri).LocalPath
                match IO.Path.GetExtension(x) with
                | ".spi" | ".spir" -> IO.File.WriteAllText(IO.Path.ChangeExtension(x,"fsx"), "// Compiled with Spiral v0.2.")
                | _ -> ()
                send_back null
            loop ()
        let msg = server.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore
        let (id : int), x = Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer))
        if !last_id = id then body msg (address, x)
        else buffer.Add(id,(address,x))
        )

    use client = new RequestSocket()
    client.Connect(uri_client)

    use __ = queue_client.ReceiveReady.Subscribe(fun x -> 
        x.Queue.Dequeue() |> Json.serialize |> client.SendFrame
        client.ReceiveMultipartMessage() |> ignore
        )

    use __ = queue_server.ReceiveReady.Subscribe(fun x -> x.Queue.Dequeue() |> server.SendMultipartMessage)

    poller.Run()
    0