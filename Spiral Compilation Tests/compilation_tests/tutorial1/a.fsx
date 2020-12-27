let rec method0 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 10
    if v2 then
        let v3 : int32 = v1 + 1
        v0.[v1] <- v1
        method0(v0, v3)
    else
        ()
and closure0 () (v0 : int32) : int32 =
    2 + v0
and method1 (v0 : int32, v1 : (int32 -> int32), v2 : (int32 []), v3 : (int32 []), v4 : int32) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : int32 = v4 + 1
        let v7 : int32 = v2.[v4]
        let v8 : int32 = v1 v7
        v3.[v4] <- v8
        method1(v0, v1, v2, v3, v6)
    else
        ()
and closure1 () (v0 : int32) : int32 =
    10 * v0
and closure2 () (v0 : int32) : int32 =
    2 / v0
and closure3 () (v0 : int32) : int32 =
    5 - v0
and closure4 () (v0 : int32) : int32 =
    4 % v0
let v0 : (int32 []) = Array.zeroCreate<int32> 10
let v1 : int32 = 0
method0(v0, v1)
let v2 : (int32 -> int32) = closure0()
let v3 : int32 = v0.Length
let v4 : (int32 []) = Array.zeroCreate<int32> v3
let v5 : int32 = 0
method1(v3, v2, v0, v4, v5)
let v6 : (int32 -> int32) = closure1()
let v7 : int32 = v4.Length
let v8 : (int32 []) = Array.zeroCreate<int32> v7
let v9 : int32 = 0
method1(v7, v6, v4, v8, v9)
let v10 : (int32 -> int32) = closure2()
let v11 : int32 = v8.Length
let v12 : (int32 []) = Array.zeroCreate<int32> v11
let v13 : int32 = 0
method1(v11, v10, v8, v12, v13)
let v14 : (int32 -> int32) = closure3()
let v15 : int32 = v12.Length
let v16 : (int32 []) = Array.zeroCreate<int32> v15
let v17 : int32 = 0
method1(v15, v14, v12, v16, v17)
let v18 : (int32 -> int32) = closure4()
let v19 : int32 = v16.Length
let v20 : (int32 []) = Array.zeroCreate<int32> v19
let v21 : int32 = 0
method1(v19, v18, v16, v20, v21)
v20
