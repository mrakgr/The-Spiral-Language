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
    "example",[tuple;console],"Module description.",
    """
inl for_template kind {d with body} =
    inl finally =
        match d with
        | {finally} -> finally
        | _ -> id

    inl state = 
        match d with
        | {state} -> state
        | _ -> ()

    inl check =
        match d with
        | {near_to} from -> from < near_to 
        | {to} from -> from <= to
        | {down_to} from -> from >= down_to
        | {near_down_to} from -> from > near_down_to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` needs be present."

    inl from =
        match d with
        | {from=(!dyn from) ^ static_from=from} -> from
        | _ -> error_type "Only one of `from` and `static_from` field to loop needs to be present."

    inl to =
        match d with
        | {(to ^ near_to ^ down_to ^ near_down_to)=to} -> to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` is allowed."

    inl by =
        match d with
        | {by} -> by
        | _ -> 1

    inl rec loop {from state} =
        inl body {from} = 
            if check from then 
                match kind with
                | .Standard ->
                    loop {from=from+by; state=body {state i=from}}
                | .CPSd ->
                    inl next state = loop {state from=from+by}
                    body {next state i=from}
            else finally state

        if Tuple.forall lit_is (from,to,by) then body {from}
        else 
            inl from = dyn from
            join (body {from} : finally state)

    loop {from state}

inl for' = for_template .CPSd
inl for = for_template .Standard

inl array_init near_to f =
    assert (near_to >= 0) "The input to init needs to be greater or equal to 0."
    // Somewhat of an ugly practice in order to infer the type in a language that doesn't support inference. 
    // For large functions, it is recomended to put them in a join point otherwise compile times could 
    // become exponential if the function contains branches.
    // For a simple map for an array like here, it does not matter.
    inl typ = type (f 0) 
    inl ar = array_create typ near_to
    for {from=0; near_to; body=inl {i} -> ar i <- f i}
    ar

inl rec zeroes = function
    | x :: x' -> array_init x (inl _ -> zeroes x')
    | () -> ""

inl dim = (4,4,4,4)
inl ar = zeroes dim
ar 0 0 0 2 <- "princess"

// Reverses a tuple
inl tuple_rev = 
    inl rec loop state = function
        | x :: xs -> loop (x :: state) xs
        | () -> state
    loop ()

// Correct version
inl rec find_index {next state} = function
    | ar & @array_is _ -> 
        inl body {next i} = find_index {next state=i::state} (ar i)
        for' {from=0; near_to=array_length ar; finally=next; body}
    | "princess" -> tuple_rev state
    | _ -> next ()

find_index {state=(); next = inl _ -> failwith (type (dim)) "The princess is in another castle."} ar
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
