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
test (dyn (Option.none (type r int64)))
test (Option.some (r 9))

inl Y = (.a,.123) \/ (.b, r int64)
test (box Y (.b, r 3))

inl Action = .Fold \/ .Call \/ (.Raise, r int64)
test (box Action (dyn (.Raise, r 7)))

inl Q = (r int64,r int64,r int64) \/ (r int64,r int64) \/ r int64
test (box Q (dyn (r 3, r 2)))

inl Q = {a=r int64; b=r int64; c=r int64} \/ {a=r int64; b=r int64} \/ {a=r int64}
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
test (dyn (Option.none (type r int64)))
test (Option.some (r 9))

inl Y = (.a,.123) \/ (.b, r int64)
test (box Y (.b, r 3))

inl Action = .Fold \/ .Call \/ (.Raise, r int64)
test (box Action (dyn (.Raise, r 7)))

inl Q = (r int64,r int64,r int64) \/ (r int64,r int64) \/ r int64
test (box Q (dyn (r 3, r 2)))

inl Q = {a=r int64; b=r int64; c=r int64} \/ {a=r int64; b=r int64} \/ {a=r int64}
inl a,b,c = r 3, r 2, r 1
test (join Option.some (box Q {a}))
test (Option.some (box Q {a b}))
test (dyn <| Option.some (box Q {a b c}))
    """

let poker1 =
    "poker1",[poker;player_random],"Does the poker game work?",
    """
inl log = Console.printfn
inl num_players = 2
inl max_stack_size = 32
open Poker {log max_stack_size num_players}

inl a = player_random {name="One"}
inl b = player_random {name="Two"}

game 10 (a,b)
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) poker1
|> printfn "%s"
|> ignore
