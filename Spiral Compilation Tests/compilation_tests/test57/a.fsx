// create
let v0 : (bool []) = Array.zeroCreate<bool> 10
let v1 : (string []) = Array.zeroCreate<string> 10
let v2 : (int32 []) = Array.zeroCreate<int32> 10
let v3 : (bool []) = Array.zeroCreate<bool> 10
let v4 : (bool []) = Array.zeroCreate<bool> 10
// set 0
v0.[0] <- true
v1.[0] <- "qwe"
v2.[0] <- 2
v3.[0] <- false
v4.[0] <- true
// set 1 - note how record fields can be omitted in the real segment
v0.[1] <- false
v1.[1] <- "zxc"
v2.[1] <- -2
v4.[1] <- false
// index 0
let v5 : bool = v0.[0]
let v6 : string = v1.[0]
let v7 : int32 = v2.[0]
let v8 : bool = v3.[0]
let v9 : bool = v4.[0]
struct (v5, v6, v7, v8, v9)
