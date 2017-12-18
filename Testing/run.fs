module File1

open Spiral.Lib
open Spiral.Tests
open System.IO
open Learning

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
//if dyn true then
//    inl a,b = dyn (1,2)
//    inl _ -> a + b
//else
//    inl a,b = dyn (3,4)
//    inl _ -> a + b
    """

let test101 = 
    "test101",[],"Does `a` cause a hygiene violation by leaking its main argument into `inter`?",
    """
inl a = dyn 1

met rec inter x = 
    ignore x
    inter (dyn 2.0)
    : 2.0

inter a
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" test101
|> printfn "%s"
|> ignore
