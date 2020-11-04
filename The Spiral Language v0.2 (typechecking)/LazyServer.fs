module Spiral.LazyServer

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.Tokenize
open Spiral.TypecheckingUtils
open Spiral.Blockize
open Spiral.SpiProj

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type TokReq =
    | DocumentAll of string
    | DocumentEdit of SpiEdit
type TokRes = {blocks : Block list; errors : RString []}

let tokenizer (req : TokReq Stream): TokRes Stream =
    let lines : LineToken [] ResizeArray = ResizeArray([[||]])
    let mutable errors = [||]
    let mutable blocks : Block list = []

    let replace edit =
        errors <- Tokenize.replace lines errors edit // Mutates the lines array
        blocks <- block_separate lines blocks edit

    let rec loop req = req >>-* function
        | Nil -> Nil
        | Cons(x,next) ->
            let next () = Cons({blocks=blocks; errors=errors},loop next)
            match x with
            | DocumentAll text -> replace {|from=0; nearTo=lines.Count; lines=Utils.lines text|}; next()
            | DocumentEdit edit -> replace edit; next()
    loop req

type ParserRes = {bundles : Bundle list; parser_errors : RString []; tokenizer_errors : RString []}

let parse dict is_top_down (a : TokRes) =
    let b = 
        List.map (fun x -> {
            parsed = Utils.memoize dict (block_init is_top_down) x.block
            offset = x.offset
            }) a.blocks
    dict.Clear(); List.iter2 (fun a b -> dict.Add(a.block,b.parsed)) a.blocks b
    let bundles, parser_errors = block_bundle b
    {bundles = bundles; parser_errors = parser_errors; tokenizer_errors = a.errors}

let parser is_top_down (req : TokRes Stream): ParserRes Stream =
    let parse = parse (Dictionary(HashIdentity.Reference)) is_top_down
    let rec loop req = req >>=* function
        | Cons(_,next) when next.Full -> loop next :> _ Job
        | Cons(x,next) -> Job.result(Cons(parse x, loop next))
        | Nil -> Job.result Nil
    loop req
