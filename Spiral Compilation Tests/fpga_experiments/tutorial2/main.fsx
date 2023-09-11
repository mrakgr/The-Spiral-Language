type Heap0 = {l0 : string; l1 : char; l2 : int32}
and Mut0 = {mutable l0 : string; mutable l1 : char; mutable l2 : int32}
let rec method0 (v0 : Heap0) : int32 =
    let struct (v1 : char, v2 : int32) = v0.l1, v0.l2
    v2
and method1 (v0 : Mut0) : unit =
    v0.l2 <- 5
    ()
let v0 : string = "asd"
let v1 : Heap0 = {l0 = v0; l1 = 'l'; l2 = 1} : Heap0
let v2 : Mut0 = {l0 = v0; l1 = 'l'; l2 = 1} : Mut0
let v3 : int32 = method0(v1)
method1(v2)
