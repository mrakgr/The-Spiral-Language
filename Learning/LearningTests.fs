module Learning.Main.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Learning.Cuda

let cfg = {Spiral.Types.cfg_default with trace_length=160; cuda_assert_enabled=false}

let allocator1 =
    "allocator1",[allocator;cuda],"Does the allocator work?",
    """
inb s = Cuda
inb s = Allocator s 1024
inl a = s.allocate 128
inl b = s.allocate 64
inl c = s.allocate 32
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

inl a2 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,4}
inl o1 = s.CudaBlas.gemm .nT .nT 1f32 a1 a2

s.CudaTensor.set (a1 0 1) 0f32
s.CudaTensor.set (a1 0 2) 0f32
s.CudaTensor.set (a1 1 2) 0f32

inl o2 = s.CudaBlas.symm .Left .Lower 1f32 a1 a2
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
    "blas7",[cuda_modules],"Does the geqrfBatched work?",
    """

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

let cholesky1 =
    "cholesky1",[cuda_modules],"What is the minimal viable input?",
    """
inb s = CudaModules (1024*1024)
inl zero = 0f32
inl one = 1f32

// k=1 is not invertible.
inl k = 3
inl n = 3

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=k,n}
inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
inl C_inv = s.CudaBlas.matinv_batched_asserted (C.split (inl a,b -> (1,a),b)) .reshape (inl a,b,c -> b,c)
inl A = s.CudaKernel.init {dim=n,n} (inl a b -> if a = b then 1f32 else 0f32)

s.CudaTensor.print x
s.CudaTensor.print C
s.CudaTensor.print C_inv
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C C_inv)
    """

let cholesky2 =
    "cholesky2",[cuda_modules],"Does the inverse Cholesky update work?",
    """
inb s = CudaModules (1024*1024*16)
inl zero = 0f32
inl one = 1f32

// k=1 is not invertible.
inl k = 64
inl n = 8

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=3f32} {elem_type=float32; dim=k,n}
inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
inl C_inv = s.CudaBlas.matinv_batched_asserted (C.split (inl a,b -> (1,a),b)) .reshape (inl a,b,c -> b,c)
inl A = s.CudaKernel.init {dim=n,n} (inl a b -> if a = b then 1f32 else 0f32)

s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C C_inv)
s.CudaTensor.print x
s.CudaTensor.print C
s.CudaTensor.print C_inv

Console.writeline "---"

inl beta = 0.001f32
inl alpha = one - beta

inl cholesky_inverse s A x =
    inl range :: _ = x.dim
    Loops.for {range with body=inl {state i} ->
        inl z = s.CudaBlas.gemm .nT .nT one x A
        inl z = z .view_span (const {from=i; near_to=i+1})
        inl zz = s.CudaBlas.gemm .T .nT one z z
        inl zzA = s.CudaBlas.gemm .nT .nT one zz A
        inl norm =
            s.CudaKernel.mapi_d1_redo_map {
                map_in=inl x _ -> x*x
                neutral_elem=zero
                redo=(+)
                } z ()
        inl norm = s.CudaTensor.get (norm 0)
        inl c = -one / sqrt alpha / norm * (one - one / sqrt (one + beta / alpha * norm))
        s.CudaBlas.geam' .nT .nT (one / sqrt alpha) A c zzA A
        }

Loops.for {from=0; near_to=100; body=inl _ ->
    s.refresh
    inb s = s.RegionMem.create'
    cholesky_inverse s A x
    }

s.CudaTensor.print A

Console.writeline "---"
inl AA = s.CudaBlas.gemm .nT .nT one A A
s.CudaTensor.print AA
s.CudaTensor.print (s.CudaBlas.geam .nT .nT one C_inv -one AA)

Console.writeline "***"
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C AA)
    """

