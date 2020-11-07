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
let promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let promise_thunk f = Hopac.memo (Job.thunk f)
let tokenizer =
    let rec loop (lines, errors, blocks) = Tokenizer(job_thunk_with (fun req -> 
        let replace edit =
            let lines, errors = Tokenize.replace lines errors edit
            let blocks = block_separate lines blocks edit
            lines, errors, blocks

        let next (lines,errors,blocks as x) = {blocks=blocks; errors=errors}, loop x
        match req with
        | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=Utils.lines text|} |> next
        | DocumentEdit edit -> replace edit |> next
        ))
    loop (PersistentVector.singleton PersistentVector.empty ,[],[])

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

let parser is_top_down =
    let rec loop (s : (LineTokens * ParsedBlock) list) = Parser(job_thunk_with (fun req -> 
        let s = parse is_top_down s req.blocks
        bundle req s, loop s
        ))
    loop []

type TypecheckerStream = Typechecker of (Bundle list -> (Infer.InferResult * TypecheckerStream) Stream)
let typechecker package_id module_id top_env =
    let rec tc s_old = Typechecker(fun bundles ->
        let rec loop s (bs : Bundle list) = promise_thunk (fun () ->
            match bs with
            | b :: bs ->
                match PersistentVector.tryNth (PersistentVector.length s) s_old with
                | Some (b', r, _ as old) when b = b'-> Cons((r,tc s_old),loop (PersistentVector.conj old s) bs)
                | _ ->
                    let env = match PersistentVector.tryLast s with Some(_,_,top_env) -> top_env | _ -> top_env
                    let r = Infer.infer package_id module_id env (bundle_top b)
                    let s = PersistentVector.conj (b,r,Infer.union r.top_env_additions env) s
                    Cons((r,tc s),loop s bs)
            | [] -> Nil
            )
        loop PersistentVector.empty bundles
        )
    tc PersistentVector.empty

let hover (l : Infer.InferResult list) (pos : VSCPos) =
    l |> List.tryFindBack (fun x ->
        let start = if 0 < x.hovers.Length then (x.hovers.[0] |> fst |> fst).line else Int32.MaxValue
        start <= pos.line
        )
    |> Option.bind (fun x ->
         x.hovers |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ))