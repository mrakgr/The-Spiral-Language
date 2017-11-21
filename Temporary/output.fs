Pattern miss error. The argument is TyList [TyMap (EnvConsed <tag 184>,MapTypeModule)]
Error trace on line: 2, column: 1 in file "Learning".
open Extern
^
Error trace on line: 3, column: 1 in file "Learning".
open Cuda
^
Error trace on line: 4, column: 1 in file "Learning".
open Console
^
Error trace on line: 6, column: 1 in file "Learning".
inl smartptr_create ptr =
^
Error trace on line: 20, column: 1 in file "Learning".
inl safe_alloc n create =
^
Error trace on line: 33, column: 1 in file "Learning".
inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
^
Error trace on line: 34, column: 1 in file "Learning".
inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
^
Error trace on line: 35, column: 1 in file "Learning".
inl SizeT = FS.Constructor SizeT_type
^
Error trace on line: 36, column: 1 in file "Learning".
inl CUdeviceptr = FS.Constructor CUdeviceptr_type
^
Error trace on line: 38, column: 1 in file "Learning".
inl allocator size =
^
Error trace on line: 81, column: 1 in file "Learning".
inl CudaTensor allocator =
^
Error trace on line: 134, column: 1 in file "Learning".
open CudaTensor (allocator 0.7)
^
Error trace on line: 136, column: 1 in file "Learning".
inl random = 
^
Error trace on line: 140, column: 1 in file "Learning".
inl CudaKernels stream =
^
Error trace on line: 244, column: 1 in file "Learning".
open CudaKernels (Stream.create())
^
Error trace on line: 245, column: 1 in file "Learning".
open Console
^
Error trace on line: 247, column: 1 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
^
Error trace on line: 248, column: 1 in file "Learning".
inl succ a ret = ret a
^
Error trace on line: 250, column: 1 in file "Learning".
inl program_random = 
^
Error trace on line: 257, column: 1 in file "Learning".
inl program_map = 
^
Error trace on line: 262, column: 1 in file "Learning".
inl program_map_redo =
^
Error trace on line: 266, column: 1 in file "Learning".
program_map_redo id
^
Error trace on line: 247, column: 21 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                    ^
Error trace on line: 57, column: 16 in file "Core".
inl (<|) a b = a b
               ^
Error trace on line: 247, column: 21 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                    ^
Error trace on line: 57, column: 16 in file "Core".
inl (<|) a b = a b
               ^
Error trace on line: 24, column: 13 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
            ^
Error trace on line: 25, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 247, column: 35 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                                  ^
Error trace on line: 166, column: 9 in file "Learning".
        inl in' = coerce_to_1d in |> to_device_tensor_form
        ^
Error trace on line: 167, column: 9 in file "Learning".
        inl near_to = total_size (in'.size)
        ^
Error trace on line: 172, column: 9 in file "Learning".
        inl blockDim = 128
        ^
Error trace on line: 173, column: 9 in file "Learning".
        inl gridDim = near_to / blockDim
        ^
Error trace on line: 174, column: 9 in file "Learning".
        inl elem_type = type (
        ^
Error trace on line: 178, column: 9 in file "Learning".
        inl out = create.unsafe {size=gridDim; layout elem_type}
        ^
Error trace on line: 179, column: 9 in file "Learning".
        inl out' = to_device_tensor_form out
        ^
Error trace on line: 181, column: 9 in file "Learning".
        run {
        ^
Error trace on line: 201, column: 15 in file "Learning".
            } |> ignore
              ^
Error trace on line: 136, column: 5 in file "Cuda".
    inl to_obj_ar args =
    ^
Error trace on line: 142, column: 5 in file "Cuda".
    inl kernel =
    ^
Error trace on line: 154, column: 40 in file "Cuda".
    inl method_name, !to_obj_ar args = join_point_entry_cuda kernel
                                       ^
Error trace on line: 6, column: 31 in file "Cuda".
inl join_point_entry_cuda x = !JoinPointEntryCuda(x())
                              ^
Error trace on line: 149, column: 13 in file "Cuda".
            inl threadIdx = {x=__threadIdxX(); y=__threadIdxY(); z=__threadIdxZ()}
            ^
Error trace on line: 150, column: 13 in file "Cuda".
            inl blockIdx = {x=__blockIdxX(); y=__blockIdxY(); z=__blockIdxZ()}
            ^
Error trace on line: 151, column: 13 in file "Cuda".
            inl blockDim = {x=x(); y=y(); z=z()}
            ^
Error trace on line: 152, column: 13 in file "Cuda".
            inl gridDim = {x=x'(); y=y'(); z=z'()}
            ^
Error trace on line: 153, column: 13 in file "Cuda".
            kernel threadIdx blockIdx blockDim gridDim
            ^
Error trace on line: 186, column: 17 in file "Learning".
                inl from = blockIdx.x * blockDim.x + threadIdx.x
                ^
Error trace on line: 187, column: 17 in file "Learning".
                inl by = gridDim.x * blockDim.x
                ^
Error trace on line: 188, column: 17 in file "Learning".
                inl load i = map (index_unsafe in' i)
                ^
Error trace on line: 189, column: 37 in file "Learning".
                inl thread_result = Loops.for {from=from+by; near_to by state=load from; body=inl {state i} -> redo state (load i)}
                                    ^
Error trace on line: 188, column: 30 in file "Learning".
                inl load i = map (index_unsafe in' i)
                             ^
Error trace on line: 87, column: 5 in file "HostTensor".
    inl {ar layout} = x
    ^
Error trace on line: 88, column: 18 in file "HostTensor".
    inl offset = offset_at_index is_safe x i
                 ^
Error trace on line: 17, column: 5 in file "HostTensor".
    inl array = {array with size=wrap self}
    ^
Error trace on line: 18, column: 5 in file "HostTensor".
    inl rec loop x state = 
    ^
Error trace on line: 31, column: 5 in file "HostTensor".
    loop (array,i) (0,inl _ -> 1) |> fst
    ^
Error trace on line: 19, column: 9 in file "HostTensor".
        match x with
        ^
