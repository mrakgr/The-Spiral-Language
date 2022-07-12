module Spiral.Codegen.C

open Spiral
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval.Main
open Spiral.CodegenUtils
open System
open System.Text
open System.Collections.Generic

let line x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore
let line' x s = line x (String.concat " " s)
let is_heap = function
    | YUnion a when a.Item.layout = UHeap -> true
    | YPrim StringT | YLayout _ | YArray _ | YFun _ -> true
    | a -> false
let is_string = function DV(L(_,YPrim StringT)) | DLit(LitString _) -> true | _ -> false

let refc_used_vars (x : TypedBind []) =
    let g : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
    let fv x = x |> data_free_vars |> Set
    let jp (x : JoinPointCall) = snd x |> Set
    let rec binds x =
        Array.foldBack (fun k vs ->
            match k with
            | TyLet(d,_,o) -> vs + op o - fv d
            | TyLocalReturnOp(_,o,_) -> vs + op o
            | TyLocalReturnData(d,_) -> vs + fv d
            |> fun vs -> g.Add(k,vs); vs
            ) x Set.empty
    and op (x : TypedOp) : TyV Set =
        match x with
        | TyMacro l -> List.fold (fun s -> function CMTerm d -> s + fv d | _ -> s) Set.empty l
        | TyArrayLiteral(_,l) | TyOp(_,l) -> List.fold (fun s x -> s + fv x) Set.empty l
        | TyLayoutToHeap(x,_) | TyLayoutToHeapMutable(x,_)
        | TyUnionBox(_,x,_) | TyFailwith(_,x) | TyConv(_,x) | TyArrayCreate(_,x) | TyArrayLength(_,x) | TyStringLength(_,x) -> fv x
        | TyWhile(cond,body) -> jp cond + binds body
        | TyLayoutIndexAll(i) | TyLayoutIndexByKey(i,_) -> Set.singleton i
        | TyLayoutHeapMutableSet(i,_,d) -> Set.singleton i + fv d
        | TyJoinPoint x -> jp x
        | TyIf(cond,tr',fl') -> fv cond + binds tr' + binds fl'
        | TyUnionUnbox(vs,_,on_succs',on_fail') ->
            let vs = vs |> Set
            let on_fail = 
                match on_fail' with
                | Some x -> binds x
                | None -> Set.empty
            Map.fold (fun s k (lets,body) -> 
                let lets = List.fold (fun s x -> s + fv x) Set.empty lets
                s + (binds body - lets)
                ) (vs + on_fail) on_succs'
        | TyIntSwitch(tag,on_succs',on_fail') ->
            let vs = Set.singleton tag
            let on_fail = binds on_fail'
            Array.fold (fun s body -> s + binds body) (vs + on_fail) on_succs'
    binds x |> ignore
    g

let refc_decref_vars (free_vars : TyV Set) (x : TypedBind []) =
    let used_vars = refc_used_vars x
    let g : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
    let fv x = x |> data_free_vars |> Set
    let rec binds (vs : TyV Set) x =
        Array.fold (fun vs k ->
            let decref_vars = vs - used_vars.[k]
            g.Add(k,decref_vars)
            let r = vs - decref_vars
            match k with
            | TyLet(d,_,o) -> op Set.empty o; r + fv d
            | TyLocalReturnOp(_,o,_) -> op vs o; r
            | TyLocalReturnData(_,_) -> r
            ) vs x
        |> ignore
    and op vs (x : TypedOp) : unit =
        match x with
        | TyMacro _ | TyArrayLiteral _ | TyOp _ | TyLayoutToHeap _ | TyLayoutToHeapMutable _ | TyUnionBox _ | TyFailwith _ | TyConv _ | TyArrayCreate _ 
        | TyArrayLength _ | TyStringLength _ | TyLayoutIndexAll _ | TyLayoutIndexByKey _ | TyLayoutHeapMutableSet _ | TyJoinPoint _ -> ()
        | TyWhile(_,body) -> binds vs body
        | TyIf(_,tr',fl') -> binds vs tr'; binds vs fl'
        | TyUnionUnbox(_,_,on_succs',on_fail') ->
            Map.iter (fun k (lets,body) -> binds vs body) on_succs'
            Option.iter (binds vs) on_fail'
        | TyIntSwitch(_,on_succs',on_fail') ->
            Array.iter (binds vs) on_succs'
            binds vs on_fail'
    binds free_vars x
    g

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
type ArrayRec = {tag : int; ty : Ty; tyvs : TyV[]}
type CFunRec = {tag : int; domain_args_ty : Ty[]; range : Ty}

