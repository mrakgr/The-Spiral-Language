module Spiral.WDiff

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral
open Spiral.Tokenize
open Spiral.BlockSplitting
open Spiral.TypecheckingUtils
open Spiral.Infer

type SpiEdit = {|from: int; nearTo: int; lines: string []|}
type TokReq =
    | DocumentAll of string []
    | DocumentEdit of SpiEdit

let process_error v = 
    let messages, expecteds = v |> List.distinct |> List.partition (fun x -> Char.IsUpper(x,0))
    let ex () = match expecteds with [x] -> sprintf "Expected: %s" x | x -> sprintf "Expected one of: %s" (String.concat ", " x)
    let f l = String.concat "\n" l
    if List.isEmpty expecteds then f messages
    elif List.isEmpty messages then ex ()
    else f (ex () :: "" :: "Other error messages:" :: messages)

let add_line_to_range line ((a,b) : VSCRange) = {|a with line=line+a.line|}, {|b with line=line+b.line|}

let process_errors line (ers : LineTokenErrors list) : RString list =
    ers |> List.mapi (fun i l -> 
        let i = line + i
        l |> List.map (fun (r,x) -> x, ({|line=i; character=r.from|}, {|line=i; character=r.nearTo|}))
        )
    |> List.concat
    |> List.groupBy snd
    |> List.map (fun (k,v) -> k, process_error (List.map fst v))

/// Replaces the token lines and updates the errors given the edit.
let tokenize_replace (lines : _ PersistentVector PersistentVector, errors : _ list) (edit : SpiEdit) =
    let toks, ers = Array.map tokenize edit.lines |> Array.unzip
    let lines = PersistentVector.replace edit.from edit.nearTo toks lines
    let errors = 
        let adj = edit.lines.Length - (edit.nearTo - edit.from)
        errors |> List.choose (fun ((a : VSCPos,b),c as x) -> 
            if edit.from <= a.line && a.line < edit.nearTo then None
            elif edit.nearTo <= a.line && adj <> 0 then Some (add_line_to_range adj (a,b),c)
            else Some x
            )
    let errors = List.append errors (process_errors edit.from (Array.toList ers))
    lines, errors

type TokenizerState = {
    lines_text : string PersistentVector
    lines_token : (LineParsers.Range * SpiralToken) PersistentVector PersistentVector
    blocks : LineTokens Block list
    errors : RString list
    }

let wdiff_tokenizer_init = { lines_text = PersistentVector.empty; lines_token = PersistentVector.empty; blocks = []; errors = [] }

/// Immutably updates the state based on the request. Does diffing to make the operation efficient.
/// It is possible for the server to go out of sync, in which case an error is returned.
let wdiff_tokenizer (state : TokenizerState) req = 
    let replace (edit : SpiEdit) =
        if edit.nearTo <= state.lines_text.Length then
            let lines_text = PersistentVector.replace edit.from edit.nearTo edit.lines state.lines_text
            let lines_token, errors = tokenize_replace (state.lines_token, state.errors) edit
            let blocks = wdiff_block_all state.blocks (lines_token, edit.lines.Length, edit.from, edit.nearTo)
            Ok {lines_text=lines_text; lines_token=lines_token; errors=errors; blocks=blocks}
        else 
            Error "The edit is out of bounds and cannot be applied. The language server and the editor are out of sync. Try reopening the file being edited."

    match req with
    | DocumentAll text -> replace {|from=0; nearTo=state.lines_text.Length; lines=text|}
    | DocumentEdit edit -> replace edit

open BlockParsing
let semantic_updates_apply (block : LineTokens) updates =
    Seq.fold (fun block (c : VectorCord, l) -> 
        let x =
            let r, x = PersistentVector.nthNth c.row c.col block
            let x =
                match x with
                | TokVar(a,_) -> TokVar(a,l)
                | TokSymbol(a,_) -> TokSymbol(a,l)
                | TokSymbolPaired(a,_) -> TokSymbolPaired(a,l)
                | TokOperator(a,_) -> TokOperator(a,l)
                | TokUnaryOperator(a,_) -> TokUnaryOperator(a,l)
                | x -> failwithf "Compiler error: Cannot change the semantic legend for the %A token." x
            r, x
        PersistentVector.updateNth c.row c.col x block
        ) block updates

let parse_block is_top_down (block : LineTokens) =
    let comments, cords_tokens = 
        Array.init block.Length (fun line ->
            let x = block.[line]
            let comment, len = match PersistentVector.tryLast x with Some (r, TokComment c) -> Some (r, c), x.Length-1 | _ -> None, x.Length
            let tokens = Array.init len (fun i ->
                let r, x = x.[i] 
                {|row=line; col=i|}, (({| line=line; character=r.from |}, {| line=line; character=r.nearTo |}), x)
                )
            comment, tokens
            )
        |> Array.unzip
    let cords, tokens = Array.unzip (Array.concat cords_tokens)

    let semantic_updates = ResizeArray()
    let env : Env = {
        tokens_cords = cords; semantic_updates = semantic_updates
        comments = comments; tokens = tokens; i = ref 0; is_top_down = is_top_down
        }
    {|result=parse env; semantic_tokens=semantic_updates_apply block semantic_updates|}

let show_block_parsing_error line (l : ParserErrorsList) =
    l |> List.groupBy fst
    |> List.map (fun (k,v) -> 
        let k = add_line_to_range line k
        let v = List.map (snd >> show_parser_error) v
        k, process_error v
        )

let wdiff_parse' (is_top_down, s : ({|old_unparsed_block : LineTokens; result : ParseResult; semantic_tokens : LineTokens|} Block) list) 
        (unparsed_block : LineTokens Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    // Offset should be ignoring when memoizing the results of parsing.
    s |> List.iter (fun x -> dict.Add(x.block.old_unparsed_block,{|result=x.block.result;semantic_tokens=x.block.semantic_tokens|}))
    List.map (fun x -> 
        let r = Utils.memoize dict (parse_block is_top_down) x.block
        { block = {|r with old_unparsed_block=x.block|}; offset = x.offset }
        ) unparsed_block

type ParserState = {
    is_top_down : bool

    }