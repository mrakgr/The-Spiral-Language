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
    let dict = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray(64)
    let rec f x =
        let memoize f = memoize dict f x
        let memoize_rec e ret f = memoize_rec dict e ret f x
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