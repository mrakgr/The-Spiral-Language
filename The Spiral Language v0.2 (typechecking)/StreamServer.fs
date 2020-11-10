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
open Spiral.ServerUtils

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type TokReq =
    | DocumentAll of string
    | DocumentEdit of SpiEdit
type TokRes = {blocks : Block list; errors : RString list}

let job_thunk_with f x = Job.thunk (fun () -> f x)
let promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let promise_thunk f = Hopac.memo (Job.thunk f)

type TokenizerStream = abstract member Run: TokReq -> TokRes * TokenizerStream

let tokenizer =
    let rec loop (lines, errors, blocks) = {new TokenizerStream with
        member t.Run req =
            let replace edit =
                let lines, errors = Tokenize.replace lines errors edit
                let blocks = block_separate lines blocks edit
                lines, errors, blocks

            let next (_,errors,blocks as x) = {blocks=blocks; errors=errors}, loop x
            match req with
            | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=Utils.lines text|} |> next
            | DocumentEdit edit -> replace edit |> next
            }
    loop (PersistentVector.singleton PersistentVector.empty ,[],[])

let parse is_top_down (s : (LineTokens * ParsedBlock) list) (x : Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    List.iter (fun (a,b) -> dict.Add(a,b.parsed)) s
    List.map (fun x -> x.block, {
        parsed = Utils.memoize dict (block_init is_top_down) x.block
        offset = x.offset
        }) x

type ParserRes = {lines : LineTokens; bundles : Bundle list; parser_errors : RString list; tokenizer_errors : RString list}
type ParserStream = abstract member Run : TokRes -> ParserRes Promise * ParserStream
let parser is_top_down =
    let run s req =
        let s = promise_thunk <| fun () -> parse is_top_down s req.blocks
        let a = s >>-* fun s ->
            let lines, bundles, parser_errors = block_bundle s
            {lines = lines; bundles = bundles; parser_errors = parser_errors; tokenizer_errors = req.errors}
        a, s
    let rec loop s =
        {new ParserStream with
            member t.Run(req) =
                let s = s()
                let a,s' = run s req
                a, loop (fun () -> if Promise.Now.isFulfilled s' then Promise.Now.get s' else s)
                }
    loop (fun () -> [])

type TypecheckerStream = abstract member Run : Bundle list Promise -> Infer.InferResult Stream * TypecheckerStream
let typechecker package_id module_id top_env =
    let rec run old_results env i (bs : Bundle list) = 
        match bs with
        | b :: bs ->
            match PersistentVector.tryNth i old_results with
            | Some (b', _, env as s) when b = b' -> Cons(s,Promise(run old_results env (i+1) bs))
            | _ ->
                let x = Infer.infer package_id module_id env (bundle_top b)
                let _,_,env as s = b,x,Infer.union x.top_env_additions env
                Cons(s,promise_thunk (fun () -> run old_results env (i+1) bs))
        | [] -> Nil
    let rec cons_fulfilled olds = function
        | Cons(old,next) when Promise.Now.isFulfilled next -> cons_fulfilled (PersistentVector.conj old olds) (Promise.Now.get next)
        | _ -> olds
    let rec loop old_results =
        {new TypecheckerStream with
            member _.Run(bundles) =
                let r = 
                    bundles >>=* fun bundles ->
                    // Doing the memoization like this has the disadvantage of always focing the evaluation of the previous 
                    // streams' first item, but will never throw away old states.
                    old_results >>- fun old_results ->
                    run (cons_fulfilled PersistentVector.empty old_results) top_env 0 bundles
                let a = Stream.mapFun (fun (_,x,_) -> x) r
                a, loop r
            }
    loop Stream.nil

let hover (l : Infer.InferResult list) (pos : VSCPos) =
    l |> List.tryFindBack (fun x ->
        let start = if 0 < x.hovers.Length then (x.hovers.[0] |> fst |> fst).line else Int32.MaxValue
        start <= pos.line
        )
    |> Option.bind (fun x ->
         x.hovers |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ))

type FileStream = abstract member Run : TokReq -> TokRes * ParserRes Promise * Infer.InferResult Stream * FileStream

type FileStreamState = {
    tokenizer : TokenizerStream
    parser : ParserStream
    typechecker : TypecheckerStream
    }

let file is_top_down =
    let rec loop (s : FileStreamState) =
        {new FileStream with
            member t.Run req =
                let a,tok = s.tokenizer.Run req
                let s = {s with tokenizer = tok}
                let par = s.parser.Run a >>-* fun (a,s') -> a, {s with parser=s'}
                let typ = par >>-* fun (b,s) ->
                    s.typechecker.Run(b.bundles) |> Stream.mapFun (fun (x,s') -> x,{s with typechecker=s'})
                //let c = s.typechecker.Run(b >>-* fun x -> x.bundles)
                //a,b,c |> Stream.mapFun fst,loop {
                //    tokenizer = tok
                //    parser = par
                //    typechecker = s.typechecker
                //    }
            }
    loop {tokenizer=tokenizer; parser=parser is_top_down; typechecker=typechecker 0 0 Infer.top_env_default}