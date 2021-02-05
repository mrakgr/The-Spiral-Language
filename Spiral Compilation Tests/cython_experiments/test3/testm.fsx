type UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
let rec method1 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_0(v2, v3) -> (* cons_ *)
        let v4 : UH0 = UH0_0(v2, v0)
        method1(v4, v3)
    | UH0_1 -> (* nil *)
        v0
and method0 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0(v1, v2) -> (* cons_ *)
        let v3 : UH0 = UH0_0(v1, v0)
        method1(v3, v2)
    | UH0_1 -> (* nil *)
        v0
let v0 : UH0 = UH0_1
method0(v0)
