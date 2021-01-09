type UH0 =
    | UH0_0 of char * int32 * string * UH0
    | UH0_1
and Mut0 = {mutable l0 : int32}
let rec method1 (v0 : UH0) : int32 =
    match v0 with
    | UH0_0(v1, v2, v3, v4) -> (* cons_ *)
        let v5 : int32 = v3.Length
        let v6 : int32 = 2 * v5
        let v7 : int32 = 4 + v6
        let v8 : int32 = v7 + 2
        let v9 : int32 = 4 + v8
        let v10 : int32 = method1(v4)
        let v11 : int32 = v9 + v10
        4 + v11
    | UH0_1 -> (* nil *)
        4
and method3 (v0 : int32, v1 : (char []), v2 : Mut0, v3 : (uint8 []), v4 : int32) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : int32 = v4 + 1
        let v7 : char = v1.[v4]
        let v8 : int32 = v2.l0
        let v9 : System.Span<uint8> = System.Span(v3,v8,2)
        let v10 : bool = System.BitConverter.TryWriteBytes(v9,v7)
        let v11 : bool = v10 = false
        if v11 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v12 : int32 = v8 + 2
        v2.l0 <- v12
        method3(v0, v1, v2, v3, v6)
    else
        ()
and method2 (v0 : UH0, v1 : Mut0, v2 : (uint8 [])) : unit =
    match v0 with
    | UH0_0(v3, v4, v5, v6) -> (* cons_ *)
        let v7 : int32 = v1.l0
        let v8 : System.Span<uint8> = System.Span(v2,v7,4)
        let v9 : bool = System.BitConverter.TryWriteBytes(v8,0)
        let v10 : bool = v9 = false
        if v10 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v11 : int32 = v7 + 4
        v1.l0 <- v11
        let v12 : int32 = v1.l0
        let v13 : System.Span<uint8> = System.Span(v2,v12,4)
        let v14 : bool = System.BitConverter.TryWriteBytes(v13,v4)
        let v15 : bool = v14 = false
        if v15 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v16 : int32 = v12 + 4
        v1.l0 <- v16
        let v17 : (char []) = v5.ToCharArray()
        let v18 : int32 = v17.Length
        let v19 : int32 = v1.l0
        let v20 : System.Span<uint8> = System.Span(v2,v19,4)
        let v21 : bool = System.BitConverter.TryWriteBytes(v20,v18)
        let v22 : bool = v21 = false
        if v22 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v23 : int32 = v19 + 4
        v1.l0 <- v23
        let v24 : int32 = 0
        method3(v18, v17, v1, v2, v24)
        let v25 : int32 = v1.l0
        let v26 : System.Span<uint8> = System.Span(v2,v25,2)
        let v27 : bool = System.BitConverter.TryWriteBytes(v26,v3)
        let v28 : bool = v27 = false
        if v28 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v29 : int32 = v25 + 2
        v1.l0 <- v29
        method2(v6, v1, v2)
    | UH0_1 -> (* nil *)
        let v3 : int32 = v1.l0
        let v4 : System.Span<uint8> = System.Span(v2,v3,4)
        let v5 : bool = System.BitConverter.TryWriteBytes(v4,1)
        let v6 : bool = v5 = false
        if v6 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v7 : int32 = v3 + 4
        v1.l0 <- v7
and method5 (v0 : int32, v1 : Mut0, v2 : (uint8 []), v3 : (char []), v4 : int32) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : int32 = v4 + 1
        let v7 : int32 = v1.l0
        let v8 : int32 = v7 + 2
        v1.l0 <- v8
        let v9 : char = System.BitConverter.ToChar(v2,v7)
        v3.[v4] <- v9
        method5(v0, v1, v2, v3, v6)
    else
        ()
