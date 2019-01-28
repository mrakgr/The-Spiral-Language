module Spiral.Types

// Global open
open System
open System.Collections.Generic
open HashConsing
open System.Text

// Language types
type LayoutType =
    | LayoutStack
    | LayoutPackedStack
    | LayoutHeap
    | LayoutHeapMutable

type HashNode<'a when 'a : equality and 'a : comparison>(expr:'a) =
    let h = ref None
    member x.Expression = expr
    override x.ToString() = expr.ToString()
    override x.GetHashCode() = 
        match !h with
        | Some h -> h
        | None ->
            let x = hash expr
            h := Some x
            x
    override x.Equals(y) =
        match y with 
        | :? HashNode<'a> as y -> expr = y.Expression
        | _ -> false

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? HashNode<'a> as y -> compare expr y.Expression
            | _ -> failwith "Invalid comparison for Node."

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

type ModuleName = string
type ModuleCode = string
type ModuleDescription = string
type Module = Module of Node<ModuleName * Module list * ModuleDescription * ModuleCode>

type PosKey = Module * int64 * int64

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
    // Type operation
    | ToVar
    
    // Extern type constructors
    | DotNetTypeCreate
    | CudaTypeCreate
    
    // Macros
    | MacroCuda
    | MacroFs

    // Term function
    | TermFunctionTypeCreate
    | TermFunctionDomainRangeCPS

    // Unsafe casts
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
    | StringFormat
    | StringConcat

    // List
    | ListCons
    | ListTakeNCPS
    | ListTakeNTailCPS

    // Keyword args
    | KeywordArgCreate
    | KeywordArgCPS

    // Module
    | ModuleCreate
    | ModuleWith
    | ModuleWithout
    | ModuleAdd
    | ModuleRemove
    | ModuleIsCPS
    | ModuleValues
    | ModuleHasMember
    | ModuleMap
    | ModuleFilter
    | ModuleFoldL
    | ModuleFoldR
    | ModuleLength
    | MapGetField // Codegen only
    | ModuleMemberCPS
    | ModuleInjectCPS

    // Braching
    | Case
    | CaseFoldLMap
    | IfStatic
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
    | BitwiseAnd
    | BitwiseOr
    | BitwiseXor
    | ShiftLeft
    | ShiftRight

    // Join points
    | JoinPointEntryMethod
    | JoinPointEntryType
    | JoinPointEntryCuda
    
    // Application related
    | Apply
    | TermCast // Term cast also places the closure join point directly.
    | TypeAnnot

    // Layout
    | LayoutToNone
    | LayoutToStack
    | LayoutToPackedStack
    | LayoutToHeap
    | LayoutToHeapMutable

    // Type 
    | TypeCatch
    | TypeRaise
    | TypeGet
    | TypeUnion
    | TypeSplit
    | TypeBox
    | TypeUnbox
    | EqType
    | SizeOf

    // Array
    | ArrayCreate
    | ReferenceCreate
    | ArrayIndex
    | MutableSet
    | ArrayLength
    | ArrayIs
   
    // Static unary operations
    | PrintStatic
    | PrintEnv
    | ErrorNonUnit
    | ErrorType
    | Dynamize
    | LitIs
    | ValIs

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
    | InfinityF64
    | InfinityF32

type ArrayType =
    | ArtDotNetHeap
    | ArtDotNetReference
    | ArtCudaGlobal of ConsedTy
    | ArtCudaShared
    | ArtCudaLocal

and Pattern =
    | PatE
    | PatVar of string
    | PatTuple of Pattern list
    | PatKeyword of string * Pattern []
    | PatCons of Pattern list
    | PatTypeEq of Pattern * Expr
    | PatActive of Expr * Pattern
    | PatPartActive of Expr * Pattern
    | PatUnbox of Pattern
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatNot of Pattern
    | PatClauses of (Pattern * Expr) list
    | PatLit of Value
    | PatWhen of Pattern * Expr
    | PatModuleIs of Pattern
    | PatModuleMember of string
    | PatModuleRebind of string * Pattern
    | PatModuleInject of string * Pattern
    | PatPos of Pos<Pattern>
    | PatTypeTermFunction of Pattern * Pattern

and [<ReferenceEquality>] Expr = // TODO: Replace `ReferenceEquality` with tagging after the prepass. No need for HashConsing for this.
    | V of string
    | Lit of Value
    | Open of Expr * Expr
    | Pattern of Pattern
    | Function of Expr * string
    | RecFunction of Expr * string * rec_name: string
    | VV of Expr list
    | Op of Op * Expr list
    | ExprPos of Pos<Expr>

and ConsedTy =
    | CListT of ConsedNode<ConsedTy list>
    | CTyKeyword of ConsedNode<KeywordArgTag * ConsedTy []>
    | CFunctionT of ConsedNode<Expr * EnvTy>
    | CRecFunctionT of ConsedNode<Expr * EnvTy>
    | CObjectT of ConsedNode<ObjectTag * EnvTy>
    | CMapT of ConsedNode<MapTy>

    | CLayoutT of ConsedNode<LayoutType * ConsedTypedData>
    | CUnionT of ConsedNode<Set<ConsedTy>>

    | CPrimT of PrimitiveType
    | CTermCastedFunctionT of ConsedTy * ConsedTy
    | CRecUnionT of JoinPointKey
    | CArrayT of ArrayType * ConsedTy
    | CDotNetTypeT of ConsedTypedData // macro
    | CCudaTypeT of ConsedTypedData // macro

