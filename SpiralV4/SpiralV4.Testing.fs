namespace SpiralV4

open FSharp.Charting

module Embel =
    let random_seed_system_random = Some 42
    let random_seed_GPU = Some 42UL

    open System
    open System.IO
    open System.Diagnostics

    type Result =
        | Success
        | Failure of string

    type Tally =
        {
        mutable succeeded : int
        mutable failed : int
        mutable ignored : int
        mutable am_ignoring : bool
        mutable label : string
        time_elapsed : Stopwatch
        output : StreamWriter
        }

        static member create(output: StreamWriter) =
            {succeeded=0; failed=0; ignored=0; am_ignoring=false; label=""; time_elapsed=Stopwatch.StartNew(); output=output}
        static member create() =
            let x = Console.OpenStandardError() |> fun x -> new StreamWriter(x)
            x.AutoFlush <- true
            Tally.create x

        override t.ToString() =
            [|
            sprintf "Test tally: Succeeded: %i" t.succeeded
            sprintf "            Failed: %i" t.failed
            sprintf "            Ignored: %i" t.ignored
            sprintf "            Time Elapsed: %A" t.time_elapsed.Elapsed
            |] |> String.concat "\n"

        interface IDisposable with
            member t.Dispose() = t.output.Dispose()

    /// The internal function for running tests.
    let inline runTestCase (x: ^a) (name: string, code: ^a -> Result) (state: Tally) =
        match random_seed_GPU with
        | Some v ->
            cudaRandom.SetOffset(0UL)
            cudaRandom.SetPseudoRandomGeneratorSeed(v)
        | None -> ()

        if state.am_ignoring then
            state.ignored <- state.ignored+1
            state
        else
            match code x with
            | Success -> state.succeeded <- state.succeeded+1
            | Failure mes -> 
                let sep = if String.IsNullOrEmpty state.label then null else "/"
                let mes = if String.IsNullOrEmpty mes = false then ": " + mes else null
                state.output.WriteLine(sprintf "Test %s%s%s failed%s" state.label sep name mes)
                state.failed <- state.failed+1
            state

    /// Applies a label to a test. Used internally by the other functions.
    let testLabel (label: string) (test: Tally -> Tally) (state: Tally) =
        let backup = state.label
        state.label <- 
            let x = if String.IsNullOrEmpty backup then "" else "/"
            String.concat null [|backup; x; label|]
        test state |> fun state -> state.label <- backup; state

    /// Tests a single test case
    let inline testCase label (setup: unit -> ^a) (test: (string * (^a -> Result))) =
        fun (state: Tally) -> 
            use x = setup () 
            runTestCase x test state
        |> testLabel label

    /// Tests an array of cases with the data from the setup function shared amongst the functions.
    let inline testCases (label: string) (setup: unit -> ^a) (tests: (string * (^a -> Result))[]) =
        fun (state: Tally) ->
            use x = setup ()
            Array.fold(fun state test -> 
                runTestCase x test state) state tests
        |> testLabel label

    /// Tests an array of cases with the data from the setup function instantiated separately for each function.
    let inline testCases' (label: string) (setup: unit -> ^a) (tests: (string * (^a -> Result))[]) =
        fun (state: Tally) -> Array.fold(fun state test -> use x = setup () in runTestCase x test state) state tests
        |> testLabel label

    /// Sequentially runs the array of tests
    let testArray (label: string) (tests: (Tally -> Tally)[]) =
        fun (state: Tally) -> Array.fold(fun state test -> test state) state tests
        |> testLabel label

    /// Ignores the selected tests.
    let testIgnore (test: (Tally -> Tally)) (state: Tally) =
        let backup = state.am_ignoring
        state.am_ignoring <- true
        test state |> fun state -> state.am_ignoring <- backup; state

    /// Turns the result of a boolean into the Result type.
    let assertTest (label: string) =
        function
        | true -> Success
        | false -> Failure label

    /// The main run function
    let run (tree: Tally -> Tally) =
        use tally = Tally.create() |> tree
        tally.ToString() |> tally.output.WriteLine // The final output

