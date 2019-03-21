open System.Collections.Generic

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

let nodes = [1;2;3;4]
let nodes_outgoing, _ = List.mapFoldBack (fun a s -> (a,s), a :: s) nodes []

/// Shuffled
let nodes_outgoing' = [(1, [3; 4; 2]); (3, [4]); (4, []); (2, [4; 3])]

let outgoing_to_ingoing initial (graph: IDictionary<_,_>) =
    let nodes = Dictionary()

    let rec loop node: HashSet<_> = 
        memoize nodes (fun node -> 
            List.iter (loop >> fun x -> x.Add(node) |> ignore) graph.[node]
            HashSet()
            ) node

    loop initial |> ignore
    nodes
    |> Seq.map (fun kv -> Seq.toList kv.Value, kv.Key)
    |> Seq.toList

outgoing_to_ingoing 1 (dict nodes_outgoing')