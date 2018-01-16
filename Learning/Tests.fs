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

inl h = HostTensor.init 32 ((+) 1)
inb a1 = CudaTensor.from_host_tensor h
inb o1 = CudaTensor.zero_like a1
CudaKernel.map' (inl a _ -> a * 2) a1 o1
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
inl o1 = CudaKernel.map_redo {neutral_elem=0; redo=(+)} a1
Console.writeline o1
    """

let kernel3 =
    "kernel3",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does the replicate_map kernel work?",
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
inb o1 = CudaKernel.replicate_map (inl a b -> a, b) a1 a2
inb o2 = CudaKernel.replicate_map (inl a _ -> a) a1 outer_size
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

inl inner_size = 8
inl outer_size = 32

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
inl outer_size = 1

inb a1 = CudaRandom.create_tensor .Uniform {elem_type=float32; dim=outer_size,inner_size}
inb a2 = CudaRandom.create_tensor .Uniform {elem_type=float32; dim=outer_size,inner_size}
inb a3 = CudaTensor.create {elem_type=float32; dim=1} // This causes the alignment error.
inl f a1 a2 =
    CudaKernel.map_d1_redo_map {
        map_in=const
        neutral_elem=-infinityf32,0f32
        redo=inl a b -> if fst a > fst b then a else b
        map_out=id
        } a1 a2
inb o1 = f (a1, a2) ()

met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,o1)
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

inb o1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=6,6}
CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
    """

let blas1 =
    "blas1",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;console],"Does the gemm work?",
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

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,8}
inb a2 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=8,2}
inb o1 = CudaTensor.create {elem_type=float32; dim=2,2}
CudaBlas.gemm' .nT .nT 1f32 a1 a2 0f32 o1
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (a1,a2,o1)
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=2,8}
inb a2 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=8,2} >>! dr
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=2,8} >>! dr
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=default_float; dim=256,256} >>! dr
inb o1,bck = map_redo {fwd={neutral_elem=0f32; redo=(+)}; bck=inl {out} -> out.A} a1
bck()
Console.writeline <| primal o1 / unsafe_convert float32 (HostTensor.length (primal a1))
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive

inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=default_float; dim=6,6} >>! dr
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive
open Activation
open Error

inb input = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=2,6}
inb weight = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=6,4} >>! dr
inb label = CudaTensor.zero {elem_type=default_float; dim=2,4}
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inl input_size = 6
inl hidden_size = 4
inb input = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=2,input_size}
inb label = CudaTensor.zero {elem_type=default_float; dim=2,hidden_size}

inb {apply update_weights} = init (sigmoid hidden_size) input_size >>! with_error square
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inb { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> CudaTensor.from_host_tensors

inl input_size = 784
inl hidden_size = 10

inb {apply update_weights} = init (sigmoid hidden_size) input_size >>! with_error square
inb {cost},bck = apply (test_images,test_labels)

Console.writeline ("Cost is:", primal cost)

adjoint cost := 1f32
bck()
    """

let learning8 =
    "learning8",[loops;cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;mnist;console],"Does the full training work with Mnist?",
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inb { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> CudaTensor.from_host_tensors

inl input_size = 784
inl hidden_size = 10

inb network = init (sigmoid hidden_size) input_size >>! with_error square

inl train_images=train_images .view_span 32
inl train_labels=train_labels .view_span 32

Loops.for {from=0; near_to=1;body=inl _ ->
    run {
        network input=train_images; label=train_labels; minibatch_size=4
        optimizer=Optimizer.sgd 0.01f32
        state={
            running_cost=dyn 0.0
            running_accuracy=dyn 0
            }
        }
    }
    """

let learning9 =
    "learning9",[cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;console],"Does the add_bias work?",
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Primitive
open Activation
open Error

inl input_size = 32
inl outer_dim = 6
inl inner_dim = 16
inb input = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=input_size,outer_dim}
inb weight = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=default_float; dim=outer_dim,inner_dim} >>! dr
inb bias = CudaTensor.zero {elem_type=default_float; dim=inner_dim} >>! dr
inb label = CudaTensor.zero {elem_type=default_float; dim=input_size,inner_dim}

inb {cost},bck = 
    inm o1 = matmult input weight >>= add_bias bias >>= sigmoid
    square (o1,label)

Console.writeline ("Cost is:", primal cost .value)

