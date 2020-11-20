module Spiral.Supervisor

open System
open System.IO
open System.Threading.Tasks
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.Tokenize
open Spiral.Infer
open Spiral.ServerUtils
open Spiral.StreamServer

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type LocalizedErrors = {|uri : string; errors : RString list|}
type SupervisorErrorsSources = {
    fatal : string Src
    tokenizer : LocalizedErrors Src
    parser : LocalizedErrors Src
    typer : LocalizedErrors Src
    package : LocalizedErrors Src
    }
type SupervisorState = {
    modules : Map<string, TokRes * TokenizerStream>
    packages : PackageMaps
    }

let schema_modules_from_disk errors (s : SupervisorState, l : ValidatedSchema) = 
    let rec elem (loads, s : SupervisorState as w) = function
        | ValidatedFileHierarchy.File((r, path as p),name,exists) ->
            match Map.tryFind path s.modules with
            | Some _ -> loads, if exists then s else {s with modules = Map.remove path s.modules}
            | None -> (if exists then (p, File.ReadAllTextAsync(path)) :: loads else loads), s
        | ValidatedFileHierarchy.Directory(name,l) ->
            loop w l
    and loop w l = List.fold elem w l
    let loads, s = loop ([], s) l.files
    List.fold (fun (s : SupervisorState, l : ValidatedSchema) ((r, path : string), x : string Task) ->
        try let x = tokenizer.Run(DocumentAll x.Result)
            let uri = "file:///" + path
            Hopac.start (Src.value errors.tokenizer {|uri=uri; errors=(fst x).errors|})
            {s with modules = Map.add path x s.modules }, l
        with e -> s, {l with errors = (r, e.Message) :: l.errors}
        ) (s, l) loads

//let project_file_open uri text errors (s : SupervisorState) =
//    change true s.packages (dir uri) text >>= fun (ers,m') -> m := m'; Array.iterJob (Src.value package_errors) ers