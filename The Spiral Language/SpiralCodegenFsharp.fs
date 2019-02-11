module Spiral.Codegen.Fsharp

open Spiral
open Spiral.Types
open Spiral.PartEval
open System.Collections.Generic

// Globals
let type_dict = Dictionary(HashIdentity.Structural)

type ProgramNode =
    | Text of string
    | Statement of string
    | Statements of string []
    | Indent
    | Dedent

type CodegenEnv() = 
    let types_printed = HashSet(HashIdentity.Structural)
    let types_unprinted = HashSet(HashIdentity.Structural)
    let join_points_printed = HashSet(HashIdentity.Structural)
    let join_points_unprinted = HashSet(HashIdentity.Structural)
    let buffer = ResizeArray()

let raise_codegen_error x = raise (CodegenError x)

let rec type_ = function
    | ListT _  | KeywordT _ | FunctionT _ | RecFunctionT _ | ObjectT _ | MapT _ as x -> 
        match type_non_units x with
        | [||] -> "unit"
        | x -> Array.map type_ x |> String.concat " * "
    | ArrayT(ArtDotNetReference,t) -> sprintf "(%s ref)" (type_ t)
    | ArrayT(ArtDotNetHeap,t) -> sprintf "(%s [])" (type_ t)
    | ArrayT(ArtCudaGlobal t,_) -> type_ t
    | ArrayT((ArtCudaShared | ArtCudaLocal),_) -> raise_codegen_error "Cuda local and shared arrays cannot be used on the F# side."
    | TermCastedFunctionT(a,b) -> sprintf "(%s -> %s)" (type_ a) (type_ b)
    | PrimT x ->
        match x with
        | Int8T -> "int8"
        | Int16T -> "int16"
        | Int32T -> "int32"
        | Int64T -> "int64"
        | UInt8T -> "uint8"
        | UInt16T -> "uint16"
        | UInt32T -> "uint32"
        | UInt64T -> "uint64"
        | Float32T -> "float32"
        | Float64T -> "float"
        | BoolT -> "bool"
        | StringT -> "string"
        | CharT -> "char"
    | MacroT x -> x
    | ty ->
        match type_dict.TryGetValue ty with
        | false, _ -> let x = type_dict.Count in type_dict.Add(ty,x); x-1
        | true, x -> x
        |> sprintf "SpiralType%i"

let tytag (T(tag,ty)) = sprintf "(var_%i : %s)" tag (type_ ty)

let typed_data x = 
    match typed_data_term_vars x with
    | true, _ -> raise_codegen_error <| sprintf "An attempt to manifest a raw type has been attempted.\nGot: %s" (Parsing.show_typed_data x)
    | false, vars -> 
        Array.map (function
            | TyV t -> tytag t
            | TyLit x -> tylit x
            ) vars
        |> String.concat ", " // TODO: Remember to add parenths.

let assign_one ret x =
    match ret with
    | Some vars -> 
        match typed_data_free_vars vars with
        | [|var|] -> sprintf "let %s = %s" (tytag var) x
        | vars -> raise_codegen_error "Compiler error: Expected a single variable in assign_one."
        |> Statement
    | None -> Text x
    
let op ret x =
    match x with
    | TyOp(op, x, _) ->
        match op, x with
        // Primitive operations on expressions.
        | Add,TyList [a;b] -> assign_one ret <| sprintf "(%s + %s)" (typed_data a) (typed_data b)
        | Sub,TyList [a;b] -> assign_one ret <| sprintf "(%s - %s)" (typed_data a) (typed_data b)
        | Mult,TyList [a;b] -> assign_one ret <| sprintf "(%s * %s)" (typed_data a) (typed_data b)
        | Div,TyList [a;b] -> assign_one ret <| sprintf "(%s / %s)" (typed_data a) (typed_data b)
        | Mod,TyList [a;b] -> assign_one ret <| sprintf "(%s %% %s)" (typed_data a) (typed_data b)
        | Pow,TyList [a;b] -> assign_one ret <| sprintf "pow(%s, %s)" (typed_data a) (typed_data b)
        | LT,TyList [a;b] -> assign_one ret <| sprintf "(%s < %s)" (typed_data a) (typed_data b)
        | LTE,TyList [a;b] -> assign_one ret <| sprintf "(%s <= %s)" (typed_data a) (typed_data b)
        | EQ,TyList [a;b] -> assign_one ret <| sprintf "(%s == %s)" (typed_data a) (typed_data b)
        | NEQ,TyList [a;b] -> assign_one ret <| sprintf "(%s != %s)" (typed_data a) (typed_data b)
        | GT,TyList [a;b] -> assign_one ret <| sprintf "(%s > %s)" (typed_data a) (typed_data b)
        | GTE,TyList [a;b] -> assign_one ret <| sprintf "(%s >= %s)" (typed_data a) (typed_data b)
        | BitwiseAnd,TyList [a;b] -> assign_one ret <| sprintf "(%s & %s)" (typed_data a) (typed_data b)
        | BitwiseOr,TyList [a;b] -> assign_one ret <| sprintf "(%s | %s)" (typed_data a) (typed_data b)
        | BitwiseXor,TyList [a;b] -> assign_one ret <| sprintf "(%s ^ %s)" (typed_data a) (typed_data b)

        | ShiftLeft,TyList [x;y] -> assign_one ret <| sprintf "(%s << %s)" (typed_data x) (typed_data y)
        | ShiftRight,TyList[x;y] -> assign_one ret <| sprintf "(%s >> %s)" (typed_data x) (typed_data y)
                    
        | Neg,a -> assign_one ret <| sprintf "(-%s)" (typed_data a)
        | Log,x -> assign_one ret <| sprintf "log(%s)" (typed_data x)
        | Exp,x -> assign_one ret <| sprintf "exp(%s)" (typed_data x)
        | Tanh,x -> assign_one ret <| sprintf "tanh(%s)" (typed_data x)
        | Sqrt,x -> assign_one ret <| sprintf "sqrt(%s)" (typed_data x)
        | NanIs,x -> assign_one ret <| sprintf "isnan(%s)" (typed_data x)
    //| TyIf of cond: TypedData * tr: TypedBind [] * fl: TypedBind [] * ConsedTy
    //| TyWhile of cond: TypedOp * TypedBind []
    //| TyCase of TypedData * (TypedData * TypedBind []) [] * ConsedTy
    //| TyJoinPoint of JoinPointKey * JoinPointType * TyTag [] * ConsedTy
    //| TySetMutableRecord of TypedData * (Tag * ConsedTy) [] * TyTag []


let binds (env: CodegenEnv) ret x =
    Array.iter (function
        | TyLet(data,_,x) -> op (Some data) x
            
        ) x

let typed_data (x: TypedBind []) =
    let env = CodegenEnv()
    binds env None x