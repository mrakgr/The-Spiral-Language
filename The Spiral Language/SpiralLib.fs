module Spiral.Lib
open CoreLib
open Main

let option =
    (
    "Option",[],"The Option module.",
    """
inl Option x = (type ([Some: x])) \/ (type ([None]))

inl some x = box (Option x) [Some: x]
inl none x = box (Option x) [None]

{Option some none}
    """) |> module_

let tuple =
    (
    "Tuple",[],"Operations on tuples.",
    """
inl index = Tuple.index // from Core
inl length = Tuple.length
inl singleton x = x :: ()
inl head = function
    | x :: xs -> x
inl tail = function
    | x :: xs -> xs

inl rec foldl f s = function
    | x :: xs -> foldl f (f s x) xs
    | () -> s

inl rec foldr f l s = 
    match l with
    | x :: xs -> f x (foldr f xs s)
    | () -> s

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
inl index = Tuple.index

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
    | x :: xs -> if f x then [Some: x] else tryFind f xs
    | () -> [None]

inl rec contains t x = 
    match tryFind ((=) x) t with
    | [Some: x] -> true
    | [None] -> false

inl rec intersperse sep = function
    | _ :: () as x -> x
    | x :: xs -> x :: sep :: intersperse sep xs
    | _ -> error_type "Not a tuple."

{index length head tail foldl foldr scanl scanr rev map iter iteri iter2 forall exists filter zip unzip index 
 init repeat append singleton range tryFind contains intersperse}
    """) |> module_

