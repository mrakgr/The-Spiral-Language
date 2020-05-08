module Spiral.Parsing
open Spiral.Tokenize
open Spiral.ParserCombinators
open System
open System.Text
open System.Collections.Generic

type Associativity = FParsec.Associativity

type VarString = string
type KeywordString = string

type Pos<'a>(pos : PosKey, expr : 'a) =
    member _.Expression = expr
    member _.Pos = pos
    override _.ToString() = sprintf "%A" expr

type Op =
    // Macro
    | Macro
    | MacroExtern

    // Reified join points
    | RJPToNone
    | RJPToStack
    | RJPToHeap

    // Type
    | TypeAnnot
    | Box

    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice

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

    // Application related
    | Apply

    // Array
    | ArrayCreate
    | ArrayLength

    // Getters
    | GetArray

    // Setters
    | SetArray
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | Dynamize
    | IsLit
    | IsPrim
    | IsRJP
    | IsKeyword
    | StripKeyword
    | EqType

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
    | InfinityF64
    | InfinityF32

type PrimitiveType =
    | UInt8T
    | UInt16T
    | UInt32T
    | UInt64T
    | Int8T
    | Int16T
    | Int32T
    | Int64T
    | Float32T
    | Float64T
    | BoolT
    | StringT
    | CharT

type OpenKind =
| OpenType of string
| OpenValue of string

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
    | PatBoxVar of VarString
    | PatBoxAnnot of Pattern * RawTExpr
    | PatAnnot of Pattern * RawTExpr

    | PatPair of Pattern * Pattern
    | PatKeyword of string * Pattern list
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatUnion of KeywordString * Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatValue of Literal
    | PatDefaultValue of VarString
    | PatWhen of Pattern * RawExpr
    | PatPos of Pos<Pattern>

and RawExpr =
    | RawB
    | RawV of VarString
    | RawLit of Literal
    | RawDefaultLit of string
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawType of RawTExpr
    | RawInl of VarString * RawExpr
    | RawForall of VarString * RawExpr
    | RawKeywordCreate of KeywordString * RawExpr []
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    //| RawTypedOp of ret_type: RawTExpr * Op * RawExpr []
    | RawJoinPoint of RawTExpr option * RawExpr
    | RawAnnot of RawTExpr * RawExpr
    | RawTypecase of RawTExpr * (RawTExpr * RawExpr) []
    | RawModuleOpen of string * (OpenKind * string option) list option * on_succ: RawExpr
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawRecBlock of (VarString * RawExpr) [] * on_succ: RawExpr
    | RawPairTest of var0: VarString * var1: VarString * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawAnnotTest of do_boxing : bool * RawTExpr * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawValueTest of Literal * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawDefaultLitTest of string * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnionTest of name: KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnitTest of bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawPos of Pos<RawExpr>
and RawTExpr =
    | RawTVar of VarString
    | RawTPair of RawTExpr * RawTExpr
    | RawTFun of RawTExpr * RawTExpr
    | RawTConstraint of RawTExpr * RawTExpr
    | RawTDepConstraint of RawTExpr * RawTExpr
    | RawTRecord of Map<string,RawTExpr>
    | RawTKeyword of KeywordString * RawTExpr []
    | RawTApply of RawTExpr * RawTExpr
    | RawTForall of (VarString * RawTTExpr) * RawTExpr
    | RawTInl of (VarString * RawTTExpr) * RawTExpr
    | RawTUnit
    | RawTPrim of PrimitiveType
    | RawTArray of RawTExpr
    | RawTPos of Pos<RawTExpr>
and RawTTExpr =
    | RawTTType
    | RawTTFun of RawTTExpr * RawTTExpr

type ParserExpr =
    | ParserStatement of (RawExpr -> RawExpr)
    | ParserExpr of RawExpr

