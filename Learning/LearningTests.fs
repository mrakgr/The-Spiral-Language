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

inl network = 
    open Feedforward
    inl layer = ln_relu

    layer 512,
    layer 512,
    linear label_size

inl learning_rate = epsilon -13
inl pars = {rate={weight=learning_rate; covariance=learning_rate ** 0.85f32}}
Console.writeline pars

inl agent = 
    feedforward 
        .with_context s
        .initialize network (train_images 0)
        .with_pars pars
        .with_error Error.softmax_cross_entropy

inl train_template is_train agent {outs with cost} {input label} =
    inb _ = agent.with_region
    agent.forward input
    agent.cost {label out=cost}
    match outs with {accuracy max_accuracy} -> agent.accuracy {label=train_labels; out={accuracy max_accuracy}} | _ -> ()
    if is_train then
        agent.backward
        agent.optimize

inl train = train_template true
inl test = train_template false

Loops.for' {from=0; near_to=5; body=inl {i next} -> 
    agent.push_region
    inl cost = agent.alloc_cost
    Timer.time_it (string_format "iteration {0}" i)
    <| inl _ -> iterate {input=train_images; label=train_labels} (train agent {cost})

    inl cost = agent.get cost
    if nan_is cost then 
        Console.writeline "Training diverged. Aborting..."
    else
        string_format "Training: {0}" cost |> Console.writeline

        inl cost = agent.alloc_cost
        inl accuracy, max_accuracy = agent.alloc_accuracy
        iterate {input=test_images; label=test_labels} (test agent {cost accuracy max_accuracy})

        string_format "Testing: {0}({1}/{2})" (agent.get (cost, accuracy, max_accuracy)) |> Console.writeline

        agent.pop_region
        next ()
    }
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) learning1
|> printfn "%s"
|> ignore
