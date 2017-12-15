Error trace on line: 167, column: 5 in file "Cuda".
inl ret -> 
    ^
Error trace on line: 56, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 57, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 168, column: 9 in file "Cuda".
    use context = context
        ^
Error trace on line: 169, column: 5 in file "Cuda".
    ret {Stream context dim3 run}
    ^
Error trace on line: 7, column: 5 in file "Learning".
inl lazy = Lazy.lazy
    ^
Error trace on line: 8, column: 5 in file "Learning".
inl zero_of = function
    ^
Error trace on line: 13, column: 5 in file "Learning".
inl one_of = function
    ^
Error trace on line: 101, column: 5 in file "Learning".
inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
    ^
Error trace on line: 102, column: 5 in file "Learning".
inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
    ^
Error trace on line: 103, column: 5 in file "Learning".
inl SizeT = FS.Constructor SizeT_type
    ^
Error trace on line: 104, column: 5 in file "Learning".
inl CUdeviceptr = FS.Constructor CUdeviceptr_type
    ^
Error trace on line: 56, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 57, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 155, column: 5 in file "Learning".
use random = 
    ^
Error trace on line: 56, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 57, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 159, column: 5 in file "Learning".
use cublas =
    ^
Error trace on line: 165, column: 5 in file "Learning".
inl operation_type = fs [text: "ManagedCuda.CudaBlas.Operation"]
    ^
Error trace on line: 166, column: 5 in file "Learning".
inl to_operation = function
    ^
Error trace on line: 170, column: 5 in file "Learning".
inl isT = function
    ^
Error trace on line: 174, column: 5 in file "Learning".
inl isnT = function
    ^
Error trace on line: 110, column: 20 in file "Learning".
inl allocator size ret =
                   ^
Error trace on line: 114, column: 9 in file "Learning".
    inl pool = 
        ^
Error trace on line: 126, column: 9 in file "Learning".
    inl pool_type = type(pool)
        ^
Error trace on line: 127, column: 9 in file "Learning".
    inl stack_type = fs [text: "System.Collections.Generic.Stack"; types: pool_type]
        ^
Error trace on line: 128, column: 9 in file "Learning".
    inl stack = FS.Constructor stack_type ()
        ^
Error trace on line: 130, column: 9 in file "Learning".
    inl allocate =
        ^
Error trace on line: 150, column: 5 in file "Learning".
    ret {allocate}
    ^
Error trace on line: 736, column: 5 in file "Learning".
inb allocator = allocator 0.7
    ^
Error trace on line: 56, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 57, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 737, column: 5 in file "Learning".
use stream = Stream.create()
    ^
Error trace on line: 744, column: 5 in file "Learning".
inl test_random = 
    ^
Error trace on line: 749, column: 5 in file "Learning".
inl test_map = 
    ^
Error trace on line: 753, column: 5 in file "Learning".
inl test_map_redo =
    ^
Error trace on line: 815, column: 5 in file "Learning".
inl mnist_path = @"C:\Users\Marko\Documents\Visual Studio 2015\Projects\SpiralQ\SpiralQ\Tests"
    ^
Error trace on line: 816, column: 1 in file "Learning".
test_mnist mnist_path
^
Error trace on line: 801, column: 16 in file "Learning".
inl test_mnist mnist_path =
               ^
Error trace on line: 251, column: 33 in file "Learning".
        inl from_host_tensors x ret = 
                                ^
Error trace on line: 252, column: 17 in file "Learning".
            inl tensors = toa_map from_host_tensor x
                ^
Error trace on line: 253, column: 21 in file "Learning".
            inl r = ret tensors
                    ^
Error trace on line: 804, column: 9 in file "Learning".
    inb mnist_tensors = load_mnist_tensors mnist_path |> from_host_tensors
        ^
Error trace on line: 806, column: 9 in file "Learning".
    inl hidden_size = 10
        ^
Error trace on line: 807, column: 9 in file "Learning".
    inl input_size = 784
        ^
Error trace on line: 668, column: 76 in file "Learning".
        inl layer initializer activation hidden_size next_layer input_size ret =
                                                                           ^
Error trace on line: 304, column: 41 in file "Learning".
        inl random_create_tensor op dsc ret =
                                        ^
Error trace on line: 91, column: 13 in file "Learning".
        | 0 ret ->
            ^
Error trace on line: 92, column: 17 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                ^
Error trace on line: 93, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 305, column: 17 in file "Learning".
            inb device_tensor = create dsc
                ^
Error trace on line: 307, column: 13 in file "Learning".
            ret device_tensor
            ^
Error trace on line: 669, column: 17 in file "Learning".
            inb weight = initializer (input_size, hidden_size)
                ^
Error trace on line: 682, column: 20 in file "Learning".
        inl succ _ ret =
                   ^
