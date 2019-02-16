module Spiral.Show
open Parsing
open Types
open System.Collections.Generic
open System

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
    | LayoutHeap -> "layout_heap"
    | LayoutHeapMutable -> "layout_heap_mutable"

let inline show_keyword show (keyword,l: _[]) =
    if l.Length > 0 then
        let a = (keyword_to_string keyword).Split([|':'|], StringSplitOptions.RemoveEmptyEntries)
        Array.map2 (fun a l -> String.concat "" [|a;": ";show l|]) a l
        |> String.concat " "
    else
        keyword_to_string keyword

let inline show_map show v = 
    let body = 
        Map.toArray v
        |> Array.map (fun (k,v) -> sprintf "%s=%s" (keyword_to_string k) (show v))
        |> String.concat "; "

    sprintf "{%s}" body

let inline show_list show l = sprintf "(%s)" (List.map show l |> String.concat ", ")

let rec show_ty = function
    | PrimT x -> show_primt x
    | KeywordT(C(keyword,l)) -> show_keyword show_ty (keyword,l)
    | ListT l -> show_list show_ty l.node
    | MapT v -> show_map show_ty v.node
    | ObjectT _ -> "<object>"
    | FunctionT _ | RecFunctionT _ -> "<function>"
    | LayoutT (C(layout_type,body,_)) ->
        sprintf "%s (%s)" (show_layout_type layout_type) (show_consed_typed_data body)
    | TermCastedFunctionT (a,b) ->
        sprintf "(%s => %s)" (show_ty a) (show_ty b)
    | UnionT l ->
        let body =
            Set.toArray l.node
            |> Array.map show_ty
            |> String.concat " | "
        sprintf "union {%s}" body
    | RecUnionT (name, _) -> name
    | ArrayT (a,b) -> sprintf "%s (%s)" (show_art a) (show_ty b)
    | MacroT x -> x

and show_typed_data = function
    | TyT x -> sprintf "type (%s)" (show_ty x)
    | TyV(T(_,t)) -> sprintf "var (%s)" (show_ty t)
    | TyKeyword(keyword,l) -> show_keyword show_typed_data (keyword,l)
    | TyList l -> show_list show_typed_data l
    | TyMap a -> show_map show_typed_data a
    | TyObject _ -> "<object>"
    | TyFunction _ | TyRecFunction _ -> "<function>"
    | TyBox(a,b) -> sprintf "(%s : %s)" (show_typed_data a) (show_ty b)
    | TyLit v -> sprintf "lit %s" (show_value v)

and show_consed_typed_data = function
    | CTyT x -> sprintf "type (%s)" (show_ty x)
    | CTyV(_,t) -> sprintf "var (%s)" (show_ty t)
    | CTyKeyword(C(keyword,l)) -> show_keyword show_consed_typed_data (keyword,l)
    | CTyList l -> show_list show_consed_typed_data l.node
    | CTyMap a -> show_map show_consed_typed_data a.node
    | CTyObject _ -> "<object>"
    | CTyFunction _ | CTyRecFunction _ -> "<function>"
    | CTyBox(a,b) -> sprintf "(%s : %s)" (show_consed_typed_data a) (show_ty b)
    | CTyLit v -> sprintf "lit %s" (show_value v)
