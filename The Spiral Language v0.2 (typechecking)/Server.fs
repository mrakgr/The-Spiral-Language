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
    | ParserErrors of {|uri : string; errors : VSCError []|}
    | TypeErrors of {|uri : string; errors : VSCError list|}
    | Message of NetMQMessage // This is just for routing through the queue. It does not have the same semantics as the other ones.

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

    let file_message uri f =
        let tokenizer = tokenizer uri
        let parser = parser uri
        let typechecker = typechecker uri
        let hover,_ = hover uri

        let res = IVar() 
        Ch.give tokenizer (f res) 
        >>=. IVar.read res >>- fun (blocks,tokenizer_errors) ->
        Hopac.start (
            let req_tc = IVar()
            Ch.give typechecker req_tc >>=.
            Ch.give hover req_tc >>=.

            let res = IVar()
            Ch.give parser (blocks, res) >>=. 
            IVar.read res >>= fun (bundle,parser_errors) -> 
            queue.Enqueue(ParserErrors {|errors=parser_errors; uri=uri|})

            let res = IVar()
            IVar.fill req_tc (bundle, res) >>=.
            IVar.read res >>= fun x ->
            x |> Seq.foldJob (fun s x ->
                IVar.read x >>- fun ((_,typechecking_errors),_) ->
                let s = List.append typechecking_errors s
                queue.Enqueue(TypeErrors {|errors=s; uri=uri|})
                s
                ) []
            >>-. ()
            )
        tokenizer_errors

    use __ = server.ReceiveReady.Subscribe(fun s ->
        let msg = server.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore
        let push_back x = msg.Push(Json.serialize x); msg.PushEmptyFrame(); msg.Push(address)
        let send_back' x = push_back x; server.SendMultipartMessage(msg)
        let send_back_via_queue x = push_back x; queue.Enqueue(Message msg)
        let send_back x = run x |> send_back'
        // TODO: The message id here is for debugging purposes. I'll remove it at some point.
        let (id : int), x = Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer))
        match x with
        | ProjectFileOpen x ->
            match config x.uri x.spiprojText with Ok x -> [||] | Error x -> x
            |> send_back'
        | FileOpen x -> file_message x.uri (fun res -> Req.Put(x.spiText,res)) |> send_back
        | FileChanged x -> file_message x.uri (fun res -> Req.Modify(x.spiEdit,res)) |> send_back
        | FileTokenRange x ->
            Hopac.start (
                let res = IVar()
                timeOutMillis 30 >>=.
                Ch.give (tokenizer x.uri) (Req.GetRange(x.range,res)) >>=. 
                IVar.read res >>- send_back_via_queue
                )
        | HoverAt x ->
            let _,hover = hover x.uri
            Hopac.start (Ch.give hover (x.pos, fun x -> send_back' {|HoverReply=x|}))
        )

    use client = new RequestSocket()
    client.Connect(uri_client)

    use __ = queue.ReceiveReady.Subscribe(fun x -> 
        match x.Queue.Dequeue() with
        | Message msg -> server.SendMultipartMessage(msg)
        | x -> 
            x |> Json.serialize |> client.SendFrame
            client.ReceiveMultipartMessage() |> ignore
        )

    poller.Run()

server()

