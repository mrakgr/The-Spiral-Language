let r = Array.zeroCreate 10
match r.[0] with
| None -> printfn "None"
| Some i -> printfn "%i" i