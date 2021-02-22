type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and [<Struct>] US2 =
    | US2_0 of f0_0 : US0
    | US2_1 of f1_0 : US1
and UH0 =
    | UH0_0 of US2 * UH0
    | UH0_1
and UH1 =
    | UH1_0 of US0 * UH1
    | UH1_1
and UH2 =
    | UH2_0 of US1 * (US0 []) * UH2
    | UH2_1
let rec method2 (v0 : uint64, v1 : uint64, v2 : (US1 []), v3 : (US1 []), v4 : uint64) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : uint64 = v4 + 1UL
        let v7 : bool = v1 <= v4
        let v8 : uint64 =
            if v7 then
                v6
            else
                v4
        let v9 : US1 = v2.[System.Convert.ToInt32(v8)]
        v3.[System.Convert.ToInt32(v4)] <- v9
        method2(v0, v1, v2, v3, v6)
and method5 (v0 : UH1, v1 : UH1) : UH1 =
    match v1 with
    | UH1_0(v2, v3) -> (* cons_ *)
        let v4 : UH1 = UH1_0(v2, v0)
        method5(v4, v3)
    | UH1_1 -> (* nil *)
        v0
and method7 (v0 : uint64, v1 : UH1) : uint64 =
    match v1 with
    | UH1_0(v2, v3) -> (* cons_ *)
        let v4 : uint64 = v0 + 1UL
        method7(v4, v3)
    | UH1_1 -> (* nil *)
        v0
and method8 (v0 : (US0 []), v1 : uint64, v2 : UH1) : uint64 =
    match v2 with
    | UH1_0(v3, v4) -> (* cons_ *)
        v0.[System.Convert.ToInt32(v1)] <- v3
        let v5 : uint64 = v1 + 1UL
        method8(v0, v5, v4)
    | UH1_1 -> (* nil *)
        v1
and method6 (v0 : UH1) : (US0 []) =
    let v1 : uint64 = 0UL
    let v2 : uint64 = method7(v1, v0)
    let v3 : (US0 []) = Array.zeroCreate<US0> (System.Convert.ToInt32(v2))
    let v4 : uint64 = 0UL
    let v5 : uint64 = method8(v3, v4, v0)
    v3
and method4 (v0 : UH1, v1 : US1, v2 : UH0) : UH2 =
    match v2 with
    | UH0_0(v3, v4) -> (* cons_ *)
        match v3 with
        | US2_0(v5) -> (* action_ *)
            let v6 : UH1 = UH1_0(v5, v0)
            method4(v6, v1, v4)
        | US2_1(v8) -> (* observation_ *)
            let v9 : UH1 = UH1_1
            let v10 : UH1 = method5(v9, v0)
            let v11 : (US0 []) = method6(v10)
            let v12 : UH1 = UH1_1
            let v13 : UH2 = method4(v12, v8, v4)
            UH2_0(v1, v11, v13)
    | UH0_1 -> (* nil *)
        let v16 : UH1 = UH1_1
        let v17 : UH1 = method5(v16, v0)
        let v18 : (US0 []) = method6(v17)
        let v19 : UH2 = UH2_1
        UH2_0(v1, v18, v19)
and method10 (v0 : uint64, v1 : UH2) : uint64 =
    match v1 with
    | UH2_0(v2, v3, v4) -> (* cons_ *)
        let v5 : uint64 = v0 + 1UL
        method10(v5, v4)
    | UH2_1 -> (* nil *)
        v0
and method11 (v0 : (struct (US1 * (US0 [])) []), v1 : uint64, v2 : UH2) : uint64 =
    match v2 with
    | UH2_0(v3, v4, v5) -> (* cons_ *)
        v0.[System.Convert.ToInt32(v1)] <- struct (v3, v4)
        let v6 : uint64 = v1 + 1UL
        method11(v0, v6, v5)
    | UH2_1 -> (* nil *)
        v1
and method9 (v0 : UH2) : (struct (US1 * (US0 [])) []) =
    let v1 : uint64 = 0UL
    let v2 : uint64 = method10(v1, v0)
    let v3 : (struct (US1 * (US0 [])) []) = Array.zeroCreate<struct (US1 * (US0 []))> (System.Convert.ToInt32(v2))
    let v4 : uint64 = 0UL
    let v5 : uint64 = method11(v3, v4, v0)
    v3
and method3 (v0 : UH0) : (struct (US1 * (US0 [])) []) =
    match v0 with
    | UH0_0(v1, v2) -> (* cons_ *)
        match v1 with
        | US2_0(v3) -> (* action_ *)
            failwith<(struct (US1 * (US0 [])) [])> "Expected a card."
        | US2_1(v5) -> (* observation_ *)
            let v6 : UH1 = UH1_1
            let v7 : UH2 = method4(v6, v5, v2)
            method9(v7)
    | UH0_1 -> (* nil *)
        failwith<(struct (US1 * (US0 [])) [])> "Expected a card."
