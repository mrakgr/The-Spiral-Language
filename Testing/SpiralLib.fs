module Spiral.Lib
open CoreLib
open Types

let macro: SpiralModule =
    {
    name="Macro"
    prerequisites=[]
    opens=[]
    description=""
    code=
    """
[
/// Creates a macro using the type.
type: t args: = !Macro(args,t)
/// Creates a macro as a type.
extern: t args: = !MacroExtern(args,t)
/// Creates a line of text. Good for accessing global constants.
type: text: = self type: args: (text:)
extern: text: = self extern: args: (text:)

/// Creates a line of text with the unit type. Good for comments.
comment: x = self type: () args: (text: "() // "), (text: x)

/// Macro for the global methods.
type: global_method: args: =
    self
        type:
        args:
            text: global_method
            :: self rounds: args

/// Class creation using the global method.
class: global_method: args: = 
    self 
        extern: 
            text: class
        args:
            text: global_method
            :: self rounds: args

/// Macro for operators.
type: separate: a and: b by: sep =
    self 
        type:
        args:
            variable: a
            ,text: sep
            ,variable: b

/// Class method call.
type: class: method: args: =
    self
        type:
        args:
            variable: class
            :: text: "."
            :: text: method
            :: self rounds: args

extern: class: method: args: =
    self
        extern:
        args:
            variable: class
            :: text: "."
            :: text: method
            :: self rounds: args

/// Class create.
class: args: =
    self 
        extern: 
            text: class
        args:
            text: class
            :: self rounds: args

class: types: args: =
    self 
        extern: 
            text: class
            :: self jaggeds: types
        args:
            text: class
            :: self jaggeds: types
            :: self rounds: args

class: args: methods: =
    inl x = self class:args:
    inl a ->
        match methods a with
        | type:method:args: -> self type:class: x method:args:

class: types: args: methods: =
    inl x = self class:types:args:
    inl a ->
        match methods a with
        | type:method:args: -> self type:class: x method:args:

/// Surrounds a sequence of macro instructions with brackets. Applies `map` to each element in the sequence.
brackets: open, close sep: args: map: f =
    inl close = (text: close) :: ()
    inl rec loop = function
        | () -> close
        | x :: x' -> (text: sep) :: f x :: loop x'
        
    text: open
    ::
    match args with
    | x :: x' -> f x :: loop x'
    | () -> close
    | x -> f x :: close

/// Surrounds a sequence of macro instructions with parentheses. Assumes that each element in the sequence is a variable.
rounds: args = self brackets: "(",")" sep: ", " args: args map:(inl x -> variable: x)
/// Surrounds a sequence of macro instructions with jagged brackets. Assumes that each element in the sequence is a type.
jaggeds: args = self brackets: "<",">" sep: ", " args: args map:(inl x -> type: x)
/// Surrounds a sequence of macro instructions with jagged brackets. For C++ templates.
jaggeds': args = self brackets: "<",">" sep: ", " args: args map:id
]
    """
    }

let loop: SpiralModule =
    {
    name="Loop"
    prerequisites=[]
    opens=[]
    description=""
    code=
    """
[
while: state: body: = join
    if while state then self while: state: body state body:
    else state
    : state

settings: =
    [
    from:!dyn from check: by: =
        [
        state: body: finally: = 
            inl finally =
                inl f x = Type eq: finally to: x
                if f id || f ignore then finally
                else inl state -> join finally state

            inl rec loop from: state: = join
                if check from then
                    if settings.cps then
                        inl next state = loop from: from + by state:
                        body next: state: i: from 
                    else
                        loop from: from + by state: (body state: i: from)
                else finally state
                : finally state
            loop from: state:
        state: body: = self state: body: finally: id
        body: finally: = 
            inl body = 
                if settings.cps then (inl next: state: i: -> body next: i:)
                else (inl state: i: -> body i:)
            self state: () body: finally:
        body: = self body: finally: id
        ]

    from: near_to: by: = self from: check: (inl from -> from < near_to) by:
    from: near_to: = self from: near_to: by: 1
    from: to: by: = self from: check: (inl from -> from <= to) by:
    from: to: = self from: to: by: 1
    from_down: near_to: by: = self from: from_down check: (inl from -> from > near_to) by:
    from_down: near_to: = self from_down: near_to: by: -1
    from_down: to: by: = self from: from_down check: (inl from -> from >= to) by:
    from_down: to: = self from_down: to: by: -1
    ]

for = self settings: {cps=false}
for' = self settings: {cps=true}
]
    """
    }

