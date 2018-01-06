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
inb {allocate} = Allocator {Cuda size=1024}
inl a = allocate 128
a.Dispose
inl b = allocate 64
b.Dispose
inl c = allocate 32
c.Dispose
()
    """

let tensor1 =
    "tensor1",[allocator;cuda;host_tensor;cuda_tensor],"Does the Cuda tensor work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inb a1 = CudaTensor.create {dim=1,2,3; elem_type=int64}
inb a2 = CudaTensor.zero_like a1
()
    """

let tensor2 =
    "tensor2",[allocator;cuda;host_tensor;cuda_tensor],"Does the Cuda tensor work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl h = HostTensor.create {elem_type=int64; dim=1,2,3}
inb a1 = CudaTensor.from_host_tensor h
inl a2 = CudaTensor.to_host_tensor a1
()
    """

let kernel1 =
    "kernel1",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;console],"Does the map kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}

inl h = HostTensor.init 32 ((+) 1)
inb a1 = CudaTensor.from_host_tensor h
inb o1 = CudaTensor.zero_like a1
CudaKernel.map ((*) 2) a1 o1
inl a2 = CudaTensor.to_host_tensor o1
HostTensor.show a2 |> Console.writeline
    """

let kernel2 =
    "kernel2",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_redo kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}

inl h = HostTensor.init 32 ((+) 1)
inb a1 = CudaTensor.from_host_tensor h
inb o1 = CudaKernel.map_redo {neutral_elem=0; redo=(+)} a1
Console.writeline o1.value
    """

let random1 =
    "random1",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_redo kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inb o1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=6,6}
CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
    """

let tests =
    [|
    allocator1
    tensor1;tensor2
    kernel1;kernel2
    random1
    |]

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = @"C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.0"
    path_cub = @"C:\cub-1.7.4"
    path_vs2017 = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community"
    cuda_includes = ["cub/cub.cuh"]
    }

rewrite_test_cache tests cfg None //(Some(0,40))

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" random1
|> printfn "%s"
|> ignore

