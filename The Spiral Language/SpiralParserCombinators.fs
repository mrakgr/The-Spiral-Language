module Spiral.ParserCombinators

open Spiral.Tokenize
open Spiral.Types

type ParserErrors =
    | ExpectedSpecial of TokenSpecial
    | ExpectedOperator'
    | ExpectedOperator of string
    | ExpectedVar
    | ExpectedLit
    | ExpectedKeyword
    | ExpectedKeywordUnary
    | ExpectedStatement
    | ExpectedKeywordPatternInObject
    | ExpectedEof
    | ExpectedRecursiveFunction
    | StatementLastInBlock
    | InvalidSemicolon
    | InbuiltOpNotFound of string
    | UnexpectedEof

type ParserEnv =
    {
    l: SpiralToken []
    i: int ref
    module_: SpiralModule
    semicolon_line: int
    keyword_line: int
    }

    member d.Index = d.i.contents
    member d.IndexSet i = d.i := i
    member d.Length = d.l.Length

    member inline d.TryCurrentTemplate on_succ on_fail =
        let i = d.Index
        if 0 <= i && i < d.Length then on_succ d.l.[i]
        else on_fail()

    member inline d.TryCurrent f = d.TryCurrentTemplate f (fun () -> Fail [])
    member d.FailWith er = d.TryCurrent (fun x -> Fail [x,er])

    member inline d.LineTemplate f = d.TryCurrentTemplate f (fun _ -> -1)

    member d.Module = d.module_
    member d.Line = d.LineTemplate (fun x -> x.Start.line)
    member d.Col = d.LineTemplate (fun x -> x.Start.column)
    member d.LineEnd = d.LineTemplate (fun x -> x.End.line)
    member d.ColEnd = d.LineTemplate (fun x -> x.End.column)
    
    member inline d.Skip'(i) = d.i := d.i.contents+i
    member d.Skip = d.Skip'(1)

    member d.PeekSpecial =
        d.TryCurrent <| function
            | TokSpecial(_,t') -> Ok t'
            | _ -> Fail []

    member d.SkipSpecial(t) =
        d.TryCurrent <| function
            | TokSpecial(_,t') when t = t' -> d.Skip; Ok()
            | _ -> d.FailWith(ExpectedSpecial t)

    member d.ReadOp =
        d.TryCurrent <| function
            | TokOperator(_,t') -> d.Skip; Ok t'
            | _ -> d.FailWith(ExpectedOperator')

    member d.ReadOpAsVar =
        d.TryCurrent <| function
            | TokOperator(_,t') -> d.Skip; Ok t'.name
            | _ -> d.FailWith(ExpectedOperator')

    member d.SkipOperator(t) =
        d.TryCurrent <| function
            | TokOperator(_,t') when t'.name = t -> d.Skip; Ok t'
            | _ -> d.FailWith(ExpectedOperator t)

    member d.ReadVar =
        d.TryCurrent <| function
            | TokVar(_,t') -> d.Skip; Ok t'
            | _ -> d.FailWith(ExpectedVar)

    member d.ReadLit =
        d.TryCurrent <| function
            | TokValue(_,t') -> d.Skip; Ok t'
            | _ -> d.FailWith(ExpectedLit)

    member d.ReadKeyword =
        d.TryCurrent <| function
            | TokKeyword(_,t') -> d.Skip; Ok t'
            | _ -> d.FailWith(ExpectedKeyword)

    member d.ReadKeywordUnary =
        d.TryCurrent <| function
            | TokKeywordUnary(_,t') -> d.Skip; Ok t'
            | _ -> d.FailWith(ExpectedKeywordUnary)

let inline preturn a d = Ok a
let inline pfail a (d: ParserEnv) = d.FailWith a

let inline (.>>.) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok (a,b)
        | Fail x -> Fail x
    | Fail x -> Fail x   

let tuple3 a b c d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> Ok (a, b, c)
            | Fail x -> Fail x
        | Fail x -> Fail x
    | Fail x -> Fail x  

let inline tuple4 a b c d' d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> Ok (a, b, c, d')
                | Fail x -> Fail x
            | Fail x -> Fail x
        | Fail x -> Fail x
    | Fail x -> Fail x  

let inline tuple5 a b c d' e d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> 
                    match e d with
                    | Ok e -> Ok (a, b, c, d', e)
                    | Fail x -> Fail x
                | Fail x -> Fail x
            | Fail x -> Fail x
        | Fail x -> Fail x
    | Fail x -> Fail x  

let inline pipe2 a b f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok (f a b)
        | Fail x -> Fail x
    | Fail x -> Fail x  

let inline pipe3 a b c f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> Ok (f a b c)
            | Fail x -> Fail x
        | Fail x -> Fail x
    | Fail x -> Fail x  

let inline pipe4 a b c d' f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> Ok (f a b c d')
                | Fail x -> Fail x
            | Fail x -> Fail x
        | Fail x -> Fail x
    | Fail x -> Fail x  

let inline pipe5 a b c d' e f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> 
                    match e d with
                    | Ok e -> Ok (f a b c d' e)
                    | Fail x -> Fail x
                | Fail x -> Fail x
            | Fail x -> Fail x
        | Fail x -> Fail x
    | Fail x -> Fail x  

let inline (.>>) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok a
        | Fail x -> Fail x
    | Fail x -> Fail x   

let inline (>>.) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok b
        | Fail x -> Fail x
    | Fail x -> Fail x   

let inline opt a (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok a -> Ok(Some a)
    | Fail x -> 
        if s = d.Index then Ok(None)
        else Fail x

let inline optional a (d: ParserEnv) = 
    let s = d.Index
    match a d with
    | Ok a -> Ok()
    | Fail x -> 
        if s = d.Index then Ok()
        else Fail x

let inline (|>>) a b d =
    match a d with
    | Ok a -> Ok(b a)
    | Fail x -> Fail x

let inline (>>%) a b d =
    match a d with
    | Ok a -> Ok(b)
    | Fail x -> Fail x
        
let inline (>>=) a b d =
    match a d with
    | Ok a -> b a d
    | Fail x -> Fail x

let inline (>>=?) a b (d: ParserEnv) =
    let i = d.Index
    match a d with
    | Ok a -> 
        let i' = d.Index
        match b a d with
        | Ok x -> Ok x
        | x when i' = d.Index -> d.IndexSet i; x
        | x -> x
    | Fail x -> Fail x

let rec many a (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x ->
        if s = d.Index then failwith "The parser succeeded without changing the parser state in 'many'. Had an exception not been raised the parser would have diverged."
        else 
            match many a d with
            | Ok x' -> Ok (x :: x')
            | Fail x -> Fail x
    | Fail x -> Ok []

let inline sepBy1 a b (d: ParserEnv) =
    match a d with
    | Ok a' -> (many (b >>. a) |>> fun b -> a' :: b) d
    | Fail x -> Fail x

let inline many1 a (d: ParserEnv) =
    match a d with
    | Ok a' -> (many a |>> fun b -> a' :: b) d
    | Fail x -> Fail x

let inline attempt a (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x -> Ok x
    | Fail a as a' -> d.IndexSet s; a'

let inline (<|>) a b (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x -> Ok x
    | Fail a as a' -> 
        if s = d.Index then
            match b d with
            | Ok x -> Ok x
            | Fail b -> Fail(List.append a b)
        else
            a'

let inline (<|>%) a b (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x -> Ok x
    | Fail a as a' -> 
        if s = d.Index then Ok b
        else a'

let inline choice ar (d: ParserEnv) =
    let s = d.Index
    let rec loop i =
        if i < Array.length ar then
            match ar.[i] d with
            | Ok x -> Ok x
            | Fail a as a' -> 
                if s = d.Index then
                    match loop (i+1) with
                    | Ok x -> Ok x
                    | Fail b -> Fail(List.append a b)
                else
                    a'
        else
            Fail []
    loop 0

let inline special x (d: ParserEnv) = d.SkipSpecial x
let match_ d = special SpecMatch d
let function_ d = special SpecFunction d
let with_ d = special SpecWith d
let without d = special SpecWithout d
let as_ d = special SpecAs d
let when_ d = special SpecWhen d
let inl d = special SpecInl d
let inm d = special SpecInm d
let inb d = special SpecInb d
let rec_ d = special SpecRec d
let if_ d = special SpecIf d
let then_ d = special SpecThen d
let elif_ d = special SpecElif d
let else_ d = special SpecElse d
let join d = special SpecJoin d
let type_ d = special SpecType d
let type_catch d = special SpecTypeCatch d
let wildcard d = special SpecWildcard d
let lambda d = special SpecLambda d
let or_ d = special SpecOr d
let and_ d = special SpecAnd d
let type_union' d = special SpecTypeUnion d
let dot d = special SpecDot d
let colon d = special SpecColon d
let comma d = special SpecComma d
let semicolon' d = special SpecSemicolon d
let unary_one d = special SpecUnaryOne d // ! Used for the active pattern and inbuilt ops.
let unary_two d = special SpecUnaryTwo d // @ Used for parser macros
let unary_three d = special SpecUnaryThree d // # Used for the unboxing pattern.
let unary_four d = special SpecUnaryFour d // $ Used for the injection in patterns and in RecordWith
let inject = unary_four
let bracket_round_open d = special SpecBracketRoundOpen d
let bracket_curly_open d = special SpecBracketCurlyOpen d
let bracket_square_open d = special SpecBracketSquareOpen d
let bracket_round_close d = special SpecBracketRoundClose d
let bracket_curly_close d = special SpecBracketCurlyClose d
let bracket_square_close d = special SpecBracketSquareClose d
let cuda d = special SpecCuda d

let cons (d: ParserEnv) = d.SkipOperator "::"
let arr (d: ParserEnv) = d.SkipOperator "=>"
let eq (d: ParserEnv) = d.SkipOperator "="

let var (d: ParserEnv) = d.ReadVar
let op (d: ParserEnv) = d.ReadOp
let op_as_var (d: ParserEnv) = d.ReadOpAsVar
let lit_ (d: ParserEnv) = d.ReadLit
let keyword (d: ParserEnv) = d.ReadKeyword
let keyword_unary (d: ParserEnv) = d.ReadKeywordUnary

let rounds a (d: ParserEnv) = (bracket_round_open >>. a .>> bracket_round_close) d
let curlies a (d: ParserEnv) = (bracket_curly_open >>. a .>> bracket_curly_close) d
let squares a (d: ParserEnv) = (bracket_square_open >>. a .>> bracket_square_close) d

let var_op = var <|> rounds op_as_var

let col (d: ParserEnv) = d.Col
let line (d: ParserEnv) = d.Line
let module_ (d: ParserEnv) = d.Module
let pos' s = module_ s, line s, col s

let eof (d: ParserEnv) = if d.Index = d.Length then Ok() else d.FailWith(ExpectedEof)
