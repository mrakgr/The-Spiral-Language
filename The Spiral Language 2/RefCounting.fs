// Here are the reference counting analysis passes.
module Spiral.RefCounting

open Spiral.BlockParsing
open Spiral.PartEval.Main
open System.Collections.Generic

let varc_add x i v =
    let c = Option.defaultValue 0 (Map.tryFind x v) + i
    if c = 0 then Map.remove x v else Map.add x c v
let varc_union a b = Map.foldBack varc_add a b
let varc_data call_data =
    let mutable v = Map.empty
    let rec f = function
        | DPair(a,b) -> f a; f b
        | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
        | DRecord l -> Map.iter (fun _ -> f) l
        | DV x -> v <- varc_add x 1 v
        | DExists(_,a) | DUnion(a,_) | DNominal(a,_) -> f a
        | DLit _ | DTLit _ | DSymbol _ | DB -> ()
        | DHashSet x -> Seq.iter f x
        | DHashMap(x,_) -> x |> Seq.iter (fun kv -> f kv.Value)
    f call_data
    v
let varc_set x i = Set.fold (fun s v -> Map.add v i s) Map.empty x

let refc_used_vars (x : TypedBind []) =
    let g_bind : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
    let fv x = x |> data_free_vars |> Set
    let jp (x : JoinPointCall) = snd x |> Set
    let rec binds x =
        Array.foldBack (fun k vs ->
            match k with
            | TyLet(d,_,o) -> vs + op o - fv d
            | TyLocalReturnOp(_,o,_) -> vs + op o
            | TyLocalReturnData(d,_) -> vs + fv d
            |> fun vs -> g_bind.Add(k,vs); vs
            ) x Set.empty
    and op (x : TypedOp) : TyV Set =
        match x with
        | TySizeOf _ -> Set.empty
        | TyMacro l -> List.fold (fun s -> function CMTerm d -> s + fv d | _ -> s) Set.empty l
        | TyArrayLiteral(_,l) | TyOp(_,l) -> List.fold (fun s x -> s + fv x) Set.empty l
        | TyLayoutToHeap(x,_) | TyLayoutToHeapMutable(x,_)
        | TyUnionBox(_,x,_) | TyFailwith(_,x) | TyConv(_,x) | TyArrayCreate(_,x) | TyArrayLength(_,x) | TyStringLength(_,x) -> fv x
        | TyWhile(cond,body) -> jp cond + binds body
        | TyLayoutIndexAll(i) | TyLayoutIndexByKey(i,_) -> Set.singleton i
        | TyApply(i,d) | TyLayoutHeapMutableSet(i,_,d) -> Set.singleton i + fv d
        | TyJoinPoint x -> jp x
        | TyBackend(_,_,_) -> Set.empty
        | TyIf(cond,tr',fl') -> fv cond + binds tr' + binds fl'
        | TyUnionUnbox(vs,_,on_succs',on_fail') ->
            let vs = vs |> Set
            let on_fail = 
                match on_fail' with
                | Some x -> binds x
                | None -> Set.empty
            Map.fold (fun s k (lets,body) -> 
                let lets = List.fold (fun s x -> s + fv x) Set.empty lets
                s + (binds body - lets)
                ) (vs + on_fail) on_succs'
        | TyIntSwitch(tag,on_succs',on_fail') ->
            let vs = Set.singleton tag
            let on_fail = binds on_fail'
            Array.fold (fun s body -> s + binds body) (vs + on_fail) on_succs'
    binds x |> ignore
    g_bind

type RefcVars = {g_incr : Dictionary<TypedBind,TyV Set>; g_decr : Dictionary<TypedBind,TyV Set>; g_op : Dictionary<TypedBind,Map<TyV, int>>; g_op_decr : Dictionary<TypedBind,TyV Set>}

let refc_prepass (new_vars : TyV Set) (increfed_vars : TyV Set) (x : TypedBind []) =
    let used_vars = refc_used_vars x
    let g_incr : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
    let g_decr : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
    let g_op : Dictionary<TypedBind, _> = Dictionary(HashIdentity.Reference)
    let g_op_decr : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)

    let add (d : Dictionary<TypedBind, TyV Set>) k x = if Set.isEmpty x then () else d.Add(k,x)
    let add' (d : Dictionary<TypedBind, Map<TyV,int>>) k x = if Map.isEmpty x then () else d.Add(k,x)
    let fv x = x |> data_free_vars |> Set
    let rec binds (new_vars : TyV Set) (increfed_vars : TyV Set) (k : TypedBind []) =
        Array.fold (fun (new_vars, increfed_vars) k ->
            add g_incr k new_vars
            let increfed_vars = new_vars + increfed_vars

            let used_vars = used_vars.[k]
            let decref_vars = increfed_vars - used_vars
            add g_decr k decref_vars
            let r = increfed_vars - decref_vars
            match k with
            | TyLet(d,_,o) ->
                op k Set.empty o
                let new_vars = fv d
                match o with
                | TyLayoutIndexAll _ | TyLayoutIndexByKey _ | TyOp(ArrayIndex,_) -> new_vars, r
                | _ -> Set.empty, r + new_vars
            | TyLocalReturnOp(_,o,_) -> 
                op k r o
                Set.empty, r
            | TyLocalReturnData(d,_) ->
                add' g_op k (varc_data d)
                add g_op_decr k r
                Set.empty, r
            ) (new_vars, increfed_vars) k
        |> ignore
    and op k increfed_vars (x : TypedOp) : unit =
        let fun_call q = add' g_op k q; add g_op_decr k increfed_vars
        match x with
        | TyApply(a,b) -> varc_add a 1 (varc_data b) |> fun_call
        | TyJoinPoint(_,x) -> Array.fold (fun s x -> varc_add x 1 s) Map.empty x |> fun_call
        | TyArrayLiteral(_,x) -> List.fold (fun s x -> varc_union s (varc_data x)) Map.empty x |> fun_call
        | TyUnionBox(_,x,_) | TyLayoutToHeapMutable(x,_) | TyLayoutToHeap(x,_) -> varc_data x |> fun_call
        | TySizeOf _ | TyLayoutIndexAll _ | TyLayoutIndexByKey _ | TyMacro _ | TyOp _ | TyFailwith _ | TyConv _ 
        | TyArrayCreate _ | TyArrayLength _ | TyStringLength _ | TyLayoutHeapMutableSet _ | TyBackend _ -> ()
        | TyWhile(_,body) -> binds Set.empty Set.empty body
        | TyIf(_,tr',fl') -> binds Set.empty increfed_vars tr'; binds Set.empty increfed_vars fl'
        | TyUnionUnbox(_,_,on_succs',on_fail') ->
            Map.iter (fun _ (lets,body) -> 
                binds (List.fold (fun s x -> s + fv x) Set.empty lets) increfed_vars body
                ) on_succs'
            Option.iter (binds Set.empty increfed_vars) on_fail'
        | TyIntSwitch(_,on_succs',on_fail') ->
            Array.iter (binds Set.empty increfed_vars) on_succs'
            binds Set.empty increfed_vars on_fail'
    binds new_vars increfed_vars x
    
    {g_incr=g_incr; g_op=g_op; g_decr=g_decr; g_op_decr=g_op_decr}
