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

let array: SpiralModule =
    {
    name="Array"
    prerequisites=[]
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
]
    """
    }

let loops: SpiralModule =
    {
    name="loops"
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
    from: to: by: = self from: check: (inl from -> from <= near_to) by:
    from: to: = self from: to: by: 1
    from_down: near_to: by: = self from: from_down check: (inl from -> from > near_to) by:
    from_down: near_to: = self from_down: near_to: by: -1
    from_down: to: by: = self from: from_down check: (inl from -> from >= near_to) by:
    from_down: to: = self from_down: near_to: by: -1
    ]

for = self settings: {cps=false}
for' = self settings: {cps=true}
]
    """
    }