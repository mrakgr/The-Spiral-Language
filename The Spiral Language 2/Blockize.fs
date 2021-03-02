module Spiral.Blockize

open FSharpx.Collections
open VSCTypes
open Spiral.Tokenize
open Spiral.BlockParsing

type LineTokens = LineToken PersistentVector PersistentVector
type Block = {block: LineTokens; offset: int}
type FileOpenRes = Block list * RString []
type FileChangeRes = Block list * RString []
type FileTokenAllRes = VSCTokenArray

/// Reads the comments up to a statement, and then reads the statement body. Leaves any errors for the parsing stage.
let block_at (lines : LineTokens) i =
    let mutable block = PersistentVector.empty
    let add x = block <- PersistentVector.conj x block
    let rec loop_initial i =
        if i < lines.Length then
            let x = lines.[i]
            add x
            if 0 < x.Length then
                let r,t = x.[0]
                if r.from = 0 then
                    match t with
                    | TokComment _ -> loop_initial (i+1)
                    | _ -> loop_body (i+1)
                else loop_initial (i+1) // This branch will be an error in the parsing stage unless the token is a comment.
            else loop_initial (i+1)
    and loop_body i =
        if i < lines.Length then
            let x = lines.[i]
            if 0 < x.Length then
                let r,_ = x.[0]
                if r.from <> 0 then add x; loop_body (i+1)
            else add x; loop_body (i+1)
    loop_initial i
    {block = block; offset = i}

// Parses all the blocks.
let rec block_all lines i = 
    if i < PersistentVector.length lines then 
        let x = block_at lines i
        x :: block_all lines (i+x.block.Length) else []

// Parses all the blocks with diffing. Only parses those blocks which are dirty based of the edit range. Preserves ref equality and saves work.
// Without considering ref preservation, it is functionally equivalent to just call `block_all` on just `lines`.
// This function is difficult to read as it is several operations fused into one loop.
let block_all_wdiff (lines : LineTokens) (blocks : Block list) (edit : SpiEdit) =
    // Lines added minus lines removed.
    let line_adjustment = edit.lines.Length - (edit.nearTo - edit.from)
    // The dirty block boundary needs to be more conservative when a separator is added in the first position of block.
    // Imagine adding a newline right on a block start. This would extend the previous block, but the naive check would not react to it.
    // The same goes for pasting an indented piece of text.
    let dirty_from = let x = lines.[edit.from] in edit.from - (if x.Length = 0 || 0 < (fst x.[0]).from then 1 else 0)
    let is_dirty (x : Block) = (dirty_from <= x.offset && x.offset < edit.nearTo) || (x.offset <= dirty_from && dirty_from < x.offset + x.block.Length)
    let rec loop blocks i =
        if i < lines.Length then
            match blocks with
            | x :: xs ->
                // If the block is dirty, forget it.
                if is_dirty x then loop xs i else 
                    // If the block is past the removal range, adjust its line offset.
                    let x = {x with offset=if edit.nearTo <= x.offset then x.offset + line_adjustment else x.offset}
                    // The block can't be dirty here. Hence if the offsets are the same, so are the blocks. Take it.
                    if x.offset = i then x :: loop xs (i + x.block.Length)
                    // Else if the block has been skipped over, forget it.
                    elif x.offset < i then loop xs i
                    // Else the block has been dirty filtered, recalculate it.
                    else let x = block_at lines i in x :: loop blocks (i + x.block.Length)
            | [] -> block_all lines i
        else []
    loop blocks 0

open Spiral.TypecheckingUtils
type ParsedBlock = {parsed: Result<TopStatement, (VSCRange * ParserErrors) list> * LineTokens; offset: int}
let block_bundle (l : (_ * ParsedBlock) list) =
    let (+.) a b = Tokenize.add_line_to_range a b
    let bundle = ResizeArray()
    let errors = ResizeArray<RString>()
    let temp = ResizeArray()
    let move_temp () = if 0 < temp.Count then bundle.Add(Seq.toList temp); temp.Clear()
    let rec init (l : (_ * ParsedBlock) list) =
        match l with
        | (_,x) :: x' ->
            match fst x.parsed with
            | Ok (TopAnd(r,_)) -> errors.Add(x.offset +. r, "Invalid `and` statement."); init x'
            | Ok (TopRecInl _ as a) -> temp.Add {offset=x.offset; statement=a}; recinl x'
            | Ok (TopNominalRec _ as a) -> temp.Add {offset=x.offset; statement=a}; rectype x'
            | Ok a -> temp.Add {offset=x.offset; statement=a}; move_temp(); init x'
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; init x'
        | [] -> move_temp()
    and recinl (l : (_ * ParsedBlock) list) =
        match l with
        | (_,x) :: x' ->
            match fst x.parsed with
            | Ok (TopAnd(_, TopRecInl _ & a)) -> temp.Add {offset=x.offset; statement=a}; recinl x'
            | Ok (TopAnd(r, _)) -> errors.Add(x.offset +. r, "inl/let recursive statements can only be followed by `and` inl/let statements."); recinl x'
            | Ok _ -> move_temp(); init l
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; recinl x'
        | [] -> move_temp()
    and rectype (l : (_ * ParsedBlock) list) =
        match l with
        | (_,x) :: x' ->
            match fst x.parsed with
            | Ok (TopAnd(_, TopNominalRec _ & a)) -> temp.Add {offset=x.offset; statement=a}; rectype x'
            | Ok (TopAnd(r, _)) -> errors.Add(x.offset +. r, "`union rec` can only be followed by `and union`."); rectype x'
            | Ok _ -> move_temp(); init l
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; rectype x'
        | [] -> move_temp()
    init l

    let line_tokens = List.fold (fun s (_,x) -> PersistentVector.append s (snd x.parsed)) PersistentVector.empty l
    line_tokens, Seq.toList bundle, Seq.toList errors

let semantic_updates_apply (block : LineTokens) updates =
    Seq.fold (fun block (c : VectorCord,l) -> 
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

let block_init is_top_down (block : LineTokens) =
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
    let env : BlockParsing.Env = {
        tokens_cords = cords; semantic_updates = semantic_updates
        comments = comments; tokens = tokens; i = ref 0; is_top_down = is_top_down
        }
    BlockParsing.parse env, semantic_updates_apply block semantic_updates