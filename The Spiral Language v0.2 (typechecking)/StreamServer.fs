module Spiral.StreamServer

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.Tokenize
open Spiral.TypecheckingUtils
open Spiral.Blockize
open Spiral.SpiProj
open Spiral.ServerUtils

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type TokReq =
    | DocumentAll of string
    | DocumentEdit of SpiEdit
type TokRes = {blocks : Block list; errors : RString list}

let job_thunk_with f x = Job.thunk (fun () -> f x)
let promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let promise_thunk f = Hopac.memo (Job.thunk f)

type TokenizerStream = abstract member Run: TokReq -> TokRes * TokenizerStream

let tokenizer =
    let rec loop (lines, errors, blocks) = {new TokenizerStream with
        member t.Run req =
            let replace edit =
                let lines, errors = Tokenize.replace lines errors edit
                let blocks = block_separate lines blocks edit
                lines, errors, blocks

            let next (_,errors,blocks as x) = {blocks=blocks; errors=errors}, loop x
            match req with
            | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=Utils.lines text|} |> next
            | DocumentEdit edit -> replace edit |> next
            }
    loop (PersistentVector.singleton PersistentVector.empty,[],[])

let parse is_top_down (s : (LineTokens * ParsedBlock) list) (x : Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    List.iter (fun (a,b) -> dict.Add(a,b.parsed)) s
    List.map (fun x -> x.block, {
        parsed = Utils.memoize dict (block_init is_top_down) x.block
        offset = x.offset
        }) x

type ParserRes = {lines : LineTokens; bundles : Bundle list; parser_errors : RString list; tokenizer_errors : RString list}
type ParserStream = abstract member Run : TokRes -> ParserRes Promise * ParserStream
let parser is_top_down =
    let run s req =
        let s = promise_thunk <| fun () -> parse is_top_down s req.blocks
        let a = s >>-* fun s ->
            let lines, bundles, parser_errors = block_bundle s
            {lines = lines; bundles = bundles; parser_errors = parser_errors; tokenizer_errors = req.errors}
        a, s
    let rec loop s =
        {new ParserStream with
            member t.Run(req) =
                let s = s()
                let a,s' = run s req
                a, loop (fun () -> if Promise.Now.isFulfilled s' then Promise.Now.get s' else s)
                }
    loop (fun () -> [])

let cons_fulfilled l = 
    let rec loop olds = function
        | Cons(old,next) when Promise.Now.isFulfilled next -> loop (PersistentVector.conj old olds) (Promise.Now.get next)
        | _ -> olds
    loop PersistentVector.empty l
type TypecheckerStream = abstract member Run : ParserRes Promise -> Infer.InferResult Stream * TypecheckerStream
let typechecker package_id module_id top_env =
    let rec run old_results env i (bs : Bundle list) = 
        match bs with
        | b :: bs ->
            match PersistentVector.tryNth i old_results with
            | Some (b', _, env as s) when b = b' -> Cons(s,Promise(run old_results env (i+1) bs))
            | _ ->
                let x = Infer.infer package_id module_id env (bundle_top b)
                let _,_,env as s = b,x,Infer.union x.top_env_additions env
                Cons(s,promise_thunk (fun () -> run old_results env (i+1) bs))
        | [] -> Nil
    let rec loop old_results =
        {new TypecheckerStream with
            member _.Run(res) =
                let r = 
                    res >>=* fun res ->
                    // Doing the memoization like this has the disadvantage of always focing the evaluation of the previous 
                    // streams' first item, but on the plus side will reuse old state.
                    old_results >>- fun old_results ->
                    run (cons_fulfilled old_results) top_env 0 res.bundles
                let a = Stream.mapFun (fun (_,x,_) -> x) r
                a, loop r
            }
    loop Stream.nil

type FileState = {
    tokenizer : TokenizerStream
    parser : ParserStream
    typechecker : TypecheckerStream
    cancellation_start : unit IVar
    cancellation_done : unit Promise
    }

let token_range (r_par : ParserRes) ((a,b) : VSCRange) =
    let from, near_to = min (r_par.lines.Length-1) a.line, min r_par.lines.Length (b.line+1)
    vscode_tokens from near_to r_par.lines

let handle_token_range r_par canc req =
    r_par >>= fun (r_par : ParserRes) ->
    let rec loop () =
        if IVar.Now.isFull canc then Job.unit() 
        else req >>= fun (r,res) -> IVar.fill res (token_range r_par r) >>= loop
    loop()

let hover (l : Infer.InferResult PersistentVector) (pos : VSCPos) =
    l |> PersistentVector.tryFindBack (fun x ->
        let start = if 0 < x.hovers.Length then (x.hovers.[0] |> fst |> fst).line else Int32.MaxValue
        start <= pos.line
        )
    |> Option.bind (fun x ->
         x.hovers |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ))

let handle_hover_at r_typ canc req =
    r_typ >>= fun r_typ ->
    let rec loop () =
        if IVar.Now.isFull canc then Job.unit()
        else req >>= fun (pos,res) -> IVar.fill res (hover (cons_fulfilled r_typ) pos) >>= loop // TODO: It might be better if the hover handler tugged on the stream rather than just sampling it like now.
    loop ()

let handle_typ uri type_errors r_typ canc =
    let rec loop ers = function
        | Nil -> Job.unit()
        | Cons(a : Infer.InferResult,next) ->
            if IVar.Now.isFull canc then Job.unit()
            else 
                let errors = List.append a.errors ers
                Src.value type_errors {|uri=uri; errors=errors|} >>=.
                next >>= loop errors
    r_typ >>= loop []

let file_server tokenizer_errors parser_errors type_errors (uri : string) req req_token_range req_hover_at =
    let cancel (s : FileState) = IVar.fill s.cancellation_start () >>=. s.cancellation_done
    let loop s =
        req >>= fun x ->
        let rec try_more x = Ch.Try.take req >>= function
            | Some x -> try_more (s.tokenizer.Run(x))
            | None -> Job.result x
        try_more (s.tokenizer.Run(x)) >>= fun (r_tok,tok) ->
        cancel s >>= fun () ->
        let r_par,par = s.parser.Run(r_tok)
        let r_typ,typ = s.typechecker.Run(r_par)
        let canc = IVar()
        Promise.start (Job.conIgnore [ 
            Src.value tokenizer_errors {|uri=uri; errors=r_tok.errors|}
            r_par >>= fun r_par -> Src.value parser_errors {|uri=uri; errors=r_par.parser_errors|}
            handle_token_range r_par canc req_token_range
            handle_typ uri type_errors r_typ canc
            handle_hover_at r_typ canc req_hover_at
            ]) >>- fun canc_done ->
        { tokenizer=tok; parser=par; typechecker=typ; cancellation_start=canc; cancellation_done=canc_done }
    Job.iterateServer {
        tokenizer=tokenizer
        parser=parser (System.IO.Path.GetExtension(uri) = ".spi")
        typechecker=typechecker 0 0 Infer.top_env_default
        cancellation_start=IVar()
        cancellation_done=Promise(())
        } loop
    
type AllFileReq =
    | FileOpen of {|uri : string; spiText : string|}
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * VSCTokenArray IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar

let all_file_server tokenizer_errors parser_errors type_errors req =
    let dict = Dictionary()
    let file_server' uri =
        match dict.TryGetValue(uri) with
        | true, v -> false, v
        | false, _ ->
            let x = {|req=Ch(); req_token_range=Ch(); req_hover_at=Ch()|}
            Hopac.start (file_server tokenizer_errors parser_errors type_errors uri x.req x.req_token_range x.req_hover_at)
            dict.[uri] <- x
            true, x
    let file_server uri = file_server' uri |> snd
    let loop = req >>= function
        | FileOpen x ->
            let is_new, s = file_server' x.uri
            if is_new then s.req *<+ DocumentAll(x.spiText)
            else Job.unit()
        | FileChanged x ->
            let s = file_server x.uri
            s.req *<+ DocumentEdit(x.spiEdit)
        | FileTokenRange(x, res) ->
            let s = file_server x.uri
            s.req_token_range *<+ (x.range, res)
        | HoverAt(x,res) -> 
            let s = file_server x.uri
            s.req_hover_at *<+ (x.pos, res)
    Job.forever loop

type PackageSupervisorReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileDelete of {|uri : string|}
    | ProjectFileLinks of {|uri : string|} * RString list IVar
    | ProjectCodeActions of {|uri : string|} * RAction list IVar
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let supervisor_server fatal_errors package_errors req =
    let m = ref {schemas=Map.empty; links=mirrored_graph_empty; loads=Map.empty}
    let change is_open dir text = change is_open !m dir text >>= fun (ers,m') -> m := m'; Array.iterJob (Src.value package_errors) ers

    let loop = req >>= function
        | ProjectFileOpen x -> change true (dir x.uri) (Some x.spiprojText)
        | ProjectFileChange x -> change false (dir x.uri) (Some x.spiprojText)
        | ProjectFileDelete x -> change false (dir x.uri) None
        | ProjectFileLinks(x,res) -> 
            match m.contents.schemas.[dir x.uri] with
            | Ok x -> IVar.fill res (List.append x.schema.links x.package_links)
            | Error _ -> IVar.fill res []
        | ProjectCodeActions(x,res) ->
            match m.contents.schemas.[dir x.uri] with
            | Ok x -> IVar.fill res x.schema.actions
            | Error _ -> IVar.fill res []
        | ProjectCodeActionExecute x -> 
            match code_action_execute x.action with
            | Some er -> Src.value fatal_errors er
            | None -> Job.unit()

    Job.foreverServer loop
       
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
    let fatal_errors = consumed_source FatalError
    let package_errors = consumed_source PackageErrors
    let tokenizer_errors = consumed_source TokenizerErrors
    let parser_errors = consumed_source ParserErrors
    let type_errors = consumed_source TypeErrors
    let file = Ch()
    Hopac.start (all_file_server tokenizer_errors parser_errors type_errors file)
    let supervisor = Ch()
    Hopac.start (supervisor_server fatal_errors package_errors supervisor)

    let buffer = Dictionary()
    let last_id = ref 0
    use __ = server.ReceiveReady.Subscribe(fun s ->
        let rec loop () = Utils.remove buffer !last_id (body <| NetMQMessage 3) id
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
            | ProjectFileOpen x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectFileOpen x)
            | ProjectFileChange x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectFileChange x)
            | ProjectFileDelete x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectFileDelete x)
            | ProjectCodeActionExecute x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectCodeActionExecute x)
            | ProjectFileLinks x -> job_val (fun res -> supervisor *<+ PackageSupervisorReq.ProjectFileLinks(x,res))
            | ProjectCodeActions x -> job_val (fun res -> supervisor *<+ PackageSupervisorReq.ProjectCodeActions(x,res))
            | FileOpen x -> job_null (file *<+ AllFileReq.FileOpen x)
            | FileChanged x -> job_null (file *<+ AllFileReq.FileChanged x)
            | FileTokenRange x -> job_val (fun res -> file *<+ AllFileReq.FileTokenRange(x,res))
            | HoverAt x -> job_val (fun res -> file *<+ AllFileReq.HoverAt(x,res))
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