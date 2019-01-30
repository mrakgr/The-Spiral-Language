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

type TaggedDictionary<'a,'b when 'a: equality>(capacity: int, tag: int) =
    inherit Dictionary<'a,'b>(capacity)

    member __.Tag = tag

    override __.Equals(b) =
        match b with
        | :? TaggedDictionary<'a,'b> as b -> tag = b.Tag
        | _ -> failwith "Invalid equality for TaggedDictionary."

    override __.GetHashCode() = tag

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? TaggedDictionary<'a,'b> as y -> compare tag y.Tag
            | _ -> failwith "Invalid comparison for TaggedDictionary."

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
        | _ -> failwith "Invalid equality for HashNode."

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? HashNode<'a> as y -> compare expr y.Expression
            | _ -> failwith "Invalid comparison for HashNode."

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
    | TermFunctionIs
    | TermFunctionDomain
    | TermFunctionRange

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
    | ListCreate

    // Module
    | ModuleMap
    | ModuleFilter
    | ModuleFoldL
    | ModuleFoldR
    | ModuleLength

    // Braching
    | Case
    | CaseFoldLMap
    | While
    | EqTest
    | TypeEqTest

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

and PatModuleMembersItem = PatModuleMembersKeyword of string * Pattern | PatModuleMembersInject of string * Pattern
and Pattern =
    | PatE
    | PatVar of string
    | PatTuple of Pattern []
    | PatKeyword of (string * Pattern) []
    | PatCons of Pattern []
    | PatTypeEq of Pattern * RawExpr
    | PatActive of RawExpr * Pattern
    | PatPartActive of RawExpr * Pattern
    | PatUnbox of Pattern
    | PatOr of Pattern []
    | PatAnd of Pattern []
    | PatNot of Pattern
    | PatClauses of (Pattern * RawExpr) []
    | PatLit of Value
    | PatWhen of Pattern * RawExpr
    | PatModuleMembers of PatModuleMembersItem []
    | PatPos of Pos<Pattern>
    | PatTypeTermFunction of Pattern * Pattern

and ModulePrepassExpr =
    | ModPreLet of string * RawExpr * ModulePrepassExpr
    | ModPreOpen of string * ModulePrepassExpr

and RawModuleTestPattern = RawModuleTestKeyword of name: string * keyword: string | RawModuleTestInjectVar of name: string * var: string
and RawModuleWithPattern = 
    | RawModuleWithKeyword of keyword: string * RawExpr 
    | RawModuleWithInjectVar of var: string * RawExpr
    | RawModuleWithoutKeyword of keyword: string 
    | RawModuleWithoutInjectVar of var: string

and RawExpr =
    | RawV of string
    | RawLit of Value
    | RawOpen of string [] * RawExpr
    | RawPattern of Pattern
    | RawFunction of RawExpr * string
    | RawRecFunction of RawExpr * string * rec_name: string
    | RawObjectCreate of (KeywordArgTag * RawExpr) []
    | RawKeywordCreate of string * RawExpr []
    | RawLet of string * bind: RawExpr * on_succ: RawExpr
    | RawIf of cond: RawExpr * on_succ: RawExpr * on_fail: RawExpr
    | RawListTakeAllTest of string [] * bind: RawExpr * on_succ: RawExpr * on_fail: RawExpr
    | RawListTakeNTest of string [] * bind: RawExpr * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of string * string [] * bind: RawExpr * on_succ: RawExpr * on_fail: RawExpr
    | RawModuleTest of RawModuleTestPattern [] * bind: RawExpr * on_succ: RawExpr * on_fail: RawExpr
    | RawModuleWith of RawExpr [] * RawModuleWithPattern []
    | RawOp of Op * RawExpr []
    | RawExprPos of Pos<RawExpr>

and ModuleTestPattern = ModuleKeyword of keyword: KeywordArgTag | ModuleInjectVar of var: VarTag
and ModuleWithPattern = 
    | ModuleWithKeyword of keyword: KeywordArgTag * Expr 
    | ModuleWithInjectVar of var: VarTag * Expr
    | ModuleWithoutKeyword of keyword: KeywordArgTag
    | ModuleWithoutInjectVar of var: VarTag

and Expr =
    | V of Tag * VarTag
    | Lit of Tag * Value
    | Open of Tag * VarTag * KeywordArgTag [] * Expr
    | Function of Tag * Expr * FreeVars * StackSize
    | RecFunction of Tag * Expr * FreeVars * StackSize
    | ObjectCreate of ObjectDict * FreeVars
    | KeywordCreate of KeywordArgTag * Expr []
    | Let of Tag * bind: Expr * on_succ: Expr
    | If of Tag * cond: Expr * on_succ: Expr * on_fail: Expr
    | ListTakeAllTest of Tag * StackSize * bind: Expr * on_succ: Expr * on_fail: Expr
    | ListTakeNTest of Tag * StackSize * bind: Expr * on_succ: Expr * on_fail: Expr
    | KeywordTest of Tag * KeywordArgTag * bind: Expr * on_succ: Expr * on_fail: Expr
    | ModuleTest of Tag * ModuleTestPattern [] * bind: Expr * on_succ: Expr * on_fail: Expr
    | ModuleWith of Tag * Expr [] * ModuleWithPattern []
    | Op of Tag * Op * Expr []
    | ExprPos of Tag * Pos<Expr>

and ConsedTy =
    | CListT of ConsedNode<ConsedTy list>
    | CTyKeyword of ConsedNode<KeywordArgTag * ConsedTy []>
    | CFunctionT of ConsedNode<Expr * EnvTy>
    | CRecFunctionT of ConsedNode<Expr * EnvTy>
    | CObjectT of ConsedNode<ObjectDict * EnvTy>
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
    | CTyObject of ConsedNode<ObjectDict * EnvTerm>
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
    | TyObject of ObjectDict * EnvTerm
    | TyMap of MapTerm

    | TyT of ConsedTy
    | TyV of TyTag
    | TyBox of TypedData * ConsedTy
    | TyLit of Value

and TypedBind = // TypedData being `TyList []` indicates a statement.
    | TyLet of TypedData * ConsedTy * Trace * TypedOp
    | TyLocalReturnOp of ConsedTy * Trace * TypedOp
    | TyLocalReturnData of TypedData * ConsedTy * Trace

and TypedOp = 
    | TyOp of Op * TypedData
    | TyIf of tr: TypedBind [] * fl: TypedBind []
    | TyCase of TyTag * (TypedData * TypedBind []) []
    | TyJoinPoint of JoinPointKey * JoinPointType * CallArguments

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
and VarTag = int
and StackSize = int
and FreeVars = VarTag []
and ObjectDict = TaggedDictionary<KeywordArgTag,Expr * StackSize>

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

type ModulePrepassEnv = {
    modpre_seq : ResizeArray<TypedBind>
    modpre_context : ResizeArray<TypedData>
    modpre_map : Map<string, int>
    }

type PrepassEnv = {
    prepass_context : EnvTerm
    prepass_map : Map<string, int>
    prepass_map_length : int
    }

type LangEnv = {
    rbeh : RecursiveBehavior
    seq : ResizeArray<TypedBind>
    env_global : EnvTerm
    env_stack : EnvTerm
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

let inline n (x: Node<_>) = x.Expression
let (|N|) x = n x

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.[k] <- v; v

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

exception PrepassError of string
exception PrepassErrorWithPos of PosKey * string
exception TypeError of Trace * string
exception TypeRaised of ConsedTy