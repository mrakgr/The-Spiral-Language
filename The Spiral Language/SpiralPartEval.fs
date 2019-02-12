module Spiral.PartEval

// Global open
open System
open System.Collections.Generic
open Parsing
open Types
open System.Runtime.CompilerServices

// Globals
let join_point_dict_method = Dictionary(HashIdentity.Structural)
let join_point_dict_closure = Dictionary(HashIdentity.Structural)
let join_point_dict_type = Dictionary(HashIdentity.Structural)
let join_point_dict_cuda = Dictionary(HashIdentity.Structural)
let private layout_to_none_dict = ConditionalWeakTable()
let private layout_to_none_dict' = ConditionalWeakTable()
let private hash_cons_table = HashConsing.HashConsTable()

let mutable private part_eval_tag = 0
let private tag () = part_eval_tag <- part_eval_tag+1; part_eval_tag

let keyword_env = Parsing.string_to_keyword "env:" // For join points keys. It is assumed that they will never be printed.
let keyword_apply = Parsing.string_to_keyword "apply:"
let typed_data_to_consed' call_data =
    let dict = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray(64)
    let rec f x =
        memoize dict (function
            | TyList l -> List.map f l |> hash_cons_table.Add |> CTyList
            | TyKeyword(a,b) -> (a,Array.map f b) |> hash_cons_table.Add |> CTyKeyword
            | TyFunction(a,b,c) -> (a,b,Array.map f c) |> hash_cons_table.Add |> CTyFunction
            | TyRecFunction(a,b,c) -> (a,b,Array.map f c) |> hash_cons_table.Add |> CTyRecFunction
            | TyObject(a,b) -> (a,Array.map f b) |> hash_cons_table.Add |> CTyObject
            | TyMap l -> Map.map (fun _ -> f) l |> hash_cons_table.Add |> CTyMap
            | TyV(T(_,ty) as t) -> call_args.Add t; CTyV (call_args.Count-1, ty)
            | TyBox(a,b) -> (f a, b) |> CTyBox
            | TyLit x -> CTyLit x
            | TyT x -> CTyT x
            ) x
    call_args.ToArray(),f call_data

let typed_data_free_vars call_data =
    let dict = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray(64)
    let rec f x =
        memoize dict (function
            | TyList l -> List.iter f l
            | TyKeyword(a,b) -> Array.iter f b
            | TyFunction(a,b,c) -> Array.iter f c
            | TyRecFunction(a,b,c) -> Array.iter f c
            | TyObject(a,b) -> Array.iter f b
            | TyMap l -> Map.iter (fun _ -> f) l
            | TyBox(a,b) -> f a
            | TyV(T(_,ty) as t) -> call_args.Add t
            | TyLit _ | TyT _ -> ()
            ) x
    f call_data
    call_args.ToArray()

let typed_data_term_vars call_data =
    let dict = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray(64)
    let mutable has_naked_type = false
    let rec f x =
        memoize dict (function
            | TyList l -> List.iter f l
            | TyKeyword(a,b) -> Array.iter f b
            | TyFunction(a,b,c) -> Array.iter f c
            | TyRecFunction(a,b,c) -> Array.iter f c
            | TyObject(a,b) -> Array.iter f b
            | TyMap l -> Map.iter (fun _ -> f) l
            | TyBox(a,b) -> f a
            | TyLit _ | TyV _ as x -> call_args.Add x
            | TyT _ -> has_naked_type <- true
            ) x
    f call_data
    has_naked_type, call_args.ToArray()

let typed_data_to_consed call_data =
    let dict = Dictionary(HashIdentity.Reference)
    let mutable count = 0
    let rec f x =
        memoize dict (function
            | TyList l -> List.map f l |> hash_cons_table.Add |> CTyList
            | TyKeyword(a,b) -> (a,Array.map f b) |> hash_cons_table.Add |> CTyKeyword
            | TyFunction(a,b,c) -> (a,b,Array.map f c) |> hash_cons_table.Add |> CTyFunction
            | TyRecFunction(a,b,c) -> (a,b,Array.map f c) |> hash_cons_table.Add |> CTyRecFunction
            | TyObject(a,b) -> (a,Array.map f b) |> hash_cons_table.Add |> CTyObject
            | TyMap l -> Map.map (fun _ -> f) l |> hash_cons_table.Add |> CTyMap
            | TyV(T(_,ty) as t) -> count <- count+1; CTyV (count-1, ty)
            | TyBox(a,b) -> (f a, b) |> CTyBox
            | TyLit x -> CTyLit x
            | TyT x -> CTyT x
            ) x
    f call_data

let consed_typed_data_uncons' consed_data =
    let dict = Dictionary(HashIdentity.Reference)
    let consed_args = ResizeArray(64)
    let rec f x =
        memoize dict (function
            | CTyList l -> List.map f l.node |> TyList
            | CTyKeyword(C(a,b)) -> (a,Array.map f b) |> TyKeyword
            | CTyFunction(C(a,b,c)) -> (a,b,Array.map f c) |> TyFunction
            | CTyRecFunction(C(a,b,c)) -> (a,b,Array.map f c) |> TyRecFunction
            | CTyObject(C(a,b)) -> (a,Array.map f b) |> TyObject
            | CTyMap l -> Map.map (fun _ -> f) l.node |> TyMap
            | CTyV(t,ty) -> consed_args.Add(t,ty); TyV (T(tag(), ty))
            | CTyBox(a,b) -> (f a, b) |> TyBox
            | CTyLit x -> TyLit x
            | CTyT x -> TyT x
            ) x
    consed_args.ToArray(), f consed_data

let consed_typed_data_uncons consed_data =
    let dict = Dictionary(HashIdentity.Reference)
    let rec f x =
        memoize dict (function
            | CTyList l -> List.map f l.node |> TyList
            | CTyKeyword(C(a,b)) -> (a,Array.map f b) |> TyKeyword
            | CTyFunction(C(a,b,c)) -> (a,b,Array.map f c) |> TyFunction
            | CTyRecFunction(C(a,b,c)) -> (a,b,Array.map f c) |> TyRecFunction
            | CTyObject(C(a,b)) -> (a,Array.map f b) |> TyObject
            | CTyMap l -> Map.map (fun _ -> f) l.node |> TyMap
            | CTyV(_,ty) -> TyV (T(tag(), ty))
            | CTyBox(a,b) -> (f a, b) |> TyBox
            | CTyLit x -> TyLit x
            | CTyT x -> TyT x
            ) x
    f consed_data

let consed_typed_free_vars consed_data =
    let dict = Dictionary(HashIdentity.Reference)
    let consed_args = ResizeArray(64)
    let rec f x =
        memoize dict (function
            | CTyList l -> List.iter f l.node
            | CTyKeyword(C(_,l)) | CTyFunction(C(_,_,l)) | CTyRecFunction(C(_,_,l)) | CTyObject(C(_,l)) -> Array.iter f l
            | CTyMap l -> Map.iter (fun _ -> f) l.node
            | CTyBox(a,b) -> f a
            | CTyV(t,ty) -> consed_args.Add(t,ty)
            | CTyLit _  | CTyT _ -> ()
            ) x
    f consed_data
    consed_args.ToArray()

let raise_type_error (d: LangEnv) x = raise (TypeError(d.trace,x))
let rect_unbox d key = 
    match join_point_dict_type.[key] with
    | JoinPointInEvaluation _ -> raise_type_error d "Types that are being constructed cannot be used for boxing."
    | JoinPointDone(_,_,ty) -> ty

let case_type_union = function
    | UnionT l -> Set.toList l.node
    | x -> [x]

let case_type d = function
    | RecUnionT(_,key) -> case_type_union (rect_unbox d key)
    | x -> case_type_union x

let case_type_union' = function
    | UnionT l -> l.node
    | x -> Set.singleton x

