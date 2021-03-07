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
    lines_token : LineTokens
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

let wdiff_parse_init is_top_down : ParserState = {is_top_down=is_top_down; blocks=[]}
let wdiff_parse (state : ParserState) (unparsed_blocks : LineTokens Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    // Offset should be ignoring when memoizing the results of parsing.
    List.iter dict.Add state.blocks
    let blocks = unparsed_blocks |> List.map (fun x -> 
        x.block, Utils.memoize dict (fun a -> {block=promise_thunk_with (parse_block state.is_top_down) a; offset=x.offset}) x.block
        )  
    {state with blocks = blocks }

type ModuleState = { tokenizer : TokenizerState; bundler : BlockBundleState; parser : ParserState }
let wdiff_module (state : ModuleState) x =
    wdiff_tokenizer state.tokenizer x |> Result.map (fun tokenizer ->
        let parser = wdiff_parse state.parser tokenizer.blocks
        let bundler = wdiff_block_bundle state.bundler parser
        {tokenizer=tokenizer; parser=parser; bundler=bundler}
        )

type PackageId = int
type ModuleId = int
type [<ReferenceEquality>] TypecheckerState = {
    package_id : PackageId
    module_id : ModuleId
    top_env : TopEnv Promise
    results : (Bundle * InferResult * TopEnv) Stream
    bundle : BlockBundleState
    }

let wdiff_typechecker_init = {
    package_id = -1
    module_id = -1
    top_env = Promise.Now.never()
    results = Promise.Now.never()
    bundle = Promise.Now.never()
    }

let rec typecheck (package_id,module_id,env) = function
    | Cons((_,{bundle=bundle} : BlockBundleValue), ls) ->
        let x = Infer.infer package_id module_id env bundle
        let adds = match x.top_env_additions with AOpen x | AInclude x -> x
        let env = Infer.union adds env
        Cons((bundle,x,env),ls >>-* typecheck (package_id,module_id,env))
    | Nil ->
        Nil

let wdiff_typechecker_update_input (state : TypecheckerState) (bundle : BlockBundleState) =
    let rec diff env (a,b : BlockBundleState) = 
        b >>-* fun b ->
        let tc () = typecheck (state.package_id,state.module_id,env) b
        if Promise.Now.isFulfilled a then
            match Promise.Now.get a,b with
            | Cons((b,_,env as x),next), Cons((_,b'),bs) when b = b'.bundle -> Cons(x,diff env (next,bs))
            | _ -> tc()
        else tc()

    let results = 
        state.top_env >>=* fun top_env ->
        diff top_env (state.results,bundle)
    {state with results = results; bundle = bundle}

let wdiff_typechecker_update_state (state : TypecheckerState) (package_id,module_id,top_env) =
    if state.package_id = package_id && state.module_id = module_id && state.top_env = top_env then state else
    let results = 
        top_env >>=* fun top_env ->
        state.bundle >>- fun l -> typecheck (package_id,module_id,top_env) l
    {state with results = results; top_env = top_env; package_id = package_id; module_id = module_id}

type PackageFilesTree =
    | File of module_id: int * path : string * name: string option
    | Directory of dir_id: int * path : string * name: string * PackageFilesTree list

type PackageFiles = { tree : PackageFilesTree list; num_dirs : int; num_modules : int }

type ProjFilesFuns<'a,'state> =
    abstract member file : string option * 'state * 'a -> 'a * 'state
    abstract member union : 'state * 'state -> 'state
    abstract member in_module : string * 'state -> 'state
    abstract member init : 'state

type ProjFilesState<'a,'state> = {
    init : 'state
    uids_file : ('a * 'state) []
    uids_directory : 'state []
    files : PackageFiles
    result : 'state
    }

let proj_files_diff (uids_file : ('a * 'b) [], uids_directory : 'b [], files) (uids, files') =
    let uids_file' = Array.zeroCreate (Array.length uids)
    let uids_directory' = Array.zeroCreate files'.num_dirs
    let rec loop = function
        | File(uid,path,name), File(uid',path',name') when uid = uid' && name = name' && path = path' && uids.[uid] = fst uids_file.[uid] -> 
            uids_file'.[uid] <- uids_file.[uid]; true
        | Directory(uid,path,name,l), Directory(uid',path',name',l') when uid = uid' && name = name' && path = path' && list (l,l') -> 
            uids_directory'.[uid] <- uids_directory.[uid]; true
        | _ -> false
    and list = function
        | x :: xs, y :: ys -> loop (x,y) && list (xs,ys)
        | _ -> false
    list (files.tree, files'.tree) |> ignore
    uids_file',uids_directory'

let proj_files (funs : ProjFilesFuns<'a,'state>) uids_file uids_directory uids s l =
    let inline memo (uids : _ []) uid f = 
        let x = uids.[uid]
        if isNull (box x) then let x = f() in uids.[uid] <- x; x
        else x
    let rec loop state = function
        | File(uid,_,name) -> memo uids_file uid (fun () -> funs.file(name,state,Array.get uids uid)) |> snd
        | Directory(uid,_,name,l) -> memo uids_directory uid (fun () -> funs.in_module(name,list state l))
    and list s l = 
        List.fold (fun (init,big) x -> 
            let small = loop big x
            funs.union(small,init), funs.union(small,big)
            ) (funs.init, s) l |> fst
    list s l.tree

let wdiff_proj_files_init (funs : ProjFilesFuns<'a,'state>) = {files={tree=[]; num_dirs=0; num_modules=0}; init=funs.init; uids_file=[||]; uids_directory=[||]; result=funs.init}

let wdiff_proj_files_update_files (funs : ProjFilesFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (uids,files : PackageFiles) =
    let uids_file, uids_directory = proj_files_diff (state.uids_file,state.uids_directory,state.files) (uids,files)
    {state with files=files; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids state.init files}

let wdiff_proj_files_update_packages (funs : ProjFilesFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (init : 'state) =
    if state.init = init then state else
    let uids_file, uids_directory = Array.zeroCreate state.uids_file.Length, Array.zeroCreate state.uids_directory.Length
    let uids = Array.map fst state.uids_file
    {state with init=init; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids init state.files}

let wdiff_proj_files (funs : ProjFilesFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (init,uids,files) =
    let state = wdiff_proj_files_update_packages funs state init
    wdiff_proj_files_update_files funs state (uids,files)

let typechecker_results_summary l =
    Stream.foldFun (fun (has_error,big) (_,x : InferResult,_) -> 
        has_error || List.isEmpty x.errors = false,
        match x.top_env_additions with 
        | AOpen _ -> big 
        | AInclude small -> union small big
        ) (false,top_env_empty) l
    |> Hopac.memo

type [<ReferenceEquality>] TypecheckerStatePropagated = {
    package_id : PackageId
    module_id : ModuleId
    has_error : bool Promise
    env : TopEnv Promise
    }

let wdiff_proj_files_infer_funs = {new ProjFilesFuns<TypecheckerState,TypecheckerStatePropagated> with
    member _.file(name,state,tc) = 
        let x = wdiff_typechecker_update_state tc (state.package_id,state.module_id,state.env)
        let summary = typechecker_results_summary x.results
        let has_error = summary >>=* fun (a,_) -> state.has_error >>- fun b -> a || b
        let env = summary >>-* fun (_,env) -> match name with None -> env | Some name -> in_module name env
        x,{state with module_id=state.module_id+1; env=env; has_error=has_error}
    member _.union(small,big) = {small with env = small.env >>=* fun small -> big.env >>- union small}
    member _.in_module(name,small) = {small with env = small.env >>-* in_module name}
    member _.init = {package_id= -1; module_id= -1; env=Promise.Now.withValue top_env_empty; has_error=Promise.Now.withValue false}
    }

type PackageEnv = {
    nominals_aux : Map<PackageId,Map<GlobalId, {|name : string; kind : TT|}>>
    nominals : Map<PackageId,Map<GlobalId, {|vars : Var list; body : T|}>>
    prototypes_instances : Map<PackageId,Map<GlobalId * GlobalId, Constraint Set list>>
    prototypes : Map<PackageId,Map<GlobalId, {|name : string; signature: T|}>>
    ty : Map<string,T>
    term : Map<string,T>
    constraints : Map<string,ConstraintOrModule>
    }

let union small big = {
    nominals_aux = Map.foldBack Map.add small.nominals_aux big.nominals_aux
    nominals = Map.foldBack Map.add small.nominals big.nominals
    prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
    prototypes = Map.foldBack Map.add small.prototypes big.prototypes
    ty = Map.foldBack Map.add small.ty big.ty
    term = Map.foldBack Map.add small.term big.term
    constraints = Map.foldBack Map.add small.constraints big.constraints
    }

let in_module m (a : PackageEnv) =
    {a with 
        ty = Map.add m (TyModule a.ty) Map.empty
        term = Map.add m (TyModule a.term) Map.empty
        constraints = Map.add m (M a.constraints) Map.empty
        }

let package_to_file (x : PackageEnv) = {
    nominals_next_tag = 0
    nominals_aux = Map.foldBack (fun _ -> Map.foldBack Map.add) x.nominals_aux Map.empty
    nominals = Map.foldBack (fun _ -> Map.foldBack Map.add) x.nominals Map.empty
    prototypes_next_tag = 0
    prototypes_instances = Map.foldBack (fun _ -> Map.foldBack Map.add) x.prototypes_instances Map.empty
    prototypes = Map.foldBack (fun _ -> Map.foldBack Map.add) x.prototypes Map.empty
    ty = x.ty
    term = x.term
    constraints = x.constraints
    }

let add_file_to_package package_id (small : TopEnv) (big : PackageEnv): PackageEnv = {
    nominals_aux = Map.add package_id small.nominals_aux big.nominals_aux
    nominals = Map.add package_id small.nominals big.nominals
    prototypes_instances = Map.add package_id small.prototypes_instances big.prototypes_instances
    prototypes = Map.add package_id small.prototypes big.prototypes
    ty = small.ty
    term = small.term
    constraints = small.constraints
    }

let package_env_empty = {
    nominals_aux = Map.empty
    nominals = Map.empty
    prototypes_instances = Map.empty
    prototypes = Map.empty
    ty = Map.empty
    term = Map.empty
    constraints = Map.empty
    }

let package_env_default = {package_env_empty with ty = top_env_default.ty; term = top_env_default.term; constraints = top_env_default.constraints}

type ProjPackagesState<'a> = {
    package_id : PackageId
    packages : (string * 'a) list
    result : 'a
    }
type ProjState<'a,'b,'state> = {
    packages : 'state ProjPackagesState
    files : ProjFilesState<'a,'b>
    result : 'state
    }
type [<ReferenceEquality>] TypecheckerStateTop = {
    has_error : bool Promise
    env : PackageEnv Promise
    }
type ProjStateTC = ProjState<TypecheckerState,TypecheckerStatePropagated,TypecheckerStateTop>
type ProjEnvTC = Map<PackageId,ProjStateTC>

type ProjPackageFuns<'file,'package> =
    abstract member unions : (string * 'package) list -> 'package
    abstract member union : 'package * 'package -> 'package
    abstract member in_module : string * 'package -> 'package
    abstract member package_to_file : PackageId * 'package -> 'file
    abstract member add_file_to_package : 'file * 'package -> 'package
    abstract member init : 'package

let proj_package_funs = {new ProjPackageFuns<TypecheckerStatePropagated,TypecheckerStateTop> with
    member funs.unions l = 
        let x = promise_thunk <| fun () ->
            List.fold (fun big (name,small) -> 
                Hopac.queueIgnore small.has_error; Hopac.queueIgnore small.env
                funs.union(funs.in_module(name,small),big)
                ) funs.init l
        {
        has_error=x >>=* fun x -> x.has_error
        env = x >>=* fun x -> x.env
        }
    member _.union(small,big) = {
        env = small.env >>=* fun small -> big.env >>- union small
        has_error = small.has_error >>=* fun a -> big.has_error >>- fun b -> a || b
        }
    member _.in_module(name,x) = {x with env = x.env >>-* in_module name}
    member _.package_to_file(package_id,x) = { package_id = package_id; module_id = 0; has_error = x.has_error; env = x.env >>-* package_to_file }
    member _.add_file_to_package(a,b) = {
        has_error = a.has_error
        env = let i,a,b = a.package_id, a.env, b.env in a >>=* fun a -> b >>- add_file_to_package i a
        }
    member _.init = {has_error = Promise.Now.withValue false; env = Promise.Now.withValue package_env_default}
    }

let wdiff_proj_packages (funs : ProjPackageFuns<_,'a>) (state : 'a ProjPackagesState) (x : (string * 'a) list) =
    if state.packages = x then state else {state with packages = x; result = funs.unions x }

let wdiff_proj_update_packages funs_packages funs_files (state : ProjState<'a,'b,'state>) x =
    let packages = wdiff_proj_packages funs_packages state.packages x
    if state.packages = packages then state else
    let files = wdiff_proj_files_update_packages funs_files state.files (funs_packages.package_to_file(packages.package_id,packages.result))
    let result = funs_packages.add_file_to_package(files.result,state.result)
    {packages=packages; files=files; result=result}

let wdiff_proj_update_files (funs_packages : ProjPackageFuns<_,_>) funs_files (state : ProjState<'a,'b,'state>) x =
    let files = wdiff_proj_files_update_files funs_files state.files x
    let result = funs_packages.add_file_to_package(files.result,state.result)
    {state with files=files; result=result}

let wdiff_proj (funs_packages : ProjPackageFuns<_,_>) funs_files (state : ProjState<'a,'b,'state>) (packages,files) =
    let state = wdiff_proj_update_packages funs_packages funs_files state packages
    wdiff_proj_update_files funs_packages funs_files state files