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
inl {Cuda} ->
    open Cuda
    open Extern
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
    inl round_up_to_multiple size = size - size % mult + mult

    inl allocate_global =
        to uint64 >> round_up_to_multiple >> dyn
        >> inl size -> { size ptr = FS.Method context .AllocateMemory (SizeT size) CUdeviceptr_type |> to_uint |> smartptr_create }

    inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32
    inl sort_ptrs x = x.sort (inl {ptr=a} {ptr=b} -> compare (a()) (b()))

    met free_cells_refresh {section with pool free_cells used_cells} = 
        used_cells.filter (inl {ptr} -> ptr.Try = 0u64)
        sort_ptrs used_cells
        free_cells.clear
        inl near_to = used_cells.count
        inl add {ptr size} = free_cells.add {ptr = smartptr_create (ptr()); size}

        inl distance state state' = 
            inl p1 = state.ptr() + state.size
            inl p2 = state.ptr()
            p2 - p1
            
        Loops.for {from=0i32; near_to by=1i32; state={pool with size = 0u64}; body=inl {{state with ptr} i} ->
            inl state' = free_cells i
            inl size = distance state state'
            if size > 0u64 then add { ptr size }
            state'
            }
        |> inl state -> // This is for the final free cell at the end.
            inl size = distance pool state
            add {state with size}

    met allocate {section with free_cells} (!(to uint64 >> dyn) size') =
        inl loop next =
            inl {ptr size} = free_cells 0i32
            if size' <= size then
                free_cells.set 0i32 {ptr=smartptr_create (ptr.Try+size'); size=size-size'}
                {ptr size=size'}
            else next()

        inl {ptr} =
            loop <| inl _ ->
                sort_ptrs free_cells
                loop <| inl _ -> 
                    free_cells_refresh section
                    sort_ptrs free_cells
                    loop <| inl _ ->
                        failwith free_cells.elem_type "Out of memory in the designated section."
        ptr

    inl size ret ->
        inl pool = allocate_global size
        inl elem_type = type pool
        inl free_cells, used_cells = ResizeArray.create {elem_type}, ResizeArray.create {elem_type}
        inl section = {pool free_cells used_cells}
        free_cells_refresh section
        inl r = ret function
            | .elem_type -> type elem_type.ptr
            | .refresh -> free_cells_refresh section
            | x -> allocate section x

        inl ptr = pool.ptr
        FS.Method context .FreeMemory (ptr() |> CUdeviceptr) unit
        ptr.Dispose
        r
    """) |> module_

let region =
    (
    "Region",[resize_array],"The region based resource tracker.",
    """
inl create' create =
    inl counter_ref_create ptr =
        inl count = ref 0
        function
        | .inc -> count := count() + 1
        | .dec -> 
            count := count() - 1
            if count() = 0 then ptr.Dispose
        | x -> ptr x
        |> stack

    inl elem_type = type counter_ref_create (var create.elem_type)
    inl region = ResizeArray.create {elem_type}

    met assign (r: elem_type) = r.inc; region.add r
    met allocate (!dyn x) = 
        inl r = create x |> counter_ref_create
        assign r
        r
        
    met clear _ =
        region.iter (inl r -> r.dec)
        region.clear

    function
    | .assign -> assign
    | .elem_type -> elem_type
    | .clear -> clear()
    | i -> allocate i

inl create x ret = 
    inl region = create' x
    inl r = ret region
    region.clear
    r

{create create'}
    """) |> module_

let cuda_stream = 
    (
    "CudaStream",[extern_],"The Cuda stream module.",
    """
inl {Cuda} ->
    open Extern
    inl ty x = fs [text: x]
    inl CudaStream_type = ty "ManagedCuda.CudaStream"
    inl CUstream_type = ty "ManagedCuda.BasicTypes.CUstream"

    inl create' _ = 
        inl stream = FS.Constructor CudaStream_type ()
        inl is_live = ref true
        inl dispose x = FS.Method x .Dispose () ()
        function
        | .Dispose -> 
            dispose stream
            is_live := false
        | x ->
            assert (is_live()) "The stream has been disposed."
            match x with
            | .extract -> macro.fs CUstream_type [arg: stream; text: ".Stream"]
            | .synchronize -> FS.Method stream .Synchronize() ()
            | .wait_on on -> join
                inl event_type = fs [text: "ManagedCuda.CudaEvent"]
                inl event = FS.Constructor event_type ()
                FS.Method event .Record on.extract ()
                macro.fs () [arg: stream; text: ".WaitEvent "; arg: event; text: ".Event"]
                dispose event
            | () -> stream
        |> stack

    inl create = function
        | .elem_type -> type create' ()
        | () -> create' ()

    {create}
    """) |> module_

let cuda_tensor = 
    (
    "CudaTensor",[option;extern_;host_tensor],"The Cuda tensor module.",
    """
inl {Cuda} d ->
    open Cuda
    open HostTensor
    open Extern

    /// Is just a CUdeviceptr rather than the true array.
    inl array_create_cuda_global elem_type len = // TODO: Why does this diverge when `|> stack`ed.
        inl ptr = d.allocate (len * sizeof elem_type)
        function // It needs to be like this rather than a module so toa_map does not split it.
        | .elem_type -> elem_type
        | .ptr -> ptr
        |> stack
    inl create data = create {data with array_create = array_create_cuda_global}
    inl create_like tns = create {elem_type=tns.elem_type; dim=tns.dim}

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

    met from_host_array (!dyn span) (!dyn {src with ar offset size}) =
        copy span {array_create=array_create_cuda_global; ptr_get=ptr_cuda} {src with ptr_get=ptr_dotnet}

    met to_host_array (!dyn span) (!dyn {src with ar offset size}) =
        copy span {array_create ptr_get=ptr_dotnet} {src with ptr_get=ptr_cuda}

    inl get_elem {src with size=()} = to_host_array 1 src 0
    met set_elem (!dyn {dst with size=()}) (!dyn v) =
        inl ar = array_create v 1
        ar 0 <- v
        copy 1 {dst with ptr_get=ptr_cuda} {ar size=(); offset=0; ptr_get=ptr_dotnet}

    inl get tns = 
        match tns.unwrap with
        | {bodies dim=()} -> toa_map get_elem bodies
        | _ -> error_type "Cannot get from tensor whose dimensions have not been applied completely."

    inl set tns v = 
        match tns.unwrap with
        | {bodies dim=()} -> toa_iter2 set_elem bodies v
        | _ -> error_type "Cannot set to a tensor whose dimensions have not been applied completely."

    inl transfer_template f tns = 
        assert_contiguous tns
        inl f = tns.dim |> fst |> span |> f
        tns.update_body <| inl body -> {body with ar = f body}

    inl from_host_tensor tns = transfer_template from_host_array tns
    inl to_host_tensor tns = transfer_template to_host_array tns
    inl to_dev_tensor tns = tns.update_body (inl body -> 
        inb ptr = ptr_cuda body
        {body with ar=!UnsafeCoerceToArrayCudaGlobal(ptr,body.ar.elem_type); offset=0}
        )

    inl clear tns = 
        assert_contiguous tns
        inl span = tns.dim |> fst |> span
        inl stream = d.stream.extract
        tns.update_body <| inl {body with size=size::_ ar} ->
            FS.Method context .ClearMemoryAsync (CUdeviceptr (ar.ptr()),0u8,size * span * sizeof ar.elem_type |> SizeT,stream) unit
        |> ignore

    inl clear' x = clear x; x
    inl zero = create >> clear'
    inl zero_like = create_like >> clear'

    inl from_host_tensors x ret = 
        inl tensors = toa_map from_host_tensor x
        inl r = ret tensors
        toa_map (inl x -> x.update_body (inl {ar} -> ar.ptr.Dispose)) |> ignore
        r

    met print (!dyn o1) = to_host_tensor o1 |> HostTensor.print

    {create from_host_tensor from_host_tensors to_host_tensor to_dev_tensor clear zero zero_like print get set}
    """) |> module_