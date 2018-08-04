[<AutoOpen>]
module Learning.Cuda.Lib

open Spiral.Types
open Spiral.Lib

let timer =
    (
    "Timer",[console],"The Timer module",
    """
inl stopwatch_ty = fs [text: "System.Diagnostics.Stopwatch"]
inl timespan_ty = fs [text: "System.TimeSpan"]
inl start_new _ = macro.fs stopwatch_ty [type: stopwatch_ty; text: ".StartNew()"]
inl elapsed x = macro.fs timespan_ty [arg: x; text: ".Elapsed"]
inl print_timespan = string_format
inl time_it msg f = 
    Console.printfn "Starting timing for: {0}" msg
    inl w = start_new ()
    inl r = f ()
    Console.printfn "The time was {0} for: {1}" (elapsed w, msg)
    r
{time_it} |> stackify
    """
    ) |> module_

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
            HostTensor.array_as_tensor ar
            |> HostTensor.split (const (images, rows * cols))
            |> HostTensor.map (inl x -> to float32 x / 255f32)
            
        | {file label_size} ->
            inl n, ar = load_mnist .label (combine (mnist_path, file))
            assert (label_size = n) "Mnist dimensions do not match the expected values."
            HostTensor.init (label_size, 10) (inl a ->
                inl x = ar a
                inl b -> if to uint8 b = x then 1.0f32 else 0.0f32
                )
        ) mnist_files

{load_mnist_tensors}
    """) |> module_

let resize_array =
    (
    "ResizeArray",[extern_; loops],"The resizable array module.",
    """
open Extern
inl create {d with elem_type} =
    inl x =
        inl ty = fs [text: "ResizeArray"; types: elem_type]
        match d with
        | {size} -> FS.Constructor ty (to int32 size)
        | _ -> FS.Constructor ty ()

    inl filter f = FS.Method x ."RemoveAll <| System.Predicate" (closure_of f (elem_type => bool)) int32 |> ignore
    inl sort f =
        inl comparison_type = fs [text: "System.Comparison"; types: elem_type]
        inl f = closure_of f (elem_type => elem_type => int32)
        inl c = FS.Constructor comparison_type f
        FS.Method x .Sort c ()

    inl index i = macro.fs elem_type [arg: x; text: ".["; arg: to int32 i; text: "]"]
    inl set i v = 
        assert (eq_type elem_type v) ("The type set to the ResizeArray must match its element type.", elem_type, v)
        macro.fs () [arg: x; text: ".["; arg: to int32 i; text: "] <- "; arg: v]
    inl clear () = FS.Method x .Clear() ()
    inl count () = FS.Method x .get_Count() int32
    inl add y = 
        assert (eq_type elem_type y) ("The type added to the ResizeArray must match its element type.", elem_type, y)
        FS.Method x .Add y ()
    inl remove_at y = FS.Method x .RemoveAt y ()

    inl iter f = Loops.for {from=0i32; near_to=count(); by=1i32; body=inl {i} -> f (index i)}
    inl to_array () = FS.Method x .ToArray() (array elem_type)

    function
    | .sort -> sort 
    | .filter -> filter 
    | .set -> set
    | .clear -> clear ()
    | .count -> count ()
    | .add -> add
    | .remove_at -> remove_at
    | .iter -> iter
    | .foldl f state -> Loops.for {from=0i32; by=1i32; near_to=count(); state body=inl {state i} -> f state (index i)}
    | .foldr f state -> Loops.for {from=count() - 1i32; by=-1i32; down_to=0i32; state body=inl {state i} -> f (index i) state}
    | .elem_type -> elem_type
    | .to_array -> to_array ()
    | .last ->  index (count()-1i32)
    | i -> index i
    |> stack
{ 
create
} |> stack
    """
    ) |> module_

let cuda_aux =
    (
    "CudaAux",[struct'],"The Cuda auxiliaries module.",
    """
inl ptr_cuda {ar offset} ret = ar.ptr() + to uint64 (offset * sizeof ar.elem_type) |> ret
inl rec to_dev_tensor x = 
    Struct.map (function
        | {block} as x -> 
            inl x = to_dev_tensor {x without block}
            {x with block}
        | x ->
            x.update_body (inl body -> 
                inb ptr = ptr_cuda body
                {body with ar=!UnsafeCoerceToArrayCudaGlobal(ptr,body.ar.elem_type); offset=0}
                )
        ) x
inl allocator_block_size = 256u64
inl temporary tns ret =
    inl x = ret tns
    Struct.iter (inl {ar} -> ar.ptr.Dispose) tns.bodies
    x

{ptr_cuda to_dev_tensor allocator_block_size temporary} |> stackify
    """
    ) |> module_

let allocator = 
    (
    "Allocator",[resize_array;loops;option;extern_;console;cuda_aux],"The section based GPU memory allocator module.",
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
    """) |> module_

let region =
    (
    "Region",[resize_array],"The region based resource tracker.",
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
    """) |> module_

let cuda_stream = 
    (
    "CudaStream",[extern_],"The Cuda stream module.",
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
    """) |> module_

let cuda_tensor = 
    (
    "CudaTensor",[extern_;host_tensor;cuda_aux],"The Cuda tensor module.",
    """
open HostTensor
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

inl get_elem s {src with size=()} = to_host_array s 1 src 0

met set_elem s (!dyn {dst with size=()}) (!dyn v) =
    inl ar = array_create v 1
    ar 0 <- v
    copy s 1 {dst with ptr_get=ptr_cuda} {ar size=(); offset=0; ptr_get=ptr_dotnet}

inl methods = 
    {
    create=inl s data -> create {data with array_create = array_create_cuda_global s}
    create_like=inl s tns -> s.CudaTensor.create {elem_type=tns.elem_type; dim=tns.dim}

    to_host_array from_host_array from_cudadevptr_array

    get=inl s tns ->
        match tns.unwrap with
        | {bodies dim=()} -> Struct.map (get_elem s) bodies
        | _ -> error_type "Cannot get from tensor whose dimensions have not been applied completely."

    set=inl s tns v ->
        match tns.unwrap with
        | {bodies dim=()} -> Struct.iter2 (set_elem s) bodies v
        | _ -> error_type "Cannot set to a tensor whose dimensions have not been applied completely."

    from_scalar = inl s -> HostTensor.from_scalar >> s.CudaTensor.from_host_tensor
    from_host_tensor=inl s -> transfer_template s.CudaTensor.from_host_array
    from_host_tensors=inl s -> Struct.map s.CudaTensor.from_host_tensor
    to_host_tensor=inl s -> transfer_template s.CudaTensor.to_host_array

    clear=inl s tns ->
        assert_contiguous tns
        inl span = tns.span_outer
        inl stream = s.data.stream.extract
        inl context = s.data.context
        tns.update_body <| inl {body with size ar} ->
            join
                inl size = match size with () -> 1 | x :: _ -> x
                FS.Method context .ClearMemoryAsync (CUdeviceptr (ar.ptr()), 0u8, size * span * sizeof ar.elem_type |> SizeT, stream) ()
        |> ignore

    copy' = inl s dst src ->
        assert_contiguous dst
        assert_contiguous src
        inl stream = s.data.stream.extract
        assert (eq_type dst.elem_type src.elem_type) "The two tensors must have the same type."
        assert (dst.dim = src.dim) "The two tensors must have the same dimensions."
        inl span = dst.span_outer
        Struct.iter2 (inl dst src ->
            inl size = match dst.size with () -> 1 | x :: _ -> x
            inl elem_type_size = sizeof dst.ar.elem_type
            inb dst = ptr_cuda dst
            inb src = ptr_cuda src
            memcpy_async dst src (span * size * elem_type_size) stream
            ) dst.bodies src.bodies

    copy = inl s src -> 
        inl dst = s.CudaTensor.create_like src
        s.CudaTensor.copy' dst src
        dst
    
    zero=inl s d -> indiv join s.CudaTensor.create d |> clear' s |> stack
    zero_like=inl s d -> indiv join s.CudaTensor.create_like d |> clear' s |> stack

    print=met s (!dyn x) -> 
        match x with
        | {cutoff input} -> HostTensor.print {cutoff input=s.CudaTensor.to_host_tensor (zip input)} 
        | x -> s.CudaTensor.to_host_tensor (zip x) |> HostTensor.print

    mmap=inl s f tns -> s.CudaKernel.map' (const f) tns.empty tns
    } |> stackify

inl s -> s.module_add .CudaTensor methods
    """) |> module_

