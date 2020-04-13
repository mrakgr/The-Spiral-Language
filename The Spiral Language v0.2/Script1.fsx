open System

async {
    printfn "Start 1."
    do! Async.Sleep(1000)
    printfn "Done 1."
} |> Async.StartImmediate

async {
    printfn "Start 2."
    do! Async.Sleep(1000)
    printfn "Done 2."
} |> Async.StartImmediate