let case_type' d = function
    | RecUnionT(_,key) -> case_type_union' (rect_unbox d key)
    | x -> case_type_union' x

let tyv ty = TyV(T(tag(), ty))
let tyb = TyList []

let type_non_units x =
    let args = ResizeArray(64)
    let rec f = function
        | ListT x -> List.iter f x.node
        | KeywordT(C(_,l)) | FunctionT(C(_,_,l)) | RecFunctionT(C(_,_,l)) | ObjectT(C(_,l)) -> Array.iter f l
        | MapT l -> Map.iter (fun _ -> f) l.node
        | x -> if type_is_unit x = false then args.Add x
    f x
    args.ToArray()

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
   
let type_to_tyv ty = if type_is_unit ty then destructure TyT ty else destructure tyv ty

let push_var x (d: LangEnv) =
    d.env_stack.[d.env_stack_ptr] <- x
    {d with env_stack_ptr=d.env_stack_ptr+1}

let seq_apply (d: LangEnv) end_dat =
    if d.seq.Count > 0 then
        match d.seq.[d.seq.Count-1] with
        | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
        | _ -> d.seq.Add(TyLocalReturnData(end_dat,d.trace))
    d.seq.ToArray()

let layout_to_none (d: LangEnv) = function
    | TyT(LayoutT(C(t,l,h))) | TyV(T(_,LayoutT(C(t,l,h)))) as v -> 
        if h then
            let key = LayoutToNone,v
            match Map.tryFind key !d.cse with
            | None ->
                let inline stmt x = TyLet(x,d.trace,TyLayoutToNone(v))
                match t with
                | LayoutHeapMutable ->
                    let x = consed_typed_data_uncons l 
                    d.seq.Add(stmt x)
                    x
                | _ ->
                    let x, stmt = memoize' layout_to_none_dict (consed_typed_data_uncons >> fun x -> x,stmt x) l 
                    d.seq.Add stmt
                    d.cse := Map.add key x !d.cse
                    x
            | Some x ->
                x
        else
            memoize' layout_to_none_dict' consed_typed_data_uncons l
    | a -> a

let layout_to_some layout (d: LangEnv) = function
    | TyT(LayoutT(C(t,l,h))) | TyV(T(_,LayoutT(C(t,l,h)))) as x when t = layout -> x
    | x ->
        let call_args, consed_data = typed_data_to_consed' (layout_to_none d x)
        let ret_ty = (layout,consed_data,call_args.Length > 0) |> hash_cons_table.Add |> LayoutT
        let ret = type_to_tyv ret_ty
        let layout =
            match layout with
            | LayoutStack -> LayoutToStack
            | LayoutHeap -> LayoutToHeap
            | LayoutHeapMutable -> LayoutToHeapMutable
        d.seq.Add(TyLet(ret,d.trace,TyOp(layout,x)))
        ret

let push_typedop d op ret_ty =
    let ret = type_to_tyv ret_ty
    d.seq.Add(TyLet(ret,d.trace,op))
    ret

let push_op_no_rewrite (d: LangEnv) op l ret_ty = push_typedop d (TyOp(op,l)) ret_ty
let push_binop_no_rewrite d op (a,b) ret_ty = push_op_no_rewrite d op (TyList [a;b]) ret_ty
let push_triop_no_rewrite d op (a,b,c) ret_ty = push_op_no_rewrite d op (TyList [a;b;c]) ret_ty

let push_op (d: LangEnv) op l ret_ty =
    let key = op,l
    match Map.tryFind key !d.cse with
    | Some x -> x
    | None ->
        let ret = type_to_tyv ret_ty
        d.seq.Add(TyLet(ret,d.trace,TyOp(op,l)))
        d.cse := Map.add key ret !d.cse
        ret

let push_binop d op (a,b) ret_ty = push_op d op (TyList [a;b]) ret_ty
let push_triop d op (a,b,c) ret_ty = push_op d op (TyList [a;b;c]) ret_ty
    
