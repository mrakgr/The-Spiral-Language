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
    "example",[option;tuple;loops;extern_;console],"Module description.",
    """
inl string_stream str {idx on_succ on_fail} =
    inl f idx = idx >= 0 && idx < string_length str
    inl branch cond = if cond then on_succ (str idx) else on_fail "string index out of bounds" 
    match idx with
    | a, b -> branch (f a && f b)
    | _ -> branch (f idx)

inl run ret_type str parser = 
    inl stream = dyn str |> string_stream

    inl d = {
        stream
        on_succ = inl x state -> id x
        on_fail = inl x state -> failwith ret_type x
        on_type = ret_type
        }

    parser d {pos=dyn 0}

inl stream_char {stream on_succ on_fail} {state with pos} =
    stream {
        idx = pos
        on_succ = inl c -> on_succ c {state with pos=pos+1}
        on_fail = inl msg -> on_fail msg state
        }

inl is_digit x = x >= '0' && x <= '9'
inl is_whitespace x = x = ' '
inl is_newline x = x = '\n' || x = '\r'

inl digit {stream on_succ on_fail} state =
    stream_char {
        stream on_fail
        on_succ = inl x state' -> 
            if is_digit x then on_succ x state'
            else on_fail "digit" state
        } state

inl convert_type = fs [text: "System.Convert"]
inl to_uint64 x = Extern.FS.StaticMethod convert_type .ToUInt64 x uint64
inl puint64 {stream on_succ on_fail on_type} state =
    inl error state = on_fail "puint64" state
    inl rec loop i on_fail state =
        digit {
            stream
            on_fail=inl _ state -> on_fail i state
            on_succ=inl c state ->
                inl max = 1844674407370955161u64 // max of uint64 / 10u64
                if i <= max then
                    inl i' = i * 10u64 + to_uint64 c - to_uint64 '0'
                    if i < i' then join loop i' on_succ state
                    else error state
                else error state
            } state
        : on_type
    loop (dyn 0u64) (inl _ state -> error state) state

met rec spaces {d with stream on_succ on_fail on_type} state =
    stream_char {
        stream
        on_fail = inl _ state -> on_succ () state
        on_succ = inl c state' -> 
            if is_whitespace c || is_newline c then spaces d state'
            else on_succ () state
        } state
    : on_type

inl (>>.) a b {d with on_succ} state = a {d with on_succ = inl _ state -> b d state} state
inl (.>>) a b {d with on_succ} state = 
    a {d with on_succ = inl a state -> 
        b {d with on_succ = inl _ state -> on_succ a state} state
        } state

inl rec tuple l {d with on_succ} state =
    match l with
    | x :: xs ->
        x {d with on_succ = inl x state ->
            tuple xs {d with on_succ = inl xs state ->
                on_succ (x :: xs) state
                } state
            } state
    | () -> on_succ () state

inl num = puint64 .>> spaces

//run (uint64,uint64,uint64) "123 456 789" (tuple (num, num, num))
inl f x ret =
    Console.writeline x
    ret()
    Console.writeline "done"
inb x = f "hello"
Console.writeline "doing work"
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
