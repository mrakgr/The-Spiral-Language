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

/// The formulas in the paper are wrong.
let claim_index = function
    | 1,2 -> 0 | 1,3 -> 1 | 1,4 -> 2 | 1,5 -> 3 | 1,6 -> 4 | 1,1 -> 5
    | 2,2 -> 6 | 2,3 -> 7 | 2,4 -> 8 | 2,5 -> 9 | 2,6 -> 10 | 2,1 -> 11
    | _ -> failwith "impossible"

let action_to_history x = 1 <<< claim_index x
let history_to_nr history =
    let rec loop i = if history &&& (1 <<< i) <> 0 then i, claims.[i] else loop (i-1)
    loop (claims.Length-1)

let node_create actions = 
    let l = Array.length actions
    {strategy_sum=Array.zeroCreate l; regret_sum=Array.zeroCreate l}

let actions_tree = 
    Array.mapFoldBack (fun a s -> List.toArray s, (Claim a :: s)) claims [Dudo]
    |> fst
let agent' = Array.init dice.Length (fun _ -> Array.replicate (1 <<< claims.Length) None)
let agent dice = agent'.[dice-1]

let inline cfr_template f (actions, node) one two =
    let action_distribution = normalize node.regret_sum
    add node.strategy_sum (fun i -> one.probability * action_distribution.[i])

    let util, util_weighted_sum =
        array_mapFold2 (fun s action action_probability ->
            let util = f action action_probability
            util, s + util * action_probability
            ) 0.0 actions action_distribution
    add node.regret_sum (fun i -> two.probability * (util.[i] - util_weighted_sum))

    util_weighted_sum

let rec cfr history one two =
    let inline recurse action action_probability = -1.0 * cfr (action_to_history action ||| history) two {one with probability=one.probability*action_probability}
    let inline node actions = 
        let agent = agent one.dice
        match agent.[history] with
        | None -> let node = node_create actions in agent.[history] <- Some node; actions, node
        | Some node -> actions, node
    if history = 0 then cfr_template recurse (node claims) one two
    else
        let claim, (number, rank) = history_to_nr history
        cfr_template (fun action action_probability ->
            match action with
            | Dudo -> 
                let f s x = if x = 1 || x = rank then s+1 else s
                let dice_guessed = f (f 0 one.dice) two.dice
                if dice_guessed < number then 1.0 else -1.0
            | Claim claim -> recurse claim action_probability
            ) (node actions_tree.[claim]) one two

let train num_iterations =
    let mutable util = 0.0
    for i=1 to num_iterations do
        Array.iter (fun b ->
            Array.iter (fun a ->
                util <- util + cfr 0 {dice=a; probability=1.0} {dice=b; probability=1.0}
                ) dice
            ) dice
    printfn "Average game value: %f" (util / float (num_iterations * dice.Length * dice.Length))

#time
train 100
#time

// Functionally the same as v2, but 6x faster. I could not have written this before v2, but v2 was trivial to optimize
// once it was done. This version is a lot more complicated than v2 while being identical functionally, so I recommend 
// studying v2 instead if you are interested in what CFR does on Dudo.

// This version seems to be getting the results from the paper. 
// It seems accounting for the history of actions does make a difference in Dudo.