module Spiral.Tests
open System.IO

open Spiral.ParserCombinators
open Spiral.Compile

let cfg = {
    trace_length = 20
    filter_list = []
    }

let test1: SpiralModule =
    {
    name="test1"
    prerequisites=[]
    description="Does it run?"
    code=
    """
inl main _ =
    inl a = 5
    inl b = 10
    dyn (a + b)
    """
    }

let test2: SpiralModule =
    {
    name="test2"
    prerequisites=[]
    description="Do the join points work?"
    code=
    """
inl main _ =
    inl a () = join 5
    inl b () = join 10
    a () + b ()
    """
    }

let test3: SpiralModule =
    {
    name="test3"
    prerequisites=[]
    description="Does `dyn` work?"
    code=
    """
inl main _ =
    inl a = dyn 5
    inl b = dyn 10
    a + b
    """
    }

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) test3
|> printfn "%s"
|> ignore
