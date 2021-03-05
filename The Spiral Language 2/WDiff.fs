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
        if from = text.Length then Ok state else
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
    {result=parse env; semantic_tokens=semantic_updates_apply block semantic_updates}

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

let inline job_thunk_with f x = Job.thunk (fun () -> f x)
let inline promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let inline promise_thunk f = Hopac.memo (Job.thunk f)

type ParserState = {
    is_top_down : bool
    blocks : (LineTokens * ParsedBlock Promise Block) list
    }
let wdiff_parse_init is_top_down : ParserState = {is_top_down=is_top_down; blocks=[]}
let wdiff_parse (state : ParserState) (unparsed_blocks : LineTokens Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    // Offset should be ignoring when memoizing the results of parsing.
    List.iter dict.Add state.blocks
    let blocks = unparsed_blocks |> List.map (fun x -> 
        x.block, Utils.memoize dict (fun a -> {block=promise_thunk_with (parse_block state.is_top_down) a; offset=x.offset}) x.block
        )  
    {state with blocks = blocks }

type PackageId = int
type ModuleId = int
type TypecheckerState = {
    package_id : PackageId
    module_id : ModuleId
    top_env : TopEnv Promise
    results : (Bundle * InferResult * TopEnv) Stream
    bundle : BlockBundleState Stream
    }

let wdiff_typechecker_init (package_id, module_id, top_env) = {
    package_id = package_id
    module_id = module_id
    top_env = top_env
    results = Promise.Now.never()
    bundle = Promise.Now.never()
    }

let rec typecheck (package_id,module_id,env) = function
    | l :: ls ->
        let x = Infer.infer package_id module_id env l
        let adds = match x.top_env_additions with AOpen x | AInclude x -> x
        let env = Infer.union adds env
        Cons((l,x,env),promise_thunk_with (typecheck (package_id,module_id,env)) ls)
    | [] ->
        Nil

let wdiff_typechecker_input (state : TypecheckerState) bundle =
    let rec diff env (a,b) = 
        let tc () = typecheck (state.package_id,state.module_id,env) b
        if Promise.Now.isFulfilled a then
            match Promise.Now.get a,b with
            | Cons((b,_,env as x),next), b' :: bs when b = b' -> Cons(x,promise_thunk_with (diff env) (next,bs))
            | _ -> tc()
        else tc()

    let results = 
        state.top_env >>=* fun top_env ->
        bundle >>- fun l -> diff top_env (state.results,l)
    {state with results = results; bundle = bundle}

let wdiff_typechecker_state (state : TypecheckerState) (package_id,module_id,top_env) =
    if state.package_id = package_id && state.module_id = module_id && state.top_env = top_env then state else
    let results = 
        top_env >>=* fun top_env ->
        state.bundle >>- fun l -> typecheck (package_id,module_id,top_env) l
    {state with results = results; top_env = top_env; package_id = package_id; module_id = module_id}

type PackageFiles =
    | File of module_id: int * name: string option
    | Directory of dir_id: int * name: string * PackageFiles list

type PackageFilesFuns<'a,'state> =
    abstract member file : string option * 'state * 'a -> 'a * 'state
    abstract member union : 'state * 'state -> 'state
    abstract member in_module : string * 'state -> 'state

type PackageFilesState<'a,'state> = {
    init : 'state
    uids_file : ('a * 'state) []
    uids_directory : 'state []
    files : PackageFiles list
    result : 'state
    }

//let rec num_dirs s l = 
//    List.fold (fun s -> function
//        | Directory(uid,_,l) -> num_dirs (max s uid) l
//        | File _ -> s
//        ) s l

let package_files_diff (uids_file : ('a * 'b) [], uids_directory : 'b [], files) (num_dirs, uids, files') =
    let uids_file' = Array.zeroCreate (Array.length uids)
    let uids_directory' = Array.zeroCreate num_dirs
    let rec loop = function
        | File(uid,name), File(uid',name') when uid = uid' && name = name' && uids.[uid] = fst uids_file.[uid] -> uids_file'.[uid] <- uids_file.[uid]; true
        | Directory(uid,name,l), Directory(uid',name',l') when uid = uid' && name = name' && list (l,l') -> uids_directory'.[uid] <- uids_directory.[uid]; true
        | _ -> false
    and list = function
        | x :: xs, y :: ys -> loop (x,y) && list (xs,ys)
        | _ -> false
    list (files, files') |> ignore
    uids_file',uids_directory'

let wdiff_package_files (funs : PackageFilesFuns<'a,'state>) 
        (state : PackageFilesState<'a,'state >) (num_dirs,uids,files : PackageFiles list) =
    let uids_file, uids_directory = package_files_diff (state.uids_file,state.uids_directory,state.files) (num_dirs,uids,files)
    let memo (uids : _ []) uid f = 
        let x = uids.[uid]
        if isNull (box x) then let x = f() in uids.[uid] <- x; x
        else x
    let rec loop state = function
        | File(uid,name) -> memo uids_file uid (fun () -> funs.file(name,state,uids.[uid])) |> snd
        | Directory(uid,name,l) -> memo uids_directory uid (fun () -> funs.in_module(name,list state l))
    and list s l = 
        List.fold (fun (init,big) x -> 
            let small = loop big x
            funs.union(small,init), funs.union(small,big)
            ) (state.init, s) l |> fst
            
    {state with files=files; uids_file=uids_file; uids_directory=uids_directory; result=list state.init files}

let union_adds l =
    Stream.foldFromFun top_env_empty (fun big (_,x : InferResult,_) -> 
        match x.top_env_additions with
        | AOpen _ -> big
        | AInclude small -> union small big
        ) l
    |> Hopac.memo

let wdiff_package_files_infer_funs = {new PackageFilesFuns<TypecheckerState,PackageId * ModuleId * TopEnv Promise> with
    member t.file(name,(package_id,module_id,_ as state),c) = 
        let x = wdiff_typechecker_state c state
        let env = union_adds x.results
        let env = match name with None -> env | Some name -> env >>-* in_module name
        x,(package_id, module_id+1, env)
    member t.union((package_id,module_id,small),(_,_,big)) = package_id,module_id,small >>=* fun small -> big >>-* union small
    member t.in_module(name,(package_id,module_id,small)) = package_id,module_id,small >>-* in_module name
    }

type PackageEnv = Map<PackageId,PackageFilesState<TypecheckerState,PackageId * ModuleId * TopEnv Promise>>