<!-- TOC -->

- [Motivation](#motivation)
- [Additions to the language](#additions-to-the-language)
    - [Keyword pattern and arguments](#keyword-pattern-and-arguments)
    - [Objects](#objects)
    - [Explicit unboxing via the `#` pattern](#explicit-unboxing-via-the--pattern)
    - [Record's `this`](#records-this)
- [Removals from the language](#removals-from-the-language)
    - [The direct `open`](#the-direct-open)
    - [`use`](#use)
    - [`met`](#met)
    - [`type_join`](#type_join)
    - [The User Guide](#the-user-guide)
    - [Unary operators](#unary-operators)
    - [Raw types in the `Core` library](#raw-types-in-the-core-library)
    - [Most of the module patterns](#most-of-the-module-patterns)
    - [`packed_stack` layout](#packed_stack-layout)
    - [`:=`, `<-`](#--)
- [Changes](#changes)
    - [`dyn`](#dyn)
    - [Tight application](#tight-application)
    - [Macros](#macros)
- [Bug fixes](#bug-fixes)
- [Library changes](#library-changes)
- [Current Status](#current-status)

<!-- /TOC -->

# Motivation

Date: 2/22/2019

Previously in development for over a year, in April 2018 the Spiral language came to maturity, and I've had good nine months or so to experience what it is like to program in a making of my own design. There is now a not insignificant amount of code written in Spiral itself, and my goal of making a ML library has been attained. The language has some of the best GPU programming capabilities out there, and the tensor datatype is still a pride point for Spiral.

While the Spiral language itself is highly expressive and powerful enough to meet my performance requirements, the previous version of Spiral was amateurishly implemented. Some things, particularly the way I was filtering the free variables for environments (which was an immutable map under the hood) was clearly crazy from a performance standpoint, even to the me of a year ago. It was done on every function creation and to make things worse, the `inl` bindings were actually done in lambda calculus style rather than with explicit `let` constructs in the language.

This and various other issues were something that was well known to me for a long time now. In fact, I tried dealing with them then and failed due to not knowing how.

Perhaps due to the accumulation of experience the attempt this time was a success.

Not only is the environment handled sanely in the partial evaluator thanks to the new prepass, but added to the language are the Smalltalk inspired keyword arguments and inbuilt objects. In addition to that the language internals have been greatly simplified. v0.09 of Spiral is a good example of how a static language with partial evaluation should look. v0.1 of Spiral is a good example of how such a language should be implemented. Standing at 4.35k LOC without the libraries, it is a neat and powerful little package.

# Additions to the language

## Keyword pattern and arguments

```fsharp
inl add (left: a right: b) = a + b
add left: 1 right: 2
```

While studying [Pharo](https://pharo.org/), I've been struck with just how readable the code is, even to a complete newcomer to the language, and had the idea that having them as a language construct would be good just for that. Under the hood, keywords are represented as integers, so comparing them for equality is performant at compile time, unlike with type literals.

```fsharp
inl add q =
    match q with
    | left: a right: b -> a + b
inl x = 
    left: 1 
    right: 2
add x
```

Like tuples and records (previously called modules), the keywords can be used on a first class basis.

```fsharp
inl add left:right: = left + right
add 
    left: 1 
    right: 2
```

Similarly to records, the right sides of patterns can be omitted, in which case they will default to the keywords' argument names.

```fsharp
inl add left:right: = left + right
inl left:right: = left:1 right:2
add 
    left:
    right:
```

Like for patterns, the keyword bodies can be left alone too. The above is equivalent to…

```fsharp
inl add left:right: = left + right
inl left:right: = left:1 right:2
add 
    left: left
    right: right
```

Keyword arguments are not just for speed. Unifying arguments and method names in objects is a significant improvement over the C calling style anti-pattern. It makes the code much more readable elsewhere when they are used, and it mentally reduces the amount of book-keeping needed by the brain.

After using them for only a week now, I've come to the conclusion that the style of using partially applied functions that I've imported into Spiral from F# is an anti-pattern here. Partial application is just fine in F# as one can just hover the mouse of the variable and get instant feedback at all times, but in Spiral such a style quickly became untenable. It is just too easy to miss an argument and get unreadable gibberish in the output. Even worse, refactoring becomes much harder.

This latest addition to the language is simple, and yet it is a wonderful thing. It should have been here from the start.

## Objects

Though all the functionality of objects at compile time can be achieved through functions + pattern matching in Spiral, there are some definite issues with that sort of arrangement.

```fsharp
inl f = function
    | .add a b -> a + b
    | .mult a b -> a * b
    
f .add 1 2
```

The above does exactly what one would expect, and is similar to having an object that has method fields. The key difference from an object is rather than using a quick dictionary lookup, the partial evaluator has to walk the entire body of the function testing for a match in turn. And in v0.09 of Spiral `.add` is a type literal. The way this used to be compiled is that the partial evaluator would make an instance of the type literal, string and all, and then compare it to the argument. Not a wise thing to do if the compilation is desired to be done in a timely fashion.

```fsharp
inl f = 
    [
    add = inl a b -> a + b
    mult = inl a b -> a * b
    ]
    
f .add 1 2
```

In v0.1 of Spiral the `.add` is a unary keyword, not a type literal. Apart from keywords having to be strings, the important difference is that under the hood the name of both keyword unary and keyword message arguments is represented by an int. Their actual bodies are represented by arrays. For unary keyword arguments those arrays are empty.

```fsharp
inl f = [
    add: a to: b = a+b
    add_tuple: a,b to: c,d = a+b+c+d
    ]
f (add: 1 to: 3) |> ignore
f (add_tuple: 1,2 to: 3,4)
```

Objects support arbitrary patterns. That said, they are not as flexible in that regard as functions — the object methods must start with a keyword pattern.

```fsharp
inl f = [
    add = inl a b -> a+b
    mult = inl a b -> a*b
    pass: message args: (left:right:) = self message left right
    ]
inl _ =
    f pass: .add args: (left: 1 right: 2)
inl _ =
    // Alternatively
    f   
        pass: .add 
        args: 
            left: 1 right: 2
// Alternatively
f   
    pass: .add 
    args: 
        inl a = 1
        inl b = 2
        left: a
        right: b
```

Inside the method body, the `self` variable holds the object's instance. This makes it easy to use objects for a role that would have needed a mutually recursive block of functions. There is a syntax rule that combines keywords on the same line into a single one. That is why `add: 1 to: 2` is not parsed as `add: (1 to: 2)` for example.

```fsharp
inl f = [
    apply: a,b = a+b
    ]
f (1, 2)
```

One last thing worth noting is the special `apply:` keyword. If the argument passed to an object is not a keyword, then the evaluator checks for the presence of that method and passes it the argument if it exists.

Spiral's objects are there for performance at compile time. Hence Spiral's objects cannot be updated like records, nor do they support inheritance.

```fsharp
[a=1; b=2; c=;3]
```

```fsharp
[
    a=1
    b=2; c=;3
]
```

Like for records, the object's fields can be separated by semicolons.

One last thing:

```fsharp
1 + [name="Tensor"]
```

Objects that are named have their names printed on type errors. The names have to be unary keywords with nothing else in the body for this to work.

```fsharp
...
The two sides need to have the same numeric types.
Got: int64 and Tensor.
```

When I started work on Spiral in 2017 I was really upbeat about functional programming and thought of OO as nothing but a burden, but after several months of programming experience in Spiral, I can confidently state that objects are extremely useful. It is not possible to make do without them and they definitely deserve their elevation to full language feature status.

## Explicit unboxing via the `#` pattern

Here is a showcase of the `#` pattern. 

```fsharp
inl option_int = .Some, (1,2,3) \/ .None

inl x = join Type (box: .None to: option_int)
match x with
| #(.Some, x) -> x 
| #(.None) -> 0,0,0
```

This compiles into...

```fsharp
type SpiralType0 =
    | SpiralType0_1 of int64 * int64 * int64
    | SpiralType0_2
let rec method_0 () : SpiralType0 =
    SpiralType0_2
let ((var_1 : SpiralType0)) = method_0 ()
let ((var_5 : int64), (var_6 : int64), (var_7 : int64)) =
    match var_1 with
    | SpiralType0_1 (var_2, var_3, var_4) ->
        (var_2, var_3, var_4)
    | SpiralType0_2 ->
        (0L, 0L, 0L)
```

Previously Spiral did its unboxing automatically on any non-trivial pattern. I did this with the aim of matching F# in appearance, but unfortunately that did not work too well. I've come to a realization that there are notable semantic differences between matching at compile time and runtime and that the two are not interchangeable. F# does all its matching at runtime so it is capable of optimizing for user experience, but if in Spiral one is using union types, then the code will definitely have to be written in a way that takes account of that.

I have a dichotomy in my mind about union types — on one hand, I see statically typed languages that do not support them as simply not getting **it** where **it** means **abstraction**. There is simply not a reason for a statically typed language to not have pattern matching + union types.

But on the other hand, Spiral's compile time features are so powerful that I've come to think of actually using union types as defeat. I had to use them in places in Spiral though. A thought growing in me is that if a task is so complex that their use is actually needed, then rather than writing an interpreter for the task maybe using an actual dynamic language would be a better choice.

## Record's `this`

```fsharp
inl f x = {x with 
    y = 
        match this with
        | () -> 0
        | y -> y+1
    }
dyn (f {}, f {y=5})
```

```fsharp
let ((var_1 : int64)) = 0L
let ((var_2 : int64)) = 6L
```

Record's `self` has been renamed to `this` and now can be matched on regardless of whether the field previously existed. In `v0.09` record's `self` would only be in the environment if the field previously was in the record.

Also to make the indentation rules more uniform between objects, keywords, and records, the indentation for parsing record expressions must be higher than the field.

```fsharp
{ 
    y = 
    1 // Syntax error
}
```

```fsharp
{ 
    y = 
     1 // Ok
}
```

# Removals from the language

## The direct `open`

```fsharp
open Array

map sqrt ar // Identical to `Array.map sqrt ar`
```

Previously `open` was used to export the contents of a module into the environment.

No longer is that possible. After some deliberation, I decided that the benefits of simplifying the prepass outweights having such a complex feature in the language. The issue is that opening a variable requires knowledge of what is in it and in Spiral that is impossible without doing partial evaluation up to that point. A lesser version of `open` that only accepts modules in the global namespace is possible, but would make it impossible to pipeline the parsing and the prepass in some future version of the Spiral language.

```fsharp
let example: SpiralModule =
    {
    name="example"
    prerequisites=[module1; module2]
    opens=[["Module1"]; ["Module2"; "Submodule1"]]
    description=""
    code=
    """
()
    """
    }
```

As an alternative to that, the opens are done at the module level now. The above is how opening will be done. Other languages can afford it as they have separate typechecking and partial evaluation passes, but in Spiral this is the best way.

Even in v0.09 I've always been hesitant about `open` since it lead to ambiguity as to the correct scope of variable.

Since in v0.1 what used to be modules can no longer be `open`ed, they have been renamed to records.

## `use`

```fsharp
inl (use) a b =
    inl r = b a
    FS.Method a .Dispose() unit
    r
```

Modeled after F#'s `use` keyword, this thing is out. `inb` covers its functionality anyway and there is no point in having two features doing the same thing.

Come to think of it, I allowed using language keywords as variables by wrapping them in parentheses in `inl`. I forgot that feature even existed in the language until I saw it while redoing the parser. And then forgot about it again until just now I saw the above fragment in the user guide. I can't imagine any better reason to remove a feature than forgetting that it even exists, so all of this is out now.

## `met`

`inl f x = join body` is equivalent to `met f x = body`. I wanted to make join points more explicit in the new version so I removed `met`. Now it should be easy to find join points by simply typing `join` into the search box.

## `type_join`

Only as a language keyword. Recursive union types can now have names so in fact their functionality has been extended. `print_static` on the following type will give its name.

```fsharp
let test14: SpiralModule =
    {
    name="test14"
    prerequisites=[]
    opens=[]
    description="Does recursive pattern matching work on partially static data?"
    code=
    """
inl rec expr x = 
    Type 
        name: "Arith"
        join:inl _ ->
            v: x
            \/ add: expr x, expr x
            \/ mult: expr x, expr x
        
inl int_expr x = Type (box: x to: expr 0)
inl v x = int_expr (v: x)
inl add a b = int_expr (add: a, b)
inl mult a b = int_expr (mult: a, b)
inl a = add (v 1) (v 2)
inl b = add (v 3) (v 4)
inl c = dyn (mult a b)

inl rec inter x = join
    inl #x = x
    match x with
    | v: x -> x
    | add: a, b -> inter a + inter b
    | mult: a, b -> inter a * inter b
    : 0

inter c
    """
    }
```

Here is an example of how to construct recursive union types. `Type` is an object in the `Core` library that passes the arguments to the inbuilt op. Here is the F# code this compiles to.

```fsharp
// Arith
type SpiralType0 =
    | SpiralType0_3 of int64
    | SpiralType0_2 of SpiralType0 * SpiralType0
    | SpiralType0_1 of SpiralType0 * SpiralType0
let rec method_0 ((var_1 : SpiralType0)) : int64 =
    match var_1 with
    | SpiralType0_3 var_2 ->
        var_2
    | SpiralType0_2 (var_3, var_4) ->
        let ((var_5 : int64)) = method_0 (var_3)
        let ((var_6 : int64)) = method_0 (var_4)
        var_5 + var_6
    | SpiralType0_1 (var_8, var_9) ->
        let ((var_10 : int64)) = method_0 (var_8)
        let ((var_11 : int64)) = method_0 (var_9)
        var_10 * var_11
let ((var_1 : SpiralType0)) = SpiralType0_1 (SpiralType0_2 (SpiralType0_3 1L, SpiralType0_3 2L), SpiralType0_2 (SpiralType0_3 3L, SpiralType0_3 4L))
let ((var_14 : int64)) = method_0 (var_1)
```

The generated code is quite concise and, compared to last time, has no needless intermediate structs allocated. In terms of code generation things have really come together. Compiling it like the above would always have been the most sensible thing to do, but various architectural constraints prevented such a thing.

```fsharp
type Rec0 =
    | Rec0Case0 of Tuple2
    | Rec0Case1 of Tuple3
    | Rec0Case2 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple2 =
    struct
    val mem_0: Rec0
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple3 =
    struct
    val mem_0: Rec0
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_1((var_0: Rec0)): int64 =
    match var_0 with
    | Rec0Case0(var_1) ->
        let (var_4: Rec0) = var_1.mem_0
        let (var_5: Rec0) = var_1.mem_1
        let (var_6: int64) = method_1((var_4: Rec0))
        let (var_7: int64) = method_1((var_5: Rec0))
        (var_6 + var_7)
    | Rec0Case1(var_2) ->
        let (var_9: Rec0) = var_2.mem_0
        let (var_10: Rec0) = var_2.mem_1
        let (var_11: int64) = method_1((var_9: Rec0))
        let (var_12: int64) = method_1((var_10: Rec0))
        (var_11 * var_12)
    | Rec0Case2(var_3) ->
        var_3.mem_0
let (var_0: Rec0) = (Rec0Case1(Tuple3((Rec0Case0(Tuple2((Rec0Case2(Tuple1(1L))), (Rec0Case2(Tuple1(2L)))))), (Rec0Case0(Tuple2((Rec0Case2(Tuple1(3L))), (Rec0Case2(Tuple1(4L)))))))))
method_1((var_0: Rec0))
```

As a showcase of the new Spiral's capabilities, here is how it would have been compiled in v0.09. I messed up last time and did too much destructuring work in the partial evaluator that is now being done in the code generator. The end result is much cleaner, readable generated code.

On the F# side, the tuples are no longer structs, but F#'s inbuilt tuples. Though value types would be more efficient overall for tuples, I am prioritizing the readability of the code in this iteration of Spiral. Should the need arise, modifying the codegen so the tuples get generated as structs would be trivial anyway, so I did not lose sleep over this decision.

Another new feature of type join points is the ability to embed metadata in the types directly. By metadata, most commonly that would be the generic type parameters.

```fsharp
inl rec List x = 
    Type 
        name: "List"
        meta: x
        join: inl _ -> .nil \/ cons: x, List x
```

Then the metadata can be retrieved using `Type meta:`. Here is an example of a map function.

```fsharp
inl rec map f l = 
    inl elem_type = type (Type meta: l) |> dyn |> f
    inl List = List elem_type
    join
        inl t x = Type box: x to: List
        inl nil = t .nil
        inl cons x xs = t (cons: x, xs)
        match l with
        | #(cons: x, xs) -> cons (f x) (map f xs)
        | #(.nil) -> nil
        : List

inl t x = Type box: x to: List 0.0
inl nil = t .nil
inl cons x xs = t (cons: x, xs)

nil |> cons 3.0 |> cons 2.0 |> cons 1.0 |> dyn |> map (inl x -> Type convert:x to: 0i32)
```

Dealing with types in Spiral is definitely harder than in F# where there it is all done automatically. Spiral cannot even compare to the elegance of using inbuilt lists in ML styled languages. Here is a alternative way of doing the same thing as the above:

```fsharp
inl List elem_type =
    [
    raw =
        Type 
            name: "List"
            meta: elem_type
            join: inl _ -> .nil \/ cons: elem_type, self .raw
    box: = Type box: to: self.raw
    nil = self box: .nil
    cons: x, x' = self box: (cons: x, x')
    cons = inl x x' -> self cons: x, x'
    ]

inl rec map f l = 
    inl elem_type = type (Type meta: l) |> dyn |> f
    inl List = List elem_type
    join
        match l with
        | #(cons: x, xs) -> List cons: f x, map f xs
        | #(.nil) -> List.nil
        : List.raw

inl List = List 0.0
List.nil |> List.cons 3.0 |> List.cons 2.0 |> List.cons 1.0 |> dyn |> map (inl x -> Type convert:x to: 0i32)
```

There is some convenience to doing the helpers directly as such. 

Spiral can do runtime union types, but unlike with the MLs, they are not the main purpose of the language. Pattern matching on arbitrary types with no run time cost is. This also comes at the cost of having to write custom type inference code such as `type (Type meta: l) |> dyn |> f`.

For the sake of completeness, here is what the above two programs compile to.

```fsharp
// List
type SpiralType0 =
    | SpiralType0_2
    | SpiralType0_1 of float * SpiralType0
// List
and SpiralType3 =
    | SpiralType3_2
    | SpiralType3_4 of int32 * SpiralType3
let rec method_0 ((var_1 : SpiralType0)) : SpiralType3 =
    match var_1 with
    | SpiralType0_2 ->
        SpiralType3_2
    | SpiralType0_1 (var_4, var_5) ->
        let ((var_6 : int32)) = int32 var_4
        let ((var_9 : SpiralType3)) = method_0 (var_5)
        SpiralType3_4 (var_6, var_9)
let ((var_1 : SpiralType0)) = SpiralType0_1 (1.000000, SpiralType0_1 (2.000000, SpiralType0_1 (3.000000, SpiralType0_2)))
let ((var_11 : SpiralType3)) = method_0 (var_1)
```

## The User Guide

It covers the internals of 0.09 and is completely obsolete now. I was really proud of Spiral when I wrote the user guide, but I feel that despite the language size growing in terms of lines of code, the actual implementation itself has been significantly simplified compared to back then. There is significantly less useless recursion (like in `destructure`) and I feel that my grip on memoization has significantly improved compared to a year ago. This should be reflected throughout the implementation.

## Unary operators

Unlike F#, Spiral had only one. The unary `-` was a pain to deal with. It required hard to reason about lookback and I finally decided to just kick it out. Unary operators are something that I've never used in my programming life anyway. The `neg` function from `Core` is now tagged to the unary negation.

There is an exception to not having unary operators and that would be the parsing of literals.

The signed 8-bit for example has a range `from: -128i8 to: 127i8`. If the parsing of unary negation was separate and the parser was restricted to only positive integers it would not be possible to parse `128i8` here. Hence negative literals are a special syntax case in the language that does lookback to see if it is preceded by a separator such as whitespace.

## Raw types in the `Core` library

```fsharp
inl int8 = type 0i8
inl int16 = type 0i16
...
inl float32 = type 0f32
```

The `Core` library has gone through significant changes apart from this, but in type annotations the literals are expected to be used now. The issue that cropped up now and then is that `int32` would get captured in lexical scope leading to it being manifested when returned from a join point. Having these raw types in the `Core` library just leads to their careless use and reduces the integrity of the language as a result.

```fsharp
inl f () = join
    dictionary (key: int32 value: string) () // Suddenly an error because the author forgot to box the raw types in the dictionary.
```

When the need to pass types directly arises, it is best to box them using layout types.

```fsharp
inl ty = 
    join
        stack {elem_type=type 1,2,3} // Is treated as a unit type and erased at compile time as the layout type has no term variables.
```

This will be a convention throughout the language starting from here. Connected to all of this, the type equality pattern `a : int32` can now parse literals.

## Most of the module patterns

In v0.09 the module grammar had a rich panoply of available patterns, most of which were used once or twice.

```fsharp
    inl to =
        match d with
        | {(to ^ near_to ^ down_to ^ near_down_to)=to} -> to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` is allowed."
```

Here is an example of the Xor pattern that is now out. Additionally there were also `|` and `&` patterns directly in modules. These are also out. Another pattern that is out is...

```fsharp
inl f {name {p with x y}} = name,(x,y)
```

This one can be rewritten as...

```fsharp
inl f {name p={x y}} = name,(x,y)
```

I want to remove meaningless duplicate functionality from the language.

In general, I went too wild with the module pattern in the previous version of the language.

```fsharp
inl f {a b c} = a+b+c
```

The way this was compiled in the previous version of the language, the evaluator would test `a` then `b` then `c` independently from one another. This lead to one of the documented scoping bugs that is sitting in the v0.09. This has now been fixed, and all the members of a record are now tested as a single case.

The pattern matching issue where the CSE rewriting was too aggressive at taking variables and unboxing them has also been fixed. CSE rewriting is now `Op * TypedData -> Typedata` function rather than the `TypedData -> Typedata` that it had been previously. It no longer rewrites one variable to another, but rewrites an operation to a variable instead. That one simple idea is all it took to attain a finer level of control over the rewriting. As a side benefit, that also means that it no longer needs to do recursive rewriting to converge. It is a win-win all around.

## `packed_stack` layout

This particular layout was intended for passing tuples in arrays across language boundaries. In the past two years, I've never used it apart from implementing it. The tuple of arrays tensors are just so easy to use in Spiral that there is no point to packed stack. Hence it is out.

## `:=`, `<-`

These two operators were used for reference and array assignment respectively. They were not particularly useful, so they are out in this version of the language. References and arrays in v0.1 are wrapped in objects. 

```fsharp
/// Creates a reference.
inl ref x = 
    inl x = !ReferenceCreate(x)
    [
    get = !GetReference(x)
    set: v = !SetReference(x,v)
    ]
```

Here is how the reference is implemented in v0.1. The array is similar to this. 

```
inl x = ref 0
x set: 5
x.get
```

For references, they can be used like so.

# Changes

## `dyn`

`dyn` now pushes types to the term level.

```fsharp
dyn (type 1)
```

This now gives an error.

```fsharp
An attempt to manifest a raw type has been made.
Got: type (int64)
```

In v0.09 `var` was used for this purpose, but in this version I want to discourage passing raw types. Preferably…

```fsharp
stack {elem_type=type 1}
```

Should be used for the task of passing around types.

```fsharp
stack type 1
```

It might be tempting to save on keystrokes as shown above by using `stack` directly on the raw type, but I'd discourage against it. It might be fine for a simple type such as the above, but when packing arbitrary types (such as for keys and values of a dictionary) those types themselves might be layout types. In which case, if those layout types are not `stack` then they will be changed so they are. This will lead to type errors.

## Tight application

```fsharp
f g.h
```

In v0.09 of Spiral this would have gotten parsed as...

```fsharp
f (g.h)
```

On the other hand...

```fsharp
f (g)(.h)
```

...would not. This is no longer the case. Now all expressions that are next to each other will get parsed with higher precedence than for ordinary application. I am not sure how useful this will be, but it should be something to keep in mind from here on out.

## Macros

I am pleased to announce that, thanks to objects and keyword arguments, the macros have been significantly streamlined in the new version.

```fsharp
Macro 
    type: ()
    global_method: "System.Console.WriteLine"
    args: "Hello, world!"
```

```fsharp
let () = System.Console.WriteLine("Hello, world!")
```

The above is the basic hello world using macros.

Here is a more elaborate example that uses the `StringBuilder`.

```fsharp
inl StringBuilder x = 
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

inl b = StringBuilder("Qwe", 128i32)
inl _ = b Append: 123
inl _ = b AppendLine: ()
inl _ = b Append: 123i16
inl _ = b AppendLine: "qwe"
inl _ = b.ToString
()
```

```fsharp
let ((var_1 : System.Text.StringBuilder)) = System.Text.StringBuilder("Qwe", 128)
let ((var_2 : System.Text.StringBuilder)) = var_1.Append(123L)
let ((var_3 : System.Text.StringBuilder)) = var_1.AppendLine()
let ((var_4 : System.Text.StringBuilder)) = var_1.Append(123s)
let ((var_5 : System.Text.StringBuilder)) = var_1.AppendLine("qwe")
let ((var_6 : string)) = var_1.ToString()
```

`Macro class: args:` instantiates a class, and `Macro type: class: method: args:` is used here to call a method.

I feel that the intention of the above code is self explanatory enough. Here is how a class with generic could be used.

```fsharp
inl Dictionary (key:value:) x = 
    Macro
        class: "System.Collections.Generic.Dictionary"
        types: key,value
        args: x
        methods:
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

inl b = Dictionary (key: "" value: 0) ()
b Add: "a", 5
inl _ = b Item: "a"
()
```

```fsharp
let () = () // unit stack layout type
let () = () // unit stack layout type
let ((var_1 : System.Collections.Generic.Dictionary<string, int64>)) = System.Collections.Generic.Dictionary<string, int64>()
let () = var_1.Add("a", 5L)
let ((var_2 : int64)) = var_1.Item("a")
```

In the development of this, I've found that keyword arguments are a significant aid. Unlike in F#, Spiral does not have global inference to guide development and missing an argument in functions with curried arguments, or mistaking the order with tuples, is a much more time consuming kind of bug to track down. Records are not quite the right abstraction for this sort of thing either.

The two basic ops, from which all the helper methods shown in the examples above are built, are these two:

```fsharp
    /// Creates a macro using the type.
    type: t args: = !Macro(args,t)
    /// Creates a macro as a type.
    extern: t args: = !MacroExtern(args,t)
```

Here is an example of the first one.

```fsharp
Macro
    type:
        text: "Qwe"
    args:
        literal: 1
        ,text: ", "
        ,literal: "2"
```

```fsharp
let ((var_1 : string)) = 1L, "2"
```

Note that the keywords get erased during code generation so the type ends up being `string` since `"Qwe"` is a `string`.

```fsharp
Macro
    extern:
        text: "Qwe"
    args:
        literal: 1
        ,text: ", "
        ,literal: "2"
```

```fsharp
let ((var_1 : Qwe)) = 1L, "2"
```

`extern` stands for external type. During codegen, the macro gets printed as a sequence of instructions comprising of either a tuple of keyword arguments, or one of `text:`, `literal:`, `type:` or `variable:` keyword arguments on the term side. On the type side, it is similar, but `variable:` is not allowed.

```fsharp
Macro
    extern:
        text: "Qwe"
        ,text: "<"
        ,literal: 1
        ,text: ", "
        ,type: "2"
        ,text: ">"
    args:
        literal: 1
        ,text: ", "
        ,literal: "2"
```

```fsharp
let ((var_1 : Qwe<1L, string>)) = 1L, "2"
```

Spiral will happily print the type of a macro, no matter how nonsensical it might be.

In Spiral, macros are used for interop and not abstraction. They are awkward, but they are a powerful facility for language interop.

# Bug fixes

Generally, all the primitive arithmetic operations in v0.09 do unsound optimizations in the presence of floats. That has been fixed. Furthermore the pattern issues as mention in the manual have been fixed.

# Library changes

Date: 2/24/2019

All the changes to the language will necessitate a full rewrite of all the libraries. I'll try to at least go through the standard library tests in the next week or so.

# Current Status

Date: 3/1/2019

Basic testing - done.

Having been put through a full week of testing the `v0.1` is far from battle ready, but it works well for the things I tried right now. Going by past experience I'd say that the language implementation should go through at least two months of intense use before I could proclaim it to be sound. Just one week is nowhere enough.

I am fairly certain that any bugs that are still left in the implementation won't be hard to fix for myself, but I could not say the same for the users. Nonetheless, it should serve well as a reference and whatever errors are left should be minor. Given the sheer amount of redesign that Spiral has undergone in February, my sense is that the implementation this time is remarkably good. Compared to the hardship of 2017, this was like a swim in a pool.

At this point rather than try to retrofit those old parser tests, it would be better to just kick them out and try Spiral on a real project.

As per plan, I will cease development of Spiral for a while in order to study CFR and workings of VMs. I had the insight that if I really want great interactive tooling, it is not enough to have a language - actually having a VM to provide such services is needed and .NET is really far short of my needs. As it was the most impressive in this area I've picked Pharo as my study target.

I am not sure when it will be, but `v0.11` of Spiral will have much more in the way of interactivity and will probably be fused to some larger language. `v0.1` is the preliminary step in breaking the command line addiction and I have a lot of conviction about the necessity of that.

Though I will be leaving, I doubt I will be doing everything in Pharo. Most likely I will try making CFR agents in Spiral as well and play with the two languages in tandem. I'll take that as an opportunity to get more of the libraries back online and do more thorough testing.
