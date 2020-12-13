type UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
let rec method1 (v0 : int32) : int32 =
    v0
and method0 (v0 : int32, v1 : int32, v2 : UH0) : int32 =
    let v3 : int32 = v0 + v1
    match v2 with
    | UH0_0(v4, v5) -> (* cons_ *)
        method0(v3, v4, v5)
    | UH0_1 -> (* nil *)
        method1(v3)
let v0 : UH0 = UH0_1
let v1 : int32 = 0
match v0 with
| UH0_0(v2, v3) -> (* cons_ *)
    method0(v1, v2, v3)
| UH0_1 -> (* nil *)
    method1(v1)
