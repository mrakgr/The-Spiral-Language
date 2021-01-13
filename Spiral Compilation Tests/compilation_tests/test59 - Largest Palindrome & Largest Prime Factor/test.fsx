let rec method0 (v0 : int32, v1 : (bool []), v2 : int32) : unit =
    let v3 : bool = v2 < v0
    if v3 then
        let v4 : int32 = v2 + 1
        v1.[v2] <- true
        method0(v0, v1, v4)
and method2 (v0 : int32, v1 : int32, v2 : (bool []), v3 : int32) : unit =
    let v4 : bool = v3 < v1
    if v4 then
        let v5 : int32 = v3 + v0
        v2.[v3] <- false
        method2(v0, v1, v2, v5)
and method1 (v0 : int32, v1 : int32, v2 : (bool []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : bool = v2.[v3]
        if v6 then
            let v7 : int32 = v3 + v3
            let v8 : int32 = v1 + 1
            method2(v3, v8, v2, v7)
        method1(v0, v1, v2, v5)
and method3 (v0 : int32, v1 : (bool []), v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v2 < v0
    if v4 then
        let v5 : int32 = v2 + 2
        let v6 : bool = v1.[v2]
        let v7 : bool =
            if v6 then
                let v7 : int64 = int64 v2
                let v8 : int64 = 60085147514L % v7
                v8 = 0L
            else
                false
        let v8 : int32 =
            if v7 then
                v2
            else
                v3
        method3(v0, v1, v5, v8)
    else
        v3
and method6 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = 0 < v1
    if v2 then
        let v3 : int32 = v1 / 10
        let v4 : int32 = v0 * 10
        let v5 : int32 = v1 % 10
        let v6 : int32 = v4 + v5
        method6(v6, v3)
    else
        v0
and method7 (v0 : int32, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v1 < 1000
    if v3 then
        let v4 : int32 = v1 + 1
        let v5 : int32 = v0 * v1
        let v6 : int32 = 0
        let v7 : int32 = method6(v6, v5)
        let v8 : bool = v5 = v7
        let v9 : bool =
            if v8 then
                v2 < v5
            else
                false
        let v10 : int32 =
            if v9 then
                v5
            else
                v2
        method7(v0, v4, v10)
    else
        v2
and method5 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = v0 < 1000
    if v2 then
        let v3 : int32 = v0 + 1
        let v4 : int32 = v0 * v0
        let v5 : int32 = 0
        let v6 : int32 = method6(v5, v4)
        let v7 : bool = v4 = v6
        let v8 : bool =
            if v7 then
                v1 < v4
            else
                false
        let v9 : int32 =
            if v8 then
                v4
            else
                v1
        method7(v0, v3, v9)
    else
        v1
and method4 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = v0 < 1000
    if v2 then
        let v3 : int32 = v0 + 1
        let v4 : int32 = method5(v0, v1)
        method4(v3, v4)
    else
        v1
let v0 : int32 = 60085147514L |> float |> sqrt |> int
let v1 : int32 = v0 + 1
let v2 : (bool []) = Array.zeroCreate<bool> v1
let v3 : int32 = 0
method0(v1, v2, v3)
let v4 : int32 = 2
method1(v1, v0, v2, v4)
let v5 : int32 = 3
let v6 : int32 = -1
let v7 : int32 = method3(v1, v2, v5, v6)
printfn "%i" v7
let v8 : int32 = 100
let v9 : int32 = 0
let v10 : int32 = method4(v8, v9)
printfn "%i" v10
