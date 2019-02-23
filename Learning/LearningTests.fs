module Learning.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Cuda.Lib

let cfg = {Spiral.Types.cfg_default with trace_length=40; cuda_assert_enabled=false}

let learning1: SpiralModule =
    {
    name="learning1"
    prerequisites=[cuda_modules; learning; mnist; timer]
    opens=[]
    description="Does the training work with Mnist?"
    code=
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

inl {train_images train_labels test_images test_labels} = Struct.map (View.wrap ((), (), ())) {train_images train_labels test_images test_labels}

inl input_size = 784
inl label_size = 10

inl float = float32
inl epsilon x = to float 2 ** to float x

inl network,_ = 
    open Feedforward
    inl layer = ln_relu
    inl network = 
        layer 512,
        layer 512,
        linear label_size

    init s input_size network

inl learning_rate = epsilon -13
inl rate = {weight=learning_rate; covariance=learning_rate ** 0.85f32}
Console.writeline rate

inl train_template is_train agent out {input label} =
    inb _ = agent.region_create'
    agent.forward input
    agent.cost {label out}
    if is_train then
        agent.backward
        agent.optimize
    agent.truncate

inl train = train_template true
inl test = train_template false

inl iterate {input label} run =
    inl near_to =
        inl b :: _ = input.dim
        inl b' :: _ = label.dim
        assert (b = b') "Input and label must have the same outer dimension."
        b
    Loops.for {from=0; near_to body=inl {i} -> run <| Struct.map (inl x -> x i) {input label}}

inl agent =
    Agent.recurrent.initialize
        {rate network context=s; error=Error.softmax_cross_entropy; input=train_images}

Loops.for' {from=0; near_to=5; body=inl {i next} ->
    agent.region_create
    inl cost = agent.alloc_cost

    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ -> iterate {input=train_images; label=train_labels} (train agent {cost})
    
    inl cost = agent.get cost / to float train_images.basic.span_outer2
    if nan_is cost then 
        Console.writeline "Training diverged. Aborting..."
        agent.region_clear
    else
        Console.printfn "Training: {0}" cost

        inl cost = agent.alloc_cost
        inl accuracy = agent.alloc_accuracy
        inl max_accuracy = test_images.basic.span_outer2
        iterate {input=test_images; label=test_labels} (test agent {cost accuracy})

        inl cost, accuracy = agent.get (cost, accuracy)
        Console.printfn "Testing: {0}({1}/{2})" (cost / to float max_accuracy, accuracy, max_accuracy)

        agent.region_clear
        next ()
    }
    """
    }

let learning2: SpiralModule =
    {
    name="learning2"
    prerequisites=[cuda_modules; timer; learning]
    opens=[]
    description="Does the full training work with the char-RNN?"
    code=
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

inl {input label} =
    {input label} 
    |> Struct.map (inl x -> x.round_split' size.step)
    |> Struct.map (View.wrap ((), (), (), ()))

inl float = float32
inl epsilon x = to float 2 ** to float x

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

inl learning_rate = epsilon -13
inl rate = {weight=learning_rate; covariance=learning_rate ** 0.85f32}
Console.writeline rate

inl train agent {cost} {input label} =
    inb _ = agent.region_create'
    inl b,a =
        inl b :: a :: _ = input.dim
        inl b' :: a' :: _ = label.dim
        assert (b = b') "The input and label must have the same outer(1) dimension."
        assert (a = a') "The input and label must have the same outer(2) dimension."
        b, a

    Loops.for {from=0; near_to=b; body=inl {i} ->
        inl input, label = input i, label i
        Loops.for {from=0; near_to=a; body=inl {i} ->
            inl input, label = input i, label i
            agent.forward input
            agent.cost {label out={cost}}
            }

        agent.backward
        agent.optimize
        agent.truncate
        }

inl agent =
    Agent.recurrent.initialize
        {rate network context=s; error=Error.softmax_cross_entropy; input}

Loops.for' {from=0; near_to=5; body=inl {i next} ->
    agent.region_create
    inl cost = agent.alloc_cost

    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ -> train agent {cost} {input label}
    
    inl cost = agent.get cost / to float input.basic.span_outer3
    if nan_is cost then 
        Console.writeline "Training diverged. Aborting..."
        agent.region_clear
    else
        Console.printfn "Training: {0}" cost

        agent.region_clear
        next ()
    }
    """
    }

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) learning2
|> printfn "%s"
|> ignore
