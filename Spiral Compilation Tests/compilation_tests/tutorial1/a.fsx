let rec method0 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 10
    if v2 then
        let v3 : int32 = v1 + 1
        v0.[v1] <- v1
        method0(v0, v3)
    else
        ()
let v0 : (int32 []) = Array.zeroCreate<int32> 10
let v1 : int32 = 0
method0(v0, v1)
