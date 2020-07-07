module Spiral.Blockize
open Hopac
open Hopac.Infixes
open Hopac.Extensions

open Config
open Tokenize

type FileOpenRes = VSCError []
type FileChangeRes = VSCError []
type FileTokenAllRes = VSCTokenArray

type Req =
    | Put of string * IVar<FileOpenRes>
    | Modify of SpiEdit [] * IVar<FileChangeRes>
    | GetRange of VSCRange * IVar<VSCTokenArray>

type Block = {block: LineToken [] []; offset: int}

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
    {block=ar.ToArray(); offset=i}

let rec block_all (lines : _ ResizeArray) i = if i < lines.Count then let x = block_at lines i in x :: block_all lines (i+x.block.Length) else []

let blockize (lines : LineToken [] ResizeArray) (blocks : Block list) (edit : SpiEdit) =
    /// Lines added minus lines removed.
    let line_adjustment = edit.lines.Length - (edit.nearTo - edit.from)
    let dirty_from = // The dirty block boundary needs to be more conservative when a separator is added in the first position of block.
        let from = edit.from
        let x = lines.[from] 
        from - (if Array.length x = 0 || 0 < (fst x.[0]).from then 1 else 0)
    let is_dirty x = (dirty_from <= x.offset && x.offset < edit.nearTo) || (x.offset <= dirty_from && dirty_from < x.offset + Array.length x.block)
    let rec loop blocks i =
        if i < lines.Count then
            match blocks with
            | x :: xs ->
                // If the block is dirty, forget it.
                if is_dirty x then loop xs i
                else 
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

let server = Job.delay <| fun () ->
    let lines : LineToken [] ResizeArray = ResizeArray([[||]])
    let mutable errors = [||]
    let mutable blocks : Block list = []

    let replace edit =
        errors <- Tokenize.replace lines errors edit // Mutates the lines array
        blocks <- blockize lines blocks edit

    let req = Ch()
    let loop =
        Ch.take req >>= function
            | Put(text,res) -> replace {|from=0; nearTo=lines.Count; lines=Utils.lines text|}; IVar.fill res errors
            | Modify(edits,res) -> Array.iter replace edits; IVar.fill res errors
            | GetRange((a,b),res) -> // It is assumed that a.character = 0 and b.character = length of the line
                let from, near_to = a.line, b.line+1
                vscode_tokens from (lines.GetRange(from,near_to-from).ToArray()) |> IVar.fill res
    Job.foreverServer loop >>-. req
