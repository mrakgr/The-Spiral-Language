[<AutoOpen>]
module Learning.Main.Lib

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

    inl fwd_add_bias C bias s = s.CudaKernel.d2_replicate_map' (inl a _ b -> a+b) bias C.empty C
    inl bck_add_bias C bias s = s.CudaKernel.mapi_d2_redo_map' {map_in=const;neutral_elem=zero;redo=(+);map_out=(+)} C bias.empty bias

    inl matmultb l bias s = 
        inl l =
            match l with
            | () -> error_type "The first argument must not be empty."
            | (_,_) :: _ -> l
            | _ :: _ -> l :: ()
        inl f = function {T} -> T, .T | nT -> nT, .nT
        inl f' = function {T} -> T, .nT | nT -> nT, .T
        inl C = 
            Tuple.foldl (inl C (A,B) ->
                inl (A,TA),(B,TB) = f A, f B
                match C with
                | () -> s.CudaBlas.gemm TA TB one (primal A) (primal B) |> dr s
                | C -> s.CudaBlas.gemm' TA TB one (primal A) (primal B) one (primal C); C
                ) () l
        match bias with
        | () -> ()
        | _ -> fwd_add_bias (primal C) (primal bias) s
        C, inl _ -> join
            inl C' = adjoint C
            inl l =
                Tuple.iter (inl A, B -> 
                    inl (A,TA),(B,TB) = f' A, f' B
                    on_non_nil (inl A -> s.CudaBlas.gemm' .nT TB one C' (primal B) one A) (adjoint A)
                    on_non_nil (inl B -> s.CudaBlas.gemm' TA .nT one (primal A) C' one B) (adjoint B)
                    ) l
            on_non_nil (inl bias -> bck_add_bias C' bias s) (adjoint bias)

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

    inl layer_norm =
        inl fwd o i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast {
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n)
                    }
                } (primal i)

        inl bck o r i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast' {
                seq = 
                    {
                    map_in=inl dr,i -> i
                    redo=(+)
                    map_out=inl dr,i sum -> dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl dr,v -> v*v
                    redo=(+)
                    map_out=inl dr,v vv -> dr,v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        top + bot
                    }
                    ,
                    {
                    redo=(+)
                    map_out=inl dv dv_sum adjoint -> adjoint + dv - dv_sum / n
                    }
                } (adjoint r, primal i) (adjoint i)

        inl o i s ->
            inl r = fwd o i s |> dr s
            r, inl _ -> bck o r i s

    /// Layer normalization fused with the relu activation.
    inl layer_norm_relu =
        inl fwd o i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast {
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n) |> relu_fwd
                    }
                } (primal i)

        inl bck o r i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast' {
                seq = 
                    {
                    map_in=inl dr,i -> i
                    redo=(+)
                    map_out=inl dr,i sum -> dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl dr,v -> v*v
                    redo=(+)
                    map_out=inl dr,v vv -> (if v > zero then dr else zero),v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        top + bot
                    }
                    ,
                    {
                    redo=(+)
                    map_out=inl dv dv_sum adjoint -> adjoint + dv - dv_sum / n
                    }
                } (adjoint r, primal i) (adjoint i)

        stack inl o i s ->
            inl r = fwd o i s |> dr s
            r, inl _ -> bck o r i s

    inl linear = succ
    inl Activation = {activation linear sigmoid tanh relu add hadmult d2_replicate_activation layer_norm layer_norm_relu} |> stack

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
                s.CudaKernel.init_d1_seq_broadcast {
                    init=inl j i -> input j i .get / temp
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
                s.CudaKernel.init_d1_seq_broadcast {
                    init=inl j i -> input j i .get / temp
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

    /// The Hubert quantile regression functions.
    inl HQR =
        inl L k u = 
            inl abs_u = abs u
            if abs_u <= k then u * u / two
            else k * (abs_u - k / two)

        inl fwd k q (a,b) = 
            inl u = b - a
            inl d = q - if u < zero then one else zero
            if k = zero then u * d
            else L k u * abs d

        inl L' k u =
            inl abs_u = abs u
            if abs_u <= k then u
            else 
                inl abs_u' = if u >= zero then one else -one
                k * abs_u'

        inl bck_b k q (a,b) =
            inl u = b - a
            inl d = q - if u < zero then one else zero
            if k = zero then d
            else L' k u * abs d

        inl bck_a k q (a,b) = -(bck_b k q (a,b))

        {fwd bck_a bck_b}

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

    inl init_parallel s network = 
        layer_map (function
            | {stream} | {layer_type=.input | .parallel} as x -> x
            | {x with weights} -> {x with weights = const (weights s); stream=s.RegionStream.allocate.data.stream}
            | x -> {x with stream=s.RegionStream.allocate.data.stream}
            ) network

    inl optimize network optimizer s =
        inl body weights s = weights () |> Struct.iter (optimizer s)
        layer_map (function
            | {weights stream optimize} -> optimize optimizer (weights ()) (s .data_add {stream})
            | {weights optimize} -> optimize optimizer (weights ()) s
            | {weights stream} -> body weights (s .data_add {stream})
            | {weights} as x -> body weights s
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

    /// The wavefront iteration optimization.
    /// Requires the non-input layers to have preallocated streams.
    inl run_parallel x d s =
        layer_map_fold (inl {x with layer_type gid} d ->
            match layer_type with
            | .input -> {value=d.input x.name; stream=s.data.stream; block=()}, d
            | .parallel -> x.sublayer, d
            | _ ->
                inl stream = x.stream
                inl s = s.data_add {stream}
                inl values = Struct.map (inl {value} -> value) x.sublayer
                inl streams = 
                    Struct.choose (function
                        | {stream=x} -> stream.wait_on x; x
                        | _ -> ()) x.sublayer

                inl wait_bck b x = b x; Struct.iter (inl x -> x.wait_on stream) streams
                inl ret' t a, b = stack (a, term_cast (wait_bck b) t)
                inl ret = ret' ()

                match layer_type with
                | .stateless ->
                    inl value, bck = indiv join x.apply values s |> ret
                    {value stream block=()}, {d with bck = apply_bck self bck}
                | .non_differentiable ->
                    inl value = indiv join x.apply values s |> stack
                    {value stream block=()}, d
                | .feedforward ->
                    inl value, bck = indiv join x.apply (x.weights()) values s |> ret
                    {value stream block=()}, {d with bck = apply_bck self bck}
                | .recurrent ->
                    inl state = match d.state with {$gid=state} -> state | _ -> ()
                    inl (value, state), bck = indiv join x.apply (x.weights()) state values s |> ret
                    {value stream block=()}, {d with bck = apply_bck self bck; state = {self with $gid=state}}
                ) x d
        |> inl x, d -> Struct.map (inl {value} -> value) x, d

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

    inl grad_check train {network} = 
        function
        | .unwrap -> 0.0
        | data s {on_fail on_succ} ->
            inl rec perturb cost primal adjoint =
                inl epsilon = to float 0.001
                inl boundary = to float 0.001

                assert (primal.dim = adjoint.dim) "Dimensions must be equal."
                match primal.dim with
                | {from near_to} :: _ ->
                    Loops.for {from near_to body=inl {i} ->
                        perturb cost (primal i) (adjoint i)
                        }
                | _ -> 
                    inl orig = s.CudaTensor.get primal
                    s.CudaTensor.set primal (orig + epsilon)
                    inl cost_plus_epsilon = cost ()
                    s.CudaTensor.set primal(orig - epsilon)
                    inl cost_minus_epsilon = cost ()
                    s.CudaTensor.set primal orig
                    inl approx_gradient = to float (cost_plus_epsilon - cost_minus_epsilon) / (two * epsilon)

                    inl true_gradient = s.CudaTensor.get adjoint
                
                    inl diff = abs (true_gradient - approx_gradient)
                    if diff >= boundary then
                        Console.writeline {true_gradient approx_gradient diff}
                        Console.writeline "--- Gradient checking failure."

            train {network optimizer=inl _ _ -> ()} data s {
                on_fail
                on_succ=inl state ->
                    s.RegionMem.clear
                    inl body = train {network}
                    inl data = Struct.map (inl x -> x.round_split 1) data

                    layer_map (function
                        | {weights stream} -> error_type "Gradient checking is not supported with the wave iteration."
                        | {weights} -> 
                            weights ()
                            |> Struct.iter (inl {primal adjoint} ->
                                inl cost _ = for {data body} s
                                perturb cost primal adjoint
                                )
                        | _ -> ()
                        ) network |> ignore
                    on_succ state
                }

    // #Layers
    inl gid _ = .(to string !GID())
    inl layer d = {d with gid=gid(); block=()}
    
    inl input name size = layer {
        layer_type = .input
        name
        size
        }

    inl stateful layer_type {d with weights apply size sublayer} = layer {d with layer_type}

    inl feedforward = stateful .feedforward
    inl recurrent = stateful .recurrent

    inl aux layer_type {d with apply sublayer size} = layer {d with layer_type}

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

    inl sample temp sublayer =
        non_differentiable
            {
            sublayer
            apply = sample temp
            size = 1
            }

    inl Layer = {layer input stateless non_differentiable feedforward recurrent parallel error accuracy encode sample} |> module_map (const stack)

    // #Feedforward
    inl layer initializer activation size sublayer =
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

    // The feedforward layer with layer norm.
    inl ln o size sublayer =
        feedforward
            {
            size sublayer
            weights = inl s -> 
                {
                input = Initializer.relu (sublayer.size, size) s |> dr s
                bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                } |> heap
            apply = inl weights input -> 
                matmultb (input, weights.input) weights.bias 
                >>= layer_norm_relu o 
            }

    inl update_covariance {alpha beta} s C x =
        inl dim = fst x.dim
        Loops.for {dim with body=inl {i} ->
            inl x = x i .reshape (inl x -> 1, x)
            s.CudaBlas.gemm' .T .nT beta x x alpha C
            }

    inl regularize_covariance s back_covariance =
        inl back_covariance = CudaAux.to_dev_tensor back_covariance
        inl epsilon = 0.00001f32
        s.CudaKernel.init {dim=back_covariance.dim} (inl a b ->
            if a = b then back_covariance a b .get + epsilon else back_covariance a b .get
            )

    inl sherman_morrison_symm {d with alpha beta} s A uA u =
        assert (u.span_outer = 1) "u must be a vector."
        inb uAu = s.CudaBlas.gemm .nT .T one uA u |> CudaAux.temporary
        inb constant = s.CudaKernel.map (inl uAu -> -beta / alpha / (alpha + beta * uAu)) uAu 0 0 |> CudaAux.temporary
        s.CudaBlas.gemm' .T .nT (s.CudaTensor.get constant) uA uA (one / alpha) A
        match d with
        | {clip} -> s.CudaKernel.map' (inl A _ -> if A < -clip then -clip elif A > clip then clip else A) A A
        | _ -> ()

    inl whiten lr {d with input bias} x s =
        inl z = s.CudaBlas.gemm .nT .nT one (primal x) (primal input) |> dr s
        fwd_add_bias (primal z) (primal bias) s
        z, inl _ -> join
            inl update beta = 
                inl alpha = one - beta
                sherman_morrison_symm {alpha beta}

            inl add_noise stddev s x =
                inb r = s.CudaRandom.create {dst=.Normal; stddev mean=0f32} {dim=x.dim; elem_type=float} |> CudaAux.temporary
                s.CudaBlas.geam .nT .nT one x one r

            inb z_precise_adjoint = 
                match d with
                | {back_precision} ret -> 
                    inb adjoint_z = add_noise 0.1f32 s (adjoint z) |> CudaAux.temporary
                    inb z_precise_adjoint = s.CudaBlas.gemm .nT .T one adjoint_z back_precision |> CudaAux.temporary
                    ret z_precise_adjoint
                    update lr.back s back_precision z_precise_adjoint adjoint_z
                | _ ret -> ret <| adjoint z
            on_non_nil (s.CudaBlas.gemm' .nT .T one z_precise_adjoint (primal input) one) (adjoint x)
            bck_add_bias z_precise_adjoint (adjoint bias) s 
            
            inb x_precise_primal = 
                match d with
                | {front_precision} ret -> 
                    inb primal_x = add_noise 0.1f32 s (primal x) |> CudaAux.temporary
                    inb x_precise_primal = s.CudaBlas.gemm .nT .T one primal_x front_precision |> CudaAux.temporary
                    ret x_precise_primal
                    update lr.front s front_precision x_precise_primal primal_x
                | _ ret -> ret <| primal x

            s.CudaBlas.gemm' .T .nT one x_precise_primal z_precise_adjoint one (adjoint input)
            

            //Console.writeline "-----"
            //Console.writeline "Back covariance:"
            //s.CudaTensor.print back_covariance
            //inl back_covariance = back_covariance.reshape (inl x -> 1 :: x)
            //s.CudaBlas.matinv_batched back_covariance (inl Ainv, info ->
            //    inl r = s.CudaKernel.map_redo_map {redo=max; neutral_elem=0i32} info |> s.CudaTensor.get
            //    if r = 0i32 then
            //        Console.writeline "The matrix inversion failed."
            //    else
            //        Console.writeline "Inverted back covariance:"
            //        s.CudaTensor.print Ainv
            //    )
            //Console.writeline "Inverted (online) back covariance:"
            //s.CudaTensor.print back_whiten
            ()

    inl prong {w with activation size} sublayer =
        inl lr = 
            match w with
            | {lr} -> lr
            | _ -> ()
        feedforward {
            size sublayer
            weights = inl s -> 
                inl d =
                    {
                    input = Initializer.relu (sublayer.size, size) s |> dr s
                    bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                    }
                //center = s.CudaTensor.zero {elem_type=float; dim=sublayer.size} |> dr s
                inl d =
                    match lr with
                    | {front} -> {d with front_precision=s.CudaKernel.init {dim=sublayer.size,sublayer.size} (inl a b -> if a = b then one else zero)}
                    | _ -> d
                inl d =
                    match lr with
                    | {back} -> {d with back_precision=s.CudaKernel.init {dim=size,size} (inl a b -> if a = b then one else zero)}
                    | _ -> d
                heap d
            apply = inl weights input -> 
                whiten lr weights input
                >>= activation // layer_norm_relu 0f32
            optimize = inl optimizer weights s ->
                optimizer s weights.input
                optimizer s weights.bias
                //reproject_bias s weights
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
            train test grad_check=grad_check train
            }
       
        {for Body} |> stackify

    inl Feedforward = 
        {
        Layer={Layer with init layer sigmoid tanh relu linear ln prong} |> stackify
        Pass
        } |> stack
    
    // #Recurrent
    /// The standard recurrent layer.
    inl layer initializer activation size sublayer =
        recurrent 
            {
            size sublayer
            weights = inl s -> 
                {
                input = initializer (sublayer.size, size) s |> dr s
                state = initializer (size, size) s |> dr s
                bias = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                } |> heap
            apply = inl weights state input -> 
                match state with
                | () -> matmultb (input, weights.input) weights.bias >>= activation
                | state -> matmultb ((input, weights.input), (state, weights.state)) weights.bias >>= activation
                >>= inl x -> succ (x,x)
            }

    inl sigmoid = layer Initializer.sigmoid Activation.sigmoid
    inl linear = layer Initializer.sigmoid succ

    inl lstm size sublayer =
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                inl sigmoid sublayer_size = sigmoid (sublayer_size, size) s |> dr s
                inl tanh sublayer_size = tanh (sublayer_size, size) s |> dr s
                inl weights sublayer_size = {
                    f = sigmoid sublayer_size
                    i = sigmoid sublayer_size
                    o = sigmoid sublayer_size
                    c = tanh sublayer_size
                    }
                inl bias0 _ = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
                inl bias init = 
                    inl x = s.CudaTensor.create {elem_type=float; dim=size} 
                    join s.CudaTensor.mmap (const init) x
                    dr s x
                {
                input = weights sublayer.size
                state = weights size
                bias = {
                    f = bias one
                    i = bias0 ()
                    o = bias0 ()
                    c = bias0 ()
                    }
                } |> heap

            apply = inl {input state bias} c i ->
                open Activation
                match c with
                | () ->
                    inm i' = matmultb (i,input.i) bias.i >>= sigmoid
                    inm o = matmultb (i,input.o) bias.o >>= sigmoid
                    inm c' = matmultb (i,input.c) bias.c >>= tanh
                    inm c = hadmult (i', c')
                    inm h' = tanh c
                    inm h = hadmult (o, h')
                    succ (h, (h, c))
                | h, c ->
                    inm f = matmultb ((i,input.f),(h,state.f)) bias.f >>= sigmoid
                    inm i' = matmultb ((i,input.i),(h,state.i)) bias.i >>= sigmoid
                    inm o = matmultb ((i,input.o),(h,state.o)) bias.o >>= sigmoid
                    inm c' = matmultb ((i,input.c),(h,state.c)) bias.c >>= tanh
                    inm c =
                        inm x1 = hadmult (f,c)
                        inm x2 = hadmult (i',c')
                        add (x1, x2)
                    inm h' = tanh c
                    inm h = hadmult (o, h')
                    succ (h, (h, c))
            }

    inl bias0 s size = s.CudaTensor.zero {elem_type=float; dim=size} |> dr s
    inl bias s size init = 
        inl x = s.CudaTensor.create {elem_type=float; dim=size} 
        join s.CudaTensor.mmap (const (dyn init)) x
        dr s x

    /// The multiplicative integration RNN.
    inl mi size sublayer = 
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                {
                input = tanh (sublayer.size, size) s |> dr s
                state = tanh (size, size) s |> dr s
                b1 = bias s size one
                b2 = bias s size half
                b3 = bias s size half
                b4 = bias0 s size
                } |> heap

            apply = inl {b1 b2 b3 b4 input state} s i ->
                inl fwd = tanh_fwd
                inl bck = tanh_bck
                match s with
                | () ->
                    inm i = matmult (i, input)
                    d2_replicate_activation {
                        fwd=inl (b3,b4) i -> b3*i + b4 |> fwd
                        bck_in=inl (b3,b4) i out -> (i, one) |> Tuple.map ((*) (bck out))
                        bck_in'=inl (b3,b4) i out -> b3 * bck out
                        } (b3,b4) i
                | _ ->
                    inm i = matmult (i, input)
                    inm s = matmult (s, state)
                    d2_replicate_activation {
                        fwd=inl (b1,b2,b3,b4) (i,s) -> b1*i*s + b2*s + b3*i + b4 |> fwd
                        bck_in=inl (b1,b2,b3,b4) (i,s) out -> (i*s, s, i, one) |> Tuple.map ((*) (bck out))
                        bck_in'=inl (b1,b2,b3,b4) (i,s) out -> (b1*s+b3, b1*i+b2) |> Tuple.map ((*) (bck out))
                        } (b1,b2,b3,b4) (i,s)
                >>= inl x -> succ (x,x)
            }

    /// Map + layer normalization + relu
    inl map_ln_relu {fwd bck_in bck_in'} =
        inl n bias i = 
            inl a,b = Struct.map (inl o -> {o without block}) i |> HostTensor.zip |> inl x -> x.dim
            Struct.iter (inl {primal adjoint} ->
                inl f x = 
                    inl b' :: () = x.dim
                    assert (b' = b) "The bias has to have a dimension equal to the input"
                f primal; f adjoint
                ) bias
            HostTensor.span b |> to float

        inl fwd' o b i w =
            inl n = n b i
            inl b = Struct.map (inl {primal} -> to_dev_tensor primal) b
            w.CudaKernel.mapi_d1_seq_broadcast {
                mapi_in=inl j i' i -> Struct.map (inl x -> x i' .get) b |> inl b -> fwd b i
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n) |> relu_fwd
                    }
                } (Struct.map primal i)

        inl bck' o r b i w =
            inl n = n b i
            inl b_primals = Struct.map (inl {primal} -> to_dev_tensor primal) b
            inl b_adjoints = Struct.map (inl {adjoint} -> to_dev_tensor adjoint) b
            w.CudaKernel.mapi_d1_seq_broadcast' {
                mapi_in=inl j i' (dr,i) -> 
                    inl b_primals = Struct.map (inl x -> x i' .get) b_primals
                    stack {b_primals i}, dr, fwd b_primals i
                seq = 
                    {
                    map_in=inl bis,dr,i -> i
                    redo=(+)
                    map_out=inl bis,dr,i sum -> bis, dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl bis,dr,v -> v*v
                    redo=(+)
                    map_out=inl bis,dr,v vv -> bis,(if v > zero then dr else zero),v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl bis,dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl bis,dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        bis,top + bot
                    }
                    ,
                    {
                    map_in=snd
                    redo=(+)
                    mapi_out=inl _ i' {b_primals i},dv dv_sum is_adjoints -> 
                        inl dx = dv - dv_sum / n

                        bck_in b_primals i
                        |> Struct.map ((*) dx)
                        // Note: The atomics make training non-deterministic.
                        |> Struct.iter2 (inl a -> atomic_add (a i')) b_adjoints

                        bck_in' b_primals i
                        |> Struct.map ((*) dx)
                        |> Struct.map2 (+) is_adjoints
                    }
                } (adjoint r, Struct.map primal i) (Struct.map adjoint i)

        inl o b i s ->
            inl r = fwd' o b i s |> dr s
            r, inl _ -> bck' o r b i s

    /// The multiplicative integration RNN with layer norm from the 'Normalizing the Normalizers' paper.
    inl miln o size sublayer = 
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                {
                input = relu (sublayer.size, size) s |> dr s
                state = relu (size, size) s |> dr s
                b1 = bias s size one
                b2 = bias s size half
                b3 = bias s size half
                b4 = bias0 s size
                } |> heap

            apply = inl {b1 b2 b3 b4 input state} s i ->
                match s with
                | () ->
                    inm i = matmult (i, input)
                    map_ln_relu {
                        fwd=inl (b3,b4) i -> b3*i + b4 
                        bck_in=inl (b3,b4) i -> (i, one) 
                        bck_in'=inl (b3,b4) i -> b3 
                        } o (b3,b4) i
                | _ ->
                    inm i = matmult (i, input)
                    inm s = matmult (s, state)
                    map_ln_relu {
                        fwd=inl (b1,b2,b3,b4) (i,s) -> b1*i*s + b2*s + b3*i + b4
                        bck_in=inl (b1,b2,b3,b4) (i,s) -> (i*s, s, i, one) 
                        bck_in'=inl (b1,b2,b3,b4) (i,s) -> (b1*s+b3, b1*i+b2)
                        } o (b1,b2,b3,b4) (i,s)
                >>= inl x -> succ (x,x)
            }


    inl prune_state state s =
        inl s = s.RegionMem.create
        inl f primal = primal.update_body (inl {x with ar} -> s.RegionMem.assign ar.ptr; x)
        inl state = Struct.map (inl {primal} | primal -> f primal) state
        inl region_clear _ = s.RegionMem.clear        
        state, region_clear

    inl Body =
        inl train {d with network} =
            inl rec loop c cost' (state, region_clear) =
                function
                | .unwrap -> region_clear(); cost' / to float64 c
                | input s {on_fail on_succ} ->
                    inl {from near_to} = outer input
                    Loops.foru {
                        from near_to
                        state=const zero, {state bck=const ()}
                        body=inl {state=cost',d i} ->
                            inl input = Struct.map ((|>) i) input
                            
                            // Note: Now that the memory transfers are async, run_parallel has a race condition, but it won't be an issue in practice.
                            // Comment it out if fully reproducible runs are needed, like for debugging for example.
                            // Also init_parallel can cause slight deviations from run to run even without run_parallel.
                            inl cost, d = run_parallel network {d with input} s
                            //inl cost, d = run network {d with input} s
                            

                            inl bck = term_cast d.bck ()
                            inl get = s.CudaTensor.get
                            inl cost _ = cost'() + get cost
                            term_cast cost (), {d with bck without input}
                        finally=inl cost, {bck state} ->
                            inl cost' = cost' + to float64 (cost ())
                            inl state = loop (c+1) cost' (prune_state state s)

                            if nan_is cost' then 
                                region_clear()
                                on_fail state
                            else
                                match d with
                                | {optimizer} ->
                                    bck()
                                    join optimize network optimizer s
                                | _ -> ()
                                region_clear()
                                on_succ state
                        }
            loop (dyn 0) (dyn 0.0) ({}, const ())
        {
        train grad_check=grad_check train
        } |> stackify

    inl sample' temp near_to network input s =
        Loops.foru {
            from=0; near_to 
            state=(), {}, const (), input
            body=inl {state=buffer,state,region_clear,input i} ->
                s.refresh
                inb s = s.RegionMem.create'
                inl input,{state} = run (sample temp network) {input={input}; bck=const (); state} s
                inl input_host = s.CudaTensor.to_host_tensor input |> stack
                inl buffer =
                    match buffer with
                    | () -> ResizeArray.create {elem_type=input_host}
                    | _ -> buffer
                buffer.add input_host
                
                inl (input, state), region_clear' = prune_state (input, state) s
                region_clear()
                buffer, state, region_clear', input
            finally=inl buffer,state,region_clear, input ->
                region_clear()
                buffer
            }

    inl sample temp near_to body x s =
        inb s = s.RegionMem.create'
        inl input = s.CudaTensor.create {elem_type=int64; dim=1}
        s.CudaTensor.set (input 0) (to int64 x)
        inl r = sample' temp near_to body input s
        Console.writeline "Sample:"
        r.iter (inl x -> Console.write (x 0 .get |> to char))
        Console.writeline ()
        Console.writeline "-----"

    inl Recurrent = 
        {
        Layer = {Layer with init init_parallel layer sigmoid linear lstm mi miln} |> stackify
        Pass = {for sample Body} |> stackify
        } |> stackify

    /// The differentiable action selectors.
    inl Selector =
        inl reduce_actions_template map_out x s = 
            s.CudaKernel.mapi_d1_redo_map {
                mapi_in=inl j i v _ -> v, i
                neutral_elem=-infinity,-1
                redo=inl a b -> if fst a > fst b then a else b
                map_out
                } x ()

        inl reduce_actions = reduce_actions_template snd
        inl reduce_actions' = reduce_actions_template id

        inl sampling_pg x s =
            inl dim_a, dim_b = primal x .dim
            inl batch_size = HostTensor.span dim_a
            assert (batch_size = 1) "Only a single dimension for now."

            inl p = softmax one (primal x) s
            inl a = sample_body p s

            a, inl (reward: float64) ->
                inl batch_size = to float batch_size
                inl reward = to float reward
                inl x_a = to_dev_tensor (adjoint x)
                inl p = to_dev_tensor p
                inl a = to_dev_tensor a
                s.CudaKernel.iter {dim=dim_a, dim_b} (inl j ->
                    inl x_a = x_a j
                    inl p = p j
                    inl a = a j .get

                    inl i ->
                        inl p = p i .get
                        inl x_a = x_a i
                        inl label = if a = i then one else zero
                        x_a.set (x_a.get + (p - label) * reward / batch_size) 
                    )

        {
        sampling_pg
        }

    inl RL =
        inl layer apply sublayer =
            Layer.layer {
                layer_type = .action_ff
                size = 1
                sublayer
                apply
                }

        inl init {range state_type action_type} s =
            inl size = Struct.foldl (inl s x -> s + SerializerOneHot.span range x) 0
            inl state_size = size state_type
            inl action_size = size action_type

            input .input state_size
            //|> Feedforward.Layer.tanh 256
            //|> Recurrent.Layer.miln 0f32 256
            |> Feedforward.Layer.ln 0f32 256
            |> Feedforward.Layer.linear action_size
            |> init s

        /// For online learning.
        inl action {range state_type action_type net state} i s =
            indiv join
                assert (eq_type state_type i) "The input must be equal to the state type."
                inl one_hot_tensor l, size = s.CudaKernel.init {dim=1,size} (inl _ x -> Struct.foldl (inl s x' -> if x = x' then one else s) zero l)
                inl input = 
                    Struct.foldl_map (inl s x -> 
                        inl i, s' = SerializerOneHot.encode' range x
                        s + i, s + s'
                        ) 0 i
                    |> one_hot_tensor

                inl a, {state bck} = run net {state input={input}; bck=const()} s
                inl action = SerializerOneHot.decode range (s.CudaTensor.get (a 0)) action_type
                stack (action, {bck state})

        {init layer Selector action}

    { 
    dr primal primals adjoint adjoints (>>=) succ Primitive Activation Optimizer Initializer Error Layer Combinator Feedforward Recurrent
    Selector RL
    }
    """) |> module_
