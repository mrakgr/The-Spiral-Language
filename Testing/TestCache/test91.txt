Error trace on line: 111, column: 18 in file "Core".
inl (<<) a b x = a (b x)
                 ^
Error trace on line: 109, column: 14 in file "Core".
inl (>>) a b x = b (a x)
             ^
Error trace on line: 39, column: 16 in file "Tuple".
    inl map' f l = foldl (inl s x -> f x :: s) () l
               ^
Error trace on line: 12, column: 7 in file "Tuple".
    | x :: xs -> foldl f (f s x) xs
      ^
Error trace on line: 35, column: 39 in file "HostTensor".
        | x when caseable_box_is x -> f s x
                                      ^
Error trace on line: 39, column: 33 in file "Tuple".
    inl map' f l = foldl (inl s x -> f x :: s) () l
                                ^
Error trace on line: 47, column: 7 in file "HostTensor".
    | {from to} -> 
      ^
Error trace on line: 50, column: 7 in file "HostTensor".
    | {from near_to} as d -> 
      ^
Error trace on line: 53, column: 7 in file "HostTensor".
    | x -> 
      ^
Error trace on line: 54, column: 9 in file "HostTensor".
        assert (x > 0) "Tensor needs to be at least size 1."
        ^
Error trace on line: 122, column: 11 in file "Core".
inl (>) a b = !GT(a,b)
          ^
(is_char a || is_string a || is_numeric a || is_bool a) && get_type a = get_type b` is false.
a=<function>, b=lit 0i64
