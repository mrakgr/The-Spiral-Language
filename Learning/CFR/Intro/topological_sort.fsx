/// Ignore this file. Was intended to be used for FSI-CFR.

open System.Collections.Generic

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

let nodes = [1;2;3;4]
let nodes_outgoing, _ = List.mapFoldBack (fun a s -> (a,s), a :: s) nodes []

/// Shuffled
let nodes_outgoing' = [(1, [4; 3; 2]); (3, [4]); (4, []); (2, [4; 3])]

/// Returns the topological order of the graph. Converts outgoing to ingoing edges.
/// Lacks checking for recursive cycles.
let outgoing_to_ingoing initial (graph: IDictionary<_,_>) =
    let nodes = Dictionary()
    let order = ResizeArray()

    let rec loop node: HashSet<_> = 
        memoize nodes (fun node -> 
            List.iter (loop >> fun x -> x.Add(node) |> ignore) graph.[node]
            order.Add(node)
            HashSet()
            ) node

    loop initial |> ignore
    nodes
    |> Seq.map (fun kv -> kv.Key, Seq.toArray kv.Value)
    |> Seq.toList
    |> fun x -> order.ToArray() |> Array.rev, dict x

outgoing_to_ingoing 1 (dict nodes_outgoing')