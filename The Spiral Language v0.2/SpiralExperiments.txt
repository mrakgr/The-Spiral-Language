module Spiral.Experiments

open System
open Spiral.Types
open System.Collections.Generic

let rename x =
    let m = Dictionary(HashIdentity.Reference)
    let v = Dictionary(HashIdentity.Structural)
    let rec loop = function
        | TyV x -> memoize v (fun _ -> TyV(v.Count)) x
        | TyFunction x as q ->
            memoize_rec m (fun (TyFunction(x)) -> TyFunction(Array.zeroCreate x.Length))
                (fun (TyFunction(x') as q) -> Array.iteri (fun i x -> x'.[i] <- loop x) x; q)
                q
    loop x

let x = Array.zeroCreate 3
let x' = TyFunction x
x.[0] <- TyV(3)
x.[1] <- TyV(2)
x.[2] <- x'

match rename x' with
| TyFunction [|_;_;x'' & TyFunction([|_;_;x'''|])|] as x' -> 
    printfn "%A" x'
    printfn "%A" x''
    printfn "%b" (Object.ReferenceEquals(x',x''))