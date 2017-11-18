module Spiral.Types

// Global open
open System
open System.Collections.Generic
open HashConsing

// Language types
type LayoutType =
    | LayoutStack
    | LayoutPackedStack
    | LayoutHeap
    | LayoutHeapMutable

type Node<'a>(expr:'a, symbol:int) = 
    member x.Expression = expr
    member x.Symbol = symbol
    override x.ToString() = sprintf "<tag %i>" symbol
    override x.GetHashCode() = symbol
    override x.Equals(y) = 
        match y with 
        | :? Node<'a> as y -> symbol = y.Symbol
        | _ -> failwith "Invalid equality for Node."

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? Node<'a> as y -> compare symbol y.Symbol
            | _ -> failwith "Invalid comparison for Node."

let inline n (x: Node<_>) = x.Expression
let (|N|) x = n x
let (|S|) (x: Node<_>) = x.Symbol

type ModuleName = string
type ModuleCode = string
type ModuleDescription = string
type Module = Module of Node<ModuleName * Module list * ModuleDescription * ModuleCode>

type PosKey = Module * int64 * int64

let h0() = HashSet(HashIdentity.Structural)
let d0() = Dictionary(HashIdentity.Structural)

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.[k] <- v; v

let nodify (dict: Dictionary<_,_>) = memoize dict (fun x -> Node(x,dict.Count))
let nodify_module = nodify <| d0()
let module_ x = nodify_module x |> Module

type Pos<'a when 'a: equality and 'a: comparison>(pos:PosKey, expr:'a) = 
    member x.Expression = expr
    member x.Pos = pos
    override x.ToString() = sprintf "%A" expr
    override x.GetHashCode() = hash expr
    override x.Equals(y) = 
        match y with 
        | :? Pos<'a> as y -> expr = y.Expression
        | x -> failwithf "Invalid equality for Pos. Got: %A" x

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? Pos<'a> as y -> compare expr y.Expression
            | x -> failwithf "Invalid comparison for Pos. Got: %A" x

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
    // Macros
    | MacroCuda
    | MacroFs

    // Closure
    | TermFunctionTypeCreate
    | ClosureIs
    | ClosureDomain
    | ClosureRange

    // Cast
    | UnsafeConvert
    | UnsafeUpcastTo
    | UnsafeDowncastTo
    | UnsafeCoerceToArrayCudaGlobal

    // Pattern matching errors
    | ErrorPatMiss
    | ErrorPatClause

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice

    // DotNetOps
    | DotNetAssemblyLoad
    | DotNetAssemblyLoadFile
    | DotNetTypeConstruct
    | DotNetTypeCallMethod
    | DotNetTypeGetField

    // Module
    | ModuleCreate
    | ModuleWith
    | ModuleWithout
    | ModuleIs
    | ModuleValues
    | CaseableIs
    | CaseableBoxedIs

    // Case
    | Case

    // TriOps
    | If
    | IfStatic

    // BinOps
    | Add
    | Sub
    | Mult 
    | Div 
    | Mod 
    | LTE 
    | LT 
    | EQ 
    | NEQ 
    | GT 
    | GTE 
    | And 
    | Or
    | BitwiseAnd
    | BitwiseOr
    | BitwiseXor

    | Fix
    | Apply
    | TermCast
    | JoinPointEntryMethod
    | JoinPointEntryType
    | JoinPointEntryCuda
    | StructCreate
    | ListIndex
    | ListSliceFrom
    | ListCons
    | ListLength
    | ListIs
    | TypeAnnot
    | MapGetField
    | LayoutToNone
    | LayoutToStack
    | LayoutToPackedStack
    | LayoutToHeap
    | LayoutToHeapMutable
    | TypeGet
    | TypeUnion
    | TypeSplit
    | TypeBox
    | EqType
    | ModuleHasMember
    | ModuleMap
    | ModuleFold
    | SizeOf

    // Array
    | ArrayCreate
    | ReferenceCreate
    | ArrayIndex
    | MutableSet
    | ArrayLength
   
    | ShiftLeft
    | ShiftRight

    // Static unary operations
    | PrintStatic
    | PrintEnv
    | PrintExpr
    | ErrorNonUnit
    | ErrorType
    | ModuleOpen
    | TypeLitCreate
    | TypeLitCast
    | TypeLitIs
    | Dynamize
    | LitIs
    | BoxIs

    // UnOps
    | Neg
    | Log
    | Exp
    | Tanh
    | FailWith

