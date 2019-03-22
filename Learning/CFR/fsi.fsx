#load "helpers.fsx"
open Helpers
open System.Collections.Generic

type Node<'a,'b,'c> =
    | Response of 'a
    | Chance of 'b
    | Initial of 'c
    | Terminal of float

type Particle<'a> = {state: 'a; probability: float}

type Number = int
type Rank = int
type Claim = Number * Rank

type Action =
    | Claim of Claim
    | Dudo

let transition (number, rank as history) action one_dice two_dice =
    match action with
    | Dudo -> 
        let f s x = if x = 1 || x = rank then s+1 else s
        let dice_guessed = f (f 0 one_dice) two_dice
        if dice_guessed < number then Terminal 1.0 else Terminal -1.0
    | Claim claim -> Response claim

let dice: Rank[] = [|1..6|]
let claims: Claim[] = [|1,2; 1,3; 1,4; 1,5; 1,6; 1,1; 2,2; 2,3; 2,4; 2,5; 2,6; 2,1|]
let actions_initial = claims
let actions_response claim = 
    Array.append
        (Array.map Claim claims.[Array.findIndex ((=) claim) claims + 1 .. claims.Length - 1])
        [|Dudo|]

let initial = dice // Is assumed that the initial states are uniformly distributed.

type NodeData = 
    {
    strategy_sum: float []
    regret_sum: float []
    }

let node_create actions = 
    let l = Array.length actions
    {strategy_sum=Array.zeroCreate l; regret_sum=Array.zeroCreate l}

let agent = Dictionary(HashIdentity.Structural)
let cfr _ =
    let actions = Dictionary(HashIdentity.Structural)    
    let particle_prob = 1.0 / (Array.length initial |> float)

    let rec response history one two =
        let actions = memoize actions actions_response (List.head history)
        let node = memoize agent (fun _ -> node_create actions) (one.state, history)
        let action_distribution = normalize node.regret_sum
        add node.strategy_sum (fun i -> one.probability * action_distribution.[i])

        let util, util_weighted_sum =
            array_mapFold2 (fun s action action_probability ->
                let util = f action action_probability
                util, s + util * action_probability
                ) 0.0 actions action_distribution
        add node.regret_sum (fun i -> two.probability * (util.[i] - util_weighted_sum))

        util_weighted_sum

    let mutable util = 0.0
    for action in actions_initial do
        for dice in initial do
            for dice' in initial do
                util <- util + response [action] {state=dice; probability=particle_prob} {state=dice'; probability=particle_prob}
    util



