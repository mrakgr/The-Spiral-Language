// create
let v0 : (bool []) = Array.zeroCreate<bool> 10
let v1 : (string []) = Array.zeroCreate<string> 10
let v2 : (int32 []) = Array.zeroCreate<int32> 10
// set
v0.[0] <- true
v1.[0] <- "qwe"
v2.[0] <- 2
// index
let v3 : bool = v0.[0]
let v4 : string = v1.[0]
let v5 : int32 = v2.[0]
struct (v3, v4, v5)
