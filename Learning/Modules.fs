module Modules

open Spiral.Types
open Spiral.Lib

let mnist =
    (
    "Mnist",[extern_;host_tensor],"The Mnist loader module.",
    """
open Extern
met load_mnist kind (!dyn filename) =
    inl enum ty x = FS.StaticField ty x ty
    inl File_ty = fs [text: "System.IO.File"]
    inl FileStream_ty = fs [text: "System.IO.FileStream"]
    inl FileMode = enum (fs [text: "System.IO.FileMode"])
    inl FileAccess = enum (fs [text: "System.IO.FileAccess"])
    inl FileShare = enum (fs [text: "System.IO.FileShare"])
    inl BinaryReader_ty = fs [text: "System.IO.BinaryReader"]
    inl IPAddress_ty = fs [text: "System.Net.IPAddress"]

    inl netword_to_host_order x = FS.StaticMethod IPAddress_ty .NetworkToHostOrder x int32

    use f = FS.StaticMethod File_ty .Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read) FileStream_ty
    use d = FS.Constructor BinaryReader_ty f

    inl read_int32 x = FS.Method d .ReadInt32 x int32 |> netword_to_host_order
    inl read_bytes n = FS.Method d .ReadBytes n (array uint8)

    inl to_int64 = unsafe_convert int64
    inl to_ints64 = Tuple.map to_int64

    inl magic_number = read_int32()
    match kind with
    | .label ->
        assert (magic_number = 2049i32) "Expected a 2049i32 magic number."
        inl n = read_int32()
        to_int64 n, read_bytes n
    | .image ->
        assert (magic_number = 2051i32) "Expected a 2051i32 magic number."
        inl n, rows, cols = read_int32(), read_int32(), read_int32()
        to_ints64 (n, rows, cols), read_bytes (n * rows * cols)


inl load_mnist_tensors mnist_path =
    inl mnist_files = {
        test_images = {file = "t10k-images.idx3-ubyte"; image_size = 10000,28,28}
        test_labels = {file = "t10k-labels.idx1-ubyte"; label_size = 10000}
        train_images = {file = "train-images.idx3-ubyte"; image_size = 60000,28,28}
        train_labels = {file = "train-labels.idx1-ubyte"; label_size = 60000}
        }
           
    inl path_type = fs [text: "System.IO.Path"]
    inl combine x = FS.StaticMethod path_type .Combine x string
    
    module_map (inl _ -> function
        | {file image_size} ->
            inl size, ar = load_mnist .image (combine (mnist_path, file))
            assert (image_size = size) "Mnist dimensions do not match the expected values."
            inl images, rows, cols = image_size
            HostTensor.array_as_tensor ar
            |> HostTensor.reshape (images, rows * cols)
            |> HostTensor.map (inl x -> unsafe_convert float32 x / 255f32)
            
        | {file label_size} ->
            inl n, ar = load_mnist .label (combine (mnist_path, file))
            assert (label_size = n) "Mnist dimensions do not match the expected values."
            HostTensor.init (label_size, 10) (inl a ->
                inl x = ar a
                inl b -> if unsafe_convert uint8 b = x then 1.0f32 else 0.0f32
                )
        ) mnist_files

{load_mnist_tensors}
    """) |> module_