and method12 (v0 : uint64, v1 : (float32 []), v2 : uint64) : unit =
    let v3 : bool = v2 < v0
    if v3 then
        let v4 : uint64 = v2 + 1UL
        v1.[System.Convert.ToInt32(v2)] <- 0.000000f
        method12(v0, v1, v4)
and method14 (v0 : uint64, v1 : (float32 []), v2 : uint64, v3 : (US0 []), v4 : uint64) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : uint64 = v4 + 1UL
        let v7 : US0 = v3.[System.Convert.ToInt32(v4)]
        let v8 : uint64 = v4 * 3UL
        let v9 : uint64 = v2 + v8
        match v7 with
        | US0_0 -> (* call *)
            v1.[System.Convert.ToInt32(v9)] <- 1.000000f
        | US0_1 -> (* fold *)
            let v10 : uint64 = v9 + 1UL
            v1.[System.Convert.ToInt32(v10)] <- 1.000000f
        | US0_2 -> (* raise *)
            let v11 : uint64 = v9 + 2UL
            v1.[System.Convert.ToInt32(v11)] <- 1.000000f
        method14(v0, v1, v2, v3, v6)
and method13 (v0 : uint64, v1 : (float32 []), v2 : (struct (US1 * (US0 [])) []), v3 : uint64) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : uint64 = v3 + 1UL
        let struct (v6 : US1, v7 : (US0 [])) = v2.[System.Convert.ToInt32(v3)]
        let v8 : uint64 = v3 * 15UL
        match v6 with
        | US1_0 -> (* jack *)
            v1.[System.Convert.ToInt32(v8)] <- 1.000000f
        | US1_1 -> (* king *)
            let v9 : uint64 = v8 + 1UL
            v1.[System.Convert.ToInt32(v9)] <- 1.000000f
        | US1_2 -> (* queen *)
            let v10 : uint64 = v8 + 2UL
            v1.[System.Convert.ToInt32(v10)] <- 1.000000f
        let v11 : uint64 = v8 + 3UL
        let v12 : uint64 = uint64 v7.LongLength
        let v13 : bool = 4UL < v12
        if v13 then
            failwith<unit> "The given array is too large."
        let v14 : uint64 = 0UL
        method14(v12, v1, v11, v7, v14)
        method13(v0, v1, v2, v5)
and method16 (v0 : US0) : uint64 =
    let v1 : uint64 =
        match v0 with
        | US0_0 -> (* call *)
            0UL
        | US0_1 -> (* fold *)
            1UL
        | US0_2 -> (* raise *)
            2UL
    v1
and method15 (v0 : uint64, v1 : (US0 []), v2 : (uint64 []), v3 : uint64) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : uint64 = v3 + 1UL
        let v6 : US0 = v1.[System.Convert.ToInt32(v3)]
        let v7 : uint64 = method16(v6)
        v2.[System.Convert.ToInt32(v3)] <- v7
        method15(v0, v1, v2, v5)
and method17 (v0 : uint64) : US0 =
    let v1 : bool = v0 < 3UL
    let v2 : bool = v1 = false
    if v2 then
        failwith<unit> "The size of the argument is too large."
    let v3 : bool = v0 < 1UL
    if v3 then
        let v4 : bool = v0 = 0UL
        let v5 : bool = v4 = false
        if v5 then
            failwith<unit> "The unit index should be 0."
        US0_0
    else
        let v7 : bool = v0 < 2UL
        if v7 then
            let v8 : uint64 = v0 - 1UL
            let v9 : bool = v8 = 0UL
            let v10 : bool = v9 = false
            if v10 then
                failwith<unit> "The unit index should be 0."
            US0_1
        else
            if v1 then
                let v12 : uint64 = v0 - 2UL
                let v13 : bool = v12 = 0UL
                let v14 : bool = v13 = false
                if v14 then
                    failwith<unit> "The unit index should be 0."
                US0_2
            else
                failwith<US0> "Unpickling of an union failed."
and method21 (v0 : int32, v1 : int32) : bool =
    v1 = v0
and method22 (v0 : int32, v1 : int32) : struct (int32 * int32) =
    let v2 : bool = v1 > v0
    if v2 then
        struct (v1, v0)
    else
        struct (v0, v1)
and closure3 (v0 : float) struct (v1 : UH0, v2 : float, v3 : (UH0 -> ((US0 []) -> US0)), v4 : UH0, v5 : float) : float =
    v0
