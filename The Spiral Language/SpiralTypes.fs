module Spiral.Types

// Global open
open System
open System.Collections.Generic
open HashConsing
open System.Runtime.CompilerServices

// Globals
let hash_cons_table = HashConsing.HashConsTable()

// Language types
type LayoutType =
    | LayoutStack
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

type SpiralModule =
    {
    name: string
    prerequisites : SpiralModule list 
    opens: string list list
    description : string 
    code : string
    }

type PosKey = SpiralModule * int * int

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
    // Macros
    | Macro
    | MacroExtern

    // Term function
    | TermFunctionTypeCreate
    | TermFunctionIs
    | TermFunctionDomain
    | TermFunctionRange

    // Unsafe casts
    | UnsafeConvert
    | UnsafeCoerceToArrayCudaGlobal

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
    | JoinPointEntryType
    | JoinPointEntryCuda
    
    // Application related
    | Apply
    | TermCast // Term cast also places the closure join point directly.
    | TypeAnnot

    // Layout
    | LayoutToNone
    | LayoutToStack
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

    // Recursive types
    | RecUnionGetName
    | RecUnionGetMeta

    // Array
    | ArrayCreateDotNet
    | ArrayCreateCudaLocal
    | ArrayCreateCudaShared
    | ReferenceCreate
    | ArrayLength

    // Getters
    | GetArray
    | GetReference

    // Setters
    | SetArray
    | SetReference
    | SetMutableRecord
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | Dynamize
    | IsLit
    | IsPrim
    | IsLayout
    | IsKeyword
    | StripKeyword
    | IsBox
    | IsUnion
    | IsRecUnion
    | IsRuntimeUnion
    | IsRuntimeRecUnion

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
    | ArtCudaGlobal of ConsedTy
    | ArtCudaShared
    | ArtCudaLocal

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
    // Note: The VarStrings are annotated with positional information using `var_position_dict` global dictionary in the Tokenize module.
    | RawV of VarString 
    | RawLit of Value
    | RawInline of RawExpr // Acts as a join point during the prepass.
    | RawFunction of RawExpr * VarString
    | RawRecFunction of RawExpr * VarString * rec_name: VarString
    | RawObjectCreate of (VarString * RawExpr) []
    | RawKeywordCreate of KeywordString * RawExpr []
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawCase of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawListTakeAllTest of vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawListTakeNTest of vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    | RawExprPos of Pos<RawExpr>
    | RawPattern of (VarString * (Pattern * RawExpr) []) // These parenthesis are here so the pattern compilation can be memoized via reference identity.

and RecordTestPattern = RecordTestKeyword of keyword: KeywordTag | RecordTestInjectVar of var: VarTag
and RecordWithPattern = 
    | RecordWithKeyword of keyword: KeywordTag * Expr 
    | RecordWithInjectVar of VarString * var: VarTag * Expr // VarString here is for error messages in the partial evaluator.
    | RecordWithoutKeyword of keyword: KeywordTag
    | RecordWithoutInjectVar of VarString * var: VarTag

and [<CustomEquality; CustomComparison>] Expr =
    | V of Tag * VarTag
    | Lit of Tag * Value
    | Inline of Tag * Expr * FreeVars * StackSize
    | Function of Tag * Expr * FreeVars * StackSize
    | RecFunction of Tag * Expr * FreeVars * StackSize
    | ObjectCreate of ObjectDict * FreeVars
    | KeywordCreate of Tag * KeywordTag * Expr []
    | Let of Tag * bind: Expr * on_succ: Expr
    | Case of Tag * bind: Expr * on_succ: Expr
    | ListTakeAllTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    | ListTakeNTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    | KeywordTest of Tag * KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    | RecordTest of Tag * RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    | RecordWith of Tag * Expr [] * RecordWithPattern []
    | ExprPos of Tag * Pos<Expr>
    | Op of Tag * Op * Expr []

    member t.Tag' =
        match t with
        | ObjectCreate(x,_) -> x.Tag
        | V(x,_) | Lit(x,_) | Inline(x,_,_,_) | Function(x,_,_,_)
        | RecFunction(x,_,_,_) | KeywordCreate(x,_,_) | Let(x,_,_)
        | Case(x,_,_) | ListTakeAllTest(x,_,_,_,_) | ListTakeNTest(x,_,_,_,_)
        | KeywordTest(x,_,_,_,_) | RecordTest(x,_,_,_,_) | RecordWith(x,_,_)
        | ExprPos(x,_) | Op(x,_,_) -> x

    override a.Equals(b) = Object.ReferenceEquals(a,b)
    override a.GetHashCode() = a.Tag'

    interface IComparable with
        member a.CompareTo(b) = 
            match b with
            | :? Expr as b -> compare a.Tag' b.Tag'
            | _ -> raise <| ArgumentException "Invalid comparison for Expr."

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
    | RecUnionT of string * ConsedTy * JoinPointKey

    | PrimT of PrimitiveType
    | TermCastedFunctionT of ConsedTy * ConsedTy
    | ArrayT of ArrayType * ConsedTy
    | MacroT of ConsedTypedData

