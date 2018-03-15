Error trace on line: 149, column: 21 in file "Cuda".
                    kernel blockDim gridDim
                    ^
Error trace on line: 216, column: 17 in file "CudaKernel".
                grid_for {blockDim gridDim} .x in_a {body=inl {i} ->
                ^
Error trace on line: 72, column: 12 in file "CudaKernel".
    | .std d -> forcd {d with from by near_to}
           ^
Error trace on line: 17, column: 11 in file "CudaKernel".
inl forcd {d with from body} =
          ^
Error trace on line: 18, column: 9 in file "CudaKernel".
    inl finally =
        ^
Error trace on line: 23, column: 9 in file "CudaKernel".
    inl check =
        ^
Error trace on line: 31, column: 9 in file "CudaKernel".
    inl by =
        ^
Error trace on line: 37, column: 9 in file "CudaKernel".
    inl to =
        ^
Error trace on line: 42, column: 9 in file "CudaKernel".
    inl state = 
        ^
Error trace on line: 47, column: 9 in file "CudaKernel".
    inl state = {from state}
        ^
Error trace on line: 48, column: 5 in file "CudaKernel".
    whilecd {
    ^
Error trace on line: 53, column: 5 in file "CudaKernel".
    |> finally
    ^
Error trace on line: 6, column: 13 in file "CudaKernel".
inl whilecd {cond state body} =
            ^
Error trace on line: 7, column: 9 in file "CudaKernel".
    inl r = HostTensor.create {
        ^
Error trace on line: 14, column: 5 in file "CudaKernel".
    !While((join cond r.get), (r.set <| body r.get))
    ^
Error trace on line: 51, column: 20 in file "CudaKernel".
        body = inl {from state} -> {state=body {state i=from}; from=from+by}
                   ^
Error trace on line: 216, column: 63 in file "CudaKernel".
                grid_for {blockDim gridDim} .x in_a {body=inl {i} ->
                                                              ^
Error trace on line: 217, column: 25 in file "CudaKernel".
                    inl out = out i
                        ^
Error trace on line: 218, column: 25 in file "CudaKernel".
                    inl in = in i
                        ^
Error trace on line: 219, column: 21 in file "CudaKernel".
                    out .set (f in.get out.get)
                    ^
Error trace on line: 88, column: 26 in file "Learning".
                inl {in} adjoint -> toa_map ((|>) {in out=out()}) bck |> toa_map2 (+) adjoint
                         ^
Error trace on line: 268, column: 7 in file "HostTensor".
    | .(_) & x -> 
      ^
Error trace on line: 271, column: 7 in file "HostTensor".
    | i -> methods .apply data i
      ^
Error trace on line: 241, column: 37 in file "HostTensor".
        apply = inl {data with dim} i ->
                                    ^
Error trace on line: 242, column: 13 in file "HostTensor".
            match dim with
            ^
Error trace on line: 243, column: 15 in file "HostTensor".
            | () -> error_type "Cannot apply the tensor anymore."
              ^
Error trace on line: 6, column: 16 in file "Core".
inl error_type x = !ErrorType(x)
               ^
lit Cannot apply the tensor anymore.