and closure4 (v0 : uint8, v1 : (US0 []), v2 : (US0 []), v3 : (US0 []), v4 : int32, v5 : US1, v6 : US1, v7 : uint8, v8 : uint32, v9 : US1, v10 : uint32) struct (v11 : UH0, v12 : float, v13 : (UH0 -> ((US0 []) -> US0)), v14 : UH0, v15 : float) : float =
    let v16 : bool = v0 = 0uy
    if v16 then
        let v17 : ((US0 []) -> US0) = v13 v11
        let v18 : US0 = v17 v1
        let v73 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v18 with
            | US0_0 -> (* call *)
                let v19 : int32 =
                    match v9 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v20 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v21 : int32 =
                    match v6 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v22 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v23 : bool = method21(v20, v19)
                let v25 : bool =
                    if v23 then
                        method21(v22, v21)
                    else
                        false
                let v48 : int32 =
                    if v25 then
                        let v26 : bool = v19 < v21
                        if v26 then
                            -1
                        else
                            let v27 : bool = v19 > v21
                            if v27 then
                                1
                            else
                                0
                    else
                        let v30 : bool = method21(v20, v19)
                        if v30 then
                            1
                        else
                            let v31 : bool = method21(v22, v21)
                            if v31 then
                                -1
                            else
                                let struct (v32 : int32, v33 : int32) = method22(v20, v19)
                                let struct (v34 : int32, v35 : int32) = method22(v22, v21)
                                let v36 : bool = v32 < v34
                                let v39 : int32 =
                                    if v36 then
                                        -1
                                    else
                                        let v37 : bool = v32 > v34
                                        if v37 then
                                            1
                                        else
                                            0
                                let v40 : bool = v39 = 0
                                if v40 then
                                    let v41 : bool = v33 < v35
                                    if v41 then
                                        -1
                                    else
                                        let v42 : bool = v33 > v35
                                        if v42 then
                                            1
                                        else
                                            0
                                else
                                    v39
                let v49 : bool = v48 = 1
                if v49 then
                    let v50 : uint32 = v10 + v8
                    let v51 : float = <float>v50
                    let v52 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v51)
                    v52
                else
                    let v53 : bool = v48 = -1
                    if v53 then
                        let v54 : uint32 = v10 + v8
                        let v55 : float = <float>v54
                        let v56 : bool = v7 = 0uy
                        let v58 : float =
                            if v56 then
                                v55
                            else
                                 -v55
                        let v59 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v58)
                        v59
                    else
                        let v60 : float = <float>0u
                        let v61 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v60)
                        v61
            | US0_1 -> (* fold *)
                let v64 : uint32 = v10 + v8
                let v65 : float = <float>v64
                let v66 : bool = v7 = 0uy
                let v68 : float =
                    if v66 then
                        v65
                    else
                         -v65
                let v69 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v68)
                v69
            | US0_2 -> (* raise *)
                let v70 : int32 = v4 - 1
                let v71 : uint32 = v8 + 4u
                method23(v2, v3, v70, v5, v9, v0, v71, v6, v7, v8)
        v73 struct (v11, v12, v13, v14, v15)
    else
        let v75 : US0 = numpy.random.choice(v1)
        let v132 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v75 with
            | US0_0 -> (* call *)
                let v76 : int32 =
                    match v9 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v77 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v78 : int32 =
                    match v6 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v79 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v80 : bool = method21(v77, v76)
                let v82 : bool =
                    if v80 then
                        method21(v79, v78)
                    else
                        false
                let v105 : int32 =
                    if v82 then
                        let v83 : bool = v76 < v78
                        if v83 then
                            -1
                        else
                            let v84 : bool = v76 > v78
                            if v84 then
                                1
                            else
                                0
                    else
                        let v87 : bool = method21(v77, v76)
                        if v87 then
                            1
                        else
                            let v88 : bool = method21(v79, v78)
                            if v88 then
                                -1
                            else
                                let struct (v89 : int32, v90 : int32) = method22(v77, v76)
                                let struct (v91 : int32, v92 : int32) = method22(v79, v78)
                                let v93 : bool = v89 < v91
                                let v96 : int32 =
                                    if v93 then
                                        -1
                                    else
                                        let v94 : bool = v89 > v91
                                        if v94 then
                                            1
                                        else
                                            0
                                let v97 : bool = v96 = 0
                                if v97 then
                                    let v98 : bool = v90 < v92
                                    if v98 then
                                        -1
                                    else
                                        let v99 : bool = v90 > v92
                                        if v99 then
                                            1
                                        else
                                            0
                                else
                                    v96
                let v106 : bool = v105 = 1
                if v106 then
                    let v107 : uint32 = v10 + v8
                    let v108 : float = <float>v107
                    let v109 : float =  -v108
                    let v110 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v109)
                    v110
                else
                    let v111 : bool = v105 = -1
                    if v111 then
                        let v112 : uint32 = v10 + v8
                        let v113 : float = <float>v112
                        let v114 : bool = v7 = 0uy
                        let v116 : float =
                            if v114 then
                                v113
                            else
                                 -v113
                        let v117 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v116)
                        v117
                    else
                        let v118 : float = <float>0u
                        let v119 : float =  -v118
                        let v120 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v119)
                        v120
            | US0_1 -> (* fold *)
                let v123 : uint32 = v10 + v8
                let v124 : float = <float>v123
                let v125 : bool = v7 = 0uy
                let v127 : float =
                    if v125 then
                        v124
                    else
                         -v124
                let v128 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v127)
                v128
            | US0_2 -> (* raise *)
                let v129 : int32 = v4 - 1
                let v130 : uint32 = v8 + 4u
                method23(v2, v3, v129, v5, v9, v0, v130, v6, v7, v8)
        v132 struct (v11, v12, v13, v14, v15)
