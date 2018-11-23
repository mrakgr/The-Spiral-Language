let rng = System.Random()

let ar _ = Array.init 128 (fun _ -> rng.NextDouble() |> float)
let a,b = ar(), ar()
let c = Array.map2 (+) a b
let y = Array.map2 (/) c a
let c' = Array.map2 (*) a y
let a' = Array.map2 (/) c y

Array.map2 (=) a a'
|> Array.map (fun x -> if x then 1 else 0)
|> Array.sum // 114

let a'' = Array.map2 (-) c b

Array.map2 (=) a a''
|> Array.map (fun x -> if x then 1 else 0)
|> Array.sum // 55