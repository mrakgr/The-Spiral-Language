module Spiral.Compile

open System.Collections.Generic
open System.Diagnostics
open System
open Spiral.Utils
open Spiral.ParserCombinators
open Spiral.Parsing
open Spiral.Prepass
open Spiral.PartEval
open Spiral.CodegenFsharp

type Timings =
    {
    parse : TimeSpan
    prepass : TimeSpan
    peval : TimeSpan
    codegen : TimeSpan
    }

    member x.Add(y) =
        {
        parse = x.parse + y.parse
        prepass = x.prepass + y.prepass
        peval = x.peval + y.peval
        codegen = x.codegen + y.codegen
        }

type Watches = 
    {
    parse : Stopwatch
    prepass : Stopwatch
    peval : Stopwatch
    codegen : Stopwatch
    }

    member x.Elapsed: Timings =
        {
        parse = x.parse.Elapsed
        prepass = x.prepass.Elapsed
        peval = x.peval.Elapsed
        codegen = x.codegen.Elapsed
        }

let inline timeit (d: Stopwatch) f x =
    d.Start()
    let x = f x
    d.Stop()
    x

type CompilationEnv = {
    keywords : KeywordEnv
    types : Map<string,TExpr>
    values : Map<string,Expr>
    }

let module' (d : CompilationEnv) (x : SpiralModule) =
    match parse x with
    | Ok(var_positions,x) ->
        match prepass var_positions d.keywords d.types d.values x with
        | Ok(t,v) -> {d with types=t; values=v}
        | Error er -> failwith er
    | Error er -> failwith er
        
let modules (d : CompilationEnv) (x : SpiralModule) =
    let m = Dictionary(HashIdentity.Reference)
    let rec f (d : CompilationEnv) (x : SpiralModule) =
        memoize m (fun _ -> module' (List.fold f d x.prerequisites) x) x

    f d x

let compile d x =
    let d = modules d x
    match d.values.[x.name].["main"] with
    | Raw