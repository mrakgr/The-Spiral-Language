module Spiral.Prepass

//let inl l = RawInl l
//let v x = RawV x
//let l bind body on_succ = RawLet(bind,body,on_succ)
//let inline_ = function RawInline _ as x -> x | x -> RawInline x
//let if' cond on_succ on_fail = RawOp(If,[|cond;on_succ;on_fail|])
//let ty x = RawType x
//let B = RawB

//let unop op' a = RawOp(op',[|a|])
//let dyn x = unop Dyn x
//let binop op' a b = RawOp(op',[|a;b|])
//let eq x y = binop EQ x y
//let ap x y = binop Apply x y
//let rec ap' f l = Array.fold ap f l

//let lit' x = RawLit x
//let lit_string x = RawLit(LitString x)
//let def_lit' x = RawDefaultLit x

//let pattern_to_rawexpr (arg: VarString, clauses: (Pattern * RawExpr) []) = 
//    let mutable tag = 0
//    let patvar () = 
//        let x = sprintf " pat_var%i" tag
//        tag <- tag + 1
//        x

//    let rec cp' is_dyned (arg: VarString) (pat: Pattern) (on_succ: RawExpr) (on_fail: RawExpr): RawExpr =
//        let cp = cp' is_dyned
//        let step pat on_succ = 
//            match pat with
//            | PatVar arg -> arg, on_succ
//            | _ -> let arg = patvar() in arg, cp arg pat on_succ on_fail
//        match pat with
//        | PatOperator _ -> failwith "Compiler error: PatOperator case is an error that should be caught during validation."
//        | PatB -> RawBTest(arg,on_succ,on_fail)
//        | PatE -> on_succ
//        | PatVar x -> l x (v arg) on_succ
//        | PatDyn x when is_dyned -> cp arg x on_succ on_fail
//        | PatDyn x -> let arg' = patvar() in l arg' (dyn (v arg)) (cp' true arg' x on_succ on_fail)
//        | PatAnnot (exp,typ) ->
//            let on_succ = cp arg exp on_succ on_fail
//            RawAnnotTest(typ,arg,on_succ,on_fail)
//        | PatPair(a,b) -> 
//            let b,on_succ = step b on_succ
//            let a,on_succ = step a on_succ
//            RawPairTest(a,b,arg,on_succ,on_fail)
//        | PatNominal(a,b) -> 
//            let arg', on_succ = step b on_succ
//            RawNominalTest(a,arg',arg,on_succ,on_fail)
//        | PatSymbol x -> RawSymbolTest(x,arg,on_succ,on_fail)
//        | PatActive (a,b) -> let arg', on_succ = step b on_succ in l arg' (ap a (v arg)) on_succ
//        | PatOr(a,b) -> let on_succ = inline_ on_succ in cp arg a on_succ (cp arg b on_succ on_fail)
//        | PatAnd(a,b) -> let on_fail = inline_ on_fail in cp arg a (cp arg b on_succ on_fail) on_fail
//        | PatValue x -> RawValueTest(x,arg,on_succ,on_fail)
//        | PatDefaultValue x -> RawDefaultLitTest(x,arg,on_succ,on_fail)
//        | PatWhen(p, e) -> cp arg p (if' e on_succ on_fail) on_fail
//        | PatUnbox p -> let arg', on_succ = step p on_succ in RawCase(arg', arg, on_succ)
//        | PatRecordMembers items ->
//            let binds, on_succ =
//                List.mapFoldBack (fun item on_succ ->
//                    match item with
//                    | PatRecordMembersSymbol(keyword,name) -> let arg, on_succ = step name on_succ in RawRecordTestSymbol(keyword,arg), on_succ
//                    | PatRecordMembersInjectVar(var,name) -> let arg, on_succ = step name on_succ in RawRecordTestInjectVar(var,arg), on_succ
//                    ) items on_succ
//            RawRecordTest(List.toArray binds,arg,on_succ,on_fail)

//    Array.foldBack (fun (pat, exp) (i, on_fail) -> 
//        i - 1, cp' false arg pat (if i <> 0 then inline_ exp else exp) on_fail
//        ) clauses (clauses.Length - 1, RawOp(ErrorPatMiss, [|v arg|])) |> snd
