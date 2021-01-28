type UH0 =
    | UH0_0 of UH0 * UH0
    | UH0_1 of UH0 * UH0
    | UH0_2 of float32
let rec method0 (v0 : UH0) : float32 =
    match v0 with
    | UH0_0(v1, v2) -> (* add_ *)
        let v3 : float32 = method0(v1)
        let v4 : float32 = method0(v2)
        v3 + v4
    | UH0_1(v6, v7) -> (* mult_ *)
        let v8 : float32 = method0(v6)
        let v9 : float32 = method0(v7)
        v8 * v9
    | UH0_2(v11) -> (* v_ *)
        v11
// static
let v0 : float32 = 21.000000f
// dynamic
let v1 : float32 = 1.000000f
let v2 : UH0 = UH0_2(v1)
let v3 : float32 = 2.000000f
let v4 : UH0 = UH0_2(v3)
let v5 : UH0 = UH0_0(v2, v4)
let v6 : float32 = 3.000000f
let v7 : UH0 = UH0_2(v6)
let v8 : float32 = 4.000000f
let v9 : UH0 = UH0_2(v8)
let v10 : UH0 = UH0_0(v7, v9)
let v11 : UH0 = UH0_1(v5, v10)
let v12 : float32 = method0(v11)
v12 * 2.000000f
