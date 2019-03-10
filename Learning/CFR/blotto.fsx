let rng = System.Random()

type Setting = {num_fields: int; num_soldiers: int}
type Regret = float[]
type Agent = 
    {
    strategy_sum: Regret
    regret_sum: Regret
    }

let utility (action_one, action_two) =
    Array.map2 compare action_one action_two
    |> Array.sum |> float

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

let actions = init {num_fields=3; num_soldiers=5}
   
let normalize array =
    let temp = Array.map (max 0.0) array
    let normalizingSum = Array.sum temp

    if normalizingSum > 0.0 then Array.map (fun x -> x / normalizingSum) temp
    else Array.replicate temp.Length (1.0 / float actions.Length)

let add_sum (sum: Regret) x = Array.iteri (fun i x -> sum.[i] <- sum.[i] + x) x
let add_regret (sum: Regret) f = Array.iteri (fun i x -> sum.[i] <- sum.[i] + f x) actions

let sample (dist: Regret) =
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
    let action_distribution = normalize player.regret_sum
    add_sum player.strategy_sum action_distribution
    sample action_distribution

let update_regret player (action_one, action_two) =
    let u = utility(action_one, action_two)
    add_regret player.regret_sum (fun a -> utility (a, action_two) - u)

let train player iterations =
    for i=1 to iterations do
        let action_one = sample_and_update (fst player)
        let action_two = sample_and_update (snd player)
        update_regret (fst player) (action_one, action_two)
        update_regret (snd player) (action_two, action_one)

let player = 
    { 
    regret_sum = Array.replicate actions.Length 0.0
    strategy_sum = Array.replicate actions.Length 0.0
    }

let timer = System.Diagnostics.Stopwatch.StartNew()
train (player,player) 100000
printfn "%A" timer.Elapsed

let print player =
    Array.iter2 (printfn "%A = %f") actions (normalize player.strategy_sum)
    printfn "---"

print player
