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

let normalize array = 
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

// ---

type Number = int
type Rank = int
type Claim = Number * Rank

type Action =
    | Claim of Claim
    | Dudo

type Node = 
    {
    strategy_sum: float []
    regret_sum: float []
    }

let show (actions, node) =
    let action_distribution = normalize node.strategy_sum
    Array.map2 (sprintf "%A=%f%%") actions action_distribution
    |> String.concat "; " |> sprintf "[|%s|]"

type Particle = {dice: Rank; probability: float}

let dice: Rank[] = [|1..6|]
let claims: Claim[] = [|1,2; 1,3; 1,4; 1,5; 1,6; 1,1; 2,2; 2,3; 2,4; 2,5; 2,6; 2,1|]

let node_create actions = 
    let l = Array.length actions
    actions, {strategy_sum=Array.zeroCreate l; regret_sum=Array.zeroCreate l}

let agent_some = 
    let actions_tree, _ = Array.mapFoldBack (fun a s -> List.toArray s, (Claim a :: s)) claims [Dudo]
    Array.map (fun dice ->
        actions_tree
        // Extends the claims so they take account of their history.
        |> Array.mapi (fun action_index actions -> 
            /// From 2 ** (action_index - 1) .. (2 ** action_index - 1)
            let num_claims = (1 <<< action_index) - 1
            Array.init num_claims (fun _ -> node_create actions))
        |> fun x -> dice, x
        ) dice
    |> dict

let agent_none = Array.map (fun dice -> dice, node_create claims) dice |> dict

let claim_range x = 
    let x = x + 1 
    let left = 1 <<< (x - 1)
    let right = (1 <<< x) - 1
    left, right

/// The formulas in the paper are wrong.
let claim_index = function
    | 1,2 -> 0 | 1,3 -> 1 | 1,4 -> 2 | 1,5 -> 3 | 1,6 -> 4 | 1,1 -> 5
    | 2,2 -> 6 | 2,3 -> 7 | 2,4 -> 8 | 2,5 -> 9 | 2,6 -> 10 | 2,1 -> 11
    | _ -> failwith "impossible"



