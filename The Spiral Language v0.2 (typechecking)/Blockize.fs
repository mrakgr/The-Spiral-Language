module Spiral.Blockize

open VSCTypes
open Spiral.Tokenize
open Spiral.BlockParsing

type Block = {block: LineToken [] []; offset: int}
type FileOpenRes = Block list * RString []
type FileChangeRes = Block list * RString []
type FileTokenAllRes = VSCTokenArray

type ParsedBlock = {parsed: Result<TopStatement, (Range * ParserErrors) list>; offset: int}

/// Reads the comments up to a statement, and then reads the statement body. Leaves any errors for the parsing stage.
let block_at (lines : LineToken [] ResizeArray) i =
    let ar = ResizeArray()
    let rec loop_initial i =
        if i < lines.Count then
            let x = lines.[i]
            ar.Add x
            if 0 < x.Length then
                let r,t = x.[0]
                if r.from = 0 then
                    match t with
                    | TokComment _ -> loop_initial (i+1)
                    | _ -> loop_body (i+1)
                else loop_initial (i+1) // This branch will be an error in the parsing stage unless the token is a comment.
            else loop_initial (i+1)
    and loop_body i =
        if i < lines.Count then
            let x = lines.[i]
            if 0 < x.Length then
                let r,_ = x.[0]
                if r.from <> 0 then ar.Add x; loop_body (i+1)
            else ar.Add x; loop_body (i+1)
    loop_initial i
    {block = ar.ToArray(); offset = i}

let rec block_all (lines : _ ResizeArray) i = 
    if i < lines.Count then 
        let x = block_at lines i
        x :: block_all lines (i+x.block.Length) else []

let block_separate (lines : LineToken [] ResizeArray) (blocks : Block list) (edit : SpiEdit) =
    // Lines added minus lines removed.
    let line_adjustment = edit.lines.Length - (edit.nearTo - edit.from)
    // The dirty block boundary needs to be more conservative when a separator is added in the first position of block.
    let dirty_from = let x = lines.[edit.from] in edit.from - (if Array.length x = 0 || 0 < (fst x.[0]).from then 1 else 0)
    let is_dirty (x : Block) = (dirty_from <= x.offset && x.offset < edit.nearTo) || (x.offset <= dirty_from && dirty_from < x.offset + Array.length x.block)
    let rec loop blocks i =
        if i < lines.Count then
            match blocks with
            | x :: xs ->
                // If the block is dirty, forget it.
                if is_dirty x then loop xs i else 
                    // If the block is past the removal range, adjust its line offset.
                    let x = {x with offset=if edit.nearTo <= x.offset then x.offset + line_adjustment else x.offset}
                    // The block can't be dirty here. Hence if the offsets are the same, so are the blocks. Take it.
                    if x.offset = i then x :: loop xs (i + Array.length x.block)
                    // Else if the block has been skipped over, forget it.
                    elif x.offset < i then loop xs i
                    // Else the block has been dirty filtered, recalculate it.
                    else let x = block_at lines i in x :: loop blocks (i + Array.length x.block)
            | [] -> block_all lines i
        else []
    loop blocks 0

open Spiral.TypecheckingUtils
let block_bundle (l : ParsedBlock list) =
    let (+.) a b = BlockParsingError.add_line_to_range a b
    let bundle = ResizeArray()
    let errors = ResizeArray<RString>()
    let temp = ResizeArray()
    let move_temp () = if 0 < temp.Count then bundle.Add(Seq.toList temp); temp.Clear()
    let rec init (l : ParsedBlock list) =
        match l with
        | x :: x' ->
            match x.parsed with
            | Ok (TopAnd(r,_)) -> errors.Add(x.offset +. r, "Invalid `and` statement."); init x'
            | Ok (TopRecInl _ as a) -> temp.Add {offset=x.offset; statement=a}; recinl x'
            | Ok (TopNominalRec _ as a) -> temp.Add {offset=x.offset; statement=a}; rectype x'
            | Ok a -> temp.Add {offset=x.offset; statement=a}; move_temp(); init x'
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; init x'
        | [] -> move_temp()
    and recinl (l : ParsedBlock list) =
        match l with
        | x :: x' ->
            match x.parsed with
            | Ok (TopAnd(_, TopRecInl _ & a)) -> temp.Add {offset=x.offset; statement=a}; recinl x'
            | Ok (TopAnd(r, _)) -> errors.Add(x.offset +. r, "inl/let recursive statements can only be followed by `and` inl/let statements."); recinl x'
            | Ok _ -> move_temp(); init l
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; recinl x'
        | [] -> move_temp()
    and rectype (l : ParsedBlock list) =
        match l with
        | x :: x' ->
            match x.parsed with
            | Ok (TopAnd(_, TopNominalRec _ & a)) -> temp.Add {offset=x.offset; statement=a}; rectype x'
            | Ok (TopAnd(r, _)) -> errors.Add(x.offset +. r, "`union rec` can only be followed by `and union`."); rectype x'
            | Ok _ -> move_temp(); init l
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; rectype x'
        | [] -> move_temp()
    init l
    Seq.toList bundle, errors.ToArray()

let block_init is_top_down (block : LineToken [] []) =
    let comments, tokens = 
        block |> Array.mapi (fun line x ->
            let comment, len = match Array.tryLast x with Some (r, TokComment c) -> Some (r, c), x.Length-1 | _ -> None, x.Length
            let tokens = Array.init len (fun i ->
                let r, x = x.[i] 
                ({| line=line; character=r.from |}, {| line=line; character=r.nearTo |}), x
                )
            comment, tokens
            )
        |> Array.unzip

    let env : BlockParsing.Env = {comments = comments; tokens = Array.concat tokens; i = ref 0; is_top_down = is_top_down}
    BlockParsing.parse env