and method23 (v0 : (US0 []), v1 : (US0 []), v2 : int32, v3 : US1, v4 : US1, v5 : uint8, v6 : uint32, v7 : US1, v8 : uint8, v9 : uint32) : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
    let v10 : bool = 0 < v2
    let v11 : (US0 []) =
        if v10 then
            v0
        else
            v1
    let v12 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure4(v8, v11, v0, v1, v2, v3, v4, v5, v6, v7, v9)
    v12
and closure2 (v0 : uint8, v1 : (US0 []), v2 : (US0 []), v3 : (US0 []), v4 : int32, v5 : US1, v6 : US1, v7 : uint8, v8 : uint32, v9 : US1) struct (v10 : UH0, v11 : float, v12 : (UH0 -> ((US0 []) -> US0)), v13 : UH0, v14 : float) : float =
    let v15 : bool = v0 = 0uy
    if v15 then
        let v16 : ((US0 []) -> US0) = v12 v10
        let v17 : US0 = v16 v1
        let v72 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v17 with
            | US0_0 -> (* call *)
                let v18 : int32 =
                    match v9 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v19 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v20 : int32 =
                    match v6 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v21 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v22 : bool = method21(v19, v18)
                let v24 : bool =
                    if v22 then
                        method21(v21, v20)
                    else
                        false
                let v47 : int32 =
                    if v24 then
                        let v25 : bool = v18 < v20
                        if v25 then
                            -1
                        else
                            let v26 : bool = v18 > v20
                            if v26 then
                                1
                            else
                                0
                    else
                        let v29 : bool = method21(v19, v18)
                        if v29 then
                            1
                        else
                            let v30 : bool = method21(v21, v20)
                            if v30 then
                                -1
                            else
                                let struct (v31 : int32, v32 : int32) = method22(v19, v18)
                                let struct (v33 : int32, v34 : int32) = method22(v21, v20)
                                let v35 : bool = v31 < v33
                                let v38 : int32 =
                                    if v35 then
                                        -1
                                    else
                                        let v36 : bool = v31 > v33
                                        if v36 then
                                            1
                                        else
                                            0
                                let v39 : bool = v38 = 0
                                if v39 then
                                    let v40 : bool = v32 < v34
                                    if v40 then
                                        -1
                                    else
                                        let v41 : bool = v32 > v34
                                        if v41 then
                                            1
                                        else
                                            0
                                else
                                    v38
                let v48 : bool = v47 = 1
                if v48 then
                    let v49 : uint32 = v8 + v8
                    let v50 : float = <float>v49
                    let v51 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v50)
                    v51
                else
                    let v52 : bool = v47 = -1
                    if v52 then
                        let v53 : uint32 = v8 + v8
                        let v54 : float = <float>v53
                        let v55 : bool = v7 = 0uy
                        let v57 : float =
                            if v55 then
                                v54
                            else
                                 -v54
                        let v58 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v57)
                        v58
                    else
                        let v59 : float = <float>0u
                        let v60 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v59)
                        v60
            | US0_1 -> (* fold *)
                let v63 : uint32 = v8 + v8
                let v64 : float = <float>v63
                let v65 : bool = v7 = 0uy
                let v67 : float =
                    if v65 then
                        v64
                    else
                         -v64
                let v68 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v67)
                v68
            | US0_2 -> (* raise *)
                let v69 : int32 = v4 - 1
                let v70 : uint32 = v8 + 4u
                method23(v2, v3, v69, v5, v9, v0, v70, v6, v7, v8)
        v72 struct (v10, v11, v12, v13, v14)
    else
        let v74 : US0 = numpy.random.choice(v1)
        let v131 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v74 with
            | US0_0 -> (* call *)
                let v75 : int32 =
                    match v9 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v76 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v77 : int32 =
                    match v6 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v78 : int32 =
                    match v5 with
                    | US1_0 -> (* jack *)
                        0
                    | US1_1 -> (* king *)
                        2
                    | US1_2 -> (* queen *)
                        1
                let v79 : bool = method21(v76, v75)
                let v81 : bool =
                    if v79 then
                        method21(v78, v77)
                    else
                        false
                let v104 : int32 =
                    if v81 then
                        let v82 : bool = v75 < v77
                        if v82 then
                            -1
                        else
                            let v83 : bool = v75 > v77
                            if v83 then
                                1
                            else
                                0
                    else
                        let v86 : bool = method21(v76, v75)
                        if v86 then
                            1
                        else
                            let v87 : bool = method21(v78, v77)
                            if v87 then
                                -1
                            else
                                let struct (v88 : int32, v89 : int32) = method22(v76, v75)
                                let struct (v90 : int32, v91 : int32) = method22(v78, v77)
                                let v92 : bool = v88 < v90
                                let v95 : int32 =
                                    if v92 then
                                        -1
                                    else
                                        let v93 : bool = v88 > v90
                                        if v93 then
                                            1
                                        else
                                            0
                                let v96 : bool = v95 = 0
                                if v96 then
                                    let v97 : bool = v89 < v91
                                    if v97 then
                                        -1
                                    else
                                        let v98 : bool = v89 > v91
                                        if v98 then
                                            1
                                        else
                                            0
                                else
                                    v95
                let v105 : bool = v104 = 1
                if v105 then
                    let v106 : uint32 = v8 + v8
                    let v107 : float = <float>v106
                    let v108 : float =  -v107
                    let v109 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v108)
                    v109
                else
                    let v110 : bool = v104 = -1
                    if v110 then
                        let v111 : uint32 = v8 + v8
                        let v112 : float = <float>v111
                        let v113 : bool = v7 = 0uy
                        let v115 : float =
                            if v113 then
                                v112
                            else
                                 -v112
                        let v116 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v115)
                        v116
                    else
                        let v117 : float = <float>0u
                        let v118 : float =  -v117
                        let v119 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v118)
                        v119
            | US0_1 -> (* fold *)
                let v122 : uint32 = v8 + v8
                let v123 : float = <float>v122
                let v124 : bool = v7 = 0uy
                let v126 : float =
                    if v124 then
                        v123
                    else
                         -v123
                let v127 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v126)
                v127
            | US0_2 -> (* raise *)
                let v128 : int32 = v4 - 1
                let v129 : uint32 = v8 + 4u
                method23(v2, v3, v128, v5, v9, v0, v129, v6, v7, v8)
        v131 struct (v10, v11, v12, v13, v14)
