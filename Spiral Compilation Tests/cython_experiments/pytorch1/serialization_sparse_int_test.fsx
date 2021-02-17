type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2 of f2_0 : uint64
let rec method1 (v0 : uint64, v1 : uint64) : uint64 =
    let v2 : bool = v0 < 1UL
    if v2 then
        let v3 : uint64 = v0 + 1UL
        let v4 : uint64 = v1 * 3504384UL
        method1(v3, v4)
    else
        v1
and method3 (v0 : uint64, v1 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v2 : uint64, v3 : uint64, v4 : uint64) : struct (uint64 * uint64) =
    let v5 : bool = 0UL <= v2
    let v7 : bool =
        if v5 then
            v2 < v0
        else
            false
    let struct (v51 : uint64, v52 : uint64) =
        if v7 then
            let struct (v8 : uint64, v9 : uint64, v10 : uint64, v11 : uint64, v12 : uint64, v13 : US0, v14 : uint64, v15 : uint64) = v1.[System.Convert.ToInt32(v2)]
            let v16 : bool = v15 < 6UL
            let v17 : bool = v16 = false
            if v17 then
                failwith<unit> "Value out of bounds."
            let v18 : uint64 = v15 * 584064UL
            let v19 : bool = v14 < 6UL
            let v20 : bool = v19 = false
            if v20 then
                failwith<unit> "Value out of bounds."
            let v21 : uint64 = v14 * 97344UL
            let v22 : bool = v12 < 6UL
            let v23 : bool = v22 = false
            if v23 then
                failwith<unit> "Value out of bounds."
            let v24 : uint64 = v12 * 16224UL
            let v25 : bool = v8 < 13UL
            let v26 : bool = v25 = false
            if v26 then
                failwith<unit> "Value out of bounds."
            let v27 : uint64 = v8 * 4UL
            let v28 : bool = v9 < 4UL
            let v29 : bool = v28 = false
            if v29 then
                failwith<unit> "Value out of bounds."
            let v30 : uint64 = v27 + v9
            let v31 : uint64 = v30 * 52UL
            let v32 : bool = v10 < 13UL
            let v33 : bool = v32 = false
            if v33 then
                failwith<unit> "Value out of bounds."
            let v34 : uint64 = v10 * 4UL
            let v35 : bool = v11 < 4UL
            let v36 : bool = v35 = false
            if v36 then
                failwith<unit> "Value out of bounds."
            let v37 : uint64 = v34 + v11
            let v38 : uint64 = v31 + v37
            let v39 : uint64 = v38 * 6UL
            let v44 : uint64 =
                match v13 with
                | US0_0 -> (* call *)
                    0UL
                | US0_1 -> (* noAction *)
                    1UL
                | US0_2(v40) -> (* raise_ *)
                    let v41 : bool = v40 < 4UL
                    let v42 : bool = v41 = false
                    if v42 then
                        failwith<unit> "Value out of bounds."
                    2UL + v40
            let v45 : uint64 = v39 + v44
            let v46 : uint64 = v24 + v45
            let v47 : uint64 = v21 + v46
            let v48 : uint64 = v18 + v47
            let v49 : uint64 = v48 * v4
            let v50 : uint64 = v3 * v4
            struct (v49, v50)
        else
            struct (v3, v4)
    let v53 : bool = 0UL < v2
    if v53 then
        let v54 : uint64 = v2 - 1UL
        method3(v0, v1, v54, v51, v52)
    else
        struct (v51, v52)
and method2 (v0 : uint64, v1 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) [])) : uint64 =
    let v2 : uint64 = uint64 v1.LongLength
    let v3 : bool = 1UL = v2
    let v4 : bool = v3 = false
    if v4 then
        failwith<unit> "The array must match the given size."
    let v5 : uint64 = v2
    let v6 : uint64 = 0UL
    let v7 : uint64 = 1UL
    let struct (v8 : uint64, v9 : uint64) = method3(v2, v1, v5, v6, v7)
    v8
