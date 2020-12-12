type [<Struct>] US0 =
    | US0_0
    | US0_1
let v0 : US0 = US0_0
match v0 with
| US0_0 -> (* a *)
    1
| US0_1 -> (* b *)
    4
