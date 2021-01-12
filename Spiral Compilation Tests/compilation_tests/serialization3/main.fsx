type [<Struct>] US0 =
    | US0_0
    | US0_1 of f1_0 : int32
and [<Struct>] US1 =
    | US1_0
    | US1_1
and [<Struct>] US2 =
    | US2_0
    | US2_1 of f1_0 : US0
and [<Struct>] US3 =
    | US3_0
    | US3_1 of f1_0 : int32 * f1_1 : US0
and [<Struct>] US4 =
    | US4_0
    | US4_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : US0
and [<Struct>] US5 =
    | US5_0
    | US5_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : int32 * f1_3 : US0
let rec method1 (v0 : (float32 []), v1 : int32, v2 : int32, v3 : int32) : US0 =
    let v4 : bool = v3 < 5
    if v4 then
        let v5 : float32 = v0.[v3]
        let v6 : bool = v5 = 0.000000f
        if v6 then
            let v7 : int32 = v3 + 1
            method1(v0, v1, v2, v7)
        else
            let v7 : bool = v5 = 1.000000f
            if v7 then
                let v8 : int32 = v1 + 1
                let v9 : int32 = v3 + 1
                method1(v0, v8, v3, v9)
            else
                failwith<US0> "Unpickling failure. The int type must either be active or inactive."
    else
        let v5 : bool = v1 = 0
        if v5 then
            US0_0
        else
            let v6 : bool = v1 = 1
            if v6 then
                US0_1(v2)
            else
                failwith<US0> "Unpickling failure. Too many active indices in the one-hot vector."
and method2 (v0 : (float32 []), v1 : int32, v2 : int32, v3 : int32) : US0 =
    let v4 : bool = v3 < 8
    if v4 then
        let v5 : float32 = v0.[v3]
        let v6 : bool = v5 = 0.000000f
        if v6 then
            let v7 : int32 = v3 + 1
            method2(v0, v1, v2, v7)
        else
            let v7 : bool = v5 = 1.000000f
            if v7 then
                let v8 : int32 = v3 - 5
                let v9 : int32 = v1 + 1
                let v10 : int32 = v3 + 1
                method2(v0, v9, v8, v10)
            else
                failwith<US0> "Unpickling failure. The int type must either be active or inactive."
    else
        let v5 : bool = v1 = 0
        if v5 then
            US0_0
        else
            let v6 : bool = v1 = 1
            if v6 then
                US0_1(v2)
            else
                failwith<US0> "Unpickling failure. Too many active indices in the one-hot vector."
and method3 (v0 : (float32 []), v1 : int32, v2 : int32, v3 : int32) : US0 =
    let v4 : bool = v3 < 11
    if v4 then
        let v5 : float32 = v0.[v3]
        let v6 : bool = v5 = 0.000000f
        if v6 then
            let v7 : int32 = v3 + 1
            method3(v0, v1, v2, v7)
        else
            let v7 : bool = v5 = 1.000000f
            if v7 then
                let v8 : int32 = v3 - 8
                let v9 : int32 = v1 + 1
                let v10 : int32 = v3 + 1
                method3(v0, v9, v8, v10)
            else
                failwith<US0> "Unpickling failure. The int type must either be active or inactive."
    else
        let v5 : bool = v1 = 0
        if v5 then
            US0_0
        else
            let v6 : bool = v1 = 1
            if v6 then
                US0_1(v2)
            else
                failwith<US0> "Unpickling failure. Too many active indices in the one-hot vector."
and method4 (v0 : (float32 []), v1 : int32, v2 : int32, v3 : int32) : US0 =
    let v4 : bool = v3 < 13
    if v4 then
        let v5 : float32 = v0.[v3]
        let v6 : bool = v5 = 0.000000f
        if v6 then
            let v7 : int32 = v3 + 1
            method4(v0, v1, v2, v7)
        else
            let v7 : bool = v5 = 1.000000f
            if v7 then
                let v8 : int32 = v3 - 12
                let v9 : int32 = v1 + 1
                let v10 : int32 = v3 + 1
                method4(v0, v9, v8, v10)
            else
                failwith<US0> "Unpickling failure. The int type must either be active or inactive."
    else
        let v5 : bool = v1 = 0
        if v5 then
            US0_0
        else
            let v6 : bool = v1 = 1
            if v6 then
                US0_1(v2)
            else
                failwith<US0> "Unpickling failure. Too many active indices in the one-hot vector."
