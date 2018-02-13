Error trace on line: 2, column: 5 in file "Cuda".
inl ret -> 
    ^
Error trace on line: 6, column: 9 in file "Cuda".
    inl cuda_kernels = FS.Constant.cuda_kernels string
        ^
Error trace on line: 19, column: 9 in file "Cuda".
    inl cuda_toolkit_path = @PathCuda
        ^
Error trace on line: 20, column: 9 in file "Cuda".
    inl visual_studio_path = @PathVS2017
        ^
Error trace on line: 21, column: 9 in file "Cuda".
    inl cub_path = @PathCub
        ^
Error trace on line: 23, column: 9 in file "Cuda".
    inl env_type = fs [text: "System.Environment"]
        ^
Error trace on line: 24, column: 9 in file "Cuda".
    inl context_type = fs [text: "ManagedCuda.CudaContext"]
        ^
Error trace on line: 57, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 58, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 25, column: 9 in file "Cuda".
    use context = FS.Constructor context_type false
        ^
Error trace on line: 111, column: 9 in file "Cuda".
    inl current_directory = FS.StaticMethod env_type .get_CurrentDirectory() string
        ^
Error trace on line: 112, column: 9 in file "Cuda".
    inl modules = compile_kernel_using_nvcc_bat_router current_directory
        ^
Error trace on line: 115, column: 9 in file "Cuda".
    inl dim3 = function
        ^
Error trace on line: 121, column: 9 in file "Cuda".
    inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
        ^
Error trace on line: 122, column: 9 in file "Cuda".
    inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
        ^
Error trace on line: 123, column: 9 in file "Cuda".
    inl SizeT = FS.Constructor SizeT_type
        ^
Error trace on line: 124, column: 9 in file "Cuda".
    inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT
        ^
Error trace on line: 161, column: 5 in file "Cuda".
    ret {context dim3 run SizeT SizeT_type CUdeviceptr CUdeviceptr_type ptr_to_uint uint_to_ptr to_uint}
    ^
Error trace on line: 2, column: 5 in file "allocator2".
inb Cuda = Cuda
    ^
Error trace on line: 3, column: 5 in file "allocator2".
inl allocate = Allocator {Cuda} 1024
    ^
Error trace on line: 4, column: 14 in file "allocator2".
inl region = Region allocate
             ^
Error trace on line: 2, column: 5 in file "Region".
inl create ->
    ^
Error trace on line: 13, column: 21 in file "Region".
    inl elem_type = type counter_ref_create (var create.elem_type)
                    ^
Variable var not bound.
