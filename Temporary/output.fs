Error trace on line: 170, column: 5 in file "Cuda".
inl ret -> 
    ^
Error trace on line: 87, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 88, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 171, column: 9 in file "Cuda".
    use context = context
        ^
Error trace on line: 172, column: 5 in file "Cuda".
    ret {Stream context dim3 run}
    ^
Error trace on line: 34, column: 5 in file "Learning".
inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
    ^
Error trace on line: 35, column: 5 in file "Learning".
inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
    ^
Error trace on line: 36, column: 5 in file "Learning".
inl SizeT = FS.Constructor SizeT_type
    ^
Error trace on line: 37, column: 5 in file "Learning".
inl CUdeviceptr = FS.Constructor CUdeviceptr_type
    ^
Error trace on line: 43, column: 20 in file "Learning".
inl allocator size ret =
                   ^
Error trace on line: 47, column: 9 in file "Learning".
    inl pool = 
        ^
Error trace on line: 59, column: 9 in file "Learning".
    inl pool_type = type(pool)
        ^
Error trace on line: 60, column: 9 in file "Learning".
    inl stack_type = fs [text: "System.Collections.Generic.Stack"; types: pool_type]
        ^
Error trace on line: 61, column: 9 in file "Learning".
    inl stack = FS.Constructor stack_type ()
        ^
Error trace on line: 63, column: 9 in file "Learning".
    inl allocate =
        ^
Error trace on line: 83, column: 5 in file "Learning".
    ret {allocate}
    ^
Error trace on line: 150, column: 5 in file "Learning".
inb allocator = allocator 0.7
    ^
Error trace on line: 87, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 88, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 156, column: 5 in file "Learning".
use random = 
    ^
Error trace on line: 87, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 88, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 160, column: 5 in file "Learning".
use cublas =
    ^
Error trace on line: 166, column: 5 in file "Learning".
inl operation_type = fs [text: "ManagedCuda.CudaBlas.Operation"]
    ^
Error trace on line: 167, column: 5 in file "Learning".
inl to_operation = function
    ^
Error trace on line: 171, column: 5 in file "Learning".
inl isT = function
    ^
Error trace on line: 175, column: 5 in file "Learning".
inl isnT = function
    ^
Error trace on line: 381, column: 5 in file "Learning".
inl test_random = 
    ^
Error trace on line: 388, column: 5 in file "Learning".
inl test_map = 
    ^
Error trace on line: 393, column: 5 in file "Learning".
inl test_map_redo =
    ^
Error trace on line: 405, column: 5 in file "Learning".
inl test_gemm =
    ^
Error trace on line: 450, column: 5 in file "Learning".
inl learning_tests =
    ^
Error trace on line: 453, column: 1 in file "Learning".
test_map id
^
Error trace on line: 375, column: 15 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
              ^
Error trace on line: 58, column: 12 in file "Core".
inl (<|) a b = a b
           ^
Error trace on line: 375, column: 15 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
              ^
Error trace on line: 58, column: 12 in file "Core".
inl (<|) a b = a b
           ^
Error trace on line: 375, column: 15 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
              ^
Error trace on line: 58, column: 12 in file "Core".
inl (<|) a b = a b
           ^
Error trace on line: 24, column: 13 in file "Learning".
        | 0 ret ->
            ^
Error trace on line: 25, column: 17 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                ^
Error trace on line: 26, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 375, column: 30 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                             ^
Error trace on line: 220, column: 25 in file "Learning".
    inl map f (!zip in) ret =
                        ^
Error trace on line: 24, column: 13 in file "Learning".
        | 0 ret ->
            ^
Error trace on line: 25, column: 17 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                ^
Error trace on line: 26, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 221, column: 13 in file "Learning".
        inb out = create {dim=in.dim; elem_type = type (f (in.elem_type))}
            ^
Error trace on line: 223, column: 13 in file "Learning".
        inl in' = to_1d in |> cuda_tensor_to_device_tensor
            ^
Error trace on line: 224, column: 13 in file "Learning".
        inl out' = to_1d out |> cuda_tensor_to_device_tensor
            ^
Error trace on line: 225, column: 13 in file "Learning".
        inl near_to = length in'
            ^
Error trace on line: 237, column: 9 in file "Learning".
        ret out
        ^
Error trace on line: 375, column: 30 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                             ^
Error trace on line: 376, column: 12 in file "Learning".
inl succ a ret = ret a
           ^
Error trace on line: 375, column: 30 in file "Learning".
inl (>>=) a b ret = a <| inl a -> b a ret
                             ^
Error trace on line: 390, column: 9 in file "Learning".
    inm {ar} = from_host_tensor host_tensor >>= map ((*) (dyn 2f32)) >>= (to_host_tensor >> succ)
        ^
Pattern miss error. The argument is <function>
