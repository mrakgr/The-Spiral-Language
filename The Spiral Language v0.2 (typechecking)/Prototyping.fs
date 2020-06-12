module Spiral.Prototyping

open System
open System.Threading
open System.Collections.Generic
open Hopac
open Hopac.Infixes
open Hopac.Extensions

type Tag = int
let tag = let i = ref 0 in fun () -> Interlocked.Increment(i) : Tag
type ParsedFile = ParsedFile of Tag
type TypecheckedFile = TypecheckedFile of Tag

let project add_project add_file id = failwith ""

type ServerIn =
    | ServerAddProject of id: string * files: string []
    | ServerAddFile of file: string * text: string

let parser = Job.delay <| fun () ->
    let req = Mailbox()
    let res = Ch()
    let rec loop_empty () = Mailbox.take req ^=> fun text -> loop_sending (ParsedFile(tag()))
    and loop_sending file = loop_empty () <|> (Ch.give res file ^=> fun () -> loop_sending file)

    Job.server (loop_empty ()) >>-. (req, res)

//let typechecker = Job.delayWith <| fun id ->
    

let server = Job.delay <| fun () ->
    let parsers = Dictionary()

    let req = Mailbox()
    let loop = Mailbox.take req >>= function
        | ServerAddProject(id,files) -> 
            files 
            |> Array.iterJob (fun file ->
                match parsers.TryGetValue(file) with
                | false, _ -> parser >>- fun x -> parsers.Add(file,x)
                | _ -> Job.unit ()
                )
        | ServerAddFile(file,text) ->
            match parsers.TryGetValue(file) with
            | true, (req,res) -> Mailbox.send req text
            | _ -> Job.unit ()
            
    Job.foreverServer loop >>-. req