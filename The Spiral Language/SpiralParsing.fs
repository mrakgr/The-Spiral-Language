module Spiral.Parsing

open System.Collections.Generic
open Types
open Tokenize
open System
open System.Text

// Globals
let private keyword_to_string_dict = Dictionary(HashIdentity.Structural)
let private string_to_keyword_dict = Dictionary(HashIdentity.Structural)
let private string_to_op_dict = Dictionary(HashIdentity.Structural)
let mutable private tag_keyword = 0

let _ =
    Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    |> Array.iter (fun x ->
        string_to_op_dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op
        )
let string_to_op x = string_to_op_dict.TryGetValue x

let string_to_keyword (x: string) =
    match string_to_keyword_dict.TryGetValue x with
    | true, v -> v
    | false, _ ->
        tag_keyword <- tag_keyword + 1
        string_to_keyword_dict.[x] <- tag_keyword
        keyword_to_string_dict.[tag_keyword] <- x
        tag_keyword
let keyword_to_string x = keyword_to_string_dict.[x] // Should never fail.

type ParserExpr =
| ParserStatement of (RawExpr -> RawExpr)
| ParserExpr of RawExpr

[<Struct>]
type Result<'a,'b> =
    | Ok of result: 'a
    | Fail of error: 'b

type ParserErrors =
    | ExpectedSpecial of TokenSpecial
    | ExpectedOperator'
    | ExpectedOperator of string
    | ExpectedUnaryOne
    | ExpectedUnaryTwo
    | ExpectedUnaryThree
    | ExpectedUnaryFour
    | ExpectedVar
    | ExpectedLit
    | ExpectedKeyword
    | ExpectedKeywordUnary
    | ExpectedRounds
    | ExpectedSquares
    | ExpectedCurlies
    | ExpectedIndentation
    | StatementLastInBlock
    | Eof

type ParserEnv =
    {
    l: SpiralToken []
    i: int ref
    module_: SpiralModule
    semicolon_line: int
    }

    member inline private d.LineTemplate f = 
        if d.Length > 0 then
            if d.Index < d.Length then f d.l.[d.Index]
            else f d.l.[d.Length-1]
        else
            -1

    member d.Module = d.module_
    member d.Line = d.LineTemplate (fun x -> x.Start.line)
    member d.Col = d.LineTemplate (fun x -> x.Start.column)
    member d.LineEnd = d.LineTemplate (fun x -> x.End.line)
    member d.ColEnd = d.LineTemplate (fun x -> x.End.column)

    member d.Index = d.i.contents
    member d.Length = d.l.Length
    member d.FailWith x = Fail [d.Index, x]
    member d.Skip = d.i := d.i.contents+1
    member inline d.TryCurrent f =
        let i = d.Index
        if i < d.Length then f d.l.[i]
        else Fail [d.l.Length-1, Eof]

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
                | Ok d' -> Ok (f a b c d)
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
                    | Ok d' -> Ok (f a b c d e)
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

let inline opt a d =
    match a d with
    | Ok a -> Ok(Some a)
    | _ -> Ok(None)

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

let inline (<|>) a b (d: ParserEnv) =
    let s = d.Index
    match a d with
    | Ok x -> Ok x
    | Fail a -> 
        if s = d.Index then
            match b d with
            | Ok x -> Ok x
            | Fail b -> Fail(List.append a b)
        else
            Fail a