let tuple: SpiralModule =
    {
    name="Tuple"
    prerequisites=[]
    opens=[]
    description="Operations on tuples."
    code=
    """
[
singleton=inl x -> x :: ()
wrap=function
    | _ :: _ | () as x -> x
    | x -> x :: ()

unwrap=inl (x :: () | x) -> x

foldl=inl f s -> function
    | x :: xs -> self.foldl f (f s x) xs
    | () -> s

foldr=inl f l s ->
    match l with
    | x :: xs -> f x (self.foldr f xs s)
    | () -> s

reducel=inl f l ->
    match l with
    | x :: xs -> self.foldl f x xs
    | () -> Type error: "Reduce must receive a non-empty tuple as input."

scanl=inl f s -> function
    | x :: xs -> s :: self.scanl f (f s x) xs
    | () -> s :: ()

scanr=inl f l s ->
    match l with
    | x :: xs -> 
        inl r :: _ as r' = self.scanr f xs s
        f x r :: r'
    | () -> s :: ()

append=self.foldr (::)
concat=inl x -> self.foldr self.append x ()

rev=self.foldl (inl s x -> x :: s) ()
map=inl f -> function
    | x :: x' -> f x :: self.map f x'
    | () -> ()

iter=inl f -> function
    | x :: x' -> f x; self.map f x'
    | () -> ()
iteri=inl f -> self.foldl f 0

choose=inl f -> function
    | a :: a' ->
        match f a with
        | () -> self.choose f a'
        | x -> x :: self.choose f a'
    | () -> ()

map2=inl f a b ->
    match a,b with
    | a :: as', b :: bs' -> f a b :: self.map2 f as' bs'
    | (), () -> ()
    | _ -> Type error: "The two tuples have uneven lengths." 

choose2=inl f a b ->
    match a, b with
    | a :: as', b :: bs' -> 
        match f a b with
        | () -> self.choose2 f as' bs'
        | x -> x :: self.choose2 f as' bs'
    | (), () -> ()
    | _ -> Type error: "The two tuples have uneven lengths." 

iter2=inl f a b ->
    match a,b with
    | a :: as', b :: bs' -> f a b; self.iter2 f as' bs'
    | (), () -> ()
    | _ -> Type error: "The two tuples have uneven lengths." 

map3=inl f a b c ->
    match a,b,c with
    | a :: as', b :: bs', c :: cs' -> f a b c :: self.map3 f as' bs' cs'
    | (), (), () -> ()
    | _ -> Type error: "The three tuples have uneven lengths." 

foldl2=inl f s a b ->
    match a,b with
    | a :: as', b :: bs' -> self.foldl2 f (f s a b) as' bs'
    | (), () -> s
    | _ -> Type error: "The two tuples have uneven lengths." 

foldr2=inl f a b s ->
    match a,b with
    | a :: a', b :: b' -> f a b (self.foldr2 f a' b' s)
    | (), () -> s

forall=inl f -> function
    | x :: xs -> f x && self.forall f xs
    | () -> true

forall2=inl f x y ->
    match x,y with
    | x :: xs, y :: ys -> f x y && self.forall2 f xs ys
    | (), () -> false

exists=inl f -> function
    | x :: xs -> f x || self.exists f xs
    | () -> false

exists2=inl f x y ->
    match x,y with
    | x :: xs, y :: ys -> f x y || self.exists2 f xs ys
    | (), () -> false

filter=inl f -> function
    | x :: xs -> if f x then x :: self.filter f xs else self.filter f xs
    | () -> ()

init_template=inl k n f ->
    inl rec loop n = 
        match n with 
        | n when n > 0 -> 
            inl n = n - 1
            f n :: loop n
        | 0 -> ()
        | _ -> Type error: "The input to this function cannot be static or less than 0 or not an int."
    loop n |> k

init = self.init_template self.rev
repeat = inl n x -> self.init_template id n (inl _ -> x)
min: max: = 
    inl l = max-min+1
    if l > 0 then self.init l ((+) min)
    else Type error: "The inputs to range must be both static and the length of the resulting tuple must be greater than 0."

tryFind=inl f -> function
    | x :: xs -> if f x then some: x else self.tryFind f xs
    | () -> .none

contains=inl t x ->
    match self.tryFind ((=) x) t with
    | some: x -> true
    | .none -> false

intersperse=inl sep -> function
    | _ :: () as x -> x
    | x :: xs -> x :: sep :: self.intersperse sep xs
    | _ -> Type error: "Not a tuple."

split_at=inl n l ->
    assert (Is lit: n) "The index must be a literal."
    assert (n >= 0) "The input must be positive or zero."
    inl rec loop n a b = 
        if n > 0 then 
            match b with
            | x :: x' -> loop (n-1) (x :: a) x'
            | _ -> Type error: "Index out of bounds."
        else
            (self.rev a, b)
    loop n () l

take=inl n l -> self.split_at n l |> fst
drop=inl n l -> self.split_at n l |> snd

map_foldl=inl f s l ->
    match l with
    | l :: l' ->
        inl l, s = f s l
        inl l', s = self.map_foldl f s l'
        l :: l', s
    | () -> (), s

map_foldr=inl f l s ->
    match l with
    | l :: l' ->
        inl l', s = self.map_foldr f l' s
        inl l, s = f l s
        l :: l', s
    | () -> (), s

mapi=inl f -> self.map_foldl (inl s x -> f s x, s + 1) 0 >> fst

find=inl f -> function
    | x :: () -> if f x then x else failwith x "Key cannot be found."
    | x :: x' -> if f x then x else self.find f x'
    | _ -> Type error: "Expected a non-empty tuple as input to this."

map_foldl2=inl f s a b ->
    match a,b with
    | a :: a', b :: b' ->
        inl l, s = f s a b
        inl l', s = self.map_foldl2 f s a' b'
        l :: l', s
    | (), () -> (), s

length=self.foldl (inl s _ -> s+1) 0
]
    """
    }

