module Learning.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Modules

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

let allocator1 =
    "allocator1",[allocator;cuda],"Does the allocator work?",
    """
inb Cuda = Cuda
inb allocate = Allocator {Cuda} 1024
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
inb allocate = Allocator {Cuda} 1024
inb region = Region.create allocate
inl a = region 128
inl b = region 64
inl c = region 32
()
    """

let allocator3 =
    "allocator3",[allocator;region;cuda_stream;cuda],"Does the stream region work?",
    """
inb Cuda = Cuda
inl CudaStream = CudaStream {Cuda}
inb allocate = Allocator {Cuda} 1024
inb stream_region = Region.create CudaStream.create
inl a = stream_region ()
inl b = stream_region ()
inl c = stream_region ()
a.wait_on b
()
    """

let tensor1 =
    "tensor1",[allocator;cuda;host_tensor;region;cuda_stream;cuda_tensor],"Does the Cuda tensor work?",
    """
inb Cuda = Cuda
inl CudaStream = CudaStream {Cuda}
inb allocate = Allocator {Cuda} 1024
inb region = Region.create allocate
inb stream_region = Region.create CudaStream.create
inl stream = stream_region()

inl obj s x = s x s
inl s = 
    {
    allocate_mem = const region
    allocate_stream = const stream_region
    stream = const stream
    context = const Cuda.context
    run = inl s x -> Cuda.run {x with stream=s.stream}
    module_add = inl s name v -> module_add s name (inl s name -> v name s) |> obj
    member_add = inl s name v -> module_add s name v |> obj
    unwrap = id
    } |> obj
    
inl s = CudaTensor s
inl a1 = s.CudaTensor.create {dim=1,2,3; elem_type=int64}
inl a2 = s.CudaTensor.zero {dim=1,2,3; elem_type=int64}
inl a3 = s.CudaTensor.zero_like a1
()
    """
    
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" tensor1
|> printfn "%s"
|> ignore