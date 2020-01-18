open System.Collections.Generic

type [<ReferenceEquality>] A = A of obj
type B = B of int * A

let x = A "qwe"
let y = A "qwe"
B(1,x) = B(2,x)

let Q : HashSet<B> = HashSet(HashIdentity.Structural)
Q.Add(B(2,x))

hash (B(2,x))