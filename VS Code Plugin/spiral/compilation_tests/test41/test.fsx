type UH0 =
    | UH0_0 of int32 * int32 * UH0
    | UH0_1
let v0 : UH0 = UH0_1
match v0 with
| UH0_0(v1, v2, v3) -> (* cons_ *)
    match v3 with
    | UH0_0(v4, v5, v6) -> (* cons_ *)
        match v6 with
        | UH0_0(v7, v8, v9) -> (* cons_ *)
            let v10 : int32 = v1 + v2
            let v11 : int32 = v10 + v4
            let v12 : int32 = v11 + v5
            let v13 : int32 = v12 + v7
            let v14 : int32 = v13 + v8
            struct ("At least three elements.", v14)
        | UH0_1 -> (* nil *)
            let v7 : int32 = v1 + v2
            let v8 : int32 = v7 + v4
            let v9 : int32 = v8 + v5
            struct ("Two elements.", v9)
    | UH0_1 -> (* nil *)
        let v4 : int32 = v1 + v2
        struct ("One element.", v4)
| UH0_1 -> (* nil *)
    struct ("No elements", 0)
