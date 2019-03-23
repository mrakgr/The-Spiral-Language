// The RPS example from the `An Introduction to Counterfactual Regret Minimization` paper.
type RPS =
    | Rock
    | Paper
    | Scissors

let rng = System.Random()
let actions = [|Rock; Paper; Scissors|]

let utility = function
    | Rock, Rock -> 0.0
    | Paper, Paper -> 0.0
    | Scissors, Scissors -> 0.0
    | Paper, Rock -> 1.0
    | Rock, Paper -> -1.0
    | Rock, Scissors -> 1.0
    | Scissors, Rock -> -1.0
    | Scissors, Paper -> 1.0
    | Paper, Scissors -> -1.0

type Regret = float[]

type Agent = 
    {
    name: string
    strategy_sum: Regret
    regret_sum: Regret
    }
   
let normalize normalizingSum strategy = if normalizingSum > 0.0 then strategy / normalizingSum else 1.0 / float actions.Length

let strategy regret =
    let strategy, normalizingSum =
        Array.mapFold (fun s x ->
            let strategy = max x 0.0
            strategy, strategy + s
            ) 0.0 regret

    Array.map (normalize normalizingSum) strategy

let update_sum (sum: Regret) strategy = Array.iteri (fun i x -> sum.[i] <- sum.[i] + x) strategy

let action (strategy: Regret) =
    let r = rng.NextDouble()
    let rec loop a cumulativeProbability =
        if a < actions.Length then 
            let cumulativeProbability = cumulativeProbability + strategy.[a]
            if r < cumulativeProbability then actions.[a]
            else loop (a+1) cumulativeProbability
        else 
            failwith "impossible"
    loop 0 0.0

let average_strategy (strategy: Regret) =
    let normalizingSum = Array.sum strategy
    Array.map (normalize normalizingSum) strategy

let sample_and_update player = 
    let strategy = strategy player.regret_sum
    update_sum player.strategy_sum strategy
    action strategy

let update_regret player (action_one, action_two) =
    let regret = Array.map (fun a -> utility (a, action_two) - utility(action_one, action_two)) actions
    update_sum player.regret_sum regret

let train player iterations =
    for i=1 to iterations do
        let action_one = sample_and_update (fst player)
        let action_two = sample_and_update (snd player)
        update_regret (fst player) (action_one, action_two)
        update_regret (snd player) (action_two, action_one)

let players = 
    let f name =
        { 
        name = name
        regret_sum = Array.replicate actions.Length 0.0
        strategy_sum = Array.replicate actions.Length 0.0
        }
    f "One", f "Two"

train players 100000

let print sum =
    {sum with strategy_sum=average_strategy sum.strategy_sum; regret_sum=strategy sum.regret_sum}
    |> printfn "%A"

print (fst players)
print (snd players)