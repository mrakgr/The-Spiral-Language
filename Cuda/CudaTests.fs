module Cuda.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types

let cfg = {Spiral.Types.cfg_default with trace_length=160; cuda_assert_enabled=false}

let allocator1 =
    "allocator1",[allocator;cuda],"Does the allocator work?",
    """
inb s = Cuda
inb s = Allocator s (1024*256)
inl a = s.allocate 128
inl b = s.allocate 64
inl c = s.allocate 32
inl print_pointer c = Console.printfn "{0}" c.Try
print_pointer a
print_pointer b
print_pointer c

c.Dispose
b.Dispose

inl b = s.allocate 64
inl c = s.allocate 32

print_pointer b
print_pointer c

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
inl a = s.RegionStream.allocate
inl b = s.RegionStream.allocate
inl c = s.RegionStream.allocate
a.stream.wait_on b.stream
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
inl s = s.RegionStream.allocate

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
inl s = s.RegionStream.allocate

inl h = HostTensor.create {elem_type=int64; dim=1,2,3}
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.to_host_tensor a1
()
    """

let tensor3 =
    "tensor3",[cuda_modules],"Does the Cuda tensor copy work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl a = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=3f32} {elem_type=float32; dim=5,5}
inl b = s.CudaTensor.copy a

s.CudaTensor.print a
s.CudaTensor.print b
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
inl s = s.RegionStream.allocate

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
inl s = s.RegionStream.allocate

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,3}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,4}
inl o1 = s.CudaBlas.gemm .nT .nT 1f32 a1 a2
inl o2 = s.CudaBlas.gemm .nT .T 1f32 o1 a2
inl o3 = s.CudaBlas.gemm .T .nT 1f32 a1 o1
Tuple.iter s.CudaTensor.print (a1,a2,o1,o2,o3)
    """

let blas2 =
    "blas2",[cuda_modules],"Do the matinv_batched and gemm_strided_batched work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl a = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=3f32} {elem_type=float32; dim=3,3,3}
s.CudaTensor.print a
inl a' = s.CudaBlas.matinv_batched_asserted a
s.CudaTensor.print a'
inl o = s.CudaBlas.gemm_strided_batched .nT .nT 1f32 a a'
s.CudaTensor.print o
    """

let blas3 =
    "blas3",[cuda_modules],"Does the trmm work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,3}
s.CudaTensor.set (a1 0 1) 0f32
s.CudaTensor.set (a1 0 2) 0f32
s.CudaTensor.set (a1 1 2) 0f32

inl a2 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,4}
inl o1 = s.CudaBlas.gemm .nT .nT 1f32 a1 a2
inl o2 = s.CudaBlas.trmm .Left .Lower .nT .NonUnit 1f32 a1 a2
Tuple.iter s.CudaTensor.print (a1,a2,o1,o2)
    """

let blas4 =
    "blas4",[cuda_modules],"Does the trsm work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,3}
s.CudaTensor.set (a1 0 1) 0f32
s.CudaTensor.set (a1 0 2) 0f32
s.CudaTensor.set (a1 1 2) 0f32

inl a2 = s.CudaKernel.init {dim=3,3} (inl a b -> if a = b then 1f32 else 0f32)
inl o1 = s.CudaBlas.trsm .Left .Lower .nT .NonUnit 1f32 a1 a2
inl o2 = s.CudaBlas.trinv .Lower a1
inl r1 = s.CudaBlas.gemm .nT .nT 1f32 a1 o2
Tuple.iter s.CudaTensor.print (a1,a2,o1,o2,r1)
    """

let blas5 =
    "blas5",[cuda_modules],"Does the symm work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,3}
inl sym a1 r c = s.CudaTensor.set (a1 r c) (s.CudaTensor.get (a1 c r))
sym a1 0 1
sym a1 0 2
sym a1 1 2

inl a2 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4,3}
inl o1 = s.CudaBlas.gemm .nT .nT 1f32 a2 a1

s.CudaTensor.set (a1 0 1) 0f32
s.CudaTensor.set (a1 0 2) 0f32
s.CudaTensor.set (a1 1 2) 0f32

inl o2 = s.CudaBlas.symm .Right .Lower 1f32 a1 a2
Tuple.iter s.CudaTensor.print (a1,a2,o1,o2)
    """

let blas6 =
    "blas6",[cuda_modules],"Does the geam work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl A = s.CudaKernel.init {dim=3,5} (inl a b -> to float32 (a+b))
inl B = s.CudaKernel.init {dim=3,5} (inl a b -> to float32 (100+a+b))
inl C = s.CudaBlas.geam .T .T 1f32 A 1f32 B
s.CudaTensor.print A
s.CudaTensor.print B
s.CudaTensor.print C
s.CudaTensor.print (s.CudaBlas.transpose C)
    """

