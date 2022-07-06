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

let term_vars_to_tys x = x |> Array.map (function WV(L(_,t)) -> t | WLit x -> YPrim (lit_to_primitive_type x))

type UnionRec = {tag : int; free_vars : Map<string, TyV[]>; is_degenerate : bool}
type LayoutRec = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : Ty []}

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
    | CharT -> "char"
    | StringT -> "struct * String"

let codegen (env : PartEvalResult) (x : TypedBind []) =
    let types = ResizeArray()
    let functions = ResizeArray()

    let print show r =
        let s_typ = {text=StringBuilder(); indent=0}
        let s_fun = {text=StringBuilder(); indent=0}
        show s_typ s_fun r
        let f (a : _ ResizeArray) (b : CodegenEnv) = 
            let text = b.text.ToString()
            if text <> "" then a.Add(text)
        f types s_typ
        f functions s_fun

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
            if dirty then print show r
            r

    let union show =
        let dict = Dictionary(HashIdentity.Reference)
        let f (a : Union) : UnionRec = 
            let free_vars = a.Item.cases |> Map.map (fun _ -> env.ty_to_data >> data_free_vars)
            {free_vars=free_vars; tag=dict.Count; is_degenerate=a.Item.is_degenerate}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let jp is_type f show =
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

    let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "

    let tmp =
        let mutable i = 0
        fun () -> let x = i in i <- i + 1; x

    let tyvs_to_tys (x : TyV []) = Array.map (fun (L(i,t)) -> t) x

    let rec binds (defs : CodegenEnv) (s : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) = 
        let tup_destruct (a,b) =
            Array.map2 (fun (L(i,_)) b -> 
                match b with
                | WLit b -> $"v{i} = {lit b};"
                | WV i' -> $"v{i} = v{i'};"
                ) a b |> String.concat " "
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
                    | BindsTailEnd -> line s $"return {tup_data d};"
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) stmts
    and show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
    and args' b = data_term_vars b |> Array.map show_w |> String.concat ", "
    and tup_term_vars x = 
        let args = Array.map show_w x |> String.concat ", "
        if 1 < args.Length then sprintf "Tuple%i(%s)" (tup' (term_vars_to_tys x)).tag args else args
    and tup_data x = tup_term_vars (data_term_vars x)
    and tup_tyvs (x : TyV []) = Array.map WV x |> tup_term_vars
    and tup_ty_tyvs (x : TyV []) =
        match tyvs_to_tys x with
        | [||] -> "void"
        | [|x|] -> tyv x
        | x -> sprintf "struct Tuple%i" (tup' x).tag
    and tyv = function
        | YUnion a ->
            match a.Item.layout with
            | UHeap -> sprintf "struct * UH%i" (uheap a).tag
            | UStack -> sprintf "struct US%i" (ustack a).tag
        | YLayout(a,Heap) -> sprintf "struct * Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "struct * Mut%i" (mut a).tag
        | YMacro a -> 
            let f x =
                match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
                | [||] -> "void"
                | x -> String.concat ", " x
            a |> List.map (function Text a -> a | Type a -> f a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "struct * Array%i" (carray a).tag
        | YFun(a,b) -> sprintf "struct * Fun%i" (cfun (a,b)).tag
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
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
            if x = infinityf then "HUGE_VALF"
            elif x = -infinityf then "-HUGE_VALF"
            elif Single.IsNaN x then "NAN"
            else x.ToString("R") |> sprintf "%sf"
        | LitFloat64 x ->
            if x = infinity then "HUGE_VAL"
            elif x = -infinity then "-HUGE_VAL"
            elif Double.IsNaN x then "NAN"
            else x.ToString("R") 
        | LitString x -> cstring_lit x
            //let strb = StringBuilder(x.Length+2)
            //strb.Append '"' |> ignore
            //String.iter (function
            //    | '"' -> strb.Append "\\\"" 
            //    | '\b' -> strb.Append @"\b"
            //    | '\t' -> strb.Append @"\t"
            //    | '\n' -> strb.Append @"\n"
            //    | '\r' -> strb.Append @"\r"
            //    | '\\' -> strb.Append @"\\"
            //    | x -> strb.Append x
            //    >> ignore 
            //    ) x
            //strb.Append '"' |> ignore
            //strb.ToString()
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
    and op defs s (ret : BindsReturn) a =
        let return' (x : string) =
            match ret with
            | BindsTailEnd -> line s $"return {x};"
            | BindsLocal [||] -> line s $"{x};"
            | BindsLocal [|L(i,_)|] -> line s $"v{i} = {x};"
            | BindsLocal ret ->
                let tmp_i = tmp()
                line defs $"{tup_ty_tyvs ret} tmp{tmp_i};"
                line s $"tmp{tmp_i} = {x};"
                Array.mapi (fun i (L(i',_)) -> $"v{i'} = tmp{tmp_i}.v{i};") ret |> String.concat " "
                |> line s
        let jp (a,b) =
            let args = args b
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "Closure%i(%s)" (closure (a,b)).tag args
        let layout_index (x'_i : int) (x' : TyV []) =
            let gs = Array.map (fun (L(i',_)) -> $"v{x'_i}->v{i'}") x'
            match ret with
            | BindsTailEnd -> 
                let gs = String.concat ", " gs
                let x = tyvs_to_tys x'
                if x.Length <= 1 then $"return {gs};" else $"return Tuple{(tup' x).tag}({gs});" 
            | BindsLocal x -> Array.map2 (fun (L(i,_)) g -> $"v{i} = {g};") x gs |> String.concat " "
            |> line s
        match a with
        | TyMacro a ->
            a |> List.map (function
                | CMText x -> x
                | CMTerm x -> tup_data x
                | CMType x -> env.ty_to_data x |> data_free_vars |> tup_ty_tyvs
                ) |> String.concat "" |> return'
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if (%s){" (tup_data cond))
            binds defs (indent s) ret tr
            line s "else {"
            binds defs (indent s) ret fl
            line s "}"
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyWhile(a,b) ->
            line s (sprintf "while (%s){" (jp a))
            binds defs (indent s) (BindsLocal [||]) b
            line s "}"
        | TyIntSwitch(v_i,on_succ,on_fail) ->
            line s (sprintf "switch (v%i) {" v_i) // TODO: Check the C switch syntax.
            Array.iteri (fun i x ->
                line s (sprintf "case %i:" i)
                binds defs (indent s) ret x
                line (indent s) "break;"
                ) on_succ
            line s "default:"
            binds defs (indent s) ret on_fail
            line s "}"
        | TyUnionUnbox(is,x,on_succs,on_fail) ->
            let case_tags = x.Item.tags
            let dot_tag = if x.Item.is_degenerate then "" else ".tag"
            let head = List.head is |> fun (L(i,_)) -> $"v{i}{dot_tag}"
            List.pairwise is
            |> List.map (fun (L(i,_), L(i',_)) -> $"v{i}{dot_tag} == v{i'}{dot_tag}")
            |> String.concat " && "
            |> function "" -> head | x -> $"{x} ? {head} : -1"
            |> sprintf "switch (%s) {" |> line s
            Map.iter (fun k (a,b) ->
                let union_i = case_tags.[k]
                line s $"case {union_i}:"
                List.iter2 (fun (L(data_i,_)) a ->
                    data_free_vars a |> Array.mapi (fun field_i (L(v_i,t)) ->
                        $"{tyv t} v{v_i} = v{data_i}).case{union_i}.v{field_i};"
                        )
                    |> String.concat " " |> line (indent s)
                    ) is a
                binds defs (indent s) ret b
                line s "break;"
                ) on_succs
            on_fail |> Option.iter (fun b ->
                line s "default: "
                binds defs (indent s) ret b
                )
            line s "}"
        | TyUnionBox(a,b,c') ->
            let c = c'.Item
            let i = c.tags.[a]
            if c.is_degenerate then return' (sprintf "%i" i)
            else
                let vars = args' b
                match c.layout with
                | UHeap -> sprintf "UH%i_%i(%s)" (uheap c').tag i vars
                | UStack -> sprintf "US%i_%i(%s)" (ustack c').tag i vars
                |> return'
        | TyLayoutToHeap(a,b) -> sprintf "Heap%i(%s)" (heap b).tag (args' a) |> return'
        | TyLayoutToHeapMutable(a,b) -> sprintf "Mut%i(%s)" (mut b).tag (args' a) |> return'
        | TyLayoutIndexAll(L(i,(a,lay))) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i
        | TyLayoutIndexByKey(L(i,(a,lay)),key) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.iter2 (fun (L(i',_)) b -> line s $"v{i}->v{i'} = {show_w b}") (data_free_vars a) (data_term_vars c)
        | TyArrayLiteral(a,b) -> carray_literal a b
        | TyArrayCreate(a,b) -> carray_create a b
        | TyFailwith(a,b) -> line s "exit(-1);"
        | TyConv(a,b) -> return' $"({tyv a}){tup_data b}"
        | TyArrayLength(_,b) | TyStringLength(_,b) -> return' $"{tup_data b}->len;"
        | TyOp(op,l) ->
            let tup = tup_data
            match op, l with
            | Apply,[a;b] -> $"{tup a}({args' b})"
            | Dyn,[a] -> tup a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringIndex, [a;b] -> sprintf "%s->ptr[%s]" (tup a) (tup b)
            | StringSlice, [a;b;c] -> raise_codegen_error "String slice is not supported natively in the C backend. Use a library implementation instead."
            | ArrayIndex, [a;b] -> sprintf "%s->ptr[%s]" (tup a) (tup b)
            | ArrayIndexSet, [a;b;c] -> 
                match tup c with
                | "" as c -> c
                | c -> sprintf "%s->ptr[%s] = %s" (tup a) (tup b) c
            // Math
            | Add, [a;b] -> sprintf "%s + %s" (tup a) (tup b)
            | Sub, [a;b] -> sprintf "%s - %s" (tup a) (tup b)
            | Mult, [a;b] -> sprintf "%s * %s" (tup a) (tup b)
            | Div, [a;b] -> sprintf "%s / %s" (tup a) (tup b)
            | Mod, [a;b] -> sprintf "%s %% %s" (tup a) (tup b)
            | Pow, [a;b] -> sprintf "pow(%s,%s)" (tup a) (tup b)
            | LT, [a;b] -> sprintf "%s < %s" (tup a) (tup b)
            | LTE, [a;b] -> sprintf "%s <= %s" (tup a) (tup b)
            | EQ, [a;b] -> sprintf "%s == %s" (tup a) (tup b)
            | NEQ, [a;b] -> sprintf "%s != %s" (tup a) (tup b)
            | GT, [a;b] -> sprintf "%s > %s" (tup a) (tup b)
            | GTE, [a;b] -> sprintf "%s >= %s" (tup a) (tup b)
            | BoolAnd, [a;b] -> sprintf "%s && %s" (tup a) (tup b)
            | BoolOr, [a;b] -> sprintf "%s || %s" (tup a) (tup b)
            | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup a) (tup b)
            | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup a) (tup b)
            | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup a) (tup b)

            | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup a) (tup b)
            | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup a) (tup b)

            | Neg, [x] -> sprintf "-%s" (tup x)
            | Log, [x] -> sprintf "log(%s)" (tup x)
            | Exp, [x] -> sprintf "exp(%s)" (tup x)
            | Tanh, [x] -> sprintf "tanh(%s)" (tup x)
            | Sqrt, [x] -> sprintf "sqrt(%s)" (tup x)
            | NanIs, [x] -> sprintf "isnan(%s)" (tup x)
            | UnionTag, [DUnion(_,l) | DV(L(_,YUnion l)) as x] -> 
                let dot_tag = if l.Item.is_degenerate then "" else ".tag"
                sprintf "%s%s" (tup x) dot_tag
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> return'
    and tup' x = 
        tuple (fun s_typ s_fun x ->
            let name = sprintf "Tuple%i" x.tag
            line s_typ (sprintf "struct %s{" name)
            let args = x.tys |> Array.mapi (fun i x -> $"{tyv x} v{i}")
            args |> Array.iter (fun x -> line (indent s_typ) $"{x};")
            line s_typ "};"
            line s_fun (sprintf "static inline struct %s %s(%s){" name name (String.concat ", " args))
            line (indent s_fun) $"struct {name} x;"
            Array.init args.Length (fun i -> $"x.v{i} = v{i};") |> String.concat " " |> line (indent s_fun) 
            line (indent s_fun) $"return x;"
            line s_fun "}"
            ) x

    let main_defs = StringBuilder()
    let main_s = StringBuilder()
    binds {text=main_defs; indent=0} {text=main_s; indent=0} BindsTailEnd x

    //let program = StringBuilder()
    //types |> Seq.iteri (fun i x -> program.Append(if i = 0 then "type " else "and ").Append(x) |> ignore)
    //functions |> Seq.iteri (fun i x -> program.Append(if i = 0 then "let rec " else "and ").Append(x) |> ignore)
    //program.Append(main).ToString()

    failwith ""