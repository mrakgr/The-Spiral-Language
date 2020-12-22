// Exercise 1.3 from the Pattern Matching and Machine Learning book.

// What I am doing here is implementing a probabilistic programming inference algorithm called enumeration.

open System.Collections.Generic
let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

type Box =
    | Red
    | Green
    | Blue

type Fruit =
    | Orange
    | Lime
    | Apple

let quantities_to_dist x = 
    let total = Array.fold (fun s (_,num_items) -> s + num_items) 0 x
    Array.map (fun (dsc,num_items) -> dsc, float num_items / float total) x

let normalize_dist dist =
    let total = Array.fold (fun s (_,prob) -> s + prob) 0.0 dist
    Array.map (fun (a, prob) -> a, prob / total) dist

let box_dist =
    [|
    (Red, quantities_to_dist [|Apple, 3; Lime, 3; Orange, 4|]), 0.2
    (Blue, quantities_to_dist [|Apple, 1; Lime, 0; Orange, 1|]), 0.2
    (Green, quantities_to_dist [|Apple, 3; Lime, 4; Orange, 3|]), 0.6
    |]

let sample dist ret cur_log_prob =
    Array.iter (fun (x,prob) ->
        ret x (log prob + cur_log_prob)
        ) dist

let factor fact ret sample = ret () (sample + fact)
let condition cond ret sample = factor (if cond then log 1.0 else log 0.0) ret sample

let program ret =
    sample box_dist (fun (box, fruit_dist) ->
        sample fruit_dist (fun fruit ->
            ret (fruit = Apple)
            )
        )

let program' ret =
    sample box_dist (fun (box, fruit_dist) ->
        sample fruit_dist (fun fruit ->
            condition (fruit = Orange) (fun _ ->
                ret (box = Green)
                )
            )
        )

let run_program prog =
    let dict = Dictionary()
    prog (fun x log_prob ->
        let prob = memoize dict (fun _ -> ref 0.0) x
        prob := !prob + exp log_prob
        ) (log 1.0)

    Seq.toArray dict
    |> Array.map (fun kv -> kv.Key, !kv.Value)
    |> normalize_dist

run_program program'
