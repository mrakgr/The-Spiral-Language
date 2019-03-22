#load "helpers.fsx"
open Helpers
open System.Collections.Generic

type Number = int
type Rank = int
type Claim = Number * Rank

type Action =
    | Claim of Claim
    | Dudo

let dice: Rank[] = [|1..6|]
let claims: Claim[] = [|1,2; 1,3; 1,4; 1,5; 1,6; 1,1; 2,2; 2,3; 2,4; 2,5; 2,6; 2,1|]
let actions = Array.append (Array.map Claim claims) [|Dudo|]

let assign_state one state next = failwith ""
let select_action (one, history) actions next = failwith ""
let dice_get one = failwith ""

let rec dudo_main history one two =
    match history with
    | [] -> select_action (one,history) claims (fun (claim, one) -> dudo_main (claim :: history) two one)
    | (number,rank as claim) :: _ ->
        select_action 
            (one,history) 
            actions.[Array.findIndex ((=) claim) claims + 1 .. ]
            (fun (action, one) ->
                match action with
                | Dudo -> 
                    let f s x = if x = 1 || x = rank then s+1 else s
                    let dice_guessed = f (f 0 (dice_get one)) (dice_get two)
                    if dice_guessed < number then 1.0 else -1.0                    
                | Claim claim -> dudo_main (claim :: history) two one 
                )

let dudo_initial one two = 
    assign_state one dice (fun one ->
        assign_state two dice (fun two ->
            dudo_main [] one two
            )
        )