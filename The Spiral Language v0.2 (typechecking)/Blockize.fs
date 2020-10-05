module Spiral.Blockize
open Hopac
open Hopac.Infixes
open Hopac.Extensions

open Spiral.Config
open Spiral.Tokenize

type Block = {block: LineToken [] []; offset: int}
type FileOpenRes = Block list * VSCError []
type FileChangeRes = Block list * VSCError []
type FileTokenAllRes = VSCTokenArray

type Req =
    | Put of string * IVar<FileOpenRes>
    | Modify of SpiEdit * IVar<FileChangeRes>
    | GetRange of VSCRange * IVar<VSCTokenArray>

open Spiral.BlockParsing
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
type ParserResult = { bundles : Bundle list; errors : VSCError [] }
let block_bundle (l : ParsedBlock list) =
    let (+.) a b = BlockParsingError.add_line_to_range a b
    let bundle = ResizeArray()
    let errors = ResizeArray()
    let temp = ResizeArray()
    let move_temp () = if 0 < temp.Count then bundle.Add(Seq.toList temp); temp.Clear()
    let rec init (l : ParsedBlock list) =
        match l with
        | x :: x' ->
            match x.parsed with
            | Ok (TopAnd(r,_)) -> errors.Add("Invalid `and` statement.", x.offset +. r); init x'
            | Ok (TopRecInl as a) -> temp.Add {offset=x.offset; statement=a}; recinl x'
            | Ok (TopNominalRec as a) -> temp.Add {offset=x.offset; statement=a}; rectype x'
            | Ok a -> temp.Add {offset=x.offset; statement=a}; move_temp(); init x'
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; init x'
        | [] -> move_temp()
    and recinl (l : ParsedBlock list) =
        match l with
        | x :: x' ->
            match x.parsed with
            | Ok (TopAnd(_, TopRecInl _ & a)) -> temp.Add {offset=x.offset; statement=a}; recinl x'
            | Ok (TopAnd(r, _)) -> errors.Add("inl/let recursive statements can only be followed by `and` inl/let statements.", x.offset +. r); recinl x'
            | Ok _ -> move_temp(); init l
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; recinl x'
        | [] -> move_temp()
    and rectype (l : ParsedBlock list) =
        match l with
        | x :: x' ->
            match x.parsed with
            | Ok (TopAnd(_, TopNominalRec & a)) -> temp.Add {offset=x.offset; statement=a}; rectype x'
            | Ok (TopAnd(r, _)) -> errors.Add("`union rec` can only be followed by `and union`.", x.offset +. r); rectype x'
            | Ok _ -> move_temp(); init l
            | Error er -> BlockParsingError.show_block_parsing_error x.offset er |> errors.AddRange; rectype x'
        | [] -> move_temp()
    init l
    {bundles=Seq.toList bundle; errors=errors.ToArray()}

let block_init is_top_down (block : LineToken [] []) =
    let comments, tokens = 
        block |> Array.mapi (fun line x ->
            let comment, len = match Array.tryLast x with Some (r, TokComment c) -> Some (r, c), x.Length-1 | _ -> None, x.Length
            let tokens = Array.init len (fun i ->
                let r, x = x.[i] 
                ({ line=line; character=r.from }, { line=line; character=r.nearTo }), x
                )
            comment, tokens
            )
        |> Array.unzip

    let env : BlockParsing.Env = 
        {comments = comments; tokens = Array.concat tokens; i = ref 0; 
        is_top_down = is_top_down; default_int=Int32T; default_float=Float64T}
    BlockParsing.parse env

let server_tokenizer (uri : string) = Job.delay <| fun () ->
    let lines : LineToken [] ResizeArray = ResizeArray([[||]])
    let mutable errors_tokenization = [||]
    let mutable blocks : Block list = []

    let replace edit =
        errors_tokenization <- Tokenize.replace lines errors_tokenization edit // Mutates the lines array
        blocks <- block_separate lines blocks edit
        blocks, errors_tokenization

    let req = Ch()
    let loop =
        Ch.take req >>= function
            | Put(text,res) -> replace {|from=0; nearTo=lines.Count; lines=Utils.lines text|} |> IVar.fill res
            | Modify(edits,res) -> replace edits |> IVar.fill res
            | GetRange((a,b),res) -> // It is assumed that a.character = 0 and b.character = length of the line
                let from, near_to = min (lines.Count-1) a.line, min lines.Count (b.line+1)
                vscode_tokens from (lines.GetRange(from,near_to-from |> max 0).ToArray()) |> IVar.fill res
    Job.foreverServer loop >>-. req

