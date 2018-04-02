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
    match state.phase with
    | .Dealing -> 
        inl f ante player =
            if player.chips >= ante then 
                inl card = state [pot.add: ante; deck.take]
                player [bet: ante; hand.set: card]
            else player.inactive

        Tuple.foldr (inl player ante -> f ante player; 1) players 2

    """) |> module_