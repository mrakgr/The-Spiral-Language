type [<Struct>] US0 =
    | US0_0
    | US0_1
and Mut0 = {mutable l0 : uint64}
and UH0 =
    | UH0_0 of string * UH0
    | UH0_1
and [<Struct>] US1 =
    | US1_0
    | US1_1 of f1_0 : UH0
and Mut1 = {mutable l0 : US1}
and Mut2 = {mutable l0 : uint64; mutable l1 : uint64}
let rec method0 (v0 : uint64, v1 : Mut0) : bool =
    let v2 : uint64 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method3 (v0 : uint64, v1 : Mut2) : bool =
    let v2 : uint64 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method4 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_0(v2, v3) -> (* Cons *)
        let v4 : UH0 = UH0_0(v2, v1)
        method4(v3, v4)
    | UH0_1 -> (* Nil *)
        v1
and method2 (v0 : ((bool []) []), v1 : ((US0 []) []), v2 : Mut1, v3 : (struct (uint64 * uint64 * UH0) [])) : UH0 =
    let v4 : uint64 = System.Convert.ToUInt64 v3.Length
    let v5 : ((struct (uint64 * uint64 * UH0) []) []) = Array.zeroCreate<(struct (uint64 * uint64 * UH0) [])> (System.Convert.ToInt32(v4))
    let v6 : Mut0 = {l0 = 0UL} : Mut0
    while method0(v4, v6) do
        let v8 : uint64 = v6.l0
        let struct (v9 : uint64, v10 : uint64, v11 : UH0) = v3.[int v8]
        let v12 : uint64 = v9 - 1UL
        let v13 : bool = 0UL <= v12
        let v22 : bool =
            if v13 then
                let v14 : uint64 = System.Convert.ToUInt64 v1.Length
                let v15 : bool = v12 < v14
                if v15 then
                    let v16 : (US0 []) = v1.[int v12]
                    let v17 : bool = 0UL <= v10
                    if v17 then
                        let v18 : uint64 = System.Convert.ToUInt64 v16.Length
                        let v19 : bool = v10 < v18
                        v19
                    else
                        false
                else
                    false
            else
                false
        let v26 : bool =
            if v22 then
                let v23 : (bool []) = v0.[int v12]
                let v24 : bool = v23.[int v10]
                let v25 : bool = v24 = false
                v25
            else
                false
        let v34 : bool =
            if v26 then
                let v27 : (US0 []) = v1.[int v12]
                let v28 : US0 = v27.[int v10]
                let v29 : bool =
                    match v28 with
                    | US0_1 -> (* Princess *)
                        true
                    | _ ->
                        false
                if v29 then
                    let v30 : string = "UP"
                    let v31 : UH0 = UH0_0(v30, v11)
                    let v32 : US1 = US1_1(v31)
                    v2.l0 <- v32
                    ()
                let v33 : (bool []) = v0.[int v12]
                v33.[int v10] <- true
                true
            else
                false
        let v35 : uint64 = v9 + 1UL
        let v36 : bool = 0UL <= v35
        let v45 : bool =
            if v36 then
                let v37 : uint64 = System.Convert.ToUInt64 v1.Length
                let v38 : bool = v35 < v37
                if v38 then
                    let v39 : (US0 []) = v1.[int v35]
                    let v40 : bool = 0UL <= v10
                    if v40 then
                        let v41 : uint64 = System.Convert.ToUInt64 v39.Length
                        let v42 : bool = v10 < v41
                        v42
                    else
                        false
                else
                    false
            else
                false
        let v49 : bool =
            if v45 then
                let v46 : (bool []) = v0.[int v35]
                let v47 : bool = v46.[int v10]
                let v48 : bool = v47 = false
                v48
            else
                false
        let v57 : bool =
            if v49 then
                let v50 : (US0 []) = v1.[int v35]
                let v51 : US0 = v50.[int v10]
                let v52 : bool =
                    match v51 with
                    | US0_1 -> (* Princess *)
                        true
                    | _ ->
                        false
                if v52 then
                    let v53 : string = "DOWN"
                    let v54 : UH0 = UH0_0(v53, v11)
                    let v55 : US1 = US1_1(v54)
                    v2.l0 <- v55
                    ()
                let v56 : (bool []) = v0.[int v35]
                v56.[int v10] <- true
                true
            else
                false
        let v58 : uint64 = v10 - 1UL
        let v59 : bool = 0UL <= v9
        let v68 : bool =
            if v59 then
                let v60 : uint64 = System.Convert.ToUInt64 v1.Length
                let v61 : bool = v9 < v60
                if v61 then
                    let v62 : (US0 []) = v1.[int v9]
                    let v63 : bool = 0UL <= v58
                    if v63 then
                        let v64 : uint64 = System.Convert.ToUInt64 v62.Length
                        let v65 : bool = v58 < v64
                        v65
                    else
                        false
                else
                    false
            else
                false
        let v72 : bool =
            if v68 then
                let v69 : (bool []) = v0.[int v9]
                let v70 : bool = v69.[int v58]
                let v71 : bool = v70 = false
                v71
            else
                false
        let v80 : bool =
            if v72 then
                let v73 : (US0 []) = v1.[int v9]
                let v74 : US0 = v73.[int v58]
                let v75 : bool =
                    match v74 with
                    | US0_1 -> (* Princess *)
                        true
                    | _ ->
                        false
                if v75 then
                    let v76 : string = "LEFT"
                    let v77 : UH0 = UH0_0(v76, v11)
                    let v78 : US1 = US1_1(v77)
                    v2.l0 <- v78
                    ()
                let v79 : (bool []) = v0.[int v9]
                v79.[int v58] <- true
                true
            else
                false
        let v81 : uint64 = v10 + 1UL
        let v90 : bool =
            if v59 then
                let v82 : uint64 = System.Convert.ToUInt64 v1.Length
                let v83 : bool = v9 < v82
                if v83 then
                    let v84 : (US0 []) = v1.[int v9]
                    let v85 : bool = 0UL <= v81
                    if v85 then
                        let v86 : uint64 = System.Convert.ToUInt64 v84.Length
                        let v87 : bool = v81 < v86
                        v87
                    else
                        false
                else
                    false
            else
                false
        let v94 : bool =
            if v90 then
                let v91 : (bool []) = v0.[int v9]
                let v92 : bool = v91.[int v81]
                let v93 : bool = v92 = false
                v93
            else
                false
        let v102 : bool =
            if v94 then
                let v95 : (US0 []) = v1.[int v9]
                let v96 : US0 = v95.[int v81]
                let v97 : bool =
                    match v96 with
                    | US0_1 -> (* Princess *)
                        true
                    | _ ->
                        false
                if v97 then
                    let v98 : string = "RIGHT"
                    let v99 : UH0 = UH0_0(v98, v11)
                    let v100 : US1 = US1_1(v99)
                    v2.l0 <- v100
                    ()
                let v101 : (bool []) = v0.[int v9]
                v101.[int v81] <- true
                true
            else
                false
        let v103 : uint64 =
            if v34 then
                1UL
            else
                0UL
        let v104 : uint64 =
            if v57 then
                1UL
            else
                0UL
        let v105 : uint64 = v103 + v104
        let v106 : uint64 =
            if v80 then
                1UL
            else
                0UL
        let v107 : uint64 = v105 + v106
        let v108 : uint64 =
            if v102 then
                1UL
            else
                0UL
        let v109 : uint64 = v107 + v108
        let v110 : (struct (uint64 * uint64 * UH0) []) = Array.zeroCreate<struct (uint64 * uint64 * UH0)> (System.Convert.ToInt32(v109))
        let v113 : uint64 =
            if v34 then
                let v111 : string = "UP"
                let v112 : UH0 = UH0_0(v111, v11)
                v110.[int 0UL] <- struct (v12, v10, v112)
                1UL
            else
                0UL
        let v117 : uint64 =
            if v57 then
                let v114 : string = "DOWN"
                let v115 : UH0 = UH0_0(v114, v11)
                v110.[int v113] <- struct (v35, v10, v115)
                let v116 : uint64 = v113 + 1UL
                v116
            else
                v113
        let v121 : uint64 =
            if v80 then
                let v118 : string = "LEFT"
                let v119 : UH0 = UH0_0(v118, v11)
                v110.[int v117] <- struct (v9, v58, v119)
                let v120 : uint64 = v117 + 1UL
                v120
            else
                v117
        let v125 : uint64 =
            if v102 then
                let v122 : string = "RIGHT"
                let v123 : UH0 = UH0_0(v122, v11)
                v110.[int v121] <- struct (v9, v81, v123)
                let v124 : uint64 = v121 + 1UL
                v124
            else
                v121
        v5.[int v8] <- v110
        let v126 : uint64 = v8 + 1UL
        v6.l0 <- v126
        ()
    let v127 : uint64 = System.Convert.ToUInt64 v5.Length
    let v128 : Mut2 = {l0 = 0UL; l1 = 0UL} : Mut2
    while method3(v127, v128) do
        let v130 : uint64 = v128.l0
        let v131 : uint64 = v128.l1
        let v132 : (struct (uint64 * uint64 * UH0) []) = v5.[int v130]
        let v133 : uint64 = System.Convert.ToUInt64 v132.Length
        let v134 : uint64 = v131 + v133
        let v135 : uint64 = v130 + 1UL
        v128.l0 <- v135
        v128.l1 <- v134
        ()
    let v136 : uint64 = v128.l1
    let v137 : (struct (uint64 * uint64 * UH0) []) = Array.zeroCreate<struct (uint64 * uint64 * UH0)> (System.Convert.ToInt32(v136))
    let v138 : Mut2 = {l0 = 0UL; l1 = 0UL} : Mut2
    while method3(v127, v138) do
        let v140 : uint64 = v138.l0
        let v141 : uint64 = v138.l1
        let v142 : (struct (uint64 * uint64 * UH0) []) = v5.[int v140]
        let v143 : uint64 = System.Convert.ToUInt64 v142.Length
        let v144 : Mut2 = {l0 = 0UL; l1 = v141} : Mut2
        while method3(v143, v144) do
            let v146 : uint64 = v144.l0
            let v147 : uint64 = v144.l1
            let struct (v148 : uint64, v149 : uint64, v150 : UH0) = v142.[int v146]
            v137.[int v147] <- struct (v148, v149, v150)
            let v151 : uint64 = v147 + 1UL
            let v152 : uint64 = v146 + 1UL
            v144.l0 <- v152
            v144.l1 <- v151
            ()
        let v153 : uint64 = v144.l1
        let v154 : uint64 = v140 + 1UL
        v138.l0 <- v154
        v138.l1 <- v153
        ()
    let v155 : uint64 = v138.l1
    let v156 : US1 = v2.l0
    match v156 with
    | US1_0 -> (* None *)
        method2(v0, v1, v2, v137)
    | US1_1(v158) -> (* Some *)
        let v159 : UH0 = UH0_1
        method4(v158, v159)
