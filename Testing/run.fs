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

rewrite_test_cache cfg None //(Some(0,40))

let example = 
    "example",[tuple;console],"Module description.",
    """
type List x =
    ()
    x, List x

inl empty x = box (List x) ()
inl singleton x = box (List x) (x, empty x)
inl cons a b = 
    inl t = List a
    box t (a, box t b)

singleton 3 |> cons 2 |> cons 1
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
