open Spiral.Lib
open Spiral.Tests
open System.IO

let learning =
    "Learning",[option;cuda;extern_;option;console],"The deep learning module.",
    """
open Extern
openb Cuda
open Console

inl smartptr_create ptr =
    inl ptr_ty = type (ptr)
    open Option
    inl cell = some ptr |> ref
    function
    | .Dispose -> cell := none ptr_ty
    | .Try -> cell()
    | () -> join (
        match cell() with
        | [Some: x] -> x
        | _ -> failwith ptr_ty "A Cuda memory cell that has been disposed has been tried to be accessed."
        )
    |> stack // Unless this closure is converted to a layout type, the CUdeviceptr gets manifested as a runtime type and gives a type error.

///// n is the number of args the create function has.
inl safe_alloc n create =
    if lit_is n = false then error_type "n need to be static."
    inl rec loop vars = function
        | 0 ret ->
            inl tns = Tuple.foldr (inl x create -> create x) vars create
            inl r = ret tns
            HostTensor.map_tensor (inl x -> x.ptr.Dispose) tns |> ignore
            r
        | n x -> loop (x :: vars) (n-1)
    function
    | .unsafe -> create
    | x -> loop () n x

inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
inl SizeT = FS.Constructor SizeT_type
inl CUdeviceptr = FS.Constructor CUdeviceptr_type

inl allocator size ret =
    inl to_float x = FS.UnOp .float x float64
    inl to_int x = FS.UnOp .int64 x int64
    inl to_uint x = FS.UnOp .uint64 x uint64
    
    inl pool = 
        inl size = 
            match size with
            | _ : float64 -> 
                inl CudaDeviceProperties_type = fs [text: "ManagedCuda.CudaDeviceProperties"]
                FS.Method context.GetDeviceInfo() CudaDeviceProperties_type
                |> inl x -> FS.Method x.get_TotalGlobalMemory() SizeT_type
                |> to_int |> to_float |> (*) size |> to_int
            | _ : int64 -> size
        inl q = FS.Method context.AllocateMemory (SizeT size) CUdeviceptr_type
        {size ptr=q |> smartptr_create}

    inl pool_type = type(pool)
    inl stack_type = fs [text: "System.Collections.Generic.Stack"; types: pool_type]
    inl stack = FS.Constructor stack_type ()

    inl allocate =
        inl smartptr_ty = type (pool.ptr)
        inl f x = FS.Field (x.ptr()) .Pointer SizeT_type |> to_uint, x.size |> to_uint
        inl pool_ptr, pool_size = f pool
        met rec remove_disposed_and_return_the_first_live ret =
            if FS.Method stack.get_Count() int32 > 0i32 then 
                inl t = FS.Method stack.Peek() pool_type
                match t.ptr.Try with
                | [Some: ptr] -> join (ret (FS.Field ptr.Pointer SizeT_type |> to_uint, t.size |> to_uint))
                | _ -> FS.Method stack.Pop() pool_type |> ignore; remove_disposed_and_return_the_first_live ret 
            else join (ret (pool_ptr, 0u64))
            : smartptr_ty
        inl (!dyn size) ->
            inb top_ptr, top_size = remove_disposed_and_return_the_first_live
            inl pool_used = top_ptr - pool_ptr + top_size
            assert (to_uint size + pool_used <= pool_size) "Cache size has been exceeded in the allocator."
            inl cell = {size ptr=top_ptr + top_size |> SizeT |> CUdeviceptr |> smartptr_create}
            FS.Method stack.Push cell unit
            cell.ptr

    ret {allocate}
    inl ptr = pool.ptr
    FS.Method context .FreeMemory (ptr()) unit
    ptr.Dispose

inl CudaTensor allocator =
    open HostTensor
    inl create_ar size1d elem_type = 
        inl ptr = allocator.allocate (size1d * unsafe_convert int64 (sizeof elem_type))
        function // It needs to be like this rather than a module so toa_map does not split it.
        | .elem_type -> elem_type
        | .ptr -> ptr
    inl create {layout elem_type size} = map_tensor (create_ar (total_size size)) {layout size ar=type (elem_type)}

    inl from_host_array ar =
        inl elem_type = ar.elem_type
        inl size = Array.length ar |> unsafe_convert int64
        inl t = create_ar size elem_type
        FS.Method context .CopyToDevice(t.ptr(), ar) unit
        t

    inl from_host_tensor = map_tensor from_host_array

    inl to_host_array size1d ar =
        inl elem_type = ar.elem_type
        inl ptr = ar.ptr()
        inl t = Array.create elem_type size1d
        FS.Method context .CopyToHost (t,ptr) unit
        FS.Method context .Synchronize() unit
        t

    inl to_host_tensor {size} & tns = map_tensor (to_host_array (total_size size)) tns
    inl ptr ar = 
        inl ptr, elem_type = ar.ptr(), ar.elem_type
        !UnsafeCoerceToArrayCudaGlobal(ptr,elem_type)
    inl to_device_tensor_form = map_tensor ptr

    inl zip = function
        | x :: xs as l ->
            inl {size=sa layout=la} = x
            Tuple.iter (inl {size=sb layout=lb} -> 
                assert (sa=sb) "The sizes of all the tensors in zip must be the same in order to be zipped"
                assert (eq_type la lb) "The layouts of all the tensors must have the same format."
                )
            match la with
            | .aot -> error_type "Array of tuples tensor layout is currently not supported."
            | .toa -> {size=sa layout=la ar = Tuple.map (inl {ar} -> ar) l}
        | () -> error_type "Empty input to zip is invalid."
        | x -> x
        
    inl coerce_to_1d {size layout ar} = {layout ar size={from=0; to=total_size size - 1} :: ()}

    // CPS'd variants of the allcoator functions.
    inl create = safe_alloc 1 create
    inl from_host_tensor = safe_alloc 1 from_host_tensor

    {create from_host_tensor to_host_tensor zip elem_type coerce_to_1d to_device_tensor_form total_size ptr}

inb allocator = allocator 0.7
open CudaTensor allocator

inl enum ty x = FS.StaticField ty x ty

use random = 
    inl generator_type = fs [text: "ManagedCuda.CudaRand.GeneratorType"]
    FS.Constructor (fs [text: "ManagedCuda.CudaRand.CudaRandDevice"]) (FS.StaticField generator_type .PseudoDefault generator_type)

use cublas =
    inl cublas_type = fs [text: "ManagedCuda.CudaBlas.CudaBlas"]
    inl pointer_mode_type = fs [text: "ManagedCuda.CudaBlas.PointerMode"]
    inl atomics_mode_type = fs [text: "ManagedCuda.CudaBlas.AtomicsMode"]
    FS.Constructor cublas_type (enum pointer_mode_type .Host, enum atomics_mode_type .Allowed)

inl operation_type = fs [text: "ManagedCuda.CudaBlas.Operation"]
inl to_operation = function
    | .T -> enum operation_type .Transpose
    | .nT -> enum operation_type .NonTranspose

inl isT = function
    | .T -> true
    | _ -> false

inl isnT = function
    | .nT -> true
    | _ -> false

inl CudaKernels stream =
    open HostTensor

    inl set_stream_random x = FS.Method x .SetStream (Stream.extract stream) unit
    inl set_stream_cublas x = FS.Method x .set_Stream (Stream.extract stream) unit

    inl fill_random_array op size1d ar =
        inl elem_type = ar.elem_type
        inl gen, dot = "Generate", "."
        match op with
        | .Uniform & .(distribution) ->
            inl args = ar, size1d
            inl bits = 
                match elem_type with
                | _ : float32 -> "32" | _ : float64 -> "64"
                | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
            !MacroFs(unit,[arg: random; text: dot; text: gen; text: distribution; text: bits; args: args])
        | {op=(.Normal | .LogNormal) & .(distribution) stddev mean} ->
            match stddev with | _: float32 -> () | _ -> error_type "Standard deviation needs to be in float32."
            match mean with | _: float32 -> () | _ -> error_type "Mean needs to be in float32."

            inl args = ar, size1d, mean, stddev
            inl bits = 
                match elem_type with
                | _ : float32 -> "32" | _ : float64 -> "64"
                | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
            !MacroFs(unit,[arg: random; text: dot; text: gen; text: distribution; text: bits; args: args])
        | .UInt ->
            inl args = ar, size1d
            inl bits =
                match elem_type with
                | _ : uint32 -> "32" | _ : uint64 -> "64"
                | _ -> error_type "Only 32/64 bit uint types are supported."
            !MacroFs(unit,[arg: random; text: dot; text: gen; text: bits; args: args])

    inl fill_random op (!zip in) =
        set_stream_random random
        inl in' = coerce_to_1d in |> to_device_tensor_form
        map_tensor (fill_random_array op (total_size (in'.size) |> SizeT)) in' |> ignore

    inl map f (!zip ({size layout} & in)) ret =
        inb out = create {size layout elem_type = type (f (elem_type in))}

        inl in' = coerce_to_1d in |> to_device_tensor_form
        inl out' = coerce_to_1d out |> to_device_tensor_form
        inl near_to = total_size (in'.size)

        run {
            stream
            blockDim = 128
            gridDim = 32
            kernel = cuda // Lexical scoping rocks.
                inl from = blockIdx.x * blockDim.x + threadIdx.x
                inl by = gridDim.x * blockDim.x
                Loops.for {from near_to by body=inl {i} ->
                    set_unsafe out' i (f (index_unsafe in' i))
                    }
            } |> ignore

        ret out

    inl map_redo {map redo} (!zip ({size layout} & in)) ret =
        inl in' = coerce_to_1d in |> to_device_tensor_form
        inl near_to = total_size (in'.size)

        assert (near_to > 0) "The input to map_redo must be non-empty."

        inl final_reduce map out =
            inl _ ->
                inl tns = to_host_tensor out
                Loops.for {from=1; near_to=total_size (tns.size); state=index_unsafe tns 0 |> map; body=inl {state i} -> redo state (index_unsafe tns i |> map)}
            |> ret

        if near_to >= 128 then
            inl blockDim = 128
            inl gridDim = near_to / blockDim
            inl elem_type = type (map (elem_type in))

            inl cub_block_reduce thread_result redo =
                !MacroCuda(elem_type,[
                    text: "cub::BlockReduce"
                    iter: "<",",",">",[type: elem_type; arg: blockDim]
                    args: ()
                    text: ".Reduce"
                    args: thread_result, redo])

            inb out = create {size=gridDim; layout elem_type}
            inl out' = to_device_tensor_form out

            run {
                stream
                blockDim
                gridDim
                kernel = cuda 
                    inl from = blockIdx.x * blockDim.x + threadIdx.x
                    inl by = gridDim.x * blockDim.x
                    inl load i = map (index_unsafe in' i)
                    inl thread_result = Loops.for {from=from+by; near_to by state=load from; body=inl {state i} -> redo state (load i)}

                    inl redo = closure_of (inl a,b -> redo a b) ((t,t) => t)
                    inl block_result = cub_block_reduce thread_result redo
                    if threadIdx.x = 0 then set_unsafe out' (blockIdx.x) block_result
                } |> ignore

            final_reduce id out
        else
            final_reduce map in


    inl rows x = x.size |> inl a,b -> a
    inl cols x = x.size |> inl a,b -> b

    /// General matrix-matrix multiply from cuBLAS. Inplace version
    inl gemm' transa transb alpha (!to_device_tensor_form A) (!to_device_tensor_form B) beta (!to_device_tensor_form C) =
        set_stream_cublas cublas
        inl handle = FS.Method cublas .get_CublasHandle() (fs [text: "ManagedCuda.CudaBlas.CudaBlasHandle"])
        inl native_type = fs [text: "ManagedCuda.CudaBlas.CudaBlasNativeMethods"]
        inl assert_ok status = !MacroFs(unit,[text: "if "; arg: status; text: " <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException"; args: status])
        inl call m x = 
            inl x = Tuple.map (function x : int64 -> unsafe_convert int32 x | x -> x) x
            inl status_type = fs [text: "ManagedCuda.CudaBlas.CublasStatus"]
            FS.StaticMethod native_type m x status_type |> assert_ok
        
        // -------

        // These two are meant to be called from inside gemm as they lack boundary checks.
        // I've added them to enhance gemm's vector handling capabilities for online learning
        // tasks.

        /// o <- alpha * op(A) * x + beta * o
        /// Matrix-vector multiplication. Inplace version.
        inl gemv transa alpha A x beta o =
            inl m,n = A.size
            inl lda = m
            call.cublasSgemv_v2(handle, to_operation transa, m, n, ref alpha, A.ar, lda, x.ar, 1, ref beta, o.ar, 1)

        // A <- alpha * x * yT + beta * A (outer product)
        inl ger alpha x y beta a =
            inl max (a,b) = max a b
            inl m = max (x.size)
            inl n = max (y.size)

            match beta with
            | 1.0f64 | 1.0f32 -> ()
            | _ -> FS.Method context .ClearMemoryAsync (a.ar,0u8,total_size (a.size) * sizeof (a.ar.elem_type) |> SizeT,Stream.extract stream) unit

            call.cublasSger_v2(handle, m, n, ref alpha, x.ar, 1, y.ar, 1, a.ar, m)

        // -------

        inl is_vector x = rows x = 1 || cols x = 1

        inl a_col = if isnT transa then cols A else rows A
        inl b_row = if isnT transb then rows B else cols B
        assert (a_col = b_row) "Colums of a does not match rows of b in GEMM."

        inl m = if isnT transa then rows A else cols A
        inl n = if isnT transb then cols B else rows B
        inl k = a_col
        inl lda = if isnT transa then m else k
        inl ldb = if isnT transb then k else n
        inl ldc = m

        assert (m = rows C && n = cols C) "Output matrix dimensions do not match in GEMM."

        // If is outer product call ger
        if a_col = 1 && b_row = 1 then ger alpha A B beta C
        // If the vector is on the right side or both are vectors call gemv normally.
        elif is_vector B then gemv transa alpha A B beta C
        // If the vector is on the left side call gemv with the arguments switched and transposed
        // It does not actually transpose them, just their views. The function should work regardless.
        elif is_vector A then
            inl optb = if isnT transb then .T else .nT
            gemv optb alpha B A beta C
        // Just do the standard matrix multiply
        else
            call.cublasSgemm_v2(handle,to_operation transa, to_operation transb, m, n, k, ref alpha, A.ar, lda, B.ar, ldb, ref beta, C.ar, ldc)

    inl gemm transa transb alpha ({layout} & A) B ret =
        inl A_ty, B_ty = type(A), type(B)
        assert (eq_type A_ty B_ty) ("A should be of equal type to B.", A_ty, " <> ", B_ty)

        inl m = if isnT transa then rows A else cols A
        inl n = if isnT transb then cols B else rows B

        inb C = create {size=m,n; layout elem_type = type (elem_type A)}
        inl beta = match alpha with _: float32 -> 0f32 | _: float64 -> 0f64
        gemm' transa transb alpha A B beta C
        ret C

    {map map_redo gemm fill_random}

inl (>>=) a b ret = a <| inl a -> b a ret
inl succ a ret = ret a

open CudaKernels (Stream.create())
open Console

inl test_random = 
    //inl host_tensor = HostTensor.init 32 (unsafe_convert float32)
    inm device_tensor = create {layout= .toa; size=32; elem_type=float32}
    fill_random {op=.LogNormal; stddev=1.0f32; mean=0f32} device_tensor
    inl {ar} = to_host_tensor device_tensor
    succ (Array.show_array ar |> writeline)

inl test_map = 
    inl host_tensor = HostTensor.init 32 (unsafe_convert float32)
    inm {ar} = from_host_tensor host_tensor >>= map ((*) (dyn 2f32)) >>= (to_host_tensor >> succ)
    succ (Array.show_array ar |> writeline)

inl test_map_redo =
    inl force x ret = ret (x ())
    // In this example the only thing that happens after the merge is the writeline, but it would be useful if there
    // is more stuff after it. The merge would be an effective tool for keeping the code bloat down in that case.
    inl merge x ret = join (ret x) 
    inl host_tensor = HostTensor.init (dyn 64) (unsafe_convert float32)
    from_host_tensor host_tensor >>= map_redo {map=id; redo=(+)} >>= force >>= merge >>= (writeline >> succ)

inl test_gemm =
    inl create' size =
        inm device_tensor = create {layout= .toa; size elem_type=float32}
        fill_random {op=.LogNormal; stddev=1.0f32; mean=0f32} device_tensor
        succ device_tensor
    inm a = create' (4,2)
    inm b = create' (2,4)
    gemm .nT .nT 1.0f32 a b >>= (to_host_tensor >> HostTensor.show_tensor >> writeline >> succ)
    

inl learning_tests =
    test_random, test_map, test_map_redo, test_gemm

test_gemm id
    """

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = @"C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.0"
    path_cub = @"C:\cub-1.7.4"
    path_vs2017 = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community"
    cuda_includes = []
    }

//rewrite_test_cache cfg None //(Some(80,tests.Length))

output_test_to_temp {cfg with cuda_includes=["cub/cub.cuh"]} @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning
|> printfn "%s"
|> ignore

