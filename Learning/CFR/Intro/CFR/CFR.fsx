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

type Particle<'state, 'history> = {state: 'state; probability: float; infosets: Dictionary<'history, Node>; is_updateable: bool}

let inline chance one dice next = 
    let prob = 1.0 / float (Array.length dice)
    prob * Array.fold (fun s dice -> s + next {state=dice; probability=one.probability * prob; infosets=one.infosets; is_updateable=one.is_updateable}) 0.0 dice

let inline response history one two actions next =
    let node = memoize one.infosets (fun _ -> node_create actions) history
    let action_distribution = regret_match node.regret_sum
    let util, util_weighted_sum =
        array_mapFold2 (fun s action action_probability ->
            let util = 
                if action_probability = 0.0 && two.probability = 0.0 then 0.0 // the pruning optimization
                else next (action, {one with probability=one.probability*action_probability})
            util, s + util * action_probability
            ) 0.0 actions action_distribution

    if one.is_updateable then
        add node.strategy_sum (fun i -> one.probability * action_distribution.[i])
        add node.regret_sum (fun i -> two.probability * (util.[i] - util_weighted_sum))

    -util_weighted_sum

let terminal x = x
