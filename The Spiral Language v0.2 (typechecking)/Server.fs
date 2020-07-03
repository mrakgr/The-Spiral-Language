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

type ProjectFileRes = Result<Schema, VSCErrorOpt []>
type FileOpenRes = VSCTokenArray * VSCError []

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
        | ProjectFileOpen x -> (config x.spiprojDir x.spiprojText : ProjectFileRes) |> Json.serialize
        | FileOpen x -> 
            let server = server_tokenizer x.spiPath
            (Ch.give server.open'.req x.spiText >>=. Ch.take server.open'.res)
            |> run
            |> Json.serialize
        | FileChanged x -> 
            let server = server_tokenizer x.spiPath
            (Ch.give server.change.req x.spiChangedLines >>=. Ch.take server.change.res)
            |> run
            |> Json.serialize
        |> msg.Push
        msg.PushEmptyFrame()
        msg.Push(address)
        sock.SendMultipartMessage(msg)

server()

