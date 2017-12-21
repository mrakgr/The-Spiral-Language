module Spiral.Lib
open CoreLib
open Main

let option =
    (
    "Option",[],"The Option module.",
    """
inl Option x = (type (.Some, x)) \/ (type (.None))

inl some x = box (Option x) (.Some, x)
inl none x = box (Option x) (.None)

{Option some none}
    """) |> module_

let lazy_ =
    (
    "Lazy",[option],"The Lazy module.",
    """
inl lazy f =
    met f x = f x
    inl ty = type (f ())
    inl x = Option.none ty |> ref
    function
    | .value -> join (
        match x() with
        | .None ->
            inl r = f()
            x := Option.some r
            r
        | .Some, r -> r
        )
    | .elem_type -> ty

{lazy}
    """) |> module_

let tuple =
    (
    "Tuple",[],"Operations on tuples.",
    """
inl singleton x = x :: ()
inl head = function
    | x :: xs -> x
inl tail = function
    | x :: xs -> xs

inl wrap = function
    | (_ :: _ | ()) as x -> x
    | x -> x :: ()

inl rec foldl f s = function
    | x :: xs -> foldl f (f s x) xs
    | () -> s

inl rec foldr f l s = 
    match l with
    | x :: xs -> f x (foldr f xs s)
    | () -> s

inl reduce f l =
    match l with
    | x :: xs -> foldl f x xs
    | () -> error_type "Reduce must receive a non-empty tuple as input."

inl rec scanl f s = function
    | x :: xs -> s :: scanl f (f s x) xs
    | () -> s :: ()

inl rec scanr f l s = 
    match l with
    | x :: xs -> 
        inl r = scanr f xs s
        f x (head r) :: r
    | () -> s :: ()

inl append = foldr (::)

inl rev, map =
    inl map' f l = foldl (inl s x -> f x :: s) () l
    inl rev l = map' id l
    inl map f = map' f >> rev
    rev, map

inl iter f = foldl (const f) ()
inl iteri f = foldl f 0

inl rec iter2 f a b = 
    match a,b with
    | a :: as', b :: bs' -> f a b; iter2 f as' bs'
    | (), () -> ()
    | _ -> error_type "The two tuples have uneven lengths." 

inl rec forall f = function
    | x :: xs -> f x && forall f xs
    | () -> true

inl rec exists f = function
    | x :: xs -> f x || exists f xs
    | () -> false

inl rec filter f = function
    | x :: xs -> if f x then x :: filter f xs else filter f xs
    | () -> ()

inl is_empty = function
    | _ :: _ -> false
    | () -> true
    | _ -> error_type "Not a tuple."

inl is_non_empty_tuple = function
    | _ :: _ -> true
    | _ -> false

inl transpose l on_fail on_succ =
    inl rec loop acc_total acc_head acc_tail l = 
        match l with
        | () :: ys ->
            match acc_head with
            | () when forall is_empty ys ->
                match acc_total with
                | _ :: _ -> rev acc_total |> on_succ
                | () -> error_type "Empty inputs in the inner dimension to transpose are invalid."
            | _ -> on_fail()
        | (x :: xs) :: ys -> loop acc_total (x :: acc_head) (xs :: acc_tail) ys
        | _ :: _ -> on_fail ()
        | () -> 
            match acc_tail with
            | _ :: _ -> loop (rev acc_head :: acc_total) () () (rev acc_tail)
            | () -> rev acc_total |> on_succ
    loop () () () l

inl zip_template on_ireg l = 
    inl rec zip = function // when forall is_non_empty_tuple l 
        | _ :: _ as l -> transpose l (inl _ -> on_ireg l) (map (function | x :: () -> zip x | x -> x))
        | () -> error_type "Zip called on an empty tuple."
        | _ -> error_type "Zip called on a non-tuple."
    zip l

inl regularity_guard l =
    if forall is_empty l then l
    else error_type "Irregular inputs in unzip/zip."
inl zip = zip_template regularity_guard
inl zip' = zip_template id

inl rec unzip_template on_irreg l = 
    inl rec unzip = function
        | _ :: _ as l when forall is_non_empty_tuple l -> transpose (map unzip l) (inl _ -> on_irreg l) id 
        | _ :: _ -> l
        | () -> error_type "Unzip called on an empty tuple."
        | _ -> error_type "Unzip called on a non-tuple."
    unzip l

inl unzip = unzip_template regularity_guard
inl unzip' = unzip_template id

inl init_template k n f =
    inl rec loop n = 
        match n with 
        | n when n > 0 -> 
            inl n = n - 1
            f n :: loop n
        | 0 -> ()
        | _ -> error_type "The input to this function cannot be static or less than 0 or not an int."
    loop n |> k

inl init = init_template rev
inl repeat n x = init_template id n (inl _ -> x)
inl range (min,max) = 
    inl l = max-min+1
    if l > 0 then init l ((+) min)
    else error_type "The inputs to range must be both static and the length of the resulting tuple must be greater than 0."

inl rec tryFind f = function
    | x :: xs -> if f x then .Some, x else tryFind f xs
    | () -> .None

inl rec contains t x = 
    match tryFind ((=) x) t with
    | .Some, x -> true
    | .None -> false

inl rec intersperse sep = function
    | _ :: () as x -> x
    | x :: xs -> x :: sep :: intersperse sep xs
    | _ -> error_type "Not a tuple."

{head tail foldl foldr reduce scanl scanr rev map iter iteri iter2 forall exists 
 filter zip unzip init repeat append singleton range tryFind contains intersperse wrap}
    """) |> module_

