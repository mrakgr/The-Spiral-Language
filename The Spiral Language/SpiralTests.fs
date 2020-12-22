module Spiral.Tests
open Spiral.Types

open System.IO
open System
open Spiral.Compile

let run_test_and_store_it_to_stream cfg stream (m: SpiralModule) =
    sprintf "%s - %s:\n%s\n\n" m.name m.description (m.code.Trim()) |> stream
    let Ok(a,b) | Fail(a,b) = compile cfg m
    stream b
    a

let output_test_to_temp cfg path test =
    if Directory.Exists <| Path.GetDirectoryName path then 
        let Ok(a,b) | Fail(a,b) = compile cfg test
        printfn "%A" a
        File.WriteAllText(path,b)
        b
    else failwithf "File %s not found.\nNote to new users: In order to prevent files being made in the middle of nowhere this check was inserted.\nWhat you should do is create a new F# project and point the compiler to a file in that directory instead." path

let make_test_path_from_name name =
    let dir = Environment.CurrentDirectory |> DirectoryInfo
    let path = Path.Combine(dir.Parent.Parent.FullName,"TestCache")
    Directory.CreateDirectory path |> ignore
    Path.Combine(path,name+".txt")

let cache_test cfg (time: Timings) (m: SpiralModule) = 
    let pass, time', b = 
        match compile cfg m with
        | Ok(time',b) -> "has passed", time', b
        | Fail(time',b) -> "has failed", time', b
    printfn "Test %s %s. Timings:\n%A" m.name pass time'
    File.WriteAllText(make_test_path_from_name m.name, b)
    time.Add time'
    
let rewrite_test_cache tests cfg x =
    let time = 
        let time: Timings = {parse=TimeSpan.Zero; prepass=TimeSpan.Zero; peval=TimeSpan.Zero; codegen=TimeSpan.Zero}
        match x with
        | None -> Array.fold (cache_test cfg) time tests
        | Some (min, max) -> Array.fold (cache_test cfg) time tests.[min..max-1]
    printfn "The timings are: %A" time
    printfn "The time it took to run all the tests is: %A" (time.parse+time.prepass+time.peval+time.codegen)
