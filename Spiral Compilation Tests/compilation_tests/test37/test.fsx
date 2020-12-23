type [<Struct>] US0 =
    | US0_0
    | US0_1 of int64
let v0 : int64 = 3L
let v1 : US0 = US0_1(v0)
match v1 with
| US0_0 -> (* none *)
    0L
| US0_1(v2) -> (* some_ *)
    v2
