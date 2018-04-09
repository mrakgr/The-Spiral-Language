module Games.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Module
open Learning.Module

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

let poker4 =
    "poker4",[loops;poker;timer],"What is the winrate of the RL based players against the random one?",
    """
inl log _ _ = ()
open Poker log
inl a = {reply=reply_q {init=5f64; learning_rate=0.03f64; num_players=2}; name="One"; trace=term_cast (inl _ -> ()) float64}
inl b = {reply=reply_random; name="Two"}
one_card 10 (a, b) |> ignore
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" poker4
|> printfn "%s"
|> ignore