let blas7 =
    "blas7",[cuda_modules],"Does the syrk work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4,3}
inl o = s.CudaBlas.gemm .T .nT 1f32 x x
s.CudaTensor.print o
inl o = s.CudaBlas.syrk .Lower .T 1f32 x
s.CudaTensor.print o
    """

let blas8 =
    "blas8",[cuda_modules],"Does the gemv work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl A = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4,3}
inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4}
inl o = s.CudaBlas.gemv .T 1f32 A x
s.CudaTensor.print o
inl o = s.CudaBlas.gemm .T .nT 1f32 A (x.split (inl x -> x,1))
s.CudaTensor.print o
    """

let blas9 =
    "blas9",[cuda_modules],"Does the symv work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl A = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4,4}
inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4}
inl o = s.CudaBlas.symv .Lower 1f32 A x
s.CudaTensor.print o
inl o = s.CudaBlas.symm .Right .Lower 1f32 A (x.split (inl x -> 1,x))
s.CudaTensor.print o
    """

let blas10 =
    "blas10",[cuda_modules],"Does the syr work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4}
inl o = s.CudaBlas.syr .Lower 1f32 x
s.CudaTensor.print o
inl o = s.CudaBlas.syrk .Lower .T 1f32 (x.reshape (inl x -> 1,x))
s.CudaTensor.print o
    """

let blas11 =
    "blas11",[cuda_modules],"Does the symv work?",
    """
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

inl A = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4,4}
inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=4}
inl o = s.CudaBlas.trmm .Left .Lower .nT .NonUnit 1f32 A (x.reshape (inl x -> x,1))
s.CudaTensor.print o
inl o = s.CudaBlas.trmv .Lower .nT .NonUnit A x
s.CudaTensor.print o
    """

let cusolver1 =
    "cusolver1",[cuda_modules],"Does the Cholesky decomposition (potrf) work?",
    """
inb s = CudaModules (1024*1024)

inl n = 5
inl A = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=n,n}

inl S = s.CudaBlas.gemm .nT .T 1f32 A A
s.CudaTensor.print S

inl O = s.CudaSolve.potrf .Lower S

s.CudaTensor.print O
s.CudaTensor.print (s.CudaBlas.trmm .Right .Lower .T .NonUnit 1f32 O O)
    """

let inverse1 =
    "inverse1",[cuda_modules;mnist],"Does the matrix inverse using the Cholesky decomposition work?",
    """
inb s = CudaModules (1024*1024*1024)
inl zero = 0f32
inl one = 1f32

inl k = 8
inl n = 8
inl beta = 0.66f32
inl alpha = one - beta

inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors

inl x = train_images .view_span (const k)

inl x = 
    if n <> 28*28 then 
        inb P = s.CudaRandom.create {dst=.Normal; stddev=sqrt (one / to float32 n); mean=0f32} {elem_type=float32; dim=28*28,n} |> CudaAux.temporary
        s.CudaBlas.gemm .nT .nT one x P
    else
        x

inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
s.CudaTensor.print C
Console.writeline "-----"

inl C_inv = s.CudaSolve.cholesky_inverse C
s.CudaTensor.print C_inv
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C C_inv)
    """

