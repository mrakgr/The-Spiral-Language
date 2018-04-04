module Poker.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module

let poker =
    (
    "Poker",[],"The Poker module",
    """
inl showdown rule state =
    inl players = state.players
    
    met rec loop _ =
        Tuple.redulel (inl a b ->
            match a.hand, b.hand with
            | (.Some,a), (.Some,b) -> if rule a b then Option.some b else Option.some a
            | (.Some,x), _ | _,(.Some,x) -> Option.some x
            | _ -> Option.none card
            )
        |> function
            | .Some, winning_hand ->
                inl losing_players_pot = 
                    Tuple.foldl (inl s x -> 
                            match x.hand with
                            | .None -> s + x.pot
                            | .Some, x -> if winning_hand = x then s else s + x.pot
                        )
                Tuple.foldl (inl s player -> s + player.pot_take winning_player_pot) 0 players
                |> winning_player.chips_add
                loop ()
            | .None ->
                ()
        : ()
    loop ()

inl betting state =
    inl is_active x = x.chips > 0 && x.hand_is
    met f player next {d with players_called limit active_players} =
        if active_players > 1 && players_called < active_players then
            if is_active player then
                player.reply state.internal_representation
                    {
                    fold = inl _ -> player.fold; next {d with active_players=self-1}
                    call = inl _ -> player.call limit; next {d with players_called=self+1}
                    raise = inl x -> next {d with limit=player.raise limit x; players_called=dyn 0}
                    }
            else
                next d
        : ()
        
    inl players=state.players
    met rec loop d = Tuple.foldr f loop players {d with players_called=dyn 0} : ()
    loop {
        active_players = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 state.players |> dyn
        limit = Tuple.foldl (inl s x -> if is_active x then max s x.pot else s) 0 state.players |> dyn
        }

inl Suits = .Spades, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.redulel (\/) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.redulel (\/) Ranks
inl Card = type {rank=Rank; suit=Suit}

inl spades, clubs, hearts, diamonds = Tuple.map (box Suit) ()
inl two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace = Tuple.map (box Rank) Ranks
inl tag_rank = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) {} Ranks |> fst
inl tag_suit = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) {} Suits |> fst

inl player _ =
    inl data = 
        {
        chips=dyn 0
        hand=dyn (Option.None Card)
        pot=dyn 0
        } |> heapm

    inl call x =
        inl chips, pot = data.chips, data.pot
        inl x = min chips x
        data.chips <- chips - x
        data.pt <- pot + x

    function
    | .hand_set x -> data.hand <- Option.some x
    | .fold -> data.hand <- Option.None Card
    | .call x -> call x
    | .raise a b -> call (a + b)
    | .pot_take x -> 
        inl pot = data.pot
        inl x = min pot x
        data.pot <- pot - x; x
    | .chips_add x ->
        data.chips <- data.chips + x
    | .hand_is ->
        match data.hand with
        | .None -> false
        | _ -> true
    | x -> data x

inl one_card =
    inl hand_rule = inl a b -> tag_rank a.rank < tag_rank b.rank
    inl dealing = inl state ->
        inl is_active x = x.chips > 0
        inl f ante player =
            if is_active player then 
                if ante > 0 then player.call ante
                player.hand_set state.deck.take

        inl ante, big_ante = 1, 2
        inl rec loop = function
            | a :: b :: () -> f ante a; f big_ante b
            | a :: b -> f 0 a; loop b
        loop state.players

    inl is_finished state =
        inl is_active x = x.chips > 0
        inl active_players = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 state.players
        active_players = 1

    inl round state = 
        dealing state
        betting state
        showdown hand_rule state

    inl game =
        met rec loop state =
            round state
            if is_finished state then state else loop state
            : ()
        loop << init
    """) |> module_
