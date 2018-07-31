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
inl r x = {from=.0; near_to=.(x); block=()}
inl a = Union.to_sparse (r 2,r 2,r 2) (0,dyn 1,dyn 1)
inl b = Union.to_sparse (Option.none (r 10)) (Option.none int64)
inl c = Union.to_sparse (Option.none (r 10)) (Option.some 5)
Console.writeline (a,b,c)
    """

let union2 =
    "union2",[union;option;extern_;console],"Does the from_sparse work?",
    """
inl r x = {from=.0; near_to=.(x); block=()}
()
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) union2
|> printfn "%s"
|> ignore

