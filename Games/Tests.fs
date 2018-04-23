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

let serializer1 =
    "serializer1",[serializer_one_hot;option],"Does the one-hot encoder work?",
    """
inl a = SerializerOneHot.encode 2 (0,dyn 1,dyn 1)
inl b = SerializerOneHot.encode 10 (Option.none int64)
inl c = SerializerOneHot.encode 10 (Option.some 5)
()
    """

let serializer2 =
    "serializer2",[serializer_one_hot;option],"Does the one-hot encoder work for nesten union types?",
    """
inl Y = (.a,.123) \/ (.b,int64)
inl y = box Y (.b,3)
inl a = SerializerOneHot.encode 10 (dyn 1,Option.some y)
()
    """

let serializer3 =
    "serializer3",[serializer_one_hot;option],"Does the one-hot decoder work?",
    """
inl test msg r x' =
    inl x = SerializerOneHot.encode r x'
    inl r = x' = SerializerOneHot.decode r x x'
    assert r msg

test "a" 2 (0, dyn 1, dyn 1)
test "b" 10 (Option.none int64)
test "c" 10 (Option.some 5)

inl Action = .Fold \/ .Call \/ (.Raise, int64)
test "d" 10 (dyn 1,Option.some (box Action (.Raise,7)))
test "e" 10 (dyn 1,Option.some (box Action .Call))
test "g" 10 (dyn 1,Option.none Action)

inl Q = (int64,int64,int64) \/ (int64,int64) \/ int64
test "h1" 5 (join Option.some (box Q (3)))
test "h2" 5 (Option.some (box Q (3,2)))
test "h3" 5 (Option.some (box Q (3,2,1)))

inl Q = {a=int64; b=int64; c=int64} \/ {a=int64; b=int64} \/ {a=int64}
inl a,b,c = 3,2,1
test "j1" 5 (join Option.some (box Q {a}))
test "j2" 5 (Option.some (box Q {a b}))
test "j3" 5 (Option.some (box Q {a b c}))
    """

let serializer4 =
    "serializer4",[serializer_one_hot;option],"Do serialization functions work on the GPU?",
    """
inl Action = .Fold \/ .Call \/ (.Raise, int64)
inl encode = SerializerOneHot.encode 10
inl x = (.Raise, 7) |> box Action |> Option.some |> dyn |> encode
()
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" serializer3
|> printfn "%s"
|> ignore