let cholesky3 =
    "cholesky3",[cuda_modules],"Does the inverse Cholesky update work in batch mode?",
    """
inb s = CudaModules (1024*1024*16)
inl zero = 0f32
inl one = 1f32

// k=1 is not invertible.
inl k = 64
inl n = 8

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=3f32} {elem_type=float32; dim=k,n}
inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
inl C_inv = s.CudaBlas.matinv_batched_asserted (C.split (inl a,b -> (1,a),b)) .reshape (inl a,b,c -> b,c)
inl A = s.CudaKernel.init {dim=n,n} (inl a b -> if a = b then 1f32 else 0f32)

s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C C_inv)
s.CudaTensor.print x
s.CudaTensor.print C
s.CudaTensor.print C_inv

Console.writeline "---"

inl beta = 0.01f32
inl alpha = one - beta

inl cholesky_inverse s A x =
    //inl range :: _ = x.dim
    //Loops.for {range with body=inl {state i} ->
        //inl x = x .view_span (const {from=i; near_to=i+1})
        inl z = s.CudaBlas.gemm .nT .nT one x A
        inl _ =
            s.CudaKernel.mapi_d1_seq_broadcast' {
                seq={
                    map_in=inl z -> z*z
                    neutral_elem=zero
                    redo=(+)            
                    mapi_out=inl i j _ norm z ->
                        inl c = one / sqrt alpha / norm * (one - one / sqrt (one + beta / alpha * norm))
                        z * sqrt c // In order for square root to work the minus was moved.
                    }
                } z z
        inl zz = s.CudaBlas.gemm .T .nT one z z
        inl zzA = s.CudaBlas.gemm .nT .nT one zz A
        s.CudaBlas.geam' .nT .nT (one / sqrt alpha) A (-one / to float32 x.span_outer) zzA A
        //}

Loops.for {from=0; near_to=200; body=inl _ ->
    s.refresh
    inb s = s.RegionMem.create'
    cholesky_inverse s A x
    }

Console.writeline "---"
inl AA = s.CudaBlas.gemm .nT .nT one A A
s.CudaTensor.print AA
s.CudaTensor.print (s.CudaBlas.geam .nT .nT one C_inv -one AA)

Console.writeline "***"
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C AA)
    """

let cholesky4 =
    "cholesky4",[cuda_modules;cholesky],"Does the inverse Cholesky update from the library work in batch mode?",
    """
inb s = CudaModules (1024*1024*16)
inl zero = 0f32
inl one = 1f32

/// k=1 is not invertible.
/// Also matinv will throw a invalid value expeption for n > 32.
inl k = 8
inl n = 8

inl x = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=3f32} {elem_type=float32; dim=k,n}

inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
inl C_inv = s.CudaBlas.matinv_batched_asserted (C.split (inl a,b -> (1,a),b)) .reshape (inl a,b,c -> b,c)
inl A = s.CudaKernel.init {dim=n,n} (inl a b -> if a = b then 1f32 else 0f32)

s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C C_inv)
s.CudaTensor.print x
s.CudaTensor.print C
s.CudaTensor.print C_inv

Console.writeline "---"

inl beta = 0.01f32
inl alpha = one - beta

inl cholesky_inverse s A x =
    inl z = s.CudaBlas.gemm .nT .T one x A
    Cholesky {alpha beta float=float32} .update_inverse' s A z

Loops.for {from=0; near_to=200; body=inl _ ->
    s.refresh
    inb s = s.RegionMem.create'
    cholesky_inverse s A x
    }

Console.writeline "---"
inl AA = s.CudaBlas.gemm .nT .nT one A A
s.CudaTensor.print AA
s.CudaTensor.print (s.CudaBlas.geam .nT .nT one C_inv -one AA)

Console.writeline "***"
s.CudaTensor.print (s.CudaBlas.gemm .nT .nT one C AA)
    """

