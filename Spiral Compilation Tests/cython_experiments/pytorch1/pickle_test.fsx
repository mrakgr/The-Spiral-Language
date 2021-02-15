type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2 of f2_0 : uint64
let rec method1 (v0 : uint64, v1 : (float32 []), v2 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v3 : uint64) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : uint64 = v3 + 1UL
        let struct (v6 : uint64, v7 : uint64, v8 : uint64, v9 : uint64, v10 : uint64, v11 : US0, v12 : uint64, v13 : uint64) = v2.[System.Convert.ToInt32(v3)]
        let v14 : uint64 = v3 * 73UL
        let v15 : bool = 0UL <= v13
        let v17 : bool =
            if v15 then
                v13 < 11UL
            else
                false
        if v17 then
            let v18 : uint64 = v14 + v13
            v1.[System.Convert.ToInt32(v18)] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
        let v19 : uint64 = v14 + 11UL
        let v20 : bool = 0UL <= v12
        let v22 : bool =
            if v20 then
                v12 < 11UL
            else
                false
        if v22 then
            let v23 : uint64 = v19 + v12
            v1.[System.Convert.ToInt32(v23)] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
        let v24 : uint64 = v19 + 11UL
        let v25 : bool = 0UL <= v10
        let v27 : bool =
            if v25 then
                v10 < 11UL
            else
                false
        if v27 then
            let v28 : uint64 = v24 + v10
            v1.[System.Convert.ToInt32(v28)] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
        let v29 : uint64 = v24 + 11UL
        let v30 : bool = 0UL <= v6
        let v32 : bool =
            if v30 then
                v6 < 13UL
            else
                false
        if v32 then
            let v33 : uint64 = v29 + v6
            v1.[System.Convert.ToInt32(v33)] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
        let v34 : uint64 = v29 + 13UL
        let v35 : bool = 0UL <= v7
        let v37 : bool =
            if v35 then
                v7 < 4UL
            else
                false
        if v37 then
            let v38 : uint64 = v34 + v7
            v1.[System.Convert.ToInt32(v38)] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
        let v39 : uint64 = v29 + 17UL
        let v40 : bool = 0UL <= v8
        let v42 : bool =
            if v40 then
                v8 < 13UL
            else
                false
        if v42 then
            let v43 : uint64 = v39 + v8
            v1.[System.Convert.ToInt32(v43)] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
        let v44 : uint64 = v39 + 13UL
        let v45 : bool = 0UL <= v9
        let v47 : bool =
            if v45 then
                v9 < 4UL
            else
                false
        if v47 then
            let v48 : uint64 = v44 + v9
            v1.[System.Convert.ToInt32(v48)] <- 1.000000f
        else
            failwith<unit> "Value out of bounds."
        let v49 : uint64 = v29 + 34UL
        match v11 with
        | US0_0 -> (* call *)
            v1.[System.Convert.ToInt32(v49)] <- 1.000000f
        | US0_1 -> (* noAction *)
            let v50 : uint64 = v49 + 1UL
            v1.[System.Convert.ToInt32(v50)] <- 1.000000f
        | US0_2(v51) -> (* raise_ *)
            let v52 : uint64 = v49 + 2UL
            let v53 : bool = 0UL <= v51
            let v55 : bool =
                if v53 then
                    v51 < 4UL
                else
                    false
            if v55 then
                let v56 : uint64 = v52 + v51
                v1.[System.Convert.ToInt32(v56)] <- 1.000000f
            else
                failwith<unit> "Value out of bounds."
        method1(v0, v1, v2, v5)
