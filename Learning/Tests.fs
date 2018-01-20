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

inl h = HostTensor.init 32 (inl x -> x % 2 = 0)
inb a1 = CudaTensor.from_host_tensor h
inb o1 = CudaTensor.zero_like a1
CudaKernel.map' (inl a _ -> a = false) a1 o1
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
inl outer_size = 32

inb a1 = CudaRandom.create_tensor .Uniform {elem_type=float32; dim=outer_size,inner_size}
inb a2 = CudaRandom.create_tensor .Uniform {elem_type=float32; dim=outer_size,inner_size}
inb a3 = CudaTensor.create {elem_type=float32; dim=1} // This causes the alignment error.
inl f a1 a2 =
    CudaKernel.map_d1_redo_map {
        map_in=const
        neutral_elem=-infinityf32,0f32
        redo=inl a b -> if fst a > fst b then a else b
        map_out=inl x -> snd x > 0.5f32
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

inl sigmoid_initializer' x = 
    inl stddev = sqrt (2.0f32 / unsafe_convert float32 (Tuple.foldl (inl s x -> s + HostTensor.span x) 0 x.dim))
    CudaRandom.fill {dst=.Normal; stddev mean=0f32} x

inl sigmoid_initializer dim ret = 
    inb x = CudaTensor.create {elem_type=float32; dim}
    sigmoid_initializer' (x.view_span (3,4))
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

inb {apply} = init (sigmoid hidden_size) input_size >>! with_error square
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

inb network = init (sigmoid hidden_size) input_size >>! with_error cross_entropy

inl train_images=train_images .view_span 32
inl train_labels=train_labels .view_span 32

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

//rewrite_test_cache tests cfg None //(Some(0,40))

let tests =
    [|
    allocator1
    tensor1;tensor2
    kernel1;kernel2;kernel3;kernel4;kernel5
    random1
    blas1
    learning1;learning2;learning3;learning4;learning5;learning6;learning7;learning8;learning9
    grad1
    |]

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning8
|> printfn "%s"
|> ignore