adjoint cost := 1f32
bck()
met rec show (!dyn o1) = CudaTensor.to_host_tensor o1 |> HostTensor.show |> Console.writeline
Tuple.iter show (adjoint bias, adjoint weight)
    """

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

//rewrite_test_cache tests cfg None //(Some(0,40))

let debug1 =
    "debug1",[loops;cuda;allocator;host_tensor;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;learning;mnist;console],"Where is the memory corruption bug?",
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
inl default_float = float32
open Learning {default_float CudaTensor CudaKernel CudaBlas CudaRandom}
open Error
open Feedforward

inl hidden_size = 5
inl batch_size = 32

inb a=CudaRandom.create_tensor .Uniform {elem_type=float32; dim=batch_size,hidden_size}
inb b=CudaRandom.create_tensor .Uniform {elem_type=float32; dim=batch_size,hidden_size}

met rec show (!dyn o1) = CudaTensor.to_host_tensor (HostTensor.zip o1) |> HostTensor.show |> Console.writeline
show (a,b)

inl by = 2
Loops.for {from=0;near_to=32;by;body=inl {i} ->
    inl f a = a .view_span {from=i;by}
    inl a, b = f a, f b
    accuracy (a,b) id |> HostTensor.show |> Console.writeline
    }
()
    """

let debug2 =
    "debug2",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;console],"Does view_span work correctly with map?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}

open Extern
inl rnd_ty = fs [text: "System.Random"]
inl rnd = FS.Constructor rnd_ty ()
inl rnd_float64 () = FS.Method rnd .NextDouble() float64
inl rnd_float32 () = rnd_float64 () |> unsafe_convert float32

inl hidden_size = 5
inl batch_size = 32

inl h1 = HostTensor.init (batch_size,hidden_size) (inl _ _ -> rnd_float32())

inl zip = HostTensor.zip
inl show a2 = HostTensor.show (zip a2) |> Console.writeline

inl a = h1
inb b = CudaTensor.from_host_tensor h1
inl by = 2
Loops.for {from=0;near_to=32;by;body=inl {i} ->
    inl f a = a .view_span {from=i;by}
    inl a, b = f a, f b
    inb b = CudaKernel.map id b 
    inl b = CudaTensor.to_host_tensor b
    show (a, b)
    HostTensor.equal (a, b) |> Console.writeline
    }
    """

let debug3 =
    "debug3",[allocator;cuda;host_tensor;cuda_tensor;cuda_kernel;cuda_random;console],"Does view_span work correctly with map_d1_redo_map?",
    """
inb Cuda = Cuda
inb Allocator = Allocator {Cuda size=0.7}
inb stream = Cuda.Stream.create()
inl CudaTensor = CudaTensor {stream Cuda Allocator}
inl CudaKernel = CudaKernel {stream Cuda CudaTensor}
inb CudaRandomModule = CudaRandom
inl CudaRandom = CudaRandomModule {stream Cuda CudaTensor}
inl default_float = float32

inl infinity = infinityf32
inl zero = 0f32

inl accuracy' input  =
    inl a, b = input.dim
    inl state = dyn (-infinity,zero)
    inl redo = inl a b -> if fst a > fst b then a else b
    HostTensor.init a (inl i ->
        inl {from near_to} = b
        inl input = input i
        Loops.for { from near_to state
            body=inl {state i} -> redo state (input i .get)
            } 
        )

inl accuracy input =
    CudaKernel.map_d1_redo_map {
        map_in=const
        neutral_elem=-infinity,zero
        redo=inl a b -> if fst a > fst b then a else b
        } input ()

open Extern
inl rnd_ty = fs [text: "System.Random"]
inl rnd = FS.Constructor rnd_ty ()
inl rnd_float64 () = FS.Method rnd .NextDouble() float64
inl rnd_float32 () = rnd_float64 () |> unsafe_convert float32

inl hidden_size = 5
inl batch_size = 32

inl h1 = HostTensor.init (batch_size,hidden_size) (inl _ _ -> rnd_float32())
inl h2 = HostTensor.init (batch_size,hidden_size) (inl _ _ -> rnd_float32())

inl zip = HostTensor.zip
inl show a2 = HostTensor.show (zip a2) |> Console.writeline

inl a = zip (h1,h2)
inb b = CudaTensor.from_host_tensor a
inl by = 2
Loops.for {from=0;near_to=32;by;body=inl {i} ->
    inl f a = a .view_span {from=i;by}
    inl a, b = f a, f b
    inl a = accuracy' a
    inb b = accuracy b 
    inl b = CudaTensor.to_host_tensor b
    show (a, b)
    HostTensor.equal (a, b) |> Console.writeline
    }
    """

let tests =
    [|
    allocator1
    tensor1;tensor2
    kernel1;kernel2;kernel3;kernel4;kernel5
    random1
    blas1
    learning1;learning2;learning3;learning4;learning5;learning6;learning7;learning8;learning9
    |]

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" debug1
|> printfn "%s"
|> ignore