and method0 () : unit =
    let v0 : int32 = 4
    let v1 : int32 = 2
    let v2 : int32 = 2
    let v3 : int32 = 0
    let v4 : US0 = US0_1(v3)
    let v5 : (float32 []) = Array.zeroCreate<float32> 13
    let v6 : bool = 0 <= v0
    let v7 : bool =
        if v6 then
            v0 < 5
        else
            false
    if v7 then
        v5.[v0] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v8 : bool = 0 <= v1
    let v9 : bool =
        if v8 then
            v1 < 3
        else
            false
    if v9 then
        let v10 : int32 = 5 + v1
        v5.[v10] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v10 : bool = 0 <= v2
    let v11 : bool =
        if v10 then
            v2 < 3
        else
            false
    if v11 then
        let v12 : int32 = 8 + v2
        v5.[v12] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    match v4 with
    | US0_0 -> (* none *)
        v5.[11] <- 1.000000f
    | US0_1(v12) -> (* some_ *)
        let v13 : bool = 0 <= v12
        let v14 : bool =
            if v13 then
                v12 < 1
            else
                false
        if v14 then
            let v15 : int32 = 12 + v12
            v5.[v15] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
    printfn "%A" v5
    let v12 : int32 = -1
    let v13 : int32 = 0
    let v14 : int32 = 0
    let v15 : US0 = method1(v5, v13, v12, v14)
    let v16 : int32 = -1
    let v17 : int32 = 0
    let v18 : int32 = 5
    let v19 : US0 = method2(v5, v17, v16, v18)
    let v20 : int32 = -1
    let v21 : int32 = 0
    let v22 : int32 = 8
    let v23 : US0 = method3(v5, v21, v20, v22)
    let v24 : float32 = v5.[11]
    let v25 : bool = v24 = 1.000000f
    let v26 : US1 =
        if v25 then
            US1_1
        else
            let v26 : bool = v24 = 0.000000f
            if v26 then
                US1_0
            else
                failwith<US1> "Unpickling failure. The unit type should always be either be active or inactive."
    let v27 : US2 =
        match v26 with
        | US1_0 -> (* none *)
            US2_0
        | US1_1 -> (* some_ *)
            let v27 : US0 = US0_0
            US2_1(v27)
    let v28 : int32 = -1
    let v29 : int32 = 0
    let v30 : int32 = 12
    let v31 : US0 = method4(v5, v29, v28, v30)
    let v32 : US2 =
        match v31 with
        | US0_0 -> (* none *)
            US2_0
        | US0_1(v32) -> (* some_ *)
            let v33 : US0 = US0_1(v32)
            US2_1(v33)
    let struct (v33 : US2, v34 : int32) =
        match v27 with
        | US2_0 -> (* none *)
            let v33 : US2 = US2_0
            struct (v33, 0)
        | US2_1(v33) -> (* some_ *)
            struct (v27, 1)
    let struct (v35 : US2, v36 : int32) =
        match v32 with
        | US2_0 -> (* none *)
            struct (v33, v34)
        | US2_1(v35) -> (* some_ *)
            let v36 : int32 = v34 + 1
            struct (v32, v36)
    let v37 : bool = v36 = 0
    let v38 : US2 =
        if v37 then
            US2_0
        else
            let v38 : bool = v36 = 1
            if v38 then
                v35
            else
                failwith<US2> "Unpickling failure. Only a single case of an union type should be active at most."
    let v39 : US3 =
        match v23 with
        | US0_0 -> (* none *)
            match v38 with
            | US2_0 -> (* none *)
                US3_0
            | US2_1(v39) -> (* some_ *)
                failwith<US3> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US0_1(v39) -> (* some_ *)
            match v38 with
            | US2_0 -> (* none *)
                failwith<US3> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US2_1(v40) -> (* some_ *)
                US3_1(v39, v40)
    let v40 : US4 =
        match v19 with
        | US0_0 -> (* none *)
            match v39 with
            | US3_0 -> (* none *)
                US4_0
            | US3_1(v40, v41) -> (* some_ *)
                failwith<US4> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US0_1(v40) -> (* some_ *)
            match v39 with
            | US3_0 -> (* none *)
                failwith<US4> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US3_1(v41, v42) -> (* some_ *)
                US4_1(v40, v41, v42)
    let v41 : US5 =
        match v15 with
        | US0_0 -> (* none *)
            match v40 with
            | US4_0 -> (* none *)
                US5_0
            | US4_1(v41, v42, v43) -> (* some_ *)
                failwith<US5> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US0_1(v41) -> (* some_ *)
            match v40 with
            | US4_0 -> (* none *)
                failwith<US5> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US4_1(v42, v43, v44) -> (* some_ *)
                US5_1(v41, v42, v43, v44)
    let struct (v42 : int32, v43 : int32, v44 : int32, v45 : US0) =
        match v41 with
        | US5_0 -> (* none *)
            failwith<struct (int32 * int32 * int32 * US0)> "Invalid format."
        | US5_1(v42, v43, v44, v45) -> (* some_ *)
            struct (v42, v43, v44, v45)
    let v46 : bool = v0 = v42
    let v47 : bool =
        if v46 then
            let v47 : bool = v1 = v43
            if v47 then
                let v48 : bool = v2 = v44
                if v48 then
                    match v4, v45 with
                    | US0_0, US0_0 -> (* none *)
                        true
                    | US0_1(v49), US0_1(v50) -> (* some_ *)
                        v49 = v50
                    | _ ->
                        false
                else
                    false
            else
                false
        else
            false
    let v48 : bool = v47 = false
    if v48 then
        failwith<unit> "Serialization and deserialization should result in the same result."
    else
        ()
method0()
