module Learning.Tests

open Spiral.Lib
open System.IO
open Spiral.Types
open Spiral.Tests
open Module

let learning10 =
    "learning10",[cuda_modules;learning],"Does the full training work with the char-RNN?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float
open Primitive
open Activation
open Error

inl size = {
    seq = 1115394
    minibatch = 64
    step = 64
    hot = 128
    }

// I got this dataset from Karpathy.
inl path = @"..\..\tiny_shakespeare.txt"
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

inl minibatch,seq = data.dim

inl input =
    inl data = s.CudaTensor.to_dev_tensor data 
    s.CudaKernel
        .init {rev_thread_limit=32; dim=seq,minibatch,size.hot} (inl seq minibatch ->
            inl x = data minibatch seq .get
            inl hot -> if x = to uint8 hot then 1f32 else 0f32
            )
        .round_split' size.step

inl label = input.view_span (const {from=1}) //.view_span (const 16)
inl input = input.view_span (inl x :: _ -> x-1) //.view_span (const 16)
inl data = input, label

inl network = 
    open Recurrent.Layer
    
    inl label = input size.hot
    inl input = input size.hot
    inl network =
        input
        //|> sigmoid size.hot
        |> highway_lstm size.hot |> Feedforward.Layer.sigmoid size.hot
        |> error square label
    create (input,label) network s

Loops.for' {from=0; near_to=5;body=inl {next} -> 
    open Recurrent.Passes
    open Body

    inl cost =
        for {
            data
            body=train {
                network
                optimizer=Optimizer.sgd 0.25f32
                }
            } s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        next ()
    }
    """

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

output_test_to_temp cfg @"C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\output.fs" learning10
//|> printfn "%s"
|> ignore
