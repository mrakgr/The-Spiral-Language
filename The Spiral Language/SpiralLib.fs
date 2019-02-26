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


