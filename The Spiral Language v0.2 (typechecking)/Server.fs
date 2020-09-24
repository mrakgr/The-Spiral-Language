module Spiral.Server

open System
open System.Collections.Generic
open FSharp.Json
open NetMQ
open NetMQ.Sockets
open Spiral.Config
open Spiral.Tokenize
open Spiral.Blockize

type ClientReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | FileOpen of {|uri : string; spiText : string|}
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    | FileTokenRange of {|uri : string; range : VSCRange|}
    | HoverAt of {|uri : string; pos : VSCPos|}

type ProjectFileRes = VSCErrorOpt []
type FileOpenRes = VSCError []
type FileChangeRes = VSCError []
type FileTokenAllRes = VSCTokenArray
type FileTokenChangesRes = int * int * VSCTokenArray

type ClientRes =
    | ProjectErrors of {|uri : string; errors : VSCErrorOpt []|}
    | TokenizerErrors of {|uri : string; errors : VSCError []|}
    | ParserErrors of {|uri : string; errors : VSCError []|}
    | TypeErrors of {|uri : string; errors : VSCError list|}

let port = 13805
let uri_server = sprintf "tcp://*:%i" port
let uri_client = sprintf "tcp://localhost:%i" (port+1)

open Hopac
open Hopac.Infixes
open Hopac.Extensions
let server () =
    let tokenizer = Utils.memoize (Dictionary()) (Blockize.server_tokenizer >> run)
    let parser = Utils.memoize (Dictionary()) (Blockize.server_parser >> run)
    let typechecker = Utils.memoize (Dictionary()) (Blockize.server_typechecking >> run)
    let hover = Utils.memoize (Dictionary()) (Blockize.server_hover >> run)
    use poller = new NetMQPoller()
    use server = new RouterSocket()
    poller.Add(server)
    server.Options.ReceiveHighWatermark <- Int32.MaxValue
    server.Bind(uri_server)
    printfn "Server bound to: %s" uri_server

    use queue = new NetMQQueue<ClientRes>()
    poller.Add(queue)

    use queue_server = new NetMQQueue<NetMQMessage>()
    poller.Add(queue_server)

    let file_message uri f =
        let tokenizer = tokenizer uri
        let parser = parser uri
        let typechecker = typechecker uri
        let hover,_ = hover uri

        Hopac.start (
            let res = IVar() 
            Ch.give tokenizer (f res) >>=. 
            IVar.read res >>= fun (blocks,tokenizer_errors) ->
            queue.Enqueue(TokenizerErrors {|uri=uri; errors=tokenizer_errors|})

            let req_tc = IVar()
            Ch.give typechecker req_tc >>=.
            Ch.give hover req_tc >>=.

            let res = IVar()
            Ch.give parser {blocks=blocks; res=res} >>=. 
            IVar.read res >>= fun parser ->
            queue.Enqueue(ParserErrors {|errors=parser.errors; uri=uri|})

            let res = IVar()
            IVar.fill req_tc {bundles=parser.bundles; res=res} >>=.
            IVar.read res >>= fun tc ->
            tc |> Seq.foldJob (fun errors tc ->
                IVar.read tc >>- fun tc ->
                let errors = List.append tc.errors errors
                queue.Enqueue(TypeErrors {|errors=errors; uri=uri|})
                errors
                ) [] >>- ignore
            )

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
            match x with
            | ProjectFileOpen x ->
                Job.thunk (fun () ->
                    match config x.uri x.spiprojText with Ok x -> [||] | Error x -> x
                    |> fun errors -> queue.Enqueue(ProjectErrors {|uri=x.uri; errors=errors|})
                    ) |> Hopac.start
                send_back None
            | FileOpen x -> file_message x.uri (fun res -> Req.Put(x.spiText,res)); send_back None
            | FileChanged x -> file_message x.uri (fun res -> Req.Modify(x.spiEdit,res)); send_back None
            | FileTokenRange x ->
                Hopac.start (
                    let res = IVar()
                    timeOutMillis 30 >>=.
                    Ch.give (tokenizer x.uri) (Req.GetRange(x.range,res)) >>=. 
                    IVar.read res >>- send_back_via_queue
                    )
            | HoverAt x ->
                let _,hover = hover x.uri
                Hopac.start (Ch.give hover (x.pos, send_back_via_queue))
            loop ()
        let msg = server.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore
        let (id : int), x = Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer))
        if !last_id = id then body msg (address, x)
        // TODO: Is enforcing order really needed.
        else failwith "message out of order" //buffer.Add(id,(address,x))
        )

    use client = new RequestSocket()
    client.Connect(uri_client)

    use __ = queue.ReceiveReady.Subscribe(fun x -> 
        x.Queue.Dequeue() |> Json.serialize |> client.SendFrame
        client.ReceiveMultipartMessage() |> ignore
        )

    use __ = queue_server.ReceiveReady.Subscribe(fun x -> x.Queue.Dequeue() |> server.SendMultipartMessage)

    poller.Run()

server()