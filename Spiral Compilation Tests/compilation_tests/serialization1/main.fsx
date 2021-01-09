type Mut0 = {mutable l0 : int32}
let rec method1 (v0 : int32, v1 : (char []), v2 : Mut0, v3 : (uint8 []), v4 : int32) : unit =
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
        method1(v0, v1, v2, v3, v6)
    else
        ()
and method2 (v0 : int32, v1 : Mut0, v2 : (uint8 []), v3 : (char []), v4 : int32) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : int32 = v4 + 1
        let v7 : int32 = v1.l0
        let v8 : int32 = v7 + 2
        v1.l0 <- v8
        let v9 : char = System.BitConverter.ToChar(v2,v7)
        v3.[v4] <- v9
        method2(v0, v1, v2, v3, v6)
    else
        ()
and method0 () : unit =
    let v0 : string = "qwe"
    let v1 : int32 = v0.Length
    let v2 : int32 = 2 * v1
    let v3 : int32 = 4 + v2
    let v4 : (uint8 []) = Array.zeroCreate<uint8> v3
    let v5 : Mut0 = {l0 = 0} : Mut0
    let v6 : (char []) = v0.ToCharArray()
    let v7 : int32 = v6.Length
    let v8 : int32 = v5.l0
    let v9 : System.Span<uint8> = System.Span(v4,v8,4)
    let v10 : bool = System.BitConverter.TryWriteBytes(v9,v7)
    let v11 : bool = v10 = false
    if v11 then
        failwith<unit> "Conversion failed."
    else
        ()
    let v12 : int32 = v8 + 4
    v5.l0 <- v12
    let v13 : int32 = 0
    method1(v7, v6, v5, v4, v13)
    let v14 : int32 = v5.l0
    let v15 : bool = v14 = v3
    let v16 : bool = v15 = false
    if v16 then
        failwith<unit> "The size of the array does not correspond to the amount being pickled. One of the combinators is faulty."
    else
        ()
    let v17 : Mut0 = {l0 = 0} : Mut0
    let v18 : int32 = v17.l0
    let v19 : int32 = v18 + 4
    v17.l0 <- v19
    let v20 : int32 = System.BitConverter.ToInt32(v4,v18)
    let v21 : (char []) = Array.zeroCreate<char> v20
    let v22 : int32 = 0
    method2(v20, v17, v4, v21, v22)
    let v23 : string = System.String(v21)
    let v24 : int32 = v17.l0
    let v25 : int32 = v4.Length
    let v26 : bool = v24 = v25
    let v27 : bool = v26 = false
    if v27 then
        failwith<unit> "The size of the array does not correspond to the amount being unpickled. One of the combinators is faulty or the data is malformed."
    else
        ()
    let v28 : bool = v0 = v23
    let v29 : bool = v28 = false
    if v29 then
        failwith<unit> "Serialization and deserialization should result in the same result."
    else
        ()
method0()
