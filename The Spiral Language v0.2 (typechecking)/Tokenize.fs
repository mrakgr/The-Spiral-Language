module Spiral.Tokenize
open System
open System.Collections.Generic
open Utils
open ParserCombinators
open LineParsers

type Range2D = {line : int; range : Range}

type TokenSpecial =
    | SpecIn
    | SpecAnd
    | SpecFun
    | SpecMatch
    | SpecTypecase
    | SpecFunction
    | SpecWith
    | SpecWithout
    | SpecAs
    | SpecWhen
    | SpecInl
    | SpecForall
    | SpecLet
    | SpecInm
    | SpecInb
    | SpecRec
    | SpecIf
    | SpecThen
    | SpecElif
    | SpecElse
    | SpecJoin
    | SpecSmallType
    | SpecNominal
    | SpecReal
    | SpecUnion
    | SpecOpen
    | SpecWildcard
    | SpecBracketRoundOpen
    | SpecBracketCurlyOpen
    | SpecBracketSquareOpen
    | SpecBracketRoundClose
    | SpecBracketCurlyClose
    | SpecBracketSquareClose

type Literal = 
    | LitUInt8 of uint8
    | LitUInt16 of uint16
    | LitUInt32 of uint32
    | LitUInt64 of uint64
    | LitInt8 of int8
    | LitInt16 of int16
    | LitInt32 of int32
    | LitInt64 of int64
    | LitFloat32 of float32
    | LitFloat64 of float
    | LitBool of bool
    | LitString of string
    | LitChar of char

type SpiralToken =
    | TokSmallVar of string
    | TokBigVar of string
    | TokKeyword of string
    | TokKeywordUnary of string
    | TokValue of Literal
    | TokDefaultValue of string
    | TokOperator of string
    | TokUnaryOperator of string
    | TokComment of string
    | TokSpecial of TokenSpecial

