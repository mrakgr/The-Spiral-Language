module Learning.Main

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types

let allocator = 
    (
    "Allocator",[option;extern_],"The stack based GPU memory allocator module.",
    """
inl {Cuda size} ret ->
    open Cuda
    open Extern
    inl smartptr_create ptr =
        inl ptr_ty = {value = type ptr} |> stack // Seals the type in a layout type so it does not get instantiated.
        inl cell = Option.some ptr |> ref
        function
        | .Dispose -> cell := Option.none ptr_ty.value
        | .Try -> cell()
        | () -> join (
            match cell() with
            | .Some, x -> x
            | _ -> failwith ptr_ty.value "A Cuda memory cell that has been disposed has been tried to be accessed."
            )

    ///// n is the number of args the create function has.
    inl safe_alloc n create =
        if lit_is n = false then error_type "n need to be static."
        inl rec loop vars = function
            | 0 ret ->
                inl tns = Tuple.foldr (inl x create -> create x) vars create
                inl r = ret tns
                tns.update_body (inl {ar} -> ar.ptr.Dispose) |> ignore
                r
            | n x -> loop (x :: vars) (n-1)
        function
        | .unsafe -> create
        | x -> loop () n x

    inl to_float x = FS.UnOp .float x float64
    inl to_int x = FS.UnOp .int64 x int64
    
    inl pool = 
        inl size = 
            match size with
            | _ : float64 -> 
                inl CudaDeviceProperties_type = fs [text: "ManagedCuda.CudaDeviceProperties"]
                FS.Method context .GetDeviceInfo() CudaDeviceProperties_type
                |> inl x -> FS.Method x .get_TotalGlobalMemory() SizeT_type
                |> to_int |> to_float |> (*) size |> to_int
            | _ : int64 -> size
        inl q = FS.Method context .AllocateMemory (SizeT size) CUdeviceptr_type
        {size ptr=smartptr_create q}

    inl pool_type = type pool
    inl stack_type = fs [text: "System.Collections.Generic.Stack"; types: pool_type]
    inl stack = FS.Constructor stack_type ()

    inl allocate =
        inl smartptr_ty = type (pool.ptr)
        inl f x = x.ptr() |> ptr_to_uint, x.size |> to_uint
        inl pool_ptr, pool_size = f pool
        met rec remove_disposed_and_return_the_first_live ret =
            if FS.Method stack .get_Count() int32 > 0i32 then 
                inl t = FS.Method stack .Peek() pool_type
                match t.ptr.Try with
                | .Some, ptr -> join (ret (ptr_to_uint ptr, t.size |> to_uint))
                | _ -> FS.Method stack .Pop() pool_type |> ignore; remove_disposed_and_return_the_first_live ret 
            else join (ret (pool_ptr, 0u64))
            : smartptr_ty
        inl (!dyn size) ->
            inb top_ptr, top_size = remove_disposed_and_return_the_first_live
            inl pool_used = top_ptr - pool_ptr + top_size
            assert (to_uint size + pool_used <= pool_size) "Cache size has been exceeded in the allocator."
            inl cell = {size ptr=top_ptr + top_size |> uint_to_ptr |> smartptr_create}
            FS.Method stack .Push cell unit
            cell.ptr

    ret {allocate ptr_to_uint uint_to_ptr safe_alloc}

    inl ptr = pool.ptr
    FS.Method context .FreeMemory (ptr()) unit
    ptr.Dispose
    """) |> module_

