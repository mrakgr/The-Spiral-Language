module Spiral.StreamServer

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
type TokRes = {blocks : Block list; errors : RString list}
type TokenizerStream = Tokenizer of (TokReq -> (TokRes * TokenizerStream) Job)

let job_thunk_with f x = Job.thunk (fun () -> f x)
let promise_thunk f x = Hopac.memo (job_thunk_with f x)
let rec tokenizer (lines, errors, blocks) = Tokenizer(job_thunk_with (fun req -> 
    let replace edit =
        let lines, errors = Tokenize.replace lines errors edit
        let blocks = block_separate lines blocks edit
        lines, errors, blocks

    let next (lines,errors,blocks as x) = {blocks=blocks; errors=errors}, tokenizer x
    match req with
    | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=Utils.lines text|} |> next
    | DocumentEdit edit -> replace edit |> next
    ))

let tokenizer_def = tokenizer (PersistentVector.empty,[],[])

type ParserRes = {bundles : Bundle list; parser_errors : RString list; tokenizer_errors : RString list}
type ParserStream = Parser of (TokRes -> (ParserRes * ParserStream) Job)

let parse is_top_down (s : (LineTokens * ParsedBlock) list) (x : Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    List.iter (fun (a,b) -> dict.Add(a,b.parsed)) s
    List.map (fun x -> x.block, {
        parsed = Utils.memoize dict (block_init is_top_down) x.block
        offset = x.offset
        }) x

let bundle (tok : TokRes) (s : (_ * ParsedBlock) list) =
    let bundles, parser_errors = block_bundle s
    {bundles = bundles; parser_errors = parser_errors; tokenizer_errors = tok.errors}

let rec parser is_top_down (s : (LineTokens * ParsedBlock) list) = Parser(job_thunk_with (fun req -> 
    let s = parse is_top_down s req.blocks
    bundle req s, parser is_top_down s
    ))

let parser_def is_top_down = parser is_top_down []