module private Testing =
    open System
    open System.IO
    open System.Collections.Generic

    open Embel
    open ManagedCuda
    open ManagedCuda.BasicTypes
    open System.Windows

    let size_gradcheck = 8

    type GradientCheckingData =
        {
        inputd2M: d2M
        outputd2M: d2M
        }

        static member create() =
            use str = new CudaStream()
            cudaRandom.SetPseudoRandomGeneratorSeed(0UL) // I want this to be always deterministic.
            cudaRandom.SetOffset(0UL)
            let inputd2M = d2M.create(size_gradcheck,2) |> fun x -> fillRandomUniformMatrix str x 1.0f 0.0f; x
            let outputd2M = d2M.create(size_gradcheck,2) |> fun x -> fillRandomUniformMatrix str x 1.0f 0.0f; x
            {inputd2M = inputd2M; outputd2M=outputd2M}

        interface IDisposable with
            member t.Dispose() =
                t.inputd2M |> dispose
                t.outputd2M |> dispose

    type MnistData =
        {
        training_set : (d2M * d2M)[]
        test_set : (d2M * d2M)[]
        }

        static member create minibatch_size mnist_path () =
            let load_mnist filename =
                use f = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read)
                use d = new BinaryReader(f)

                let magicnumber = d.ReadInt32() |> Net.IPAddress.NetworkToHostOrder
                match magicnumber with
                | 2049 -> // Labels
                    let n = d.ReadInt32() |> Net.IPAddress.NetworkToHostOrder
                    d.ReadBytes n
                    |> Array.collect (
                        fun x -> 
                            let t = Array.zeroCreate 10
                            t.[int x] <- 1.0f
                            t)
                    |> Array.chunkBySize (minibatch_size*10)
                    |> Array.map (fun x -> (10,x.Length/10,x) |> d2M.createConstant )
                | 2051 -> // Images
                    let n = d.ReadInt32() |> Net.IPAddress.NetworkToHostOrder
                    let rows = d.ReadInt32() |> Net.IPAddress.NetworkToHostOrder
                    let cols = d.ReadInt32() |> Net.IPAddress.NetworkToHostOrder
                    d.ReadBytes(n * rows * cols)
                    |> Array.map (fun x -> float32 x / 255.0f)
                    |> Array.chunkBySize (minibatch_size*rows*cols)
                    |> Array.map (fun x ->  (rows*cols,x.Length/(rows*cols),x) |> d2M.createConstant)
                | _ -> failwith "Given file is not in the MNIST format."

            let [|test_images;test_labels;train_images;train_labels|] = 
                [|"t10k-images.idx3-ubyte";"t10k-labels.idx1-ubyte";"train-images.idx3-ubyte";"train-labels.idx1-ubyte"|]
                |> Array.map (fun x -> Path.Combine(mnist_path,x) |> load_mnist)

            {
            training_set = Array.zip train_images train_labels
            test_set = Array.zip test_images test_labels
            }

        interface IDisposable with
            member t.Dispose() =
                for x,y in t.training_set do x |> dispose; y |> dispose
                for x,y in t.test_set do x |> dispose; y |> dispose

    type ReberData =
        {
        data : Dictionary<int, (d2M*d2M)[][]>
        }

        static member create() =
            let rng = 
                match random_seed_system_random with
                | Some random_seed -> System.Random(random_seed)
                | None -> System.Random()

            let b_string = [|1.0f;0.0f;0.0f;0.0f;0.0f;0.0f;0.0f|]
            let t_string = [|0.0f;1.0f;0.0f;0.0f;0.0f;0.0f;0.0f|]
            let p_string = [|0.0f;0.0f;1.0f;0.0f;0.0f;0.0f;0.0f|]
            let s_string = [|0.0f;0.0f;0.0f;1.0f;0.0f;0.0f;0.0f|]
            let x_string = [|0.0f;0.0f;0.0f;0.0f;1.0f;0.0f;0.0f|]
            let v_string = [|0.0f;0.0f;0.0f;0.0f;0.0f;1.0f;0.0f|]
            let e_string = [|0.0f;0.0f;0.0f;0.0f;0.0f;0.0f;1.0f|]

            let t_p_string = [|0.0f;1.0f;1.0f;0.0f;0.0f;0.0f;0.0f|]
            let t_v_string = [|0.0f;1.0f;0.0f;0.0f;0.0f;1.0f;0.0f|]
            let s_x_string = [|0.0f;0.0f;0.0f;1.0f;1.0f;0.0f;0.0f|]
            let p_v_string = [|0.0f;0.0f;1.0f;0.0f;0.0f;1.0f;0.0f|]

            let make_random_reber_string str path prediction =
                let rec nodeF _ _ _ = // Only outputs B. First node.
                    nodeS "B" [b_string] [b_string]
                and nodeS str path prediction = // Can only receive B. Outputs T or P.
                    let p = rng.NextDouble()
                    if p > 0.5 then node0a (str+"T") (t_string::path) (t_p_string::prediction) else node0b (str+"P") (p_string::path) (t_p_string::prediction)
                and node0a str path prediction = // Can only receive T. Outputs B.
                    node1a (str+"B") (b_string::path) (b_string::prediction)
                and node1a str path prediction = // Can only receive B. Outputs T or P.
                    let p = rng.NextDouble()
                    if p > 0.5 then node2a (str+"T") (t_string::path) (t_p_string::prediction) else node3a (str+"P") (p_string::path) (t_p_string::prediction)
                and node2a str path prediction = // Can receive T or S. Outputs S or X.
                    let p = rng.NextDouble()
                    if p > 0.5 then node2a (str+"S") (s_string::path) (s_x_string::prediction) else node4a (str+"X") (x_string::path) (s_x_string::prediction)
                and node3a str path prediction = // Can receive P or T. Outputs V or T.
                    let p = rng.NextDouble()
                    if p > 0.5 then node3a (str+"T") (t_string::path) (t_v_string::prediction) else node5a (str+"V") (v_string::path) (t_v_string::prediction)
                and node4a str path prediction = // Can receive X or P. Outputs X or S.
                    let p = rng.NextDouble()
                    if p > 0.5 then node3a (str+"X") (x_string::path) (s_x_string::prediction) else node6a (str+"S") (s_string::path) (s_x_string::prediction)
                and node5a str path prediction = // Can only receive V. Outputs P or V.
                    let p = rng.NextDouble()
                    if p > 0.5 then node4a (str+"P") (p_string::path) (p_v_string::prediction) else node6a (str+"V") (v_string::path) (p_v_string::prediction)
                and node6a str path prediction = // Can receive S or V. Outputs E.
                    node7a (str+"E") (e_string::path) (e_string::prediction)
                and node7a str path prediction = // Can only receive E. Outputs T.
                    node8 (str+"T") (t_string::path) (t_string::prediction)
                and node0b str path prediction = // Can only receive P. Outputs B.
                    node1b (str+"B") (b_string::path) (b_string::prediction)
                and node1b str path prediction = // Can only receive B. Outputs T or P.
                    let p = rng.NextDouble()
                    if p > 0.5 then node2b (str+"T") (t_string::path) (t_p_string::prediction) else node3b (str+"P") (p_string::path) (t_p_string::prediction)
                and node2b str path prediction = // Can receive T or S. Outputs S or X.
                    let p = rng.NextDouble()
                    if p > 0.5 then node2b (str+"S") (s_string::path) (s_x_string::prediction) else node4b (str+"X") (x_string::path) (s_x_string::prediction)
                and node3b str path prediction = // Can receive P or T. Outputs V or T.
                    let p = rng.NextDouble()
                    if p > 0.5 then node3b (str+"T") (t_string::path) (t_v_string::prediction) else node5b (str+"V") (v_string::path) (t_v_string::prediction)
                and node4b str path prediction = // Can receive X or P. Outputs X or S.
                    let p = rng.NextDouble()
                    if p > 0.5 then node3b (str+"X") (x_string::path) (s_x_string::prediction) else node6b (str+"S") (s_string::path) (s_x_string::prediction)
                and node5b str path prediction = // Can only receive V. Outputs P or V.
                    let p = rng.NextDouble()
                    if p > 0.5 then node4b (str+"P") (p_string::path) (p_v_string::prediction)  else node6b (str+"V") (v_string::path) (p_v_string::prediction) 
                and node6b str path prediction = // Can receive S or V. Outputs E.
                    node7b (str+"E") (e_string::path) (e_string::prediction)
                and node7b str path prediction = // Can only receive E. Outputs P.
                    node8 (str+"P") (p_string::path) (p_string::prediction)
                and node8 str path prediction = // Can receive T or P. Outputs E. Final node.
                    (str+"E"), ((e_string::path) |> List.rev |> List.toArray), ((e_string::prediction) |> List.rev |> List.toArray)
                nodeF str path prediction
            
            let make_reber_set num_examples =
                let mutable c = 0
                let reber_set = new HashSet<(float32 [] * float32 []) []>(HashIdentity.Structural)

                while c < num_examples do
                    let _,inp,lab = make_random_reber_string "" [] []
                    if reber_set.Add (Array.zip inp lab) then c <- c+1
                reber_set |> Seq.toArray

            let ex = 
                group_data_by_seq_length_and_load_to_gpu 512 (make_reber_set 3000)
                |> Array.concat
                |> Array.groupBy (fun x -> x.Length)
                |> dict |> Dictionary

            { data = ex }

        interface IDisposable with
            member t.Dispose() = 
                t.data.Values |> Seq.iter (Seq.iter <| Seq.iter (fun (inp,lab) -> dispose inp; dispose lab))

    type BanditData =
        {
        reward_matrices : d3M[]
        idealized_actions : d2M[]
        }

        // Full batch only for now.
        static member create num_examples num_levers min_reward max_reward () =
            let reward_size = max_reward - min_reward + 1
            let rng = 
                match random_seed_system_random with
                | Some random_seed -> System.Random(random_seed)
                | None -> System.Random()
            let make_random_phase num_levers min_reward max_reward =
                let reward_matrix = 
                    Array.init num_levers (fun x -> rng.Next(min_reward,max_reward+1))
                    |> Array.map (scalar_decoder' min_reward max_reward)
                let ideal_action =
                    reward_matrix
                    |> Array.mapi (fun i x -> i, Array.max x)
                    |> Array.maxBy snd
                    |> fst
                    |> scalar_decoder' 0 (num_levers-1)
                reward_matrix, ideal_action
            
            let reward_matrices, ideal_actions = 
                Array.init num_examples (fun _ -> make_random_phase num_levers min_reward max_reward)
                |> Array.unzip

            {
            reward_matrices = [|d3M.create'((reward_size,num_levers,num_examples),Array.concat (Array.concat reward_matrices))|]
            idealized_actions = [|d2M.createConstant(num_levers,num_examples,Array.concat ideal_actions)|]
            }

        interface IDisposable with
            member t.Dispose()=
                t.reward_matrices |> Array.iter dispose
                t.idealized_actions |> Array.iter dispose

    type private LayerOrSublayer<'input, 'time,'output> =
    | Layer of ('input -> Context<'time> -> 'output)
    | RNNSublayer of ('input -> Context<'time> -> ('output option * 'input -> Context<'time> -> 'output))

    let run_all_tests() =
        let gradientCheckingTests =
            let epsilon = 0.001f
            let boundary = 0.001f
            // Functional programming strikes again. This function can check any kind of layer for correctness.
            let inline checkLayer layer_number (layer: LayerOrSublayer<d2M,unit,d2M>) (data: GradientCheckingData) =
                let input = data.inputd2M
                let target = data.outputd2M
                let inp_tar = [|Some target, input|]
                use ctx = Context<_>.create

                let layer = 
                    match layer with
                    | Layer f -> 
                        fun (_, x) ctx -> f x ctx
                        >=> squared_error_cost' target
                    | RNNSublayer f -> 
                        f input ctx 
                        >=> squared_error_cost' target
                
                // Does not zero out the adjoints with GradChecking
                train layer GradChecking inp_tar ctx false |> ignore

                let getNodes extract_node = 
                    [|for dm in (nodes ctx).[layer_number] do 
                        match extract_node dm with
                        | Some v -> yield v
                        | None -> ()|]
                let true_gradients =
                    let nodes = getNodes (function D2M x -> 
                        if x.HasAdjoint then Some x.GAV else None)
                    [|for x in nodes do yield x.Gather()|]
                let approx_gradients =
                    let nodes = getNodes (function D2M x -> 
                        if x.HasAdjoint then Some x.GPV else None)
                    let grad_check (ar: CudaDeviceVariable<float32>) =
                        [|
                        for i=0 to int ar.Size-1 do
                            let i = SizeT i
                            let orig = ar.[i]
                            let cost() = infer layer GradChecking inp_tar ctx false |> fun (_,x) -> x

                            ar.[i] <- orig + epsilon
                            let cost_plus_epsilon = cost()
                            ar.[i] <- orig - epsilon
                            let cost_minus_epsilon = cost()
                            ar.[i] <- orig // Restore the original
                            let approx_gradient = (cost_plus_epsilon - cost_minus_epsilon) / (2.0f * epsilon)
                            yield approx_gradient
                            |]
                    Array.map grad_check nodes
                let difference_between_true_and_approx_gradients =
                    Array.map2 (Array.map2 (fun x y -> abs <| x-y)) true_gradients approx_gradients
                let max_difference =
                    Array.fold (Array.fold max) Single.NegativeInfinity difference_between_true_and_approx_gradients
//                let max_difference =
//                    Array.fold2 (Array.fold2(fun m x y -> x-y |> abs |> max m)) Single.NegativeInfinity true_gradients approx_gradients
                printfn "difference_between_true_and_approx_gradients=%A" difference_between_true_and_approx_gradients
                printfn "max_difference=%f" max_difference
                max_difference <= boundary |> assertTest "max_difference <= boundary"

            let ``feedforward layer test`` = 
                checkLayer 0 (FFLayer size_gradcheck relu |> Layer)
            let ``standard RNN test`` = 
                checkLayer 0 (createStdRNNSublayer true tanh_ size_gradcheck |> RNNSublayer)
            let ``multiplicative_integration RNN test`` =
                checkLayer 0 (createMI_RNNSublayer tanh_ size_gradcheck |> RNNSublayer)
//            let ``batch normalization test`` = 
//                let main = BNLayer()
//                checkLayer 0 (fun target -> main ^- squaredErrorLayer target)
            [|
            "feedforward layer test", ``feedforward layer test``
            "standard RNN test", ``standard RNN test``
            //"batch normalization test", ``batch normalization test`` // Note: read the warning in batch_normalization_forward before proceeding with this one.
            "multiplicative_integration RNN test", ``multiplicative_integration RNN test``
            |]
       
        let mnistTests =
            let inline layerTest network optimizer num_iters (data: MnistData) =
                let training_set = data.training_set
                let test_set = data.test_set
                let ctx = Context<_>.create
                printfn "Testing the feedforward net with %A..." optimizer
                let rec loop iter =
                    let _,training_cost = train network optimizer training_set ctx false
                    printfn "Done with training."
                    let (test_accuracy, max_accuracy),test_cost = infer network optimizer test_set ctx true
                    printfn "Training cost is %f at iteration %i" training_cost iter
                    printfn "Test accuracy and cost are (%i/%i, %f) at iteration %i" test_accuracy max_accuracy test_cost iter
                    if iter >= num_iters then 
                        test_accuracy >= 9750 |> assertTest "test_accuracy >= 9750"
                    else
                        loop <| iter+1
                loop 1

            let ``n layer feedforward net test`` =
                layerTest 
                    (FFLayer 256 relu >=>
                     FFLayer 256 relu >=>
                     FFLayer 10 clipped_sigmoid ==
                     cross_entropy_cost')
        
            let ``n layer feedforward net test (with BN)`` =
                layerTest
                    (FFLayer' false 256 relu >=> BNLayer 0.01 >=>
                     FFLayer' false 256 relu >=> BNLayer 0.01 >=>
                     FFLayer 10 clipped_sigmoid ==
                     cross_entropy_cost')

            [|
            "n layer feedforward net test", ``n layer feedforward net test`` (Sgd(1.0f)) 20
            "n layer feedforward net test (with BN)", ``n layer feedforward net test (with BN)`` (Sgd(2.0f)) 20
            |]

        let reberTests =
            let ``standard 1 layer RNN test`` num_iters (optimizer: Optimizer) (data: ReberData) =
                let state = Context<_>.create
                let training_set = data.data.[20] // As these two are full batch I need to put them in an array explicitly.
                let test_set = data.data.[30]
                let network = RNN1DLayer 128 tanh_ >=> FFLayer 7 clipped_sigmoid == cross_entropy_cost' |> recurrectSequence
                printfn "Testing the standard 1 layer RNN for %i iterations and optimizer %A..." num_iters optimizer
                let stopwatch = Diagnostics.Stopwatch.StartNew()
                let rec loop iter =
                    let _,training_cost = train network optimizer training_set state false
                    let _, test_cost = infer network optimizer test_set state false
                    printfn "Training cost is %f at iteration %i" training_cost iter
                    printfn "Test cost is %f at iteration %i" test_cost iter
                    let boundary = 0.5f
                    if iter >= num_iters then 
                        printfn "Time elapsed for Reber test is %A" stopwatch.Elapsed
                        test_cost <= boundary |> assertTest (sprintf "test_cost <= boundary(%f/%f)" test_cost boundary)
                    else
                        loop <| iter+1
                loop 1
        
            [|
            "standard 1 layer RNN test", ``standard 1 layer RNN test`` 100 <| ClippedSgd(0.1f, 0.1f)
            |]

        let banditTests =
            let inline bandit_test_run set network ctx (num_iters: int) optimizer =
                let results_ar = ResizeArray(num_iters)

                printfn "Testing the bandit for %i iterations with optimizer %A..." num_iters optimizer
                let stopwatch = Diagnostics.Stopwatch.StartNew()
                let rec loop iter =
                    let _,training_cost = train network optimizer set ctx false
                    printfn "Training cost is %f at iteration %i" training_cost iter
                    results_ar.Add(training_cost)
                    if iter >= num_iters then 
                        printfn "Time elapsed for bandit test is %A" stopwatch.Elapsed
                        Chart.Line(results_ar).ShowChart().Show()
                        assertTest "Ok" true
                    else
                        loop <| iter+1
                loop 1

            // ---
            // Test one has been removed. It was just a plain RNN without recurrent connection that did not converge at any rate.
            // It can be found in the past commits.
            // ---

            // ---

            // Test two used to be here.
            // Test two is equivalent to test 4 with delayed_steps argument set to zero.
            
            // ---

            // There was a a bug in test two of the previous library so I brought in this one.
            // As it turned out the prev timestep got set to the max iteration of the previous run.
            // I like my decision to use state in the sublayers a lot less now. I'll have to be more cautious.

            // Also the style of coding recurrent nets as seen in this test is succeptible for races in userstate.
            // Be warned.
            
            // ---
            // Test 3 has been removed. It can be found in the past commits.
            // ---

            // Now that I've found the bug in the previous test and got their results to match, it still does not explain 
            // why test 2 version performs so much more poorly than the test 3. Sure, they are different but they are also
            // quite similar.

            // My current hypothesis is this - it might just be the case that the rewards in the very early timesteps might be
            // destabilizing the net by causing it to overfocus. It could be that is simply needs some time to ruminate before
            // being graded. So I'll make it so the reward does not get returned until the few steps after the start for this test.

            // ---
            // Test 4 has been folded into test 5.
            // ---

            let inline ``bandit prediction test 5(residual layers in depth & GRU & LSTM in time)`` 
                    reward_layers_inner reward_layers_outer
                    action_layers_inner action_layers_outer
                    delay_reward_for_n_steps (num_iters: int) optimizer (data: BanditData) =
                let rewards_matrices = data.reward_matrices
                let idealized_actions = data.idealized_actions
                let reward_size,num_levers,num_examples = rewards_matrices.[0].rcn

                let reward_layers_inner = reward_layers_inner()
                let reward_layers_outer = reward_layers_outer reward_size
                let action_layers_inner = action_layers_inner()
                let action_layers_outer = action_layers_outer num_levers

                /// Stacks explicit reward ontop of predicted reward and runs the cost on the predicted reward as well.
                let residual_reward_layers_reward_stacker 
                        layer reward_matrices (residual_input,action as ex) ctx = 
                    let explicit_reward = map_indices_3d action reward_matrices ctx
                    let (residual_output, implicit_reward) = layer ex ctx
                    let total_reward = stack_vertical_lazy implicit_reward explicit_reward ctx

                    if timestep (getRNNState ctx) >= delay_reward_for_n_steps then
                        let cost = cross_entropy_cost' explicit_reward implicit_reward ctx
                        (residual_output, Some cost, total_reward)
                    else
                        (residual_output, None, total_reward)
                    

                let residual_reward_layers (residual_input, input) = context {
                    let! output = reward_layers_inner input
                    let! residual_output = ResidualLayer (residual_input,output)
                    let! output = reward_layers_outer residual_output
                    return Some residual_output, output
                    }

                let residual_action_layers (residual_input, input) = context {
                    let! output = action_layers_inner input
                    let! residual_output = ResidualLayer (residual_input,output)
                    let! output = action_layers_outer residual_output
                    return Some residual_output, output
                    }

                let reward_layers_with_costs rewards_matrices input = 
                    residual_reward_layers_reward_stacker residual_reward_layers rewards_matrices input

                let lazy_action_layers input ctx = 
                    lazy residual_action_layers (force input) ctx
                
                let feedback_section rewards_matrices input = context {
                    let! residual_output, cost, output = reward_layers_with_costs rewards_matrices input
                    let! output = lazy_action_layers (lazy (residual_output,force output))
                    return cost, output
                    }

                /// Loops the reward and action layers.
                let recurrect_feedback_section rewards_matrices =
                    feedback_section rewards_matrices
                    |> recurrentFeedback 10 (fun (_,reward) -> force reward)
                    |> wrapChoose (fun (cost,_) -> cost)
                    |> recurrectCostSum

                let network (rewards_matrices, input) =
                    recurrect_feedback_section rewards_matrices (None,input)

                use cc = Context<_>.create
                let d = Array.zip data.reward_matrices data.idealized_actions
                bandit_test_run d network cc num_iters optimizer


            [|
//            "bandit prediction test 5(residual layers in depth & GRU & LSTM in time)", 
//                ``bandit prediction test 5(residual layers in depth & GRU & LSTM in time)``
//                    (fun () -> GRULayer 128 tanh_) (fun reward_size -> GRULayer reward_size clipped_sigmoid)
//                    (fun () -> GRULayer 128 tanh_) (fun num_levers -> GRULayer num_levers clipped_sigmoid)
//                    5 300 (ClippedSgd(0.1f,0.025f))
//            "bandit prediction test 5(residual layers in depth & GRU & LSTM in time)", 
//                ``bandit prediction test 5(residual layers in depth & GRU & LSTM in time)``
//                    (fun () -> LSTMLayer 128 tanh_ tanh_) (fun reward_size -> LSTMLayer reward_size tanh_ clipped_sigmoid)
//                    (fun () -> LSTMLayer 128 tanh_ tanh_) (fun num_levers -> LSTMLayer num_levers tanh_ clipped_sigmoid)
//                    3 300 (ClippedSgd(0.1f,0.025f))
//            "bandit prediction test 5(residual layers in depth & GRU & LSTM in time)", 
//                ``bandit prediction test 5(residual layers in depth & GRU & LSTM in time)``
//                    (fun () -> RNN1DLayer 128 tanh_) (fun reward_size -> RNN1DLayer reward_size clipped_sigmoid)
//                    (fun () -> RNN1DLayer 128 tanh_) (fun num_levers -> RNN1DLayer num_levers clipped_sigmoid)
//                    0 300 (ClippedSgd(0.1f,0.1f))

//            yield! // The performance of MI with zero delayed steps is trully exemplary. 
//                   // And unlike the non-MI nets, the performance is not all over the place
//                   // with different learning rates and delayed steps.
//                Array.init 1 (fun x ->
//                    "bandit prediction test 5(residual layers in depth & GRU & LSTM in time)", 
//                        ``bandit prediction test 5(residual layers in depth & GRU & LSTM in time)``
//                            (fun () -> MI_RNN1DLayer 128 tanh_) (fun reward_size -> MI_RNN1DLayer reward_size clipped_sigmoid)
//                            (fun () -> MI_RNN1DLayer 128 tanh_) (fun num_levers -> MI_RNN1DLayer num_levers clipped_sigmoid)
//                            x 300 (ClippedSgd(0.03f,0.03f)))
//            yield! // The GRU is not bad, although it is much slower than the standard MI RNN.
//                Array.init 5 (fun x ->
//                "bandit prediction test 5(residual layers in depth & GRU & LSTM in time)", 
//                    ``bandit prediction test 5(residual layers in depth & GRU & LSTM in time)``
//                        (fun () -> MI_GRU1DLayer 128 tanh_) (fun reward_size -> MI_GRU1DLayer reward_size clipped_sigmoid)
//                        (fun () -> MI_GRU1DLayer 128 tanh_) (fun num_levers -> MI_GRU1DLayer num_levers clipped_sigmoid)
//                        x 500 (ClippedSgd(0.05f,0.05f))
//                )
            yield! // It seems that the more complex the architecture, the worse it performs. LSTM is quite bad here.
                Array.init 3 (fun x ->
                "bandit prediction test 5(residual layers in depth & GRU & LSTM in time)", 
                    ``bandit prediction test 5(residual layers in depth & GRU & LSTM in time)``
                        (fun () -> MI_LSTM1DLayer 128 tanh_ tanh_) (fun reward_size -> MI_LSTM1DLayer reward_size tanh_ clipped_sigmoid)
                        (fun () -> MI_LSTM1DLayer 128 tanh_ tanh_) (fun num_levers -> MI_LSTM1DLayer num_levers tanh_ clipped_sigmoid)
                        x 300 (ClippedSgd(0.05f,0.025f))
                )
            |]

        
        cuda_context.Synchronize() // Inits the library.
        let tree =
            let mnist_path =
                // If you are anybody other than me, change this to where the Mnist dataset is.
                @"C:\ML Datasets\Mnist" 
            testArray null
                [|
//                testCases "Mnist Tests" (MnistData.create 256 mnist_path) mnistTests
//                testCases "Gradient Checking Tests" GradientCheckingData.create gradientCheckingTests
//                testCases "Reber Grammar RNN Tests" ReberData.create reberTests
                testCases "Multi-armed Bandit Tests" (BanditData.create 128 8 0 9) banditTests
                |]
        run tree
        Application().Run() |> ignore

    [<STAThread>]
    run_all_tests()