let inbuilt_operators = 
    let inbuilt_operators = Dictionary(HashIdentity.Structural)
    let add_infix_operator assoc str prec = inbuilt_operators.Add(str, (prec, assoc))

    let left_assoc_ops = 
        let f = add_infix_operator Associativity.Left
        f "+" 60; f "-" 60; f "*" 70; f "/" 70; f "%" 70
        f "<|" 10; f "|>" 10; f "<<" 10; f ">>" 10

        let f str = add_infix_operator Associativity.None str 40
        f "<="; f "<"; f "="; f "`="; f ">"; f ">="; f "<>"
        f "<<<"; f ">>>"; f "&&&"; f "|||"

    let right_associative_ops =
        let f str prec = add_infix_operator Associativity.Right str prec
        f "||" 20; f "&&" 30; f "::" 50; f "^^^" 45
        f ";" 4; f "," 5; f ":>" 35; f ":?>" 35; f "**" 80
    inbuilt_operators

let inline expr_indent i op expr d = if op i (col d) then expr d else Error []

let expr_pos pos = function
    | RawPos _ as x -> x
    | x -> RawPos(Pos(pos,x))
let exprpos expr d =
    let pos = pos' d
    (expr |>> function RawB | RawType _ | RawInline _ | RawRecBlock _ | RawInl _ | RawForall _ as x -> x | x -> expr_pos pos x) d
let pat_pos pos = function
    | PatPos _ as x -> x
    | x -> PatPos(Pos(pos,x))
