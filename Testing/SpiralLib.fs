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
type:text: = self type: args: (text:)
/// Creates a line of text with the unit type. Good for comments.
comment: x = self type: () args: (text: x)
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

/// Macro for the global methods.
type: method: args: =
    self
        type:
        args:
            text: method
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

class: types: args: methods: =
    inl x = self class:types:args:
    inl a ->
        match methods a with
        | type:method:args: -> self type:class: x method:args:
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
    if while state then self while: state: body state: body
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
        inl r = self.scanr f xs s
        f x (head r) :: r
    | () -> s :: ()

append=foldr (::)
concat=inl x -> foldr append x ()

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

init = self.init_template rev
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
            (rev a, b)
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

map_foldl2 f s a b = 
    match a,b with
    | a :: a', b :: b' ->
        inl l, s = f s a b
        inl l', s = self.map_foldl2 f s a' b'
        l :: l', s
    | (), () -> (), s

length = foldl (inl s _ -> s+1) 0
]
    """
    }

let array: SpiralModule =
    {
    name="Array"
    prerequisites=[loop;tuple]
    opens=[]
    description=""
    code=
    """
[
facade: ar =
    [
    /// Returns the length of an array. Not applicable to Cuda arrays.
    length = !ArrayLength(ar)
    /// Gets the value from the array at index `get`.
    get: = !GetArray(ar, get)
    /// Sets the value `to` the array at index `set`
    set:to: = !SetArray(ar, set, to)
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
    inl ar = 
        self
            type: type 
                inl i = dyn 0 
                join init i
            size:

    Loop.for
        (from:0 near_to: size)
        (body:inl i: -> ar set: i to: join init i)

    ar

/// Applies a function to each elements of the collection, threading an accumulator argument through the computation.
/// If the input function is f and the elements are i0..iN then computes f..(f i0 s)..iN.
/// (s -> a -> s) -> s -> a array -> s
foldl=inl f state ar -> Loop.for (from:0 near_to:ar.length) (state: body:inl state: i: -> f state (ar i))

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

/// Applies the function to every element of the array.
/// (a -> unit) -> a array -> unit
iter=inl f x -> Loop.for (from:0 near_to: x.length) (body:inl i: -> f (x i))

/// Returns a new array containing only elements of the array for which the predicate function returns `true`.
/// (a -> bool) -> a array -> a array
filter=inl f ar ->
    inl init = self type: ar.elem_type size: ar.length
    self init: size: self .foldl (inl s x -> if f x then init set: s to: x; s+1 else s) (dyn 0) ar

///// Merges all the arrays in a tuple into a single one.
///// a array tuple -> a array
//append=inl l ->
//    inl ar' = self type: (fst l).elem_type size: Tuple.foldl (inl s l -> s + l.length) 0 l
//    inl ap s ar = self.foldl (inl i x -> ar' set: i to: x; i+1) s ar
//    Tuple.foldl ap (dyn 0) l |> ignore
//    ar'

///// Flattens an array of arrays into a single one.
///// a array array -> a array
//inl concat ar =
//    inl count = foldl (inl s ar -> s + array_length ar) (dyn 0) ar
//    inl ar' = array_create ar.elem_type.elem_type count
//    (foldl << foldl) (inl i x -> ar' i <- x; i+1) (dyn 0) ar |> ignore
//    ar'

///// Tests if all the elements of the array satisfy the given predicate.
///// (a -> bool) -> a array -> bool
//inl forall f ar = for' {from=0; near_to=array_length ar; state=true; body = inl {next state i} -> f (ar i) && next state}

///// Tests if any the element of the array satisfies the given predicate.
///// (a -> bool) -> a array -> bool
//inl exists f ar = for' {from=0; near_to=array_length ar; state=false; body = inl {next state i} -> f (ar i) || next state}

//inl sort ar = macro.fs ar [text: "Array.sort "; arg: ar]
//inl sort_descending ar = macro.fs ar [text: "Array.sortDescending "; arg: ar]

]
    """
    }
