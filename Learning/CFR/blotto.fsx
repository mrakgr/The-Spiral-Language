let rng = System.Random()

type Setting = {num_fields: int; num_soldiers: int}
type Regret = float[]
type Agent = 
    {
    name: string
    strategy_sum: Regret
    regret_sum: Regret
    }

let utility (action_one, action_two) =
    Array.fold2 (fun s a b -> s + compare a b) 0 action_one action_two |> float

let init (d: Setting) =
    let rec loop (d: Setting) (ar: ResizeArray<_>) (temp: _[]) field soldiers_left =
        if field < d.num_fields then
            for soldier=0 to soldiers_left do
                temp.[field] <- soldier
                loop d ar temp (field+1) (soldiers_left-soldier)
        elif soldiers_left = 0 then ar.Add(Array.copy temp)
    let ar = ResizeArray()
    loop d ar (Array.replicate d.num_fields 0) 0 d.num_soldiers
    ar.ToArray()

let actions = init {num_fields=3; num_soldiers=5}
   
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
    let u = utility(action_one, action_two)
    let regret = Array.map (fun a -> utility (a, action_two) - u) actions
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

train players 1000000

let print player =
    printfn "%s" player.name
    Array.iter2 (printfn "%A = %f") actions (average_strategy player.strategy_sum)
    printfn "---"

print (fst players)
print (snd players)
