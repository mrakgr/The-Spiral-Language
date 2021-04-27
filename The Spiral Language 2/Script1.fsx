//let t = 100.0
//let rec iter n m i =
//    if i < n then
//        let rec loop m i =
//            if i < 1 then
//                let s = (1.1 / m) ** float (i+1)
//                let m = (t - 1.0) / t * m + 1.0 / t * s
//                loop m (i+1)
//            else m

//        let m = loop m 0
//        iter n m (i+1)
//    else
//        m
//let m = iter 10000 1.0 0

let x = 0.2
let r = x / (x + x)
x / r

let l = [0.2;0.5]
let s = l |> List.fold (fun s x -> s + abs x) 0.0
let u = l |> List.map (fun x -> x * s / x)