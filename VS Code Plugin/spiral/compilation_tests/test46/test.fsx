type UH0 =
    | UH0_0 of string * UH0
    | UH0_1
and [<Struct>] US0 =
    | US0_0 of f0_0 : UH0
    | US0_1 of f1_0 : int32
and [<Struct>] US1 =
    | US1_0 of f0_0 : UH0
    | US1_1 of f1_0 : char
and [<Struct>] US2 =
    | US2_0 of f0_0 : UH0
    | US2_1
and [<Struct>] US4 =
    | US4_0
    | US4_1
and [<Struct>] US3 =
    | US3_0
    | US3_1 of f1_0 : US4
let rec method0 (v0 : string, v1 : int32, v2 : bool, v3 : int32) : struct (US0 * int32) =
    let v4 : bool = v1 <= 0
    let v5 : bool =
        if v4 then
            let v5 : int32 = v0.Length
            v1 < v5
        else
            false
    let struct (v6 : US1, v7 : int32) =
        if v5 then
            let v6 : char = v0.[v1]
            let v7 : char = System.Char.MaxValue
            let v8 : bool = v6 = v7
            let v9 : bool = v8 <> true
            if v9 then
                let v10 : int32 = v1 + 1
                let v11 : int32 = int '0'
                let v12 : int32 = int v6
                let v13 : bool = v11 <= v12
                let v14 : bool =
                    if v13 then
                        let v14 : int32 = int v6
                        let v15 : int32 = int '9'
                        v14 <= v15
                    else
                        false
                if v14 then
                    let v15 : US1 = US1_1(v6)
                    struct (v15, v10)
                else
                    let v15 : UH0 = UH0_1
                    let v16 : UH0 = UH0_0("digit", v15)
                    let v17 : US1 = US1_0(v16)
                    struct (v17, v10)
            else
                let v10 : UH0 = UH0_1
                let v11 : UH0 = UH0_0("Out of bounds.", v10)
                let v12 : US1 = US1_0(v11)
                struct (v12, v1)
        else
            let v6 : char = System.Char.MaxValue
            let v7 : char = System.Char.MaxValue
            let v8 : bool = v6 = v7
            let v9 : bool = v8 <> true
            if v9 then
                let v10 : char = v0.[v1]
                let v11 : int32 = v1 + 1
                let v12 : int32 = int '0'
                let v13 : int32 = int v10
                let v14 : bool = v12 <= v13
                let v15 : bool =
                    if v14 then
                        let v15 : int32 = int v10
                        let v16 : int32 = int '9'
                        v15 <= v16
                    else
                        false
                if v15 then
                    let v16 : US1 = US1_1(v10)
                    struct (v16, v11)
                else
                    let v16 : UH0 = UH0_1
                    let v17 : UH0 = UH0_0("digit", v16)
                    let v18 : US1 = US1_0(v17)
                    struct (v18, v11)
            else
                let v10 : UH0 = UH0_1
                let v11 : UH0 = UH0_0("Out of bounds.", v10)
                let v12 : US1 = US1_0(v11)
                struct (v12, v1)
    match v6 with
    | US1_0(v8) -> (* error_ *)
        if v2 then
            let v9 : US0 = US0_1(v3)
            struct (v9, v7)
        else
            let v9 : UH0 = UH0_1
            let v10 : UH0 = UH0_0("i32", v9)
            let v11 : US0 = US0_0(v10)
            struct (v11, v7)
    | US1_1(v8) -> (* ok_ *)
        let v9 : int32 = v3 * 10
        let v10 : int32 = int v8
        let v11 : int32 = v9 + v10
        let v12 : bool = v3 <= 214748364
        let v13 : bool =
            if v12 then
                0 <= v11
            else
                false
        if v13 then
            let v14 : bool = true
            method0(v0, v7, v14, v11)
        else
            let v14 : UH0 = UH0_1
            let v15 : UH0 = UH0_0("The number is too large to be parsed as 32 bit int.", v14)
            let v16 : US0 = US0_0(v15)
            struct (v16, v7)
