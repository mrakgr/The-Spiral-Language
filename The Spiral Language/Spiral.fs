module Spiral.Main

// Global open
open System
open System.Collections.Generic
open HashConsing
open Parsing
open Types

// Codegen open
open System.Text

// #Main
let spiral_compile (settings: CompilerSettings) module_ = 
    let join_point_dict_method = d0()
    let join_point_dict_closure = d0()
    let join_point_dict_type = d0()
    let join_point_dict_cuda = d0()

    //let keyword_num_args x = keyword_to_string x |> Seq.fold (fun s x -> if x = '.' then s+1 else s) 0

    let mutable tag_prepass = 0
    let rec module_prepass (env: ModulePrepassEnv) expr = 
        let error x = raise (PrepassError x)
        
        match expr with
        | ModPreLet(x,a,b) ->
            let count = env.modpre_context.Count
            let context = env.modpre_context.ToArray()
            let expr, size = prepass {prepass_context=context; prepass_map=env.modpre_map; prepass_map_length=count} a
            let module_ = partial_eval {rbeh=AnnotationDive; seq=env.modpre_seq; env_global=context; env_stack=Array.zeroCreate size; trace=[] } expr
            env.modpre_context.Add module_
            module_prepass {env with modpre_map=env.modpre_map.Add (x, count)} b
        | ModPreOpen(x,b) ->
            match env.modpre_map.TryFind x with
            | Some x ->
                match env.modpre_context.[x] with
                | TyMap x ->
                    let map, _ =
                        Map.fold (fun (s, count) k v ->
                            env.modpre_context.Add v
                            Map.add (keyword_to_string k) count s, count+1
                            ) (env.modpre_map, env.modpre_context.Count) x
                    module_prepass {env with modpre_map=map} b
                | _ -> error <| sprintf "In module_prepass, `open` did not receive a module."
            | _ -> error <| sprintf "In module_prepass, `open` did not find a module named %s in the environment." x
                        
            
    and prepass (env: PrepassEnv) expr = 
        let tag () = tag_prepass <- tag_prepass + 1; tag_prepass
        let prepass_memo_dict = Dictionary(HashIdentity.Reference)
        let prepass_subrenaming_memo_dict = Dictionary(HashIdentity.Reference)
        let error x = raise (PrepassError x)

        let string_to_var env x =
            match Map.tryFind x env with
            | Some x -> x
            | None -> error <| sprintf "Variable %s not bound." x

        let rec loop (env: PrepassEnv) expr = 
            let inline env_add_var (env: PrepassEnv) k = 
                env.prepass_map_length, 
                { env with 
                    prepass_map = Map.add k env.prepass_map_length env.prepass_map
                    prepass_map_length = env.prepass_map_length + 1
                    }

            let subrenaming_env_init size_lexical_scope free_vars = 
                let d = Dictionary(Array.length free_vars, HashIdentity.Structural)
                Array.iter (fun k -> d.Add(k,d.Count)) free_vars
                {subren_size_lexical_scope=size_lexical_scope; subren_dict=d}

            let rec subrenaming (env: PrepassSubrenameEnv) expr =
                let rename x =
                    // If is a free variable rename it explicitly else shift it.
                    if x < env.subren_size_lexical_scope then env.subren_dict.[x]
                    else x - env.subren_size_lexical_scope + env.subren_dict.Count
                let rename' x = Array.map rename x
                let inline f expr = subrenaming env expr
                memoize prepass_subrenaming_memo_dict (function
                    | V(tag,vartag) -> V(tag,rename vartag)
                    | Lit _ as x -> x
                    | Open(tag,vartag,a,on_succ) -> Open(tag,rename vartag,a,f on_succ)
                    // Not supposed to rename the bodies of these 3.
                    | Function(tag,body,free_vars,b) -> Function(tag,body,rename' free_vars,b)
                    | RecFunction(tag,body,free_vars,b) -> RecFunction(tag,body,rename' free_vars,b)
                    | ObjectCreate(dict,free_vars) -> ObjectCreate(dict,rename' free_vars)
                    | KeywordCreate(tag,a,exprs) -> KeywordCreate(tag,a,Array.map f exprs)
                    | Let(tag,bind,on_succ) -> Let(tag,f bind,f on_succ)
                    | Case(tag,bind,on_succ) -> Case(tag,f bind,f on_succ)
                    | If(tag,cond,on_succ,on_fail) -> If(tag,f cond,f on_succ,f on_fail)
                    | ListTakeAllTest(tag,size,bind,on_succ,on_fail) -> ListTakeAllTest(tag,size,bind,f on_succ,f on_fail)
                    | ListTakeNTest(tag,size,bind,on_succ,on_fail) -> ListTakeNTest(tag,size,bind,f on_succ,f on_fail)
                    | KeywordTest(tag,keyword,bind,on_succ,on_fail) -> KeywordTest(tag,keyword,bind,f on_succ,f on_fail)
                    | ModuleTest(tag,patterns,bind,on_succ,on_fail) ->
                        let patterns =
                            Array.map (function
                                | ModuleTestInjectVar x -> ModuleTestInjectVar(rename x)
                                | ModuleTestKeyword _ as x -> x
                                ) patterns
                        ModuleTest(tag,patterns,bind,f on_succ,f on_fail)
                    | ModuleWith(tag,exprs,patterns) ->
                        let patterns =
                            Array.map (function
                                | ModuleWithKeyword(keyword,expr) -> ModuleWithKeyword(keyword,f expr)
                                | ModuleWithInjectVar(var,expr) -> ModuleWithInjectVar(rename var,f expr)
                                | ModuleWithoutKeyword(keyword) -> ModuleWithoutKeyword keyword
                                | ModuleWithoutInjectVar(var) -> ModuleWithoutInjectVar(rename var)
                                ) patterns
                        ModuleWith(tag,Array.map f exprs,patterns)
                    | Op(tag,op,exprs) -> Op(tag,op,Array.map f exprs)
                    | ExprPos(tag, pos) -> ExprPos(tag, Pos.Position(pos.Pos,f pos.Expression))
                    ) expr

            let prepass_pattern (arg: VarString) (clauses: (Pattern * RawExpr) []): RawExpr = 
                let mutable tag = 0
                let patvar () = 
                    let x = sprintf " pat_var%i" tag
                    tag <- tag + 1
                    x

                let rec cp (arg: VarString) (pat: Pattern) (on_succ: RawExpr) (on_fail: RawExpr): RawExpr =
                    let list_test f pats = 
                        let binds, on_succ = 
                            List.mapFoldBack (fun pat on_succ ->
                                match pat with
                                | PatVar arg -> arg, on_succ
                                | _ -> let arg = patvar() in arg, cp arg pat on_succ on_fail
                                ) pats on_succ
                        f(List.toArray binds,arg,on_succ,on_fail)
                    match pat with
                    | PatE -> on_succ
                    | PatVar x -> l x (v arg) on_succ
                    | PatTypeEq (exp,typ) ->
                        let on_succ = cp arg exp on_succ on_fail
                        if_ (eq_type (v arg) typ) on_succ on_fail
                    | PatTuple pats -> list_test RawListTakeAllTest pats
                    | PatCons pats -> list_test RawListTakeNTest pats
                    | PatKeyword(keyword,pats) -> list_test (fun (a,b,c,d) -> RawKeywordTest(keyword,a,b,c,d)) pats
                    | PatActive (a,b) ->
                        let pat_var = patvar()
                        l pat_var (ap a (v arg)) (cp pat_var b on_succ on_fail)
                    | PatPartActive (a,pat) -> 
                        let pat_var = patvar()
                        let on_succ = inl pat_var (cp pat_var pat on_succ on_fail)
                        let on_fail = inl "" on_fail
                        ap' a [|v arg; on_fail; on_succ|]
                    | PatOr l -> List.foldBack (fun pat on_fail -> cp arg pat on_succ on_fail) l on_fail
                    | PatAnd l -> List.foldBack (fun pat on_succ -> cp arg pat on_succ on_fail) l on_succ
                    | PatNot p -> cp arg p on_fail on_succ // switches the on_fail and on_succ arguments
                    | PatLit x -> 
                        let x = lit x
                        if_ (eq_type (v arg) x) (if_ (eq (v arg) x) on_succ on_fail) on_fail
                    | PatWhen (p, e) -> cp arg p (if_ e on_succ on_fail) on_fail
                    | PatPos p -> expr_pos p.Pos (cp arg p.Expression on_succ on_fail)
                    | PatUnbox pat -> 
                        match pat with
                        | PatVar patvar -> RawCase(patvar,v arg,on_succ)
                        | _ -> let patvar = patvar() in RawCase(patvar,v arg,cp patvar pat on_succ on_fail)
                    | PatModuleMembers items ->
                        let binds, on_succ =
                            List.mapFoldBack (fun item on_succ ->
                                match item with
                                | PatModuleMembersKeyword(keyword,name) ->
                                    match name with
                                    | PatVar x -> RawModuleTestKeyword(keyword,x), on_succ
                                    | _ -> let arg = patvar() in RawModuleTestKeyword(keyword,arg), cp arg pat on_succ on_fail
                                | PatModuleMembersInjectVar(var,name) ->
                                    match name with
                                    | PatVar x -> RawModuleTestInjectVar(var,x), on_succ
                                    | _ -> let arg = patvar() in RawModuleTestInjectVar(var,arg), cp arg pat on_succ on_fail
                                ) items on_succ
                        RawModuleTest(List.toArray binds,arg,on_succ,on_fail)
                    | PatTypeTermFunction(domain,range) ->
                        let f pat on_succ = 
                            match pat with
                            | PatVar x -> x, on_succ
                            | _ -> let arg = patvar() in arg, cp arg pat on_succ on_fail
                        let range, on_succ = f range on_succ
                        let domain, on_succ = f domain on_succ
                        let arg = [|v arg|]
                        if_ (op TermFunctionIs arg)
                            (l domain (op TermFunctionDomain arg) 
                                (l range (op TermFunctionRange arg) on_succ))
                            on_fail

                Array.foldBack (fun (pat, exp) on_fail -> cp arg pat exp on_fail) clauses (op ErrorPatMiss [|v arg|])

            let inline list_test f (vars,bind,on_succ,on_fail) =
                let bind = string_to_var env.prepass_map bind
                let on_fail,on_fail_free_vars,on_fail_stack_size = loop env on_fail
                let vartags, env = Array.mapFold env_add_var env vars
                let on_succ,on_succ_free_vars,on_succ_stack_size = loop env on_succ
                let on_succ_free_vars = Array.fold (fun s x -> Set.remove x s) on_succ_free_vars vartags
                let free_vars = Set.singleton bind+on_succ_free_vars+on_fail_free_vars
                let stack_size = vars.Length + max on_succ_stack_size on_fail_stack_size
                f(tag(),vars.Length,bind,on_succ,on_fail),free_vars,stack_size

            let inline let_helper f (var,bind,on_succ) =
                let bind, free_vars, stack_size = loop env bind
                let vartag, env = env_add_var env var
                let on_succ, free_vars', stack_size' = loop env on_succ
                let free_vars' = Set.remove vartag free_vars'
                f(tag(), bind, on_succ), free_vars + free_vars', 1 + max stack_size stack_size'

            memoize prepass_memo_dict (function
                | RawV x -> let tag = tag() in V(tag, string_to_var env.prepass_map x), Set.singleton tag, 0
                | RawLit x -> Lit(tag(), x), Set.empty, 0
                | RawOpen(module_name,submodule_names,on_succ) ->
                    match env.prepass_map.TryFind module_name with
                    | Some vartag ->
                        if vartag < env.prepass_context.Length then
                            let env' =
                                Array.fold (fun (name, s) x ->
                                    match s with
                                    | TyMap s ->
                                        match Map.tryFind (string_to_keyword x) s with
                                        | Some s -> sprintf "%s.%s" name x,s
                                        | None -> error <| sprintf "Module %s does not have a submodule named %s." name x
                                    | _ -> error <| sprintf "The variable %s being opened is not a module." name
                                    ) (module_name, env.prepass_context.[vartag]) submodule_names
                                |> function
                                    | _, TyMap s -> s
                                    | name, _ -> error <| sprintf "The variable %s being opened is not a module." name
                            let on_succ, free_vars, stack_size = 
                                let env = Map.fold (fun env k _ -> env_add_var env (keyword_to_string k) |> snd) env env'
                                loop env on_succ
                            let free_vars, stack_size =
                                Map.fold (fun (free_vars, stack_size) k _ -> Set.remove k free_vars, stack_size + 1) 
                                    (free_vars, stack_size) env'
                            Open(tag(), vartag, Array.map string_to_keyword submodule_names, on_succ), free_vars, stack_size
                        else
                            error <| sprintf "Module %s is not a proper module or might have been shadowed. Only records returned from previously compiled modules can be opened." module_name
                    | None -> error <| sprintf "Module %s is not bound." module_name
                | RawFunction(expr, name) ->
                    let size_lexical_scope = env.prepass_map_length
                    let name_vartag, env = env_add_var env name
                    let expr, free_vars, stack_size = loop env expr
                    let free_vars = Set.remove name_vartag free_vars
                    let array_free_vars = Set.toArray free_vars
                    let expr = subrenaming (subrenaming_env_init size_lexical_scope array_free_vars) expr
                    Function(tag(),expr,array_free_vars,stack_size), free_vars, 0
                | RawRecFunction(expr, name, rec_name) ->
                    let size_lexical_scope = env.prepass_map_length
                    let name_vartag, env = env_add_var env name
                    let rec_name_vartag, env = env_add_var env rec_name
                    let expr, free_vars, stack_size = loop env expr
                    let free_vars = Set.remove name_vartag free_vars |> Set.remove rec_name_vartag
                    let array_free_vars = Set.toArray free_vars
                    let expr = subrenaming (subrenaming_env_init size_lexical_scope array_free_vars) expr
                    Function(tag(),expr,array_free_vars,stack_size), free_vars, 0
                | RawObjectCreate(ar) ->
                    let size_lexical_scope = env.prepass_map_length
                    let ar, free_vars = 
                        Array.mapFold (fun free_vars (keyword_string, var_strings, expr) ->
                            let self_vartag, env = env_add_var env "self"
                            let var_vartags, env = Array.mapFold env_add_var env var_strings
                            let expr, free_vars', stack_size = loop env expr
                            let free_vars' = Array.fold (fun s x -> Set.remove x s) (Set.remove self_vartag free_vars') var_vartags
                            (string_to_keyword keyword_string, expr, stack_size + 1 + var_vartags.Length), free_vars + free_vars'
                            ) Set.empty ar
                    let array_free_vars = Set.toArray free_vars
                    let tagged_dict =
                        let subrenaming_env = subrenaming_env_init size_lexical_scope array_free_vars
                        let tagged_dict = TaggedDictionary(ar.Length,tag())
                        Array.iter (fun (keyword, expr, stack_size) -> 
                            let expr = subrenaming subrenaming_env expr
                            tagged_dict.Add(keyword, (expr, stack_size))
                            ) ar
                        tagged_dict

                    ObjectCreate(tagged_dict, array_free_vars), free_vars, 0
                | RawKeywordCreate(name,args) ->
                    let args, (free_vars, stack_size) =
                        Array.mapFold (fun (free_vars, stack_size) arg ->
                            let arg, free_vars', stack_size' = loop env arg
                            arg, (free_vars + free_vars', max stack_size stack_size')
                            ) (Set.empty, 0) args
                    KeywordCreate(tag(), string_to_keyword name, args), free_vars, stack_size
                | RawLet(var,bind,on_succ) -> let_helper Let (var,bind,on_succ)
                | RawCase(var,bind,on_succ) -> let_helper Case (var,bind,on_succ)
                | RawIf(cond,on_succ,on_fail) ->
                    let cond,free_vars,stack_size = loop env cond
                    let on_succ,free_vars',stack_size' = loop env on_succ
                    let on_fail,free_vars'',stack_size'' = loop env on_fail
                    If(tag(),cond,on_succ,on_fail),free_vars+free_vars'+free_vars'',stack_size+max stack_size' stack_size''
                | RawListTakeAllTest(vars,bind,on_succ,on_fail) -> list_test ListTakeAllTest (vars,bind,on_succ,on_fail)
                | RawListTakeNTest(vars,bind,on_succ,on_fail) -> list_test ListTakeNTest (vars,bind,on_succ,on_fail)
                | RawKeywordTest(keyword,vars,bind,on_succ,on_fail) -> 
                    list_test (fun (tag,stack_size,bind,on_succ,on_fail) -> KeywordTest(tag,string_to_keyword keyword,bind,on_succ,on_fail)) 
                        (vars,bind,on_succ,on_fail)
                | RawModuleTest(vars,bind,on_succ,on_fail) ->
                    let bind = string_to_var env.prepass_map bind
                    let on_fail,on_fail_free_vars,on_fail_stack_size = loop env on_fail
                    let vartags, env = Array.mapFold (fun s (RawModuleTestKeyword(_,name) | RawModuleTestInjectVar(_,name)) -> env_add_var s name) env vars
                    let on_succ,on_succ_free_vars,on_succ_stack_size = loop env on_succ
                    let on_succ_free_vars = Array.fold (fun s x -> Set.remove x s) on_succ_free_vars vartags
                    let vars, vars_free_vars =
                        Array.mapFold (fun s -> function
                            | RawModuleTestInjectVar(x,_) -> let x = string_to_var env.prepass_map x in ModuleTestInjectVar x, Set.add x s
                            | RawModuleTestKeyword(x,_) -> ModuleTestKeyword(string_to_keyword x), s
                            ) Set.empty vars
                    let free_vars = vars_free_vars+Set.singleton bind+on_succ_free_vars+on_fail_free_vars
                    let stack_size = vars.Length + max on_succ_stack_size on_fail_stack_size
                    ModuleTest(tag(),vars,bind,on_succ,on_fail),free_vars,stack_size                    
                | RawModuleWith(binds,patterns) ->
                    let binds, (binds_free_vars, binds_stack_size) = 
                        Array.mapFold (fun (free_vars, stack_size) x ->
                            let bind, free_vars', stack_size' = loop env x
                            bind,(free_vars+free_vars',max stack_size stack_size')
                            ) (Set.empty, 0) binds
                    let patterns, (patterns_free_vars, patterns_stack_size) =
                        Array.mapFold (fun (free_vars, stack_size) -> function
                            | RawModuleWithKeyword(keyword,expr) ->
                                let this_tag, env = env_add_var env "this"
                                let expr, free_vars', stack_size' = loop env expr
                                let free_vars' = Set.remove this_tag free_vars'
                                ModuleWithKeyword(string_to_keyword keyword, expr),(free_vars+free_vars',max stack_size stack_size')
                            | RawModuleWithInjectVar(var,expr) ->
                                let this_tag, env = env_add_var env "this"
                                let expr, free_vars', stack_size' = loop env expr
                                let free_vars' = Set.remove this_tag free_vars'
                                let x = string_to_var env.prepass_map var
                                ModuleWithInjectVar(x, expr),(free_vars+free_vars' |> Set.add x, max stack_size stack_size')
                            | RawModuleWithoutKeyword keyword -> ModuleWithoutKeyword(string_to_keyword keyword),(free_vars,stack_size)
                            | RawModuleWithoutInjectVar var -> 
                                let x = string_to_var env.prepass_map var
                                ModuleWithoutInjectVar x,(Set.add x free_vars,stack_size)
                            ) (Set.empty, 0) patterns
                    ModuleWith(tag(), binds, patterns),binds_free_vars+patterns_free_vars,binds_stack_size+patterns_stack_size
                | RawOp(op,exprs) ->
                    let exprs, (free_vars, stack_size) =
                        Array.mapFold (fun (free_vars,stack_size) expr ->
                            let expr, free_vars', stack_size' = loop env expr
                            expr, (free_vars + free_vars', max stack_size stack_size')
                            ) (Set.empty, 0) exprs
                    Op(tag(),op,exprs),free_vars,stack_size
                | RawExprPos(pos) ->
                    let pos, expr = pos.Pos, pos.Expression
                    try loop env expr
                    with
                    | :? PrepassError as er ->
                        let mes = er.Data0
                        raise (PrepassErrorWithPos(pos,mes))
                | RawPattern(var, pattern) -> prepass_pattern var pattern |> loop env
                ) expr
        
        let expr, free_vars, stack_size = loop env expr
        expr, stack_size
        
    and partial_eval _ = failwith ""

    ()