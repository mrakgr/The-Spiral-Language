let v0 : (int32 []) = [|1; 2; 3|]
let v1 : uint64 = uint64 v0.LongLength
let v2 : bool = v1 = 3UL
if v2 then
    let v3 : int32 = v0.[int 0u]
    let v4 : int32 = v0.[int 1u]
    let v5 : int32 = v0.[int 2u]
    let v6 : int32 = v3 + v4
    v6 + v5
else
    let v8 : bool = v1 = 2UL
    if v8 then
        let v9 : int32 = v0.[int 0u]
        let v10 : int32 = v0.[int 1u]
        v9 + v10
    else
        let v12 : bool = v1 = 1UL
        if v12 then
            v0.[int 0u]
        else
            0
