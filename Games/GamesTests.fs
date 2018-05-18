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

//output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) poker6
//|> printfn "%s"
//|> ignore

