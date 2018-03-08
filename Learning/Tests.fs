module Learning.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Module

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

let kernel1 =
    "kernel1",[cuda_modules],"Does the map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl h = HostTensor.init 32 (inl x -> x + 1)
inl a1 = s.CudaTensor.from_host_tensor h
inl o1 = s.CudaTensor.zero_like a1
s.CudaKernel.map' (inl a _ -> a * 2) a1 o1

inl a2 = s.CudaTensor.to_host_tensor o1
HostTensor.zip (h,a2) |> HostTensor.show |> Console.writeline
    """

let kernel2 =
    "kernel2",[cuda_modules],"Does the map_redo_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl h = HostTensor.init 1024 ((+) 1)
inl a1 = s.CudaTensor.from_host_tensor h

s.CudaKernel.map_redo_map {neutral_elem=0; redo=(+)} a1
|> s.CudaTensor.print // 524800
    """

let kernel3 =
    "kernel3",[cuda_modules],"Does the d2_replicate_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 8
inl outer_size = 8

inl h = HostTensor.init inner_size (const (2,2))
inl h' = HostTensor.init (outer_size,inner_size) (inl a b -> a,b)
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.from_host_tensor h'
inl o1 = s.CudaKernel.d2_replicate_map (inl a b -> a, b) a1 a2
inl o2 = s.CudaKernel.d2_replicate_map (inl a _ -> a) a1 outer_size
Tuple.iter s.CudaTensor.print (o1,o2)
    """

let kernel4 =
    "kernel4",[cuda_modules],"Does the map_d2_redo_map' kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 128

inl h = HostTensor.init (outer_size,inner_size) (inl _ x -> x)
inl h' = HostTensor.init inner_size (const 10)
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.from_host_tensor h'
inl f map_in a2 =
    s.CudaKernel.map_d2_redo_map {
        map_in
        neutral_elem=0; redo=(+)
        map_out=inl a -> a/2
        } a1 a2
inl o1 = f (inl a b -> a+1) ()
inl o2 = f (inl a b -> a+b) a2

Tuple.iter s.CudaTensor.print (a1,o1,o2)
    """

let kernel5 =
    "kernel5",[cuda_modules],"Does the map_d1_redo_map' kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 32

inl a1 = s.CudaRandom.create .Uniform {elem_type=float32; dim=outer_size,inner_size}
inl a2 = s.CudaRandom.create .Uniform {elem_type=float32; dim=outer_size,inner_size}
inl a3 = s.CudaTensor.create {elem_type=float32; dim=1}
inl f a1 a2 =
    s.CudaKernel.map_d1_redo_map {
        map_in=const
        neutral_elem=-infinityf32,0f32
        redo=inl a b -> if fst a > fst b then a else b
        map_out=snd
        } a1 a2
inl o1 = f (a1, a2) ()

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel6 =
    "kernel6",[cuda_modules],"Does the map_d1_inscan_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 50
inl outer_size = 3

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    s.CudaKernel.map_d1_inscan_map {
        neutral_elem=-infinityf32
        redo=max
        } a1

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel7 =
    "kernel7",[cuda_modules],"Does the map_d2_inscan_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 6
inl outer_size = 64

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    s.CudaKernel.map_d2_inscan_map {
        neutral_elem=-infinityf32
        redo=max
        } a1

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel8 =
    "kernel8",[cuda_modules],"Does the map_d1_exscan_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 10

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    s.CudaKernel.map_d1_exscan_map {
        neutral_elem=0f32
        redo=(+)
        } a1

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel9 =
    "kernel9",[cuda_modules],"Does the map_inscan_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 64
