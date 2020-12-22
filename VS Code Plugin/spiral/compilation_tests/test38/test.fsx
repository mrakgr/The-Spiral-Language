type [<Struct>] US0 =
    | US0_0
    | US0_1 of int32
let rec closure0 (v0 : int32) (v1 : US0) : int32 =
    match v1 with
    | US0_0 -> (* none *)
        v0
    | US0_1(v2) -> (* some_ *)
        v2
let v0 : int32 = 0
closure0(v0)
