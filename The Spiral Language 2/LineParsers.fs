module Spiral.LineParsers
open System
open System.Text
open ParserCombinators

type Range = {from : int; nearTo : int}
type TokenizerError = string

type Tokenizer = {
    text : string // A single line.
    mutable from : int
    } with

    member t.Index with get() = t.from and set i = t.from <- i

let range_char i = {from=i; nearTo=i+1}
let error_char i er = Error [range_char i, er]

let inc' i (s : Tokenizer) = s.from <- s.from+i
let inc (s : Tokenizer) = inc' 1 s

/// End Of Line character
let eol = Char.MaxValue
let peek' (s : Tokenizer) i =
    let i = s.from + i
    if 0 <= i && i < s.text.Length then s.text.[i]
    else eol

let peek (s : Tokenizer) = peek' s 0

let inline many1Satisfy2L init body label (s : Tokenizer) = 
    let x = peek s
    if init x && x <> eol then
        inc s
        let rec loop (b : StringBuilder) = 
            let x = peek s
            if body x && x <> eol then inc s; b.Append(x) |> loop
            else b.ToString()
        Ok(loop (StringBuilder().Append(x)))
    else
        let i = s.from
        error_char i label

let inline many1SatisfyL body label (s : Tokenizer) = many1Satisfy2L body body label s

let inline skip c (s : Tokenizer) = let b = peek s = c in (if b then inc s); b
let rec spaces' (s : Tokenizer) = if peek s = ' ' then inc s; spaces' s
let spaces s = spaces' s |> Ok

let spaces1 (s : Tokenizer) =
    if peek s = ' ' then inc s; spaces s else error_char s.from "space"

let skip_char c (s : Tokenizer) =
    let from = s.from
    if skip c s then Ok() else error_char from (sprintf "'%c'" c)

let skip_string x (s : Tokenizer) =
    if String.Compare(s.text,s.from,x,0,x.Length) = 0 then inc' x.Length s; Ok()
    else error_char s.from x

let anyOf (l : char list) (s : Tokenizer) =
    let c = peek s
    if Seq.contains c l then 
        inc s; Ok(c)
    else
        let i = s.from
        Error (List.map (fun c -> range_char i, string c) l)

let chars_till_string close (s : Tokenizer) =
    assert (close <> "")
    let rec loop (b : StringBuilder) =
        let x = peek s
        if x = close.[0] && String.Compare(s.text,s.from,close,1,close.Length-1) = 0 then inc' close.Length s; Ok(b.ToString())
        else 
            if x <> eol then inc s; b.Append(x) |> loop
            else error_char s.from close
    loop(StringBuilder())

/// Parses a number as a sequence of digits and optionally underscores. Filters out the underscores from the result.
let number (s : Tokenizer) = 
    let x = peek s
    if Char.IsDigit x then
        inc s
        let rec loop (b : StringBuilder) = 
            let x = peek s
            if x = '_' then inc s; loop b
            elif Char.IsDigit x then inc s; loop(b.Append(x))
            else Ok(b.ToString())
        loop (StringBuilder().Append(x))
    else
        let i = s.from
        error_char i "number"

let number_fractional s = (number .>>. (opt (skip_char '.' >>. number))) s