let cusolver2 =
    "cusolver2",[cuda_modules],"Does the LU decomposition (getrf) work?",
    """
inb s = CudaModules (1024*1024)

inl n = 2
inl m = 5
inl dim = n,m
//inl A = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim}
inl A = s.CudaKernel.init {dim} (inl a b -> to float32 (a+b*2+1))

inl out, ipiv = s.CudaSolve.getrf A

inl perm ipiv =
    inl p = s.CudaTensor.to_host_tensor ipiv
    inl range :: () = p.dim
    inl ar = HostTensor.init (max n m) id
    Loops.for {range with body=inl {i} ->
        inl swap a b =
            inl x = ar a .get
            inl y = ar b .get
            ar a .set y
            ar b .set x

        swap i (to int64 (p i .get) - 1)
        }

    inl ipiv = CudaAux.to_dev_tensor (s.CudaTensor.from_host_tensor ar)
    s.CudaKernel.init {dim=m,m} <| inl a b ->
        inl p = ipiv a .get
        if b = p then 1f32 else 0f32

inl lu O =
    inl dim = O.dim
    inl O = CudaAux.to_dev_tensor O

    /// Note: The are transposed. getrf loads the array assuming a column major format while Spiral uses the row major.
    inl L =
        s.CudaKernel.init {dim=m,m} <| inl a b ->
            if a = b then 1f32
            elif a < b && a < n then O a b .get
            else 0f32

    inl U =
        s.CudaKernel.init {dim} <| inl a b ->
            if a >= b then O a b .get
            else 0f32

    { L U }

inl {L U} = lu out

// The reason for all the transposes is because Spiral tensors are row major while the Cuda library
// functions are all column major.
Console.writeline "LU decomposition of A (transposed):"
s.CudaTensor.print out
Console.writeline "ipiv:"
s.CudaTensor.print ipiv
Console.writeline "L (transposed):"
s.CudaTensor.print L
Console.writeline "U (transposed):"
s.CudaTensor.print U


inl P = perm ipiv
Console.writeline "The permutation matrix P:"
s.CudaTensor.print P
Console.writeline "The original matrix A:"
s.CudaTensor.print A
Console.writeline "P^-1 * L * U:"
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT 1f32 (s.CudaBlas.gemm .nT .nT 1f32 U L) P)
    """

let inverse2 =
    "inverse2",[cuda_modules;mnist],"Does the matrix inverse using the LU decomposition work?",
    """
inb s = CudaModules (1024*1024*1024)
inl zero = 0f32
inl one = 1f32

inl k = 8
inl n = 8
inl beta = 0.66f32
inl alpha = one - beta

inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors

inl x = train_images .view_span (const k)

inl x = 
    if n <> 28*28 then 
        inb P = s.CudaRandom.create {dst=.Normal; stddev=sqrt (one / to float32 n); mean=0f32} {elem_type=float32; dim=28*28,n} |> CudaAux.temporary
        s.CudaBlas.gemm .nT .nT one x P
    else
        x

inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
s.CudaTensor.print C
Console.writeline "-----"

inl C_inv = s.CudaSolve.lu_inverse C
s.CudaTensor.print C_inv
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C C_inv)
    """

let kernel1 =
    "kernel1",[cuda_modules],"Does the iter kernel work?",
    """
inb s = CudaModules (1024*1024)
inl x = s.CudaTensor.create {elem_type=int64,int64,int64; dim=2,2,128}
inl _ = 
    inl x = CudaAux.to_dev_tensor x
    s.CudaKernel.iter {dim=x.dim} (inl a, b, c -> x a b c .set (a, b, c))
s.CudaTensor.print x
    """

let kernel2 =
    "kernel2",[cuda_modules],"Does the init kernel work?",
    """
inb s = CudaModules (1024*1024)

inl o1 = s.CudaKernel.init {dim=2,2,128} id
s.CudaTensor.print o1
    """

let kernel3 =
    "kernel3",[cuda_modules],"Does the map kernel work?",
    """
/// Initializes all the Cuda parts
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

/// Creates a host tensor with the given generator function.
inl h = HostTensor.init 32 (inl x -> x + 1) 
/// Loads the tensor on the GPU based on the host tensor
inl a1 = s.CudaTensor.from_host_tensor h
/// Makes a tensor of the same type and dimensions as `a1` and zeroes it.
inl o1 = s.CudaTensor.zero_like a1
/// Calls the map operation. `a1` is the input and `o1` is the output.
s.CudaKernel.map' (inl a _ -> a * 2) a1 o1

/// Transfers the tensor back to host.
inl a2 = s.CudaTensor.to_host_tensor o1
/// Zips the two tensors and prints them out.
HostTensor.zip (h,a2) |> HostTensor.show |> Console.writeline
    """

let kernel4 =
    "kernel4",[cuda_modules],"Does the init_exscan kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 10

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = s.CudaTensor.create_like a1
inl _ =
    inl a1, o1 = CudaAux.to_dev_tensor (a1,o1)
    s.CudaKernel.init_exscan {
        dim=a1.dim
        neutral_elem=0f32
        redo=(+)
        init=inl a b -> a1 a b .get
        outit=inl a b -> o1 a b .set
        }

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel5 =
    "kernel5",[cuda_modules],"Does the inscan kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 64