let loops =
    (
    "Loops",[tuple],"Various imperative loop constructors module.",
    """
inl rec while {cond body state} as d =
    inl loop_body {state cond body} as d =
        if cond state then while {d with state=body state}
        else state
    match d with
    | {static} -> loop_body d
    | _ -> (met _ -> loop_body d : state) ()

inl for_template kind {d with body} =
    inl finally =
        match d with
        | {finally} -> finally
        | _ -> id

    inl state = 
        match d with
        | {state} -> state
        | _ -> ()

    inl check =
        match d with
        | {near_to} from -> from < near_to 
        | {to} from -> from <= to
        | {down_to} from -> from >= down_to
        | {near_down_to} from -> from > near_down_to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` needs be present."

    inl from =
        match d with
        | {from=(!dyn from) ^ static_from=from} -> from
        | _ -> error_type "Only one of `from` and `static_from` field to loop needs to be present."

    inl to =
        match d with
        | {(to ^ near_to ^ down_to ^ near_down_to)=to} -> to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` is allowed."

    inl by =
        match d with
        | {by} -> by
        | {to | near_to} -> 1
        | {down_to | near_down_to} -> -1

    inl rec loop {from state} =
        inl body {from} = 
            if check from then 
                match kind with
                | .Standard ->
                    loop {state=body {state i=from}; from=from+by}
                | .CPSd ->
                    inl next state = loop {state from=from+by}
                    body {next state i=from}
            else finally state

        if Tuple.forall lit_is (from,to,by) then body {from}
        else 
            inl from = dyn from
            join (body {from} : finally state)

    loop {from state}

inl for' = for_template .CPSd
inl for = for_template .Standard

{for for' while}
    """) |> module_

let extern_ =
    (
    "Extern",[tuple;loops],"The Extern module.",
    """
inl dot = "."
inl FS = {
    Constant = inl a t -> !MacroFs(t, [text: a])
    StaticField = inl a b t -> !MacroFs(t, [
        type: a
        text: dot
        text: b
        ])
    Field = inl a b t -> !MacroFs(t, [
        arg: a
        text: dot
        text: b
        ])
    Method = inl a b c t -> !MacroFs(t, [
        arg: a
        text: dot
        text: b
        args: c
        ])
    StaticMethod = inl a b c t -> !MacroFs(t, [
        type: a
        text: dot
        text: b
        args: c
        ])
    Constructor = inl a b -> !MacroFs(a, [
        type: a
        args: b
        ])
    UnOp = inl op a t -> !MacroFs(t,[
        text: op
        text: " "
        arg: a
        ])
    BinOp = inl a op b t -> !MacroFs(t,[
        arg: a
        text: op
        arg: b
        ])
    }

inl closure_of_template check_range = 
    inl rec loop f tys =
        match tys with
        | x => xs -> term_cast (inl x -> loop (f x) xs) x
        | x when check_range && eq_type f x = false -> error_type "The tail of the closure does not correspond to the one being casted to."
        | _ -> f
    loop

inl closure_of' = closure_of_template false
inl closure_of = closure_of_template true

inl (use) a b =
    inl r = b a
    FS.Method a .Dispose() unit
    r

// Optimized to do more work at compile time. Will flatten nested tuples.
inl string_concat sep = 
    inl rec loop x = 
        Tuple.foldr (inl x {state with dyn stc} ->
            match x with
            | _ :: _ -> loop x state
            | x when lit_is x -> {state with stc=x::stc}
            | x -> 
                match stc with
                | _ :: _ -> {dyn=x :: string_concat sep stc :: dyn; stc=()}
                | _ -> {dyn=x :: dyn; stc=()}
            ) x
    function
    | _ :: _ as l ->
        inl {dyn stc} = loop l {dyn=(); stc=()}
        Tuple.append stc dyn |> string_concat sep
    | x -> x

inl rec show' cfg =
    inl show x = show' cfg x
    met show_array !dyn (array_cutoff, ar) = 
        inl strb_type = fs [text: "System.Text.StringBuilder"]
        inl s = FS.Constructor strb_type ()
        inl append x = FS.Method s .Append x strb_type |> ignore

        append "[|"
        Loops.for {from=0; near_to=min (array_length ar) array_cutoff; state=dyn ""; body=inl {state=prefix i} ->
            append prefix; append (show (ar i)); dyn "; "
            } |> ignore
        append "|]"
        FS.Method s .ToString() string
    inl show_tuple l = 
        Tuple.foldr (inl v s -> show v :: s) l ()
        |> string_concat ", "
        |> string_format "[{0}]"
    inl show_module m = 
        inl x = module_foldr (inl .(k) v s -> string_format "{0} = {1}" (k, show v) :: s) m () 
        string_format "{0}{1}{2}" ("{", string_concat "; " x, "}")
    
    function
    | {} as m -> show_module m
    | _ :: _ as l -> show_tuple l
    | (@array_is x) as ar ->
        match x with
        | .DotNetHeap -> 
            inl array_cutoff = match cfg with {array_cutoff} -> array_cutoff | _ -> FS.Constant "System.Int64.MaxValue" int64
            show_array (array_cutoff, ar)
        | .DotNetReference -> show (ar ())
    | x -> cfg.show_value x

inl show_value = string_format "{0}"
inl show = show' {array_cutoff = 30; show_value}

inl assert c msg =
    if c = false then
        if lit_is c then error_type msg
        else failwith unit (show msg)

{string_concat closure_of closure_of' FS (use) show' show assert} |> stack
    """) |> module_


let array =
    (
    "Array",[tuple;loops],"The array module",
    """
open Loops

/// Creates an empty array with the given type.
/// t -> t array
inl empty t = array_create t 0

/// Creates a singleton array with the given element.
/// x -> t array
inl singleton x =
    inl ar = array_create x 1
    ar 0 <- x
    ar

/// Applies a function to each elements of the collection, threading an accumulator argument through the computation.
/// If the input function is f and the elements are i0..iN then computes f..(f i0 s)..iN.
/// (s -> a -> s) -> s -> a array -> s
inl foldl f state ar = for {from=0; near_to=array_length ar; state; body=inl {state i} -> f state (ar i)}

/// Applies a function to each element of the array, threading an accumulator argument through the computation. 
/// If the input function is f and the elements are i0...iN then computes f i0 (...(f iN s)).
/// (a -> s -> a) -> a array -> s -> s
inl foldr f ar state = for {from=array_length ar-1; down_to=0; state; body=inl {state i} -> f (ar i) state}

// Creates an array given a dimension and a generator function to compute the elements.
// ?{.is_static} -> int -> (int -> a) -> a array
inl init = 
    inl body is_static n f =
        assert (n >= 0) "The input to init needs to be greater or equal to 0."
        inl typ = type (f 0)
        inl ar = array_create typ n
        inl d = 
            inl d = {near_to=n; body=inl {i} -> ar i <- f i}
            if is_static then {d with static_from = 0} else {d with from = 0}
        for d
        ar
    function
    | .static -> body true
    | n -> body false n

/// Builds a new array that contains elements of a given array.
/// a array -> a array
met copy ar = init (array_length ar) ar

/// Builds a new array whose elements are the result of applying a given function to each of the elements of the array.
/// (a -> b) -> a array -> a array
inl map f ar = init (array_length ar) (ar >> f)

/// Returns a new array containing only elements of the array for which the predicate function returns `true`.
/// (a -> bool) -> a array -> a array
inl filter f ar =
    inl ar' = array_create (ar.elem_type) (array_length ar)
    inl count = foldl (inl s x -> if f x then ar' s <- x; s+1 else s) (dyn 0) ar
    init count ar'

/// Merges all the arrays in a tuple into a single one.
/// a array tuple -> a array
inl append l =
    inl ar' = array_create ((fst l).elem_type) (Tuple.foldl (inl s l -> s + array_length l) 0 l)
    inl ap s ar = foldl (inl i x -> ar' i <- x; i+1) s ar
    Tuple.foldl ap (dyn 0) l |> ignore
    ar'

/// Flattens an array of arrays into a single one.
/// a array array -> a array
inl concat ar =
    inl count = foldl (inl s ar -> s + array_length ar) (dyn 0) ar
    inl ar' = array_create (ar.elem_type.elem_type) count
    (foldl << foldl) (inl i x -> ar' i <- x; i+1) (dyn 0) ar |> ignore
    ar'

/// Tests if all the elements of the array satisfy the given predicate.
/// (a -> bool) -> a array -> bool
inl forall f ar = for' {from=0; near_to=array_length ar; state=true; body = inl {next state i} -> f (ar i) && next state}

/// Tests if any the element of the array satisfies the given predicate.
/// (a -> bool) -> a array -> bool
inl exists f ar = for' {from=0; near_to=array_length ar; state=false; body = inl {next state i} -> f (ar i) || next state}

{empty singleton foldl foldr init copy map filter append concat forall exists} 
|> stack
    """) |> module_