and method4 (v0 : Mut0, v1 : (uint8 [])) : UH0 =
    let v2 : int32 = v0.l0
    let v3 : int32 = v2 + 4
    v0.l0 <- v3
    let v4 : int32 = System.BitConverter.ToInt32(v1,v2)
    let v5 : bool = 0 = v4
    if v5 then
        let v6 : int32 = v0.l0
        let v7 : int32 = v6 + 4
        v0.l0 <- v7
        let v8 : int32 = System.BitConverter.ToInt32(v1,v6)
        let v9 : int32 = v0.l0
        let v10 : int32 = v9 + 4
        v0.l0 <- v10
        let v11 : int32 = System.BitConverter.ToInt32(v1,v9)
        let v12 : (char []) = Array.zeroCreate<char> v11
        let v13 : int32 = 0
        method5(v11, v0, v1, v12, v13)
        let v14 : string = System.String(v12)
        let v15 : int32 = v0.l0
        let v16 : int32 = v15 + 2
        v0.l0 <- v16
        let v17 : char = System.BitConverter.ToChar(v1,v15)
        let v18 : UH0 = method4(v0, v1)
        UH0_0(v17, v8, v14, v18)
    else
        let v6 : bool = 1 = v4
        if v6 then
            UH0_1
        else
            failwith<UH0> "Invalid tag."
and method6 (v0 : UH0, v1 : UH0) : bool =
    match v1, v0 with
    | UH0_0(v2, v3, v4, v5), UH0_0(v6, v7, v8, v9) -> (* cons_ *)
        let v10 : bool = v2 = v6
        let v11 : bool =
            if v10 then
                let v11 : bool = v3 = v7
                if v11 then
                    v4 = v8
                else
                    false
            else
                false
        if v11 then
            method6(v9, v5)
        else
            false
    | UH0_1, UH0_1 -> (* nil *)
        true
    | _ ->
        false
and method0 () : unit =
    let v0 : int32 = 1
    let v1 : int32 = 2
    let v2 : char = 'z'
    let v3 : int32 = 1
    let v4 : string = "a"
    let v5 : char = 'x'
    let v6 : int32 = 2
    let v7 : string = "s"
    let v8 : UH0 = UH0_1
    let v9 : UH0 = UH0_0(v5, v6, v7, v8)
    let v10 : UH0 = UH0_0(v2, v3, v4, v9)
    let v11 : int32 = method1(v10)
    let v12 : int32 = 4 + v11
    let v13 : int32 = 4 + v12
    let v14 : (uint8 []) = Array.zeroCreate<uint8> v13
    let v15 : Mut0 = {l0 = 0} : Mut0
    let v16 : int32 = v15.l0
    let v17 : System.Span<uint8> = System.Span(v14,v16,4)
    let v18 : bool = System.BitConverter.TryWriteBytes(v17,v0)
    let v19 : bool = v18 = false
    if v19 then
        failwith<unit> "Conversion failed."
    else
        ()
    let v20 : int32 = v16 + 4
    v15.l0 <- v20
    let v21 : int32 = v15.l0
    let v22 : System.Span<uint8> = System.Span(v14,v21,4)
    let v23 : bool = System.BitConverter.TryWriteBytes(v22,v1)
    let v24 : bool = v23 = false
    if v24 then
        failwith<unit> "Conversion failed."
    else
        ()
    let v25 : int32 = v21 + 4
    v15.l0 <- v25
    method2(v10, v15, v14)
    let v26 : int32 = v15.l0
    let v27 : bool = v26 = v13
    let v28 : bool = v27 = false
    if v28 then
        failwith<unit> "The size of the array does not correspond to the amount being pickled. One of the combinators is faulty."
    else
        ()
    let v29 : Mut0 = {l0 = 0} : Mut0
    let v30 : int32 = v29.l0
    let v31 : int32 = v30 + 4
    v29.l0 <- v31
    let v32 : int32 = System.BitConverter.ToInt32(v14,v30)
    let v33 : int32 = v29.l0
    let v34 : int32 = v33 + 4
    v29.l0 <- v34
    let v35 : int32 = System.BitConverter.ToInt32(v14,v33)
    let v36 : UH0 = method4(v29, v14)
    let v37 : int32 = v29.l0
    let v38 : int32 = v14.Length
    let v39 : bool = v37 = v38
    let v40 : bool = v39 = false
    if v40 then
        failwith<unit> "The size of the array does not correspond to the amount being unpickled. One of the combinators is faulty or the data is malformed."
    else
        ()
    let v41 : bool = v0 = v32
    let v42 : bool =
        if v41 then
            let v42 : bool = v1 = v35
            if v42 then
                method6(v36, v10)
            else
                false
        else
            false
    let v43 : bool = v42 = false
    if v43 then
        failwith<unit> "Serialization and deserialization should result in the same result."
    else
        ()
method0()
