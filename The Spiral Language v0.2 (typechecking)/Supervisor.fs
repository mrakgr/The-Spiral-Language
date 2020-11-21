module Spiral.Supervisor

open System
open System.IO
open System.Threading.Tasks
open FSharpx.Collections
open System.Collections.Generic

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
type SupervisorErrorSources = {
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
type LoadResult =
    | LoadModule of package_dir: string * path: RString * Result<TokRes * TokenizerStream,string>
    | LoadPackage of package_dir: string * Result<ValidatedSchema,string>

let package_update errors (s : SupervisorState) package_dir text =
    let queue : LoadResult Task Queue = Queue()
    let rec load_module package_dir s l =
        List.fold (fun s -> function
            | ValidatedFileHierarchy.File((r, path as p),name,exists) ->
                match Map.tryFind path s.modules with
                | Some _ -> if exists then s else {s with modules = Map.remove path s.modules}
                | None -> 
                    if exists then 
                        File.ReadAllTextAsync(path).ContinueWith(fun (x : _ Task) ->
                            try let x = tokenizer.Run(DocumentAll x.Result)
                                Hopac.start (Src.value errors.tokenizer {|uri="file:///" + path; errors=(fst x).errors|})
                                LoadModule(package_dir,p,Ok(x))
                            with e -> LoadModule(package_dir,p,Error e.Message)
                            ) |> queue.Enqueue
                    s
            | ValidatedFileHierarchy.Directory(name,l) ->
                load_module package_dir s l
            ) s l

    let load_package s package_dir text =
        match Map.tryFind package_dir s.packages.validated_schemas, text with
        | _, Some text -> // Parse and validate the schema using the provided string.
            Task.Run(fun () -> LoadPackage(package_dir, Ok(schema_parse_then_validate package_dir text)))
            |> queue.Enqueue
            s
        | Some(Ok x), None -> // Rather than reloading from disk, just revalidate it.
            Task.Run(fun () -> LoadPackage(package_dir, Ok(schema_validate package_dir x.schema)))
            |> queue.Enqueue
            s
        | _ -> // Load from disk and validate it.
            let p = Path.Combine(package_dir,"package.spiproj")
            if File.Exists(p) then 
                File.ReadAllTextAsync(p).ContinueWith(fun (x : _ Task) ->
                    try LoadPackage(package_dir, Ok(schema_parse_then_validate package_dir x.Result))
                    with e -> LoadPackage(package_dir, Error e.Message)
                    ) |> queue.Enqueue
                s
            else {s with packages={s.packages with validated_schemas=Map.add package_dir (Error "The package file does not exist.") s.packages.validated_schemas}}

    let main (s : SupervisorState) (x : LoadResult) =
        match queue.Dequeue().Result with
        | LoadPackage(dir,x) ->
            let s = {s with packages={s.packages with validated_schemas=Map.add dir x s.packages.validated_schemas}}
            match x with
            | Ok x -> List.fold (fun s (r,x) -> load_package s x None) (load_module dir s x.files) x.packages
            | Error _ -> s
        | LoadModule(_,(_,path),Ok x) -> {s with modules=Map.add path x s.modules}
        | LoadModule(package_dir,(r,_),Error er) ->
            match Map.tryFind package_dir s.packages.validated_schemas with
            | Some (Ok x) -> {s with packages={s.packages with validated_schemas=Map.add package_dir (Ok {x with errors = (r,er) :: x.errors}) s.packages.validated_schemas}}
            | _ -> failwith "Compiler error: The package should be present and valid in the map."
    
    let mutable s = load_package s package_dir text
    while 0 < queue.Count do s <- main s (queue.Dequeue().Result)
    s