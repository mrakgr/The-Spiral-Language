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

type SupervisorReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileDelete of {|uri : string|}
    | ProjectFileLinks of {|uri : string|} * RString list IVar
    | ProjectCodeActions of {|uri : string|} * RAction list IVar
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
    | FileOpen of {|uri : string; spiText : string|}
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * VSCTokenArray IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar

let package_validate_then_send_errors errors s dir =
    let order,packages = package_validate s.packages dir
    package_errors order packages |> Array.iter (fun er ->
        Hopac.start (Src.value errors.package er)
        )
    {s with packages=packages}

let supervisor (errors : SupervisorErrorSources) req =
    let loop s = req >>- function
        | ProjectFileChange x | ProjectFileOpen x ->
            let dir = dir x.uri
            let s = package_update errors s dir (Some x.spiprojText)
            package_validate_then_send_errors errors s dir
        | ProjectFileDelete x ->
            let dir = dir x.uri
            let s = {s with packages={s.packages with validated_schemas=Map.add dir (Error "The package file does not exist.") s.packages.validated_schemas}}
            package_validate_then_send_errors errors s dir
        | ProjectFileLinks(x,res) -> 
            match Map.tryFind (dir x.uri) s.packages.package_schemas with
            | Some (Ok x) -> Hopac.start (IVar.fill res (List.append x.schema.links x.package_links))
            | _ -> Hopac.start (IVar.fill res [])
            s
        | ProjectCodeActions(x,res) ->
            match Map.tryFind (dir x.uri) s.packages.package_schemas with
            | Some (Ok x) -> Hopac.start (IVar.fill res x.schema.actions)
            | _ -> Hopac.start (IVar.fill res [])
            s
        | ProjectCodeActionExecute x -> 
            match code_action_execute x.action with
            | Some er -> Hopac.start (Src.value errors.fatal er)
            | None -> ()
            s
        | FileOpen x -> failwith "TODO"
        | FileChanged x -> failwith "TODO"
        | FileTokenRange(x, res) -> failwith "TODO"
        | HoverAt(x,res) -> failwith "TODO"
    Job.iterateServer {
        modules = Map.empty
        packages = {
            validated_schemas = Map.empty
            package_links = mirrored_graph_empty
            package_schemas = Map.empty
            }
        } loop