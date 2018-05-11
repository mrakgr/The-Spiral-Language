module Learning.Module

open Spiral.Types
open Spiral.Lib

let serializer_one_hot =
    (
    "SerializerOneHot",[tuple;console],"The Serializer module.",
    """
/// The functions here are used for transforming arbitrary types into the one-hot format.
/// Useful in RL contexts since union types are not blittable.
inl rec encode_template f x =
    inl encode = encode_template f
    inl prod (i,s) x =
        inl i',s' = encode x
        i + i' * s, s * s'

    inl sum s x =
        inl i',s' = encode x
        s + i', s + s'

    match x with
    | x when caseable_box_is x -> case_foldl_map sum 0 x
    | _ :: _ as x -> Tuple.foldl prod (0,1) x
    | .(_) | () -> 0,1
    | {!block} as x -> module_foldl (const prod) (0,1) x
    | x -> f x

inl assert_range r x =
    inl {from near_to} = match r with {from near_to} -> r | near_to -> {from=0; near_to}
    assert (x >= from) "x must be greater or equal to its lower bound."
    assert (x < near_to) "x must be lesser than its upper bound."
    x, near_to - from

inl span r elem_type =
    type encode_template (assert_range r) elem_type |> snd |> type_lit_lift
    |> type_lit_cast

inl encode' r = encode_template (assert_range r)
inl encode r = encode' r >> fst

inl rec decode_template f n x =
    inl decode = decode_template f
    inl prod (n,s) x = 
        inl i,s' = decode n x
        i, (n / s', s * s')

    match x with
    | x when caseable_box_is x -> 
        inl i, (_, s) = 
            Tuple.foldl_map (inl (n,s) x ->
                inl i, s' = decode n x
                (i, s'), (n - s', s + s')
                ) (n, 0) (split x)
        
        inl rec loop n ((i,s) :: x') =
            inl i _ = i () |> box x
            match x' with
            | () -> i () 
            | _ -> if n < s then i () else loop (n - s) x'

        inl i _ = loop (n % s) i
        i, s
    | _ :: _ -> Tuple.foldl_map prod (n,1) x |> inl a, (n, s) -> (inl _ -> Tuple.map (inl x -> x()) a), s
    | .(_) | () -> const x, 1
    | {!block} -> module_foldl_map (const prod) (n,1) x |> inl a, (n, s) -> (inl _ -> module_map (inl _ x -> x()) a), s
    | _ -> f n x

inl decode' r a b = 
    inl {from near_to} = match r with {from near_to} -> r | near_to -> {from=0; near_to}
    inl s = near_to - from
    decode_template (inl n (x: int64) -> (inl _ -> n % s), s) a b |> inl a,b -> a(), b

inl decode r a b = decode' r a b |> fst

{ encode' encode decode' decode span } |> stackify
    """) |> module_

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
    "ResizeArray",[extern_],"The resizable array module.",
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
    inl set i v = macro.fs () [arg: x; text: ".["; arg: to int32 i; text: "] <- "; arg: v]
    inl clear () = FS.Method x .Clear() ()
    inl count () = FS.Method x .get_Count() int32
    inl add y = FS.Method x .Add y ()

    inl iter f = FS.Method x ."ForEach <| System.Action<_>" (closure_of f (elem_type => ())) ()
    inl to_array () = FS.Method x .ToArray() (array elem_type)

    function
    | .sort -> sort 
    | .filter -> filter 
    | .set -> set
    | .clear -> clear ()
    | .count -> count ()
    | .add -> add
    | .iter -> iter
    | .elem_type -> elem_type
    | .to_array -> to_array ()
    | i -> index i
    |> stack
{ 
create
} |> stack
    """
    ) |> module_

let allocator = 
    (
    "Allocator",[resize_array;loops;option;extern_;console],"The section based GPU memory allocator module.",
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
        assert (x <> 0u64) "A Cuda memory cell that has been disposed has been tried to be accessed."
        x

inl mult = 256u64
assert (mult <> 0u64 && (mult &&& mult - 1u64) = 0u64) "Multiple must be a power of 2." 
inl round_up_to_multiple size = (size + mult - 1u64) &&& 0u64 - mult

inl to_uint x = FS.UnOp .uint64 x uint64
inl allocate_global s =
    to uint64 >> round_up_to_multiple >> dyn
    >> inl size -> { size ptr = FS.Method s.data.context .AllocateMemory (SizeT size) CUdeviceptr_type |> to_uint |> smartptr_create }

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32
inl sort_ptrs x = x.sort (inl {ptr=a} {ptr=b} -> compare (a()) (b()))
inl sort_sizes x = x.sort (inl {size=a} {size=b} -> compare b a)

met refresh s = 
    inl {pool free_cells used_cells} = s.data.section
    used_cells.filter (inl {ptr} -> ptr.Try = 0u64)
    sort_ptrs used_cells
    free_cells.clear
    inl add {ptr size} = 
        inl ptr' = round_up_to_multiple ptr
        inl d = ptr' - ptr
        if size > d then free_cells.add {ptr = ptr'; size=size-d}

    inl start x = x.ptr()
    inl end x = x.ptr() + x.size

    Loops.for {from=0i32; near_to=used_cells.count; by=1i32; state=start pool; body=inl {state=ptr i} ->
        inl state' = used_cells i
        assert (start state' >= ptr) "The next pointer should be higher than the last."
        
        inl start = start state'
        add { ptr size = start - ptr }
        start + state'.size // end state'
        }
    |> inl ptr -> // This is for the final free cell at the end.
        inl size = end pool - ptr
        add {ptr size}


met allocate s (!(to uint64 >> round_up_to_multiple >> dyn) size') =
    inl {pool used_cells free_cells} = s.data.section
    inl loop next =
        inl {ptr size} = free_cells 0i32
        if size' <= size then
            free_cells.set 0i32 {ptr=ptr+size'; size=size-size'}
            {ptr=smartptr_create ptr; size=size'}
        else next()

    inl x =
        assert (free_cells.count > 0i32) "Out of memory in the designated section."
        loop <| inl _ ->
            sort_sizes free_cells
            loop <| inl _ -> 
                refresh s
                sort_sizes free_cells
                loop <| inl _ ->
                    failwith pool "Out of memory in the designated section."
    used_cells.add x
    x.ptr

inl section_create s size ret =
    inl pool = allocate_global s size
    inl free_cells = ResizeArray.create {elem_type=type {ptr=uint64; size=uint64}}
    inl used_cells = ResizeArray.create {elem_type=type pool}
    inl section = {pool free_cells used_cells} |> heap
    inl allocate s = 
        function
        | .elem_type -> type s.data.section.pool.ptr
        | x -> allocate s x
        
    inl s =
        s.member_add {
            refresh
            allocate
            }
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
    "CudaTensor",[extern_;host_tensor],"The Cuda tensor module.",
    """
open HostTensor
open Extern

inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
inl SizeT = FS.Constructor SizeT_type
inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT

inl ptr_cuda {ar offset} ret = ar.ptr() + to uint64 (offset * sizeof ar.elem_type) |> ret
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

inl get_elem s {src with size=()} = to_host_array s 1 src 0

met set_elem s (!dyn {dst with size=()}) (!dyn v) =
    inl ar = array_create v 1
    ar 0 <- v
    copy s 1 {dst with ptr_get=ptr_cuda} {ar size=(); offset=0; ptr_get=ptr_dotnet}

