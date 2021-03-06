﻿module Spiral.Codegen.Cython

open Spiral
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval.Main
open Spiral.CodegenUtils

open System
open System.Text
open System.Collections.Generic

// In order to have block scoped variables, the Cython backend does del insertion.
// TCO support is not complete yet.
// https://github.com/cython/cython/issues/3999
let tco_enabler (x : TypedBind []) =
    let is_tailend = HashSet(HashIdentity.Reference)
    let reqs_tco = HashSet(HashIdentity.Reference)

    // Shortcutting workaround.
    let or' a b = a || b
    let rec binds x = 
        let x = Array.last x
        match x with
        | TyLet _ -> failwith "Compiler error: This function should only be called on the last statement of a sequence."
        | TyLocalReturnOp(_,o,_) ->
            let has_jp = ops o
            is_tailend.Add(o :> obj) |> ignore
            if has_jp then reqs_tco.Add(o :> obj) |> ignore
            has_jp
        | TyLocalReturnData(d,_) ->
            is_tailend.Add(d) |> ignore
            false
    and ops = function
        | TyJoinPoint(JPMethod _,_) -> true
        | TyUnionUnbox(_,_,a,b) -> or' (Map.fold (fun s _ (_,x) -> or' s (binds x)) false a) (match b with Some x -> binds x | _ -> false)
        | TyIntSwitch(_,a,b) -> or' (Array.fold (fun s x -> or' s (binds x)) false a) (binds b)
        | TyIf(_,a,b) -> or' (binds a) (binds b)
        | _ -> false
        
    let _ = binds x
    is_tailend, reqs_tco

let is_stack = function
    | YPrim (UInt8T | UInt16T | UInt32T | UInt64T
        | Int8T | Int16T | Int32T | Int64T 
        | Float32T | Float64T | BoolT) -> true
    | YUnion x -> x.Item.is_degenerate
    | _ -> false

