module File1

open Spiral.Lib
open Spiral.Tests
open System.IO
open System.Diagnostics

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = @"C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.0"
    path_cub = @"C:\cub-1.7.4"
    path_vs2017 = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community"
    cuda_includes = []
    }

//rewrite_test_cache cfg None //(Some(0,40))

let example = 
    "example",[option;tuple;loops;extern_;console;host_tensor],"Module description.",
    """
inl ar = array_create string 3
Tuple.foldl (inl i x -> ar i <- x; i+1) 0 ("zero","one","two") |> ignore
inl tns = HostTensor.init (3,5,{from=2; to=5}) (inl a ->
    inl x = ar a
    inl b c -> x, b, c
    )
inl f x = x 0 2 .get
tns 0 |> f |> Console.writeline
tns 1 |> f |> Console.writeline
tns 2 |> f |> Console.writeline
"""

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
