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

let kernel1 =
    "kernel1",[cuda_modules],"Does the map kernel work?",
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

let kernel2 =
    "kernel2",[cuda_modules],"Does the map_redo_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl h = HostTensor.init 2048 ((+) 1)
inl a1 = s.CudaTensor.from_host_tensor h

s.CudaKernel.map_redo_map {neutral_elem=0; redo=(+)} a1
|> s.CudaTensor.print // 2098176
    """

let kernel3 =
    "kernel3",[cuda_modules],"Does the d2_replicate_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 8
inl outer_size = 8

inl h = HostTensor.init inner_size (const 123)
inl h' = HostTensor.init (outer_size,inner_size) (inl a b -> a,b)
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.from_host_tensor h'
inl o1 = s.CudaKernel.d2_replicate_map (inl a b -> a, b) a1 a2
Tuple.iter s.CudaTensor.print (a1,a2,o1)
    """

let kernel4 =
    "kernel4",[cuda_modules],"Does the mapi_d2_redo_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 4

inl h = HostTensor.init (outer_size,inner_size) (inl _ x -> x)
inl h' = HostTensor.init inner_size id
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.from_host_tensor h'
inl o = 
    s.CudaKernel.mapi_d2_redo_map {
        map_in=(+)
        neutral_elem=0; redo=(+)
        } a1 a2
Tuple.iter s.CudaTensor.print (a1,a2,o)
    """

let kernel5 =
    "kernel5",[cuda_modules],"Does the mapi_d1_redo_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 32

inl a1 = s.CudaRandom.create {dst=.Uniform} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = s.CudaRandom.create {dst=.Uniform} {elem_type=float32; dim=outer_size,inner_size}
inl a3 = s.CudaTensor.create {elem_type=float32; dim=1}
inl f a1 a2 =
    s.CudaKernel.mapi_d1_redo_map {
        map_in=const
        neutral_elem=-infinityf32,0f32
        redo=inl a b -> if fst a > fst b then a else b
        map_out=snd
        } a1 a2
inl o1 = f (a1, a2) ()

Tuple.iter s.CudaTensor.print (a1,o1)

inl f a1 =
    s.CudaKernel.mapi_d1_redo_map {
        mapi_in=inl j i a _ -> a,i
        neutral_elem=-infinityf32,-1
        redo=inl a b -> if fst a > fst b then a else b
        } a1 ()

s.CudaTensor.print (f a1)
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
            f=inl a b -> if fst a <= fst b then a else b
            }
        map_out=snd
        } a1 a2

Tuple.iter s.CudaTensor.print (a1,o1)
    """

let kernel11 =
    "kernel11",[cuda_modules],"Does the mapi_d1_seq_broadcast kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 4
inl outer_size = 1

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,inner_size}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=outer_size,inner_size}
inl o1 = // Softmax forward
    s.CudaKernel.mapi_d1_seq_broadcast {
        seq = 
            {
            redo=max // max x
            map_out=inl x max_x -> exp (x - max_x) // exp (x - replicate max_x)
            }
            ,
            {
            redo=(+) // sum z
            map_out=inl z sum_z -> z / sum_z // z / replicate sum_z
            }
        } a1

inl o2 = 
    s.CudaKernel.map_d1_inscan_map {
        redo=(+)
        neutral_elem=0f32
        } o1

inl o3 = // Softmax backward
    s.CudaKernel.mapi_d1_seq_broadcast {
        seq = 
            {
            map_in=inl z,dz -> z*dz
            redo=(+)
            map_out=inl (z,dz) er -> (dz - er) * z
            }
        } (a1,a2)

Tuple.iter s.CudaTensor.print (a1,o1,o2,o3)
//  [|0.2925366; -0.718359; 0.09999694; -0.3931978|]
//  [|0.3714055; 0.1351518; 0.3063581; 0.1870845|]
//  [|0.3714055; 0.5065573; 0.8129154; 0.9999999|]
//  [|0.5028772; -1.234876; 0.1718971; -0.6759161|]
    """

let kernel12 =
    "kernel12",[cuda_modules],"Does the init kernel work?",
    """
inb s = CudaModules (1024*1024)

inl o1 = s.CudaKernel.init {rev_thread_limit=32; dim=2,2,128} (inl a b c -> a, b, c)
s.CudaTensor.print o1
    """

let kernel13 =
    "kernel13",[cuda_modules],"Does the mapi_d1_dredo_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=6,12,256}
s.CudaTensor.print x
inl a,b,c = x.dim
inl c = to float32 (HostTensor.span c)
inl v =
    s.CudaKernel.mapi_d1_dredo_map { 
        redo_in = {
            neutral_elem=0f32
            redo=(+)
            }
        redo_mid = {
            mapi_in=inl j i a -> a, i
            neutral_elem=-infinityf32,-1
            redo=inl a b -> if fst a > fst b then a else b
            }
        map_out = inl a, i -> a / c, i
        } x
s.CudaTensor.print v
    """

let kernel14 =
    "kernel14",[cuda_modules],"Does the iter kernel work?",
    """
inb s = CudaModules (1024*1024)
inl x = s.CudaTensor.create {elem_type=int64,int64,int64; dim=2,2,128}
inl _ = 
    inl x = CudaAux.to_dev_tensor x
    s.CudaKernel.iter {rev_thread_limit=32; dim=x.dim} (inl a b c -> x a b c .set (a, b, c))
s.CudaTensor.print x
    """

