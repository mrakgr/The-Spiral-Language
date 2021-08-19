let rec method0 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 10
    if v2 then
        let v3 : int32 = v1 + 1
        v0.[int v1] <- v1
        method0(v0, v3)
and method1 (v0 : int32, v1 : (int32 []), v2 : (struct (int32 * int32) []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : int32 = v1.[int v3]
        v2.[int v3] <- struct (v6, v6)
        method1(v0, v1, v2, v5)
let v0 : (int32 []) = Array.zeroCreate<int32> (10)
let v1 : int32 = 0
method0(v0, v1)
let v3 : int32 = v0.Length
let v4 : (struct (int32 * int32) []) = Array.zeroCreate<struct (int32 * int32)> (v3)
let v5 : int32 = 0
method1(v3, v0, v4, v5)
v4
