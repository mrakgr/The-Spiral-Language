type UH0 =
    | UH0_0 of int32 * int32 * UH0
    | UH0_1
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = 4
let v3 : int32 = 5
let v4 : int32 = 5
let v5 : int32 = 6
let v6 : UH0 = UH0_1
let v7 : UH0 = UH0_0(v4, v5, v6)
let v8 : UH0 = UH0_0(v2, v3, v7)
let v9 : UH0 = UH0_0(v0, v1, v8)
let struct (v42 : string, v43 : int32) =
    match v9 with
    | UH0_0(v11, v12, v13) -> (* Cons *)
        match v13 with
        | UH0_0(v16, v17, v18) -> (* Cons *)
            match v18 with
            | UH0_0(v23, v24, v25) -> (* Cons *)
                let v26 : int32 = v11 + v12
                let v27 : int32 = v26 + v16
                let v28 : int32 = v27 + v17
                let v29 : int32 = v28 + v23
                let v30 : int32 = v29 + v24
                let v31 : string = "At least three elements."
                struct (v31, v30)
            | UH0_1 -> (* Nil *)
                let v19 : int32 = v11 + v12
                let v20 : int32 = v19 + v16
                let v21 : int32 = v20 + v17
                let v22 : string = "Two elements."
                struct (v22, v21)
        | UH0_1 -> (* Nil *)
            let v14 : int32 = v11 + v12
            let v15 : string = "One element."
            struct (v15, v14)
    | UH0_1 -> (* Nil *)
        let v10 : string = "No elements"
        struct (v10, 0)
printf("%s\n%i\n",v42->ptr,v43)
0