inl outer_size = 3

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = s.CudaTensor.create_like a1
inl _ = 
    inl a1,o1 = CudaAux.to_dev_tensor (a1,o1)
    s.CudaKernel.inscan {
        dim=a1.dim
        neutral_elem=infinityf32
        redo=min
        init=inl i -> a1 i .get
        outit=inl i -> o1 i .set
        }

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel6 =
    "kernel6",[cuda_modules],"Does the redo kernel work?",
    """
inb s = CudaModules (1024*1024)

inl h = HostTensor.init 2048 ((+) 1)
inl a1 = s.CudaTensor.from_host_tensor h
inl o1 = s.CudaTensor.create {dim=1; elem_type=int64}

inl _ =
    inl a1,o1 = CudaAux.to_dev_tensor (a1,o1)
    s.CudaKernel.redo {neutral_elem=0; redo=(+)
        dim=a1.dim
        init=inl i -> a1 i .get
        outit=inl i -> o1 i .set
        }
s.CudaTensor.print o1 // 2098176
    """

let kernel7 =
    "kernel7",[cuda_modules],"Does the iter2 kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 8
inl outer_size = 8

inl h = HostTensor.init inner_size (const 123)
inl h' = HostTensor.init (outer_size,inner_size) (inl a b -> a,b)
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.from_host_tensor h'
inl o1 = s.CudaTensor.create {elem_type=a1.elem_type,a2.elem_type; dim=a2.dim}
inl _ =
    inl a1,a2,o1 = CudaAux.to_dev_tensor (a1,a2,o1)
    s.CudaKernel.iter2 {dim=o1.dim} (inl b -> 
        inl a2,o1 = a2 b, o1 b
        inl a -> 
            inl a1, a2, o1 = a1 a .get, a2 a .get, o1 a
            o1 .set (a1, a2)
            )
Tuple.iter s.CudaTensor.print (a1,a2,o1)
    """

let kernel8 =
    "kernel8",[cuda_modules],"Does the init_inscan kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 50
inl outer_size = 3

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = s.CudaTensor.create_like a1
inl _ = 
    inl a1, o1 = CudaAux.to_dev_tensor (a1,o1)
    s.CudaKernel.init_inscan {
        dim=a1.dim
        neutral_elem=-infinityf32
        redo=max
        init=inl a b -> a1 a b .get
        outit=inl a b -> o1 a b .set
        }

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel9 =
    "kernel9",[cuda_modules],"Does the init_redo kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 32

inl a1 = s.CudaRandom.create {dst=.Uniform} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = s.CudaRandom.create {dst=.Uniform} {elem_type=float32; dim=outer_size,inner_size}
inl a3 = s.CudaTensor.create {elem_type=float32; dim=1}
inl f (a1, a2) =
    inl a1,a2 = CudaAux.to_dev_tensor (a1,a2)
    inl o1 = s.CudaTensor.create {elem_type=float32; dim=outer_size} 
    inl _ = 
        inl o1 = CudaAux.to_dev_tensor o1
        s.CudaKernel.init_redo {
            dim=a1.dim
            init=inl b a -> a1 b a .get, a2 b a .get
            neutral_elem=-infinityf32,0f32
            redo=inl a b -> if fst a > fst b then a else b
            outit=inl b -> o1 b .set << snd
            } 
    o1
inl o1 = f (a1, a2)

Tuple.iter s.CudaTensor.print (a1,o1)

inl f a1 =
    inl a1 = CudaAux.to_dev_tensor a1
    inl o1 = s.CudaTensor.create {elem_type=int64; dim=outer_size}
    inl _ = 
        inl o1 = CudaAux.to_dev_tensor o1
        s.CudaKernel.init_redo {
            dim=a1.dim
            init=inl b a -> a1 b a .get, a
            neutral_elem=-infinityf32,-1
            redo=inl a b -> if fst a > fst b then a else b
            outit=inl b -> o1 b .set << snd
            }
    o1

s.CudaTensor.print (f a1)
    """

let kernel10 =
    "kernel10",[cuda_modules],"Does the init_redo_redo kernel work?",
    """
inb s = CudaModules (1024*1024)

inl c,b,a = 6,12,256
inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=c,b,a}
s.CudaTensor.print a1
inl o1 = s.CudaTensor.create {elem_type=float32,int64; dim=c}
inl _ =
    inl a1,o1 = CudaAux.to_dev_tensor (a1,o1)
    s.CudaKernel.init_redo_redo {
        dim=c,b,a
        init=inl c' k ->
            inl a1 = a1 c'
            k {
                neutral_elem=-infinityf32,-1
                redo=inl a b -> if fst a > fst b then a else b
                init=inl b k -> 
                    inl a1 = a1 b
                    k {
                        neutral_elem=0f32
                        redo=(+)
                        init=inl a -> a1 a .get
                        }
                    |> inl x -> x, b
                outit=
                    inl a,b -> a / to float32 c, b
                    >> o1 c' .set
                }
        }
s.CudaTensor.print o1
    """

