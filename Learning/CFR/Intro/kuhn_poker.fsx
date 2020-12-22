open System.Collections.Generic

/// Globals
let rng = System.Random()

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

let knuth_shuffle (ar: _[]) =
    let swap i j =
        let item = ar.[i]
        ar.[i] <- ar.[j]
        ar.[j] <- item

    for i=Array.length ar - 1 downto 1 do swap (rng.Next(i+1)) i

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

type Action =
    | Pass
    | Bet

type Card =
    | One
    | Two
    | Three

type Node = 
    {
    strategy_sum: float[]
    regret_sum: float[]
    }

type Particle = {card: Card; probability: float}

let agent = Dictionary()
let actions = [|Bet;Pass|]
let show = Array.map2 (sprintf "%A=%f%%") actions >> String.concat "; " >> sprintf "[|%s|]"

let rec cfr history (one : Particle) (two : Particle) =
    let node = 
        memoize agent (fun _ -> 
            {strategy_sum=Array.zeroCreate actions.Length; regret_sum=Array.zeroCreate actions.Length}
            ) (one.card, history)

    let action_distribution = normalize node.regret_sum
    add node.strategy_sum (fun i -> one.probability * action_distribution.[i])

    let util, util_weighted_sum =
        array_mapFold2 (fun s action action_probability ->
            let history = action :: history
            let util =
                match history with
                | [Pass; Bet; Pass] -> -1.0
                | [Pass; Bet] -> -1.0
                | [Pass; Pass] -> if one.card > two.card then 1.0 else -1.0
                | [Bet; Bet; Pass] -> if one.card > two.card then 2.0 else -2.0
                | [Bet; Bet] -> if one.card > two.card then 2.0 else -2.0
                | _ -> -1.0 * cfr history two {one with probability=one.probability*action_probability}
            util, s + util * action_probability
            ) 0.0 actions action_distribution
    add node.regret_sum (fun i -> two.probability * (util.[i] - util_weighted_sum))
    
    util_weighted_sum
    
let train num_iterations =
    let cards =
        let cards = [|One; Two; Three|]
        [|
        for i=0 to 2 do
            for j=0 to 2 do
                if i <> j then yield (cards.[i], cards.[j])
        |]

    let mutable util = 0.0
    for i=1 to num_iterations do
        Array.iter (fun (a,b) ->
            util <- util + cfr [] {card=a; probability=1.0} {card=b; probability=1.0}
            ) cards
        
    printfn "Average game value: %f" (util / float (num_iterations * cards.Length))
    agent
    |> Seq.sortBy (fun x -> x.Key)
    |> Seq.iter (fun kv ->
        printfn "%A - %s" (kv.Key |> fun (card,actions) -> card, List.rev actions) (normalize kv.Value.strategy_sum |> show)
        ) 

train 100000
