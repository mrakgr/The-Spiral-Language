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
    v2 < v0
and method3 (v0 : uint64, v1 : Mut2) : bool =
    let v2 : uint64 = v1.l0
    v2 < v0
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
                        v10 < v18
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
                v24 = false
            else
                false
        let v33 : bool =
            if v26 then
                let v27 : (US0 []) = v1.[int v12]
                let v28 : US0 = v27.[int v10]
                let v29 : bool =
                    match v28 with
                    | US0_0 -> (* Empty *)
                        false
                    | US0_1 -> (* Princess *)
                        true
                if v29 then
                    let v30 : UH0 = UH0_0("UP", v11)
                    let v31 : US1 = US1_1(v30)
                    v2.l0 <- v31
                let v32 : (bool []) = v0.[int v12]
                v32.[int v10] <- true
                true
            else
                false
        let v34 : uint64 = v9 + 1UL
        let v35 : bool = 0UL <= v34
        let v44 : bool =
            if v35 then
                let v36 : uint64 = System.Convert.ToUInt64 v1.Length
                let v37 : bool = v34 < v36
                if v37 then
                    let v38 : (US0 []) = v1.[int v34]
                    let v39 : bool = 0UL <= v10
                    if v39 then
                        let v40 : uint64 = System.Convert.ToUInt64 v38.Length
                        v10 < v40
                    else
                        false
                else
                    false
            else
                false
        let v48 : bool =
            if v44 then
                let v45 : (bool []) = v0.[int v34]
                let v46 : bool = v45.[int v10]
                v46 = false
            else
                false
        let v55 : bool =
            if v48 then
                let v49 : (US0 []) = v1.[int v34]
                let v50 : US0 = v49.[int v10]
                let v51 : bool =
                    match v50 with
                    | US0_0 -> (* Empty *)
                        false
                    | US0_1 -> (* Princess *)
                        true
                if v51 then
                    let v52 : UH0 = UH0_0("DOWN", v11)
                    let v53 : US1 = US1_1(v52)
                    v2.l0 <- v53
                let v54 : (bool []) = v0.[int v34]
                v54.[int v10] <- true
                true
            else
                false
        let v56 : uint64 = v10 - 1UL
        let v57 : bool = 0UL <= v9
        let v66 : bool =
            if v57 then
                let v58 : uint64 = System.Convert.ToUInt64 v1.Length
                let v59 : bool = v9 < v58
                if v59 then
                    let v60 : (US0 []) = v1.[int v9]
                    let v61 : bool = 0UL <= v56
                    if v61 then
                        let v62 : uint64 = System.Convert.ToUInt64 v60.Length
                        v56 < v62
                    else
                        false
                else
                    false
            else
                false
        let v70 : bool =
            if v66 then
                let v67 : (bool []) = v0.[int v9]
                let v68 : bool = v67.[int v56]
                v68 = false
            else
                false
        let v77 : bool =
            if v70 then
                let v71 : (US0 []) = v1.[int v9]
                let v72 : US0 = v71.[int v56]
                let v73 : bool =
                    match v72 with
                    | US0_0 -> (* Empty *)
                        false
                    | US0_1 -> (* Princess *)
                        true
                if v73 then
                    let v74 : UH0 = UH0_0("LEFT", v11)
                    let v75 : US1 = US1_1(v74)
                    v2.l0 <- v75
                let v76 : (bool []) = v0.[int v9]
                v76.[int v56] <- true
                true
            else
                false
        let v78 : uint64 = v10 + 1UL
        let v87 : bool =
            if v57 then
                let v79 : uint64 = System.Convert.ToUInt64 v1.Length
                let v80 : bool = v9 < v79
                if v80 then
                    let v81 : (US0 []) = v1.[int v9]
                    let v82 : bool = 0UL <= v78
                    if v82 then
                        let v83 : uint64 = System.Convert.ToUInt64 v81.Length
                        v78 < v83
                    else
                        false
                else
                    false
            else
                false
        let v91 : bool =
            if v87 then
                let v88 : (bool []) = v0.[int v9]
                let v89 : bool = v88.[int v78]
                v89 = false
            else
                false
        let v98 : bool =
            if v91 then
                let v92 : (US0 []) = v1.[int v9]
                let v93 : US0 = v92.[int v78]
                let v94 : bool =
                    match v93 with
                    | US0_0 -> (* Empty *)
                        false
                    | US0_1 -> (* Princess *)
                        true
                if v94 then
                    let v95 : UH0 = UH0_0("RIGHT", v11)
                    let v96 : US1 = US1_1(v95)
                    v2.l0 <- v96
                let v97 : (bool []) = v0.[int v9]
                v97.[int v78] <- true
                true
            else
                false
        let v99 : uint64 =
            if v33 then
                1UL
            else
                0UL
        let v100 : uint64 =
            if v55 then
                1UL
            else
                0UL
        let v101 : uint64 = v99 + v100
        let v102 : uint64 =
            if v77 then
                1UL
            else
                0UL
        let v103 : uint64 = v101 + v102
        let v104 : uint64 =
            if v98 then
                1UL
            else
                0UL
        let v105 : uint64 = v103 + v104
        let v106 : (struct (uint64 * uint64 * UH0) []) = Array.zeroCreate<struct (uint64 * uint64 * UH0)> (System.Convert.ToInt32(v105))
        let v108 : uint64 =
            if v33 then
                let v107 : UH0 = UH0_0("UP", v11)
                v106.[int 0UL] <- struct (v12, v10, v107)
                1UL
            else
                0UL
        let v111 : uint64 =
            if v55 then
                let v109 : UH0 = UH0_0("DOWN", v11)
                v106.[int v108] <- struct (v34, v10, v109)
                v108 + 1UL
            else
                v108
        let v114 : uint64 =
            if v77 then
                let v112 : UH0 = UH0_0("LEFT", v11)
                v106.[int v111] <- struct (v9, v56, v112)
                v111 + 1UL
            else
                v111
        let v117 : uint64 =
            if v98 then
                let v115 : UH0 = UH0_0("RIGHT", v11)
                v106.[int v114] <- struct (v9, v78, v115)
                v114 + 1UL
            else
                v114
        v5.[int v8] <- v106
        let v118 : uint64 = v8 + 1UL
        v6.l0 <- v118
    let v119 : uint64 = System.Convert.ToUInt64 v5.Length
    let v120 : Mut2 = {l0 = 0UL; l1 = 0UL} : Mut2
    while method3(v119, v120) do
        let v122 : uint64 = v120.l0
        let v123 : uint64 = v120.l1
        let v124 : (struct (uint64 * uint64 * UH0) []) = v5.[int v122]
        let v125 : uint64 = System.Convert.ToUInt64 v124.Length
        let v126 : uint64 = v123 + v125
        let v127 : uint64 = v122 + 1UL
        v120.l0 <- v127
        v120.l1 <- v126
    let v128 : uint64 = v120.l1
    let v129 : (struct (uint64 * uint64 * UH0) []) = Array.zeroCreate<struct (uint64 * uint64 * UH0)> (System.Convert.ToInt32(v128))
    let v130 : Mut2 = {l0 = 0UL; l1 = 0UL} : Mut2
    while method3(v119, v130) do
        let v132 : uint64 = v130.l0
        let v133 : uint64 = v130.l1
        let v134 : (struct (uint64 * uint64 * UH0) []) = v5.[int v132]
        let v135 : uint64 = System.Convert.ToUInt64 v134.Length
        let v136 : Mut2 = {l0 = 0UL; l1 = v133} : Mut2
        while method3(v135, v136) do
            let v138 : uint64 = v136.l0
            let v139 : uint64 = v136.l1
            let struct (v140 : uint64, v141 : uint64, v142 : UH0) = v134.[int v138]
            v129.[int v139] <- struct (v140, v141, v142)
            let v143 : uint64 = v139 + 1UL
            let v144 : uint64 = v138 + 1UL
            v136.l0 <- v144
            v136.l1 <- v143
        let v145 : uint64 = v136.l1
        let v146 : uint64 = v132 + 1UL
        v130.l0 <- v146
        v130.l1 <- v145
    let v147 : uint64 = v130.l1
    let v148 : US1 = v2.l0
    match v148 with
    | US1_0 -> (* None *)
        method2(v0, v1, v2, v129)
    | US1_1(v150) -> (* Some *)
        let v151 : UH0 = UH0_1
        method4(v150, v151)
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
        v4.[int v7] <- v10
        let v15 : uint64 = v7 + 1UL
        v5.l0 <- v15
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
                v10 = v2
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
    v3.[int v6] <- v7
    let v18 : uint64 = v6 + 1UL
    v4.l0 <- v18
print("Starting")
let v19 : uint64 = 0UL
let v20 : uint64 = 0UL
let v21 : UH0 = method1(v3, v19, v20)
print("Printing")
method5(v21)
