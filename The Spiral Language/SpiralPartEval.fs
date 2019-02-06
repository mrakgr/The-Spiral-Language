module Spiral.PartEval

// Global open
open System
open System.Collections.Generic
open Parsing
open Types
open Spiral

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
   
let tyt_to_tyv ty = if ty_is_unit ty then destructure TyT ty else destructure tyv ty

let push_var (d: LangEnv) x =
    d.env_stack.[d.env_stack_ptr] <- x
    {d with env_stack_ptr=d.env_stack_ptr+1}

let rec partial_eval (d: LangEnv) x = 
    let inline ev d x = partial_eval d x
    
    let inline push_var_ptr ptr x = d.env_stack.[ptr] <- x; ptr+1
    let inline v x = let l = d.env_global.Length in if x < l then d.env_global.[x] else d.env_stack.[x - l]
    let inline seq_end_align (end_dat,end_ty) (seq: ResizeArray<_>) =
        if d.seq.Count > 0 then
            match seq.[d.seq.Count-1] with
            | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
            | _ -> d.seq.Add(TyLocalReturnData(end_dat,end_ty,d.trace))
    let inline list_test all_or_n (stack_size,bind,on_succ,on_fail) =
        let inline on_fail() = ev d on_fail
        match v bind with
        | TyList l ->
            if all_or_n then // all
                let rec loop d = function
                    | 1, l -> ev (push_var d (TyList l)) on_succ
                    | i, x :: x' -> loop (push_var d x) (i-1,x')
                    | _, [] -> on_fail()
                loop d (stack_size,l)
            else // n
                let rec loop d = function
                    | 0, [] -> ev d on_succ
                    | _, [] -> on_fail()
                    | i, x :: x' -> loop (push_var d x) (i-1,x')
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
                    | Some x -> loop (push_var d x) (i+1)
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
                | Some this -> push_var d this
                | None -> push_var d tyb
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
        | _ -> failwith "Compiler error: %A not implemented" op
