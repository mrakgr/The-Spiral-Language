module Spiral.ParserCombinators

open Spiral.Tokenize

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

type SpiralModule =
    {
    name: string
    prerequisites : SpiralModule list 
    description : string 
    code : string
    }

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

    member inline d.TryCurrent f = d.TryCurrentTemplate f (fun () -> Error [])
    member d.FailWith er = d.TryCurrent (fun x -> Error [x,er])

    member inline d.LineTemplate f = d.TryCurrentTemplate f (fun _ -> -1)

    member d.Module = d.module_
    member d.Line = d.LineTemplate (fun x -> x.Pos.start_line)
    member d.Col = d.LineTemplate (fun x -> x.Pos.start_column)
    member d.LineEnd = d.LineTemplate (fun x -> x.Pos.end_line)
    member d.ColEnd = d.LineTemplate (fun x -> x.Pos.end_column)
    
    member inline d.Skip'(i) = d.i := d.i.contents+i
    member d.Skip = d.Skip'(1)

    member d.PeekSpecial =
        d.TryCurrent <| function
            | TokSpecial(_,t') -> Ok t'
            | _ -> Error []

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
            | TokOperator(_,t') -> d.Skip; Ok t'
            | _ -> d.FailWith(ExpectedOperator')

    member d.SkipOperator(t) =
        d.TryCurrent <| function
            | TokOperator(_,t') when t' = t -> d.Skip; Ok t'
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
        | Error x -> Error x
    | Error x -> Error x   

let tuple3 a b c d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> Ok (a, b, c)
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline tuple4 a b c d' d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> Ok (a, b, c, d')
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

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
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline pipe2 a b f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok (f a b)
        | Error x -> Error x
    | Error x -> Error x  

let inline pipe3 a b c f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> Ok (f a b c)
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline pipe4 a b c d' f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> Ok (f a b c d')
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

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
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline (.>>) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok a
        | Error x -> Error x
    | Error x -> Error x   

let inline (>>.) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok b
        | Error x -> Error x
    | Error x -> Error x   

let inline opt a (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok a -> Ok(Some a)
    | Error x -> 
        if s = d.Index then Ok(None)
        else Error x

let inline optional a (d: ParserEnv) = 
    let s = d.Index
    match a d with
    | Ok a -> Ok()
    | Error x -> 
        if s = d.Index then Ok()
        else Error x

let inline (|>>) a b d =
    match a d with
    | Ok a -> Ok(b a)
    | Error x -> Error x

let inline (>>%) a b d =
    match a d with
    | Ok a -> Ok(b)
    | Error x -> Error x
        
let inline (>>=) a b d =
    match a d with
    | Ok a -> b a d
    | Error x -> Error x

let inline (>>=?) a b (d: ParserEnv) =
    let i = d.Index
    match a d with
    | Ok a -> 
        let i' = d.Index
        match b a d with
        | Ok x -> Ok x
        | x when i' = d.Index -> d.IndexSet i; x
        | x -> x
    | Error x -> Error x

let rec many a (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x ->
        if s = d.Index then failwith "The parser succeeded without changing the parser state in 'many'. Had an exception not been raised the parser would have diverged."
        else 
            match many a d with
            | Ok x' -> Ok (x :: x')
            | Error x -> Error x
    | Error x -> Ok []

let inline sepBy1 a b (d: ParserEnv) =
    match a d with
    | Ok a' -> (many (b >>. a) |>> fun b -> a' :: b) d
    | Error x -> Error x

let inline many1 a (d: ParserEnv) =
    match a d with
    | Ok a' -> (many a |>> fun b -> a' :: b) d
    | Error x -> Error x

let inline attempt a (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x -> Ok x
    | Error a as a' -> d.IndexSet s; a'

let inline (<|>) a b (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x -> Ok x
    | Error a as a' -> 
        if s = d.Index then
            match b d with
            | Ok x -> Ok x
            | Error b -> Error(List.append a b)
        else
            a'

let inline (<|>%) a b (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x -> Ok x
    | Error a as a' -> 
        if s = d.Index then Ok b
        else a'

let inline choice ar (d: ParserEnv) =
    let s = d.Index
    let rec loop i =
        if i < Array.length ar then
            match ar.[i] d with
            | Ok x -> Ok x
            | Error a as a' -> 
                if s = d.Index then
                    match loop (i+1) with
                    | Ok x -> Ok x
                    | Error b -> Error(List.append a b)
                else
                    a'
        else
            Error []
    loop 0

let inline special x (d: ParserEnv) = d.SkipSpecial x
let match_ d = special SpecMatch d
let typecase_ d = special SpecTypecase d
let function_ d = special SpecFunction d
let with_ d = special SpecWith d
let without d = special SpecWithout d
let as_ d = special SpecAs d
let when_ d = special SpecWhen d
let inl d = special SpecInl d
let forall d = special SpecForall d
let let_ d = special SpecLet d
let inm d = special SpecInm d
let inb d = special SpecInb d
let rec_ d = special SpecRec d
let if_ d = special SpecIf d
let then_ d = special SpecThen d
let elif_ d = special SpecElif d
let else_ d = special SpecElse d
let join d = special SpecJoin d
let type_ d = special SpecType d
let nominal d = special SpecNominal d
let real d = special SpecReal d
let union d = special SpecUnion d
let open_ d = special SpecOpen d
let wildcard d = special SpecWildcard d
let bracket_round_open d = special SpecBracketRoundOpen d
let bracket_curly_open d = special SpecBracketCurlyOpen d
let bracket_square_open d = special SpecBracketSquareOpen d
let bracket_round_close d = special SpecBracketRoundClose d
let bracket_curly_close d = special SpecBracketCurlyClose d
let bracket_square_close d = special SpecBracketSquareClose d

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
