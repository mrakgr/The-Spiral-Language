[<AutoOpen>]
module Cuda.Lib

open Spiral.Types
open Spiral.Lib

let mnist: SpiralModule =
    {
    name="Mnist"
    prerequisites=[extern_; host_tensor]
    opens=[]
    description="The Mnist loader module."
    code=
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

    inl to_ints64 = Tuple.map (to int64)

    inl magic_number = read_int32()
    match kind with
    | .label ->
        assert (magic_number = 2049i32) "Expected a 2049i32 magic number."
        inl n = read_int32()
        to int64 n, read_bytes n
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
            Tensor.array_as_tensor ar
            |> Tensor.split (const (images, rows * cols))
            |> Tensor.map (inl x -> to float32 x / 255f32)
            
        | {file label_size} ->
            inl n, ar = load_mnist .label (combine (mnist_path, file))
            assert (label_size = n) "Mnist dimensions do not match the expected values."
            Tensor.init (label_size, 10) (inl a ->
                inl x = ar a
                inl b -> if to uint8 b = x then 1.0f32 else 0.0f32
                )
        ) mnist_files

{load_mnist_tensors}
    """
    }

let cuda_aux: SpiralModule =
    {
    name="CudaAux"
    prerequisites=[struct']
    opens=[]
    description="The Cuda auxiliaries module."
    code=
    """
inl ptr_cuda {ar offset} ret = ar.ptr() + to uint64 (offset * sizeof ar.elem_type) |> ret
inl to_dev_tensor = 
    Struct.map' <| function
        | x when val_is x -> x
        | x ->
            x.update_body <| inl body -> 
                inb ptr = ptr_cuda body
                {body with ar=!UnsafeCoerceToArrayCudaGlobal(ptr,body.ar.elem_type); offset=0}
        
inl allocator_block_size = 256u64

inl temporary tns ret =
    inl x = ret tns
    Struct.iter' (inl !unconst {ar} -> ar.ptr.Dispose) tns.bodies
    x

inl atomic_add o x =
    inl (),{ar offset} = o.dim, unconst o.bodies
    inl adr = macro.cd ar [arg: ar; text: " + "; arg: offset]
    macro.cd () [text: "atomicAdd"; args: adr, x]

inl assert_dim in =
    module_map (inl k dim ->
        match in with
        | {$k=in} ->
            Struct.foldr2 (inl a b i -> 
                assert (a = b) (string_format "The {0}th dimension of {1} must match. {2} <> {3}" (i,type_lit_cast k,a,b))
                i+1
                ) (in .dim |> Tuple.unwrap) dim 0
            |> ignore
        | _ ->
            ()
        )
    >> ignore

{ptr_cuda to_dev_tensor allocator_block_size temporary atomic_add assert_dim} |> stackify
    """
    }

let allocator: SpiralModule =
    {
    name="Allocator"
    prerequisites=[resize_array; loops; option; extern_; console; cuda_aux]
    opens=[]
    description="The section based GPU memory allocator module."
    code=
    """
open Extern

inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
inl SizeT = FS.Constructor SizeT_type
inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT

inl smartptr_create (ptr: uint64) =
    inl cell = ref ptr
    function
    | .Dispose -> cell := 0u64
    | .Try -> cell()
    | () -> join 
        inl x = cell ()
        assert (x <> 0u64) "A disposed Cuda memory cell has been tried to be accessed."
        x

inl mult = CudaAux.allocator_block_size
assert (mult <> 0u64 && (mult &&& mult - 1u64) = 0u64) "Multiple must be a power of 2." 
inl round_up_to_multiple size = (size + mult - 1u64) &&& 0u64 - mult

inl to_uint x = FS.UnOp .uint64 x uint64
inl allocate_global s =
    to uint64 >> round_up_to_multiple >> dyn
    >> inl size -> { size ptr = FS.Method s.data.context .AllocateMemory (SizeT size) CUdeviceptr_type |> to_uint |> smartptr_create }

/// Linear search to find the index of the largest free cell.
inl find_index_of_largest_free_cell free_cells =
    Loops.for {from=0i32; near_to=free_cells.used_cells.count; by=1i32; state={size=0u64; index=0i32}; body=inl {state i} ->
        inl used_cells = free_cells.used_cells i
        inl size' =
            if used_cells.count > 0i32 then
                inl {ptr size} = used_cells.last
                inl ptr_end = ptr.Try + size
                inl free_cell_end = free_cells.ptr i + free_cells.size i
                free_cell_end - ptr_end
            else
                free_cells .size i
        if state.size < size' then {index=i; size=size'}
        else state
        }
    |> inl {index} -> index

met refresh s =
    inl {pool free_cells} = s.data.section
    inl pool_type = type pool

    // Adds a element into the free cell at the last position. Splits the cells when needed.
    inl add {ar with ptr size} =
        inl last = free_cells.used_cells.count-1i32
        inl global_ptr = free_cells.ptr last
        inl global_size = free_cells.size last

        inl ptr = ptr.Try
        inl global_ptr_end = global_ptr + global_size
        if global_ptr_end < ptr then
            // If there is a gap then make a new cell and add the current element to it.
            free_cells.size.set last (ptr-global_ptr)
            inl used_cells = ResizeArray.create {elem_type=pool_type}
            used_cells.add ar

            free_cells.ptr.add ptr
            free_cells.size.add size
            free_cells.used_cells.add used_cells
        elif global_ptr_end = ptr then
            // Add the current element to the current cell.
            free_cells.size.set last (global_size+size)
            inl used_cells = free_cells.used_cells last
            used_cells.add ar
        else
            failwith () "The elements should always be ordered."

    inl used_cells = ResizeArray.create {elem_type=pool_type}

    // Filters out the nils and adds the rest to the array.
    free_cells.used_cells.iter <| inl x ->
        x.iter <| inl x -> 
            if x .ptr .Try <> 0u64 then used_cells.add x

    // Clear the free cells
    free_cells.used_cells.clear
    free_cells.ptr.clear
    free_cells.size.clear
    
    // Init the free cells
    free_cells.ptr.add <| pool.ptr()
    free_cells.size.add 0u64
    free_cells.used_cells.add <| ResizeArray.create {elem_type=pool_type}
    free_cells.index := 0i32

    used_cells.iter add

    inl _ = // Set the size of the last free cell so it goes to the end of the pool.
        inl last = free_cells.used_cells.count-1i32
        inl ptr = free_cells.ptr last
        inl pool_ptr_end = pool.ptr.Try + pool.size
        free_cells.size .set last (pool_ptr_end - ptr) 
    ()

met allocate s (!(to uint64 >> round_up_to_multiple >> dyn) size') =
    inl {pool free_cells} = s.data.section

    met rec clear_top_if_nil () =
        inl index = free_cells.index()
        inl used_cells = free_cells.used_cells index
        inl i = used_cells.count-1i32
        if i >= 0i32 then
            // Remove the empty pointers.
            inl {ptr} = used_cells i
            if ptr.Try = 0u64 then
                used_cells.remove_at i
                clear_top_if_nil ()
        else
            if index > 0i32 then 
                // Merge the cell with the previous one.
                inl size = free_cells.size index
                free_cells.size .set (index-1i32) (free_cells.size (index-1i32) + size)
                Tuple.iter (inl x -> free_cells x .remove_at index) (.size,.used_cells,.ptr)
                free_cells.index := index - 1i32
                
                clear_top_if_nil ()
        : ()

    inl loop next =
        clear_top_if_nil()

        /// Try allocating memory.
        met size_remaining, ptr =
            inl index = free_cells.index()
            inl used_cells = free_cells.used_cells index
            inl free_cell_ptr = free_cells.ptr index
            inl free_cell_end = free_cell_ptr + free_cells.size index
            if used_cells.count > 0i32 then
                inl used_cell_end = used_cells.last |> inl {ptr size} -> ptr.Try + size
                free_cell_end - used_cell_end, used_cell_end
            else
                free_cell_end, free_cell_ptr
        if size_remaining >= size' then {ptr=smartptr_create ptr; size=size'}
        else next ()

    inl x =
        loop <| inl _ ->
            // Try a bigger cell.
            free_cells.index := find_index_of_largest_free_cell free_cells
            loop <| inl _ -> 
                // Do a GC.
                refresh s
                loop <| inl _ ->
                    failwith pool "Out of memory in the designated section."

    inl index = free_cells.index()
    free_cells.used_cells index .add x
    x.ptr

inl section_create s size ret =
    inl pool = allocate_global s size
    inl free_cells = 
            {
            used_cells=ResizeArray.create {elem_type=type ResizeArray.create {elem_type=type pool}}
            size=ResizeArray.create {elem_type=uint64}
            ptr=ResizeArray.create {elem_type=uint64}
            index=ref 0i32
            }
    inl section = {pool free_cells} |> heap
    inl allocate s = function
        | .elem_type -> type s.data.section.pool.ptr
        | x -> allocate s x
        
    inl s =
        s.member_add {refresh allocate}
         .data_add {section}
    
    refresh s
    ret s

    inl ptr = pool.ptr
    FS.Method s.data.context .FreeMemory (ptr() |> CUdeviceptr) ()
    ptr.Dispose

stack section_create
    """
    }

let region: SpiralModule =
    {
    name="Region"
    prerequisites=[resize_array]
    opens=[]
    description="The region based resource tracker."
    code=
    """
inl counter_ref_create ptr =
    inl count = ref 0
    function
    | .inc -> count := count() + 1
    | .dec -> 
        count := count() - 1
        if count() = 0 then ptr.Dispose
    | x -> ptr x

inl assign {region_name} s r = 
    inl region = s .data region_name
    join r.inc; region.add r

inl allocate_mem d s (!dyn x) =
    inl allocate = d.allocate s
    join
        inl r = allocate x |> counter_ref_create
        assign d s r; r

inl allocate_stream d s =
    inl allocate = d.allocate s
    s.data_add {
        stream=join
            inl r = counter_ref_create allocate
            assign d s r; r
        }

inl clear {region_name} s =
    inl region = s .data region_name
    join 
        region.iter (inl r -> r.dec)
        region.clear

inl create {region_name allocate} s = 
    inl elem_type = type counter_ref_create (var (allocate s).elem_type)
    inl region = ResizeArray.create {elem_type}
    s.data_add {$region_name=region}

inl create' {region_module_name} s ret =
    inl s = s region_module_name .create
    inl r = ret s
    s region_module_name .clear
    r

inl methods_template d = 
    {
    assign = assign d
    clear = clear d
    create = create d 
    create' = create' d
    }

inl methods_mem = 
    inl region_module_name = .RegionMem
    inl d = {
        region_module_name
        region_name = .region_mem
        allocate = inl s -> s.allocate
        }
    inl x = methods_template d
    region_module_name, {x with allocate = allocate_mem d}

inl methods_stream =
    inl region_module_name = .RegionStream
    inl d = {
        region_module_name
        region_name = .region_stream
        allocate = inl s -> s.Stream.allocate
        }
    inl x = methods_template d
    region_module_name, {x with allocate = allocate_stream d }

