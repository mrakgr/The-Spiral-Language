// Outcome sampling. Algorithm 3 in Marc Lanctot's thesis.

#load "helpers.fsx"
open Helpers
open System.Collections.Generic

type Node = 
    {
    strategy_sum: float []
    regret_sum: float []
    count: uint32 ref
    }

let node_create actions = 
    let l = Array.length actions
    {strategy_sum=Array.zeroCreate l; regret_sum=Array.zeroCreate l; count=ref 0.0}

type Particle<'state> = 
    {
    state: 'state
    probability: Probability
    uniformity_coef: float
    count: uint32
    }

//let particle state = {state=state; propositional_probability=1.0; sampling_probability=1.0}

let state x = x.state
let inline chance dice one next = 
    let dice = sample_uniform dice 
    /// Outcome sampling does not consider the probabilities in chance nodes
    next {one with state=dice}

let inline response_first node one two actions next = 
    let proposal_distribution = regret_match node.regret_sum
    let sampling_distribution = Array.map (fun prob -> one.uniformity_coef * (1.0 / float (Array.length actions)) + (1.0 - one.uniformity_coef) * prob) proposal_distribution
    let action, node_probability, i' = sample actions sampling_distribution proposal_distribution
    let utility, tail_probability = next (action, {one with probability=one.probability * node_probability})
    let W = utility * two.probability.proposal // for some reason importance sampling is not being done here
    for i=0 to actions.Length-1 do
        let r =
            if i = i' then -W * node_probability.proposal
            else W * (one.probability.proposal * (proposal_distribution.[i] - 1.0))
        node.regret_sum.[i] <- node.regret_sum.[i] + r
    -utility, tail_probability * node_probability.proposal

let inline respose_second node one two actions next =
    let proposal_distribution = regret_match node.regret_sum
    let action, node_probability, _ = sample_uniform' actions proposal_distribution
    let utility, tail_probability = next (action, {one with probability=one.probability * node_probability})
    for i=0 to actions.Length-1 do
        node.strategy_sum.[i] <- node.strategy_sum.[i] + float (one.count - !node.count) * two.probability.proposal * node_probability.proposal
        node.count := one.count
    -utility, tail_probability * node_probability.proposal

let terminal one two x = x * one.probability.sample * two.probability.sample, 1.0
