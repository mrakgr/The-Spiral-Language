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
    "poker4",[loops;poker;timer;list],"What is the winrate of the RL based players against the random one?",
    """
inl log _ _ = ()
open Poker log

inl {state_type action_type reply} = reply_q {init=5f64; learning_rate=0.03f64; num_players=2}

inl bet_type = .Bet, state_type, action_type, float64 => ()
inl reward_type = .Reward, float64
inl trace_type = bet_type \/ reward_type

inl rec trace l = function
    | .add_bet (state,action,bck) -> 
        inl bck = term_cast bck float64
        inl x = box trace_type (.Bet,state,action,bck)
        List.cons x l |> dyn |> trace
    | .add_reward x -> 
        inl x = box trace_type (.Reward, x)
        List.cons x l |> dyn |> trace
    | .process -> 
        List.foldl (inl s x -> 
            match x with
            | .Reward, x -> s + x
            | .Bet,(_,_,bck) -> bck s; s
            ) (dyn 0) l 
        |> ignore
        
inl a = {reply name="One"; state=(); trace=trace (List.empty trace_type)}

inl rec trace = function
    | .add_bet _ -> trace
    | .add_reward _ -> trace
    | .process -> ()

inl b = {reply=reply_random; name="Two"; state=(); trace}

Loops.for {from=0; near_to=10; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=1000; state=dyn {a=0; b=0}; body=inl {state=s i} ->
            inl a,b = one_card 10 (a, b)
            match a.name with
            | "One" -> if a.chips > 0 then {s with a=self+1} else {s with b=self+1}
            | _ -> if a.chips > 0 then {s with b=self+1} else {s with a=self+1}
            }
        |> inl {a b} ->
            inl total = a + b
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
    }
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" poker4
|> printfn "%s"
|> ignore