let inline choice ar (d: ParserEnv) =
    let s = d.Index
    let rec loop i =
        if i < Array.length ar then
            match ar.[i] d with
            | Ok x -> Ok x
            | Fail a -> 
                if s = d.Index then
                    match loop (i+1) with
                    | Ok x -> Ok x
                    | Fail b -> Fail(List.append a b)
                else
                    Fail a
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
let else_ d = special SpecElse d
let open_ d = special SpecOpen d
let join d = special SpecJoin d
let type_ d = special SpecType d
let type_catch d = special SpecTypeCatch d
let wildcard d = special SpecWildcard d
let lambda d = special SpecLambda d
let or_ d = special SpecOr d
let and_ d = special SpecAnd d
let type_union d = special SpecTypeUnion d
let comma d = special SpecComma d
let semicolon d = special SpecSemicolon d
let unary_one d = special SpecUnaryOne d // ! Used for the active pattern and inbuilt ops.
let unary_two d = special SpecUnaryTwo d // @ Used for parser macros
let unary_three d = special SpecUnaryThree d // # Used for the unboxing pattern.
let unary_four d = special SpecUnaryFour d // $ Used for the injection in patterns and in RecordWith
let bracket_round_open d = special SpecBracketRoundOpen d
let bracket_curly_open d = special SpecBracketCurlyOpen d
let bracket_square_open d = special SpecBracketSquareOpen d
let bracket_round_close d = special SpecBracketRoundClose d
let bracket_curly_close d = special SpecBracketCurlyClose d
let bracket_square_close d = special SpecBracketSquareClose d
let cuda d = special SpecCuda d

let cons (d: ParserEnv) = d.SkipOperator "::"
let colon (d: ParserEnv) = d.SkipOperator ":"
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

let col (d: ParserEnv) = d.Col
let line (d: ParserEnv) = d.Line
let module_ (d: ParserEnv) = d.Module
let pos' s = module_ s, line s, col s

let inline expr_indent i op expr d = if op i (col d) then expr d else d.FailWith ExpectedIndentation

let exprpos expr d = 
    let pos = pos' d
    (expr |>> function
        | RawFunction _ | RawObjectCreate _  as x -> x // Pos nodes can get in the way of optimizations.
        | x -> expr_pos pos x) d
let patpos expr d = (expr |>> pat_pos (pos' d)) d
let exprpos expr d = expr d
let patpos expr d = expr d

let inline concat_keyword f x =
    let strb = StringBuilder()
    let pattern = 
        List.map (fun (str: string, pat) -> 
            strb.Append(str).Append(':') |> ignore
            f (str, pat)
            ) x
    strb.ToString(), pattern

let concat_keyword'' x = concat_keyword (function _, Some pat -> pat | str, None -> PatVar str) x
let concat_keyword' x = let a,b = concat_keyword snd x in a, List.toArray b

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
    let pat_type pattern = pattern .>>. opt (colon >>. pat_expr) |>> function a,Some b as x-> PatTypeEq(a,b) | a, None -> a
    let pat_closure pattern = sepBy1 pattern arr |>> List.reduceBack (fun a b -> PatTypeTermFunction(a,b))
    let pat_wildcard = wildcard >>% PatE
    let pat_var = var |>> PatVar
    let pat_active pattern = unary_one >>. pat_expr .>>. pattern |>> PatActive 
    let pat_unbox pattern = unary_three >>. pattern |>> PatUnbox
    let pat_lit = lit_ |>> PatLit
    let pat_record_item pattern =
        let inline templ var k = pipe2 var (opt (eq >>. pattern)) (fun a -> function Some b -> k(a,b) | None -> k(a,PatVar a))
        templ (var <|> op_as_var) PatRecordMembersKeyword <|> templ (unary_four >>. var) PatRecordMembersInjectVar
    let pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
    let pat_keyword_unary = keyword_unary |>> fun keyword -> PatKeyword(keyword,[])
    let pat_rounds pattern = rounds (pattern <|> (op_as_var |>> PatVar)) 
        
    pat_when ^<| pat_as ^<| pat_or ^<| pat_keyword ^<| pat_tuple ^<| pat_cons ^<| pat_and ^<| pat_type ^<| pat_closure
    ^<| choice [|pat_wildcard; pat_var; pat_active recurse; pat_unbox recurse; pat_lit; pat_record recurse; pat_keyword_unary; pat_rounds recurse|] <| s

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

let indentations statements expressions d =
    let i = col d
    let inline if_ op tr s = expr_indent i op tr s

    let inline many_semis expr = many (if_ (<) semicolon >>. if_ (<) expr)
    let inline many_indents expr = many1 (if_ (=) (pipe2 expr (many_semis expr) (fun a b -> a :: b)))
    many_indents ((statements |>> ParserStatement) <|> (exprpos expressions |>> ParserExpr)) >>= process_parser_exprs <| d
   
let parse (x: SpiralToken list) =

    ()