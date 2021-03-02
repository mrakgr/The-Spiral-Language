module Spiral.StreamServer.Main

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral
open Spiral.Tokenize
open Spiral.BlockSplitting
open Spiral.TypecheckingUtils
open Spiral.Infer
open Spiral.Blockize

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

let job_thunk_with f x = Job.thunk (fun () -> f x)
let promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let promise_thunk f = Hopac.memo (Job.thunk f)

type EditorStream<'a,'b> = abstract member Run : 'a -> 'b * EditorStream<'a,'b>

type SpiEdit = {|from: int; nearTo: int; lines: string []|}
type TokReq =
    | DocumentAll of string []
    | DocumentEdit of SpiEdit
type TokRes = {blocks : Block list; errors : RString list}
type LinerStream = EditorStream<TokReq, string PersistentVector>
type TokenizerStream = EditorStream<TokReq, TokRes>

let liner lines req =
    let replace (edit : SpiEdit) = PersistentVector.replace edit.from edit.nearTo edit.lines lines
    match req with
    | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=text|}
    | DocumentEdit edit -> replace edit

//let liner =
//    let rec loop lines =
//        {new LinerStream with
//            member t.Run req =
//                let replace (edit : SpiEdit) = PersistentVector.replace edit.from edit.nearTo edit.lines lines
//                let next lines = lines, loop lines
//                match req with
//                | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=text|} |> next
//                | DocumentEdit edit -> replace edit |> next
//            }
//    loop PersistentVector.empty

type TokenizerState = {
    lines : (LineParsers.Range * SpiralToken) PersistentVector PersistentVector
    blocks : Block list
    errors : RString list
    }

/// An array of {line: int; char: int; length: int; tokenType: int; tokenModifiers: int} in the order as written suitable for serialization.
type VSCTokenArray = int []
let process_error (k,v) = 
    let messages, expecteds = v |> List.distinct |> List.partition (fun x -> Char.IsUpper(x,0))
    let ex () = match expecteds with [x] -> sprintf "Expected: %s" x | x -> sprintf "Expected one of: %s" (String.concat ", " x)
    let f l = String.concat "\n" l
    if List.isEmpty expecteds then k, f messages
    elif List.isEmpty messages then k, ex ()
    else k, f (ex () :: "" :: "Other error messages:" :: messages)

let process_errors line (ers : LineTokenErrors list) : RString list =
    ers |> List.mapi (fun i l -> 
        let i = line + i
        l |> List.map (fun (r,x) -> x, ({|line=i; character=r.from|}, {|line=i; character=r.nearTo|}))
        )
    |> List.concat
    |> List.groupBy snd
    |> List.map ((fun (k,v) -> k, List.map fst v) >> process_error)

let vscode_tokens from near_to (lines : LineToken PersistentVector PersistentVector) =
    let toks = ResizeArray()
    let rec loop i line_delta =
        if i < near_to then
            lines.[i] |> PersistentVector.fold (fun (line_delta,from_prev) (r,x) ->
                toks.AddRange [|line_delta; r.from-from_prev; r.nearTo-r.from; int (token_groups x); 0|]
                0, r.from
                ) (line_delta, 0)
            |> fst |> ((+) 1) |> loop (i+1)
    
    loop from from
    toks.ToArray()

let add_line_to_range line ((a,b) : VSCRange) = {|a with line=line+a.line|}, {|b with line=line+b.line|}
let tokenize_replace (lines : _ PersistentVector PersistentVector) (errors : _ list) (edit : SpiEdit) =
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

let tokenizer (state : TokenizerState) req = 
    let replace edit =
        let lines, errors = tokenize_replace state.lines state.errors edit
        let blocks = block_all_wdiff state.blocks (lines, edit)
        {lines=lines; errors=errors; blocks=blocks}

    let next (state : TokenizerState) = {blocks=state.blocks; errors=state.errors}, state
    match req with
    | DocumentAll text -> replace {|from=0; nearTo=state.lines.Length; lines=text|} |> next
    | DocumentEdit edit -> replace edit |> next

