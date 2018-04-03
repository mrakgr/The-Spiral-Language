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
        inl is_active x = x.pot > 0 && x.hand_is
        inl winning_player = 
            Tuple.redulel (inl a b ->
                if is_active a && is_active b then
                    if rule a.hand b.hand then a else b
                elif is_active a then a
                else b
                )

        if is_active winning_player then
            inl winning_player_pot = winning_player.pot
            Tuple.foldl (inl s player -> s + player.pot_take winning_player_pot) 0 players
            |> winning_player.chips_add
            loop ()
        : ()
    loop()

inl betting state =
    inl is_active x = x.chips > 0 && x.hand_is
    met f player next {d with players_called limit active_players} =
        if active_players > 1 && players_called < active_players then
            if is_active player then
                player.reply state.internal_representation
                    {
                    fold = inl _ -> player.fold; next {d with active_players=self-1}
                    call = inl _ -> player.call limit; next {d with players_called=self+1}
                    raise = inl x -> next {d with limit=player.raise limit x}
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

/// One card poker dealing function.
inl one_card_dealing state =
    inl is_active x = x.chips > 0
    inl f ante player =
        if is_active player then 
            player.call ante
            player.hand_set state.deck.take

    inl ante, big_ante = 1, 2
    inl rec loop = function
        | a :: b :: () -> f ante; f big_ante
        | a :: b -> loop b
    loop state.players
    """) |> module_