inl methods = 
    {
    create=inl s data -> create {data with array_create = array_create_cuda_global s}
    create_like=inl s tns -> s.CudaTensor.create {elem_type=tns.elem_type; dim=tns.dim}

    to_host_array from_host_array

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
    
    zero=inl s d -> indiv join s.CudaTensor.create d |> clear' s |> stack
    zero_like=inl s d -> indiv join s.CudaTensor.create_like d |> clear' s |> stack

    to_dev_tensor = inl _ tns -> tns.update_body (inl body -> 
        inb ptr = ptr_cuda body
        {body with ar=!UnsafeCoerceToArrayCudaGlobal(ptr,body.ar.elem_type); offset=0}
        )

    print=met s (!zip (!dyn x)) -> s.CudaTensor.to_host_tensor x |> HostTensor.print

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
    
    inl fill_array s distribution (!SizeT size1d) ar =
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
            inl in' = zip in |> flatten |> s.CudaTensor.to_dev_tensor
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
        inl to_dev_tensor = s.CudaTensor.to_dev_tensor
        inl to_dev_tensor x = assert_contiguous x; to_dev_tensor x
        inl args = Tuple.map (function x : int64 -> to int32 x | x -> x) args
        inl handle = FS.Method cublas .get_CublasHandle() (fs [text: "ManagedCuda.CudaBlas.CudaBlasHandle"])
        FS.Method cublas .set_Stream stream.extract ()
        inl args = 
            Tuple.map (function 
                | x : float64 | x : float32 -> ref x
                | .nT | .T as x -> to_operation x
                | {ptr=!to_dev_tensor x} -> x.bodies.ar |> CUdeviceptr
                | x -> x
                ) args
        inl native_type = fs [text: "ManagedCuda.CudaBlas.CudaBlasNativeMethods"]
        inl status_type = fs [text: "ManagedCuda.CudaBlas.CublasStatus"]
        inl assert_ok status = macro.fs () [text: "if "; arg: status; text: " <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException"; args: status]
        FS.StaticMethod native_type method (handle :: args) status_type |> assert_ok

    /// General matrix-matrix multiply from cuBLAS. Inplace version
    met gemm' s transa transb alpha A B beta C =
        inl a_col = if isnT transa then cols A else rows A
        inl b_row = if isnT transb then rows B else cols B
        assert (a_col = b_row) "Colums of a does not match rows of b in GEMM."

        inl m = if isnT transa then rows A else cols A
        inl n = if isnT transb then cols B else rows B
        inl k = a_col
        
        assert (m = rows C && n = cols C) "Output matrix dimensions do not match in GEMM."

        // The arguments are switched in order to convert from column major (which CuBlas uses) to row major (which Spiral's tensor use)
        call s .cublasSgemm_v2(transb, transa, n, m, k, alpha, {ptr=B}, ld B, {ptr=A}, ld A, beta, {ptr=C}, ld C)

    inl gemm s transa transb alpha A B =
        indiv join
            inl m = if isnT transa then rows A else cols A
            inl n = if isnT transb then cols B else rows B

            inl C = s.CudaTensor.create {dim=m,n; elem_type = A.elem_type}
            gemm' s transa transb alpha A B (to alpha 0) C
            stack C

    ret <| s.module_add .CudaBlas {gemm' gemm}
    """) |> module_

let cuda_kernel =
    (
    "CudaKernel",[lazy_;host_tensor;cuda_tensor],"The Cuda kernels module.",
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

inl grid_for_template {iteration_mode} {blockDim gridDim} axis dim =
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
            if i < near_to then body {span num_valid item state i} else state
            }
    | .std d -> forcd {d with from by near_to}

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

met map' w f in out = 
    inl in, out = zip in, zip out
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
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
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
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
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
        
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
        inl to_dev_tensor = w.CudaTensor.to_dev_tensor
   
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
        inl gridDim = 1 //lit_min 64 (divup span blockDim)

        inl r = 
            if gridDim = 1 then
                run {map_out map_in blockDim gridDim} in
            else
                run {map_out=id; map_in blockDim gridDim} in
                |> run {map_out map_in=id; blockDim=gridDim; gridDim=1}
        r 0 |> stack
        

/// Replicates the 1d `in` and maps it along the outer dimension as determined by `in'`.
met d2_replicate_map' w f in in' out =
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
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
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
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

/// Maps the two inputs and then reduces the first's inner dimension.
met mapi_d1_redo_map' w {d with redo neutral_elem} in in' out = 
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
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
    inl map_out = match d with {map_out} -> map_out | _ -> const
        
    w.run {
        blockDim
        gridDim=1,gridDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .y dim_in_a {body=inl {i} ->
                inl in, in' = in i, in' i .get

                inl x = 
                    grid_for .x dim_in_b {state=dyn neutral_elem; body=inl {state i=j} ->
                        inl in = in j
                        match d with
                        | {map_in} -> redo state (map_in in.get in')
                        | {mapi_in} -> redo state (mapi_in i j in.get in')
                        | _ -> redo state in.get
                        }
                    |> cub_block_reduce {blockDim redo}

                if threadIdx.x = 0 then
                    inl out = out i
                    out.set (map_out x out.get)
                }
        }

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
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
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

/// Does a sequence of maps, reductions and maps in registers.
met iteri_d1_seq_broadcast w {d with seq mapi_in} (dim_a, dim_b) = 
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

                seq_redo items (Tuple.wrap seq)
                }
        }

inl ddef fout in out = 
    function
    | {d with mapi_in} -> {d with mapi_in = inl j i -> mapi_in j i (in j i .get)}
    | {d with map_in} -> {d without map_in with mapi_in = map_in (in j i .get)}
    | d -> {d with mapi_in = inl j i -> in j i .get}
    >> function
    | {d with seq} ->
        inl f = function
            | {mapi_out} as x -> {x with mapi_out = inl j i a b -> 
                inl out = out j i
                out .set (fout (mapi_out j i) a b out.get)
                }
            | {map_out} as x -> {x without map_out with mapi_out = inl j i a b -> 
                inl out = out j i
                out .set (fout map_out a b out.get)
                }
            | _ -> error_type "The map_out or mapi_out in is needed in every item of the sequence."

        {d with seq = Tuple.map_last f (Tuple.wrap seq)}

// Repeatedly reduces along the inner dimension and then maps the result of that reductions over the input in the previous step.
met mapi_d1_seq_broadcast' w {d with seq} in out = 
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
    inl in, out = zip in, zip out
    assert (in.dim = out.dim) "The input and the output dimensions need to be equal"

    inl in = to_dev_tensor in
    inl out = to_dev_tensor out

    iteri_d1_seq_broadcast w (ddef (inl f a b c -> f a b c) in out d) in.dim

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
            Tuple.foldl (inl ty d -> 
                inl ty' = 
                    match d with
                    | {map_in} -> map_in ty
                    | {mapi_in} -> mapi_in (dyn 0) (dyn 0) ty
                    | _ -> ty
                match d with
                | {map_out} -> map_out ty ty'
                | {mapi_out} -> map_out (dyn 0) (dyn 0) ty ty'
                ) ty seq
        
        inl out = w.CudaTensor.create {elem_type dim=in.dim}
        inl to_dev_tensor = w.CudaTensor.to_dev_tensor

        iteri_d1_seq_broadcast w (ddef (inl f a b c -> f a b) (to_dev_tensor in) (to_dev_tensor out) d) in.dim
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
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
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
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
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

/// Maps the two inputs and then reduces the first's outer dimension.
met mapi_d2_redo_map' w {d with redo neutral_elem} in in' out =
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
    inl in, in', out = zip in, zip in', zip out
    inl dim_in_a, dim_in_b = in.dim
    inl dim_in' :: () = in'.dim

    assert (dim_in' = dim_in_b) "Input's inner dimension must equal the output's dimension."
    assert (in'.dim = out.dim) "Input and output's dimensions must be equal."

    inl blockDimX = lit_min warp_size (s dim_in')
    inl blockDimY = lit_min 32 (s dim_in_a)
    inl gridDim = min 64 (divup (s dim_in') blockDimX)

    inl in = to_dev_tensor in
    inl in' = to_dev_tensor in'
    inl out = to_dev_tensor out
    inl map_out = match d with {map_out} -> map_out | _ a _ _ -> a

    w.run {
        gridDim
        blockDim=blockDimX,blockDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .x dim_in_b {body=inl {i} ->
                inl in j = in j i
                inl in' = in' i .get
                inl out = out i

                grid_for .y dim_in_a {state=dyn neutral_elem; body=inl {state i=j} -> 
                    inl in = in j
                    match d with
                    | {map_in} -> redo state (map_in in.get in') 
                    | {mapi_in} -> redo state (mapi_in i j in.get in') 
                    | _ -> redo state in.get
                    }
                |> block_reduce_2dt (blockDim.x,threadIdx.x) (blockDim.y, threadIdx.y) redo
                |> inl result ->
                    inl finally result = out.set (map_out result out.get)
                    if blockDim.y > 1 then if threadIdx.y = 0 then finally result
                    else finally result
            }
        } |> ignore

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
met iter w d f (!(Tuple.wrap) dim) =
    inl rec merge = function
        | thread_limit :: l', dim :: d' -> {dim thread_limit=min thread_limit (s dim)} :: merge (l', d')
        | (), d' -> Tuple.map (inl dim -> {dim thread_limit=()}) d'
    inl d = 
        match d with
        | {thread_limit} -> merge (Tuple.wrap thread_limit,dim)
        | {rev_thread_limit} -> merge (Tuple.wrap rev_thread_limit,Tuple.rev dim) |> Tuple.rev
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
    inl out = w.CudaTensor.to_dev_tensor out |> zip
    inl rec loop f out = function
        | _ :: x' -> inl i -> loop (f i) (out i) x'
        | _ -> out.set (f out.get)

    inl dim = out.dim
    inl f = loop f out (type dim)

    iter w d f dim

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

inl methods =
    {
    map' map map_redo_map d2_replicate_map' d2_replicate_map mapi_d1_redo_map' mapi_d1_redo_map mapi_d2_redo_map' mapi_d2_redo_map
    map_d1_inscan_map' map_d1_inscan_map map_d2_inscan_map' map_d2_inscan_map map_inscan_map' map_inscan_map 
    map_d1_exscan_map' map_d1_exscan_map mapi_d1_inscan_mapi_d1_reduce_mapi' mapi_d1_inscan_mapi_d1_reduce_mapi
    mapi_d1_seq_broadcast' mapi_d1_seq_broadcast init' init mapi_d1_dredo_map' mapi_d1_dredo_map iter iteri_d1_seq_broadcast
    iteri_dd1_seq_broadcast
    } |> stackify

inl s -> s.module_add .CudaKernel methods
    """) |> module_

let cuda_modules =
    (
    "CudaModules",[cuda;allocator;region;cuda_stream;cuda_tensor;cuda_kernel;cuda_random;cuda_blas;console],"All the cuda modules in one.",
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
    ret s
    """) |> module_

let learning =
    (
    "Learning",[struct';extern_;serializer_one_hot],"The deep learning module.",
    """
inl float ->
    // #Primitives
    inl zero = to float 0
    inl one = to float 1
    inl two = to float 2
    inl infinity =
        match float with
        | _: float32 -> infinityf32
        | _: float64 -> infinityf64

    inl primal = function {primal} | primal -> primal
    inl adjoint = function {adjoint} -> adjoint | _ -> ()

    inl primals = Struct.map primal
    inl adjoints = Struct.map adjoint

    inl on_non_nil ret B =
        match B with
        | () -> ()
        | B -> ret B

    inl dr s primal = {primal adjoint=s.CudaTensor.zero_like primal; block=()}

    inl matmultb l bias s = 
        inl l =
            match l with
            | () -> error_type "The first argument must not be empty."
            | (_,_) :: _ -> l
            | _ :: _ -> l :: ()
        inl C = 
            Tuple.foldl (inl C (A,B) ->
                match C with
                | () -> s.CudaBlas.gemm .nT .nT one (primal A) (primal B) |> dr s
                | C -> s.CudaBlas.gemm' .nT .nT one (primal A) (primal B) one (primal C); C
                ) () l
        match bias with
        | () -> ()
        | _ -> s.CudaKernel.d2_replicate_map' (inl a b _ -> a+b) (primal bias) (primal C) (primal C)
        C, inl _ -> join
            inl C' = adjoint C
            inl l =
                Tuple.iter (inl A, B -> 
                    on_non_nil (inl A -> s.CudaBlas.gemm' .nT .T one C' (primal B) one A) (adjoint A)
                    on_non_nil (inl B -> s.CudaBlas.gemm' .T .nT one (primal A) C' one B) (adjoint B)
                    ) l
            match bias with
            | () -> ()
            | _ -> on_non_nil (inl bias -> s.CudaKernel.mapi_d2_redo_map' {map_in=const;neutral_elem=zero;redo=(+);map_out=(+)} C' bias.empty bias) (adjoint bias)

    inl matmult l s = matmultb l () s

    inl choose_adjoints in bck =
        Struct.choose2 (function
            | {primal adjoint} bck -> {adjoint bck block=()}
            | _ _ -> ()) in bck
        |> inl x -> Struct.map (inl x -> x.adjoint) x, Struct.map (inl x -> x.bck) x
            
    inl map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaKernel.map fwd primal |> dr s

        inl adjoint, bck = choose_adjoints in bck
        out, inl _ -> join
            inl bck (in, out) = Struct.map2 (inl bck -> bck (in, out)) bck
            s.CudaKernel.map' bck (primal, {out without block}) adjoint

    /// Does not return a `dr` unlike the rest. This is an optimization in order to avoid having to call too many useless kernels that 
    /// just to set the adjoint to 1. The current library is intended for a narrow purpose.
    inl map_redo_map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaKernel.map_redo_map fwd primal

        inl adjoint, bck = choose_adjoints in bck
        out, inl _ -> join
            inl out = s.CudaTensor.to_dev_tensor out
            inl bck in = Struct.map2 (inl bck -> bck (in, out.get)) bck
            s.CudaKernel.map' bck primal adjoint

    inl d2_replicate_map {fwd bck={bck_in bck_in'}} in in' s =
        inl primal, adjoint = primals in, adjoints in
        inl primal', adjoint' = primals in', adjoints in'
        inl out = s.CudaKernel.d2_replicate_map fwd primal primal' |> dr s
        out, inl _ -> join
            inl out = {out without block}
            s.CudaKernel.mapi_d2_redo_map' bck_in (primal', out) primal adjoint
            s.CudaKernel.d2_replicate_map' bck_in' primal (primal', out) adjoint'

    inl Primitive =
        {
        matmult map map_redo_map matmultb d2_replicate_map
        } |> stack

    // #Operations
    inl apply_bck = (<<)

    inl (>>=) a b s =
        inl a,a_bck = a s
        inl b,b_bck = b a s
        b, apply_bck a_bck b_bck

    inl succ x _ = x, const ()

    // #Activation
    inl activation d = map {d with bck = Struct.map (inl bck (in, out) adjoint -> adjoint + out.adjoint * (self in out.primal)) self}

    inl sigmoid_fwd x = one / (one + exp -x)
    inl sigmoid_bck out = out * (one - out)

    inl sigmoid = activation {
        fwd = sigmoid_fwd
        bck = inl _ -> sigmoid_bck
        }

    inl tanh_fwd = tanh
    inl tanh_bck out = one - out * out

    inl tanh = activation {
        fwd = tanh_fwd
        bck = inl _ -> tanh_bck
        }

    inl relu_fwd x = if x > zero then x else zero
    inl relu_bck out = if out > zero then one else zero

    inl relu = activation {
        fwd = relu_fwd
        bck = inl _ -> relu_bck
        }

    inl add = activation {
        fwd = inl a,b -> a+b
        bck = (inl _ _ -> one), (inl _ _ -> one)
        }

    inl hadmult = activation {
        fwd = inl a,b -> a*b
        bck = (inl (_,x) _ -> x), (inl (x,_) _ -> x)
        }

    inl d2_replicate_activation {fwd bck_in bck_in'} in =
        inl neutral_elem = Struct.map (const zero) in
        inl bck = {
            bck_in={
                map_in=inl (in', out) in -> Struct.map ((*) out.adjoint) (bck_in in in' out.primal)
                neutral_elem redo=Struct.map2 (+)
                map_out=Struct.map2 (+)
                }
            bck_in'=inl in (in', out) -> Struct.map2 (inl x adjoint -> adjoint + out.adjoint*x) (bck_in' in in' out.primal)
            }
        d2_replicate_map { fwd bck } in

    inl Activation = {activation sigmoid tanh relu add hadmult d2_replicate_activation } |> stack

    // #Optimizer
    inl sgd learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> P - learning_rate * A, zero) primal.empty (primal, adjoint)

    inl clipped_sgd max learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> 
            inl A = if A < -max then -max elif A > max then max else A
            P - learning_rate * A, zero
            ) primal.empty (primal, adjoint)

    inl Optimizer = {sgd clipped_sgd}

    // #Accuracy
    inl accuracy label input s =
        inl input, label = primal input, primal label
        inl max = input .span_outer
        inl value =
            s.CudaKernel.mapi_d1_redo_map {
                map_in=const
                neutral_elem=-infinity,zero
                redo=inl a b -> if fst a > fst b then a else b
                map_out=snd >> to int64
                } (input,label) ()
            |> s.CudaKernel.map_redo_map {
                neutral_elem=0; redo=(+)
                }
        {value max}

    // #Auxiliary
    inl atomic_add o x =
        inl (),{ar offset} = o.dim, o.bodies
        inl adr = macro.cd ar [arg: ar; text: " + "; arg: offset]
        macro.cd () [text: "atomicAdd"; args: adr, x]

    /// The softmax activation
    inl softmax temp input s =
        s.CudaKernel.mapi_d1_seq_broadcast {
            map_in=inl x -> x / temp
            seq = 
                {
                redo=max
                map_out=inl a b -> exp (a - b)
                }
                ,
                {
                redo=(+)
                map_out=(/)
                }
            } input
                
    inl encode =
        {
        /// The one hot encode function. Does not check that the inputs are in range.
        one_hot = inl size tns s ->
            inl f = 
                inl rec f tns = function
                    | _ :: x' -> inl x -> f (tns x) x'
                    | () -> inl x -> if x = to int64 tns.get then one else zero
                f (s.CudaTensor.to_dev_tensor tns) (type tns.dim)
            s.CudaKernel.init {rev_thread_limit=32; dim=Tuple.append tns.dim (size :: ())} f
        } |> stackify

    /// Aplies a softmax to the inputs and then samples from them randomly. Returns the resulting indices in a 1d tensor.
    inl sample temp x s =
        inl prob = softmax temp (primal x) s
        inl boundary = s.CudaRandom.create {dst=.Uniform} {elem_type=float; dim=fst prob.dim}
        s.CudaKernel.mapi_d1_inscan_mapi_d1_reduce_mapi {
            scan={
                ne=0f32
                f=(+)
                }
            mapi_mid=inl _ index prob boundary -> 
                inl x = prob - boundary
                (if x < 0f32 then infinity else x), index
            redo={
                ne=infinity,0
                f=inl a b -> if fst a <= fst b then a else b
                }
            map_out=snd
            } prob boundary

    inl Auxiliary = {encode sample} |> stackify

    //#Error
    inl error {fwd bck} label input s = 
        inl batch_size = primal input .span_outer |> to float
        inl div_by_minibatch_size x = x / batch_size
        map_redo_map {
            fwd = {
                map_in = fwd
                redo = (+)
                neutral_elem = zero
                map_out = div_by_minibatch_size
                }
            /// The adjoint in error is always assumed to be one.
            bck = Struct.map (inl bck (in, out) adjoint -> adjoint + div_by_minibatch_size (bck in out)) bck
            } (input, label) s

    inl square_bck (x,y) = two * (x - y)
    inl sqaure_bck' (x,y) = -(two * (x - y))

    inl square = error {
        fwd = inl (x,y) -> (y - x) * (y - x)
        bck =
            inl x _ -> square_bck x
            ,inl x _ -> sqaure_bck' x
        }

    inl cross_entropy = error {
        fwd = inl x,y -> -(y * log x + (one - y) * log (one - x))
        bck = 
            inl (x, y) _ -> (x - y) / (x * (one - x))
            ,inl (x, y) _ -> log (one - x) - log x
        }

    /// Applies a softmax and then calculates the cross entropy cost. Is intended to take a linear layer as input.
    inl softmax_cross_entropy label input s =
        assert ((primal label).dim = (primal input).dim) "Labels and inputs must have equal dimensions."
        inl to_dev_tensor = s.CudaTensor.to_dev_tensor
        
        inl batch_size = primal input .span_outer |> to float

        inl temp = one

        inl cost = 
            inl cost = s.CudaTensor.create {elem_type=float; dim=primal input .dim |> fst}
            inl _ =
                inl input, label, cost = Tuple.map (primal >> to_dev_tensor) (input, label, cost)
                s.CudaKernel.iteri_d1_seq_broadcast {
                    mapi_in=inl j i -> input j i .get / temp
                    seq = 
                        {
                        redo=max
                        mapi_out=inl _ _ a b -> exp (a - b)
                        }
                        ,
                        {
                        redo=(+)
                        mapi_out=inl j i x sum_x ->
                            inl p = x / sum_x
                            inl label = label j i .get
                            -label * log p
                        }
                        ,
                        {
                        redo'=(+)
                        mapi_out=inl j i _ c -> if threadIdx.x = 0 then cost j .set (c / batch_size)
                        }
                    } (primal input).dim
            s.CudaKernel.map_redo_map {
                redo = (+)
                neutral_elem = zero
                } cost

        inl bck _ = join
            match Tuple.map (adjoint >> on_non_nil to_dev_tensor) (input, label) with
            | (), () -> ()
            | input', label' ->
                inl input, label = Tuple.map (primal >> to_dev_tensor) (input, label)
                s.CudaKernel.iteri_d1_seq_broadcast {
                    mapi_in=inl j i -> input j i .get / temp
                    seq = 
                        {
                        redo=max
                        mapi_out=inl _ _ a b -> exp (a - b)
                        }
                        ,
                        {
                        redo=(+)
                        mapi_out=inl j i x sum_x ->
                            inl get x = x j i .get
                            inl set x = x j i .set
                            inl ret f = on_non_nil (inl x -> set x (get x + f () / batch_size))

                            inl p = x / sum_x
                            inl label = get label
                            ret (inl _ -> (p - label) / temp) input'
                            ret (inl _ -> -(log p)) label'
                        }
                    } input.dim

        cost, bck


    /// The Hubert quantile regression functions.
    inl HQR =
        inl L k u = 
            inl abs_u = abs u
            if abs_u <= k then u * u / two
            else k * (abs_u - k / two)

        inl fwd k q (a,b) = 
            inl u = b - a
            inl d = q - if u < zero then one else zero
            if k = zero then u * d
            else L k u * abs d

        inl L' k u =
            inl abs_u = abs u
            if abs_u <= k then u
            else 
                inl abs_u' = if u >= zero then one else -one
                k * abs_u'

        inl bck_b k q (a,b) =
            inl u = b - a
            inl d = q - if u < zero then one else zero
            if k = zero then d
            else L' k u * abs d

        inl bck_a k q (a,b) = -(bck_b k q (a,b))

        {fwd bck_a bck_b}

    /// Though it say qr, this instance of it is just the mean function.
    /// Is here so it can be put in through the gradient checker.
    inl hubert_qr k =
        inl half = to float 0.5
        error {
            fwd = HQR.fwd k half
            bck = 
                inl x _ -> HQR.bck_a k half x
                ,inl x _ -> HQR.bck_b k half x
            }

    inl Error = {square cross_entropy softmax_cross_entropy hubert_qr} |> stackify

    // #Initializer
    inl Initializer = 
        inl init mult dim s = 
            inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 dim))
            s.CudaRandom.create {dst=.Normal; stddev mean=0.0f32} {dim elem_type=type zero}
        { 
        // Note: The following inits are not intended to be optimal, but work well either way with LN.
        // Even with LN extremely poor inits can undermine the integrity of the network, but these should work interchangeably.
        sigmoid = init 2f32
        tanh = init 3f32
        relu = init 1f32
        bad = init 0.01f32
        } |> stackify

    // #Combinators
    inl layer_map_fold f network s =
        inl rec layer_map_fold r x s =
            match x with
            | {layer_type gid} ->
                match r with
                | {$gid=x} -> (x, s), r
                | _ ->
                    inl (sublayer, s), r =
                        match x with
                        | {sublayer} -> layer_map_fold r sublayer s
                        | _ -> ((), s), r
                    inl x, s = f {x with sublayer} s
                    (x, s), {r with $gid=x}
            | x :: x' -> 
                inl (x, s), r = layer_map_fold r x s
                inl (x', s), r = layer_map_fold r x' s
                (x :: x', s), r
            | () -> ((), s), r
            | {} ->
                module_foldl (inl k ((m,s),r) x ->
                    inl (x, s), r = layer_map_fold r x s
                    (module_add k x m, s), r
                    ) (({},s),r) x
            | _ -> error_type ("Expected a layer. Got", x)
            
        layer_map_fold {} network s |> fst

    inl layer_map f network =
        inl rec layer_map r = function
            | {x with layer_type gid} ->
                match r with
                | {$gid=x} -> x, r
                | _ ->
                    inl sublayer, r =
                        match x with
                        | {sublayer} -> layer_map r sublayer
                        | _ -> (), r
                    inl x = f {x with sublayer}
                    x, {r with $gid=x}
            | x :: x' -> 
                inl x, r = layer_map r x
                inl x', r = layer_map r x'
                x :: x', r
            | () -> (), r
            | {} as x ->
                module_foldl (inl k (m,r) x ->
                    inl x,r = layer_map r x
                    module_add k x m, r
                    ) ({},r) x
            | x -> error_type ("Expected a layer. Got", x)
        layer_map {} network |> fst

    inl init s network = 
        layer_map (function
            | {x with weights} -> {x with weights = const (weights s)}
            | x -> x
            ) network

    inl init_parallel s network = 
        layer_map (function
            | {stream} | {layer_type=.input | .parallel} as x -> x
            | {x with weights} -> {x with weights = const (weights s); stream=s.RegionStream.allocate.data.stream}
            | x -> {x with stream=s.RegionStream.allocate.data.stream}
            ) network

    inl optimize network optimizer s =
        inl body weights s = weights () |> Struct.iter (optimizer s)
        layer_map (function
            | {weights stream} -> s .data_add {stream} |> body weights
            | {weights} -> body weights s
            | _ -> ()
            ) network 

    inl run x d s =
        layer_map_fold (inl {x with layer_type gid} d ->
            inl ret' t a, b = stack (a, term_cast b t)
            inl ret = ret' ()
            match layer_type with
            | .input -> d.input x.name, d
            | .stateless ->
                inl value, bck = indiv join x.apply x.sublayer s |> ret
                value, {d with bck = apply_bck self bck}
            | .non_differentiable ->
                inl value = indiv join x.apply x.sublayer s |> stack
                value, d
            | .parallel -> x.sublayer, d
            | .feedforward ->
                inl value, bck = indiv join x.apply (x.weights()) x.sublayer s |> ret
                value, {d with bck = apply_bck self bck}
            | .action ->
                inl value, bck = indiv join x.apply (x.weights()) x.sublayer s |> ret' float64
                value, {d with bck = apply_bck self bck}
            | .recurrent ->
                inl state = match d.state with {$gid=state} -> state | _ -> ()
                inl (value, state), bck = indiv join x.apply (x.weights()) state x.sublayer s |> ret
                value, {d with bck = apply_bck self bck; state = {self with $gid=state}}
            ) x d

    /// The wavefront iteration optimization.
    /// Requires the non-input layers to have preallocated streams.
    inl run_parallel x d s =
        layer_map_fold (inl {x with layer_type gid} d ->
            match layer_type with
            | .input -> {value=d.input x.name; stream=s.data.stream; block=()}, d
            | .parallel -> x.sublayer, d
            | _ ->
                inl stream = x.stream
                inl s = s.data_add {stream}
                inl values = Struct.map (inl {value} -> value) x.sublayer
                inl streams = 
                    Struct.choose (function
                        | {stream=x} -> stream.wait_on x; x
                        | _ -> ()) x.sublayer

                inl wait_bck b x = b x; Struct.iter (inl x -> x.wait_on stream) streams
                inl ret' t a, b = stack (a, term_cast (wait_bck b) t)
                inl ret = ret' ()

                match layer_type with
                | .stateless ->
                    inl value, bck = indiv join x.apply values s |> ret
                    {value stream block=()}, {d with bck = apply_bck self bck}
                | .non_differentiable ->
                    inl value = indiv join x.apply values s |> stack
                    {value stream block=()}, d
                | .feedforward ->
                    inl value, bck = indiv join x.apply (x.weights()) values s |> ret
                    {value stream block=()}, {d with bck = apply_bck self bck}
                | .action ->
                    inl value, bck = indiv join x.apply (x.weights()) values s |> ret' float64
                    {value stream block=()}, {d with bck = apply_bck self bck}
                | .recurrent ->
                    inl state = match d.state with {$gid=state} -> state | _ -> ()
                    inl (value, state), bck = indiv join x.apply (x.weights()) state values s |> ret
                    {value stream block=()}, {d with bck = apply_bck self bck; state = {self with $gid=state}}
                ) x d
        |> inl x, d -> Struct.map (inl {value} -> value) x, d

    inl Combinator = 
        {
        layer_map_fold layer_map init init_parallel optimize run run_parallel
        } |> stackify

    // #Loops
    inl outer data =
        Struct.foldl (inl s x ->
            match s with
            | () -> fst x.dim
            | s -> assert (s = fst x.dim) "The data tensors need to have the same outer dimension."; s
            ) () data

    inl for {data body} s =
        inl {from near_to} = outer data
           
        Loops.for' {
            from near_to
            state=body
            body=inl {next state i} ->
                inl data = Struct.map (inl x -> x i) data
                s.refresh
                inl s = s.RegionMem.create
                state data s {
                    on_fail=inl state ->
                        s.RegionMem.clear
                        state.unwrap
                    on_succ=inl state ->
                        s.RegionMem.clear
                        next state
                    }
            finally=inl state -> state.unwrap
            }

    inl grad_check train {network} = 
        function
        | .unwrap -> 0.0
        | data s {on_fail on_succ} ->
            inl rec perturb cost primal adjoint =
                inl epsilon = to float 0.001
                inl boundary = to float 0.001

                assert (primal.dim = adjoint.dim) "Dimensions must be equal."
                match primal.dim with
                | {from near_to} :: _ ->
                    Loops.for {from near_to body=inl {i} ->
                        perturb cost (primal i) (adjoint i)
                        }
                | _ -> 
                    inl orig = s.CudaTensor.get primal
                    s.CudaTensor.set primal (orig + epsilon)
                    inl cost_plus_epsilon = cost ()
                    s.CudaTensor.set primal(orig - epsilon)
                    inl cost_minus_epsilon = cost ()
                    s.CudaTensor.set primal orig
                    inl approx_gradient = to float (cost_plus_epsilon - cost_minus_epsilon) / (two * epsilon)

                    inl true_gradient = s.CudaTensor.get adjoint
                
                    inl diff = abs (true_gradient - approx_gradient)
                    if diff >= boundary then
                        Console.writeline {true_gradient approx_gradient diff}
                        Console.writeline "--- Gradient checking failure."

            train {network optimizer=inl _ _ -> ()} data s {
                on_fail
                on_succ=inl state ->
                    s.RegionMem.clear
                    inl body = train {network}
                    inl data = Struct.map (inl x -> x.round_split 1) data

                    layer_map (function
                        | {weights stream} -> error_type "Gradient checking is not supported with the wave iteration."
                        | {weights} -> 
                            weights ()
                            |> Struct.iter (inl {primal adjoint} ->
                                inl cost _ = for {data body} s
                                perturb cost primal adjoint
                                )
                        | _ -> ()
                        ) network |> ignore
                    on_succ state
                }

    // #Layers
    inl gid _ = .(to string !GID())
    inl layer d = {d with gid=gid(); block=()}
    
    inl input name size = layer {
        layer_type = .input
        name
        size
        }

    inl stateful layer_type {weights apply size sublayer} = 
        layer {
            layer_type
            size
            sublayer
            weights
            apply
            }

    inl feedforward = stateful .feedforward
    inl recurrent = stateful .recurrent

    inl aux layer_type {apply sublayer size} =
        layer {
            layer_type
            size
            sublayer
            apply
            }

    inl stateless = aux .stateless
    inl non_differentiable = aux .non_differentiable

    inl parallel sublayer = 
        layer {
            layer_type = .parallel
            size = Struct.map (inl x -> x.size) sublayer
            sublayer
            }

    inl error cost label input =
        stateless
            {
            sublayer = input, label
            apply = inl input, label -> cost label input
            size = 1
            }

    inl accuracy label input =
        non_differentiable
            {
            sublayer = input, label
            apply = inl input, label -> accuracy label input
            size = 1
            }

    inl encode =
        {
        one_hot = inl size sublayer ->
            non_differentiable
                {
                sublayer
                apply = encode.one_hot size
                size
                }
        }

    inl sample temp sublayer =
        non_differentiable
            {
            sublayer
            apply = sample temp
            size = 1
            }

    inl Layer = {layer input stateless non_differentiable feedforward recurrent parallel error accuracy encode sample} |> module_map (const stack)

    // #Feedforward
    inl layer initializer activation size sublayer =
        feedforward
            {
            size sublayer
            weights = inl s -> 
                {
                input = initializer (sublayer.size, size) s |> dr s
                bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                } |> heap
            apply = inl weights input -> matmultb (input, weights.input) weights.bias >>= activation
            }

    inl sigmoid = layer Initializer.sigmoid sigmoid
    inl relu = layer Initializer.relu relu
    inl tanh = layer Initializer.tanh tanh
    inl linear = layer Initializer.sigmoid succ

    inl layer_norm =
        inl fwd o i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast {
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n)
                    }
                } (primal i)

        inl bck o r i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast' {
                seq = 
                    {
                    map_in=inl dr,i -> i
                    redo=(+)
                    map_out=inl dr,i sum -> dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl dr,v -> v*v
                    redo=(+)
                    map_out=inl dr,v vv -> dr,v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        top + bot
                    }
                    ,
                    {
                    redo=(+)
                    map_out=inl dv dv_sum adjoint -> adjoint + dv - dv_sum / n
                    }
                } (adjoint r, primal i) (adjoint i)

        inl o i s ->
            inl r = fwd o i s |> dr s
            r, inl _ -> bck o r i s

    /// Layer normalization fused with the relu activation.
    inl layer_norm_relu =
        inl fwd o i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast {
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n) |> relu_fwd
                    }
                } (primal i)

        inl bck o r i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast' {
                seq = 
                    {
                    map_in=inl dr,i -> i
                    redo=(+)
                    map_out=inl dr,i sum -> dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl dr,v -> v*v
                    redo=(+)
                    map_out=inl dr,v vv -> (if v > zero then dr else zero),v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        top + bot
                    }
                    ,
                    {
                    redo=(+)
                    map_out=inl dv dv_sum adjoint -> adjoint + dv - dv_sum / n
                    }
                } (adjoint r, primal i) (adjoint i)

        stack inl o i s ->
            inl r = fwd o i s |> dr s
            r, inl _ -> bck o r i s

    // The feedforward layer with layer norm.
    inl ln o size sublayer =
        feedforward
            {
            size sublayer
            weights = inl s -> 
                {
                input = Initializer.relu (sublayer.size, size) s |> dr s
                bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                } |> heap
            apply = inl weights input -> 
                matmultb (input, weights.input) weights.bias 
                >>= layer_norm_relu o 
            }

    inl highway sublayer =
        feedforward
            {
            size sublayer
            weights = inl s ->
                open Initializer
                inl sigmoid _ = sigmoid (sublayer.size, sublayer.size) s |> dr s
                inl tanh _ = tanh (sublayer.size, sublayer.size) s |> dr s
                inl bias0 _ = s.CudaTensor.zero {elem_type=float; dim=sublayer.size} |> dr s
                {
                input = {
                    h = tanh ()
                    t = sigmoid ()
                    c = sigmoid ()
                    }
                bias = {
                    h = bias0 ()
                    t = bias0 ()
                    c = bias0 ()
                    }
                } |> heap

            apply = inl {input bias} i ->
                open Activation
                inm h = matmultb (i, input.h) bias.h >>= tanh
                inm t = matmultb (i, input.t) bias.t >>= sigmoid
                inm c = matmultb (i, input.c) bias.c >>= sigmoid
                inm x1 = hadmult (h,t)
                inm x2 = hadmult (i,c)
                add (x1, x2)
            }

    inl Pass =
        inl train {d with network} =
            inl rec loop c cost' = 
                function
                | .unwrap -> cost' / to float64 c
                | input s {on_fail on_succ} ->
                    inl cost, {bck} = run network {input state = {}; bck=const ()} s
                    inl cost' = cost' + to float64 (s.CudaTensor.get cost)
                    inl state = loop (c+1) cost'
                    if nan_is cost' then on_fail state
                    else
                        match d with
                        | {optimizer} ->
                            bck()
                            optimize network optimizer s
                        | _ -> ()
                        on_succ state
            loop (dyn 0) (dyn 0.0)

        inl test {d with network} =
            inl rec loop c cost' accuracy' accuracy_max' = 
                function
                | .unwrap -> cost' / to float64 c, accuracy', accuracy_max'
                | input s {on_fail on_succ} ->
                    inl (cost, {value max}), {bck} = run network {input state = {}; bck=const ()} s
                    inl cost' = cost' + to float64 (s.CudaTensor.get cost)
                    inl accuracy' = accuracy' + s.CudaTensor.get value
                    inl accuracy_max' = accuracy_max' + max
                    inl state = loop (c+1) cost' accuracy' accuracy_max'
                    if nan_is cost' then on_fail state
                    else
                        match d with
                        | {optimizer} ->
                            bck()
                            optimize network optimizer s
                        | _ -> ()
                        on_succ state
            loop (dyn 0) (dyn 0.0) (dyn 0) (dyn 0)

        inl Body = 
            {
            train test grad_check=grad_check train
            }
       
        {for Body} |> stackify

    inl Feedforward = 
        {
        Layer={Layer with init layer sigmoid tanh relu linear highway ln} |> stackify
        Pass
        } |> stack
    
    // #Recurrent
    /// The standard recurrent layer.
    inl layer initializer activation size sublayer =
        recurrent 
            {
            size sublayer
            weights = inl s -> 
                {
                input = initializer (sublayer.size, size) s |> dr s
                state = initializer (size, size) s |> dr s
                bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                } |> heap
            apply = inl weights state input -> 
                match state with
                | () -> matmultb (input, weights.input) weights.bias >>= activation
                | state -> matmultb ((input, weights.input), (state, weights.state)) weights.bias >>= activation
                >>= inl x -> succ (x,x)
            }

    inl sigmoid = layer Initializer.sigmoid Activation.sigmoid
    inl linear = layer Initializer.sigmoid succ

    inl lstm size sublayer =
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                inl sigmoid sublayer_size = sigmoid (sublayer_size, size) s |> dr s
                inl tanh sublayer_size = tanh (sublayer_size, size) s |> dr s
                inl weights sublayer_size = {
                    f = sigmoid sublayer_size
                    i = sigmoid sublayer_size
                    o = sigmoid sublayer_size
                    c = tanh sublayer_size
                    }
                inl bias0 _ = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                inl bias init = 
                    inl x = s.CudaTensor.create {elem_type=float; dim=size} 
                    join s.CudaTensor.mmap (const init) x
                    dr s x
                {
                input = weights sublayer.size
                state = weights size
                bias = {
                    f = bias one
                    i = bias0 ()
                    o = bias0 ()
                    c = bias0 ()
                    }
                } |> heap

            apply = inl {input state bias} c i ->
                open Activation
                match c with
                | () ->
                    inm i' = matmultb (i,input.i) bias.i >>= sigmoid
                    inm o = matmultb (i,input.o) bias.o >>= sigmoid
                    inm c' = matmultb (i,input.c) bias.c >>= tanh
                    inm c = hadmult (i', c')
                    inm h' = tanh c
                    inm h = hadmult (o, h')
                    succ (h, (h, c))
                | h, c ->
                    inm f = matmultb ((i,input.f),(h,state.f)) bias.f >>= sigmoid
                    inm i' = matmultb ((i,input.i),(h,state.i)) bias.i >>= sigmoid
                    inm o = matmultb ((i,input.o),(h,state.o)) bias.o >>= sigmoid
                    inm c' = matmultb ((i,input.c),(h,state.c)) bias.c >>= tanh
                    inm c =
                        inm x1 = hadmult (f,c)
                        inm x2 = hadmult (i',c')
                        add (x1, x2)
                    inm h' = tanh c
                    inm h = hadmult (o, h')
                    succ (h, (h, c))
            }

    inl bias0 s size = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
    inl bias s size init = 
        inl x = s.CudaTensor.create {elem_type=float; dim=size} 
        join s.CudaTensor.mmap (const (dyn init)) x
        dr s x

    /// The multiplicative integration RNN.
    inl mi size sublayer = 
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                {
                input = tanh (sublayer.size, size) s |> dr s
                state = tanh (size, size) s |> dr s
                b1 = bias s size one
                b2 = bias s size (to float 0.5)
                b3 = bias s size (to float 0.5)
                b4 = bias0 s size
                } |> heap

            apply = inl {b1 b2 b3 b4 input state} s i ->
                match s with
                | () ->
                    inm i = matmult (i, input)
                    d2_replicate_activation {
                        fwd=inl (b3,b4) i -> b3*i + b4 |> tanh_fwd
                        bck_in=inl (b3,b4) i out -> (i, one) |> Tuple.map ((*) (tanh_bck out))
                        bck_in'=inl (b3,b4) i out -> b3 * tanh_bck out
                        } (b3,b4) i
                | _ ->
                    inm i = matmult (i, input)
                    inm s = matmult (s, state)
                    d2_replicate_activation {
                        fwd=inl (b1,b2,b3,b4) (i,s) -> b1*i*s + b2*s + b3*i + b4 |> tanh_fwd
                        bck_in=inl (b1,b2,b3,b4) (i,s) out -> (i*s, s, i, one) |> Tuple.map ((*) (tanh_bck out))
                        bck_in'=inl (b1,b2,b3,b4) (i,s) out -> (b1*s+b3, b1*i+b2) |> Tuple.map ((*) (tanh_bck out))
                        } (b1,b2,b3,b4) (i,s)
                >>= inl x -> succ (x,x)
            }

    /// Map + layer normalization + relu
    inl map_ln_relu {fwd bck_in bck_in'} =
        inl n bias i = 
            inl a,b = Struct.map (inl o -> {o without block}) i |> HostTensor.zip |> inl x -> x.dim
            Struct.iter (inl {primal adjoint} ->
                inl f x = 
                    inl b' :: () = x.dim
                    assert (b' = b) "The bias has to have a dimension equal to the input"
                f primal; f adjoint
                ) bias
            HostTensor.span b |> to float

        inl fwd' o b i w =
            inl n = n b i
            inl b = Struct.map (inl {primal} -> w.CudaTensor.to_dev_tensor primal) b
            w.CudaKernel.mapi_d1_seq_broadcast {
                mapi_in=inl j i' i -> Struct.map (inl x -> x i' .get) b |> inl b -> fwd b i
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n) |> relu_fwd
                    }
                } (Struct.map primal i)

        inl bck' o r b i w =
            inl n = n b i
            inl b_primals = Struct.map (inl {primal} -> w.CudaTensor.to_dev_tensor primal) b
            inl b_adjoints = Struct.map (inl {adjoint} -> w.CudaTensor.to_dev_tensor adjoint) b
            w.CudaKernel.mapi_d1_seq_broadcast' {
                mapi_in=inl j i' (dr,i) -> 
                    inl b_primals = Struct.map (inl x -> x i' .get) b_primals
                    stack {b_primals i}, dr, fwd b_primals i
                seq = 
                    {
                    map_in=inl bis,dr,i -> i
                    redo=(+)
                    map_out=inl bis,dr,i sum -> bis, dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl bis,dr,v -> v*v
                    redo=(+)
                    map_out=inl bis,dr,v vv -> bis,(if v > zero then dr else zero),v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl bis,dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl bis,dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        bis,top + bot
                    }
                    ,
                    {
                    map_in=snd
                    redo=(+)
                    mapi_out=inl _ i' {b_primals i},dv dv_sum is_adjoints -> 
                        inl dx = dv - dv_sum / n

                        bck_in b_primals i
                        |> Struct.map ((*) dx)
                        // Note: The atomics make training non-deterministic.
                        |> Struct.iter2 (inl a -> atomic_add (a i')) b_adjoints

                        bck_in' b_primals i
                        |> Struct.map ((*) dx)
                        |> Struct.map2 (+) is_adjoints
                    }
                } (adjoint r, Struct.map primal i) (Struct.map adjoint i)

        inl o b i s ->
            inl r = fwd' o b i s |> dr s
            r, inl _ -> bck' o r b i s

    /// The multiplicative integration RNN with layer norm from the 'Normalizing the Normalizers' paper.
    inl miln o size sublayer = 
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                {
                input = relu (sublayer.size, size) s |> dr s
                state = relu (size, size) s |> dr s
                b1 = bias s size one
                b2 = bias s size (to float 0.5)
                b3 = bias s size (to float 0.5)
                b4 = bias0 s size
                } |> heap

            apply = inl {b1 b2 b3 b4 input state} s i ->
                match s with
                | () ->
                    inm i = matmult (i, input)
                    map_ln_relu {
                        fwd=inl (b3,b4) i -> b3*i + b4 
                        bck_in=inl (b3,b4) i -> (i, one) 
                        bck_in'=inl (b3,b4) i -> b3 
                        } o (b3,b4) i
                | _ ->
                    inm i = matmult (i, input)
                    inm s = matmult (s, state)
                    map_ln_relu {
                        fwd=inl (b1,b2,b3,b4) (i,s) -> b1*i*s + b2*s + b3*i + b4
                        bck_in=inl (b1,b2,b3,b4) (i,s) -> (i*s, s, i, one) 
                        bck_in'=inl (b1,b2,b3,b4) (i,s) -> (b1*s+b3, b1*i+b2)
                        } o (b1,b2,b3,b4) (i,s)
                >>= inl x -> succ (x,x)
            }


    inl prune_state state s =
        inl s = s.RegionMem.create
        inl f primal = primal.update_body (inl {x with ar} -> s.RegionMem.assign ar.ptr; x)
        inl state = Struct.map (inl {primal} | primal -> f primal) state
        inl region_clear _ = s.RegionMem.clear        
        state, region_clear

    inl Body =
        inl train {d with network} =
            inl rec loop c cost' (state, region_clear) =
                function
                | .unwrap -> region_clear(); cost' / to float64 c
                | input s {on_fail on_succ} ->
                    inl {from near_to} = outer input
                    Loops.foru {
                        from near_to
                        state=const zero, {state bck=const ()}
                        body=inl {state=cost',d i} ->
                            inl input = Struct.map ((|>) i) input
                            
                            // Note: Now that the memory transfers are async, run_parallel has a race condition, but it won't be an issue in practice.
                            inl cost, d = run_parallel network {d with input} s

                            inl bck = term_cast d.bck ()
                            inl get = s.CudaTensor.get
                            inl cost _ = cost'() + get cost
                            term_cast cost (), {d with bck without input}
                        finally=inl cost, {bck state} ->
                            inl cost' = cost' + to float64 (cost ())
                            inl state = loop (c+1) cost' (prune_state state s)

                            if nan_is cost' then 
                                region_clear()
                                on_fail state
                            else
                                match d with
                                | {optimizer} ->
                                    bck()
                                    join optimize network optimizer s
                                | _ -> ()
                                region_clear()
                                on_succ state
                        }
            loop (dyn 0) (dyn 0.0) ({}, const ())
        {
        train grad_check=grad_check train
        } |> stackify

    inl sample' temp near_to network input s =
        Loops.foru {
            from=0; near_to 
            state=(), {}, const (), input
            body=inl {state=buffer,state,region_clear,input i} ->
                s.refresh
                inb s = s.RegionMem.create'
                inl input,{state} = run (sample temp network) {input={input}; bck=const (); state} s
                inl input_host = s.CudaTensor.to_host_tensor input |> stack
                inl buffer =
                    match buffer with
                    | () -> ResizeArray.create {elem_type=input_host}
                    | _ -> buffer
                buffer.add input_host
                
                inl (input, state), region_clear' = prune_state (input, state) s
                region_clear()
                buffer, state, region_clear', input
            finally=inl buffer,state,region_clear, input ->
                region_clear()
                buffer
            }

    inl sample temp near_to body x s =
        inb s = s.RegionMem.create'
        inl input = s.CudaTensor.create {elem_type=int64; dim=1}
        s.CudaTensor.set (input 0) (to int64 x)
        inl r = sample' temp near_to body input s
        Console.writeline "Sample:"
        r.iter (inl x -> Console.write (x 0 .get |> to char))
        Console.writeline ()
        Console.writeline "-----"

    inl Recurrent = 
        {
        Layer = {Layer with init init_parallel layer sigmoid linear lstm mi miln} |> stackify
        Pass = {for sample Body} |> stackify
        } |> stackify

    /// The differentiable action selectors.
    inl Selector =
        inl reduce_actions x s = 
            s.CudaKernel.mapi_d1_redo_map {
                mapi_in=inl j i v _ -> v, i
                neutral_elem=-infinity,-1
                redo=inl a b -> if fst a > fst b then a else b
                } (primal x) ()
            |> HostTensor.unzip
        {
        greedy_square = inl x s ->
            inl v,a = reduce_actions x s

            (v, a), inl (reward: float64) ->
                inl reward = to float reward
                inl a, x, v = Tuple.map s.CudaTensor.to_dev_tensor (a, adjoint x, v)
                s.CudaKernel.iter () (inl j ->
                    inl a, v = Tuple.map (inl x -> x j .get) (a, v)
                    inl x = x j a
                    x.set (x.get + square_bck (v, reward))
                    ) a.dim

        greedy_qr = inl k x s ->
            inl dim_a,dim_b,dim_c as dim = (primal x).dim
            inl dim_c' = to float (HostTensor.span dim_c)
            inl v,a =
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
                    map_out = inl a, i -> a / dim_c', i
                    } (primal x)
                |> HostTensor.unzip

            (v, a), inl (reward: float64) ->
                inl reward = to float reward
                inl a, x_a, x_p = Tuple.map s.CudaTensor.to_dev_tensor (a, adjoint x, primal x)

                s.CudaKernel.iter () (inl j ->
                    inl a = a j .get
                    inl x_a, x_p = Tuple.map (inl x -> x j a) (x_a, x_p)
                    inl i ->
                        inl x_a, x_p = Tuple.map (inl x -> x i) (x_a, x_p)
                        inl quantile = (to float i - to float 0.5) / dim_c'
                        x_a.set (x_a.get + HQR.bck_a k quantile (x_p.get, reward))
                    ) (dim_a,dim_c)

        greedy_kl = inl x s ->
            inl dim_a,dim_b,dim_c as dim = (primal x).dim

            inl index c x next = 
                inl f i = Struct.map ((|>) i)
                inl rec loop c x =
                    if c > 0 then inl i -> loop (c-1) (f i x)
                    else next x
                assert (lit_is c && c >= 0) "c must be a literal greater or equal to zero."
                loop c x

            inl v,a =
                inl o = s.CudaTensor.create {elem_type=float; dim=dim_a, dim_b}
                inl _ = 
                    inl x,o = Tuple.map s.CudaTensor.to_dev_tensor (primal x, o)
                    s.CudaKernel.iteri_dd1_seq_broadcast { 
                        mapi_in =
                            inb x = index 3 x
                            x.get
                        seq = 
                            {
                            redo=max
                            map_out=inl x max_x -> exp (x - max_x) 
                            }
                            ,
                            {
                            redo=(+)
                            mapi_out=inl k j i z sum_z -> 
                                inl z = z / sum_z
                                z * to float i
                            }
                            ,
                            {
                            redo'=(+)
                            mapi_out=
                                inb o = index 2 o
                                inl _ _ sum -> if threadIdx.x = 0 then o.set sum
                            }
                        } dim
                reduce_actions o s            
            //Console.printfn "{0}, {1}" (s.CudaTensor.get (v 0), s.CudaTensor.get (a 0))

            (v, a), inl (reward: float64) ->
                inl reward = to int64 reward

                assert (dim_c.from <= reward && reward < dim_c.near_to) "The reward must be in range."
                inl a, x_p, x_a = Tuple.map s.CudaTensor.to_dev_tensor (a, primal x, adjoint x)
                s.CudaKernel.iteri_d1_seq_broadcast { 
                    mapi_in = inl j ->
                        inl a = a j .get
                        inl x_p = x_p j a
                        inl i -> a, x_p i .get
                    seq = 
                        {
                        map_in=snd
                        redo=max
                        map_out=inl (a,x) max_x -> a, exp (x - max_x) 
                        }
                        ,
                        {
                        map_in=snd
                        redo=(+)
                        mapi_out=inl j ->
                            inl x_a = x_a j
                            inl i (a,z) sum_z -> 
                                inl p = z / sum_z
                                inl reward = if i = reward then one else zero
                                inl o = p - reward
                                inl x_a = x_a a i
                                x_a .set (x_a .get + o)
                        }
                    } (dim_a, dim_c)
        }

    inl RL = 
        inl greedy_square sublayer =
            Layer.layer {
                layer_type = .action
                size = 1
                sublayer
                weights = const ()
                apply = inl _ -> Selector.greedy_square
                }

        inl greedy_qr k dist_size sublayer =
            Layer.layer {
                layer_type = .action
                size = 1
                sublayer
                weights = const ()
                apply = inl _ x s -> 
                    inl f x = x.split (inl a,b -> a,(b/dist_size,dist_size))
                    Struct.map (function
                        | {primal adjoint block} as x -> {x with primal=f self; adjoint=f self}
                        | x -> f x
                        ) x
                    |> inl x -> Selector.greedy_qr k x s
                }

        inl greedy_kl {reward_range with from near_to} sublayer =
            Layer.layer {
                layer_type = .action
                size = 1
                sublayer
                weights = const ()
                apply = inl _ x s -> 
                    inl f x = x.split (inl a,b -> a, (b / HostTensor.span reward_range, reward_range))
                    Struct.map (function
                        | {primal adjoint block} as x -> {x with primal=f self; adjoint=f self}
                        | x -> f x
                        ) x
                    |> inl x -> Selector.greedy_kl x s
                }

        inl square_init {range state_type action_type} s =
            inl size = Struct.foldl (inl s x -> s + SerializerOneHot.span range x) 0
            inl state_size = size state_type
            inl action_size = size action_type

            input .input state_size
            //|> Feedforward.Layer.ln 0f32 256
            //|> Feedforward.Layer.relu 256
            |> Recurrent.Layer.mi 256
            |> Feedforward.Layer.linear action_size
            |> init s

        inl qr_init {distribution_size range state_type action_type} s =
            inl size = Struct.foldl (inl s x -> s + SerializerOneHot.span range x) 0
            inl state_size = size state_type
            inl action_size = size action_type * distribution_size

            input .input state_size
            //|> Feedforward.Layer.ln 0f32 256
            //|> Feedforward.Layer.relu 256
            |> Feedforward.Layer.linear action_size
            |> init s

        inl kl_init {reward_range range state_type action_type} s =
            inl size = Struct.foldl (inl s x -> s + SerializerOneHot.span range x) 0
            inl state_size = size state_type
            inl action_size = size action_type * HostTensor.span reward_range

            input .input state_size
            |> Recurrent.Layer.miln 0.05f32 256
            |> Recurrent.Layer.miln 0.05f32 256
            //|> Feedforward.Layer.ln 0f32 256
            //|> Feedforward.Layer.relu 256
            |> Feedforward.Layer.linear action_size
            |> init s

        /// For online learning.
        inl action {d with range state_type action_type net state} i s =
            indiv join
                assert (eq_type state_type i) "The input must be equal to the state type."
                inl input = 
                    Struct.foldl_map (inl s x -> 
                        inl i, s' = SerializerOneHot.encode' range x
                        s + i, s + s'
                        ) 0 i
                    |> inl l,size -> 
                        s.CudaKernel.init {dim=1,size} (inl _ x -> Struct.foldl (inl s x' -> if x = x' then one else s) zero l)
                inl (v,a),{state bck} = 
                    match d with 
                    | {distribution_size} -> greedy_qr one distribution_size
                    | {reward_range} -> greedy_kl reward_range
                    | _ -> greedy_square
                    |> inl runner -> run (runner net) {state input={input}; bck=const()} s
                inl action = SerializerOneHot.decode range (s.CudaTensor.get (a 0)) action_type
                stack (action, {bck state})
        {square_init qr_init kl_init action}

    { 
    dr primal primals adjoint adjoints (>>=) succ Primitive Activation Optimizer Initializer Error Layer Combinator Feedforward Recurrent
    Selector RL
    }
    """) |> module_
