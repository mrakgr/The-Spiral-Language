type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2 of f2_0 : uint32
let rec method2 (v0 : uint32, v1 : (float32 []), v2 : uint32, v3 : uint32, v4 : uint32) : struct (uint32 * uint32) =
    let v5 : bool = v2 < v0
    if v5 then
        let v6 : uint32 = v2 + 1u
        let v7 : float32 = v1.[int v2]
        let v8 : bool = v7 = 0.000000f
        let struct (v15 : uint32, v16 : uint32) =
            if v8 then
                struct (v3, v4)
            else
                let v9 : bool = v7 = 1.000000f
                if v9 then
                    let v10 : uint32 = v4 + 1u
                    struct (v2, v10)
                else
                    failwith<struct (uint32 * uint32)> "Unpickling failure. The int type must either be active or inactive."
        method2(v0, v1, v6, v15, v16)
    else
        struct (v3, v4)
and method1 (v0 : (float32 []), v1 : uint32, v2 : uint32) : struct (uint32 * uint32) =
    let v3 : uint32 = 0u
    let v4 : uint32 = 0u
    let struct (v5 : uint32, v6 : uint32) = method2(v1, v0, v2, v3, v4)
    let v7 : bool = 1u < v6
    if v7 then
        failwith<unit> "Unpickling failure. Too many active indices in the one-hot vector."
    let v8 : uint32 = v5 - v2
    struct (v8, v6)