let array: SpiralModule =
    {
    name="Array"
    prerequisites=[macro;loop;tuple]
    opens=[]
    description=""
    code=
    """
[
facade: ar =
    [
    name="Array"
    /// Returns the length of an array. Not applicable to Cuda arrays.
    length = !ArrayLength(ar)
    /// Gets the value from the array at index `get`.
    get: = !GetArray(ar, get)
    at: i = self get: i
    /// Sets the value `to` the array at index `set`
    set:to: = !SetArray(ar, set, to)
    at: i put: v = self set: i to: v
    /// Adds to a particular field.
    at: i add: v = self set: i to: (self get: i) + v
    /// Gets the value from the array at index `apply`.
    apply: = !GetArray(ar, apply)
    elem_type = type !GetArray(ar, 0)
    ]

/// Creates an .NET array with the given type and the size.
type: t size: = self facade: !ArrayCreateDotNet(t,size)
type: t = self facade: type !ArrayCreateDotNet(t,1)

.cuda = 
    inl super = self
    [
    /// Creates a Cuda local memory array with the given type and the size.
    local = 
        [
        type: t size: = super facade: !ArrayCreateCudaLocal(t,size)
        type: t = super facade: type !ArrayCreateCudaLocal(t,1)
        ]

    /// Creates a Cuda shared memory array with the given type and the size.
    shared = 
        [
        type: t size: = super facade: !ArrayCreateCudaShared(t,size)
        type: t = super facade: type !ArrayCreateCudaShared(t,1)
        ]
    ]

// Creates an array given a dimension and a generator function to compute the elements.
// int -> (int -> a) -> a array
init=inl size init -> self init: size:
init: size: =
    inl init !dyn i = join init i
    inl ar = self type: type init 0 size:

    Loop.for from:0 near_to: size
        body:inl i: -> ar set: i to: init i

    ar

copy=inl x -> self init: x size: x.length

replicate=inl size replicate -> self replicate: size:
replicate: v size: = self init: const v size:

/// Applies a function to each elements of the collection, threading an accumulator argument through the computation.
/// If the input function is f and the elements are i0..iN then computes f..(f i0 s)..iN.
/// (s -> a -> s) -> s -> a array -> s
foldl=inl f state ar -> Loop.for (from:0 near_to:ar.length) (state: body:inl state: i: -> f state (ar i))
sum=inl x -> self .foldl (+) (dyn <| Type type: x.elem_type convert: 0) x

/// Applies a function to each element of the array, threading an accumulator argument through the computation. 
/// If the input function is f and the elements are i0...iN then computes f i0 (...(f iN s)).
/// (a -> s -> a) -> a array -> s -> s
foldr=inl f ar state -> Loop.for (from_down:ar.length-1 to:0) (state: body:inl state: i: -> f (ar i) state)

/// Builds a new array that contains elements of a given array.
/// copy: a array -> a array
copy: ar = self init: ar size: ar.length

/// Builds a new array whose elements are the result of applying a given function to each of the elements of the array.
/// (a -> b) -> a array -> a array
map=inl f ar -> self init: ar >> f size: ar.length
map2=inl f b a -> 
    inl size = a.length
    assert 
        cond: b.length = size
        msg: "The two arrays must have the same length."

    self init: (inl i -> f (b i) (a i)) size:

/// Applies the function to every element of the array.
/// (a -> unit) -> a array -> unit
iter=inl f -> self.iteri (const f)
/// Applies the function to every element of the array. Also passes it the index of the current element.
/// (int -> a -> unit) -> a array -> unit
iteri=inl f x -> Loop.for (from:0 near_to: x.length) (body:inl i: -> f i (x i)) 
iter2=inl f -> self.iter2i (const f)
iter2i=inl f b a -> 
    inl near_to = a.length
    assert
        cond: b.length = near_to
        msg: "The two arrays must have the same length."

    Loop.for (from:0 near_to:) (body:inl i: -> f i (b i) (a i)) 

/// Returns a new array containing only elements of the array for which the predicate function returns `true`.
/// (a -> bool) -> a array -> a array
filter=inl f ar ->
    inl init = self type: ar.elem_type size: ar.length
    self init: size: self .foldl (inl s x -> if f x then init set: s to: x; s+1 else s) (dyn 0) ar

/// Merges all the arrays in a tuple into a single one.
/// a array tuple -> a array
append=inl l ->
    inl ar' = self type: (fst l).elem_type size: Tuple.foldl (inl s l -> s + l.length) 0 l
    inl ap = self.foldl (inl i x -> ar' set: i to: x; i+1)
    Tuple.foldl ap (dyn 0) l |> ignore
    ar'

/// Flattens an array of arrays into a single one.
/// a array array -> a array
concat=inl ar ->
    inl count = self.foldl (inl s ar -> s + ar.length) (dyn 0) ar
    inl ar' = self type: ar.elem_type.elem_type size: count
    (self.foldl << self.foldl) (inl i x -> ar' set: i to: x; i+1) (dyn 0) ar |> ignore
    ar'

/// Tests if all the elements of the array satisfy the given predicate.
/// (a -> bool) -> a array -> bool
forall=inl f ar -> Loop.for' (from:0 near_to: ar.length) (state:true body:inl next: i: -> f (ar i) && next true)

/// Tests if any the element of the array satisfies the given predicate.
/// (a -> bool) -> a array -> bool
exists=inl f ar -> Loop.for' (from:0 near_to: ar.length) (state:true body:inl next: i: -> f (ar i) || next false)

sort=inl ar -> Type macro: ar method: "Array.sort " args: ar
sort_descending=inl ar -> Type macro: ar method: "Array.sortDescending " args: ar
]
    """
    }