let list =
    (
    "List",[loops;option;tuple],"The List module.",
    """
open Loops
open Option

type List x =
    ()
    x, List x

inl lw x = 
    inl rec loop tup_type n x on_fail on_succ =
        if n > 0 then
            match x with
            | () -> on_fail()
            | a, b -> loop tup_type (n-1) b on_fail <| inl b -> on_succ (a :: b)
        else
            match tup_type with
            | .tup ->
                match x with
                | () -> on_succ()
                | _ -> on_fail()
            | .cons -> on_succ (x :: ())

    // Testing for whether the type is a List is not possible since the types are stripped away so ruthlesly in case.
    match x with
    | [var: x] _ on_succ -> on_succ x
    | (.tup | .cons) & typ, (n, x) -> loop typ n x

inl empty x = box (List x) ()
inl singleton x = box (List x) (x, empty x)
inl cons a b = 
    inl t = List a
    box t (a, box t b)

inl init = 
    inl body n f =
        inl t = type (f 0)
        {from=0; near_to=n; state=empty t; body=inl {next i state} -> cons (f i) (next state)}

    function
    | .static n f -> body n f |> inl d -> {d with static=()} |> for'
    | n f -> body n f |> for'
    
    
inl elem_type l =
    match split l with
    | (), (a,b) when eq_type (List a) l -> a
    | _ -> error_type "Expected a List in elem_type."

inl is_static x = box_is x || lit_is x

inl rec map f l = 
    inl t = type (f (elem_type l))
    inl loop map =
        match l with
        | #lw (x :: xs) -> cons (f x) (map f xs)
        | #lw () -> empty t
        : List t
    if is_static l then loop map
    else (met _ -> loop map) ()

inl fold_template loop f s l = 
    if is_static l then loop f s l
    else (met () -> loop f s l) ()

inl rec foldl x =
    fold_template (inl f s l ->
        match l with
        | #lw (x :: xs) -> foldl f (f s x) xs
        | #lw () -> s
        : s) x

inl rec foldr f l s = 
    fold_template (inl f s l ->
        match l with
        | #lw (x :: xs) -> f x (foldr f xs s)
        | #lw () -> s
        : s) f s l

inl head_tail_template f l = 
    inl t = elem_type l
    match l with
    | #lw (x :: xs) -> f (x, xs) |> some
    | #lw () -> none t

inl head = head_tail_template fst
inl tail = head_tail_template snd

met rec last l = 
    inl t = elem_type l
    foldl (inl _ x -> some x) (none t) l

inl append a b = foldr cons a b
inl concat l & !elem_type !elem_type t = foldr append l (empty t)

{List lw init map foldl foldr empty cons singleton append concat head tail last}
    """) |> module_

