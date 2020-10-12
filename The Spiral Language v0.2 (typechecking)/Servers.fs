module Spiral.Servers

open System.Collections.Generic
open FSharpx.Collections

open Spiral.Config
open Spiral.Tokenize
open Spiral.TypecheckingUtils
open Spiral.Blockize

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type TokReq =
    | Put of string
    | Modify of SpiEdit
    | GetRange of VSCRange * (VSCTokenArray -> unit)
type TokRes = {blocks : Block list; errors : VSCError []}
type ParserRes = { bundles : Bundle list; parser_errors : VSCError []; tokenizer_errors : VSCError []}

let tokenizer req =
    let lines : LineToken [] ResizeArray = ResizeArray([[||]])
    let mutable errors_tokenization = [||]
    let mutable blocks : Block list = []

    let res_text = Src.create()
    let replace edit =
        errors_tokenization <- Tokenize.replace lines errors_tokenization edit // Mutates the lines array
        blocks <- block_separate lines blocks edit
        Src.value res_text {blocks=blocks; errors=errors_tokenization}

    req |> Stream.consumeJob (function 
        | Put text -> replace {|from=0; nearTo=lines.Count; lines=Utils.lines text|}
        | Modify edit -> replace edit
        | GetRange((a,b),res) ->
            let from, near_to = min (lines.Count-1) a.line, min lines.Count (b.line+1)
            vscode_tokens from (lines.GetRange(from,near_to-from |> max 0).ToArray()) |> res
            Job.unit()
        )
    Src.tap res_text

let parser is_top_down req =
    let dict = System.Collections.Generic.Dictionary(HashIdentity.Reference)
    req |> Stream.keepPreceding1 |> Stream.mapFun (fun (a : TokRes) ->
        let b = 
            List.map (fun x -> {
                parsed = Utils.memoize dict (block_init is_top_down) x.block
                offset = x.offset
                }) a.blocks
        dict.Clear(); List.iter2 (fun a b -> dict.Add(a.block,b.parsed)) a.blocks b
        let bundles, parser_errors = block_bundle b
        {bundles = bundles; parser_errors = parser_errors; tokenizer_errors = a.errors}
        )
    
let typechecker (req : ParserRes Stream) =
    let req = Stream.values req
    let res = Src.create()
    let r = Src.tap res
    let rec waiting a = req ^=> fun b ->
        let rec loop s i b = 
            match PersistentVector.tryNth i a, b with
            | Some(bundle,_ as r), bundle' :: b' when bundle = bundle' -> loop (PersistentVector.conj r s) (i+1) b'
            | _ -> s, b
        loop PersistentVector.empty 0 b.bundles |> processing
    and processing = function
        | a, [] -> Alt.prepare (Src.value res (a,true) >>- fun () -> waiting a)
        | a, b :: b' -> Alt.prepare (Src.value res (a, false) >>- fun () -> 
                let env = 
                    match PersistentVector.tryLast a with
                    | Some(_,x : Infer.InferResult) -> x.top_env
                    | None -> Infer.default_env
                let a' = PersistentVector.conj (b, Infer.infer env (bundle b)) a
                waiting a' <|> processing (a', b')
                )
    Job.server (waiting PersistentVector.empty) |> Hopac.queue
    r
