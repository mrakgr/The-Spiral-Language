module Spiral.StreamServer.Main

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral
open Spiral.Tokenize
open Spiral.TypecheckingUtils
open Spiral.Infer
open Spiral.Blockize
open Spiral.SpiProj
open Spiral.ServerUtils

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream


type TokReq =
    | DocumentAll of string
    | DocumentEdit of SpiEdit
type TokRes = {blocks : Block list; errors : RString list}

let job_thunk_with f x = Job.thunk (fun () -> f x)
let promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let promise_thunk f = Hopac.memo (Job.thunk f)

type EditorStream<'a,'b> = abstract member Run : 'a -> 'b * EditorStream<'a,'b>
type TokenizerStream = EditorStream<TokReq, TokRes>

let tokenizer =
    let rec loop (lines, errors, blocks) = {new TokenizerStream with
        member t.Run req =
            let replace edit =
                let lines, errors = Tokenize.replace lines errors edit
                let blocks = block_separate lines blocks edit
                lines, errors, blocks

            let next (_,errors,blocks as x) = {blocks=blocks; errors=errors}, loop x
            match req with
            | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=Utils.lines text|} |> next
            | DocumentEdit edit -> replace edit |> next
            }
    loop (PersistentVector.singleton PersistentVector.empty,[],[])

