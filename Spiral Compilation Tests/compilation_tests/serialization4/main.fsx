type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2 of f2_0 : int32
let rec method2 (v0 : int32, v1 : (float32 []), v2 : int32, v3 : int32, v4 : uint32) : struct (int32 * uint32) =
    let v5 : bool = v2 < v0
    if v5 then
        let v6 : int32 = v2 + 1
        let v7 : float32 = v1.[v2]
        let v8 : bool = v7 = 0.000000f
        let struct (v9 : int32, v10 : uint32) =
            if v8 then
                struct (v3, v4)
            else
                let v9 : bool = v7 = 1.000000f
                if v9 then
                    let v10 : uint32 = v4 + 1u
                    struct (v2, v10)
                else
                    failwith<struct (int32 * uint32)> "Unpickling failure. The int type must either be active or inactive."
        method2(v0, v1, v6, v9, v10)
    else
        struct (v3, v4)
and method1 (v0 : (float32 []), v1 : int32, v2 : int32) : struct (int32 * uint32) =
    let v3 : int32 = -1
    let v4 : uint32 = 0u
    let struct (v5 : int32, v6 : uint32) = method2(v1, v0, v2, v3, v4)
    let v7 : bool = 1u < v6
    if v7 then
        failwith<unit> "Unpickling failure. Too many active indices in the one-hot vector."
    let v8 : int32 = v5 - v2
    struct (v8, v6)
