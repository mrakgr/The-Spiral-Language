﻿module Spiral.Codegen.Cuda.Cpp

open Spiral
open Spiral.Utils
open Spiral.Tokenize
open Spiral.Startup
open Spiral.BlockParsing
open Spiral.PartEval.Main
open Spiral.CodegenUtils
open System
open System.Text
open System.Collections.Generic

let is_string = function DV(L(_,YPrim StringT)) | DLit(LitString _) -> true | _ -> false
// The number of bits needed to represent an union type with an x number of cases.
// Strictly speaking it should be x * 2 - 1, but we do it like this to give 1 bit of extra wiggle room for the 2,4,8,16 (pow of 2) cases
// because of how TyUnionUnbox is being compiled. For those particular cases we need to have the -1 to have an extra bit of information.
// Note: This was how it was compiled in the HLS backend, but in the Cuda C++ one the tag field should get padded up to its full value either way.
let num_bits_needed_to_represent (x : int) = Numerics.BitOperations.Log2(x * 2 |> uint) |> max 1

let sizeof_tyv = function
    | YPrim (Int64T | UInt64T | Float64T) -> 64
    | YPrim (Int32T | UInt32T | Float32T) -> 32
    | YPrim (Int16T | UInt16T) -> 16
    | YPrim (Int8T | UInt8T | CharT | BoolT) -> 8
    | _ -> 64
let order_args v = v |> Array.sortWith (fun (L(_,t)) (L(_,t')) -> compare (sizeof_tyv t') (sizeof_tyv t))
let line x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore
let line' x s = line x (String.concat " " s)

type BindsReturn =
    | BindsTailEnd
    | BindsLocal of TyV []

let term_vars_to_tys x = x |> Array.map (function WV(L(_,t)) -> t | WLit x -> YPrim (lit_to_primitive_type x))
let binds_last_data x = x |> Array.last |> function TyLocalReturnData(x,_) | TyLocalReturnOp(_,_,x) -> x | TyLet _ -> raise_codegen_error "Compiler error: Cannot find the return data of the last bind."

type UnionRec = {tag : int; free_vars : Map<string, TyV[]>}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]; name : string option}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : Ty []}
type CFunRec = {tag : int; domain : Ty; range : Ty}

let size_t = UInt32T

