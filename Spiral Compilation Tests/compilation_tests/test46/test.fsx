type UH0 =
    | UH0_0 of string * UH0
    | UH0_1
and [<Struct>] US0 =
    | US0_0 of f0_0 : UH0
    | US0_1 of f1_0 : uint32
and [<Struct>] US1 =
    | US1_0 of f0_0 : UH0
    | US1_1
and [<Struct>] US3 =
    | US3_0
    | US3_1
and [<Struct>] US2 =
    | US2_0
    | US2_1 of f1_0 : US3
and Mut0 = {mutable l0 : uint32}
let rec method0 (v0 : string, v1 : uint32, v2 : bool, v3 : uint32) : struct (US0 * uint32) =
    let v4 : bool = 0u <= v1
    let v7 : bool =
        if v4 then
            let v5 : uint32 = System.Convert.ToUInt32 v0.Length
            let v6 : bool = v1 < v5
            v6
        else
            false
    let struct (v53 : US0, v54 : uint32) =
        if v7 then
            let v8 : char = v0.[int v1]
            let v9 : char = System.Char.MaxValue
            let v10 : bool = v8 = v9
            let v11 : bool = v10 <> true
            if v11 then
                let v12 : uint32 = v1 + 1u
                let v13 : uint32 = uint32 v8 - uint32 '0'
                let v14 : bool = 0u <= v13
                let v16 : bool =
                    if v14 then
                        let v15 : bool = v13 <= 9u
                        v15
                    else
                        false
                if v16 then
                    let v17 : US0 = US0_1(v13)
                    struct (v17, v12)
                else
                    let v18 : string = "digit"
                    let v19 : UH0 = UH0_1
                    let v20 : UH0 = UH0_0(v18, v19)
                    let v21 : US0 = US0_0(v20)
                    struct (v21, v12)
            else
                let v24 : string = "Out of bounds."
                let v25 : UH0 = UH0_1
                let v26 : UH0 = UH0_0(v24, v25)
                let v27 : US0 = US0_0(v26)
                struct (v27, v1)
        else
            let v30 : char = System.Char.MaxValue
            let v31 : char = System.Char.MaxValue
            let v32 : bool = v30 = v31
            let v33 : bool = v32 <> true
            if v33 then
                let v34 : char = v0.[int v1]
                let v35 : uint32 = v1 + 1u
                let v36 : uint32 = uint32 v34 - uint32 '0'
                let v37 : bool = 0u <= v36
                let v39 : bool =
                    if v37 then
                        let v38 : bool = v36 <= 9u
                        v38
                    else
                        false
                if v39 then
                    let v40 : US0 = US0_1(v36)
                    struct (v40, v35)
                else
                    let v41 : string = "digit"
                    let v42 : UH0 = UH0_1
                    let v43 : UH0 = UH0_0(v41, v42)
                    let v44 : US0 = US0_0(v43)
                    struct (v44, v35)
            else
                let v47 : string = "Out of bounds."
                let v48 : UH0 = UH0_1
                let v49 : UH0 = UH0_0(v47, v48)
                let v50 : US0 = US0_0(v49)
                struct (v50, v1)
    match v53 with
    | US0_0(v70) -> (* Error *)
        if v2 then
            let v71 : US0 = US0_1(v3)
            struct (v71, v54)
        else
            let v72 : string = "i32"
            let v73 : UH0 = UH0_1
            let v74 : UH0 = UH0_0(v72, v73)
            let v75 : US0 = US0_0(v74)
            struct (v75, v54)
    | US0_1(v55) -> (* Ok *)
        let v56 : uint32 = v3 * 10u
        let v57 : uint32 = v56 + v55
        let v58 : bool = v3 <= 214748364u
        let v60 : bool =
            if v58 then
                let v59 : bool = 0u <= v57
                v59
            else
                false
        if v60 then
            let v61 : bool = true
            method0(v0, v54, v61, v57)
        else
            let v64 : string = "The number is too large to be parsed as 32 bit int."
            let v65 : UH0 = UH0_1
            let v66 : UH0 = UH0_0(v64, v65)
            let v67 : US0 = US0_0(v66)
            struct (v67, v54)
