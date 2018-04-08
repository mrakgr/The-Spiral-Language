module Games.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Module

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

let dict1 =
    "dict1",[dictionary],"",
    """
inl x = Dictionary {elem_type=string,int64}
x.set "One" 1
x "One" {
    on_succ = id
    on_fail = const -1
    } |> ignore

x "Two" {
    on_succ = id
    on_fail = const -1
    } |> ignore
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" dict1
|> printfn "%s"
|> ignore

