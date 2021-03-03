module Spiral.BlockSplitting

open FSharpx.Collections
open VSCTypes
open Spiral.Tokenize

type LineTokens = LineToken PersistentVector PersistentVector
type Block<'a> = {block: 'a; offset: int}

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
let wdiff_block_all (blocks : LineTokens Block list) (lines : LineTokens, lines_added, from, nearTo) =
    // Lines added minus lines removed.
    let line_adjustment = lines_added - (nearTo - from)
    // The dirty block boundary needs to be more conservative when a separator is added in the first position of block.
    // Imagine adding a newline right on a block start. This would extend the previous block, but the naive check would not react to it.
    // The same goes for pasting an indented piece of text.
    let dirty_from = let x = lines.[from] in from - (if x.Length = 0 || 0 < (fst x.[0]).from then 1 else 0)
    let is_dirty (x : LineTokens Block) = (dirty_from <= x.offset && x.offset < nearTo) || (x.offset <= dirty_from && dirty_from < x.offset + x.block.Length)
    let rec loop blocks i =
        if i < lines.Length then
            match blocks with
            | x :: xs ->
                // If the block is dirty, forget it.
                if is_dirty x then loop xs i else 
                    // If the block is past the removal range, adjust its line offset.
                    let x = {x with offset=if nearTo <= x.offset then x.offset + line_adjustment else x.offset}
                    // The block can't be dirty here. Hence if the offsets are the same, so are the blocks. Take it.
                    if x.offset = i then x :: loop xs (i + x.block.Length)
                    // Else if the block has been skipped over, forget it.
                    elif x.offset < i then loop xs i
                    // Else the block has been dirty filtered, recalculate it.
                    else let x = block_at lines i in x :: loop blocks (i + x.block.Length)
            | [] -> block_all lines i
        else []
    loop blocks 0
