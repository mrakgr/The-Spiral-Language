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
    {strategy_sum=Array.zeroCreate l; regret_sum=Array.zeroCreate l}

let actions_tree = 
    Array.mapFoldBack (fun a s -> (a, List.toArray s), (Claim a :: s)) claims [Dudo]
    |> fst |> dict
let agent = Dictionary(HashIdentity.Structural)

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
    let inline recurse action action_probability = -1.0 * cfr (action :: history) two {one with probability=one.probability*action_probability}
    let inline node actions = actions, memoize agent (fun _ -> node_create actions) (one.dice, history)
    match history with
    | [] -> cfr_template recurse (node claims) one two
    | (number, rank as claim) :: _ ->
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
                util <- util + cfr [] {dice=a; probability=1.0} {dice=b; probability=1.0}
                ) dice
            ) dice
        
    printfn "Average game value: %f" (util / float (num_iterations * dice.Length * dice.Length))

#time
train 100
#time

// Unlike v1, this one takes account of the history of actions. I removed the printing as there are now too many
// branches for it to be useful. Somehow the code for this ended up being simpler than for the v1 version.