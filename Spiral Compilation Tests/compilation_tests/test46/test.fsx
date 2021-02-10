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
let rec method0 (v0 : string, v1 : uint32, v2 : bool, v3 : uint32) : struct (US0 * uint32) =
    let v4 : bool = 0u <= v1
    let v7 : bool =
        if v4 then
            let v5 : uint32 = uint32 v0.Length
            v1 < v5
        else
            false
    let struct (v49 : US0, v50 : uint32) =
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
                        v13 <= 9u
                    else
                        false
                if v16 then
                    let v17 : US0 = US0_1(v13)
                    struct (v17, v12)
                else
                    let v18 : UH0 = UH0_1
                    let v19 : UH0 = UH0_0("digit", v18)
                    let v20 : US0 = US0_0(v19)
                    struct (v20, v12)
            else
                let v23 : UH0 = UH0_1
                let v24 : UH0 = UH0_0("Out of bounds.", v23)
                let v25 : US0 = US0_0(v24)
                struct (v25, v1)
        else
            let v28 : char = System.Char.MaxValue
            let v29 : char = System.Char.MaxValue
            let v30 : bool = v28 = v29
            let v31 : bool = v30 <> true
            if v31 then
                let v32 : char = v0.[int v1]
                let v33 : uint32 = v1 + 1u
                let v34 : uint32 = uint32 v32 - uint32 '0'
                let v35 : bool = 0u <= v34
                let v37 : bool =
                    if v35 then
                        v34 <= 9u
                    else
                        false
                if v37 then
                    let v38 : US0 = US0_1(v34)
                    struct (v38, v33)
                else
                    let v39 : UH0 = UH0_1
                    let v40 : UH0 = UH0_0("digit", v39)
                    let v41 : US0 = US0_0(v40)
                    struct (v41, v33)
            else
                let v44 : UH0 = UH0_1
                let v45 : UH0 = UH0_0("Out of bounds.", v44)
                let v46 : US0 = US0_0(v45)
                struct (v46, v1)
    match v49 with
    | US0_0(v51) -> (* error_ *)
        if v2 then
            let v52 : US0 = US0_1(v3)
            struct (v52, v50)
        else
            let v53 : UH0 = UH0_1
            let v54 : UH0 = UH0_0("i32", v53)
            let v55 : US0 = US0_0(v54)
            struct (v55, v50)
    | US0_1(v58) -> (* ok_ *)
        let v59 : uint32 = v3 * 10u
        let v60 : uint32 = v59 + v58
        let v61 : bool = v3 <= 214748364u
        let v63 : bool =
            if v61 then
                0u <= v60
            else
                false
        if v63 then
            let v64 : bool = true
            method0(v0, v50, v64, v60)
        else
            let v67 : UH0 = UH0_1
            let v68 : UH0 = UH0_0("The number is too large to be parsed as 32 bit int.", v67)
            let v69 : US0 = US0_0(v68)
            struct (v69, v50)
and method1 (v0 : string, v1 : uint32) : struct (US1 * uint32) =
    let v2 : bool = 0u <= v1
    let v10 : bool =
        if v2 then
            let v3 : uint32 = uint32 v0.Length
            let v4 : bool = v1 < v3
            if v4 then
                let v5 : char = v0.[int v1]
                let v6 : bool = v5 = ' '
                if v6 then
                    true
                else
                    v5 = '\n'
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
and method3 (v0 : (US2 []), v1 : uint32) : unit =
    let v2 : bool = v1 < 101u
    if v2 then
        let v3 : uint32 = v1 + 1u
        let v4 : US2 = US2_0
        v0.[int v1] <- v4
        method3(v0, v3)
