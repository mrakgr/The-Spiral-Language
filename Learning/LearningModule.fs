[<AutoOpen>]
module Learning.Lib

open Spiral.Types
open Spiral.Lib
open Cuda.Lib

let union =
    (
    "Union",[tuple;console;option;list],"The Union module.",
    """
/// The bounded integer type's constructor.
inl int {from near_to} value =
    assert (value >= from) "Value must be greater or equal to from."
    assert (value < near_to) "Value must be less than near_to."
    {from=.(from); near_to=.(near_to); value block=()}

/// Transforms the argument into an index. Accepts only bound integers as values as parts of tuples, modules or unions.
inl rec to_one_hot x =
    inl prod (i,s) x =
        inl i', s' = to_one_hot x
        i + i' * s, s * s'

    inl sum s x =
        inl i',s' = to_one_hot x
        s + i', s + s'

    match x with
    | _ when caseable_box_is x -> case_foldl_map sum 0 x
    | _ :: _ -> Tuple.foldl prod (0,1) x
    | .(_) | () -> 0,1
    | {!block} -> module_foldl (const prod) (0,1) x
    | {from=.(from) near_to=.(near_to) value block=()} -> value - from, near_to - from

/// x -> int64
inl to_one_hot = to_one_hot >> fst

inl to_dense f x =
    inl rec to_dense i x =
        match x with
        | _ when caseable_box_is x -> case_foldl_map (inl i x -> (), to_dense i x) i x |> snd
        | _ :: _ -> Tuple.foldl to_dense i x
        | .(_) | () -> f i; i+1
        | {!block} -> module_foldl (const to_dense) i x
        | {from=.(from) near_to=.(near_to) value block=()} -> f (i + value - from); i + near_to - from
    to_dense 0 x

/// Converts an argument to a dense representation. Accepts only bound integers as values as parts of tuples, modules or unions.
/// The output float32 array will contain only 1s or 0s as elements.
/// x -> float32 array
inl to_dense x =
    inl s = to_dense (inl _ -> ()) x
    inl ar = array_create float32 s
    to_dense (inl i -> ar i <- 1f32) x |> ignore
    ar

///// A simplifying rewrite in order to embed the sizes and the conversion types for the caseable_box_is case.
inl from_form op =
    inl op, init =
        match op with
        | .add -> (+), 0
        | .mult -> (*), 1

    inl rec from_form ty =
        inl prod s v =
            inl x = from_form v
            x, op s x.s

        match ty with
        | _ when caseable_box_is ty -> 
            inl x,s =
                Tuple.foldl_map (inl s v ->
                    inl x = from_form v
                    x, s + x.s
                    ) 0 (split ty)
            {ty s union_type=x}
        | _ :: _ -> 
            inl x, s = Tuple.foldl_map prod init ty
            {ty s x}
        | .(_) | () -> {ty s=1; x=ty}
        | {!block} -> 
            inl x, s = module_foldl_map (const prod) init ty
            {ty s x}
        | {from=.(from) near_to=.(near_to) value block=()} -> 
            {ty s=near_to - from; x=ty}

    from_form

inl from_one_hot_form = from_form .mult
inl length_one_hot x = from_one_hot_form x .s

/// Converts an index into a union type.
/// type -> int64 -> x
inl rec from_one_hot ty i =
    inl prod i ty =
        inl x = from_one_hot ty i
        x, i / ty.s

    inl {s ty=conv} = ty
    match ty with
    | {union_type=x} ->
        Tuple.foldr (inl x next i ->
            if i < x.s then box conv (from_one_hot x i) else next (i - x.s)
            ) x (inl i -> failwith conv "impossible") (i % s)
    | {x} ->
        match x with
        | _ :: _ -> Tuple.foldl_map prod i x |> fst
        | .(_) | () -> x
        | {!block} -> module_foldl_map (const prod) i x |> fst
        | {from=.(from) near_to=.(near_to) value block=()} -> {x with value=i % (near_to - from) + from}

inl from_one_hot ty i = 
    assert (i >= 0) "i needs to be greater or equal to zero."
    inl ty = from_one_hot_form (type ty)
    assert (i < ty.s) "The input to this function must be less than the size of the type."
    from_one_hot ty i

inl from_dense_form = from_form .add
inl length_dense x = from_dense_form x .s

inl from_dense true_is ty ar =
    inl fatal_fail conv _ = failwith conv "The array is in the wrong format."

    inl rec from_dense ty i =
        inl peek i {on_succ on_fail} = if true_is (ar i) then on_succ i else on_fail ()
        inl find {from near_to} {on_succ on_fail} =
            Loops.for' {from near_to 
                body=inl {next i} -> peek i {on_succ on_fail=next}
                finally=on_fail
                }

        inl {s ty=conv} = ty
        match ty with
        | {union_type=x} ->
            inl next _ = function
                | .find -> Option.none conv
                | .found, v -> Option.some v

            Tuple.foldr (inl x next i state ->
                inl r = indiv join stack (from_dense x i)
                match state with
                | .find ->
                    match r with
                    | .Some, v -> next (i + x.s) (.found, box conv v)
                    | .None -> next (i + x.s) state
                | .found, v -> 
                    match r with
                    | .Some, v -> fatal_fail (Option.none conv) ()
                    | .None -> next (i + x.s) state
                ) x next i .find
        | {x} ->
            match x with
            | _ :: _ -> 
                Tuple.foldr (inl x next i l on_fail ->
                    inl r = indiv join stack (from_dense x i)
                    match r with
                    | .Some, v -> next (i + x.s) (v :: l) (fatal_fail (Option.none conv))
                    | .None -> on_fail()
                    ) x (inl i l on_fail -> Option.some (Tuple.rev l)) i () (inl _ -> Option.none conv)
            | .(_) | () -> peek i {on_succ=(inl _ -> Option.some x); on_fail=(inl _ -> Option.none x)}
            | {!block} -> 
                module_foldr (inl k x next i m on_fail ->
                    inl r = indiv join stack (from_dense x i)
                    match r with
                    | .Some, v -> next (i + x.s) (module_add k v m) (fatal_fail (Option.none conv))
                    | .None -> on_fail()
                    ) x (inl i m on_fail -> Option.some m) i {} (inl _ -> Option.none conv)
            | {from=.(from) near_to=.(near_to) value block=()} -> 
                find {from=i; near_to=i+near_to-from} {
                    on_succ=inl i' ->
                        find {from=i'+1; near_to} {
                            on_succ=fatal_fail (Option.none conv)
                            on_fail=inl _ -> Option.some ({x with value=i' - i + from})
                            }
                    on_fail=inl _ -> Option.none conv
                    }

    match from_dense ty 0 with
    | .Some, v -> v
    | .None -> fatal_fail ty.ty ()

inl from_dense ty ar = 
    inl ty = from_dense_form (type ty)
    assert (array_length ar = ty.s) "The length of the array must be equal to the size of the type."
    from_dense ((=) 1f32) ty ar

inl rec unroll f x =
    inl x' = type f x
    if eq_type x x' then x
    else x \/ unroll f x'

inl mutable_function f {state=(!heap state) input} =
    inl f = f >> inl x -> {x with state=heap self}
    inl rec unroll_state state =
        inl state' = type f {state input} .state
        if eq_type state state' then state
        else state \/ unroll_state state'
    
    inl ty = unroll_state state
    inl state = List.singleton (box ty state) |> dyn
    inl store = ref state
    inl is_in_use = ref false
    function
    | .reset -> 
        inl x = store()
        store := state
        x
    | input -> 
        if is_in_use() then failwith () "The mutable function is already in use."
        is_in_use := true
        inl try_head l = List.head' l {some=id; none=inl ty -> failwith ty "The list should always be non-empty."}
        inl l = store()
        // That useless seeming pattern match is to trigger the uncasing of 
        // the union type so it can be converted to a layout type in this scope.
        // In order for this and unroll_state to be the same it is necessary for state to
        // be passed as a regular argument into f rather than an union type.
        inl {state out} = match try_head l with () | _ as state -> f {state input}
        store := List.cons (box ty state) l
        is_in_use := false
        out
    |> heap

{int to_one_hot to_dense from_one_hot from_dense length_one_hot length_dense unroll mutable_function} |> stackify
    """) |> module_