//let tokenizer =
//    let rec loop (lines, errors, blocks) = {new TokenizerStream with
//        member t.Run req =
//            let replace edit =
//                let lines, errors = Tokenize.replace lines errors edit
//                let blocks = block_all_wdiff blocks (lines, edit)
//                lines, errors, blocks

//            let next (_,errors,blocks as x) = {blocks=blocks; errors=errors}, loop x
//            match req with
//            | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=text|} |> next
//            | DocumentEdit edit -> replace edit |> next
//            }
//    loop (PersistentVector.singleton PersistentVector.empty,[],[])

let parse is_top_down (s : (LineTokens * ParsedBlock) list) (x : Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    List.iter (fun (a,b) -> dict.Add(a,b.parsed)) s
    List.map (fun x -> x.block, {
        parsed = Utils.memoize dict (block_init is_top_down) x.block
        offset = x.offset
        }) x

type ParserRes = {lines : LineTokens; bundles : TopOffsetStatement list list; parser_errors : RString list; tokenizer_errors : RString list}
type ParserStream = abstract member Run : TokRes -> ParserRes Promise * ParserStream
let parser is_top_down =
    let run s req =
        let s = promise_thunk <| fun () -> parse is_top_down s req.blocks
        let a = s >>-* fun s ->
            let lines, bundles, parser_errors = block_bundle s
            {lines = lines; bundles = bundles; parser_errors = parser_errors; tokenizer_errors = req.errors}
        a, s
    let rec loop s =
        {new ParserStream with
            member t.Run(req) =
                let s = s()
                let a,s' = run s req
                a, loop (fun () -> if Promise.Now.isFulfilled s' then Promise.Now.get s' else s)
                }
    loop (fun () -> [])

type ModuleStreamOut = string PersistentVector * TokRes * ParserRes Promise
type ModuleStream = EditorStream<TokReq, ModuleStreamOut>
type ModuleStreamRes = ModuleStreamOut * ModuleStream
let module' error_tokenizer error_parser is_top_down =
    let rec loop (liner : LinerStream, tokenizer : TokenizerStream, parser : ParserStream) =
        {new ModuleStream with
            member _.Run(req) =
                let lines,lin = liner.Run(req)
                let a,tok = tokenizer.Run(req)
                error_tokenizer a.errors
                let b,par = parser.Run(a)
                let b = b >>-* fun x -> error_parser x.parser_errors; x
                (lines, a, b), loop (lin, tok, par)
                }
    loop (liner, tokenizer, parser is_top_down)

let cons_fulfilled l = 
    let rec loop olds = function
        | Cons(old,next) when Promise.Now.isFulfilled next -> loop (PersistentVector.conj old olds) (Promise.Now.get next)
        | _ -> olds
    loop PersistentVector.empty l
type TypecheckerStream = EditorStream<ParserRes Promise, InferResult Stream>
let typechecker package_id module_id (path : string) top_env =
    let rec run old_results env i (bss : TopOffsetStatement list list) = 
        match bss with
        | b :: bs ->
            match PersistentVector.tryNth i old_results with
            | Some (b', _, env as s) when b = b' -> Cons(s,Promise(run old_results env (i+1) bs))
            | _ ->
                let rec loop old_results env i = function
                    | b :: bs ->
                        let x = Infer.infer package_id module_id env (bundle_statements b)
                        let adds = match x.top_env_additions with AOpen x | AInclude x -> x
                        let _,_,env as s = b,x,Infer.union adds env
                        Cons(s,promise_thunk (fun () -> loop old_results env (i+1) bs))
                    | [] -> Nil
                loop old_results env i bss
        | [] -> Nil
    let rec loop r =
        {new TypecheckerStream with
            member _.Run(res) =
                let r = r()
                let r' = 
                    r >>=* fun old_results ->
                    top_env >>= fun top_env ->
                    res >>- fun res ->
                    run (cons_fulfilled old_results) top_env 0 res.bundles
                let a = Stream.mapFun (fun (_,x,_) -> x) r'
                a, loop (fun () -> if Promise.Now.isFulfilled r' then r' else r)
            }
    loop (fun () -> Stream.nil)

type ModuleId = int
type DiffableFileHierarchyT<'a,'b> =
    | File of path: string * name: string option * 'a
    | Directory of name: string * DiffableFileHierarchyT<'a,'b> list * 'b
type DiffableFileHierarchy = 
    DiffableFileHierarchyT<
        (InferResult Stream * (ModuleId * TopEnv Promise)) option * ParserRes Promise * TypecheckerStream option,
        (ModuleId * TopEnv Promise) option
        >
type MultiFileStream = EditorStream<DiffableFileHierarchy list, Map<string,InferResult Stream> * TopEnv Promise>

// Rather than just throwing away the old results, diff returns the new tree with as much useful info from the old tree as is possible.
let diff_order_changed old new' =
    let mutable same_files = true
    let mutable same_order = true
    let rec elem (o,n) = 
        match o,n with
        // In `n`, `meta` and `tc` fields are None.
        | File(path,name,(_,p,tc)) & o,File(path',name',(_,p',_)) when path = path' && name = name' -> 
            if same_files then 
                if Object.ReferenceEquals(p,p') then o
                else same_files <- false; File(path,name,(None,p',tc))
            else File(path,name,(None,p',None))
        | Directory(name,l,o), Directory(name',l',o') when name = name' -> Directory(name,list (l,l'),if same_files then o else o')
        | _, n -> same_order <- false; n
    and list = function
        | o :: o', n :: n' -> elem (o,n) :: (if same_order then list (o', n') else n')
        | [], [] -> []
        | _, n -> same_order <- false; n
    list (old,new')

let inline multi_file_run on_unchanged_file on_changed_file top_env_empty create_stream post_process_result union in_module package_id top_env files = 
    let rec changed (module_id,top_env as i) x =
        match x with
        | File(path,_,(Some (r,o),_,_)) -> 
            on_unchanged_file path r
            x, o
        | File(path,name,(None,res,tc)) ->
            let tc : EditorStream<_,_> = match tc with Some tc -> tc | None -> create_stream package_id module_id path top_env
            let r,tc = tc.Run res
            on_changed_file path r
            let top_env_additions = 
                let adds = post_process_result r
                match name with
                | Some name -> adds >>-* in_module name
                | None -> adds
            let o = module_id+1, top_env_additions
            File(path,name,(Some (r,o),res,Some tc)),o
        | Directory(name,l,Some o) -> Directory(name,l,Some o), o
        | Directory(name,l,None) ->
            let l,(module_id,top_env_adds) = changed_list i l
            let o = module_id, top_env_adds >>-* in_module name
            Directory(name,l,Some o),o
    and changed_list (module_id,top_env) l =
        let o = module_id, Promise.Now.withValue(top_env_empty)
        let l,(_,o) =
            List.mapFold (fun (top_env, (module_id, top_env_adds as o)) x ->
                let i = module_id, top_env
                let x,(module_id,top_env_adds') = changed i x
                let union a b = a >>=* fun a -> b >>- fun b -> union a b
                let top_env = union top_env_adds' top_env
                let o = module_id, union top_env_adds' top_env_adds
                x,(top_env,o)
                ) (top_env,o) l
        l,o
    let i = 0, top_env
    let l,(_,top_env_adds) = changed_list i files 
    top_env_adds, l

let union_adds r =
    Stream.foldFromFun top_env_empty (fun s (x : InferResult) -> 
        match x.top_env_additions with
        | AOpen _ -> s
        | AInclude x -> union x s
        ) r
    |> Hopac.memo

let multi_file package_id top_env =
    let rec create files' = 
        {new MultiFileStream with 
            member _.Run files = 
                let files = diff_order_changed files' files 
                let mutable changed_files = Map.empty
                let on_unchanged _ _ = ()
                let on_changed path r = changed_files <- Map.add path r changed_files
                let x, l = multi_file_run on_unchanged on_changed top_env_empty typechecker union_adds Infer.union Infer.in_module package_id top_env files
                (changed_files, x), create l
            }
    create []

type PackagePath = string
type PackageName = string
type PackageLinks = (PackagePath * PackageName option) list
type PackageId = int
type PackageIds = PersistentHashMap<PackagePath,PackageId>
type AddPackageInput = {links : PackageLinks; files : DiffableFileHierarchy list}
type PackageCoreStream =
    abstract member ReplacePackages : (string * AddPackageInput) list * string Set -> (Map<string,InferResult Stream> * PackageIds) * PackageCoreStream

type PackageEnv = {
    nominals_aux : Map<int,Map<GlobalId, {|name : string; kind : TT|}>>
    nominals : Map<int,Map<GlobalId, {|vars : Var list; body : T|}>>
    prototypes_instances : Map<int,Map<GlobalId * GlobalId, Constraint Set list>>
    prototypes : Map<int,Map<GlobalId, {|name : string; signature: T|}>>
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

let package_to_top (x : PackageEnv) = {
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

let top_to_package package_id (small : TopEnv) (big : PackageEnv): PackageEnv = {
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

type ModulePath = string
type PackageMultiFileLinks = (PackagePath * (PackageName option * PackageEnv Promise)) list
type PackageMultiFileStreamAux = EditorStream<DiffableFileHierarchy list, Map<string,InferResult Stream> * PackageEnv Promise>
type PackageMultiFileStream = EditorStream<PackageId * PackageMultiFileLinks * DiffableFileHierarchy list, Map<string,InferResult Stream> * PackageEnv Promise>

let package_multi_file post_process_result multi_file package_env_default union in_module top_to_package package_to_top =
    let make_new_stream (id : PackageId) links =
        let package_env_in = 
            let l = List.fold (fun l (k, (name,env_out)) -> (match name with Some name -> env_out >>-* in_module name | None -> env_out) :: l) [] links |> Job.conCollect
            l >>-* Seq.fold (fun big small -> union small big) package_env_default
        let rec loop (top_env_out',env_out') (multi_file : EditorStream<_,_>) =
            {new EditorStream<_,_> with
                member _.Run x =
                    let (result,top_env_out),multi_file = multi_file.Run(x)
                    let f env_out = env_out >>=* fun env_out -> package_env_in >>- fun package_env_in -> top_to_package id env_out package_env_in
                    let env_out = if top_env_out = top_env_out' then env_out' else f top_env_out
                    let target = post_process_result f result
                    (target,env_out), loop (top_env_out, env_out) multi_file
                }
        loop (Promise(), Promise()) (multi_file id (package_env_in >>-* package_to_top))
        
    let rec loop (id',links',stream) =
        {new EditorStream<_,_> with
            member _.Run((id,links,data)) =
                let stream = if id = id' && links = links' then stream else make_new_stream id links
                run id links stream data
                }
    and run id links (stream : EditorStream<_,_>) data =
        let a,b = stream.Run(data)
        a, loop (id,links,b)

    {new EditorStream<_,_> with
        member _.Run((id,links,data)) =
            let stream = make_new_stream id links
            run id links stream data
            }
type PackageCoreStateItem = {
    links : PackageLinks
    rev_links : PackagePath Set
    env_out : PackageEnv Promise
    stream : PackageMultiFileStream
    id : int
    }

type PackageCoreState = {
    packages : Map<string,PackageCoreStateItem>
    package_ids : PackageIds
    }

let inline link_op f dir s k = 
    match Map.tryFind k s.packages with 
    | Some x -> {s with packages = Map.add k {x with rev_links = f dir x.rev_links} s.packages}
    | None -> s

/// Removes the current package from its parents' reverse links.
let links_rev_remove links dir s = links |> List.fold (fun s (k, _) -> link_op Set.remove dir s k) s
/// Adds the current package to its parents' reverse links.
let links_rev_add links dir s = links |> List.fold (fun s (k, _) -> link_op Set.add dir s k) s

let add_package (s : PackageCoreState, infer_results' : Map<string,InferResult Stream>, dirty_nodes : Set<string>) (dir, x : AddPackageInput) =
    let id, package_ids = 
        if PersistentHashMap.containsKey dir s.package_ids then s.package_ids.[dir], s.package_ids
        else s.package_ids.Count, s.package_ids.Add(dir,s.package_ids.Count)
    let old_package = Map.tryFind dir s.packages
    let (infer_results, env_out), stream =
        let links = x.links |> List.map (fun (k, v) -> k, (v, s.packages.[k].env_out))
        let files = x.files
        match old_package with
        | Some p -> p.stream.Run(id,links,files)
        | None -> (package_multi_file (fun _ x -> x) multi_file package_env_default union in_module top_to_package package_to_top).Run(id,links,files)
    
    let s = // Remove the current package dir from the parents based on the old links.
        let old_links = match old_package with Some x -> x.links | None -> []
        links_rev_remove old_links dir s
        // Add the current package dir to the parents based on the new links.
        |> links_rev_add x.links dir
    
    let infer_results = Map.foldBack Map.add infer_results infer_results'

    let package = {
        links = x.links; env_out = env_out; stream = stream; id = id
        rev_links = match old_package with Some x -> x.rev_links | None -> Set.empty
        }
    
    { packages = Map.add dir package s.packages; package_ids = package_ids }, infer_results, Set.add dir dirty_nodes

let remove_package (s : PackageCoreState) x =
    match Map.tryFind x s.packages with
    | Some package ->
        let s = links_rev_remove package.links x s
        {s with packages = Map.remove x s.packages}
    | None ->
        s

let package_core =
    let rec loop (s : PackageCoreState) =
        {new PackageCoreStream with
            member _.ReplacePackages(adds,removes) =
                let s,b,_ = List.fold add_package (s,Map.empty,Set.empty) adds
                let s = Set.fold remove_package s removes
                (b, s.package_ids), loop s
            }
    loop {packages=Map.empty; package_ids=PersistentHashMap.empty}

//type PackageDiffStream =
//    abstract member Run : string [] * FullyValidatedSchema ResultMap * MirroredGraph * Map<string,ModuleStreamRes> -> (Map<string, InferResult Stream> * PackageIds) option * PackageDiffStream

//let package_named_links (p : FullyValidatedSchema) =
//    let names = p.schema.schema.packages // TODO: Extend the parser for packages and separate out the names and locations.
//    let links = p.schema.packages
//    List.map2 (fun (_,a) b -> a, if b.is_include then None else Some b.name) links names

//type PackageDiffState = { changes : string Set; errors : string Set; core : PackageCoreStream }
//let get_adds_and_removes (schema : FullyValidatedSchema ResultMap) ((abs,bas) : MirroredGraph) (modules : Map<string,ModuleStreamRes>) (changes : string Set) =
//    let sort_order, _ = topological_sort bas changes
//    Seq.foldBack (fun dir (adds,removes) ->
//        match Map.tryFind dir schema with
//        | Some(Ok p) ->
//            let files =
//                let rec elem = function
//                    | ValidatedFileHierarchy.File((_,a),b,_) -> File(a,b,(None,modules.[a] |> (fun ((_,_,x),_) -> x),None))
//                    | ValidatedFileHierarchy.Directory(a,b) -> Directory(a,list b,None)
//                and list l = List.map elem l
//                list p.schema.files
//            (dir,{links=package_named_links p; files=files}) :: adds, removes
//        | _ -> adds, Set.add dir removes
//        ) sort_order ([], Set.empty)

//let package_diff =
//    let rec loop (s : PackageDiffState) =
//        {new PackageDiffStream with
//            member _.Run(order,schemas,graph,modules) =
//                let changes = Array.foldBack Set.add order s.changes
//                let errors = 
//                    Array.fold (fun s x ->
//                        let has_error =
//                            match Map.tryFind x schemas with
//                            | Some(Ok x) -> (List.isEmpty x.package_errors && List.isEmpty x.schema.errors) = false
//                            | _ -> false
//                        if has_error then Set.add x s else Set.remove x s
//                        ) s.errors order
//                if Set.isEmpty errors && Set.isEmpty changes = false then 
//                    let adds,removes = get_adds_and_removes schemas graph modules changes
//                    let x,core = s.core.ReplacePackages(adds,removes)
//                    Some x,loop {changes=Set.empty; errors=errors; core=core}
//                else None,loop {s with changes=changes; errors=errors}
//            }
//    loop {changes=Set.empty; errors=Set.empty; core=package_core}
