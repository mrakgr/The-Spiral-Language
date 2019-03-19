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

let inline normalize f array = 
    let temp, normalizing_sum =
        Array.mapFold (fun s x ->
            let strategy = max (f x) 0.0
            strategy, strategy + s
            ) 0.0 array

    let inline mutate_temp f = for i=0 to temp.Length-1 do temp.[i] <- f temp.[i]
    if normalizing_sum > 0.0 then mutate_temp (fun x -> x / normalizing_sum)
    else let value = 1.0 / float array.Length in mutate_temp (fun _ -> value)
    temp

let inline add sum f = for i=0 to Array.length sum-1 do sum.[i] <- sum.[i] + f i

// ---

type Action =
    | Claim of int * int
    | Dudo

type Node = 
    {
    mutable strategy: float
    mutable regret: float
    }

//type Agent = Dictionary<Action, History * Node>

let actions_initial = Array.map Claim [|1,2; 1,3; 1,4; 1,5; 1,6; 1,1; 2,2; 2,3; 2,4; 2,5; 2,6; 2,1|]
let actions_tree = 
    Array.mapFoldBack (fun a s -> (a,s), a :: s) actions_initial [Dudo]
    |> fun (x,_) -> Dictionary(dict x, HashIdentity.Reference)

let agent = Dictionary(HashIdentity.Reference)

let cfr_initial one two =
    let actions_allowed = actions_initial
    let nodes =
        actions_allowed 
        |> Array.map (
            memoize agent (fun _ -> Dictionary(HashIdentity.Reference), {strategy=0.0; regret=0.0})
            >> snd
            )
        
    let action_distribution = nodes |> normalize (fun x -> x.regret)
    add nodes
    ()


let dice_count target dice = Array.fold (fun s x -> if x = 1 || x = target then s+1 else s) 0 dice



type Particle = {probability: float}

let agent = Dictionary()

