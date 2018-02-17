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
inb s = Cuda
inb s = Allocator s 1024
inl a = s.Section.allocate 128
inl b = s.Section.allocate 64
inl c = s.Section.allocate 32
c.Dispose
b.Dispose
a.Dispose
    """

let allocator2 =
    "allocator2",[allocator;region;cuda],"Does the allocator + regions work?",
    """
inb s = Cuda
inb s = Allocator s 1024
inl s = Region s .RegionMem .create
inl a = s.RegionMem.allocate 128
inl b = s.RegionMem.allocate 64
inl c = s.RegionMem.allocate 32
s.RegionMem.clear
()
    """

let allocator3 =
    "allocator3",[allocator;region;cuda_stream;cuda],"Does the stream region work?",
    """
inb s = Cuda
inb s = Allocator s 1024
inl s = CudaStream s |> Region
inb s = s.RegionStream .create'
inl b = s.RegionStream.allocate
inl c = s.RegionStream.allocate
s.stream.wait_on b.stream
()
    """

let tensor1 =
    "tensor1",[allocator;cuda;host_tensor;region;cuda_stream;cuda_tensor],"Does the Cuda tensor work?",
    """
inb s = Cuda
inb s = Allocator s 1024
inl s = CudaTensor s |> CudaStream |> Region
inb s = s.RegionMem.create'
inb s = s.RegionStream.create'

inl a1 = s.CudaTensor.create {dim=1,2,3; elem_type=int64}
inl a2 = s.CudaTensor.zero {dim=1,2,3; elem_type=int64}
inl a3 = s.CudaTensor.zero_like a1
()
    """

let tensor2 =
    "tensor2",[allocator;cuda;host_tensor;cuda_tensor;region;cuda_stream],"Does the Cuda tensor work?",
    """
inb s = Cuda
inb s = Allocator s 1024
inl s = CudaTensor s |> CudaStream |> Region
inb s = s.RegionMem.create'
inb s = s.RegionStream.create'

inl h = HostTensor.create {elem_type=int64; dim=1,2,3}
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.to_host_tensor a1
()
    """

let random1 =
    "random1",[cuda;allocator;region;cuda_stream;host_tensor;cuda_tensor;cuda_random;console],"Does the create_tensor work?",
    """
inb s = Cuda
inb s = Allocator s 1024
inb s = CudaRandom s
inl s = Region s |> CudaStream |> CudaTensor
inb s = s.RegionMem.create'
inb s = s.RegionStream.create'

inl sigmoid_initializer' s x = 
    inl stddev = sqrt (2.0f32 / to float32 (Tuple.foldl (inl s x -> s + HostTensor.span x) 0 x.dim))
    Console.writeline {stddev}
    s.CudaRandom.fill {dst=.Normal; stddev mean=0f32} x

inl sigmoid_initializer s dim = 
    inl x = s.CudaTensor.create {elem_type=float32; dim}
    sigmoid_initializer' s x
    x

inl o1 = sigmoid_initializer s (3,8)
s.CudaTensor.print o1
    """

let blas1 =
    "blas1",[cuda;allocator;region;cuda_stream;cuda_tensor;cuda_blas;cuda_random;host_tensor;console],"Does the gemm work?",
    """
inb s = Cuda
inb s = Allocator s 1024
inb s = CudaRandom s
inb s = CudaBlas s
inl s = Region s |> CudaStream |> CudaTensor
inb s = s.RegionMem.create'
inb s = s.RegionStream.create'

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,3}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,4}
inl o1 = s.CudaBlas.gemm .nT .nT 1f32 a1 a2
inl o2 = s.CudaBlas.gemm .nT .T 1f32 o1 a2
inl o3 = s.CudaBlas.gemm .T .nT 1f32 a1 o1
Tuple.iter s.CudaTensor.print (a1,a2,o1,o2,o3)
    """

    
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" random1
|> printfn "%s"
|> ignore