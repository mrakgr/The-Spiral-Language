type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2 of f2_0 : int32
and [<Struct>] US1 =
    | US1_0
    | US1_1 of f1_0 : int32
and [<Struct>] US2 =
    | US2_0
    | US2_1 of f1_0 : int32 * f1_1 : int32
and [<Struct>] US3 =
    | US3_0
    | US3_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : int32 * f1_3 : int32
and [<Struct>] US4 =
    | US4_0
    | US4_1
and [<Struct>] US5 =
    | US5_0
    | US5_1 of f1_0 : US0
and [<Struct>] US6 =
    | US6_0
    | US6_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : int32 * f1_3 : int32 * f1_4 : US0
and [<Struct>] US7 =
    | US7_0
    | US7_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : int32 * f1_3 : int32 * f1_4 : int32 * f1_5 : US0
and [<Struct>] US8 =
    | US8_0
    | US8_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : int32 * f1_3 : int32 * f1_4 : int32 * f1_5 : int32 * f1_6 : US0
and [<Struct>] US9 =
    | US9_0
    | US9_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : int32 * f1_3 : int32 * f1_4 : int32 * f1_5 : int32 * f1_6 : int32 * f1_7 : US0
and [<Struct>] US10 =
    | US10_0
    | US10_1 of f1_0 : int32 * f1_1 : int32 * f1_2 : int32 * f1_3 : int32 * f1_4 : int32 * f1_5 : US0 * f1_6 : int32 * f1_7 : int32
let rec method2 (v0 : int32, v1 : (float32 []), v2 : int32, v3 : int32, v4 : int32) : struct (int32 * int32) =
    let v5 : bool = v2 < v0
    if v5 then
        let v6 : int32 = v2 + 1
        let v7 : float32 = v1.[v2]
        let v8 : bool = v7 = 0.000000f
        let struct (v9 : int32, v10 : int32) =
            if v8 then
                struct (v3, v4)
            else
                let v9 : bool = v7 = 1.000000f
                if v9 then
                    let v10 : int32 = v4 + 1
                    struct (v2, v10)
                else
                    failwith<struct (int32 * int32)> "Unpickling failure. The int type must either be active or inactive."
        method2(v0, v1, v6, v9, v10)
    else
        struct (v3, v4)
