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

let private free_vars_and_stack_size_dict = ConditionalWeakTable()
let private pattern_dict = ConditionalWeakTable()

let pattern x = 
    memoize' pattern_dict (fun (arg: VarString, clauses: (Pattern * RawExpr) []) ->
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
    memoize' free_vars_and_stack_size_dict (fun x ->
        let rec f' (pos: PosKey option) x = 
            let inline f x = f' pos x
            match x with
            | RawV x -> Map.empty.Add(x, pos), 0
            | RawLit _ -> Map.empty, 0
            | RawFunction(expr, name) ->
                let free_vars, _ = free_vars_and_stack_size expr
                Map.remove name free_vars, 0
            | RawRecFunction(expr, name, rec_name) ->
                let free_vars, _ = free_vars_and_stack_size expr
                Map.remove name free_vars |> Map.remove rec_name, 0
            | RawObjectCreate(ar) ->
                let free_vars =
                    Array.fold (fun free_vars (keyword_string, expr) ->
                        let free_vars', _ = free_vars_and_stack_size expr
                        free_vars' 
                        |> Map.remove "self" 
                        |> Map.remove Types.pat_main
                        |> map_union free_vars
                        ) Map.empty ar
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
                    |> Map.add bind pos
                free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size
            | RawRecordTest(vars,bind,on_succ,on_fail) ->
                let varnames = 
                    Array.foldBack (fun x s ->
                        match x with
                        | RawRecordTestInjectVar(_,x) -> Map.add x pos s
                        | RawRecordTestKeyword(_,x) -> s
                        ) vars Map.empty
                    
                let vars_free_vars =
                    Array.foldBack (fun x s ->
                        match x with
                        | RawRecordTestInjectVar(x,_) -> Map.add x pos s
                        | RawRecordTestKeyword(x,_) -> s
                        ) vars Map.empty
                let on_succ_free_vars, on_succ_stack_size = f on_succ
                let on_succ_free_vars = Array.foldBack Map.remove vars_free_vars on_succ_free_vars
                let on_fail_free_vars, on_fail_stack_size = f on_fail 
                let free_vars =
                    map_union on_succ_free_vars on_fail_free_vars
                    |> Map.add bind pos
                free_vars, vars.Length + max on_succ_stack_size on_fail_stack_size                
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
        f' None x
        ) x