let console: SpiralModule =
    {
    name="Console"
    prerequisites=[macro]
    opens=[]
    description="IO printing functions."
    code=
    """
[
readall =
    Macro
        class: "System.IO.Stream"
        global_method: "System.Console.OpenStandardInput"
        args: ()
    |> inl args -> 
        Macro 
            class: "System.IO.StreamReader"
            args:
    |> inl class ->
        Macro
            type: ""
            class:
            method: "ReadToEnd"
            args: ()

readline = 
    Macro
        type: ""
        global_method: "System.Console.ReadLine"
        args: ()

write=inl x -> self write: x
write: args = 
    match args with
    | () -> ()
    | _ -> 
        Macro
            type: ()
            global_method: "System.Console.Write"
            args:

writeline=inl x -> self writeline: x
writeline: args = 
    Macro
        type: ()
        global_method: "System.Console.WriteLine"
        args:

printf=inl a b -> self write: String (format: a args: b)
printfn=inl a b -> self writeline: String (format: a args: b)
]
    """
    }

let option: SpiralModule =
    {
    name="Option"
    prerequisites=[]
    opens=[]
    description="The Option module."
    code=
    """
[
raw: x = (some: x) \/ .none
some=inl x -> Type box: (some: x) to: (self raw: x)
none=inl x -> Type box: .none to: (self raw: x)
]
    """
    }

