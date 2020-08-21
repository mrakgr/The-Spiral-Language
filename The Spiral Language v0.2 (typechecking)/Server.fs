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
    let server_blockizer = Utils.memoize (Dictionary()) (Blockize.server >> run)
    use poller = new NetMQPoller()
    use server = new ResponseSocket()
    poller.Add(server)
    server.Options.ReceiveHighWatermark <- Int32.MaxValue
    server.Bind(uri_server)
    printfn "Server bound to: %s" uri_server

    use __ = server.ReceiveReady.Subscribe(fun s ->
        // TODO: The message id here is for debugging purposes. I'll remove it at some point.
        let (id : int), x = Json.deserialize(s.Socket.ReceiveFrameString())
        match x with
        | ProjectFileOpen x ->
            match config x.uri x.spiprojText with Ok x -> [||] | Error x -> x
            |> Json.serialize
        | FileOpen x ->
            (let res = IVar() in Ch.give (server_blockizer x.uri) (Req.Put(x.spiText,res)) >>=. IVar.read res)
            |> run |> Json.serialize
        | FileChanged x ->
            (let res = IVar() in Ch.give (server_blockizer x.uri) (Req.Modify(x.spiEdit,res)) >>=. IVar.read res)
            |> run |> Json.serialize
        | FileTokenRange x ->
            (let res = IVar() in Ch.give (server_blockizer x.uri) (Req.GetRange(x.range,res)) >>=. IVar.read res)
            |> run |> Json.serialize
        |> s.Socket.SendFrame
        )

    use client = new RequestSocket()
    client.Connect(uri_client)

    use queue = new NetMQQueue<ClientRes>()
    poller.Add(queue)
    use __ = queue.ReceiveReady.Subscribe(fun x -> 
        x.Queue.Dequeue() |> Json.serialize |> client.SendFrame
        client.ReceiveMultipartMessage() |> ignore
        )

    poller.Run()

server()

