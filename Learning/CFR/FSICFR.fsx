#load "helpers.fsx"
open Helpers
open System.Collections.Generic

type Node =
    | Terminal of float
    | Response of strategy: float[] * regret: float[] * Node []
    | Chance of Node []

type Particle<'state> = {state: 'state; player: int}

let particle player = {state=(); player=player}

let state x = x
let inline chance player dice next = Array.map (fun dice -> next {state=dice; player=player.player}) dice |> Chance
let inline response actions next =
    let regret = Array.zeroCreate (Array.length actions)
    let strategy = Array.zeroCreate (Array.length actions)
    let nodes = Array.map next actions
    Response(strategy,regret,nodes)
let terminal = Terminal
