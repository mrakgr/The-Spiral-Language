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
        relu 256,
        linear label_size
    init s input_size network

inl optimizer = Optimizer.sgd (0.01f32 / to float32 train_minibatch_size)

inl train {data={input label} network optimizer final} s =
    inl range = fst input.dim
    assert (range = fst label.dim) "The input and label must have the same outer dimension."
    Loops.for' {range with state=dyn 0.0; body=inl {i next state} ->
        inl input, label = input i, label i
        inb s = s.RegionMem.create'
        inl network, {input bck} = run s {input} network
        inl {out bck=bck'} = final label input s

        bck'(); bck()
        Struct.iter (inl {optimize} -> optimize optimizer) network

        inl cost = s.CudaTensor.get out |> to float64
        inl state = state + cost

        if nan_is cost then state
        else next state
        }
    |> inl cost -> cost / to float64 (HostTensor.span range)

inl test {data={input label} network final} s =
    inl range = fst input.dim
    assert (range = fst label.dim) "The input and label must have the same outer dimension."
    Loops.for' {range with state=dyn {cost=0.0;ac=0;max_ac=0}; body=inl {i next state} ->
        inl input, label = input i, label i
        inb s = s.RegionMem.create'
        inl network, {input bck} = run s {input} network
        inl {out bck=bck'} = final label input s

        inl cost = out |> s.CudaTensor.get |> to float64
        inl ac = Error.accuracy label input s |> s.CudaTensor.get
        inl max_ac = (primal input).span_outer
        inl state = {state with cost=self+cost; ac=self+ac; max_ac=self+max_ac}

        if nan_is cost then state
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
                optimizer=Optimizer.sgd (0.3f32 / to float32 train_minibatch_size)
                final=Error.softmax_cross_entropy
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


let tests =
    [|
    learning1
    |]

//rewrite_test_cache tests cfg None

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) learning1
|> printfn "%s"
|> ignore

