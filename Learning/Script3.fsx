/// Error measurements for the reversible weight updates for Hebbian learning.

type R<'a> = {passes: int32; error : 'a}

let inline error_template num_weights float passes H' H =
    let rng = System.Random()
    let num_weights = int num_weights

    let weights = Array.zeroCreate num_weights
    let input_out = Array.init passes (fun _ -> Array.init num_weights (fun _ -> rng.NextDouble() |> float), rng.NextDouble() |> float)

    let Hs, r = Array.mapFold H' weights input_out
    let H's, r' = Array.mapFoldBack H input_out r

    let errors = (Array.map2 << Array.map2) (fun a b -> abs (a - b)) Hs H's
    {passes=passes; error=errors.[0]}

let inline error_weight_norm num_weigths float passes =
    let n = float 0.01
    let zero = float 0.0
    let one = float 1.0

    let norm x =
        let mean = Array.sum x / num_weigths
        let x = Array.map (fun x -> x - mean) x
        let std = Array.fold (fun s x -> s + x * x) zero x / num_weigths |> sqrt
        Array.map (fun x -> if std <> zero then x / std else zero) x

    let H' H (input, out) = 
        let r = Array.map2 (fun H input -> H + n * input * out) H input |> norm
        r,r
    let H (input, out) H' = 
        let r = Array.map2 (fun H' input -> H' - n * input * out) H' input |> norm
        H',r

    error_template num_weigths float passes H' H

   
let passes = [|500;1000;2000;3000;4000;5000;6000;7000;8000;9000;10000|] |> Array.map ((*) 20)
printfn "The Weight Norm errors with float32 are:"
Array.iter (error_weight_norm 256.0f float32 >> printfn "%A") passes

printfn "The Weight Norm errors with float64 are:"
Array.iter (error_weight_norm 256.0 float >> printfn "%A") passes

