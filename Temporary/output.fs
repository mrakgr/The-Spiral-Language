Error trace on line: 107, column: 12 in file "Core".
inl (<|) a b = a b
           ^
Error trace on line: 5, column: 9 in file "CudaModules".
    inb s = CudaRandom s
        ^
Error trace on line: 2, column: 7 in file "CudaBlas".
inl s ret ->
      ^
Error trace on line: 5, column: 9 in file "CudaBlas".
    inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
        ^
Error trace on line: 6, column: 9 in file "CudaBlas".
    inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
        ^
Error trace on line: 7, column: 9 in file "CudaBlas".
    inl SizeT = FS.Constructor SizeT_type
        ^
Error trace on line: 8, column: 9 in file "CudaBlas".
    inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT
        ^
Error trace on line: 12, column: 9 in file "CudaBlas".
    inl operation_type = fs [text: "ManagedCuda.CudaBlas.Operation"]
        ^
Error trace on line: 13, column: 9 in file "CudaBlas".
    inl to_operation = function
        ^
Error trace on line: 17, column: 9 in file "CudaBlas".
    inl isT = function
        ^
Error trace on line: 21, column: 9 in file "CudaBlas".
    inl isnT = function
        ^
Error trace on line: 25, column: 9 in file "CudaBlas".
    inl len = HostTensor.span
        ^
Error trace on line: 55, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 56, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 30, column: 9 in file "CudaBlas".
    use cublas =
        ^
Error trace on line: 78, column: 5 in file "CudaBlas".
    ret <| s.module_add .CudaBlas {gemm' gemm}
    ^
Error trace on line: 107, column: 12 in file "Core".
inl (<|) a b = a b
           ^
Error trace on line: 6, column: 9 in file "CudaModules".
    inb s = CudaBlas s
        ^
Error trace on line: 7, column: 9 in file "CudaModules".
    inl s = Region s |> CudaStream |> CudaTensor |> CudaKernel
        ^
Error trace on line: 46, column: 36 in file "Region".
inl create' {region_module_name} s ret =
                                   ^
Error trace on line: 47, column: 9 in file "Region".
    inl s = s region_module_name .create
        ^
Error trace on line: 48, column: 13 in file "Region".
    inl r = ret s
            ^
Error trace on line: 8, column: 9 in file "CudaModules".
    inb s = s.RegionMem.create'
        ^
Error trace on line: 46, column: 36 in file "Region".
inl create' {region_module_name} s ret =
                                   ^
Error trace on line: 47, column: 9 in file "Region".
    inl s = s region_module_name .create
        ^
Error trace on line: 48, column: 13 in file "Region".
    inl r = ret s
            ^
Error trace on line: 9, column: 9 in file "CudaModules".
    inb s = s.RegionStream.create'
        ^
Error trace on line: 10, column: 5 in file "CudaModules".
    ret s
    ^
Error trace on line: 2, column: 5 in file "learning6".
inb s = CudaModules (1024*1024)
    ^
Error trace on line: 4, column: 5 in file "learning6".
inl float = float32
    ^
Error trace on line: 11, column: 5 in file "learning6".
inl input_size = 6
    ^
Error trace on line: 12, column: 5 in file "learning6".
inl hidden_size = 4
    ^
Error trace on line: 13, column: 5 in file "learning6".
inl batch_size = 2
    ^
Error trace on line: 14, column: 5 in file "learning6".
inl input = s.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=batch_size,input_size}
    ^
Error trace on line: 15, column: 5 in file "learning6".
inl label = s.CudaTensor.zero {elem_type=float; dim=batch_size,hidden_size}
    ^
Error trace on line: 19, column: 5 in file "learning6".
    init (sigmoid hidden_size) input_size s |> with_error square
    ^
Variable init not bound.