inl outer_size = 3

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = 
    s.CudaKernel.map_inscan_map {
        neutral_elem=infinityf32
        redo=min
        } a1

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel10 =
    "kernel10",[cuda_modules],"Does the mapi_d1_inscan_mapi_d1_reduce_mapi kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 6

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=0f32; mean=0f32} {elem_type=float32; dim=outer_size}
inl o1 = // The sampling function
    s.CudaKernel.mapi_d1_inscan_mapi_d1_reduce_mapi {
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

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel11 =
    "kernel11",[cuda_modules],"Does the map_d1_seq_broadcast kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 4
inl outer_size = 1

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = // Softmax forward
    s.CudaKernel.map_d1_seq_broadcast {
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
    s.CudaKernel.map_d1_inscan_map {
        redo=(+)
        neutral_elem=0f32
        } o1

inl o3 = // Softmax backward
    s.CudaKernel.map_d1_seq_broadcast {
        seq = 
            {
            map_redo=inl in,er -> in*er
            redo=(+)
            map=inl (in,er) sum -> er * in * (1f32 - in) - in * (sum - er * in)
            }
        } (a1,a2)

Tuple.iter s.CudaTensor.print (a1,o3)
//    [|0.2925366; -0.718359; 0.09999694; -0.3931978|]
//    [|0.5028772; -1.234876; 0.1718971; -0.6759161|]
    """

let kernel12 =
    "kernel12",[cuda_modules],"Does the init kernel work?",
    """
inb s = CudaModules (1024*1024)

inl o1 = s.CudaKernel.init {rev_thread_limit=32; dim=2,2,128} (inl a b c -> a, b, c)
s.CudaTensor.print o1
    """

let learning1 =
    "learning1",[cuda_modules;learning],"Does the matmult work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float s 
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=8,2} |> s.dr
inl o1,bck = matmult a1 a2 s
bck()

primal o1 |> s.CudaTensor.print
    """

let learning2 =
    "learning2",[cuda_modules;learning],"Does the map work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float s
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8} |> s.dr
inl o1,bck = map {fwd=((*) 10f32); bck=inl {out} -> out.A * 10f32} a1 s
bck()
primal o1 |> s.CudaTensor.print
    """

let learning3 =
    "learning3",[cuda_modules;learning],"Does the map_redo_map work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float s
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=float; dim=256,256} |> s.dr
inl l = primal a1 .span_outer |> to float
/// map_redo_map assumes an adjoint of 1. No need to set to that value directly.
inl o1,bck = map_redo_map {fwd={neutral_elem=0f32; redo=(+); map_out=inl x -> x/l}; bck=inl _ -> l} a1 s
o1() |> Console.writeline
    """

let learning4 =
    "learning4",[cuda_modules;learning],"Does the map_redo's backwards pass work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float s
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=float; dim=6,6} |> s.dr
inl l = primal a1 .span_outer |> to float
/// map_redo_map assumes an adjoint of 1. No need to set to that value directly.
inl o1,bck = map_redo_map {fwd={neutral_elem=0f32; redo=(+); map_out=inl x -> x/l}; bck=inl _ -> l} a1 s
bck()
adjoint a1 |> s.CudaTensor.print
    """

let learning5 =
    "learning5",[cuda_modules;learning],"Does the basic pass work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float s
open Primitive
open Activation
open Error

inl input = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,6}
inl weight = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=6,4} |> s.dr
inl label = s.CudaTensor.zero {elem_type=float; dim=2,4}
inl f = matmult input weight >>= sigmoid >>= square label
inl {cost},bck = f s

string_format "Cost is: {0}" (cost()) |> Console.writeline

bck()
adjoint weight |> s.CudaTensor.print
    """

let learning6 =
    "learning6",[cuda_modules;learning],"Does the basic layer work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float s
open Primitive
open Activation
open Error
open Feedforward

inl input_size = 6
inl hidden_size = 4
inl batch_size = 2
inl input = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=batch_size,input_size}
inl label = s.CudaTensor.zero {elem_type=float; dim=batch_size,hidden_size}

inl network = 
    open Layer
    inl label = input hidden_size
    inl input = input input_size
    inl network =
        input
        |> sigmoid hidden_size
        |> error square label
    create (input,label) network s

inl {cost},{bck} = network.run (input, label) {bck=const ()} s

string_format "Cost is: {0}" (cost ()) |> Console.writeline
bck()
    """

let learning7 =
    "learning7",[cuda_modules;learning;mnist],"Does the pass work with Mnist?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float s
open Primitive
open Activation
open Error
open Feedforward

inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors

inl input_size = 784
inl hidden_size = 10

inl network = 
    open Layer
    inl label = input hidden_size
    inl input = input input_size
    inl network =
        input
        |> sigmoid hidden_size
        |> error square label
    create (input,label) network s

inl {cost},{bck} = network.run (test_images, test_labels) {bck=const ()} s

string_format "Cost is: {0}" (cost()) |> Console.writeline
bck()
    """