and method1 (v0 : (float32 []), v1 : int32, v2 : int32) : US1 =
    let v3 : int32 = -1
    let v4 : int32 = 0
    let struct (v5 : int32, v6 : int32) = method2(v1, v0, v2, v3, v4)
    let v7 : bool = v6 = 0
    if v7 then
        US1_0
    else
        let v8 : bool = v6 = 1
        if v8 then
            let v9 : int32 = v5 - v2
            US1_1(v9)
        else
            failwith<US1> "Unpickling failure. Too many active indices in the one-hot vector."
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
    let v25 : US1 = method1(v8, v24, v23)
    let v26 : int32 = 11
    let v27 : int32 = 22
    let v28 : US1 = method1(v8, v27, v26)
    let v29 : int32 = 22
    let v30 : int32 = 33
    let v31 : US1 = method1(v8, v30, v29)
    let v32 : int32 = 33
    let v33 : int32 = 46
    let v34 : US1 = method1(v8, v33, v32)
    let v35 : int32 = 46
    let v36 : int32 = 50
    let v37 : US1 = method1(v8, v36, v35)
    let v38 : US2 =
        match v34 with
        | US1_0 -> (* none *)
            match v37 with
            | US1_0 -> (* none *)
                US2_0
            | US1_1(v38) -> (* some_ *)
                failwith<US2> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US1_1(v38) -> (* some_ *)
            match v37 with
            | US1_0 -> (* none *)
                failwith<US2> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US1_1(v39) -> (* some_ *)
                US2_1(v38, v39)
    let v39 : int32 = 50
    let v40 : int32 = 63
    let v41 : US1 = method1(v8, v40, v39)
    let v42 : int32 = 63
    let v43 : int32 = 67
    let v44 : US1 = method1(v8, v43, v42)
    let v45 : US2 =
        match v41 with
        | US1_0 -> (* none *)
            match v44 with
            | US1_0 -> (* none *)
                US2_0
            | US1_1(v45) -> (* some_ *)
                failwith<US2> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US1_1(v45) -> (* some_ *)
            match v44 with
            | US1_0 -> (* none *)
                failwith<US2> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US1_1(v46) -> (* some_ *)
                US2_1(v45, v46)
    let v46 : US3 =
        match v38 with
        | US2_0 -> (* none *)
            match v45 with
            | US2_0 -> (* none *)
                US3_0
            | US2_1(v46, v47) -> (* some_ *)
                failwith<US3> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US2_1(v46, v47) -> (* some_ *)
            match v45 with
            | US2_0 -> (* none *)
                failwith<US3> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US2_1(v48, v49) -> (* some_ *)
                US3_1(v46, v47, v48, v49)
    let v47 : float32 = v8.[67]
    let v48 : bool = v47 = 1.000000f
    let v49 : US4 =
        if v48 then
            US4_1
        else
            let v49 : bool = v47 = 0.000000f
            if v49 then
                US4_0
            else
                failwith<US4> "Unpickling failure. The unit type should always be either be active or inactive."
    let v50 : US5 =
        match v49 with
        | US4_0 -> (* none *)
            US5_0
        | US4_1 -> (* some_ *)
            let v50 : US0 = US0_0
            US5_1(v50)
    let v51 : float32 = v8.[68]
    let v52 : bool = v51 = 1.000000f
    let v53 : US4 =
        if v52 then
            US4_1
        else
            let v53 : bool = v51 = 0.000000f
            if v53 then
                US4_0
            else
                failwith<US4> "Unpickling failure. The unit type should always be either be active or inactive."
    let v54 : US5 =
        match v53 with
        | US4_0 -> (* none *)
            US5_0
        | US4_1 -> (* some_ *)
            US5_1(v5)
    let v55 : int32 = 69
    let v56 : int32 = 73
    let v57 : US1 = method1(v8, v56, v55)
    let v58 : US5 =
        match v57 with
        | US1_0 -> (* none *)
            US5_0
        | US1_1(v58) -> (* some_ *)
            let v59 : US0 = US0_2(v58)
            US5_1(v59)
    let struct (v59 : US5, v60 : int32) =
        match v50 with
        | US5_0 -> (* none *)
            let v59 : US5 = US5_0
            struct (v59, 0)
        | US5_1(v59) -> (* some_ *)
            struct (v50, 1)
    let struct (v61 : US5, v62 : int32) =
        match v54 with
        | US5_0 -> (* none *)
            struct (v59, v60)
        | US5_1(v61) -> (* some_ *)
            let v62 : int32 = v60 + 1
            struct (v54, v62)
    let struct (v63 : US5, v64 : int32) =
        match v58 with
        | US5_0 -> (* none *)
            struct (v61, v62)
        | US5_1(v63) -> (* some_ *)
            let v64 : int32 = v62 + 1
            struct (v58, v64)
    let v65 : bool = v64 = 0
    let v66 : US5 =
        if v65 then
            US5_0
        else
            let v66 : bool = v64 = 1
            if v66 then
                v63
            else
                failwith<US5> "Unpickling failure. Only a single case of an union type should be active at most."
    let v67 : US6 =
        match v46 with
        | US3_0 -> (* none *)
            match v66 with
            | US5_0 -> (* none *)
                US6_0
            | US5_1(v67) -> (* some_ *)
                failwith<US6> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US3_1(v67, v68, v69, v70) -> (* some_ *)
            match v66 with
            | US5_0 -> (* none *)
                failwith<US6> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US5_1(v71) -> (* some_ *)
                US6_1(v67, v68, v69, v70, v71)
    let v68 : US7 =
        match v31 with
        | US1_0 -> (* none *)
            match v67 with
            | US6_0 -> (* none *)
                US7_0
            | US6_1(v68, v69, v70, v71, v72) -> (* some_ *)
                failwith<US7> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US1_1(v68) -> (* some_ *)
            match v67 with
            | US6_0 -> (* none *)
                failwith<US7> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US6_1(v69, v70, v71, v72, v73) -> (* some_ *)
                US7_1(v68, v69, v70, v71, v72, v73)
    let v69 : US8 =
        match v28 with
        | US1_0 -> (* none *)
            match v68 with
            | US7_0 -> (* none *)
                US8_0
            | US7_1(v69, v70, v71, v72, v73, v74) -> (* some_ *)
                failwith<US8> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US1_1(v69) -> (* some_ *)
            match v68 with
            | US7_0 -> (* none *)
                failwith<US8> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US7_1(v70, v71, v72, v73, v74, v75) -> (* some_ *)
                US8_1(v69, v70, v71, v72, v73, v74, v75)
    let v70 : US9 =
        match v25 with
        | US1_0 -> (* none *)
            match v69 with
            | US8_0 -> (* none *)
                US9_0
            | US8_1(v70, v71, v72, v73, v74, v75, v76) -> (* some_ *)
                failwith<US9> "Unpickling failure. Two sides of a pair should either all be active or inactive."
        | US1_1(v70) -> (* some_ *)
            match v69 with
            | US8_0 -> (* none *)
                failwith<US9> "Unpickling failure. Two sides of a pair should either all be active or inactive."
            | US8_1(v71, v72, v73, v74, v75, v76, v77) -> (* some_ *)
                US9_1(v70, v71, v72, v73, v74, v75, v76, v77)
    let v71 : US10 =
        match v70 with
        | US9_0 -> (* none *)
            US10_0
        | US9_1(v71, v72, v73, v74, v75, v76, v77, v78) -> (* some_ *)
            US10_1(v74, v75, v76, v77, v73, v78, v72, v71)
    let struct (v72 : int32, v73 : int32, v74 : int32, v75 : int32, v76 : int32, v77 : US0, v78 : int32, v79 : int32) =
        match v71 with
        | US10_0 -> (* none *)
            failwith<struct (int32 * int32 * int32 * int32 * int32 * US0 * int32 * int32)> "Invalid format."
        | US10_1(v72, v73, v74, v75, v76, v77, v78, v79) -> (* some_ *)
            struct (v72, v73, v74, v75, v76, v77, v78, v79)
    let v80 : bool = v0 = v72
    let v81 : bool =
        if v80 then
            v1 = v73
        else
            false
    let v82 : bool =
        if v81 then
            let v82 : bool = v2 = v74
            if v82 then
                v3 = v75
            else
                false
        else
            false
    let v83 : bool =
        if v82 then
            let v83 : bool = v4 = v76
            if v83 then
                let v84 : bool =
                    match v5, v77 with
                    | US0_0, US0_0 -> (* call *)
                        true
                    | US0_1, US0_1 -> (* noAction *)
                        true
                    | US0_2(v84), US0_2(v85) -> (* raise_ *)
                        v84 = v85
                    | _ ->
                        false
                if v84 then
                    let v85 : bool = v6 = v78
                    if v85 then
                        v7 = v79
                    else
                        false
                else
                    false
            else
                false
        else
            false
    let v84 : bool = v83 = false
    if v84 then
        failwith<unit> "Serialization and deserialization should result in the same result."
    else
        ()
method0()
