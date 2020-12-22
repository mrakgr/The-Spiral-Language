// Outcome sampling. Algorithm 3 in Marc Lanctot's thesis.

#load "helpers.fsx"
open Helpers
open System.Collections.Generic

type Node = 
        {
        strategy_sum: float []
        regret_sum: float []
        mutable count: uint32
        }

let node_create actions = 
    let l = Array.length actions
    {strategy_sum=Array.zeroCreate l; regret_sum=Array.zeroCreate l; count=0u}

let inline chance dice next = 
    /// Outcome sampling does not consider the probabilities in chance nodes
    next (sample_uniform dice)

let inline response_regret infosets uniformity_coef history actions one_probability two_probability next =
    let node = memoize infosets (fun _ -> node_create actions) history
    let proposal_distribution = regret_match node.regret_sum
    let sampling_distribution = Array.map (fun prob -> uniformity_coef * (1.0 / float (Array.length actions)) + (1.0 - uniformity_coef) * prob) proposal_distribution
    let action, node_probability, action_index = sample actions sampling_distribution proposal_distribution
    let utility, tail_probability = next action (one_probability * node_probability)
    let W = utility * two_probability.proposal // For some reason the importance sampling correction is not being done here.
    for i=0 to actions.Length-1 do
        // The branches seem to be the other way around between the thesis pseudocode and Lanctot's C++ examples.
        // Also, what `pi(z[i]a,z)` means in the context is ambiguous.
        // Note: this is very close to the softmax update which would be
        // let r = if i = action_index then W * (1.0 - proposal_distribution.[i]) else -W * proposal_distribution.[i]
        // This is another thing I need to make sure to check out.
        let r = if i = action_index then W * (1.0 - proposal_distribution.[i]) else -W
        node.regret_sum.[i] <- node.regret_sum.[i] + r
    -utility, tail_probability * node_probability.proposal

let inline response_strategy infosets count history actions one_probability next =
    let node = memoize infosets (fun _ -> node_create actions) history
    let proposal_distribution = regret_match node.regret_sum
    let action, node_probability, _ = sample_uniform' actions proposal_distribution
    let utility, tail_probability = next action (one_probability * node_probability)
    for i=0 to actions.Length-1 do
        node.strategy_sum.[i] <- node.strategy_sum.[i] + float (count - node.count) * one_probability.proposal * node_probability.proposal
        node.count <- count
    -utility, tail_probability * node_probability.proposal

let terminal one_probability two_probability x = x * one_probability.sample * two_probability.sample
