module Spiral.Codegen.Fsharp

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
    | LitBool x -> if x then "true" else "false"

let prim = function
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

type UnionRec = {free_vars : Map<string, TyV[]>; tag : int}
type LayoutRec = {data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>; tag : int}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : TyV[]; range : Ty; body : TypedBind[]}

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

    let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "
    let show_w = function WV i -> sprintf "v%i" i | WLit a -> lit a

    let rec tyv = function
        | YUnion a -> 
            let a = a.Item
            match a.layout with
            | UHeap -> sprintf "UH%i" (uheap a.cases).tag
            | UStack -> sprintf "US%i" (ustack a.cases).tag
        | YLayout(a,Heap) -> sprintf "Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i" (mut a).tag
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> ty a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "(%s [])" (ty a)
        | YFun(a,b) -> sprintf "(%s -> %s)" (ty a) (ty b)
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and args_tys x = x |> Array.map (fun (L(i,t)) -> sprintf "v%i : %s" i (ty t)) |> String.concat ", "
    and binds (s : CodegenEnv) (x : TypedBind []) =
        Array.iter (fun x ->
            match x with
            | TyLet(d,trace,a) -> try op s (Some d) a with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a) -> try op s None a with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d,trace) -> try line s (term_vars d) with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) x
    and term_vars x =
        match data_term_vars x with
        | [||] -> "()"
        | [|x|] -> show_w x
        | x -> Array.map show_w x |> String.concat ", " |> sprintf "struct (%s)"
    and ty x =
        match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
        | [||] -> "unit"
        | [|x|] -> x
        | x -> String.concat " * " x |> sprintf "struct (%s)"
    and op s d a =
        let jp (a, b) =
            let args = args b
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "closure%i(%s)" (closure (a,b)).tag args
        let free_vars do_annot x =
            let f (L(i,t)) = if do_annot then sprintf "v%i : %s" i (tyv t) else sprintf "v%i" i
            match data_free_vars x with
            | [||] -> "()"
            | [|x|] -> f x
            | x -> Array.map f x |> String.concat ", " |> sprintf "struct (%s)"
        let simple x = 
            match d with
            | None -> x
            | Some d -> match free_vars true d with "()" -> x | d -> sprintf "let %s = %s" d x
            |> line s
        let complex f =
            match d with
            | None -> f s : unit
            | Some d -> match free_vars true d with "()" -> f s | d -> line s (sprintf "let %s =" d); f (indent s)
        let layout_vars a =
            let f i x =
                match x with
                | WV i' -> sprintf "l%i = v%i" i i'
                | WLit x -> sprintf "l%i = %s" i (lit x)
            a |> data_term_vars |> Array.mapi f |> String.concat "; "
        let layout_index i x =
            x |> Array.map (fun (L(i',_)) -> sprintf "v%i.l%i" i i')
            |> String.concat ", "
            |> function "" -> "()" | x -> x
            |> simple
        match a with
        | TyMacro a -> a |> List.map (function CMText x -> x | CMTerm x -> term_vars x | CMType x -> ty x) |> String.concat "" |> simple
        | TyIf(cond,tr,fl) ->
            complex <| fun s ->
            line s (sprintf "if %s then" (term_vars cond))
            binds (indent s) tr
            match fl with
            | [|TyLocalReturnData(DB,_)|] -> ()
            | _ ->
                line s "else"
                binds (indent s) fl
        | TyJoinPoint(a,args) -> simple (jp (a, args))
        | TyWhile(a,b) ->
            complex <| fun s ->
            line s (sprintf "while %s do" (jp a))
            binds (indent s) b
        | TyIntSwitch(i,on_succ,on_fail) ->
            complex <| fun s ->
            line s (sprintf "match v%i with" i)
            Array.iteri (fun i x ->
                line s (sprintf "| %i ->" i)
                binds (indent s) x
                ) on_succ
            line s "| _ ->"
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
            let mutable i = -1
            if Map.exists (fun k _ -> i <- i+1; k = a) c.cases = false then raise_codegen_error "Compiler error: Union key not found."
            let vars =
                match data_term_vars b with
                | [||] -> ""
                | x -> Array.map show_w x |> String.concat ", " |> sprintf "(%s)"
            match c.layout with
            | UHeap -> sprintf "UH%i_%i%s" (uheap c.cases).tag i vars
            | UStack -> sprintf "US%i_%i%s" (ustack c.cases).tag i vars
            |> simple
        | TyLayoutToHeap(a,b) -> sprintf "{%s} : Heap%i" (layout_vars a) (heap b).tag |> simple
        | TyLayoutToHeapMutable(a,b) -> sprintf "{%s} : Mut%i" (layout_vars a) (mut b).tag |> simple
        | TyLayoutIndexAll(L(i,(a,lay))) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i
        | TyLayoutIndexByKey(L(i,(a,lay)),key) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.iter2 (fun (L(i',_)) b ->
                line s (sprintf "v%i.l%i <- %s" i i' (show_w b))
                ) (data_free_vars a) (data_term_vars c)
        | TyArrayCreate(a,b) -> simple (sprintf "Array.zeroCreate<%s> %s" (ty a) (term_vars b))
        | TyFailwith(a,b) -> simple (sprintf "failwith<%s> %s" (ty a) (term_vars b))
        | TyOp(op,l) ->
            match op, l with
            | Apply,[a;b] -> sprintf "%s %s" (term_vars a) (term_vars b)
            | Dyn,[a] -> term_vars a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringLength, [a] -> sprintf "%s.Length" (term_vars a)
            | StringIndex, [a;b] -> sprintf "%s.[%s]" (term_vars a) (term_vars b)
            | StringSlice, [a;b;c] -> sprintf "%s.[%s..%s]" (term_vars a) (term_vars b) (term_vars c)
            | ArrayIndex, [a;b] -> sprintf "%s.[%s]" (term_vars a) (term_vars b)
            | ArrayIndexSet, [a;b;c] -> sprintf "%s.[%s] <- %s" (term_vars a) (term_vars b) (term_vars c) 
            | ArrayLength, [a] -> sprintf "%s.Length" (term_vars a)

            // Math
            | Add, [a;b] -> sprintf "%s + %s" (term_vars a) (term_vars b)
            | Sub, [a;b] -> sprintf "%s - %s" (term_vars a) (term_vars b)
            | Mult, [a;b] -> sprintf "%s * %s" (term_vars a) (term_vars b)
            | Div, [a;b] -> sprintf "%s / %s" (term_vars a) (term_vars b)
            | Mod, [a;b] -> sprintf "%s %% %s" (term_vars a) (term_vars b)
            | Pow, [a;b] -> sprintf "%s ** %s" (term_vars a) (term_vars b)
            | LT, [a;b] -> sprintf "%s < %s" (term_vars a) (term_vars b)
            | LTE, [a;b] -> sprintf "%s <= %s" (term_vars a) (term_vars b)
            | EQ, [a;b] -> sprintf "%s = %s" (term_vars a) (term_vars b)
            | NEQ, [a;b] -> sprintf "%s <> %s" (term_vars a) (term_vars b)
            | GT, [a;b] -> sprintf "%s > %s" (term_vars a) (term_vars b)
            | GTE, [a;b] -> sprintf "%s >= %s" (term_vars a) (term_vars b)
            | BoolAnd, [a;b] -> sprintf "%s && %s" (term_vars a) (term_vars b)
            | BoolOr, [a;b] -> sprintf "%s || %s" (term_vars a) (term_vars b)
            | BitwiseAnd, [a;b] -> sprintf "%s & %s" (term_vars a) (term_vars b)
            | BitwiseOr, [a;b] -> sprintf "%s | %s" (term_vars a) (term_vars b)
            | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (term_vars a) (term_vars b)

            | ShiftLeft, [a;b] -> sprintf "%s << %s" (term_vars a) (term_vars b)
            | ShiftRight, [a;b] -> sprintf "%s >> %s" (term_vars a) (term_vars b)

            | Neg, [x] -> sprintf " -%s" (term_vars x)
            | Log, [x] -> sprintf "log %s" (term_vars x)
            | Exp, [x] -> sprintf "exp %s" (term_vars x)
            | Tanh, [x] -> sprintf "tanh %s" (term_vars x)
            | Sqrt, [x] -> sprintf "sqrt %s" (term_vars x)
            | Hash, [x] -> sprintf "hash %s" (term_vars x)
            | NanIs, [x] -> 
                match x with
                | DLit(LitFloat32 _) | DV(L(_,YPrim Float32T)) -> sprintf "System.Single.IsNaN(%s)" (term_vars x)
                | DLit(LitFloat64 _) | DV(L(_,YPrim Float64T)) -> sprintf "System.Double.IsNaN(%s)" (term_vars x)
                | _ -> raise_codegen_error "Compiler error: Invalid type in NanIs."
            | UnionTag, [DV(L(i,YUnion h))] -> 
                let ty =
                    let h = h.Item
                    match h.layout with
                    | UHeap -> sprintf "UH%i" (uheap h.cases).tag
                    | UStack -> sprintf "US%i" (ustack h.cases).tag
                sprintf "(fst (Reflection.FSharpValue.GetUnionFields(v%i, typeof<%s>))).Tag" i ty // TODO: Stopgap measure for now. Replace this with something more efficient.
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> simple
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
            line s (sprintf "method%i (%s) : %s =" x.tag (args_tys x.free_vars) (ty x.range))
            binds (indent s) x.body
            )
    and closure : _ -> ClosureRec =
        jp (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=data_free_vars domain_args; range=range; body=body}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s x ->
            let domain = 
                match x.domain |> Array.map (fun (L(i,t)) -> sprintf "v%i : %s" i (tyv t)) with
                | [||] -> "()"
                | [|x|] -> sprintf "(%s)" x
                | x -> String.concat ", " x |> sprintf "struct (%s)"
            line s (sprintf "closure%i (%s) %s : %s =" x.tag (args_tys x.free_vars) domain (ty x.range))
            binds (indent s) x.body
            )

    let main = StringBuilder()
    binds {text=main; indent=0} x

    let program = StringBuilder()
    types |> Seq.iteri (fun i x -> program.Append(if i = 0 then "type " else "and ").Append(x) |> ignore)
    functions |> Seq.iteri (fun i x -> program.Append(if i = 0 then "let rec " else "and ").Append(x) |> ignore)
    program.Append(main).ToString()
