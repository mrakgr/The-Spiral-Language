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
inl b = allocate 64
inl c = allocate 32
c.Dispose
b.Dispose
a.Dispose
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
inb a2 = CudaTensor.zero {dim=1,2,3; elem_type=int64}
inb a3 = CudaTensor.zero_like a1
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

inl h = HostTensor.init 32 (inl x -> x + 1)
inb a1 = CudaTensor.from_host_tensor h
inb o1 = CudaTensor.zero_like a1
CudaKernel.map' (inl a _ -> a *2) a1 o1
inl a2 = CudaTensor.to_host_tensor o1
HostTensor.zip (h,a2) |> HostTensor.show |> Console.writeline
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
inl o1 = CudaKernel.map_redo {neutral_elem=0; redo=(+)} a1
Console.writeline o1
    """

let kernel3 =
    "kernel3",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the d2_replicate_map kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}

inl inner_size = 8
inl outer_size = 8

inl h = HostTensor.init inner_size (const (2,2))
inl h' = HostTensor.init (outer_size,inner_size) (inl a b -> a,b)
inb a1 = CudaTensor.from_host_tensor h
inb a2 = CudaTensor.from_host_tensor h'
inb o1 = CudaKernel.d2_replicate_map (inl a b -> a, b) a1 a2
inb o2 = CudaKernel.d2_replicate_map (inl a _ -> a) a1 outer_size
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,a2,o1,o2)
    """

let kernel4 =
    "kernel4",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_d2_redo_map' kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}

inl inner_size = 10
inl outer_size = 128

inl h = HostTensor.init (outer_size,inner_size) (inl _ x -> x)
inl h' = HostTensor.init inner_size (const 10)
inb a1 = CudaTensor.from_host_tensor h
inb a2 = CudaTensor.from_host_tensor h'
inl f map_in a2 =
    CudaKernel.map_d2_redo_map {
        map_in
        neutral_elem=0; redo=(+)
        map_out=inl a -> a/2
        } a1 a2
inb o1 = f (inl a b -> a+1) ()
inb o2 = f (inl a b -> a+b) a2

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1,o2)
    """

let kernel5 =
    "kernel5",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_d1_redo_map' kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl inner_size = 10
inl outer_size = 32

inb a1 = CudaRandom.create_tensor .Uniform {elem_type=float32; dim=outer_size,inner_size}
inb a2 = CudaRandom.create_tensor .Uniform {elem_type=float32; dim=outer_size,inner_size}
inb a3 = CudaTensor.create {elem_type=float32; dim=1} // This causes the alignment error.
inl f a1 a2 =
    CudaKernel.map_d1_redo_map {
        map_in=const
        neutral_elem=-infinityf32,0f32
        redo=inl a b -> if fst a > fst b then a else b
        map_out=snd
        } a1 a2
inb o1 = f (a1, a2) ()

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1)
    """

let kernel6 =
    "kernel6",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_d1_inscan_map kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl inner_size = 50
inl outer_size = 3

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
//inb a2 = CudaRandom.create_tensor .Uniform {elem_type=float32; dim=outer_size,inner_size}
inb o1 = 
    CudaKernel.map_d1_inscan_map {
        neutral_elem=-infinityf32
        redo=max
        } a1

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1)
    """

let kernel7 =
    "kernel7",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_d2_inscan_map kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl inner_size = 6
inl outer_size = 64

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inb o1 = 
    CudaKernel.map_d2_inscan_map {
        neutral_elem=-infinityf32
        redo=max
        } a1

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1)
    """

let kernel8 =
    "kernel8",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_d1_exscan_map kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl inner_size = 10
inl outer_size = 10

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inb o1 = 
    CudaKernel.map_d1_exscan_map {
        neutral_elem=0f32
        redo=(+)
        } a1

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1)
    """

let kernel9 =
    "kernel9",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_inscan_map kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl inner_size = 64
inl outer_size = 3

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inb o1 = 
    CudaKernel.map_inscan_map {
        neutral_elem=infinityf32
        redo=min
        } a1

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1)
    """

let kernel10 =
    "kernel10",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the mapi_d1_inscan_mapi_d1_reduce_mapi kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl inner_size = 10