and method1 (v0 : string, v1 : int32) : struct (US2 * int32) =
    let v2 : bool = 0 <= v1
    let v3 : bool =
        if v2 then
            let v3 : int32 = v0.Length
            let v4 : bool = v1 < v3
            if v4 then
                let v5 : char = v0.[v1]
                let v6 : bool = v5 = ' '
                if v6 then
                    true
                else
                    v5 = '\n'
            else
                false
        else
            false
    if v3 then
        let v4 : int32 = v1 + 1
        method1(v0, v4)
    else
        let v4 : US2 = US2_1
        struct (v4, v1)
and method3 (v0 : (US3 []), v1 : int32) : unit =
    let v2 : bool = v1 < 101
    if v2 then
        let v3 : int32 = v1 + 1
        let v4 : US3 = US3_0
        v0.[v1] <- v4
        method3(v0, v3)
    else
        ()
and method4 (v0 : (US3 []), v1 : US4, v2 : US4, v3 : int32) : US4 =
    match v1 with
    | US4_0 -> (* first *)
        let v4 : US3 = v0.[v3]
        match v4 with
        | US3_0 -> (* none *)
            let v5 : bool = v3 >= 2
            let v6 : bool =
                if v5 then
                    let v6 : int32 = v3 - 2
                    let v7 : US4 = method4(v0, v2, v1, v6)
                    match v7 with
                    | US4_0 -> (* first *)
                        true
                    | US4_1 -> (* second *)
                        false
                else
                    false
            let v7 : US4 =
                if v6 then
                    v1
                else
                    let v7 : bool = v3 >= 3
                    let v8 : bool =
                        if v7 then
                            let v8 : int32 = v3 - 3
                            let v9 : US4 = method4(v0, v2, v1, v8)
                            match v9 with
                            | US4_0 -> (* first *)
                                true
                            | US4_1 -> (* second *)
                                false
                        else
                            false
                    if v8 then
                        v1
                    else
                        let v9 : bool = v3 >= 5
                        let v10 : bool =
                            if v9 then
                                let v10 : int32 = v3 - 5
                                let v11 : US4 = method4(v0, v2, v1, v10)
                                match v11 with
                                | US4_0 -> (* first *)
                                    true
                                | US4_1 -> (* second *)
                                    false
                            else
                                false
                        if v10 then
                            v1
                        else
                            v2
            let v8 : US3 = US3_1(v7)
            v0.[v3] <- v8
            v7
        | US3_1(v5) -> (* some_ *)
            v5
    | US4_1 -> (* second *)
        let v4 : bool = v3 >= 2
        let v5 : bool =
            if v4 then
                let v5 : int32 = v3 - 2
                let v6 : US4 = method4(v0, v2, v1, v5)
                match v6 with
                | US4_0 -> (* first *)
                    false
                | US4_1 -> (* second *)
                    true
            else
                false
        if v5 then
            v1
        else
            let v6 : bool = v3 >= 3
            let v7 : bool =
                if v6 then
                    let v7 : int32 = v3 - 3
                    let v8 : US4 = method4(v0, v2, v1, v7)
                    match v8 with
                    | US4_0 -> (* first *)
                        false
                    | US4_1 -> (* second *)
                        true
                else
                    false
            if v7 then
                v1
            else
                let v8 : bool = v3 >= 5
                let v9 : bool =
                    if v8 then
                        let v9 : int32 = v3 - 5
                        let v10 : US4 = method4(v0, v2, v1, v9)
                        match v10 with
                        | US4_0 -> (* first *)
                            false
                        | US4_1 -> (* second *)
                            true
                    else
                        false
                if v9 then
                    v1
                else
                    v2
