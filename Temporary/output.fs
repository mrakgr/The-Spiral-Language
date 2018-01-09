Error trace on line: 101, column: 16 in file "Core".
inl (|>) a b = b a
               ^
Error trace on line: 41, column: 23 in file "CudaTensor".
    inl to_dev_tensor tns = 
                      ^
Error trace on line: 42, column: 9 in file "CudaTensor".
        tns.update_body (inl {body with ar offset} ->
        ^
Error trace on line: 105, column: 14 in file "Core".
inl (>>) a b x = b (a x)
             ^
Error trace on line: 78, column: 42 in file "HostTensor".
    update_body = inl {data with bodies} f -> {data with bodies=toa_map f bodies}    
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
Error trace on line: 3, column: 15 in file "Lazy".
    met f x = f x
              ^
Error trace on line: 42, column: 30 in file "CudaTensor".
        tns.update_body (inl {body with ar offset} ->
                             ^
Error trace on line: 43, column: 17 in file "CudaTensor".
            inl o = match offset with o :: _ | o -> o
                ^
Error trace on line: 45, column: 34 in file "CudaTensor".
            inl ptr, elem_type = ar.ptr(), ar.elem_type
                                 ^
Unknown type string applied to array. Got: ptr
