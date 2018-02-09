module Modules

open Spiral.Types
open Spiral.Lib

let allocator = 
    (
    "Allocator",[option;extern_;console],"The stack based GPU memory allocator module.",
    """
inl {Cuda size} ret ->
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

    /////// n is the number of args the create function has.
    //inl safe_alloc n create =
    //    if lit_is n = false then error_type "n need to be static."
    //    inl rec loop vars = function
    //        | 0 ret ->
    //            inl tns = Tuple.foldr (inl x create -> create x) vars create
    //            inl r = ret tns
    //            tns.update_body (inl {ar} -> ar.ptr.Dispose) |> ignore
    //            r
    //        | n x -> loop (x :: vars) (n-1)
    //    function
    //    | .unsafe -> create
    //    | x -> loop () n x

    //inl to_float x = FS.UnOp .float x float64
    //inl to_int x = FS.UnOp .int64 x int64
    
    //inl pool = 
    //    inl size = 
    //        match size with
    //        | _ : float64 -> 
    //            FS.Method context .GetFreeDeviceMemorySize() SizeT_type
    //            |> to_int |> to_float |> (*) size |> to_uint
    //        | _ : int64 -> to uint64 size
    //    {size ptr=FS.Method context .AllocateMemory (SizeT size) CUdeviceptr_type |> to_uint |> smartptr_create}

    //inl pool_type = type pool
    //inl stack_type = fs [text: "System.Collections.Generic.Stack"; types: pool_type]
    //inl stack = FS.Constructor stack_type ()

    //inl allocate =
    //    inl smartptr_ty = type pool.ptr
    //    inl f {ptr size} = ptr(), size
    //    inl pool_ptr, pool_size = f pool
    //    met rec remove_disposed_and_return_the_first_live ret =
    //        if FS.Method stack .get_Count() int32 > 0i32 then 
    //            inl {ptr size} = FS.Method stack .Peek() pool_type
    //            match ptr.Try with
    //            | 0u64 -> FS.Method stack .Pop() pool_type |> ignore; remove_disposed_and_return_the_first_live ret 
    //            | ptr -> join (ret (ptr, size))
                
    //        else join (ret (pool_ptr, 0u64))
    //        : smartptr_ty
    //    inl round_up_to_multiple mult size = size - size % mult + mult
    //    inl s = to uint64 >> round_up_to_multiple 256u64 >> dyn
    //    inl (!s size) ->
    //        inb top_ptr, top_size = remove_disposed_and_return_the_first_live
    //        inl top_used = top_ptr + top_size
    //        inl pool_used = pool_ptr + pool_size
    //        assert (size <= pool_used - top_used) "Cache size has been exceeded in the allocator."
    //        inl ptr = top_used |> smartptr_create
    //        FS.Method stack .Push {size ptr} unit
    //        ptr

    //ret {allocate safe_alloc}

    //inl ptr = pool.ptr
    //FS.Method context .FreeMemory (ptr() |> CUdeviceptr) unit
    //ptr.Dispose
    """) |> module_
