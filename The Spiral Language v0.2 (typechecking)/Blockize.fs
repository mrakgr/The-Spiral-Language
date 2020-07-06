module Spiral.Blockize
open Hopac
open Hopac.Infixes
open Hopac.Extensions
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

type Block = {block: LineToken [] []; offset: int}
let server () = Job.delay <| fun () ->
    let lines : LineToken [] ResizeArray = ResizeArray([[||]])

    /// Reads the comments up to a statement, and then reads the statement body. Leaves any errors for the parsing stage.
    let block_at i =
        let ar = ResizeArray()
        let rec loop_initial i =
            if i < lines.Count then
                let x = lines.[i]
                ar.Add x
                if 0 < x.Length then
                    let r,t = x.[i]
                    if r.from = 0 then
                        match t with
                        | TokComment _ -> loop_initial (i+1)
                        | _ -> loop_body (i+1)
                    else loop_initial (i+1) // This branch will be an error in the parsing stage.
                else loop_initial (i+1)
        and loop_body i =
            if i < lines.Count then
                let x = lines.[i]
                if 0 < x.Length then
                    let r,_ = x.[i]
                    if r.from <> 0 then ar.Add x; loop_body (i+1)
                else ar.Add x; loop_body (i+1)
        loop_initial i
        {block=ar.ToArray(); offset=i}

    let rec block_all i = if i < lines.Count then let x = block_at i in x :: block_all (i+x.block.Length) else []

    let mutable blocks : Block list = []

    let replace (from, near_to, toks : LineToken [] []) =
        lines.RemoveRange(from,near_to-from)
        lines.InsertRange(from,toks)

        blocks <-
            let rec loop blocks i =
                if i < lines.Count then
                    match blocks with
                    | x :: xs ->
                        // If the block is dirty, forget it.
                        if (from <= x.offset && x.offset < near_to) || (x.offset <= from && from < x.offset + Array.length x.block) then loop xs i
                        else 
                            // If the block is past the removal range, adjust its line offset.
                            let x = {x with offset=if near_to <= x.offset then x.offset - (near_to - from) + toks.Length else x.offset}
                            // The block can't be dirty here. Hence if the offsets are the same, so are the blocks. Take it.
                            if x.offset = i then x :: loop xs (i + Array.length x.block)
                            // Else if the block has been skipped over, forget it.
                            elif x.offset < i then loop xs i
                            // Else the block has been dirty filtered, recalculate it.
                            else let x = block_at i in x :: loop blocks (i + Array.length x.block)
                    | [] -> block_all i
                else []
            loop blocks 0
    ()
    
    //let req, res = Ch(), Ch()
    //let rec loop from =
    //    req >>= fun (from,_,_ as x) -> replace x
    
    