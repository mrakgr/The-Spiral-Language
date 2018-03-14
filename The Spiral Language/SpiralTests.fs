module Spiral.Tests
open Types
open Lib
open Main

open System.IO
open System

let run_test_and_store_it_to_stream cfg stream (name,aux,desc,body as m) =
    let main_module = module_ m
    sprintf "%s - %s:\n%s\n\n" name desc (body.Trim()) |> stream
    match spiral_peval cfg main_module with
    | Succ (x,_) | Fail x -> stream x

let output_test_to_string cfg test = 
    match spiral_peval cfg (module_ test) with
    | Succ (x,_) | Fail x -> x

let output_test_to_temp cfg path test = 
    match spiral_peval cfg (module_ test) with
    | Succ (x,_) | Fail x -> 
        if File.Exists path then File.WriteAllText(path,x)
        else failwithf "File %s not found.\nNote to new users: In order to prevent files being made in the middle of nowhere this check was inserted.\nWhat you should do is create a new F# project with an F# file and point the compiler to it instead." path
        x

let make_test_path_from_name name =
    let dir = Environment.CurrentDirectory |> DirectoryInfo
    let path = Path.Combine(dir.Parent.Parent.FullName,"TestCache")
    Directory.CreateDirectory path |> ignore
    Path.Combine(path,name+".txt")

let cache_test cfg ({parsing_time=a; prepass_time=b; peval_time=c; codegen_time=d} as time) (name,aux,desc,body as m) = 
    let write x = File.WriteAllText(make_test_path_from_name name, x)
    match spiral_peval cfg (module_ m) with
    | Fail x -> write x; time
    | Succ(x, {parsing_time=a'; prepass_time=b'; peval_time=c'; codegen_time=d'}) -> write x; {parsing_time=a+a'; prepass_time=b+b'; peval_time=c+c'; codegen_time=d+d'}
    
let rewrite_test_cache tests cfg x = 
    let time = {parsing_time=TimeSpan.Zero; prepass_time=TimeSpan.Zero; peval_time=TimeSpan.Zero; codegen_time=TimeSpan.Zero}
    match x with
    | None -> Array.fold (cache_test cfg) time tests
    | Some (min, max) -> Array.fold (cache_test cfg) time tests.[min..max-1]
    |> fun ({parsing_time=a; prepass_time=b; peval_time=c; codegen_time=d} as time) -> 
        printfn "The timings are: %A" time
        printfn "The time it took to run all the tests is: %A" (a+b+c+d)