let learning8 =
    "learning8",[cuda_modules;learning],"Does the add_bias work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float s
open Primitive
open Activation
open Error
open Feedforward

inl input_size = 32
inl outer_dim = 6
inl inner_dim = 16
inl input = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=input_size,outer_dim}
inl weight = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=outer_dim,inner_dim} |> s.dr
inl bias = s.CudaTensor.zero {elem_type=float; dim=inner_dim} |> s.dr
inl label = s.CudaTensor.zero {elem_type=float; dim=input_size,inner_dim}

inl f = matmult input weight >>= add_bias bias >>= sigmoid >>= square label
inl {cost},bck = f s
string_format "Cost is: {0}" (cost()) |> Console.writeline

bck()
    """

let learning9 =
    "learning9",[cuda_modules;learning;mnist],"Does the full training work with Mnist?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float s
open Primitive
open Activation
open Error

inl minibatch_size = 128
inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors
    |> module_map (inl _ x -> 
        x.view_span (inl a,_ -> a - a % minibatch_size)
         .split (inl a,b -> (a/minibatch_size,minibatch_size),b)
        )

inl input_size = 784
inl hidden_size = 10

inl network = 
    open Feedforward.Layer
    
    inl label = input hidden_size
    inl input = input input_size
    inl network =
        input
        |> sigmoid hidden_size
        |> error cross_entropy label
    create (input,label) network s

Loops.for' {from=0; near_to=10;body=inl {next} -> 
    open Feedforward.Loops
    open Body

    inl cost =
        for {
            data=train_images, train_labels
            body=train {
                network
                optimizer=Optimizer.sgd 0.25f32
                }
            } s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        inl max_ac = test_labels.span_outer2
        inl cost, ac =
            for {
                data=test_images, test_labels
                body=test {
                    network 
                    }
                } s 

        string_format "Testing: {0}({1}/{2})" (cost, ac, max_ac) |> Console.writeline
        next ()
    }
    """

let grad1 =
    "grad1",[cuda_modules;learning;mnist],"Does gradient checking pass for the full network?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float s
open Primitive
open Activation
open Error
open Feedforward

inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors

inl input_size = 784
inl hidden_size = 10

inl network = 
    open Layer
    init (sigmoid hidden_size) input_size s |> with_error cross_entropy

inl train_images=train_images .view_span (const 32)
inl train_labels=train_labels .view_span (const 32)

grad_check {network input=train_images; label=train_labels} s
()
    """

let learning10 =
    "learning10",[cuda_modules;learning],"Does the full training work with the char-RNN?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float s
open Primitive
open Activation
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
inl data = 
    macro.fs (array char) [text: "System.IO.File.ReadAllText"; args: path; text: ".ToCharArray()"]
    |> Array.map (inl x -> 
        inl x = to int64 x
        assert (x < size.hot) "The inputs need to be in the [0,127] range."
        to uint8 x
        )
    |> HostTensor.array_as_tensor
    |> HostTensor.assert_size size.seq
    |> s.CudaTensor.from_host_tensor

inl round mult x = x - x % mult
inl view f x = x.view_span f
inl data =
    view (round size.minibatch) data
    |> HostTensor.split (inl x -> size.minibatch,x/size.minibatch)

inl minibatch,seq = data.dim
inl input =
    inl data = s.CudaTensor.to_dev_tensor data 
    s.CudaKernel.init {rev_thread_limit=32; dim=seq,minibatch,size.hot} (inl seq minibatch ->
        inl x = data minibatch seq .get
        inl hot -> if x = to uint8 hot then 1f32 else 0f32
        )

input
|> view (const 4)
|> s.CudaTensor.to_host_tensor
|> view (inl a,_,c -> a,4,c)
|> HostTensor.print
    """

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

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning9
|> printfn "%s"
|> ignore
