type UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
let rec method0 (v0 : UH0, v1 : int32) : int32 =
    match v0 with
    | UH0_0(v2, v3) -> (* Cons *)
        let v4 : int32 = v1 + v2
        method0(v3, v4)
    | UH0_1 -> (* Nil *)
        v1
let v0 : int32 = 4
let v1 : int32 = 5
let v2 : int32 = 6
let v3 : UH0 = UH0_1
let v4 : UH0 = UH0_0(v2, v3)
let v5 : UH0 = UH0_0(v1, v4)
let v6 : UH0 = UH0_0(v0, v5)
let v7 : int32 = 6
method0(v6, v7)
