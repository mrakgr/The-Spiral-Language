open System
let rng = Random()
let normalize x =
    let sum = x |> Array.sum
    x |> Array.map (fun x -> x / sum)
let probs = [|0.4;0.6|] |> normalize
let f() =
    probs
    |> Array.mapi (fun i x -> 
        let r = rng.NextDouble()
        (if r < x then x else 0),
        i
        )
    |> Array.max
let counts = probs |> Array.map (fun _ -> 0)
for i = 0 to 1 <<< 20 do
    let x,i = f()
    if x > 0 then
        counts[i] <- counts[i] + 1
let probs' =
    counts |> Array.map float |> normalize