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
    "blas1",[cuda;allocator;region;cuda_stream;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;host_tensor;console],"Does the gemm work?",
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

let kernel1 =
    "kernel1",[cuda_modules],"Does the map kernel work?",
    """
inb d = CudaModules (1024*1024)

inl h = HostTensor.init 32 (inl x -> x + 1)
inl a1 = d.CudaTensor.from_host_tensor h
inl o1 = d.CudaTensor.zero_like a1
d.CudaKernel.map' (inl a _ -> a *2) a1 o1
inl a2 = d.CudaTensor.to_host_tensor o1
HostTensor.zip (h,a2) |> HostTensor.show |> Console.writeline
    """

let kernel2 =
    "kernel2",[cuda_modules],"Does the map_redo_map kernel work?",
    """
inb d = CudaModules (1024*1024)

inl h = HostTensor.init 1024 ((+) 1)
inl a1 = d.CudaTensor.from_host_tensor h
d.CudaKernel.map_redo_map {neutral_elem=0; redo=(+)} a1
|> d.CudaTensor.print // 524800
    """

let kernel3 =
    "kernel3",[cuda_modules],"Does the d2_replicate_map kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 8
inl outer_size = 8

inl h = HostTensor.init inner_size (const (2,2))
inl h' = HostTensor.init (outer_size,inner_size) (inl a b -> a,b)
inl a1 = d.CudaTensor.from_host_tensor h
inl a2 = d.CudaTensor.from_host_tensor h'
inl o1 = d.CudaKernel.d2_replicate_map (inl a b -> a, b) a1 a2
inl o2 = d.CudaKernel.d2_replicate_map (inl a _ -> a) a1 outer_size
Tuple.iter d.CudaTensor.print (o1,o2)
    """

let kernel4 =
    "kernel4",[cuda_modules],"Does the map_d2_redo_map' kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 128

inl h = HostTensor.init (outer_size,inner_size) (inl _ x -> x)
inl h' = HostTensor.init inner_size (const 10)
inl a1 = d.CudaTensor.from_host_tensor h
inl a2 = d.CudaTensor.from_host_tensor h'
inl f map_in a2 =
    d.CudaKernel.map_d2_redo_map {
        map_in
        neutral_elem=0; redo=(+)
        map_out=inl a -> a/2
        } a1 a2
inl o1 = f (inl a b -> a+1) ()
inl o2 = f (inl a b -> a+b) a2

Tuple.iter d.CudaTensor.print (a1,o1,o2)
    """

let kernel5 =
    "kernel5",[cuda_modules],"Does the map_d1_redo_map' kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 32

inl a1 = d.CudaRandom.create .Uniform {elem_type=float32; dim=outer_size,inner_size}
inl a2 = d.CudaRandom.create .Uniform {elem_type=float32; dim=outer_size,inner_size}
inl a3 = d.CudaTensor.create {elem_type=float32; dim=1}
inl f a1 a2 =
    d.CudaKernel.map_d1_redo_map {
        map_in=const
        neutral_elem=-infinityf32,0f32
        redo=inl a b -> if fst a > fst b then a else b
        map_out=snd
        } a1 a2
inl o1 = f (a1, a2) ()

Tuple.iter d.CudaTensor.print (a1,o1)
    """

let kernel6 =
    "kernel6",[cuda_modules],"Does the map_d1_inscan_map kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 50
inl outer_size = 3

inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
//inb a2 = d.CudaRandom.create .Uniform {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    d.CudaKernel.map_d1_inscan_map {
        neutral_elem=-infinityf32
        redo=max
        } a1

Tuple.iter d.CudaTensor.print (a1,o1)
    """

let kernel7 =
    "kernel7",[cuda_modules],"Does the map_d2_inscan_map kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 6
inl outer_size = 64

inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    d.CudaKernel.map_d2_inscan_map {
        neutral_elem=-infinityf32
        redo=max
        } a1

Tuple.iter d.CudaTensor.print (a1,o1)
    """

let kernel8 =
    "kernel8",[cuda_modules],"Does the map_d1_exscan_map kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 10

inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    d.CudaKernel.map_d1_exscan_map {
        neutral_elem=0f32
        redo=(+)
        } a1

Tuple.iter d.CudaTensor.print (a1,o1)
    """

let kernel9 =
    "kernel9",[cuda_modules],"Does the map_inscan_map kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 64
inl outer_size = 3

inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    d.CudaKernel.map_inscan_map {
        neutral_elem=infinityf32
        redo=min
        } a1

Tuple.iter d.CudaTensor.print (a1,o1)
    """

let kernel10 =
    "kernel10",[cuda_modules],"Does the mapi_d1_inscan_mapi_d1_reduce_mapi kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 6

inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = d.CudaRandom.create {dst=.Normal; stddev=0f32; mean=0f32} {elem_type=float32; dim=outer_size}
inl o1 = // The sampling function
    d.CudaKernel.mapi_d1_inscan_mapi_d1_reduce_mapi {
        scan={
            ne=0f32
            f=(+)
            }
        mapi_mid=inl _ index prob boundary -> 
            inl x = prob - boundary
            (if x < 0f32 then infinityf32 else x), index
        redo={
            ne=infinityf32,0
            f=inl a b -> if fst a < fst b then a else b
            }
        map_out=snd
        } a1 a2

Tuple.iter d.CudaTensor.print (a1,o1)
    """

let kernel11 =
    "kernel11",[cuda_modules],"Does the map_d1_seq_broadcast kernel work?",
    """
inb d = CudaModules (1024*1024)

inl inner_size = 4
inl outer_size = 1

inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = d.CudaRandom.create {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = // Softmax forward
    d.CudaKernel.map_d1_seq_broadcast {
        seq = 
            {
            redo=max
            map=inl a b -> a - b |> exp
            }
            ,
            {
            redo=(+)
            map=(/)
            }
        } a1

inl o2 = 
    d.CudaKernel.map_d1_inscan_map {
        redo=(+)
        neutral_elem=0f32
        } o1

inl o3 = // Softmax backward
    d.CudaKernel.map_d1_seq_broadcast {
        seq = 
            {
            map_redo=inl in,er -> in*er
            redo=(+)
            map=inl (in,er) sum -> er * in * (1f32 - in) - in * (sum - er * in)
            }
        } (a1,a2)

Tuple.iter d.CudaTensor.print (a1,o3)
    """

let kernel12 =
    "kernel12",[cuda_modules],"Does the init kernel work?",
    """
inb d = CudaModules (1024*1024)

inl o1 = d.CudaKernel.init {rev_thread_limit=32; dim=2,2,128} (inl a b c -> a, b, c)
d.CudaTensor.print o1
    """

let learning1 =
    "learning1",[cuda_modules;learning],"Does the matmult work?",
    """
inb d = CudaModules (1024*1024)

inl float = float32
open Learning {float d}
open Primitive

inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8}
inl a2 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=8,2} >>! dr
inl o1,bck = matmult a1 a2
bck()

primal o1 |> d.CudaTensor.print
    """

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }
    
output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning1
|> printfn "%s"
|> ignore