inl outer_size = 6

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inb a2 = CudaRandom.create_tensor {dst=.Normal; stddev=0f32; mean=0f32} {elem_type=float32; dim=outer_size}
inb o1 = // The sampling function
    CudaKernel.mapi_d1_inscan_mapi_d1_reduce_mapi {
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

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1)
    """

let kernel11 =
    "kernel11",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the map_d1_seq_broadcast kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl inner_size = 4
inl outer_size = 1

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inb a2 = CudaRandom.create_tensor {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=outer_size,inner_size}
inb o1 = // Softmax forward
    CudaKernel.map_d1_seq_broadcast {
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

inb o2 = 
    CudaKernel.map_d1_inscan_map {
        redo=(+)
        neutral_elem=0f32
        } o1

inb o3 = // Softmax backward
    CudaKernel.map_d1_seq_broadcast {
        seq = 
            {
            map_redo=inl in,er -> in*er
            redo=(+)
            map=inl (in,er) sum -> er * in * (1f32 - in) - in * (sum - er * in)
            }
        } (a1,a2)

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (HostTensor.zip (a1),HostTensor.zip (o3))
    """

let kernel12 =
    "kernel12",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the init kernel work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb o1 = CudaKernel.init {rev_thread_limit=32; dim=2,2,128} (inl a b c -> a,b, c)

CudaTensor.print o1
    """

let random1 =
    "random1",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the create_tensor work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}

inl sigmoid_initializer' x = 
    inl stddev = sqrt (2.0f32 / to float32 (Tuple.foldl (inl s x -> s + HostTensor.span x) 0 x.dim))
    CudaRandom.fill {dst=.Normal; stddev mean=0f32} x

inl sigmoid_initializer dim ret = 
    inb x = CudaTensor.create {elem_type=float32; dim}
    sigmoid_initializer' x
    ret x

inb o1 = sigmoid_initializer (3,8)
CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
    """

let blas1 =
    "blas1",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;console],"Does the gemm work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.1}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,3}
inb a2 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,4}
inb o1 = CudaBlas.gemm .nT .nT 1f32 a1 a2
inb o2 = CudaBlas.gemm .nT .T 1f32 o1 a2
inb o3 = CudaBlas.gemm .T .nT 1f32 a1 o1
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,a2,o1,o2,o3)
    """

let learning1 =
    "learning1",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the matmult work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8}
inb a2 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=8,2} >>! dr
inb o1,bck = matmult a1 a2
bck()
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
primal o1 |> show
    """

let learning2 =
    "learning2",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the map work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8} >>! dr
inb o1,bck = map {fwd=((*) 10f32); bck=inl {out} -> out.A * 10f32} a1
bck()
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
primal o1 |> show
    """

let learning3 =
    "learning3",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the map_redo work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=float; dim=256,256} >>! dr
inb o1,bck = map_redo {fwd={neutral_elem=0f32; redo=(+)}; bck=inl {out} -> out.A} a1
bck()
Console.writeline <| primal o1 / to float32 ((primal a1).length)
    """

let learning4 =
    "learning4",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the map_redo's backwards pass work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=float; dim=6,6} >>! dr
inb o1,bck = map_redo {fwd={neutral_elem=0f32; redo=(+)}; bck=inl {out} -> out.A} a1
adjoint o1 := 1f32
bck()
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
adjoint a1 |> show
    """

let learning5 =
    "learning5",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the basic pass work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive
open Activation
open Error

inb input = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,6}
inb weight = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=6,4} >>! dr
inb label = CudaTensor.zero {elem_type=float; dim=2,4}
inb {cost},bck = 
    inm o1 = matmult input weight >>= sigmoid
    square (o1,label)

Console.writeline ("Cost is:", primal cost)

adjoint cost := 1f32
bck()
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
adjoint weight |> show
    """

let learning6 =
    "learning6",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the basic layer work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inl input_size = 6
inl hidden_size = 4
inb input = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,input_size}
inb label = CudaTensor.zero {elem_type=float; dim=2,hidden_size}

inb {apply} = init (sigmoid hidden_size) input_size >>! with_error square
inb {cost},bck = apply (input,label)

Console.writeline ("Cost is:", primal cost)

adjoint cost := 1f32
bck()
    """

let learning7 =
    "learning7",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;mnist;console],"Does the pass work with Mnist?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inb { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> CudaTensor.from_host_tensors

inl input_size = 784
inl hidden_size = 10

inb {apply} = init (sigmoid hidden_size) input_size >>! with_error square
inb {cost},bck = apply (test_images,test_labels)

Console.writeline ("Cost is:", primal cost)

adjoint cost := 1f32
bck()
    """

let learning8 =
    "learning8",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the add_bias work?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive
open Activation
open Error

inl input_size = 32
inl outer_dim = 6
inl inner_dim = 16
inb input = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=input_size,outer_dim}
inb weight = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=outer_dim,inner_dim} >>! dr
inb bias = CudaTensor.zero {elem_type=float; dim=inner_dim} >>! dr
inb label = CudaTensor.zero {elem_type=float; dim=input_size,inner_dim}

inb {cost},bck = 
    inm o1 = matmult input weight >>= add_bias bias >>= sigmoid
    square (o1,label)

