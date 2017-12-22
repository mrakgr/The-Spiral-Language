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
    "example",[tuple;console;loops],"Module description.",
    """
open Loops
inl rec List x = () \/ x, List x

/// Creates an empty list with the given type.
/// t -> List t
inl empty x = box (List x) ()
/// Creates a single element list with the given type.
/// x -> List x
inl singleton x = box (List x) (x, empty x)
/// Immutable appends an element to the head of the list.
/// x -> List x -> List x
inl cons a b = 
    inl t = List a
    box t (a, box t b)

/// Creates a list by calling the given generator on each index.
/// ?(.static) -> int -> (int -> a) -> List a
inl init =
    inl body is_static n f =
        inl t = type (f 0)
        inl d = {near_to=n; state=empty t; body=inl {next i state} -> cons (f i) (next state)}
        if is_static then for' {d with static_from=0}
        else for' {d with from=0}

    function
    | .static -> body true
    | x -> body false x

inl Option x = type (.Some, x) \/ type (.None)
print_static (Option int64 |> split)
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" test95
|> printfn "%s"
|> ignore
