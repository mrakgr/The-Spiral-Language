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
inl rec List x = join_type () \/ x, List x

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
        if is_static then Loops.for' {d with static_from=0}
        else Loops.for' {d with from=0}

    function
    | .static -> body true
    | x -> body false x

/// Returns the element type of the list.
/// a List -> a type
inl elem_type l =
    match split l with
    | (), (a,b) when eq_type (List a) l -> a
    | _ -> error_type "Expected a List in elem_type."

/// Builds a new list whose elements are the results of applying the given function to each of the elements of the list.
/// (a List -> b List) -> a List -> List b
inl rec map f l = 
    inl t = elem_type l
    inl loop = function
        | x,xs -> cons (f x) (map f xs)
        | () -> empty t
    if box_is l then loop l
    else join loop l : List t

/// Applies a function f to each element of the collection, threading an accumulator argument through the computation. 
/// The fold function takes the second argument, and applies the function f to it and the first element of the list. 
/// Then, it feeds this result into the function f along with the second element, and so on. It returns the final result. 
/// If the input function is f and the elements are i0...iN, then this function computes f (... (f s i0) i1 ...) iN.
/// (s -> a -> s) -> s -> a List -> s
inl rec foldl f s l = 
    inl loop = function
        | x, xs -> foldl f (f s x) xs
        | () -> s
    if box_is l then loop l
    else join loop l : s

/// Applies a function to each element of the collection, threading an accumulator argument through the computation. 
/// If the input function is f and the elements are i0...iN, then this function computes f i0 (...(f iN s)).
/// (a -> s -> s) -> a List -> s -> s
inl rec foldr f l s = 
    inl loop = function
        | x, xs -> f x (foldr f xs s)
        | () -> s
    if box_is l then loop l
    else join loop l : s

open Option

/// Returns the first element of the list.
/// a List -> {some=(a -> a) none=(a type -> a)} -> a
inl head' l {some none} =
    inl t = elem_type l
    match l with
    | x, xs -> some x
    | () -> none t

/// Returns the list without the first element.
/// a List -> {some=(a List -> a List) none=(a List type -> a List)} -> a List
inl tail' l {some none} =
    inl t = elem_type l
    match l with
    | x, xs -> some xs
    | () -> none (List t)

/// Returns the last element of the list.
/// a List -> {some=(a -> a) none=(a type -> a)} -> a
inl rec last' l {some none} =
    inl t = elem_type l
    inl loop = function
        | x, xs -> last' xs {some none=some x}
        | () -> none t
    if box_is l then loop l
    else join loop l : none t

/// Returns the first element of the list.
/// a List -> a Option
inl head l = head' l {some none}

/// Returns the list without the first element.
/// a List -> a List Option
inl tail l = tail' l {some none}

/// Returns the last element of the list.
/// a List -> a Option
inl last l = last' l {some=const << some; none}

/// Returns a new list that contains the elements of the first list followed by elements of the second.
/// a List -> a List -> a List
inl append = foldr cons

/// Returns a new list that contains the elements of each list in order.
/// a List List -> a List
inl concat l & !elem_type !elem_type t = foldr append l (empty t)

{List empty cons init map foldl foldr singleton head' tail' last' head tail last append concat} |> stack
    """

//output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" example
|> printfn "%s"
|> ignore
