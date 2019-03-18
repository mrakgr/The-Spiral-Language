open System.Collections.Generic

type Action =
    | Pass
    | Bet

type Card =
    | One
    | Two
    | Three

let rng = System.Random()

let knuth_shuffle (ar: _[]) =
    let swap i j =
        let item = ar.[i]
        ar.[i] <- ar.[j]
        ar.[j] <- item

    for i=Array.length ar - 1 downto 1 do swap (rng.Next(i+1)) i

let cards = [|One; Two; Three|]

type Node = 
    {
    strategy_sum: float[]
    regret_sum: float[]
    }

type Agent = Dictionary<Action list * Card, Node>

let node_map : Agent = Dictionary()

let actions = [|Bet;Pass|]

let normalize array = 
    let temp, normalizing_sum =
        Array.mapFold (fun s x ->
            let strategy = max x 0.0
            strategy, strategy + s
            ) 0.0 array

    let inline mutate_temp f = for i=0 to temp.Length-1 do temp.[i] <- f temp.[i]
    if normalizing_sum > 0.0 then mutate_temp (fun x -> x / normalizing_sum)
    else mutate_temp (fun _ -> 1.0 / float actions.Length)
    temp

let add_strategy_sum agent realization_weight x = 
    let sum = agent.strategy_sum
    Array.iteri (fun i x -> sum.[i] <- sum.[i] + realization_weight * x) x

type Particle = {card: Card; probability: float}

let cfr history (one : Particle) (two : Particle) =
    match history with
    | [Pass; Pass] -> if one.card > two.card then 1.0 else -1.0
    | [Pass; Bet; Pass] -> -1.0
    | [Pass; Bet; Bet] -> if one.card > two.card then 2.0 else -2.0
    | [Bet; Pass] -> 1.0
    | [Bet; Bet] -> if one.card > two.card then 2.0 else -2.0
    | _ ->
        let node =
            match node_map.TryGetValue((history, one.card)) with
            | true, v -> v
            | false, _ -> {strategy_sum=Array.zeroCreate actions.Length; regret_sum=Array.zeroCreate actions.Length}

        let action_distribution = 
        0.0
    
let train num_iterations =
    let cards = [|One; Two; Three|]
    let mutable util = 0.0
    for i=1 to num_iterations do
        knuth_shuffle cards
        util <- util + cfr [] {card=cards.[0]; probability=1.0} {card=cards.[1]; probability=1.0}
    printfn "Average game value: %f" (util / float num_iterations)
    printfn "%A" node_map