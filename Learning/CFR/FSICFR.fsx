#load "helpers.fsx"
open Helpers
open System.Collections.Generic

type Node =
    | Terminal of float
    | Response of strategy: float[] * regret: float[] * Node []
    | Chance of Node []

let particle state = state

let state x = x
let inline chance dice next = Array.map next dice |> Chance
let inline response actions next =
    let regret = Array.zeroCreate (Array.length actions)
    let strategy = Array.zeroCreate (Array.length actions)
    let nodes = Array.map next actions
    Response(strategy,regret,nodes)
let terminal = Terminal
