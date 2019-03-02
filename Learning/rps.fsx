// The RPS example from the `An Introduction to Counterfactual Regret Minimization` paper.
type RPS =
    | Rock=0
    | Paper=1
    | Scissors=2

let rng = System.Random()
let actions = [|RPS.Rock; RPS.Paper; RPS.Scissors|]
let opp_strategy = [|0.4;0.3;0.3|]

let utility = function
    | RPS.Rock, RPS.Rock -> 0.0
    | RPS.Paper, RPS.Paper -> 0.0
    | RPS.Scissors, RPS.Scissors -> 0.0
    | RPS.Paper, RPS.Rock -> 1.0
    | RPS.Rock, RPS.Paper -> -1.0
    | RPS.Rock, RPS.Scissors -> 1.0
    | RPS.Scissors, RPS.Rock -> -1.0
    | RPS.Scissors, RPS.Paper -> 1.0
    | RPS.Paper, RPS.Scissors -> -1.0
    | _ -> failwith "impossible"

type Regret = float[]

type Sum = 
    {
    strategy: Regret
    regret: Regret
    }
    
let normalize normalizingSum strategy = if normalizingSum > 0.0 then strategy / normalizingSum else 1.0 / float actions.Length

let getStrategy sum =
    let strategy, normalizingSum =
        Array.mapFold (fun s x ->
            let strategy = max x 0.0
            strategy, strategy + s
            ) 0.0 sum.regret

    Array.map (normalize normalizingSum) strategy

let updateSum (sum: Regret) strategy = Array.iteri (fun i x -> sum.[i] <- sum.[i] + x) strategy

let getAction (strategy: Regret) =
    let r = rng.NextDouble()
    let rec loop a cumulativeProbability =
        if a < actions.Length then 
            let cumulativeProbability = cumulativeProbability + strategy.[a]
            if r < cumulativeProbability then actions.[a]
            else loop (a+1) cumulativeProbability
        else 
            actions.[a]
    loop 0 0.0

let getAverageStrategy (sum: Regret) =
    let normalizingSum = Array.sum sum
    Array.map (normalize normalizingSum) sum

let train sum iterations =
    for i=1 to iterations do
        let strategy = getStrategy sum
        updateSum sum.strategy strategy
        let myAction = getAction strategy
        let otherAction = getAction opp_strategy
        let regret = Array.map (fun a -> utility (a, otherAction) - utility(myAction, otherAction)) actions
        updateSum sum.regret regret

let sum = 
    { 
    regret = Array.replicate actions.Length 0.0
    strategy = Array.replicate actions.Length 0.0
    }

train sum 1000000

let avgStrategy = getAverageStrategy sum.strategy
Array.iter2 (printfn "%A = %f") actions avgStrategy

