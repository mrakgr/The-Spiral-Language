module Spiral.Types

// Global open
open System
open System.Collections.Generic
open System.Runtime.CompilerServices

// Language types
type LayoutType =
    | LayoutStack
    | LayoutHeap
    | LayoutHeapMutable

type SpiralModule =
    {
    name: string
    prerequisites : SpiralModule list 
    description : string 
    code : string
    }

type PosKey = SpiralModule * int * int
type Trace = PosKey list

type Pos<'a> = Position of PosKey * 'a with
    member x.Expression = match x with Position (_, expr) -> expr
    member x.Pos = match x with Position (pos, _) -> pos
    override x.ToString() = match x with Position (_, expr) -> sprintf "%A" expr

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

type Value = 
    | LitUInt8 of uint8
    | LitUInt16 of uint16
    | LitUInt32 of uint32
    | LitUInt64 of uint64
    | LitInt8 of int8
    | LitInt16 of int16
    | LitInt32 of int32
    | LitInt64 of int64
    | LitFloat32 of float32
    | LitFloat64 of float
    | LitBool of bool
    | LitString of string
    | LitChar of char

type Op =
    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice
    | StringFormat
    | StringConcat

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

    // Join points
    | JoinPointEntryMethod
    | JoinPointAnnotEntryMethod
    
    // Application related
    | Apply
    | TermCast // Term cast also places the closure join point directly.
    | TypeAnnot

    // Array
    | ArrayCreateDotNet
    | ReferenceCreate
    | ArrayLength

    // Getters
    | GetArray
    | GetReference

    // Setters
    | SetArray
    | SetReference
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | Dynamize
    | IsLit
    | IsPrim

    // UnOps
    | Neg
    | FailWith

    // Auxiliary math ops
    | Tanh
    | Log
    | Exp
    | Sqrt
    | IsNan

    // Infinity
    | InfinityF64
    | InfinityF32

type ArrayType =
    | ArtDotNetHeap
    | ArtDotNetReference

type VarString = string * PosKey
type KeywordString = string

type Pattern =
    | PatE
    | PatVar of VarString
    | PatPair of Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatLit of Value
    | PatWhen of Pattern * RawExpr
    | PatPos of Pos<Pattern>

and RawExpr =
    | RawV of VarString 
    | RawLit of Value
    | RawFunction of RawExpr * VarString
    //| RawRecBlock of (RawExpr * VarString) []
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawPairTest of vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawOp of Op * RawExpr []
    | RawExprPos of Pos<RawExpr>
    | RawPattern of (VarString * (Pattern * RawExpr) []) // These parenthesis are here so the pattern compilation can be memoized via reference identity.

type VarTag = int
type FreeVars = VarTag []
type StackSize = int

type [<ReferenceEquality; NoComparison>] Expr =
    | V of VarTag
    | Lit of Value
    | Inline of Expr * FreeVars * StackSize
    | Function of Expr * FreeVars * StackSize
    | Let of bind: Expr * on_succ: Expr
    //| RecBlock of binds: Expr [] * on_succ: Expr // TODO: Figure out the exact form of this.
    | PairTest of StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    | ExprPos of Pos<Expr>
    | Op of Op * Expr []

type EnvTy = Ty []
and EnvTerm = TypedData []

and Ty =
    | PairT of Ty * Ty
    | FunctionT of Expr * StackSize * EnvTy * EnvTy
    | PrimT of PrimitiveType
    | TermCastedFunctionT of Ty * Ty
    | ArrayT of ArrayType * Ty

and TyTag = int * Ty

and TypedData =
    | TyPair of TypedData * TypedData
    | TyFunction of Expr * StackSize * EnvTy * EnvTerm
    | TyV of TyTag
    | TyLit of Value

and JoinPointType =
    | JoinPointClosure
    | JoinPointMethod

type JoinPointKey = Expr * (int * Ty)
type JoinPoint = JoinPointKey * JoinPointType * TyTag []

type TypedBind =
    | TyLet of TypedData [] * Trace * TypedOp
    | TyLocalReturnOp of Trace * TypedOp
    | TyLocalReturnData of TypedData * Trace

and TypedOp = 
    | TyOp of Op * TypedData
    | TyIf of cond: TypedData * tr: TypedBind [] * fl: TypedBind []
    | TyJoinPoint of JoinPoint

type JoinPointState<'a,'b> =
    | JoinPointInEvaluation of 'a
    | JoinPointDone of 'b

// This key is for functions without arguments. It is intended that the arguments be passed in through the Environment.
and JoinPointDict<'a,'b> = Dictionary<JoinPointKey, JoinPointState<'a,'b>>

type LangEnv = {
    trace : Trace
    // Residual program
    seq : ResizeArray<TypedBind>
    // Envs
    env_value : EnvTerm
    env_value_ptr : int
    env_type : EnvTy
    env_type_ptr : int
    // Cse
    cse : Dictionary<Op * TypedData, TypedData>
    }

// Codegen types
let inline memoize' (memo_dict: ConditionalWeakTable<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v
let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

type SpiralCompilerSettings = {
    trace_length : int // The length of the error messages.
    filter_list : string list // List of modules to be ignored in the trace.
    }

/// Here are the paths on my machine.
let cfg_default = {
    trace_length = 20
    filter_list = 
        [
        ]
    }

type LC = {
    line : int
    column : int
    }

type TokenPosition = {
    start: LC 
    end_: LC 
    }

type TokenOperator = {
    name: string
    associativity: FParsec.Associativity
    precedence: int
    }

[<Struct>]
type Result<'a,'b> =
    | Ok of result: 'a
    | Fail of error: 'b

exception PrepassError of string
exception PrepassErrorWithPos of PosKey * string
exception TypeError of Trace * string
exception TypeRaised of Ty
exception CodegenError of string
exception CodegenErrorWithPos of Trace * string
exception CompileError of string
exception CompileErrorWithPos of Trace * string