and ConsedTypedData = // for join points and layout types
    | CTyList of ConsedNode<ConsedTypedData list>
    | CTyKeyword of ConsedNode<KeywordTag * ConsedTypedData []>
    | CTyFunction of ConsedNode<Expr * StackSize * ConsedEnvTerm>
    | CTyRecFunction of ConsedNode<Expr * StackSize * ConsedEnvTerm>
    | CTyObject of ConsedNode<ObjectDict * ConsedEnvTerm>
    | CTyMap of ConsedNode<ConsedMapTerm>

    | CTyT of ConsedTy
    | CTyV of Tag * ConsedTy
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
    | TyLocalReturnData of TypedData * Trace

and JoinPoint = JoinPointKey * JoinPointType * TyTag []

and TypedOp = 
    | TyOp of Op * TypedData
    | TyIf of cond: TypedData * tr: TypedBind [] * fl: TypedBind []
    | TyWhile of cond: JoinPoint * TypedBind []
    | TyCase of TypedData * (TypedData * TypedBind []) []
    | TyLayoutToNone of TypedData
    | TyJoinPoint of JoinPoint
    | TySetMutableRecord of TypedData * (Tag * ConsedTy) [] * TyTag []

and JoinPointType =
    | JoinPointClosure
    | JoinPointMethod
    | JoinPointType
    | JoinPointCuda

and JoinPointState<'a,'b> =
    | JoinPointInEvaluation of 'a
    | JoinPointDone of 'b

and Tag = int
and [<CustomComparison;CustomEquality>] T<'a,'b when 'a: equality and 'a: comparison> = 
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
and TyTag = T<int,ConsedTy>

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

and JoinPointKey = Expr * ConsedTypedData

// This key is for functions without arguments. It is intended that the arguments be passed in through the Environment.
and JoinPointDict<'a,'b> = Dictionary<JoinPointKey, JoinPointState<'a,'b>>

and Trace = PosKey list

type RecursiveBehavior =
    | AnnotationDive
    | AnnotationReturn

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

// Codegen types
let inline memoize' (memo_dict: ConditionalWeakTable<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v
let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

let cuda_kernels_name = "cuda_kernels"

type SpiralCompilerSettings = {
    trace_length : int // The length of the error messages.
    filter_list : string list // List of modules to be ignored in the trace.
    }

