(Work in progress)

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
- [Future plans](#future-plans)

<!-- /TOC -->

# Motivation

Date: 2/22/2019

Previously in development for over a year, in April 2018 the Spiral language came to maturity and I've had good nine months or so to experience what it is like to programming in a like to program in my a making of my own design. There is now a not insignificant amount of code written in Spiral itself, and my goal of making a ML library has been attained. The language has some of the best GPU programming capabilities out there and the tensor datatype is still a pride point for Spiral.

While the Spiral language itself is highly expressive and powerful enough to meet my performance requirements the previous version of Spiral is amateurishly implemented. Some things, in particularly the way I was filtering the free variables for the environment (which was an immutable map under the hood) was clearly crazy from a performance standpoint even to the me of a year ago. It was done on every function creation and to make things worse, the `inl` bindings were actually done in lambda calculus style rather than having explicit `let` constructs in the language.

This and various other issues were something that was well known to me for a long time now. In fact, I tried dealing with them then and failed due to not knowing how.

Perhaps due to the accumulation of experience the attempt this time was a success.

Not only is the environment handled sanely in the partial evaluator thanks to the new prepass, but added to the language are the Smalltalk inspired keyword arguments and inbuilt objects. In addition to that the language internals have been greatly simplified. v0.09 of Spiral is a good example of how a static language with partial evaluation should look. v0.1 of Spiral is a good example of how such a language should be implemented. Standing at 4.35k LOC without the libraries, it is a neat and powerful little package.

# Additions to the language

## Keyword pattern and arguments

```
inl add (left: a right: b) = a + b
add left: 1 right: 2
```

While studying [Pharo](https://pharo.org/), I've been struck with just how readable the code is even to a complete beginner to the language and had the idea that having them as a language construct would be good just for that. Under the hood, they keyword is represented by an integer so comparing them for equality is performant at compile time, unlike with type literals.

```
inl add q =
    match q with
    | left: a right: b -> a + b
inl x = 
    left: 1 
    right: 2
add x
```

Like tuples and records (previously called modules), the keywords can be used on a first class basis.

```
inl add left:right: = left + right
add 
    left: 1 
    right: 2
```

Similarly to records, the pattern's right sides can be omitted in which case they will default to the keyword's argument names.

```
inl add left:right: = left + right
inl left:right: = left:1 right:2
add 
    left:
    right:
```

Like for patterns, the keyword bodies can be left alone too. The above is equivalent to...

```
inl add left:right: = left + right
inl left:right: = left:1 right:2
add 
    left: left
    right: right
```

## Objects

Though all the functionality of objects at compile time can be gotten through functions + pattern matching in Spiral, there are some definite issues with that sort of arrangement.

```
inl f = function
    | .add a b -> a + b
    | .mult a b -> a * b
    
f .add 1 2
```

The above does exactly what one would expect and is similar to having an object that has method fields. The key difference from an object is rather than using a quick dictionary lookup, the partial evaluator has to walk the entire body of the function testing for a match in turn. And in v0.09 of Spiral `.add` is a type literal. The way this was compiled is that the partial evaluator would make an instance of the type literal, string and all, and then compare it to the the argument. Not a wise thing to do if the compilation is desired to be done in a timely fashion.

```
inl f = 
    [
    add = inl a b -> a + b
    mult = inl a b -> a * b
    ]
    
f .add 1 2
```

In v0.1 of Spiral the `.add` is a unary keyword, not a type literal. Apart from keywords having to be strings, the important difference is that under the hood the name of both keyword unary and keyword message arguments is represented by an int. Their actual bodies are represented by arrays. For unary keyword arguments those arrays are empty.

```
inl f = [
    add: a to: b = a+b
    add_tuple: a,b to: c,d = a+b+c+d
    ]
f (add: 1 to: 3) |> ignore
f (add_tuple: 1,2 to: 3,4)
```

Objects support arbitrary patterns. That having said, they are not as flexible in that regard as functions - the object methods must start with a keyword pattern.

```
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

```
inl f = [
    apply: a,b = a+b
    ]
f (1, 2)
```

One last thing worth noting is the special `apply:` keyword. If the argument passed to an object is not a keyword, then the evaluator checks for the presence of that method and passed it the argument if it exists.

Spiral's objects are there for performance at compile time. Hence Spiral's objects cannot be updated like records, nor do they support inheritance.

```
[a=1; b=2; c=;3]
```

```
[
    a=1
    b=2; c=;3
]
```

Like for records, the object's fields can be separated by semicolons.

One last thing.

```
1 + [name="Tensor"]
```

Objects that are named have their names printed on type errors. The names have to be unary keywords with nothing else in the body for this to work.

```
...
The two sides need to have the same numeric types.
Got: int64 and Tensor.
```

When I started work on Spiral in 2017 I was really upbeat about functional programming and thought of OO as nothing but a burden, but several months of experience programming in Spiral I can confidently state that objects are extremely useful. It is not possible to do without them and they definitely deserve their elevation to full language feature status.

## Explicit unboxing via the `#` pattern

Here is a showcase of the `#` pattern. 

```
inl option_int = .Some, (1,2,3) \/ .None

inl x = join Type (box: .None to: option_int)
match x with
| #(.Some, x) -> x 
| #(.None) -> 0,0,0
```

This compiles into...

```
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

Previously Spiral did its unboxing automatically on any non-trivial pattern. I did this with the aim of matching F# in appearance, but unfortunately that did not work too well. I've come to a realization that there are notable semantic differences between matching at compile time and runtime and that the two are not interchangeable. F# does all its matching at runtime so it is capable of optimizing for user experience, but if in Spiral one is using union types, then definitely the code will have to be written in a way that takes account of that.

I have a dichotomy in my mind about union types - on one hand I see statically typed languages that do not support them as simply not getting **it** where **it** means **abstraction**. There is simply not a reason for a statically typed language to not have pattern matching + union types.

But on other hand, Spiral's compile time features are so powerful that I've come to think of actually using union types as defeat. I had to use them in places in Spiral though. A thought growing in me is that if the task is so complex that their use is actually needed, then rather than writing an interpreter for the task maybe using an actual dynamic language would be a better choice.

## Record's `this`

```
inl f x = {x with 
    y = 
        match this with
        | () -> 0
        | y -> y+1
    }
dyn (f {}, f {y=5})
```

```
let ((var_1 : int64)) = 0L
let ((var_2 : int64)) = 6L
```

Record's `self` has been renamed to `this` and now can be matched on regardless of whether the field previously existed. In `v0.09` record's `self` would only be in the environment if the field previously was in the record.

Also to make the indentation rules more uniform between objects, keywords and records the indentation for parsing record expressions must be higher than the field.

```
{ 
    y = 
    1 // Syntax error
}
```

```
{ 
    y = 
     1 // Ok
}
```

# Removals from the language

## The direct `open`

```
open Array

map sqrt ar // Identical to `Array.map sqrt ar`
```

Previously `open` was used to export the contents of a module into the environment.

No longer is that possible. After some deliberation, I decided that the benefits of simplifying the prepass outweights having such a complex feature in the language. The issue is that opening a variable requires knowledge of what is in it and in Spiral that is impossible without doing partial evaluation up to that point. A lesser version of `open` that only accepts modules in the global namespace is possible, but would make it impossible to parallelize the parsing and the prepass in some future version of the Spiral language. 

```
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

```
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

```
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

Here is an example of how construct recursive union types. `Type` is an object in the `Core` library that passes the arguments to the inbuilt op. Here is the F# code this compiles to.

```
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

The generated code is quite concise and compared to last time has no needless intermediate structs allocated. In terms of code generation things have really come together. Compiling it like the above would always have been the most sensible thing to do, but various architectural constraints prevented such a thing.

```
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

On the F# side, the tuples are no longer structs, but F#'s inbuilt tuples. Though value types would be more efficient overall for tuples, I am prioritizing the readability of the code in this iteration of Spiral. Should the need arise, modifying the codegen so the tuples get generated as structs would be trivial anyway so I did not lose sleep over this decision.

Another new feature of type join points is the ability to embed metadata in the types directly. By metadata, most commonly that would be the generic type parameters.

```
inl rec List x = 
    Type 
        name: "List"
        meta: x
        join: inl _ -> .nil \/ cons: x, List x
```

Then the metadata can be retrieved using `Type meta:`. Here is an example of a map function.

```
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

Dealing with types in Spiral is definitely harder than in F# where there it is all done automatically. Spiral cannot even compare to the elegance of using inbuilt lists in ML styled languages. Here is a alternative way of doing the same thing as the above

```
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

Spiral can do runtime union types, but unlike with the MLs, they are not the main purpose of the language. Pattern matching on arbitrary types with no cost at compile time is. This also comes at the cost of having to write custom type inference code such as `type (Type meta: l) |> dyn |> f`.

For the sake of completeness, here is what the above two programs compile to.

```
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

```
inl int8 = type 0i8
inl int16 = type 0i16
...
inl float32 = type 0f32
```

The `Core` library has gone through significant changes apart from this, but in type annotations the literals are expected to be used now. The issue that cropped up now and then is that `int32` would get captured in lexical scope leading to it being manifested when returned from a join point. Having these raw types in the `Core` library just leads to their careless use and reduces the integrity of the language as a result.

```
inl f () = join
    dictionary (key: int32 value: string) () // Suddenly an error because the author forgot to box the raw types in the dictionary.
```

When the need to pass types directly arises it is best to box them using layout types.

```
inl ty = 
    join
        stack {elem_type=type 1,2,3} // Is treated as a unit type and erased at compile time as the layout type has no term variables.
```

This will be a convention throughout the language starting from here. Connected to all of this, the type equality pattern `a : int32` can now parse literals.

## Most of the module patterns

In v0.09 the module pattern had a rich panoply of available patterns, most of which were used once or twice.

```
    inl to =
        match d with
        | {(to ^ near_to ^ down_to ^ near_down_to)=to} -> to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` is allowed."
```

Here is an example of the Xor pattern that is now out. Additionally there were also `|` and `&` patterns directly in modules. These are also out. Another pattern that is out is...

```
inl f {name {p with x y}} = name,(x,y)
```

This one can be rewritten as...

```
inl f {name p={x y}} = name,(x,y)
```

I want to remove meaningless duplicate functionality from the language.

In general, I went too wild with the module pattern in the previous version of the language.

```
inl f {a b c} = a+b+c
```

The way this was compiled in the previous version of the language, the evaluator would test `a` then `b` then `c` independently from one another. This lead to one of the documented scoping bugs that is sitting in the v0.09. This has now been fixed, and all the members of a record now are tested as a single case.

The pattern matching issue where the CSE rewriting was too aggressive at taking variables and unboxing them has also been fixed. CSE rewriting is now `Op * TypedData -> Typedata` function rather than the `TypedData -> Typedata` that it had been previously. It no longer rewrites one variable to another, but rewrites an operation to a variable instead. That one simple idea is all it took to attain a finer level of control over the rewriting. As a side benefit, that also means that it no longer needs to do recursive rewriting to converge. It is a win-win all around.

## `packed_stack` layout

This particular layout was intended for passing tuples in arrays across language boundaries. In the past two years, I've never used it apart from implementing it. The tuple of arrays tensors are just so easy to use in Spiral that there is no point to packed stack. Hence it is out.

## `:=`, `<-`

These two operators were used for reference and array assignment respectively. They were not particularly useful so they are out in this version of the language. References and arrays in v0.1 are wrapped in objects. 

```
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

```
dyn (type 1)
```

This now gives an error.

```
An attempt to manifest a raw type has been made.
Got: type (int64)
```

In v0.09 `var` was used for this purpose, but in this version I want to discourage passage of raw types. Preferably...

```
stack {elem_type=type 1}
```

Should be used for the task of passing around types.

```
stack type 1
```

It might be tempting to save on keystrokes as shown above by using `stack` directly on the raw type, but I'd discourage against it. It might be fine for a simple type such as the above, but when packing arbitrary types (such as for keys and values of a dictionary) those types themselves might be layout types. In which case, if those layout types are not `stack` then they will be changed so they are. This will lead to type errors.

## Tight application

```
f g.h
```

In v0.09 of Spiral this would have gotten parsed as...

```
f (g.h)
```

On the other hand...

```
f (g)(.h)
```

...would not. This is no longer the case. Now all expressions that are next to each other will get parsed with higher precedence than for ordinary application. I am not sure how useful this will be, but it should be something to keep in mind from here on out.

## Macros

I am pleased to announce that thanks to objects and keyword arguments the macros have been significantly streamline in the new version.

```
Macro 
    type: ()
    method: "System.Console.WriteLine"
    args: "Hello, world!"
```

```
let () = System.Console.WriteLine("Hello, world!")
```

The above is the basic hello world using macros.

Here is a more elaborate example that uses the `StringBuilder`.

```
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

```
let ((var_1 : System.Text.StringBuilder)) = System.Text.StringBuilder("Qwe", 128)
let ((var_2 : System.Text.StringBuilder)) = var_1.Append(123L)
let ((var_3 : System.Text.StringBuilder)) = var_1.AppendLine()
let ((var_4 : System.Text.StringBuilder)) = var_1.Append(123s)
let ((var_5 : System.Text.StringBuilder)) = var_1.AppendLine("qwe")
let ((var_6 : string)) = var_1.ToString()
```

`Macro class: args:` instantiates a class, and `Macro type: class: method: args:` is used here to call a method.

I feel that the intention of the above code is self explanatory enough. Here is how a class with generic could be used.

```
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

```
let () = () // unit stack layout type
let () = () // unit stack layout type
let ((var_1 : System.Collections.Generic.Dictionary<string, int64>)) = System.Collections.Generic.Dictionary<string, int64>()
let () = var_1.Add("a", 5L)
let ((var_2 : int64)) = var_1.Item("a")
```

In the development of this, I've found that keyword arguments are a significant aid. Unlike in F#, Spiral does not have global inference to guide development and missing an argument in functions with curried arguments, or with tuples mistaking the order is a much more time consuming kind of bug to track down. Records are not quite the right abstraction for this sort of thing either.

The two basic ops from which all the helper methods show in the examples above are built from are these two:

```
    /// Creates a macro using the type.
    type: t args: = !Macro(args,t)
    /// Creates a macro as a type.
    extern: t args: = !MacroExtern(args,t)
```

Here is an example of the first one.

```
Macro
    type:
        text: "Qwe"
    args:
        literal: 1
        ,text: ", "
        ,literal: "2"
```

```
let ((var_1 : string)) = 1L, "2"
```

Note that the keywords get erased during code generation so the type ends up being `string` since `"Qwe"` is a `string`.

```
Macro
    extern:
        text: "Qwe"
    args:
        literal: 1
        ,text: ", "
        ,literal: "2"
```

```
let ((var_1 : Qwe)) = 1L, "2"
```

`extern` stands for external type. During codegen, the macro gets printed as a sequence of instructions comprising of either a tuple of keyword arguments, or one of `text:`, `literal:`, `type:` or `variable:` keyword arguments on the term side. On the type side, it is similar, but `variable:` is not allowed.

```
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

```
let ((var_1 : Qwe<1L, string>)) = 1L, "2"
```

Spiral will happily print the type of a macro no matter how nonsensical it might be.

In Spiral, macros are used for interop and not abstraction. They are awkward, but they have a powerful facility for language interop.

# Bug fixes

Generally, all the primitive arithmetic operations in v0.09 do unsound optimizations in the presence of floats. That has been fixed. Furthermore the patterns have been fixed.

# Library changes

(Work in progress)

Date: 2/24/2019

All the changes to the language will necessitate a full rewrite of all the libraries. I'll try to at least go through the standard library tests in the next week or so.

# Future plans

(Work in progress)

Date: 2/24/2019

Since April 2018 I've had a good whack at deep reinforcement learning. Despite all the highly publicized successes by DeepMind and OpenAI, I've found that to be mostly hype. It is a curious thing. Deep learning does seem to be capable of conquering enormously complicated games like Starcraft, but in terms of robustness I have found it to be far inferior to simple tabular methods on toy tasks. And literally nothing of the recent Deepmind research is of any use to me. Those victories have been made by tacking on complexity, not by resolving the fundamental issues with the current crop of RL algorithms.

At this point I've started looking for alternatives to backpropagation.

I've also had quite a bit of time to get familiar with actually programming in Spiral. In short, the language itself is great, but the type errors are so damn nasty. They just take so long to get through, about 10x more than they would in F#. Due to its high level nature, I've found that Spiral programs do work after they compile, but the effort to get to that point needs to be brought lower.

When I made the design for Spiral I praised it to high heaven. I was right that Spiral is more expressive than any extensionally typed language out there, and that its inlining capabilities give it unparalleled potential for performance and integration. But coming to an understanding of the limits of static typing made me realize the hubris of thinking that it might reach the expressiveness dynamically typed languages with enough programming cleverness.

And I could not even imagine how tedious dealing with type errors could get - now that I see that there is a definite benefit to extensional typing. During the current rewrite of Spiral I must have written code for over 3 weeks and gone through thousands of lines of code without running the program even once. No way would that style of programming be viable in a language like Spiral. Extensional typing might be both less expressive and performant than intensional one, but it has scaling advantages that I've under appreciated.

Putting all of this together, I think that Spiral after all is not the best thing to program with in isolation. It is small, fast and powerful, but needs to be used with care. It is a power tool.

The 9 months or so which I've tried to make deep RL work are not something I want to repeat - the effort needs to be a lot better next time. Every single attempt was the same - I'd study, implement, debug and always - always without fail I'd just watch the cost go down from the command line.

Looking forward into my future I've come to the conclusion that I do not want every single of my creations to be a command line application. I actually deeply appreciate graphical interfaces and the command line is hell for me. I wish Spiral had an IDE.

This is an old story by now. In 2016 I tried making a poker game. On the command line it was roughly 300-400 lines of code in total. Adding a GUI onto that made it 1500 which I thought was insane for a single window application. I remember one day thinking exactly that and poring through the code looking for what to cut and I could not find anything.

Nonetheless, interactivity should not have such a high price. Back then I was satisfied to make that my core value and leave it for the future me to deal with when all the pieces are in place. That time has nearly come.

I really regret that I did all my deep learning experiments from the command line. Watching the cost go down is like watching stock prices move - in some ways it is mesmerizing, but on the other hand it is foolish. Especially so with machine learning.

ML algorithms are not something that is understood at the moment. They cannot be reasoned through beyond the most superficial. They are essentially alien systems. Yet, for nine months I was trying to study them without ever really attempting to open them up. If that is not stupid then what is? Should I continue like this, then chance of victory will literally be 0%. They might be alien, but unlike stocks, they are right there in my computer!

In my hurry, I've made the mistake of rushing into a dark room and stumbling all over the furniture. I am just about ready to start looking for the light switch.

In January, I've seriously considered Python + PyTorch for the sake of breaking the command line dependency, but after looking into it I've realized that Python is not particularly interactive as a language. All the PyTorch examples that I've seen had their plotting windows frozen, and the Tkinter GUI example would hang the interpreter. Workarounds for that would require messing with callbacks, the most poisonous thing possible for development experience.

The single language that most meets the graphical interactivity criteria at this point would be [Pharo](https://pharo.org/) which is a Smalltalk dialect. In it is trivial to create and play around with windows and widgets in it. Its [interactive development](https://youtu.be/baxtyeFVn3w) experience is definitely in a league of its own.

Spiral is a pretty small language. I am thinking that it would be easier to make Pharo fast by connecting it with Spiral than it would be to make Python interactive. Spiral's compact design actually makes it an ideal fit for a library language. So this attempt should be made.

Since it took me 3.5 weeks to essentially redo the language starting from a base, I'd say that the full version in a different language would be 2-3 months of work. It would be quite doable to do this, though I have not yet decided that I want to do it in Pharo just yet. I think that writing an IDE for Spiral would be much easier in Pharo than in any other language, but I am anxious about trying to tackle the task of rewriting Spiral in a dynamic language without pattern matching.

Not that I have any have any experience in that language either. I just decided I want to do it.

After I finish the tests for the standard library which should take me another week or two, I just want to forget about Spiral for a bit. I've labored hard over the last month to make the new design operational and I want to take a break from the grind of it. I want to finish v0.1 of Spiral so that it serves as a reference to me and the others on this path, but I do not want to program in it for the reasons that I did previously. At the moment I just want my vision of Spiral to be brought to completion.

Since I might restart Spiral from scratch yet again, I won't bother redoing the `Learning`, `Cuda` nor the `Games` modules during this testing run.

Once I am done with v0.1, I am going to make a different attempt. I once made fun of the authors of Libratus for having to use a supercomputer to beat those poker pros, but last year they [delivered](https://arxiv.org/abs/1805.08195) and improved their [counterfactual regret](http://modelai.gettysburg.edu/2013/cfr/cfr.pdf) minization based algorithm to the point where it can be used on desktop machines. I respect this and will honor them by studying CFR and implementing it.

I have an image in my mind of how I want things to go. I will implement CFR in Pharo and have it work well. Then I will implement it in Spiral and speed it up by 30x. Then I will implement both it and the poker game on the GPU in Spiral and speed it up another 30x. At every point in this process, the game, Spiral, and other tools will be graphical and nothing will be done from the command line.

Then after that I will get back to machine learning and this time make the ML library not just fast, but the closest it can get to being a direct jack into the user's brain. Eventually, ML is going to get good and I will have my battle station from which to wage war from. I hope that in a few years I can elevate my programming skill up to a completely new level. 

Programmers improve by mastering new concepts, but that goes hand in hand with mastering new tools.

Improvement cannot happen without one or the other.