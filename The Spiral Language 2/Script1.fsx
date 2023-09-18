open System

let num_bits_needed_to_represent (x : int) = Numerics.BitOperations.Log2(x * 2 |> uint) |> max 1
List.init 20 (fun i -> let i = i+1 in i, num_bits_needed_to_represent i)
|> printfn "%A"