let kernel15 =
    "kernel15",[cuda_modules],"Does the iteri_dd1_seq_broadcast kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = {from=-32; near_to=32}
inl middle_size = 3
inl outer_size = 2

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,middle_size,inner_size}
inl o = s.CudaRandom.create {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=outer_size,middle_size,inner_size}
inl to_dev_tensor = CudaAux.to_dev_tensor
inl _ = // Softmax forward
    inl x = to_dev_tensor x
    inl o = to_dev_tensor o
    inl index c x next = 
        inl f i = Struct.map ((|>) i)
        inl rec loop c x =
            if c > 0 then inl i -> loop (c-1) (f i x)
            else next x
        assert (lit_is c && c >= 0) "c must be a literal greater or equal to zero."
        loop c x

    s.CudaKernel.iteri_dd1_seq_broadcast {
        mapi_in =
            inb x = index 3 x
            x.get
        seq = 
            {
            redo=max
            map_out=inl x max_x -> exp (x - max_x) // exp (x - replicate max_x)
            }
            ,
            {
            redo=(+)
            mapi_out=
                inb o = index 3 o
                inl z sum_z -> o.set (z / sum_z)
            }
        } x.dim

s.CudaTensor.print x
s.CudaTensor.print o
    """

let kernel16 =
    "kernel16",[cuda_modules],"Does the init_d1_redo_outit kernel work?",
    """
inb s = CudaModules (1024*1024)
inl inner_size = 6
inl middle_size = 3
inl outer_size = 2
inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,middle_size,inner_size}
inl o = s.CudaRandom.create {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=outer_size,middle_size}

inl o =
    inl x = CudaAux.to_dev_tensor x
    s.CudaKernel.init_d1_redo_outit {
        dim=(outer_size,middle_size),inner_size
        init=inl (i, j) -> 
            inl x = x i j 
            inl k -> x k .get
        neutral_elem=0f32
        redo=(+)
        }

s.CudaTensor.print x
s.CudaTensor.print o
    """

let kernel17 =
    "kernel17",[cuda_modules],"Does the init_d2_redo_outit kernel work?",
    """
inb s = CudaModules (1024*1024)
inl inner_size = 6
inl middle_size = 3
inl outer_size = 2
inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=outer_size,middle_size,inner_size}
inl o = s.CudaRandom.create {dst=.Normal; stddev=0f32; mean=1f32} {elem_type=float32; dim=inner_size}

inl o =
    inl x = CudaAux.to_dev_tensor x
    s.CudaKernel.init_d2_redo_outit {
        dim=(outer_size,middle_size),inner_size
        // Note that the arguments are in reverse order compared to init_d1_redo_outit.
        init=inl inner (outer,mid) -> x outer mid inner .get
        neutral_elem=0f32
        redo=(+)
        }

s.CudaTensor.print x
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

inl O = 
    s.CudaSolve.potrf .Lower S {
        on_succ=stack
        on_fail=inl result ->
            inl ty = type stack S
            if result > 0i32 then failwith ty (string_format "The leading minor of order {0} is not positive definite." result)
            else failwith ty (string_format "The {0}-th parameter is wrong." result)
        }

s.CudaTensor.print O
s.CudaTensor.print (s.CudaBlas.trmm .Right .Lower .T .NonUnit 1f32 O O)
    """

let cusolver2 =
    "cusolver2",[cuda_modules],"Does the LU decomposition (getrf) work?",
    """
inb s = CudaModules (1024*1024)

inl n = 5
inl dim = n,n
inl A = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim}

inl {out ipiv} = s.CudaSolve.getrf A .assert

inl lu O =
    inl dim = O.dim
    inb O = s.CudaBlas.transpose O |> CudaAux.temporary
    inl O = CudaAux.to_dev_tensor O
    inl L =
        s.CudaKernel.init {dim} <| inl a b ->
            if a = b then 1f32 
            elif a > b then O a b .get
            else 0f32
            
    inl U =
        s.CudaKernel.init {dim} <| inl a b ->
            if a <= b then O a b .get
            else 0f32

    L, U

inl L, U = lu out

s.CudaTensor.print ipiv
s.CudaTensor.print L
s.CudaTensor.print U

s.CudaTensor.print A
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT 1f32 L U)

() // TODO: Work in progress.
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

inl cholesky_inverse s C =
    inl C_sqr = s.CudaSolve.potrf .Lower C .assert
    inb C_sqr_inv = s.CudaBlas.trinv .Lower C_sqr |> CudaAux.temporary
    s.CudaBlas.trmm' .Left .Lower .T .NonUnit 1f32 C_sqr_inv C_sqr_inv C_sqr
    C_sqr

inl C_inv = cholesky_inverse s C
s.CudaTensor.print C_inv
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C C_inv)
    """

let tests =
    [|
    allocator1
    tensor1;tensor2;tensor3
    kernel1;kernel2;kernel3;kernel4;kernel5;kernel6;kernel7;kernel8;kernel9
    kernel10;kernel11;kernel12;kernel13;kernel14;kernel15;kernel16;kernel17
    random1
    blas1;blas2;blas3;blas4;blas5;blas6;blas7;blas8;blas9
    cusolver1;cusolver2
    inverse1
    |]

//rewrite_test_cache tests cfg None //(Some(0,40))

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) cusolver2
|> printfn "%s"
|> ignore