let parse is_top_down (s : (LineTokens * ParsedBlock) list) (x : Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    List.iter (fun (a,b) -> dict.Add(a,b.parsed)) s
    List.map (fun x -> x.block, {
        parsed = Utils.memoize dict (block_init is_top_down) x.block
        offset = x.offset
        }) x

type ParserRes = {lines : LineTokens; bundles : Bundle list; parser_errors : RString list; tokenizer_errors : RString list}
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

type ModuleStream = abstract member Run : TokReq -> TokRes * ParserRes Promise * ModuleStream
let module' error is_top_down =
    let rec loop (tokenizer : TokenizerStream, parser : ParserStream) =
        {new ModuleStream with
            member _.Run(req) =
                let a,tok = tokenizer.Run(req)
                let b,par = parser.Run(a)
                let b = b >>-* fun x -> error x.parser_errors; x
                a, b, loop (tok, par)
                }
    loop (tokenizer, parser is_top_down)

let cons_fulfilled l = 
    let rec loop olds = function
        | Cons(old,next) when Promise.Now.isFulfilled next -> loop (PersistentVector.conj old olds) (Promise.Now.get next)
        | _ -> olds
    loop PersistentVector.empty l
type TypecheckerStream = EditorStream<ParserRes Promise, InferResult Stream>
let typechecker package_id module_id top_env =
    let rec run old_results env i (bss : Bundle list) = 
        match bss with
        | b :: bs ->
            match PersistentVector.tryNth i old_results with
            | Some (b', _, env as s) when b = b' -> Cons(s,Promise(run old_results env (i+1) bs))
            | _ ->
                let rec loop old_results env i = function
                    | b :: bs ->
                        let x = Infer.infer package_id module_id env (bundle_top b)
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
type DiffableFileHierarchyT<'a> =
    | File of path: string * name: string option * 'a
    | Directory of name: string * 'a DiffableFileHierarchyT list
type DiffableFileHierarchy = ((ModuleId * TopEnv Promise) option * ParserRes Promise * TypecheckerStream option) DiffableFileHierarchyT
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
        | Directory(name,l), Directory(name',l') when name = name' -> Directory(name,list (l,l'))
        | _, n -> same_order <- false; n
    and list = function
        | o :: o', n :: n' -> elem (o,n) :: (if same_order then list (o', n') else n')
        | [], [] -> []
        | _, n -> same_order <- false; n
    list (old,new')

let multi_file_run top_env_empty create_stream post_process_result union in_module package_id top_env files = 
    let mutable changed_files = Map.empty
    let rec changed (module_id,top_env as i) x =
        match x with
        | File(_,_,(Some o,_,_)) -> x, o
        | File(path,name,(None,res,tc)) ->
            let tc : EditorStream<_,_> = match tc with Some tc -> tc | None -> create_stream package_id module_id top_env
            let r,tc = tc.Run res
            changed_files <- Map.add path r changed_files
            let top_env_additions = 
                let adds = post_process_result r
                match name with
                | Some name -> adds >>-* in_module name
                | None -> adds
            let o = module_id+1, top_env_additions
            File(path,name,(Some o,res,Some tc)),o
        | Directory(name,l) ->
            let l,(module_id,top_env_adds) = changed_list i l
            let o = module_id, top_env_adds >>-* in_module name
            Directory(name,l),o
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
    (changed_files, top_env_adds), l

let union_adds r =
    Stream.foldFromFun top_env_empty (fun a (b : InferResult) -> 
        match b.top_env_additions with
        | AOpen _ -> a
        | AInclude adds -> union a adds
        ) r
    |> Hopac.memo

let multi_file package_id top_env =
    let rec create files' = 
        {new MultiFileStream with 
            member _.Run files = 
                let files = diff_order_changed files' files 
                let x, l = multi_file_run top_env_empty typechecker union_adds Infer.union Infer.in_module package_id top_env files
                x, create l
            }
    create []

type Name = string
type AddPackageInput = {links : Map<string, Name>; files : DiffableFileHierarchy list}
type PackageCoreStream =
    abstract member ReplacePackages : (string * AddPackageInput) list * string Set -> Map<string,InferResult Stream> * PackageCoreStream

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

type PackageCoreStateItem = {
    links : Map<string,Name>
    rev_links : string Set
    env_in : PackageEnv Promise
    env_out : PackageEnv Promise
    stream : MultiFileStream
    }

type PackageCoreState = {
    packages : Map<string,PackageCoreStateItem>
    package_ids : PersistentHashMap<string,int>
    }

let inline link_op f dir s k = 
    match Map.tryFind k s.packages with 
    | Some x -> {s with packages = Map.add k {x with rev_links = f dir x.rev_links} s.packages}
    | None -> s

/// Removes the current package from its parents' reverse links.
let links_rev_remove links dir s = links |> Map.fold (fun s k _ -> link_op Set.remove dir s k) s
/// Adds the current package to its parents' reverse links.
let links_rev_add links dir s = links |> Map.fold (fun s k _ -> link_op Set.add dir s k) s

let add_package (s : PackageCoreState, infer_results' : Map<string,InferResult Stream>, dirty_nodes : Set<string>) (dir, x : AddPackageInput) =
    let old_package = Map.tryFind dir s.packages
    let is_dirty = x.links |> Map.exists (fun k _ -> Set.contains k dirty_nodes)
    let env_in =
        let f() =
            let l = x.links |> Map.fold (fun l k v -> (s.packages.[k].env_out >>-* in_module v) :: l) [] |> Job.conCollect
            l >>-* Seq.fold union package_env_default
        if is_dirty then f()
        else match old_package with Some x -> x.env_in | None -> f()
    
    let id, package_ids = 
        if PersistentHashMap.containsKey dir s.package_ids then s.package_ids.[dir], s.package_ids
        else s.package_ids.Count, s.package_ids.Add(dir,s.package_ids.Count)
    let (infer_results, top_env_out), stream =
        match old_package with
        | Some _ when is_dirty -> (multi_file id (env_in >>-* package_to_top)).Run(x.files)
        | Some p -> p.stream.Run(x.files)
        | None -> (multi_file id (env_in >>-* package_to_top)).Run(x.files)
    let env_out = top_env_out >>=* fun top_env_out -> env_in >>- fun env_in -> top_to_package id top_env_out env_in
    
    let s = // Remove the current package dir from the parents based on the old links.
        let old_links = match old_package with Some x -> x.links | None -> Map.empty
        links_rev_remove old_links dir s
        // Add the current package dir to the parents based on the new links.
        |> links_rev_add x.links dir
    
    let infer_results = Map.foldBack Map.add infer_results infer_results'

    let package = {
        links = x.links
        rev_links = match old_package with Some x -> x.rev_links | None -> Set.empty
        env_in = env_in
        env_out = env_out
        stream = stream
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
                b, loop (Set.fold remove_package s removes)
            }
    loop {packages=Map.empty; package_ids=PersistentHashMap.empty}

type PackageDiffStream =
    abstract member Run : string [] * PackageSchema ResultMap * MirroredGraph * Map<string,'a * ParserRes Promise * 'b> -> Map<string, InferResult Stream> * PackageDiffStream

let package_named_links (p : PackageSchema) =
    let names = p.schema.schema.packages // TODO: Extend the parser for packages and separate out the names and locations.
    let links = p.schema.packages
    Map(List.map2 (fun (_,a) (_,b) -> a, b) links names)

type PackageDiffState = { changes : string Set; errors : string Set; core : PackageCoreStream }
let get_adds_and_removes (schema : PackageSchema ResultMap) ((abs,bas) : MirroredGraph) (modules : Map<string,_ * ParserRes Promise * _>) (changes : string Set) =
    let sort_order, _ = topological_sort bas changes
    Seq.foldBack (fun dir (adds,removes) ->
        match Map.tryFind dir schema with
        | Some(Ok p) ->
            let files =
                let rec elem = function
                    | ValidatedFileHierarchy.File((_,a),b,_) -> File(a,b,(None,modules.[a] |> (fun (_,x,_) -> x),None))
                    | ValidatedFileHierarchy.Directory(a,b) -> Directory(a,list b)
                and list l = List.map elem l
                list p.schema.files
            (dir,{links=package_named_links p; files=files}) :: adds, removes
        | _ -> adds, Set.add dir removes
        ) sort_order ([], Set.empty)

let package_diff =
    let rec loop (s : PackageDiffState) =
        {new PackageDiffStream with
            member _.Run(order,schemas,graph,modules) =
                let changes = Array.foldBack Set.add order s.changes
                let errors = 
                    Array.fold (fun s x ->
                        let has_error =
                            match Map.tryFind x schemas with
                            | Some(Ok x) -> (List.isEmpty x.package_errors && List.isEmpty x.schema.errors) = false
                            | _ -> false
                        if has_error then Set.add x s else Set.remove x s
                        ) s.errors order
                if Set.isEmpty errors && Set.isEmpty changes = false then 
                    let adds,removes = get_adds_and_removes schemas graph modules changes
                    let x,core = s.core.ReplacePackages(adds,removes)
                    x,loop {changes=Set.empty; errors=errors; core=core}
                else Map.empty, loop {s with changes=changes; errors=errors}
            }
    loop {changes=Set.empty; errors=Set.empty; core=package_core}
