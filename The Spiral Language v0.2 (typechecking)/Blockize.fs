module Spiral.Blockize
open Tokenize

/// Groups the comments with the statement following them.
let blocks (ar : LineToken ResizeArray) : Result<LineToken [] [], int * LineToken> =
    let indent_init = 0
    let blocks = ResizeArray()
    let blocks_add (b : _ ResizeArray) = blocks.Add(b.ToArray())
    let rec loop_initial (b : _ ResizeArray) i =
        if i < ar.Count then
            let r,t as x = ar.[i]
            if r.from = indent_init then
                match t with
                | TokComment _ -> b.Add x; loop_initial b (i+1)
                | _ -> b.Add x; loop_body b (i+1)
            else Error(i,x)
        else blocks_add b; Ok(blocks.ToArray())
    and loop_body (b : _ ResizeArray) i =
        if i < ar.Count then
            let r,_ as x = ar.[i]
            if r.from = indent_init then blocks_add b; loop_initial (ResizeArray()) i
            else b.Add x; loop_body b (i+1)
        else blocks_add b; Ok(blocks.ToArray())
    loop_initial (ResizeArray()) 0

    