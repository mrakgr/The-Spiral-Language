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
let tyt_to_tyv ty = 
    if ty_is_unit ty then TyT ty
    else TyV (tag_get(), ty)
    |> destructure

let push_var (d: LangEnv) x =
    d.env_stack.[d.env_stack_ptr] <- x
    {d with env_stack_ptr=d.env_stack_ptr+1}

let rec partial_eval (d: LangEnv) x = 
    let inline ev d x = partial_eval d x

    let inline v x = let l = d.env_global.Length in if x < l then d.env_global.[x] else d.env_stack.[x - l]

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
        let v = ev d bind
        let rewrite_key = (TypeUnbox, v)
        match Map.tryFind rewrite_key !d.cse with
        | Some v -> ev (push_var d v) on_succ
        | None ->
            match v with
            | TyBox(b,_) -> ev (push_var d b) on_succ
            | (TyV(_, t & (UnionT _ | RecUnionT _)) | TyT(t & (UnionT _ | RecUnionT _))) ->
                let inline ev_case r_ty' x =
                    let d = {d with seq=ResizeArray(); cse=ref (Map.add rewrite_key x !d.cse)}
                    let r = ev (push_var d x) on_succ
                    let r_ty = type_get r
                    match r_ty' with
                    | Some r_ty' -> if r_ty <> r_ty' then raise_type_error d <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\nGot: %s and %s" (show_ty a) (show_ty b)
                    | None -> ()
                    if d.seq.Count > 0 then
                        match d.seq.[d.seq.Count-1] with
                        | TyLet(r',a,b) when Object.ReferenceEquals(r,r') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
                        | _ -> d.seq.Add(TyLocalReturnData(r,r_ty,d.trace))
                    (x, d.seq.ToArray()), Some r_ty
                  
                case_type d t 
                |> List.map tyt_to_tyv 
                |> List.mapFold ev_case None
                |> fun (a,b) -> TyCase(v,List.toArray a,b.Value)
                |> make_tyv_and_push_typed_expr_even_if_unit d
            | v -> ev (push_var d v) on_succ

    //| Case of Tag * bind: Expr * on_succ: Expr
    //| If of Tag * cond: Expr * on_succ: Expr * on_fail: Expr
    //| ListTakeAllTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| ListTakeNTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| KeywordTest of Tag * KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordTest of Tag * RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordWith of Tag * Expr [] * RecordWithPattern []
    //| ExprPos of Tag * Pos<Expr>
    //| Op of Tag * Op * Expr []
