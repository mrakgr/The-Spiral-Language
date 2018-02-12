open System.IO

let path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"

let text = File.ReadAllText path
text.Length

let symbols = text.ToCharArray() |> Array.groupBy id |> Array.map (fun (a,b) -> a,b.Length)

symbols
|> Array.map (fst >> int)
|> Array.max

let s = [|0.2;0.3;0.5|]

let f i j =
    if i = j then s.[i]*(1.0-s.[j])
    else -s.[i]*s.[j]

let g i = f 0 i + f 1 i + f 2 i
g 0