and method20 (v0 : (US0 []), v1 : (US0 []), v2 : int32, v3 : US1, v4 : US1, v5 : uint8, v6 : uint32, v7 : US1, v8 : uint8) : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
    let v9 : bool = 0 < v2
    let v10 : (US0 []) =
        if v9 then
            v0
        else
            v1
    let v11 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure2(v8, v10, v0, v1, v2, v3, v4, v5, v6, v7)
    v11
and closure1 (v0 : (US1 []), v1 : (US0 []), v2 : (US0 []), v3 : (US0 []), v4 : US1, v5 : uint8, v6 : uint32, v7 : US1, v8 : uint8) struct (v9 : UH0, v10 : float, v11 : (UH0 -> ((US0 []) -> US0)), v12 : UH0, v13 : float) : float =
    let v14 : US1 = numpy.random.choice(v0)
    let v15 : bool = v8 = 0uy
    if v15 then
        let v16 : US2 = US2_1(v14)
        let v17 : UH0 = UH0_0(v16, v9)
        let v18 : ((US0 []) -> US0) = v11 v17
        let v19 : US0 = v18 v1
        let v26 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v19 with
            | US0_0 -> (* call *)
                let v20 : int32 = 2
                method20(v2, v3, v20, v14, v7, v8, v6, v4, v5)
            | US0_1 -> (* fold *)
                failwith<(struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float)> "impossible"
            | US0_2 -> (* raise *)
                let v23 : int32 = 1
                let v24 : uint32 = v6 + 4u
                method23(v2, v3, v23, v14, v7, v8, v24, v4, v5, v6)
        let v27 : US2 = US2_1(v14)
        let v28 : UH0 = UH0_0(v27, v9)
        let v29 : US2 = US2_1(v14)
        let v30 : UH0 = UH0_0(v29, v12)
        v26 struct (v28, v10, v11, v30, v13)
    else
        let v32 : US0 = numpy.random.choice(v1)
        let v39 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v32 with
            | US0_0 -> (* call *)
                let v33 : int32 = 2
                method20(v2, v3, v33, v14, v7, v8, v6, v4, v5)
            | US0_1 -> (* fold *)
                failwith<(struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float)> "impossible"
            | US0_2 -> (* raise *)
                let v36 : int32 = 1
                let v37 : uint32 = v6 + 4u
                method23(v2, v3, v36, v14, v7, v8, v37, v4, v5, v6)
        let v40 : US2 = US2_1(v14)
        let v41 : UH0 = UH0_0(v40, v9)
        let v42 : US2 = US2_1(v14)
        let v43 : UH0 = UH0_0(v42, v12)
        v39 struct (v41, v10, v11, v43, v13)
