let y = 6.0
let x = 1.0
let l = [0.0..0.02..1.0]
let a = List.map (fun alpha -> (1.0 - alpha) * x + alpha * y) l
let b = List.map (fun alpha -> y - (1.0 - alpha) * x) l
let c = List.map (fun alpha -> alpha * y) l