and ConsedTypedData = 
    | CTyList of ConsedNode<ConsedTypedData list>
    | CTyKeyword of ConsedNode<KeywordArgTag * TypedData []>
    | CTyFunction of ConsedNode<Expr * EnvTerm>
    | CTyRecFunction of ConsedNode<Expr * EnvTerm>
    | CTyObject of ConsedNode<ObjectTag * EnvTerm>
    | CTyMap of ConsedNode<MapTerm>

    | CTyT of ConsedTy
    | CTyV of TyTag
    | CTyBox of ConsedTypedData * ConsedTy
    | CTyLit of Value

and TypedData =
    | TyList of TypedData list
    | TyKeyword of KeywordArgTag * TypedData []
    | TyFunction of Expr * EnvTerm
    | TyRecFunction of Expr * EnvTerm
    | TyObject of ObjectTag * EnvTerm
    | TyMap of MapTerm

    | TyT of ConsedTy
    | TyV of TyTag
    | TyBox of TypedData * ConsedTy
    | TyLit of Value

and TypedExpr = // TypedData being `TyList []` indicates a statement.
    | TyOp of TypedData * ConsedTy * Trace * Op * TypedData
    | TyIf of TypedData * ConsedTy * Trace * tr: TypedExpr [] * fl: TypedExpr []
    | TyCase of TypedData * ConsedTy * Trace * TyTag * (TypedData * TypedExpr []) []
    | TyJoinPoint of TypedData * ConsedTy * Trace * JoinPointKey * JoinPointType * CallArguments
    | TyLocalReturn of TypedData * ConsedTy * Trace

and JoinPointType =
    | JoinPointClosure
    | JoinPointMethod
    | JoinPointType
    | JoinPointCuda

and JoinPointState<'a,'b> =
    | JoinPointInEvaluation of 'a
    | JoinPointDone of 'b

and Tag = int
and TyTag = Tag * ConsedTy
and EnvTy = ConsedTy []
and EnvTerm = TypedData []
and KeywordArgTag = int
and MapTerm = Map<KeywordArgTag,TypedData>
and MapTy = Map<KeywordArgTag, ConsedTy>
and ObjectTag = int

and JoinPointKey = Node<Expr * EnvTerm>

and CallArguments = TyTag []
and Renamer = Dictionary<Tag,Tag>

// This key is for functions without arguments. It is intended that the arguments be passed in through the Environment.
and JoinPointDict<'a,'b> = Dictionary<JoinPointKey, JoinPointState<'a,'b>>

and Trace = PosKey list

type TypeOrMethod =
    | TomType of ConsedTy
    | TomJP of JoinPointType * JoinPointKey

type RecursiveBehavior =
    | AnnotationDive
    | AnnotationReturn

type LangEnvOuter = {
    rbeh : RecursiveBehavior
    seq : ResizeArray<TypedExpr>
    }

type LangEnvInner = {
    env_main : EnvTerm
    env_temp : EnvTerm
    trace : Trace
    }

type Result<'a,'b> = Succ of 'a | Fail of 'b

// Parser types
type Userstate = {
    ops : Dictionary<string, int * FParsec.Associativity>
    semicolon_line : int64
    }

type ParserExpr =
| ParserStatement of (Expr -> Expr)
| ParserExpr of Expr

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
    memo : Dictionary<TypedData,TypedData>
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

let h0() = HashSet(HashIdentity.Structural)
let d0() = Dictionary(HashIdentity.Structural)

let string_to_op =
    let cases = Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    let dict = d0()
    cases |> Array.iter (fun x ->
        dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op
        )
    dict.TryGetValue

type CompilerSettings = {
    cub_path : string
    cuda_path : string
    cuda_nvcc_options : string
    vs_path : string
    vs_path_vcvars : string
    vcvars_args : string
    vs_path_cl : string
    vs_path_include : string
    cuda_includes : string list
    trace_length : int // The length of the error messages.
    cuda_assert_enabled : bool // Enables the bounds checking in Cuda kernels. Off by default.
    filter_list : string list // List of modules to be ignored in the trace.
    }

/// Here are the paths on my machine.
let cfg_default = {
    cub_path = "C:/cub-1.7.4"
    cuda_path = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    cuda_nvcc_options = "-gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\""
    vs_path = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    vs_path_vcvars = "VC/Auxiliary/Build/vcvarsall.bat"
    vcvars_args = " x64 -vcvars_ver=14.11"
    vs_path_cl = "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64"
    vs_path_include = "VC/Tools/MSVC/14.11.25503/include"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    filter_list = 
        [
        //"Core"; "Option"; "Lazy"; "Tuple"; "Liple"; "Loops"; "Extern"; "Array"; "List"; "Parsing"; "Console"
        //"Queue"; "Struct"; "Tensor"; "View"; "ViewR"; "Object"; "Cuda"; "Random"; "Math"
        ]
    }

let cfg_testing = {cfg_default with cuda_includes=[]; trace_length=20}

type Timings = {
    parsing_time: TimeSpan    
    prepass_time: TimeSpan
    peval_time: TimeSpan
    codegen_time: TimeSpan
    }

exception TypeError of Trace * string
exception TypeRaised of ConsedTy