module Spiral.Server

open System
open System.Collections.Generic
open FSharp.Json
open NetMQ
open NetMQ.Sockets
open Spiral.Config
open Spiral.Tokenize

type Changes = { range: Range; rangeOffset: int; rangeLength: int; text: string }
let process_errors = Result.mapError <| fun x ->
    let pos' len (x : Pos) : Range option =
        let x : Pos = {line=x.line-1; character=x.character-1}
        Some (x, {line=x.line; character=x.character+len})
    let pos x = pos' 1 x
    let fatal_error = function
        | Tabs l -> l |> Array.map (fun x -> "Tab not allowed.", pos x)
        | ConfigCannotReadProjectFile x -> [|sprintf "Cannot read package.spiproj at path: %s" x, None|]
        | ConfigProjectDirectoryPathInvalid x -> [|sprintf "Invalid project directory: %s" x, None|]
        | ParserError(x,p) -> [|(Utils.lines x).[3..] |> String.concat "\n", pos p|]
        | UnexpectedException x -> [|sprintf "Compiler error: %s" x, None|]
    let duplicate er l = l |> Array.collect (fun (name : string, l) -> l |> Array.map (fun x -> er l.Length, pos' name.Length x))
    let resumable_error = function
        | DuplicateFiles l -> duplicate (sprintf "Duplicate name. Count: %i") l
        | DuplicateRecordFields l -> duplicate (sprintf "Duplicate record field. Count: %i") l
        | MissingNecessaryRecordFields (l,p) -> [|sprintf "Record is missing the fields: %s" (String.concat ", " l), Some p|]
        | DirectoryInvalid (x,p) -> [|x, pos' x.Length p|]
        | MainMustBeLast p -> [|"The module Main must be the last one in the directory.", pos' 4 p|]
        | MainMustBeAFile p -> [|"The module Main must be a file.", pos' 4 p|]
    match x with
    | ResumableError x -> Array.collect resumable_error x
    | FatalError x -> fatal_error x

type ClientReq =
    | ProjectFile of {|spiprojDir : string; spiprojText : string|}
    | File of {|spiPath : string; spiChangedLines : (int * string) []|}

type Error = string * Config.Range option
type TokenSuc = {line: int; char: int; length: int; tokenType: int; tokenModifiers: int}
type ClientRes =
    | ProjectFileRes of Result<Schema, Error []>
    | FileRes of TokenSuc[] * (string * Config.Range) []

open Spiral.LineParsers
let process_token (line, text) = 
    match tokenize text with
    | Error _ -> failwith "impossible" 
    | Ok(toks,ers) ->
        let toks = toks |> Array.map (fun (r,x) -> {line=line; char=r.from; length=r.near_to-r.from; tokenType=token_groups x; tokenModifiers=0})
        let ers = 
            List.toArray ers
            |> Array.groupBy (fun (a,_) -> a.from)
            |> Array.map (fun (from,ar) ->
                if 0 < ar.Length then
                    let near_to, (expecteds, messages) = 
                        ar |> Array.fold (fun (near_to, (expecteds, messages)) (a,b) -> 
                            max near_to a.near_to,
                            match b with
                            | Expected x -> x :: expecteds, messages
                            | Message x -> expecteds, x :: messages
                            ) (Int32.MinValue,([],[]))
                    let range = {line=line; character=from}, {line=line; character=near_to}
                    let ex = match expecteds with [x] -> sprintf "Expected %s" x | x -> sprintf "Expected one of: %s" (String.concat ", " x)
                    let f l = String.concat "\n" l
                    if List.isEmpty expecteds then f messages
                    elif List.isEmpty messages then ex
                    else f (ex :: "" :: "Other error messages:" :: messages)
                    |> fun x -> Some(x,range)
                else None
                )
            |> Array.choose id
        toks, ers

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

        match Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer)) with
        | ProjectFile x -> config x.spiprojDir x.spiprojText |> process_errors |> ProjectFileRes |> Json.serialize |> msg.Push
        | File x -> x.spiChangedLines |> Array.map process_token |> Array.unzip |> fun (a,b) -> FileRes(Array.concat a, Array.concat b) |> Json.serialize |> msg.Push
        msg.PushEmptyFrame()
        msg.Push(address)
        sock.SendMultipartMessage(msg)

server()