module Spiral.Prototyping

open System
open System.Threading
open System.Collections.Generic
open Hopac
open Hopac.Infixes
open Hopac.Extensions

type Tag = int
let tag = let i = ref 0 in fun () -> Interlocked.Increment(i) : Tag
type ParsedFile = FileParsed of Tag
type TypecheckedFile = FileTypechecked of Tag

let parse text = timeOutMillis 50 ^->. FileParsed(tag())
let tc file_prev text = timeOutMillis 50 ^->. FileTypechecked(tag())

let project add_project add_file id = failwith ""

type ServerIn =
    | ServerAddProject of id: string * files: string []
    | ServerAddFile of file: string * text: string

let parser = Job.delay <| fun () ->
    let req = Ch()
    let res = Ch()
    let rec loop_empty () = (Ch.take req ^=> parse) ^=> loop_sending
    and loop_sending file = loop_empty () <|> (Ch.give res file ^=> fun () -> loop_sending file)

    Job.server (loop_empty ()) >>-. (req, res)

type TykerState = {|ins: ParsedFile Ch; outs: TypecheckedFile Ch|} []
type TykerIn =
    | TykerGoto of int
    | TykerRestart of TykerState

let typechecker = Job.delay <| fun () ->
    let req = Ch()

    let t = Stack()
    let rec skip i = if i > 0 then t.Pop() |> ignore; skip (i-1)
    let rec restart (state : TykerState) (state' : TykerState) =
        let rec loop i = if i < min (Array.length state) (Array.length state') && Object.ReferenceEquals(state.[i].ins,state'.[i].ins) then loop (i+1) else i
        let near_to = loop 0
        skip (t.Count - max 0 near_to)
        start state'
    and goto state i = 
        skip (t.Count - i)
        start state
    and start state =
        if t.Count < state.Length then parse state (if t.Count > 0 then t.Peek() |> Some else None)
        else waiting state
    and waiting state =
        Ch.take req ^=> function
            | TykerGoto i -> goto state (i-1)
            | TykerRestart state' -> restart state state'
    and parse state (file_prev_t : TypecheckedFile option) = 
        waiting state <|> (Ch.take state.[t.Count].ins ^=> typecheck state file_prev_t)
    and typecheck state (file_prev_t : TypecheckedFile option) (file_cur_p : ParsedFile) =
        let body = 
            tc file_prev_t file_cur_p ^=> fun file_cur_t ->
            Ch.give state.[t.Count].outs file_cur_t ^=> fun () ->
            t.Push(file_cur_t)
            start state
        waiting state <|> body

    Job.server (waiting [||]) >>-. req

let server = Job.delay <| fun () ->
    let req = Mailbox()
    let parsers = Dictionary()
    let typecheckers = Dictionary()

    let loop = Mailbox.take req >>= function
        | ServerAddProject(id,files) -> 
            files |> Array.iterJob (fun file ->
                match parsers.TryGetValue(file) with
                | false, _ -> parser >>- fun x -> parsers.Add(file,x)
                | _ -> Job.unit ()
                )
        | ServerAddFile(file,text) ->
            match parsers.TryGetValue(file) with
            | true, (req,res) -> upcast Ch.give req text
            | _ -> Job.unit ()
            
    Job.foreverServer loop >>-. req