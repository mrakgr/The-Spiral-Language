module Spiral.WDiff.Prepass

open VSCTypes
open Spiral
open Spiral.Infer
open Spiral.PartEval
open Spiral.PartEval.Prepass

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type PrepassStateValue = InferResult * PrepassTopEnv AdditionType * PrepassTopEnv
type [<ReferenceEquality>] PrepassState = {
    package_id : PackageId
    module_id : ModuleId
    path : string
    top_env : PrepassTopEnv Promise
    results : PrepassStateValue Stream
    input : TypecheckerStateValue Stream
    }

let rec prepass (package_id,module_id,path,env) = function
    | Cons((_,r,_) : TypecheckerStateValue, ls) ->
        r.filled_top >>- fun filled_top -> 
            let x = (Prepass.prepass package_id module_id path env).filled_top filled_top
            let adds = match x with AOpen x | AInclude x -> x
            let env = union adds env
            Cons((r,x,env),ls >>=* prepass (package_id,module_id,path,env))
    | Nil ->
        Job.result Nil

let wdiff_prepass_update_input (state : PrepassState) (input : TypecheckerStateValue Stream) =
    if state.input = input then state else
    let rec diff env (a,b : TypecheckerStateValue Stream) = 
        b >>=* fun b ->
        let tc () = prepass (state.package_id,state.module_id,state.path,env) b |> Hopac.memo
        if Promise.Now.isFulfilled a then
            match Promise.Now.get a,b with
            | Cons((b,_,env as x),next), Cons((_,b',_),bs) when b = b' -> Cons(x,diff env (next,bs)) |> Promise.Now.withValue
            | _ -> tc()
        else tc()

    let results = 
        state.top_env >>=* fun top_env ->
        diff top_env (state.results,input)
    {state with results = results; input = input}

let wdiff_prepass_update_state (state : PrepassState) (package_id,module_id,path,top_env) =
    if state.package_id = package_id && state.module_id = module_id && state.path = path && state.top_env = top_env then state else
    let results = 
        top_env >>=* fun top_env ->
        state.input >>= fun l -> prepass (package_id,module_id,path,top_env) l
    {state with results = results; top_env = top_env; package_id = package_id; module_id = module_id}

open Spiral.WDiff
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

let package_env_default = { package_env_empty with ty = top_env_default.ty }