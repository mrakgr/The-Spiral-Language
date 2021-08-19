type Mut0 = {mutable l0 : uint64}
let rec method0 (v0 : Mut0) : bool =
    let v1 : uint64 = v0.l0
    v1 < 10UL
and method1 (v0 : uint64, v1 : Mut0) : bool =
    let v2 : uint64 = v1.l0
    v2 < v0
let v0 : (struct (int32 * int32 * int32) []) = Array.zeroCreate<struct (int32 * int32 * int32)> (System.Convert.ToInt32(10UL))
let v1 : Mut0 = {l0 = 0UL} : Mut0
while method0(v1) do
    let v3 : uint64 = v1.l0
    v0.[int v3] <- struct (5, 4, 3)
    let v4 : uint64 = v3 + 1UL
    v1.l0 <- v4
let v5 : uint64 = System.Convert.ToUInt64 v0.Length
let v6 : (struct (int32 * int32 * int32) []) = Array.zeroCreate<struct (int32 * int32 * int32)> (System.Convert.ToInt32(v5))
let v7 : Mut0 = {l0 = 0UL} : Mut0
while method1(v5, v7) do
    let v9 : uint64 = v7.l0
    let struct (v10 : int32, v11 : int32, v12 : int32) = v0.[int v9]
    v6.[int v9] <- struct (v12, v11, v10)
    let v13 : uint64 = v9 + 1UL
    v7.l0 <- v13
v6