let allocator = 
    (
    "Allocator",[option;extern_],"The stack based GPU memory allocator module.",
    """
inl {Cuda size} ret ->
    open Cuda
    open Extern
    inl smartptr_create ptr =
        inl ptr_ty = type ptr
        inl cell = Option.some ptr |> ref
        function
        | .Dispose -> cell := Option.none ptr_ty
        | .Try -> cell()
        | () -> join 
            match cell() with
            | .Some, x -> x
            | _ -> failwith ptr_ty "A Cuda memory cell that has been disposed has been tried to be accessed."
        |> stack

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
            inl ptr = 
                inl x = top_ptr + top_size
                x + x % 128u64 |> uint_to_ptr |> smartptr_create
            inl cell = {size ptr}
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

    /// Is just a CUdeviceptr rather than the true array.
    inl array_create_cuda_global elem_type len = 
        inl ptr = allocate (len * unsafe_convert int64 (sizeof elem_type))
        function // It needs to be like this rather than a module so toa_map does not split it.
        | .elem_type -> elem_type
        | .ptr -> ptr
    inl create data = create {data with array_create = array_create_cuda_global}
    inl create_like tns = create {elem_type=tns.elem_type; dim=tns.dim}

    inl from_host_array ar =
        inl elem_type = ar.elem_type
        inl size = array_length ar |> unsafe_convert int64
        inl t = array_create_cuda_global elem_type size
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
            inl type_size = sizeof ar.elem_type
            inl o, offset = 
                match offset with 
                | _ :: _ -> Tuple.foldl (+) 0 offset * type_size, Tuple.map (const 0) offset
                | o -> o * type_size, 0
            inl ptr, elem_type = ar.ptr(), ar.elem_type
            inl ptr =
                if lit_is o then ptr
                else ptr_to_uint ptr + unsafe_convert uint64 o |> uint_to_ptr    
            inl ar = !UnsafeCoerceToArrayCudaGlobal(ptr,elem_type)
            //inl ptr, elem_type = ar.ptr(), ar.elem_type
            //inl ar = !UnsafeCoerceToArrayCudaGlobal(ptr,elem_type)
            {body with ar offset}
            )

    inl clear (!to_dev_tensor tns) = 
        assert_contiguous tns
        inl size = length tns
        inl stream = Stream.extract stream
        tns.update_body <| inl {body with ar} ->
            FS.Method context .ClearMemoryAsync (ar,0u8,size * sizeof ar.elem_type |> SizeT,stream) unit
        |> ignore

    inl fmap f a ret =
        inb a = a
        ret (f a)

    inl clear' x = clear x; x
    inl zero = create >> clear'
    inl zero_like = create_like >> clear'

    inl from_host_tensors x ret = 
        inl tensors = toa_map from_host_tensor x
        inl r = ret tensors
        toa_map (inl x -> x.update_body (inl {ar} -> ar.ptr.Dispose)) |> ignore
        r

    // CPS'd variants of the allocator functions.
    inl create = safe_alloc 1 create
    inl from_host_tensor = safe_alloc 1 from_host_tensor
    inl zero = safe_alloc 1 zero
    inl zero_like = safe_alloc 1 zero_like

    {create from_host_tensor from_host_tensors to_host_tensor to_dev_tensor clear zero zero_like}
    """) |> module_