and method1 (v0 : string, v1 : uint32) : struct (US1 * uint32) =
    let v2 : bool = 0u <= v1
    let v10 : bool =
        if v2 then
            let v3 : uint32 = System.Convert.ToUInt32 v0.Length
            let v4 : bool = v1 < v3
            if v4 then
                let v5 : char = v0.[int v1]
                let v6 : bool = v5 = ' '
                if v6 then
                    true
                else
                    let v7 : bool = v5 = '\n'
                    v7
            else
                false
        else
            false
    if v10 then
        let v11 : uint32 = v1 + 1u
        method1(v0, v11)
    else
        let v14 : US1 = US1_1
        struct (v14, v1)
and method3 (v0 : Mut0) : bool =
    let v1 : uint32 = v0.l0
    let v2 : bool = v1 < 101u
    v2
and method4 (v0 : (US2 []), v1 : US3, v2 : US3, v3 : uint32) : US3 =
    match v1 with
    | US3_0 -> (* First *)
        let v4 : US2 = v0.[int v3]
        match v4 with
        | US2_0 -> (* None *)
            let v5 : bool = v3 >= 2u
            let v10 : bool =
                if v5 then
                    let v6 : uint32 = v3 - 2u
                    let v7 : US3 = method4(v0, v2, v1, v6)
                    match v7 with
                    | US3_0 -> (* First *)
                        true
                    | US3_1 -> (* Second *)
                        false
                else
                    false
            let v25 : US3 =
                if v10 then
                    v1
                else
                    let v11 : bool = v3 >= 3u
                    let v16 : bool =
                        if v11 then
                            let v12 : uint32 = v3 - 3u
                            let v13 : US3 = method4(v0, v2, v1, v12)
                            match v13 with
                            | US3_0 -> (* First *)
                                true
                            | US3_1 -> (* Second *)
                                false
                        else
                            false
                    if v16 then
                        v1
                    else
                        let v17 : bool = v3 >= 5u
                        let v22 : bool =
                            if v17 then
                                let v18 : uint32 = v3 - 5u
                                let v19 : US3 = method4(v0, v2, v1, v18)
                                match v19 with
                                | US3_0 -> (* First *)
                                    true
                                | US3_1 -> (* Second *)
                                    false
                            else
                                false
                        if v22 then
                            v1
                        else
                            v2
            let v26 : US2 = US2_1(v25)
            v0.[int v3] <- v26
            v25
        | US2_1(v27) -> (* Some *)
            v27
    | US3_1 -> (* Second *)
        let v30 : bool = v3 >= 2u
        let v35 : bool =
            if v30 then
                let v31 : uint32 = v3 - 2u
                let v32 : US3 = method4(v0, v2, v1, v31)
                match v32 with
                | US3_0 -> (* First *)
                    false
                | US3_1 -> (* Second *)
                    true
            else
                false
        if v35 then
            v1
        else
            let v36 : bool = v3 >= 3u
            let v41 : bool =
                if v36 then
                    let v37 : uint32 = v3 - 3u
                    let v38 : US3 = method4(v0, v2, v1, v37)
                    match v38 with
                    | US3_0 -> (* First *)
                        false
                    | US3_1 -> (* Second *)
                        true
                else
                    false
            if v41 then
                v1
            else
                let v42 : bool = v3 >= 5u
                let v47 : bool =
                    if v42 then
                        let v43 : uint32 = v3 - 5u
                        let v44 : US3 = method4(v0, v2, v1, v43)
                        match v44 with
                        | US3_0 -> (* First *)
                            false
                        | US3_1 -> (* Second *)
                            true
                    else
                        false
                if v47 then
                    v1
                else
                    v2
