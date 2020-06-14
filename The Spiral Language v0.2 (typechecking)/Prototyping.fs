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

let rnd_v = MVar(Random())
let wait t = MVar.take rnd_v ^=> fun rnd -> MVar.fill rnd_v rnd >>=. timeOutMillis (rnd.Next(t))
let parse text = wait 100 ^->. FileParsed(tag())
let tc file_prev text = wait 100 ^->. FileTypechecked(tag())

let editor = Job.delay <| fun () ->
    let c = Ch ()
    let loop = Ch.take c >>-. ()
    Job.foreverServer loop >>-. c

type ServerIn =
    | ServerAddProject of id: string * files: string []
    | ServerAddFile of id: string * file: string * text: string

let parser = Job.delay <| fun () ->
    let req = Ch()
    let res = Ch()
    let rec loop_empty () = (Ch.take req ^-> (parse >> memo)) ^=> loop_sending
    and loop_sending (file : _ Promise) = loop_empty () <|> (Ch.give res file ^=> fun () -> loop_sending file)

    Job.server (loop_empty ()) >>-. {|req=req; res=res|}

type TykerState = {|req: ParsedFile Promise Ch; res: TypecheckedFile -> unit Alt|} []
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
            state.[t.Count].res file_cur_t ^=> fun () ->
            t.Push(file_cur_t)
            start state i
        waiting state <|> body

    Job.server (waiting [||]) >>-. req

let server = Job.delay <| fun () ->
    let req = Mailbox()
    let parsers = Dictionary()
    let typecheckers = Dictionary()

    let loop out = Mailbox.take req >>= function
        | ServerAddProject(id,files) -> 
            files |> Array.mapJob (fun file ->
                match parsers.TryGetValue(file) with
                | true, v -> Job.result v
                | _ -> parser >>- fun x -> parsers.Add(file,x); x
                )
            >>= fun parsers ->
                let body tc_req =
                    let x = {|
                        req = tc_req
                        gotos = files |> Array.mapi (fun i x -> KeyValuePair(x, Ch.give tc_req (TykerGoto i))) |> Dictionary
                        restart = (files, parsers) ||> Array.map2 (fun file p -> {|req=p.res; res=fun x -> Ch.give out (file,x)|}) |> TykerRestart |> Ch.give tc_req
                        |}
                    typecheckers.[id] <- x
                    x.restart :> _ Job
                match typecheckers.TryGetValue(id) with
                | false, _ -> typechecker >>= body
                | true, x -> body x.req
        | ServerAddFile(id',file,text) ->
            match parsers.TryGetValue(file) with
            | true, p -> 
                let inline f (d : Dictionary<_,_>) x on_succ = match d.TryGetValue(x) with true, v -> on_succ v | _ -> Alt.unit ()
                let goto = f typecheckers id' (fun v -> f v.gotos file id)
                Ch.give p.req text >>=. goto
            | _ -> Job.unit ()
            
    editor >>= fun x -> 
    Job.foreverServer (loop x) >>-. req