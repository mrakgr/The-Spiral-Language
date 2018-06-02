#if INTERACTIVE
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsecCs.dll"
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsec.dll"
#r @"..\packages\ManagedCuda-CUBLAS.8.0.22\lib\net46\CudaBlas.dll"
#r @"..\packages\ManagedCuda-CURAND.8.0.22\lib\net46\CudaRand.dll"
#r @"Microsoft.CSharp"
#r @"..\The Spiral Language\bin\Release\The_Spiral_Language.dll"
#endif

open Spiral.Lib
open Spiral.Tests
open System.IO
open System.Diagnostics

let cfg = Spiral.Types.cfg_testing

let example = 
    "example",[],"Module description.",
    """
inl f a b =
    inl c = a + b
    c + 3

f (dyn 1) (dyn 2)
    """

//rewrite_test_cache tests cfg None //(Some(0,40))
output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) example
|> printfn "%s"
|> ignore

