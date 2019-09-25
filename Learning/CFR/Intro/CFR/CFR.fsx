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

type Particle<'state> = {state: 'state; probability: float}

let particle state = {state=state; probability=1.0}

let state x = x.state
let inline chance one dice next = 
    let prob = 1.0 / float (Array.length dice)
    prob * Array.fold (fun s dice -> s + next {state=dice; probability=one.probability * prob}) 0.0 dice

/// Note: Here I swap player positions and update both of them in a single round, but in Marc Lanctot's thesis
/// CFR is described as updating only one player per episode. I am not sure if I made mistake translating the 
/// Java examples, or if the paper covered a different variant. Either way, it seems to be working correctly.
let inline response node one two actions next =
    let action_distribution = regret_match node.regret_sum
    add node.strategy_sum (fun i -> one.probability * action_distribution.[i])

    let util, util_weighted_sum =
        array_mapFold2 (fun s action action_probability ->
            let util = 
                if action_probability = 0.0 && two.probability = 0.0 then 0.0 // the pruning optimization
                else next (action, {one with probability=one.probability*action_probability})
            util, s + util * action_probability
            ) 0.0 actions action_distribution
    add node.regret_sum (fun i -> two.probability * (util.[i] - util_weighted_sum))

    -util_weighted_sum

let terminal x = x
