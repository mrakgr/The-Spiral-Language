module Learning.Main.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Learning.Cuda

let cfg = {Spiral.Types.cfg_default with trace_length=160; cuda_assert_enabled=false}

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
inl hidden_size = 10

inl network =
    open Feedforward.Layer
    () // TODO: Work in progress

Loops.for' {from=0; near_to=1; body=inl {i next} -> 
    open Feedforward.Pass
    open Body

    inl cost =
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            for {
                data={input=train_images; label=train_labels}
                body=train {
                    network=network.train
                    optimizer=Optimizer.sgd (0.0001f32 / to float32 train_minibatch_size)
                    }
                } s

    string_format "Training: {0}" (cost / to float64 train_minibatch_size) |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        inl cost, ac, max_ac =
            for {
                data={input=test_images; label=test_labels}
                body=test {network=network.test}
                } s 

        string_format "Testing: {0}({1}/{2})" (cost / to float64 test_minibatch_size, ac, max_ac) |> Console.writeline
        next ()
    }
    """


let tests =
    [|
    learning1
    |]

//rewrite_test_cache tests cfg None //(Some(0,40))

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) learning1
|> printfn "%s"
|> ignore