inl s -> 
    inl add s (a, b) = s.module_add a (stackify b)
    Tuple.foldl add s (methods_mem, methods_stream)
    """
    }

let cuda_stream: SpiralModule =
    {
    name="CudaStream"
    prerequisites=[extern_]
    opens=[]
    description="The Cuda stream module."
    code=
    """
open Extern
inl ty x = fs [text: x]
inl dispose x = FS.Method x .Dispose () ()

inl rec allocate _ =
    inl data =
        {
        is_live = ref true
        stream = FS.Constructor (ty "ManagedCuda.CudaStream") ()
        event = FS.Constructor (fs [text: "ManagedCuda.CudaEvent"]) ()
        } |> heap
    function
    | .Dispose ->
        dispose data.stream
        dispose data.event
        data.is_live := false
    | .elem_type -> type allocate ()
    | x -> join
        assert (data.is_live()) "The stream has been disposed."
        match x with
        | .extract -> macro.fs (ty "ManagedCuda.BasicTypes.CUstream") [arg: data.stream; text: ".Stream"]
        | .synchronize -> FS.Method data.stream .Synchronize() ()
        | .wait_on on ->
            FS.Method data.event .Record on.extract ()
            macro.fs () [arg: data.stream; text: ".WaitEvent "; arg: data.event; text: ".Event"]
        | () -> data.stream

inl s -> s.module_add .Stream (stackify {allocate})
    """
    }

let cuda_tensor: SpiralModule =
    {
    name="CudaTensor"
    prerequisites=[extern_; host_tensor_tree_view; host_tensor_range_view; cuda_aux]
    opens=[]
    description="The Cuda tensor module."
    code=
    """
open Tensor
open Extern

inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
inl SizeT = FS.Constructor SizeT_type
inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT

inl ptr_cuda = CudaAux.ptr_cuda
inl CUResult_ty = fs [text: "ManagedCuda.BasicTypes.CUResult"]
inl assert_curesult res = macro.fs () [text: "if "; arg: res; text: " <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException"; args: res]
//inl memcpy dst_ptr src_ptr size = macro.fs CUResult_ty [text: "ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy"; args: CUdeviceptr dst_ptr, CUdeviceptr src_ptr, SizeT size] |> assert_curesult
inl memcpy_async dst_ptr src_ptr size stream = macro.fs CUResult_ty [text: "ManagedCuda.DriverAPINativeMethods.AsynchronousMemcpy_v2.cuMemcpyAsync"; args: CUdeviceptr dst_ptr, CUdeviceptr src_ptr, SizeT size, stream] |> assert_curesult

inl GCHandle_ty = fs [text: "System.Runtime.InteropServices.GCHandle"]
inl ptr_dotnet {ar offset} ret =
    inl elem_type = ar.elem_type
    inl handle = macro.fs GCHandle_ty [type:GCHandle_ty; text: ".Alloc"; parenth: [arg: ar; text: "System.Runtime.InteropServices.GCHandleType.Pinned"]]
    inl r =
        macro.fs int64 [arg: handle; text: ".AddrOfPinnedObject().ToInt64()"] 
        |> to uint64 |> (+) (to uint64 (offset * sizeof elem_type)) |> ret
    macro.fs () [arg: handle; text: ".Free()"]
    r

