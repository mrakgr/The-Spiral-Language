module Spiral.Prepass

// Global open
open System
open System.Collections.Generic
open Spiral.Show
open Spiral.Types

// Globals
let mutable tag_prepass = 0
let private tag () = tag_prepass <- tag_prepass + 1; tag_prepass

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
        | PatRecordMembers items ->
            let binds, on_succ =
                List.mapFoldBack (fun item on_succ ->
                    match item with
                    | PatRecordMembersKeyword(keyword,name) ->
                        match name with
                        | PatVar x -> RawRecordTestKeyword(keyword,x), on_succ
                        | pat -> let arg = patvar() in RawRecordTestKeyword(keyword,arg), cp arg pat on_succ on_fail
                    | PatRecordMembersInjectVar(var,name) ->
                        match name with
                        | PatVar x -> RawRecordTestInjectVar(var,x), on_succ
                        | pat -> let arg = patvar() in RawRecordTestInjectVar(var,arg), cp arg pat on_succ on_fail
                    ) items on_succ
            RawRecordTest(List.toArray binds,arg,on_succ,on_fail)
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

    let move_ptr = id //if clauses.Length > 1 then RawMoveGlobalPtrTo else id
    Array.foldBack (fun (pat, exp) on_fail -> cp arg pat (move_ptr exp) on_fail) clauses (op ErrorPatMiss [|v arg|])

