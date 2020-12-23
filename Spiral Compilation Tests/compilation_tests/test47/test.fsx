type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
    | US0_1 of f1_0 : float
and UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
let rec method0 (v0 : UH0, v1 : UH0) : bool =
    match v1, v0 with
    | UH0_0(v2, v3), UH0_0(v4, v5) -> (* cons_ *)
        let v6 : bool = v2 = v4
        if v6 then
            method0(v5, v3)
        else
            false
    | UH0_1, UH0_1 -> (* nil *)
        true
    | _ ->
        false
// Union test
// Static, Static
let v0 : bool = false
// Dyn, Static
let v1 : int32 = 1
let v2 : US0 = US0_0(v1)
let v3 : bool =
    match v2 with
    | US0_1(v3) -> (* b_ *)
        v3 = 3.000000
    | _ ->
        false
// Static, Dyn
let v4 : float = 3.000000
let v5 : US0 = US0_1(v4)
let v6 : bool =
    match v5 with
    | US0_0(v6) -> (* a_ *)
        1 = v6
    | _ ->
        false
// Dyn, Dyn
let v7 : int32 = 1
let v8 : US0 = US0_0(v7)
let v9 : float = 3.000000
let v10 : US0 = US0_1(v9)
let v11 : bool =
    match v8, v10 with
    | US0_0(v11), US0_0(v12) -> (* a_ *)
        v11 = v12
    | US0_1(v11), US0_1(v12) -> (* b_ *)
        v11 = v12
    | _ ->
        false
// Union rec test
let v12 : int32 = 3
let v13 : UH0 = UH0_1
let v14 : UH0 = UH0_0(v12, v13)
let v15 : int32 = 2
let v16 : int32 = 3
let v17 : UH0 = UH0_0(v16, v13)
let v18 : UH0 = UH0_0(v15, v17)
let v19 : bool =
    match v18 with
    | UH0_0(v19, v20) -> (* cons_ *)
        let v21 : bool = 2 = v19
        if v21 then
            method0(v20, v14)
        else
            false
    | _ ->
        false
()
