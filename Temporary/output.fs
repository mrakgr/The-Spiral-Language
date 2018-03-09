Error trace on line: 475, column: 33 in file "Learning".
                            inl cost' = cost' + to float64 (cost ())
                                ^
Error trace on line: 477, column: 33 in file "Learning".
                            inl s = s.RegionMem.create
                                ^
Error trace on line: 480, column: 33 in file "Learning".
                                HostTensor.toa_map (inl {primal} ->
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
Error trace on line: 196, column: 18 in file "Core".
inl module_map f a = !ModuleMap(f,a)
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
Error trace on line: 480, column: 57 in file "Learning".
                                HostTensor.toa_map (inl {primal} ->
                                                        ^
Error trace on line: 481, column: 37 in file "Learning".
                                    primal.update_body (inl {x with ar} -> s.RegionMem.assign ar; x)
                                    ^
Error trace on line: 225, column: 46 in file "HostTensor".
        update_body = inl {data with bodies} f -> {data with bodies=toa_map f bodies} |> facade
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
Error trace on line: 481, column: 61 in file "Learning".
                                    primal.update_body (inl {x with ar} -> s.RegionMem.assign ar; x)
                                                            ^
Error trace on line: 12, column: 28 in file "Region".
inl assign {region_name} s r = 
                           ^
Error trace on line: 13, column: 9 in file "Region".
    inl region = s region_name
        ^
Error trace on line: 14, column: 5 in file "Region".
    join r.inc; region.add r
    ^
Error trace on line: 57, column: 7 in file "CudaTensor".
    | .elem_type -> elem_type
      ^
Error trace on line: 58, column: 7 in file "CudaTensor".
    | .ptr -> ptr
      ^
Pattern miss error. The argument is type (type_lit (inc))
