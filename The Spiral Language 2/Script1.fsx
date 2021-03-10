open System
open System.IO
open System.Collections.Generic

let x = Queue()
x.Enqueue(1)
x.Enqueue(2)
x.Enqueue(3)

printfn "%A" (x.ToArray())