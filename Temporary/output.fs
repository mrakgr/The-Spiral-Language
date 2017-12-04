Error trace on line: 3, column: 1 in file "test96".
init (3,3) (inl a b -> a*b) .view ({from=1; near_to=3},{from=1; near_to=3})
^
Error trace on line: 4, column: 1 in file "test96".
|> copy
^
Error trace on line: 57, column: 12 in file "Core".
inl (|>) a b = b a
           ^
Error trace on line: 195, column: 11 in file "HostTensor".
inl map f tns =
          ^
Error trace on line: 196, column: 9 in file "HostTensor".
    inl size = tns.dim
        ^
Error trace on line: 201, column: 5 in file "HostTensor".
    init size (loop tns size)
    ^
Error trace on line: 187, column: 15 in file "HostTensor".
inl init size f =
              ^
Error trace on line: 188, column: 9 in file "HostTensor".
    inl dim = Tuple.wrap size
        ^
Error trace on line: 189, column: 21 in file "HostTensor".
    inl elem_type = type (Tuple.foldl (inl f _ -> f 0) f dim)
                    ^
Error trace on line: 15, column: 7 in file "Tuple".
    | x :: xs -> foldl f (f s x) xs
      ^
Error trace on line: 189, column: 46 in file "HostTensor".
    inl elem_type = type (Tuple.foldl (inl f _ -> f 0) f dim)
                                             ^
Error trace on line: 198, column: 26 in file "HostTensor".
        | _ :: x' -> inl x -> loop (tns x) x' 
                         ^
Error trace on line: 141, column: 11 in file "HostTensor".
        | .replace_module module -> wrap_tensor_template module data
          ^
Error trace on line: 142, column: 11 in file "HostTensor".
        | (.elem_type | .get | .set) & x -> module x data
          ^
Error trace on line: 143, column: 11 in file "HostTensor".
        | .(_) & x -> 
          ^
Error trace on line: 146, column: 11 in file "HostTensor".
        | i -> module .apply data i |> wrap
          ^
Error trace on line: 96, column: 33 in file "HostTensor".
    apply = inl {data with dim} i ->
                                ^
Error trace on line: 97, column: 9 in file "HostTensor".
        match dim with
        ^
Error trace on line: 98, column: 11 in file "HostTensor".
        | () -> error_type "Cannot apply the tensor anymore."
          ^
Error trace on line: 99, column: 11 in file "HostTensor".
        | {from near_to} :: dim ->
          ^
Error trace on line: 100, column: 13 in file "HostTensor".
            assert (i >= from && i < near_to) "Argument out of bounds." 
            ^
Error trace on line: 93, column: 14 in file "Core".
inl assert c msg = 
             ^
Error trace on line: 96, column: 9 in file "Core".
    inl raise = 
        ^
Error trace on line: 100, column: 5 in file "Core".
    if c = false then raise msg
    ^
Error trace on line: 4, column: 16 in file "Core".
inl error_type x = !ErrorType(x)
               ^
lit Argument out of bounds.
