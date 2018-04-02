module Poker.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module

let poker =
    (
    "Poker",[],"The Poker module",
    """
/// The bot that just predictably goes all in.
inl aggrobot state = .AllIn

/// The controller for the one card poker game.
inl one_card_poker state players =
    match phase with
    | .Dealing -> 
        inl f ante player state =
            if player.chips >= ante then 
                inl card, state = state .pot_add ante .deck.take
                player.chips_remove ante .hand_set card, state
            else player.inactive, state

        Tuple.foldr_map (inl player {ante state} -> 
            inl player,state = f ante player state
            player, {ante=1; state}
            ) players {ante=2; state}

    """) |> module_