Error trace on line: 65, column: 26 in file "Learning".
    inl map {fwd bck} in s =
                         ^
Error trace on line: 66, column: 13 in file "Learning".
        inl primal, adjoint = primals in, adjoints in
            ^
Error trace on line: 67, column: 19 in file "Learning".
        inl out = s.CudaKernel.map fwd primal |> dr s
                  ^
Error trace on line: 223, column: 13 in file "CudaKernel".
inl map w f in =
            ^
Error trace on line: 224, column: 5 in file "CudaKernel".
    indiv join
    ^
Error trace on line: 225, column: 18 in file "CudaKernel".
        inl in = zip in
                 ^
Error trace on line: 353, column: 9 in file "HostTensor".
inl zip l = 
        ^
Error trace on line: 354, column: 5 in file "HostTensor".
    match assert_zip l with
    ^
Error trace on line: 345, column: 16 in file "HostTensor".
inl assert_zip l =
               ^
Error trace on line: 346, column: 5 in file "HostTensor".
    toa_foldl (inl s x ->
    ^
Error trace on line: 33, column: 19 in file "HostTensor".
inl toa_foldl f s x = 
                  ^
Error trace on line: 40, column: 5 in file "HostTensor".
    loop s x
    ^
Error trace on line: 35, column: 11 in file "HostTensor".
        | x when caseable_box_is x -> f s x
          ^
Error trace on line: 36, column: 11 in file "HostTensor".
        | () -> s
          ^
Error trace on line: 37, column: 11 in file "HostTensor".
        | x :: xs -> loop (loop s x) xs
          ^
Error trace on line: 35, column: 11 in file "HostTensor".
        | x when caseable_box_is x -> f s x
          ^
Error trace on line: 36, column: 11 in file "HostTensor".
        | () -> s
          ^
Error trace on line: 37, column: 11 in file "HostTensor".
        | x :: xs -> loop (loop s x) xs
          ^
Error trace on line: 35, column: 11 in file "HostTensor".
        | x when caseable_box_is x -> f s x
          ^
Error trace on line: 36, column: 11 in file "HostTensor".
        | () -> s
          ^
Error trace on line: 37, column: 11 in file "HostTensor".
        | x :: xs -> loop (loop s x) xs
          ^
Error trace on line: 38, column: 11 in file "HostTensor".
        | {!block_toa_map} & x -> module_foldl (inl _ -> loop) s x
          ^
Error trace on line: 39, column: 11 in file "HostTensor".
        | x -> f s x
          ^
Error trace on line: 346, column: 22 in file "HostTensor".
    toa_foldl (inl s x ->
                     ^
Error trace on line: 347, column: 9 in file "HostTensor".
        match s with
        ^
Error trace on line: 348, column: 11 in file "HostTensor".
        | .nil -> x
          ^
Error trace on line: 349, column: 11 in file "HostTensor".
        | s -> assert (s.dim = x.dim) "All tensors in zip need to have the same dimensions"; s) .nil l
          ^
Error trace on line: 166, column: 14 in file "Core".
inl assert c msg = 
             ^
Error trace on line: 167, column: 9 in file "Core".
    inl raise = 
        ^
Error trace on line: 171, column: 5 in file "Core".
    if c = false then raise msg
    ^
Error trace on line: 6, column: 16 in file "Core".
inl error_type x = !ErrorType(x)
               ^
lit All tensors in zip need to have the same dimensions
