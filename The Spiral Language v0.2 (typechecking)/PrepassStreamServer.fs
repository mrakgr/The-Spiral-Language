module Spiral.StreamServer.Prepass

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.PartEval
open Spiral.Infer
open Spiral.PartEval.Prepass
open Spiral.StreamServer.Main

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

type FileStream = EditorStream<InferResult Stream, PrepassTopEnv Promise>
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
type DiffableFileHierarchy = DiffableFileHierarchyT<(PrepassTopEnv Promise * (ModuleId * PrepassTopEnv Promise)) option * InferResult Stream * FileStream option>
type ModuleTarget = string
type HasChanged = bool
type MultiFileStream = EditorStream<DiffableFileHierarchy list * ModuleTarget,HasChanged * PrepassTopEnv Promise option * PrepassTopEnv Promise>

let multi_file package_id top_env =
    let rec create files' =
        {new MultiFileStream with
            member _.Run((files,target)) =
                let files = diff_order_changed files' files
                let mutable res = None
                let mutable changed = false
                let on_unchanged path r = if path = target then res <- Some r
                let on_changed path r = on_unchanged path r; changed <- true
                let x, files = multi_file_run on_unchanged on_changed top_env_empty prepass id Prepass.union Prepass.in_module package_id top_env files
                (changed, res, x), create files
            }
    create []

open Spiral.ServerUtils


type PackageStream = EditorStream<Map<PackageName,DiffableFileHierarchy list * PackageLinks * PackageId> * PackageName seq * ModuleTarget, PrepassTopEnv Promise option>

type PackageItem = {
    env_in : PrepassPackageEnv Promise
    env_out : PrepassPackageEnv Promise
    links : Map<PackagePath,PackageName>
    stream : MultiFileStream
    id : PackageId
    }
let package = // TODO: This is broken.
    let rec loop (s : Map<PackageName, PackageItem>) =
        {new PackageStream with
            member _.Run((packages,order,target)) = 
                Seq.fold (fun (s,has_changed,_) n ->
                    let old_package = Map.tryFind n s
                    let files, links, id = packages.[n]
                    let is_dirty_prev = Map.exists (fun k _ -> Set.contains k has_changed) links = false
                    let env_in = 
                        let f() =
                            let l = links |> Map.fold (fun l k v -> ((Map.find k s).env_out >>-* in_module v) :: l) [] |> Job.conCollect
                            l >>-* Seq.fold union package_env_default
                        if is_dirty_prev then f()
                        else match old_package with Some p -> p.env_in | None -> f()
                    let is_dirty_cur, ((is_dirty_file,target_res,top_env_out), stream) =
                        match old_package with
                        | Some p when is_dirty_prev = false && id = p.id && links = p.links -> false, p.stream.Run(files,target)
                        | _ -> true, (multi_file id (env_in >>-* package_to_top)).Run(files,target)
                    let env_out = top_env_out >>=* fun top_env_out -> env_in >>- fun env_in -> top_to_package id top_env_out env_in
                    let s = 
                        let x = {env_in = env_in; env_out = env_out; stream = stream; id = id; links = links}
                        Map.add n x s 
                    let has_changed = if is_dirty_prev || is_dirty_cur || is_dirty_file then Set.add n has_changed else has_changed
                    s, has_changed, target_res
                    ) (s,Set.empty,None) order
                |> fun (_,_,target_res) -> target_res, loop s
            }
    loop Map.empty