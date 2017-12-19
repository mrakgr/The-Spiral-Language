"1 2 3".Split [|' '|] |> Array.map int
|> Array.fold (+) 0