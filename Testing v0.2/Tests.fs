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
inl a = 5
inl b = 10
dyn (a + b)
    """
    }

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) test1
|> printfn "%s"
|> ignore