let parsing =
    (
    "Parsing",[extern_],"Parser combinators.",
    """
open Extern
// Primitives
inl m x = { 
    elem =
        match x with
        | {parser_rec} {d with on_type} state -> join (parser_rec d .elem d state : on_type)
        | {parser} -> parser
        | {parser_mon} -> parser_mon .elem
    }
inl term_cast p typ = m {
    parser = inl d state ->
        p .elem {d with 
            on_succ = 
                inl k = term_cast (inl x,state -> self x state) (typ,state)
                inl x state -> k (x,state)
            } state
    }
inl goto point x = m {
    parser = inl _ -> point x
    }
inl succ x = m {
    parser = inl {on_succ} -> on_succ x
    }
inl fail x = m {
    parser = inl {on_fail} -> on_fail x
    }
inl fatal_fail x = m {
    parser = inl {on_fatal_fail} -> on_fatal_fail x
    }
inl type_ = m {
    parser = inl {on_type on_succ} -> on_succ on_type
    }
inl state = m {
    parser = inl {on_succ} state -> on_succ state state
    }
inl set_state state = m {
    parser = inl {on_succ} _ -> on_succ () state
    }
inl (>>=) a b = m {
    parser = inl d -> a .elem {d with on_succ = inl x -> b x .elem d}
    }
inl try_with handle handler = m {
    parser = inl d -> handle .elem {d with on_fail = inl _ -> handler .elem d}
    }
inl guard cond handler = m {
    parser = inl {d with on_succ} state -> 
        if cond then on_succ () state 
        else handler .elem d state
    }
inl ifm cond tr fl = m {
    parser = inl d state -> if cond then tr () .elem d state else fl () .elem d state
    }
inl attempt a = m {
    parser = inl d state -> a .elem { d with on_fail = inl x _ -> self x state } state
    }

inl rec tuple = function
    | () -> succ ()
    | x :: xs ->
        inm x = x
        inm xs = tuple xs
        succ (x :: xs)

inl (|>>) a f = a >>= inl x -> succ (f x)
inl (.>>.) a b = tuple (a,b)
inl (.>>) a b = tuple (a,b) |>> fst
inl (>>.) a b = a >>= inl _ -> b // The way bind is used here in on purpose. `spaces` diverges otherwise due to loop not being evaled in tail position.
inl (>>%) a b = a |>> inl _ -> b

// TODO: Instead of just passing the old state on failure to the next parser, the parser should
// compare states and fail if the state changed. Right now that cannot be done because Spiral is missing
// polymorphic structural equality on all but primitive types. I want to be able to structurally compare anything.

// Though to be fair, in all the times I've used `choice`, I don't think there has been a single time it was without `attempt`.
// Unlike with Fparsec, backing up the state in Spiral is essentially a no-op due to inlining.
inl (<|>) a b = try_with (attempt a) b
inl choice = function
    | x :: xs -> Tuple.foldl (<|>) x xs
    | () -> error_type "choice require at lease one parser as input"

// CharParsers
inl convert_type = fs [text: "System.Convert"]
inl to_int64 x = FS.StaticMethod convert_type .ToInt64 x int64

inl is_digit x = x >= '0' && x <= '9'
inl is_whitespace x = x = ' '
inl is_newline x = x = '\n' || x = '\r'

inl string_stream str {idx on_succ on_fail} =
    inl f idx = idx >= 0 && idx < string_length str
    match idx with
    | a, b when f a && f b | idx when f idx -> on_succ (str idx)
    | _ -> on_fail "string index out of bounds"

inl stream_char = m {
    parser = inl {d with stream on_succ on_fail} {state with pos} ->
        stream {
            idx = pos
            on_succ = inl c -> on_succ c {state with pos=pos+1}
            on_fail = inl msg -> on_fail msg state
            }
    }

inl run data parser ret = 
    match data with
    | _ : string -> parser .elem { ret with stream = string_stream data} { pos = if lit_is data then 0 else dyn 0 }
    | _ -> error_type "Only strings supported for now."

inl with_unit_ret = {
    on_type = ()
    on_succ = inl _ _ -> ()
    on_fail = inl x _ -> failwith unit x
    on_fatal_fail = inl x _ -> failwith unit x
    }

inl run_with_unit_ret data parser = run data parser with_unit_ret

inl stream_char_pos =
    inm {pos} = state
    stream_char |>> inl x -> x,pos

inl satisfyL f m =
    inm s = state
    inm c = stream_char
    inm _ = guard (f c) (set_state s >>. fail m)
    succ c

inl (<?>) a m = try_with a (fail m)
inl pdigit = satisfyL is_digit "digit"
inl pchar c = satisfyL ((=) c) "char"

inl pstring (!dyn str) x = 
    inl rec loop (!dyn i) = m {
        parser_rec = inl {d with on_succ} ->
            ifm (i < string_length str)
            <| inl _ -> pchar (str i) >>. loop (i+1)
            <| inl _ -> succ str
        }
    loop 0 x

inl pint64 =
    inl rec loop handler i = m {
        parser_rec = inl {on_succ} ->
            inm c = try_with pdigit handler
            inl x = to_int64 c - to_int64 '0'
            inl max = 922337203685477580 // max int64 divided by 10
            inm _ = guard (i = max && x <= 7 || i < max) (fail "integer overflow")
            inl i = i * 10 + x
            loop (goto on_succ i) i
        }
    loop (fail "pint64") 0

/// Note: Unlike the Fparsec version, this spaces returns the number of spaces skipped.
inl spaces x =
    inl rec loop (!dyn i) = m {
        parser_rec = inl {on_succ} -> try_with (satisfyL (inl c -> is_whitespace c || is_newline c) "space") (goto on_succ i) >>. loop (i+1)
        }
    loop 0 x

inl parse_int =
    inm !dyn m = try_with (pchar '-' >>. succ false) (succ true)
    (pint64 |>> inl x -> if m then x else -x) .>> spaces

inl repeat n parser =
    inl rec loop (!dyn i) = m {
        parser_rec = inl _ ->
            ifm (i < n)
            <| inl _ -> parser i >>. loop (i+1)
            <| inl _ -> succ ()
        }
    loop 0

inl parse_array {parser typ n} = m {
    parser_mon =
        inm _ = guard (n >= 0) (fatal_fail "n in parse array must be >= 0")
        inl ar = array_create typ n
        repeat n (inl i -> parser |>> inl x -> ar i <- x) >>. succ ar
    }

// This function takes too long to compile so its use is not recommended.
// `show`, `string_concat` and `string_format` are better candidates as printing functions.
inl sprintf_parser append =
    inl rec sprintf_parser sprintf_state =
        inl parse_variable = m {
            parser_mon =
                inm c = try_with stream_char (inl x -> append '%'; fail "done" x)
                match c with
                | 's' -> function
                    | x : string -> x
                    | _ -> error_type "Expected a string in sprintf."
                | 'c' -> function
                    | x : char -> x
                    | _ -> error_type "Expected a char in sprintf."
                | 'b' -> function
                    | x : bool -> x
                    | _ -> error_type "Expected a bool in sprintf."
                | 'i' -> function
                    | x : int32 | x : int64 | x : uint32 | x : uint64 -> x
                    | _ -> error_type "Expected an integer in sprintf."
                | 'f' -> function
                    | x : float32 | x : float64 -> x
                    | _ -> error_type "Expected a float in sprintf."
                | 'A' -> id
                | _ -> error_type "Unexpected literal in sprintf."
                |> inl guard_type -> 
                    m { parser = inl d state -> d.on_succ (inl x -> append x; sprintf_parser .None .elem d state) state }
            }

        inl append_state = m {
            parser = inl {d with stream on_succ on_fail} state ->
                match sprintf_state with
                | .None -> on_succ () state
                | ab -> stream {
                    idx = ab
                    on_succ = inl r -> append r; on_succ () state 
                    on_fail = inl msg -> on_fail msg state
                    }
            }

        inm c = try_with stream_char_pos (append_state >>. fail "done")
        match c with
        | '%', _ -> append_state >>. parse_variable
        | _, pos ->
            match sprintf_state with
            | .None -> (pos, pos)
            | (start,_) -> (start, pos)
            |> sprintf_parser
    sprintf_parser .None

inl sprintf_template append ret format =
    run format (sprintf_parser append) ret

inl sprintf format = 
    inl strb_type = fs [text: "System.Text.StringBuilder"]
    inl strb = FS.Constructor strb_type (64i32)
    inl append x = FS.Method strb .Append x strb_type |> ignore
    sprintf_template append {
        on_succ = inl x _ -> x
        on_fail = inl msg _ -> FS.Method strb .ToString() string
        } format

{run run_with_unit_ret succ fail fatal_fail state type_ tuple (>>=) (|>>) (.>>.) (.>>) (>>.) (>>%) (<|>) choice stream_char 
 ifm (<?>) pdigit pchar pstring pint64 spaces parse_int repeat parse_array sprintf sprintf_template term_cast} |> stack
    """) |> module_


