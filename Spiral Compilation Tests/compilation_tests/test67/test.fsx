type [<Struct>] US0 =
    | US0_0 of f0_0 : string
    | US0_1 of f1_0 : uint32
let v0 : string = "qwe"
let v1 : US0 = US0_0(v0)
match v1 with
| US0_0(v2) -> (* C1of2 *)
    "a"
| US0_1(v3) -> (* C2of2 *)
    let v4 : uint32 = v3 + 2u
    "b"
