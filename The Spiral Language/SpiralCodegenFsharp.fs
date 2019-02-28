module Spiral.Codegen.Fsharp

open Spiral
open Spiral.Types
open Spiral.Show
open Spiral.PartEval
open System.Collections.Generic
open System.Text
open System

type Tagger<'a when 'a : equality>() =
    let dict = Dictionary<'a, int>()
    let queue = Queue<'a * int>()

    member t.Tag ty =
        match dict.TryGetValue ty with
        | false, _ -> let x = dict.Count in queue.Enqueue(ty,x); dict.Add(ty,x); x
        | true, x -> x

    member t.QueuedCount = queue.Count
    member t.Dequeue = queue.Dequeue()

type CodegenEnv =
    {
    stmts : StringBuilder
    indent : int
    join_points : Tagger<JoinPointKey * JoinPointType>
    types : Tagger<ConsedTy>
    }

    member x.NewDefinition = {x with stmts = StringBuilder()}
    member x.Statement s =
        x.stmts
            .Append(' ', x.indent)
            .AppendLine s
        |> ignore

    member x.Text s = x.Statement s
    member x.Indent = {x with indent=x.indent+4}

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

let rec type_ (d: CodegenEnv) x = 
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
    | MacroT x -> 
        let f keyword l = 
            if keyword = keyword_text then
                match l with
                | CTyLit (LitString x) -> x
                | x -> raise_codegen_error <| sprintf "Expected a string literal in type macro's keyword `text:`.\nGot: %s" (show_consed_typed_data x)
            elif keyword = keyword_literal then
                match l with
                | CTyLit x -> lit d x
                | x -> raise_codegen_error <| sprintf "Expected a literal in type macro's keyword `literal:`.\nGot: %s" (show_consed_typed_data x)
            elif keyword = keyword_type then f (type_consed_data_get l)
            else raise_codegen_error <| sprintf "Invalid keyword in type macro. Expected `text:`, `literal:` or `type:`.\nGot: `%s`" (keyword_to_string keyword)

        let strb = StringBuilder()
        let rec loop = function
            | CTyKeyword(C(keyword,[|l|])) -> f keyword l |> strb.Append |> ignore
            | CTyList(C l) -> List.iter loop l
            | x -> raise_codegen_error <| sprintf "Expected a tuple, or a `text:`, `literal:` or `type:` keyword argument in type macro. Got: `%s`" (show_consed_typed_data x)
        loop x
        strb.ToString()
    | ty -> d.types.Tag ty |> sprintf "SpiralType%i"

let tytag d (T(tag,ty)) = sprintf "(var_%i : %s)" (uint32 tag) (type_ d ty)
let tytag' d (T(tag,ty)) = sprintf "var_%i" (uint32 tag)
let tytags_semicolon d x = Array.map (tytag' d) x |> String.concat "; "
let tytags_comma' d x = Array.map (tytag' d) x |> String.concat ", " |> sprintf "(%s)"
let tytags_comma d x = Array.map (tytag d) x |> String.concat ", " |> sprintf "(%s)"
let error_raw_type x = raise_codegen_error <| sprintf "An attempt to manifest a raw type has been made.\nGot: %s" (show_typed_data x)

let rec typed_data (d: CodegenEnv) x = 
    match typed_data_term_vars x with
    | true, _ -> error_raw_type x
    | false, vars -> 
        Array.map (function
            | TyV t -> tytag' d t
            | TyLit x -> lit d x
            | TyBox(a,ty) -> 
                let tag' = d.types.Tag ty
                let tag = d.types.Tag (type_get a)
                match typed_data d a with
                | "()" -> sprintf "SpiralType%i_%i" tag' tag
                | x -> sprintf "SpiralType%i_%i %s" tag' tag x
            | _ -> failwith "impossible"
            ) vars
        |> function
            | [|x|] -> x
            | x -> String.concat ", " x |> sprintf "(%s)"