let prepass (env: PrepassEnv) expr = 
    let prepass_memo_dict = Dictionary(HashIdentity.Reference)
    let prepass_subrenaming_memo_dict = Dictionary(HashIdentity.Reference)
    let error x = raise (PrepassError x)

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
            | MoveGlobalPtrTo(tag,vartag,on_succ) -> MoveGlobalPtrTo(tag,rename vartag,f on_succ)
            | Open(tag,vartag,a,on_succ) -> Open(tag,rename vartag,a,f on_succ)
            // Not supposed to rename the bodies of these 3.
            | Function(tag,body,free_vars,b) -> Function(tag,body,rename' free_vars,b)
            | RecFunction(tag,body,free_vars,b) -> RecFunction(tag,body,rename' free_vars,b)
            | ObjectCreate(dict,free_vars) -> ObjectCreate(dict,rename' free_vars)
            | KeywordCreate(tag,a,exprs) -> KeywordCreate(tag,a,Array.map f exprs)
            | Let(tag,bind,on_succ) -> Let(tag,f bind,f on_succ)
            | Case(tag,bind,on_succ) -> Case(tag,f bind,f on_succ)
            | ListTakeAllTest(tag,size,bind,on_succ,on_fail) -> ListTakeAllTest(tag,size,rename bind,f on_succ,f on_fail)
            | ListTakeNTest(tag,size,bind,on_succ,on_fail) -> ListTakeNTest(tag,size,rename bind,f on_succ,f on_fail)
            | KeywordTest(tag,keyword,bind,on_succ,on_fail) -> KeywordTest(tag,keyword,rename bind,f on_succ,f on_fail)
            | RecordTest(tag,patterns,bind,on_succ,on_fail) ->
                let patterns =
                    Array.map (function
                        | RecordTestInjectVar x -> RecordTestInjectVar(rename x)
                        | RecordTestKeyword _ as x -> x
                        ) patterns
                RecordTest(tag,patterns,rename bind,f on_succ,f on_fail)
            | RecordWith(tag,exprs,patterns) ->
                let patterns =
                    Array.map (function
                        | RecordWithKeyword(keyword,expr) -> RecordWithKeyword(keyword,f expr)
                        | RecordWithInjectVar(x,var,expr) -> RecordWithInjectVar(x,rename var,f expr)
                        | RecordWithoutKeyword(keyword) -> RecordWithoutKeyword keyword
                        | RecordWithoutInjectVar(x,var) -> RecordWithoutInjectVar(x,rename var)
                        ) patterns
                RecordWith(tag,Array.map f exprs,patterns)
            | Op(tag,op,exprs) -> Op(tag,op,Array.map f exprs)
            | ExprPos(tag, pos) -> ExprPos(tag, Pos.Position(pos.Pos,f pos.Expression))
            ) expr

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

        let inline list_test f (vars,bind,on_succ,on_fail) =
            let bind = string_to_var env.prepass_map bind
            let vartags, env' = Array.mapFold env_add_var env vars
            let on_succ,on_succ_free_vars,on_succ_stack_size = loop env' on_succ
            let on_fail,on_fail_free_vars,on_fail_stack_size = loop env on_fail
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
            | RawV x -> let tag, x = tag(), string_to_var env.prepass_map x in V(tag, x), Set.singleton x, 0
            | RawLit x -> Lit(tag(), x), Set.empty, 0
            | RawMoveGlobalPtrTo x ->
                let on_succ,free_vars,stack_size = loop env x
                MoveGlobalPtrTo(tag(),env.prepass_map_length,on_succ),free_vars,stack_size
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
                Function(tag(),expr,array_free_vars,stack_size + 1), free_vars, 0
            | RawRecFunction(expr, name, rec_name) ->
                let size_lexical_scope = env.prepass_map_length
                let name_vartag, env = env_add_var env name
                let rec_name_vartag, env = env_add_var env rec_name
                let expr, free_vars, stack_size = loop env expr
                let free_vars = Set.remove name_vartag free_vars |> Set.remove rec_name_vartag
                let array_free_vars = Set.toArray free_vars
                let expr = subrenaming (subrenaming_env_init size_lexical_scope array_free_vars) expr
                RecFunction(tag(),expr,array_free_vars,stack_size + 2), free_vars, 0
            | RawObjectCreate(ar) ->
                let size_lexical_scope = env.prepass_map_length
                let ar, free_vars = 
                    Array.mapFold (fun free_vars (keyword_string, expr) ->
                        let self_vartag, env = env_add_var env "self"
                        let main_vartag, env = env_add_var env Types.pat_main
                        let expr, free_vars', stack_size = loop env expr
                        let free_vars' = Set.remove main_vartag (Set.remove self_vartag free_vars')
                        (string_to_keyword keyword_string, expr, stack_size + 2), free_vars + free_vars'
                        ) Set.empty ar
                let array_free_vars = Set.toArray free_vars
                let tagged_dict =
                    let subrenaming_env = subrenaming_env_init size_lexical_scope array_free_vars
                    let tagged_dict = TaggedDictionary(ar.Length,tag())
                    Array.iter (fun (keyword, expr, stack_size) -> 
                        let expr = subrenaming subrenaming_env expr
                        try tagged_dict.Add(keyword, (expr, stack_size))
                        with :? ArgumentException -> error <| sprintf "The same receiver %s already exists in the object." (keyword_to_string keyword)
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
            | RawListTakeAllTest(vars,bind,on_succ,on_fail) -> list_test ListTakeAllTest (vars,bind,on_succ,on_fail)
            | RawListTakeNTest(vars,bind,on_succ,on_fail) -> list_test ListTakeNTest (vars,bind,on_succ,on_fail)
            | RawKeywordTest(keyword,vars,bind,on_succ,on_fail) -> 
                list_test (fun (tag,stack_size,bind,on_succ,on_fail) -> KeywordTest(tag,string_to_keyword keyword,bind,on_succ,on_fail)) 
                    (vars,bind,on_succ,on_fail)
            | RawRecordTest(vars,bind,on_succ,on_fail) ->
                let bind = string_to_var env.prepass_map bind
                let vartags, env' = Array.mapFold (fun s (RawRecordTestKeyword(_,name) | RawRecordTestInjectVar(_,name)) -> env_add_var s name) env vars
                let on_succ,on_succ_free_vars,on_succ_stack_size = loop env' on_succ
                let on_fail,on_fail_free_vars,on_fail_stack_size = loop env on_fail
                let on_succ_free_vars = Array.fold (fun s x -> Set.remove x s) on_succ_free_vars vartags
                let vars, vars_free_vars =
                    Array.mapFold (fun s -> function
                        | RawRecordTestInjectVar(x,_) -> let x = string_to_var env'.prepass_map x in RecordTestInjectVar x, Set.add x s
                        | RawRecordTestKeyword(x,_) -> RecordTestKeyword(string_to_keyword x), s
                        ) Set.empty vars
                let free_vars = vars_free_vars+Set.singleton bind+on_succ_free_vars+on_fail_free_vars
                let stack_size = vars.Length + max on_succ_stack_size on_fail_stack_size
                RecordTest(tag(),vars,bind,on_succ,on_fail),free_vars,stack_size                    
            | RawRecordWith(binds,patterns) ->
                let binds, (binds_free_vars, binds_stack_size) = 
                    Array.mapFold (fun (free_vars, stack_size) x ->
                        let bind, free_vars', stack_size' = loop env x
                        bind,(free_vars+free_vars',max stack_size stack_size')
                        ) (Set.empty, 0) binds
                let patterns, (patterns_free_vars, patterns_stack_size) =
                    Array.mapFold (fun (free_vars, stack_size) -> function
                        | RawRecordWithKeyword(keyword,expr) ->
                            let this_tag, env = env_add_var env "this"
                            let expr, free_vars', stack_size' = loop env expr
                            let free_vars' = Set.remove this_tag free_vars'
                            RecordWithKeyword(string_to_keyword keyword, expr),(free_vars+free_vars',max stack_size (stack_size'+1))
                        | RawRecordWithInjectVar(var,expr) ->
                            let this_tag, env = env_add_var env "this"
                            let expr, free_vars', stack_size' = loop env expr
                            let free_vars' = Set.remove this_tag free_vars'
                            let x = string_to_var env.prepass_map var
                            RecordWithInjectVar(var, x, expr),(free_vars+free_vars' |> Set.add x, max stack_size (stack_size'+1))
                        | RawRecordWithoutKeyword keyword -> RecordWithoutKeyword(string_to_keyword keyword),(free_vars,stack_size)
                        | RawRecordWithoutInjectVar var -> 
                            let x = string_to_var env.prepass_map var
                            RecordWithoutInjectVar(var, x),(Set.add x free_vars,stack_size)
                        ) (Set.empty, 0) patterns
                RecordWith(tag(), binds, patterns),binds_free_vars+patterns_free_vars,binds_stack_size+patterns_stack_size
            | RawOp(op,exprs) ->
                let exprs, (free_vars, stack_size) =
                    Array.mapFold (fun (free_vars,stack_size) expr ->
                        let expr, free_vars', stack_size' = loop env expr
                        expr, (free_vars + free_vars', max stack_size stack_size')
                        ) (Set.empty, 0) exprs
                
                Op(tag(),op,exprs),free_vars,stack_size
            | RawExprPos(pos) ->
                let pos, expr = pos.Pos, pos.Expression
                try loop env expr |> fun (a,b,c) -> ExprPos(tag(),Position(pos,a)), b, c
                with
                | :? PrepassError as er ->
                    let mes = er.Data0
                    raise (PrepassErrorWithPos(pos,mes))
            | RawPattern(var, pattern) -> prepass_pattern var pattern |> loop env
            ) expr

    let expr, free_vars, stack_size = loop env expr
    expr, stack_size

