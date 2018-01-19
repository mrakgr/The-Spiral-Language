Error trace on line: 21, column: 17 in file "Allocator".
            | 0 ret ->
                ^
Error trace on line: 22, column: 21 in file "Allocator".
                inl tns = Tuple.foldr (inl x create -> create x) vars create
                    ^
Error trace on line: 23, column: 25 in file "Allocator".
                inl r = ret tns
                        ^
Error trace on line: 49, column: 17 in file "CudaRandom".
            inb device_tensor = create dsc
                ^
Error trace on line: 51, column: 13 in file "CudaRandom".
            ret device_tensor
            ^
Error trace on line: 12, column: 5 in file "blas1".
inb a1 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=2,3}
    ^
Error trace on line: 48, column: 34 in file "CudaRandom".
        inl create_tensor op dsc ret =
                                 ^
Error trace on line: 21, column: 17 in file "Allocator".
            | 0 ret ->
                ^
Error trace on line: 22, column: 21 in file "Allocator".
                inl tns = Tuple.foldr (inl x create -> create x) vars create
                    ^
Error trace on line: 23, column: 25 in file "Allocator".
                inl r = ret tns
                        ^
Error trace on line: 49, column: 17 in file "CudaRandom".
            inb device_tensor = create dsc
                ^
Error trace on line: 51, column: 13 in file "CudaRandom".
            ret device_tensor
            ^
Error trace on line: 13, column: 5 in file "blas1".
inb a2 = CudaRandom.create_tensor {dst=.Normal; stddev=1f32; mean=0f32} {elem_type=float32; dim=3,4}
    ^
Error trace on line: 75, column: 42 in file "CudaBlas".
        inl gemm transa transb alpha A B ret =
                                         ^
Error trace on line: 76, column: 17 in file "CudaBlas".
            inl m = if isnT transa then rows A else cols A
                ^
Error trace on line: 77, column: 17 in file "CudaBlas".
            inl n = if isnT transb then cols B else rows B
                ^
Error trace on line: 21, column: 17 in file "Allocator".
            | 0 ret ->
                ^
Error trace on line: 22, column: 21 in file "Allocator".
                inl tns = Tuple.foldr (inl x create -> create x) vars create
                    ^
Error trace on line: 23, column: 25 in file "Allocator".
                inl r = ret tns
                        ^
Error trace on line: 79, column: 17 in file "CudaBlas".
            inb C = create {dim=m,n; elem_type = A.elem_type}
                ^
Error trace on line: 81, column: 13 in file "CudaBlas".
            ret C
            ^
Error trace on line: 14, column: 5 in file "blas1".
inb o1 = CudaBlas.gemm .nT .nT 1f32 a1 a2
    ^
Error trace on line: 75, column: 42 in file "CudaBlas".
        inl gemm transa transb alpha A B ret =
                                         ^
Error trace on line: 76, column: 17 in file "CudaBlas".
            inl m = if isnT transa then rows A else cols A
                ^
Error trace on line: 77, column: 17 in file "CudaBlas".
            inl n = if isnT transb then cols B else rows B
                ^
Error trace on line: 21, column: 17 in file "Allocator".
            | 0 ret ->
                ^
Error trace on line: 22, column: 21 in file "Allocator".
                inl tns = Tuple.foldr (inl x create -> create x) vars create
                    ^
Error trace on line: 23, column: 25 in file "Allocator".
                inl r = ret tns
                        ^
Error trace on line: 79, column: 17 in file "CudaBlas".
            inb C = create {dim=m,n; elem_type = A.elem_type}
                ^
Error trace on line: 80, column: 13 in file "CudaBlas".
            gemm' transa transb alpha A B (zero_of alpha) C
            ^
Error trace on line: 61, column: 48 in file "CudaBlas".
        inl gemm' transa transb alpha A B beta C =
                                               ^
Error trace on line: 62, column: 17 in file "CudaBlas".
            inl a_col = if isnT transa then cols A else rows A
                ^
Error trace on line: 63, column: 17 in file "CudaBlas".
            inl b_row = if isnT transb then rows B else cols B
                ^
Error trace on line: 64, column: 13 in file "CudaBlas".
            assert (a_col = b_row) "Colums of a does not match rows of b in GEMM."
            ^
Error trace on line: 115, column: 14 in file "Extern".
inl assert c msg =
             ^
Error trace on line: 116, column: 5 in file "Extern".
    if c = false then
    ^
Error trace on line: 117, column: 9 in file "Extern".
        if lit_is c then error_type msg
        ^
Error trace on line: 6, column: 16 in file "Core".
inl error_type x = !ErrorType(x)
               ^
lit Colums of a does not match rows of b in GEMM.
