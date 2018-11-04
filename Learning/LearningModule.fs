[<AutoOpen>]
module Learning.Lib

open Spiral.Types
open Spiral.Lib
open Cuda.Lib

let cuda_ad =
    (
    "CudaAD",[struct';liple],"The CudaAD module",
    """
inl float = float32
inl zero = 0f32
inl half = 0.5f32
inl one = 1f32
inl two = 2f32

inl (>>=) a b =
    match a with
    | {out=a bck=bck_a} ->
        inl {out=b bck=bck_b} = b a
        {out=b; bck=bck_a << bck_b}
    | _ ->
        inl {out=b bck=bck_b} = b a
        {out=b; bck=bck_b}

inl succ out = {out bck=const ()}

inl dr x =
    {
    primal=x
    adjoint=
        Struct.map (inl _ ->
            inl x = array_create_cuda_local float 1
            x 0 <- zero
            x
            ) x
    block=()
    }

inl add_adjoint x out =
    match x with
    | {adjoint} -> adjoint 0 <- adjoint 0 + out ()
    | _ -> ()

inl get_adjoint {adjoint} = adjoint 0

inl primal {primal} | primal = primal
inl primals = Struct.map primal

inl bind f x =
    module_foldr (inl k x next m ->
        inm x = x
        next {m with $k=x}
        ) x f {}

inl unary_bind f a = bind (inl {a} -> f a) {a}
inl binary_bind f a b = bind (inl {a b} -> f a b) {a b}

inl op fwd bck =
    bind <| inl x ->
        inl out = primals x |> fwd |> dr
        {
        out
        bck=inl _ -> 
            inl x' = {(primals x) with out=primal out}
            Struct.iter2 (inl bck x -> add_adjoint x (inl _ -> bck x' * get_adjoint out)) bck x
        }

inl unary_op fwd bck a = op (inl {a} -> fwd a) {a = inl {a out} -> bck a out} {a}
inl unary {fwd bck} = {fwd bck op = unary_op fwd bck}

inl comp_op fwd a b =
    bind (inl {a b} ->
        inl out = fwd (primal a) (primal b)
        {
        out
        bck=const ()
        }
        ) {a b}

inl comp fwd = {fwd op = comp_op fwd}

inl binary_op fwd bck a b =
    inl fwd {a b} = fwd a b
    inl bck = module_map (inl k bck -> inl {a b out} -> bck a b out) bck
    op fwd bck {a b}

inl binary {fwd bck} = {fwd bck op = binary_op fwd bck}

inl Unary = 
    inl sigmoid =
        unary {
            fwd = inl x -> one / (one + exp -x)
            bck = inl x out -> out * (one - out)
            }

    inl tanh =
        unary {
            fwd = tanh
            bck = inl x out -> one - out * out
            }

    inl relu =
        unary {
            fwd = inl x -> if x > zero then x else zero
            bck = inl x out -> if out > zero then one else zero
            }

    inl abs =
        unary {
            fwd = abs
            bck = inl x out -> if x >= zero then one else -one
            }

    inl sqr =
        unary {
            fwd = inl x -> x * x
            bck = inl x out -> two * x
            }

    inl sqrt =
        unary {
            fwd = sqrt
            bck = inl x out -> half / out
            }

    {sigmoid tanh relu abs sqr sqrt}

inl Binary = 
    inl (/) =
        binary {
            fwd = (/)
            bck = {
                a=inl a b out -> one / b
                b=inl a b out -> -out / b
                }
            }

    inl (*) =
        binary {
            fwd = (*)
            bck = {
                a = inl a b out -> b
                b = inl a b out -> a
                }
            }

    inl (+) =
        binary {
            fwd = (+)
            bck = {
                a = inl a b out -> one
                b = inl a b out -> one
                }
            }

    inl (-) =
        binary {
            fwd = (-)
            bck = {
                a = inl a b out -> one
                b = inl a b out -> -one
                }
            }

    {(*) (/) (+) (-)}

inl Comp =
    inl (<) = comp (<)
    inl (<=) = comp (<=)
    inl (=) = comp (=)
    inl (>=) = comp (>=)
    inl (>) = comp (>)
    {(<) (<=) (=) (>=) (>)}

inl Custom =
    inl cond =
        inl fwd {cond tr fl} = if cond then tr else fl
        inl bck = {
            cond = inl _ -> one
            tr = inl {cond} -> if cond then one else zero
            fl = inl {cond} -> if cond then zero else one
            }
        {fwd bck op = op fwd bck}
    {cond}

inl add_atomic = CudaAux.atomic_add
inl add_std x out = x .set (x .get + out)

inl index_std cur = Struct.map' <| inl x -> x cur
inl index_broadcast cur =
    Struct.map' <| inl x ->
        Struct.foldl (inl x cur ->
            x (if x.span_outer = 1 then 0 else cur)
            ) x cur

inl {link link_broadcast link_auto} =
    inl get_primal = 
        Struct.map (function
            | {primal adjoint} -> primal .get |> dr
            | x -> x .get
            )

    inl bck f =
        Struct.iter2 (inl x out ->
            match x, out with
            | {adjoint=x}, {adjoint=out} -> f x (out 0)
            | _ -> ()
            )

    {
    link = inl x cur ->
        inl x = index_std cur x
        inl out = get_primal x
    
        {
        out
        bck = inl _ -> bck add_std x out
        }

    link_broadcast = inl x cur ->
        inl x = index_broadcast cur x 
        inl out = get_primal x
    
        {
        out
        bck = inl _ -> bck add_atomic x out
        }

    link_auto = inl dim x cur ->
        inl out = index_broadcast cur x |> get_primal
    
        {
        out
        bck = inl _ ->
            inl dim_is_not_one = Tuple.map (inl dim -> dim <> 1) dim
            inl add_auto x out =
                inl is_atomic = Tuple.exists2 (inl dim_is_not_one x_dim -> dim_is_not_one && x_dim = 1) dim_is_not_one x.dim
                inl x = index_broadcast cur x
                if is_atomic then add_atomic x out else add_std x out
            bck add_auto x out
        }
    }
   
inl link_adjoint cur {from to} =
    Struct.iter2 (inl from to -> 
        match to with
        | () -> ()
        | _ -> to 0 <- from cur .get
        ) from to
    {
    out=()
    bck=inl _ -> 
        Struct.iter2 (inl from to -> 
            match to with
            | () -> ()
            | _ -> from cur .set (to 0)
            ) from to
    }

inl link_adjoint_view cur x = link_adjoint cur {x with from=Struct.map (inl x -> x.view) self}

inl sequence_module f x =
    inl x = module_map (const f) x
    inl bck = module_foldr (inl k {bck} s -> bck << s) x (const ())
    inl out = module_map (inl _ {out} -> out) x
    {out bck}

inl Op =
    module_foldl (inl _ ->
        module_foldl (inl k m {op} -> {m with $k=op})
        ) {} {Unary Comp Custom Binary}

inl Activation =
    open Op
    inl generalized_mi {bias={si s i c} input state} = si * state * input + s * state + i * input + c
    inl generalized_mi_tanh {bias={si s i c} input state} = si * state * input + s * state + i * input + c |> tanh

    inl lstm {memory cell} =
        inm memory = sigmoid cell.input * tanh cell.memory + sigmoid cell.forget * memory
        inm out = sigmoid cell.output * tanh memory
        succ {memory out}

    {generalized_mi generalized_mi_tanh lstm }

inl Seq k =
    inl val x = k.block.init (const x)
    inl dr x =
        {
        primal=x
        adjoint=Struct.map (inl _ -> val zero) x
        block=()
        }

    inl add_adjoint x out =
        match x with
        | {adjoint} -> 
            k.block.iter (inl {item} -> 
                inl adjoint = adjoint item
                adjoint .set (adjoint .get + out item)
                )
        | _ -> ()

    inl get_adjoint item {adjoint} = adjoint item .get
    inl op fwd bck =
        bind <| inl x ->
            inl out = primals x |> k.block.map fwd |> dr
            {
            out
            bck=inl _ -> 
                inl x' = {(primals x) with out=primal out}
                Struct.iter2 (inl bck x -> add_adjoint x (inl item -> bck (Struct.map' (inl x -> x item .get) x') * get_adjoint item out)) bck x
            }

    inl unary_op fwd bck a = op (inl {a} -> fwd a) {a = inl {a out} -> bck a out} {a}
    inl unary {fwd bck} = {fwd bck op = unary_op fwd bck}

    inl comp_op fwd a b =
        bind (inl {a b} ->
            inl out = k.block.map (inl a,b -> fwd a b) (primal a, primal b)
            {
            out
            bck=const ()
            }
            ) {a b}
    inl comp {fwd} = {fwd op = comp_op fwd}

    inl binary_op fwd bck a b =
        inl fwd {a b} = fwd a b
        inl bck = module_map (inl k bck -> inl {a b out} -> bck a b out) bck
        op fwd bck {a b}
    inl binary {fwd bck} = {fwd bck op = binary_op fwd bck}

    inl add_atomic a b {i item} = add_atomic (a i) (b item .get)
    inl add_std a b {i item} = add_std (a i) (b item .get)
    
    inl {link link_broadcast link_auto} =
        inl bck f =
            Struct.iter2 (inl x out ->
                match x, out with
                | {adjoint=x}, {adjoint=out} -> k.block.iter (f x out)
                | _ -> ()
                )

        inl get = Struct.map' (inl x -> x.get)

        {
        link = inl x b ->
            inl x = index_std b x
            inl out = 
                inl x = primals x
                Struct.map (inl x -> k.block.init (inl {i=a} -> index_std a x |> get) |> dr) x
    
            {
            out
            bck = inl _ -> bck add_std x out
            }

        link_broadcast = inl x b ->
            inl x = index_broadcast b x 
            inl out = 
                inl x = primals x
                Struct.map (inl x -> k.block.init (inl {i=a} -> index_broadcast a x |> get) |> dr) x
    
            {
            out
            bck = inl _ -> bck atomic_add x out
            }

        link_auto = inl dim x b ->
            inl out = 
                inl x = index_broadcast b (primals x) 
                Struct.map (inl x -> k.block.init (inl {i=a} -> index_broadcast a x |> get) |> dr) x 
            
            {
            out
            bck = inl _ ->
                inl dim_is_not_one = Tuple.map (inl dim -> dim <> 1) dim
                inl add_auto x out =
                    inl is_atomic = Tuple.exists2 (inl dim_is_not_one x_dim -> dim_is_not_one && x_dim = 1) dim_is_not_one x.dim
                    inl x = index_broadcast b x
                    if is_atomic then add_atomic x out else add_std x out
                bck add_auto x out
            }
        }
   
    inl link_adjoint b {from to} =
        Struct.iter2 (inl from to -> 
            match to with
            | () -> ()
            | _ -> k.block.iter (inl {item i=a} -> to item .set (from b a .get))
            ) from to
        {
        out=()
        bck=inl _ -> 
            Struct.iter2 (inl from to -> 
                match to with
                | () -> ()
                | _ -> k.block.iter (inl {item i=a} -> from b a .set (to item .get))
                ) from to
        }

    inl link_adjoint_view b x = link_adjoint b {x with from=Struct.map (inl x a b -> x .view a .view b) self} 

    inl Unary = module_map (const unary) Unary
    inl Comp = module_map (const comp) Comp
    inl Binary = module_map (const binary) Binary
    inl Custom = module_map (inl _ {fwd bck} -> {fwd bck op = op fwd bck}) Custom
    inl Op =
        module_foldl (inl _ ->
            module_foldl (inl k m {op} -> {m with $k=op})
            ) {} {Unary Comp Custom Binary}

    inl Op =
        inl sum =
            unary_bind <| inl x ->
                inl out = k.block.uter (+) (primal x) |> val |> dr
                {
                out
                bck=inl _ -> 
                    inl er = k.block.uter (+) out.adjoint
                    add_adjoint x (const er)
                }

        inl mean =
            unary_bind <| inl x ->
                inl dim = to float (Tensor.length (snd k.dim))
                inl div x = x / dim
                inl out = k.block.uter (+) (primal x) |> div |> val |> dr
                {
                out
                bck=inl _ -> 
                    inl er = k.block.uter (+) out.adjoint |> div
                    add_adjoint x (const er)
                }

        //// ----------
        open Op

        inl norm_template f x =
            inm x = x - mean x
            inm std = f x
            succ (x, std)

        inl safe x = x + val (to float (10.0 ** -7.0))
        inl l1_norm_body = norm_template (abs >> mean >> safe)
        inl l2_norm_body = norm_template (sqr >> mean >> safe >> sqrt)

        inl layer_norm =
            unary_bind <| inl x ->
                inm x, std = l2_norm_body x
                x / std

        inl weight_norm =
            unary_bind <| inl x ->
                inm x, std = l2_norm_body x
                cond {cond=std < val one; tr=x; fl=x / std}
        
        {Op with sum mean layer_norm weight_norm}

    inl Activation =
        open Op
        inl generalized_mi_ln_relu {bias={si s i c} input state} = si * state * input + s * state + i * input + c >>= layer_norm >>= relu
        inl wn_hebb {H eta input out} = H + val 0.0f32 * input * out >>= weight_norm
            
        {generalized_mi_ln_relu wn_hebb}

    {
    dr val link link_broadcast link_auto link_adjoint link_adjoint_view 
    Unary Binary Op Activation
    }

{
(>>=) succ dr link link_broadcast link_auto link_adjoint link_adjoint_view
Unary Binary Op Activation Seq
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

    /// Updates the covariance such that cov(t+1) = alpha * cov t + beta / k * x^T * x
    met update_covariance learning_rate x cov s =
        inl k = x.span_outer
        inl alpha = Math.pow (one - learning_rate) k
        inl beta = one - alpha
        s.CudaBlas.syrk' .Lower .T (beta / to float k) x alpha cov // symmetric rank-k update. (beta / to float k) * x * x^T + alpha * cov

    inl dr s primal = {primal adjoint=s.CudaTensor.zero_like primal; block=()}
    inl drv s primal = {primal adjoint=s.CudaTensor.zero_like_view primal; block=()}

    inl fwd_add_bias C bias s = s.CudaFun.map_map {out=C; map=inl {in in_inner} -> in+in_inner} {in=C; in_inner=bias}
    inl bck_add_bias C bias s = 
        s.CudaFun.redo_map {out=bias; mid=bias; neutral_elem=zero; redo=(+);
            map=inl {in} -> in
            map_out=inl {mid out} -> mid + out
            } C

    inl matmult_stream l s = 
        inl get_dims {data weight} =
            inl get_dim = function 
                | {T} -> T.dim |> inl b,a -> a,b
                | T -> T.dim
            inl (b,_),(_,a) = Tuple.map (primals >> get_dim) (data, weight)
            b,a

        inl init {d with data weight streams=l,r} = 
            inl dim = get_dims {data weight}
            inl s = s.data_add {stream=l}
            {d with out = s.CudaTensor.create {elem_type=float; dim} |> dr s}
        
        inl run {out data weight streams=l,r} =  
            l.wait_on s.data.stream
            inl s = s.data_add {stream=l}

            inl f = function {T} -> T, .T | nT -> nT, .nT
            inl (A,TA),(B,TB) = f data, f weight
            s.CudaBlas.gemm' TA TB one (primal A) (primal B) zero (primal out)

        inl bck {learning_rate} {d with out data weight streams=l,r} =
            inl f' = function {T} -> T, .nT | nT -> nT, .T
            inl (A,TA),(B,TB) = f' data, f' weight
            inl out = adjoint out
            on_non_nil (inl A -> 
                l.wait_on s.data.stream
                inl s = s.data_add {stream=l}
                match TA with
                | .T -> s.CudaBlas.gemm' .nT TB one out (primal B) one A
                | .nT -> s.CudaBlas.gemm' .nT TB one (primal B) out one A
                ) (adjoint A)
            on_non_nil (inl B -> 
                r.wait_on s.data.stream
                inl s = s.data_add {stream=r}
                match TB with
                | .T -> s.CudaBlas.gemm' TA .nT one (primal A) out one B
                | .nT -> s.CudaBlas.gemm' TA .nT one out (primal A) one B
                ) (adjoint B)
            inl update k data = 
                match d with 
                | {$k={covariance k}} -> 
                    update_covariance learning_rate data covariance s 
                    k := k() + out.span_outer
                | _ -> ()
            update .front (primal data)
            update .back out

        inl l = Struct.map init l
        Struct.iter run l
        Struct.iter (inl {streams=l,r} -> s.data.stream.wait_on l) l
        {
        out=Struct.map (inl {out} -> out) l
        bck=met d ->
            Struct.iter (bck d) l
            Struct.iter (inl {streams=x} -> Tuple.iter s.data.stream.wait_on x) l
        }

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
                        match TA with
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
        inl x = primals in |> Tensor.zip
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
        inl x = primals in |> Tensor.zip
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

    inl init {dim} init s =
        inl out =
            s.CudaFun.init {dim} (inl dim -> primals (init dim .out))
            |> Tensor.unzip
            |> Struct.map (dr s)
        
        {
        out
        bck=met _ ->
            inl from = adjoints (to_dev_tensor out)
            open CudaAD
            s.CudaKernel.iter {dim} <| inl dim -> 
                inl {out bck} = init dim >>= succ
                inl {bck=bck'} = link_adjoint dim {from to=adjoints out}
                bck(); bck'()
        }

    inl mapi f in s =
        inl dim = Tensor.assert_broadcastable (primals in)
        inl in = to_dev_tensor in
        open CudaAD
        init {dim} (inl cur -> link_auto dim in cur >>= f cur) s

    inl map = mapi << const

    inl segmented_init {dim} init s =
        inl out =
            open CudaAD
            inl init =
                Struct.map (inl init dim ->
                    inl {out} = init dim >>= succ
                    primals out
                    ) init
            s.CudaFun.segmented_init {dim} init
            |> View.unzip
            |> Struct.map (drv s)
        
        {
        out
        bck=met _ ->
            inl from = adjoints (to_dev_tensor out)
            open CudaAD
            s.CudaKernel.segmented_iter {dim} <| inl dim ->
                Struct.iter2 (inl cur init ->
                    inl {out=to bck} = init cur >>= succ
                    inl {bck=bck'} = link_adjoint_view dim {from to=adjoints to}
                    bck(); bck'()
                    ) dim init
        }

    inl init_seq {dim elem_type} init s =
        inl out =
            s.CudaFun.init_seq {dim elem_type} (inl b k -> primals (init b k .out))
            |> Tensor.unzip
            |> Struct.map (dr s)
        
        {
        out
        bck=met _ ->
            inl from = adjoints (to_dev_tensor out)
            open CudaAD
            s.CudaKernel.iter_seq {dim} <| inl b k -> 
                inl {out bck} = init b k >>= succ
                inl {bck=bck'} = (Seq k).link_adjoint b {from to=adjoints out}
                bck(); bck'()
        }

    inl seqi elem_type f in s =
        inl dim = Tensor.assert_broadcastable (primals in)
        inl in = to_dev_tensor in
        open CudaAD
        init_seq {dim elem_type} (inl b k -> 
            inl Seq = Seq k
            Seq.link_auto dim in b >>= f b k
            ) s

    inl seq elem_type f = seqi elem_type (const f)

    inl Primitive =
        {
        matmult activation error matmultb broadcasting_activation init mapi map
        segmented_init init_seq seq seqi
        } |> stack

    // #Operations
    inl (>>=) a b s =
        inl {out=a bck=a_bck} = a s
        inl {out=b bck=b_bck} = b a s
        {out=b; bck=a_bck, b_bck}

    inl succ out _ = {out bck=()}

    // #Activation
    inl sigmoid_fwd = CudaAD.Unary.sigmoid.fwd
    inl sigmoid_bck = CudaAD.Unary.sigmoid.bck

    inl sigmoid = activation {
        fwd = sigmoid_fwd
        bck = inl {in out} -> sigmoid_bck in out
        }

    inl tanh_fwd = CudaAD.Unary.tanh.fwd
    inl tanh_bck = CudaAD.Unary.tanh.bck

    // Unlike the others tanh supports multiple inputs that it sums before mapping.
    // TODO: Do that for the other activations as well.
    inl tanh = activation {
        fwd = Liple.foldl (+) zero >> tanh_fwd
        bck = inl {in out} -> Liple.map (const (tanh_bck in out)) in
        }

    inl relu_fwd = CudaAD.Unary.relu.fwd
    inl relu_bck = CudaAD.Unary.relu.bck

    inl relu = activation {
        fwd = relu_fwd
        bck = inl {in out} -> relu_bck in out
        }

    inl add a b = 
        activation {
            fwd = inl a,b -> a+b
            bck = inl _ -> one, one
            } (a,b)

    inl mult a b =
        activation {
            fwd = inl {a b} -> a*b
            bck = inl {in={a b}} -> { a = b; b = a }
            } {a b}

    inl hadmult (a,b) = mult a b
    inl hadmultb (x1,x2) b =
        activation {
            fwd=inl {b x1 x2} -> b + x1 * x2
            bck=inl {in={b x1 x2}} -> {b = one; x1 = x2; x2 = x1 }
            } {x1 x2 b}

    inl print x s =
        inb x = s.CudaFun.map {map=id} (primal x) |> CudaAux.temporary
        s.CudaTensor.print x
        {out=(); bck=()}

    inl ln_relu = seq float <| inl k -> 
        open CudaAD
        open Seq k .Op
        layer_norm >> relu

    inl ln_tanh = seq float <| inl k (alpha,plastic,static) -> 
        open CudaAD
        open Seq k
        open Op
        alpha * val 0.001f32 + static >>= tanh

    inl generalized_mi_ln_relu = seq float <| inl k -> CudaAD .Seq k .Activation .generalized_mi_ln_relu
    inl wn_hebb x = 
        {x with out=Struct.map' (Tensor.rotate (inl a,b -> b,a)) self}
        |> seq float (inl k -> CudaAD .Seq k .Activation .wn_hebb)

    inl linear = succ
    inl Activation = { linear sigmoid tanh relu add hadmult hadmultb ln_relu} |> stack

    // #Optimizer
    inl sgd learning_rate s {primal adjoint} = 
        inl out = primal, adjoint
        s.CudaFun.map {out map=inl P, A -> P - learning_rate * A, zero} out

    inl clipped_sgd max learning_rate s {primal adjoint} = 
        s.CudaFun.map {
            out=primal,adjoint
            map=inl P, A -> 
                inl A = if A < -max then -max elif A > max then max else A
                P - learning_rate * A, zero
            } (primal, adjoint)

    inl kfac {learning_rate weights} s =
        inl k_max = 128

        inl factor {covariance=from precision=to k epsilon} = 
            if k() >= k_max then
                k := 0
                s.CudaSolve.regularized_cholesky_inverse {epsilon from to}

        Struct.iter (function
            | {d with weight} ->
                inl reproject a b ret =
                    inb x = s.CudaBlas.gemm .nT .nT one a b |> CudaAux.temporary // TODO: Replace the gemm with a symm here.
                    ret x

                inl reproject_to a b c = s.CudaBlas.gemm' .nT .nT -learning_rate a b one c // TODO: Replace the gemm with a symm here.
                inl clear = s.CudaTensor.clear

                match d with
                | {front back} -> 
                    factor front; factor back
                    inb x = reproject front.precision (adjoint weight)
                    reproject_to x back.precision (primal weight)
                | {back} -> factor back; reproject_to (adjoint weight) back.precision (primal weight)
                | {front} -> factor front; reproject_to front.precision (adjoint weight) (primal weight)
                | _ -> s.CudaBlas.geam' .nT .nT -learning_rate (adjoint weight) one (primal weight) (primal weight)
                clear (adjoint weight)
            | _ -> ()
            ) weights

    inl standard learning_rate s = 
        Struct.iter (function 
            | {optimize weights} ->
                inl weights = Struct.map' (inl x -> x.data) weights
                optimize {learning_rate weights} s
            | {weights} -> 
                Struct.iter' (function !(inl x -> x.data) {x with primal adjoint} -> sgd learning_rate s x | _ -> ()) weights
            )

    inl Optimizer = {sgd clipped_sgd standard kfac}

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
        s.CudaKernel.iter_seq {dim=input.dim}
            (inl b k ->
                inl input,output = Tuple.map (inl x -> x b) ins
                k.block.store {
                    from=softmax_body temp k input
                    to=output
                    }
            )
        output
                
    inl sample_body prob s =
        inl b, a as dim = prob.dim
        inl boundary = s.CudaRandom.create {dst=.Uniform} {elem_type=float; dim=b}
        inl output = s.CudaTensor.create {elem_type=int64; dim=boundary.dim}
        inl inputs = Tuple.map CudaAux.to_dev_tensor (prob,boundary,output)
        s.CudaKernel.iter_seq {dim} // The sampling function
            (inl b k ->
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
            )
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
                s.CudaKernel.iter_seq {dim=input.dim}
                    (inl b k ->
                        inl input,label,to = Tuple.map (inl x -> x b) ins
                        inl prob = softmax_body temp k input
                        inl label = k.block.load label
                        inl costs = k.block.map (inl {prob label} -> -label * log prob) {prob label}
                        k.block.store_scalar { to from = k.block.redo (+) costs }
                    )
            s.CudaFun.redo {
                redo = (+)
                neutral_elem = zero
                } cost 0

        inl bck _ = join
            inl ins = to_dev_tensor (input, label)
            s.CudaKernel.iter_seq {dim=primal input .dim}
                (inl b k ->
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
                )
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
    inl Initializer number =
        inl Init =
            inl normal {stddev mean} to s = 
                inb from = s.CudaRandom.create {dst=.Normal; stddev mean} {elem_type=float; dim=to.dim} |> CudaAux.temporary
                inl {from to} = to_dev_tensor {from to}
                s.CudaKernel.iter {dim=to.dim} (inl i -> to i .set (from i .get))
            inl stddev_sum_init mult tns = 
                inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 tns.dim))
                inl mean = 0f32
                normal {stddev mean} tns

            inl constant init tns s =
                inl tns = to_dev_tensor tns
                s.CudaKernel.iter {dim=tns.dim} (inl i -> tns i .set init)

            inl identity init tns s =
                inl a,b as dim = tns.dim
                assert (a = b) "The tensor needs to be a square matrix."
                inl tns = to_dev_tensor tns
                s.CudaKernel.iter {dim} (inl a,b as i -> tns i .set (if a = b then init else zero))
            {
            // Rough and possibly poorly tuned inits. Recommended to be used together with PRONG or layer/batch norm.
            relu = stddev_sum_init 1f32
            sigmoid = stddev_sum_init 2f32
            tanh = stddev_sum_init 3f32
            randn = inl stddev -> normal {stddev mean=0f32}
            const = constant
            identity' = identity
            identity = identity one
            custom = inl f tns s -> f tns s
            }

        inl tensor {dim init} s =
            inl tns = Struct.map' (inl _ -> s.CudaTensor.create {dim elem_type=float}) init |> heap
            function
            | .data -> tns
            | .init -> Struct.iter2' (inl init tns -> init tns s) init tns
            | .save stream -> Struct.iter2' (inl f tns -> f stream tns s) d.save tns
            | .load stream -> Struct.iter2' (inl f tns -> f stream tns s) d.load tns

        inl tensor_view_init init tns s =
            inl dim = tns.dim
            inl tns = tns.basic
            inl f x next s =
                match x with
                | {} ->
                    inl rec loop init x = 
                        match x with
                        | {from near_to} -> next {s with apply=x :: self; init}
                        | {} -> module_map (inl k x -> loop (init k) x; ()) x |> ignore
                    loop s.init x
                | from -> next {s with apply=() :: self}

            inl finally {apply init} = 
                inl tns = Tuple.rev apply |> tns 
                init tns s
            
            Tuple.foldr f dim finally {init apply=()}

        inl tensor_view_template f {init dim} s =
            inl tns = Struct.map' (inl _ -> s.CudaTensor.create_view {dim elem_type=float}) init |> heap
            function
            | .data -> f tns
            | .init -> Struct.iter2' (inl init tns -> init tns s) init tns
            | .save stream -> Struct.iter2' (inl f tns -> f stream tns s) d.save tns
            | .load stream -> Struct.iter2' (inl f tns -> f stream tns s) d.load tns

        inl tensor_view = tensor_view_template id
        inl tensor_view' = tensor_view_template (Struct.map' (inl x -> x.basic))

        inl stream s =
            inl stream = s.RegionStream.allocate.data.stream
            function
            | .data -> stream
            | .init -> ()
            | .save stream -> ()
            | .load stream -> ()

        inl var init s =
            inl data = ref init
            function
            | .data -> data
            | .init -> ()
            | .save stream -> ()
            | .load stream -> ()

        inl val init s =
            function
            | .data -> init
            | .init -> ()
            | .save stream -> ()
            | .load stream -> ()

        inl Tensor = 
            inl sing init dim = tensor {dim init}
            inl dual primal dim = tensor {dim init={primal adjoint=Init.const zero; block=()}}
            inl number = {sing dual} number
            
            {
            relu = number Init.relu
            sigmoid = number Init.sigmoid
            tanh = number Init.tanh
            randn = inl stddev -> number (Init.randn stddev)
            identity = number Init.identity
            const = inl init -> number (Init.const init)
            custom = number Init.custom
            stream var val
            }

        inl TensorView =
            inl sing tensor_view {init dim} = tensor_view {init=tensor_view_init init; dim}
            inl dual tensor_view {init dim} =
                inl primal = tensor_view_init init
                inl adjoint tns s = Init.const zero tns.basic s
                tensor_view {init={primal adjoint block=()}; dim}
            
            inl view = Struct.map (inl x -> x tensor_view) {sing dual} number
            inl view' = Struct.map (inl x -> x tensor_view') {sing dual} number

            { Init with view view' stream var val }

        { Tensor TensorView }

    inl Initializer = 
        {
        sing = Initializer.sing
        dual = Initializer.dual
        }

    inl init s size dsc = 
        Struct.foldl_map (inl sublayer_size {x with init} -> 
            inl {d with dsc size} = init sublayer_size
            inl weights = Struct.map' (inl x -> x s |> inl x -> x.init; x) dsc |> heap
            {x without init with weights size}, size
            ) size dsc

    inl run s input =
        Struct.foldl_map (inl input {layer with apply} ->
            inl input =
                inl input = {input}
                inl input = match layer with {weights} -> {input with weights} | _ -> input
                match layer with {state} -> {input with state} | _ -> input

            inl {x with out} =
                indiv join
                    match input with
                    | {weights} -> {input with weights = Struct.map' (inl x -> x.data) weights}
                    | _ -> input
                    |> inl input -> apply input s |> stack
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
                bias = Initializer.dual.Tensor.const zero size
                }
            size
            }

        apply = inl {weights input} -> matmultb (input, weights.input) weights.bias >>= activation
        block = ()
        }

    inl Feedforward = 
        inl I = Initializer.dual.Tensor
        inl sigmoid = layer I.sigmoid sigmoid
        inl relu = layer I.relu relu
        inl tanh = layer I.tanh tanh
        inl linear = layer I.sigmoid succ
        inl zero = layer (I.const zero) succ
        inl ln_relu = layer (I.relu) ln_relu
        {sigmoid relu tanh linear zero ln_relu} |> stackify
   
    inl zero_like x = 
        inl zero dim s = {out=s.CudaTensor.zero {elem_type=float; dim}; bck=()}
        zero (primal x .dim)

    inl concat x s =
        inl span_inner x = x.dim |> inl b,a -> a
        inl {dim elem_type} = 
            Struct.foldl (inl s x ->
                match s with
                | () -> {dim=x.dim; elem_type=x.elem_type}
                | {dim=b, a} ->
                    inl b', a' = x.dim
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

    inl sequence x s =
        inl x = Struct.map (inl x -> x s |> inl x -> {x with block=()}) x
        {
        out = Struct.map (inl {out} -> out) x
        bck = Struct.map (inl {bck} -> bck) x
        }

    inl covariance = 
        inl {identity val var} = Initializer.sing.Tensor
        inl epsilon !(View.span) x -> {covariance=identity (x, x); precision=identity (x, x); epsilon=val epsilon; k=var 0}

    inl default_epsilon = to float (2.0 ** -3.0)

    inl zip_dual {primal adjoint} = Struct.map2 (inl primal adjoint -> {primal adjoint block=()}) primal adjoint
    inl wrap_split dim = Struct.map' (View.wrap dim >> View.split) >> Struct.map zip_dual
    inl wrap_split_weight = Struct.map2 (inl dim {d with weight} -> wrap_split dim weight)

    inl expand_singular dim x s =
        inl out = 
            Struct.map (inl {x with weight} ->
                inl s = 
                    match x with
                    | {stream} -> s.data_add {stream}
                    | _ -> s
                Tensor.expand_singular dim (primal weight) |> dr s
                ) x

        inl wait_for_streams _ =
            Struct.iter (function {stream} -> s.data.stream.wait_on stream | _ -> ()) x

        wait_for_streams()
        
        inl squeeze weight =
            assert (weight.span_outer = 1) "The span of outer must be 1."
            weight 0

        {
        out
        bck=met d -> 
            Struct.iter2 (inl out {x with weight back} ->
                
                inl s = 
                    match x with
                    | {stream} ->
                        stream.wait_on s.data.stream
                        s.data_add {stream}
                    | _ ->
                        s
                        
                bck_add_bias (adjoint out) (adjoint weight |> squeeze) s
                update_covariance d.learning_rate (adjoint out) back.covariance s
                back.k := back.k() + (primal out .span_outer)
                ) out x

            wait_for_streams()
        }

    inl weight {d with dim=b,a} = 
        open Initializer.dual.TensorView
        {
        weight = view' d
        streams = stream, stream
        front = covariance default_epsilon b
        back = covariance default_epsilon a
        block = ()
        }

    inl bias {d with dim=1,a} = 
        open Initializer.dual.TensorView
        {
        weight = view' d
        block = ()
        }

    inl load = to_dev_tensor >> CudaAD.link
    inl loadb = to_dev_tensor >> CudaAD.link_broadcast
    inl loada dim = to_dev_tensor >> CudaAD.link_auto dim

    // #Recurrent
    inl rnn size =
        inl inner = size
        {
        init = inl sublayer_size -> 
            open Initializer.dual.TensorView
            inl outer = {bias=1; input=sublayer_size; state=size}
            inl init = {bias=const zero; input=relu; state=relu}
            {
            dsc = 
                {
                weights = weight {init dim=outer,inner}
                outer = val outer
                }
            size
            }

        apply = inl {d with weights={weights outer} input} s -> 
            inl span = primal input .span_outer
            inl out =
                match d with
                | {state={out}} -> out
                | _ -> 
                    inl f _ = s.CudaTensor.zero {elem_type=float; dim=span,size}
                    f()

            inl apply =
                inm out =
                    inm data = segmented_init {dim=span,outer} {bias=const one; input=load input; state=load out}
                    inl data = Struct.map' (inl data -> data.basic) data
                    matmult_stream {weights with data} >>= ln_relu
                succ {out state={out}}

            inl {out={out state} bck} = apply s
            {out state bck}
        optimize = Optimizer.kfac
        block = ()
        }

    inl plastic_rnn size =
        {
        init = inl sublayer_size -> 
            open Initializer.dual.TensorView
            inl outer = {bias=1; input=sublayer_size; state=size}
            inl inner = 
                {
                static={alpha=1; eta=1; out=size}
                plastic=size
                }
            inl init = 
                {
                bias={alpha=const 0.01f32; eta=const 0.001f32; out=const zero}
                input={alpha=const zero; eta=const zero; out=identity}
                state={alpha=const zero; eta=const zero; out=const zero}
                }
            {
            dsc = 
                {
                weights = weight {init dim=outer,inner.static}
                dim = val {outer inner sublayer_size}
                }
            size
            }

        apply = inl {d with weights={weights dim={outer inner}} input} s -> 
            inl span = primal input .span_outer
            assert (span = 1) "The differentiable plasticity layer supports only online learning for now."
            inl {state H} =
                match d with
                | {state} -> state
                | _ -> {
                    H=s.CudaTensor.zero_view {elem_type=float; dim=inner.plastic, size} .basic
                    state=s.CudaTensor.zero {elem_type=float; dim=span, size}
                    }

            inl apply =
                inm data = segmented_init {dim=span,outer} {bias=const one; input=load input; state=load state}
                inl data = Struct.map' (inl data -> data.basic) data
                inm {alpha eta out} =
                    inm data = matmult_stream {weights with data}
                    succ (wrap_split ((), inner.static) data)
                //inm _ = print state
                //inm _ = print (Struct.map' (inl x -> x.basic) data)
                //inm _ = print modulation
                //inm _ = print out
                inm out =
                    //inm plastic = matmult_stream {data=state; weight={T=H}; streams=weights.streams; block=()}
                    //inm _ = print out'
                    //ln_tanh (alpha, plastic, out)
                    tanh out
                inm _ = print out
                inm H = wn_hebb {H eta out input=state}
                //inm _ = print weights.weight
                succ {out state={state=out; H}}

            inl {out={out state} bck} = apply s
            {out state bck}
        //optimize = Optimizer.kfac
        block = ()
        }

    inl mi size =
        inl inner = 
            {
            matrix = size
            bias = {si=size; i=size; s=size; c=size}
            }
        {
        init = inl sublayer_size -> 
            open Initializer.dual.TensorView
            inl outer = sublayer_size
            inl init = {
                bias = {si=const one; i=const half; s=const half; c=const zero}
                }
            {
            dsc = 
                {
                weights = 
                    {
                    input = weight {init=tanh; dim=outer,inner.matrix}
                    state = weight {init=tanh; dim=outer,inner.matrix}
                    }
                bias = bias {init=init.bias; dim=1,inner.bias}
                outer = val outer
                }
            size
            }

        apply = inl {d with weights={weights bias outer} input} s -> 
            inl span = primal input .span_outer
            inl out =
                match d with
                | {state={out}} -> out
                | _ -> 
                    inl f _ = s.CudaTensor.zero {elem_type=float; dim=span,size}
                    f()

            inl apply =
                inm out =
                    inl bias = wrap_split_weight ((),inner.bias) bias
                    matmult_stream {
                        input={(weights.input) with data=input}
                        state={(weights.state) with data=out}
                        }
                    >>= inl x -> generalized_mi_ln_relu {x with bias}
                succ {out state={out}}

            inl {out={out state} bck} = apply s
            {out state bck}
        optimize = Optimizer.kfac
        block = ()
        }

    inl lstm size =
        inl inner = {input=size; forget=size; output=size; memory=size}
        {
        init = inl sublayer_size -> 
            open Initializer.dual.TensorView
            inl init = 
                {
                bias = {input=const zero; forget=const one; output=const zero; memory=const zero}
                input = {input=tanh; forget=tanh; output=tanh; memory=tanh}
                state = {input=tanh; forget=tanh; output=tanh; memory=tanh}
                }
            inl outer = {bias=1; input=sublayer_size; state=size}
            {
            dsc = 
                {
                weights = weight {init dim=outer,inner}
                outer = val outer
                }
            size
            }

        apply = inl {d with weights={weights outer} input} s -> 
            inl span = primal input .span_outer
            inl out, memory =
                match d with
                | {state={out memory}} -> out, memory
                | _ -> 
                    inl f _ = s.CudaTensor.zero {elem_type=float; dim=span,size}
                    f(), f()

            inl apply =
                inm {out memory} =
                    inm data = segmented_init {dim=span,outer} {bias=const one; input=load input; state=load out}
                    inl data = Struct.map' (inl data -> data.basic) data
                    inm cell = matmult_stream {weights with data}
                    inl cell = wrap_split ((),inner) cell
                    map CudaAD.Activation.lstm {memory cell}

                succ {out state={out memory}}

            inl {out={out state} bck} = apply s
            {out state bck}
        optimize = Optimizer.kfac
        block = ()
        }

    inl RNN = {rnn plastic_rnn mi lstm }

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
                        assert (Tensor.span dim_a = 1) "In the scalar reward case, the outer dimension of the input must be 1."
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

        //inl Layer =
        //    inl default w = 
        //        inl defaults =
        //            {
        //            initializer=Initializer.dual.Tensor.bias
        //            activation=Activation.linear
        //            }

        //        module_foldl (inl k w x -> match w with {$k=_} -> w | _ -> {w with $k=x}) w defaults

        //    inl pg = default >> prong

        //    // Both the MC and the TD layers do their reprojection steps on the optimization pass unlike
        //    // the vanilla PRONG layers.
        //    inl mc (!default {w with !size}) = prong {w with size=1}
        //        //prong_template {front_mode=.prong; mode=.update} {w with size=1}

        //    {pg mc}

        /// For online learning.
        inl action {State Action final} {net input} s =
            indiv join
                assert (eq_type State input) "The input must be equal to the state type."
                inl input = 
                    inl tns = Union.to_dense input |> Tensor.array_as_tensor
                    s.CudaTensor.from_host_tensor tns .reshape (inl x -> 1, Union.length_dense State)

                inl net, input = run s input net
                inl {out bck} = final input s

                inl action = Union.from_one_hot Action (s.CudaTensor.get (out 0))
                stack {action net bck}
       
        {action sampling_pg Value}

    { 
    dr primal primals adjoint adjoints (>>=) succ Primitive Activation Optimizer Initializer Error run init Feedforward RNN RL
    }
    """) |> module_
