open System.Collections.Generic

/// Helpers
let inline array_mapFold2 f s a b =
    let mutable s = s
    let ar = 
        Array.map2 (fun a b ->
            let x, s' = f s a b
            s <- s'
            x
            ) a b
    ar, s

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

let regret_match array = 
    let temp, normalizing_sum =
        Array.mapFold (fun s x ->
            let strategy = max x 0.0
            strategy, strategy + s
            ) 0.0 array

    let inline mutate_temp f = for i=0 to temp.Length-1 do temp.[i] <- f temp.[i]
    if normalizing_sum > 0.0 then mutate_temp (fun x -> x / normalizing_sum)
    else let value = 1.0 / float array.Length in mutate_temp (fun _ -> value)
    temp

let inline add sum f = for i=0 to Array.length sum-1 do sum.[i] <- sum.[i] + f i

let rng = System.Random()
let sample (actions : 'action []) (distribution : float []) =
    if actions.Length <> distribution.Length then failwith "The two arrays must be equally sized."
    let r = rng.NextDouble()
    let rec loop i cumulative_probability =
        if i < actions.Length then 
            let cumulative_probability = cumulative_probability + distribution.[i]
            if r < cumulative_probability then actions.[i], distribution.[i]
            else loop (i+1) cumulative_probability
        else 
            failwith "impossible"
    loop 0 0.0

let sample_uniform (actions : 'action []) = actions.[rng.Next(actions.Length)], 1.0 / float actions.Length
