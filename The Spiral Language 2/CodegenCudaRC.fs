module Spiral.Codegen.CudaRC

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
open Spiral.RefCounting

let private backend_name = "Cuda"

// Used to decide whether to zero initialize arrays.
let rec is_heap f x =
    Array.exists (fun (L(i,t)) -> 
        match t with
        | YUnion a when a.Item.layout = UStack -> Array.exists (snd >> f >> is_heap f) a.Item.tag_cases
        | YPrim StringT -> true
        | YPrim _ -> false
        | _ -> true
        ) x
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

type UnionRec = {tag : int; free_vars : Map<string, TyV[]>}
type LayoutRec = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]; name : string option}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : Ty []}
type ArrayRec = {tag : int; ty : Ty; tyvs : TyV[]}
type FunRec = {tag : int; domain_args_ty : Ty[]; range : Ty}
type FunPtrRec = {tag : int; domain : Ty; range : Ty}
type FunPtrMethodRec = {tag : int; domain : Ty; range : Ty; body : TypedBind[]; domain_args : TyV[]}


// TODO: Figure out how to merge this with the default int.
let size_t = UInt32T

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

let codegen (globals : _ ResizeArray, fwd_dcls : _ ResizeArray, types : _ ResizeArray, functions : _ ResizeArray, main_defs : _ ResizeArray) (env : PartEvalResult) =
    let malloc, free = "malloc", "free"
    let print_decref s_fun name_fun type_arg name_decref =
        line s_fun (sprintf "__device__ void %s(%s * x){" name_fun type_arg)
        let _ =
            let s_fun = indent s_fun
            line s_fun $"if (x != NULL && --(x->refc) == 0) {{ %s{name_decref}(x); %s{free}(x); }}"
        line s_fun "}"

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

    let carray' show =
        let dict = Dictionary(HashIdentity.Structural)
        let f x = {tag=dict.Count; ty=x; tyvs = env.ty_to_data x |> data_free_vars}
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

    let cfunptr' show =
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

    let rec binds_start (args : TyV []) (s : CodegenEnv) (x : TypedBind []) = binds (refc_prepass Set.empty (Set args) x) (Stack()) s BindsTailEnd x
    and return_local s ret (x : string) = 
        match ret with
        | [||] -> line s $"{x};"
        | [|L(i,_)|] -> line s $"v{i} = {x};"
        | ret ->
            let tmp_i = tmp()
            line s $"{tup_ty_tyvs ret} tmp{tmp_i} = {x};"
            Array.mapi (fun i (L(i',_)) -> $"v{i'} = tmp{tmp_i}.v{i};") ret |> line' s
    and binds (vars : RefcVars) (unroll : Stack<int>) (s : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) = 
        let tup_destruct (a,b) =
            Array.map2 (fun (L(i,_)) b -> 
                match b with
                | WLit b -> $"v{i} = {lit b};"
                | WV (L(i',_)) -> $"v{i} = v{i'};"
                ) a b
        Array.forall (fun x ->
            // This complicated looking piece of code is responsible for putting the incref and decref statements at the beginning of every
            // statement. It's actually the only place where ref counting code is outputted in the codegen.
            let _ =
                let f k = get_default k x (fun () -> Set.empty)
                let f' k = get_default k x (fun () -> Map.empty)
                let incr, decr, op, op_decr = varc_set (f vars.g_incr) 1, varc_set (f vars.g_decr) -1, f' vars.g_op, varc_set (f vars.g_op_decr) -1
                let incr, decr = varc_union incr decr |> varc_union op |> varc_union op_decr |> Map.partition (fun _ v -> 0 < v)
                refc_varc incr |> line' s; refc_varc decr |> line' s
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
                            let q = m.Split("\\v")
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
                                    raise_codegen_error "The special \\v macro requires the same number of free vars in its binding as there are \\v in the code."
                    | _ ->
                        decl_vars |> line' s
                        op vars unroll s (BindsLocal d) a
                        true
                with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
            | TyLocalReturnOp(trace,a,_) ->
                try op vars unroll s ret a
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
    and refc_change'' (f : int * Ty -> string) count (L(i,t')) =
        let v = i,t'
        let inline g decref =
            if count = -1 then Some (decref())
            elif count = 1 then Some $"{f v}->refc++;"
            elif 1 < count then Some $"{f v}->refc += {count};"
            else raise_codegen_error $"Compiler error: Invalid count in refc_change''. Got: {count}"
        match t' with
        | YUnion t -> 
            match t.Item.layout with
            | UStack -> 
                if count = -1 then Some $"USDecref{(ustack t).tag}(&({f v}));"
                elif 0 < count then Some (String.replicate count $"USIncref{(ustack t).tag}(&({f v}));")
                else raise_codegen_error $"Compiler error: Invalid count in refc_change''. UStack case. Got: {count}"
            | UHeap -> g (fun () -> $"UHDecref{(uheap t).tag}({f v});")
        | YArray t -> g (fun () -> $"ArrayDecref{(carray t).tag}({f v});")
        | YFun(a,b) -> g (fun () ->  $"{f v}->decref_fptr({f v});")
        | YPrim StringT -> g (fun () ->  $"StringDecref({f v});" )
        | YLayout(a,Heap) -> g (fun () ->  $"HeapDecref{(heap a).tag}({f v});")
        | YLayout(a,HeapMutable) -> g (fun () ->  $"MutDecref{(mut a).tag}({f v});")
        | _ -> None
    and refc_change' (f : int * Ty -> string) count (x : TyV []) : string [] = Array.choose (refc_change'' f count) x
    and refc_change f c x = refc_change' (fun (i,t) -> f i) c x
    and refc_varc x = 
        let ar = ResizeArray(Map.count x)
        Map.iter (fun k v -> refc_change'' (fun (i,_) -> $"v{i}") v k |> Option.iter ar.Add) x
        ar
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
        | YLayout(a,Heap) -> sprintf "Heap%i *" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i *" (mut a).tag
        | YMacro [Text "backend_switch "; Type (YRecord r)] ->
            match Map.tryFind backend_name r with
            | Some x -> tup_ty x
            | None -> raise_codegen_error $"In the backend_switch, expected a record with the '{backend_name}' field."
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_lit a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "Array%i *" (carray a).tag
        | YFun(a,b) -> sprintf "Fun%i *" (fun_type (a,b)).tag
        | YFunPtr(a,b) -> sprintf "FunPtr%i" (funptr_type (a,b)).tag
        | YExists -> raise_codegen_error "Existentials are not supported at runtime. They are a compile time feature only."
        | a -> raise_codegen_error (sprintf "Compiler error: Type not supported in the codegen.\nGot: %A" a)
    and prim = function
        | Int8T -> "char" 
        | Int16T -> "short"
        | Int32T -> "long"
        | Int64T -> "long long"
        | UInt8T -> "unsigned char"
        | UInt16T -> "unsigned short"
        | UInt32T -> "unsigned long"
        | UInt64T -> "unsigned long long"
        | Float32T -> "float"
        | Float64T -> "double"
        | BoolT -> "bool" // part of c++ standard
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
            if x = infinityf then "1.0f / 0.0f"
            elif x = -infinityf then "-1.0f / 0.0f"
            elif Single.IsNaN x then "0.0f / 0.0f"
            else x.ToString("R") |> add_dec_point |> sprintf "%sf"
        | LitFloat64 x ->
            if x = infinity then "1.0 / 0.0"
            elif x = -infinity then "-1.0 / 0.0"
            elif Double.IsNaN x then "0.0 / 0.0"
            else x.ToString("R") |> add_dec_point
        | LitString x ->
            cstring()
            lit_string x |> sprintf "StringLit(%i, %s)" (x.Length + 1)
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
    and op (vars : RefcVars) (unroll : Stack<int>) s (ret : BindsReturn) a =
        let binds a b = binds vars unroll a b
        let return' (x : string) =
            match ret with
            | BindsLocal ret -> return_local s ret x
            | BindsTailEnd -> line s $"return {x};"
        let layout_index (x'_i : int) (x' : TyV []) =
            match ret with
            | BindsLocal x -> Array.map2 (fun (L(i,_)) (L(i',_)) -> $"v{i} = v{x'_i}->v{i'};") x x' |> line' s
            // This is because otherwise the decref and incref statements might not be printed.
            | BindsTailEnd -> raise_codegen_error "Compiler error: Layout index should never come in end position." 
        let jp (a,b') =
            let args = args b'
            match a with
            | JPMethod(a,b) -> 
                let x = method (a,b)
                sprintf "%s%i(%s)" (Option.defaultValue "method" x.name) x.tag args
            | JPClosure(a,C(_,_,YFun _) & b) -> sprintf "ClosureCreate%i(%s)" (closure (a,b)).tag args
            | JPClosure(a,C(_,_,YFunPtr _) & b) -> sprintf "FunPtrMethod%i" (funptr_method (a,b)).tag
            | JPClosure(a,C(_,_,_)) -> raise_codegen_error "Compiler error: Malformed join point."
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
            let acs = match x.Item.layout with UHeap -> "->" | UStack -> "."
            let head = List.head is |> fun (L(i,_)) -> $"v{i}{acs}tag"
            List.pairwise is
            |> List.map (fun (L(i,_), L(i',_)) -> $"v{i}{acs}tag == v{i'}{acs}tag")
            |> String.concat " && "
            |> function "" -> head | x -> $"{x} ? {head} : -1"
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
                            qs.Add $"{tyv t} v{v_i} = v{data_i}{acs}v.case{union_i}.v{field_i};"
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
                    | Some b ->
                        binds s ret b
                    | None ->
                        line s "assert(\"Invalid tag.\" && false);"
                line s "}"
            line s "}"
        | TyUnionBox(a,b,c') ->
            let c = c'.Item
            let i = c.tags.[a]
            let vars = args' b
            match c.layout with
            | UHeap -> sprintf "UH%i_%i(%s)" (uheap c').tag i vars
            | UStack -> sprintf "US%i_%i(%s)" (ustack c').tag i vars
            |> return'
        | TyLayoutToHeap(a,b) -> sprintf "HeapCreate%i(%s)" (heap b).tag (args' a) |> return'
        | TyLayoutToHeapMutable(a,b) -> sprintf "MutCreate%i(%s)" (mut b).tag (args' a) |> return'
        | TyLayoutIndexAll(x) -> match x with L(i,YLayout(a,lay)) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i | _ -> failwith "Compiler error: Expected the TyV in layout index to be a layout type."
        | TyLayoutIndexByKey(x,key) -> match x with L(i,YLayout(a,lay)) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i | _ -> failwith "Compiler error: Expected the TyV in layout index by key to be a layout type."
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let q = mut t // `mut t` is correct here, peval strips the YLayout.
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") q.data b 
            Array.map2 (fun (L(i',_)) b -> $"&(v{i}->v{i'}), {show_w b}") (data_free_vars a) (data_term_vars c) |> String.concat ", " 
            |> sprintf "AssignMut%i(%s)" (assign_mut (tyvs_to_tys q.free_vars)).tag |> return'
        | TyArrayLiteral(a,b') ->
            let b = List.map tup_data b' |> String.concat "," |> sprintf "{%s}"
            $"ArrayLit{(carray a).tag}({b'.Length}, ({tup_ty a} []){b})" |> return'
        | TyArrayCreate(a,b) -> 
            let a = carray a
            let is_heap : string = is_heap (env.ty_to_data >> data_free_vars) a.tyvs |> sprintf "%b"
            $"ArrayCreate{a.tag}({tup_data b}, {is_heap})" |> return'
        | TyFailwith(a,b) ->
            let string_in_op = function DLit (LitString b) -> lit_string b | b -> raise_codegen_error "In the Cuda backend, the exception string must be a literal."
            let fmt = @"%s\n"
            line s $"printf(\"{fmt}\", {string_in_op b});"
            line s "asm(\"exit;\");" // TODO: Print out the error traces as well.
        | TyConv(a,b) -> return' $"({tyv a}){tup_data b}"
        | TyApply(L(i,YFunPtr _),b) -> 
            let rec loop = function
                | DPair(a,b) -> tup_data a :: loop b
                | a -> [tup_data a]
            let args = loop b |> String.concat ", "
            $"v{i}({args})" |> return'
        | TyApply(L(i,YFun _),b) -> 
            match args' b with
            | "" -> $"v{i}->fptr(v{i})"
            | b -> $"v{i}->fptr(v{i}, {b})"
            |> return'
        | TyApply _ -> raise_codegen_error "Compiler error: Unexpected type in apply. Should have been taken care of in the peval stage."
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
                | _ -> sprintf "%s->ptr[%s]" (tup_data a) (tup_data b)
            | ArrayIndexSet, [DV(L(_,YArray t)) as a;b;c] -> 
                let a',b',c' = tup_data a, tup_data b, tup_data c
                match c' with
                | "" -> "/* void array set */"
                | _ -> $"AssignArray{(assign_array (tyvs_to_tys (carray t).tyvs)).tag}(&({a'}->ptr[{b'}]), {c'})"
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
            let inline_ = if is_while then "inline " else line s_fwd $"__device__ {ret_ty} {fun_name}{x.tag}({args});"; ""
            line s_fun $"__device__ {inline_}{ret_ty} {fun_name}{x.tag}({args}){{"
            binds_start (if is_while then [||] else x.free_vars) (indent s_fun) x.body
            line s_fun "}"
            )
    and method : _ -> MethodRec = method_template false
    and method_while : _ -> MethodRec = method_template true
    and closure : _ -> ClosureRec =
        jp (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
            match fun_ty with
            | YFun(domain,range) ->
                match (fst env.join_point_closure.[jp_body]).[key] with
                | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
                | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            | YFunPtr _ -> raise_codegen_error "Compiler error: Function pointers are should be evaluated elsewhere."
            | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
            ) (fun _ s_typ s_fun x ->
            
            let i, range = x.tag, tup_ty x.range
            line s_typ (sprintf "typedef struct Closure%i Closure%i;" i i)
            line s_typ (sprintf "struct Closure%i {" i)
            let _ =
                let s_typ = indent s_typ
                line s_typ $"int refc;"
                line s_typ $"void (*decref_fptr)(Closure{i} *);"
                match x.domain_args |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat ", " with
                | "" -> $"{range} (*fptr)(Closure{i} *);"
                | domain_args_ty -> $"{range} (*fptr)(Closure{i} *, {domain_args_ty});"
                |> line s_typ
                print_ordered_args s_typ x.free_vars
            line s_typ "};"

            line s_fun (sprintf "__device__ static inline void ClosureDecrefBody%i(Closure%i * x){" i i)
            let _ =
                let s_fun = indent s_fun
                x.free_vars |> refc_change (fun i -> $"x->v{i}") -1 |> line' s_fun
            line s_fun "}"

            print_decref s_fun $"ClosureDecref{i}" $"Closure{i}" $"ClosureDecrefBody{i}"
            
            match x.domain_args |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", " with
            | "" -> sprintf "__device__ %s ClosureMethod%i(Closure%i * x){" range i i
            | domain_args -> sprintf "__device__ %s ClosureMethod%i(Closure%i * x, %s){" range i i domain_args
            |> line s_fun
            let _ =
                let s_fun = indent s_fun
                x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i} = x->v{i};") |> line' s_fun
                line s_fun $"ClosureDecref{i}(x);"
                binds_start x.domain_args s_fun x.body
            line s_fun "}"

            let fun_tag = (fun_type (x.domain,x.range)).tag
            let free_vars = x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}")
            line s_fun (sprintf "__device__ Fun%i * ClosureCreate%i(%s){" fun_tag i (String.concat ", " free_vars))
            let _ =
                let s_fun = indent s_fun
                line s_fun $"Closure{i} * x = (Closure{i} *) {malloc}(sizeof(Closure{i}));"
                line s_fun "x->refc = 1;"
                line s_fun $"x->decref_fptr = ClosureDecref{i};"
                line s_fun $"x->fptr = ClosureMethod{i};"
                x.free_vars |> Array.map (fun (L(i,_)) -> $"x->v{i} = v{i};")  |> line' s_fun
                line s_fun $"return (Fun{fun_tag} *) x;"
            line s_fun "}"
            )
    and fun_type : _ -> FunRec =
        cfun' (fun _ s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            line s_typ $"typedef struct Fun{i} Fun{i};"
            line s_typ (sprintf "struct Fun%i{" i)
            let _ =
                let s_typ = indent s_typ
                line s_typ $"int refc;"
                line s_typ $"void (*decref_fptr)(Fun{i} *);"
                match x.domain_args_ty |> Array.map tyv |> String.concat ", " with
                | "" -> $"{range} (*fptr)(Fun{i} *);"
                | domain_args_ty -> $"{range} (*fptr)(Fun{i} *, {domain_args_ty});"
                |> line s_typ
            line s_typ "};"
            )
    and funptr_args domain = // Instead of flattening all the runtime vars as is usual, only the outermost pair is flattened.
        let rec loop = function
            | YPair(a,b) -> a :: loop b
            | a -> [a]
        let mutable count = 0
        let assert_not_void = function [||] -> raise_codegen_error "Void arguments in closures are not allowed." | x -> x
        let rename x = Array.map (fun (L(i,t)) -> let x = L(count,t) in count <- count+1; x) x
        loop domain |> List.mapi (fun i x -> let n = env.ty_to_data x |> data_free_vars in i, tup_ty_tyvs n, n |> rename |> assert_not_void)
    and funptr_type : _ -> FunPtrRec =
        cfunptr' (fun s_fwd s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            let domain_args_ty = funptr_args x.domain |> List.map (fun (_,ty,_) -> ty) |> String.concat ", "
            line s_fwd $"typedef %s{range} (* FunPtr%i{i})(%s{domain_args_ty});"
            )
    and funptr_method : _ -> FunPtrMethodRec =
        jp (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
            match fun_ty with
            | YFunPtr(domain,range) ->
                match (fst env.join_point_closure.[jp_body]).[key] with
                | Some(domain_args, body) -> 
                    if Array.isEmpty (rdata_free_vars args) = false then raise_codegen_error "The Cuda C++ backend doesn't support closures due to them needing to be heap allocated, only function pointers. For them to be converted to pointers, the closures must not have any free variables in them."
                    {tag=i; domain=domain; range=range; body=body; domain_args=data_free_vars domain_args}
                | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            | YFun _ -> raise_codegen_error "Closure are supposed to be handled elsewhere..."
            | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
            ) (fun _ s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            let funptr_args = funptr_args x.domain
            let args = funptr_args |> List.map (fun (i,ty,_) -> $"{ty} tup{i}") |> String.concat ", "
            $"__device__ {range} FunPtrMethod{i}({args}){{" |> line s_fun
            let _ =
                let s_fun = indent s_fun
                funptr_args |> List.map (fun (i'',_,vars) ->
                    Array.mapi (fun i' (L(i,t)) -> 
                        if vars.Length <> 1 then $"{tyv t} v{i} = tup{i''}.v{i'};"
                        else $"{tyv t} v{i} = tup{i''};"
                        ) vars
                    |> String.concat " "
                    ) |> String.concat " " |> line s_fun
                binds_start x.domain_args s_fun x.body
            line s_fun "}"
            )
    and tup : _ -> TupleRec =
        tuple (fun _ s_typ s_fun x ->
            let name = sprintf "Tuple%i" x.tag
            line s_typ "typedef struct {"
            x.tys |> Array.mapi (fun i x -> L(i,x)) |> print_ordered_args (indent s_typ)
            line s_typ (sprintf "} %s;" name)

            let args = x.tys |> Array.mapi (fun i x -> $"{tyv x} v{i}")
            line s_fun (sprintf "__device__ static inline %s TupleCreate%i(%s){" name x.tag (String.concat ", " args))
            let _ =
                let s_fun = indent s_fun
                line s_fun $"{name} x;"
                Array.init args.Length (fun i -> $"x.v{i} = v{i};") |> line' s_fun
                line s_fun $"return x;"
            line s_fun "}"
            )
    and assign_mut : _ -> TupleRec = 
        tuple (fun _ s_typ s_fun x ->
            let tyvs = Array.mapi (fun i t -> L(i,t)) x.tys
            let args = Array.mapi (fun i t -> let t = tyv t in $"{t} * a{i}, {t} b{i}") x.tys |> String.concat ", "
            line s_fun (sprintf "__device__ static inline void AssignMut%i(%s){" x.tag args)
            let _ =
                let s_fun = indent s_fun
                refc_change (fun i -> $"b{i}") 1 tyvs |> line' s_fun
                refc_change (fun i -> $"*a{i}") -1 tyvs |> line' s_fun
                Array.init tyvs.Length (fun i -> $"*a{i} = b{i};") |> line' s_fun
            line s_fun "}"
            )
    and assign_array : _ -> TupleRec = 
        tuple (fun _ s_typ s_fun x ->
            let tyvs, T = Array.mapi (fun i t -> L(i,t)) x.tys, tup_ty_tys x.tys
            line s_fun (sprintf "__device__ static inline void AssignArray%i(%s * a, %s b){" x.tag T T)
            let _ =
                let s_fun = indent s_fun
                match tyvs with
                | [||] -> raise_codegen_error "Compiler error: Void types not allowed in assign."
                | [|t|] -> 
                    refc_change (fun i -> "b") 1 tyvs |> line' s_fun
                    refc_change (fun i -> "*a") -1 tyvs |> line' s_fun
                    $"*a = b;" |> line s_fun
                | _ ->
                    refc_change (fun i -> $"b.v{i}") 1 tyvs |> line' s_fun
                    refc_change (fun i -> $"a->v{i}") -1 tyvs |> line' s_fun
                    $"*a = b;" |> line s_fun
            line s_fun "}"
            )
    and layout_tmpl name : _ -> LayoutRec =
        layout (fun _ s_typ s_fun (x : LayoutRec) ->
            let i = x.tag
            let name' = sprintf "%s%i" name i

            line s_typ "typedef struct {"
            let _ =
                let s_typ = indent s_typ
                line s_typ "int refc;"
                print_ordered_args s_typ x.free_vars
            line s_typ (sprintf "} %s;" name')

            line s_fun (sprintf "__device__ static inline void %sDecrefBody%i(%s * x){" name i name')
            let _ =
                let s_fun = indent s_fun
                x.free_vars |> refc_change (fun i -> $"x->v{i}") -1 |> line' s_fun
            line s_fun "}"

            print_decref s_fun $"{name}Decref{i}" name' $"{name}DecrefBody{i}"

            let args = x.free_vars |> Array.map (fun (L(i,x)) -> $"{tyv x} v{i}")
            line s_fun (sprintf "__device__ %s * %sCreate%i(%s){" name' name i (String.concat ", " args))
            let _ =
                let s_fun = indent s_fun
                line s_fun $"{name'} * x = ({name'} *) {malloc}(sizeof({name'}));"
                line s_fun "x->refc = 1;"
                Array.init args.Length (fun i -> $"x->v{i} = v{i};") |> line' s_fun
                line s_fun $"return x;"
            line s_fun "}"
            )
    and heap : _ -> LayoutRec = layout_tmpl "Heap"
    and mut : _ -> LayoutRec = layout_tmpl "Mut"
    and union_tmpl is_stack : Union -> UnionRec = 
        let inline map_iteri f x = Map.fold (fun i k v -> f i k v; i+1) 0 x |> ignore
        union (fun s_fwd s_typ s_fun x ->
            let i = x.tag
            match is_stack with
            | true  -> line s_typ "typedef struct {"
            | false -> 
                line s_fwd (sprintf "typedef struct UH%i UH%i;" i i)
                line s_typ (sprintf "struct UH%i {" i)
            let _ =
                let s_typ = indent s_typ
                match is_stack with
                | true -> ()
                | false -> line s_typ "int refc;"
                line s_typ "int tag;"
                line s_typ "union {"
                let _ =
                    let s_typ = indent s_typ
                    map_iteri (fun tag k v -> 
                        if Array.isEmpty v = false then
                            line s_typ "struct {"
                            print_ordered_args (indent s_typ) v
                            line s_typ (sprintf "} case%i; // %s" tag k)
                        ) x.free_vars
                line s_typ "};"
            match is_stack with
            | true  -> line s_typ (sprintf "} US%i;" i)
            | false -> line s_typ "};"

            let print_refc name typ q =
                line s_fun (sprintf "__device__ static inline void %s(%s * x){" name typ)
                let _ =
                    let s_fun = indent s_fun
                    line s_fun "switch (x->tag) {"
                    map_iteri (fun tag k v -> 
                        let s_fun = indent s_fun
                        let refc = v |> refc_change (fun i -> $"x->case{tag}.v{i}") q
                        if refc.Length <> 0 then
                            line s_fun (sprintf "case %i: {" tag)
                            let _ =
                                let s_fun = indent s_fun
                                refc |> line' s_fun
                                line s_fun "break;"
                            line s_fun "}"
                        ) x.free_vars
                    line s_fun "}"
                line s_fun "}"

            match is_stack with
            | true  -> 
                print_refc $"USIncrefBody{i}" $"US{i}" 1
                print_refc $"USDecrefBody{i}" $"US{i}" -1
            | false -> print_refc $"UHDecrefBody{i}" $"UH{i}" -1

            match is_stack with
            | true  -> 
                line s_fun (sprintf "__device__ void USIncref%i(US%i * x){ USIncrefBody%i(x); }" i i i)
                line s_fun (sprintf "__device__ void USDecref%i(US%i * x){ USDecrefBody%i(x); }" i i i)
            | false -> 
                line s_fwd (sprintf "__device__ void UHDecref%i(UH%i * x);" i i)
                print_decref s_fun $"UHDecref{i}" $"UH{i}" $"UHDecrefBody{i}"
            
            map_iteri (fun tag k v -> 
                let args = v |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", "
                if is_stack then
                    line s_fun (sprintf "__device__ US%i US%i_%i(%s) { // %s" i i tag args k)
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"US{i} x;"
                        line s_fun $"x.tag = {tag};"
                        if v.Length <> 0 then
                            v |> Array.map (fun (L(i,t)) -> $"x.case{tag}.v{i} = v{i};") |> line' s_fun
                        line s_fun "return x;"
                    line s_fun "}"
                else
                    line s_fun (sprintf "__device__ UH%i * UH%i_%i(%s) { // %s" i i tag args k)
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"UH{i} * x = (UH{i} *) {malloc}(sizeof(UH{i}));"
                        line s_fun $"x->tag = {tag};"
                        line s_fun "x->refc = 1;"
                        if v.Length <> 0 then
                            v |> Array.map (fun (L(i,t)) -> $"x->case{tag}.v{i} = v{i};") |> line' s_fun
                        line s_fun $"return x;"
                    line s_fun "}"
                ) x.free_vars
            )
    and ustack : _ -> UnionRec = union_tmpl true
    and uheap : _ -> UnionRec = union_tmpl false
    and carray : _ -> ArrayRec =
        carray' (fun _ s_typ s_fun x ->
            let i, len_t, ptr_t = x.tag, prim size_t, tup_ty_tyvs x.tyvs
            line s_typ "typedef struct {"
            let _ =
                let s_typ = indent s_typ
                line s_typ "int refc;"
                line s_typ $"{len_t} len;"
                if ptr_t <> "void" then line s_typ $"{ptr_t} ptr[];" // flexible array member
            line s_typ (sprintf "} Array%i;" i)


            let print_body p s_fun q =
                let refcs = x.tyvs |> refc_change (fun i -> if 1 < x.tyvs.Length then $"v.v{i}" else "v") q
                if refcs.Length <> 0 then
                    p()
                    line s_fun (sprintf "for (%s i=0; i < len; i++){" len_t)
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"{ptr_t} v = ptr[i];"
                        refcs |> line' s_fun
                    line s_fun "}"

            line s_fun (sprintf "__device__ static inline void ArrayDecrefBody%i(Array%i * x){" i i)
            let _ =
                let s_fun = indent s_fun
                print_body (fun () ->
                    line s_fun $"{len_t} len = x->len;"
                    line s_fun $"{ptr_t} * ptr = x->ptr;"
                    ) s_fun -1
            line s_fun "}"

            print_decref s_fun $"ArrayDecref{i}" $"Array{i}" $"ArrayDecrefBody{i}"
            
            line s_fun (sprintf "__device__ Array%i * ArrayCreate%i(%s len, bool init_at_zero){" i i len_t)
            let _ =
                let s_fun = indent s_fun
                match ptr_t with
                | "void" -> line s_fun $"{len_t} size = sizeof(Array{i});"
                | _ -> line s_fun $"{len_t} size = sizeof(Array{i}) + sizeof({ptr_t}) * len;"
                line s_fun $"Array{i} * x = (Array{i} *) {malloc}(size);"
                line s_fun "if (init_at_zero) { memset(x,0,size); }"
                line s_fun "x->refc = 1;"
                line s_fun "x->len = len;"
                line s_fun "return x;"
            line s_fun "}"

            line s_fun (sprintf "__device__ Array%i * ArrayLit%i(%s len, %s * ptr){" i i len_t ptr_t)
            let _ =
                let s_fun = indent s_fun
                line s_fun $"Array{i} * x = ArrayCreate{i}(len, false);"
                if ptr_t <> "void" then 
                    line s_fun $"memcpy(x->ptr, ptr, sizeof({ptr_t}) * len);"
                    print_body (fun () -> ()) (indent s_fun) 1
                line s_fun "return x;"
            line s_fun "}"
            )
    and cstring : unit -> unit =
        cstring' (fun _ s_typ s_fun () ->
            let char = YPrim CharT
            let size_t, ptr_t, tag = prim size_t, tyv char, (carray char).tag
            line s_typ $"typedef Array{tag} String;"

            line s_fun "__device__ static inline void StringDecref(String * x){"
            line (indent s_fun) $"return ArrayDecref{tag}(x);"
            line s_fun "}"

            line s_fun (sprintf "__device__ static inline String * StringLit(%s len, %s * ptr){" size_t ptr_t)
            line (indent s_fun) $"return ArrayLit{tag}(len, ptr);"
            line s_fun "}"
            )

    global' "template <typename el, int dim> struct static_array { el v[dim]; };"
    global' "template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };"

    fun vs (x : TypedBind []) ->
        match binds_last_data x |> data_term_vars |> term_vars_to_tys with
        | [||] ->
            let main_defs' = {text=StringBuilder(); indent=0}
            let args = vs |> Array.mapi (fun i (L(_,x)) -> $"{tyv x} v{i}") |> String.concat ", "
            line main_defs' $"extern \"C\" __global__ void entry%i{main_defs.Count}(%s{args}) {{"
            binds_start [||] (indent main_defs') x
            line main_defs' "}"
            main_defs.Add(main_defs'.text.ToString())
        | _ ->
            raise_codegen_error $"The return type of the __global__ kernel in the Cuda backend should be a void type."
