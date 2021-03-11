open System
open System.IO
open System.Collections.Generic

let x = Queue()
x.Enqueue(1)
x.Enqueue(2)
x.Enqueue(3)

printfn "%A" (x.ToArray())

let q =
    List.fold (fun s x ->
        List.mapFold (fun s x -> if s = x then s+1,s+1 else x,s) x s |> fst
        ) [0;1;2] [0;2;3;5]