and method0 () : unit =
    let v0 : int32 = 0
    let v1 : int32 = 1
    let v2 : int32 = 12
    let v3 : int32 = 3
    let v4 : int32 = 10
    let v5 : US0 = US0_1
    let v6 : int32 = 5
    let v7 : int32 = 5
    let v8 : (float32 []) = Array.zeroCreate<float32> 73
    let v9 : bool = 0 <= v7
    let v10 : bool =
        if v9 then
            v7 < 11
        else
            false
    if v10 then
        v8.[v7] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v11 : bool = 0 <= v6
    let v12 : bool =
        if v11 then
            v6 < 11
        else
            false
    if v12 then
        let v13 : int32 = 11 + v6
        v8.[v13] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v13 : bool = 0 <= v4
    let v14 : bool =
        if v13 then
            v4 < 11
        else
            false
    if v14 then
        let v15 : int32 = 22 + v4
        v8.[v15] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v15 : bool = 0 <= v0
    let v16 : bool =
        if v15 then
            v0 < 13
        else
            false
    if v16 then
        let v17 : int32 = 33 + v0
        v8.[v17] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v17 : bool = 0 <= v1
    let v18 : bool =
        if v17 then
            v1 < 4
        else
            false
    if v18 then
        let v19 : int32 = 46 + v1
        v8.[v19] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v19 : bool = 0 <= v2
    let v20 : bool =
        if v19 then
            v2 < 13
        else
            false
    if v20 then
        let v21 : int32 = 50 + v2
        v8.[v21] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v21 : bool = 0 <= v3
    let v22 : bool =
        if v21 then
            v3 < 4
        else
            false
    if v22 then
        let v23 : int32 = 63 + v3
        v8.[v23] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    match v5 with
    | US0_0 -> (* call *)
        v8.[67] <- 1.000000f
    | US0_1 -> (* noAction *)
        v8.[68] <- 1.000000f
    | US0_2(v23) -> (* raise_ *)
        let v24 : bool = 0 <= v23
        let v25 : bool =
            if v24 then
                v23 < 4
            else
                false
        if v25 then
            let v26 : int32 = 69 + v23
            v8.[v26] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
    printfn "%A" v8
    let v23 : int32 = 0
    let v24 : int32 = 11
    let struct (v25 : int32, v26 : uint32) = method1(v8, v24, v23)
    let v27 : int32 = 11
    let v28 : int32 = 22
    let struct (v29 : int32, v30 : uint32) = method1(v8, v28, v27)
    let v31 : int32 = 22
    let v32 : int32 = 33
    let struct (v33 : int32, v34 : uint32) = method1(v8, v32, v31)
    let v35 : int32 = 33
    let v36 : int32 = 46
    let struct (v37 : int32, v38 : uint32) = method1(v8, v36, v35)
    let v39 : int32 = 46
    let v40 : int32 = 50
    let struct (v41 : int32, v42 : uint32) = method1(v8, v40, v39)
    let v43 : uint32 = v38 + v42
    let v44 : bool = v43 = 1u
    if v44 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v45 : uint32 = v43 / 2u
    let v46 : int32 = 50
    let v47 : int32 = 63
    let struct (v48 : int32, v49 : uint32) = method1(v8, v47, v46)
    let v50 : int32 = 63
    let v51 : int32 = 67
    let struct (v52 : int32, v53 : uint32) = method1(v8, v51, v50)
    let v54 : uint32 = v49 + v53
    let v55 : bool = v54 = 1u
    if v55 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v56 : uint32 = v54 / 2u
    let v57 : uint32 = v45 + v56
    let v58 : bool = v57 = 1u
    if v58 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v59 : uint32 = v57 / 2u
    let v60 : float32 = v8.[67]
    let v61 : bool = v60 = 1.000000f
    let v62 : uint32 =
        if v61 then
            1u
        else
            let v62 : bool = v60 = 0.000000f
            if v62 then
                0u
            else
                failwith<uint32> "Unpickling failure. The unit type should always be either be active or inactive."
    let v63 : float32 = v8.[68]
    let v64 : bool = v63 = 1.000000f
    let v65 : uint32 =
        if v64 then
            1u
        else
            let v65 : bool = v63 = 0.000000f
            if v65 then
                0u
            else
                failwith<uint32> "Unpickling failure. The unit type should always be either be active or inactive."
    let v66 : int32 = 69
    let v67 : int32 = 73
    let struct (v68 : int32, v69 : uint32) = method1(v8, v67, v66)
    let v70 : bool = v65 = 1u
    let v71 : US0 =
        if v70 then
            v5
        else
            US0_0
    let v72 : uint32 = v62 + v65
    let v73 : bool = v69 = 1u
    let v74 : US0 =
        if v73 then
            US0_2(v68)
        else
            v71
    let v75 : uint32 = v72 + v69
    let v76 : bool = 1u < v75
    if v76 then
        failwith<unit> "Unpickling failure. Only a single case of an union type should be active at most."
    let v77 : uint32 = v59 + v75
    let v78 : bool = v77 = 1u
    if v78 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v79 : uint32 = v77 / 2u
    let v80 : uint32 = v34 + v79
    let v81 : bool = v80 = 1u
    if v81 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v82 : uint32 = v80 / 2u
    let v83 : uint32 = v30 + v82
    let v84 : bool = v83 = 1u
    if v84 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v85 : uint32 = v83 / 2u
    let v86 : uint32 = v26 + v85
    let v87 : bool = v86 = 1u
    if v87 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v88 : uint32 = v86 / 2u
    let v89 : bool = v88 = 1u
    let v90 : bool = v89 <> true
    if v90 then
        failwith<unit> "Invalid format."
    let v91 : bool = v0 = v37
    let v92 : bool =
        if v91 then
            v1 = v41
        else
            false
    let v93 : bool =
        if v92 then
            let v93 : bool = v2 = v48
            if v93 then
                v3 = v52
            else
                false
        else
            false
    let v94 : bool =
        if v93 then
            let v94 : bool = v4 = v33
            if v94 then
                let v95 : bool =
                    match v5, v74 with
                    | US0_0, US0_0 -> (* call *)
                        true
                    | US0_1, US0_1 -> (* noAction *)
                        true
                    | US0_2(v95), US0_2(v96) -> (* raise_ *)
                        v95 = v96
                    | _ ->
                        false
                if v95 then
                    let v96 : bool = v6 = v29
                    if v96 then
                        v7 = v25
                    else
                        false
                else
                    false
            else
                false
        else
            false
    let v95 : bool = v94 = false
    if v95 then
        failwith<unit> "Serialization and deserialization should result in the same result."
method0()