let console =
    (
    "Console",[parsing;extern_],"IO printing functions.",
    """
open Extern
inl console_type = fs [text: "System.Console"]
inl stream_type = fs [text: "System.IO.Stream"]
inl streamreader_type = fs [text: "System.IO.StreamReader"]
inl readall () = 
    FS.StaticMethod console_type .OpenStandardInput() stream_type
    |> FS.Constructor streamreader_type 
    |> inl x -> FS.Method x .ReadToEnd() string
inl readline () = FS.StaticMethod console_type .ReadLine() string

inl write = function
    | () -> ()
    | x -> FS.StaticMethod console_type .Write (show x) unit
inl writeline = function
    | () -> FS.StaticMethod console_type .WriteLine () unit
    | x -> FS.StaticMethod console_type .WriteLine (show x) unit

inl printf_template cont = 
    Parsing.sprintf_template write {
        on_succ = inl x _ -> x
        on_fail = inl msg _ -> cont()
        }

inl printf = printf_template id
inl printfn = printf_template writeline

{readall readline write writeline printf printfn}
    """) |> module_

let queue =
    (
    "Queue",[tuple;loops;console],"The queue module.",
    """
open Loops
open Console

inl add_one len x =
    inl x = x + 1
    if x = len then 0 else x

inl resize {len from to ar} =
    inl ar' = array_create (ar.elem_type) (len*3/2+3)
    for {from near_to=len; body=inl {i} -> ar' (i - from) <- ar i}
    for {from=0; near_to=from; body=inl {i} -> ar' (len - from + i) <- ar i}
    {from=0; to=len; ar=ar'}

met enqueue queue (!dyn v) =
    inl {from to ar} = queue
    ar to <- v
    inl len = array_length ar
    inl to = add_one len to
    if from = to then 
        inl {from to ar} = resize {len from to ar}
        queue.from <- from
        queue.to <- to
        queue.ar <- ar
    else queue.to <- to

met dequeue queue =
    inl {from to ar} = queue
    assert (from <> to) "Cannot dequeue past the end of the queue."
    queue.from <- add_one (array_length ar) from
    ar from

inl create typ n =
    inl n = match n with () -> 16 | n -> max 1 n
    heapm {from=dyn 0; to=dyn 0; ar=array_create typ n}

// Note: By convention I am disallowing module methods to keep track of their data.
// Hence the user will have to use enqueue and dequeue statically on the queue.

// This is because {queue with queue = new_queue} will not update the queue and dequeue
// which will still point to the old and unused data. Modules are not to be used as classes.

// Closures can be used as classes as their fields cannot be updated immutably.
{create enqueue dequeue}
    """) |> module_

