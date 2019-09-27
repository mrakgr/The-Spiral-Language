// Generic CFR implementation based on the `An Introduction to Counterfactual Regret Minimization` paper

#load "helpers.fsx"
open Helpers
open System.Collections.Generic

type Node = 
    {
    strategy_sum: float []
    regret_sum: float []
    }

let node_create actions = 
    let l = Array.length actions
    {strategy_sum=Array.zeroCreate l; regret_sum=Array.zeroCreate l}

let inline chance dice one_probability next = 
    let prob = 1.0 / float (Array.length dice)
    prob * Array.fold (fun s dice -> s + next dice (one_probability * prob)) 0.0 dice

let inline response is_updateable infosets history actions one_probability two_probability next =
    let node = memoize infosets (fun _ -> node_create actions) history
    let action_distribution = regret_match node.regret_sum
    let util, util_weighted_sum =
        array_mapFold2 (fun s action action_probability ->
            let util = 
                if action_probability = 0.0 && two_probability = 0.0 then 0.0 // the pruning optimization
                else next action (one_probability * action_probability)
            util, s + util * action_probability
            ) 0.0 actions action_distribution

    if is_updateable then
        add node.strategy_sum (fun i -> one_probability * action_distribution.[i])
        add node.regret_sum (fun i -> two_probability * (util.[i] - util_weighted_sum))

    -util_weighted_sum

let terminal x = x