let cuda_tensor = 
    (
    "CudaTensor",[option;extern_;host_tensor],"The Cuda tensor module.",
    """
inl {stream Cuda Allocator} ->
    open Cuda
    open Allocator
    open HostTensor
    open Extern
    inl cuda_array_create elem_type len = 
        inl ptr = allocate (len * unsafe_convert int64 (sizeof elem_type))
        function // It needs to be like this rather than a module so toa_map does not split it.
        | .elem_type -> elem_type
        | .ptr -> ptr
    inl create data = create {data with array_create = cuda_array_create}
    inl create_like tns = create {elem_type=tns.elem_type; dim=tns.dim}

    inl from_host_array ar =
        inl elem_type = ar.elem_type
        inl size = array_length ar |> unsafe_convert int64
        inl t = cuda_array_create elem_type size
        FS.Method context .CopyToDevice(t.ptr(), ar) unit
        t

    inl to_host_array size1d ar =
        inl elem_type = ar.elem_type
        inl ptr = ar.ptr()
        inl t = array_create elem_type size1d
        FS.Method context .CopyToHost (t,ptr) unit
        FS.Method context .Synchronize() unit
        t

    inl transfer_template f tns = 
        assert_contiguous tns
        tns.update_body <| inl {body with offset=o::_ ar} ->
            // I do not feel like messing with GC handles in Spiral right now.
            // Allowing a copy with an offset would be easy though. See ManagedCuda's CopyToHost and CopyToDevice.
            assert (o = 0) "Only unviewed arrays are allowed for now."
            {body with ar = f ar}

    inl from_host_tensor = transfer_template from_host_array
    inl to_host_tensor tns = transfer_template (to_host_array (length tns)) tns

    inl to_dev_tensor tns = 
        tns.update_body (inl {body with ar offset} ->
            inl ptr, elem_type = ar.ptr(), ar.elem_type
            inl o = match offset with o :: _ | o -> o
            inl ptr = ptr_to_uint ptr + unsafe_convert uint64 o |> uint_to_ptr    
            inl ar = !UnsafeCoerceToArrayCudaGlobal(ptr,elem_type)
            inl offset = match offset with _ :: o' -> 0 :: o' | offset -> 0
            {body with ar offset}
            )

    inl clear (!to_dev_tensor tns) = 
        assert_contiguous tns
        inl size = length tns
        inl stream = Stream.extract stream
        tns.update_body <| inl {body with ar} ->
            FS.Method context .ClearMemoryAsync (ar,0u8,size * sizeof (ar.elem_type) |> SizeT,stream) unit
        |> ignore

    inl zero_like = create_like >> inl x -> clear x; x

    inl from_host_tensors x ret = 
        inl tensors = toa_map from_host_tensor x
        inl r = ret tensors
        toa_map (inl x -> x.update_body (inl {ar} -> ar.ptr.Dispose)) |> ignore
        r

    // CPS'd variants of the allocator functions.
    inl create = safe_alloc 1 create
    inl from_host_tensor = safe_alloc 1 from_host_tensor
    inl zero_like = safe_alloc 1 zero_like

    {create from_host_tensor from_host_tensors to_host_tensor to_dev_tensor clear zero_like}
    """) |> module_

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

