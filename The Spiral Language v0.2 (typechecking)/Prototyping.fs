module Spiral.Prototyping

open System
open System.Collections.Generic
open System.Threading
open System.Reactive
open System.Reactive.Subjects
//open FSharp.Control.Reactive

open FSharpx.Control

type Tag = int
let tag = let i = ref 0 in fun () -> Interlocked.Increment(i) : Tag
type ParsedFile = ParsedFile of Tag
type TypecheckedFile = TypecheckedFile of Tag

type MsgClient =
    | ClientAddProject of id: string * files: string []
    | ClientAddFile of id: string * file: string * text: string

type MsgProject =
    | ProjAddProject of files: string []
    | ProjAddFile of file: string * text: string
    | ProjParserDone of file: string * ParsedFile
    | ProjTykerDone of file: string * TypecheckedFile

type MsgParser =
    | ParserFile of text: string

type MsgTypechecker =
    | TykerSize of near_to: int * length: int
    | TykerFile of i: int * ParsedFile
    | TykerFocus of i: int

type StateProject = {
    file_order: Dictionary<string, int>
    }

type StateTypechecker = {
    file_parsed : ParsedFile option []
    file_typechecked : TypecheckedFile option []
    }

let parser rep = Agent.Start(fun mb ->
    let rec loop () = async {
        match! mb.Receive() with
        | ParserFile(text) -> 
            tag () |> ParsedFile |> rep
            return! loop ()
        }
    loop ()
    )

let typechecker rep = Agent.Start(fun mb ->
    let rec loop state = async {
        match! mb.Receive() with
        | TykerSize(near_to,length) ->
            let f (file: _ []) = Array.init length (fun i -> if i < near_to then file.[i] else None)
            return! loop {
                file_parsed = f state.file_parsed
                file_typechecked = f state.file_typechecked
                }
        | TykerFile(i, x) ->
            state.file_parsed.[i] <- Some x
            return! loop state
        | TykerFocus from ->
            let f (file : _ []) = for i=from+1 to file.Length-1 do file.[i] <- None
            f state.file_typechecked; f state.file_parsed
        }
    loop {file_parsed=[||]; file_typechecked=[||]}
    )

let project rep = Agent.Start(fun mb ->
    let parsers = Dictionary()
    let tyker = typechecker ()
    let rec loop (state: StateProject) = async { 
        let iter_order file f = match state.file_order.TryGetValue(file) with true, i -> f i | _ -> ()
        match! mb.Receive() with
        | ProjAddProject files -> return! {state with file_order=files |> Array.mapi (fun i x -> KeyValuePair(x, i)) |> Dictionary} |> loop
        | ProjAddFile(file, text) ->
            file |> Utils.memoize parsers (fun file -> (fun x -> ProjParserDone(file,x) |> mb.Post) |> parser)
            |> fun p -> iter_order file (fun _ -> p.Post(ParserFile text))
            return! loop state
        | ProjParserDone(file, x) ->
            iter_order file (fun i -> TykerFile(i,x) |> tyker.Post)
            return! loop state
        | ProjTykerDone(file, x) ->
            //rep file x
            return! loop state
        }
    loop {file_order=Dictionary()}
    )

let server = Agent.Start(fun mb -> 
    let d = Dictionary()
    let rec loop () = async {
        let project_get id = Utils.memoize d project id
        match! mb.Receive() with
        | ClientAddProject(id, files) -> (project_get id).Post(ProjAddProject files)
        | ClientAddFile(id, file, text) -> (project_get id).Post(ProjAddFile(file,text))
        }
    loop ()
    )