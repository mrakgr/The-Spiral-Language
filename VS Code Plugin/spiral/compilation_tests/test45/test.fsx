type [<Struct>] US0 =
    | US0_0
    | US0_1
and UH0 =
    | UH0_0 of string * UH0
    | UH0_1
and [<Struct>] US1 =
    | US1_0
    | US1_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : UH0
and Heap0 = {l0 : US1}
and Mut0 = {mutable l0 : US1}
let rec method1 (v0 : int32, v1 : int32, v2 : int32, v3 : int32, v4 : (US0 []), v5 : int32) : unit =
    let v6 : bool = v5 < v0
    if v6 then
        let v7 : int32 = v5 + 1
        let v8 : bool = v3 = v1
        let v9 : bool =
            if v8 then
                v5 = v2
            else
                false
        let v10 : US0 =
            if v9 then
                let v10 : US0 = US0_1
                v10
            else
                let v10 : US0 = US0_0
                v10
        v4.[v5] <- v10
        method1(v0, v1, v2, v3, v4, v7)
    else
        ()
and method0 (v0 : int32, v1 : int32, v2 : int32, v3 : ((US0 []) []), v4 : int32) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : int32 = v4 + 1
        let v7 : (US0 []) = Array.zeroCreate<US0> v0
        let v8 : int32 = 0
        method1(v0, v1, v2, v4, v7, v8)
        v3.[v4] <- v7
        method0(v0, v1, v2, v3, v6)
    else
        ()
and method4 (v0 : int32, v1 : (bool []), v2 : int32) : unit =
    let v3 : bool = v2 < v0
    if v3 then
        let v4 : int32 = v2 + 1
        v1.[v2] <- false
        method4(v0, v1, v4)
    else
        ()
