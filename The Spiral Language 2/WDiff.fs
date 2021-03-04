module Spiral.WDiff

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral
open Spiral.Tokenize
open Spiral.BlockSplitting
open Spiral.BlockBundling
open Spiral.Infer

type SpiEdit = {|from: int; nearTo: int; lines: string []|}
type TokReq =
    | DocumentAll of string []
    | DocumentEdit of SpiEdit

let process_errors line (ers : LineTokenErrors list) : RString list =
    ers |> List.mapi (fun i l -> 
        let i = line + i
        l |> List.map (fun (r,x) -> x, ({|line=i; character=r.from|}, {|line=i; character=r.nearTo|}))
        )
    |> List.concat
    |> List.groupBy snd
    |> List.map (fun (k,v) -> k, process_error (List.map fst v))

/// Replaces the token lines and updates the errors given the edit.
let tokenize_replace (lines : _ PersistentVector PersistentVector, errors : _ list) (edit : SpiEdit) =
    let toks, ers = Array.map tokenize edit.lines |> Array.unzip
    let lines = PersistentVector.replace edit.from edit.nearTo toks lines
    let errors = 
        let adj = edit.lines.Length - (edit.nearTo - edit.from)
        errors |> List.choose (fun ((a : VSCPos,b),c as x) -> 
            if edit.from <= a.line && a.line < edit.nearTo then None
            elif edit.nearTo <= a.line && adj <> 0 then Some (add_line_to_range adj (a,b),c)
            else Some x
            )
    let errors = List.append errors (process_errors edit.from (Array.toList ers))
    lines, errors

type TokenizerState = {
    lines_text : string PersistentVector
    lines_token : (LineParsers.Range * SpiralToken) PersistentVector PersistentVector
    blocks : LineTokens Block list
    errors : RString list
    }

let wdiff_tokenizer_init = { lines_text = PersistentVector.empty; lines_token = PersistentVector.empty; blocks = []; errors = [] }

