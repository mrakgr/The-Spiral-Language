module Spiral.Server

open System
open System.Collections.Generic
open FSharp.Json
open NetMQ
open NetMQ.Sockets
open Config
open Tokenize
open Blockize

type ClientReq =
    | ProjectFileOpen of {|spiprojDir : string; spiprojText : string|}
    | FileOpen of {|spiPath : string; spiText : string|}
    | FileChanged of {|spiPath : string; spiEdits : SpiEdit []|}
    | FileTokenRange of {|spiPath : string; range : VSCRange|}

type ProjectFileRes = VSCErrorOpt []
type FileOpenRes = VSCError []
type FileChangeRes = VSCError []
type FileTokenAllRes = VSCTokenArray
type FileTokenChangesRes = int * int * VSCTokenArray

let uri = "tcp://*:13805"

open Hopac
open Hopac.Infixes
open Hopac.Extensions
let server () =
    let server_blockizer = Utils.memoize (Dictionary()) (fun _ -> run Blockize.server)

    use sock = new RouterSocket()
    sock.Options.ReceiveHighWatermark <- Int32.MaxValue
    sock.Bind(uri)
    printfn "Server bound to: %s" uri

    while true do
        let msg = sock.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore

        // TODO: The message id here is for debugging purposes. I'll remove it at some point.
        let (id : int), x = Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer))
        match x with
        | ProjectFileOpen x -> 
            match config x.spiprojDir x.spiprojText with Ok x -> [||] | Error x -> x
            |> Json.serialize
        | FileOpen x ->
            (let res = IVar() in Ch.give (server_blockizer x.spiPath) (Req.Put(x.spiText,res)) >>=. IVar.read res) 
            |> run |> Json.serialize
        | FileChanged x ->
            // The multiple edits given here all point to coordinates in the original array, but tokenizer works sequentially.
            // So I am reversing them from last to first here.
            (let res = IVar() in Ch.give (server_blockizer x.spiPath) (Req.Modify(Array.rev x.spiEdits,res)) >>=. IVar.read res) 
            |> run |> Json.serialize
        | FileTokenRange x ->
            (let res = IVar() in Ch.give (server_blockizer x.spiPath) (Req.GetRange(x.range,res)) >>=. IVar.read res)
            |> run |> Json.serialize
        |> msg.Push
        msg.PushEmptyFrame()
        msg.Push(address)
        sock.SendMultipartMessage(msg)

server()

