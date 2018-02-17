module Learning.Modules

open Spiral.Types
open Spiral.Lib

let resize_array =
    (
    "ResizeArray",[extern_],"The resizable array module.",
    """
open Extern
inl create {d with elem_type} =
    inl ty = fs [text: "ResizeArray"; types: elem_type]
    inl x =
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

    function
    | .sort -> sort 
    | .filter -> filter 
    | .set -> set
    | .clear -> clear ()
    | .count -> count ()
    | .add -> add
    | .iter -> iter
    | .elem_type -> elem_type
    | i -> index i
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
    |> stack

inl mult = 256u64
assert (mult <> 0u64 && (mult &&& mult - 1u64) = 0u64) "Multiple must be a power of 2." 
inl round_up_to_multiple size = (size + mult - 1u64) &&& 0u64 - mult

inl to_uint x = FS.UnOp .uint64 x uint64
inl allocate_global s =
    to uint64 >> round_up_to_multiple >> dyn
    >> inl size -> { size ptr = FS.Method s.context .AllocateMemory (SizeT size) CUdeviceptr_type |> to_uint |> smartptr_create }

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32
inl sort_ptrs x = x.sort (inl {ptr=a} {ptr=b} -> compare (a()) (b()))
inl sort_sizes x = x.sort (inl {size=a} {size=b} -> compare a b)

met free_cells_refresh {section with pool free_cells used_cells} = 
    used_cells.filter (inl {ptr} -> ptr.Try = 0u64)
    sort_ptrs used_cells
    free_cells.clear
    inl near_to = used_cells.count
    inl add {ptr size} = 
        inl ptr = ptr()
        inl ptr' = round_up_to_multiple ptr
        inl d = ptr' - ptr
        if size >= d then free_cells.add {ptr = smartptr_create ptr'; size=size-d}

    inl start x = x.ptr()
    inl end x = x.ptr() + x.size

    Loops.for {from=0i32; near_to by=1i32; state={pool with size = 0u64}; body=inl {{state with ptr} i} ->
        inl state' = free_cells i
        inl size = start state' - end state
        add { ptr size }
        state'
        }
    |> inl state -> // This is for the final free cell at the end.
        inl size = end pool - start state
        add {state with size}

met allocate {section with free_cells} (!(to uint64 >> round_up_to_multiple >> dyn) size') =
    inl loop next =
        inl {ptr size} = free_cells 0i32
        if size' <= size then
            free_cells.set 0i32 {ptr=smartptr_create (ptr.Try+size'); size=size-size'}
            {ptr size=size'}
        else next()

    inl {ptr} =
        loop <| inl _ ->
            sort_sizes free_cells
            loop <| inl _ -> 
                free_cells_refresh section
                sort_sizes free_cells
                loop <| inl _ ->
                    failwith free_cells.elem_type "Out of memory in the designated section."
    ptr

inl section_create s size ret =
    inl pool = allocate_global s size
    inl elem_type = type pool
    inl free_cells, used_cells = ResizeArray.create {elem_type}, ResizeArray.create {elem_type}
    inl section = {pool free_cells used_cells}
    free_cells_refresh section

    inl allocate _ = 
        function
        | .elem_type -> type elem_type.ptr
        | .refresh -> free_cells_refresh section
        | x -> allocate section x
        |> heap

    inl r = s.module_add .Section {allocate} |> ret

    inl ptr = pool.ptr
    FS.Method s.context .FreeMemory (ptr() |> CUdeviceptr) unit
    ptr.Dispose
    r

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
    |> heap

inl assign {region_name} s r = 
    inl region = s region_name
    join r.inc; region.add r

inl allocate d s (!dyn x) =
    inl allocate = d.allocate s
    join
        inl r = allocate x |> counter_ref_create
        assign d s r; r

inl allocate_mem d s (!dyn x) =
    inl allocate = d.allocate s
    join
        inl r = allocate x |> counter_ref_create
        assign d s r; r

inl allocate_stream d s =
    inl allocate = d.allocate s
    join
        inl r = counter_ref_create allocate
        assign d s r; r
    |> (const >> s.member_add .stream)

inl clear {region_name} s =
    inl region = s region_name
    join 
        region.iter (inl r -> r.dec)
        region.clear

inl create {region_name allocate} s = 
    inl elem_type = type counter_ref_create (var (allocate s).elem_type)
    inl region = ResizeArray.create {elem_type}
    s.member_add region_name (const region)

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
    } |> stack

inl methods_mem = 
    inl region_module_name = .RegionMem
    inl d = {
        region_module_name
        region_name = .region_mem
        allocate = inl s -> s.Section.allocate
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
    region_module_name, {x with
        allocate = allocate_stream d 
        create = inl s -> (self s).RegionStream.allocate
        }

inl s -> 
    inl add s (a, b) = s.module_add a b
    Tuple.foldl add s (methods_mem, methods_stream)
    """) |> module_

