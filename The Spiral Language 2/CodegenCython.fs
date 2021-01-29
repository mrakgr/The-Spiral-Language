module Spiral.Codegen.Cython

open Spiral
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval.Main
open System
open System.Text
open System.Collections.Generic

type CodegenEnv =
    {
    text : StringBuilder
    indent : int
    }

let line x s = x.text.Append(' ', x.indent).AppendLine s |> ignore
let indent x = {x with indent=x.indent+4}

exception CodegenError of string
exception CodegenErrorWithPos of Trace * string
let raise_codegen_error x = raise (CodegenError x)
let raise_codegen_error' trace x = raise (CodegenErrorWithPos(trace,x))

let lit = function
    | LitInt8 x -> sprintf "%i" x
    | LitInt16 x -> sprintf "%i" x
    | LitInt32 x -> sprintf "%i" x
    | LitInt64 x -> sprintf "%i" x
    | LitUInt8 x -> sprintf "%i" x
    | LitUInt16 x -> sprintf "%i" x
    | LitUInt32 x -> sprintf "%i" x
    | LitUInt64 x -> sprintf "%i" x
    | LitFloat32 x -> 
        if x = infinityf then "float('inf')"
        elif x = -infinityf then "float('-inf')"
        elif Single.IsNaN x then "float()"
        else sprintf "%f" x
    | LitFloat64 x ->
        if x = infinity then "float('inf')"
        elif x = -infinity then "float('-inf')"
        elif Double.IsNaN x then "float()"
        else sprintf "%f" x
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
        | x -> string x
        |> sprintf "'%s'"
    | LitBool x -> if x then "1" else "0"

let prim = function
    | Int8T -> "signed char"
    | Int16T -> "signed short"
    | Int32T -> "signed long"
    | Int64T -> "signed long long"
    | UInt8T -> "unsigned char"
    | UInt16T -> "unsigned short"
    | UInt32T -> "unsigned long"
    | UInt64T -> "unsigned long long"
    | Float32T -> "float"
    | Float64T -> "double"
    | BoolT -> "char"
    | StringT | CharT -> "str"

type UnionRec = {free_vars : Map<string, TyV[]>; tag : int}
type LayoutRec = {data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>; tag : int}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureTyRec = {tag : int; domain : Ty; range : Ty}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : string []}