type ArrayType =
    | ArtDotNetHeap
    | ArtDotNetReference
    | ArtCudaGlobal of Ty
    | ArtCudaShared
    | ArtCudaLocal

and SSExpr = // SS are the Spiral .NET interop types. SS is short for 'S'piral 'S'ystem Type.
    | SSType of Ty
    | SSVar of string
    | SSArray of SSExpr []
    | SSLam of string [] * SSExpr
    | SSCompileTypeDefinition of Type
    | SSCompileMethod of Reflection.MethodInfo
    | SSCompileField of Reflection.FieldInfo
    | SSCompileConstructor of Reflection.ConstructorInfo

and SSTypedExpr =
    | SSTyType of Ty
    | SSTyArray of SSTypedExpr []
    | SSTyLam of SSEnvTerm * string [] * SSExpr
    | SSTyClass of SSTypedExprClass

and SSMethodMap = Map<string, SSTypedExpr[]>
and SSFieldMap = Map<string, SSTypedExpr>
and SSConstructors = SSTypedExpr[]
and SSEvents = Map<string, SSTypedExpr>

and SSTypedExprClass = {
    full_name : string
    assembly_name : string
    generic_type_args : Ty []
    methods : SSMethodMap
    static_methods : SSMethodMap
    fields : SSFieldMap
    static_fields : SSFieldMap
    constructors : SSConstructors
    }
    
and SSEnvTerm = Map<string,Ty>

and FunctionCore = string * Expr

and MapType =
    | MapTypeFunction of FunctionCore // Type level function. Can also be though of as a procedural macro.
    | MapTypeRecFunction of FunctionCore * string
    | MapTypeModule

and Pattern =
    | E
    | PatVar of string
    | PatTuple of Pattern list
    | PatCons of Pattern list
    | PatTypeEq of Pattern * Expr
    | PatActive of string * Pattern
    | PatPartActive of string * Pattern
    | PatExtActive of string * Pattern
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatClauses of (Pattern * Expr) list
    | PatTypeLit of Value
    | PatTypeLitBind of string
    | PatLit of Value
    | PatWhen of Pattern * Expr
    | PatModule of string option * PatternModule
    | PatPos of Pos<Pattern>
    | PatTypeClosure of Pattern * Pattern

and PatternModule =
    | PatMAnd of PatternModule list
    | PatMOr of PatternModule list
    | PatMXor of PatternModule list
    | PatMNot of PatternModule
    | PatMInnerModule of string * PatternModule
    | PatMName of string
    | PatMRebind of string * Pattern
    | PatMPattern of Pattern

and Expr = 
    | V of Node<string>
    | Lit of Node<Value>
    | Pattern of Node<Pattern>
    | Function of Node<FunctionCore>
    | FunctionFilt of Node<Set<string> * Node<FunctionCore>>
    | VV of Node<Expr list>
    | Op of Node<Op * Expr list>
    | ExprPos of Pos<Expr>

and Ty =
    | PrimT of PrimitiveType
    | ListT of Ty list
    | LitT of Value
    | MapT of EnvTy * MapType
    | LayoutT of LayoutType * EnvTerm * MapType
    | TermFunctionT of Ty * Ty
    | UnionT of Set<Ty>
    | RecT of JoinPointKey
    | ArrayT of ArrayType * Ty
    | DotNetTypeT of Node<SSTypedExpr>

