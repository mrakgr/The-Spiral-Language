// Outcome sampling. Algorithm 3 in Marc Lanctot's thesis.

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

type Particle<'state> = {state : 'state; propositional_probability : float; sampling_probability : float}

let particle state = {state=state; propositional_probability=1.0; sampling_probability=1.0}

let state x = x.state
let inline chance one dice next = 
    let dice, prob = sample_uniform dice 
    next {state=dice; propositional_probability=one.propositional_probability * prob; sampling_probability=one.sampling_probability * prob}

let inline response node one two actions next =
    let action_distribution = regret_match node.regret_sum
    add node.strategy_sum (fun i -> one.probability * action_distribution.[i])

    let util, util_weighted_sum =
        array_mapFold2 (fun s action action_probability ->
            let util = next (action, {one with probability=one.probability*action_probability})
            util, s + util * action_probability
            ) 0.0 actions action_distribution
    add node.regret_sum (fun i -> two.probability * (util.[i] - util_weighted_sum))

    -util_weighted_sum

let terminal x = x
