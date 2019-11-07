//#r @"..\..\..\packages\FsCheck.3.0.0-alpha4\lib\net452\FsCheck.dll"

//open FsCheck

type Infoset = uint32
type Side = uint32
type Player = int

type GameTree =
| Terminal of reward : float
| Response of id : Infoset * branches : GameTree []

type PolicyAtNode = float []
type Policy = Map<Infoset, PolicyAtNode>

let sum_succ (id : Infoset) (branches : GameTree []) (o : Policy) f = Array.fold2 (fun s policy branch -> s + policy * f branch) 0.0 o.[id] branches

let u' o f = function
    | Terminal reward -> reward
    | Response (id, branches) -> sum_succ id branches o f

let rec u (o : Policy) tree = u' o (u o) tree

let rec infosets_at_branch = function
    | Terminal _ -> Set.empty
    | Response (id, branches) -> Set.add id (Array.fold (fun s branch -> Set.union s (infosets_at_branch branch)) Set.empty branches)

let update_at_branch_current cur next = function
    | Terminal _ -> cur
    | Response (id, _) -> Map.add id (Map.find id next) cur
let update_at_branch_descent cur next branch = Set.fold (fun s id -> Map.add id (Map.find id next) s) cur (infosets_at_branch branch)

let R (o' : Policy) (o : Policy) (tree : GameTree) = u o' tree - u o tree
let R' (o' : Policy) (o : Policy) (tree : GameTree) =
    u (update_at_branch_current o o' tree) tree - u o tree + 
    u' o' (fun branch -> u (update_at_branch_descent o o' branch) branch - u o branch) tree