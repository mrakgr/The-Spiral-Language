module Spiral.Prepass

// Global open
open System
open System.Collections.Generic
open Spiral.Show
open Spiral.Types
open System.Runtime.CompilerServices

// Globals
let mutable tag_prepass = 0
let private tag () = tag_prepass <- tag_prepass + 1; tag_prepass

let prepass x =
    let free_vars_and_stack_size_dict = Dictionary(HashIdentity.Reference)
    let pattern_dict = Dictionary(HashIdentity.Reference)
    let renaming_dict = Dictionary(HashIdentity.Reference)

    let free_vars_dict = Dictionary(HashIdentity.Reference)
    let object_arg = ["self"; Types.pat_main]

    let error x = raise (PrepassError x)

    let pattern x = 
        memoize pattern_dict (fun (arg: VarString, clauses: (Pattern * RawExpr) []) ->
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

            let inline g f = Array.foldBack (fun (pat, exp) on_fail -> cp arg pat (f exp) on_fail) clauses (op ErrorPatMiss [|v arg|])
            if clauses.Length > 1 then g inline_ else g id
            ) x

    let rec free_vars_and_stack_size x =
        memoize free_vars_and_stack_size_dict (fun x ->
            let rec f x = 
                match x with
                | RawV x -> Set.singleton x, 0
                | RawLit _ -> Set.empty, 0
                | RawInline expr ->
                    let free_vars, _ = free_vars_and_stack_size expr
                    free_vars, 0
                | RawFunction(expr, name) ->
                    let free_vars, _ = free_vars_and_stack_size expr
                    Set.remove name free_vars, 0
                | RawRecFunction(expr, name, rec_name) ->
                    let free_vars, _ = free_vars_and_stack_size expr
                    Set.remove name free_vars |> Set.remove rec_name, 0
                | RawObjectCreate(ar) ->
                    let free_vars =
                        Array.fold (fun free_vars (keyword_string, expr) ->
                            let free_vars', _ = free_vars_and_stack_size expr
                            Set.remove "self" free_vars' 
                            |> Set.remove Types.pat_main
                            |> Set.union free_vars
                            ) Set.empty ar
                    let _ = memoize free_vars_dict (fun _ -> free_vars) x
                    free_vars, 0
                | RawOp(_, args) | RawKeywordCreate(_,args) ->
                    Array.fold (fun (free_vars, stack_size) arg ->
                        let free_vars', stack_size' = f arg
                        Set.union free_vars free_vars', max stack_size stack_size'
                        ) (Set.empty, 0) args
                | RawLet(var,bind,on_succ) | RawCase(var,bind,on_succ) -> 
                    let bind_free_vars, bind_stack_size = f bind
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    Set.union bind_free_vars (Set.remove var on_succ_free_vars), 1 + max bind_stack_size on_succ_stack_size
                | RawListTakeAllTest(vars,bind,on_succ,on_fail)
                | RawListTakeNTest(vars,bind,on_succ,on_fail) 
                | RawKeywordTest(_,vars,bind,on_succ,on_fail) -> 
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    let on_succ_free_vars = Array.foldBack Set.remove vars on_succ_free_vars
                    let on_fail_free_vars, on_fail_stack_size = f on_fail 
                    let free_vars =
                        Set.union on_succ_free_vars on_fail_free_vars
                        |> Set.add bind
                    free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size
                | RawRecordTest(vars,bind,on_succ,on_fail) ->
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    let on_succ_free_vars = 
                        let f (RawRecordTestKeyword(_,name) | RawRecordTestInjectVar(_,name)) = name
                        Array.foldBack (f >> Set.remove) vars on_succ_free_vars
                    let on_fail_free_vars, on_fail_stack_size = f on_fail 
                    let free_vars =
                        let f x s = match x with RawRecordTestInjectVar(x,_) -> Set.add x s | RawRecordTestKeyword(x,_) -> s
                        Set.union on_succ_free_vars on_fail_free_vars
                        |> Set.add bind
                        |> Array.foldBack f vars
                    free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size                
                | RawRecordWith(binds,patterns) ->
                    let binds_free_vars, binds_stack_size =
                        Array.foldBack (fun x (free_vars, stack_size) ->
                            let free_vars', stack_size' = f x
                            Set.union free_vars free_vars', max stack_size stack_size'
                            ) binds (Set.empty, 0)

                    let patterns_free_vars, patterns_stack_size =
                        Array.foldBack (fun x (free_vars, stack_size) ->
                            match x with
                            | RawRecordWithKeyword(keyword,expr) ->
                                let free_vars', stack_size' = f expr
                                let free_vars' = Set.remove "this" free_vars'
                                Set.union free_vars free_vars',max stack_size (stack_size'+1)
                            | RawRecordWithInjectVar(var,expr) ->
                                let free_vars', stack_size' = f expr
                                let free_vars' = Set.remove "this" free_vars'
                                Set.union free_vars free_vars' |> Set.add var,max stack_size (stack_size'+1)
                            | RawRecordWithoutKeyword keyword -> free_vars,stack_size
                            | RawRecordWithoutInjectVar var -> Set.add var free_vars,stack_size
                            ) patterns (Set.empty, 0)
                    Set.union binds_free_vars patterns_free_vars, binds_stack_size+patterns_stack_size
                | RawExprPos(pos) -> f pos.Expression
                | RawPattern x -> pattern x |> f
            f x
            ) x

    let env_add k (map,count) = Map.add k count map, count+1
    let env_init x args = 
        List.foldBack Set.remove args x 
        |> fun env -> Set.fold (fun env k -> env_add k env) (Map.empty, 0) env
        |> fun env -> List.fold (fun env k -> env_add k env) env args

    let rec rename x =
        memoize renaming_dict (fun x ->
            let rec f' ((map, count) as env) x =
                let inline f x = f' env x
                let inline v x = Map.find x map
                let inline array_free_vars_from x = Set.toArray x |> Array.map (fun k -> Map.find k map)

                let inline op_helper (x,args) = tag(),x,Array.map f args
                let inline let_helper (var,bind,on_succ) =
                    let env = env_add var env
                    tag(), f bind, f' env on_succ
                let inline list_helper (vars,bind,on_succ,on_fail) =
                    let env = Array.fold (fun s x -> env_add x s) env vars
                    tag(),vars.Length,v bind,f' env on_succ,f on_fail

                match x with
                | RawV x -> V(tag(), v x)
                | RawLit x -> Lit(tag(), x)
                | RawInline expr ->
                    let free_vars, stack_size = free_vars_and_stack_size expr
                    let array_free_vars = array_free_vars_from free_vars
                    Inline(tag(),rename expr,array_free_vars,stack_size)
                | RawFunction(expr, name) -> 
                    let free_vars, stack_size = free_vars_and_stack_size expr
                    let free_vars = Set.remove name free_vars
                    let array_free_vars = array_free_vars_from free_vars
                    Function(tag(),f' (env_init free_vars [name]) expr,array_free_vars,stack_size + 1)
                | RawRecFunction(expr, name, rec_name) -> 
                    let free_vars, stack_size = free_vars_and_stack_size expr
                    let free_vars = Set.remove name free_vars |> Set.remove rec_name
                    let array_free_vars = array_free_vars_from free_vars
                    RecFunction(tag(),f' (env_init free_vars [name; rec_name]) expr,array_free_vars,stack_size + 2)
                | RawObjectCreate(ar) ->
                    let free_vars = memoize free_vars_dict (fun _ -> failwith "Compiler error: `free_vars` for RawObjectCreate need to be memoized.") x 
                    let env = env_init free_vars object_arg
                    let array_free_vars = array_free_vars_from free_vars
                    let tagged_dict = TaggedDictionary(ar.Length,tag())
                    Array.iter (fun (keyword_string, expr) ->
                        let _, stack_size = free_vars_and_stack_size expr
                        try tagged_dict.Add(string_to_keyword keyword_string, (f' env expr, stack_size + 2))
                        with :? ArgumentException -> error <| sprintf "The same receiver %s already exists in the object." keyword_string
                        ) ar
                    ObjectCreate(tagged_dict, array_free_vars)
                | RawOp(x,args) -> op_helper (x,args) |> Op
                | RawKeywordCreate(x,args) -> op_helper (string_to_keyword x,args) |> KeywordCreate
                | RawLet(var,bind,on_succ) -> let_helper (var,bind,on_succ) |> Let
                | RawCase(var,bind,on_succ) -> let_helper (var,bind,on_succ) |> Case
                | RawListTakeAllTest(vars,bind,on_succ,on_fail) -> list_helper (vars,bind,on_succ,on_fail) |> ListTakeAllTest
                | RawListTakeNTest(vars,bind,on_succ,on_fail) -> list_helper (vars,bind,on_succ,on_fail) |> ListTakeNTest
                | RawKeywordTest(keyword,vars,bind,on_succ,on_fail) -> 
                    let tag, stack_size, bind, on_succ, on_fail = list_helper (vars,bind,on_succ,on_fail)
                    KeywordTest(tag,string_to_keyword keyword,bind,on_succ,on_fail)
                | RawRecordTest(vars,bind,on_succ,on_fail) ->
                    let vars, env =
                        Array.mapFold (fun env x ->   
                            match x with
                            | RawRecordTestKeyword(keyword,name) -> RecordTestKeyword(string_to_keyword keyword), env_add name env
                            | RawRecordTestInjectVar(var,name) -> RecordTestInjectVar(v var), env_add name env
                            ) env vars
                    RecordTest(tag(),vars,v bind,f' env on_succ,f on_fail)      
                | RawRecordWith(binds,patterns) ->
                    let binds = Array.map f binds
                    let patterns =
                        Array.map (function
                            | RawRecordWithKeyword(keyword,expr) -> RecordWithKeyword(string_to_keyword keyword, f' (env_add "this" env) expr)
                            | RawRecordWithInjectVar(var,expr) -> RecordWithInjectVar(var,v var, f' (env_add "this" env) expr)
                            | RawRecordWithoutKeyword(keyword) -> RecordWithoutKeyword(string_to_keyword keyword)
                            | RawRecordWithoutInjectVar(var) -> RecordWithoutInjectVar(var,v var)
                            ) patterns
                    RecordWith(tag(),binds,patterns)
                | RawExprPos(pos) ->
                    let pos, expr = pos.Pos, pos.Expression
                    try f expr |> fun x -> ExprPos(tag(),Position(pos,x))
                    with
                    | :? PrepassError as er ->
                        let mes = er.Data0
                        raise (PrepassErrorWithPos(pos,mes))
                | RawPattern x -> pattern x |> f

            let free_vars, stack_size = free_vars_and_stack_size x
            f' (env_init free_vars []) x
            ) x

    let free_vars, stack_size = free_vars_and_stack_size x
    let free_vars = 
        let er x = failwithf "Compiler error: The variable `%s` must be annotated with its position in the tokenizer." x
        Set.toArray free_vars
        |> Array.map (fun x -> x, memoize' Tokenize.var_position_dict er x)
    rename x, free_vars, stack_size