let cuda_random =
    (
    "CudaRandom",[extern_;cuda_tensor],"The CudaRandom module.",
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
    
    open HostTensor
    
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

    ret <| s.module_add .CudaRandom {fill create}
    """) |> module_

let cuda_blas =
    (
    "CudaBlas",[cuda_tensor;extern_],"The CudaBlas module.",
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

    inl len = HostTensor.span
    inl rows x = x.dim |> inl a,b -> len a
    inl cols x = x.dim |> inl a,b -> len b
    inl ld x = x.bodies.size |> fst

    use cublas' =
        inl cublas_type = fs [text: "ManagedCuda.CudaBlas.CudaBlas"]
        inl pointer_mode_type = fs [text: "ManagedCuda.CudaBlas.PointerMode"]
        inl atomics_mode_type = fs [text: "ManagedCuda.CudaBlas.AtomicsMode"]
        FS.Constructor cublas_type (enum pointer_mode_type .Host, enum atomics_mode_type .Allowed)
    inl s = s.data_add {cublas=cublas'}

    open HostTensor
    
    inl call s method args = 
        inl cublas = s.data.cublas
        inl stream = s.data.stream
        inl to_dev_tensor x = assert_contiguous x; CudaAux.to_dev_tensor x
        inl handle = FS.Method cublas .get_CublasHandle() (fs [text: "ManagedCuda.CudaBlas.CudaBlasHandle"])
        FS.Method cublas .set_Stream stream.extract ()
        inl args = 
            inl strip ptr = 
                assert (Tuple.last ptr.bodies.size = 1) "The stride of the innermost dimension should always be 1."
                (to_dev_tensor ptr).bodies.ar
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
            inl x = s.CudaTensor.copy x
            trmv' s uplo trans diag A x
            stack x

    /// Triangular matrix-matrix multiply from cuBLAS. Inplace version
    met trmm' s side uplo trans diag alpha A B C =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type B.elem_type float32) "B must be of type float32."
        assert (eq_type C.elem_type float32) "C must be of type float32."
        assert (eq_type alpha float32) "alpha must be of type float32."

        inl assert_side A B =
            inl a_row, a_col = if isnT trans then rows A, cols A else cols A, rows A
            inl b_row, b_col = rows B, cols B
            assert (a_col = b_row) "Colums of A does not match rows of B in TRMM."
            assert (a_row = rows C && b_col = cols C) "Output matrix dimensions do not match in TRMM."

        match side with
        | .Left -> assert_side A B
        | .Right -> assert_side B A

        inl m = rows B
        inl n = cols B

        inl f = to int32
        call s .cublasStrmm_v2(opposite_side side, opposite_fill uplo, trans, diag, f n, f m, alpha, {ptr=A}, f (ld A), {ptr=B}, f (ld B), {ptr=C}, f (ld C))

    inl trmm s side uplo trans diag alpha A B =
        indiv join
            inl get_dims A B =
                inl a_row = if isnT trans then rows A else cols A
                inl b_col = cols B
                a_row, b_col

            inl C =
                inl dim =
                    match side with
                    | .Left -> get_dims A B
                    | .Right -> get_dims B A
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
                s.CudaKernel.init {dim} (inl a b -> B a b .get)
            trsm' s side uplo trans diag alpha A B
            stack B

    /// The triangular matrix inverse
    inl trinv s uplo A =
        indiv join
            inl float = A.elem_type
            inl B = s.CudaKernel.init {dim=A.dim} (inl a b -> if a = b then to float 1 else to float 0)
            trsm' s .Left uplo .nT .NonUnit (to float 1) A B
            stack B

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

    /// General matrix-matrix multiply from cuBLAS. Inplace version
    met gemm' s transa transb alpha A B beta C =
        assert (eq_type A.elem_type float32) "A must be of type float32."
        assert (eq_type B.elem_type float32) "B must be of type float32."
        assert (eq_type C.elem_type float32) "C must be of type float32."
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
        call s .cublasSgemm_v2(transb, transa, f n, f m, f k, alpha, {ptr=B}, f (ld B), {ptr=A}, f (ld A), beta, {ptr=C}, f (ld C))

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
                    inl a = len a
                    assert (a = len b) "The tensor must be a square matrix."
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

        inl batch_size = len a
        assert (batch_size = len b) "Ainv must be equal to batch size."
        assert (batch_size = len c) "info must be equal to batch size."

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
                        inl n = len b
                        assert (n = len c) "The (sub)matrix needs to be square."
                        len a, n
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
                    inl A, Ainv = s.CudaKernel.tensor_to_pointers (A, Ainv)
                    matinv_batched' s n A lda Ainv lda_inv info
                (Ainv, info) |> ret |> stack

    inl matinv_batched_asserted s A = 
        matinv_batched s A (inl Ainv, info ->
            inl r = s.CudaKernel.map_redo_map {redo=max; neutral_elem=0i32} info
            assert (s.CudaTensor.get r = 0i32) "The matrix inversion failed."
            Ainv
            )

    inl rows x = x.dim |> inl _,a,b -> len a
    inl cols x = x.dim |> inl _,a,b -> len b
    inl ld x = match x.bodies.size with stride,ld,_ -> ld 
    inl stride x = match x.bodies.size with stride,ld,_ -> stride

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
        trmm' trmm trsm' trsm trinv symm' symm geam' geam transpose gemm' gemm matinv_batched matinv_batched_asserted 
        gemm_strided_batched' gemm_strided_batched syrk' syrk gemv' gemv symv' symv syr' syr trmv' trmv
        }

    ret <| s.module_add .CudaBlas modules
    """) |> module_

