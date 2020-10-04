module Spiral.CodegenFsharp

open System
open System.Text
open System.Collections.Generic
open Spiral.Utils
open Spiral.Tokenize
open Spiral.Parsing
open Spiral.Prepass
open Spiral.PartEval

type H<'a when 'a: equality>(x : 'a) = 
    let h = hash x

    member _.Item = x
    override a.Equals(b) =
        match b with
        | :? H<'a> as b -> h = hash b && x = b.Item
        | _ -> false
    override a.GetHashCode() = h

type Tagger<'a when 'a : equality>() = 
    let dict = Dictionary<H<'a>, int>(HashIdentity.Structural)
    let queue = Queue<'a * int>()

    member t.Tag ty = memoize dict (fun _ -> let x = dict.Count in queue.Enqueue(ty,x); x) (H ty)
    member t.QueuedCount = queue.Count
    member t.Dequeue = queue.Dequeue()

type CodegenEnv =
    {
    keywords : KeywordEnv
    stmts : StringBuilder
    indent : int
    join_points : Tagger<JoinPointKey>
    types : Tagger<Ty>
    }

    member x.NewDefinition = {x with stmts = StringBuilder()}
    member x.Statement s =
        x.stmts
            .Append(' ', x.indent)
            .AppendLine s
        |> ignore

    member x.Text s = x.Statement s
    member x.Indent = {x with indent=x.indent+4}

exception CodegenError of string
let raise_codegen_error x = raise (CodegenError x)

let lit d = function
    | LitInt8 x -> sprintf "%iy" x
    | LitInt16 x -> sprintf "%is" x
    | LitInt32 x -> sprintf "%i" x
    | LitInt64 x -> sprintf "%iL" x
    | LitUInt8 x -> sprintf "%iuy" x
    | LitUInt16 x -> sprintf "%ius" x
    | LitUInt32 x -> sprintf "%iu" x
    | LitUInt64 x -> sprintf "%iUL" x
    | LitFloat32 x -> 
        if x = infinityf then "infinityf"
        elif x = -infinityf then "-infinityf"
        elif Single.IsNaN x then "nanf"
        else sprintf "%ff" x
    | LitFloat64 x ->
        if x = infinity then "infinity"
        elif x = -infinity then "-infinity"
        elif Double.IsNaN x then "nan"
        else sprintf "%f" x
    | LitString x -> 
        let strb = StringBuilder(x.Length)
        strb.Append '"' |> ignore
        String.iter (function
            | '"' -> strb.Append "\\\"" 
            | '\t' -> strb.Append "\\t"
            | '\n' -> strb.Append "\\n"
            | '\r' -> strb.Append "\\r"
            | '\\' -> strb.Append "\\\\"
            | x -> strb.Append x
            >> ignore 
            ) x
        strb.Append '"' |> ignore
        strb.ToString()
    | LitChar x -> 
        match x with
        | '\n' -> @"\n"
        | '\t' -> @"\t"
        | '\r' -> @"\r"
        | x -> string x
        |> sprintf "'%s'"
    | LitBool x -> if x then "true" else "false"

let rec type' (d: CodegenEnv) x = 
    let inline f x = type' d x
    ty_vars x
    |> Array.map (function
        | ArrayT t -> sprintf "(%s [])" (f t)
        | RuntimeFunctionT(a,b) -> sprintf "(%s -> %s)" (f a) (f b)
        | YPrim x ->
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
        | MacroT x -> failwith "Compiler error: Macros not implemented yet." // TODO
        | RJPT _ & ty -> d.types.Tag ty |> sprintf "SpiralType%i"
        | ty -> raise_codegen_error <| sprintf "Compiler error: %s not supported in type_" (show_ty d.keywords ty)
        )
    |> function
        | [||] -> "unit"
        | x -> String.concat " * " x

let tytag d (T(tag,ty)) = sprintf "(var_%i : %s)" (uint32 tag) (type' d ty)
let tytag' d (T(tag,ty)) = sprintf "var_%i" (uint32 tag)
let tytags_semicolon d x = Array.map (tytag' d) x |> String.concat "; "
let tytags_comma' d x = Array.map (tytag' d) x |> String.concat ", " |> sprintf "(%s)"
let tytags_comma d x = Array.map (tytag d) x |> String.concat ", " |> sprintf "(%s)"
let error_raw_type d x = raise_codegen_error <| sprintf "An attempt to manifest a raw type has been made.\nGot: %s" (show_typed_data d.keywords x)

let rec data (d: CodegenEnv) x = 
    data_term_vars x 
    |> Array.map (function
        | TyV t -> tytag' d t
        | DLit x -> lit d x
        | _ -> failwith "impossible"
        )
    |> function
        | [|x|] -> x
        | x -> String.concat ", " x |> sprintf "(%s)"

let join_point (d: CodegenEnv) (key, args) =
    let tag = d.join_points.Tag key
    sprintf "method_%i %s" tag (tytags_comma' d args)

exception CodegenErrorWithPos of Trace * string

let rec op (d: CodegenEnv) x =
    match x with
    | TyOp(op, x') ->
        let inline t x = data d x
        match op, x' with
        | UnsafeConvert, [|a;b|] -> sprintf "%s %s" (type' d (data_to_ty a)) (t b)
        | StringLength, [|a|] -> sprintf "int64 %s.Length" (t a)
        | StringIndex, [|a;b|] -> sprintf "%s.[int32 %s]" (t a) (t b)
        | StringSlice, [|a;b;c|] -> sprintf "%s.[int32 %s..int32 %s]" (t a) (t b) (t c)
        | Apply, [|a;b|] -> sprintf "%s%s" (t a) (t b)
        | ArrayCreate, [|a;b|] -> sprintf "Array.zeroCreate (System.Convert.ToInt32 %s)" (t b)
        | GetArray, [|a;b|] -> sprintf "%s.[int32 %s]" (t a) (t b)
        | SetArray, [|a;b;c|] -> sprintf "%s.[int32 %s] <- %s" (t a) (t b) (t c) 
        | ArrayLength, [|a|] -> sprintf "%s.LongLength" (t a)
        | Dynamize, [|a|] -> t a
        | FailWith, [|a|] -> sprintf "failwith %s" (t a)
        | RJPToStack, [|b;a|] ->
            match data_free_vars b with
            | [||] -> "() // unit stack layout type"
            | free_vars ->
                let tag = d.types.Tag (data_to_ty a)
                let b = tytags_comma' d free_vars
                sprintf "SpiralType%i %s" tag b
        | RJPToHeap,[|b;a|] ->
            match data_free_vars b with
            | [||] -> "() // unit heap layout type"
            | free_vars ->
                free_vars
                |> Array.mapi (fun i x -> sprintf "subvar_%i = %s" i (tytag' d x))
                |> String.concat "; "
                |> sprintf "{%s}"
        | RJPToNone,[|b|] ->
            match b with
            | TyV(T(tag,RJPT(_,b))) ->
                rdata_free_vars b
                |> Array.map (fun (tag',_) -> sprintf "var_%i.subvar_%i" tag tag')
                |> String.concat ", "
            | _ -> failwith "impossible"

        // Primitive operations on expressions.
        | Add, [|a;b|] -> sprintf "%s + %s" (t a) (t b)
        | Sub, [|a;b|] -> sprintf "%s - %s" (t a) (t b)
        | Mult, [|a;b|] -> sprintf "%s * %s" (t a) (t b)
        | Div, [|a;b|] -> sprintf "%s / %s" (t a) (t b)
        | Mod, [|a;b|] -> sprintf "%s %% %s" (t a) (t b)
        | Pow, [|a;b|] -> sprintf "pow(%s, %s)" (t a) (t b)
        | LT, [|a;b|] -> sprintf "%s < %s" (t a) (t b)
        | LTE, [|a;b|] -> sprintf "%s <= %s" (t a) (t b)
        | EQ, [|a;b|] -> sprintf "%s = %s" (t a) (t b)
        | NEQ, [|a;b|] -> sprintf "%s != %s" (t a) (t b)
        | GT, [|a;b|] -> sprintf "%s > %s" (t a) (t b)
        | GTE, [|a;b|] -> sprintf "%s >= %s" (t a) (t b)
        | BoolAnd, [|a;b|] -> sprintf "%s && %s" (t a) (t b)
        | BoolOr, [|a;b|] -> sprintf "%s || %s" (t a) (t b)
        | BitwiseAnd, [|a;b|] -> sprintf "%s & %s" (t a) (t b)
        | BitwiseOr, [|a;b|] -> sprintf "%s | %s" (t a) (t b)
        | BitwiseXor, [|a;b|] -> sprintf "%s ^ %s" (t a) (t b)

        | ShiftLeft, [|a;b|] -> sprintf "%s << %s" (t a) (t b)
        | ShiftRight, [|a;b|] -> sprintf "%s >> %s" (t a) (t b)
                    
        | Neg, [|x|] -> sprintf " -%s" (t x)
        | Log, [|x|] -> sprintf "log%s" (t x)
        | Exp, [|x|] -> sprintf "exp%s" (t x)
        | Tanh, [|x|] -> sprintf "tanh%s" (t x)
        | Sqrt, [|x|] -> sprintf "sqrt%s" (t x)
        | IsNan, [|x|] -> sprintf "isnan%s" (t x)
        | a, b -> raise_codegen_error <| sprintf "Compiler error: Case %A with data %A not implemented." a (Array.map (show_typed_data d.keywords) b)
    | TyIf(cond,on_succ,on_fail) ->
        d.Text(sprintf "if %s then" (data d cond))
        binds d.Indent on_succ
        d.Text("else")
        binds d.Indent on_fail
        null
    | TyWhile(cond,on_succ) ->
        d.Text(sprintf "while %s do" (join_point d cond))
        binds d.Indent on_succ
        null
    | TyJoinPoint key -> join_point d key

and binds (d: CodegenEnv) x =
    Array.iter (function
        | TyLet(a,trace,x) ->
            try 
                let vars = data_free_vars a |> tytags_comma d
                match x with
                | TyJoinPoint _ | TyOp _ -> d.Statement(sprintf "let %s = %s" vars (op d x))
                | _ -> d.Statement(sprintf "let %s =" vars); op d.Indent x |> ignore
            with :? CodegenError as x -> raise (CodegenErrorWithPos(trace,x.Data0))
        | TyLocalReturnOp(trace,x) -> 
            try match op d x with null -> () | x -> d.Statement(x)
            with :? CodegenError as x -> raise (CodegenErrorWithPos(trace,x.Data0))
        | TyLocalReturnData(x,trace) -> 
            try d.Statement(data d x)
            with :? CodegenError as x -> raise (CodegenErrorWithPos(trace,x.Data0))
        ) x


let codegen (dex : ExternalLangEnv) x =
    let def_main = {
        keywords = dex.keywords
        stmts = StringBuilder()
        indent = 0
        join_points = Tagger()
        types = Tagger()
        }
    let def_types = def_main.NewDefinition
    let def_join_points = def_main.NewDefinition

    binds def_main x

    let inline print_types is_first =
        let d = def_types
        let ty, tag' = d.types.Dequeue
        let intro() =
            if is_first then d.Statement(sprintf "type SpiralType%i =" tag')
            else d.Statement(sprintf "and SpiralType%i =" tag')
            d.Indent
        let rec f = function
            | RJPT(lay,ty) ->
                let d = intro()
                match lay with
                | RJPStack ->
                    d.Text "struct"
                    let vars = rdata_free_vars ty
                    Array.iter (fun (t,ty) -> d.Text(sprintf "val subvar_%i : %s" t (type' d ty))) vars
                    d.Text "end"
                    let a = Array.map (fun (t,_) -> sprintf "v_%i" t) vars |> String.concat ", "
                    let b = Array.map (fun (t,_) -> sprintf "subvar_%i=v_%i" t t) vars |> String.concat "; "
                    d.Text(sprintf "new (%s) = {%s}" a b)
                | RJPHeap ->
                    d.Text "{"
                    let vars = rdata_free_vars ty
                    Array.iter (fun (t,ty) -> d.Text(sprintf "subvar_%i : %s" t (type' d ty))) vars
                    d.Text "}"
            | _ -> ()
        f ty
            
    let inline print_join_points is_first =
        let d = def_join_points
        let key, tag' = d.join_points.Dequeue

        match key with
        | JPMethod(expr,key) ->
            match dex.join_point_method.[expr].[key] with
            | Some(args,body,ret_ty) ->
                let args = tytags_comma d args
                let ret_ty = type' d ret_ty
                if is_first then d.Statement(sprintf "let rec method_%i %s : %s =" tag' args ret_ty)
                else d.Statement(sprintf "and method_%i %s : %s =" tag' args ret_ty)
                let d = d.Indent
                binds d body
            | None -> raise_codegen_error "Compiler error: Cannot print an unfinished join point."
        | JPClosure(expr,key) ->
            raise_codegen_error "JPClosure not implemented yet." // TODO

    let rec loop is_first_method is_first_type =
        let d = def_main
        if d.join_points.QueuedCount > 0 then print_join_points is_first_method; loop false is_first_type
        elif d.types.QueuedCount > 0 then print_types is_first_type; loop is_first_method false
        else ()

    loop true true

    def_types.stmts
        .Append(def_join_points.stmts)
        .Append(def_main.stmts)
        .ToString()