and method5 (v0 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v1 : uint64, v2 : uint64, v3 : uint64) : struct (uint64 * uint64) =
    let v4 : bool = v1 < 1UL
    if v4 then
        let v5 : uint64 = v1 + 1UL
        let v6 : uint64 = v2 / 3504384UL
        let v7 : uint64 = v3 / v6
        let v8 : uint64 = v7 / 584064UL
        let v9 : bool = v8 < 6UL
        let v10 : bool = v9 = false
        if v10 then
            failwith<unit> "The index should be less than size."
        let v11 : uint64 = v7 % 584064UL
        let v12 : uint64 = v11 / 97344UL
        let v13 : bool = v12 < 6UL
        let v14 : bool = v13 = false
        if v14 then
            failwith<unit> "The index should be less than size."
        let v15 : uint64 = v11 % 97344UL
        let v16 : uint64 = v15 / 16224UL
        let v17 : bool = v16 < 6UL
        let v18 : bool = v17 = false
        if v18 then
            failwith<unit> "The index should be less than size."
        let v19 : uint64 = v15 % 16224UL
        let v20 : uint64 = v19 / 6UL
        let v21 : uint64 = v20 / 52UL
        let v22 : uint64 = v21 / 4UL
        let v23 : bool = v22 < 13UL
        let v24 : bool = v23 = false
        if v24 then
            failwith<unit> "The index should be less than size."
        let v25 : uint64 = v21 % 4UL
        let v26 : bool = v25 < 4UL
        let v27 : bool = v26 = false
        if v27 then
            failwith<unit> "The index should be less than size."
        let v28 : uint64 = v20 % 52UL
        let v29 : uint64 = v28 / 4UL
        let v30 : bool = v29 < 13UL
        let v31 : bool = v30 = false
        if v31 then
            failwith<unit> "The index should be less than size."
        let v32 : uint64 = v28 % 4UL
        let v33 : bool = v32 < 4UL
        let v34 : bool = v33 = false
        if v34 then
            failwith<unit> "The index should be less than size."
        let v35 : uint64 = v19 % 6UL
        let v36 : bool = v35 < 1UL
        let v53 : US0 =
            if v36 then
                let v37 : bool = v35 = 0UL
                let v38 : bool = v37 = false
                if v38 then
                    failwith<unit> "The unit index should be 0."
                US0_0
            else
                let v40 : bool = v35 < 2UL
                if v40 then
                    let v41 : uint64 = v35 - 1UL
                    let v42 : bool = v41 = 0UL
                    let v43 : bool = v42 = false
                    if v43 then
                        failwith<unit> "The unit index should be 0."
                    US0_1
                else
                    let v45 : bool = v35 < 6UL
                    if v45 then
                        let v46 : uint64 = v35 - 2UL
                        let v47 : bool = v46 < 4UL
                        let v48 : bool = v47 = false
                        if v48 then
                            failwith<unit> "The index should be less than size."
                        US0_2(v46)
                    else
                        failwith<US0> "Unpickling of an union failed."
        v0.[System.Convert.ToInt32(v1)] <- struct (v22, v25, v29, v32, v16, v53, v12, v8)
        let v54 : uint64 = v3 % v6
        method5(v0, v5, v6, v54)
    else
        struct (v2, v3)
and method4 (v0 : uint64, v1 : uint64) : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) =
    let v2 : bool = v1 < v0
    let v3 : bool = v2 = false
    if v3 then
        failwith<unit> "The size of the argument is too large."
    let v4 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) = Array.zeroCreate<struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64)> (System.Convert.ToInt32(1UL))
    let v5 : uint64 = 0UL
    let struct (v6 : uint64, v7 : uint64) = method5(v4, v5, v0, v1)
    v4
and method6 (v0 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v1 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v2 : uint64) : bool =
    let v3 : uint64 = uint64 v0.LongLength
    let v4 : bool = v2 < v3
    if v4 then
        let struct (v5 : uint64, v6 : uint64, v7 : uint64, v8 : uint64, v9 : uint64, v10 : US0, v11 : uint64, v12 : uint64) = v0.[System.Convert.ToInt32(v2)]
        let struct (v13 : uint64, v14 : uint64, v15 : uint64, v16 : uint64, v17 : uint64, v18 : US0, v19 : uint64, v20 : uint64) = v1.[System.Convert.ToInt32(v2)]
        let v21 : bool = v5 = v13
        let v23 : bool =
            if v21 then
                v6 = v14
            else
                false
        let v27 : bool =
            if v23 then
                let v24 : bool = v7 = v15
                if v24 then
                    v8 = v16
                else
                    false
            else
                false
        let v38 : bool =
            if v27 then
                let v28 : bool = v9 = v17
                if v28 then
                    let v32 : bool =
                        match v10, v18 with
                        | US0_0, US0_0 -> (* call *)
                            true
                        | US0_1, US0_1 -> (* noAction *)
                            true
                        | US0_2(v29), US0_2(v30) -> (* raise_ *)
                            v29 = v30
                        | _ ->
                            false
                    if v32 then
                        let v33 : bool = v11 = v19
                        if v33 then
                            v12 = v20
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        if v38 then
            let v39 : uint64 = v2 + 1UL
            method6(v0, v1, v39)
        else
            false
    else
        true
and method0 () : unit =
    let v0 : uint64 = 0UL
    let v1 : uint64 = 1UL
    let v2 : uint64 = method1(v0, v1)
    let v3 : US0 = US0_1
    let v4 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) = [|struct (0UL, 1UL, 12UL, 3UL, 5UL, v3, 2UL, 2UL)|]
    let v5 : uint64 = method2(v2, v4)
    let v6 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) = method4(v2, v5)
    let v7 : uint64 = uint64 v4.LongLength
    let v8 : uint64 = uint64 v6.LongLength
    let v9 : bool = v7 = v8
    let v10 : bool = v9 <> true
    let v13 : bool =
        if v10 then
            false
        else
            let v11 : uint64 = 0UL
            method6(v4, v6, v11)
    let v14 : bool = v13 = false
    if v14 then
        failwith<unit> "Serialization and deserialization should result in the same result."
method0()