let rec partial_eval (d: LangEnv) x = 
    let inline ev d x = partial_eval d x
    let inline ev2 d a b = ev d a, ev d b
    let inline ev3 d a b c = ev d a, ev d b, ev d c
    let inline ev_seq d x =
        let x = ev {d with seq=ResizeArray()} x
        let x_ty = type_get x
        seq_apply d x, x_ty
    let inline ev_annot d x = ev_seq {d with cse=ref !d.cse} x |> snd
    
    let inline push_var_ptr ptr x = d.env_stack.[ptr] <- x; ptr+1
    let inline v x = let l = d.env_global.Length in if x < l then d.env_global.[x] else d.env_stack.[x - l]

    let inline list_test all_or_n (stack_size,bind,on_succ,on_fail) =
        let inline on_fail() = ev d on_fail
        match v bind with
        | TyList l ->
            if all_or_n then // all
                let rec loop d = function
                    | 1, l -> ev (push_var (TyList l) d) on_succ
                    | i, x :: x' -> loop (push_var x d) (i-1,x')
                    | _, [] -> on_fail()
                loop d (stack_size,l)
            else // n
                let rec loop d = function
                    | 0, [] -> ev d on_succ
                    | _, [] -> on_fail()
                    | i, x :: x' -> loop (push_var x d) (i-1,x')
                loop d (stack_size,l)
        | _ -> on_fail()

    let rec apply d = function
        | TyFunction(body,stack_size,env), b ->
            let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
            ev (push_var b d) body
        | TyRecFunction(body,stack_size,env) & a, b ->
            let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
            ev (push_var b d |> push_var a) body
        | TyMap l, TyKeyword(keyword,_) ->
            match Map.tryFind keyword l with
            | Some a -> a
            | None -> raise_type_error d <| sprintf "The record does not have the field %s." (keyword_to_string keyword)
        | TyMap _, b -> raise_type_error d <| sprintf "The second argument to a record application is not a keyword.\nGot: %s" (show_typed_data b)
        | TyObject(dict,env) & a, TyKeyword(keyword,_) & b ->
            match dict.TryGetValue keyword with
            | true, (body, stack_size) ->
                let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
                ev (push_var a d |> push_var b) body
            | false, _ -> raise_type_error d <| sprintf "The object does not have the receiver for %s." (keyword_to_string keyword)
        | TyObject(dict,env) & a, b ->
            match dict.TryGetValue keyword_apply with
            | true, (body, stack_size) ->
                let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
                ev (push_var a d |> push_var (TyKeyword(keyword_apply,[|b|]))) body
            | false, _ -> raise_type_error d <| sprintf "The second argument to an object application is not a keyword nor is there a receiver for `apply:`.\nGot: %s" (show_typed_data b)
        | (TyV(T(_,LayoutT _)) | TyT(LayoutT _)) & a, b -> apply d (layout_to_none d a, b)
        | (TyV(T(_,TermCastedFunctionT(clo_arg_ty,clo_ret_ty))) | TyT(TermCastedFunctionT(clo_arg_ty,clo_ret_ty))) & a, b -> 
            let b_ty = type_get b
            if clo_arg_ty <> b_ty then raise_type_error d <| sprintf "Cannot apply an argument of type %s to closure (%s => %s)." (show_ty b_ty) (show_ty clo_arg_ty) (show_ty clo_ret_ty)
            else push_op_no_rewrite d Apply (TyList [a;b]) clo_ret_ty
        | a, _ -> raise_type_error d <| sprintf "The first argument provided cannot be applied.\nGot: %s" (show_typed_data a)

    let inline prim_bin_op_template d check_error is_check k a b t =
        let a, b = ev2 d a b
        if is_check a b then k t a b
        else raise_type_error d (check_error a b)

    let inline prim_bin_op_helper d t a b = push_binop d t (a,b) (type_get a)
    let inline prim_un_op_helper d t a = push_op d t a (type_get a)
    let inline bool_helper d t a b = push_binop d t (a,b) (PrimT BoolT)

    let prim_arith_op d a b t = 
        let er a b = sprintf "`is_numeric a && type_get a = type_get b` is false.\na=%s, b=%s" (show_typed_data a) (show_typed_data b)
        let check a b = let a,b = type_get a, type_get b in is_numeric a && a = b
        prim_bin_op_template d er check (fun t a b ->
            let inline op_arith a b =
                match t with
                | Add -> a + b
                | Sub -> a - b
                | Mult -> a * b
                | Div -> 
                    if Unchecked.defaultof<_> = b then raise_type_error d "Division by zero caught at compile time."
                    a / b
                | Mod -> 
                    if Unchecked.defaultof<_> = b then raise_type_error d "Modulus by zero caught at compile time."
                    a % b
                | _ -> failwith "Expected an arithmetic operation."
            let inline op_arith_num_zero a b =
                match t with
                | Add | Sub -> a
                | Mult -> b
                | Div -> raise_type_error d "Division by zero caught at compile time."
                | Mod -> raise_type_error d "Modulus by zero caught at compile time."
                | _ -> failwith "Expected an arithmetic operation."
            let inline op_arith_zero_num a b =
                match t with
                | Add -> b
                | Sub -> push_op d Neg b (type_get b)
                | Mult | Div | Mod -> a
                | _ -> failwith "Expected an arithmetic operation."
            let inline op_arith_num_one a b =
                match t with
                | Mult | Div -> a
                | Mod ->
                    match type_get a with
                    | PrimT x ->
                        match x with
                        | Int8T -> TyLit (LitInt8 0y)
                        | Int16T -> TyLit (LitInt16 0s)
                        | Int32T -> TyLit (LitInt32 0)
                        | Int64T -> TyLit (LitInt64 0L)
                        | UInt8T -> TyLit (LitUInt8 0uy)
                        | UInt16T -> TyLit (LitUInt16 0us)
                        | UInt32T -> TyLit (LitUInt32 0u)
                        | UInt64T -> TyLit (LitUInt64 0UL)
                        | Float32T -> TyLit (LitFloat32 0.0f)
                        | Float64T -> TyLit (LitFloat64 0.0)
                        | BoolT | CharT | StringT -> failwith "Compiler error: Invalid type."
                    | _ -> failwith "Compiler error: Invalid type."
                | Add | Sub -> prim_bin_op_helper d t a b
                | _ -> failwith "Expected an arithmetic operation."
            let inline op_arith_one_num a b =
                match t with
                | Mult -> b
                | Div | Mod | Add | Sub -> prim_bin_op_helper d t a b
                | _ -> failwith "Expected an arithmetic operation."
            match a, b with
            | TyLit a', TyLit b' ->
                match a', b' with
                | LitInt8 a, LitInt8 b -> op_arith a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op_arith a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op_arith a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op_arith a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op_arith a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op_arith a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op_arith a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op_arith a b |> LitUInt64 |> TyLit
                | LitFloat32 a, LitFloat32 b -> op_arith a b |> LitFloat32 |> TyLit
                | LitFloat64 a, LitFloat64 b -> op_arith a b |> LitFloat64 |> TyLit
                | _ -> prim_bin_op_helper d t a b

            | TyLit a', _ ->
                match a' with
                | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
                | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL
                | LitFloat32 0.0f | LitFloat64 0.0 -> op_arith_zero_num a b
                | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
                | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL
                | LitFloat32 1.0f | LitFloat64 1.0 -> op_arith_one_num a b
                | _ -> prim_bin_op_helper d t a b

            | _, TyLit b' ->
                match b' with
                | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
                | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL
                | LitFloat32 0.0f | LitFloat64 0.0 -> op_arith_num_zero a b
                | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
                | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL
                | LitFloat32 1.0f | LitFloat64 1.0 -> op_arith_num_one a b
                | _ -> prim_bin_op_helper d t a b
            | TyV(T(a',typ)), TyV(T(b',_)) when a' = b' && t = Sub -> 
                match typ with
                | PrimT Int8T -> LitInt8 0y |> TyLit
                | PrimT Int16T -> LitInt16 0s |> TyLit
                | PrimT Int32T -> LitInt32 0 |> TyLit
                | PrimT Int64T -> LitInt64 0L |> TyLit
                | PrimT UInt8T -> LitUInt8 0uy |> TyLit
                | PrimT UInt16T -> LitUInt16 0us |> TyLit
                | PrimT UInt32T -> LitUInt32 0u |> TyLit
                | PrimT UInt64T -> LitUInt64 0UL |> TyLit
                | PrimT Float32T -> LitFloat32 0.0f |> TyLit
                | PrimT Float64T -> LitFloat64 0.0 |> TyLit
                | _ -> prim_bin_op_helper d t a b
            | _ -> prim_bin_op_helper d t a b
            ) a b t

    let power d a b =
        match ev2 d a b with
        | TyLit (LitFloat64 a), TyLit (LitFloat64 b) -> a ** b |> LitFloat64 |> TyLit
        | TyLit (LitFloat32 a), TyLit (LitFloat32 b) -> float32 (float a ** float b) |> LitFloat32 |> TyLit
        | a, b ->
            match type_get a, type_get b with
            | PrimT Float64T, PrimT Float64T -> push_binop d Pow (a,b) (PrimT Float64T)
            | PrimT Float32T, PrimT Float32T -> push_binop d Pow (a,b) (PrimT Float32T)
            | a, b -> raise_type_error d <| sprintf "The arguments to Pow must both be either float32 or float64. Got: %s and %s" (show_ty a) (show_ty b)

    let prim_comp_op d a b t = 
        let er a b = sprintf "(is_char a || is_string a || is_numeric a || is_bool a) && type_get a = type_get b` is false.\na=%s, b=%s" (show_typed_data a) (show_typed_data b)
        let check a b = let a,b = type_get a, type_get b in (is_char a || is_string a || is_numeric a || is_bool a) && a = b
        prim_bin_op_template d er check (fun t a b ->
            let inline eq_op a b = LitBool (a = b) |> TyLit
            let inline neq_op a b = LitBool (a <> b) |> TyLit
            match t, a, b with
            | EQ, TyV(T(a,_)), TyV(T(b,_)) when a = b -> LitBool true |> TyLit
            | EQ, TyLit (LitBool a), TyLit (LitBool b) -> eq_op a b
            | EQ, TyLit (LitString a), TyLit (LitString b) -> eq_op a b
            | NEQ, TyV(T(a,_)), TyV(T(b,_)) when a = b -> LitBool false |> TyLit
            | NEQ, TyLit (LitBool a), TyLit (LitBool b) -> neq_op a b
            | NEQ, TyLit (LitString a), TyLit (LitString b) -> neq_op a b
            | _ ->
                let inline op a b =
                    match t with
                    | LT -> a < b
                    | LTE -> a <= b
                    | EQ -> a = b
                    | NEQ -> a <> b
                    | GT -> a > b
                    | GTE -> a >= b 
                    | _ -> failwith "Expected a comparison operation."
                match a, b with
                | TyLit a', TyLit b' ->
                    match a', b' with
                    | LitInt8 a, LitInt8 b -> op a b |> LitBool |> TyLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitBool |> TyLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitBool |> TyLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitBool |> TyLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> TyLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> TyLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> TyLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> TyLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> TyLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> TyLit
                    | LitString a, LitString b -> op a b |> LitBool |> TyLit
                    | LitChar a, LitChar b -> op a b |> LitBool |> TyLit
                    | _ -> bool_helper d t a b
                | _ -> bool_helper d t a b
                ) a b t

    let prim_shift_op d a b t =
        let er a b = sprintf "`is_int a && is_int b` is false.\na=%s, b=%s" (show_typed_data a) (show_typed_data b)
        let check a b = let a,b = type_get a, type_get b in is_int a && is_int b
        prim_bin_op_template d er check (prim_bin_op_helper d) a b t

    let prim_bitwise_op d a b t =
        let er a b = sprintf "`type_get a = type_get b && is_any_int a && is_any_int b` is false.\na=%s, b=%s" (show_typed_data a) (show_typed_data b)
        let check a b = let a,b = type_get a, type_get b in a = b && is_any_int a && is_any_int b
        prim_bin_op_template d er check (fun t a b ->
            let inline op_bitwise a b = 
                match t with
                | BitwiseAnd -> a &&& b
                | BitwiseOr -> a ||| b
                | BitwiseXor -> a ^^^ b
                | _ -> raise_type_error d "Compiler error: Expected a bitwise operation."
            match a,b with
            | TyLit a', TyLit b' ->
                match a', b' with
                | LitInt8 a, LitInt8 b -> op_bitwise a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op_bitwise a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op_bitwise a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op_bitwise a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op_bitwise a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op_bitwise a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op_bitwise a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op_bitwise a b |> LitUInt64 |> TyLit
                | _ -> prim_bin_op_helper d t a b
            | _ -> prim_bin_op_helper d t a b
            ) a b t

    let prim_un_op_template d check_error is_check k a t =
        let a = ev d a
        if is_check a then k t a
        else raise_type_error d (check_error a)

    let prim_un_floating d a t =
        let er a = sprintf "`is_float a` is false.\na=%s" (show_typed_data a)
        let check a = is_float (type_get a)
        prim_un_op_template d er check (fun t a ->
            let inline op x =
                match t with
                | Tanh -> tanh x
                | Log -> log x
                | Exp -> exp x
                | Sqrt -> sqrt x
                | _ -> raise_type_error d "Compiler error: Unknown op."
            match a with
            | TyLit (LitFloat32 x) -> op x |> LitFloat32 |> TyLit
            | TyLit (LitFloat64 x) -> op x |> LitFloat64 |> TyLit
            | x -> prim_un_op_helper d t x
            ) a t

    let prim_un_numeric d a t =
        let er a = sprintf "`is_numeric a` is false.\na=%s" (show_typed_data a)
        let check a = is_numeric (type_get a)
        prim_un_op_template d er check (fun t a -> 
            let inline op a = 
                match t with
                | Neg -> -a
                | _ -> failwithf "Compiler error: Unexpected operation %A." t

            match a with
            | TyLit a' ->
                match a' with
                | LitInt8 a -> op a |> LitInt8 |> TyLit
                | LitInt16 a -> op a |> LitInt16 |> TyLit
                | LitInt32 a -> op a |> LitInt32 |> TyLit
                | LitInt64 a -> op a |> LitInt64 |> TyLit
                | LitFloat32 a -> op a |> LitFloat32 |> TyLit
                | LitFloat64 a -> op a |> LitFloat64 |> TyLit
                | _ -> prim_un_op_helper d t a
            | _ -> prim_un_op_helper d t a
            ) a t

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
    | Let(_,bind,on_succ) -> ev (push_var (ev d bind) d) on_succ
    | Case(_,bind,on_succ) ->
        match ev d bind with
        | TyBox(b,_) -> ev (push_var b d) on_succ
        | (TyV(T(_, t & (UnionT _ | RecUnionT _))) | TyT(t & (UnionT _ | RecUnionT _))) as v ->
            let rewrite_key = TypeUnbox, v
            match Map.tryFind rewrite_key !d.cse with
            | Some v -> ev (push_var v d) on_succ
            | None ->
                let inline ev_case end_ty' x =
                    let x = type_to_tyv x
                    let d = {d with cse=ref (Map.add rewrite_key x !d.cse)}
                    let seq, end_ty = ev_seq (push_var x d) on_succ
                    match end_ty' with
                    | Some end_ty' -> if end_ty' <> end_ty then raise_type_error d <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\nGot: %s and %s" (show_ty end_ty') (show_ty end_ty)
                    | None -> ()
                    (x, seq), Some end_ty
                
                let cases, end_ty = case_type d t |> List.mapFold ev_case None
                let end_ty = end_ty.Value
                push_typedop d (TyCase(v,List.toArray cases)) end_ty
        | v -> ev (push_var v d) on_succ
    | ListTakeAllTest(_,stack_size,bind,on_succ,on_fail) -> list_test true (stack_size,bind,on_succ,on_fail)
    | ListTakeNTest(_,stack_size,bind,on_succ,on_fail) -> list_test false (stack_size,bind,on_succ,on_fail)
    | KeywordTest(_, keyword, bind, on_succ, on_fail) ->
        match v bind with
        | TyKeyword(keyword', l) when keyword = keyword' -> ev {d with env_stack_ptr=Array.fold push_var_ptr d.env_stack_ptr l} on_succ
        | _ -> ev d on_fail
    | RecordTest(_, pats, bind, on_succ, on_fail) ->
        let inline on_fail () = ev d on_fail
        match v bind with
        | TyMap l -> 
            let rec loop d i =
                let inline case keyword =
                    match l.TryFind keyword with
                    | Some x -> loop (push_var x d) (i+1)
                    | None -> on_fail()
                if i < pats.Length then
                    match pats.[i] with
                    | RecordTestKeyword keyword -> case keyword
                    | RecordTestInjectVar var ->
                        match v var with
                        | TyKeyword(keyword,_) -> case keyword
                        | _ -> raise_type_error d "The injected variable needs to an unary keyword."
                else ev d on_succ
            loop d 0
        | _ -> on_fail()
    | RecordWith(_,vars, withs) ->
        let withs l =
            let push_keyword keyword =
                match Map.tryFind keyword l with
                | Some this -> push_var this d
                | None -> push_var tyb d
            let var_to_keyword var_string var = 
                match v var with
                | TyKeyword(keyword,_) -> keyword
                | _ -> raise_type_error d <| sprintf "The injected variable %s in RecordWith is not a keyword." var_string
            Array.fold (fun l -> function
                | RecordWithKeyword(keyword,expr) -> Map.add keyword (ev (push_keyword keyword) expr) l
                | RecordWithInjectVar(var_string, var,expr) -> let keyword = var_to_keyword var_string var in Map.add keyword (ev (push_keyword keyword) expr) l
                | RecordWithoutKeyword keyword -> Map.remove keyword l
                | RecordWithoutInjectVar(var_string, var) -> Map.remove (var_to_keyword var_string var) l
                ) l withs
            |> TyMap
        match vars with
        | [||] -> withs Map.empty
        | _ -> 
            match ev d vars.[0] with
            | TyMap l -> 
                let rec loop l i =
                    if i < vars.Length then
                        let th = function 1 -> "st" | 2 -> "nd" | 3 -> "rd" | _ -> "th"
                        match ev d vars.[i] with
                        | TyKeyword(keyword,_) ->
                            match Map.tryFind keyword l with
                            | Some(TyMap l') -> Map.add keyword (loop l' (i+1)) l |> TyMap
                            | Some _ -> raise_type_error d <| sprintf "The %i%s variable application in RecordWith does not result in a record." i (th i)
                            | None -> raise_type_error d <| sprintf "The keyword %s cannot be found in the %i%s sub-record." (keyword_to_string keyword) i (th i)
                        | _ -> let i = i+1 in raise_type_error d <| sprintf "The %i%s variable in RecordWith is not a keyword." i (th i)
                    else withs l
                loop l 1
            | _ -> raise_type_error d "The first variable must be a record."
    | ExprPos(_,pos) -> ev {d with trace=pos.Pos :: d.trace} pos.Expression
    | Op(_,op,l) ->
        match op, l with
        | Apply,[|a;b|] -> apply d (ev d a, ev d b)
        | TermCast,[|a;b|] ->
            // Compiles into a method with two lambda arguments. The second argument resides in `env_local`.
            let join_point_closure (d: LangEnv) body =
                let call_args, consed_env = typed_data_to_consed' (TyKeyword(keyword_env, d.env_global))
                let call_args2, consed_env2, domain_ty = 
                    let x = d.env_stack.[0]
                    let call, env = typed_data_to_consed' x
                    call, env, type_get x
                let join_point_key = body, CTyList (hash_cons_table.Add [consed_env; consed_env2])
           
                let _, range_ty =
                    let dict = join_point_dict_closure
                    match dict.TryGetValue join_point_key with
                    | false, _ ->
                        let tag: Tag = dict.Count
                        dict.[join_point_key] <- JoinPointInEvaluation ()
                        let x = ev_seq {d with cse=ref Map.empty} body
                        dict.[join_point_key] <- JoinPointDone (tag,call_args,call_args2,x)
                        x
                    | true, JoinPointInEvaluation _ -> ev_seq {d with cse=ref Map.empty; rbeh=AnnotationReturn} body
                    | true, JoinPointDone (_,_,_,x) -> x

                let ret_ty = TermCastedFunctionT(domain_ty,range_ty)
                push_typedop d (TyJoinPoint(join_point_key,JoinPointClosure,call_args)) ret_ty

            match ev d a, ev d b with
            | TyFunction(body,stack_size,env), b ->
                let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
                join_point_closure (push_var (type_get b |> type_to_tyv) d) body
            | TyRecFunction(body,stack_size,env) & a, b ->
                let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
                join_point_closure (push_var (type_get b |> type_to_tyv) d |> push_var a) body
            | x,_ -> raise_type_error d <| sprintf "Expected a function in term casting.\nGot: %s" (show_typed_data x)
        // Note: All of the following join points must be wrapped in a function so that their local environment is fresh and all used free vars are in the `env_global`.
        | JoinPointEntryMethod,[|body|] -> 
            let call_args, consed_env = typed_data_to_consed' (TyKeyword(keyword_env, d.env_global))
            let join_point_key = body, consed_env
           
            let _, ret_ty = 
                let dict = join_point_dict_method
                match dict.TryGetValue join_point_key with
                | false, _ ->
                    let tag: Tag = dict.Count
                    dict.[join_point_key] <- JoinPointInEvaluation ()
                    let x = ev_seq {d with cse=ref Map.empty} body
                    dict.[join_point_key] <- JoinPointDone (tag,call_args,x)
                    x
                | true, JoinPointInEvaluation _ -> ev_seq {d with cse=ref Map.empty; rbeh=AnnotationReturn} body
                | true, JoinPointDone (_,_,x) -> x

            push_typedop d (TyJoinPoint(join_point_key,JoinPointMethod,call_args)) ret_ty

        | JoinPointEntryCuda,[|body|] -> 
            let call_args, consed_env = typed_data_to_consed' (TyKeyword(keyword_env, d.env_global))
            if Array.forall (fun (T(_,x)) -> fsharp_to_cuda_blittable_is x) call_args = false then 
                Array.choose (fun (T(_,x) as t) -> if fsharp_to_cuda_blittable_is x then None else Some (TyV t)) call_args
                |> fun x -> show_typed_data (TyList(Array.toList x))
                |> (raise_type_error d << sprintf "At the Cuda join point the following arguments have disallowed non-blittable types: %s")
            let join_point_key = body, consed_env
           
            let tag, (_, ret_ty) = 
                let dict = join_point_dict_cuda
                match dict.TryGetValue join_point_key with
                | false, _ ->
                    let tag: Tag = dict.Count
                    dict.[join_point_key] <- JoinPointInEvaluation tag
                    let x = ev_seq {d with cse=ref Map.empty} body
                    dict.[join_point_key] <- JoinPointDone (tag,call_args,x)
                    tag,x
                | true, JoinPointInEvaluation tag -> tag, ev_seq {d with cse=ref Map.empty; rbeh=AnnotationReturn} body
                | true, JoinPointDone (tag,_,x) -> tag, x

            let ret = push_typedop d (TyJoinPoint(join_point_key,JoinPointCuda,call_args)) ret_ty
            match ret with
            | TyList [] -> 
                let call_args = Array.map (fun x -> TyV x) call_args |> Array.toList
                TyList (TyLit(LitString <| sprintf "method_%i" tag) :: call_args)
            | _ -> raise_type_error d "The return type of Cuda join point must be unit tuple.\nGot: %s" (show_ty ret_ty)

        | JoinPointEntryType,[|body;name|] -> 
            let name =
                match ev d name with
                | TyLit (LitString name) -> name
                | _ -> raise_type_error d "The name of the recursive type must be a string literal."
            let call_args, consed_env = typed_data_to_consed' (TyKeyword(keyword_env, d.env_global))
            let join_point_key = body, consed_env
            
            let inline y _ = RecUnionT (name, join_point_key)
            let dict = join_point_dict_type
            match dict.TryGetValue join_point_key with
            | false, _ ->
                let tag: Tag = dict.Count
                dict.[join_point_key] <- JoinPointInEvaluation false
                let x = ev_seq {d with cse=ref Map.empty} body |> snd
                match dict.[join_point_key] with
                | JoinPointInEvaluation false -> dict.[join_point_key] <- JoinPointDone (tag,false,x); x
                | JoinPointInEvaluation true -> dict.[join_point_key] <- JoinPointDone (tag,true,x); y()
                | _ -> failwith "impossible"
            | true, JoinPointInEvaluation _ -> dict.[join_point_key] <- JoinPointInEvaluation true; y()
            | true, JoinPointDone (_,false,x) -> x
            | true, JoinPointDone (_,true,_) -> y()
            |> TyT
        | LayoutToStack,[|a|] -> layout_to_some LayoutStack d (ev d a)
        | LayoutToHeap,[|a|] -> layout_to_some LayoutHeap d (ev d a)
        | LayoutToHeapMutable,[|a|] -> layout_to_some LayoutHeapMutable d (ev d a)
        | If,[|cond;on_succ;on_fail|] ->
            match ev d cond with
            | TyLit (LitBool true) -> ev d on_succ
            | TyLit (LitBool false) -> ev d on_fail
            | cond ->
                match type_get cond with
                | PrimT BoolT ->
                    let lit_tr = TyLit(LitBool true)
                    let lit_fl = TyLit(LitBool false)
                    let add_rewrite_cases cse is_true = 
                        let tr,fl = if is_true then lit_tr, lit_fl else lit_fl, lit_tr
                        let inline op op cond' res x = x |> Map.add (op,TyList [cond;cond']) res |> Map.add (op,TyList [cond';cond]) res
                        cse |> op EQ tr tr |> op NEQ tr fl |> op EQ fl fl |> op NEQ fl tr
                    let tr, type_tr = ev_seq {d with cse = ref (add_rewrite_cases !d.cse true)} on_succ
                    let fl, type_fl = ev_seq {d with cse = ref (add_rewrite_cases !d.cse false)} on_fail
                    if type_tr = type_fl then
                        if tr.Length = 1 && fl.Length = 1 then
                            match tr.[0], fl.[0] with
                            | TyLocalReturnData(TyLit (LitBool true),_), TyLocalReturnData(TyLit (LitBool false),_) -> cond
                            | TyLocalReturnData(TyLit (LitBool false),_), TyLocalReturnData(TyLit (LitBool true),_) -> push_binop_no_rewrite d EQ (cond,lit_fl) type_tr
                            | TyLocalReturnData(tr,_), TyLocalReturnData(fl,_) when tr = fl -> tr
                            | TyLocalReturnOp(_,tr), TyLocalReturnOp(_,fl) when tr = fl -> push_typedop d tr type_tr
                            | _ -> push_typedop d (TyIf(cond,tr,fl)) type_tr
                        else push_typedop d (TyIf(cond,tr,fl)) type_tr
                    else raise_type_error d <| sprintf "Types in branches of If do not match.\nGot: %s and %s" (show_ty type_tr) (show_ty type_fl)
                | cond_ty -> raise_type_error d <| sprintf "Expected a bool in conditional.\nGot: %s" (show_ty cond_ty)
        | While,[|cond;on_succ|] ->
            match ev_seq d cond with
            | [|TyLocalReturnOp(_,TyJoinPoint cond)|], ty ->
                match ty with
                | PrimT BoolT -> 
                    match ev_seq d on_succ with
                    | on_succ, ListT(C []) & ty -> push_typedop d (TyWhile(cond,on_succ)) ty
                    | _, ty -> raise_type_error d <| sprintf "The body of the while loop must be of type unit.\nGot: %s" (show_ty ty)
                | _ -> raise_type_error d <| sprintf "The conditional of the while loop must be of type bool.\nGot: %s" (show_ty ty)
            | _ -> raise_type_error d "Compiler error: The body of the conditional of the while loop must be a solitary join point."
        | Dynamize,[|a|] ->
            let rec f = function
                | TyList l -> List.map f l |> TyList
                | TyKeyword(a,b) -> (a,Array.map f b) |> TyKeyword
                | TyFunction(a,b,c) -> (a,b,Array.map f c) |> TyFunction
                | TyRecFunction(a,b,c) -> (a,b,Array.map f c) |> TyRecFunction
                | TyObject(a,b) -> (a,Array.map f b) |> TyObject
                | TyMap l -> Map.map (fun _ -> f) l |> TyMap
                | TyBox _ | TyLit _ as x -> push_op_no_rewrite d Dynamize x (type_get x)
                | TyV _ | TyT _ as x -> x
            
            f (ev d a)
        | Macro, [|body;ty|] ->
            match ev d body with
            | TyLit(LitString _) as body -> push_op_no_rewrite d Macro body (ev d ty |> type_get)
            | body -> raise_type_error d "The body of the macro must be a compile time string literal.\nGot: %s" (show_typed_data body)
        | MacroExtern, [|body;ty|] ->
            match ev d body with
            | TyLit(LitString _) as body ->
                match ev d ty with
                | TyLit(LitString ty) -> push_op_no_rewrite d Macro body (MacroT ty)
                | ty -> raise_type_error d "The type of the extern macro must be a compile time string literal.\nGot: %s" (show_typed_data ty)
            | body -> raise_type_error d "The body of the extern macro must be a compile time string literal.\nGot: %s" (show_typed_data body)
        | VarToString, [|x|] ->
            match ev d x with
            | TyV(T(tag,_)) -> TyLit(LitString(sprintf "var_%i" tag))
            | x -> raise_type_error d "The body of the macro must be a runtime variable.\nGot: %s" (show_typed_data x)
        | TypeAnnot, [|a;b|] ->
            match d.rbeh with
            | AnnotationReturn -> ev_annot {d with rbeh=AnnotationDive} b |> TyT
            | AnnotationDive ->
                let a, tb = ev d a, ev_annot d b
                let ta = type_get a
                if ta = tb then a else raise_type_error d <| sprintf "Type annotation mismatch.\n%s <> %s" (show_ty ta) (show_ty tb)
        | TypeGet, [|a|] -> ev_annot d a |> TyT
        | TypeUnion, l -> 
            let set_field = function UnionT t -> t.node | t -> Set.singleton t
            Array.fold (fun s x -> Set.union s (ev_annot d x |> set_field)) Set.empty l |> hash_cons_table.Add |> UnionT |> TyT
        | TypeSplit, [|a|] -> ev_annot d a |> case_type d |> List.map TyT |> TyList
        | TypeRaise, [|a|] -> ev_annot d a |> TypeRaised |> raise
        | TypeCatch, [|a|] -> 
            try ev_annot d a |> TyT
            with
            | :? TypeRaised as x -> TyT x.Data0
            | _ -> reraise()
        | TypeBox, [|a;b|] -> 
            let a_ty = ev_annot d a
            let b = ev d b
            let b_ty = type_get b
            if a_ty = b_ty then b
            elif case_type' d a_ty |> Set.contains b_ty then TyBox(b,a_ty)
            else raise_type_error d <| sprintf "Type constructor application failed. %s is not a subset of %s." (show_ty b_ty) (show_ty a_ty)
        | SizeOf,[|a|] -> 
            match ev_annot d a with
            | PrimT x ->
                let size =
                    match x with
                    | Int8T -> sizeof<int8>
                    | Int16T -> sizeof<int16>
                    | Int32T -> sizeof<int32>
                    | Int64T -> sizeof<int64>
                    | UInt8T -> sizeof<uint8>
                    | UInt16T -> sizeof<uint16>
                    | UInt32T -> sizeof<uint32>
                    | UInt64T -> sizeof<uint64>
                    | Float32T -> sizeof<float32>
                    | Float64T -> sizeof<float>
                    | CharT -> sizeof<char>
                    | StringT -> sizeof<string>
                    | BoolT -> sizeof<bool>
                TyLit (LitInt64 (int64 size))
            | a -> push_op d SizeOf (TyT a) (PrimT Int64T)
        | TermFunctionTypeCreate, [|a;b|] -> TermCastedFunctionT(ev_annot d a, ev_annot d b) |> TyT
        | TermFunctionIs, [|a|] -> 
            match ev d a with
            | TyT(TermCastedFunctionT(dom,range)) | TyV(T(_,TermCastedFunctionT(dom,range))) -> TyLit(LitBool true)
            | _ -> TyLit(LitBool false)
        | TermFunctionDomain, [|a|] -> 
            match ev d a with
            | TyT(TermCastedFunctionT(dom,range)) | TyV(T(_,TermCastedFunctionT(dom,range))) -> TyT dom
            | x -> raise_type_error d <| sprintf "Not a term casted function.\nGot: %s" (show_typed_data x)
        | TermFunctionRange, [|a|] -> 
            match ev d a with
            | TyT(TermCastedFunctionT(dom,range)) | TyV(T(_,TermCastedFunctionT(dom,range))) -> TyT range
            | x -> raise_type_error d <| sprintf "Not a term casted function.\nGot: %s" (show_typed_data x)            
        | StringSlice, [|a;b;c|] ->
            match ev3 d a b c with
            | TyLit(LitString a), TyLit(LitInt64 b), TyLit(LitInt64 c) ->
                if int b >= 0 && int c < a.Length then a.[(int b)..(int c)] |> LitString |> TyLit
                else raise_type_error d <| sprintf "String slice out of bounds. length: %i from: %i to: %i" a.Length b c
            | TyType(PrimT StringT) & a, TyType(PrimT Int64T) & b, TyType(PrimT Int64T) & c -> push_triop d StringSlice (a,b,c) (PrimT StringT)
            | a,b,c -> raise_type_error d <| sprintf "Expected a string and two int64s as arguments to StringSlice.\nstring: %s\nfrom: %s\nto: %s" (show_typed_data a) (show_typed_data b) (show_typed_data c)
        | StringLength, [|a|] ->
            match ev d a with
            | TyLit (LitString str) -> TyLit (LitInt64 (int64 str.Length))
            | TyType(PrimT StringT) & str -> push_op d StringLength str (PrimT Int64T)
            | x -> raise_type_error d <| sprintf "Expected a string.\nGot: %s" (show_typed_data x)
        | StringFormat, [|a;b|] ->
            match ev2 d a b with
            | TyLit(LitString format) & a, TyTuple l when List.forall lit_is l ->
                let f = function
                    | TyLit x ->
                        match x with
                        | LitInt8 x -> box x
                        | LitInt16 x -> box x
                        | LitInt32 x -> box x
                        | LitInt64 x -> box x
                        | LitUInt8 x -> box x
                        | LitUInt16 x -> box x
                        | LitUInt32 x -> box x
                        | LitUInt64 x -> box x
                        | LitFloat32 x -> box x
                        | LitFloat64 x -> box x
                        | LitString x -> box x
                        | LitChar x -> box x
                        | LitBool x -> box x
                    | _ -> failwith "impossible"
                try 
                    match l with
                    | [a] -> String.Format(format,f a)
                    | [a;b] -> String.Format(format,f a,f b)
                    | [a;b;c] -> String.Format(format,f a,f b,f c)
                    | l -> String.Format(format,List.toArray l |> Array.map f)
                    |> LitString |> TyLit
                with :? System.FormatException as e -> raise_type_error d <| sprintf "Dotnet format exception.\nMessage: %s" e.Message
            | TyType (PrimT StringT) & a, TyTuple l -> push_op d StringFormat (TyList(a :: l)) (PrimT StringT)
            | a, _ -> raise_type_error d <| sprintf "Expected a string as the first argument to string format.\nGot: %s" (show_typed_data a)
        | StringConcat,[|sep;l|] -> 
            let sep, TyTuple l = ev2 d sep l
            let string_is x = type_get x |> function PrimT StringT -> true | _ -> false
            if string_is sep = false then raise_type_error d <| sprintf "The first argument to StringConcat must be a string.\nGot: %s" (show_typed_data sep)
            match List.filter (string_is >> not) l with
            | [] -> () | l -> raise_type_error d <| sprintf "The second argument to StringConcat must be all strings.\nGot: %s" (show_typed_data (TyList l))
            match sep with
            | TyLit(LitString sep) when List.forall lit_is l ->
                let l = List.map (function TyLit (LitString x) -> x | _ -> failwith "impossible") l
                String.concat sep l |> LitString |> TyLit
            | _ -> push_op d StringConcat (TyList (sep :: l)) (PrimT StringT)
        | UnsafeConvert,[|to_;from|] ->
            let to_,from = ev2 d to_ from
            let tot,fromt = type_get to_, type_get from
            if tot = fromt then from
            else
                let inline conv_lit x =
                    match tot with
                    | PrimT Int8T -> int8 x |> LitInt8
                    | PrimT Int16T -> int16 x |> LitInt16
                    | PrimT Int32T -> int32 x |> LitInt32
                    | PrimT Int64T -> int64 x |> LitInt64
                    | PrimT UInt8T -> uint8 x |> LitUInt8
                    | PrimT UInt16T -> uint16 x |> LitUInt16
                    | PrimT UInt32T -> uint32 x |> LitUInt32
                    | PrimT UInt64T -> uint64 x |> LitUInt64
                    | PrimT CharT -> char x |> LitChar
                    | PrimT Float32T -> float32 x |> LitFloat32
                    | PrimT Float64T -> float x |> LitFloat64
                    | PrimT StringT -> string x |> LitString
                    | _ -> raise_type_error d <| sprintf "Cannot convert the literal to the following type: %s" (show_ty tot)
                    |> TyLit
                match from with
                | TyLit (LitInt8 a) -> conv_lit a
                | TyLit (LitInt16 a) -> conv_lit a
                | TyLit (LitInt32 a) -> conv_lit a
                | TyLit (LitInt64 a) -> conv_lit a
                | TyLit (LitUInt8 a) -> conv_lit a
                | TyLit (LitUInt16 a) -> conv_lit a
                | TyLit (LitUInt32 a) -> conv_lit a
                | TyLit (LitUInt64 a) -> conv_lit a
                | TyLit (LitChar a) -> conv_lit a
                | TyLit (LitFloat32 a) -> conv_lit a
                | TyLit (LitFloat64 a) -> conv_lit a
                | TyLit (LitString a) -> conv_lit a
                | TyLit (LitBool _) -> raise_type_error d "Cannot convert the bool to any type."
                | _ ->
                    let is_convertible_primt x =
                        match x with
                        | PrimT BoolT | PrimT StringT -> false
                        | PrimT _ -> true
                        | _ -> false
                    if is_convertible_primt fromt && is_convertible_primt tot then push_binop d UnsafeConvert (to_,from) tot
                    else raise_type_error d <| sprintf "Cannot convert %s to the following type: %s" (show_typed_data from) (show_ty tot)
        | PrintStatic,[|a|] -> printfn "%s" (ev d a |> show_typed_data); tyb
        | RecordMap,[|a;b|] ->
            match ev2 d a b with
            | a, TyMap l ->
                Map.map (fun k x ->
                    let inline ap a b = apply d (a, b)
                    ap (ap a (TyKeyword(k,[||]))) x
                    ) l
                |> TyMap
            | _, b -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data b)
        | RecordFilter,[|a;b|] ->
            match ev2 d a b with
            | a, TyMap l ->
                Map.filter (fun k x ->
                    let inline ap a b = apply d (a, b)
                    match ap (ap a (TyKeyword(k,[||]))) x with
                    | TyLit(LitBool x) -> x
                    | x -> raise_type_error d <| sprintf "Expected a bool literal in ModuleFilter.\nGot: %s" (show_typed_data x)
                    ) l
                |> TyMap
            | _, b -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data b)
        | RecordFoldL,[|a;b;c|] ->
            match ev3 d a b c with
            | a, s, TyMap l ->
                Map.fold (fun s k x ->
                    let inline ap a b = apply d (a, b)
                    ap (ap (ap a (TyKeyword(k,[||]))) s) x
                    ) s l
            | _, _, r -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data r)
        | RecordFoldR,[|a;b;c|] ->
            match ev3 d a b c with
            | a, TyMap l, s ->
                Map.foldBack (fun k x s ->
                    let inline ap a b = apply d (a, b)
                    ap (ap (ap a (TyKeyword(k,[||]))) x) s
                    ) l s
            | _, r, _ -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data r)
        | RecordLength,[|a|] ->
            match ev d a with
            | TyMap l -> Map.count l |> int64 |> LitInt64 |> TyLit
            | r -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data r)
        | LitIs,[|a|] -> 
            match ev d a with
            | TyLit _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | BoxIs,[|a|] -> 
            match ev d a with
            | TyBox _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | ArrayCreateDotNet,[|a;b|] ->
            match ev_annot d a, ev d b with
            | a, TyType(PrimT Int64T) & b -> push_binop_no_rewrite d ArrayCreateDotNet (TyT a, b) (ArrayT(ArtDotNetHeap, a))
            | _, b -> raise_type_error d <| sprintf "Expected an int64 as the size of the array.\nGot: %s" (show_typed_data b)
        | ArrayCreateCudaLocal,[|a;b|] ->
            match ev_annot d a, ev d b with
            | a, TyType(PrimT Int64T) & b -> push_binop_no_rewrite d ArrayCreateCudaLocal (TyT a, b) (ArrayT(ArtCudaLocal, a))
            | _, b -> raise_type_error d <| sprintf "Expected an int64 as the size of the array.\nGot: %s" (show_typed_data b)
        | ArrayCreateCudaShared,[|a;b|] ->
            match ev_annot d a, ev d b with
            | a, TyLit(LitInt64 _) & b -> push_binop_no_rewrite d ArrayCreateCudaShared (TyT a, b) (ArrayT(ArtCudaShared, a))
            | _, b -> raise_type_error d <| sprintf "Expected an int64 literal as the size of the array.\nGot: %s" (show_typed_data b)
        | ReferenceCreate,[|a|] ->
            let a = ev d a
            push_op_no_rewrite d ReferenceCreate a (ArrayT(ArtDotNetReference, type_get a))
        | ArrayLength,[|a|] ->
            let a = ev d a
            match type_get a with
            | ArrayT(ArtDotNetHeap,t) -> push_op d ArrayLength a (PrimT Int64T)
            | ArrayT(ArtDotNetReference,t) -> TyLit (LitInt64 1L)
            | _ -> raise_type_error d <| sprintf "ArrayLength is only supported for .NET arrays. Got: %s" (show_typed_data a)
        | ArrayIs,[|a|] ->
            match ev d a |> type_get with
            | ArrayT _ -> TyLit(LitBool true)
            | _ -> TyLit(LitBool false)
        | GetArray,[|a;b|] ->
            match ev d a with
            | TyType (ArrayT((ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaLocal | ArtCudaShared),ty)) & a ->
                match ev d b with
                | TyType (PrimT Int64T) & b -> push_binop_no_rewrite d GetArray (a,b) ty
                | b -> raise_type_error d <| sprintf "Expected a int64 as the index argumet in GetArray.\nGot: %s" (show_typed_data b)
            | a -> raise_type_error d <| sprintf "Expected an array in GetArray.\nGot: %s" (show_typed_data a)
        | GetReference,[|a|] ->
            match ev d a with
            | TyType (ArrayT(ArtDotNetReference,ty)) & a -> push_op_no_rewrite d GetReference a ty
            | a -> raise_type_error d <| sprintf "Expected an array in GetReference.\nGot: %s" (show_typed_data a)
        | SetArray,[|a;b;c|] ->
            match ev d a with
            | TyType (ArrayT((ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaLocal | ArtCudaShared),ty)) & a ->
                match ev d b with
                | TyType (PrimT Int64T) & b -> 
                    match ev d c with
                    | TyType ty' & c -> 
                        if ty' = ty then push_triop_no_rewrite d SetArray (a,b,c) ty
                        else raise_type_error d <| sprintf "The array and the value being set do not have the same type.\nGot: %s\nAnd: %s" (show_ty ty) (show_ty ty')
                | b -> raise_type_error d <| sprintf "Expected a int64 as the index argumet in GetArray.\nGot: %s" (show_typed_data b)
            | a -> raise_type_error d <| sprintf "Expected an array in SetArray.\nGot: %s" (show_typed_data a)
        | SetReference,[|a;c|] ->
            match ev d a with
            | TyType (ArrayT(ArtDotNetReference,ty)) & a -> 
                    match ev d c with
                    | TyType ty' & c -> 
                        if ty' = ty then push_binop_no_rewrite d SetReference (a,c) ty
                        else raise_type_error d <| sprintf "The reference and the value being set do not have the same type.\nGot: %s\nAnd: %s" (show_ty ty) (show_ty ty')
            | a -> raise_type_error d <| sprintf "Expected an array in SetReference.\nGot: %s" (show_typed_data a)
        | SetMutableRecord,[|a;b;c|] ->
            match ev d a with
            | TyType(LayoutT(C(LayoutHeapMutable,CTyMap(C env),_))) & a ->
                match ev d b with
                | TyKeyword(keyword,[||]) ->
                    match Map.tryFind keyword env with
                    | Some x -> 
                        let b_args, ty = consed_typed_data_uncons' x
                        let ty = typed_data_to_consed ty
                        let c_args, ty' = typed_data_to_consed' (ev d c)
                        if ty = ty' then push_typedop d (TySetMutableRecord(a,b_args,c_args)) Types.tyb
                        else raise_type_error d <| sprintf "The record's field and the value being set do not have the same type.\nGot: %s\nAnd: %s" (show_consed_typed_data ty) (show_consed_typed_data ty')
                    | None -> raise_type_error d <| sprintf "The record does not have the %s field." (keyword_to_string keyword)
                | b -> raise_type_error d <| sprintf "Expected an unary keyword as the field argument to SetMutableRecord.\nGot: %s" (show_typed_data b)
            | a -> raise_type_error d <| sprintf "Expected a mutable record in SetMutableRecord.\nGot: %s" (show_typed_data a)

        | NanIs,[|a|] ->
            match ev d a with
            | TyLit (LitFloat32 x) -> System.Single.IsNaN x |> LitBool |> TyLit
            | TyLit (LitFloat64 x) -> System.Double.IsNaN x |> LitBool |> TyLit
            | a & TyType (PrimT (Float32T | Float64T)) -> push_op d NanIs a (PrimT BoolT)
            | x -> raise_type_error d <| sprintf "Expected a float in NanIs. Got: %s" (show_typed_data x)

        // Primitive operations on expressions.
        | Add,[|a;b|] -> prim_arith_op d a b Add
        | Sub,[|a;b|] -> prim_arith_op d a b Sub 
        | Mult,[|a;b|] -> prim_arith_op d a b Mult
        | Div,[|a;b|] -> prim_arith_op d a b Div
        | Mod,[|a;b|] -> prim_arith_op d a b Mod
        | Pow,[|a;b|] -> power d a b

        | LT,[|a;b|] -> prim_comp_op d a b LT
        | LTE,[|a;b|] -> prim_comp_op d a b LTE
        | EQ,[|a;b|] -> prim_comp_op d a b EQ
        | NEQ,[|a;b|] -> prim_comp_op d a b NEQ 
        | GT,[|a;b|] -> prim_comp_op d a b GT
        | GTE,[|a;b|] -> prim_comp_op d a b GTE
    
        | BitwiseAnd,[|a;b|] -> prim_bitwise_op d a b BitwiseAnd
        | BitwiseOr,[|a;b|] -> prim_bitwise_op d a b BitwiseOr
        | BitwiseXor,[|a;b|] -> prim_bitwise_op d a b BitwiseXor

        | ShiftLeft,[|a;b|] -> prim_shift_op d a b ShiftLeft
        | ShiftRight,[|a;b|] -> prim_shift_op d a b ShiftRight

        | Log,[|a|] -> prim_un_floating d a Log
        | Exp,[|a|] -> prim_un_floating d a Exp
        | Tanh,[|a|] -> prim_un_floating d a Tanh
        | Sqrt,[|a|] -> prim_un_floating d a Sqrt
        | Neg,[|a|] -> prim_un_numeric d a Neg

        | ListCons,[|a;b|] ->
            match ev2 d a b with
            | a, TyList b -> TyList(a::b)
            | a, b -> raise_type_error d <| sprintf "Expected a tuple on the right in ListCons.\nGot: %s" (show_typed_data b)
        | ListCons, l -> Array.map (ev d) l |> Array.toList |> TyList

        | EqType,[|a;b|] -> type_get (ev d a) = type_get (ev d b) |> LitBool |> TyLit
        | ErrorType,[|a|] -> ev d a |> show_typed_data |> raise_type_error d
        | ErrorNonUnit,[|a'|] -> 
            match ev d a' with
            | TyList [] & a -> a
            | a ->
                let d = match a' with ExprPos(_,x) -> {d with trace = x.Pos :: d.trace} | _ -> d
                raise_type_error d "Only the last expression of a block is allowed to be unit. Use `ignore` if it intended to be such.\nGot: %s" (show_typed_data a)
        | ErrorPatMiss,[|a|] -> ev d a |> show_typed_data |> sprintf "Pattern miss error. The argument is %s" |> raise_type_error d
        | FailWith,[|typ;a|] ->
            match ev2 d typ a with
            | typ, TyType (PrimT StringT) & a -> push_op_no_rewrite d FailWith a (type_get typ)
            | _,a -> raise_type_error d "Expected a string as input to failwith.\nGot: %s" (show_typed_data a)
        | UnsafeUpcastTo,[|a;b|] -> 
            let a, b = ev2 d a b
            push_binop d UnsafeUpcastTo (a,b) (type_get a)
        | UnsafeDowncastTo,[|a;b|] ->
            let a, b = ev2 d a b
            push_binop d UnsafeDowncastTo (a,b) (type_get a)
        | UnsafeCoerceToArrayCudaGlobal,[|a;b|] ->
            match ev2 d a b with
            | TyV(T(x,t')), t -> TyV(T(x,ArrayT(ArtCudaGlobal t',type_get t)))
            | TyT t', t -> TyT(ArrayT(ArtCudaGlobal t',type_get t))
            | _ -> raise_type_error d "Only variables or runtime types can be converted to the Cuda global array type."
        | InfinityF64,[||] -> TyLit (LitFloat64 infinity)
        | InfinityF32,[||] -> TyLit (LitFloat32 infinityf)
        | _ -> raise_type_error d <| sprintf "Compiler error: %A not implemented" op