let cuda_kernel =
    (
    "CudaKernel",[lazy_;host_tensor],"The Cuda kernels module.",
    """
inl {stream Cuda CudaTensor} ->
    open HostTensor
    open Cuda
    open CudaTensor
    open Extern
    inl divup a b = (a-1)/b+1 // Integer division with rounding up. (a+b-1)/b is another variant on this.
    inl map f (!zip in) (!zip out) =
        assert_zip (in, out) |> ignore
        inl in = to_1d in |> to_dev_tensor
        inl out = to_1d out |> to_dev_tensor
        inl near_to = length in

        inl blockDim = 128
        inl gridDim = min 64 (divup near_to blockDim)

        run {
            stream blockDim gridDim
            kernel = cuda // Lexical scoping rocks.
                inl from = blockIdx.x * blockDim.x + threadIdx.x
                inl by = gridDim.x * blockDim.x
                Loops.for {from near_to by body=inl {i} -> out i .set (f (in i .get))}
            } |> ignore

    /// Flattens the tensor to 1d, maps and reduces it.
    /// Lazily returns the output. Requires the redo and the neutral element.
    /// Map is optional. Allocates a temporary tensor for the intermediary results.
	/// Requires the continuation in order for the sake of memory allocation.
    inl map_redo {d with redo neutral_elem} (!zip (!to_1d in)) ret =
        inl in' = to_dev_tensor in
        inl near_to = length in'
        inl map = match d with {map} -> map | _ -> id

        inl blockDim = 128
        inl gridDim = min 64 (divup near_to blockDim)
        inl elem_type = type (in.elem_type |> map)
        inl ty = elem_type

        inl cub_block_reduce thread_result redo =
            macro.cd ty [
                text: "cub::BlockReduce"
                iter: "<",",",">",[type: ty; arg: blockDim]
                args: ()
                text: ".Reduce"
                args: thread_result, redo
                ]

        inb out = create {elem_type dim=gridDim}
        inl out' = to_dev_tensor out

        run {
            stream blockDim gridDim
            kernel = cuda 
                inl from = blockIdx.x * blockDim.x + threadIdx.x
                inl by = gridDim.x * blockDim.x
                inl load i = map (in' i .get)
                inl thread_result = Loops.for {from near_to by state=dyn neutral_elem; body=inl {state i} -> redo state (load i)}

                inl redo = closure_of (inl a,b -> redo a b) ((ty,ty) => ty)
                inl block_result = cub_block_reduce thread_result redo
                if threadIdx.x = 0 then out' (blockIdx.x) .set block_result
            } |> ignore

        inl _ ->
            inl tns = to_host_tensor out
            inl load i = tns i .get
            Loops.for {from=0; near_to=length tns; state=dyn neutral_elem; body=inl {state i} -> redo state (load i)}
        |> Lazy.lazy // The lazy return here is because transfering to host would block the execution.
        |> ret

    {map map_redo}
    """) |> module_

let cuda_random =
    (
    "CudaRandom",[extern_],"The Cuda random module.",
    """
inl ret ->
    open Extern
    use random = 
        inl generator_type = fs [text: "ManagedCuda.CudaRand.GeneratorType"]
        FS.Constructor (fs [text: "ManagedCuda.CudaRand.CudaRandDevice"]) (FS.StaticField generator_type .PseudoDefault generator_type)
    
    ret inl {d with stream Cuda CudaTensor} ->
        open Cuda
        open HostTensor
        open CudaTensor
        FS.Method random .SetStream (Stream.extract stream) unit
    
        inl fill_array distribution size1d ar =
            inl elem_type = ar.elem_type
            inl gen, dot = "Generate", "."
            match distribution with
            | .Uniform ->
                inl args = ar, SizeT size1d
                inl bits = 
                    match elem_type with
                    | _ : float32 -> "32" | _ : float64 -> "64"
                    | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
                macro.fs unit [arg: random; text: dot; text: gen; text: distribution; text: bits; args: args]
            | {dst=(.Normal | .LogNormal) & distribution stddev mean} ->
                match stddev with | _: float32 -> () | _ -> error_type "Standard deviation needs to be in float32."
                match mean with | _: float32 -> () | _ -> error_type "Mean needs to be in float32."

                inl args = ar, SizeT size1d, mean, stddev
                inl bits = 
                    match elem_type with
                    | _ : float32 -> "32" | _ : float64 -> "64"
                    | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
                macro.fs unit [arg: random; text: dot; text: gen; text: distribution; text: bits; args: args]
            | .UInt -> // every bit random
                inl args = ar, SizeT size1d
                inl bits =
                    match elem_type with
                    | _ : uint32 -> "32" | _ : uint64 -> "64"
                    | _ -> error_type "Only 32/64 bit uint types are supported."
                macro.fs unit [arg: random; text: dot; text: gen; text: bits; args: args]

        inl fill op (!zip in) =
            inl in' = to_1d in |> to_dev_tensor
            inl len = length in'
            in'.update_body (inl {ar} -> fill_array op len ar) |> ignore

        inl create_tensor op dsc ret =
            inb device_tensor = create dsc
            fill op device_tensor
            ret device_tensor

        {fill create_tensor}
    """) |> module_

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

