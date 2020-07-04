module Spiral.Server

open System
open System.Collections.Generic
open FSharp.Json
open NetMQ
open NetMQ.Sockets
open Spiral.Config
open Spiral.Tokenize

type ClientReq =
    | ProjectFileOpen of {|spiprojDir : string; spiprojText : string|}
    | FileOpen of {|spiPath : string; spiText : string|}
    | FileChanged of {|spiPath : string; spiEdits : SpiEdit []|}
    | FileTokenAll of {|spiPath : string|}
    | FileTokenChanges of {|spiPath : string|}

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
    let server_tokenizer = Utils.memoize (Dictionary()) (fun _ -> run Tokenize.server)

    use sock = new RouterSocket()
    sock.Options.ReceiveHighWatermark <- Int32.MaxValue
    sock.Bind(uri)
    printfn "Server bound to: %s" uri

    while true do
        let msg = sock.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore

        match Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer)) with
        | ProjectFileOpen x -> 
            match config x.spiprojDir x.spiprojText with Ok x -> [||] | Error x -> x
            |> Json.serialize
        | FileOpen x ->
            let server = server_tokenizer x.spiPath
            let res = IVar()
            (Ch.give server (TokReq.Put(x.spiText,res)) >>=. IVar.read res)
            |> run
            |> Json.serialize
        | FileChanged x ->
            let server = server_tokenizer x.spiPath
            let res = IVar()
            (Ch.give server (TokReq.Modify(x.spiEdits,res)) >>=. IVar.read res)
            |> run
            |> Json.serialize
        | FileTokenAll x ->
            let server = server_tokenizer x.spiPath
            let res = IVar()
            (Ch.give server (TokReq.GetAll res) >>=. IVar.read res)
            |> run
            |> Json.serialize
        | FileTokenChanges x ->
            let server = server_tokenizer x.spiPath
            let res = IVar()
            (Ch.give server (TokReq.GetChanges res) >>=. IVar.read res)
            |> run
            |> Json.serialize
        |> msg.Push
        msg.PushEmptyFrame()
        msg.Push(address)
        sock.SendMultipartMessage(msg)

server()

