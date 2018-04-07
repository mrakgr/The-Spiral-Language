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
open Poker
one_card {player_chips=5; players={reply=reply_random; name="One"}, {reply=reply_random; name="Two"}}
    """

let poker2 =
    "poker2",[poker],"Does the rules based player work?",
    """
open Poker
one_card {player_chips=5; players={reply=reply_rules; name="One"}, {reply=reply_random; name="Two"}}
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" poker2
|> printfn "%s"
|> ignore

