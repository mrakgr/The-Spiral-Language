module Spiral.LineParsers
open System
open System.Text
open ParserCombinators

type Range = {from : int; near_to : int}

type Tokenizer = {
    text : string // A single line.
    mutable from : int
    } with

    member t.Index with get() = t.from and set i = t.from <- i

let range_char i = {from=i; near_to=i+1}
let error_char i er = Error [range_char i, er]

let inc' i (s : Tokenizer) = s.from <- s.from+i
let inc (s : Tokenizer) = inc' 1 s

type TokenizerError =
    | Expected of string
    | Message of string

/// Out Of Bounds character
let oob = Char.MaxValue
let peek' (s : Tokenizer) i =
    let i = s.from + i
    if i < s.text.Length then s.text.[i]
    else oob

let peek (s : Tokenizer) = peek' s 0

let inline many1Satisfy2L init body label (s : Tokenizer) = 
    let x = peek s
    if init x then
        inc s
        let b = StringBuilder()
        b.Append(x) |> ignore
        let rec loop () = 
            let x = peek s
            if body x then inc s; b.Append(x) |> ignore; loop ()
            else Ok(b.ToString())
        loop ()
    else
        let i = s.from
        error_char i (Expected label)

let inline many1SatisfyL body label (s : Tokenizer) = many1Satisfy2L body body label s

let inline skip c (s : Tokenizer) on_succ on_fail =
    let x = peek s 
    if x = c then inc s; on_succ() else on_fail()

let spaces (s : Tokenizer) =
    let rec loop () = if peek s = ' ' then inc s; loop() else Ok()
    loop ()

let spaces1 (s : Tokenizer) =
    if peek s = ' ' then inc s; spaces s else Error [{from=s.from; near_to=s.from+1}, Expected "space"]

let skip_char c (s : Tokenizer) =
    let from = s.from
    skip c s Ok (fun () -> error_char from (Expected (sprintf "'%c'" c)))

let skip_string x (s : Tokenizer) =
    if String.Compare(s.text,s.from,x,0,x.Length) = 0 then inc' x.Length s; Ok()
    else error_char s.from (Expected x)

let chars_till_string close (s : Tokenizer) =
    assert (close <> "")
    let b = StringBuilder()
    let rec loop () =
        let x = peek s
        if x = close.[0] && String.Compare(s.text,s.from,close,1,close.Length-1) = 0 then inc' close.Length s; Ok(b.ToString())
        else 
            if x <> oob then inc s; b.Append(x) |> ignore; loop()
            else error_char s.from (Expected close)
    loop()

/// Parses a number as a sequence of digits and optionally underscores. Filters out the underscores from the result.
let number (s : Tokenizer) = 
    let x = peek s
    if Char.IsDigit x then
        inc s
        let b = StringBuilder()
        b.Append(x) |> ignore
        let rec loop () = 
            let x = peek s
            if x = '_' then inc s; loop ()
            elif Char.IsDigit x then inc s; b.Append(x) |> ignore; loop ()
            else Ok(b.ToString())
        loop ()
    else
        let i = s.from
        error_char i (Expected "number")

let number_fractional s = (number .>>. (opt (skip_char '.' >>. number))) s