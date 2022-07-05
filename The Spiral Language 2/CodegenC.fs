module Spiral.Codegen.C

open Spiral
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval.Main
open Spiral.CodegenUtils
open System
open System.Text
open System.Collections.Generic

type BindsReturn =
    | BindsTailEnd
    | BindsLocal of TyV []

let cchar = "char"
let cstring = $"{cchar} *" // I'll leave it as this for now. Later when I do ref counting I'll replace it with something else.

let lit = function
    | LitInt8 x -> sprintf "%i" x
    | LitInt16 x -> sprintf "%i" x
    | LitInt32 x -> sprintf "%il" x
    | LitInt64 x -> sprintf "%ill" x
    | LitUInt8 x -> sprintf "%iu" x
    | LitUInt16 x -> sprintf "%iu" x
    | LitUInt32 x -> sprintf "%iul" x
    | LitUInt64 x -> sprintf "%iull" x
    | LitFloat32 x -> 
        if x = infinityf then "HUGE_VALF"
        elif x = -infinityf then "-HUGE_VALF"
        elif Single.IsNaN x then "NAN"
        else x.ToString("R") |> sprintf "%sf"
    | LitFloat64 x ->
        if x = infinity then "HUGE_VAL"
        elif x = -infinity then "-HUGE_VAL"
        elif Double.IsNaN x then "NAN"
        else x.ToString("R") 
    | LitString x ->
        let strb = StringBuilder(x.Length+2)
        strb.Append '"' |> ignore
        String.iter (function
            | '"' -> strb.Append "\\\"" 
            | '\b' -> strb.Append @"\b"
            | '\t' -> strb.Append @"\t"
            | '\n' -> strb.Append @"\n"
            | '\r' -> strb.Append @"\r"
            | '\\' -> strb.Append @"\\"
            | x -> strb.Append x
            >> ignore 
            ) x
        strb.Append '"' |> ignore
        strb.ToString()
    | LitChar x -> 
        match x with
        | '\b' -> @"\b"
        | '\n' -> @"\n"
        | '\t' -> @"\t"
        | '\r' -> @"\r"
        | '\\' -> @"\\"
        | x -> string x
        |> sprintf "'%s'"
    | LitBool x -> if x then "1" else "0"

let term_vars_to_tys x = x |> Array.map (function WV(L(_,t)) -> t | WLit x -> YPrim (lit_to_primitive_type x))

let codegen (env : PartEvalResult) (x : TypedBind []) =
    let types = ResizeArray()
    let functions = ResizeArray()

    let show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
    let tup_destruct (a,b) =
        Array.map2 (fun (L(i,_)) b -> 
            match b with
            | WLit b -> $"v{i} = {lit b};"
            | WV i' -> $"v{i} = v{i'};"
            ) a b |> String.concat " "

    let rec binds (defs : CodegenEnv) (s : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) = 
        Array.iter (function
            | TyLet(d,trace,a) ->
                try let d = data_free_vars d
                    Array.map (fun (L(i,t)) -> $"{tyv t} v{i};") d |> String.concat " " |> line defs
                    op defs s (BindsLocal d) a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a,_) ->
                try op defs s ret a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d,trace) ->
                try match ret with
                    | BindsLocal l -> line s (tup_destruct (l,data_term_vars d))
                    | BindsTailEnd -> line s $"return {tup d};"
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) stmts
    and tup x =
        let x = data_term_vars x
        let args = Array.map show_w x |> String.concat ", " 
        if 1 < args.Length then sprintf "Tuple%i(%s)" ((tup' (term_vars_to_tys x)).tag) args else args
    and tyv = function
        | YUnion a ->
            match a.Item.layout with
            | UHeap -> sprintf "struct * UH%i" (uheap a).tag
            | UStack -> sprintf "struct US%i" (ustack a).tag
        | YLayout(a,Heap) -> sprintf "struct * Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "struct * Mut%i" (mut a).tag
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "struct * Array%i" (carray a).tag
        | YFun(a,b) -> sprintf "struct * Fun%i" (cfun (a,b)).tag
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and prim = function
        | Int8T -> "int8_t"
        | Int16T -> "int16_t"
        | Int32T -> "int32_t"
        | Int64T -> "int64_t"
        | UInt8T -> "uint8_t"
        | UInt16T -> "uint16_t"
        | UInt32T -> "uint32_t"
        | UInt64T -> "uint64_t"
        | Float32T -> "float"
        | Float64T -> "double"
        | BoolT -> "_Bool"
        | StringT -> cstring
        | CharT -> cchar
    and tup_ty x =
        match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
        | [||] -> "void"
        | x -> String.concat ", " x

    let main_defs = StringBuilder()
    let main_s = StringBuilder()
    binds {text=main_defs; indent=0} {text=main_s; indent=0} BindsTailEnd x

    //let program = StringBuilder()
    //types |> Seq.iteri (fun i x -> program.Append(if i = 0 then "type " else "and ").Append(x) |> ignore)
    //functions |> Seq.iteri (fun i x -> program.Append(if i = 0 then "let rec " else "and ").Append(x) |> ignore)
    //program.Append(main).ToString()

    failwith ""