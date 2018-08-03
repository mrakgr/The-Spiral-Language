module Games.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Module
open Learning.Cuda
open Learning.Main

let cfg = Spiral.Types.cfg_default

let poker1 =
    "poker1",[poker],"Does the poker game work?",
    """
inl log = Console.printfn
inl num_players = 2
inl max_stack_size = 32
open Poker {log max_stack_size num_players}

inl a = player_random {name="One"}
inl b = player_random {name="Two"}

game 10 (a,b)
    """

let union1 =
    "union1",[union;option;extern_;console],"Does the to_sparse work?",
    """
inl r = Union.int {from=0; near_to=2}
inl a = Union.to_one_hot (r 0, r (dyn 1), r (dyn 1))
inl r = Union.int {from=0; near_to=10}
inl b = Union.to_one_hot (dyn (Option.none (r int64)))
inl c = Union.to_one_hot ((Option.some (r 9)))
Console.writeline (a,b,c)
    """

let union2 =
    "union2",[union;option;extern_;console],"Does the from_sparse work?",
    """
inl r x = {from=.0; near_to=.(x); block=()}
inl test ty x =
    inl a = Union.to_sparse ty x
    inl b = Union.from_sparse ty (fst a)
    assert (b = x) "The input and output should be equal." 
    Console.writeline b

test (r 2,r 2,r 2) (0,dyn 1,dyn 1)
test (Option.none (r 10)) (Option.none int64)
test (Option.none (r 10)) (Option.some 5)
    """

let union3 =
    "union3",[union;option;extern_;console],"Does the to_dense work?",
    """
inl r x = {from=.0; near_to=.(x); block=()}
inl a = Union.to_dense (r 2,r 2,r 2) (0,dyn 0,dyn 0)
inl b = Union.to_dense (Option.none (r 10)) (dyn (Option.none int64))
inl c = Union.to_dense (Option.none (r 10)) ((Option.some 9))
Console.writeline (a,b,c)
    """

let union4 =
    "union4",[union;option;extern_;console],"Does the from_dense work?",
    """
inl r x = {from=.0; near_to=.(x); block=()}
inl test ty x =
    inl a = Union.to_dense ty x
    inl b = Union.from_dense ty a
    assert (b = x) "The input and output should be equal." 
    Console.writeline b

//test (r 2,r 2,r 2) (0,dyn 1,dyn 1)
//test (Option.none (r 10)) (Option.none int64)
//test (Option.none (r 10)) (dyn (Option.some 5))
//inl Y = (.a,.123) \/ (.b,r 10)
//test Y (Union.box Y (.b, 3))

//inl Action = .Fold \/ .Call \/ (.Raise, r 10)
//test Action (Union.box Action (dyn (.Raise,7)))

inl Q = (r 5,r 5,r 5) \/ (r 5,r 5) \/ r 5
test Q (Union.box Q (dyn (3,2)))

//inl Q = {a=int64; b=int64; c=int64} \/ {a=int64; b=int64} \/ {a=int64}
//inl a,b,c = 3,2,1
//test "j1" 5 (join Option.some (box Q {a}))
//test "j2" 5 (Option.some (box Q {a b}))
//test "j3" 5 (Option.some (box Q {a b c}))
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) union1
|> printfn "%s"
|> ignore

