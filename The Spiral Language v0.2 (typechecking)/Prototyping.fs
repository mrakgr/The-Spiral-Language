module Spiral.Prototyping

open System
open System.Collections.Generic
open System.Threading
open System.Reactive
open System.Reactive.Subjects
//open FSharp.Control.Reactive

let tag = let i = ref 0 in fun () -> Interlocked.Increment(i)

type Project = {
    file_text : Dictionary<string, string Subject>
    file_order : string [] Subject
    }
type Projects = Dictionary<string, Project>

let d = Projects()

let update_project id (file_order : string []) =
    (id |> Utils.memoize d (fun _ -> { file_text = Dictionary(); file_order = new Subject<_>() }))
        .file_order.OnNext file_order

let update_file id file text =
    match d.TryGetValue(id) with
    | true, v -> (file |> Utils.memoize v.file_text (fun _ -> new Subject<_>())).OnNext text
    | _ -> ()

type Tag = int
type ParsedFile = ParsedFile of Tag
type TypecheckedFile = TypecheckedFile of Tag