let join_point (d: CodegenEnv) (key, typ, args) =
    let tag = d.join_points.Tag (key,typ)
    match typ with
    | JoinPointMethod -> sprintf "method_%i %s" tag (tytags_comma' d args)
    | JoinPointClosure -> sprintf "closure_method_%i %s" tag (tytags_comma' d args)
    | JoinPointCuda -> sprintf "\"cuda_method_%i\", ([|%s|] : System.Object)" tag (tytags_semicolon d args)
    | JoinPointType -> failwith "impossible"

let heap_layout d free_vars =
    let b = 
        free_vars
        |> Array.mapi (fun i x -> sprintf "subvar_%i = %s" i (tytag' d x))
        |> String.concat "; "
    sprintf "{%s}" b
   
let rec op (d: CodegenEnv) x =
    match x with
    | TyOp(op, x') ->
        let inline t x = typed_data d x
        match op, x' with
        | Macro, a ->
            let f keyword l = 
                if keyword = keyword_text then
                    match l with
                    | TyLit (LitString x) -> x
                    | x -> raise_codegen_error <| sprintf "Expected a string literal in term macro's keyword `text:`.\nGot: %s" (show_typed_data x)
                elif keyword = keyword_literal then
                    match l with
                    | TyLit x -> lit d x
                    | x -> raise_codegen_error <| sprintf "Expected a literal in term macro's keyword `literal:`.\nGot: %s" (show_typed_data x)
                elif keyword = keyword_type then type_ d (type_get l)
                elif keyword = keyword_variable then t l
                else raise_codegen_error <| sprintf "Invalid keyword in term macro. Expected `text:`, `literal:`, `type:` or `variable:`.\nGot: `%s`" (keyword_to_string keyword)
            
            let strb = StringBuilder()
            let rec loop = function
                | TyKeyword(keyword,[|l|]) -> f keyword l |> strb.Append |> ignore
                | TyList l -> List.iter loop l
                | x -> raise_codegen_error <| sprintf "Expected a tuple, or a `text:`, `literal:`, `type:` or `variable:` keyword argument in term macro. Got: `%s`" (show_typed_data x)
            loop a
            strb.ToString()
        | UnsafeConvert, TyList [a;b] -> sprintf "%s %s" (type_ d (type_get a)) (t b)
        | StringLength, a -> sprintf "int64 %s.Length" (t a)
        | StringIndex, TyList [a;b] -> sprintf "%s.[int32 %s]" (t a) (t b)
        | StringSlice, TyList [a;b;c] -> sprintf "%s.[int32 %s..int32 %s]" (t a) (t b) (t c)
        | StringFormat, TyList (format :: l) -> 
            match l with
            | [a;b;c] -> sprintf "System.String.Format(%s,%s,%s,%s)" (t format) (t a) (t b) (t c)
            | [a;b] -> sprintf "System.String.Format(%s,%s,%s)" (t format) (t a) (t b)
            | [a] -> sprintf "System.String.Format(%s,%s)" (t format) (t a)
            | [] -> sprintf "System.String.Format(%s)" (t format)
            | l -> 
                let l = List.map (t) l |> String.concat "; "
                sprintf "System.String.Format(%s,([|%s|] : obj[]))" (t format) l 
        | StringConcat, TyList (sep :: l) ->
            let l = List.map (t) l |> String.concat "; "
            sprintf "String.concat %s [|%s|]" (t sep) l 
        | Apply, TyList [a;b] -> sprintf "%s%s" (t a) (t b)
        | LayoutToStack, TyList [a;b] ->
            match typed_data_free_vars b with
            | [||] -> "() // unit stack layout type"
            | free_vars -> 
                let tag = d.types.Tag (type_get a)
                let b = tytags_comma' d free_vars
                sprintf "SpiralType%i %s" tag b
        | LayoutToHeap, TyList [a;b] -> 
            match typed_data_free_vars b with
            | [||] -> "() // unit heap layout type"
            | free_vars -> heap_layout d free_vars
        | LayoutToHeapMutable, TyList [a;b] -> 
            match typed_data_free_vars b with
            | [||] -> "() // unit mutable heap layout type"
            | free_vars -> heap_layout d free_vars
        | SizeOf, a -> sprintf "sizeof<%s>" (type_ d (type_get a))
        | (ArrayCreateCudaLocal | ArrayCreateCudaShared), _ -> raise_codegen_error "Cuda arrays are not allowed on the F# side."
        | ArrayCreateDotNet, TyList [a;b] -> if typed_data_is_unit a then "() // unit array create" else sprintf "Array.zeroCreate (System.Convert.ToInt32 %s)" (t b)
        | ReferenceCreate, a -> if typed_data_is_unit a then "() // unit ref create" else sprintf "ref %s" (t a)
        | GetArray, TyList [a;b] -> if typed_data_is_unit a then "() // get from unit array" else sprintf "%s.[int32 %s]" (t a) (t b)
        | GetReference, a -> if typed_data_is_unit a then "() // get from unit reference" else sprintf "!%s" (t a) 
        | SetArray, TyList [a;b;c] -> if typed_data_is_unit a then "() // set to unit array" else sprintf "%s.[int32 %s] <- %s" (t a) (t b) (t c) 
        | SetReference, TyList [a;b] -> if typed_data_is_unit a then "() // set to unit reference" else sprintf "%s := %s" (t a) (t b) 
        | ArrayLength, a -> sprintf "%s.LongLength" (t a)
        | Dynamize, a -> t a
        | FailWith, a -> sprintf "failwith %s" (t a)

        // Primitive operations on expressions.
        | Add,TyList [a;b] -> sprintf "%s + %s" (t a) (t b)
        | Sub,TyList [a;b] -> sprintf "%s - %s" (t a) (t b)
        | Mult,TyList [a;b] -> sprintf "%s * %s" (t a) (t b)
        | Div,TyList [a;b] -> sprintf "%s / %s" (t a) (t b)
        | Mod,TyList [a;b] -> sprintf "%s %% %s" (t a) (t b)
        | Pow,TyList [a;b] -> sprintf "pow(%s, %s)" (t a) (t b)
        | LT,TyList [a;b] -> sprintf "%s < %s" (t a) (t b)
        | LTE,TyList [a;b] -> sprintf "%s <= %s" (t a) (t b)
        | EQ,TyList [a;b] -> sprintf "%s = %s" (t a) (t b)
        | NEQ,TyList [a;b] -> sprintf "%s != %s" (t a) (t b)
        | GT,TyList [a;b] -> sprintf "%s > %s" (t a) (t b)
        | GTE,TyList [a;b] -> sprintf "%s >= %s" (t a) (t b)
        | BoolAnd,TyList [a;b] -> sprintf "%s && %s" (t a) (t b)
        | BoolOr,TyList [a;b] -> sprintf "%s || %s" (t a) (t b)
        | BitwiseAnd,TyList [a;b] -> sprintf "%s & %s" (t a) (t b)
        | BitwiseOr,TyList [a;b] -> sprintf "%s | %s" (t a) (t b)
        | BitwiseXor,TyList [a;b] -> sprintf "%s ^ %s" (t a) (t b)

        | ShiftLeft,TyList [x;y] -> sprintf "%s << %s" (t x) (t y)
        | ShiftRight,TyList[x;y] -> sprintf "%s >> %s" (t x) (t y)
                    
        | Neg,a -> sprintf " -%s" (t a)
        | Log,x -> sprintf "log%s" (t x)
        | Exp,x -> sprintf "exp%s" (t x)
        | Tanh,x -> sprintf "tanh%s" (t x)
        | Sqrt,x -> sprintf "sqrt%s" (t x)
        | IsNan,x -> sprintf "isnan%s" (t x)
        | a, b -> raise_codegen_error <| sprintf "Compiler error: Case %A with data %s not implemented." a (show_typed_data b)

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
            let tag', tag = d.types.Tag (type_get var), d.types.Tag (type_get bind)
            match typed_data d bind with
            | "()" -> d.Text(sprintf "| SpiralType%i_%i ->" tag' tag)
            | x -> d.Text(sprintf "| SpiralType%i_%i %s ->" tag' tag x)
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
        | TyLet(data,trace,x) ->
            try 
                let vars = typed_data_free_vars data |> tytags_comma d
                match x with
                | TyJoinPoint _ | TyLayoutToNone _ | TyOp _ -> d.Statement(sprintf "let %s = %s" vars (op d x))
                | _ -> d.Statement(sprintf "let %s =" vars); op d.Indent x |> ignore
            with :? CodegenError as x -> raise (CodegenErrorWithPos(trace,x.Data0))
        | TyLocalReturnOp(trace,x) -> 
            try match op d x with null -> () | x -> d.Statement(x)
            with :? CodegenError as x -> raise (CodegenErrorWithPos(trace,x.Data0))
        | TyLocalReturnData(x,trace) -> 
            try d.Statement(typed_data d x)
            with :? CodegenError as x -> raise (CodegenErrorWithPos(trace,x.Data0))
        ) x


let codegen x =
    let def_main = {
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
            | LayoutT(C(lay,ty,_)) ->
                let d = intro()
                match lay with
                | LayoutStack ->
                    d.Text "struct"
                    let vars = consed_typed_free_vars ty
                    Array.iter (fun (t,ty) -> d.Text(sprintf "val subvar_%i : %s" t (type_ d ty))) vars
                    d.Text "end"
                    let a = Array.map (fun (t,_) -> sprintf "v_%i" t) vars |> String.concat ", "
                    let b = Array.map (fun (t,_) -> sprintf "subvar_%i=v_%i" t t) vars |> String.concat "; "
                    d.Text(sprintf "new (%s) = {%s}" a b)
                | LayoutHeap ->
                    d.Text "{"
                    let vars = consed_typed_free_vars ty
                    Array.iter (fun (t,ty) -> d.Text(sprintf "subvar_%i : %s" t (type_ d ty))) vars
                    d.Text "}"
                | LayoutHeapMutable ->
                    d.Text "{"
                    let vars = consed_typed_free_vars ty
                    Array.iter (fun (t,ty) -> d.Text(sprintf "mutable subvar_%i : %s" t (type_ d ty))) vars
                    d.Text "}"
            | RecUnionT(n,_,key) -> 
                d.Text(sprintf "// %s" n)
                match join_point_dict_type.[key] with
                | JoinPointDone(_,l) -> f l
                | JoinPointInEvaluation _ -> raise_codegen_error "Compiler error: Unfinished type join point."
            | UnionT(C l) ->
                let d = intro()
                Set.iter (fun x ->
                    let tag = d.types.Tag x
                    match type_ d x with
                    | "unit" -> d.Text(sprintf "| SpiralType%i_%i" tag' tag)
                    | l -> d.Text(sprintf "| SpiralType%i_%i of %s" tag' tag l)
                    ) l
            | _ -> ()
        f ty
            
    let inline print_join_points is_first =
        let d = def_join_points
        let (key,ty), tag' = d.join_points.Dequeue

        match ty with
        | JoinPointMethod ->
            match join_point_dict_method.[key] with
            | JoinPointDone(args,(body,ret_ty)) ->
                let args = tytags_comma d args
                let ret_ty = type_ d ret_ty
                if is_first then d.Statement(sprintf "let rec method_%i %s : %s =" tag' args ret_ty)
                else d.Statement(sprintf "and method_%i %s : %s =" tag' args ret_ty)
                let d = d.Indent
                binds d body
            | JoinPointInEvaluation _ -> raise_codegen_error "Compiler error: Cannot print an unfinished join point."
        | JoinPointClosure ->
            match join_point_dict_closure.[key] with
            | JoinPointDone(args,args2,(body,ret_ty)) ->
                let args = tytags_comma d args
                let args2 = tytags_comma d args2
                let ret_ty = type_ d ret_ty
                if is_first then d.Statement(sprintf "let rec closure_method_%i %s %s : %s =" tag' args args2 ret_ty)
                else d.Statement(sprintf "and closure_method_%i %s %s : %s =" tag' args args2 ret_ty)
                let d = d.Indent
                binds d body
            | JoinPointInEvaluation _ -> raise_codegen_error "Compiler error: Cannot print an unfinished join point."
        | JoinPointCuda -> raise_codegen_error "Compiler error: Not supported yet."
        | JoinPointType -> raise_codegen_error "Compiler error: Not supposed to exist on the term level."

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