let host_tensor =
    (
    "HostTensor",[tuple;loops;extern_],"The host tensor module.",
    """
// A lot of the code in this module is made with purpose of being reused on the Cuda side.

inl toa_map f x = 
    inl rec loop = function
        | x when caseable_is x -> f x
        | () -> ()
        | x :: xs -> loop x :: loop xs
        | {!block_toa_map} & x -> module_map (inl _ -> loop) x
        | x -> f x
    loop x

inl toa_map2 f a b = 
    inl rec loop = function
        | x, y when caseable_is x || caseable_is y -> f x y
        | (), () -> ()
        | x :: xs, y :: ys -> loop (x,y) :: loop (xs,ys)
        | {!block_toa_map} & x, {!block_toa_map} & y -> module_map (inl k y -> loop (x k,y)) y
        | x, y -> f x y
    loop (a,b)

inl toa_map3 f a b c = 
    inl rec loop = function
        | x, y, z when caseable_is x || caseable_is y || caseable_is z -> f x y z
        | (), (), () -> ()
        | x :: xs, y :: ys, z :: zs -> loop (x,y,z) :: loop (xs,ys,zs)
        | {!block_toa_map} & x, {!block_toa_map} & y, {!block_toa_map} & z -> module_map (inl k y -> loop (x k,y k,z)) z
        | x, y, z -> f x y z
    loop (a,b,c)

inl toa_foldl f s x = 
    inl rec loop s = function
        | x when caseable_is x -> f s x
        | () -> s
        | x :: xs -> loop (loop s x) xs
        | {!block_toa_map} & x -> module_foldl (inl _ -> loop) s x
        | x -> f s x
    loop s x

inl toa_iter f = toa_map (inl x -> f x; ()) >> ignore
inl toa_iter2 f a b = toa_map2 (inl a b -> f a b; ()) a b |> ignore
inl toa_iter3 f a b c = toa_map3 (inl a b c -> f a b c; ()) a b c |> ignore

inl map_dim = function
    | {from to} -> 
        assert (from <= to) "Tensor needs to be at least size 1."
        {from; near_to=to+1}
    | {from near_to} as d -> 
        assert (from < near_to) "Tensor needs to be at least size 1."
        d
    | x -> 
        assert (x > 0) "Tensor needs to be at least size 1."
        {from=0; near_to=x}

inl map_dims = Tuple.map map_dim << Tuple.wrap

inl primitive_apply_template {merge_offset view} {data with offsets} v = 
    match offsets with
    | x :: offsets -> merge_offset (view {data with offsets} v) x
    | () -> view data v |> inl x -> {x without size offsets}

inl rec view_offsets = function
    | {position size} :: d', i :: h' -> {size position=position + i * size} :: view_offsets (d',h')
    | (), _ :: _ -> error_type "The view has more dimensions than the tensor."
    | offsets, () -> offsets

inl HostTensorPrimitives =
    inl view {data with size position offsets} = function
        | i :: l -> {data with 
            position=position + i * size
            offsets=view_offsets (offsets,l)
            }
        | i -> {data with position=position + i * size}
    inl merge_offset {data with size position} {size=size' position=position'} = {data with size=size'; position=position + position'}
    {
    view 
    get = inl {data with position ar} -> ar position
    set = inl {data with position ar} v -> ar position <- v
    apply = primitive_apply_template {view merge_offset} 
    }

inl span {from near_to} = near_to - from

inl TensorTemplate {view get set apply} = {
    elem_type = inl {data with bodies} -> toa_map (inl {ar} -> ar.elem_type) bodies
    update_body = inl {data with bodies} f -> {data with bodies=toa_map f bodies}    
    update_body2 = inl {data with bodies=a,b} f -> {data with bodies=toa_map2 f a b}
    update_dim = inl {data with dim} f -> {data with dim=f dim}
    get = inl {data with dim bodies} -> 
        match dim with
        | () -> toa_map get bodies
        | _ -> error_type "Cannot get from tensor whose dimensions have not been applied completely."
    set = inl {data with dim bodies} v ->
        match dim with
        | () -> toa_iter2 set bodies v
        | _ -> error_type "Cannot set to a tensor whose dimensions have not been applied completely."
    view = inl {data with dim} (!map_dims head_dims) ->
        inl rec new_dim = function
            | {from near_to} :: d', {nd with from=from' near_to=near_to'} :: h' ->
                assert (from' >= from && from' < near_to) "Lower boundary out of bounds." 
                assert (near_to' > from && near_to' <= near_to) "Higher boundary out of bounds." 
                inl i',nd' = new_dim (d',h')
                from'-from :: i', nd :: nd'
            | (), _ :: _ -> error_type "The view has more dimensions than the tensor."
            | dim, () -> (),dim

        inl indices, dim = new_dim (dim, head_dims)
        {data with bodies = toa_map (inl ar -> view ar indices) self; dim}
    
    // Resizes the view towards zero.
    view_span = inl {data with dim} (!map_dims head_dims) ->
        inl rec new_dim = function
            | {from near_to} :: d', {nd with from=from' near_to=near_to'} :: h' ->
                inl nd = {from = 0; near_to = span nd}
                inl _ = // Want to make `from'` go out scope.
                    inl from', near_to' = from + from', from + near_to'
                    assert (from' >= from && from' < near_to) "Lower boundary out of bounds." 
                    assert (near_to' > from && near_to' <= near_to) "Higher boundary out of bounds." 
                inl i', nd' = new_dim (d',h')
                from' :: i', nd :: nd'
            | (), _ :: _ -> error_type "The view has more dimensions than the tensor."
            | dim, () -> (),dim

        inl indices, dim = new_dim (dim, head_dims)
        {data with bodies = toa_map (inl ar -> view ar indices) self; dim}

    apply = inl {data with dim} i ->
        match dim with
        | () -> error_type "Cannot apply the tensor anymore."
        | {from near_to} :: dim ->
            assert (i >= from && i < near_to) "Argument out of bounds." 
            {data with bodies = toa_map (inl ar -> apply ar (i-from)) self; dim}
    }

inl show_tensor_all tns =
    open Extern
    inl strb_type = fs [text: "System.Text.StringBuilder"]
    inl s = FS.Constructor strb_type ()
    inl append x = FS.Method s .Append x strb_type |> ignore
    inl append_line x = FS.Method s .AppendLine x strb_type |> ignore
    inl indent near_to = Loops.for {from=0; near_to; body=inl _ -> append ' '}
    inl blank = dyn ""
    inl rec loop {tns ind} = 
        match tns.dim with
        | () -> tns.get |> show |> append
        | {from near_to} :: () ->
            indent ind; append "[|"
            Loops.for {from near_to state=blank; body=inl {state i} -> 
                append state
                tns i .get |> show |> append
                dyn "; "
                } |> ignore
            append_line "|]"
        | {from near_to} :: x' ->
            indent ind; append_line "[|"
            Loops.for {from near_to body=inl {state i} -> loop {tns=tns i; ind=ind+4}}
            indent ind; append_line "|]"
        
    loop {tns; ind=0; prefix=blank} |> ignore
    FS.Method s .ToString() string

inl show_tensor' (!map_dims dim) tns =
    inl f {from near_to} {from=from' near_to=near_to'} = {
        from = min (near_to-1) (from + from') |> max from
        near_to = min near_to (from + near_to') |> max (from+1)
        }
    inl {view ap} =
        Tuple.foldr (inl {x with from} -> function
            | {state with view dim=d :: dim} -> {state with view=f x d :: view; dim}
            | {state with ap} -> {state with ap=from :: ap}
            ) (tns.dim) {dim=Tuple.rev dim; view=(); ap=()}
    Tuple.foldr (|>) ap tns .view view |> show_tensor_all

// By default it just shows the first 5x5x5 matrix of the first 3 innermost dimensions.
// If the tensor has less than 3 dimensions or its sizes are less than 5 then the minimum is taken.
inl show_tensor = show_tensor' (5,5,5) 

inl rec wrap_tensor_template module = 
    inl rec wrap data = function
        | .replace_module module -> wrap_tensor_template module data
        | (.elem_type | .get | .set) & x -> module x data
        | .(_) & x -> 
            if module_has_member data x then data x
            else module x data >> wrap
        | i -> module .apply data i |> wrap
    wrap

inl wrap_host_tensor = wrap_tensor_template (TensorTemplate HostTensorPrimitives)

inl dim_describe (!map_dims dim) = 
    match dim with
    | () -> error_type "Empty dimensions are not allowed."
    | dim ->
        inl len :: size :: size' = Tuple.scanr (inl (!span x) s -> x * s) dim 1
        inl make_body ar = 
            inl position = 0
            inl offsets = Tuple.map (inl size -> {size position}) size'
            {ar size position offsets block_toa_map=()}
        {len dim make_body}

/// Creates an empty tensor given the descriptor. {size elem_type ?layout=(.toa | .aot) ?array_create} -> tensor
inl create {dsc with dim elem_type} = 
    inl create dim =
        inl {len dim make_body} = dim_describe dim
        inl bodies =
            inl layout = match dsc with {layout} -> layout | _ -> .toa
            inl array_create = match dsc with {array_create} -> array_create | _ -> array_create
            inl create elem_type = make_body (array_create elem_type len)
            match layout with
            | .aot -> create elem_type
            | .toa -> toa_map create elem_type

        wrap_host_tensor {bodies dim}
    match dim with
    | () -> create 1 0
    | dim -> create dim
    
inl init_core tns f =
    inl rec loop tns f = 
        match tns.dim with
        | {from near_to} :: _ -> Loops.for { from near_to; body=inl {i} -> loop (tns i) (f i) }
        | () -> tns .set f
    loop tns f

/// Creates a new tensor based on given sizes. Takes in a setter function. size -> f -> tensor.
inl init size f =
    inl dim = Tuple.wrap size
    inl elem_type = type (Tuple.foldl (inl f _ -> f 0) f dim)
    inl tns = create {elem_type dim layout= .toa}
    init_core tns f
    tns

/// Maps the elements of the tensor. (a -> b) -> a tensor -> b tensor
inl map f tns =
    inl size = tns.dim
    inl rec loop tns = function
        | _ :: x' -> inl x -> loop (tns x) x' 
        | () -> f (tns .get)
    
    init size (loop tns size)

/// Copies a tensor. tensor -> tensor
inl copy = map id

/// Total tensor size in elements.
inl product = Tuple.foldl (inl s (!span x) -> s * x) 1
inl length tns = product (tns.dim)

/// Sets the tensor dimensions assuming the overall length matches. Does not copy. size -> tensor -> tensor.
inl reshape (!dim_describe {len dim make_body}) tns = 
    tns.update_dim (inl dim' ->
            inl len' = product dim'
            assert (len = len') "The product of given dimensions does not match the product of tensor dimensions."
            dim)
        .update_body (inl {offsets ar} ->
            assert 
                (Tuple.forall (inl {position} -> position = 0) offsets) 
                "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead"
            make_body ar
            )

inl assert_contiguous tns = reshape (tns.dim) tns |> ignore 
inl to_1d tns = reshape (length tns) tns

/// Asserts the tensor size. Useful for setting those values to statically known ones. Does not copy. size -> tensor -> tensor.
inl assert_size (!map_dims dim') tns = 
    inl dim = tns.dim
    assert (dim = dim') "The dimensions do not match."
    reshape dim tns // This is in order for the offsets to become static.

/// Reinterprets an array as a tensor. Does not copy. array -> tensor.
inl array_as_tensor ar =
    inl {dim make_body} = dim_describe (array_length ar)
    wrap_host_tensor {dim bodies=make_body ar}

/// Reinterprets an array as a tensor. array -> tensor.
inl array_to_tensor = array_as_tensor >> copy

inl assert_zip l =
    toa_foldl (inl s x ->
        match s with
        | () -> x
        | s -> assert ((s.dim) = (x.dim)) "All tensors in zip need to have the same dimensions"; s) () l

inl zip l = 
    match assert_zip l with
    | () -> error_type "Empty inputs to zip are not allowed."
    | tns -> tns.update_body <| inl _ -> toa_map (inl x -> x.bodies) l

{toa_map toa_map2 toa_iter toa_iter2 map_dim map_dims length create dim_describe primitive_apply_template TensorTemplate
 view_offsets init copy to_1d reshape assert_size array_as_tensor array_to_tensor map zip show_tensor' show_tensor 
 show_tensor_all toa_map3 toa_iter3 assert_contiguous assert_zip span}
|> stack
    """) |> module_

