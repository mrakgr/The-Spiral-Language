module Spiral.PartEval

// Global open
open System
open System.Collections.Generic
open Parsing
open Types

// Globals
let private join_point_dict_method = Dictionary(HashIdentity.Structural)
let private join_point_dict_closure = Dictionary(HashIdentity.Structural)
let private join_point_dict_type = Dictionary(HashIdentity.Structural)
let private join_point_dict_cuda = Dictionary(HashIdentity.Structural)

let private hash_cons_table = HashConsing.hashcons_create 0
let private hash_cons_add x = HashConsing.hashcons_add hash_cons_table x

let mutable private tag = 0

let raise_type_error (d: LangEnv) x = raise (TypeError(d.trace,x))
let rect_unbox d key = 
    match join_point_dict_type.[key] with
    | JoinPointInEvaluation () -> raise_type_error d "Types that are being constructed cannot be used for boxing."
    | JoinPointDone ty -> ty

let case_type_union = function
    | UnionT l -> Set.toList l.node
    | x -> [x]

let case_type d = function
    | RecUnionT key -> case_type_union (rect_unbox d key.node)
    | x -> case_type_union x

let tag_get () = tag <- tag+1; tag
let tyv ty = TyV (tag_get(), ty)

let rec destructure tyv_or_tyt x =
    let inline f x = destructure tyv_or_tyt x
    match x with
    | ListT x -> TyList(List.map f x.node)
    | KeywordT(C(a,l)) -> TyKeyword(a,Array.map f l)
    | FunctionT(C(a,b,l)) -> TyFunction(a,b,Array.map f l)
    | RecFunctionT(C(a,b,l)) -> TyRecFunction(a,b,Array.map f l)
    | ObjectT(C(a,l)) -> TyObject(a,Array.map f l)
    | MapT l -> TyMap(Map.map (fun _ -> f) l.node)
    | x -> tyv_or_tyt x
   
let tyt_to_tyv ty = if ty_is_unit ty then destructure TyT ty else destructure tyv ty

let push_var (d: LangEnv) x =
    d.env_stack.[d.env_stack_ptr] <- x
    {d with env_stack_ptr=d.env_stack_ptr+1}

let rec partial_eval (d: LangEnv) x = 
    let inline ev d x = partial_eval d x

    let inline v x = let l = d.env_global.Length in if x < l then d.env_global.[x] else d.env_stack.[x - l]
    let inline seq_end_align (end_dat,end_ty) (seq: ResizeArray<_>) =
        if d.seq.Count > 0 then
            match seq.[d.seq.Count-1] with
            | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
            | _ -> d.seq.Add(TyLocalReturnData(end_dat,end_ty,d.trace))

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
    | Let(_,bind,on_succ) -> ev (ev d bind |> push_var d) on_succ
    | Case(_,bind,on_succ) ->
        match ev d bind with
        | TyBox(b,_) -> ev (push_var d b) on_succ
        | (TyV(_, t & (UnionT _ | RecUnionT _)) | TyT(t & (UnionT _ | RecUnionT _))) as v ->
            let rewrite_key = TypeUnbox, v
            match Map.tryFind rewrite_key !d.cse with
            | Some v -> ev (push_var d v) on_succ
            | None ->
                let inline ev_case end_ty' x =
                    let x = tyt_to_tyv x
                    let d = {d with seq=ResizeArray(); cse=ref (Map.add rewrite_key x !d.cse)}
                    let end_dat = ev (push_var d x) on_succ
                    let end_ty = type_get end_dat
                    match end_ty' with
                    | Some end_ty' -> if end_ty' <> end_ty then raise_type_error d <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\nGot: %s and %s" (show_ty end_ty') (show_ty end_ty)
                    | None -> ()
                    seq_end_align (end_dat, end_ty) d.seq
                    (x, d.seq.ToArray()), Some end_ty
                
                let cases, end_ty = case_type d t |> List.mapFold ev_case None
                let end_ty = end_ty.Value
                let end_dat = tyt_to_tyv end_ty
                d.seq.Add(TyLet(end_dat,d.trace,TyCase(v,List.toArray cases,end_ty)))
                end_dat
        | v -> ev (push_var d v) on_succ

    //| If of Tag * cond: Expr * on_succ: Expr * on_fail: Expr
    //| ListTakeAllTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| ListTakeNTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| KeywordTest of Tag * KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordTest of Tag * RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordWith of Tag * Expr [] * RecordWithPattern []
    //| ExprPos of Tag * Pos<Expr>
    //| Op of Tag * Op * Expr []
