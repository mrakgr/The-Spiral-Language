module Spiral.Main

// Global open
open System
open System.Collections.Generic
open HashConsing
open Types
open DotNetInterop

// Parser open
open FParsec

// Codegen open
open System.Text

// #Main
let spiral_peval (Module(N(module_name,_,_,_)) as module_main) = 
    let join_point_dict_method = d0()
    let join_point_dict_closure = d0()
    let join_point_dict_type = d0()
    let join_point_dict_cuda = d0()

    // #Smart constructors
    let trace (d: LangEnv) = d.trace

    let ty_join_point key jp_type args ret_type = TyJoinPoint(key,jp_type,args,ret_type)

    let nodify_expr (dict: Dictionary<_,_>) x =
        match dict.TryGetValue x with
        | true, id -> Node(x,id)
        | false, _ ->
            let id = dict.Count
            let x' = Node(x,id)
            dict.[x] <- id
            x'
   
    // nodify_expr variants.
    let nodify_v = nodify_expr <| d0()
    let nodify_lit = nodify_expr <| d0()
    let nodify_pattern = nodify_expr <| d0()
    let nodify_func = nodify_expr <| d0()
    let nodify_func_filt = nodify_expr <| d0()
    let nodify_vv = nodify_expr <| d0()
    let nodify_op = nodify_expr <| d0()

    let v x = nodify_v x |> V
    let lit x = nodify_lit x |> Lit
    let op x = nodify_op x |> Op
    let pattern x = nodify_pattern x |> Pattern
    let func x = nodify_func x |> Function
    let func_filt x = nodify_func_filt x |> FunctionFilt
    let vv x = nodify_vv x |> VV

    // nodify_ty variants
    let boxed_type_dict = d0()
    let rec boxed_type_open = function // Will diverge on degenerate cases.
        | RecT x -> boxed_type_dict.[x] |> boxed_type_open
        | x -> x
        
    let nodify_memo_key = nodify <| d0()
    let consify_env_term = (hashcons_add <| hashcons_create 0) >> EnvConsed

    let tyv x = TyV x
    let tyvv x = TyList x
    let tymap (a,t) = (a,t) |> TyMap
    let tybox x = TyBox x

    let lit_int i = LitInt64 i |> lit
    let lit_string x = LitString x |> lit

    let fix name x =
        match name with
        | "" -> x
        | _ -> (Fix,[lit_string name; x]) |> op
    let inl x y = (x,y) |> func
    let inl_pat x y = (PatClauses([x,y])) |> pattern
    let ap x y = (Apply,[x;y]) |> op
    let lp v b e = ap (inl_pat v e) b
    let inmp v' b e = ap (ap (v ">>=") b) (inl_pat v' e)
    let usep v' b e = ap (ap (v "use") b) (inl_pat v' e)
    let inbp v' b e = ap b (inl_pat v' e)
    let l v b e = ap (inl v e) b
    let l_rec v b e = ap (inl v e) (fix v b)

    let inl' args body = List.foldBack inl args body

    let B = vv []
    let TyB = tyvv []
    
    let join_point_entry_method y = (JoinPointEntryMethod,[y]) |> op
    let join_point_entry_type y = (JoinPointEntryType,[y]) |> op

    let module_open a b = (ModuleOpen,[a;b]) |> op

    let rec ap' f l = List.fold ap f l

    let tuple_index' v i = (ListIndex,[v; i]) |> op
    let tuple_index v i = tuple_index' v (lit_int i)
    let tuple_length v = (ListLength,[v]) |> op
    let tuple_slice_from v i = (ListSliceFrom,[v; lit_int i]) |> op
    let tuple_is v = (ListIs,[v]) |> op

    let print_env x = (PrintEnv,[x]) |> op
    let print_expr x = (PrintExpr,[x]) |> op

    let module_is x = op (ModuleIs,[x])
    let module_has_member a b = op (ModuleHasMember,[a;b])

    let if_static cond tr fl = (IfStatic,[cond;tr;fl]) |> op
    let case arg case = (Case,[arg;case]) |> op
    let binop op' a b = (op',[a;b]) |> op
    let eq_type a b = binop EqType a b
    let eq a b = binop EQ a b
    let lt a b = binop LT a b
    let gte a b = binop GTE a b

    let closure_is x = op(ClosureIs,[x])
    let closure_dom x = op(ClosureDomain,[x])
    let closure_range x = op(ClosureRange,[x])

    let error_non_unit x = (ErrorNonUnit, [x]) |> op
    let type_lit_lift' x = (TypeLitCreate,[x]) |> op
    let type_lit_lift x = type_lit_lift' (lit x)
    let type_lit_cast x = (TypeLitCast,[x]) |> op
    let type_lit_is x = (TypeLitIs,[x]) |> op
    let expr_pos pos x = ExprPos(Pos(pos,x))
    let pat_pos pos x = PatPos(Pos(pos,x))

    let type_get a = op(TypeGet,[a])
    let type_union a b = op(TypeUnion,[a;b])
    let type_box a b = op(TypeBox,[a;b])

    // Aux outer functions
    let flip f a b = f b a

    let get_type_of_value = function
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

    let rec env_to_ty env = Map.map (fun _ -> get_type) env
    and get_type = function
        | TyLit x -> get_type_of_value x
        | TyList l -> List.map get_type l |> listt
        | TyMap(C l, t) -> funt (env_to_ty l, t)

        | TyT t | TyV(_,t) | TyBox(_,t)
        | TyLet(_,_,_,t,_) | TyJoinPoint(_,_,_,t)
        | TyState(_,_,t,_) | TyOp(_,_,t) -> t

    let rec typed_expr_env_free_var_exists x = Map.exists (fun k v -> typed_expr_free_var_exists v) x
    and typed_expr_free_var_exists e =
        let inline f x = typed_expr_free_var_exists x
        match e with
        | TyBox (n,t) -> f n
        | TyList l -> List.exists f l
        | TyMap(C l,t) -> typed_expr_env_free_var_exists l
        | TyV (n,t as k) -> true
        | TyT _ | TyLit _ -> false
        | TyJoinPoint _ | TyOp _ | TyState _ | TyLet _ -> failwithf "Only data structures in the TypedExpr can be tested for free variable existence. Got: %A" e

    // #Unit type tests
    let rec is_unit_tuple t = List.forall is_unit t
    and is_unit_env x = Map.forall (fun _ -> is_unit) x
    and is_unit = function
        | LitT _ -> true
        | UnionT _ | RecT _ | DotNetTypeT _ | TermFunctionT _ | PrimT _ -> false
        | ArrayT (_,t) -> is_unit t
        | MapT (env,_) -> is_unit_env env
        | LayoutT (_, C x, _) -> typed_expr_env_free_var_exists x = false
        | ListT t -> is_unit_tuple t

    /// Wraps the argument in a list if not a tuple.
    let tuple_field = function 
        | TyList args -> args
        | x -> [x]

    let (|TyTuple|) x = tuple_field x

    /// Wraps the argument in a set if not a UnionT.
    let set_field = function
        | UnionT t -> t
        | t -> Set.singleton t

    let (|TySet|) x = set_field x

    let (|TyType|) x = get_type x
    let (|TypeLit|_|) = function
        | TyType (LitT x) -> Some x
        | _ -> None
    let (|TypeString|_|) = function
        | TypeLit (LitString x) -> Some x
        | _ -> None

    let is_numeric' = function
        | PrimT (UInt8T | UInt16T | UInt32T | UInt64T 
            | Int8T | Int16T | Int32T | Int64T 
            | Float32T | Float64T) -> true
        | _ -> false
    let inline is_numeric a = is_numeric' (get_type a)

    let is_string' = function
        | PrimT StringT -> true
        | _ -> false
    let inline is_string a = is_string' (get_type a)

    let is_char' = function
        | PrimT CharT -> true
        | _ -> false
    let inline is_char a = is_char' (get_type a)

    let is_primt' = function
        | PrimT x -> true
        | _ -> false
    let inline is_primt a = is_primt' (get_type a)

    let is_float' = function
        | PrimT (Float32T | Float64T) -> true
        | _ -> false
    let inline is_float a = is_float' (get_type a)

    let rec is_bool' = function
        | PrimT BoolT -> true
        | _ -> false
    let inline is_bool a = is_bool' (get_type a)

    let rec is_int' = function
        | PrimT (UInt32T | UInt64T | Int32T | Int64T) -> true
        | _ -> false
    let inline is_int a = is_int' (get_type a)

    let rec is_any_int' = function
        | PrimT (UInt8T | UInt16T | UInt32T | UInt64T 
            | Int8T | Int16T | Int32T | Int64T) -> true
        | _ -> false
    let inline is_any_int x = is_any_int' (get_type x)

    let rec is_int64' = function
        | PrimT Int64T -> true
        | _ -> false
    let inline is_int64 a = is_int64' (get_type a)

    // #Prepass
    
    let new_pat_var =
        let mutable i = 0
        let get_pattern_tag () = i <- i+1; i
        fun () -> sprintf " pat_var_%i" (get_pattern_tag())

    let rec pattern_compile arg pat =
        let rec pattern_compile arg pat on_succ on_fail =
            let inline cp arg pat on_succ on_fail = pattern_compile arg pat on_succ on_fail

            let inline pat_foldbacki f s l =
                let mutable len = 0L
                let rec loop i l =
                    match l with
                    | x :: xs -> f (x,i) (loop (i+1L) xs)
                    | [] -> len <- i; s
                loop 0L l, len
            
            let pat_tuple l' =
                pat_foldbacki
                    (fun (pat,i) on_succ ->
                        let arg = tuple_index arg i
                        cp arg pat on_succ on_fail)
                    on_succ
                    l'
                |> fun (on_succ,len) -> 
                    if_static (eq (tuple_length arg) (lit_int len)) on_succ on_fail
                    |> fun on_succ -> if_static (tuple_is arg) on_succ on_fail
                    |> case arg

            let pat_cons l = 
                pat_foldbacki
                    (fun (pat,i) (on_succ, tuple_index') ->
                        let arg = tuple_index' arg i
                        cp arg pat on_succ on_fail, tuple_index)
                    (on_succ, tuple_slice_from)
                    l
                |> fun ((on_succ,_),len) -> 
                    if_static (gte (tuple_length arg) (lit_int (len-1L))) on_succ on_fail
                    |> fun on_succ -> if_static (tuple_is arg) on_succ on_fail
                    |> case arg

            let pat_part_active a pat on_fail arg =
                let pat_var = new_pat_var()
                let on_succ = inl pat_var (cp (v pat_var) pat on_succ on_fail)
                let on_fail = inl "" on_fail
                ap' (v a) [arg; on_fail; on_succ]

            
            let pat_module_is_module on_succ = if_static (module_is arg) on_succ on_fail

            let inline pat_or cp arg l on_succ on_fail = List.foldBack (fun pat on_fail -> cp arg pat on_succ on_fail) l on_fail
            let inline pat_and cp arg l on_succ on_fail = List.foldBack (fun pat on_succ -> cp arg pat on_succ on_fail) l on_succ

            let rec pattern_module_compile arg pat on_succ on_fail =
                let inline pat_bind name f =
                    let memb = type_lit_lift (LitString name)
                    let on_succ = f memb
                    if_static (module_has_member arg memb) on_succ on_fail

                match pat with
                | PatMName name ->
                    pat_bind name <| fun memb -> l name (ap arg memb) on_succ
                | PatMRebind(name,pat) ->
                    let pat_var = new_pat_var()
                    pat_bind name <| fun memb -> l pat_var (ap arg memb) (cp (v pat_var) pat on_succ on_fail)
                | PatMPattern pat -> cp arg pat on_succ on_fail
                | PatMAnd l -> pat_and pattern_module_compile arg l on_succ on_fail
                | PatMOr l -> pat_or pattern_module_compile arg l on_succ on_fail
                | PatMXor l ->
                    let state_var = new_pat_var()
                    let state_var' = v state_var
                    let bool x = lit <| LitBool x
                    let rec just_one = function
                        | x :: xs -> 
                            let xs = just_one xs
                            inl state_var (pattern_module_compile arg x (if_static state_var' on_fail (ap xs (bool true))) (ap xs state_var'))
                        | [] -> inl state_var on_succ
                    ap (just_one l) (bool false)
                | PatMNot x -> pattern_module_compile arg x on_fail on_succ
                | PatMInnerModule(name,pat) ->
                    let pat_var = new_pat_var()
                    let pat_var' = v pat_var
                    let memb = type_lit_lift (LitString name)
                
                    pattern_module_compile pat_var' pat on_succ on_fail
                    |> l name pat_var'
                    |> l pat_var (ap arg memb)
                    |> fun on_succ -> if_static (module_has_member arg memb) on_succ on_fail
                    |> pat_module_is_module

            match pat with
            | E -> on_succ
            | PatVar x -> l x arg on_succ
            | PatTypeEq (exp,typ) ->
                let on_succ = cp arg exp on_succ on_fail
                if_static (eq_type arg typ) on_succ on_fail
                |> case arg
            | PatTuple l -> pat_tuple l
            | PatCons l -> pat_cons l
            | PatActive (a,b) ->
                let pat_var = new_pat_var()
                l pat_var (ap (v a) arg) (cp (v pat_var) b on_succ on_fail)
            | PatPartActive (a,pat) -> pat_part_active a pat on_fail arg
            | PatExtActive (a,pat) ->
                let rec f pat' on_fail = function
                    | PatAnd _ as pat -> op(ErrorType,[lit_string "And patterns are not allowed in extension patterns."]) |> pat_part_active a (pat' pat) on_fail
                    | PatOr l -> List.foldBack (fun pat on_fail -> f pat' on_fail pat) l on_fail
                    | PatCons l -> vv [type_lit_lift (LitString "cons"); vv [l.Length-1 |> int64 |> LitInt64 |> lit; arg]] |> pat_part_active a (pat' <| PatTuple l) on_fail
                    | PatTuple l as pat -> vv [type_lit_lift (LitString "tup"); vv [l.Length |> int64 |> LitInt64 |> lit; arg]] |> pat_part_active a (pat' pat) on_fail
                    | PatTypeEq (a,typ) -> f (fun a -> PatTypeEq(a,typ) |> pat') on_fail a
                    | PatWhen (pat, e) -> f (fun pat -> PatWhen(pat,e) |> pat') on_fail pat
                    | PatClauses _ -> failwith "Clauses should not appear inside other clauses."
                    | pat -> vv [type_lit_lift (LitString "var"); arg] |> pat_part_active a (pat' pat) on_fail
                f id on_fail pat
            | PatOr l -> pat_or cp arg l on_succ on_fail
            | PatAnd l -> pat_and cp arg l on_succ on_fail
            | PatClauses l -> List.foldBack (fun (pat, exp) on_fail -> cp arg pat (expr_prepass exp |> snd) on_fail) l on_fail
            | PatTypeLit x -> 
                if_static (eq_type arg (type_lit_lift x)) on_succ on_fail 
                |> case arg
            | PatTypeLitBind x -> 
                if_static (type_lit_is arg) (l x (type_lit_cast arg) on_succ) on_fail 
                |> case arg
            | PatLit x -> 
                let x = lit x
                let on_succ = if_static (eq arg x) on_succ on_fail
                if_static (eq_type arg x) on_succ on_fail |> case arg
            | PatWhen (p, e) -> cp arg p (if_static e on_succ on_fail) on_fail
            | PatModule(name,pat) ->
                let pat_var = new_pat_var()
                let pat_var' = v pat_var
                pattern_module_compile pat_var' pat on_succ on_fail
                |> fun x -> 
                    match name with
                    | Some name -> l name pat_var' x
                    | None -> x
                |> l pat_var arg
                |> pat_module_is_module
            | PatPos p -> expr_pos p.Pos (cp arg p.Expression on_succ on_fail)
            | PatTypeClosure(a,b) ->
                let range = cp (closure_range arg) b on_succ on_fail
                let closure = cp (closure_dom arg) a range on_fail
                if_static (closure_is arg) closure on_fail
                    
        let pattern_compile_def_on_succ = op(ErrorPatClause,[])
        let pattern_compile_def_on_fail = op(ErrorPatMiss,[arg])
        pattern_compile arg pat pattern_compile_def_on_succ pattern_compile_def_on_fail

    and pattern_compile_single pat =
        let main_arg = new_pat_var()
        inl main_arg (pattern_compile (v main_arg) pat) |> expr_prepass

    and expr_prepass e =
        let inline f e = expr_prepass e
        match e with
        | V (N n) -> Set.singleton n, e
        | Op(N(op',l)) ->
            let l,l' = List.map f l |> List.unzip
            Set.unionMany l, op(op',l')
        | VV (N l) -> 
            let l,l' = List.map f l |> List.unzip
            Set.unionMany l, vv l'
        | FunctionFilt(N (vars,N(name,body))) ->
            Set.remove name vars, e
        | Function(N(name,body)) ->
            let vars,body = f body
            Set.remove name vars, func_filt(vars,nodify_func(name,body))
        | Lit _ -> Set.empty, e
        | Pattern (N pat) -> pattern_compile_single pat
        | ExprPos p -> 
            let vars, body = f p.Expression
            vars, expr_pos p.Pos body

    // #Renaming
    let inline renamables0() = {memo=Dictionary(HashIdentity.Reference); renamer=d0(); ref_call_args=ref []; ref_method_pars=ref []} : EnvRenamer
    let rec renamer_apply_env' (r: EnvRenamer) (C x) = Map.map (fun k -> renamer_apply_typedexpr' r) x
    and renamer_apply_typedexpr' ({memo=memo; renamer=renamer; ref_call_args=call_args; ref_method_pars=method_pars} as r) e =
        let inline f e = renamer_apply_typedexpr' r e
        let inline rename (n,t as k) =
            match renamer.TryGetValue n with
            | true, v -> v,t
            | false, _ ->
                let n' = renamer.Count
                renamer.Add(n,n')
                call_args := k :: !call_args 
                let k' = n', t
                method_pars := k' :: !method_pars
                k'

        match memo.TryGetValue e with
        | true, e -> e
        | false, _ ->
            match e with
            | TyT _ -> e
            | TyBox (n,t) -> tybox(f n,t)
            | TyList l -> tyvv(List.map f l)
            | TyMap(l,t) -> tymap(renamer_apply_env' r l |> consify_env_term, t)
            | TyV (n,t as k) ->
                let n', _ as k' = rename k
                if n' = n then e else tyv k'
            | TyLit _ -> e
            | TyJoinPoint _ | TyOp _ | TyState _ | TyLet _ -> failwithf "Only data structures in the env can be renamed. Got: %A" e
            |> fun x -> memo.[e] <- x; x

    let inline renamer_apply_template f x =
        let {ref_call_args=call_args; ref_method_pars=method_pars;renamer=renamer} as r = renamables0()
        let x = f r x
        {call_args= !call_args; method_pars= !method_pars; renamer'=renamer}, x

    let inline renamer_apply_env_template f x = renamer_apply_template (fun r -> renamer_apply_env' r >> f) x
    let inline renamer_apply_env x = renamer_apply_env_template Env x
    let inline renamer_apply_envc x = renamer_apply_env_template consify_env_term x
    let inline renamer_apply_typedexpr e = renamer_apply_template renamer_apply_typedexpr' e

    let on_type_er trace message = TypeError(trace,message) |> raise
    let print_method tag = sprintf "method_%i" tag

    let layout_to_op = function
        | LayoutStack -> LayoutToStack
        | LayoutPackedStack -> LayoutToPackedStack
        | LayoutHeap -> LayoutToHeap
        | LayoutHeapMutable -> LayoutToHeapMutable

    let layout_from_op = function
        | LayoutToStack -> LayoutStack
        | LayoutToPackedStack -> LayoutPackedStack
        | LayoutToHeap -> LayoutHeap
        | LayoutToHeapMutable -> LayoutHeapMutable
        | _ -> failwith "Not a layout op."

    // #Type directed partial evaluation
    let rec expr_peval (d: LangEnv) (expr: Expr) =
        let inline tev d expr = expr_peval d expr
        let inline apply_seq d x = !d.seq x
        let inline tev_seq d expr = let d = {d with seq=ref id; cse_env=ref !d.cse_env} in tev d expr |> apply_seq d
        let inline tev_assume cse_env d expr = let d = {d with seq=ref id; cse_env=ref cse_env} in tev d expr |> apply_seq d
        let inline tev_method d expr = let d = {d with seq=ref id; cse_env=ref Map.empty} in tev d expr |> apply_seq d
        let inline tev_rec d expr = let d = {d with seq=ref id; cse_env=ref Map.empty; rbeh=AnnotationReturn} in tev d expr |> apply_seq d

        let inline tev2 d a b = tev d a, tev d b
        let inline tev3 d a b c = tev d a, tev d b, tev d c
        let inline tev4 d a b c d' = tev d a, tev d b, tev d c, tev d d'

        let inline inner_compile x = expr_prepass x |> snd |> tev d

        let inline v_find env x on_fail = 
            let run env = 
                match Map.tryFind x env with
                | Some v -> v
                | None -> on_fail()
            match env with
            | Env env -> run env
            | EnvConsed env -> run env.node
            | EnvUnfiltered (env, used_vars) -> if used_vars.Contains x then run env else on_fail()

        let get_tag d = 
            let t = !d.ltag
            d.ltag := t + 1
            t

        let make_tyv_ty d ty = get_tag d, ty

        let inline tyt x = TyT x
        let make_up_vars_for_ty d ty = 
            if is_unit ty then tyt ty
            else TyV <| make_tyv_ty d ty

        let inline make_tyv_and_push_typed_expr_template even_if_unit d ty_exp =
            let ty = get_type ty_exp
            if is_unit ty then
                if even_if_unit then 
                    let seq = !d.seq
                    let trace = (trace d)
                    d.seq := fun rest -> TyState(ty_exp,rest,get_type rest,trace) |> seq
                tyt ty
            else
                let v = make_tyv_ty d ty
                let seq = !d.seq
                let trace = (trace d)
                d.seq := fun rest -> TyLet(v,ty_exp,rest,get_type rest,trace) |> seq
                tyv v
            
        let make_tyv_and_push_typed_expr_even_if_unit d ty_exp = make_tyv_and_push_typed_expr_template true d ty_exp
        let make_tyv_and_push_typed_expr d ty_exp = make_tyv_and_push_typed_expr_template false d ty_exp

        let cse_add' d r x = let e = !d.cse_env in if r <> x then Map.add r x e else e
        let cse_add d r x = d.cse_env := cse_add' d r x

        // for a shallow version, take a look at `alternative_destructure_v6e.fsx`.
        // The deep version can also be straightforwardly derived from a template of this using the Y combinator.
        let rec destructure d r = 
            let inline destructure r = destructure d r

            let inline chase_cse on_succ on_fail r = 
                match Map.tryFind r !d.cse_env with
                | Some x -> on_succ x
                | None -> on_fail r
            let inline chase_recurse r = chase_cse destructure id r

            let inline destructure_cse r = 
                chase_cse 
                    chase_recurse
                    (fun r ->
                        let x = make_tyv_and_push_typed_expr d r
                        cse_add d r x
                        x)
                    r

            let index_tuple_args r tuple_types = 
                let unpack (s,i as state) typ = 
                    if is_unit typ then tyt typ :: s, i
                    else (destructure <| TyOp(ListIndex,[r;TyLit <| LitInt64 (int64 i)],typ)) :: s, i + 1
                List.fold unpack ([],0) tuple_types
                |> fst |> List.rev

            let env_unseal r x =
                let unseal (m,i as state) (k: string) typ = 
                    if is_unit typ then Map.add k (tyt typ) m, i
                    else
                        let r = TyOp(MapGetField,[r; tyv(i,typ)], typ) |> destructure 
                        Map.add k r m, i + 1
                Map.fold unseal (Map.empty,0) x |> fst

            let inline destructure_var r map_vvt map_funt =
                match get_type r with
                | ListT tuple_types -> tyvv(map_vvt tuple_types)
                | MapT (env,t) -> tymap(map_funt env, t)
                | _ -> chase_recurse r
            
            match r with
            | TyMap _ | TyList _ | TyLit _ -> r
            | TyBox _ -> chase_recurse r
            | TyT _ -> destructure_var r (List.map (tyt >> destructure)) (Map.map (fun _ -> (tyt >> destructure)) >> Env)
            | TyV _ -> destructure_var r (index_tuple_args r) (env_unseal r >> Env)
            | TyOp _ -> destructure_cse r
            | TyJoinPoint _ | TyLet _ | TyState _ -> failwithf "This should never appear in destructure. It should go directly into d.seq. Got: %A" r

        let if_body d cond tr fl =
            let b x = cse_add' d cond (TyLit <| LitBool x)
            let tr = 
                match cond with
                | TyOp(EQ,[b & TyLit _; a & TyV _],_) | TyOp(EQ,[a & TyV _; b & TyLit _],_) -> tev_assume (cse_add' d a b) d tr
                | _ -> tev_assume (b true) d tr
            let fl = tev_assume (b false) d fl
            let type_tr, type_fl = get_type tr, get_type fl
            if type_tr = type_fl then
                match tr, fl with
                | TyLit (LitBool true), TyLit (LitBool false) -> cond
                | _ when tr = fl -> tr
                | _ ->
                    match cond with
                    | TyLit(LitBool true) -> tr
                    | TyLit(LitBool false) -> fl
                    | _ -> TyOp(If,[cond;tr;fl],type_tr) |> make_tyv_and_push_typed_expr_even_if_unit d
            else on_type_er (trace d) <| sprintf "Types in branches of If do not match.\nGot: %A and %A" type_tr type_fl

        let if_cond d tr fl cond =
            if is_bool cond = false then on_type_er (trace d) <| sprintf "Expected a bool in conditional.\nGot: %A" (get_type cond)
            else if_body d cond tr fl

        let if_static d cond tr fl =
            match tev d cond with
            | TyLit (LitBool cond) -> 
                let branch = if cond then tr else fl
                tev d branch
            | cond -> if_cond d tr fl cond

        let if_ d cond tr fl = tev d cond |> if_cond d tr fl

        let rec layout_boxed_unseal d recf x =
            let inline f x = layout_boxed_unseal d recf x
            match x with
            | TyV _ as v -> TyOp(MapGetField,[recf;v],get_type v) |> destructure d
            | TyList l -> tyvv (List.map f l)
            | TyBox(a,b) -> tybox (f a, b)
            | TyMap(env, b) -> tymap (layout_env_term_unseal d recf env, b)
            | x -> x
               
        and layout_env_term_unseal d recf (C env) = Map.map (fun _ -> layout_boxed_unseal d recf) env |> Env

        let layout_to_none' d = function
            | TyMap _ as a -> a
            | TyType(LayoutT(_,env,t)) as a -> tymap(layout_env_term_unseal d a env,t)
            | x -> on_type_er (trace d) <| sprintf "Cannot turn the argument into a non-layout type. Got: %A" x
        let layout_to_none d a = layout_to_none' d (tev d a)

        let rec layoutify layout d = function
            | TyMap(env,t) as a ->
                let {renamer'=r}, env' = renamer_apply_envc env 
                if r.Count = 0 then LayoutT(layout,env',t) |> tyt
                else TyOp(layout_to_op layout,[a],LayoutT(layout,env',t)) |> destructure d
            | TyType(LayoutT(layout',_,_)) as a ->
                if layout <> layout' then layout_to_none' d a |> layoutify layout d else a
            | x -> on_type_er (trace d) <| sprintf "Cannot turn the argument into a layout type. Got: %A" x

        let layout_to layout d a = layoutify layout d (tev d a)

        let join_point_method d expr = 
            let {call_args=call_arguments; method_pars=method_parameters; renamer'=renamer}, renamed_env = renamer_apply_env d.env
            let length=renamer.Count
            let join_point_key = nodify_memo_key (expr, renamed_env) 
            
            let ret_ty = 
                let d = {d with env=renamed_env; ltag=ref length}
                let join_point_dict = join_point_dict_method
                match join_point_dict.TryGetValue join_point_key with
                | false, _ ->
                    join_point_dict.[join_point_key] <- JoinPointInEvaluation ()
                    let typed_expr = tev_method d expr
                    join_point_dict.[join_point_key] <- JoinPointDone (method_parameters, typed_expr)
                    typed_expr
                | true, JoinPointInEvaluation _ -> 
                    tev_rec d expr
                | true, JoinPointDone (used_vars, typed_expr) -> 
                    typed_expr
                |> get_type

            ty_join_point join_point_key JoinPointMethod call_arguments ret_ty 
            |> make_tyv_and_push_typed_expr_even_if_unit d

        let join_point_closure arg d expr = 
            let {call_args=call_arguments; method_pars=method_parameters; renamer'=renamer}, renamed_env = renamer_apply_env d.env
            let length=renamer.Count
            let join_point_key = nodify_memo_key (expr, renamed_env) 
            
            let {call_args=imaginary_arguments},_ = renamer_apply_typedexpr arg
            let method_imaginary_parameters = List.map (fun (k,t) -> renamer.[k],t) imaginary_arguments
            let arg_ty = get_type arg

            let ret_ty = 
                let d = {d with env=renamed_env; ltag=ref length}
                let join_point_dict = join_point_dict_closure
                match join_point_dict.TryGetValue join_point_key with
                | false, _ ->
                    join_point_dict.[join_point_key] <- JoinPointInEvaluation ()
                    let typed_expr = tev_method d expr
                    let captured_method_parameters =
                        let method_imaginary_parameters = HashSet(method_imaginary_parameters)
                        List.filter (method_imaginary_parameters.Contains >> not) method_parameters
                    join_point_dict.[join_point_key] <- JoinPointDone (captured_method_parameters,method_imaginary_parameters,typed_expr)
                    typed_expr
                | true, JoinPointInEvaluation _ -> 
                    tev_rec d expr
                | true, JoinPointDone (_, _, typed_expr) -> 
                    typed_expr
                |> get_type

            let captured_arguments =
                let imaginary_arguments = HashSet(imaginary_arguments)
                List.filter (imaginary_arguments.Contains >> not) call_arguments

            ty_join_point join_point_key JoinPointClosure captured_arguments (term_functiont arg_ty ret_ty)
            |> make_tyv_and_push_typed_expr_even_if_unit d

        let rec is_cuda_type = function
            | LitT _ -> true
            | PrimT t ->
                match t with
                | StringT _ -> false
                | _ -> true
            | ListT l -> false
            | MapT (l,_) -> Map.forall (fun _ -> is_cuda_type) l
            | LayoutT (LayoutPackedStack, l, _) -> 
                let {call_args=args},_ = renamer_apply_env l
                List.forall (fun (_,t) -> is_cuda_type t) args
            | ArrayT ((ArtCudaGlobal _ | ArtCudaShared | ArtCudaLocal),t) -> is_cuda_type t
            | UnionT _ | LayoutT _ | ArrayT _ | DotNetTypeT _ | TermFunctionT _ | RecT _ -> false

        let join_point_cuda d expr = 
            let {call_args=call_arguments; method_pars=method_parameters; renamer'=renamer}, renamed_env = renamer_apply_env d.env
            match List.filter (snd >> is_cuda_type >> not) call_arguments with
            | [] -> ()
            | l -> on_type_er (trace d) <| sprintf "At the Cuda join point the following arguments have disallowed types: %A" l

            let length=renamer.Count
            let join_point_key = nodify_memo_key (expr, renamed_env) 

            let ret_ty = 
                let d = {d with env=renamed_env; ltag=ref length}
                let join_point_dict = join_point_dict_cuda
                match join_point_dict.TryGetValue join_point_key with
                | false, _ ->
                    join_point_dict.[join_point_key] <- JoinPointInEvaluation ()
                    let typed_expr = tev_method d expr
                    join_point_dict.[join_point_key] <- JoinPointDone (method_parameters, typed_expr)
                    typed_expr
                | true, JoinPointInEvaluation () -> 
                    tev_rec d expr
                | true, JoinPointDone (used_vars, typed_expr) -> 
                    typed_expr
                |> get_type

            if is_unit ret_ty = false then on_type_er d.trace "The return type of Cuda join point must be unit."

            // This line is so the method actually gets printed during codegen.
            ty_join_point join_point_key JoinPointCuda call_arguments ret_ty 
            |> make_tyv_and_push_typed_expr_even_if_unit d |> ignore

            let method_name = print_method join_point_key.Symbol |> LitString |> TyLit
            let args = Seq.toList call_arguments |> List.map tyv |> tyvv
            tyvv [method_name; args]

        let join_point_type d expr = 
            let env = Map.map (fun _ -> get_type >> tyt) (c d.env) |> Env
            let join_point_key = nodify_memo_key (expr, env) 

            let ret_ty = 
                let d = {d with env=env; ltag=ref 0}
                let join_point_dict = join_point_dict_type
                match join_point_dict.TryGetValue join_point_key with
                | false, _ ->
                    let is_rec = ref false
                    join_point_dict.[join_point_key] <- JoinPointInEvaluation is_rec
                    let ty = tev_method d expr |> get_type
                    let packed_ty = if !is_rec then RecT join_point_key else ty 
                    join_point_dict.[join_point_key] <- JoinPointDone (ty, packed_ty)
                    packed_ty
                | true, JoinPointInEvaluation is_rec -> 
                    is_rec := true
                    RecT join_point_key
                | true, JoinPointDone (ty, packed_ty) -> packed_ty

            tyt ret_ty

        let rec rect_unbox' d = function
            | RecT key -> rect_unbox d key
            | x -> x

        and rect_unbox d key = 
            match join_point_dict_type.[key] with
            | JoinPointInEvaluation _ -> on_type_er (trace d) "Types that are being constructed cannot be used for boxing otherwise the compiler would diverge."
            | JoinPointDone (ty, packed_ty) -> ty
            |> rect_unbox' d

        let type_get d a = tev_seq d a |> get_type |> TyT
        let rec case_type d args_ty =
            let union_case = function
                | UnionT l -> Set.toList l
                | _ -> [args_ty]
            match args_ty with
            | RecT key -> union_case (rect_unbox d key)
            | x -> union_case x

        let type_split d x =
            tev d x |> get_type |> case_type d
            |> List.map tyt
            |> tyvv

        let inline closure_f on_fail on_succ d x =
            match tev d x with
            | TyType(TermFunctionT (a,b)) -> on_succ (a,b)
            | x -> on_fail x

        let closure_is d x =
            let on_x x _ = LitBool x |> TyLit
            closure_f (on_x false) (on_x true) d x

        let inline closure_dr is_domain d x =
            let on_fail x = on_type_er (trace d) <| sprintf "Expected a closure (or its type).\nGot: %A" x
            let on_succ (dom,range) = if is_domain then tyt dom else tyt range
            closure_f on_fail on_succ d x

        let closure_type_create d a b =
            let a = tev_seq d a
            let b = tev_seq d b
            term_functiont (get_type a) (get_type b) |> tyt

        let case_ d v case =
            let inline assume d v x branch = tev_assume (cse_add' d v x) d branch
            match tev d v with
            | a & TyBox(b,_) -> tev {d with cse_env = ref (cse_add' d a b)} case
            | TyType(t & (UnionT _ | RecT _)) as v ->
                let rec map_cases l =
                    match l with
                    | x :: xs -> (x, assume d v x case) :: map_cases xs
                    | _ -> []
                            
                match map_cases (case_type d t |> List.map (make_up_vars_for_ty d)) with
                | (_, TyType p) :: _ as cases -> 
                    if List.forall (fun (_, TyType x) -> x = p) cases then 
                        TyOp(Case,v :: List.collect (fun (a,b) -> [a;b]) cases, p) 
                        |> make_tyv_and_push_typed_expr_even_if_unit d
                    else 
                        let l = List.map (snd >> get_type) cases
                        on_type_er (trace d) <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\n%A" l
                | _ -> failwith "There should always be at least one clause here."
            | _ -> tev d case
           
        let type_union d a b =
            let a, b = tev2 d a b
            let f x = set_field (get_type x)
            f a + f b |> uniont |> tyt

        let inline wrap_exception d f =
            try f()
            with 
            | :? TypeError as e -> reraise()
            | e -> on_type_er (trace d) (".NET exception:\n"+e.Message)

        let assembly_compile d =
            memoize ss_cache_assembly <| fun (x: Reflection.Assembly) ->
                let rec to_typedexpr = function
                    | LoadMap map -> tymap(Map.map (fun _ -> to_typedexpr) map |> consify_env_term, MapTypeModule) |> layoutify LayoutStack d
                    | LoadType typ -> match ss_type_definition typ with SSTyType x -> tyt x | x -> dotnet_typet x |> tyt

                x.GetTypes()
                |> Array.fold (fun map (typ: Type) ->
                    if typ.IsPublic then
                        let namesp = typ.FullName.Split '.'
                        let typ = typ
                        let rec loop i map =
                            if i < namesp.Length then
                                let name = namesp.[i]
                                match map with
                                | LoadMap map ->
                                    let env =
                                        match Map.tryFind name map with
                                        | Some(LoadMap _ & env) -> env
                                        | None -> LoadMap Map.empty
                                        | _ -> failwith "impossible"
                                    LoadMap (Map.add name (loop (i+1) env) map)
                                | _ -> failwith "impossible"
                            else
                                LoadType typ
                        loop 0 map
                    else
                        map
                        ) (LoadMap Map.empty)
                |> to_typedexpr

        let dotnet_assembly_load is_load_file d x =
            match tev d x with
            | TypeString x ->
                wrap_exception d <| fun _ ->
                    if is_load_file then System.Reflection.Assembly.LoadFile(x) else System.Reflection.Assembly.Load(x)
                    |> assembly_compile d
            | _ -> on_type_er (trace d) "Expected a type level string."

        let (|TyLitIndex|_|) = function
            | TyLit (LitInt32 i) -> Some i
            | TyLit (LitInt64 i) -> Some (int i)
            | TyLit (LitUInt32 i) -> Some (int i)
            | TyLit (LitUInt64 i) -> Some (int i)
            | _ -> None

        let string_length d a = 
            match tev d a with
            | TyLit (LitString str) -> TyLit (LitInt64 (int64 str.Length))
            | TyType(PrimT StringT) & str -> TyOp(StringLength,[str],PrimT Int64T)
            | _ -> on_type_er (trace d) "Expected a string."

        let (|M|_|) = function
            | TyMap(env,t) -> Some (None,env,t)
            | TyType(LayoutT(layout,env,t)) -> Some (Some layout,env,t)
            | _ -> None

        let inline env_add a b env =
            match env with
            | EnvConsed env -> Map.add a b env.node |> Env
            | Env env -> Map.add a b env |> Env
            | EnvUnfiltered (env, used_vars) -> 
                let env = if used_vars.Contains a then Map.add a b env else env
                EnvUnfiltered(env,used_vars)

        let inline apply_func is_term_cast d recf layout env_term fun_type args =
            let unpack () =
                match layout with
                | None -> env_term
                | _ -> layout_env_term_unseal d recf env_term

            let inline tev x =
                if is_term_cast then join_point_closure args x
                else tev x

            match fun_type with
            | MapTypeRecFunction ((pat,body),name) ->
                let env_term = unpack()
                let env = if pat <> "" then env_add pat args env_term else env_term
                tev {d with env = env_add name recf env} body
            | MapTypeFunction (pat,body) -> 
                let env_term = unpack()
                tev {d with env = if pat <> "" then env_add pat args env_term else env_term} body
            // apply_module
            | MapTypeModule when is_term_cast -> on_type_er (trace d) <| sprintf "Expected a function in term casting application. Got: %A" fun_type
            | MapTypeModule ->
                match args with
                | TypeString n ->
                    let unpack () = v_find env_term n (fun () -> on_type_er (trace d) <| sprintf "Cannot find a member named %s inside the module." n)
                    match layout with
                    | None -> unpack()
                    | _ -> unpack() |> layout_boxed_unseal d recf
                | x -> on_type_er (trace d) "Expected a type level string in module application." 

        let term_cast d a b =
            match tev d a, tev d b with
            | recf & M(layout,env_term,fun_type), args -> 
                let instantiate_type_as_variable d args_ty =
                    let f x = make_up_vars_for_ty d x
                    match args_ty with
                    | ListT l -> tyvv(List.map f l)
                    | x -> f x
            
                let args = instantiate_type_as_variable d (get_type args)
                apply_func true d recf layout env_term fun_type args
            | x -> on_type_er (trace d) <| sprintf "Expected a function in term casting application. Got: %A" x

        let type_lit_create' x = litt x |> tyt

        let rec apply d a b =
            match destructure d a, destructure d b with
            // apply_function
            | recf & M(layout,env_term,fun_type), args -> apply_func false d recf layout env_term fun_type args
            // apply_string_static
            | TyLit (LitString str), TyList [TyLitIndex a; TyLitIndex b] -> 
                let f x = x >= 0 && x < str.Length
                if f a && f b then TyLit(LitString str.[a..b])
                else on_type_er (trace d) "The slice into a string literal is out of bounds."
            | TyLit (LitString str), TyLitIndex x -> 
                if x >= 0 && x < str.Length then TyLit(LitChar str.[x])
                else on_type_er (trace d) "The index into a string literal is out of bounds."
            // apply_array
            | ar & TyType(ArrayT(array_ty,elem_ty)), idx ->
                match array_ty, idx with
                | _, TypeString x -> 
                    if x = "elem_type" then elem_ty |> tyt
                    else failwithf "Unknown type string applied to array. Got: %s" x
                | (ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaShared | ArtCudaLocal), idx when is_int idx -> TyOp(ArrayIndex,[ar;idx],elem_ty) |> make_tyv_and_push_typed_expr d
                | (ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaShared | ArtCudaLocal), idx -> on_type_er (trace d) <| sprintf "The index into an array is not an int. Got: %A" idx
                | ArtDotNetReference, TyList [] -> TyOp(ArrayIndex,[ar;idx],elem_ty) |> make_tyv_and_push_typed_expr d
                | ArtDotNetReference, _ -> on_type_er (trace d) <| sprintf "The index into a reference is not a unit. Got: %A" idx
            // apply_dotnet_type 
            | TyType(DotNetTypeT(N t)) & dotnet_type, arg ->
                let lambdify a b =
                    let lam = 
                        inl' ["a";"b";"c"] (ap (v "a") (vv [v "b"; v "c"]))
                        |> inner_compile
                    apply d (apply d lam a) b

                let ss_overload_tryPick_method_return_type (TyTuple typ_arg) (TyType arg_ty) method_overloads =
                    let typ_arg_len, typ_arg = typ_arg.Length, List.map get_type typ_arg

                    method_overloads |> Array.tryPick (function
                        | SSTyLam(_,typ_arg',_) as lam -> 
                            if typ_arg_len = typ_arg'.Length then
                                let r = ss_apply lam typ_arg
                                match r with
                                | TermFunctionT(method_ty,method_ret) -> 
                                    if tuple_field_ty method_ty = tuple_field_ty arg_ty then Some method_ret else None
                                | _ -> failwith "Methods need to return an arrow type."
                            else None
                        | _ -> failwith "Methods should always be staged."
                        )

                let ss_class_find kind f r name =
                    match Map.tryFind name (f r) with
                    | None -> on_type_er (trace d) <| sprintf "Cannot find %s %s in the .NET type." kind name
                    | Some v -> v

                let ss_method_template kind ss_tryPick t name typ_arg arg =
                    match ss_tryPick t name typ_arg arg with
                    | Some ret_ty -> 
                        TyOp(DotNetTypeCallMethod,[dotnet_type;tyvv [name |> LitString |> type_lit_create'; arg]],ret_ty)
                        |> make_tyv_and_push_typed_expr_even_if_unit d        
                    | None ->
                        on_type_er (trace d) <| sprintf "%s with the matching arguments not found." kind

                let ss_static_method x = 
                    let tryPick t name typ_arg arg = 
                        ss_class_find "static method" (fun {static_methods=x} -> x) t name 
                        |> ss_overload_tryPick_method_return_type typ_arg arg
                    ss_method_template "Static method" tryPick x

                let ss_method x = 
                    let tryPick t name typ_arg arg = 
                        ss_class_find "method" (fun {methods=x} -> x) t name
                        |> ss_overload_tryPick_method_return_type typ_arg arg
                    ss_method_template "Method" tryPick x

                let ss_field_template f t name =
                    let name' = name |> LitString |> type_lit_create'
                    match Map.tryFind name (f t) with
                    | None -> lambdify dotnet_type name'
                    | Some field ->
                        match field with
                        | SSTyLam _ as lam -> 
                            let typ = ss_apply lam []
                            TyOp(DotNetTypeGetField,[dotnet_type;name'],typ)
                            |> make_tyv_and_push_typed_expr_even_if_unit d
                        | _ -> failwith "Fields should always be staged."

                let ss_field x = ss_field_template (fun {fields=a} -> a) x
                let ss_static_field x = ss_field_template (fun {static_fields=x} -> x) x

                let ss_constructor (t': SSTypedExprClass) (TyType args_ty & args) =
                    t'.constructors
                    |> Array.exists (fun x -> tuple_field_ty (ss_apply x []) = tuple_field_ty args_ty)
                    |> function
                        | false -> on_type_er (trace d) "No constructors with the matching arguments exist."
                        | _ ->
                            TyOp(DotNetTypeConstruct,[args],get_type dotnet_type) 
                            |> make_tyv_and_push_typed_expr_even_if_unit d

                let ss_type_apply t a = 
                    let a = get_type a |> tuple_field_ty
                    ss_apply t a |> tyt

                match dotnet_type with
                | TyT _ ->
                    match t with 
                    | SSTyClass t ->
                        match arg with
                        | TyList [TypeString method_name; typ_arg; arg] -> ss_static_method t method_name typ_arg arg
                        | TyList [TypeString method_name; arg] -> ss_static_method t method_name TyB arg
                        | TypeString field_name -> ss_static_field t field_name
                        | arg -> ss_constructor t arg
                    | _ -> ss_type_apply t arg
                | TyV _ ->
                    match t with 
                    | SSTyClass t ->
                        match arg with
                        | TyList [TypeString method_name; typ_arg; arg] -> ss_method t method_name typ_arg arg
                        | TyList [TypeString method_name; arg] -> ss_method t method_name TyB arg
                        | TypeString field_name -> 
                            match field_name with
                            | "elem_type" -> 
                                match t.generic_type_args with 
                                | [|x|] -> tyt x 
                                | x -> Array.map tyt x |> Array.toList |> tyvv
                            | _ -> ss_field t field_name
                        | _ -> on_type_er (trace d) "Invalid input to a .NET type."
                    | _ -> failwith "Compiler error: An instance of a .NET type should always be a SSTyClass."
                | _ -> failwith "impossible"
            // apply_string
            | TyType(PrimT StringT) & str, TyList [a;b] -> 
                if is_int a && is_int b then TyOp(StringSlice,[str;a;b],PrimT StringT) |> destructure d
                else on_type_er (trace d) "Expected an int as the second argument to string index."
            | TyType(PrimT StringT) & str, idx -> 
                if is_int idx then TyOp(StringIndex,[str;idx],PrimT CharT) |> destructure d
                else on_type_er (trace d) "Expected an int as the second argument to string index."
            // apply_closure
            | closure & TyType(TermFunctionT (clo_arg_ty,clo_ret_ty)), args -> 
                let arg_ty = get_type args
                if arg_ty <> clo_arg_ty then on_type_er (trace d) <| sprintf "Cannot apply an argument of type %A to closure (%A -> %A)." arg_ty clo_arg_ty clo_ret_ty
                else TyOp(Apply,[closure;args],clo_ret_ty) |> make_tyv_and_push_typed_expr_even_if_unit d
            | a,b -> on_type_er (trace d) <| sprintf "Invalid use of apply. %A and %A" a b

        let type_box d typec args =
            let typec & TyType ty, args = tev2 d typec args
            let substitute_ty = function
                | TyBox(x,_) -> tybox(x,ty)
                | x -> tybox(x,ty)

            let (|TyRecUnion|_|) = function
                | UnionT ty' -> Some ty'
                | RecT key -> Some (set_field (rect_unbox d key))
                | _ -> None

            match ty, args with
            | x, TyType r when x = r -> args
            | TyRecUnion ty', TyType (UnionT ty_args) when Set.isSubset ty_args ty' ->
                let lam = inl' ["typec"; "args"] (op(Case,[v "args"; type_box (v "typec") (v "args")])) |> inner_compile
                apply d (apply d lam typec) args
            | TyRecUnion ty', TyType x when Set.contains x ty' -> substitute_ty args
            | _ -> on_type_er (trace d) <| sprintf "Type constructor application failed. %A does not intersect %A." ty (get_type args)


        let apply_tev d expr args = apply d (tev d expr) (tev d args)

        let inline vv_index_template f d v i =
            let v,i = tev2 d v i
            match v, i with
            | TyList l, TyLitIndex i ->
                match f i l with
                | Some v -> v
                | None -> on_type_er (trace d) "Tuple index not within bounds."
            | v & TyType (ListT ts), TyLitIndex i -> failwith "The tuple should always be destructured."
            | v, TyLitIndex i -> on_type_er (trace d) <| sprintf "Type of an evaluated expression in tuple index is not a tuple.\nGot: %A" v
            | v, i -> on_type_er (trace d) <| sprintf "Index into a tuple must be an at least a i32 less than the size of the tuple.\nGot: %A" i

        let vv_index d v i = vv_index_template List.tryItem d v i |> destructure d
        let vv_slice_from d v i = 
            let rec loop i l = 
                if i = 0 then tyvv l |> Some
                else
                    match l with
                    | x :: xs -> loop (i-1) xs
                    | [] -> None
            vv_index_template loop d v i

        let inline vv_unop_template on_succ on_fail d v =
            match tev d v with
            | TyList l -> on_succ l
            | v & TyType (ListT ts) -> failwith "The tuple should always be destructured."
            | v -> on_fail()

        let vv_length x = 
            vv_unop_template (fun l -> l.Length |> int64 |> LitInt64 |> TyLit) 
                (fun _ -> on_type_er (trace d) <| sprintf "Type of an evaluated expression in tuple index is not a tuple.\nGot: %A" v) x
                
        let vv_is x = vv_unop_template (fun _ -> TyLit (LitBool true)) (fun _ -> TyLit (LitBool false)) x

        let eq_type d a b =
            let a, b = tev2 d a b 
            LitBool (get_type a = get_type b) |> TyLit
    
        let vv_cons d a b =
            let a, b = tev2 d a b
            match b with
            | TyList b -> tyvv(a::b)
            | _ -> on_type_er (trace d) "Expected a tuple on the right in ListCons."

        let module_open d a b =
            let a = tev d a
            match a with
            | M(layout,C env_term,MapTypeModule) as recf -> 
                let inline opt open_ env =
                    let env = 
                        let map_add s k v = Map.add k (open_ v) s
                        let run d_env = Map.fold map_add d_env env
                        match d.env with
                        | Env d_env -> run d_env |> Env
                        | EnvConsed d_env -> run d_env.node |> Env
                        | EnvUnfiltered (d_env,used_vars) ->
                            let d_env = Map.fold (fun s k v -> if used_vars.Contains k then map_add s k v else s) d_env env
                            EnvUnfiltered(d_env,used_vars)
                    tev {d with env = env} b
                match layout with
                | None -> opt id env_term
                | _ -> opt (layout_boxed_unseal d recf) env_term
            | x -> on_type_er (trace d) <| sprintf "The open expected a module type as input. Got: %A" x

        let type_annot d a b =
            match d.rbeh with
            | AnnotationReturn -> tev_seq {d with rbeh=AnnotationDive} b
            | AnnotationDive ->
                let a, b = tev d a, tev_seq {d with rbeh=AnnotationDive} b
                let ta, tb = get_type a, get_type b
                if ta = tb then a else on_type_er (trace d) <| sprintf "Type annotation mismatch.\n%A <> %A" ta tb

        let inline prim_bin_op_template d check_error is_check k a b t =
            let a, b = tev2 d a b
            if is_check a b then k t a b
            else on_type_er (trace d) (check_error a b)

        let inline prim_bin_op_helper t a b = TyOp(t,[a;b],get_type a)
        let inline prim_un_op_helper t a = TyOp(t,[a],get_type a)
        let inline bool_helper t a b = TyOp(t,[a;b],PrimT BoolT)

        let prim_arith_op d a b t = 
            let er a b = sprintf "`is_numeric a && get_type a = get_type b` is false.\na=%A, b=%A" a b
            let check a b = is_numeric a && get_type a = get_type b
            prim_bin_op_template d er check (fun t a b ->
                let inline op_arith a b =
                    match t with
                    | Add -> a + b
                    | Sub -> a - b
                    | Mult -> a * b
                    | Div -> a / b
                    | Mod -> a % b
                    | _ -> failwith "Expected an arithmetic operation."
                let op_arith_num_zero a b =
                    match t with
                    | Add | Sub -> a
                    | Mult -> b
                    | Div -> on_type_er (trace d) "Division by zero caught at compile time."
                    | Mod -> on_type_er (trace d) "Modulus by zero caught at compile time."
                    | _ -> failwith "Expected an arithmetic operation."
                let op_arith_zero_num a b =
                    match t with
                    | Add -> b
                    | Sub -> TyOp(Neg,[b],get_type b) |> destructure d
                    | Mult | Div | Mod -> a
                    | _ -> failwith "Expected an arithmetic operation."
                let op_arith_num_one a b =
                    match t with
                    | Mult | Div | Mod -> a
                    | Add | Sub -> prim_bin_op_helper t a b
                    | _ -> failwith "Expected an arithmetic operation."
                let op_arith_one_num a b =
                    match t with
                    | Mult -> b
                    | Div | Mod | Add | Sub -> prim_bin_op_helper t a b
                    | _ -> failwith "Expected an arithmetic operation."
                match a, b with
                | TyLit a', TyLit b' ->
                    match a', b' with
                    | LitInt8 a, LitInt8 b -> op_arith a b |> LitInt8 |> TyLit
                    | LitInt16 a, LitInt16 b -> op_arith a b |> LitInt16 |> TyLit
                    | LitInt32 a, LitInt32 b -> op_arith a b |> LitInt32 |> TyLit
                    | LitInt64 a, LitInt64 b -> op_arith a b |> LitInt64 |> TyLit
                    | LitUInt8 a, LitUInt8 b -> op_arith a b |> LitUInt8 |> TyLit
                    | LitUInt16 a, LitUInt16 b -> op_arith a b |> LitUInt16 |> TyLit
                    | LitUInt32 a, LitUInt32 b -> op_arith a b |> LitUInt32 |> TyLit
                    | LitUInt64 a, LitUInt64 b -> op_arith a b |> LitUInt64 |> TyLit
                    | LitFloat32 a, LitFloat32 b -> op_arith a b |> LitFloat32 |> TyLit
                    | LitFloat64 a, LitFloat64 b -> op_arith a b |> LitFloat64 |> TyLit
                    | _ -> prim_bin_op_helper t a b

                | TyLit a', _ ->
                    match a' with
                    | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
                    | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL
                    | LitFloat32 0.0f | LitFloat64 0.0 -> op_arith_zero_num a b
                    | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
                    | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL
                    | LitFloat32 1.0f | LitFloat64 1.0 -> op_arith_one_num a b
                    | _ -> prim_bin_op_helper t a b

                | _, TyLit b' ->
                    match b' with
                    | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
                    | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL
                    | LitFloat32 0.0f | LitFloat64 0.0 -> op_arith_num_zero a b
                    | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
                    | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL
                    | LitFloat32 1.0f | LitFloat64 1.0 -> op_arith_num_one a b
                    | _ -> prim_bin_op_helper t a b
                | TyV(a',typ), TyV(b',_) when a' = b' && t = Sub -> 
                    match typ with
                    | PrimT Int8T -> LitInt8 0y |> TyLit
                    | PrimT Int16T -> LitInt16 0s |> TyLit
                    | PrimT Int32T -> LitInt32 0 |> TyLit
                    | PrimT Int64T -> LitInt64 0L |> TyLit
                    | PrimT UInt8T -> LitUInt8 0uy |> TyLit
                    | PrimT UInt16T -> LitUInt16 0us |> TyLit
                    | PrimT UInt32T -> LitUInt32 0u |> TyLit
                    | PrimT UInt64T -> LitUInt64 0UL |> TyLit
                    | PrimT Float32T -> LitFloat32 0.0f |> TyLit
                    | PrimT Float64T -> LitFloat64 0.0 |> TyLit
                    | _ -> prim_bin_op_helper t a b
                | _ -> prim_bin_op_helper t a b
                ) a b t

        let prim_comp_op d a b t = 
            let er a b = sprintf "(is_char a || is_string a || is_numeric a || is_bool a) && get_type a = get_type b` is false.\na=%A, b=%A" a b
            let check a b = (is_char a || is_string a || is_numeric a || is_bool a) && get_type a = get_type b
            prim_bin_op_template d er check (fun t a b ->
                let inline eq_op a b = LitBool (a = b) |> TyLit
                let inline neq_op a b = LitBool (a <> b) |> TyLit
                match t, a, b with
                | EQ, TyV(a,_), TyV(b,_) when a = b -> LitBool true |> TyLit
                | EQ, TyLit (LitBool a), TyLit (LitBool b) -> eq_op a b
                | EQ, TyLit (LitString a), TyLit (LitString b) -> eq_op a b
                | NEQ, TyV(a,_), TyV(b,_) when a = b -> LitBool false |> TyLit
                | NEQ, TyLit (LitBool a), TyLit (LitBool b) -> neq_op a b
                | NEQ, TyLit (LitString a), TyLit (LitString b) -> neq_op a b
                | _ ->
                    let inline op a b =
                        match t with
                        | LT -> a < b
                        | LTE -> a <= b
                        | EQ -> a = b
                        | NEQ -> a <> b
                        | GT -> a > b
                        | GTE -> a >= b 
                        | _ -> failwith "Expected a comparison operation."
                    match a, b with
                    | TyLit a', TyLit b' ->
                        match a', b' with
                        | LitInt8 a, LitInt8 b -> op a b |> LitBool |> TyLit
                        | LitInt16 a, LitInt16 b -> op a b |> LitBool |> TyLit
                        | LitInt32 a, LitInt32 b -> op a b |> LitBool |> TyLit
                        | LitInt64 a, LitInt64 b -> op a b |> LitBool |> TyLit
                        | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> TyLit
                        | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> TyLit
                        | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> TyLit
                        | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> TyLit
                        | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> TyLit
                        | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> TyLit
                        | LitString a, LitString b -> op a b |> LitBool |> TyLit
                        | LitChar a, LitChar b -> op a b |> LitBool |> TyLit
                        | _ -> bool_helper t a b
                    | _ -> bool_helper t a b
                    ) a b t

        let prim_bool_op d a b t =
            match t with
            | And -> if_ d a b (lit (LitBool false))
            | Or -> if_ d a (lit (LitBool true)) b
            | _ -> failwith "impossible"

        let prim_shift_op d a b t =
            let er a b = sprintf "`is_int a && is_int b` is false.\na=%A, b=%A" a b
            let check a b = is_int a && is_int b
            prim_bin_op_template d er check prim_bin_op_helper a b t

        let prim_bitwise_op d a b t =
            let er a b = sprintf "`is_any_int a && is_any_int b` is false.\na=%A, b=%A" a b
            let check a b = is_any_int a && is_any_int b
            prim_bin_op_template d er check prim_bin_op_helper a b t

        let prim_shuffle_op d a b t =
            let er a b = sprintf "`is_int b` is false.\na=%A, b=%A" a b
            let check a b = is_int b
            prim_bin_op_template d er check prim_bin_op_helper a b t

        let prim_un_op_template d check_error is_check k a t =
            let a = tev d a
            if is_check a then k t a
            else on_type_er (trace d) (check_error a)

        let prim_un_floating d a t =
            let er a = sprintf "`is_float a` is false.\na=%A" a
            let check a = is_float a
            prim_un_op_template d er check prim_un_op_helper a t

        let prim_un_numeric d a t =
            let er a = sprintf "`is_numeric a` is false.\na=%A" a
            let check a = is_numeric a
            prim_un_op_template d er check (fun t a -> 
                let inline op a = 
                    match t with
                    | Neg -> -a
                    | _ -> failwithf "Unexpected operation %A." t

                match a with
                | TyLit a' ->
                    match a' with
                    | LitInt8 a -> op a |> LitInt8 |> TyLit
                    | LitInt16 a -> op a |> LitInt16 |> TyLit
                    | LitInt32 a -> op a |> LitInt32 |> TyLit
                    | LitInt64 a -> op a |> LitInt64 |> TyLit
                    | LitFloat32 a -> op a |> LitFloat32 |> TyLit
                    | LitFloat64 a -> op a |> LitFloat64 |> TyLit
                    | _ -> prim_un_op_helper t a
                | _ -> prim_un_op_helper t a
                ) a t

        let error_non_unit d a =
            let x = tev d a 
            if get_type x <> BListT then on_type_er (trace d) "Only the last expression of a block is allowed to be unit. Use `ignore` if it intended to be such."
            else x

        let type_lit_create d a =
            match tev d a with
            | TyLit a -> type_lit_create' a
            | _ -> on_type_er (trace d) "Expected a literal in type literal create."

        let type_lit_cast d a =
            match tev d a with
            | TyT (LitT x) -> TyLit x
            | _ -> on_type_er (trace d) "Expected a literal in type literal cast."

        let type_lit_is d a =
            match tev d a with
            | TyT (LitT _) -> TyLit <| LitBool true
            | _ -> TyLit <| LitBool false

        let lit_is d a =
            match tev d a with
            | TyLit _ -> TyLit <| LitBool true
            | _ -> TyLit <| LitBool false

        let box_is d a =
            match tev d a with
            | TyBox _ -> TyLit <| LitBool true
            | _ -> TyLit <| LitBool false

        let caseable_is d a =
            match tev d a with
            | TyType (UnionT _ | RecT _) -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)

        let caseable_boxed_is d a =
            match tev d a with
            | (TyT _ | TyV _) & TyType (UnionT _ | RecT _) -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)

        // Is intended to be equal to push -> destructure.
        let dynamize d a =
            let rec loop = function
                | TyBox(_, _) | TyLit _ as a -> make_tyv_and_push_typed_expr d a
                | TyList l -> tyvv (List.map loop l)
                | TyMap(C env, t) -> tymap (Map.map (fun _ -> loop) env |> Env, t)
                | a -> a
            
            loop (tev d a)

        let module_create d l =
            let rec loop acc = function
                | V (N x) -> x :: acc
                | VV (N l) -> List.fold loop acc l
                | ExprPos p -> loop acc p.Expression
                | x -> on_type_er (trace d) <| sprintf "Only variable names are allowed in module create. Got: %A" x
            let er n _ = on_type_er (trace d) <| sprintf "In module create, the variable %s was not found." n
            let env = List.fold (fun s n -> Map.add n (v_find d.env n (er n)) s) Map.empty (loop [] l) |> Env
            tymap(env, MapTypeModule)

        let array_create d size typ =
            let typ = tev_seq d typ |> get_type

            let size,array_type =
                match tev d size with
                | size when is_int size -> size,arrayt(ArtDotNetHeap,typ)
                | size -> on_type_er (trace d) <| sprintf "An size argument in CreateArray is not of type int64.\nGot: %A" size

            TyOp(ArrayCreate,[size],array_type) |> make_tyv_and_push_typed_expr d

        let reference_create d x =
            let x = tev d x
            let array_type = arrayt(ArtDotNetReference, get_type x)
            TyOp(ReferenceCreate,[x],array_type) |> make_tyv_and_push_typed_expr d

        let mutable_set d ar idx r =
            let ret t ar idx r =
                if is_unit t then TyB
                else make_tyv_and_push_typed_expr_even_if_unit d (TyOp(MutableSet,[ar;idx;r],BListT))
            match tev3 d ar idx r with
            | ar & TyType (ArrayT((ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaShared | ArtCudaLocal),ar_ty)), idx, r ->
                if is_int idx then
                    let r_ty = get_type r
                    if ar_ty = r_ty then ret ar_ty ar idx r
                    else on_type_er (trace d) <| sprintf "The two sides in array set have different types.\nGot: %A and %A" ar_ty r_ty
                else on_type_er (trace d) <| sprintf "Expected the array index to be an integer.\nGot: %A" idx
            | ar & TyType (ArrayT(ArtDotNetReference,ar_ty)), idx, r ->
                match idx with
                | TyList [] ->
                    let r_ty = get_type r
                    if ar_ty = r_ty then ret ar_ty ar idx r
                    else on_type_er (trace d) <| sprintf "The two sides in reference set have different types.\nGot: %A and %A" ar_ty r_ty
                | _ -> on_type_er (trace d) <| sprintf "The input to reference set should be ().\nGot: %A" idx
            | module_ & TyType (LayoutT(LayoutHeapMutable,C env,_)), field, r ->
                match field with
                | TypeString field' ->
                    let r_ty = get_type r
                    let mutable s = 0
                    let br =
                        Map.exists (fun k v -> 
                            if k = field' then 
                                let v_ty = get_type v
                                if v_ty = r_ty then true 
                                else on_type_er (trace d) <| sprintf "The two sides in the module set have different types.\nExpected: %A\n Got:%A" v_ty r_ty
                            else 
                                s <- s+1
                                false) env
                    if br then ret r_ty module_ (sprintf "mem_%i" s |> LitString |> type_lit_create') r
                    else on_type_er (trace d) <| sprintf "The field %s is missing in the module." field'
                | x -> on_type_er (trace d) <| sprintf "Expected a type string as the input to a mutable heap module.\nGot: %A" x
            | x,_,_ -> on_type_er (trace d) <| sprintf "Expected a heap mutable module, reference or an array the input to mutable set.\nGot: %A" x

        let array_length d ar =
            match tev d ar with
            | ar & TyType (ArrayT(ArtDotNetHeap,t))-> make_tyv_and_push_typed_expr d (TyOp(ArrayLength,[ar],PrimT Int64T))
            | ar & TyType (ArrayT(ArtDotNetReference,t))-> TyLit (LitInt64 1L)
            | x -> on_type_er (trace d) <| sprintf "ArrayLength is only supported for .NET arrays. Got: %A" x

        let module_is d a =
            match tev d a with
            | M(_,_,MapTypeModule) -> TyLit (LitBool true)
            | _ -> TyLit (LitBool false)

        let module_values d a =
            match tev d a with
            | M(layout,C env,MapTypeModule) as recf ->
                let inline toList f = Map.foldBack (fun _ x s -> f x :: s) env []
                match layout with
                | None -> toList id
                | _ -> toList (layout_boxed_unseal d recf)
                |> tyvv
            | x ->
                on_type_er (trace d) <| sprintf "Expected a module. Got: %A" x

        let module_map d map_op a =
            match tev2 d map_op a with
            | map_op, M(layout,C env,MapTypeModule) & recf ->
                let inline map f = 
                    let f k x = apply d (apply d map_op (type_lit_create' (LitString k))) (f x)
                    tymap(Map.map f env |> Env, MapTypeModule)
                match layout with
                | None -> map id
                | Some l -> map (layout_boxed_unseal d recf) |> layoutify l d
            | x ->
                on_type_er (trace d) <| sprintf "Expected a module. Got: %A" x

        let module_fold d fold_op s m =
            match tev3 d fold_op s m with
            | fold_op, s, M(layout,C env,MapTypeModule) & recf ->
                let inline ap a b = apply d a b
                let inline fold f = Map.fold (fun s k v -> ap (ap (ap fold_op s) (type_lit_create' (LitString k))) (f v)) s env
                match layout with
                | None -> fold id
                | Some l -> fold (layout_boxed_unseal d recf)
            | x ->
                on_type_er (trace d) <| sprintf "Expected a module. Got: %A" x

        let module_has_member d a b =
            match tev2 d a b with
            | M(_,C env,MapTypeModule), b -> 
                match b with
                | TypeString b -> TyLit (LitBool <| Map.containsKey b env)
                | _ -> on_type_er (trace d) "Expecting a type literals as the second argument to ModuleHasMember."
            | x -> on_type_er (trace d) <| sprintf "Expecting a module as the first argument to ModuleHasMember. Got: %A" x

        let module_create d l =
            List.fold (fun env -> function
                | VV(N [Lit(N(LitString n)); e]) -> Map.add n (tev d e |> destructure d) env
                | _ -> failwith "impossible"
                ) Map.empty l
            |> fun x -> tymap(Env x, MapTypeModule)

        let module_with (d: LangEnv) l =
            let names, bindings =
                match l with
                | VV (N l) :: bindings -> l, bindings
                | V _ as x :: bindings -> [x], bindings
                | x -> failwithf "Malformed ModuleWith. %A" x

            let rec module_with_loop (C cur_env) names = 
                let inline layout_unseal name =
                    match Map.tryFind name cur_env with
                    | Some (M(layout,env,MapTypeModule) as recf) -> 
                        match layout with
                        | None -> layout, env
                        | _ -> layout, layout_env_term_unseal d recf env
                    | Some _ -> on_type_er (trace d) <| sprintf "Variable %s is not a module." name
                    | _ -> on_type_er (trace d) <| sprintf "Module %s is not bound in the environment." name

                let inline layout_reseal layout env =
                    match layout with
                    | None -> env
                    | Some layout -> layoutify layout d env

                let inline layout_map f name =
                    let layout,env = layout_unseal name
                    layout_reseal layout (f env)

                let inline next names env = module_with_loop env names

                match names with
                | V(N name) :: names -> layout_map (next names) name
                | Lit(N(LitString name)) :: names -> tymap (Map.add name (layout_map (next names) name) cur_env |> Env, MapTypeModule)
                | [] ->
                    List.fold (fun env -> function
                        | VV(N [Lit(N(LitString name)); e]) ->
                            match Map.tryFind name env with
                            | Some v -> {d with env = env_add "self" v d.env}
                            | None -> d
                            |> fun d -> Map.add name (tev d e |> destructure d) env
                        | Op(N(ModuleWithout,[Lit(N(LitString name))])) ->
                            Map.remove name env
                        | _ -> failwith "impossible"
                        ) cur_env bindings
                    |> fun env -> tymap(Env env, MapTypeModule)
                | x -> failwithf "Malformed ModuleWith. %A" x
            module_with_loop d.env names

        let failwith_ d typ a =
            match tev2 d typ a with
            | typ, TyType (PrimT StringT) & a -> TyOp(FailWith,[a],get_type typ) |> make_tyv_and_push_typed_expr_even_if_unit d
            | _ -> on_type_er (trace d) "Expected a string as input to failwith."

        let unsafe_convert d to_ from =
            let to_,from = tev2 d to_ from
            let tot,fromt = get_type to_, get_type from
            if tot = fromt then from
            else
                let inline conv_lit x =
                    match tot with
                    | PrimT Int8T -> int8 x |> LitInt8
                    | PrimT Int16T -> int16 x |> LitInt16
                    | PrimT Int32T -> int32 x |> LitInt32
                    | PrimT Int64T -> int64 x |> LitInt64
                    | PrimT UInt8T -> uint8 x |> LitUInt8
                    | PrimT UInt16T -> uint16 x |> LitUInt16
                    | PrimT UInt32T -> uint32 x |> LitUInt32
                    | PrimT UInt64T -> uint64 x |> LitUInt64
                    | PrimT CharT -> char x |> LitChar
                    | PrimT Float32T -> float32 x |> LitFloat32
                    | PrimT Float64T -> float x |> LitFloat64
                    | _ -> on_type_er (trace d) "Cannot convert the literal to the following type: %A" tot
                    |> TyLit
                match from with
                | TyLit (LitInt8 a) -> conv_lit a
                | TyLit (LitInt16 a) -> conv_lit a
                | TyLit (LitInt32 a) -> conv_lit a
                | TyLit (LitInt64 a) -> conv_lit a
                | TyLit (LitUInt8 a) -> conv_lit a
                | TyLit (LitUInt16 a) -> conv_lit a
                | TyLit (LitUInt32 a) -> conv_lit a
                | TyLit (LitUInt64 a) -> conv_lit a
                | TyLit (LitChar a) -> conv_lit a
                | TyLit (LitFloat32 a) -> conv_lit a
                | TyLit (LitFloat64 a) -> conv_lit a
                | TyLit (LitBool _) -> on_type_er (trace d) "Cannot convert the a boolean literal to the following type: %A" tot
                // The string is not supported because it can't throw an exception if the conversion fails on the Cuda side.
                | TyLit (LitString _) -> on_type_er (trace d) "Cannot convert the a string literal to the following type: %A" tot
                | _ ->
                    let is_convertible_primt x =
                        match x with
                        | PrimT BoolT | PrimT StringT -> false
                        | PrimT _ -> true
                        | _ -> false
                    if is_convertible_primt fromt && is_convertible_primt tot then TyOp(UnsafeConvert,[to_;from],tot)
                    else on_type_er (trace d) <| sprintf "Cannot convert %A to the following type: %A" from tot

        let unsafe_upcast_to d a b =
            let a, b = tev2 d a b
            TyOp(UnsafeUpcastTo,[a;b],get_type a)

        let unsafe_downcast_to d a b =
            let a, b = tev2 d a b
            TyOp(UnsafeDowncastTo,[a;b],get_type a)

        let unsafe_coerce_to_array_cuda_global d a b =
            match tev2 d a b with
            | TyV(x,t'), t -> tyv(x,ArrayT(ArtCudaGlobal t',get_type t))
            | TyT t', t -> tyt(ArrayT(ArtCudaGlobal t',get_type t))
            | _ -> on_type_er (trace d) "Only variables or runtime types can be converted to the Cuda global array type."

        let sizeof d a = TyOp(SizeOf,[tev d a],PrimT Int64T)

        let macro op d t a = 
            let t, a = tev_seq d t, tev d a
            TyOp(op,[a],get_type t) |> make_tyv_and_push_typed_expr_even_if_unit d
           
        let inline add_trace (d: LangEnv) x = {d with trace = x :: (trace d)}

        match expr with
        | Lit (N value) -> TyLit value
        | V (N x) -> v_find d.env x (fun () -> on_type_er (trace d) <| sprintf "Variable %A not bound." x) |> destructure d
        | FunctionFilt(N (vars,N (pat, body))) -> 
            let env = match d.env with | EnvUnfiltered (env,_) | Env env | EnvConsed (CN env) -> env
            tymap(EnvUnfiltered (env,vars), MapTypeFunction (pat, body))
        | Function core -> failwith "Function not allowed in this phase as it tends to cause stack overflows in recursive scenarios."
        | Pattern pat -> failwith "Pattern not allowed in this phase as it tends to cause stack overflows when prepass is triggered in the match case."
        | ExprPos p -> tev (add_trace d p.Pos) p.Expression
        | VV (N vars) -> List.map (tev d >> destructure d) vars |> tyvv
        | Op(N (op,vars)) ->
            match op,vars with
            | (MacroFs | MacroCuda),[a;b] -> macro op d a b
            | Apply,[a;b] -> apply_tev d a b
            | StringLength,[a] -> string_length d a
            | DotNetAssemblyLoad,[a] -> dotnet_assembly_load false d a
            | DotNetAssemblyLoadFile,[a] -> dotnet_assembly_load true d a
            | Fix,[Lit (N (LitString name)); body] ->
                match tev d body with
                | TyMap(env_term,MapTypeFunction core) -> tymap(env_term,MapTypeRecFunction(core,name))
                | x -> x
            | Case,[v;case] -> case_ d v case
            | IfStatic,[cond;tr;fl] -> if_static d cond tr fl
            | If,[cond;tr;fl] -> if_ d cond tr fl
            | JoinPointEntryMethod,[a] -> join_point_method d a
            | JoinPointEntryType,[a] -> join_point_type d a
            | JoinPointEntryCuda,[a] -> join_point_cuda d a
            | TermCast,[a;b] -> term_cast d a b
            | UnsafeConvert,[to_;from] -> unsafe_convert d to_ from
            | PrintStatic,[a] -> printfn "%A" (tev d a); TyB
            | PrintEnv,[a] -> 
                Map.iter (fun k v -> printfn "%s" k) (c d.env)
                tev d a
            | PrintExpr,[a] -> printfn "%A" a; tev d a
            | LayoutToNone,[a] -> layout_to_none d a
            | LayoutToStack,[a] -> layout_to LayoutStack d a
            | LayoutToPackedStack,[a] -> layout_to LayoutPackedStack d a
            | LayoutToHeap,[a] -> layout_to LayoutHeap d a
            | LayoutToHeapMutable,[a] -> layout_to LayoutHeapMutable d a
            | TypeLitCreate,[a] -> type_lit_create d a
            | TypeLitCast,[a] -> type_lit_cast d a
            | TypeLitIs,[a] -> type_lit_is d a
            | Dynamize,[a] -> dynamize d a
            | LitIs,[a] -> lit_is d a
            | BoxIs,[a] -> box_is d a
            | ModuleOpen,[a;b] -> module_open d a b
            | ModuleCreate,l -> module_create d l
            | ModuleWith, l -> module_with d l
            | ModuleValues, [a] -> module_values d a
            | ModuleIs,[a] -> module_is d a
            | ModuleHasMember,[a;b] -> module_has_member d a b
            | ModuleMap,[a;b] -> module_map d a b
            | ModuleFold,[a;b;c] -> module_fold d a b c
            | CaseableIs,[a] -> caseable_is d a
            | CaseableBoxedIs,[a] -> caseable_boxed_is d a

            | ArrayCreate,[a;b] -> array_create d a b
            | ReferenceCreate,[a] -> reference_create d a
            | MutableSet,[a;b;c] -> mutable_set d a b c
            | ArrayLength,[a] -> array_length d a

            // Primitive operations on expressions.
            | Add,[a;b] -> prim_arith_op d a b Add
            | Sub,[a;b] -> prim_arith_op d a b Sub 
            | Mult,[a;b] -> prim_arith_op d a b Mult
            | Div,[a;b] -> prim_arith_op d a b Div
            | Mod,[a;b] -> prim_arith_op d a b Mod

            | LT,[a;b] -> prim_comp_op d a b LT
            | LTE,[a;b] -> prim_comp_op d a b LTE
            | EQ,[a;b] -> prim_comp_op d a b EQ
            | NEQ,[a;b] -> prim_comp_op d a b NEQ 
            | GT,[a;b] -> prim_comp_op d a b GT
            | GTE,[a;b] -> prim_comp_op d a b GTE
    
            | And,[a;b] -> prim_bool_op d a b And
            | Or,[a;b] -> prim_bool_op d a b Or

            | BitwiseAnd,[a;b] -> prim_bitwise_op d a b BitwiseAnd
            | BitwiseOr,[a;b] -> prim_bitwise_op d a b BitwiseOr
            | BitwiseXor,[a;b] -> prim_bitwise_op d a b BitwiseXor

            | ShiftLeft,[a;b] -> prim_shift_op d a b ShiftLeft
            | ShiftRight,[a;b] -> prim_shift_op d a b ShiftRight

            | ListIndex,[a;b] -> vv_index d a b
            | ListLength,[a] -> vv_length d a
            | ListIs,[a] -> vv_is d a
            | ListSliceFrom,[a;b] -> vv_slice_from d a b
            | ListCons,[a;b] -> vv_cons d a b

            | TypeAnnot,[a;b] -> type_annot d a b
            | TypeUnion,[a;b] -> type_union d a b
            | TypeBox,[a;b] -> type_box d a b
            | TypeGet,[a] -> type_get d a
            | TypeSplit,[a] -> type_split d a

            | TermFunctionTypeCreate,[a;b] -> closure_type_create d a b
            | ClosureIs,[a] -> closure_is d a
            | ClosureDomain,[a] -> closure_dr true d a
            | ClosureRange,[a] -> closure_dr false d a 

            | EqType,[a;b] -> eq_type d a b
            | Neg,[a] -> prim_un_numeric d a Neg
            | ErrorType,[a] -> tev d a |> fun a -> on_type_er (trace d) <| sprintf "%A" a
            | ErrorNonUnit,[a] -> error_non_unit d a
            | ErrorPatClause,[] -> on_type_er (trace d) "Compiler error: The pattern matching clauses are malformed. PatClause is missing."
            | ErrorPatMiss,[a] -> tev d a |> fun a -> on_type_er (trace d) <| sprintf "Pattern miss error. The argument is %A" a

            | Log,[a] -> prim_un_floating d a Log
            | Exp,[a] -> prim_un_floating d a Exp
            | Tanh,[a] -> prim_un_floating d a Tanh
            | FailWith,[typ;a] -> failwith_ d typ a

            | UnsafeUpcastTo,[a;b] -> unsafe_upcast_to d a b
            | UnsafeDowncastTo,[a;b] -> unsafe_downcast_to d a b
            | UnsafeCoerceToArrayCudaGlobal,[a;b] -> unsafe_coerce_to_array_cuda_global d a b
            | SizeOf,[a] -> sizeof d a
            
            | x -> failwithf "Missing Op case. %A" x

    // #Parsing
    let spiral_parse (Module(N(module_name,_,_,module_code)) & module_) = 
        let pos' (s: CharStream<_>) = module_, s.Line, s.Column
        let pos expr (s: CharStream<_>) = (expr |>> expr_pos (pos' s)) s

        let patpos expr (s: CharStream<_>) = 
            let p = pos' s
            (expr |>> fun expr -> pat_pos p expr) s

        let rec spaces_template spaces s = spaces >>. optional (followedByString "//" >>. skipRestOfLine true >>. spaces_template spaces) <| s
        let spaces, spaces1 = spaces_template spaces, spaces_template spaces1
    
        let is_identifier_starting_char c = isAsciiLetter c || c = '_'
        let is_identifier_char c = is_identifier_starting_char c || c = ''' || isDigit c 
        let is_separator_char c = 
            let inline f x = c = x
            f ' ' || f ',' || f ';' || f '\t' || f '\n' || f '\"' || f '(' || f '{' || f '['
        let is_closing_parenth_char c = 
            let inline f x = c = x
            f ')' || f '}' || f ']'
        let is_operator_char c = (is_identifier_char c || is_separator_char c || is_closing_parenth_char c) = false

        let var_name_core s = (many1Satisfy2L is_identifier_starting_char is_identifier_char "identifier" .>> spaces) s

        let var_name =
            var_name_core >>=? function
                | "match" | "function" | "with" | "without" | "open" | "module" | "as" | "when" | "print_env" | "inl" | "met" | "inm" 
                | "inb" | "use" | "type" | "print_expr" | "rec" | "if" | "if_dynamic" | "then" | "elif" | "else" | "true" | "false" 
                | "join" as x -> fun _ -> Reply(Error,messageError <| sprintf "%s not allowed as an identifier." x)
                | x -> preturn x

        let between_brackets l p r = between (skipChar l >>. spaces) (skipChar r >>. spaces) p
        let rounds p = between_brackets '(' p ')'
        let curlies p = between_brackets '{' p '}'
        let squares p = between_brackets '[' p ']'
        
        let keywordString x = attempt (skipString x >>. nextCharSatisfiesNot is_identifier_char >>. spaces)
        let operatorChar x = attempt (skipChar x >>. nextCharSatisfiesNot is_operator_char >>. spaces)
        let prefixOperatorChar x = attempt (skipChar x >>. nextCharSatisfiesNot is_operator_char)
        let operatorString x = attempt (skipString x >>. nextCharSatisfiesNot is_operator_char >>. spaces)

        let when_ = keywordString "when"
        let as_ = keywordString "as"
        let prefix_negate = prefixOperatorChar '-'
        let comma = skipChar ',' >>. spaces
        let dot = operatorChar '.'
        let prefix_dot = prefixOperatorChar '.'
        let pp = operatorChar ':'
        let semicolon' = operatorChar ';'
        let semicolon = semicolon' >>=? fun _ s -> 
            if s.Line <> s.UserState.semicolon_line then Reply(())
            else Reply(ReplyStatus.Error, messageError "cannot parse ; on this line") 
        let eq = operatorChar '=' 
        let eq' = skipChar '=' >>. spaces
        let bar = operatorChar '|' 
        let amphersand = operatorChar '&'
        let caret = operatorChar '^'
        let barbar = operatorString "||" 
        let lam = operatorString "->"
        let arr = operatorString "=>"
        let union = operatorString "\/"
        let set_ref = operatorString ":="
        let set_array = operatorString "<-"
        let inl_ = keywordString "inl"
        let inm_ = keywordString "inm"
        let use_ = keywordString "use"
        let inb_ = keywordString "inb"
        let met_ = keywordString "met"
        let inl_rec = keywordString "inl" >>. keywordString "rec"
        let met_rec = keywordString "met" >>. keywordString "rec"
        let match_ = keywordString "match"
        let function_ = keywordString "function"
        let with_ = keywordString "with"
        let without = keywordString "without"
        let open_ = keywordString "open"
        let cons = operatorString "::"
        let active_pat = prefixOperatorChar '!'
        let not_ = active_pat
        let part_active_pat = prefixOperatorChar '@'
        let ext_active_pat = prefixOperatorChar '#'
        let type_' = keywordString "type"
        let wildcard = operatorChar '_'

        let pbool = ((skipString "false" >>% LitBool false) <|> (skipString "true" >>% LitBool true)) .>> spaces

        let unary_minus_check_precondition s = previousCharSatisfiesNot (is_separator_char >> not) s
        let unary_minus_check s = (unary_minus_check_precondition >>. prefix_negate) s

        let pnumber : Parser<_,_> =
            let default_number_format =  
                NumberLiteralOptions.AllowFraction
                ||| NumberLiteralOptions.AllowExponent
                ||| NumberLiteralOptions.AllowHexadecimal
                ||| NumberLiteralOptions.AllowBinary
                ||| NumberLiteralOptions.AllowInfinity
                ||| NumberLiteralOptions.AllowNaN
            
            let number_format_with_minus = default_number_format ||| NumberLiteralOptions.AllowMinusSign

            let parser (s: CharStream<_>) = 
                let parse_num_lit number_format s = numberLiteral number_format "number" s
                /// This is necessary in order to differentiate binary from unary operations.
                if s.Peek() = '-' then (unary_minus_check_precondition >>. parse_num_lit number_format_with_minus) s
                else parse_num_lit default_number_format s

            let inline safe_parse f on_succ er_msg x = 
                match f x with
                | true, x -> Reply(on_succ x)
                | false, _ -> Reply(ReplyStatus.FatalError,messageError er_msg)

            let default_int x _ = safe_parse Int64.TryParse LitInt64 "default int parse failed" x
            let default_float x _ = safe_parse Double.TryParse LitFloat64 "default float parse failed" x

            let int8 x _ = safe_parse SByte.TryParse LitInt8 "int8 parse failed" x
            let int16 x _ = safe_parse Int16.TryParse LitInt16 "int16 parse failed" x
            let int32 x _ = safe_parse Int32.TryParse LitInt32 "int32 parse failed" x
            let int64 x _ = safe_parse Int64.TryParse LitInt64 "int64 parse failed" x

            let uint8 x _ = safe_parse Byte.TryParse LitUInt8 "uint8 parse failed" x
            let uint16 x _ = safe_parse UInt16.TryParse LitUInt16 "uint16 parse failed" x
            let uint32 x _ = safe_parse UInt32.TryParse LitUInt32 "uint32 parse failed" x
            let uint64 x _ = safe_parse UInt64.TryParse LitUInt64 "uint64 parse failed" x

            let float32 x _ = safe_parse Single.TryParse LitFloat32 "float32 parse failed" x
            let float64 x _ = safe_parse Double.TryParse LitFloat64 "float64 parse failed" x

            let followedBySuffix x is_x_integer =
                let f c l = 
                    let l = Array.map (fun (k,m) -> keywordString k >>= fun _ -> m x) l
                    skipChar c >>. choice l
                choice
                    [|
                    f 'i'
                        [|
                        "8", int8
                        "16", int16
                        "32", int32
                        "64", int64
                        |]

                    f 'u'
                        [|
                        "8", uint8
                        "16", uint16
                        "32", uint32
                        "64", uint64
                        |]

                    f 'f'
                        [|
                        "32", float32
                        "64", float64
                        |]
                    (if is_x_integer then default_int x else default_float x) .>> spaces
                    |]

            fun s ->
                let reply = parser s
                if reply.Status = Ok then
                    let nl = reply.Result // the parsed NumberLiteral
                    try 
                        followedBySuffix nl.String nl.IsInteger s
                    with
                    | :? System.OverflowException as e ->
                        s.Skip(-nl.String.Length)
                        Reply(FatalError, messageError e.Message)
                else // reconstruct error reply
                    Reply(reply.Status, reply.Error)

        let quoted_char = 
            let normalChar = satisfy (fun c -> c <> '\\' && c <> ''')
            let unescape c = match c with
                             | 'n' -> '\n'
                             | 'r' -> '\r'
                             | 't' -> '\t'
                             | c   -> c
            let escapedChar = pchar '\\' >>. (anyOf "\\nrt'" |>> unescape)
            let a = (normalChar <|> escapedChar) .>> pchar ''' |>> LitChar
            let b = pstring "''" >>% LitChar '''
            pchar ''' >>. (a <|> b) .>> spaces

        let string_quoted =
            let normalChar = satisfy (fun c -> c <> '\\' && c <> '"')
            let unescape c = match c with
                             | 'n' -> '\n'
                             | 'r' -> '\r'
                             | 't' -> '\t'
                             | c   -> c
            let escapedChar = pchar '\\' >>. (anyOf "\\nrt\"" |>> unescape)
            between (pchar '"') (pchar '"' >>. spaces)
                    (manyChars (normalChar <|> escapedChar))
            |>> LitString

        let satisfy_nonquote = satisfy ((<>) '"')
        let string_raw =
            between (pstring "@\"") (pchar '"' >>. spaces) (manyChars satisfy_nonquote)
            |>> LitString

        let string_raw_triple =
            let str = pstring "\"\"\""
            between str (str >>. spaces) (manyChars satisfy_nonquote)
            |>> LitString

        let lit_ s = 
            choice 
                [|
                pbool
                pnumber
                string_quoted
                string_raw
                string_raw_triple
                quoted_char
                |]
            <| s

        let pat_e = wildcard >>% E
        let pat_var = var_name |>> PatVar
        let pat_tuple pattern = sepBy1 pattern comma |>> function [x] -> x | x -> PatTuple x
        let pat_cons pattern = sepBy1 pattern cons |>> function [x] -> x | x -> PatCons x
        let pat_rounds pattern = rounds (pattern <|>% PatTuple [])
        let pat_type expr pattern = tuple2 pattern (opt (pp >>. ((var_name |>> v) <|> rounds expr))) |>> function a,Some b as x-> PatTypeEq(a,b) | a, None -> a
        let pat_active pattern = 
            let active_pat = choice [active_pat >>% PatActive; part_active_pat >>% PatPartActive; ext_active_pat >>% PatExtActive]
            pipe3 active_pat var_name pattern <| fun c name pat -> c (name,pat)
        let pat_or pattern = sepBy1 pattern bar |>> function [x] -> x | x -> PatOr x
        let pat_and pattern = sepBy1 pattern amphersand |>> function [x] -> x | x -> PatAnd x
        let lit_var = lit_ <|> (var_name_core |>> LitString)
        let pat_type_lit = 
            let literal = lit_var |>> PatTypeLit
            let bind = var_name |>> PatTypeLitBind
            prefix_dot >>. (literal <|> rounds bind)
        let pat_lit = lit_ |>> PatLit
        let pat_when expr pattern = pattern .>>. (opt (when_ >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
        let pat_as pattern = pattern .>>. (opt (as_ >>. pattern )) |>> function a, Some b -> PatAnd [a;b] | a, None -> a

        let pat_named_tuple pattern =
            let pat = pipe2 lit_var (opt (pp >>. pattern)) (fun lit pat ->
                let lit = PatTypeLit lit
                match pat with
                | Some pat -> PatTuple [lit; pat]
                | None -> lit)
            squares (many pat) |>> function [x] -> x | x -> PatTuple x

        let pat_closure pattern = 
            pipe2 pattern (opt (arr >>. pattern))
                (fun a -> function
                    | Some b -> PatTypeClosure(a,b)
                    | None -> a)

        let (^<|) a b = a b // High precedence, right associative <| operator

        let rec pat_module_helper (names,bindings) = 
            match names with
            | [x] -> PatMInnerModule(x,bindings)
            | x :: xs -> PatMInnerModule(x,pat_module_helper (xs,bindings))
            | _ -> failwith "Invalid state"
        
        let rec pat_module_outer expr s = 
            curlies (opt (attempt (sepBy1 var_name dot .>> with_)) .>>. pat_module_body expr)
            |>> function
                | Some (n :: (_ :: _ as ns)), bindings -> PatModule(Some n, pat_module_helper (ns,bindings))
                | Some [n], bindings -> PatModule(Some n,bindings)
                | Some [], _ -> failwith "impossible"
                | None, bindings -> PatModule(None,bindings)
            <| s

        and pat_module_inner expr s = 
            curlies ((sepBy1 var_name dot .>> with_) .>>. pat_module_body expr) 
            |>> pat_module_helper <| s

        and pat_module_body expr s =
            let bind = eq' >>. patterns_template expr
            let pat_bind_fun (v,pat) =
                match pat with
                | Some pat -> 
                    let rec loop = function
                        | PatMName name -> PatMRebind(name,pat)
                        | PatMRebind (name,_) as v  -> PatMAnd [v; PatMRebind(name,pat)]
                        | (PatMInnerModule _ | PatMPattern _) as v -> PatMAnd [v;PatMPattern pat]
                        | PatMAnd l -> PatMAnd <| List.map loop l
                        | PatMOr l -> PatMOr <| List.map loop l
                        | PatMXor l -> PatMXor <| List.map loop l
                        | PatMNot x -> PatMNot (loop x)
                    loop v
                | None -> v
                
            let pat_name = var_name |>> PatMName
            let pat_bind pat = (pat .>>. opt bind |>> pat_bind_fun) 
            let inline pat_template sep con pat = sepBy1 pat sep |>> function [x] -> x | x -> con x
            let pat_not pat = (not_ >>. pat |>> PatMNot) <|> pat
            let pat_xor pat = pat_template caret PatMXor pat
            let pat_or pat = pat_template bar PatMOr pat
            let pat_and pat = many pat |>> PatMAnd
            pat_and ^<| pat_or ^<| pat_xor ^<| pat_not ^<| pat_bind ^<| choice [pat_name; pat_module_inner expr; rounds (pat_module_body expr)] <| s

        and patterns_template expr s = // The order in which the pattern parsers are chained in determines their precedence.
            let inline recurse s = patterns_template expr s
            pat_or ^<| pat_when expr ^<| pat_as ^<| pat_tuple ^<| pat_cons ^<| pat_and ^<| pat_type expr ^<| pat_closure
            ^<| choice [|pat_active recurse; pat_e; pat_var; pat_type_lit; pat_lit 
                         pat_rounds recurse; pat_named_tuple recurse; pat_module_outer expr|] <| s

        let inline patterns expr s = patterns_template expr s
    
        let pattern_list expr = many (patterns expr)
    
        let col (s: CharStream<_>) = s.Column
        let line (s: CharStream<_>) = s.Line

        let set_semicolon_level_to_line line p (s: CharStream<_>) =
            let u = s.UserState
            s.UserState <- { u with semicolon_line=line }
            let r = p s
            s.UserState <- u
            r

        let reset_semicolon_level expr = attempt (set_semicolon_level_to_line -1L expr)

        let inline expr_indent i op expr (s: CharStream<_>) = if op i (col s) then expr s else pzero s
        let if_then_else expr (s: CharStream<_>) =
            let i = (col s)
            let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
            let inline f' str = keywordString str >>. expr
            let inline f str = expr_indent (f' str)
            let if_ = f' "if" |>> fun x -> IfStatic, x
            let if_dynamic = f' "if_dynamic" |>> fun x -> If, x
            pipe4 (if_ <|> if_dynamic) (f "then") (many (f "elif" .>>. f "then")) (opt (f "else"))
                (fun (if_op,cond) tr elifs fl -> 
                    let fl = 
                        match fl with Some x -> x | None -> B
                        |> List.foldBack (fun (cond,tr) fl -> op(if_op,[cond;tr;fl])) elifs
                    op(if_op,[cond;tr;fl]))
            <| s

        let poperator (s: CharStream<Userstate>) = many1Satisfy is_operator_char .>> spaces <| s
        let var_op_name = var_name <|> rounds (poperator <|> var_name_core)

        let filter_env x = ap (inl "" x) B
        let inl_pat' (args: Pattern list) body = List.foldBack inl_pat args body
        let inline x_pat' memo args body = 
            let body = memo body
            if List.isEmpty args then filter_env body else body
            |> inl_pat' args
        let meth_pat' args body = x_pat' join_point_entry_method args body
        let type_pat' args body = x_pat' join_point_entry_type args body


        let inline statement_expr expr = eq' >>. expr
        let case_inl_pat_statement expr = pipe2 (inl_ >>. patterns expr) (statement_expr expr) lp
        let case_inl_name_pat_list_statement expr = pipe3 (inl_ >>. var_op_name) (pattern_list expr) (statement_expr expr) (fun name pattern body -> l name (inl_pat' pattern body)) 
        let case_inl_rec_name_pat_list_statement expr = pipe3 (inl_rec >>. var_op_name) (pattern_list expr) (statement_expr expr) (fun name pattern body -> l_rec name (inl_pat' pattern body))
        
        let case_met_pat_statement expr = pipe2 (met_ >>. patterns expr) (statement_expr expr) <| fun pattern body -> lp pattern (filter_env (join_point_entry_method body))
        let case_met_name_pat_list_statement expr = pipe3 (met_ >>. var_op_name) (pattern_list expr) (statement_expr expr) (fun name pattern body -> l name (meth_pat' pattern body))
        let case_met_rec_name_pat_list_statement expr = pipe3 (met_rec >>. var_op_name) (pattern_list expr) (statement_expr expr) <| fun name pattern body -> l_rec name (meth_pat' pattern body)

        let case_type_name_pat_list_statement expressions expr = 
            let type_parse (s: CharStream<_>) = 
                let i = col s
                let expr_indent expr (s: CharStream<_>) = expr_indent i (=) expr s
                many1 (expr_indent expressions) |>> (List.reduce type_union) <| s

            pipe3 (type_' >>. var_op_name) (pattern_list expr) (eq' >>. type_parse) <| fun name pattern body -> 
                l_rec name (type_pat' pattern body)

        let case_open expr = open_ >>. expr |>> module_open
        let case_inm_pat_statement expr = pipe2 (inm_ >>. patterns expr) (eq' >>. expr) inmp
        let case_use_pat_statement expr = pipe2 (use_ >>. patterns expr) (eq' >>. expr) usep
        let case_inn_pat_statement expr = pipe2 (inb_ >>. patterns expr) (eq' >>. expr) inbp

        let statements expressions expr = 
            [case_inl_pat_statement; case_inl_name_pat_list_statement; case_inl_rec_name_pat_list_statement
             case_met_pat_statement; case_met_name_pat_list_statement; case_met_rec_name_pat_list_statement
             case_use_pat_statement; case_inm_pat_statement; case_inn_pat_statement
             case_open; case_type_name_pat_list_statement expressions]
            |> List.map (fun x -> x expr |> attempt)
            |> choice

        let inline expression_expr expr = lam >>. reset_semicolon_level expr
        let case_inl_pat_list_expr expr = pipe2 (inl_ >>. pattern_list expr) (expression_expr expr) inl_pat'
        let case_met_pat_list_expr expr = pipe2 (met_ >>. pattern_list expr) (expression_expr expr) meth_pat'

        let case_lit expr = lit_ |>> lit
        let case_if_then_else expr = if_then_else expr
        let case_rounds expr s = (rounds (reset_semicolon_level expr <|>% B)) s
        let case_var expr = var_op_name |>> v

        let case_typex match_type expr (s: CharStream<_>) =
            let mutable i = None
            let expr_indent op expr (s: CharStream<_>) = expr_indent i.Value op expr s
    
            let clause = 
                let clause_template is_meth = 
                    pipe2 (many1 (patterns expr) .>> lam) expr <| fun pat body ->
                        match pat with
                        | x :: xs -> x, if is_meth then meth_pat' xs body else inl_pat' xs body
                        | _ -> failwith "impossible"

                poperator >>=? function
                    | "|" -> clause_template false
                    | "||" -> clause_template true
                    | _ -> fail "not a pattern matching clause"
                |> expr_indent (<=) 
            
            let set_col (s: CharStream<_>) = i <- Some (col s); Reply(())

            let pat_function l = pattern (PatClauses l)
            let pat_match x l = ap (pat_function l) x

            match match_type with
            | true -> // function
                (function_ >>. set_col >>. many1 clause
                |>> pat_function) s    
            | false -> // match
                pipe2 (match_ >>. expr .>> with_ .>> set_col)
                    (many1 clause)
                    pat_match s

        let case_typeinl expr (s: CharStream<_>) = case_typex true expr s
        let case_typecase expr (s: CharStream<_>) = case_typex false expr s

        let case_lit_lift expr = 
            let var = var_name |>> (LitString >> type_lit_lift)
            let lit = expr |>> type_lit_lift'
            prefix_dot >>. (var <|> lit)

        let case_print_env expr s = 
            let i = col s
            keywordString "print_env" >>. expr_indent i (<=) expr |>> print_env
            <| s

        let case_print_expr expr s = 
            let i = col s
            keywordString "print_expr" >>. expr_indent i (<=) expr |>> print_expr
            <| s
          
        let case_module expr s =
            let mp_binding (n,e) = vv [lit_string n; e]
            let mp_without n = op(ModuleWithout,[lit_string n])
            let mp_create l = op(ModuleCreate,l)
            let mp_with (n,l) = 
                match n with
                | [x] -> op(ModuleWith,v x :: l)
                | x :: xs -> op(ModuleWith,vv (v x :: List.map lit_string xs) :: l)
                | _ -> failwith "impossible"

            let inline parse_binding_with s =
                let i = col s
                let line = s.Line
                var_op_name .>>. opt (eq' >>. expr_indent i (<) (set_semicolon_level_to_line line expr)) 
                |>> function a, None -> mp_binding (a, v a) | a, Some b -> mp_binding (a, b)
                <| s

            let parse_binding_without s = var_op_name |>> mp_without <| s

            let module_create_with s = (parse_binding_with .>> optional semicolon') s
            let module_create_without s = (parse_binding_without .>> optional semicolon') s

            let module_with = 
                let withs s = (with_ >>. many1 module_create_with) s
                let withouts s = (without >>. many1 module_create_without) s 
                pipe2 (sepBy1 var_name dot) (many1 (withs <|> withouts))
                <| fun names l -> mp_with (names,List.concat l)

            let module_create = many module_create_with |>> mp_create
                
            curlies (attempt module_with <|> module_create) <| s

        let case_type expr = type_' >>. rounds expr |>> type_get // rounds are needed to avoid collisions with the statement parser

        let case_named_tuple expr =
            let pat s = 
                let i = col s
                let line = line s
                pipe2 lit_var (opt (pp >>. expr_indent i (<) (set_semicolon_level_to_line line expr))) (fun lit expr ->
                    let tup = type_lit_lift lit
                    match expr with
                    | Some expr -> vv [tup; expr]
                    | None -> tup
                    ) s
            squares (many (pat .>> optional semicolon')) |>> function [x] -> x | x -> vv x

        let case_negate expr = unary_minus_check >>. expr |>> (ap (v "negate"))
        let case_join_point expr = keywordString "join" >>. expr |>> join_point_entry_method
        let case_cuda expr = keywordString "cuda" >>. expr |>> inl' ["threadIdx"; "blockIdx"; "blockDim";"gridDim"]

        let case_inbuilt_op expr =
            (operatorChar '!' >>. var_name) .>>. (rounds (expr <|>% B))
            >>= fun (a, b) ->
                let rec loop = function
                    | ExprPos x -> loop x.Expression
                    | VV (N l) -> l 
                    | x -> [x]
                match string_to_op a with
                | true, op' -> op(op',loop b) |> preturn
                | false, _ -> failFatally <| sprintf "%s not found among the inbuilt Ops." a

        let rec expressions expr s =
            let unary_ops = 
                [case_lit_lift; case_negate]
                |> List.map (fun x -> x (expressions expr) |> attempt)
                |> choice
            let expressions = 
                [case_print_env; case_print_expr; case_type; case_join_point; case_cuda; case_inbuilt_op
                 case_inl_pat_list_expr; case_met_pat_list_expr; case_lit; case_if_then_else
                 case_rounds; case_typecase; case_typeinl; case_var; case_module; case_named_tuple]
                |> List.map (fun x -> x expr |> attempt)
                |> choice
            expressions <|> unary_ops <| s
 
        let process_parser_exprs exprs = 
            let error_statement_in_last_pos _ = Reply(Error,messageError "Statements not allowed in the last position of a block.")
            let rec process_parser_exprs on_succ = function
                | [ParserExpr (p,a)] -> on_succ (expr_pos p a)
                | [ParserStatement _] -> error_statement_in_last_pos
                | ParserStatement (p,a) :: xs -> process_parser_exprs (expr_pos p >> a >> on_succ) xs
                | ParserExpr (p,a) :: xs -> process_parser_exprs (l "" (error_non_unit (expr_pos p a)) >> on_succ) xs
                | [] -> preturn B
            
            process_parser_exprs preturn exprs

        let indentations statements expressions (s: CharStream<Userstate>) =
            let i = col s
            let pos' s = Reply(pos' s)
            let inline if_ op tr s = expr_indent i op tr s
            let inline many_indents expr = many1 (if_ (<=) (expr .>> optional semicolon))
            many_indents ((tuple2 pos' statements |>> ParserStatement) <|> (tuple2 pos' expressions |>> ParserExpr)) >>= process_parser_exprs <| s

        let application expr (s: CharStream<_>) =
            let i = (col s)
            let expr_up (s: CharStream<_>) = expr_indent i (<) expr s
    
            pipe2 expr (many expr_up) (List.fold ap) s

        let tuple expr (s: CharStream<_>) =
            let i = (col s)
            let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
            sepBy1 (expr_indent expr) (expr_indent comma)
            |>> function [x] -> x | x -> vv x
            <| s

        let mset statements expressions (s: CharStream<_>) = 
            let i = col s
            let line = s.Line
            let expr_indent expr (s: CharStream<_>) = expr_indent i (<) expr s
            let op =
                (set_ref >>% fun l r -> op(MutableSet,[l;B;r]) |> preturn)
                <|> (set_array >>% fun l r -> 
                        let rec loop = function
                            | ExprPos p -> loop p.Expression
                            | Op(N(Apply,[a;b])) -> op(MutableSet,[a;b;r]) |> preturn
                            | _ -> fail "Expected two arguments on the left of <-."
                        loop l)

            (tuple2 expressions (opt (expr_indent op .>>. expr_indent (set_semicolon_level_to_line line statements)))
            >>= function 
                | a,Some(f,b) -> f a b
                | a,None -> preturn a) s

        let annotations expr (s: CharStream<_>) = 
            let i = (col s)
            let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
            pipe2 (expr_indent expr) (opt (expr_indent pp >>. expr_indent expr))
                (fun a -> function
                    | Some b -> op(TypeAnnot,[a;b])
                    | None -> a) s

        let inbuilt_operators =
            let dict_operator = d0()
            let add_infix_operator assoc str prec = dict_operator.Add(str, (prec, assoc))

            let left_assoc_ops = 
                let f = add_infix_operator Associativity.Left
                f "+" 60; f "-" 60; f "*" 70; f "/" 70; f "%" 70
                f "<|" 10; f "|>" 10; f "<<" 10; f ">>" 10

                let f str = add_infix_operator Associativity.None str 40
                f "<="; f "<"; f "="; f ">"; f ">="; f "<>"
                f "<<<"; f ">>>"; f "&&&"; f "|||"

            let right_associative_ops =
                let f str prec = add_infix_operator Associativity.Right str prec
                f "||" 20; f "&&" 30; f "::" 50; f "^^^" 45
                f "=>" 0; f "\/" -10
                f ":>" 35; f ":?>" 35
         
            dict_operator

        let operators expr (s: CharStream<_>) =
            let poperator (s: CharStream<Userstate>) =
                let dict_operator = s.UserState.ops
                let p = pos' s
                (poperator >>=? function
                    | "->" | ":=" | "<-" -> fail "forbidden operator"
                    | orig_op -> 
                        let rec calculate on_fail op' = 
                            match dict_operator.TryGetValue op' with
                            | true, (prec,asoc) -> preturn (prec,asoc,fun a b -> 
                                match orig_op with
                                | "||" -> expr_pos p (op(Or, [a; b]))
                                | "&&" -> expr_pos p (op(And, [a; b]))
                                | _ -> expr_pos p (ap' (v orig_op) [a; b]))
                            | false, _ -> on_fail ()

                        let on_fail () =
                            let x = orig_op.TrimStart [|'.'|]
                            let rec on_fail i () = 
                                if i >= 0 then calculate (on_fail (i-1)) x.[0..i] 
                                else fail "unknown operator"
                            calculate (on_fail (x.Length-1)) x

                        calculate on_fail orig_op) s

            let i = (col s)
            let inline expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
            let inline poperator s = expr_indent poperator s
            let inline term s = expr_indent expr s

            let rec led left (prec,asoc,m) =
                match asoc with
                | Associativity.Left | Associativity.None -> tdop prec |>> m left
                | Associativity.Right -> tdop (prec-1) |>> m left
                | _ -> failwith "impossible"

            and tdop rbp =
                let rec loop left = 
                    attempt (poperator >>= fun (prec,asoc,m as v) ->
                        if rbp < prec then led left v >>= loop
                        else pzero) <|>% left
                term >>= loop

            tdop Int32.MinValue s

        let rec expr s = 
            let expressions s = mset expr ^<| tuple ^<| operators ^<| application ^<| expressions expr <| s
            let statements s = statements expressions expr <| s
            annotations ^<| indentations statements expressions <| s
        runParserOnString (spaces >>. expr .>> eof) {ops=inbuilt_operators; semicolon_line= -1L} module_name module_code

    // #Codegen
    let process_statements statements =
        let process_statement (code: StringBuilder,ind as state) statement =
            match statement with
            | Statement(sep, x) -> [|String.replicate ind " "; x; sep|] |> String.concat "" |> code.Append, ind
            | Indent -> code, ind+4
            | Dedent -> code, ind-4
        Seq.fold process_statement (StringBuilder(),0) statements
        |> fun (code,ind) -> code.ToString()

    let sep_c = ";\n"
    let sep_new = "\n"
    let state_c (buffer_temp: ResizeArray<_>) x = buffer_temp.Add <| Statement(sep_c,x)
    let state_new (buffer_temp: ResizeArray<_>) x = buffer_temp.Add <| Statement(sep_new,x)
    let enter' (buffer_temp: ResizeArray<_>) f = buffer_temp.Add Indent; f(); buffer_temp.Add Dedent
    let enter state buffer_temp f = 
        enter' buffer_temp <| fun _ -> 
            match f() with
            | "" -> ()
            | s -> state buffer_temp s

    let (|Unit|_|) x = if is_unit x then Some () else None

    let print_tag_tuple' t = sprintf "Tuple%i" t
    let print_tag_union' t = sprintf "Union%i" t
    let print_tag_env' t = sprintf "Env%i" t
    let print_tag_env_stack' t = sprintf "EnvStack%i" t
    let print_tag_env_packed_stack' t = sprintf "EnvPackedStack%i" t
    let sep_comma = ", "

    let inline print_args print_tyv args = 
        (args, (StringBuilder(),null)) ||> List.foldBack (fun (_,ty as x) (bldr,sep as state) ->
            if is_unit ty = false then 
                let f (x: string) = bldr.Append x |> ignore
                f sep; f (print_tyv x)
                bldr,sep_comma
            else state)
        |> fun (a,_) -> a.ToString()

    let inline make_struct codegen l on_empty on_rest =
        Seq.choose (fun x -> let x = codegen x in if x = "" then None else Some x) l
        |> String.concat ", "
        |> function
            | "" -> on_empty
            | x -> on_rest x

    let print_tyv (tag,ty) = sprintf "var_%i" tag

    let inline if_not_unit ty f = if is_unit ty then "" else f()
    let inline def_enqueue (definitions_set: HashSet<_>) (definitions_queue: Queue<_>) (sym_dict: Dictionary<_,_>) f t =
        if definitions_set.Add (TomType t) then definitions_queue.Enqueue (TomType t)

        match sym_dict.TryGetValue t with
        | true, v -> v
        | false, _ ->
            let v = sym_dict.Count
            sym_dict.[t] <- v
            v
        |> f

    let move_to (buffer: ResizeArray<_>) (temp: ResizeArray<_>) = buffer.AddRange(temp); temp.Clear()
    let define_mem (l,i as s) t =
        if is_unit t then s
        else (sprintf "mem_%i" i, t) :: l, i+1

    let inline define_listt ty print_tag_tuple print_type_definition tys =
        if is_unit_tuple tys = false then
            let name = print_tag_tuple ty
            let tys = List.fold define_mem ([],0) tys |> fst |> List.rev
            print_type_definition None name tys

    let inline define_mapt ty print_tag_env print_type_definition tys =
        if Map.forall (fun _ -> is_unit) tys = false then
            let name = print_tag_env None ty
            let tys = Map.fold (fun s _ t -> define_mem s t) ([],0) tys |> fst |> List.rev
            print_type_definition None name tys

    let inline define_layoutt ty print_tag_env print_type_definition layout (C env) =
        if Map.forall (fun _ -> get_type >> is_unit) env = false then
            let name = print_tag_env (Some layout) ty
            let {call_args=fv},_ = renamer_apply_env (Env env)
            let tys = List.foldBack (fun (_,x) s -> define_mem s x) fv ([],0) |> fst |> List.rev
            print_type_definition (Some layout) name tys

    let inline codegen_macro codegen print_type x = 
        let strb = StringBuilder()
        let inline append (x: string) = strb.Append x |> ignore
        let f = function
            | TyList [TypeString "text"; (TypeString x | TyLit (LitString x))] -> append x
            | TyList [TypeString "arg"; (TyV _ | TyT _ as x)] -> append (codegen x)
            | TyList [TypeString "args"; (TyTuple l)] -> append "("; List.map codegen l |> String.concat ", " |> append; append ")"
            | TyList [TypeString "type"; (TyV (_,x) | TyT x)] -> append (print_type x)
            | TyList [TypeString "types"; (TyTuple l)] -> append "<"; List.map (get_type >> print_type) l |> String.concat ", " |> append; append ">" 
            | x -> failwithf "Unknown argument in macro. Got: %A" x
        match x with
        | TyList (TyList _ :: _ as x) -> List.iter f x
        | x -> f x
        strb.ToString()

    // #Cuda
    let spiral_cuda_codegen (definitions_queue: Queue<TypeOrMethod>) = 
        let buffer_forward_declarations = ResizeArray()
        let buffer_type_definitions = Stack()
        let buffer_method = ResizeArray()
        let buffer_temp = ResizeArray()

        let state x = state_c buffer_temp x
        let enter' x = enter' buffer_temp x
        let enter x = enter state_c buffer_temp x
        let state_new x = state_new buffer_temp x

        let sym_dict = d0()
        let definitions_set = h0()
        definitions_queue |> Seq.iter (definitions_set.Add >> ignore)

        let inline def_enqueue x = def_enqueue definitions_set definitions_queue sym_dict x

        let print_tag_tuple t = def_enqueue print_tag_tuple' t
        let print_tag_union t = def_enqueue print_tag_union' t
        let print_case_union x i = [|print_tag_union x;"Case";string i|] |> String.concat null

        let print_tag_env layout t =
            match layout with
            | None -> def_enqueue print_tag_env' t
            | Some LayoutStack -> def_enqueue print_tag_env_stack' t
            | Some LayoutPackedStack -> def_enqueue print_tag_env_packed_stack' t
            | _ -> failwith "impossible"

        let print_tag_closure' t = sprintf "FunPointer%i" t // Not actual closures. They are only function pointers on the Cuda side.
        let print_tag_closure t = def_enqueue print_tag_closure' t

        let rec print_type = function
            | Unit -> "void"
            | MapT _ as x -> print_tag_env None x
            | LayoutT ((LayoutStack | LayoutPackedStack) as layout, _, _) as x -> print_tag_env (Some layout) x
            | ListT _ as x -> print_tag_tuple x
            | UnionT _ as x -> print_tag_union x
            | ArrayT((ArtCudaLocal | ArtCudaShared | ArtCudaGlobal _),t) -> sprintf "%s *" (print_type t)
            | ArrayT _ -> failwith "Not implemented."
            | LayoutT (_, _, _) | RecT _ | DotNetTypeT _ as x -> failwithf "%A is not supported on the Cuda side." x
            | TermFunctionT _ as t -> print_tag_closure t
            | PrimT x ->
                match x with
                | UInt8T -> "unsigned char"
                | UInt16T -> "unsigned short"
                | UInt32T -> "unsigned int"
                | UInt64T -> "unsigned long long int"
                | Int8T -> "char"
                | Int16T -> "short"
                | Int32T -> "int"
                | Int64T -> "long long int"
                | Float32T -> "float"
                | Float64T -> "double"
                | BoolT -> "char"
                | CharT -> "unsigned short"
                | StringT -> failwith "The string type is not supported on the Cuda side."
            | LitT _ -> 
                failwith "Should be covered in Unit."

        and print_tyv_with_type (tag,ty as v) = sprintf "%s %s" (print_type ty) (print_tyv v)
        and print_args' print_tyv x = print_args print_tyv x
        let rec codegen' ({branch_return=branch_return; trace=trace} as d) expr =
            let inline codegen expr = codegen' {d with branch_return=id} expr

            let inline print_method_definition_args x = print_args' print_tyv_with_type x
            let inline print_join_point_args x = 
                let print_with_error_checking x = print_type (snd x) |> ignore; print_tyv x
                print_args' print_with_error_checking x

            let print_value = function
                | LitUInt8 x -> string x 
                | LitUInt16 x -> string x 
                | LitUInt32 x -> string x 
                | LitUInt64 x -> string x 
                | LitInt8 x -> string x
                | LitInt16 x -> string x
                | LitInt32 x -> string x
                | LitInt64 x -> string x
                | LitFloat32 x -> string x
                | LitFloat64 x -> string x
                | LitBool x -> if x then "1" else "0"
                | LitChar x -> string (int x)
                | LitString x -> on_type_er trace "String literals are not supported on the Cuda side."

            let assign_to tyv = function
                | "" as x -> x
                | x -> sprintf "%s = %s" tyv x

            let inline if_ codegen' cond tr fl =
                sprintf "if (%s) {" (codegen cond) |> state_new
                enter <| fun _ -> codegen' tr
                "} else {" |> state_new
                enter <| fun _ -> codegen' fl
                "}" |> state_new

            let match_with codegen' v cases =
                let print_case =
                    match get_type v with
                    | UnionT _ as x -> print_case_union x
                    | _ -> failwith "Only UnionT can be a type of a match case on the Cuda side."

                let v = codegen v
                let rec loop i = function
                    | case :: body :: rest ->
                        sprintf "case %i : {" i |> state_new
                        enter' <| fun _ ->
                            let case_ty = get_type case
                            if is_unit case_ty = false then sprintf "%s %s = %s.data.%s" (print_type case_ty) (codegen case) v (print_case i) |> state
                            codegen' body |> state
                            "break" |> state
                        "}" |> state_new
                        loop (i+1) rest
                    | [] -> ()
                    | _ -> failwith "The cases should always be in pairs."

                sprintf "switch (%s.tag) {" v |> state_new
                enter' <| fun _ -> loop 0 cases
                "}" |> state_new

            let make_struct x = make_struct codegen x

            let unsafe_convert tot from =
                let conv_func = 
                    match tot with
                    | PrimT UInt8T -> "unsigned char"
                    | PrimT UInt16T -> "unsigned short"
                    | PrimT UInt32T -> "unsigned int"
                    | PrimT UInt64T -> "unsigned long long int"
                    | PrimT Int8T -> "char"
                    | PrimT Int16T -> "short"
                    | PrimT Int32T -> "int"
                    | PrimT Int64T -> "long long int"
                    | PrimT Float32T -> "float"
                    | PrimT Float64T -> "double"
                    | PrimT CharT -> on_type_er trace "Conversion to char is not supported on the Cuda side."
                    | _ -> failwith "impossible"
                sprintf "((%s) (%s))" conv_func (codegen from)

            let inline print_scope tyv f =
                print_tyv_with_type tyv |> state
                f (codegen' {d with branch_return = assign_to (print_tyv tyv)})

            try
                match expr with
                | TyT Unit | TyV (_, Unit) -> ""
                | TyT t -> on_type_er trace <| sprintf "Usage of naked type %A as an instance on the term level is invalid." t
                | TyV v -> print_tyv v |> branch_return
                | TyLet(tyv,b,TyV tyv',_,trace) when tyv = tyv' -> codegen' {d with trace=trace} b
                | TyState(b,rest,_,trace) ->
                    let d' = {d with branch_return=id; trace=trace}
                    match b with
                    | TyOp(MutableSet,[ar;idx;b],_) ->
                        match get_type ar with
                        | ArrayT((ArtCudaLocal | ArtCudaShared | ArtCudaGlobal _),_) -> 
                            sprintf "%s[%s] = %s" (codegen' d' ar) (codegen' d' idx) (codegen' d' b) |> state
                        | _ -> failwith "impossible"
                    | _ ->
                        let b = codegen' d' b
                        if b <> "" then sprintf "%s" b |> state
                    codegen' {d with trace=trace} rest
                | TyLet(tyv,TyOp(If,[cond;tr;fl],t),rest,_,trace) -> 
                    print_scope tyv if_ cond tr fl
                    codegen' {d with trace=trace} rest
                | TyLet(tyv,TyOp(Case,v :: cases,t),rest,_,trace) -> 
                    print_scope tyv match_with v cases
                    codegen' {d with trace=trace} rest
                | TyLet(tyv & (tag,_),b,rest,_,trace) -> 
                    let _ = 
                        let d = {d with branch_return=id; trace=trace}
                        match b with
                        | TyOp(ArrayCreate,[a],t) -> sprintf "%s[%s]" (print_tyv_with_type (tag,t)) (codegen' d a)
                        | _ -> sprintf "%s = %s" (print_tyv_with_type tyv) (codegen' d b) 
                        |> state 
                    codegen' {d with trace=trace} rest
                | TyLit x -> print_value x |> branch_return
                | TyJoinPoint(S tag & key,join_point_type,call_args,_) ->
                    let method_name = print_method tag
                    let tomjp = TomJP (join_point_type,key)
                    if definitions_set.Add tomjp then definitions_queue.Enqueue tomjp
                    match join_point_type with
                    | JoinPointType -> failwith "Should never be printed."
                    | JoinPointCuda -> // This join point is just a placeholder.
                        "// Cuda join point" |> state
                        sprintf "// %s(%s)" method_name (print_join_point_args call_args) |> state
                        ""
                    | JoinPointMethod -> 
                        sprintf "%s(%s)" method_name (print_join_point_args call_args) |> branch_return
                    | JoinPointClosure ->
                        if List.isEmpty call_args then branch_return method_name 
                        else on_type_er trace "The closure should not have free variables on the Cuda side."
                | TyBox(x, t) -> 
                    let case_name =
                        let union_idx s = Seq.findIndex ((=) (get_type x)) s
                        match t with
                        | UnionT s -> "make_" + print_case_union t (union_idx s)
                        | _ -> failwith "Only UnionT can be a boxed type."
                    if is_unit (get_type x) then sprintf "(%s())" case_name else sprintf "(%s(%s))" case_name (codegen x)
                | TyMap(C env_term, _) ->
                    let t = get_type expr
                    Map.toArray env_term
                    |> Array.map snd
                    |> fun x -> make_struct x "" (fun args -> sprintf "(make_%s(%s))" (print_tag_env None t) args)
                    |> branch_return
                | TyList l -> let t = get_type expr in make_struct l "" (fun args -> sprintf "make_%s(%s)" (print_tag_tuple t) args) |> branch_return
                | TyOp(op,args,t) ->
                    match op, args with
                    | Apply,[a;b] ->
                        // Apply during codegen is only used for applying closures.
                        // There is one level of flattening in the outer arguments.
                        // The reason for this is the symmetry between the F# and the Cuda side.
                        let b = tuple_field b |> List.map codegen |> String.concat ", "
                        sprintf "%s(%s)" (codegen a) b
                    | Case, v :: cases -> match_with (codegen' d) v cases; ""
                    | If,[cond;tr;fl] -> if_ (codegen' d) cond tr fl; ""
                    | ArrayCreate,[a] -> failwith "ArrayCreate should be done in a let statement on the Cuda side."
                    | ArrayIndex,[ar & TyType(ArrayT((ArtCudaLocal | ArtCudaShared | ArtCudaGlobal _),_));idx] -> sprintf "%s[%s]" (codegen ar) (codegen idx)
                    | ArrayLength,[a] -> on_type_er trace "The ArrayLlength operation is invalid on the Cuda side as the array is just a pointer."
                    | UnsafeConvert,[_;from] -> unsafe_convert t from

                    // Primitive operations on expressions.
                    | Add,[a;b] -> sprintf "(%s + %s)" (codegen a) (codegen b)
                    | Sub,[a;b] -> sprintf "(%s - %s)" (codegen a) (codegen b)
                    | Mult,[a;b] -> sprintf "(%s * %s)" (codegen a) (codegen b)
                    | Div,[a;b] -> sprintf "(%s / %s)" (codegen a) (codegen b)
                    | Mod,[a;b] -> sprintf "(%s %% %s)" (codegen a) (codegen b)
                    | LT,[a;b] -> sprintf "(%s < %s)" (codegen a) (codegen b)
                    | LTE,[a;b] -> sprintf "(%s <= %s)" (codegen a) (codegen b)
                    | EQ,[a;b] -> sprintf "(%s == %s)" (codegen a) (codegen b)
                    | NEQ,[a;b] -> sprintf "(%s != %s)" (codegen a) (codegen b)
                    | GT,[a;b] -> sprintf "(%s > %s)" (codegen a) (codegen b)
                    | GTE,[a;b] -> sprintf "(%s >= %s)" (codegen a) (codegen b)
                    | And,[a;b] -> sprintf "(%s && %s)" (codegen a) (codegen b)
                    | Or,[a;b] -> sprintf "(%s || %s)" (codegen a) (codegen b)
                    | BitwiseAnd,[a;b] -> sprintf "(%s & %s)" (codegen a) (codegen b)
                    | BitwiseOr,[a;b] -> sprintf "(%s | %s)" (codegen a) (codegen b)
                    | BitwiseXor,[a;b] -> sprintf "(%s ^ %s)" (codegen a) (codegen b)

                    | ShiftLeft,[x;y] -> sprintf "(%s << %s)" (codegen x) (codegen y)
                    | ShiftRight,[x;y] -> sprintf "(%s >> %s)" (codegen x) (codegen y)

                    | Neg,[a] -> sprintf "(-%s)" (codegen a)
                    | ListIndex,[a;TyLit(LitInt64 b)] -> if_not_unit t <| fun _ -> sprintf "%s.mem_%i" (codegen a) b
                    | MapGetField, [r; TyV (i,_)] -> if_not_unit t <| fun _ -> sprintf "%s.mem_%i" (codegen r) i
                    | (LayoutToStack | LayoutToPackedStack | LayoutToHeap | LayoutToHeapMutable),[a] ->
                        let {call_args=fv},_ = renamer_apply_typedexpr a
                        match op with
                        | LayoutToStack | LayoutToPackedStack ->
                            let args = Seq.map print_tyv fv |> String.concat ", "
                            sprintf "make_%s(%s)" (print_tag_env (layout_from_op op |> Some) t) args
                        | LayoutToHeap | LayoutToHeapMutable -> on_type_er trace "Heapify is unsupported on the Cuda side."
                        | _ -> failwith "impossible"
                    | Log,[x] -> sprintf "log(%s)" (codegen x)
                    | Exp,[x] -> sprintf "exp(%s)" (codegen x)
                    | Tanh,[x] -> sprintf "tanh(%s)" (codegen x)
                    | FailWith,[x] -> on_type_er trace "Exceptions and hence failwith are not supported on the Cuda side."

                    | MacroCuda,[a] -> codegen_macro codegen print_type a
                    | SizeOf,[TyType a] -> sprintf "(sizeof %s)" (print_type a)

                    | x -> failwithf "Missing TyOp case. %A" x
                    |> branch_return
            with 
            | :? TypeError -> reraise()
            | e -> on_type_er trace e.Message

        let print_closure_type_definition name (a,r) =
            let ret_ty = print_type r
            let ty = tuple_field_ty a |> List.map print_type |> String.concat ", "
            sprintf "typedef %s(*%s)(%s)" ret_ty name ty |> state

        let print_union_definition name tys =
            sprintf "struct %s {" name |> state_new
            enter' <| fun _ ->
                "int tag" |> state
                "union {" |> state_new
                enter' <| fun _ ->
                    Array.iteri (fun i t -> 
                        if is_unit t = false then
                            sprintf "%s %sCase%i" (print_type t) name i |> state
                        ) tys
                "} data" |> state
            "}" |> state

            Array.iteri (fun i t ->
                let is_unit_false = is_unit t = false
                let case_name = sprintf "%sCase%i" name i
                if is_unit_false then sprintf "__device__ __forceinline__ %s make_%s(%s v) {" name case_name (print_type t) |> state_new
                else sprintf "__device__ __forceinline__  %s make_%s() {" name case_name |> state_new
                enter' <| fun _ ->
                    sprintf "%s t" name |> state
                    sprintf "t.tag = %i" i |> state
                    if is_unit_false then sprintf "t.data.%s = v" case_name |> state
                    "return t" |> state
                "}" |> state_new
                ) tys

        let print_type_definition layout name tys =
            match layout with
            | Some LayoutPackedStack -> "#pragma pack(1)" |> state
            | _ -> ()

            let args =
                List.map (fun (name,ty) ->
                    sprintf "%s %s" (print_type ty) name
                    ) tys

            sprintf "struct %s {" name |> state_new
            enter' <| fun _ -> List.iter state args
            "}" |> state

            sprintf "__device__ __forceinline__ %s make_%s(%s){" name name (String.concat ", " args) |> state_new
            enter' <| fun _ ->
                sprintf "%s tmp" name |> state
                List.iter (fun (x,_) -> sprintf "tmp.%s = %s" x x |> state) tys
                "return tmp" |> state
            "}" |> state_new

        let print_method_definition is_forward_declaration tag (join_point_type, fv, body) =
            let method_name = print_method tag

            let method_return = function
                | "" as x -> x
                | x -> sprintf "return %s" x
            let print_body() = enter <| fun _ -> codegen' {branch_return=method_return; trace=[]} body
            let print_method prefix =
                let args = print_args' print_tyv_with_type fv
                if is_forward_declaration then
                    sprintf "%s %s %s(%s)" prefix (print_type (get_type body)) method_name args |> state
                else
                    sprintf "%s %s %s(%s) {" prefix (print_type (get_type body)) method_name args |> state_new
                    print_body()
                    "}" |> state_new

            match join_point_type with
            | JoinPointClosure | JoinPointMethod -> print_method "__device__"
            | JoinPointCuda -> print_method "__global__"
            | JoinPointType -> ()
            
        while definitions_queue.Count > 0 do
            match definitions_queue.Dequeue() with
            | TomJP (join_point_type,key) ->
                let fv,body =
                    match join_point_type with
                    | JoinPointMethod -> 
                        match join_point_dict_method.[key] with
                        | JoinPointDone(a,b) -> a,b
                        | _ -> failwith "impossible"
                    | JoinPointClosure -> 
                        match join_point_dict_closure.[key] with
                        | JoinPointDone(_,a,b) -> a,b
                        | _ -> failwith "impossible"
                    | JoinPointCuda -> 
                        match join_point_dict_cuda.[key] with
                        | JoinPointDone(a,b) -> a,b
                        | _ -> failwith "impossible"
                    | JoinPointType -> failwith "impossible"

                print_method_definition true key.Symbol (join_point_type, fv, body)
                move_to buffer_forward_declarations buffer_temp

                print_method_definition false key.Symbol (join_point_type, fv, body)
                move_to buffer_method buffer_temp
            | TomType ty ->
                match ty with
                | ListT tys -> define_listt ty print_tag_tuple print_type_definition tys
                | MapT(tys, _) -> define_mapt ty print_tag_env print_type_definition tys
                | LayoutT ((LayoutStack | LayoutPackedStack) as layout, env, _) ->
                    define_layoutt ty print_tag_env print_type_definition layout env
                | UnionT tys as x -> print_union_definition (print_tag_union x) (Set.toArray tys)
                | TermFunctionT(a,r) as x -> print_closure_type_definition (print_tag_closure x) (a,r)
                | _ -> failwith "impossible"
                
                buffer_type_definitions.Push(ResizeArray(buffer_temp))
                buffer_temp.Clear()

        "module SpiralExample.Main" |> state_new
        sprintf "let %s = \"\"\"" cuda_kernels_name |> state_new
        "extern \"C\" {" |> state_new
        enter' <| fun _ ->
            while buffer_type_definitions.Count > 0 do move_to buffer_temp (buffer_type_definitions.Pop())
            move_to buffer_temp buffer_forward_declarations
            state_new ""
            move_to buffer_temp buffer_method
        "}" |> state_new
        "\"\"\"" |> state_new

        buffer_temp |> process_statements

    // #F#
    let spiral_fsharp_codegen main =
        let buffer_type_definitions = ResizeArray()
        let buffer_method = ResizeArray()
        let buffer_main = ResizeArray()
        let buffer_temp = ResizeArray()

        let state x = state_new buffer_temp x
        let enter' x = enter' buffer_temp x
        let enter x = enter state_new buffer_temp x

        let sym_dict = d0()
        let definitions_set = h0()
        let definitions_queue = Queue<TypeOrMethod>()

        let print_tag_rec' t = sprintf "Rec%i" t
        let print_tag_env_heap' t = sprintf "EnvHeap%i" t
        let print_tag_env_heap_mutable' t = sprintf "EnvHeapMutable%i" t

        let inline def_enqueue x = def_enqueue definitions_set definitions_queue sym_dict x

        let print_tag_tuple t = def_enqueue print_tag_tuple' t
        let print_tag_union t = def_enqueue print_tag_union' t
        let print_tag_rec t = def_enqueue print_tag_rec' t
        let print_tag_env layout t = 
            match layout with
            | None -> def_enqueue print_tag_env' t
            | Some LayoutStack -> def_enqueue print_tag_env_stack' t
            | Some LayoutPackedStack -> def_enqueue print_tag_env_packed_stack' t
            | Some LayoutHeap -> def_enqueue print_tag_env_heap' t
            | Some LayoutHeapMutable -> def_enqueue print_tag_env_heap_mutable' t

        let rec print_type = function
            | Unit -> "unit"
            | MapT _ as x -> print_tag_env None x
            | LayoutT (layout, _, _) as x -> print_tag_env (Some layout) x
            | ListT _ as x -> print_tag_tuple x
            | UnionT _ as x -> print_tag_union x
            | RecT _ as x -> print_tag_rec x
            | ArrayT(ArtDotNetReference,t) -> sprintf "(%s ref)" (print_type t)
            | ArrayT(ArtDotNetHeap,t) -> sprintf "(%s [])" (print_type t)
            | ArrayT(ArtCudaGlobal t,_) -> print_type t
            | ArrayT((ArtCudaShared | ArtCudaLocal),_) -> failwith "Cuda local and shared arrays cannot be used on the F# side."
            | DotNetTypeT (N t) -> print_dotnet_type t
            | TermFunctionT(a,b) -> 
                let a = tuple_field_ty a |> List.map print_type |> String.concat " * "
                sprintf "(%s -> %s)" a (print_type b)
            | PrimT x ->
                match x with
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
            | LitT _ -> 
                failwith "Should be covered in Unit."
                

        and print_dotnet_type x =
            let print_class (x: SSTypedExprClass) =
                if x.generic_type_args |> Array.isEmpty then x.full_name
                else sprintf "%s<%s>" x.full_name (Array.map print_type x.generic_type_args |> String.concat ", ")
            match x with
            | SSTyClass x -> print_class x
            | SSTyType x -> print_type x
            | SSTyArray _ | SSTyLam _ -> failwith "SSTyArray and SSTyLam type should never appear in generated code."

        let print_tyv_with_type (tag,ty as v) = sprintf "(%s: %s)" (print_tyv v) (print_type ty)
        let print_args x = print_args print_tyv_with_type x

        let print_case_rec x i = [|print_tag_rec x;"Case";string i|] |> String.concat null
        let print_case_union x i = [|print_tag_union x;"Case";string i|] |> String.concat null

        let inline handle_unit_in_last_position f =
            let c = buffer_temp.Count
            match f () with
            | "" ->
                match Seq.last buffer_temp with
                | Statement (_,s) when s.StartsWith "let " -> "()"
                | _ when c = buffer_temp.Count -> "()"
                | _ -> ""
            | x -> x

        let rec codegen' trace expr =
            let inline codegen expr = codegen' trace expr
            let print_value = function
                | LitInt8 x -> sprintf "%iy" x
                | LitInt16 x -> sprintf "%is" x
                | LitInt32 x -> sprintf "%i" x
                | LitInt64 x -> sprintf "%iL" x
                | LitUInt8 x -> sprintf "%iuy" x
                | LitUInt16 x -> sprintf "%ius" x
                | LitUInt32 x -> sprintf "%iu" x
                | LitUInt64 x -> sprintf "%iUL" x
                | LitFloat32 x -> sprintf "%ff" x
                | LitFloat64 x -> sprintf "%f" x
                | LitString x -> 
                    let strb = StringBuilder(x.Length)
                    String.iter (function
                        | '"' -> strb.Append "\\\"" 
                        | '\t' -> strb.Append "\t"
                        | '\n' -> strb.Append "\n"
                        | '\r' -> strb.Append "\r"
                        | '\\' -> strb.Append "\\\\"
                        | x -> strb.Append x
                        >> ignore 
                        ) x
                    sprintf "\"%s\"" (strb.ToString())
                | LitChar x -> 
                    match x with
                    | '\n' -> @"\n"
                    | '\t' -> @"\t"
                    | '\r' -> @"\r"
                    | x -> string x
                    |> sprintf "'%s'"
                | LitBool x -> if x then "true" else "false"

            let inline print_scope v f = // Unit types are impossible in let statements so no need to check for that.
                sprintf "let %s =" (print_tyv_with_type v) |> state
                enter' <| fun _ -> f()

            let inline if_ cond tr fl =
                let enter f = enter <| fun _ -> handle_unit_in_last_position f
                
                sprintf "if %s then" (codegen cond) |> state
                enter <| fun _ -> codegen tr
                "else" |> state
                enter <| fun _ -> codegen fl

            let make_struct x = make_struct codegen x

            let (|DotNetPrintedArgs|) x = List.map codegen x |> List.filter ((<>) "") |> String.concat ", "

            let array_create size = function
                | ArrayT(_,t) -> sprintf "Array.zeroCreate<%s> (System.Convert.ToInt32(%s))" (print_type t) (codegen size)
                | _ -> failwith "impossible"

            let reference_create x = sprintf "(ref %s)" (codegen x)
            let array_index ar idx = sprintf "%s.[int32 %s]" (codegen ar) (codegen idx)
            let array_length ar = sprintf "%s.LongLength" (codegen ar)
            let reference_index x = sprintf "(!%s)" (codegen x)

            let layout_heap_mutable_set module_ field r = sprintf "%s.%s <- %s" (codegen module_) field (codegen r) |> state
            let array_set ar idx r = sprintf "%s <- %s" (array_index ar idx) (codegen r) |> state
            let reference_set l r = sprintf "%s := %s" (codegen l) (codegen r) |> state

            let string_length str = sprintf "(int64 %s.Length)" (codegen str)
            let string_index str idx = sprintf "%s.[int32 %s]" (codegen str) (codegen idx)
            let string_slice str a b = sprintf "%s.[int32 %s..int32 %s]" (codegen str) (codegen a) (codegen b)

            let match_with v cases =
                let print_case =
                    match get_type v with
                    | RecT _ as x -> print_case_rec x
                    | UnionT _ as x -> print_case_union x
                    | _ -> failwith "impossible"
                
                let rec loop i = function
                    | case :: body :: rest -> 
                        let case = codegen case
                        if String.IsNullOrEmpty case then sprintf "| %s ->" (print_case i) |> state
                        else sprintf "| %s(%s) ->" (print_case i) case |> state
                        enter <| fun _ -> handle_unit_in_last_position (fun _ -> codegen body)
                        loop (i+1) rest
                    | [] -> ()
                    | _ -> failwith "The cases should always be in pairs."

                sprintf "match %s with" (codegen v) |> state
                loop 0 cases

            let unsafe_convert tot from =
                let conv_func = 
                    match tot with
                    | PrimT Int8T -> "int8"
                    | PrimT Int16T -> "int16"
                    | PrimT Int32T -> "int32"
                    | PrimT Int64T -> "int64"
                    | PrimT UInt8T -> "uint8"
                    | PrimT UInt16T -> "uint16"
                    | PrimT UInt32T -> "uint32"
                    | PrimT UInt64T -> "uint64"
                    | PrimT CharT -> "char"
                    | PrimT Float32T -> "float32"
                    | PrimT Float64T -> "float"
                    | _ -> failwith "impossible"
                sprintf "(%s %s)" conv_func (codegen from)

            try
                match expr with
                | TyT Unit | TyV (_, Unit) -> ""
                | TyT t -> on_type_er trace <| sprintf "Usage of naked type %A as an instance on the term level is invalid." t
                | TyV v -> print_tyv v
                | TyLet(tyv,b,TyV tyv',_,trace) when tyv = tyv' -> codegen' trace b
                | TyState(b,rest,_,trace) ->
                    match b with
                    | TyOp(MutableSet,[ar;idx;b],_) ->
                        match get_type ar with
                        | ArrayT(ArtDotNetReference,_) -> reference_set ar b
                        | ArrayT(ArtDotNetHeap,_) -> array_set ar idx b
                        | LayoutT(LayoutHeapMutable,_,_) -> 
                            match idx with
                            | TypeString field -> layout_heap_mutable_set ar field b
                            | _ -> failwith "impossible"
                        | _ -> failwith "impossible"
                    | _ ->
                        let b = codegen' trace b
                        if b <> "" then sprintf "%s" b |> state
                    codegen' trace rest
                | TyLet(tyv,TyOp(If,[cond;tr;fl],t),rest,_,trace) -> print_scope tyv (fun _ -> if_ cond tr fl); codegen' trace rest
                | TyLet(tyv,TyOp(Case,v :: cases,t),rest,_,trace) -> print_scope tyv (fun _ -> match_with v cases); codegen' trace rest
                | TyLet(tyv,b,rest,_,trace) -> sprintf "let %s = %s" (print_tyv_with_type tyv) (codegen' trace b) |> state; codegen' trace rest
                | TyLit x -> print_value x
                | TyJoinPoint(S tag & key,join_point_type,fv,_) ->
                    let method_name = print_method tag
                    let tomjp = TomJP (join_point_type,key)
                    if definitions_set.Add tomjp then definitions_queue.Enqueue tomjp
                
                    match join_point_type with
                    | JoinPointType -> failwith "Should never be printed."
                    | JoinPointMethod -> sprintf "%s(%s)" method_name (print_args fv)
                    | JoinPointCuda -> 
                        "// Cuda join point" |> state
                        sprintf "// %s(%s)" method_name (print_args fv)
                    | JoinPointClosure ->
                        if List.isEmpty fv then method_name
                        else sprintf "%s(%s)" method_name (print_args fv)
                | TyBox(x, t) ->
                    let case_name =
                        let union_idx s = Seq.findIndex ((=) (get_type x)) s
                        match t with
                        | UnionT s -> print_case_union t (union_idx s)
                        | RecT tag -> 
                            match join_point_dict_type.[tag] with
                            | JoinPointDone (UnionT s,_) -> print_case_rec t (union_idx s)
                            | _ -> print_tag_rec t
                        | _ -> failwith "Only RecT and UnionT can be boxed types."
                    if is_unit (get_type x) then case_name else sprintf "(%s(%s))" case_name (codegen x)
                | TyMap(C env_term, _) ->
                    let t = get_type expr
                    Map.toArray env_term
                    |> Array.map snd
                    |> fun x -> make_struct x "" (fun args -> sprintf "(%s(%s))" (print_tag_env None t) args)
                | TyList l -> let t = get_type expr in make_struct l "" (fun args -> sprintf "%s(%s)" (print_tag_tuple t) args)
                | TyOp(op,args,t) ->
                    match op, args with
                    | Apply,[a;b] ->
                        // Apply during codegen is only used for applying closures.
                        // There is one level of flattening in the outer arguments.
                        // The reason for this is the symmetry between the F# and the Cuda side.
                        let b = tuple_field b |> List.map codegen |> String.concat ", "
                        sprintf "%s(%s)" (codegen a) b
                    | Case,v :: cases -> match_with v cases; ""
                    | If,[cond;tr;fl] -> if_ cond tr fl; ""
                    | ArrayCreate,[a] -> array_create a t
                    | ReferenceCreate,[a] -> reference_create a
                    | ArrayIndex,[b & TyType(ArrayT(ArtDotNetHeap,_));c] -> array_index b c
                    | ArrayIndex,[b & TyType(ArrayT(ArtDotNetReference,_));c] -> reference_index b
                    | ArrayLength,[a] -> array_length a
                    | StringIndex,[str;idx] -> string_index str idx
                    | StringSlice,[str;a;b] -> string_slice str a b
                    | StringLength,[str] -> string_length str
                    | UnsafeConvert,[_;from] -> unsafe_convert t from

                    // Primitive operations on expressions.
                    | Add,[a;b] -> sprintf "(%s + %s)" (codegen a) (codegen b)
                    | Sub,[a;b] -> sprintf "(%s - %s)" (codegen a) (codegen b)
                    | Mult,[a;b] -> sprintf "(%s * %s)" (codegen a) (codegen b)
                    | Div,[a;b] -> sprintf "(%s / %s)" (codegen a) (codegen b)
                    | Mod,[a;b] -> sprintf "(%s %% %s)" (codegen a) (codegen b)
                    | LT,[a;b] -> sprintf "(%s < %s)" (codegen a) (codegen b)
                    | LTE,[a;b] -> sprintf "(%s <= %s)" (codegen a) (codegen b)
                    | EQ,[a;b] -> sprintf "(%s = %s)" (codegen a) (codegen b)
                    | NEQ,[a;b] -> sprintf "(%s <> %s)" (codegen a) (codegen b)
                    | GT,[a;b] -> sprintf "(%s > %s)" (codegen a) (codegen b)
                    | GTE,[a;b] -> sprintf "(%s >= %s)" (codegen a) (codegen b)
                    | And,[a;b] -> sprintf "(%s && %s)" (codegen a) (codegen b)
                    | Or,[a;b] -> sprintf "(%s || %s)" (codegen a) (codegen b)
                    | BitwiseAnd,[a;b] -> sprintf "(%s &&& %s)" (codegen a) (codegen b)
                    | BitwiseOr,[a;b] -> sprintf "(%s ||| %s)" (codegen a) (codegen b)
                    | BitwiseXor,[a;b] -> sprintf "(%s ^^^ %s)" (codegen a) (codegen b)

                    | ShiftLeft,[x;y] -> sprintf "(%s <<< %s)" (codegen x) (codegen y)
                    | ShiftRight,[x;y] -> sprintf "(%s >>> %s)" (codegen x) (codegen y)

                    | Neg,[a] -> sprintf "(-%s)" (codegen a)
                    | ListIndex,[a;TyLit(LitInt64 b)] -> if_not_unit t <| fun _ -> sprintf "%s.mem_%i" (codegen a) b
                    | MapGetField, [r; TyV (i,_)] -> if_not_unit t <| fun _ -> sprintf "%s.mem_%i" (codegen r) i
                    | (LayoutToStack | LayoutToPackedStack | LayoutToHeap | LayoutToHeapMutable),[a] ->
                        let {call_args=fv},_ = renamer_apply_typedexpr a
                        match op with
                        | LayoutToStack | LayoutToPackedStack ->
                            let args = List.rev fv |> List.map print_tyv_with_type |> String.concat ", "
                            sprintf "%s(%s)" (print_tag_env (layout_from_op op |> Some) t) args
                        | LayoutToHeap | LayoutToHeapMutable ->
                            let args = List.rev fv |> List.mapi (fun i x -> sprintf "mem_%i = %s" i (print_tyv_with_type x)) |> String.concat "; "
                            sprintf "({%s} : %s)" args (print_tag_env (layout_from_op op |> Some) t)
                        | _ -> failwith "impossible"
                    | Log,[x] -> sprintf "log(%s)" (codegen x)
                    | Exp,[x] -> sprintf "exp(%s)" (codegen x)
                    | Tanh,[x] -> sprintf "tanh(%s)" (codegen x)
                    | FailWith,[x] -> sprintf "(failwith %s)" (codegen x)
                    | DotNetTypeConstruct,[TyTuple (DotNetPrintedArgs args)] as x ->
                        match t with 
                        | DotNetTypeT (N instance_type) -> sprintf "%s(%s)" (print_dotnet_type instance_type) args
                        | _ -> failwith "impossible"
                    | DotNetTypeCallMethod,[v; TyTuple [TypeString method_name; TyTuple (DotNetPrintedArgs method_args)]] ->
                        match v with
                        | TyT _ & TyType (DotNetTypeT (N t)) -> sprintf "%s.%s(%s)" (print_dotnet_type t) method_name method_args
                        | _ -> sprintf "%s.%s(%s)" (codegen v) method_name method_args
                    | DotNetTypeGetField,[v; TypeString name] ->
                        match v with
                        | TyT _ & TyType (DotNetTypeT (N t)) -> sprintf "%s.%s" (print_dotnet_type t) name
                        | _ -> sprintf "%s.%s" (codegen v) name
                    | UnsafeUpcastTo,[a;b] -> sprintf "(%s :> %s)" (codegen b) (print_type (get_type a))
                    | UnsafeDowncastTo,[a;b] -> sprintf "(%s :?> %s)" (codegen b) (print_type (get_type a))
                    | MacroFs,[a] -> codegen_macro codegen print_type a
                    | SizeOf,[TyType a] -> sprintf "(int64 sizeof<%s>)" (print_type a)
                    | x -> failwithf "Missing TyOp case. %A" x
            with 
            | :? TypeError -> reraise()
            | e -> on_type_er trace e.Message

        let type_prefix =
            let mutable type_is_first = true
            fun () -> if type_is_first then type_is_first <- false; "type" else "and"
        let method_prefix =
            let mutable method_is_first = true
            fun () -> if method_is_first then method_is_first <- false; "let rec" else "and"

        let print_union_cases print_case tys =
            enter' <| fun _ ->
                List.iteri (fun i -> function
                    | Unit -> "| " + print_case i |> state
                    | x -> sprintf "| %s of %s" (print_case i) (print_type x) |> state) tys

        let print_type_definition layout name tys =
            match layout with
            | None | Some (LayoutStack | LayoutPackedStack) ->
                match layout with
                | Some LayoutPackedStack -> "[<System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential,Pack=1)>]" |> state
                | _ -> ()
                sprintf "%s %s =" (type_prefix()) name |> state
                enter' <| fun _ -> 
                    "struct" |> state
                    List.iter (fun (name,typ) ->
                        sprintf "val %s: %s" name (print_type typ) |> state
                        ) tys

                    let args_declaration = 
                        List.map(fun (name,typ) -> sprintf "arg_%s" name) tys
                        |> String.concat ", "
                    let args_mapping = 
                        List.map(fun (name,typ) -> sprintf "%s = arg_%s" name name) tys
                        |> String.concat "; "

                    sprintf "new(%s) = {%s}" args_declaration args_mapping |> state
                    "end" |> state
            | Some ((LayoutHeap | LayoutHeapMutable) as layout) ->
                sprintf "%s %s =" (type_prefix()) name |> state
                enter' <| fun _ -> 
                    "{" |> state
                    let inline layout_mem_heap a b = sprintf "%s: %s" a b
                    let inline layout_mem_heap_mutable a b = sprintf "mutable %s: %s" a b
                    let inline layout_mems layout_mem = 
                        List.iter (fun (name,typ) ->
                            layout_mem name (print_type typ) |> state
                            )
                    match layout with
                    | LayoutHeap -> layout_mems layout_mem_heap tys
                    | LayoutHeapMutable -> layout_mems layout_mem_heap_mutable tys
                    | _ -> failwith "impossible"
                    "}" |> state

        codegen' [] main |> state
        move_to buffer_main buffer_temp

        let cuda_join_points = Queue()

        while definitions_queue.Count > 0 do
            match definitions_queue.Dequeue() with
            | TomJP (join_point_type,key) as tom ->
                let method_name = print_method (key.Symbol)
                let print_body body = enter <| fun _ -> handle_unit_in_last_position (fun _ -> codegen' [] body)

                match join_point_type with
                | JoinPointMethod -> 
                    match join_point_dict_method.[key] with
                    | JoinPointDone(fv,body) -> 
                        sprintf "%s %s(%s): %s =" (method_prefix()) method_name (print_args fv) (print_type (get_type body)) |> state
                        print_body body
                        move_to buffer_method buffer_temp
                    | _ -> failwith "impossible"
                | JoinPointClosure -> 
                    match join_point_dict_closure.[key] with
                    | JoinPointDone(capt_pars,img_pars,body) ->
                        if capt_pars.IsEmpty then sprintf "%s %s (%s): %s =" (method_prefix()) method_name (print_args img_pars) (print_type (get_type body)) |> state
                        else sprintf "%s %s (%s) (%s): %s =" (method_prefix()) method_name (print_args capt_pars) (print_args img_pars) (print_type (get_type body)) |> state

                        print_body body
                        move_to buffer_method buffer_temp
                    | _ -> failwith "impossible"
                | JoinPointCuda -> cuda_join_points.Enqueue tom
                | JoinPointType -> failwith "impossible"
            | TomType ty ->
                match ty with
                | ListT tys -> define_listt ty print_tag_tuple print_type_definition tys
                | MapT(tys, _) -> define_mapt ty print_tag_env print_type_definition tys
                | LayoutT(layout, env, _) -> define_layoutt ty print_tag_env print_type_definition layout env
                | RecT key as x ->
                    let tys = 
                        match join_point_dict_type.[key] with
                        | JoinPointDone (tys, _) -> tys
                        | _ -> failwith "impossible"
                    let tag = key.Symbol
                    sprintf "%s %s =" (type_prefix()) (print_tag_rec x) |> state
                    match tys with
                    | Unit -> "| " + print_tag_rec' tag |> state
                    | UnionT tys -> print_union_cases (print_case_rec x) (Set.toList tys)
                    | _ -> sprintf "| %s of %s" (print_tag_rec' tag) (print_type tys) |> state
                | UnionT tys as x ->
                    sprintf "%s %s =" (type_prefix()) (print_tag_union x) |> state
                    print_union_cases (print_case_union x) (Set.toList tys)
                | _ -> failwith "impossible"
                move_to buffer_type_definitions buffer_temp

        spiral_cuda_codegen cuda_join_points |> state

        move_to buffer_temp buffer_type_definitions
        move_to buffer_temp buffer_method
        move_to buffer_temp buffer_main
  
        process_statements buffer_temp

    // #Run
    let print_type_error (trace: Trace) message = 
        let code: Dictionary<Module, ModuleCode []> = d0()
        let error = System.Text.StringBuilder(1024)
        error.AppendLine message |> ignore
        List.foldBack (fun ((file & Module(N(file_name,_,_,file_code))), line, col as trace) prev_trace ->
            let b =
                match prev_trace with
                | Some (prev_file, prev_line, col) when prev_file <> file || prev_line <> line -> true
                | None -> true
                | _ -> false
            if b then
                let er_code =
                    memoize code (fun _ -> file_code.Split [|'\n'|]) file
                    |> fun x -> x.[int line - 1]

                let er_file = if file_name <> "" then sprintf " in file \"%s\"." file_name else file_name
                error.AppendLine <| sprintf "Error trace on line: %i, column: %i%s" line col er_file |> ignore
                error.AppendLine er_code |> ignore
                let col = int (col - 1L)
                for i=1 to col do error.Append(' ') |> ignore
                error.AppendLine "^" |> ignore
            Some trace
            ) trace None
        |> ignore
        error.ToString()

    let data_empty () = {
        ltag = ref 0; seq=ref id; trace=[]; rbeh=AnnotationDive
        env = Env Map.empty
        cse_env = ref Map.empty
        }

    let rec parse_modules (Module(N(_,module_auxes,_,_)) as module_main) on_fail ret =
        let h = h0()

        let inline p x ret =
            match spiral_parse x with
            | Success(r,_,_) -> ret r
            | Failure(er,_,_) -> on_fail er

        let rec loop xs ret =
            match xs with
            | (x & Module(N(name,auxes,_,_))) :: xs ->
                if h.Add x then
                    loop auxes <| fun auxes ->
                        p x <| fun x ->
                            loop xs <| fun xs ->
                                ret (auxes << l name x << xs)
                else loop xs ret
            | [] -> ret id

        p CoreLib.core <| fun core ->
            loop module_auxes <| fun auxes -> 
                p module_main <| fun main -> 
                    ret (module_open core (auxes main))

    let watch = System.Diagnostics.Stopwatch.StartNew()

    parse_modules module_main Fail <| fun body -> 
        printfn "Running %s." module_name
        printfn "Time for parse: %A" watch.Elapsed
        watch.Restart()
        let d = data_empty()
        let input = body |> expr_prepass |> snd
        printfn "Time for prepass: %A" watch.Elapsed
        watch.Restart()
        try
            let x = !d.seq (expr_peval d input)
            printfn "Time for peval was: %A" watch.Elapsed
            watch.Restart()
            let x = Succ (spiral_fsharp_codegen x)
            printfn "Time for codegen was: %A" watch.Elapsed
            x
        with 
        | :? TypeError as e -> 
            let trace, message = e.Data0, e.Data1
            let message = if message.Length > 300 then message.[0..299] + "..." else message
            Fail <| print_type_error trace message
