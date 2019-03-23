let rng = System.Random()

type Setting = {num_fields: int; num_soldiers: int}
type Agent = 
    {
    strategy_sum: float[]
    regret_sum: float[]
    }

let utility (action_one, action_two) =
    Array.map2 compare action_one action_two
    |> Array.sum |> float

/// Initializes the actions for the General Blotto Vs Boba Fett example from the paper.
let init (d: Setting) =
    let ar = ResizeArray()
    let temp = Array.zeroCreate d.num_fields
    let rec loop field soldiers_left =
        if field < d.num_fields then
            for soldier=0 to soldiers_left do
                temp.[field] <- soldier
                loop (field+1) (soldiers_left-soldier)
        elif soldiers_left = 0 then ar.Add(Array.copy temp)
    loop 0 d.num_soldiers
    ar.ToArray()

let actions = init {num_fields=3; num_soldiers=5} // `{num_fields=3; num_soldiers=5}` would be 21 different possible actions.
   
let normalize array =
    let temp = Array.map (max 0.0) array
    let normalizingSum = Array.sum temp

    if normalizingSum > 0.0 then Array.map (fun x -> x / normalizingSum) temp
    else Array.replicate temp.Length (1.0 / float actions.Length)

let add_sum (sum: float[]) x = Array.iteri (fun i x -> sum.[i] <- sum.[i] + x) x
let add_regret (sum: float[]) f = Array.iteri (fun i x -> sum.[i] <- sum.[i] + f x) actions

let sample (dist: float[]) =
    let r = rng.NextDouble()
    let rec loop a cumulativeProbability =
        if a < actions.Length then 
            let cumulativeProbability = cumulativeProbability + dist.[a]
            if r <= cumulativeProbability then actions.[a]
            else loop (a+1) cumulativeProbability
        else 
            failwith "impossible"
    loop 0 0.0

let sample_and_update player = 
    /// Normalized sum of regret is the action/policy distribution.
    /// Actions being in a distribution means that every possible action has a probability that weights it.
    /// Sampling rather than being uniform is weighted by those probabilities.
    let action_distribution = normalize player.regret_sum
    /// `strategy_sum` is the sum of action distributions and is not actually used during play.
    /// `add_sum` is just a mutable vector addition function.
    add_sum player.strategy_sum action_distribution
    /// Sampling from the action distribution selects an action.
    sample action_distribution

/// This is the function that updates the sum of regrets which is related to the policy.
let update_regret one (action_one, action_two) =
    /// Computes the utility for player `one` given the actions taken by player `one` and `two`.
    let self_utility = utility(action_one, action_two)
    /// Iterates over all the actions and mutably adds them to the sum.
    add_regret one.regret_sum (fun a -> utility (a, action_two) - self_utility)

/// When the players are the same, this does self-play.
let vs (one : Agent, two : Agent as players) = 
    let action_one = sample_and_update one
    let action_two = sample_and_update two
    update_regret one (action_one, action_two)
    update_regret two (action_two, action_one)

let train (one : Agent, two : Agent as players) iterations = for i=1 to iterations do vs players

let player = 
    { 
    regret_sum = Array.replicate actions.Length 0.0
    strategy_sum = Array.replicate actions.Length 0.0
    }

let timer = System.Diagnostics.Stopwatch.StartNew()
train (player,player) 10000000
printfn "%A" timer.Elapsed

let print player =
    Array.iter2 (printfn "%A = %f") actions (normalize player.strategy_sum)
    printfn "---"

print player