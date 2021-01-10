type UH0 =
    | UH0_0 of int32 * UH0
    | UH0_1
and Mut0 = {mutable l0 : int32}
let rec method1 (v0 : UH0) : int32 =
    let v1 : int32 =
        match v0 with
        | UH0_0(v1, v2) -> (* cons_ *)
            let v3 : int32 = method1(v2)
            4 + v3
        | UH0_1 -> (* nil *)
            0
    4 + v1
and method2 (v0 : UH0, v1 : Mut0, v2 : (uint8 [])) : unit =
    match v0 with
    | UH0_0(v3, v4) -> (* cons_ *)
        let v5 : int32 = v1.l0
        let v6 : System.Span<uint8> = System.Span(v2,v5,4)
        let v7 : bool = System.BitConverter.TryWriteBytes(v6,0)
        let v8 : bool = v7 = false
        if v8 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v9 : int32 = v5 + 4
        v1.l0 <- v9
        let v10 : int32 = v1.l0
        let v11 : System.Span<uint8> = System.Span(v2,v10,4)
        let v12 : bool = System.BitConverter.TryWriteBytes(v11,v3)
        let v13 : bool = v12 = false
        if v13 then
            failwith<unit> "Conversion failed."
        else
            ()
        let v14 : int32 = v10 + 4
        v1.l0 <- v14
        method2(v4, v1, v2)
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
and method3 (v0 : Mut0, v1 : (uint8 [])) : UH0 =
    let v2 : int32 = v0.l0
    let v3 : int32 = v2 + 4
    v0.l0 <- v3
    let v4 : int32 = System.BitConverter.ToInt32(v1,v2)
    match v4 with
    | 0 ->
        let v5 : int32 = v0.l0
        let v6 : int32 = v5 + 4
        v0.l0 <- v6
        let v7 : int32 = System.BitConverter.ToInt32(v1,v5)
        let v8 : UH0 = method3(v0, v1)
        UH0_0(v7, v8)
    | 1 ->
        UH0_1
    | _ ->
        failwith<UH0> "Invalid tag."
and method4 (v0 : UH0, v1 : UH0) : bool =
    match v1, v0 with
    | UH0_0(v2, v3), UH0_0(v4, v5) -> (* cons_ *)
        let v6 : bool = v2 = v4
        if v6 then
            method4(v5, v3)
        else
            false
    | UH0_1, UH0_1 -> (* nil *)
        true
    | _ ->
        false
and method0 () : unit =
    let v0 : int32 = 1
    let v1 : UH0 = UH0_1
    let v2 : UH0 = UH0_0(v0, v1)
    let v3 : int32 = method1(v2)
    let v4 : (uint8 []) = Array.zeroCreate<uint8> v3
    let v5 : Mut0 = {l0 = 0} : Mut0
    method2(v2, v5, v4)
    let v6 : int32 = v5.l0
    let v7 : bool = v6 = v3
    let v8 : bool = v7 = false
    if v8 then
        failwith<unit> "The size of the array does not correspond to the amount being pickled."
    else
        ()
    let v9 : Mut0 = {l0 = 0} : Mut0
    let v10 : UH0 = method3(v9, v4)
    let v11 : int32 = v9.l0
    let v12 : int32 = v4.Length
    let v13 : bool = v11 = v12
    let v14 : bool = v13 = false
    if v14 then
        failwith<unit> "The size of the array does not correspond to the amount being unpickled."
    else
        ()
    let v15 : bool = method4(v10, v2)
    let v16 : bool = v15 = false
    if v16 then
        failwith<unit> "Serialization and deserialization should result in the same result."
    else
        ()
method0()
