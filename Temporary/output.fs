Error trace on line: 124, column: 9 in file "Learning".
        ret (out, inl _ ->
        ^
Error trace on line: 150, column: 13 in file "Learning".
        inb b,b_bck = b a
            ^
Error trace on line: 151, column: 9 in file "Learning".
        ret (b, inl _ -> b_bck(); a_bck())
        ^
Error trace on line: 149, column: 13 in file "Learning".
        inb a,a_bck = a
            ^
Error trace on line: 153, column: 16 in file "Learning".
    inl succ x ret = ret (x, const ())
               ^
Error trace on line: 150, column: 13 in file "Learning".
        inb b,b_bck = b a
            ^
Error trace on line: 151, column: 9 in file "Learning".
        ret (b, inl _ -> b_bck(); a_bck())
        ^
Error trace on line: 150, column: 13 in file "Learning".
        inb b,b_bck = b a
            ^
Error trace on line: 151, column: 9 in file "Learning".
        ret (b, inl _ -> b_bck(); a_bck())
        ^
Error trace on line: 278, column: 17 in file "Learning".
            inb {cost accuracy}, _ as er = apply (view input, view label)
                ^
Error trace on line: 281, column: 13 in file "Learning".
            optimizer er
            ^
Error trace on line: 270, column: 27 in file "Learning".
            | {optimizer} {cost},bck ->
                          ^
Error trace on line: 323, column: 13 in file "Learning".
            bck()
            ^
Error trace on line: 151, column: 21 in file "Learning".
        ret (b, inl _ -> b_bck(); a_bck())
                    ^
Error trace on line: 102, column: 21 in file "Learning".
        ret (C, inl _ ->
                    ^
Error trace on line: 103, column: 17 in file "Learning".
            inl C' = adjoint C
                ^
Error trace on line: 105, column: 13 in file "Learning".
            on_non_nil (adjoint B) (inl B -> gemm' .T .nT one (primal A) C' one B)
            ^
Error trace on line: 64, column: 22 in file "Learning".
    inl on_non_nil B ret =
                     ^
Error trace on line: 65, column: 9 in file "Learning".
        match B with
        ^
Error trace on line: 66, column: 11 in file "Learning".
        | .nil -> ()
          ^
Error trace on line: 67, column: 11 in file "Learning".
        | B -> ret B
          ^
Error trace on line: 105, column: 41 in file "Learning".
            on_non_nil (adjoint B) (inl B -> gemm' .T .nT one (primal A) C' one B)
                                        ^
Error trace on line: 62, column: 48 in file "CudaBlas".
        inl gemm' transa transb alpha B A beta C =
                                               ^
Error trace on line: 92, column: 17 in file "CudaBlas".
            inl a_col = if isnT transa then cols A else rows A
                ^
Error trace on line: 93, column: 17 in file "CudaBlas".
            inl b_row = if isnT transb then rows B else cols B
                ^
Error trace on line: 94, column: 13 in file "CudaBlas".
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
