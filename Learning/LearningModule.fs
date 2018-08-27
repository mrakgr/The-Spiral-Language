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
        if is_in_use() then failwith () "The mutable function is already in use."
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
        match try_head l with () | _ as state -> 
            inl {state out} = f {state input}
            store := List.cons (box ty state) l
            is_in_use := false
            stack out
        |> indiv
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

    inl fwd_add_bias C bias s = s.CudaFun.map_map (out=C; in_inner=bias; map_out=map=inl {in in_inner} -> in+in_inner) C
    inl bck_add_bias C bias s = 
        s.CudaFun.redo_map {out=bias; mid=bias; neutral_elem=zero; redo=(+);
            map=inl {in} -> in
            map_out=inl {mid out} -> mid + out
            } C

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
        inl out = s.CudaFun.map {map=fwd} primal |> dr s

        inl adjoint, bck = choose_adjoints in bck
        {
        out
        bck=inl _ -> join
            inl bck (in, out) = Struct.map2 (inl bck -> bck (in, out)) bck
            on_non_nil (inl x -> s.CudaFun.map {map=bck; out=x} (primal, {out without block}) x) adjoint
        }

    /// Does not return a `dr` unlike the rest. This is an optimization in order to avoid having to call too many useless kernels that 
    /// just to set the adjoint to 1. The current library is intended for a narrow purpose.
    inl map_redo_map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaFun.redo fwd primal

        inl adjoint, bck = choose_adjoints in bck
        {
        out
        bck=inl _ -> join
            inl out = to_dev_tensor out
            inl bck in = Struct.map2 (inl bck -> bck (in, out.get)) bck
            s.CudaFun.map {out=adjoint; map=bck} primal
        }

    inl d2_replicate_map {fwd bck={bck_in bck_in'}} in in' s =
        inl primal, adjoint = primals in, adjoints in
        inl primal', adjoint' = primals in', adjoints in'
        inl out = s.CudaFun.map_map {map=fwd; in_inner=primal} primal' |> dr s
        { // TODO: This can't be right.
        out
        bck=inl _ -> join
            inl out = {out without block}
            s.CudaFun.redo_map {bck_in with out=adjoint; mid=primal} (primal', out)
            s.CudaFun.map_map {bck_in' with out=adjoint'; in_inner=primal} (primal', out)
        }

    inl Primitive =
        {
        matmult map map_redo_map matmultb d2_replicate_map
        } |> stack

    // #Operations
    inl (>>=) a b s =
        inl {out=a bck=a_bck} = a s
        inl {out=b bck=b_bck} = b a s
        {out=b; bck=a_bck, b_bck}

    inl succ out _ = {out bck=()}

    // #Activation
    inl activation d = map {d with bck = inl (in, out) adjoint ->
        Struct.map2 (inl bck adjoint -> adjoint + out.adjoint * (bck in out.primal)) self adjoint
        }

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

    inl hadmult (a,b) = 
        activation {
            fwd = inl {a b} -> a*b
            bck = {
                a = inl {b} _ -> b
                b = inl {a} _ -> a
                }
            } {a b}

    inl d2_replicate_activation {fwd bck_in bck_in'} in =
        inl neutral_elem = Struct.map (const zero) in
        inl bck = {
            bck_in={
                map=inl (in', out) in -> Struct.map ((*) out.adjoint) (bck_in in in' out.primal)
                neutral_elem redo=Struct.map2 (+)
                map_out=Struct.map2 (+)
                }
            bck_in'=inl in (in', out) -> Struct.map2 (inl x adjoint -> adjoint + out.adjoint*x) (bck_in' in in' out.primal)
            }
        d2_replicate_map { fwd bck } in

    inl hadmultb (x1,x2) b =
        activation {
            fwd=inl {b x1 x2} -> b + x1 * x2
            bck={
                b=inl _ _ -> one
                x1=inl {x2} _ -> x2
                x2=inl {x1} _ -> x1
                }
            } {b x1 x2}

    inl linear = succ
    inl Activation = {activation linear sigmoid tanh relu add hadmult hadmultb d2_replicate_activation } |> stack

    // #Optimizer
    inl sgd learning_rate s {primal adjoint} = 
        s.CudaFun.map {out=primal,adjoint; map=inl P, A -> P - learning_rate * A, zero} (primal, adjoint)

    inl clipped_sgd max learning_rate s {primal adjoint} = 
        s.CudaFun.map {
            out=primal,adjoint
            map=inl P, A -> 
                inl A = if A < -max then -max elif A > max then max else A
                P - learning_rate * A, zero
            } (primal, adjoint)

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
        inl output = s.CudaTensor.create_like input
        inl ins = CudaAux.to_dev_tensor (input,output)
        s.CudaKernel.init_seq {
            dim=input.dim
            init=inl b k ->
                inl input,output = Tuple.map (inl x -> x b) ins
                inl x = k.block.load input |> k.block.map (inl x -> x / temp)
                inl max_x = k.block.uter max x
                inl z = k.block.map (inl x -> exp (x - max_x)) x
                inl sum_z = k.block.uter (+) z
                k.block.store {
                    from=k.block.map (inl z -> z / sum_z) z
                    to=output
                    }
            }
        output
                
    inl sample_body prob s =
        inl b, a as dim = prob.dim
        inl boundary = s.CudaRandom.create {dst=.Uniform} {elem_type=float; dim=b}
        inl output = s.CudaTensor.create {elem_type=int64; dim=boundary.dim}
        inl inputs = Tuple.map CudaAux.to_dev_tensor (prob,boundary,output)
        s.CudaKernel.init_seq { // The sampling function
            dim
            init=inl b k ->
                inl prob,boundary,to = Tuple.map (inl x -> x b) inputs
                inl boundary = boundary.get
                k.block.store_scalar {to
                    from=
                        k.grid.for_items .x inner_size {
                            state=dyn {scan=0f32; redo=infinityf32,0}
                            body=inl {state i=a num_valid} ->
                                inl prob = prob a .get
                    
                                inl prob_at_a, scan = 
                                    inl redo = (+)
                                    k.thread.exscan {prefix=state.scan; redo} prob |> Tuple.map (redo state.scan)

                                inl distance_from_boundary, a = 
                                    inl x = boundary - prob_at_a
                                    (if x < 0f32 then infinityf32 else x), a

                                inl redo =
                                    inl redo a b = if fst a <= fst b then a else b
                                    k.thread.redo {num_valid redo} (distance_from_boundary, a) |> redo state.redo

                                {scan redo}
                            } .redo |> snd
                    }
            }
        output

    //#Error
    inl error {fwd bck} label input s = 
        map_redo_map {
            fwd = {
                map = fwd
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

    /// Applies a softmax and then calculates the cross entropy cost. Is intended to take the output of a linear layer as input.
    inl softmax_cross_entropy label input s =
        assert ((primal label).dim = (primal input).dim) "Labels and inputs must have equal dimensions."
        
        inl temp = one

        inl cost = 
            inl cost = s.CudaTensor.create {elem_type=float; dim=primal input .dim |> fst}
            inl _ =
                inl input, label, cost as ins = Tuple.map (primal >> to_dev_tensor) (input, label, cost)
                s.CudaKernel.init_seq {
                    dim=input.dim
                    init=inl b k ->
                        inl input,label,to = Tuple.map (inl x -> x b) ins
                        inl x = k.block.load input |> k.block.map (inl x -> x / temp)
                        inl max_x = k.block.uter max x
                        inl z = k.block.map (inl x -> exp (x - max_x)) x
                        inl sum_z = k.block.uter (+) z
                        inl prob = k.block.map (inl z -> z / sum_z) z
                        inl label = k.block.load label
                        inl costs = k.block.map (inl {prob label} -> -label * log prob) {prob label}
                        k.block.store_scalar { to from = k.block.redo (+) costs }
                    }
            s.CudaKernel.redo {
                redo = (+)
                neutral_elem = zero
                } cost

        inl bck _ = join
            inl input, label as ins = to_dev_tensor (input, label)
            s.CudaKernel.init_seq {
                dim=primal input .dim
                init=inl b k ->
                    inl p,a = Struct.map (inl x -> x b) ({input=primal input; label=primal label}, {input=adjoint input; label=adjoint label})
                    inl x = k.block.load p.input |> k.block.map (inl x -> x / temp)
                    inl max_x = k.block.uter max x
                    inl z = k.block.map (inl x -> exp (x - max_x)) x
                    inl sum_z = k.block.uter (+) z
                    inl prob = k.block.map (inl z -> z / sum_z) z
                    inl label = k.block.load p.label
                    inl ret {map in} = 
                        on_non_nil <| inl to ->
                            k.block.store {
                                to from=k.block.map {map=inl {in out} -> out + map in} {in out=k.block.load to}
                                }
                    ret {in={prob label} map=inl {prob label} -> (prob - label) / temp} a.input
                    ret {in=prob; map=inl prob -> -(log prob)} a.label
                }
        {out=cost; bck}

    inl accuracy label input s =
        inl input, label = primal input, primal label
        s.CudaFun.init_redo {
            map=inl {in} -> in
            neutral_elem=-infinity,zero
            redo=inl a b -> if fst a > fst b then a else b
            map_out=snd >> to int64
            } (input,label)
        |> s.CudaFun.redo {
            neutral_elem=0; redo=(+)
            }

    inl Error = {square sigmoid_cross_entropy softmax_cross_entropy accuracy} |> stackify

    // #Initializer
    inl Initializer x dim = {$x=dim; block=()}
    inl rec initialize s x =
        inl init mult dim s = 
            inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 dim))
            s.CudaRandom.create {dst=.Normal; stddev mean=0.0f32} {dim elem_type=float}

        Struct.map (function // Rough and possibly poorly tuned inits. Recommended to be used together with PRONG or layer/batch norm.
            | {sigmoid=dim} -> init 2f32 dim s |> dr s
            | {tanh=dim} -> init 3f32 dim s |> dr s
            | {relu=dim} -> init 1f32 dim s |> dr s
            | {bias=dim} -> s.CudaTensor.zero {elem_type=float; dim} |> dr s
            | {zero=dim} -> s.CudaTensor.zero {elem_type=float; dim}
            | {identity=dim} -> s.CudaKernel.init {dim} (inl a, b -> if a = b then one else zero)
            | {reference=x} -> ref x
            | {constant={dim init}} -> s.CudaKernel.init {dim} (const init) |> dr s
            | {prong={d with sublayer_size size}} -> 
                // 2 ** -3 is a sensible default.
                // There is a relation between the epsilon parameter and the learning rate.
                // Tests on the poker game show that up to 2 ** -2, every 2x increase in epsilon also allows a 2x increase in the learning rate.
                // The networks can be trained with epsilons of 2 ** -10 and lower, but all that seems to do is make the network overfit 
                // and forces the learning rates to go low. Unlike on Mnist where overfitting lowers the test accuracy, on the poker game 
                // it lowers the winrate instead. High learning rates seem to be necessary for generalization.
                inl default_epsilon = match d with {default_epsilon} -> default_epsilon | _ -> to float (2.0 ** -3.0)

                {
                front = {
                    covariance = Initializer.identity (sublayer_size, sublayer_size)
                    precision = Initializer.identity (sublayer_size, sublayer_size)
                    epsilon = match d with {epsilon={front}} -> front | _ -> default_epsilon
                    }
                back = {
                    covariance = Initializer.identity (size, size)
                    precision = Initializer.identity (size, size)
                    epsilon = match d with {epsilon={back}} -> back | _ -> default_epsilon
                    }
                k = match d with {steps_until_inverse_update} -> steps_until_inverse_update | _ -> 128 
                    |> Initializer.counter 
                } |> initialize s
            | {counter=init} ->
                inl r = ref init
                inl mod y =
                    inl x = r() + y
                    r := x
                    x <= 0
                function
                | .dec x -> mod -x
                | .mod -> mod
                | .reset -> r := init
                |> stack
            | x -> x
            ) x

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

    /// Updates the covariance such that cov(t+1) = alpha * cov t + beta / k * x^T * x + epsilon * I
    met update_covariance {identity_coef learning_rate} s cov x =
        inl k = x.span_outer
        inl alpha = Math.pow (one - learning_rate) k
        inl epsilon = (one - alpha) * identity_coef
        inl beta = one - alpha - epsilon
        inl _ =
            inl cov = CudaAux.to_dev_tensor cov
            s.CudaKernel.iter {dim=cov.dim} <| inl a, b -> 
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
            cd.CudaKernel.iter {dim=A.dim} <| inl a, b -> 
                inl A = A a b
                inl identity = if a = b then epsilon else zero
                A .set (alpha * A .get + identity)

        cd.CudaBlas.gemm' .T .nT (beta / to float32 k) a b one A

    inl naturalize config {prong input bias} x s =
        inl z = s.CudaBlas.gemm .nT .nT one (primal x) (primal input) |> dr s
        fwd_add_bias (primal z) (primal bias) s
        {
        out=z
        bck=inl d -> join
            inl finally x_precise_primal z_precise_adjoint =
                s.CudaBlas.gemm' .T .nT one x_precise_primal z_precise_adjoint one (adjoint input)
                on_non_nil (s.CudaBlas.gemm' .nT .T one (adjoint z) (primal input) one) (adjoint x)
                bck_add_bias z_precise_adjoint (adjoint bias) s

            match d with
            | {learning_rate} ->
                inl k = prong.k
                inl is_update = prong.k.dec (primal x).span_outer
                match config with
                | {mode=.optimize} -> if is_update then k.reset
                | {mode=.update} -> ()

                inb x_precise_primal = 
                    match prong with
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
                                inb basis_update = 
                                    inl map basis_max, basis_cur = basis_cur - discount_factor * basis_max
                                    s.CudaFun.map {map} (state', primal x) |> CudaAux.temporary
                                update_steady_state {identity_coef=epsilon; learning_rate} s steady_state x basis_update
                            | {state} -> error_type "Do not forget the discount factor."
                            | _ -> update_steady_state {identity_coef=epsilon; learning_rate} s steady_state x x

                            match config with
                            | {mode=.optimize} ->
                                if is_update then s.CudaSolve.lu_inverse {from=steady_state; to=steady_state_inverse}
                                inb x_precise_primal = s.CudaBlas.gemm .nT .T one x steady_state_inverse |> CudaAux.temporary
                                ret x_precise_primal
                            | {mode=.update} ->
                                ret x
                    | {front} -> error_type "front is improperly formed."
                    | _ ret -> ret <| primal x

                inb z_precise_adjoint = 
                    match prong with
                    | {back={covariance precision epsilon}} ret ->
                        inl z = adjoint z
                        update_covariance {identity_coef=epsilon; learning_rate} s covariance z
                        match config with
                        | {mode=.optimize} ->
                            if covariance.length = 1 then
                                inl covariance = CudaAux.to_dev_tensor covariance
                                inb z_precise_adjoint = s.CudaFun.map {map=inl z -> z / covariance 0 0 .get} z |> CudaAux.temporary
                                ret z_precise_adjoint
                            else
                                if is_update then s.CudaSolve.cholesky_inverse {from=covariance; to=precision}
                                inb z_precise_adjoint = s.CudaBlas.symm .Right .Lower one precision z |> CudaAux.temporary
                                ret z_precise_adjoint
                        | {mode=.update} ->
                            ret z
                    | {back} -> error_type "back is improperly formed."
                    | _ ret -> ret <| adjoint z

                finally x_precise_primal z_precise_adjoint
            | _ ->
                error_type "Since it would be too easy to forget to pass in the learning rate at this point this stop was added as an precaution."
                finally (primal x) (adjoint z)
        }

    inl prong {w with activation size} = 
        {
        init = inl sublayer_size -> {
            size
            dsc = {
                input = Initializer.tanh (sublayer_size, size)
                bias = Initializer.bias size
                prong = Initializer.prong {w with sublayer_size}
                }
            }
        apply = inl {weights input} ->
            naturalize {front_mode=.prong; mode=.optimize} weights input 
            >>= activation
        optimize=inl {weights={input bias} learning_rate} s ->
            Tuple.iter (Optimizer.sgd learning_rate s) (input, bias)
        block=()
        }

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

    // #Recurrent
    inl hebb n {input out H} = 
        inm x = matmult ({T=input},out)
        match H with
        | () ->
            activation {
                fwd=inl {n x} -> n * x
                bck={
                    n=inl {n x} _ -> x
                    x=inl {n x} _ -> n
                    }
                } {n x}
        | _ ->
            activation {
                fwd=inl {n x H} -> n * x + (one - n) * H
                bck={
                    n=inl {n x H} _ -> x - H
                    x=inl {n x H} _ -> n
                    H=inl {n x H} _ -> -n
                    }
                } {n x H}

    inl plastic_hebb initializer activation size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                input = {
                    bias = initializer (sublayer_size, size)
                    alpha = initializer (sublayer_size, size)
                    n = Initializer.constant {dim=sublayer_size, size; init=to float 0.5}
                    }
                bias = Initializer.bias size
                }
            size
            }

        apply = inl {d with weights input} s -> 
            assert (input.span_outer = 1) "The differentirable plasticity layer supports only online learning for now."
            inl apply =
                inm W, H = 
                    match d with
                    | {state} ->
                        inm H = hebb weights.input.n state
                        inm W = hadmultb (weights.input.alpha, H) weights.input.bias 
                        succ (W, H)
                    | _ -> succ (weights.input.bias, ())
                inm out = matmultb (input, W) weights.bias >>= activation
                succ {out state={out input H}}
            inl {out={out state} bck} = apply s
            {out state bck}
        block = ()
        }

    inl RNN = {plastic_hebb}

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

                    s.CudaFun.map {map=value} input

                { value bck = inl _ -> on_non_nil (inl out -> s.CudaFun.map' {out map=inl {value out} -> out - two * value} {value out}) (adjoint v) }

            inl mc v s {discount_factor reward} =
                match reward with
                | _: float32 -> td v s {discount_factor reward=discount_factor * reward; value'=()}
                | _ -> td v s {discount_factor reward=zero; value'=reward}

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
                        inl _ _ _ -> reward
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

            {pg mc}

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
    dr primal primals adjoint adjoints (>>=) succ Primitive Activation Optimizer Initializer Error run init Feedforward RNN RL
    }
    """) |> module_
