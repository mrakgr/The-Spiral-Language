module File1

open Spiral.Lib
open Spiral.Tests
open System.IO
open System.Diagnostics

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = []
    trace_length = 20
    cuda_assert_enabled = false
    }

//rewrite_test_cache tests cfg None //(Some(0,40))

let example = 
    "example",[option;tuple;loops;extern_;console;host_tensor],"Module description.",
    """
inl f a b =
    inl c = a + b
    c + 3

f (dyn 1) (dyn 2)
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" loop7
|> printfn "%s"
|> ignore
