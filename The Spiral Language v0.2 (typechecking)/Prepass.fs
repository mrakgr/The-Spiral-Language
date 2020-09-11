module Spiral.Prepass

type Id = int32
type FreeVars = {|type' : int; term : int|}
type Range = { uri : string; range : Config.VSCRange }

type Macro =
    | MacroText of Range * string
    | MacroTypeVar of Range * Id
    | MacroTermVar of Range * Id
type RecordWith =
    | RecordWithSymbol of (Range * string) * Expr
    | RecordWithSymbolModify of (Range * string) * Expr
    | RecordWithInjectVar of (Range * Id) * Expr
    | RecordWithInjectVarModify of (Range * Id) * Expr
and RecordWithout =
    | RecordWithoutSymbol of Range * string
    | RecordWithoutInjectVar of Range * Id
and PatRecordMember =
    | PatRecordMembersSymbol of (Range * string) * Id
    | PatRecordMembersInjectVar of (Range * Id) * Id
and Expr =
    | B of Range
    | V of Range * Id
    | Lit of Range * Tokenize.Literal
    | DefaultLit of Range * string * TExpr
    | SymbolCreate of Range * string
    | Type of Range * TExpr
    | Let of Range * Id * Expr * Expr
    | Fun of Range * FreeVars * Id * Expr
    | Forall of Range * FreeVars * Id * Expr
    | RecBlock of Range * ((Range * Id) * Expr) list * on_succ: Expr
    | RecordWith of Range * Expr list * RecordWith list * RecordWithout list
    | Op of Range * BlockParsing.Op * Expr list
    | JoinPoint of Range * FreeVars * Expr
    | Annot of Range * Expr * TExpr
    | Typecase of Range * TExpr * (TExpr * Expr) list
    | ModuleOpen of Range * (Range * Id) * (Range * string) list * on_succ: Expr
    | Apply of Range * Expr * Expr
    | Macro of Range * Macro list
    | Recursive of Range * Expr ref
    | PatternMemo of Range * Expr // Acts like a join point during the prepass. Should not appear during peval.
    | PairTest of Range * bind: Id * pat: Id list * on_succ: Expr * on_fail: Expr
    | KeywordTest of Range * string * bind: Id * on_succ: Expr * on_fail: Expr
    | RecordTest of Range * PatRecordMember list * bind: Id * on_succ: Expr * on_fail: Expr
    | AnnotTest of Range * TExpr * bind: Id * on_succ: Expr * on_fail: Expr
    | LitTest of Range * Tokenize.Literal * bind: Id * on_succ: Expr * on_fail: Expr
    | UnitTest of Range * bind: Id * on_succ: Expr * on_fail: Expr
    | NominalTest of Range * nominal: Id * bind: Id * on_succ: Expr * on_fail: Expr
and TExpr =
    | S

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