let cuda =
    (
    "Cuda",[loops;console;array;host_tensor;extern_],"The Cuda module.",
    """
open Extern
open Console

inl cuda_kernels = FS.Constant.cuda_kernels string
inl join_point_entry_cuda x = !JoinPointEntryCuda(x())

inl cuda_constant a t = !MacroCuda(t,[text: a])

inl cuda_constant_int constant () = cuda_constant constant int64
inl __threadIdxX = cuda_constant_int "threadIdx.x"
inl __threadIdxY = cuda_constant_int "threadIdx.y"
inl __threadIdxZ = cuda_constant_int "threadIdx.z"
inl __blockIdxX = cuda_constant_int "blockIdx.x"
inl __blockIdxY = cuda_constant_int "blockIdx.y"
inl __blockIdxZ = cuda_constant_int "blockIdx.z"

inl __blockDimX = cuda_constant_int "blockDim.x"
inl __blockDimY = cuda_constant_int "blockDim.y"
inl __blockDimZ = cuda_constant_int "blockDim.z"
inl __gridDimX = cuda_constant_int "gridDim.x"
inl __gridDimY = cuda_constant_int "gridDim.y"
inl __gridDimZ = cuda_constant_int "gridDim.z"

inl cuda_toolkit_path = @PathCuda
inl visual_studio_path = @PathVS2017
inl cub_path = @PathCub

inl env_type = fs [text: "System.Environment"]
inl context_type = fs [text: "ManagedCuda.CudaContext"]
inl context = FS.Constructor context_type false
FS.Method context .Synchronize() unit

inl compile_kernel_using_nvcc_bat_router (kernels_dir: string) =
    inl path_type = fs [text: "System.IO.Path"]
    inl combine x = FS.StaticMethod path_type .Combine x string
    
    inl file_type = fs [text: "System.IO.File"]
    inl stream_type = fs [text: "System.IO.Stream"]
    inl streamwriter_type = fs [text: "System.IO.StreamWriter"]
    inl process_start_info_type = fs [text: "System.Diagnostics.ProcessStartInfo"]
    
    inl nvcc_router_path = combine (kernels_dir,"nvcc_router.bat")
    inl procStartInfo = FS.Constructor process_start_info_type ()
    FS.Method procStartInfo .set_RedirectStandardOutput true unit
    FS.Method procStartInfo .set_RedirectStandardError true unit
    FS.Method procStartInfo .set_UseShellExecute false unit
    FS.Method procStartInfo .set_FileName nvcc_router_path unit

    inl process_type = fs [text: "System.Diagnostics.Process"]
    use process = FS.Constructor process_type ()
    FS.Method process .set_StartInfo procStartInfo unit
    inl print_to_standard_output = 
        closure_of (inl args -> FS.Method args .get_Data() string |> writeline) 
            (fs [text: "System.Diagnostics.DataReceivedEventArgs"] => ())

    FS.Method process ."OutputDataReceived.Add" print_to_standard_output ()
    FS.Method process ."ErrorDataReceived.Add" print_to_standard_output ()

    inl concat = string_concat ""
    inl (+) a b = concat (a, b)

    /// Puts quotes around the string.
    inl quote x = ("\"",x,"\"")
    inl call x = ("CALL ", x)
    inl quoted_vs_path_to_vcvars = combine(visual_studio_path, @"VC\Auxiliary\Build\vcvars64.bat") |> quote
    inl quoted_vs_path_to_cl = combine(visual_studio_path, @"VC\Tools\MSVC\14.11.25503\bin\Hostx64\x64") |> quote
    inl quoted_cuda_toolkit_path_to_include = combine(cuda_toolkit_path,"include") |> quote
    inl quoted_vc_path_to_include = combine(visual_studio_path, @"VC\Tools\MSVC\14.11.25503\include") |> quote
    inl quoted_nvcc_path = combine(cuda_toolkit_path,@"bin\nvcc.exe") |> quote
    inl quoted_cub_path_to_include = cub_path |> quote
    inl quoted_kernels_dir = kernels_dir |> quote
    inl target_path = combine(kernels_dir,"cuda_kernels.ptx")
    inl quoted_target_path = target_path |> quote
    inl input_path = combine(kernels_dir,"cuda_kernels.cu")
    inl quoted_input_path = input_path |> quote

    if FS.StaticMethod file_type .Exists input_path bool then FS.StaticMethod file_type .Delete input_path unit
    FS.StaticMethod file_type .WriteAllText(input_path,cuda_kernels) unit
   
    inl _ = 
        if FS.StaticMethod file_type .Exists nvcc_router_path bool then FS.StaticMethod file_type .Delete nvcc_router_path unit
        inl filestream_type = fs [text: "System.IO.FileStream"]

        use nvcc_router_file = FS.StaticMethod file_type .OpenWrite(nvcc_router_path) filestream_type
        use nvcc_router_stream = FS.Constructor streamwriter_type nvcc_router_file

        inl write_to_batch = concat >> inl x -> FS.Method nvcc_router_stream .WriteLine x unit

        "SETLOCAL" |> write_to_batch
        call quoted_vs_path_to_vcvars |> write_to_batch
        ("SET PATH=%PATH%;", quoted_vs_path_to_cl) |> write_to_batch
        (
        quoted_nvcc_path, " -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017",
        " -I", quoted_cuda_toolkit_path_to_include,
        " -I", quoted_cub_path_to_include,
        " -I", quoted_vc_path_to_include,
        " --keep-dir ",quoted_kernels_dir,
        " -maxrregcount=0  --machine 64 -ptx -cudart static  -o ",quoted_target_path," ",quoted_input_path
        ) |> write_to_batch

    inl stopwatch_type = fs [text: "System.Diagnostics.Stopwatch"]
    inl timer = FS.StaticMethod stopwatch_type .StartNew () stopwatch_type
    if FS.Method process .Start() bool = false then failwith unit "NVCC failed to run."
    FS.Method process .BeginOutputReadLine() unit
    FS.Method process .BeginErrorReadLine() unit
    FS.Method process .WaitForExit() unit

    inl exit_code = FS.Method process .get_ExitCode() int32
    assert (exit_code = 0i32) ("NVCC failed compilation.", exit_code)
    
    inl elapsed = FS.Method timer .get_Elapsed() (fs [text: "System.TimeSpan"])
    !MacroFs(unit,[text: "printfn \"The time it took to compile the Cuda kernels is: %A\" "; arg: elapsed])

    FS.Method context .LoadModulePTX target_path (fs [text: "ManagedCuda.BasicTypes.CUmodule"])

inl current_directory = FS.StaticMethod env_type .get_CurrentDirectory() string
inl modules = compile_kernel_using_nvcc_bat_router current_directory
writeline (string_concat "" ("Compiled the kernels into the following directory: ", current_directory))

inl dim3 = function
    | {x y z} as m -> m
    | x,y,z -> {x=x: int64; y=y: int64; z=z: int64}
    | x,y -> {x=x: int64; y=y: int64; z=1}
    | x -> {x=x: int64; y=1; z=1}

inl Stream =
    inl ty x = fs [text: x]
    inl CudaStream_type = ty."ManagedCuda.CudaStream"
    inl CUstream_type = ty."ManagedCuda.BasicTypes.CUstream"

    {
    create = inl x -> FS.Constructor CudaStream_type x
    extract = inl x -> FS.Method x .get_Stream() CUstream_type 
    } |> stack

inl run {blockDim=!dim3 blockDim gridDim=!dim3 gridDim kernel} as runable =
    inl to_obj_ar args =
        inl ty = fs [text: "System.Object"] |> array
        !MacroFs(ty,[fs_array_args: args; text: ": "; type: ty])

    inl kernel =
        inl map_to_op_if_not_static {x y z} (x', y', z') = 
            inl f x x' = if lit_is x then const x else x' 
            f x x', f y y', f z z'
        inl x,y,z = map_to_op_if_not_static blockDim (__blockDimX,__blockDimY,__blockDimZ)
        inl x',y',z' = map_to_op_if_not_static gridDim (__gridDimX,__gridDimY,__gridDimZ)
        inl _ -> // This convoluted way of swaping non-literals for ops is so they do not get called outside of the kernel.
            inl threadIdx = {x=__threadIdxX(); y=__threadIdxY(); z=__threadIdxZ()}
            inl blockIdx = {x=__blockIdxX(); y=__blockIdxY(); z=__blockIdxZ()}
            inl blockDim = {x=x(); y=y(); z=z()}
            inl gridDim = {x=x'(); y=y'(); z=z'()}
            kernel threadIdx blockIdx blockDim gridDim
    inl method_name, !to_obj_ar args = join_point_entry_cuda kernel
    inl dim3 {x y z} = Tuple.map (unsafe_convert uint32) (x,y,z) |> FS.Constructor (fs [text: "ManagedCuda.VectorTypes.dim3"])
    
    inl context = match runable with | {context} | _ -> context
    inl kernel_type = fs [text: "ManagedCuda.CudaKernel"]
    inl cuda_kernel = FS.Constructor kernel_type (method_name,modules,context)
    FS.Method cuda_kernel .set_GridDimensions(dim3 gridDim) unit
    FS.Method cuda_kernel .set_BlockDimensions(dim3 blockDim) unit

    match runable with
    | {stream} -> FS.Method cuda_kernel .RunAsync(Stream.extract stream,args) unit
    | _ -> FS.Method cuda_kernel .Run(args) float32

inl ret -> 
    use context = context
    ret {Stream context dim3 run}
    """) |> module_

