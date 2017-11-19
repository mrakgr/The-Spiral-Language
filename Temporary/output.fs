Method with the matching arguments not found.
Error trace on line: 2, column: 1 in file "Learning".
open Cuda
^
Error trace on line: 3, column: 1 in file "Learning".
open Extern
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
inl allocator size =
^
Error trace on line: 68, column: 1 in file "Learning".
inl CudaTensor allocator =
^
Error trace on line: 121, column: 1 in file "Learning".
open CudaTensor (allocator 0.7)
^
Error trace on line: 123, column: 1 in file "Learning".
inl map f (!zip ({size layout} & in)) =
^
Error trace on line: 143, column: 1 in file "Learning".
inl map = safe_alloc 2 map
^
Error trace on line: 145, column: 1 in file "Learning".
inl CudaRand = assembly_load ."CudaRand, Version=8.0.22.0, Culture=neutral, PublicKeyToken=fe981579f4e9a066" .ManagedCuda.CudaRand
^
Error trace on line: 146, column: 1 in file "Learning".
inl random_ty = CudaRand.CudaRandDevice
^
Error trace on line: 148, column: 1 in file "Learning".
open Console
^
Error trace on line: 150, column: 1 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
^
Error trace on line: 151, column: 1 in file "Learning".
inl succ a ret = ret a
^
Error trace on line: 153, column: 1 in file "Learning".
inl map_op_option x =
^
Error trace on line: 159, column: 1 in file "Learning".
inl map_op x =
^
Error trace on line: 164, column: 1 in file "Learning".
inl program = 
^
Error trace on line: 170, column: 1 in file "Learning".
program id
^
Error trace on line: 150, column: 21 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                    ^
Error trace on line: 63, column: 16 in file "Core".
inl (<|) a b = a b
               ^
Error trace on line: 150, column: 21 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                    ^
Error trace on line: 63, column: 16 in file "Core".
inl (<|) a b = a b
               ^
Error trace on line: 24, column: 23 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                      ^
Error trace on line: 15, column: 5 in file "Tuple".
    match l with
    ^
Error trace on line: 16, column: 18 in file "Tuple".
    | x :: xs -> f x (foldr f xs s)
                 ^
Error trace on line: 24, column: 52 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                                                   ^
Error trace on line: 114, column: 43 in file "HostTensor".
inl map_tensor f {size ar layout} & tns = { size layout ar = map_tensor_ar f tns }
                                          ^
Error trace on line: 109, column: 5 in file "HostTensor".
    match layout with
    ^
Error trace on line: 111, column: 15 in file "HostTensor".
    | .toa -> toa_map f ar
              ^
Error trace on line: 32, column: 5 in file "HostTensor".
    inl rec loop = function
    ^
Error trace on line: 38, column: 5 in file "HostTensor".
    loop x
    ^
Error trace on line: 37, column: 16 in file "HostTensor".
        | x -> f x
               ^
Error trace on line: 78, column: 9 in file "Learning".
        inl elem_type = ar.elem_type
        ^
Error trace on line: 79, column: 9 in file "Learning".
        inl size = Array.length ar |> unsafe_convert int64
        ^
Error trace on line: 80, column: 17 in file "Learning".
        inl t = create_ar size elem_type
                ^
Error trace on line: 71, column: 19 in file "Learning".
        inl ptr = allocator.allocate (size1d * unsafe_convert int64 (sizeof elem_type))
                  ^
Error trace on line: 51, column: 13 in file "Learning".
            if stack.get_Count() > 0i32 then 
            ^
Error trace on line: 52, column: 17 in file "Learning".
                inl t = stack.Peek() 
                ^
Error trace on line: 53, column: 17 in file "Learning".
                match t.ptr.Try with
                ^
Error trace on line: 54, column: 35 in file "Learning".
                || [Some: ptr] -> ret (ptr.Pointer |> to_uint, t.size |> to_uint)
                                  ^
Error trace on line: 59, column: 13 in file "Learning".
            inb top_ptr, top_size = remove_disposed_and_return_the_first_live
            ^
Error trace on line: 60, column: 13 in file "Learning".
            inl pool_used = top_ptr - pool_ptr + top_size
            ^
Error trace on line: 62, column: 13 in file "Learning".
            inl cell = {size ptr=top_ptr + top_size |> SizeT |> CUdeviceptr |> smartptr_create}
            ^
Error trace on line: 63, column: 13 in file "Learning".
            stack.Push cell
            ^