and method19 (v0 : (US0 []), v1 : (US0 []), v2 : (US0 []), v3 : (US1 []), v4 : US1, v5 : uint8, v6 : uint32, v7 : US1, v8 : uint8) : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
    let v9 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure1(v3, v0, v1, v2, v4, v5, v6, v7, v8)
    v9
and closure6 (v0 : (US1 []), v1 : (US0 []), v2 : (US0 []), v3 : (US0 []), v4 : US1, v5 : uint8, v6 : uint32, v7 : US1, v8 : uint8, v9 : uint32) struct (v10 : UH0, v11 : float, v12 : (UH0 -> ((US0 []) -> US0)), v13 : UH0, v14 : float) : float =
    let v15 : US1 = numpy.random.choice(v0)
    let v16 : bool = v8 = 0uy
    if v16 then
        let v17 : US2 = US2_1(v15)
        let v18 : UH0 = UH0_0(v17, v10)
        let v19 : ((US0 []) -> US0) = v12 v18
        let v20 : US0 = v19 v1
        let v27 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v20 with
            | US0_0 -> (* call *)
                let v21 : int32 = 2
                method23(v2, v3, v21, v15, v7, v8, v9, v4, v5, v6)
            | US0_1 -> (* fold *)
                failwith<(struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float)> "impossible"
            | US0_2 -> (* raise *)
                let v24 : int32 = 1
                let v25 : uint32 = v6 + 4u
                method23(v2, v3, v24, v15, v7, v8, v25, v4, v5, v6)
        let v28 : US2 = US2_1(v15)
        let v29 : UH0 = UH0_0(v28, v10)
        let v30 : US2 = US2_1(v15)
        let v31 : UH0 = UH0_0(v30, v13)
        v27 struct (v29, v11, v12, v31, v14)
    else
        let v33 : US0 = numpy.random.choice(v1)
        let v40 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v33 with
            | US0_0 -> (* call *)
                let v34 : int32 = 2
                method23(v2, v3, v34, v15, v7, v8, v9, v4, v5, v6)
            | US0_1 -> (* fold *)
                failwith<(struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float)> "impossible"
            | US0_2 -> (* raise *)
                let v37 : int32 = 1
                let v38 : uint32 = v6 + 4u
                method23(v2, v3, v37, v15, v7, v8, v38, v4, v5, v6)
        let v41 : US2 = US2_1(v15)
        let v42 : UH0 = UH0_0(v41, v10)
        let v43 : US2 = US2_1(v15)
        let v44 : UH0 = UH0_0(v43, v13)
        v40 struct (v42, v11, v12, v44, v14)
and method25 (v0 : (US0 []), v1 : (US0 []), v2 : (US0 []), v3 : (US1 []), v4 : US1, v5 : uint8, v6 : uint32, v7 : US1, v8 : uint8, v9 : uint32) : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
    let v10 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure6(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9)
    v10
and closure5 (v0 : uint8, v1 : (US0 []), v2 : (US0 []), v3 : (US0 []), v4 : (US0 []), v2 : (US0 []), v3 : (US0 []), v5 : (US1 []), v6 : int32, v7 : US1, v8 : uint8, v9 : uint32, v10 : US1, v11 : uint32) struct (v12 : UH0, v13 : float, v14 : (UH0 -> ((US0 []) -> US0)), v15 : UH0, v16 : float) : float =
    let v17 : bool = v0 = 0uy
    if v17 then
        let v18 : ((US0 []) -> US0) = v14 v12
        let v19 : US0 = v18 v1
        let v30 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v19 with
            | US0_0 -> (* call *)
                method25(v4, v2, v3, v5, v7, v8, v9, v10, v0, v11)
            | US0_1 -> (* fold *)
                let v21 : uint32 = v11 + v9
                let v22 : float = <float>v21
                let v23 : bool = v8 = 0uy
                let v25 : float =
                    if v23 then
                        v22
                    else
                         -v22
                let v26 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v25)
                v26
            | US0_2 -> (* raise *)
                let v27 : int32 = v6 - 1
                let v28 : uint32 = v9 + 2u
                method24(v2, v3, v4, v5, v27, v10, v0, v28, v7, v8, v9)
        v30 struct (v12, v13, v14, v15, v16)
    else
        let v32 : US0 = numpy.random.choice(v1)
        let v43 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v32 with
            | US0_0 -> (* call *)
                method25(v4, v2, v3, v5, v10, v0, v11, v7, v8, v9)
            | US0_1 -> (* fold *)
                let v34 : uint32 = v11 + v9
                let v35 : float = <float>v34
                let v36 : bool = v8 = 0uy
                let v38 : float =
                    if v36 then
                        v35
                    else
                         -v35
                let v39 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v38)
                v39
            | US0_2 -> (* raise *)
                let v40 : int32 = v6 - 1
                let v41 : uint32 = v9 + 2u
                method24(v2, v3, v4, v5, v40, v10, v0, v41, v7, v8, v9)
        v43 struct (v12, v13, v14, v15, v16)