and method3 (v0 : int32, v1 : ((US0 []) []), v2 : ((bool []) []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : (US0 []) = v1.[v3]
        let v7 : int32 = v6.Length
        let v8 : (bool []) = Array.zeroCreate<bool> v7
        let v9 : int32 = 0
        method4(v7, v8, v9)
        v2.[v3] <- v8
        method3(v0, v1, v2, v5)
    else
        ()
and method6 (v0 : int32, v1 : ((bool []) []), v2 : ((US0 []) []), v3 : Mut0, v4 : (struct (int32 * int32 * UH0) []), v5 : ((struct (int32 * int32 * UH0) []) []), v6 : int32) : unit =
    let v7 : bool = v6 < v0
    if v7 then
        let v8 : int32 = v6 + 1
        let struct (v9 : int32, v10 : int32, v11 : UH0) = v4.[v6]
        let v12 : int32 = v9 - 1
        let v13 : bool = 0 <= v12
        let v14 : bool =
            if v13 then
                let v14 : int32 = v2.Length
                let v15 : bool = v12 < v14
                if v15 then
                    let v16 : (US0 []) = v2.[v12]
                    let v17 : bool = 0 <= v10
                    if v17 then
                        let v18 : int32 = v16.Length
                        v10 < v18
                    else
                        false
                else
                    false
            else
                false
        let v15 : bool =
            if v14 then
                let v15 : (bool []) = v1.[v12]
                let v16 : bool = v15.[v10]
                v16 = false
            else
                false
        let v16 : bool =
            if v15 then
                let v16 : (US0 []) = v2.[v12]
                let v17 : US0 = v16.[v10]
                let v18 : bool =
                    match v17 with
                    | US0_0 -> (* empty *)
                        false
                    | US0_1 -> (* princess *)
                        true
                if v18 then
                    let v19 : UH0 = UH0_0("UP", v11)
                    let v20 : US1 = US1_1(v12, v10, v19)
                    v3.l0 <- v20
                else
                    ()
                let v19 : (bool []) = v1.[v12]
                v19.[v10] <- true
                true
            else
                false
        let v17 : int32 = v9 + 1
        let v18 : bool = 0 <= v17
        let v19 : bool =
            if v18 then
                let v19 : int32 = v2.Length
                let v20 : bool = v17 < v19
                if v20 then
                    let v21 : (US0 []) = v2.[v17]
                    let v22 : bool = 0 <= v10
                    if v22 then
                        let v23 : int32 = v21.Length
                        v10 < v23
                    else
                        false
                else
                    false
            else
                false
        let v20 : bool =
            if v19 then
                let v20 : (bool []) = v1.[v17]
                let v21 : bool = v20.[v10]
                v21 = false
            else
                false
        let v21 : bool =
            if v20 then
                let v21 : (US0 []) = v2.[v17]
                let v22 : US0 = v21.[v10]
                let v23 : bool =
                    match v22 with
                    | US0_0 -> (* empty *)
                        false
                    | US0_1 -> (* princess *)
                        true
                if v23 then
                    let v24 : UH0 = UH0_0("DOWN", v11)
                    let v25 : US1 = US1_1(v17, v10, v24)
                    v3.l0 <- v25
                else
                    ()
                let v24 : (bool []) = v1.[v17]
                v24.[v10] <- true
                true
            else
                false
        let v22 : int32 = v10 - 1
        let v23 : bool = 0 <= v9
        let v24 : bool =
            if v23 then
                let v24 : int32 = v2.Length
                let v25 : bool = v9 < v24
                if v25 then
                    let v26 : (US0 []) = v2.[v9]
                    let v27 : bool = 0 <= v22
                    if v27 then
                        let v28 : int32 = v26.Length
                        v22 < v28
                    else
                        false
                else
                    false
            else
                false
        let v25 : bool =
            if v24 then
                let v25 : (bool []) = v1.[v9]
                let v26 : bool = v25.[v22]
                v26 = false
            else
                false
        let v26 : bool =
            if v25 then
                let v26 : (US0 []) = v2.[v9]
                let v27 : US0 = v26.[v22]
                let v28 : bool =
                    match v27 with
                    | US0_0 -> (* empty *)
                        false
                    | US0_1 -> (* princess *)
                        true
                if v28 then
                    let v29 : UH0 = UH0_0("LEFT", v11)
                    let v30 : US1 = US1_1(v9, v22, v29)
                    v3.l0 <- v30
                else
                    ()
                let v29 : (bool []) = v1.[v9]
                v29.[v22] <- true
                true
            else
                false
        let v27 : int32 = v10 + 1
        let v28 : bool =
            if v23 then
                let v28 : int32 = v2.Length
                let v29 : bool = v9 < v28
                if v29 then
                    let v30 : (US0 []) = v2.[v9]
                    let v31 : bool = 0 <= v27
                    if v31 then
                        let v32 : int32 = v30.Length
                        v27 < v32
                    else
                        false
                else
                    false
            else
                false
        let v29 : bool =
            if v28 then
                let v29 : (bool []) = v1.[v9]
                let v30 : bool = v29.[v27]
                v30 = false
            else
                false
        let v30 : bool =
            if v29 then
                let v30 : (US0 []) = v2.[v9]
                let v31 : US0 = v30.[v27]
                let v32 : bool =
                    match v31 with
                    | US0_0 -> (* empty *)
                        false
                    | US0_1 -> (* princess *)
                        true
                if v32 then
                    let v33 : UH0 = UH0_0("RIGHT", v11)
                    let v34 : US1 = US1_1(v9, v27, v33)
                    v3.l0 <- v34
                else
                    ()
                let v33 : (bool []) = v1.[v9]
                v33.[v27] <- true
                true
            else
                false
        let v31 : int32 =
            if v16 then
                1
            else
                0
        let v32 : int32 =
            if v21 then
                1
            else
                0
        let v33 : int32 = v31 + v32
        let v34 : int32 =
            if v26 then
                1
            else
                0
        let v35 : int32 = v33 + v34
        let v36 : int32 =
            if v30 then
                1
            else
                0
        let v37 : int32 = v35 + v36
        let v38 : (struct (int32 * int32 * UH0) []) = Array.zeroCreate<struct (int32 * int32 * UH0)> v37
        let v39 : int32 =
            if v16 then
                let v39 : UH0 = UH0_0("UP", v11)
                v38.[0] <- struct (v12, v10, v39)
                1
            else
                0
        let v40 : int32 =
            if v21 then
                let v40 : UH0 = UH0_0("DOWN", v11)
                v38.[v39] <- struct (v17, v10, v40)
                v39 + 1
            else
                v39
        let v41 : int32 =
            if v26 then
                let v41 : UH0 = UH0_0("LEFT", v11)
                v38.[v40] <- struct (v9, v22, v41)
                v40 + 1
            else
                v40
        let v42 : int32 =
            if v30 then
                let v42 : UH0 = UH0_0("RIGHT", v11)
                v38.[v41] <- struct (v9, v27, v42)
                v41 + 1
            else
                v41
        v5.[v6] <- v38
        method6(v0, v1, v2, v3, v4, v5, v8)
    else
        ()
and method7 (v0 : int32, v1 : ((struct (int32 * int32 * UH0) []) []), v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v2 < v0
    if v4 then
        let v5 : int32 = v2 + 1
        let v6 : (struct (int32 * int32 * UH0) []) = v1.[v2]
        let v7 : int32 = v6.Length
        let v8 : int32 = v3 + v7
        method7(v0, v1, v5, v8)
    else
        v3
and method9 (v0 : int32, v1 : (struct (int32 * int32 * UH0) []), v2 : (struct (int32 * int32 * UH0) []), v3 : int32, v4 : int32) : int32 =
    let v5 : bool = v3 < v0
    if v5 then
        let v6 : int32 = v3 + 1
        let struct (v7 : int32, v8 : int32, v9 : UH0) = v2.[v3]
        v1.[v4] <- struct (v7, v8, v9)
        let v10 : int32 = v4 + 1
        method9(v0, v1, v2, v6, v10)
    else
        v4
and method8 (v0 : int32, v1 : (struct (int32 * int32 * UH0) []), v2 : ((struct (int32 * int32 * UH0) []) []), v3 : int32, v4 : int32) : int32 =
    let v5 : bool = v3 < v0
    if v5 then
        let v6 : int32 = v3 + 1
        let v7 : (struct (int32 * int32 * UH0) []) = v2.[v3]
        let v8 : int32 = v7.Length
        let v9 : int32 = 0
        let v10 : int32 = method9(v8, v1, v7, v9, v4)
        method8(v0, v1, v2, v6, v10)
    else
        v4
and method10 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_0(v2, v3) -> (* cons_ *)
        let v4 : UH0 = UH0_0(v2, v0)
        method10(v4, v3)
    | UH0_1 -> (* nil *)
        v0
and method5 (v0 : ((bool []) []), v1 : ((US0 []) []), v2 : Mut0, v3 : (struct (int32 * int32 * UH0) [])) : UH0 =
    let v4 : int32 = v3.Length
    let v5 : ((struct (int32 * int32 * UH0) []) []) = Array.zeroCreate<(struct (int32 * int32 * UH0) [])> v4
    let v6 : int32 = 0
    method6(v4, v0, v1, v2, v3, v5, v6)
    let v7 : int32 = v5.Length
    let v8 : int32 = 0
    let v9 : int32 = 0
    let v10 : int32 = method7(v7, v5, v8, v9)
    let v11 : (struct (int32 * int32 * UH0) []) = Array.zeroCreate<struct (int32 * int32 * UH0)> v10
    let v12 : int32 = 0
    let v13 : int32 = 0
    let v14 : int32 = method8(v7, v11, v5, v12, v13)
    let v15 : US1 = v2.l0
    match v15 with
    | US1_0 -> (* none *)
        method5(v0, v1, v2, v11)
    | US1_1(v16, v17, v18) -> (* some_ *)
        let v19 : UH0 = UH0_1
        method10(v19, v18)
and method2 (v0 : ((US0 []) []), v1 : int32, v2 : int32) : UH0 =
    let v3 : int32 = v0.Length
    let v4 : ((bool []) []) = Array.zeroCreate<(bool [])> v3
    let v5 : int32 = 0
    method3(v3, v0, v4, v5)
    let v6 : US1 = US1_0
    let v7 : Mut0 = {l0 = v6} : Mut0
    let v8 : (struct (int32 * int32 * UH0) []) = Array.zeroCreate<struct (int32 * int32 * UH0)> 1
    let v9 : UH0 = UH0_1
    v8.[0] <- struct (v1, v2, v9)
    method5(v4, v0, v7, v8)
and method11 (v0 : UH0) : unit =
    match v0 with
    | UH0_0(v1, v2) -> (* cons_ *)
        printfn "%s" v1
        method11(v2)
    | UH0_1 -> (* nil *)
        ()
let v0 : int32 = 4
let v1 : int32 = 2
let v2 : int32 = 3
let v3 : ((US0 []) []) = Array.zeroCreate<(US0 [])> v0
let v4 : int32 = 0
method0(v0, v1, v2, v3, v4)
let v5 : int32 = 0
let v6 : int32 = 0
let v7 : UH0 = method2(v3, v5, v6)
method11(v7)
