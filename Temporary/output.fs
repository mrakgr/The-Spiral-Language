Error trace on line: 9, column: 5 in file "kernel3".
inl outer_size = 8
    ^
Error trace on line: 11, column: 5 in file "kernel3".
inl h = HostTensor.init inner_size id
    ^
Error trace on line: 12, column: 5 in file "kernel3".
inl h' = 
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
Error trace on line: 17, column: 5 in file "kernel3".
inb a1 = CudaTensor.from_host_tensor h
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
Error trace on line: 18, column: 5 in file "kernel3".
inb a2 = CudaTensor.from_host_tensor h'
    ^
Error trace on line: 121, column: 39 in file "CudaKernel".
    inl replicate_map f (!zip in) in' ret =
                                      ^
Error trace on line: 124, column: 13 in file "CudaKernel".
        inl in' =
            ^
Error trace on line: 131, column: 19 in file "CudaKernel".
        inb out = create {elem_type=type f in.elem_type in'.elem_type; dim=in'.dim}
                  ^
Error trace on line: 21, column: 37 in file "kernel3".
    CudaKernel.replicate_map (inl a b -> 
                                    ^
Error trace on line: 23, column: 9 in file "kernel3".
        a+a'+b) a1 a2
        ^
Variable a' not bound.
