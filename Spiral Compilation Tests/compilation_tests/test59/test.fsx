let rec method2 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = 0 < v1
    if v2 then
        let v3 : int32 = v1 / 10
        let v4 : int32 = v0 * 10
        let v5 : int32 = v1 % 10
        let v6 : int32 = v4 + v5
        method2(v6, v3)
    else
        v0
and method3 (v0 : int32, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v1 < 1000
    if v3 then
        let v4 : int32 = v1 + 1
        let v5 : int32 = v0 * v1
        let v6 : int32 = 0
        let v7 : int32 = method2(v6, v5)
        let v8 : bool = v5 = v7
        let v10 : bool =
            if v8 then
                v2 < v5
            else
                false
        let v11 : int32 =
            if v10 then
                printfn("%i\n",v5)
                v5
            else
                v2
        method3(v0, v4, v11)
    else
        v2
and method1 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = v0 < 1000
    if v2 then
        let v3 : int32 = v0 + 1
        let v4 : int32 = v0 * v0
        let v5 : int32 = 0
        let v6 : int32 = method2(v5, v4)
        let v7 : bool = v4 = v6
        let v9 : bool =
            if v7 then
                v1 < v4
            else
                false
        let v10 : int32 =
            if v9 then
                printfn("%i\n",v4)
                v4
            else
                v1
        method3(v0, v3, v10)
    else
        v1
and method0 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = v0 < 1000
    if v2 then
        let v3 : int32 = v0 + 1
        let v4 : int32 = method1(v0, v1)
        method0(v3, v4)
    else
        v1
let v0 : int32 = 100
let v1 : int32 = 0
method0(v0, v1)
