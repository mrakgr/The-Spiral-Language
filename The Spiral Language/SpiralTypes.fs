module Spiral.Types

// Global open
open System
open System.Collections.Generic
open HashConsing
open System.Text
open FSharpx.Collections

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

let inline n (x: HashNode<_>) = x.Expression
let (|N|) x = n x

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
    | ListIndex // codegen only
    | ListCons
    | ListTakeNCPS
    | ListTakeNTailCPS

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

    // Subtype tests
    | CaseableIs
    | CaseableBoxIs
    | BoxIs
    | BlittableIs

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

    // Type lit ops
    | TypeLitCreate
    | TypeLitCast
    | TypeLitIs
    | TypeLitCPS

    // UnOps
    | Neg
    | FailWith
    | LocalReturn

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

and FunctionCore = string * Expr
and FunctionRecCore = string * Expr * string
and HashRef = int option ref

and Pattern =
    | PatE
    | PatVar of string
    | PatTuple of Pattern list
    | PatCons of Pattern list
    | PatTypeEq of Pattern * Expr
    | PatActive of Expr * Pattern
    | PatPartActive of Expr * Pattern
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatXor of Pattern list
    | PatNot of Pattern
    | PatClauses of (Pattern * Expr) list
    | PatTypeLit of Value
    | PatTypeLitBind of string
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
    | CFunctionT of ConsedNode<FunctionCore * EnvTy>
    | CRecFunctionT of ConsedNode<FunctionRecCore * EnvTy>
    | CMapT of ConsedNode<MapTy>
    | CLayoutT of ConsedNode<LayoutType * ConsedTypedData>
    | CUnionT of ConsedNode<Set<ConsedTy>>

    | CPrimT of PrimitiveType
    | CLitT of Value
    | CTermCastedFunctionT of ConsedTy * ConsedTy
    | CRecUnionT of JoinPointKey
    | CArrayT of ArrayType * ConsedTy
    | CDotNetTypeT of ConsedTypedData // macro
    | CCudaTypeT of ConsedTypedData // macro

and ConsedTypedData = 
    | CTyList of ConsedNode<ConsedTypedData list>
    | CTyFunction of ConsedNode<FunctionCore * EnvTerm>
    | CTyRecFunction of ConsedNode<FunctionRecCore * EnvTerm>
    | CTyMap of ConsedNode<MapTerm>

    | CTyT of ConsedTy
    | CTyV of TyTag
    | CTyBox of ConsedTypedData * ConsedTy
    | CTyLit of Value

and TypedData =
    | TyList of TypedData list
    | TyFunction of FunctionCore * EnvTerm
    | TyRecFunction of FunctionRecCore * EnvTerm
    | TyMap of MapTerm

    | TyT of ConsedTy
    | TyV of TyTag
    | TyBox of TypedData * ConsedTy
    | TyLit of Value

and TypedExpr = // TypedData being `TyList []` indicates either a statement, or a local return if it is in last place of the array.
    | TyOp of TypedData * ConsedTy * Trace * Op * TypedData
    | TyIf of TypedData * ConsedTy * Trace * tr: TypedExpr [] * fl: TypedExpr []
    | TyCase of TypedData * ConsedTy * Trace * TyTag * (TypedData * TypedExpr []) []
    | TyJoinPoint of TypedData * ConsedTy * Trace * JoinPointKey * JoinPointType * CallArguments

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
and MapTy = Map<string, ConsedTy>
and EnvTy = ConsedTy []
and EnvTerm = TypedData []
and MapTerm = Map<string,TypedData>

and JoinPointKey = Node<Expr * EnvTerm>

and CallArguments = TyTag []
and Renamer = Dictionary<Tag,Tag>

// This key is for functions without arguments. It is intended that the arguments be passed in through the Environment.
and JoinPointDict<'a,'b> = Dictionary<JoinPointKey, JoinPointState<'a,'b>>

and Trace = PosKey list

type TypeOrMethod =
    | TomType of Ty
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

/// Wraps the argument in a list if not a tuple.
let tuple_field = function 
    | TyList (args) -> args
    | x -> [x]

let (|TyTuple|) x = tuple_field x

let (|TypeLit|_|) = function
    | TyT (LitT x) -> Some x
    | _ -> None
let (|TypeString|_|) = function
    | TyT (LitT (LitString x)) -> Some x
    | _ -> None

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

let rec map_to_ty env = Map.map (fun _ -> get_type_data) env
and env_to_ty x = Array.map get_type_data x
and get_type_data = function
    | TyT t | TyV(_,t) | TyBox(_,t) -> t
    | TyLit x -> get_type_of_value x
    | TyList l -> List.map get_type_data l |> ListT
    | TyMap l -> MapT(map_to_ty l)
    | TyFunction (c, l, _) -> FunctionT(c, env_to_ty l)
    | TyRecFunction (c, l, _) -> RecFunctionT(c, env_to_ty l)

let (|TyType|) x = get_type_data x

let show_primt = function
    | UInt8T -> "uint8"
    | UInt16T -> "uint16"
    | UInt32T -> "uint32"
    | UInt64T -> "uint64"
    | Int8T -> "int8"
    | Int16T -> "int16"
    | Int32T -> "int32"
    | Int64T -> "int64"
    | Float32T -> "float32"
    | Float64T -> "float64"
    | BoolT -> "bool"
    | StringT -> "string"
    | CharT -> "char"