inl copy s span dst {src with ar size ptr_get} =
    inl stream = s.data.stream.extract
    inl elem_type = ar.elem_type 
    assert (blittable_is elem_type) "The host array type must be blittable."
    inl span_size = match size with () -> span | size :: _ -> span * size
    inb src = ptr_get src
    inl memcpy dst = memcpy_async dst src (span_size * sizeof elem_type) stream
    match dst with
    | {ar size=size' ptr_get} -> 
        assert (size' = size) "The source and the destination must have the same sizes."
        assert (eq_type ar.elem_type elem_type) "The source and the destination must have the same types"
        inb dst = ptr_get dst
        memcpy dst
    | {array_create ptr_get} -> 
        inl ar = array_create elem_type span_size
        inb dst = ptr_get {ar offset=0}
        memcpy dst
        ar

inl transfer_template f tns = 
    assert_contiguous tns
    inl f = f tns.span_outer
    tns.update_body <| inl body -> {body with ar = f body; offset = 0}

inl array_create_cuda_global s elem_type len =
    inl ptr = join s.RegionMem.allocate (len * sizeof elem_type)
    inl elem_type = stack {value = elem_type}
    function // It needs to be like this rather than a module so Struct.map does not split it.
    | .elem_type -> elem_type.value
    | .ptr -> ptr

inl clear' s x = s.CudaTensor.clear x; x

met to_host_array s (!dyn span) (!dyn {src with ar offset size}) =
    copy s span {array_create ptr_get=ptr_dotnet} {src with ptr_get=ptr_cuda}

met from_host_array s (!dyn span) (!dyn {src with ar offset size}) =
    copy s span {array_create=array_create_cuda_global s; ptr_get=ptr_cuda} {src with ptr_get=ptr_dotnet}

/// For interfacing with Cuda APIs.
met from_cudadevptr_array s ar =
    inl dst = copy s (array_length ar) {array_create=array_create_cuda_global s; ptr_get=ptr_cuda} {ar size=(); offset=0; ptr_get=ptr_dotnet}
    CUdeviceptr dst.ptr.Try

inl get_elem s !unconst {src with size=()} = to_host_array s 1 src 0

met set_elem s (!(unconst >> dyn) {dst with size=()}) (!dyn v) =
    inl ar = array_create v 1
    ar 0 <- v
    copy s 1 {dst with ptr_get=ptr_cuda} {ar size=(); offset=0; ptr_get=ptr_dotnet}

inl methods = 
    {
    create=inl s data -> create {data with array_create = array_create_cuda_global s}
    create_view=inl s data -> View.create {data with array_create = array_create_cuda_global s}
    create_like=inl s tns -> s.CudaTensor.create {elem_type=tns.elem_type; dim=tns.dim}
    create_like_view=inl s tns -> View.create_like {array_create = array_create_cuda_global s} tns

    to_host_array from_host_array from_cudadevptr_array

    get=inl s tns ->
        match tns.unwrap with
        | {bodies dim=()} -> Struct.map' (get_elem s) bodies
        | _ -> error_type "Cannot get from tensor whose dimensions have not been applied completely."

    set=inl s tns v ->
        match tns.unwrap with
        | {bodies dim=()} -> Struct.iter2' (set_elem s) bodies v
        | _ -> error_type "Cannot set to a tensor whose dimensions have not been applied completely."

    from_scalar = inl s -> Tensor.from_scalar >> s.CudaTensor.from_host_tensor
    from_host_tensor=inl s -> transfer_template s.CudaTensor.from_host_array
    from_host_tensors=inl s -> Struct.map s.CudaTensor.from_host_tensor
    to_host_tensor=inl s -> transfer_template s.CudaTensor.to_host_array

    clear=met s tns ->
        assert_contiguous tns
        inl span = tns.span_outer
        inl stream = s.data.stream.extract
        inl context = s.data.context
        tns.update_body <| inl {body with size ar} ->
            join
                inl size = match size with () -> 1 | x :: _ -> x
                FS.Method context .ClearMemoryAsync (CUdeviceptr (ar.ptr()), 0u8, size * span * sizeof ar.elem_type |> SizeT, stream) ()
        |> ignore

    copy=inl s d ->
        met body src dst = 
            assert_contiguous dst
            assert_contiguous src
            inl stream = s.data.stream.extract
            assert (eq_type dst.elem_type src.elem_type) "The two tensors must have the same type."
            assert (dst.dim = src.dim) "The two tensors must have the same dimensions."
            inl span = dst.span_outer
            Struct.iter2' (inl (!unconst dst) (!unconst src) ->
                inl size = match dst.size with () -> 1 | x :: _ -> x
                inl elem_type_size = sizeof dst.ar.elem_type
                inb dst = ptr_cuda dst
                inb src = ptr_cuda src
                memcpy_async dst src (span * size * elem_type_size) stream
                ) dst.bodies src.bodies

        match d with
        | {from to} -> body from to
        | {from} | from -> 
            inl to = s.CudaTensor.create_like from
            body from to
            to
  
    zero=inl s d -> indiv join s.CudaTensor.create d |> clear' s |> stack
    zero_like=inl s d -> indiv join s.CudaTensor.create_like d |> clear' s |> stack
    zero_view=inl s d -> indiv join 
        inl x = s.CudaTensor.create_view d
        s.CudaTensor.clear x.basic
        stack x
    zero_like_view=inl s d -> indiv join 
        inl x = s.CudaTensor.create_like_view d
        s.CudaTensor.clear x.basic
        stack x

    print=met s (!dyn x) ->
        match x with
        | {cutoff input=x} -> 
            inb x = s.CudaFun.map {map=id} x |> CudaAux.temporary    
            Tensor.print {cutoff input=s.CudaTensor.to_host_tensor (zip x)} 
        | x -> 
            inb x = s.CudaFun.map {map=id} x |> CudaAux.temporary
            s.CudaTensor.to_host_tensor (zip x) |> Tensor.print

    mmap=inl s f tns -> s.CudaKernel.map' (const f) tns.empty tns
    } |> stackify

inl s -> s.module_add .CudaTensor methods
    """
    }

let cuda_random: SpiralModule =
    {
    name="CudaRandom"
    prerequisites=[extern_; cuda_tensor]
    opens=[]
    description="The CudaRandom module."
    code=
    """
inl s ret ->
    open Extern

    inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
    inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
    inl SizeT = FS.Constructor SizeT_type
    inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT
    
    use random' = 
        inl generator_type = fs [text: "ManagedCuda.CudaRand.GeneratorType"]
        FS.Constructor (fs [text: "ManagedCuda.CudaRand.CudaRandDevice"]) (FS.StaticField generator_type .PseudoDefault generator_type)
    inl s = s.data_add {random=random'}
    
    open Tensor
    
    inl fill_array s distribution size1d ar =
        // The allocator always allocates in blocks of 256 so incrementing the odd sizes by 1 won't be a problem.
        // The reason why this is necessary is because CudaRandom will throw exceptions on odds sizes.
        assert (CudaAux.allocator_block_size = 256u64) "The block size must be 256 (or a multiple of 2.)"
        inl size1d = SizeT (size1d + size1d % 2)
        inl random = s.data.random
        FS.Method random .SetStream s.data.stream.extract ()
        inl elem_type = ar.elem_type
        inl ar = CUdeviceptr ar
        inl gen, dot = "Generate", "."
        match distribution with
        | {dst=.Uniform & distribution} ->
            inl args = ar, size1d
            inl bits = 
                match elem_type with
                | _ : float32 -> "32" | _ : float64 -> "64"
                | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
            macro.fs () [arg: random; text: dot; text: gen; text: distribution; text: bits; args: args]
        | {dst=(.Normal | .LogNormal) & distribution stddev mean} ->
            match stddev with | _: float32 -> () | _ -> error_type "Standard deviation needs to be in float32."
            match mean with | _: float32 -> () | _ -> error_type "Mean needs to be in float32."

            inl args = ar, size1d, mean, stddev
            inl bits = 
                match elem_type with
                | _ : float32 -> "32" | _ : float64 -> "64"
                | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
            macro.fs () [arg: random; text: dot; text: gen; text: distribution; text: bits; args: args]
        | {dst=.UInt & distribution} -> // every bit random
            inl args = ar, size1d
            inl bits =
                match elem_type with
                | _ : uint32 -> "32" | _ : uint64 -> "64"
                | _ -> error_type "Only 32/64 bit uint types are supported."
            macro.fs () [arg: random; text: dot; text: gen; text: bits; args: args]

    inl fill s op in =
        indiv join
            inl in' = zip in |> flatten |> CudaAux.to_dev_tensor
            inl len = in'.length
            in'.update_body (inl {ar} -> fill_array s op len ar) |> ignore

    inl create s op dsc =
        indiv join
            inl device_tensor = s.CudaTensor.create dsc
            fill s op device_tensor
            stack device_tensor

    inl set_pseudorandom_seed s (v: uint64) = macro.fs () [arg: s.data.random; text: ".SetPseudoRandomGeneratorSeed"; args: v]

    ret <| s.module_add .CudaRandom {fill create set_pseudorandom_seed}
    """
    }

let cuda_blas: SpiralModule =
    {
    name="CudaBlas"
    prerequisites=[cuda_tensor; extern_]
    opens=[]
    description="The CudaBlas module."
    code=
    """
inl s ret ->
    open Extern
    
    inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
    inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
    inl SizeT = FS.Constructor SizeT_type
    inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT

    inl enum ty x = FS.StaticField ty x ty

    inl operation_type = fs [text: "ManagedCuda.CudaBlas.Operation"]
    inl to_operation = function
        | .T -> enum operation_type .Transpose
        | .nT -> enum operation_type .NonTranspose
    inl opposite_operation = function
        | .T -> .nT
        | .nT -> .T

    inl side_type = fs [text: "ManagedCuda.CudaBlas.SideMode"]
    inl to_side_mode .Left | .Right as x = enum side_type x
    inl opposite_side = function
        | .Left -> .Right
        | .Right -> .Left

    inl fill_mode_type = fs [text: "ManagedCuda.CudaBlas.FillMode"]
    inl to_fill_mode .Lower | .Upper as x = enum fill_mode_type x
    inl opposite_fill = function
        | .Lower -> .Upper
        | .Upper -> .Lower

    inl diag_type = fs [text: "ManagedCuda.CudaBlas.DiagType"]
    inl to_diag_type .NonUnit | .Unit as x = enum diag_type x

    inl isT = function
        | .T -> true
        | _ -> false

    inl isnT = function
        | .nT -> true
        | _ -> false

    inl rows x = x.dim |> inl a,b -> a
    inl cols x = x.dim |> inl a,b -> b
    inl ld x = unconst x.bodies .size |> fst

    use cublas' =
        inl cublas_type = fs [text: "ManagedCuda.CudaBlas.CudaBlas"]
        inl pointer_mode_type = fs [text: "ManagedCuda.CudaBlas.PointerMode"]
        inl atomics_mode_type = fs [text: "ManagedCuda.CudaBlas.AtomicsMode"]
        FS.Constructor cublas_type (enum pointer_mode_type .Host, enum atomics_mode_type .Allowed)
    inl s = s.data_add {cublas=cublas'}

    open Tensor

    inl mode_dev_ptr s = macro.fs () [arg: s.data.cublas, text: " <- ManagedCuda.CudaBlas.PointerMode.Device"]
    inl mode_host_ptr s = macro.fs () [arg: s.data.cublas, text: " <- ManagedCuda.CudaBlas.PointerMode.Host"]

    inl call s method args = 
        inl cublas = s.data.cublas
        inl stream = s.data.stream
        inl to_dev_tensor x = assert_unpadded x; CudaAux.to_dev_tensor x
        inl handle = FS.Method cublas .get_CublasHandle() (fs [text: "ManagedCuda.CudaBlas.CudaBlasHandle"])
        FS.Method cublas .set_Stream stream.extract ()
        inl args = 
            inl strip ptr = 
                assert (Tuple.last (unconst ptr.bodies .size) = 1) "The stride of the innermost dimension should always be 1."
                unconst (to_dev_tensor ptr).bodies .ar
            Tuple.map (function
                | x : float64 | x : float32 -> ref x
                | {ptr} -> strip ptr |> CUdeviceptr
                | {ptr_ar} -> Array.map strip ptr_ar |> s.CudaTensor.from_cudadevptr_array
                | .nT | .T as x -> to_operation x
                | .Left | .Right as x -> to_side_mode x
                | .Lower | .Upper as x -> to_fill_mode x
                | .NonUnit | .Unit as x -> to_diag_type x
                | x -> x
                ) args
        inl native_type = fs [text: "ManagedCuda.CudaBlas.CudaBlasNativeMethods"]
        inl status_type = fs [text: "ManagedCuda.CudaBlas.CublasStatus"]
        inl assert_ok status = macro.fs () [text: "if "; arg: status; text: " <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException"; args: status]
        FS.StaticMethod native_type method (handle :: args) status_type |> assert_ok

    /// Triangular matrix-vector multiply.
    met trmv' s uplo trans diag A x =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type x.elem_type float32) "B must be of type float32."

        inl assert_1d x msg = match x.dim with x :: () -> () | _ -> error_type msg
        assert_1d x "x must be a vector"

        inl m = rows A
        inl n = cols A

        assert (m = n) "A must be a square matrix."
        assert (m = x.span_outer) "The span of x must match the dimensions of A."

        inl f = to int32
        call s .cublasStrmv_v2(opposite_fill uplo, opposite_operation trans, diag, f n, {ptr=A}, f (ld A), {ptr=x}, f (ld x))

    inl trmv s uplo trans diag A x =
        indiv join
            inl x = s.CudaTensor.copy {from=x}
            trmv' s uplo trans diag A x
            stack x

    /// Triangular matrix-matrix multiply from cuBLAS. Inplace version
    met trmm' s side uplo trans diag alpha A B C =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type B.elem_type float32) "B must be of type float32."
        assert (eq_type C.elem_type float32) "C must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."

        inl assert_side A B =
            assert (A.col = B.row) "Colums of A does not match rows of B in TRMM."
            assert (A.row = rows C && B.col = cols C) "Output matrix dimensions do not match in TRMM."

        inl f = function {T} -> {row=cols T; col=rows T} | T -> {row=rows T; col=cols T}
        inl g T = match trans with .T -> {T} | .nT -> T
        match side with
        | .Left -> assert_side (f (g A)) (f B)
        | .Right -> assert_side (f B) (f (g A))

        inl m = rows B
        inl n = cols B

        inl f = to int32
        call s .cublasStrmm_v2(opposite_side side, opposite_fill uplo, trans, diag, f n, f m, alpha, {ptr=A}, f (ld A), {ptr=B}, f (ld B), {ptr=C}, f (ld C))

    inl trmm s side uplo trans diag alpha A B =
        indiv join
            inl C =
                inl dim =
                    inl f = function {T} -> {row=cols T; col=rows T} | T -> {row=rows T; col=cols T}
                    inl g T = match trans with .T -> {T} | .nT -> T
                    match side with
                    | .Left -> (f (g A)) .row, (f B) .col
                    | .Right -> (f B) .row, (f (g A)) .col
                s.CudaTensor.create {dim elem_type = A.elem_type}
            trmm' s side uplo trans diag alpha A B C
            stack C

    /// Triangular matrix solve. Overwrittes B with the result.
    met trsm' s side uplo trans diag alpha A B =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type B.elem_type float32) "B must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."

        inl assert_side A B =
            inl a_row, a_col = if isnT trans then rows A, cols A else cols A, rows A
            inl b_row, b_col = rows B, cols B
            assert (a_col = b_row) "Colums of A does not match rows of B in TRMM."

        match side with
        | .Left -> assert_side A B
        | .Right -> assert_side B A

        inl m = rows B
        inl n = cols B

        inl f = to int32
        call s .cublasStrsm_v2(opposite_side side, opposite_fill uplo, trans, diag, f n, f m, alpha, {ptr=A}, f (ld A), {ptr=B}, f (ld B))

    inl trsm s side uplo trans diag alpha A B =
        indiv join
            inl get_dims A B =
                inl a_row = if isnT trans then rows A else cols A
                inl b_col = cols B
                a_row, b_col

            inl B =
                inl dim =
                    match side with
                    | .Left -> get_dims A B
                    | .Right -> get_dims B A
                inl B = CudaAux.to_dev_tensor B
                s.CudaFun.init {dim} (inl a, b -> B a b .get)
            trsm' s side uplo trans diag alpha A B
            stack B

    /// The triangular matrix inverse
    met trinv' s uplo {factor inv_factor} = // The inv_factor gets overwritten.
        inl float = factor.elem_type
        s.CudaFun.map {out=inv_factor; mapi=inl (a, b) _ -> if a = b then to float 1 else to float 0} inv_factor
        trsm' s .Left uplo .nT .NonUnit (to float 1) factor inv_factor

    /// Symmetric matrix vector product.
    met symv' s uplo alpha A x beta y =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type x.elem_type float32) "x must be of type float32."
        assert (eq_type y.elem_type float32) "y must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."
        assert (eq_type beta float32) "beta must be of type float32."

        inl assert_1d x msg = match x.dim with x :: () -> () | _ -> error_type msg
        assert_1d x "x must be a vector"
        assert_1d y "y must be a vector"

        inl m, n = rows A, cols A
        assert (m = n) "A must be a square matrix."
        assert (m = x.span_outer) "The inner dimension of A must match the span of x."
        assert (m = y.span_outer) "The outer dimension of A must match the span of y."
        
        inl f = to int32
        call s .cublasSsymv_v2(opposite_fill uplo, f m, alpha, {ptr=A}, f (ld A), {ptr=x}, f (ld x), beta, {ptr=y}, f (ld y))

    inl symv s uplo alpha A x =
        indiv join
            inl dim = rows A
            inl y = s.CudaTensor.create {elem_type=x.elem_type; dim}
            symv' s uplo alpha A x (to alpha 0) y
            stack y

    /// The symmetric matrix multiply. Inplace version.
    met symm' s side uplo alpha A B beta C =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type B.elem_type float32) "B must be of type float32."
        assert (eq_type C.elem_type float32) "C must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."
        assert (eq_type beta float32) "beta must be of type float32."

        inl assert_side A B =
            assert (cols A = rows B) "Colums of A does not match rows of B in SYMM."
            assert (rows A = rows C && cols B = cols C) "Output matrix dimensions do not match in SYMM."

        match side with
        | .Left -> assert_side A B
        | .Right -> assert_side B A

        inl m = rows B
        inl n = cols B

        inl f = to int32
        call s .cublasSsymm_v2(opposite_side side, opposite_fill uplo, f n, f m, alpha, {ptr=A}, f (ld A), {ptr=B}, f (ld B), beta, {ptr=C}, f (ld C))

    inl symm s side uplo alpha A B =
        indiv join
            inl get_dims A B = rows A, cols B
            inl elem_type = A.elem_type

            inl C =
                inl dim =
                    match side with
                    | .Left -> get_dims A B
                    | .Right -> get_dims B A
                s.CudaTensor.create {dim elem_type}
            symm' s side uplo alpha A B (to elem_type 0) C
            stack C

    inl rc trans A = if isnT trans then rows A, cols A else cols A, rows A

    /// The matrix addition function.
    met geam' s transa transb alpha A beta B C =
        inl m,n as dim_c = rc .nT C
        assert (rc transa A = dim_c) "The dimensions of A and C must match."
        assert (rc transb B = dim_c) "The dimensions of B and C must match."

        inl f = to int32
        call s .cublasSgeam(transa, transb, f n, f m, alpha, {ptr=A}, f (ld A), beta, {ptr=B}, f (ld B), {ptr=C}, f (ld C))

    inl geam s transa transb alpha A beta B =
        indiv join
            inl C = s.CudaTensor.create {dim=rc transa A; elem_type = A.elem_type}
            geam' s transa transb alpha A beta B C
            stack C

    inl transpose s A = geam s .T .T 1f32 A 0f32 A

    /// Symmetric rank one update.
    met syr' s uplo alpha x A =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type x.elem_type float32) "x must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."

        inl assert_1d x msg = match x.dim with x :: () -> () | _ -> error_type msg
        assert_1d x "x must be a vector"

        inl m, n = rows A, cols A
        assert (m = n) "A must be a square matrix."
        assert (m = x.span_outer) "The inner dimension of A must match the span of x."
        
        inl f = to int32
        call s .cublasSsyr_v2(opposite_fill uplo, f m, alpha, {ptr=x}, f (ld x), {ptr=A}, f (ld A))

    inl syr s uplo alpha x =
        indiv join
            inl dim = x.span_outer
            inl A = s.CudaTensor.create {elem_type=x.elem_type; dim=dim,dim}
            syr' s uplo alpha x A
            stack A

    /// The symmetric rank-k update
    met syrk' s uplo trans alpha A beta C =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type C.elem_type float32) "C must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."
        assert (eq_type beta float32) "beta must be of type float32."

        inl m = if isnT trans then rows A else cols A
        inl k = if isnT trans then cols A else rows A

        assert (m = rows C && m = cols C) "The rows and columns of C must match."

        if (rows A = 1 || cols A = 1) && beta = to beta 1 then
            syr' s uplo alpha (A.reshape (inl a,b -> a+b-1)) C
        else
            inl f = to int32
            call s .cublasSsyrk_v2(opposite_fill uplo, opposite_operation trans, f m, f k, alpha, {ptr=A}, f (ld A), beta, {ptr=C}, f (ld C))

    inl syrk s uplo trans alpha A =
        indiv join
            inl m = if isnT trans then rows A else cols A
            inl C = s.CudaTensor.create {dim=m,m; elem_type = A.elem_type}
            syrk' s uplo trans alpha A (to alpha 0) C
            stack C

    /// General matrix vector product
    met gemv' s trans alpha A x beta y =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type x.elem_type float32) "x must be of type float32."
        assert (eq_type y.elem_type float32) "y must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."
        assert (eq_type beta float32) "beta must be of type float32."

        inl assert_1d x msg = match x.dim with x :: () -> () | _ -> error_type msg
        assert_1d x "x must be a vector"
        assert_1d y "y must be a vector"

        inl m, n = rows A, cols A

        inl dim_a, dim_b = if isT trans then cols A, rows A else rows A, cols A
        assert (dim_b = x.span_outer) "The inner dimension of A must match the span of x."
        assert (dim_a = y.span_outer) "The outer dimension of A must match the span of y."
        
        inl f = to int32
        call s .cublasSgemv_v2(opposite_operation trans, f n, f m, alpha, {ptr=A}, f (ld A), {ptr=x}, f (ld x), beta, {ptr=y}, f (ld y))
        
    inl gemv s trans alpha A x =
        indiv join
            inl dim = if isT trans then cols A else rows A
            inl y = s.CudaTensor.create {elem_type=x.elem_type; dim}
            gemv' s trans alpha A x (to alpha 0) y
            stack y

    met gemm_template mode s transa transb alpha A B beta C =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type B.elem_type float32) "B must be of type float32."
        assert (eq_type C.elem_type float32) "C must be of type float32."
        match mode with
        | .dev_ptr ->
            assert (eq_type alpha.elem_type float32) "alpha must be of type float32."
            assert (eq_type beta.elem_type float32) "beta must be of type float32."
        | .host_ptr ->
            assert (eq_type alpha float32) "alpha must be of type float32."
            assert (eq_type beta float32) "beta must be of type float32."

        inl a_col = if isnT transa then cols A else rows A
        inl b_row = if isnT transb then rows B else cols B
        assert (a_col = b_row) "Colums of A does not match rows of B in GEMM."

        inl m = if isnT transa then rows A else cols A
        inl n = if isnT transb then cols B else rows B
        inl k = a_col
        
        assert (m = rows C && n = cols C) "Output matrix dimensions do not match in GEMM."

        // The arguments are switched in order to convert from column major (which CuBlas uses) to row major (which Spiral's tensors use)
        // TODO: Adapt it for other float types.
        inl f = to int32
        match mode with
        | .dev_ptr ->
            mode_dev_ptr s
            call s .cublasSgemm_v2(transb, transa, f n, f m, f k, {ptr=alpha}, {ptr=B}, f (ld B), {ptr=A}, f (ld A), {ptr=beta}, {ptr=C}, f (ld C))
            mode_host_ptr s
        | .host_ptr ->
            call s .cublasSgemm_v2(transb, transa, f n, f m, f k, alpha, {ptr=B}, f (ld B), {ptr=A}, f (ld A), beta, {ptr=C}, f (ld C))

    /// General matrix-matrix multiply from cuBLAS. Inplace version
    inl gemm' = gemm_template .host_ptr
    inl gemm_dev_ptr' = gemm_template .dev_ptr

    inl gemm s transa transb alpha A B =
        indiv join
            inl m = if isnT transa then rows A else cols A
            inl n = if isnT transb then cols B else rows B

            inl C = s.CudaTensor.create {dim=m,n; elem_type = A.elem_type}
            gemm' s transa transb alpha A B (to alpha 0) C
            stack C

    /// Note: matinv will raise an invalid value exception if the matrix passed into it is greater than 32.

    /// cuda -> 2d float32 cuda_tensor array -> 2d float32 cuda_tensor array -> 1d int32 cuda_tensor -> unit
    met matinv_batched_array' s A Ainv info =
        inl batch_size = array_length A
        assert (eq_type A.elem_type.elem_type float32) "The A tensor must be of type float32."
        assert (eq_type Ainv.elem_type.elem_type float32) "The Ainv tensor must be of type float32."
        assert (eq_type info.elem_type int32) "The info tensor must be of type int32."
        assert (batch_size > 0) "A, Ainv and info must have at least one element."
        assert (batch_size = array_length Ainv) "A and Ainv arrays must have the same size."
        assert (batch_size = info.span_outer) "A and info arrays must have the same size."
        inl n_size x =
            inl assert_dim x =
                match x.dim with
                | a, b -> 
                    assert (a = b) "The tensor must be a square matrix."
                    a, ld x
                | _ -> error_type "The tensor must have two dimensions."

            inl n, size = assert_dim (x 0)

            if lit_is size && lit_is n then ()
            else 
                Loops.for {from=1; near_to=batch_size; body=inl {i} ->
                    inl n', size' = assert_dim (x i)
                    assert (n = n') "The spans of all the tensors in the array must match."
                    assert (size = size') "The leading dimensions of all the tensors in the array must match."
                    }
                
            n, size

        inl n,lda = n_size A
        inl n',lda_inv = n_size Ainv

        assert (n = n') "The two arrays must have tensors of equal dimension."
                
        // TODO: Adapt it for other float types.
        inl f = to int32
        call s .cublasSmatinvBatched (f n,{ptr_ar=A},f lda,{ptr_ar=Ainv},f lda_inv,{ptr=info},f batch_size)

    /// cuda -> int64 -> 1d uint64 tensor -> int64 -> 1d uint64 tensor -> int64 -> 1d int32 cuda_tensor -> unit
    met matinv_batched' s n A lda Ainv lda_inv info =
        assert (eq_type A.elem_type uint64) "The A tensor must be of type uint64."
        assert (eq_type Ainv.elem_type uint64) "The Ainv tensor must be of type uint64."
        assert (eq_type info.elem_type int32) "The info tensor must be of type int32."

        inl a :: () = A.dim
        inl b :: () = Ainv.dim
        inl c :: () = info.dim

        inl batch_size = a
        assert (batch_size = b) "Ainv must be equal to batch size."
        assert (batch_size = c) "info must be equal to batch size."

        // TODO: Adapt it for other float types.
        inl f = to int32
        call s .cublasSmatinvBatched (f n,{ptr=A},f lda,{ptr=Ainv},f lda_inv,{ptr=info},f batch_size)

    /// Inverts the matrices of the (3d cuda_tensor | 2d cuda_tensor array) A.
    inl matinv_batched s A ret =
        indiv join
            match A with
            | @array_is _ ->
                inl batch_size = array_length A
                inl Ainv = Array.map (stack << s.CudaTensor.create_like) A
                inl info = s.CudaTensor.create {elem_type=int32; dim=batch_size}
                matinv_batched_array' s A Ainv info
                (Ainv, info) |> ret |> stack
            | _ ->
                inl batch_size, n =
                    match A.dim with
                    | a,b,c ->  
                        inl n = b
                        assert (n = c) "The (sub)matrix needs to be square."
                        a, n
                    | _ -> error_type "The tensor A needs to be 3d."

                inl ld x = 
                    inl x = x 0
                    assert_contiguous x
                    ld x

                assert (eq_type A.elem_type float32) "Only float32 matrices can be inverted for now."
                inl lda = ld A
                inl Ainv = s.CudaTensor.create_like A
                inl lda_inv = ld Ainv
                inl info = s.CudaTensor.create {elem_type=int32; dim=batch_size}
                inl _ =
                    inl A, Ainv = s.CudaFun.tensor_to_pointers (A, Ainv)
                    matinv_batched' s n A lda Ainv lda_inv info
                (Ainv, info) |> ret |> stack

    inl matinv_batched_asserted s A = 
        matinv_batched s A (inl Ainv, info ->
            inl r = s.CudaFun.redo {redo=max; neutral_elem=0i32} info 0
            assert (s.CudaTensor.get r = 0i32) "The matrix inversion failed."
            Ainv
            )

    inl rows x = x.dim |> inl _,a,b -> a
    inl cols x = x.dim |> inl _,a,b -> b
    inl ld x = match unconst x.bodies .size with stride,ld,_ -> ld 
    inl stride x = match unconst x.bodies .size with stride,ld,_ -> stride

    met gemm_strided_batched' s transa transb alpha A B beta C =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type B.elem_type float32) "B must be of type float32."
        assert (eq_type C.elem_type float32) "C must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."
        assert (eq_type beta float32) "beta must be of type float32."
        inl batch_size = A.span_outer
        assert (batch_size = B.span_outer) "A and B must have the same outer span."
        assert (batch_size = C.span_outer) "A and C must have the same outer span."

        inl a_col = if isnT transa then cols A else rows A
        inl b_row = if isnT transb then rows B else cols B
        assert (a_col = b_row) "Colums of a does not match rows of b in GEMMStridedBatched."

        inl m = if isnT transa then rows A else cols A
        inl n = if isnT transb then cols B else rows B
        inl k = a_col
        
        assert (m = rows C && n = cols C) "Output matrix dimensions do not match in GEMMStridedBatched."

        // The arguments are switched in order to convert from column major (which CuBlas uses) to row major (which Spiral's tensors use)
        // TODO: Adapt it for other float types.
        inl f = to int32
        call s .cublasSgemmStridedBatched(transb, transa, f n, f m, f k, alpha, {ptr=B}, f (ld B), stride B, {ptr=A}, f (ld A), stride A, beta, {ptr=C}, f (ld C), stride C, f batch_size)

    inl gemm_strided_batched s transa transb alpha A B =
        indiv join
            inl m = if isnT transa then rows A else cols A
            inl n = if isnT transb then cols B else rows B

            inl C = s.CudaTensor.create {dim=A.span_outer,m,n; elem_type = A.elem_type}
            gemm_strided_batched' s transa transb alpha A B (to alpha 0) C
            stack C

    inl modules =
        {
        trmm' trmm trsm' trsm trinv' symm' symm geam' geam transpose gemm' gemm matinv_batched matinv_batched_asserted 
        gemm_strided_batched' gemm_strided_batched syrk' syrk gemv' gemv symv' symv syr' syr trmv' trmv
        gemm_dev_ptr'
        }

    ret <| s.module_add .CudaBlas modules
    """
    }

let cuda_kernel: SpiralModule =
    {
    name="CudaKernel"
    prerequisites=[cuda_tensor]
    opens=[]
    description="The Cuda kernels module."
    code=
    """
open Tensor
open Extern

inl span = function {from near_to} -> near_to - from | by -> by
inl length = Liple.foldl (inl s x -> s * span x) 1
inl index_example dim = Tuple.map (inl _ -> var 0) (Tuple.wrap dim) |> Tuple.unwrap

/// These two loops are only here until NVidia gets its shit together and fixes the NVCC tuple local write bugs for tail recursive loops.
inl whilecd {cond state body} =
    inl r = Tensor.create {
        array_create=array_create_cuda_local 
        elem_type=state 
        dim=()
        }
    r .set state
    /// Note: While must have a join point around it.
    !While((join cond r.get), (r.set <| body r.get))
    r .get

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
        body = inl {from state} -> {state=body {state i=from}; from=from+by}
        } .state
    |> finally

inl divup a b = (a-1)/b+1 // Integer division with rounding up. (a+b-1)/b is another variant on this.

inl index_to_tuple d i =
    Tuple.foldr (inl x (l,i) -> 
        inl span, from = match x with {from near_to} -> near_to - from, from | x -> x, 0
        (i % span + from) :: l, i / span
        ) d ((),i)
    |> fst

inl grid_for_template {iteration_mode} {blockDim gridDim} axis dim =
    inl dim, index_convert =
        match dim with
        | {from near_to} -> dim, id
        | _ :: _ -> {from=0; near_to=length dim}, index_to_tuple dim
        | near_to : int64 -> {from=0; near_to}, id

    inl from = threadIdx axis + blockDim axis * blockIdx axis + dim.from
    inl by = gridDim axis * blockDim axis
    inl near_to = dim.near_to

    inl lit_is = Struct.foldl (inl s x -> s && lit_is x) true (by,dim)
    inl can_be_eliminated = lit_is && by = span dim

    if can_be_eliminated then
        match iteration_mode with
        | .items_per_thread {d with body} -> 
            inl span = span dim
            body {d without body with span num_valid=span; item=0; i=index_convert from}
        | .std {d with body} -> body {d without body with i = index_convert from}
        | .state_loading {d with body state} -> 
            state (index_convert from) 
            |> match d with {finally} -> finally | _ -> id // The return here must be unit
            () 
    else
        match iteration_mode with
        | .items_per_thread {d with body} ->
            inl span = span dim
            inl items_per_thread = divup span by
            forcd {d with from=0; near_to=items_per_thread; body=inl {state i=item} ->
                inl i = from + by * item
                inl num_valid = span - by * item
                if i < near_to then body {span num_valid item state i=index_convert i} else state
                }
        | .std d -> forcd {d with from by near_to body=inl d -> self {d with i = index_convert self}}
        | .state_loading {d with state} ->
            assert (by < span dim) "The step size must be less than the dimension size."
            forcd {d with from=from+by; state=state (index_convert from); by near_to 
                body=inl d -> self {d with i = index_convert self}
                }

inl grid_for_items = grid_for_template {iteration_mode=.items_per_thread}
inl grid_for = grid_for_template {iteration_mode=.std}
inl grid_for_state_loading = grid_for_template {iteration_mode=.state_loading}

inl warp_size = 32
inl syncthreads () = macro.cd () [text: "__syncthreads()"]

inl cub_block_reduce {d with blockDim redo} x =
    inl ty = 
        match x with
        | @array_is _ -> x.elem_type
        | _ -> type x

    inl algorithm =
        match d with
        | {algorithm} -> algorithm
        | _ -> "BLOCK_REDUCE_WARP_REDUCTIONS"

    inl block_redo = [
        text: "cub::BlockReduce"
        iter: "<",",",">",[type: ty; arg: blockDim.x; text: string_format "cub::{0}" algorithm; arg: blockDim.y; arg: blockDim.z]
        args: ()
        ]

    inl call =
        if eq_type (+) redo then 
            [
            text: ".Sum"
            args:
                match d with
                | {num_valid} -> x,num_valid
                | _ -> x
            ]
        else
            [
            text: ".Reduce"
            args: 
                inl clo = closure_of (inl a,b -> redo a b) ((ty,ty) => ty)
                match d with
                | {num_valid} -> x,clo,num_valid
                | _ -> x,clo
            ]

    macro.cd ty (Tuple.append block_redo call)

inl cub_block_scan {scan_type is_input_tensor return_aggregate} {d with blockDim redo} in =
    inl out, ty = 
        if is_input_tensor then 
            inl elem_type = in.elem_type
            Tensor.create {
                array_create = array_create_cuda_local
                elem_type dim=in.dim
                }, elem_type
        else array_create_cuda_local in 1 0, type in

    inl ag = if return_aggregate then array_create_cuda_local ty 1 0 else ()
    inl algorithm =
        match d with
        | {algorithm} -> algorithm
        | _ -> "BLOCK_SCAN_RAKING_MEMOIZE"

    inl block_scan =
        [
        text: "cub::BlockScan"
        iter: "<",",",">",[type: ty; arg: blockDim.x; text: string_format "cub::{0}" algorithm; arg: blockDim.y; arg: blockDim.z]
        args: ()
        ]

    inl call =
        inl in, out = if is_input_tensor then unconst in.bodies .ar, unconst out.bodies .ar else in, out

        inl exclusive_scan initial_elem =
            [
            text: ".ExclusiveScan"
            args: 
                inl clo = closure_of (inl a,b -> redo a b) ((ty,ty) => ty)
                if return_aggregate then in,out,initial_elem,clo,ag else in,out,initial_elem,clo
            ]

        if eq_type (+) redo then 
            match scan_type with
            | .inclusive ->
                [
                text: ".InclusiveSum"
                args: if return_aggregate then in,out,ag else in,out
                ]
            | .exclusive, initial_elem ->
                // This is because the exclusive sum does not accept an initial element.
                // The Cub author picked such an uncomfortable place to do this kind of thing in the API.
                exclusive_scan initial_elem 
        else
            match scan_type with
            | .inclusive ->
                [
                text: ".InclusiveScan"
                args: 
                    inl clo = closure_of (inl a,b -> redo a b) ((ty,ty) => ty)
                    if return_aggregate then in,out,clo,ag else in,out,clo
                ]
            | .exclusive, initial_elem ->
                exclusive_scan initial_elem

    macro.cd () (Tuple.append block_scan call)

    if return_aggregate then 
        inl ag =
            match scan_type with
            | .inclusive -> ag
            | .exclusive, initial_elem -> redo initial_elem ag // For some reason, Cub does not do this on its own.
        out, ag 
    else out

inl cub_warp_reduce redo x =
    macro.cd x [
        text: "cub::WarpReduce"
        types: x
        args: ()
        text: ".Reduce"
        args: x, closure_of (inl a,b -> redo a b) ((x,x) => x)
        ]

inl broadcast_zero x =
    inl ar = array_create_cuda_shared x 1
    if threadIdx.x = 0 then ar 0 <- x
    syncthreads()
    ar 0

inl to_dev_tensor = CudaAux.to_dev_tensor
inl temporary = CudaAux.temporary

met iter w {d with dim} f =
    inl l = length dim
    inl blockDim = lit_min l <| match d with {threads} -> threads | _ -> 32
    inl gridDim = divup l blockDim
    w.run {blockDim gridDim // Lexical scoping rocks.
        kernel = cuda grid_for {blockDim gridDim} .x dim {body=inl {i} -> f i}
        }

inl segmented_iter w {d with dim} f = iter w {d with dim=View.span self} (inl i -> View.from_basic dim i (View.dim_merge >> f))

/// The exclusive scan over the innermost dimension.
met iter_exscan w {dim=b,a redo neutral_elem init outit} =
    w.run {
        blockDim = {x = lit_min 1024 (length a)}
        gridDim = {y = min 256 (length b)}
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y b {body=inl {i} ->
                inl in, out = init i, outit i

                grid_for .x a {state=dyn neutral_elem; body=inl {state=prefix i} ->
                    inl in, out = in i, out i
                    inl state, prefix = cub_block_scan {scan_type=.exclusive,prefix; is_input_tensor=false; return_aggregate=true} {blockDim redo} in
                    out state
                    prefix
                    } |> ignore
                }
        }

/// Inclusive scan.
/// Note: Not fully optimized.
met inscan w {dim redo neutral_elem init outit} =
    inl l = length dim
    inl blockDim = lit_min 1024 l
    inl gridDim = divup l blockDim

    inb prefix = w.CudaTensor.create {elem_type=type init (index_example dim); dim=gridDim} |> temporary
    inl prefix = to_dev_tensor prefix

    // First perform the reduction to get the aggregates.
    w.run {
        blockDim gridDim
        kernel = cuda
            grid_for_items {blockDim gridDim} .x dim {body=inl {num_valid item i} ->
                inl x = init i |> cub_block_reduce {num_valid blockDim redo}
                if threadIdx.x = 0 then prefix item .set x
                }
        }

    // Scan the aggregates to get the prefixes.
    iter_exscan w {dim=1,gridDim; redo neutral_elem
        init = inl a b -> prefix b .get
        outit = inl a b -> prefix b .set
        }

    // The actual scan.
    w.run {
        blockDim gridDim
        kernel = cuda
            grid_for_items {blockDim gridDim} .x dim {body=inl {num_valid item i} ->
                init i
                |> cub_block_scan
                    {scan_type=.inclusive; return_aggregate=false; is_input_tensor=false}
                    {blockDim redo}
                |> redo (prefix item .get)
                |> outit i
                }
        }

met redo w {redo dim init outit} =
    inl run {dim blockDim gridDim init outit} =
        w.run {
            blockDim gridDim
            kernel = cuda 
                grid_for_state_loading {blockDim gridDim} .x dim {
                    state=init
                    body=inl {state i} -> redo state (init i) 
                    finally=
                        cub_block_reduce {blockDim redo}
                        >> inl x -> if threadIdx.x = 0 then outit blockIdx.x x
                    }

            }

    inl l = length dim
    inl blockDim = lit_min l 1024
    inl gridDim = min 128 (divup l blockDim) - 1 |> max 1

    if gridDim = 1 then
        run {dim blockDim gridDim init outit}
    else
        inb temp = w.CudaTensor.create {elem_type=type init (index_example dim); dim=gridDim} |> temporary
        inl temp = to_dev_tensor temp
        run {blockDim gridDim dim init outit=inl i -> temp i .set}
        run {outit blockDim=gridDim; gridDim=1; dim=temp.dim; init=inl i -> temp i .get}

met iter2 w {d with dim=b,a} f =
    inl l = length a
    inl blockDim = lit_min l <| match d with {threads} -> threads | _ -> 32
    w.run {blockDim 
        gridDim={x=divup l blockDim; y=min 256 (length b)}
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y b {body=inl {i} ->
                inl f = f i
                grid_for .x a {body=inl {i} -> f i}
                }
        }

met iter3 w {d with dim=c,b,a} f =
    inl l = length a
    inl blockDim = lit_min l <| match d with {threads} -> threads | _ -> 32
    w.run {blockDim 
        gridDim={x=divup l blockDim; y=min 256 (length b); z=min 256 (length c)}
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim} 
            grid_for .z c {body=inl {i} ->
                inl f = f i
                grid_for .y b {body=inl {i} ->
                    inl f = f i
                    grid_for .x a {body=inl {i} -> f i}
                    }
                }
        }

/// The inclusive scan over the innermost dimension.
met iter_inscan w {d with redo neutral_elem dim=b,a init outit} =
    w.run {
        blockDim = lit_min 1024 (length a)
        gridDim = {y=min 256 (length b)}
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y b {body=inl {i} ->
                inl in, out = init i, outit i

                grid_for .x a {state=dyn neutral_elem; body=inl {state=prefix i} ->
                    inl in, out = in i, out i
                    inl state', ag = 
                        cub_block_scan
                            {scan_type=.inclusive; is_input_tensor=false; return_aggregate=true}
                            {blockDim redo} in
                    out (redo prefix state')
                    redo prefix ag
                    } |> ignore
                }
        }

met iter_redo w {dim=b,a init redo outit} =
    w.run {
        blockDim = lit_min 1024 (length a)
        gridDim = {y = min 256 (length b)}
        kernel = cuda 
            grid_for {blockDim gridDim} .y b {body=inl {i} ->
                inl init = init i
                grid_for_state_loading {blockDim gridDim} .x a { 
                    state=init
                    body=inl {state i=j} -> redo state (init j)
                    finally=
                        cub_block_reduce {blockDim redo}
                        >> inl x -> if threadIdx.x = 0 then outit i x
                    }
                }
        }

inl block_reduce_body ar near_to threadIdx redo state =
    whilecd {
        state={near_to state}
        cond=inl {near_to} -> near_to >= 2
        body=inl {near_to state} ->
            inl by = near_to/2 // It might be worth trying `max 1 (near_to/3)`
            if threadIdx < near_to && threadIdx >= by then ar threadIdx .set state
            syncthreads()

            {
            near_to=by
            state=
                if threadIdx < by then
                    forcd {from=threadIdx + by; by near_to state 
                        body=inl {state i} -> redo state (ar i .get)
                        }
                else
                    state
            }
        }
    |> inl {state} -> state

inl block_reduce_template dim ar (near_to, threadIdx) redo state =
    if near_to > 1 then
        inl ar = 
            Tensor.create {
                array_create=array_create_cuda_shared
                elem_type=state
                dim=Liple.map length dim
                }
            |> ViewR.wrap dim
            |> ar

        block_reduce_body ar near_to threadIdx redo state
    else
        state

/// Only to be used with the other blockDims held to a single dimension. 
/// If the rest are not held to 1 then this algorithm will cause errors.
inl block_reduce_1d (near_to, threadIdxX as x) =
    block_reduce_template {from=1; near_to} id x
        
/// The third dimension should be held to 1 similarly to the 1d case.
/// Does a block reduction in a transposed manner.
inl block_reduce_2dt (blockDimY, threadIdxY) (near_to, threadIdxX as x) =
    block_reduce_template 
        ({from=1; near_to}, blockDimY) 
        (inl ar i -> ar i threadIdxY)
        x

/// The third dimension should be held to 1 similarly to the 1d case.
inl block_reduce_2d (blockDimY, threadIdxY) (near_to, threadIdxX as x) =
    block_reduce_template 
        (blockDimY, {from=1; near_to}) 
        (inl ar -> ar threadIdxY)
        x

/// Reduces only one of the dimensions of a block.
inl block_reduce_3d (blockDimZ, threadIdxZ) (blockDimY, threadIdxY) (near_to, threadIdxX as x) =
    block_reduce_template
        (blockDimZ, blockDimY, {from=1; near_to})
        (inl ar -> ar threadIdxZ threadIdxY)
        x

/// Maps the input and then reduces twice, first along the inner dimension and then along the middle.
met iter_redo_redo w {dim=c,b,a init} = 
    inl x = lit_min 1024 (length a)
    inl y = lit_min (1024 / x) (length b)
    w.run {
        blockDim={y x}
        gridDim={z=min 64 (length c)}
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .z c {body=inl {i} ->
                init i <| inl {neutral_elem redo init outit} ->
                    inl x = 
                        grid_for .y b {state=dyn neutral_elem; body=inl {state i} ->
                            init i <| inl {neutral_elem redo init} ->
                                grid_for .x a {state=dyn neutral_elem; body=inl {state i} -> redo state (init i)}
                                |> block_reduce_2d (blockDim.y, threadIdx.y) (blockDim.x, threadIdx.x) redo
                            |> redo state
                            }
                    if threadIdx.x = 0 then
                        inl x = block_reduce_1d (blockDim.y, threadIdx.y) redo x
                        if threadIdx.y = 0 then outit x
                    }
        }

/// Does arbitrary operations over the innermost dimension using registers.
met iter_seq w {dim=b,a} f =
    inl num_valid = length a
    inl items_per_thread, blockDim =
        assert (lit_is num_valid) "The inner dimension of the input to this kernel must be known at compile time."
        if num_valid <= 1024 then 1, num_valid
        else divup num_valid 1024, 1024

    inl body {dims with blockDim gridDim} =
        inl grid_for = grid_for dims
        inl grid_for_items = grid_for_items dims
        inl inner_loop = grid_for_items .x a
        inl create_items map = 
            inl items = Tensor.create {
                array_create = array_create_cuda_local
                layout=.aot
                elem_type=type map {item=var 0; i=var 0}
                dim=items_per_thread
                }

            inner_loop {body=inl {x with item i} -> items item .set (map x)}
            items

        inl block_reduce redo = 
            inl d = {blockDim redo}
            if num_valid % blockDim.x = 0 then cub_block_reduce d
            else cub_block_reduce {d with num_valid} 

        inl thread = {
            redo = inl {redo num_valid} -> cub_block_reduce {blockDim redo num_valid}
            inscan = inl redo -> cub_block_scan {scan_type=.inclusive; is_input_tensor=false; return_aggregate=true} {blockDim redo}
            exscan = inl {prefix redo} -> cub_block_scan {scan_type=.exclusive,prefix; is_input_tensor=false; return_aggregate=true} {blockDim redo}
            }

        inl block = {
            iter=inl body -> inner_loop {body}
            init=inl f -> create_items f
            load=inl (!zip tns) -> create_items (inl {i} -> tns i .get)
            store=inl {from=(!zip from) to=(!zip to)} -> inner_loop {body=inl {item i} -> to i .set (from item .get)}
            add_store=inl {from=(!zip from) to=(!zip to)} -> inner_loop {body=inl {item i} -> to i .set (to i .get + from item .get)}
            store_scalar=inl {from to} -> if threadIdx.x = 0 then to .set from
            add_store_scalar=inl {from to} -> if threadIdx.x = 0 then to .set (to .get + from)
            map=inl f (!zip tns) -> create_items (inl {item} -> f (tns item .get))
            uter=inl redo items -> block_reduce redo (unconst items.bodies .ar) |> broadcast_zero
            redo=inl redo items -> block_reduce redo (unconst items.bodies .ar)
            }

        inl grid = {
            for=grid_for
            for_items=grid_for_items
            }

        inl seq_module = {grid block thread dim=b,a}
        
        grid_for .y b {body=inl {i=b} -> f b seq_module }

    w.run {
        blockDim
        gridDim={y=min 256 (length b)}
        kernel = cuda body {blockDim gridDim}
        }

// The inclusive scan over the outermost dimension.
// Note that dimension are iterated in reverse order and hence the arguments are passed as such into `init` as well.
// The first argument to init is the inner dimension and then the outer. `outit` is iterated over the inner dimension.
met inscan_iter w {dim=b,a init outit redo neutral_elem} =
    inl length = {b=length b; a=length a}
    inl x = lit_min warp_size length.a
    inl y = lit_min (1024 / x) length.b
    inl blockDim = {x y}
    inl x = min 256 (divup length.a x)
    inl gridDim = {x}

    w.run {blockDim gridDim
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .x a {body=inl {i} -> 
                inl init,outit = init i, outit i
                grid_for .y b {state=dyn neutral_elem; body=inl {state=prefix i} -> 
                    inl state = init i

                    inl state, prefix = // block inclusive transposed scan
                        inl near_to = blockDim.y
                        if near_to > 1 then
                            inl from = 1
                            inl to = near_to - from

                            inl ar = 
                                Tensor.create {
                                    array_create=array_create_cuda_shared
                                    elem_type=state
                                    dim=to, blockDim.x
                                    }
                                |> inl ar i -> ar i threadIdx.x

                            inl {state} =
                                whilecd {
                                    state={from state}
                                    cond=inl {from} -> from < near_to
                                    body=inl {from state} ->
                                        if threadIdx.y < near_to - from then ar threadIdx.y .set state
                                        syncthreads()
                                        inl d = {from=from*2; state}
                                        if threadIdx.y >= from then { d with state = redo self (ar (threadIdx.y-from) .get) }
                                        else d
                                    }
                            inl state = redo prefix state
                            if threadIdx.y = to then ar 0 .set state
                            syncthreads()
                            state, ar 0 .get
                        else
                            inl x = redo prefix state
                            x, x

                    outit state
                    prefix
                    } |> ignore
                }
        }

// Does a reduction based on data from the init function and pipes it into the outit function.
// Note that dimension are iterated in reverse order and hence the arguments are passed as such into `init` as well.
// The first argument to init is the inner dimension and then the outer. `outit` is iterated over the inner dimension.
met redo_iter w {dim=b, a init redo outit} =
    inl length = {b=length b; a=length a}
    inl x = lit_min warp_size length.a
    inl y = lit_min (1024 / x) length.b
    inl blockDim = {x y}
    inl x = min 256 (divup length.a x)
    inl gridDim = {x}

    w.run {blockDim gridDim
        kernel = cuda
            grid_for {blockDim gridDim} .x a {body=inl {i} ->
                inl init = init i
                inl finally result = outit i result

                if blockDim.y > 1 then
                    grid_for_state_loading {blockDim gridDim} .y b {
                        state=init
                        body=inl {state i=j} -> redo state (init j)
                        finally=
                            block_reduce_2dt (blockDim.x,threadIdx.x) (blockDim.y, threadIdx.y) redo
                            >> inl result -> if threadIdx.y = 0 then finally result
                        }
                else 
                    finally (init 0)
            }
        }

inl methods =
    {
    iter segmented_iter iter_exscan inscan redo iter2 iter3 iter_inscan iter_redo iter_redo_redo
    iter_seq inscan_iter redo_iter
    } |> stackify

inl s -> s.module_add .CudaKernel methods
    """
    }

let cuda_fun: SpiralModule =
    {
    name="CudaFun"
    prerequisites=[host_tensor; cuda_tensor]
    opens=[]
    description="The CudaFun module."
    code=
    """
open Tensor
inl to_dev_tensor = CudaAux.to_dev_tensor

inl index_example dim = Tuple.map (inl _ -> var 0) (Tuple.wrap dim) |> Tuple.unwrap

inl init w {d with dim} f =
    indiv join
        inl elem_type = type f (index_example dim)
        inl out =            
            match d with
            | {out} -> 
                inl out=zip out
                assert (dim = out.dim) "The input and the output must have the same dimensions."
                out
            | _ -> w.CudaTensor.create {dim elem_type}
        inl _ =
            inl out = to_dev_tensor out |> zip
            w.CudaKernel.iter d (inl i -> out i .set (f i))
        match d with
        | {out} -> ()
        | _ -> stack out

inl init_seq w {d with dim} f =
    indiv join
        inl out =            
            match d with
            | {out} -> 
                inl out=zip out
                assert (dim = out.dim) "The input and the output must have the same dimensions."
                out
            | _ -> 
                inl elem_type = 
                    type_catch w.CudaKernel.iter_seq d <| inl b k -> 
                        Struct.map' (inl x -> x.elem_type) (f b k)
                        |> type_raise
                w.CudaTensor.create {dim elem_type}
        inl _ =
            inl out = to_dev_tensor out |> zip
            w.CudaKernel.iter_seq d <| inl b k -> k.block.store {from=f b k; to=out b}
        match d with
        | {out} -> ()
        | _ -> stack out

inl map w d in =
    indiv join
        inl map = match d with {map} -> const map | {mapi} -> mapi
        inl in = zip in
        inl dim = in.dim
        inl out = 
            match d with
            | {out} -> 
                inl out=zip out
                assert (dim = out.dim) "The input and the output must have the same dimensions."
                out
            | _ -> 
                inl elem_type = type map (index_example dim) in.elem_type
                w.CudaTensor.create {dim elem_type}
        inl _ =
            inl in, out = to_dev_tensor (in, out)
            w.CudaKernel.iter {dim} <| inl i -> out i .set (map i (in i .get))
        match d with
        | {out} -> ()
        | _ -> stack out

inl rec view_map map i = 
    match i, map with
    | {}, {} ->
        inl {c k x} = module_foldr (inl k x s -> {s with k x c=self+1}) i {c=0}
        assert (c = 1) "The number of branches in i must be 1."
        view_map (map k) (i k)
    | _ ->
        map i

inl segmented_init w d init =
    indiv join
        inl init = view_map init
        inl dim = d.dim
        inl out = 
            match d with
            | {out} -> 
                assert (dim = out.dim) "The input and the output must have the same dimensions."
                out
            | _ -> 
                inl elem_type = d.elem_type // TODO: Replace the explicit argument with inference.
                w.CudaTensor.create_view {dim elem_type}
        inl _ =
            inl out = to_dev_tensor out
            w.CudaKernel.segmented_iter {dim} <| inl i -> 
                out .view i .set (init i)
        match d with
        | {out} -> ()
        | _ -> stack out

inl assert_dim = CudaAux.assert_dim

inl map_map w d in =
    indiv join
        inl map = match d with {map} -> (inl _ _ -> map) | {mapi} -> mapi
        inl in = module_map (inl _ x -> zip x) in
        inl b,a as dim = 
            match in with
            | {in} -> in.dim
            | {in_inner in_outer} -> Tuple.unwrap in_outer.dim, Tuple.unwrap in_inner.dim

        assert_dim in {
            in=b,a
            in_outer=b
            in_inner=a
            in_scalar={from=0; near_to=1}
            }

        inl out = 
            match d with
            | {out} -> 
                inl out=zip out
                assert (dim = out.dim) "The input and the output must have the same dimensions."
                out
            | _ -> w.CudaTensor.create {dim elem_type=type map (index_example b) (index_example a) (module_map (inl _ x -> x.elem_type) in)}
        inl index k i ins = Struct.foldl (inl ins k -> if module_has_member k ins then {ins with $k=self i} else ins) ins k
        inl ins = {in with out}
        inl _ =
            inl ins = to_dev_tensor ins
            w.CudaKernel.iter2 {dim} <| inl i ->
                inl map = map i
                inl ins = 
                    index .in_scalar 0 ins
                    |> index .in_scalar .get
                    |> index (.in, .in_outer, .out) i
                    |> index .in_outer .get
                inl i ->
                    inl map = map i
                    inl ins = index (.in, .in_inner, .out) i ins
                    ins.out.set (map <| index (.in, .in_inner, .out) .get ins)
        match d with
        | {out} -> ()
        | _ -> stack out

// Note that the dimension get passed in reverse order into `map`. The kernel iterates over the inner and then over the outer dimension.
inl redo_map w d in =
    indiv join
        inl {redo} = d
        inl map = match d with {map} -> (inl _ _ -> map) | {mapi} -> mapi
        inl in = match d with {in_inner} -> {in=zip in; in_inner=zip in_inner} | _ -> {in=zip in}
        inl in = match d with {in_outer} -> {in with in_outer=zip in_outer} | _ -> in
        inl in = match d with {mid} -> {in with mid=zip mid} | _ -> in
        inl b,a as dim = in.in.dim

        assert_dim in {
            in_inner=a
            mid=a
            in_outer=b
            }

        inl map_out = match d with {map_out} -> (inl _ -> map_out) | {mapi_out} -> mapi_out | _ -> (inl _ {out} -> out)
        inl out = 
            match d with
            | {out} -> 
                inl out=zip out
                inl a' :: () = out.dim
                assert (a = a') "The input and the output must have the same dimensions."
                out
            | _ -> 
                w.CudaTensor.create {dim=a;
                    elem_type=type 
                        inl in = module_map (inl _ x -> x.elem_type) in
                        inl out = map (index_example a) (index_example b) in
                        match in with {mid} -> {mid out} | _ -> {out}
                        |> map_out (index_example a)
                        }
        inl _ =
            inl in, out = to_dev_tensor (in, out)
            w.CudaKernel.redo_iter {
                dim redo
                init=inl a -> 
                    inl in = {in without mid}
                    inl map = map a
                    inl in =
                        {in with in=inl b -> self b a}
                        |> function {in_inner} as in -> {in with in_inner=self a .get} | in -> in
                    inl b ->
                        inl map = map b
                        inl in =
                            {in with in=self b .get}
                            |> function {in_outer} as in -> {in with in_outer=self b .get} | in -> in
                        map in
                outit=inl a -> 
                    inl o = out a
                    inl out ->
                        inl x = {out}
                        match in with {mid} -> {x with mid=mid a .get} | _ -> x
                        |> map_out a |> o .set
                }
        match d with
        | {out} -> ()
        | _ -> stack out

inl redo w d in =
    indiv join
        inl {redo} = d
        inl map = match d with {map} -> (inl _ -> map) | {mapi} -> mapi | _ -> (inl _ -> id)
        inl map_out = match d with {map_out} -> map_out | _ -> id
        inl in = zip in
        inl dim = in.dim
        inl out = 
            match d with
            | {out} -> 
                inl out=zip out
                inl 1 :: () = out.dim
                out
            | _ -> w.CudaTensor.create {dim=1; elem_type=type map (index_example dim) in.elem_type |> map_out}
        inl _ =
            inl in, out = to_dev_tensor (in, out)
            w.CudaKernel.redo {
                redo dim
                init=inl i -> map i (in i .get)
                outit=inl i x -> out i .set (map_out x)
                }
        match d with
        | {out} -> ()
        | _ -> stack out

inl map_redo w d in =
    indiv join
        inl {redo} = d
        inl map = match d with {map} -> (inl _ _ -> map) | {mapi} -> mapi
        inl in = match d with {in_inner} -> {in=zip in; in_inner=zip in_inner} | _ -> {in=zip in}
        inl in = match d with {in_outer} -> {in with in_outer=zip in_outer} | _ -> in
        inl in = match d with {mid} -> {in with mid=zip mid} | _ -> in
        inl b,a as dim = in.in.dim

        assert_dim in { 
            in_inner=a
            mid=b
            in_outer=b
            }

        inl map_out = match d with {map_out} -> (inl _ -> map_out) | {mapi_out} -> mapi_out | _ -> (inl _ {out} -> out)
        inl out = 
            match d with
            | {out} -> 
                inl out=zip out
                inl b' :: () = out.dim
                assert (b = b') "The input and the output must have the same dimensions."
                out
            | _ -> 
                w.CudaTensor.create {dim=b;
                    elem_type=type 
                        inl in = module_map (inl _ x -> x.elem_type) in
                        inl out = map (index_example b) (index_example a) in
                        match in with {mid} -> {mid out} | _ -> {out}
                        |> map_out (index_example b)
                        }
        inl _ =
            inl in, out = to_dev_tensor (in, out)
            w.CudaKernel.iter_redo {
                dim redo
                init=inl b -> 
                    inl map = map b
                    inl in =
                        {in with in=self b}
                        |> function {in_outer} as in -> {in with in_outer=self b .get} | in -> in
                    inl a ->
                        inl map = map a
                        inl in =
                            {in with in=self a .get}
                            |> function {in_inner} as in -> {in with in_inner=self a .get} | in -> in
                        map in
                outit=inl b -> 
                    inl o = out b
                    inl out ->
                        inl x = {out}
                        match in with {mid} -> {x with mid=mid b .get} | _ -> x
                        |> map_out b |> o .set
                }
        match d with
        | {out} -> ()
        | _ -> stack out

inl address_at o =
    inl {ar offset} = unconst o.bodies
    macro.cd uint64 [text: "(unsigned long long) ("; arg: ar; text: " + "; arg: offset; text: ")"]

/// Turns the outermost dimension of the tensor(s) into tensor of pointers to the inner ones.
/// They are represented as uint64.
/// All the tensors passed as input must have the same outer dimension.
inl tensor_to_pointers w x =
    indiv join
        inl dim =
            Struct.foldl (inl s x ->
                match s with
                | () -> x.span_outer
                | _ -> assert (s = x.span_outer) "All the tensors passed as input must have the same outer dimension."; s
                ) () x
        inl a = Struct.map (inl x -> w.CudaTensor.create {elem_type=uint64; dim}) x
        inl _ = 
            inl a,x = CudaAux.to_dev_tensor (a,x)
            w.CudaKernel.iter {dim} (inl i -> 
                Struct.iter2 (inl a x -> a i .set (address_at (x i))) a x
                )
        a

inl methods =
    {
    map init init_seq segmented_init map_map redo_map redo map_redo
    tensor_to_pointers
    } |> stackify

inl s -> s.module_add .CudaFun methods
    """
    }

let cuda_solve: SpiralModule =
    {
    name="CudaSolve"
    prerequisites=[extern_]
    opens=[]
    description="The CudaSolve module."
    code=
    """
inl s ret ->
    open Extern

    inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
    inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
    inl SizeT = FS.Constructor SizeT_type
    inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT

    inl dense_native_type = fs [text: "ManagedCuda.CudaSolve.CudaSolveNativeMethods.Dense"]
    inl status_type = fs [text: "ManagedCuda.CudaSolve.cusolverStatus"]

    inl assert_ok status = macro.fs () [text: "if "; arg: status; text: " <> ManagedCuda.CudaSolve.cusolverStatus.Success then raise <| new ManagedCuda.CudaSolve.CudaSolveException"; args: status]
    inl dense_handle =
        inl cusolver_type = fs [text: "ManagedCuda.CudaSolve.cusolverDnHandle"]
        FS.Constructor cusolver_type () |> ref
    FS.StaticMethod dense_native_type .cusolverDnCreate dense_handle status_type |> assert_ok
    inl s = s.data_add {cusolve_dense_handle=dense_handle}

    inl enum ty x = FS.StaticField ty x ty

    inl fill_mode_type = fs [text: "ManagedCuda.CudaBlas.FillMode"]
    inl to_fill_mode .Lower | .Upper as x = enum fill_mode_type x
    inl opposite_fill = function
        | .Lower -> .Upper
        | .Upper -> .Lower

    inl operation_type = fs [text: "ManagedCuda.CudaBlas.Operation"]
    inl to_operation = function
        | .T -> enum operation_type .Transpose
        | .nT -> enum operation_type .NonTranspose
    inl opposite_operation = function
        | .T -> .nT
        | .nT -> .T

    inl dense_call' handle method args =
        FS.StaticMethod dense_native_type method (handle :: args) status_type |> assert_ok    

    inl dense_call s method args =
        inl stream = s.data.stream
        inl handle = s.data.cusolve_dense_handle ()
        dense_call' handle .cusolverDnSetStream (stream.extract :: ())
        inl to_dev_tensor x = Tensor.assert_contiguous x; CudaAux.to_dev_tensor x

        inl args =
            inl strip ptr = 
                assert (Tuple.last (unconst ptr.bodies .size) = 1) "The stride of the innermost dimension should always be 1."
                unconst (to_dev_tensor ptr).bodies .ar
            Tuple.map (function
                | x : float64 | x : float32 -> ref x
                | {ptr} -> strip ptr |> CUdeviceptr
                | {ptr_ar} -> Array.map strip ptr_ar |> s.CudaTensor.from_cudadevptr_array
                | .Lower | .Upper as x -> to_fill_mode x
                | .nT | .T as x -> to_operation x
                | x -> x
                ) (Tuple.wrap args)
        dense_call' handle method args

    inl ld x = unconst x.bodies .size |> fst

    inl i32 = to int32

    /// For the CuSolve functions.
    inl handle_error s {d with info} =
        inl error_pos_msg = 
            match d with
            | {pos} -> pos
            | _ -> "Something went wrong with positive error %d."

        inl error_neg_msg =
            match d with
            | {neg} -> neg
            | _ -> "The %d-th parameter is wrong."
            
        inb info = CudaAux.temporary info
        inl info = CudaAux.to_dev_tensor info

        s.CudaKernel.iter {dim=1} <| inl _ ->
            inl msg x = macro.cd () [text: "printf"; args: x]
            inl info = info.get
            if info > 0i32 then msg "CuSolve function failed!\n"; msg (error_pos_msg, info); msg "\n"
            if info < 0i32 then msg "CuSolve function failed!\n"; msg (error_neg_msg, -info); msg "\n"
            macro.cd () [text: "int is_info_zero = "; arg: info = 0i32]
            macro.cd () [text: "assert(is_info_zero)"]

    /// The Cholesky decomposition.
    inl potrf' s uplo A =
        indiv join
            assert (eq_type A.elem_type float32) "The type of matrix A must be float32."
            inl n, n' = A.dim
            assert (n = n') "The matrix A must be square."
            inl lda = ld A
            inl Lwork = 
                inl Lwork = ref 0i32
                dense_call s .cusolverDnSpotrf_bufferSize(opposite_fill uplo, i32 n, {ptr=A}, i32 lda, Lwork)
                Lwork()
            inb workspace = s.CudaTensor.create {elem_type=float32; dim=to int64 Lwork} |> CudaAux.temporary
            inl dev_info = s.CudaTensor.create {elem_type=int32; dim=1}

            dense_call s .cusolverDnSpotrf(opposite_fill uplo, i32 n, {ptr=A}, i32 lda, {ptr=workspace}, Lwork, {ptr=dev_info})
            stack (dev_info 0)

    inl symm_map s f uplo = 
        inl body !(CudaAux.to_dev_tensor) {from to} =
            s.CudaKernel.iter {dim=from.dim} <| inl a, b as dim ->
                inl check = match uplo with .Lower -> a >= b | .Upper -> a <= b
                if check then to dim .set (f dim (from dim .get))

        function
        | {from to} ->  
            assert (from.dim = to.dim) "`to` and `from` must have the same dimensions."
            body {from to}
        | {from} -> 
            inl to = s.CudaTensor.create_like from
            body {from to}
            to

    inl symm_copy s = symm_map s (inl _ x -> x)

    inl potrf s uplo A =
        indiv join
            inl A = symm_copy s uplo {from=A}
            handle_error s { 
                info = potrf' s uplo A
                pos = "The leading minor of order %d is not positive definite."
                }

            stack A

    inl cholesky_body {factor inv_factor} = 
        s.CudaBlas.trinv' .Lower {factor inv_factor}
        s.CudaBlas.trmm' .Left .Lower .T .NonUnit 1f32 inv_factor inv_factor factor // `factor` becomes inverse covariance

    inl dampen epsilon b,a from =
        inl one, zero = to epsilon 1, to epsilon 0
        inl i = if b = a then one else zero
        epsilon * i + (one - epsilon) * from

    inl regularized_cholesky_inverse s {epsilon covariance precision sampling} = 
        symm_map s (dampen epsilon) .Lower {from=covariance; to=precision}
        handle_error s {
            info = potrf' s .Lower precision // Overwrites precision with covariance's factor
            pos = "The leading minor of order %d is not positive definite."
            }
        cholesky_body {factor=precision; inv_factor=sampling}

    /// The LU decomposition.
    inl getrf' s A =
        indiv join
            assert (eq_type A.elem_type float32) "The type of matrix A must be float32."
            inl n, m = A.dim
        
            inl lda = ld A
            inl Lwork = 
                inl Lwork = ref 0i32
                dense_call s .cusolverDnSgetrf_bufferSize(i32 n, i32 m, {ptr=A}, i32 lda, Lwork)
                Lwork()
            inb workspace = s.CudaTensor.create {elem_type=float32; dim=to int64 Lwork} |> CudaAux.temporary
            inl ipiv = s.CudaTensor.create {elem_type=int32; dim=min n m}
            inl info = s.CudaTensor.create {elem_type=int32; dim=1}

            dense_call s .cusolverDnSgetrf(i32 m, i32 n, {ptr=A}, i32 lda, {ptr=workspace}, {ptr=ipiv}, {ptr=info})
            stack {ipiv info=info 0}

    inl getrf s A =
        indiv join
            inl A = s.CudaTensor.copy {from=A}
            inl {ipiv info} = getrf' s A
            handle_error s { info pos = "U(x,x) = 0 where x = %d."}
            stack (A, ipiv)

    inl getrs' s trans A ipiv B =
        indiv join
            assert (eq_type A.elem_type float32) "The type of matrix A must be float32."
            assert (eq_type B.elem_type float32) "The type of matrix B must be float32."
            inl n, m = A.dim
            assert (n = m) "The matrix A must be square."

            inl n',nrhs = B.dim
            assert (n = n') "The two matrices must have the same outer dimension."

            inl info = s.CudaTensor.create {elem_type=int32; dim=1}
            dense_call s .cusolverDnSgetrs(trans, i32 n, i32 nrhs, {ptr=A}, i32 (ld A), {ptr=ipiv}, {ptr=B}, i32 (ld B), {ptr=info})
            stack (info 0)

    inl getrs s trans A ipiv B =
        indiv join
            inl B = s.CudaTensor.copy {from=B}
            handle_error s { info = getrs' s trans A ipiv B }
            B

    inl set_to_identity x =
        inl x = CudaAux.to_dev_tensor x
        inl to = to x.elem_type
        inl one, zero = to 1, to 0
        s.CudaKernel.iter {dim=x.dim} <| inl a, b -> 
            inl x = x a b
            if a = b then x .set one else x .set zero

    inl regularized_lu_inverse s {epsilon from to} =
        inb from = s.CudaFun.map {mapi=dampen epsilon} from |> CudaAux.temporary
        inl {ipiv info} = getrf' s from
        inb ipiv = CudaAux.temporary ipiv
        handle_error s { info pos = "U(x,x) = 0 where x = %d."}
        set_to_identity to
        handle_error s {info = s.CudaSolve.getrs' .nT from ipiv to}

    inl lu_inverse s ({from} | from as d) =
        inl A, ipiv = s.CudaSolve.getrf from
        inb ipiv = CudaAux.temporary ipiv
        match d with
        | {to} ->
            set_to_identity to
            handle_error s {info = s.CudaSolve.getrs' .nT A ipiv to}
        | _ ->
            inl to = s.CudaTensor.create_like from
            set_to_identity to
            handle_error s {info = s.CudaSolve.getrs' .nT A ipiv to}
            to
    
    {
    potrf' potrf getrf' getrf getrs' getrs regularized_cholesky_inverse regularized_lu_inverse lu_inverse
    }
    |> s.module_add .CudaSolve
    |> ret
    
    dense_call s .cusolverDnDestroy()
    """
    }

let cuda_modules: SpiralModule =
    {
    name="CudaModules"
    prerequisites=[cuda; allocator; region; cuda_stream; cuda_tensor; cuda_kernel; cuda_fun; cuda_random; cuda_blas; cuda_solve; console]
    opens=[]
    description="All the cuda modules in one."
    code=
    """
inl size ret ->
    inb s = Cuda
    inb s = Allocator s size
    inb s = CudaRandom s
    inb s = CudaBlas s
    inl s = Region s |> CudaStream |> CudaTensor |> CudaKernel |> CudaFun
    inb s = s.RegionMem.create'
    inb s = s.RegionStream.create'
    inl s = s.RegionStream.allocate
    inb s = CudaSolve s
    ret s
    """
    }
