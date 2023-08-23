module Spiral.Tokenize
open System
open System.Text
open FSharpx.Collections
open VSCTypes
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
    | SpecJoinBackend
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

type SemanticTokenLegend =
    | variable = 0
    | symbol = 1
    | string = 2
    | number = 3
    | operator = 4
    | unary_operator = 5
    | comment = 6
    | keyword = 7
    | parenthesis = 8
    | type_variable = 9
    | escaped_char = 10
    | unescaped_char = 11
    | number_suffix = 12

type SpiralToken =
    | TokVar of string * SemanticTokenLegend
    | TokSymbol of string * SemanticTokenLegend
    | TokOperator of string * SemanticTokenLegend
    | TokUnaryOperator of string * SemanticTokenLegend
    | TokValue of Literal
    | TokValueSuffix
    | TokDefaultValue of string
    | TokComment of string
    | TokKeyword of TokenKeyword
    | TokParenthesis of Parenthesis * ParenthesisState
    | TokStringOpen | TokStringClose
    | TokText of string
    | TokEscapedChar of char
    | TokUnescapedChar of char
    | TokMacroOpen | TokMacroClose
    | TokMacroTermVar of string
    | TokMacroTypeVar of string
    | TokMacroTypeLitVar of string

let token_groups = function
    | TokUnaryOperator(_,r) | TokOperator(_,r) | TokVar(_,r) | TokSymbol(_,r) -> r
    | TokValue (LitChar _) | TokStringOpen | TokStringClose | TokText _ | TokMacroOpen | TokMacroClose | TokValue(LitString _) -> SemanticTokenLegend.string
    | TokComment _ -> SemanticTokenLegend.comment
    | TokKeyword _ -> SemanticTokenLegend.keyword
    | TokParenthesis _ -> SemanticTokenLegend.parenthesis
    | TokMacroTypeVar _ -> SemanticTokenLegend.type_variable
    | TokMacroTypeLitVar _ -> SemanticTokenLegend.type_variable
    | TokMacroTermVar _ -> SemanticTokenLegend.variable
    | TokEscapedChar _ -> SemanticTokenLegend.escaped_char
    | TokUnescapedChar _ -> SemanticTokenLegend.unescaped_char
    | TokValue _ | TokDefaultValue _ -> SemanticTokenLegend.number
    | TokValueSuffix -> SemanticTokenLegend.number_suffix

let show_lit = function
    | LitUInt8 x -> sprintf "%iu8" x
    | LitUInt16 x -> sprintf "%iu16" x
    | LitUInt32 x -> sprintf "%iu32" x
    | LitUInt64 x -> sprintf "%iu64" x
    | LitInt8 x -> sprintf "%ii8" x
    | LitInt16 x -> sprintf "%ii16" x
    | LitInt32 x -> sprintf "%ii32" x
    | LitInt64 x -> sprintf "%ii64" x
    | LitFloat32 x -> sprintf "%ff32" x
    | LitFloat64 x -> sprintf "%ff64" x
    | LitBool x -> sprintf "%b" x
    | LitString x -> sprintf "%s" x
    | LitChar x -> sprintf "%c" x

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
    let ok x = Ok ({from=from; nearTo=s.from}, x)
    let body x _ = 
        if skip ':' s then error_char from ": is not allowed directly after a var."
        else
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
            | "join" -> f SpecJoin | "join_backend" -> f SpecJoinBackend
            | "type" -> f SpecType | "nominal" -> f SpecNominal 
            | "real" -> f SpecReal | "union" -> f SpecUnion
            | "open" -> f SpecOpen | "_" -> f SpecWildcard
            | "prototype" -> f SpecPrototype | "instance" -> f SpecInstance
            | "true" -> TokValue(LitBool true) | "false" -> TokValue(LitBool false)
            | x -> TokVar(x,SemanticTokenLegend.variable)
            |> ok

    (many1Satisfy2L is_var_char_starting is_var_char "variable" >>= body .>> spaces) s

