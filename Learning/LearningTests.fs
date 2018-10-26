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

inl input_size = 784
inl label_size = 10

inl learning_rate = 2f32 ** -11f32
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
    inl near_to = fst input.dim
    assert (near_to = fst label.dim) "The input and label must have the same outer dimension."
    Loops.for' {from=0; near_to state=dyn 0.0; body=inl {i next state} ->
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
    |> inl cost -> cost / to float64 input.span_outer2

inl test {data={input label} network final} s =
    inl near_to = fst input.dim
    assert (near_to = fst label.dim) "The input and label must have the same outer dimension."
    Loops.for' {from=0; near_to state=dyn {cost=0.0;ac=0;max_ac=0}; body=inl {i next state} ->
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
    |> inl cost -> {cost with cost = self / to float64 input.span_outer2}

Loops.for' {from=0; near_to=5; body=inl {i next} -> 
    inl final = Error.square
    inl cost =
        //Timer.time_it (string_format "iteration {0}" i)
        //<| inl _ ->
            train {
                data={input=train_images; label=train_labels}
                network
                learning_rate
                final
                } s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        inl {cost ac max_ac} =
            test {
                data={input=test_images; label=test_labels}
                network
                final
                } s 

        string_format "Testing: {0}({1}/{2})" (cost, ac, max_ac) |> Console.writeline
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
    minibatch = 64
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
    |> Tensor.array_as_tensor
    |> Tensor.assert_size size.seq
    |> s.CudaTensor.from_host_tensor
    |> inl data -> data.round_split size.minibatch

inl input =
    inl minibatch,seq = data.dim
    inl data = CudaAux.to_dev_tensor data
    s.CudaFun.init {dim=seq,minibatch,size.hot} <| inl seq, minibatch, hot ->
        if data minibatch seq .get = to uint8 hot then 1f32 else 0f32

inl by :: _ = input.dim
//inl by = by / 64 // Am using only 1/64th of the dataset here in order to speed up testing on plastic RNNs.
inl input = input {from=0; by} 

inl label = input {from=1}
inl input = input {from=0; by=by-1}

inl data = {input label} |> Struct.map (inl x -> x.round_split' size.step)

inl learning_rate = 2f32 ** -12.5f32
inl n = 1f32 / to float size.step

inl network,_ =
    open Feedforward
    open RNN
    inl network =
        {
        rnn =
            rnn 128,
            linear size.hot
        }

    init s size.hot network.rnn

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
                map=inl {network s} {input label} ->
                    inl network, input = run s input network
                    inl {out bck} = final label input s
                    inl out _ = s.CudaTensor.get out |> to float64
                    inl prev = {out bck=Struct.map (inl {bck} -> bck) network, bck}
                    inl network = Struct.map (inl x -> {x without bck}) network
                    {network s prev}
                input=const {input=input (dyn 0) (dyn 0); label=label (dyn 0) (dyn 0)}
                block=()
                }
            truncate={
                map=inl {network s} _ -> truncate network s
                input=const ()
                block=()
                }
            } {network s}

    inl empty_states = List.empty ty |> dyn
    inl state = {network s} |> heap |> box ty |> dyn

    inl near_to = fst input.dim
    assert (near_to = fst label.dim) "The input and label must have the same outer(1) dimension."
    Loops.for' {from=0; near_to state={cost=dyn 0.0; state prev_states=empty_states}; 
        body=inl {i next state} ->
            inl input, label = input i, label i
            inl near_to = fst input.dim
            assert (near_to = fst label.dim) "The input and label must have the same outer(2) dimension."

            Loops.for' {from=0; near_to state
                body=inl {i next state={d with state prev_states}} ->
                    inl prev_states = List.cons state prev_states |> dyn
                    inl input, label = input i, label i
                    inl state = run state {input label}
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

                    inl state = truncate state ()

                    if nan_is cost then (match state with {s} -> s.RegionMem.clear); cost 
                    else next {cost state prev_states=empty_states}
                }
        finally=inl {cost state} -> (match state with {s} -> s.RegionMem.clear); cost
        }
    |> inl cost -> cost / to float64 input.span_outer3

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

let learning3 =
    "learning3",[cuda_modules;timer;learning;random],"Does the plastic RNN work on the Binary Pattern test?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl rng = Random(42i32)

inl make_pattern size =
    inl original = Array.init size (inl _ -> if rng.next_double > 0.5 then 1f32 else -1f32)
    inl degraded =
        inl size_half = size / 2
        inl mask = Array.init size (inl x -> if x < size_half then 0f32 else 1f32) 
        Array.shuffle_inplace rng mask
        Array.init size (inl i -> mask i * original i)
    {original degraded}

inl make_patterns n size =
    Tensor.init (n,size) (inl n ->
        inl pattern = make_pattern size
        inl n -> Struct.map (inl x -> x n) pattern
        )