and method4 (v0 : (US2 []), v1 : US3, v2 : US3, v3 : uint32) : US3 =
    match v1 with
    | US3_0 -> (* first *)
        let v4 : US2 = v0.[int v3]
        match v4 with
        | US2_0 -> (* none *)
            let v5 : bool = v3 >= 2u
            let v9 : bool =
                if v5 then
                    let v6 : uint32 = v3 - 2u
                    let v7 : US3 = method4(v0, v2, v1, v6)
                    match v7 with
                    | US3_0 -> (* first *)
                        true
                    | US3_1 -> (* second *)
                        false
                else
                    false
            let v22 : US3 =
                if v9 then
                    v1
                else
                    let v10 : bool = v3 >= 3u
                    let v14 : bool =
                        if v10 then
                            let v11 : uint32 = v3 - 3u
                            let v12 : US3 = method4(v0, v2, v1, v11)
                            match v12 with
                            | US3_0 -> (* first *)
                                true
                            | US3_1 -> (* second *)
                                false
                        else
                            false
                    if v14 then
                        v1
                    else
                        let v15 : bool = v3 >= 5u
                        let v19 : bool =
                            if v15 then
                                let v16 : uint32 = v3 - 5u
                                let v17 : US3 = method4(v0, v2, v1, v16)
                                match v17 with
                                | US3_0 -> (* first *)
                                    true
                                | US3_1 -> (* second *)
                                    false
                            else
                                false
                        if v19 then
                            v1
                        else
                            v2
            let v23 : US2 = US2_1(v22)
            v0.[int v3] <- v23
            v22
        | US2_1(v24) -> (* some_ *)
            v24
    | US3_1 -> (* second *)
        let v26 : bool = v3 >= 2u
        let v30 : bool =
            if v26 then
                let v27 : uint32 = v3 - 2u
                let v28 : US3 = method4(v0, v2, v1, v27)
                match v28 with
                | US3_0 -> (* first *)
                    false
                | US3_1 -> (* second *)
                    true
            else
                false
        if v30 then
            v1
        else
            let v31 : bool = v3 >= 3u
            let v35 : bool =
                if v31 then
                    let v32 : uint32 = v3 - 3u
                    let v33 : US3 = method4(v0, v2, v1, v32)
                    match v33 with
                    | US3_0 -> (* first *)
                        false
                    | US3_1 -> (* second *)
                        true
                else
                    false
            if v35 then
                v1
            else
                let v36 : bool = v3 >= 5u
                let v40 : bool =
                    if v36 then
                        let v37 : uint32 = v3 - 5u
                        let v38 : US3 = method4(v0, v2, v1, v37)
                        match v38 with
                        | US3_0 -> (* first *)
                            false
                        | US3_1 -> (* second *)
                            true
                    else
                        false
                if v40 then
                    v1
                else
                    v2
and closure1 (v0 : uint32, v1 : uint32, v2 : string) (v3 : uint32) : struct (US1 * uint32) =
    let v4 : bool = false
    let v5 : uint32 = 0u
    let struct (v6 : US0, v7 : uint32) = method0(v2, v3, v4, v5)
    let struct (v18 : US0, v19 : uint32) =
        match v6 with
        | US0_0(v8) -> (* error_ *)
            let v9 : US0 = US0_0(v8)
            struct (v9, v7)
        | US0_1(v10) -> (* ok_ *)
            let struct (v11 : US1, v12 : uint32) = method1(v2, v7)
            match v11 with
            | US1_0(v13) -> (* error_ *)
                let v14 : US0 = US0_0(v13)
                struct (v14, v12)
            | US1_1 -> (* ok_ *)
                let v15 : US0 = US0_1(v10)
                struct (v15, v12)
    match v18 with
    | US0_0(v20) -> (* error_ *)
        let v21 : US1 = US1_0(v20)
        struct (v21, v19)
    | US0_1(v22) -> (* ok_ *)
        let v23 : bool = 100u < v22
        if v23 then
            failwith<unit> "The max input has been exceeded."
        let v24 : (US2 []) = Array.zeroCreate<US2> (int 101u)
        let v25 : uint32 = 0u
        method3(v24, v25)
        let v26 : US3 = US3_0
        let v27 : US3 = US3_1
        let v28 : US3 = method4(v24, v26, v27, v22)
        let v29 : string =
            match v28 with
            | US3_0 -> (* first *)
                "First"
            | US3_1 -> (* second *)
                "Second"
        System.Console.WriteLine(v29)
        let v30 : uint32 = v1 + 1u
        let v31 : (string -> (uint32 -> struct (US1 * uint32))) = method2(v0, v30)
        let v32 : (uint32 -> struct (US1 * uint32)) = v31 v2
        v32 v19
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
    | UH0_0(v1, v2) -> (* cons_ *)
        printfn "%s" v1
        method5(v2)
    | UH0_1 -> (* nil *)
        ()
let v0 : string = "8 1 2 3 4 5 6 7 10"
let v1 : uint32 = 0u
let v2 : bool = false
let v3 : uint32 = 0u
let struct (v4 : US0, v5 : uint32) = method0(v0, v1, v2, v3)
let struct (v16 : US0, v17 : uint32) =
    match v4 with
    | US0_0(v6) -> (* error_ *)
        let v7 : US0 = US0_0(v6)
        struct (v7, v5)
    | US0_1(v8) -> (* ok_ *)
        let struct (v9 : US1, v10 : uint32) = method1(v0, v5)
        match v9 with
        | US1_0(v11) -> (* error_ *)
            let v12 : US0 = US0_0(v11)
            struct (v12, v10)
        | US1_1 -> (* ok_ *)
            let v13 : US0 = US0_1(v8)
            struct (v13, v10)
let struct (v26 : US1, v27 : uint32) =
    match v16 with
    | US0_0(v18) -> (* error_ *)
        let v19 : US1 = US1_0(v18)
        struct (v19, v17)
    | US0_1(v20) -> (* ok_ *)
        let v21 : uint32 = 0u
        let v22 : (string -> (uint32 -> struct (US1 * uint32))) = method2(v20, v21)
        let v23 : (uint32 -> struct (US1 * uint32)) = v22 v0
        v23 v17
match v26 with
| US1_0(v28) -> (* error_ *)
    printfn "Parsing failed at position %i" v27
    printfn "Errors:"
    method5(v28)
| US1_1 -> (* ok_ *)
    ()
