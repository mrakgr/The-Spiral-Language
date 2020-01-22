module Spiral.Tokenize
open System
open FParsec
open System.Collections.Generic
open Utils

// Globals
type TokenPosition = {
    start_line : int
    start_column : int
    end_line : int
    end_column : int
    }

type TokenSpecial =
    | SpecIn
    | SpecAnd
    | SpecFun
    | SpecMatch
    | SpecTypecase
    | SpecFunction
    | SpecBigType
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

type Value = 
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
    | TokSmallVar of TokenPosition * string
    | TokBigVar of TokenPosition * string
    | TokKeyword of TokenPosition * string
    | TokKeywordUnary of TokenPosition * string
    | TokValue of TokenPosition * Value
    | TokDefaultValue of TokenPosition * string
    | TokOperator of TokenPosition * string
    | TokUnaryOperator of TokenPosition * string
    | TokSpecial of TokenPosition * TokenSpecial

    member d.Pos = 
        match d with 
        | TokSmallVar(x,_) | TokBigVar(x,_) | TokKeyword(x,_)
        | TokKeywordUnary(x,_) | TokValue(x,_) | TokDefaultValue(x,_)
        | TokOperator(x,_) | TokUnaryOperator(x,_) | TokSpecial(x,_) -> x

let pos (s: CharStream) = int s.Line, int s.Column
let pos' (start_line, start_column) (end_line, end_column) = {start_line=start_line; start_column=start_column; end_line=end_line; end_column=end_column}

let rec spaces_template s = spaces >>. optional (followedByString "//" >>. skipRestOfLine true >>. spaces_template) <| s
let spaces s = spaces_template s

let is_small_var_char_starting c = isAsciiLower c || c = '_'
let is_var_char c = isAsciiLetter c || c = '_' || c = ''' || isDigit c 
let is_big_var_char_starting c = isAsciiUpper c
let is_big_var_char c = is_var_char c || c = '\\'
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
    f ' ' || f '\t' || f '\n' || f '\r' || is_parenth_open c || f CharStream.EndOfStreamChar

let var (s:CharStream<_>) = 
    let start = pos s

    let small_var s =
        many1Satisfy2L is_small_var_char_starting is_var_char "small var"
        >>= (fun x s ->
            if s.Skip(':') then
                TokKeyword(pos' start (pos s),x)
            else
                let f x = TokSpecial(pos' start (pos s),x)
                match x with
                | "in" -> f SpecIn
                | "and" -> f SpecAnd | "fun" -> f SpecFun
                | "match" -> f SpecMatch | "typecase" -> f SpecTypecase
                | "function" -> f SpecFunction | "Type" -> f SpecBigType
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
                | "true" -> TokValue(pos' start (pos s),LitBool true) | "false" -> TokValue(pos' start (pos s),LitBool false)
                | x -> TokSmallVar(pos' start (pos s),x)
            |> Reply)
        .>> spaces
        <| s

    let big_var s =
        many1Satisfy2L is_big_var_char_starting is_big_var_char "big var"
        >>= (fun x s ->
            if s.Skip(':') then TokKeyword(pos' start (pos s),x)
            else TokBigVar(pos' start (pos s),x)
            |> Reply)
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

    let x = s.Peek2()
    if x.Char0 = '.' && is_small_var_char_starting x.Char1 then
        s.Skip()
        ((manySatisfy is_var_char <?> "unary message") >>= f .>> spaces) s
    else
        Reply(Error, expected "unary message")

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