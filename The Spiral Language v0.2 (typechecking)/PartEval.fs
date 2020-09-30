module Spiral.PartEval

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

type StackSize = int
type Nominal = {|body : T; id : int; name : string|} ConsedNode
type Macro = Text of string | Type of Ty
and Ty =
    | YB
    | YPair of Ty * Ty
    | YSymbol of string
    | YTypeFunction of body : T * ty : Ty [] * ty_stack_size : StackSize
    | YRecord of Map<string, Ty>
    | YPrim of PrimitiveType
    | YArray of Ty
    | YFunction of Ty * Ty
    | YMacro of Macro list
    | YNominal of Nominal
    | YApply of Ty * Ty
    | YLayout of Ty * Layout
    | YUnion of Map<string,Ty>
and Data =
    | DB
    | DPair of Data * Data
    | DSymbol of string
    | DFunction of body : E * annot : T option * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
    | DForall of body : E * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
    | DRecord of Map<string, Data>
    | DLit of Literal
    | DNominal of Data * Ty
    | DV of TyV
and TyV = L<Tag,Ty>

type RData =
    | RUnit
    | RPair of ConsedNode<RData * RData>
    | RSymbol of string
    | RFunction of ConsedNode<E * RData [] * Ty []> // T option and stack sizes are entirely dependent on the body. And unlike in v0.09/v0.1 there are no reified join points.
    | RForall of ConsedNode<E * RData [] * Ty []>
    | RRecord of ConsedNode<Map<string, RData>>
    | RLit of Tokenize.Literal
    | RNominal of ConsedNode<Data * Ty>
    | RV of ConsedNode<Tag * Ty>

type Trace = Range list
type JoinPointKey = 
    | JPMethod of E * ConsedNode<RData [] * Ty []>
    | JPType of T * ConsedNode<Ty []>
    | JPClosure of E * ConsedNode<RData [] * Ty [] * Ty>

type JoinPointCall = JoinPointKey * TyV []

type TypedBind =
    | TyLet of Data * Trace * TypedOp
    | TyLocalReturnOp of Trace * TypedOp
    | TyLocalReturnData of Data * Trace

and TypedOp = 
    | TyOp of Op * Data []
    | TyIf of cond: Data * tr: TypedBind [] * fl: TypedBind []
    | TyWhile of cond: JoinPointCall * TypedBind []
    | TyJoinPoint of JoinPointCall

type LangEnv = {
    trace : Trace
    seq : ResizeArray<TypedBind>
    cse : Dictionary<Op * Data [], Data> list
    i : int ref
    env_global_type : Ty []
    env_global_value : Data []
    env_stack_type : Ty []
    env_stack_value : Data []
    }

type TopEnv = {
    prototypes : Dictionary<int, E> []
    nominals : Nominal []
    }

let lit_is = function
    | DLit _ -> true
    | _ -> false

let data_to_rdata'' (hc : HashConsTable) call_data =
    let hc x = hc.Add x
    let m = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray()
    let rec f x =
        Utils.memoize m (function
            | DPair(a,b) -> RPair(hc(f a, f b))
            | DSymbol a -> RSymbol a
            | DFunction(a,_,b,c,_,_) -> RFunction(hc(a,Array.map f b,c))
            | DForall(a,b,c,_,_) -> RFunction(hc(a,Array.map f b,c))
            | DRecord l -> RRecord(hc(Map.map (fun _ -> f) l))
            | DV(L(_,ty) as t) -> call_args.Add t; RV(hc (call_args.Count-1,ty))
            | DLit a -> RLit a
            | DB -> RUnit
            | DNominal(a,b) -> RNominal(hc(a,b))
            ) x
    let x = Array.map f call_data
    call_args.ToArray(),x

let data_to_rdata' (hc : HashConsTable) call_data = let a,b = data_to_rdata'' hc [|call_data|] in a,b.[0]
let data_to_rdata hc call_data = data_to_rdata' hc call_data |> snd // TODO: Specialize this.

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
            | DNominal(a,_) -> f a
            | DSymbol | DLit | DB -> ()
    f call_data
    free_vars.ToArray()

let data_term_vars call_data =
    let term_vars = ResizeArray(64)
    let rec f = function
        | DPair(a,b) -> f a; f b
        | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
        | DRecord l -> Map.iter (fun _ -> f) l
        | DLit | DV _ as x -> term_vars.Add x
        | DNominal(a,_) -> f a
        | DSymbol | DB -> ()
    f call_data
    term_vars.ToArray()

