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

type ClientRes =
    | ProjectFileRes of Result<Schema, VSCErrorOpt []>
    | FileOpenRes of VSCToken * VSCError []
    | FileChangedRes of VSCToken * VSCError []

let uri = "tcp://*:13805"

let server () =
    use sock = new RouterSocket()
    sock.Options.ReceiveHighWatermark <- Int32.MaxValue
    sock.Bind(uri)
    printfn "Server bound to: %s" uri

    while true do
        let msg = sock.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore

        let file_rest x = 
            let a,b = x |> Array.unzip 
            FileOpenRes(a |> Array.concat |> Array.concat, Array.concat b)
        match Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer)) with
        | ProjectFile x -> config x.spiprojDir x.spiprojText |> ProjectFileRes
        | FileOpen x -> x.spiText |> Utils.lines |> Array.mapi (fun i x -> tokenize (i,x)) |> file_rest
        | FileChanged x -> x.spiChangedLines |> Array.map tokenize |> file_rest
        |> Json.serialize |> msg.Push
        msg.PushEmptyFrame()
        msg.Push(address)
        sock.SendMultipartMessage(msg)

server()

