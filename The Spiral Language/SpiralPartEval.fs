module Spiral.PartEval

// Global open
open System
open System.Collections.Generic
open Spiral.Show
open Spiral.Types
open System.Runtime.CompilerServices

// Globals
let join_point_dict_method = Dictionary(HashIdentity.Structural)
let join_point_dict_closure = Dictionary(HashIdentity.Structural)
let join_point_dict_type = Dictionary(HashIdentity.Structural)
let join_point_dict_cuda = Dictionary(HashIdentity.Structural)
let private layout_to_none_dict = ConditionalWeakTable()
let private layout_to_none_dict' = ConditionalWeakTable()

let mutable part_eval_tag = 0
let private tag () = part_eval_tag <- part_eval_tag+1; part_eval_tag

let keyword_env = string_to_keyword "env:" // For join points keys. It is assumed that they will never be printed.
let keyword_apply = string_to_keyword "apply:"
let keyword_key_value = string_to_keyword "key:value:"
let keyword_key_state_value = string_to_keyword "key:state:value:"
let keyword_text = string_to_keyword "text:"
let keyword_variable = string_to_keyword "variable:"
let keyword_literal = string_to_keyword "literal:"
let keyword_type = string_to_keyword "type:"

let ctylist x = x |> hash_cons_table.Add |> CTyList
let ctykeyword x = x |> hash_cons_table.Add |> CTyKeyword
let ctyfunction x = x |> hash_cons_table.Add |> CTyFunction
let ctyrecfunction x = x |> hash_cons_table.Add |> CTyRecFunction
let ctyobject x = x |> hash_cons_table.Add |> CTyObject
let ctymap x = x |> hash_cons_table.Add |> CTyMap

let typed_data_to_consed' call_data =
    let dict = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray(64)
    let rec f x =
        memoize dict (function
            | TyList l -> List.map f l |> ctylist
            | TyKeyword(a,b) -> (a,Array.map f b) |> ctykeyword
            | TyFunction(a,b,c) -> (a,b,Array.map f c) |> ctyfunction
            | TyRecFunction(a,b,c) -> (a,b,Array.map f c) |> ctyrecfunction
            | TyObject(a,b) -> (a,Array.map f b) |> ctyobject
            | TyMap l -> Map.map (fun _ -> f) l |> ctymap
            | TyV(T(_,ty) as t) -> call_args.Add t; CTyV (call_args.Count-1, ty)
            | TyBox(a,b) -> (f a, b) |> CTyBox
            | TyLit x -> CTyLit x
            | TyT x -> CTyT x
            ) x
    let x = f call_data
    call_args.ToArray(),x

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
    let call_args = ResizeArray(64)
    let mutable has_naked_type = false
    let rec f = function
        | TyList l -> List.iter f l
        | TyKeyword(a,b) -> Array.iter f b
        | TyFunction(a,b,c) -> Array.iter f c
        | TyRecFunction(a,b,c) -> Array.iter f c
        | TyObject(a,b) -> Array.iter f b
        | TyMap l -> Map.iter (fun _ -> f) l
        | TyBox _ | TyLit _ | TyV _ as x -> call_args.Add x
        | TyT _ -> has_naked_type <- true
    f call_data
    has_naked_type, call_args.ToArray()

