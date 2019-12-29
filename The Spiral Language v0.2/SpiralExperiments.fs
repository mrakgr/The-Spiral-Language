module Spiral.Experiments

open Spiral.Types
open System.Collections.Generic

let rename x =
    let d = Dictionary(HashIdentity.Reference)
    let m = Dictionary(HashIdentity.Reference)
    let v = Dictionary(HashIdentity.Structural)
    let rec loop x = 
        memoize d (function
            | TyV x -> memoize v (fun _ -> TyV(v.Count)) x
            | TyFunction x ->
                let mutable is_new = false
                let x' = x |> memoize m (fun x -> is_new <- true; Array.zeroCreate x.Length)
                if is_new then Array.iteri (fun i x -> x'.[i] <- loop x) x
                TyFunction(x')
            ) x
    loop x

let x = Array.zeroCreate 3
x.[0] <- TyV(3)
x.[1] <- TyV(2)
x.[2] <- TyFunction(x)

printfn "%A" (rename (x.[2]))