let cuda_kernel =
    (
    "CudaKernel",[lazy_;host_tensor],"The Cuda kernels module.",
    """
inl {stream Cuda CudaTensor} ->
    open HostTensor
    open Cuda
    open CudaTensor
    open Extern

    /// These two loops are only here until NVidia gets its shit together and fixes the NVCC tuple write bugs.
    inl whilecd {cond state body} =
        inl r = array_create_cuda_local state 1
        r 0 <- state
        /// Note: While must have a join point around it.
        !While((join cond (r 0)), (r 0 <- body (r 0)))
        r 0

    inl forcd {d with from body} =
        inl finally =
            match d with
            | {finally} -> finally
            | _ -> id

        inl check =
            match d with
            | {near_to} from -> from < near_to 
            | {to} from -> from <= to
            | {down_to} from -> from >= down_to
            | {near_down_to} from -> from > near_down_to
            | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` needs be present."

        inl by =
            match d with
            | {by} -> by
            | {to | near_to} -> 1
            | {down_to | near_down_to} -> -1

        inl to =
            match d with
            | {(to ^ near_to ^ down_to ^ near_down_to)=to} -> to
            | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` is allowed."

        inl state = 
            match d with
            | {state} -> state
            | _ -> ()

        inl state = {from state}
        whilecd {
            state
            cond = inl {from state} -> check from
            body = inl {from state} -> {from=from+by; state=body {state i=from}}
            } .state
        |> finally

    inl divup a b = (a-1)/b+1 // Integer division with rounding up. (a+b-1)/b is another variant on this.
    inl map' f (!zip in) (!zip out) =
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
                forcd {from near_to by body=inl {i} -> 
                    inl out = out i
                    inl in = in i
                    out .set (f in.get out.get)
                    }
            } |> ignore

    inl map f (!zip in) ret =
        inb out = create {dim=in.dim; elem_type=type f in.elem_type}
        map' (inl in _ -> f in) in out
        ret out

    inl cub_block_reduce blockDim redo x =
        macro.cd x [
            text: "cub::BlockReduce"
            iter: "<",",",">",[type: x; arg: blockDim]
            args: ()
            text: ".Reduce"
            args: x, closure_of (inl a,b -> redo a b) ((x,x) => x)
            ]

    /// Flattens the tensor to 1d, maps and reduces it.
    /// Requires the redo and the neutral element.
    /// Map is optional. Allocates a temporary tensor for the intermediary results.
    inl map_redo {d with redo neutral_elem} (!zip (!to_1d (!to_dev_tensor in))) =
        inl near_to = length in
        inl map = match d with {map} -> map | _ -> id

        inl blockDim = 128
        inl gridDim = min 64 (divup near_to blockDim)
        inl elem_type = type (in.elem_type |> map)
        inl ty = elem_type

        inb out = create {elem_type dim=gridDim}
        inl out' = to_dev_tensor out

        run {
            stream blockDim gridDim
            kernel = cuda 
                inl from = blockIdx.x * blockDim.x + threadIdx.x
                inl by = gridDim.x * blockDim.x
                inl body {state i} = redo state (map (in i .get)) 
                inl thread_result = forcd {from near_to by state=dyn neutral_elem; body}
                inl block_result = cub_block_reduce blockDim.x redo thread_result
                if threadIdx.x = 0 then out' blockIdx.x .set block_result
            } |> ignore

        inl tns = to_host_tensor out
        Loops.for {from=0; near_to=length tns; state=dyn neutral_elem; body=inl {state i} -> redo state (tns i .get)}

    inl warp_size = 32

    /// Replicates the 1d `in` and maps it along with the in' and the out.
    inl replicate_map' f (!zip in) (!zip in') (!zip out) =
        inl s = HostTensor.span
        inl dim_in :: () = in.dim
        inl dim_in'_a, dim_in'_b = in'.dim

        assert (dim_in = dim_in'_b) "Input's dimension must equal the second input's inner dimension."
        assert (in'.dim = out.dim) "Second input must have the same dimension as the output."

        inl blockDimX = min warp_size (s dim_in)
        // TODO: Determine if a different multiple would be better.
        inl blockDimY = min 8 (s dim_in'_a)
        inl gridDim = min 64 (divup (s dim_in) blockDimX)

        inl in = to_dev_tensor in
        inl in' = to_dev_tensor in'
        inl out = to_dev_tensor out

        run {
            stream gridDim
            blockDim=blockDimX,blockDimY
            kernel = cuda 
                forcd {from=threadIdx.x+blockDim.x*blockIdx.x-dim_in.from; by=gridDim.x*blockDim.x; near_to=dim_in.near_to; body=inl {i} ->
                        inl in = in i
                        inl in' j = in' j i 
                        inl out j = out j i
                        forcd {
                            from=threadIdx.y+blockDim.y*blockIdx.y-dim_in'_a.from
                            by=gridDim.y*blockDim.y
                            near_to=dim_in'_a.near_to
                            body=inl {i} ->
                                inl in' = in' i
                                inl out = out i
                                out.set (f in.get in'.get out.get)
                            }
                    }
            } |> ignore

    inl replicate_map f (!zip in) in' ret =
        inl in' =
            match in' with
            | by : int64 -> 
                inl dim_in :: () = in.dim
                HostTensor.create {elem_type=(); dim=by,dim_in}
            | in' -> zip in'
        inb out = create {elem_type=type f in.elem_type in'.elem_type; dim=in'.dim}
        replicate_map' (inl a b _ -> f a b) in in' out
        ret out

    inl syncthreads () = macro.cd unit [text: "__syncthreads()"]

    inl lit_min a b =
        if lit_is a && lit_is b then min a b
        elif lit_is a then a
        elif lit_is b then b
        else error_type "a or b need to be a literal"

    /// Maps the two inputs and then reduces the first's inner dimension.
    inl map_d1_redo_map' {d with redo neutral_elem} (!zip in) (!zip in') (!zip out) = 
        inl s = HostTensor.span
        inl dim_in_a, dim_in_b = in.dim
        inl dim_in' :: () = in'.dim

        assert (dim_in' = dim_in_a) "Input's outer dimension must equal the output's dimension."
        assert (in'.dim = out.dim) "Input and output's dimensions must be equal."

        inl blockDim = lit_min 1024 (s dim_in_b)
        inl gridDimY = lit_min 64 (s dim_in')

        inl in = to_dev_tensor in
        inl in' = to_dev_tensor in'
        inl out = to_dev_tensor out
        inl map_in = match d with {map_in} -> map_in | _ -> const
        inl map_out = match d with {map_out} -> map_out | _ -> const
        
        run {
            stream blockDim
            gridDim=1,gridDimY
            kernel = cuda 
                forcd {from=threadIdx.y+blockDim.y*blockIdx.y-dim_in'.from; by=gridDim.y*blockDim.y; near_to=dim_in'.near_to; body=inl {i} ->
                    inl in = in i
                    inl in' = in' i

                    inl result = 
                        forcd {
                            from=threadIdx.x+blockDim.x*blockIdx.x-dim_in_b.from
                            by=gridDim.x*blockDim.x
                            near_to=dim_in_b.near_to
                            state=dyn neutral_elem 
                            body=inl {state i} -> 
                                inl in = in i 
                                inl a = in.get
                                redo state (map_in a in'.get)
                            }
                        |> cub_block_reduce blockDim.x redo

                    if threadIdx.x = 0 then 
                        inl out = out i
                        out.set (map_out result out.get)
                    }
            }

    /// Maps the two inputs and then reduces the first's outer dimension.
    inl map_d2_redo_map' {d with redo neutral_elem} (!zip in) (!zip in') (!zip out) =
        inl s = HostTensor.span
        inl dim_in_a, dim_in_b = in.dim
        inl dim_in' :: () = in'.dim

        assert (dim_in' = dim_in_b) "Input's inner dimension must equal the output's dimension."
        assert (in'.dim = out.dim) "Input and output's dimensions must be equal."

        inl blockDimX = lit_min warp_size (s dim_in')
        // TODO: Determine if a different multiple would be better.
        inl blockDimY = lit_min 8 (s dim_in_a)
        inl gridDim = min 64 (divup (s dim_in') blockDimX)

        inl in = to_dev_tensor in
        inl in' = to_dev_tensor in'
        inl out = to_dev_tensor out
        inl map_in = match d with {map_in} -> map_in | _ -> const
        inl map_out = match d with {map_out} -> map_out | _ -> const

        run {
            stream gridDim
            blockDim=blockDimX,blockDimY
            kernel = cuda 
                forcd {from=threadIdx.x+blockDim.x*blockIdx.x-dim_in'.from; by=gridDim.x*blockDim.x; near_to=dim_in'.near_to; body=inl {i} ->
                        inl in j = in j i
                        inl in' = in' i
                        inl out = out i
                        inl finally result = out.set (map_out result out.get)

                        inl blockResult = forcd {
                            from=threadIdx.y+blockDim.y*blockIdx.y-dim_in_a.from
                            by=gridDim.y*blockDim.y
                            near_to=dim_in_a.near_to 
                            state=dyn neutral_elem 
                            body=inl {state i} -> 
                                inl in = in i 
                                redo state (map_in in.get in'.get) 
                            }
                        
                        if blockDim.y > 1 then
                            inl ar = HostTensor.create {
                                array_create=array_create_cuda_shared
                                elem_type=blockResult
                                // TODO: Determine if padding is needed here for the sake of bank conflict elimination.
                                dim=blockDim.x,{from=1; near_to=blockDim.y}
                                }
                            
                            inl ar = ar threadIdx.x
                            
                            if threadIdx.y <> 0 then ar threadIdx.y .set blockResult
                            syncthreads()

                            if threadIdx.y = 0 then
                                forcd {from=1; near_to=blockDim.y; state=blockResult; 
                                    body=inl {state i} -> redo state (ar i .get)
                                    finally
                                    }
                        else
                            finally blockResult
                    }
            } |> ignore

    inl map_dx_redo_map_template dim kernel d in in' ret =
        inl in' = 
            match in' with
            | () -> HostTensor.create {elem_type=(); dim}
            | in' -> zip in'

        inl map_in = match d with {map_in} -> map_in | _ -> const
        inl map_out, elem_type = 
            inl ty = type map_in in.elem_type in'.elem_type
            match d with {map_out} -> (inl a _ -> map_out a),(type map_out ty) | _ -> const, ty
        inb out = create {elem_type dim=in'.dim}
        kernel {d with map_in map_out} in in' out
        ret out

    inl map_d1_redo_map d (!zip in) = map_dx_redo_map_template (fst in.dim) map_d1_redo_map' d in
    inl map_d2_redo_map d (!zip in) = map_dx_redo_map_template (snd in.dim) map_d2_redo_map' d in

    {map' map map_redo replicate_map' replicate_map map_d1_redo_map' map_d1_redo_map map_d2_redo_map' map_d2_redo_map}
    """) |> module_

