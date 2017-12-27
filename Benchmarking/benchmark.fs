open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

type ParserBenchmarks () =

    [<Benchmark>]
    static member TermCasted () = ParserTermCasted.example()
    [<Benchmark>]
    static member Boxy () = ParserBoxy.example()
    [<Benchmark>]
    static member FullySpecialized () = ParserFullySpecialized.example()
    [<Benchmark>]
    static member FSharp () = ParserFSharp.example()

BenchmarkRunner.Run<ParserBenchmarks>() |> ignore