let number (s: Tokenizer) = 
    let from = s.from

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
        let from' = s.from
        let inline safe_parse string_to_val val_to_lit val_dsc =
            if (let x = peek s in is_separator_char x || is_operator_char x) then
                match string_to_val x with
                | true, x -> Ok [{from=from; nearTo=from'}, TokValue(val_to_lit x); {from=from'; nearTo=s.from}, TokValueSuffix]
                | false, _ -> Error [{from=from; nearTo=s.from}, (sprintf "The string %s cannot be safely parsed as %s." x val_dsc)]
            else error_char s.from "separator"
        let skip c = skip c s
        if skip 'i' then
            if skip '8' then safe_parse SByte.TryParse LitInt8 "i8"
            elif skip '1' && skip '6' then safe_parse Int16.TryParse LitInt16 "i16"
            elif skip '3' && skip '2' then safe_parse Int32.TryParse LitInt32 "i32"
            elif skip '6' && skip '4' then safe_parse Int64.TryParse LitInt64 "i64"
            else error_char s.from "8,16,32 or 64"
        elif skip 'u' then
            if skip '8' then safe_parse Byte.TryParse LitUInt8 "uint8"
            elif skip '1' && skip '6' then safe_parse UInt16.TryParse LitUInt16 "u16"
            elif skip '3' && skip '2' then safe_parse UInt32.TryParse LitUInt32 "u32"
            elif skip '6' && skip '4' then safe_parse UInt64.TryParse LitUInt64 "u64"
            else error_char s.from "8,16,32 or 64"
        elif skip 'f' then
            if skip '3' && skip '2' then safe_parse Single.TryParse LitFloat32 "f32"
            elif skip '6' && skip '4' then safe_parse Double.TryParse LitFloat64 "f64"
            else error_char s.from "32 or 64"
        else Ok [{from=from; nearTo=s.from}, TokDefaultValue x]

    (parser >>= followedBySuffix .>> spaces) s

let symbol s =
    let from = s.from
    let f x = ({from=from; nearTo=s.from}, x)

    let symbol x = TokSymbol(x,SemanticTokenLegend.symbol)
    let x = peek s
    let x' = peek' s 1
    if x = '.' && x' = '(' then inc' 2 s; ((many1SatisfyL is_operator_char "operator") .>> skip_char ')' |>> (symbol >> f) .>> spaces) s
    elif x = '.' && is_var_char_starting x' then inc s; ((many1SatisfyL is_var_char "variable") |>> (symbol >> f) .>> spaces) s
    else error_char from "symbol"

let comment (s : Tokenizer) =
    if peek s = '/' && peek' s 1 = '/' then 
        let from = s.from
        inc' 2 s
        if skip ' ' s then
            let com = s.text.[s.from..]
            s.from <- s.text.Length
            Ok ({from=from; nearTo=s.from}, TokComment com)
        else error_char s.from "whitespace"
    else
        error_char s.from "comment"

let operator (s : Tokenizer) = 
    let from = s.from
    let ok x = ({from=from; nearTo=s.from}, x) |> Ok
    let is_separator_prev = is_prefix_separator_char (peek' s -1)
    let f name (s: Tokenizer) = 
        if is_separator_prev && (is_postfix_separator_char (peek s) = false) then TokUnaryOperator(name,SemanticTokenLegend.unary_operator) |> ok
        else TokOperator(name,SemanticTokenLegend.operator) |> ok
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
                    | 'n' -> '\n' | 'r' -> '\r' | 't' -> '\t' | 'b' -> '\b'
                    | x -> x
                    )
            | x -> Ok x
            )
    let from = s.from
    let f _ x _ = {from=from; nearTo=s.from}, TokValue(LitChar x)
    (pipe3 (skip_char '\'') char_quoted_body (skip_char '\'') f .>> spaces) s

let inline special_char l text s =
    let inline f from x = {from=from; nearTo=s.from}, x
    let f = f s.from
    inc s
    let esc x = inc s; text (f (TokEscapedChar x) :: l)
    let unesc x = inc s; text (f (TokUnescapedChar x) :: l)
    match peek s with 
    | x when x = eol -> error_char s.from "character"
    | 'n' -> esc '\n' | 'r' -> esc '\r'  | 't' -> esc '\t'  | 'b' -> esc '\b' 
    | x -> unesc x

