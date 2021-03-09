module Graph
open System.Collections.Generic

type Graph = Map<string,string Set>
type MirroredGraph = Graph * Graph

let mirrored_graph_empty : MirroredGraph = Map.empty, Map.empty

let link_add' (abs : Graph) a b: Graph = 
    match Map.tryFind a abs with
    | Some bs -> Map.add a (Set.add b bs) abs
    | None -> Map.add a (Set.singleton b) abs
let link_add (s : MirroredGraph) a b: MirroredGraph = link_add' (fst s) a b, link_add' (snd s) b a

let link_remove' (abs : Graph) a b = 
    match Map.tryFind a abs with
    | Some bs -> 
        let bs = Set.remove b bs
        if Set.isEmpty bs then Map.remove a abs else Map.add a bs abs
    | None -> abs
let link_remove (s : MirroredGraph) a b: MirroredGraph = link_remove' (fst s) a b, link_remove' (snd s) b a

let links_remove ((abs,bas as s) : MirroredGraph) a: MirroredGraph = 
    match Map.tryFind a abs with
    | Some bs -> Map.remove a abs, Set.fold (fun bas b -> link_remove' bas b a) bas bs
    | None -> s
let links_add s a bs = List.fold (fun s b -> link_add s a b) s bs
let links_replace (s : MirroredGraph) a bs = links_add (links_remove s a) a bs
let links_get (abs : Graph) a = Map.tryFind a abs |> Option.defaultValue Set.empty
let link_exists ((abs,bas) : MirroredGraph) x = Map.containsKey x abs || Map.containsKey x bas

let topological_sort bas dirty_nodes =
    let sort_order = Stack()
    let sort_visited = HashSet()
    let rec dfs_rev a = if sort_visited.Add(a) then Seq.iter dfs_rev (links_get bas a); sort_order.Push(a)
    Seq.iter dfs_rev dirty_nodes
    sort_order, sort_visited

let circular_nodes ((abs,bas) : MirroredGraph) dirty_nodes =
    let sort_order, sort_visited = topological_sort bas dirty_nodes
    let order = sort_order.ToArray()
    let visited = HashSet()
    let circular_nodes = HashSet()
    order |> Array.iter (fun a ->
        let sc = ResizeArray() // This array stores the strongly connected components.
        let rec dfs a = if sort_visited.Contains(a) && visited.Add(a) then Seq.iter dfs (links_get abs a); sc.Add a
        dfs a
        if 1 < sc.Count then sc |> Seq.iter (fun x -> circular_nodes.Add(x) |> ignore)
        )
    order, circular_nodes