let cuda_random =
    (
    "CudaRandom",[extern_],"The CudaRandom module.",
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

let cuda_blas =
    (
    "CudaBlas",[extern_],"The CudaBlas module.",
    """
inl ret ->
    open Extern
    
    inl enum ty x = FS.StaticField ty x ty

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

    inl len = HostTensor.span
    inl rows x = x.dim |> inl a,b -> len a
    inl cols x = x.dim |> inl a,b -> len b

    inl assert_singleton x = 
        match x.bodies with
        | _ :: _ | {!block_toa_map} -> error_type "Expected a singleton tensor."
        | _ -> ()

    use cublas =
        inl cublas_type = fs [text: "ManagedCuda.CudaBlas.CudaBlas"]
        inl pointer_mode_type = fs [text: "ManagedCuda.CudaBlas.PointerMode"]
        inl atomics_mode_type = fs [text: "ManagedCuda.CudaBlas.AtomicsMode"]
        FS.Constructor cublas_type (enum pointer_mode_type .Host, enum atomics_mode_type .Allowed)

    inl handle = FS.Method cublas .get_CublasHandle() (fs [text: "ManagedCuda.CudaBlas.CudaBlasHandle"])

    ret inl {d with stream Cuda CudaKernel CudaTensor} ->
        open Cuda
        open HostTensor
        open CudaTensor

        inl call method args = 
            inl to_dev_tensor x = assert_contiguous x; assert_singleton x; to_dev_tensor x
            inl args = Tuple.map (function x : int64 -> unsafe_convert int32 x | x -> x) args
            join 
                inl args = 
                    Tuple.map (function 
                        | x : float64 | x : float32 -> ref x
                        | (.nT | .T) as x -> to_operation x
                        | {ptr=!to_dev_tensor x} -> x.bodies.ar
                        | x -> x
                        ) args
                inl native_type = fs [text: "ManagedCuda.CudaBlas.CudaBlasNativeMethods"]
                inl status_type = fs [text: "ManagedCuda.CudaBlas.CublasStatus"]
                inl assert_ok status = macro.fs unit [text: "if "; arg: status; text: " <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException"; args: status]
                FS.StaticMethod native_type method args status_type |> assert_ok

        FS.Method cublas .set_Stream (Stream.extract stream) unit

        /// General matrix-matrix multiply from cuBLAS. Inplace version
        inl gemm' transa transb alpha A B beta C =
            // -------

            // These two are meant to be called from inside gemm as they lack boundary checks.
            // I've added them to enhance gemm's vector handling capabilities for online learning
            // tasks.

            /// o <- alpha * op(A) * x + beta * o
            /// Matrix-vector multiplication. Inplace version.
            inl gemv transa alpha A x beta o =
                inl m,n = rows A, cols A
                inl lda = m
                call.cublasSgemv_v2(handle, transa, m, n, alpha, {ptr=A}, lda, {ptr=x}, 1, beta, {ptr=o}, 1)

            // A <- alpha * x * yT + beta * A (outer product)
            inl ger alpha x y beta a =
                inl max (a,b) = max a b
                inl m = max (rows x, cols x)
                inl n = max (rows y, cols y)

                match beta with
                | 0.0f64 | 0.0f32 -> ()
                | _ -> CudaKernel.map' (toa_map ((*) beta) |> const) a a

                call.cublasSger_v2(handle, m, n, alpha, {ptr=x}, 1, {ptr=y}, 1, {ptr=a}, m)

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

            //// If is outer product call ger
            //if a_col = 1 && b_row = 1 then ger alpha A B beta C
            //// If the vector is on the right side or both are vectors call gemv normally.
            //elif is_vector B then gemv transa alpha A B beta C
            //// If the vector is on the left side call gemv with the arguments switched and transposed
            //// It does not actually transpose them, just their views. The function should work regardless.
            //elif is_vector A then
            //    inl optb = if isnT transb then .T else .nT
            //    gemv optb alpha B A beta C
            //// Just do the standard matrix multiply
            //else
            call.cublasSgemm_v2(handle, transa, transb, m, n, k, alpha, {ptr=A}, lda, {ptr=B}, ldb, beta, {ptr=C}, ldc)

        inl gemm transa transb alpha A B ret =
            inl m = if isnT transa then rows A else cols A
            inl n = if isnT transb then cols B else rows B

            inb C = create {dim=m,n; elem_type = A.elem_type}
            gemm' transa transb alpha A B (zero_of alpha) C
            ret C

        {gemm' gemm}
    """) |> module_

let learning =
    (
    "Learning",[host_tensor;extern_],"The deep learning module.",
    """
inl {default_float CudaTensor CudaKernel CudaBlas CudaRandom} ->
    open HostTensor
    open CudaTensor
    open CudaKernel
    open CudaBlas

    // #Primitives
    inl zero = Extern.zero_of default_float
    inl one = Extern.one_of default_float
    inl two = unsafe_convert default_float 2
    inl infinity =
        match default_float with
        | _: float32 -> infinityf32
        | _: float64 -> infinityf64

    inl dr primal ret =
        inb adjoint = zero_like primal
        ret {DR={primal adjoint}; block_toa_map=()}

    inl dr_lazyhost primal = {DR={primal adjoint=Extern.zero_of primal.elem_type |> ref}; block_toa_map=()}
    inl dr_host primal = {DR={primal adjoint=Extern.zero_of (type primal) |> ref}; block_toa_map=()}

    inl primal = function {DR={primal}} | primal -> primal
    inl adjoint = function {DR={adjoint}} -> adjoint | _ -> .nil

    inl primals = toa_map primal
    inl adjoints = toa_map adjoint

    inl (>>!) a b ret = a <| inl a -> b a ret

    inl is_not_unit = function
        | () -> false
        | _ -> true

    inl rec filter_units = function
        | x :: x' -> 
            match filter_units x with
            | () -> filter_units x'
            | x -> x :: filter_units x'
        | {} & x ->
            module_filter (inl k (!filter_units (!is_not_unit x)) -> x) x
            |> inl x -> if eq_type x {} then () else x
        | .nil -> ()
        | x -> x

    // What this does is selectively filter out the results of applying f 
    // where the adjoints are missing (in other words constants.)
    inl filter_based_on_adjoints x adjoint =
        inl rec mark_units = function
            | x :: x', y :: y' -> mark_units (x,y) :: mark_units (x',y')
            | (), () -> ()
            | (), _ | _, () -> error_type "Tuple dimesions do not match."
            | {} & x, {} & y -> module_map (inl k y -> mark_units (x k,y)) y
            | _, .nil -> ()
            | x, _ -> x
        mark_units (x, adjoint) |> filter_units

    inl filter_unit_and_branch x ret =
        match filter_units x with
        | () -> ()
        | x -> ret x

    inl on_non_nil B ret =
        match B with
        | .nil -> ()
        | B -> ret B

    inl matmult A B ret =
        inb C = gemm .nT .nT one (primal A) (primal B) >>! dr
        ret (C, inl _ ->
            on_non_nil (adjoint A) (inl A -> gemm' .nT .T one (adjoint C) (primal B) one A)
            on_non_nil (adjoint B) (inl B -> gemm' .T .nT one (primal A) (adjoint C) one B)
            )

    inl map {fwd bck} in ret =
        inl primal, adjoint = primals in, adjoints in
        inb out = map fwd primal >>! dr
        ret (out, inl _ ->
            inl out = match out with {DR={primal adjoint}} -> zip (primal, adjoint) .update_body2 (inl P A -> {P A})
            inl bck =
                inl bck = filter_based_on_adjoints bck adjoint
                inl in adjoint -> toa_map ((|>) in) bck |> toa_map2 (+) adjoint

            inb adjoint = filter_unit_and_branch adjoint 
            map' bck {in=primal; out} adjoint
            )

    inl replicate_map {fwd bck={bck_in bck_in'}} in in' ret =
        inl primal, adjoint = primals in, adjoints in
        inl primal', adjoint' = primals in', adjoints in'
        inb out = replicate_map fwd primal primal' >>! dr
        ret (out, inl _ ->
            inl out = match out with {DR={primal adjoint}} -> zip (primal, adjoint) .update_body2 (inl P A -> {P A})
            on_non_nil adjoint (map_d2_redo_map' bck_in {in'=primal'; out} primal)
            on_non_nil adjoint' (replicate_map' bck_in' primal {in'=primal'; out})
            )

    inl matmultb A B bias ret =
        inb C = gemm .nT .nT one (primal A) (primal B) >>! dr
        replicate_map' (inl a b _ -> a+b) (primal bias) (primal C) (primal C)
        ret (C, inl _ ->
            inl C' = adjoint C
            on_non_nil (adjoint A) (inl A -> gemm' .nT .T one C' (primal B) one A)
            on_non_nil (adjoint B) (inl B -> gemm' .T .nT one (primal A) C' one B)
            on_non_nil (adjoint bias) (inl bias -> map_d2_redo_map' {map_in=const;neutral_elem=zero;redo=(+);map_out=(+)} C' bias.empty bias)
            )

    inl add_bias = replicate_map {
        fwd=(+)
        bck={
            bck_in={
                map_in=inl {out} _ -> out.A
                neutral_elem=zero;redo=(+)
                map_out=(+)
                }
            bck_in'=inl _ {out} adjoint -> out.A + adjoint
            }
        }

    inl host_map {fwd bck} in ret =
        inl primal, adjoint = primals in, adjoints in
        inl out = fwd primal |> dr_host
        ret (out, inl _ ->
            inl out = toa_map2 (inl P A -> {P A=A()}) (primals out) (adjoints out)
            inl bck = 
                inl bck = filter_based_on_adjoints bck adjoint
                toa_map ((|>) {in=primal; out}) bck
            inb adjoint = filter_unit_and_branch adjoint 
            toa_map2 (inl a b -> a := a() + b) adjoint bck
            )

    inl map_redo {fwd bck} in ret =
        inl primal, adjoint = primals in, adjoints in
        inl out = map_redo fwd primal |> dr_host
        ret (out, inl _ ->
            inl out = toa_map2 (inl P A -> {P A=A()}) (primals out) (adjoints out)
            inl bck =
                inl bck = filter_based_on_adjoints bck adjoint
                inl {in} adjoint -> toa_map ((|>) {in out}) bck |> toa_map2 (+) adjoint
            inb adjoint = filter_unit_and_branch adjoint 
            map' bck {in=primal} adjoint
            )

    inl Primitive = {matmult matmultb map map_redo host_map replicate_map add_bias}

    // #Operations
    inl (>>=) a b ret =
        inb a,a_bck = a
        inb b,b_bck = b a
        ret (b, inl _ -> b_bck(); a_bck())

    inl succ x ret = ret (x, const ())

    inl multiply_by_adjoint f {d with out={A P} in} = toa_map ((*) A) (f {in out=P})
    inl activation d = map {d with bck = multiply_by_adjoint self }

    inl sigmoid = activation {
        fwd = inl x -> one / (one + exp -x)
        bck = inl {out} -> out * (one - out)
        }

    inl Activation = {sigmoid}

    inl accuracy (input,label) ret =
        inl input, label = primal input, primal label
        inb x = 
            map_d1_redo_map {
                map_in=const
                neutral_elem=-infinity,zero
                redo=inl a b -> if fst a > fst b then a else b
                map_out=snd
                } (input,label) ()
        Array.foldl (inl s x -> if x = one then s+1 else s) (dyn 0) (to_host_tensor x).bodies.ar 
        |> ret

    inl error {fwd bck} (input,_ as x) = 
        inl batch_size = primal input .dim |> fst |> span
        inl div_by_minibatch_size x = x / unsafe_convert default_float batch_size
        inm cost =
            map_redo {
                fwd = {
                    map = fwd
                    redo = (+)
                    neutral_elem = zero
                    }
                bck = toa_map multiply_by_adjoint bck
                } x
            >>= host_map {fwd = div_by_minibatch_size; bck = inl {out={A}} -> div_by_minibatch_size A}
        inl accuracy = accuracy x
        succ {cost accuracy}

    inl square = error {
        fwd = inl (x,y) -> (y - x) * (y - x)
        bck = 
            inl {in=x,y} -> two * (x - y)
            ,inl {in=x,y} -> two * (y - x)
        }

    inl cross_entropy = error {
        fwd = inl x, y -> -(y * log x + (one - y) * log (one - x))
        bck = 
            inl {in=x, y} -> x * (x - y) / (one - x)
            ,inl {in=x, y} -> log (one - x) - log x
        }

    inl Error = {square cross_entropy}

    // #Feedforward
    inl layer initializer activation hidden_size next_layer input_size ret =
        inb weight = initializer (input_size, hidden_size) >>! dr
        inb bias = CudaTensor.zero {elem_type=default_float; dim=hidden_size} >>! dr
        inb {weights apply} = next_layer hidden_size
        ret {
            weights = (weight, bias) :: weights
            apply = inl input -> matmultb input weight bias >>= activation >>= apply
            }

    //inl layer initializer activation hidden_size next_layer input_size ret =
    //    inb weight = initializer (input_size, hidden_size) >>! dr
    //    //inb bias = CudaTensor.zero {elem_type=default_float; dim=hidden_size} >>! dr
    //    inb {weights apply} = next_layer hidden_size
    //    ret {
    //        weights = weight :: weights
    //        apply = inl input -> matmult input weight >>= activation >>= apply
    //        }

    inl sigmoid_initializer dim = 
        inl stddev = sqrt (two / unsafe_convert default_float (Tuple.foldl (+) 0 dim))
        CudaRandom.create_tensor {dst=.Normal; stddev mean=0f32} {dim elem_type=type zero}

    inl sigmoid = layer sigmoid_initializer sigmoid
    inl linear = layer sigmoid_initializer succ

    inl init = 
        inl fin _ ret =
            ret {
                weights = ()
                apply = succ
                }            
        function
        | _ :: _ as layers -> Tuple.foldr (<|) layers fin
        | layer -> layer fin
    inl with_error error network ret = ret {network with apply = inl (input,label) -> self input >>= inl input -> error (input,label)}

    inl Feedforward = {sigmoid linear init with_error}

    // #Optimizer
    inl sgd learning_rate x = 
        inl primal, adjoint = primal x, adjoint x
        map' (toa_map2 (inl A P -> P - learning_rate * A)) adjoint primal
        CudaTensor.clear adjoint 

    inl Optimizer = {sgd}

    inl run {d with network={weights apply} input label state} =
        open Extern
        open Console
        inl dim1 x = x.dim |> fst
        inl to = unsafe_convert

        assert (dim1 input = dim1 label) "Training and test set need to have to equal first dimensions."

        inl run_minibatch {state span} = 
            inl view x = x.view_span span
            inb {cost accuracy}, bck = apply (view input, view label)
            inl primal = primal cost
            //string_format "On minibatch {0}. Error = {1}" (show span, primal) |> writeline

            match d with
            | {optimizer} ->
                adjoint cost := one_of primal
                bck() // Runs the backwards pass.
                toa_iter optimizer weights
            | _ -> ()

            inl running_cost =
                match state with
                | {running_cost} -> running_cost + to float64 primal * to float64 (HostTensor.span span)
                
            match state with
            | {running_accuracy} -> { running_cost running_accuracy=running_accuracy + accuracy id }
            | _ -> {running_cost}
            
        inl {from near_to} = dim1 input
        inl span = near_to - from
        inl by = match d with {minibatch_size} -> minibatch_size | _ -> span

        inl state = Loops.for {from near_to; state by; body=inl {state i=from} ->
            if span % by = 0 then run_minibatch {state span={from by}}
            else run_minibatch {state span={from near_to=from+by |> min near_to}}
            }

        writeline "-----"
        writeline "Batch done."
        match state with {running_cost} -> string_format "Average of batch costs is {0}." (running_cost / to float64 span) |> writeline | _ -> ()
        match state with {running_accuracy} -> string_format "The accuracy of the batch is {0}/{1}." (running_accuracy,span) |> writeline | _ -> ()
        writeline "-----"

    inl grad_check {d with network={weights apply} input label} =
        open Extern
        inl CDV t = fs [text: "ManagedCuda.CudaDeviceVariable"; types: t] |> FS.Constructor
        inl SizeT = fs [text: "ManagedCuda.BasicTypes.SizeT"] |> FS.Constructor
        inl into_cdv x =
            inl {ar offset=offset : int64} = x.bodies
            inl elem_type = ar.elem_type
            inl size = sizeof elem_type
            inl ptr = ar.ptr()
            {cdv=CDV elem_type (ptr,false,SizeT size); elem_type offset}

        inl get_cdv x = macro.fs x.elem_type [arg:x.cdv; text: ".["; arg:SizeT x.offset; text: "]"]
        inl set_cdv x v = macro.fs unit [arg:x.cdv; text: ".["; arg:SizeT x.offset; text: "] <- "; arg:v : x.elem_type]

        // Run it once.
        inb {cost accuracy}, bck = apply (input, label)
        adjoint cost := 1f32
        bck()

        inl epsilon = 0.001f32
        inl boundary = 0.001f32
        // Assert that all the gradients make sense.

        inl rec perturb primal' adjoint' =
            HostTensor.assert_zip (primal', adjoint') |> ignore
            match primal'.dim with
            | {from near_to} :: _ ->
                Loops.for {from near_to body=inl {i} ->
                    perturb (primal' i) (adjoint' i)
                    }
            | _ -> 
                met cost () =
                    inb {cost accuracy}, bck = apply (input, label)
                    primal cost
                inl cdv = into_cdv primal'
                inl orig = get_cdv cdv
                set_cdv cdv (orig + epsilon)
                inl cost_plus_epsilon = cost ()
                set_cdv cdv (orig - epsilon)
                inl cost_minus_epsilon = cost ()
                set_cdv cdv orig
                inl approx_gradient = (cost_plus_epsilon - cost_minus_epsilon) / (2.0f32 * epsilon)

                inl cdv = into_cdv adjoint'
                inl true_gradient = get_cdv cdv
                
                inl diff = abs (true_gradient - approx_gradient)
                if diff >= boundary then
                    Console.writeline {true_gradient approx_gradient diff}
                    Console.writeline "--- Gradient checking failure."
                
        toa_iter (inl t -> perturb (primal t) (adjoint t)) weights


    {dr primal primals adjoint adjoints (>>!) Primitive succ (>>=) Activation Error Feedforward Optimizer run grad_check accuracy }
    """) |> module_