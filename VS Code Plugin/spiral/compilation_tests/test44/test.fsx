type UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
and UH1 =
    | UH1_0 of string * UH1
    | UH1_1
and UH2 =
    | UH2_0 of bool * UH2
    | UH2_1
and UH3 =
    | UH3_0 of int32 * string * bool * UH3
    | UH3_1
and UH4 =
    | UH4_0 of UH3 * UH4
    | UH4_1
let rec method3 (v0 : int32, v1 : string, v2 : UH4, v3 : UH2) : UH4 =
    match v3 with
    | UH2_0(v4, v5) -> (* cons_ *)
        let v6 : UH4 = method3(v0, v1, v2, v5)
        let v7 : UH3 = UH3_1
        let v8 : UH3 = UH3_0(v0, v1, v4, v7)
        let v9 : UH4 = UH4_0(v8, v6)
        v9
    | UH2_1 -> (* nil *)
        v2
and method5 (v0 : UH3, v1 : UH3) : UH3 =
    match v1 with
    | UH3_0(v2, v3, v4, v5) -> (* cons_ *)
        let v6 : UH3 = method5(v0, v5)
        let v7 : UH3 = UH3_0(v2, v3, v4, v6)
        v7
    | UH3_1 -> (* nil *)
        v0
and method4 (v0 : UH3, v1 : UH4) : UH3 =
    match v1 with
    | UH4_0(v2, v3) -> (* cons_ *)
        let v4 : UH3 = method4(v0, v3)
        method5(v4, v2)
    | UH4_1 -> (* nil *)
        v0
and method2 (v0 : UH2, v1 : int32, v2 : UH4, v3 : UH1) : UH4 =
    match v3 with
    | UH1_0(v4, v5) -> (* cons_ *)
        let v6 : UH4 = method2(v0, v1, v2, v5)
        let v7 : UH4 = UH4_1
        let v8 : UH4 = method3(v1, v4, v7, v0)
        let v9 : UH3 = UH3_1
        let v10 : UH3 = method4(v9, v8)
        let v11 : UH4 = UH4_0(v10, v6)
        v11
    | UH1_1 -> (* nil *)
        v2
and method1 (v0 : UH1, v1 : UH2, v2 : UH4, v3 : UH0) : UH4 =
    match v3 with
    | UH0_0(v4, v5) -> (* cons_ *)
        let v6 : UH4 = method1(v0, v1, v2, v5)
        let v7 : UH4 = UH4_1
        let v8 : UH4 = method2(v1, v4, v7, v0)
        let v9 : UH3 = UH3_1
        let v10 : UH3 = method4(v9, v8)
        let v11 : UH4 = UH4_0(v10, v6)
        v11
    | UH0_1 -> (* nil *)
        v2
and method0 (v0 : UH0, v1 : UH1, v2 : UH2) : UH3 =
    let v3 : UH4 = UH4_1
    let v4 : UH4 = method1(v1, v2, v3, v0)
    let v5 : UH3 = UH3_1
    method4(v5, v4)
and method6 (v0 : UH3) : unit =
    match v0 with
    | UH3_0(v1, v2, v3, v4) -> (* cons_ *)
        printfn "%i, %s, %b" v1 v2 v3
        method6(v4)
    | UH3_1 -> (* nil *)
        ()
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = 3
let v3 : UH0 = UH0_1
let v4 : UH0 = UH0_0(v2, v3)
let v5 : UH0 = UH0_0(v1, v4)
let v6 : UH0 = UH0_0(v0, v5)
let v7 : string = "a"
let v8 : string = "b"
let v9 : UH1 = UH1_1
let v10 : UH1 = UH1_0(v8, v9)
let v11 : UH1 = UH1_0(v7, v10)
let v12 : bool = true
let v13 : UH2 = UH2_1
let v14 : UH2 = UH2_0(v12, v13)
let v15 : UH3 = method0(v6, v11, v14)
method6(v15)