and method1 (v0 : ((US0 []) []), v1 : uint64, v2 : uint64) : UH0 =
    let v3 : uint64 = System.Convert.ToUInt64 v0.Length
    let v4 : ((bool []) []) = Array.zeroCreate<(bool [])> (System.Convert.ToInt32(v3))
    let v5 : Mut0 = {l0 = 0UL} : Mut0
    while method0(v3, v5) do
        let v7 : uint64 = v5.l0
        let v8 : (US0 []) = v0.[int v7]
        let v9 : uint64 = System.Convert.ToUInt64 v8.Length
        let v10 : (bool []) = Array.zeroCreate<bool> (System.Convert.ToInt32(v9))
        let v11 : Mut0 = {l0 = 0UL} : Mut0
        while method0(v9, v11) do
            let v13 : uint64 = v11.l0
            v10.[int v13] <- false
            let v14 : uint64 = v13 + 1UL
            v11.l0 <- v14
            ()
        v4.[int v7] <- v10
        let v15 : uint64 = v7 + 1UL
        v5.l0 <- v15
        ()
    let v16 : US1 = US1_0
    let v17 : Mut1 = {l0 = v16} : Mut1
    let v18 : (struct (uint64 * uint64 * UH0) []) = Array.zeroCreate<struct (uint64 * uint64 * UH0)> (System.Convert.ToInt32(1UL))
    let v19 : UH0 = UH0_1
    v18.[int 0UL] <- struct (v1, v2, v19)
    method2(v4, v0, v17, v18)
