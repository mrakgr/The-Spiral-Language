module Blocks

type Line = Separator | Text of string
type Block = string []

let lines_to_blocks (lines : Line []) : Block [] =
    let blocks = ResizeArray()
    let block = ResizeArray()
    let blocks_add () = blocks.Add(block.ToArray()); block.Clear()
    lines |> Array.iter (function Separator -> blocks_add() | Text t -> block.Add(t))
    blocks_add()
    blocks.ToArray()

let insert_block (block : Block) pos (x : Block []) =
    if Array.isEmpty x then [|block|] else
    let l,r = Array.splitAt pos block
    let x = Array.copy x
    x.[0] <- Array.append l x.[0]
    let last = x.Length-1
    x.[last] <- Array.append x.[last] r
    x

let insert (blocks : Block ResizeArray) (pos : int) (lines : Line []) =
    let rec loop pos i =
        let l = blocks.[i].Length
        if pos <= l then
            blocks.RemoveAt(i)
            blocks.AddRange(insert_block blocks.[i] pos (lines_to_blocks lines))
        else loop (pos-l) (i+1)
    loop pos 0