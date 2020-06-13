module HopacArith

open System
open Hopac

type S = S of int * Job<S>

let rec arith i = Job.delay(fun () ->
    printfn "Hello"
    S(i,arith (i+1)) |> Job.result
    )
    
let rec loop k = job {
    let! (S(i,_)) = k
    let! (S(i,k)) = k
    printfn "%i" i
    Console.ReadKey()
    return! loop k
    }

loop (arith 0) |> run