Console.writeline ("Cost is:", primal cost)

adjoint cost := 1f32
bck()
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (adjoint bias, adjoint weight)
    """

let learning9 =
    "learning9",[loops;cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;mnist;console],"Does the full training work with Mnist?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inb { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> CudaTensor.from_host_tensors

inl input_size = 784
inl hidden_size = 10

inb network = init (sigmoid hidden_size) input_size >>! with_error cross_entropy

Loops.for' {from=0; near_to=10;body=inl {next} -> 
    inl train_cost =
        Console.writeline "Training:"
        run {
            network input=train_images; label=train_labels; minibatch_size=128
            optimizer=Optimizer.sgd 0.25f32
            state={running_cost=0.0}
            }

    if macro.fs bool [text: "System.Double.IsNaN"; args: train_cost] then
        Console.writeline "Training diverged. Aborting..."
    else
        inl test_cost =
            Console.writeline "Test:"
            run {
                network input=test_images; label=test_labels
                state={running_cost=0.0; running_accuracy=0}
                }
        next ()
    }
    """

let learning10 =
    "learning10",[loops;cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;mnist;console],"Does the full training work with the char-RNN?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inl size = {
    seq = 1115394
    minibatch = 128
    step = 64
    hot = 128
    }

// I got this dataset from Karpathy.
inl path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"
inb data = 
    macro.fs (array char) [text: "System.IO.File.ReadAllText"; args: path; text: ".ToCharArray()"]
    |> Array.map (inl x -> 
        inl x = to int64 x
        assert (x < size.hot) "The inputs need to be in the [0,127] range."
        to uint8 x
        )
    |> HostTensor.array_as_tensor
    |> HostTensor.assert_size size.seq
    |> CudaTensor.from_host_tensor

inl round mult x = x - x % mult

inl view f x = x.view_span f
inl data =
    view (round size.minibatch) data
    |> HostTensor.split (inl x -> size.minibatch,x/size.minibatch)

inl minibatch,seq = data.dim
inb input =
    inl data = CudaTensor.to_dev_tensor data
    CudaKernel.init {rev_thread_limit=32; dim=seq,minibatch,size.hot} (inl seq minibatch ->
        inl x = data minibatch seq .get
        inl hot -> if x = to uint8 hot then 1f32 else 0f32
        )

input
|> view (const 4)
|> CudaTensor.to_host_tensor
|> view (inl a,_,c -> a,4,c)
|> HostTensor.print
() 
    """

let grad1 =
    "grad1",[loops;cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;mnist;console],"Does gradient checking pass for the full network?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inb CudaBlasModule = CudaBlas
inl CudaBlas = CudaBlasModule {stream Cuda CudaKernel CudaTensor}
inl float = float32
open Learning {float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inb { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> CudaTensor.from_host_tensors

inl input_size = 784
inl hidden_size = 10

inb network = init (sigmoid hidden_size) input_size >>! with_error cross_entropy

inl train_images=train_images .view_span (const 32)
inl train_labels=train_labels .view_span (const 32)

grad_check {network input=train_images; label=train_labels}
()
    """

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

let tests =
    [|
    allocator1
    tensor1;tensor2
    kernel1;kernel2;kernel3;kernel4;kernel5;kernel6;kernel7;kernel8;kernel9
    kernel10;kernel11;kernel12
    random1
    blas1
    learning1;learning2;learning3;learning4;learning5;learning6;learning7;learning8;learning9
    learning10
    grad1
    |]

//rewrite_test_cache tests cfg None //(Some(0,40))

let message_passing1 = 
    "message_passing1",[console],"Does the message passing monad work in Spiral?",
    """
inl rec (>>=) a b x =
    inl x,a = a x
    inl x,b = b x
    x, a >>= b

inl rec message_init {f input state} input' =
    match input with
    | .step -> .step, message_init {f state input=input'}
    | .finally, input ->
        inl x,state = f state input
        (.finally, x), message_init {f state input=input'}
    | input ->
        inl x,state = f state input
        x, message_init {f state input=input'}

inl message_init f = message_init {f state=.nil; input=.step}

inl print msg state x =
    Console.writeline msg
    inl state = 
        match state with
        | .nil -> 0
        | state -> state + x
    Console.writeline ("state=",state)
    Console.writeline ("x=",x)
    x, state

inl a = message_init (print "I am in a.")
inl b = message_init (print "I am in b.")
inl c = message_init (print "I am in c.")

inl m = a >>= b >>= c
inl f x m = 
    inl x, x' = m x
    print_static x
    x'
inl x = f 100 m |> f 200 |> f (.finally,300) |> f .step |> f .step |> f .step
()
    """

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" message_passing1
|> printfn "%s"
|> ignore
