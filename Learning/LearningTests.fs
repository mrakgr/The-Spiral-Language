module Learning.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Cuda.Lib

let cfg = {Spiral.Types.cfg_default with trace_length=40; cuda_assert_enabled=false}

let learning1 =
    "learning1",[cuda_modules;learning;mnist;timer],"Does the training work with Mnist?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl train_minibatch_size = 128
inl test_minibatch_size = 128
inl {test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors

inl {train_images train_labels} = module_map (inl _ x -> x.round_split' train_minibatch_size) {train_images train_labels}
inl {test_images test_labels} = module_map (inl _ x -> x.round_split' test_minibatch_size) {test_images test_labels}

/// Temporary measure to make the test go faster.
//inl train_images, train_labels = Tuple.map (inl x -> x.view_span (inl x :: _ -> x/10)) (train_images,train_labels)

inl input_size = 784
inl label_size = 10

inl network,_ =
    open Feedforward
    inl network =
        relu 256,
        linear label_size
    //inl network =
    //    prong {activation=Activation.relu; size=256},
    //    prong {activation=Activation.linear; size=label_size}

    init s input_size network

inl train {data={input label} network learning_rate final} s =
    inl range = fst input.dim
    assert (range = fst label.dim) "The input and label must have the same outer dimension."
    Loops.for' {range with state=dyn 0.0; body=inl {i next state} ->
        inl input, label = input i, label i
        inl state =
            inb s = s.RegionMem.create'
            inl network, input = run s input network
            inl {out bck} = final label input s

            inl _ =
                inl learning_rate = learning_rate ** 0.85f32
                inl apply bck = bck {learning_rate} |> ignore
                apply bck
                Struct.foldr (inl {bck} _ -> Struct.foldr (inl bck _ -> apply bck) bck ()) network ()

            Optimizer.standard learning_rate s network

            inl cost = s.CudaTensor.get out |> to float64
            state + cost

        if nan_is state then state else next state
        }
    |> inl cost -> cost / to float64 (HostTensor.span range)

inl test {data={input label} network final} s =
    inl range = fst input.dim
    assert (range = fst label.dim) "The input and label must have the same outer dimension."
    Loops.for' {range with state=dyn {cost=0.0;ac=0;max_ac=0}; body=inl {i next state} ->
        inl input, label = input i, label i
        inl state =
            inb s = s.RegionMem.create'
            inl network, input = run s input network
            inl {out} = final label input s

            inl cost = out |> s.CudaTensor.get |> to float64
            inl ac = Error.accuracy label input s |> s.CudaTensor.get
            inl max_ac = (primal input).span_outer
            {state with cost=self+cost; ac=self+ac; max_ac=self+max_ac}

        if nan_is state.cost then state
        else next state
        }
    |> inl cost -> {cost with cost = self / to float64 (HostTensor.span range)}

Loops.for' {from=0; near_to=5; body=inl {i next} -> 
    inl cost =
        //Timer.time_it (string_format "iteration {0}" i)
        //<| inl _ ->
            train {
                data={input=train_images; label=train_labels}
                network
                learning_rate = 2f32 ** -7f32
                final = Error.softmax_cross_entropy
                } s

    string_format "Training: {0}" (cost / to float64 train_minibatch_size) |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        inl {cost ac max_ac} =
            test {
                data={input=test_images; label=test_labels}
                network
                final=Error.softmax_cross_entropy
                } s 

        string_format "Testing: {0}({1}/{2})" (cost / to float64 test_minibatch_size, ac, max_ac) |> Console.writeline
        next ()
    }
    """

let learning2 =
    "learning2",[cuda_modules;timer;learning],"Does the full training work with the char-RNN?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl size = {
    seq = 1115394
    minibatch = 1
    step = 64
    hot = 128
    }

// I got this dataset from Karpathy.
inl path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"
inl data = 
    macro.fs (array char) [text: "System.IO.File.ReadAllText"; args: path; text: ".ToCharArray()"]
    |> Array.map (inl x -> 
        inl x = to int64 x
        assert (x < size.hot) "The inputs need to be in the [0,127] range."
        to uint8 x
        )
    |> HostTensor.array_as_tensor
    |> HostTensor.assert_size size.seq
    |> s.CudaTensor.from_host_tensor
    |> inl data -> data.round_split size.minibatch

inl input =
    inl minibatch,seq = data.dim
    inl data = CudaAux.to_dev_tensor data
    s.CudaFun.init {dim=seq,minibatch,size.hot} <| inl seq, minibatch, hot ->
        if data minibatch seq .get = to uint8 hot then 1f32 else 0f32

inl input = input.view_span (inl x :: _ -> x / 64) // Am using only 1/64th of the dataset here in order to speed up testing on plastic RNNs.

inl label = input.view_span (const {from=1}) 
inl input = input.view_span (inl x :: _ -> x-1) 

inl data = {input label} |> Struct.map (inl x -> x.round_split' size.step)

inl learning_rate = 2f32 ** -9f32

inl network,_ =
    open Feedforward
    open RNN
    //inl network =
    //    mi_prong 128, 
    //    prong {activation=Activation.linear; size=size.hot}
    inl network =
        plastic_hebb',
        linear size.hot
    //inl network =
    //    mi 128,
    //    linear size.hot

    init s size.hot network

inl truncate network s' =
    inl s = s'.RegionMem.create
    inl network = 
        Struct.map (function
            | {state} as d -> {d without bck with state = Struct.map (inl x -> x.update_body (inl {x with ar} -> s.RegionMem.assign ar.ptr; x)) (primals state) |> heap}
            | d -> {d without bck}
            ) network
    s'.RegionMem.clear
    s.refresh
    {network s}

met train {data={input label} network learning_rate final} s =
    inl s = s.RegionMem.create

    inl ty, {run truncate} = 
        Union.infer {
            run={
                map=inl {state={network s} input={input label}} ->
                    inl network, input = run s input network
                    inl {out bck} = final label input s
                    inl out _ = s.CudaTensor.get out |> to float64
                    inl prev = {out bck=Struct.map (inl {bck} -> bck) network, bck}
                    inl network = Struct.map (inl x -> {x without bck}) network
                    {state={network s prev}}
                input=const {input=input (dyn 0) (dyn 0); label=label (dyn 0) (dyn 0)}
                block=()
                }
            truncate={
                map=inl {state={network s}} -> {state=truncate network s}
                input=const ()
                block=()
                }
            } {network s}

    inl empty_states = List.empty ty |> dyn
    inl state = {network s} |> heap |> box ty |> dyn

    inl range = fst input.dim
    assert (range = fst label.dim) "The input and label must have the same outer(1) dimension."
    Loops.for' {range with state={cost=dyn 0.0; state prev_states=empty_states}; 
        body=inl {i next state} ->
            inl input, label = input i, label i
            inl range = fst input.dim
            assert (range = fst label.dim) "The input and label must have the same outer(2) dimension."

            Loops.for' {range with state
                body=inl {i next state={d with state prev_states}} ->
                    inl prev_states = List.cons state prev_states |> dyn
                    inl input, label = input i, label i
                    inl {state} = run {state input={input label}}
                    next {d with prev_states state}
                finally=inl {state with cost state prev_states} ->
                    inl prev_states = List.cons state prev_states |> dyn
                    List.foldl (inl _ -> function
                        | {prev={bck}} ->
                            inl learning_rate = learning_rate ** 0.85f32
                            inl apply bck = bck {learning_rate} |> ignore
                            Struct.foldr (inl bck _ -> apply bck) bck ()
                        | _ -> ()
                        ) () prev_states

                    Optimizer.standard learning_rate s network
                    inl cost =
                        List.foldl (inl cost -> function
                            | {prev={out}} -> cost + out()
                            | _ -> cost
                            ) cost prev_states

                    inl {state} = truncate {state input=()}

                    if nan_is cost then (match state with {s} -> s.RegionMem.clear); cost 
                    else next {cost state prev_states=empty_states}
                }
        finally=inl {cost state} -> (match state with {s} -> s.RegionMem.clear); cost
        }
    |> inl cost -> cost / to float64 input.span_outer2

inl f (!dyn learning_rate) next i =
    Console.printfn "The learning rate is 2 ** {0}" (log learning_rate / log 2f32)
    inl cost =
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            train {
                data network
                learning_rate
                final = Error.softmax_cross_entropy
                } s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then Console.writeline "Training diverged. Aborting..."
    else next ()

Loops.for' {from=0; near_to=5; body=inl {i next} -> f learning_rate next i}
    """

let tests =
    [|
    learning1;learning2
    |]

//rewrite_test_cache tests cfg None

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) learning2
|> printfn "%s"
|> ignore

