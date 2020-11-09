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
type TokenizerStream = Tokenizer of (TokReq -> (TokRes * TokenizerStream) Job)

let job_thunk_with f x = Job.thunk (fun () -> f x)
let promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let promise_thunk f = Hopac.memo (Job.thunk f)

type TokenizerState = { lines : LineTokens; errors : RString list; blocks : Block list }
let tokenizer_state_def = { lines = PersistentVector.singleton PersistentVector.empty; errors = []; blocks = [] }

let replace (s : TokenizerState) edit =
    let lines, errors = Tokenize.replace s.lines s.errors edit
    let blocks = block_separate lines s.blocks edit
    {lines=lines; errors=errors; blocks=blocks}

let tokenizer (s : TokenizerState) = function
    | DocumentAll text -> replace s {|from=0; nearTo=s.lines.Length; lines=Utils.lines text|}
    | DocumentEdit edit -> replace s edit

type ParserRes = {lines : LineTokens; bundles : Bundle list; parser_errors : RString list; tokenizer_errors : RString list}
type ParserState = {
    is_top_down : bool
    blocks : (LineTokens * ParsedBlock) list
    }

let parse (s : ParserState) (x : Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    List.iter (fun (a,b) -> dict.Add(a,b.parsed)) s.blocks
    let blocks =
        List.map (fun x -> x.block, {
            parsed = Utils.memoize dict (block_init s.is_top_down) x.block
            offset = x.offset
            }) x
    {s with blocks = blocks}

let parser (s : ParserState) (req : TokRes) =
    let s = parse s req.blocks
    let lines, bundles, parser_errors = block_bundle s.blocks
    {lines = lines; bundles = bundles; parser_errors = parser_errors; tokenizer_errors = req.errors}, s

type TypecheckerState = (Bundle * Infer.InferResult * Infer.TopEnv) PersistentVector

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

type SupervisorState = {
    tokenizer : Map<string, TokenizerStream>
    parser : Map<string, ParserStream>
    }

type ClientReq =
    //| ProjectFileOpen of {|uri : string; spiprojText : string|}
    //| ProjectFileChange of {|uri : string; spiprojText : string|}
    //| ProjectFileDelete of {|uri : string|}
    //| ProjectFileLinks of {|uri : string|}
    //| ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
    //| ProjectCodeActions of {|uri : string|}
    | FileOpen of {|uri : string; spiText : string|}
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    //| FileTokenRange of {|uri : string; range : VSCRange|}
    //| HoverAt of {|uri : string; pos : VSCPos|}
    //| BuildFile of {|uri : string|}

type ClientErrorsRes =
    | FatalError of string
    | PackageErrors of {|uri : string; errors : RString []|}
    | TokenizerErrors of {|uri : string; errors : RString []|}
    | ParserErrors of {|uri : string; errors : RString []|}
    | TypeErrors of {|uri : string; errors : RString list|}

let file_op (s : SupervisorState) uri req =
    let (Tokenizer t) = Map.findOrDefault uri tokenizer s.tokenizer
    let (Parser p) = Map.findOrDefault uri (parser (Path.GetExtension(uri) = ".spi")) s.parser
    t req >>= fun (tr,t) ->
    p tr >>- fun (pr,p) ->
    pr, {s with tokenizer=Map.add uri t s.tokenizer; parser=Map.add uri p s.parser}