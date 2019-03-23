#load "FSICFR.fsx"
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

let smallkey_nodes = Dictionary()
let bigkey_game = Dictionary()
let game_nodes = Dictionary(HashIdentity.Reference)
let game_ordered = ResizeArray() // All the game nodes in topological order.

open FSICFR
let inline response history one two actions next = 
    memoize bigkey_game (fun (history, one, two) -> 
        let response = response one actions next
        game_ordered.Add(response)
        let node = memoize smallkey_nodes (fun _ -> node_create actions) (history, state one)
        let node = memoize game_nodes (fun _ -> node) response
        response
        ) (history, one, two)

let inline chance one dice next = 
    let chance = chance one dice next
    game_ordered.Add(chance)
    chance

let rec dudo_main history one two =
    match history with
    | [] -> response history one two claims (fun claim -> dudo_main (claim :: history) two one)
    | (number,rank as claim) :: _ ->
        response 
            history one two
            actions.[Array.findIndex ((=) claim) claims + 1 .. ]
            (fun action ->
                match action with
                | Dudo ->
                    let f s x = if x = 1 || x = rank then s+1 else s
                    let dice_guessed = f (f 0 (state one)) (state two)
                    if dice_guessed < number then 1.0 else -1.0                    
                    |> terminal
                | Claim claim -> dudo_main (claim :: history) two one
                )

let dudo_initial one two = 
    chance one dice <| fun one ->
        chance two dice <| fun two ->
            dudo_main [] one two

let game_visitation_counts = Dictionary(HashIdentity.Reference)
let node_visitation_counts = Dictionary(HashIdentity.Reference)
let run () = 
    /// Propagate the visitations. This only needs to be done once.
    if game_visitation_counts.Count = 0 then
        let count_get' game = memoize game_visitation_counts (fun _ -> ref 0) game
        let count_get game = !(count_get' game)
        let count_increase i game =
            let r = count_get' game
            r := !r + i

        count_increase 1 game_ordered.[0]
        
        Seq.iter (function
            | Response(_, nodes) | Chance(_, nodes) as game-> Array.iter (count_increase (count_get game)) nodes
            | Terminal _ -> ()
            ) game_ordered

        Seq.iter (function
            | Response(player, nodes) as game-> 
                let count = count_get game
                let one, two = memoize node_visitation_counts (fun _ -> ref 0, ref 0) game
                if player = 1 then one := !one + count else two := !two + count
            | Chance _ | Terminal _ -> ()
            ) game_ordered

    let game_probabilities = Dictionary(HashIdentity.Reference)

    /// Initialize the probabilities for the first node
    let _ = memoize game_probabilities (fun _ -> ref 1.0, ref 1.0) game_ordered.[0]
    /// Propagate them.
    Seq.iter (fun game ->
        match game with
        | Response(player,nodes) ->
            let one,two = memoize game_probabilities (fun _ -> ref 0.0, ref 0.0) game
            ()
        ) game_ordered

    failwith ""
    

let train num_iterations =
    /// Compile the game.
    if game_ordered.Count = 0 then 
        let _ = dudo_initial (particle 1) (particle 2)
        game_ordered.Reverse()
    let mutable util = 0.0
    for i=1 to num_iterations do
        util <- util - run()
        
    printfn "Average game value: %f" (util / float num_iterations)

#time
train 100
#time

// Forget this. This algorithm is too complex for me to deal with. I barely started, and it is already a huge mess.

// What I intended to implement here was FSI-CFR from the paper, but though the pseudo-code is relatively straightforward,
// the part about getting a lexicographically ordered array of game nodes is what is difficult. It is much more difficult
// than the actual algorithm itself.

// CFR has a relatively neat monadic implementation. Turning a game into a graph on the other hand is more like a complicated
// compiler project than anything else. It already exceeds my threeshold for allowable mutation, and I can tell that it is going
// to take me something like a week to get it done correctly.

// The reason why is it worked for the authors is because they hand specialized everything just for the sake of one very specific game.
// In general, while the paper itself is fine, the code examples in it are fairly horrid all around.

// One thing that particularly sucks about FSI is that the actual game graph itself is much larger than the amount of player nodes.
// For Dudo here, what needs to be memoized is the state of the other player (6x) and the player ids (2x). 
// So for this that means a 12x increase in memory consumption.

// Since I haven't restricted the length of the history yet here, there would be no benefit to FSI over the standard program, but
// it would be a lot slower as everything would be interpreted and the program would be spread out across memory.

// It is really difficult - for CFR with memoization it would be great if there was a neat way of doing a topologically sorted kind
// of traversal without necessarily serating the game into its graph representation and having to do complex compiler analyses before
// that.

// As I said, just forget FSI. I can only hope that other variants of CFR do not end up being as complex as this.