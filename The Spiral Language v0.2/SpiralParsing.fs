module Spiral.Parsing
open Spiral.Tokenize
open Spiral.ParserCombinators
open System
open System.Text

type Associativity = FParsec.Associativity

type VarString = string
type KeywordString = string

type Pos<'a>(pos : PosKey, expr : 'a) =
    member _.Expression = expr
    member _.Pos = pos
    override _.ToString() = sprintf "%A" expr

type Op =
    // Type
    | TypeAnnot
    | Box

    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice
    | StringFormat
    | StringConcat

    // Pair
    | PairCreate

    // Record
    | RecordMap
    | RecordFilter
    | RecordFoldL
    | RecordFoldR
    | RecordLength

    // Braching
    | If
    | While

    // BinOps
    | Add
    | Sub
    | Mult 
    | Div 
    | Mod 
    | Pow
    | LTE
    | LT
    | EQ
    | NEQ
    | GT
    | GTE 
    | BoolAnd
    | BoolOr
    | BitwiseAnd
    | BitwiseOr
    | BitwiseXor
    | ShiftLeft
    | ShiftRight

    // Join points
    | JoinPointEntryMethod
    | JoinPointAnnotEntryMethod
    
    // Application related
    | Apply

    // Array
    | ArrayCreateDotNet
    | ReferenceCreate
    | ArrayLength

    // Getters
    | GetArray
    | GetReference

    // Setters
    | SetArray
    | SetReference
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | Dynamize
    | IsLit
    | IsPrim

    // UnOps
    | Neg
    | FailWith

    // Auxiliary math ops
    | Tanh
    | Log
    | Exp
    | Sqrt
    | IsNan

    // Infinity
    | Infinity

type RawRecordTestPattern = 
    | RawRecordTestKeyword of keyword: KeywordString * name: VarString
    | RawRecordTestInjectVar of var: VarString * name: VarString
and RawRecordWithPattern = 
    | RawRecordWithKeyword of KeywordString * RawExpr 
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithoutKeyword of KeywordString 
    | RawRecordWithoutInjectVar of VarString
and PatRecordMembersItem =
    | PatRecordMembersKeyword of keyword: KeywordString * name: Pattern
    | PatRecordMembersInjectVar of var: VarString * name: Pattern

and Pattern =
    | PatUnit
    | PatE
    | PatVar of VarString
    | PatBox of Pattern
    | PatBoxAnnot of Pattern * RawTypeExpr
    | PatAnnot of Pattern * RawTypeExpr
    //| PatForallAnnot of VarString * RawTypeExpr

    | PatPair of Pattern * Pattern
    | PatKeyword of string * Pattern list
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatUnion of KeywordString * Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatValue of Value
    | PatDefaultValue of VarString
    | PatWhen of Pattern * RawExpr
    | PatPos of Pos<Pattern>

and RawExpr =
    | RawB
    | RawV of VarString 
    | RawLit of Value
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawType of RawTypeExpr
    | RawInl of VarString * RawExpr
    | RawForall of VarString * RawExpr
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawRecBlock of (VarString * RawExpr) [] * on_succ: RawExpr 
    | RawPairTest of var0: VarString * var1: VarString * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawAnnotTest of do_boxing : bool * RawTypeExpr * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawValueTest of Value * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawDefaultValueTest of string * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnionTest of name: KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnitTest of bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordCreate of KeywordString * RawExpr []
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    | RawPos of Pos<RawExpr>
and RawTypeExpr =
    | RawTVar of VarString
    | RawTPair of RawTypeExpr * RawTypeExpr
    | RawTFun of RawTypeExpr * RawTypeExpr
    | RawTConstraint of RawTypeExpr * RawTypeExpr
    | RawTDepConstraint of RawTypeExpr * RawTypeExpr
    | RawTRecord of Map<string,RawTypeExpr>
    | RawTKeyword of string * RawTypeExpr []
    | RawTApply of RawTypeExpr * RawTypeExpr
    | RawTForall of (string * RawTypeTypeExpr) [] * RawTypeExpr
    | RawTUnit
    | RawTPos of Pos<RawTypeExpr>