let list: SpiralModule =
    {
    name="List"
    prerequisites=[loop; option; tuple]
    opens=[]
    description="The List module."
    code=
    """
[
raw: elem_type =
    Type 
        name: "List"
        meta: elem_type
        join: inl _ -> .nil \/ cons: elem_type, self (raw: elem_type)

/// Creates an empty list with the given type.
/// t -> t List
nil=inl a -> Type box: .nil to: self (raw: a)

/// Immutable appends an element to the head of the list.
/// x -> x List -> x List
cons=inl a b -> Type box: (cons: a, b) to: self (raw: a)

/// Creates a single element list with the given type.
/// x -> x List
singleton=inl x -> self.cons x (self.nil x)

/// Creates a list by calling the given generator on each index.
/// int -> (int -> a) -> a List
init=inl size init -> self init: size:
init: size: =
    inl init !dyn i = join init i
    inl elem_type = type init 0
    Loop.for' from:0 to:size
        state: self.nil elem_type
        body: inl next: state: i: -> self.cons (init i) (next state)

/// Returns the element type of the list.
/// a List -> a type
elem_type=inl l -> Type meta: l

/// Builds a new list whose elements are the results of applying the given function to each of the elements of the list.
/// (a List -> b List) -> a List -> b List
map=inl f l -> self map: f value: l
map: f value: l =
    inl recurse value = self map: f value:
    inl body type: t map: f = 
        match l with 
        | #(cons: x,xs) -> self.cons (f x) (recurse xs)
        | _ -> self.nil t

    if Is box: l then
        inl t = type self.elem_type l |> f
        body type: t map: f
    else
        inl f (!dyn x) = join f x
        inl t = type self.elem_type l |> f
        join (body type: t map: f) : self raw: t
        
default_finally: finally =
    inl f x = Type eq: finally to: x
    if f id || f ignore then finally else (inl state -> join finally state)

/// The CPS'd version of foldl.
foldl: f state: value: l finally: =
    inl recurse state: value: = self foldl: f state: value: finally:
    inl body finally: =
        match l with
        | #(cons: x, xs) -> f next: (inl state -> recurse state: value: xs) state: value: x
        | _ -> finally state

    if Is box: l then
        body finally:
    else
        inl finally = self default_finally: finally
        join (body finally:) : finally state

/// Applies a function f to each element of the collection, threading an accumulator argument through the computation. 
/// The fold function takes the second argument, and applies the function f to it and the first element of the list. 
/// Then, it feeds this result into the function f along with the second element, and so on. It returns the final result. 
/// If the input function is f and the elements are i0...iN, then this function computes f (... (f s i0) i1 ...) iN.
/// (s -> a -> s) -> s -> a List -> s
foldl=inl fold state value -> self foldl: (inl next: state: value: -> next (fold state value)) state: value: finally: id

/// Applies a function to each element of the collection, threading an accumulator argument through the computation. 
/// If the input function is f and the elements are i0...iN, then this function computes f i0 (...(f iN s)).
/// (a -> s -> s) -> a List -> s -> s
foldr=inl f value state -> self foldr: f state: value:
foldr: f state: value: =
    inl body _ =
        match value with
        | #(cons: x, xs) -> f x (self foldr: f state: value: xs)
        | _ -> state

    if Is box: value then body()
    else join body() : state

/// Returns the first element of the list.
/// a List -> some:(a -> a) none:(a type -> a) -> a
head'=inl l some: none: ->
    inl t = self.elem_type l
    match l with
    | #(cons: x, xs) -> some x
    | _ -> none t

/// Returns the list without the first element.
/// a List -> some:(a List -> a List) none:(a List type -> a List) -> a List
tail'=inl l some: none: ->
    inl t = self.elem_type l
    match l with
    | #(cons: x, xs) -> some xs
    | _ -> none (self raw: t)

/// Returns the last element of the list.
/// a List -> some:(a -> a) none:(a type -> a) -> a
last'=inl l some: none: ->
    inl t = self.elem_type l
    inl loop = function
        | #(cons: x, xs) -> self.last' xs some: none: some x
        | _ -> none t
    if Is box: l then loop l
    else join loop l : none t

/// Returns the first element of the list.
/// a List -> a Option
head=inl l -> self.head' l some: Option.some none: Option.none

/// Returns the list without the first element.
/// a List -> a List Option
tail=inl l -> self.tail' l some: Option.some none: Option.none

/// Returns the last element of the list.
/// a List -> a Option
last=inl l -> self.last' l some:const << Option.some none: Option.none

/// Returns a new list that contains the elements of the first list followed by elements of the second.
/// a List -> a List -> a List
append = self.foldr self.cons

/// Returns a new list that contains the elements of each list in order.
/// a List List -> a List
concat=inl l -> self.foldr self.append l (self.nil (self.elem_type t |> self.elem_type)
]
    """
    }

