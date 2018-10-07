[<AutoOpen>]
module Learning.Lib

open Spiral.Types
open Spiral.Lib
open Cuda.Lib

let cuda_ad =
    (
    "CudaAD",[struct';liple],"The CudaAD module",
    """
inl zero = 0f32
inl half = 0.5f32
inl one = 1f32
inl two = 2f32

inl (>>=) a b =
    inl {out=a bck=bck_a} = a
    inl {out=b bck=bck_b} = b a
    {out=b; bck=bck_a,bck_b}

inl succ out = {out bck=const ()}

inl dr x =
    {
    primal=x
    adjoint=
        inl x = array_create_cuda_local x 1
        x 0 <- zero
        x
    block=()
    }

inl set_adjoint x out =
    match x with
    | {adjoint} -> adjoint 0 <- out ()
    | _ -> ()

inl get_adjoint {adjoint} = adjoint 0

inl primal = Struct.map (inl {primal} | primal -> primal)

inl sigmoid_fwd x = one / (one + exp -x)
inl sigmoid_bck out = out * (one - out)

inl sigmoid x =
    inl out = primal x |> sigmoid_fwd |> dr
    {
    out
    bck=inl _ -> set_adjoint x (inl _ -> sigmoid_bck (primal out) * get_adjoint out)
    }

inl tanh_fwd = tanh
inl tanh_bck out = one - out * out

inl tanh x =
    inl out = primal x |> tanh_fwd |> dr
    {
    out
    bck=inl _ -> set_adjoint x (inl _ -> tanh_bck (primal out) * get_adjoint out)
    }

inl relu_fwd x = if x > zero then x else zero
inl relu_bck out = if out > zero then one else zero

inl relu x =
    inl out = primal x |> relu_fwd |> dr
    {
    out
    bck=inl _ -> set_adjoint x (inl _ -> relu_bck (primal out) * get_adjoint out)
    }

inl (*) a b =
    inl out = primal a * primal b |> dr
    {
    out
    bck=inl _ ->
        set_adjoint a (inl _ -> primal b * get_adjoint out)
        set_adjoint b (inl _ -> primal a * get_adjoint out)
    }

inl (+) a b =
    inl out = primal a + primal b |> dr
    {
    out
    bck=inl _ ->
        set_adjoint a (inl _ -> get_adjoint out)
        set_adjoint b (inl _ -> get_adjoint out)
    }

inl link dim x =
    inl out = 
        Struct.map' (inl x -> x dim .get) x
        |> Struct.map (inl x ->
            match x with
            | {adjoint} -> 
                inl ar = array_create_cuda_local adjoint 1
                ar 0 <- adjoint
                {x with adjoint=ar}
            | _ -> 
                x
                )
    {
    out
    bck = inl _ ->
        Struct.iter2 (inl x out ->
            match x, out with
            | {adjoint=x}, {adjoint=out} -> x dim .set (out 0)
            | _ -> ()
            ) x out
    }

inl link_adjoint dim {from to} =
    Struct.iter2 (inl from to ->
        match from, to with
        | {adjoint=from}, {adjoint=to} -> to 0 <- from 0
        | _ -> ()
        ) from to
    {
    out=()
    bck=inl _ ->
        Struct.iter2 (inl from to ->
            match from, to with
            | {adjoint=from}, {adjoint=to} -> from 0 <- to 0
            | _ -> ()
            ) from to
    }

inl sequence x =
    inl out = Struct.map (inl {out} -> out) x
    inl bck = Struct.map (inl {bck} -> bck) x
    {out bck}

inl try_link_adjoint dim {from to} =
    inl a = module_intersect (inl from to -> from) from to
    inl b = module_intersect (inl from to -> to) from to

    Struct.map2 (inl from to -> link_adjoint dim {from to} |> inl x -> {x with block=()}) a b
    |> sequence

inl run {out bck} = Struct.foldr (<|) bck (); out

inl activation_lstm dim x =
    inm {from with in={input_cell output_cell memory_cell forget_cell memory_old}} = link dim x

    inm memory =
        inm input = sigmoid input_cell
        inm forget = sigmoid forget_cell
        inm memory = tanh memory_cell

        inm a = input * memory
        inm b = forget * memory_old
        a + b
    inm _ = try_link_adjoint dim {from to={out={memory}}}
                
    inm out =
        inm memory = tanh memory
        inm output = sigmoid output_cell
        output * memory
    inm _ = try_link_adjoint dim {from to={out={out}}}

    succ {memory out}

{
(>>=) succ dr sigmoid tanh relu (+) (*) link link_adjoint sequence try_link_adjoint run
sigmoid_fwd sigmoid_bck tanh_fwd tanh_bck relu_fwd relu_bck
activation_lstm
}
|> stackify
    """
    ) |> module_

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
    "Learning",[struct';extern_;cuda_aux;math;union;list;liple;cuda_ad],"The deep learning module.",
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
    inl sigmoid_fwd = CudaAD.sigmoid_fwd
    inl sigmoid_bck = CudaAD.sigmoid_bck

    inl sigmoid = activation {
        fwd = sigmoid_fwd
        bck = inl {out} -> sigmoid_bck out
        }

    inl tanh_fwd = CudaAD.tanh_fwd
    inl tanh_bck = CudaAD.tanh_bck

    inl tanh = activation {
        fwd = tanh_fwd
        bck = inl {out} -> tanh_bck out
        }

    inl relu_fwd = CudaAD.relu_fwd
    inl relu_bck = CudaAD.relu_bck

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

    // Optimized LSTM activation.
    inl lstm memory_old {ins with input_cell output_cell forget_cell memory_cell} s =
        inl b,a as dim = primal memory_old .dim
        inl primals_ins = primals ins
        assert_dim primals_ins (Struct.map (const dim) primals_ins)
        inl in = {ins with memory_old}
            
        inl out =
            inl x = to_dev_tensor {in=primals in}
            s.CudaFun.init {dim} (inl dim -> CudaAD.activation_lstm dim x .out |> primals)
            |> HostTensor.unzip
            |> Struct.map (dr s)

        {
        out
        bck=met _ ->
            inl x = to_dev_tensor {in out}
            s.CudaKernel.iter {dim} (inl dim -> CudaAD.activation_lstm dim x |> CudaAD.run |> ignore)
        }

    inl linear = succ
    inl Activation = { linear sigmoid tanh relu add hadmult hadmultb lstm } |> stack

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
                        | {primal adjoint} & x -> sgd learning_rate s x
                        | {} & x -> loop {x without block}
                        | x -> ()
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

    inl sign_accuracy label input s = // For the Binary Pattern test.
        inl input, label = primal input, primal label
        s.CudaFun.redo {
            map=inl input, label -> if Math.sign label = Math.sign input then 1 else 0
            redo=(+)
            } (input,label)
        |> inl x -> x 0

    inl Error = {square sigmoid_cross_entropy softmax_cross_entropy accuracy sign_accuracy} |> stackify

    // #Initializer
    inl Initializer =
        inl normal {stddev mean} tns s = s.CudaRandom.fill {dst=.Normal; stddev mean} tns
        inl stddev_sum_init mult tns = 
            inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 tns.dim))
            inl mean = 0f32
            normal {stddev mean} tns

        // Rough and possibly poorly tuned inits. Recommended to be used together with PRONG or layer/batch norm.
        inl relu = stddev_sum_init 1f32
        inl sigmoid = stddev_sum_init 2f32
        inl tanh = stddev_sum_init 3f32
        inl randn stddev = normal {stddev mean=0f32}
        
        inl zero tns s = s.CudaTensor.clear tns
        inl init init tns s = 
            inl tns = to_dev_tensor tns
            s.CudaKernel.iter {dim=tns.dim} (inl i -> tns i .set init)

        inl tensor d dim s =
            inl tns = Struct.map (inl _ -> s.CudaTensor.create {dim elem_type=float}) d.init |> heap
            function
            | .tensor -> tns
            | .init -> Struct.iter2 (inl f -> f s) d.init tns
            | .save stream -> Struct.iter2 (inl f -> f stream s) d.save tns
            | .load stream -> Struct.iter2 (inl f -> f stream s) d.load tns

        {
        tensor
        }
        |> stackify

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
    inl generalized_mi = // Online only version for now.
        activation {
            fwd=inl {input state bias={si s i c}} -> si * state * input + s * state + i * input + c
            bck=inl {in={input state bias={si s i c}} out} ->
                {
                input = si * state + i
                state = si * input + s
                bias = { si = input*state; i = input; s = state; c = one } 
                }
            }

    inl generalized_mi_tanh = // Online only version for now.
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
                    inm out = generalized_mi_tanh {input state bias}
                    succ out

                succ {out state={out}}
            inl {out={out state} bck} = apply s
            {out state bck}
        block = ()
        }

    inl concat x s =
        inl span_inner x = x.dim |> inl b,a -> a
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

    inl RNN = {mi mi_alt}

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
                        assert (snd reward.dim = 1) "Reward's second dimension must be 1." 
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