and closure1 (v0 : uint32, v1 : uint32, v2 : string) (v3 : uint32) : struct (US1 * uint32) =
    let v4 : bool = false
    let v5 : uint32 = 0u
    let struct (v6 : US0, v7 : uint32) = method0(v2, v3, v4, v5)
    let struct (v22 : US0, v23 : uint32) =
        match v6 with
        | US0_0(v18) -> (* Error *)
            let v19 : US0 = US0_0(v18)
            struct (v19, v7)
        | US0_1(v8) -> (* Ok *)
            let struct (v9 : US1, v10 : uint32) = method1(v2, v7)
            match v9 with
            | US1_0(v12) -> (* Error *)
                let v13 : US0 = US0_0(v12)
                struct (v13, v10)
            | US1_1 -> (* Ok *)
                let v11 : US0 = US0_1(v8)
                struct (v11, v10)
    match v22 with
    | US0_0(v44) -> (* Error *)
        let v45 : US1 = US1_0(v44)
        struct (v45, v23)
    | US0_1(v24) -> (* Ok *)
        let v25 : bool = 100u < v24
        if v25 then
            failwith<unit> "The max input has been exceeded."
        let v26 : (US2 []) = Array.zeroCreate<US2> (System.Convert.ToInt32(101u))
        let v27 : Mut0 = {l0 = 0u} : Mut0
        while method3(v27) do
            let v29 : uint32 = v27.l0
            let v30 : US2 = US2_0
            v26.[int v29] <- v30
            let v31 : uint32 = v29 + 1u
            v27.l0 <- v31
            ()
        let v32 : US3 = US3_0
        let v33 : US3 = US3_1
        let v34 : US3 = method4(v26, v32, v33, v24)
        let v38 : string =
            match v34 with
            | US3_0 -> (* First *)
                let v35 : string = "First"
                v35
            | US3_1 -> (* Second *)
                let v36 : string = "Second"
                v36
        System.Console.WriteLine(v38)
        let v39 : uint32 = v1 + 1u
        let v40 : (string -> (uint32 -> struct (US1 * uint32))) = method2(v0, v39)
        let v41 : (uint32 -> struct (US1 * uint32)) = v40 v2
        let struct (v42 : US1, v43 : uint32) = v41 v23
        struct (v42, v43)
and closure0 (v0 : uint32, v1 : uint32) (v2 : string) : (uint32 -> struct (US1 * uint32)) =
    closure1(v0, v1, v2)
and closure3 () (v0 : uint32) : struct (US1 * uint32) =
    let v1 : US1 = US1_1
    struct (v1, v0)
and closure2 () (v0 : string) : (uint32 -> struct (US1 * uint32)) =
    closure3()
and method2 (v0 : uint32, v1 : uint32) : (string -> (uint32 -> struct (US1 * uint32))) =
    let v2 : bool = v1 < v0
    if v2 then
        let v3 : (string -> (uint32 -> struct (US1 * uint32))) = closure0(v0, v1)
        v3
    else
        let v4 : (string -> (uint32 -> struct (US1 * uint32))) = closure2()
        v4
and method5 (v0 : UH0) : unit =
    match v0 with
    | UH0_0(v1, v2) -> (* Cons *)
        printfn "%s" v1
        method5(v2)
    | UH0_1 -> (* Nil *)
        ()
let v0 : string = "8 1 2 3 4 5 6 7 10"
let v1 : uint32 = 0u
let v2 : bool = false
let v3 : uint32 = 0u
let struct (v4 : US0, v5 : uint32) = method0(v0, v1, v2, v3)
let struct (v20 : US0, v21 : uint32) =
    match v4 with
    | US0_0(v16) -> (* Error *)
        let v17 : US0 = US0_0(v16)
        struct (v17, v5)
    | US0_1(v6) -> (* Ok *)
        let struct (v7 : US1, v8 : uint32) = method1(v0, v5)
        match v7 with
        | US1_0(v10) -> (* Error *)
            let v11 : US0 = US0_0(v10)
            struct (v11, v8)
        | US1_1 -> (* Ok *)
            let v9 : US0 = US0_1(v6)
            struct (v9, v8)
let struct (v32 : US1, v33 : uint32) =
    match v20 with
    | US0_0(v28) -> (* Error *)
        let v29 : US1 = US1_0(v28)
        struct (v29, v21)
    | US0_1(v22) -> (* Ok *)
        let v23 : uint32 = 0u
        let v24 : (string -> (uint32 -> struct (US1 * uint32))) = method2(v22, v23)
        let v25 : (uint32 -> struct (US1 * uint32)) = v24 v0
        let struct (v26 : US1, v27 : uint32) = v25 v21
        struct (v26, v27)
match v32 with
| US1_0(v34) -> (* Error *)
    printfn "Parsing failed at position %i" v33
    printfn "Errors:"
    method5(v34)
| _ ->
    ()
0
