module Spiral.Supervisor

open System
open System.IO
open System.Threading.Tasks
open System.Collections.Generic

open VSCTypes
open Spiral.SpiProj
open Spiral.ServerUtils
open Spiral.StreamServer

type SupervisorState = {
    modules : Map<string, ParserRes Hopac.Promise * ModuleStream>
    schemas : Map<string, ValidatedSchema>
    }

let schema_modules_from_disk (s : SupervisorState, l : ValidatedSchema) = 
    let rec elem (loads, s : SupervisorState as w) = function
        | ValidatedFileHierarchy.File((r, path as p),name,exists) ->
            match Map.tryFind path s.modules with
            | Some x -> loads, if exists then s else {s with modules = Map.remove path s.modules}
            | None -> (if exists then (p, File.ReadAllTextAsync(path)) :: loads else loads), s
        | ValidatedFileHierarchy.Directory(name,l) ->
            loop w l
    and loop w l = List.fold elem w l
    let loads, s = loop ([], s) l.files
    List.fold (fun (s : SupervisorState, l : ValidatedSchema) ((r, path : string), x : string Task) ->
        try {s with modules = Map.add path ((module' (path.EndsWith ".spi")).Run(DocumentAll x.Result)) s.modules }, l
        with e -> s, {l with errors = (r, e.Message) :: l.errors}
        ) (s, l) loads
    