let size_t = UInt32T

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

    let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "

    let tmp =
        let mutable i = 0u
        fun () -> let x = i in i <- i + 1u; x

    let import =
        let has_added = HashSet()
        fun x -> if has_added.Add(x) then imports.Add $"#include <{x}>"

    let cimport =
        let has_added = HashSet()
        fun x -> if has_added.Add(x) then imports.Add $"#include \"{x}\""

    let tyvs_to_tys (x : TyV []) = Array.map (fun (L(i,t)) -> t) x

    let rec binds (decref_vars : Dictionary<TypedBind, TyV Set>) (s : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) = 
        let tup_destruct (a,b) =
            Array.map2 (fun (L(i,_)) b -> 
                match b with
                | WLit b -> $"v{i} = {lit b};"
                | WV (L(i',_)) -> $"v{i} = v{i'};"
                ) a b
        Array.iter (fun x ->
            decref_vars.[x] |> Set.toArray |> refc_decr |> line' s
            match x with
            | TyLet(d,trace,a) ->
                try let d = data_free_vars d
                    Array.map (fun (L(i,t)) -> $"{tyv t} v{i};") d |> line' s
                    op decref_vars s (BindsLocal d) a
                    refc_incr d |> line' s
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a,_) ->
                try op decref_vars s ret a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d,trace) ->
                try match ret with
                    | BindsLocal l -> line' s (tup_destruct (l,data_term_vars d))
                    | BindsTailEnd -> 
                        data_free_vars d |> refc_suppr |> line' s
                        line s $"return {tup_data d};"
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) stmts
    and refc_change' (f : int * Ty -> string) (c : string) (x : TyV []) : string [] =
        Array.choose (fun (L(i,t)) -> 
            match t with
            | YUnion a -> 
                match a.Item.layout with
                | UHeap -> Some $"UHRefc{(uheap a).tag}({f (i,t)}, {c});"
                | UStack -> Some $"USRefc{(ustack a).tag}(&({f (i,t)}), {c});"
            | YArray t -> Some $"ArrayRefc{(carray t).tag}({f (i,t)}, {c});" 
            | YFun(a,b) -> Some $"{f (i,t)}->refc_fptr({f (i,t)}, {c});"
            | YPrim StringT -> Some $"StringRefc({f (i,t)}, {c});" 
            | YLayout(a,Heap) -> Some $"HeapRefc{(heap a).tag}({f (i,t)}, {c});"
            | YLayout(a,HeapMutable) -> Some $"MutRefc{(mut a).tag}({f (i,t)}, {c});"
            | a -> None
            ) x
    and refc_change f c x = refc_change' (fun (i,t) -> f i) c x
    and refc_incr x : string [] = refc_change (fun i -> $"v{i}") "REFC_INCR" x
    and refc_decr x : string [] = refc_change (fun i -> $"v{i}") "REFC_DECR" x
    and refc_suppr (x : TyV []) : string [] = refc_change (fun i -> $"v{i}") "REFC_SUPPR" x
    and binds_start (args : TyV []) (s : CodegenEnv) (x : TypedBind []) = 
        refc_incr args |> line' s
        binds (refc_decref_vars (Set args) x) s BindsTailEnd x
    and show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
    and args' b = data_term_vars b |> Array.map show_w |> String.concat ", "
    and tup_term_vars x =
        let args = Array.map show_w x |> String.concat ", "
        if 1 < x.Length then sprintf "TupleCreate%i(%s)" (tup (term_vars_to_tys x)).tag args else args
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
        | YMacro a ->
            let f x =
                match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
                | [||] -> "void"
                | x -> String.concat ", " x
            a |> List.map (function Text a -> a | Type a -> f a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "Array%i *" (carray a).tag
        | YFun(a,b) -> sprintf "Fun%i *" (cfun (a,b)).tag
        | a -> raise_codegen_error (sprintf "Compiler error: Type not supported in the codegen.\nGot: %A" a) // TODO: Fix the bug cauing this to trigger in the save the princess test. 
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
            lit_string x |> sprintf "StringLit(%i, %s)" x.Length
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
    and op decref_vars s (ret : BindsReturn) a =
        let binds a b = binds decref_vars a b
        let return' (x : string) =
            match ret with
            | BindsTailEnd -> line s $"return {x};"
            | BindsLocal [||] -> line s $"{x};"
            | BindsLocal [|L(i,_)|] -> line s $"v{i} = {x};"
            | BindsLocal ret ->
                let tmp_i = tmp()
                line s $"{tup_ty_tyvs ret} tmp{tmp_i} = {x};"
                Array.mapi (fun i (L(i',_)) -> $"v{i'} = tmp{tmp_i}.v{i};") ret |> line' s
        let layout_index (x'_i : int) (x' : TyV []) =
            let gs = Array.map (fun (L(i',_)) -> $"v{x'_i}->v{i'}") x'
            match ret with
            | BindsTailEnd -> 
                let gs = String.concat ", " gs
                let tys = tyvs_to_tys x'
                if tys.Length <= 1 then $"return {gs};" else $"return Tuple{(tup tys).tag}({gs});" 
                |> line s
            | BindsLocal x -> 
                Array.map2 (fun (L(i,_)) g -> $"v{i} = {g};") x gs |> line' s
        let jp (a,b') =
            let args = args b'
            match ret with
            | BindsTailEnd -> refc_suppr b' |> line' s
            | BindsLocal _ -> ()
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "ClosureCreate%i(%s)" (closure (a,b)).tag args
        match a with
        | TyMacro a ->
            a |> List.map (function
                | CMText x -> x
                | CMTerm x -> tup_data x
                | CMType x -> tup_ty x
                ) |> String.concat "" |> return'
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if (%s){" (tup_data cond))
            binds (indent s) ret tr
            line s "} else {"
            binds (indent s) ret fl
            line s "}"
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyWhile(a,b) ->
            line s (sprintf "while (%s){" (jp a))
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
                        let a = data_free_vars a
                        Array.mapi (fun field_i (L(v_i,t)) ->
                            $"{tyv t} v{v_i} = v{data_i}{acs}case{union_i}.v{field_i};"
                            ) a
                        |> line' (indent s)
                        ) is a
                    binds (indent s) ret b
                    line (indent s) "break;"
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
        | TyLayoutToHeap(a,b) -> sprintf "HeapCreate%i(%s)" (heap b).tag (args' a) |> return'
        | TyLayoutToHeapMutable(a,b) -> sprintf "MutCreate%i(%s)" (mut b).tag (args' a) |> return'
        | TyLayoutIndexAll(x) -> match x with L(i,YLayout(a,lay)) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i | _ -> failwith "Compiler error: Expected the TyV in layout index to be a layout type."
        | TyLayoutIndexByKey(x,key) -> match x with L(i,YLayout(a,lay)) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i | _ -> failwith "Compiler error: Expected the TyV in layout index by key to be a layout type."
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let q = mut t // `mut t` is correct here, peval strips the YLayout.
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") q.data b 
            Array.map2 (fun (L(i',_)) b -> $"&v{i}->v{i'}, {show_w b}") (data_free_vars a) (data_term_vars c) |> String.concat ", " 
            |> sprintf "AssignMut%i(%s)" (assign_mut (tyvs_to_tys q.free_vars)).tag |> line s
        | TyArrayLiteral(a,b) -> 
            let b = b |> List.map tup_data |> String.concat "," |> sprintf "{%s}"
            $"ArrayLit{(carray a).tag}({b.Length}, ({tup_ty a} []){b})" |> return'
        | TyArrayCreate(a,b) -> 
            let is_heap : bool = a |> env.ty_to_data |> data_free_vars |> Array.exists (fun (L(_,t)) -> is_heap t)
            $"ArrayCreate{(carray a).tag}({tup_data b},{is_heap})" |> return'
        | TyFailwith(a,b) -> 
            let fmt = @"%s\n"
            match b with DLit (LitString b) -> lit_string b | _ -> $"{tup_data b}->ptr" 
            |> fun b -> line s $"fprintf(stderr, \"{fmt}\", {b})"
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
            | Apply,[a;b'] -> 
                match tup_data a, args' b' with
                | a, "" -> $"{a}->fptr({a})"
                | a, b -> $"{a}->fptr({a}, {b})"
            | Dyn,[a] -> tup_data a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringIndex, [a;b] -> sprintf "%s->ptr[%s]" (tup_data a) (tup_data b)
            | StringSlice, [a;b;c] -> raise_codegen_error "String slice is not supported natively in the C backend. Use a library implementation instead."
            | ArrayIndex, [DV(L(_,YArray t)) & a;b] -> 
                match tup_ty t with
                | "void" -> "/* void array index */"
                | _ -> sprintf "%s->ptr[%s]" (tup_data a) (tup_data b)
            | ArrayIndexSet, [DV(L(_,YArray t)) as a;b;c] -> 
                let a',b',c' = tup_data a, tup_data b, tup_data c
                match c' with
                | "" -> "/* void array set */"
                | _ -> $"AssignArray{(assign_array (tyvs_to_tys (carray t).tyvs)).tag}({a'}->ptr+{b'}, {c'})"
            // Math
            | Add, [a;b] -> sprintf "%s + %s" (tup_data a) (tup_data b)
            | Sub, [a;b] -> sprintf "%s - %s" (tup_data a) (tup_data b)
            | Mult, [a;b] -> sprintf "%s * %s" (tup_data a) (tup_data b)
            | Div, [a;b] -> sprintf "%s / %s" (tup_data a) (tup_data b)
            | Mod, [a;b] -> sprintf "%s %% %s" (tup_data a) (tup_data b)
            | Pow, [a;b] -> sprintf "pow%s(%s,%s)" (float_suffix a) (tup_data a) (tup_data b)
            | LT, [a;b] -> sprintf "%s < %s" (tup_data a) (tup_data b)
            | LTE, [a;b] -> sprintf "%s <= %s" (tup_data a) (tup_data b)
            | EQ, [a;b] when is_string a -> sprintf "strcmp(%s, %s) == 0" (tup_data a) (tup_data b) // TODO: Optimize string structural comparison in the real_core
            | NEQ, [a;b] when is_string a -> sprintf "strcmp(%s, %s) != 0" (tup_data a) (tup_data b)
            | GT, [a;b] when is_string a -> sprintf "strcmp(%s, %s) > 0" (tup_data a) (tup_data b)
            | GTE, [a;b] when is_string a -> sprintf "strcmp(%s, %s) >= 0" (tup_data a) (tup_data b)
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
                match l.Item.layout with
                | UHeap -> "->tag"
                | UStack -> ".tag"
                |> sprintf "%s%s" (tup_data x)
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
            binds_start x.free_vars (indent s_fun) x.body
            line s_fun "}"
            )
    and closure : _ -> ClosureRec =
        jp (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s_typ s_fun x ->
            
            let i, range = x.tag, tup_ty x.range
            let free_vars = x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}")

            line s_typ "typedef struct {"
            free_vars |> Array.iter (fun x -> line (indent s_typ) $"{x};")
            line s_typ (sprintf "} ClosureEnv%i;" i)
            
            line s_typ (sprintf "typedef struct Closure%i Closure%i;" i i)
            line s_typ (sprintf "struct Closure%i {" i)
            let _ =
                let s_typ = indent s_typ
                line s_typ $"int refc;"
                line s_typ $"void (*refc_fptr)(Closure{i} *, int);"
                match x.domain_args |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat ", " with
                | "" -> $"{range} (*fptr)(Closure{i} *);"
                | domain_args_ty -> $"{range} (*fptr)(Closure{i} *, {domain_args_ty});"
                |> line s_typ
                line s_typ $"ClosureEnv{i} env[];"
            line s_typ "};"

            line s_fun (sprintf "static inline void ClosureRefcBody%i(Closure%i * x, REFC_FLAG q){" i i)
            let _ =
                let s_fun = indent s_fun
                let refcs = x.free_vars |> refc_change (fun i -> $"env.v{i}") "q"
                if refcs.Length <> 0 then
                    line s_fun $"ClosureEnv{i} env = x->env[0];"
                    refcs |> line' s_fun
            line s_fun "}"

            line s_fun (sprintf "void ClosureRefc%i(Closure%i * x, REFC_FLAG q){" i i)
            let _ =
                let s_fun = indent s_fun
                line s_fun "if (x != NULL) {"
                let _ =
                    let s_fun = indent s_fun
                    line s_fun "int refc = (x->refc += q & REFC_INCR ? 1 : -1);"
                    line s_fun "if (!(q & REFC_SUPPR) && refc == 0) {"
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"ClosureRefcBody{i}(x, REFC_DECR);"
                        line s_fun "free(x);"
                    line s_fun "}"
                line s_fun "}"
            line s_fun "}"
            
            match x.domain_args |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", " with
            | "" -> sprintf "%s ClosureMethod%i(Closure%i * x){" range i i
            | domain_args -> sprintf "%s ClosureMethod%i(Closure%i * x, %s){" range i i domain_args
            |> line s_fun
            let _ =
                let s_fun = indent s_fun
                if x.free_vars.Length <> 0 then
                    line s_fun $"ClosureEnv{i} * env = x->env;"
                    x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i} = env->v{i};") |> line' s_fun
                binds_start x.domain_args s_fun x.body
            line s_fun "}"

            let fun_tag = (cfun (x.domain,x.range)).tag
            line s_fun (sprintf "Fun%i * ClosureCreate%i(%s){" fun_tag i (String.concat ", " free_vars))
            let _ =
                let s_fun = indent s_fun
                line s_fun $"Closure{i} * x = malloc(sizeof(Closure{i}) + sizeof(ClosureEnv{i}));"
                line s_fun "x->refc = 0;"
                line s_fun $"x->refc_fptr = ClosurRefc{i};"
                line s_fun $"x->fptr = ClosureMethod{i};"
                if x.free_vars.Length <> 0 then
                    line s_fun $"ClosureEnv{i} * env = x->env;"
                    x.free_vars |> Array.map (fun (L(i,_)) -> $"env->v{i} = v{i};")  |> line' s_fun
                    line s_fun $"ClosureRefcBody{i}(x,REFC_INCR);"
                line s_fun $"return (Fun{fun_tag} *) x;"
            line s_fun "}"
            )
    and cfun : _ -> CFunRec =
        cfun' (fun s_typ s_fun x ->
            let i, range = x.tag, tup_ty x.range
            line s_typ $"typedef struct Fun{i} Fun{i};"
            line s_typ (sprintf "struct Fun%i{" i)
            let _ =
                let s_typ = indent s_typ
                line s_typ $"int refc;"
                line s_typ $"void (*refc_fptr)(Fun{i} *, int);"
                match x.domain_args_ty |> Array.map (fun t -> tyv t) |> String.concat ", " with
                | "" -> $"{range} (*fptr)(Fun{i} *);"
                | domain_args_ty -> $"{range} (*fptr)(Fun{i} *, {domain_args_ty});"
                |> line s_typ
            line s_typ "};"
            )
    and tup : _ -> TupleRec = 
        tuple (fun s_typ s_fun x ->
            let name = sprintf "Tuple%i" x.tag
            let args = x.tys |> Array.mapi (fun i x -> $"{tyv x} v{i}")
            line s_typ "typedef struct {"
            args |> Array.iter (fun x -> line (indent s_typ) $"{x};")
            line s_typ (sprintf "} %s;" name)

            line s_fun (sprintf "static inline %s TupleCreate%i(%s){" name x.tag (String.concat ", " args))
            let _ =
                let s_fun = indent s_fun
                line s_fun $"{name} x;"
                Array.init args.Length (fun i -> $"x.v{i} = v{i};") |> line' s_fun
                line s_fun $"return x;"
            line s_fun "}"
            )
    and assign_mut : _ -> TupleRec = 
        tuple (fun s_typ s_fun x ->
            let tyvs = Array.mapi (fun i t -> L(i,t)) x.tys
            let args = Array.mapi (fun i t -> let t = tyv t in $"{t} * a{i}, {t} b{i}") x.tys |> String.concat ", "
            line s_fun (sprintf "static inline void AssignMut%i(%s){" x.tag args)
            let _ =
                let s_fun = indent s_fun
                refc_change (fun i -> $"b{i}") "REFC_INCR" tyvs |> line' s_fun
                refc_change (fun i -> $"*a{i}") "REFC_DECR" tyvs |> line' s_fun
                Array.init tyvs.Length (fun i -> $"*a{i} = b{i};") |> line' s_fun
            line s_fun "}"
            )
    and assign_array : _ -> TupleRec = 
        tuple (fun s_typ s_fun x ->
            let tyvs, T = Array.mapi (fun i t -> L(i,t)) x.tys, tup_ty_tys x.tys
            line s_fun (sprintf "static inline void AssignArray%i(%s * a, %s b){" x.tag T T)
            let _ =
                let s_fun = indent s_fun
                match tyvs with
                | [||] -> raise_codegen_error "Compiler error: Void types not allowed in assign."
                | [|t|] -> 
                    refc_change (fun i -> "b") "REFC_INCR" tyvs |> line' s_fun
                    refc_change (fun i -> "*a") "REFC_DECR" tyvs |> line' s_fun
                    $"*a = b;" |> line s_fun
                | _ ->
                    refc_change (fun i -> $"b.v{i}") "REFC_INCR" tyvs |> line' s_fun
                    refc_change (fun i -> $"a->v{i}") "REFC_DECR" tyvs |> line' s_fun
                    $"*a = b;" |> line s_fun
            line s_fun "}"
            )
    and layout_tmpl name : _ -> LayoutRec =
        layout (fun s_typ s_fun (x : LayoutRec) ->
            let i = x.tag
            let name' = sprintf "%s%i" name i
            let args = x.free_vars |> Array.map (fun (L(i,x)) -> $"{tyv x} v{i}")

            line s_typ "typedef struct {"
            let _ =
                let s_typ = indent s_typ
                line s_typ "int refc;"
                Array.iter (fun x -> line s_typ $"{x};") args
            line s_typ (sprintf "} %s;" name')

            line s_fun (sprintf "static inline void %sRefcBody%i(%s * x, REFC_FLAG q){" name i name')
            let _ =
                let s_fun = indent s_fun
                let refc_vars = ResizeArray()
                let refcs = x.free_vars |> refc_change' (fun (i,t) -> refc_vars.Add($"{tyv t} z{i} = x->v{i};"); $"z{i}") "q" 
                if refcs.Length <> 0 then
                    refc_vars |> line' s_fun 
                    refcs |> line' s_fun
            line s_fun "}"

            line s_fun (sprintf "void %sRefc%i(%s * x, REFC_FLAG q){" name i name')
            let _ =
                let s_fun = indent s_fun
                line s_fun "if (x != NULL) {"
                let _ =
                    let s_fun = indent s_fun
                    line s_fun "int refc = (x->refc += q & REFC_INCR ? 1 : -1);"
                    line s_fun "if (!(q & REFC_SUPPR) && refc == 0) {"
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"{name}RefcBody{i}(x, REFC_DECR);"
                        line s_fun "free(x);"
                    line s_fun "}"
                line s_fun "}"
            line s_fun "}"

            line s_fun (sprintf "%s * %sCreate%i(%s){" name' name i (String.concat ", " args))
            let _ =
                let s_fun = indent s_fun
                line s_fun $"{name'} * x = malloc(sizeof({name'}));"
                line s_fun "x->refc = 0;"
                Array.init args.Length (fun i -> $"x->v{i} = v{i};") |> line' (indent s_fun)
                line s_fun $"{name}RefcBody{i}(x, REFC_INCR);"
                line s_fun $"return x;"
            line s_fun "}"
            )
    and heap : _ -> LayoutRec = layout_tmpl "Heap"
    and mut : _ -> LayoutRec = layout_tmpl "Mut"
    and union_tmpl is_stack : Union -> UnionRec = 
        let inline map_iteri f x = Map.fold (fun i k v -> f i k v; i+1) 0 x |> ignore
        union (fun s_typ s_fun x ->
            let i = x.tag
            match is_stack with
            | true  -> line s_typ "typedef struct {"
            | false -> 
                line s_typ (sprintf "typedef struct UH%i UH%i;" i i)
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
                            v |> Array.iter (fun (L(i,t)) -> line (indent s_typ) $"{tyv t} v{i};")
                            line s_typ (sprintf "} case%i; // %s" tag k)
                        ) x.free_vars
                line s_typ "};"
            match is_stack with
            | true  -> line s_typ (sprintf "} US%i;" i)
            | false -> line s_typ "};"

            match is_stack with
            | true  -> line s_fun (sprintf "static inline void USRefcBody%i(US%i x, REFC_FLAG q){" i i)
            | false -> line s_fun (sprintf "static inline void UHRefcBody%i(UH%i x, REFC_FLAG q){" i i)
            let _ =
                let s_fun = indent s_fun
                line s_fun "switch (x.tag) {"
                map_iteri (fun tag k v -> 
                    let s_fun = indent s_fun
                    line s_fun (sprintf "case %i: {" tag)
                    let _ =
                        let s_fun = indent s_fun
                        v |> refc_change (fun i -> $"x.case{tag}.v{i}") "q" |> line' s_fun
                    line s_fun "}"
                    ) x.free_vars
                line s_fun "}"
            line s_fun "}"

            match is_stack with
            | true  -> 
                line s_fun (sprintf "void USRefc%i(US%i * x, REFC_FLAG q){" i i)
                line (indent s_fun) $"USRefcBody{i}(*x, q);"
                line s_fun "}"
            | false -> 
                line s_fun (sprintf "void UHRefc%i(UH%i * x, REFC_FLAG q){" i i)
                let _ =
                    let s_fun = indent s_fun
                    line s_fun "if (x != NULL) {"
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun "int refc = (x->refc += q & REFC_INCR ? 1 : -1);"
                        line s_fun "if (!(q & REFC_SUPPR) && refc == 0) {"
                        let _ =
                            let s_fun = indent s_fun
                            line s_fun $"UHRefcBody{i}(*x, REFC_DECR);"
                            line s_fun "free(x);"
                        line s_fun "}"
                    line s_fun "}"
                line s_fun "}"

            map_iteri (fun tag k v -> 
                let args = v |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", "
                match is_stack with
                | true  -> line s_fun (sprintf "US%i US%i_%i(%s) { // %s" i i tag args k)
                | false -> line s_fun (sprintf "UH%i * UH%i_%i(%s) { // %s" i i tag args k)
                let _ =
                    let s_fun = indent s_fun
                    match is_stack with
                    | true  -> line s_fun $"US{i} x;"
                    | false -> line s_fun $"UH{i} x;"
                    line s_fun $"x.tag = {tag};"
                    if 0 < v.Length then
                        v |> Array.map (fun (L(i,t)) -> $"x.case{tag}.v{i} = v{i};") |> line' s_fun
                    match is_stack with
                    | true  ->
                        line s_fun $"USRefcBody{i}(x,REFC_INCR);"
                        line s_fun "return x;"
                    | false -> 
                        line s_fun $"UHRefcBody{i}(x,REFC_INCR);"
                        line s_fun $"return memcpy(malloc(sizeof(UH{i})),&x,sizeof(UH{i}));"
                line s_fun (sprintf "}")
                ) x.free_vars
            )
    and ustack : _ -> UnionRec = union_tmpl true
    and uheap : _ -> UnionRec = union_tmpl false
    and carray : _ -> ArrayRec =
        carray' (fun s_typ s_fun x ->
            let i, size_t, ptr_t = x.tag, prim size_t, tup_ty_tyvs x.tyvs
            line s_typ "typedef struct {"
            let _ =
                let s_typ = indent s_typ
                line s_typ "int refc;"
                line s_typ $"{size_t} len;"
                if ptr_t <> "void" then line s_typ $"{ptr_t} ptr[];" // flexible array member
            line s_typ (sprintf "} Array%i;" i)

            line s_fun (sprintf "static inline void ArrayRefcBody%i(Array%i * x, REFC_FLAG q){" i i)
            let _ =
                let s_fun = indent s_fun
                let refcs = x.tyvs |> refc_change (fun i -> $"v->v{i}") "q"
                if refcs.Length <> 0 then
                    line s_fun (sprintf "for (%s i=0; i < x->len; i++){" size_t)
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"{ptr_t} v = x->ptr[i];"
                        refcs |> line' s_fun
                    line s_fun "}"
            line s_fun "}"

            line s_fun (sprintf "void ArrayRefc%i(Array%i * x, REFC_FLAG q){" i i)
            let _ =
                let s_fun = indent s_fun
                line s_fun "if (x != NULL) {"
                let _ =
                    let s_fun = indent s_fun
                    line s_fun "int refc = (x->refc += q & REFC_INCR ? 1 : -1);"
                    line s_fun "if (!(q & REFC_SUPPR) && refc == 0) {"
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"ArrayRefcBody{i}(x, REFC_DECR);"
                        line s_fun "free(x);"
                    line s_fun "}"
                line s_fun "}"
            line s_fun "}"

            line s_fun (sprintf "Array%i * ArrayCreate%i(%s size, bool init_at_zero){" i i size_t)
            let _ =
                let s_fun = indent s_fun
                line s_fun "x->refc = 0;"
                match ptr_t with
                | "void" -> line s_fun $"Array{i} * x = malloc(sizeof(Array{i}));"
                | _ -> line s_fun $"Array{i} * x = (init_at_zero ? calloc : malloc)(sizeof(Array{i}) + sizeof({ptr_t}) * size);"
                line s_fun "x->len = size;"
                line s_fun "return x;"
            line s_fun "}"

            line s_fun (sprintf "Array%i * ArrayLit%i(%s size, %s * ptr){" i i size_t ptr_t)
            let _ =
                let s_fun = indent s_fun
                line s_fun $"Array{i} * x = ArrayCreate{i}(size, false);"
                if ptr_t <> "void" then 
                    line s_fun $"memcpy(x->ptr, ptr, sizeof({ptr_t}) * size);"
                    line s_fun $"ArrayRefcBody{i}(x,REFC_INCR);"
                line s_fun "return x;"
            line s_fun "}"
            )
    and cstring : unit -> unit =
        cstring' (fun s_typ s_fun () ->
            let char = YPrim CharT
            let size_t, ptr_t, tag = prim size_t, tyv char, (carray char).tag
            line s_typ $"typedef Array{tag} String;"

            line s_fun "static inline void StringRefc(String * x, REFC_FLAG q){"
            line (indent s_fun) $"return ArrayRefc{tag}(x, q);"
            line s_fun "}"

            line s_fun (sprintf "static inline String * StringLit(%s size, %s * ptr){" size_t ptr_t)
            line (indent s_fun) $"return ArrayLit{tag}(size, ptr);"
            line s_fun "}"
            )

    match binds_last_data x |> data_term_vars |> term_vars_to_tys with
    | [|YPrim Int32T|] ->
        import "stdbool.h"
        import "stdint.h"
        import "stdio.h"
        import "stdlib.h"
        import "string.h"
        import "math.h"
        types.Add("typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;")

        let main_defs = {text=StringBuilder(); indent=0}
        line main_defs (sprintf "%s main(){" (prim Int32T))
        binds_start [||] (indent main_defs) x
        line main_defs "}"

        let program = StringBuilder()

        imports |> Seq.iter (fun x -> program.AppendLine(x) |> ignore)
        types |> Seq.iter (fun x -> program.Append(x) |> ignore)
        functions |> Seq.iter (fun x -> program.Append(x) |> ignore)
        program.Append(main_defs.text).ToString()
    | _ ->
        raise_codegen_error "The return type of main in the C backend should be a 32-bit int."