/// Here are the paths on my machine.
let cfg_default = {
    trace_length = 20
    filter_list = 
        [
        //"Core"; "Option"; "Lazy"; "Tuple"; "Liple"; "Loops"; "Extern"; "Array"; "List"; "Parsing"; "Console"
        //"Queue"; "Struct"; "Tensor"; "View"; "ViewR"; "Object"; "Cuda"; "Random"; "Math"
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
exception TypeRaised of ConsedTy
exception CodegenError of string
exception CodegenErrorWithPos of Trace * string
exception CompileError of string
exception CompileErrorWithPos of Trace * string

let v x = RawV x
let lit x = RawLit x
let inline_ = function RawInline _ as x -> x | x -> RawInline x
let func x y = RawFunction(y,x)
let objc m = RawObjectCreate m
let keyword k l = RawKeywordCreate(k,l)
let keyword_unary k = RawKeywordCreate(k,[||])
let l bind body on_succ = RawLet(bind,body,on_succ)
let case bind body on_succ = RawCase(bind,body,on_succ)
let if_ cond on_succ on_fail = RawOp(If,[|cond;on_succ;on_fail|])
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

// The seemingly useless function application is there to filter unused arguments from the environment and move the rest to `env_global`.
let join_point_entry_method y = inline_ (op JoinPointEntryMethod [|y|])

let pat_main = " pat_main"

let inline (|C|) (x: ConsedNode<_>) = x.node

let type_is_unit e =
    let dict = Dictionary(HashIdentity.Reference)
    let rec f e = 
        memoize dict (function
            | UnionT _ | RecUnionT _ | MacroT _ | TermCastedFunctionT _ | PrimT _ -> false
            | ArrayT (_,t) -> f t
            | MapT t -> Map.forall (fun _ -> f) t.node
            | ObjectT(C(_,env)) | KeywordT(C(_,env)) | FunctionT(C(_,_,env)) | RecFunctionT(C(_,_,env)) -> Array.forall f env
            | LayoutT (C(_, _, has_free_vars)) -> has_free_vars = false // This is enough as unit types automatically get converted to TyT.
            | ListT t -> List.forall f t.node
            ) e
    f e

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

let keywordt x = x |> hash_cons_table.Add |> KeywordT
let listt x = x |> hash_cons_table.Add |> ListT
let functiont x = x |> hash_cons_table.Add |> FunctionT
let recfunctiont x = x |> hash_cons_table.Add |> RecFunctionT
let objectt x = x |> hash_cons_table.Add |> ObjectT
let mapt x = x |> hash_cons_table.Add |> MapT
let layoutt x = x |> hash_cons_table.Add |> LayoutT
let uniont x = x |> hash_cons_table.Add |> UnionT

let rec type_get = function
    | TyKeyword(t,l) -> (t, Array.map type_get l) |> keywordt
    | TyList l -> List.map type_get l |> listt
    | TyFunction (a,b,l) -> (a,b,Array.map type_get l) |> functiont
    | TyRecFunction (a,b,l) -> (a,b,Array.map type_get l) |> recfunctiont
    | TyObject(a,l) -> (a,Array.map type_get l) |> objectt
    | TyMap l -> Map.map (fun _ -> type_get) l |> mapt
    | TyT x | TyV(T(_,x)) | TyBox(_,x) -> x
    | TyLit x -> get_type_of_value x

let rec type_consed_data_get = function
    | CTyKeyword(C(t,l)) -> (t, Array.map type_consed_data_get l) |> keywordt
    | CTyList(C l) -> List.map type_consed_data_get l |> listt
    | CTyFunction(C(a,b,l)) -> (a,b,Array.map type_consed_data_get l) |> functiont
    | CTyRecFunction(C(a,b,l)) -> (a,b,Array.map type_consed_data_get l) |> recfunctiont
    | CTyObject(C(a,l)) -> (a,Array.map type_consed_data_get l) |> objectt
    | CTyMap l -> Map.map (fun _ -> type_consed_data_get) l.node |> mapt
    | CTyT x | CTyV(_,x) | CTyBox(_,x) -> x
    | CTyLit x -> get_type_of_value x

let typed_data_is_unit a = type_get a |> type_is_unit

let (|TyType|) x = type_get x
let (|TyTuple|) = function
    | TyList l -> l
    | x -> [x]

let lit_is = function
    | TyLit _ -> true
    | _ -> false

let tyb = ListT (hash_cons_table.Add [])

let rec fsharp_to_cuda_blittable_is = function
    | PrimT t ->
        match t with
        | BoolT _ | CharT _ | StringT _ -> false
        | _ -> true
    | ArrayT (ArtCudaGlobal _,t) -> fsharp_to_cuda_blittable_is t
    | LayoutT(C(_, _, false)) ->  true
    | _ -> false

let is_numeric = function
    | PrimT (UInt8T | UInt16T | UInt32T | UInt64T 
        | Int8T | Int16T | Int32T | Int64T 
        | Float32T | Float64T) -> true
    | _ -> false

let is_signed_numeric = function
    | PrimT (Int8T | Int16T | Int32T | Int64T | Float32T | Float64T) -> true
    | _ -> false

let is_non_float_primitive = function
    | PrimT (Float32T | Float64T) -> false
    | PrimT _ -> true
    | _ -> false

let is_primitive = function
    | PrimT _ -> true
    | _ -> false

let is_string = function
    | PrimT StringT -> true
    | _ -> false

let is_char = function
    | PrimT CharT -> true
    | _ -> false

let is_primt = function
    | PrimT x -> true
    | _ -> false

let is_float = function
    | PrimT (Float32T | Float64T) -> true
    | _ -> false

let is_bool = function
    | PrimT BoolT -> true
    | _ -> false

let is_int = function
    | PrimT (UInt32T | UInt64T | Int32T | Int64T) -> true
    | _ -> false

let is_any_int = function
    | PrimT (UInt8T | UInt16T | UInt32T | UInt64T 
        | Int8T | Int16T | Int32T | Int64T) -> true
    | _ -> false

let is_int64 = function
    | PrimT Int64T -> true
    | _ -> false

let is_int32 = function
    | PrimT Int32T -> true
    | _ -> false

let is_lit_zero = function
    | TyLit a ->
        match a with
        | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
        | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL
        | LitFloat32 0.0f | LitFloat64 0.0 -> true
        | _ -> false
    | _ -> false

let is_lit_one = function
    | TyLit a ->
        match a with
        | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
        | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL
        | LitFloat32 1.0f | LitFloat64 1.0 -> true
        | _ -> false
    | _ -> false

let is_int_lit_zero = function
    | TyLit a ->
        match a with
        | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
        | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL -> true
        | _ -> false
    | _ -> false

let is_int_lit_one = function
    | TyLit a ->
        match a with
        | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
        | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL -> true
        | _ -> false
    | _ -> false
