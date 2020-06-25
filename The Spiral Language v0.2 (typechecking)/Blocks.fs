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

let is_overlapping l r =
    let in_range (from',_) (from,near_to) = from <= from' && from' < near_to
    in_range l r || in_range r l // One of the starting points will always be in the range of the other if they are overlapping.

let remove (blocks : Block ResizeArray) r = 
    if fst r < snd r then
        let lines_to_keep = ResizeArray()
        let rec loop (from, i) blocks_to_remove =
            if i < blocks.Count then
                let x = blocks.[i]
                let near_to = from + x.Length
                let next x = loop (near_to, i+1) x
                if is_overlapping (from, near_to) r then 
                    let take from' near_to' = for i=max 0 (from'-from) to (min x.Length (near_to'-from))-1 do lines_to_keep.Add(x.[i])
                    take from (fst r)
                    take (snd r) near_to
                    match blocks_to_remove with 
                    | None -> Some(i,1) // Moves into the removal interval.
                    | Some(i,c) -> Some(i,c+1) // Is in the interval.
                    |> next // Go to next.
                else
                    match blocks_to_remove with
                    | None -> next blocks_to_remove // Has not encountered the interval. Go to next.
                    | Some _ -> blocks_to_remove // Moves out of the removal interval. Since there is nothing left to do stop.
            else blocks_to_remove
    
        match loop (0,0) None with
        | Some(i,c) ->
            blocks.RemoveRange(i,c)
            blocks.Insert(i,lines_to_keep.ToArray())
        | None ->
            failwith "The removal should be in range."
