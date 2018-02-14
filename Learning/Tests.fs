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

inl d = {
    allocate = region
    stream = stream
    Cuda = Cuda
    }

inl CudaTensor = CudaTensor d
inl a1 = CudaTensor.create {dim=1,2,3; elem_type=int64}
inl a2 = CudaTensor.zero {dim=1,2,3; elem_type=int64}
inl a3 = CudaTensor.zero_like a1
()
    """

let tensor2 =
    "tensor2",[allocator;cuda;host_tensor;cuda_tensor;region;cuda_stream],"Does the Cuda tensor work?",
    """
inb Cuda = Cuda
inl CudaStream = CudaStream {Cuda}
inb allocate = Allocator {Cuda} 1024
inb region = Region.create allocate
inb stream_region = Region.create CudaStream.create
inl stream = stream_region()

inl d = {
    allocate = region
    stream = stream
    Cuda = Cuda
    }

inl CudaTensor = CudaTensor d
inl h = HostTensor.create {elem_type=int64; dim=1,2,3}
inl a1 = CudaTensor.from_host_tensor h
inl a2 = CudaTensor.to_host_tensor a1
()
    """

let random1 =
    "random1",[cuda;allocator;region;cuda_stream;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the create_tensor work?",
    """
inb Cuda = Cuda
inl CudaStream = CudaStream {Cuda}
inb allocate = Allocator {Cuda} 1024
inb region = Region.create allocate
inb stream_region = Region.create CudaStream.create
inl stream = stream_region()

inl d = {
    allocate = region
    stream = stream
    Cuda = Cuda
    }

inl CudaTensor = CudaTensor d
inl d = {d with CudaTensor}
inb CudaRandom = CudaRandom
inl CudaRandom = CudaRandom d
inl d = {d with CudaRandom}

inl sigmoid_initializer' x = 
    inl stddev = sqrt (2.0f32 / to float32 (Tuple.foldl (inl s x -> s + HostTensor.span x) 0 x.dim))
    Console.writeline {stddev}
    CudaRandom.fill {dst=.Normal; stddev mean=0f32} x

inl sigmoid_initializer dim = 
    inl x = CudaTensor.create {elem_type=float32; dim}
    sigmoid_initializer' x
    x

inl o1 = sigmoid_initializer (3,8)
CudaTensor.print o1
    """

let blas1 =
    "blas1",[cuda;allocator;region;cuda_stream;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;console],"Does the gemm work?",
    """
inb Cuda = Cuda
inl CudaStream = CudaStream {Cuda}
inb allocate = Allocator {Cuda} 1024
inb region = Region.create allocate
inb stream_region = Region.create CudaStream.create
inl stream = stream_region()

inl d = {
    allocate = region
    stream = stream
    Cuda = Cuda
    }

inl CudaTensor = CudaTensor d
inl d = {d with CudaTensor}
inb CudaRandom = CudaRandom
inl CudaRandom = CudaRandom d
inb CudaBlas = CudaBlas
inl CudaBlas = CudaBlas d
inl d = {d with CudaBlas CudaRandom}

inl a1 = CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,3}
inl a2 = CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,4}
inl o1 = CudaBlas.gemm .nT .nT 1f32 a1 a2
inl o2 = CudaBlas.gemm .nT .T 1f32 o1 a2
inl o3 = CudaBlas.gemm .T .nT 1f32 a1 o1
Tuple.iter CudaTensor.print (a1,a2,o1,o2,o3)
    """

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }
    
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" blas1
|> printfn "%s"
|> ignore