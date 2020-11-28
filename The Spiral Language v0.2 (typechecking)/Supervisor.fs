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
open Spiral.StreamServer.Typechecking

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
    | FileChange of {|uri : string; spiEdit : SpiEdit|}
    | FileDelete of {|uri : string|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * VSCTokenArray IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar

let package_validate_then_send_errors atten errors s dir =
    let order,packages = package_validate s.packages dir
    let infer_results, diff_stream = s.diff_stream.Run(order,packages.package_schemas,packages.package_links,s.modules)
    
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

    package_errors order packages |> Array.iter (fun er ->
        Hopac.start (Src.value errors.package er)
        )
    let s = {s with packages=packages; infer_results=Map.foldBack Map.add infer_results s.infer_results; diff_stream=diff_stream}
    Hopac.start (Src.value atten (s, dir))
    s

let package_update_validate_then_send_errors atten errors s dir text = package_validate_then_send_errors atten errors (package_update errors s dir text) dir

let token_range (r_par : ParserRes) ((a,b) : VSCRange) =
    let from, near_to = min (r_par.lines.Length-1) a.line, min r_par.lines.Length (b.line+1)
    vscode_tokens from near_to r_par.lines

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
                let s = {s with modules = Map.add p ((module' (parser_error errors x.uri) (is_top_down p)).Run(DocumentAll x.spiText)) s.modules}
                module_changed atten errors s p
        | FileChange x ->
            let p = file x.uri
            let _,_,m = s.modules.[p]
            let s = {s with modules = Map.add p (m.Run(DocumentEdit x.spiEdit)) s.modules}
            module_changed atten errors s p
        | FileDelete x ->
            let p = file x.uri
            let s = {s with modules = Map.remove p s.modules; infer_results = Map.remove p s.infer_results }
            module_changed atten errors s p
        | FileTokenRange(x, res) ->
            match Map.tryFind (file x.uri) s.modules with
            | Some(_,a,_) -> Hopac.start (a >>= fun a -> IVar.fill res (token_range a x.range))
            | None -> ()
            s
        | HoverAt(x,res) -> 
            Hopac.start (
                match Map.tryFind (file x.uri) s.infer_results with
                | Some a when a.Full -> a >>= fun a -> IVar.fill res (hover (cons_fulfilled a) x.pos)
                | _ -> IVar.fill res None
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
    | FileChange of {|uri : string; spiEdit : SpiEdit|}
    | FileDelete of {|uri : string|}
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

let main _ =
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
            | FileChange x -> job_null (supervisor *<+ SupervisorReq.FileChange x)
            | FileDelete x -> job_null (supervisor *<+ SupervisorReq.FileDelete x)
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

open Spiral.PartEval
open Spiral.PartEval.Prepass

//type PrepassFileHierarchy =
//    | File of path: RString * name: string option * FilledTop list
//    | Directory of name: string * PrepassFileHierarchy list

//let prepass_compile (package_ids : PersistentHashMap<string,int>) 
//        (packages : Map<string, {|links : Map<string,{|name : string|}>; files : PrepassFileHierarchy list |}>) 
//        (package_order : string seq) =
//    Seq.fold (fun package_envs package_name ->
//        let package_id = package_ids.[package_name]
//        let package = packages.[package_name]
//        let package_env = package.links |> Map.fold (fun s k v -> in_module v.name (union s (Map.find k package_envs))) package_env_default 

//        let rec elem (top_env, module_id) = function
//            | ValidatedFileHierarchy.File((_,path),name,_) ->
//                let r = results.[path]
//                let _,top_env_adds = 
//                    List.fold (fun (top_env, top_env_adds) x ->
//                        match (prepass package_id module_id top_env).filled_top x with
//                        | AOpen adds -> Prepass.union adds top_env, top_env_adds
//                        | AInclude adds -> Prepass.union adds top_env, Prepass.union adds top_env_adds
//                        ) (top_env, top_env_empty) r
//                let top_env_adds =
//                    match name with
//                    | None -> top_env_adds
//                    | Some name -> Prepass.in_module name top_env_adds
//                (module_id+1), top_env_adds
//            | ValidatedFileHierarchy.Directory(name,l) ->
//                let _,module_id,top_env_adds = list (top_env,module_id) l
//                module_id, top_env_adds
//        and list (top_env,module_id) l =
//            List.fold (fun (top_env,module_id,top_env_adds) x ->
//                let module_id, top_env_adds' = elem (top_env, module_id) x
//                Prepass.union top_env_adds' top_env, module_id, Prepass.union top_env_adds' top_env_adds
//                ) (top_env,module_id,top_env_empty) l
                
//        let _,_,top_env_adds = list (package_to_top package_env,0) package.files
//        Map.add package_name (top_to_package package_id top_env_adds package_env) package_envs
//        ) Map.empty package_order
