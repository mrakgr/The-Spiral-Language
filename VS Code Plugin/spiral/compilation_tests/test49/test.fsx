type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2
and [<Struct>] US1 =
    | US1_0 of f0_0 : int32
    | US1_1 of f1_0 : float
and UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
let rec method0 (v0 : UH0, v1 : UH0) : US0 =
    match v1, v0 with
    | UH0_0(v2, v3), UH0_0(v4, v5) -> (* cons_ *)
        let v6 : bool = v2 < v4
        let v7 : US0 =
            if v6 then
                US0_2
            else
                let v7 : bool = v2 > v4
                if v7 then
                    US0_1
                else
                    US0_0
        let v8 : bool =
            match v7 with
            | US0_0 -> (* eQ *)
                true
            | US0_1 -> (* gT *)
                false
            | US0_2 -> (* lT *)
                false
        if v8 then
            method0(v5, v3)
        else
            v7
    | UH0_1, UH0_1 -> (* nil *)
        US0_0
    | _ ->
        let v2 : int32 = (fst (Reflection.FSharpValue.GetUnionFields(v1, typeof<UH0>))).Tag
        let v3 : int32 = (fst (Reflection.FSharpValue.GetUnionFields(v0, typeof<UH0>))).Tag
        let v4 : bool = v2 < v3
        if v4 then
            US0_2
        else
            let v5 : bool = v2 > v3
            if v5 then
                US0_1
            else
                US0_0
// Union test
// Static, Static
let v0 : US0 = US0_2
// Dyn, Static
let v1 : int32 = 1
let v2 : US1 = US1_0(v1)
let v3 : US0 =
    match v2 with
    | US1_1(v3) -> (* b_ *)
        let v4 : bool = v3 < 3.000000
        if v4 then
            v0
        else
            let v5 : bool = v3 > 3.000000
            if v5 then
                US0_1
            else
                US0_0
    | _ ->
        let v3 : int32 = (fst (Reflection.FSharpValue.GetUnionFields(v2, typeof<US1>))).Tag
        let v4 : bool = v3 < 1
        if v4 then
            v0
        else
            let v5 : bool = v3 > 1
            if v5 then
                US0_1
            else
                US0_0
// Static, Dyn
let v4 : float = 3.000000
let v5 : US1 = US1_1(v4)
let v6 : US0 =
    match v5 with
    | US1_0(v6) -> (* a_ *)
        let v7 : bool = 1 < v6
        if v7 then
            v0
        else
            let v8 : bool = 1 > v6
            if v8 then
                US0_1
            else
                US0_0
    | _ ->
        let v6 : int32 = (fst (Reflection.FSharpValue.GetUnionFields(v5, typeof<US1>))).Tag
        let v7 : bool = 0 < v6
        if v7 then
            v0
        else
            let v8 : bool = 0 > v6
            if v8 then
                US0_1
            else
                US0_0
// Dyn, Dyn
let v7 : int32 = 1
let v8 : US1 = US1_0(v7)
let v9 : float = 3.000000
let v10 : US1 = US1_1(v9)
let v11 : US0 =
    match v8, v10 with
    | US1_0(v11), US1_0(v12) -> (* a_ *)
        let v13 : bool = v11 < v12
        if v13 then
            v0
        else
            let v14 : bool = v11 > v12
            if v14 then
                US0_1
            else
                US0_0
    | US1_1(v11), US1_1(v12) -> (* b_ *)
        let v13 : bool = v11 < v12
        if v13 then
            v0
        else
            let v14 : bool = v11 > v12
            if v14 then
                US0_1
            else
                US0_0
    | _ ->
        let v11 : int32 = (fst (Reflection.FSharpValue.GetUnionFields(v8, typeof<US1>))).Tag
        let v12 : int32 = (fst (Reflection.FSharpValue.GetUnionFields(v10, typeof<US1>))).Tag
        let v13 : bool = v11 < v12
        if v13 then
            v0
        else
            let v14 : bool = v11 > v12
            if v14 then
                US0_1
            else
                US0_0
// Union rec test
let v12 : int32 = 3
let v13 : UH0 = UH0_1
let v14 : UH0 = UH0_0(v12, v13)
let v15 : int32 = 2
let v16 : int32 = 3
let v17 : UH0 = UH0_0(v16, v13)
let v18 : UH0 = UH0_0(v15, v17)
let v19 : US0 =
    match v18 with
    | UH0_0(v19, v20) -> (* cons_ *)
        let v21 : bool = 2 < v19
        let v22 : US0 =
            if v21 then
                v0
            else
                let v22 : bool = 2 > v19
                if v22 then
                    US0_1
                else
                    US0_0
        let v23 : bool =
            match v22 with
            | US0_0 -> (* eQ *)
                true
            | US0_1 -> (* gT *)
                false
            | US0_2 -> (* lT *)
                false
        if v23 then
            method0(v20, v14)
        else
            v22
    | _ ->
        let v19 : int32 = (fst (Reflection.FSharpValue.GetUnionFields(v18, typeof<UH0>))).Tag
        let v20 : bool = 0 < v19
        if v20 then
            v0
        else
            let v21 : bool = 0 > v19
            if v21 then
                US0_1
            else
                US0_0
()
