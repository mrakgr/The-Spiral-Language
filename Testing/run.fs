#if INTERACTIVE
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsecCs.dll"
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsec.dll"
#r @"..\packages\ManagedCuda-CUBLAS.8.0.22\lib\net46\CudaBlas.dll"
#r @"..\packages\ManagedCuda-CURAND.8.0.22\lib\net46\CudaRand.dll"
#r @"Microsoft.CSharp"
#r @"..\The Spiral Language\bin\Release\The_Spiral_Language.dll"
#endif

open Spiral.Lib
open Spiral.Tests
open System.IO
open System.Diagnostics

let cfg = Spiral.Types.cfg_testing

let example = 
    "example",[],"Module description.",
    """
// https://gist.github.com/SimonDanisch/812e01d7183681ed414932c8f7b533d0#file-unroll-jl
// This is not quite the same as the above example, but Spiral's staging optimizations
// only work when code is written in a functionally pure manner. 

// `sin` currently is not a part of the core library so I use a macro to interop with it.
// If it were then this whole program would be evaluated at compile time.
// To see that, replace sin with tanh or sqrt for example.
// Spiral's semantics allow for any functionally pure computation at compile time.
inl sin x = macro.fs float64 [text:"sin"; args: x]

inl rec unroll f i s =
    assert (lit_is i) "i must be a literal."
    if i > 0 then unroll f (i-1) (f s) else s

inl test () =
    inl box = 1.0
    unroll sin 3 box

test ()

//let (var_0: float) = sin(1.000000)
//let (var_1: float) = sin(var_0)
//sin(var_1)
    """

let example2 =
    "example2",[tuple;console],"Module description.",
    """
inl rec foo n = 
    assert (lit_is n) "n must be known at compile time."
    assert (n >= 0) "n must greater or equal to zero."
    if n = 0 then ()
    else (if n % 2 = 0 then int32 else string) :: foo (n - 1)

inl stringify = function _: int32 -> "int" | _ : string -> "string"
foo 10 |> Tuple.map stringify |> Console.writeline
    """

