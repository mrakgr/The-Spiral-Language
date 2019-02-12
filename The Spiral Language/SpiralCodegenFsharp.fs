module Spiral.Codegen.Fsharp

open Spiral
open Spiral.Types
open Spiral.PartEval
open System.Collections.Generic
open System.Text
open System

// Globals
let type_dict = Dictionary(HashIdentity.Structural)

type CodegenEnv =
    {
    stmts : StringBuilder
    indent : int
    }

    member x.Statement s =
        x.stmts
            .Append(' ', x.indent)
            .AppendLine s
        |> ignore

    member x.Text s = x.Statement s
    member x.Indent = {x with indent=x.indent+4}
        
let raise_codegen_error x = raise (CodegenError x)

let rec type_ d x = 
    let inline f x = type_ d x
    match x with
    | ListT _  | KeywordT _ | FunctionT _ | RecFunctionT _ | ObjectT _ | MapT _ as x -> 
        match type_non_units x with
        | [||] -> "unit"
        | x -> Array.map f x |> String.concat " * "
    | ArrayT(ArtDotNetReference,t) -> sprintf "(%s ref)" (f t)
    | ArrayT(ArtDotNetHeap,t) -> sprintf "(%s [])" (f t)
    | ArrayT(ArtCudaGlobal t,_) -> f t
    | ArrayT((ArtCudaShared | ArtCudaLocal),_) -> raise_codegen_error "Cuda local and shared arrays cannot be used on the F# side."
    | TermCastedFunctionT(a,b) -> sprintf "(%s -> %s)" (f a) (f b)
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
        match type_dict.TryGetValue ty with // TODO: Do not forget to tag this.
        | false, _ -> let x = type_dict.Count in type_dict.Add(ty,x); x-1
        | true, x -> x
        |> sprintf "SpiralType%i"

let tytag d (T(tag,ty)) = sprintf "(var_%i : %s)" (uint32 tag) (type_ d ty)
let tylit d = function
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

let error_raw_type x = raise_codegen_error <| sprintf "An attempt to manifest a raw type has been attempted.\nGot: %s" (Parsing.show_typed_data x)

let typed_data (d: CodegenEnv) x = 
    match typed_data_term_vars x with
    | true, _ -> error_raw_type x
    | false, vars -> 
        Array.map (function
            | TyV t -> tytag d t
            | TyLit x -> tylit d x
            | _ -> failwith "impossible"
            ) vars
        |> String.concat ", "
        |> sprintf "(%s)"

let join_point (d: CodegenEnv) (key, typ, args) =
    let args = Array.map (tytag d) args |> String.concat ", "
    match typ with
    | JoinPointMethod -> // TODO: Make sure to tag the join points later.
        let tag =
            match PartEval.join_point_dict_method.[key] with // TODO: Do not forget to tag these.
            | JoinPointDone(tag,_,_) -> tag
            | _ -> failwith "impossible"
        sprintf "method_%i(%s)" tag args
    | JoinPointClosure ->
        let tag =
            match PartEval.join_point_dict_closure.[key] with // TODO: Do not forget to tag these.
            | JoinPointDone(tag,_,_,_) -> tag
            | _ -> failwith "impossible"
        sprintf "closure_method_%i(%s)" tag args
    | JoinPointCuda -> 
        ""
    | JoinPointType -> failwith "impossible" 
   
let rec op (d: CodegenEnv) x =
    match x with
    | TyOp(op, x) ->
        let inline t x = typed_data d x
        match op, x with
        // Primitive operations on expressions.
        | Add,TyList [a;b] -> sprintf "(%s + %s)" (t a) (t b)
        | Sub,TyList [a;b] -> sprintf "(%s - %s)" (t a) (t b)
        | Mult,TyList [a;b] -> sprintf "(%s * %s)" (t a) (t b)
        | Div,TyList [a;b] -> sprintf "(%s / %s)" (t a) (t b)
        | Mod,TyList [a;b] -> sprintf "(%s %% %s)" (t a) (t b)
        | Pow,TyList [a;b] -> sprintf "pow(%s, %s)" (t a) (t b)
        | LT,TyList [a;b] -> sprintf "(%s < %s)" (t a) (t b)
        | LTE,TyList [a;b] -> sprintf "(%s <= %s)" (t a) (t b)
        | EQ,TyList [a;b] -> sprintf "(%s == %s)" (t a) (t b)
        | NEQ,TyList [a;b] -> sprintf "(%s != %s)" (t a) (t b)
        | GT,TyList [a;b] -> sprintf "(%s > %s)" (t a) (t b)
        | GTE,TyList [a;b] -> sprintf "(%s >= %s)" (t a) (t b)
        | BitwiseAnd,TyList [a;b] -> sprintf "(%s & %s)" (t a) (t b)
        | BitwiseOr,TyList [a;b] -> sprintf "(%s | %s)" (t a) (t b)
        | BitwiseXor,TyList [a;b] -> sprintf "(%s ^ %s)" (t a) (t b)

        | ShiftLeft,TyList [x;y] -> sprintf "(%s << %s)" (t x) (t y)
        | ShiftRight,TyList[x;y] -> sprintf "(%s >> %s)" (t x) (t y)
                    
        | Neg,a -> sprintf "(-%s)" (t a)
        | Log,x -> sprintf "log(%s)" (t x)
        | Exp,x -> sprintf "exp(%s)" (t x)
        | Tanh,x -> sprintf "tanh(%s)" (t x)
        | Sqrt,x -> sprintf "sqrt(%s)" (t x)
        | NanIs,x -> sprintf "isnan(%s)" (t x)

    | TyIf(cond,on_succ,on_fail) ->
        d.Text(sprintf "if %s then" (typed_data d cond))
        binds d.Indent on_succ
        d.Text("else")
        binds d.Indent on_fail
        null
    | TyWhile(cond,on_succ) ->
        d.Text(sprintf "while %s do" (join_point d cond))
        binds d.Indent on_succ
        null
    | TyCase(var,cases) ->
        d.Text(sprintf "match %s with" (typed_data d var))
        Array.iter (fun (bind,case) ->
            d.Text(sprintf "| %s ->" (typed_data d bind))
            binds d.Indent case
            ) cases
        null
    | TyJoinPoint key -> join_point d key
    | TySetMutableRecord(a,b,c) ->
        let a = typed_data d a
        Array.iter2 (fun (b,_) (T(c,_)) ->
            d.Statement(sprintf "%s.subvar_%i <- var_%i" a b c)
            ) b c
        null
    | TyLayoutToNone x ->
        match x with
        | TyT _ -> error_raw_type x
        | TyV(T(tag,LayoutT(C(_,b,_)))) ->
            consed_typed_free_vars b
            |> Array.map (fun (tag',_) -> sprintf "var_%i.subvar_%i" tag tag')
            |> String.concat ", "
        | _ -> failwith "impossible"

and binds (d: CodegenEnv) x =
    Array.iter (function
        | TyLet(data,_,x) ->
            let vars = typed_data_free_vars data |> Array.map (tytag d) |> String.concat ", "
            match x with
            | TyOp _ -> d.Statement(sprintf "let %s = %s" vars (op d x))
            | _ -> d.Statement(sprintf "let %s =" vars); op d.Indent x |> ignore
        | TyLocalReturnOp(_,x) -> match op d x with | null -> () | x -> d.Statement(x)
        | TyLocalReturnData(x,_) -> d.Statement(typed_data d x)
        ) x

