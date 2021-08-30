module Spiral.Codegen.C

open Spiral
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval.Main
open Spiral.CodegenUtils
open System
open System.Text
open System.Collections.Generic

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
        | x -> string x
        |> sprintf "'%s'"
    | LitBool x -> if x then "true" else "false"

let prim = function
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
    | BoolT -> "bool"
    | StringT -> "char *" // TODO: I'll make this a proper reference type once I get everything else done.
    | CharT -> "char"

type UnionRec = {free_vars : Map<string, TyV[]>; tag : int}
type LayoutRec = {data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>; tag : int}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : TyV[]; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : string []}

type BindsReturn =
    | BindsTailEnd
    | BindsLocal of TyV []

let tuple (x : Ty []) : TupleRec = failwith "TODO"
let tuple_tyv (x : TyV[]) = x |> Array.map (fun (L(_,x)) -> x) |> tuple
let tuple_term_vars (x : TermVar []) = x |> Array.map (function WV(L(_,x)) -> x | WLit x -> lit_to_ty x) |> tuple
let array = failwith "TODO"
let function' = failwith "TODO"

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
    let show_w = function WV (L(i,_)) -> sprintf "v%i" i | WLit a -> lit a

    let tmp =
        let mutable i = 0
        fun () -> let x = i in i <- i + 1; x

    let rec return' s ret x =
        match ret with
        | BindsTailEnd -> sprintf "return %s;" x
        | BindsLocal d ->
            match d with
            | [||] -> sprintf "%s;" x
            | [|L(v_i,_)|] -> sprintf "v%i = %s;" v_i x
            | d ->
                let tmp_i = tmp()
                line s $"struct Tuple{(tuple_tyv d).tag} tmp{tmp_i} = {x};"
                d |> Array.mapi (fun i (L(v_i,_)) -> $"v{v_i} = tmp{tmp_i}.v{i};") |> String.concat " "
        |> line s
    and tyv = function
        | YUnion a ->
            let a = a.Item
            match a.layout with
            | UHeap -> sprintf "UH%i" (uheap a.cases).tag
            | UStack -> sprintf "US%i" (ustack a.cases).tag
        | YLayout(a,Heap) -> sprintf "Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i" (mut a).tag
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "Array%i" (array a).tag
        | YFun(a,b) -> sprintf "Closure%i" (function' a b).tag
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and args_tys x = x |> Array.map (fun (L(i,t)) -> sprintf "v%i : %s" i (tup_ty t)) |> String.concat ", "
    and binds (s : CodegenEnv) ret (x : TypedBind []) =
        Array.iter (fun x ->
            match x with
            | TyLet(d,trace,a) ->
                try let vars = data_free_vars d
                    Array.map (fun (L(i,t)) -> $"{tyv t} v{i};") vars |> String.concat " " |> line s
                    op s (BindsLocal vars) a 
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a,_) -> try op s ret a with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d',trace) ->
                try match ret with
                    | BindsTailEnd -> sprintf "return %s;" (tup d') |> line s
                    | BindsLocal d -> Array.map2 (fun (L(i,_)) b -> $"v{i} = {show_w b};") d (data_term_vars d') |> String.concat " " |> line s
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) x
    and tup x =
        match data_term_vars x with
        | [||] -> ""
        | [|x|] -> show_w x
        | x -> Array.map show_w x |> String.concat ", " |> sprintf "create_tuple%i(%s)" (tuple_term_vars x).tag
    and tup_ty x =
        let vars = env.ty_to_data x |> data_free_vars
        match Array.map (fun (L(_,x)) -> tyv x) vars with
        | [||] -> "void"
        | [|x|] -> x
        | x -> sprintf "Tuple%i" (tuple_tyv vars).tag
    and op s (ret : BindsReturn) a =
        let jp (a, b) =
            let args = args b
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "create_closure%i(%s)" (closure (a,b)).tag args
        let simple x = return' s ret x
        let layout_vars a =
            let f i x =
                match x with
                | WV(L(i',_)) -> sprintf "l%i = v%i" i i'
                | WLit x -> sprintf "l%i = %s" i (lit x)
            a |> data_term_vars |> Array.mapi f |> String.concat "; "
        let layout_index i x =
            x |> Array.map (fun (L(i',_)) -> sprintf "v%i.l%i" i i')
            |> String.concat ", "
            |> function "" -> () | x -> simple x
        let length (a,b) =
            match a with
            | YPrim UInt8T -> sprintf "System.Convert.ToByte %s.Length" (tup b)
            | YPrim UInt16T -> sprintf "System.Convert.ToUInt16 %s.Length" (tup b)
            | YPrim UInt32T -> sprintf "System.Convert.ToUInt32 %s.Length" (tup b)
            | YPrim UInt64T -> sprintf "System.Convert.ToUInt64 %s.Length" (tup b)
            | YPrim Int8T -> sprintf "System.Convert.ToSByte %s.Length" (tup b)
            | YPrim Int16T -> sprintf "System.Convert.ToInt16 %s.Length" (tup b)
            | YPrim Int32T -> sprintf "%s.Length" (tup b)
            | YPrim Int64T -> sprintf "System.Convert.ToInt64 %s.Length" (tup b)
            | _ -> raise_codegen_error "Compiler error: Expected an int in length"
            |> simple
        match a with
        | TyMacro a -> a |> List.map (function CMText x -> x | CMTerm x -> tup x | CMType x -> tup_ty x) |> String.concat "" |> simple
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if (%s) {" (tup cond))
            binds (indent s) ret tr
            line s "} else {"
            binds (indent s) ret fl
            line s "}"
        | TyJoinPoint(a,args) -> simple (jp (a, args))
        | TyWhile(a,b) ->
            line s (sprintf "while (%s) {" (jp a))
            binds (indent s) ret b
            line s "}"
        | TyIntSwitch(i,on_succ,on_fail) ->
            line s (sprintf "switch (v%i.tag) {" i)
            Array.iteri (fun i x ->
                line s (sprintf "case %i:" i)
                binds (indent s) ret x
                line (indent s) "break;"
                ) on_succ
            line s "default:"
            binds (indent s) ret on_fail
            line s "}"
        | TyUnionUnbox([L(i_tag,_)],x,on_succs,on_fail) ->
            let case_tags = x.Item.tags
            let accessor = match x.Item.layout with UHeap -> "->" | UStack -> "."
            line s (sprintf "switch (v%i%stag) {" i_tag accessor)
            Map.iter (fun k (a,b) ->
                let i_case = case_tags.[k]
                line s (sprintf "case %i: // %s" i_case k)
                let s = indent s
                match a with
                | [a] ->
                    let vars = data_free_vars a
                    if 0 < vars.Length then
                        let i = tmp()
                        line s $"struct Tuple{(tuple_tyv vars).tag} tmp{i} = v{i_tag}{accessor}data.case{i_case};"
                        vars |> Array.mapi (fun i_sub (L(i_var,_)) ->
                            $"v{i_var} = tmp{i}.v{i_sub};"
                            )
                        |> String.concat " " |> line s
                | _ -> failwith "Compiler error. Expected only a single list."
                binds (indent s) ret b
                ) on_succs
            on_fail |> Option.iter (fun b ->
                line s "default:"
                binds (indent s) ret b
                )
            line s "}"
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
            |> simple
        | TyLayoutToHeap(a,b) -> 
            let a = layout_vars a
            simple (if a = "" then sprintf "Heap%i()" (heap b).tag else sprintf "{%s} : Heap%i" a (heap b).tag)
        | TyLayoutToHeapMutable(a,b) ->
            let a = layout_vars a
            simple (if a = "" then sprintf "Mut%i()" (mut b).tag else sprintf "{%s} : Mut%i" a (mut b).tag)
        | TyLayoutIndexAll(L(i,(a,lay))) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i
        | TyLayoutIndexByKey(L(i,(a,lay)),key) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.iter2 (fun (L(i',_)) b ->
                line s (sprintf "v%i.l%i <- %s" i i' (show_w b))
                ) (data_free_vars a) (data_term_vars c)
        | TyArrayLiteral(a,b) -> simple <| sprintf "[|%s|]" (List.map tup b |> String.concat "; ")
        | TyArrayCreate(a,b) ->
            match b with
            | DLit(LitInt32 _) | DV(L(_,YPrim Int32T)) -> simple (sprintf "Array.zeroCreate<%s> (%s)" (tup_ty a) (tup b))
            | _ -> simple (sprintf "Array.zeroCreate<%s> (System.Convert.ToInt32(%s))" (tup_ty a) (tup b))
        | TyArrayLength(a,b) -> length (a,b)
        | TyStringLength(a,b) -> length (a,b)
        | TyFailwith(a,b) -> simple (sprintf "failwith<%s> %s" (tup_ty a) (tup b))
        | TyConv(a,b) ->
            let b = tup b
            match a with
            | YPrim Int8T -> $"int8 {b}"
            | YPrim Int16T -> $"int16 {b}"
            | YPrim Int32T -> $"int32 {b}"
            | YPrim Int64T -> $"int64 {b}"
            | YPrim UInt8T -> $"uint8 {b}"
            | YPrim UInt16T -> $"uint16 {b}"
            | YPrim UInt32T -> $"uint32 {b}"
            | YPrim UInt64T -> $"uint64 {b}"
            | YPrim Float32T -> $"float32 {b}"
            | YPrim Float64T -> $"float {b}"
            | _ -> raise_codegen_error $"Compiler error: Unexpected type in Conv. Got: {show_ty a}"
            |> simple
        | TyOp(op,l) ->
            match op, l with
            | Apply,[a;b] -> sprintf "%s %s" (tup a) (tup b)
            | Dyn,[a] -> tup a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringIndex, [a;b] -> sprintf "%s.[int %s]" (tup a) (tup b)
            | StringSlice, [a;b;c] -> sprintf "%s.[int %s..int %s]" (tup a) (tup b) (tup c)
            | ArrayIndex, [a;b] -> sprintf "%s.[int %s]" (tup a) (tup b)
            | ArrayIndexSet, [a;b;c] -> sprintf "%s.[int %s] <- %s" (tup a) (tup b) (tup c) 

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
            | BitwiseAnd, [a;b] -> sprintf "%s &&& %s" (tup a) (tup b)
            | BitwiseOr, [a;b] -> sprintf "%s ||| %s" (tup a) (tup b)
            | BitwiseXor, [a;b] -> sprintf "%s ^^^ %s" (tup a) (tup b)

            | ShiftLeft, [a;b] -> sprintf "%s <<< %s" (tup a) (tup b)
            | ShiftRight, [a;b] -> sprintf "%s >>> %s" (tup a) (tup b)

            | Neg, [x] -> sprintf " -%s" (tup x)
            | Log, [x] -> sprintf "log %s" (tup x)
            | Exp, [x] -> sprintf "exp %s" (tup x)
            | Tanh, [x] -> sprintf "tanh %s" (tup x)
            | Sqrt, [x] -> sprintf "sqrt %s" (tup x)
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
            |> simple
    and heap : _ -> LayoutRec = layout (fun s x ->
        let b = x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "l%i : %s" i (tyv t)) |> String.concat "; "
        if b = "" then line s (sprintf "Heap%i() = class end" x.tag)
        else line s (sprintf "Heap%i = {%s}" x.tag b)
        )
    and mut : _ -> LayoutRec = layout (fun s x ->
        let b = x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "mutable l%i : %s" i (tyv t)) |> String.concat "; "
        if b = "" then line s (sprintf "Mut%i() = class end" x.tag)
        else line s (sprintf "Mut%i = {%s}" x.tag b)
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
            line s (sprintf "closure%i (%s) %s : %s =" x.tag (args_tys x.free_vars) domain (tup_ty x.range))
            binds (indent s) x.body
            )

    let main = StringBuilder()
    binds {text=main; indent=0} x

    let program = StringBuilder()
    types |> Seq.iteri (fun i x -> program.Append(if i = 0 then "type " else "and ").Append(x) |> ignore)
    functions |> Seq.iteri (fun i x -> program.Append(if i = 0 then "let rec " else "and ").Append(x) |> ignore)
    program.Append(main).ToString()
