module Spiral.PartEval

open System
open Spiral.Prepass

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
type Macro = Text of string | Type of Ty
and Ty =
    | YUnit
    | YPair of Ty * Ty
    | YSymbol of string
    | YTypeFunction of body : T * ty : Ty [] * ty_stack_size : StackSize
    | YRecord of Map<string, Ty>
    | YPrim of Config.PrimitiveType
    | YArray of Ty
    | YFunction of Ty * Ty
    | YMacro of Macro
    | YNominal of int
    | YApply of Ty * Ty
    | YLayout of Ty * BlockParsing.Layout
and Data =
    | DUnit
    | DPair of Data * Data
    | DSymbol of string
    | DFunction of body : E * annot : T option * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
    | DForall of body : E * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
    | DRecord of Map<string, Data>
    | DLit of Tokenize.Literal
    | DV of TyV
and TyV = L<Tag,Ty>
