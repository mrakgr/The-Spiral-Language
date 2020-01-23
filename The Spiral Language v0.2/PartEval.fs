module Spiral.PartEval

open Spiral.Prepass
open Spiral.Utils
open System.Collections.Generic
open System

type Env<'a,'b> = {type' : StackSize * 'a []; value : StackSize * 'b []}

type LayoutType =
    | LayoutStack
    | LayoutHeap
    | LayoutHeapMutable

type Tag = int
type [<CustomComparison;CustomEquality>] T<'a,'b when 'a: equality and 'a: comparison> = 
    | T of 'a * 'b

    override a.Equals(b) =
        match b with
        | :? T<'a,'b> as b -> match a,b with T(a,_), T(b,_) -> a = b
        | _ -> false
    override a.GetHashCode() = match a with T(a,_) -> hash a
    interface IComparable with
        member a.CompareTo(b) = 
            match b with
            | :? T<'a,'b> as b -> match a,b with T(a,_), T(b,_) -> compare a b
            | _ -> raise <| ArgumentException "Invalid comparison for T."

type Ty =
    | PairT of Ty * Ty
    | KeywordT of KeywordTag * Ty []
    | FunctionT of Expr * StackSize * Ty [] * StackSize * Ty []
    | RecordT of Map<KeywordTag, Ty>
    | PrimT of Parsing.PrimitiveType
    
    | LayoutT of LayoutType * RData
    | ArrayT of Ty
    | RuntimeFunctionT of Ty * Ty
    | MacroT of RData

and Data =
    | TyPair of Data * Data
    | TyKeyword of KeywordTag * Data []
    | TyFunction of Expr * StackSize * Ty [] * StackSize * Data []
    | TyRecord of Map<KeywordTag, Data>
    | TyLit of Tokenize.Value

    | TyV of TyV
    | TyRef of int // For use in join points, layout types and macros
and TyV = T<Tag,Ty>

and RData = R of Data // has TyRef

type Trace = ParserCombinators.PosKey list
type JoinPointKey = Expr * Ty []
type JoinPointType =
    | JoinPointClosure
    | JoinPointMethod
type JoinPoint = JoinPointKey * JoinPointType * TyV []

type TypedBind = // Data being `TyList []` indicates a statement.
    | TyLet of Data * Trace * TypedOp
    | TyLocalReturnOp of Trace * TypedOp
    | TyLocalReturnData of Data * Trace

and TypedOp = 
    | TyOp of Parsing.Op * Data
    | TyIf of cond: Data * tr: TypedBind [] * fl: TypedBind []
    | TyWhile of cond: JoinPoint * TypedBind []
    | TyCase of Data * (Data * TypedBind []) []
    | TyLayoutToNone of Data
    | TyJoinPoint of JoinPoint
    | TySetMutableRecord of Data * (Tag * Ty) [] * TyV []

/// Unlike v0.1 and previously, the functions can now have cycles so that needs to be taken care of during memoization.
let typed_data_to_renamed' call_data =
    let m = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray(64)
    let rec f x =
        let memoize f = memoize m f x
        let memoize_rec e ret f = memoize_rec m e ret f x
        match x with
        | TyPair(a,b) -> memoize (fun _ -> TyPair(f a, f b))
        | TyKeyword(a,b) -> memoize (fun _ -> TyKeyword(a, Array.map f b))
        | TyFunction(a,b,c,d,e) -> memoize_rec e (fun e' -> TyFunction(a,b,c,d,e')) f
        | TyRecord l -> memoize (fun _ -> TyRecord(Map.map (fun _ -> f) l))
        | TyV(T(_,ty) as t) -> memoize (fun _ -> call_args.Add t; TyV(T(call_args.Count-1, ty)))
        | TyLit x -> memoize (fun _ -> TyLit x)
        | TyRef _ -> failwith "Compiler error"
    let x = f call_data
    call_args.ToArray(),x

let ty_to_data i x =
    let m = Dictionary(HashIdentity.Reference)
    let rec f x = 
        match x with
        | PairT(a,b) -> TyPair(f a, f b) 
        | KeywordT(a,b) -> TyKeyword(a,Array.map f b)
        | FunctionT(a,b,c,d,e) -> 
            match m.TryGetValue x with
            | true, v -> v
            | _ ->
                let e' = Array.zeroCreate e.Length
                let r = TyFunction(a,b,c,d,e')
                m.Add(x,r)
                Array.iteri (fun i x -> e'.[i] <- f x) e
                m.Remove(x) |> ignore // Non-nested mapping should not share vars
                r
        | RecordT l -> TyRecord(Map.map (fun k -> f) l)
        | PrimT _ | LayoutT _ | ArrayT _ | RuntimeFunctionT _ | MacroT _ -> let r = TyV(T(!i,x)) in i := !i+1; r
    f x

open Spiral.Tokenize
open Spiral.Parsing
let value_to_ty = function
    | LitUInt8 _ -> PrimT UInt8T
    | LitUInt16 _ -> PrimT UInt16T
    | LitUInt32 _ -> PrimT UInt32T
    | LitUInt64 _ -> PrimT UInt64T
    | LitInt8 _ -> PrimT Int8T
    | LitInt16 _ -> PrimT Int16T
    | LitInt32 _ -> PrimT Int32T
    | LitInt64 _ -> PrimT Int64T
    | LitFloat32 _ -> PrimT Float32T
    | LitFloat64 _ -> PrimT Float64T   
    | LitBool _ -> PrimT BoolT
    | LitString _ -> PrimT StringT
    | LitChar _ -> PrimT CharT

let data_to_ty x =
    let m = Dictionary(HashIdentity.Reference)
    let rec f x =
        let memoize f = memoize m f x
        let memoize_rec e ret f = memoize_rec m e ret f x
        match x with
        | TyPair(a,b) -> memoize (fun _ -> PairT(f a, f b))
        | TyKeyword(a,b) -> memoize (fun _ -> KeywordT(a, Array.map f b))
        | TyFunction(a,b,c,d,e) -> memoize_rec e (fun e' -> FunctionT(a,b,c,d,e')) f
        | TyRecord l -> memoize (fun _ -> RecordT(Map.map (fun _ -> f) l))
        | TyV(T(_,ty) as t) -> ty
        | TyLit x -> value_to_ty x
        | TyRef _ -> failwith "Compiler error"
    f x