and method5 (v0 : uint64, v1 : (float32 []), v2 : uint64, v3 : uint64, v4 : uint64) : struct (uint64 * uint64) =
    let v5 : bool = v2 < v0
    if v5 then
        let v6 : uint64 = v2 + 1UL
        let v7 : float32 = v1.[System.Convert.ToInt32(v2)]
        let v8 : bool = v7 = 0.000000f
        let struct (v15 : uint64, v16 : uint64) =
            if v8 then
                struct (v3, v4)
            else
                let v9 : bool = v7 = 1.000000f
                if v9 then
                    let v10 : uint64 = v4 + 1UL
                    struct (v2, v10)
                else
                    failwith<struct (uint64 * uint64)> "Unpickling failure. The int type must either be active or inactive."
        method5(v0, v1, v6, v15, v16)
    else
        struct (v3, v4)
and method4 (v0 : (float32 []), v1 : uint64, v2 : uint64) : struct (uint64 * uint64) =
    let v3 : uint64 = 0UL
    let v4 : uint64 = 0UL
    let struct (v5 : uint64, v6 : uint64) = method5(v1, v0, v2, v3, v4)
    let v7 : bool = 1UL < v6
    if v7 then
        failwith<unit> "Unpickling failure. Too many active indices in the one-hot vector."
    let v8 : uint64 = v5 - v2
    struct (v8, v6)