type ParserReq = {
    blocks : Block list
    res : ParserResult IVar
    }

let server_parser (uri : string) = Job.delay <| fun () ->
    let is_top_down = System.IO.Path.GetExtension(uri) = ".spi"
    let dict = System.Collections.Generic.Dictionary(HashIdentity.Reference)
    let parse (a : Block list) =
        let b = 
            List.map (fun x -> {
                parsed = Utils.memoize dict (block_init is_top_down) x.block
                offset = x.offset
                }) a
        dict.Clear(); List.iter2 (fun a b -> dict.Add(a.block,b.parsed)) a b
        block_bundle b

    let req = Ch()
    let rec waiting () = Ch.take req ^=> processing
    and processing (a : ParserReq) = waiting () <|> Alt.prepareJob (fun () -> IVar.fill a.res (parse a.blocks) >>- waiting)
        
    Job.server (waiting()) >>-. req

open Spiral.Infer
type TypecheckingReq = {
    bundles : Bundle list
    res : InferResult IVar list IVar
    }

let server_typechecking (uri : string) = Job.delay <| fun () ->
    let req = Ch ()

    let rec waiting data = req ^=> extracting data
    and extracting data req' = 
        waiting data <|> (IVar.read req' ^=> fun (req' : TypecheckingReq) -> 
            let rec loop = function // Does memoization by fetching previous computed values.
                | [], bundle -> List.map (fun _ -> IVar()) bundle
                | (a, ivar) :: a', (b :: b' as bundle) -> if a = b then ivar :: loop (a',b') else loop ([], bundle)
                | _, [] -> []
            let x = loop (data, req'.bundles)
            Hopac.start (IVar.fill req'.res x)
            let x = List.zip req'.bundles x
            processing Infer.default_env x x
            )
    and processing state data = function
        | [] -> waiting data
        | (x,res) :: x' ->
            waiting data <|> Alt.prepareFun (fun () -> 
                if res.Full then IVar.read res ^=> fun x -> processing x.top_env data x'
                else 
                    let x = bundle x |> infer state
                    Hopac.start (IVar.fill res x)
                    processing x.top_env data x'
                )

    Job.server (waiting []) >>-. req

let server_hover (uri : string) = Job.delay <| fun () ->
    let req_tc, req_hov = Ch (), Ch ()

    let block_at data (pos : Config.VSCPos) = 
        let rec loop = function // tryPick from the back
            | (offset,b) :: x' ->
                match loop x' with
                | ValueSome _ as x -> x
                | ValueNone -> if offset <= pos.line then ValueSome b else ValueNone
            | [] -> ValueNone
        loop data |> function ValueSome x -> x | ValueNone -> IVar()

    let hover_msg_at (pos : Config.VSCPos) ranges =
        ranges |> Array.tryPick (fun ((a,b) : Config.VSCRange, r : string) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            )

    let signal_none ret x = Option.iter ((|>) None) ret; x
    let rec tc ret = req_tc ^=> (signal_none ret >> extracting)
    and hov data ret = req_hov ^=> (signal_none ret >> processing data)
    and waiting data ret = tc ret <|> hov data ret
    and extracting req = tc None <|> (IVar.read req ^=> extracting')
    and extracting' (req : TypecheckingReq) =
        tc None 
        <|> (IVar.read req.res ^=> fun x -> waiting (List.map2 (fun (a : Bundle) b -> (List.head a).offset, b) req.bundles x) None)
    and processing data (pos, ret) =
        waiting data (Some ret)
        <|> (IVar.read (block_at data pos) ^=> fun x -> hover_msg_at pos x.hovers |> ret; waiting data None)

    Job.server (tc None) >>-. (req_tc, req_hov)