module Modules

open Spiral.Types
open Spiral.Lib

//let cuda_stream = 
//    "CudaStream",[extern_],"The Cuda stream module.",
//    """
//inl {Cuda} ->
//    open Extern
//    inl ty x = fs [text: x]
//    inl CudaStream_type = ty "ManagedCuda.CudaStream"
//    inl CUstream_type = ty "ManagedCuda.BasicTypes.CUstream"

//    inl create ret = 
//        use stream = FS.Constructor CudaStream_type ()
//        ret function
//            | .extract -> extract stream
//            | .get -> FS.Method x .get_Stream() CUstream_type 
//            | .wait_on -> () // TODO
            
//    inl async ret = 
//        inb stream = create
//        inl r = ret stream

//    {create}
//    """

//let cuda_tensor = 
//    (
//    "CudaTensor",[option;extern_;host_tensor],"The Cuda tensor module.",
//    """
//inl {current_region current_stream Cuda} ->
//    open Cuda
//    open HostTensor
//    open Extern

//    /// Is just a CUdeviceptr rather than the true array.
//    inl array_create_cuda_global elem_type len = // TODO: Why does this diverge when `|> stack`ed.
//        inl ptr = current_region (len * sizeof elem_type)
//        function // It needs to be like this rather than a module so toa_map does not split it.
//        | .elem_type -> elem_type
//        | .ptr -> ptr
//        |> stack
//    inl create data = create {data with array_create = array_create_cuda_global}
//    inl create_like tns = create {elem_type=tns.elem_type; dim=tns.dim}

//    inl ptr_cuda {ar offset} ret = ar.ptr() + to uint64 (offset * sizeof ar.elem_type) |> ret
//    inl CUResult_ty = fs [text: "ManagedCuda.BasicTypes.CUResult"]
//    inl assert_curesult res = macro.fs unit [text: "if "; arg: res; text: " <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException"; args: res]
//    inl memcpy dst_ptr src_ptr size = macro.fs CUResult_ty [text: "ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy"; args: CUdeviceptr dst_ptr, CUdeviceptr src_ptr, SizeT size] |> assert_curesult

//    inl GCHandle_ty = fs [text: "System.Runtime.InteropServices.GCHandle"]
//    inl ptr_dotnet {ar offset} ret =
//        inl elem_type = ar.elem_type
//        inl handle = macro.fs GCHandle_ty [type:GCHandle_ty; text: ".Alloc"; parenth: [arg: ar; text: "System.Runtime.InteropServices.GCHandleType.Pinned"]]
//        inl r =
//            macro.fs int64 [arg: handle; text: ".AddrOfPinnedObject().ToInt64()"] 
//            |> to uint64 |> (+) (to uint64 (offset * sizeof elem_type)) |> ret
//        macro.fs unit [arg: handle; text: ".Free()"]
//        r

//    inl copy span dst {src with ar size ptr_get} =
//        inl elem_type = ar.elem_type 
//        assert (blittable_is elem_type) "The host array type must be blittable."
//        inl span_size = match size with () -> span | size :: _ -> span * size
//        inb src = ptr_get src
//        inl memcpy dst = memcpy dst src (span_size * sizeof elem_type)
//        match dst with
//        | {ar size=size' ptr_get} -> 
//            assert (size' = size) "The source and the destination must have the same sizes."
//            assert (eq_type ar.elem_type elem_type) "The source and the destination must have the same types"
//            inb dst = ptr_get dst
//            memcpy dst
//        | {array_create ptr_get} -> 
//            inl ar = array_create elem_type span_size
//            inb dst = ptr_get {ar offset=0}
//            memcpy dst
//            ar

//    met from_host_array (!dyn span) (!dyn {src with ar offset size}) =
//        copy span {array_create=array_create_cuda_global; ptr_get=ptr_cuda} {src with ptr_get=ptr_dotnet}

//    met to_host_array (!dyn span) (!dyn {src with ar offset size}) =
//        copy span {array_create ptr_get=ptr_dotnet} {src with ptr_get=ptr_cuda}

//    inl get_elem {src with size=()} = to_host_array 1 src 0
//    met set_elem (!dyn {dst with size=()}) (!dyn v) =
//        inl ar = array_create v 1
//        ar 0 <- v
//        copy 1 {dst with ptr_get=ptr_cuda} {ar size=(); offset=0; ptr_get=ptr_dotnet}

//    inl get tns = 
//        match tns.unwrap with
//        | {bodies dim=()} -> toa_map get_elem bodies
//        | _ -> error_type "Cannot get from tensor whose dimensions have not been applied completely."

//    inl set tns v = 
//        match tns.unwrap with
//        | {bodies dim=()} -> toa_iter2 set_elem bodies v
//        | _ -> error_type "Cannot set to a tensor whose dimensions have not been applied completely."

