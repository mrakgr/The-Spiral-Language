module Spiral.PartEval

open Spiral.Tokenize
open Spiral.Parsing
open Spiral.Prepass
open Spiral.Utils
open System.Collections.Generic
open System

type Env<'a,'b> = {type' : StackSize * 'a []; value : StackSize * 'b []}

type LayoutType =
    | LayoutStack
    | LayoutHeap
    | LayoutHeapMutable

type Tag = int
type [<CustomComparison;CustomEquality>] T<'a,'b when 'a: equality and 'a: comparison> = 
    | T of 'a * 'b

    override a.Equals(b) =
        match b with
        | :? T<'a,'b> as b -> match a,b with T(a,_), T(b,_) -> a = b
        | _ -> false
    override a.GetHashCode() = match a with T(a,_) -> hash a
    interface IComparable with
        member a.CompareTo(b) = 
            match b with
            | :? T<'a,'b> as b -> match a,b with T(a,_), T(b,_) -> compare a b
            | _ -> raise <| ArgumentException "Invalid comparison for T."

type Ty =
    | BT
    | PairT of Ty * Ty
    | KeywordT of KeywordTag * Ty []
    | FunctionT of Expr * StackSize * Ty [] * StackSize * Ty [] * is_forall : bool
    | TypeFunctionT of Ty * StackSize * Ty []
    | RecordT of Map<KeywordTag, Ty>
    | PrimT of PrimitiveType
    
    | LayoutT of LayoutType * RData
    | ArrayT of Ty
    | RuntimeFunctionT of Ty * Ty
    | MacroT of RData

and Data =
    | TyB
    | TyPair of Data * Data
    | TyKeyword of KeywordTag * Data []
    | TyFunction of Expr * StackSize * Ty [] * StackSize * Data [] * is_forall : bool
    | TyRecord of Map<KeywordTag, Data>
    | TyValue of Value

    | TyV of TyV
    | TyR of int // For use in join points, layout types and macros
and TyV = T<Tag,Ty>

and RData = R of Data // has TyRef // TODO: Hash cons this.

type Trace = ParserCombinators.PosKey list
type JoinPointKey = Expr * Ty []
type JoinPointType =
    | JoinPointClosure
    | JoinPointMethod
type JoinPoint = JoinPointKey * JoinPointType * TyV []

type TypedBind =
    | TyLet of Data * Trace * TypedOp
    | TyLocalReturnOp of Trace * TypedOp
    | TyLocalReturnData of Data * Trace

and TypedOp = 
    | TyOp of Op * Data []
    | TyIf of cond: Data * tr: TypedBind [] * fl: TypedBind []
    | TyWhile of cond: JoinPoint * TypedBind []
    | TyCase of Data * (Data * TypedBind []) []
    | TyLayoutToNone of Data
    | TyJoinPoint of JoinPoint
    | TySetMutableRecord of Data * (Tag * Ty) [] * TyV []

/// Unlike v0.1 and previously, the functions can now have cycles so that needs to be taken care of during memoization.
let data_to_rdata' call_data =
    let m = Dictionary(HashIdentity.Reference)
    let call_args = ResizeArray()
    let rec f x =
        match m.TryGetValue x with
        | true, v -> v
        | _ ->
            let memo r = m.Add(x,TyR m.Count); r
            match x with
            | TyPair(a,b) -> memo <| TyPair(f a, f b)
            | TyKeyword(a,b) -> memo <| TyKeyword(a, Array.map f b)
            | TyFunction(a,b,c,d,e,z) -> m.Add(x,TyR m.Count); TyFunction(a,b,c,d,Array.map f e,z)
            | TyRecord l -> memo <| TyRecord(Map.map (fun _ -> f) l)
            | TyV(T(_,ty) as t) -> memo (call_args.Add t; TyV(T(call_args.Count-1, ty)))
            | TyValue _ | TyB -> x
            | TyR _ -> failwith "Compiler error"
    let x = f call_data
    call_args.ToArray(),R x

let data_to_rdata call_data = data_to_rdata' call_data |> snd // TODO: Specialize this.

let rdata_to_data' i (R call_data) =
    let m = Dictionary(HashIdentity.Structural)
    let r_args = ResizeArray()
    let rec f x =
        let memo r = m.Add(m.Count,r); r
        match x with
        | TyPair(a,b) -> memo <| TyPair(f a, f b)
        | TyKeyword(a,b) -> memo <| TyKeyword(a, Array.map f b)
        | TyFunction(a,b,c,d,e,z) -> 
            let e' = Array.zeroCreate<_> e.Length
            let r = TyFunction(a,b,c,d,e',z)
            m.Add(m.Count,r)
            Array.iteri (fun i x -> e'.[i] <- f x) e
            r
        | TyRecord l -> memo <| TyRecord(Map.map (fun _ -> f) l)
        | TyV(T(_,ty) as t) -> memo (r_args.Add t; let r = TyV(T(!i, ty)) in i := !i+1; r)
        | TyValue _ | TyB -> x
        | TyR x -> m.[x]
    let x = f call_data
    r_args.ToArray(),x

let rdata_to_data i x = rdata_to_data' i x |> snd // TODO: Specialize this.

let data_free_vars call_data =
    let m = HashSet(HashIdentity.Reference)
    let free_vars = ResizeArray()
    let rec f x =
        if m.Add x then
            match x with
            | TyPair(a,b) -> f a; f b
            | TyKeyword(a,b) -> Array.iter f b
            | TyFunction(a,b,c,d,e,z) -> Array.iter f e
            | TyRecord l -> Map.iter (fun _ -> f) l
            | TyV(T(_,ty) as t) -> free_vars.Add t
            | TyValue _ | TyB | TyR _ -> ()
    f call_data
    free_vars.ToArray()

let rdata_free_vars (R x) = data_free_vars x

let ty_to_data i x =
    let m = Dictionary(HashIdentity.Reference)
    let rec f x = 
        match x with
        | BT -> TyB
        | PairT(a,b) -> TyPair(f a, f b) 
        | KeywordT(a,b) -> TyKeyword(a,Array.map f b)
        | FunctionT(a,b,c,d,e,z) -> 
            match m.TryGetValue x with
            | true, v -> v
            | _ ->
                let e' = Array.zeroCreate e.Length
                let r = TyFunction(a,b,c,d,e',z)
                m.Add(x,r)
                Array.iteri (fun i x -> e'.[i] <- f x) e
                m.Remove(x) |> ignore // Non-nested mapping should not share vars
                r
        | RecordT l -> TyRecord(Map.map (fun k -> f) l)
        | PrimT _ | LayoutT _ | ArrayT _ | RuntimeFunctionT _ | MacroT _ -> let r = TyV(T(!i,x)) in i := !i+1; r
        | TypeFunctionT _ -> failwith "Compiler error: Cannot turn a type function to a runtime variable."
    f x

let value_to_ty = function
    | LitUInt8 _ -> PrimT UInt8T
    | LitUInt16 _ -> PrimT UInt16T
    | LitUInt32 _ -> PrimT UInt32T
    | LitUInt64 _ -> PrimT UInt64T
    | LitInt8 _ -> PrimT Int8T
    | LitInt16 _ -> PrimT Int16T
    | LitInt32 _ -> PrimT Int32T
    | LitInt64 _ -> PrimT Int64T
    | LitFloat32 _ -> PrimT Float32T
    | LitFloat64 _ -> PrimT Float64T   
    | LitBool _ -> PrimT BoolT
    | LitString _ -> PrimT StringT
    | LitChar _ -> PrimT CharT

let rdata_to_ty (R call_data) = // TODO: When R is hash-consed, do global memoization for this as a compile time optimization.
    let m = Dictionary(HashIdentity.Structural)
    let rec f x =
        let memo r = m.Add(m.Count,r); r
        match x with
        | TyPair(a,b) -> memo <| PairT(f a, f b)
        | TyKeyword(a,b) -> memo <| KeywordT(a, Array.map f b)
        | TyFunction(a,b,c,d,e,z) ->
            let e' = Array.zeroCreate<_> e.Length
            let r = FunctionT(a,b,c,d,e',z)
            m.Add(m.Count,r)
            Array.iteri (fun i x -> e'.[i] <- f x) e
            r
        | TyRecord l -> memo <| RecordT(Map.map (fun _ -> f) l)
        | TyV(T(_,ty) as t) -> memo ty
        | TyValue x -> value_to_ty x
        | TyB -> BT
        | TyR x -> m.[x]
    f call_data

let data_to_ty x =
    let m = Dictionary(HashIdentity.Reference)
    let rec f x =
        let memoize f = memoize m f x
        let memoize_rec e ret f = memoize_rec m e ret f x
        match x with
        | TyPair(a,b) -> memoize (fun _ -> PairT(f a, f b))
        | TyKeyword(a,b) -> memoize (fun _ -> KeywordT(a, Array.map f b))
        | TyFunction(a,b,c,d,e,z) -> memoize_rec e (fun e' -> FunctionT(a,b,c,d,e',z)) f
        | TyRecord l -> memoize (fun _ -> RecordT(Map.map (fun _ -> f) l))
        | TyV(T(_,ty) as t) -> ty
        | TyValue x -> value_to_ty x
        | TyB -> BT
        | TyR _ -> failwith "Compiler error"
    f x

type LangEnv = {
    trace : Trace
    seq : ResizeArray<TypedBind>
    cse : Dictionary<Op * Data [], Data> list
    i : VarTag ref
    env_global_type : Ty []
    env_global_value : Data []
    env_stack_type : Ty []
    env_stack_type_ptr : int
    env_stack_value : Data []
    env_stack_value_ptr : int 
    }

let push_value_var x (d: LangEnv) =
    d.env_stack_value.[d.env_stack_value_ptr] <- x
    {d with env_stack_value_ptr=d.env_stack_value_ptr+1}

let push_type_var x (d: LangEnv) =
    d.env_stack_type.[d.env_stack_type_ptr] <- x
    {d with env_stack_type_ptr=d.env_stack_type_ptr+1}

let seq_apply (d: LangEnv) end_dat =
    let inline end_ () = d.seq.Add(TyLocalReturnData(end_dat,d.trace))
    if d.seq.Count > 0 then
        match d.seq.[d.seq.Count-1] with
        | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b)
        | _ -> end_()
    else end_()
    d.seq.ToArray()

let cse_tryfind (d: LangEnv) key =
    d.cse |> List.tryPick (fun x ->
        match x.TryGetValue key with
        | true, v -> Some v
        | _ -> None
        )

let cse_add (d: LangEnv) k v = (List.head d.cse).Add(k,v)

let layout_to_none (d: LangEnv) = function
    | TyV(T(_,LayoutT(t,l))) as v ->
        let x = rdata_to_data d.i l 
        d.seq.Add(TyLet(x,d.trace,TyLayoutToNone(v)))
        x
    | a -> a

let layout_to_some layout (d: LangEnv) = function
    | TyV(T(_,LayoutT(t,l))) as x when t = layout -> x
    | x ->
        let x = layout_to_none d x
        let consed_data = data_to_rdata x
        let ret_ty = LayoutT(layout,consed_data)
        let ret = ty_to_data d.i ret_ty
        let layout =
            match layout with
            | LayoutStack -> LayoutToStack
            | LayoutHeap -> LayoutToHeap
            | LayoutHeapMutable -> LayoutToHeapMutable
        d.seq.Add(TyLet(ret,d.trace,TyOp(layout,[|x|])))
        ret

let push_typedop d op ret_ty =
    let ret = ty_to_data d.i ret_ty
    d.seq.Add(TyLet(ret,d.trace,op))
    ret

let push_op_no_rewrite (d: LangEnv) op l ret_ty = push_typedop d (TyOp(op,l)) ret_ty

let push_op (d: LangEnv) op l ret_ty =
    let key = op,l
    match cse_tryfind d key with
    | Some x -> x
    | None ->
        let ret = ty_to_data d.i ret_ty
        d.seq.Add(TyLet(ret,d.trace,TyOp(op,l)))
        cse_add d key ret
        ret

exception TypeError of Trace * string
let raise_type_error (d: LangEnv) x = raise (TypeError(d.trace,x))

let show_primt = function
    | UInt8T -> "uint8"
    | UInt16T -> "uint16"
    | UInt32T -> "uint32"
    | UInt64T -> "uint64"
    | Int8T -> "int8"
    | Int16T -> "int16"
    | Int32T -> "int32"
    | Int64T -> "int64"
    | Float32T -> "float32"
    | Float64T -> "float64"
    | BoolT -> "bool"
    | StringT -> "string"
    | CharT -> "char"

let show_value = function
    | LitUInt8 x -> sprintf "%iu8" x
    | LitUInt16 x -> sprintf "%iu16" x
    | LitUInt32 x -> sprintf "%iu32" x
    | LitUInt64 x -> sprintf "%iu64" x
    | LitInt8 x -> sprintf "%ii8" x
    | LitInt16 x -> sprintf "%ii16" x
    | LitInt32 x -> sprintf "%ii32" x
    | LitInt64 x -> sprintf "%ii64" x
    | LitFloat32 x -> sprintf "%ff32" x
    | LitFloat64 x -> sprintf "%ff64" x
    | LitBool x -> sprintf "%b" x
    | LitString x -> sprintf "%s" x
    | LitChar x -> sprintf "%c" x

let show_layout_type = function
    | LayoutStack -> "layout_stack"
    | LayoutHeap -> "layout_heap"
    | LayoutHeapMutable -> "layout_heap_mutable"

let rec partial_eval (keywords: KeywordEnv) (d: LangEnv) x = 
    let inline show_keyword show (keyword,l: _[]) =
        if l.Length > 0 then
            let a = (keywords.From keyword).Split([|':'|], StringSplitOptions.RemoveEmptyEntries)
            Array.map2 (fun a l -> String.concat "" [|a;":(";show l;")"|]) a l
            |> String.concat " "
        else
            keywords.From keyword

    let inline show_map show v = 
        let body = 
            Map.toArray v
            |> Array.map (fun (k,v) -> sprintf "%s=%s" (keywords.From k) (show v))
            |> String.concat "; "

        sprintf "{%s}" body

    let rec show_ty = function
        | BT -> "()"
        | PrimT x -> show_primt x
        | KeywordT(keyword,l) -> show_keyword show_ty (keyword,l)
        | PairT(a, b) -> sprintf "(%s * %s)" (show_ty a) (show_ty b)
        | RecordT v -> show_map show_ty v
        | FunctionT(_,_,_,_,_,false) -> "<function>"
        | FunctionT(_,_,_,_,_,true) -> "<forall>"
        | TypeFunctionT(_,_,_) -> "<type function>" // TODO: Do proper printing for this case.
        | LayoutT (layout_type,R body) -> sprintf "%s (%s)" (show_layout_type layout_type) (show_typed_data body)
        | RuntimeFunctionT (a,b) -> sprintf "(%s -> %s)" (show_ty a) (show_ty b)
        | ArrayT x -> sprintf "array %s" (show_ty x)
        | MacroT (R x) -> show_typed_data x |> sprintf "macro (%s)"

    and show_typed_data = function
        | TyB -> "()"
        | TyV(T(_,t)) -> sprintf "var (%s)" (show_ty t)
        | TyKeyword(keyword,l) -> show_keyword show_typed_data (keyword,l)
        | TyPair(a,b) -> sprintf "(%s, %s)" (show_typed_data a) (show_typed_data b)
        | TyRecord a -> show_map show_typed_data a
        | TyFunction(_,_,_,_,_,false) -> "<function>"
        | TyFunction(_,_,_,_,_,true) -> "<forall>"
        | TyValue v -> sprintf "lit %s" (show_value v)
        | TyR i -> sprintf "<%i>" i

    let inline ev d x = partial_eval keywords d x
    let inline ev2 d a b = ev d a, ev d b
    let inline ev3 d a b c = ev d a, ev d b, ev d c
    let inline ev_seq d x =
        let d = {d with seq=ResizeArray(); i=ref !d.i}
        let x = ev d x
        let x_ty = data_to_ty x
        seq_apply d x, x_ty
    let inline ev_annot d x = ev_seq {d with cse=Dictionary(HashIdentity.Structural) :: d.cse} x |> snd
    
    let inline push_var_ptrt ptr x = d.env_stack_type.[ptr] <- x; ptr+1
    let inline push_var_ptr ptr x = d.env_stack_value.[ptr] <- x; ptr+1
    let inline vt x = if x < 0 then d.env_global_type.[-x-1] else d.env_stack_type.[x]
    let inline v x = if x < 0 then d.env_global_value.[-x-1] else d.env_stack_value.[x]

    let inline nan_guardf32 x = if Single.IsNaN x then raise_type_error d "A 32-bit floating point operation resulting in a nan detected at compile time. Spiral cannot propagate nan literal without diverging." else x
    let inline nan_guardf64 x = if Double.IsNaN x then raise_type_error d "A 64-bit floating point operation resulting in a nan detected at compile time. Spiral cannot propagate nan literal without diverging." else x

    let func_env d (t_sz,t_env,v_sz,v_env) =
        {d with 
            env_global_type=t_env
            env_global_value=v_env
            env_stack_type=Array.zeroCreate t_sz
            env_stack_type_ptr=0
            env_stack_value=Array.zeroCreate v_sz
            env_stack_value_ptr=0
            }

    let apply d a b = 
        match a with
        | Module l -> failwith ""
        | _ ->
            match ev d a with
            | TyFunction(body,t_sz,t_env,v_sz,v_env,true) ->
                match b with
                | Type b -> 
                    let d = func_env d (t_sz,t_env,v_sz,v_env)
                    ev (push_type_var (partial_eval_type keywords d b) d) body
                | _ -> raise_type_error d <| sprintf "Expected a type as the second argument in the type application."
            | a ->
                match a, ev d b with
                | TyFunction(body,t_sz,t_env,v_sz,v_env,false), b ->
                    let d = func_env d (t_sz,t_env,v_sz,v_env)
                    ev (push_value_var b d) body
                | TyRecord l, TyKeyword(keyword,_) ->
                    match Map.tryFind keyword l with
                    | Some a -> a
                    | None -> raise_type_error d <| sprintf "The record does not have the field %s." (keywords.From keyword)
                | TyRecord _, b -> raise_type_error d <| sprintf "The second argument in a record application is not a keyword.\nGot: %s" (show_typed_data b)
                | TyV(T(_,LayoutT(layout_type,R (TyRecord l) & r))) & a, TyKeyword(keyword,_) & b ->
                    match rdata_to_ty r with
                    | RecordT l ->
                        match Map.tryFind keyword l with
                        | Some x -> 
                            match layout_type with
                            | LayoutHeapMutable -> push_op_no_rewrite d LayoutRecordGet [|a; b|] x
                            | LayoutStack | LayoutHeap -> push_op d LayoutRecordGet [|a; b|] x
                        | None -> raise_type_error d <| sprintf "The (layouted) record does not have the field %s." (keywords.From keyword)
                    | _ -> failwith "impossible"
                | TyV(T(_,LayoutT(_,R (TyRecord l)))), b -> raise_type_error d <| sprintf "The second argument in a (layouted) record application is not a keyword.\nGot: %s" (show_typed_data b)
                | TyV(T(_,RuntimeFunctionT(clo_arg_ty,clo_ret_ty))) & a, b -> 
                    let b_ty = data_to_ty b
                    if clo_arg_ty <> b_ty then raise_type_error d <| sprintf "Cannot apply an argument of type %s to a function of type: %s -> %s" (show_ty b_ty) (show_ty clo_arg_ty) (show_ty clo_ret_ty)
                    else push_op_no_rewrite d Apply [|a; b|] clo_ret_ty
                | a, _ -> raise_type_error d <| sprintf "The first argument provided cannot be applied.\nGot: %s" (show_typed_data a)

    let function' is_forall on_succ (data : ExprData) = 
        TyFunction(on_succ,
            data.type'.stack_size,Array.zeroCreate<_> data.type'.free_vars.Length,
            data.value.stack_size,Array.map v data.value.free_vars,
            is_forall)

    match x with
    | V x -> v x
    | Value x -> TyValue x
    | Inline(on_succ,data) ->
        let d = 
            {d with 
                env_global_type=Array.map vt data.type'.free_vars
                env_global_value=Array.map v data.value.free_vars
                env_stack_type=Array.zeroCreate data.type'.stack_size
                env_stack_type_ptr=0
                env_stack_value=Array.zeroCreate data.value.stack_size
                env_stack_value_ptr=0
                }
        ev d on_succ
    | Inl(on_succ,data) -> function' false on_succ data
    | Forall(on_succ,data) -> function' true on_succ data
    | Glob(e) -> ev d !e
    | Let(bind,on_succ) -> ev (push_value_var (ev d bind) d) on_succ
    | RecBlock(l,on_succ) ->
        let l,d =
            let function' is_forall on_succ (data : ExprData) = 
                TyFunction(on_succ,
                    data.type'.stack_size,Array.zeroCreate<_> data.type'.free_vars.Length,
                    data.value.stack_size,Array.zeroCreate<_> data.value.free_vars.Length,
                    is_forall)
            Array.mapFold (fun d x -> 
                let data,x = 
                    match x with
                    | Inl(on_succ,data) -> data,function' false on_succ data
                    | Forall(on_succ,data) -> data,function' true on_succ data
                    | _ -> raise_type_error d "Compiler error: Expected a inl or a forall in the recursive block."
                (data,x), push_value_var x d
                ) d l
        l |> Array.iter (function 
            | data,TyFunction(_,_,c,_,e,_) ->
                data.type'.free_vars |> Array.iteri (fun i x -> c.[i] <- vt x) // Don't mind the lack of d being passed to vt and v.
                data.value.free_vars |> Array.iteri (fun i x -> e.[i] <- v x)
            | _ -> failwith "impossible"
            )
        ev d on_succ
    | PairTest(x,on_succ,on_fail) ->
        match v x with
        | TyPair(a,b) -> ev (push_value_var a d |> push_value_var b) on_succ
        | _ -> ev d on_fail
    | KeywordTest(keyword, bind, on_succ, on_fail) ->
        match v bind with
        | TyKeyword(keyword', l) when keyword = keyword' -> ev {d with env_stack_value_ptr=Array.fold push_var_ptr d.env_stack_value_ptr l} on_succ
        | _ -> ev d on_fail
    | RecordTest(pats, bind, on_succ, on_fail) ->
        let inline on_fail () = ev d on_fail
        match v bind with
        | TyRecord l -> 
            let rec loop d i =
                let inline case keyword =
                    match l.TryFind keyword with
                    | Some x -> loop (push_value_var x d) (i+1)
                    | None -> on_fail()
                if i < pats.Length then
                    match pats.[i] with
                    | RecordTestKeyword keyword -> case keyword
                    | RecordTestInjectVar var ->
                        match ev d var with
                        | TyKeyword(keyword,_) -> case keyword
                        | _ -> raise_type_error d "The injected variable needs to an unary keyword."
                else ev d on_succ
            loop d 0
        | _ -> on_fail()
    | RecordWith(vars, withs) ->
        let withs l =
            let push_keyword keyword =
                match Map.tryFind keyword l with
                | Some this -> push_value_var this d
                | None -> push_value_var TyB d
            let var_to_keyword var_string var = 
                match ev d var with
                | TyKeyword(keyword,_) -> keyword
                | _ -> raise_type_error d <| sprintf "The injected variable %s in RecordWith is not a keyword." var_string
            Array.fold (fun l -> function
                | RecordWithKeyword(keyword,expr) -> Map.add keyword (ev (push_keyword keyword) expr) l
                | RecordWithInjectVar(var_string,var,expr) -> let keyword = var_to_keyword var_string var in Map.add keyword (ev (push_keyword keyword) expr) l
                | RecordWithoutKeyword keyword -> Map.remove keyword l
                | RecordWithoutInjectVar(var_string,var) -> Map.remove (var_to_keyword var_string var) l
                ) l withs
            |> TyRecord
        match vars with
        | [||] -> withs Map.empty
        | _ -> 
            match ev d vars.[0] with
            | TyRecord l -> 
                let rec loop l i =
                    if i < vars.Length then
                        let th = function 1 -> "st" | 2 -> "nd" | 3 -> "rd" | _ -> "th"
                        match ev d vars.[i] with
                        | TyKeyword(keyword,_) ->
                            match Map.tryFind keyword l with
                            | Some(TyRecord l') -> Map.add keyword (loop l' (i+1)) l |> TyRecord
                            | Some _ -> raise_type_error d <| sprintf "The %i%s variable application in RecordWith does not result in a record." i (th i)
                            | None -> raise_type_error d <| sprintf "The keyword %s cannot be found in the %i%s sub-record." (keywords.From keyword) i (th i)
                        | _ -> let i = i+1 in raise_type_error d <| sprintf "The %i%s variable in RecordWith is not a keyword." i (th i)
                    else withs l
                loop l 1
            | _ -> raise_type_error d "The first variable must be a record."
    | Module l -> raise_type_error d "Modules should only appear as the first argument in an application."
    | Type _ -> raise_type_error d "Types should only appear as a part of the application to foralls."
    | UnitTest(a,on_succ,on_fail)-> 
        match v a with
        | TyB -> ev d on_succ
        | _ -> ev d on_fail
    | Typecase(a,l) ->
        let f x = partial_eval_type keywords d x
        let a = f a
        match Array.tryPick (fun (b,body) -> if a = f b then Some (ev d body) else None) l with
        | Some x -> x
        | None -> raise_type_error d <| sprintf "Typecase miss for %s" (show_ty a)
    | Pos(pos) -> ev {d with trace=pos.Pos :: d.trace} pos.Expression

and partial_eval_type keywords d x = failwith "TODO"