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
Error trace on line: 39, column: 20 in file "Learning".
inl allocator size ret =
                   ^
Error trace on line: 44, column: 9 in file "Learning".
    inl pool = 
        ^
Error trace on line: 56, column: 9 in file "Learning".
    inl pool_type = type(pool)
        ^
Error trace on line: 57, column: 9 in file "Learning".
    inl stack_type = fs [text: "System.Collections.Generic.Stack"; types: pool_type]
        ^
Error trace on line: 58, column: 9 in file "Learning".
    inl stack = FS.Constructor stack_type ()
        ^
Error trace on line: 60, column: 9 in file "Learning".
    inl allocate =
        ^
Error trace on line: 80, column: 5 in file "Learning".
    ret {allocate}
    ^
Error trace on line: 138, column: 5 in file "Learning".
inb allocator = allocator 0.7
    ^
Error trace on line: 139, column: 6 in file "Learning".
open CudaTensor allocator
     ^
Error trace on line: 85, column: 16 in file "Learning".
inl CudaTensor allocator =
               ^
Error trace on line: 101, column: 9 in file "Learning".
    inl from_host_tensor = map_ar from_host_array
        ^
Error trace on line: 115, column: 33 in file "Learning".
    inl to_device_tensor_form = map_tensor ptr
                                ^
Variable map_tensor not bound.