and method3 (v0 : (float32 []), v1 : uint64, v2 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v3 : uint64, v4 : uint64) : uint64 =
    let v5 : bool = v3 < 3UL
    if v5 then
        let v6 : uint64 = v3 + 1UL
        let v7 : uint64 = v3 * 73UL
        let v8 : uint64 = v1 + v7
        let v9 : bool = v3 = v4
        let v156 : uint64 =
            if v9 then
                let v10 : uint64 = v8 + 11UL
                let struct (v11 : uint64, v12 : uint64) = method4(v0, v10, v8)
                let v13 : uint64 = v10 + 11UL
                let struct (v14 : uint64, v15 : uint64) = method4(v0, v13, v10)
                let v16 : uint64 = v13 + 11UL
                let struct (v17 : uint64, v18 : uint64) = method4(v0, v16, v13)
                let v19 : uint64 = v16 + 13UL
                let struct (v20 : uint64, v21 : uint64) = method4(v0, v19, v16)
                let v22 : uint64 = v19 + 4UL
                let struct (v23 : uint64, v24 : uint64) = method4(v0, v22, v19)
                let v25 : uint64 = v21 + v24
                let v26 : bool = v25 = 1UL
                if v26 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v27 : uint64 = v25 / 2UL
                let v28 : uint64 = v16 + 17UL
                let v29 : uint64 = v28 + 13UL
                let struct (v30 : uint64, v31 : uint64) = method4(v0, v29, v28)
                let v32 : uint64 = v29 + 4UL
                let struct (v33 : uint64, v34 : uint64) = method4(v0, v32, v29)
                let v35 : uint64 = v31 + v34
                let v36 : bool = v35 = 1UL
                if v36 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v37 : uint64 = v35 / 2UL
                let v38 : uint64 = v27 + v37
                let v39 : bool = v38 = 1UL
                if v39 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v40 : uint64 = v38 / 2UL
                let v41 : uint64 = v16 + 34UL
                let v42 : float32 = v0.[System.Convert.ToInt32(v41)]
                let v43 : bool = v42 = 1.000000f
                let v47 : uint64 =
                    if v43 then
                        1UL
                    else
                        let v44 : bool = v42 = 0.000000f
                        if v44 then
                            0UL
                        else
                            failwith<uint64> "Unpickling failure. The unit type should always be either be active or inactive."
                let v48 : uint64 = v41 + 1UL
                let v49 : float32 = v0.[System.Convert.ToInt32(v48)]
                let v50 : bool = v49 = 1.000000f
                let v54 : uint64 =
                    if v50 then
                        1UL
                    else
                        let v51 : bool = v49 = 0.000000f
                        if v51 then
                            0UL
                        else
                            failwith<uint64> "Unpickling failure. The unit type should always be either be active or inactive."
                let v55 : uint64 = v41 + 2UL
                let v56 : uint64 = v55 + 4UL
                let struct (v57 : uint64, v58 : uint64) = method4(v0, v56, v55)
                let v59 : bool = v54 = 1UL
                let v62 : US0 =
                    if v59 then
                        US0_1
                    else
                        US0_0
                let v63 : uint64 = v47 + v54
                let v64 : bool = v58 = 1UL
                let v66 : US0 =
                    if v64 then
                        US0_2(v57)
                    else
                        v62
                let v67 : uint64 = v63 + v58
                let v68 : bool = 1UL < v67
                if v68 then
                    failwith<unit> "Unpickling failure. Only a single case of an union type should be active at most."
                let v69 : uint64 = v40 + v67
                let v70 : bool = v69 = 1UL
                if v70 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v71 : uint64 = v69 / 2UL
                let v72 : uint64 = v18 + v71
                let v73 : bool = v72 = 1UL
                if v73 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v74 : uint64 = v72 / 2UL
                let v75 : uint64 = v15 + v74
                let v76 : bool = v75 = 1UL
                if v76 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v77 : uint64 = v75 / 2UL
                let v78 : uint64 = v12 + v77
                let v79 : bool = v78 = 1UL
                if v79 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v80 : uint64 = v78 / 2UL
                let v81 : bool = v80 = 1UL
                if v81 then
                    v2.[System.Convert.ToInt32(v3)] <- struct (v20, v23, v30, v33, v17, v66, v14, v11)
                v4 + v80
            else
                let v83 : uint64 = v8 + 11UL
                let struct (v84 : uint64, v85 : uint64) = method4(v0, v83, v8)
                let v86 : uint64 = v83 + 11UL
                let struct (v87 : uint64, v88 : uint64) = method4(v0, v86, v83)
                let v89 : uint64 = v86 + 11UL
                let struct (v90 : uint64, v91 : uint64) = method4(v0, v89, v86)
                let v92 : uint64 = v89 + 13UL
                let struct (v93 : uint64, v94 : uint64) = method4(v0, v92, v89)
                let v95 : uint64 = v92 + 4UL
                let struct (v96 : uint64, v97 : uint64) = method4(v0, v95, v92)
                let v98 : uint64 = v94 + v97
                let v99 : bool = v98 = 1UL
                if v99 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v100 : uint64 = v98 / 2UL
                let v101 : uint64 = v89 + 17UL
                let v102 : uint64 = v101 + 13UL
                let struct (v103 : uint64, v104 : uint64) = method4(v0, v102, v101)
                let v105 : uint64 = v102 + 4UL
                let struct (v106 : uint64, v107 : uint64) = method4(v0, v105, v102)
                let v108 : uint64 = v104 + v107
                let v109 : bool = v108 = 1UL
                if v109 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v110 : uint64 = v108 / 2UL
                let v111 : uint64 = v100 + v110
                let v112 : bool = v111 = 1UL
                if v112 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v113 : uint64 = v111 / 2UL
                let v114 : uint64 = v89 + 34UL
                let v115 : float32 = v0.[System.Convert.ToInt32(v114)]
                let v116 : bool = v115 = 1.000000f
                let v120 : uint64 =
                    if v116 then
                        1UL
                    else
                        let v117 : bool = v115 = 0.000000f
                        if v117 then
                            0UL
                        else
                            failwith<uint64> "Unpickling failure. The unit type should always be either be active or inactive."
                let v121 : uint64 = v114 + 1UL
                let v122 : float32 = v0.[System.Convert.ToInt32(v121)]
                let v123 : bool = v122 = 1.000000f
                let v127 : uint64 =
                    if v123 then
                        1UL
                    else
                        let v124 : bool = v122 = 0.000000f
                        if v124 then
                            0UL
                        else
                            failwith<uint64> "Unpickling failure. The unit type should always be either be active or inactive."
                let v128 : uint64 = v114 + 2UL
                let v129 : uint64 = v128 + 4UL
                let struct (v130 : uint64, v131 : uint64) = method4(v0, v129, v128)
                let v132 : bool = v127 = 1UL
                let v135 : US0 =
                    if v132 then
                        US0_1
                    else
                        US0_0
                let v136 : uint64 = v120 + v127
                let v137 : bool = v131 = 1UL
                let v139 : US0 =
                    if v137 then
                        US0_2(v130)
                    else
                        v135
                let v140 : uint64 = v136 + v131
                let v141 : bool = 1UL < v140
                if v141 then
                    failwith<unit> "Unpickling failure. Only a single case of an union type should be active at most."
                let v142 : uint64 = v113 + v140
                let v143 : bool = v142 = 1UL
                if v143 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v144 : uint64 = v142 / 2UL
                let v145 : uint64 = v91 + v144
                let v146 : bool = v145 = 1UL
                if v146 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v147 : uint64 = v145 / 2UL
                let v148 : uint64 = v88 + v147
                let v149 : bool = v148 = 1UL
                if v149 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v150 : uint64 = v148 / 2UL
                let v151 : uint64 = v85 + v150
                let v152 : bool = v151 = 1UL
                if v152 then
                    failwith<unit> "Unpickling failure. Two sides of a pair should either all be active or inactive."
                let v153 : uint64 = v151 / 2UL
                let v154 : bool = v153 = 0UL
                let v155 : bool = v154 <> true
                if v155 then
                    failwith<unit> "Expected an inactive subsequence in the array unpickler."
                v4
        method3(v0, v1, v2, v6, v156)
    else
        v4
