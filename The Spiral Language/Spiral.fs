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
let spiral_compile (settings: CompilerSettings) (Module(N(module_name,_,_,_)) as module_main) = 
    let join_point_dict_method = d0()
    let join_point_dict_closure = d0()
    let join_point_dict_type = d0()
    let join_point_dict_cuda = d0()

    let keyword_to_string_dict = d0()
    let string_to_keyword_dict = d0()

    let mutable tag_keyword = 0
    let string_to_keyword (x: string) =
        match string_to_keyword_dict.TryGetValue x with
        | true, v -> v
        | false, _ ->
            tag_keyword <- tag_keyword + 1
            string_to_keyword_dict.[x] <- tag_keyword
            keyword_to_string_dict.[tag_keyword] <- x
            tag_keyword
    let keyword_to_string x = keyword_to_string_dict.[x] // Should never fail.
    //let keyword_num_args x = keyword_to_string x |> Seq.fold (fun s x -> if x = '.' then s+1 else s) 0

    let v x = RawV x
    let lit x = RawLit x
    let open_ var subs on_succ = RawOpen(var,subs,on_succ)
    let inl x y = RawFunction(y,x)
    let objc m = RawObjectCreate m
    let keyword k l = RawKeywordCreate(k,l)
    let l bind body on_succ = RawLet(bind,body,on_succ)
    let case bind body on_succ = RawCase(bind,body,on_succ)
    let if_ cond on_succ on_fail = RawIf(cond,on_succ,on_fail)
    let list_take_all_test x bind on_succ on_fail = RawListTakeAllTest(x,bind,on_succ,on_fail)
    let list_take_n_test x bind on_succ on_fail = RawListTakeNTest(x,bind,on_succ,on_fail)
    let list_keyword_test keyword x bind on_succ on_fail = RawKeywordTest(keyword,x,bind,on_succ,on_fail)
    let module_test x bind on_succ on_fail = RawModuleTest(x,bind,on_succ,on_fail)
    let module_with binds patterns = RawModuleWith(binds,patterns)
    
    let op x args = RawOp(x,args)
    let vv x = op ListCreate x
    let B = vv [||]
    let pattern arg clauses = RawPattern(arg,clauses)

    let binop op' a b = op op' [|a;b|]
    let eq x y = binop EQ x y
    let eq_type a b = binop EqType a b
    let ap x y = binop Apply x y
    let rec ap' f l = Array.fold ap f l
    let expr_pos pos x = RawExprPos(Pos.Position(pos,x))
    let pat_pos pos x = PatPos(Spiral.Types.Position(pos,x))

    // The seemingly useless function application is there to filter the environment just in case it has not been done.
    let join_point_entry_method y = ap (inl "" (op JoinPointEntryMethod [|y|])) B 
    let join_point_entry_type y = ap (inl "" (op JoinPointEntryType [|y|])) B

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
                            Array.mapFoldBack (fun pat on_succ ->
                                match pat with
                                | PatVar arg -> arg, on_succ
                                | _ -> let arg = patvar() in arg, cp arg pat on_succ on_fail
                                ) pats on_succ
                        f(binds,arg,on_succ,on_fail)
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
                    | PatOr l -> Array.foldBack (fun pat on_fail -> cp arg pat on_succ on_fail) l on_fail
                    | PatAnd l -> Array.foldBack (fun pat on_succ -> cp arg pat on_succ on_fail) l on_succ
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
                            Array.mapFoldBack (fun item on_succ ->
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
                        RawModuleTest(binds,arg,on_succ,on_fail)
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
                | "match" | "function" | "with" | "without" | "as" | "when" | "inl" | "inm" 
                | "inb" | "rec" | "if" | "then" | "elif" | "else" | "true" | "false" 
                | "open" | "join" | "join_type" | "type" | "type_catch" as x -> fun _ -> Reply(Error,messageError <| sprintf "%s not allowed as an identifier." x)
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
                pipe2 (inject >>. var_name) ((eq' >>. patterns_template expr) <|>% PatE) (fun a b -> PatModuleInject(a, b))
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
        let case_type_catch expr = keywordString "type_catch" >>. expr |>> type_catch
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
            case_join_point; case_join_point_type; case_type; case_type_catch
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

    ()