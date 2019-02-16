module Spiral.Parsing

open System.Collections.Generic
open Types
open Tokenize
open System

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
    | Eof

type ParserEnv<'a> =
    {
    l: SpiralToken list ref
    prev_token: SpiralToken ref
    state: 'a // I am assuming this is immutable.
    }

    member inline d.StateUpdate f = {d with state=f d.state}
    member d.ParseTokenList l = {d with l=ref l; prev_token=d.prev_token}

    member d.Peek =
        match !d.l with
        | x :: x' -> Ok x
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.Read =
        match !d.l with
        | x :: x' -> d.l := x'; d.prev_token := x; Ok x
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.SkipSpecial(t) =
        match !d.l with
        | (x & TokSpecial(_,t')) :: x' when t' = t -> d.l := x'; d.prev_token := x; Ok()
        | x :: x' -> Fail [d.prev_token.contents, ExpectedSpecial t]
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.ReadOp =
        match !d.l with
        | (x & TokOperator(_,t')) :: x' -> d.l := x'; d.prev_token := x; Ok t'
        | x :: x' -> Fail [d.prev_token.contents, ExpectedOperator']
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.SkipOperator(t) =
        match !d.l with
        | (x & TokOperator(_,t')) :: x' when t'.name = t -> d.l := x'; d.prev_token := x; Ok()
        | x :: x' -> Fail [d.prev_token.contents, ExpectedOperator t]
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.ReadVar =
        match !d.l with
        | (x & TokVar (_,t')) :: x' -> d.l := x'; d.prev_token := x; Ok t'
        | x :: x' -> Fail [d.prev_token.contents, ExpectedVar]
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.ReadLit =
        match !d.l with
        | (x & TokValue(_,t')) :: x' -> d.l := x'; d.prev_token := x; Ok t'
        | x :: x' -> Fail [d.prev_token.contents, ExpectedLit]
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.ReadKeyword =
        match !d.l with
        | (x & TokKeyword(_,t')) :: x' -> d.l := x'; d.prev_token := x; Ok t'
        | x :: x' -> Fail [d.prev_token.contents, ExpectedKeyword]
        | [] -> Fail [d.prev_token.contents, Eof]

    member d.ReadKeywordUnary =
        match !d.l with
        | (x & TokKeyword(_,t')) :: x' -> d.l := x'; d.prev_token := x; Ok t'
        | x :: x' -> Fail [d.prev_token.contents, ExpectedKeywordUnary]
        | [] -> Fail [d.prev_token.contents, Eof]

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

let rec many a (d: ParserEnv<_>) =
    let s = d.l.contents
    match a d with
    | Ok x ->
        if Object.ReferenceEquals(s,d.l.contents) then failwith "The parser succeeded without changing the parser state in 'many'. Had an exception not been raised the parser would have diverged."
        else 
            match many a d with
            | Ok x' -> Ok (x :: x')
            | Fail x -> Fail x
    | Fail x -> Ok []

let inline sepBy1 a b (d: ParserEnv<_>) =
    match a d with
    | Ok a' -> (many (b >>. a) |>> fun b -> a' :: b) d
    | Fail x -> Fail x

let inline many1 a (d: ParserEnv<_>) =
    match a d with
    | Ok a' -> (many a |>> fun b -> a' :: b) d
    | Fail x -> Fail x

let inline (<|>) a b (d: ParserEnv<_>) =
    let s = d.l.contents
    match a d with
    | Ok x -> Ok x
    | Fail a -> 
        if Object.ReferenceEquals(s,d.l.contents) then
            match b d with
            | Ok x -> Ok x
            | Fail b -> Fail(List.append a b)
        else
            Fail a

let inline choice ar (d: ParserEnv<_>) =
    let s = d.l.contents
    let rec loop i =
        if i < Array.length ar then
            match ar.[i] with
            | Ok x -> Ok x
            | Fail a -> 
                if Object.ReferenceEquals(s,d.l.contents) then
                    match loop (i+1) with
                    | Ok x -> Ok x
                    | Fail b -> Fail(List.append a b)
                else
                    Fail a
        else
            Fail []
    loop 0

let when_ (d: ParserEnv<_>) = d.SkipSpecial SpecWhen
let as_ (d: ParserEnv<_>) = d.SkipSpecial SpecAs
let bar (d: ParserEnv<_>) = d.SkipSpecial SpecOr
let comma (d: ParserEnv<_>) = d.SkipSpecial SpecComma
let semicolon (d: ParserEnv<_>) = d.SkipSpecial SpecSemicolon
let cons (d: ParserEnv<_>) = d.SkipOperator "::"
let amphersand (d: ParserEnv<_>) = d.SkipSpecial SpecAnd
let colon (d: ParserEnv<_>) = d.SkipOperator ":"
let wildcard (d: ParserEnv<_>) = d.SkipSpecial SpecWildcard
let var (d: ParserEnv<_>) = d.ReadVar
let op (d: ParserEnv<_>) = d.ReadOp
let unary_one (d: ParserEnv<_>) = d.SkipSpecial Spec
let unary_two (d: ParserEnv<_>) = d.ReadUnaryTwo
let unary_three (d: ParserEnv<_>) = d.ReadUnaryThree
let unary_four (d: ParserEnv<_>) = d.ReadUnaryFour
let lit_ (d: ParserEnv<_>) = d.ReadLit
let keyword (d: ParserEnv<_>) = d.ReadKeyword
let arr (d: ParserEnv<_>) = d.SkipOperator "=>"
let keyword_unary (d: ParserEnv<_>) = d.ReadKeywordUnary
let eq (d: ParserEnv<_>) = d.SkipOperator "="
   
let parse (x: SpiralToken list) =
    let patterns_template expr =
        let pat_when pattern = pattern .>>. (opt (when_ >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
        let pat_as pattern = pattern .>>. (opt (as_ >>. pattern )) |>> function a, Some b -> PatAnd [a;b] | a, None -> a
        let pat_or pattern = sepBy1 pattern bar |>> function [x] -> x | x -> PatOr x
        let pat_keyword pattern = many1 (keyword .>>. opt pattern) |>> (concat_keyword'' >> PatKeyword) <|> pattern
        let pat_tuple pattern = sepBy1 pattern comma |>> function [x] -> x | x -> PatTuple x
        let pat_cons pattern = sepBy1 pattern cons |>> function [x] -> x | x -> PatCons x
        let pat_and pattern = sepBy1 pattern amphersand |>> function [x] -> x | x -> PatAnd x
        let pat_expr = (var |>> v) <|> rounds expr
        let pat_type pattern = pattern .>>. opt (colon >>. pat_expr) |>> function a,Some b as x-> PatTypeEq(a,b) | a, None -> a
        let pat_closure pattern = sepBy1 pattern arr |>> List.reduceBack (fun a b -> PatTypeTermFunction(a,b))
        let pat_var pattern = (wildcard >>% PatE) <|> (var |>> PatVar) 
        let pat_active pattern = (unary_one >>. pat_expr .>>. pattern |>> PatActive) <|> (unary_three >>. pattern |>> PatUnbox)
        let pat_lit = lit_ |>> PatLit
        let pat_record_item pattern =
            let inline templ var k = pipe2 var (opt (eq >>. pattern)) (fun a -> function Some b -> k(a,b) | None -> k(a,PatVar a))
            templ var_op_name PatRecordMembersKeyword <|> templ (inject >>. var_name) PatRecordMembersInjectVar
        let pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
        let pat_keyword_unary = keyword_unary |>> fun keyword -> PatKeyword(keyword,[])


    ()