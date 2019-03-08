module Spiral.Parsing
open Spiral.Types
open Spiral.Tokenize
open Spiral.ParserCombinators
open Spiral.Show
open System
open System.Text


type Associativity = FParsec.Associativity

type ParserExpr =
| ParserStatement of (RawExpr -> RawExpr)
| ParserExpr of RawExpr

let inline expr_indent i op expr d = if op i (col d) then expr d else Fail []

let semicolon (d: ParserEnv) = if d.Line <> d.semicolon_line then semicolon' d else d.FailWith(InvalidSemicolon) 

let exprpos expr d =
    let pos = pos' d
    (expr |>> function RawInline _ | RawObjectCreate _ | RawRecFunction _ | RawFunction _ as x -> x | x -> expr_pos pos x) d
let patpos expr d = (expr |>> pat_pos (pos' d)) d
//let exprpos expr d = expr d
//let patpos expr d = expr d

let inline concat_keyword f x =
    let strb = StringBuilder()
    let pattern = 
        List.map (fun (str: string, pat) -> 
            strb.Append(str).Append(':') |> ignore
            f (str, pat)
            ) x
    strb.ToString(), pattern

let concat_keyword'' x = concat_keyword (function _, Some pat -> pat | str, None -> PatVar str) x
let concat_keyword' x = let a,b = concat_keyword (function _,Some b -> b | a,None -> v a) x in a, List.toArray b

let (^<|) a b = a b // High precedence, right associative <| operator

let rec pattern_template expr s =
    let inline recurse s = pattern_template expr s

    let pat_when pattern = pattern .>>. (opt (when_ >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
    let pat_as pattern = pattern .>>. (opt (as_ >>. pattern )) |>> function a, Some b -> PatAnd [a;b] | a, None -> a
    let pat_or pattern = sepBy1 pattern or_ |>> function [x] -> x | x -> PatOr x
    let pat_keyword pattern = many1 (keyword .>>. opt pattern) |>> (concat_keyword'' >> PatKeyword) <|> pattern
    let pat_tuple pattern = sepBy1 pattern comma |>> function [x] -> x | x -> PatTuple x
    let pat_cons pattern = sepBy1 pattern cons |>> function [x] -> x | x -> PatCons x
    let pat_and pattern = sepBy1 pattern and_ |>> function [x] -> x | x -> PatAnd x
    let pat_expr = (var |>> v) <|> rounds expr
    let pat_type pattern = pattern .>>. opt (colon >>. (pat_expr <|> (lit_ |>> lit))) |>> function a,Some b as x-> PatTypeEq(a,b) | a, None -> a
    let pat_closure pattern = sepBy1 pattern arr |>> List.reduceBack (fun a b -> PatTypeTermFunction(a,b))
    let pat_wildcard = wildcard >>% PatE
    let pat_var = var |>> PatVar
    let pat_active pattern = unary_one >>. pat_expr .>>. pattern |>> PatActive 
    let pat_unbox pattern = unary_three >>. ((var |>> PatVar) <|> rounds pattern) |>> PatUnbox
    let pat_lit = lit_ |>> PatLit
    let pat_record_item pattern =
        let inline templ var k = pipe2 var (opt (eq >>. pattern)) (fun a -> function Some b -> k(a,b) | None -> k(a,PatVar a))
        templ (var <|> op_as_var) PatRecordMembersKeyword <|> templ (unary_four >>. var) PatRecordMembersInjectVar
    let pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
    let pat_keyword_unary = keyword_unary |>> fun keyword -> PatKeyword(keyword,[])
    let pat_rounds pattern = rounds (pattern <|> (op_as_var |>> PatVar) <|>% PatTuple []) 
        
    pat_when ^<| pat_as ^<| pat_or ^<| pat_keyword ^<| pat_tuple ^<| pat_cons ^<| pat_and ^<| pat_type ^<| pat_closure
    ^<| choice [|pat_wildcard; pat_var; pat_active recurse; pat_unbox recurse; pat_lit; pat_record recurse; pat_keyword_unary; pat_rounds recurse|] <| s

let inline pattern expr s = patpos (pattern_template expr) s
    
let set_semicolon_level line p (d: ParserEnv) = p {d with semicolon_line = line}
let set_keyword_level line p (d: ParserEnv) = p {d with semicolon_line = line; keyword_line = line}
let reset_level expr d = expr {d with semicolon_line= -1; keyword_line= -1}

let inline statement_body expr = eq >>. reset_level expr
let inline expression_body expr = lambda >>. reset_level expr

let compile_pattern pat body =
    let inline f expr_pos = function
        | PatE -> RawFunction(expr_pos body,"")
        | PatVar name -> RawFunction(expr_pos body, name)
        | _ -> RawFunction(expr_pos <| RawPattern(pat_main, [|pat, body|]), pat_main)
    match pat with
    | PatPos x -> f (expr_pos x.Pos) x.Expression
    | x -> f id x
let compile_patterns pats body = List.foldBack compile_pattern pats body

let annotations expr d = 
    let i = col d
    let inline expr_indent expr d = expr_indent i (<=) expr d
    pipe2 (expr_indent expr) (opt (expr_indent colon >>. expr_indent expr))
        (fun a -> function
            | Some b -> binop TypeAnnot a b
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

let statements expr (d: ParserEnv) =
    let handle_inl_expression pats body = compile_patterns pats body |> ParserExpr
    
    let handle_inl_rec (name, pats, body) (d: ParserEnv) = 
        compile_patterns pats body
        |> function
            | RawFunction(body,arg) as x -> 
                fun on_succ -> l name (RawRecFunction(body,arg,name)) on_succ
                |> ParserStatement |> Ok
            | x -> d.FailWith(ExpectedRecursiveFunction)

    let handle_inl_statement pats body = 
        fun on_succ ->
            match pats with
            | x :: x' ->
                compile_pattern x on_succ
                |> function
                    | RawFunction(on_succ,arg) -> l arg (compile_patterns x' body) on_succ
                    | _ -> failwith "impossible"
            |_ -> failwith "impossible"
        |> ParserStatement
    let inline inb_templ l pat body =
        fun on_succ ->
            compile_pattern pat on_succ
            |> function
                | RawFunction(on_succ,arg) -> l arg body on_succ
                | _ -> failwith "impossible"
        |> ParserStatement
    let handle_inb pat body = inb_templ (fun arg body on_succ -> ap body (func arg on_succ)) pat body
    let handle_inm pat body = inb_templ (fun arg body on_succ -> ap (ap (v ">>=") body) (func arg on_succ)) pat body

    match d.PeekSpecial with
    | Ok x ->
        match x with
        | SpecInl ->
            d.Skip
            match d.SkipSpecial SpecRec with
            | Ok _ -> (tuple3 var_op (many (pattern expr)) (statement_body expr) >>= handle_inl_rec) d
            | Fail _ ->
                (many1 (pattern expr) >>= (fun pats -> 
                    (statement_body expr |>> handle_inl_statement pats) 
                    <|> (expression_body expr |>> handle_inl_expression pats)
                    )) d
        | SpecInm -> d.Skip; pipe2 (pattern expr) (statement_body expr) handle_inm d
        | SpecInb -> d.Skip; pipe2 (pattern expr) (statement_body expr) handle_inb d
        | _ -> d.FailWith ExpectedStatement
    | Fail _ -> d.FailWith ExpectedStatement
        
let inline tuple_template fin sep expr (d: ParserEnv) =
    let i = col d
    let inline expr_indent expr (d: ParserEnv) = expr_indent i (<=) expr d
    sepBy1 (expr_indent expr) (expr_indent sep)
    |>> function [x] -> x | x -> fin (List.toArray x)
    <| d

let type_union expr s = tuple_template (Types.op TypeUnion) type_union' expr s
let tuple expr s = tuple_template vv comma expr s

let operators expr d =
    let op d =
        let pos = pos' d
        match op d with
        | Ok x ->
            match x.name with
            | "&&" -> fun a b -> expr_pos pos (Types.if_ a b (lit (LitBool false)))
            | "||" -> fun a b -> expr_pos pos (Types.if_ a (lit (LitBool true)) b)
            | x -> fun a b -> expr_pos pos (ap (ap (v x) a) b)
            |> fun m -> x.precedence, x.associativity, m
            |> Ok
        | Fail x -> Fail x

    let i = col d
    let inline op s = expr_indent i (<=) op s
    let inline term s = expr_indent i (<=) expr s

    /// Pratt parser
    let rec led left (prec,asoc,m) =
        match asoc with
        | Associativity.Left | Associativity.None -> tdop prec |>> m left
        | Associativity.Right -> tdop (prec-1) |>> m left
        | _ -> failwith "impossible"

    and tdop rbp =
        let rec loop left = 
            op >>=? (fun (prec,_,_ as v) d ->
                if rbp < prec then (led left v >>= loop) d
                else Fail []) <|>% left
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
        if a = b then Ok () else Fail []

    pipe2 expr (many (is_previus_near >>. expr)) (List.fold ap) d

let rec expressions expr d =
    let case_object =
        let f (pat, body) (d: ParserEnv) = 
            let inline f expr_pos pat =
                let compile_pattern name pat body =
                    match compile_pattern pat body with
                    | RawFunction(x,_) -> Ok(name, expr_pos x)
                    | _ -> failwith "impossible"
                match pat with
                | PatVar name -> compile_pattern name (PatKeyword(name, [])) body
                | PatKeyword(name,_) -> compile_pattern name pat body
                | _ -> d.FailWith(ExpectedKeywordPatternInObject)
                    
            match pat with
            | PatPos pos -> f (expr_pos pos.Pos) pos.Expression
            | _ -> f id pat
        let receiver s =
            let i = col s
            let line = line s
            (pattern expr .>>. (eq >>. expr_indent i (<) (set_semicolon_level line expr)) >>= f) s
        squares (many (receiver .>> optional semicolon')) |>> (List.toArray >> Types.objc)
    let case_inl_pat_list_expr = pipe2 (inl >>. many1 (pattern expr)) (expression_body expr) compile_patterns

    let case_lit = lit_ |>> lit
    let case_if_then_else d = 
        let i = col d
        let expr_indent expr d = expr_indent i (<=) expr d
        let inline f' str = str >>. expr
        let inline f str = expr_indent (f' str)
        pipe4 (f' if_) (f then_) (many (f elif_ .>>. f then_)) (opt (f else_))
            (fun cond tr elifs fl -> 
                let fl = 
                    match fl with Some x -> x | None -> B
                    |> List.foldBack (fun (cond,tr) fl -> Types.if_ cond tr fl) elifs
                Types.if_ cond tr fl)
        <| d
    let case_var = var |>> v
    let case_rounds = rounds ((op_as_var |>> v) <|> (reset_level expr <|>% B))

    let case_typex match_type (d: ParserEnv) =
        let clause = 
            pipe2 (many1 (pattern expr) .>> lambda) expr <| fun pats body ->
                match pats with
                | x :: xs -> x, compile_patterns xs body
                | _ -> failwith "impossible"

        let pat_function l = func pat_main <| RawPattern(pat_main, List.toArray l)
        let pat_match x l' = l pat_main x (RawPattern(pat_main, List.toArray l'))

        let clauses d = 
            let i = col d
            let bar s = expr_indent i (<=) or_ s
            (optional bar >>. sepBy1 (expr_indent i (<=) clause) bar) d

        match match_type with
        | true -> // function
            (function_ >>. clauses |>> pat_function) d
        | false -> // match
            pipe2 (match_ >>. expr .>> with_) clauses pat_match d

    let case_typeinl d = case_typex true d
    let case_typecase d = case_typex false d

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
            let inline body s = (eq >>. expr_indent i (<) (set_semicolon_level line expr)) s
            let a s =
                pipe2 var_op (opt body)
                    (fun a -> function
                        | None -> mp_binding (a, v a)
                        | Some b -> mp_binding (a, b)) s
            let b s = pipe2 (inject >>. var_op) body mp_binding_inject s
            (a <|> b) s

        let parse_binding_without s = 
            let a s = var_op |>> mp_without <| s
            let b s = inject >>. var_op |>> mp_without_inject <| s
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
                    ((var |>> v) <|> rounds expr)
                    (many ((keyword_unary |>> Types.keyword_unary) <|> (dot >>. rounds expr)))
                    ((with_ >>% withs') <|> (without >>% withouts')))
            >>= (fun (init,names,next) s ->
                pipe2 next (many (withs <|> withouts)) (fun a b -> mp_with init names (List.concat(a::b))) s
                )

        let record_create = many record_create_with |>> mp_create
                
        curlies (record_with <|> record_create)

    let case_join_point = join >>. expr |>> join_point_entry_method
    let case_type = type_ >>. expr |>> unop TypeGet
    let case_type_catch = type_catch >>. expr |>> unop TypeCatch
    let case_cuda = cuda >>. expr |>> (func "blockDim" << func "gridDim")

    let inbuilt_op_core c = c >>. var
    let case_inbuilt_op =
        let rec loop = function
            | RawExprPos x -> loop x.Expression
            | RawOp(ListCreate, l) -> l 
            | x -> [|x|]
        let body c = inbuilt_op_core c .>>. rounds (expr <|>% B)
        body unary_one >>= fun (a, b) d ->
            match string_to_op a with
            | true, op' -> Ok(Types.op op' (loop b))
            | false, _ -> d.FailWith(InbuiltOpNotFound a)

    let case_keyword_unary = keyword_unary |>> Types.keyword_unary
    let case_keyword_message s =
        if s.keyword_line <> line s then
            let i' = col s
            let pat s = 
                let i = col s
                let line = line s
                (expr_indent i' (<=) keyword .>>. opt (expr_indent i (<) (set_keyword_level line expr))) s
            (many1 pat |>> (concat_keyword' >> RawKeywordCreate)) s
        else
            Fail []

    [|
    case_lit; case_var; case_join_point; case_type; case_keyword_unary; case_keyword_message
    case_typecase; case_typeinl; case_rounds; case_record; case_object
    case_if_then_else; case_inl_pat_list_expr
    case_inbuilt_op
    case_cuda; case_type_catch
    |] |> choice <| d

let parser d = 
    let rec raw_expr s =
        let expressions s = type_union ^<| tuple ^<| operators ^<| application ^<| application_tight ^<| expressions raw_expr <| s
        let statements s = statements raw_expr <| s
        annotations ^<| indentations (statements <|> (exprpos expressions |>> ParserExpr)) <| s

    (raw_expr .>> eof) d

open FParsec
   
let parse (m: SpiralModule) =
    match runParserOnString tokenize m "" m.code with
    | Failure(x,_,_) -> Fail x
    | Success(l,_,_) ->
        //printfn "%A" l
        let d = 
            {
            l=l
            i=ref 0
            module_=m
            semicolon_line= -1
            keyword_line= -1
            }
        let fail (x: (SpiralToken * ParserErrors) list) = 
            let strb = StringBuilder()
            List.groupBy fst x
            |> List.iter (fun (a,b) -> 
                show_position' strb (m, a.Start.line, a.Start.column)
                strb.Append(show_parser_error_list b) |> ignore
                )
            Fail(strb.ToString())
        match parser d with
        | Types.Ok x ->  Types.Ok x
        | Fail [] -> 
            if d.Index = d.Length then fail [Array.last l, UnexpectedEof]
            else Fail "Unknown parse error."
        | Fail x -> fail x