let string_builder: SpiralModule =
    {
    name="StringBuilder"
    prerequisites=[macro]
    opens=[]
    description="Parser combinators."
    code=
    """
inl x -> 
    inl x =
        Macro
            class: "System.Text.StringBuilder"
            args: x
    [
    Append: a = 
        Macro
            type: x
            class: x
            method: "Append"
            args: a
    AppendLine: a = 
        Macro
            type: x
            class: x
            method: "AppendLine"
            args: a
    ToString =
        Macro
            type: ""
            class: x
            method: "ToString"
            args: ()
    ]
    """
    }

let dictionary: SpiralModule =
    {
    name="Dictionary"
    prerequisites=[macro]
    opens=[]
    description="The Dictionary module."
    code=
    """
// A wrapped for the .NET Dictionary class.
inl (key:value:) x ->
    Macro
        class: "System.Collections.Generic.Dictionary"
        types: key,value
        args: x
        methods: // TODO: Add more methods.
            inl key = stack {elem_type=type key}
            inl value = stack {elem_type=type value}
            [
            Add: a : (key.elem_type), b =
                type: ()
                method: "Add"
                args: a, b
            Item: a =
                type: value.elem_type
                method: "Item"
                args: a
            ]
    """
    }

let random: SpiralModule =
    {
    name="Random"
    prerequisites=[macro;array]
    opens=[]
    description="The Random module."
    code=
    """
/// Wrapper for the standard .NET Random class.
inl _ : 0i32 | () as seed ->
    Macro
        class: "System.Random"
        args: seed
        methods:
            [
            Next=inl (min : 0i32, max : 0i32) | (max : 0i32) | () as args -> 
                type: 0i32
                method: "Next"
                args:
            NextDouble=
                type: 0f64
                method: "NextDouble"
                args: ()
            NextBytes=inl (ar : (Array type: 0u8)) -> 
                type: ()
                method: "NextBytes"
                args: ar
            ]
    """
    }

