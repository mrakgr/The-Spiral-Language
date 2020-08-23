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

type ProjectFileRes = VSCErrorOpt []
type FileOpenRes = VSCError []
type FileChangeRes = VSCError []
type FileTokenAllRes = VSCTokenArray
type FileTokenChangesRes = int * int * VSCTokenArray

type ClientRes =
    | ParserErrors of {|uri : string; errors : VSCError []|}
    | Qwe

let port = 13805
let uri_server = sprintf "tcp://*:%i" port
let uri_client = sprintf "tcp://localhost:%i" (port+1)

open Hopac
open Hopac.Infixes
open Hopac.Extensions
let server () =
    let tokenizer = Utils.memoize (Dictionary()) (Blockize.server_tokenizer >> run)
    let parser = Utils.memoize (Dictionary()) (Blockize.server_parser >> run)
    use poller = new NetMQPoller()
    use server = new RouterSocket()
    poller.Add(server)
    server.Options.ReceiveHighWatermark <- Int32.MaxValue
    server.Bind(uri_server)
    printfn "Server bound to: %s" uri_server

    use queue = new NetMQQueue<ClientRes>()
    poller.Add(queue)

    let inline file_message uri f =
        let tokenizer = tokenizer uri
        let parser = parser uri
        let res = IVar() 
        Ch.give tokenizer (f res) >>=. IVar.read res
        >>- fun (a,b) ->
            Hopac.start (
                let res = IVar()
                Ch.give parser (a, res) >>=. IVar.read res 
                >>- fun (bundle,errors) -> queue.Enqueue(ParserErrors {|errors=errors; uri=uri|})
                )
            b

    use __ = server.ReceiveReady.Subscribe(fun s ->
        let msg = server.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore
        let send_back' x =
            msg.Push(Json.serialize x); msg.PushEmptyFrame(); msg.Push(address)
            server.SendMultipartMessage(msg)
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
            (let res = IVar() in Ch.give (tokenizer x.uri) (Req.GetRange(x.range,res)) >>=. IVar.read res)
            |> send_back
        )

    use client = new RequestSocket()
    client.Connect(uri_client)

    use __ = queue.ReceiveReady.Subscribe(fun x -> 
        x.Queue.Dequeue() |> Json.serialize |> client.SendFrame
        client.ReceiveMultipartMessage() |> ignore
        )

    poller.Run()

server()

