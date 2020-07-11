module Spiral.BlockParsing
open Spiral.ParserCombinators

type Env = {
    l : Tokenize.LineToken [] []
    row : int ref
    col : int ref
    semicolon_line : int
    symbol_line : int
    is_top_down : bool
    } with

    member t.Index with get() = t.row.contents, t.col.contents and set(row,col) = t.row := row; t.col := col

type Pos = {line : int; from : int; nearTo : int}
type SymbolString = string * Pos
type VarString = string * Pos

type Literal = Tokenize.Literal

type Op =
    // Type
    | TypeAnnot
    | TypeToVar
    | Box

    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice

    // Pair
    | PairCreate

    // Record
    | RecordMap
    | RecordFilter
    | RecordFoldL
    | RecordFoldR
    | RecordLength

    // Braching
    | If
    | While

    // BinOps
    | Add
    | Sub
    | Mult 
    | Div 
    | Mod 
    | Pow
    | LTE
    | LT
    | EQ
    | NEQ
    | GT
    | GTE 
    | BoolAnd
    | BoolOr
    | BitwiseAnd
    | BitwiseOr
    | BitwiseXor
    | ShiftLeft
    | ShiftRight

    // Application related
    | Apply

    // Array
    | ArrayCreate
    | ArrayLength
    | ArrayIndex
    | ArrayIndexSet
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | LitIs
    | PrimIs
    | SymbolIs
    | EqType

    // UnOps
    | Neg
    | FailWith

    // Auxiliary math ops
    | Tanh
    | Log
    | Exp
    | Sqrt
    | NanIs

    // Infinity
    | Infinity

type PrimitiveType =
    | UInt8T
    | UInt16T
    | UInt32T
    | UInt64T
    | Int8T
    | Int16T
    | Int32T
    | Int64T
    | Float32T
    | Float64T
    | BoolT
    | StringT
    | CharT

type RawRecordTestPattern =
    | RawRecordTestSymbol of symbol: SymbolString * name: VarString
    | RawRecordTestInjectVar of var: VarString * name: VarString
and RawRecordWithPattern =
    | RawRecordWithSymbol of SymbolString * RawExpr
    | RawRecordWithSymbolModify of SymbolString * RawExpr
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithInjectSymbolModify of SymbolString * RawExpr
    | RawRecordWithoutSymbol of SymbolString
    | RawRecordWithoutInjectVar of VarString
and PatRecordMembersItem =
    | PatRecordMembersSymbol of symbol: SymbolString * name: Pattern
    | PatRecordMembersInjectVar of var: VarString * name: Pattern

and Pattern =
    | PatB
    | PatE
    | PatVar of VarString
    | PatOperator of VarString // Isn't actually a pattern. Is just here to help the inl/let statement parser.
    | PatBox of Pattern
    | PatAnnot of Pattern * RawTExpr

    | PatPair of Pattern * Pattern
    | PatSymbol of string * Pattern list
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatUnion of SymbolString * Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatValue of Literal
    | PatDefaultValue of VarString
    | PatWhen of Pattern * RawExpr
    | PatNominal of VarString * Pattern

and RawExpr =
    | RawB
    | RawV of VarString
    | RawLit of Literal
    | RawDefaultLit of string
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawType of RawTExpr
    | RawInl of VarString * RawExpr
    | RawForall of VarString * RawExpr
    | RawSymbolCreate of SymbolString * RawExpr []
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Pos * Op * RawExpr []
    | RawJoinPoint of RawTExpr option * RawExpr
    | RawAnnot of RawTExpr * RawExpr
    | RawTypecase of RawTExpr * (RawTExpr * RawExpr) []
    | RawModuleOpen of VarString list * on_succ: RawExpr
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawRecBlock of (VarString * RawExpr) [] * on_succ: RawExpr
    | RawPairTest of var0: VarString * var1: VarString * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawSymbolTest of SymbolString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawAnnotTest of RawTExpr * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawValueTest of Literal * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawDefaultLitTest of string * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnionTest of name: SymbolString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawBTest of bind: VarString * on_succ: RawExpr * on_fail: RawExpr
and RawTExpr =
    | RawTVar of VarString
    | RawTPair of RawTExpr * RawTExpr
    | RawTFun of RawTExpr * RawTExpr

    | RawTRecord of Map<string,RawTExpr>
    | RawTSymbol of SymbolString * RawTExpr []
    | RawTApply of RawTExpr * RawTExpr
    | RawTForall of (VarString * RawKindExpr) * RawTExpr
    | RawTB
    | RawTPrim of PrimitiveType
    | RawTArray of RawTExpr
and RawKindExpr =
    | RawKindStar
    | RawKindFun of RawKindExpr * RawKindExpr

let index (t : Env) = t.Index
let index_set v (t : Env) = t.Index <- v

let top_let s = failwith "TODO" s
let top_inl s = failwith "TODO" s

let comments s = failwith "TODO" s

//let top_statement s =
//    let i = index s
//    let inline (+) a b = alt i a b
//    comments (top_let + top_inl) s