and RawTypeTypeExpr =
    | RawTType
    | RawTTFun of RawTypeTypeExpr * RawTypeTypeExpr

type ParserExpr =
    | ParserStatement of (RawExpr -> RawExpr)
    | ParserExpr of RawExpr

let inline expr_indent i op expr d = if op i (col d) then expr d else Error []

let semicolon (d: ParserEnv) = if d.Line <> d.semicolon_line then semicolon' d else d.FailWith(InvalidSemicolon) 

let expr_pos pos x = RawPos(Pos(pos,x))
let exprpos expr d =
    let pos = pos' d
    (expr |>> function RawInline _ | RawRecBlock _ | RawInl _ | RawForall _ as x -> x | x -> expr_pos pos x) d
let pat_pos pos x = PatPos(Pos(pos,x))
let patpos expr d = (expr |>> pat_pos (pos' d)) d

let inline concat_keyword'' f x =
    let strb = StringBuilder()
    let pattern = 
        List.map (fun (str : string, pat) -> 
            strb.Append(str).Append(':') |> ignore
            f str pat
            ) x
    strb.ToString(), pattern

let concat_keyword' x = concat_keyword'' (fun str -> function None -> PatVar str | Some pat -> pat) x

type FunsOrCons = Funs | Cons

let rec ttype' d = 
    let ttfun next = many1 next |>> List.reduceBack (fun a b -> RawTTFun(a,b))
    ttfun ((ttype >>% RawTType) <|> rounds ttype') d

let rec type_template is_outside (d : ParserEnv) =
    let recurse d = type_template false d
    let assert_allowed msg (d : ParserEnv) = if d.is_easy_phase then Ok() else d.Skip'(-1); d.FailWith msg
    let pairs next = sepBy1 next product |>> List.reduceBack (fun a b -> RawTPair(a,b))
    let arr_funs_cons next = 
        pipe2 next (many (((arr_fun >>% Funs) <|> (arr_cons >>. assert_allowed ConstraintNotAllowed >>% Cons)) .>>. next))
            (fun a l -> 
                let rec loop a = function   
                    | [] -> a
                    | (Funs, b) :: l -> RawTFun(a,loop b l)
                    | (Cons, b) :: l -> RawTConstraint(a,loop b l)
                loop a l)
    let arr_depcon next d = 
        pipe2 next (opt (arr_depcon >>. assert_allowed DepConstraintNotAllowed >>. next)) (fun a -> function Some b -> RawTDepConstraint(a,b) | None -> a) d
    let forall next (d : ParserEnv) = 
        let var d = (small_var' |>> fun x -> x, RawTType) d
        let var_annot d = rounds ((small_var' .>> colon) .>>. ttype') d
        (pipe2 (forall >>. assert_allowed TypeForallNotAllowed >>. many1 (var <|> var_annot) .>> dot) next (fun l x -> RawTForall(List.toArray l,x))
         <|> next) d
    let record next = curlies (many ((small_var' .>> colon) .>>. next)) |>> (Map.ofList >> RawTRecord)
    let keyword next = 
        (keyword_unary' |>> fun x -> RawTKeyword(x,[||]))
        <|> (many (keyword' .>>. next) |>> (concat_keyword'' (fun _ t -> t) >> fun (a, b) -> RawTKeyword(a, List.toArray b)))
    let var = (small_var <|> big_var) >>= fun (str, pos) d -> d.var_positions.Add(str,pos); Ok(RawTVar str)
    let parenths next = rounds (next <|>% RawTUnit)
    let tapply next = many1 next |>> List.reduce (fun a b -> RawTApply(a,b))

    if is_outside then
        (
        choice [|var; parenths recurse|] 
        ) d
    else
        (
        choice [|var; parenths recurse; record recurse; keyword recurse|] 
        |> tapply |> pairs |> arr_depcon |> arr_funs_cons |> forall
        ) d        

let type' d = (grave >>. type_template true) d
let type_annot d = type_template false d

let v x = RawV x

let rec pattern_template is_outer is_box expr s =
    let inline recurse s = pattern_template false is_box expr s

    let pat_when pattern = pattern .>>. (opt (when_ >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
    let pat_as pattern = pattern .>>. (opt (as_ >>. pattern )) |>> function a, Some b -> PatAnd [a;b] | a, None -> a
    let pat_or pattern = sepBy1 pattern or_ |>> function [x] -> x | x -> PatOr x
    let pat_keyword_fun l = concat_keyword'' (fun str -> function Some pat -> pat | None -> PatVar str) l
    let pat_keyword pattern = many1 (keyword' .>>. opt pattern) |>> (pat_keyword_fun >> PatKeyword) <|> pattern
    let pat_pair pattern = sepBy1 pattern comma |>> List.reduceBack (fun a b -> PatPair(a,b))
    let pat_and pattern = sepBy1 pattern and_ |>> function [x] -> x | x -> PatAnd x
    let pat_expr = (small_var' |>> v) <|> rounds expr
    let pat_type pattern = 
        pattern .>>. opt (colon >>. type_annot) 
        |>> function a,Some b as x -> (if is_box then PatBoxAnnot(a,b) else PatAnnot(a,b)) | a, None -> a
    let pat_wildcard = wildcard >>% PatE
    let pat_var = small_var' |>> PatVar
    let pat_active pattern = exclamation >>. pat_expr .>>. pattern |>> PatActive
    let pat_union pattern = pipe2 big_var' (many ((small_var' |>> PatVar) <|> rounds pattern)) (fun a b -> PatUnion(a,b))
    let pat_value = (value_ |>> PatValue) <|> (def_value_' |>> PatDefaultValue)
    let pat_record_item pattern =
        let inline templ var k = pipe2 var (opt (eq >>. pattern)) (fun a -> function Some b -> k(a,b) | None -> k(a,PatVar a))
        templ small_var' (fun (str,name) -> PatRecordMembersKeyword(str,name)) <|> templ (dollar >>. small_var') PatRecordMembersInjectVar
    let pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
    let pat_keyword_unary = keyword_unary |>> fun (keyword,_) -> PatKeyword(keyword,[])
    let pat_rounds pattern = rounds (pattern <|> (op' |>> PatVar) <|>% PatUnit) 

    if is_outer then
        (
        choice [|pat_wildcard; pat_var; pat_value; pat_record recurse; pat_keyword_unary; pat_rounds recurse|]
        |> pat_pair |> pat_keyword
        ) s
    else
        (
        choice [|pat_wildcard; pat_var; pat_active recurse; pat_value; pat_union recurse; pat_record recurse; pat_keyword_unary; pat_rounds recurse|] 
        |> pat_type |> pat_and |> pat_pair |> pat_keyword |> pat_or |> pat_as |> pat_when
        ) s

let inline pattern is_outer is_box expr s = patpos (pattern_template is_outer is_box expr) s

let set_semicolon_level line p (d: ParserEnv) = p {d with semicolon_line = line}
let set_keyword_level line p (d: ParserEnv) = p {d with semicolon_line = line; keyword_line = line}
let reset_level expr d = expr {d with semicolon_line= -1; keyword_line= -1}

let inline statement_body expr = eq >>. reset_level expr
let inline expression_body expr = arr_fun >>. reset_level expr

let lit x = RawLit x
let inline_ = function RawInline _ as x -> x | x -> RawInline x
let inl x y = RawInl(x,y)
//let keyword_ k l = RawKeywordCreate(k,l)
//let keyword_unary_ k = RawKeywordCreate(k,[||])
let l bind body on_succ = RawLet(bind,body,on_succ)
//let case bind body on_succ = RawCase(bind,body,on_succ)
let if_ cond on_succ on_fail = RawOp(If,[|cond;on_succ;on_fail|])
//let keyword_test keyword x bind on_succ on_fail = RawKeywordTest(keyword,x,bind,on_succ,on_fail)
//let record_test x bind on_succ on_fail = RawRecordTest(x,bind,on_succ,on_fail)
//let record_with binds patterns = RawRecordWith(binds,patterns)
let ty x = RawType x

let op x args = RawOp(x,args)
let box x = op Box x
let B = RawB

let unop op' a = op op' [|a|]
let binop op' a b = op op' [|a;b|]
let eq x y = binop EQ x y
let ap x y = binop Apply x y
let rec ap' f l = Array.fold ap f l

// The seemingly useless function application is there to filter unused arguments from the environment and move the rest to `env_global`.
let join_point_entry_method y = inline_ (op JoinPointEntryMethod [|y|])

let annotations expr d = 
    let i = col d
    let inline expr_indent expr d = expr_indent i (<=) expr d
    pipe2 (expr_indent expr) (opt (expr_indent colon >>. expr_indent type_annot))
        (fun a -> function
            | Some b -> binop TypeAnnot a (ty b)
            | None -> a) d

let process_parser_exprs exprs = 
    let error_statement_in_last_pos = pfail StatementLastInBlock
    let rec process_parser_exprs on_succ = function
        | [ParserExpr a] -> on_succ a
        | [ParserStatement _] -> error_statement_in_last_pos
        | ParserStatement a :: xs -> process_parser_exprs (a >> on_succ) xs
        | ParserExpr a :: xs -> process_parser_exprs (l "" (unop ErrorNonUnit a) >> on_succ) xs
        | [] -> on_succ B
            
    process_parser_exprs preturn (List.concat exprs)

let indentations expr d =
    let i = col d
    let inline if_ op tr s = expr_indent i op tr s

    let inline many_semis expr = many (if_ (<) semicolon >>. if_ (<) expr)
    let inline many_indents expr = many1 (if_ (=) (pipe2 expr (many_semis expr) (fun a b -> a :: b)))
    (many_indents expr >>= process_parser_exprs) d

let pattern_to_rawexpr (arg: VarString, clauses: (Pattern * RawExpr) []) = 
    let mutable tag = 0
    let patvar () = 
        let x = sprintf " pat_var%i" tag
        tag <- tag + 1
        x

    let rec cp (arg: VarString) (pat: Pattern) (on_succ: RawExpr) (on_fail: RawExpr): RawExpr =
        let step pat on_succ = 
            match pat with
            | PatVar arg -> arg, on_succ
            | _ -> let arg = patvar() in arg, cp arg pat on_succ on_fail
        let test f pats = 
            let binds, on_succ = List.mapFoldBack step pats on_succ
            f(List.toArray binds,on_succ)
        match pat with
        | PatUnit -> RawUnitTest(arg,on_succ,on_fail)
        | PatE -> on_succ
        | PatVar x -> l x (v arg) on_succ
        | PatBox exp -> 
            let on_succ = cp arg exp on_succ on_fail
            l arg (unop Box (v arg)) on_succ
        | PatBoxAnnot(exp,typ) -> 
            let on_succ = cp arg exp on_succ on_fail
            RawAnnotTest(true,typ,arg,on_succ,on_fail)
        | PatAnnot (exp,typ) ->
            let on_succ = cp arg exp on_succ on_fail
            RawAnnotTest(false,typ,arg,on_succ,on_fail)
        | PatPair(a,b) -> 
            let b,on_succ = step b on_succ
            let a,on_succ = step a on_succ
            RawPairTest(a,b,arg,on_succ,on_fail)
        | PatKeyword(keyword,pats) -> test (fun (vars,on_succ) -> RawKeywordTest(keyword,vars,arg,on_succ,on_fail)) pats
        | PatActive (a,b) ->
            let pat_var = patvar()
            l pat_var (ap a (v arg)) (cp pat_var b on_succ on_fail)
        | PatOr l -> List.foldBack (fun pat on_fail -> cp arg pat on_succ on_fail) l on_fail
        | PatAnd l -> List.foldBack (fun pat on_succ -> cp arg pat on_succ on_fail) l on_succ
        | PatValue x -> RawValueTest(x,arg,on_succ,on_fail)
        | PatDefaultValue x -> RawDefaultValueTest(x,arg,on_succ,on_fail)
        | PatWhen (p, e) -> cp arg p (if_ e on_succ on_fail) on_fail
        | PatPos p -> expr_pos p.Pos (cp arg p.Expression on_succ on_fail)
        | PatUnion(name, pats) -> test (fun (vars,on_succ) -> RawUnionTest(name,vars,arg,on_succ,on_fail)) pats
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

    let inline g f = Array.foldBack (fun (pat, exp) on_fail -> cp arg pat (f exp) on_fail) clauses (op ErrorPatMiss [|v arg|])
    if clauses.Length > 1 then g inline_ else g id

let pat_main = " pat_main"
let pattern_to_rawinl pat body =
    let inline f expr_pos = function
        | PatE -> RawInl("", expr_pos body)
        | PatVar name -> RawInl(name, expr_pos body)
        | _ -> RawInl(pat_main, expr_pos <| pattern_to_rawexpr(pat_main, [|pat, body|]))
    match pat with
    | PatPos x -> f (expr_pos x.Pos) x.Expression
    | x -> f id x
let compile_patterns pats body = List.foldBack pattern_to_rawinl pats body

type StatementType = StatementVarOp of string | StatementPattern of (RawExpr -> RawExpr)

let statements expr (d: ParserEnv) =
    let handle_inl_rec_block (l, l') (d: ParserEnv) = 
        (l :: l') 
        |> List.toArray
        |> fun x on_succ -> RawRecBlock(x,on_succ)
        |> ParserStatement |> Ok

    let handle_inl_expression pats body = List.foldBack (<|) pats body |> ParserExpr
    let handle_inl_statement arg pats body = 
        fun on_succ -> l arg (List.foldBack (<|) pats body) on_succ
        |> ParserStatement
    let inline inb_templ l pat body =
        fun on_succ ->
            match pattern_to_rawinl pat on_succ with
            | RawInl(arg,on_succ) -> l arg body on_succ
            | _ -> failwith "impossible"
        |> ParserStatement
    let handle_inb pat body = inb_templ (fun arg body on_succ -> ap body (inl arg on_succ)) pat body
    let handle_inm pat body = inb_templ (fun arg body on_succ -> ap (ap (v ">>=") body) (inl arg on_succ)) pat body

    let i = col d
    let inline if_ tr s = expr_indent i (=) tr s

    let forall d =
        let var = small_var'
        let var_annot d = rounds ((small_var' .>> colon) .>> ttype') d // TODO: Make use of the annotations in foralls.
        (
        forall >>. many1 (var <|> var_annot) .>> dot
        |>> List.foldBack (fun x on_succ -> RawForall(x,on_succ))
        ) d

    let pattern' expr = forall <|> (pattern true false expr |>> pattern_to_rawinl)
    let ret_type = opt (colon >>. type')

    match d.PeekSpecial with
    | Ok x ->
        match x with
        | SpecInl ->
            d.Skip
            match d.SkipSpecial SpecRec with
            | Ok _ -> 
                let name_pats_body d = 
                    (tuple3 var_op' (many (pattern' expr)) (statement_body expr) >>= fun (name,pats,body) d ->
                        match List.foldBack (<|) pats body with
                        | RawInl _ | RawForall _ as x -> Ok(name,x)
                        | _ -> d.FailWith ExpectedFunction
                        ) d
                (name_pats_body .>>. (many (if_ (and' >>. name_pats_body))) >>= handle_inl_rec_block) d
            | Error _ ->
                (
                tuple3 ((var_op' |>> StatementVarOp) <|> (pattern' expr |>> StatementPattern)) (many (pattern' expr)) ret_type
                >>= fun (init,pats,ret_type) d -> // TODO: Make use of the return type.
                    match init with
                    | StatementVarOp name -> 
                        ((statement_body expr |>> handle_inl_statement name pats) 
                         <|> (expression_body expr |>> handle_inl_expression (inl name :: pats))) d
                    | StatementPattern pat -> (expression_body expr |>> handle_inl_expression (pat :: pats)) d
                ) d
        | SpecInm -> d.Skip; pipe2 (pattern true false expr) (statement_body expr) handle_inm d
        | SpecInb -> d.Skip; pipe2 (pattern true false expr) (statement_body expr) handle_inb d
        | _ -> d.FailWith ExpectedStatement
    | Error _ -> d.FailWith ExpectedStatement
        
