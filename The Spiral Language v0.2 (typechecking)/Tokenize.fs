module Spiral.Tokenize
open System
open System.Collections.Generic
open Utils
open ParserCombinators
open LineParsers
open System.Text

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
    | TokVar of string
    | TokSymbol of string
    | TokSymbolPaired of string
    | TokValue of Literal
    | TokDefaultValue of string
    | TokOperator of string
    | TokUnaryOperator of string
    | TokComment of string
    | TokSpecial of TokenSpecial

let is_small_var_char_starting c = Char.IsLower c || c = '_'
let is_var_char c = Char.IsLetterOrDigit c || c = '_' || c = '''
let is_big_var_char_starting c = Char.IsUpper c
let is_var_char_starting c = Char.IsLetter c || c = '_'
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
let is_prefix_separator_char c = 
    let inline f x = c = x
    f ' ' || f oob || is_parenth_open c

let var (s: Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; near_to=s.from}, x) |> Ok
    let body x _ = 
        skip ':' s (fun () -> TokSymbolPaired(x) |> ok)
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
                | x -> TokVar(x)
                |> ok
                )

    (many1Satisfy2L is_var_char_starting is_var_char "variable" >>= body .>> spaces) s

let number (s: Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; near_to=s.from}, x) |> Ok

    let inline parser (s: Tokenizer) = 
        let parse_num_lit = number .>>. (opt (skip_char '.' >>. number))
        if peek s = '-' && Char.IsDigit (peek' s 1) && is_prefix_separator_char (peek' s -1) then 
            inc s
            parse_num_lit s |> Result.map (function 
                | (a,Some b) -> sprintf "-%s.%s" a b
                | (a,None) -> "-"+a)
        else parse_num_lit s |> Result.map (function 
                | (a,Some b) -> sprintf "%s.%s" a b
                | (a,None) -> a)

    let inline safe_parse s f on_succ target_type (x : string) = 
        match f x with
        | true, x -> on_succ x |> TokValue |> ok
        | false, _ -> Error [{from=from; near_to=s.from}, Message (sprintf "The string %s cannot be safely parsed as %s." x target_type)]
    
    let followedBySuffix x (s: Tokenizer) =
        let guard f =
            let a = peek s
            if is_small_var_char_starting a || Char.IsDigit a then error_char s.from (Expected "separator")
            else f x
        let skip s c = skip c s (fun () -> true) (fun () -> false)
        if skip s 'i' then
            if skip s '8' then guard (safe_parse s SByte.TryParse LitInt8 "int8")
            elif skip s '1' && skip s '6' then guard (safe_parse s Int16.TryParse LitInt16 "int16")
            elif skip s '3' && skip s '2' then guard (safe_parse s Int32.TryParse LitInt32 "int32")
            elif skip s '6' && skip s '4' then guard (safe_parse s Int64.TryParse LitInt64 "int64")
            else error_char s.from (Expected "8,16,32 or 64")
        elif skip s 'u' then
            if skip s '8' then guard (safe_parse s Byte.TryParse LitUInt8 "uint8")
            elif skip s '1' && skip s '6' then guard (safe_parse s UInt16.TryParse LitUInt16 "uint16")
            elif skip s '3' && skip s '2' then guard (safe_parse s UInt32.TryParse LitUInt32 "uint32")
            elif skip s '6' && skip s '4' then guard (safe_parse s UInt64.TryParse LitUInt64 "uint64")
            else error_char s.from (Expected "8,16,32 or 64")
        elif skip s 'f' then
            if skip s '3' && skip s '2' then guard (safe_parse s Single.TryParse LitFloat32 "float32")
            elif skip s '6' && skip s '4' then guard (safe_parse s Double.TryParse LitFloat64 "float64")
            else error_char s.from (Expected "32 or 64")
        else TokDefaultValue x |> ok

    (parser >>= followedBySuffix .>> spaces) s

let symbol s =
    let from = s.from
    let f x = ({from=from; near_to=s.from}, TokSymbol x)

    let x = peek s
    let x' = peek' s 1
    if x = '.' then
        if x' = '(' then inc' 2 s; ((many1SatisfyL is_operator_char "operator") .>> skip_char ')' |>> f .>> spaces) s
        else inc s; ((many1Satisfy2L is_var_char_starting is_var_char "variable") |>> f .>> spaces) s
    else error_char from (Expected "symbol")

let comment (s : Tokenizer) =
    let from = s.from
    let x = peek s
    let x' = peek' s 1
    if x = '\\' && x' = '\\' then 
        inc' 2 s
        let com = s.text.[s.from..]
        s.from <- s.text.Length
        Ok ({from=from; near_to=s.from}, TokComment com)
    else
        error_char from (Expected "comment")

let operator (s : Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; near_to=s.from}, x) |> Ok
    let is_separator_prev = is_prefix_separator_char (peek' s -1)
    let f name (s: Tokenizer) = 
        if is_separator_prev && (let x = peek s in (x = ' ' || x = oob) = false) then TokUnaryOperator(name) |> ok
        else TokOperator(name) |> ok
    (many1SatisfyL is_operator_char "operator"  >>= f .>> spaces) s

let string_raw s =
    let from = s.from
    let f x = {from=from; near_to=s.from}, TokValue(LitString x)
    (skip_string "@\"" >>. chars_till_string "\"" |>> f .>> spaces) s

let char_quoted_body (s: Tokenizer) =
    let read on_succ =
        let x = peek s
        if x <> oob then inc s; on_succ x
        else error_char s.from (Expected "character or '")
    read (function
        | '\\' -> 
            read (Ok << function
                | 'n' -> '\n'
                | 'r' -> '\r'
                | 't' -> '\t'
                | x -> x
                )
        | x -> Ok x
        )

let char_quoted s = 
    let from = s.from
    let f _ x _ = {from=from; near_to=s.from}, TokValue(LitChar x)
    (pipe3 (skip_char '\'') char_quoted_body (skip_char '\'') f .>> spaces) s

let string_quoted_body (s: Tokenizer) =
    let read on_succ =
        let x = peek s
        if x <> oob then inc s; on_succ x
        else error_char s.from (Expected "character or \"")
    let rec loop (b : StringBuilder) =
        read (function
            | '\\' -> 
                read (function
                    | 'n' -> '\n'
                    | 'r' -> '\r'
                    | 't' -> '\t'
                    | x -> x
                    >> b.Append >> loop
                    )
            | '"' -> inc' -1 s; Ok (b.ToString())
            | x -> b.Append x |> loop
            )
    loop (StringBuilder())

let string_quoted s = 
    let from = s.from
    let f _ x _ = {from=from; near_to=s.from}, TokValue(LitString x)
    (pipe3 (skip_char '"') string_quoted_body (skip_char '"') f .>> spaces) s

let brackets s =
    let from = s.from
    let f spec = inc s; (spaces >>% ({from=from; near_to=s.from}, TokSpecial(spec))) s
    match peek s with
    | '(' -> f SpecBracketRoundOpen | '[' -> f SpecBracketSquareOpen | '{' -> f SpecBracketCurlyOpen
    | ')' -> f SpecBracketRoundClose | ']' -> f SpecBracketSquareClose | '}' -> f SpecBracketCurlyClose
    | _ -> error_char s.from (Expected "`(`,`[`,`{`,`}`,`]` or `)`")

let token s = choice [|var; symbol; number; string_raw; char_quoted; string_quoted; brackets; comment; operator|] s

let tokenize (text : string) =
    (many_array token >>= fun x s ->
        let c = peek s
        if c = oob then Ok x
        else error_char s.from (Message <| if c = '\t' then "Tabs are not allowed." else "Unknown error at this location during tokenization.")
        ) {from=0; text=text}