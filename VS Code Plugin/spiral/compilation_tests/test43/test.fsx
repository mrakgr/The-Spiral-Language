type UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
let rec method0 (v0 : int32, v1 : UH0) : int32 =
    match v1 with
    | UH0_0(v2, v3) -> (* cons_ *)
        let v4 : int32 = v0 + v2
        method0(v4, v3)
    | UH0_1 -> (* nil *)
        v0
let v0 : UH0 = UH0_1
let v1 : int32 = 0
method0(v1, v0)
