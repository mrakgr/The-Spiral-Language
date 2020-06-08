module Spiral.ConfigServer

open Spiral.Config

let process_errors = Result.mapError <| fun x ->
    let pos x : Range option = Some {Start=x; End={Line=x.Line; Column=x.Column+1}}
    let fatal_error = function
        | Tabs l -> l |> Array.map (fun x -> "Tab not allowed.", pos x)
        | ConfigCannotReadProjectFile x -> [|sprintf "Cannot read package.spiproj at path: %s" x, None|]
        | ConfigProjectDirectoryPathInvalid x -> [|sprintf "Invalid project directory: %s" x, None|]
        | ParserError(x,p) -> [|x, pos p|]
        | UnexpectedException x -> [|x, None|]
    let duplicate er l = l |> Array.collect (snd >> Array.map (fun x -> er, pos x))
    let resumable_error = function
        | DuplicateFiles l -> duplicate "Duplicate name." l
        | DuplicateRecordFields l -> duplicate "Duplicate record field." l
        | MissingNecessaryRecordFields (l,p) -> [|sprintf "Record is missing the fields: %s" (String.concat ", " l), Some p|]
        | DirectoryInvalid (x,p) -> [|x, pos p|]
        | MainMustBeLast p -> [|"The module Main must be the last one in the directory.", pos p|]
        | MainMustBeAFile p -> [|"The module Main must be a file.", pos p|]
    match x with
    | ResumableError x -> Array.collect resumable_error x
    | FatalError x -> fatal_error x

open System
open MBrace.FsPickler
open NetMQ
open NetMQ.Sockets

type ClientMsgs =
    | ProjectDir of string

let uri = "tcp://*:13805"

let server () =
    use sock = new RouterSocket()
    sock.Bind(uri)
    printfn "Server bound to: %s" uri
    let ser = Json.JsonSerializer(false,true)
    while true do
        let msg = sock.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore

        let x = msg.Pop()
        match ser.UnPickle(x.Buffer) with
        | ProjectDir dir ->
            msg.Push(config dir |> process_errors |> ser.Pickle)
            msg.PushEmptyFrame()
            msg.Push(address)
            sock.SendMultipartMessage(msg)

server()