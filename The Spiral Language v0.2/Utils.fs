module Spiral.Utils

open System.Collections.Generic
open System.Runtime.CompilerServices

let inline memoize' (memo_dict: ConditionalWeakTable<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v
let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

// Memoizing map for cyclical structure
let inline memoize_rec (dict : Dictionary<_,_>) (e : _ []) ret f x =
    match dict.TryGetValue x with
    | true, v -> v
    | _ ->
        let e' = Array.zeroCreate e.Length
        let r = ret e'
        dict.Add(x,r)
        Array.iteri (fun i x -> e'.[i] <- f x) e
        r