and method0 () : unit =
    let v0 : uint32 = 0u
    let v1 : uint32 = 1u
    let v2 : uint32 = 12u
    let v3 : uint32 = 3u
    let v4 : uint32 = 10u
    let v5 : US0 = US0_1
    let v6 : uint32 = 5u
    let v7 : uint32 = 5u
    let v8 : (float32 []) = Array.zeroCreate<float32> (int 73u)
    let v9 : bool = 0u <= v7
    let v11 : bool =
        if v9 then
            v7 < 11u
        else
            false
    if v11 then
        v8.[int v7] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v12 : bool = 0u <= v6
    let v14 : bool =
        if v12 then
            v6 < 11u
        else
            false
    if v14 then
        let v15 : uint32 = 11u + v6
        v8.[int v15] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v16 : bool = 0u <= v4
    let v18 : bool =
        if v16 then
            v4 < 11u
        else
            false
    if v18 then
        let v19 : uint32 = 22u + v4
        v8.[int v19] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v20 : bool = 0u <= v0
    let v22 : bool =
        if v20 then
            v0 < 13u
        else
            false
    if v22 then
        let v23 : uint32 = 33u + v0
        v8.[int v23] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v24 : bool = 0u <= v1
    let v26 : bool =
        if v24 then
            v1 < 4u
        else
            false
    if v26 then
        let v27 : uint32 = 46u + v1
        v8.[int v27] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v28 : bool = 0u <= v2
    let v30 : bool =
        if v28 then
            v2 < 13u
        else
            false
    if v30 then
        let v31 : uint32 = 50u + v2
        v8.[int v31] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    let v32 : bool = 0u <= v3
    let v34 : bool =
        if v32 then
            v3 < 4u
        else
            false
    if v34 then
        let v35 : uint32 = 63u + v3
        v8.[int v35] <- 1.000000f
    else
        failwith<unit> "Value out of bounds."
    match v5 with
    | US0_0 -> (* call *)
        v8.[int 67u] <- 1.000000f
    | US0_1 -> (* noAction *)
        v8.[int 68u] <- 1.000000f
    | US0_2(v36) -> (* raise_ *)
        let v37 : bool = 0u <= v36
        let v39 : bool =
            if v37 then
                v36 < 4u
            else
                false
        if v39 then
            let v40 : uint32 = 69u + v36
            v8.[int v40] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
    printfn "%A" v8
    let v41 : uint32 = 0u
    let v42 : uint32 = 11u
    let struct (v43 : uint32, v44 : uint32) = method1(v8, v42, v41)
    let v45 : uint32 = 11u
    let v46 : uint32 = 22u
    let struct (v47 : uint32, v48 : uint32) = method1(v8, v46, v45)
    let v49 : uint32 = 22u
    let v50 : uint32 = 33u
    let struct (v51 : uint32, v52 : uint32) = method1(v8, v50, v49)
    let v53 : uint32 = 33u
    let v54 : uint32 = 46u
    let struct (v55 : uint32, v56 : uint32) = method1(v8, v54, v53)
    let v57 : uint32 = 46u
    let v58 : uint32 = 50u
    let struct (v59 : uint32, v60 : uint32) = method1(v8, v58, v57)
    let v61 : uint32 = v56 + v60
    let v62 : bool = v61 = 1u
    if v62 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v63 : uint32 = v61 / 2u
    let v64 : uint32 = 50u
    let v65 : uint32 = 63u
    let struct (v66 : uint32, v67 : uint32) = method1(v8, v65, v64)
    let v68 : uint32 = 63u
    let v69 : uint32 = 67u
    let struct (v70 : uint32, v71 : uint32) = method1(v8, v69, v68)
    let v72 : uint32 = v67 + v71
    let v73 : bool = v72 = 1u
    if v73 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v74 : uint32 = v72 / 2u
    let v75 : uint32 = v63 + v74
    let v76 : bool = v75 = 1u
    if v76 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v77 : uint32 = v75 / 2u
    let v78 : float32 = v8.[int 67u]
    let v79 : bool = v78 = 1.000000f
    let v83 : uint32 =
        if v79 then
            1u
        else
            let v80 : bool = v78 = 0.000000f
            if v80 then
                0u
            else
                failwith<uint32> "Unpickling failure. The unit type should always be either be active or inactive."
    let v84 : float32 = v8.[int 68u]
    let v85 : bool = v84 = 1.000000f
    let v89 : uint32 =
        if v85 then
            1u
        else
            let v86 : bool = v84 = 0.000000f
            if v86 then
                0u
            else
                failwith<uint32> "Unpickling failure. The unit type should always be either be active or inactive."
    let v90 : uint32 = 69u
    let v91 : uint32 = 73u
    let struct (v92 : uint32, v93 : uint32) = method1(v8, v91, v90)
    let v94 : bool = v89 = 1u
    let v97 : US0 =
        if v94 then
            US0_1
        else
            US0_0
    let v98 : uint32 = v83 + v89
    let v99 : bool = v93 = 1u
    let v101 : US0 =
        if v99 then
            US0_2(v92)
        else
            v97
    let v102 : uint32 = v98 + v93
    let v103 : bool = 1u < v102
    if v103 then
        failwith<unit> "Unpickling failure. Only a single case of an union type should be active at most."
    let v104 : uint32 = v77 + v102
    let v105 : bool = v104 = 1u
    if v105 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v106 : uint32 = v104 / 2u
    let v107 : uint32 = v52 + v106
    let v108 : bool = v107 = 1u
    if v108 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v109 : uint32 = v107 / 2u
    let v110 : uint32 = v48 + v109
    let v111 : bool = v110 = 1u
    if v111 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v112 : uint32 = v110 / 2u
    let v113 : uint32 = v44 + v112
    let v114 : bool = v113 = 1u
    if v114 then
        failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
    let v115 : uint32 = v113 / 2u
    let v116 : bool = v115 = 1u
    let v117 : bool = v116 <> true
    if v117 then
        failwith<unit> "Invalid format."
    let v118 : bool = v0 = v55
    let v120 : bool =
        if v118 then
            v1 = v59
        else
            false
    let v124 : bool =
        if v120 then
            let v121 : bool = v2 = v66
            if v121 then
                v3 = v70
            else
                false
        else
            false
    let v135 : bool =
        if v124 then
            let v125 : bool = v4 = v51
            if v125 then
                let v129 : bool =
                    match v5, v101 with
                    | US0_0, US0_0 -> (* call *)
                        true
                    | US0_1, US0_1 -> (* noAction *)
                        true
                    | US0_2(v126), US0_2(v127) -> (* raise_ *)
                        v126 = v127
                    | _ ->
                        false
                if v129 then
                    let v130 : bool = v6 = v47
                    if v130 then
                        v7 = v43
                    else
                        false
                else
                    false
            else
                false
        else
            false
    let v136 : bool = v135 = false
    if v136 then
        failwith<unit> "Serialization and deserialization should result in the same result."
method0()
