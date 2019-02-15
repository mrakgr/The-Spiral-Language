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
open Spiral.Types

let cfg = Spiral.Types.cfg_testing

let example: SpiralModule =
    {
    name="example"
    prerequisites=[]
    description="Module description."
    code=
    """
// https://gist.github.com/SimonDanisch/812e01d7183681ed414932c8f7b533d0#file-unroll-jl
// This is not quite the same as the above example, but Spiral's staging optimizations
// only work when code is written in a functionally pure manner. 

// `sin` currently is not a part of the core library so I use a macro to interop with it.
// If it were then this whole program would be evaluated at compile time.
// To see that, replace sin with tanh or sqrt for example.
// Spiral's semantics allow for any functionally pure computation at compile time.
inl sin x = macro.fs float64 [text:"sin"; args: x]

inl rec unroll f i s =
    assert (lit_is i) "i must be a literal."
    if i > 0 then unroll f (i-1) (f s) else s

inl test () =
    inl box = 1.0
    unroll sin 3 box

test ()

//let (var_0: float) = sin(1.000000)
//let (var_1: float) = sin(var_0)
//sin(var_1)
    """
    }

let example2: SpiralModule =
    {
    name="example2"
    prerequisites=[tuple; console]
    description="Module description."
    code=
    """
inl rec foo n = 
    assert (lit_is n) "n must be known at compile time."
    assert (n >= 0) "n must greater or equal to zero."
    if n = 0 then ()
    else (if n % 2 = 0 then int32 else string) :: foo (n - 1)

inl stringify = function _: int32 -> "int" | _ : string -> "string"
foo 10 |> Tuple.map stringify |> Console.writeline
    """
    }

let example3: SpiralModule =
    {
    name="example3"
    prerequisites=[]
    description="Module description."
    code=
    """
inl x = .blocke
// Combination of not `!` and injection `$` patterns.
// Since the module does not have the member `blocke`, the case returns "asd" at compile time.
match {block=()} with 
| {!($x)} -> "asd"
| _ -> "qwe"
    """
    }

let example4: SpiralModule =
    {
    name="parser_test"
    prerequisites=[loops; parsing]
    description="Parser test for compilation speed."
    code=
    """
Loops.for {static_from=0; near_to=40; body=inl {i} ->
    Parsing.sprintf "%i, %i, %i" 1 2 3 |> ignore
    Parsing.sprintf "%i, %i, %i, %i" 1 2 3 4 |> ignore
    Parsing.sprintf "%i, %i, %i, %i, %i" 1 2 3 5 6 |> ignore
    Parsing.sprintf "(%s, %i, %f)" "asd" 11 3.3 |> ignore
    }
    """
    }

let test1: SpiralModule =
    {
    name="test1"
    prerequisites=[]
    description="Does it run?"
    code=
    """
""
    """
    }

//rewrite_test_cache tests cfg None //(Some(0,40))
output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) test1
|> printfn "%s"
|> ignore

