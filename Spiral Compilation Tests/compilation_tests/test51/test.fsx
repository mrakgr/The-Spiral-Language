type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
    | US0_1 of f1_0 : float
and UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
and UH1 =
    | UH1_0 of float * UH1
    | UH1_1
let rec method0 (v0 : UH0) : int32 =
    match v0 with
    | UH0_0(v1, v2) -> (* cons_ *)
        let v3 : int32 = hash v1
        let v4 : int32 = v3 * 33
        let v5 : int32 = method0(v2)
        v4 + v5
    | UH0_1 -> (* nil *)
        33
and method1 (v0 : UH1) : int32 =
    match v0 with
    | UH1_0(v1, v2) -> (* cons_ *)
        let v3 : int32 = hash v1
        let v4 : int32 = v3 * 33
        let v5 : int32 = method1(v2)
        v4 + v5
    | UH1_1 -> (* nil *)
        33
// Union test
// Static a
let v0 : int32 = 1
// Static b
let v1 : int32 = 1074266145
// Dyn a
let v2 : int32 = 1
let v3 : US0 = US0_0(v2)
let v4 : int32 =
    match v3 with
    | US0_0(v4) -> (* a_ *)
        hash v4
    | US0_1(v4) -> (* b_ *)
        let v5 : int32 = hash v4
        v5 + 33
// Dyn b
let v5 : float = 3.000000
let v6 : US0 = US0_1(v5)
let v7 : int32 =
    match v6 with
    | US0_0(v7) -> (* a_ *)
        hash v7
    | US0_1(v7) -> (* b_ *)
        let v8 : int32 = hash v7
        v8 + 33
// Union rec test
let v8 : int32 = 3
let v9 : UH0 = UH0_1
let v10 : UH0 = UH0_0(v8, v9)
let v11 : float = 2.000000
let v12 : float = 3.000000
let v13 : UH1 = UH1_1
let v14 : UH1 = UH1_0(v12, v13)
let v15 : UH1 = UH1_0(v11, v14)
// a
let v16 : int32 = method0(v10)
let v17 : int32 = 66 + v16
let v18 : int32 = 33 + v17
// b
let v19 : int32 = method1(v15)
let v20 : int32 = 1039138816 + v19
()
