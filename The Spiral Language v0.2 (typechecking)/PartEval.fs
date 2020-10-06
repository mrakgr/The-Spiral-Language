﻿module Spiral.PartEval

open System
open System.Collections.Generic
open Spiral.Config
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.Prepass
open Spiral.HashConsing

type Tag = int
type [<CustomComparison;CustomEquality>] L<'a,'b when 'a: equality and 'a: comparison> = 
    | L of 'a * 'b

    override a.Equals(b) =
        match b with
        | :? L<'a,'b> as b -> match a,b with L(a,_), L(b,_) -> a = b
        | _ -> false
    override a.GetHashCode() = match a with L(a,_) -> hash a
    interface IComparable with
        member a.CompareTo(b) = 
            match b with
            | :? L<'a,'b> as b -> match a,b with L(a,_), L(b,_) -> compare a b
            | _ -> raise <| ArgumentException "Invalid comparison for T."

type H<'a when 'a : equality>(x : 'a) = 
    let h = hash x

    member _.Item = x
    override _.Equals(b) =
        match b with
        | :? H<'a> as b -> Object.ReferenceEquals(x,b.Item)
        | _ -> false
    override _.GetHashCode() = h

type StackSize = int
type Nominal = {|body : T; id : int; name : string|} ConsedNode // TODO: When doing incremental compilation, make the `body` field a weak reference.
type Macro = Text of string | Type of Ty
and Ty =
    | YB
    | YPair of Ty * Ty
    | YSymbol of string
    | YTypeFunction of body : T * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
    | YRecord of Map<string, Ty>
    | YPrim of PrimitiveType
    | YArray of Ty
    | YFun of Ty * Ty
    | YMacro of Macro list
    | YNominal of Nominal
    | YApply of Ty * Ty
    | YLayout of Ty * Layout
    | YUnion of Union 
and Data =
    | DB
    | DPair of Data * Data
    | DSymbol of string
    | DFunction of body : E * annot : T option * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
    | DForall of body : E * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
    | DRecord of Map<string, Data>
    | DLit of Literal
    | DUnion of Data * Union
    | DNominal of Data * Ty
    | DV of TyV
and TyV = L<Tag,Ty>
and Union = (Map<string, Ty> * UnionLayout) H // Unions always go through a join point which enables them to be compared via ref eqaulity.

type TermVar =
    | WV of Tag
    | WLit of Literal

type RData =
    | ReB
    | RePair of ConsedNode<RData * RData>
    | ReSymbol of string
    | ReFunction of ConsedNode<E * RData [] * Ty []> // T option and stack sizes are entirely dependent on the body. And unlike in v0.09/v0.1 there are no reified join points.
    | ReForall of ConsedNode<E * RData [] * Ty []>
    | ReRecord of ConsedNode<Map<string, RData>>
    | ReLit of Tokenize.Literal
    | ReUnion of ConsedNode<RData * Union>
    | ReNominal of ConsedNode<RData * Ty>
    | ReV of ConsedNode<Tag * Ty>

type Trace = Range list
type JoinPointKey = 
    | JPMethod of E * ConsedNode<RData [] * Ty []>
    | JPClosure of E * ConsedNode<RData [] * Ty [] * Ty * Ty>

type JoinPointCall = JoinPointKey * TyV []

type CodeMacro =
    | CMText of string
    | CMType of Ty
    | CMTerm of Data

type TypedBind =
    | TyLet of Data * Trace * TypedOp
    | TyLocalReturnOp of Trace * TypedOp
    | TyLocalReturnData of Data * Trace

and TypedOp = 
    | TyMacro of CodeMacro list
    | TyOp of Op * Data list
    | TyUnionBox of string * Data * Union
    | TyUnionUnbox of Tag * Union * Map<string,Data * TypedBind []>
    | TyLayoutToHeap of Data * Ty
    | TyLayoutToHeapMutable of Data * Ty
    | TyLayoutIndexAll of L<Tag,Ty * Layout>
    | TyLayoutIndexByKey of L<Tag,Ty * Layout> * string
    | TyIf of cond: Data * tr: TypedBind [] * fl: TypedBind []
    | TyWhile of cond: JoinPointCall * TypedBind []
    | TyJoinPoint of JoinPointCall

type LangEnv = {
    trace : Trace
    seq : ResizeArray<TypedBind>
    cse : Dictionary<TypedOp, Data> list
    i : int ref
    env_global_type : Ty []
    env_global_term : Data []
    env_stack_type : Ty []
    env_stack_term : Data []
    }

type TopEnv = {
    prototypes : Dictionary<int, E> []
    nominals : Nominal []
    }

let data_to_rdata (hc : HashConsTable) call_data =
    let hc x = hc.Add x
    let m = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray()
    let rec f x =
        Utils.memoize m (function
            | DPair(a,b) -> RePair(hc(f a, f b))
            | DSymbol a -> ReSymbol a
            | DFunction(a,_,b,c,_,_) -> ReFunction(hc(a,Array.map f b,c))
            | DForall(a,b,c,_,_) -> ReFunction(hc(a,Array.map f b,c))
            | DRecord l -> ReRecord(hc(Map.map (fun _ -> f) l))
            | DV(L(_,ty) as t) -> call_args.Add t; ReV(hc (call_args.Count-1,ty))
            | DLit a -> ReLit a
            | DUnion(a,b) -> ReUnion(hc(f a,b))
            | DNominal(a,b) -> ReNominal(hc(f a,b))
            | DB -> ReB
            ) x
    let x = Array.map f call_data
    call_args.ToArray(),x

// This rename is a consideration for when I do incremental compilation.
// In order to allow them to be cleaned by the garbage collection, I do not want the 
// references to unused nodes to end up in anywhere other than join point keys (which will be weak).
let rename_global_term (s : LangEnv) =
    let m = Dictionary(HashIdentity.Reference)
    let rec f x =
        Utils.memoize m (function
            | DPair(a,b) -> DPair(f a, f b)
            | DForall(body,a,b,c,d) -> DForall(body,Array.map f a,b,c,d)
            | DFunction(body,annot,a,b,c,d) -> DFunction(body,annot,Array.map f a,b,c,d)
            | DRecord l -> DRecord(Map.map (fun _ -> f) l)
            | DV(L(_,ty)) -> let x = DV(L(!s.i,ty)) in incr s.i; x
            | DUnion(a,b) -> DUnion(f a,b)
            | DNominal(a,b) -> DNominal(f a,b)
            | DSymbol | DLit | DB as x -> x
            ) x
    for i=0 to s.env_global_term.Length-1 do s.env_global_term.[i] <- f s.env_global_term.[i]

let data_free_vars call_data =
    let m = HashSet(HashIdentity.Reference)
    let free_vars = ResizeArray()
    let rec f x =
        if m.Add x then
            match x with
            | DPair(a,b) -> f a; f b
            | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
            | DRecord l -> Map.iter (fun _ -> f) l
            | DV(L as t) -> free_vars.Add t
            | DUnion(a,_) | DNominal(a,_) -> f a
            | DSymbol | DLit | DB -> ()
    f call_data
    free_vars.ToArray()

let (|C|) (x : _ ConsedNode) = x.node
let rdata_free_vars call_data =
    let m = HashSet(HashIdentity.Reference)
    let free_vars = ResizeArray()
    let rec f x =
        if m.Add x then
            match x with
            | RePair(C(a,b)) -> f a; f b
            | ReForall(C(_,a,_)) | ReFunction(C(_,a,_)) -> Array.iter f a
            | ReRecord(C l) -> Map.iter (fun _ -> f) l
            | ReV(C(a,b)) -> free_vars.Add(L(a,b))
            | ReUnion(C(a,_)) | ReNominal(C(a,_)) -> f a
            | ReSymbol | ReLit | ReB -> ()
    Array.iter f call_data
    free_vars.ToArray()

let data_term_vars call_data =
    let term_vars = ResizeArray(64)
    let rec f = function
        | DPair(a,b) -> f a; f b
        | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
        | DRecord l -> Map.iter (fun _ -> f) l
        | DLit x -> term_vars.Add(WLit x)
        | DV(L(i,_)) -> term_vars.Add(WV i)
        | DUnion(a,_) | DNominal(a,_) -> f a
        | DSymbol | DB -> ()
    f call_data
    term_vars.ToArray()

let lit_to_primitive_type = function
    | LitUInt8 -> UInt8T
    | LitUInt16 -> UInt16T
    | LitUInt32 -> UInt32T
    | LitUInt64 -> UInt64T
    | LitInt8 -> Int8T
    | LitInt16 -> Int16T
    | LitInt32 -> Int32T
    | LitInt64 -> Int64T
    | LitFloat32 -> Float32T
    | LitFloat64 -> Float64T   
    | LitBool -> BoolT
    | LitString -> StringT
    | LitChar -> CharT

let lit_to_ty x = lit_to_primitive_type x |> YPrim

let seq_apply (d: LangEnv) end_dat =
    let inline end_ () = d.seq.Add(TyLocalReturnData(end_dat,d.trace))
    if d.seq.Count > 0 then
        match d.seq.[d.seq.Count-1] with
        | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
        | _ -> end_()
    else end_()
    d.seq.ToArray()

let cse_tryfind (d: LangEnv) key =
    d.cse |> List.tryPick (fun x ->
        match x.TryGetValue key with
        | true, v -> Some v
        | _ -> None
        )

let cse_add (d: LangEnv) k v = (List.head d.cse).Add(k,v)

exception TypeError of Trace * string
let raise_type_error (d: LangEnv) x = raise (TypeError(d.trace,x))

let show_primt = Infer.show_primt
let p = Infer.p

let show_lit = function
    | LitUInt8 x -> sprintf "%iu8" x
    | LitUInt16 x -> sprintf "%iu16" x
    | LitUInt32 x -> sprintf "%iu32" x
    | LitUInt64 x -> sprintf "%iu64" x
    | LitInt8 x -> sprintf "%ii8" x
    | LitInt16 x -> sprintf "%ii16" x
    | LitInt32 x -> sprintf "%ii32" x
    | LitInt64 x -> sprintf "%ii64" x
    | LitFloat32 x -> sprintf "%ff32" x
    | LitFloat64 x -> sprintf "%ff64" x
    | LitBool x -> sprintf "%b" x
    | LitString x -> sprintf "%s" x
    | LitChar x -> sprintf "%c" x

let show_layout_type = Infer.show_layout_type

let show_ty x =
    let rec f prec x =
        let p = p prec
        match x with
        | YB -> "()"
        | YPair(YSymbol a, b) when 0 < a.Length && System.Char.IsLower(a,0) && a.[a.Length-1] = '_' -> 
            let show (s,a) = sprintf "%s: %s" s (f 15 a)
            let rec loop (a,b) = 
                match a,b with
                | s :: s', YPair(a,b) -> show (s,a) :: loop (s',b)
                | s :: [], a -> [show (s,a)]
                | s, a -> [show (String.concat "_" s, a)]
            p 15 (loop (a.Split('_',System.StringSplitOptions.RemoveEmptyEntries) |> (fun x -> x.[0] <- to_upper x.[0]; Array.toList x), b) |> String.concat " ")
        | YPair(YSymbol a, YB) when 0 < a.Length && System.Char.IsLower(a,0) -> to_upper a
        | YPair(a,b) -> p 25 (sprintf "%s, %s" (f 25 a) (f 24 b))
        | YSymbol x -> sprintf ".%s" x
        | YTypeFunction -> p 0 (sprintf "? => ?")
        | YRecord l -> sprintf "{%s}" (l |> Map.toList |> List.map (fun (k,v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "; ")
        | YUnion l -> sprintf "{%s}" (l.Item |> fst |> Map.toList |> List.map (fun (k,v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "| ")
        | YPrim x -> show_primt x
        | YArray a -> p 30 (sprintf "array %s" (f 30 a))
        | YFun(a,b) -> p 20 (sprintf "%s -> %s" (f 20 a) (f 19 b))
        | YMacro a -> p 30 (List.map (function Type a -> f -1 a | Text a -> a) a |> String.concat "")
        | YApply(a,b) -> p 30 (sprintf "%s %s" (f 29 a) (f 30 b))
        | YLayout(a,b) -> p 30 (sprintf "%s %s" (show_layout_type b) (f 30 a))
        | YNominal x -> x.node.name
    f -1 x

let show_data x =
    let rec f prec x =
        let p = p prec
        match x with
        | DB -> "()"
        | DPair(DSymbol a, b) when 0 < a.Length && System.Char.IsLower(a,0) && a.[a.Length-1] = '_' -> 
            let show (s,a) = sprintf "%s: %s" s (f 15 a)
            let rec loop (a,b) = 
                match a,b with
                | s :: s', DPair(a,b) -> show (s,a) :: loop (s',b)
                | s :: [], a -> [show (s,a)]
                | s, a -> [show (String.concat "_" s, a)]
            p 15 (loop (a.Split('_',System.StringSplitOptions.RemoveEmptyEntries) |> (fun x -> x.[0] <- to_upper x.[0]; Array.toList x), b) |> String.concat " ")
        | DPair(DSymbol a, DB) when 0 < a.Length && System.Char.IsLower(a,0) -> to_upper a
        | DPair(a,b) -> p 25 (sprintf "%s, %s" (f 25 a) (f 24 b))
        | DSymbol x -> sprintf ".%s" x
        | DFunction -> p 20 "? -> ?"
        | DForall -> p 0 "forall ?. ?"
        | DRecord l -> sprintf "{%s}" (l |> Map.toList |> List.map (fun (k,v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "; ")
        | DLit a -> show_lit a
        | DV(L(_,ty)) -> show_ty ty
        | DUnion(a,_) -> f prec a
        | DNominal(a,b) -> p 0 (sprintf "%s : %s" (f 0 a) (show_ty b))
    f -1 x

let is_lit = function
    | DLit -> true
    | _ -> false

let is_numeric = function
    | YPrim (UInt8T | UInt16T | UInt32T | UInt64T 
        | Int8T | Int16T | Int32T | Int64T 
        | Float32T | Float64T) -> true
    | _ -> false

let is_signed_numeric = function
    | YPrim (Int8T | Int16T | Int32T | Int64T | Float32T | Float64T) -> true
    | _ -> false

let is_non_float_primitive = function
    | YPrim (Float32T | Float64T) -> false
    | YPrim -> true
    | _ -> false

let is_primitive = function
    | YPrim _ -> true
    | _ -> false

let is_string = function
    | YPrim StringT -> true
    | _ -> false

let is_char = function
    | YPrim CharT -> true
    | _ -> false

let is_primt = function
    | YPrim -> true
    | _ -> false

let is_float = function
    | YPrim (Float32T | Float64T) -> true
    | _ -> false

let is_bool = function
    | YPrim BoolT -> true
    | _ -> false

let is_int = function
    | YPrim (UInt32T | UInt64T | Int32T | Int64T) -> true
    | _ -> false

let is_any_int = function
    | YPrim (UInt8T | UInt16T | UInt32T | UInt64T 
        | Int8T | Int16T | Int32T | Int64T) -> true
    | _ -> false

let is_int64 = function
    | YPrim Int64T -> true
    | _ -> false

let is_int32 = function
    | YPrim Int32T -> true
    | _ -> false

let is_lit_zero = function
    | DLit a ->
        match a with
        | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
        | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL
        | LitFloat32 0.0f | LitFloat64 0.0 -> true
        | _ -> false
    | _ -> false

let is_lit_one = function
    | DLit a ->
        match a with
        | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
        | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL
        | LitFloat32 1.0f | LitFloat64 1.0 -> true
        | _ -> false
    | _ -> false

let is_int_lit_zero = function
    | DLit a ->
        match a with
        | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
        | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL -> true
        | _ -> false
    | _ -> false

let is_int_lit_one = function
    | DLit a ->
        match a with
        | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
        | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL -> true
        | _ -> false
    | _ -> false

let lit_zero = function
    | YPrim Int8T -> LitInt8 0y
    | YPrim Int16T -> LitInt16 0s
    | YPrim Int32T -> LitInt32 0
    | YPrim Int64T -> LitInt64 0L
    | YPrim UInt8T -> LitUInt8 0uy
    | YPrim UInt16T -> LitUInt16 0us
    | YPrim UInt32T -> LitUInt32 0u
    | YPrim UInt64T -> LitUInt64 0UL
    | YPrim Float32T -> LitFloat32 0.0f
    | YPrim Float64T -> LitFloat64 0.0
    | _ -> failwith "Compiler error: Expected a numeric value."

let vt s i = if i < s.env_global_type.Length then s.env_global_type.[i] else s.env_stack_type.[i-s.env_global_type.Length]
let v s i = if i < s.env_global_term.Length then s.env_global_term.[i] else s.env_stack_term.[i-s.env_global_term.Length]
let add_trace (s : LangEnv) r = {s with trace = r :: s.trace}
let store_term (s : LangEnv) i v = s.env_stack_term.[i-s.env_global_term.Length] <- v
let store_ty (s : LangEnv) i v = s.env_stack_type.[i-s.env_global_type.Length] <- v

type PartEvalResult = {
    join_point_method : Dictionary<E,Dictionary<ConsedNode<RData [] * Ty []>,TypedBind [] option * Ty option> * HashConsTable>
    join_point_closure : Dictionary<E,Dictionary<ConsedNode<RData [] * Ty [] * Ty * Ty>,TypedBind [] option> * HashConsTable>
    ty_to_data : Ty -> Data
    }

let peval (env : TopEnv) x =
    let join_point_method = Dictionary(HashIdentity.Reference)
    let join_point_closure = Dictionary(HashIdentity.Reference)
    let join_point_type = Dictionary(HashIdentity.Reference)

    let rec ty_to_data s x =
        let f = ty_to_data s
        match x with
        | YB -> DB
        | YPair(a,b) -> DPair(f a, f b) 
        | YSymbol a -> DSymbol a
        | YRecord l -> DRecord(Map.map (fun _ -> f) l)
        | YUnion | YLayout | YPrim | YArray | YFun | YMacro as x -> let r = DV(L(!s.i,x)) in incr s.i; r
        | YNominal | YApply as a -> DNominal(nominal_apply s a |> ty_to_data s, a)
        | YTypeFunction -> raise_type_error s "Cannot turn a type function to a runtime variable."
    and push_typedop_no_rewrite d op ret_ty =
        let ret = ty_to_data d ret_ty
        d.seq.Add(TyLet(ret,d.trace,op))
        ret
    and push_typedop (d: LangEnv) key ret_ty =
        match cse_tryfind d key with
        | Some x -> x
        | None ->
            let x = ty_to_data d ret_ty
            d.seq.Add(TyLet(x,d.trace,key))
            cse_add d key x
            x
    and push_op_no_rewrite' (d: LangEnv) op l ret_ty = push_typedop_no_rewrite d (TyOp(op,l)) ret_ty
    and push_op_no_rewrite d op a ret_ty = push_op_no_rewrite' d op [a] ret_ty
    and push_binop_no_rewrite d op (a,b) ret_ty = push_op_no_rewrite' d op [a;b] ret_ty
    and push_triop_no_rewrite d op (a,b,c) ret_ty = push_op_no_rewrite' d op [a;b;c] ret_ty

    and push_op' d op a ret_ty = push_typedop d (TyOp(op, a)) ret_ty
    and push_op d op a ret_ty = push_op' d op [a] ret_ty
    and push_binop d op (a,b) ret_ty = push_op' d op [a;b] ret_ty
    and push_triop d op (a,b,c) ret_ty = push_op' d op [a;b;c] ret_ty
    and closure_convert s (body,annot,gl_term,gl_ty,sz_term,sz_ty) =
        let domain, range, ret_ty = 
            match ty s annot with
            | YFun(a,b) as x -> a,b, x
            | annot -> raise_type_error s "Expected a function type in annotation during closure conversion. Got: %s" (show_ty annot)
        let dict, hc_table = Utils.memoize join_point_closure (fun _ -> Dictionary(HashIdentity.Structural), HashConsTable()) body
        let call_args, env_global_value = data_to_rdata hc_table s.env_global_term
        let join_point_key = hc_table.Add(env_global_value, s.env_global_type, domain, range)

        match dict.TryGetValue(join_point_key) with
        | true, _ -> ()
        | false, _ ->
            let s : LangEnv = {
                trace = s.trace
                seq = ResizeArray()
                cse = [Dictionary(HashIdentity.Structural)]
                i = ref 0
                env_global_type = gl_ty
                env_global_term = gl_term
                env_stack_type = Array.zeroCreate<_> sz_ty
                env_stack_term = Array.zeroCreate<_> sz_term
                }
            s.env_stack_term.[0] <- ty_to_data s domain
            rename_global_term s
            dict.[join_point_key] <- None
            let seq,ty = term_scope'' s body
            dict.[join_point_key] <- Some seq
            if range <> ty then raise_type_error s <| sprintf "The annotation of the function does not match its body's type.Got: %s\nExpected: %s" (show_ty ty) (show_ty range)

        push_typedop s (TyJoinPoint(JPClosure(body,join_point_key),call_args)) ret_ty, ret_ty
    and data_to_ty s x =
        let m = Dictionary(HashIdentity.Reference)
        let rec f x =
            Utils.memoize m (function
                | DPair(a,b) -> YPair(f a, f b)
                | DSymbol a -> YSymbol a
                | DRecord l -> YRecord(Map.map (fun _ -> f) l)
                | DUnion(_,a) -> YUnion a
                | DNominal(_,a) | DV(L(_,a)) -> a
                | DLit x -> lit_to_ty x
                | DB -> YB
                | DFunction(_,Some a,_,_,_,_) -> ty s a
                | DFunction(_,None,_,_,_,_) -> raise_type_error s "Cannot convert a function that is not annotated into a type."
                | DForall -> raise_type_error s "Cannot convert a forall into a type."
                ) x
        f x
    and dyn do_lit s x =
        let m = Dictionary(HashIdentity.Reference)
        let mutable dirty = false
        let rec f x =
            Utils.memoize m (function
                | DPair(a,b) -> DPair(f a, f b)
                | DB | DV | DSymbol as a -> a
                | DRecord l -> DRecord(Map.map (fun _ -> f) l)
                | DUnion(DPair(DSymbol k,v),b) -> dirty <- true; push_typedop s (TyUnionBox(k,f v,b)) (YUnion b)
                | DUnion -> raise_type_error s "Compiler error: Malformed union"
                | DNominal(a,b) -> DNominal(f a,b)
                | DLit v as x -> if do_lit then dirty <- true; push_op_no_rewrite s Dyn x (lit_to_ty v) else x // TODO: Since strings are heap allocated, it might be worth it to consider them separate from other literals much like union types.
                | DFunction(body,Some annot,term',ty',sz_term,sz_ty) -> dirty <- true; closure_convert s (body,annot,term',ty',sz_term,sz_ty) |> fst
                | DFunction(_,None,_,_,_,_) -> raise_type_error s "Cannot convert a function that is not annotated into a type."
                | DForall -> raise_type_error s "Cannot convert a forall into a type."
                ) x
        let v = f x
        if dirty then v else x
    and term_scope'' s x =
        let x = term s x |> dyn false s
        let x_ty = data_to_ty s x
        seq_apply s x, x_ty
    and term_scope' s cse x = term_scope'' {s with seq=ResizeArray(); i=ref !s.i; cse=cse :: s.cse} x
    and term_scope s x = term_scope' s (Dictionary(HashIdentity.Structural)) x
    and nominal_apply s x =
        match x with
        | YApply(a,b) ->
            match nominal_apply s a with
            | YTypeFunction(body,gl_ty,sz_term,sz_ty) ->
                let s =
                    {s with
                        env_global_type = gl_ty
                        env_global_term = [||]
                        env_stack_type = Array.zeroCreate<_> sz_ty
                        env_stack_term = Array.zeroCreate<_> sz_term
                        }
                s.env_stack_type.[0] <- b
                ty s body
            | a -> raise_type_error s <| sprintf "Expected a type level function in nominal application.\nGot: %s" (show_ty a)
        | YNominal a -> ty s a.node.body
        | _ -> raise_type_error s <| sprintf "Expected a nominal or a deferred type apply.\nGot: %s" (show_ty x)
    and ty s x =
        match x with
        | TArrow | TJoinPoint -> failwith "Compiler error: Should have been transformed during the prepass."
        | TArrow'(_,scope,i,body) -> 
            assert (i = scope.ty.stack_size)
            YTypeFunction(body,Array.map (vt s) scope.ty.free_vars,scope.term.stack_size,scope.ty.stack_size)
        | TJoinPoint'(r,scope,body) ->
            let dict, hc_table = Utils.memoize join_point_type (fun _ -> Dictionary(HashIdentity.Structural), HashConsTable()) body
            let join_point_key = hc_table.Add(s.env_global_type)
            match dict.TryGetValue(join_point_key) with
            | true, Some ret_ty -> ret_ty
            | true, None -> raise_type_error (add_trace s r) "Type join points must not be unboxed during their definition."
            | false, _ ->
                assert (0 = scope.term.free_vars.Length)
                let s : LangEnv = {
                    trace = r :: s.trace
                    seq = ResizeArray()
                    cse = [Dictionary(HashIdentity.Structural)]
                    i = ref 0
                    env_global_type = Array.map (vt s) scope.ty.free_vars
                    env_global_term = [||]
                    env_stack_type = Array.zeroCreate<_> scope.ty.stack_size
                    env_stack_term = Array.zeroCreate<_> scope.term.stack_size
                    }
                dict.[join_point_key] <- None
                let ret_ty = ty s body
                dict.[join_point_key] <- Some ret_ty
                ret_ty
        | TB -> YB
        | TV i -> vt s i
        | TPair(_,a,b) -> YPair(ty s a, ty s b)
        | TFun(_,a,b) -> YFun(ty s a, ty s b)
        | TRecord(_,a) -> YRecord(Map.map (fun _ -> ty s) a)
        | TUnion(_,(a,b)) -> YUnion(H(Map.map (fun _ -> ty s) a, b))
        | TSymbol(_,a) -> YSymbol a
        | TApply(r,a,b) ->
            let s = add_trace s r
            match ty s a with
            | YRecord a ->
                match ty s b with
                | YSymbol b ->
                    match Map.tryFind b a with
                    | Some x -> x
                    | None -> raise_type_error s <| sprintf  "Cannot find key %s in the record." b
                | b -> raise_type_error s <| sprintf "Expected a symbol in the record application.\nGot: %s" (show_ty b)
            | YNominal | YApply as a -> YApply(a,ty s b)
            | YTypeFunction(body,gl_ty,sz_term,sz_ty) -> 
                let b = ty s b
                let s = 
                    {s with 
                        env_global_type = gl_ty
                        env_global_term = [||]
                        env_stack_type = Array.zeroCreate<_> sz_ty
                        env_stack_term = Array.zeroCreate<_> sz_term
                        }
                s.env_stack_type.[0] <- b
                ty s body
            | a -> raise_type_error s <| sprintf "Expected record, nominal or a type function.\nGot: %s" (show_ty a)
        | TPrim(_,a) -> YPrim a
        | TTerm(_,a) -> term_scope s a |> snd
        | TMacro(r,a) -> let s = add_trace s r in YMacro(a |> List.map (function TMText a -> Text a | TMType a -> Type(ty s a)))
        | TNominal i -> YNominal env.nominals.[i]
        | TArray(_,a) -> YArray(ty s a)
        | TLayout(_,a,b) -> YLayout(ty s a,b)
    and term (s : LangEnv) x = 
        let term2 s a b = term s a, term s b
        let term3 s a b c = term s a, term s b, term s c
        let type_apply s a b =
            match a with
            | DForall(body,gl_term,gl_ty,sz_term,sz_ty) ->
                let s =
                    {s with 
                        env_global_type = gl_ty
                        env_global_term = gl_term
                        env_stack_type = Array.zeroCreate<_> sz_ty
                        env_stack_term = Array.zeroCreate<_> sz_term
                        }
                s.env_stack_type.[0] <- b
                term s body
            | a -> raise_type_error s <| sprintf "Expected a forall.\nGot: %s" (show_data a)

        let rec apply s = function
            | DRecord a, DSymbol b ->
                match Map.tryFind b a with
                | Some a -> a
                | None -> raise_type_error s <| sprintf "Cannot find the key %s inside the record." b
            | DRecord a, DPair(DSymbol b,b') ->
                match Map.tryFind b a with
                | Some a -> apply s (a, b')
                | None -> raise_type_error s <| sprintf "Cannot find the key %s inside the record." b
            | DFunction(body,_,gl_term,gl_ty,sz_term,sz_ty), b ->
                let s : LangEnv = 
                    {s with
                        env_global_type = gl_ty
                        env_global_term = gl_term
                        env_stack_type = Array.zeroCreate<_> sz_ty
                        env_stack_term = Array.zeroCreate<_> sz_term
                        }
                s.env_global_term.[0] <- b
                term s body
            | DForall, _ -> raise_type_error s "Cannot apply a forall with a term."
            | DV(L(_,YFun(domain,range) & a_ty)) & a, b ->
                let b = dyn false s b
                let b_ty = data_to_ty s b
                if domain = b_ty then push_binop_no_rewrite s Apply (a, b) range
                else raise_type_error s <| sprintf "Cannot apply an argument of type %s to a function of type: %s" (show_ty b_ty) (show_ty a_ty)
            | DV(L(i,YLayout(ty,layout))) as a, DSymbol b -> 
                let key = TyLayoutIndexByKey(L(i,(ty,layout)), b)
                match layout with
                | HeapMutable -> push_typedop_no_rewrite s key ty
                | Heap -> push_typedop s key ty
            | DV(L(_,YLayout)), b -> raise_type_error s <| sprintf "Expected a symbol as the index into the layout type.\nGot: %s" (show_data b)
            | a,_ -> raise_type_error s <| sprintf "Expected a function, closure, record or a layout type.\nGot: %s" (show_data a)

        let rec if_ s cond on_succ on_fail = 
            match cond with
            | DLit (LitBool true) -> term s on_succ
            | DLit (LitBool false) -> term s on_fail
            | DV(L(_,YPrim BoolT & type_bool)) ->
                let lit_tr = DLit(LitBool true)
                match cse_tryfind s (TyOp(EQ, [cond; lit_tr])) with
                | Some cond -> if_ s cond on_succ on_fail
                | None ->
                    let lit_fl = DLit(LitBool false)
                    let add_rewrite_cases is_true = 
                        let cse = Dictionary(HashIdentity.Structural)
                        let tr,fl = if is_true then lit_tr, lit_fl else lit_fl, lit_tr
                        let inline op op cond' res = cse.Add(TyOp(op,[cond;cond']),res); cse.Add(TyOp(op,[cond';cond]),res)
                        op EQ lit_tr tr; op NEQ lit_tr fl; op EQ lit_fl fl; op NEQ lit_fl tr
                        cse
                    let tr, type_tr = term_scope' s (add_rewrite_cases true) on_succ
                    let fl, type_fl = term_scope' s (add_rewrite_cases false) on_fail
                    if type_tr = type_fl then
                        if tr.Length = 1 && fl.Length = 1 then
                            match tr.[0], fl.[0] with
                            | TyLocalReturnOp(_,tr), TyLocalReturnOp(_,fl) when tr = fl -> push_typedop_no_rewrite s tr type_tr
                            | TyLocalReturnData(tr',_), TyLocalReturnData(fl',_) -> 
                                match tr', fl' with
                                | tr, fl when tr = fl -> tr
                                | DLit(LitBool false), DLit(LitBool true) -> push_binop s EQ (cond,lit_fl) type_bool
                                | DLit(LitBool false), fl when cond = fl -> lit_fl
                                | DLit(LitBool true), fl -> // boolean or
                                    match fl with
                                    | DLit (LitBool false) -> cond
                                    | _ -> if cond = fl then cond else push_binop s BoolOr (cond,fl) type_bool
                                | tr, DLit(LitBool false) -> // boolean and
                                    match tr with
                                    | DLit(LitBool true) -> cond
                                    | _ -> if cond = tr then cond else push_binop s BoolAnd (cond,tr) type_bool
                                | _ -> push_typedop_no_rewrite s (TyIf(cond,tr,fl)) type_tr
                            | _ -> push_typedop_no_rewrite s (TyIf(cond,tr,fl)) type_tr
                        else push_typedop_no_rewrite s (TyIf(cond,tr,fl)) type_tr
                    else raise_type_error s <| sprintf "Types in branches of If do not match.\nGot: %s and %s" (show_ty type_tr) (show_ty type_fl)
            | cond -> raise_type_error s <| sprintf "Expected a bool in conditional.\nGot: %s" (show_data cond)

        let eq s a b = 
            let inline op a b = a = b
            match a,b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                | LitString a, LitString b -> op a b |> LitBool |> DLit
                | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | DV(L(a,a_ty)), DV(L(b,_)) when a = b && is_non_float_primitive a_ty -> LitBool true |> DLit
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop s EQ (a,b) (YPrim BoolT)
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)    

        let default_lit s (a : string) b =
            let inline f string_to_val val_to_lit val_dsc =
                match string_to_val a with
                | true, x -> val_to_lit x
                | false, _ -> raise_type_error s <| sprintf "Cannot parse the literal as: %s" val_dsc
            match b with
            | YPrim Float32T -> f Single.TryParse LitFloat32 "f32"
            | YPrim Float64T -> f Double.TryParse LitFloat64 "f64"
            | YPrim Int8T -> f SByte.TryParse LitInt8 "i8"
            | YPrim Int16T -> f Int16.TryParse LitInt16 "i16"
            | YPrim Int32T -> f Int32.TryParse LitInt32 "i32"
            | YPrim Int64T -> f Int64.TryParse LitInt64 "i64"
            | YPrim UInt8T -> f Byte.TryParse LitUInt8 "u8"
            | YPrim UInt16T -> f UInt16.TryParse LitUInt16 "u16"
            | YPrim UInt32T -> f UInt32.TryParse LitUInt32 "u32"
            | YPrim UInt64T -> f UInt64.TryParse LitUInt64 "u64"
            | b -> raise_type_error s <| sprintf "Expected a numberic type (f32,f64,i8,i16,i32,i64,u8,u16,u32,u64) as the type of literaly.\nGot: %s" (show_ty b)

        let lit_test s a bind on_succ on_fail =
            let b = v s bind
            if lit_to_ty a = data_to_ty s b then if_ s (eq s (DLit a) b) on_succ on_fail
            else term s on_fail

        let inline nan_guardf32 x = if Single.IsNaN x then raise_type_error s "A 32-bit floating point operation resulting in a nan detected at compile time." else x
        let inline nan_guardf64 x = if Double.IsNaN x then raise_type_error s "A 64-bit floating point operation resulting in a nan detected at compile time." else x

        match x with
        | EB -> DB
        | EV a -> v s a
        | ELit(_,a) -> DLit a
        | ESymbol(_,a) -> DSymbol a
        | EFun -> failwith "Compiler error: Raw functions should be transformed during the prepass."
        | EFun'(_,free_vars,i,body,annot) -> 
            assert (free_vars.term.free_vars.Length = i)
            DFunction(body,annot,Array.map (v s) free_vars.term.free_vars,Array.map (vt s) free_vars.ty.free_vars,free_vars.term.stack_size,free_vars.ty.stack_size)
        | EForall -> failwith "Compiler error: Raw foralls should be transformed during the prepass."
        | EForall'(_,free_vars,i,body) ->
            assert (free_vars.ty.free_vars.Length = i)
            DForall(body,Array.map (v s) free_vars.term.free_vars,Array.map (vt s) free_vars.ty.free_vars,free_vars.term.stack_size,free_vars.ty.stack_size)
        | ERecursive a -> term s !a
        | ERecBlock -> failwith "Compiler error: Recursive blocks should be inlined and eliminated during the prepass."
        | EJoinPoint -> failwith "Compiler error: Raw join points should be transformed during the prepass."
        | EJoinPoint'(r,scope,body,annot) ->
            let dict, hc_table = Utils.memoize join_point_method (fun _ -> Dictionary(HashIdentity.Structural), HashConsTable()) body
            let call_args, env_global_value = data_to_rdata hc_table s.env_global_term
            let join_point_key = hc_table.Add(env_global_value, s.env_global_type)

            let ret_ty =
                match dict.TryGetValue(join_point_key) with
                | true, (_, Some ret_ty) -> ret_ty
                | true, (_, None) -> raise_type_error (add_trace s r) "Recursive join points must be annotated."
                | false, _ ->
                    let s : LangEnv = {
                        trace = r :: s.trace
                        seq = ResizeArray()
                        cse = [Dictionary(HashIdentity.Structural)]
                        i = ref 0
                        env_global_type = Array.map (vt s) scope.ty.free_vars
                        env_global_term = Array.map (v s) scope.term.free_vars
                        env_stack_type = Array.zeroCreate<_> scope.ty.stack_size
                        env_stack_term = Array.zeroCreate<_> scope.term.stack_size
                        }
                    rename_global_term s
                    let annot = Option.map (ty s) annot
                    dict.[join_point_key] <- (None, annot)
                    let seq,ty = term_scope'' s body
                    dict.[join_point_key] <- (Some seq, Some ty)
                    annot |> Option.iter (fun annot -> if annot <> ty then raise_type_error s <| sprintf "The annotation of the join point does not match its body's type.Got: %s\nExpected: %s" (show_ty ty) (show_ty annot))
                    ty

            push_typedop_no_rewrite s (TyJoinPoint(JPMethod(body,join_point_key),call_args)) ret_ty
        | EDefaultLit(r,a,b) -> let s = add_trace s r in default_lit s a (ty s b) |> DLit
        | EType(r,_) -> raise_type_error (add_trace s r) "Raw types are not allowed on the term level."
        | EApply(r,a,b) -> let s = add_trace s r in apply s (term s a, term s b)
        | ETypeApply(r,a,b) ->
            let s = add_trace s r
            type_apply s (term s a) (ty s b)
        | ERecordWith(r,vars,withs,withouts) ->
            let s = add_trace s r
            let fold f a b = List.fold f b a
            let inline var r a on_succ = 
                match term s a with
                | DSymbol a -> on_succ a
                | a -> raise_type_error (add_trace s r) <| sprintf "Expected a symbol.\nGot: %s" (show_data a)
            List.fold (fun m (r,x) ->
                let s = add_trace s r
                match m with
                | Some a -> 
                    match term s x with
                    | DSymbol b -> 
                        match Map.tryFind b a with
                        | Some (DRecord a) -> Some a
                        | Some a -> raise_type_error s <| sprintf "Expected a record as the result of indexing.\nGot: %s" (show_data a)
                        | None -> raise_type_error s <| sprintf "Cannot find the key %s in a record." b
                    | b -> raise_type_error s <| sprintf "Expected a symbol.\nGot: %s" (show_data b)
                | None -> 
                    match term s x with
                    | DRecord l -> Some l
                    | a -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data a)
                ) None vars
            |> Option.defaultValue Map.empty
            |> fold (fun m x -> 
                let sym a b = Map.add a (term s b) m
                let sym_mod r a b = 
                    match Map.tryFind a m with
                    | Some a' -> Map.add a (apply s (term s b, a')) m
                    | None -> raise_type_error (add_trace s r) "Cannot find key %s in record." a
                match x with
                | RSymbol((_,a),b) -> sym a b
                | RSymbolModify((r,a),b) -> sym_mod r a b
                | RVar((r,a),b) -> var r a (fun a -> sym a b)
                | RVarModify((r,a),b) -> var r a (fun a -> sym_mod r a b)
                ) withs
            |> fold (fun m -> function
                | WSymbol(r,a) -> Map.remove a m
                | WVar(r,a) -> var r a (fun a -> Map.remove a m)
                ) withouts
            |> DRecord
        | EPatternMemo | EReal -> failwith "Compiler error: Should have been eliminated during the prepass."
        | ERecord a -> DRecord(Map.map (fun _ -> term s) a)
        | EPair(r,a,b) -> DPair(term s a, term s b)
        | ESeq(r,a,b) -> 
            let s = add_trace s r
            match term s a with
            | DB -> term s b
            | a -> raise_type_error s <| sprintf "Expected unit.\nGot: %s" (show_data a)
        | EAnnot(r,a,b) ->
            let s = add_trace s r
            let a = term s a 
            let a_ty = data_to_ty s a
            let b = ty s b
            if a_ty <> b then raise_type_error s <| sprintf "The body does not match the annotation.\nGot: %s\nExpected: %s" (show_ty a_ty) (show_ty b)
            a
        | EPatternMiss a -> raise_type_error s "Pattern miss.\nGot: %s" (show_data (term s a))
        | EIfThenElse(r,cond,tr,fl) -> let s = add_trace s r in if_ s (term s cond) tr fl
        | EIfThen(r,cond,tr) -> let s = add_trace s r in if_ s (term s cond) tr (EB r)
        | EHeapMutableSet(r,a,b,c) ->
            let s = add_trace s r
            let a = term s a
            let a_layout_ty =
                match a with
                | DV(L(_,YLayout(a,b))) -> a
                | _ -> raise_type_error s <| sprintf "Expected a layout type.\nGot: %s" (show_data a)
            let b = List.map (fun (r,b) -> r, term s b) b
            let c_ty =
                List.fold (fun (r,a) (r',b) ->
                    match a with
                    | YRecord a ->
                        match b with
                        | DSymbol b ->
                            match Map.tryFind b a with
                            | Some a -> r', a
                            | None -> raise_type_error (add_trace s r) <| sprintf "Key %s not found in the layout type." b
                        | b -> raise_type_error (add_trace s r') <| sprintf "Expected a symbol.\nGot: %s" (show_data b)
                    | a -> raise_type_error (add_trace s r) <| sprintf "Expected a record.\nGot: %s" (show_ty a)
                    ) (r,a_layout_ty) b |> snd
            let c = term s c |> dyn false s
            if data_to_ty s c = c_ty then push_typedop_no_rewrite s (TyOp(LayoutSet,c :: a :: List.map snd b)) YB
            else raise_type_error s <| sprintf "The two side do not have the same type.\nGot: %s\nExpected: %s" (show_ty a_layout_ty) (show_ty c_ty)
        | EMacro(r,a,b) ->
            let s = add_trace s r
            let a = a |> List.map (function MText x -> CMText x | MTerm x -> CMTerm(term s x |> dyn false s) | MType x -> CMType(ty s x))
            push_typedop_no_rewrite s (TyMacro(a)) (ty s b)
        | EPrototypeApply(r,a,b) ->
            let a = env.prototypes.[a]
            let rec loop = function
                | YNominal b -> term s a.[b.node.id]
                | YApply(a,b) -> type_apply s (loop a) b
                | b -> raise_type_error s <| sprintf "Expected a nominal or a deferred type apply.\nGot: %s" (show_ty b)
            loop (ty s b)
        | ENominal(r,a,b) ->
            let a = term s a
            let b = ty s b
            match nominal_apply s b with
            | YUnion h ->
                match a with
                | DPair(DSymbol k, v) ->
                    let v_ty = data_to_ty s v
                    match Map.tryFind k (fst h.Item) with
                    | Some v_ty' when v_ty = v_ty' -> DNominal(DUnion(a,h),b) 
                    | Some v_ty' -> raise_type_error s <| sprintf "For key %s, The type of the value does not match the union case.\nGot: %s\nExpected: %s" k (show_ty v_ty) (show_ty v_ty')
                    | None -> raise_type_error s <| sprintf "The union does not have key %s.\nGot: %s" k (show_ty b)
                | _ -> raise_type_error s <| sprintf "Compiler error: Expected key/value pair.\nGot: %s" (show_data a)
            | b ->
                let a_ty = data_to_ty s a
                if a_ty = b then DNominal(a,b)
                else raise_type_error s <| sprintf "Type error in nominal constructor.\nGot: %s\nExpected: %s" (show_ty a_ty) (show_ty b)
        | EUnbox(r,id,a,b) ->
            let s = add_trace s r
            match term s a with
            | DNominal(DUnion(a,_),_) -> store_term s id a; term s b
            | DNominal(DV(L(i,YUnion h)) & a,_) ->
                let key = TyOp(Unbox,[a])
                match cse_tryfind s key with
                | Some a -> store_term s id a; term s b
                | None ->
                    let mutable case_ty = None
                    let cases =
                        Map.map (fun k v ->
                            let s = {s with i = ref !s.i; cse = Dictionary(HashIdentity.Structural) :: s.cse; seq = ResizeArray()}
                            let a = ty_to_data s v
                            cse_add s key a
                            let x = store_term s id a; term s b |> dyn false s
                            let x_ty' = data_to_ty s x
                            match case_ty with
                            | Some x_ty -> if x_ty' <> x_ty then raise_type_error s <| sprintf "One union case for key %s has a different return that the previous one.\nGot: %s\nExpected: %s" k (show_ty x_ty') (show_ty x_ty)
                            | None -> case_ty <- Some x_ty'
                            a, seq_apply s x
                            ) (fst h.Item)
                    push_typedop_no_rewrite s (TyUnionUnbox(i,h,cases)) (Option.get case_ty)
            | a -> raise_type_error s <| sprintf "Expected an union type.\nGot: %s" (show_data a)
        | ELet(r,i,a,b) -> let s = add_trace s r in store_term s i (term s a); term s b
        | EPairTest(r,bind,p1,p2,on_succ,on_fail) ->
            let s = add_trace s r
            match v s bind with
            | DPair(a,b) -> store_term s p1 a; store_term s p2 b; term s on_succ
            | _ -> term s on_fail
        | ESymbolTest(r,a,bind,on_succ,on_fail) ->
            let s = add_trace s r
            match v s bind with
            | DSymbol a' when a = a' -> term s on_succ
            | _ -> term s on_fail
        | ERecordTest(r,a,bind,on_succ,on_fail) ->
            let s = add_trace s r
            match v s bind with
            | DRecord l ->
                let rec loop = function
                    | x :: x' ->
                        let sym a b =
                            match Map.tryFind a l with
                            | Some a -> store_term s b a; loop x'
                            | None -> term s on_fail
                        match x with
                        | Symbol((_,a),b) -> sym a b
                        | Var((r,a),b) ->
                            match term s a with
                            | DSymbol a -> sym a b
                            | a -> raise_type_error (add_trace s r) <| sprintf "Expected a symbol.\nGot: %s" (show_data a)
                    | [] -> term s on_succ
                loop a
            | _ -> term s on_fail
        | EAnnotTest(r,a,bind,on_succ,on_fail) -> let s = add_trace s r in if data_to_ty s (v s bind) = ty s a then term s on_succ else term s on_fail
        | EUnitTest(r,bind,on_succ,on_fail) -> let s = add_trace s r in match v s bind with DB -> term s on_succ | _ -> term s on_fail
        | ENominalTest(r,a,bind,p1,on_succ,on_fail) ->
            let s = add_trace s r
            match ty s a with
            | YNominal a ->
                match v s bind with
                | DNominal((DUnion | DV(L(_,YUnion))),_) -> raise_type_error s "Got an union in a nominal pattern."
                | DNominal(v,b) ->
                    let rec loop = function
                        | YNominal b -> if a = b then store_term s p1 v; term s on_succ else term s on_fail
                        | YApply(a,_) -> loop a
                        | _ -> raise_type_error s "Compiler error: Expected a deferred type apply or a nominal."
                    loop b
                | _ -> term s on_fail
            | a -> raise_type_error s <| sprintf "Expected a nominal on the left side of the pattern.\nGot: %s" (show_ty a)
        | ELitTest(r,a,bind,on_succ,on_fail) -> let s = add_trace s r in lit_test s a bind on_succ on_fail
        | EDefaultLitTest(r,a,b,bind,on_succ,on_fail) -> let s = add_trace s r in lit_test s (default_lit s a (ty s b)) bind on_succ on_fail
        | ETypeLet(r,i,a,b) -> let s = add_trace s r in store_ty s i (ty s a); term s b
        | ETypePairTest(r,bind,p1,p2,on_succ,on_fail) ->
            let s = add_trace s r
            match vt s bind with
            | YPair(a,b) -> store_ty s p1 a; store_ty s p2 b; term s on_succ
            | _ -> term s on_fail
        | ETypeFunTest(r,bind,p1,p2,on_succ,on_fail) ->
            let s = add_trace s r
            match vt s bind with
            | YFun(a,b) -> store_ty s p1 a; store_ty s p2 b; term s on_succ
            | _ -> term s on_fail
        | ETypeRecordTest(r,p,bind,on_succ,on_fail) ->
            let s = add_trace s r
            match vt s bind with
            | YRecord l -> 
                let mutable is_succ = true
                Map.iter (fun k p ->
                    match Map.tryFind k l with
                    | Some v -> store_ty s p v
                    | None -> is_succ <- false
                    ) p
                if is_succ then term s on_succ else term s on_fail
            | _ -> term s on_fail
        | ETypeApplyTest(r,bind,p1,p2,on_succ,on_fail) ->
            let s = add_trace s r
            match vt s bind with
            | YApply(a,b) -> store_ty s p1 a; store_ty s p2 b; term s on_succ
            | _ -> term s on_fail
        | ETypeArrayTest(r,bind,p,on_succ,on_fail) ->
            let s = add_trace s r
            match vt s bind with
            | YArray a -> store_ty s p a; term s on_succ
            | _ -> term s on_fail
        | ETypeEq(r,a,b,on_succ,on_fail) ->
            let s = add_trace s r
            if ty s a = vt s b then term s on_succ
            else term s on_fail
        | EOp(_,While,[cond;body]) -> 
            match term_scope'' s cond with
            | [|TyLocalReturnOp(_,TyJoinPoint cond)|], ty ->
                match ty with
                | YPrim BoolT -> 
                    match term_scope s body with
                    | body, YB & ty -> push_typedop s (TyWhile(cond,body)) ty
                    | _, ty -> raise_type_error s <| sprintf "The body of the while loop must be of type unit.\nGot: %s" (show_ty ty)
                | _ -> raise_type_error s <| sprintf "The conditional of the while loop must be of type bool.\nGot: %s" (show_ty ty)
            | _ -> raise_type_error s "Compiler error: The body of the conditional of the while loop must be a solitary join point."
        | EOp(_,LayoutToHeap,[a]) -> 
            let x = dyn false s (term s a)
            let ty = data_to_ty s x
            let key = TyLayoutToHeap(x,ty)
            push_typedop_no_rewrite s key (YLayout(ty,Heap))
        | EOp(_,LayoutToHeapMutable,[a]) -> 
            let x = dyn false s (term s a)
            let ty = data_to_ty s x
            let key = TyLayoutToHeapMutable(x,ty)
            push_typedop_no_rewrite s key (YLayout(ty,HeapMutable))
        | EOp(_,LayoutIndex,[a]) -> 
            match term s a with
            | DV(L(i,YLayout(ty,layout))) as a -> 
                let v = L(i,(ty,layout))
                match layout with
                | HeapMutable -> push_typedop_no_rewrite s (TyLayoutIndexAll v) ty
                | Heap -> 
                    match ty with
                    | YRecord l -> DRecord(Map.map (fun b ty -> push_typedop s (TyLayoutIndexByKey(v,b)) ty) l)
                    | _ -> push_typedop s (TyLayoutIndexAll v) ty
            | a -> raise_type_error s <| sprintf "Expected a layout type.\nGot: %s" (show_data a)
        | EOp(_,TypeToVar,[EType(_,a)]) -> push_typedop_no_rewrite s (TyOp(TypeToVar,[])) (ty s a)
        | EOp(_,TypeToVar,_) -> raise_type_error s "Malformed TypeToVar."
        | EOp(_,Dyn,[a]) -> term s a |> dyn true s
        | EOp(_,StringLength,[a]) ->
            match term s a with
            | DLit(LitString str) -> DLit (LitInt32 str.Length)
            | DV(L(_,YPrim StringT)) & str -> push_op s StringLength str (YPrim Int64T)
            | x -> raise_type_error s <| sprintf "Expected a string.\nGot: %s" (show_data x)
        | EOp(_,StringIndex,[a;b]) ->
            match term2 s a b with
            | DLit(LitString a), DLit(LitInt32 b) ->
                if b >= 0 && b < a.Length then a.[b] |> LitChar |> DLit
                else raise_type_error s <| sprintf "String index out of bounds. length: %i index: %i" a.Length b
            | a,b ->
                match data_to_ty s a, data_to_ty s b with
                | YPrim StringT,YPrim Int32T -> push_binop s StringIndex (a,b) (YPrim CharT)
                | a,b -> raise_type_error s <| sprintf "Expected a string and an i32 as arguments.\nstring: %s\ni: %s" (show_ty a) (show_ty b)
        | EOp(_,StringSlice,[a;b;c]) ->
            match term3 s a b c with
            | DLit(LitString a), DLit(LitInt32 b), DLit(LitInt32 c) ->
                if b >= 0 && c < a.Length then a.[b..c] |> LitString |> DLit
                else raise_type_error s <| sprintf "String slice out of bounds. length: %i from: %i to: %i" a.Length b c
            | a,b,c ->
                match data_to_ty s a, data_to_ty s b, data_to_ty s c with
                | YPrim StringT, YPrim Int32T, YPrim Int32T -> push_triop s StringSlice (a,b,c) (YPrim StringT)
                | a,b,c -> raise_type_error s <| sprintf "Expected a string and two i32s as arguments.\nstring: %s\nfrom: %s\nto: %s" (show_ty a) (show_ty b) (show_ty c)
        | EOp(_,ArrayCreate,[EType(_,a);b]) ->
            let a,b = ty s a, term s b
            match data_to_ty s b with
            | YPrim Int32T -> push_op_no_rewrite s ArrayCreate b (YArray a)
            | b -> raise_type_error s <| sprintf "Expected an i32 as the size of the array.\nGot: %s" (show_ty b)
        | EOp(_,ArrayLength,[a]) ->
            let a = term s a
            match data_to_ty s a with
            | YArray -> push_op s ArrayLength a (YPrim Int32T)
            | a -> raise_type_error s <| sprintf "Array length is only supported for non-native arrays. Got: %s" (show_ty a)
        | EOp(_,ArrayIndex,[a;b]) ->
            match term s a with
            | DV(L(_,YArray ty)) & a ->
                let b = term s b
                match data_to_ty s b with
                | YPrim Int64T -> push_binop_no_rewrite s ArrayIndex (a,b) ty
                | b -> raise_type_error s <| sprintf "Expected a i32 as the index argumet.\nGot: %s" (show_ty b)
            | a -> raise_type_error s <| sprintf "Expected an array.\nGot: %s" (show_data a)
        | EOp(_,ArrayIndexSet,[a;b;c]) ->
            match term s a with
            | DV(L(_,YArray ty)) & a ->
                let b = term s b
                match data_to_ty s b with
                | YPrim Int32T -> 
                    let c = term s c
                    let ty' = data_to_ty s c
                    if ty' = ty then push_triop_no_rewrite s ArrayIndexSet (a,b,c) YB
                    else raise_type_error s <| sprintf "The array and the value being set do not have the same type.\nGot: %s\nExpected: %s" (show_ty ty') (show_ty ty)
                | b -> raise_type_error s <| sprintf "Expected a i32 as the index argumet.\nGot: %s" (show_ty b)
            | a -> raise_type_error s <| sprintf "Expected an array.\nGot: %s" (show_data a)
        | EOp(_,RecordMap,[a;b]) ->
            match term2 s a b with
            | a, DRecord l -> Map.map (fun k v -> apply s (a, DPair(DSymbol "key_value_", DPair(DSymbol k,v)))) l |> DRecord
            | _, b -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data b)
        | EOp(_,RecordFilter,[a;b]) ->
            match term2 s a b with
            | a, DRecord l ->
                Map.filter (fun k v ->
                    match apply s (a, DPair(DSymbol "key_value_", DPair(DSymbol k,v))) with
                    | DLit(LitBool x) -> x
                    | x -> raise_type_error s <| sprintf "Expected a bool literal in ModuleFilter.\nGot: %s" (show_data x)
                    ) l
                |> DRecord
            | _, b -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data b)
        | EOp(_,RecordFoldL,[a;b;c]) ->
            match term3 s a b c with
            | a, state, DRecord l -> Map.fold (fun state k v -> apply s (a, DPair(DSymbol "state_key_value_", DPair(state, DPair(DSymbol k,v))))) state l
            | _, _, r -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data r)
        | EOp(_,RecordFoldR,[a;b;c]) ->
            match term3 s a b c with
            | a, state, DRecord l -> Map.foldBack (fun k v state -> apply s (a, DPair(DSymbol "state_key_value_", DPair(state, DPair(DSymbol k,v))))) l state
            | _, r, _ -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data r)
        | EOp(_,RecordLength,[a]) ->
            match term s a with
            | DRecord l -> Map.count l |> int64 |> LitInt64 |> DLit
            | r -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data r)
        | EOp(_,Add,[a;b]) -> 
            let inline op a b = a + b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_lit_zero a then b
                    elif is_lit_zero b then a
                    elif is_numeric a_ty then push_binop s Add (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,Sub,[a;b]) ->
            let inline op a b = a - b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_lit_zero a then push_op s Neg b b_ty
                    elif is_lit_zero b then a
                    elif is_numeric a_ty then push_binop s Sub (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,Mult,[a;b]) ->
            let inline op a b = a * b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_int_lit_zero a || is_int_lit_zero b then lit_zero a_ty |> DLit
                    elif is_lit_one a then b
                    elif is_lit_one b then a
                    elif is_numeric a_ty then push_binop s Mult (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,Div,[a;b]) -> 
            let inline op a b = a / b
            try
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_lit_zero b then raise (DivideByZeroException())
                        elif is_lit_one b then a
                        elif is_numeric a_ty then push_binop s Div (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            with :? DivideByZeroException ->
                raise_type_error s <| sprintf "An attempt to divide by zero has been detected at compile time."
        | EOp(_,Pow,[a;b]) -> 
            let inline op a b = a ** b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32 |> LitFloat32 |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be both float and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then push_binop s Pow (a,b) a_ty
                else 
                    raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,Mod,[a;b]) -> 
            let inline op a b = a % b
            try
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_lit_zero b then raise (DivideByZeroException())
                        elif is_numeric a_ty then push_binop s Mod (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            with :? DivideByZeroException ->
                raise_type_error s <| sprintf "An attempt to divide by zero has been detected at compile time."
        | EOp(_,LT,[a;b]) ->
            let inline op a b = a < b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                | LitString a, LitString b -> op a b |> LitBool |> DLit
                | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop s LT (a,b) (YPrim BoolT)
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,LTE,[a;b]) ->
            let inline op a b = a <= b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                | LitString a, LitString b -> op a b |> LitBool |> DLit
                | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop s LTE (a,b) (YPrim BoolT)
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,GT,[a;b]) -> 
            let inline op a b = a > b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                | LitString a, LitString b -> op a b |> LitBool |> DLit
                | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop s GT (a,b) (YPrim BoolT)
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,GTE,[a;b]) -> 
            let inline op a b = a >= b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                | LitString a, LitString b -> op a b |> LitBool |> DLit
                | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop s GTE (a,b) (YPrim BoolT)
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,EQ,[a;b]) -> eq s (term s a) (term s b)
        | EOp(_,NEQ,[a;b]) ->
            let inline op a b = a <> b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                | LitString a, LitString b -> op a b |> LitBool |> DLit
                | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | DV(L(a,a_ty)), DV(L(b,_)) when a = b && is_non_float_primitive a_ty -> LitBool false |> DLit
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_primitive a_ty then push_binop s NEQ (a,b) (YPrim BoolT)
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,BitwiseAnd,[a;b]) -> 
            let inline op a b = a &&& b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_any_int a_ty then push_binop s BitwiseAnd (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,BitwiseOr,[a;b]) ->
            let inline op a b = a ||| b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_any_int a_ty then push_binop s BitwiseOr (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,BitwiseXor,[a;b]) ->
            let inline op a b = a ^^^ b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if a_ty = b_ty then
                    if is_any_int a_ty then push_binop s BitwiseXor (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                else
                    raise_type_error s <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
        | EOp(_,ShiftLeft,[a;b]) -> 
            let inline op a b = a <<< b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt32 b -> op a b |> LitInt64 |> DLit
                | LitUInt32 a, LitInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitInt32 b -> op a b |> LitUInt64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The first literal must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if is_int a_ty && is_int32 b_ty then push_binop s ShiftLeft (a,b) a_ty
                else raise_type_error s <| sprintf "The type of the first argument must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_ty a_ty) (show_ty b_ty)
        | EOp(_,ShiftRight,[a;b]) ->
            let inline op a b = a >>> b
            match term2 s a b with
            | DLit a, DLit b ->
                match a, b with
                | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                | LitInt64 a, LitInt32 b -> op a b |> LitInt64 |> DLit
                | LitUInt32 a, LitInt32 b -> op a b |> LitUInt32 |> DLit
                | LitUInt64 a, LitInt32 b -> op a b |> LitUInt64 |> DLit
                | a, b -> raise_type_error s <| sprintf "The first literal must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_lit a) (show_lit b)
            | a, b ->
                let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                if is_int a_ty && is_int32 b_ty then push_binop s ShiftRight (a,b) a_ty
                else raise_type_error s <| sprintf "The type of the first argument must be a 32 or 64 bit int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_ty a_ty) (show_ty b_ty)
        | EOp(_,Neg,[a]) ->
            let inline op a = -a
            match term s a with
            | DLit a ->
                match a with
                | LitInt8 a -> op a |> LitInt8 |> DLit
                | LitInt16 a -> op a |> LitInt16 |> DLit
                | LitInt32 a -> op a |> LitInt32 |> DLit
                | LitInt64 a -> op a |> LitInt64 |> DLit
                | LitFloat32 a -> op a |> LitFloat32 |> DLit
                | LitFloat64 a -> op a |> LitFloat64 |> DLit
                | _ -> raise_type_error s <| sprintf "The literal must be a signed numeric type.\nGot: %s" (show_lit a)
            | a ->
                let a_ty = data_to_ty s a
                if is_signed_numeric a_ty then push_op s Neg a a_ty
                else raise_type_error s <| sprintf "The argument must be a signed numeric type.\nGot: %s" (show_ty a_ty)
        | EOp(_,Tanh,[a]) -> 
            let inline op a = tanh a
            match term s a with
            | DLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
            | a ->
                let a_ty = data_to_ty s a
                if is_float a_ty then push_op s Tanh a a_ty
                else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | EOp(_,Log,[a]) ->
            let inline op a = log a
            match term s a with
            | DLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
            | a ->
                let a_ty = data_to_ty s a
                if is_float a_ty then push_op s Log a a_ty
                else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | EOp(_,Exp,[a]) ->
            let inline op a = exp a
            match term s a with
            | DLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
            | a ->
                let a_ty = data_to_ty s a
                if is_float a_ty then push_op s Exp a a_ty
                else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | EOp(_,Sqrt,[a]) ->
            let inline op a = sqrt a
            match term s a with
            | DLit a ->
                match a with
                | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
            | a ->
                let a_ty = data_to_ty s a
                if is_float a_ty then push_op s Sqrt a a_ty
                else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
        | EOp(_,Infinity,[EType(_,a)]) -> 
            match ty s a with
            | YPrim Float32T -> DLit (LitFloat32 infinityf)
            | YPrim Float64T -> DLit (LitFloat64 infinity)
            | a -> raise_type_error s "Expected a float.\nGot: %s" (show_ty a)
        | EOp(_,NanIs,[a]) ->
            let a = term s a
            match data_to_ty s a with
            | YPrim (Float32T | Float64T) -> push_op s NanIs a (YPrim BoolT)
            | a -> raise_type_error s <| sprintf "Expected a float in NanIs. Got: %s" (show_ty a)
        | EOp(_,LitIs,[a]) -> 
            match term s a with
            | DLit -> DLit (LitBool true)
            | _ -> DLit (LitBool false)
        | EOp(_,PrimIs,[a]) -> 
            match term s a |> data_to_ty s with
            | YPrim -> DLit (LitBool true)
            | _ -> DLit (LitBool false)
        | EOp(_,SymbolIs,[a]) -> 
            match term s a with
            | DSymbol -> DLit (LitBool true)
            | _ -> DLit (LitBool false)
        | EOp(_,FailWith,[EType(_,typ);a]) ->
            match ty s typ, term s a with
            | typ, (DV(L(_,YPrim StringT)) | DLit(LitString)) & a -> push_op_no_rewrite s FailWith a typ
            | _,a -> raise_type_error s "Expected a string as input to failwith.\nGot: %s" (show_data a)
        | EOp(_,FailWith,_) -> raise_type_error s "Malformed FailWith"
        | EOp(_,ErrorType,[a]) -> term s a |> show_data |> raise_type_error s
        | EOp(_,PrintStatic,[a]) -> printfn "%s" (term s a |> show_data); DB
        | EOp(_,op,a) -> raise_type_error s <| sprintf "Compiler error: %A with %i args not implemented" op (List.length a)

    let s : LangEnv = {
        trace = []
        seq = null
        cse = []
        i = ref 0
        env_global_type = null
        env_global_term = null
        env_stack_type = null
        env_stack_term = null
        }
    let ty_to_data x = ty_to_data {s with i = ref 0} x

    term_scope s x, {join_point_method=join_point_method; join_point_closure=join_point_closure; ty_to_data=ty_to_data}