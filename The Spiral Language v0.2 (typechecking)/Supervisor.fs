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
    | LoadModule of package_dir: string * path: string * Result<TokRes * TokenizerStream,string>
    | LoadPackage of package_dir: string * Result<ValidatedSchema,string>

let load errors (s : SupervisorState) project_dir =
    let queue : (SupervisorState -> LoadResult) Task Queue = Queue()
    let load_package _ = failwith "TODO"
    let load_module _ = failwith "TODO"

    let main (s : SupervisorState) (x : LoadResult) = s
    load_package project_dir
    let mutable s = s
    while 0 < queue.Count do s <- main s (queue.Dequeue().Result s)
    s