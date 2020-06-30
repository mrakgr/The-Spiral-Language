module Spiral.Server

open System
open System.Collections.Generic
open FSharp.Json
open NetMQ
open NetMQ.Sockets
open Spiral.Config
open Spiral.Tokenize

type ClientReq =
    | ProjectFile of {|spiprojDir : string; spiprojText : string|}
    | FileOpen of {|spiPath : string; spiText : string|}
    | FileChanged of {|spiPath : string; spiChangedLines : (int * string) []|}

type ProjectFileRes = Result<Schema, VSCErrorOpt []>
type FileOpenRes = VSCToken * VSCError []

let uri = "tcp://*:13805"

let server () =
    let tokenizer_state = Utils.memoize (Dictionary()) (fun _ -> ResizeArray())

    use sock = new RouterSocket()
    sock.Options.ReceiveHighWatermark <- Int32.MaxValue
    sock.Bind(uri)
    printfn "Server bound to: %s" uri

    while true do
        let msg = sock.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore

        match Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer)) with
        | ProjectFile x -> (config x.spiprojDir x.spiprojText : ProjectFileRes) |> Json.serialize
        | FileOpen x -> 
            let lines = tokenizer_state x.spiPath
            x.spiText |> Utils.lines |> Array.iteri (fun i x -> tr_set lines (i, tokenize x))
            tr_vscode_view lines |> Json.serialize
        | FileChanged x -> 
            let lines = tokenizer_state x.spiPath
            x.spiChangedLines |> Array.iter (fun (i,x) -> tr_set lines (i, tokenize x))
            tr_vscode_view lines |> Json.serialize
        |> msg.Push
        msg.PushEmptyFrame()
        msg.Push(address)
        sock.SendMultipartMessage(msg)

server()

