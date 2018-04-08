module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module
open System.Collections.Generic
open System.Security.Policy

let dictionary =
    (
    "Dictionary",[],"The Dictionary module.",
    """
inl ty elem_type = fs [text: "System.Collections.Generic.Dictionary"; types: elem_type]
inl {d with elem_type} ->
    inl elem_type = type elem_type
    inl key, value = elem_type
    inl ty = ty elem_type
    inl capacity = 
        match d with
        | {capacity} -> capacity : int32
        | _ -> 64i32
    inl id =
        match d with
        | {id} -> id
        | _ -> .structural
    inl x = 
        match id with
        | .structural -> macro.fs ty [type: ty; iter: "(",",",")", [arg: capacity; text: "HashIdentity.Structural"]]
        | .reference -> macro.fs ty [type: ty; iter: "(",",",")", [arg: capacity; text: "HashIdentity.Reference"]]
    inl elem_type = stack {key value}
    function
    | .set i v ->
        assert (eq_type elem_type.key i) {msg="The index's type is not the equal to that of the key."; key i}
        assert (eq_type elem_type.value v) {msg="The second argument's type is not the equal to that of the value."; value v}
        macro.fs () [arg: x; text: ".["; arg: i; text: "] <- "; arg: v]
    | i {on_succ on_fail} ->
        assert (eq_type key i) {msg="The index's type is not the equal to that of the key."; key i}
        macro.fs () [arg: x; text: ".TryGetValue"; args: i; text: " |> fun (a,b) -> ";]
        inl a = macro.fs bool [text: "a"]
        inl b = macro.fs elem_type.value [text: "b"]
        if a then on_succ b else on_fail ()
    """) |> module_

let poker =
    (
    "Poker",[random;console;option],"The Poker module.",
    """
inl Suits = .Spades, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.reducel (inl a b -> a \/ b) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.reducel (inl a b -> a \/ b) Ranks
inl Card = type {rank=Rank; suit=Suit}

inl num_cards = 
    inl l = Tuple.foldl (inl s _ -> s+1) 0
    l Suits * l Ranks

inl tag_rank = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Ranks |> fst
inl tag_suit = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Suits |> fst
   
inl deck _ =
    met knuth_shuffle rnd ln ar =
        inl swap i j =
            inl item = ar i
            ar i <- ar j
            ar j <- item

        Loops.for {from=0; near_to=ln-1; body=inl {i} -> swap i (rnd.next(to int32 i, to int32 ln))}

    inl unshuffled = 
        Tuple.map (inl rank ->
            Tuple.map (inl suit -> box Card {rank=box Rank rank; suit=box Suit suit}) Suits
            ) Ranks
        |> Tuple.concat

    inl ty = array Card
    inl ar = macro.fs ty [fs_array_args: unshuffled; text: ": "; type: ty]
    assert (array_length ar = num_cards) "The number of cards in the deck must be 52."
    inl rnd = Random()
    knuth_shuffle rnd num_cards ar

    inl rec facade p _ =
        inl x = p - 1
        ar x, facade x
    facade (dyn num_cards)

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32

met show_hand x =
    inl {rank=.(a) suit=.(b)} = x 
    string_format "{0}-{1}" (a, b)

inl log ->
    met showdown rule {state with players} =
        inl is_active {pot} = pot > 0

        log "Showdown:" ()
        Tuple.iter (met x ->
            if is_active x then
                match x.hand with
                | .Some, hand -> log "{0} shows {1}" (x.name, show_hand hand)
                | _ -> ()
            ) players

        inl old_chips = Tuple.map (inl {chips + pot} -> chips + pot) players

        met rec loop players =
            inl is_active = Tuple.map is_active players
            inl foldl f s players = Tuple.foldl2 (met s player is_active -> if is_active then f s player else s) s players is_active
            inl foldl_map f s players = Tuple.foldl_map2 (met s player is_active -> if is_active then f s player else player,s) s players is_active

            foldl (inl s player ->
                match s with
                | .Some, a ->
                    match player.hand with
                    | .Some, b -> if rule a b = 1i32 then Option.some a else Option.some b
                    | .None -> Option.some a
                | .None -> player.hand
                ) (Option.none Card)
            |> function
                | .Some, winning_hand ->
                    inl foldl_winners t f = 
                        foldl (inl s x ->
                            match x.hand with
                            | .Some, hand -> if rule winning_hand hand = 0i32 then f s x else s
                            | _ -> s
                            )
                    inl foldl_map_winners t f = 
                        foldl_map (inl s x ->
                            match x.hand with
                            | .Some, hand -> if rule winning_hand hand = 0i32 then f s x else x, s
                            | _ -> s
                            )

                    inl pot_take x {player with pot} -> 
                        inl x = min pot x
                        x, {player with pot=pot-x}

                    inl num_winners = foldl_winners (inl s _ -> s + 1) 0 players
                    inl min_pot = foldl (inl s {pot} -> min s pot) (macro.fs int64 [text: "System.Int64.MaxValue"]) players
                    inl pot, players = 
                        foldl (inl s x -> 
                            inl s', player = pot_take min_pot x
                            player, s + s') 0 players
                    inl could_be_odd = pot % num_winners <> 0
                    inl pot = pot / num_winners
                    foldl_map_winners (inl s x ->
                        inl odd_chip = if s && could_be_odd then 0 else 1
                        {x with chips=self + pot + odd_chip}, false
                        ) true players 
                    |> fst
                    |> loop
                | .None ->
                    Tuple.map (inl x -> x.chips) players
            : Tuple.map (inl x -> x.chips) players
        inl chips =
            Tuple.map (inl {hand chips pot} -> {hand chips pot}) players
            |> loop 

        inl rewards = 
            ...

        Tuple.iter2 (met old_chips x -> 
            inl chips = x.chips
            if old_chips < chips then log "{0} wins {1} chips." (x.name,chips-old_chips)
            elif old_chips > chips then log "{0} loses {1} chips." (x.name,old_chips-chips)
            else ()
            ) old_chips players

    """) |> module_