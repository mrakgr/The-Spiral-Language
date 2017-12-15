Error trace on line: 328, column: 25 in file "Learning".
                        match mode with
                        ^
Error trace on line: 329, column: 27 in file "Learning".
                        | .Add -> out .set (out .get + f (in .get)) 
                          ^
Error trace on line: 543, column: 25 in file "Learning".
                inl bck x = filter_based_on_adjoints (bck x) adjoint
                        ^
Error trace on line: 625, column: 35 in file "Learning".
        inl multiply_by_adjoint f {d with out={A P} in} = toa_map ((*) A) (f {in out=P})
                                  ^
Error trace on line: 4, column: 15 in file "HostTensor".
inl toa_map f x = 
              ^
Error trace on line: 11, column: 5 in file "HostTensor".
    loop x
    ^
Error trace on line: 6, column: 11 in file "HostTensor".
        | x when caseable_is x -> f x
          ^
Error trace on line: 7, column: 11 in file "HostTensor".
        | () -> ()
          ^
Error trace on line: 8, column: 11 in file "HostTensor".
        | x :: xs -> loop x :: loop xs
          ^
Error trace on line: 9, column: 11 in file "HostTensor".
        | {!block_toa_map} & x -> module_map (inl _ -> loop) x
          ^
Error trace on line: 10, column: 11 in file "HostTensor".
        | x -> f x
          ^
Error trace on line: 53, column: 11 in file "Core".
inl (*) a b = !Mult(a,b)
          ^
`is_numeric a && get_type a = get_type b` is false.
a=[], b=var (float32)
