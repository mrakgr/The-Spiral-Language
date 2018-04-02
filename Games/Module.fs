module Poker.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module

let poker =
    (
    "Poker",[],"The Poker module",
    """
inl aggrobot state = .AllIn

inl response_raise player x =
    player.reply (.Raise, x)
    """) |> module_