inl size = {
    pattern = 50
    episode = 5
    minibatch = 1
    seq = 200

    shot = 3
    pattern_repetition = 10
    empty_input_after_repetition = 3
    }

inl data =
    make_patterns (size.seq * size.episode * size.minibatch) size.pattern 
        .reshape (inl a,b -> size.seq, size.episode, size.minibatch, b)
    |> s.CudaTensor.from_host_tensor
    |> Tensor.unzip

inl loop_over near_to f = Loops.for {from=0; near_to body=inl {i} -> f i}
inl loop_over' near_to f = Loops.for' {from=0; near_to body=inl {i next} -> f {i next}}
inl index_into i x = Struct.map (inl x -> x i) x

inl runner {network s} funs =
    inl init_state = heap {network s}
    inl elem_type, funs = Union.infer funs init_state
    
    inl init_state = box elem_type init_state
    inl network =
        inl states = ResizeArray.create {elem_type}
        states.add init_state

        function
        | .peek -> states.last
        | .pop_bcks x ->
            Loops.for {from=states.count - 1i32; by=-1i32; down_to=0i32; body=inl {i} -> 
                inl {network} = states i
                Struct.foldr (inl layer _ ->
                    match layer with
                    | {bck} -> Struct.foldr (inl bck _ -> bck x) bck ()
                    | _ -> ()
                    ) network ()
                }
            states.clear
            states.add init_state
        | .burn_in_state ->
            inl {network} = states.last
            Struct.foldr (inl layer _ ->
                match layer with
                | {init_state state} -> Struct.iter2 (inl to from -> s.CudaTensor.copy {from to}) init_state (primals state)
                | _ -> ()
                ) network ()
        | .optimize learning_rate -> Optimizer.standard learning_rate s network
        | k input ->
            (funs k) states.last input
            |> states.add

    heap network

met train {!data network learning_rate final} s =
    inl cost = 
        {
        square=ref 0f32
        sgn=ref 0
        }

    inl run = {
        map=inl {network s} input ->
            inl network, input = run s input network
            inl final label =
                inl {out=square bck} = final label input s
                inl sgn = Error.sign_accuracy label input s
                bck()
                Struct.map s.CudaTensor.get {sgn square}
            {network s final}
        input=inl _ -> data.original (dyn 0) (dyn 0)
        block=()
        }
    
    inl order = Array.init size.episode id 
    inl zero = s.CudaTensor.zero {dim=1,size.minibatch,size.pattern; elem_type=float32} (dyn 0) // This (dyn 0) is so the offset stops being a literal.

    loop_over' size.seq <| inl {next i} ->
        inl _ =
            inb s = s.RegionMem.create'
            inl network = runner {network s} {run}
            inl data = index_into i data

            loop_over size.shot <| inl _ ->
                Array.shuffle_inplace rng order

                loop_over size.episode <| inl i ->
                    loop_over size.pattern_repetition <| inl _ ->
                        network.run (data.original (order i))
                
                    loop_over size.empty_input_after_repetition <| inl _ ->
                        network.run zero

            inl i = rng.next (to int32 size.episode) |> to int64
            loop_over size.pattern_repetition <| inl _ ->
                network.run (data.degraded i)
            network.peek |> function 
                | {final} -> Struct.iter2 (inl a b -> a := a() + b) cost (final (data.original i))
                | _ -> ()
            //network.burn_in_state
            network.pop_bcks {learning_rate=learning_rate ** 0.85f32}
            network.optimize learning_rate

        inl iters = 10
        
        if (i + 1) % iters = 0 then 
            inl square = cost.square() / to float32 iters
            inl sgn = to float64 (cost.sgn()) / to float64 (iters * size.pattern)
            Console.printfn "At iteration {0} the cost and the sign accuracy are {1} and {2}/1." (i, square, sgn)
            Struct.iter (inl x -> x := to (type x()) 0) cost
            next()
        elif nan_is (cost.square()) then
            Console.printfn "At iteration {0} the cost is {1}" (i, cost.square())
        else next()

inl learning_rate = 2f32 ** -13f32
inl n = 0.005f32

inl network,_ = 
    open Feedforward
    open RNN
    inl network = 
        {
        plastic_rnn = plastic_rnn n size.pattern
        plastic_rnn' = plastic_rnn' n size.pattern
        plastic_rnn'' = plastic_rnn'' n size.pattern
        }

    init s size.pattern network.plastic_rnn''

Timer.time_it "Training"
<| inl _ ->
    Console.printfn "The learning rate is 2 ** {0}" (log learning_rate / log 2f32)
    train {
        network
        learning_rate
        final = Error.square
        } s
    """

let tests =
    [|
    learning1;learning2;learning3
    |]

//rewrite_test_cache tests cfg None 

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) learning2
|> printfn "%s"
|> ignore
