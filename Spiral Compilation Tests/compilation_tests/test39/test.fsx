type [<Struct>] US0 =
    | US0_0
    | US0_1
let v0 : US0 = US0_1
let v1 : US0 = US0_1
let v2 : US0 = US0_1
match v0 with
| US0_0 -> (* A *)
    1
| US0_1 -> (* B *)
    match v1 with
    | US0_0 -> (* A *)
        2
    | US0_1 -> (* B *)
        match v2 with
        | US0_0 -> (* A *)
            3
        | US0_1 -> (* B *)
            4
