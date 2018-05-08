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
    "serializer4",[cuda_modules;learning;serializer_one_hot;option],"Does greedy square selector function work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,3} |> dr s
s.CudaTensor.print x.primal
inl (v,a),bck = Selector.greedy_square x s
s.CudaTensor.print (v.primal,a)

s.CudaRandom.fill {dst=.Normal; stddev=1f32; mean=0f32} v.adjoint
s.CudaTensor.print x.adjoint
s.CudaTensor.print v.adjoint

bck 0.0
s.CudaTensor.print x.adjoint
    """

let serializer5 = 
    "serializer5",[cuda_modules;learning;option],"Does greedy square init function work?",
    """
inl Suits = .Spades :: () //, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.reducel (inl a b -> a \/ b) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.reducel (inl a b -> a \/ b) Ranks
inl Card = type {rank=Rank; suit=Suit}

inl Rep = type {pot=int64; chips=int64; hand=Option.none Card}
inl Action = .Fold \/ .Call \/ (.Raise, int64)

inb s = CudaModules (1024*1024)

inl float = float32
open Learning float

inl d = {bias=0.0; scale=1.0; range=10; state_type=Rep; action_type=Action}

inl net = RL.square_init d s
inl i = {pot=9; chips=0; hand=Option.some <| box Card {rank=box Rank .Five; suit=.Spades}}
inl action, bck = RL.action {d with net} i s
Console.writeline action
    """

let serializer6 = 
    "serializer6",[cuda_modules;learning;option],"Does greedy square bck function work?",
    """
inl Suits = .Spades :: () //, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.reducel (inl a b -> a \/ b) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.reducel (inl a b -> a \/ b) Ranks
inl Card = type {rank=Rank; suit=Suit}

inl Rep = type {pot=int64; chips=int64; hand=Option.none Card}
inl Action = .Fold \/ .Call \/ (.Raise, int64)

inb s = CudaModules (1024*1024)

inl float = float32
open Learning float

inl d = {range=10; state_type=Rep; action_type=Action}

inl net = RL.square_init d s
inl i = {pot=9; chips=0; hand=Option.some <| box Card {rank=box Rank .Five; suit=.Spades}}
Loops.for {from=0; near_to=10; body=inl _ ->
    s.refresh
    inb s = s.RegionMem.create'
    inl action, bck = RL.action {d with net} i s
    Console.writeline action
    bck -1.0
    Combinator.optimize net (Optimizer.sgd 0.2f32) s
    }
    """

let serializer7 =
    "serializer7",[cuda_modules;learning;serializer_one_hot;option],"Does greedy QR selector function work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,3,4} |> dr s
s.CudaTensor.print x.primal
inl (v,a),bck = Selector.greedy_qr x s
s.CudaTensor.print x.adjoint

bck -1.0
s.CudaTensor.print x.adjoint
    """

let serializer8 =
    "serializer8",[cuda_modules;learning],"Does QR cost function work?",
    """
// It does, just worse that MSE with Monte Carlo updates.
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl minibatch_size = 1

inl input_size = 128
inl hidden_size = 1

inl network = 
    open Feedforward.Layer

    inl label = input .label hidden_size
    inl network =
        input .input input_size 
        |> relu 128
        |> linear hidden_size 
        |> init s
    error (Error.hubert_qr 1.0f32) label network

inl train_images = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=1,minibatch_size,input_size}
inl train_labels = s.CudaKernel.init {dim=1,minibatch_size,hidden_size} (inl _ _ _ -> 10f32)

open Feedforward.Pass
open Body

inl cost =
    for {
        data={input=train_images; label=train_labels}
        body=grad_check { network }
        } s

string_format "Training: {0}" cost |> Console.writeline
    """

let poker4 =
    "poker4",[loops;poker;timer],"What is the winrate of the RL based players against the random one?",
    """
inl log _ _ = ()
open Poker log
inl a = {reply=reply_q {init=5f64; learning_rate=0.03f64; num_players=2}; name="One"; trace=term_cast (inl _ -> ()) float64}
inl b = {reply=reply_random; name="Two"}
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

let poker5 =
    "poker5",[cuda_modules;loops;poker;timer],"What is the winrate of the deep Q learning (square error feedforward) player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl log _ _ = ()
open Poker log
inl stack_size = 10
inl a' = {reply=reply_dq {bias=0.0; scale=to float64 stack_size; range=32; num_players=2} s; name="One"; trace=term_cast (inl _ -> ()) float64}
inl b' = {reply=reply_random; name="Two"}
Loops.for {from=0; near_to=10; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=1000; state=dyn {a=0; b=0}; body=inl {state i} ->
            s.refresh
            inb s = s.RegionMem.create'
            inl a,b = one_card stack_size ({a' with reply=self s |> heap}, b')
            a'.reply.optimize s 0.01f32
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
    "poker6",[cuda_modules;loops;poker;timer],"What is the winrate of the deep Q learning (QR feedforward) player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl log _ _ = ()
open Poker log
inl stack_size = 10
inl a' = {reply=reply_dq {distribution_size=64; bias=0.0; scale=to float64 stack_size; range=32; num_players=2} s; name="One"; trace=term_cast (inl _ -> ()) float64}
inl b' = {reply=reply_random; name="Two"}
Loops.for {from=0; near_to=10; body=inl {i} ->
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ ->
        Loops.for {from=0; near_to=1000; state=dyn {a=0; b=0}; body=inl {state i} ->
            s.refresh
            inb s = s.RegionMem.create'
            inl a,b = one_card stack_size ({a' with reply=self s |> heap}, b')
            a'.reply.optimize s 0.03f32
            match a.name with
            | "One" -> if a.chips > 0 then {state with a=self+1} else {state with b=self+1}
            | _ -> if a.chips > 0 then {state with b=self+1} else {state with a=self+1}
            }
        |> inl {a b} ->
            inl total = a + b
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,total)
    }
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" poker6
//|> printfn "%s"
|> ignore

