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
/// Converts a string to a parser stream.
/// string -> parser_stream
inl string_stream str {idx on_succ on_fail} =
    inl f idx = idx >= 0 && idx < string_length str
    inl branch cond = if cond then on_succ (str idx) else on_fail "string index out of bounds" 
    match idx with
    | a, b -> branch (f a && f b)
    | _ -> branch (f idx)

/// Runs a parser given the string and the expected return type.
/// t type -> string -> t parser -> t
inl run ret_type str parser = 
    inl stream = dyn str |> string_stream

    inl d = {
        stream
        on_succ = inl x state -> id x
        on_fail = inl x state -> failwith ret_type x
        on_type = ret_type
        }

    parser d {pos=dyn 0}

/// Reads a char.
/// char parser
inl stream_char {stream on_succ on_fail} {state with pos} =
    stream {
        idx = pos
        on_succ = inl c -> on_succ c {state with pos=pos+1}
        on_fail = inl msg -> on_fail msg state
        }

inl is_digit x = x >= '0' && x <= '9'
inl is_whitespace x = x = ' '
inl is_newline x = x = '\n' || x = '\r'

/// Reads a digit.
/// char parser
inl digit {stream on_succ on_fail} state =
    stream_char {
        stream on_fail
        on_succ = inl x state' -> 
            if is_digit x then on_succ x state'
            else on_fail "digit" state
        } state

inl convert_type = fs [text: "System.Convert"]
inl to_uint64 x = Extern.FS.StaticMethod convert_type .ToUInt64 x uint64
/// Reads an 64-bit integer parser.
/// uint64 parser
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

/// The skips an all the whitespaces (including newlines) before succeeding.
/// unit parser
met rec spaces {d with stream on_succ on_fail on_type} state =
    stream_char {
        stream
        on_fail = inl _ state -> on_succ () state
        on_succ = inl c state' -> 
            if is_whitespace c || is_newline c then spaces d state'
            else on_succ () state
        } state
    : on_type

/// Runs the first and then the second parser before returning the result of the second parser.
/// a parser -> b parser -> b parser
inl (>>.) a b {d with on_succ} state = a {d with on_succ = inl _ state -> b d state} state
/// Runs the first and then the second parser before returning the result of the first parser.
/// a parser -> b parser -> a parser
inl (.>>) a b {d with on_succ} state = 
    a {d with on_succ = inl a state -> 
        b {d with on_succ = inl _ state -> on_succ a state} state
        } state

/// Runs the tuple of parsers before returning their result.
/// tuple parser
inl rec tuple l {d with on_succ} state =
    match l with
    | x :: xs ->
        x {d with on_succ = inl x state ->
            tuple xs {d with on_succ = inl xs state ->
                on_succ (x :: xs) state
                } state
            } state
    | () -> on_succ () state

/// Term casting for parsers
/// a type -> a parser -> a parser
inl term_cast typ p {d with on_succ on_fail on_type} state =
    inl term_cast_uncurried g a b = // This is to make sure only one closure is allocated.
        inl g = term_cast (inl a, b -> g a b) (a,b)
        inl a b -> g (a,b)
    p {d with 
        on_succ = term_cast_uncurried on_succ typ state
        on_fail = term_cast_uncurried on_fail string state
        } state

inl ParserResult x state = .ParserSucc, x, state \/ .ParserFail, string, state

/// Union boxing for parsers
/// a type -> a parser -> a parser
inl box typ p {d with on_succ on_fail} state = 
    inl on_type = ParserResult typ state
    inl box = box on_type
    p {d with
        on_succ = inl x state -> box (.ParserSucc, x, state)
        on_fail = inl x state -> box (.ParserFail, x, state)
        on_type
        } state
    |> function
        | .ParserSucc, x, state -> on_succ x state
        | .ParserFail, x, state -> on_fail x state

inl puint64 d state = join puint64 d state // Make sure that the unrolled outer loop is rolled in.

/// Parses an unsigned 64-bit integer and returns it after parsing whitespaces.
/// uint64 parser
inl num = box uint64 (puint64 .>> spaces)

run (uint64,uint64,uint64) "123 456 789" (tuple (num, num, num))
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
