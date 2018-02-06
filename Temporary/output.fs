Error trace on line: 16, column: 5 in file "learning10".
inl size = {
    ^
Error trace on line: 24, column: 5 in file "learning10".
inl path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"
    ^
Error trace on line: 20, column: 17 in file "Allocator".
            | 0 ret ->
                ^
Error trace on line: 21, column: 21 in file "Allocator".
                inl tns = Tuple.foldr (inl x create -> create x) vars create
                    ^
Error trace on line: 22, column: 25 in file "Allocator".
                inl r = ret tns
                        ^
Error trace on line: 25, column: 5 in file "learning10".
inb data = 
    ^
Error trace on line: 39, column: 5 in file "learning10".
inl data =
    ^
Error trace on line: 43, column: 5 in file "learning10".
inl minibatch,seq = data.dim
    ^
Error trace on line: 834, column: 29 in file "CudaKernel".
    inl init {d with dim} f ret =
                            ^
Error trace on line: 835, column: 13 in file "CudaKernel".
        inl dim = Tuple.wrap dim
            ^
Error trace on line: 836, column: 25 in file "CudaKernel".
        inl elem_type = type Tuple.foldl (inl f _ -> f 0) f dim
                        ^
Error trace on line: 14, column: 7 in file "Tuple".
    | x :: xs -> foldl f (f s x) xs
      ^
Error trace on line: 836, column: 49 in file "CudaKernel".
        inl elem_type = type Tuple.foldl (inl f _ -> f 0) f dim
                                                ^
Error trace on line: 47, column: 80 in file "learning10".
    CudaKernel.init {rev_thread_limit=32; dim=seq,minibatch,size.hot} (inl seq minibatch ->
                                                                               ^
Error trace on line: 49, column: 17 in file "learning10".
        inl x = data minibatch seq .get
                ^
Error trace on line: 191, column: 7 in file "HostTensor".
    | .(_) & x -> 
      ^
Error trace on line: 192, column: 9 in file "HostTensor".
        if module_has_member data x then data x
        ^
Error trace on line: 193, column: 14 in file "HostTensor".
        else Tensor x data
             ^
Error trace on line: 128, column: 19 in file "HostTensor".
        get = inl {data with dim bodies} -> 
                  ^
Error trace on line: 129, column: 13 in file "HostTensor".
            match dim with
            ^
Error trace on line: 130, column: 15 in file "HostTensor".
            | () -> toa_map tensor_get bodies
              ^
Error trace on line: 4, column: 15 in file "HostTensor".
inl toa_map f x = 
              ^
Error trace on line: 11, column: 5 in file "HostTensor".
    loop x
    ^
Error trace on line: 6, column: 11 in file "HostTensor".
        | x when caseable_box_is x -> f x
          ^
Error trace on line: 7, column: 11 in file "HostTensor".
        | x :: xs -> loop x :: loop xs
          ^
Error trace on line: 8, column: 11 in file "HostTensor".
        | () -> ()
          ^
Error trace on line: 9, column: 11 in file "HostTensor".
        | {!block_toa_map} & x -> module_map (inl _ -> loop) x
          ^
Error trace on line: 10, column: 11 in file "HostTensor".
        | x -> f x
          ^
Error trace on line: 70, column: 16 in file "HostTensor".
inl tensor_get {data with offset ar} = ar offset
               ^
Error trace on line: 12, column: 11 in file "CudaTensor".
        | .elem_type -> elem_type
          ^
Error trace on line: 13, column: 11 in file "CudaTensor".
        | .ptr -> ptr
          ^
Pattern miss error. The argument is lit 0i64