let cholesky5 =
    "cholesky5",[cuda_modules;cholesky;mnist],"Does the inverse Cholesky update from the library work in batch mode on Mnist?",
    """
inb s = CudaModules (1024*1024*1024)
inl zero = 0f32
inl one = 1f32

inl m = 5
inl k = (28/m)*(28/m)
inl n = k

inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> inl { x with test_images train_images } ->
        inl f t =
            inl t = t .reshape (inl a,_ -> a,28,28)
            inl batch,x,y = t .dim
            HostTensor.init (batch, HostTensor.span x / m, HostTensor.span y / m) (inl batch x y -> t batch (x*m) (y*m) .get)
                .reshape (inl a,b,c -> a,b*c)
        {x with test_images=f self; train_images=f self}
    |> s.CudaTensor.from_host_tensors

inl x = train_images .view_span (const k)
//inl r = s.CudaRandom.create {dst=.Normal; stddev=0.0001f32; mean=0f32} {elem_type=float32; dim=k,n}
//inl x = s.CudaBlas.geam .nT .nT one r one x

inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
//inl C_inv = s.CudaBlas.matinv_batched_asserted (C.split (inl a,b -> (1,a),b)) .reshape (inl a,b,c -> b,c)
inl A = s.CudaKernel.init {dim=n,n} (inl a b -> if a = b then 1f32 else 0f32)

inl v x = x
s.CudaTensor.print (v x)
s.CudaTensor.print (v C)

Console.writeline "---"

inl beta = 0.001f32
inl alpha = one - beta

inl cholesky_inverse' s A x =
    inl range :: _ = x.dim
    Loops.for {range with body=inl {state i} ->
        inl z = s.CudaBlas.gemm .nT .nT one x A
        inl z = z .view_span (const {from=i; near_to=i+1})
        inl zz = s.CudaBlas.gemm .T .nT one z z
        inl zzA = s.CudaBlas.gemm .nT .nT one zz A
        inl norm =
            s.CudaKernel.mapi_d1_redo_map {
                map_in=inl x _ -> x*x
                neutral_elem=zero
                redo=(+)
                } z ()
        inl norm = s.CudaTensor.get (norm 0)
        inl c = -one / sqrt alpha / norm * (one - one / sqrt (one + beta / alpha * norm))
        s.CudaBlas.geam' .nT .nT (one / sqrt alpha) A c zzA A
        }

inl cholesky_inverse s A x =
    inl range :: _ = x.dim
    Loops.for {range with body=inl {state i} ->
        inl z = s.CudaBlas.gemm .nT .T one x A
        inl z = z .view_span (const {from=i; near_to=i+1})
        Cholesky {alpha beta float=float32} .update_inverse' s A z
        }

inl cholesky_inverse_r s A x =
    inl z = s.CudaBlas.gemm .nT .T one x A
    Cholesky {alpha beta float=float32} .update_inverse' s A z

Loops.for {from=0; near_to=1000; body=inl _ ->
    s.refresh
    inb s = s.RegionMem.create'
    cholesky_inverse_r s A x
    }

//s.CudaTensor.print (v C_inv)
Console.writeline "///"
inl AA = s.CudaBlas.gemm .nT .nT one A A
s.CudaTensor.print (v AA)

Console.writeline "***"
s.CudaTensor.print A
    """

