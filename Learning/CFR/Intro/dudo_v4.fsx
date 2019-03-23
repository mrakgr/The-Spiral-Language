#load "CFR.fsx"
open System.Collections.Generic

open Helpers

type Number = int
type Rank = int
type Claim = Number * Rank

type Action =
    | Claim of Claim
    | Dudo

let dice: Rank[] = [|1..6|]
let claims: Claim[] = [|1,2; 1,3; 1,4; 1,5; 1,6; 1,1; 2,2; 2,3; 2,4; 2,5; 2,6; 2,1|]
let actions = Array.append (Array.map Claim claims) [|Dudo|]

let agent = Dictionary()

open CFR
let inline response (history,one,two) actions next = 
    let node = memoize agent (fun _ -> node_create actions) (history, one.state)
    response node one two actions next

let rec dudo_main (history, one, two as key) =
    match history with
    | [] -> response key claims (fun (claim, one) -> dudo_main (claim :: history, two, one))
    | (number,rank as claim) :: _ ->
        response key
            actions.[Array.findIndex ((=) claim) claims + 1 .. ]
            (fun (action, one) ->
                match action with
                | Dudo ->
                    let f s x = if x = 1 || x = rank then s+1 else s
                    let dice_guessed = f (f 0 (state one)) (state two)
                    if dice_guessed < number then 1.0 else -1.0                    
                    |> terminal
                | Claim claim -> dudo_main (claim :: history, two, one)
                )

let dudo_initial one two = 
    chance one dice <| fun one ->
        chance two dice <| fun two ->
            dudo_main ([], one, two)

let train num_iterations =
    let mutable util = 0.0
    for i=1 to num_iterations do
        util <- util - dudo_initial (particle ()) (particle ())
        
    printfn "Average game value: %f" (util / float num_iterations)

#time
train 100
#time

// The refined design for the CFR agent. Here I've finally succeeded in factoring out the inference logic from the game logic.
// This results in quite a generic implementation that could be used for other games. Having the correct design in mind will
// also make implementing the more complicated FSI-CFR much easier.