let typed_data_to_consed call_data =
    let dict = Dictionary(HashIdentity.Reference)
    let mutable count = 0
    let rec f x =
        memoize dict (function
            | TyList l -> List.map f l |> ctylist
            | TyKeyword(a,b) -> (a,Array.map f b) |> ctykeyword
            | TyFunction(a,b,c) -> (a,b,Array.map f c) |> ctyfunction
            | TyRecFunction(a,b,c) -> (a,b,Array.map f c) |> ctyrecfunction
            | TyObject(a,b) -> (a,Array.map f b) |> ctyobject
            | TyMap l -> Map.map (fun _ -> f) l |> ctymap
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
    let x = f consed_data
    consed_args.ToArray(), x

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

let value_zero d = function
    | PrimT Int8T -> LitInt8 0y
    | PrimT Int16T -> LitInt16 0s
    | PrimT Int32T -> LitInt32 0
    | PrimT Int64T -> LitInt64 0L
    | PrimT UInt8T -> LitUInt8 0uy
    | PrimT UInt16T -> LitUInt16 0us
    | PrimT UInt32T -> LitUInt32 0u
    | PrimT UInt64T -> LitUInt64 0UL
    | PrimT Float32T -> LitFloat32 0.0f
    | PrimT Float64T -> LitFloat64 0.0
    | ty -> raise_type_error d <| sprintf "Compiler error: Expected a numeric value in value_zero.\nGot: %s" (show_ty ty)

let rect_unbox d key = 
    match join_point_dict_type.[key] with
    | JoinPointInEvaluation _ -> raise_type_error d "Types that are being constructed cannot be used for boxing."
    | JoinPointDone(_,ty) -> ty

let case_type_union = function
    | UnionT l -> Set.toList l.node
    | x -> [x]

let case_type d = function
    | RecUnionT(_,_,key) -> case_type_union (rect_unbox d key)
    | x -> case_type_union x

let case_type_union' = function
    | UnionT l -> l.node
    | x -> Set.singleton x

let case_type' d = function
    | RecUnionT(_,_,key) -> case_type_union' (rect_unbox d key)
    | x -> case_type_union' x

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
   
let rec tyv = function
    | ListT x -> TyList(List.map tyv x.node)
    | KeywordT(C(a,l)) -> TyKeyword(a,Array.map tyv l)
    | FunctionT(C(a,b,l)) -> TyFunction(a,b,Array.map tyv l)
    | RecFunctionT(C(a,b,l)) -> TyRecFunction(a,b,Array.map tyv l)
    | ObjectT(C(a,l)) -> TyObject(a,Array.map tyv l)
    | MapT l -> TyMap(Map.map (fun _ -> tyv) l.node)
    | LayoutT(C (_,_,true)) | UnionT _ | RecUnionT _ | MacroT _ | TermCastedFunctionT _ | PrimT _ as ty -> TyV(T(tag(), ty))
    | ArrayT(_,l) as ty -> if type_is_unit l then TyT ty else TyV(T(tag(), ty))
    | LayoutT _ as ty -> TyT ty
    
let rec tyt = function
    | ListT x -> TyList(List.map tyt x.node)
    | KeywordT(C(a,l)) -> TyKeyword(a,Array.map tyt l)
    | FunctionT(C(a,b,l)) -> TyFunction(a,b,Array.map tyt l)
    | RecFunctionT(C(a,b,l)) -> TyRecFunction(a,b,Array.map tyt l)
    | ObjectT(C(a,l)) -> TyObject(a,Array.map tyt l)
    | MapT l -> TyMap(Map.map (fun _ -> tyt) l.node)
    | ArrayT _ | LayoutT _ | UnionT _ | RecUnionT _ | MacroT _ | TermCastedFunctionT _ | PrimT _ as ty -> TyT ty

let push_var x (d: LangEnv) =
    d.env_stack.[d.env_stack_ptr] <- x
    {d with env_stack_ptr=d.env_stack_ptr+1}

let seq_apply (d: LangEnv) end_dat =
    let inline end_ () = d.seq.Add(TyLocalReturnData(end_dat,d.trace))
    if d.seq.Count > 0 then
        match d.seq.[d.seq.Count-1] with
        | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
        | _ -> end_()
    else end_()
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
        let x = layout_to_none d x
        let call_args, consed_data = typed_data_to_consed' x
        let ret_ty = (layout,consed_data,call_args.Length > 0) |> layoutt
        let ret = tyv ret_ty
        let layout =
            match layout with
            | LayoutStack -> LayoutToStack
            | LayoutHeap -> LayoutToHeap
            | LayoutHeapMutable -> LayoutToHeapMutable
        d.seq.Add(TyLet(ret,d.trace,TyOp(layout,TyList[tyt ret_ty;x])))
        ret

let push_typedop d op ret_ty =
    let ret = tyv ret_ty
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
        let ret = tyv ret_ty
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
        let d = {d with seq=ResizeArray()}
        let x = ev d x
        let x_ty = type_get x
        seq_apply d x, x_ty
    let inline ev_annot d x = ev_seq {d with cse=ref !d.cse} x |> snd
    
    let inline push_var_ptr ptr x = d.env_stack.[ptr] <- x; ptr+1
    let inline v x = let l = d.env_global.Length in if x < l then d.env_global.[x] else d.env_stack.[x - l]

    let inline nan_guardf32 x = if Single.IsNaN x then raise_type_error d "A 32-bit floating point operation resulting in a nan detected at compile time. Spiral cannot propagate nan literal without diverging." else x
    let inline nan_guardf64 x = if Double.IsNaN x then raise_type_error d "A 64-bit floating point operation resulting in a nan detected at compile time. Spiral cannot propagate nan literal without diverging." else x

    let inline list_test all_or_n (stack_size,bind,on_succ,on_fail) =
        let inline on_fail() = ev d on_fail
        match v bind with
        | TyList l ->
            if all_or_n then // all
                let rec loop d = function
                    | 0, [] -> ev d on_succ
                    | _, [] -> on_fail()
                    | i, x :: x' -> loop (push_var x d) (i-1,x')
                loop d (stack_size,l)
            else // n
                let rec loop d = function
                    | 1, l -> ev (push_var (TyList l) d) on_succ
                    | i, x :: x' -> loop (push_var x d) (i-1,x')
                    | _, [] -> on_fail()
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
            | false, _ -> raise_type_error d <| sprintf "The object does not have the receiver for `%s`." (keyword_to_string keyword)
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

    match x with
    | V(_, x) -> v x
    | Lit(_,x) -> TyLit x
    | Inline(_,on_succ,free_vars,stack_size) ->
        let d = {d with env_global=Array.map v free_vars; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
        ev d on_succ
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
                    let x = tyv x
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
                let join_point_key = body, ctylist [consed_env; consed_env2]
           
                let _, range_ty =
                    let dict = join_point_dict_closure
                    match dict.TryGetValue join_point_key with
                    | false, _ ->
                        dict.[join_point_key] <- JoinPointInEvaluation ()
                        let x = ev_seq {d with cse=ref Map.empty} body
                        dict.[join_point_key] <- JoinPointDone (call_args,call_args2,x)
                        x
                    | true, JoinPointInEvaluation _ -> ev_seq {d with cse=ref Map.empty; rbeh=AnnotationReturn} body
                    | true, JoinPointDone (_,_,x) -> x

                let ret_ty = TermCastedFunctionT(domain_ty,range_ty)
                push_typedop d (TyJoinPoint(join_point_key,JoinPointClosure,call_args)) ret_ty

            match ev d a, ev d b with
            | TyFunction(body,stack_size,env), b ->
                let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
                join_point_closure (push_var (type_get b |> tyv) d) body
            | TyRecFunction(body,stack_size,env) & a, b ->
                let d = {d with env_global=env; env_stack=Array.zeroCreate stack_size; env_stack_ptr=0}
                join_point_closure (push_var (type_get b |> tyv) d |> push_var a) body
            | x,_ -> raise_type_error d <| sprintf "Expected a function in term casting.\nGot: %s" (show_typed_data x)
        // Note: All of the following join points must be wrapped in a function so that their local environment is fresh and all used free vars are in the `env_global`.
        | JoinPointEntryMethod,[|body|] -> 
            let call_args, consed_env = typed_data_to_consed' (TyKeyword(keyword_env, d.env_global))
            let join_point_key = body, consed_env
           
            let _, ret_ty = 
                let dict = join_point_dict_method
                match dict.TryGetValue join_point_key with
                | false, _ ->
                    dict.[join_point_key] <- JoinPointInEvaluation ()
                    let x = ev_seq {d with cse=ref Map.empty} body
                    dict.[join_point_key] <- JoinPointDone (call_args,x)
                    x
                | true, JoinPointInEvaluation _ -> ev_seq {d with cse=ref Map.empty; rbeh=AnnotationReturn} body
                | true, JoinPointDone (_,x) -> x

            push_typedop d (TyJoinPoint(join_point_key,JoinPointMethod,call_args)) ret_ty

        | JoinPointEntryCuda,[|body|] -> 
            let call_args, consed_env = typed_data_to_consed' (TyKeyword(keyword_env, d.env_global))
            if Array.forall (fun (T(_,x)) -> fsharp_to_cuda_blittable_is x) call_args = false then 
                Array.choose (fun (T(_,x) as t) -> if fsharp_to_cuda_blittable_is x then None else Some (TyV t)) call_args
                |> fun x -> show_typed_data (TyList(Array.toList x))
                |> (raise_type_error d << sprintf "At the Cuda join point the following arguments have disallowed non-blittable types: %s")
            let join_point_key = body, consed_env
           
            let _, ret_ty = 
                let dict = join_point_dict_cuda
                match dict.TryGetValue join_point_key with
                | false, _ ->
                    dict.[join_point_key] <- JoinPointInEvaluation()
                    let x = ev_seq {d with cse=ref Map.empty} body
                    dict.[join_point_key] <- JoinPointDone (call_args,x)
                    x
                | true, JoinPointInEvaluation _ -> ev_seq {d with cse=ref Map.empty; rbeh=AnnotationReturn} body
                | true, JoinPointDone (_,x) -> x

            
            match ret_ty with
            | ListT(C []) -> 
                let macro = MacroT (ctykeyword (keyword_text,[|CTyLit(LitString "System.Object")|]))
                push_typedop d (TyJoinPoint(join_point_key,JoinPointCuda,call_args)) ([PrimT StringT; ArrayT(ArtDotNetHeap,macro)] |> hash_cons_table.Add |> ListT)
            | _ -> raise_type_error d "The return type of Cuda join point must be unit tuple.\nGot: %s" (show_ty ret_ty)

        | JoinPointEntryType,[|body;name;meta|] -> 
            let meta = ev_annot d meta
            let name', name =
                match ev d name with
                | TyLit (LitString name) as name' -> name', name
                | _ -> raise_type_error d "The name of the recursive type must be a string literal."
            let call_args, consed_env = typed_data_to_consed' (TyKeyword(keyword_env, Array.append [|name'; tyt meta|] d.env_global))
            let join_point_key = body, consed_env
            
            let inline y _ = RecUnionT (name, meta, join_point_key)
            let dict = join_point_dict_type
            match dict.TryGetValue join_point_key with
            | false, _ ->
                dict.[join_point_key] <- JoinPointInEvaluation false
                let x = ev_seq {d with cse=ref Map.empty} body |> snd
                match dict.[join_point_key] with
                | JoinPointInEvaluation is_recursive -> dict.[join_point_key] <- JoinPointDone (is_recursive,x); y()
                | _ -> failwith "impossible"
            | true, JoinPointInEvaluation _ -> dict.[join_point_key] <- JoinPointInEvaluation true; y()
            | true, JoinPointDone _ -> y()
            |> tyt
        | LayoutToStack,[|a|] -> layout_to_some LayoutStack d (ev d a)
        | LayoutToHeap,[|a|] -> layout_to_some LayoutHeap d (ev d a)
        | LayoutToHeapMutable,[|a|] -> layout_to_some LayoutHeapMutable d (ev d a)
        | LayoutToNone,[|a|] -> layout_to_none d (ev d a)
        | If,[|cond;on_succ;on_fail|] ->
            let rec if_ = function
                | TyLit (LitBool true) -> ev d on_succ
                | TyLit (LitBool false) -> ev d on_fail
                | cond ->
                    match type_get cond with
                    | PrimT BoolT as type_bool ->
                        let lit_tr = TyLit(LitBool true)
                        match Map.tryFind (EQ, TyList [cond; lit_tr]) d.cse.contents with
                        | Some cond -> if_ cond
                        | None ->
                            let lit_fl = TyLit(LitBool false)
                            let add_rewrite_cases cse is_true = 
                                let tr,fl = if is_true then lit_tr, lit_fl else lit_fl, lit_tr
                                let inline op op cond' res x = x |> Map.add (op,TyList [cond;cond']) res |> Map.add (op,TyList [cond';cond]) res
                                cse |> op EQ lit_tr tr |> op NEQ lit_tr fl |> op EQ lit_fl fl |> op NEQ lit_fl tr
                            let tr, type_tr = ev_seq {d with cse = ref (add_rewrite_cases !d.cse true)} on_succ
                            let fl, type_fl = ev_seq {d with cse = ref (add_rewrite_cases !d.cse false)} on_fail
                            if type_tr = type_fl then
                                if tr.Length = 1 && fl.Length = 1 then
                                    match tr.[0], fl.[0] with
                                    | TyLocalReturnOp(_,tr), TyLocalReturnOp(_,fl) when tr = fl -> push_typedop d tr type_tr
                                    | TyLocalReturnData(tr',_), TyLocalReturnData(fl',_) -> 
                                        match tr', fl' with
                                        | tr, fl when tr = fl -> tr
                                        | TyLit(LitBool false), TyLit(LitBool true) -> push_binop d EQ (cond,lit_fl) type_bool
                                        | TyLit(LitBool false), fl when cond = fl -> lit_fl
                                        | TyLit(LitBool true), fl -> // boolean or
                                            match fl with
                                            | TyLit (LitBool false) -> cond
                                            | _ -> if cond = fl then cond else push_binop d BoolOr (cond,fl) type_bool
                                        | tr, TyLit(LitBool false) -> // boolean and
                                            match tr with
                                            | TyLit(LitBool true) -> cond
                                            | _ -> if cond = tr then cond else push_binop d BoolAnd (cond,tr) type_bool
                                        | _ -> push_typedop d (TyIf(cond,tr,fl)) type_tr
                                    | _ -> push_typedop d (TyIf(cond,tr,fl)) type_tr
                                else push_typedop d (TyIf(cond,tr,fl)) type_tr
                            else raise_type_error d <| sprintf "Types in branches of If do not match.\nGot: %s and %s" (show_ty type_tr) (show_ty type_fl)
                    | cond_ty -> raise_type_error d <| sprintf "Expected a bool in conditional.\nGot: %s" (show_ty cond_ty)
            if_ (ev d cond)
        | While,[|cond;on_succ|] ->
            match ev_seq d cond with
            | [|TyLocalReturnOp(_,TyJoinPoint cond)|], ty ->
                match ty with
                | PrimT BoolT -> 
                    match ev_seq {d with cse=ref !d.cse} on_succ with
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
                | TyT t as x -> if type_is_unit t then x else push_op_no_rewrite d Dynamize x (type_get x)
                | TyV _ as x -> x
            
            f (ev d a)
        | Macro, [|body;ty|] -> push_op_no_rewrite d Macro (ev d body) (ev d ty |> type_get)
        | MacroExtern, [|body;ty|] -> push_op_no_rewrite d Macro (ev d body) (MacroT (typed_data_to_consed (ev d ty)))
        | TypeAnnot, [|a;b|] ->
            match d.rbeh with
            | AnnotationReturn -> ev_annot {d with rbeh=AnnotationDive} b |> tyt
            | AnnotationDive ->
                let a, tb = ev d a, ev_annot d b
                let ta = type_get a
                if ta = tb then a else raise_type_error d <| sprintf "Type annotation mismatch.\n%s <> %s" (show_ty ta) (show_ty tb)
        | TypeGet, [|a|] -> ev_annot d a |> tyt
        | TypeUnion, l -> 
            let set_field = function UnionT t -> t.node | t -> Set.singleton t
            Array.fold (fun s x -> Set.union s (ev_annot d x |> set_field)) Set.empty l |> uniont |> tyt
        | TypeSplit, [|a|] -> ev_annot d a |> case_type d |> List.map tyt |> TyList
        | TypeRaise, [|a|] -> ev_annot d a |> TypeRaised |> raise
        | TypeCatch, [|a|] -> 
            try ev_annot d a |> tyt
            with
            | :? TypeRaised as x -> tyt x.Data0
            | _ -> reraise()
        | TypeBox, [|a;b|] -> 
            let a_ty = ev_annot d a
            let b = ev d b
            let b_ty = type_get b
            if a_ty = b_ty then b
            elif case_type' d a_ty |> Set.contains b_ty then TyBox(b,a_ty)
            else raise_type_error d <| sprintf "Type constructor application failed. %s is not a subset of %s." (show_ty b_ty) (show_ty a_ty)
        | RecUnionGetName, [|a|] ->
            match ev d a |> type_get with
            | RecUnionT(name,meta,key) -> TyLit (LitString name)
            | x -> raise_type_error d <| sprintf "Expected a recursive union type.\nGot: %s" (show_ty x)
        | RecUnionGetMeta, [|a|] ->
            match ev d a |> type_get with
            | RecUnionT(name,meta,key) -> tyt meta
            | x -> raise_type_error d <| sprintf "Expected a recursive union type.\nGot: %s" (show_ty x)
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
            | a -> push_op d SizeOf (tyt a) (PrimT Int64T)
        | TermFunctionTypeCreate, [|a;b|] -> TermCastedFunctionT(ev_annot d a, ev_annot d b) |> tyt
        | TermFunctionIs, [|a|] -> 
            match ev d a with
            | TyT(TermCastedFunctionT(dom,range)) | TyV(T(_,TermCastedFunctionT(dom,range))) -> TyLit(LitBool true)
            | _ -> TyLit(LitBool false)
        | TermFunctionDomain, [|a|] -> 
            match ev d a with
            | TyT(TermCastedFunctionT(dom,range)) | TyV(T(_,TermCastedFunctionT(dom,range))) -> tyt dom
            | x -> raise_type_error d <| sprintf "Not a term casted function.\nGot: %s" (show_typed_data x)
        | TermFunctionRange, [|a|] -> 
            match ev d a with
            | TyT(TermCastedFunctionT(dom,range)) | TyV(T(_,TermCastedFunctionT(dom,range))) -> tyt range
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
            | _ -> 
                match l with
                | [] -> TyLit(LitString "")
                | [x] -> x 
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
                Map.map (fun k x -> apply d (a, TyKeyword(keyword_key_value,[|TyKeyword(k,[||]); x|]))) l
                |> TyMap
            | _, b -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data b)
        | RecordFilter,[|a;b|] ->
            match ev2 d a b with
            | a, TyMap l ->
                Map.filter (fun k x ->
                    match apply d (a, TyKeyword(keyword_key_value,[|TyKeyword(k,[||]); x|])) with
                    | TyLit(LitBool x) -> x
                    | x -> raise_type_error d <| sprintf "Expected a bool literal in ModuleFilter.\nGot: %s" (show_typed_data x)
                    ) l
                |> TyMap
            | _, b -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data b)
        | RecordFoldL,[|a;b;c|] ->
            match ev3 d a b c with
            | a, s, TyMap l -> Map.fold (fun s k x -> apply d (a, TyKeyword(keyword_key_state_value,[|TyKeyword(k,[||]); s; x|]))) s l
            | _, _, r -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data r)
        | RecordFoldR,[|a;b;c|] ->
            match ev3 d a b c with
            | a, s, TyMap l -> Map.foldBack (fun k x s -> apply d (a, TyKeyword(keyword_key_state_value,[|TyKeyword(k,[||]); s; x|]))) l s
            | _, r, _ -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data r)
        | RecordLength,[|a|] ->
            match ev d a with
            | TyMap l -> Map.count l |> int64 |> LitInt64 |> TyLit
            | r -> raise_type_error d <| sprintf "Expected a record.\nGot: %s" (show_typed_data r)
        | IsLit,[|a|] -> 
            match ev d a with
            | TyLit _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | IsPrim,[|a|] -> 
            match ev d a |> type_get with
            | PrimT _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | IsLayout,[|a|] -> 
            match ev d a |> type_get with
            | LayoutT _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | IsKeyword,[|a|] -> 
            match ev d a with
            | TyKeyword _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | StripKeyword,[|a|] -> 
            match ev d a with
            | TyKeyword(_,l) -> TyList(Array.toList l)
            | a -> raise_type_error d <| sprintf "Expected a keyword.\nGot: %s" (show_typed_data a)
        | IsBox,[|a|] -> 
            match ev d a with
            | TyBox _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | IsUnion,[|a|] -> 
            match ev d a |> type_get with
            | UnionT _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | IsRecUnion,[|a|] -> 
            match ev d a |> type_get with
            | RecUnionT _ -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | IsRuntimeUnion,[|a|] -> 
            match ev d a with
            | TyT (UnionT _) | TyV(T(_,UnionT _)) -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | IsRuntimeRecUnion,[|a|] -> 
            match ev d a with
            | TyT (RecUnionT _) | TyV(T(_,RecUnionT _)) -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)
        | ArrayCreateDotNet,[|a;b|] ->
            match ev_annot d a, ev d b with
            | a, TyType(PrimT Int64T) & b -> push_binop_no_rewrite d ArrayCreateDotNet (tyt a, b) (ArrayT(ArtDotNetHeap, a))
            | _, b -> raise_type_error d <| sprintf "Expected an int64 as the size of the array.\nGot: %s" (show_typed_data b)
        | ArrayCreateCudaLocal,[|a;b|] ->
            match ev_annot d a, ev d b with
            | a, TyType(PrimT Int64T) & b -> push_binop_no_rewrite d ArrayCreateCudaLocal (tyt a, b) (ArrayT(ArtCudaLocal, a))
            | _, b -> raise_type_error d <| sprintf "Expected an int64 as the size of the array.\nGot: %s" (show_typed_data b)
        | ArrayCreateCudaShared,[|a;b|] ->
            match ev_annot d a, ev d b with
            | a, TyLit(LitInt64 _) & b -> push_binop_no_rewrite d ArrayCreateCudaShared (tyt a, b) (ArrayT(ArtCudaShared, a))
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
                        if ty' = ty then push_triop_no_rewrite d SetArray (a,b,c) Types.tyb
                        else raise_type_error d <| sprintf "The array and the value being set do not have the same type.\nGot: %s\nAnd: %s" (show_ty ty) (show_ty ty')
                | b -> raise_type_error d <| sprintf "Expected a int64 as the index argumet in GetArray.\nGot: %s" (show_typed_data b)
            | a -> raise_type_error d <| sprintf "Expected an array in SetArray.\nGot: %s" (show_typed_data a)
        | SetReference,[|a;c|] ->
            match ev d a with
            | TyType (ArrayT(ArtDotNetReference,ty)) & a -> 
                    match ev d c with
                    | TyType ty' & c -> 
                        if ty' = ty then push_binop_no_rewrite d SetReference (a,c) Types.tyb
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
        | IsNan,[|a|] ->
            match ev d a with
            | TyLit (LitFloat32 x) -> System.Single.IsNaN x |> LitBool |> TyLit
            | TyLit (LitFloat64 x) -> System.Double.IsNaN x |> LitBool |> TyLit
            | a & TyType (PrimT (Float32T | Float64T)) -> push_op d IsNan a (PrimT BoolT)
            | x -> raise_type_error d <| sprintf "Expected a float in NanIs. Got: %s" (show_typed_data x)

        // Primitive operations on expressions.
        | Add,[|a;b|] -> 
            let inline op a b = a + b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> TyLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_lit_zero a then b
                    elif is_lit_zero b then a
                    elif is_numeric a_ty then push_binop d Add (a,b) a_ty
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | Sub,[|a;b|] ->
            let inline op a b = a - b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> TyLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_lit_zero a then push_op d Neg b b_ty
                    elif is_lit_zero b then a
                    elif is_numeric a_ty then push_binop d Sub (a,b) a_ty
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | Mult,[|a;b|] ->
            let inline op a b = a * b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> TyLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_int_lit_zero a || is_int_lit_zero b then value_zero d a_ty |> TyLit
                    elif is_lit_one a then b
                    elif is_lit_one b then a
                    elif is_numeric a_ty then push_binop d Mult (a,b) a_ty
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | Pow,[|a;b|] -> 
            let inline op a b = a ** b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32 |> LitFloat32 |> TyLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be both float and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then push_binop d Pow (a,b) a_ty
                else 
                    raise_type_error d <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | Div,[|a;b|] -> 
            let inline op a b = a / b
            try
                match ev2 d a b with
                | TyLit a, TyLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> TyLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> TyLit
                    | a, b -> raise_type_error d <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
                | a, b ->
                    let a_ty, b_ty = type_get a, type_get b 
                    if a_ty = b_ty then
                        if is_lit_zero b then raise (DivideByZeroException())
                        elif is_lit_one b then a
                        elif is_numeric a_ty then push_binop d Div (a,b) a_ty
                        else raise_type_error d <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error d <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            with :? DivideByZeroException ->
                raise_type_error d <| sprintf "An attempt to divide by zero has been detected at compile time."
        | Mod,[|a;b|] -> 
            let inline op a b = a % b
            try
                match ev2 d a b with
                | TyLit a, TyLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> TyLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> TyLit
                    | a, b -> raise_type_error d <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
                | a, b ->
                    let a_ty, b_ty = type_get a, type_get b 
                    if a_ty = b_ty then
                        if is_lit_zero b then raise (DivideByZeroException())
                        elif is_numeric a_ty then push_binop d Mod (a,b) a_ty
                        else raise_type_error d <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error d <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            with :? DivideByZeroException ->
                raise_type_error d <| sprintf "An attempt to divide by zero has been detected at compile time."
        | LT,[|a;b|] ->
            let inline op a b = a < b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
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
                | LitBool a, LitBool b -> op a b |> LitBool |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop d LT (a,b) (PrimT BoolT)
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | LTE,[|a;b|] ->
            let inline op a b = a <= b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
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
                | LitBool a, LitBool b -> op a b |> LitBool |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop d LTE (a,b) (PrimT BoolT)
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | GT,[|a;b|] -> 
            let inline op a b = a > b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
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
                | LitBool a, LitBool b -> op a b |> LitBool |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop d GT (a,b) (PrimT BoolT)
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | GTE,[|a;b|] -> 
            let inline op a b = a >= b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
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
                | LitBool a, LitBool b -> op a b |> LitBool |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop d GTE (a,b) (PrimT BoolT)
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EQ,[|a;b|] -> 
            let inline op a b = a = b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
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
                | LitBool a, LitBool b -> op a b |> LitBool |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | TyV(T(a,a_ty)), TyV(T(b,_)) when a = b && is_non_float_primitive a_ty -> LitBool true |> TyLit
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop d EQ (a,b) (PrimT BoolT)
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | NEQ,[|a;b|] ->
            let inline op a b = a <> b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
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
                | LitBool a, LitBool b -> op a b |> LitBool |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | TyV(T(a,a_ty)), TyV(T(b,_)) when a = b && is_non_float_primitive a_ty -> LitBool false |> TyLit
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop d NEQ (a,b) (PrimT BoolT)
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | BitwiseAnd,[|a;b|] -> 
            let inline op a b = a &&& b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_any_int a_ty then push_binop d BitwiseAnd (a,b) a_ty
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | BitwiseOr,[|a;b|] ->
            let inline op a b = a ||| b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_any_int a_ty then push_binop d BitwiseOr (a,b) a_ty
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | BitwiseXor,[|a;b|] ->
            let inline op a b = a ^^^ b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> TyLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> TyLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> TyLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> TyLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> TyLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if a_ty = b_ty then
                    if is_any_int a_ty then push_binop d BitwiseXor (a,b) a_ty
                    else raise_type_error d <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error d <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | ShiftLeft,[|a;b|] -> 
            let inline op a b = a <<< b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt32 b -> op a b |> LitInt64 |> TyLit
                | LitUInt32 a, LitInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitInt32 b -> op a b |> LitUInt64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The first literal must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if is_int a_ty && is_int32 b_ty then push_binop d ShiftLeft (a,b) a_ty
                else raise_type_error d <| sprintf "The type of the first argument must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_ty a_ty) (show_ty b_ty)
        | ShiftRight,[|a;b|] ->
            let inline op a b = a >>> b
            match ev2 d a b with
            | TyLit a, TyLit b ->
                match a, b with
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> TyLit
                | LitInt64 a, LitInt32 b -> op a b |> LitInt64 |> TyLit
                | LitUInt32 a, LitInt32 b -> op a b |> LitUInt32 |> TyLit
                | LitUInt64 a, LitInt32 b -> op a b |> LitUInt64 |> TyLit
                | a, b -> raise_type_error d <| sprintf "The first literal must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_value a) (show_value b)
            | a, b ->
                let a_ty, b_ty = type_get a, type_get b 
                if is_int a_ty && is_int32 b_ty then push_binop d ShiftRight (a,b) a_ty
                else raise_type_error d <| sprintf "The type of the first argument must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_ty a_ty) (show_ty b_ty)
        | Log,[|a|] ->
            let inline op a = log a
            match ev d a with
            | TyLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> TyLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> TyLit
                | _ -> raise_type_error d <| sprintf "The literal must be a float type.\nGot: %s" (show_value a)
            | a ->
                let a_ty = type_get a
                if is_float a_ty then push_op d Log a a_ty
                else raise_type_error d <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | Exp,[|a|] ->
            let inline op a = exp a
            match ev d a with
            | TyLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> TyLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> TyLit
                | _ -> raise_type_error d <| sprintf "The literal must be a float type.\nGot: %s" (show_value a)
            | a ->
                let a_ty = type_get a
                if is_float a_ty then push_op d Exp a a_ty
                else raise_type_error d <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | Tanh,[|a|] -> 
            let inline op a = tanh a
            match ev d a with
            | TyLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> TyLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> TyLit
                | _ -> raise_type_error d <| sprintf "The literal must be a float type.\nGot: %s" (show_value a)
            | a ->
                let a_ty = type_get a
                if is_float a_ty then push_op d Tanh a a_ty
                else raise_type_error d <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | Sqrt,[|a|] ->
            let inline op a = sqrt a
            match ev d a with
            | TyLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> TyLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> TyLit
                | _ -> raise_type_error d <| sprintf "The literal must be a float type.\nGot: %s" (show_value a)
            | a ->
                let a_ty = type_get a
                if is_float a_ty then push_op d Sqrt a a_ty
                else raise_type_error d <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | Neg,[|a|] ->
            let inline op a = -a
            match ev d a with
            | TyLit a ->
                match a with
                | LitInt8 a -> op a |> LitInt8 |> TyLit
                | LitInt16 a -> op a |> LitInt16 |> TyLit
                | LitInt32 a -> op a |> LitInt32 |> TyLit
                | LitInt64 a -> op a |> LitInt64 |> TyLit
                | LitFloat32 a -> op a |> LitFloat32 |> TyLit
                | LitFloat64 a -> op a |> LitFloat64 |> TyLit
                | _ -> raise_type_error d <| sprintf "The literal must be a signed numeric type.\nGot: %s" (show_value a)
            | a ->
                let a_ty = type_get a
                if is_signed_numeric a_ty then push_op d Neg a a_ty
                else raise_type_error d <| sprintf "The argument must be a signed numeric type.\nGot: %s" (show_ty a_ty)
        | ListCons,[|a;b|] ->
            match ev2 d a b with
            | a, TyList b -> TyList(a::b)
            | a, b -> raise_type_error d <| sprintf "Expected a tuple on the right in ListCons.\nGot: %s" (show_typed_data b)
        | ListCreate, l -> Array.map (ev d) l |> Array.toList |> TyList

        | EqType,[|a;b|] -> type_get (ev d a) = type_get (ev d b) |> LitBool |> TyLit
        | ErrorType,[|a|] -> ev d a |> show_typed_data |> raise_type_error d
        | ErrorNonUnit,[|a'|] -> 
            match ev d a' with
            | TyList [] & a -> a
            | a ->
                let d = match a' with ExprPos(_,x) -> {d with trace = x.Pos :: d.trace} | _ -> d
                raise_type_error d <| sprintf "Only the last expression of a block is allowed to be unit. Use `ignore` if it intended to be such.\nGot: %s" (show_typed_data a)
        | ErrorPatMiss,[|a|] -> ev d a |> show_typed_data |> sprintf "Pattern miss error. The argument is %s" |> raise_type_error d
        | FailWith,[|typ;a|] ->
            match ev2 d typ a with
            | typ, TyType (PrimT StringT) & a -> push_op_no_rewrite d FailWith a (type_get typ)
            | _,a -> raise_type_error d "Expected a string as input to failwith.\nGot: %s" (show_typed_data a)
        | UnsafeCoerceToArrayCudaGlobal,[|a;b|] ->
            match ev2 d a b with
            | TyV(T(x,t')), t -> TyV(T(x,ArrayT(ArtCudaGlobal t',type_get t)))
            | TyT t', t -> tyt(ArrayT(ArtCudaGlobal t',type_get t))
            | _ -> raise_type_error d "Only variables or runtime types can be converted to the Cuda global array type."
        | InfinityF64,[||] -> TyLit (LitFloat64 infinity)
        | InfinityF32,[||] -> TyLit (LitFloat32 infinityf)
        | _ -> raise_type_error d <| sprintf "Compiler error: %A not implemented" op
