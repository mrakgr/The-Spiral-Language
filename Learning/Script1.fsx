let rng = System.Random()

let ar = Array.init 10 (fun x -> rng.Next(10) |> float)
let beta = 0.01
let alpha = 1.0 - beta
let s = Array.fold (fun s x -> alpha * s + beta * x) 0.0 ar
let s' =
    let k = ar.Length |> float
    let alpha = alpha ** k
    let beta = 1.0 - alpha
    beta * Array.sum ar / k
