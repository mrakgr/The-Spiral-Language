module Spiral.StreamServer.Prepass

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.PartEval
open Spiral.Infer
open Spiral.PartEval.Prepass

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type PrepassPackageEnv = {
    prototypes_instances : Map<int, Map<GlobalId * GlobalId,E>>
    nominals : Map<int, Map<GlobalId,{|body : T; name : string|}>>
    term : Map<string,E>
    ty : Map<string,T>
    }

let union small big = {
    prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
    nominals = Map.foldBack Map.add small.nominals big.nominals
    term = Map.foldBack Map.add small.term big.term
    ty = Map.foldBack Map.add small.ty big.ty
    }
    
let in_module m (a : PrepassPackageEnv) =
    {a with 
        ty = Map.add m (TModule a.ty) Map.empty
        term = Map.add m (EModule a.term) Map.empty
        }

let package_env_empty = {
    prototypes_instances = Map.empty
    nominals = Map.empty
    term = Map.empty
    ty = Map.empty
    }

let package_env_default = { package_env_empty with ty = top_env_default.ty }

let package_to_top (x : PrepassPackageEnv) = {
    nominals_next_tag = 0
    nominals = Map.foldBack (fun _ -> Map.foldBack Map.add) x.nominals Map.empty
    prototypes_next_tag = 0
    prototypes_instances = Map.foldBack (fun _ -> Map.foldBack Map.add) x.prototypes_instances Map.empty
    ty = x.ty
    term = x.term
    }

let top_to_package package_id (small : PrepassTopEnv) (big : PrepassPackageEnv): PrepassPackageEnv = {
    nominals = Map.add package_id small.nominals big.nominals
    prototypes_instances = Map.add package_id small.prototypes_instances big.prototypes_instances
    ty = small.ty
    term = small.term
    }

type FileStream = abstract member Run : InferResult Stream -> PrepassTopEnv Promise * FileStream
let prepass package_id module_id top_env =
    let rec main r =
        {new FileStream with
            member _.Run x = 
                let r = r()
                let rec loop top_env top_env_adds old_results = function
                    | Nil -> Job.result (top_env_adds, [])
                    | Cons(x : InferResult,xs) ->
                        x.filled_top >>= fun filled_top ->
                        match old_results with
                        | (filled_top',top_env,top_env_adds as r) :: rs when Object.ReferenceEquals(filled_top,filled_top') -> 
                            xs >>= loop top_env top_env_adds rs >>- fun (q,rs) -> q,r :: rs
                        | _ -> 
                            let top_env, top_env_adds =
                                match (prepass package_id module_id top_env).filled_top filled_top with
                                | AOpen adds -> Prepass.union adds top_env, top_env_adds
                                | AInclude adds -> Prepass.union adds top_env, Prepass.union adds top_env_adds
                            xs >>= loop top_env top_env_adds [] >>- fun (q,rs) -> q, (filled_top, top_env, top_env_adds) :: rs
                let l = 
                    top_env >>=* fun top_env ->
                    x >>= loop top_env top_env_empty r
                l >>-* fst, main (fun () -> if l.Full then Promise.Now.get l |> snd else r)
            }
    main (fun () -> [])

type ModuleId = int
type DiffableFileHierarchy =
    | File of path: string * name: string option * meta: (ModuleId * PrepassTopEnv Promise) option * InferResult Stream * FileStream option
    | Directory of name: string * DiffableFileHierarchy list

type MultiFileStream = 
    abstract member Run : DiffableFileHierarchy list -> PrepassTopEnv Promise * MultiFileStream

// Rather than just throwing away the old results, diff returns the new tree with as much useful info from the old tree as is possible.
let diff_order_changed old new' =
    let mutable same_files = true
    let mutable same_order = true
    let rec elem (o,n) = 
        match o,n with
        // In `n`, `meta` and `tc` fields are None.
        | File(path,name,_,p,tc) & o,File(path',name',_,p',_) when path = path' && name = name' -> 
            if same_files then 
                if Object.ReferenceEquals(p,p') then o
                else same_files <- false; File(path,name,None,p',tc)
            else File(path,name,None,p',None)
        | Directory(name,l), Directory(name',l') when name = name' -> Directory(name,list (l,l'))
        | _, n -> same_order <- false; n
    and list = function
        | o :: o', n :: n' -> elem (o,n) :: (if same_order then list (o', n') else n')
        | [], [] -> []
        | _, n -> same_order <- false; n
    list (old,new')

let multi_file package_id top_env =
    let rec create files' =
        let run files = 
            let rec changed (module_id,top_env as i) x =
                match x with
                | File(_,_,Some o,_,_) -> x, o
                | File(path,name,None,results_infer,pr) ->
                    let pr = match pr with Some tc -> tc | None -> prepass package_id module_id top_env
                    let r,pr = pr.Run(results_infer)
                    let top_env_adds = 
                        match name with
                        | Some name -> r >>-* fun adds -> Prepass.in_module name adds
                        | None -> r
                    let o = module_id+1, top_env_adds
                    File(path,name,Some o,results_infer,Some pr),o
                | Directory(name,l) ->
                    let l,(module_id,top_env_adds) = changed_list i l
                    let o = module_id, top_env_adds >>-* Prepass.in_module name
                    Directory(name,l),o
            and changed_list (module_id,top_env) l =
                let o = module_id, Promise(top_env_empty)
                let l,(_,o) =
                    List.mapFold (fun (top_env, (module_id, top_env_adds as o)) x ->
                        let i = module_id, top_env
                        let x,(module_id,top_env_adds') = changed i x
                        let union a b = a >>=* fun a -> b >>- fun b -> Prepass.union a b
                        let top_env = union top_env_adds' top_env
                        let o = module_id, union top_env_adds' top_env_adds
                        x,(top_env,o)
                        ) (top_env,o) l
                l,o
            let i = 0, top_env
            let l,(_,top_env_adds) = changed_list i files 
            top_env_adds, create l
        {new MultiFileStream with member _.Run files = diff_order_changed files' files |> run}
    create []