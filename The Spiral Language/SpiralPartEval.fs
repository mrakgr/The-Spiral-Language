module Spiral.PartEval

// Global open
open System
open System.Collections.Generic
open Parsing
open Types
open System.Runtime.CompilerServices

// Globals
let private join_point_dict_method = Dictionary(HashIdentity.Structural)
let private join_point_dict_closure = Dictionary(HashIdentity.Structural)
let private join_point_dict_type = Dictionary(HashIdentity.Structural)
let private join_point_dict_cuda = Dictionary(HashIdentity.Structural)
let private layout_to_none_dict = ConditionalWeakTable()
let private layout_to_none_dict' = ConditionalWeakTable()

let private hash_cons_table = HashConsing.hashcons_create 0
let private hash_cons_add x = HashConsing.hashcons_add hash_cons_table x

let mutable private tag = 0
let tag () = tag <- tag+1; tag

let keyword_env = Parsing.string_to_keyword "env:" // For join points keys. It is assumed that they will never be printed.
let typed_data_to_consed call_data =
    let dict = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray(64)
    let rec f x =
        memoize dict (function
            | TyList l -> List.map f l |> hash_cons_add |> CTyList
            | TyKeyword(a,b) -> (a,Array.map f b) |> hash_cons_add |> CTyKeyword
            | TyFunction(a,b,c) -> (a,b,Array.map f c) |> hash_cons_add |> CTyFunction
            | TyRecFunction(a,b,c) -> (a,b,Array.map f c) |> hash_cons_add |> CTyRecFunction
            | TyObject(a,b) -> (a,Array.map f b) |> hash_cons_add |> CTyObject
            | TyMap l -> Map.map (fun _ -> f) l |> hash_cons_add |> CTyMap
            | TyV(T(_,ty) as t) -> call_args.Add t; CTyV (call_args.Count-1, ty)
            | TyBox(a,b) -> (f a, b) |> CTyBox
            | TyLit x -> CTyLit x
            | TyT x -> CTyT x
            ) x
    call_args.ToArray(),f call_data

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

let tyv ty = TyV(T(tag(), ty))
let tyb = TyList []

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

let seq_apply (d: LangEnv) (end_dat,end_ty) =
    if d.seq.Count > 0 then
        match d.seq.[d.seq.Count-1] with
        | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
        | _ -> d.seq.Add(TyLocalReturnData(end_dat,end_ty,d.trace))
    d.seq.ToArray()

let layout_to_none (d: LangEnv) = function
    | TyT(LayoutT(C(t,l,h))) | TyV(T(_,LayoutT(C(t,l,h)))) as v -> 
        if h then
            let key = LayoutToNone,v
            match Map.tryFind key !d.cse with
            | None ->
                let inline stmt x = TyLet(x,d.trace,TyOp(LayoutToNone,v,type_get x))
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
        let call_args, consed_data = typed_data_to_consed (layout_to_none d x)
        let ret_ty = (layout,consed_data,call_args.Length > 0) |> hash_cons_add |> LayoutT
        let ret = type_to_tyv ret_ty
        let layout =
            match layout with
            | LayoutStack -> LayoutToStack
            | LayoutHeap -> LayoutToHeap
            | LayoutHeapMutable -> LayoutToHeapMutable
        d.seq.Add(TyLet(ret,d.trace,TyOp(layout,x,ret_ty)))
        ret
    
let rec partial_eval (d: LangEnv) x = 
    let inline ev d x = partial_eval d x
    let inline ev_seq d x =
        let x = ev {d with seq=ResizeArray()} x
        let x_ty = type_get x
        seq_apply d (x,x_ty), x_ty
    
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
                let end_dat = type_to_tyv end_ty
                d.seq.Add(TyLet(end_dat,d.trace,TyCase(v,List.toArray cases,end_ty)))
                end_dat
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
        | Apply,[|a;b|] ->
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
                | TyObject _, b -> raise_type_error d <| sprintf "The second argument to an object application is not a keyword.\nGot: %s" (show_typed_data b)
                | (TyV(T(_,LayoutT _)) | TyT(LayoutT _)) & a, b -> apply d (layout_to_none d a, b)
                | (TyV(T(_,TermCastedFunctionT(clo_arg_ty,clo_ret_ty))) | TyT(TermCastedFunctionT(clo_arg_ty,clo_ret_ty))) & a, b -> 
                    let b_ty = type_get b
                    if clo_arg_ty <> b_ty then raise_type_error d <| sprintf "Cannot apply an argument of type %s to closure (%s => %s)." (show_ty b_ty) (show_ty clo_arg_ty) (show_ty clo_ret_ty)
                    else push_op_no_rewrite d Apply (TyList [a;b]) clo_ret_ty
            apply d (ev d a, ev d b)
        | TermCast,[|a;b|] ->
            // Compiles into a method with two lambda arguments. The second argument resides in `env_local`.
            let join_point_closure (d: LangEnv) body =
                let call_args, consed_env = typed_data_to_consed (TyKeyword(keyword_env, d.env_global))
                let call_args2, consed_env2, domain_ty = 
                    let x = d.env_stack.[0]
                    let call, env = typed_data_to_consed x
                    call, env, type_get x
                let join_point_key = body, CTyList (hash_cons_add [consed_env; consed_env2])
           
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
                let ret = type_to_tyv ret_ty
                d.seq.Add(TyLet(ret, d.trace, TyJoinPoint(join_point_key,JoinPointMethod,call_args,ret_ty)))
                ret
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
            let call_args, consed_env = typed_data_to_consed (TyKeyword(keyword_env, d.env_global))
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

            let ret = type_to_tyv ret_ty
            d.seq.Add(TyLet(ret, d.trace, TyJoinPoint(join_point_key,JoinPointMethod,call_args,ret_ty)))
            ret

        | JoinPointEntryCuda,[|body|] -> 
            let call_args, consed_env = typed_data_to_consed (TyKeyword(keyword_env, d.env_global))
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

            match type_to_tyv ret_ty with
            | TyList [] -> 
                let call_args = Array.map (fun x -> TyV x) call_args |> Array.toList
                TyList (TyLit(LitString <| sprintf "method_%i" tag) :: call_args)
            | _ -> raise_type_error d "The return type of Cuda join point must be unit tuple.\nGot: %s" (show_ty ret_ty)

        | JoinPointEntryType,[|body;name|] -> 
            let name =
                match ev d name with
                | TyLit (LitString name) -> name
                | _ -> raise_type_error d "The name of the recursive type must be a string literal."
            let call_args, consed_env = typed_data_to_consed (TyKeyword(keyword_env, d.env_global))
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
        | _ -> failwith "Compiler error: %A not implemented" op