let patpos expr d = (expr |>> pat_pos (pos' d)) d

let inline concat_keyword f x =
    let strb = StringBuilder()
    let pattern = 
        List.map (fun (str : string, pat) -> 
            strb.Append(str).Append(':') |> ignore
            f str pat
            ) x
    strb.ToString(), pattern

let concat_keyword' x = concat_keyword (fun str -> function None -> PatVar str | Some pat -> pat) x

type FunsOrCons = Funs | Cons

let rec ttype' d = 
    let ttfun next = many1 next |>> List.reduceBack (fun a b -> RawTTFun(a,b))
    ttfun ((ttype >>% RawTTType) <|> rounds ttype') d

let rec type_template is_outside (d : ParserEnv) =
    let recurse d = type_template false d
    let assert_allowed msg (d : ParserEnv) = if d.is_top_down then Ok() else d.Skip'(-1); d.FailWith msg
    let pairs next = sepBy1 next product |>> List.reduceBack (fun a b -> RawTPair(a,b))
    let arr_funs_cons next = 
        pipe2 next (many (((arr_fun >>% Funs) <|> (arr_cons >>. assert_allowed ConstraintNotAllowed >>% Cons)) .>>. next))
            (fun a l -> 
                let rec loop a = function   
                    | [] -> a
                    | (Funs, b) :: l -> RawTFun(a,loop b l)
                    | (Cons, b) :: l -> RawTConstraint(a,loop b l)
                loop a l)
    let arr_depcon next = 
        pipe2 next (opt (arr_depcon >>. assert_allowed DepConstraintNotAllowed >>. next)) (fun a -> function Some b -> RawTDepConstraint(a,b) | None -> a)
    let forall next = 
        let var d = (small_var |>> fun x -> x, RawTTType) d
        let var_annot d = rounds ((small_var .>> colon) .>>. ttype') d
        pipe2 (forall >>. assert_allowed TypeForallNotAllowed >>. many1 (var <|> var_annot) .>> dot) next (List.foldBack (fun x s -> RawTForall(x,s)))
        <|> next
    let record next = curlies (many ((small_var .>> colon) .>>. next)) |>> (Map.ofList >> RawTRecord)
    let keyword next = 
        (keyword_unary' |>> fun x -> RawTKeyword(x,[||]))
        <|> (many (keyword .>>. next) |>> (concat_keyword (fun _ t -> t) >> fun (a, b) -> RawTKeyword(a, List.toArray b)))
    let var = (big_var <|> small_var) |>> function
        | "i8" -> RawTPrim Int8T
        | "i16" -> RawTPrim Int16T
        | "i32" -> RawTPrim Int32T
        | "i64" -> RawTPrim Int64T
        | "u8" -> RawTPrim UInt8T
        | "u16" -> RawTPrim UInt16T
        | "u32" -> RawTPrim UInt32T
        | "u64" -> RawTPrim UInt64T
        | "f32" -> RawTPrim Float32T
        | "f64" -> RawTPrim Float64T
        | x -> RawTVar x
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
let type_annot d = type_template true d

let v x = RawV x

let rec pattern_template is_outer is_box expr s =
    let inline recurse s = pattern_template false is_box expr s

    let pat_when pattern = pattern .>>. (opt (when_ >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
    let pat_as pattern = pattern .>>. (opt (as_ >>. pattern )) |>> function a, Some b -> PatAnd [a;b] | a, None -> a
    let pat_or pattern = sepBy1 pattern or_ |>> function [x] -> x | x -> PatOr x
    let pat_keyword_fun l = concat_keyword (fun str -> function Some pat -> pat | None -> PatVar str) l
    let pat_keyword pattern = many1 (keyword .>>. opt pattern) |>> (pat_keyword_fun >> PatKeyword) <|> pattern
    let pat_pair pattern = sepBy1 pattern comma |>> List.reduceBack (fun a b -> PatPair(a,b))
    let pat_and pattern = sepBy1 pattern and_ |>> function [x] -> x | x -> PatAnd x
    
    let pat_type pattern = 
        pattern .>>. opt (colon >>. type_annot)
        |>> function a,Some b as x -> (if is_box then PatBoxAnnot(a,b) else PatAnnot(a,b)) | a, None -> a
    let pat_wildcard = wildcard >>% PatE
    let pat_var = small_var |>> fun x -> if is_box then PatBoxVar x else PatVar x
    let pat_active pattern = exclamation >>. ((small_var |>> v) <|> rounds expr) .>>. pattern |>> PatActive
    let pat_union pattern = pipe2 big_var (many ((small_var |>> PatVar) <|> rounds pattern)) (fun a b -> PatUnion(a,b))
    let pat_value = (value_ |>> PatValue) <|> (def_value_ |>> PatDefaultValue)
    let pat_record_item pattern =
        let inline templ var k = pipe2 var (opt (eq' >>. pattern)) (fun a -> function Some b -> k(a,b) | None -> k(a,PatVar a))
        templ small_var (fun (str,name) -> PatRecordMembersKeyword(str,name)) <|> templ (dollar >>. small_var) PatRecordMembersInjectVar
    let pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
    let pat_keyword_unary = keyword_unary' |>> fun keyword -> PatKeyword(keyword,[])
    let pat_rounds pattern = rounds (pattern <|> (op |>> PatVar) <|>% PatUnit) 

    if is_outer then
        (
        choice [|pat_wildcard; pat_var; pat_value; pat_record recurse; pat_keyword_unary; pat_rounds recurse|]
        |> pat_and |> pat_pair |> pat_keyword
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

let ret_type d = opt (colon >>. type_annot) d
let inline_ = function RawInline _ as x -> x | x -> RawInline x

let join_point_entry_method y = 
    match y with RawPos y -> y.Expression | y -> y
    |> function
        // The seemingly useless inline_ is there to filter unused arguments from the environment.
        | RawAnnot(ret_type, y) -> inline_ (RawJoinPoint(Some ret_type, y))
        | _ -> inline_ (RawJoinPoint(None, y))

let with_ret_type ret_type e =
    match ret_type with
    | Some t ->
        match e with
        | RawInline(RawJoinPoint(None,x)) -> RawInline(RawJoinPoint(ret_type,x))
        | _ -> RawAnnot(t,e)
    | None -> e

let inline statement_body expr = pipe2 (ret_type .>> eq') (reset_level expr) with_ret_type
let inline expression_body' expr = arr_fun >>. reset_level expr
let inline expression_body expr = pipe2 (ret_type .>> arr_fun) (reset_level expr) with_ret_type

let inl x y = RawInl(x,y)
let l bind body on_succ = RawLet(bind,body,on_succ)
let if' cond on_succ on_fail = RawOp(If,[|cond;on_succ;on_fail|])
let ty x = RawType x
let B = RawB

let unop op' a = RawOp(op',[|a|])
let box' x = unop Box x
let binop op' a b = RawOp(op',[|a;b|])
let eq x y = binop EQ x y
let ap x y = binop Apply x y
let rec ap' f l = Array.fold ap f l

let lit' x = RawLit x
let lit_string x = RawLit(LitString x)
let def_lit' x = RawDefaultLit x

let type_annot' a = function
    | Some b -> RawAnnot(b,a)
    | None -> a

let annotations expr d = 
    let i = col d
    let inline expr_indent expr d = expr_indent i (<=) expr d
    pipe2 (expr_indent expr) (opt (expr_indent colon >>. expr_indent type_annot)) type_annot' d

let process_parser_exprs (exprs, in') (d : ParserEnv) =
    let f x s = match x with ParserExpr a -> l "" (unop ErrorNonUnit a) s | ParserStatement a -> a s
    match in' with
    | Some in' -> Ok(List.foldBack f exprs in')
    | None -> 
        match List.rev exprs with
        | ParserStatement _ :: _ -> d.FailWith StatementLastInBlock
        | ParserExpr x :: xs -> Ok(List.fold (fun a b -> f b a) x xs)
        | [] -> failwith "impossible"

let rec indentations expr d =
    let i = col d
    let inline if_ op tr s = expr_indent i op tr s

    (many1 (if_ (=) expr) .>>. opt (if_ (<=) in_ >>. if_ (<=) (indentations expr)) >>= process_parser_exprs) d

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
        | PatBoxVar x -> l x (box' (v arg)) on_succ
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
        | PatOr l -> let on_succ = inline_ on_succ in List.foldBack (fun pat on_fail -> cp arg pat on_succ on_fail) l on_fail
        | PatAnd l -> let on_fail = inline_ on_fail in List.foldBack (fun pat on_succ -> cp arg pat on_succ on_fail) l on_succ
        | PatValue x -> RawValueTest(x,arg,on_succ,on_fail)
        | PatDefaultValue x -> RawDefaultLitTest(x,arg,on_succ,on_fail)
        | PatWhen (p, e) -> cp arg p (if' e on_succ on_fail) on_fail
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

    let inline g f = Array.foldBack (fun (pat, exp) on_fail -> cp arg pat (f exp) on_fail) clauses (RawOp(ErrorPatMiss, [|v arg|]))
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

let forall d =
    let var = small_var
    let var_annot d = rounds ((small_var .>> colon) .>> ttype') d // TODO: Make use of the annotations in foralls.
    (
    forall >>. many1 (var <|> var_annot) .>> dot
    |>> List.foldBack (fun x on_succ -> RawForall(x,on_succ))
    ) d

let statements is_global expr (d: ParserEnv) =
    let handle_inl_rec_block (l, l') (d: ParserEnv) = 
        (l :: l') 
        |> List.toArray
        |> fun x on_succ -> RawRecBlock(x,on_succ)
        |> Ok

    let handle_inl_statement (name, body) = fun on_succ -> l name body on_succ
    let inline inb_templ l pat body =
        fun on_succ ->
            match pattern_to_rawinl pat on_succ with
            | RawInl(arg,on_succ) -> l arg body on_succ
            | _ -> failwith "impossible"
    let handle_inb pat body = inb_templ (fun arg body on_succ -> ap body (inl arg on_succ)) pat body
    let handle_inm pat body = inb_templ (fun arg body on_succ -> ap (ap (v ">>=") body) (inl arg on_succ)) pat body
    let handle_open a b = fun on_succ -> RawModuleOpen(a,b,on_succ)

    let i = col d
    let inline if_ tr s = expr_indent i (=) tr s
   
    let inline inl join_point_entry_method pattern' =
        let inline name_pats_body on_else = 
            tuple3 var_op (many pattern') (statement_body expr) >>= fun (name,pats,body) d ->
                match List.foldBack (<|) pats (join_point_entry_method body) with
                | RawInl _ | RawForall _ as x -> Ok(name,x)
                | x -> if is_global then d.FailWith ExpectedGlobalFunction else on_else (name,x) d

        let pat_body = pattern true false expr .>>. statement_body expr |>> fun (pat,body) -> 
            fun on_succ -> 
                match pat with PatPos x -> x.Expression | x -> x
                |> function
                    | PatE -> l "" body on_succ
                    | PatVar name -> l name body on_succ
                    | _ -> l pat_main body (pattern_to_rawexpr(pat_main, [|pat, on_succ|]))
        
        match d.SkipSpecial SpecRec with
        | Ok _ ->
            if is_global then
                let name_pats_body d = name_pats_body (fun _ d -> d.FailWith ExpectedFunction) d
                (name_pats_body .>>. (many (if_ (and' >>. name_pats_body))) >>= handle_inl_rec_block) d
            else
                d.Skip'(-1); d.FailWith RecNotAllowedLocally
        | Error _ ->
            let name_pats_body d = name_pats_body (fun x _ -> Ok x) d
            if is_global then (name_pats_body |>> handle_inl_statement) d
            else ((attempt pat_body) <|> (name_pats_body |>> handle_inl_statement)) d

    match d.PeekSpecial with
    | Ok x ->
        match x with
        | SpecLet -> d.Skip; inl join_point_entry_method (forall <|> (tilde >>. pattern true false expr |>> pattern_to_rawinl) <|> (pattern true true expr |>> pattern_to_rawinl))
        | SpecInl -> d.Skip; inl id (forall <|> (tilde >>. pattern true true expr |>> pattern_to_rawinl) <|> (pattern true false expr |>> pattern_to_rawinl))
        | SpecInm -> if is_global then d.FailWith InmCannotBeGlobal else d.Skip; pipe2 (pattern true false expr) (statement_body expr) handle_inm d
        | SpecInb -> if is_global then d.FailWith InbCannotBeGlobal else d.Skip; pipe2 (pattern true false expr) (statement_body expr) handle_inb d
        | SpecOpen -> d.Skip; pipe2 (open_ >>. big_var) (opt (curlies (with_ >>. many (let var = small_var <|> big_var <|> rounds op in ((var |>> OpenValue) <|> (grave >>. var |>> OpenType) ) .>>. opt (arr_fun >>. var))))) handle_open d
        | _ -> d.FailWith ExpectedStatement
    | Error _ -> d.FailWith ExpectedStatement

let operators expr d =
    let i = col d
    let inline term s = expr_indent i (<=) expr s

    // Similarly to F#, Spiral filters out the '.' from the operator name and then tries to match to the nearest inbuilt operator
    // for the sake of assigning associativity and precedence.
    // TODO: This might change in v0.2 to explicit precedence and associativity like in Agda/Haskell.
    let precedence_associativity (d : ParserEnv) x on_succ = 
        match inbuilt_operators.TryGetValue x with
        | true, v -> Ok(v,on_succ)
        | false, _ ->
            let name = String.filter ((<>) '.') x
            let rec loop l =
                if l > 0 then
                    let name = name.[0..l-1]
                    match inbuilt_operators.TryGetValue name with
                    | false, _ -> loop (l - 1)
                    | true, v -> Ok(v,on_succ)
                else
                    d.FailWith(InbuiltOpNotFound x)
            loop name.Length

    let op (d : ParserEnv) =
        let pos = pos' d
        match d.ReadOp with
        | Ok x ->
            match x with
            | ";"  -> 
                if pos.line = d.semicolon_line then let r = d.FailWith(InvalidSemicolon) in d.Skip'(-1); r
                else precedence_associativity d x (fun a b -> l "" (unop ErrorNonUnit a) b)
            | ":" // Is handled in the annotation parser.
            | "|" // Will be parsed as a regular operator otherwise.
            | "->" -> d.Skip'(-1); Error [] // Can be mistakenly parsed in when patterns.
            | _ ->
                match x with
                | "&&" -> fun a b -> expr_pos pos (if' a b (lit' (LitBool false)))
                | "||" -> fun a b -> expr_pos pos (if' a (lit' (LitBool true)) b)
                | "," -> fun a b -> expr_pos pos (RawOp(PairCreate,[|a;b|]))
                | x -> fun a b -> expr_pos pos (ap (ap (v x) a) b)
                |> precedence_associativity d x
        | Error x -> Error x

    let inline op s = expr_indent i (<=) op s

    /// Pratt parser
    let rec led left ((prec,asoc),m) =
        match asoc with
        | Associativity.Left | Associativity.None -> tdop prec |>> m left
        | Associativity.Right -> tdop (prec-1) |>> m left
        | _ -> failwith "impossible"

    and tdop rbp =
        let rec loop left = 
            (op >>=? fun ((prec,_),_ as v) d ->
                if rbp < prec then (led left v >>= loop) d
                else Error []) <|>% left
        term >>= loop

    tdop Int32.MinValue d

let application expr (d: ParserEnv) =
    let i = col d
    let expr_up d = expr_indent i (<) expr d
    pipe2 expr (many expr_up) (List.fold ap) d

let application_tight expr d =
    let is_previus_near (d: ParserEnv) = 
        let a = d.Skip'(-1); let x = d.LineEnd, d.ColEnd in d.Skip; x
        let b = d.Line, d.Col
        if a = b then Ok () else Error []

    pipe2 expr (many (is_previus_near >>. expr)) (List.fold ap) d

let keyword_unary'' keyword = RawKeywordCreate(keyword,[||])

let private string_to_op_dict = Dictionary(HashIdentity.Structural)
let _ =
    Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    |> Array.iter (fun x -> string_to_op_dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op)
let string_to_op x = string_to_op_dict.TryGetValue x

let case_var = (big_var <|> small_var) |>> v
let case_rounds expr = rounds ((op |>> v) <|> (reset_level expr <|>% B))
let case_small_var_rounds expr = ((small_var |>> v) <|> case_rounds expr)

let rec expressions expr d =
    let case_fun =
        let pattern x = pattern true x expr |>> pattern_to_rawinl
        pipe2 (fun' >>. many1 (forall <|> (tilde >>. pattern true) <|> pattern false)) (expression_body expr) (List.foldBack (<|))

    let case_value = value_ |>> lit'
    let case_default_value = def_value_ |>> def_lit'
    let case_if_then_else d = 
        let i = col d
        let expr_indent expr d = expr_indent i (<=) expr d
        let inline f' str = str >>. expr
        let inline f str = expr_indent (f' str)
        pipe4 (f' if_) (f then_) (many (f elif_ .>>. f then_)) (opt (f else_))
            (fun cond tr elifs fl -> 
                let fl = List.foldBack (fun (cond,tr) fl -> if' cond tr fl) elifs (Option.defaultValue B fl)
                if' cond tr fl)
        <| d

    let case_pattern_match =
        let clause d = ((pattern false false expr) .>>. (expression_body' expr)) d

        let pat_function l = inl pat_main <| pattern_to_rawexpr(pat_main, List.toArray l)
        let pat_match x l' = l pat_main x <| pattern_to_rawexpr(pat_main, List.toArray l')

        let clauses d = 
            let i = col d
            let bar s = expr_indent i (<=) or_ s
            (optional bar >>. sepBy1 (expr_indent i (<=) clause) bar) d

        (function_ >>. clauses |>> pat_function) 
        <|> (pipe2 (match_ >>. expr .>> with_) clauses pat_match)


    let case_typecase =
        let clauses d = 
            let i = col d
            let bar s = expr_indent i (<=) or_ s
            (optional bar >>. sepBy1 (expr_indent i (<=) (type_annot .>>. expression_body' expr)) bar) d

        pipe2 (typecase >>. type_annot .>> with_) clauses (fun a b -> RawTypecase(a,List.toArray b))

    let case_record =
        let mp_binding (n,e) = RawRecordWithKeyword(n, e)
        let mp_binding_inject n e = RawRecordWithInjectVar(n, e)
        let mp_without n = RawRecordWithoutKeyword n
        let mp_without_inject n = RawRecordWithoutInjectVar n
        let mp_create l = RawRecordWith([||],List.toArray l)
        let mp_with init names l = RawRecordWith(List.toArray (init :: names), List.toArray l)

        let parse_binding_with s =
            let i = col s
            let line = s.Line
            let inline body s = (eq' >>. expr_indent i (<) (set_semicolon_level line expr)) s
            let a s =
                pipe2 var_op (opt body)
                    (fun a -> function
                        | None -> mp_binding (a, v a)
                        | Some b -> mp_binding (a, b)) s
            let b s = pipe2 (dollar >>. var_op) body mp_binding_inject s
            (a <|> b) s

        let parse_binding_without s = 
            let a s = var_op |>> mp_without <| s
            let b s = dollar >>. var_op |>> mp_without_inject <| s
            (a <|> b) s

        let record_create_with s = (parse_binding_with .>> optional semicolon') s
        let record_create_without s = (parse_binding_without .>> optional semicolon') s

        let record_with = 
            let withs' s = many1 record_create_with s
            let withouts' s = many1 record_create_without s 
            let withs s = (with_ >>. withs') s
            let withouts s = (without >>. withouts') s 
            attempt
                (tuple3
                    (case_small_var_rounds expr)
                    (many ((keyword_unary' |>> keyword_unary'') <|> (dollar' >>. case_small_var_rounds expr)))
                    ((with_ >>% withs') <|> (without >>% withouts')))
            >>= (fun (init,names,next) s ->
                pipe2 next (many (withs <|> withouts)) (fun a b -> mp_with init names (List.concat(a::b))) s
                )

        let record_create = many record_create_with |>> mp_create
                
        curlies (record_with <|> record_create)

    let case_join_point = join >>. expr |>> join_point_entry_method

    let case_keyword_unary = keyword_unary' |>> keyword_unary''
    let case_keyword_message s =
        if s.keyword_line <> line s then
            let i' = col s
            let pat s = 
                let i = col s
                let line = line s
                (expr_indent i' (<=) keyword .>>. opt (expr_indent i (<) (set_keyword_level line expr))) s
            (many1 pat |>> (concat_keyword (fun a -> function Some b -> b | None -> v a) >> fun (a,b) -> RawKeywordCreate(a, List.toArray b))) s
        else
            Error []

    [|
    case_value; case_default_value; case_var; case_join_point; case_keyword_unary; case_keyword_message
    case_typecase; case_pattern_match; case_typecase; case_rounds expr; case_record
    case_if_then_else; case_fun
    |] |> choice <| d

let inbuilt_op expr =
    (exclamationx4 >>. big_var) .>>. (rounds (sepBy1 (expr <|> (type' |>> RawType)) comma))
    >>= fun (a, b) d ->
        match string_to_op a with
        | true, op' -> Ok(RawOp(op',List.toArray b))
        | false, _ -> d.FailWith(InbuiltOpNotFound a)

let operators_unary expr =
    choice [|
        type' |>> RawType
        inbuilt_op expr
        pipe2 (opt unary_op) expr (fun op e -> match op with Some op -> ap (v op) e | None -> e)
        |]

let parser_expressions expr s = (expressions expr |> operators_unary |> application_tight |> application |> operators) s
let rec parser_inner s = (((statements false parser_inner |>> ParserStatement) <|> (exprpos (parser_expressions parser_inner) |>> ParserExpr)) |> indentations |> annotations) s
let parser_outer d =
    let i = col d
    (many (expr_indent i (=) (statements true parser_inner |>> ParserStatement)) .>>. preturn (Some RawB) >>= process_parser_exprs) d

let parser d = (parser_outer .>> eof) d

let show_parser_error = function
    | ExpectedSpecial x ->
        match x with
        | SpecIn -> "in"
        | SpecAnd -> "and"
        | SpecFun -> "fun"
        | SpecMatch -> "match"
        | SpecTypecase -> "typecase"
        | SpecFunction -> "function"
        | SpecBigType -> "Type"
        | SpecWith -> "with"
        | SpecWithout -> "without"
        | SpecAs -> "as"
        | SpecWhen -> "when"
        | SpecInl -> "inl"
        | SpecLet -> "let"
        | SpecForall -> "forall"
        | SpecInm -> "inm"
        | SpecInb -> "inb"
        | SpecRec -> "rec"
        | SpecIf -> "if"
        | SpecThen -> "then"
        | SpecElif -> "elif"
        | SpecElse -> "else"
        | SpecJoin -> "join"
        | SpecSmallType -> "type"
        | SpecNominal -> "nominal"
        | SpecReal -> "real"
        | SpecUnion -> "union"
        | SpecOpen -> "open"
        | SpecWildcard -> "_"
        | SpecBracketRoundOpen -> "("
        | SpecBracketCurlyOpen -> "{"
        | SpecBracketSquareOpen -> "["
        | SpecBracketRoundClose -> ")"
        | SpecBracketCurlyClose -> "}"
        | SpecBracketSquareClose -> "]"
    | ExpectedOperator' -> "operator"
    | ExpectedOperator x -> x
    | ExpectedUnaryOperator' -> "unary operator"
    | ExpectedUnaryOperator x -> x
    | ExpectedSmallVar -> "small var"
    | ExpectedBigVar -> "big var"
    | ExpectedModuleInOpen -> "The variable provided is not a module."
    | ExpectedLit -> "literal"
    | ExpectedKeyword -> "keyword"
    | ExpectedKeywordUnary -> "unary keyword"
    | ExpectedStatement -> "statement"
    | ExpectedKeywordPatternInObject -> "keyword pattern"
    | ExpectedEof -> "end of file"
    | ExpectedFunction -> "function"
    | ExpectedGlobalFunction -> "global function"
    | StatementLastInBlock -> "A block requires an expression in last position."
    | InvalidSemicolon -> "Invalid syntax."
    | InbuiltOpNotFound x -> sprintf "`%s` not found among the inbuilt ops." x
    | UnexpectedEof -> "Unexpected end of file."
    | TypeForallNotAllowed -> sprintf "forall not allowed in the top-down phase."
    | DepConstraintNotAllowed -> sprintf "~> not allowed in the top-down phase."
    | ConstraintNotAllowed -> sprintf "=> not allowed in the top-down phase."
    | InmCannotBeGlobal -> "inm statements cannot be global"
    | InbCannotBeGlobal -> "inb statements cannot be global"
    | RecNotAllowedLocally -> "Recursive functions and blocks must be global."
    
let is_expected = function
    | StatementLastInBlock | InvalidSemicolon | InbuiltOpNotFound _
    | UnexpectedEof | TypeForallNotAllowed | DepConstraintNotAllowed
    | ConstraintNotAllowed | InmCannotBeGlobal | InbCannotBeGlobal -> false
    | _ -> true

let show_parser_error_list x = 
    let expected, errors = List.partition (snd >> is_expected) x
    let expected = 
        List.map (snd >> show_parser_error) expected
        |> String.concat ", "
        |> function
            | "" as x -> x
            | x -> sprintf "Expected one of: %s\n" x
    let errors = 
        List.map (snd >> show_parser_error) errors
        |> String.concat "\n"
        |> function
            | "" as x -> x
            | x -> sprintf "Parser errors:\n%s\n" x
    expected + errors

let show_position m (strb: StringBuilder) {module_={name=name; code=code}; line=line; column=col} =
    let er_code = 
        Utils.memoize m (fun _ -> code.Split([|"\r\n";"\r";"\n"|],System.StringSplitOptions.None)) code
        |> fun x -> x.[int line - 1]

    strb
        .AppendLine(sprintf "Error trace on line: %i, column: %i in module %s." line col name)
        .AppendLine(er_code)
        .Append(' ', col - 1)
        .AppendLine "^"
    |> ignore
  
let parse (m: SpiralModule) =
    match FParsec.CharParsers.runParserOnString tokenize m "" m.code with
    | FParsec.CharParsers.ParserResult.Failure(x,_,_) -> Error x
    | FParsec.CharParsers.ParserResult.Success(l,_,_) ->
        let var_positions=Dictionary(HashIdentity.Reference)
        let d = 
            {
            l=l
            i=ref 0
            module_=m
            semicolon_line= -1
            keyword_line= -1
            is_top_down=false
            var_positions=var_positions
            }
        let fail (x: (SpiralToken * ParserErrors) list) = 
            let strb = StringBuilder()
            let dict = Dictionary(HashIdentity.Reference)
            List.groupBy fst x
            |> List.iter (fun (a,b) -> 
                show_position dict strb {module_=m; line=a.Pos.start_line; column=a.Pos.start_column}
                strb.Append(show_parser_error_list b) |> ignore
                )
            Error(strb.ToString())
        match parser d with
        | Ok x ->  Ok (var_positions, x)
        | Error [] -> 
            if d.Index = d.Length then 
                match Array.tryLast l with
                | Some x -> fail [x, UnexpectedEof]
                | None -> Error "Unknown parse error."
            else Error "Unknown parse error."
        | Error x -> fail x
