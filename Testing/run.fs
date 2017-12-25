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

let example = 
    "example",[option;tuple;loops],"Module description.",
    """
inl string_stream str {idx on_succ on_fail} =
    inl f idx = idx >= 0 && idx < string_length str
    inl branch cond = if cond then on_succ (str idx) else on_fail "string index out of bounds" 
    match idx with
    | a, b -> branch (f a && f b)
    | _ -> branch (f idx)

inl stream_char {stream on_succ on_fail} {state with pos} =
    stream {
        idx = pos
        on_succ = inl c -> on_succ c {state with pos=pos+1}
        on_fail = inl msg -> on_fail msg state
        }

inl is_digit x = x >= '0' && x <= '9'
inl digit {stream on_succ on_fail} state =
    stream_char {
        stream on_fail
        on_succ = inl x state' -> 
            if is_digit x then on_succ x state'
            else on_fail "digit" state
        } state

inl stream = dyn "123456789" |> string_stream

inl d = {
    stream
    on_succ = inl x state -> id x
    on_fail = inl x state -> failwith char x
    }

digit d {pos=0}
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
