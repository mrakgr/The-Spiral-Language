Error trace on line: 5, column: 9 in file "CudaModules".
    inb global_allocate = Allocator {Cuda} size
        ^
Error trace on line: 32, column: 14 in file "Region".
inl create x ret = 
             ^
Error trace on line: 33, column: 9 in file "Region".
    inl region = create' x
        ^
Error trace on line: 34, column: 13 in file "Region".
    inl r = ret region
            ^
Error trace on line: 6, column: 9 in file "CudaModules".
    inb region = Region.create global_allocate
        ^
Error trace on line: 32, column: 14 in file "Region".
inl create x ret = 
             ^
Error trace on line: 33, column: 9 in file "Region".
    inl region = create' x
        ^
Error trace on line: 34, column: 13 in file "Region".
    inl r = ret region
            ^
Error trace on line: 7, column: 9 in file "CudaModules".
    inb stream_region = Region.create CudaStream.create
        ^
Error trace on line: 8, column: 9 in file "CudaModules".
    inl stream = stream_region()
        ^
Error trace on line: 10, column: 9 in file "CudaModules".
    inl d = {
        ^
Error trace on line: 16, column: 9 in file "CudaModules".
    inl CudaTensor = CudaTensor d
        ^
Error trace on line: 17, column: 9 in file "CudaModules".
    inl d = {d with CudaTensor}
        ^
Error trace on line: 2, column: 5 in file "CudaRandom".
inl ret ->
    ^
Error trace on line: 55, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 56, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 4, column: 9 in file "CudaRandom".
    use random = 
        ^
Error trace on line: 8, column: 5 in file "CudaRandom".
    ret inl d ->
    ^
Error trace on line: 18, column: 9 in file "CudaModules".
    inb CudaRandom' = CudaRandom
        ^
Error trace on line: 19, column: 9 in file "CudaModules".
    inl CudaRandom = CudaRandom' d
        ^
Error trace on line: 2, column: 5 in file "CudaBlas".
inl ret ->
    ^
Error trace on line: 7, column: 9 in file "CudaBlas".
    inl operation_type = fs [text: "ManagedCuda.CudaBlas.Operation"]
        ^
Error trace on line: 8, column: 9 in file "CudaBlas".
    inl to_operation = function
        ^
Error trace on line: 12, column: 9 in file "CudaBlas".
    inl isT = function
        ^
Error trace on line: 16, column: 9 in file "CudaBlas".
    inl isnT = function
        ^
Error trace on line: 20, column: 9 in file "CudaBlas".
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
Error trace on line: 36, column: 9 in file "CudaBlas".
    inl handle = FS.Method cublas .get_CublasHandle() (fs [text: "ManagedCuda.CudaBlas.CudaBlasHandle"])
        ^
Error trace on line: 38, column: 5 in file "CudaBlas".
    ret inl d ->
    ^
Error trace on line: 20, column: 9 in file "CudaModules".
    inb CudaBlas' = CudaBlas
        ^
Error trace on line: 21, column: 9 in file "CudaModules".
    inl CudaBlas = CudaBlas' d
        ^
Error trace on line: 22, column: 9 in file "CudaModules".
    inl CudaKernel = CudaKernel d
        ^
Error trace on line: 23, column: 5 in file "CudaModules".
    ret {d with CudaBlas CudaRandom CudaKernel}
    ^
Error trace on line: 2, column: 5 in file "learning1".
inb d = CudaModules (1024*1024)
    ^
Error trace on line: 4, column: 5 in file "learning1".
inl float = float32
    ^
Error trace on line: 8, column: 5 in file "learning1".
inl a1 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=2,8}
    ^
Error trace on line: 9, column: 10 in file "learning1".
inl a2 = d.CudaRandom.create {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float; dim=8,2} >>! dr
         ^
Variable >>! not bound.
