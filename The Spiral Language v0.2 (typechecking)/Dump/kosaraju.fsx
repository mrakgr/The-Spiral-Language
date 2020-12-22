open System
open System.Collections.Generic

let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v

type Graph = Dictionary<string,string HashSet>
type MirroredGraph = Graph * Graph

let add_link (s : Graph) (a,b) = 
    memoize s (fun _ -> HashSet()) b |> ignore
    (memoize s (fun _ -> HashSet()) a).Add(b) |> ignore

let add_link' (s : MirroredGraph) (a,b) = add_link (fst s) (a,b); add_link (snd s) (b,a)

let topological_sort (s : Graph) = 
    let order = Stack()
    let visited = HashSet()
    let rec dfs a = if visited.Add(a) then Seq.iter dfs s.[a]; order.Push(a)
    let rng = Random()
    s |> Seq.toArray |> Array.map (fun x -> rng.Next(), x.Key) |> Array.sortBy fst // Shuffles the order.
    |> Array.iter (snd >> dfs)
    order.ToArray()

let strong_components (s : MirroredGraph) =
    let l = topological_sort (snd s)
    printfn "%A" l
    let visited = HashSet()
    let components = ResizeArray()
    l |> Array.iter (fun a ->
        let ar = ResizeArray()
        let rec dfs a = if visited.Add(a) then Seq.iter dfs (fst s).[a]; ar.Add a
        dfs a
        if 0 < ar.Count then components.Add(Seq.toList ar)
        )
    Seq.toList components

let s = Graph(), Graph()

[
"A", "B"
"B", "A"
"C", "D"
"D", "C"
"B", "D"
"D", "E"
] |> List.iter (add_link' s)

strong_components s |> printfn "%A"