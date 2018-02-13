module Learning.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Modules

let allocator1 =
    "allocator1",[allocator;cuda],"Does the allocator work?",
    """
inb Cuda = Cuda
inl allocate = Allocator {Cuda} 1024
inl a = allocate 128
inl b = allocate 64
inl c = allocate 32
c.Dispose
b.Dispose
a.Dispose
    """

let allocator2 =
    "allocator2",[allocator;region;cuda],"Does the allocator + regions work?",
    """
inb Cuda = Cuda
inl allocate = Allocator {Cuda} 1024
inl region = Region allocate
inl a = region 128
()
//inl b = region 64
//inl c = region 32
//region.clear
    """

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }
    
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" allocator2
|> printfn "%s"
|> ignore