let kernel11 =
    "kernel11",[cuda_modules],"Does the init_seq kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 4
inl outer_size = 1

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=outer_size,inner_size}

inl softmax_forward input s =
    inl output = s.CudaTensor.create_like input
    inl ins = CudaAux.to_dev_tensor (input,output)
    s.CudaKernel.init_seq {
        dim=input.dim
        init=inl b k ->
            inl input,output = Tuple.map (inl x -> x b) ins
            inl x = k.block.load input
            inl max_x = k.block.uter max x
            inl z = k.block.map (inl x -> exp (x - max_x)) x
            inl sum_z = k.block.uter (+) z
            k.block.store {
                from=k.block.map (inl z -> z / sum_z) z
                to=output
                }
        }
    output

inl probs input s = 
    inl output = s.CudaTensor.create_like input
    inl _ =
        inl input,output = CudaAux.to_dev_tensor (input,output)
        s.CudaKernel.init_exscan {
            dim=input.dim
            redo=(+)
            neutral_elem=0f32
            init=inl b a -> input b a .get
            outit=inl b a -> output b a .set
            }
    output

inl softmax_backward z dz s =
    assert (z.dim = dz.dim) "The dimensions of output and its adjoint must be the same."
    inl output = s.CudaTensor.create_like z
    inl inputs = CudaAux.to_dev_tensor (z,dz,output)
    s.CudaKernel.init_seq {
        dim=z.dim
        init=inl b k ->
            inl z,dz,output = Tuple.map (inl x -> x b) inputs
            inl z,dz = Tuple.map k.block.load (z,dz)
            inl er = k.block.map (inl z,dz -> z*dz) (z,dz) |> k.block.uter (+)
            k.block.store {
                from=k.block.map (inl {dz z} -> (dz - er) * z) {dz z}
                to=output // Do not forget than the real softmax backwards needs to add to adjoint rather than writing to it directly.
                }
        }
    output

inl o1 = softmax_forward a1 s
inl o2 = probs o1 s
inl o3 = softmax_backward a1 a2 s

Tuple.iter s.CudaTensor.print (a1,o1,o2,o3)
//  [|0.2925366; -0.718359; 0.09999694; -0.3931978|]
//  [|0.3714055; 0.1351518; 0.3063581; 0.1870845|]
//  [|0.3714055; 0.5065573; 0.8129154; 0.9999999|]
//  [|0.5028772; -1.234876; 0.1718971; -0.6759161|]

Console.writeline "-----"

inl inner_size = 10
inl outer_size = 6

inl prob = softmax_forward (s.CudaRandom.create {dst=.Uniform} {elem_type=float32; dim=outer_size,inner_size}) s
inl scan_prob = probs prob s
inl boundary = s.CudaKernel.init {dim=outer_size} (const 0.2f32)

