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
open Poker Console.printfn
one_card 5 ({reply=reply_random; name="One"}, {reply=reply_random; name="Two"})
|> ignore
    """

let poker2 =
    "poker2",[poker],"Does the rules based player work?",
    """
open Poker Console.printfn
one_card 5 ({reply=reply_rules; name="One"}, {reply=reply_random; name="Two"})
|> ignore
    """

let poker3 =
    "poker3",[loops;poker],"What is the winrate of the rules based players against the random one?",
    """
inl log _ _ = ()
open Poker log
Loops.for {from=0; near_to=10000; state=dyn {a=0; b=0}; body=inl {state=s i} ->
    inl a,b = one_card 6 ({reply=reply_rules; name="One"}, {reply=reply_random; name="Two"})
    match a.name with
    | "One" -> if a.chips > 0 then {s with a=self+1} else {s with b=self+1}
    | _ -> if a.chips > 0 then {s with b=self+1} else {s with a=self+1}
    }
|> inl {a b} ->
    inl total = a + b
    Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
    """

let poker4 =
    "poker4",[loops;poker;timer],"What is the winrate of the RL based players against the random one?",
    """
inl log _ _ = ()
open Poker log
inl a = {reply=reply_q {init=5f64; learning_rate=0.03f64; num_players=2}; name="One"; trace=term_cast (inl _ -> ()) float64}
inl b = {reply=reply_random; name="Two"}
Loops.for {from=0; near_to=100; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=10000; state=dyn {a=0; b=0}; body=inl {state=s i} ->
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

let poker5 =
    "poker5",[loops;poker;timer],"What is the winrate of the deep Q learning feedforward based player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl log _ _ = ()
open Poker log
inl a = {reply=reply_dq {scale=10.0; init=0f64; learning_rate=0.01f64; num_players=2} s; name="One"; trace=term_cast (inl _ -> ()) float64}
inl b = {reply=reply_random; name="Two"}
Loops.for {from=0; near_to=10; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=100; state=dyn {a=0; b=0}; body=inl {state=s i} ->
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

let encoder1 =
    "encoder1",[loops;poker;timer],"Does the one-hot encoder work?",
    """
open Poker log
inl state_type = Rep
inl Serializer = 
    inl range ranges = function
        | x : int64 ->
            match ranges.int64 with
            | {from near_to} as r -> r
            | near_to ->
                assert (near_to >= 0) "Integer ranges go from 0."
                {from=0; near_to}
        | _ -> error_type "Only int64 ranges supported for now."

    inl span ranges = function
        | x : int64 ->
            match ranges.int64 with
            | {from near_to} as r -> near_to - from
            | near_to ->
                assert (near_to >= 0) "Integer ranges go from 0."
                near_to
        | _ -> error_type "Only int64 ranges supported for now."

    inl in_range ranges = function
        | x : int64 ->
            inl {from near_to} = range ranges int64
            assert (x >= from) "x must be greater or equal to its lower bound."
            assert (x < near_to) "x must be lesser than its lower bound."
            x
        | _ -> error_type "Only int64 ranges supported for now."

    {
    encode = inl ranges ty ->
        inl var_is = caseable_box_in >> not
        match ty with
        | x : int64 -> 
            assert (in_range ranges x) "x is out of range."
            x
    }
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" encoder1
|> printfn "%s"
|> ignore
