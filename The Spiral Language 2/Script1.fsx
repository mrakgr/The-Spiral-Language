open System
open System.IO

let a = "asdf @ qwerty @ 2134"
match a.Split " @ "  with
| [|a|] -> a
| [|a;b|] -> a
| _ -> failwith $"Encountered a malformed type macro. Got: {a}"

