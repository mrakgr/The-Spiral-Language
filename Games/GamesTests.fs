module Games.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Module
open Learning.Cuda
open Learning.Main

let cfg = Spiral.Types.cfg_default

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

let poker_players =
    (
    "PokerPlayers",[player_random;player_tabular],"The poker players module.",
    """
inl {basic_methods State Action} ->
    inl player_random {name} =
        inl {action} = PlayerRandom {Action State}

        inl methods = {basic_methods with
            bet=inl s rep -> s.data.action rep .action
            showdown=inl s v -> ()
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; action}

    inl player_rules {name} =
        inl methods = {basic_methods with
            bet=inl s players -> 
                inl limit = Tuple.foldl (inl s x -> max s x.pot.value) 0 players
                /// TODO: Replace find with pick.
                inl self = Tuple.find (inl x -> match x.hand with .Some, _ -> true | _ -> false) players
                match self.hand with
                | .Some, x ->
                    match x.rank with
                    | .Ten | .Jack | .Queen | .King | .Ace -> 
                        inl {raise} = Tuple.find (function {raise} -> true | _ -> false) (split Action)
                        box Action {raise={raise with value=0}}
                    | _ -> if self.pot.value >= limit || self.chips.value = 0 then box Action .Call else box Action .Fold
                | .None -> failwith Action "No self in the internal representation."
            showdown=inl s v -> ()
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0}

    inl player_tabular_mc {name init learning_rate} =
        inl {action} = PlayerTabular {Action State init learning_rate}
        inl trace = ResizeArray.create {elem_type=type heap (action State .bck)}

        inl methods = {basic_methods with
            bet=inl s rep -> 
                inl {action bck} = s.data.action rep
                s.data.trace.add (heap bck)
                action
            showdown=inl s v -> s.data.trace.foldr (inl bck v -> bck v |> ignore; v) (dyn (to float32 v)) |> ignore; s.data.trace.clear
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; action trace}

    inl player_tabular_sarsa {name init learning_rate} =
        inl {action} = PlayerTabular {Action State init learning_rate}
        inl trace = ResizeArray.create {elem_type=type heap (action State .bck)}

        inl methods = {basic_methods with
            bet=inl s rep -> 
                inl {action bck} = s.data.action rep
                s.data.trace.add (heap bck)
                action
            showdown=inl s v -> s.data.trace.foldr (inl bck v -> bck v) (dyn (to float32 v)) |> ignore; s.data.trace.clear
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; action trace}

    inl player_pg {name net cd learning_rate} =
        inl {action} = PlayerPG {Action State}
        inl trace = ResizeArray.create {elem_type=type heap (action {net input=State} cd .bck)}
        inl net_type = Union.unroll (inl x -> action x cd .net) {net input=State}
        inl starting_net = net
        inl net = ref (box net_type net)

        inl methods = {basic_methods with
            bet=inl s rep ->
                match s.data.net () with
                | () | net -> // This is in order to trigger unboxing.
                    inl cd = s.data.cd
                    inl {action net bck} = s.data.action {net input=rep} cd
                    s.data.net := box net_type net
                    s.data.trace.add (heap bck)
                    action
            showdown=inl s v -> 
                s.data.trace.foldr (inl bck v -> bck v |> ignore; v) (dyn (to float32 v)) |> ignore
                s.data.trace.clear
                s.data.net := box net_type s.data.starting_net
                inl optimizer = Optimizer.sgd learning_rate
                match s.data.net () with
                | () | net -> // This is in order to trigger unboxing.
                    Struct.iter (inl {optimize} -> optimize optimizer) net
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; action trace net starting_net}

    {
    player_random player_rules player_tabular_mc player_tabular_sarsa player_pg
    } |> stackify
    """) |> module_

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
    "poker3",[cuda_modules;loops;poker;poker_players;timer],"The iterative test for NNs.",
    """
inb s = CudaModules (1024*1024*1024)
inl num_players = 2
inl stack_size = 10
inl max_stack_size = num_players * stack_size
open Poker {max_stack_size num_players}
open PokerPlayers {basic_methods State Action}
open Learning float32

inl input_size = Union.length_dense State
inl num_actions = Union.length_one_hot Action

inl net,_ =
    open Feedforward
    inl network = linear num_actions
    init s input_size network

inl a = player_pg {name="One"; net learning_rate=0.01f32}
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

f game 5 1000
//open Poker {max_stack_size num_players log=Console.printfn}
//f game 10 1
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) poker2
|> printfn "%s"
|> ignore