and TypedExpr =
    // Data structures
    | TyT of Ty
    | TyV of TyTag
    | TyList of TypedExpr list
    | TyMap of EnvTerm * MapType
    | TyBox of TypedExpr * Ty
    | TyLit of Value

    // Operations
    | TyLet of TyTag * TypedExpr * TypedExpr * Ty * Trace
    | TyState of TypedExpr * TypedExpr * Ty * Trace
    | TyOp of Op * TypedExpr list * Ty
    | TyJoinPoint of JoinPointKey * JoinPointType * Arguments * Ty

and JoinPointType =
    | JoinPointClosure
    | JoinPointMethod
    | JoinPointType
    | JoinPointCuda

and JoinPointState<'a,'b> =
    | JoinPointInEvaluation of 'a
    | JoinPointDone of 'b

and Tag = int
and TyTag = Tag * Ty
and EnvTy = Map<string, Ty>
and EnvTerm = 
| EnvConsed of ConsedNode<Map<string, TypedExpr>>
| Env of Map<string, TypedExpr>
| EnvUnfiltered of Map<string, TypedExpr> * Set<string>

and JoinPointKey = Node<Expr * EnvTerm>

and Arguments = TyTag list
and Renamer = Dictionary<Tag,Tag>

// This key is for functions without arguments. It is intended that the arguments be passed in through the Environment.
and JoinPointDict<'a,'b> = Dictionary<JoinPointKey, JoinPointState<'a,'b>>
// For Common Subexpression Elimination. I need it not for its own sake, but to enable other PE based optimizations.
and CSEDict = Map<TypedExpr,TypedExpr> ref

and Trace = PosKey list

and TraceNode<'a when 'a:equality and 'a:comparison>(expr:'a, trace:Trace) = 
    member x.Expression = expr
    member x.Trace = trace
    override x.ToString() = sprintf "%A" expr
    override x.GetHashCode() = hash expr
    override x.Equals(y) = 
        match y with 
        | :? TraceNode<'a> as y -> expr = y.Expression
        | _ -> failwith "Invalid equality for TraceNode."

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? TraceNode<'a> as y -> compare expr y.Expression
            | _ -> failwith "Invalid comparison for TraceNode."

type TypeOrMethod =
    | TomType of Ty
    | TomJP of JoinPointType * JoinPointKey

let inline t (x: TraceNode<_>) = x.Expression
let (|T|) x = t x

type RecursiveBehavior =
    | AnnotationDive
    | AnnotationReturn

type LangEnv = {
    rbeh: RecursiveBehavior
    ltag : int ref
    seq : (TypedExpr -> TypedExpr) ref
    env : EnvTerm
    cse_env : CSEDict
    trace : Trace
    }

exception TypeError of Trace * string

type Result<'a,'b> = Succ of 'a | Fail of 'b

// Parser types
type Userstate = {
    ops : Dictionary<string, int * FParsec.Associativity>
    semicolon_line : int64
    }

type ParserExpr =
| ParserStatement of PosKey * (Expr -> Expr)
| ParserExpr of PosKey * Expr

// Codegen types
type CodegenEnv = {
    branch_return: string -> string
    trace: Trace
    }

type Buf = ResizeArray<ProgramNode>
and ProgramNode =
    | Statement of sep: string * code: string
    | Indent
    | Dedent

type EnvRenamer = {
    memo : Dictionary<TypedExpr,TypedExpr>
    renamer : Dictionary<Tag,Tag>
    ref_call_args : TyTag list ref
    ref_method_pars : TyTag list ref
    }

type RenamerResult = {
    renamer' : Dictionary<Tag,Tag>
    call_args : TyTag list
    method_pars : TyTag list
    }

let cuda_kernels_name = "cuda_kernels"

type AssemblyLoadType =
    | LoadType of Type
    | LoadMap of Map<string,AssemblyLoadType>

let string_to_op =
    let cases = Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    let dict = d0()
    cases |> Array.iter (fun x ->
        dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op
        )
    dict.TryGetValue

let c = function
| Env env -> env
| EnvUnfiltered (env,used_vars) -> Map.filter (fun k _ -> used_vars.Contains k) env
| EnvConsed env -> env.node

let (|C|) x = c x
let (|CN|) (x: ConsedNode<_>) = x.node