let cuda_kernel =
    (
    "CudaKernel",[host_tensor;cuda_tensor],"The Cuda kernels module.",
    """
open HostTensor
open Extern

/// These two loops are only here until NVidia gets its shit together and fixes the NVCC tuple local write bugs for tail recursive loops.
inl whilecd {cond state body} =
    inl r = HostTensor.create {
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
inl s = span

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
        | _ :: _ -> {from=0; near_to=Tuple.foldl (inl a b -> a * s b) 1 dim}, index_to_tuple dim
        | near_to : int64 -> {from=0; near_to}, id

    inl from = threadIdx axis + blockDim axis * blockIdx axis + dim.from
    inl by = gridDim axis * blockDim axis
    inl near_to = dim.near_to

    match iteration_mode with
    | .items_per_thread {d with body} ->
        inl span = s dim
        inl items_per_thread = divup span by
        forcd {d with from=0;near_to=items_per_thread; body=inl {state i=item} ->
            inl i = from + by * item
            inl num_valid = span - by * item
            if i < near_to then body {span num_valid item state i=index_convert i} else state
            }
    | .std d -> forcd {d with from by near_to body=inl d -> self {d with i = index_convert self}}

inl grid_for_items = grid_for_template {iteration_mode=.items_per_thread}
inl grid_for = grid_for_template {iteration_mode=.std}
    
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
            HostTensor.create {
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
        inl in, out = if is_input_tensor then in.bodies.ar, out.bodies.ar else in, out

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

met map' w f in out = 
    inl in, out = zip in, zip out
    assert (in.dim = out.dim) "The input and output dimensions must be equal."
    inl in = flatten in |> to_dev_tensor
    inl out = flatten out |> to_dev_tensor
    inl in_a :: () = in.dim
    
    inl blockDim = 128
    inl gridDim = min 64 (divup (s in_a) blockDim)

    w.run {
        blockDim gridDim
        kernel = cuda // Lexical scoping rocks.
            grid_for {blockDim gridDim} .x in_a {body=inl {i} ->
                inl out = out i
                inl in = in i
                out .set (f in.get out.get)
                }
        }

inl map w f in =
    indiv join
        inl in = zip in
        inl out = w.CudaTensor.create {dim=in.dim; elem_type=type f in.elem_type}
        map' w (inl in _ -> f in) in out
        stack out

/// The exclusive scan over the innermost dimension.
/// Accepts the optional map_in and map_out arguments for the mapping before the scan and after it.
met map_d1_exscan_map' w {d with redo neutral_elem} in out =
    inl in, out = zip in, zip out
    inl dim_in_a, dim_in_b = in.dim
    assert (in.dim = out.dim) "The input and the output dimensions need to be equal"

    inl blockDim = lit_min 1024 (s dim_in_b)
    inl gridDimY = lit_min 64 (s dim_in_a)

    inl in = to_dev_tensor in
    inl out = to_dev_tensor out

    inl map_in = match d with {map_in} -> map_in | _ -> id
    inl map_out = match d with {map_out} -> map_out | _ -> const

    w.run {
        blockDim
        gridDim = 1, gridDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y dim_in_a {body=inl {i} ->
                inl in, out = in i, out i

                grid_for .x dim_in_b {state=dyn neutral_elem; body=inl {state=prefix i} ->
                    inl in, out = in i, out i
                    inl state, prefix = 
                        cub_block_scan {scan_type=.exclusive,prefix; is_input_tensor=false; return_aggregate=true}
                            {blockDim redo} (map_in in.get)
                    out.set (map_out state out.get)
                    prefix
                    } |> ignore
                }
        }

/// Inclusive scan over the entire tensor.
met map_inscan_map' w {d with redo neutral_elem} in out =
    inl in, out = zip in, zip out
    assert (in.dim = out.dim) "The input and output dimensions must be equal."
    inl in = flatten in |> to_dev_tensor
    inl out = flatten out |> to_dev_tensor
    inl in_a :: () = in.dim

    inl near_to = s in_a
    inl blockDim = lit_min 1024 near_to
    inl num_blocks = divup near_to blockDim
    inl gridDim = lit_min 64 num_blocks

    inl map_in = match d with {map_in} -> map_in | _ -> id
    inl map_out = match d with {map_out} -> map_out | _ -> const

    /// TODO: Optimize the case where the size of temp is just 1.
    inl temp = w.CudaTensor.create {elem_type=type map_in in.elem_type; dim=1,num_blocks}

    inl _ = // First perform the reduction to get the aggregates.
        inl temp = to_dev_tensor (temp 0)
        w.run {
            blockDim gridDim
            kernel = cuda
                grid_for_items {blockDim gridDim} .x in_a {body=inl {num_valid item i} ->
                    inl temp = temp item
                    inl x = in i .get |> map_in |> cub_block_reduce {num_valid blockDim redo}
                    if threadIdx.x = 0 then temp .set x
                    }
            }

    // Scan the aggregates to get the prefixes.
    w.CudaKernel.map_d1_exscan_map' {redo neutral_elem} temp temp

    // The actual scan.
    inl temp = to_dev_tensor (temp 0)
    w.run {
        blockDim gridDim
        kernel = cuda
            grid_for_items {blockDim gridDim} .x in_a {body=inl {num_valid item i} ->
                inl prefix, out = temp item .get, out i
                in i .get 
                |> map_in
                |> cub_block_scan
                    {scan_type=.inclusive; return_aggregate=false; is_input_tensor=false}
                    {blockDim redo}
                |> redo prefix
                |> inl x -> out .set (map_out x out.get)
                }
        }

/// Zips, flattens the tensor to 1d, maps, reduces it and maps it.
/// Map is optional. Allocates a temporary tensor for the intermediary results.
inl map_redo_map w {d with redo neutral_elem} in =
    indiv join
        inl run {map_out map_in blockDim gridDim} (!to_dev_tensor in) =
            inl in_a :: () = in.dim
            inl out = w.CudaTensor.create {elem_type=type map_in in.elem_type |> map_out; dim=gridDim}
            inl out' = to_dev_tensor out

            w.run {
                blockDim gridDim
                kernel = cuda 
                    inl x = 
                        grid_for {blockDim gridDim} .x in_a {state=dyn neutral_elem; body=inl {state i} -> redo state (map_in (in i .get)) }
                        |> cub_block_reduce {blockDim redo} |> map_out
                    if threadIdx.x = 0 then out' blockIdx.x .set x
                }

            out

        inl in = zip in |> flatten
        inl map_in = match d with {map_in} -> map_in | _ -> id
        inl map_out = match d with {map_out} -> map_out | _ -> id

        inl in_a :: () = in.dim
        inl span = s in_a
        inl blockDim = lit_min span 1024
        inl gridDim = lit_min 64 (divup span blockDim)

        inl r = 
            if gridDim = 1 then
                run {map_out map_in blockDim gridDim} in
            else
                run {map_out=id; map_in blockDim gridDim} in
                |> run {map_out map_in=id; blockDim=gridDim; gridDim=1}
        r 0 |> stack
        

/// Replicates the 1d `in` and maps it along the outer dimension as determined by `in'`.
met d2_replicate_map' w f in in' out =
    inl in, in', out = zip in, zip in', zip out
    inl dim_in :: () = in.dim
    inl dim_in'_a, dim_in'_b = in'.dim

    assert (dim_in = dim_in'_b) "Input's dimension must equal the second input's inner dimension."
    assert (in'.dim = out.dim) "Second input must have the same dimension as the output."

    inl blockDimX = min warp_size (s dim_in)
    inl blockDimY = min 32 (s dim_in'_a)
    inl gridDim = min 64 (divup (s dim_in) blockDimX)

    inl in = to_dev_tensor in
    inl in' = to_dev_tensor in'
    inl out = to_dev_tensor out

    w.run {
        gridDim
        blockDim=blockDimX,blockDimY
        kernel = cuda 
            inl grid_for = grid_for {gridDim blockDim}
            grid_for .x dim_in'_b {body=inl {i} ->
                inl in = in i .get
                inl in' j = in' j i
                inl out j = out j i
                grid_for .y dim_in'_a {body=inl {i} ->
                    inl in', out = in' i, out i
                    out.set (f in in'.get out.get)
                    }
                }
        }

inl d2_replicate_map w f in in' =
    indiv join 
        inl in = zip in
        inl in' =
            match in' with
            | by : int64 -> 
                inl dim_in :: () = in.dim
                HostTensor.create {elem_type=(); dim=by,dim_in}
            | in' -> zip in'
        inl out = w.CudaTensor.create {elem_type=type f in.elem_type in'.elem_type; dim=in'.dim}
        d2_replicate_map' w (inl a b _ -> f a b) in in' out
        stack out

/// The inclusive scan over the innermost dimension.
/// Accepts the optional map_in and map_out arguments for the mapping before the scan and after it.
met map_d1_inscan_map' w {d with redo neutral_elem} in out =
    inl in, out = zip in, zip out
    inl dim_in_a, dim_in_b = in.dim
    assert (in.dim = out.dim) "The input and the output dimensions need to be equal"

    inl blockDim = lit_min 1024 (s dim_in_b)
    inl gridDimY = lit_min 64 (s dim_in_a)

    inl in = to_dev_tensor in
    inl out = to_dev_tensor out

    inl map_in = match d with {map_in} -> map_in | _ -> id
    inl map_out = match d with {map_out} -> map_out | _ -> const

    w.run {
        blockDim
        gridDim = 1, gridDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y dim_in_a {body=inl {i} ->
                inl in, out = in i, out i

                grid_for .x dim_in_b {state=dyn neutral_elem; body=inl {state=prefix i} ->
                    inl in, out = in i, out i
                    inl state', ag = 
                        cub_block_scan
                            {scan_type=.inclusive; is_input_tensor=false; return_aggregate=true}
                            {blockDim redo} (map_in in.get)
                    out.set (map_out (redo prefix state') out.get)
                    redo prefix ag
                    } |> ignore
                }
        }

met init_d1_redo_outit' w {dim=outer,inner init redo neutral_elem outit} =
    inl span = Tuple.foldl (inl a b -> a * s b) 1 << Tuple.wrap
    inl span_outer, span_inner = Tuple.map span (outer,inner)

    inl blockDimX = lit_min 1024 span_inner
    inl gridDimX = 1

    inl blockDimY = 1
    inl gridDimY = lit_min 64 span_outer

    w.run {
        blockDim=blockDimX,blockDimY
        gridDim=gridDimX,gridDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y outer {body=inl {i} ->
                inl init = init i

                inl x =
                    grid_for .x inner {state=dyn neutral_elem; body=inl {state i=j} -> redo state (init j) }
                    |> cub_block_reduce {blockDim redo}

                if threadIdx.x = 0 then outit i x
                }
        }

inl init_d1_redo_outit w {d with dim init redo neutral_elem} =
    indiv join
        inl outer, inner = dim
        inl f = function
            | _ :: _ as x -> Tuple.map (const (dyn 0)) x
            | x -> dyn 0
        inl elem_type = type init (f outer) (f inner)
        inl out = w.CudaTensor.create {elem_type dim=outer}

        inl outit =
            inl out = to_dev_tensor out
            inl outit = match d with {outit} -> outit | _ -> id
            inl i x -> 
                inl out = Tuple.foldl (inl out i -> out i) out (Tuple.wrap i)
                out .set (outit x)
        init_d1_redo_outit' w {dim init redo neutral_elem outit}
        stack out

/// Maps the two inputs and then reduces the first's inner dimension.
met mapi_d1_redo_map' w {d with redo neutral_elem} in in' out = 
    inl in = zip in
    inl dim_in_a, dim_in_b as dim = in.dim
    inl in' =
        match in' with
        | () -> HostTensor.create {dim=dim_in_a; elem_type=()}
        | x -> zip in'
    inl out = zip out
    
    inl dim_in' :: () = in'.dim

    assert (dim_in' = dim_in_a) "Input's outer dimension must equal the output's dimension."
    assert (in'.dim = out.dim) "Input and output's dimensions must be equal."

    inl in, in', out = to_dev_tensor (in, in', out)
    inl init =
        match d with
        | {map_in} ->
            inl i ->
                inl in, in' = in i, in' i .get
                inl j -> map_in (in j .get) in'
        | {mapi_in} ->
            inl i ->
                inl in, in' = in i, in' i .get
                inl mapi_in = mapi_in i
                inl j -> mapi_in j (in j .get) in'
        | _ ->
            match in' with
            | () ->
                inl i ->
                    inl in = in i
                    inl j -> in j .get
            | _ -> error_type "The redo is missing the map_in argument."

    inl outit =
        match d with
        | {map_out} -> inl i x -> 
            inl out = out i
            out .set (map_out x out.get)
        | {mapi_out} -> inl i x -> 
            inl out = out i
            out .set (mapi_out i x out.get)
        | _ -> inl i x -> out i .set x

    init_d1_redo_outit' w {dim init redo neutral_elem outit}

inl ddef def_map_out =
    function
    | {d with map_out} -> d
    | d -> {d with map_out=def_map_out}
    >> function
    | {d.redo_mid with mapi_in} -> d
    | {d.redo_mid with map_in} -> {d.redo_mid without map_in with mapi_in=inl _ _ -> map_in}
    | {d with redo_mid} -> {d.redo_mid with mapi_in=inl _ _ x -> x}
    >> function
    | {d.redo_in with mapi_in} -> d
    | {d.redo_in with map_in} -> {d.redo_in without map_in with mapi_in=inl _ _ _ -> map_in}
    | {d with redo_in} -> {d.redo_in with mapi_in=inl _ _ _ x -> x}        


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
            HostTensor.create {
                array_create=array_create_cuda_shared
                elem_type=state
                dim
                }
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

/// Maps the input and then reduces twice, first along the inner dimension and then along the middle. Takes 3d tensors.
met mapi_d1_dredo_map' w d in out = 
    inl {d with redo_mid redo_in map_out} = ddef const d
    inl in, out = zip in, zip out
    inl dim_in_a, dim_in_b, dim_in_c = in.dim
    inl out_a :: () = out.dim

    assert (dim_in_a = out_a) "Input's outermost and output's dimension must be equal."

    inl blockDimX = lit_min 1024 (s dim_in_c)
    inl blockDimY = lit_min (1024 / blockDimX) (s dim_in_b)
    inl gridDimZ = lit_min 64 (s dim_in_a)

    inl in, out = to_dev_tensor in, to_dev_tensor out
        
    w.run {
        blockDim=blockDimX,blockDimY
        gridDim=1,1,gridDimZ
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .z dim_in_a {body=inl {i} ->
                inl {mapi_in redo neutral_elem} = redo_mid
                inl x = 
                    inl in = in i
                    grid_for .y dim_in_b {state=dyn neutral_elem; body=inl {state i=j} ->
                        inl x = 
                            inl in = in j
                            inl {d with redo neutral_elem mapi_in} = redo_in
                            grid_for .x dim_in_c {state=dyn neutral_elem; body=inl {state i=k} ->
                                inl in = in k .get
                                redo state (mapi_in i j k in)
                                }
                            |> block_reduce_2d (blockDim.y,threadIdx.y) (blockDim.x, threadIdx.x) redo
                        redo state (mapi_in i j x)
                        }

                if threadIdx.x = 0 then
                    inl x = block_reduce_1d (blockDim.y, threadIdx.y) redo x
                    if threadIdx.y = 0 then
                        inl out = out i
                        out.set (map_out x out.get)
                }
        }

inl mapi_d1_dredo_map w d in =
    indiv join
        inl d = ddef id d
        inl in = zip in

        inl {redo_in redo_mid map_out} = d
        inl elem_type = 
            type 
                redo_in.mapi_in (dyn 0) (dyn 0) (dyn 0) in.elem_type
                |> redo_mid.mapi_in (dyn 0) (dyn 0)
                |> map_out
        inl out = w.CudaTensor.create {elem_type dim=fst in.dim}
        mapi_d1_dredo_map' w {d with map_out = inl a _ -> map_out a} in out
        stack out

/// Does a (repeating) sequence of maps, reductions and maps in registers.
met init_d1_seq_broadcast w {d with seq init} (dim_a, dim_b) = 
    inl num_valid = s dim_b
    inl items_per_thread, blockDim =
        assert (lit_is num_valid) "The inner dimension of the input to this kernel must be known at compile time."
        if num_valid <= 1024 then 1, num_valid
        else divup num_valid 256, 256
    inl gridDimY = min 64 (s dim_a)

    w.run {
        blockDim
        gridDim=1,gridDimY
        kernel = cuda
            inl dims = {blockDim gridDim}
            inl inner_loop = grid_for_items dims .x dim_b
            inl create_items map = 
                inl items = HostTensor.create {
                    array_create = array_create_cuda_local
                    layout=.aot
                    elem_type=type map {item=dyn 0; i=dyn 0}
                    dim=items_per_thread
                    }

                inner_loop {body=inl {x with item i} -> items item .set (map x)}
                items

            grid_for dims .y dim_a {body=inl {i=j} ->
                inl body n items d =
                    inl items =
                        match d with
                        | {init} ->
                            inl map = match n with () -> init j | _ -> init n j
                            create_items <| inl {item i} -> map i (items item .get)
                        | _ -> items
                    match d with
                    | {mapi_in} ->
                        inl map = match n with () -> mapi j | _ -> mapi_in n j
                        create_items <| inl {item i} -> map i (items item .get)
                    | {map_in=map} -> create_items <| inl {item i} -> map (items item .get)
                    | _ -> items
                    |> inl items -> 
                        inl items = items.bodies.ar
                        inl block_reduce redo = 
                            inl d = {blockDim redo}
                            if num_valid % blockDim.x = 0 then cub_block_reduce d
                            else cub_block_reduce {d with num_valid} 
                        match d with
                        | {redo} -> block_reduce redo items |> broadcast_zero
                        | {redo'} -> block_reduce redo' items
                        | _ -> items
                    |> inl x ->
                        inl body map {item i} = map i (items item .get) x
                        match d with
                        | {mapi_out} -> 
                            inl map = match n with () -> mapi_out j | _ -> mapi_out n j
                            create_items (body map)
                        | {map_out} -> 
                            inl map = const map_out
                            create_items (body map)
                        | () -> items

                inl items = 
                    inl init = init j
                    create_items <| inl {item i} -> init i

                inl items =
                    Tuple.foldl (inl items d ->
                        match d with
                        | {from near_to} -> 
                            forcd {from near_to body=inl {i} ->
                                inl items' = body i items d
                                inner_loop {body=inl {item} -> items item .set (items' item .get)}
                                }
                            items
                        | _ -> body () items d
                        ) items (Tuple.wrap seq)
                match d with
                | {outit} -> 
                    inl outit = outit j
                    inner_loop {body=inl {x with item i} -> outit i (items item .get)}
                | _ -> type
                    match items.elem_type with
                    | () -> ()
                    | _ -> error_type "The elem type of the last operation in the sequence must be unit."
                }
        }

inl ddef fout in out = 
    function
    | {d with mapi_in} -> {d without mapi_in with init = inl j i -> mapi_in j i (in j i .get)}
    | {d with map_in} -> {d without map_in with init = inl j i -> map_in (in j i .get)}
    | d -> {d with init = inl j i -> in j i .get}
    >> function
    | {d with seq} ->
        inl f = function
            | {from near_to mapi_out} as x -> {x with mapi_out = inl n j i a b -> 
                inl out = out j i
                fout (mapi_out n j i) a b out.get
                }
            | {mapi_out} as x -> {x with mapi_out = inl j i a b -> 
                inl out = out j i
                fout (mapi_out j i) a b out.get
                }
            | {from near_to map_out} as x -> {x without map_out with mapi_out = inl n j i a b -> 
                inl out = out j i
                fout map_out a b out.get
                }
            | {map_out} as x -> {x without map_out with mapi_out = inl j i a b -> 
                inl out = out j i
                fout map_out a b out.get
                }
            | x -> x
        {d with seq = Tuple.map_last f (Tuple.wrap seq)}
    >> function
        | {mapi_out} as x -> {x without mapi_out with outit=inl j i a -> out j i .set (mapi_out j i a)}
        | {map_out} as x -> {x without map_out with outit=inl j i a -> out j i .set (map_out a)}
        | x -> {x with outit=inl j i a -> out j i .set a}

// Repeatedly reduces along the inner dimension and then maps the result of that reductions over the input in the previous step.
met mapi_d1_seq_broadcast' w {d with seq} in out = 
    inl in, out = zip in, zip out
    assert (in.dim = out.dim) "The input and the output dimensions need to be equal"

    inl in = to_dev_tensor in
    inl out = to_dev_tensor out

    init_d1_seq_broadcast w (ddef (inl f a b c -> f a b c) in out d) in.dim

inl mapi_d1_seq_broadcast w {d with seq} in =
    indiv join
        inl in = zip in
        inl seq = Tuple.wrap seq
        inl elem_type = type
            inl ty =
                match d with
                | {map_in} -> map_in in.elem_type
                | {mapi_in} -> mapi_in (dyn 0) (dyn 0) in.elem_type
                | _ -> in.elem_type
            inl ty =
                Tuple.foldl (inl ty d -> 
                    inl ty =
                        match d with
                        | {from near_to init} -> init (dyn 0) (dyn 0) (dyn 0) ty
                        | {init} -> init (dyn 0) (dyn 0) ty
                        | _ -> ty
                    inl ty' = 
                        match d with
                        | {map_in} -> map_in ty
                        | {from near_to mapi_in} -> mapi_in (dyn 0) (dyn 0) (dyn 0) ty
                        | {mapi_in} -> mapi_in (dyn 0) (dyn 0) ty
                        | _ -> ty
                    match d with
                    | {map_out} -> map_out ty ty'
                    | {from near_to mapi_out} -> map_out (dyn 0) (dyn 0) (dyn 0) ty ty'
                    | {mapi_out} -> map_out (dyn 0) (dyn 0) ty ty'
                    | _ -> ty'
                    ) ty seq
            match d with
            | {map_out} -> map_out ty
            | {mapi_out} -> map_out (dyn 0) (dyn 0) ty
            | _ -> ty

        inl out = w.CudaTensor.create {elem_type dim=in.dim}

        init_d1_seq_broadcast w (ddef (inl f a b c -> f a b) (to_dev_tensor in) (to_dev_tensor out) d) in.dim
        stack out

/// Does a sequence of maps, reductions and maps in registers.
met iteri_dd1_seq_broadcast w {d with seq mapi_in} (dim_a, dim_b, dim_c) = 
    inl num_valid = s dim_c
    inl items_per_thread, blockDim =
        assert (lit_is num_valid) "The inner dimension of the input to this kernel must be known at compile time."
        if num_valid <= 1024 then 1, num_valid
        else divup num_valid 256, 256
    inl gridDimY = s dim_b
    inl gridDimZ = s dim_a

    w.run {
        blockDim
        gridDim=1,gridDimY,gridDimZ
        kernel = cuda 
            inl dims = {blockDim gridDim}
            inl inner_loop = grid_for_items dims .x dim_c
            inl create_items map = 
                inl items = HostTensor.create {
                    array_create = array_create_cuda_local
                    layout=.aot
                    elem_type=type map {item=dyn 0; i=dyn 0}
                    dim=items_per_thread
                    }

                inner_loop {body=inl {x with item i} -> items item .set (map x)}
                items

            grid_for dims .z dim_a {body=inl {i=k} ->
                inl mapi_in = mapi_in k
                inl seq = 
                    Tuple.map (
                        function
                        | {d with mapi_in} -> {d with mapi_in = self k}
                        | d -> d
                        >> function
                        | {d with mapi_out} -> {d with mapi_out = self k}
                        | d -> d
                        ) (Tuple.wrap seq)

                grid_for dims .y dim_b {body=inl {i=j} ->
                    inl items = 
                        inl map = mapi_in j
                        create_items <| inl {item i} -> map i

                    inl rec seq_redo items (d :: d') =
                        match d with
                        | {mapi_in} ->
                            inl map = mapi_in j
                            create_items <| inl {item i} -> map i (items item .get)
                        | {map_in=map} -> create_items <| inl {item i} -> map (items item .get)
                        | _ -> items
                        |> inl x -> 
                            inl x = x.bodies.ar
                            inl block_reduce redo = 
                                inl d = {blockDim redo}
                                if num_valid % blockDim.x = 0 then cub_block_reduce d
                                else cub_block_reduce {d with num_valid} 
                            match d with
                            | {redo} -> block_reduce redo x |> broadcast_zero
                            | {redo'} -> block_reduce redo' x
                        |> inl x ->
                            inl map =
                                match d with
                                | {mapi_out} -> mapi_out j
                                | {map_out} -> const map_out

                            inl body {item i} = map i (items item .get) x
                            match d' with
                            | () -> inner_loop {body}
                            | _ -> seq_redo (create_items body) d'

                    seq_redo items seq
                    }
                }
        }

/// Maps the two inputs and then scans, maps, reduces and maps the first's inner dimension.
met mapi_d1_inscan_mapi_d1_reduce_mapi' w {d with scan redo} in in' out = 
    inl in, in', out = zip in, zip in', zip out
    inl dim_in_a, dim_in_b = in.dim
    inl dim_in' :: () = in'.dim

    assert (dim_in' = dim_in_a) "Input's outer dimension must equal the output's dimension."
    assert (in'.dim = out.dim) "Input and output's dimensions must be equal."

    inl blockDim = lit_min 1024 (s dim_in_b)
    inl gridDimY = lit_min 64 (s dim_in')

    inl in = to_dev_tensor in
    inl in' = to_dev_tensor in'
    inl out = to_dev_tensor out

    w.run {
        blockDim
        gridDim=1,gridDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y dim_in_a {body=inl {i} ->
                inl in = in i
                inl in' = in' i .get

                inl _,redo_prefix =
                    grid_for .x dim_in_b {state=dyn (scan.ne, redo.ne); body=inl {state=scan_prefix,redo_prefix i=j} ->
                        inl in = in j .get
                        inl scan_x, scan_prefix = 
                            match d with
                            | {mapi_in} -> mapi_in i j in in'
                            | {map_in} -> map_in in in'
                            | _ -> in
                            |> cub_block_scan 
                                {scan_type=.inclusive; is_input_tensor=false; return_aggregate=true}
                                {blockDim redo=scan.f}
                            |> Tuple.map (scan.f scan_prefix)
                        inl redo_prefix = 
                            match d with
                            | {mapi_mid} -> mapi_mid i j scan_x in'
                            | {map_mid} -> map_mid scan_x in'
                            | _ -> scan_x
                            |> cub_block_reduce {blockDim redo=redo.f}
                            |> redo.f redo_prefix
                        scan_prefix, redo_prefix
                        }
                if threadIdx.x = 0 then 
                    inl out = out i
                    match d with
                    | {mapi_out} -> map_out i redo_prefix out.get
                    | {map_out} -> map_out redo_prefix out.get
                    | _ -> redo_prefix
                    |> out.set
                }
        }

/// The inclusive scan over the outermost dimension.
/// Accepts the optional map_in and map_out arguments for the mapping before the scan and after it.
met map_d2_inscan_map' w {d with redo neutral_elem} in out =
    inl in, out = zip in, zip out
    inl dim_in_a, dim_in_b = in.dim
    assert (in.dim = out.dim) "The input and the output dimensions need to be equal"

    inl blockDimX = lit_min warp_size (s dim_in_b)
    inl blockDimY = lit_min 32 (s dim_in_a)
    inl gridDim = min 64 (divup (s dim_in_b) blockDimX)

    inl in = to_dev_tensor in
    inl out = to_dev_tensor out

    inl map_in = match d with {map_in} -> map_in | _ -> id
    inl map_out = match d with {map_out} -> map_out | _ -> const

    w.run {
        gridDim
        blockDim=blockDimX,blockDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .x dim_in_b {body=inl {i} ->
                inl in j = in j i
                inl out j = out j i

                grid_for .y dim_in_a {state=dyn neutral_elem; body=inl {state=prefix i} -> 
                    inl in, out = in i, out i

                    inl state, prefix = // block inclusive transposed scan
                        inl state = map_in in.get
                        inl near_to = blockDim.y
                        if near_to > 1 then
                            inl from = 1
                            inl to = near_to-from

                            inl ar = 
                                HostTensor.create {
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

                    out.set (map_out state out.get)
                    prefix
                    } |> ignore
                }
        }

/// Does a reduction based on data from the init function and pipes it into the outit function.
/// Warning - the index arguments will be passed in the opposite order compared to the d1 kernel into `init`.
met init_d2_redo_outit' w {dim=outer, inner init redo neutral_elem outit} =
    inl span = Tuple.foldl (inl a b -> a * s b) 1 << Tuple.wrap
    inl span_outer, span_inner = Tuple.map span (outer,inner)

    inl blockDimX = lit_min warp_size span_inner
    inl gridDimX = min 64 (divup span_inner blockDimX)
    
    inl blockDimY = lit_min 32 span_outer
    inl gridDimY = 1

    w.run {
        gridDim=gridDimX,gridDimY
        blockDim=blockDimX,blockDimY
        kernel = cuda
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .x inner {body=inl {i} ->
                inl init = init i

                grid_for .y outer {state=dyn neutral_elem; body=inl {state i=j} -> redo state (init j)}
                |> block_reduce_2dt (blockDim.x,threadIdx.x) (blockDim.y, threadIdx.y) redo
                |> inl result ->
                    inl finally result = outit i result
                    if blockDim.y > 1 then if threadIdx.y = 0 then finally result
                    else finally result
            }
        }

inl init_d2_redo_outit w {d with dim init redo neutral_elem} =
    indiv join
        inl outer, inner = dim
        inl f = function
            | _ :: _ as x -> Tuple.map (const (dyn 0)) x
            | x -> dyn 0
        inl elem_type = type init (f inner) (f outer)
        inl out = w.CudaTensor.create {elem_type dim=inner}

        inl outit =
            inl out = to_dev_tensor out
            inl outit = match d with {outit} -> outit | _ -> id
            inl i x -> 
                inl out = Tuple.foldl (inl out i -> out i) out (Tuple.wrap i)
                out .set (outit x)
        init_d2_redo_outit' w {dim init redo neutral_elem outit}
        stack out

/// Maps the two inputs and then reduces the first's outer dimension.
met mapi_d2_redo_map' w {d with redo neutral_elem} in in' out =
    inl in, in', out = zip in, zip in', zip out
    inl dim_in_a, dim_in_b as dim = in.dim
    inl dim_in' :: () = in'.dim

    assert (dim_in' = dim_in_b) "Input's inner dimension must equal the output's dimension."
    assert (in'.dim = out.dim) "Input and output's dimensions must be equal."

    inl in,in',out = to_dev_tensor (in,in',out)

    inl init =
        match d with
        | {map_in} -> 
            inl i ->
                inl in j = in j i
                inl in' = in' i .get
                inl j ->
                    inl in = in j .get
                    map_in in in'
        | {mapi_in} ->
            inl i -> // TODO: Note that the kernel iterates in the opposite order. `i` is the inner dimension here.
                inl in j = in j i
                inl in' = in' i .get
                inl mapi_in = mapi_in i
                inl j ->
                    inl in = in j .get
                    mapi_in j in in'
        | _ ->
            match in' with
            | () ->
                inl i ->
                    inl in = in i
                    inl j -> in j .get
            | _ -> error_type "The redo is missing the map_in argument."

    inl outit =
        match d with
        | {map_out} -> inl i x -> 
            inl out = out i
            out .set (map_out x out.get)
        | {mapi_out} -> inl i x -> 
            inl out = out i
            out .set (mapi_out i x out.get)
        | _ -> inl i x -> out i .set x

    init_d2_redo_outit' w {dim init redo neutral_elem outit}

inl map_dx_redo_map_template select kernel w d in in' =
    indiv join
        inl in = zip in
        inl in' = 
            match in' with
            | () -> HostTensor.create {elem_type=(); dim=select in.dim}
            | in' -> zip in'

        inl map_out, elem_type = 
            inl map_in = match d with {map_in} -> map_in | {mapi_in} -> mapi_in (dyn 0) (dyn 0) | _ -> const
            inl ty = type map_in in.elem_type in'.elem_type
            match d with {map_out} -> (inl a _ -> map_out a),(type map_out ty) | _ -> const, ty
        inl out = w.CudaTensor.create {elem_type dim=in'.dim}
        kernel w {d with map_out} in in' out
        stack out

inl mapi_d1_redo_map w d in = map_dx_redo_map_template fst mapi_d1_redo_map' w d in
inl mapi_d2_redo_map w d in = map_dx_redo_map_template snd mapi_d2_redo_map' w d in

inl map_dx_scan_map_template kernel w d in =
    indiv join
        inl in = zip in
        inl map_in = match d with {map_in} -> map_in | _ -> id
        inl map_out, elem_type = 
            inl ty = type map_in in.elem_type
            match d with {map_out} -> (inl a _ -> map_out a), (type map_out ty) | _ -> const, ty
        inl out = w.CudaTensor.create {elem_type dim=in.dim}
        kernel w {d with map_in map_out} in out
        stack out

inl map_d1_exscan_map = map_dx_scan_map_template map_d1_exscan_map'
inl map_d1_inscan_map = map_dx_scan_map_template map_d1_inscan_map'
inl map_d2_inscan_map = map_dx_scan_map_template map_d2_inscan_map'
inl map_inscan_map = map_dx_scan_map_template map_inscan_map'

inl mapi_d1_inscan_mapi_d1_reduce_mapi w d in in' =
    indiv join
        inl in = zip in
        inl in' = 
            match in' with
            | () -> HostTensor.create {elem_type=(); dim=fst in.dim}
            | in' -> zip in'

        inl elem_type = type
            inl in = in.elem_type 
            inl in' = in'.elem_type
            match d with
            | {mapi_in} -> mapi_in (dyn 0) (dyn 0) in in'
            | {map_in} -> map_in in in'
            | _ -> in
            |>
            match d with
            | {mapi_mid} x -> mapi_mid (dyn 0) (dyn 0) x in'
            | {map_mid} x -> map_mid x in'
            | _ -> id
            |>
            match d with
            | {mapi_out} -> mapi_out (dyn 0)
            | {map_out} -> map_out
            | _ -> id

        inl d =
            match d with
            | {mapi_out} -> {d with mapi_out=inl i x _ -> mapi_out i x}
            | {map_out} -> {d with map_out=inl x _ -> map_out x}
            | _ -> {d with map_out=const}
        
        inl out = w.CudaTensor.create {elem_type dim=in'.dim}
        mapi_d1_inscan_mapi_d1_reduce_mapi' w d in in' out
        stack out

/// Iterates over the dimensions.
/// Takes in the optional {thread_limit} or {rev_thread_limit} as the first argument in order to control the degree of parallelism.
met iter w {d with dim} f =
    inl dim = HostTensor.map_dims dim
    inl rec merge = function
        | thread_limit :: l', dim :: d' -> {dim thread_limit=min thread_limit (s dim)} :: merge (l', d')
        | (), d' -> Tuple.map (inl dim -> {dim thread_limit=()}) d'
    inl d = 
        match d with
        | {thread_limit} -> merge (Tuple.wrap thread_limit,dim)
        | {rev_thread_limit} -> merge (Tuple.wrap rev_thread_limit, Tuple.rev dim) |> Tuple.rev
        | _ -> merge ((),dim)
    inl s = function {thread_limit=() dim} -> s dim | {thread_limit} -> thread_limit
    inl near_to = Tuple.foldl (inl a (!s b) -> a*b) 1 d
    inl blockDim = min near_to 256
    inl gridDim = divup near_to blockDim

    w.run {blockDim gridDim
        kernel = cuda
            grid_for {blockDim gridDim} .x {from=0; near_to} {body=inl {i} ->
                inl l,_ = Tuple.foldr (inl ((!s x_span) & x) (l,i) -> (i % x_span + x.dim.from) :: l, i / x_span) d ((),i)
                inl rec loop f = function
                    | {thread_limit=()} :: d', i :: i' -> loop (f i) (d', i')
                    | {thread_limit=by dim={near_to}} :: d', from :: i' -> forcd {from by near_to body=inl {i} -> loop (f i) (d',i')}
                    | (), () -> f; () // The output of f should be unit.
                loop f (d,l)
                }
        }

/// Creates a tensor using the given generator function.
/// Takes in the optional {thread_limit} or {rev_thread_limit} as the first argument in order to control the degree of parallelism.
met init' w d f out =
    inl out = to_dev_tensor out |> zip
    inl rec loop f out = function
        | _ :: x' -> inl i -> loop (f i) (out i) x'
        | _ -> out.set (f out.get)

    inl dim = out.dim
    inl f = loop f out (type dim)

    iter w {d with dim} f

inl init w {d with dim} f =
    indiv join
        inl dim = Tuple.wrap dim
        inl elem_type = type Tuple.foldl (inl f _ -> f (dyn 0)) f dim
        inl f = // Shifts the arguments one to the left.
            inl rec loop f = function
                | _ :: x' -> inl x -> loop (f x) x'
                | _ -> inl _ -> f
            loop f (type dim)
        inl out = w.CudaTensor.create {dim elem_type}
        init' w d f out
        stack out

// TODO: Rather than launching num_blocks, it would be better to iterate in a strided fashion so to avoid potentially 
// recomputing the indices for large matrices.
inl inplace_transpose w A =
    inl dim_a, dim_b = A.dim
    assert (s dim_a = s dim_b) "The inplace transpose is only applicable to square matrices."

    inl blockDim = warp_size

    inl blocks_per_row = divup (s dim_b) blockDim
    inl num_blocks = blocks_per_row * (blocks_per_row + 1) / 2

    inl A = to_dev_tensor A

    w.run {
        blockDim=blockDim,blockDim
        gridDim=num_blocks
        kernel=cuda
            inl thread_apply blockIdx A axis ret = 
                Tuple.foldr (inl axis next A -> 
                    inl {from near_to} :: _ = A.dim
                    inl i = blockDim axis * blockIdx axis + threadIdx axis + from
                    if i < near_to then next (A i)
                    ) axis ret A

            inl block_transposed_load y x A =
                inl t = HostTensor.create {
                    array_create = array_create_cuda_shared
                    elem_type = A.elem_type
                    dim = blockDim.y, blockDim.x+1
                    }

                inl _ =
                    inb A = thread_apply {y x} A (.y,.x)
                    t threadIdx.x threadIdx.y .set A.get

                t

            inl block_store y x t A = 
                inb A = thread_apply {y x} A (.y,.x) 
                A.set (t threadIdx.y threadIdx.x .get)

            inl {y x} =
                whilecd {
                    state={y=0; x=blockIdx.x}
                    cond=inl {y x} -> blocks_per_row - y <= x
                    body=inl {y x} -> {y = y + 1; x = x - (blocks_per_row - y)}
                    }
                |> inl {y x} -> {x=x+y; y} // Switches from upper left/lower right to a upper right/lower left representation.

            if y < x then
                inl s = block_transposed_load x y A
                inl d = block_transposed_load y x A
                syncthreads()
                block_store y x s A
                block_store x y d A
            else // y = x
                inl s = block_transposed_load x y A
                syncthreads()
                block_store x y s A
        }

inl address_at o =
    inl {ar offset} = o.bodies
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
    map' map map_redo_map d2_replicate_map' d2_replicate_map mapi_d1_redo_map' mapi_d1_redo_map mapi_d2_redo_map' mapi_d2_redo_map
    map_d1_inscan_map' map_d1_inscan_map map_d2_inscan_map' map_d2_inscan_map map_inscan_map' map_inscan_map 
    map_d1_exscan_map' map_d1_exscan_map mapi_d1_inscan_mapi_d1_reduce_mapi' mapi_d1_inscan_mapi_d1_reduce_mapi
    mapi_d1_seq_broadcast' mapi_d1_seq_broadcast init' init mapi_d1_dredo_map' mapi_d1_dredo_map iter init_d1_seq_broadcast
    iteri_dd1_seq_broadcast init_d1_redo_outit' init_d1_redo_outit init_d2_redo_outit' init_d2_redo_outit inplace_transpose
    tensor_to_pointers
    } |> stackify

inl s -> s.module_add .CudaKernel methods
    """) |> module_

