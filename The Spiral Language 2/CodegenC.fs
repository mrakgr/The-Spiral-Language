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
    | LitBool x -> if x then "1" else "0"

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
    | BoolT -> "_Bool"
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
        | x -> Array.map show_w x |> String.concat ", " |> sprintf "create_Tuple%i(%s)" (tuple_term_vars x).tag
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
            | JPClosure(a,b) -> sprintf "create_Closure%i(%s)" (closure (a,b)).tag args
        let simple x = return' s ret x
        let layout_index free_vars i_v =
            let v = free_vars |> Array.map (fun (L(i_free_var,_)) -> sprintf "v%i->l%i" i_v i_free_var)
            match ret with
            | BindsTailEnd when 0 < v.Length -> let v = String.concat ", " v in $"return create_Tuple{(tuple_tyv free_vars).tag}({v});"
            | BindsTailEnd -> ""
            | BindsLocal x -> Array.map2 (fun (L(i,_)) x -> $"v{i} = {x};") x v |> String.concat " "
            |> line s 
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
            line s (sprintf "switch (v%i) {" i)
            Array.iteri (fun i x ->
                line s (sprintf "case %i:" i)
                let s = indent s
                binds s ret x
                match ret with 
                | BindsLocal _ -> line s "break;"
                | BindsTailEnd -> ()
                ) on_succ
            line s "default:"
            binds (indent s) ret on_fail
            line s "}"
        | TyUnionUnbox(is,x,on_succs,on_fail) ->
            let case_tags = x.Item.tags
            let accessor = match x.Item.layout with UHeap -> "->" | UStack -> "."
            let i_label_fail, i_label_exit = tmp(), tmp()
            match is with
            | [L(i_tag,_)] ->
                line s (sprintf "switch (v%i%stag) {" i_tag accessor)
            | L(i_tag,_) :: l' ->
                let i_head = tmp()
                line s $"int tmp{i_head} = v{i_tag}{accessor}tag;"
                let cond = 
                    let l = $"tmp{i_head}"
                    let l' = l' |> List.map (fun (L(i_tag,_)) -> $"v{i_tag}{accessor}tag")
                    List.pairwise (l :: l')
                    |> List.map (fun (a,b) -> $"{a} != {b}")
                    |> String.concat " || "
                line s $"if ({cond}) goto MatchFail{i_label_fail};"
                line s (sprintf "switch (tmp%i) {" i_head)
            | [] -> raise_codegen_error "Compiler error: Expected at least one case in TyUnionUnbox."
            Map.iter (fun k (a,b) ->
                let i_case = case_tags.[k]
                line s (sprintf "case %i: // %s" i_case k)
                let s = indent s
                List.iter2 (fun (L(i_tag,_)) a ->
                    let vars = data_free_vars a
                    if 0 < vars.Length then
                        let i = tmp()
                        line s $"struct Tuple{(tuple_tyv vars).tag} tmp{i} = v{i_tag}{accessor}data.case{i_case};"
                        vars |> Array.mapi (fun i_sub (L(i_var,t)) ->
                            $"{tyv t} v{i_var} = tmp{i}.v{i_sub};"
                            )
                        |> String.concat " " |> line s
                    ) is a
                binds s ret b
                match ret with 
                | BindsLocal _ -> line s $"goto MatchExit{i_label_exit};"
                | BindsTailEnd -> ()
                ) on_succs
            line s "}"
            on_fail |> Option.iter (fun b ->
                line s $"MatchFail{i_label_fail}: ;"
                binds (indent s) ret b
                )
            match ret with 
            | BindsLocal _ -> line s $"MatchExit{i_label_exit}: ;"
            | BindsTailEnd -> ()
        | TyUnionBox(a,b,c) ->
            let c = c.Item
            let i = c.tags.[a]
            let vars = data_term_vars b |> Array.map show_w |> String.concat ", "
            match c.layout with
            | UHeap -> sprintf "create_UH%i_%i(%s)" (uheap c.cases).tag i vars
            | UStack -> sprintf "create_US%i_%i(%s)" (ustack c.cases).tag i vars
            |> simple
        | TyLayoutToHeap(a,b) -> simple $"create_Heap{(heap b).tag}({args (data_free_vars a)})"
        | TyLayoutToHeapMutable(a,b) -> simple $"create_Mut{(mut b).tag}({args (data_free_vars a)})"
        | TyLayoutIndexAll(L(i_v,(a,lay))) -> layout_index (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars i_v
        | TyLayoutIndexByKey(L(i_v,(a,lay)),key) -> layout_index (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] i_v
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.map2 (fun (L(i',_)) b ->
                sprintf "v%i->l%i = %s;" i i' (show_w b)
                ) (data_free_vars a) (data_term_vars c)
            |> String.concat " " |> line s
        | TyArrayCreate(a,b) -> simple (sprintf "create_Array%i(%s)" (array a).tag (tup b))
        | TyArrayLiteral(a,b) ->
            let i_tag = (array a).tag
            if List.isEmpty b then simple $"create_Array{i_tag}(0)"
            else 
                let i_tmp = tmp()
                line s $"Array{i_tag} tmp{i_tmp} = create_Array{i_tag}({List.length b});"
                b |> List.mapi (fun i x -> $"tmp{i_tmp}.buffer[{i}] = {tup x};") |> String.concat " " |> line s
                simple $"tmp{i_tmp}"
        | TyArrayLength(a,b) -> simple $"{b}->length"
        | TyStringLength(a,b) -> simple $"strlen({tup b})" // TODO: Replace this with a proper string.
        | TyFailwith(a,b) -> line s $"puts({tup b});"; line s $"exit(-1);"
        | TyConv(a,b) ->
            let b = tup b
            let er() = raise_codegen_error $"Compiler error: Unexpected type in Conv. Got: {show_ty a}"
            match a with
            | YPrim a' ->
                match a' with
                | Int8T | Int16T | Int32T | Int64T 
                | UInt8T | UInt16T | UInt32T | UInt64T 
                | Float32T | Float64T -> $"({prim a'}){b}"
                | _ -> er()
            | _ -> er()
            |> simple
        | TyOp(op,l) ->
            match op, l with
            | Apply,[a;b] -> sprintf "%s->funptr(%s)" (tup a) (tup b)
            | Dyn,[a] -> tup a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringIndex, [a;b] -> sprintf "%s[%s]" (tup a) (tup b) // TODO: Do the string operation properly.
            | StringSlice, [a;b;c] -> raise_codegen_error "Compiler error: StringSlice not implemented yet."
            | ArrayIndex, [a;b] -> 
                match a with
                | DV(L(_,YArray t)) -> sprintf "index_Array%i(%s,%s)" ((array t).tag) (tup a) (tup b)
                | _ -> raise_codegen_error "Compiler error: Expected an array in ArrayIndex."
            | ArrayIndexSet, [a;b;c] -> 
                match a with
                | DV(L(_,YArray t)) -> sprintf "set_Array%i(%s,%s,%s)" ((array t).tag) (tup a) (tup b) (tup c) 
                | _ -> raise_codegen_error "Compiler error: Expected an array in ArrayIndex."
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
            | Log, [x] -> 
                match x with
                | DV(L(_,YPrim Float32T)) | DLit (LitFloat32 _) -> sprintf "logf(%s)" (tup x)
                | DV(L(_,YPrim Float64T)) | DLit (LitFloat64 _) -> sprintf "log(%s)" (tup x)
                | _ -> raise_codegen_error "Compiler error: Expected a float."
            | Exp, [x] ->
                match x with
                | DV(L(_,YPrim Float32T)) | DLit (LitFloat32 _) -> sprintf "expf(%s)" (tup x)
                | DV(L(_,YPrim Float64T)) | DLit (LitFloat64 _) -> sprintf "exp(%s)" (tup x)
                | _ -> raise_codegen_error "Compiler error: Expected a float."
            | Tanh, [x] -> 
                match x with
                | DV(L(_,YPrim Float32T)) | DLit (LitFloat32 _) -> sprintf "tanhf(%s)" (tup x)
                | DV(L(_,YPrim Float64T)) | DLit (LitFloat64 _) -> sprintf "tanh(%s)" (tup x)
                | _ -> raise_codegen_error "Compiler error: Expected a float."
            | Sqrt, [x] ->
                match x with
                | DV(L(_,YPrim Float32T)) | DLit (LitFloat32 _) -> sprintf "sqrtf(%s)" (tup x)
                | DV(L(_,YPrim Float64T)) | DLit (LitFloat64 _) -> sprintf "sqrt(%s)" (tup x)
                | _ -> raise_codegen_error "Compiler error: Expected a float."
            | NanIs, [x] -> sprintf "isnan(%s)" (tup x)
            | UnionTag, [DV(L(i,YUnion h))] ->
                match h.Item.layout with
                | UHeap -> $"v{i}->tag"
                | UStack -> $"v{i}.tag"
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
