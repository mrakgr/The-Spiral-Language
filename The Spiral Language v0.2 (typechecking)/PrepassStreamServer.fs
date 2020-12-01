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
type DiffableFileHierarchy = 
    DiffableFileHierarchyT<
        (PrepassTopEnv Promise * (ModuleId * PrepassTopEnv Promise)) option * InferResult Stream * FileStream option,
        (ModuleId * PrepassTopEnv Promise) option
        >
type ModuleTarget = string
type HasChanged = bool
type MultiFileStream = EditorStream<DiffableFileHierarchy list * ModuleTarget,PrepassTopEnv Promise option * PrepassTopEnv Promise>

let multi_file package_id top_env =
    let rec create files' =
        {new MultiFileStream with
            member _.Run((files,target)) =
                let files = diff_order_changed files' files
                let mutable res = None
                let on_res path r = if path = target then res <- Some r
                let x, files = multi_file_run on_res on_res top_env_empty prepass id Prepass.union Prepass.in_module package_id top_env files
                (res, x), create files
            }
    create []

type ModulePath = string
type PackageId = int
type PackageMultiFileLinks = Map<PackagePath,PackageName * PrepassPackageEnv Promise>
type PackageMultiFileStreamAux = EditorStream<DiffableFileHierarchy list * ModuleTarget, PrepassPackageEnv Promise option * PrepassPackageEnv Promise>
type PackageMultiFileStream = EditorStream<PackageId * PackageMultiFileLinks * (DiffableFileHierarchy list * ModuleTarget), PrepassPackageEnv Promise option * PrepassPackageEnv Promise>

let package_multi_file post_process_result multi_file package_env_default union in_module top_to_package package_to_top =
    let make_new_stream (id : PackageId) links =
        let package_env_in = 
            let l = Map.fold (fun l k (name,env_out) -> (env_out >>-* in_module name) :: l) [] links |> Job.conCollect
            l >>-* Seq.fold union package_env_default
        let rec loop (top_env_out',env_out') (multi_file : EditorStream<_,_>) =
            {new EditorStream<_,_> with
                member _.Run x =
                    let (result,top_env_out),multi_file = multi_file.Run(x)
                    let f package_env_in env_out = env_out >>=* fun env_out -> package_env_in >>- fun package_env_in -> top_to_package id env_out package_env_in
                    let env_out = if top_env_out = top_env_out' then env_out' else f package_env_in top_env_out
                    let target = post_process_result (f package_env_in) result
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

type PackageStream = EditorStream<Map<PackageName,DiffableFileHierarchy list * PackageLinks * PackageId> * PackageName seq * ModuleTarget, PrepassPackageEnv Promise option>

type PackageItem = {
    env_out : PrepassPackageEnv Promise
    links : Map<PackagePath,PackageName>
    stream : PackageMultiFileStream
    id : PackageId
    }
let package =
    let rec loop (s : Map<PackageName, PackageItem>) =
        {new PackageStream with
            member _.Run((packages,order,target)) = 
                Seq.fold (fun (s,_) n ->
                    let old_package = Map.tryFind n s
                    let files, links, id = packages.[n]
                    let (target_res,env_out), stream =
                        let links = links |> Map.map (fun k v -> v, s.[k].env_out)
                        let files = files
                        match old_package with
                        | Some p -> p.stream.Run(id,links,(files,target))
                        | None -> (package_multi_file Option.map multi_file package_env_default union in_module top_to_package package_to_top).Run(id,links,(files,target))
                    let s = Map.add n {env_out = env_out; stream = stream; id = id; links = links} s
                    s, target_res
                    ) (s,None) order
                |> fun (_,target_res) -> target_res, loop s
            }
    loop Map.empty