let cuda_solve =
    (
    "CudaSolve",[extern_],"The CudaSolve module.",
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

    inl dense_call' handle method args =
        FS.StaticMethod dense_native_type method (handle :: args) status_type |> assert_ok    

    inl dense_call s method args =
        inl stream = s.data.stream
        inl handle = s.data.cusolve_dense_handle ()
        dense_call' handle .cusolverDnSetStream (stream.extract :: ())
        inl to_dev_tensor x = HostTensor.assert_contiguous x; CudaAux.to_dev_tensor x

        inl args =
            inl strip ptr = 
                assert (Tuple.last ptr.bodies.size = 1) "The stride of the innermost dimension should always be 1."
                (to_dev_tensor ptr).bodies.ar
            Tuple.map (function
                | x : float64 | x : float32 -> ref x
                | {ptr} -> strip ptr |> CUdeviceptr
                | {ptr_ar} -> Array.map strip ptr_ar |> s.CudaTensor.from_cudadevptr_array
                | .Lower | .Upper as x -> to_fill_mode x
                | x -> x
                ) (Tuple.wrap args)
        dense_call' handle method args

    inl span = HostTensor.span
    inl ld x = x.bodies.size |> fst

    inl i32 = to int32

    /// The Cholesky decomposition function.
    met potrf' s uplo A =
        assert (eq_type A.elem_type float32) "The type of matrix A must be float32."
        inl n, n' = A.dim |> Tuple.map span
        assert (n = n') "The matrix A must be square."
        inl lda = ld A
        inl Lwork = 
            inl Lwork = ref 0i32
            dense_call s .cusolverDnSpotrf_bufferSize(opposite_fill uplo, i32 n, {ptr=A}, i32 lda, Lwork)
            Lwork()
        inb workspace = s.CudaTensor.create {elem_type=float32; dim=to int64 Lwork} |> CudaAux.temporary
        inl dev_info = s.CudaTensor.create {elem_type=int32; dim=1}

        dense_call s .cusolverDnSpotrf(opposite_fill uplo, i32 n, {ptr=A}, i32 lda, {ptr=workspace}, Lwork, {ptr=dev_info})
        dev_info 0

    inl potrf s uplo A d =
        indiv join
            inl A = 
                inl A = CudaAux.to_dev_tensor A
                s.CudaKernel.init {dim=A.dim} <| inl a b ->
                    inl check = match uplo with .Lower -> a >= b | .Upper -> a <= b
                    if check then A a b .get else to A.elem_type 0f32
                    
            inb result = potrf' s uplo A |> CudaAux.temporary
            match d with
            | {on_succ on_fail} ->
                inl result = s.CudaTensor.get result
                if result = 0i32 then on_succ A
                else on_fail result
            | .assert ->
                inl result = s.CudaTensor.get result
                inl A = stack A
                if result = 0i32 then A
                elif result > 0i32 then failwith A (string_format "The leading minor of order {0} is not positive definite." result)
                else failwith A (string_format "The {0}-th parameter is wrong." result)
            | ret -> ret (A,result)

    ret <| s.module_add .CudaSolve {potrf' potrf}
    
    dense_call s .cusolverDnDestroy()
    """) |> module_

let cuda_modules =
    (
    "CudaModules",[cuda;allocator;region;cuda_stream;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;cuda_solve;console],"All the cuda modules in one.",
    """
inl size ret ->
    inb s = Cuda
    inb s = Allocator s size
    inb s = CudaRandom s
    inb s = CudaBlas s
    inl s = Region s |> CudaStream |> CudaTensor |> CudaKernel
    inb s = s.RegionMem.create'
    inb s = s.RegionStream.create'
    inl s = s.RegionStream.allocate
    inb s = CudaSolve s
    ret s
    """) |> module_
