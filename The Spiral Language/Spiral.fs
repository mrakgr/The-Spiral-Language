module Spiral.Main

// Global open
open System
open System.Collections.Generic
open HashConsing
open Types

// Parser open
open FParsec

// Codegen open
open System.Text

// #Main
let spiral_peval (settings: CompilerSettings) (Module(N(module_name,_,_,_)) as module_main) = 
    let join_point_dict_method = d0()
    let join_point_dict_closure = d0()
    let join_point_dict_type = d0()
    let join_point_dict_cuda = d0()

    // #Smart constructors
    let trace (d: LangEnv) = d.trace

    let ty_join_point key jp_type args ret_type = TyJoinPoint(key,jp_type,args,ret_type)

    let mutable expr_id = -1
    let nodify_expr (dict: Dictionary<_,_>) x =
        match dict.TryGetValue x with
        | true, expr_id -> expr_id
        | false, _ ->
            expr_id <- expr_id+1
            dict.[x] <- expr_id
            expr_id
   
    // nodify_expr variants.
    let nodify_v = nodify_expr <| d0()
    let nodify_open = nodify_expr <| d0()
    let nodify_fix = nodify_expr <| d0()
    let nodify_lit = nodify_expr <| d0()
    let nodify_pattern = nodify_expr <| d0()
    let nodify_func = nodify_expr <| d0()
    let nodify_func_filt = nodify_expr <| d0()
    let nodify_vv = nodify_expr <| d0()
    let nodify_op = nodify_expr <| d0()
    let nodify_exprpos = nodify_expr <| d0()

    let listt x = ListT x
    let litt x = LitT x
    let funt (x, core) = MapT (x, core)
    let uniont x = UnionT x
    let term_functiont a b = TermFunctionT (a,b)
    let arrayt x = ArrayT x

    let BListT = listt []

    /// Wraps the argument in a list if not a tuple type.
    let tuple_field_ty = function 
        | ListT x -> x
        | x -> [x]

    let v x = nodify_v x |> fun id -> V(x,id)
    let open_ (a,b,c as x) = nodify_open x |> fun id -> Open(a,b,c,id)
    let fix_ (a,b as x) = nodify_fix x |> fun id -> Fix(a,b,id)
    let lit x = nodify_lit x |> fun id -> Lit(x,id)
    let op (a,b as x) = nodify_op x |> fun id -> Op(a,b,id)
    let pattern x = nodify_pattern x |> fun id -> Pattern(x,id)
    let func (a,b as x) = nodify_func x |> fun id -> Function(a,b,id)
    let func_filt (a,b,c as x) = nodify_func_filt x |> fun id -> FunctionFilt(a,b,c,id)
    let vv x = nodify_vv x |> fun id -> VV(x,id)
    let exprpos x = nodify_exprpos x |> fun id -> ExprPos(x,id)

    // nodify_ty variants
    let boxed_type_dict = d0()
    let rec boxed_type_open = function // Will diverge on degenerate cases.
        | RecT x -> boxed_type_dict.[x] |> boxed_type_open
        | x -> x
        
    let nodify_memo_key = nodify <| d0()
    let hashcons_table = hashcons_create 0
    let consify_env_term x = EnvConsed(hashcons_add hashcons_table x)

    let tyv x = TyV x
    let tyvv x = TyList x
    let tymap (a,t) = (a,t) |> TyMap
    let tybox x = TyBox x

    let lit_int i = LitInt64 i |> lit
    let lit_string x = LitString x |> lit

    let fix name x = fix_ (name, x)
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
    
    // The seemingly useless function application is there to filter the environment just in case it has not been done.
    let join_point_entry_method y = ap (inl "" (op(JoinPointEntryMethod,[y]))) B 
    let join_point_entry_type y = ap (inl "" (op(JoinPointEntryType,[y]))) B

    let module_open a b = open_(a,b,Set.empty)
    let module_openb a b = ap a (inl " module" (module_open (v " module") b)) 

    let rec ap' f l = List.fold ap f l

    let if_static cond tr fl = (IfStatic,[cond;tr;fl]) |> op
    let case arg case = (Case,[arg;case]) |> op
    let module_is_cps arg on_fail on_succ = op(ModuleIsCPS,[arg;on_fail;on_succ])
    let module_member_cps arg name on_fail on_succ = op(ModuleMemberCPS,[arg;lit (LitString name);on_fail;on_succ])
    let module_inject_cps arg name on_fail on_succ = op(ModuleInjectCPS,[arg;v name;on_fail;on_succ])
    let term_fun_dom_range_cps arg on_fail on_succ = op(TermFunctionDomainRangeCPS,[arg;on_fail;on_succ])
    let list_taken_cps count arg on_fail on_succ = op(ListTakeNCPS,[lit (LitInt32 count);arg;on_fail;on_succ])
    let list_taken_tail_cps count arg on_fail on_succ = op(ListTakeNTailCPS,[lit (LitInt32 (count-1));arg;on_fail;on_succ])
    let binop op' a b = (op',[a;b]) |> op
    let eq_type a b = binop EqType a b
    let eq a b = binop EQ a b
    let lt a b = binop LT a b
    let gte a b = binop GTE a b

    let error_non_unit x = (ErrorNonUnit, [x]) |> op
    let type_lit_lift' x = (TypeLitCreate,[x]) |> op
    let type_lit_lift x = type_lit_lift' (lit x)
    let type_lit_cps a b c d = op(TypeLitCPS,[a;b;c;d])
    let type_lit_cast x = (TypeLitCast,[x]) |> op
    let type_lit_is x = (TypeLitIs,[x]) |> op
    let expr_pos pos x = exprpos(Spiral.Types.Position(pos,x))
    let pat_pos pos x = PatPos(Spiral.Types.Position(pos,x))

    let type_get a = op(TypeGet,[a])
    let type_union l = op(TypeUnion,l)
    let type_box a b = op(TypeBox,[a;b])

    let rec typed_expr_env_free_var_exists x = Map.exists (fun k v -> typed_expr_free_var_exists v) x
    and typed_expr_free_var_exists e =
        let inline f x = typed_expr_free_var_exists x
        match e with
        | TyBox (n,t) -> f n
        | TyList l -> List.exists f l
        | TyMap(C l,t) -> typed_expr_env_free_var_exists l
        | TyV (n,t as k) -> true
        | TyT _ | TyLit _ -> false
        | TyJoinPoint _ | TyOp _ | TyState _ | TyLet _ -> failwith "Compiler error: Only data structures in the TypedExpr can be tested for free variable existence."

    // #Unit type tests
    let rec is_unit_tuple t = List.forall is_unit t
    and is_unit_env x = Map.forall (fun _ -> is_unit) x
    and is_unit = function
        | LitT _ -> true
        | UnionT _ | RecT _ | DotNetTypeT _ | CudaTypeT _ | TermFunctionT _ | PrimT _ -> false
        | ArrayT (_,t) -> is_unit t
        | MapT (env,_) -> is_unit_env env
        | LayoutT (_, x) -> typed_expr_free_var_exists x = false
        | ListT t -> is_unit_tuple t

    /// Wraps the argument in a set if not a UnionT.
    let set_field = function
        | UnionT t -> t
        | t -> Set.singleton t

    let (|TySet|) x = set_field x

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
    let pattern_dict = d0()
    let expr_used_vars_dict = d0()
    let rec pattern_compile pat node = 
        node |> memoize pattern_dict (fun _ ->
            let new_pat_var =
                let mutable i = 0
                let get_pattern_tag () = 
                    let x = i
                    i <- i + 1
                    x
                fun () -> sprintf " pat_var_%i_%i" node (get_pattern_tag())

            let rec pattern_compile (arg: Expr) (pat: Pattern) (on_succ: Expr) (on_fail: Expr): Expr =
                let inline cp arg pat on_succ on_fail = pattern_compile arg pat on_succ on_fail

                let pat_tuple_helper l =
                    List.foldBack (fun pat (c,s,on_succ) -> 
                        let arg = new_pat_var()
                        c + 1, arg :: s,cp (v arg) pat on_succ on_fail) l (0,[],on_succ)
           
                match pat with
                | PatClauses l -> List.foldBack (fun (pat, exp) on_fail -> cp arg pat exp on_fail) l on_fail
                | PatE -> on_succ
                | PatVar x -> l x arg on_succ
                | PatTypeEq (exp,typ) ->
                    let on_succ = cp arg exp on_succ on_fail
                    if_static (eq_type arg typ) on_succ on_fail
                    |> case arg
                | PatTuple l -> 
                    let count, args, on_succ = pat_tuple_helper l
                    list_taken_cps count arg on_fail (inl' args on_succ) |> case arg
                | PatCons l -> 
                    let count, args, on_succ = pat_tuple_helper l
                    list_taken_tail_cps count arg on_fail (inl' args on_succ) |> case arg
                | PatActive (a,b) ->
                    let pat_var = new_pat_var()
                    l pat_var (ap a arg) (cp (v pat_var) b on_succ on_fail)
                | PatPartActive (a,pat) -> 
                    let pat_var = new_pat_var()
                    let on_succ = inl pat_var (cp (v pat_var) pat on_succ on_fail)
                    let on_fail = inl "" on_fail
                    ap' a [arg; on_fail; on_succ]
                | PatOr l -> List.foldBack (fun pat on_fail -> cp arg pat on_succ on_fail) l on_fail
                | PatAnd l -> List.foldBack (fun pat on_succ -> cp arg pat on_succ on_fail) l on_succ
                | PatNot p -> cp arg p on_fail on_succ // switches the on_fail and on_succ arguments
                | PatXor l ->
                    let state_var = new_pat_var()
                    let state_var' = v state_var
                    let bool x = lit <| LitBool x
                    let rec just_one = function
                        | x :: xs -> 
                            let xs = just_one xs
                            inl state_var 
                                (cp arg x 
                                    (if_static state_var' on_fail (ap xs (bool true))) // true case
                                    (ap xs state_var')) // false case
                        | [] -> inl state_var (if_static state_var' on_succ on_fail)
                    ap (just_one l) (bool false)
                | PatLit x -> 
                    let x = lit x
                    let on_succ = if_static (eq arg x) on_succ on_fail
                    if_static (eq_type arg x) on_succ on_fail |> case arg
                | PatTypeLit x -> 
                    type_lit_cps arg (lit x) on_fail on_succ
                    |> case arg
                | PatTypeLitBind x -> 
                    if_static (type_lit_is arg) (l x (type_lit_cast arg) on_succ) on_fail 
                    |> case arg
                | PatModuleIs p -> module_is_cps arg on_fail (cp arg p on_succ on_fail) |> case arg
                | PatModuleMember name -> module_member_cps arg name on_fail (inl name on_succ) |> case arg
                | PatModuleRebind(name,b) -> 
                    let arg' = new_pat_var()
                    module_member_cps arg name on_fail (inl arg' (cp (v arg') b on_succ on_fail)) 
                    |> case arg
                | PatModuleInject(name,b) ->
                    let arg' = new_pat_var()
                    module_inject_cps arg name on_fail (inl arg' (cp (v arg') b on_succ on_fail)) 
                    |> case arg
                | PatWhen (p, e) -> cp arg p (if_static e on_succ on_fail) on_fail
                | PatTypeTermFunction(a,b) -> 
                    let va, vb = new_pat_var(), new_pat_var()
                    term_fun_dom_range_cps arg on_fail 
                    <| inl' [va; vb] (cp (v va) a (cp (v vb) b on_succ on_fail) on_fail)
                | PatPos p -> expr_pos p.Pos (cp arg p.Expression on_succ on_fail)
                    
            let main_arg = new_pat_var()
            let arg = v main_arg
                    
            let pattern_compile_def_on_succ = op(ErrorPatClause,[])
            let pattern_compile_def_on_fail = op(ErrorPatMiss,[arg])
            inl main_arg (pattern_compile arg pat pattern_compile_def_on_succ pattern_compile_def_on_fail)
            )
            
    /// Rewrites the AST so that used variables are included.
    let rec expr_used_vars e =
        e |> memoize expr_used_vars_dict (fun e ->
            let inline f e = expr_used_vars e
            match e with
            | V (n,_) -> Set.singleton n, e
            | Fix(name,body,_) ->
                let l, body = f body
                if Set.contains name l then l, fix name body
                else l, body
            | Op(op',l,_) ->
                let l,l' = List.map f l |> List.unzip
                Set.unionMany l, op(op',l')
            | VV (l,_) -> 
                let l,l' = List.map f l |> List.unzip
                Set.unionMany l, vv l'
            | FunctionFilt(vars,name,body,_) ->
                Set.remove name vars, e
            | Function(name,body,_) ->
                let vars,body = f body
                Set.remove name vars, func_filt(vars,name,body)
            | Lit _ -> Set.empty, e
            | Pattern (pat,node) -> pattern_compile pat node |> f
            | Open (a,b,_,_) ->
                let a,a' = f a
                let b,b' = f b
                let c = a + b
                c, open_(a',b',c)
            | ExprPos (p,_) -> 
                let vars, body = f p.Expression
                vars, expr_pos p.Pos body
            )
    let expr_prepass x = expr_used_vars x |> snd // |> expr_diff_vars

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
            | TyJoinPoint _ | TyOp _ | TyState _ | TyLet _ -> failwith "Only data structures in the env can be renamed."
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

    // #Partial evaluation
    let rec expr_peval (d: LangEnv) (expr: Expr): TypedExpr =
        let inline tev d expr = expr_peval d expr
        let inline apply_seq d x = !d.seq x
        let inline tev_seq d expr = let d = {d with seq=ref id; cse_env=ref !d.cse_env} in tev d expr |> apply_seq d
        let inline tev_annot d expr = let d = {d with seq=ref id; cse_env=ref !d.cse_env} in tev d expr
        let inline tev_assume cse_env d expr = let d = {d with seq=ref id; cse_env=ref cse_env} in tev d expr |> apply_seq d
        let inline tev_method d expr = let d = {d with seq=ref id; cse_env=ref Map.empty} in tev d expr |> apply_seq d
        let inline tev_rec d expr = let d = {d with seq=ref id; cse_env=ref Map.empty; rbeh=AnnotationReturn} in tev d expr |> apply_seq d

        let inline tev2 d a b = tev d a, tev d b
        let inline tev3 d a b c = tev d a, tev d b, tev d c
        let inline tev4 d a b c d' = tev d a, tev d b, tev d c, tev d d'

        let inline inner_compile x = expr_prepass x |> tev d

        let inline v_find env x on_fail on_succ = 
            let run env = 
                match Map.tryFind x env with
                | Some v -> on_succ v
                | None -> on_fail()
            match env with
            | Env env -> run env
            | EnvConsed env -> run env.node

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
                    let trace = trace d
                    d.seq := fun rest -> TyState(ty_exp,rest,get_type rest,trace) |> seq
                tyt ty
            else
                let v = make_tyv_ty d ty
                let seq = !d.seq
                let trace = trace d
                d.seq := fun rest -> TyLet(v,ty_exp,rest,get_type rest,trace) |> seq
                tyv v
            
        let make_tyv_and_push_typed_expr_even_if_unit d ty_exp = make_tyv_and_push_typed_expr_template true d ty_exp
        let make_tyv_and_push_typed_expr d ty_exp = make_tyv_and_push_typed_expr_template false d ty_exp

        let cse_add' d r x = let e = !d.cse_env in if r <> x then Map.add r x e else e
        let cse_remove' d r = let e = !d.cse_env in Map.remove r e
        let cse_add d r x = d.cse_env := cse_add' d r x
        let cse_remove d r = d.cse_env := cse_remove' d r

        let rec destructure (d: LangEnv) (r: TypedExpr): TypedExpr = 
            let inline destructure r = destructure d r

            let inline cse_eval on_succ on_fail r = 
                match Map.tryFind r !d.cse_env with
                | Some x -> on_succ x
                | None -> on_fail r
            let inline cse_recurse r = cse_eval destructure id r

            let inline let_insert_cse r = 
                cse_eval 
                    cse_recurse
                    (fun r ->
                        let x = make_tyv_and_push_typed_expr d r |> destructure
                        cse_add d r x
                        x)
                    r

            let list_unseal r tuple_types = 
                let unpack (s,i as state) typ = 
                    if is_unit typ then (tyt typ |> destructure) :: s, i
                    else (destructure <| TyOp(ListIndex,[r;TyLit <| LitInt64 (int64 i)],typ)) :: s, i + 1
                List.fold unpack ([],0) tuple_types
                |> fst |> List.rev

            let env_unseal r x =
                let unseal (m,i as state) (k: string) typ = 
                    if is_unit typ then Map.add k (tyt typ |> destructure) m, i
                    else
                        let r = TyOp(MapGetField,[r; tyv(i,typ)], typ) |> destructure 
                        Map.add k r m, i + 1
                Map.fold unseal (Map.empty,0) x |> fst

            let inline destructure_var r map_vvt map_funt =
                match get_type r with
                | ListT tuple_types -> tyvv(map_vvt tuple_types)
                | MapT (env,t) -> tymap(map_funt env, t)
                | _ -> cse_recurse r
            
            match r with
            | TyMap _ | TyList _ | TyLit _ -> r
            | TyBox _ -> cse_recurse r
            | TyT _ -> destructure_var r (List.map (tyt >> destructure)) (Map.map (fun _ -> (tyt >> destructure)) >> Env)
            | TyV _ -> destructure_var r (list_unseal r) (env_unseal r >> Env)
            | TyOp _ -> let_insert_cse r
            | TyJoinPoint _ | TyLet _ | TyState _ -> on_type_er (trace d) "Compiler error: This should never appear in destructure. It should go directly into d.seq."

        let if_static (d: LangEnv) (cond: Expr) (tr: Expr) (fl: Expr): TypedExpr =
            match tev d cond with
            | TyLit (LitBool true) -> tev d tr
            | TyLit (LitBool false) -> tev d fl
            | TyType (PrimT BoolT) as cond ->
                let b x = cse_add' d cond (TyLit <| LitBool x)
                let tr = tev_assume (b true) d tr
                let fl = tev_assume (b false) d fl
                let type_tr, type_fl = get_type tr, get_type fl
                if type_tr = type_fl then
                    match tr, fl with
                    | TyLit (LitBool true), TyLit (LitBool false) -> cond
                    | _ when tr = fl -> tr
                    | _ -> TyOp(IfStatic,[cond;tr;fl],type_tr) |> make_tyv_and_push_typed_expr_even_if_unit d
                else on_type_er (trace d) <| sprintf "Types in branches of If do not match.\nGot: %s and %s" (show_ty type_tr) (show_ty type_fl)
            | TyType cond -> on_type_er (trace d) <| sprintf "Expected a bool in conditional.\nGot: %s" (show_ty cond)

        // Note: The while loop is only here until NVidia fixes the compiler bugs in NVCC.
        // It exists in order to be a workaround for languages that do not support tail call optimization.
        // `cond` is always supposed to be a join point so no need to test for if it is a literal.
        let while_ d cond body =
            match tev_seq d cond with
            | TyType (PrimT BoolT) as cond -> 
                match tev_seq d body with
                | TyType (ListT []) as body -> 
                    TyOp(While,[cond;body],BListT) 
                    |> make_tyv_and_push_typed_expr_even_if_unit d
                | TyType t -> on_type_er (trace d) <| sprintf "Expected unit as the type of the while loop.\nGot: %s" (show_ty t)
            | TyType cond -> on_type_er (trace d) <| sprintf "Expected a bool in conditional.\nGot: %s" (show_ty cond)

        let extern_type_create op d x =
            let _, x = renamer_apply_typedexpr (tev d x)
            match op with
            | DotNetTypeCreate -> tyt (DotNetTypeT x)
            | CudaTypeCreate -> tyt (CudaTypeT x)
            | _ -> failwith "invalid op"

        let inline layout_boxed_unseal_var recf v = TyOp(MapGetField,[recf;v],get_type v)

        let rec layout_boxed_unseal_mutable d recf x =
            let inline f x = layout_boxed_unseal_mutable d recf x
            match x with
            | TyV _ as v -> layout_boxed_unseal_var recf v |> make_tyv_and_push_typed_expr d
            | TyList l -> tyvv (List.map f l)
            | TyBox(a,b) -> tybox (f a, b)
            | TyMap(env, b) -> tymap (layout_env_term_unseal_mutable d recf env, b)
            | x -> x
        and layout_env_term_unseal_mutable d recf (C env) = Map.map (fun _ -> layout_boxed_unseal_mutable d recf) env |> Env

        let rec layout_boxed_unseal d recf x =
            let inline f x = layout_boxed_unseal d recf x
            match x with
            | TyV _ as v -> layout_boxed_unseal_var recf v |> destructure d
            | TyList l -> tyvv (List.map f l)
            | TyBox(a,b) -> tybox (f a, b)
            | TyMap(env, b) -> tymap (layout_env_term_unseal d recf env, b)
            | x -> x
        and layout_env_term_unseal d recf (C env) = Map.map (fun _ -> layout_boxed_unseal d recf) env |> Env

        let layout_to_none' d = function
            | TyT(LayoutT(t,l))
            | TyV(_,LayoutT(t,l)) as recf -> 
                match t with
                | LayoutHeapMutable -> layout_boxed_unseal_mutable d recf l
                | _ -> layout_boxed_unseal d recf l
            | a -> a
        let layout_to_none d a = layout_to_none' d (tev d a)

        let rec layoutify (layout: LayoutType) (d: LangEnv) = function
            | TyT(LayoutT(layout',_))
            | TyV(_,LayoutT(layout',_)) as a ->
                if layout <> layout' then layout_to_none' d a |> layoutify layout d else a
            | TyLit _ | TyT _ | TyV _ as a -> a
            | a -> 
                let {renamer'=r}, expr = renamer_apply_typedexpr a
                if r.Count = 0 then LayoutT(layout,expr) |> tyt
                else TyOp(layout_to_op layout,[a],LayoutT(layout,expr)) |> destructure d
        let layout_to layout d a = layoutify layout d (tev d a)

        let join_point_method (d: LangEnv) (expr: Expr): TypedExpr = 
            let {call_args=call_arguments; method_pars=method_parameters; renamer'=renamer}, renamed_env = renamer_apply_env d.env
            let length = renamer.Count
            let join_point_key: Node<Expr * EnvTerm> = nodify_memo_key (expr, renamed_env)
           
            let ret_ty = 
                let d = {d with env=renamed_env; ltag=ref length}
                let join_point_dict: Dictionary<_,_> = join_point_dict_method
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

        let rec blittable_is' = function
            | CudaTypeT _ | LitT _ -> true
            | PrimT t ->
                match t with
                | BoolT _ | CharT _ | StringT _ -> false
                | _ -> true
            | ListT l -> false
            | MapT (l,_) -> Map.forall (fun _ -> blittable_is') l
            | LayoutT (LayoutPackedStack, l) -> 
                let {call_args=args},_ = renamer_apply_typedexpr l
                List.forall (fun (_,t) -> blittable_is' t) args
            | ArrayT (ArtCudaGlobal _,t) -> blittable_is' t
            | UnionT _ | LayoutT _ | ArrayT _ | DotNetTypeT _ | TermFunctionT _ | RecT _ -> false

        let blittable_is d a = tev d a |> get_type |> blittable_is' |> LitBool |> TyLit

        let join_point_cuda d expr = 
            let {call_args=call_arguments; method_pars=method_parameters; renamer'=renamer}, renamed_env = renamer_apply_env d.env
            match List.filter (snd >> blittable_is' >> not) call_arguments with
            | [] -> ()
            | l -> on_type_er (trace d) <| sprintf "At the Cuda join point the following arguments have disallowed non-blittable types: %s" (List.map tyv l |> tyvv |> show_typedexpr)

            let length=renamer.Count
            let join_point_key = nodify_memo_key (expr, renamed_env) 

            let method_name = print_method join_point_key.Symbol |> LitString |> TyLit
            let inline ret x = tyvv [method_name; List.map tyv x |> List.rev |> tyvv]

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
          
            ret call_arguments

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

        let type_get d a = tev_annot d a |> get_type |> TyT
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

        let case_ d v case =
            let inline assume d v x branch = tev_assume (cse_add' d v x) d branch
            match tev d v with
            | a & TyBox(b,_) -> 
                cse_add d a b
                let r = tev d case
                cse_remove d a
                r
            | (TyV(_, t & (UnionT _ | RecT _)) | TyT(t & (UnionT _ | RecT _))) as v ->
                let make_up_vars_for_ty (l: Ty list): TypedExpr list = List.map (make_up_vars_for_ty d) l
                let map_to_cases (l: TypedExpr list): (TypedExpr * TypedExpr) list = List.map (fun x -> x, assume d v x case) l
                            
                match case_type d t |> make_up_vars_for_ty |> map_to_cases with
                | (_, TyType p) :: cases as cases' -> 
                    if List.forall (fun (_, TyType x) -> x = p) cases then 
                        TyOp(Case,v :: List.collect (fun (a,b) -> [a;b]) cases', p) 
                        |> make_tyv_and_push_typed_expr_even_if_unit d
                    else 
                        let l = List.map (snd >> get_type) cases'
                        on_type_er (trace d) <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\nGot: %s" (listt l |> show_ty)
                | _ -> failwith "There should always be at least one clause here."
            | _ -> tev d case
          
        let type_union d l = List.fold (fun s x -> Set.union s (tev d x |> get_type |> set_field)) Set.empty l |> uniont |> tyt

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

        let string_format d a b = 
            match tev2 d a b with
            | TyLit(LitString format) & a, TyTuple l when List.forall lit_is l ->
                let f = function
                    | TyLit x ->
                        match x with
                        | LitInt8 x -> box x
                        | LitInt16 x -> box x
                        | LitInt32 x -> box x
                        | LitInt64 x -> box x
                        | LitUInt8 x -> box x
                        | LitUInt16 x -> box x
                        | LitUInt32 x -> box x
                        | LitUInt64 x -> box x
                        | LitFloat32 x -> box x
                        | LitFloat64 x -> box x
                        | LitString x -> box x
                        | LitChar x -> box x
                        | LitBool x -> box x
                    | _ -> failwith "impossible"
                try 
                    match l with
                    | [a] -> String.Format(format,f a)
                    | [a;b] -> String.Format(format,f a,f b)
                    | [a;b;c] -> String.Format(format,f a,f b,f c)
                    | l -> String.Format(format,List.toArray l |> Array.map f)
                    |> LitString |> TyLit
                with :? System.FormatException as e -> on_type_er (trace d) <| sprintf "Dotnet format exception.\nMessage: %s" e.Message
            | TyType (PrimT StringT) & a, TyTuple l -> 
                List.map (function TyT(LitT x) -> TyLit x | x -> x) l
                |> fun l -> TyOp(StringFormat,a :: l,PrimT StringT)
            | a, _ -> on_type_er (trace d) <| sprintf "Expected a string as the first argument to string format.\nGot: %s" (show_typedexpr a)

        let string_concat d sep l =
            match tev2 d sep l with
            | TyType(PrimT StringT) & sep, TyList [] -> LitString "" |> TyLit
            | TyType(PrimT StringT) & sep, TyType (ArrayT(_,t)) & a -> 
                match t with
                | PrimT StringT -> TyOp(StringConcat, [sep; a], PrimT StringT)
                | t -> on_type_er (trace d) <| sprintf "Expected the type of the array element inputted to string concat as the second argument to be string.\nGot: %s" (show_ty t)
            | (TyT(PrimT StringT) | TyV(_, (PrimT StringT))) & sep, TyTuple l -> 
                List.iter (function
                    | TyType (PrimT StringT) -> ()
                    | x -> on_type_er (trace d)  <| sprintf "One of the arguments to string concat is not a string.\nGot: %s" (show_typedexpr x)) l
                TyOp(StringConcat, [sep; tyvv l], PrimT StringT)
            | TyLit(LitString sep) & a, TyTuple l ->
                List.fold (fun s -> function
                    | TyLit (LitString _) -> s && true
                    | TyType (PrimT StringT) -> false
                    | x -> on_type_er (trace d)  <| sprintf "One of the arguments to string concat is not a string.\nGot: %s" (show_typedexpr x)
                    ) true l
                |> function
                    | true -> 
                        List.map (function
                            | TyLit (LitString x) -> x
                            | _ -> failwith "impossible") l
                        |> String.concat sep
                        |> LitString |> TyLit
                    | false ->
                        TyOp(StringConcat, [a; tyvv l], PrimT StringT)
            | x,_ -> on_type_er (trace d) <| sprintf "Expected a string as the separator argument to string concat.\nGot: %s" (show_typedexpr x)

        let inline env_add a b env =
            match env with
            | EnvConsed env -> Map.add a b env.node |> Env
            | Env env -> Map.add a b env |> Env

        let inline apply_func is_term_cast d recf env_term fun_type args =
            let inline tev x =
                if is_term_cast then join_point_closure args x
                else tev x

            match fun_type with
            | MapTypeRecFunction ((pat,body),name) ->
                let env = if String.IsNullOrEmpty pat then env_term else env_add pat args env_term
                tev {d with env = env_add name recf env} body
            | MapTypeFunction (pat,body) -> 
                tev {d with env = if String.IsNullOrEmpty pat then env_term else env_add pat args env_term} body
            | _ -> on_type_er (trace d) "Expected a function in function application."

        let term_cast d a b =
            match tev d a |> layout_to_none' d, tev d b with
            | recf & TyMap(env_term,(MapTypeFunction _ | MapTypeRecFunction _ ) & map_type), args -> 
                let instantiate_type_as_variable d args_ty =
                    let f x = make_up_vars_for_ty d x
                    match args_ty with
                    | ListT l -> tyvv(List.map f l)
                    | x -> f x
            
                let args = instantiate_type_as_variable d (get_type args)
                apply_func true d recf env_term map_type args
            | x,_ -> on_type_er (trace d) <| sprintf "Expected a function in term casting application. Got: %s" (show_typedexpr x)

        let type_lit_create' x = litt x |> tyt

        let inline apply_module on_miss on_fail on_succ d a n =
            match a with
            | TyMap (env_term, MapTypeModule) -> v_find env_term n on_fail on_succ
            | recf & TyT (LayoutT (t, TyMap (env_term, MapTypeModule)))
            | recf & TyV (_, LayoutT (t, TyMap (env_term, MapTypeModule))) ->
                let inline f k = 
                    match Map.tryFind n (c env_term) with
                    | Some v -> k d recf v |> on_succ
                    | None -> on_fail()
                match t with
                | LayoutHeapMutable -> f layout_boxed_unseal_mutable
                | _ -> f layout_boxed_unseal
            | _ -> on_miss ()

        let rec apply d a b =
            match destructure d b with
            | TyT (LitT (LitString n)) ->
                match destructure d a with
                | TyV (_,ArrayT(_,elem_ty)) 
                | TyT (ArrayT(_,elem_ty)) ->
                    // apply_array
                    if n = "elem_type" then tyt elem_ty
                    else on_type_er (trace d) <| sprintf "Unknown type string applied to array. Got: %s" n
                | a ->
                    let on_miss _ =
                        match layout_to_none' d a with
                        | recf & TyMap(env_term,fun_type) -> apply_func false d recf env_term fun_type b
                        | a -> on_type_er (trace d) <| sprintf "Invalid type string application. Got: %s and %s" (show_typedexpr a) n
                    let on_fail _ = on_type_er (trace d) <| sprintf "Cannot find a member named %s inside the module." n
                    apply_module on_miss on_fail id d a n
            | b ->
                match destructure d a |> layout_to_none' d, b with
                // apply_function
                | recf & TyMap(env_term,fun_type), args -> apply_func false d recf env_term fun_type args
                // apply_string_static
                | TyLit (LitString str), TyList [TyLitIndex a; TyLitIndex b] -> 
                    let f x = x >= 0 && x < str.Length
                    if f a && f b then TyLit(LitString str.[a..b])
                    else on_type_er (trace d) "The slice into a string literal is out of bounds."
                | TyLit (LitString str), TyLitIndex x -> 
                    if x >= 0 && x < str.Length then TyLit(LitChar str.[x])
                    else on_type_er (trace d) "The index into a string literal is out of bounds."
                | a, b ->
                    match get_type a with
                    // apply_array
                    | ArrayT(array_ty,elem_ty) ->
                        let ar,idx = a, b
                        match array_ty, idx with
                        | (ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaShared | ArtCudaLocal), idx when is_int idx -> TyOp(ArrayIndex,[ar;idx],elem_ty) |> make_tyv_and_push_typed_expr d
                        | (ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaShared | ArtCudaLocal), idx -> on_type_er (trace d) <| sprintf "The index into an array is not an int. Got: %s" (show_typedexpr idx)
                        | ArtDotNetReference, TyList [] -> TyOp(ArrayIndex,[ar;idx],elem_ty) |> make_tyv_and_push_typed_expr d
                        | ArtDotNetReference, _ -> on_type_er (trace d) <| sprintf "The index into a reference is not a unit. Got: %s" (show_typedexpr idx)
                    // apply_string
                    | PrimT StringT -> 
                        let str = a
                        match b with
                        | TyList [a;b] ->
                            if is_int a && is_int b then TyOp(StringSlice,[str;a;b],PrimT StringT) |> destructure d
                            else on_type_er (trace d) "Expected an int as the second argument to string index."
                        | idx -> 
                            if is_int idx then TyOp(StringIndex,[str;idx],PrimT CharT) |> destructure d
                            else on_type_er (trace d) "Expected an int as the second argument to string index."
                    // apply_closure
                    | TermFunctionT (clo_arg_ty,clo_ret_ty) -> 
                        let closure,args = a,b
                        let arg_ty = get_type args
                        if arg_ty <> clo_arg_ty then on_type_er (trace d) <| sprintf "Cannot apply an argument of type %s to closure (%s => %s)." (show_ty arg_ty) (show_ty clo_arg_ty) (show_ty clo_ret_ty)
                        else TyOp(Apply,[closure;args],clo_ret_ty) |> make_tyv_and_push_typed_expr_even_if_unit d
                    | _ -> on_type_er (trace d) <| sprintf "Invalid use of apply. %s and %s" (show_typedexpr a) (show_typedexpr b)

        let case_foldl_map d case s v =
            let case, s, v = tev3 d case s v

            let make_up_vars_for_ty (l: Ty list): TypedExpr list = List.map (make_up_vars_for_ty d) l
            let map_to_cases (l: TypedExpr list) = 
                List.mapFold (fun s x -> 
                    let case = apply d case s
                    let d = {d with seq=ref id}
                    match apply d case x with
                    | TyList [a;b] -> 
                        if typed_expr_free_var_exists b then on_type_er (trace d) "The state returned from a case must not have a free variable."
                        (x,apply_seq d a,s),b
                    | x -> on_type_er (trace d) "Expected a value * state tuple as the return from a case branch."
                    ) s l

            match v with
            | TyBox(v,t) ->
                let t = case_type d t
                let cases,state = make_up_vars_for_ty t |> map_to_cases
                            
                match cases with
                | (_, TyType p,_) :: cases' ->
                    if List.forall (fun (_, TyType x,_) -> x = p) cases' then
                        let v_ty = get_type v
                        let _,_,s = cases.[List.findIndex (fun t -> v_ty = t) t]
                        match apply d (apply d case s) v with
                        | TyList [a;b] -> 
                            if typed_expr_free_var_exists b then on_type_er (trace d) "The state returned from a case must not have a free variable."
                            tyvv [a;state]
                        | x -> on_type_er (trace d) "Expected a value * state tuple as the return from a case branch."
                    else
                        let l = List.map (fun (_,b,_) -> get_type b) cases
                        on_type_er (trace d) <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\nGot: %s" (listt l |> show_ty)
                | _ -> failwith "There should always be at least one clause here."

            | (TyV(_, t & (UnionT _ | RecT _)) | TyT(t & (UnionT _ | RecT _))) as v ->
                let cases,state = case_type d t |> make_up_vars_for_ty |> map_to_cases

                match cases with
                | (_, TyType p,_) :: cases' -> 
                    if List.forall (fun (_, TyType x,_) -> x = p) cases' then 
                        TyOp(Case,v :: List.collect (fun (a,b,_) -> [a;b]) cases, p) 
                        |> make_tyv_and_push_typed_expr_even_if_unit d
                        |> fun x -> tyvv [x;state]
                    else 
                        let l = List.map (fun (_,b,_) -> get_type b) cases
                        on_type_er (trace d) <| sprintf "All the cases in pattern matching clause with dynamic data must have the same type.\nGot: %s" (listt l |> show_ty)
                | _ -> failwith "There should always be at least one clause here."
            | x -> on_type_er (trace d) <| sprintf "CaseFoldLMap needs an union type as input.\nGot: %A" x

        let term_fun_type_create d a b =
            let a = tev_seq d a
            let b = tev_seq d b
            term_functiont (get_type a) (get_type b) |> tyt

        let term_fun_dom_range_cps d x on_fail on_succ =
            match tev d x with
            | TyType(TermFunctionT (a,b)) -> 
                let on_succ = tev d on_succ    
                apply d (apply d on_succ (tyt a)) (tyt b)
            | x -> tev d on_fail

        let type_box (d: LangEnv) (typec: Expr) (args: Expr): TypedExpr =
            let typec & TyType ty, args = tev2 d typec args
            let substitute_ty = function
                | TyBox(x,_) -> tybox(x,ty)
                | x -> tybox(x,ty)

            let (|TyRecUnion|_|) = function
                | UnionT ty' -> Some ty'
                | RecT key -> Some (set_field (rect_unbox d key))
                | _ -> None
            
            match ty, get_type args with
            | x, r when x = r -> args
            | TyRecUnion ty', UnionT ty_args when Set.isSubset ty_args ty' ->
                let lam = inl' ["typec"; "args"] (op(Case,[v "args"; type_box (v "typec") (v "args")])) |> inner_compile
                apply d (apply d lam typec) args
            | TyRecUnion ty', x when Set.contains x ty' -> substitute_ty args
            | _ -> on_type_er (trace d) <| sprintf "Type constructor application failed. %s does not intersect %s." (show_ty ty) (get_type args |> show_ty)


        let apply_tev d expr args = apply d (tev d expr) (tev d args)

        let list_cons d a b =
            let a, b = tev2 d a b
            match b with
            | TyList b -> tyvv(a::b)
            | _ -> on_type_er (trace d) "Expected a tuple on the right in ListCons."

        let list_taken (d: LangEnv) (a: Expr) (arg: Expr) (on_fail: Expr) (on_succ: Expr) = 
            match tev d a with
            | TyLitIndex c -> 
                let inline loop f args = 
                    let rec loop = function
                        | 0,[] -> List.fold (fun on_succ arg -> apply d on_succ (f arg)) (tev d on_succ) args
                        | _,[] | 0, _ -> tev d on_fail
                        | c,_ :: x' -> loop (c-1,x')
                    loop (c, args)
                match tev d arg with
                | TyList args -> loop id args
                | recf & TyT (LayoutT (t, TyList args))
                | recf & TyV (_, LayoutT (t, TyList args)) ->
                    match t with
                    | LayoutHeapMutable -> loop (layout_boxed_unseal_mutable d recf) args
                    | _ -> loop (layout_boxed_unseal d recf) args
                | _ -> tev d on_fail
            | x -> on_type_er (trace d) "Expected an int literal as the first input to ListTakeN.\nGot: %s" (show_typedexpr x)

        let list_taken_tail d a arg on_fail on_succ = 
            match tev d a with
            | TyLitIndex c -> 
                let inline loop f =
                    let rec loop args = function
                        | 0,x' -> List.foldBack (fun arg on_succ -> apply d on_succ (f arg)) (tyvv x' :: args) (tev d on_succ)
                        | _,[] -> tev d on_fail
                        | c,x :: x' -> loop (x :: args) (c-1,x')
                    loop
                match tev d arg with
                | TyList args -> loop id [] (c,args)
                | recf & TyT (LayoutT (t, TyList args))
                | recf & TyV (_, LayoutT (t, TyList args)) ->
                    match t with
                    | LayoutHeapMutable -> loop (layout_boxed_unseal_mutable d recf) [] (c,args)
                    | _ -> loop (layout_boxed_unseal d recf) [] (c,args)
                | _ -> tev d on_fail
            | x -> on_type_er (trace d) "Expected an int literal as the first input to ListTakeNTail.\nGot: %s" (show_typedexpr x)

        let eq_type d a b =
            let a, b = tev2 d a b 
            LitBool (get_type a = get_type b) |> TyLit

        let module_open d a b vars =
            match tev d a |> layout_to_none' d with
            | TyMap(C env_term,MapTypeModule) as recf -> 
                let env = 
                    let map_add s k v = Map.add k v s
                    Map.fold map_add (c d.env) env_term
                    |> Map.filter (fun x _ -> Set.contains x vars)
                    |> Env
                tev {d with env = env} b
            | x -> on_type_er (trace d) <| sprintf "The open expected a module type as input. Got: %s" (show_typedexpr x)

        let type_annot d a b =
            match d.rbeh with
            | AnnotationReturn -> tev_annot {d with rbeh=AnnotationDive} b
            | AnnotationDive ->
                let a, b = tev d a, tev_annot d b
                let ta, tb = get_type a, get_type b
                if ta = tb then a else on_type_er (trace d) <| sprintf "Type annotation mismatch.\n%s <> %s" (show_ty ta) (show_ty tb)

        let inline prim_bin_op_template d check_error is_check k a b t =
            let a, b = tev2 d a b
            if is_check a b then k t a b |> destructure d
            else on_type_er (trace d) (check_error a b)

        let inline prim_bin_op_helper t a b = TyOp(t,[a;b],get_type a)
        let inline prim_un_op_helper t a = TyOp(t,[a],get_type a)
        let inline bool_helper t a b = TyOp(t,[a;b],PrimT BoolT)

        let prim_arith_op d a b t = 
            let er a b = sprintf "`is_numeric a && get_type a = get_type b` is false.\na=%s, b=%s" (show_typedexpr a) (show_typedexpr b)
            let check a b = is_numeric a && get_type a = get_type b
            prim_bin_op_template d er check (fun t a b ->
                let inline op_arith a b =
                    match t with
                    | Add -> a + b
                    | Sub -> a - b
                    | Mult -> a * b
                    | Div -> 
                        if Unchecked.defaultof<_> = b then on_type_er (trace d) "Division by zero caught at compile time."
                        a / b
                    | Mod -> 
                        if Unchecked.defaultof<_> = b then on_type_er (trace d) "Modulus by zero caught at compile time."
                        a % b
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
                    | Sub -> TyOp(Neg,[b],get_type b)
                    | Mult | Div | Mod -> a
                    | _ -> failwith "Expected an arithmetic operation."
                let op_arith_num_one a b =
                    match t with
                    | Mult | Div -> a
                    | Mod ->
                        match get_type a with
                        | PrimT x ->
                            match x with
                            | Int8T -> TyLit (LitInt8 0y)
                            | Int16T -> TyLit (LitInt16 0s)
                            | Int32T -> TyLit (LitInt32 0)
                            | Int64T -> TyLit (LitInt64 0L)
                            | UInt8T -> TyLit (LitUInt8 0uy)
                            | UInt16T -> TyLit (LitUInt16 0us)
                            | UInt32T -> TyLit (LitUInt32 0u)
                            | UInt64T -> TyLit (LitUInt64 0UL)
                            | Float32T -> TyLit (LitFloat32 0.0f)
                            | Float64T -> TyLit (LitFloat64 0.0)
                            | BoolT | CharT | StringT -> failwith "Compiler error: Invalid type."
                        | _ -> failwith "Compiler error: Invalid type."
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

        let power d a b =
            match tev2 d a b with
            | TyLit (LitFloat64 a), TyLit (LitFloat64 b) -> a ** b |> LitFloat64 |> TyLit
            | TyLit (LitFloat32 a), TyLit (LitFloat32 b) -> float32 (float a ** float b) |> LitFloat32 |> TyLit
            | a, b ->
                match get_type a, get_type b with
                | PrimT Float64T, PrimT Float64T -> TyOp(Pow,[a;b],PrimT Float64T)
                | PrimT Float32T, PrimT Float32T -> TyOp(Pow,[a;b],PrimT Float32T)
                | a, b -> on_type_er (trace d) <| sprintf "The arguments to Pow must both be either float32 or float64. Got: %s and %s" (show_ty a) (show_ty b)

        let prim_comp_op d a b t = 
            let er a b = sprintf "(is_char a || is_string a || is_numeric a || is_bool a) && get_type a = get_type b` is false.\na=%s, b=%s" (show_typedexpr a) (show_typedexpr b)
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

        let prim_shift_op d a b t =
            let er a b = sprintf "`is_int a && is_int b` is false.\na=%s, b=%s" (show_typedexpr a) (show_typedexpr b)
            let check a b = is_int a && is_int b
            prim_bin_op_template d er check prim_bin_op_helper a b t

        let prim_bitwise_op d a b t =
            let er a b = sprintf "`get_type a = get_type b && is_any_int a && is_any_int b` is false.\na=%s, b=%s" (show_typedexpr a) (show_typedexpr b)
            let check a b = get_type a = get_type b && is_any_int a && is_any_int b
            prim_bin_op_template d er check (fun t a b ->
                let inline op_bitwise a b = 
                    match t with
                    | BitwiseAnd -> a &&& b
                    | BitwiseOr -> a ||| b
                    | BitwiseXor -> a ^^^ b
                    | _ -> on_type_er (trace d) "Compiler error: Expected a bitwise operation."
                match a,b with
                | TyLit a', TyLit b' ->
                    match a', b' with
                    | LitInt8 a, LitInt8 b -> op_bitwise a b |> LitInt8 |> TyLit
                    | LitInt16 a, LitInt16 b -> op_bitwise a b |> LitInt16 |> TyLit
                    | LitInt32 a, LitInt32 b -> op_bitwise a b |> LitInt32 |> TyLit
                    | LitInt64 a, LitInt64 b -> op_bitwise a b |> LitInt64 |> TyLit
                    | LitUInt8 a, LitUInt8 b -> op_bitwise a b |> LitUInt8 |> TyLit
                    | LitUInt16 a, LitUInt16 b -> op_bitwise a b |> LitUInt16 |> TyLit
                    | LitUInt32 a, LitUInt32 b -> op_bitwise a b |> LitUInt32 |> TyLit
                    | LitUInt64 a, LitUInt64 b -> op_bitwise a b |> LitUInt64 |> TyLit
                    | _ -> prim_bin_op_helper t a b
                | _ -> prim_bin_op_helper t a b
                ) a b t

        let prim_un_op_template d check_error is_check k a t =
            let a = tev d a
            if is_check a then k t a |> destructure d
            else on_type_er (trace d) (check_error a)

        let prim_un_floating d a t =
            let er a = sprintf "`is_float a` is false.\na=%s" (show_typedexpr a)
            let check a = is_float a
            prim_un_op_template d er check (fun t a ->
                let inline op x =
                    match t with
                    | Tanh -> tanh x
                    | Log -> log x
                    | Exp -> exp x
                    | Sqrt -> sqrt x
                    | _ -> on_type_er (trace d) "Compiler error: Unknown op."
                match a with
                | TyLit (LitFloat32 x) -> op x |> LitFloat32 |> TyLit
                | TyLit (LitFloat64 x) -> op x |> LitFloat64 |> TyLit
                | x -> prim_un_op_helper t x
                ) a t

        let is_nan d a =
            match tev d a with
            | TyLit (LitFloat32 x) -> System.Single.IsNaN x |> LitBool |> TyLit
            | TyLit (LitFloat64 x) -> System.Double.IsNaN x |> LitBool |> TyLit
            | a & TyType (PrimT (Float32T | Float64T)) -> TyOp(NanIs,[a],PrimT BoolT)
            | x -> on_type_er (trace d) <| sprintf "Expected a float in NanIs. Got: %s" (show_typedexpr x)

        let prim_un_numeric d a t =
            let er a = sprintf "`is_numeric a` is false.\na=%s" (show_typedexpr a)
            let check a = is_numeric a
            prim_un_op_template d er check (fun t a -> 
                let inline op a = 
                    match t with
                    | Neg -> -a
                    | _ -> failwithf "Compiler error: Unexpected operation %A." t

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
            let er l = on_type_er l <| sprintf "Only the last expression of a block is allowed to be unit. Use `ignore` if it intended to be such.\nGot: %s" (show_typedexpr x)
            if get_type x <> BListT then 
                match a with
                | ExprPos (x,_) -> er (x.Pos :: trace d)
                | _ -> er (trace d)
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

        let type_lit_cps d a b on_fail on_succ =
            match tev d a with
            | TyT (LitT a) ->
                match tev d b with
                | TyLit b -> if a = b then tev d on_succ else tev d on_fail
                | _ -> failwith "Compiler error: Expected a literal as the second argument in TypeLitCps."
            | _ -> tev d on_fail

        let lit_is d a = TyLit <| LitBool (tev d a |> lit_is)

        let box_is d a =
            match tev d a with
            | TyBox _ -> TyLit <| LitBool true
            | _ -> TyLit <| LitBool false

        let caseable_box_is d a =
            match tev d a with
            | TyBox _ -> TyLit (LitBool true)
            | TyV(_, t) | TyT t -> 
                match t with
                | UnionT _ | RecT _ -> TyLit (LitBool true)
                | _ -> TyLit (LitBool false)
            | _ -> TyLit (LitBool false)

        let caseable_is d a =
            match tev d a with
            | TyV(_, t) | TyT t -> 
                match t with
                | UnionT _ | RecT _ -> TyLit (LitBool true)
                | _ -> TyLit (LitBool false)
            | _ -> TyLit (LitBool false)

        // Apart from preserving aliasing is intended to be equal to push -> destructure.
        let dynamize d a =
            let rec loop = function
                | TyBox(_, _) | TyLit _ as a -> make_tyv_and_push_typed_expr d a
                | TyList l -> tyvv (List.map loop l)
                | TyMap(C env, t) -> tymap (Map.map (fun _ -> loop) env |> Env, t)
                | a -> a
            
            loop (tev d a)

        let array_create' ar_typ d size typ =
            let typ = tev_seq d typ |> get_type

            let size,array_type =
                match ar_typ, tev d size with
                | ArtCudaShared, TyLit _ & size when is_int size -> size,arrayt(ar_typ,typ)
                | ArtCudaShared, size -> on_type_er (trace d) <| sprintf "The size argument for shared memory arrays must be a int literal.\nGot: %s" (show_typedexpr size)
                | _, size when is_int size -> size,arrayt(ar_typ,typ)
                | _, size -> on_type_er (trace d) <| sprintf "An size argument in CreateArray is not of type int64.\nGot: %s" (show_typedexpr size)

            TyOp(ArrayCreate,[size],array_type) |> make_tyv_and_push_typed_expr d

        let array_create ar_typ d size typ =
            let ar_typ = 
                match tev d ar_typ with
                | TypeString x ->
                    match x with 
                    | "cuda_shared" -> ArtCudaShared
                    | "cuda_local" -> ArtCudaLocal
                    | x -> on_type_er (trace d) <| sprintf "Array %s not supported." x
                | x -> on_type_er (trace d) <| sprintf "Expected a type string as the input to array_create.\nGot: %s" (show_typedexpr x)
            array_create' ar_typ d size typ

        let reference_create d x =
            let x = tev d x
            let array_type = arrayt(ArtDotNetReference, get_type x)
            TyOp(ReferenceCreate,[x],array_type) |> make_tyv_and_push_typed_expr d

        let mutable_set d ar idx r =
            let ret t ar idx r =
                if is_unit t then TyB
                else make_tyv_and_push_typed_expr_even_if_unit d (TyOp(MutableSet,[ar;idx;r],BListT))
            let a,b,c = tev3 d ar idx r
            match get_type a with
            | ArrayT((ArtDotNetHeap | ArtCudaGlobal _ | ArtCudaShared | ArtCudaLocal),ar_ty) ->
                let ar, idx, r = a, b, c
                if is_int idx then
                    let r_ty = get_type r
                    if ar_ty = r_ty then ret ar_ty ar idx r
                    else on_type_er (trace d) <| sprintf "The two sides in array set have different types.\nGot: %s and %s" (show_ty ar_ty) (show_ty r_ty)
                else on_type_er (trace d) <| sprintf "Expected the array index to be an integer.\nGot: %s" (show_typedexpr idx)
            | ArrayT(ArtDotNetReference,ar_ty) ->
                let ar, idx, r = a, b, c
                match idx with
                | TyList [] ->
                    let r_ty = get_type r
                    if ar_ty = r_ty then ret ar_ty ar idx r
                    else on_type_er (trace d) <| sprintf "The two sides in reference set have different types.\nGot: %s and %s" (show_ty ar_ty) (show_ty r_ty)
                | _ -> on_type_er (trace d) <| sprintf "The input to reference set should be ().\nGot: %s" (show_typedexpr idx)
            | LayoutT(LayoutHeapMutable,TyMap(C env,MapTypeModule)) ->
                let module_,field,r = a,b,c
                match field with
                | TypeString field' ->
                    match Map.tryFind field' env with
                    | None -> on_type_er (trace d) <| sprintf "The field %s is missing in the module." field'
                    | Some v -> 
                        let _,r_ty = renamer_apply_typedexpr r
                        let _,v_ty = renamer_apply_typedexpr v
                        if v_ty = r_ty then make_tyv_and_push_typed_expr_even_if_unit d (TyOp(MutableSet,[module_;v;r],BListT))
                        else on_type_er (trace d) <| sprintf "The two sides in the module set have different types.\nExpected: %s\n     Got: %s" (show_typedexpr v_ty) (show_typedexpr r_ty)
                | x -> on_type_er (trace d) <| sprintf "Expected a type string as the input to a mutable heap module.\nGot: %s" (show_typedexpr x)
            | _ -> on_type_er (trace d) <| sprintf "Expected a heap mutable module, reference or an array the input to mutable set.\nGot: %s" (show_typedexpr a)

        let array_length d ar =
            let ar = tev d ar
            match get_type ar with
            | ArrayT(ArtDotNetHeap,t) -> make_tyv_and_push_typed_expr d (TyOp(ArrayLength,[ar],PrimT Int64T))
            | ArrayT(ArtDotNetReference,t) -> TyLit (LitInt64 1L)
            | _ -> on_type_er (trace d) <| sprintf "ArrayLength is only supported for .NET arrays. Got: %s" (show_typedexpr ar)

        let array_is d ar on_fail on_succ =
            match tev d ar with
            | TyV(_,ArrayT(t,_)) | TyT (ArrayT(t,_)) ->
                match t with
                | ArtCudaGlobal _ -> "CudaGlobal"
                | ArtCudaShared -> "CudaShared"
                | ArtCudaLocal -> "CudaLocal"
                | ArtDotNetHeap -> "DotNetHeap"
                | ArtDotNetReference -> "DotNetReference"
                |> (type_lit_create' << LitString)
                |> apply d (tev d on_succ)
            | x -> apply d (tev d on_fail) TyB

        let module_is_cps d a on_fail on_succ =
            match tev d a with
            | TyMap(_,MapTypeModule) | TyType(LayoutT(_,TyMap(_,MapTypeModule))) -> tev d on_succ
            | _ -> tev d on_fail

        let module_values d a =
            match tev d a |> layout_to_none' d with
            | TyMap(C env,MapTypeModule) as recf -> Map.foldBack (fun _ x s -> x :: s) env [] |> tyvv
            | x -> on_type_er (trace d) <| sprintf "Expected a module. Got: %s" (show_typedexpr x)

        let inline module_map_template is_filter d op a =
            match tev d op, tev d a |> layout_to_none' d with
            | op, TyMap(C env,MapTypeModule) & recf ->
                if is_filter then
                    let f k x = 
                        match apply d (apply d op (type_lit_create' (LitString k))) x with
                        | TyLit (LitBool x) -> x
                        | x -> on_type_er (trace d) "Expected a bool literal in ModuleFilter.\nGot: %s" (show_typedexpr x)
                    tymap(Map.filter f env |> Env, MapTypeModule)
                else
                    let f k x = apply d (apply d op (type_lit_create' (LitString k))) x |> destructure d
                    tymap(Map.map f env |> Env, MapTypeModule)
            | _, x ->
                on_type_er (trace d) <| sprintf "Expected a module in module map. Got: %s" (show_typedexpr x)

        let module_map x = module_map_template false x
        let module_filter x = module_map_template true x

        let inline module_fold_template map_fold d fold_op s m =
            match tev d fold_op, tev d s, tev d m |> layout_to_none' d with
            | fold_op, s, TyMap(C env,MapTypeModule) & recf -> map_fold fold_op s env
            | _,_,x -> on_type_er (trace d) <| sprintf "Expected a module on module fold. Got: %s" (show_typedexpr x)

        let module_foldl d = 
            let inline ap a b = apply d a b
            module_fold_template (fun fold_op -> Map.fold (fun s k v -> ap (ap (ap fold_op (type_lit_create' (LitString k))) s) v)) d

        let module_foldr d = 
            let inline ap a b = apply d a b
            module_fold_template (fun fold_op s env -> Map.foldBack (fun k v s -> ap (ap (ap fold_op (type_lit_create' (LitString k))) v) s) env s) d

        let module_length d a =
            match tev d a with
            | TyMap(C env, MapTypeModule) -> TyLit (LitInt64 (int64 env.Count))
            | x -> on_type_er (trace d) <| sprintf "Expected a module on module length. Got: %s" (show_typedexpr x)

        let module_has_member d a b =
            match tev d a, tev d b with
            | a, (TyV(_,LayoutT(_,TyMap(C env,MapTypeModule))) | (TyT(LayoutT(_,TyMap(C env,MapTypeModule)))) | TyMap(C env,MapTypeModule)) -> 
                match a with
                | TyT (LitT (LitString a)) -> TyLit (LitBool <| Map.containsKey a env)
                | x -> on_type_er (trace d) <| sprintf "Expecting a type literal as the first argument to ModuleHasMember.\nGot: %s" (show_typedexpr x)
            | _,x -> on_type_er (trace d) <| sprintf "Expecting a module as the second argument to ModuleHasMember.\nGot: %s" (show_typedexpr x)

        let module_member_cps d a b on_fail on_succ =
            match tev d b with
            | TyLit(LitString n) ->
                let inline member_miss _ = tev d on_fail
                apply_module member_miss member_miss (apply d (tev d on_succ)) d (tev d a) n
            | x -> on_type_er (trace d) <| sprintf "Expecting a string as the second argument to ModuleMemberCPS.\nGot: %s" (show_typedexpr x)

        let module_inject_cps d a b on_fail on_succ =
            match tev d b with
            | TypeString n ->
                let inline member_miss _ = tev d on_fail
                apply_module member_miss member_miss (apply d (tev d on_succ)) d (tev d a) n
            | x -> on_type_er (trace d) <| sprintf "Expecting a type string as the second argument to ModuleInjectCPS.\nGot: %s" (show_typedexpr x)

        let module_create d l =
            List.fold (fun env -> function
                | VV([Lit(LitString n, _); e],_) -> Map.add n (tev d e |> destructure d) env
                | VV([n; e],_) -> 
                    match tev d n with
                    | TypeString name -> Map.add name (tev d e |> destructure d) env
                    | x -> on_type_er (trace d) <| sprintf "Expected a type string literal in module create's injection. Got: %s" (show_typedexpr x)
                | _ -> failwith "impossible"
                ) Map.empty l
            |> fun x -> tymap(Env x, MapTypeModule)

        let module_add d name v s =
            match tev d s with
            | TyMap(C env, MapTypeModule) ->
                match tev2 d name v with
                | TypeString name, v -> tymap(Map.add name v env |> Env, MapTypeModule)
                | _ -> on_type_er (trace d) "Expected a type string as the first argument to ModuleAdd."
            | s -> on_type_er (trace d) <| sprintf "Expected a module as the third argument to ModuleAdd. Got: %s" (show_typedexpr s)

        let module_remove d name s =
            match tev d s with
            | TyMap(C env, MapTypeModule) ->
                match tev d name with
                | TypeString name -> tymap(Map.remove name env |> Env, MapTypeModule)
                | _ -> on_type_er (trace d) "Expected a type string as the first argument to ModuleRemove."
            | _ -> on_type_er (trace d) "Expected a module as the second argument to ModuleRemove."

        let module_with (d: LangEnv) l =
            let names, bindings =
                match l with
                | VV (l, _) :: bindings -> l, bindings
                | x :: bindings -> [x], bindings
                | _ -> failwith "Compiler error: Malformed ModuleWith."

            let inline layout_map cur_env name (on_succ: EnvTerm -> TypedExpr) =
                match Map.tryFind name cur_env with
                | Some recf ->
                    match recf with
                    | TyMap(env,MapTypeModule) -> on_succ env
                    | TyType(LayoutT(_,TyMap(_,MapTypeModule))) -> on_type_er (trace d) "For the sake of consistency directly updating a layout type is disallowed. Unseal it using 'indiv' first."
                    | _ -> on_type_er (trace d) <| sprintf "Variable %s is not a module." name
                | _ -> on_type_er (trace d) <| sprintf "Module %s is not bound in the environment." name

            let rec module_with_loop names (C cur_env) = 
                match names with
                | Lit(LitString name, _) :: names -> tymap (Map.add name (layout_map cur_env name (module_with_loop names)) cur_env |> Env, MapTypeModule)
                | x :: names ->
                    match tev d x with
                    | TypeString name -> tymap (Map.add name (layout_map cur_env name (module_with_loop names)) cur_env |> Env, MapTypeModule)
                    | _ -> on_type_er (trace d) "The expression in the module_with construct is not a type string."
                | [] -> 
                    let bind env name e =
                        match Map.tryFind name env with
                        | Some v -> {d with env = env_add "self" v d.env}
                        | None -> d
                        |> fun d -> Map.add name (tev d e |> destructure d) env
                    List.fold (fun env -> function
                        | VV([Lit(LitString name,_); e], _) -> bind env name e
                        | Op(ModuleWithout,[Lit(LitString name,_)],_) -> Map.remove name env
                        | VV([name; e],_) ->
                            match tev d name with
                            | TypeString name -> bind env name e
                            | x -> on_type_er (trace d) <| sprintf "Expected a type string literal in module with's injection. Got: %s" (show_typedexpr x)
                        | Op(ModuleWithout,[name],_) ->
                            match tev d name with
                            | TypeString name -> Map.remove name env
                            | x -> on_type_er (trace d) <| sprintf "Expected a type string literal in module without's injection. Got: %s" (show_typedexpr x)
                        | x -> failwithf "impossible\nGot: %A" x
                        ) cur_env bindings
                    |> fun env -> tymap(Env env, MapTypeModule)

            match names with
            | V(name, _) :: names -> layout_map (c d.env) name (module_with_loop names)
            | x :: names ->
                match tev d x with
                | TyMap(env,MapTypeModule) -> module_with_loop names env 
                | TyType(LayoutT(_,TyMap(_,MapTypeModule))) -> on_type_er (trace d) "For the sake of consistency directly updating a layout type is disallowed. Unseal it using 'indiv' first."
                | _ -> on_type_er (trace d) "The expression in the module_with construct is not a module."
            | x -> failwithf "Compiler error: Malformed ModuleWith."

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
                    | PrimT StringT -> string x |> LitString
                    | _ -> on_type_er (trace d) <| sprintf "Cannot convert the literal to the following type: %s" (show_ty tot)
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
                | TyLit (LitString a) -> conv_lit a
                | TyLit (LitBool _) -> on_type_er (trace d) "Cannot convert the bool to any type."
                | _ ->
                    let is_convertible_primt x =
                        match x with
                        | PrimT BoolT | PrimT StringT -> false
                        | PrimT _ -> true
                        | _ -> false
                    if is_convertible_primt fromt && is_convertible_primt tot then TyOp(UnsafeConvert,[to_;from],tot)
                    else on_type_er (trace d) <| sprintf "Cannot convert %s to the following type: %s" (show_typedexpr from) (show_ty tot)

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

        let sizeof d a = 
            match tev d a with
            | TyType (PrimT x) ->
                let size =
                    match x with
                    | Int8T -> sizeof<int8>
                    | Int16T -> sizeof<int16>
                    | Int32T -> sizeof<int32>
                    | Int64T -> sizeof<int64>
                    | UInt8T -> sizeof<uint8>
                    | UInt16T -> sizeof<uint16>
                    | UInt32T -> sizeof<uint32>
                    | UInt64T -> sizeof<uint64>
                    | Float32T -> sizeof<float32>
                    | Float64T -> sizeof<float>
                    | CharT -> sizeof<char>
                    | StringT -> sizeof<string>
                    | BoolT -> sizeof<bool>
                TyLit (LitInt64 (int64 size))
            | a -> TyOp(SizeOf,[a],PrimT Int64T)

        let macro op d t a = 
            let t, a = tev_seq d t, tev d a
            TyOp(op,[a],get_type t) |> make_tyv_and_push_typed_expr_even_if_unit d

        let to_var d x = tev d x |> make_tyv_and_push_typed_expr d
           
        let inline add_trace (d: LangEnv) x = {d with trace = x :: d.trace}

        match expr with
        | Lit (value, _) -> TyLit value
        | V (x, _) -> v_find d.env x (fun () -> on_type_er (trace d) <| sprintf "Variable %s not bound." x) (destructure d)
        | FunctionFilt(vars, pat, body, _) -> 
            let env = Map.filter (fun x _ -> Set.contains x vars) (c d.env)
            tymap(Env env, MapTypeFunction (pat, body))
        | Function _ -> failwith "Function not allowed in this phase as it tends to cause stack overflows in recursive scenarios."
        | Pattern _ -> failwith "Pattern not allowed in this phase as it tends to cause stack overflows when prepass is triggered in the match case."
        | ExprPos (p, _) -> tev (add_trace d p.Pos) p.Expression
        | VV (vars, _) -> List.map (tev d >> destructure d) vars |> tyvv
        | Open (a,b,vars,_) -> module_open d a b vars
        | Fix(name,body,_) ->
            match tev d body with
            | TyMap(env_term,MapTypeFunction core) -> tymap(env_term,MapTypeRecFunction(core,name))
            | x -> x
        | Op(op,vars,_) ->
            match op,vars with
            | (MacroFs | MacroCuda),[a;b] -> macro op d a b
            | Apply,[a;b] -> apply_tev d a b
            | StringLength,[a] -> string_length d a
            | StringFormat,[a;b] -> string_format d a b
            | StringConcat,[a;b] -> string_concat d a b
            | Case,[v;case] -> case_ d v case
            | CaseFoldLMap,[a;b;c] -> case_foldl_map d a b c
            | IfStatic,[cond;tr;fl] -> if_static d cond tr fl
            | While,[cond;body] -> while_ d cond body
            | JoinPointEntryMethod,[a] -> join_point_method d a
            | JoinPointEntryType,[a] -> join_point_type d a
            | JoinPointEntryCuda,[a] -> join_point_cuda d a
            | TermCast,[a;b] -> term_cast d a b
            | UnsafeConvert,[to_;from] -> unsafe_convert d to_ from
            | PrintStatic,[a] -> printfn "%s" (tev d a |> show_typedexpr); TyB
            | PrintEnv,[a] ->
                printfn "%A" (d.env)
                tev d a
            | (CudaTypeCreate | DotNetTypeCreate), [a] -> extern_type_create op d a
            | LayoutToNone,[a] -> layout_to_none d a
            | LayoutToStack,[a] -> layout_to LayoutStack d a
            | LayoutToPackedStack,[a] -> layout_to LayoutPackedStack d a
            | LayoutToHeap,[a] -> layout_to LayoutHeap d a
            | LayoutToHeapMutable,[a] -> layout_to LayoutHeapMutable d a
            | TypeLitCreate,[a] -> type_lit_create d a
            | TypeLitCast,[a] -> type_lit_cast d a
            | TypeLitIs,[a] -> type_lit_is d a
            | TypeLitCPS,[a;b;c;d'] -> type_lit_cps d a b c d'
            | Dynamize,[a] -> dynamize d a
            | ModuleCreate,l -> module_create d l
            | ModuleAdd,[a;b;c] -> module_add d a b c
            | ModuleRemove,[a;b] -> module_remove d a b
            | ModuleWith, l -> module_with d l
            | ModuleValues, [a] -> module_values d a
            | ModuleIsCPS,[a;b;c] -> module_is_cps d a b c
            | ModuleHasMember,[a;b] -> module_has_member d a b
            | ModuleMemberCPS,[a;b;c;d'] -> module_member_cps d a b c d'
            | ModuleInjectCPS,[a;b;c;d'] -> module_inject_cps d a b c d'
            | ModuleMap,[a;b] -> module_map d a b
            | ModuleFilter,[a;b] -> module_filter d a b
            | ModuleFoldL,[a;b;c] -> module_foldl d a b c
            | ModuleFoldR,[a;b;c] -> module_foldr d a b c
            | ModuleLength,[a] -> module_length d a
            | LitIs,[a] -> lit_is d a
            | CaseableIs,[a] -> caseable_is d a
            | BoxIs,[a] -> box_is d a
            | CaseableBoxIs,[a] -> caseable_box_is d a
            | BlittableIs,[a] -> blittable_is d a

            | ArrayCreate,[a;b] -> array_create' ArtDotNetHeap d a b
            | ArrayCreate,[ar_typ;a;b] -> array_create ar_typ d a b
            | ReferenceCreate,[a] -> reference_create d a
            | MutableSet,[a;b;c] -> mutable_set d a b c
            | ArrayLength,[a] -> array_length d a
            | ArrayIs,[a;b;c] -> array_is d a b c

            // Primitive operations on expressions.
            | Add,[a;b] -> prim_arith_op d a b Add
            | Sub,[a;b] -> prim_arith_op d a b Sub 
            | Mult,[a;b] -> prim_arith_op d a b Mult
            | Div,[a;b] -> prim_arith_op d a b Div
            | Mod,[a;b] -> prim_arith_op d a b Mod
            | Pow,[a;b] -> power d a b

            | LT,[a;b] -> prim_comp_op d a b LT
            | LTE,[a;b] -> prim_comp_op d a b LTE
            | EQ,[a;b] -> prim_comp_op d a b EQ
            | NEQ,[a;b] -> prim_comp_op d a b NEQ 
            | GT,[a;b] -> prim_comp_op d a b GT
            | GTE,[a;b] -> prim_comp_op d a b GTE
    
            | BitwiseAnd,[a;b] -> prim_bitwise_op d a b BitwiseAnd
            | BitwiseOr,[a;b] -> prim_bitwise_op d a b BitwiseOr
            | BitwiseXor,[a;b] -> prim_bitwise_op d a b BitwiseXor

            | ShiftLeft,[a;b] -> prim_shift_op d a b ShiftLeft
            | ShiftRight,[a;b] -> prim_shift_op d a b ShiftRight

            | ListCons,[a;b] -> list_cons d a b
            | ListTakeNCPS,[a;b;c;d'] -> list_taken d a b c d'
            | ListTakeNTailCPS,[a;b;c;d'] -> list_taken_tail d a b c d'

            | TypeAnnot,[a;b] -> type_annot d a b
            | TypeUnion,l -> type_union d l
            | TypeBox,[a;b] -> type_box d a b
            | TypeGet,[a] -> type_get d a
            | TypeSplit,[a] -> type_split d a

            | TermFunctionTypeCreate,[a;b] -> term_fun_type_create d a b
            | TermFunctionDomainRangeCPS,[a;b;c] -> term_fun_dom_range_cps d a b c

            | EqType,[a;b] -> eq_type d a b
            | Neg,[a] -> prim_un_numeric d a Neg
            | ErrorType,[a] -> tev d a |> fun a -> on_type_er (trace d) <| sprintf "%s" (show_typedexpr a)
            | ErrorNonUnit,[a] -> error_non_unit d a
            | ErrorPatClause,[] -> on_type_er (trace d) "Compiler error: The pattern matching clauses are malformed. PatClause is missing."
            | ErrorPatMiss,[a] -> tev d a |> fun a -> on_type_er (trace d) <| sprintf "Pattern miss error. The argument is %s" (show_typedexpr a)

            | Log,[a] -> prim_un_floating d a Log
            | Exp,[a] -> prim_un_floating d a Exp
            | Tanh,[a] -> prim_un_floating d a Tanh
            | Sqrt,[a] -> prim_un_floating d a Sqrt
            | NanIs,[a] -> is_nan d a
            | FailWith,[a;b] -> failwith_ d a b

            | UnsafeUpcastTo,[a;b] -> unsafe_upcast_to d a b
            | UnsafeDowncastTo,[a;b] -> unsafe_downcast_to d a b
            | UnsafeCoerceToArrayCudaGlobal,[a;b] -> unsafe_coerce_to_array_cuda_global d a b
            | SizeOf,[a] -> sizeof d a

            | InfinityF64,[] -> TyLit (LitFloat64 infinity)
            | InfinityF32,[] -> TyLit (LitFloat32 infinityf)

            | ToVar,[x] -> to_var d x
            
            | x -> failwithf "Compiler error: Missing Op case. %A" x

    // #Parsing
    let spiral_parse (Module(N(module_name,_,_,module_code)) & module_) = 
        let pos' (s: CharStream<_>) = module_, s.Line, s.Column
        let exprpos expr (s: CharStream<_>) = (expr |>> expr_pos (pos' s)) s
        let patpos expr (s: CharStream<_>) = (expr |>> pat_pos (pos' s)) s

        let rec spaces_template s = spaces >>. optional (followedByString "//" >>. skipRestOfLine true >>. spaces_template) <| s
        let spaces s = spaces_template s
    
        let is_identifier_starting_char c = isAsciiLetter c || c = '_'
        let is_identifier_char c = is_identifier_starting_char c || c = ''' || isDigit c 
        let is_separator_char c = 
            let inline f x = c = x
            f ' ' || f ',' || f ';' || f '\t' || f '\n' || f '\"' || f '(' || f '{' || f '['
        let is_separator_char_ext c = 
            let inline f x = c = x
            is_separator_char c || f '=' || f ':'
        let is_closing_parenth_char c = 
            let inline f x = c = x
            f ')' || f '}' || f ']'
        let is_operator_char c = (is_identifier_char c || is_separator_char c || is_closing_parenth_char c) = false

        let var_name_core s = (many1Satisfy2L is_identifier_starting_char is_identifier_char "identifier" .>> spaces) s

        let var_name =
            var_name_core >>=? function
                | "match" | "function" | "with" | "without" | "as" | "when" | "inl" | "met" | "inm" 
                | "inb" | "use" | "rec" | "if" | "then" | "elif" | "else" | "true" | "false" 
                | "open" | "openb" | "join" | "join_type" | "type" as x -> fun _ -> Reply(Error,messageError <| sprintf "%s not allowed as an identifier." x)
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
        let union = keywordString "\/"
        let dot = operatorChar '.'
        let prefix_dot = prefixOperatorChar '.'
        let pp = operatorChar ':'
        let pp' = skipChar ':' >>. spaces
        let semicolon' = operatorChar ';'
        let semicolon (s: CharStream<_>) = 
            if s.Line <> s.UserState.semicolon_line then semicolon' s
            else Reply(ReplyStatus.Error, messageError "cannot parse ; on this line") 
        let eq = operatorChar '=' 
        let eq' = skipChar '=' >>. spaces
        let bar = operatorChar '|' 
        let amphersand = operatorChar '&'
        let caret = operatorChar '^'
        let lam = operatorString "->"
        let arr = operatorString "=>"
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
        let cons = operatorString "::"
        let active_pat = prefixOperatorChar '!'
        let not_ = active_pat
        let part_active_pat = prefixOperatorChar '@'
        let inject = prefixOperatorChar '$'
        let wildcard = operatorChar '_'

        let pbool = ((keywordString "false" >>% LitBool false) <|> (keywordString "true" >>% LitBool true)) .>> spaces

        let unary_minus_check_precondition s = previousCharSatisfiesNot (is_separator_char_ext >> not) s
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

        let pat_e = wildcard >>% PatE
        let pat_var = var_name |>> PatVar
        let pat_expr expr = (var_name |>> v) <|> rounds expr
        let pat_tuple pattern = sepBy1 pattern comma |>> function [x] -> x | x -> PatTuple x
        let pat_cons pattern = sepBy1 pattern cons |>> function [x] -> x | x -> PatCons x
        let pat_rounds pattern = rounds (pattern <|>% PatTuple [])
        let pat_type expr pattern = tuple2 pattern (opt (pp >>. pat_expr expr)) |>> function a,Some b as x-> PatTypeEq(a,b) | a, None -> a
        let pat_active expr pattern = 
            let active_pat = choice [active_pat >>% PatActive; part_active_pat >>% PatPartActive]
            pipe3 active_pat (pat_expr expr) pattern <| fun c name pat -> c (name,pat)
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
            let pat = pipe2 lit_var (opt (pp' >>. pattern)) (fun lit pat ->
                let lit = PatTypeLit lit
                match pat with
                | Some pat -> PatTuple [lit; pat]
                | None -> lit)
            squares (many pat) |>> PatTuple

        let pat_closure pattern = sepBy1 pattern arr |>> List.reduceBack (fun a b -> PatTypeTermFunction(a,b))

        let (^<|) a b = a b // High precedence, right associative <| operator

        let inline pat_module_nested x b = List.foldBack (fun x b -> PatModuleRebind(x,PatAnd [PatVar x; b])) x b

        let rec pat_module_outer expr s = 
            curlies
                (pipe2 
                    (opt (attempt (sepBy1 var_name dot .>> with_))) (pat_module_body expr)
                    (fun n bindings ->
                        match n with
                        | None -> PatModuleIs bindings
                        | Some [] -> failwith "impossible"
                        | Some (n :: n') -> PatAnd [PatVar n; pat_module_nested n' bindings]))
                s

        and pat_module_inner expr s = 
            curlies (pipe2 (sepBy1 var_name dot .>> with_) (pat_module_body expr) pat_module_nested) s

        and pat_module_body expr s =
            let pat_name = var_name |>> PatModuleMember
            let pat_semicolon = semicolon' >>. pat_module_body expr

            let inline pat_inject pat = 
                pipe2 (inject >>. var_name) (eq' >>. patterns_template expr) (fun a b -> PatModuleInject(a, b))
                <|> pat

            let inline pat_bind pat = 
                pipe2 pat (opt (eq' >>. patterns_template expr))
                    (fun v -> function
                        | None -> v
                        | Some pat ->
                            let rec loop = function
                                | PatModuleMember name -> PatModuleRebind(name,pat)
                                | PatModuleRebind (name,_) as v  -> PatAnd [v; PatModuleRebind(name,pat)]
                                | PatModuleIs x -> PatModuleIs (loop x)
                                | PatAnd l -> PatAnd <| List.map loop l
                                | PatOr l -> PatOr <| List.map loop l
                                | PatXor l -> PatXor <| List.map loop l
                                | PatNot x -> PatNot (loop x)
                                | x -> failwithf "Compiler error: Pattern %A not supported." x
                            loop v
                            )
            let inline pat_template sep con pat = sepBy1 pat sep |>> function [x] -> x | x -> con x
            let inline pat_not pat = (not_ >>. pat |>> PatNot) <|> pat
            let inline pat_xor pat = pat_template caret PatXor pat
            let inline pat_or pat = pat_template bar PatOr pat
            let inline pat_and pat = many pat |>> PatAnd
            pat_and ^<| pat_or ^<| pat_xor ^<| pat_not ^<| pat_inject ^<| pat_bind ^<| choice [pat_semicolon; pat_name; pat_module_inner expr; rounds (pat_module_body expr)] 
            <| s

        and patterns_template expr s = // The order in which the pattern parsers are chained in determines their precedence.
            let inline recurse s = patterns_template expr s
            pat_when expr ^<| pat_as ^<| pat_or ^<| pat_tuple ^<| pat_cons ^<| pat_and ^<| pat_type expr ^<| pat_closure
            ^<| choice [|pat_active expr recurse; pat_e; pat_var; pat_type_lit; pat_lit 
                         pat_rounds recurse; pat_named_tuple recurse; pat_module_outer expr|] <| s

        let inline patterns expr s = patpos (patterns_template expr) s
    
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
            pipe4 (f' "if") (f "then") (many (f "elif" .>>. f "then")) (opt (f "else"))
                (fun cond tr elifs fl -> 
                    let fl = 
                        match fl with Some x -> x | None -> B
                        |> List.foldBack (fun (cond,tr) fl -> op(IfStatic,[cond;tr;fl])) elifs
                    op(IfStatic,[cond;tr;fl]))
            <| s

        let poperator (s: CharStream<Userstate>) = many1Satisfy is_operator_char .>> spaces <| s
        let var_op_name = var_name <|> rounds (poperator <|> var_name_core)

        let inl_pat' (args: Pattern list) body = List.foldBack inl_pat args body
        let meth_pat' args body = inl_pat' args (join_point_entry_method body)

        let inline statement_expr expr = eq' >>. expr
        let case_inl_pat_statement expr = pipe2 (inl_ >>. patterns expr) (statement_expr expr) lp
        let case_inl_name_pat_list_statement expr = pipe3 (inl_ >>. var_op_name) (pattern_list expr) (statement_expr expr) (fun name pattern body -> l name (inl_pat' pattern body)) 
        let case_inl_rec_name_pat_list_statement expr = pipe3 (inl_rec >>. var_op_name) (pattern_list expr) (statement_expr expr) (fun name pattern body -> l_rec name (inl_pat' pattern body))
        
        let case_met_pat_statement expr = pipe2 (met_ >>. patterns expr) (statement_expr expr) <| fun pattern body -> lp pattern (join_point_entry_method body)
        let case_met_name_pat_list_statement expr = pipe3 (met_ >>. var_op_name) (pattern_list expr) (statement_expr expr) (fun name pattern body -> l name (meth_pat' pattern body))
        let case_met_rec_name_pat_list_statement expr = pipe3 (met_rec >>. var_op_name) (pattern_list expr) (statement_expr expr) <| fun name pattern body -> l_rec name (meth_pat' pattern body)

        let case_open expr = 
            var_name_core >>=? function
                | "open" -> expr |>> module_open
                | "openb" -> expr |>> module_openb
                | x -> fun _ -> Reply(Error,expected "open or openb")
        let case_inm_pat_statement expr = pipe2 (inm_ >>. patterns expr) (eq' >>. expr) inmp
        let case_use_pat_statement expr = pipe2 (use_ >>. patterns expr) (eq' >>. expr) usep
        let case_inn_pat_statement expr = pipe2 (inb_ >>. patterns expr) (eq' >>. expr) inbp

        let statements expr = 
            [case_inl_pat_statement; case_inl_name_pat_list_statement; case_inl_rec_name_pat_list_statement
             case_met_pat_statement; case_met_name_pat_list_statement; case_met_rec_name_pat_list_statement
             case_use_pat_statement; case_inm_pat_statement; case_inn_pat_statement
             case_open]
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
            let clause = pipe2 (many1 (patterns expr) .>> lam) expr <| fun pat body ->
                match pat with
                | x :: xs -> x, inl_pat' xs body
                | _ -> failwith "impossible"

            let pat_function l = pattern (PatClauses l)
            let pat_match x l = ap (pat_function l) x

            let clauses i = 
                let bar s = expr_indent i (<=) bar s
                optional bar >>. sepBy1 (expr_indent i (<=) clause) bar
            let get_col (s: CharStream<_>) = Reply(col s)

            match match_type with
            | true -> // function
                (function_ >>. get_col >>=? clauses |>> pat_function) s    
            | false -> // match
                pipe2 (match_ >>. expr .>> with_) (get_col >>=? clauses) pat_match s

        let case_typeinl expr (s: CharStream<_>) = case_typex true expr s
        let case_typecase expr (s: CharStream<_>) = case_typex false expr s

        let case_module expr s =
            let mp_binding (n,e) = vv [lit_string n; e]
            let mp_binding_inject n e = vv [v n; e]
            let mp_without n = op(ModuleWithout,[lit_string n])
            let mp_without_inject n = op(ModuleWithout,[v n])
            let mp_create l = op(ModuleCreate,l)
            let mp_with init names l = 
                let l = List.concat l
                match names with
                | _ :: _ -> op(ModuleWith,vv (init :: names) :: l)
                | _ -> op(ModuleWith,init :: l)

            let inline parse_binding_with s =
                let i = col s
                let line = s.Line
                let inline body s = (eq' >>. expr_indent i (<) (set_semicolon_level_to_line line expr)) s
                let a s = 
                    pipe2 var_op_name (opt body)
                        (fun a -> function
                            | None -> mp_binding (a, v a)
                            | Some b -> mp_binding (a, b)) s
                let b s = pipe2 (inject >>. var_op_name) body mp_binding_inject s
                (a <|> b) s

            let parse_binding_without s = 
                let a s = var_op_name |>> mp_without <| s
                let b s = inject >>. var_op_name |>> mp_without_inject <| s
                (a <|> b) s

            let module_create_with s = (parse_binding_with .>> optional semicolon') s
            let module_create_without s = (parse_binding_without .>> optional semicolon') s

            let module_with = 
                let withs s = (with_ >>. many1 module_create_with) s
                let withouts s = (without >>. many1 module_create_without) s 
                pipe3 ((var_name |>> v) <|> rounds expr)
                    (many (dot >>. ((var_name |>> lit_string) <|> rounds expr)))
                    (many1 (withs <|> withouts))
                    mp_with

            let module_create = many module_create_with |>> mp_create
                
            curlies (attempt module_with <|> module_create) <| s

        let case_named_tuple expr =
            let pat s = 
                let i = col s
                let line = line s
                pipe2 lit_var (opt (pp' >>. expr_indent i (<) (set_semicolon_level_to_line line expr))) (fun lit expr ->
                    let tup = type_lit_lift lit
                    match expr with
                    | Some expr -> vv [tup; expr]
                    | None -> tup
                    ) s
            squares (many (pat .>> optional semicolon')) |>> vv

        let case_negate expr = unary_minus_check >>. expr |>> (ap (v "negate"))
        let case_join_point expr = keywordString "join" >>. expr |>> join_point_entry_method
        let case_join_point_type expr = keywordString "join_type" >>. expr |>> join_point_entry_type
        let case_type expr = keywordString "type" >>. expr |>> type_get
        let case_cuda expr = keywordString "cuda" >>. expr |>> inl' ["blockDim";"gridDim"]

        let inbuilt_op_core c = operatorChar c >>. var_name
        let case_inbuilt_op expr =
            let rec loop = function
                | ExprPos (x,_) -> loop x.Expression
                | VV (l, _) -> l 
                | x -> [x]
            let body c = inbuilt_op_core c .>>. rounds (expr <|>% B)
            body '!' >>= fun (a, b) ->
                match string_to_op a with
                | true, op' -> op(op',loop b) |> preturn
                | false, _ -> failFatally <| sprintf "%s not found among the inbuilt Ops." a

        let case_parser_macro expr = 
            inbuilt_op_core '@' >>= fun a ->
                let f x = LitString x |> lit |> preturn
                match a with
                | "CubPath" -> f settings.cub_path
                | "CudaPath" -> f settings.cuda_path
                | "CudaNVCCOptions" -> f settings.cuda_nvcc_options
                | "VSPath" -> f settings.vs_path
                | "VSPathVcvars" -> f settings.vs_path_vcvars
                | "VcvarsArgs" -> f settings.vcvars_args
                | "VSPathCL" -> f settings.vs_path_cl
                | "VSPathInclude" -> f settings.vs_path_include
                | a -> failFatally <| sprintf "%s is not a valid parser macro." a

        let case_lit_lift expr = 
            let var = var_name |>> (LitString >> type_lit_lift)
            let lit = expr |>> type_lit_lift'
            prefix_dot >>. (var <|> lit)

        let binary_lit_lift expr =
            let is_immeditate_expr x = is_closing_parenth_char x || is_identifier_char x
            sepBy1 expr (previousCharSatisfies is_immeditate_expr >>. prefix_dot) 
            |>> List.reduce (fun a b ->
                match b with
                | V (x, _) -> type_lit_lift (LitString x)
                | x -> type_lit_lift' x
                |> ap a
                )

        let inline tuple_template fin sep expr (s: CharStream<_>) =
            let i = (col s)
            let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
            sepBy1 (expr_indent expr) (expr_indent sep)
            |>> function [x] -> x | x -> fin x
            <| s

        let type_union expr s = tuple_template type_union union expr s
        let tuple expr s = tuple_template vv comma expr s

        let rec expressions expr s = 
            [
            case_join_point; case_join_point_type; case_type
            case_cuda; case_inbuilt_op; case_parser_macro
            case_inl_pat_list_expr; case_met_pat_list_expr; case_lit; case_if_then_else
            case_rounds; case_typecase; case_typeinl; case_var; case_module; case_named_tuple
            case_negate << expressions; case_lit_lift << expressions
            ] |> List.map (fun x -> x expr |> attempt) |> choice <| s
 
        let process_parser_exprs exprs = 
            let error_statement_in_last_pos _ = Reply(Error,messageError "Statements not allowed in the last position of a block.")
            let rec process_parser_exprs on_succ = function
                | [ParserExpr a] -> on_succ a
                | [ParserStatement _] -> error_statement_in_last_pos
                | ParserStatement a :: xs -> process_parser_exprs (a >> on_succ) xs
                | ParserExpr a :: xs -> process_parser_exprs (l "" (error_non_unit a) >> on_succ) xs
                | [] -> on_succ B
            
            process_parser_exprs preturn (List.concat exprs)

        let indentations statements expressions (s: CharStream<Userstate>) =
            let i = col s
            let inline if_ op tr s = expr_indent i op tr s

            let inline many_semis expr = many (if_ (<) semicolon >>. if_ (<) expr)
            let inline many_indents expr = many1 (if_ (=) (pipe2 expr (many_semis expr) (fun a b -> a :: b)))
            many_indents ((statements |>> ParserStatement) <|> (exprpos expressions |>> ParserExpr)) >>= process_parser_exprs <| s

        let application expr (s: CharStream<_>) =
            let i = col s
            let expr_up (s: CharStream<_>) = expr_indent i (<) expr s
            pipe2 expr (many expr_up) (List.fold ap) s

        let mset recurse expr (s: CharStream<_>) = 
            let i = col s
            let line = s.Line
            let expr_indent expr (s: CharStream<_>) = expr_indent i (<) expr s
            let op =
                (set_ref >>% fun l r -> op(MutableSet,[l;B;r]) |> preturn)
                <|> (set_array >>% fun l r -> 
                        let rec loop = function
                            | ExprPos(p,_) -> loop p.Expression
                            | Op(Apply,[a;b],_) -> op(MutableSet,[a;b;r]) |> preturn
                            | _ -> fail "Expected two arguments on the left of <-."
                        loop l)

            (tuple2 expr (opt (expr_indent op .>>. expr_indent (set_semicolon_level_to_line line recurse)))
            >>= function 
                | a,Some(f,b) -> f a b
                | a,None -> preturn a) s

        let annotations expr (s: CharStream<_>) = 
            let i = (col s)
            let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
            pipe2 (expr_indent expr) (opt (expr_indent pp' >>. expr_indent expr))
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
                f "=>" 0; f ":>" 35; f ":?>" 35; f "**" 80
         
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
                                | "&&" -> expr_pos p (op(IfStatic, [a; b; lit (LitBool false)]))
                                | "||" -> expr_pos p (op(IfStatic, [a; lit (LitBool true); b]))
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
            let expressions s = mset expr ^<| type_union ^<| tuple ^<| operators ^<| application ^<| binary_lit_lift ^<| expressions expr <| s
            let statements s = statements expr <| s
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

    let inline print_args' print_tyv args = 
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

    let inline define_layoutt ty print_tag_env print_type_definition layout expr =
        if (get_type expr |> is_unit) = false then
            let name = print_tag_env (Some layout) ty
            let {call_args=fv},_ = renamer_apply_typedexpr expr
            let tys = List.foldBack (fun (_,x) s -> define_mem s x) fv ([],0) |> fst |> List.rev
            print_type_definition (Some layout) name tys

    let print_unescaped_string (x: string) =
        let strb = StringBuilder(x.Length)
        String.iter (function
            | '"' -> strb.Append "\\\"" 
            | '\t' -> strb.Append "\\t"
            | '\n' -> strb.Append "\\n"
            | '\r' -> strb.Append "\\r"
            | '\\' -> strb.Append "\\\\"
            | x -> strb.Append x
            >> ignore 
            ) x
        sprintf "\"%s\"" (strb.ToString())

    // #Cuda
    let spiral_cuda_codegen (definitions_queue: Queue<TypeOrMethod>) = 
        let buffer_forward_declarations = ResizeArray()
        let buffer_type_definitions = ResizeArray()
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

        let rec print_type restrict_array = function
            | Unit -> "void"
            | MapT _ as x -> print_tag_env None x
            | LayoutT ((LayoutStack | LayoutPackedStack) as layout, _) as x -> print_tag_env (Some layout) x
            | ListT _ as x -> print_tag_tuple x
            | UnionT _ as x -> print_tag_union x
            | ArrayT((ArtCudaLocal | ArtCudaShared | ArtCudaGlobal _),t) -> 
                if restrict_array then sprintf "%s * __restrict__" (print_type false t)
                else sprintf "%s *" (print_type false t)
            | ArrayT _ -> failwith "Not implemented."
            | LayoutT (_, _) | RecT _ | DotNetTypeT _ as x -> failwithf "%s is not supported on the Cuda side." (show_ty x)
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
            | CudaTypeT x -> codegen_macro (codegen' {branch_return=id; trace=[]}) (print_type false) x
            | LitT _ -> failwith "Should be covered in Unit."
        and print_tyv_with_type restrict_array (tag,ty as v) = sprintf "%s %s" (print_type restrict_array ty) (print_tyv v)
        and codegen' ({branch_return=branch_return; trace=trace} as d) expr =
            let inline codegen expr = codegen' {d with branch_return=id} expr

            //let inline print_method_definition_args x = print_args' print_tyv_with_type x
            let inline print_join_point_args x = 
                let print_with_error_checking x = print_type false (snd x) |> ignore; print_tyv x
                print_args' print_with_error_checking x

            let print_type_array = function // C syntax sucks.
                | ArrayT(ArtCudaLocal,t) -> print_type false t
                | ArrayT(ArtCudaShared,t) -> sprintf "__shared__ %s" (print_type false t)
                | t -> print_type false t
            let print_tyv_with_array (tag,ty as v) = sprintf "%s %s" (print_type_array ty) (print_tyv v)

            let print_value = function
                | LitUInt8 x -> string x 
                | LitUInt16 x -> string x 
                | LitUInt32 x -> string x 
                | LitUInt64 x -> string x 
                | LitInt8 x -> string x
                | LitInt16 x -> string x
                | LitInt32 x -> string x
                | LitInt64 x -> string x
                | LitFloat32 x -> 
                    if x = infinityf then "__int_as_float(0x7f800000)"
                    elif x = -infinityf then "__int_as_float(0xff800000)"
                    elif x = nanf then "__int_as_float(0x7fffffff)"
                    else string x
                | LitFloat64 x ->
                    if x = infinity then "__longlong_as_double(0x7ff0000000000000ULL)"
                    elif x = -infinity then "__longlong_as_double(0xfff0000000000000ULL)"
                    elif x = nan then "__longlong_as_double(0xfff8000000000000ULL)"
                    else string x
                | LitBool x -> if x then "1" else "0"
                | LitChar x -> string (int x)
                | LitString x -> print_unescaped_string x
                    //on_type_er trace "String literals are not supported on the Cuda side."

            let assign_to tyv = function
                | "" as x -> x
                | x -> sprintf "%s = %s" tyv x

            let inline if_ codegen' cond tr fl =
                sprintf "if (%s) {" (codegen cond) |> state_new
                enter <| fun _ -> codegen' tr
                "} else {" |> state_new
                enter <| fun _ -> codegen' fl
                "}" |> state_new

            /// This thing is only here until NVCC gets its act together.
            let inline while_ cond body =
                sprintf "while (%s) {" (codegen cond) |> state_new
                enter <| fun _ -> codegen body
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
                            if is_unit case_ty = false then sprintf "%s %s = %s.data.%s" (print_type false case_ty) (codegen case) v (print_case i) |> state
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
                print_tyv_with_type false tyv |> state
                f (codegen' {d with branch_return = assign_to (print_tyv tyv)})

            try
                match expr with
                | TyT Unit | TyV (_, Unit) -> ""
                | TyT t -> //on_type_er trace <| sprintf "Usage of naked type %s as an instance on the term level is invalid." t
                    printfn "Error: Naked type on the term level has been generated on the Cuda side. Check the code for the exact location of it."
                    sprintf "naked_type /*%s*/" (print_type false t)
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
                | TyLet(tyv,TyOp(IfStatic,[cond;tr;fl],t),rest,_,trace) -> 
                    print_scope tyv if_ cond tr fl
                    codegen' {d with trace=trace} rest
                | TyLet(tyv,TyOp(Case,v :: cases,t),rest,_,trace) -> 
                    print_scope tyv match_with v cases
                    codegen' {d with trace=trace} rest
                | TyLet(tyv & (tag,_),b,rest,_,trace) -> 
                    let _ = 
                        let d = {d with branch_return=id; trace=trace}
                        match b with
                        | TyOp(ArrayCreate,[a],t) -> sprintf "%s[%s]" (print_tyv_with_array (tag,t)) (codegen' d a)
                        | _ -> sprintf "%s = %s" (print_tyv_with_type false tyv) (codegen' d b) 
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
                    | IfStatic,[cond;tr;fl] -> if_ (codegen' d) cond tr fl; ""
                    | While,[cond;body] -> while_ cond body; ""
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
                    | Pow,[a;b] -> sprintf "pow(%s, %s)" (codegen a) (codegen b)
                    | LT,[a;b] -> sprintf "(%s < %s)" (codegen a) (codegen b)
                    | LTE,[a;b] -> sprintf "(%s <= %s)" (codegen a) (codegen b)
                    | EQ,[a;b] -> sprintf "(%s == %s)" (codegen a) (codegen b)
                    | NEQ,[a;b] -> sprintf "(%s != %s)" (codegen a) (codegen b)
                    | GT,[a;b] -> sprintf "(%s > %s)" (codegen a) (codegen b)
                    | GTE,[a;b] -> sprintf "(%s >= %s)" (codegen a) (codegen b)
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
                            let args = List.map print_tyv fv |> List.rev |> String.concat ", "
                            sprintf "make_%s(%s)" (print_tag_env (layout_from_op op |> Some) t) args
                        | LayoutToHeap | LayoutToHeapMutable -> on_type_er trace "Heapify is unsupported on the Cuda side."
                        | _ -> failwith "impossible"
                    | Log,[x] -> sprintf "log(%s)" (codegen x)
                    | Exp,[x] -> sprintf "exp(%s)" (codegen x)
                    | Tanh,[x] -> sprintf "tanh(%s)" (codegen x)
                    | Sqrt,[x] -> sprintf "sqrt(%s)" (codegen x)
                    | NanIs,[x] -> sprintf "isnan(%s)" (codegen x)
                    | FailWith,[x] -> 
                        if settings.cuda_assert_enabled then
                            sprintf "printf(%s)" (codegen x) |> state
                            sprintf "assert(false)" |> state
                        else
                            sprintf "// %s" (codegen x) |> state_new
                        ""
                    | MacroCuda,[a] -> codegen_macro codegen (print_type false) a
                    | SizeOf,[TyType a] -> sprintf "(sizeof %s)" (print_type false a)

                    | x -> failwithf "Compiler error: Missing TyOp case. %A" x
                    |> branch_return
            with 
            | :? TypeError -> reraise()
            | e -> on_type_er trace e.Message

        let print_closure_type_definition name (a,r) =
            let ret_ty = print_type false r
            let ty = tuple_field_ty a |> List.map (print_type false) |> String.concat ", "
            sprintf "typedef %s(*%s)(%s)" ret_ty name ty |> state

        let print_union_definition name tys =
            sprintf "struct %s {" name |> state_new
            enter' <| fun _ ->
                "int tag" |> state
                "union {" |> state_new
                enter' <| fun _ ->
                    Array.iteri (fun i t -> 
                        if is_unit t = false then
                            sprintf "%s %sCase%i" (print_type false t) name i |> state
                        ) tys
                "} data" |> state
            "}" |> state

            Array.iteri (fun i t ->
                let is_unit_false = is_unit t = false
                let case_name = sprintf "%sCase%i" name i
                if is_unit_false then sprintf "__device__ __forceinline__ %s make_%s(%s v) {" name case_name (print_type false t) |> state_new
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
                    sprintf "%s %s" (print_type false ty) name
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
                let args = print_args' (print_tyv_with_type true) fv
                if is_forward_declaration then
                    sprintf "%s %s %s(%s)" prefix (print_type false (get_type body)) method_name args |> state
                else
                    sprintf "%s %s %s(%s) {" prefix (print_type false (get_type body)) method_name args |> state_new
                    print_body()
                    "}" |> state_new

            match join_point_type with
            | JoinPointClosure | JoinPointMethod -> print_method "__device__"
            | JoinPointCuda -> print_method "__global__"
            | JoinPointType -> ()

        /// Flattens the types inside out as it encounters them.
        let definitions_set_printed = h0()
        let rec collect_definition x: TypeOrMethod list = 
            let inline f x = collect_definition (TomType x)
            if definitions_set_printed.Add x then
                match x with
                | TomJP (join_point_type,key) ->
                    let x' = 
                        match join_point_type with
                        | JoinPointMethod -> 
                            match join_point_dict_method.[key] with
                            | JoinPointDone(a,b) -> a
                            | _ -> failwith "impossible"
                        | JoinPointClosure -> 
                            match join_point_dict_closure.[key] with
                            | JoinPointDone(i,a,b) -> i @ a
                            | _ -> failwith "impossible"
                        | JoinPointCuda -> 
                            match join_point_dict_cuda.[key] with
                            | JoinPointDone(a,b) -> a
                            | _ -> failwith "impossible"
                        | JoinPointType -> failwith "impossible"
                        |> List.collect (f << snd)
                    x :: x'
                | TomType ty ->
                    match ty with
                    | ListT tys -> x :: (List.collect f tys)
                    | MapT(tys, _) -> x :: (Map.toList tys |> List.collect (f << snd))
                    | LayoutT (_, expr) ->
                        let {call_args=x'},_ = renamer_apply_typedexpr expr
                        x :: (List.collect (f << snd) x')
                    | UnionT tys -> x :: (Set.toList tys |> List.collect f)
                    | TermFunctionT(a,b) -> x :: f a  @ f b
                    | _ -> []
            else
                []

        let print_definition = function
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
                | LayoutT ((LayoutStack | LayoutPackedStack) as layout, expr) ->
                    define_layoutt ty print_tag_env print_type_definition layout expr
                | UnionT tys as x -> print_union_definition (print_tag_union x) (Set.toArray tys)
                | TermFunctionT(a,r) as x -> print_closure_type_definition (print_tag_closure x) (a,r)
                | _ -> failwith "impossible"
                move_to buffer_type_definitions buffer_temp


        while definitions_queue.Count > 0 do
            let x = definitions_queue.Dequeue() |> collect_definition
            List.foldBack (fun x _ -> print_definition x) x ()

        "module SpiralExample.Main" |> state_new
        sprintf "let %s = \"\"\"" cuda_kernels_name |> state_new
        settings.cuda_includes |> List.iter (sprintf "#include \"%s\"" >> state_new)
        //if settings.cuda_assert_enabled = false then "#define NDEBUG" |> state_new
        "#include <assert.h>" |> state_new
        state_new ""
        "extern \"C\" {" |> state_new
        enter' <| fun _ ->
            move_to buffer_temp buffer_type_definitions
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

        let rec print_type = function
            | Unit -> "unit"
            | MapT _ as x -> print_tag_env None x
            | LayoutT (layout, _) as x -> print_tag_env (Some layout) x
            | ListT _ as x -> print_tag_tuple x
            | UnionT _ as x -> print_tag_union x
            | RecT _ as x -> print_tag_rec x
            | ArrayT(ArtDotNetReference,t) -> sprintf "(%s ref)" (print_type t)
            | ArrayT(ArtDotNetHeap,t) -> sprintf "(%s [])" (print_type t)
            | ArrayT(ArtCudaGlobal t,_) -> print_type t
            | ArrayT((ArtCudaShared | ArtCudaLocal),_) -> failwith "Cuda local and shared arrays cannot be used on the F# side."
            | TermFunctionT(a,b) -> 
                let a = 
                    tuple_field_ty a |> List.map print_type |> String.concat " * "
                    |> function "" -> "unit" | x -> x
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
            | DotNetTypeT x -> codegen_macro (codegen' []) print_type x
            | CudaTypeT _ -> failwith "Cuda types are not allowed on the F# side."
            | LitT _ -> failwith "Should be covered in Unit."

        and print_tyv_with_type (tag,ty as v) = sprintf "(%s: %s)" (print_tyv v) (print_type ty)
        and print_args x = print_args' print_tyv_with_type x

        and codegen' trace expr =
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
                | LitFloat32 x -> 
                    if x = infinityf then "infinityf"
                    elif x = -infinityf then "-infinityf"
                    elif x = nanf then "nanf"
                    else sprintf "%ff" x
                | LitFloat64 x ->
                    if x = infinity then "infinity"
                    elif x = -infinity then "-infinity"
                    elif x = nan then "nan"
                    else sprintf "%f" x
                | LitString x -> print_unescaped_string x
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

            let inline enter_handle_unit f = enter <| fun _ -> handle_unit_in_last_position f
            let if_ cond tr fl =
                sprintf "if %s then" (codegen cond) |> state
                enter_handle_unit <| fun _ -> codegen tr
                "else" |> state
                enter_handle_unit <| fun _ -> codegen fl

            let make_struct x = make_struct codegen x

            let array_create size = function
                | ArrayT(_,t) -> sprintf "Array.zeroCreate<%s> (System.Convert.ToInt32(%s))" (print_type t) (codegen size)
                | _ -> failwith "impossible"

            let reference_create x = sprintf "(ref %s)" (codegen x)
            let array_index ar idx = sprintf "%s.[int32 %s]" (codegen ar) (codegen idx)
            let array_length ar = sprintf "%s.LongLength" (codegen ar)
            let reference_index x = sprintf "(!%s)" (codegen x)

            let layout_heap_mutable_set module_ l r = 
                let {call_args=l},_ = renamer_apply_typedexpr l
                let {call_args=r},_ = renamer_apply_typedexpr r
                let module_ = codegen module_
                List.iter2 (fun (l,_) r ->
                    sprintf "%s.mem_%i <- %s" module_ l (print_tyv r) |> state
                    ) l r
            let array_set ar idx r = sprintf "%s <- %s" (array_index ar idx) (codegen r) |> state
            let reference_set l r = sprintf "%s := %s" (codegen l) (codegen r) |> state

            let string_length str = sprintf "(int64 %s.Length)" (codegen str)
            let string_index str idx = sprintf "%s.[int32 %s]" (codegen str) (codegen idx)
            let string_slice str a b = sprintf "%s.[int32 %s..int32 %s]" (codegen str) (codegen a) (codegen b)
            let string_format = function
                | format :: l ->
                    match l with
                    | [a;b;c] -> sprintf "System.String.Format(%s,%s,%s,%s)" (codegen format) (codegen a) (codegen b) (codegen c)
                    | [a;b] -> sprintf "System.String.Format(%s,%s,%s)" (codegen format) (codegen a) (codegen b)
                    | [a] -> sprintf "System.String.Format(%s,%s)" (codegen format) (codegen a)
                    | [] -> sprintf "System.String.Format(%s)" (codegen format)
                    | l -> 
                        let l = List.map codegen l |> String.concat "; "
                        sprintf "System.String.Format(%s,([|%s|] : obj[]))" (codegen format) l 
                | _ -> failwith "impossible"

            let string_concat = function
                | [sep; TyList l] -> 
                    let l = List.map codegen l |> String.concat "; "
                    sprintf "String.concat %s [|%s|]" (codegen sep) l 
                | [sep; x] -> sprintf "String.concat %s %s" (codegen sep) (codegen x)
                | _ -> failwith "impossible"

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
                        enter_handle_unit <| fun _ -> codegen body
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
                | TyT t -> //on_type_er trace <| sprintf "Usage of naked type %s as an instance on the term level is invalid." t
                    printfn "Error: Naked type detected on the F# side. Please check the generated code for details."
                    sprintf "naked_type (*%s*)" (print_type t)
                | TyV v -> print_tyv v
                | TyLet(tyv,b,TyV tyv',_,trace) when tyv = tyv' -> codegen' trace b
                | TyState(b,rest,_,trace) ->
                    match b with
                    | TyOp(MutableSet,[ar;idx;b],_) ->
                        match get_type ar with
                        | ArrayT(ArtDotNetReference,_) -> reference_set ar b
                        | ArrayT(ArtDotNetHeap,_) -> array_set ar idx b
                        | LayoutT(LayoutHeapMutable,_) -> layout_heap_mutable_set ar idx b
                        | _ -> failwith "impossible"
                    | _ ->
                        let b = codegen' trace b
                        if b <> "" then sprintf "%s" b |> state
                    codegen' trace rest
                | TyLet(tyv,TyOp(IfStatic,[cond;tr;fl],t),rest,_,trace) -> print_scope tyv (fun _ -> if_ cond tr fl); codegen' trace rest
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
                    | IfStatic,[cond;tr;fl] -> if_ cond tr fl; ""
                    | ArrayCreate,[a] -> array_create a t
                    | ReferenceCreate,[a] -> reference_create a
                    | ArrayIndex,[b & TyType(ArrayT(ArtDotNetHeap,_));c] -> array_index b c
                    | ArrayIndex,[b & TyType(ArrayT(ArtDotNetReference,_));c] -> reference_index b
                    | ArrayLength,[a] -> array_length a
                    | StringIndex,[str;idx] -> string_index str idx
                    | StringSlice,[str;a;b] -> string_slice str a b
                    | StringLength,[str] -> string_length str
                    | StringFormat,l -> string_format l
                    | StringConcat,l -> string_concat l
                    | UnsafeConvert,[_;from] -> unsafe_convert t from

                    // Primitive operations on expressions.
                    | Add,[a;b] -> sprintf "(%s + %s)" (codegen a) (codegen b)
                    | Sub,[a;b] -> sprintf "(%s - %s)" (codegen a) (codegen b)
                    | Mult,[a;b] -> sprintf "(%s * %s)" (codegen a) (codegen b)
                    | Div,[a;b] -> sprintf "(%s / %s)" (codegen a) (codegen b)
                    | Mod,[a;b] -> sprintf "(%s %% %s)" (codegen a) (codegen b)
                    | Pow,[a;b] -> 
                        match get_type a, get_type b with
                        | PrimT Float64T, PrimT Float64T -> sprintf "(%s ** %s)" (codegen a) (codegen b)
                        | PrimT Float32T, PrimT Float32T -> sprintf "(float32 (float %s ** float %s))" (codegen a) (codegen b)
                        | _, _ -> failwith "impossible"
                    | LT,[a;b] -> sprintf "(%s < %s)" (codegen a) (codegen b)
                    | LTE,[a;b] -> sprintf "(%s <= %s)" (codegen a) (codegen b)
                    | EQ,[a;b] -> sprintf "(%s = %s)" (codegen a) (codegen b)
                    | NEQ,[a;b] -> sprintf "(%s <> %s)" (codegen a) (codegen b)
                    | GT,[a;b] -> sprintf "(%s > %s)" (codegen a) (codegen b)
                    | GTE,[a;b] -> sprintf "(%s >= %s)" (codegen a) (codegen b)
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
                    | Log,[x] -> sprintf "(log %s)" (codegen x)
                    | Exp,[x] -> sprintf "(exp %s)" (codegen x)
                    | Tanh,[x] -> sprintf "(tanh %s)" (codegen x)
                    | Sqrt,[x] -> sprintf "(sqrt %s)" (codegen x)
                    | NanIs,[x] -> 
                        match get_type x with
                        | PrimT Float32T -> sprintf "(System.Single.IsNaN %s)" (codegen x)
                        | PrimT Float64T -> sprintf "(System.Double.IsNaN %s)" (codegen x)
                        | _ -> failwith "impossible"
                    | FailWith,[x] -> sprintf "(failwith %s)" (codegen x)
                    | UnsafeUpcastTo,[a;b] -> sprintf "(%s :> %s)" (codegen b) (print_type (get_type a))
                    | UnsafeDowncastTo,[a;b] -> sprintf "(%s :?> %s)" (codegen b) (print_type (get_type a))
                    | MacroFs,[a] -> codegen_macro codegen print_type a
                    | SizeOf,[TyType a] -> sprintf "(int64 sizeof<%s>)" (print_type a)
                    | x -> failwithf "Compiler error: Missing TyOp case. %A" x
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
                | LayoutT(layout, expr) -> define_layoutt ty print_tag_env print_type_definition layout expr
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
        let trace = 
            let mutable c = settings.trace_length
            List.takeWhile (fun x -> if c > 0 then c <- c-1; true else false) trace
        let code: Dictionary<Module, ModuleCode []> = d0()
        let error = System.Text.StringBuilder(1024)
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
        error.AppendLine message |> ignore
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
        let parse_time = watch.Elapsed
        printfn "Time for parse: %A" parse_time
        watch.Restart()
        let d = data_empty()
        let input = body |> expr_prepass
        let prepass_time = watch.Elapsed
        printfn "Time for prepass: %A" prepass_time
        watch.Restart()
        try
            let x = !d.seq (expr_peval d input)
            let peval_time = watch.Elapsed
            printfn "Time for peval was: %A" peval_time
            watch.Restart()
            let x = spiral_fsharp_codegen x
            let codegen_time = watch.Elapsed
            printfn "Time for codegen was: %A" codegen_time
            Succ (x, {parsing_time=parse_time; prepass_time=prepass_time;peval_time=peval_time; codegen_time=codegen_time})
        with
        | :? TypeError as e -> 
            let trace, message = e.Data0, e.Data1
            Fail <| print_type_error trace message
