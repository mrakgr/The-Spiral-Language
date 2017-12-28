module File1

open Spiral.Lib
open Spiral.Tests
open System.IO
open Learning
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
inl toa_map f =
    inl rec loop = function
        | x when caseable_is x -> f x
        | x :: x' -> loop x :: loop x'
        | () -> ()
        | {!toa_map_block} & x -> module_map (const loop) x
        | x -> f x
    loop

inl toa_map2 f a b =
    inl rec loop = function
        | x, y when caseable_is x || caseable_is y -> f x y
        | x :: x', y :: y' -> loop (x,y) :: loop (x',y')
        | (),() -> ()
        | {!toa_map_block} & x, {!toa_map_block} & y -> module_map (inl k y -> loop (x k, y)) y
        | x, y -> f x y
    loop (a,b)

inl toa_array_create typ size = toa_map (inl x -> array_create x size) typ
inl toa_index ar idx = toa_map (inl ar -> ar idx) ar
inl toa_set ar idx v = toa_map2 (inl ar v -> ar idx <- v) ar v |> ignore

inl ar = toa_array_create {x=int64; y=int64,int64; o=Option.Option float32} 8
toa_set ar 0 {x=2; y=1,1; o=Option.some 2.2f32}
()
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
