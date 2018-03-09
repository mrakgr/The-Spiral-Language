Error trace on line: 4, column: 5 in file "learning10".
inl float = float32
    ^
Error trace on line: 11, column: 5 in file "learning10".
inl size = {
    ^
Error trace on line: 19, column: 5 in file "learning10".
inl path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"
    ^
Error trace on line: 20, column: 5 in file "learning10".
inl data = 
    ^
Error trace on line: 32, column: 5 in file "learning10".
inl minibatch,seq = data.dim
    ^
Error trace on line: 33, column: 5 in file "learning10".
inl input =
    ^
Error trace on line: 42, column: 1 in file "learning10".
print_static (input.round size.step .split (inl a :: _ -> size.step, a/size.step))
^
Error trace on line: 261, column: 26 in file "HostTensor".
        split = inl data f -> split f (facade data)
                         ^
Error trace on line: 124, column: 13 in file "HostTensor".
inl split f tns =
            ^
Error trace on line: 146, column: 9 in file "HostTensor".
    inl prev_dim, dim =
        ^
Error trace on line: 165, column: 5 in file "HostTensor".
    tns .set_dim (concat dim)
    ^
Error trace on line: 232, column: 46 in file "HostTensor".
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
Error trace on line: 166, column: 27 in file "HostTensor".
        .update_body (inl d -> {d with size=update_size (self,dim)})
                          ^
Error trace on line: 134, column: 25 in file "HostTensor".
    inl rec update_size x = 
                        ^
Error trace on line: 136, column: 9 in file "HostTensor".
        match x with
        ^
Error trace on line: 137, column: 11 in file "HostTensor".
        | init :: s', dim :: x' ->
          ^
Error trace on line: 138, column: 24 in file "HostTensor".
            inl next = update_size (s', x')
                       ^
Error trace on line: 134, column: 25 in file "HostTensor".
    inl rec update_size x = 
                        ^
Error trace on line: 136, column: 9 in file "HostTensor".
        match x with
        ^
Error trace on line: 137, column: 11 in file "HostTensor".
        | init :: s', dim :: x' ->
          ^
Error trace on line: 138, column: 24 in file "HostTensor".
            inl next = update_size (s', x')
                       ^
Error trace on line: 134, column: 25 in file "HostTensor".
    inl rec update_size x = 
                        ^
Error trace on line: 136, column: 9 in file "HostTensor".
        match x with
        ^
Error trace on line: 137, column: 11 in file "HostTensor".
        | init :: s', dim :: x' ->
          ^
Error trace on line: 144, column: 11 in file "HostTensor".
        | (), () -> ()
          ^
Pattern miss error. The argument is [[lit 1i64], []]