let show_value = function
    | LitUInt8 x -> sprintf "%iu8" x
    | LitUInt16 x -> sprintf "%iu16" x
    | LitUInt32 x -> sprintf "%iu32" x
    | LitUInt64 x -> sprintf "%iu64" x
    | LitInt8 x -> sprintf "%ii8" x
    | LitInt16 x -> sprintf "%ii16" x
    | LitInt32 x -> sprintf "%ii32" x
    | LitInt64 x -> sprintf "%ii64" x
    | LitFloat32 x -> sprintf "%ff32" x
    | LitFloat64 x -> sprintf "%ff64" x
    | LitBool x -> sprintf "%b" x
    | LitString x -> sprintf "%s" x
    | LitChar x -> sprintf "%c" x

let show_art = function
    | ArtDotNetHeap -> "array"
    | ArtDotNetReference -> "ref"
    | ArtCudaGlobal _ -> "array_cuda_global"
    | ArtCudaShared -> "array_cuda_shared"
    | ArtCudaLocal -> "array_cuda_local"

let show_layout_type = function
    | LayoutStack -> "layout_stack"
    | LayoutPackedStack -> "layout_packed_stack"
    | LayoutHeap -> "layout_heap"
    | LayoutHeapMutable -> "layout_heap_mutable"

let inline codegen_macro' show_typedexpr codegen print_type x = 
    let strb = StringBuilder()
    let inline append (x: string) = strb.Append x |> ignore
    let (|LS|) = function
            | TyLit (LitString x) | TypeString x -> x
            | _ -> failwithf "Iter's first three arguments must be strings."
    let er x = failwithf "Unknown argument in macro. Got: %s" (show_typedexpr x)
    let rec iter begin_ sep end_ ops = 
        append begin_
        match ops with
        | TyList (x :: xs) -> f x; List.iter (fun x -> append sep; f x) xs
        | TyList [] -> ()
        | x -> er x
        append end_
    and f = function
        | TyList [TypeString "text"; (TyLit (LitString x) | TypeString x)] -> append x
        | TyList [TypeString "arg"; x] -> append (codegen x)
        | TyList [TypeString "args"; TyTuple l] -> append "("; List.map codegen l |> String.concat ", " |> append; append ")"
        | TyList [TypeString "fs_array_args"; TyTuple l] -> append "[|"; List.map codegen l |> String.concat "; " |> append; append "|]"
        | TyList [TypeString "type"; TyType x] -> append (print_type x)
        | TyList [TypeString "types"; TyTuple l] -> append "<"; List.map (get_type_data >> print_type) l |> String.concat ", " |> append; append ">" 
        | TyList [TypeString "iter"; TyList [LS begin_;LS sep;LS end_;ops]] -> iter begin_ sep end_ ops
        | TyList [TypeString "parenth"; ops] -> iter "(" "," ")" ops
        | x -> er x
    match x with
    | TyList x -> List.iter f x
    | x -> er x
    strb.ToString()

let rec show_ty = function
    | PrimT x -> show_primt x
    | ListT l -> sprintf "[%s]" (List.map show_ty l |> String.concat ", ")
    | LitT v -> sprintf "type_lit (%s)" (show_value v)
    | MapT v -> 
        let body = 
            v |> Map.toArray 
            |> Array.map (fun (k,v) -> sprintf "%s=%s" k (show_ty v))
            |> String.concat "; "

        sprintf "{%s}" body
    | FunctionT _ | RecFunctionT _ -> "<function>"
    | LayoutT (layout_type,body) ->
        sprintf "%s (%s)" (show_layout_type layout_type) (show_typedexpr body)
    | TermCastedFunctionT (a,b) ->
        sprintf "(%s => %s)" (show_ty a) (show_ty b)
    | UnionT l ->
        let body =
            Set.toArray l
            |> Array.map show_ty
            |> String.concat " | "
        sprintf "union {%s}" body
    | RecUnionT x -> sprintf "rec_union_type %i" x.Symbol
    | ArrayT (a,b) -> sprintf "%s (%s)" (show_art a) (show_ty b)
    | DotNetTypeT x -> sprintf "dotnet_type (%s)" (codegen_macro' show_typedexpr show_typedexpr show_ty x)
    | CudaTypeT x -> sprintf "cuda_type (%s)" (codegen_macro' show_typedexpr show_typedexpr show_ty x)

and show_typedexpr = function
    | TyT x -> sprintf "type (%s)" (show_ty x)
    | TyV (_,t) -> sprintf "var (%s)" (show_ty t)
    | TyList l -> 
        let body = List.map show_typedexpr l |> String.concat ", "
        sprintf "[%s]" body
    | TyMap a ->
        let body =
            Map.toArray a
            |> Array.map (fun (a,b) -> sprintf "%s=%s" a (show_typedexpr b))
            |> String.concat "; "
        sprintf "{%s}" body
    | TyFunction _ | TyRecFunction _ -> "<function>"
    | TyBox (a,b) -> sprintf "(boxed_type %s with %s)" (show_ty b) (show_typedexpr a)
    | TyLit v -> sprintf "lit %s" (show_value v)

let inline codegen_macro codegen print_type x = codegen_macro' show_typedexpr codegen print_type x

let lit_is = function
    | TyLit _ -> true
    | _ -> false

let val_is = function
    | TyLit _ 
    | TyV(_, (PrimT _ | LitT _))
    | TyT(PrimT _ | LitT _) -> true
    | _ -> false

type Timings = {
    parsing_time: TimeSpan    
    prepass_time: TimeSpan
    peval_time: TimeSpan
    codegen_time: TimeSpan
    }

exception TypeError of Trace * string
exception TypeRaised of Ty