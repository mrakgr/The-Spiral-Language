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
    let rec loop (a,b) = 
        {new ParserStream with 
            member t.Run(req) =
                let a = if Promise.Now.isFulfilled b then Promise.Now.get b else a
                let r = promise_thunk <| fun () ->
                    let s = parse is_top_down a req.blocks
                    let lines, bundles, parser_errors = block_bundle s
                    {lines = lines; bundles = bundles; parser_errors = parser_errors; tokenizer_errors = req.errors}, s
                r >>-* fst, loop (a,r >>-* snd)
            }
    loop ([],Promise.Now.never())

type TypecheckerStream = abstract member Run : Bundle list Promise -> Infer.InferResult Stream * TypecheckerStream
let typechecker package_id module_id top_env =
    let rec tc s_old = 
        let rec loop s (bs : Bundle list) = 
            match bs with
            | b :: bs ->
                match PersistentVector.tryNth (PersistentVector.length s) s_old with
                | Some (b', r, _ as old) when b = b'-> Cons((r,tc s_old),wrap (PersistentVector.conj old s) bs)
                | _ ->
                    let env = match PersistentVector.tryLast s with Some(_,_,top_env) -> top_env | _ -> top_env
                    let r = Infer.infer package_id module_id env (bundle_top b)
                    let s = PersistentVector.conj (b,r,Infer.union r.top_env_additions env) s
                    Cons((r,tc s),wrap s bs)
            | [] -> Nil
        and wrap s bs = promise_thunk (fun () -> loop s bs)
        {new TypecheckerStream with
            member t.Run(bundles) = bundles >>-* loop PersistentVector.empty
            }
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

type FileStream = abstract member Run : TokReq -> (TokRes * FileStream) * (ParserRes * FileStream) Promise * (Infer.InferResult * FileStream) Stream

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