//    inl transfer_template f tns = 
//        assert_contiguous tns
//        inl f = tns.dim |> fst |> span |> f
//        tns.update_body <| inl body -> {body with ar = f body}

//    inl from_host_tensor tns = transfer_template from_host_array tns
//    inl to_host_tensor tns = transfer_template to_host_array tns
//    inl to_dev_tensor tns = tns.update_body (inl body -> 
//        inb ptr = ptr_cuda body
//        {body with ar=!UnsafeCoerceToArrayCudaGlobal(ptr,body.ar.elem_type); offset=0}
//        )

//    inl clear tns = 
//        assert_contiguous tns
//        inl span = tns.dim |> fst |> span
//        inl stream = current_stream .extract
//        tns.update_body <| inl {body with size=size::_ ar} ->
//            FS.Method context .ClearMemoryAsync (CUdeviceptr (ar.ptr()),0u8,size * span * sizeof ar.elem_type |> SizeT,stream) unit
//        |> ignore

//    inl clear' x = clear x; x
//    inl zero = create >> clear'
//    inl zero_like = create_like >> clear'

//    inl from_host_tensors x ret = 
//        inl tensors = toa_map from_host_tensor x
//        inl r = ret tensors
//        toa_map (inl x -> x.update_body (inl {ar} -> ar.ptr.Dispose)) |> ignore
//        r

//    met print (!dyn o1) = to_host_tensor o1 |> HostTensor.print

//    // CPS'd variants of the allocator functions.
//    inl create = safe_alloc 1 create
//    inl from_host_tensor = safe_alloc 1 from_host_tensor
//    inl zero = safe_alloc 1 zero
//    inl zero_like = safe_alloc 1 zero_like

//    {create from_host_tensor from_host_tensors to_host_tensor to_dev_tensor clear zero zero_like print get set}
//    """) |> module_

let allocator = 
    (
    "Allocator",[loops;option;extern_;console],"The section based GPU memory allocator module.",
    """
inl {Cuda} size ->
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

    inl resize_type = fs [text: "ResizeArray"; types: pool]
    inl resize_array_filter f ar = FS.Method ar .RemoveAll (closure_of f (pool => int32)) int32 |> ignore
    inl resize_array_sort f ar =
        inl comparison_type = fs [text: System.Comparison]
        inl f = closure_of f (pool => pool => int32)
        inl c = FS.Contructor comparison_type f
        FS.Method ar .Sort c unit

    inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32
    inl index free_cells i = macro.fs pool [arg: free_cells; iter: ".[","","]",[arg: to int32 i]]
    inl set free_cells i v = macro.fs () [arg: free_cells; iter: ".[","","] <- ",[arg: to int32 i]; arg: v]

    inl filter_empty = resize_array_filter (inl {ptr} -> ptr.Try = 0u64)
    inl sort_ptrs = resize_array_sort (inl {ptr=a} {ptr=b} -> compare (a()) (b()))

    met free_cells_refresh {section with pool free_cells used_cells} = 
        filter_empty used_cells; sort_ptrs used_cells
        FS.Method free_cells .Clear() ()
        inl near_to = FS.Method used_cells .get_Count() int32
        inl add {ptr size} = FS.Method free_cells .Add {ptr = smartptr_create (ptr()); size} ()
        inl index = index free_cells

        inl distance state state' = 
            inl p1 = state.ptr() + state.size
            inl p2 = state.ptr()
            p2 - p1
            
        Loops.for {from=0i32; near_to by=1i32; state={pool with size = 0u64}; body=inl {state i} ->
            inl state' = index i
            inl size = distance state state'
            if size > 0u64 then add { ptr size }
            state'
            }
        |> inl state = // This is for the final free cell at the end.
            inl size = distance pool state
            add {state with size}

    met allocate {section with free_cells} (!dyn size') =
        inl index = index free_cells
        inl set = set free_cells
        inl near_to = FS.Method free_cells .get_Count() int32
        inl loop next = 
            inl i = 0i32
            inl {ptr size} = index i
            if size' <= size then 
                set i {ptr=smartptr_create (ptr.Try+size'); size=size-size'}
                {ptr size=size'}
            else next()

        loop <| inl _ ->
            sort_ptrs free_cells
            loop <| inl _ -> 
                free_cells_refresh section
                sort_ptrs free_cells
                loop <| inl _ ->
                    failwith () "Out of memory in the designated section."

    inl create_section size =
        inl free_cells = FS.Constructor resize_type ()
        inl used_cells = FS.Constructor resize_type ()
        inl pool = allocate_global size
        inl section = {pool free_cells used_cells}
        free_cells_refresh section
        function
        | .refresh -> free_cells_refresh section
        | x -> allocate section x

    create_section size
    """) |> module_