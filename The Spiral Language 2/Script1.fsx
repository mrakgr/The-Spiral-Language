open System
open System.Collections.Generic

[<ReferenceEquality>]
type T = T of int

let x = Dictionary()
x.Add(T(1),"a")
x.Add(T(2),"b")
x.Add(T(3),"c")
x.AsReadOnly()
x.Add(T(4),"d")
printfn "%A" x

