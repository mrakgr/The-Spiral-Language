open System

let x = ResizeArray()
x.Add 1
x.Add 2
x.Add 3
let y = x.RemoveAll(fun x -> x = 2)
let comp = Comparison(fun a b -> 1)
x.Sort(comp)
compare 2 1