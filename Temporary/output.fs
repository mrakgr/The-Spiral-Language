Error trace on line: 166, column: 35 in file "Cuda".
        inl join_point_entry_cuda x = !JoinPointEntryCuda(x())
                                  ^
Error trace on line: 159, column: 17 in file "Cuda".
            inl _ -> // This convoluted way of swaping non-literals for ops is so they do not get called outside of the kernel.
                ^
Error trace on line: 160, column: 21 in file "Cuda".
                inl threadIdx = {x=__threadIdxX(); y=__threadIdxY(); z=__threadIdxZ()}
                    ^
Error trace on line: 161, column: 21 in file "Cuda".
                inl blockIdx = {x=__blockIdxX(); y=__blockIdxY(); z=__blockIdxZ()}
                    ^
Error trace on line: 162, column: 21 in file "Cuda".
                inl blockDim = {x=x(); y=y(); z=z()}
                    ^
Error trace on line: 163, column: 21 in file "Cuda".
                inl gridDim = {x=x'(); y=y'(); z=z'()}
                    ^
Error trace on line: 164, column: 17 in file "Cuda".
                kernel threadIdx blockIdx blockDim gridDim
                ^
Error trace on line: 491, column: 17 in file "CudaKernel".
                forcd {from=threadIdx.y+blockDim.y*blockIdx.y-dim_in_a.from; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                ^
Error trace on line: 20, column: 15 in file "CudaKernel".
    inl forcd {d with from body} =
              ^
Error trace on line: 21, column: 13 in file "CudaKernel".
        inl finally =
            ^
Error trace on line: 26, column: 13 in file "CudaKernel".
        inl check =
            ^
Error trace on line: 34, column: 13 in file "CudaKernel".
        inl by =
            ^
Error trace on line: 40, column: 13 in file "CudaKernel".
        inl to =
            ^
Error trace on line: 45, column: 13 in file "CudaKernel".
        inl state = 
            ^
Error trace on line: 50, column: 13 in file "CudaKernel".
        inl state = {from state}
            ^
Error trace on line: 51, column: 9 in file "CudaKernel".
        whilecd {
        ^
Error trace on line: 56, column: 9 in file "CudaKernel".
        |> finally
        ^
Error trace on line: 9, column: 17 in file "CudaKernel".
    inl whilecd {cond state body} =
                ^
Error trace on line: 10, column: 13 in file "CudaKernel".
        inl r = HostTensor.create {
            ^
Error trace on line: 17, column: 9 in file "CudaKernel".
        !While((join cond r.get), (r.set <| body r.get))
        ^
Error trace on line: 54, column: 24 in file "CudaKernel".
            body = inl {from state} -> {from=from+by; state=body {state i=from}}
                       ^
Error trace on line: 491, column: 138 in file "CudaKernel".
                forcd {from=threadIdx.y+blockDim.y*blockIdx.y-dim_in_a.from; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                                                                                                                                         ^
Error trace on line: 492, column: 25 in file "CudaKernel".
                    inl in, out = in i, out i
                        ^
Error trace on line: 494, column: 25 in file "CudaKernel".
                    inl items = HostTensor.create {
                        ^
Error trace on line: 501, column: 25 in file "CudaKernel".
                    inl inner_loop =
                        ^
Error trace on line: 515, column: 29 in file "CudaKernel".
                        inl d = {blockDim redo}
                            ^
Error trace on line: 516, column: 25 in file "CudaKernel".
                        if num_valid % blockDim.x = 0 then cub_block_reduce d
                        ^
Error trace on line: 518, column: 44 in file "CudaKernel".
                        <| items.bodies.ar |> broadcast_zero
                                           ^
Error trace on line: 105, column: 12 in file "Core".
inl (|>) a b = b a
           ^
Error trace on line: 179, column: 24 in file "CudaKernel".
    inl broadcast_zero x =
                       ^
Error trace on line: 180, column: 13 in file "CudaKernel".
        inl ar = array_create_cuda_shared x 1
            ^
Error trace on line: 181, column: 9 in file "CudaKernel".
        if threadIdx.x = 0 then ar 0 <- x
        ^
Error trace on line: 578, column: 24 in file "CudaKernel".
                    if threadIdx.x = 0 then 
                       ^
Variable threadIdx not bound.
