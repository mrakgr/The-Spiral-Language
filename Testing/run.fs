module File1

open Spiral.Lib
open Spiral.Tests
open System.IO

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = @"C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.0"
    path_cub = @"C:\cub-1.7.4"
    path_vs2017 = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community"
    cuda_includes = []
    }

//rewrite_test_cache cfg None //(Some(0,40))

let example1 = 
    "example1",[],"",
    """
inl add a b = a + b
inl f = add 1
f 2, f 3
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example1
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example1
|> printfn "%s"
|> ignore
