type [<Struct>] US0 =
    | US0_0
    | US0_1
let rec method0 () : struct (US0 * US0 * US0 * US0) =
    let v0 : US0 = US0_0
    struct (v0, v0, v0, v0)
and method1 () : int32 =
    1
and method2 () : int32 =
    2
and method3 () : int32 =
    3
and method4 () : int32 =
    4
let struct (v0 : US0, v1 : US0, v2 : US0, v3 : US0) = method0()
match v0 with
| US0_0 -> (* a *)
    match v1 with
    | US0_0 -> (* a *)
        method1()
    | US0_1 -> (* b *)
        match v2 with
        | US0_0 -> (* a *)
            match v3 with
            | US0_0 -> (* a *)
                method2()
            | US0_1 -> (* b *)
                method3()
        | US0_1 -> (* b *)
            method4()
| US0_1 -> (* b *)
    match v2 with
    | US0_0 -> (* a *)
        match v3 with
        | US0_0 -> (* a *)
            method2()
        | US0_1 -> (* b *)
            method4()
    | US0_1 -> (* b *)
        method4()
