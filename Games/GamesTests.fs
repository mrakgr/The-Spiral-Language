module Games.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Module
open Cuda.Lib
open Learning.Lib

let cfg = {Spiral.Types.cfg_default with cuda_assert_enabled=false}

let union1 =
    "union1",[union;option;extern_;console],"Does the to_sparse work?",
    """
inl r = Union.int {from=0; near_to=2}
inl a = Union.to_one_hot (r 0, r (dyn 1), r (dyn 1))
inl r = Union.int {from=0; near_to=10}
inl b = Union.to_one_hot (dyn (Option.none (type r int64)))
inl c = Union.to_one_hot ((Option.some (r 9)))
Console.writeline (a,b,c)
    """

let union2 =
    "union2",[union;option;extern_;console],"Does the from_sparse work?",
    """
inl test x =
    inl a = Union.to_one_hot x
    inl b = Union.from_one_hot x a
    assert (b = x) "The input and output should be equal." 
    Console.writeline b

inl r = Union.int {from=-1; near_to=2}
test (r 0, r (dyn 1), r (dyn 1))
inl r = Union.int {from=-2; near_to=10}
inl rint64 = type r int64

test (dyn (Option.none rint64))
test (Option.some (r 9))

inl Y = (.a,.123) \/ (.b, rint64)
test (box Y (.b, r 3))

inl Action = .Fold \/ .Call \/ (.Raise, rint64)
test (box Action (dyn (.Raise, r 7)))

inl Q = (rint64, rint64, rint64) \/ (rint64, rint64) \/ rint64
test (box Q (dyn (r 3, r 2)))

inl Q = {a=rint64; b=rint64; c=rint64} \/ {a=rint64; b=rint64} \/ {a=rint64}
inl a,b,c = r 3, r 2, r 1
test (join Option.some (box Q {a}))
test (Option.some (box Q {a b}))
test (dyn <| Option.some (box Q {a b c}))
    """

let union3 =
    "union3",[union;option;extern_;console],"Does the to_dense work?",
    """
inl r = Union.int {from=0; near_to=2}
inl a = Union.to_dense (r 0, r (dyn 1), r (dyn 1))
inl r = Union.int {from=0; near_to=10}
inl b = Union.to_dense (dyn (Option.none (type r int64)))
inl c = Union.to_dense (Option.some (r 9))
Console.writeline (a,b,c)
    """

let union4 =
    "union4",[union;option;extern_;console],"Does the from_dense work?",
    """
inl test x =
    inl a = Union.to_dense x
    inl b = Union.from_dense x a
    assert (b = x) "The input and output should be equal." 
    Console.writeline b

inl r = Union.int {from=-1; near_to=2}
test (r 0, r (dyn 1), r (dyn 1))
inl r = Union.int {from=-2; near_to=10}
inl rint64 = type r int64

test (dyn (Option.none rint64))
test (Option.some (r 9))

inl Y = (.a,.123) \/ (.b, rint64)
test (box Y (.b, r 3))

inl Action = .Fold \/ .Call \/ (.Raise, rint64)
test (box Action (dyn (.Raise, r 7)))

inl Q = (rint64, rint64, rint64) \/ (rint64, rint64) \/ rint64
test (box Q (dyn (r 3, r 2)))

inl Q = {a=rint64; b=rint64; c=rint64} \/ {a=rint64; b=rint64} \/ {a=rint64}
inl a,b,c = r 3, r 2, r 1
test (join Option.some (box Q {a}))
test (Option.some (box Q {a b}))
test (dyn <| Option.some (box Q {a b c}))
    """

let poker1 =
    "poker1",[poker;poker_players],"Does the poker game work?",
    """
inl log = Console.printfn
inl num_players = 2
inl max_stack_size = 32
open Poker {log max_stack_size num_players}
open PokerPlayers {basic_methods State Action}

inl a = player_random {name="One"}
inl b = player_rules {name="Two"}
inl c = player_tabular_mc {name="Three"; init=8f32; learning_rate=0.01f32}

game 10 (a,c)
    """

let poker2 =
    "poker2",[cuda_modules;loops;poker;poker_players;timer],"The iterative test.",
    """
//inb s = CudaModules (1024*1024*1024)
inl num_players = 2
inl stack_size = 10
inl max_stack_size = num_players * stack_size
open Poker {max_stack_size num_players}
open PokerPlayers {basic_methods State Action}

inl a = player_tabular_sarsa {name="One"; init=10f32; learning_rate=0.01f32}
//inl a = player_random {name="One"}
inl b = player_rules {name="Two"}

met f game (!dyn near_to) (!dyn near_to_inner) = 
    Loops.for {from=0; near_to body=inl {i} ->
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            //s.refresh
            //inb s = s.RegionMem.create'
            //inl a = a.data_add {win=ref 0; state=ref (box_net_state a.net {} s); cd=s}
            inl a = a.data_add {win=ref 0}
            inl b = b.data_add {win=ref 0}
            Loops.for {from=0; near_to=near_to_inner; body=inl {state=s i} -> game stack_size (a, b)}
            inl a = a.data.win ()
            inl b = b.data.win ()
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,a+b)
        }

f game 30 100000
//open Poker {max_stack_size num_players log=Console.printfn}
//f game 10 1
    """

let poker3 =
    "poker3",[cuda_modules;loops;poker;poker_players;timer],"The iterative test for NN based players.",
    """
inb s = CudaModules (1024*1024*1024)
inl num_players = 2
inl stack_size = 10
inl max_stack_size = num_players * stack_size
open Poker {max_stack_size num_players}
open PokerPlayers {basic_methods State Action}

Loops.for {from=0; near_to=1; body=inl {i} ->
    inb s = s.RegionMem.create'
    s.CudaRandom.set_pseudorandom_seed (to uint64 i)

    Console.writeline "------"
    Console.printfn "The CudaRandom pseudorandom seed is {0}" i

    inl a = 
        open (Learning float32).Feedforward
        player_pg {name="One"; actor=tanh 256; learning_rate=0.001f32} s
    //inl a = player_zap_q {name="One"; steps_until_inverse_update=128; learning_rate=0.0001f32; discount_factor=0.99f32} s
    inl b = player_rules {name="Two"}

    met f game (!dyn near_to) (!dyn near_to_inner) = 
        Loops.for {from=0; near_to body=inl {i} ->
            Timer.time_it (string_format "iteration {0}" i)
            <| inl _ ->
                s.refresh
                inb s = s.RegionMem.create'
                inl a = a.data_add {win=ref 0; cd=s}
                inl b = b.data_add {win=ref 0; cd=s}
                Loops.for {from=0; near_to=near_to_inner; body=inl {state=s i} -> game stack_size (a, b)}
                inl a = a.data.win ()
                inl b = b.data.win ()
                Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,a+b)
            }

    f game 15 1000
    //open Poker {max_stack_size num_players log=Console.printfn}
    //f game 10 1
    }
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) poker3
|> printfn "%s"
|> ignore

