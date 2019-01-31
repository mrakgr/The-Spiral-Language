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
    let mutable tag_prepass = 0
    let mutable tag_keyword = 0

    let keyword_to_string_dict = d0()
    let string_to_keyword_dict = d0()
    
    let string_to_keyword (x: string) =
        match string_to_keyword_dict.TryGetValue x with
        | true, v -> v
        | false, _ ->
            tag_keyword <- tag_keyword + 1
            string_to_keyword_dict.[x] <- tag_keyword
            keyword_to_string_dict.[tag_keyword] <- x
            tag_keyword
    let keyword_to_string x = keyword_to_string_dict.[x] // Should never fail.
    let keyword_num_args x = keyword_to_string x |> Seq.fold (fun s x -> if x = '.' then s+1 else s) 0

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

            let inline subrenaming_env_add_var (count, map) k = count + 1, Map.add k count map
            let inline subrenaming_env_add_var' k env = subrenaming_env_add_var env k

            let rec subrenaming expr (count,map) = failwith ""

            let inline list_test f (vars,bind,on_succ,on_fail) =
                let bind,bind_free_vars,bind_stack_size = loop env bind
                let on_fail,on_fail_free_vars,on_fail_stack_size = loop env on_fail
                let vartags, env = Array.mapFold env_add_var env vars
                let on_succ,on_succ_free_vars,on_succ_stack_size = loop env on_succ
                let on_succ_free_vars = Array.fold (fun s x -> Set.remove x s) on_succ_free_vars vartags
                let free_vars = bind_free_vars+on_succ_free_vars+on_fail_free_vars
                let stack_size = vars.Length + bind_stack_size + max on_succ_stack_size on_fail_stack_size
                f(tag(),vars.Length,bind,on_succ,on_fail),free_vars,stack_size

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
                    let name_vartag, env = env_add_var env name
                    let expr, free_vars, stack_size = loop env expr
                    let free_vars = Set.remove name_vartag free_vars
                    let array_free_vars = Set.toArray free_vars
                    let expr = 
                        Array.fold subrenaming_env_add_var (0, Map.empty) array_free_vars
                        |> subrenaming_env_add_var' name_vartag
                        |> subrenaming expr
                    Function(tag(),expr,array_free_vars,stack_size), free_vars, 0
                | RawRecFunction(expr, name, rec_name) ->
                    let name_vartag, env = env_add_var env name
                    let rec_name_vartag, env = env_add_var env rec_name
                    let expr, free_vars, stack_size = loop env expr
                    let free_vars = Set.remove name_vartag free_vars |> Set.remove rec_name_vartag
                    let array_free_vars = Set.toArray free_vars
                    let expr = 
                        Array.fold subrenaming_env_add_var (0, Map.empty) array_free_vars
                        |> subrenaming_env_add_var' name_vartag
                        |> subrenaming_env_add_var' rec_name_vartag
                        |> subrenaming expr
                    Function(tag(),expr,array_free_vars,stack_size), free_vars, 0
                | RawObjectCreate(ar) ->
                    let ar, free_vars = 
                        Array.mapFold (fun free_vars (keyword_string, var_strings, expr) ->
                            let self_vartag, env = env_add_var env "self"
                            let var_vartags, env = Array.mapFold env_add_var env var_strings
                            let expr, free_vars', stack_size = loop env expr
                            let free_vars' = Array.fold (fun s x -> Set.remove x s) (Set.remove self_vartag free_vars') var_vartags
                            (string_to_keyword keyword_string, expr, self_vartag, var_vartags, stack_size), free_vars + free_vars'
                            ) Set.empty ar
                    let array_free_vars = Set.toArray free_vars
                    let tagged_dict =
                        let env = Array.fold subrenaming_env_add_var (0, Map.empty) array_free_vars
                        let tagged_dict = TaggedDictionary(ar.Length,tag())
                        Array.iter (fun (keyword, expr, self_vartag, var_vartags, stack_size) -> 
                            let env = subrenaming_env_add_var env self_vartag
                            let env = Array.fold subrenaming_env_add_var env var_vartags
                            let expr = subrenaming expr env
                            tagged_dict.Add(keyword, (expr, stack_size + 1 + var_vartags.Length))
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
                | RawLet(name,bind,on_succ) ->
                    let bind, free_vars, stack_size = loop env bind
                    let name_vartag, env = env_add_var env name
                    let on_succ, free_vars', stack_size' = loop env on_succ
                    let free_vars' = Set.remove name_vartag free_vars'
                    Let(tag(), bind, on_succ), free_vars + free_vars', 1 + max stack_size stack_size'
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
                    let bind,bind_free_vars,bind_stack_size = loop env bind
                    let on_fail,on_fail_free_vars,on_fail_stack_size = loop env on_fail
                    let vartags, env = Array.mapFold (fun s (RawModuleTestKeyword(name,_) | RawModuleTestInjectVar(name,_)) -> env_add_var s name) env vars
                    let on_succ,on_succ_free_vars,on_succ_stack_size = loop env on_succ
                    let on_succ_free_vars = Array.fold (fun s x -> Set.remove x s) on_succ_free_vars vartags
                    let vars, vars_free_vars =
                        Array.mapFold (fun s -> function
                            | RawModuleTestInjectVar(_,x) -> let x = string_to_var env.prepass_map x in ModuleTestInjectVar x, Set.add x s
                            | RawModuleTestKeyword(_,x) -> ModuleTestKeyword(string_to_keyword x), s
                            ) Set.empty vars
                    let free_vars = vars_free_vars+bind_free_vars+on_succ_free_vars+on_fail_free_vars
                    let stack_size = vars.Length + bind_stack_size + max on_succ_stack_size on_fail_stack_size
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
                ) expr
        
        let expr, free_vars, stack_size = loop env expr
        expr, stack_size
        
        
    and partial_eval _ = failwith ""
    ()