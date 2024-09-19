module Spiral.Codegen.Cuda

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

let private backend_name = "Cuda"
let private max_tag = 255uy

let is_string = function DV(L(_,YPrim StringT)) | DLit(LitString _) -> true | _ -> false
let sizeof_tyv = function
    | YPrim (Int64T | UInt64T | Float64T) -> 8
    | YPrim (Int32T | UInt32T | Float32T) -> 4
    | YPrim (Int16T | UInt16T) -> 2
    | YPrim (Int8T | UInt8T | CharT | BoolT) -> 1
    | _ -> 8
let order_args v = v |> Array.sortWith (fun (L(_,t)) (L(_,t')) -> compare (sizeof_tyv t') (sizeof_tyv t))
let line x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore
let line' x s = line x (String.concat " " s)

type BindsReturn =
    | BindsTailEnd
    | BindsLocal of TyV []

let term_vars_to_tys x = x |> Array.map (function WV(L(_,t)) -> t | WLit x -> YPrim (lit_to_primitive_type x))
let binds_last_data x = x |> Array.last |> function TyLocalReturnData(x,_) | TyLocalReturnOp(_,_,x) -> x | TyLet _ -> raise_codegen_error "Compiler error: Cannot find the return data of the last bind."

type LayoutRec = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>}
type UnionRec = {tag : int; free_vars : Map<string, TyV[]>; is_heap : bool}
type MethodRec = {tag : int; free_vars : TyV[]; range : Ty; body : TypedBind[]; name : string option}
type ClosureRec = {tag : int; free_vars : TyV[]; domain : Ty; range : Ty; funtype : FunType; body : TypedBind[]}
type TupleRec = {tag : int; tys : Ty []}
type CFunRec = {tag : int; domain : Ty; range : Ty; funtype : FunType}

//let size_t = UInt32T

