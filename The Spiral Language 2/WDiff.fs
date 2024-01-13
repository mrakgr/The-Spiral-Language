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

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

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

type [<ReferenceEquality>] TokenizerState = {
    lines_text : string PersistentVector
    lines_token : LineTokens
    blocks : LineTokens Block list
    errors : RString list
    }

let wdiff_tokenizer_init = { lines_text = PersistentVector.empty; lines_token = PersistentVector.empty; blocks = []; errors = [] }

/// Immutably updates the state based on the request. Does diffing to make the operation efficient.
/// It is possible for the server to go out of sync, in which case an error is returned.
let replace (state : TokenizerState) (edit : SpiEdit) =
    let lines_text = PersistentVector.replace edit.from edit.nearTo edit.lines state.lines_text
    let lines_token, errors = tokenize_replace (state.lines_token, state.errors) edit
    let blocks = wdiff_block_all state.blocks (lines_token, edit.lines.Length, edit.from, edit.nearTo)
    {lines_text=lines_text; lines_token=lines_token; errors=errors; blocks=blocks}
let wdiff_tokenizer_all (state : TokenizerState) text = 
    let text = Utils.lines text
    let text' = state.lines_text |> Seq.toArray
    let rec loop (index,text : string [] as x) i = if i < min text.Length state.lines_text.Length && index text i = index text' i then loop x (i+1) else i
    let from = loop ((fun text i -> text.[i]),text) 0
    if from = text.Length then state else
    let text = text.[from..]
    let fromRev = loop ((fun text i -> text.[text.Length-1-i]),text) 0
    replace state {|from=from; nearTo=text'.Length-fromRev; lines=text.[..text.Length-1-fromRev]|}
let wdiff_tokenizer_edit (state : TokenizerState) (edit : SpiEdit) = 
    if edit.nearTo <= state.lines_text.Length then Ok (replace state edit)
    else Error "The edit is out of bounds and cannot be applied. The language server and the editor are out of sync. Try reopening the file being edited."

open BlockParsing
let semantic_updates_apply (block : LineTokens) updates =
    Seq.fold (fun block (c : VectorCord, l) -> 
        let x =
            let r, x = PersistentVector.nthNth c.row c.col block
            let x =
                match x with
                | TokVar(a,_) -> TokVar(a,l)
                | TokSymbol(a,_) -> TokSymbol(a,l)
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

let wdiff_parse_init is_top_down : ParserState = {is_top_down=is_top_down; blocks=[]}
let wdiff_parse (state : ParserState) (unparsed_blocks : LineTokens Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    // Offset should be ignored when memoizing the results of parsing.
    List.iter (fun (a,b) -> dict.Add(a,b.block)) state.blocks
    let blocks = unparsed_blocks |> List.map (fun x -> 
        x.block, {block=Utils.memoize dict (fun a -> Hopac.memo(Job.thunk <| fun () -> (parse_block state.is_top_down) a)) x.block; offset=x.offset}
        )  
    {state with blocks = blocks }

type ModuleState = { tokenizer : TokenizerState; bundler : BlockBundleState; parser : ParserState }
let wdiff_module_init is_top_down = {tokenizer = wdiff_tokenizer_init; bundler = wdiff_block_bundle_init; parser = wdiff_parse_init is_top_down}
let wdiff_module_body state tokenizer =
    if state.tokenizer = tokenizer then state else
    let parser = wdiff_parse state.parser tokenizer.blocks
    let bundler = wdiff_block_bundle state.bundler parser
    {tokenizer=tokenizer; parser=parser; bundler=bundler}
let wdiff_module_edit (state : ModuleState) x = wdiff_tokenizer_edit state.tokenizer x |> Result.map (wdiff_module_body state)
let wdiff_module_all state x = wdiff_tokenizer_all state.tokenizer x |> wdiff_module_body state
let wdiff_module_init_all is_top_down x = wdiff_module_all (wdiff_module_init is_top_down) x

type [<ReferenceEquality>] FileState<'input,'result,'state> = { input : 'input; result : 'result; state : 'state }
type FileFuns<'a,'b,'state> =
    abstract member eval : 'state * 'a -> 'b
    abstract member diff : 'state * 'b * 'a -> 'b
    abstract member init : 'a -> FileState<'a,'b,'state>

type TypecheckerStateValue = Bundle option * InferResult * TopEnv
type TypecheckerStatePropagated = (bool * TopEnv) Promise
type TypecheckerState = FileState<PackageId * ModuleId * BlockBundleState, TypecheckerStateValue Stream, TypecheckerStatePropagated>

let rec typecheck (package_id,module_id,env : TopEnv) x = x >>=* function
    | Cons((_,b : BlockBundleValue), ls) ->
        match b.bundle with
        | Some bundle ->
            let x = Infer.infer package_id module_id env bundle
            let adds = match x.top_env_additions with AOpen x | AInclude x -> x
            let env = Infer.union adds env
            Job.result (Cons((b.bundle,x,env),typecheck (package_id,module_id,env) ls))
        | None ->
            typecheck (package_id,module_id,env) ls :> _ Job
    | Nil ->
        Job.result Nil

let rec diff (package_id,module_id,env) (result,input : BlockBundleState) = 
    let tc () = typecheck (package_id,module_id,env) input
    if Promise.Now.isFulfilled result then
        input >>** fun input ->
        match Promise.Now.get result,input with
        | Cons((b',_,env as x),next), Cons((_,b),bs) when b' = b.bundle -> Promise.Now.withValue (Cons(x,diff (package_id,module_id,env) (next,bs)))
        | _ -> tc()
    else tc()

let funs_file_tc = {new FileFuns<PackageId * ModuleId * BlockBundleState, TypecheckerStateValue Stream, TypecheckerStatePropagated> with
    member _.eval(state,(pid,mid,x)) = 
        state >>=* fun (_,env) -> 
        typecheck (pid,mid,env) x
    member _.diff(state,b,(pid,mid,a)) =
        state >>=* fun (_,env) -> diff (pid,mid,env) (b,a)
    member _.init x = {
        input = x
        result = Promise.Now.never()
        state = Promise.Now.never()
        }
    }

let wdiff_file_update_state (funs : FileFuns<'a,'b,'state>) (state : FileState<'a,'b,'state>) (x : 'state) =
    if state.state = x then state else {state with state=x; result=funs.eval(x,state.input)}

let wdiff_file_update_input (funs : FileFuns<'a,'b,'state>) (state : FileState<'a,'b,'state>) (x : 'a) =
    if state.input = x then state else {state with input=x; result=funs.diff(state.state,state.result,x)}

let wdiff_file (funs : FileFuns<'a,'b,'state>) (state : FileState<'a,'b,'state>) (a,b) =
    if state.state = a then wdiff_file_update_input funs state b else {state=a; input=b; result=funs.eval(a,b)}

type ProjFilesTree =
    | File of module_id: ModuleId * path: string * name: string option
    | Directory of dir_id: DirId * name: string * ProjFilesTree list

type ProjFiles = { tree : ProjFilesTree list; num_dirs : int; num_files : int }

type ProjFileFuns<'a,'state> =
    abstract member file : string option * 'state * 'a -> 'a * 'state
    abstract member union : 'state * 'state -> 'state
    abstract member in_module : string * 'state -> 'state
    abstract member default' : 'state
    abstract member empty : 'state

type [<ReferenceEquality>] ProjFilesState<'a,'state> = {
    init : 'state
    uids_file : ('a * 'state) []
    uids_directory : 'state []
    files : ProjFiles
    result : 'state
    }

let proj_files_diff (uids_file : ('a * 'b) [], uids_directory : 'b [], files) (uids, files') =
    let uids_file' = Array.zeroCreate (Array.length uids)
    let uids_directory' = Array.zeroCreate files'.num_dirs
    // Ref equality is done first for performance. Most of the time the strings will be the same.
    let eq a b = Object.ReferenceEquals(a,b) || a = b
    let rec loop = function
        | File(mid,path,name), File(mid',path',name') when mid = mid' && eq path path' && eq name name' -> 
            let x = uids_file.[mid]
            if uids.[mid] = fst x then uids_file'.[mid] <- x; true else false
        | Directory(uid,name,l), Directory(uid',name',l') when uid = uid' && eq name name' && list (l,l') -> 
            uids_directory'.[uid] <- uids_directory.[uid]; true
        | _ -> false
    and list = function
        | x :: xs, y :: ys -> loop (x,y) && list (xs,ys)
        | _ -> false
    if list (files.tree, files'.tree) then None else Some (uids_file',uids_directory')

let proj_files (funs : ProjFileFuns<'a,'state>) uids_file uids_directory uids s l =
    let inline memo (uids : _ []) uid f = 
        let x = uids.[uid]
        if isNull (box x) then let x = f() in uids.[uid] <- x; x
        else x
    let rec loop state = function
        | File(mid,_,name) -> memo uids_file mid (fun () -> funs.file(name,state,Array.get uids mid)) |> snd
        | Directory(uid,name,l) -> memo uids_directory uid (fun () -> funs.in_module(name,list state l))
    and list s l = 
        List.fold (fun (empty,big) x -> 
            let small = loop big x
            funs.union(small,empty), funs.union(small,big)
            ) (funs.empty, s) l |> fst
    list s l.tree

let wdiff_proj_files_update_files (funs : ProjFileFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (uids,files : ProjFiles) =
    match proj_files_diff (state.uids_file,state.uids_directory,state.files) (uids,files) with
    | Some (uids_file, uids_directory) -> {state with files=files; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids state.init files}
    | None -> state

let wdiff_proj_files_update_packages (funs : ProjFileFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (init : 'state) =
    if state.init = init then state else
    let uids_file, uids_directory = Array.zeroCreate state.uids_file.Length, Array.zeroCreate state.uids_directory.Length
    let uids = Array.map fst state.uids_file
    {state with init=init; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids init state.files}

let wdiff_proj_files (funs : ProjFileFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (init,(uids,files)) =
    if state.init = init then wdiff_proj_files_update_files funs state (uids,files)
    else
        let uids_file, uids_directory = Array.zeroCreate files.num_files, Array.zeroCreate files.num_dirs
        {files=files; init=init; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids init files}

let typechecker_results_summary l =
    Stream.foldFun (fun (has_error,big) (_,x : InferResult,_) -> 
        has_error || List.isEmpty x.errors = false,
        match x.top_env_additions with 
        | AOpen _ -> big 
        | AInclude small -> union small big
        ) (false,top_env_empty) l

let funs_proj_file_tc = {new ProjFileFuns<TypecheckerState,TypecheckerStatePropagated> with
    member _.file(name,state,x) = 
        let x = wdiff_file_update_state funs_file_tc x state
        let env = 
            typechecker_results_summary x.result >>-* fun (has_error,env) -> 
            has_error, match name with None -> env | Some name -> in_module name env
        x,env
    member _.union(small,big) = small >>=* fun small -> big >>- fun big -> fst small || fst big, union (snd small) (snd big)
    member _.in_module(name,small) = small >>-* fun (has_error,env) -> has_error, in_module name env
    member _.default' = Promise.Now.withValue (false,top_env_default)
    member _.empty = Promise.Now.withValue (false,top_env_empty)
    }

type PackageEnv = {
    nominals_aux : Map<PackageId,Map<GlobalId, {|name : string; kind : TT|}>>
    nominals : Map<PackageId,Map<GlobalId, {|vars : Var list; body : T|}>>
    prototypes_instances : Map<PackageId,Map<GlobalId * GlobalId, Constraint Set list>>
    prototypes : Map<PackageId,Map<GlobalId, {|name : string; signature : T; kind : TT|}>>
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
    packages : (string option * 'a) list
    result : 'a
    }
type ProjState<'file_inputs,'files,'packages> = {
    package_id : PackageId
    packages : 'packages ProjPackagesState
    files : ProjFilesState<'file_inputs,'files>
    result : 'packages
    }
type TypecheckerStateTop = (bool * PackageEnv) Promise
type ProjStateTC = ProjState<TypecheckerState,TypecheckerStatePropagated,TypecheckerStateTop>
type ProjEnvTC = Map<PackageId,ProjStateTC>

type ProjPackageFuns<'file,'package> =
    abstract member unions : (string option * 'package) list -> 'package
    abstract member union : 'package * 'package -> 'package
    abstract member in_module : string * 'package -> 'package
    abstract member package_to_file : 'package -> 'file
    abstract member add_file_to_package : PackageId * 'file * 'package -> 'package
    abstract member default' : 'package
    abstract member empty : 'package

let funs_proj_package_tc = {new ProjPackageFuns<TypecheckerStatePropagated,TypecheckerStateTop> with
    member funs.unions l = 
        let f = function Some name, small -> funs.in_module(name,small) | None, small -> small
        List.fold (fun big x -> funs.union(f x,big)) funs.default' l
    member _.union(small,big) = 
        Job.delay <| fun () ->
            Hopac.queueIgnore big
            small >>= fun a ->
            big >>- fun b ->
            fst a || fst b, union (snd a) (snd b)
        |> Hopac.memo
    member _.in_module(name,x) = x >>-* fun (has_error,env) -> has_error, in_module name env
    member _.package_to_file(x) = x >>-* fun (has_error,env) -> has_error, package_to_file env
    member _.add_file_to_package(pid,a,b) = 
        a >>=* fun (has_error,env) ->
        b >>-* fun (has_error',env') ->
        has_error || has_error', add_file_to_package pid env env'
    member _.default' = Promise.Now.withValue (false, package_env_default)
    member _.empty = Promise.Now.withValue (false, package_env_empty)
    }

let wdiff_proj_init (funs_packages : ProjPackageFuns<'file,'package>) (funs_files : ProjFileFuns<'file_input,'file>) package_id : ProjState<'file_input,'file,'package> = 
    let packages = { packages = []; result = funs_packages.default' }
    let files = {
        files={tree=[]; num_dirs=0; num_files=0}
        uids_file=[||]; uids_directory=[||]
        init=funs_files.default'; result=funs_files.empty
        }
    let result = funs_packages.empty
    { package_id = package_id; packages = packages; files = files; result = result}

let wdiff_proj_packages (funs : ProjPackageFuns<_,'a>) (state : 'a ProjPackagesState) x =
    if state.packages = x then state else {packages = x; result = funs.unions x }

let wdiff_proj_update_packages funs_packages funs_files (state : ProjState<'a,'b,'state>) x =
    let packages = wdiff_proj_packages funs_packages state.packages x
    if state.packages = packages then state else
    let files = wdiff_proj_files_update_packages funs_files state.files (funs_packages.package_to_file(packages.result))
    let result = funs_packages.add_file_to_package(state.package_id,files.result,packages.result)
    {state with packages=packages; files=files; result=result}

let wdiff_proj_update_files (funs_packages : ProjPackageFuns<_,_>) funs_files (state : ProjState<'a,'b,'state>) x =
    let files = wdiff_proj_files_update_files funs_files state.files x
    if state.files = files then state else
    let result = funs_packages.add_file_to_package(state.package_id,files.result,state.packages.result)
    {state with files=files; result=result}

let wdiff_proj (funs_packages : ProjPackageFuns<_,_>) funs_files (state : ProjState<'file_input,'file,'state>) (packages,files) =
    let packages = wdiff_proj_packages funs_packages state.packages packages
    if state.packages = packages then wdiff_proj_update_files funs_packages funs_files state files
    else
        let files = wdiff_proj_files funs_files state.files (funs_packages.package_to_file(packages.result),files)
        let result = funs_packages.add_file_to_package(state.package_id,files.result,packages.result)
        {state with packages=packages; files=files; result=result}

type ProjEnvUpdate<'a> =
    | UpdatePackageModule of PackageId * (string option * PackageId) list * ('a [] * ProjFiles)
    | UpdatePackage of PackageId * (string option * PackageId) list

let map_packages s packages = packages |> List.map (fun (a,b) -> a, (Map.find b s).result)
let wdiff_projenv funs_packages funs_files (s : Map<PackageId,ProjState<'a,'b,'state>>) l =
    List.fold (fun s -> function
        | UpdatePackageModule(uid,packages,files) -> Map.add uid (wdiff_proj funs_packages funs_files s.[uid] (map_packages s packages,files)) s
        | UpdatePackage(uid,packages) -> Map.add uid (wdiff_proj_update_packages funs_packages funs_files s.[uid] (map_packages s packages)) s
        ) s l
