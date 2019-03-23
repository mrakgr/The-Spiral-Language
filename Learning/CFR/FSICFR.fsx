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

type Game =
    | Terminal of float
    | Response of player: int * Game []
    | Chance of player: int * Game []

type Particle<'state> = {state: 'state; id: int}

let particle id = {state=(); id=id}

let state x = x.state
let inline chance player dice next = Array.map (fun dice -> next {state=dice; id=player.id}) dice |> fun x -> Chance(player.id,x)
let inline response player actions next = Response(player.id,Array.map next actions)
let terminal = Terminal

