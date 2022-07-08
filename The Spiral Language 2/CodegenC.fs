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
let binds_last_data x = x |> Array.last |> function TyLocalReturnData(x,_) | TyLocalReturnOp(_,_,x) -> x | TyLet _ -> raise_codegen_error "Compiler error: Cannot find the return data of the last bind."

type UnionRec = {tag : int; free_vars : Map<string, TyV[]>}
type LayoutRec = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : Ty []}
type ArrayRec = {tag : int; ty : Ty}
type CFunRec = {tag : int; domain_args_ty : Ty[]; range : Ty}

let size_t = UInt32T
let codegen (env : PartEvalResult) (x : TypedBind []) =
    let imports = ResizeArray()
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
            {free_vars=free_vars; tag=dict.Count}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let jp f show =
        let dict = Dictionary(HashIdentity.Structural)
        let f x = 
            printf "%i" dict.Count
            f (x, dict.Count)
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

    let carray' show =
        let dict = Dictionary(HashIdentity.Structural)
        let f x = {tag=dict.Count; ty=x}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let cstring' show =
        let mutable dirty = true
        fun () ->
            if dirty then print show ()
            dirty <- false

    let cfun' show =
        let dict = Dictionary(HashIdentity.Structural)
        let f (a : Ty, b : Ty) = {tag=dict.Count; domain_args_ty=a |> env.ty_to_data |> data_free_vars |> Array.map (fun (L(_,t)) -> t); range=b}
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
            if dirty then print show r
            r

    let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "

    let tmp =
        let mutable i = 0
        fun () -> let x = i in i <- i + 1; x

    let import =
        let has_added = HashSet()
        fun x -> if has_added.Add(x) then imports.Add $"#include <{x}>"

    let cimport =
        let has_added = HashSet()
        fun x -> if has_added.Add(x) then imports.Add $"#include \"{x}\""

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
    and binds' (defs : CodegenEnv) (x : TypedBind []) =
        let s = {defs with text = StringBuilder()}
        binds defs s BindsTailEnd x
        defs.text.Append(s.text) |> ignore
    and show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
    and args' b = data_term_vars b |> Array.map show_w |> String.concat ", "
    and tup_term_vars x =
        let args = Array.map show_w x |> String.concat ", "
        if 1 < x.Length then sprintf "TupleCreate%i(%s)" (tup' (term_vars_to_tys x)).tag args else args
    and tup_data x = tup_term_vars (data_term_vars x)
    and tup_tyvs (x : TyV []) = Array.map WV x |> tup_term_vars
    and tup_ty_tyvs (x : TyV []) =
        match tyvs_to_tys x with
        | [||] -> "void"
        | [|x|] -> tyv x
        | x -> sprintf "Tuple%i" (tup' x).tag
    and tup_ty x = env.ty_to_data x |> data_free_vars |> tup_ty_tyvs
    and tyv = function
        | YUnion a ->
            match a.Item.layout with
            | UStack -> sprintf "US%i" (ustack a).tag
            | UHeap -> sprintf "UH%i *" (uheap a).tag
        | YLayout(a,Heap) -> sprintf "Heap%i *" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i *" (mut a).tag
        | YMacro a ->
            let f x =
                match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
                | [||] -> "void"
                | x -> String.concat ", " x
            a |> List.map (function Text a -> a | Type a -> f a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "Array%i *" (carray a).tag
        | YFun(a,b) -> sprintf "Fun%i *" (cfun (a,b)).tag
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and prim = function
        | Int8T -> "int8_t" 
        | Int16T -> "int16_t"
        | Int32T -> "int32_t"
        | Int64T -> "int64_t"
        | UInt8T -> "uint8_t"
        | UInt16T -> "uint16_t"
        | UInt32T -> "uint32_t"
        | UInt64T -> "uint64_t" // are defined in stdint.h
        | Float32T -> "float"
        | Float64T -> "double"
        | BoolT -> "bool" // is defined in stdbool.h
        | CharT -> "char"
        | StringT -> cstring(); "String *"
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
            if x = infinityf then "HUGE_VALF" // nan/inf macros are defined in math.h
            elif x = -infinityf then "-HUGE_VALF"
            elif Single.IsNaN x then "NAN"
            else x.ToString("R") |> add_dec_point |> sprintf "%sf"
        | LitFloat64 x ->
            if x = infinity then "HUGE_VAL"
            elif x = -infinity then "-HUGE_VAL"
            elif Double.IsNaN x then "NAN"
            else x.ToString("R") |> add_dec_point
        | LitString x ->
            cstring()
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
            |> sprintf "StringLit(%i, %s)" x.Length
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
            | JPClosure(a,b) -> sprintf "ClosureCreate%i(%s)" (closure (a,b)).tag args
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
            line s (sprintf "switch (v%i) {" v_i)
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
            let acs = match x.Item.layout with UHeap -> "->" | UStack -> "."
            let head = List.head is |> fun (L(i,_)) -> $"v{i}{acs}tag"
            List.pairwise is
            |> List.map (fun (L(i,_), L(i',_)) -> $"v{i}{acs}tag == v{i'}{acs}tag")
            |> String.concat " && "
            |> function "" -> head | x -> $"{x} ? {head} : -1"
            |> sprintf "switch (%s) {" |> line s
            Map.iter (fun k (a,b) ->
                let union_i = case_tags.[k]
                line s $"case {union_i}:"
                List.iter2 (fun (L(data_i,_)) a ->
                    data_free_vars a |> Array.mapi (fun field_i (L(v_i,t)) ->
                        $"{tyv t} v{v_i} = v{data_i}){acs}case{union_i}.v{field_i};"
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
        | TyLayoutToHeap(a,b) -> sprintf "HeapCreate%i(%s)" (heap b).tag (args' a) |> return'
        | TyLayoutToHeapMutable(a,b) -> sprintf "MutCreate%i(%s)" (mut b).tag (args' a) |> return'
        | TyLayoutIndexAll(L(i,(a,lay))) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i
        | TyLayoutIndexByKey(L(i,(a,lay)),key) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.iter2 (fun (L(i',_)) b -> line s $"v{i}->v{i'} = {show_w b}") (data_free_vars a) (data_term_vars c)
        | TyArrayLiteral(a,b) -> 
            let b = b |> List.map tup_data |> String.concat "," |> sprintf "{%s}"
            line s $"ArrayLit{(carray a).tag}({b.Length},{b})"
        | TyArrayCreate(a,b) -> line s $"ArrayCreate{(carray a).tag}({tup_data b})"
        | TyFailwith(a,b) -> 
            let fmt = "%s\\\n"
            line s ($"fprintf(stderr, \"{fmt}\", {tup_data b})")
            line s "exit(EXIT_FAILURE);" // TODO: Print out the error traces as well.
        | TyConv(a,b) -> return' $"({tyv a}){tup_data b}"
        | TyArrayLength(_,b) | TyStringLength(_,b) -> return' $"{tup_data b}->len;"
        | TyOp(op,l) ->
            let float_suffix = function
                | DV(L(_,YPrim Float32T)) | DLit(LitFloat32 _) -> "f"
                | _ -> ""
            match op, l with
            | Import,[DLit (LitString x)] -> import x; $"// #include <{x}>"
            | CImport,[DLit (LitString x)] -> cimport x; $"// #include \"{x}\""
            | Apply,[a;b] -> 
                match tup_data a, args' b with
                | a, "" -> $"{a}->fptr({a}->env)"
                | a, b -> $"{a}->fptr({a}->env, {b})"
            | Dyn,[a] -> tup_data a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringIndex, [a;b] -> sprintf "%s->ptr[%s]" (tup_data a) (tup_data b)
            | StringSlice, [a;b;c] -> raise_codegen_error "String slice is not supported natively in the C backend. Use a library implementation instead."
            | ArrayIndex, [a;b] -> sprintf "%s->ptr[%s]" (tup_data a) (tup_data b)
            | ArrayIndexSet, [a;b;c] -> 
                match tup_data c with
                | "" as c -> c
                | c -> sprintf "%s->ptr[%s] = %s" (tup_data a) (tup_data b) c
            // Math
            | Add, [a;b] -> sprintf "%s + %s" (tup_data a) (tup_data b)
            | Sub, [a;b] -> sprintf "%s - %s" (tup_data a) (tup_data b)
            | Mult, [a;b] -> sprintf "%s * %s" (tup_data a) (tup_data b)
            | Div, [a;b] -> sprintf "%s / %s" (tup_data a) (tup_data b)
            | Mod, [a;b] -> sprintf "%s %% %s" (tup_data a) (tup_data b)
            | Pow, [a;b] -> sprintf "pow%s(%s,%s)" (float_suffix a) (tup_data a) (tup_data b)
            | LT, [a;b] -> sprintf "%s < %s" (tup_data a) (tup_data b)
            | LTE, [a;b] -> sprintf "%s <= %s" (tup_data a) (tup_data b)
            | EQ, [a;b] -> sprintf "%s == %s" (tup_data a) (tup_data b)
            | NEQ, [a;b] -> sprintf "%s != %s" (tup_data a) (tup_data b)
            | GT, [a;b] -> sprintf "%s > %s" (tup_data a) (tup_data b)
            | GTE, [a;b] -> sprintf "%s >= %s" (tup_data a) (tup_data b)
            | BoolAnd, [a;b] -> sprintf "%s && %s" (tup_data a) (tup_data b)
            | BoolOr, [a;b] -> sprintf "%s || %s" (tup_data a) (tup_data b)
            | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup_data a) (tup_data b)
            | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup_data a) (tup_data b)
            | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup_data a) (tup_data b)

            | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup_data a) (tup_data b)
            | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup_data a) (tup_data b)

            | Neg, [x] -> sprintf "-%s" (tup_data x)
            | Log, [x] -> sprintf "log%s(%s)" (float_suffix x) (tup_data x)
            | Exp, [x] -> sprintf "exp%s(%s)" (float_suffix x) (tup_data x)
            | Tanh, [x] -> sprintf "tanh%s(%s)" (float_suffix x) (tup_data x)
            | Sqrt, [x] -> sprintf "sqrt%s(%s)" (float_suffix x) (tup_data x)
            | NanIs, [x] -> sprintf "isnan(%s)" (tup_data x)
            | UnionTag, [DUnion(_,l) | DV(L(_,YUnion l)) as x] -> 
                let dot_tag = if l.Item.is_degenerate then "" else ".tag"
                sprintf "%s%s" (tup_data x) dot_tag
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> return'
    and method : _ -> MethodRec =
        jp (fun ((jp_body,key & (C(args,_))),i) ->
            match (fst env.join_point_method.[jp_body]).[key] with
            | Some a, Some range -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s_typ s_fun x ->
            let q = tup_ty x.range
            let args = x.free_vars |> Array.mapi (fun i (L(_,x)) -> $"{tyv x} v{i}") |> String.concat ", "
            line s_fun (sprintf "%s method%i(%s){" q x.tag args)
            binds' (indent s_fun) x.body
            line s_fun "}"
            )
    and closure : _ -> ClosureRec =
        jp (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s_typ s_fun x ->
            
            let i = x.tag
            line s_typ "typedef struct {"
            let free_vars = x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}")
            free_vars |> Array.iter (fun x -> line (indent s_typ) $"{x};")
            line s_typ (sprintf "} ClosureEnv%i;" i)
            
            line s_typ "typedef struct {"
            let range = tup_ty x.range
            match x.domain_args |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat ", " with
            | "" -> $"{range} (*fptr)(ClosureEnv{i} *);"
            | domain_args_ty -> $"{range} (*fptr)(ClosureEnv{i} *, {domain_args_ty});"
            |> line (indent s_typ)
            line (indent s_typ) $"ClosureEnv{i} env[];"
            line s_typ (sprintf "} Closure%i;" i)
            
            match x.domain_args |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", " with
            | "" -> sprintf "%s ClosureMethod%i(ClosureEnv%i * env){" range i i
            | domain_args -> sprintf "%s ClosureMethod%i(ClosureEnv%i * env, %s){" range i i domain_args
            |> line s_fun
            if x.free_vars.Length <> 0 then
                x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i} = env->v{i};") |> String.concat " " |> line (indent s_fun)
            binds' (indent s_fun) x.body
            line s_fun "}"

            let fun_tag = (cfun (x.domain,x.range)).tag
            line s_fun (sprintf "Fun%i * ClosureCreate%i(%s){" fun_tag i (String.concat ", " free_vars))
            line (indent s_fun) $"Closure{i} * x = malloc(sizeof(Closure{i}) + sizeof(ClosureEnv{i}));"
            if x.free_vars.Length <> 0 then
                line (indent s_fun) $"ClosureEnv{i} * env = x->env;"
                x.free_vars |> Array.map (fun (L(i,_)) -> $"env->v{i} = v{i};")  |> String.concat " " |> line (indent s_fun)
            line (indent s_fun) $"x->fptr = ClosureMethod{i};"
            line (indent s_fun) $"return (Fun{fun_tag} *) x;"
            line s_fun "}"
            )
    and cfun : _ -> CFunRec =
        cfun' (fun s_typ s_fun x ->
            line s_typ "typedef struct {"
            let range = tup_ty x.range
            match x.domain_args_ty |> Array.map (fun t -> tyv t) |> String.concat ", " with
            | "" -> $"{range} (*fptr)(char *);"
            | domain_args_ty -> $"{range} (*fptr)(char *, {domain_args_ty});"
            |> line (indent s_typ)
            line (indent s_typ) $"char env[];"
            line s_typ (sprintf "} Fun%i;" x.tag)
            )
    and tup' : _ -> TupleRec = 
        tuple (fun s_typ s_fun x ->
            let name = sprintf "Tuple%i" x.tag
            line s_typ "typedef struct {"
            let args = x.tys |> Array.mapi (fun i x -> $"{tyv x} v{i}")
            args |> Array.iter (fun x -> line (indent s_typ) $"{x};")
            line s_typ (sprintf "} %s;" name)

            line s_fun (sprintf "static inline %s TupleCreate%i(%s){" name x.tag (String.concat ", " args))
            line (indent s_fun) $"{name} x;"
            Array.init args.Length (fun i -> $"x.v{i} = v{i};") |> String.concat " " |> line (indent s_fun)
            line (indent s_fun) $"return x;"
            line s_fun "}"
            )
    and layout_tmpl name : _ -> LayoutRec =
        layout (fun s_typ s_fun (x : LayoutRec) ->
            let name' = sprintf "%s%i" name x.tag
            line s_typ "typedef struct {"
            let args = x.free_vars |> Array.map (fun (L(i,x)) -> $"{tyv x} v{i}")
            args |> Array.iter (fun x -> line (indent s_typ) $"{x};")
            line s_typ (sprintf "} %s;" name')

            line s_fun (sprintf "static inline %s * %s(%s){" name' (sprintf "%sCreate%i" name x.tag) (String.concat ", " args))
            line (indent s_fun) $"{name'} * x = malloc(sizeof({name'}));"
            Array.init args.Length (fun i -> $"x->v{i} = v{i};") |> String.concat " " |> line (indent s_fun)
            line (indent s_fun) $"return x;"
            line s_fun "}"
            )
    and heap : _ -> LayoutRec = layout_tmpl "Heap"
    and mut : _ -> LayoutRec = layout_tmpl "Mut"
    and union_tmpl is_stack : Union -> UnionRec = 
        let inline map_iteri f x = Map.fold (fun i k v -> f i k v; i+1) 0 x |> ignore
        union (fun s_typ s_fun x ->
            line s_typ "typedef struct {"
            let _ =
                let s_typ = indent s_typ
                line s_typ "int tag;"
                line s_typ "union {"
                let _ =
                    let s_typ = indent s_typ
                    map_iteri (fun tag k v -> 
                        if Array.isEmpty v = false then
                            line s_typ "struct {"
                            v |> Array.iter (fun (L(i,t)) -> line (indent s_typ) $"{tyv t} v{i};")
                            line s_typ (sprintf "} case%i; // %s" tag k)
                        ) x.free_vars
                line s_typ "};"
            match is_stack with
            | true  -> line s_typ (sprintf "} US%i;" x.tag)
            | false -> line s_typ (sprintf "} UH%i;" x.tag)

            map_iteri (fun tag k v -> 
                let args = v |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", "
                match is_stack with
                | true  -> line s_fun (sprintf "US%i US%i_%i(%s) { // %s" x.tag x.tag tag args k)
                | false -> line s_fun (sprintf "UH%i * UH%i_%i(%s) { // %s" x.tag x.tag tag args k)
                let _ =
                    let s_fun = indent s_fun
                    let acs = 
                        match is_stack with
                        | true  -> line s_fun $"US{x.tag} x;"; "."
                        | false -> line s_fun $"UH{x.tag} * x = malloc(sizeof(UH{x.tag}));"; "->"
                    line s_fun $"x{acs}tag = {tag};"
                    v |> Array.map (fun (L(i,t)) -> $"x{acs}case{tag}.v{i} = v{i};") |> String.concat " " |> line s_fun
                    line s_fun "return x;"
                line s_fun (sprintf "}")
                ) x.free_vars
            )
    and ustack : _ -> UnionRec = union_tmpl true
    and uheap : _ -> UnionRec = union_tmpl false
    and carray : _ -> ArrayRec =
        carray' (fun s_typ s_fun x ->
            let i, size_t, ptr_t = x.tag, prim size_t, tyv x.ty
            line s_typ "typedef struct {"
            line (indent s_typ) $"{size_t} len;"
            line (indent s_typ) $"{ptr_t} ptr[];" // flexible array member
            line s_typ (sprintf "} Array%i;" i)

            line s_fun (sprintf "Array%i * ArrayCreate%i(%s size){" i i size_t)
            let _ =
                let s_fun = indent s_fun
                line s_fun $"Array{i} * x = malloc(sizeof(Array{i}) + sizeof({ptr_t}) * size);"
                line s_fun $"x->len = size;"
                line s_fun "return x;"
            line s_fun "}"

            line s_fun (sprintf "Array%i * ArrayLit%i(%s size, %s * ptr){" i i size_t ptr_t)
            let _ =
                let s_fun = indent s_fun
                line s_fun $"Array{i} * x = ArrayCreate{i}(size);"
                line s_fun $"memcpy(x->ptr, ptr, sizeof({ptr_t}) * size);"
                line s_fun "return x;"
            line s_fun "}"
            )
    and cstring : unit -> unit =
        cstring' (fun s_typ s_fun () ->
            let char = YPrim CharT
            let size_t, ptr_t, tag = prim size_t, tyv char, (carray char).tag
            line s_typ $"typedef Array{tag} String;"

            line s_fun (sprintf "static inline String * StringLit(%s size, %s * ptr){" size_t ptr_t)
            line (indent s_fun) $"return ArrayLit{tag}(size, ptr);"
            line s_fun "}"
            )

    import "stdbool.h"
    import "stdint.h"
    import "stdio.h"
    import "stdlib.h"
    import "string.h"
    import "math.h"

    let main_defs = {text=StringBuilder(); indent=0}
    line main_defs (sprintf "%s main(){" (binds_last_data x |> data_free_vars |> tup_ty_tyvs))
    binds' (indent main_defs) x
    line main_defs "}"

    let program = StringBuilder()

    imports |> Seq.iter (fun x -> program.AppendLine(x) |> ignore)
    types |> Seq.iter (fun x -> program.Append(x) |> ignore)
    functions |> Seq.iter (fun x -> program.Append(x) |> ignore)
    program.Append(main_defs.text).ToString()