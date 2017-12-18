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
inl npc = 
    {
    health = dyn 0
    mana = dyn 0
    max_health = 40
    max_mana = 30
    } |> stack

inl ar = array_create npc 3
ar 0 <- {npc with health = dyn 10; mana = dyn 20}
ar 1 <- {npc with health = dyn 20; mana = dyn 10}
//ar 2 <- {npc with health = dyn 10; mana = dyn 20; max_health = 50} // Gives a type error
()
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example1
|> printfn "%s"
|> ignore
