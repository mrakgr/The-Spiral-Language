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
    "poker3",[cuda_modules;loops;poker;poker_players;timer],"The iterative test for NN MC based players.",
    """
inb s = CudaModules (1024*1024*1024)
Struct.iter (inl i ->
    inl learning_rate = 2f32 ** to float32 i |> dyn
    Console.printfn "The learning_rate is 2 ** {0}" i
    Loops.for {from=0; near_to=10; body=inl {i} ->
        inl num_players = 2
        inl stack_size = 10
        inl max_stack_size = num_players * stack_size
        open Poker {max_stack_size num_players}
        open PokerPlayers {basic_methods State Action}

        s.refresh
        inb s = s.RegionMem.create'
        s.CudaRandom.set_pseudorandom_seed (to uint64 i)

        Console.writeline "------"
        Console.printfn "The CudaRandom pseudorandom seed is {0}" i

        inl pars = {rate={weight=learning_rate; covariance=learning_rate ** 0.85f32}}
        inl s = s.data_add pars

        inl a =
            open (Learning float32)
            inl net = RNN.rnn 512
            player_ac {net name="One"; discount=0.99f32} s 
        inl b = player_rules {name="Two"}

        met f game (!dyn near_to) (!dyn near_to_inner) = 
            Loops.for {from=0; near_to body=inl {i} ->
                Timer.time_it (string_format "iteration {0}" i)
                <| inl _ ->
                    inl a = a.data_add {win=ref 0}
                    inl b = b.data_add {win=ref 0}
                    Loops.for {from=0; near_to=near_to_inner; body=inl {i} -> 
                        s.refresh
                        inb cd = s.RegionMem.create'
                        inl a = a.data_add {cd}
                        inb cd = s.RegionMem.create'
                        inl b = b.data_add {cd}
                        game stack_size (a, b)
                        }
                    inl a = a.data.win ()
                    inl b = b.data.win ()
                    Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,a+b)
                }

        f game 15 1000
        //open Poker {max_stack_size num_players log=Console.printfn}
        //f game 10 1
        }
    ) (-13)
    """

let grid1 =
    "grid1",[cuda_modules;loops;timer],"The Gridworld (Sea) test.",
    """
inl n = 50
inl reward {row col} =
    if row = col then 0.01 / to float64 n + (if row = n - 1 then 1.0 else 0.0)
    else 0.0

inl transition action {row col} ret =
    inl row = row + 1
    if row = n then ret .End
    else
        inl col =
            match action with
            | .Left -> 
                inl col = col - 1
                if col < 0 then 0 else col
            | .Right -> 
                inl col = col + 1
                if col >= n then n - 1 else col           
        ret {row col}

inl Position = Union.int {from=0; near_to=n}
inl observe = Struct.map Position
inl Observation = type observe {row=int64; col=int64}
inl Action = type .Left \/ .Right

inl game player =
    Loops.for' {from=0; near_to=n; state={row=0; col=0}
        body=inl {state i next} ->
            player.observe (observe state)
            player.reward (reward state)
            transition player.action state <| function
            | .End -> player.game_over
            | state -> next state
        finally=ignore
        }

inl player_tabular_sarsa {Action State init learning_rate} =
    inl {action} = PlayerTabular {Action State init learning_rate}
    inl Reward = type float64
    inl History = type State \/ Action \/ Reward
    inl buffer = ResizeArray.create {elem_type=History}
    inl trace = ResizeArray.create {elem_type=heap (action State .bck)}

    inl methods = {
        observe=inl s rep -> s.data.buffer.add (box History rep)
        reward=inl s v -> s.data.buffer.add (box History v)
        action=inl s ->
            inl hist = get_latest_slice s.data.buffer
            inl {action bck} = s.data.action rep
            s.data.trace.add (heap bck)
            action
        game_over=inl s ->
            s.data.trace.foldr (inl bck v -> bck v) (dyn (to float32 v)) |> ignore; s.data.trace.clear
        }

    Object
        .member_add methods
        .data_add {name; win=ref 0; action trace buffer}

()
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) grid1
|> printfn "%s"
|> ignore

