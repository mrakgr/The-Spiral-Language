type Mut0 = {mutable l0 : int32}
let rec method0 (v0 : Mut0) : bool =
    let v1 : int32 = v0.l0
    v1 < 10
and method1 (v0 : int32, v1 : Mut0) : bool =
    let v2 : int32 = v1.l0
    v2 < v0
let v0 : (int32 []) = Array.zeroCreate<int32> (10)
let v1 : (int32 []) = Array.zeroCreate<int32> (10)
let v2 : Mut0 = {l0 = 0} : Mut0
while method0(v2) do
    let v4 : int32 = v2.l0
    v0.[int v4] <- v4
    v1.[int v4] <- v4
    let v5 : int32 = v4 + 1
    v2.l0 <- v5
let v6 : int32 = v0.Length
let v7 : (int32 []) = Array.zeroCreate<int32> (v6)
let v8 : (int32 []) = Array.zeroCreate<int32> (v6)
let v9 : (int32 []) = Array.zeroCreate<int32> (v6)
let v10 : Mut0 = {l0 = 0} : Mut0
while method1(v6, v10) do
    let v12 : int32 = v10.l0
    let v13 : int32 = v0.[int v12]
    let v14 : int32 = v1.[int v12]
    let v15 : int32 = v13 * 2
    let v16 : int32 = v14 + 3
    let v17 : int32 = 2 * v14
    let v18 : int32 = v13 - v17
    v7.[int v12] <- v15
    v8.[int v12] <- v16
    v9.[int v12] <- v18
    let v19 : int32 = v12 + 1
    v10.l0 <- v19
struct (v7, v8, v9)
