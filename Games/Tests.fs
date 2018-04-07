module Games.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Module

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

let poker1 =
    "poker1",[poker],"Does the poker game work?",
    """
open Poker Console.printfn
one_card.init {player_chips=5; players={reply=reply_random; name="One"}, {reply=reply_random; name="Two"}}
|> one_card.game 
    """

let poker2 =
    "poker2",[poker],"Does the rules based player work?",
    """
open Poker Console.printfn
one_card.init {player_chips=5; players={reply=reply_rules; name="One"}, {reply=reply_random; name="Two"}}
|> one_card.game 
    """

let poker3 =
    "poker3",[loops;poker],"What is the winrate of the rules based players against the random one?",
    """
inl log _ _ = ()
open Poker log
inl player_chips = dyn 5
inl state = one_card.init {player_chips players={reply=reply_rules; name="One"}, {reply=reply_random; name="Two"}}
Loops.for {from=0; near_to=10000; state=dyn {a=0; b=0}; body=inl {state=s i} ->
    Tuple.iter (inl x -> x.data.chips <- player_chips) state.players
    one_card.game state
    inl a,b = state.players
    if a.chips = 0 then 
        assert (b.chips > 0) "If a is 0 then b much be positive."
        {s with b=self+1} 
    else 
        assert (b.chips = 0) "If a positive then b much 0."
        {s with a=self+1}
    }
|> inl {a b} ->
    inl total = a + b
    Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" poker3
|> printfn "%s"
|> ignore

