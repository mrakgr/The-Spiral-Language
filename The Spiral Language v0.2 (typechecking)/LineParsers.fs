module Spiral.LineParsers
open System
open System.Text

type Range = {from : int; near_to : int}

type Tokenizer = {
    text : string // A single line.
    mutable from : int
    } with

    member t.Index with get() = t.from and set i = t.from <- i

let inc' i (s : Tokenizer) = s.from <- s.from+i
let inc (s : Tokenizer) = inc' 1 s

type TokenizerError =
    | Tab
    | EOL
    | Expected of string

let inline peek (s : Tokenizer) on_succ =
    let i = s.from
    if i < s.text.Length then on_succ s.text.[i]
    else Error [{from=i; near_to=i+1}, EOL]

let many1Satisfy2L init body label (s : Tokenizer) = peek s <| fun x ->
    if init x then
        inc s
        let b = StringBuilder()
        b.Append(x) |> ignore
        let rec loop () = peek s <| fun x ->
            if body x then inc s; b.Append(x) |> ignore; loop ()
            else Ok(b.ToString())
        loop ()
    else
        let i = s.from
        Error [{from=i; near_to=i+1}, Expected label]

let inline skip c (s : Tokenizer) on_succ on_fail =
    peek s (fun x -> if x = c then inc s; on_succ() else on_fail())

let spaces (s : Tokenizer) =
    let rec loop () = peek s (fun x -> if x = ' ' then inc s; loop() else Ok())
    loop ()

let spaces1 (s : Tokenizer) =
    peek s (fun x -> if x = ' ' then inc s; spaces s else Error [{from=s.from; near_to=s.from+1}, Expected "space"])

