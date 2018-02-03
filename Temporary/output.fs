Error trace on line: 16, column: 5 in file "learning10".
inl seq_len = 1115394
    ^
Error trace on line: 17, column: 5 in file "learning10".
inl minibatch_size = 128
    ^
Error trace on line: 18, column: 5 in file "learning10".
inl num_steps = 64
    ^
Error trace on line: 19, column: 5 in file "learning10".
inl one_hot_size = 128
    ^
Error trace on line: 22, column: 5 in file "learning10".
inl path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"
    ^
Error trace on line: 25, column: 5 in file "learning10".
    macro.fs (array char) [text: "System.IO.File.ReadAllText"; args: path; text: ".ToCharArray()"]
    ^
Error trace on line: 36, column: 5 in file "learning10".
    |> HostTensor.reshape (inl mini, label -> mini,label/num_steps,num_steps)
    ^
Error trace on line: 105, column: 12 in file "Core".
inl (|>) a b = b a
           ^
Error trace on line: 261, column: 15 in file "HostTensor".
inl reshape f tns = 
              ^
Error trace on line: 262, column: 9 in file "HostTensor".
    inl dim' = tns.dim
        ^
Error trace on line: 263, column: 9 in file "HostTensor".
    inl dim = tensor_update_dim f dim' |> map_dims
        ^
Error trace on line: 265, column: 5 in file "HostTensor".
    tns .update_dim (const dim)
    ^
Error trace on line: 130, column: 46 in file "HostTensor".
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
Error trace on line: 3, column: 15 in file "Lazy".
    met f x = f x
              ^
Error trace on line: 266, column: 27 in file "HostTensor".
        .update_body (inl {d with size=size' offset=o::o' ar} ->
                          ^
Error trace on line: 270, column: 21 in file "HostTensor".
                inl {size} = make_body dim'
                    ^
Error trace on line: 271, column: 17 in file "HostTensor".
                assert (size = size') "The inner sizes of the tensor being reshaped must be contiguous."
                ^
Error trace on line: 168, column: 14 in file "Core".
inl assert c msg = 
             ^
Error trace on line: 169, column: 9 in file "Core".
    inl raise = 
        ^
Error trace on line: 173, column: 5 in file "Core".
    if c = false then raise msg
    ^
Error trace on line: 6, column: 16 in file "Core".
inl error_type x = !ErrorType(x)
               ^
lit The inner sizes of the tensor being reshaped must be contiguous.