// Replaces the invalid symbols in Spiral method names for the C backend.
let fix_method_name (x : string) = x.Replace(''','_') + "_"

let lit_string x =
    let strb = StringBuilder(String.length x + 2)
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

let codegen' (env : PartEvalResult) (x : TypedBind []) =
    let globals = ResizeArray()
    let fwd_dcls = ResizeArray()
    let types = ResizeArray()
    let functions = ResizeArray()

    let print show r =
        let s_typ_fwd = {text=StringBuilder(); indent=0}
        let s_typ = {text=StringBuilder(); indent=0}
        let s_fun = {text=StringBuilder(); indent=0}
        show s_typ_fwd s_typ s_fun r
        let f (a : _ ResizeArray) (b : CodegenEnv) = 
            let text = b.text.ToString()
            if text <> "" then a.Add(text)
        f fwd_dcls s_typ_fwd
        f types s_typ
        f functions s_fun

    let union show =
        let dict = Dictionary(HashIdentity.Reference)
        let f (a : Union) : UnionRec = 
            let free_vars = a.Item.cases |> Map.map (fun _ -> env.ty_to_data >> data_free_vars)
            {free_vars=free_vars; tag=dict.Count}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let jp f show =
        let dict = Dictionary(HashIdentity.Structural)
        let f x = f (x, dict.Count)
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let tuple show =
        let dict = Dictionary(HashIdentity.Structural)
        let f x = {tag=dict.Count; tys=x}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let cfun' show =
        let dict = Dictionary(HashIdentity.Structural)
        let f (a : Ty, b : Ty) = {tag=dict.Count; domain=a; range=b}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "

    let tmp =
        let mutable i = 0u
        fun () -> let x = i in i <- i + 1u; x

    let global' =
        let has_added = HashSet()
        fun x -> if has_added.Add(x) then globals.Add x

    let import x = global' $"#include <{x}>"
    let import' x = global' $"#include \"{x}\""

    let tyvs_to_tys (x : TyV []) = Array.map (fun (L(i,t)) -> t) x

    let rec binds_start (s : CodegenEnv) (x : TypedBind []) = binds s BindsTailEnd x
    and return_local s ret (x : string) = 
        match ret with
        | [||] -> line s $"{x};"
        | [|L(i,_)|] -> line s $"v{i} = {x};"
        | ret ->
            let tmp_i = tmp()
            line s $"{tup_ty_tyvs ret} tmp{tmp_i} = {x};"
            Array.mapi (fun i (L(i',_)) -> $"v{i'} = tmp{tmp_i}.v{i};") ret |> line' s
    and binds (s : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) = 
        let tup_destruct (a,b) =
            Array.map2 (fun (L(i,_)) b -> 
                match b with
                | WLit b -> $"v{i} = {lit b};"
                | WV (L(i',_)) -> $"v{i} = v{i'};"
                ) a b
        Array.forall (fun x ->
            match x with
            | TyLet(d,trace,a) ->
                try let d = data_free_vars d
                    let decl_vars = Array.map (fun (L(i,t)) -> $"{tyv t} v{i};") d
                    match a with
                    | TyMacro a ->
                        let m = a |> List.map (function CMText x -> x | CMTerm x -> tup_data x | CMType x -> tup_ty x | CMTypeLit x -> type_lit x) |> String.concat ""
                        if m.StartsWith("#pragma") then 
                            line s m
                            true
                        elif m = "break" then
                            line s "break;"
                            false
                        elif m.StartsWith("return") then
                            line s $"{m};"
                            false
                        else
                            let q = m.Split("v$")
                            if q.Length = 1 then 
                                decl_vars |> line' s
                                return_local s d m 
                                true
                            else
                                if d.Length = q.Length-1 then
                                    let w = StringBuilder(m.Length+8)
                                    let tag (L(i,_)) = i : int
                                    Array.iteri (fun i v -> w.Append(q.[i]).Append('v').Append(tag v) |> ignore) d
                                    w.Append(q.[d.Length]).Append(';').ToString() |> line s
                                    true
                                else
                                    raise_codegen_error "The special v$ macro requires the same number of free vars in its binding as there are v$ in the code."
                    | TyArrayLiteral(a,b') -> 
                        let inits = List.map tup_data b' |> String.concat "," |> sprintf "{%s}"
                        match d with
                        | [|L(i,YArray t)|] -> // For the regular arrays.
                            line s $"%s{tyv t} v{i}[] = %s{inits};"
                            true
                        //| [|L(i,t)|] -> // TODO: For overloaded arrays. Structs with a single field that are arrays can be initialized like this in C++.
                        //    line s $"%s{tyv t} v{i} = %s{inits};"
                        | _ ->
                            raise_codegen_error "Compiler error: Expected a single variable on the left side of an array literal op."
                    | TyArrayCreate(a,b) ->  
                        match d with
                        | [|L(i,YArray t)|] -> 
                            let size =
                                match b with
                                | DLit x -> lit x
                                | _ -> raise_codegen_error "Array sizes need to be statically known in the HLS C++ backend."
                            line s $"%s{tyv t} v{i}[{size}];"
                            true
                        //| [|L(i,t)|] -> line s $"%s{tyv t} v{i};" // TODO: Put in overloaded arrays later.
                        | _ -> raise_codegen_error "Compiler error: Expected a single variable on the left side of an array create op."
                    | _ ->
                        decl_vars |> line' s
                        op s (BindsLocal d) a
                        true
                with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
            | TyLocalReturnOp(trace,a,_) ->
                try op s ret a
                    true
                with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
            | TyLocalReturnData(d,trace) ->
                try match ret with
                    | BindsLocal l -> line' s (tup_destruct (l,data_term_vars d))
                    | BindsTailEnd -> line s $"return {tup_data d};"
                    true
                with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
            ) stmts
        |> ignore
    and show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
    and args' b = data_term_vars b |> Array.map show_w |> String.concat ", "
    and tup_term_vars x =
        let args = Array.map show_w x |> String.concat ", "
        if 1 < x.Length then sprintf "Tuple%i(%s)" (tup (term_vars_to_tys x)).tag args else args
    and tup_data x = tup_term_vars (data_term_vars x)
    and tup_ty_tys = function
        | [||] -> "void"
        | [|x|] -> tyv x
        | x -> sprintf "Tuple%i" (tup x).tag
    and tup_ty_tyvs (x : TyV []) = tup_ty_tys (tyvs_to_tys x)
    and tup_ty x = env.ty_to_data x |> data_free_vars |> tup_ty_tyvs
    and tyv = function
        | YUnion a ->
            match a.Item.layout with
            | UStack -> sprintf "US%i" (ustack a).tag
            | UHeap -> sprintf "UH%i *" (uheap a).tag
        | YLayout(a,Heap) -> raise_codegen_error "Heap layout types aren't supported in the HLS C++ backend due to them needing to be heap allocated."
        | YLayout(a,HeapMutable) -> raise_codegen_error "Heap mutable layout types aren't supported in the HLS C++ backend due to them needing to be heap allocated."
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_lit a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "%s *" (tup_ty a)
        | YFun(a,b) -> sprintf "Fun%i" (cfun (a,b)).tag
        | a -> raise_codegen_error (sprintf "Compiler error: Type not supported in the codegen.\nGot: %A" a)
    and prim = function
        | Int8T -> "int8_t" 
        | Int16T -> "int16_t"
        | Int32T -> "int32_t"
        | Int64T -> "int64_t"
        | UInt8T -> "uint8_t"
        | UInt16T -> "uint16_t"
        | UInt32T -> "uint32_t"
        | UInt64T -> "uint64_t" // are defined in cstdint
        | Float32T -> "float"
        | Float64T -> "double"
        | BoolT -> "bool" // part of c++ standard
        | CharT -> "char"
        | StringT -> "const char *"
    and lit = function
        | LitInt8 x -> sprintf "%i" x
        | LitInt16 x -> sprintf "%i" x
        | LitInt32 x -> sprintf "%il" x
        | LitInt64 x -> sprintf "%ill" x
        | LitUInt8 x -> sprintf "%iu" x
        | LitUInt16 x -> sprintf "%iu" x
        | LitUInt32 x -> sprintf "%iul" x
        | LitUInt64 x -> sprintf "%iull" x
        | LitFloat32 x -> 
            if x = infinityf then "HUGE_VALF" // nan/inf macros are defined in cmath
            elif x = -infinityf then "-HUGE_VALF"
            elif Single.IsNaN x then "NAN"
            else x.ToString("R") |> add_dec_point |> sprintf "%sf"
        | LitFloat64 x ->
            if x = infinity then "HUGE_VAL"
            elif x = -infinity then "-HUGE_VAL"
            elif Double.IsNaN x then "NAN"
            else x.ToString("R") |> add_dec_point
        | LitString x -> lit_string x
        | LitChar x -> 
            match x with
            | '\b' -> @"\b"
            | '\n' -> @"\n"
            | '\t' -> @"\t"
            | '\r' -> @"\r"
            | '\\' -> @"\\"
            | x -> string x
            |> sprintf "'%s'"
        | LitBool x -> if x then "true" else "false" // true and false are defined in stddef.h
    and type_lit = function
        | YLit x -> lit x
        | YSymbol x -> x
        | x -> raise_codegen_error "Compiler error: Expecting a type literal in the macro." 
    and op s (ret : BindsReturn) a =
        let binds a b = binds a b
        let return' (x : string) =
            match ret with
            | BindsLocal ret -> return_local s ret x
            | BindsTailEnd -> line s $"return {x};"
        let jp (a,b') =
            let args = args b'
            match a with
            | JPMethod(a,b) -> 
                let x = method (a,b)
                sprintf "%s%i(%s)" (Option.defaultValue "method_" x.name) x.tag args
            | JPClosure(a,b) -> sprintf "ClosureMethod%i" (closure (a,b)).tag
        match a with
        | TySizeOf t -> return' $"sizeof({tup_ty t})"
        | TyMacro _ -> raise_codegen_error "Macros are supposed to be taken care of in the `binds` function."
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if (%s){" (tup_data cond))
            binds (indent s) ret tr
            line s "} else {"
            binds (indent s) ret fl
            line s "}"
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyBackendSwitch m ->
            let backend = "Cuda"
            match Map.tryFind backend m with
            | Some b -> binds s ret b
            | None -> raise_codegen_error $"Cannot find the backend \"{backend}\" in the TyBackendSwitch."
        | TyBackend(_,_,(r,_)) -> raise_codegen_error_backend r "The C backend does not support nesting of other backends."
        | TyWhile(a,b) ->
            let cond =
                match a with
                | JPMethod(a,b),b' -> sprintf "while_method_%i(%s)" (method_while (a,b)).tag (args b')
                | _ -> raise_codegen_error "Expected a regular method rather than closure create in the while conditional."
            line s (sprintf "while (%s){" cond)
            binds (indent s) (BindsLocal [||]) b
            line s "}"
        | TyIntSwitch(L(v_i,_),on_succ,on_fail) ->
            line s (sprintf "switch (v%i) {" v_i)
            let _ =
                let s = indent s
                Array.iteri (fun i x ->
                    line s (sprintf "case %i: {" i)
                    binds (indent s) ret x
                    line (indent s) "break;"
                    line s "}"
                    ) on_succ
                line s "default: {"
                binds (indent s) ret on_fail
                line s "}"
            line s "}"
        | TyUnionUnbox(is,x,on_succs,on_fail) ->
            let case_tags = x.Item.tags
            let acs = match x.Item.layout with UHeap -> "->" | UStack -> "."
            let head = List.head is |> fun (L(i,_)) -> $"v{i}{acs}tag"
            List.pairwise is
            |> List.map (fun (L(i,_), L(i',_)) -> $"v{i}{acs}tag == v{i'}{acs}tag")
            |> String.concat " && "
            |> function "" -> head | x -> $"{x} ? {head} : -1"
            |> sprintf "switch (%s) {" |> line s
            let _ =
                let s = indent s
                let _,on_succs = Map.foldBack (fun k v (is_last, m) -> false, Map.add k (is_last,v) m) on_succs (on_fail.IsNone, Map.empty)
                Map.iter (fun k (is_last,(a,b)) ->
                    let union_i = case_tags.[k]

                    if is_last then line s $"default: {{ // {k}"
                    else line s $"case {union_i}: {{ // {k}"

                    List.iter2 (fun (L(data_i,_)) a ->
                        let a, s = data_free_vars a, indent s
                        let qs = ResizeArray(a.Length)
                        Array.iteri (fun field_i (L(v_i,t) as v) -> 
                            qs.Add $"{tyv t} v{v_i} = v{data_i}{acs}v.case{union_i}.v{field_i};"
                            ) a 
                        line' s qs
                        ) is a
                    binds (indent s) ret b
                    if not is_last then line (indent s) "break;"
                    line s "}"
                    ) on_succs
                on_fail |> Option.iter (fun b ->
                    line s "default: {"
                    binds (indent s) ret b
                    line s "}"
                    )
            line s "}"
        | TyUnionBox(a,b,c') ->
            let c = c'.Item
            let i = c.tags.[a]
            let vars = args' b
            match c.layout with
            | UHeap -> sprintf "UH%i_%i(%s)" (uheap c').tag i vars
            | UStack -> sprintf "US%i_%i(%s)" (ustack c').tag i vars
            |> return'
        | TyLayoutToHeap(a,b) -> raise_codegen_error "Cannot create a heap layout type in the HLS C++ backend due to them needing to be heap allocated."
        | TyLayoutToHeapMutable(a,b) -> raise_codegen_error "Cannot create a heap mutable layout type in the HLS C++ backend due to them needing to be heap allocated."
        | TyLayoutIndexAll _ 
        | TyLayoutIndexByKey _ -> raise_codegen_error "Cannot index into a layout type in the HLS C++ backend due to them needing to be heap allocated."
        | TyLayoutHeapMutableSet(L(i,t),b,c) -> raise_codegen_error "Cannot set a value into a layout type in the HLS C++ backend due to them needing to be heap allocated."
        | TyArrayLiteral(a,b') -> raise_codegen_error "Compiler error: TyArrayLiteral should have been taken care of in TyLet."
        | TyArrayCreate(a,b) ->  raise_codegen_error "Compiler error: TyArrayCreate should have been taken care of in TyLet."
        | TyFailwith(a,b) -> raise_codegen_error "Failwith is not supported in the HLS C++ backend."
        | TyConv(a,b) -> return' $"({tyv a}){tup_data b}"
        | TyApply(L(i,_),b) -> 
            let rec loop = function
                | DPair(a,b) -> tup_data a :: loop b
                | a -> [tup_data a]
            let args = loop b |> String.concat ", "
            $"v{i}({args})" |> return'
        | TyArrayLength(_,b) -> raise_codegen_error "Array length is not supported in the HLS C++ backend as they are bare pointers."
        | TyStringLength(_,b) -> raise_codegen_error "String length is not supported in the HLS C++ backend."
        | TyOp(Global,[DLit (LitString x)]) -> global' x
        | TyOp(op,l) ->
            match op, l with
            | Dyn,[a] -> tup_data a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringIndex, [a;b] -> sprintf "%s[%s]" (tup_data a) (tup_data b)
            | StringSlice, [a;b;c] -> raise_codegen_error "String slice is not supported natively in the C backend. Use a library implementation instead."
            | ArrayIndex, [DV(L(_,YArray t)) & a;b] -> 
                match tup_ty t with
                | "void" -> "/* void array index */"
                | _ -> sprintf "%s[%s]" (tup_data a) (tup_data b)
            | ArrayIndexSet, [DV(L(_,YArray t)) as a;b;c] -> 
                let a',b',c' = tup_data a, tup_data b, tup_data c
                match c' with
                | "" -> "/* void array set */"
                | _ -> $"{a'}[{b'}] = {c'}"
            // Math
            | Add, [a;b] -> sprintf "%s + %s" (tup_data a) (tup_data b)
            | Sub, [a;b] -> sprintf "%s - %s" (tup_data a) (tup_data b)
            | Mult, [a;b] -> sprintf "%s * %s" (tup_data a) (tup_data b)
            | Div, [a;b] -> sprintf "%s / %s" (tup_data a) (tup_data b)
            | Mod, [a;b] -> sprintf "%s %% %s" (tup_data a) (tup_data b)
            | Pow, [a;b] -> sprintf "pow(%s,%s)" (tup_data a) (tup_data b)
            | LT, [a;b] -> sprintf "%s < %s" (tup_data a) (tup_data b)
            | LTE, [a;b] -> sprintf "%s <= %s" (tup_data a) (tup_data b)
            | EQ, [a;b] | NEQ, [a;b] | GT, [a;b] | GTE, [a;b] when is_string a -> raise_codegen_error "String comparison operations are not supported in the HLS C++ backend."
            | EQ, [a;b] -> sprintf "%s == %s" (tup_data a) (tup_data b)
            | NEQ, [a;b] -> sprintf "%s != %s" (tup_data a) (tup_data b)
            | GT, [a;b] -> sprintf "%s > %s" (tup_data a) (tup_data b)
            | GTE, [a;b] -> sprintf "%s >= %s" (tup_data a) (tup_data b)
            | BoolAnd, [a;b] -> sprintf "%s && %s" (tup_data a) (tup_data b)
            | BoolOr, [a;b] -> sprintf "%s || %s" (tup_data a) (tup_data b)
            | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup_data a) (tup_data b)
            | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup_data a) (tup_data b)
            | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup_data a) (tup_data b)
            | BitwiseComplement, [a] -> sprintf "~%s" (tup_data a)

            | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup_data a) (tup_data b)
            | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup_data a) (tup_data b)

            | Neg, [x] -> sprintf "-%s" (tup_data x)
            | Log, [x] -> import "cmath"; sprintf "log(%s)" (tup_data x)
            | Exp, [x] -> import "cmath"; sprintf "exp(%s)" (tup_data x)
            | Tanh, [x] -> import "cmath"; sprintf "tanh(%s)" (tup_data x)
            | Sqrt, [x] -> import "cmath"; sprintf "sqrt(%s)" (tup_data x)
            | Sin, [x] -> import "cmath"; sprintf "sin(%s)" (tup_data x)
            | Cos, [x] -> import "cmath"; sprintf "cos(%s)" (tup_data x)
            | NanIs, [x] -> import "cmath"; sprintf "isnan(%s)" (tup_data x)
            | UnionTag, [DV(L(i,YUnion l)) as x] -> 
                match l.Item.layout with
                | UHeap -> "->tag"
                | UStack -> ".tag"
                |> sprintf "v%i%s" i
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> return'
    and print_ordered_args s v = // Unlike C# for example, C keeps the struct fields in input order. To reduce padding, it is best to order the fields from largest to smallest.
        order_args v |> Array.iter (fun (L(i,x)) -> line s $"{tyv x} v{i};")
    and method_template is_while : _ -> MethodRec =
        jp (fun ((jp_body,key & (C(args,_))),i) ->
            match (fst env.join_point_method.[jp_body]).[key] with
            | Some a, Some range, name -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a; name=Option.map fix_method_name name}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s_fwd s_typ s_fun x ->
            let ret_ty = tup_ty x.range
            let fun_name = Option.defaultValue (if is_while then "while_method_" else "method_") x.name
            let args = x.free_vars |> Array.mapi (fun i (L(_,x)) -> $"{tyv x} v{i}") |> String.concat ", "
            let inline_ = if is_while then "inline " else line s_fwd $"{ret_ty} {fun_name}{x.tag}({args});"; ""
            line s_fun $"{inline_}{ret_ty} {fun_name}{x.tag}({args}){{"
            binds_start (indent s_fun) x.body
            line s_fun "}"
            )
    and method : _ -> MethodRec = method_template false
    and method_while : _ -> MethodRec = method_template true
    and closure_args domain =
        let rec loop = function
            | YPair(a,b) -> a :: loop b
            | a -> [a]
        let mutable count = 0
        let assert_not_void = function [||] -> raise_codegen_error "Void arguments in closures are not allowed." | x -> x
        let rename x = Array.map (fun (L(i,t)) -> let x = L(count,t) in count <- count+1; x) x
        loop domain |> List.mapi (fun i x -> let n = env.ty_to_data x |> data_free_vars in i, tup_ty_tyvs n, n |> rename |> assert_not_void)
    and closure : _ -> ClosureRec =
        jp (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some(domain_args, body) -> 
                let assert_empty x = if Array.isEmpty x then x else raise_codegen_error "The HLS C++ backend doesn't support closures due to them needing to be heap allocated, only function pointers. For them to be converted to pointers, the closures must not have any free variables in them."
                {tag=i; free_vars=rdata_free_vars args |> assert_empty; domain=domain; range=range; body=body}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun _ s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            let closure_args = closure_args x.domain
            let args = closure_args |> List.map (fun (i,ty,_) -> $"{ty} tup{i}") |> String.concat ", "
            $"{range} ClosureMethod{i}({args}){{" |> line s_fun
            let _ =
                let s_fun = indent s_fun
                closure_args |> List.map (fun (i'',_,vars) ->
                    Array.mapi (fun i' (L(i,t)) -> 
                        if vars.Length <> 1 then $"{tyv t} v{i} = tup{i''}.v{i'};"
                        else $"{tyv t} v{i} = tup{i''};"
                        ) vars
                    |> String.concat " "
                    ) |> String.concat " " |> line s_fun
                binds_start s_fun x.body
            line s_fun "}"
            )
    and cfun : _ -> CFunRec =
        cfun' (fun s_fwd s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            let domain_args_ty = closure_args x.domain |> List.map (fun (_,ty,_) -> ty) |> String.concat ", "
            line s_fwd $"typedef %s{range} (* Fun%i{i})(%s{domain_args_ty});"
            )
    and tup : _ -> TupleRec = 
        tuple (fun s_fwd s_typ s_fun x ->
            let name = sprintf "Tuple%i" x.tag
            line s_fwd $"struct {name};"
            line s_typ $"struct {name} {{"
            x.tys |> Array.mapi (fun i x -> L(i,x)) |> print_ordered_args (indent s_typ)

            let concat x = String.concat ", " x
            let args = x.tys |> Array.mapi (fun i x -> $"{tyv x} t{i}")
            let con_init = x.tys |> Array.mapi (fun i x -> $"v{i}(t{i})")
            line (indent s_typ) $"{name}({concat args}) : {concat con_init} {{}}" 
            line (indent s_typ) $"{name}() = default;" 

            line s_typ "};"

            )
    and ustack : _ -> UnionRec =
        let inline map_iteri f x = Map.fold (fun i k v -> f i k v; i+1) 0 x |> ignore
        union (fun s_fwd s_typ s_fun x ->
            let i = x.tag
            line s_fwd $"struct US{i};"
            line s_typ $"struct US{i} {{"
            let _ =
                let s_typ = indent s_typ
                line s_typ "union {"
                let _ =
                    let s_typ = indent s_typ
                    map_iteri (fun tag k v -> 
                        if Array.isEmpty v = false then
                            line s_typ "struct {"
                            print_ordered_args (indent s_typ) v
                            line s_typ (sprintf "} case%i; // %s" tag k)
                        ) x.free_vars
                line s_typ "} v;"

                // Tag
                let num_bits = num_bits_needed_to_represent x.free_vars.Count
                if num_bits > 8 then raise_codegen_error "Too many union cases! Cannot have a union case type with more than 8 bits."
                line s_typ $"char tag : {num_bits};"
            line s_typ "};"

            map_iteri (fun tag k v -> 
                let args = v |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", "
                line s_fun (sprintf "US%i US%i_%i(%s) { // %s" i i tag args k)
                let _ =
                    let s_fun = indent s_fun
                    line s_fun $"US{i} x;"
                    line s_fun $"x.tag = {tag};"
                    if v.Length <> 0 then
                        v |> Array.map (fun (L(i,t)) -> $"x.v.case{tag}.v{i} = v{i};") |> line' s_fun
                    line s_fun "return x;"
                line s_fun "}"
                ) x.free_vars
            )
    and uheap _ : UnionRec = raise_codegen_error "Recursive unions aren't allowed in the HLS C++ backend due to them needing to be heap allocated."

    global' "#pragma warning(disable: 4101 4065 4060)"
    global' "// Add these as extra argument to the compiler to suppress the rest:"
    global' "// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550"
    import "cstdint"
    import "array"

    let main_defs = {text=StringBuilder(); indent=0}

    match binds_last_data x |> data_term_vars |> term_vars_to_tys with
    | [|YPrim Int32T|] ->
        line main_defs $"{prim Int32T} main() {{"
        binds_start (indent main_defs) x
        line main_defs "}"

        let cpp = StringBuilder()
        globals |> Seq.iter (fun x -> cpp.AppendLine(x) |> ignore)
        fwd_dcls |> Seq.iter (fun x -> cpp.Append(x) |> ignore)
        types |> Seq.iter (fun x -> cpp.Append(x) |> ignore)
        functions |> Seq.iter (fun x -> cpp.Append(x) |> ignore)
    
        cpp.Append(main_defs.text) |> ignore
        [
        {|code = cpp.ToString(); file_extension = "cu"|}
        ]
    | _ ->
        raise_codegen_error "The return type of main in the C backend should be a 32-bit int."

let codegen (env : PartEvalResult) (x : TypedBind []) = codegen' env x