let f x = 1.0 - exp -x
let l = [0.0..1.0..55.0] |> List.map f