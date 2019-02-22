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

    let function_args_dict = Dictionary(HashIdentity.Reference)
    let free_vars_dict = Dictionary(HashIdentity.Reference)
    let object_arg = ["self"; Types.pat_main]

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

            Array.foldBack (fun (pat, exp) on_fail -> cp arg pat exp on_fail) clauses (op ErrorPatMiss [|v arg|])
            ) x

    /// Adds the elements of b to a.
    let map_union a b = Map.foldBack Map.add a b

    let rec free_vars_and_stack_size x =
        memoize free_vars_and_stack_size_dict (fun x ->
            let rec f' (pos: PosKey option) x = 
                let inline f x = f' pos x
                let inline map_add x m = Map.add x pos m
                match x with
                | RawV x -> Map.empty.Add(x, pos), 0
                | RawLit _ -> Map.empty, 0
                | RawFunction(expr, name) ->
                    let _ = memoize function_args_dict (fun _ -> [name]) expr
                    let free_vars, _ = free_vars_and_stack_size expr
                    Map.remove name free_vars, 0
                | RawRecFunction(expr, name, rec_name) ->
                    let _ = memoize function_args_dict (fun _ -> [name;rec_name]) expr
                    let free_vars, _ = free_vars_and_stack_size expr
                    Map.remove name free_vars |> Map.remove rec_name, 0
                | RawObjectCreate(ar) ->
                    let free_vars =
                        Array.fold (fun free_vars (keyword_string, expr) ->
                            let _ = memoize function_args_dict (fun _ -> object_arg) expr
                            let free_vars', _ = free_vars_and_stack_size expr
                            Map.remove "self" free_vars' 
                            |> Map.remove Types.pat_main
                            |> map_union free_vars
                            ) Map.empty ar
                    let _ = memoize free_vars_dict (fun _ -> free_vars) x
                    free_vars, 0
                | RawOp(_, args) | RawKeywordCreate(_,args) ->
                    Array.fold (fun (free_vars, stack_size) arg ->
                        let free_vars', stack_size' = f arg
                        map_union free_vars free_vars', max stack_size stack_size'
                        ) (Map.empty, 0) args
                | RawLet(var,bind,on_succ) | RawCase(var,bind,on_succ) -> 
                    let bind_free_vars, bind_stack_size = f bind
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    map_union bind_free_vars (Map.remove var on_succ_free_vars), 1 + max bind_stack_size on_succ_stack_size
                | RawListTakeAllTest(vars,bind,on_succ,on_fail)
                | RawListTakeNTest(vars,bind,on_succ,on_fail) 
                | RawKeywordTest(_,vars,bind,on_succ,on_fail) -> 
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    let on_succ_free_vars = Array.foldBack Map.remove vars on_succ_free_vars
                    let on_fail_free_vars, on_fail_stack_size = f on_fail 
                    let free_vars =
                        map_union on_succ_free_vars on_fail_free_vars
                        |> map_add bind
                    free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size
                | RawRecordTest(vars,bind,on_succ,on_fail) ->
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    let on_succ_free_vars = 
                        let f (RawRecordTestKeyword(_,name) | RawRecordTestInjectVar(_,name)) = name
                        Array.foldBack (f >> Map.remove) vars on_succ_free_vars
                    let on_fail_free_vars, on_fail_stack_size = f on_fail 
                    let free_vars =
                        let f x s = match x with RawRecordTestInjectVar(x,_) -> Map.add x pos s | RawRecordTestKeyword(x,_) -> s
                        map_union on_succ_free_vars on_fail_free_vars
                        |> map_add bind
                        |> Array.foldBack f vars
                    free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size                
                | RawRecordWith(binds,patterns) ->
                    let binds_free_vars, binds_stack_size =
                        Array.foldBack (fun x (free_vars, stack_size) ->
                            let free_vars', stack_size' = f x
                            map_union free_vars free_vars', max stack_size stack_size'
                            ) binds (Map.empty, 0)

                    let patterns_free_vars, patterns_stack_size =
                        Array.foldBack (fun x (free_vars, stack_size) ->
                            match x with
                            | RawRecordWithKeyword(keyword,expr) ->
                                let free_vars', stack_size' = f expr
                                let free_vars' = Map.remove "this" free_vars'
                                map_union free_vars free_vars',max stack_size (stack_size'+1)
                            | RawRecordWithInjectVar(var,expr) ->
                                let free_vars', stack_size' = f expr
                                let free_vars' = Map.remove "this" free_vars'
                                map_union free_vars free_vars' |> map_add var,max stack_size (stack_size'+1)
                            | RawRecordWithoutKeyword keyword -> free_vars,stack_size
                            | RawRecordWithoutInjectVar var -> map_add var free_vars,stack_size
                            ) patterns (Map.empty, 0)
                    map_union binds_free_vars patterns_free_vars, binds_stack_size+patterns_stack_size
                | RawExprPos(pos) ->
                    let pos, expr = pos.Pos, pos.Expression
                    f' (Some pos) expr
                | RawPattern x -> pattern x |> f
            f' None x
            ) x

    let env_add k (map,count) = Map.add k count map, count+1
    let env_init x args = 
        List.foldBack Map.remove args x 
        |> fun env -> Map.fold (fun env k _ -> env_add k env) (Map.empty, 0) env
        |> fun env -> List.fold (fun env k -> env_add k env) env args
    let env_to_array (map,count) = Map.toArray map |> Array.map snd

    let rec renaming x =
        memoize renaming_dict (fun x ->
            let rec f' ((map, count) as env) x =
                let inline f x = f' env x
                let inline v x = Map.find x map
                let inline array_free_vars_from x = Map.map (fun k _ -> Map.find k map) x |> Map.toArray |> Array.map snd
                match x with
                | RawV x -> V(tag(), v x)
                | RawLit x -> Lit(tag(), x)
                | RawFunction(expr, name) -> 
                    let free_vars, stack_size = free_vars_and_stack_size expr
                    let free_vars = Map.remove name free_vars
                    let array_free_vars = array_free_vars_from free_vars
                    Function(tag(),renaming expr,array_free_vars,stack_size + 1)
                | RawRecFunction(expr, name, rec_name) -> 
                    let free_vars, stack_size = free_vars_and_stack_size expr
                    let free_vars = Map.remove name free_vars |> Map.remove rec_name
                    let array_free_vars = array_free_vars_from free_vars
                    RecFunction(tag(),renaming expr,array_free_vars,stack_size + 2)
                | RawObjectCreate(ar) ->
                    let array_free_vars = 
                        memoize free_vars_dict (fun _ -> failwith "Compiler error: `free_vars` for RawObjectCreate need to be memoized.") x 
                        |> array_free_vars_from
                    let tagged_dict = TaggedDictionary(ar.Length,tag())
                    Array.iter (fun (keyword_string, expr) ->
                        let _, stack_size = free_vars_and_stack_size expr
                        try tagged_dict.Add(string_to_keyword keyword_string, (renaming expr, stack_size + 2))
                        with :? ArgumentException -> error <| sprintf "The same receiver %s already exists in the object." keyword_string
                        ) ar
                    ObjectCreate(tagged_dict, array_free_vars)
                | RawOp(_, args) | RawKeywordCreate(_,args) ->
                    Array.fold (fun (free_vars, stack_size) arg ->
                        let free_vars', stack_size' = f arg
                        map_union free_vars free_vars', max stack_size stack_size'
                        ) (Map.empty, 0) args
                | RawLet(var,bind,on_succ) | RawCase(var,bind,on_succ) -> 
                    let bind_free_vars, bind_stack_size = f bind
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    map_union bind_free_vars (Map.remove var on_succ_free_vars), 1 + max bind_stack_size on_succ_stack_size
                | RawListTakeAllTest(vars,bind,on_succ,on_fail)
                | RawListTakeNTest(vars,bind,on_succ,on_fail) 
                | RawKeywordTest(_,vars,bind,on_succ,on_fail) -> 
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    let on_succ_free_vars = Array.foldBack Map.remove vars on_succ_free_vars
                    let on_fail_free_vars, on_fail_stack_size = f on_fail 
                    let free_vars =
                        map_union on_succ_free_vars on_fail_free_vars
                        |> map_add bind
                    free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size
                | RawRecordTest(vars,bind,on_succ,on_fail) ->
                    let on_succ_free_vars, on_succ_stack_size = f on_succ
                    let on_succ_free_vars = 
                        let f (RawRecordTestKeyword(_,name) | RawRecordTestInjectVar(_,name)) = name
                        Array.foldBack (f >> Map.remove) vars on_succ_free_vars
                    let on_fail_free_vars, on_fail_stack_size = f on_fail 
                    let free_vars =
                        let f x s = match x with RawRecordTestInjectVar(x,_) -> Map.add x pos s | RawRecordTestKeyword(x,_) -> s
                        map_union on_succ_free_vars on_fail_free_vars
                        |> map_add bind
                        |> Array.foldBack f vars
                    free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size                
                | RawRecordWith(binds,patterns) ->
                    let binds_free_vars, binds_stack_size =
                        Array.foldBack (fun x (free_vars, stack_size) ->
                            let free_vars', stack_size' = f x
                            map_union free_vars free_vars', max stack_size stack_size'
                            ) binds (Map.empty, 0)

                    let patterns_free_vars, patterns_stack_size =
                        Array.foldBack (fun x (free_vars, stack_size) ->
                            match x with
                            | RawRecordWithKeyword(keyword,expr) ->
                                let free_vars', stack_size' = f expr
                                let free_vars' = Map.remove "this" free_vars'
                                map_union free_vars free_vars',max stack_size (stack_size'+1)
                            | RawRecordWithInjectVar(var,expr) ->
                                let free_vars', stack_size' = f expr
                                let free_vars' = Map.remove "this" free_vars'
                                map_union free_vars free_vars' |> map_add var,max stack_size (stack_size'+1)
                            | RawRecordWithoutKeyword keyword -> free_vars,stack_size
                            | RawRecordWithoutInjectVar var -> map_add var free_vars,stack_size
                            ) patterns (Map.empty, 0)
                    map_union binds_free_vars patterns_free_vars, binds_stack_size+patterns_stack_size
                | RawExprPos(pos) ->
                    let pos, expr = pos.Pos, pos.Expression
                    f' (Some pos) expr
                | RawPattern x -> pattern x |> f

            let args = memoize function_args_dict (fun _ -> []) x
            let free_vars, stack_size = free_vars_and_stack_size x
            f' (env_init free_vars args) x
            ) x

    ()