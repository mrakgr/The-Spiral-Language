module Spiral.Types

// Global open
open System
open System.Collections.Generic
open HashConsing
open System.Runtime.CompilerServices

// Globals
let hash_cons_table = HashConsing.HashConsTable()

type TypedData =
    | TyFunction of TypedData []
    | TyV of int

and ConsedTypedData = // for join points and layout types
    | CTyFunction of ConsedNode<ConsedTypedData []>
    | CTyV of int

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

let inline memoize_rec (memo_dict: Dictionary<_,_>) on_init on_rec k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> 
        let v = on_init k
        memo_dict.Add(k,v)
        on_rec v
