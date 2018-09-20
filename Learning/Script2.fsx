/// Error measurements for the reversible weight updates for Hebbian learning.

type R<'a> = {passes: int32; error : 'a}

let inline error_template float passes H' H =
    let rng = System.Random()
    let input_out = Array.init passes (fun _ -> rng.NextDouble() |> float, rng.NextDouble() |> float)

    let Hs, r = Array.mapFold H' (float 0.0) input_out
    let H's, r' = Array.mapFoldBack H input_out r

    let errors = Array.map2 (fun a b -> abs (a - b)) Hs H's
    {passes=passes; error=errors.[0]} // The error is highest at the beginning as could be expected.

let inline error_oja float passes =
    let n = float 0.01
    let one = float 1.0

    let H' H (input, out) = 
        let r = H + n * (input * out - out * out * H)
        r,r
    let H (input, out) H' = 
        let r = (n * input * out - H') / (n * out * out - one) 
        H',r

    error_template float passes H' H

let inline error_ema float passes =
    let n = float 0.01
    let one = float 1.0

    let H' H (input, out) = 
        let r = n * input * out + (n - one) * H
        r,r
    let H (input, out) H' = 
        let r = (H' - n * input * out) / (n - one)
        H',r

    error_template float passes H' H
    
let passes = [|500;1000;2000;3000;4000;5000;6000;7000;8000;9000|]
printfn "The Oja errors with float32 are:"
Array.iter (error_oja float32 >> printfn "%A") passes

printfn "The Oja errors with float64 are:"
Array.iter (error_oja float >> printfn "%A") passes

printfn "The EMA errors with float32 are:"
Array.iter (error_ema float32 >> printfn "%A") passes

printfn "The EMA errors with float64 are:"
Array.iter (error_ema float >> printfn "%A") passes