and method24 (v0 : (US0 []), v1 : (US0 []), v2 : (US0 []), v0 : (US0 []), v1 : (US0 []), v3 : (US1 []), v4 : int32, v5 : US1, v6 : uint8, v7 : uint32, v8 : US1, v9 : uint8, v10 : uint32) : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
    let v11 : bool = 0 < v4
    let v12 : (US0 []) =
        if v11 then
            v0
        else
            v1
    let v13 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure5(v9, v12, v0, v1, v2, v3, v4, v5, v6, v7, v8, v10)
    v13
and closure0 (v0 : uint8, v1 : (US0 []), v2 : (US0 []), v3 : (US0 []), v4 : (US0 []), v5 : (US1 []), v6 : int32, v7 : US1, v8 : uint8, v9 : uint32, v10 : US1) struct (v11 : UH0, v12 : float, v13 : (UH0 -> ((US0 []) -> US0)), v14 : UH0, v15 : float) : float =
    let v16 : bool = v0 = 0uy
    if v16 then
        let v17 : ((US0 []) -> US0) = v13 v11
        let v18 : US0 = v17 v1
        let v29 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v18 with
            | US0_0 -> (* call *)
                method19(v4, v2, v3, v5, v7, v8, v9, v10, v0)
            | US0_1 -> (* fold *)
                let v20 : uint32 = v9 + v9
                let v21 : float = <float>v20
                let v22 : bool = v8 = 0uy
                let v24 : float =
                    if v22 then
                        v21
                    else
                         -v21
                let v25 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v24)
                v25
            | US0_2 -> (* raise *)
                let v26 : int32 = v6 - 1
                let v27 : uint32 = v9 + 2u
                method24(v2, v3, v4, v5, v26, v10, v0, v27, v7, v8, v9)
        v29 struct (v11, v12, v13, v14, v15)
    else
        let v31 : US0 = numpy.random.choice(v1)
        let v42 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
            match v31 with
            | US0_0 -> (* call *)
                method19(v4, v2, v3, v5, v10, v0, v9, v7, v8)
            | US0_1 -> (* fold *)
                let v33 : uint32 = v9 + v9
                let v34 : float = <float>v33
                let v35 : bool = v8 = 0uy
                let v37 : float =
                    if v35 then
                        v34
                    else
                         -v34
                let v38 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure3(v37)
                v38
            | US0_2 -> (* raise *)
                let v39 : int32 = v6 - 1
                let v40 : uint32 = v9 + 2u
                method24(v2, v3, v4, v5, v39, v10, v0, v40, v7, v8, v9)
        v42 struct (v11, v12, v13, v14, v15)
and method18 (v0 : (US0 []), v1 : (US0 []), v2 : (US0 []), v3 : (US1 []), v4 : int32, v5 : US1, v6 : uint8, v7 : uint32, v8 : US1, v9 : uint8) : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
    let v10 : bool = 0 < v4
    let v11 : (US0 []) =
        if v10 then
            v0
        else
            v1
    let v12 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) = closure0(v9, v11, v0, v1, v2, v3, v4, v5, v6, v7, v8)
    v12
and closure8 (v0 : object, v1 : (struct (US1 * (US0 [])) [])) (v2 : (US0 [])) : US0 =
    let v3 : (float32 []) = Array.zeroCreate<float32> (System.Convert.ToInt32(30UL))
    let v4 : uint64 = uint64 v3.LongLength
    let v5 : uint64 = 0UL
    method12(v4, v3, v5)
    let v6 : uint64 = uint64 v1.LongLength
    let v7 : bool = 2UL < v6
    if v7 then
        failwith<unit> "The given array is too large."
    let v8 : uint64 = 0UL
    method13(v6, v3, v1, v8)
    let v9 : object = torch.from_numpy(v3)
    let v10 : object = v0.forward(v9)
    let v11 : uint64 = uint64 v2.LongLength
    let v12 : (uint64 []) = Array.zeroCreate<uint64> (System.Convert.ToInt32(v11))
    let v13 : uint64 = 0UL
    method15(v11, v2, v12, v13)
    let v14 : object = v10[v12]
    let v15 : object = torch.nn.functional.Softmax(v14)
    let v16 : object = torch.distributions.Categorical(probs=v15)
    let v17 : object = v16.sample()
    let v18 : uint64 = v17.item()
    let v19 : uint64 = v12.[System.Convert.ToInt32(v18)]
    method17(v19)
and closure7 (v0 : object) (v1 : UH0) : ((US0 []) -> US0) =
    let v2 : (struct (US1 * (US0 [])) []) = method3(v1)
    closure8(v0, v2)
