type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
    | US0_1 of f1_0 : bool * f1_1 : int32
and [<Struct>] US1 =
    | US1_0
    | US1_1 of f1_0 : bool * f1_1 : float32
and [<Struct>] US2 =
    | US2_0 of f0_0 : bool * f0_1 : string
and [<Struct>] US3 =
    | US3_0 of f0_0 : bool * f0_1 : uint8
and [<Struct>] US4 =
    | US4_0 of f0_0 : bool * f0_1 : uint8 * f0_2 : bool
    | US4_1 of f1_0 : bool * f1_1 : uint8
let rec method0 (v0 : US0) : unit =
    match v0 with
    | US0_0(v1) -> (* A *)
        ()
    | US0_1(v2, v3) -> (* C *)
        ()
and method1 (v0 : US1) : unit =
    match v0 with
    | US1_0 -> (* B *)
        ()
    | US1_1(v1, v2) -> (* C *)
        ()
and method2 (v0 : US2) : unit =
    match v0 with
    | US2_0(v1, v2) -> (* C *)
        ()
and method3 (v0 : US3) : unit =
    match v0 with
    | US3_0(v1, v2) -> (* C *)
        ()
and method4 (v0 : US4) : unit =
    match v0 with
    | US4_0(v1, v2, v3) -> (* C *)
        ()
    | US4_1(v4, v5) -> (* D *)
        ()
let v0 : int32 = 2
let v1 : US0 = US0_0(v0)
method0(v1)
let v2 : US1 = US1_0
method1(v2)
let v3 : bool = false
let v4 : string = "qwe"
let v5 : US2 = US2_0(v3, v4)
method2(v5)
let v6 : bool = false
let v7 : uint8 = 234uy
let v8 : US3 = US3_0(v6, v7)
method3(v8)
let v9 : bool = false
let v10 : uint8 = 234uy
let v11 : US4 = US4_1(v9, v10)
method4(v11)
