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
    let file_tokens = Dictionary()

    use sock = new RouterSocket()
    sock.Options.ReceiveHighWatermark <- Int32.MaxValue
    sock.Bind(uri)
    printfn "Server bound to: %s" uri

    while true do
        let msg = sock.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore

        let file_rest (l : TokenResult []) = 
            let toks' = ResizeArray()
            let ers' = ResizeArray()
            let rec loop i =
                if i < l.Length then
                    let line, toks, ers = l.[i]
                    ers'.AddRange(process_error line ers)
                    let s =
                        Array.mapFold (fun s x ->
                            
                            )
                    match s with
                    | Some(line',from') -> [|line-line'; r.from-from'; r.near_to-r.from; token_groups x; 0|]
                    | None -> [|line; r.from; r.near_to-r.from; token_groups x; 0|]
                else ()
            (toks'.ToArray(), ers'.ToArray() : FileOpenRes) |> Json.serialize
        match Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer)) with
        | ProjectFile x -> (config x.spiprojDir x.spiprojText : ProjectFileRes) |> Json.serialize
        | FileOpen x -> x.spiText |> Utils.lines |> Array.mapi (fun i x -> tokenize (i,x)) |> file_rest
        | FileChanged x -> x.spiChangedLines |> Array.map tokenize |> file_rest
        |> msg.Push
        msg.PushEmptyFrame()
        msg.Push(address)
        sock.SendMultipartMessage(msg)

server()