// Replaces the invalid symbols in Spiral method names for the C backend.
let fix_method_name (x : string) = x.Replace(''','_') + "_"

let unroll_pop (s : Stack<int>) = if s.Count > 0 then s.Pop() else -1
let unroll_peek (s : Stack<int>) = if s.Count > 0 then s.Peek() else -1

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

let codegen (default_env : Startup.DefaultEnv) (globals : _ ResizeArray, fwd_dcls : _ ResizeArray, types : _ ResizeArray, functions : _ ResizeArray, main_defs : _ ResizeArray) (env : PartEvalResult) =
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

    let layout show =
        let dict' = Dictionary(HashIdentity.Structural)
        let dict = Dictionary(HashIdentity.Reference)
        let f x : LayoutRec = 
            match x with
            | YLayout(x,_) ->
                let x = env.ty_to_data x
                let a, b =
                    match x with
                    | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                    | _ -> data_free_vars x, Map.empty
                {data=x; free_vars=a; free_vars_by_key=b; tag=dict'.Count}
            | _ -> raise_codegen_error $"Compiler error: Expected a layout type (1).\nGot: %s{show_ty x}"
        fun x ->
            let mutable dirty = false
            let r = Utils.memoize dict (Utils.memoize dict' (fun x -> dirty <- true; f x)) x
            if dirty then print show r
            r

    let union show =
        let dict = Dictionary(HashIdentity.Reference)
        let f (a : Union) : UnionRec = 
            let free_vars = a.Item.cases |> Map.map (fun _ -> env.ty_to_data >> data_free_vars)
            {free_vars=free_vars; tag=dict.Count; is_heap=a.Item.layout = UHeap}
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
        let f (a : Ty, b : Ty, t : FunType) = {tag=dict.Count; domain=a; range=b; funtype=t}
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

    let rec binds_start (s : CodegenEnv) (x : TypedBind []) = binds (Stack()) s BindsTailEnd x
    and return_local s ret (x : string) = 
        match ret with
        | [||] -> line s $"{x};"
        | [|L(i,_)|] -> line s $"v{i} = {x};"
        | ret ->
            let tmp_i = tmp()
            line s $"{tup_ty_tyvs ret} tmp{tmp_i} = {x};"
            Array.mapi (fun i (L(i',_)) -> $"v{i'} = tmp{tmp_i}.v{i};") ret |> line' s
    and get_layout_rec lay a =
        match lay with 
        | Heap -> heap a 
        | HeapMutable -> mut a
        | StackMutable -> stack_mut a
    and binds (unroll : Stack<int>) (s : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) =
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
                    let decl_vars () = Array.map (fun (L(i,t)) -> $"{tyv t} v{i};") d
                    let layout_index layout (x'_i : int) (x' : TyV []) = 
                        match layout with
                        | Heap | HeapMutable -> Array.map2 (fun (L(i,t)) (L(i',_)) -> $"{tyv t} & v{i} = v{x'_i}.base->v{i'};") d x' |> line' s
                        | StackMutable -> Array.map2 (fun (L(i,t)) (L(i',_)) -> $"{tyv t} & v{i} = v{x'_i}.v{i'};") d x' |> line' s
                    match a with
                    | TyToLayout(a,YLayout(_,StackMutable) & b) ->
                        match d with
                        | [|L(i,YLayout(_,StackMutable))|] -> // For the regular arrays.
                            let tag = (stack_mut b).tag
                            line s $"StackMut{tag} v{i}{{{args' a}}};"
                            true
                        | _ ->
                            raise_codegen_error "Compiler error: Expected a stack mutable layout type."
                    | TyLayoutIndexAll(x) -> 
                        match x with 
                        | L(i,YLayout(_,lay) & a) -> (get_layout_rec lay a).free_vars |> layout_index lay i 
                        | _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index to be a layout type."
                        true
                    | TyLayoutIndexByKey(x,key) -> 
                        match x with 
                        | L(i,YLayout(_,lay) & a) -> (get_layout_rec lay a).free_vars_by_key.[key] |> layout_index lay i 
                        | _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index by key to be a layout type."
                        true
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
                            let q = m.Split("\\v")
                            if q.Length = 1 then 
                                decl_vars() |> line' s
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
                                    raise_codegen_error "The special \\v macro requires the same number of free vars in its binding as there are \\v in the code."
                    | TyArrayLiteral(a,b') -> 
                        let inits = List.map tup_data b' |> String.concat "," |> sprintf "{%s}"
                        match d with
                        | [|L(i,YArray t)|] -> // For the regular arrays.
                            line s $"%s{tup_ty t} v{i}[] = %s{inits};"
                            true
                        | _ ->
                            raise_codegen_error "Compiler error: Expected a single variable on the left side of an array literal op."
                    | TyArrayCreate(a,b) ->  
                        match d with
                        | [|L(i,YArray t)|] -> 
                            match tup_ty t with
                            | "void" -> line s "/* void array create */"
                            | t -> line s $"{t} v{i}[{tup_data b}];"
                            true
                        | _ -> raise_codegen_error "Compiler error: Expected a single variable on the left side of an array create op."
                    | TyJoinPoint(JPClosure(a,b),b') ->
                        match d with
                        | [|L(i,_)|] -> 
                            let x = closure (a,b)
                            match x.funtype with
                            | FT_Pointer ->
                                let y = cfun (x.domain,x.range,x.funtype)
                                line s $"Fun{y.tag} v{i} = FunPointerMethod{x.tag};"
                            | FT_Vanilla ->
                                let args = args b'
                                line s $"Closure{x.tag} v{i}{{{args}}};"
                            | FT_Closure -> 
                                let y = cfun (x.domain,x.range,x.funtype)
                                let args = args b'
                                line s $"Fun{y.tag} v{i}{{new Closure{x.tag}{{{args}}}}};"
                            true
                        | _ -> raise_codegen_error "Compiler error: Expected a single variable on the left side of a closure join point."
                    | _ ->
                        decl_vars() |> line' s
                        op unroll s (BindsLocal d) a
                        true
                with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
            | TyLocalReturnOp(trace,a,_) ->
                try op unroll s ret a
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
        if 1 < x.Length then sprintf "Tuple%i{%s}" (tup (term_vars_to_tys x)).tag args else args
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
            | UStack -> sprintf "Union%i" (unions a).tag
            | UHeap -> sprintf "sptr<Union%i>" (unions a).tag
        | YLayout(_,lay) as a -> 
            match lay with
            | Heap -> sprintf "sptr<Heap%i>" (heap a).tag
            | HeapMutable -> sprintf "sptr<Mut%i>" (mut a).tag
            | StackMutable -> sprintf "StackMut%i &" (stack_mut a).tag
        | YMacro [Text "backend_switch "; Type (YRecord r)] ->
            match Map.tryFind backend_name r with
            | Some x -> tup_ty x
            | None -> raise_codegen_error $"In the backend_switch, expected a record with the '{backend_name}' field."
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_lit a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "%s *" (tup_ty a)
        | YFun(a,b,t) -> $"Fun%i{(cfun (a,b,t)).tag}"
        | YExists -> raise_codegen_error "Existentials are not supported at runtime. They are a compile time feature only."
        | YForall -> raise_codegen_error "Foralls are not supported at runtime. They are a compile time feature only."
        | a -> raise_codegen_error (sprintf "Compiler error: Type not supported in the codegen.\nGot: %A" a)
    and prim = function
        | Int8T -> "char" 
        | Int16T -> "short"
        | Int32T -> "int"
        | Int64T -> "long long"
        | UInt8T -> "unsigned char"
        | UInt16T -> "unsigned short"
        | UInt32T -> "unsigned int"
        | UInt64T -> "unsigned long long"
        | Float32T -> "float"
        | Float64T -> "double"
        | BoolT -> "bool" // part of c++ standard
        | CharT -> "char"
        | StringT -> "const char *"
    and lit = function
        | LitInt8 x -> sprintf "%i" x
        | LitInt16 x -> sprintf "%i" x
        | LitInt32 x -> sprintf "%i" x
        | LitInt64 x -> sprintf "%ill" x
        | LitUInt8 x -> sprintf "%iu" x
        | LitUInt16 x -> sprintf "%iu" x
        | LitUInt32 x -> sprintf "%iu" x
        | LitUInt64 x -> sprintf "%iull" x
        | LitFloat32 x -> 
            if x = infinityf then "1.0f / 0.0f"
            elif x = -infinityf then "-1.0f / 0.0f"
            elif Single.IsNaN x then "0.0f / 0.0f"
            else x.ToString("R") |> add_dec_point |> sprintf "%sf"
        | LitFloat64 x ->
            if x = infinity then "1.0 / 0.0"
            elif x = -infinity then "-1.0 / 0.0"
            elif Double.IsNaN x then "0.0 / 0.0"
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
    and op (unroll : Stack<int>)s (ret : BindsReturn) a =
        let binds a b = binds unroll a b
        let return' (x : string) =
            match ret with
            | BindsLocal ret -> return_local s ret x
            | BindsTailEnd -> line s $"return {x};"
        let jp (a,b') =
            let args = args b'
            match a with
            | JPMethod(a,b) -> 
                let x = method (a,b)
                let method_name = Option.defaultValue "method_" x.name
                $"{method_name}{x.tag}({args})"
            | JPClosure(a,b) ->
                let x = closure (a,b)
                match x.funtype with
                | FT_Vanilla -> raise_codegen_error "Compiler error: The vanilla function case should have been blocked elsewhere."
                | FT_Pointer -> $"FunPointerMethod{x.tag}"
                | FT_Closure -> $"csptr<ClosureBase{x.tag}>{{new Closure{x.tag}{{{args}}}}}"
        match a with
        | TyMacro _ -> raise_codegen_error "Macros are supposed to be taken care of in the `binds` function."
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if (%s){" (tup_data cond))
            binds (indent s) ret tr
            line s "} else {"
            binds (indent s) ret fl
            line s "}"
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyBackend(_,_,r) -> raise_codegen_error_backend r "The Cuda backend does not support the nesting of other backends."
        | TyWhile(a,b) ->
            let cond =
                match a with
                | JPMethod(a,b),b' -> sprintf "while_method_%i(%s)" (method_while (a,b)).tag (args b')
                | _ -> raise_codegen_error "Expected a regular method rather than closure create in the while conditional."
            match unroll_peek unroll with
            | -1 -> ()
            | 0 -> line s $"#pragma unroll"
            | i -> line s $"#pragma unroll %i{i}"
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
            let acs = match x.Item.layout with UHeap -> ".base->" | UStack -> "."
            let head = List.head is |> fun (L(i,_)) -> $"v{i}{acs}tag"
            List.pairwise is
            |> List.map (fun (L(i,_), L(i',_)) -> $"v{i}{acs}tag == v{i'}{acs}tag")
            |> String.concat " && "
            |> function "" -> head | x -> $"{x} ? {head} : {max_tag}"
            |> sprintf "switch (%s) {" |> line s
            let _ =
                let s = indent s
                Map.iter (fun k (a,b) ->
                    let union_i = case_tags.[k]
                    line s (sprintf "case %i: { // %s" union_i k)
                    List.iter2 (fun (L(data_i,_)) a ->
                        let a, s = data_free_vars a, indent s
                        let qs = ResizeArray(a.Length)
                        Array.iteri (fun field_i (L(v_i,t) as v) -> 
                            qs.Add $"{tyv t} v{v_i} = v{data_i}{acs}case{union_i}.v{field_i};"
                            ) a 
                        line' s qs
                        ) is a
                    binds (indent s) ret b
                    line (indent s) "break;"
                    line s "}"
                    ) on_succs
                line s "default: {"
                let _ =
                    let s = indent s
                    match on_fail with
                    | Some b -> binds s ret b
                    | None -> line s "assert(\"Invalid tag.\" && false); __trap();"
                line s "}"
            line s "}"
        | TyUnionBox(a,b,c') ->
            let c = c'.Item
            let i = c.tags.[a]
            let vars = args' b
            let tag = (unions c').tag
            match c.layout with
            | UHeap -> $"sptr<Union{tag}>{{new Union{tag}{{Union{tag}_{i}{{{vars}}}}}}}"
            | UStack -> $"Union{tag}{{Union{tag}_{i}{{{vars}}}}}"
            |> return'
        | TyToLayout(a,b) -> 
            match b with
            | YLayout(_,layout) -> 
                match layout with
                | Heap ->
                    let tag = (heap b).tag
                    $"sptr<Heap{tag}>{{new Heap{tag}{{{args' a}}}}}"
                | HeapMutable ->
                    let tag = (mut b).tag
                    $"sptr<Mut{tag}>{{new Mut{tag}{{{args' a}}}}}"
                | StackMutable -> raise_codegen_error "The Cuda backend doesn't support stack mutable layout types."
            | _ -> raise_codegen_error "Compiler error: Expected a layout type (2)."
            |> return'
        | TyLayoutIndexAll(x) -> raise_codegen_error "Compiler error: TyLayoutIndexAll should have been taken care of in TyLet."
        | TyLayoutIndexByKey(x,key) -> raise_codegen_error "Compiler error: TyLayoutIndexByKey should have been taken care of in TyLet."
        | TyLayoutMutableSet(L(i,t),b,c) ->
            match t with
            | YLayout(_,lay) ->
                match lay with
                | HeapMutable -> 
                    let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
                    Array.map2 (fun (L(i',_)) b -> $"v{i}.base->v{i'} = {show_w b};") (data_free_vars a) (data_term_vars c)
                | StackMutable -> 
                    let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (stack_mut t).data b
                    Array.map2 (fun (L(i',_)) b -> $"v{i}.v{i'} = {show_w b};") (data_free_vars a) (data_term_vars c)
                | Heap -> raise_codegen_error "Compiler error (1): TyLayoutMutableSet should only be HeapMutable or StackMutable."
            | _ -> raise_codegen_error "Compiler error (2): TyLayoutMutableSet should only be HeapMutable or StackMutable."
            |> String.concat " " |> line s
        | TyArrayLiteral(a,b') -> raise_codegen_error "Compiler error: TyArrayLiteral should have been taken care of in TyLet."
        | TyArrayCreate(a,b) ->  raise_codegen_error "Compiler error: TyArrayCreate should have been taken care of in TyLet."
        | TyFailwith(a,b) ->
            let string_in_op = function DLit (LitString b) -> lit_string b | b -> raise_codegen_error "In the Cuda backend, the exception string must be a literal."
            let fmt = @"%s\n"
            line s $"printf(\"{fmt}\", {string_in_op b});"
            line s "__trap();" // TODO: Print out the error traces as well.
        | TyConv(a,b) -> return' $"({tyv a}){tup_data b}"
        | TyApply(L(i,_),b) -> 
            let rec loop = function
                | DPair(a,b) -> tup_data a :: loop b
                | a -> [tup_data a]
            let args = loop b |> List.filter ((<>) "") |> String.concat ", "
            $"v{i}({args})" |> return'
        | TyArrayLength(_,b) -> raise_codegen_error "Array length is not supported in the Cuda C++ backend as they are bare pointers."
        | TyStringLength(_,b) -> raise_codegen_error "String length is not supported in the Cuda C++ backend."
        | TySizeOf t -> return' $"sizeof({tup_ty t})"
        | TyOp(Global,[DLit (LitString x)]) -> global' x
        | TyOp(PragmaUnrollPush,[DLit (LitInt32 x)]) -> unroll.Push(x); line s $"// Pushing the loop unrolling to: {x}"
        | TyOp(PragmaUnrollPop,[]) -> line s $"// Poping the loop unrolling to: {unroll_pop unroll}"
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
            | EQ, [a;b] | NEQ, [a;b] | GT, [a;b] | GTE, [a;b] when is_string a -> raise_codegen_error "String comparison operations are not supported in the Cuda C++ backend."
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
            | Log, [x] -> sprintf "log(%s)" (tup_data x)
            | Exp, [x] -> sprintf "exp(%s)" (tup_data x)
            | Tanh, [x] -> sprintf "tanh(%s)" (tup_data x)
            | Sqrt, [x] -> sprintf "sqrt(%s)" (tup_data x)
            | Sin, [x] -> sprintf "sin(%s)" (tup_data x)
            | Cos, [x] -> sprintf "cos(%s)" (tup_data x)
            | NanIs, [x] -> sprintf "isnan(%s)" (tup_data x)
            | Printf, [fmt;str] -> 
                match args' str with
                | "" -> sprintf "printf(%s)" (tup_data fmt)
                | str -> sprintf "printf(%s,%s)" (tup_data fmt) str
            | UnionTag, [DV(L(i,YUnion l)) as x] -> 
                match l.Item.layout with
                | UHeap -> ".base->tag"
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
            let inline_ = 
                if is_while then "inline "
                else 
                    line s_fwd $"__device__ {ret_ty} {fun_name}{x.tag}({args});"
                    if fun_name.StartsWith "noinline" then "__noinline__ " else ""
            line s_fun $"__device__ {inline_}{ret_ty} {fun_name}{x.tag}({args}){{"
            binds_start (indent s_fun) x.body
            line s_fun "}"
            )
    and method : _ -> MethodRec = method_template false
    and method_while : _ -> MethodRec = method_template true
    and closure_args domain count_start =
        let rec loop = function
            | YPair(a,b) -> a :: loop b
            | a -> [a]
        let mutable count = count_start
        let rename x = Array.map (fun (L(i,t)) -> let x = L(count,t) in count <- count+1; x) x
        let mutable i = 0
        loop domain |> List.choose (fun x -> 
            let n = env.ty_to_data x |> data_free_vars 
            let x = if n.Length <> 0 then Some(i, tup_ty_tyvs n, n |> rename) else None
            i <- i+1
            x
            )
    and closure : _ -> ClosureRec =
        jp (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
            match fun_ty with
            | YFun(domain,range,t) ->
                match (fst env.join_point_closure.[jp_body]).[key] with
                | Some(domain_args, body) -> {tag=i; domain=domain; range=range; body=body; free_vars=rdata_free_vars args; funtype=t}
                | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
            ) (fun _ s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            let closure_args = closure_args x.domain x.free_vars.Length
            let args = closure_args |> List.map (fun (i,ty,_) -> $"{ty} tup{i}") |> String.concat ", "
            let print_body s_fun =
                let s_fun = indent s_fun
                x.free_vars |> Array.map (fun (L(i,t)) ->
                    $"{tyv t} & v{i} = this->v{i};"
                    ) |> String.concat " " |> line s_fun
                closure_args |> List.map (fun (i'',_,vars) ->
                    Array.mapi (fun i' (L(i,t)) -> 
                        if vars.Length <> 1 then $"{tyv t} v{i} = tup{i''}.v{i'};"
                        else $"{tyv t} v{i} = tup{i''};"
                        ) vars
                    |> String.concat " "
                    ) |> String.concat " " |> line s_fun
                binds_start s_fun x.body
            match x.funtype with
            | FT_Pointer ->
                $"__device__ {range} FunPointerMethod{i}({args}){{" |> line s_fun
                print_body s_fun
                line s_fun "}"
            | FT_Vanilla | FT_Closure ->
                match x.funtype with
                | FT_Pointer -> raise_codegen_error "Compiler error: The pointer case have been taken care of (1)."
                | FT_Closure ->
                    let i' = (cfun (x.domain,x.range,x.funtype)).tag
                    line s_typ $"struct Closure{i} : public ClosureBase{i'} {{"
                | FT_Vanilla ->
                    line s_typ $"struct Closure{i} {{"
                let () =
                    let s_typ = indent s_typ
                    let () = // free vars in the environment
                        print_ordered_args s_typ x.free_vars
                    let () = // operator()
                        match x.funtype with
                        | FT_Pointer -> raise_codegen_error "Compiler error: The pointer case have been taken care of (2)."
                        | FT_Vanilla -> line s_typ $"__device__ {range} operator()({args}){{"
                        | FT_Closure -> line s_typ $"__device__ {range} operator()({args}) override {{"
                        print_body s_typ
                        line s_typ "}"
                    let () = // constructor
                        match x.free_vars with
                        | [||] -> ()
                        | _ ->
                            let constructor_args = 
                                x.free_vars 
                                |> Array.map (fun (L(i,t)) -> $"{tyv t} _v{i}")
                                |> String.concat ", "
                            let initializer_args = 
                                x.free_vars 
                                |> Array.map (fun (L(i,t)) -> $"v{i}(_v{i})")
                                |> String.concat ", "
                            line s_typ $"__device__ Closure{i}({constructor_args}) : {initializer_args} {{ }}"
                    let () = // destructor
                        match x.funtype with
                        | FT_Pointer | FT_Vanilla -> ()
                        | FT_Closure -> line s_typ $"__device__ ~Closure{i}() override = default;"
                    ()
                line s_typ "};"
            )
    and cfun : _ -> CFunRec =
        cfun' (fun s_fwd s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            let domain_args_ty = closure_args x.domain 0 |> List.map (fun (_,ty,_) -> ty) |> String.concat ", "
            match x.funtype with
            | FT_Vanilla -> raise_codegen_error "Regular functions do not have a composable type in the Cuda backend. Consider explicitly converting them to either closures or pointers using `to_closure` or `to_fptr` if you want to pass them through boundaries."
            | FT_Pointer -> line s_fwd $"typedef {range} (* Fun{i})({domain_args_ty});"
            | FT_Closure ->
                line s_fwd $"struct ClosureBase{i} {{ int refc{{0}}; __device__ virtual {range} operator()({domain_args_ty}) = 0; __device__ virtual ~ClosureBase{i}() = default; }};"
                line s_fwd $"typedef csptr<ClosureBase{i}> Fun{i};"
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
            if args.Length <> 0 then
                line (indent s_typ) $"__device__ {name}() = default;"
                line (indent s_typ) $"__device__ {name}({concat args}) : {concat con_init} {{}}"
            line s_typ "};"
            )
    and unions : _ -> UnionRec = 
        let inline map_iteri f x = Map.fold (fun i k v -> f i k v; i+1) 0 x |> ignore
        union (fun s_fwd s_typ s_fun x ->
            let i = x.tag
            line s_fwd $"struct Union{i};" // Forward declaration for the union.
            map_iteri (fun tag k v -> // The individual union cases.
                line s_typ $"struct Union{i}_{tag} {{ // {k}"
                // The free vars in the env.
                print_ordered_args (indent s_typ) v
                let () = // constructors
                    let s_typ = indent s_typ
                    let concat x = String.concat ", " x
                    let args = v |> Array.map (fun (L(i,x)) -> $"{tyv x} t{i}")
                    let con_init = v |> Array.map (fun (L(i,x)) -> $"v{i}(t{i})")
                    if v.Length <> 0 then 
                        line s_typ $"__device__ Union{i}_{tag}({concat args}) : {concat con_init} {{}}" 
                        line s_typ $"__device__ Union{i}_{tag}() = delete;" 
                line s_typ "};"
                ) x.free_vars
                
            line s_typ $"struct Union{i} {{" // The union definition.
            let _ = // Union cases inside the union.
                let s_typ = indent s_typ
                line s_typ $"union {{"
                let _ =
                    let s_typ = indent s_typ
                    map_iteri (fun tag k v -> line s_typ $"Union{i}_{tag} case{tag}; // {k}") x.free_vars
                line s_typ "};"

                if x.is_heap then line s_typ "int refc{0};"
                if x.free_vars.Count > int max_tag then raise_codegen_error $"Too many union cases. They should not be more than {max_tag}."
                line s_typ $"unsigned char tag{{{max_tag}}};"
                line s_typ $"__device__ Union{i}() {{}}" // default constructor, the refc and tag have def value so we don't have to do anything here.
                
                map_iteri (fun tag k v -> // The constructors for all the union cases.
                    line s_typ $"__device__ Union{i}(Union{i}_{tag} t) : tag({tag}), case{tag}(t) {{}} // {k}"
                    ) x.free_vars
                
                line s_typ $"__device__ Union{i}(Union{i} & x) : tag(x.tag) {{" // copy constructor
                let () =
                    let s_typ = indent s_typ
                    line s_typ "switch(x.tag){"
                    let () = // copy constructor cases
                        let s_typ = indent s_typ
                        map_iteri (fun tag k v -> 
                            line s_typ $"case {tag}: new (&this->case{tag}) Union{i}_{tag}(x.case{tag}); break; // {k}"
                            ) x.free_vars
                    line s_typ "}"
                line s_typ "}"
                line s_typ $"__device__ Union{i}(Union{i} && x) : tag(x.tag) {{" // move constructor
                let () =
                    let s_typ = indent s_typ
                    line s_typ "switch(x.tag){"
                    let () = // move constructor cases
                        let s_typ = indent s_typ
                        map_iteri (fun tag k v -> 
                            line s_typ $"case {tag}: new (&this->case{tag}) Union{i}_{tag}(std::move(x.case{tag})); break; // {k}"
                            ) x.free_vars
                    line s_typ "}"
                line s_typ "}"
                line s_typ $"__device__ Union{i} & operator=(Union{i} & x) {{" // copy assignment operator
                let () =
                    let s_typ = indent s_typ
                    line s_typ "if (this->tag == x.tag) {" 
                    let () =
                        let s_typ = indent s_typ
                        line s_typ "switch(x.tag){"
                        let () = // copy assignment cases
                            let s_typ = indent s_typ
                            map_iteri (fun tag k v -> 
                                line s_typ $"case {tag}: this->case{tag} = x.case{tag}; break; // {k}"
                                ) x.free_vars
                        line s_typ "}"
                    line s_typ "} else {"
                    let () =
                        let s_typ = indent s_typ
                        line s_typ $"this->~Union{i}();"
                        line s_typ $"new (this) Union{i}{{x}};"
                    line s_typ "}"
                    line s_typ "return *this;"
                line s_typ "}"
                line s_typ $"__device__ Union{i} & operator=(Union{i} && x) {{" // move assignment operator
                let () =
                    let s_typ = indent s_typ
                    line s_typ "if (this->tag == x.tag) {" 
                    let () =
                        let s_typ = indent s_typ
                        line s_typ "switch(x.tag){"
                        let () = // move assignment cases
                            let s_typ = indent s_typ
                            map_iteri (fun tag k v -> 
                                line s_typ $"case {tag}: this->case{tag} = std::move(x.case{tag}); break; // {k}"
                                ) x.free_vars
                        line s_typ "}"
                    line s_typ "} else {"
                    let () =
                        let s_typ = indent s_typ
                        line s_typ $"this->~Union{i}();"
                        line s_typ $"new (this) Union{i}{{std::move(x)}};"
                    line s_typ "}"
                    line s_typ "return *this;"
                line s_typ "}"
                line s_typ $"__device__ ~Union{i}() {{"
                let () = // destructor
                    let s_typ = indent s_typ
                    line s_typ "switch(this->tag){"
                    let () = // destructor cases
                        let s_typ = indent s_typ
                        map_iteri (fun tag k v -> 
                            line s_typ $"case {tag}: this->case{tag}.~Union{i}_{tag}(); break; // {k}"
                            ) x.free_vars
                    line s_typ "}"
                    line s_typ $"this->tag = {max_tag};"
                line s_typ "}"
            line s_typ "};"
            )
    and layout_tmpl is_heap name : _ -> LayoutRec =
        layout (fun s_fwd s_typ s_fun (x : LayoutRec) ->
            let name = sprintf "%s%i" name x.tag
            line s_fwd $"struct {name};"
            line s_typ $"struct {name} {{"
            let () =
                let s_typ = indent s_typ
                if is_heap then line s_typ "int refc{0};"
                x.free_vars |> print_ordered_args s_typ
                let concat x = String.concat ", " x
                let args = x.free_vars |> Array.map (fun (L(i,x)) -> $"{tyv x} t{i}")
                let con_init = x.free_vars |> Array.map (fun (L(i,x)) -> $"v{i}(t{i})")
                if args.Length <> 0 then
                    line s_typ $"__device__ {name}() = default;"
                    line s_typ $"__device__ {name}({concat args}) : {concat con_init} {{}}" 
            line s_typ "};"
            )
    and heap : _ -> LayoutRec = layout_tmpl true "Heap"
    and mut : _ -> LayoutRec = layout_tmpl true "Mut"
    and stack_mut : _ -> LayoutRec = layout_tmpl false "StackMut"

    fun vs (x : TypedBind []) ->
        match binds_last_data x |> data_term_vars |> term_vars_to_tys with
        | [||] ->
            let main_defs' = {text=StringBuilder(); indent=0}
            let args = vs |> Array.mapi (fun i (L(_,x)) -> $"{tyv x} v{i}") |> String.concat ", "
            line main_defs' $"extern \"C\" __global__ void entry%i{main_defs.Count}(%s{args}) {{"
            binds_start (indent main_defs') x
            line main_defs' "}"
            main_defs.Add(main_defs'.text.ToString())

            global' $"using default_int = {prim default_env.default_int};"
            global' $"using default_uint = {prim default_env.default_uint};"
            global' (IO.File.ReadAllText(IO.Path.Join(AppDomain.CurrentDomain.BaseDirectory, "reference_counting.cuh")))
            
        | _ ->
            raise_codegen_error $"The return type of the __global__ kernel in the Cuda backend should be a void type."