let extern_ =
    (
    "Extern",[tuple],"The Extern module.",
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

/// The sprintf in Parsing is very slow to compile so this is the reasonable alternative to it.
/// It is a decent bit more flexible that it too.
/// TODO: Move this somewhere better. There needs to be a String module at some point.
inl string_concat sep l =
    inl stringbuilder_type = fs [text: "System.Text.StringBuilder"]
    inl StringBuilder = FS.Constructor stringbuilder_type
    inl len =
        inl rec len x = 
            inl f (static_len, dyn_len, num_sep as s) = function
                | x : string ->
                    if lit_is x then (static_len + string_length x, dyn_len, num_sep+1)
                    else (static_len, dyn_len + string_length x, num_sep+1)
                | _ :: _ as l -> len s l
                | x -> (static_len+6, dyn_len, num_sep+1)
            Tuple.foldl f x
        inl static_len, dyn_len, num_sep = len (0,0,-1) l
        static_len + num_sep * string_length sep + dyn_len
        |> unsafe_convert int32

    inl rec apply = function
        | .ap s -> function
            | x : string when lit_is x && x = "" -> s
            | _ :: _ as l -> Tuple.foldl (apply.ap_sep) s l
            | x -> FS.Method s .Append x stringbuilder_type
        | .ap_sep s x -> apply.ap (apply.ap s sep) x

    Tuple.foldl (apply.ap_sep) (apply.ap (StringBuilder len) (Tuple.head l)) (Tuple.tail l)
    |> inl x -> FS.Method x .ToString () string

inl closure_of_template check_range f tys = 
    inl rec loop vars tys =
        match tys with
        | x => xs -> term_cast (inl x -> loop (x :: vars) xs) x
        | x -> 
            inl r = Tuple.foldr (inl var f -> f var) vars f 
            if check_range && eq_type r x = false then error_type "The tail of the closure does not correspond to the one being casted to."
            r
    loop () tys

inl closure_of' = closure_of_template false
inl closure_of = closure_of_template true

{string_concat closure_of closure_of' FS} |> stack
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

inl for_template kind =
    inl rec loop {from (near_to ^ to)=to by} as d =
        inl loop_body {check from by state body finally} as d =
            if check from then 
                match kind with
                | .Navigable ->
                    inl d = {d without state}
                    inl next state = loop {d with state from=from+by}
                    body {next state i=from}
                | .Standard ->
                    loop {d with state=body {state i=from}; from=from+by}
            else finally state
            : finally state

        match d with
        | {static} when Tuple.forall lit_is (from,to,by) -> loop_body d
        | _ -> (met d -> loop_body d) {d with from=dyn from}

    inl er_msg = "The by field should not be zero in loop as the program would diverge."

    function | {static_from} as d -> {d with static=()} | d -> d
    >> function | {from ^ static_from=from} as d -> {d with from without static_from} | d -> error_type "The from field to loop is missing."
    >> function | {to ^ near_to} as d -> d | d -> "For loop needs exlusively to or near_to fields."
    >> function | {body} as d -> d | d -> error_type "The loop body is missing."
    >> function | {state} as d -> d | d -> {d with state=()}
    >> function | {by} as d -> d | d -> {d with by=1}
    >> function | {finally} as d -> d | d -> {d with finally=id}
    >> function 
        | {by} when lit_is by && by = 0 -> error_type er_msg
        // The `check` field is a binding time improvement so the loop gets specialized to negative steps.
        // That way it will get specialized even if `by` is dynamic.
        | {by} as d -> 
            if by < 0 then loop {d with check=match d with | {to} -> inl from -> from >= to | {near_to} -> inl from -> from > near_to}
            else loop {d with check=match d with | {to} -> inl from -> from <= to | {near_to} -> inl from -> from < near_to}

inl for = for_template .Standard
inl for' = for_template .Navigable

{for for' while}
    """) |> module_


let array =
    (
    "Array",[tuple;loops;extern_],"The array module",
    """
open Loops

inl empty t = Array.create t 0
inl singleton x =
    inl ar = Array.create x 1
    ar 0 <- x
    ar

inl foldl f state ar = for {from=0; near_to=Array.length ar; state; body=inl {state i} -> f state (ar i)}
inl foldr f ar state = for {to=0; from=Array.length ar-1; by= -1; state; body=inl {state i} -> f (ar i) state}

inl init = 
    inl body is_static n f =
        assert (n >= 0) "The input to init needs to be greater or equal than 0."
        inl typ = type (f 0)
        inl ar = Array.create typ n
        inl d = 
            inl d = {from=0; near_to=n; body=inl {i} -> ar i <- f i}
            if is_static then {d with static = ()} else d
        for d
        ar
    function
    | .static n f -> body true n f
    | n f -> body false n f


inl map f ar = init (Array.length ar) (ar >> f)
inl filter f ar =
    inl ar' = Array.create (ar.elem_type) (Array.length ar)
    inl count = foldl (inl s x -> if f x then ar' s <- x; s+1 else s) (dyn 0) ar
    init count ar'

inl append l =
    inl ar' = Array.create ((fst l).elem_type) (Tuple.foldl (inl s l -> s + Array.length l) 0 l)
    inl ap s ar = foldl (inl i x -> ar' i <- x; i+1) s ar
    Tuple.foldl ap (dyn 0) l |> ignore
    ar'

inl concat ar =
    inl count = foldl (inl s ar -> s + Array.length ar) (dyn 0) ar
    inl ar' = Array.create (ar.elem_type.elem_type) count
    (foldl << foldl) (inl i x -> ar' i <- x; i+1) (dyn 0) ar |> ignore
    ar'

inl forall f ar = for' {from=0; near_to=Array.length ar; state=true; body = inl {next state i} -> f (ar i) && next state}
inl exists f ar = for' {from=0; near_to=Array.length ar; state=false; body = inl {next state i} -> f (ar i) || next state}

met show_array ar =
    open Extern
    inl strb_type = fs [text: "System.Text.StringBuilder"]
    inl s = FS.Constructor strb_type ()

    FS.Method s.Append "[|" strb_type |> ignore
    foldl (inl prefix x ->
        FS.Method s.Append prefix strb_type |> ignore
        FS.Method s.Append (FS.StaticMethod (fs [text: "System.Convert"]) .ToString x string) strb_type |> ignore
        "; "
        ) "" ar |> ignore
    FS.Method s.Append "|]" strb_type |> ignore
    FS.Method s.ToString() string

{create=Array.create; length=Array.length; empty singleton foldl foldr init map filter append concat forall exists show_array}
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
        || {parser_rec} {d with on_type} state -> parser_rec d .elem d state : on_type
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
        inl ar = Array.create typ n
        repeat n (inl i -> parser |>> inl x -> ar i <- x) >>. succ ar
    }

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
    inl append x = FS.Method strb.Append x strb_type |> ignore
    sprintf_template append {
        on_succ = inl x _ -> x
        on_fail = inl msg _ -> FS.Method strb.ToString() string
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
    |> inl x -> FS.Method x.ReadToEnd() string
inl readline () = FS.StaticMethod console_type .ReadLine() string

inl write x = FS.StaticMethod console_type .Write x unit
inl writeline x = FS.StaticMethod console_type .WriteLine x unit

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
// The design of this is not ideal, it should be a single object with 3 mutable fields instead of just one tuple field,
// but it should do nicely in a pinch for those dynamic programming kind of problems.
inl add_one len x =
    inl x = x + 1
    if x = len then 0 else x

inl resize {len from to ar} =
    inl ar' = Array.create (ar.elem_type) (len*3/2+3)
    for {from near_to=len; body=inl {i} -> ar' (i - from) <- ar i}
    for {from=0; near_to=from; body=inl {i} -> ar' (len - from + i) <- ar i}
    {from=0; to=len; ar=ar'}

met enqueue queue (!dyn v) =
    inl {from to ar} = queue
    ar to <- v
    inl len = Array.length ar
    inl to = add_one len to
    if from = to then 
        inl {from to ar} = resize {len from to ar}
        queue.from <- from
        queue.to <- to
        queue.ar <- ar
    else queue.to <- to

met dequeue queue () =
    inl {from to ar} = queue
    assert (from <> to) "Cannot dequeue past the end of the queue."
    queue.from <- add_one (Array.length ar) from
    ar from

inl create n typ =
    inl n = match n with | () -> 16 | n -> max 1 n
    inl queue = heapm {from=dyn 0; to=dyn 0; ar=Array.create typ n}
    {internal = queue; enqueue = enqueue queue; dequeue = dequeue queue}

{create}
    """) |> module_

let host_tensor =
    (
    "HostTensor",[tuple;loops;console],"The host tensor module.",
    """
open Loops
open Console

inl dim_size {from to} = to - from + 1 |> max 0
inl offset_at_index is_safe array i =
    inl rec loop x state = 
        match x with
        | {size=({from to} & dim_range) :: size ar}, i :: is ->
            inl offset, dim_offset = loop ({size ar}, is) state
            inl dim_offset = dim_offset() 
            if is_safe then assert (i >= from && i <= to) "Argument out of bounds."
            
            // The function wrapper here is to simulate lazy eval in order to 
            // avoid the multiply on the first index at the end of the loop.
            (offset+dim_offset*(i-from)), inl _ -> dim_offset * dim_size dim_range 
        | {size=() ar}, () ->
            state
    inl i = match i with | _ :: _ -> i | i -> i :: ()
    loop (array,i) (0,inl _ -> 1) |> fst
       
inl map_dims x = 
    inl f = function
        | {from to} as d -> d
        | x -> {from=0; to=x-1}

    match x with
    | _ :: _ -> Tuple.map f x
    | x -> f x :: ()

inl rec toa_map f x = 
    inl rec loop = function
        | x when caseable_is x -> f x
        | () -> ()
        | x :: xs -> loop x :: loop xs
        | {} & x -> module_map (inl _ -> loop) x
        | x -> f x
    loop x

inl rec toa_map2 f a b = 
    inl rec loop = function
        | x, y when caseable_is x || caseable_is y -> f x y
        | (), () -> ()
        | x :: xs, y :: ys -> loop (x,y) :: loop (xs,ys)
        | {} & x, {} & y -> module_map (inl k y -> loop (x k,y)) y
        | x, y -> f x y
    loop (a,b)

inl toa_iter f = toa_map (inl x -> f x; ()) >> ignore
inl toa_iter2 f a b = toa_map2 (inl a b -> f a b; ()) a b |> ignore

inl init_template {create set layout} (!map_dims size) f =
    match Tuple.length size with
    | 0 -> error_type "The number of dimensions to init must exceed 0. Use `ref` instead."
    | num_dims ->
        inl len :: dim_offsets = Tuple.scanr (inl (!dim_size dim) s -> dim * s) size 1
        inl f = if num_dims = 1 then (inl x :: () -> f x) else f
        inl ty = type (f (Tuple.repeat num_dims 0))
        inl ar = create ty len
        inl rec loop offset index = function
            | {from to} :: size, dim_offset :: dim_offsets ->
                for {from to state=offset; body=inl {state=offset i} ->
                    loop offset (i :: index) (size,dim_offsets)
                    offset+dim_offset
                    } |> ignore
            | (),() -> f (Tuple.rev index) |> set offset ar
        loop (dyn 0) () (size,dim_offsets)
        heap {size ar layout}

inl init_toa = init_template {
    create = inl ty len -> toa_map (inl ty -> Array.create ty len) ty
    set = inl offset -> toa_iter2 (inl a b -> a offset <- b) 
    layout = .toa
    }

inl init_aot = init_template {
    create = Array.create
    set = inl offset ar b -> ar offset <- b
    layout = .aot
    }

inl init = init_toa

inl index_template is_safe x i = 
    inl {ar layout} = x
    inl offset = offset_at_index is_safe x i
    match layout with
    | .aot -> ar offset
    | .toa -> toa_map (inl ar -> ar offset) ar

inl set_template is_safe x i v = 
    inl {ar layout} = x
    inl offset = offset_at_index is_safe x i
    inl body ar v = ar offset <- v
    match layout with
    | .aot -> body ar v
    | .toa -> toa_iter2 body ar v

inl index = index_template true
inl index_unsafe = index_template false
inl set = set_template true
inl set_unsafe = set_template false

inl total_size = function
    | _ :: _ as x -> Tuple.foldl (inl s x -> s * dim_size x) 1 x
    | x -> x

inl map_tensor_ar f {ar layout} =
    match layout with
    | .aot -> f ar
    | .toa -> toa_map f ar

inl elem_type = map_tensor_ar (inl ar -> ar.elem_type)
inl map_tensor f {size ar layout} & tns = { size layout ar = map_tensor_ar f tns }
                
{init init_toa init_aot index index_unsafe set set_unsafe toa_map toa_map2 toa_iter toa_iter2 dim_size
 total_size map_tensor_ar elem_type map_tensor} |> stack
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

inl compile_kernel_using_nvcc_bat_router (kernels_dir: string) =
    inl path_type = fs [text: "System.IO.Path"]
    inl file_type = fs [text: "System.IO.File"]
    inl stream_type = fs [text: "System.IO.Stream"]
    inl streamwriter_type = fs [text: "System.IO.StreamWriter"]
    inl process_start_info_type = fs [text: "System.Diagnostics.ProcessStartInfo"]
    inl combine x = FS.StaticMethod path_type .Combine x string

    inl nvcc_router_path = combine (kernels_dir,"nvcc_router.bat")
    inl procStartInfo = FS.Constructor process_start_info_type ()
    FS.Method procStartInfo.set_RedirectStandardOutput true unit
    FS.Method procStartInfo.set_RedirectStandardError true unit
    FS.Method procStartInfo.set_UseShellExecute false unit
    FS.Method procStartInfo.set_FileName nvcc_router_path unit

    inl (use) a b =
        inl r = b a
        FS.Method a.Dispose() unit
        r

    inl process_type = fs [text: "System.Diagnostics.Process"]
    use process = FS.Constructor process_type ()
    FS.Method process .set_StartInfo procStartInfo unit
    inl print_to_standard_output = 
        closure_of (inl args -> FS.Method args.get_Data() string |> writeline) 
            (fs [text: "System.Diagnostics.DataReceivedEventArgs"] => ())

    FS.Method process ."OutputDataReceived.Add" print_to_standard_output ()
    FS.Method process ."ErrorDataReceived.Add" print_to_standard_output ()

    inl concat = string_concat ""
    inl (+) a b = concat (a, b)

    /// Puts quotes around the string.
    inl quote x = ('"',x,'"')
    inl call x = ("call ", x)
    inl quoted_vs_path_to_vcvars = combine(visual_studio_path, @"VC\Auxiliary\Build\vcvarsx86_amd64.bat") |> quote
    inl quoted_vs_path_to_cl = combine(visual_studio_path, @"VC\Tools\MSVC\14.11.25503\bin\Hostx64\x64\cl.exe") |> quote
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

        call quoted_vs_path_to_vcvars
        |> concat |> inl x -> FS.Method nvcc_router_stream.WriteLine x unit
        (
        quoted_nvcc_path, " -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017 -ccbin ", quoted_vs_path_to_cl,
        " -I", quoted_cuda_toolkit_path_to_include,
        " -I", quoted_cub_path_to_include,
        " -I", quoted_vc_path_to_include,
        " --keep-dir ",quoted_kernels_dir,
        " -maxrregcount=0  --machine 64 -ptx -cudart static  -o ",quoted_target_path,' ',quoted_input_path
        ) |> concat |> inl x -> FS.Method nvcc_router_stream.WriteLine x unit

    inl stopwatch_type = fs [text: "System.Diagnostics.Stopwatch"]
    inl timer = FS.StaticMethod stopwatch_type .StartNew () stopwatch_type
    if FS.Method process.Start() bool = false then failwith unit "NVCC failed to run."
    FS.Method process.BeginOutputReadLine() unit
    FS.Method process.BeginErrorReadLine() unit
    FS.Method process.WaitForExit() unit

    inl exit_code = FS.Method process.get_ExitCode() int32
    if exit_code <> 0i32 then failwith unit <| concat ("NVCC failed compilation with code ", exit_code)
    
    inl elapsed = FS.Method timer .get_Elapsed() (fs [text: "System.TimeSpan"])
    !MacroFs(unit,[text: "printfn \"The time it took to compile the Cuda kernels is: %A\" "; arg: elapsed])

    FS.Method context.LoadModulePTX target_path (fs [text: "ManagedCuda.BasicTypes.CUmodule"])

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

    {create = inl x -> FS.Constructor CudaStream_type x
     extract = inl x -> FS.Method x.get_Stream() CUstream_type } |> stack

inl run {blockDim=!dim3 blockDim gridDim=!dim3 gridDim kernel} as runable =
    inl to_obj_ar args =
        inl len = Tuple.length args
        inl typ = fs [text: "System.Object"]
        if len > 0 then Array.init.static len (inl x -> Tuple.index args x :> typ)
        else Array.empty typ

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
    FS.Method cuda_kernel.set_GridDimensions(dim3 gridDim) unit
    FS.Method cuda_kernel.set_BlockDimensions(dim3 blockDim) unit

    match runable with
    | {stream} -> FS.Method cuda_kernel.RunAsync(Stream.extract stream,args) unit
    | _ -> FS.Method cuda_kernel.Run(args) float32


{Stream context dim3 run}
    """) |> module_

