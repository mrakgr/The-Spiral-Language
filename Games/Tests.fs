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

let serializer =
    (
    "Serializer",[tuple],"The Serializer module.",
    """
inl rec template f x =
    inl encode = template f
    inl prod (i,s) x = 
        inl i',s' = encode x
        i + i' * s, s * s'

    inl sum s x =
        inl i',s' = encode x
        s + i', s + s'

    match x with
    | x when caseable_box_is x -> case_foldl_map sum 0 x
    | _ :: _ as x -> Tuple.foldl prod (0,1) x
    | .(_) | () -> 0,1
    | {!block} as x -> module_foldl (const prod) (0,1) x
    | x -> f x

inl assert_range r x =
    inl {from near_to} = match r with {from near_to} -> r | near_to -> {from=0; near_to}
    assert (x >= from) "x must be greater or equal to its lower bound."
    assert (x < near_to) "x must be lesser than its lower bound."
    x, near_to - from

inl encode = template << assert_range

{
template 
encode
} |> stackify
    """) |> module_

let encoder1 =
    "encoder1",[serializer;option],"Does the one-hot encoder work?",
    """
inl a = Serializer.encode 2 (0,dyn 1,dyn 1)
inl b = Serializer.encode 10 (Option.none int64)
inl c = Serializer.encode 10 (Option.some 5)
()
    """

let encoder2 =
    "encoder2",[serializer;option],"Does the one-hot encoder work for nesten union types?",
    """
inl Y = (.a,.123) \/ (.b,int64)
inl y = box Y (.b,3)
inl a = Serializer.encode 10 (dyn 1,Option.some y)
()
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" encoder2
|> printfn "%s"
|> ignore

