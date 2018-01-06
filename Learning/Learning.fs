module Learning.Main

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types

let allocator = 
    (
    "Allocator",[],"The deep learning module.",
    """
inl context ->
    inl smartptr_create ptr =
        inl ptr_ty = type (ptr)
        open Option
        inl cell = some ptr |> ref
        function
        | .Dispose -> cell := none ptr_ty
        | .Try -> cell()
        | () -> join (
            match cell() with
            | .Some, x -> x
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
                tns.update_body (inl {ar} -> ar.ptr.Dispose) |> ignore
                r
            | n x -> loop (x :: vars) (n-1)
        function
        | .unsafe -> create
        | x -> loop () n x

    inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
    inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
    inl SizeT = FS.Constructor SizeT_type
    inl CUdeviceptr = FS.Constructor CUdeviceptr_type

    inl to_uint x = FS.UnOp .uint64 x uint64
    inl ptr_to_uint (ptr: CUdeviceptr_type) = FS.Field ptr .Pointer SizeT_type |> to_uint
    inl uint_to_ptr (x: uint64) = SizeT x |> CUdeviceptr

    inl allocator size ret =
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

        ret {allocate}
        inl ptr = pool.ptr
        FS.Method context .FreeMemory (ptr()) unit
        ptr.Dispose

    {allocator ptr_to_uint uint_to_ptr safe_alloc} |> stack
    """) |> module_

let allocator1 =
    "allocator1",[allocator;cuda],"Does the allocator work?",
    """
openb Cuda
openb Allocator context
    """

let tests =
    [|
    allocator1
    |]

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = @"C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.0"
    path_cub = @"C:\cub-1.7.4"
    path_vs2017 = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community"
    cuda_includes = ["cub/cub.cuh"]
    }

//rewrite_test_cache tests cfg None //(Some(0,40))

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" allocator1
|> printfn "%s"
|> ignore