inl sample prob boundary =
    inl b, a = prob.dim
    inl b' :: () = boundary.dim
    assert (b = b') "The outer dimensions of prob and boundary must match."
    inl output = s.CudaTensor.create {elem_type=int64; dim=boundary.dim}
    inl inputs = Tuple.map CudaAux.to_dev_tensor (prob,boundary,output)
    s.CudaKernel.init_seq { // The sampling function
        dim=fst inputs .dim
        init=inl b k ->
            inl prob,boundary,to = Tuple.map (inl x -> x b) inputs
            inl boundary = boundary.get
            k.block.store_scalar {to
                from=
                    k.grid.for_items .x inner_size {
                        state=dyn {scan=0f32; redo=infinityf32,0}
                        body=inl {state i=a num_valid} ->
                            inl prob = prob a .get
                    
                            inl prob_at_a, scan = 
                                inl redo = (+)
                                k.thread.exscan {prefix=state.scan; redo} prob |> Tuple.map (redo state.scan)

                            inl distance_from_boundary, a = 
                                inl x = boundary - prob_at_a
                                (if x < 0f32 then infinityf32 else x), a

                            inl redo =
                                inl redo a b = if fst a <= fst b then a else b
                                k.thread.redo {num_valid redo} (distance_from_boundary, a) |> redo state.redo

                            {scan redo}
                        } .redo |> snd
                }
        }
    output

Tuple.iter s.CudaTensor.print (prob,scan_prob,boundary,sample prob boundary)
//[|
//    [|0.1448696; 0.08975142; 0.1119456; 0.06411155; 0.09191942; 0.09595577; 0.1248195; 0.07712746; 0.1172963; 0.08220332|]
//    [|0.1265654; 0.0857431; 0.08812442; 0.1440635; 0.07469794; 0.09993364; 0.0788334; 0.1179571; 0.08706164; 0.0970199|]
//    [|0.06908347; 0.131681; 0.1043008; 0.1380333; 0.09747635; 0.09509689; 0.07800347; 0.1126144; 0.07219322; 0.1015171|]
//    [|0.1177737; 0.09522544; 0.08323706; 0.09908337; 0.07187302; 0.1231938; 0.08701994; 0.1426689; 0.08100419; 0.09892052|]
//    [|0.06105581; 0.1009913; 0.121569; 0.08423346; 0.07607485; 0.1581762; 0.1482701; 0.07125104; 0.0708849; 0.1074934|]
//    [|0.109375; 0.05619004; 0.1118484; 0.1379087; 0.1251823; 0.09930393; 0.07038308; 0.05500374; 0.1239332; 0.1108716|]
//|]
//[|
//    [|0; 0.1448696; 0.2346211; 0.3465667; 0.4106782; 0.5025976; 0.5985534; 0.7233729; 0.8005004; 0.9177967|]
//    [|0; 0.1265654; 0.2123085; 0.3004329; 0.4444964; 0.5191944; 0.619128; 0.6979614; 0.8159185; 0.9029801|]
//    [|0; 0.06908347; 0.2007645; 0.3050653; 0.4430985; 0.5405749; 0.6356718; 0.7136753; 0.8262897; 0.8984829|]
//    [|0; 0.1177737; 0.2129992; 0.2962362; 0.3953196; 0.4671926; 0.5903865; 0.6774064; 0.8200753; 0.9010795|]
//    [|0; 0.06105581; 0.1620471; 0.283616; 0.3678495; 0.4439244; 0.6021006; 0.7503706; 0.8216217; 0.8925066|]
//    [|0; 0.109375; 0.1655651; 0.2774135; 0.4153222; 0.5405045; 0.6398084; 0.7101915; 0.7651953; 0.8891283|]
//|]
//[|0.2; 0.2; 0.2; 0.2; 0.2; 0.2|]
//[|1; 1; 1; 1; 2; 2|]
    """

let kernel12 =
    "kernel12",[cuda_modules],"Does the inscan_init kernel work?",
    """
inb s = CudaModules (1024*1024)

inl a = 6
inl b = 64

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=b,a}
inl o1 = s.CudaTensor.create {elem_type=float32; dim=a}
inl _ = 
    inl a1,o1 = CudaAux.to_dev_tensor (a1,o1)
    s.CudaKernel.inscan_init {
        dim=a1.dim
        neutral_elem=-infinityf32
        redo=max
        init=inl a b -> a1 b a .get // Note: This kernel has reversed dimensions in init.
        outit=inl a -> o1 a .set
        }

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel13 =
    "kernel13",[cuda_modules],"Does the redo_init kernel work?",
    """
inb s = CudaModules (1024*1024)
inl inner_size = 5
inl middle_size = 3
inl outer_size = 2
inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,middle_size,inner_size}
inl o = s.CudaTensor.create {elem_type=float32; dim=inner_size}

inl _ =
    inl x,o = CudaAux.to_dev_tensor (x,o)
    s.CudaKernel.redo_init {
        dim=(outer_size,middle_size),inner_size
        // Note that the arguments are in reverse order compared to init_redo.
        init=inl inner (outer,mid) -> x outer mid inner .get
        outit=inl inner -> o inner .set
        neutral_elem=-infinityf32
        redo=max
        }

s.CudaTensor.print x
s.CudaTensor.print o
    """


let tests =
    [|
    allocator1
    tensor1;tensor2;tensor3;
    kernel1;kernel2;kernel3;kernel4;kernel5;kernel6;kernel7;kernel8;kernel9
    kernel10;kernel11;kernel12;kernel13
    random1
    blas1;blas2;blas3;blas4;blas5;blas6;blas7;blas8;blas9
    cusolver1;cusolver2
    inverse1;inverse2
    |]

//rewrite_test_cache tests cfg None

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) kernel13
|> printfn "%s"
|> ignore
