module Spiral.Codegen.Python

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
    | LitInt32 x -> sprintf "%i" x
    | LitInt64 x -> sprintf "%i" x
    | LitUInt8 x -> sprintf "%i" x
    | LitUInt16 x -> sprintf "%i" x
    | LitUInt32 x -> sprintf "%i" x
    | LitUInt64 x -> sprintf "%i" x
    | LitFloat32 x -> 
        if x = infinityf then "float('inf')"
        elif x = -infinityf then "float('-inf')"
        elif Single.IsNaN x then "float()"
        else x.ToString("R") |> add_dec_point
    | LitFloat64 x ->
        if x = infinity then "float('inf')"
        elif x = -infinity then "float('-inf')"
        elif Double.IsNaN x then "float()"
        else x.ToString("R") |> add_dec_point
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
        | '\\' -> @"\\"
        | x -> string x
        |> sprintf "'%s'"
    | LitBool x -> if x then "True" else "False"

let show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "
let prim x = Infer.show_primt x
let numpy_ty = function
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
        | _ -> "object"
    | _ -> "object"

type UnionRec = {tag : int; free_vars : Map<string, TyV[]>}
type LayoutRec = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<string, TyV[]>}
type MethodRec = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
type ClosureRec = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}

type BindsReturn =
    | BindsTailEnd
    | BindsLocal of TyV []

let line x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore

let codegen (env : PartEvalResult) (x : TypedBind []) =
    let imports = ResizeArray()
    let types = ResizeArray()
    let functions = ResizeArray()

    let numpy_ty x = env.ty_to_data x |> data_free_vars |> numpy_ty
    let rec binds_start (args : TyV []) (s : CodegenEnv) (x : TypedBind []) = binds (Codegen.C.refc_prepass' false (Set args) x).g_decr s BindsTailEnd x
    and binds g_decr (s' : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) = 
        let s = {s' with text = StringBuilder()}
        let tup_destruct (a,b) =
            if 0 < Array.length a then
                let a = args a
                let b = Array.map show_w (data_term_vars b) |> String.concat ", "
                sprintf "%s = %s" a b |> line s
        Array.iter (fun x ->
            let _ =
                let f (g : Dictionary<_,_>) = match g.TryGetValue(x) with true, x -> Seq.toArray x | _ -> [||]
                match args (f g_decr) with "" -> () | x -> sprintf "del %s" x |> line s
            match x with
            | TyLet(d,trace,a) ->
                try op g_decr s (BindsLocal (data_free_vars d)) a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a,_) ->
                try op g_decr s ret a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d,trace) ->
                try match ret with
                    | BindsLocal l -> tup_destruct (l, d) 
                    | BindsTailEnd -> line s $"return {tup_data' d}"
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) stmts
        ignore <| if 0 < s.text.Length then s'.text.Append(s.text) else s'.text.Append("pass")
    and tup_term_vars x =
        match Array.map show_w x with
        | [||] -> ""
        | [|x|] -> x
        | args -> sprintf "(%s)" (String.concat ", " args)
    and tup_data' x = tup_term_vars (data_term_vars x)
    and tup_data x = match tup_data' x with "" -> "None" | x -> x
    and tyv = function
        | YUnion a ->
            match a.Item.layout with
            | UHeap -> sprintf "UH%i" (uheap a).tag
            | UStack -> sprintf "US%i" (ustack a).tag
        | YLayout(a,Heap) -> sprintf "Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i" (mut a).tag
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> "ndarray"
        | YFun(a,b) -> $"Callable[{tyv a}, {tyv b}]"
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and tup_ty x =
        match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
        | [||] -> "None"
        | [|x|] -> x
        | x -> String.concat ", " x |> sprintf "Tuple[%s]"
    and op g_decr s (ret : BindsReturn) a =
        let return' x =
            match ret with
            | BindsTailEnd -> sprintf "return %s" x
            | BindsLocal [||] -> x
            | BindsLocal ret -> sprintf "%s = %s" (args ret) x
            |> line s
        let jp (a,b) =
            let args = args b
            match a with
            | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
            | JPClosure(a,b) -> sprintf "Closure%i(%s)" (closure (a,b)).tag args
        let layout_index i x' =
            x' |> Array.map (fun (L(i',_)) -> $"v{i}.v{i'}")
            |> String.concat ", "
            |> return'
        let length (a,b) = return' $"len({tup_data b})"
        match a with
        | TyMacro a -> a |> List.map (function CMText x -> x | CMTerm x -> tup_data x | CMType x -> tup_ty x) |> String.concat "" |> return'
        | TyIf(cond,tr,fl) ->
            line s (sprintf "if %s:" (tup_data cond))
            binds g_decr (indent s) ret tr
            line s "else:"
            binds g_decr (indent s) ret fl
        | TyJoinPoint(a,args) -> return' (jp (a, args))
        | TyWhile(a,b) ->
            line s (sprintf "while %s:" (jp a))
            binds g_decr (indent s) (BindsLocal [||]) b
        | TyIntSwitch(L(v_i,_),on_succ,on_fail) ->
            Array.iteri (fun i x ->
                if i = 0 then line s $"if v{v_i} == {i}:"
                else line s $"elif v{v_i} == {i}:"
                binds g_decr (indent s) ret x
                ) on_succ
            line s "else:"
            binds g_decr (indent s) ret on_fail
        | TyUnionUnbox(is,x,on_succs,on_fail) ->
            let case_tags = x.Item.tags
            line s (sprintf "match %s:" (is |> List.map (fun (L(i,_)) -> $"v{i}") |> String.concat ", "))
            let s = indent s
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
                        | x -> 
                            let x,g_decr' = Array.mapFold (fun g_decr (L(i,_) as v) -> if Set.contains v g_decr then "_", Set.remove v g_decr else sprintf "v%i" i, g_decr) g_decr.[Array.head b] x
                            g_decr.[Array.head b] <- g_decr'
                            sprintf "(%s)" (String.concat ", " x)
                        |> sprintf "%s_%i%s" prefix i
                        )
                    |> String.concat ", "
                line s (sprintf "| %s: # %s" cases k)
                binds g_decr (indent s) ret b
                ) on_succs
            on_fail |> Option.iter (fun b ->
                line s "case other:"
                binds g_decr (indent s) ret b
                )
        | TyUnionBox(a,b,c') ->
            let c = c'.Item
            let i = c.tags.[a]
            let vars = tup_data' b
            match c.layout with
            | UHeap -> sprintf "UH%i_%i(%s)" (uheap c').tag i vars
            | UStack -> sprintf "US%i_%i(%s)" (ustack c').tag i vars
            |> return'
        | TyLayoutToHeap(a,b) -> sprintf "Heap%i(%s)" (heap b).tag (tup_data' a) |> return'
        | TyLayoutToHeapMutable(a,b) -> sprintf "Mut%i(%s)" (mut b).tag (tup_data' a) |> return'
        | TyLayoutIndexAll(x) -> match x with L(i,YLayout(a,lay)) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i | _ -> failwith "Compiler error: Expected the TyV in layout index to be a layout type."
        | TyLayoutIndexByKey(x,key) -> match x with L(i,YLayout(a,lay)) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i | _ -> failwith "Compiler error: Expected the TyV in layout index by key to be a layout type."
        | TyLayoutHeapMutableSet(L(i,t),b,c) ->
            let a = List.fold (fun s k -> match s with DRecord l -> l.[k] | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
            Array.iter2 (fun (L(i',_)) b -> line s $"v{i}.v{i'} = {show_w b}") (data_free_vars a) (data_term_vars c)
        | TyArrayLiteral(a,b) -> return' <| sprintf "numpy.array([%s],dtype=%s)" (List.map tup_data' b |> String.concat ", ") (numpy_ty a)
        | TyArrayCreate(a,b) -> return' $"numpy.empty({tup_data b},dtype={numpy_ty a})" 
        | TyFailwith _ -> failwith "Taken care in the outer level."
        | TyConv(a,b) -> return' $"{tyv a}({tup_data b})"
        | TyArrayLength(a,b) | TyStringLength(a,b) -> length (a,b)
        | TyOp(op,l) ->
            let tup = tup_data
            match op, l with
            | Import,[DLit (LitString x)] -> import x; ""
            | ToCythonRecord,[DRecord x] -> Map.foldBack (fun k v l -> $"'{k}': {tup v}" :: l) x [] |> String.concat ", " |> sprintf "{%s}"
            | ToCythonNamedTuple,[n;DRecord x] -> 
                import "collections"
                let field_names = Map.foldBack (fun k v l -> $"'{k}'" :: l) x [] |> String.concat ", "
                let args = Map.foldBack (fun k v l -> tup v :: l) x [] |> String.concat ", "
                $"collections.namedtuple({tup n},[{field_names}])({args})"
            | Apply,[a;b] -> $"{tup a}({tup_data' b})"
            | Dyn,[a] -> tup a
            | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
            | StringIndex, [a;b] -> sprintf "%s[%s]" (tup a) (tup b)
            | StringSlice, [a;b;c] -> sprintf "%s[%s:%s]" (tup a) (tup b) (tup c)
            | ArrayIndex, [a;b] -> sprintf "%s[%s]" (tup a) (tup b)
            | ArrayIndexSet, [a;b;c] -> 
                match tup_data' c with
                | "" -> "pass"
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
            | Log, [x] -> import "math"; sprintf "math.log(%s)" (tup x)
            | Exp, [x] -> import "math"; sprintf "math.exp(%s)" (tup x)
            | Tanh, [x] -> import "math"; sprintf "math.tanh(%s)" (tup x)
            | Sqrt, [x] -> import "math"; sprintf "math.sqrt(%s)" (tup x)
            | NanIs, [x] -> import "math"; sprintf "math.isnan(%s)" (tup x)
            | UnionTag, [DUnion(_,l) | DV(L(_,YUnion l)) as x] -> sprintf "%s.tag" (tup x) 
            | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
            |> return'


    "Hello."