and method1 (v0 : object) : float =
    let v1 : US0 = US0_0
    let v2 : US0 = US0_2
    let v3 : (US0 []) = [|v1; v2|]
    let v4 : US0 = US0_1
    let v5 : US0 = US0_0
    let v6 : US0 = US0_2
    let v7 : (US0 []) = [|v4; v5; v6|]
    let v8 : US0 = US0_1
    let v9 : US0 = US0_0
    let v10 : (US0 []) = [|v8; v9|]
    let v11 : US1 = US1_1
    let v12 : US1 = US1_2
    let v13 : US1 = US1_0
    let v14 : US1 = US1_1
    let v15 : US1 = US1_2
    let v16 : US1 = US1_0
    let v17 : (US1 []) = [|v11; v12; v13; v14; v15; v16|]
    let v18 : uint64 = uint64 v17.LongLength
    let v19 : uint64 = numpy.random.randint(0,v18)
    let v20 : US1 = v17.[System.Convert.ToInt32(v19)]
    let v21 : uint64 = v18 - 1UL
    let v22 : (US1 []) = Array.zeroCreate<US1> (System.Convert.ToInt32(v21))
    let v23 : uint64 = 0UL
    method2(v21, v19, v17, v22, v23)
    let v24 : uint64 = uint64 v22.LongLength
    let v25 : uint64 = numpy.random.randint(0,v24)
    let v26 : US1 = v22.[System.Convert.ToInt32(v25)]
    let v27 : uint64 = v24 - 1UL
    let v28 : (US1 []) = Array.zeroCreate<US1> (System.Convert.ToInt32(v27))
    let v29 : uint64 = 0UL
    method2(v27, v25, v22, v28, v29)
    let v30 : US2 = US2_1(v20)
    let v31 : UH0 = UH0_1
    let v32 : UH0 = UH0_0(v30, v31)
    let v33 : (struct (US1 * (US0 [])) []) = method3(v32)
    let v34 : (float32 []) = Array.zeroCreate<float32> (System.Convert.ToInt32(30UL))
    let v35 : uint64 = uint64 v34.LongLength
    let v36 : uint64 = 0UL
    method12(v35, v34, v36)
    let v37 : uint64 = uint64 v33.LongLength
    let v38 : bool = 2UL < v37
    if v38 then
        failwith<unit> "The given array is too large."
    let v39 : uint64 = 0UL
    method13(v37, v34, v33, v39)
    let v40 : object = torch.from_numpy(v34)
    let v41 : object = v0.forward(v40)
    let v42 : uint64 = uint64 v3.LongLength
    let v43 : (uint64 []) = Array.zeroCreate<uint64> (System.Convert.ToInt32(v42))
    let v44 : uint64 = 0UL
    method15(v42, v3, v43, v44)
    let v45 : object = v41[v43]
    let v46 : object = torch.nn.functional.Softmax(v45)
    let v47 : object = torch.distributions.Categorical(probs=v46)
    let v48 : object = v47.sample()
    let v49 : uint64 = v48.item()
    let v50 : uint64 = v43.[System.Convert.ToInt32(v49)]
    let v51 : US0 = method17(v50)
    let v64 : (struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float) =
        match v51 with
        | US0_0 -> (* call *)
            let v52 : int32 = 2
            let v53 : uint8 = 1uy
            let v54 : uint32 = 1u
            let v55 : uint8 = 0uy
            method18(v7, v10, v3, v28, v52, v20, v55, v54, v26, v53)
        | US0_1 -> (* fold *)
            failwith<(struct (UH0 * float * (UH0 -> ((US0 []) -> US0)) * UH0 * float) -> float)> "impossible"
        | US0_2 -> (* raise *)
            let v58 : int32 = 1
            let v59 : uint8 = 1uy
            let v60 : uint32 = 1u
            let v61 : uint8 = 0uy
            let v62 : uint32 = 3u
            method24(v7, v10, v3, v28, v58, v20, v61, v62, v26, v59, v60)
    let v65 : US2 = US2_1(v20)
    let v66 : UH0 = UH0_1
    let v67 : UH0 = UH0_0(v65, v66)
    let v68 : (UH0 -> ((US0 []) -> US0)) = closure7(v0)
    let v69 : US2 = US2_1(v26)
    let v70 : UH0 = UH0_1
    let v71 : UH0 = UH0_0(v69, v70)
    v64 struct (v67, 1.000000, v68, v71, 1.000000)
and method0 (v0 : object, v1 : uint32) : unit =
    let v2 : bool = v1 < 10u
    if v2 then
        let v3 : uint32 = v1 + 1u
        let v4 : float = method1(v0)
        print("Reward for player one at iteration ", v1, " is ", v4)
        method0(v0, v3)
let v0 : object = nets.leduc(30UL,64UL,3UL)
let v1 : uint32 = 0u
method0(v0, v1)
