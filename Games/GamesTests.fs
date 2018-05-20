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

let poker1 =
    "poker1",[poker],"Does the poker game work?",
    """
open Poker {log=Console.printfn; num_players=2}
inl a = player_random {name="One"}
inl b = player_random {name="Two"}

game 10 (a,b)
    """

let poker2 =
    "poker2",[loops;poker;timer],"What is the winrate of the tabular (MC) RL based player against the random one?",
    """
//open Poker {log=Console.printfn; num_players=2}
open Poker {num_players=2}

inl a = player_mc {init=10f64; learning_rate=0.02f64; name="One"}
inl b = player_random {name="Two"}

met f (!dyn near_to) (!dyn near_to_inner) = 
    Loops.for {from=0; near_to body=inl {i} ->
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            inl a = a.data_add {win=ref 0}
            inl b = b.data_add {win=ref 0}
            Loops.for {from=0; near_to=near_to_inner; body=inl {state=s i} -> game 10 (a, b)}
            inl a = a.data.win ()
            inl b = b.data.win ()
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,a+b)
        }

f 10 100000
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) poker2
|> printfn "%s"
|> ignore

