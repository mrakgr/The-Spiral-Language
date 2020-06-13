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

let parse text = Promise.start (timeOutMillis 50 ^->. FileParsed(tag()))
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

    Job.server (loop_empty ()) >>-. {|req=req; res=res|}

type TykerState = {|req: ParsedFile Promise Ch; res: TypecheckedFile Ch|} []
type TykerIn =
    | TykerGoto of int
    | TykerRestart of TykerState

let typechecker = Job.delay <| fun () ->
    let req = Ch()

    let t = Stack()
    let rec skip i = if i > 0 && t.Count > 0 then t.Pop() |> ignore; skip (i-1)
    let rec restart (state : TykerState) (state' : TykerState) =
        let rec loop i = if i < min (Array.length state) (Array.length state') && Object.ReferenceEquals(state.[i].req,state'.[i].req) then loop (i+1) else i
        goto state' (loop 0 - 1)
    and goto state i = 
        skip (t.Count - i)
        start state i
    and start state i =
        if t.Count < min (i + 1) state.Length then parse state i (if t.Count > 0 then t.Peek() |> Some else None)
        else waiting state
    and waiting state =
        Ch.take req ^=> function
            | TykerGoto i -> goto state (i - 1)
            | TykerRestart state' -> restart state state'
    and parse state i (file_prev_t : TypecheckedFile option) = 
        waiting state <|> ((Ch.take state.[t.Count].req ^=> Promise.read) ^=> typecheck state i file_prev_t)
    and typecheck state i (file_prev_t : TypecheckedFile option) (file_cur_p : ParsedFile) =
        let body = 
            tc file_prev_t file_cur_p ^=> fun file_cur_t ->
            Ch.give state.[t.Count].res file_cur_t ^=> fun () ->
            t.Push(file_cur_t)
            start state i
        waiting state <|> body

    Job.server (waiting [||]) >>-. req

let server = Job.delay <| fun () ->
    let req = Mailbox()
    let parsers = Dictionary()
    let typecheckers = Dictionary()

    let loop = Mailbox.take req >>= function
        | ServerAddProject(id,files) -> 
            files |> Array.mapJob (fun file ->
                match parsers.TryGetValue(file) with
                | true, v -> Job.result v
                | _ -> parser >>- fun x -> parsers.Add(file,x); x
                )
            >>= fun parsers ->
                let f tc_req =
                    parsers |> Array.map (fun p -> {|req=p.res; res=Ch()|})
                    |> TykerRestart
                    |> Ch.give tc_req
                match typecheckers.TryGetValue(id) with
                | false, _ -> typechecker >>= fun x -> typecheckers.[id] <- x; f x
                | true, x -> upcast f x
        | ServerAddFile(file,text) ->
            match parsers.TryGetValue(file) with
            | true, p -> upcast Ch.give p.req text
            | _ -> Job.unit ()
            
    Job.foreverServer loop >>-. req