let time_it: SpiralModule =
    {
    name="TimeIt"
    prerequisites=[console]
    opens=[]
    description="The Timer module"
    code=
    """
inl TimeSpan x =
    Macro
        class: "System.TimeSpan"
        args: x

inl StopWatch() =
    Macro
        class: "System.Diagnostics.Stopwatch"
        args:()
        methods:
            [
            Start=
                type: ()
                method: "Start"
                args: ()
            Restart=
                type: ()
                method: "Restart"
                args: ()
            Reset=
                type: ()
                method: "Reset"
                args: ()
            Stop=
                type: ()
                method: "Stop"
                args: ()
            Elapsed=
                type: type TimeSpan()
                method: "get_Elapsed"
                args: ()
            ]

inl message: body: ->
    Console.printfn "Starting timing for: {0}" message
    inl stopwatch = StopWatch()
    stopwatch.Start
    inl r = body ()
    stopwatch.Stop
    Console.printfn "The time was {0} for: {1}" (stopwatch.Elapsed, message)
    r
    """
    }

let resize_array: SpiralModule =
    {
    name="ResizeArray"
    prerequisites=[array;loop]
    opens=[]
    description="The ResizeArray module."
    code=
    """
[
type: t size: =
    Macro
        class: "ResizeArray"
        types: t :: ()
        args: Type type: 0i32 convert: size
        methods: self (methods: stack {elem_type=type t})
type: t = 
    Macro
        class: "ResizeArray"
        types: t :: ()
        args: ()
        methods: self (methods: stack {elem_type=type t})
methods: t =
    [
    assert_is_elem_type: v =
        assert 
            cond: (Type eq: t.elem_type to: v)
            msg:
                message: "The type passed to the ResizeArray must match its element type."
                arg1: t.elem_type
                arg2: type v
    at: i set: v =
        self assert_is_elem_type: v
        type: ()
        method: "set_Item"
        args: (Type type: 0i32 convert: i), v
    at: i =
        type: t.elem_type
        method: "Item"
        args: (Type type: 0i32 convert: i)
    Clear =
        type: ()
        method: "Clear"
        args: ()
    Count =
        type: 0i32
        method: "Count"
        args: ()
    Add: v =
        self assert_is_elem_type: v
        type: ()
        method: "Add"
        args: v
    RemoveAt: i =
        type: ()
        method: "RemoveAt"
        args: (Type type: 0i32 convert: i)
    ToArray =
        type: (Array type: t.elem_type)
        method: "ToArray"
        args: ()
    elem_type = t.elem_type
    apply: i = self at: i
    ]
iter=inl f x ->
    Loop.for from: 0i32 near_to: x.Count by:1i32 
        body: inl i: -> f (x i)
foldl=inl f state x -> 
    Loop.for from:0i32 near_to: x.Count by:1i32
        state: 
        body: inl state: i: -> f state (x i)
foldr=inl f x state -> 
    Loop.for from_down: x.Count - 1i32 to:0i32 by: -1i32 
        state: 
        body: inl state: i: -> f (x i) state
foldl: f value: x state: finally: =
    Loop.for' from:0i32 near_to: x.Count by:1i32
        state:
        body:inl next: state: i: -> f next: state: value: x i
        finally:
foldr: f value: x state: finally: =
    Loop.for' from_down: x.Count - 1i32 to:0i32 by: -1i32
        state:
        body:inl next: state: i: -> f next: state: value: x i
        finally:
]
    """
    }