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

inl infer f (!heap state) =
    inl f = Struct.map (inl d -> {d with map=met state input -> heap (self state input)}) f
    inl unroll_state state =
        inl rec loop {f with map input} state =
            inl state' = map state (input ())
            if eq_type state state' then state
            else state \/ loop f state'
        
        Struct.foldl (inl state f -> 
            split state
            |> Tuple.wrap
            |> Tuple.map (loop f)
            |> Tuple.reducel (inl a b -> a \/ b)
            ) state f

    inl ty =
        type
            inl rec loop prev =
                inl cur = unroll_state prev
                if eq_type prev cur then cur else loop cur
            loop state

    ty, Struct.map (inl {map} state input -> match state with () | _ -> map state input |> box ty) f

{int to_one_hot to_dense from_one_hot from_dense length_one_hot length_dense unroll mutable_function infer} |> stackify
    """) |> module_

let learning =
    (
    "Learning",[struct';extern_;cuda_aux;math;union;list;liple],"The deep learning module.",
    """
inl float ->
    // #Primitives
    inl to_dev_tensor = CudaAux.to_dev_tensor
    inl atomic_add = CudaAux.atomic_add
    inl assert_dim = CudaAux.assert_dim
    
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

    inl fwd_add_bias C bias s = s.CudaFun.map_map {out=C; map=inl {in in_inner} -> in+in_inner} {in=C; in_inner=bias}
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
                    on_non_nil (inl A -> 
                        match TA with // Note: TA and TB are opposite of what they should be.
                        | .T -> s.CudaBlas.gemm' .nT TB one C' (primal B) one A
                        | .nT -> s.CudaBlas.gemm' .nT TB one (primal B) C' one A
                        ) (adjoint A)
                    on_non_nil (inl B -> 
                        match TB with
                        | .T -> s.CudaBlas.gemm' TA .nT one (primal A) C' one B
                        | .nT -> s.CudaBlas.gemm' TA .nT one C' (primal A) one B
                        ) (adjoint B)
                    ) l
            on_non_nil (inl bias -> bck_add_bias C' bias s) (adjoint bias)
        }

    inl matmult l s = matmultb l () s

    inl activation {fwd bck} in s =
        inl x = primals in |> HostTensor.zip
        inl dim = x.dim
        inl out = s.CudaFun.map {map=fwd} x |> dr s

        {
        out
        bck=inl _ -> join
            if Struct.is_empty in = false then
                inl ins = to_dev_tensor {in out}
                s.CudaKernel.iter {dim} <| inl i ->
                    inl {in out} = Struct.map' (inl x -> x i) ins
                    inl x = bck {in=Struct.map (inl x -> x .get) (primals in); out=primal out .get}
                    inl out = adjoint out .get
                    Struct.iter2 (inl x -> function
                        | () -> ()
                        | z -> z .set (z .get + out * x)
                        ) x (adjoints in)
        }

    /// Does not return a `dr` unlike the rest. This is an optimization in order to avoid having to call too many useless kernels that 
    /// just to set the adjoint to 1. The current library is intended for a narrow purpose.
    inl error {fwd bck} in s =
        inl x = primals in |> HostTensor.zip
        inl dim = x.dim
        inl out = s.CudaFun.redo {redo=(+); neutral_elem=zero; map=fwd} x 0
        
        {
        out
        bck=inl _ -> join
            if Struct.is_empty in = false then
                inl in = to_dev_tensor in // As none of the cost functions I've ran into use the `out`, I've removed it for the time being.
                s.CudaKernel.iter {dim} <| inl i ->
                    inl in = Struct.map' (inl x -> x i) in
                    inl x = bck {in=Struct.map (inl x -> x .get) (primals in)}
                    Struct.iter2 (inl x -> function
                        | () -> ()
                        | z -> z .set (z .get + x) // The adjoint is set to 0.
                        ) x (adjoints in)
        }

    inl broadcasting_activation {fwd bck} ins s =
        inl out = s.CudaFun.map_map {map=fwd} (primals ins) |> dr s
        
        {
        out
        bck=inl _ -> join
            inl ins = to_dev_tensor {ins with out}
            inl dim = primal ins.out .dim
            inl primals_with_adjoint_of = Struct.foldl (inl m k -> {m with $k={primal=self; adjoint=adjoints (ins k); block=()}}) (primals ins)
            inl get_primals ins = Struct.map' (inl x -> x.get) (primals ins)
            inl adjoint_of k ins = Struct.foldl (inl m k -> {m with $k=adjoints (ins k)}) {} k
            inl index k i ins = Struct.foldl (inl ins k -> if module_has_member k ins then {ins with $k=Struct.map' (inl x -> x i) self} else ins) ins k
            inl finally out =
                Struct.iter2 (inl x -> function
                    | () -> ()
                    | in -> in .set (in .get + out * x)
                    )

            inl handle =
                inl ads = adjoints ins
                inl k f ->
                    match ads with
                    | {$k=adjoint} when Struct.is_empty adjoint = false ->
                        inl bck = bck k
                        inl ins = primals_with_adjoint_of (k, .out)
                        f {bck ins}
                    | _ -> ()

            handle .in <| inl {bck ins} ->
                s.CudaKernel.iter2 {dim} <| inl i ->
                    inl ins =
                        index .in_scalar 0 ins
                        |> index .in_scalar .get
                        |> index (.in, .in_outer, .out) i
                        |> index .in_outer .get
                    inl i ->
                        inl ins = index (.in, .in_inner, .out) i ins
                        inl x = primals ins |> index (.in, .out, .in_inner) .get |> bck
                        inl {in out} = adjoint_of (.in, .out) ins
                        finally out.get x in

            handle .in_inner <| inl {bck ins} ->
                s.CudaKernel.redo_init {
                    dim
                    redo=Struct.map2 (+)
                    init=inl a ->
                        inl ins =
                            index .in_scalar 0 ins
                            |> index .in_scalar .get
                            |> index .in_inner a
                            |> index .in_inner .get
                        inl b ->
                            inl ins = 
                                index (.in, .in_outer, .out) b ins
                                |> index (.in, .out) a
                            primals ins
                            |> index (.in, .in_outer, .out) .get
                            |> bck |> Struct.map ((*) (adjoint ins.out .get))
                    outit=inl a x ->
                        finally one x (Struct.map (inl x -> x a) (adjoints ins.in_inner))
                    }

            handle .in_outer <| inl {bck ins} ->
                s.CudaKernel.init_redo {    
                    dim
                    redo=Struct.map2 (+)
                    init=inl b ->
                        inl ins =
                            index .in_scalar 0 ins
                            |> index .in_scalar .get
                            |> index (.in, .in_outer, .out) b
                            |> index .in_outer .get
                        inl a ->
                            inl ins = index (.in, .in_inner, .out) a ins
                            primals ins 
                            |> index (.in, .in_inner, .out) .get 
                            |> bck |> Struct.map ((*) (adjoint ins.out .get))
                    outit=inl b x ->
                        finally one x (Struct.map (inl x -> x b) (adjoints ins.in_outer))
                    }

            handle .in_scalar <| inl {bck ins} ->
                s.CudaKernel.redo {    
                    dim
                    redo=Struct.map2 (+)
                    init=inl b,a ->
                        inl ins =
                            index .in_scalar 0 ins
                            |> index (.in, .in_outer, .out) b
                            |> index (.in, .in_inner, .out) a
                        Struct.map ((*) (adjoint ins.out .get)) (bck (get_primals ins))
                    outit=inl i x ->
                        finally one x (Struct.map (inl x -> x i) (adjoints ins.in_scalar))
                    }
        }

    inl Primitive =
        {
        matmult activation error matmultb broadcasting_activation
        } |> stack

    // #Operations
    inl (>>=) a b s =
        inl {out=a bck=a_bck} = a s
        inl {out=b bck=b_bck} = b a s
        {out=b; bck=a_bck, b_bck}

    inl succ out _ = {out bck=()}

    // #Activation
    inl sigmoid_fwd x = one / (one + exp -x)
    inl sigmoid_bck out = out * (one - out)

    inl sigmoid = activation {
        fwd = sigmoid_fwd
        bck = inl {out} -> sigmoid_bck out
        }

    inl tanh_fwd = tanh
    inl tanh_bck out = one - out * out

    inl tanh = activation {
        fwd = tanh_fwd
        bck = inl {out} -> tanh_bck out
        }

    inl relu_fwd x = if x > zero then x else zero
    inl relu_bck out = if out > zero then one else zero

    inl relu = activation {
        fwd = relu_fwd
        bck = inl {out} -> relu_bck out
        }

    inl add = activation {
        fwd = inl a,b -> a+b
        bck = inl _ -> one, one
        }

    inl hadmult (a,b) = 
        activation {
            fwd = inl {a b} -> a*b
            bck = inl {in={a b}} -> { a = b; b = a }
            } {a b}

    inl hadmultb (x1,x2) b =
        activation {
            fwd=inl {b x1 x2} -> b + x1 * x2
            bck=inl {in={b x1 x2}} -> {b = one; x1 = x2; x2 = x1 }
            } {x1 x2 b}

    inl linear = succ
    inl Activation = {linear sigmoid tanh relu add hadmult hadmultb } |> stack

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

    inl prong {learning_rate} s cov w =
        inl k_max = 128
        inl f {covariance precision k} = 
            if k () >= k_max then
                k := 0
                s.CudaSolve.cholesky_inverse {from=covariance; to=precision}
        module_map (inl _ x -> f x; ()) {cov without block} |> ignore

        inl reproject a b ret =
            inb x = s.CudaBlas.gemm .nT .nT one a b |> CudaAux.temporary
            ret x

        inl reproject_to a b c = s.CudaBlas.gemm' .nT .nT -learning_rate a b one c
        inl clear = s.CudaTensor.clear
        
        Struct.iter (inl w ->
            match cov with
            | {front={precision=front} back={precision=back}} -> 
                inb x = reproject front (adjoint w)
                reproject_to x back (primal w)
            | {back={precision=back}} -> reproject_to (adjoint w) back (primal w)
            | {front={precision=front}} -> reproject_to front (adjoint w) (primal w)
            clear (adjoint w)
            ) w

    inl standard learning_rate s = 
        Struct.iter (function 
            | {optimize weights} -> optimize {learning_rate weights} s
            | {weights} -> 
                inl rec loop x =
                    Struct.iter (function
                        | {cell} -> loop cell
                        | x -> sgd learning_rate s x
                        ) x
                loop weights
                        
            )

    inl Optimizer = {sgd clipped_sgd standard prong}

    inl softmax_body temp k input =
        inl x = k.block.map (inl x -> x / temp) (k.block.load input)
        inl max_x = k.block.uter max x
        inl z = k.block.map (inl x -> exp (x - max_x)) x
        inl sum_z = k.block.uter (+) z
        k.block.map (inl z -> z / sum_z) z

    // #Auxiliary
    /// The softmax activation
    inl softmax temp input s =
        inl output = s.CudaTensor.create_like input
        inl ins = CudaAux.to_dev_tensor (input,output)
        s.CudaKernel.init_seq {
            dim=input.dim
            init=inl b k ->
                inl input,output = Tuple.map (inl x -> x b) ins
                k.block.store {
                    from=softmax_body temp k input
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
                        k.grid.for_items .x a {
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
                                    inl redo a b = if fst a < fst b then a else b
                                    k.thread.redo {num_valid redo} (distance_from_boundary, a) |> redo state.redo

                                {scan redo}
                            } .redo |> snd
                    }
            }
        output

    //#Error
    inl square y x = 
        error {
            fwd = inl {x y} -> (y - x) * (y - x)
            bck = inl {in={x y}} -> {x = two * (x - y); y = -(two * (x - y))}
            } {x y}

    inl sigmoid_cross_entropy y x = 
        error {
            fwd = inl {x y} -> 
                inl x = sigmoid_fwd x
                -(y * log x + (one - y) * log (one - x))
            bck = inl {in={x y}} -> 
                inl x = sigmoid_fwd x
                { x = x - y; y = log (one - x) - log x }
            } {x y}

    /// Applies a softmax and then calculates the cross entropy cost. Is intended to take the output of a linear layer as input.
    inl softmax_cross_entropy label input s =
        assert ((primal label).dim = (primal input).dim) "Labels and inputs must have equal dimensions."
        
        inl temp = one

        inl cost = 
            inl cost = s.CudaTensor.create {elem_type=float; dim=primal input .dim |> fst}
            inl _ =
                inl input, label, cost as ins = to_dev_tensor (primals (input, label, cost))
                s.CudaKernel.init_seq {
                    dim=input.dim
                    init=inl b k ->
                        inl input,label,to = Tuple.map (inl x -> x b) ins
                        inl prob = softmax_body temp k input
                        inl label = k.block.load label
                        inl costs = k.block.map (inl {prob label} -> -label * log prob) {prob label}
                        k.block.store_scalar { to from = k.block.redo (+) costs }
                    }
            s.CudaFun.redo {
                redo = (+)
                neutral_elem = zero
                } cost 0

        inl bck _ = join
            inl ins = to_dev_tensor (input, label)
            s.CudaKernel.init_seq {
                dim=primal input .dim
                init=inl b k ->
                    inl input, label = Struct.map' (inl x -> x b) ins
                    inl prob = softmax_body temp k (primal input)
                    inl label = k.block.load (primal label)
                    inl ret {map in} = 
                        on_non_nil <| inl to ->
                            k.block.store {
                                to from=k.block.map (inl {in out} -> out + map in) {in out=k.block.load to}
                                }
                    ret {in={prob label}; map=inl {prob label} -> (prob - label) / temp} (adjoint input)
                    ret {in=prob; map=inl prob -> -(log prob)} (adjoint label)
                }
        {out=cost; bck}

    inl accuracy label input s =
        inl input, label = primal input, primal label
        s.CudaFun.map_redo {
            map=inl {in} -> in
            neutral_elem=-infinity,zero
            redo=inl a b -> if fst a > fst b then a else b
            map_out=inl {out=_,x} -> to int64 x
            } (input,label)
        |> s.CudaFun.redo {
            neutral_elem=0; redo=(+)
            }
        |> inl x -> x 0

    inl Error = {square sigmoid_cross_entropy softmax_cross_entropy accuracy} |> stackify

    // #Initializer
    inl Initializer x dim = {$x=dim; block=()}
    inl rec initialize s x =
        inl init mult dim s =
            inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 dim))
            s.CudaRandom.create {dst=.Normal; stddev mean=0.0f32} {dim elem_type=float}

        // 2 ** -3 is a sensible default.
        // There is a relation between the epsilon parameter and the learning rate.
        // Tests on the poker game show that up to 2 ** -2, every 2x increase in epsilon also allows a 2x increase in the learning rate.
        // The networks can be trained with epsilons of 2 ** -10 and lower, but all that seems to do is make the network overfit 
        // and forces the learning rates to go low. Unlike on Mnist where overfitting lowers the test accuracy, on the poker game 
        // it lowers the winrate instead. High learning rates seem to be necessary for generalization.
        inl default_epsilon = to float (2.0 ** -3.0)

        inl covariance size =
            Struct.map (inl x -> 
                inl {epsilon size} =
                    match x with
                    | {size epsilon} -> x
                    | size -> {epsilon=default_epsilon; size}
                {
                covariance = Initializer.identity (size, size)
                precision = Initializer.identity (size, size)
                k = ref 0
                epsilon
                } |> initialize s
                ) size
            |> inl x -> {x with block=()}

        Struct.map (function // Rough and possibly poorly tuned inits. Recommended to be used together with PRONG or layer/batch norm.
            | {randn={dim stddev}} -> s.CudaRandom.create {dst=.Normal; stddev mean=0.0f32} {dim elem_type=float} |> dr s
            | {randn'={dim stddev}} -> s.CudaRandom.create {dst=.Normal; stddev mean=0.0f32} {dim elem_type=float}
            | {sigmoid=dim} -> init 2f32 dim s |> dr s
            | {tanh=dim} -> init 3f32 dim s |> dr s
            | {relu=dim} -> init 1f32 dim s |> dr s
            | {bias=dim} -> s.CudaTensor.zero {elem_type=float; dim} |> dr s
            | {zero=dim} -> s.CudaTensor.zero {elem_type=float; dim}
            | {dr=x} -> dr s (initialize s x)
            | {identity=dim} -> s.CudaFun.init {dim} (inl a, b -> if a = b then one else zero)
            | {reference=x} -> ref x
            | {constant={dim init}} -> s.CudaFun.init {dim} (const init) |> dr s
            | {prong={d with sublayer_size size}} -> 
                inl extra = match d with {extra} -> extra | _ -> {}

                { extra with
                front = {
                    covariance = Initializer.identity (sublayer_size, sublayer_size)
                    precision = Initializer.identity (sublayer_size, sublayer_size)
                    center = Initializer.zero sublayer_size
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
            | {covariance={dim}} -> covariance dim
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
            | {x with cell} -> {x with cell=initialize s self}
            | x -> x
            ) x

    inl prong_ff {d with sublayer_size size} = 
        Initializer.prong {d with 
            extra={
                input=
                    match d with
                    | {initializer} -> initializer (sublayer_size, size)
                    | _ -> Initializer.tanh (sublayer_size, size)
                bias=Initializer.bias size
                }
            }

    inl prong_rnn {d with sublayer_size size} = 
        Initializer.prong {d with 
            extra={
                input=
                    match d with
                    | {initializer} -> initializer (sublayer_size, size)
                    | _ -> Initializer.tanh (sublayer_size, size)
                bias=Initializer.constant {dim=size; init=one}
                }
            }

    inl init s size dsc = 
        Struct.foldl_map (inl sublayer_size {x with init} -> 
            inl {d with dsc size} = init sublayer_size
            inl weights = initialize s dsc |> heap
            match d with
            | {init_state} -> 
                inl init_state = initialize s init_state |> heap
                {x without init with init_state weights}, size
            | _ -> {x without init with weights}, size
            ) size dsc

    inl run s input = 
        Struct.foldl_map (inl input {layer with apply} -> 
            inl input = 
                inl input = {input}
                inl input = match layer with {weights} -> {input with weights} | _ -> input
                match layer with {state} | {init_state=state} -> {input with state} | _ -> input

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

    inl covariance_update cov x s =
        {
        out=()
        bck=met {learning_rate} ->
            Struct.iter2 (inl {epsilon covariance precision k} x ->
                update_covariance {identity_coef=epsilon; learning_rate} s covariance x
                k := k() + x.span_outer
                ) cov x
        }

    inl with_zero_adjoints x s =
        inl out = Struct.map (inl x -> {x with adjoint=s.CudaTensor.zero_like self}) x
        {
        out
        bck=met _ -> 
            inl x = Struct.map (inl {adjoint} -> adjoint) x
            inl out = Struct.map (inl {adjoint} -> adjoint) out
            s.CudaFun.map {out=x; map=inl a,b -> Struct.map2 (+) a b} (x,out)
        }

    met update_center {learning_rate} s center x =
        inl k = x.span_outer
        inl alpha = Math.pow (one - learning_rate) k
        inl beta = one - alpha
        s.CudaFun.redo_map {neutral_elem=zero; redo=(+); mid=center; out=center;
            map=inl {in} -> in
            map_out=inl {mid out} -> alpha * mid + beta / to float k * out 
            } x

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

    inl center in in_inner =
        broadcasting_activation {
            fwd=inl {in_inner in} -> in - in_inner
            bck={
                in=inl _ -> one
                in_inner=inl _ -> -one
                }
            } {in_inner in}

    inl natural_matmultb_template config x {weights with input} s =
        inl z = s.CudaBlas.gemm .nT .nT one (primal x) (primal input) |> dr s
        match weights with
        | {bias} -> fwd_add_bias (primal z) (primal bias) s
        | _ -> ()
        {
        out=z
        bck=inl {learning_rate} -> join
            inl k = weights.k
            inl is_update = k.dec (primal x).span_outer
            match config with
            | {mode=.optimize} -> if is_update then k.reset
            | {mode=.update} -> ()

            inb x_centered =
                match weights with
                | {front={center}} ret -> 
                    inl x = primal x
                    update_center {learning_rate} s center x
                    inb x = s.CudaFun.map_map {map=inl {in in_inner} -> in-in_inner} {in=x; in_inner=center} |> CudaAux.temporary
                    ret x
                | _ ret -> 
                    ret (primal x)

            inb x_precise_primal = 
                match weights with
                | {front={covariance precision epsilon}} ret -> 
                    inl x = x_centered
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
                match weights with
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

            s.CudaBlas.gemm' .T .nT one x_precise_primal z_precise_adjoint one (adjoint input)
            on_non_nil (s.CudaBlas.gemm' .nT .T one (adjoint z) (primal input) one) (adjoint x)
            match weights with
            | {bias} -> bck_add_bias z_precise_adjoint (adjoint bias) s
            | _ -> ()
        }

    inl natural_matmultb = natural_matmultb_template {front_mode=.prong; mode=.optimize}

    inl prong {w with activation size} = 
        {
        init = inl sublayer_size -> { size dsc = prong_ff {w with sublayer_size} }
        apply = inl {weights input} -> natural_matmultb input weights >>= activation
        optimize = inl {weights={input bias} learning_rate} s -> Tuple.iter (Optimizer.sgd learning_rate s) (input, bias)
        block = ()
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

    inl print x s =
        s.CudaTensor.print x
        {out=(); bck=()}
    
    inl zero_like x = 
        inl zero dim s = {out=s.CudaTensor.zero {elem_type=float; dim}; bck=()}
        zero (primal x .dim)

    // #Recurrent
    inl hebb {d with input out n} = 
        inm x = matmult ({T=input},out)
        match d with
        | {H} ->
            activation {
                fwd=inl {x H} -> n * x + (one - n) * H
                bck=inl {in={x H}} -> { x=n; H=one-n }
                } {x H}
        | _ ->
            activation {
                fwd=inl {x} -> n * x
                bck=inl {in={x}} -> { x=n }
                } {x}

    inl vanilla_hebb n size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                state = {
                    bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                    alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                    }
                input = {
                    bias = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                    alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                    }
                bias = Initializer.bias (1,size)
                }
            size
            }

        apply = inl {d with weights input} s -> 
            assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
            inl H =
                match d with
                | {state={H}} -> H
                | _ -> 
                    inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                    {input=f .input; state=f .state}

            inl out' =
                match d with
                | {state={out}} -> out
                | _ -> s.CudaTensor.zero_like (primal (weights .bias))

            inl apply =
                inm out =
                    inm input = 
                        inm W = hadmultb (weights.input.alpha, H.input) (weights.input.bias)
                        matmult (input, W)
                    inm state =
                        inm W = hadmultb (weights.state.alpha, H.state) (weights.state.bias)
                        matmult (out', W)
                    activation {
                        fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                        bck=inl {in out} ->
                            inl out = tanh_bck out
                            Struct.map (const out) in
                        } {input state bias=weights.bias}
                
                inm H =
                    inm input = hebb {input out n H=H.input}
                    inm state = hebb {input=out'; out n H=H.state}
                    succ {input state}
                
                succ {out state={out H}}
            inl {out={out state} bck} = apply s
            {out state bck}
        block = ()
        }

    inl generalized_mi =
        activation {
            fwd=inl {input state bias={si s i c}} -> si * state * input + s * state + i * input + c |> tanh_fwd
            bck=inl {in={input state bias={si s i c}} out} ->
                inl out = tanh_bck out
                {
                input = si * state + i
                state = si * input + s
                bias = { si = input*state; i = input; s = state; c = one } 
                } |> Struct.map ((*) out)
            }

    inl mi_hebb n size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                state = {
                    bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                    alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                    }
                input = {
                    bias = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                    alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                    }
                bias = {
                    si = Initializer.constant {dim=1,size; init=to float 1}
                    i = Initializer.constant {dim=1,size; init=to float 0.5}
                    s = Initializer.constant {dim=1,size; init=to float 0.5}
                    c = Initializer.bias (1,size)
                    }
                }
            size
            }

        apply = inl {d with weights input} s -> 
            assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
            inl H =
                match d with
                | {state={H}} -> H
                | _ -> 
                    inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                    {input=f .input; state=f .state}

            inl out' =
                match d with
                | {state={out}} -> out
                | _ -> s.CudaTensor.zero_like (primal (weights.bias.c))

            inl apply =
                inm out =
                    inm input = 
                        inm W = hadmultb (weights.input.alpha, H.input) (weights.input.bias)
                        matmult (input, W)
                    inm state =
                        inm W = hadmultb (weights.state.alpha, H.state) (weights.state.bias)
                        matmult (out', W)

                    generalized_mi {input state bias=weights.bias}
                
                inm H =
                    inm input = hebb {input out n H=H.input}
                    inm state = hebb {input=out'; out n H=H.state}
                    succ {input state}
                
                succ {out state={out H}}
            inl {out={out state} bck} = apply s
            {out state bck}
        block = ()
        }

    inl mi_hebb_prong n size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                weights = {
                    state = {
                        bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                        }
                    input = {
                        bias = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        }
                    bias = {
                        si = Initializer.constant {dim=1,size; init=to float 1}
                        i = Initializer.constant {dim=1,size; init=to float 0.5}
                        s = Initializer.constant {dim=1,size; init=to float 0.5}
                        c = Initializer.bias (1,size)
                        }
                    }
                covariance = {
                    state = Initializer.covariance {dim={front=size; back=size}} 
                    input = Initializer.covariance {dim={front=sublayer_size; back=size}}
                    bias = {
                        si = Initializer.covariance {dim={back=size}}
                        i = Initializer.covariance {dim={back=size}}
                        s = Initializer.covariance {dim={back=size}}
                        c = Initializer.covariance {dim={back=size}}
                        }
                    }
                }
            size
            }

        apply = inl {d with weights={weights covariance} input} s -> 
            assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
            inl H =
                match d with
                | {state={H}} -> H
                | _ -> 
                    inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                    {input=f .input; state=f .state}

            inl out' =
                match d with
                | {state={out}} -> out
                | _ -> s.CudaTensor.zero_like (primal (weights.bias.c))

            inl apply =
                inm _ = covariance_update covariance.input.front (primal input) // Does the updates on the backward pass.
                inm _ = covariance_update covariance.state.front (primal out')
                inm out =
                    inm input = 
                        inm W = hadmultb (weights.input.alpha, H.input) (weights.input.bias)
                        matmult (input, W)
                    inm _ = covariance_update covariance.input.back (adjoint input)
                    
                    inm state =
                        inm W = hadmultb (weights.state.alpha, H.state) (weights.state.bias)
                        matmult (out', W)
                    inm _ = covariance_update covariance.state.back (adjoint state)
                    
                    inm bias = with_zero_adjoints weights.bias
                    inm _ = covariance_update (Struct.map (inl {back} -> back) covariance.bias) (Struct.map (inl {adjoint} -> adjoint) bias)
                    generalized_mi {input state bias}

                inm H =
                    inm input = hebb {input out n H=H.input}
                    inm state = hebb {input=out'; out n H=H.state}
                    succ {input state}
                
                succ {out state={out H}}
            inl {out={out state} bck} = apply s
            {out state bck}
        optimize=inl {weights={weights covariance} learning_rate} s -> 
            Struct.iter2 (Optimizer.prong {learning_rate} s) covariance weights
        block = ()
        }

    inl mi_hebb'_prong n size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                weights = {
                    alpha = {
                        input = Initializer.constant {dim=1,1; init=zero}
                        state = Initializer.constant {dim=1,1; init=zero}
                        }
                    state = //Initializer.randn {stddev=0.01f32; dim=size, size} // Use this one for the Binary Pattern test.
                        Initializer.tanh (size, size)
                    input = //Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        Initializer.tanh (sublayer_size, size)
                    bias = {
                        si = Initializer.constant {dim=1,size; init=to float 1}
                        i = Initializer.constant {dim=1,size; init=to float 0.5}
                        s = Initializer.constant {dim=1,size; init=to float 0.5}
                        c = Initializer.bias (1,size)
                        }
                    }
                covariance = {
                    alpha = {
                        input = Initializer.covariance {dim={back=1}}
                        state = Initializer.covariance {dim={back=1}}
                        }
                    state = Initializer.covariance {dim={front=size; back=size}} 
                    input = Initializer.covariance {dim={front=sublayer_size; back=size}}
                    bias = {
                        si = Initializer.covariance {dim={back=size}}
                        i = Initializer.covariance {dim={back=size}}
                        s = Initializer.covariance {dim={back=size}}
                        c = Initializer.covariance {dim={back=size}}
                        }
                    }
                }
            size
            }

        apply = inl {d with weights={weights covariance} input} s -> 
            assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
            inl H =
                match d with
                | {state={H}} -> H
                | _ -> 
                    inl f k = s.CudaTensor.zero_like (primal (weights k))
                    {input=f .input; state=f .state}

            inl out' =
                match d with
                | {state={out}} -> out
                | _ -> s.CudaTensor.zero_like (primal (weights.bias.c))

            inl apply =
                inm _ = covariance_update covariance.input.front (primal input) // Does the updates on the backward pass.
                inm _ = covariance_update covariance.state.front (primal out')
                inm out =
                    inl weight_add {B H alpha} = 
                        broadcasting_activation {
                            fwd=inl {in={B H} in_scalar={alpha}} -> B + alpha * H
                            bck={
                                in=inl {in={B H} in_scalar={alpha}} -> {B = one; H = alpha }
                                in_scalar=inl {in={B H} in_scalar={alpha}} -> {alpha = H}
                                }
                            } {in={B H}; in_scalar={alpha}}

                    inm alpha = with_zero_adjoints weights.alpha
                    inm _ = covariance_update (Struct.map (inl {back} -> back) covariance.alpha) (Struct.map (inl {adjoint} -> adjoint) alpha)
                    inl flatten = Struct.map' (inl x -> x.flatten)
                    inm input = 
                        inm W = weight_add {alpha=flatten alpha.input; H=H.input; B=weights.input}
                        matmult (input, W)
                    inm _ = covariance_update covariance.input.back (adjoint input)
                    
                    inm state =
                        inm W = weight_add {alpha=flatten alpha.state; H=H.state; B=weights.state}
                        matmult (out', W)
                    inm _ = covariance_update covariance.state.back (adjoint state)
                    
                    inm bias = with_zero_adjoints weights.bias
                    inm _ = covariance_update (Struct.map (inl {back} -> back) covariance.bias) (Struct.map (inl {adjoint} -> adjoint) bias)
                    generalized_mi {input state bias}

                inm H =
                    inm input = hebb {input out n H=H.input}
                    inm state = hebb {input=out'; out n H=H.state}
                    succ {input state}
                
                succ {out state={out H}}
            inl {out={out state} bck} = apply s
            {out state bck}
        optimize=inl {weights={weights covariance} learning_rate} s -> 
            Struct.iter2 (Optimizer.prong {learning_rate} s) covariance weights
        block = ()
        }


    inl mi size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                input = {
                    bias = Initializer.bias size
                    weight = Initializer.tanh (sublayer_size, size)
                    }
                state = {
                    bias = Initializer.constant {dim=size; init=one}
                    weight = Initializer.tanh (size, size)
                    }
                }
            size
            }

        apply = inl {d with weights input} s -> 
            inl apply =
                inm right = matmultb (input, weights.input.weight) weights.input.bias
                inm out =
                    match d with
                    | {state} ->
                        inm left = matmultb (state, weights.state.weight) weights.state.bias
                        activation {
                            fwd=inl {left right} -> left * right |> tanh_fwd
                            bck=inl {in={left right} out} ->
                                inl out = tanh_bck out
                                {
                                left = out * right
                                right = out * left
                                }
                            } {left right}
                    | _ -> 
                        broadcasting_activation {
                            fwd=inl {in=right in_inner=left} -> left * right |> tanh_fwd
                            bck={
                                in=inl {in=right in_inner=left out} ->
                                    inl out = tanh_bck out
                                    out * left
                                in_inner=inl {in=right in_inner=left out} ->
                                    inl out = tanh_bck out
                                    out * right
                                }
                            }
                            { in=right; in_inner=weights.state.bias }
                succ {out state=out}
            inl {out={out state} bck} = apply s
            {out state bck}
        block = ()
        }

    inl mi_prong size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                input = prong_ff {sublayer_size size}
                state = prong_rnn {sublayer_size=size; size}
                }
            size
            }

        apply = inl {d with weights input} s -> 
            inl apply =
                inm right = natural_matmultb input weights.input
                inm left =
                    inm state =
                        match d with
                        | {state} -> succ state
                        | _ -> zero_like right
                    natural_matmultb state weights.state
                activation {
                    fwd=inl {left right} -> left * right |> tanh_fwd
                    bck=inl {in={left right} out} ->
                        inl out = tanh_bck out
                        {
                        left = out * right
                        right = out * left
                        }
                    } {left right}
                >>= inl out -> succ {out state=out}
            inl {out={out state} bck} = apply s
            {out state bck}
        optimize=inl {weights={input state} learning_rate} s -> 
            Tuple.iter (inl {input bias} ->
                Tuple.iter (Optimizer.sgd learning_rate s) (input, bias)
                ) (input,state)
        block = ()
        }

    inl mi_prong_alt size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                weights = {
                    state = Initializer.tanh (size, size)
                    input = Initializer.tanh (sublayer_size, size)
                    bias = {
                        si = Initializer.constant {dim=1,size; init=to float 1}
                        i = Initializer.constant {dim=1,size; init=to float 0.5}
                        s = Initializer.constant {dim=1,size; init=to float 0.5}
                        c = Initializer.bias (1,size)
                        }
                    }
                covariance = {
                    state = Initializer.covariance {dim={front=size; back=size}} 
                    input = Initializer.covariance {dim={front=sublayer_size; back=size}}
                    bias = {
                        si = Initializer.covariance {dim={back=size}}
                        i = Initializer.covariance {dim={back=size}}
                        s = Initializer.covariance {dim={back=size}}
                        c = Initializer.covariance {dim={back=size}}
                        }
                    }
                }
            size
            }

        apply = inl {d with weights={weights covariance} input} s -> 
            assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
            inl out' =
                match d with
                | {state={out}} -> out
                | _ -> s.CudaTensor.zero_like (primal (weights.bias.c))

            inl apply =
                inm _ = covariance_update covariance.input.front (primal input) // Does the updates on the backward pass.
                inm _ = covariance_update covariance.state.front (primal out')
                inm out =
                    inm input = matmult (input, weights.input)
                    inm _ = covariance_update covariance.input.back (adjoint input)
                    
                    inm state = matmult (out', weights.state)
                    inm _ = covariance_update covariance.state.back (adjoint state)
                    
                    inm bias = with_zero_adjoints weights.bias
                    inm _ = covariance_update (Struct.map (inl {back} -> back) covariance.bias) (Struct.map (inl {adjoint} -> adjoint) bias)
                    inm out = generalized_mi {input state bias}
                    succ out

                succ {out state={out}}
            inl {out={out state} bck} = apply s
            {out state bck}
        optimize=inl {weights={weights covariance} learning_rate} s -> 
            Struct.iter2 (Optimizer.prong {learning_rate} s) covariance weights
        block = ()
        }

    inl mi_alt size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                state = Initializer.tanh (size, size)
                input = Initializer.tanh (sublayer_size, size)
                bias = {
                    si = Initializer.constant {dim=1,size; init=to float 1}
                    i = Initializer.constant {dim=1,size; init=to float 0.5}
                    s = Initializer.constant {dim=1,size; init=to float 0.5}
                    c = Initializer.bias (1,size)
                    }
                }
            size
            }

        apply = inl {d with weights input} s -> 
            assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
            inl out' =
                match d with
                | {state={out}} -> out
                | _ -> s.CudaTensor.zero_like (primal (weights.bias.c))

            inl apply =
                inm out =
                    inm input = matmult (input, weights.input)
                    inm state = matmult (out', weights.state)
                    
                    inl bias = weights.bias
                    inm out = generalized_mi {input state bias}
                    succ out

                succ {out state={out}}
            inl {out={out state} bck} = apply s
            {out state bck}
        block = ()
        }

    inl mi_hebb n size =
        {
        init = inl sublayer_size -> 
            {
            dsc = 
                {
                state = {
                    bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                    alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                    }
                input = {
                    bias = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                    alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                    }
                bias = {
                    si = Initializer.constant {dim=1,size; init=to float 1}
                    i = Initializer.constant {dim=1,size; init=to float 0.5}
                    s = Initializer.constant {dim=1,size; init=to float 0.5}
                    c = Initializer.bias (1,size)
                    }
                }
            size
            }

        apply = inl {d with weights input} s -> 
            assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
            inl H =
                match d with
                | {state={H}} -> H
                | _ -> 
                    inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                    {input=f .input; state=f .state}

            inl out' =
                match d with
                | {state={out}} -> out
                | _ -> s.CudaTensor.zero_like (primal (weights.bias.c))

            inl apply =
                inm out =
                    inm input = 
                        inm W = hadmultb (weights.input.alpha, H.input) (weights.input.bias)
                        matmult (input, W)
                    inm state =
                        inm W = hadmultb (weights.state.alpha, H.state) (weights.state.bias)
                        matmult (out', W)

                    generalized_mi {input state bias=weights.bias}
                
                inm H =
                    inm input = hebb {input out n H=H.input}
                    inm state = hebb {input=out'; out n H=H.state}
                    succ {input state}
                
                succ {out state={out H}}
            inl {out={out state} bck} = apply s
            {out state bck}
        block = ()
        }

    inl hebb_template {output_functions index_into fwd bck dim} ins s =
        inl out =
            inl ins = to_dev_tensor (primals ins)
            s.CudaFun.init {dim} (inl dim ->
                index_into dim ins 
                |> Struct.map (inl x -> x .get)
                |> fwd
                )
            |> dr s
        {
        out
        bck=met _ ->
            inl ins = to_dev_tensor ins
            inl error = to_dev_tensor (adjoint out)
            s.CudaKernel.iter {dim} (inl dim ->
                    inl ads =
                        index_into dim (primals ins) 
                        |> Struct.map (inl x -> x .get)
                        |> bck
                    inl error = error dim .get
                    inl ins = 
                        inl a = Struct.choose id (adjoints ins)
                        inl b = index_into dim a
                        Struct.map2 (inl a b -> b) a b // This is to get rid of the `n` in a safe way.
                    
                    Struct.iter3 (inl in b f -> f in (error * b ())) ins ads output_functions
                )
        }

    inl concat x s =
        inl span_inner x = x.dim |> inl b,a -> HostTensor.span a
        inl {dim elem_type} = 
            Struct.foldl (inl s x ->
                match s with
                | () -> {dim=x.dim; elem_type=x.elem_type}
                | {dim=b, {from=0 near_to=a}} ->
                    inl b', {from=0 near_to=a'} = x.dim
                    assert (b = b') "The outer dimensions of the inputs must be the same."
                    {s with dim=b,a+a'}
                ) () (primals x)

        inl out = s.CudaTensor.create {elem_type dim} |> dr s
        inl _ =
            inl x, out = to_dev_tensor (primals (x, out))
            s.CudaKernel.iter {dim} (inl b,a ->
                Struct.foldl (inl s x ->
                    inl s' = s + span_inner x
                    if s <= a && a < s' then 
                        out b a .set (x b (a - s) .get)
                    else ()
                    s'
                    ) 0  x
                |> ignore
                )
        {
        out
        bck=met _ ->
            inl dims_adjoints = Struct.map (function
                | {primal adjoint} -> {dim=primal.dim; adjoint=to_dev_tensor adjoint; block=()}
                | primal -> {dim=primal.dim; block=()}
                )
            inl x, out = dims_adjoints (x, out)
            s.CudaKernel.iter {dim} (inl b,a ->
                Struct.foldl (inl s x ->
                    inl s' = s + span_inner x
                    match x with
                    | {adjoint=x} ->
                        if s <= a && a < s' then 
                            inl x = x b (a - s)
                            x .set (x .get + out.adjoint b a .get)
                        else ()
                    | _ -> ()
                    s'
                    ) 0  x
                |> ignore
                )
        }

    inl Modulated = // This is experimental for now.
        inl modulated_oja_update {ins with input out n H} =
            inl b,a as dim = primal H .dim
            inl assert_dim = assert_dim (primals ins)
            inl sng = {from=0; near_to=1}
            assert_dim .input (sng, b)
            assert_dim .out (sng, a)
            assert_dim .n (sng)

            inl output_functions =
                inl add a b = a.set (a.get + b)
                {
                input=atomic_add
                out=atomic_add
                n=atomic_add
                H=add
                }
            inl index_into (b,a) x = 
                Struct.map2 (<|) (Struct.choose id x)                 
                    {
                    input = 0, b
                    out = 0, a
                    n = 0
                    H = b, a
                    } 
            inl tanh = tanh_fwd
            inl abs_bck x = if x >= zero then one else -one

            //inl fwd {input out n H} =
            //    H + n * input * out - abs n * out * out * H
            //inl bck {input out n H} =
            //    { 
            //    input = inl _ -> n * out
            //    out = inl _ -> n * input - abs n * two * out * H
            //    H = inl _ -> one - abs n * out * out
            //    n = inl _ -> input * out - abs_bck n * out * out * H
            //    }
            inl fwd {input out n H} =
                H + n * (input * out - out * out * H)
            inl bck {input out n H} =
                { 
                input = inl _ -> n * out
                out = inl _ -> n * input - two * out * H
                H = inl _ -> one - out * out
                n = inl _ -> input * out
                }
            hebb_template {output_functions index_into fwd bck dim} ins

        inl oja_update n {ins with input out H} =
            inl b,a as dim = primal H .dim
            inl span_inner = HostTensor.span a |> to float
            inl assert_dim = assert_dim (primals ins)
            inl sng = {from=0; near_to=1}
            assert_dim .input (sng, b)
            assert_dim .out (sng, a)

            inl output_functions =
                inl add a b = a.set (a.get + b)
                {
                input=atomic_add
                out=atomic_add
                H=add
                }
            inl index_into (b,a) x = 
                inl n =
                    match n with
                    | {from near_to} _ -> from + (near_to - from) / (span_inner + one) * (to float a + one)
                    | _ _ -> n
                Struct.map2 (<|) (Struct.choose id x)
                    {
                    input = 0, b
                    out = 0, a
                    H = b, a
                    } 
                |> inl x -> {x with n}
            inl tanh = tanh_fwd
            inl abs_bck x = if x >= zero then one else -one

            inl fwd {n input out H} =
                H + n * (input * out - out * out * H)
            inl bck {n input out H} =
                { 
                input = inl _ -> n * out
                out = inl _ -> n * (input - two * out * H)
                H = inl _ -> one - n * out * out
                }
            hebb_template {output_functions index_into fwd bck dim} ins



        inl unmodulated_feedforward size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    input = Initializer.randn {dim=sublayer_size, size; stddev=0.01f32}
                    bias = Initializer.bias size
                    }
                size
                }

            apply = inl {weights input} -> matmultb (input, weights.input) weights.bias >>= Activation.tanh
            block = ()
            }

        inl feedforward n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    input = 
                        {
                        bias = Initializer.bias size
                        }
                    modulator = 
                        {
                        weight = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        bias = Initializer.bias size
                        }
                    }
                init_state =
                    {
                    H = Initializer.randn' {stddev=0.01f32; dim=sublayer_size, size}
                    }
                size
                }
            apply = inl {d with state={H} weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."

                inl apply =
                    inm out = matmultb (input, H) weights.input.bias >>= tanh
                    inm m = matmultb (input, weights.modulator.weight) weights.modulator.bias
                    inm H = modulated_oja_update n {input out m H}
                
                    succ {out state={H}}
                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl rnn n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    input = 
                        {
                        bias = Initializer.bias size
                        }
                    modulator = 
                        {
                        input =
                            {
                            weight = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                            bias = Initializer.bias size
                            }
                        state =
                            {
                            weight = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                            bias = Initializer.bias size
                            }
                        }
                    }
                init_state =
                    {
                    H = {
                        input = Initializer.randn' {stddev=0.01f32; dim=sublayer_size, size}
                        state = Initializer.randn' {stddev=0.01f32; dim=size, size}
                        }
                    state = Initializer.zero (1,size)
                    }
                size
                }
            apply = inl {d with state={H state} weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."

                inl apply =
                    inm out = matmultb ((state, H.state), (input, H.input)) weights.input.bias >>= tanh
                    
                    inm H = 
                        inl f k =
                            inl input = {state input} k
                            inm m = matmultb (input, weights .modulator k .weight) (weights .modulator k .bias)
                            modulated_oja_update n {input out m H=H k}
                        inm state = f .state
                        inm input = f .input
                        succ {state input}
                
                    succ {out state={H state=out}}
                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl unmodulated_concatenative_vanilla_oja n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = {
                        bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                        }
                    input = {
                        bias = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        }
                    bias = Initializer.bias (1,size)
                    }
                size=sublayer_size+size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                        {input=f .input; state=f .state}

                inl out' =
                    match d with
                    | {state={out}} -> out
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inm out =
                        inm input = 
                            inm W = hadmultb (weights.input.alpha, H.input) (weights.input.bias)
                            matmult (input, W)
                        inm state =
                            inm W = hadmultb (weights.state.alpha, H.state) (weights.state.bias)
                            matmult (out', W)
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}
                    
                    inm H =
                        inm input = oja_update n {input out H=H.input}
                        inm state = oja_update n {input=out'; out H=H.state}
                        succ {input state}
                    
                    inm out' = concat (out,input)
                    succ {out=out'; state={out H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl unmodulated_vanilla_oja n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = {
                        bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                        }
                    input = {
                        bias = //Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                            Initializer.dr (Initializer.identity (sublayer_size,size))
                        alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        }
                    bias = Initializer.bias (1,size)
                    }
                size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                        {input=f .input; state=f .state}

                inl out' =
                    match d with
                    | {state={out}} -> out
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inm out =
                        inm input = 
                            inm W = hadmultb (weights.input.alpha, H.input) (weights.input.bias)
                            matmult (input, W)
                        inm state =
                            inm W = hadmultb (weights.state.alpha, H.state) (weights.state.bias)
                            matmult (out', W)
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}
                
                    inm H =
                        inm input = oja_update n {input out H=H.input}
                        inm state = oja_update n {input=out'; out H=H.state}
                        succ {input state}

                    succ {out state={out H}}
                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl vanilla_oja n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = {
                        bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                        }
                    input = {
                        bias = //Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                            Initializer.dr (Initializer.identity (sublayer_size, size))
                        alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        }
                    modulator = {
                        input = {
                            weight = Initializer.randn {stddev=0.01f32; dim=sublayer_size+size, size}
                            bias = Initializer.constant {dim=size; init=one}
                            }
                        state = {
                            weight = Initializer.randn {stddev=0.01f32; dim=sublayer_size+size, size}
                            bias = Initializer.constant {dim=size; init=one}
                            }
                        }
                    bias = Initializer.bias (1,size)
                    }
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                        {input=f .input; state=f .state}

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inm out =
                        inl f k =
                            inm W = hadmultb (weights k .alpha, H k) (weights k .bias)
                            matmult ({input state} k, W)
                        inm input = f.input
                        inm state = f.state
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}
                    
                    inm H =
                        inm input' = concat (state,input)
                        inl f k =
                            inm m = matmultb (input', weights.modulator k .weight) (weights.modulator k .bias) >>= tanh
                            modulated_oja_update n {m input={input state} k; out H=H k}
                        inm input = f.input
                        inm state = f.state
                        succ {input state}
                    
                    succ {out state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl concatenative_vanilla_oja n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = {
                        bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=size, size}
                        }
                    input = {
                        bias = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        alpha = Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                        }
                    modulator = {
                        input = {
                            weight = Initializer.randn {stddev=0.01f32; dim=sublayer_size+size, size}
                            bias = Initializer.bias size
                            }
                        state = {
                            weight = Initializer.randn {stddev=0.01f32; dim=sublayer_size+size, size}
                            bias = Initializer.bias size
                            }
                        }
                    bias = Initializer.bias (1,size)
                    }
                size=sublayer_size+size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                        {input=f .input; state=f .state}

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inm out =
                        inl f k =
                            inm W = hadmultb (weights k .alpha, H k) (weights k .bias)
                            matmult ({input state} k, W)
                        inm input = f.input
                        inm state = f.state
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}
                    
                    inm H =
                        inm input' = concat (state,input)
                        inl f k =
                            inm m = matmultb (input', weights.modulator k .weight) (weights.modulator k .bias) >>= tanh
                            modulated_oja_update n {m input={input state} k; out H=H k}
                        inm input = f.input
                        inm state = f.state
                        succ {input state}
                    
                    inm out' = concat (out,input)
                    succ {out=out'; state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl semimodulated_vanilla_oja n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = {
                        bias = Initializer.randn {stddev=0.01f32; dim=size, size}
                        }
                    input = {
                        bias = //Initializer.randn {stddev=0.01f32; dim=sublayer_size, size}
                            Initializer.dr (Initializer.identity (sublayer_size, size))
                        }
                    modulator = {
                        input = {
                            weight = Initializer.bias (sublayer_size+size, size)
                            bias = Initializer.bias size
                            }
                        state = {
                            weight = Initializer.bias (sublayer_size+size, size)
                            bias = Initializer.bias size
                            }
                        }
                    bias = Initializer.bias (1,size)
                    }
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k .bias))
                        {input=f .input; state=f .state}

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inm out =
                        inm input' = concat (state,input)
                        inl calculate k =
                            inm alpha = matmultb (input', weights.modulator k .weight) (weights.modulator k .bias)
                            inm static = matmult ({input state} k, weights k .bias)
                            inm plastic = matmult ({input state} k, H k)
                            broadcasting_activation {
                                fwd=inl {in={static plastic} in_inner={alpha}} -> static + alpha * plastic
                                bck={
                                    in=inl {in={static plastic} in_inner={alpha}} -> { static = one; plastic = alpha }
                                    in_inner=inl {in={static plastic} in_inner={alpha}} -> { alpha = plastic }
                                    }
                                } {in={static plastic}; in_inner={alpha=Struct.map' (inl x -> x.flatten) alpha}}

                        inm input = calculate .input
                        inm state = calculate .state
                    
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}

                    inm H =
                        inl oja_update k = oja_update n {input={input state} k; out H=H k}
                        inm input = oja_update .input
                        inm state = oja_update .state
                        succ {input state}

                    succ {out state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl semimodulated_vanilla_oja_alt n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = Initializer.randn {stddev=0.01f32; dim=size, size}
                    input = Initializer.dr (Initializer.identity (sublayer_size, size))
                    modulator = {
                        input = {
                            input = Initializer.bias (sublayer_size, size)
                            state = Initializer.bias (size, size)
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        state = {
                            input = Initializer.bias (sublayer_size, size)
                            state = Initializer.bias (size, size)
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        }
                    bias = Initializer.bias (1,size)
                    }
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k))
                        {input=f .input; state=f .state}

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inm out =
                        inl calculate k =
                            inm alpha = 
                                inl modulator = weights.modulator k
                                inm input = matmult (input, modulator.input)
                                inm state = matmult (state, modulator.state)
                                generalized_mi {modulator with input state}
                            inm static = matmult ({input state} k, weights k)
                            inm plastic = matmult ({input state} k, H k)
                            broadcasting_activation {
                                fwd=inl {in={static plastic} in_inner={alpha}} -> static + alpha * plastic
                                bck={
                                    in=inl {in={static plastic} in_inner={alpha}} -> { static = one; plastic = alpha }
                                    in_inner=inl {in={static plastic} in_inner={alpha}} -> { alpha = plastic }
                                    }
                                } {in={static plastic}; in_inner={alpha=Struct.map' (inl x -> x.flatten) alpha}}

                        inm input = calculate .input
                        inm state = calculate .state
                    
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}

                    inm H =
                        inl oja_update k = oja_update n {input={input state} k; out H=H k}
                        inm input = oja_update .input
                        inm state = oja_update .state
                        succ {input state}

                    succ {out state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl semimodulated_mi_oja n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = Initializer.randn {stddev=0.003f32; dim=size, size}
                    input = Initializer.dr (Initializer.identity (sublayer_size, size))
                    modulator = {
                        input = {
                            input = Initializer.bias (sublayer_size, size)
                            state = Initializer.bias (size, size)
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        state = {
                            input = Initializer.bias (sublayer_size, size)
                            state = Initializer.bias (size, size)
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        }
                    bias = {
                        si = Initializer.constant {dim=1,size; init=to float 1}
                        i = Initializer.constant {dim=1,size; init=to float 0.5}
                        s = Initializer.constant {dim=1,size; init=to float 0.5}
                        c = Initializer.bias (1,size)
                        }
                    }
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k))
                        {input=f .input; state=f .state}

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias .c))

                inl apply =
                    inm out =
                        inl calculate k =
                            inm alpha = 
                                inl modulator = weights.modulator k
                                inm input = matmult (input, modulator.input)
                                inm state = matmult (state, modulator.state)
                                generalized_mi {modulator with input state}
                            inm static = matmult ({input state} k, weights k)
                            inm plastic = matmult ({input state} k, H k)
                            broadcasting_activation {
                                fwd=inl {in={static plastic} in_inner={alpha}} -> static + alpha * plastic
                                bck={
                                    in=inl {in={static plastic} in_inner={alpha}} -> { static = one; plastic = alpha }
                                    in_inner=inl {in={static plastic} in_inner={alpha}} -> { alpha = plastic }
                                    }
                                } {in={static plastic}; in_inner={alpha=Struct.map' (inl x -> x.flatten) alpha}}

                        inm input = calculate .input
                        inm state = calculate .state
                        generalized_mi {input state bias=weights.bias}

                    inm H =
                        inl oja_update k = oja_update n {input={input state} k; out H=H k}
                        inm input = oja_update .input
                        inm state = oja_update .state
                        succ {input state}

                    succ {out state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl modulated_rnn size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = Initializer.randn {stddev=0.01f32; dim=size, size}
                    input = Initializer.dr (Initializer.identity (sublayer_size, size))
                    modulator = {
                        input = {
                            input = Initializer.randn {stddev=0.001f32; dim=sublayer_size, size}
                            state = Initializer.randn {stddev=0.001f32; dim=size, size}
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        state = {
                            input = Initializer.randn {stddev=0.001f32; dim=sublayer_size, size}
                            state = Initializer.randn {stddev=0.001f32; dim=size, size}
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        }
                    n = {
                        input = {
                            input = Initializer.randn {stddev=0.001f32; dim=sublayer_size, size}
                            state = Initializer.randn {stddev=0.001f32; dim=size, size}
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.constant {dim=1; init=to float 0.01}
                                }
                            }
                        state = {
                            input = Initializer.randn {stddev=0.001f32; dim=sublayer_size, size}
                            state = Initializer.randn {stddev=0.001f32; dim=size, size}
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.constant {dim=1; init=to float 0.01}
                                }
                            }
                        }
                    bias = Initializer.bias (1,size)
                    }
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k))
                        {input=f .input; state=f .state}

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inm out =
                        inl calculate k =
                            inm alpha = 
                                inl modulator = weights.modulator k
                                inm input = matmult (input, modulator.input)
                                inm state = matmult (state, modulator.state)
                                generalized_mi {modulator with input state}
                            inm static = matmult ({input state} k, weights k)
                            inm plastic = matmult ({input state} k, H k)
                            broadcasting_activation {
                                fwd=inl {in={static plastic} in_inner={alpha}} -> static + alpha * plastic
                                bck={
                                    in=inl {in={static plastic} in_inner={alpha}} -> { static = one; plastic = alpha }
                                    in_inner=inl {in={static plastic} in_inner={alpha}} -> { alpha = plastic }
                                    }
                                } {in={static plastic}; in_inner={alpha=Struct.map' (inl x -> x.flatten) alpha}}

                        inm input = calculate .input
                        inm state = calculate .state
                    
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}

                    inm H =
                        inl oja_update k = 
                            inl n = weights .n k .bias .c
                            modulated_oja_update {n input={input state} k; out H=H k}
                        inm input = oja_update .input
                        inm state = oja_update .state
                        succ {input state}

                    succ {out state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl semimodulated_vanilla_oja_alt2 n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    {
                    state = Initializer.randn {stddev=0.01f32; dim=size, size}
                    input = Initializer.dr (Initializer.identity (sublayer_size, size))
                    modulator = {
                        input = {
                            input = Initializer.bias (sublayer_size, size)
                            state = Initializer.bias (size, size)
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        state = {
                            input = Initializer.bias (sublayer_size, size)
                            state = Initializer.bias (size, size)
                            bias = {
                                si = Initializer.constant {dim=1,size; init=to float 1}
                                i = Initializer.constant {dim=1,size; init=to float 0.5}
                                s = Initializer.constant {dim=1,size; init=to float 0.5}
                                c = Initializer.bias (1,size)
                                }
                            }
                        }
                    bias = Initializer.bias (1,size)
                    }
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        inl f k = s.CudaTensor.zero_like (primal (weights k))
                        {input=f .input; state=f .state}

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero_like (primal (weights .bias))

                inl apply =
                    inl calculate k =
                        inm alpha = 
                            inl modulator = weights.modulator k
                            inm input = matmult (input, modulator.input)
                            inm state = matmult (state, modulator.state)
                            generalized_mi {modulator with input state}
                        inm static = matmult ({input state} k, weights k)
                        inm plastic = matmult ({input state} k, H k)
                        broadcasting_activation {
                            fwd=inl {in={static plastic} in_inner={alpha}} -> static + alpha * plastic
                            bck={
                                in=inl {in={static plastic} in_inner={alpha}} -> { static = one; plastic = alpha }
                                in_inner=inl {in={static plastic} in_inner={alpha}} -> { alpha = plastic }
                                }
                            } {in={static plastic}; in_inner={alpha=Struct.map' (inl x -> x.flatten) alpha}}

                    inm input = calculate .input
                    inm state = calculate .state
                    inm out =
                        activation {
                            fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in |> tanh_fwd
                            bck=inl {in out} ->
                                inl out = tanh_bck out
                                Struct.map (const out) in
                            } {input state bias=weights.bias}

                    inm H =
                        inl oja_update k = oja_update n {input={input state} k; out H=H k}
                        inm input = oja_update .input
                        inm state = oja_update .state
                        succ {input state}

                    succ {out state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl sequence x s =
            inl x = Struct.map (inl x -> x s |> inl x -> {x with block=()}) x
            {
            out = Struct.map (inl {out} -> out) x
            bck = Struct.map (inl {bck} -> bck) x
            }

        inl attend =
            activation {
                fwd=
                    Liple.foldl (inl s {factor out} ->
                        inl out = Struct.foldl (+) zero out
                        s + factor * out
                        ) zero
                    >> tanh_fwd
                bck=inl {in out} ->
                    Liple.map (inl {factor out} ->
                        {
                        factor=Struct.foldl (+) zero out
                        out=Struct.map (const factor) out
                        }
                        ) in
                    |> Struct.map ((*) (tanh_bck out))
                }

        inl multiscale_v1 (!dyn n) size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    inl modulator _ = {
                        input = Initializer.bias (sublayer_size, size)
                        state = Initializer.bias (size, size)
                        bias = {
                            si = Initializer.constant {dim=1,size; init=to float 1}
                            i = Initializer.constant {dim=1,size; init=to float 0.5}
                            s = Initializer.constant {dim=1,size; init=to float 0.5}
                            c = Initializer.bias (1,size)
                            }
                        }

                    inl cell _ =
                        {
                        input = Initializer.dr (Initializer.identity (sublayer_size, size))
                        state = Initializer.randn {stddev=0.01f32; dim=size, size}
                        modulator = 
                            {
                            input = modulator()
                            state = modulator()
                            }
                        bias = Initializer.bias (1,size)
                        factor = Initializer.constant {dim=1,size; init=to float 1}
                        }

                    Struct.map (inl _ -> {cell=cell(); block=()}) n
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        Struct.map (inl {cell=weights} ->
                            inl f k = s.CudaTensor.zero_like (primal (weights k))
                            {input=f .input; state=f .state}
                            ) weights

                inl state =
                    match d with
                    | {state={state}} -> state
                    | _ -> s.CudaTensor.zero {elem_type=float; dim=1,size}

                inl apply =
                    inm cell_results =
                        Struct.map3 (inl {cell=weights} H n ->
                            inm out =
                                inl calculate k =
                                    inm alpha = 
                                        inl modulator = weights.modulator k
                                        inm input = matmult (input, modulator.input)
                                        inm state = matmult (state, modulator.state)
                                        generalized_mi {modulator with input state}
                                    inm static = matmult ({input state} k, weights k)
                                    inm plastic = matmult ({input state} k, H k)
                                    broadcasting_activation {
                                        fwd=inl {in={static plastic} in_inner={alpha}} -> static + alpha * plastic
                                        bck={
                                            in=inl {in={static plastic} in_inner={alpha}} -> { static = one; plastic = alpha }
                                            in_inner=inl {in={static plastic} in_inner={alpha}} -> { alpha = plastic }
                                            }
                                        } {in={static plastic}; in_inner={alpha=Struct.map' (inl x -> x.flatten) alpha}}

                                inm input = calculate .input
                                inm state = calculate .state
                    
                                activation {
                                    fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in //|> tanh_fwd
                                    bck=inl {in out} ->
                                        Struct.map (const one) in
                                        //inl out = tanh_bck out
                                        //Struct.map (const out) in
                                    } {input state bias=weights.bias}

                            succ {out block=()}
                            ) weights H n
                        |> sequence

                    inm out = 
                        Struct.map2 (inl {cell={factor}} {out} -> {factor out}) weights cell_results
                        |> attend

                    inm H =
                        Struct.map2 (inl H n ->
                            inl oja_update k = oja_update n {input={input state} k; out H=H k}
                            inm input = oja_update .input
                            inm state = oja_update .state
                            succ {input state}
                            ) H n
                        |> sequence
                    
                    succ {out state={state=out; H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        inl plastic_lstm n size =
            {
            init = inl sublayer_size -> 
                {
                dsc = 
                    inl modulator _ = {
                        input = Initializer.bias (sublayer_size, size)
                        state = Initializer.bias (size, size)
                        bias = {
                            si = Initializer.constant {dim=1,size; init=to float 1}
                            i = Initializer.constant {dim=1,size; init=to float 0.5}
                            s = Initializer.constant {dim=1,size; init=to float 0.5}
                            c = Initializer.bias (1,size)
                            }
                        }

                    inl cell _ =
                        {
                        input = Initializer.dr (Initializer.identity (sublayer_size, size))
                        state = Initializer.randn {stddev=0.01f32; dim=size, size}
                        modulator = 
                            {
                            input = modulator()
                            state = modulator()
                            }
                        bias = Initializer.bias (1,size)
                        }

                    {
                    input=cell()
                    output=cell()
                    forget=cell()
                    memory=cell()
                    }
                size=size
                }

            apply = inl {d with weights input} s -> 
                assert (primal input .span_outer = 1) "The differentiable plasticity layer supports only online learning for now."
                inl H =
                    match d with
                    | {state={H}} -> H
                    | _ -> 
                        Struct.map (inl {cell=weights} ->
                            inl f k = s.CudaTensor.zero_like (primal (weights k))
                            {input=f .input; state=f .state}
                            ) weights

                inl {state memory} =
                    match d with
                    | {state={state memory}} -> {state memory}
                    | _ -> 
                        inl f _ = s.CudaTensor.zero {elem_type=float; dim=1,size}
                        { state=f(); memory=f() }

                inl apply =
                    inm {out memory} =
                        Struct.map2 (inl {cell=weights} H ->
                            inm out =
                                inl calculate k =
                                    inm alpha = 
                                        inl modulator = weights.modulator k
                                        inm input = matmult (input, modulator.input)
                                        inm state = matmult (state, modulator.state)
                                        generalized_mi {modulator with input state}
                                    inm static = matmult ({input state} k, weights k)
                                    inm plastic = matmult ({input state} k, H k)
                                    broadcasting_activation {
                                        fwd=inl {in={static plastic} in_inner={alpha}} -> static + alpha * plastic
                                        bck={
                                            in=inl {in={static plastic} in_inner={alpha}} -> { static = one; plastic = alpha }
                                            in_inner=inl {in={static plastic} in_inner={alpha}} -> { alpha = plastic }
                                            }
                                        } {in={static plastic}; in_inner={alpha=Struct.map' (inl x -> x.flatten) alpha}}

                                inm input = calculate .input
                                inm state = calculate .state
                    
                                activation {
                                    fwd=inl in -> Struct.foldl (inl s x -> s + x) zero in
                                    bck=inl {in out} -> Struct.map (const one) in
                                    } {input state bias=weights.bias}

                            succ {out block=()}
                            ) weights H
                        |> sequence
                        >>= lstm_activation memory

                    inm H =
                        Struct.map (inl H ->
                            inl oja_update k = oja_update n {input={input state} k; out H=H k}
                            inm input = oja_update .input
                            inm state = oja_update .state
                            succ {input state}
                            ) H
                        |> sequence
                    
                    succ {out state={state=out; memory H}}

                inl {out={out state} bck} = apply s
                {out state bck}
            block = ()
            }

        {
        unmodulated_feedforward feedforward rnn unmodulated_vanilla_oja unmodulated_concatenative_vanilla_oja concatenative_vanilla_oja
        vanilla_oja semimodulated_vanilla_oja semimodulated_vanilla_oja_alt semimodulated_mi_oja modulated_rnn semimodulated_vanilla_oja_alt2
        multiscale_v1 plastic_lstm
        }

    inl RNN = {mi mi_hebb mi_hebb_prong mi_hebb'_prong vanilla_hebb mi_prong mi_prong_alt mi_alt Modulated}

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

                { value bck = inl _ -> on_non_nil (inl out -> s.CudaFun.map {out map=inl {value out} -> out - two * value} {value out}) (adjoint v) }

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
                s.CudaKernel.iter2 {dim=dim_a, dim_b} <| inl j ->
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
            inl mc (!default {w with !size}) = prong {w with size=1}
                //prong_template {front_mode=.prong; mode=.update} {w with size=1}

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
