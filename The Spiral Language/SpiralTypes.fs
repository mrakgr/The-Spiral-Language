module Spiral.Types

// Global open
open System
open System.Collections.Generic
open HashConsing

// Globals
let mutable private module_tag = 0
let private hash_cons_table = HashConsing.hashcons_create 0
let private hash_cons_add x = HashConsing.hashcons_add hash_cons_table x

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
        | _ -> false

    override __.GetHashCode() = tag

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? TaggedDictionary<'a,'b> as y -> compare tag y.Tag
            | _ -> raise <| ArgumentException "Invalid comparison for TaggedDictionary."

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
        | _ -> false

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
    | RawObjectCreate of (VarString * RawExpr) []
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
    | ExprPos of Tag * Pos<Expr>
    | Op of Tag * Op * Expr []

and HasFreeVars = bool

and ConsedTy =
    | ListT of ConsedNode<ConsedTy list>
    | KeywordT of ConsedNode<KeywordTag * ConsedTy []>
    | FunctionT of ConsedNode<Expr * StackSize * EnvTy>
    | RecFunctionT of ConsedNode<Expr * StackSize * EnvTy>
    | ObjectT of ConsedNode<ObjectDict * EnvTy>
    | MapT of ConsedNode<MapTy>
    | LayoutT of ConsedNode<LayoutType * ConsedTypedData * HasFreeVars>
    | UnionT of ConsedNode<Set<ConsedTy>>
    | RecUnionT of ConsedNode<JoinPointKey>

    | PrimT of PrimitiveType
    | TermCastedFunctionT of ConsedTy * ConsedTy
    | ArrayT of ArrayType * ConsedTy
    | DotNetTypeT of string // macro
    | CudaTypeT of string // macro

and ConsedTypedData = // for join points and layout types
    | CTyList of ConsedNode<ConsedTypedData list>
    | CTyKeyword of ConsedNode<KeywordTag * ConsedTypedData []>
    | CTyFunction of ConsedNode<Expr * StackSize * ConsedEnvTerm>
    | CTyRecFunction of ConsedNode<Expr * StackSize * ConsedEnvTerm>
    | CTyObject of ConsedNode<ObjectDict * ConsedEnvTerm>
    | CTyMap of ConsedNode<ConsedMapTerm>

    | CTyT of ConsedTy
    | CTyV of TyTag
    | CTyBox of ConsedTypedData * ConsedTy
    | CTyLit of Value

and TypedData =
    | TyList of TypedData list
    | TyKeyword of KeywordTag * TypedData []
    | TyFunction of Expr * StackSize * EnvTerm
    | TyRecFunction of Expr * StackSize * EnvTerm
    | TyObject of ObjectDict * EnvTerm
    | TyMap of MapTerm

    | TyT of ConsedTy
    | TyV of TyTag
    | TyBox of TypedData * ConsedTy
    | TyLit of Value

and TypedBind = // TypedData being `TyList []` indicates a statement.
    | TyLet of TypedData * Trace * TypedOp
    | TyLocalReturnOp of Trace * TypedOp
    | TyLocalReturnData of TypedData * ConsedTy * Trace

and TypedOp = 
    | TyOp of Op * TypedData * ConsedTy
    | TyIf of tr: TypedBind [] * fl: TypedBind [] * ConsedTy
    | TyCase of TypedData * (TypedData * TypedBind []) [] * ConsedTy
    | TyJoinPoint of JoinPointKey * JoinPointType * CallArguments * ConsedTy

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
and ConsedEnvTerm = ConsedTypedData []
and KeywordTag = int
and MapTerm = Map<KeywordTag,TypedData>
and ConsedMapTerm = Map<KeywordTag,ConsedTypedData>
and MapTy = Map<KeywordTag, ConsedTy>
and VarTag = int
and StackSize = int
and FreeVars = VarTag []
and ObjectDict = TaggedDictionary<KeywordTag,Expr * StackSize>

