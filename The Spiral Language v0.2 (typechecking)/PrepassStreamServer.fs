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

type PrepassFileStream = abstract member Run : InferResult Stream -> PrepassTopEnv Promise * PrepassFileStream
let prepass package_id module_id top_env =
    let rec main r =
        {new PrepassFileStream with
            member _.Run x = 
                let r = r()
                let rec loop top_env top_env_adds old_results = function
                    | Nil -> Job.result (top_env_adds, [])
                    | Cons(x : InferResult,ns) ->
                        x.filled_top >>= fun filled_top ->
                        match old_results with
                        | (filled_top',top_env,top_env_adds as r) :: rs when Object.ReferenceEquals(filled_top,filled_top') -> 
                            ns >>= loop top_env top_env_adds rs >>- fun (q,rs) -> q,r :: rs
                        | _ -> 
                            let top_env, top_env_adds =
                                match (prepass package_id module_id top_env).filled_top filled_top with
                                | AOpen adds -> Prepass.union adds top_env, top_env_adds
                                | AInclude adds -> Prepass.union adds top_env, Prepass.union adds top_env_adds
                            ns >>= loop top_env top_env_adds [] >>- fun (q,rs) -> q, (filled_top, top_env, top_env_adds) :: rs
                let l = x >>=* loop top_env top_env_empty r
                l >>-* fst, main (fun () -> if l.Full then Promise.Now.get l |> snd else r)
            }
    main (fun () -> [])