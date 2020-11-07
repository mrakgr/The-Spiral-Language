module Spiral.Server

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.Tokenize
open Spiral.TypecheckingUtils
open Spiral.Blockize
open Spiral.SpiProj

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type TokReq =
    | Put of string
    | Modify of SpiEdit
    | GetRange of VSCRange * (VSCTokenArray -> unit)
type TokRes = {blocks : Block list; errors : RString []}
type ParserRes = {bundles : Bundle list; parser_errors : RString []; tokenizer_errors : RString []}

let tokenizer req =
    let lines : LineToken [] ResizeArray = ResizeArray([[||]])
    let mutable errors_tokenization = [||]
    let mutable blocks : Block list = []

    let res_text = Src.create()
    let replace edit =
        errors_tokenization <- Tokenize.replace lines errors_tokenization edit // Mutates the lines array
        blocks <- block_separate lines blocks edit
        Src.value res_text {blocks=blocks; errors=errors_tokenization}

    req |> Stream.consumeJob (function 
        | Put text -> replace {|from=0; nearTo=lines.Count; lines=Utils.lines text|}
        | Modify edit -> replace edit
        | GetRange((a,b),res) ->
            let from, near_to = min (lines.Count-1) a.line, min lines.Count (b.line+1)
            vscode_tokens from (lines.GetRange(from,near_to-from |> max 0).ToArray()) |> res
            Job.unit()
        )
    Src.tap res_text

let parse dict is_top_down (a : TokRes) =
    let b = 
        List.map (fun x -> {
            parsed = Utils.memoize dict (block_init is_top_down) x.block
            offset = x.offset
            }) a.blocks
    dict.Clear(); List.iter2 (fun a b -> dict.Add(a.block,b.parsed)) a.blocks b
    let bundles, parser_errors = block_bundle b
    {bundles = bundles; parser_errors = parser_errors; tokenizer_errors = a.errors}

let parser' is_top_down tokens =
    let tokens = Stream.values tokens
    let req = Ch()

    let dict = Dictionary(HashIdentity.Reference)
    let src = Src.create()

    let rec init () = waiting <|> (Ch.give req (Src.tap src) ^=> init)
    and rest p = waiting <|> (Ch.give req (Stream.cons p (Src.tap src)) ^=> fun () -> rest p)
    and parsing x = waiting <|> Alt.prepareJob (fun () -> let p = parse dict is_top_down x in Src.value src p >>-. rest p)
    and waiting = tokens ^=> parsing

    Hopac.start (init ())
    req

//let parser is_top_down tokens = Ch.take (parser' is_top_down tokens) |> Hopac.run
let parser is_top_down tokens = tokens |> Stream.keepPreceding1 |> Stream.mapFun (parse (Dictionary(HashIdentity.Reference)) is_top_down)

type TypecheckerRes = (Bundle * Infer.InferResult * Infer.TopEnv) PersistentVector * bool
let typechecker package_id module_id (req : ParserRes Stream) : TypecheckerRes Stream =
    let req = Stream.values req
    let res = Src.create()
    let r = Src.tap res
    let rec waiting a = req ^=> fun b ->
        let rec loop s i b = 
            match PersistentVector.tryNth i a, b with
            | Some(bundle,_,_ as r), bundle' :: b' when bundle = bundle' -> loop (PersistentVector.conj r s) (i+1) b'
            | _ -> s, b
        loop PersistentVector.empty 0 b.bundles |> processing
    and processing = function
        | a, [] -> Alt.prepare (Src.value res (a,true) >>- fun () -> waiting a)
        | a, b :: b' -> waiting a <|> Alt.prepare (Src.value res (a, false) >>- fun () ->
            let env =
                match PersistentVector.tryLast a with
                | Some(_,_,env) -> env
                | None -> Infer.top_env_default
            let r = Infer.infer package_id module_id env (bundle_top b)
            let a' = PersistentVector.conj (b,r,Infer.union r.top_env_additions env) a
            processing (a', b')
            )
    Hopac.server (waiting PersistentVector.empty)
    r

let hover (req : (VSCPos * (string option -> unit)) Stream) (req_tc : TypecheckerRes Stream) =
    let req, req_tc = Stream.values req, Stream.values req_tc
    let rec processing ((x,_ as r) : TypecheckerRes) = waiting <|> (req ^=> fun (pos,ret) ->
        let rec block_from i = 
            if 0 <= i then 
                let a,b,_ = x.[i]
                if (List.head a).offset <= pos.line then b.hovers else block_from (i-1)
            else [||]
        block_from (x.Length-1) |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ) |> ret
        processing r
        )
    and waiting = req_tc ^=> processing
    Hopac.server waiting

