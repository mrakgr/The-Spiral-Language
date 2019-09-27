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

let player_one_infosets = Dictionary()
let player_two_infosets = Dictionary()

open CFR
let inline response (history,one,two) actions next = 
    response (history, one.state) one two actions next

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
                    let dice_guessed = f (f 0 one.state) two.state
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
        let run one_is_updateable two_is_updateable =
            let particle infoset is_updateable = {state=(); probability=1.0; infosets=infoset; is_updateable=is_updateable}
            dudo_initial (particle player_one_infosets one_is_updateable) (particle player_two_infosets two_is_updateable)
        util <- util - (run true false + run false true) / 2.0
        
    printfn "Average game value: %f" (util / float num_iterations)

#time
train 100
#time

/// I've decided to skip FSI-CFR as compiling arbitrary games to graph form is too difficult.
/// It is doable enough for a single game like the authors did in paper, but there
/// is just no easy technique that I can think of to do it generically.

/// And even if it were done, it is difficult to push through the reasoning of correctness.

/// Turning CFR into a breadth first search like FSI demands is just too laborious.
/// The vanilla CFR which does depth first search is a lot more flexible as an algorithm.