and JoinPointKey = Expr * ConsedEnvTerm

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
    trace : Trace
    // Recursive join points
    rbeh : RecursiveBehavior
    // Joint points
    seq : ResizeArray<TypedBind>
    // Objects and inlineables
    env_global : EnvTerm
    env_stack : EnvTerm
    env_stack_ptr : int
    // If statements
    cse : Map<Op * TypedData, TypedData> ref
    }

type Result<'a,'b> = Succ of 'a | Fail of 'b

// Parser types
type Userstate = {
    ops : Dictionary<string, int * FParsec.Associativity>
    semicolon_line : int64
    }

type ParserExpr =
| ParserStatement of (RawExpr -> RawExpr)
| ParserExpr of RawExpr

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

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.[k] <- v; v

let cuda_kernels_name = "cuda_kernels"

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
let func x y = RawFunction(y,x)
let objc m = RawObjectCreate m
let keyword k l = RawKeywordCreate(k,l)
let keyword_unary k = RawKeywordCreate(k,[||])
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

let unop op' a = op op' [|a|]
let binop op' a b = op op' [|a;b|]
let eq x y = binop EQ x y
let eq_type a b = binop EqType a b
let ap x y = binop Apply x y
let rec ap' f l = Array.fold ap f l
let expr_pos pos x = RawExprPos(Position(pos,x))
let pat_pos pos x = PatPos(Position(pos,x))

// The seemingly useless function application is there to filter the environment just in case it has not been done.
let join_point_entry_method y = ap (func "" (op JoinPointEntryMethod [|y|])) B 
let join_point_entry_type y = ap (func "" (op JoinPointEntryType [|y|])) B

let pat_main = " pat_main"

let inline (|C|) (x: ConsedNode<_>) = x.node

let ty_is_unit e =
    let dict = Dictionary(HashIdentity.Reference)
    let rec is_unit_list t = List.forall is_unit t
    and is_unit_array t = Array.forall is_unit t
    and is_unit_map x = Map.forall (fun _ -> is_unit) x
    and is_unit e = 
        memoize dict (function
            | UnionT _ | RecUnionT _ | DotNetTypeT _ | CudaTypeT _ | TermCastedFunctionT _ | PrimT _ -> false
            | ArrayT (_,t) -> is_unit t
            | MapT t -> is_unit_map t.node
            | ObjectT(C(_,env)) | KeywordT(C(_,env)) | FunctionT(C(_,_,env)) | RecFunctionT(C(_,_,env)) -> is_unit_array env
            | LayoutT (C(_, _, has_free_vars)) -> has_free_vars = false // This is enough as unit types automatically get converted to TyT.
            | ListT t -> is_unit_list t.node
            ) e
    is_unit e

let get_type_of_value = function
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

let rec type_get_module env = Map.map (fun _ -> type_get) env
and type_get_list env = List.map type_get env
and type_get_array env = Array.map type_get env
and type_get = function
    | TyKeyword(t,l) -> (t, type_get_array l) |> hash_cons_add |> KeywordT
    | TyList l -> type_get_list l |> hash_cons_add |> ListT
    | TyFunction (a,b,l) -> (a,b,type_get_array l) |> hash_cons_add |> FunctionT
    | TyRecFunction (a,b,l) -> (a,b,type_get_array l) |> hash_cons_add |> RecFunctionT
    | TyObject(a,l) -> (a,type_get_array l) |> hash_cons_add |> ObjectT
    | TyMap l -> type_get_module l |> hash_cons_add |> MapT
    | TyT x | TyV(_,x) | TyBox(_,x) -> x
    | TyLit x -> get_type_of_value x

let typed_op_type = function
    | TyOp(_,_,t) | TyIf(_,_,t) | TyCase(_,_,t) | TyJoinPoint(_,_,_,t) -> t

let typed_bind_type = function
    | TyLet(_,_,op) | TyLocalReturnOp(_,op) -> typed_op_type op
    | TyLocalReturnData(_,t,_) -> t

