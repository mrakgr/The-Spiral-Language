module Spiral.PartEval

// Global open
open System
open System.Collections.Generic
open Parsing
open Types

// Globals
let join_point_dict_method = d0()
let join_point_dict_closure = d0()
let join_point_dict_type = d0()
let join_point_dict_cuda = d0()

let rec spiral_partial_eval (d: LangEnv) x = 
    let inline ev d x = spiral_partial_eval d x

    let inline v x = let l = d.env_global.Length in if x < l then d.env_global.[x] else d.env_stack.[x - l]
    let inline push_var x =
        d.env_stack.[d.env_stack_ptr] <- x
        {d with env_stack_ptr=d.env_stack_ptr+1}

    match x with
    | V(_, x) -> v x
    | Lit(_,x) -> TyLit x
    | Open(_,x,l,on_succ) -> 
        let map_get = function TyMap x -> x | _ -> failwith "impossible"
        {d with 
            env_stack_ptr=
                Array.fold (fun s x -> (map_get s).[x]) (v x) l 
                |> map_get
                |> Map.fold (fun ptr _ x -> d.env_stack.[ptr] <- x; ptr+1) d.env_stack_ptr
                }
        |> fun d -> ev d on_succ
    | Function(_,on_succ,free_vars,stack_size) -> TyFunction(on_succ,stack_size,Array.map v free_vars)
    | RecFunction(_,on_succ,free_vars,stack_size) -> TyRecFunction(on_succ,stack_size,Array.map v free_vars)
    | ObjectCreate(dict,free_vars) -> TyObject(dict,Array.map v free_vars)
    | KeywordCreate(_,keyword,l) -> TyKeyword(keyword,Array.map (ev d) l)
    | Let(_,bind,on_succ) -> ev (ev d bind |> push_var) on_succ

    //| Case of Tag * bind: Expr * on_succ: Expr
    //| If of Tag * cond: Expr * on_succ: Expr * on_fail: Expr
    //| ListTakeAllTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| ListTakeNTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| KeywordTest of Tag * KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordTest of Tag * RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordWith of Tag * Expr [] * RecordWithPattern []
    //| ExprPos of Tag * Pos<Expr>
    //| Op of Tag * Op * Expr []
