let rec method0 (v0 : int64, v1 : int64) : int64 =
    let (v2 : bool) = true
    if v2 then
        method0(v1, v0)
    else
        v0 + v1
let (v0 : int64) = 1L
let (v1 : int64) = 2L
method0(v0, v1)