/// Immutably updates the state based on the request. Does diffing to make the operation efficient.
/// It is possible for the server to go out of sync, in which case an error is returned.
let wdiff_tokenizer (state : TokenizerState) req = 
    let replace (edit : SpiEdit) =
        if edit.nearTo <= state.lines_text.Length then
            let lines_text = PersistentVector.replace edit.from edit.nearTo edit.lines state.lines_text
            let lines_token, errors = tokenize_replace (state.lines_token, state.errors) edit
            let blocks = wdiff_block_all state.blocks (lines_token, edit.lines.Length, edit.from, edit.nearTo)
            Ok {lines_text=lines_text; lines_token=lines_token; errors=errors; blocks=blocks}
        else 
            Error "The edit is out of bounds and cannot be applied. The language server and the editor are out of sync. Try reopening the file being edited."

    match req with
    | DocumentAll text ->
        let text' = state.lines_text |> Seq.toArray
        let rec loop (index,text : string [] as x) i = if i < min text.Length state.lines_text.Length && index text i = index text' i then loop x (i+1) else i
        let from = loop ((fun text i -> text.[i]),text) 0
        let text = text.[from..]
        let fromRev = loop ((fun text i -> text.[text.Length-1-i]),text) 0
        replace {|from=from; nearTo=text'.Length-fromRev; lines=text.[..text.Length-1-fromRev]|}
    | DocumentEdit edit -> replace edit

open BlockParsing
let semantic_updates_apply (block : LineTokens) updates =
    Seq.fold (fun block (c : VectorCord, l) -> 
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

let parse_block is_top_down (block : LineTokens) =
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
    let env : Env = {
        tokens_cords = cords; semantic_updates = semantic_updates
        comments = comments; tokens = tokens; i = ref 0; is_top_down = is_top_down
        }
    {|result=parse env; semantic_tokens=semantic_updates_apply block semantic_updates|}

type ParserState = {
    is_top_down : bool
    blocks : {|old_unparsed_block : LineTokens; result : ParseResult; semantic_tokens : LineTokens; offset : int |} list
    }
let wdiff_parse'_init is_top_down : ParserState = {is_top_down=is_top_down; blocks=[]}
let wdiff_parse' (state : ParserState) (unparsed_blocks : LineTokens Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    // Offset should be ignoring when memoizing the results of parsing.
    state.blocks |> List.iter (fun x -> dict.Add(x.old_unparsed_block,{|result=x.result;semantic_tokens=x.semantic_tokens|}))
    let blocks = unparsed_blocks |> List.map (fun x -> 
        let r = Utils.memoize dict (parse_block state.is_top_down) x.block
        {|r with old_unparsed_block=x.block; offset = x.offset|}
        )  
    {state with blocks = blocks }

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

let inline job_thunk_with f x = Job.thunk (fun () -> f x)
let inline promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let inline promise_thunk f = Hopac.memo (Job.thunk f)

type SP<'a> = {s :'a; p : 'a Promise}
let sp (x : _ SP) = if Promise.Now.isFulfilled x.p then Promise.Now.get x.p else x.s

let inline wdiff_fold f s x =
    let s = s()
    let p = promise_thunk_with (f s) x
    p, fun () -> if Promise.Now.isFulfilled p then Promise.Now.get p else s

let inline wdiff_mapFold f s x =
    let s = s()
    let p = promise_thunk_with (f s) x
    p >>-* fst, fun () -> if Promise.Now.isFulfilled p then snd (Promise.Now.get p) else s

let wdiff_parse_init is_top_down () = wdiff_parse'_init is_top_down
let wdiff_parse state unparsed_blocks = wdiff_fold wdiff_parse' state unparsed_blocks

let wdiff_block_bundle_init () = wdiff_block_bundle'_init
let wdiff_block_bundle state parsed_block_list = wdiff_mapFold wdiff_block_bundle' state parsed_block_list

type TypecheckerState = {
    package_id : int
    module_id : int
    top_env : TopEnv Promise
    results : (Bundle * InferResult * TopEnv) Stream
    }

let wdiff_typechecker (state : TypecheckerState) l =
    let rec loop env = function
        | l :: ls ->
            let x = Infer.infer state.package_id state.module_id env l
            let adds = match x.top_env_additions with AOpen x | AInclude x -> x
            let env = Infer.union adds env
            Cons((l,x,env),promise_thunk_with (loop env) ls)
        | [] ->
            Nil

    let rec diff env = function
        | Cons((b,_,env as x),next), b' :: bs when b = b' -> 
            if Promise.Now.isFulfilled next then Cons(x,promise_thunk_with (diff env) (Promise.Now.get next,bs))
            else Cons(x,promise_thunk_with (loop env) bs)
        | _,bs -> loop env bs

    let results = 
        state.top_env >>=* fun top_env ->
        state.results >>= fun r ->
        l >>- fun l -> diff top_env (r,l)
    {state with results = results}

type PackageFiles<'a> =
    | File of uid: int * name: string option * 'a
    | Directory of uid: int * name: string * PackageFiles<'a> list

type PackageFilesInnerState<'state> = {
    package_id : int
    module_id : int
    top_env : 'state
    }

type PackageFilesFuns<'a1,'a2,'state> =
    abstract member file : string option * 'state * 'a1 -> 'a2 * 'state
    abstract member union : 'state * 'state -> 'state
    abstract member in_module : string * 'state -> 'state

type PackageFilesState<'a1,'state> = {
    package_id : int
    top_env_init : 'state
    uids : obj []
    files : 'a1 PackageFiles list
    }

let package_files_diff (state : _ [], files) (uids, files') =
    let state' = Array.zeroCreate uids
    let inline ok uid = state'.[uid] <- state.[uid]; true
    let rec loop = function
        | File(uid,name,x), File(uid',name',x') when uid = uid' && name = name' && x = x' -> ok uid
        | Directory(uid,name,l), Directory(uid',name',l') when uid = uid' && name = name' && list (l,l') -> ok uid
        | _ -> false
    and list = function
        | x :: xs, y :: ys -> loop (x,y) && list (xs,ys)
        | _ -> false
    list (files, files') |> ignore
    state'

let wdiff_package_files (funs : PackageFilesFuns<'a1,'a2,'state PackageFilesInnerState>) (state : PackageFilesState<'a1,'state >) (uids,l : 'a1 PackageFiles list) =
    let uids = package_files_diff (state.uids,state.files) (uids,l)
    let memo uid f =
        match uids.[uid] with
        | null -> let x = f() in uids.[uid] <- x :> obj; x
        | x -> x :?> _
    let rec loop (state : PackageFilesInnerState<'state>) = function
        | File(uid,name,x) -> memo uid <| fun () ->
            let a,state = funs.file(name,state,x)
            File(uid,name,a),state
        | Directory(uid,name,l) -> memo uid <| fun () ->
            let l,state = list state l
            let state = funs.in_module(name,state)
            Directory(uid,name,l),state
    and list state l =
        List.mapFold (fun big x ->
            let x,small = loop big x
            x,funs.union(small,big)
            ) state l
            
    let _,s = list { package_id = state.package_id; module_id = 0; top_env = state.top_env_init } l
    s.top_env, {state with files=l; uids=uids}