let learning =
    (
    "Learning",[struct';extern_;cuda_aux;math;union;list],"The deep learning module.",
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
        {
        out=C
        bck=inl _ -> join
            inl C' = adjoint C
            inl l =
                Tuple.iter (inl A, B -> 
                    inl (A,TA),(B,TB) = f' A, f' B
                    on_non_nil (inl A -> s.CudaBlas.gemm' .nT TB one C' (primal B) one A) (adjoint A)
                    on_non_nil (inl B -> s.CudaBlas.gemm' TA .nT one (primal A) C' one B) (adjoint B)
                    ) l
            on_non_nil (inl bias -> bck_add_bias C' bias s) (adjoint bias)
        }

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
        {
        out
        bck=inl _ -> join
            inl bck (in, out) = Struct.map2 (inl bck -> bck (in, out)) bck
            s.CudaKernel.map' bck (primal, {out without block}) adjoint
        }

    /// Does not return a `dr` unlike the rest. This is an optimization in order to avoid having to call too many useless kernels that 
    /// just to set the adjoint to 1. The current library is intended for a narrow purpose.
    inl map_redo_map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaKernel.map_redo_map fwd primal

        inl adjoint, bck = choose_adjoints in bck
        {
        out
        bck=inl _ -> join
            inl out = to_dev_tensor out
            inl bck in = Struct.map2 (inl bck -> bck (in, out.get)) bck
            s.CudaKernel.map' bck primal adjoint
        }

    inl d2_replicate_map {fwd bck={bck_in bck_in'}} in in' s =
        inl primal, adjoint = primals in, adjoints in
        inl primal', adjoint' = primals in', adjoints in'
        inl out = s.CudaKernel.d2_replicate_map fwd primal primal' |> dr s
        {
        out
        bck=inl _ -> join
            inl out = {out without block}
            s.CudaKernel.mapi_d2_redo_map' bck_in (primal', out) primal adjoint
            s.CudaKernel.d2_replicate_map' bck_in' primal (primal', out) adjoint'
        }

    inl Primitive =
        {
        matmult map map_redo_map matmultb d2_replicate_map
        } |> stack

    // #Operations
    inl apply_bck = (<<)

    inl (>>=) a b s =
        inl {out=a bck=a_bck} = a s
        inl {out=b bck=b_bck} = b a s
        {out=b; bck=apply_bck a_bck b_bck}

    inl succ out _ = {out bck=const ()}

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

    inl linear = succ
    inl Activation = {activation linear sigmoid tanh relu add hadmult d2_replicate_activation } |> stack

    // #Optimizer
    inl sgd learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> P - learning_rate * A, zero) primal.empty (primal, adjoint)

    inl clipped_sgd max learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> 
            inl A = if A < -max then -max elif A > max then max else A
            P - learning_rate * A, zero
            ) primal.empty (primal, adjoint)

    inl standard learning_rate s = 
        Struct.iter (function 
            | {optimize weights} -> optimize {learning_rate weights} s
            | {weights} -> Struct.iter (sgd learning_rate s) weights
            )

    inl Optimizer = {sgd clipped_sgd standard}

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
        map_redo_map {
            fwd = {
                map_in = fwd
                redo = (+)
                neutral_elem = zero
                }
            /// The adjoint in error is always assumed to be one.
            bck = Struct.map (inl bck (in, out) adjoint -> adjoint + (bck in out)) bck
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
                        mapi_out=inl j i _ c -> if threadIdx.x = 0 then cost j .set c
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
                            inl ret f = on_non_nil (inl x -> set x (get x + f ()))

                            inl p = x / sum_x
                            inl label = get label
                            ret (inl _ -> (p - label) / temp) input'
                            ret (inl _ -> -(log p)) label'
                        }
                    } input.dim
        {out=cost; bck}

    inl accuracy label input s =
        inl input, label = primal input, primal label
        s.CudaKernel.mapi_d1_redo_map {
            map_in=const
            neutral_elem=-infinity,zero
            redo=inl a b -> if fst a > fst b then a else b
            map_out=snd >> to int64
            } (input,label) ()
        |> s.CudaKernel.map_redo_map {
            neutral_elem=0; redo=(+)
            }

    inl Error = {square sigmoid_cross_entropy softmax_cross_entropy accuracy} |> stackify

    // #Initializer
    inl initialize s =
        inl init mult dim s = 
            inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 dim))
            s.CudaRandom.create {dst=.Normal; stddev mean=0.0f32} {dim elem_type=float}

        Struct.map (function // Rough and possibly poorly tuned inits. Recommended to be used together with PRONG or layer/batch norm.
            | {sigmoid=dim} -> init 2f32 dim s |> dr s
            | {tanh=dim} -> init 3f32 dim s |> dr s
            | {relu=dim} -> init 1f32 dim s |> dr s
            | {bias=dim} -> s.CudaTensor.zero {elem_type=float; dim} |> dr s
            | {zero=dim} -> s.CudaTensor.zero {elem_type=float; dim}
            | {identity=dim} -> s.CudaKernel.init {dim} (inl a b -> if a = b then one else zero)
            | {reference=x} -> ref x
            | x -> x
            )

    inl init s size dsc = 
        Struct.foldl_map (inl sublayer_size {x with init} -> 
            inl {dsc size} = init sublayer_size
            inl weights = initialize s dsc |> heap
            {x without init with weights}, size
            ) size dsc

    inl run s input = 
        Struct.foldl_map (inl input {layer with apply} -> 
            inl input = 
                inl input = {input}
                inl input = match layer with {weights} -> {input with weights} | _ -> input
                match layer with {state} -> {input with state} | _ -> input

            inl {x with out} = indiv join apply input s |> stack
            inl layer = match x with {bck} -> {layer with bck=heap bck} | _ -> layer
            inl layer = match x with {state} -> {layer with state=heap state} | _ -> layer
            layer, out
            ) input

    inl Initializer x dim = {$x=dim; block=()}

    /// Updates the covariance such that cov(t+1) = alpha * cov t + beta / k * x^T * x + epsilon * I
    met update_covariance {identity_coef learning_rate} s cov x =
        inl k = x.span_outer
        inl alpha = Math.pow (one - learning_rate) k
        inl epsilon = (one - alpha) * identity_coef
        inl beta = one - alpha - epsilon
        inl _ =
            inl cov = CudaAux.to_dev_tensor cov
            s.CudaKernel.iter {dim=cov.dim} <| inl a b -> 
                if b <= a then
                    inl cov = cov a b
                    inl identity = if a = b then epsilon else zero
                    cov .set (alpha * cov .get + identity)
        s.CudaBlas.syrk' .Lower .T (beta / to float k) x one cov // symmetric rank-k update. (beta / to float k) * x * x^T + cov

    /// Updates the state state matrix such that A(t+1) = alpha * A(t) + beta / k * a^T * b + epsilon * I
    /// Was changed from the Zap paper to have positive eigenvalues in order to mirror the covariance matrix updates 
    /// used in natural gradient methods.
    met update_steady_state {identity_coef learning_rate} cd A a b =
        inl k = a.span_outer
        inl alpha = Math.pow (one - learning_rate) k
        inl epsilon = (one - alpha) * identity_coef
        inl beta = one - alpha - epsilon
        inl _ =
            inl A = CudaAux.to_dev_tensor A
            cd.CudaKernel.iter {dim=A.dim} <| inl a b -> 
                inl A = A a b
                inl identity = if a = b then epsilon else zero
                A .set (alpha * A .get + identity)

        cd.CudaBlas.gemm' .T .nT (beta / to float32 k) a b one A

    inl whiten config {steps_until_inverse_update learning_rate_modifier} weights x s =
        inl z = s.CudaBlas.gemm .nT .nT one (primal x) (primal weights.input) |> dr s
        match weights with
        | {bias} -> fwd_add_bias (primal z) (primal bias) s
        | _ -> ()
        {
        out=z
        bck=inl d -> join
            match d with
            | {learning_rate} ->
                inl learning_rate = learning_rate_modifier learning_rate
                inl is_update = 
                    inl span = (primal x).span_outer
                    inl k = weights.k
                    inl x = k() - span
                    match config with
                    | {mode=.optimize} ->
                        if x <= 0 then k := steps_until_inverse_update; true
                        else k := x; false
                    | {mode=.update} ->
                        k := x

                inb x_precise_primal = 
                    match weights with
                    | {front={covariance precision epsilon}} ret -> 
                        inl x = primal x
                        match config with
                        | {front_mode=.prong} ->
                            update_covariance {identity_coef=epsilon; learning_rate} s covariance x

                            match config with
                            | {mode=.optimize} ->
                                if is_update then s.CudaSolve.cholesky_inverse {from=covariance; to=precision}
                                inb x_precise_primal = s.CudaBlas.symm .Right .Lower one precision x |> CudaAux.temporary
                                ret x_precise_primal
                            | {mode=.update} ->
                                ret x
                        | {front_mode=.zap} ->
                            // Zap is quite similar to PRONG's front pass.
                            inl steady_state = covariance
                            inl steady_state_inverse = precision

                            match d with
                            | {state=state' discount_factor} ->
                                inb basis_update = s.CudaKernel.map (inl basis_max, basis_cur -> basis_cur - discount_factor * basis_max) (state', primal x) |> CudaAux.temporary
                                update_steady_state {identity_coef=epsilon; learning_rate} s steady_state x basis_update
                            | {state} -> error_type "Do not forget the discount factor."
                            | _ -> update_steady_state {identity_coef=epsilon; learning_rate} s steady_state x x

                            match config with
                            | {mode=.optimize} ->
                                if is_update then s.CudaSolve.lu_inverse {from=steady_state; to=steady_state_inverse}
                                inb x_precise_primal = s.CudaBlas.gemm .nT .nT one steady_state_inverse x |> CudaAux.temporary
                                ret x_precise_primal
                            | {mode=.update} ->
                                ret x
                    | {front} -> error_type "front is improperly formed."
                    | _ ret -> ret <| primal x

                inb z_precise_adjoint = 
                    match weights with
                    | {back={covariance precision epsilon}} ret ->
                        inl z = adjoint z
                        update_covariance {identity_coef=epsilon; learning_rate} s covariance z
                        match config with
                        | {mode=.optimize} ->
                            if covariance.length = 1 then
                                inl covariance = CudaAux.to_dev_tensor covariance
                                inb z_precise_adjoint = s.CudaKernel.map (inl z -> z / covariance 0 0 .get) z |> CudaAux.temporary
                                ret z_precise_adjoint
                            else
                                if is_update then s.CudaSolve.cholesky_inverse {from=covariance; to=precision}
                                inb z_precise_adjoint = s.CudaBlas.symm .Right .Lower one precision z |> CudaAux.temporary
                                ret z_precise_adjoint
                        | {mode=.update} ->
                            ret z
                    | {back} -> error_type "back is improperly formed."
                    | _ ret -> ret <| adjoint z

                s.CudaBlas.gemm' .T .nT one x_precise_primal z_precise_adjoint one (adjoint weights.input)
                on_non_nil (s.CudaBlas.gemm' .nT .T one (adjoint z) (primal weights.input) one) (adjoint x)
                match weights with
                | {bias} -> bck_add_bias z_precise_adjoint (adjoint bias) s 
                | _ -> ()
            | _ ->
                error_type "Since it would be too easy to forget to pass in the learning rate at this point this stop was added as an precaution."
                s.CudaBlas.gemm' .T .nT one (primal x) (adjoint z) one (adjoint weights.input)
                on_non_nil (s.CudaBlas.gemm' .nT .T one (adjoint z) (primal weights.input) one) (adjoint x)
                match weights with
                | {bias} -> bck_add_bias (adjoint z) (adjoint bias) s
                | _ -> ()
                
        }

    inl prong_template config {w with size} =
        // 2 ** -3 is a sensible default.
        // There is a relation between the epsilon parameter and the learning rate.
        // Tests on the poker game show that up to 2 ** -2, every 2x increase in epsilon also allows a 2x increase in the learning rate.
        // The networks can be trained with epsilons of 2 ** -10 and lower, but all that seems to do is make the network overfit 
        // and forces the learning rates to go low. Unlike on Mnist where overfitting lowers the test accuracy, on the poker game 
        // it lowers the winrate instead. High learning rates seem to be necessary for generalization.
        inl default_epsilon = 2f32 ** -3f32 
        inl f front =
            match w with
            | {$front={x with epsilon}} -> x
            | {$front=()} -> ()
            | _ -> {epsilon=default_epsilon}

        inl front = f .front
        inl back = f .back

        inl {initializer steps_until_inverse_update learning_rate_modifier activation} =
            inl defaults =
                {
                initializer=Initializer.tanh
                steps_until_inverse_update=128
                learning_rate_modifier=inl x -> x ** 0.85f32 // A sensible default for PRONG. Taken from the Zap paper.
                activation=Activation.tanh
                }

            module_foldl (inl k def x -> match w with {$k=x} -> {def with $k=x} | _ -> {def with $k=x}) {} defaults

        {
        init = inl sublayer_size -> {
            size
            dsc =
                inl d =
                    {
                    input = initializer (sublayer_size, size)
                    bias = Initializer.bias size
                    k = Initializer.reference steps_until_inverse_update
                    }
                
                inl init x = Initializer.identity (x,x)
                inl f name front init d =
                    match front with
                    | () -> d
                    | front -> {d with $name={front with covariance=init; precision=init}}

                f .front front (init sublayer_size) d
                |> f .back back (init size)
            }
                
        apply = inl {weights input} s -> 
            inl {out=a bck=bck_a} = whiten config {steps_until_inverse_update learning_rate_modifier} weights input s
            inl {out=b bck=bck_b} = activation a s
            {
            out=b
            bck=inl x -> bck_b(); bck_a x
            }
        optimize=inl {weights={input bias front back k} learning_rate} s ->
            match config with
            | {mode=.update} -> // In update mode, the reprojection is done during the optimization pass.
                if k() <= 0 then
                    k := steps_until_inverse_update
                    inl {covariance precision} = front
                    match config with
                    | {front_mode=.zap} -> s.CudaSolve.lu_inverse {from=covariance; to=precision}
                    | {front_mode=.prong} -> s.CudaSolve.cholesky_inverse {from=covariance; to=precision}
                    inl {covariance} = back
                    if covariance.length <> 1 then 
                        s.CudaSolve.cholesky_inverse {from=covariance; to=precision}
                    else
                        () // Just divide by covariance directly.
                
                inb input_adjoint =
                    inl {precision} = back
                    inl reshape x = x.reshape (inl x -> 1,x)
                    inl l = back.covariance.length
                    if back.covariance.length <> 1 then 
                        s.CudaTensor.gemm' .nT .nT -learning_rate (adjoint bias |> reshape) precision one (primal bias |> reshape)
                        s.CudaBlas.symm .Right .Lower one precision input.adjoint
                    else
                        inl covariance = CudaAux.to_dev_tensor back.covariance
                        s.CudaKernel.map' (inl x o -> o - learning_rate * x / covariance 0 0 .get) bias.adjoint bias.primal
                        s.CudaKernel.map (inl x -> x / covariance 0 0 .get) input.adjoint
                    |> CudaAux.temporary
                
                inl {precision} = front
                match config with
                | {front_mode=.zap} -> s.CudaBlas.gemm' .nT .nT -learning_rate precision input_adjoint one input.primal
                | {front_mode=.prong} -> s.CudaBlas.symm' .Left .Lower -learning_rate precision input_adjoint one input.primal

                s.CudaTensor.clear input.adjoint
                s.CudaTensor.clear bias.adjoint
            | {mode=.optimize} ->
                Optimizer.sgd learning_rate s input
                Optimizer.sgd learning_rate s bias
        block=()
        }

    inl prong = prong_template {front_mode=.prong; mode=.optimize}

    // #Feedforward
    inl layer initializer activation size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                input = initializer (sublayer_size, size)
                bias = Initializer.bias size
                }
            size
            }

        apply = inl {weights input} -> matmultb (input, weights.input) weights.bias >>= activation
        block = ()
        }

    inl Feedforward = 
        inl sigmoid = layer Initializer.sigmoid sigmoid
        inl relu = layer Initializer.relu relu
        inl tanh = layer Initializer.tanh tanh
        inl linear = layer Initializer.sigmoid succ
        inl zero = layer Initializer.bias succ        
        {sigmoid relu tanh linear zero prong} |> stackify

    inl RL =
        inl Value = // The value functions for RL act more like activations.
            inl td v s {discount_factor reward value'=v'} =
                inl value =
                    inl input =
                        match reward with
                        | _: float32 -> assert ((primal v).length = 1) "The length of v must be 1."; {v=primal v}
                        | _ -> {reward v=primal v}

                    inl {value input} =
                        match v' with
                        | () -> {
                            value = inl {reward v} -> reward - v
                            input
                            }
                        | _ -> {
                            value = inl {reward v' v} -> (reward + discount_factor * v') - v
                            input = {input with v'}
                            }

                    inl value = 
                        match reward with
                        | _: float32 -> inl x -> value {x with reward}
                        | _ -> value

                    s.CudaKernel.map value input

                { value bck = inl _ -> on_non_nil (s.CudaKernel.map' (inl value out -> out - two * value) value) (adjoint v) }

            inl mc v s {discount_factor reward} =
                match reward with
                | _: float32 -> td v s {discount_factor reward=discount_factor * reward; value'=()}
                | _ -> td s v {discount_factor reward=zero; value'=reward}

            {td mc}

        /// The PG activation.
        inl sampling_pg x s =
            inl dim_a, dim_b = primal x .dim
            inl p = softmax one (primal x) s
            inl out = sample_body p s

            {
            out
            bck=inl {reward} -> join
                inl reward = 
                    match reward with
                    | _: float32 | _: float64 ->
                        assert (HostTensor.span dim_a = 1) "In the scalar reward case, the outer dimension of the input must be 1."
                        inl reward = to float reward
                        inl _ _ -> reward
                    | _ ->
                        assert (dim_a = fst reward.dim) "Reward's dimensions must be equal to that of the input's outer dimnesion."
                        assert (snd reward.dim = {from=0; near_to=1}) "Reward's second dimension must be {from=0; near_to=1}." 
                        CudaAux.to_dev_tensor reward

                    
                inl x_a, p, out = to_dev_tensor (adjoint x, p, out)
                s.CudaKernel.iter {dim=dim_a, dim_b} <| inl j ->
                    inl x_a, p, out, reward = x_a j, p j, out j .get, reward j 0 .get

                    inl i ->
                        inl p = p i .get
                        inl x_a = x_a i
                        inl label = if out = i then one else zero
                        x_a.set (x_a.get + (p - label) * reward) 
            }

        inl Layer =
            inl default w = 
                inl defaults =
                    {
                    initializer=Initializer.bias
                    activation=Activation.linear
                    }

                module_foldl (inl k w x -> match w with {$k=_} -> w | _ -> {w with $k=x}) w defaults

            inl pg = default >> prong

            // Both the MC and the TD layers do their reprojection steps on the optimization pass unlike
            // the vanilla PRONG layers.
            inl mc (!default {w with !size}) = prong_template {front_mode=.prong; mode=.update} {w with size=1}

            // The TD layer uses the Zap update from the 'Fastest Convergence for Q-Learning' paper by Devray and Meyn 
            // in place of the standard PRONG update. It works better than standard TD, but is still a net negative in an AC
            // agent.
            inl td (!default {w with !size}) = prong_template {front_mode=.zap; mode=.update} {w with size=1}

            {pg mc td}

        /// For online learning.
        inl action {State Action final} {net input} s =
            indiv join
                assert (eq_type State input) "The input must be equal to the state type."
                inl input = 
                    inl tns = Union.to_dense input |> HostTensor.array_as_tensor
                    s.CudaTensor.from_host_tensor tns .reshape (inl x -> 1, Union.length_dense State)

                inl net, input = run s input net
                inl {out bck} = final input s

                inl action = Union.from_one_hot Action (s.CudaTensor.get (out 0))
                stack {action net bck}
       
        {action sampling_pg Layer Value}

    { 
    dr primal primals adjoint adjoints (>>=) succ Primitive Activation Optimizer Initializer Error run init Feedforward RL
    }
    """) |> module_