let cholesky6 =
    "cholesky6",[cuda_modules;cholesky;mnist],"Does the inverse Cholesky update from the library work in batch mode on Mnist with random projections?",
    """
inb s = CudaModules (1024*1024*1024)
inl zero = 0f32
inl one = 1f32

inl k = 96
inl n = 8

inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors

inl x = train_images .view_span (const k)

inl P = s.CudaRandom.create {dst=.Normal; stddev=0.1f32; mean=0f32} {elem_type=float32; dim=28*28,n}
inl x = s.CudaBlas.gemm .nT .nT one x P

inl C = s.CudaBlas.gemm .T .nT (one / to float32 k) x x
inl C_inv = s.CudaBlas.matinv_batched_asserted (C.split (inl a,b -> (1,a),b)) .reshape (inl a,b,c -> b,c)
inl A = s.CudaKernel.init {dim=n,n} (inl a b -> if a = b then 1f32 else 0f32)

inl v x = x
s.CudaTensor.print (v x)
s.CudaTensor.print (v C)

Console.writeline "---"

inl beta = 0.001f32
inl alpha = one - beta

inl cholesky_inverse s by A x =
    inl {range with near_to} :: _ = x.dim
    inl z = s.CudaBlas.gemm .nT .T one x A
    Loops.for {range with by body=inl {state i} ->
        if i + by <= near_to then
            inl z = z .view_span (const {from=i; near_to=i+by})
            Cholesky {alpha beta float=float32} .update_inverse' s A z
        }

inl cholesky_inverse_r s A x =
    inl z = s.CudaBlas.gemm .nT .T one x A
    Cholesky {alpha beta float=float32} .update_inverse' s A z

inl by = 4
Loops.for {from=0; near_to=1000; body=inl _ ->
    s.refresh
    inb s = s.RegionMem.create'
    cholesky_inverse s by A x
    }

s.CudaTensor.print (v C_inv)
Console.writeline "///"
inl AA = s.CudaBlas.gemm .nT .nT one A A
s.CudaTensor.print (v AA)

Console.writeline "***"
s.CudaTensor.print A
inl A_diff = s.CudaBlas.geam .nT .T one A -one A
s.CudaTensor.print A_diff
inl max_abs_diff = s.CudaKernel.map_redo_map {map_in=abs; redo=max; neutral_elem=-infinityf32} A_diff
Console.printfn "The absolute maximum of A_diff is {0} with step size {1}" (s.CudaTensor.get max_abs_diff, by)
    """

let learning1 =
    "learning1",[cuda_modules;learning],"Does the matmult work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8}
inl a2 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=8,2} |> dr s
inl o1,bck = matmult (a1, a2) s
bck()

primal o1 |> s.CudaTensor.print
    """

let learning2 =
    "learning2",[cuda_modules;learning],"Does the map work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8} |> dr s
inl o1,bck = map {fwd=((*) 10f32); bck=inl (in,out) adjoint -> out.adjoint * 10f32} a1 s
bck()
primal o1 |> s.CudaTensor.print
    """

let learning3 =
    "learning3",[cuda_modules;learning],"Does the map_redo_map work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=float; dim=256,256} |> dr s
inl l = primal a1 .span_outer |> to float
/// map_redo_map assumes an adjoint of 1. No need to set to that value directly.
inl o1,bck = map_redo_map {fwd={neutral_elem=0f32; redo=(+); map_out=inl x -> x/l}; bck=inl _ -> l} a1 s
s.CudaTensor.print o1
    """

let learning4 =
    "learning4",[cuda_modules;learning],"Does the map_redo's backwards pass work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float
open Primitive

inl a1 = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=1f32} {elem_type=float; dim=6,6} |> dr s
inl l = primal a1 .span_outer |> to float
/// map_redo_map assumes an adjoint of 1. No need to set to that value directly.
inl o1,bck = map_redo_map {fwd={neutral_elem=0f32; redo=(+); map_out=inl x -> x/l}; bck=inl _ _ -> l} a1 s
bck()
adjoint a1 |> s.CudaTensor.print
    """

let learning5 =
    "learning5",[cuda_modules;learning],"Does the basic pass work?",
    """
inb s = CudaModules (1024*1024)

inl float = float32
open Learning float
open Primitive
open Activation
open Error

inl input = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,6}
inl weight = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=6,4} |> dr s
inl label = s.CudaTensor.zero {elem_type=float; dim=2,4}
inl f = matmult (input, weight) >>= sigmoid >>= square label
inl cost,bck = f s

Console.printfn "Cost is: {0}" (s.CudaTensor.get cost)

bck()
adjoint weight |> s.CudaTensor.print
    """

let learning9 =
    "learning9",[cuda_modules;learning;mnist],"Does the full training work with Mnist?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl minibatch_size = 128
inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors
    |> module_map (inl _ x -> x.round_split' minibatch_size)

inl input_size = 784
inl hidden_size = 10

inl network =
    open Feedforward.Layer

    inl label = input .label hidden_size
    inl network =
        input .input input_size
        |> prong' 0.001f32 256
        |> linear hidden_size
        |> init s
    inl train = error Error.softmax_cross_entropy label network
    inl test = parallel (train, accuracy label network)
    {train test}

Loops.for' {from=0; near_to=10;body=inl {next} -> 
    open Feedforward.Pass
    open Body

    inl cost =
        for {
            data={input=train_images; label=train_labels}
            body=train {
                network=network.train
                optimizer=Optimizer.sgd 0.005f32
                }
            } s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        inl cost, ac, max_ac =
            for {
                data={input=test_images; label=test_labels}
                body=test { network=network.test }
                } s 

        string_format "Testing: {0}({1}/{2})" (cost, ac, max_ac) |> Console.writeline
        next ()
    }
    """

let learning10 =
    "learning10",[cuda_modules;timer;learning],"Does the full training work with the char-RNN?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float
open Primitive
open Activation
open Error

inl size = {
    seq = 1115394
    minibatch = 64
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
    |> inl data -> data.round_split size.minibatch

inl minibatch,seq = data.dim

inl input =
    inl data = CudaAux.to_dev_tensor data 
    s.CudaKernel
        .init {rev_thread_limit=32; dim=seq,minibatch,size.hot} (inl seq minibatch ->
            inl x = data minibatch seq .get
            inl hot -> if x = to uint8 hot then 1f32 else 0f32
            )

inl label = input.view_span (const {from=1}) .round_split' size.step 
inl input = input.view_span (inl x :: _ -> x-1) .round_split' size.step 
inl data = {input label}

inl network = 
    open Recurrent.Layer
    
    inl label = input .label size.hot
    inl input = input .input size.hot

    inl train =
        input
        |> miln 0.05f32 128
        //|> mi 128
        |> Feedforward.Layer.linear size.hot
        |> error Error.softmax_cross_entropy label
        |> init_parallel s
    
    {train}

Loops.for' {from=0; near_to=5; body=inl {next i} -> 
    open Recurrent.Pass
    open Body

    inl cost =
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            for {
                data
                body=train {
                    network=network.train
                    optimizer=Optimizer.sgd 0.01f32
                    }
                } s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        next ()
    }
    """

let learning11 =
    "learning11",[cuda_modules;timer;learning],"Does the full training + sampling work with the char-RNN?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl size = {
    seq = 1115394
    minibatch = 64
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
    |> inl data -> data.round_split size.minibatch

inl minibatch,seq = data.dim

inl input =
    inl data = CudaAux.to_dev_tensor data 
    s.CudaKernel
        .init {dim=seq,minibatch} (inl seq minibatch ->
            data minibatch seq .get
            )
        
inl label = input.view_span (const {from=1}) .round_split' size.step
inl input = input.view_span (inl x :: _ -> x-1) .round_split' size.step
inl data = {input label}

inl network = 
    open Recurrent.Layer
    
    inl label = input .label 1 |> encode.one_hot size.hot
    inl input = input .input 1 |> encode.one_hot size.hot

    inl body =
        input
        |> miln 0.05f32 128
        |> Feedforward.Layer.linear size.hot
        |> init_parallel s

    inl train = 
        error Error.softmax_cross_entropy label body
        |> init_parallel s
    
    {train body}

inb _ = Timer.time_it "whole loop"
Loops.for' {from=0; near_to=5; body=inl {next i} -> 
    open Recurrent.Pass
    open Body

    inl cost = 
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            for {
                data
                body=train {
                    network=network.train
                    optimizer=Optimizer.sgd 0.01f32
                    }
                } s

    Console.writeline "----"

    sample 0.6f32 2048 network.body '\n' s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        next ()
    }
    """

let tests =
    [|
    allocator1
    tensor1;tensor2;tensor3
    kernel1;kernel2;kernel3;kernel4;kernel5;kernel6;kernel7;kernel8;kernel9
    kernel10;kernel11;kernel12;kernel13;kernel14;kernel15;kernel16;kernel17
    cholesky1
    random1
    blas1;blas2;blas3;blas4;blas5;blas6;blas7
    learning1;learning2;learning3;learning4;learning5;                               learning9
    learning10;learning11
    |]

//rewrite_test_cache tests cfg None //(Some(0,40))

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) cholesky6
|> printfn "%s"
|> ignore

