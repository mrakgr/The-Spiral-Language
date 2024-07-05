type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
and [<Struct>] US1 =
    | US1_0
let rec method0 (v0 : US0) : unit =
    match v0 with
    | US0_0(v1) -> (* A *)
        ()
and method1 (v0 : US1) : unit =
    match v0 with
    | US1_0 -> (* B *)
        ()
let v0 : int32 = 2
let v1 : US0 = US0_0(v0)
method0(v1)
let v2 : US1 = US1_0
method1(v2)
