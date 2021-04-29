let f y = (1.0 - 1.0/y) ** (3.0 * y)
f 1000000.0

//let var x =
//    let len = float (List.length x)
//    let mean_sqr_sum = let x = List.sum x in x * x / len / (len - 1.0)
//    let var_sum = (List.map (fun x -> x*x) x |> List.sum) / (len - 1.0)
//    sqrt (var_sum - mean_sqr_sum)

let sqr x = x * x
let var x =
    let len = float (List.length x)
    let mean = List.sum x / len
    let var = List.fold (fun s x -> s + sqr x) 0.0 x / len
    sqrt ((var - mean * mean) * len / (len - 1.0))

let var' x =
    let len = float (List.length x)
    let mean = List.sum x / len
    List.fold (fun s x -> s + sqr (x - mean)) 0.0 x / (len - 1.0) |> sqrt

let l = [5.0; 7.0; 10.0; 40.0] |> List.map (fun x -> x / 100.0)
let q = var' l
let w = var l

let x = List.sum l / float (List.length l)