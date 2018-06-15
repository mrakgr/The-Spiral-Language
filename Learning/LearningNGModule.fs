// The experimental module for relative natural gradient related work.
[<AutoOpen>]
module Learning.Experimental.Lib

open Spiral.Types
open Spiral.Lib
open Learning.Cuda

let learning =
    (
    "Learning",[struct';extern_;serializer_one_hot;cuda_aux],"The deep learning module.",
    """
inl float ->
    // #Primitives
    inl to_dev_tensor = CudaAux.to_dev_tensor
    
    inl zero = to float 0
    inl half = to float 0.5
    inl one = to float 1
    inl two = to float 2
    inl infinity =
        match float with
        | _: float32 -> infinityf32
        | _: float64 -> infinityf64

    inl primal = function {primal} | primal -> primal
    inl adjoint = function {adjoint} -> adjoint | _ -> ()

    inl primals = Struct.map primal
    inl adjoints = Struct.map adjoint

    inl on_non_nil ret B =
        match B with
        | () -> ()
        | B -> ret B

    inl dr s primal = {primal adjoint=s.CudaTensor.zero_like primal; block=()}

    inl matmultb l bias s = 
        inl l =
            match l with
            | () -> error_type "The first argument must not be empty."
            | (_,_) :: _ -> l
            | _ :: _ -> l :: ()
        inl C = 
            Tuple.foldl (inl C (A,B) ->
                match C with
                | () -> s.CudaBlas.gemm .nT .nT one (primal A) (primal B) |> dr s
                | C -> s.CudaBlas.gemm' .nT .nT one (primal A) (primal B) one (primal C); C
                ) () l
        match bias with
        | () -> ()
        | _ -> s.CudaKernel.d2_replicate_map' (inl a b _ -> a+b) (primal bias) (primal C) (primal C)
        C, inl _ -> join
            inl C' = adjoint C
            inl l =
                Tuple.iter (inl A, B -> 
                    on_non_nil (inl A -> s.CudaBlas.gemm' .nT .T one C' (primal B) one A) (adjoint A)
                    on_non_nil (inl B -> s.CudaBlas.gemm' .T .nT one (primal A) C' one B) (adjoint B)
                    ) l
            match bias with
            | () -> ()
            | _ -> on_non_nil (inl bias -> s.CudaKernel.mapi_d2_redo_map' {map_in=const;neutral_elem=zero;redo=(+);map_out=(+)} C' bias.empty bias) (adjoint bias)

    inl matmult l s = matmultb l () s

    inl choose_adjoints in bck =
        Struct.choose2 (function
            | {primal adjoint} bck -> {adjoint bck block=()}
            | _ _ -> ()) in bck
        |> inl x -> Struct.map (inl x -> x.adjoint) x, Struct.map (inl x -> x.bck) x
            
    inl map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaKernel.map fwd primal |> dr s

        inl adjoint, bck = choose_adjoints in bck
        out, inl _ -> join
            inl bck (in, out) = Struct.map2 (inl bck -> bck (in, out)) bck
            s.CudaKernel.map' bck (primal, {out without block}) adjoint

    /// Does not return a `dr` unlike the rest. This is an optimization in order to avoid having to call too many useless kernels that 
    /// just to set the adjoint to 1. The current library is intended for a narrow purpose.
    inl map_redo_map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaKernel.map_redo_map fwd primal

        inl adjoint, bck = choose_adjoints in bck
        out, inl _ -> join
            inl out = to_dev_tensor out
            inl bck in = Struct.map2 (inl bck -> bck (in, out.get)) bck
            s.CudaKernel.map' bck primal adjoint

    inl d2_replicate_map {fwd bck={bck_in bck_in'}} in in' s =
        inl primal, adjoint = primals in, adjoints in
        inl primal', adjoint' = primals in', adjoints in'
        inl out = s.CudaKernel.d2_replicate_map fwd primal primal' |> dr s
        out, inl _ -> join
            inl out = {out without block}
            s.CudaKernel.mapi_d2_redo_map' bck_in (primal', out) primal adjoint
            s.CudaKernel.d2_replicate_map' bck_in' primal (primal', out) adjoint'

    inl Primitive =
        {
        matmult map map_redo_map matmultb d2_replicate_map
        } |> stack

    // #Operations
    inl apply_bck = (<<)

    inl (>>=) a b s =
        inl a,a_bck = a s
        inl b,b_bck = b a s
        b, apply_bck a_bck b_bck

    inl succ x _ = x, const ()

    // #Activation
    inl activation d = map {d with bck = Struct.map (inl bck (in, out) adjoint -> adjoint + out.adjoint * (self in out.primal)) self}

    inl sigmoid_fwd x = one / (one + exp -x)
    inl sigmoid_bck out = out * (one - out)

    inl sigmoid = activation {
        fwd = sigmoid_fwd
        bck = inl _ -> sigmoid_bck
        }

    inl tanh_fwd = tanh
    inl tanh_bck out = one - out * out

    inl tanh = activation {
        fwd = tanh_fwd
        bck = inl _ -> tanh_bck
        }

    inl relu_fwd x = if x > zero then x else zero
    inl relu_bck out = if out > zero then one else zero

    inl relu = activation {
        fwd = relu_fwd
        bck = inl _ -> relu_bck
        }

    inl add = activation {
        fwd = inl a,b -> a+b
        bck = (inl _ _ -> one), (inl _ _ -> one)
        }

    inl hadmult = activation {
        fwd = inl a,b -> a*b
        bck = (inl (_,x) _ -> x), (inl (x,_) _ -> x)
        }

    inl d2_replicate_activation {fwd bck_in bck_in'} in =
        inl neutral_elem = Struct.map (const zero) in
        inl bck = {
            bck_in={
                map_in=inl (in', out) in -> Struct.map ((*) out.adjoint) (bck_in in in' out.primal)
                neutral_elem redo=Struct.map2 (+)
                map_out=Struct.map2 (+)
                }
            bck_in'=inl in (in', out) -> Struct.map2 (inl x adjoint -> adjoint + out.adjoint*x) (bck_in' in in' out.primal)
            }
        d2_replicate_map { fwd bck } in

    inl Activation = {activation sigmoid tanh relu add hadmult d2_replicate_activation } |> stack

    // #Optimizer
    inl sgd learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> P - learning_rate * A, zero) primal.empty (primal, adjoint)

    inl clipped_sgd max learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> 
            inl A = if A < -max then -max elif A > max then max else A
            P - learning_rate * A, zero
            ) primal.empty (primal, adjoint)

    inl Optimizer = {sgd clipped_sgd}

    // #Accuracy
    inl accuracy label input s =
        inl input, label = primal input, primal label
        inl max = input .span_outer
        inl value =
            s.CudaKernel.mapi_d1_redo_map {
                map_in=const
                neutral_elem=-infinity,zero
                redo=inl a b -> if fst a > fst b then a else b
                map_out=snd >> to int64
                } (input,label) ()
            |> s.CudaKernel.map_redo_map {
                neutral_elem=0; redo=(+)
                }
        {value max}

    // #Auxiliary
    inl atomic_add o x =
        inl (),{ar offset} = o.dim, o.bodies
        inl adr = macro.cd ar [arg: ar; text: " + "; arg: offset]
        macro.cd () [text: "atomicAdd"; args: adr, x]

    /// The softmax activation
    inl softmax temp input s =
        s.CudaKernel.mapi_d1_seq_broadcast {
            map_in=inl x -> x / temp
            seq = 
                {
                redo=max
                map_out=inl a b -> exp (a - b)
                }
                ,
                {
                redo=(+)
                map_out=(/)
                }
            } input
                
    inl encode =
        {
        /// The one hot encode function. Does not check that the inputs are in range.
        one_hot = inl size tns s ->
            inl f = 
                inl rec f tns = function
                    | _ :: x' -> inl x -> f (tns x) x'
                    | () -> inl x -> if x = to int64 tns.get then one else zero
                f (to_dev_tensor tns) (type tns.dim)
            s.CudaKernel.init {rev_thread_limit=32; dim=Tuple.append tns.dim (size :: ())} f
        } |> stackify

    inl sample_body prob s =
        inl boundary = s.CudaRandom.create {dst=.Uniform} {elem_type=float; dim=fst prob.dim}
        s.CudaKernel.mapi_d1_inscan_mapi_d1_reduce_mapi {
            scan={
                ne=0f32
                f=(+)
                }
            mapi_mid=inl _ index prob boundary -> 
                inl x = prob - boundary
                (if x < 0f32 then infinity else x), index
            redo={
                ne=infinity,0
                f=inl a b -> if fst a <= fst b then a else b
                }
            map_out=snd
            } prob boundary

    /// Aplies a softmax to the inputs and then samples from them randomly. Returns the resulting indices in a 1d tensor.
    inl sample temp x s =
        inl prob = softmax temp (primal x) s
        sample_body prob s

    inl Auxiliary = {encode sample} |> stackify

    //#Error
    inl error {fwd bck} label input s = 
        inl batch_size = primal input .span_outer |> to float
        inl div_by_minibatch_size x = x / batch_size
        map_redo_map {
            fwd = {
                map_in = fwd
                redo = (+)
                neutral_elem = zero
                map_out = div_by_minibatch_size
                }
            /// The adjoint in error is always assumed to be one.
            bck = Struct.map (inl bck (in, out) adjoint -> adjoint + div_by_minibatch_size (bck in out)) bck
            } (input, label) s

    inl square_bck (x,y) = two * (x - y)
    inl sqaure_bck' (x,y) = -(two * (x - y))

    inl square = error {
        fwd = inl (x,y) -> (y - x) * (y - x)
        bck =
            inl x _ -> square_bck x
            ,inl x _ -> sqaure_bck' x
        }

    inl sigmoid_cross_entropy = error {
        fwd = inl x,y -> 
            inl x = sigmoid_fwd x
            -(y * log x + (one - y) * log (one - x))
        bck = 
            inl (x, y) _ -> 
                inl x = sigmoid_fwd x
                x - y
            ,inl (x, y) _ -> 
                inl x = sigmoid_fwd x
                log (one - x) - log x
        }

    /// Applies a softmax and then calculates the cross entropy cost. Is intended to take a linear layer as input.
    inl softmax_cross_entropy label input s =
        assert ((primal label).dim = (primal input).dim) "Labels and inputs must have equal dimensions."
        
        inl batch_size = primal input .span_outer |> to float

        inl temp = one

        inl cost = 
            inl cost = s.CudaTensor.create {elem_type=float; dim=primal input .dim |> fst}
            inl _ =
                inl input, label, cost = Tuple.map (primal >> to_dev_tensor) (input, label, cost)
                s.CudaKernel.iteri_d1_seq_broadcast {
                    mapi_in=inl j i -> input j i .get / temp
                    seq = 
                        {
                        redo=max
                        mapi_out=inl _ _ a b -> exp (a - b)
                        }
                        ,
                        {
                        redo=(+)
                        mapi_out=inl j i x sum_x ->
                            inl p = x / sum_x
                            inl label = label j i .get
                            -label * log p
                        }
                        ,
                        {
                        redo'=(+)
                        mapi_out=inl j i _ c -> if threadIdx.x = 0 then cost j .set (c / batch_size)
                        }
                    } (primal input).dim
            s.CudaKernel.map_redo_map {
                redo = (+)
                neutral_elem = zero
                } cost

        inl bck _ = join
            match Tuple.map (adjoint >> on_non_nil to_dev_tensor) (input, label) with
            | (), () -> ()
            | input', label' ->
                inl input, label = Tuple.map (primal >> to_dev_tensor) (input, label)
                s.CudaKernel.iteri_d1_seq_broadcast {
                    mapi_in=inl j i -> input j i .get / temp
                    seq = 
                        {
                        redo=max
                        mapi_out=inl _ _ a b -> exp (a - b)
                        }
                        ,
                        {
                        redo=(+)
                        mapi_out=inl j i x sum_x ->
                            inl get x = x j i .get
                            inl set x = x j i .set
                            inl ret f = on_non_nil (inl x -> set x (get x + f () / batch_size))

                            inl p = x / sum_x
                            inl label = get label
                            ret (inl _ -> (p - label) / temp) input'
                            ret (inl _ -> -(log p)) label'
                        }
                    } input.dim

        cost, bck

    inl Error = {square sigmoid_cross_entropy softmax_cross_entropy} |> stackify

    // #Initializer
    inl Initializer = 
        inl init mult dim s = 
            inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 dim))
            s.CudaRandom.create {dst=.Normal; stddev mean=0.0f32} {dim elem_type=type zero}
        { 
        // Note: The following inits are not intended to be optimal, but work well either way with LN.
        // Even with LN extremely poor inits can undermine the integrity of the network, but these should work interchangeably.
        sigmoid = init 2f32
        tanh = init 3f32
        relu = init 1f32
        bad = init 0.01f32
        } |> stackify

    // #Combinators
    inl layer_map_fold f network s =
        inl rec layer_map_fold r x s =
            match x with
            | {layer_type gid} ->
                match r with
                | {$gid=x} -> (x, s), r
                | _ ->
                    inl (sublayer, s), r =
                        match x with
                        | {sublayer} -> layer_map_fold r sublayer s
                        | _ -> ((), s), r
                    inl x, s = f {x with sublayer} s
                    (x, s), {r with $gid=x}
            | x :: x' -> 
                inl (x, s), r = layer_map_fold r x s
                inl (x', s), r = layer_map_fold r x' s
                (x :: x', s), r
            | () -> ((), s), r
            | {} ->
                module_foldl (inl k ((m,s),r) x ->
                    inl (x, s), r = layer_map_fold r x s
                    (module_add k x m, s), r
                    ) (({},s),r) x
            | _ -> error_type ("Expected a layer. Got", x)
            
        layer_map_fold {} network s |> fst

    inl layer_map f network =
        inl rec layer_map r = function
            | {x with layer_type gid} ->
                match r with
                | {$gid=x} -> x, r
                | _ ->
                    inl sublayer, r =
                        match x with
                        | {sublayer} -> layer_map r sublayer
                        | _ -> (), r
                    inl x = f {x with sublayer}
                    x, {r with $gid=x}
            | x :: x' -> 
                inl x, r = layer_map r x
                inl x', r = layer_map r x'
                x :: x', r
            | () -> (), r
            | {} as x ->
                module_foldl (inl k (m,r) x ->
                    inl x,r = layer_map r x
                    module_add k x m, r
                    ) ({},r) x
            | x -> error_type ("Expected a layer. Got", x)
        layer_map {} network |> fst

    inl init s network = 
        layer_map (function
            | {x with weights} -> {x with weights = const (weights s)}
            | x -> x
            ) network

    inl optimize network optimizer s =
        inl body weights s = weights () |> Struct.iter (optimizer s)
        layer_map (function
            | {weights stream} -> s .data_add {stream} |> body weights
            | {weights} -> body weights s
            | _ -> ()
            ) network 

    inl run x d s =
        layer_map_fold (inl {x with layer_type gid} d ->
            inl ret' t a, b = stack (a, term_cast b t)
            inl ret = ret' ()
            match layer_type with
            | .input -> d.input x.name, d
            | .stateless ->
                inl value, bck = indiv join x.apply x.sublayer s |> ret
                value, {d with bck = apply_bck self bck}
            | .non_differentiable ->
                inl value = indiv join x.apply x.sublayer s |> stack
                value, d
            | .parallel -> x.sublayer, d
            | .feedforward ->
                inl value, bck = indiv join x.apply (x.weights()) x.sublayer s |> ret
                value, {d with bck = apply_bck self bck}
            | .action_ff ->
                inl value, bck = indiv join x.apply x.sublayer s |> ret' float64
                value, {d with bck = apply_bck self bck}
            | .recurrent ->
                inl state = match d.state with {$gid=state} -> state | _ -> ()
                inl (value, state), bck = indiv join x.apply (x.weights()) state x.sublayer s |> ret
                value, {d with bck = apply_bck self bck; state = {self with $gid=state}}
            | .action_rnn ->
                inl state = match d.state with {$gid=state} -> state | _ -> ()
                inl (value, state), bck = indiv join x.apply state x.sublayer s |> ret' float64
                value, {d with bck = apply_bck self bck; state = {self with $gid=state}}
            ) x d
        |> function
            | {value assoc}, d -> value, {d with state=module_foldl (inl k m x -> module_add k x m) self assoc}
            | x -> x

    inl Combinator = 
        {
        layer_map_fold layer_map init init_parallel optimize run run_parallel
        } |> stackify

    // #Loops
    inl outer data =
        Struct.foldl (inl s x ->
            match s with
            | () -> fst x.dim
            | s -> assert (s = fst x.dim) "The data tensors need to have the same outer dimension."; s
            ) () data

    inl for {data body} s =
        inl {from near_to} = outer data
           
        Loops.for' {
            from near_to
            state=body
            body=inl {next state i} ->
                inl data = Struct.map (inl x -> x i) data
                s.refresh
                inl s = s.RegionMem.create
                state data s {
                    on_fail=inl state ->
                        s.RegionMem.clear
                        state.unwrap
                    on_succ=inl state ->
                        s.RegionMem.clear
                        next state
                    }
            finally=inl state -> state.unwrap
            }

    // #Layers
    inl gid _ = .(to string !GID())
    inl layer d = {d with gid=gid(); block=()}
    
    inl input name size = layer {
        layer_type = .input
        name
        size
        }

    inl stateful layer_type {weights apply size sublayer} = 
        layer {
            layer_type
            size
            sublayer
            weights
            apply
            }

    inl feedforward = stateful .feedforward
    inl recurrent = stateful .recurrent

    inl aux layer_type {apply sublayer size} =
        layer {
            layer_type
            size
            sublayer
            apply
            }

    inl stateless = aux .stateless
    inl non_differentiable = aux .non_differentiable

    inl parallel sublayer = 
        layer {
            layer_type = .parallel
            size = Struct.map (inl x -> x.size) sublayer
            sublayer
            }

    inl error cost label input =
        stateless
            {
            sublayer = input, label
            apply = inl input, label -> cost label input
            size = 1
            }

    inl accuracy label input =
        non_differentiable
            {
            sublayer = input, label
            apply = inl input, label -> accuracy label input
            size = 1
            }

    inl encode =
        {
        one_hot = inl size sublayer ->
            non_differentiable
                {
                sublayer
                apply = encode.one_hot size
                size
                }
        }

    inl sampling temp sublayer =
        non_differentiable
            {
            sublayer
            apply = sample temp
            size = 1
            }

    inl Layer = {layer input stateless non_differentiable feedforward recurrent parallel error accuracy encode sampling} |> module_map (const stack)

    // #Feedforward
    inl layer initializer activation {size lr} sublayer =
        feedforward
            {
            size sublayer
            weights = inl s -> 
                {
                input = initializer (sublayer.size, size) s |> dr s
                bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                } |> heap
            apply = inl weights input -> matmultb (input, weights.input) weights.bias >>= activation
            }

    inl sigmoid = layer Initializer.sigmoid sigmoid
    inl relu = layer Initializer.relu relu
    inl tanh = layer Initializer.tanh tanh
    inl linear = layer Initializer.sigmoid succ

    inl bias init = 
        inl x = s.CudaTensor.create {elem_type=float; dim=size} 
        join s.CudaTensor.mmap (const init) x
        dr s x

    inl rng {size lr v_num} sublayer =
        feedforward
            {
            size sublayer
            weights = inl s -> 
                inl initializer = Initializer.sigmoid
                inl bias init = 
                    inl x = s.CudaTensor.create {elem_type=float; dim=size} 
                    join s.CudaTensor.mmap (const init) x
                    x

                {
                input = initializer (sublayer.size, size) s |> dr s
                bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                o = bias one
                v = initializer (size, v_num, sublayer.size) s
                } |> heap
            apply = inl weights input -> matmultb (input, weights.input) weights.bias >>= sigmoid
            optimizer = inl weights s x z ->
                inl o = weights.o
                inl v = weights.v
                inl batch_num, z_num = z.dim
                inl _, v_num, x_num = v.dim

                // c1 = - size * log (sqr o)
                inl c1 =
                    s.CudaKernel.map (inl o -> 
                        inl o2 = o*o
                        -(to float size) / o2 * two * o 
                        ) o

                // c2 = - (log << det) (I + 1 / o^2 * V^T V)
                inl c2 =
                    // V^T V
                    inl vtv = s.CudaBlas.gemm_strided_batched .T .nT 1f32 v v
                    // I + 1 / o^2 * V^T V
                    inl i_oo_vtv = 
                        inl o,vtv = Tuple.map CudaAux.to_dev_tensor (o,vtv)
                        s.CudaKernel.init {dim=vtv.dim} (
                            inl i ->
                                inl o = o i .get
                                inl vtv = vtv i
                                inl j k ->
                                    inl I = if j = k then one else zero
                                    I + 1 / (o*o) * vtv j k .get
                            )

                    // (I + 1 / o^2 * V^T V)^-1
                    // Is the error when at the top which is the case here.
                    inl i_oo_vtv_inv = s.CudaBlas.matinv_batched_asserted i_oo_vtv
                    
                    // d -(log << det) (I + 1 / o^2 * V^T V) / d o
                    inl o_bck = 
                        // d o^-2 * vtv / d o = -2 * o^-3 * vtv
                        inl o_bck_inner = 
                            inl o,vtv = Tuple.map CudaAux.to_dev_tensor (o,vtv)
                            s.CudaKernel.init {dim=vtv.dim} (
                                inl i ->
                                    inl o = o i .get
                                    inl vtv = vtv i

                                    // Note that left should be -two / (o*o*o)
                                    // The result is rescaled by the negative sign at the top.
                                    inl left = two / (o*o*o)
                                    inl j k -> left * vtv j k .get
                                )

                        s.CudaBlas.gemm_strided_batched .nT T one i_oo_vtv_inv o_bck_inner
                        |> inl x -> x.reshape (inl a,b,c -> a,b*c)
                        |> s.CudaKernel.mapi_d1_redo_map {neutral_elem=zero; redo=(+)}

                    // d -(log << det) (I + 1 / o^2 * V^T V) / d V
                    inl v_bck =
                        inl rescaled_i_oo_vtv_inv = 
                            inl o,i_oo_vtv_inv = Tuple.map CudaAux.to_dev_tensor (o,i_oo_vtv_inv)
                            s.CudaKernel.init {dim=i_oo_vtv_inv.dim} (
                                inl i ->
                                    inl o = o i .get
                                    inl i_oo_vtv_inv = i_oo_vtv_inv i

                                    inl j k -> 
                                        // The rescaling by the derivative should be
                                        // one / (o*o) * i_oo_vtv_inv j k .get
                                        // The rescaling by the negative sign at the top and the adjustment 
                                        // for the following matrix multiplication times the derivative is added to the formula.
                                        -two / (o*o) * i_oo_vtv_inv j k .get
                                )
                            
                        /// TODO: Reverse all the transposes when done. Spiral does it in row major order.
                        s.CudaBlas.gemm_strided_batched .nT T one rescaled_i_oo_vtv_inv v

                    o_bck, v_bck
                
                // o^2 * reduce_mean (z * dot x x)
                inl c3 = 
                    s.CudaKernel.mapi_d1_redo_map {
                        map_in=inl x -> x*x
                        neutral_elem=zero; redo=(+)
                        } x
                    |> inl x ->
                        inl x,o = Tuple.map CudaAux.to_dev_tensor (x,o)
                        s.CudaKernel.mapi_d2_redo_map {
                            mapi_in=inl i -> // TODO: The order of dimensions is probably wrong here.
                                inl x = x i .get
                                inl _ z -> x * z
                            neutral_elem=zero; redo=(+)
                            mapi_out=inl i ->
                                inl o = o i .get * two
                                inl _ r -> o * r
                            } z

                // sum {from=1; near_to=S.dim_outer} (inl i -> reduce_mean (z * sqr (dot (v i) x)))
                //```
                //z = batch_num x z_num
                //v = z_num x v_num x x_num
                //x = batch_num x x_num
                //```
                //The double sum can be simplified into a series of matrix multiplications. The imporant thing is to keep track of dimensions.
                //```
                //xv = batch_num x z_num x v_num
                //```
                //The first operation is `x * transpose v`. Since `v` is 3d, the first two dimensions of it are flattened
                //before being passed into the gemm kernel.
                //```
                //z_rep = batch_num x z_num x v_num
                //```
                //Since each `z` element touches each of the `xv`s, it is replicated `v_num` times so the dimensions match up.
                //In actual code, rather than do that the init kernel is used instead to do that implicitly.
                //`z_rep` is then used in an Hadamard multiplication with `xv`.
                //```
                //zxv = batch_num x z_num x v_num
                //```
                //The derivative of the fourth term requires a multiplication by another x.
                //```
                //zxv_rep = batch_num x z_num x v_num x x_num
                //```
                //In the code, the replication is done implicitly inside the kernel.
                //```
                //zxvx = batch_num x z_num x v_num x x_num
                //```
                //The finally to get the derivative with respect to v, the batch dimension needs to be reduced.
                //```
                //zxvx' = z_num x v_num x x_num
                //```
                inl c4 =
                    // d (sqr (x v)) / d v = two * dot (S s) x * x
                    inl xv =
                        inl v = v.reshape (inl z_num,v_num,x_num -> z_num * v_num, x_num)
                        s.CudaBlas.gemm .nT T one x v
                            .reshape (inl batch_num, zv_num -> batch_num, v_num, zv_num / v_num)
                    // d (sqr (x v)) / d v = two * dot (S s) x * x
                    inl zxv = 
                        inl z,xv = Tuple.map CudaAux.to_dev_tensor (z,xv)
                        s.CudaKernel.init {dim=batch_num,z_num,v_num} (inl b ->
                            inl z = z b
                            inl xv = xv b
                            inl z' ->
                                inl z = z z' .get
                                inl xv = xv z'
                                inl v' ->
                                    inl xv = xv v' .get
                                    /// The rescaling for the mean of the batch size and derivative of sqr is done here.
                                    two / to float batch_num * z * xv 
                            )
                    inl zxvx =
                        inl zxv, x = Tuple.map CudaAux.to_dev_tensor (zxv,x)
                        s.CudaKernel.init {dim=batch_num, z_num, v_num, x_num} (
                            inl b ->
                                inl zxv = zxv b
                                inl x = x b
                                inl z ->
                                    inl zxv = zxv z
                                    inl v ->
                                        inl zxv = zxv v .get
                                        inl x' ->
                                            inl x = x x' .get
                                            zxv * x
                            )
                        |> s.CudaKernel.mapi_d2_redo_map {neutral_elem=zero; redo=(+)}
                    zxvx


                // - size * log (sqr o) - (log << det) (I + 1 / o * dot V V) + o^2 * reduce_mean (z * dot x x) +
                // sum {from=1; near_to=S.dim_outer} (inl s -> reduce_mean (z * sqr (dot (S s) x))) + C1
                ()
            }

    inl Pass =
        inl train {d with network} =
            inl rec loop c cost' = 
                function
                | .unwrap -> cost' / to float64 c
                | input s {on_fail on_succ} ->
                    inl cost, {bck} = run network {input state = {}; bck=const ()} s
                    inl cost' = cost' + to float64 (s.CudaTensor.get cost)
                    inl state = loop (c+1) cost'
                    if nan_is cost' then on_fail state
                    else
                        match d with
                        | {optimizer} ->
                            bck()
                            optimize network optimizer s
                        | _ -> ()
                        on_succ state
            loop (dyn 0) (dyn 0.0)

        inl test {d with network} =
            inl rec loop c cost' accuracy' accuracy_max' = 
                function
                | .unwrap -> cost' / to float64 c, accuracy', accuracy_max'
                | input s {on_fail on_succ} ->
                    inl (cost, {value max}), {bck} = run network {input state = {}; bck=const ()} s
                    inl cost' = cost' + to float64 (s.CudaTensor.get cost)
                    inl accuracy' = accuracy' + s.CudaTensor.get value
                    inl accuracy_max' = accuracy_max' + max
                    inl state = loop (c+1) cost' accuracy' accuracy_max'
                    if nan_is cost' then on_fail state
                    else
                        match d with
                        | {optimizer} ->
                            bck()
                            optimize network optimizer s
                        | _ -> ()
                        on_succ state
            loop (dyn 0) (dyn 0.0) (dyn 0) (dyn 0)

        inl Body = 
            {
            train test
            }
       
        {for Body} |> stackify

    inl Feedforward = 
        {
        Layer={Layer with init layer sigmoid tanh relu linear } |> stackify
        Pass
        } |> stack
    
    { 
    dr primal primals adjoint adjoints (>>=) succ Primitive Activation Optimizer Initializer Error Layer Combinator Feedforward
    }
    """) |> module_
