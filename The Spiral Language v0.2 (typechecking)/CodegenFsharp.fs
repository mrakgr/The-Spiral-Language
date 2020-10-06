module Spiral.Codegen.Fsharp
open Spiral
open Spiral.Config
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval
open System
open System.Text
open System.Collections.Generic

type G<'a when 'a: equality>(x : 'a) = 
    let h = hash x

    member _.Item = x
    override a.Equals(b) =
        match b with
        | :? H<'a> as b -> h = hash b && x = b.Item
        | _ -> false
    override a.GetHashCode() = h

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

let codegen (env : PartEvalResult) (x : TypedBind []) =
    let enqueue (queue : _ Queue) x = queue.Enqueue(x); x
    let layout () =
        let queue = Queue()
        let dict' = Dictionary(HashIdentity.Structural)
        let dict = Dictionary(HashIdentity.Reference)
        let f (x : _ G) = 
            let x = env.ty_to_data x.Item
            let a, b =
                match x with
                | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                | _ -> data_free_vars x, Map.empty
            enqueue queue {|free_vars=a; free_vars_by_key=b; tag=dict'.Count|}
        queue, Utils.memoize dict (G >> Utils.memoize dict' f)
    let queue_heap, heap = layout()
    let queue_mut, mut = layout()

    let queue_union_stack, queue_union_heap, union =
        let stack = Queue()
        let heap = Queue()
        let dict = Dictionary(HashIdentity.Structural)
        let f (a : Union) = 
            let d = fst a.Item |> Map.map (fun _ -> env.ty_to_data >> data_free_vars)
            match snd a.Item with
            | UStack -> enqueue stack {|free_vars=d; tag=dict.Count|}
            | UHeap -> enqueue heap {|free_vars=d; tag=dict.Count|}
        stack, heap, Utils.memoize dict f

    let jp f =
        let queue = Queue()
        let dict = Dictionary(HashIdentity.Structural)
        let f x = enqueue queue (f (x, dict.Count))
        queue, Utils.memoize dict f
    let queue_method, method = 
        jp (fun ((jp_body,key & (C(args,_))),i) ->
            match (fst env.join_point_method.[jp_body]).[key] with
            | Some a, Some range -> {|tag=i; free_vars=rdata_free_vars args; range=range; body=a|}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            )
    let queue_closure, closure = 
        jp (fun ((jp_body,key & (C(args,_,domain,range))),i) ->
            match (fst env.join_point_closure.[jp_body]).[key] with
            | Some a -> {|tag=i; free_vars=rdata_free_vars args; domain=env.ty_to_data domain |> data_free_vars; range=range; body=a|}
            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
            )

    let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "

    let show_w = function WV i -> sprintf "v%i" i | WLit a -> lit a
    let rec binds (s : CodegenEnv) (x : TypedBind []) =
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
        match x with
        | YUnion a -> sprintf "Union%i" (union a).tag
        | YLayout(a,Heap) -> sprintf "Heap%i" (heap a).tag
        | YLayout(a,HeapMutable) -> sprintf "Mut%i" (mut a).tag
        | YMacro a -> a |> List.map (function Text a -> a | Type a -> ty a) |> String.concat ""
        | YPrim a -> prim a
        | YArray a -> sprintf "(%s [])" (ty a)
        | YFun(a,b) -> sprintf "(%s -> %s)" (ty a) (ty b)
        | a -> failwithf "Type not supported in the codegen.\nGot: %A" a
    and jp (a, b) =
        let args = args b
        match a with
        | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
        | JPClosure(a,b) -> sprintf "closure%i(%s)" (closure (a,b)).tag args
    and op s d a =
        let free_vars do_annot x =
            let f (L(i,t)) = if do_annot then sprintf "v%i : %s" i (ty t) else sprintf "v%i" i
            match data_free_vars x with
            | [||] -> "()"
            | x -> Array.map f x |> String.concat ", " |> sprintf "(%s)"
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
            line s "else"
            binds (indent s) fl
        | TyJoinPoint(a,args) -> simple (jp (a, args))
        | TyWhile(a,b) ->
            complex <| fun s ->
            line s (sprintf "while %s do" (jp a))
            binds (indent s) b
        | TyUnionUnbox(i,x,l) ->
            complex <| fun s ->
            line s (sprintf "match v%i with" i)
            let u = union x
            let prefix = 
                match snd x.Item with
                | UHeap -> sprintf "UH%i" u.tag
                | UStack -> sprintf "US%i" u.tag
            Map.fold (fun i k (a,b) ->
                let vars = 
                    match data_free_vars a with
                    | [||] -> ""
                    | x -> sprintf "(%s)" (args x)
                line s (sprintf "| %s_%i%s -> (* %s *)" prefix i k vars)
                binds (indent s) b
                i + 1
                ) 0 l
            |> ignore
        | TyUnionBox(a,b,c) ->
            let u = union c
            let l,lay = c.Item
            let mutable i = -1
            if Map.exists (fun k _ -> i <- i+1; k = a) l = false then raise_codegen_error "Compiler error: Union key not found."
            let vars =
                match data_term_vars b with
                | [||] -> ""
                | x -> Array.map show_w x |> String.concat ", " |> sprintf "(%s)"
            match lay with
            | UHeap -> sprintf "UH%i_%i%s" u.tag i vars
            | UStack -> sprintf "US%i_%i%s" u.tag i vars
            |> simple
        | TyLayoutToHeap(a,b) -> sprintf "{%s} : Heap%i" (layout_vars a) (heap b).tag |> simple
        | TyLayoutToHeapMutable(a,b) -> sprintf "{%s} : Mut%i" (layout_vars a) (heap b).tag |> simple
        | TyLayoutIndexAll(L(i,(a,lay))) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars |> layout_index i
        | TyLayoutIndexByKey(L(i,(a,lay)),key) -> (match lay with Heap -> heap a | HeapMutable -> mut a).free_vars_by_key.[key] |> layout_index i
        //| TyOp(op,l) ->
        //    match op,l with
        //    | LayoutToHeap,[a] -> 
        //        let d = data_to_ty
        //    |> simple

    binds {text=StringBuilder(); indent=0} x