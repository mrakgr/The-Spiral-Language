[<AutoOpen>]
module Learning.Lib

open Spiral.Types
open Spiral.Lib
open Cuda.Lib

let cuda_ad: SpiralModule =
    {
    name="CudaAD"
    prerequisites=[struct'; liple]
    opens=[]
    description="The CudaAD module"
    code=
    """
inl float = float32
inl num = to float
inl zero = num 0
inl half = num 0.5
inl one = num 1
inl two = num 2
inl epsilon x = num 2.0 ** num x

inl (>>=) a b =
    match a with
    | {out=a bck=bck_a} ->
        match b a with
        | {out=b bck=bck_b} -> {out=b; bck=bck_a << bck_b}
        | b -> {out=b; bck=bck_a}
    | _ ->
        match b a with
        | {out=b bck=bck_b} -> {out=b; bck=bck_b}
        | b -> b

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

inl adjoint = function
    | {adjoint} -> adjoint
    | _ -> ()
inl adjoints = Struct.map adjoint
inl get_adjoint {adjoint} = adjoint 0

inl primal = function
    | {out bck} -> error_type "Not supposed to be used on {out bck}."
    | {primal} | primal -> primal
inl primals = Struct.map primal

inl bind f x =
    module_foldr (inl k x next m ->
        inm x = x
        next {m with $k=x}
        ) x f {}

inl unary_bind f a = bind (inl {a} -> f a) {a}
inl binary_bind f a b = bind (inl {a b} -> f a b) {a b}

inl as_cost =
    unary_bind <| inl x ->
        inl out = primal x
        {
        out
        bck=inl _ -> adjoint x 0 <- one
        }

inl cond_primals {input map on_succ} =
    inl (!map out), c =
        Struct.foldl_map (inl s -> function
            | {adjoint primal} -> primal, true
            | x -> x, s
            ) false input
    if c then on_succ out else out

inl op fwd bck =
    bind <| inl x ->
        cond_primals {
            input=x
            map=fwd
            on_succ=inl out ->
                inl out = dr out
                {
                out
                bck=inl _ -> 
                    inl x' = {(primals x) with out=primal out}
                    Struct.iter2 (inl bck x -> add_adjoint x (inl _ -> bck x' * get_adjoint out)) bck x
                }
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
            bck = inl x out -> if out = zero then zero else half / out
            }

    inl exp =
        unary {
            fwd = exp
            bck = inl x out -> out
            }

    inl log =
        unary {
            fwd = log
            bck = inl x out -> one / x
            }

    {sigmoid tanh relu abs sqr sqrt exp log}

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

    inl (**) =
        binary {
            fwd = (**)
            bck = {
                a = inl a b out -> b * a ** (b - one)
                b = inl a b out -> out * log a
                }
            }

    inl max =
        binary {
            fwd = max
            bck = {
                a = inl a b out -> if a > b then one else zero
                b = inl a b out -> if a > b then zero else one
                }
            }

    inl min =
        binary {
            fwd = min
            bck = {
                a = inl a b out -> if a > b then zero else one
                b = inl a b out -> if a > b then one else zero
                }
            }

    {(*) (/) (+) (-) (**) max min}

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
    inl bounded_exp =
        inl fwd {eta upper lower} = if upper = lower then lower else exp (eta * log upper + (one - eta) * log lower)
        inl bck = {
            eta = inl {eta upper lower out} -> if upper = lower then zero else out * (log upper - log lower)
            upper = inl {eta upper lower out} -> if upper = lower then zero else out * eta / upper
            lower = inl {eta upper lower out} -> if upper = lower then one else out * (one - eta) / lower
            }
        {fwd bck op = op fwd bck}
    {cond bounded_exp}

inl add_atomic = CudaAux.atomic_add
inl add_std x out = x .set (x .get + out)

inl index_std cur = 
    Struct.map' <| function
        | x when val_is x -> x
        | x -> x cur

inl index_broadcast cur =
    Struct.map' <| function
        | x when val_is x -> x
        | x ->
            Struct.foldl (inl x cur ->
                x (if x.span_outer = 1 then 0 else cur)
                ) x cur

inl {link link_broadcast link_auto} =
    inl get_primal =
        Struct.map (function
            | x when val_is x -> x
            | x ->
                Struct.map (function
                    | {primal adjoint} -> primal .get |> dr
                    | {primal} -> {primal=primal.get; block=()}
                    | primal -> primal.get
                    ) (View.unzip x)
            )

    inl bck f x out =
        inl x = 
            Struct.map (function
                | x when val_is x -> x
                | x -> View.unzip x
                ) x
        Struct.iter2 (inl x out ->
            match x, out with
            | {adjoint=x}, {adjoint=out} -> f x (out 0)
            | _ -> ()
            ) x out

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
    inl from = from .view cur |> View.unzip
    Struct.iter2 (inl from to -> 
        match to with
        | () -> ()
        | _ -> to 0 <- from .get
        ) from to
    {
    out=()
    bck=inl _ -> 
        Struct.iter2 (inl from to -> 
            match to with
            | () -> ()
            | _ -> from .set (to 0)
            ) from to
    }

inl Op =
    module_foldl (inl _ ->
        module_foldl (inl k m {op} -> {m with $k=op})
        ) {} {Unary Comp Custom Binary}

inl Activation =
    open Op
    inl module_map f x =
        inl x = module_map f x
        inl bck = module_foldr (inl k {bck} s -> bck << s) x (const ())
        inl out = module_map (inl _ {out} -> out) x
        {out bck}

    inl generalized_mi {bias={si s i c} input state} = si * state * input + s * state + i * input + c
    inl generalized_mi_tanh {bias={si s i c} input state} = si * state * input + s * state + i * input + c |> tanh

    inl lstm {memory cell} =
        inm memory = sigmoid cell.input * tanh cell.memory + sigmoid cell.forget * memory
        inm out = sigmoid cell.output * tanh memory
        succ {memory out}

    inl hebb_tanh {alpha plastic static} = alpha * plastic + static >>= tanh

    inl td discount {trace value reward value'} =
        inm value' = reward + value'
        inm error = value' - value
        inm _ = sqr error |> as_cost

        inm trace = sigmoid trace 
        inm value' = discount * (trace * value' + (one - trace) * primal value)

        succ {value' error=primal error}


    {generalized_mi generalized_mi_tanh lstm hebb_tanh td}

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
            cond_primals {
                input=x
                map=k.block.map fwd
                on_succ=inl out ->
                    inl out = dr out
                    {
                    out
                    bck=inl _ -> 
                        inl x' = {(primals x) with out=primal out}
                        Struct.iter2 (inl bck x -> add_adjoint x (inl item -> bck (Struct.map' (inl x -> x item .get) x') * get_adjoint item out)) bck x
                    }
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

    inl add_atomic a b {i item} = add_atomic (index_broadcast i a) (b item .get)
    inl add_std a b {i item} = add_std (a i) (b item .get)
    
    inl {link link_broadcast link_auto} =
        inl bck f =
            Struct.iter2 (inl x out ->
                match x, out with
                | {adjoint=x}, {adjoint=out} -> k.block.iter (f x out)
                | _ -> ()
                ) << Tensor.unzip

        inl get = Struct.map' (inl x -> x.get)

        {
        link = inl x b ->
            inl x = index_std b x
            inl out = 
                inl x = primals (Tensor.unzip x)
                Struct.map (inl x -> k.block.init (inl {i=a} -> index_std a x |> get) |> dr) x
    
            {
            out
            bck = inl _ -> bck add_std x out
            }

        link_broadcast = inl x b ->
            inl x = index_broadcast b x 
            inl out = 
                inl x = primals (Tensor.unzip x)
                Struct.map (inl x -> k.block.init (inl {i=a} -> index_broadcast a x |> get) |> dr) x
    
            {
            out
            bck = inl _ -> bck atomic_add x out
            }

        link_auto = inl dim x b ->
            inl out = 
                inl x = index_broadcast b (primals (Tensor.unzip x)) 
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
            | _ -> k.block.iter (inl {item i=a} -> to item .set (from .view (b, a) .get))
            ) from to

        {
        out=()
        bck=inl _ -> 
            Struct.iter2 (inl from to -> 
                match to with
                | () -> ()
                | _ -> k.block.iter (inl {item i=a} -> from .view (b, a) .set (to item .get))
                ) from to
        }

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
                cond_primals {
                    input=x
                    map=k.block.uter (+) >> val
                    on_succ=inl out ->
                        inl out = dr out
                        {
                        out
                        bck=inl _ -> 
                            inl er = k.block.uter (+) out.adjoint
                            add_adjoint x (const er)
                        }
                    }

        inl mean =
            unary_bind <| inl x ->
                inl div =
                    inl dim = to float (Tensor.length (snd k.dim))    
                    inl x -> x / dim
                cond_primals {
                    input=x
                    map=k.block.uter (+) >> div >> val
                    on_succ=inl out ->
                        inl out = dr out
                        {
                        out
                        bck=inl _ -> 
                            inl er = k.block.uter (+) out.adjoint |> div
                            add_adjoint x (const er)
                        }
                    }

        //// ----------
        open Op

        inl norm_template f x =
            inm x = x - mean x
            inm std = f x
            succ (x, std)

        inl safe x = x + val (epsilon -10)
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
        inl wn_hebb {H upper mid eta input out} = 
            inm eta = 
                match eta with 
                | {input out} -> (tanh input + tanh out) / val two 
                | _ -> tanh eta
            inm eta = bounded_exp {eta upper lower=mid}
            weight_norm (H + eta * input * out)
            
        {generalized_mi_ln_relu wn_hebb}

    {
    dr val link link_broadcast link_auto link_adjoint 
    Unary Binary Op Activation
    }

{
primal primals adjoint adjoints
(>>=) succ dr link link_broadcast link_auto link_adjoint
Unary Binary Op Activation Seq
}
|> stackify
    """
    }

let union: SpiralModule =
    {
    name="Union"
    prerequisites=[tuple; console; option; list]
    opens=[]
    description="The Union module."
    code=
    """
/// Note: The innermost dimension is the first one rather than the last which is used by tensors.

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

inl infer f state =
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
            loop (var (heap state))

    ty, Struct.map (inl {map} state input -> match state with () | _ -> map state input |> box ty) f

{int to_one_hot to_dense from_one_hot from_dense length_one_hot length_dense unroll mutable_function infer} |> stackify
    """
    }

let learning: SpiralModule =
    {
    name="Learning"
    prerequisites=[struct'; extern_; cuda_aux; math; union; list; liple; cuda_ad]
    opens=[]
    description="The deep learning module."
    code=
    """
inl float ->
    // #Primitives
    inl to_dev_tensor = CudaAux.to_dev_tensor
    inl atomic_add = CudaAux.atomic_add
    inl assert_dim = CudaAux.assert_dim
    
    inl num = to float
    inl zero = num 0
    inl half = num 0.5
    inl one = num 1
    inl two = num 2
    inl epsilon x = num 2 ** num x
    inl infinity =
        match float with
        | _: float32 -> infinityf32
        | _: float64 -> infinityf64

    inl on_non_nil ret B =
        match B.elem_type with
        | () -> ()
        | _ -> ret B

    inl basic x = x.basic
    inl pr = function {primal} | primal -> primal
    inl adj = function {adjoint} -> adjoint | _ -> ()

    inl primal x = x.update_body' pr
    inl adjoint x = x.update_body' adj

    inl primals x = x.update_body' (Struct.map pr)
    inl adjoints x = x.update_body' (Struct.map adj)

    /// Updates the covariance such that cov(t+1) = alpha * cov(t) + beta / k * x^T * x
    met update_covariance x cov s =
        inl rate = s.data.rate.covariance
        inl k = x.span_outer
        inl alpha = Math.pow (one - rate) k
        inl beta = one - alpha
        s.CudaBlas.syrk' .Lower .T (beta / to float k) x.basic alpha cov.basic // symmetric rank-k update. (beta / to float k) * x * x^T + alpha * cov

    inl dr s primal = View.zip {primal adjoint=s.CudaTensor.zero_like_view primal; block=()}

    inl matmult_stream l s = 
        inl get_dims {data weight} =
            inl get_dim = function 
                | {T} -> T.dim |> inl b,a -> a,b
                | T -> T.dim
            inl (b,_),(_,a) = Tuple.map get_dim (data, weight)
            b,a

        inl init {d with data weight streams=l,r} = 
            inl dim = get_dims {data weight}
            inl s = s.data_add {stream=l}
            {d with out = s.CudaTensor.create_view {elem_type=float; dim} |> dr s}
        
        inl run {out data weight streams=l,r} =  
            l.wait_on s.data.stream
            inl s = s.data_add {stream=l}

            inl f = function {T} -> T, .T | nT -> nT, .nT
            inl (A,TA),(B,TB) = f data, f weight
            s.CudaBlas.gemm' TA TB one (primal A .basic) (primal B .basic) zero (primal out .basic)

        inl bck {d with out data weight streams=l,r} = 
            inl f' = function {T} -> T, .nT | nT -> nT, .T
            inl (A,TA),(B,TB) = f' data, f' weight
            inl out = adjoint out
            on_non_nil (inl A -> 
                l.wait_on s.data.stream
                inl s = s.data_add {stream=l}
                match TA with
                | .T -> s.CudaBlas.gemm' .nT TB one out.basic (primal B .basic) one A.basic
                | .nT -> s.CudaBlas.gemm' .nT TB one (primal B .basic) out.basic one A.basic
                ) (adjoint A)
            on_non_nil (inl B -> 
                r.wait_on s.data.stream
                inl s = s.data_add {stream=r}
                match TB with
                | .T -> s.CudaBlas.gemm' TA .nT one (primal A .basic) out.basic one B.basic
                | .nT -> s.CudaBlas.gemm' TA .nT one out.basic (primal A .basic) one B.basic
                ) (adjoint B)
            
            inl update k data = 
                match d with 
                | {$k={covariance k}} ->
                    update_covariance (basic data) (basic covariance) s 
                    k := k() + (basic out).span_outer
                | _ -> ()
            update .front (primal data)
            update .back out
            

        inl l = Struct.map init l
        Struct.iter run l
        Struct.iter (inl {streams=l,r} -> s.data.stream.wait_on l) l
        inl out = Struct.map (inl {out} -> out) l
        {
        out
        bck=met _ ->
            Struct.iter bck l
            Struct.iter (inl {streams=x} -> Tuple.iter s.data.stream.wait_on x) l
        }

    inl activation {fwd bck} (!(View.zip) in) s =
        inl v = in.dim
        inl in = in.basic
        inl out = s.CudaFun.map {map=fwd} (primals in) |> View.wrap v |> dr s
        
        {
        out
        bck=met _ ->
            if Struct.is_empty (adjoints in .elem_type) = false then
                inl ins = to_dev_tensor {in out}
                s.CudaKernel.iter {dim=in.dim} <| inl i ->
                    inl {in out} = Struct.map' (inl x -> x i) ins
                    inl x = bck {in=primals in .get; out=primal out .get}
                    inl out = adjoint out .get
                    adjoints in .modify' (inl in x -> in + out * x) x
        }

    /// Takes in an `out` argument. Stopping to gather a scalar so it can be accumulated is actually expensive enough that
    /// this optimization is worth it.
    inl error {fwd bck out} (!(View.zip) in) s =
        assert (out.dim = (1 :: ())) "The `out` needs to be 1d singleton tensor."
        inl in = in.basic |> to_dev_tensor
        inl out = out.basic |> to_dev_tensor
        s.CudaKernel.redo {
            redo=(+); dim=in.dim;
            init=inl i -> 
                inl in = in i
                inl adj, in = adjoints in, primals in .get
                adj .modify' (inl in x -> in + x) (bck {in}) // The adjoint is assumed to be 1 for cost functions.
                fwd in
            outit=inl i x -> 
                inl out = out i
                out .set (out .get + x)
            }

    inl init {dim} init s =
        inl out =
            open CudaAD
            inl init cur =
                (init cur >>= succ) .out
                |> Struct.map (function
                    | {adjoint} as x -> {x with adjoint=adjoint 0}
                    | x -> x
                    )
            s.CudaFun.init {dim} init
            |> View.wrap dim
        
        {
        out
        bck=met _ ->
            inl from = to_dev_tensor (adjoints out)
            open CudaAD
            s.CudaKernel.iter {dim} <| inl cur -> 
                inl {out bck} = init cur >>= succ
                inl {bck=bck'} = link_adjoint cur {from to=adjoints out}
                bck(); bck'()
        }

    inl mapi_template dim f in s =
        inl in = to_dev_tensor in
        open CudaAD
        init {dim} (inl cur -> link_auto dim in cur >>= f cur) s

    inl mapi f in s =
        inl dim = Tensor.assert_broadcastable in
        assert (Tuple.exists (function {} -> true | _ -> false) dim = false) "Tree views are not allowed in mapi."
        mapi_template dim f in s

    inl map f in = mapi_template (Tensor.assert_broadcastable in) (const f) in

    inl segmented_init {dim elem_type} init s =
        inl out =
            open CudaAD
            inl init = 
                Struct.map' (inl init cur -> 
                    (init cur >>= succ) .out
                    |> Struct.map (function
                        | {adjoint} as x -> {x with adjoint=adjoint 0}
                        | x -> x
                        )
                    ) init
            s.CudaFun.segmented_init {dim elem_type} init
        
        {
        out
        bck=met _ ->
            inl from = to_dev_tensor (adjoints out)
            open CudaAD
            s.CudaKernel.segmented_iter {dim} <| inl cur' -> 
                Struct.iter2' (inl cur init ->
                    inl {out bck} = init cur >>= succ
                    inl {bck=bck'} = link_adjoint cur' {from to=adjoints out}
                    bck(); bck'()
                    ) cur' init
        }

    inl rec unify_dual = // Note that if `s < r` then this unification won't be right, but a type error will occur in the kernel instead so it is fine.
        Struct.map2 (inl s r ->
            match s,r with
            | {primal adjoint}, {primal adjoint} ->
                assert (eq_type s r) "The two structures must be the same type."
                s
            | {primal adjoint}, _ ->
                assert (eq_type primal r) "The two structures must be the same type."
                s
            | _, {primal adjoint} ->
                assert (eq_type s primal) "The two structures must be the same type."
                r
            | _, _ ->
                assert (eq_type s r) "The two structures must be the same type."
                s
            )

    inl upscale_scalar elem_type x =
        match elem_type with
        | {primal adjoint} -> const {primal=x; block=()}
        | _ -> const x

    inl load = to_dev_tensor >> CudaAD.link
    inl loadb = to_dev_tensor >> CudaAD.link_broadcast
    inl loada dim = to_dev_tensor >> CudaAD.link_auto dim

    inl upscale_tensor elem_type x =
        Struct.map2 (inl elem_type x ->
            match elem_type, x with
            | {primal adjoint}, {primal adjoint} -> x
            | {primal adjoint}, _ -> {primal=x; block=()}
            | _ -> x
            ) elem_type
        |> x.update_body'
        |> load

    inl concat l =
        inl dim =
            Struct.foldl_map (inl s x -> 
                match x with
                | _ when val_is x -> 1, s
                | _ ->
                    inl b, a = x.dim
                    match s with
                    | () -> ()
                    | _ -> assert (s = b) "The outer dimensions of l must be equal."
                    a, b
                ) () l
            |> inl a, b -> b, a

        inl elem_type =
            Struct.foldl (inl s x ->
                inl r =
                    match x with
                    | x when val_is x -> type x
                    | x -> x.elem_type
                match s with
                | () -> r
                | _ -> unify_dual s r
                ) () l

        inl init =
            Struct.map (inl x ->
                match x with
                | x when val_is x -> upscale_scalar elem_type x
                | x -> upscale_tensor elem_type x
                ) l

        segmented_init {dim elem_type} init

    inl init_seq {dim} init s =
        inl out = 
            s.CudaFun.init_seq {dim} <| inl b k -> init b k .out
            |> View.wrap dim
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

    inl seqi f in s =
        inl dim = Tensor.assert_broadcastable in
        inl in = to_dev_tensor (Struct.map (inl x -> x.basic) in)
        open CudaAD
        init_seq {dim} (inl b k -> 
            inl Seq = Seq k
            Seq.link_auto dim in b >>= f b k
            ) s

    inl seq f = seqi (const f)

    inl Primitive =
        {
        activation error segmented_init concat mapi map
        init_seq seq seqi
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

    inl print x s = {out=s.CudaTensor.print (primal x); bck=()}
    inl print_bck x s = {out=(); bck=inl _ -> s.CudaTensor.print (adjoint x)}

    inl ln_relu = seq <| inl k -> 
        open CudaAD
        open Seq k .Op
        layer_norm >> relu

    inl linear = succ
    inl Activation = { linear sigmoid tanh relu add hadmult hadmultb ln_relu} |> stack

    // #Optimizer
    inl sgd s x =
        inl rate = s.data.rate.weight
        inl out = x.basic
        s.CudaFun.map {out map=inl {primal adjoint} -> {primal=primal - rate * adjoint; adjoint=zero}} out

    met kfac {weights} s =
        inl rate = s.data.rate.weight
        inl k_max = 128

        inl factor {d with k epsilon covariance precision sampling} =
            if k() >= k_max then
                k := 0
                inl {covariance precision sampling} = Struct.map (inl x -> x.basic) {covariance precision sampling}
                s.CudaSolve.regularized_cholesky_inverse {epsilon covariance precision sampling}

        Struct.iter (function
            | {d with weight} ->
                
                inl reproject a b ret =
                    inb x = s.CudaBlas.gemm .nT .nT one a.basic b.basic |> CudaAux.temporary
                    ret x

                inl reproject_to a b c = s.CudaBlas.gemm' .nT .nT -rate a.basic b.basic one c.basic 
                inl clear = s.CudaTensor.clear

                match d with
                | {front back} -> 
                    factor front; factor back
                    inb x = reproject front.precision (adjoint weight)
                    reproject_to x back.precision (primal weight)
                | {back} -> factor back; reproject_to (adjoint weight) back.precision (primal weight)
                | {front} -> factor front; reproject_to front.precision (adjoint weight) (primal weight)
                | _ -> s.CudaBlas.geam' .nT .nT -rate (adjoint weight .basic) one (primal weight .basic) (primal weight .basic)
                clear (adjoint weight .basic)
            | _ -> ()
            ) weights

    inl standard s x =
        Struct.iter (function
            | {optimize weights} -> join
                inl weights = Struct.map' (inl x -> x.data) weights
                optimize {weights} s
            | {weights} -> join
                Struct.iter (function {weight} -> sgd s weight.data | _ -> ()) weights
            ) x

    inl Optimizer = {sgd standard kfac}

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
        inb boundary = s.CudaRandom.create {dst=.Uniform} {elem_type=float; dim=b} |> CudaAux.temporary
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
    inl square {label out} x = 
        error {
            out
            fwd = inl {x y} -> (y - x) * (y - x)
            bck = inl {in={x y}} -> {x = two * (x - y); y = -(two * (x - y))}
            } {x y=label}

    inl sigmoid_cross_entropy {label out} x = 
        error {
            out
            fwd = inl {x y} -> 
                inl x = sigmoid_fwd x
                -(y * log x + (one - y) * log (one - x))
            bck = inl {in={x y}} -> 
                inl x = sigmoid_fwd x
                { x = x - y; y = log (one - x) - log x }
            } {x y=label}

    inl mutable_add_redo (!to_dev_tensor {out temp}) s =
        assert (out.dim = (1 :: ())) "The `out` needs to be 1d singleton tensor."
        s.CudaKernel.redo {
            redo=(+); dim=temp.dim
            init = inl i -> temp i .get
            outit = inl i x -> 
                inl out = out i
                out .set (out .get + x)
            }

    /// Applies a softmax and then calculates the cross entropy cost. Is intended to take the output of a linear layer as input.
    inl softmax_cross_entropy {label=!basic label; out} (!basic input) s =
        assert (label.dim = input.dim) "Labels and inputs must have equal dimensions."
        
        inl temp = one
        inl cost = s.CudaTensor.create {elem_type=float; dim=input .dim |> fst}
        inl _ =
            inl input, label, cost = to_dev_tensor (input, label, cost)
            s.CudaKernel.iter_seq {dim=input.dim}
                (inl b k ->
                    inl input,label,to = Tuple.map (inl x -> x b) (input, label, cost)
                    inl prob = softmax_body temp k (primal input)
                    inl label = k.block.load (primal label)

                    // Back
                    inl ret {map in} = 
                        on_non_nil <| inl to ->
                            k.block.store {
                                to from=k.block.map (inl {in out} -> out + map in) {in out=k.block.load to}
                                }
                    ret {in={prob label}; map=inl {prob label} -> (prob - label) / temp} (adjoint input)
                    ret {in=prob; map=inl prob -> -(log prob)} (adjoint label)

                    // Front
                    inl costs = k.block.map (inl {prob label} -> -label * log prob) {prob label}
                    k.block.store_scalar { to from = k.block.redo (+) costs }
                )

        mutable_add_redo {out temp=cost} s

    inl accuracy {label out} input s =
        inl input, label = primal input .basic, primal label .basic
        inl temp =
            s.CudaFun.map_redo {
                map=inl {in} -> in
                neutral_elem=-infinity,zero
                redo=inl a b -> if fst a > fst b then a else b
                map_out=inl {out=_,x} -> to int64 x
                } (input, label)
        mutable_add_redo {out temp} s

    inl Error = {square sigmoid_cross_entropy softmax_cross_entropy accuracy} |> stackify

    // #Initializer
    inl Initializer number =
        inl Init =
            met normal (!dyn {stddev mean}) (!dyn to) s = 
                inb from = s.CudaRandom.create {dst=.Normal; stddev mean} {elem_type=float; dim=to.dim} |> CudaAux.temporary
                inl {from to} = to_dev_tensor {from to}
                s.CudaKernel.iter {dim=to.dim} (inl i -> to i .set (from i .get))
            inl stddev_sum_init mult tns = 
                inl stddev = sqrt (mult / to float32 (Tuple.foldl (+) 0 tns.dim))
                inl mean = 0f32
                normal {stddev mean} tns

            met constant (!dyn init) (!dyn tns) s =
                inl tns = to_dev_tensor tns
                s.CudaKernel.iter {dim=tns.dim} (inl i -> tns i .set init)

            met identity (!dyn init) (!dyn tns) s =
                inl a,b as dim = tns.dim
                assert (a = b) "The tensor needs to be a square matrix."
                inl tns = to_dev_tensor tns
                s.CudaKernel.iter {dim} (inl a,b as i -> tns i .set (if a = b then init else zero))
            {
            // Rough and possibly poorly tuned inits. Recommended to be used together with KFAC.
            relu = stddev_sum_init 1f32
            sigmoid = stddev_sum_init 2f32
            tanh = stddev_sum_init 3f32
            randn = inl stddev -> normal {stddev mean=0f32}
            const = constant
            identity' = identity
            identity = identity one
            custom = inl f tns s -> f tns s
            }

        inl tensor_view_init init tns s =
            inl dim = tns.tree_dim
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
                inl tns = Tuple.rev apply |> tns |> basic
                init tns s

            Tuple.foldr f dim finally {init apply=()}

        inl tensor_view {init dim} s =
            inl tns = s.CudaTensor.create_view {dim elem_type=Struct.map' (const float) init} |> heap
            function
            | .data -> tns
            | .init -> 
                inl tns = dyn tns
                inl init = dyn init
                join Struct.iter2' (met init tns -> init tns s) init (View.unzip tns)
            | .save stream -> Struct.iter2' (inl f tns -> f stream tns s) d.save tns
            | .load stream -> Struct.iter2' (inl f tns -> f stream tns s) d.load tns

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

        inl sing {init dim} = tensor_view {init=tensor_view_init init; dim}
        inl dual {init dim} =
            inl primal = tensor_view_init init
            inl adjoint tns s = Init.const zero tns.basic s
            tensor_view {init={primal adjoint block=()}; dim}
            
        inl view = {sing dual} number

        { Init with view stream var val }

    inl Initializer = 
        {
        sing = Initializer.sing
        dual = Initializer.dual
        }

    inl init s size dsc = 
        Struct.foldl_map (inl sublayer_size {x with init} -> 
            indiv join
                inl {dsc size} = init sublayer_size
                inl weights = Struct.map' (inl x -> x s |> inl x -> x.init; x) dsc |> heap
                stack ({x without init with weights size}, size)
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
                    |> inl input -> apply input s 
                    |> module_map (const heap)
                    
            inl layer = match x with {bck} -> {layer with bck} | _ -> layer
            inl layer = match x with {state} -> {layer with state} | _ -> layer
            layer, out
            ) (heap input)

    inl sequence x s =
        inl x = Struct.map (inl x -> x s |> inl x -> {x with block=()}) x
        {
        out = Struct.map (inl {out} -> out) x
        bck = Struct.map (inl {bck} -> bck) x
        }

    inl covariance =
        inl {identity val var view} = Initializer.sing
        inl identity dim = view {init=identity; dim}
        inl epsilon !(View.span) x -> {covariance=identity (x, x); precision=identity (x, x); sampling=identity (x, x); epsilon=val epsilon; k=var 0}

    inl default_epsilon = to float (2.0 ** -3.0)

    inl weight {d with dim=b,a} = 
        open Initializer.dual
        {
        weight = view d
        streams = stream, stream
        front = covariance default_epsilon b
        back = covariance default_epsilon a
        stddev = val (one / (to float (View.span b)))
        block = ()
        }

    inl weight_sample {d with stddev weight front back} s =
        match s.data with
        //| {rate} ->
        //    inl random = s.CudaRandom.create {stddev dst=.Normal; mean=0f32} {elem_type=float; dim=weight.basic.dim}

        //    inb a = s.CudaBlas.trmm .Left .Lower .nT .NonUnit 1f32 front.sampling.basic random.basic |> CudaAux.temporary
        //    inb b = s.CudaBlas.trmm .Right .Lower .nT .NonUnit 1f32 back.sampling.basic a |> CudaAux.temporary

        //    { d with weight = View.zip {(View.unzip weight) with primal = (s.CudaBlas.geam' .nT .nT one self.basic one b.basic random; View.wrap weight.dim random)} }
        | _ ->
            d

    // #Feedforward
    inl layer activation size =
        {
        init = inl sublayer_size -> 
            open Initializer.dual
            inl outer = {bias=1; input=sublayer_size}
            inl init = {bias=const zero; input=relu}
            {
            dsc = 
                {
                weights = weight {init dim=outer,size}
                outer = val outer
                }
            size
            }

        apply = inl {d with weights={weights outer} input} s ->
            inl weights =
                match d with
                | {state={weights}} -> weights
                | _ -> weight_sample weights s
            inl apply = 
                inm data = concat {bias=one; input}
                matmult_stream {weights with data} >>= activation
            inl {out bck} = apply s
            {out state={weights}; bck}

        optimize = Optimizer.kfac
        block = ()
        }

    inl Feedforward =
        inl sigmoid = layer sigmoid
        inl relu = layer relu
        inl tanh = layer tanh
        inl linear = layer succ
        inl zero = layer succ
        inl ln_relu = layer ln_relu
        {sigmoid relu tanh linear zero ln_relu} |> stackify
   
    // #Recurrent
    inl rnn size =
        inl inner = size
        {
        init = inl sublayer_size -> 
            open Initializer.dual
            inl outer = {bias=1; input=sublayer_size; state=size}
            inl init = {bias=const zero; input=relu; state=relu}
            {
            dsc = 
                {
                weights = weight {init dim=outer,inner}
                }
            size
            }

        apply = inl {d with weights={weights} input} s -> 
            inl span = fst input.dim
            inl out, weights =
                match d with
                | {state={out weights}} -> out, weights
                | _ -> 
                    inl f _ = s.CudaTensor.zero_view {elem_type=float; dim=span,size}
                    f(), weight_sample weights s

            inl apply =
                inm out =
                    inm data = concat {bias=one; input; state=out}
                    matmult_stream {weights with data} >>= ln_relu
                succ {out state={out weights}}
            inl {out={out state} bck} = apply s
            {out state bck}
        optimize = Optimizer.kfac
        block = ()
        }

    inl RNN = {rnn}

    inl RL =
        /// The PG activation.
        inl sampling_pg x s =
            inl x = x.basic
            inl dim_a, dim_b = x .dim
            inl p = softmax one (primal x) s
            inl out = sample_body p s

            {
            out
            bck=inl {reward} ->
                inl reward = 
                    inl reward = primal reward
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

        inl ac_sample_action {policy trace value} s =
            inl {out bck} = sampling_pg policy s
            {
            out
            bck=inl discount d ->
                inl {out bck=bck'} = map (CudaAD.Activation.td discount) {d with trace value} s
                inl {value' error} = View.unzip out |> module_map (const View.zip)
                {
                out={reward=dyn zero; value'=value}
                bck=inl _ -> bck' (); bck {reward=error}
                }
            }

        inl ac size =
            inl inner = { policy=size; trace=1; value=1 }
            
            {
            init = inl sublayer_size ->
                open Initializer.dual
                inl outer = {bias=1; input=sublayer_size}
                inl init = {
                    bias = {policy=const zero; trace=const two; value=const zero}
                    input = {policy=const zero; trace=const zero; value=const zero}
                    }
                {
                dsc = { weights = weight {init dim=outer,inner} }
                size
                }

            apply = inl {d with weights={weights} input} s -> 
                inl apply =
                    inm data = concat {bias=one; input}
                    inm out = matmult_stream {weights with data}
                    succ (View.split out)

                inl {out bck} = apply s
                {out bck}
            optimize = Optimizer.kfac
            block = ()
            }

        /// For online learning.
        inl action {State Action final} {net input} s =
            indiv join
                assert (eq_type State input) "The input must be equal to the state type."
                inl input =
                    inl tns = Union.to_dense input |> Tensor.array_as_tensor
                    s.CudaTensor.from_host_tensor tns .reshape (inl x -> 1, Union.length_dense State)
                    |> View.wrap ((), ())

                inl net, input = run s input net
                inl {out bck} = final input s

                inl action = Union.from_one_hot Action (s.CudaTensor.get (out 0))
                stack {action net bck}
       
        {action ac ac_sample_action}

    inl Agent =
        inl basic_methods = {
            optimize = inl s ->
                inl {cd network} = s.data.buffer.last
                Optimizer.standard cd network
            truncate = inl s ->
                inl state = s.data.truncate s.data.buffer.last ()
                s.data.buffer.clear
                s.data.buffer.add state
            region_create = inl s ->
                s.data.region_create s.data.buffer.last ()
                |> s.data.buffer.add
            cd = inl s -> s.data.buffer.last |> inl {cd} -> join heap cd
            region_clear = inl s -> s.cd.RegionMem.clear
            region_create' = inl s ret ->
                s.region_create
                ret ()
                s.region_clear
            alloc_cost = inl s -> s.cd.CudaTensor.zero {elem_type=float32; dim=1}
            alloc_accuracy = inl s -> s.cd.CudaTensor.zero {elem_type=int64; dim=1}
            get = inl s -> Struct.map ((inl x -> x 0) >> s.cd.CudaTensor.get)
            }
        
        inl basic_infer = {
            truncate = {
                map = inl {network cd=cd'} _ -> join
                    inl cd = cd'.RegionMem.create
                    inl network = 
                        Struct.map (function
                            | {state} as d -> 
                                inl state = 
                                    Struct.map 
                                        (inl out -> out.update_body (inl {x with ar} -> cd.RegionMem.assign ar.ptr; x))
                                        (Struct.map primals {(indiv state) without weights})
                                    |> heap
                                {d without bck with state}
                            | d -> {d without bck}
                            ) network
                    cd'.RegionMem.clear
                    cd.refresh
                    heap {network cd}
                input = const ()
                block = ()
                }
            region_create = {
                map = inl {state with cd} _ -> join heap {(indiv state) with cd = cd.RegionMem.create}
                input = const ()
                block = ()
                }
            }

        // TODO: There should be a call to s.refresh somewhere in there.
        inl recurrent =
            inl methods = {basic_methods with
                initialize = inl s {rate network context error input} ->
                    inl cd = context
                    inl cd = cd.data_add {rate}
                    inl state = heap {network cd}
                    inl elem_type, funs =
                        Union.infer {basic_infer with
                            forward = {
                                map = inl {network cd} {input} -> join
                                    inl network, output = run cd input network
                                    inl bck = Struct.map (inl {bck} -> bck) network
                                    inl network = Struct.map (inl x -> {x without bck}) network
                                    inl final {label out} =
                                        match out with
                                        | {cost accuracy} ->
                                            error {label out=cost} output cd
                                            Error.accuracy {label out=accuracy} output cd
                                        | {cost} ->
                                            error {label out=cost} output cd
                                    heap {cd network bck final}
                                input = inl _ ->
                                    inl rec loop f = function
                                        | _ :: _ :: () -> f
                                        | _ :: next -> loop (f (dyn 0)) next
                                    {input=loop input input.dim}
                                block = ()
                                }
                            } state
                    inl buffer = ResizeArray.create {elem_type}
                    buffer.add state

                    s.data_add {funs with buffer}
                forward = inl s input ->
                    inl forward = s.data.forward s.data.buffer.last {input}
                    s.data.buffer.add forward
                cost = inl s {label out} ->
                    match s.data.buffer.last with
                    | {final} -> final {label out}
                    | _ -> ()
                backward = inl s ->
                    s.data.buffer.foldr (inl x _ ->
                        match x with
                        | {bck} -> join Struct.foldr (inl bck _ -> bck(); ()) bck ()
                        | _ -> ()
                        ) ()
                }
            Object.member_add methods

        inl rl =
            inl methods = {basic_methods with
                initialize = inl s {rate discount network context Action Observation} ->
                    inl input_size = Union.length_dense Observation
                    inl num_actions = Union.length_one_hot Action

                    inl cd = context
                    inl cd = cd.data_add {rate}
                    inl state = heap {network cd}
                    inl elem_type, funs =
                        Union.infer {basic_infer with
                            forward = {
                                map = inl {network cd} {input} -> join
                                    assert (eq_type Observation input) "The input must be equal to the Observation type."
                                    inl input =
                                        inl tns = Union.to_dense input |> Tensor.array_as_tensor
                                        cd.CudaTensor.from_host_tensor tns .reshape (inl x -> 1, Union.length_dense Observation)
                                        |> View.wrap ((), ())
                                    inl network, out = run cd input network
                                    inl bck = Struct.map (inl {bck} -> bck) network
                                    inl network = Struct.map (inl x -> {x without bck}) network
                                    inl {out bck=final} = RL.ac_sample_action out cd
                                    inl final = final discount
                                    inl action = Union.from_one_hot Action (cd.CudaTensor.get (out 0))
                                    heap {cd network bck final action}
                                input = inl _ -> {input=var Observation}
                                block = ()
                                }
                            reward = {
                                map = inl {network cd} {reward} -> join
                                    assert (eq_type reward float) "The reward needs to be a float type."
                                    inl final {reward=reward' value'} = 
                                        {
                                        out = {reward=reward+reward'; value'}
                                        bck = const ()
                                        }
                                    heap {network cd final}
                                input = inl _ -> {reward=var float}
                                block = ()
                                }
                            } state
                    inl buffer = ResizeArray.create {elem_type}
                    buffer.add state

                    inl types = {Action Observation}
                    s.data_add {funs with buffer types}
                act = inl s input ->
                    inl forward = s.data.forward s.data.buffer.last {input}
                    s.data.buffer.add forward
                    match forward with
                    | {action} -> action
                    | _ -> failwith s.data.types.Action "The Action branchs should be impossible."
                reward = inl s (!dyn reward) ->
                    s.data.reward s.data.buffer.last {reward}
                    |> s.data.buffer.add
                backward = inl s ->
                    s.data.buffer.foldr' ignore (inl next x out ->
                        match x with
                        | {final} ->
                            inl {out bck} = final out
                            next out
                            bck ()
                        | _ ->
                            ()
                        ) {reward=dyn zero; value'=zero}

                    s.data.buffer.foldr (inl x _ ->
                        match x with
                        | {bck} -> join Struct.foldr (inl bck _ -> bck(); ()) bck ()
                        | _ -> ()
                        ) ()
                }
            Object.member_add methods

        {recurrent rl}

    { 
    dr primal primals adjoint adjoints (>>=) succ Primitive Activation Optimizer Initializer Error run init Feedforward RNN RL Agent
    }
    """
    }