type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
    | US0_1 of f1_0 : int32
and [<Struct>] US1 =
    | US1_0 of f0_0 : float32
    | US1_1 of f1_0 : float32
let rec method0 (v0 : US0) : int32 =
    match v0 with
    | US0_0(v1) -> (* A *)
        v1
    | US0_1(v2) -> (* C *)
        v2
and method1 (v0 : US1) : float32 =
    match v0 with
    | US1_0(v1) -> (* B *)
        v1
    | US1_1(v2) -> (* C *)
        v2
let v0 : int32 = 2
let v1 : US0 = US0_0(v0)
let v2 : int32 = method0(v1)
let v3 : float32 = 3.0f
let v4 : US1 = US1_0(v3)
let v5 : float32 = method1(v4)
()