let ty_to_data i x =
    let rec f = function
        | YB -> DB
        | YPair(a,b) -> DPair(f a, f b) 
        | YSymbol a -> DSymbol a
        | YRecord l -> DRecord(Map.map (fun _ -> f) l)
        | YUnion | YNominal | YLayout | YApply | YPrim | YArray | YFunction | YMacro as x -> let r = DV(L(!i,x)) in incr i; r
        | YTypeFunction -> failwith "Compiler error: Cannot turn a type function to a runtime variable." // TODO: Should be a type error.
    f x

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

let push_typedop d op ret_ty =
    let ret = ty_to_data d.i ret_ty
    d.seq.Add(TyLet(ret,d.trace,op))
    ret

let push_op_no_rewrite' (d: LangEnv) op l ret_ty = push_typedop d (TyOp(op,l)) ret_ty
let push_op_no_rewrite d op a ret_ty = push_op_no_rewrite' d op [|a|] ret_ty
let push_binop_no_rewrite d op (a,b) ret_ty = push_op_no_rewrite' d op [|a;b|] ret_ty
let push_triop_no_rewrite d op (a,b,c) ret_ty = push_op_no_rewrite' d op [|a;b;c|] ret_ty

let push_op' (d: LangEnv) op l ret_ty =
    let key = op,l
    match cse_tryfind d key with
    | Some x -> x
    | None ->
        let x = ty_to_data d.i ret_ty
        d.seq.Add(TyLet(x,d.trace,TyOp(op,l)))
        cse_add d key x
        x

let push_op d op a ret_ty = push_op' d op [|a|] ret_ty
let push_binop d op (a,b) ret_ty = push_op' d op [|a;b|] ret_ty
let push_triop d op (a,b,c) ret_ty = push_op' d op [|a;b;c|] ret_ty

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
        | YUnion l -> sprintf "{%s}" (l |> Map.toList |> List.map (fun (k,v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "| ")
        | YPrim x -> show_primt x
        | YArray a -> p 30 (sprintf "array %s" (f 30 a))
        | YFunction(a,b) -> p 20 (sprintf "%s -> %s" (f 20 a) (f 19 b))
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
        | DNominal(a,b) -> p 0 (sprintf "%s : %s" (f 0 a) (show_ty b))
    f -1 x

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

let lit_zero d = function
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
    | _ -> raise_type_error d "Compiler error: Expected a numeric value."

let data_to_ty closure_convert env x =
    let m = Dictionary(HashIdentity.Reference)
    let rec f x =
        Utils.memoize m (function
            | DPair(a,b) -> YPair(f a, f b)
            | DSymbol a -> YSymbol a
            | DRecord l -> YRecord(Map.map (fun _ -> f) l)
            | DNominal(_,a) | DV(L(_,a)) -> a
            | DLit x -> lit_to_ty x
            | DB -> YB
            | DFunction(a,Some b,c,d,e,z) -> closure_convert env a b c d e z
            | DFunction(_,None,_,_,_,_) -> raise_type_error env "Cannot convert a function that is not annotated into a type."
            | DForall -> raise_type_error env "Cannot convert a forall into a type."
            ) x
    f x

let vt s i = if i < s.env_global_type.Length then s.env_global_type.[i] else s.env_stack_type.[i-s.env_global_type.Length]
let v s i = if i < s.env_global_value.Length then s.env_global_value.[i] else s.env_stack_value.[i-s.env_global_value.Length]
let add_trace (s : LangEnv) r = {s with trace = r :: s.trace}
let store_value_var (s : LangEnv) i v = s.env_stack_value.[i-s.env_global_value.Length] <- v
let store_type_var (s : LangEnv) i v = s.env_stack_type.[i-s.env_global_type.Length] <- v
let peval (env : TopEnv) x =
    let rec term (s : LangEnv) x = 
        let ev = term
        match x with
        | EB -> DB
        | EV a -> v s a
        | ELit(_,a) -> DLit a
        | ESymbol(_,a) -> DSymbol a
        | EFun'(_,free_vars,i,body,annot) -> 
            assert (free_vars.term.free_vars.Length = i)
            DFunction(body,annot,Array.map (v s) free_vars.term.free_vars,Array.map (vt s) free_vars.ty.free_vars,free_vars.term.stack_size,free_vars.ty.stack_size)
        | EForall'(_,free_vars,i,body) ->
            assert (free_vars.ty.free_vars.Length = i)
            DForall(body,Array.map (v s) free_vars.term.free_vars,Array.map (vt s) free_vars.ty.free_vars,free_vars.term.stack_size,free_vars.ty.stack_size)
        | ERecursive a -> ev s !a
        | ERecBlock -> failwith "Compiler error: Recursive blocks should be inlined and eliminated during the prepass."
        | ELet(r,i,a,b) -> store_value_var s i (ev s a); ev (add_trace s r) b
        | EJoinPoint'(r,free_vars,body,annot) ->
            

    and ty x = failwith ""
    term (failwith "TODO") x