open Spiral.ServerUtils

type PackageSupervisorReq =
    | SOpen of dir: string * text: string option
    | SChange of dir: string * text: string option
    | SLinks of dir: string * RString [] IVar
    | SCodeActions of dir: string * RAction [] IVar
    | SCodeActionExecute of ProjectCodeAction

let supervisor fatal_errors errors =
    let req = Src.create()
    let m = ref {schemas=Map.empty; links=mirrored_graph_empty; loads=Map.empty}
    let change is_open dir text = change is_open !m dir text >>= fun (ers,m') -> m := m'; Array.iterJob (Src.value errors) ers

    Src.tap req |> consumeJob (function
        | SOpen(dir,text) -> change true dir text
        | SChange(dir,text) -> change false dir text
        | SLinks(dir,res) -> 
            match m.contents.schemas.[dir] with
            | Ok x -> IVar.fill res (Array.append x.schema.links x.package_links)
            | Error _ -> IVar.fill res [||]
        | SCodeActions(dir,res) ->
            match m.contents.schemas.[dir] with
            | Ok x -> IVar.fill res x.schema.actions
            | Error _ -> IVar.fill res [||]
        | SCodeActionExecute a -> 
            match code_action_execute a with
            | Some er -> Src.value fatal_errors er
            | None -> Job.unit()
        )

    req

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
    | PackageErrors of {|uri : string; errors : RString []|}
    | TokenizerErrors of {|uri : string; errors : RString []|}
    | ParserErrors of {|uri : string; errors : RString []|}
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

    let file = Utils.memoize (Dictionary()) <| fun (uri : string) ->
        let s = {|token = Src.create(); hover = Src.create()|}
        let token = tokenizer (Src.tap s.token)
        let parse = parser (System.IO.Path.GetExtension(uri) = ".spi") token
        let ty = typechecker 0 0 parse
        hover (Src.tap s.hover) ty

        token |> Stream.consumeFun (fun x -> queue_client.Enqueue(TokenizerErrors {|uri=uri; errors=x.errors|}))
        parse |> Stream.consumeFun (fun x -> queue_client.Enqueue(ParserErrors {|uri=uri; errors=x.parser_errors|}))
        ty |> Stream.consumeFun (fun (x,_) -> 
            let errors = PersistentVector.foldBack (fun (_,x : Infer.InferResult,_) errors -> List.append errors x.errors) x []
            queue_client.Enqueue(TypeErrors {|errors=errors; uri=uri|})
            )
        s

    let fatal_errors = Src.create()
    Src.tap fatal_errors |> Stream.consumeFun (FatalError >> queue_client.Enqueue)
    let package_errors = Src.create()
    Src.tap package_errors |> Stream.consumeFun (PackageErrors >> queue_client.Enqueue)
    let supervisor = supervisor fatal_errors package_errors
    let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName

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
            let send_ivar_back_via_queue () = let res = IVar() in Hopac.start (IVar.read res >>- send_back_via_queue); res

            match x with
            | ProjectFileOpen x -> Src.value supervisor (SOpen(dir x.uri, Some x.spiprojText)) |> Hopac.start; send_back null
            | ProjectFileChange x -> Src.value supervisor (SChange(dir x.uri, Some x.spiprojText)) |> Hopac.start; send_back null
            | ProjectFileDelete x -> Src.value supervisor (SChange(dir x.uri, None)) |> Hopac.start; send_back null
            | ProjectFileLinks x -> Src.value supervisor (SLinks(dir x.uri, send_ivar_back_via_queue())) |> Hopac.start
            | ProjectCodeActionExecute x -> Src.value supervisor (SCodeActionExecute x.action) |> Hopac.start; send_back null
            | ProjectCodeActions x -> Src.value supervisor (SCodeActions(dir x.uri, send_ivar_back_via_queue())) |> Hopac.start
            | FileOpen x -> Src.value (file x.uri).token (TokReq.Put(x.spiText)) |> Hopac.start; send_back null
            | FileChanged x -> Src.value (file x.uri).token (TokReq.Modify(x.spiEdit)) |> Hopac.start; send_back null
            | FileTokenRange x -> Hopac.start (timeOutMillis 30 >>=. Src.value (file x.uri).token (TokReq.GetRange(x.range,send_back_via_queue)))
            | HoverAt x -> Hopac.start (Src.value (file x.uri).hover (x.pos, send_back_via_queue))
            | BuildFile x ->
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