let is_small_var_char_starting c = Char.IsLower c || c = '_'
let is_var_char c = Char.IsLetterOrDigit c || c = '_' || c = '''
let is_big_var_char_starting c = Char.IsUpper c
let is_var_starting c = Char.IsLetter c || c = '_'
let is_parenth_open c = 
    let inline f x = c = x
    f '(' || f '[' || f '{'
let is_parenth_close c = 
    let inline f x = c = x
    f ')' || f ']' || f '}'

// http://www.asciitable.com/
let is_operator_char c =
    let inline f x = c = x
    '!' <= c && c <= '~' && (is_var_char c || f '"' || is_parenth_open c || is_parenth_close c) = false
let is_separator_char c = 
    let inline f x = c = x
    f ' ' || is_parenth_open c

let var (s: Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; near_to=s.from}, x) |> Ok

    let small_var s =
        many1Satisfy2L is_small_var_char_starting is_var_char "small var"
        >>= (fun x _ ->
            skip ':' s (fun () -> TokKeyword(x) |> ok)
                (fun () ->
                    let f x = TokSpecial(x)
                    match x with
                    | "in" -> f SpecIn
                    | "and" -> f SpecAnd | "fun" -> f SpecFun
                    | "match" -> f SpecMatch | "typecase" -> f SpecTypecase
                    | "function" -> f SpecFunction
                    | "with" -> f SpecWith | "without" -> f SpecWithout
                    | "as" -> f SpecAs | "when" -> f SpecWhen
                    | "inl" -> f SpecInl | "forall" -> f SpecForall
                    | "let" -> f SpecLet | "inm" -> f SpecInm
                    | "inb" -> f SpecInb | "rec" -> f SpecRec
                    | "if" -> f SpecIf | "then" -> f SpecThen
                    | "elif" -> f SpecElif | "else" -> f SpecElse
                    | "join" -> f SpecJoin | "type" -> f SpecSmallType 
                    | "nominal" -> f SpecNominal | "real" -> f SpecReal
                    | "open" -> f SpecOpen | "_" -> f SpecWildcard
                    | "true" -> TokValue(LitBool true) | "false" -> TokValue(LitBool false)
                    | x -> TokSmallVar(x)
                    |> ok
                    )
            )
        .>> spaces
        <| s

    let big_var s =
        many1Satisfy2L is_big_var_char_starting is_var_char "big var"
        >>= (fun x s ->
            skip ':' s (fun () -> TokKeyword(x) |> ok)
                (fun () -> TokBigVar(x) |> ok)
            )
        .>> spaces
        <| s

    (small_var <|> big_var) s

let default_number_format =  
    NumberLiteralOptions.AllowFraction
    ||| NumberLiteralOptions.AllowExponent
    ||| NumberLiteralOptions.AllowHexadecimal
    ||| NumberLiteralOptions.AllowBinary
            
let number_format_with_minus = default_number_format ||| NumberLiteralOptions.AllowMinusSign

let number (s: CharStream<_>) = 
    let start = pos s

    let inline parser (s: CharStream<_>) = 
        let parse_num_lit number_format s = numberLiteral number_format "number" s
        if s.Peek() = '-' && isDigit (s.Peek(1)) && is_separator_char (s.Peek(-1)) then parse_num_lit number_format_with_minus s
        else parse_num_lit default_number_format s

    let inline safe_parse s f on_succ er_msg (x : string) = 
        match f x with
        | true, x -> Reply(TokValue(pos' start (pos s),on_succ x))
        | false, _ -> Reply(ReplyStatus.FatalError,messageError er_msg)

    let inline default_int x = Reply(TokDefaultValue(pos' start (pos s),x))
    let inline default_float x = Reply(TokDefaultValue(pos' start (pos s),x))

    let followedBySuffix x is_x_integer (s: CharStream<_>) =
        let guard f =
            let a = s.Peek()
            if is_small_var_char_starting a || isDigit a then Reply(Error, expected "non-identifier character or digit")
            else f x
        if s.Skip('i') then
            if s.Skip('8') then guard (safe_parse s SByte.TryParse LitInt8 "int8 parse failed")
            elif s.Skip('1') && s.Skip('6') then guard (safe_parse s Int16.TryParse LitInt16 "int16 parse failed")
            elif s.Skip('3') && s.Skip('2') then guard (safe_parse s Int32.TryParse LitInt32 "int32 parse failed")
            elif s.Skip('6') && s.Skip('4') then guard (safe_parse s Int64.TryParse LitInt64 "int64 parse failed")
            else Reply(Error, expected "8,16,32 or 64")
        elif s.Skip('u') then
            if s.Skip('8') then guard (safe_parse s Byte.TryParse LitUInt8 "uint8 parse failed")
            elif s.Skip('1') && s.Skip('6') then guard (safe_parse s UInt16.TryParse LitUInt16 "uint16 parse failed")
            elif s.Skip('3') && s.Skip('2') then guard (safe_parse s UInt32.TryParse LitUInt32 "uint32 parse failed")
            elif s.Skip('6') && s.Skip('4') then guard (safe_parse s UInt64.TryParse LitUInt64 "uint64 parse failed")
            else Reply(Error, expected "8,16,32 or 64")
        elif s.Skip('f') then
            if s.Skip('3') && s.Skip('2') then guard (safe_parse s Single.TryParse LitFloat32 "float32 parse failed")
            elif s.Skip('6') && s.Skip('4') then guard (safe_parse s Double.TryParse LitFloat64 "float64 parse failed")
            else Reply(Error, expected "32 or 64")
        elif is_x_integer then guard default_int
        else guard default_float

    let reply = parser s
    if reply.Status = Ok then
        let nl = reply.Result // the parsed NumberLiteral
        try 
            ((followedBySuffix nl.String nl.IsInteger) .>> spaces) s
        with
        | :? System.OverflowException as e ->
            s.Skip(-nl.String.Length)
            Reply(FatalError, messageError e.Message)
    else // reconstruct error reply
        Reply(reply.Status, reply.Error)

let keyword_unary s =
    let start = pos s
    let f x s = Reply(TokKeywordUnary(pos' start (pos s), x))
    let er _ = Reply(Error, expected "unary keyword")

    let x = s.Peek2()
    if x.Char0 = '.' then
        if is_var_starting x.Char1 then
            s.Skip()
            ((manySatisfy is_var_char <?> "unary keyword") >>= f .>> spaces) s
        elif x.Char1 = '(' then
            s.Skip(2)
            ((manySatisfy is_operator_char <?> "unary keyword") .>> skipChar ')' >>= f .>> spaces) s
        else er()
    else er()

let operator (s : CharStream<_>) = 
    let is_separator_prev = is_separator_char (s.Peek(-1))
    let start = pos s
    let f name (s: CharStream<_>) = 
        if is_separator_prev && (let x = s.Peek() in is_var_char x || isDigit x || is_parenth_open x) then Reply(TokUnaryOperator(pos' start (pos s),name))
        else Reply(TokOperator(pos' start (pos s),name))
    (many1SatisfyL is_operator_char "operator"  >>= f .>> spaces) s

let inline string_raw_template begin_ end_ s =
    let start = pos s
    let f x = TokValue(pos' start (pos s), LitString x)
    (skipString begin_ >>. charsTillString end_ true Int32.MaxValue |>> f .>> spaces) s

let string_raw s = string_raw_template "@\"" "\"" s
let string_raw_triple s = let x = "\"\"\"" in string_raw_template x x s

let inline char_quoted_read check (s: CharStream<_>) =
    let x = s.Peek()
    if check x then
        s.Skip()
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

let char_quoted s = 
    let start = pos s
    let f x = TokValue(pos' start (pos s), LitChar x)
    (between (skipChar '\'') (skipChar '"') (char_quoted_read (fun _ -> true) |>> f) .>> spaces) s
let string_quoted s = 
    let start = pos s
    let f x = TokValue(pos' start (pos s), LitString x)
    (between (skipChar '"') (skipChar '"') (manyChars (char_quoted_read ((<>) '"')) |>> f) .>> spaces) s

let special s =
    let start = pos s
    let f spec = s.Skip(); (spaces >>% (TokSpecial(pos' start (pos s), spec))) s
    match s.Peek() with
    | '(' -> f SpecBracketRoundOpen | '[' -> f SpecBracketSquareOpen | '{' -> f SpecBracketCurlyOpen
    | ')' -> f SpecBracketRoundClose | ']' -> f SpecBracketSquareClose | '}' -> f SpecBracketCurlyClose
    | _ -> Reply(Error, expected "`(`,`[`,`{`,`}`,`]` or `)`")

let token s =
    choice
        [|
        var; keyword_unary; number
        string_raw_triple; string_raw; char_quoted; string_quoted
        special; operator
        |]
        s

let token_array s =
    Inline.Many(
                elementParser = token,
                stateFromFirstElement = (fun x0 ->
                    let ra = ResizeArray<_>()
                    ra.Add(x0)
                    ra),
                foldState = (fun ra x -> ra.Add(x); ra),
                resultFromState = (fun ra -> ra.ToArray()),
                resultForEmptySequence = (fun () -> [||])
                ) s

let tokenize s = between spaces eof token_array s