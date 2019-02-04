﻿module Spiral.Parsing
open System
open Types

// Parser open
open FParsec
open System.Text

let string_to_op =
    let cases = Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    let dict = d0()
    cases |> Array.iter (fun x ->
        dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op
        )
    dict.TryGetValue

let keyword_to_string_dict = d0()
let string_to_keyword_dict = d0()

let mutable tag_keyword = 0
let string_to_keyword (x: string) =
    match string_to_keyword_dict.TryGetValue x with
    | true, v -> v
    | false, _ ->
        tag_keyword <- tag_keyword + 1
        string_to_keyword_dict.[x] <- tag_keyword
        keyword_to_string_dict.[tag_keyword] <- x
        tag_keyword
let keyword_to_string x = keyword_to_string_dict.[x] // Should never fail.

// #Parsing
let spiral_parse (settings: CompilerSettings) module_ = 
    let col (s: CharStream<_>) = s.Column
    let line (s: CharStream<_>) = s.Line

    let pos' s = module_, line s, col s
    let exprpos expr (s: CharStream<_>) = (expr |>> expr_pos (pos' s)) s
    let patpos expr (s: CharStream<_>) = (expr |>> pat_pos (pos' s)) s

    let rec spaces_template s = spaces >>. optional (followedByString "//" >>. skipRestOfLine true >>. spaces_template) <| s
    let spaces s = spaces_template s
    
    let is_identifier_starting_char c = isAsciiLetter c || c = '_'
    let is_identifier_char c = is_identifier_starting_char c || c = ''' || isDigit c 
    let is_separator_char c = 
        let inline f x = c = x
        f ' ' || f ',' || f ';' || f '\t' || f '\n' || f '\"' || f '(' || f '{' || f '['
    let is_separator_char_ext c = 
        let inline f x = c = x
        is_separator_char c || f '=' || f ':'
    let is_closing_parenth_char c = 
        let inline f x = c = x
        f ')' || f '}' || f ']'
    let is_operator_char c = (is_identifier_char c || is_separator_char c || is_closing_parenth_char c) = false

    let var_name_core' s = 
        (many1Satisfy2L is_identifier_starting_char is_identifier_char "identifier" >>=? fun x s ->
            if s.Peek() = ':' then Reply(Error,expected "identifier") else Reply(x)
            ) s
    let var_name_core s = (var_name_core' .>> spaces) s
    let keyword_core' s = 
        // It is assumed that functions using keyword will append ':' to the end themselves.
        attempt (many1Satisfy2L is_identifier_starting_char is_identifier_char "keyword" .>> skipChar ':') s
    let keyword s = (keyword_core' .>> spaces) s

    let var_name =
        var_name_core >>=? function
            | "match" | "function" | "with" | "without" | "as" | "when" | "inl" | "inm" 
            | "inb" | "rec" | "if" | "then" | "elif" | "else" | "true" | "false" 
            | "open" | "join" | "join_type" | "type" | "type_catch" as x -> fun _ -> Reply(Error,messageError <| sprintf "%s not allowed as an identifier." x)
            | x -> preturn x

    let between_brackets l p r = between (skipChar l >>. spaces) (skipChar r >>. spaces) p
    let rounds p = between_brackets '(' p ')'
    let curlies p = between_brackets '{' p '}'
    let squares p = between_brackets '[' p ']'

    let poperator (s: CharStream<Userstate>) = many1Satisfy is_operator_char .>> spaces <| s
    let var_op_name = var_name <|> rounds (poperator <|> var_name_core)
        
    let keywordString_template str followedByChar (s: CharStream<_>) =
        let len = String.length str
        if s.Match str && followedByChar (s.Peek(len)) then s.Seek(int64 len); Reply(())
        else Reply(ReplyStatus.Error,expected str)
    let keywordString x = keywordString_template x (is_identifier_char >> not) >>. spaces
    let operatorString x = keywordString_template x (is_operator_char >> not) >>. spaces
    let prefixOperatorChar x = next2CharsSatisfy (fun a b -> a = x && is_operator_char b = false)
    let operatorChar x = prefixOperatorChar x >>. spaces

    let keyword_unary s = (prefixOperatorChar '.' >>.var_name_core' .>> spaces) s

    let when_ = keywordString "when"
    let as_ = keywordString "as"
    let prefix_negate = prefixOperatorChar '-'
    let comma = skipChar ',' >>. spaces
    let union = keywordString "\/"
    let pp = operatorChar ':'
    let pp' = skipChar ':' >>. spaces
    let semicolon' = operatorChar ';'
    let semicolon (s: CharStream<_>) = 
        if s.Line <> s.UserState.semicolon_line then semicolon' s
        else Reply(ReplyStatus.Error, messageError "cannot parse ; on this line") 
    let eq = operatorChar '=' 
    let eq' = skipChar '=' >>. spaces
    let bar = operatorChar '|' 
    let amphersand = operatorChar '&'
    let lam = operatorString "->"
    let arr = operatorString "=>"
    let set_ref = operatorString ":="
    let set_array = operatorString "<-"
    let inl = keywordString "inl"
    let inl_rec = keywordString "inl rec"
    let inm = keywordString "inm"
    let inb = keywordString "inb"
    let open_ = keywordString "open"
    let match_ = keywordString "match"
    let function_ = keywordString "function"
    let with_ = keywordString "with"
    let without = keywordString "without"
    let cons = operatorString "::"
    let inject = prefixOperatorChar '$'
    let wildcard = operatorChar '_'

    let pbool = ((keywordString "false" >>% LitBool false) <|> (keywordString "true" >>% LitBool true)) .>> spaces

    let unary_minus_check_precondition s = previousCharSatisfiesNot (is_separator_char_ext >> not) s
    let unary_minus_check s = (unary_minus_check_precondition >>. prefix_negate) s

    let pnumber : Parser<_,_> =
        let default_number_format =  
            NumberLiteralOptions.AllowFraction
            ||| NumberLiteralOptions.AllowExponent
            ||| NumberLiteralOptions.AllowHexadecimal
            ||| NumberLiteralOptions.AllowBinary
            
        let number_format_with_minus = default_number_format ||| NumberLiteralOptions.AllowMinusSign

        let parser (s: CharStream<_>) = 
            let parse_num_lit number_format s = numberLiteral number_format "number" s
            /// This is necessary in order to differentiate binary from unary operations.
            if s.Peek() = '-' && isDigit (s.Peek(1)) then (unary_minus_check_precondition >>. parse_num_lit number_format_with_minus) s
            else parse_num_lit default_number_format s

        let inline safe_parse f on_succ er_msg x = 
            match f x with
            | true, x -> Reply(on_succ x)
            | false, _ -> Reply(ReplyStatus.FatalError,messageError er_msg)

        let inline default_int x = safe_parse Int64.TryParse LitInt64 "default int parse failed" x
        let inline default_float x = safe_parse Double.TryParse LitFloat64 "default float parse failed" x

        let followedBySuffix x is_x_integer (s: CharStream<_>) =
            match s.Peek(0), s.Peek(1), s.Peek(2) with
            | 'i', '8', _ -> s.Seek(2L); safe_parse SByte.TryParse LitInt8 "int8 parse failed" x
            | 'u', '8', _ -> s.Seek(2L); safe_parse Byte.TryParse LitUInt8 "uint8 parse failed" x
            | 'i', '1', '6' -> s.Seek(3L); safe_parse Int16.TryParse LitInt16 "int16 parse failed" x
            | 'i', '3', '2' -> s.Seek(3L); safe_parse Int32.TryParse LitInt32 "int32 parse failed" x
            | 'i', '6', '4' -> s.Seek(3L); safe_parse Int64.TryParse LitInt64 "int64 parse failed" x
            | 'u', '1', '6' -> s.Seek(3L); safe_parse UInt16.TryParse LitUInt16 "uint16 parse failed" x
            | 'u', '3', '2' -> s.Seek(3L); safe_parse UInt32.TryParse LitUInt32 "uint32 parse failed" x
            | 'u', '6', '4' -> s.Seek(3L); safe_parse UInt64.TryParse LitUInt64 "uint64 parse failed" x
            | 'f', '3', '2' -> s.Seek(3L); safe_parse Single.TryParse LitFloat32 "float32 parse failed" x
            | 'f', '6', '4' -> s.Seek(3L); safe_parse Double.TryParse LitFloat64 "float64 parse failed" x
            | _ -> if is_x_integer then default_int x else default_float x

        fun s ->
            let reply = parser s
            if reply.Status = Ok then
                let nl = reply.Result // the parsed NumberLiteral
                try 
                    (followedBySuffix nl.String nl.IsInteger .>> spaces) s
                with
                | :? System.OverflowException as e ->
                    s.Skip(-nl.String.Length)
                    Reply(FatalError, messageError e.Message)
            else // reconstruct error reply
                Reply(reply.Status, reply.Error)

    let char_quoted_read check (s: CharStream<_>) =
        let x = s.Peek()
        if check x then
            s.Seek(1L)
            match x with
            | '\\' -> 
                match s.Read() with
                | 'n' -> '\n'
                | 'r' -> '\r'
                | 't' -> '\t'
                | x -> x
            | x -> x
            |> Reply
        else Reply(Error,null)

    let char_quoted = skipChar '\'' >>. char_quoted_read (fun _ -> true) .>> skipChar '\'' |>> LitChar
    let string_quoted = skipChar '\"' >>. manyChars (char_quoted_read ((<>) '\"')) .>> skipChar '\"' |>> LitString

    let inline string_raw_template str =
        skipString str >>. charsTillString str true Int32.MaxValue .>> spaces
        |>> LitString

    let string_raw = string_raw_template "@\""
    let string_raw_triple = string_raw_template "\"\"\""

    let lit_ s = 
        choice 
            [|
            pbool
            pnumber
            string_raw_triple
            string_raw
            string_quoted
            char_quoted
            |]
        <| s

    let concat_keyword x =
        let strb = StringBuilder()
        let pattern = 
            List.map (fun (str: string, pat) -> 
                strb.Append(str).Append(':') |> ignore
                pat
                ) x
        strb.ToString(), pattern

    let concat_keyword' x = let a,b = concat_keyword x in a, List.toArray b

    let (^<|) a b = a b // High precedence, right associative <| operator

    let rec pattern_template expr s = // The order in which the pattern parsers are chained determines their precedence.
        let inline recurse s = pattern_template expr s

        let pat_e = wildcard >>% PatE
        let pat_var = var_name |>> PatVar
        let pat_expr = (var_name |>> v) <|> rounds expr
        let pat_tuple pattern = sepBy1 pattern comma |>> function [x] -> x | x -> PatTuple x
        let pat_cons pattern = sepBy1 pattern cons |>> function [x] -> x | x -> PatCons x
        let pat_rounds pattern = rounds (pattern <|>% PatTuple [])
        let pat_type pattern = tuple2 pattern (opt (pp >>. pat_expr)) |>> function a,Some b as x-> PatTypeEq(a,b) | a, None -> a
        let pat_active pattern (s: CharStream<_>) =
            let inline f k = pipe2 pat_expr pattern (fun name pat -> k(name,pat)) s
            match s.Peek() with
            | '!' -> f PatActive
            | '@' -> f PatPartActive
            | _ -> Reply(ReplyStatus.Error, expected "! or @")
        let pat_or pattern = sepBy1 pattern bar |>> function [x] -> x | x -> PatOr x
        let pat_and pattern = sepBy1 pattern amphersand |>> function [x] -> x | x -> PatAnd x
    
        let pat_lit = lit_ |>> PatLit
        let pat_when pattern = pattern .>>. (opt (when_ >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
        let pat_as pattern = pattern .>>. (opt (as_ >>. pattern )) |>> function a, Some b -> PatAnd [a;b] | a, None -> a



        let pat_keyword_unary = keyword_unary |>> fun keyword -> PatKeyword(keyword,[])
        let pat_keyword pattern = 
            many1 (tuple2 keyword pattern) |>> (concat_keyword >> PatKeyword)
            <|> pattern

        let pat_record_item pattern =
            let inline templ var k = pipe2 var (opt (eq' >>. pattern)) (fun a -> function Some b -> k(a,b) | None -> k(a,PatVar a))
            templ var_op_name PatRecordMembersKeyword <|> templ (skipChar '$' >>. var_name) PatRecordMembersInjectVar
        
        let pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
        let pat_closure pattern = sepBy1 pattern arr |>> List.reduceBack (fun a b -> PatTypeTermFunction(a,b))

        pat_when ^<| pat_as ^<| pat_or ^<| pat_keyword ^<| pat_tuple ^<| pat_cons ^<| pat_and ^<| pat_type ^<| pat_closure
        ^<| choice [|pat_active recurse; pat_e; pat_var; pat_lit; pat_record recurse; pat_rounds recurse; pat_keyword_unary|] <| s

    let inline pattern expr s = patpos (pattern_template expr) s
    
    let set_semicolon_level_to_line line p (s: CharStream<_>) =
        let u = s.UserState
        s.UserState <- { u with semicolon_line=line }
        let r = p s
        s.UserState <- u
        r

    let reset_semicolon_level expr = attempt (set_semicolon_level_to_line -1L expr)

    let inline statement_expr expr = eq' >>. expr

    let pat_main = " pat_main"
    let compile_pattern pat body =
        match pat with
        | PatE -> RawFunction(body,"")
        | PatVar name -> RawFunction(body, name)
        | _ -> RawFunction(RawPattern(pat_main, [|pat, body|]), pat_main)
    let compile_patterns pats body = List.foldBack compile_pattern pats body

    let statements expr =
        let inline inb_templ inb k =
            inb >>. pipe2 (pattern expr) (statement_expr expr) (fun pat body ->
                compile_pattern pat body
                |> function
                    | RawFunction(body,arg) -> k arg body
                    | _ -> failwith "impossible"
                )

        let inb = inb_templ inb (fun arg body on_succ -> ap body (func arg on_succ))
        let inm = inb_templ inm (fun arg body on_succ -> ap (ap (v ">>=") body) (func arg on_succ))

        let inl = 
            inl >>. pipe2 (many1 (pattern expr)) (statement_expr expr) (fun pats body ->
                compile_patterns pats body
                |> function
                    | RawFunction(body,arg) -> l arg body
                    | _ -> failwith "impossible"
                )

        let inl_rec = 
            inl_rec >>. tuple3 var_name (many (pattern expr)) (statement_expr expr) >>= fun (name, pats, body) _ -> 
                compile_patterns pats body
                |> function
                    | RawFunction(body,arg) -> Reply(l name (RawRecFunction(body,arg,name)))
                    | _ -> Reply(ReplyStatus.Error, expected "function after rec")

        let open_ = open_ >>. var_name .>>. many keyword_unary |>> fun (x, x') on_succ -> RawOpen(x,List.toArray x',on_succ)
        choice [|inl_rec; inm; inb; attempt inl; open_|]

    let inline expr_indent i op expr (s: CharStream<_>) = if op i (col s) then expr s else pzero s
    let if_then_else expr (s: CharStream<_>) =
        let i = (col s)
        let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
        let inline f' str = keywordString str >>. expr
        let inline f str = expr_indent (f' str)
        pipe4 (f' "if") (f "then") (many (f "elif" .>>. f "then")) (opt (f "else"))
            (fun cond tr elifs fl -> 
                let fl = 
                    match fl with Some x -> x | None -> B
                    |> List.foldBack (fun (cond,tr) fl -> if_ cond tr fl) elifs
                if_ cond tr fl)
        <| s

    let inline expression_expr expr = lam >>. reset_semicolon_level expr
    let case_inl_pat_list_expr expr = pipe2 (inl >>. many1 (pattern expr)) (expression_expr expr) compile_patterns

    let case_lit expr = lit_ |>> lit
    let case_if_then_else expr = if_then_else expr
    let case_rounds expr s = (rounds (reset_semicolon_level expr <|>% B)) s
    let case_var expr = var_op_name |>> v

    let case_typex match_type expr (s: CharStream<_>) =
        let clause = 
            pipe2 (many1 (pattern expr) .>> lam) expr <| fun pats body ->
                match pats with
                | x :: xs -> x, compile_patterns xs body
                | _ -> failwith "impossible"

        let pat_function l = func pat_main <| RawPattern(pat_main, List.toArray l)
        let pat_match x l' = l pat_main x (RawPattern(pat_main, List.toArray l'))

        let clauses i = 
            let bar s = expr_indent i (<=) bar s
            optional bar >>. sepBy1 (expr_indent i (<=) clause) bar
        let get_col (s: CharStream<_>) = Reply(col s)

        match match_type with
        | true -> // function
            (function_ >>. get_col >>=? clauses |>> pat_function) s    
        | false -> // match
            pipe2 (match_ >>. expr .>> with_) (get_col >>=? clauses) pat_match s

    let case_typeinl expr (s: CharStream<_>) = case_typex true expr s
    let case_typecase expr (s: CharStream<_>) = case_typex false expr s

    let case_record expr s =
        let mp_binding (n,e) = RawRecordWithKeyword(n, e)
        let mp_binding_inject n e = RawRecordWithInjectVar(n, e)
        let mp_without n = RawRecordWithoutKeyword n
        let mp_without_inject n = RawRecordWithoutInjectVar n
        let mp_create l = RawRecordWith([||],List.toArray l)
        let mp_with init names l = RawRecordWith(List.toArray (init :: names), List.toArray l)

        let inline parse_binding_with s =
            let i = col s
            let line = s.Line
            let inline body s = (eq' >>. expr_indent i (<) (set_semicolon_level_to_line line expr)) s
            let a s =
                pipe2 var_op_name (opt body)
                    (fun a -> function
                        | None -> mp_binding (a, v a)
                        | Some b -> mp_binding (a, b)) s
            let b s = pipe2 (inject >>. var_op_name) body mp_binding_inject s
            (a <|> b) s

        let parse_binding_without s = 
            let a s = var_op_name |>> mp_without <| s
            let b s = inject >>. var_op_name |>> mp_without_inject <| s
            (a <|> b) s

        let record_create_with s = (parse_binding_with .>> optional semicolon') s
        let record_create_without s = (parse_binding_without .>> optional semicolon') s

        let record_with = 
            let withs s = (with_ >>. many1 record_create_with) s
            let withouts s = (without >>. many1 record_create_without) s 
            pipe3 ((var_name |>> v) <|> rounds expr)
                (many (skipChar '.' >>. ((var_name |>> Types.keyword_unary) <|> rounds expr)))
                (many1 (withs <|> withouts) |>> List.concat)
                mp_with

        let record_create = many record_create_with |>> mp_create
                
        curlies (attempt record_with <|> record_create) <| s

    let case_negate expr = unary_minus_check >>. expr |>> (ap (v "negate"))
    let case_join_point expr = keywordString "join" >>. expr |>> join_point_entry_method
    let case_join_point_type expr = keywordString "join_type" >>. expr |>> join_point_entry_type
    let case_type expr = keywordString "type" >>. expr |>> unop TypeGet
    let case_type_catch expr = keywordString "type_catch" >>. expr |>> unop TypeCatch
    let case_cuda expr = keywordString "cuda" >>. expr |>> (func "blockDim" << func "gridDim")

    let inbuilt_op_core c = skipChar c >>. var_name
    let case_inbuilt_op expr =
        let rec loop = function
            | RawExprPos x -> loop x.Expression
            | RawOp(ListCreate, l) -> l 
            | x -> [|x|]
        let body c = inbuilt_op_core c .>>. rounds (expr <|>% B)
        body '!' >>= fun (a, b) ->
            match string_to_op a with
            | true, op' -> op op' (loop b) |> preturn
            | false, _ -> failFatally <| sprintf "%s not found among the inbuilt Ops." a

    let case_parser_macro expr = 
        inbuilt_op_core '@' >>= fun a ->
            let f x = LitString x |> lit |> preturn
            match a with
            | "CubPath" -> f settings.cub_path
            | "CudaPath" -> f settings.cuda_path
            | "CudaNVCCOptions" -> f settings.cuda_nvcc_options
            | "VSPath" -> f settings.vs_path
            | "VSPathVcvars" -> f settings.vs_path_vcvars
            | "VcvarsArgs" -> f settings.vcvars_args
            | "VSPathCL" -> f settings.vs_path_cl
            | "VSPathInclude" -> f settings.vs_path_include
            | a -> failFatally <| sprintf "%s is not a valid parser macro." a

    let case_keyword_unary expr = keyword_unary |>> Types.keyword_unary

    let inline tuple_template fin sep expr (s: CharStream<_>) =
        let i = (col s)
        let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
        sepBy1 (expr_indent expr) (expr_indent sep)
        |>> function [x] -> x | x -> fin (List.toArray x)
        <| s

    let type_union expr s = tuple_template (op TypeUnion) union expr s
    let tuple expr s = tuple_template vv comma expr s

    let case_object expr =
        let keyword s = 
            let i = col s
            tuple2 keyword (expr_indent i (<) var_name) s
        let f pat body = 
            match pat with
            | PatKeyword(name, vars) as x ->
                let vars = 
                    List.map (function
                        | PatV x -> x, PatE
                        | x -> patvar, 
                        ) vars
            compile_pattern
        let receiver s =
            let i = col s
            let line = line s
            (pipe2 (pattern_template expr) (eq' >>. expr_indent i (<) (set_semicolon_level_to_line line expr)) f) s
        squares (many receiver) 
        |>> (List.toArray >> Types.objc)

    let rec expressions expr s = 
        [
        case_join_point; case_join_point_type; case_type; case_type_catch
        case_cuda; case_inbuilt_op; case_parser_macro
        case_inl_pat_list_expr; case_lit; case_if_then_else
        case_rounds; case_typecase; case_typeinl; case_record; case_object
        case_negate << expressions; case_keyword_unary
        case_var
        ] |> List.map (fun x -> x expr) |> choice <| s
 
    let process_parser_exprs exprs = 
        let error_statement_in_last_pos _ = Reply(Error,messageError "Statements not allowed in the last position of a block.")
        let rec process_parser_exprs on_succ = function
            | [ParserExpr a] -> on_succ a
            | [ParserStatement _] -> error_statement_in_last_pos
            | ParserStatement a :: xs -> process_parser_exprs (a >> on_succ) xs
            | ParserExpr a :: xs -> process_parser_exprs (l "" (unop ErrorNonUnit a) >> on_succ) xs
            | [] -> on_succ B
            
        process_parser_exprs preturn (List.concat exprs)

    let indentations statements expressions (s: CharStream<Userstate>) =
        let i = col s
        let inline if_ op tr s = expr_indent i op tr s

        let inline many_semis expr = many (if_ (<) semicolon >>. if_ (<) expr)
        let inline many_indents expr = many1 (if_ (=) (pipe2 expr (many_semis expr) (fun a b -> a :: b)))
        many_indents ((statements |>> ParserStatement) <|> (exprpos expressions |>> ParserExpr)) >>= process_parser_exprs <| s

    let immediate_keyword_unary expr =
        let is_immeditate_expr x = is_closing_parenth_char x || is_identifier_char x
        pipe2 expr (many (previousCharSatisfies is_immeditate_expr >>. keyword_unary |>> Types.keyword_unary)) (List.fold ap)

    let application expr (s: CharStream<_>) =
        let i = col s
        let expr_up (s: CharStream<_>) = expr_indent i (<) expr s
        pipe2 expr (many expr_up) (List.fold ap) s

    let mset recurse expr (s: CharStream<_>) = 
        let i = col s
        let line = s.Line
        let expr_indent expr (s: CharStream<_>) = expr_indent i (<) expr s
        let op =
            (set_ref >>% fun l r -> op MutableSet [|l;B;r|] |> preturn)
            <|> (set_array >>% fun l r -> 
                    let rec loop = function
                        | RawExprPos(p) -> loop p.Expression
                        | RawOp(Apply,[|a;b|]) -> op MutableSet [|a;b;r|] |> preturn
                        | _ -> fail "Expected two arguments on the left of <-."
                    loop l)

        (tuple2 expr (opt (expr_indent op .>>. expr_indent (set_semicolon_level_to_line line recurse)))
        >>= function 
            | a,Some(f,b) -> f a b
            | a,None -> preturn a) s

    let annotations expr (s: CharStream<_>) = 
        let i = (col s)
        let expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
        pipe2 (expr_indent expr) (opt (expr_indent pp' >>. expr_indent expr))
            (fun a -> function
                | Some b -> binop TypeAnnot a b
                | None -> a) s

    let inbuilt_operators =
        let dict_operator = d0()
        let add_infix_operator assoc str prec = dict_operator.Add(str, (prec, assoc))

        let left_assoc_ops = 
            let f = add_infix_operator Associativity.Left
            f "+" 60; f "-" 60; f "*" 70; f "/" 70; f "%" 70
            f "<|" 10; f "|>" 10; f "<<" 10; f ">>" 10

            let f str = add_infix_operator Associativity.None str 40
            f "<="; f "<"; f "="; f ">"; f ">="; f "<>"
            f "<<<"; f ">>>"; f "&&&"; f "|||"

        let right_associative_ops =
            let f str prec = add_infix_operator Associativity.Right str prec
            f "||" 20; f "&&" 30; f "::" 50; f "^^^" 45
            f "=>" 0; f ":>" 35; f ":?>" 35; f "**" 80
         
        dict_operator

    let operators expr (s: CharStream<_>) =
        let poperator (s: CharStream<Userstate>) =
            let dict_operator = s.UserState.ops
            let p = pos' s
            (poperator >>=? function
                | "->" | ":=" | "<-" -> fail "forbidden operator"
                | orig_op -> 
                    let rec calculate on_fail op' = 
                        match dict_operator.TryGetValue op' with
                        | true, (prec,asoc) -> preturn (prec,asoc,fun a b -> 
                            match orig_op with
                            | "&&" -> expr_pos p (if_ a b (lit (LitBool false)))
                            | "||" -> expr_pos p (if_ a (lit (LitBool true)) b)
                            | _ -> expr_pos p (ap (ap (v orig_op) a) b)
                            )
                        | false, _ -> on_fail ()

                    let on_fail () =
                        let x = orig_op.TrimStart [|'.'|]
                        let rec on_fail i () = 
                            if i >= 0 then calculate (on_fail (i-1)) x.[0..i] 
                            else fail "unknown operator"
                        calculate (on_fail (x.Length-1)) x

                    calculate on_fail orig_op) s

        let i = (col s)
        let inline expr_indent expr (s: CharStream<_>) = expr_indent i (<=) expr s
        let inline poperator s = expr_indent poperator s
        let inline term s = expr_indent expr s

        let rec led left (prec,asoc,m) =
            match asoc with
            | Associativity.Left | Associativity.None -> tdop prec |>> m left
            | Associativity.Right -> tdop (prec-1) |>> m left
            | _ -> failwith "impossible"

        and tdop rbp =
            let rec loop left = 
                attempt (poperator >>= fun (prec,asoc,m as v) ->
                    if rbp < prec then led left v >>= loop
                    else pzero) <|>% left
            term >>= loop

        tdop Int32.MinValue s

    let keyword_message expr =
        let pat s =
            let i = col s
            tuple2 keyword (expr_indent i (<) (reset_semicolon_level expr)) s
        squares (many pat) |>> (concat_keyword' >> RawKeywordCreate)

    let rec expr s =
        let expressions s = mset expr ^<| type_union ^<| keyword_message ^<| tuple ^<| operators ^<| application ^<| immediate_keyword_unary ^<| expressions expr <| s
        let statements s = statements expr <| s
        annotations ^<| indentations statements expressions <| s
    runParserOnString (spaces >>. expr .>> eof) {ops=inbuilt_operators; semicolon_line= -1L} module_.Name module_.Code