Error trace on line: 54, column: 13 in file "CudaKernel".
        inl out' = to_dev_tensor out
            ^
Error trace on line: 69, column: 9 in file "CudaKernel".
        inl _ ->
        ^
Error trace on line: 74, column: 9 in file "CudaKernel".
        |> ret
        ^
Error trace on line: 101, column: 12 in file "Core".
inl (|>) a b = b a
           ^
Error trace on line: 86, column: 13 in file "Learning".
        inb !dr_lazyhost out = map_redo fwd primal
            ^
Error trace on line: 87, column: 9 in file "Learning".
        ret (out, inl _ ->
        ^
Error trace on line: 15, column: 5 in file "learning3".
inb o1,bck = map_redo {fwd={neutral_elem=0f32; redo=(+)}; bck=(+)} a1
    ^
Error trace on line: 16, column: 1 in file "learning3".
bck()
^
Error trace on line: 87, column: 23 in file "Learning".
        ret (out, inl _ ->
                      ^
Error trace on line: 88, column: 17 in file "Learning".
            inl out = toa_map2 (inl P A -> {P A = A ()}) out.primal.value out.adjoint
                ^
Error trace on line: 89, column: 17 in file "Learning".
            inl bck =
                ^
Error trace on line: 53, column: 34 in file "Learning".
    inl filter_unit_and_branch x ret =
                                 ^
Error trace on line: 54, column: 9 in file "Learning".
        match filter_units x with
        ^
Error trace on line: 55, column: 11 in file "Learning".
        | () -> ()
          ^
Error trace on line: 56, column: 11 in file "Learning".
        | x -> ret x
          ^
Error trace on line: 94, column: 17 in file "Learning".
            inb adjoint = filter_unit_and_branch adjoint 
                ^
Error trace on line: 95, column: 13 in file "Learning".
            map bck {in=primal; adjoint} adjoint
            ^
Error trace on line: 69, column: 13 in file "Learning".
    inl map {fwd bck} in ret =
            ^
Pattern miss error. The argument is <function>