Error trace on line: 683, column: 13 in file "Learning".
            ret {
            ^
Error trace on line: 670, column: 17 in file "Learning".
            inb {update_weights apply} = next_layer hidden_size
                ^
Error trace on line: 671, column: 13 in file "Learning".
            ret {
            ^
Error trace on line: 809, column: 9 in file "Learning".
    inb layers = init (sigmoid hidden_size) input_size
        ^
Error trace on line: 810, column: 9 in file "Learning".
    inl network = with_error (Error.square) layers
        ^
Error trace on line: 812, column: 9 in file "Learning".
    inl input, label = mnist_tensors.train_images, mnist_tensors.train_labels
        ^
Error trace on line: 813, column: 5 in file "Learning".
    run {network minibatch_size=128; input label}
    ^
Error trace on line: 693, column: 17 in file "Learning".
        inl run {d with network={update_weights apply} input label} =
                ^
Error trace on line: 695, column: 17 in file "Learning".
            inl to = unsafe_convert
                ^
Error trace on line: 698, column: 17 in file "Learning".
            inl {span with from near_to} = dim1 input
                ^
Error trace on line: 701, column: 17 in file "Learning".
            inl minibatch_size = match d with {minibatch_size} -> minibatch_size | _ -> span_size span
                ^
Error trace on line: 703, column: 13 in file "Learning".
            Loops.for {from near_to; state=0.0; by=minibatch_size; body = inl {state i=from} ->
            ^
Error trace on line: 720, column: 13 in file "Learning".
            |> inl unscaled_cost -> 
            ^
Error trace on line: 59, column: 14 in file "Core".
inl (>>) a b x = b (a x)
             ^
Error trace on line: 36, column: 11 in file "Loops".
        | {down} as d -> loop {d with check=match d with | {to} -> inl from -> from >= to | {near_to} -> inl from -> from > near_to}
          ^
Error trace on line: 37, column: 11 in file "Loops".
        | d -> loop {d with check=match d with | {to} -> inl from -> from <= to | {near_to} -> inl from -> from < near_to}
          ^
Error trace on line: 11, column: 18 in file "Loops".
    inl rec loop {from (near_to ^ to)=to by} as d =
                 ^
Error trace on line: 24, column: 9 in file "Loops".
        match d with
        ^
Error trace on line: 25, column: 11 in file "Loops".
        | {static} when Tuple.forall lit_is (from,to,by) -> loop_body d
          ^
Error trace on line: 26, column: 11 in file "Loops".
        | _ -> (met d -> loop_body d) {d with from=dyn from}
          ^
Error trace on line: 12, column: 23 in file "Loops".
        inl loop_body {check from by state body finally} as d =
                      ^
Error trace on line: 13, column: 13 in file "Loops".
            if check from then 
            ^
Error trace on line: 14, column: 17 in file "Loops".
                match kind with
                ^
Error trace on line: 15, column: 19 in file "Loops".
                | .Navigable ->
                  ^
Error trace on line: 19, column: 19 in file "Loops".
                | .Standard ->
                  ^
Error trace on line: 20, column: 21 in file "Loops".
                    loop {d with state=body {state i=from}; from=from+by}
                    ^
Error trace on line: 703, column: 79 in file "Learning".
            Loops.for {from near_to; state=0.0; by=minibatch_size; body = inl {state i=from} ->
                                                                              ^
Error trace on line: 704, column: 21 in file "Learning".
                inl near_to = min (from + minibatch_size) near_to
                    ^
Error trace on line: 705, column: 21 in file "Learning".
                inl span = {from near_to}
                    ^
Error trace on line: 707, column: 45 in file "Learning".
                inl {primal adjoint}, bck = apply (view input, view label) id
                                            ^
Error trace on line: 618, column: 23 in file "Learning".
        inl (>>=) a b ret =
                      ^
Error trace on line: 582, column: 29 in file "Learning".
        inl gemm' alpha A B ret =
                            ^
Error trace on line: 487, column: 23 in file "Learning".
        inl (>>=) a b ret = a <| inl a -> b a ret
                      ^
Error trace on line: 58, column: 12 in file "Core".
inl (<|) a b = a b
           ^
Error trace on line: 472, column: 42 in file "Learning".
        inl gemm transa transb alpha A B ret =
                                         ^
Error trace on line: 473, column: 17 in file "Learning".
            inl A_ty, B_ty = A.elem_type, B.elem_type
                ^
Error trace on line: 476, column: 17 in file "Learning".
            inl m = if isnT transa then rows A else cols A
                ^
Error trace on line: 477, column: 17 in file "Learning".
            inl n = if isnT transb then cols B else rows B
                ^
Error trace on line: 91, column: 13 in file "Learning".
        | 0 ret ->
            ^
Error trace on line: 92, column: 17 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                ^
Error trace on line: 93, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 479, column: 17 in file "Learning".
            inb C = create {dim=m,n; elem_type = A_ty}
                ^
Error trace on line: 481, column: 13 in file "Learning".
            ret C
            ^
Error trace on line: 487, column: 38 in file "Learning".
        inl (>>=) a b ret = a <| inl a -> b a ret
                                     ^
Error trace on line: 506, column: 30 in file "Learning".
        inl dual_make primal ret = 
                             ^
Error trace on line: 91, column: 13 in file "Learning".
        | 0 ret ->
            ^
Error trace on line: 92, column: 17 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                ^
Error trace on line: 93, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 507, column: 17 in file "Learning".
            inb adjoint = zero_like primal
                ^
Error trace on line: 508, column: 13 in file "Learning".
            ret {primal adjoint}
            ^
Error trace on line: 583, column: 17 in file "Learning".
            inb C = gemm .nT .nT alpha (primal A) (primal B) >>= dual_make
                ^
Error trace on line: 584, column: 13 in file "Learning".
            ret (C, inl _ ->
            ^
Error trace on line: 619, column: 17 in file "Learning".
            inb a,a_bck = a
                ^
Error trace on line: 542, column: 30 in file "Learning".
        inl map {fwd bck} in ret =
                             ^
Error trace on line: 543, column: 17 in file "Learning".
            inl primal, adjoint = primal in, adjoint in
                ^
Error trace on line: 487, column: 23 in file "Learning".
        inl (>>=) a b ret = a <| inl a -> b a ret
                      ^
Error trace on line: 58, column: 12 in file "Core".
inl (<|) a b = a b
           ^
Error trace on line: 330, column: 29 in file "Learning".
        inl map f (!zip in) ret =
                            ^
Error trace on line: 91, column: 13 in file "Learning".
        | 0 ret ->
            ^
Error trace on line: 92, column: 17 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                ^
Error trace on line: 93, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 331, column: 17 in file "Learning".
            inb out = create {dim=in.dim; elem_type = type (f (in.elem_type))}
                ^
Error trace on line: 333, column: 13 in file "Learning".
            ret out
            ^
Error trace on line: 487, column: 38 in file "Learning".
        inl (>>=) a b ret = a <| inl a -> b a ret
                                     ^
Error trace on line: 506, column: 30 in file "Learning".
        inl dual_make primal ret = 
                             ^
Error trace on line: 91, column: 13 in file "Learning".
        | 0 ret ->
            ^
Error trace on line: 92, column: 17 in file "Learning".
            inl tns = Tuple.foldr (inl x create -> create x) vars create
                ^
Error trace on line: 93, column: 21 in file "Learning".
            inl r = ret tns
                    ^
Error trace on line: 507, column: 17 in file "Learning".
            inb adjoint = zero_like primal
                ^
Error trace on line: 508, column: 13 in file "Learning".
            ret {primal adjoint}
            ^
Error trace on line: 544, column: 17 in file "Learning".
            inb out = map fwd primal >>= dual_make
                ^
Error trace on line: 545, column: 13 in file "Learning".
            ret (out, inl _ ->
            ^
Error trace on line: 620, column: 17 in file "Learning".
            inb b,b_bck = b a
                ^
Error trace on line: 621, column: 13 in file "Learning".
            ret (b, inl _ -> a_bck(); b_bck())
            ^
Error trace on line: 619, column: 17 in file "Learning".
            inb a,a_bck = a
                ^
Error trace on line: 623, column: 20 in file "Learning".
        inl succ x ret = ret (x, const ())
                   ^
Error trace on line: 620, column: 17 in file "Learning".
            inb b,b_bck = b a
                ^
Error trace on line: 621, column: 13 in file "Learning".
            ret (b, inl _ -> a_bck(); b_bck())
            ^
Error trace on line: 619, column: 17 in file "Learning".
            inb a,a_bck = a
                ^
Error trace on line: 618, column: 23 in file "Learning".
        inl (>>=) a b ret =
                      ^
Error trace on line: 572, column: 35 in file "Learning".
        inl map_redo {fwd bck} in ret =
                                  ^
Error trace on line: 573, column: 17 in file "Learning".
            inl primal, adjoint = primal in, adjoint in
                ^
Error trace on line: 337, column: 55 in file "Learning".
        inl map_redo {d with redo} (!zip (!to_1d in)) ret =
                                                      ^
Error trace on line: 338, column: 17 in file "Learning".
            inl in' = to_dev_tensor in
                ^
Error trace on line: 339, column: 17 in file "Learning".
            inl near_to = length in'
                ^
Error trace on line: 343, column: 17 in file "Learning".
            inl map = match d with {map} -> map | _ -> id
                ^
Error trace on line: 353, column: 13 in file "Learning".
            if near_to >= 128 then
            ^
Types in branches of If do not match.
Got: [{adjoint=ref (float32); primal=<function>}, <function>] and [{adjoint=ref (float32); primal=<function>}, <function>]