and closure1 (v0 : string) (v1 : int32) : struct (US2 * int32) =
    let v2 : bool = false
    let v3 : int32 = 0
    let struct (v4 : US0, v5 : int32) = method0(v0, v1, v2, v3)
    let struct (v6 : US0, v7 : int32) =
        match v4 with
        | US0_0(v6) -> (* error_ *)
            let v7 : US0 = US0_0(v6)
            struct (v7, v5)
        | US0_1(v6) -> (* ok_ *)
            let struct (v7 : US2, v8 : int32) = method1(v0, v5)
            match v7 with
            | US2_0(v9) -> (* error_ *)
                let v10 : US0 = US0_0(v9)
                struct (v10, v8)
            | US2_1 -> (* ok_ *)
                let v9 : US0 = US0_1(v6)
                struct (v9, v8)
    match v6 with
    | US0_0(v8) -> (* error_ *)
        let v9 : US2 = US2_0(v8)
        struct (v9, v7)
    | US0_1(v8) -> (* ok_ *)
        let v9 : bool = 100 < v8
        if v9 then
            failwith "The max input has been exceeded."
        else
            ()
        let v10 : (US3 []) = Array.zeroCreate<US3> 101
        let v11 : int32 = 0
        method3(v10, v11)
        let v12 : US4 = US4_0
        let v13 : US4 = US4_1
        let v14 : US4 = method4(v10, v12, v13, v8)
        let v15 : string =
            match v14 with
            | US4_0 -> (* first *)
                "First"
            | US4_1 -> (* second *)
                "Second"
        System.Console.WriteLine(v15)
        let v16 : US2 = US2_1
        struct (v16, v7)
and closure0 () (v0 : string) : (int32 -> struct (US2 * int32)) =
    closure1(v0)
and closure3 () (v0 : int32) : struct (US2 * int32) =
    let v1 : US2 = US2_1
    struct (v1, v0)
and closure2 () (v0 : string) : (int32 -> struct (US2 * int32)) =
    closure3()
and method2 (v0 : int32, v1 : int32) : (string -> (int32 -> struct (US2 * int32))) =
    let v2 : bool = v1 < v0
    if v2 then
        let v3 : (string -> (int32 -> struct (US2 * int32))) = closure0()
        v3
    else
        let v3 : (string -> (int32 -> struct (US2 * int32))) = closure2()
        v3
and method5 (v0 : UH0) : unit =
    match v0 with
    | UH0_0(v1, v2) -> (* cons_ *)
        printfn "%s" v1
        method5(v2)
    | UH0_1 -> (* nil *)
        ()
let v0 : string = "6 1 2 3 4 5 6"
let v1 : int32 = 0
let v2 : bool = false
let v3 : int32 = 0
let struct (v4 : US0, v5 : int32) = method0(v0, v1, v2, v3)
let struct (v6 : US0, v7 : int32) =
    match v4 with
    | US0_0(v6) -> (* error_ *)
        let v7 : US0 = US0_0(v6)
        struct (v7, v5)
    | US0_1(v6) -> (* ok_ *)
        let struct (v7 : US2, v8 : int32) = method1(v0, v5)
        match v7 with
        | US2_0(v9) -> (* error_ *)
            let v10 : US0 = US0_0(v9)
            struct (v10, v8)
        | US2_1 -> (* ok_ *)
            let v9 : US0 = US0_1(v6)
            struct (v9, v8)
let struct (v8 : US2, v9 : int32) =
    match v6 with
    | US0_0(v8) -> (* error_ *)
        let v9 : US2 = US2_0(v8)
        struct (v9, v7)
    | US0_1(v8) -> (* ok_ *)
        let v9 : int32 = 0
        let v10 : (string -> (int32 -> struct (US2 * int32))) = method2(v8, v9)
        let v11 : (int32 -> struct (US2 * int32)) = v10 v0
        v11 v7
match v8 with
| US2_0(v10) -> (* error_ *)
    printfn "Parsing failed at position %i" v9
    printfn "Errors:"
    method5(v10)
| US2_1 -> (* ok_ *)
    ()