let nullable_vars_of (x : TypedBind []) =
    let is_tailend, reqs_tco = tco_enabler x
    let nulls = Dictionary<obj,_>(HashIdentity.Reference)
    let tag_fun (L(i,t)) = if is_stack t then None else Some i
    let tags'' d = d |> List.choose tag_fun |> Set
    let tags' d = d |> Array.choose tag_fun |> Set
    let tags d = data_free_vars d |> tags'
    let jp (x : JoinPointCall) = snd x |> tags'
    let rec binds (init_freeable : Tag Set) (init_used : Tag Set) (x : TypedBind []) = 
        let rec loop (freeable : Tag Set) i =
            let st = x.[i]
            match st with
            | TyLet(d,_,o) ->
                let d = tags d
                let next_used = loop (d + freeable) (i+1)
                let op_nulls, op_used = ops freeable next_used o
                let d_nulls = d |> Set.filter (fun i -> Set.contains i next_used = false)
                nulls.[st] <- d_nulls + op_nulls
                op_used - Set d
            | TyLocalReturnOp(_,o,_) ->
                let next_used = init_used
                let op_nulls, op_used = ops freeable next_used o
                nulls.[st] <- op_nulls
                op_used
            | TyLocalReturnData(d',_) ->
                let d = tags d'
                let next_used = init_used
                if is_tailend.Contains(d') then
                    nulls.[st] <- Set.empty
                else
                    let op_nulls = d |> Set.filter (fun i -> Set.contains i freeable && Set.contains i next_used = false)
                    nulls.[st] <- op_nulls
                d + next_used
        loop init_freeable 0
    and ops (freeable : Tag Set) (used : Tag Set) (x : TypedOp) =
        let return_op used' =
            let nulls =
                if is_tailend.Contains(x) then Set.empty
                else used' |> Set.filter (fun i -> Set.contains i freeable && Set.contains i used = false)
            nulls, used + used'
        let freeable_local d = List.fold (fun s x -> s + tags x) Set.empty d
        let binds_tco' (d,x) = 
            let freeable_local = freeable_local d
            let new_used = binds (freeable_local + freeable) used x - used
            new_used - freeable_local, freeable_local - new_used
        let binds_reg' (d,x) = 
            let freeable_local = freeable_local d
            let new_used = binds freeable_local Set.empty x
            new_used - freeable_local, freeable_local - new_used
        let binds_tco x = binds freeable used x - used
        let binds_reg x = binds Set.empty Set.empty x
        match x with
        | TyMacro l -> List.fold (fun s -> function CMTerm d -> s + tags d | _ -> s) Set.empty l
        | TyArrayLiteral(_,l) | TyOp(_,l) -> List.fold (fun s x -> s + tags x) Set.empty l
        | TyLayoutToHeap(x,_) | TyLayoutToHeapMutable(x,_)
        | TyUnionBox(_,x,_) | TyFailwith(_,x) | TyArrayCreate(_,x) | TyArrayLength(_,x) | TyStringLength(_,x) -> tags x
        | TyWhile(cond, body) -> nulls.[body] <- Set.empty; jp cond + binds Set.empty Set.empty body
        | TyLayoutIndexAll(L(i,_)) | TyLayoutIndexByKey(L(i,_),_) -> Set.singleton i
        | TyLayoutHeapMutableSet(L(i,_),_,d) -> Set.singleton i + tags d
        | TyJoinPoint x -> jp x
        | TyIf(cond,tr',fl') -> 
            if reqs_tco.Contains(x) then
                let tr = binds_tco tr'
                let fl = binds_tco fl'
                let all = tr + fl
                let all_freeable = Set.intersect all freeable
                nulls.[tr'] <- all_freeable - tr
                nulls.[fl'] <- all_freeable - fl
                tags cond + all
            else
                nulls.[tr'] <- Set.empty
                nulls.[fl'] <- Set.empty
                tags cond + binds_reg tr' + binds_reg fl'
        | TyUnionUnbox(vs,_,on_succs',on_fail') ->
            let vs = tags'' vs
            if reqs_tco.Contains(x) then
                let on_succs = Map.map (fun _ -> binds_tco') on_succs'
                let on_fail = match on_fail' with Some body -> binds_tco body | _ -> Set.empty
                let all = Map.fold (fun s _ v -> s + fst v) on_fail on_succs
                let all_freeable = Set.intersect all freeable
                Map.iter (fun k (_,body) -> let freeable, local_unused = on_succs.[k] in nulls.[body] <- all_freeable - freeable + local_unused) on_succs'
                match on_fail' with Some body -> nulls.[body] <- all_freeable - on_fail | _ -> ()
                vs + all
            else
                let on_succs = Map.map (fun _ -> binds_reg') on_succs'
                Map.iter (fun k (_, local_unused) -> nulls.[snd on_succs'.[k] : TypedBind []] <- local_unused) on_succs
                match on_fail' with Some body -> nulls.[body] <- Set.empty | _ -> ()
                let on_fail = match on_fail' with Some body -> binds_reg body | _ -> Set.empty
                let all = Map.fold (fun s _ v -> s + fst v) on_fail on_succs
                vs + all
        | TyIntSwitch(tag,on_succs',on_fail') ->
            if reqs_tco.Contains(x) then
                let on_succs = Array.map binds_tco on_succs'
                let on_fail = binds_tco on_fail'
                let all = Array.fold Set.union on_fail on_succs
                let all_freeable = Set.intersect all freeable
                Array.iter2 (fun body v -> nulls.[body] <- all_freeable - v) on_succs' on_succs
                nulls.[on_fail'] <- all_freeable - on_fail
                Set.singleton tag + all
            else
                Array.iter (fun body -> nulls.[body] <- Set.empty) on_succs'
                nulls.[on_fail'] <- Set.empty
                let on_succs = Array.fold (fun s x -> s + binds_reg x) Set.empty on_succs'
                let on_fail = binds_reg on_fail'
                Set.singleton tag + on_succs + on_fail
        |> return_op
    let freeable = Set.empty
    let used = binds freeable Set.empty x
    // Function call args do not need to be freed in Cython. This is unfortunate as it blocks TCO on some cases.
    nulls.[x] <- Set.empty // freeable - used
    nulls

let lit = function
    | LitInt8 x -> sprintf "(<signed char>%i)" x
    | LitInt16 x -> sprintf "(<signed short>%i)" x
    | LitInt32 x -> sprintf "(<signed long>%i)" x
    | LitInt64 x -> sprintf "(<signed long long>%i)" x
    | LitUInt8 x -> sprintf "(<unsigned char>%i)" x
    | LitUInt16 x -> sprintf "(<unsigned short>%i)" x
    | LitUInt32 x -> sprintf "(<unsigned long>%i)" x
    | LitUInt64 x -> sprintf "(<unsigned long long>%i)" x
    | LitFloat32 x -> 
        if x = infinityf then "(<float>float('inf'))"
        elif x = -infinityf then "(<float>float('-inf'))"
        elif Single.IsNaN x then "(<float>float())"
        else sprintf "(<float>%s)" (x.ToString("R"))
    | LitFloat64 x ->
        if x = infinity then "(<double>float('inf'))"
        elif x = -infinity then "(<double>float('-inf'))"
        elif Double.IsNaN x then "(<double>float())"
        else sprintf "(<double>%s)" (x.ToString("R"))
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
    | Int8T -> "signed char" | Int16T -> "signed short" | Int32T -> "signed long" | Int64T -> "signed long long"
    | UInt8T -> "unsigned char" | UInt16T -> "unsigned short" | UInt32T -> "unsigned long" | UInt64T -> "unsigned long long"
    | Float32T -> "float" | Float64T -> "double"
    | BoolT -> "bint"
    | StringT | CharT -> "str"

type UnionRec = {free_vars : Map<string, TyV[]>; tag : int; is_degenerate : bool}
type LayoutRec = {data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>; tag : int}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}
type TupleRec = {tag : int; tys : string []}

type BindsReturn =
    | BindsTailEnd of is_void : bool
    | BindsLocal of TyV []

let codegen is_except_star (env : PartEvalResult) (x : TypedBind []) =
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
        let f (a : Union) : UnionRec = 
            let free_vars = a.Item.cases |> Map.map (fun _ -> env.ty_to_data >> data_free_vars)
            {free_vars=free_vars; tag=dict.Count; is_degenerate=a.Item.is_degenerate}
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

    let cimport =
        let has_added = HashSet()
        fun x -> if has_added.Add(x) then imports.Add $"cimport {x}"

    let with_self = function "" -> "self" | x -> $"self, {x}"
    let pass_if_empty = function "" -> "pass" | x -> x

    let binds_last_data x = x |> Array.last |> function TyLocalReturnData(x,_) | TyLocalReturnOp(_,_,x) -> x | TyLet _ -> raise_codegen_error "Compiler error: Cannot find the return data of the last bind."
    let set_to_none (i : int) = $"del v{i}"
    let print_nullables' (nulls : Tag Set) s = Set.toArray nulls |> Array.map set_to_none |> String.concat "; " |> function "" -> () | x -> line s x
    let print_nullables (nulls : Dictionary<obj,Tag Set>) s (x : obj) = print_nullables' nulls.[x] s

    let numpy_ty x = 
        match env.ty_to_data x |> data_free_vars with
        | [|L(_,x)|] ->
            match x with
            | YPrim x ->
                match x with
                | Int8T -> "numpy.int8"
                | Int16T -> "numpy.int16"
                | Int32T -> "numpy.int32"
                | Int64T -> "numpy.int64"
                | UInt8T -> "numpy.uint8"
                | UInt16T -> "numpy.uint16"
                | UInt32T -> "numpy.uint32"
                | UInt64T -> "numpy.uint64"
                | Float32T -> "numpy.float32"
                | Float64T -> "numpy.float64"
                | BoolT -> "numpy.int8"
                | _ -> "object"
            | YUnion l -> if l.Item.is_degenerate then "numpy.int32" else "object"
            | _ -> "object"
        | _ -> "object"

    let show_except q =
        if is_except_star then 
            let b = 
                match q with 
                | "void" -> true
                | "float" | "double" | "bint" -> true
                | x when x.StartsWith "signed" || x.StartsWith "unsigned" -> true
                | _ -> false
            if b then " except *" else ""
        else ""

    let rec tyv = function
        | YUnion a -> 
            match a.Item.layout with
            | UHeap -> sprintf "UH%i" (uheap a).tag
            | UStack -> sprintf "US%i" (ustack a).tag
        | YLayout(a,Heap) -> sprintf "Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i" (mut a).tag
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a ->
            import "numpy"; cimport "numpy"
            // Cython arrays have various restrictions. The inability to give more precise types to container elements will result in runtime typechecks.
            // https://github.com/cython/cython/issues/3995
            let a =
                match env.ty_to_data a |> data_free_vars with 
                | [|L(_,x)|] -> 
                    match x with
                    | YPrim x -> prim x
                    | YUnion x -> if x.Item.is_degenerate then "signed long" else "object"
                    | _ -> "object"
                | _ -> "object"
            $"numpy.ndarray[{a},ndim=1]"
        | YFun _ -> "object" // Function types used to be more precise, but now I am using objects for the sake of interop. See commit at 2/25/2021 for the more efficient version.
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and binds' (defs : CodegenEnv) (x : TypedBind []) =
        let s = {defs with text = StringBuilder()}
        binds (nullable_vars_of x) defs s (BindsTailEnd(binds_last_data x |> data_term_vars |> Array.isEmpty)) x
        defs.text.Append(s.text) |> ignore
    and binds_loop (nulls : Dictionary<obj,Tag Set>) (defs : CodegenEnv) (s : CodegenEnv) ret (stmts : TypedBind []) =
        let rec loop i =
            if i < stmts.Length then
                let inline op a b c d = function
                    | TyFailwith(_,b) -> line s $"raise Exception({tup b})"; false
                    | e -> op a b c d e; true
                let x = stmts.[i]
                match x with
                | TyLet(d,trace,a) ->
                    try let d = data_free_vars d
                        Array.iter (fun (L(i,t)) -> cdef_show "" defs i (tyv t)) d
                        op nulls defs s (BindsLocal d) a
                    with :? CodegenError as e -> raise_codegen_error' trace e.Data0
                | TyLocalReturnOp(trace,a,_) ->
                    try op nulls defs s ret a
                    with :? CodegenError as e -> raise_codegen_error' trace e.Data0
                | TyLocalReturnData(d,trace) ->
                    try match ret with
                        | BindsLocal [||] | BindsTailEnd true -> if i = 0 then line s "pass"
                        | BindsTailEnd false -> line s $"return {tup d}"
                        | BindsLocal ret -> line s $"{args ret} = {args' d}"
                    with :? CodegenError as e -> raise_codegen_error' trace e.Data0
                    true
                |> function
                    | true -> print_nullables nulls s x; loop (i+1)
                    | false -> ()
        loop 0
    and binds (nulls : Dictionary<obj,Tag Set>) (defs : CodegenEnv) (s : CodegenEnv) ret (x : TypedBind []) =
        print_nullables nulls s x
        binds_loop nulls defs s ret x
    and term_vars_type_show x = x |> Array.map (function WV(L(_,t)) -> tyv t | WLit x -> prim (lit_to_primitive_type x))
    and tup x =
        match data_term_vars x with
        | [||] -> "pass"
        | [|x|] -> show_w x
        | x -> 
            let args = Array.map show_w x |> String.concat ", " 
            let ty = term_vars_type_show x
            sprintf "Tuple%i(%s)" ((tup' ty).tag) args
    and tup_ty_template = function
        | [||] -> "void"
        | [|x|] -> x
        | x -> $"Tuple{(tup' x).tag}"
    and tup_ty_data_term_vars x = tup_ty_template (data_term_vars x |> term_vars_type_show)
    and tup_ty_tyvs x = tup_ty_template (tyv_type_show x)
    and tup_ty_data_free_vars x = tup_ty_tyvs (data_free_vars x)
    and tup_ty x = tup_ty_data_free_vars (env.ty_to_data x)
    and op nulls defs s (ret : BindsReturn) a =
        let return' x =
            match ret with
            | BindsTailEnd true -> line s x 
            | BindsTailEnd false -> line s (sprintf "return %s" x)
            | BindsLocal [||] -> line s x
            | BindsLocal [|L(i,_)|] -> line s $"v{i} = {x}"
            | BindsLocal ret ->
                let tmp_i = tmp()
                line defs $"cdef {tup_ty_tyvs ret} tmp{tmp_i}"
                line s $"tmp{tmp_i} = {x}"
                let tmp_is = Array.init ret.Length (fun i -> $"tmp{tmp_i}.v{i}") |> String.concat ", "
                line s $"{args ret} = {tmp_is}"
                line s $"del tmp{tmp_i}"
        let jp (a,b) =
            let args = args b
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "Closure%i(%s)" (closure (a,b)).tag args
        let layout_index i x' =
            x' |> Array.map (fun (L(i',_)) -> $"v{i}.v{i'}")
            |> String.concat ", "
            |> fun x -> 
                match ret with
                | BindsTailEnd false -> 
                    let ty = Array.map (fun (L(_,t)) -> tyv t) x'
                    if 1 < ty.Length then line s (sprintf "return Tuple%i(%s)" (tup' ty).tag x)
                    else line s (sprintf "return %s" x)
                | BindsTailEnd true | BindsLocal [||] -> ()
                | BindsLocal ret -> line s $"{args ret} = {x}"
        let length (a,b) =
            match a with
            | YPrim (Int64T | UInt64T) -> return' $"len({tup b})"
            | YPrim a ->
                let l = $"len({tup b})"
                let tmp_i = tmp()
                line defs $"cdef unsigned long long tmp{tmp_i}"
                line s $"tmp{tmp_i} = {l}"
                let a = prim a
                line s $"if <{a}>tmp{tmp_i} != tmp{tmp_i}: raise Exception(\"The conversion to {a} failed.\")"
                return' $"<{a}>tmp{tmp_i}"
            | _ -> raise_codegen_error "Compiler error: Expected a primitive type in length."
        match a with
        | TyMacro a -> 
            a |> List.map (function 
                | CMText x -> x 
                | CMTerm x -> match tup x with "pass" -> raise_codegen_error "Cython codegen error: Void terms are not allowed in macros." | x -> x
                | CMType x -> match tup_ty x with "void" -> raise_codegen_error "Cython codegen error: Void types are not allowed in macros." | x -> x
                ) |> String.concat "" |> return'
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if %s:" (tup cond))
            binds nulls defs (indent s) ret tr
            line s "else:"
            binds nulls defs (indent s) ret fl
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyWhile(a,b) ->
            line s (sprintf "while %s:" (jp a))
            binds nulls defs (indent s) (BindsLocal [||]) b
        | TyIntSwitch(v_i,on_succ,on_fail) ->
            Array.iteri (fun i x ->
                if i = 0 then line s $"if v{v_i} == {i}:"
                else line s $"elif v{v_i} == {i}:"
                binds nulls defs (indent s) ret x
                ) on_succ
            line s "else:"
            binds nulls defs (indent s) ret on_fail
        | TyUnionUnbox(is,x,on_succs,on_fail) ->
            let case_tags = x.Item.tags
            let dot_tag = if x.Item.is_degenerate then "" else ".tag"
            let prefix = 
                match x.Item.layout with
                | UHeap -> sprintf "UH%i" (uheap x).tag
                | UStack -> sprintf "US%i" (ustack x).tag
            let mutable is_first = true
            Map.iter (fun k (a,b) ->
                let union_i = case_tags.[k]
                let branch =
                    let cond = is |> List.map (fun (L(v_i,_)) -> sprintf "v%i%s == %i" v_i dot_tag union_i) |> String.concat " and "
                    if is_first then 
                        line s (sprintf "if %s: # %s" cond k)
                        is_first <- false
                    else line s (sprintf "elif %s: # %s" cond k)
                let s = indent s
                let mutable nvs = Set(nulls.[b])
                let vs = ResizeArray()
                List.iter2 (fun (L(data_i,_)) a ->
                    data_free_vars a |> Array.iteri (fun field_i (L(v_i,t)) ->
                        if Set.contains v_i nvs then
                            nvs <- Set.remove v_i nvs
                        else
                            line defs $"cdef {tyv t} v{v_i}"
                            vs.Add $"v{v_i} = (<{prefix}_{union_i}>v{data_i}).v{field_i}"
                        )
                    ) is a
                if 0 < vs.Count then line s (String.concat "; " vs)
                print_nullables' nvs s
                binds_loop nulls defs s ret b
                ) on_succs
            on_fail |> Option.iter (fun b ->
                line s "else:"
                binds nulls defs (indent s) ret b
                )
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
            Array.iter2 (fun (L(i',_)) b -> line s $"v{i}.v{i'} = {show_w b}") (data_free_vars a) (data_term_vars c)
        | TyArrayLiteral(a,b) ->
            //TODO: Check whether optimizing this actually does anything. It might be the case that Cython already optimizes Numpy array creation.
            //return' <| sprintf "numpy.array([%s],dtype=%s)" (List.map tup b |> String.concat ", ") (numpy_ty a)
            let l = List.length b
            let assign v = List.mapi (fun i x -> $"{v}[{i}] = {tup x}") b |> String.concat "; " |> line s
            match ret with
            | BindsTailEnd false ->
                let tmp_i = tmp()
                line defs $"cdef {tyv (YArray a)} tmp{tmp_i}"
                line s $"tmp{tmp_i} = numpy.empty({l},dtype={numpy_ty a})"
                assign $"tmp{tmp_i}"
                line s $"return tmp{tmp_i}"
            | BindsLocal [|L(i,_)|] -> 
                line s $"v{i} = numpy.empty({l},dtype={numpy_ty a})"
                assign $"v{i}"
            | _ -> raise_codegen_error "Compiler error: Expected a single var or a non-void return in array literal creation."
        | TyArrayCreate(a,b) -> return' $"numpy.empty({tup b},dtype={numpy_ty a})" 
        | TyFailwith _ -> failwith "Taken care in the outer level."
        | TyArrayLength(a,b) -> length (a,b)
        | TyStringLength(a,b) -> length (a,b)
        | TyOp(op,l) ->
            match op, l with
            | Import,[DLit (LitString x)] -> import x; $"pass # import {x}"
            | CImport,[DLit (LitString x)] -> cimport x; $"pass # cimport {x}"
            | ToCythonRecord,[DRecord x] -> Map.foldBack (fun k v l -> $"'{k}': {tup v}" :: l) x [] |> String.concat ", " |> sprintf "{%s}"
            | ToCythonNamedTuple,[n;DRecord x] -> 
                import "collections"
                let field_names = Map.foldBack (fun k v l -> $"'{k}'" :: l) x [] |> String.concat ", "
                let args = Map.foldBack (fun k v l -> tup v :: l) x [] |> String.concat ", "
                $"collections.namedtuple({tup n},[{field_names}])({args})"
            | Apply,[a;b] -> $"{tup a}({args' b})"
            | Dyn,[a] -> tup a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            //| StringU64Length, [a] -> sprintf "len(%s)" (tup a)
            //| ArrayU64Length, [a] -> sprintf "len(%s)" (tup a)
            | StringIndex, [a;b] -> sprintf "%s[%s]" (tup a) (tup b)
            | StringSlice, [a;b;c] -> sprintf "%s[%s:%s]" (tup a) (tup b) (tup c)
            | ArrayIndex, [a;b] -> sprintf "%s[%s]" (tup a) (tup b)
            | ArrayIndexSet, [a;b;c] -> 
                match tup c with
                | "pass" as c -> c
                | c -> sprintf "%s[%s] = %s" (tup a) (tup b) c
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

            | Neg, [x] -> sprintf "-%s" (tup x)
            | Log, [x] -> cimport "libc.math"; sprintf "libc.math.log(%s)" (tup x)
            | Exp, [x] -> cimport "libc.math"; sprintf "libc.math.exp(%s)" (tup x)
            | Tanh, [x] -> cimport "libc.math"; sprintf "libc.math.tanh(%s)" (tup x)
            | Sqrt, [x] -> cimport "libc.math"; sprintf "libc.math.sqrt(%s)" (tup x)
            | NanIs, [x] -> cimport "libc.math"; sprintf "libc.math.isnan(%s)" (tup x)
            | UnionTag, [DUnion(_,l) | DV(L(_,YUnion l)) as x] -> 
                let dot_tag = if l.Item.is_degenerate then "" else ".tag"
                sprintf "%s%s" (tup x) dot_tag
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> return'
    and arg_show i = function "object" -> sprintf "v%i" i | t -> sprintf "%s v%i" t i
    and cdef_show (prefix : string) s i x = line s $"cdef {prefix}{x} v{i}"
    and args_tys x = x |> Array.map (fun (L(i,t)) -> arg_show i (tyv t)) |> String.concat ", "
    and tyv_type_show x = x |> Array.map (fun (L(_,t)) -> tyv t)
    
    // These functions are hacks since cdef classes do not support arrays.
    // https://github.com/cython/cython/issues/4007
    and layout_arrays_to_objects (tys : string []) = tys |> Array.map (fun x -> if x.StartsWith "numpy.ndarray" then "object" else x)
    and layout_arrays_to_objects' (tys : (Tag * string) []) = tys |> Array.map (fun (i,x) -> i, if x.StartsWith "numpy.ndarray" then "object" else x)
    // TODO: Hopefully Cython will get cdef tuples that can hold Python objects. 
    // Until then, they will share functionality with layout types and be heap allocated.
    // https://github.com/cython/cython/issues/3985
    and layout_template name prefix s tag tys = 
        let tys = layout_arrays_to_objects tys
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
        if x.is_degenerate then 
            line s $"ctypedef signed long {prefix}{x.tag}"
        else
            line s $"cdef class {prefix}{x.tag}:"
            line (indent s) $"cdef readonly signed long tag"
            let mutable i = 0
            x.free_vars |> Map.iter (fun k a ->
                line s $"cdef class {prefix}{x.tag}_{i}({prefix}{x.tag}): # {k}"
                let s = indent s
                let tys = tyv_type_show a |> layout_arrays_to_objects
                tys |> Array.iteri (cdef_show "readonly " s)
                let args = tys |> Array.mapi arg_show |> String.concat ", " |> with_self
                let body = $"self.tag = {i}" :: List.init tys.Length (fun i -> $"self.v{i} = v{i}") |> String.concat "; "
                line s $"def __init__({args}): {body}"
                i <- i+1
                )
    and uheap : _ -> UnionRec = union (union_template "UH")
    // TODO: Stack unions will be implemented the same as heap ones for the time being. 
    // I don't have a good way to implement the stack based ones in Cython.
    // https://github.com/cython/cython/issues/3990
    and ustack : _ -> UnionRec = union (union_template "US") 
    and method : _ -> MethodRec =
        jp false (fun ((jp_body,key & (C(args,_))),i) ->
            match (fst env.join_point_method.[jp_body]).[key] with
            | Some a, Some range -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s x ->
            let q = tup_ty x.range
            line s $"cdef {q} method{x.tag}({args_tys x.free_vars}){show_except q}:"
            binds' (indent s) x.body
            )
    and closure : _ -> ClosureRec =
        jp true (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            ) (fun s x ->
            line s (sprintf "cdef class Closure%i():" x.tag)
            let s = indent s
            let free_vars = x.free_vars |> Array.map (fun (L(i,t)) -> i, tyv t)
            free_vars |> layout_arrays_to_objects' |> Array.iter (fun (i,x) -> cdef_show "" s i x)
            let init_args = free_vars |> Array.map (fun (i,t) -> arg_show i t) |> String.concat ", " |> with_self
            let init_body = free_vars |> Array.map (fun (i,_) -> $"self.v{i} = v{i}") |> String.concat "; " |> pass_if_empty
            line s $"def __init__({init_args}): {init_body}"
            match x.domain_args with 
            | [||] -> line s $"def __call__(self):"
            | t -> line s $"def __call__(self, {args_tys t}):"
            let s = indent s
            free_vars |> Array.iter (function i, t -> line s $"cdef {t} v{i} = self.v{i}")
            binds' s x.body
            )

    let main = StringBuilder()
    let s = {text=main; indent=0}
    let q = tup_ty_data_term_vars (binds_last_data x)
    line s $"cpdef {q} main(){show_except q}:"
    binds' (indent s) x

    let program = StringBuilder()
    imports |> Seq.iter (fun x -> program.AppendLine(x) |> ignore)
    types |> Seq.iter (fun x -> program.Append(x) |> ignore)
    functions |> Seq.iter (fun x -> program.Append(x) |> ignore)
    program.Append(main).ToString()