let cuda_stream = 
    (
    "CudaStream",[extern_],"The Cuda stream module.",
    """
open Extern
inl ty x = fs [text: x]
inl CudaStream_type = ty "ManagedCuda.CudaStream"
inl CUstream_type = ty "ManagedCuda.BasicTypes.CUstream"
inl dispose x = FS.Method x .Dispose () ()

inl rec allocate _ =
    inl is_live = ref true
    inl stream = FS.Constructor CudaStream_type ()
    function
    | .Dispose -> 
        dispose stream
        is_live := false
    | .elem_type -> type allocate ()
    | x -> join
        assert (is_live()) "The stream has been disposed."
        match x with
        | .extract -> macro.fs CUstream_type [arg: stream; text: ".Stream"]
        | .synchronize -> FS.Method stream .Synchronize() ()
        | .wait_on on ->
            inl event_type = fs [text: "ManagedCuda.CudaEvent"]
            inl event = FS.Constructor event_type ()
            FS.Method event .Record on.extract ()
            macro.fs () [arg: stream; text: ".WaitEvent "; arg: event; text: ".Event"]
            dispose event
        | () -> stream
    |> heap

inl s -> s.module_add .Stream {allocate}
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
inl assert_curesult res = macro.fs unit [text: "if "; arg: res; text: " <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException"; args: res]
inl memcpy dst_ptr src_ptr size = macro.fs CUResult_ty [text: "ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy"; args: CUdeviceptr dst_ptr, CUdeviceptr src_ptr, SizeT size] |> assert_curesult

inl GCHandle_ty = fs [text: "System.Runtime.InteropServices.GCHandle"]
inl ptr_dotnet {ar offset} ret =
    inl elem_type = ar.elem_type
    inl handle = macro.fs GCHandle_ty [type:GCHandle_ty; text: ".Alloc"; parenth: [arg: ar; text: "System.Runtime.InteropServices.GCHandleType.Pinned"]]
    inl r =
        macro.fs int64 [arg: handle; text: ".AddrOfPinnedObject().ToInt64()"] 
        |> to uint64 |> (+) (to uint64 (offset * sizeof elem_type)) |> ret
    macro.fs unit [arg: handle; text: ".Free()"]
    r

inl copy span dst {src with ar size ptr_get} =
    inl elem_type = ar.elem_type 
    assert (blittable_is elem_type) "The host array type must be blittable."
    inl span_size = match size with () -> span | size :: _ -> span * size
    inb src = ptr_get src
    inl memcpy dst = memcpy dst src (span_size * sizeof elem_type)
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
    inl f = tns.dim |> fst |> span |> f
    tns.update_body <| inl body -> {body with ar = f body}

inl methods = 
    {
    array_create_cuda_global=inl s elem_type len ->
        inl ptr = s.RegionMem.allocate (len * sizeof elem_type)
        function // It needs to be like this rather than a module so toa_map does not split it.
        | .elem_type -> elem_type
        | .ptr -> ptr
        |> stack
    create=inl s data -> create {data with array_create = s.CudaTensor.array_create_cuda_global}
    create_like=inl s tns -> s.CudaTensor.create {elem_type=tns.elem_type; dim=tns.dim}

    from_host_array=met s (!dyn span) (!dyn {src with ar offset size}) ->
        copy span {array_create=s.CudaTensor.array_create_cuda_global; ptr_get=ptr_cuda} {src with ptr_get=ptr_dotnet}

    to_host_array=met s (!dyn span) (!dyn {src with ar offset size}) ->
        copy span {array_create ptr_get=ptr_dotnet} {src with ptr_get=ptr_cuda}

    get_elem=inl s {src with size=()} -> s.CudaTensor.to_host_array 1 src 0
    set_elem=met s (!dyn {dst with size=()}) (!dyn v) ->
        inl ar = array_create v 1
        ar 0 <- v
        copy 1 {dst with ptr_get=ptr_cuda} {ar size=(); offset=0; ptr_get=ptr_dotnet}

    get=inl s tns ->
        match tns.unwrap with
        | {bodies dim=()} -> toa_map s.CudaTensor.get_elem bodies
        | _ -> error_type "Cannot get from tensor whose dimensions have not been applied completely."

    set=inl s tns v ->
        match tns.unwrap with
        | {bodies dim=()} -> toa_iter2 s.CudaTensor.set_elem bodies v
        | _ -> error_type "Cannot set to a tensor whose dimensions have not been applied completely."

    from_host_tensor=inl s -> transfer_template s.CudaTensor.from_host_array
    from_host_tensors=inl s -> toa_map s.CudaTensor.from_host_tensor
    to_host_tensor=inl s -> transfer_template s.CudaTensor.to_host_array

    to_dev_tensor=inl s tns -> tns.update_body (inl body -> 
        inb ptr = ptr_cuda body
        {body with ar=!UnsafeCoerceToArrayCudaGlobal(ptr,body.ar.elem_type); offset=0}
        )

    clear=inl s tns ->
        assert_contiguous tns
        inl span = tns.dim |> fst |> span
        inl stream = s.stream.extract
        tns.update_body <| inl {body with size=size::_ ar} ->
            FS.Method s.context .ClearMemoryAsync (CUdeviceptr (ar.ptr()), 0u8, size * span * sizeof ar.elem_type |> SizeT, stream) unit
        |> ignore

    clear'=inl s x -> s.CudaTensor.clear x; x
    zero=inl s -> s.CudaTensor.create >> s.CudaTensor.clear'
    zero_like=inl s -> s.CudaTensor.create_like >> s.CudaTensor.clear'

    print=met s (!dyn x) -> s.CudaTensor.to_host_tensor x |> HostTensor.print
    } |> stack

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
    
    use random = 
        inl generator_type = fs [text: "ManagedCuda.CudaRand.GeneratorType"]
        FS.Constructor (fs [text: "ManagedCuda.CudaRand.CudaRandDevice"]) (FS.StaticField generator_type .PseudoDefault generator_type)
    
    open HostTensor
    
    inl fill_array s distribution (!SizeT size1d) ar =
        FS.Method random .SetStream s.stream.extract unit
        inl elem_type = ar.elem_type
        inl ar = CUdeviceptr ar
        inl gen, dot = "Generate", "."
        match distribution with
        | .Uniform ->
            inl args = ar, size1d
            inl bits = 
                match elem_type with
                | _ : float32 -> "32" | _ : float64 -> "64"
                | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
            macro.fs unit [arg: random; text: dot; text: gen; text: distribution; text: bits; args: args]
        | {dst=(.Normal | .LogNormal) & distribution stddev mean} ->
            match stddev with | _: float32 -> () | _ -> error_type "Standard deviation needs to be in float32."
            match mean with | _: float32 -> () | _ -> error_type "Mean needs to be in float32."

            inl args = ar, size1d, mean, stddev
            inl bits = 
                match elem_type with
                | _ : float32 -> "32" | _ : float64 -> "64"
                | _ -> error_type ("Only 32/64 bit float types are supported. Try UInt if you need uint random numbers. Got: ", elem_type)
            macro.fs unit [arg: random; text: dot; text: gen; text: distribution; text: bits; args: args]
        | .UInt -> // every bit random
            inl args = ar, size1d
            inl bits =
                match elem_type with
                | _ : uint32 -> "32" | _ : uint64 -> "64"
                | _ -> error_type "Only 32/64 bit uint types are supported."
            macro.fs unit [arg: random; text: dot; text: gen; text: bits; args: args]

    inl fill s op (!zip in) =
        inl in' = flatten in |> s.CudaTensor.to_dev_tensor
        inl len = in'.length
        in'.update_body (inl {ar} -> fill_array s op len ar) |> ignore

    inl create s op dsc =
        inl device_tensor = s.CudaTensor.create dsc
        fill s op device_tensor
        device_tensor

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

    use cublas =
        inl cublas_type = fs [text: "ManagedCuda.CudaBlas.CudaBlas"]
        inl pointer_mode_type = fs [text: "ManagedCuda.CudaBlas.PointerMode"]
        inl atomics_mode_type = fs [text: "ManagedCuda.CudaBlas.AtomicsMode"]
        FS.Constructor cublas_type (enum pointer_mode_type .Host, enum atomics_mode_type .Allowed)

    inl handle = FS.Method cublas .get_CublasHandle() (fs [text: "ManagedCuda.CudaBlas.CudaBlasHandle"])

    open HostTensor
    inl call s method args = 
        inl to_dev_tensor x = assert_contiguous x; s.CudaTensor.to_dev_tensor x
        inl args = Tuple.map (function x : int64 -> to int32 x | x -> x) args
        join 
            FS.Method cublas .set_Stream s.stream.extract ()
            inl args = 
                Tuple.map (function 
                    | x : float64 | x : float32 -> ref x
                    | (.nT | .T) as x -> to_operation x
                    | {ptr=!to_dev_tensor x} -> x.bodies.ar |> CUdeviceptr
                    | x -> x
                    ) args
            inl native_type = fs [text: "ManagedCuda.CudaBlas.CudaBlasNativeMethods"]
            inl status_type = fs [text: "ManagedCuda.CudaBlas.CublasStatus"]
            inl assert_ok status = macro.fs unit [text: "if "; arg: status; text: " <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException"; args: status]
            FS.StaticMethod native_type method args status_type |> assert_ok

    /// General matrix-matrix multiply from cuBLAS. Inplace version
    inl gemm' s transa transb alpha A B beta C =
        inl a_col = if isnT transa then cols A else rows A
        inl b_row = if isnT transb then rows B else cols B
        assert (a_col = b_row) "Colums of a does not match rows of b in GEMM."

        inl m = if isnT transa then rows A else cols A
        inl n = if isnT transb then cols B else rows B
        inl k = a_col
        
        assert (m = rows C && n = cols C) "Output matrix dimensions do not match in GEMM."

        // The arguments are switched in order to convert from column major (which CuBlas uses) to row major (which Spiral's tensor use)
        call s .cublasSgemm_v2(handle, transb, transa, n, m, k, alpha, {ptr=B}, ld B, {ptr=A}, ld A, beta, {ptr=C}, ld C)

    inl gemm s transa transb alpha A B =
        inl m = if isnT transa then rows A else cols A
        inl n = if isnT transb then cols B else rows B

        inl C = s.CudaTensor.create {dim=m,n; elem_type = A.elem_type}
        gemm' s transa transb alpha A B (to alpha 0) C
        C

    ret <| s.module_add .CudaBlas {gemm' gemm}
    """) |> module_