and method6 (v0 : uint64, v1 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v2 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v3 : uint64) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : uint64 = v3 + 1UL
        let struct (v6 : uint64, v7 : uint64, v8 : uint64, v9 : uint64, v10 : uint64, v11 : US0, v12 : uint64, v13 : uint64) = v1.[System.Convert.ToInt32(v3)]
        v2.[System.Convert.ToInt32(v3)] <- struct (v6, v7, v8, v9, v10, v11, v12, v13)
        method6(v0, v1, v2, v5)
and method2 (v0 : (float32 []), v1 : uint64) : struct ((struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) * uint64) =
    let v2 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) = Array.zeroCreate<struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64)> (System.Convert.ToInt32(3UL))
    let v3 : uint64 = 0UL
    let v4 : uint64 = 0UL
    let v5 : uint64 = method3(v0, v1, v2, v3, v4)
    let v6 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) = Array.zeroCreate<struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64)> (System.Convert.ToInt32(v5))
    let v7 : uint64 = 0UL
    method6(v5, v2, v6, v7)
    struct (v6, 1UL)
and method7 (v0 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v1 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v2 : uint64) : bool =
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
            method7(v0, v1, v39)
        else
            false
    else
        true
and method0 () : unit =
    let v0 : US0 = US0_1
    let v1 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []) = [|struct (0UL, 1UL, 12UL, 3UL, 10UL, v0, 5UL, 5UL)|]
    let v2 : (float32 []) = Array.zeroCreate<float32> (System.Convert.ToInt32(219UL))
    let v3 : uint64 = uint64 v1.LongLength
    let v4 : bool = 3UL < v3
    if v4 then
        failwith<unit> "The given array is too large."
    let v5 : uint64 = 0UL
    method1(v3, v2, v1, v5)
    let v6 : uint64 = 0UL
    let struct (v7 : (struct (uint64 * uint64 * uint64 * uint64 * uint64 * US0 * uint64 * uint64) []), v8 : uint64) = method2(v2, v6)
    let v9 : bool = v8 = 1UL
    let v10 : bool = v9 <> true
    if v10 then
        failwith<unit> "Invalid format."
    let v11 : uint64 = uint64 v7.LongLength
    let v12 : bool = v3 = v11
    let v13 : bool = v12 <> true
    let v16 : bool =
        if v13 then
            false
        else
            let v14 : uint64 = 0UL
            method7(v1, v7, v14)
    let v17 : bool = v16 = false
    if v17 then
        failwith<unit> "Serialization and deserialization should result in the same result."
method0()