let host_tensor =
    (
    "HostTensor",[tuple;struct';loops;extern_;console;liple],"The HostTensor module.",
    """
// A lot of the code in this module is made with purpose of being reused on the Cuda side.
// Despite its name, it can be overloaded to work inside Cuda kernels by passing a different `array_create` as argument into `create`.
inl rec view_offsets offset = function
    | s :: s', i :: i' -> s * i + view_offsets offset (s', i')
    | _, () -> offset

inl tensor_view {data with size offset} i' = {data with offset = view_offsets offset (size,i')}
inl tensor_get {data with offset ar} = ar offset
inl tensor_set {data with offset ar} v = ar offset <- v
inl tensor_apply i {data with size=s::size offset} = {data with size offset=offset + i * s}

inl show' {cutoff_near_to} tns = 
    open Extern
    inl strb_type = fs [text: "System.Text.StringBuilder"]
    inl s = FS.Constructor strb_type ()
    inl append x = FS.Method s .Append x strb_type |> ignore
    inl append_line x = FS.Method s .AppendLine x strb_type |> ignore
    inl indent near_to = Loops.for {from=0; near_to; body=inl _ -> append ' '}
    inl blank = dyn ""
    inl rec loop {tns ind cutoff} =
        inl from = 0
        match tns.dim with
        | () -> tns.get |> Extern.show |> append
        | near_to :: () ->
            indent ind; append "[|"
            inl cutoff =
                Loops.for' {from near_to state=blank,cutoff; finally=snd; body=inl {next state=prefix,cutoff i} -> 
                    if cutoff < cutoff_near_to then
                        append prefix
                        tns i .get |> Extern.show |> append
                        next (dyn "; ", cutoff+1)
                    else
                        append "..."
                        cutoff
                    }
            append_line "|]"
            cutoff
        | near_to :: x' ->
            indent ind; append_line "[|"
            inl cutoff =
                Loops.for' {from near_to state=cutoff; body=inl {next state=cutoff i} -> 
                    if cutoff < cutoff_near_to then
                        loop {tns=tns i; ind=ind+4; cutoff} |> next
                    else
                        indent ind; append_line "..."
                        cutoff
                    }
            indent ind; append_line "|]"
            cutoff

    loop {tns; ind=0; cutoff=dyn 0} |> ignore
    FS.Method s .ToString() string

inl show = show' {cutoff_near_to=1000}

/// Total tensor size in elements.
inl length = Liple.foldl (*) 1

/// Splits a tensor's dimensions. Works on non-contiguous tensors.
/// Given the tensor dimensions (a,b,c) and a function which maps them to (a,(q,w),c)
/// the resulting tensor dimensions come out to (a,q,w,c).
inl split f tns =
    inl rec concat = function
        | d :: d', n :: n' -> 
            inl next = concat (d',n')
            match n with
            | _ :: _ -> 
                assert (d = length n) "The length of the split dimension must be equal to that of the previous one."
                Tuple.append n next
            | _ -> 
                assert (d = n) "The span on the new dimension must be equal to that of the previous one."
                n :: next
        | d', () -> d'

    inl rec update_size = function
        | init :: s', dim :: x' ->
            inl next = update_size (s', x')
            match dim with
            | _ :: _ ->
                inl _ :: size = Tuple.scanr (*) dim init
                Tuple.append size next
            | _ -> init :: next
        | s', () -> s'

    match tns.dim with
    | () ->
        inl f = Tuple.wrap f
        assert (length f = 1) "The length of new dimensions for the scalar tensor must be 1."
        tns .set_dim f .update_body (inl d -> {d with size=f})
    | dim ->
        inl dim' =
            inl rec wrapped_is = function
                | (_ :: _) :: _ -> true
                | _ :: x' -> wrapped_is x'
                | _ -> false
            
            match dim with
            | dim :: () -> dim
            | dim -> Tuple.map dim
            |> f |> inl x -> if wrapped_is x then x else x :: ()

        tns .set_dim (concat (dim, dim'))
            .update_body (inl d -> {d with size=update_size (self,dim')})

/// Flattens the tensor to a single dimension.
inl flatten tns =
    match tns.dim with
    | () -> tns
    | dim ->
        tns .set_dim (length dim)
            .update_body (inl {d with size} ->
                Tuple.zip (dim,size)
                |> Tuple.reducel (inl d,s d',s' ->
                    assert (s = d' * s') "The tensor must be contiguous in order to be flattened."
                    d*s, s'
                    )
                |> inl _,s -> {d with size=s :: ()}
                )

/// Flattens and then splits the tensor dimensions.
inl reshape f tns = split (inl _ -> tns.dim |> Tuple.unwrap |> f) (flatten tns)

inl rec facade data = 
    inl methods = stack {
        length = inl {data with dim} -> length dim
        elem_type = inl {data with bodies} -> Struct.map (inl {ar} -> ar.elem_type) bodies
        update_body = inl {data with bodies} f -> {data with bodies=Struct.map f bodies} |> facade
        set_dim = inl {data with dim} dim -> {data with dim} |> facade
        get = inl {data with dim bodies} -> 
            match dim with
            | () -> Struct.map tensor_get bodies
            | _ -> error_type "Cannot get from tensor whose dimensions have not been applied completely."
        set = inl {data with dim bodies} v ->
            match dim with
            | () -> Struct.iter2 (inl v bodies -> tensor_set bodies v) v bodies
            | _ -> error_type "Cannot set to a tensor whose dimensions have not been applied completely."
        /// Applies the tensor. `i` can be a tuple.
        apply = inl data i ->
            inl rec loop data i =
                match i with
                | () -> data
                | i :: i' ->
                    match data.dim with
                    | () -> error_type "Cannot apply the tensor anymore."
                    | near_to :: dim ->
                        inl rest from = loop {data with bodies=Struct.map (tensor_apply from) self; dim} i'
                        inl view from near_to =
                            inl size = Struct.map (inl {size=s::_} -> s) data.bodies
                            {(rest from) with bodies=Struct.map2 (inl size ar -> {ar with size=size :: self}) size self; dim=near_to - from :: self}

                        match i with
                        | {from=from'} ->
                            assert (from' >= 0 && from' < near_to) "Argument out of bounds." 
                            inl check near_to' =
                                assert (near_to' > 0 && near_to' <= near_to) "Higher boundary out of bounds." 
                                assert (from' < near_to') "The view must be positive."
                                view from' near_to'
                            match i with
                            | {near_to=near_to'} -> check near_to'
                            | {by} -> check (from' + by)
                            | _ -> view from' near_to
                        | () -> view 0 near_to 
                        | from' -> 
                            assert (from' >= 0 && from' < near_to) "Argument out of bounds." 
                            rest from'
            loop data (Tuple.wrap i) |> facade
        /// Returns the tensor data.
        unwrap = id
        /// Returns an empty tensor of the same dimension.
        empty = inl data -> facade {data with bodies=()}
        span_outer = inl {dim} -> match dim with () -> 1 | x :: _ -> x
        span_outer2 = inl {dim=a::b::_} -> a * b
        span_outer3 = inl {dim=a::b::c::_} -> a * b * c
        split = inl data f -> split f (facade data)
        flatten = inl data -> flatten (facade data)
        reshape = inl data f -> reshape f (facade data)
        // Rounds the dimension to the multiple.
        round = inl data mult -> view_span data (inl x :: _ | x -> x - x % mult) |> facade
        // Rounds the dimension to a multiple and splits it so that the outermost dimension becomes the multiple.
        round_split = inl data mult -> facade data .round mult .split (inl x :: _ | x -> mult,x/mult)
        // Rounds the dimension to a multiple and splits it so that the dimension next to the outermost becomes the multiple.
        round_split' = inl data mult -> facade data .round mult .split (inl x :: _ | x -> x/mult,mult)
        }

    function
    | .(_) & x -> 
        if module_has_member x data then data x
        else methods x data
    | i -> methods .apply data i

inl make_body {d with dim elem_type} =
    match dim with
    | () -> error_type "Empty dimensions are not allowed."
    | dim ->
        inl init =
            match d with
            | {pad_to} -> min 1 (pad_to / sizeof elem_type)
            | {last_size} -> last_size
            | _ -> 1
        inl len :: size = Tuple.scanr (*) dim init
        inl ar = match d with {array_create} | _ -> array_create elem_type len
        {ar size offset=0; block=()}

/// Creates an empty tensor given the descriptor. {size elem_type ?layout=(.toa | .aot) ?array_create ?pad_to} -> tensor
inl create {dsc with dim elem_type} = 
    inl create dim =
        inl dsc = {dsc with dim}
        inl bodies =
            inl layout = match dsc with {layout} -> layout | _ -> .toa
            inl create elem_type = make_body {dsc with elem_type}
            match layout with
            | .aot -> create elem_type
            | .toa -> Struct.map create elem_type

        facade {bodies dim}
    match dim with
    | () -> create (1 :: ()) 0
    | dim -> 
        inl dim = Tuple.wrap dim
        Tuple.iter (inl dim -> assert (dim > 0) "Dimensions of a tensor must be positive") dim
        create dim
    
/// Creates a new tensor based on given sizes. Takes in a setter function. 
/// ?layout -> size -> f -> tensor.
inl init = 
    inl body layout size f = 
        inl dim = Tuple.wrap size
        inl elem_type = type (Tuple.foldl (inl f _ -> f 0) f dim)
        inl tns = create {elem_type dim layout}
        inl rec loop tns f = 
            match tns.dim with
            | near_to :: _ -> Loops.for { from=0; near_to; body=inl {i} -> loop (tns i) (f i) }
            | () -> tns .set f
        loop tns f
        tns
    function
    | .aot  -> body .aot
    | size -> body .toa size

/// Maps the elements of the tensor. (a -> b) -> a tensor -> b tensor
inl map f tns =
    inl size = tns.dim
    inl rec loop tns = function
        | _ :: x' -> inl x -> loop (tns x) x' 
        | () -> f (tns .get)
    
    init size (loop tns size)

/// Copies a tensor. tensor -> tensor
inl copy = map id

/// Asserts the tensor size. Useful for setting those values to statically known ones. 
/// Does not copy. size -> tensor -> tensor.
inl assert_size dim' tns = 
    assert (tns.dim = dim') "The dimensions must match."
    tns.set_dim dim'

/// Reinterprets an array as a tensor. Does not copy. array -> tensor.
inl array_as_tensor ar = facade {dim=array_length ar; bodies={ar size=1::(); offset=0; block=()}}

/// Reinterprets an array as a tensor. array -> tensor.
inl array_to_tensor = array_as_tensor >> copy

/// Asserts that all the dimensions of the tensors are equal. Returns the dimension of the first tensor if applicable.
/// tensor structure -> (tensor | ())
inl assert_zip l =
    Struct.foldl (inl s x ->
        match s with
        | () -> x
        | s -> assert (s.dim = x.dim) "All tensors in zip need to have the same dimensions"; s) () l

/// Zips all the tensors in the argument together. Their dimensions must be equal.
/// tensor structure -> tensor
inl zip l = 
    match assert_zip l with
    | () -> error_type "Empty inputs to zip are not allowed."
    | tns -> facade {(tns.unwrap) with bodies=Struct.map (inl x -> x.bodies) l}

/// Unzips all the elements of a tensor.
/// tensor -> tensor structure
inl unzip tns =
    inl {bodies dim} = tns.unwrap
    Struct.map (inl bodies -> facade {bodies dim}) bodies

/// Are all subtensors structurally equal?
/// tensor structure -> bool
inl rec equal (!zip t) =
    match t.dim with
    | near_to :: _ ->
        Loops.for' {from=0; near_to state=true; body=inl {next i} ->
            equal (t i) && next true
            }
    | _ -> 
        inl a :: b = t.get
        Tuple.forall ((=) a) b

/// Asserts that the tensor is contiguous.
inl assert_contiguous = flatten >> ignore
/// Asserts that the dimensions of the tensors are all equal.
inl assert_dim l = assert_zip >> ignore
/// Prints the tensor to the standard output.
met print (!dyn x) = 
    match x with
    | {cutoff input} -> show' {cutoff_near_to=cutoff} input
    | x -> show x 
    |> Console.writeline

/// Creates a tensor from a scalar.
/// x -> x tensor
inl from_scalar x =
    inl t = create {dim=(); elem_type=type x}
    t .set x
    t

{
create facade init copy assert_size array_as_tensor array_to_tensor map zip show print length
equal split flatten assert_contiguous assert_dim reshape unzip from_scalar
} |> stackify
    """) |> Spiral.Types.module_

let test96 =
    "test96",[host_tensor;console],"Does the show from HostTensor work?",
    """
open HostTensor
init (2,3,4) (inl a b c -> a*b*c)  
|> show |> Console.writeline
    """

let test97 =
    "test97",[host_tensor],"Does the view indexing work?",
    """
open HostTensor
inl w = 2,3,4
init (2,3,4) (inl a b c -> a*b*c) (1,{from=1},{from=1; by=2})
|> show |> Console.writeline
    """

let view_host_tensor =
    (
    "ViewHostTensor",[tuple;host_tensor],"Views for the tensor.",
    """
inl rec facade data = 
    inl methods = stack {
        length = inl {data with basic} -> basic.length
        elem_type = inl {data with basic} -> basic.elem_type
        update_body = inl data f -> {data with basic=self.update_body f} |> facade
        get = inl {data with basic} -> basic.get
        set = inl {data with basic} v -> basic.set v
        // Applies the tensor. `i` can be a tuple.
        apply = inl data i ->
            inl rec loop data i =
                match i with
                | () -> ()
                | i :: i' ->
                    match data.dim with
                    | () -> error_type "Cannot apply the tensor anymore."
                    | branch :: dim -> 
                        inl apply b =
                            inl a', b' = loop {data with dim} i'
                            a', b :: b'
                        inl view a b = 
                            inl a', b' = loop {data with dim} i'
                            a :: a', b :: b'

                        // The view tensor support two kinds of views.
                        match branch with
                        | {} -> Tree view
                            inl rec loop branch i =
                                match branch with
                                | {from near_to} -> // Tree view's leaf - the ranges start at zero.
                                    match i with
                                    | () -> view 0 {from near_to} // Only () is supported for the sake of simplicity for now.
                                | _ -> // Tree view's branch
                                    match i with
                                    | () -> view branch i
                                    | _ ->
                                        inl {c k i} = module_foldl (inl s k x -> {s with c=self+1; k x}) {c=0} i
                                        assert (c = 1) "The number of branches indexed into must be 1."
                                        loop (branch k) i
                            loop branch i
                        | from -> // Range view
                            match i with
                            | {from=from'} ->
                                match i with
                                | {near_to=near_to'} -> view 0 {from=from'-from; near_to=near_to'-from}
                                | {by} -> view 0 {from=from'-from; by}
                                | _ -> view 0 {from=from'-from}
                            | () -> view from ()
                            | from' -> apply (from'-from)
            inl dim, apply = loop data (Tuple.wrap i)
            inl basic = data.basic apply
            facade {data with basic dim}

        /// Returns the tensor data.
        unwrap = id
        }

    function
    | .(_) & x -> 
        if module_has_member x data then data x
        else methods x data
    | i -> methods .apply data i

inl map_dim = function
    | {from near_to} -> 
        inl s = near_to - from
        assert (0 < s) "The size must be a positive value."
        s, from
    | {} as x -> // Tree view
        inl rec loop from = function
            | {} as x -> 
                module_foldl (inl (from,m) k x -> 
                    inl near_to, x = loop from x
                    near_to, {m with $k=x}
                    ) (from, {}) x
            | size: int64 ->  
                inl near_to=from+size
                assert (from < near_to) "The size must be a positive value."
                near_to, {from near_to}
            | _ -> error_type "The tree's leaves must be integer values and branches must be modules."
        loop 0 x
    | _ -> error_type "Expected a range or a tree view."
        
inl create {dsc with dim} = 
    inl size, dim = Tuple.map map_dim (Tuple.wrap dim) |> Tuple.unzip
    inl basic = HostTensor.create {dsc with dim}
    facade {basic dim}

inl wrap dim basic =
    inl size, dim = Tuple.map map_dim (Tuple.wrap dim) |> Tuple.unzip
    assert (basic.dim = size) "The view must be of the same size as the tensor it is wrapping."
    facade {basic dim}

{
facade create wrap
} |> stackify
    """
    ) |> Spiral.Types.module_

let test113 =
    "test113",[view_host_tensor;console],"Do the tensor views work?",
    """
inl tns =
    HostTensor.init (2,3,4) (inl a b c -> a*b*c)  
    |> ViewHostTensor.wrap ({from=2; near_to=4},{from=2; near_to=5},{from=2; near_to=6}))

tns (3,4,5) .get |> Console.writeline
    """

//rewrite_test_cache tests cfg None //(Some(0,40))
output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) test113
|> printfn "%s"
|> ignore
