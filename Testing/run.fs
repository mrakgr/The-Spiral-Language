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

//inl ar = toa_array_create {x=int64; y=int64,int64; o=Option.Option float32} 8
//toa_set ar 0 {x=2; y=1,1; o=Option.some 2.2f32}

/// Creating a nd tensor
inl tensor_create {dsc with typ dim} =
    inl dim = match dim with _ :: _ -> dim | x -> x :: ()
    inl array_size :: size = Tuple.scanr (*) dim 1
    inl offset = Tuple.map (const 0) dim
    inl make_body typ = {
        toa_map_block=()
        ar = array_create typ array_size
        size offset
        }
    {
    bodies = 
        match dsc with
        | {layout=x} -> 
            match x with
            | .aot -> make_body typ
            | .toa -> toa_map make_body typ
        | _ -> toa_map make_body typ
    dim
    }

inl tensor_apply i {dim=d::dim bodies} =
    assert (i >= 0 && i < d) "Tensor application out of bounds"

    {
    dim
    bodies = 
        toa_map (inl {d with size=s::size offset=o::offset} ->
            inl o = o + i * s
            inl offset = 
                match offset with
                | o' :: offset -> o + o' :: offset
                | () -> o
            {d with size offset}
            ) bodies
    }

inl tensor_index {bodies dim=()} = toa_map (inl {ar offset} -> ar offset) bodies
inl tensor_set {bodies dim=()} v = toa_map2 (inl {ar offset} v -> ar offset <- v) bodies v |> ignore

inl tns = 
    tensor_create {layout=.aot; typ=int64,string,float32; dim=10,5,5}
    |> tensor_apply 2
    |> tensor_apply 3
    |> tensor_apply 4

tensor_set tns (1,"asd",3.3f32)
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore

