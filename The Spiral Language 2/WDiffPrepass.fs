module Spiral.WDiffPrepass

open VSCTypes
open Spiral
open Spiral.WDiff
open Spiral.Infer
open Spiral.PartEval
open Spiral.PartEval.Prepass

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type PrepassStateValue = InferResult * PrepassTopEnv AdditionType * PrepassTopEnv
type PrepassStatePropagated = PrepassTopEnv Promise
type PrepassState = FileState<PackageId * ModuleId * string * TypecheckerStateValue Stream, PrepassStateValue Stream, PrepassStatePropagated>

let rec prepass (package_id,module_id,path,env) = function
    | Cons((_,r,_) : TypecheckerStateValue, ls) ->
        r.filled_top >>- fun filled_top -> 
        let x = (Prepass.prepass package_id module_id path env).filled_top filled_top
        let adds = match x with AOpen x | AInclude x -> x
        let env = union adds env
        Cons((r,x,env),ls >>=* prepass (package_id,module_id,path,env))
    | Nil ->
        Job.result Nil

let rec diff (package_id,module_id,path,env) (result,input : TypecheckerStateValue Stream) = 
    input >>** fun input ->
    let tc () = prepass (package_id,module_id,path,env) input |> Hopac.memo
    if Promise.Now.isFulfilled result then
        match Promise.Now.get result,input with
        | Cons((b',_,env as x),next), Cons((_,b,_),bs) when b' = b -> Cons(x,diff (package_id,module_id,path,env) (next,bs)) |> Promise.Now.withValue
        | _ -> tc()
    else tc()

let funs_file_prepass = {new FileFuns<PackageId * ModuleId * string * TypecheckerStateValue Stream, PrepassStateValue Stream, PrepassStatePropagated> with
    member _.eval(state,(pid,mid,path,x)) = 
        state >>=* fun env -> 
        x >>= prepass (pid,mid,path,env)
    member _.diff(state,b,(pid,mid,path,a)) =
        state >>=* fun env -> diff (pid,mid,path,env) (b,a)
    member _.init x = {
        input = x
        result = Promise.Now.never()
        state = Promise.Now.never()
        }
    }

let prepass_results_summary l =
    Stream.foldFun (fun big (_,x,_) ->
        match x with
        | AOpen _ -> big
        | AInclude small -> union small big
        ) (top_env_empty) l

let funs_proj_file_prepass = {new ProjFileFuns<PrepassState,PrepassStatePropagated> with
    member _.file(name,state,x) = 
        let x = wdiff_file_update_state funs_file_prepass x state
        let env = 
            prepass_results_summary x.result >>-* fun env -> 
            match name with None -> env | Some name -> in_module name env
        x,env
    member _.union(small,big) = small >>=* fun small -> big >>- fun big -> union small big
    member _.in_module(name,small) = small >>-* in_module name
    member _.default' default_env = Promise.Now.withValue (top_env_default default_env)
    member _.empty = Promise.Now.withValue top_env_empty
    }

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

let package_to_file (x : PrepassPackageEnv) = {
    nominals_next_tag = 0
    nominals = Map.foldBack (fun _ -> Map.foldBack Map.add) x.nominals Map.empty
    prototypes_next_tag = 0
    prototypes_instances = Map.foldBack (fun _ -> Map.foldBack Map.add) x.prototypes_instances Map.empty
    ty = x.ty
    term = x.term
    }

let add_file_to_package package_id (small : PrepassTopEnv) (big : PrepassPackageEnv): PrepassPackageEnv = {
    nominals = Map.add package_id small.nominals big.nominals
    prototypes_instances = Map.add package_id small.prototypes_instances big.prototypes_instances
    ty = small.ty
    term = small.term
    }

let package_env_default default_env = { package_env_empty with ty = (top_env_default default_env).ty }

type ProjStatePrepass = ProjState<PrepassState,PrepassStatePropagated,PrepassPackageEnv Promise>
let funs_proj_package_prepass = {new ProjPackageFuns<PrepassStatePropagated,PrepassPackageEnv Promise> with
    member funs.unions default_env l = 
        let f = function Some name, small -> funs.in_module(name,small) | None, small -> small
        List.fold (fun big x -> funs.union(f x,big)) (funs.default' default_env) l
    member _.union(small,big) = 
        Job.delay <| fun () ->
            Hopac.queueIgnore big
            small >>= fun a -> big >>- union a
        |> Hopac.memo
    member _.in_module(name,x) = x >>-* fun env -> in_module name env
    member _.package_to_file(x) = x >>-* package_to_file
    member _.add_file_to_package(pid,a,b) = 
        a >>=* fun env ->
        b >>-* add_file_to_package pid env
    member _.default' default_env = Promise.Now.withValue (package_env_default default_env)
    member _.empty = Promise.Now.withValue package_env_empty
    }