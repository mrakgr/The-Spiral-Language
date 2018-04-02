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
inl one_card_poker phase state =
    inl players = state.players
    match phase with
    | .Dealing -> 
        inl f ante player =
            if player.chips > 0 then 
                player [bet: ante; hand.set: state.deck.take]

        inl ante, big_ante = 1, 2
        match players with
        | a,b -> f ante; f big_ante
        | _ -> error_type "Only two players supported for the time being."

        .Betting

    | .Betting ->
        met rec loop is_done =
            if is_done then .Showdown
            else
                Tuple.foldl (inl is_done player ->
                    if player.chips = 0 then is_done
                    else is_done && betting player state
                    ) true players
                |> loop
            : .Showdown

        loop false

    | .Showdown -> showdown Rule.one_card state
    """) |> module_