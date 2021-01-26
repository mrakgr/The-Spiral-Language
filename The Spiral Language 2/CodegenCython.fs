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
        if x = infinityf then "float(inf)"
        elif x = -infinityf then "float(-inf)"
        elif Single.IsNaN x then "float()"
        else sprintf "%f" x
    | LitFloat64 x ->
        if x = infinity then "float(inf)"
        elif x = -infinity then "float(-inf)"
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
    | StringT | CharT -> "object"

type UnionRec = {free_vars : Map<string, TyV[]>; tag : int}
type LayoutRec = {data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>; tag : int}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureTyRec = {tag : int; domain : Ty; range : Ty}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : string []}

let codegen (env : PartEvalResult) (x : TypedBind []) =
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

    let jp f show =
        let dict = Dictionary(HashIdentity.Structural)
        let f x = f (x, dict.Count)
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print false show r
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

    let tmp =
        let mutable i = 0
        fun () -> let x = i in i <- i + 1; x

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
        | YArray a -> "object" // TODO: Special cases for primitive arrays.
        | YFun(a,b) -> sprintf "ClosureTy%i" ((closure_ty (a,b)).tag)
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and binds (s : CodegenEnv) (x : TypedBind []) =
        Array.iter (fun x ->
            match x with
            | TyLet(d,trace,a) -> try op s (Some d) a with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a) -> try op s None a with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d,trace) -> try line s (tup d) with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) x
    and tup x =
        match data_term_vars x with
        | [|x|] -> show_w x
        | x -> 
            let args = Array.map show_w x |> String.concat ", " 
            let ty = x |> Array.map (function WV(L(_,t)) -> tyv t | WLit x -> prim (lit_to_primitive_type x))
            sprintf "Tuple%i(%s)" ((tup' ty).tag) args
    and tup_tyvs (x : TyV []) = 
        let vars = x |> Array.map (fun (L(_,x)) -> tyv x)
        let i = tup' vars
        sprintf "Tuple%i" i.tag
    and tup_data x = tup_tyvs (data_free_vars x)
    and tup_ty x = tup_data (env.ty_to_data x)
    and op s d a =
        let jp (a,b) =
            let args = args b
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "Closure%i(%s)" (closure (a,b)).tag args
        let return' x =
            match d with
            | None -> line s (sprintf "return %s" x)
            | Some d ->
                match data_free_vars d with
                | [||] -> line s x
                | [|L(i,_)|] -> line s (sprintf "v%i = %s" i x)
                | d ->
                    let tmp_i = tmp()
                    line s (sprintf "cdef %s tmp%i = %s" (tup_tyvs d) tmp_i x)
                    line s (Array.mapi (fun i (L(v_i,_)) -> sprintf "v%i = tmp%i.v%i" v_i tmp_i i) d |> String.concat "; ")
        match a with
        | TyMacro a -> a |> List.map (function CMText x -> x | CMTerm x -> tup x | CMType x -> tup_ty x) |> String.concat "" |> return'
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if %s:" (tup cond))
            binds (indent s) tr
            match fl with
            | [|TyLocalReturnData(DB,_)|] -> ()
            | _ ->
                line s "else:"
                binds (indent s) fl
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyWhile(a,b) ->
            line s (sprintf "while %s:" (jp a))
            binds (indent s) b
        | TyIntSwitch(v_i,on_succ,on_fail) ->
            Array.iteri (fun i x ->
                if i = 0 then line s (sprintf "if v%i = %i:" v_i i)
                else line s (sprintf "elif v%i = %i:" v_i i)
                binds (indent s) x
                ) on_succ
            line s "else:"
            binds (indent s) on_fail
        | TyUnionUnbox(is,x,on_succs,on_fail) ->
            complex <| fun s ->
            let case_tags = x.Item.tags
            line s (sprintf "match %s with" (is |> List.map (sprintf "v%i") |> String.concat ", "))
            let prefix = 
                let x = x.Item
                match x.layout with
                | UHeap -> sprintf "UH%i" (uheap x.cases).tag
                | UStack -> sprintf "US%i" (ustack x.cases).tag
            Map.iter (fun k (a,b) ->
                let i = case_tags.[k]
                let cases = 
                    a |> List.map (fun a ->
                        match data_free_vars a with
                        | [||] -> ""
                        | x -> sprintf "(%s)" (args x)
                        |> sprintf "%s_%i%s" prefix i
                        )
                    |> String.concat ", "
                line s (sprintf "| %s -> (* %s *)" cases k)
                binds (indent s) b
                ) on_succs
            |> ignore
            on_fail |> Option.iter (fun b ->
                line s "| _ ->"
                binds (indent s) b
                )
        | TyUnionBox(a,b,c) ->
            let c = c.Item
            let i = c.tags.[a]
            let vars =
                match data_term_vars b with
                | [||] -> ""
                | x -> Array.map show_w x |> String.concat ", " |> sprintf "(%s)"
            match c.layout with
            | UHeap -> sprintf "UH%i_%i%s" (uheap c.cases).tag i vars
            | UStack -> sprintf "US%i_%i%s" (ustack c.cases).tag i vars
            |> return'
        | TyLayoutToHeap(a,b) -> sprintf "{%s} : Heap%i" (layout_vars a) (heap b).tag |> return'
        | TyLayoutToHeapMutable(a,b) -> sprintf "{%s} : Mut%i" (layout_vars a) (mut b).tag |> return'
        | TyLayoutIndexAll(L(i,(a,lay))) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i
        | TyLayoutIndexByKey(L(i,(a,lay)),key) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.iter2 (fun (L(i',_)) b ->
                line s (sprintf "v%i.l%i <- %s" i i' (show_w b))
                ) (data_free_vars a) (data_term_vars c)
        | TyArrayCreate(a,b) -> return' (sprintf "Array.zeroCreate<%s> %s" (ty a) (term_vars b))
        | TyFailwith(a,b) -> return' (sprintf "failwith<%s> %s" (ty a) (term_vars b))
        | TyOp(op,l) ->
            match op, l with
            | Apply,[a;b] -> sprintf "%s %s" (tup a) (tup b)
            | Dyn,[a] -> tup a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringLength, [a] -> sprintf "%s.Length" (tup a)
            | StringIndex, [a;b] -> sprintf "%s.[%s]" (tup a) (tup b)
            | StringSlice, [a;b;c] -> sprintf "%s.[%s..%s]" (tup a) (tup b) (tup c)
            | ArrayIndex, [a;b] -> sprintf "%s.[%s]" (tup a) (tup b)
            | ArrayIndexSet, [a;b;c] -> sprintf "%s.[%s] <- %s" (tup a) (tup b) (tup c) 
            | ArrayLength, [a] -> sprintf "%s.Length" (tup a)

            // Math
            | Add, [a;b] -> sprintf "%s + %s" (tup a) (tup b)
            | Sub, [a;b] -> sprintf "%s - %s" (tup a) (tup b)
            | Mult, [a;b] -> sprintf "%s * %s" (tup a) (tup b)
            | Div, [a;b] -> sprintf "%s / %s" (tup a) (tup b)
            | Mod, [a;b] -> sprintf "%s %% %s" (tup a) (tup b)
            | Pow, [a;b] -> sprintf "%s ** %s" (tup a) (tup b)
            | LT, [a;b] -> sprintf "%s < %s" (tup a) (tup b)
            | LTE, [a;b] -> sprintf "%s <= %s" (tup a) (tup b)
            | EQ, [a;b] -> sprintf "%s = %s" (tup a) (tup b)
            | NEQ, [a;b] -> sprintf "%s <> %s" (tup a) (tup b)
            | GT, [a;b] -> sprintf "%s > %s" (tup a) (tup b)
            | GTE, [a;b] -> sprintf "%s >= %s" (tup a) (tup b)
            | BoolAnd, [a;b] -> sprintf "%s && %s" (tup a) (tup b)
            | BoolOr, [a;b] -> sprintf "%s || %s" (tup a) (tup b)
            | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup a) (tup b)
            | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup a) (tup b)
            | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup a) (tup b)

            | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup a) (tup b)
            | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup a) (tup b)

            | Neg, [x] -> sprintf " -%s" (tup x)
            | Log, [x] -> sprintf "log %s" (tup x)
            | Exp, [x] -> sprintf "exp %s" (tup x)
            | Tanh, [x] -> sprintf "tanh %s" (tup x)
            | Sqrt, [x] -> sprintf "sqrt %s" (tup x)
            | Hash, [x] -> sprintf "hash %s" (tup x)
            | NanIs, [x] -> 
                match x with
                | DLit(LitFloat32 _) | DV(L(_,YPrim Float32T)) -> sprintf "System.Single.IsNaN(%s)" (tup x)
                | DLit(LitFloat64 _) | DV(L(_,YPrim Float64T)) -> sprintf "System.Double.IsNaN(%s)" (tup x)
                | _ -> raise_codegen_error "Compiler error: Invalid type in NanIs."
            | UnionTag, [DV(L(i,YUnion h))] -> 
                let ty =
                    let h = h.Item
                    match h.layout with
                    | UHeap -> sprintf "UH%i" (uheap h.cases).tag
                    | UStack -> sprintf "US%i" (ustack h.cases).tag
                sprintf "(fst (Reflection.FSharpValue.GetUnionFields(v%i, typeof<%s>))).Tag" i ty // TODO: Stopgap measure for now. Replace this with something more efficient.
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> return'
    and arg_show i = function "object" -> sprintf "v%i" i | t -> sprintf "%s v%i" t i
    and cdef_show s i = function
        | "object" -> line s (sprintf "v%i" i)
        | x -> line s (sprintf "cdef %s v%i" x i)
    and args_tys' x = x |> Array.map (fun (i,t) -> arg_show i t) |> String.concat ", "
    and args_tys x = x |> Array.map (fun (L(i,t)) -> arg_show i (tyv t)) |> String.concat ", "
    and heap : _ -> LayoutRec = layout (fun s x ->
        line s (sprintf "Heap%i = {%s}" x.tag (x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "l%i : %s" i (tyv t)) |> String.concat "; "))
        )
    and mut : _ -> LayoutRec = layout (fun s x ->
        line s (sprintf "Mut%i = {%s}" x.tag (x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "mutable l%i : %s" i (tyv t)) |> String.concat "; "))
        )
    and uheap : _ -> UnionRec = union (fun s x ->
        line s (sprintf "UH%i =" x.tag)
        let mutable i = 0
        x.free_vars |> Map.iter (fun _ a ->
            match a with
            | [||] -> line (indent s) (sprintf "| UH%i_%i" x.tag i)
            | a -> line (indent s) (sprintf "| UH%i_%i of %s" x.tag i (a |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat " * "))
            i <- i+1
            )
        )
    and ustack : _ -> UnionRec = union (fun s x ->
        line s (sprintf "[<Struct>] US%i =" x.tag)
        let mutable i = 0
        x.free_vars |> Map.iter (fun _ a ->
            match a with
            | [||] -> line (indent s) (sprintf "| US%i_%i" x.tag i)
            | a -> line (indent s) (sprintf "| US%i_%i of %s" x.tag i (a |> Array.mapi (fun i' (L(_,t)) -> sprintf "f%i_%i : %s" i i' (tyv t)) |> String.concat " * "))
            i <- i+1
            )
        )
    and method : _ -> MethodRec =
        jp (fun ((jp_body,key & (C(args,_))),i) ->
            match (fst env.join_point_method.[jp_body]).[key] with
            | Some a, Some range -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s x ->
            line s (sprintf "method%i (%s) : %s =" x.tag (args_tys x.free_vars) (tup_ty x.range))
            binds (indent s) x.body
            )
    and closure_ty : _ -> ClosureTyRec =
        jp (fun ((domain,range),i) -> {tag=i; domain=domain; range=range}) (fun s x ->
            line s (sprintf "cdef class ClosureTy%i:" x.tag)
            let dom = env.ty_to_data x.domain |> data_free_vars |> args_tys
            line (indent s) (sprintf "cpdef %s apply(self, %s) = raise raise NotImplementedError()" (tup_ty x.range) dom)
            )
    and closure : _ -> ClosureRec =
        jp (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s x ->
            let domain = args_tys x.domain_args
            line s (sprintf "cdef class Closure%i(ClosureTy%i):" x.tag (closure_ty (x.domain,x.range)).tag)
            let s = indent s
            let free_vars = x.free_vars |> Array.map (fun (L(i,t)) -> i, tyv t)
            free_vars |> Array.iter (fun (i,x) -> cdef_show s i x)
            let init_body = free_vars |> Array.map (fun (i,_) -> sprintf "self.v%i = v%i" i i) |> String.concat "; "
            line s (sprintf "def __init__(self, %s): %s" (args_tys' free_vars) init_body)
            line s (sprintf "cpdef apply(self, %s):" (args_tys x.domain_args))
            let s = indent s
            line s (free_vars |> Array.map (function i, "object" -> sprintf "v%i = self.v%i" i i | i, t -> sprintf "cdef %s v%i = self.v%i" t i i) |> String.concat "; ")
            binds s x.body
            )
    and tup' : _ -> TupleRec =
        tuple (fun s x ->
            line s (sprintf "cdef class Tuple%i:" x.tag)
            let s = indent s
            x.tys |> Array.iteri (cdef_show s)
            let args = x.tys |> Array.mapi arg_show |> String.concat ", "
            let body = Array.init x.tys.Length (fun i -> sprintf "self.v%i = v%i" i i) |> String.concat "; "
            line s (sprintf "def __init__(self, %s): %s" args body)
            )

    let main = StringBuilder()
    binds {text=main; indent=0} x

    let program = StringBuilder()
    types |> Seq.iteri (fun i x -> program.Append(if i = 0 then "type " else "and ").Append(x) |> ignore)
    functions |> Seq.iteri (fun i x -> program.Append(if i = 0 then "let rec " else "and ").Append(x) |> ignore)
    program.Append(main).ToString()
