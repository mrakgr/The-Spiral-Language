module Spiral.Tokenize
open System
open Spiral.Types
open FParsec
open System.Collections.Generic
open System.Runtime.CompilerServices

// Globals
// Note: The tokens should not be memoized along with the string since that would conflict with extending them with 
// implicit positional information using the `var_position_dict`.
let private inbuilt_operators = Dictionary(HashIdentity.Structural)
let var_position_dict = ConditionalWeakTable<string,PosKey>()

exception TokenizationError of string

type TokenSpecial =
    | SpecMatch
    | SpecFunction
    | SpecWith
    | SpecWithout
    | SpecAs
    | SpecWhen
    | SpecInl
    | SpecInm
    | SpecInb
    | SpecRec
    | SpecIf
    | SpecThen
    | SpecElif
    | SpecElse
    | SpecJoin
    | SpecType
    | SpecTypeCatch
    | SpecWildcard
    | SpecLambda
    | SpecOr
    | SpecAnd
    | SpecTypeUnion
    | SpecDot
    | SpecColon
    | SpecComma
    | SpecSemicolon
    | SpecUnaryOne // ! Used for the active pattern and inbuilt ops.
    | SpecUnaryTwo // @ Used for parser macros
    | SpecUnaryThree // # Used for the unboxing pattern.
    | SpecUnaryFour // $ Used for the injection in patterns and in RecordWith
    | SpecBracketRoundOpen
    | SpecBracketCurlyOpen
    | SpecBracketSquareOpen
    | SpecBracketRoundClose
    | SpecBracketCurlyClose
    | SpecBracketSquareClose
    | SpecCuda

type SpiralToken =
    | TokVar of TokenPosition * string
    | TokValue of TokenPosition * Value
    | TokKeyword of TokenPosition * string
    | TokKeywordUnary of TokenPosition * string
    | TokOperator of TokenPosition * TokenOperator
    | TokSpecial of TokenPosition * TokenSpecial

    member d.Pos =
        match d with
        | TokVar(x,_) | TokValue(x,_) | TokKeyword(x,_)
        | TokKeywordUnary(x,_) | TokOperator(x,_) | TokSpecial(x,_) -> x

    member d.Start = d.Pos.start
    member d.End = d.Pos.end_

let _ =
    let add_infix_operator assoc str prec = inbuilt_operators.Add(str, (prec, assoc))

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
        f "=>" 5; f ":>" 35; f ":?>" 35; f "**" 80
    ()
         
let pos (s: CharStream) = {column=int s.Column; line=int s.Line}
let tok start end_ = {start=start; end_=end_}

let rec spaces_template s = spaces >>. optional (followedByString "//" >>. skipRestOfLine true >>. spaces_template) <| s
let spaces s = spaces_template s

