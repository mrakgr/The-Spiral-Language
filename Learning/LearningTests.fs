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

inl {train_images train_labels test_images test_labels} = Struct.map (View.wrap ((), (), ())) {train_images train_labels test_images test_labels}

inl input_size = 784
inl label_size = 10

inl float = float32
inl epsilon x = to float 2 ** to float x
inl network,_ =
    open Feedforward
    inl network =
        //ln_relu 512,
        //ln_relu 512,
        linear label_size

    init s input_size network

inl train {data={input label} network final} s =
    inl near_to = fst input.dim
    assert (near_to = fst label.dim) "The input and label must have the same outer dimension."
    Loops.for' {from=0; near_to state=dyn 0.0; body=inl {i next state} ->
        inl input, label = input i, label i
        inl state =
            inb s = s.RegionMem.create'
            inl network, input = run s input network
            inl {out bck} = final label input s

            bck()
            Struct.foldr (inl {bck} _ -> Struct.foldr (inl bck _ -> bck()) bck ()) network ()
            Optimizer.standard s network

            inl cost = s.CudaTensor.get out |> to float64
            state + cost

        if nan_is state then state else next state
        }
    |> inl cost -> cost / to float64 input.basic.span_outer2

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
            inl max_ac = (primal input).basic.span_outer
            {state with cost=self+cost; ac=self+ac; max_ac=self+max_ac}

        if nan_is state.cost then state
        else next state
        }
    |> inl cost -> {cost with cost = self / to float64 input.basic.span_outer2}

inl learning_rate = epsilon -13
inl pars = {rate={weight=learning_rate; covariance=learning_rate ** 0.85f32; noise=epsilon 0; l2=0.0f32}}
Console.writeline pars
Loops.for' {from=0; near_to=45; body=inl {i next} -> 
    inl final = Error.softmax_cross_entropy
    inl cost =
        inl s = s.data_add pars
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            train {
                data={input=train_images; label=train_labels}
                network
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

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) learning1
|> printfn "%s"
|> ignore
