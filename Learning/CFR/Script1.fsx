let q p = p, (2.0 * p + 2.0) / (p + 2.0)
let pos = Array.map q [|1.0..0.01..4.0|]
Array.partition (fun (p,q) -> p*p < 2.0) pos