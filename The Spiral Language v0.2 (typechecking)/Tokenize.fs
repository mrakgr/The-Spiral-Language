module Spiral.Tokenize
open System
open System.Text
open Spiral.LineParsers
open Spiral.ParserCombinators

type TokenKeyword =
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
    | SpecType
    | SpecNominal
    | SpecReal
    | SpecUnion
    | SpecOpen
    | SpecWildcard
    | SpecPrototype
    | SpecInstance

type ParenthesisState = Open | Close
type Parenthesis = Round | Square | Curly

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
    | TokKeyword of TokenKeyword
    | TokParenthesis of Parenthesis * ParenthesisState

let token_groups = function
    | TokVar _ -> 0 // variable
    | TokSymbol _ | TokSymbolPaired _ -> 1 // symbol
    | TokValue(LitString _) -> 2 // string
    | TokValue _ | TokDefaultValue -> 3 // number
    | TokOperator _ -> 4 // operator
    | TokUnaryOperator _ -> 5 // unary operator
    | TokComment _ -> 6 // comment
    | TokKeyword _ -> 7 // keyword
    | TokParenthesis _ -> 8 // parenthesis

let is_small_var_char_starting c = Char.IsLower c || c = '_'
let is_var_char c = Char.IsLetterOrDigit c || c = '_' || c = '''
let is_big_var_char_starting c = Char.IsUpper c
let is_var_char_starting c = Char.IsLetter c || c = '_'
let is_parenth_open c = 
    let f x = c = x
    f '(' || f '[' || f '{'
let is_parenth_close c = 
    let f x = c = x
    f ')' || f ']' || f '}'

// http://www.asciitable.com/
let is_operator_char c =
    let f x = c = x
    '!' <= c && c <= '~' && (is_var_char c || f '"' || is_parenth_open c || is_parenth_close c) = false
let is_prefix_separator_char c = 
    let f x = c = x
    f ' ' || f eol || is_parenth_open c
let is_postfix_separator_char c = 
    let f x = c = x
    f ' ' || f eol || is_parenth_close c
let is_separator_char c = is_prefix_separator_char c || is_parenth_close c

let var (s: Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; nearTo=s.from}, x)
    let body x = 
        skip ':' s (fun () -> TokSymbolPaired(x) |> ok)
            (fun () ->
                let f x = TokKeyword(x)
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
                | "join" -> f SpecJoin | "type" -> f SpecType 
                | "nominal" -> f SpecNominal | "real" -> f SpecReal
                | "union" -> f SpecUnion
                | "open" -> f SpecOpen | "_" -> f SpecWildcard
                | "prototype" -> f SpecPrototype | "instance" -> f SpecInstance
                | "true" -> TokValue(LitBool true) | "false" -> TokValue(LitBool false)
                | x -> TokVar(x)
                |> ok
                )

    (many1Satisfy2L is_var_char_starting is_var_char "variable" |>> body .>> spaces) s

let number (s: Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; nearTo=s.from}, x) |> Ok

    let parser (s: Tokenizer) = 
        if peek s = '-' && Char.IsDigit (peek' s 1) && is_prefix_separator_char (peek' s -1) then 
            inc s
            number_fractional s |> Result.map (function 
                | (a,Some b) -> sprintf "-%s.%s" a b
                | (a,None) -> "-"+a)
        else number_fractional s |> Result.map (function 
                | (a,Some b) -> sprintf "%s.%s" a b
                | (a,None) -> a)
    
    let followedBySuffix x (s: Tokenizer) =
        let inline safe_parse string_to_val val_to_lit val_dsc =
            if is_separator_char (peek s) then 
                match string_to_val x with
                | true, x -> val_to_lit x |> TokValue |> ok
                | false, _ -> Error [{from=from; nearTo=s.from}, (sprintf "The string %s cannot be safely parsed as %s." x val_dsc)]
            else error_char s.from "separator"
        let skip c = skip c s (fun () -> true) (fun () -> false)
        if skip 'i' then
            if skip '8' then safe_parse SByte.TryParse LitInt8 "int8"
            elif skip '1' && skip '6' then safe_parse Int16.TryParse LitInt16 "int16"
            elif skip '3' && skip '2' then safe_parse Int32.TryParse LitInt32 "int32"
            elif skip '6' && skip '4' then safe_parse Int64.TryParse LitInt64 "int64"
            else error_char s.from "8,16,32 or 64"
        elif skip 'u' then
            if skip '8' then safe_parse Byte.TryParse LitUInt8 "uint8"
            elif skip '1' && skip '6' then safe_parse UInt16.TryParse LitUInt16 "uint16"
            elif skip '3' && skip '2' then safe_parse UInt32.TryParse LitUInt32 "uint32"
            elif skip '6' && skip '4' then safe_parse UInt64.TryParse LitUInt64 "uint64"
            else error_char s.from "8,16,32 or 64"
        elif skip 'f' then
            if skip '3' && skip '2' then safe_parse Single.TryParse LitFloat32 "float32"
            elif skip '6' && skip '4' then safe_parse Double.TryParse LitFloat64 "float64"
            else error_char s.from "32 or 64"
        else TokDefaultValue x |> ok

    (parser >>= followedBySuffix .>> spaces) s

let symbol s =
    let from = s.from
    let f x = ({from=from; nearTo=s.from}, x)

    let x = peek s
    let x' = peek' s 1
    if x = '.' then
        if x' = '(' then inc' 2 s; ((many1SatisfyL is_operator_char "operator") .>> skip_char ')' |>> (TokSymbol >> f) .>> spaces) s
        elif is_var_char_starting x' then inc s; ((many1SatisfyL is_var_char "variable") |>> (TokSymbol >> f) .>> spaces) s
        else inc s; Ok (f (TokOperator "."))
    else error_char from "symbol"

let comment (s : Tokenizer) =
    if peek s = '/' && peek' s 1 = '/' then 
        let from = s.from
        inc' 2 s
        skip ' ' s (fun () ->
            let com = s.text.[s.from..]
            s.from <- s.text.Length
            Ok ({from=from; nearTo=s.from}, TokComment com)
            ) (fun () -> error_char s.from "whitespace")
    else
        error_char s.from "comment"

let operator (s : Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; nearTo=s.from}, x) |> Ok
    let is_separator_prev = is_prefix_separator_char (peek' s -1)
    let f name (s: Tokenizer) = 
        if is_separator_prev && (is_postfix_separator_char (peek s) = false) then TokUnaryOperator(name) |> ok
        else TokOperator(name) |> ok
    (many1SatisfyL is_operator_char "operator"  >>= f .>> spaces) s

let string_raw s =
    let from = s.from
    let f x = {from=from; nearTo=s.from}, TokValue(LitString x)
    (skip_string "@\"" >>. chars_till_string "\"" |>> f .>> spaces) s

let char_quoted s = 
    let char_quoted_body (s: Tokenizer) =
        let inline read on_succ =
            let x = peek s
            if x <> eol then inc s; on_succ x
            else error_char s.from "character or '"
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
    let from = s.from
    let f _ x _ = {from=from; nearTo=s.from}, TokValue(LitChar x)
    (pipe3 (skip_char '\'') char_quoted_body (skip_char '\'') f .>> spaces) s

let string_quoted s = 
    let string_quoted_body (s: Tokenizer) =
        let inline read on_succ =
            let x = peek s
            if x <> eol then inc s; on_succ x
            else error_char s.from "character or \""
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
                | '"' -> Ok (b.ToString())
                | x -> b.Append x |> loop
                )
        loop (StringBuilder())
    let from = s.from
    let f _ x = {from=from; nearTo=s.from}, TokValue(LitString x)
    (pipe2 (skip_char '"') string_quoted_body f .>> spaces) s

let brackets s =
    let from = s.from
    let f spec = inc s; (spaces >>% ({from=from; nearTo=s.from}, TokParenthesis(spec))) s
    match peek s with
    | '(' -> f (Round,Open) | '[' -> f (Square,Open) | '{' -> f (Curly,Open)
    | ')' -> f (Round,Close) | ']' -> f (Square,Close) | '}' -> f (Curly,Close)
    | _ -> error_char s.from "`(`,`[`,`{`,`}`,`]` or `)`"

let token s =
    let i = s.from
    let inline (+) a b = alt i a b
    (var + symbol + number + string_raw + char_quoted + string_quoted + brackets + comment + operator) s

/// An array of {line: int; char: int; length: int; tokenType: int; tokenModifiers: int} in the order as written suitable for serialization.
type VSCTokenArray = int []
open Config
let process_error (k,v) = 
    let messages, expecteds = v |> Array.distinct |> Array.partition (fun x -> Char.IsUpper(x,0))
    let ex () = match expecteds with [|x|] -> sprintf "Expected: %s" x | x -> sprintf "Expected one of: %s" (String.concat ", " x)
    let f l = String.concat "\n" l
    if Array.isEmpty expecteds then f messages, k
    elif Array.isEmpty messages then ex (), k
    else f (Array.append [|ex (); ""; "Other error messages:"|] messages), k

type LineTokenErrors = (Range * TokenizerError) list
let process_errors line (ers : LineTokenErrors []) : (string * VSCRange) [] =
    ers |> Array.mapi (fun i l -> 
        let i = line + i
        l |> List.toArray |> Array.map (fun (r,x) -> x, ({line=i; character=r.from}, {line=i; character=r.nearTo}))
        )
    |> Array.concat
    |> Array.groupBy snd
    |> Array.map ((fun (k,v) -> k, Array.map fst v) >> process_error)

type LineToken = Range * SpiralToken
type LineComment = Range * string

type LineTokenResult = LineToken [] * LineTokenErrors
let tokenize text : LineTokenResult =
    let s = {from=0; text=text}
    LineParsers.spaces' s

    let ar = ResizeArray()
    let rec loop () =
        let i = index s
        match token s with
        | Ok _ when i = index s -> failwith "The parser succeeded without changing the parser index in `tokenize`. Had an exception not been raised the parser would have diverged."
        | Ok x -> ar.Add x; loop()
        | Error er -> er
    let ers =
        let ers = loop ()
        let c = peek s
        if c = eol then []
        elif c = '\t' then [range_char (index s), "Tabs are not allowed."]
        else ers
    ar.ToArray(), ers

type VSCodeTokenData = int [] * (string * VSCRange) [] // FSharp.Json does not support serializing ResizeArray objects
let vscode_tokens line_delta (lines : LineToken [] []) =
    let toks = ResizeArray()
    lines |> Array.fold (fun line_delta tok ->
        tok |> Array.fold (fun (line_delta,from_prev) (r,x) ->
            toks.AddRange [|line_delta; r.from-from_prev; r.nearTo-r.from; token_groups x; 0|]
            0, r.from
            ) (line_delta, 0)
        |> fst |> ((+) 1)
        ) line_delta
    |> ignore
    
    toks.ToArray()

type SpiEdit = {|from: int; nearTo: int; lines: string []|}

let replace (lines : _ [] ResizeArray) (errors : _ []) (edit : SpiEdit) =
    let toks, ers = Array.map tokenize edit.lines |> Array.unzip
    lines.RemoveRange(edit.from,edit.nearTo-edit.from)
    lines.InsertRange(edit.from,toks)

    let errors = errors |> Array.filter (fun (_,(a,_)) -> (edit.from <= a.line && a.line < edit.nearTo) = false)
    Array.append errors (process_errors edit.from ers)
