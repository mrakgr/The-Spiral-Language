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

inl a = reply_q {init=5f64; learning_rate=0.03f64; num_players=2; name="One"}
inl b = reply_random {name="Two"}

met f (!dyn near_to) (!dyn nb) = 
    Loops.for {from=0; near_to body=inl {i} ->
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            Loops.for {from=0; near_to=nb; state=dyn {a=0; b=0}; body=inl {state=s i} ->
                inl a,b = one_card 10 (a, b)
                match a.name with
                | "One" -> if a.chips > 0 then {s with a=self+1} else {s with b=self+1}
                | _ -> if a.chips > 0 then {s with b=self+1} else {s with a=self+1}
                }
            |> inl {a b} ->
                inl total = a + b
                Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
        }

f 10 10000
f 10 1000
    """

let poker5 =
    "poker5",[cuda_modules;loops;poker;timer],"What is the winrate of the deep MC learning (square error feedforward) player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl log _ _ = ()
open Poker log
inl stack_size = 10
inl a' = reply_dmc {bias=0.0; scale=to float64 stack_size; range=32; num_players=2; name="One"} s
inl b' = reply_random {name="Two"}
Loops.for {from=0; near_to=10; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=1000; state=dyn {a=0; b=0}; body=inl {state i} ->
            s.refresh
            inb s = s.RegionMem.create'
            inl a,b = one_card stack_size ({a' with reply=self s |> heap}, b')
            a'.optimize 0.01f32 s
            match a.name with
            | "One" -> if a.chips > 0 then {state with a=self+1} else {state with b=self+1}
            | _ -> if a.chips > 0 then {state with b=self+1} else {state with a=self+1}
            }
        |> inl {a b} ->
            inl total = a + b
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
    }
    """

let poker6 =
    "poker6",[cuda_modules;loops;poker;timer],"What is the winrate of the deep MC learning (QR feedforward) player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl log _ _ = ()
open Poker log
inl stack_size = 10
inl a' = reply_dmc {distribution_size=64; bias=0.0; scale=to float64 stack_size; range=32; num_players=2; name="One"} s
inl b' = reply_random {name="Two"}
Loops.for {from=0; near_to=10; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=1000; state=dyn {a=0; b=0}; body=inl {state i} ->
            s.refresh
            inb s = s.RegionMem.create'
            inl a,b = one_card stack_size ({a' with reply=self s |> heap}, b')
            a'.optimize 0.01f32 s
            match a.name with
            | "One" -> if a.chips > 0 then {state with a=self+1} else {state with b=self+1}
            | _ -> if a.chips > 0 then {state with b=self+1} else {state with a=self+1}
            }
        |> inl {a b} ->
            inl total = a + b
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
    }
    """

let poker7 =
    "poker7",[cuda_modules;loops;poker;timer],"What is the winrate of the deep MC learning (KL feedforward) player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl log _ _ = ()
open Poker log
inl stack_size = 10
inl a' = reply_dmc {reward_range={from=-32; near_to=32}; bias=0.0; scale=1.0; range=32; num_players=2; name="One"} s
inl b' = reply_random {name="Two"}
Loops.for {from=0; near_to=10; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=1000; state=dyn {a=0; b=0}; body=inl {state i} ->
            s.refresh
            inb s = s.RegionMem.create'
            inl a,b = one_card stack_size ({a' with reply=self s |> heap}, b')
            a'.optimize 0.001f32 s
            match a.name with
            | "One" -> if a.chips > 0 then {state with a=self+1} else {state with b=self+1}
            | _ -> if a.chips > 0 then {state with b=self+1} else {state with a=self+1}
            }
        |> inl {a b} ->
            inl total = a + b
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
    }
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) poker5
//|> printfn "%s"
|> ignore

