open System.IO

let path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"

let text = File.ReadAllText path

let symbols = text.ToCharArray() |> Array.groupBy id |> Array.map (fun (a,b) -> a,b.Length)

symbols 
|> Array.map (fst >> int)
|> Array.max
