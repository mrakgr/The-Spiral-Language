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

let mutable module_tag = 0
type SpiralModule(name: string, prerequisites : SpiralModule list, description : string, code : string) = 
    let tag = module_tag
    do module_tag <- module_tag + 1
    member __.Tag = tag
    member __.Name = name
    member __.Prerequisites = prerequisites
    member __.Description = description
    member __.Code = code

    override x.Equals(y) =
        match y with
        | :? SpiralModule as y -> x.Tag = y.Tag
        | _ -> failwith "Invalid equality for SpiralModule."

    override x.GetHashCode() = x.Tag
    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? SpiralModule as y -> compare x.Tag y.Tag
            | _ -> failwith "Invalid comparison for SpiralModule."

let spiral_module name prerequisites description code = SpiralModule(name,prerequisites,description,code)

type PosKey = SpiralModule * int64 * int64

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

    // Record
    | RecordMap
    | RecordFilter
    | RecordFoldL
    | RecordFoldR
    | RecordLength

    // Braching
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

and PatternArg = {
    pat_on_succ : RawExpr
    pat_on_fail : RawExpr
    }

and PatRecordMembersItem =
    | PatRecordMembersKeyword of keyword: KeywordString * name: Pattern
    | PatRecordMembersInjectVar of var: VarString * name: Pattern
and Pattern =
    | PatE
    | PatVar of string
    | PatTuple of Pattern list
    | PatKeyword of string * Pattern list
    | PatCons of Pattern list
    | PatTypeEq of Pattern * RawExpr
    | PatActive of RawExpr * Pattern
    | PatPartActive of RawExpr * Pattern
    | PatUnbox of Pattern
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatNot of Pattern
    | PatLit of Value
    | PatWhen of Pattern * RawExpr
    | PatRecordMembers of PatRecordMembersItem list
    | PatPos of Pos<Pattern>
    | PatTypeTermFunction of Pattern * Pattern

and ModulePrepassExpr =
    | ModPreLet of string * RawExpr * ModulePrepassExpr
    | ModPreOpen of string * ModulePrepassExpr

and VarString = string
and KeywordString = string

and RawRecordTestPattern = 
    | RawRecordTestKeyword of keyword: KeywordString * name: VarString
    | RawRecordTestInjectVar of var: VarString * name: VarString
and RawRecordWithPattern = 
    | RawRecordWithKeyword of KeywordString * RawExpr 
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithoutKeyword of KeywordString 
    | RawRecordWithoutInjectVar of VarString

and RawExpr =
    | RawV of string
    | RawLit of Value
    | RawOpen of VarString * KeywordString [] * RawExpr
    | RawFunction of RawExpr * VarString
    | RawRecFunction of RawExpr * VarString * rec_name: VarString
    | RawObjectCreate of (VarString * KeywordString [] * RawExpr) []
    | RawKeywordCreate of KeywordString * RawExpr []
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawCase of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawIf of cond: RawExpr * on_succ: RawExpr * on_fail: RawExpr
    | RawListTakeAllTest of vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawListTakeNTest of vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    | RawExprPos of Pos<RawExpr>
    | RawPattern of VarString * (Pattern * RawExpr) []

and RecordTestPattern = RecordTestKeyword of keyword: KeywordTag | RecordTestInjectVar of var: VarTag
and RecordWithPattern = 
    | RecordWithKeyword of keyword: KeywordTag * Expr 
    | RecordWithInjectVar of var: VarTag * Expr
    | RecordWithoutKeyword of keyword: KeywordTag
    | RecordWithoutInjectVar of var: VarTag

and Expr =
    | V of Tag * VarTag
    | Lit of Tag * Value
    | Open of Tag * VarTag * KeywordTag [] * Expr
    | Function of Tag * Expr * FreeVars * StackSize
    | RecFunction of Tag * Expr * FreeVars * StackSize
    | ObjectCreate of ObjectDict * FreeVars
    | KeywordCreate of Tag * KeywordTag * Expr []
    | Let of Tag * bind: Expr * on_succ: Expr
    | Case of Tag * bind: Expr * on_succ: Expr
    | If of Tag * cond: Expr * on_succ: Expr * on_fail: Expr
    | ListTakeAllTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    | ListTakeNTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    | KeywordTest of Tag * KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    | RecordTest of Tag * RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    | RecordWith of Tag * Expr [] * RecordWithPattern []
    | Op of Tag * Op * Expr []
    | ExprPos of Tag * Pos<Expr>

and ConsedTy =
    | CListT of ConsedNode<ConsedTy list>
    | CTyKeyword of ConsedNode<KeywordTag * ConsedTy []>
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
    | CTyKeyword of ConsedNode<KeywordTag * TypedData []>
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
    | TyKeyword of KeywordTag * TypedData []
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
and KeywordTag = int
and MapTerm = Map<KeywordTag,TypedData>
and MapTy = Map<KeywordTag, ConsedTy>
and VarTag = int
and StackSize = int
and FreeVars = VarTag []
and ObjectDict = TaggedDictionary<KeywordTag,Expr * StackSize>

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

type PrepassSubrenameEnv = {
    subren_dict : Dictionary<int, int>
    subren_size_lexical_scope : int
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

let v x = RawV x
let lit x = RawLit x
let open_ var subs on_succ = RawOpen(var,subs,on_succ)
let inl x y = RawFunction(y,x)
let objc m = RawObjectCreate m
let keyword k l = RawKeywordCreate(k,l)
let l bind body on_succ = RawLet(bind,body,on_succ)
let case bind body on_succ = RawCase(bind,body,on_succ)
let if_ cond on_succ on_fail = RawIf(cond,on_succ,on_fail)
let list_take_all_test x bind on_succ on_fail = RawListTakeAllTest(x,bind,on_succ,on_fail)
let list_take_n_test x bind on_succ on_fail = RawListTakeNTest(x,bind,on_succ,on_fail)
let list_keyword_test keyword x bind on_succ on_fail = RawKeywordTest(keyword,x,bind,on_succ,on_fail)
let module_test x bind on_succ on_fail = RawRecordTest(x,bind,on_succ,on_fail)
let module_with binds patterns = RawRecordWith(binds,patterns)
    
let op x args = RawOp(x,args)
let vv x = op ListCreate x
let B = vv [||]
let pattern arg clauses = RawPattern(arg,clauses)

let binop op' a b = op op' [|a;b|]
let eq x y = binop EQ x y
let eq_type a b = binop EqType a b
let ap x y = binop Apply x y
let rec ap' f l = Array.fold ap f l
let expr_pos pos x = RawExprPos(Position(pos,x))
let pat_pos pos x = PatPos(Position(pos,x))

// The seemingly useless function application is there to filter the environment just in case it has not been done.
let join_point_entry_method y = ap (inl "" (op JoinPointEntryMethod [|y|])) B 
let join_point_entry_type y = ap (inl "" (op JoinPointEntryType [|y|])) B