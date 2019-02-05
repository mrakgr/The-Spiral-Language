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

let mutable tag = 0

let raise_type_error x = failwith x

let rect_unbox key = 
    match join_point_dict_type.[key] with
    | JoinPointInEvaluation () -> raise_type_error "Types that are being constructed cannot be used for boxing otherwise the compiler would diverge."
    | JoinPointDone ty -> ty

let case_type_union = function
    | UnionT l -> Set.toList l.node
    | x -> [x]

let case_type = function
    | RecUnionT key -> case_type_union (rect_unbox key.node)
    | x -> case_type_union x

let tag_get () = tag <- tag+1; tag
let tyt_to_tyv ty = 
    if ty_is_unit ty then TyT ty
    else TyV (tag_get(), ty)

let rec partial_eval (d: LangEnv) x = 
    let inline ev d x = partial_eval d x

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
    | Case(_,bind,on_succ) ->
        let v = ev d bind
        let rewrite_key = (TypeUnbox, v)
        match Map.tryFind rewrite_key !d.cse with
        | Some v -> ev (push_var v) on_succ
        | None ->
            match v with
            | TyBox(b,_) -> ev (push_var b) on_succ
            | (TyV(_, t & (UnionT _ | RecUnionT _)) | TyT(t & (UnionT _ | RecUnionT _))) ->
                let inline ev_case x =
                    let d = {d with seq=ResizeArray(); cse=ref (Map.add rewrite_key x !d.cse)}
                    let r = ev (push_var' d x) on_succ
                    if d.seq.Count > 0 then
                        match d.seq.[d.seq.Count-1] with
                        | TyLet(r',a,b,c) when Object.ReferenceEquals(r,r') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b,c)
                        | _ -> d.seq.Add(TyLocalReturnData(r,get_type r,d.trace))
                    d.seq.ToArray()
                    
                match case_type t |> List.map tyt_to_tyv |> List.map (fun x -> x, ev_case x) with
                | (_, statements) :: cases as cases' -> 
                    if List.forall (fun (_, TyType x) -> x = p) cases then 
                        TyOp(Case,v :: List.collect (fun (a,b) -> [a;b]) cases', p) 
                        |> make_tyv_and_push_typed_expr_even_if_unit d
                    else 
                        let l = List.map (snd >> get_type) cases'
                        on_type_er (trace d) <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\nGot: %s" (listt l |> show_ty)
                | _ -> failwith "There should always be at least one clause here."
            | v -> ev (push_var v) on_succ


    //| Case of Tag * bind: Expr * on_succ: Expr
    //| If of Tag * cond: Expr * on_succ: Expr * on_fail: Expr
    //| ListTakeAllTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| ListTakeNTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| KeywordTest of Tag * KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordTest of Tag * RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordWith of Tag * Expr [] * RecordWithPattern []
    //| ExprPos of Tag * Pos<Expr>
    //| Op of Tag * Op * Expr []
