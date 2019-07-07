let n = 1
let mutable T = 0
let mutable X = 1
let mutable Y = 1
let mutable Z = 1
while X <> n + 1 do
    T <- Z
    Z <- Z + Y
    Y <- T
    X <- X + 1
