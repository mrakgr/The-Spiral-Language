type Mut0 = {mutable l0 : int32; mutable l1 : int32}
let v0 : Mut0 = {l0 = 1; l1 = 2} : Mut0
v0.l0 <- 3
v0.l1 <- 4
let v1 : int32 = v0.l0
v1
