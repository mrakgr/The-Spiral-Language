inl force x ret = ret (x.value)
inl (>>=) a b ret = a <| inl a -> b a ret
inl succ a ret = ret a

inb allocator = allocator 0.7
use stream = Stream.create()
open Learning {allocator stream}
open HostTensor
open CudaTensor
open CudaKernels
open Console

inl test_random = 
    inm device_tensor = create {dim=32; elem_type=float32}
    random_fill {op=.LogNormal; stddev=1.0f32; mean=0f32} device_tensor
    to_host_tensor device_tensor |> show_tensor_all |> writeline |> succ
    
inl test_map = 
    inl host_tensor = HostTensor.init 32 (unsafe_convert float32)
    from_host_tensor host_tensor >>= map ((*) (dyn 2f32)) >>= (to_host_tensor >> show_tensor_all >> writeline >> succ)

inl test_map_redo =
    inl host_tensor = HostTensor.init (dyn 64) (unsafe_convert float32)
    from_host_tensor host_tensor >>= map_redo {redo=(+); neutral_elem=0f32} >>= force >>= (writeline >> succ)

inl test_mnist_feedforward mnist_path =
    inb mnist_tensors = load_mnist_tensors mnist_path |> from_host_tensors

    inl hidden_size = 10
    inl input_size = 784

    inl create' dim = 
        inl sqrt x = FS.UnOp .sqrt x x
        inl stddev = sqrt (2f32 / unsafe_convert float32 (Tuple.foldl (+) 0 dim))
        random_create_tensor {op=.Normal; stddev mean=0f32} {dim elem_type=float32}

    inb weight = create' (input_size, hidden_size)
    inl sigmoid x = 1f32 / (1f32 + (exp (-x)))

    inl Error = {
        cross_entropy = inl (x,y) -> -(y * log x + (1f32-y) * log (1f32-x))
        square = inl (x,y) -> (y - x) * (y - x)
        }

    inl pass (input,test) =
        gemm .nT .nT 1f32 input weight 
        >>= map sigmoid 
        >>= inl input -> map_redo {map=Error.square; redo=(+); neutral_elem=0f32} (input,test)
        >>= force
        >>= (writeline >> succ)
        |> heap

    inl iterate minibatch_size (train,test) =
        inl dim1 x = x.dim |> fst
        inl near_to = dim1 train |> inl {near_to} -> near_to 
        assert (dim1 train = dim1 test) "Training and test set need to have to equal first dimensions."

        Loops.for {from=0; near_to; by=minibatch_size; body = inl {i=from} ->
            inl near_to = min (from + minibatch_size) near_to
            inl span = {from near_to}
            inl view x = x.view_span span
            string_format "On span {0}" (show span) |> writeline
            pass (view train, view test) id
            }

    iterate 128 (mnist_tensors.train_images,mnist_tensors.train_labels)