let codegen (env : PartEvalResult) (x : TypedBind []) =
    let imports = ResizeArray()
    let types = ResizeArray()
    let functions = ResizeArray()

    let print is_type show r =
        let s = {text=StringBuilder(); indent=0}
        show s r
        let text = s.text.ToString()
        if is_type then types.Add(text) else functions.Add(text)

    let layout show =
        let dict' = Dictionary(HashIdentity.Structural)
        let dict = Dictionary(HashIdentity.Reference)
        let f x : LayoutRec = 
            let x = env.ty_to_data x
            let a, b =
                match x with
                | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                | _ -> data_free_vars x, Map.empty
            {data=x; free_vars=a; free_vars_by_key=b; tag=dict'.Count}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (Utils.memoize dict' (fun x -> dirty <- true; f x)) x
            if dirty then print true show r
            r

    let union show =
        let dict = Dictionary(HashIdentity.Reference)
        let f (a : Map<string,Ty>) : UnionRec = {free_vars=a |> Map.map (fun _ -> env.ty_to_data >> data_free_vars); tag=dict.Count}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print true show r
            r

    let jp is_type f show =
        let dict = Dictionary(HashIdentity.Structural)
        let f x = f (x, dict.Count)
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print is_type show r
            r

    let tuple show =
        let dict = Dictionary(HashIdentity.Structural)
        let f (x : string []) = {tag=dict.Count; tys=x}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print true show r
            r

    let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "
    let show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
    let args' b = data_term_vars b |> Array.map show_w |> String.concat ", "

    let tmp =
        let mutable i = 0
        fun () -> let x = i in i <- i + 1; x

    let import =
        let has_added = HashSet()
        fun x -> if has_added.Add(x) then imports.Add $"import {x}"

    let with_self = function "" -> "self" | x -> $"self, {x}"
    let pass_if_empty = function "" -> "pass" | x -> x

    let binds_last_data x = x |> Array.last |> function TyLocalReturnData(x,_) | TyLocalReturnOp(_,_,x) -> x | TyLet _ -> raise_codegen_error "Compiler error: Cannot find the return data of the last bind."

    let rec tyv = function
        | YUnion a -> 
            let a = a.Item
            match a.layout with
            | UHeap -> sprintf "UH%i" (uheap a.cases).tag
            | UStack -> sprintf "US%i" (ustack a.cases).tag
        | YLayout(a,Heap) -> sprintf "Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i" (mut a).tag
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> "list" // TODO: Special cases for primitive arrays.
        | YFun(a,b) -> sprintf "ClosureTy%i" ((closure_ty (a,b)).tag)
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and binds' (defs : CodegenEnv) (x : TypedBind []) =
        let s = {defs with text = StringBuilder()}
        binds defs s (Choice1Of2(binds_last_data x |> data_free_vars |> Array.isEmpty)) x
        defs.text.Append(s.text) |> ignore
    and binds (defs : CodegenEnv) (s : CodegenEnv) ret (x : TypedBind []) =
        Array.iteri (fun i x ->
            match x with
            | TyLet(d,trace,a) -> 
                try let d = data_free_vars d
                    Array.iter (fun (L(i,t)) -> cdef_show "" defs i (tyv t)) d
                    op defs s (Choice2Of2 d) a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a,_) -> try op defs s ret a with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d,trace) -> 
                try match ret with
                    | Choice1Of2 true -> if i = 0 then line s "pass"
                    | Choice1Of2 false -> line s $"return {tup d}"
                    | Choice2Of2 [||] -> ()
                    | Choice2Of2 ret -> line s $"{args ret} = {args' d}"
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) x
    and tup x =
        match data_term_vars x with
        | [||] -> "pass"
        | [|x|] -> show_w x
        | x -> 
            let args = Array.map show_w x |> String.concat ", " 
            let ty = x |> Array.map (function WV(L(_,t)) -> tyv t | WLit x -> prim (lit_to_primitive_type x))
            sprintf "Tuple%i(%s)" ((tup' ty).tag) args
    and tup_tyvs = function
        | [||] -> "void"
        | [|L(_,x)|] -> tyv x
        | x -> $"Tuple{(tup' (tyv_type_show x)).tag}"
    and tup_data x = tup_tyvs (data_free_vars x)
    and tup_ty x = tup_data (env.ty_to_data x)
    and op defs s ret a =
        let return' x =
            match ret with
            | Choice1Of2 true -> line s x 
            | Choice1Of2 false -> line s (sprintf "return %s" x)
            | Choice2Of2 [||] -> line s x
            | Choice2Of2 [|L(i,_)|] -> line s $"v{i} = {x}"
            | Choice2Of2 ret ->
                    let tmp_i = tmp()
                    line defs $"cdef {tup_tyvs ret} tmp{tmp_i}"
                    line s $"tmp{tmp_i} = {x}"
                    let tmp_is = Array.init ret.Length (fun i -> $"tmp{tmp_i}.v{i}") |> String.concat ", "
                    line s $"{args ret} = {tmp_is}"
        let jp (a,b) =
            let args = args b
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "Closure%i(%s)" (closure (a,b)).tag args
        let layout_index i x =
            x |> Array.map (fun (L(i',_)) -> $"v{i}.v{i'}")
            |> String.concat ", "
            |> function "" -> "pass" | x -> x
            |> return'
        match a with
        | TyMacro a -> 
            a |> List.map (function 
                | CMText x -> x 
                | CMTerm x -> match tup x with "pass" -> raise_codegen_error "Cython codegen error: Void terms are not allowed in macros." | x -> x
                | CMType x -> match tup_ty x with "void" -> raise_codegen_error "Cython codegen error: Void types are not allowed in macros." | x -> x
                ) |> String.concat "" |> return'
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if %s:" (tup cond))
            binds defs (indent s) ret tr
            match fl with
            | [|TyLocalReturnData(DB,_)|] -> ()
            | _ ->
                line s "else:"
                binds defs (indent s) ret fl
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyWhile(a,b) ->
            line s (sprintf "while %s:" (jp a))
            binds defs (indent s) ret b
        | TyIntSwitch(v_i,on_succ,on_fail) ->
            Array.iteri (fun i x ->
                if i = 0 then line s (sprintf "if v%i = %i:" v_i i)
                else line s (sprintf "elif v%i = %i:" v_i i)
                binds defs (indent s) ret x
                ) on_succ
            line s "else:"
            binds defs (indent s) ret on_fail
        | TyUnionUnbox(is,x,on_succs,on_fail) ->
            let case_tags = x.Item.tags
            let prefix = 
                let x = x.Item
                match x.layout with
                | UHeap -> sprintf "UH%i" (uheap x.cases).tag
                | UStack -> sprintf "US%i" (ustack x.cases).tag
            let mutable is_first = true
            Map.iter (fun k (a,b) ->
                let union_i = case_tags.[k]
                let branch =
                    let cond = is |> List.map (fun (v_i : Tag) -> sprintf "v%i.tag == %i" v_i union_i) |> String.concat " and "
                    if is_first then 
                        line s (sprintf "if %s: # %s" cond k)
                        is_first <- false
                    else line s (sprintf "elif %s: # %s" cond k)
                let s = indent s
                List.iter2 (fun data_i a ->
                    data_free_vars a |> Array.iteri (fun field_i (L(v_i,t)) ->
                        line defs $"cdef {tyv t} v{v_i}"
                        line s $"v{v_i} = (<{prefix}_{union_i}>v{data_i}).v{field_i}"
                        )
                    ) is a
                binds defs s ret b
                ) on_succs
            on_fail |> Option.iter (fun b ->
                line s "else:"
                binds defs (indent s) ret b
                )
        | TyUnionBox(a,b,c) ->
            let c = c.Item
            let i = c.tags.[a]
            let vars = args' b
            match c.layout with
            | UHeap -> sprintf "UH%i_%i(%s)" (uheap c.cases).tag i vars
            | UStack -> sprintf "US%i_%i(%s)" (ustack c.cases).tag i vars
            |> return'
        | TyLayoutToHeap(a,b) -> sprintf "Heap%i(%s)" (heap b).tag (args' a) |> return'
        | TyLayoutToHeapMutable(a,b) -> sprintf "Mut%i(%s)" (mut b).tag (args' a) |> return'
        | TyLayoutIndexAll(L(i,(a,lay))) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i
        | TyLayoutIndexByKey(L(i,(a,lay)),key) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.iter2 (fun (L(i',_)) b ->
                line s $"v{i}.v{i'} = {show_w b}"
                ) (data_free_vars a) (data_term_vars c)
        | TyArrayCreate(a,b) -> return' (sprintf "[None] * %s" (tup b))
        | TyFailwith(a,b) -> return' (sprintf "raise Exception(%s)" (tup b))
        | TyOp(op,l) ->
            match op, l with
            | Apply,[a;b] -> sprintf "%s.apply(%s)" (tup a) (args' b)
            | Dyn,[a] -> tup a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringLength, [a] -> sprintf "<signed long>len(%s)" (tup a)
            | StringIndex, [a;b] -> sprintf "%s[%s]" (tup a) (tup b)
            | StringSlice, [a;b;c] -> sprintf "%s[%s..%s]" (tup a) (tup b) (tup c)
            | ArrayIndex, [a;b] -> sprintf "%s[%s]" (tup a) (tup b)
            | ArrayIndexSet, [a;b;c] -> 
                match tup c with
                | "pass" as c -> c
                | c -> sprintf "%s[%s] = %s" (tup a) (tup b) c
            | ArrayLength, [a] -> sprintf "<signed long>len(%s)" (tup a)

            // Math
            | Add, [a;b] -> sprintf "%s + %s" (tup a) (tup b)
            | Sub, [a;b] -> sprintf "%s - %s" (tup a) (tup b)
            | Mult, [a;b] -> sprintf "%s * %s" (tup a) (tup b)
            | Div, [(DV(L(_,YPrim (Float32T | Float64T))) | DLit(LitFloat32 _ | LitFloat64 _)) & a;b] -> sprintf "%s / %s" (tup a) (tup b)
            | Div, [a;b] -> sprintf "%s // %s" (tup a) (tup b)
            | Mod, [a;b] -> sprintf "%s %% %s" (tup a) (tup b)
            | Pow, [a;b] -> sprintf "pow(%s,%s)" (tup a) (tup b)
            | LT, [a;b] -> sprintf "%s < %s" (tup a) (tup b)
            | LTE, [a;b] -> sprintf "%s <= %s" (tup a) (tup b)
            | EQ, [a;b] -> sprintf "%s == %s" (tup a) (tup b)
            | NEQ, [a;b] -> sprintf "%s != %s" (tup a) (tup b)
            | GT, [a;b] -> sprintf "%s > %s" (tup a) (tup b)
            | GTE, [a;b] -> sprintf "%s >= %s" (tup a) (tup b)
            | BoolAnd, [a;b] -> sprintf "%s and %s" (tup a) (tup b)
            | BoolOr, [a;b] -> sprintf "%s or %s" (tup a) (tup b)
            | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup a) (tup b)
            | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup a) (tup b)
            | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup a) (tup b)

            | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup a) (tup b)
            | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup a) (tup b)

            | Neg, [x] -> sprintf " -%s" (tup x)
            | Log, [x] -> import "math"; sprintf "math.log(%s)" (tup x)
            | Exp, [x] -> import "math"; sprintf "math.exp(%s)" (tup x)
            | Tanh, [x] -> import "math"; sprintf "math.tanh(%s)" (tup x)
            | Sqrt, [x] -> import "math"; sprintf "math.sqrt(%s)" (tup x)
            | Hash, [x] -> sprintf "<signed long>hash(%s)" (tup x)
            | NanIs, [x] -> import "math"; sprintf "math.isnan(%s)" (tup x)
            | UnionTag, [x] -> sprintf "%s.tag" (tup x)
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> return'
    and arg_show i = function "object" -> sprintf "v%i" i | t -> sprintf "%s v%i" t i
    and cdef_show (prefix : string) s i x = line s $"cdef {prefix}{x} v{i}"
    and args_tys x = x |> Array.map (fun (L(i,t)) -> arg_show i (tyv t)) |> String.concat ", "
    and tyv_type_show x = x |> Array.map (fun (L(_,t)) -> tyv t)
    // TODO: Hopefully Cython will get cdef tuples that can hold Python objects. 
    // Until then, they will share functionality with layout types and be heap allocated.
    and layout_template name prefix s tag tys = 
        line s (sprintf "cdef class %s%i:" name tag)
        let s = indent s
        tys |> Array.iteri (cdef_show prefix s)
        let args = tys |> Array.mapi arg_show |> String.concat ", " |> with_self
        let body = Array.init tys.Length (fun i -> $"self.v{i} = v{i}") |> String.concat "; " |> pass_if_empty
        line s (sprintf "def __init__(%s): %s" args body)
    and heap : _ -> LayoutRec = layout (fun s x -> layout_template "Heap" "readonly " s x.tag (tyv_type_show x.free_vars))
    and mut : _ -> LayoutRec = layout (fun s x -> layout_template "Mut" "public " s x.tag (tyv_type_show x.free_vars))
    and tup' : _ -> TupleRec = tuple (fun s x -> layout_template "Tuple" "readonly " s x.tag x.tys)
    and union_template (prefix : string) s (x : UnionRec) = 
        line s $"cdef class {prefix}{x.tag}:"
        line (indent s) $"cdef readonly unsigned long tag"
        let mutable i = 0
        x.free_vars |> Map.iter (fun k a ->
            line s $"cdef class {prefix}{x.tag}_{i}({prefix}{x.tag}): # {k}"
            let s = indent s
            let tys = tyv_type_show a
            tys |> Array.iteri (cdef_show "readonly " s)
            let args = tys |> Array.mapi arg_show |> String.concat ", " |> with_self
            let body = $"self.tag = {i}" :: List.init tys.Length (fun i -> $"self.v{i} = v{i}") |> String.concat "; "
            line s $"def __init__({args}): {body}"
            i <- i+1
            )
    and uheap : _ -> UnionRec = union (union_template "UH")
    // TODO: Stack unions will be implemented the same as heap ones for the time being. 
    // I don't have a good way to implement the stack based ones in Cython.
    and ustack : _ -> UnionRec = union (union_template "US") 
    and method : _ -> MethodRec =
        jp false (fun ((jp_body,key & (C(args,_))),i) ->
            match (fst env.join_point_method.[jp_body]).[key] with
            | Some a, Some range -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s x ->
            line s $"cdef {tup_ty x.range} method{x.tag}({args_tys x.free_vars}):"
            binds' (indent s) x.body
            )
    and closure_ty : _ -> ClosureTyRec =
        jp true (fun ((domain,range),i) -> {tag=i; domain=domain; range=range}) (fun s x ->
            line s (sprintf "cdef class ClosureTy%i:" x.tag)
            let dom = env.ty_to_data x.domain |> data_free_vars |> args_tys |> with_self
            line (indent s) $"cpdef {tup_ty x.range} apply({dom}): raise NotImplementedError()"
            )
    and closure : _ -> ClosureRec =
        jp true (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s x ->
            line s (sprintf "cdef class Closure%i(ClosureTy%i):" x.tag (closure_ty (x.domain,x.range)).tag)
            let s = indent s
            let free_vars = x.free_vars |> Array.map (fun (L(i,t)) -> i, tyv t)
            free_vars |> Array.iter (fun (i,x) -> cdef_show "" s i x)
            let init_args = free_vars |> Array.map (fun (i,t) -> arg_show i t) |> String.concat ", " |> with_self
            let init_body = free_vars |> Array.map (fun (i,_) -> $"self.v{i} = v{i}") |> String.concat "; " |> pass_if_empty
            line s $"def __init__({init_args}): {init_body}"
            line s $"cpdef {tup_ty x.range} apply({with_self (args_tys x.domain_args)}):"
            let s = indent s
            free_vars |> Array.iter (function i, "object" -> line s $"v{i} = self.v{i}" | i, t -> line s $"cdef {t} v{i} = self.v{i}")
            binds' s x.body
            )

    let main = StringBuilder()
    let s = {text=main; indent=0}
    line s $"cpdef {tup_data (binds_last_data x)} main():"
    binds' (indent s) x

    let program = StringBuilder()
    imports |> Seq.iter (fun x -> program.Append(x) |> ignore)
    types |> Seq.iter (fun x -> program.Append(x) |> ignore)
    functions |> Seq.iter (fun x -> program.Append(x) |> ignore)
    program.Append(main).ToString()