and method5 (v0 : UH0) : unit =
    match v0 with
    | UH0_0(v1, v2) -> (* Cons *)
        print(v1)
        method5(v2)
    | UH0_1 -> (* Nil *)
        ()
let v0 : uint64 = 4UL
let v1 : uint64 = 2UL
let v2 : uint64 = 3UL
print("Initing")
let v3 : ((US0 []) []) = Array.zeroCreate<(US0 [])> (System.Convert.ToInt32(v0))
let v4 : Mut0 = {l0 = 0UL} : Mut0
while method0(v0, v4) do
    let v6 : uint64 = v4.l0
    let v7 : (US0 []) = Array.zeroCreate<US0> (System.Convert.ToInt32(v0))
    let v8 : Mut0 = {l0 = 0UL} : Mut0
    while method0(v0, v8) do
        let v10 : uint64 = v8.l0
        let v11 : bool = v6 = v1
        let v13 : bool =
            if v11 then
                let v12 : bool = v10 = v2
                v12
            else
                false
        let v16 : US0 =
            if v13 then
                US0_1
            else
                US0_0
        v7.[int v10] <- v16
        let v17 : uint64 = v10 + 1UL
        v8.l0 <- v17
        ()
    v3.[int v6] <- v7
    let v18 : uint64 = v6 + 1UL
    v4.l0 <- v18
    ()
print("Starting")
let v19 : uint64 = 0UL
let v20 : uint64 = 0UL
let v21 : UH0 = method1(v3, v19, v20)
print("Printing")
method5(v21)
0