let is_identifier_starting_char c = isAsciiLetter c || c = '_'
let is_identifier_char c = is_identifier_starting_char c || c = ''' || isDigit c 
let is_operator_char c = 
    let inline f x = c = x
    f '%' || f '^' || f '&' || f '|' || f '*' || f '/' || f '+' || f '-' || f '<' 
    || f '>' || f '=' || f '.' || f ':' || f '?' || f '\\' || f '!' || f '@' || f '#' || f '$'
let is_separator_char c = 
    let inline f x = c = x
    f ' ' || f ',' || f ':' || f ';' || f '\t' || f '\n' || f '\r' || f '(' || f '{' || f '[' || f CharStream.EndOfStreamChar

let var (s:CharStream<_>) = 
    let start = pos s

    let f x (s: CharStream<SpiralModule>) =
        if s.Skip(':') then
            let end_ = pos s
            let _ = memoize' var_position_dict (fun _ -> s.UserState,start.line,start.column) x
            TokKeyword(tok start end_,x)
        else
            let end_ = pos s
            let pos = tok start end_
            match x with
            | "match" -> TokSpecial(pos,SpecMatch) | "function" -> TokSpecial(pos,SpecFunction)
            | "with" -> TokSpecial(pos,SpecWith) | "without" -> TokSpecial(pos,SpecWithout)
            | "as" -> TokSpecial(pos,SpecAs) | "when" -> TokSpecial(pos,SpecWhen)
            | "inl" -> TokSpecial(pos,SpecInl) | "inm" -> TokSpecial(pos,SpecInm)
            | "inb" -> TokSpecial(pos,SpecInb) | "rec" -> TokSpecial(pos,SpecRec)
            | "if" -> TokSpecial(pos,SpecIf) | "then" -> TokSpecial(pos,SpecThen)
            | "elif" -> TokSpecial(pos,SpecElif) | "else" -> TokSpecial(pos,SpecElse)
            | "join" -> TokSpecial(pos,SpecJoin) | "cuda" -> TokSpecial(pos,SpecCuda)
            | "type" -> TokSpecial(pos,SpecType) | "type_catch" -> TokSpecial(pos,SpecTypeCatch)
            | "true" -> TokValue(pos,LitBool true) | "false" -> TokValue(pos,LitBool false)
            | "_" -> TokSpecial(pos,SpecWildcard)
            | x -> 
                let _ = memoize' var_position_dict (fun _ -> s.UserState,start.line,start.column) x
                TokVar(pos,x)
        |> Reply

    (many1Satisfy2L is_identifier_starting_char is_identifier_char "identifier" >>= f .>> spaces) s

let default_number_format =  
    NumberLiteralOptions.AllowFraction
    ||| NumberLiteralOptions.AllowExponent
    ||| NumberLiteralOptions.AllowHexadecimal
    ||| NumberLiteralOptions.AllowBinary
            
let number_format_with_minus = default_number_format ||| NumberLiteralOptions.AllowMinusSign

let number (s: CharStream<_>) = 
    let inline parser (s: CharStream<_>) = 
        let parse_num_lit number_format s = numberLiteral number_format "number" s
        if s.Peek() = '-' && isDigit (s.Peek(1)) && is_separator_char (s.Peek(-1)) then parse_num_lit number_format_with_minus s
        else parse_num_lit default_number_format s

    let inline safe_parse f on_succ er_msg x = 
        match f x with
        | true, x -> Reply(on_succ x)
        | false, _ -> Reply(ReplyStatus.FatalError,messageError er_msg)

    let inline default_int x = safe_parse Int64.TryParse LitInt64 "default int parse failed" x
    let inline default_float x = safe_parse Double.TryParse LitFloat64 "default float parse failed" x

    let followedBySuffix x is_x_integer (s: CharStream<_>) =
        let guard f =
            let a = s.Peek()
            if is_identifier_starting_char a || isDigit a then Reply(Error, expected "non-identifier character or digit")
            else f x
        if s.Skip('i') then
            if s.Skip('8') then guard (safe_parse SByte.TryParse LitInt8 "int8 parse failed")
            elif s.Skip('1') && s.Skip('6') then guard (safe_parse Int16.TryParse LitInt16 "int16 parse failed")
            elif s.Skip('3') && s.Skip('2') then guard (safe_parse Int32.TryParse LitInt32 "int32 parse failed")
            elif s.Skip('6') && s.Skip('4') then guard (safe_parse Int64.TryParse LitInt64 "int64 parse failed")
            else Reply(Error, expected "8,16,32 or 64")
        elif s.Skip('u') then
            if s.Skip('8') then guard (safe_parse Byte.TryParse LitUInt8 "uint8 parse failed")
            elif s.Skip('1') && s.Skip('6') then guard (safe_parse UInt16.TryParse LitUInt16 "uint16 parse failed")
            elif s.Skip('3') && s.Skip('2') then guard (safe_parse UInt32.TryParse LitUInt32 "uint32 parse failed")
            elif s.Skip('6') && s.Skip('4') then guard (safe_parse UInt64.TryParse LitUInt64 "uint64 parse failed")
            else Reply(Error, expected "8,16,32 or 64")
        elif s.Skip('f') then
            if s.Skip('3') && s.Skip('2') then guard (safe_parse Single.TryParse LitFloat32 "float32 parse failed")
            elif s.Skip('6') && s.Skip('4') then guard (safe_parse Double.TryParse LitFloat64 "float64 parse failed")
            else Reply(Error, expected "32 or 64")
        elif is_x_integer then guard default_int
        else guard default_float

    let start = pos s
    let reply = parser s
    if reply.Status = Ok then
        let nl = reply.Result // the parsed NumberLiteral
        try 
            let f x = TokValue(tok start (pos s), x)
            ((followedBySuffix nl.String nl.IsInteger |>> f) .>> spaces) s
        with
        | :? System.OverflowException as e ->
            s.Skip(-nl.String.Length)
            Reply(FatalError, messageError e.Message)
    else // reconstruct error reply
        Reply(reply.Status, reply.Error)

let keyword_unary s =
    let start = pos s
    let f x s = Reply(TokKeywordUnary(tok start (pos s), x))

    let x = s.Peek2()
    if x.Char0 = '.' && is_identifier_starting_char x.Char1 then
        s.Skip()
        ((manySatisfy is_identifier_char <?> "unary message") >>= f .>> spaces) s
    else
        Reply(Error, expected "unary message")

// Similarly to F#, Spiral filters out the '.' from the operator name and then tries to match to the nearest inbuilt operator
// for the sake of assigning associativity and precedence.
let op x = 
    memoize inbuilt_operators (fun name' ->
        let name = String.filter ((<>) '.') name'
        let rec loop l =
            if l > 0 then
                let name = name.[0..l-1]
                match inbuilt_operators.TryGetValue name with
                | false, _ -> loop (l - 1)
                | true, v -> v
            else
                raise (TokenizationError(sprintf "The `%s` operator is not supported." name'))
        loop name.Length
        ) x

let operator s = 
    let start = pos s
    let f name (s: CharStream<SpiralModule>) = 
        let pos = tok start (pos s)
        match name with
        | "!" -> Reply(TokSpecial(pos,SpecUnaryOne))
        | "@" -> Reply(TokSpecial(pos,SpecUnaryTwo))
        | "#" -> Reply(TokSpecial(pos,SpecUnaryThree))
        | "$" -> Reply(TokSpecial(pos,SpecUnaryFour))
        | "\/" -> Reply(TokSpecial(pos,SpecTypeUnion))
        | "->" -> Reply(TokSpecial(pos,SpecLambda))
        | "|" -> Reply(TokSpecial(pos,SpecOr))
        | "&" -> Reply(TokSpecial(pos,SpecAnd))
        | "." -> Reply(TokSpecial(pos,SpecDot))
        | ":" -> Reply(TokSpecial(pos,SpecColon))
        | _ ->
            try 
                let prec,asoc = op name
                let _ = memoize' var_position_dict (fun _ -> s.UserState,start.line,start.column) name
                Reply(TokOperator(pos,{name=name; precedence=prec; associativity=asoc}))
            with :? TokenizationError as x -> Reply(Error, messageError x.Data0)
    (many1SatisfyL is_operator_char "operator"  >>= f .>> spaces) s

let inline string_raw_template str str' s =
    let start = pos s
    let f x = TokValue(tok start (pos s), LitString x)
    (skipString str >>. charsTillString str' true Int32.MaxValue |>> f .>> spaces) s

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
    let f x = TokValue(tok start (pos s), LitChar x)
    (between (skipChar '\'') (skipChar '"') (char_quoted_read (fun _ -> true) |>> f) .>> spaces) s
let string_quoted s = 
    let start = pos s
    let f x = TokValue(tok start (pos s), LitString x)
    (between (skipChar '"') (skipChar '"') (manyChars (char_quoted_read ((<>) '"')) |>> f) .>> spaces) s

let special s =
    let start = pos s
    let f spec = s.Skip(); (spaces >>% (TokSpecial(tok start (pos s), spec))) s
    match s.Peek() with
    | '(' -> f SpecBracketRoundOpen | '[' -> f SpecBracketSquareOpen | '{' -> f SpecBracketCurlyOpen
    | ')' -> f SpecBracketRoundClose | ']' -> f SpecBracketSquareClose | '}' -> f SpecBracketCurlyClose
    | ',' -> f SpecComma | ';' -> f SpecSemicolon
    | _ -> Reply(Error, expected "``(`,`[`,`{`,`}`,`]`,`)`,`,`,`;`")

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
                resultFromState = (fun ra -> ra.ToArray())
                ) s

let tokenize s = between spaces eof token_array s