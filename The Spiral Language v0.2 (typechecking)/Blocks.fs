module Blocks

type Lang =
    | Separator
    | Line of string
type File = Lang ResizeArray

type Block = string []
type FileBlocks = Block ResizeArray

let insert_block (block : Block) pos (x : Block []) =
    assert (pos <= block.Length)
    let l,r = Array.splitAt pos block

let insert (blocks : FileBlocks) (pos : int) (lines : Lang []) =
    let rec find c i =
        if i < blocks.Count then
            let c' = c + blocks.[i].Length
            if pos <= c' then failwith ""
            else find c' (i+1)
        else failwith "Can't insert out of bounds."
    ()