let string_quoted' s =
    let inline f from x = {from=from; nearTo=s.from}, x
    let close l = let f = f s.from in inc s; List.rev (f TokStringClose :: l) |> Ok
    let rec text l =
        let f = f s.from
        let rec loop (str : StringBuilder) =
            let l () = if 0 < str.Length then f (TokText(str.ToString())) :: l else l
            match peek s with
            | x when x = eol -> error_char s.from "character or \""
            | '\\' -> special_char (l ()) text s
            | '"' -> close (l ())
            | x -> inc s; loop (str.Append(x))
        loop (StringBuilder())
        
    match peek s with
    | '"' -> let f = f s.from in inc s; text [f TokStringOpen]
    | _ -> error_char s.from "\""
let string_quoted s = (string_quoted' .>> spaces) s

type MacroEnum =
    | MTerm
    | MType
    | MTypeLit

let macro' s =
    let inline f from x = {from=from; nearTo=s.from}, x
    let close l = let f = f s.from in inc s; List.rev (f TokMacroClose :: l) |> Ok
    let rec text close_char l =
        let f = f s.from
        let rec loop (str : StringBuilder) =
            let l () = if 0 < str.Length then f (TokText(str.ToString())) :: l else l
            let var b = 
                let c = 
                    match b with
                    | MTerm -> '!'
                    | MType -> '`'
                    | MTypeLit -> '@'
                    
                if peek' s 1 = c then inc' 2 s; loop (str.Append(c))
                else var close_char b (l ())
            match peek s with
            | x when x = eol -> error_char s.from "character or \""
            | '`' -> var MType 
            | '!' -> var MTerm
            | '@' -> var MTypeLit
            | '\\' -> special_char (l ()) (text close_char) s
            | x when x = close_char -> close (l ())
            | x -> inc s; loop (str.Append(x))
        loop (StringBuilder())
    and var close_char is_type l =
        let f = f s.from
        let text x _ = text close_char (f (match is_type with MType -> TokMacroTypeVar x | MTerm -> TokMacroTermVar x | MTypeLit -> TokMacroTypeLitVar x) :: l)
        inc s; (many1Satisfy2L is_var_char_starting is_var_char "variable" >>= text) s
    match peek s, peek' s 1 with
    | '$', '"' -> let f = f s.from in inc' 2 s; text '"' [f TokMacroOpen]
    | '$', ''' -> let f = f s.from in inc' 2 s; text ''' [f TokMacroOpen]
    | _ -> error_char s.from "$\""
let macro s = (macro' .>> spaces) s

let brackets s =
    let from = s.from
    let f spec = inc s; (spaces >>% ({from=from; nearTo=s.from}, TokParenthesis(spec))) s
    match peek s with
    | '(' -> f (Round,Open) | '[' -> f (Square,Open) | '{' -> f (Curly,Open)
    | ')' -> f (Round,Close) | ']' -> f (Square,Close) | '}' -> f (Curly,Close)
    | _ -> error_char s.from "`(`,`[`,`{`,`}`,`]` or `)`"

let tab s = if peek s = '\t' then Error [range_char (index s), "Tabs are not allowed."] else Error []
let eol s = if peek s = eol then Ok [] else Error [range_char (index s), "end of line"]

let token s =
    let i = s.from
    let inline (+) a b = alt i a b
    (string_quoted + macro + number + ((var + symbol + string_raw + char_quoted + brackets + comment + operator) |>> fun x -> [x])) s

type LineToken = Range * SpiralToken
type LineComment = Range * string
type LineTokenErrors = (Range * TokenizerError) list
let tokenize text = 
    let mutable ar = PersistentVector.empty
    let er = match (spaces >>. many_iter (List.iter (fun x -> ar <- PersistentVector.conj x ar)) token .>> (eol <|> tab)) {from=0; text=text} with Ok() -> [] | Error er -> er
    ar, er

let vscode_tokens ((a,b) : VSCRange) (lines : LineToken PersistentVector PersistentVector) =
    let in_range x = min lines.Length x
    let from, near_to = in_range a.line, in_range (b.line+1)
    let toks = ResizeArray()
    let rec loop i line_delta =
        if i < near_to then
            lines.[i] |> PersistentVector.fold (fun (line_delta,from_prev) (r,x) ->
                toks.AddRange [|line_delta; r.from-from_prev; r.nearTo-r.from; int (token_groups x); 0|]
                0, r.from
                ) (line_delta, 0)
            |> fst |> ((+) 1) |> loop (i+1)
    
    loop from from
    toks.ToArray()