# Table of Contents

<!-- TOC -->

- [Table of Contents](#table-of-contents)
- [News](#news)
- [The Spiral Language](#the-spiral-language)
    - [Overview](#overview)
        - [Intro](#intro)
        - [Design Philosophy](#design-philosophy)
    - [Dependencies](#dependencies)
                - [For the compiler:](#for-the-compiler)
                - [For the Cuda using Spiral libraries:](#for-the-cuda-using-spiral-libraries)
    - [Tutorials: Introduction to Spiral](#tutorials-introduction-to-spiral)
        - [0: The way to use the language](#0-the-way-to-use-the-language)
        - [1: Inlineables, Methods and Join Points](#1-inlineables-methods-and-join-points)
            - [Recursion, Destructuring and Pattern Matching](#recursion-destructuring-and-pattern-matching)
                - [Intensional Recursion](#intensional-recursion)
                - [Term Casting of Functions](#term-casting-of-functions)
                - [`<function>` error message](#function-error-message)
        - [2: Modules, Macros and Interop](#2-modules-macros-and-interop)
            - [Modules](#modules)
            - [Macros](#macros)
                - [Solve Me](#solve-me)
                - [Simple Array Sum (macro version)](#simple-array-sum-macro-version)
            - [Spiral libraries](#spiral-libraries)
        - [3: Loops and Arrays](#3-loops-and-arrays)
            - [Loops](#loops)
            - [Arrays](#arrays)
        - [3: Union Types and Lists](#3-union-types-and-lists)
            - [Type Splitting and Generic Parameters](#type-splitting-and-generic-parameters)
            - [Warning on combining union types, partial active patterns and join points](#warning-on-combining-union-types-partial-active-patterns-and-join-points)
        - [4: Continuation Passing Style, Monadic Computation and Parsing](#4-continuation-passing-style-monadic-computation-and-parsing)
            - [Parsing Benchmark](#parsing-benchmark)
        - [5: Tensors and Structural Instrospection](#5-tensors-and-structural-instrospection)
            - [Under the Hood](#under-the-hood)
                - [Layout Polymorphism](#layout-polymorphism)
                - [Dimensionality Polymorphism](#dimensionality-polymorphism)
                    - [Design of the Tensor](#design-of-the-tensor)
                    - [The Tensor Facade](#the-tensor-facade)
            - [Closing Comments](#closing-comments)
        - [6: The Cuda Backend](#6-the-cuda-backend)
            - [Intro](#intro-1)
            - [How Cuda Kernels Are Compiled](#how-cuda-kernels-are-compiled)
            - [Tour Of The Standard Library Cuda Module](#tour-of-the-standard-library-cuda-module)
            - [Why Spiral Was Created](#why-spiral-was-created)
                - [How It Used To Be Done](#how-it-used-to-be-done)
        - [7: Object Orientation](#7-object-orientation)
            - [Motivation](#motivation)
            - [The Object](#the-object)
        - [8: GPU Programming Basics](#8-gpu-programming-basics)
            - [map](#map)
            - [map_redo_map](#map_redo_map)
                - [flatten](#flatten)
                - [Cuda Loops](#cuda-loops)
            - [d2_replicate_map](#d2_replicate_map)
                - [Example](#example)
            - [mapi_d2_redo_map](#mapi_d2_redo_map)
                - [Example](#example-1)
            - [mapi_d1_seq_broadcast](#mapi_d1_seq_broadcast)
                - [The Softmax Activation](#the-softmax-activation)
        - [9: Deep Learning Basics](#9-deep-learning-basics)
            - [Primitives](#primitives)
                - [map](#map-1)
                - [map_redo_map](#map_redo_map-1)
                - [d2_replicate_map](#d2_replicate_map-1)
            - [Optimizers](#optimizers)
            - [Operations](#operations)
            - [Layers](#layers)
                - [Multiplicative Integration RNN](#multiplicative-integration-rnn)
                - [Map + Layer Norm + Relu](#map--layer-norm--relu)
            - [Layer Combinators](#layer-combinators)
                - [A Note On Compilation Times](#a-note-on-compilation-times)
            - [Loops](#loops-1)
            - [Example - Feedforward Net On Mnist](#example---feedforward-net-on-mnist)
            - [Example - Recurrent Net on tiny_shakespeare](#example---recurrent-net-on-tiny_shakespeare)
        - [Known Bugs](#known-bugs)

<!-- /TOC -->

# News

03/2019

v0.1 is currently in development. Here is [the changelog](https://github.com/mrakgr/The-Spiral-Language/blob/v0.1/changelog_v0.1.md).

Going from 0.09 to 0.1 there have been significant changes to the language, so some of the things in the tutorial will be obsolete. Nonetheless, the language philosophy is the same as it was before so for the time being, the tutorial should still be useful.

---

01/2020

Work on v0.2 is beginning. This will be a complete redesign so when it comes this entire documentation will be obsolete. Nevertheless, the essence of Spiral that is here will remain in the uniferred segment. The big idea will be to jack the partial evaluator into the constraint solver of a Haskell 98' tier type system. This will give the language top down-typing capabilities and ease of use almost on par with Haskell 98', but the efficiency, power and expressiveness of regular Spiral.

# The Spiral Language

## Overview

### Intro

As the world inexorably hurls towards the black maw of tomorrow, the power to face it is needed.

Throughout the history of programming languages, the choice was between fast or expressive; the two traditions are crystallized by the C and the Lisp family of languages. There has been a lot of effort into this, but always as languages developed and moved forward they stepped away from the bare metal and in turn lost some of that core vitality that is needed for performance.

The culprit for this is the heap allocation by default dogma introduced by Lisp decades ago. It is a crutch for languages with weak type systems.

Abstraction by heap allocation is a dead end. It works moderately well on the current generation of computers where CPU is still the dominant driver of computation.

It cannot work for devices like GPUs and the rest coming down the line. Many of the most important computational devices of the future won't support heap allocation so an alternative is needed to draw out their full power. It is of absolute importance that a language for that task have excellent control over inlining. Inlining, therefore, must come as a guarantee in the language and be a part of the type system.

Inlining is a trade-off that expresses the exchange of memory for computation. It should be the default instead of heap allocating.

A language good enough at propagating information so as to be capable of expressing inlining guarantees is also powerful enough for expressing a lot of other things well - without any abstraction overhead.

1) First class types.
2) Structural introspection through pattern matching.
3) Interoperability between different languages (such as F# and Cuda.)
4) First class functions.
5) Tuples as heterogeneous lists.
6) First class records.
7) First class layouts of data structures.
8) First class keyword arguments.

Spiral is such a language.

Statically typed and with a lightweight, very powerful type system giving it expressiveness of dynamic languages and the speed of C, Spiral is the crystallization of staged functional programming. It boasts of having intensional polymorphism and first-class staging. It was made for the sake of making a deep learning library which was too difficult to do in F# itself for its author.

### Design Philosophy

Automatically doing type inference, inlining and other optimizations require restrictions and heuristics in order to ensure termination. Languages that make the choice of automating the important parts of their internals invariably hamstring their expressiveness. Even if they end up doing well on some low-level benchmarks, they perform poorly when high-level abstractions are required.

Spiral is different. The power of Spiral lies in its novel kind of language design, not compiler smartness. Spiral is a static language without any restrictions on either type inference or optimizations.

It introduces novel constructs such as inlineables and join points, exposes optimizations as polymorphism in its type system, and then ties them together and with the rest of the features in such a manner so as to allow programs to be written so they terminate.

The halting problem is the primary obstacle preventing the bridging of expressiveness and performance. Ultimately, C is a competing style more than it is a competing language. It is something other higher level languages regress to once they start worrying about performance.

In Spiral, inlining by hand will never be necessary.

In Spiral, the most abstract way of writing a program is also the optimal one from a performance standpoint.

Spiral exists to abstract away optimization.

## Dependencies

##### For the compiler:

FParsec

Visual Studio 2017 F# template (.NET desktop development)

##### For the Cuda using Spiral libraries:

ManagedCuda 8.0 + (CUBLAS,CURAND)

Cuda SDK 8.0 + 9.0 (8.0 for the libraries and 9.0 for the NVCC compiler)

The Cuda Unbound library

Visual C++ version 15.4 v14.11 toolset

## Tutorials: Introduction to Spiral

### 0: The way to use the language

The easiest way to do it right now would be to clone this repo. In the Testing project, look at `run.fs`. It has the latest example used for the tutorial. Select the `Testing` project as the starter one and point the output to the `output.fs` file in the `Temporary` project. No need to worry about getting it wrong - at worst an exception will be raised.

Modifying the Cuda configuration options in the `run.fs` file unless usage of libraries related to that is required.

### 1: Inlineables, Methods and Join Points

Spiral has a great many similarities to other languages of the ML family, most notably F# with whom it shares the most similarity and a great deal of syntax, but in terms of semantics, it is different at its core.

```
inl x = 2 // Define a 64-bit integer in Spiral.
```
```
let x = 2 // Define a 32-bit integer in F#.
```

Unlike in F#, statements and function definitions in Spiral are preceded by `inl` instead of `let` which is short for `inl`ineable.

```
let x = 2
()
```

If a program like the above was disassembled, `x` would compile down to a public method in F#. In Spiral, by contrast, there would be nothing.

```
module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""
```

It is not absolutely nothing though. If the program used Cuda kernels in it, they would be gathered at the top of the file inside the `cuda_kernels` variable. For interests of brevity, the unremarkable top part will be cut out during the tutorials.

```
inl x = dyn 2
```
```
let (var_0: int64) = 2L // Generated F# code.
```

The reason Spiral is generating nothing is that `2` as defined is a literal and gets tracked as such by the partial evaluator inside the environment. In order to have it appear in the generated code, it is necessary to cast it from the type to the term level using `dyn`amize function. From here on out, the literal will be bound to a variable and the binding `x` will track `var_0` instead.

Being able to do this is useful for a variety of reasons. For example, without it constructs such as runtime loops would be impossible to write in Spiral because the partial evaluator would diverge. Despite its static typing features, the language would essentially be constrained to being an interpreter for a pure dynamic functional language.

```
inl x = dyn 2
inl y = 3
(x + y) * (x + y)
```

```
let (var_0: int64) = 2L
let (var_1: int64) = (var_0 + 3L)
(var_1 * var_1)
```

To get a sense of how `dyn` works, here is a slightly more complex example. The evaluator does common subexpression elimination in the local scope and so it is smart enough to optimize the `x+y` into a single addition and a multiplication.

```
inl x = 2
inl y = 3
(x + y) * (x + y)
```

```
25L
```

Without `dyn`, all the arithmetic operations get evaluated at compile time. This is due to the simple fact that a variable added to a literal is a variable. In general, if an operation has a variable as one of its inputs, then its output will also be a variable. The evaluator term casts the literals when necessary. For an operation to be evaluated at compile time, the partial evaluator must have support for it internally.

`inl` can also be used to define functions.

```
inl add a b = a + b
add 1 2, add 3 4
```

```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
Tuple0(3L, 7L)
```

Tuples are used in Spiral much in the same way as in other functional languages. As per their name, `inl`ineables are always inlined. There are no heuristics at play here in the evaluator. Spiral's staged functions are tracked at the type level and both their exact body and environments are known at every point of compilation. This is an absolute guarantee and there is no point at which they can be automatically converted into heap allocated closures.

```
inl add a b = a + b
inl f = add 1
f 2, f 3
```

```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
Tuple0(3L, 4L)
```

Of course, they can be partially applied.

Besides being staged, Spiral's functions allow more powerful forms of polymorphism than F#'s.

```
inl mult a b = a * b
inl f g = g 1 2, g 3.0 4.0 // Would give a type error in F#.
f mult
```

```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
Tuple0(2L, 12.000000)
```

Haskell could manage something like that using typeclasses and higher ranked types, but it would be nowhere as simple. Having to declare new types and then putting in the necessary annotations into the function would be needed.

On the other hand, being able to do this makes type inference for Spiral undecidable.

```
inl f _ = 1 + "qwe" // Does not give a type error
()
```

Undecidability manifests in Spiral like so - the body of the function is not evaluated until it is applied. That means that type errors can lurk in functions that are unused.

That being said, Spiral is a statically typed language and any type errors for code on the execution path will get reported at compile time along with the trace for it.

```
inl f _ = 1 + "qwe" // Does not give a type error
inl _ = 1
inl _ = 2
inl _ = 3
f ()
```

```
Error trace on line: 3, column: 5 in file "example1".
inl _ = 1
    ^
Error trace on line: 4, column: 5 in file "example1".
inl _ = 2
    ^
Error trace on line: 5, column: 5 in file "example1".
inl _ = 3
    ^
Error trace on line: 6, column: 1 in file "example1".
f ()
^
Error trace on line: 2, column: 7 in file "example1".
inl f _ = 1 + "qwe" // Does not give a type error
      ^
Error trace on line: 51, column: 11 in file "Core".
inl (+) a b = !Add(a,b)
          ^
`is_numeric a && get_type a = get_type b` is false.
a=lit 1i64, b=lit qwe
```

Since methods are necessary to achieve code reuse, Spiral makes it possible to make use of them with the `met` keyword. It works much like `inl`.

```
inl mult a b = a * b
met f g = g 1 2, g 3.0 4.0
f mult
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0(): Tuple0 =
    Tuple0(2L, 12.000000)
method_0()
```

`mult` can also be defined using `met` and passed into the other function.

```
met mult a b = a * b
met f g = g 1 2, g 3.0 4.0
f mult
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0(): Tuple0 =
    let (var_0: int64) = method_1()
    let (var_1: float) = method_2()
    Tuple0(var_0, var_1)
and method_1(): int64 =
    2L
and method_2(): float =
    12.000000
method_0()
```

The result would not be as one might expect since the methods would get specialized to the literal arguments passed to them. Instead, it would be better to use `dyn` here. But rather than letting the caller `f` do the term casting operation, it would be better if the callee `mult` did it.

```
met mult (!dyn a) (!dyn b) = a * b
met f g = g 1 2, g 3.0 4.0
f mult
```

```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0(): Tuple0 =
    let (var_0: int64) = 1L
    let (var_1: int64) = 2L
    let (var_2: int64) = method_1((var_0: int64), (var_1: int64))
    let (var_3: float) = 3.000000
    let (var_4: float) = 4.000000
    let (var_5: float) = method_2((var_3: float), (var_4: float))
    Tuple0(var_2, var_5)
and method_1((var_0: int64), (var_1: int64)): int64 =
    (var_0 * var_1)
and method_2((var_0: float), (var_1: float)): float =
    (var_0 * var_1)
method_0()
```

`!` on the left (the pattern) side of the expression is the active pattern unary operator. It takes a function as its first argument, applies the input to it and rebinds the result to the second argument of the pattern (in this case `a` and `b` respectively) before the body is evaluated.

#### Recursion, Destructuring and Pattern Matching

Much like in F#, recursive functions can be defined using `rec`.

```
inl rec foldl f s = function
    | x :: xs -> foldl f (f s x) xs
    | () -> s

inl sum = foldl (+) 0

sum (1,2,3)
```
```
6L
```

In the ML family of languages, `::` is the list cons pattern. In Spiral it is the tuple cons pattern. Tuples are fully fledged heterogeneous lists in Spiral and can be treated as such.

```
inl a = 2,3
1 :: a
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
Tuple0(1L, 2L, 3L)
```

There are some interesting applications of this. 

```
inl rec foldl f s = function
    | x :: xs -> foldl f (f s x) xs
    | () -> s

met sum (!dyn l) = foldl (+) 0 l

sum (1,2,3), sum (1,2,3,4)
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0((var_0: int64), (var_1: int64), (var_2: int64)): int64 =
    let (var_3: int64) = (var_0 + var_1)
    (var_3 + var_2)
and method_1((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
    let (var_4: int64) = (var_0 + var_1)
    let (var_5: int64) = (var_4 + var_2)
    (var_5 + var_3)
let (var_0: int64) = 1L
let (var_1: int64) = 2L
let (var_2: int64) = 3L
let (var_3: int64) = method_0((var_0: int64), (var_1: int64), (var_2: int64))
let (var_4: int64) = 1L
let (var_5: int64) = 2L
let (var_6: int64) = 3L
let (var_7: int64) = 4L
let (var_8: int64) = method_1((var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64))
Tuple0(var_3, var_8)
```

While the language allows variant arguments, Spiral has the ability to specialize methods to their exact arguments and in combination with destructuring to implement variant arguments in a typesafe manner. 

```
inl rec foldl f s = function
    | x :: xs -> foldl f (f s x) xs
    | () -> s

met sum l = foldl (+) 0 l

sum (1,2,3,dyn 4), sum (2,2,3,dyn 4)
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0((var_0: int64)): int64 =
    (6L + var_0)
and method_1((var_0: int64)): int64 =
    (7L + var_0)
let (var_0: int64) = 4L
let (var_1: int64) = method_0((var_0: int64))
let (var_2: int64) = 4L
let (var_3: int64) = method_1((var_2: int64))
Tuple0(var_1, var_3)
```

By default, in Spiral tuples and modules are flattened and have their variables tracked individually. As can be seen in the generated code, when a tuple is passed into a function it is not the actual tuple that is being passed into it, but its arguments instead.

The specialization is exact to the structure, not just the types. If literals are being passed through the method call, the method will get specialized to them.

```
met f _ = 1,2,3
inl x = f ()
0
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
let rec method_0(): Tuple0 =
    Tuple0(1L, 2L, 3L)
let (var_0: Tuple0) = method_0()
let (var_1: int64) = var_0.mem_0
let (var_2: int64) = var_0.mem_1
let (var_3: int64) = var_0.mem_2
0L
```

Tuples themselves are only manifested in the generated code on join point and branch returns. They get destructured right away and tracked by their individual variables on binding and function application. Had the method return not been bound to `x`, it would not have been destructured. This is the desired behavior because otherwise destructuring might block tail call optimizations.

```
met f _ = 1
```
```
inl f _ = join 1
```

The above two code fragments are identical in Spiral. `met` is just syntax sugar for a function with a join point around its body.

Being able to do this is quite powerful as it allows more fine-grained control over inlining.

```
inl rec foldl f s = function
    | x :: xs -> foldl f (f s x) xs
    | () -> s

inl rec forall f = function
    | x :: xs -> f x && forall f xs
    | () -> true

inl sum l = 
    if forall lit_is l then foldl (+) 0 l
    else join foldl (+) 0 (dyn l)

sum (1,2,3,4), sum (1,2,3,dyn 4)
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0((var_0: int64)): int64 =
    let (var_1: int64) = 1L
    let (var_2: int64) = 2L
    let (var_3: int64) = 3L
    let (var_4: int64) = (var_1 + var_2)
    let (var_5: int64) = (var_4 + var_3)
    (var_5 + var_0)
let (var_0: int64) = 4L
let (var_1: int64) = method_0((var_0: int64))
Tuple0(10L, var_1)
```
The `lit_is` always resolves at compile time to either `true` or `false` just like other structure testing functions. In combination with `forall` that allows for testing of whether all the arguments of `l` are known at compile time. Then using a static if, the two branches amount to either summing them all at compile time, or term casting them and pushing the work to runtime.

This ensures that the sum function does not get specialized for every arbitrary literal passed into it.

```
if true then 1 else "qwe" // Not a type error.
```
```
if dyn true then 1 else "qwe" // A type error.
```

If statements in Spiral default to evaluating only one branch if their conditional is known at compile time meaning they are static by default. This is the bedrock of its intensional (structural) polymorphism. Under the hood, the patterns get compiled to static if statements which allow it to branch on structures and types.

`if` goes hand in hand with join point specialization.

```
inl default_of = function
    | _: int64 -> 0
    | _: float64 -> 0.0
    | _: string -> ""

default_of 1, default_of 1.0, default_of "qwe"
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    val mem_2: string
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
Tuple0(0L, 0.000000, "")
```
Unlike ML languages which use Hindley-Milner global type inference, Spiral does not infer as much as propagate. A consequence of that besides undecidability is that it knows the exact structure and type of everything at all times. When done on non-union types as done up to now, this sort of branching has no runtime overhead whatsoever and can be readily seen by looking into the generated code.

[`function`](https://stackoverflow.com/questions/1839016/f-explicit-match-vs-function-syntax) is just shorthand for matching on the immediate argument like in F#.

One other thing that is different from F# is that `int64`,`float64` and `string` on the right side of the `:` operators are not type annotations, but standard variables. The types in Spiral are first class much like everything else.

```
inl int64_type = type 1
inl float64_type = type 1.0
inl string_type = type "qwe"

inl default_of = function
    | _: int64_type -> 0
    | _: float64_type -> 0.0
    | _: string_type -> ""

default_of 1, default_of 1.0, default_of "qwe"
```

```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    val mem_2: string
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
Tuple0(0L, 0.000000, "")
```

As can be seen, the two generated code fragments are identical. `:` on the pattern side is the type equality operator. It can be invoked outside the pattern using the `eq_type` function.

`type` is a keyword and like `join` it enters a new scope.

The types themselves can do more than being passed around or matched on.

```
inl int64_type = type 1
inl float64_type = type 1.0
inl string_type = type "qwe"

inl default_of = function
    | _: int64_type -> 0
    | _: float64_type -> 0.0
    | _: string_type -> ""

inl a = type int64_type + 1
inl b = type float64_type + 1.0
inl c = type string_format "{0}, {1}" (string_type, "rty")

default_of a, default_of b, default_of c
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    val mem_2: string
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
Tuple0(0L, 0.000000, "")
```

The above is just to illustrate that inside the evaluator naked types are treated just like variables of the same type. If they should happen to slip on the term level that would cause an error.

```
int64 + 3
```
```
(naked_type (*int64*) + 3L)
```

These kinds of errors are easier to locate when they are shown in generated code. When they happen it is usually because of a missed argument to a curried function which causes its environment to spill into the generated code. This makes the usual error messages unhelpful, but looking at the error code gives a good indication of what is happening.

##### Intensional Recursion

Spiral, in general, does not need type annotations. The only exceptions are recursive functions when used in tandem with join points.

```
met rec fact (!dyn x) = if x > 1 then x * fact (x-1) else 1
fact 3
```
```
Process is terminated due to StackOverflowException.
```

The correct way to write the above would be.

```
met rec fact (!dyn x) = 
    if x > 1 then x * fact (x-1) else 1
    : int64 // or alternatively `: x`
fact 3
```
```
let rec method_0((var_0: int64)): int64 =
    let (var_1: bool) = (var_0 > 1L)
    if var_1 then
        let (var_2: int64) = (var_0 - 1L)
        let (var_3: int64) = method_0((var_2: int64))
        (var_0 * var_3)
    else
        1L
let (var_0: int64) = 3L
method_0((var_0: int64))
```

`:` has the lowest precedence of all Spiral's constructs so it will get applied before any of the statements. It does not necessarily have to be put directly into the function. As a reminder, on the pattern side `:` is not a type annotation, but a type equality test.

```
inl rec fact x =
    inl body x = if x > 1 then x * fact (x-1) else 1
    if lit_is x then body x
    else join (body x : int64)
fact 3, fact (dyn 3)
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0((var_0: int64)): int64 =
    let (var_1: bool) = (var_0 > 1L)
    if var_1 then
        let (var_2: int64) = (var_0 - 1L)
        let (var_3: int64) = method_0((var_2: int64))
        (var_0 * var_3)
    else
        1L
let (var_0: int64) = 3L
let (var_1: int64) = method_0((var_0: int64))
Tuple0(6L, var_1)
```

It takes some work, but it is not difficult to make functions stage polymorphic in Spiral.

Mutual recursion can also be done using join points.

```
// https://en.wikipedia.org/wiki/Hofstadter_sequence#Hofstadter_Female_and_Male_sequences
inl rec hof x = 
    inl male n = if n > 0 then n - hof.female (hof.male (n-1)) else 0
    inl female n = if n > 0 then n - hof.male (hof.female (n-1)) else 1
    match x with
    | .male (!dyn n) -> join male n : int64
    | .female (!dyn n) -> join female n : int64
hof.male 3
```
```
let rec method_0((var_0: int64)): int64 =
    let (var_1: bool) = (var_0 > 0L)
    if var_1 then
        let (var_2: int64) = (var_0 - 1L)
        let (var_3: int64) = method_0((var_2: int64))
        let (var_4: int64) = method_1((var_3: int64))
        (var_0 - var_4)
    else
        0L
and method_1((var_0: int64)): int64 =
    let (var_1: bool) = (var_0 > 0L)
    if var_1 then
        let (var_2: int64) = (var_0 - 1L)
        let (var_3: int64) = method_1((var_2: int64))
        let (var_4: int64) = method_0((var_3: int64))
        (var_0 - var_4)
    else
        1L
let (var_0: int64) = 3L
method_0((var_0: int64))
```

`.` here is the type literal lift operator. It has special syntax for strings and when used directly next to an expression, it binds more tightly than application similar to how F#'s method access works. It also has its own dedicated pattern as shown above.

```
inl f x = .(x)
inl a = f "asd"
inl b = .asd
eq_type a b
```
```
true
```

It works on any kind of literal, not just strings. Type literals can be converted to ordinary literals as well.

```
inl a = .1
inl b = .2
match a,b with
| .(a), .(b) -> a + b
```
```
3L
```

The difference between type literals and ordinary literals is that type literals will always be erased in generated code and it is impossible to push them at runtime by `dyn`ing them.

```
dyn (.a,"b",.false,true)
```
```
type Tuple0 =
    struct
    val mem_0: string
    val mem_1: bool
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: string) = "b"
let (var_1: bool) = true
Tuple0(var_0, var_1)
```

Using `print_static` can be used to inspect what the evaluator sees at compile time.

```
print_static (dyn (.a,"b",.false,true))
```
```
[type (type_lit (a)), var (string), type (type_lit (false)), var (bool)]
```

All the information in type literals is preserved at all times.

##### Term Casting of Functions

Spiral's functions, as flexible as they are, have the notable weakness of not being able to emulate recursive datatypes. For that, they need to be cast to the term level.

Consider a silly example like the following where the function is used as a counter.

```
met rec loop f (!dyn i) =
    if i < 10 then loop (inl _ -> f() + 1) (i + 1)
    else f()
    : int64
loop (inl _ -> 0) 0
```

This will never compile for the reason that `f` continually expands its environment.

At first it tries to specialize the function for just `inl _ -> 0` -> `int64` -> `int64`. The second specialization it tries is `[inl _ -> 0; inl _ -> f() + 1]` -> `int64` -> `int64`. During the third it is trying to specialize it for `[inl _ -> 0; inl _ -> f() + 1; inl _ -> f() + 1]` -> `int64` -> `int64`. The syntax used here is just for the sake of description. The problem is the it is impossible for the compiler to ever terminate on the above program. The only way to do it would be to cast the function to the term level and track it as a variable.

```
inl rec loop f i =
    inl f, i = term_cast f (), dyn i
    join 
        if i < 10 then loop (inl _ -> f() + 1) (i + 1) else f()
        : int64

loop (inl _ -> 0) 0
```
```
let rec method_0 (): int64 =
    0L
and method_1((var_0: (unit -> int64)), (var_1: int64)): int64 =
    let (var_2: bool) = (var_1 < 10L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_4: (unit -> int64)) = method_2((var_0: (unit -> int64)))
        method_1((var_4: (unit -> int64)), (var_3: int64))
    else
        var_0()
and method_2 ((var_0: (unit -> int64))) (): int64 =
    let (var_1: int64) = var_0()
    (var_1 + 1L)
let (var_0: (unit -> int64)) = method_0
let (var_1: int64) = 0L
method_1((var_0: (unit -> int64)), (var_1: int64))
```

`term_cast` works by taking a function as its first argument and a type as its second. It emulates a function call, gets the return type of the term function from the result of that, and set the input type to the first argument. In the generated code, it flattens the arguments a single tuple level.

Term level functions have their environments hidden and the only information available to the evaluator is its type.

On the Cuda side, term functions are also allowed with the restriction that their environments be empty. Meaning, they cannot capture variables in their lexical scope and can only be used as function pointers. Despite that restriction, they are useful for interop with Cuda libraries.

All the features of Spiral with the exception of heap allocated modules and closures can be used on the Cuda side.

##### `<function>` error message

Don't be fooled by the `<function>` during type errors. As was repeatedly stated, functions are not at all opaque - they are fully transparent to the evaluator. The reason why they get printed like that is simply that they have a tendency to suck everything into the environment. And except for very small examples, trying to print out the raw AST of its body is worthless even for debugging as it is so convoluted.

```
if dyn true then
    inl a,b = dyn (1,2)
    inl _ -> a + b
else
    inl a,b = dyn (3.0,4.0)
    inl _ -> a + b
```
```
if dyn true then
^
Types in branches of If do not match.
Got: <function> and <function>
```

If functions have the same bodies, they can be returned from branches of a dynamic if statement if they also have the same environments.

```
if dyn true then
    inl a,b = dyn (1,2)
    inl _ -> a + b
else
    inl a,b = dyn (3,4)
    inl _ -> a + b
```
```
type Env0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: bool) = true
if var_0 then
    let (var_1: int64) = 1L
    let (var_2: int64) = 2L
    (Env0(var_1, var_2))
else
    let (var_3: int64) = 3L
    let (var_4: int64) = 4L
    (Env0(var_3, var_4))
```

### 2: Modules, Macros and Interop

#### Modules

Owing to Spiral's relatively dynamic nature, modules work much like [records](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/records) do in F# albeit with greatly expanded functionality. Unlike in F#, they do not need to be predefined.

```
inl f m =
    open m
    q + w + e
inl m1 = {q=1; w=2; e=3}
inl m2 = {q=1.0; w=2.0; e=3.0}
f m1, f m2
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
Tuple0(6L, 6.000000)
```

As per their namesake, they can be opened and passed as arguments. They have their own dedicated patterns.

```
inl f {q w e} = q + w + e
inl q = 1
inl w = 2
inl e = 3
inl m = {q w e}
f m
```
```
6L
```

They allow functional lens updates. Note that in the generated code their fields are ordered by their names.

```
inl f d = {d.data with a = self + 10}
inl a = 1
inl b = 2
inl c = 3
inl m = {data={a b c}}
f m
```
```
type Env0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Env1 =
    struct
    val mem_0: Env0
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
(Env1((Env0(11L, 2L, 3L))))
```

Fields can be added to them and removed arbitrarily in an immutable fashion. Using `without` on a non-existing field will not do anything.

```
inl a = 1
inl b = 2
inl c = 3
inl m = {a b c}
{m with d = 4; without a}
```
```
type Env0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
(Env0(2L, 3L, 4L))
```

Like with tuples which are represented by immutable lists in Spiral, the modules in Spiral allow anything immutable maps might do. For example, they can be mapped over(`module_map`), folded(`module_foldl`,`module_fold`), and filtered(`module_filter`). Here is the fold example.

```
inl m = {a=1; b=2; c=3}
module_foldl (inl key state value -> state + value) 0 m
```
```
6L
```

They support more powerful patterns than F# allows on records like not(`!`) and xor(`^`).

```
inl f {!nope (a ^ b)=s} = s
// f {nope=()} // Would trigger a type error
inl m = {a=1; b=2}
// f m // Without trigger a type error
f {m without a}, f {m without b}
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
Tuple0(2L, 1L)
```

Last, but not least, Spiral's modules and functions support several kinds of layouts. By default, like tuples, they have a transparent structure whose variables are tracked on an individual basis. Here is the heap layout.

```
{a=1; b=2; c=3} |> dyn |> heap
```
```
type EnvHeap0 =
    {
    mem_0: int64
    mem_1: int64
    mem_2: int64
    }
let (var_0: int64) = 1L
let (var_1: int64) = 2L
let (var_2: int64) = 3L
({mem_0 = (var_0: int64); mem_1 = (var_1: int64); mem_2 = (var_2: int64)} : EnvHeap0)
```

Here are the 5 layouts in order: `indiv`,`heap`,`heapm`,`stack`,`packed_stack`.

```
{a=1; b=2; c=3} |> dyn |> heap |> heapm |> stack |> packed_stack
```
```
type EnvHeap0 =
    {
    mem_0: int64
    mem_1: int64
    mem_2: int64
    }
and EnvHeapMutable1 =
    {
    mutable mem_0: int64
    mutable mem_1: int64
    mutable mem_2: int64
    }
and EnvStack2 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
[<System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential,Pack=1)>]
and EnvPackedStack3 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
let (var_0: int64) = 1L
let (var_1: int64) = 2L
let (var_2: int64) = 3L
let (var_3: EnvHeap0) = ({mem_0 = (var_0: int64); mem_1 = (var_1: int64); mem_2 = (var_2: int64)} : EnvHeap0)
let (var_4: int64) = var_3.mem_0
let (var_5: int64) = var_3.mem_1
let (var_6: int64) = var_3.mem_2
let (var_7: EnvHeapMutable1) = ({mem_0 = (var_4: int64); mem_1 = (var_5: int64); mem_2 = (var_6: int64)} : EnvHeapMutable1)
let (var_8: int64) = var_7.mem_0
let (var_9: int64) = var_7.mem_1
let (var_10: int64) = var_7.mem_2
let (var_11: EnvStack2) = EnvStack2((var_8: int64), (var_9: int64), (var_10: int64))
let (var_12: int64) = var_11.mem_0
let (var_13: int64) = var_11.mem_1
let (var_14: int64) = var_11.mem_2
EnvPackedStack3((var_12: int64), (var_13: int64), (var_14: int64))
```

That is the tour of them, but it does not yet demonstrate their true power. The essence of modules converted to layout types is that they capture scope.

```
inl npc = 
    {
    health = dyn 0
    mana = dyn 0
    max_health = 40
    max_mana = 30
    }

inl ar = array_create (type stack npc) 3
ar 0 <- stack {npc with health = dyn 10; mana = dyn 20}
ar 1 <- stack {npc with health = dyn 20; mana = dyn 10}
//ar 2 <- {npc with health = dyn 10; mana = dyn 20} // Gives a type error as the module here is not a layout type.
//ar 2 <- stack {npc with health = dyn 10; mana = dyn 20; max_health = 50} // Gives a type error as max health is an incorrect literal.
()
```
```
type EnvStack0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: int64) = 0L
let (var_1: int64) = 0L
let (var_3: (EnvStack0 [])) = Array.zeroCreate<EnvStack0> (System.Convert.ToInt32(3L))
let (var_4: int64) = 10L
let (var_5: int64) = 20L
let (var_6: EnvStack0) = EnvStack0((var_4: int64), (var_5: int64))
var_3.[int32 0L] <- var_6
let (var_7: int64) = 20L
let (var_8: int64) = 10L
let (var_9: EnvStack0) = EnvStack0((var_7: int64), (var_8: int64))
var_3.[int32 1L] <- var_9
```

In layout types, literals and naked types become a part of the bigger type and are tracked at the type level. The individual variables are flattened and the intermediate structures are erased in the generated code, very similarly to how the arguments are handled at join points.

The `packed_stack` layout is just there in case it might be necessary to pass a tuple over to the Cuda side. In most cases though, it makes more sense to use the default (non)layout and pass them as individual arguments.

`heapm` layout is useful for mutably updating individual fields of a heap allocated module.

Layout types are there in order to allow finer control of the boxed representations of modules and functions. Without `heap` it would be impossible to heap allocate modules directly for example.

#### Macros
##### Solve Me

Modules are beautiful and elegant part of Spiral. Macros are definitely ugly, but they are the only way for Spiral to interop with other languages' libraries and as such are indispensable.

In Spiral they have the interesting property of also acting as types.

So far all the examples given in the tutorial were relatively unmotivated. Macros make it is possible to do IO among other things which allows the language to be applied to real-world problems.

As a very basic demonstration of them, let us start with this HackerRank problem.

```
// https://www.hackerrank.com/challenges/solve-me-first/problem
// The entire code is given, you can just review and submit!
open System

[<EntryPoint>]
let main argv = 
    let a = Console.ReadLine() |> int
    let b = Console.ReadLine() |> int
    printfn "%d" (a+b)
    0 // return an integer exit code
```

The above is the F# solution given directly. It just reads two ints from input, sums them and returns the sum. Doing it in Spiral without the IDE support or even direct language support for .NET constructs make it more complicated.

First the `System.Console` type needs to be defined.

```
//inl console = fs ((.text, "System.Console") :: ())
inl console = fs [text: "System.Console"]
print_static console
```
```
type (dotnet_type (System.Console))
```

What this has done is create the `[text: "System.Console"]` naked type. The type shown in the output is just how it gets printed - the actual type is determined by its body, namely `[text: "System.Console"]`. This is equivalent to `(.text, "System.Console") :: ()`

```
inl a = (.text, "System.Console") :: () |> fs
inl b = [text: "System.Console"] |> fs
eq_type a b
```
```
true
```

`[]` is just syntax sugar for named tuples. It has no extra functionality apart from what is provided by the standard constructs.

Since types are just macros it is possible to make nonsensical types.

```
print_static (fs [text: "1 + 2 + 3"])
```
```
type (dotnet_type (1 + 2 + 3))
```

Hence mistakes with macros will have to be responsibility of the downwards languages. But in the worst they will just lead to a type error.

Unlike in other languages where they are used for abstraction, macros in Spiral are only to be used for interop. They would not be good at all for that anyway given that at most they can print text.

```
inl console = fs [text: "System.Console"]
inl static_method static_type method_name args return_type = 
    macro.fs return_type [
        type: static_type
        text: "."
        text: method_name
        args: args
        ]
inl readline() = static_method console .ReadLine() string
inl a, b = readline(), readline()
()
```
```
let (var_0: string) = System.Console.ReadLine()
let (var_1: string) = System.Console.ReadLine()
```

The above program succinctly captures Spiral's approach to language interop. The facilities used for defining macro-based types and printing them are interwoven with one another. One extra ingredient macros evaluation require over macro type definitions is the return type.

What the `macro.fs` function is doing is printing the macro based on the second argument and returning a variable of the type in the first argument.

Now all the pieces are in place to finish the exercise.

```
inl console = fs [text: "System.Console"]
inl static_method static_type method_name args return_type = 
    macro.fs return_type [
        type: static_type
        text: "."
        text: method_name
        args: args
        ]
inl unop name arg return_type = 
    macro.fs return_type [
        text: name
        text: " "
        arg: arg
        ]
inl readline() = static_method console .ReadLine() string
inl writeline x = static_method console .WriteLine x string
inl int x = unop "int" x int32
inl a, b = readline(), readline()
writeline (int a + int b)
```
```
let (var_0: string) = System.Console.ReadLine()
let (var_1: string) = System.Console.ReadLine()
let (var_2: int32) = int var_0
let (var_3: int32) = int var_1
let (var_4: int32) = (var_2 + var_3)
System.Console.WriteLine(var_4)
```

##### Simple Array Sum (macro version)

This example is to demonstrate how macros can be used to interop with F# libraries which often take in functions as arguments.

The code fragments will be split into two. The first part loads the numbers into a Spiral array, splits them based on the whitespace char and convert them to ints.

```
//https://www.hackerrank.com/challenges/simple-array-sum/problem
inl console = fs [text: "System.Console"]
inl static_method static_type method_name args return_type = 
    macro.fs return_type [
        type: static_type
        text: "."
        text: method_name
        args: args
        ]

inl readline() = static_method console .ReadLine() string
inl writeline x = static_method console .WriteLine x string

inl array t = type (array_create t 0)
inl _, ar = readline(), macro.fs (array int32) [arg: readline(); text: ".Split [|' '|] |> Array.map int"]
```
```
let (var_0: string) = System.Console.ReadLine()
let (var_2: string) = System.Console.ReadLine()
let (var_3: (int32 [])) = var_2.Split [|' '|] |> Array.map int
```

The next part could also be done using macros, but is here to demonstrate an aspect of Spiral's intensional polymorphism.

```
// Converts a type level function to a term level function based on a type.
inl rec closure_of f tys = 
    match tys with
    | x => xs -> term_cast (inl x -> closure_of (f x) xs) x
    | x: f -> f
    | _ -> error_type "The tail of the closure does not correspond to the one being casted to."

inl add a b = a + b
inl add_closure = closure_of add (int32 => int32 => int32)

macro.fs int32 [text: "Array.fold "; arg: add_closure; text: " 0 "; arg: ar]
|> writeline
```
```
let (var_5: (int32 -> (int32 -> int32))) = method_0
let (var_6: int32) = Array.fold var_5 0 var_3
System.Console.WriteLine(var_6)
```

`closure_of` is an expanded version of `term_cast` that instead of converting by applying using the input argument converts a (staged) type level function to a term level using a target type thereby unstaging it. Term level functions have their own dedicated pattern for destructuring their types.

Naked types for them can be constructed with the `=>` operator. The `error_type` raises a type error with the specified message whenever it is evaluated.

What the `closure_of` function does can be better understood by rewriting it to a specific instance with two arguments.

```
inl closure_of_2 f (a' => b' => c') = 
    term_cast (inl a -> term_cast (inl b -> f a b : c') b') a'
closure_of_2 (+) (int32 => int32 => int32)
```
```
let rec method_0 ((var_0: int32)): (int32 -> int32) =
    method_1((var_0: int32))
and method_1 ((var_1: int32)) ((var_0: int32)): int32 =
    (var_1 + var_0)
method_0
```
The original version is just a more generic version of `closure_of_2` that loops over the arguments while both accumulating the results of the application of the closure and term casting it.

That is roughly it with regards to interop. Spiral of course does have its own libraries.

`closure_of` and other macro related functions can be found in the `Extern` module.

#### Spiral libraries

```
let example1 = 
    "example1",[array;console],"Module description.",
    """
open Console
inl _, b = readline(), macro.fs (array int32) [arg: readline(); text: ".Split [|' '|] |> Array.map int"]
Array.foldl (+) (dyn 0i32) b |> writeline
    """
```
The way Spiral is currently meant to be used is as a scripting language inside F#. The module argument is the list in the middle and the `array` and `console` are the modules of the same name respectively.
```
inl Array = ...
inl Console = ...
open Console
inl _, b = readline(), macro.fs (array int32) [arg: readline(); text: ".Split [|' '|] |> Array.map int"]
Array.foldl (+) (dyn 0i32) b |> writeline
```
The above is roughly how the program would be unfolded after parsing, but before typing and partial evaluation. Modules are unfolded in a flattened manner in the sequence they are input. Duplicate modules are ignored.

Much like F#, Spiral imposes a top down ordering of the program and modules cannot refer to each other recursively. If that functionality is required, it can be achieved using join points, but in general it should not be necessary.

This kind of constrained architecture cuts down on circular referencing and encourages purposeful laying out of programs.

Spiral libraries are (to be) covered in depth in the user guide and the reference.

### 3: Loops and Arrays

#### Loops

Most languages make it trivial to write loops and the user does not have to worry about them diverging except at runtime.

Spiral's staging abilities introduce new complexities into the mix. In Spiral, for every loop one writes, it is necessary to keep in mind whether it is intended to run at compile or at runtime.

Making functions stage polymorphic takes even more effort. Furthermore for recursive runtime functions it is easy to forget to put in the type annotation and to dynamize the counter.

For that reason, the bog standard `for` and `while` loops exist as a part of the `Loops` module in Spiral.

This chapter will be on building up the basic loop and then using it to implement the array library functions from first principles.

At this point, apart from union types and the Cuda backend, all the main language features have been introduced albeit shallowly.

This makes it possible to demonstrate how the architecture of a Spiral program differs from those in other languages.

```
let example = 
    "example",[console],"Module description.",
    """
open Console
met rec for {d with from=(!dyn from) to by body} =
    if from <= to then body from; for {d with from=from+by}
    else ()
    : ()

for {from=0; to=5; by=1; body=inl i ->
    string_format "The loop is on iteration {0}" i |> writeline
    }
    """
```
```
let rec method_0((var_0: int64)): unit =
    let (var_1: bool) = (var_0 <= 5L)
    if var_1 then
        let (var_2: string) = System.String.Format("The loop is on iteration {0}",var_0)
        let (var_3: string) = System.String.Format("{0}",var_2)
        System.Console.WriteLine(var_3)
        let (var_4: int64) = (var_0 + 1L)
        method_1((var_4: int64))
    else
        ()
and method_1((var_0: int64)): unit =
    let (var_1: bool) = (var_0 <= 5L)
    if var_1 then
        let (var_2: string) = System.String.Format("The loop is on iteration {0}",var_0)
        let (var_3: string) = System.String.Format("{0}",var_2)
        System.Console.WriteLine(var_3)
        let (var_4: int64) = (var_0 + 1L)
        method_1((var_4: int64))
    else
        ()
let (var_0: int64) = 0L
method_0((var_0: int64))
```
Somewhat inadvertently, the first example become a good lesson in why loops would be desirable as a part of the library. The first example was careful to `dyn` the counter and did not forget the annotation, but for some reason the loop got specialized to two functions one which only got called once.

It is not a compiler bug.

```
met rec for {d with from=(!dyn from) to by body} =
    if from <= to then body from; for {d with from=from+by}
```

The way join points work is that they specialize the call by their arguments. By rewriting the fragment highlighted above to an equivalent form it will be easy to demonstrate what is happening.

```
inl rec for d =
    inl from = dyn d.from
    inl {to by body} = d
    join
        if from <= to then body from; for {d with from=from+by}
        else ()
        : ()
```

What is going on is that `d` - the old one with the `from` field still as literal is getting passed through the join point and causes the redundant specialization to happen.

Here is the way to write the `for` function correctly.

Out of all the mistakes to make in Spiral, accidentally passing old state through the join point is the easiest one to make. With missed return type annotations and such the compiler will diverge and warn the user that way, but but this one has a way of preying on laziness.

In fact, this kind of error can happen in any language that supports records with mutable updates, not just Spiral. Spiral in particular just makes it obvious by looking at the argument count in the generated code.

```
met rec for {from=(!dyn from) to by body} =
    if from <= to then body from; for {from=from+by; to by body}
    else ()
    : ()
```
```
let rec method_0((var_0: int64)): unit =
    let (var_1: bool) = (var_0 <= 5L)
    if var_1 then
        let (var_2: string) = System.String.Format("The loop is on iteration {0}",var_0)
        let (var_3: string) = System.String.Format("{0}",var_2)
        System.Console.WriteLine(var_3)
        let (var_4: int64) = (var_0 + 1L)
        method_0((var_4: int64))
    else
        ()
let (var_0: int64) = 0L
method_0((var_0: int64))
```

The above output is the ideal for this kind of loop. Only the `var_0` varies, the other literals all get passed through the boundary and specialized along with the body.

This is kind of specialization important to do with Cuda kernels as using too many variables in place of literals can cause register spillage into global memory and cause drastic degradations of performance. Spiral makes it easy to keep such data static and propagate it through the program.

In addition, Spiral makes it trivial to this kind of specialization even across language boundaries. Partial evaluation is commonly refereed to as specialization. Staging makes it user directed. And being able to use staging constructs through the the type system as the basis of abstraction rather than being restricted to a second class macro inspired system is what makes Spiral's staging first class. That is a desirable trait as it increases uniformity of the language and with it, its power. It also simplifies its implementation greatly, so it is a good design principle to follow at all times.

More concretely, one of the main motivations for writing Spiral for its author is avoiding having to write unending litanies of wrappers for simple Cuda kernels.

Moving on, here is the static version of the loop.

```
inl rec for {from to by body} =
    if from <= to then body from; for {from=from+by; to by body}
    else ()

for {from=0; to=5; by=1; body=inl i ->
    string_format "The loop is on iteration {0}" i |> writeline
    }
```
```
System.Console.WriteLine("The loop is on iteration 0")
System.Console.WriteLine("The loop is on iteration 1")
System.Console.WriteLine("The loop is on iteration 2")
System.Console.WriteLine("The loop is on iteration 3")
System.Console.WriteLine("The loop is on iteration 4")
System.Console.WriteLine("The loop is on iteration 5")
```

Now what remains is to make the function stage polymorphic.

```
let example = 
    "example",[tuple;console],"Module description.",
    """
open Console
inl rec for {from to by body} =
    inl body from = 
        if from <= to then body from; for {from=from+by; to by body}
        else ()
    if Tuple.forall lit_is (from,to,by) then body from
    else 
        inl from = dyn from
        join body from : ()

for {from=0; to=5; by=1; body=inl i ->
    string_format "The loop is on iteration {0}" i |> writeline
    }

for {from=dyn 0; to=5; by=1; body=inl i ->
    string_format "The loop is on iteration {0}" i |> writeline
    }
    """
```
```
let rec method_0((var_0: int64)): unit =
    let (var_1: bool) = (var_0 <= 5L)
    if var_1 then
        let (var_2: string) = System.String.Format("The loop is on iteration {0}",var_0)
        let (var_3: string) = System.String.Format("{0}",var_2)
        System.Console.WriteLine(var_3)
        let (var_4: int64) = (var_0 + 1L)
        method_0((var_4: int64))
    else
        ()
System.Console.WriteLine("The loop is on iteration 0")
System.Console.WriteLine("The loop is on iteration 1")
System.Console.WriteLine("The loop is on iteration 2")
System.Console.WriteLine("The loop is on iteration 3")
System.Console.WriteLine("The loop is on iteration 4")
System.Console.WriteLine("The loop is on iteration 5")
let (var_0: int64) = 0L
method_0((var_0: int64))
```

The above loop can further improved in terms of functionality. Notice that its body has a type `unit` which is represented by an empty tuple in Spiral. That is a throwback to C that has no place in modern language such as Spiral.

```
open Console
inl rec for {from to by state body} =
    inl body from = 
        if from <= to then for {to by body from=from+by; state=body {state i=from}}
        else state
    if Tuple.forall lit_is (from,to,by) then body from
    else 
        inl from = dyn from
        join body from : state

inl power a to = for {from=2; to by=1; state=a; body=inl {state} -> state * a}

power 2 3
```
```
8L
```

The above works, but various criticisms of the program could be made. For one, is it really necessary to give `by` every time? Vast majority of loops will in fact have it as `1` so if it is not given it makes sense to use that default instead of giving a type error.

Speaking of defaults, a decent guess would be that most loops are not intended to be unrolled and that a user is more likely to just forget to `dyn` the `from` field by accident.

```
open Console
inl rec for {d with to state body} =
    inl body {from by} = 
        if from <= to then for {to by body from=from+by; state=body {state i=from}}
        else state

    inl from =
        match d with
        | {from} -> dyn from
        | {static_from} -> static_from

    inl by =
        match d with
        | {by} -> by
        | _ -> 1

    if Tuple.forall lit_is (from,to,by) then body {from}
    else 
        inl from = dyn from
        join body {from by} : state

inl power a to = for {from=2; to state=a; body=inl {state} -> state * a}

power 2 3
```
```
let rec method_0((var_0: int64)): int64 =
    let (var_1: bool) = (var_0 <= 3L)
    if var_1 then
        let (var_2: int64) = (var_0 + 1L)
        method_1((var_2: int64))
    else
        2L
and method_1((var_0: int64)): int64 =
    let (var_1: bool) = (var_0 <= 3L)
    if var_1 then
        let (var_2: int64) = (var_0 + 1L)
        method_2((var_2: int64))
    else
        4L
and method_2((var_0: int64)): int64 =
    let (var_1: bool) = (var_0 <= 3L)
    if var_1 then
        let (var_2: int64) = (var_0 + 1L)
        method_3((var_2: int64))
    else
        8L
// ...and so on up to method_63
```

Not quite as planned. An error made now is that the state gets specialized for every different power of 2.

With a single added `dyn` that can be fixed.

```
inl power a to = for {from=2; to state=dyn a; body=inl {state} -> state * a}
```
```
let rec method_0((var_0: int64), (var_1: int64)): int64 =
    let (var_2: bool) = (var_1 <= 3L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_4: int64) = (var_0 * 2L)
        method_0((var_4: int64), (var_3: int64))
    else
        var_0
let (var_0: int64) = 2L
let (var_1: int64) = 2L
method_0((var_0: int64), (var_1: int64))
```

As a matter of convention, Spiral library functions that take in `state` never `dyn` it directly. That responsibility should fall onto the user. 

As an example of the reason for that, the state might be an option type so it might be better to specialize it for both of its states without instantiating it directly. Or it might be a tuple with some fields which would be desirable to remain as literals.

`for` is intended to be used as a primitive and so requires some flexibility; it would not do to block functionality.

Looking over the function now it seems fine, but it is a bit uncomfortable how from has to start from `2`. It is not like the loop has to use the `<=` operator for comparison in the conditional. In a lot of cases `<` make a lot more sense.

Furthermore, an user might want to iterate downwards. That can be accommodated.

```
open Console
inl rec for {d with state body} =
    inl check =
        match d with
        | {near_to} from -> from < near_to 
        | {to} from -> from <= to
        | {down_to} from -> from >= down_to
        | {near_down_to} from -> from > near_down_to

    inl from =
        match d with
        | {from} -> dyn from
        | {static_from} -> static_from

    inl {(to ^ near_to ^ down_to ^ near_down_to)=to} = d

    inl by =
        match d with
        | {by} -> by
        | _ -> 1

    inl rec loop {from state} =
        inl body {from} = 
            if check from then loop {from=from+by; state=body {state i=from}}
            else state

        if Tuple.forall lit_is (from,to,by) then body {from}
        else 
            inl from = dyn from
            join body {from} : state

    loop {from state}

inl power a near_to = for {from=1; near_to state=dyn a; body=inl {state} -> state * a}

power 2 3
```
```
let rec method_0((var_0: int64), (var_1: int64)): int64 =
    let (var_2: bool) = (var_1 < 3L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_4: int64) = (var_0 * 2L)
        method_0((var_4: int64), (var_3: int64))
    else
        var_0
let (var_0: int64) = 2L
let (var_1: int64) = 1L
method_0((var_0: int64), (var_1: int64))
```

The module member queries are all done statically and so maximum polymorphism is attained. The above program also demonstrates why lexical scope is so great.

The above is starting to near the functionality of the `for` function in the actual library. To make it more professional, rather than returning a pattern miss error on when a field is missed, it would be better to tell the user what the problem is.

```
open Console
inl for {d with state body} =
    inl check =
        match d with
        | {near_to} from -> from < near_to 
        | {to} from -> from <= to
        | {down_to} from -> from >= down_to
        | {near_down_to} from -> from > near_down_to
        | _ -> error_type "One of `to`,`near_to`,`down_to`,`near_down_to` needs be present."


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
        | _ -> 1

    inl rec loop {from state} =
        inl body {from} = 
            if check from then loop {from=from+by; state=body {state i=from}}
            else state

        if Tuple.forall lit_is (from,to,by) then body {from}
        else 
            inl from = dyn from
            join body {from} : state

    loop {from state}

inl power a near_to = for {static_from=1; near_to state=a; body=inl {state} -> state * a}

power 2 3
```
```
8L
```

The above design is in fact superior to what is currently in the standard library. A lot of features of the language were developed along with the library and some parts of it did not keep up. The author also got to fancy with the design of it. At the time that was useful for pushing the language, but not so much from a design perspective.

Another issue with the standard library as it stands is that in fact its author did not know how to program in the language he was making and had to learn it as he going along.

```
    inl from =
        match d with
        | {from=(!dyn from) ^ static_from=from} -> from
        | _ -> error_type "Only one of `from` and `static_from` field to loop needs to be present."
```

This part here is highlighted in order to show the xor (`^`) pattern might be used in tandem with active patterns.

All the features in the making of the loop so far have been covered in the previous chapters and now it can be seen how they come together.

It is not done yet.

In order to attain the full functionality of C style loops, Spiral's loops also need the ability to break out. Strictly speaking, this cannot be done in a functional language and having `return` would make even less sense in Spiral than it does in ML variants, but the same functionality can be achieved instead by writing the loop body and calling the continuation for the next iteration in tail position.

As motivating example, imagine trying to iterate over nested arrays trying to find a specific item before breaking out. With the loop as was written above, there is no way to stop before reaching the end.

To start things off, first the nested arrays need to be created.

```
open Console
inl for {d with body} =
    inl state = 
        match d with
        | {state} -> state
        | _ -> ()
/// ...
inl array_init near_to f =
    assert (near_to >= 0) "The input to init needs to be greater or equal to 0."
    // Somewhat of an ugly practice in order to infer the type in a language that doesn't support inference. 
    // For large functions, it is recommended to put them in a join point otherwise compile times could 
    // become exponential if the function contains branches.
    // For a simple map for an array like here, it does not matter.
    inl typ = type (f 0) 
    inl ar = array_create typ near_to
    for {from=0; near_to; body=inl {i} -> ar i <- f i}
    ar

inl rec zeroes = function
    | x :: x' -> array_init x (inl _ -> zeroes x')
    | () -> ""

inl ar = zeroes (4,4,4,4)
ar 0 0 0 2 <- "princess"
```
```
let rec method_3((var_0: ((((string []) []) []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_8: (((string []) []) [])) = Array.zeroCreate<((string []) [])> (System.Convert.ToInt32(4L))
        let (var_9: int64) = 0L
        method_2((var_8: (((string []) []) [])), (var_9: int64))
        var_0.[int32 var_1] <- var_8
        method_3((var_0: ((((string []) []) []) [])), (var_3: int64))
    else
        ()
and method_2((var_0: (((string []) []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_6: ((string []) [])) = Array.zeroCreate<(string [])> (System.Convert.ToInt32(4L))
        let (var_7: int64) = 0L
        method_1((var_6: ((string []) [])), (var_7: int64))
        var_0.[int32 var_1] <- var_6
        method_2((var_0: (((string []) []) [])), (var_3: int64))
    else
        ()
and method_1((var_0: ((string []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_4: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(4L))
        let (var_5: int64) = 0L
        method_0((var_4: (string [])), (var_5: int64))
        var_0.[int32 var_1] <- var_4
        method_1((var_0: ((string []) [])), (var_3: int64))
    else
        ()
and method_0((var_0: (string [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        var_0.[int32 var_1] <- ""
        method_0((var_0: (string [])), (var_3: int64))
    else
        ()
let (var_6: ((((string []) []) []) [])) = Array.zeroCreate<(((string []) []) [])> (System.Convert.ToInt32(4L))
let (var_7: int64) = 0L
method_3((var_6: ((((string []) []) []) [])), (var_7: int64))
let (var_8: (((string []) []) [])) = var_6.[int32 0L]
let (var_9: ((string []) [])) = var_8.[int32 0L]
let (var_10: (string [])) = var_9.[int32 0L]
var_10.[int32 2L] <- "princess"
```

First off, the case for `state` that was forgotten is added at the top of the `for` function. As the big comment states inferring the type returned by `f` involves evaluating it twice which might not be a good idea depending on what it is.

The `Lazy` module's only function `lazy` for example puts a join point before evaluating the function because it might otherwise repeat long evaluations and those long evaluation in combination with branching (such as when nesting lazy values) might make compilation time take exponential time.

The `assert` function if its conditional can be statically determined and is true gives a type error at compile time instead of triggering at runtime. Spiral has support for throwing exceptions, but not catching or cleaning up after them, so they are intended to be used only for unrecoverable errors.

As the example shows, nesting loops is straightforward in Spiral. It is a decent bit more elegant than doing it with macros which are the only choice in languages with weaker type systems. In Spiral, type inference and partial evaluation are one.

Its type system is extremely powerful, and yet it does not have parametric polymorphism. Adding parametric polymorphism would significantly increase the complexity of both the language and its implementation, would not make the language any more expressive and would make it a lot harder to integrate the partial evaluator with the type system. This would make the language quite a bit slower.

It is interesting to consider the implication of this - in Lisp languages, its raw AST flavored syntax is there for the reason of supporting its macro meta-programming feature. Maybe a really powerful type system does require the absence of parametricity?

In light of what Spiral can do, it might be worth considering whether the programming language community at large collectively missed a whole evolutionary branch of languages with static typing, but without parametric polymorphism.

If that is not convincing yet, maybe it will be after the tutorials are through.

Here is how to write a breakable version of the `for` function in to take advantage of the continuation passing style.

```
inl for' {d with body} =
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
        | _ -> 1

    inl rec loop {from state} =
        inl body {from} = 
            if check from then 
                inl next state = loop {state from=from+by}
                body {next state i=from}
            else finally state

        if Tuple.forall lit_is (from,to,by) then body {from}
        else 
            inl from = dyn from
            join body {from} : finally state

    loop {from state}
```

There is a significant amount of duplication now that will need to be eliminated. The highlights are the addition of the `finally` field and the parts inside `loop`.

```
            if check from then 
                inl next state = loop {state from=from+by}
                body {next state i=from}
            else finally state
```
Instead of the loop calling itself, it instead passes a function to the body and lets it do it instead.

The `finally` field is useful for resuming the outer loop. It can also be used to set the state to `unit`, which would allow the loop to change states without having to resort to union types.

First a utility function for reversing a tuple is needed. This is standard fare for functional programmers and closely mirrors how one would reverse a list in ML styled languages.

```
// Reverses a tuple
inl tuple_rev = 
    inl rec loop state = function
        | x :: xs -> loop (x :: state) xs
        | () -> state
    loop ()
```

Here is how to apply the breakable for loop function. The goal is to find the coordinates of "princess". The method is generalized to an arbitrary of number of nested arrays.

```
// Correct version
inl rec find_index {next state} = function
    | ar & @array_is _ -> 
        inl body {next i} = find_index {next state=i::state} (ar i)
        for' {from=0; near_to=array_length ar; finally=next; body}
    | "princess" -> tuple_rev state
    | _ -> next ()

find_index {state=(); next = inl _ -> failwith (type (dim)) "The princess is in another castle."} ar
```
`failwith` unlike in F#, requires the return type in Spiral but otherwise functions the same.

The `@` operator on the pattern side is a partial active pattern. Unlike F#'s which expect an option type, what `@` takes in is a function with three arguments in the `inl arg on_fail on_succ -> ...` form. `on_fail` and `on_succ` are to be called in tail position and possibly with join points around them when done so multiple times. They represent pattern failure and pattern success respectively.

Here is a small example.

```
inl f pat = function
    | @pat x -> x
    | _ -> error_type "The pattern failed to trigger."

inl pat x on_fail on_succ =
    match x with
    | x: string | x: int64 -> join on_succ (string_format "{0} joined" x)
    | _ -> on_fail()

f pat "qwe", f pat 123
```
```
type Tuple0 =
    struct
    val mem_0: string
    val mem_1: string
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0(): string =
    "qwe joined"
and method_1(): string =
    "123 joined"
let (var_0: string) = method_0()
let (var_1: string) = method_1()
Tuple0(var_0, var_1)
```

Anything in Spiral can be passed as an argument, and since that includes functions it also applies to partial active patterns.

The output of the compiled program is rather large, but it will be reproduced in bulk as an example this time to show that all the loops are being unfolded correctly into tail recursive functions.

```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
let rec method_3((var_0: ((((string []) []) []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_8: (((string []) []) [])) = Array.zeroCreate<((string []) [])> (System.Convert.ToInt32(4L))
        let (var_9: int64) = 0L
        method_2((var_8: (((string []) []) [])), (var_9: int64))
        var_0.[int32 var_1] <- var_8
        method_3((var_0: ((((string []) []) []) [])), (var_3: int64))
    else
        ()
and method_4((var_0: ((((string []) []) []) [])), (var_1: int64), (var_2: int64)): Tuple0 =
    let (var_3: bool) = (var_2 < var_1)
    if var_3 then
        let (var_4: (((string []) []) [])) = var_0.[int32 var_2]
        let (var_5: int64) = var_4.LongLength
        let (var_6: int64) = 0L
        method_5((var_4: (((string []) []) [])), (var_2: int64), (var_5: int64), (var_0: ((((string []) []) []) [])), (var_1: int64), (var_6: int64))
    else
        (failwith "The princess is in another castle.")
and method_2((var_0: (((string []) []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_6: ((string []) [])) = Array.zeroCreate<(string [])> (System.Convert.ToInt32(4L))
        let (var_7: int64) = 0L
        method_1((var_6: ((string []) [])), (var_7: int64))
        var_0.[int32 var_1] <- var_6
        method_2((var_0: (((string []) []) [])), (var_3: int64))
    else
        ()
and method_5((var_0: (((string []) []) [])), (var_1: int64), (var_2: int64), (var_3: ((((string []) []) []) [])), (var_4: int64), (var_5: int64)): Tuple0 =
    let (var_6: bool) = (var_5 < var_2)
    if var_6 then
        let (var_7: ((string []) [])) = var_0.[int32 var_5]
        let (var_8: int64) = var_7.LongLength
        let (var_9: int64) = 0L
        method_6((var_7: ((string []) [])), (var_5: int64), (var_1: int64), (var_8: int64), (var_0: (((string []) []) [])), (var_2: int64), (var_3: ((((string []) []) []) [])), (var_4: int64), (var_9: int64))
    else
        let (var_11: int64) = (var_1 + 1L)
        method_4((var_3: ((((string []) []) []) [])), (var_4: int64), (var_11: int64))
and method_1((var_0: ((string []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_4: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(4L))
        let (var_5: int64) = 0L
        method_0((var_4: (string [])), (var_5: int64))
        var_0.[int32 var_1] <- var_4
        method_1((var_0: ((string []) [])), (var_3: int64))
    else
        ()
and method_6((var_0: ((string []) [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: (((string []) []) [])), (var_5: int64), (var_6: ((((string []) []) []) [])), (var_7: int64), (var_8: int64)): Tuple0 =
    let (var_9: bool) = (var_8 < var_3)
    if var_9 then
        let (var_10: (string [])) = var_0.[int32 var_8]
        let (var_11: int64) = var_10.LongLength
        let (var_12: int64) = 0L
        method_7((var_10: (string [])), (var_8: int64), (var_1: int64), (var_2: int64), (var_11: int64), (var_0: ((string []) [])), (var_3: int64), (var_4: (((string []) []) [])), (var_5: int64), (var_6: ((((string []) []) []) [])), (var_7: int64), (var_12: int64))
    else
        let (var_14: int64) = (var_1 + 1L)
        method_5((var_4: (((string []) []) [])), (var_2: int64), (var_5: int64), (var_6: ((((string []) []) []) [])), (var_7: int64), (var_14: int64))
and method_0((var_0: (string [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        var_0.[int32 var_1] <- ""
        method_0((var_0: (string [])), (var_3: int64))
    else
        ()
and method_7((var_0: (string [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: ((string []) [])), (var_6: int64), (var_7: (((string []) []) [])), (var_8: int64), (var_9: ((((string []) []) []) [])), (var_10: int64), (var_11: int64)): Tuple0 =
    let (var_12: bool) = (var_11 < var_4)
    if var_12 then
        let (var_13: string) = var_0.[int32 var_11]
        let (var_14: bool) = (var_13 = "princess")
        if var_14 then
            Tuple0(var_3, var_2, var_1, var_11)
        else
            let (var_15: int64) = (var_11 + 1L)
            method_7((var_0: (string [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: ((string []) [])), (var_6: int64), (var_7: (((string []) []) [])), (var_8: int64), (var_9: ((((string []) []) []) [])), (var_10: int64), (var_15: int64))
    else
        let (var_18: int64) = (var_1 + 1L)
        method_6((var_5: ((string []) [])), (var_2: int64), (var_3: int64), (var_6: int64), (var_7: (((string []) []) [])), (var_8: int64), (var_9: ((((string []) []) []) [])), (var_10: int64), (var_18: int64))
let (var_6: ((((string []) []) []) [])) = Array.zeroCreate<(((string []) []) [])> (System.Convert.ToInt32(4L))
let (var_7: int64) = 0L
method_3((var_6: ((((string []) []) []) [])), (var_7: int64))
let (var_8: (((string []) []) [])) = var_6.[int32 0L]
let (var_9: ((string []) [])) = var_8.[int32 0L]
let (var_10: (string [])) = var_9.[int32 0L]
var_10.[int32 2L] <- "princess"
let (var_11: int64) = var_6.LongLength
let (var_12: int64) = 0L
method_4((var_6: ((((string []) []) []) [])), (var_11: int64), (var_12: int64))
```

The continuation passing style is the key to a significant amount of abstractive power. It is difficult to understand in terms of what the program does, instead what is needed is to focus on what the program is.

There are numerous ways of writing `find_index` incorrectly that would not get immediately caught by the type system.

1) Forgetting to pass in the array.

```
...
find_index {state=(); next = inl _ -> failwith (type (dim)) "The princess is in another castle."}
```
```
...
method_3((var_6: ((((string []) []) []) [])), (var_7: int64))
let (var_8: (((string []) []) [])) = var_6.[int32 0L]
let (var_9: ((string []) [])) = var_8.[int32 0L]
let (var_10: (string [])) = var_9.[int32 0L]
var_10.[int32 2L] <- "princess"
(Env7((Env4((Env3((Env2((Env1((Env0(naked_type (*bool*))))))))))), (Env3((Env2((Env1((Env0(naked_type (*bool*))))))))), (Env6(Tuple5(4L, 4L, 4L, 4L)))))
```
Seeing a dozen nested `Env`s along with a naked type in the generated code is almost always a sign of forgetting to apply an argument somewhere.

2) Passing the state in incorrectly in the else branch.

```
...
| _ -> next state
```

This would still have it compile and run correctly, but the code would have 40 lines more of useless specializations. It won't be shown here.

3) Passing the state even more incorrectly.

```
inl rec find_index {next state} = function
    | ar & @array_is _ -> 
        inl body {next state i} = find_index {next state=i::state} (ar i)
        for' {from=0; near_to=array_length ar; state finally=next; body}
    | "princess" -> tuple_rev state
    | _ -> next state
```

This would cause it to diverge as it would continually append to `state` inside the loop.

In general though, programs written in a higher order style tend to work well after they typecheck much like in F# despite the language feeling more dynamic. And it is not necessarily the case that Spiral is less typesafe than F#. 

In fact it is the opposite for tasks that require union types due to F# having insufficient polymorphism in its type system. Many tasks that would otherwise require writing an interpreter in other languages can be done at compile time in Spiral.

Loop unrolling is just one of those examples.

Before the section on Loops can be finished there is just one bit of cleaning up left to do. That would be to merge `for` and `for'` into one function. Here is the full example in its completed form with a last minute change to `by`. The new loops are going to go into the standard library.

```
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
                    loop {from=from+by; state=body {state i=from}}
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

inl array_init near_to f =
    assert (near_to >= 0) "The input to init needs to be greater or equal to 0."
    // Somewhat of an ugly practice in order to infer the type in a language that doesn't support inference. 
    // For large functions, it is recomended to put them in a join point otherwise compile times could 
    // become exponential if the function contains branches.
    // For a simple map for an array like here, it does not matter.
    inl typ = type (f 0) 
    inl ar = array_create typ near_to
    for {from=0; near_to; body=inl {i} -> ar i <- f i}
    ar

inl rec zeroes = function
    | x :: x' -> array_init x (inl _ -> zeroes x')
    | () -> ""

inl dim = (4,4,4,4)
inl ar = zeroes dim
ar 0 0 0 2 <- "princess"

// Reverses a tuple
inl tuple_rev = 
    inl rec loop state = function
        | x :: xs -> loop (x :: state) xs
        | () -> state
    loop ()

// Correct version
inl rec find_index {next state} = function
    | ar & @array_is _ -> 
        inl body {next i} = find_index {next state=i::state} (ar i)
        for' {from=0; near_to=array_length ar; finally=next; body}
    | "princess" -> tuple_rev state
    | _ -> next ()

find_index {state=(); next = inl _ -> failwith (type (dim)) "The princess is in another castle."} ar
```

There was a lot of material covered here. The logic of `find_index` as well as the other loop unrolling functions might seem confusing to the uninitiated, and would no doubt be to the author had he encountered this over a year ago. But ultimately the function is just 5 lines long and there is nothing particular magical about it; the function is fully explicit. Thinking about it for a long time will help and so will mentally rehearsing the motions until the pieces fall into place.

One useful tool in gaining understanding is trying to manually expand the loop. Here is what happens if `find_index` is expanded a single step of recursion.

```
inl rec find_index {next state} = function
    | ar & @array_is _ -> 
        inl body {next i} = 
            inl state = i :: state
            match ar i with
            | ar & @array_is _ -> 
                inl body {next i} = find_index {next state=i::state} (ar i)
                for' {from=0; near_to=array_length ar; finally=next; body}
            | "princess" -> tuple_rev state
            | _ -> next ()
        for' {from=0; near_to=array_length ar; finally=next; body}
    | "princess" -> tuple_rev state
    | _ -> next ()
```

Supposing the input is one dimensional, that is if the type of the array was `string []` it become possible to do more partial evaluation by hand.

```
inl rec find_index {next state} = function
    | ar & @array_is _ -> 
        inl body {next i} = 
            inl state = i :: state
            match ar i with
            | "princess" -> tuple_rev state
            | _ -> next ()
        for' {from=0; near_to=array_length ar; finally=next; body}
```

This program corresponds to a single loop and is in fact what the program would get specialized to had it been given only a string array as input.

Seeing similar examples of this pattern will no doubt help and there will be a significant number of them throughout these tutorials.

#### Arrays

Compared to the intensity of the previous section, this one should be a breeze in comparison. The most important of the array functions `init` was already introduced. 

```
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
...
```

Here are some of the basic ones. Having a loop as a part of the standard library makes it really easy to implement the two `fold` functions. Unlike in F# where `foldl` and `foldr` are `fold` and `foldBack`, here the Haskell naming convention has been followed for no special reason apart from `foldr` being more elegant to write than `foldBack`.

```
// Creates an array given a dimension and a generator function to compute the elements.
// ?(.is_static) -> int -> (int -> a) -> a array
inl init = 
    inl body is_static n f =
        assert (n >= 0) "The input to init needs to be greater or equal to 0."
        inl typ = type (f 0)
        inl ar = array_create typ n
        inl d = 
            inl d = {near_to=n; body=inl {i} -> ar i <- f i}
            if is_static then {d with from = 0} else {d with static_from = 0}
        for d
        ar
    function
    | .static -> body true
    | n -> body false n
```

`init` here is a example how the architecture of a Spiral function differs from that in F#. The interesting part is that `.static` can be passed into it as an optional argument that will allow it to be run statically. Otherwise this is the same as the `init` from the previous section so no demonstration of it should be necessary.

```
/// Builds a new array that contains elements of a given array.
/// a array -> a array
met copy ar = init (array_length ar) ar

/// Builds a new array whose elements are the result of applying a given function to each of the elements of the array.
/// (a -> b) -> a array -> a array
inl map f ar = init (array_length ar) (ar >> f)
```

`init` is useful as it is easy to derive other functions from it. These two function exactly as in F# and other functional languages.

```
/// Returns a new array containing only elements of the array for which the predicate function returns `true`.
/// (a -> bool) -> a array -> a array
inl filter f ar =
    inl ar' = array_create ar.elem_type (array_length ar)
    inl count = foldl (inl s x -> if f x then ar' s <- x; s+1 else s) (dyn 0) ar
    init count ar'
```

Being able to apply arrays directly instead of having to index them allows them to be used more like functions. Also worthy of note is the `ar.elem_type`. In Spiral there is no inference, only propagation so the type of an array must be extracted directly. In Spiral, types are first class and can be used as values. This can be exploited to get around the lack of inference in most cases.

Arrays are a simple examples of how types might be held in structures.

Unlike other .NET types, arrays are built into the language directly.

```
/// Merges all the arrays in a tuple into a single one.
/// a array tuple -> a array
inl append l =
    inl ar' = array_create ((fst l).elem_type) (Tuple.foldl (inl s l -> s + array_length l) 0 l)
    inl ap s ar = foldl (inl i x -> ar' i <- x; i+1) s ar
    Tuple.foldl ap (dyn 0) l |> ignore
    ar'
```

Like how `init` can match on its first arguments before deciding whether to run statically or not, being able to iterate over tuples in order to merge the arrays is a standard use case for intensional polymorphism.

```
/// Flattens an array of arrays into a single one.
/// a array array -> a array
inl concat ar =
    inl count = foldl (inl s ar -> s + array_length ar) (dyn 0) ar
    inl ar' = array_create ar.elem_type.elem_type count
    (foldl << foldl) (inl i x -> ar' i <- x; i+1) (dyn 0) ar |> ignore
    ar'
```

`foldl << foldl` is a good way to compose folds for nested arrays.

Writing functions in this higher order style is the optimal way to program in Spiral. For contrast, here is how `concat` is implemented in F#'s source.

```
let concatArrays (arrs : 'T[][]) : 'T[] =
    let mutable acc = 0    
    for h in arrs do
        acc <- acc + h.Length        
        
    let res = Microsoft.FSharp.Primitives.Basics.Array.zeroCreateUnchecked acc  
        
    let mutable j = 0
    for i = 0 to arrs.Length-1 do     
        let h = arrs.[i]
        let len = h.Length
        Array.Copy(h,0,res,j,len)        
        j <- j + len
    res               
```

It is not quite C, but it is the same style inherited from it. All fast languages tend to regress to that particular kind of programming when performance or just the guarantee of it becomes a necessity.

Even in a pure and lazy language like Haskell, looking under the hood of some of its fast libraries will reveal this and other kinds of regressions.

On the strength of its inlining guarantees, the goal of Spiral is to liberate programmers from that gravitic impulse towards C.

During the last 45 years there have been numerous attempts at bridging the expressiveness of dynamic languages with the performance of C, none of which have borne fruit.

Assuming Spiral can be scaled, it or some other language of similar design with powerful first class types and staging features will finally break beyond the atmosphere to bring light of civilization into the cold, dead space that lies beyond.

The above example is not that bad actually. It is only 12 lines in F# vs 5 in Spiral. It is hardly a reason to create a new language and propose the jettison of parametric polymoprhism.

In the following chapters there will be examples of programs, most notably of Spiral's tensors, whose functionalities have such requirements that would pretty much break any existing language.

The next two functions are all that remains of the module.

```
/// Tests if all the elements of the array satisfy the given predicate.
/// (a -> bool) -> a array -> bool
inl forall f ar = for' {from=0; near_to=array_length ar; state=true; body = inl {next state i} -> f (ar i) && next state}

/// Tests if any the element of the array satisfies the given predicate.
/// (a -> bool) -> a array -> bool
inl exists f ar = for' {from=0; near_to=array_length ar; state=false; body = inl {next state i} -> f (ar i) || next state}

{empty singleton foldl foldr init copy map filter append concat forall exists} 
|> stack
    """) |> module_
```

On the F# side it is necessary to wrap the module in a type using the `module_` function. That `|> stack` at the end is not necessary and only has something to do with the way the language is currently implemented. Omitting the conversion of the module to a layout type would not break anything, at most there might be a minor compilation slowdown. More details are (to be) provided in the user guide.

Modules with no free variables such as the `Array` module whose fields are entirely made of combinators always get converted into naked types rather than variables and hence have no overhead.

### 3: Union Types and Lists

Discriminated union types in Spiral take direct inspiration from F#'s own. Having said that, the lack of type inference and the aggressive unboxing of them by the Spiral evaluator makes them less convenient to work with. Nonetheless, union types capture the essence of dynamism and are absolutely essential in a modern language.

Since Spiral has first class types, type string literals take the place of case names. Furthermore, types can be defined anywhere in the program rather than only at the top level like in F#.

A non-recursive union type like the Option can be defined like the following. `\/` is the type union keyword operator. It has a lower precedence than tuples.

```
inl Option x = .Some, x \/ .None

// constructors
inl some x = box (Option x) (.Some, x)
inl none x = box (Option x) (.None)

none int64
```
```
type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
Union0Case1
```

Commentary on the quality of the generated code will be left for the user guide. Pattern matching on the boxed union values can be done the same way as in F#.

```
match none int64 with
| .Some, x -> x
| .None -> -11
```
```
11L
```

The word 'staging' means 'defering for later'. Just like literals, the creation of union types is deferred for as long as possible in Spiral.

In order to actually instantiate the type, it is necessary to `dyn` it or return it from a join point or an if branch. The end of the entire program also qualifies for instantiation.

```
match none int64 |> dyn with
| .Some, x -> x
| .None -> -11
```
```
type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let (var_0: Union0) = Union0Case1
match var_0 with
| Union0Case0(var_1) ->
    var_1.mem_0
| Union0Case1 ->
    -11L
```

The above is roughly what would be expect to in F# or the MLs. Spiral's pattern matching is more flexible though.

```
inl TypeA = .A \/ .B
inl TypeB = .B \/ .C

inl f = function
    | .A -> 1
    | .B -> 2
    | .C -> 3

box TypeA .A |> dyn |> f |> ignore
box TypeB .C |> dyn |> f |> ignore
```
```
type Union0 =
    | Union0Case0
    | Union0Case1
and Union1 =
    | Union1Case0
    | Union1Case1
let (var_0: Union0) = Union0Case0
let (var_1: int64) =
    match var_0 with
    | Union0Case0 ->
        1L
    | Union0Case1 ->
        2L
let (var_2: Union1) = Union1Case1
let (var_3: int64) =
    match var_2 with
    | Union1Case0 ->
        2L
    | Union1Case1 ->
        3L
```

Despite this added flexibility, it is in fact exhaustive. Unlike in F#, this is not a warning, but an error as Spiral's union types are intended to be used on devices which have no capabilities for raising exceptions.

```
inl TypeA = .A \/ .B

inl f = function
    | .A -> 1
    | .C -> 3

box TypeA .A |> dyn |> f |> ignore
```
```
...
Error trace on line: 35, column: 7 in file "example".
    | .A -> 1
      ^
Error trace on line: 36, column: 7 in file "example".
    | .C -> 3
      ^
Pattern miss error. The argument is type (type_lit (B))
```

As it never matches `.B` it goes over the edge and returns a type error.

Here is how recursive datatypes like lists might be defined.

```
let example = 
    "example",[option;tuple;loops],"Module description.",
    """
open Loops
inl rec List x = join_type () \/ x, List x

/// Creates an empty list with the given type.
/// t -> List t
inl empty x = box (List x) ()

/// Creates a single element list with the given type.
/// x -> List x
inl singleton x = box (List x) (x, empty x)

/// Immutable appends an element to the head of the list.
/// x -> List x -> List x
inl cons a b = 
    inl t = List a
    box t (a, box t b)

singleton 3 |> cons 2 |> cons 1
    """
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
(Rec0Case1(Tuple1(1L, (Rec0Case1(Tuple1(2L, (Rec0Case1(Tuple1(3L, Rec0Case0)))))))))
```

`join_type` is similar to the standard `join` except it is used to define types. It always returns a naked type and on entry converts everything in the environment to their types and that includes literals. That means that passing literals through the type join point requires doing it on the type level or inside a layout type.

```
/// Creates a list by calling the given generator on each index.
/// ?(.static) -> int -> (int -> a) -> List a
inl init =
    inl body is_static n f =
        inl t = type (f 0)
        inl d = {near_to=n; state=empty t; body=inl {next i state} -> cons (f i) (next state)}
        if is_static then for' {d with static_from=0}
        else for' {d with from=0}

    function
    | .static -> body true
    | x -> body false x
```

The above function resembles the `init` in the `Array` module in structure. There is an interesting usage of the breakable `for'` here. Usually the `next` is intended to be called in tail position, but here it is not. Instead the `state` is used merely to ship the empty list to the end of it.

```
inl x = init.static 3 id |> dyn
()
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: Rec0) = (Rec0Case1(Tuple1(0L, (Rec0Case1(Tuple1(1L, (Rec0Case1(Tuple1(2L, Rec0Case0)))))))))
```

The above is nearly identical to the `singleton 3 |> cons 2 |> cons 1` example.

The next function on the list would be the `map`. This is where things start to get tricky. Here is an example of it that does not work.

```
inl rec map f l = 
    inl loop l =
        match l with
        | x,xs -> cons (f x) (map f xs)
        | () -> l // Error #1
        : ??? // Error #2
    if box_is l then loop l
    else join loop l
```

Error #2 should be obvious - there is no return type. Error #1 is more subtle - and is related to the way pattern matching is compiled. 

Backtracking to the earlier example.

```
inl TypeA = .A \/ .B

inl f = function
    | x -> x

box TypeA .A |> dyn |> f |> ignore
```
```
type Union0 =
    | Union0Case0
    | Union0Case1
let (var_0: Union0) = Union0Case0
```

The above is as one would expect.

```
inl TypeA = .A \/ .B

inl f = function
    | "qwe" -> ()
    | x -> x

box TypeA .A |> dyn |> f |> ignore
```
```
...
Error trace on line: 35, column: 7 in file "example".
    | "qwe" -> ()
      ^
All the cases in pattern matching clause with dynamic data must have the same type.
Got: [type_lit (A), type_lit (B)]
```

The error message gives an indication of what is wrong. In Spiral, the match case is not what triggers unboxing - the operations that actually need to unbox the union type are what do it. That means literal, type literal, type equality, tuple and module patterns. This applies even to those patterns that have nothing to do with the variable's type and would have been expected to be skipped.

It gets worse. Spiral is really aggressive at rewriting the terms it is unboxing even if they are outside its intended scope.

```
inl x = box TypeA .A |> dyn
print_static x // var (union {type_lit (A) | type_lit (B)})

match x with
| "qwe" -> ()
| _ -> 
    // prints twice
    // type (type_lit (A))
    // type (type_lit (B))
    print_static x 
    x
```
```
...
All the cases in pattern matching clause with dynamic data must have the same type.
Got: [type_lit (A), type_lit (B)]
```

The way things are currently is the fault of whoever wrote the pattern matching compiler. Since patterns would be difficult to compile otherwise, internally Spiral uses the same mechanism used to do common subexpression elimination to pass information over multiple branches. There is no issue at all with this when not dealing with union types, but here there is some friction there.

There is something good about the current arrangement that MLs do not have.

```
inl TypeA = .A \/ .B \/ .C \/ .D

inl f g = function
    | .A -> 1
    | .B -> 2
    | x -> 
        dyn "Just passing through." |> ignore
        g x

f (function
    | .C -> 3
    | .D -> 4)
    (box TypeA .A |> dyn )
```
```
type Union0 =
    | Union0Case0
    | Union0Case1
    | Union0Case2
    | Union0Case3
let (var_0: Union0) = Union0Case0
match var_0 with
| Union0Case0 ->
    1L
| Union0Case1 ->
    2L
| Union0Case2 ->
    let (var_1: string) = "Just passing through."
    3L
| Union0Case3 ->
    let (var_2: string) = "Just passing through."
    4L
```

That would be that the exhaustiveness check is not local to the pattern. As long as all the branches of it are properly handled, the pattern does not have to be squeezed all into one place and can be composed. This is one of the safety aspects at compile time that F# does not have.

Regardless of the merits and demerits of this approach, in order to complete the map function some kind of method for getting what would be the generic parameter of the list in a parametric language is needed.

#### Type Splitting and Generic Parameters

```
/// Returns the element type of the list.
/// a List -> a type
inl elem_type l =
    match split l with
    | (), (a,b) when eq_type (List a) l -> a
    | _ -> error_type "Expected a List in elem_type."
```

The way the `split` function works is that it splits an union type into its individual components and returns them as a tuple. After it has been split, this makes it possible to match on the types of it directly.

```
inl Option x = .Some, x \/ .None
print_static (Option int64) // type (union {[type_lit (Some), int64] | type_lit (None)})
print_static (Option int64 |> split) // [type ([type_lit (Some), int64]), type (type_lit (None))]
```

This is a bit of a hack. Spiral has union and not sum types, meaning they are not ordered. Or better put, they are ordered, just not based on how they were entered.

The above example works for lists and is how they are implemented in the standard library, but there are alternative ways of implementing the basic list.

```
inl rec List x = join_type 
    inl el = stack {elem_type=x}
    el, () \/ el, (x, List x)
```

They all involve sticking the type in directly by using layout types. Since layout types capture the scope by the expression instead of type and since `x` can only ever be a naked type once it passes the `join_type` point, that assures that it will always be instantiated.

If adding `el` to all the branches of a larger type by hand is tedious, it is possible to automate that. It needs to be done inside the type join point. Here is how it would be done on a tuple.

```
inl rec List x = join_type 
    inl el = stack {elem_type=x}
    inl typ = () \/ x, List x
    split typ
    |> Tuple.map (inl x -> el, x)
    |> Tuple.reducel (inl a b -> a \/ b)

// [type ([layout_stack {elem_type=type (int64)}, []]), type ([layout_stack {elem_type=type (int64)}, [int64, rec_type 0]])]
print_static (split (List int64))
```

Using first class types Spiral can emulate what would be generic parameters of a container in a language with parametric polymorphism.

With `elem_type` in hand, it becomes possible to implement map.

```
/// Builds a new list whose elements are the results of applying the given function to each of the elements of the list.
/// (a List -> b List) -> a List -> List b
inl rec map f l = 
    inl t = elem_type l
    inl loop = function
        | x,xs -> cons (f x) (map f xs)
        | () -> empty t
    if box_is l then loop l
    else join loop l : List t

inl l = init.static 3 id |> map ((*) 2) |> dyn
()
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: Rec0) = (Rec0Case1(Tuple1(0L, (Rec0Case1(Tuple1(2L, (Rec0Case1(Tuple1(4L, Rec0Case0)))))))))
```

The static version of map works fine now.

Here is how the non-static version looks like.

```
init 3 id |> map ((*) 2) |> dyn
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_1((var_0: int64)): Rec0 =
    let (var_1: bool) = (var_0 < 3L)
    if var_1 then
        let (var_2: int64) = (var_0 + 1L)
        let (var_3: Rec0) = method_1((var_2: int64))
        (Rec0Case1(Tuple1(var_0, var_3)))
    else
        Rec0Case0
and method_2((var_0: Rec0)): Rec0 =
    match var_0 with
    | Rec0Case0 ->
        Rec0Case0
    | Rec0Case1(var_1) ->
        let (var_2: int64) = var_1.mem_0
        let (var_3: Rec0) = var_1.mem_1
        let (var_4: int64) = (2L * var_2)
        let (var_5: Rec0) = method_2((var_3: Rec0))
        (Rec0Case1(Tuple1(var_4, var_5)))
let (var_0: int64) = 0L
let (var_1: Rec0) = method_1((var_0: int64))
method_2((var_1: Rec0))
```

This does not demonstrate Spiral's true power. The function can map over lists that are partially static.

```
inl l = dyn (singleton 3) |> cons 2 |> cons 1 |> cons 0
map ((*) 2) l |> dyn
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_1((var_0: Rec0)): Rec0 =
    match var_0 with
    | Rec0Case0 ->
        Rec0Case0
    | Rec0Case1(var_1) ->
        let (var_2: int64) = var_1.mem_0
        let (var_3: Rec0) = var_1.mem_1
        let (var_4: int64) = (2L * var_2)
        let (var_5: Rec0) = method_1((var_3: Rec0))
        (Rec0Case1(Tuple1(var_4, var_5)))
let (var_0: Rec0) = (Rec0Case1(Tuple1(3L, Rec0Case0)))
let (var_1: Rec0) = method_1((var_0: Rec0))
(Rec0Case1(Tuple1(0L, (Rec0Case1(Tuple1(2L, (Rec0Case1(Tuple1(4L, var_1)))))))))
```

The first 3 elements are done at compile time, and the rest is done at runtime.

With the map done, `foldl` and `foldr` are straightforward enough.

```
/// Applies a function f to each element of the collection, threading an accumulator argument through the computation. 
/// The fold function takes the second argument, and applies the function f to it and the first element of the list. 
/// Then, it feeds this result into the function f along with the second element, and so on. It returns the final result. 
/// If the input function is f and the elements are i0...iN, then this function computes f (... (f s i0) i1 ...) iN.
/// (s -> a -> s) -> s -> a List -> s
inl rec foldl f s l = 
    inl loop = function
        | x, xs -> foldl f (f s x) xs
        | () -> s
    if box_is l then loop l
    else join loop l : s

inl l = dyn (singleton 3) |> cons 2 |> cons 1 |> cons 0
foldl (+) (dyn 0) l
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_1((var_0: Rec0), (var_1: int64)): int64 =
    match var_0 with
    | Rec0Case0 ->
        var_1
    | Rec0Case1(var_2) ->
        let (var_3: int64) = var_2.mem_0
        let (var_4: Rec0) = var_2.mem_1
        let (var_5: int64) = (var_1 + var_3)
        method_1((var_4: Rec0), (var_5: int64))
let (var_0: Rec0) = (Rec0Case1(Tuple1(3L, Rec0Case0)))
let (var_1: int64) = 0L
let (var_2: int64) = (var_1 + 1L)
let (var_3: int64) = (var_2 + 2L)
method_1((var_0: Rec0), (var_3: int64))
```

One thing the example above demonstrates is that Spiral does require the user to know whether compile time or runtime execution is being targeted. The above fragment is not ideal since it would be better to sum the static part of the list and then `dyn` the state rather than do so at the beginning.

```
/// Applies a function to each element of the collection, threading an accumulator argument through the computation. 
/// If the input function is f and the elements are i0...iN, then this function computes f i0 (...(f iN s)).
/// (a -> s -> s) -> a List -> s -> s
inl rec foldr f l s = 
    inl loop = function
        | x, xs -> f x (foldr f xs s)
        | () -> s
    if box_is l then loop l
    else join loop l : s

inl l = dyn (singleton 3) |> cons 2 |> cons 1 |> cons 0
foldr (+) l (dyn 0)
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_1((var_0: Rec0), (var_1: int64)): int64 =
    match var_0 with
    | Rec0Case0 ->
        var_1
    | Rec0Case1(var_2) ->
        let (var_3: int64) = var_2.mem_0
        let (var_4: Rec0) = var_2.mem_1
        let (var_5: int64) = method_1((var_4: Rec0), (var_1: int64))
        (var_3 + var_5)
let (var_0: Rec0) = (Rec0Case1(Tuple1(3L, Rec0Case0)))
let (var_1: int64) = 0L
let (var_2: int64) = method_1((var_0: Rec0), (var_1: int64))
let (var_3: int64) = (2L + var_2)
(1L + var_3)
```

The next are `head` and `tail`.

```
open Option

/// Returns the first element of the list.
/// a List -> a Option
inl head l =
    inl t = elem_type l
    match l with
    | x, xs -> some x
    | () -> none t

/// Returns the list without the first element.
/// a List -> a List Option
inl tail l =
    inl t = elem_type l
    match l with
    | x, xs -> some xs
    | () -> none (List t)
```

As the above are straightforward so there is no need to run them. That being said, it would be interesting to know how it might be possible to implement them in continuation passing style for greater efficiency.

```
/// Returns the first element of the list.
/// a List -> {some=(a -> a) none=(a type -> a)} -> a
inl head' l {some none} =
    inl t = elem_type l
    match l with
    | x, xs -> some x
    | () -> none t

/// Returns the list without the first element.
/// a List -> {some=(a List -> a List) none=(a List type -> a List)} -> a List
inl tail' l {some none} =
    inl t = elem_type l
    match l with
    | x, xs -> some xs
    | () -> none (List t)

inl l = dyn (singleton 3)
tail' l {
    some = id
    none = inl x -> failwith x "The list is empty."
    }
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: Rec0) = (Rec0Case1(Tuple1(3L, Rec0Case0)))
match var_0 with
| Rec0Case0 ->
    (failwith "The list is empty.")
| Rec0Case1(var_1) ->
    let (var_3: int64) = var_1.mem_0
    var_1.mem_1
```

The best is left for `last`.

```
/// Returns the last element of the list.
/// a List -> a Option
inl last l =
    inl t = elem_type l
    foldl (inl _ x -> some x) (none t) l

inl l = dyn (singleton 3) |> cons 2 |> cons 1 |> cons 0
last l 
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union2 =
    | Union2Case0 of Tuple3
    | Union2Case1
and Tuple3 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_1((var_0: Rec0)): Union2 =
    match var_0 with
    | Rec0Case0 ->
        (Union2Case0(Tuple3(2L)))
    | Rec0Case1(var_1) ->
        let (var_2: int64) = var_1.mem_0
        let (var_3: Rec0) = var_1.mem_1
        method_2((var_3: Rec0), (var_2: int64))
and method_2((var_0: Rec0), (var_1: int64)): Union2 =
    match var_0 with
    | Rec0Case0 ->
        (Union2Case0(Tuple3(var_1)))
    | Rec0Case1(var_2) ->
        let (var_3: int64) = var_2.mem_0
        let (var_4: Rec0) = var_2.mem_1
        method_2((var_4: Rec0), (var_3: int64))
let (var_0: Rec0) = (Rec0Case1(Tuple1(3L, Rec0Case0)))
method_1((var_0: Rec0))
```

The above way of specializing it is close to ideal. It would be better had `method_1` been inlined, but this is a decent showing. As can be seen, the option type is staged and only the int inside is passed through until it is time to return from the function at which point the instantiation happens. In F#, this way of doing `last` would be grossly inefficient as a new option would be instantiated at each step. Very few languages allow passing of literals across call boundaries due to the uncertainty whether the optimizer will diverge. Spiral achieves its efficiency by making dealing with the [halting problem](https://en.wikipedia.org/wiki/Halting_problem) the user's responsibility. This is not a bad strategy - as the halting problem is NP Hard, other compilers' optimizers have no choice but to rely on fallible heuristics whereas the user has to determine whether the program will terminate anyway and has no say in what the black box is deciding. It is not so in Spiral.

The essence of Spiral is to convert the termination proofs implicitly and informally present in the program into polymorphism.

Here is how it would be done in CPS for that last bit of efficiency.

```
/// Returns the last element of the list.
/// a List -> {some=(a -> a) none=(a type -> a)} -> a
inl rec last' l {some none} =
    inl t = elem_type l
    inl loop = function
        | x, xs -> last' xs {some none=some x}
        | () -> none t
    if box_is l then loop l
    else join loop l : none t

inl l = dyn (singleton 3)
last' l {
    some = inl x _ -> x
    none = inl t -> failwith t "The list is empty."
    }
```
```
type Rec0 =
    | Rec0Case0
    | Rec0Case1 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_1((var_0: Rec0)): int64 =
    match var_0 with
    | Rec0Case0 ->
        (failwith "The list is empty.")
    | Rec0Case1(var_1) ->
        let (var_3: int64) = var_1.mem_0
        let (var_4: Rec0) = var_1.mem_1
        method_2((var_4: Rec0), (var_3: int64))
and method_2((var_0: Rec0), (var_1: int64)): int64 =
    match var_0 with
    | Rec0Case0 ->
        var_1
    | Rec0Case1(var_2) ->
        let (var_3: int64) = var_2.mem_0
        let (var_4: Rec0) = var_2.mem_1
        method_2((var_4: Rec0), (var_3: int64))
let (var_0: Rec0) = (Rec0Case1(Tuple1(3L, Rec0Case0)))
method_1((var_0: Rec0))
```

It can no longer be implemented in terms of fold, but otherwise is rather simple.

Note that `head'`, `tail'` and `last'` are just more generic versions of the non-CPS versions. Assuming the 3 original functions were missing, here is how they might be implemented in terms of CPS'd ones.

```
/// Returns the first element of the list.
/// a List -> a Option
inl head l = head' l {some none}

/// Returns the list without the first element.
/// a List -> a List Option
inl tail l = tail' l {some none}

/// Returns the last element of the list.
/// a List -> a Option
inl last l = last' l {some=const << some; none}
```

Here `const` is simply `inl x _ -> x` as was used inside `some` of the previous example. The continuation passing style is great for writing generic code in Spiral as it meshes well with its typing scheme. The monadic computations that will be shown in the following chapters are just syntax sugar over CPS.

The capacity to make specialized functions from generic one like the above is an important factor in ensuring code correctness. Eliminating code duplication and ensuring single responsibility is possible without performance impact in Spiral.

```
/// Returns a new list that contains the elements of the first list followed by elements of the second.
/// a List -> a List -> a List
inl append = foldr cons

/// Returns a new list that contains the elements of each list in order.
/// a List List -> a List
inl concat l & !elem_type !elem_type t = foldr append l (empty t)

{List empty cons init map foldl foldr singleton head' tail' last' head tail last append concat} |> stack
```

With this, the new List module is done.

#### Warning on combining union types, partial active patterns and join points

Union types in Spiral are an example of a well designed feature with some implementation issues. Union types work, partial active patterns work and join points work, but right now they are a pick two out of three kind of deal. The reason for this is related to how Spiral will aggressively rewrite even variables outside of its intended scope.

```
inl ab = box (.A \/ .B)
inl x = dyn (ab .A, ab .A, ab .A)
match x with
| .A, .A, _ -> 1
| .A, .B, .B -> 2
| _, _, .A -> 3
| _ -> 4   
```
```
type Union0 =
    | Union0Case0
    | Union0Case1
let (var_0: Union0) = Union0Case0
let (var_1: Union0) = Union0Case0
let (var_2: Union0) = Union0Case0
match var_0 with
| Union0Case0 ->
    match var_1 with
    | Union0Case0 ->
        1L
    | Union0Case1 ->
        match var_2 with
        | Union0Case0 ->
            3L
        | Union0Case1 ->
            2L
| Union0Case1 ->
    match var_2 with
    | Union0Case0 ->
        3L
    | Union0Case1 ->
        4L
```

The above compiles nicely, but suppose a partial active pattern with a join point is inserted in the middle.

```
inl ab = box (.A \/ .B)
inl x = dyn (ab .A, ab .A, ab .A)
inl pat arg on_fail on_succ = join on_fail ()
match x with
| .A, .A, _ -> 1
| @pat _ -> -1
| .A, .B, .B -> 2
| _, _, .A -> 3
| _ -> 4    
```
```
type Union0 =
    | Union0Case0
    | Union0Case1
let rec method_0((var_0: Union0), (var_1: Union0), (var_2: Union0)): int64 =
    match var_0 with
    | Union0Case0 ->
        match var_1 with
        | Union0Case0 ->
            match var_2 with
            | Union0Case0 ->
                3L
            | Union0Case1 ->
                4L
        | Union0Case1 ->
            match var_2 with
            | Union0Case0 ->
                3L
            | Union0Case1 ->
                2L
    | Union0Case1 ->
        match var_2 with
        | Union0Case0 ->
            3L
        | Union0Case1 ->
            4L
let (var_0: Union0) = Union0Case0
let (var_1: Union0) = Union0Case0
let (var_2: Union0) = Union0Case0
match var_0 with
| Union0Case0 ->
    match var_1 with
    | Union0Case0 ->
        1L
    | Union0Case1 ->
        method_0((var_0: Union0), (var_1: Union0), (var_2: Union0))
| Union0Case1 ->
    method_0((var_0: Union0), (var_1: Union0), (var_2: Union0))
```

What is going on here is that the evaluator is forgetting that it already tested the variables and starts unboxing them again inside the join point. This is because join points throw away local left to right rewrite information.

A workaround would be to put join points in the clause bodies.

```
inl ab = box (.A \/ .B)
inl x = dyn (ab .A, ab .A, ab .A)
inl pat arg on_fail on_succ = on_fail ()
match x with
| .A, .A, _ -> join 1
| @pat _ -> join -1
| .A, .B, .B -> join 2
| _, _, .A -> join 3
| _ -> join 4
```
```
type Union0 =
    | Union0Case0
    | Union0Case1
let rec method_0(): int64 =
    1L
and method_1(): int64 =
    3L
and method_2(): int64 =
    2L
and method_3(): int64 =
    4L
let (var_0: Union0) = Union0Case0
let (var_1: Union0) = Union0Case0
let (var_2: Union0) = Union0Case0
match var_0 with
| Union0Case0 ->
    match var_1 with
    | Union0Case0 ->
        method_0()
    | Union0Case1 ->
        match var_2 with
        | Union0Case0 ->
            method_1()
        | Union0Case1 ->
            method_2()
| Union0Case1 ->
    match var_2 with
    | Union0Case0 ->
        method_1()
    | Union0Case1 ->
        method_3()
```
Now the result is what one might want.

In the future this might not be an issue and in fact, it might just get fixed as a natural process of making the compiler run faster. The way patterns work now is inefficient from a compilation speed perspective and there is room for improvement there. In fact, since pattern matching is so ubiquitous in Spiral, that would be the first thing one would want to optimize in order to speed up compilation.

The way they work now though has the great combination of them being elegant, highly effective and simple to implement.

It is difficult to imagine what could be added to Spiral for it to generate better code for runtime at this point. Spiral's one pass is THE optimization pass to optimize these patterns at runtime, but it does not have any capacity to optimize its own compilation.

Right now Spiral's worst problem is its poor library support. The libraries are always in text and have to be parsed and prepassed from the scratch on every compilation. The way most languages solve that is by inventing an intermediate bytecode format, but without a doubt there exists a language design that would allow both the language to be fused to libraries, and to optimize both itself and the programs it is applied to. Without a doubt, such a language would significantly exceed Spiral in quality.

One thing is for certain, such a language would be hard to write as a standard compiler in F#. A lot more infrastructure support would be necessary in order to support a fundamentally different approach towards compiler construction. Its own platform and a surgical compiler like [Lancet](https://github.com/TiarkRompf/lancet) would be a prerequisite. MLs are more suited towards writing interpreters than language towers. 

[Racket](https://racket-lang.org/) has a superior ecosystem for writing such a language compared to the .NET, but it is the author's opinion that the parser in particular is not the best place to do compile time evaluation of functions and that syntax should not be used for abstraction - it should be used for ergonomics and should be consistent. Parsing should be a step to get rid of syntax for the rest of the passes.

Macros do not make sense in dynamic languages as a tool for language creation. They are absolute insanity in static languages. Often when static languages reach the limit of their design they cram macros to do everything else - like performance optimizations for example, and tout them as a feature rather than an admission of failure in language design. 

Wanting macros in order to optimize performance will never happen in Spiral.

### 4: Continuation Passing Style, Monadic Computation and Parsing

Now that union types are out of the way, slowly the subject can move towards the more fun stuff that can be done with the language. CPS is a great way of writing highly abstract, generic and very fast code in Spiral and so the language has support for programming in such a style using monadic syntax. Modules are a significant aid as well for programming in CPS.

This chapter will be short and won't go into depth of how monads work. Neither will it explain how parsers work. As both of those subjects are highly complex, it would take a lot of time to cover them. For parsers combinators in particular, the place place to learn how they work would be to start with the [FParsec documentation](http://www.quanttec.com/fparsec/).

For monads in particular, it is best to study their specific instances. There is a large amount of tutorials online regarding them, most often in the context of the Haskell language. More closer to home, the author's understanding of them went through a dramatic improvement once he stopped trying to figure out what the higher kinded types are doing and simply focused on the functions themselves in terms of flow.

```
inl on_succ a = (a,())
inl on_log x = ((),Tuple.singleton x)
inl (>>=) (a,w) f = // The writer monad.
    inl a',w' = f a
    (a',Tuple.append w w')

inl add x y = x + y |> on_succ

inm x = add 1 1
inm _ = on_log x
inm y = add 3 4
inm _ = on_log y
inm z = add 5 6
inm _ = on_log z
on_succ (x+y+z) // Tuple2(20L, Tuple1(2L, 7L, 11L))
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple1 =
    struct
    val mem_0: int64
    val mem_1: Tuple0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
Tuple1(20L, Tuple0(2L, 7L, 11L))
```

What the `inm` keyword does is merely rewrite `inm x = f` to `f >>= inl x -> ...`. Meaning the above example could have been done manually as...

```
add 1 1 >>= inl x ->
on_log x >>= inl _ ->
add 3 4 >>= inl y ->
on_log y >>= inl _ ->
add 5 6 >>= inl z ->
on_log z >>= inl _ ->
on_succ (x+y+z)
```

The writer monad pattern is notable as it is used to accumulate the backwards trace in the ML library, so it is worth keeping in mind. Despite the power of monads, most of the time they are used to encapsulate state.

Apart from `inm` there is also `inb`.

```
inl f x ret =
    Console.writeline x
    ret()
    Console.writeline "done"
inb x = f "hello"
Console.writeline "doing work"
```
```
System.Console.WriteLine("hello")
System.Console.WriteLine("doing work")
System.Console.WriteLine("done")
```

A pattern similar to the above is used to emulate stack allocation of Cuda memory in the ML library.

Anyway, here is a simple Spiral parser library written in CPS style just for the sake of making a benchmark. A more advanced version in monadic style can be found in the standard library.

#### Parsing Benchmark

```
let example = 
    "example",[option;tuple;loops;extern_;console],"Module description.",
    """
/// Converts a string to a parser stream.
/// string -> parser_stream
inl string_stream str {idx on_succ on_fail} =
    inl f idx = idx >= 0 && idx < string_length str
    inl branch cond = if cond then on_succ (str idx) else on_fail "string index out of bounds" 
    match idx with
    | a, b -> branch (f a && f b)
    | _ -> branch (f idx)

/// Runs a parser given the string and the expected return type.
/// t type -> string -> t parser -> t
inl run ret_type str parser = 
    inl stream = dyn str |> string_stream

    inl d = {
        stream
        on_succ = inl x state -> id x
        on_fail = inl x state -> failwith ret_type x
        on_type = ret_type
        }

    parser d {pos=dyn 0}

/// Reads a char.
/// char parser
inl stream_char {stream on_succ on_fail} {state with pos} =
    stream {
        idx = pos
        on_succ = inl c -> on_succ c {state with pos=pos+1}
        on_fail = inl msg -> on_fail msg state
        }

inl is_digit x = x >= '0' && x <= '9'
inl is_whitespace x = x = ' '
inl is_newline x = x = '\n' || x = '\r'

/// Reads a digit.
/// char parser
inl digit {stream on_succ on_fail} state =
    stream_char {
        stream on_fail
        on_succ = inl x state' -> 
            if is_digit x then on_succ x state'
            else on_fail "digit" state
        } state

inl convert_type = fs [text: "System.Convert"]
inl to_uint64 x = Extern.FS.StaticMethod convert_type .ToUInt64 x uint64
/// Reads an 64-bit integer parser.
/// uint64 parser
inl puint64 {stream on_succ on_fail on_type} state =
    inl error state = on_fail "puint64" state
    inl rec loop i on_fail state =
        digit {
            stream
            on_fail=inl _ state -> on_fail i state
            on_succ=inl c state ->
                inl max = 1844674407370955161u64 // max of uint64 / 10u64
                if i <= max then
                    inl i' = i * 10u64 + to_uint64 c - to_uint64 '0'
                    if i < i' then join loop i' on_succ state
                    else error state
                else error state
            } state
        : on_type
    loop (dyn 0u64) (inl _ state -> error state) state

/// The skips an all the whitespaces (including newlines) before succeeding.
/// unit parser
met rec spaces {d with stream on_succ on_fail on_type} state =
    stream_char {
        stream
        on_fail = inl _ state -> on_succ () state
        on_succ = inl c state' -> 
            if is_whitespace c || is_newline c then spaces d state'
            else on_succ () state
        } state
    : on_type

/// Runs the first and then the second parser before returning the result of the second parser.
/// a parser -> b parser -> b parser
inl (>>.) a b {d with on_succ} state = a {d with on_succ = inl _ state -> b d state} state
/// Runs the first and then the second parser before returning the result of the first parser.
/// a parser -> b parser -> a parser
inl (.>>) a b {d with on_succ} state = 
    a {d with on_succ = inl a state -> 
        b {d with on_succ = inl _ state -> on_succ a state} state
        } state

/// Runs the tuple of parsers before returning their result.
/// tuple parser
inl rec tuple l {d with on_succ} state =
    match l with
    | x :: xs ->
        x {d with on_succ = inl x state ->
            tuple xs {d with on_succ = inl xs state ->
                on_succ (x :: xs) state
                } state
            } state
    | () -> on_succ () state

/// Parses an unsigned 64-bit integer and returns it after parsing whitespaces.
/// uint64 parser
inl num = puint64 .>> spaces

run (uint64,uint64,uint64) "123 456 789" (tuple (num, num, num))
    """
```
As the output is 376 lines long, it won't be pasted. Here is a straightforward translation of the above to F#.
```
let example2 = 
    /// Converts a string to a parser stream.
    /// string -> parser_stream
    /// Note: The functionality of this functions needs to be pared down in F# due to lack of intensional polymorphism.
    let string_stream (str: string) (idx, on_succ, on_fail) =
        if idx >= 0 && idx < str.Length then on_succ str.[idx] else on_fail "string index out of bounds" 

    /// Runs a parser given the string and the expected return type.
    /// string -> t parser -> t
    let run str parser = 
        let stream = string_stream str

        let d = 
            stream
            ,fun x state -> id x
            ,fun x state -> failwith x

        parser d 0

    /// Reads a char.
    /// char parser
    let stream_char (stream, on_succ, on_fail) pos =
        stream 
            (pos
            ,fun c -> on_succ c (pos+1)
            ,fun msg -> on_fail msg pos
            )

    let is_digit x = x >= '0' && x <= '9'
    let is_whitespace x = x = ' '
    let is_newline x = x = '\n' || x = '\r'

    /// Reads a digit.
    /// char parser
    let digit (stream, on_succ, on_fail) state =
        stream_char ( 
            stream 
            ,fun x state' -> 
                if is_digit x then on_succ x state'
                else on_fail "digit" state
            ,on_fail
            ) state
            

    /// Reads an 64-bit integer parser.
    /// uint64 parser
    let puint64 (stream, on_succ, on_fail) state =
        let error state = on_fail "puint64" state
        let rec loop i on_fail state =
            digit (
                stream
                ,fun c state ->
                    let max = 1844674407370955161UL // max of uint64 / 10u64
                    if i <= max then
                        let i' = i * 10UL + System.Convert.ToUInt64 c - System.Convert.ToUInt64 '0'
                        if i < i' then loop i' on_succ state
                        else error state
                    else error state
                ,fun _ state -> on_fail i state
                ) state
        loop 0UL (fun _ state -> error state) state

    /// The skips an all the whitespaces (including newlines) before succeeding.
    /// unit parser
    let rec spaces (stream, on_succ, on_fail as d) state =
        stream_char (
            stream
            ,fun c state' -> 
                if is_whitespace c || is_newline c then spaces d state'
                else on_succ () state
            ,fun _ state -> on_succ () state
            ) state

    /// Runs the first and then the second parser before returning the result of the second parser.
    /// a parser -> b parser -> b parser
    let (>>.) a b (stream,on_succ,on_fail as d) state = a (stream,(fun _ state -> b d state), on_fail) state
    /// Runs the first and then the second parser before returning the result of the first parser.
    /// a parser -> b parser -> a parser
    let (.>>) a b (stream,on_succ,on_fail) state = 
        a (stream, (fun a state -> b (stream, (fun _ state -> on_succ a state),on_fail) state), on_fail) state

    /// Runs the tuple of parsers before returning their result.
    /// tuple parser
    /// Note: This one is ugly. It is impossible to make a generic tuple without great type hackery in F#. 
    /// Check out FParsec.Pipes library to see how that might be done.
    let tuple3 (a,b,c) (stream,on_succ,on_fail) =
        a (
            stream 
            ,fun a ->
                b (
                    stream
                    ,fun b ->
                        c (
                            stream
                            ,fun c ->
                                on_succ (a,b,c)
                            ,on_fail)
                    ,on_fail)
            ,on_fail)

    /// Parses an unsigned 64-bit integer and returns it after parsing whitespaces.
    /// uint64 parser
    let num = puint64 .>> spaces

    run "123 456 789" (tuple3 (num, num, num))
```

Here are the performance figures from testing the above two programs using the [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) library . What the above program is doing is merely parsing 3 unsigned 64-bit ints and returning them in a tuple.

```
           Method |       Mean |     Error |    StdDev |
----------------- |-----------:|----------:|----------:|
 FullySpecialized |   292.8 ns | 0.8448 ns | 0.7902 ns |
           FSharp | 3,616.2 ns | 8.9547 ns | 8.3762 ns |
```

The Spiral parser is about 12x times faster. That is quite a nice improvement and roughly what one could expect. The interesting thing not noted in the benchmark is that once the Spiral's output has been compiled to F# code, it runs instantaneously while in F#'s case, there is a noticeable delay while the .NET JIT tries to optimize it. Obviously, in Spiral's case the JIT does not have much work left for it. Apart from register allocation, Spiral already does everything else and does a better job if it finishes compiling.

If anything, the above understates the advantage that Spiral has over F#. Given how poor F# is at optimizing [monads](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/computation-expressions), for parsers written in a monadic style the author would not be surprised to see the gap widen by another 10x.

Nevertheless, one point in F#'s favor are compile times. The parser being tested here is somewhat trivial, but for a more complex parser such as the one for the Spiral compiler, the author would not be surprised to see it go up into 100s of thousands of lines of code. Given that the IDE gets crushed by the weight of a 20k LOC parser, it has him wondering how would he even compile such a monster? As a rule of the thumb, Spiral's evaluator generates around 3k LOC per second currently.

For that sake, rather than CPSing everything it would be important to do boxing. In the previous section on lists, it was shown how in Spiral, the CPS form of `head`,`tail` and `last` is just a more generic form of the one that uses the option type. Note that this is not the case in other functional languages as they lack Spiral's inlining guarantees.

There are two choices for doing boxing in Spiral and they are good to know in order to cut down on exceesive specialization and making sure the evaluator does not diverge.

1) Do term casting.

```
/// Term casting for parsers
/// a type -> a parser -> a parser
inl term_cast typ p {d with on_succ on_fail on_type} state =
    inl term_cast_uncurried g a b = // This is to make sure only one closure is allocated.
        inl g = term_cast (inl a, b -> g a b) (a,b)
        inl a b -> g (a,b)
    p {d with 
        on_succ = term_cast_uncurried on_succ typ state
        on_fail = term_cast_uncurried on_fail string state
        } state

inl puint64 d state = join puint64 d state // Make sure that the unrolled outer loop is rolled in.

/// Parses an unsigned 64-bit integer and returns it after parsing whitespaces.
/// uint64 parser
inl num = term_cast uint64 (puint64 .>> spaces)

run (uint64,uint64,uint64) "123 456 789" (tuple (num, num, num))
```

The amount of code generated drops down to 141 LOC with this. Unfortunately it does make the program slower by about 40%.

```
           Method |       Mean |     Error |    StdDev |
----------------- |-----------:|----------:|----------:|
       TermCasted |   406.6 ns | 1.2316 ns | 1.1520 ns |
 FullySpecialized |   292.8 ns | 0.8448 ns | 0.7902 ns |
           FSharp | 3,616.2 ns | 8.9547 ns | 8.3762 ns |
```

2) Box using union types.

```
inl ParserResult x state = .ParserSucc, x, state \/ .ParserFail, string, state

/// Union boxing for parsers
/// a type -> a parser -> a parser
inl box typ p {d with on_succ on_fail} state = 
    inl on_type = ParserResult typ state
    inl box = box on_type
    p {d with
        on_succ = inl x state -> box (.ParserSucc, x, state)
        on_fail = inl x state -> box (.ParserFail, x, state)
        on_type
        } state
    |> function
        | .ParserSucc, x, state -> on_succ x state
        | .ParserFail, x, state -> on_fail x state

inl puint64 d state = join puint64 d state // Make sure that the unrolled outer loop is rolled in.

/// Parses an unsigned 64-bit integer and returns it after parsing whitespaces.
/// uint64 parser
inl num = box uint64 (puint64 .>> spaces)

run (uint64,uint64,uint64) "123 456 789" (tuple (num, num, num))
```

This actually improves the running time significantly.

```
           Method |       Mean |     Error |    StdDev |
----------------- |-----------:|----------:|----------:|
       TermCasted |   406.6 ns | 1.2316 ns | 1.1520 ns |
             Boxy |   199.4 ns | 0.9976 ns | 0.9332 ns |
 FullySpecialized |   292.8 ns | 0.8448 ns | 0.7902 ns |
           FSharp | 3,616.2 ns | 8.9547 ns | 8.3762 ns |
```

The boxy parser is by far the best variant. It comes out to only 170 LOCs and is 45% faster than the fully specialized version and 18x times than the F# version. This also demonstrates that code duplication does have a noticeable performance impact. The lines of code reduced would be much more dramatic for a larger parser thereby making the application of this technique a necessity in a serious library. Currently the `Parsing` module in the standard library is lacking in that regard and the above benchmark is actually the first time the author used union type boxing on parsers or did benchmarking of a Spiral program. The `Parsing` module was not intented to be a serious parsing library, but to drive the development of the language in a challening area.

When the first version of it was created Spiral did not have modules nor monadic syntax nor good error messages, but it did have a lot of compiler bugs as if to make up for it. Spiral's modules were created in part because refactoring the parser was simply so painful during those days - it would take the author hours to fix the type errors that in F# would have taken him 10m. It is much better now thankfully.

As the author has no intention of doing so and wants to do machine learning instead, for those interested in parsing Spiral is a very good language to experiment with in the context of staged functional programming.

It will no doubt be a very productive language for such a purpose depending on how much weight is put on performance. If full weight is put on it then there is no doubt that Spiral would be orders of magnitute more productive at such a task than other languages.

The reason for that is that it is not enough to judge merely by how long would it take to write a parser, but how long would it take to get it on par with Spiral in performance. It took the author ~5h to make the parser for this benchmark in Spiral and then maybe 20m to transcribe it to F# by hand. In order to get to the Boxy level of performance, how long would it have taken to specialize all of that by hand and test it? Days?

Just how hard would such a fast handwritten C-style parser be to modify after that? It would be completely inflexible, so a decent guess is quite hard. It would also take a special kind of masochism to deliberately write code in such a style.

ML styled languages still have some advantages over Spiral due to having type inference which is a great aid to refactoring and explorability, but C offshots can be completely replaced with no regret.

The 4 parsers benchmarked in this section can be found in [this folder](https://github.com/mrakgr/The-Spiral-Language/tree/master/Benchmarking) of the repo.

### 5: Tensors and Structural Instrospection

The development of Spiral was driven by the need for a language with great capability for abstraction whose semantics would allow for it to be compiled to very fast code suitable for GPUs and the architectures coming down the line. During the early days of its development when it was intended as a Cuda backend for the ML library Spiral actually had built in arrays that would track variables at on the type level, but that tensors could be designed like the way they currently could be was beyond the imagination of its author and makes him glad that he decided to complete the language instead of leaving Spiral in a half finished state as a crappy ML library backend.

Tensors in Spiral represent the crystallization of its power; they are the point at which all of its features flow together to create something that cannot be done in any other language.

Unlike parsers of the previous chapter which were complicated - so complicated that they could not be explained, tensors are actually rather simple and intended for all ages.

The implementation of `HostTensor` in the standard library is somewhat convoluted due to needing to be generic in order to be reusable on the Cuda side in addition to having a lot of functionality, so this chapter will follow the format of giving a few examples of its most salient features and then show how a simpler tensor can be derived from first principles in order to attain understanding of it.

Tensors in Spiral can have an arbitrary number of dimensions, arbitrary types and arbitrary layouts in addition to supporting views. Indexing into them emulates the partial application of functions. `init` for them takes arguments in curried form which supports scope control.

*Note: The HostTensor module was greatly redesigned since this was last written so the examples won't compile anymore. This tutorial will be updated at some point to reflect this. The tensor does not longer support ranges, but instead it has been split into `Tensor` and `View`. `View` in particular supports both range views as shown here and named tree-based views which make certain optimization such as for the LSTM layer a lot safer and easier to implement.*

```
let example = 
    "example",[option;tuple;loops;extern_;console;host_tensor],"Module description.",
    """
inl ar = array_create string 3
Tuple.foldl (inl i x -> ar i <- x; i+1) 0 ("zero","one","two") |> ignore
HostTensor.init (3,5,{from=2; to=5}) (inl a ->
    inl x = ar a
    string_format "x is {0}" x |> Console.writeline
    inl b c -> x, b, c
    )
|> HostTensor.show.all
|> Console.writeline
    """
```

The generated code won't be posted as the loops for printing the tensors and initializing it are long, but here is what comes out when the program has been ran.

```
x is zero
x is one
x is two
[|
    [|
        [|[zero, 0, 2]; [zero, 0, 3]; [zero, 0, 4]; [zero, 0, 5]|]
        [|[zero, 1, 2]; [zero, 1, 3]; [zero, 1, 4]; [zero, 1, 5]|]
        [|[zero, 2, 2]; [zero, 2, 3]; [zero, 2, 4]; [zero, 2, 5]|]
        [|[zero, 3, 2]; [zero, 3, 3]; [zero, 3, 4]; [zero, 3, 5]|]
        [|[zero, 4, 2]; [zero, 4, 3]; [zero, 4, 4]; [zero, 4, 5]|]
    |]
    [|
        [|[one, 0, 2]; [one, 0, 3]; [one, 0, 4]; [one, 0, 5]|]
        [|[one, 1, 2]; [one, 1, 3]; [one, 1, 4]; [one, 1, 5]|]
        [|[one, 2, 2]; [one, 2, 3]; [one, 2, 4]; [one, 2, 5]|]
        [|[one, 3, 2]; [one, 3, 3]; [one, 3, 4]; [one, 3, 5]|]
        [|[one, 4, 2]; [one, 4, 3]; [one, 4, 4]; [one, 4, 5]|]
    |]
    [|
        [|[two, 0, 2]; [two, 0, 3]; [two, 0, 4]; [two, 0, 5]|]
        [|[two, 1, 2]; [two, 1, 3]; [two, 1, 4]; [two, 1, 5]|]
        [|[two, 2, 2]; [two, 2, 3]; [two, 2, 4]; [two, 2, 5]|]
        [|[two, 3, 2]; [two, 3, 3]; [two, 3, 4]; [two, 3, 5]|]
        [|[two, 4, 2]; [two, 4, 3]; [two, 4, 4]; [two, 4, 5]|]
    |]
|]
```
Having the arguments to `init` be partially applied rather than given all at once is what allow the outside array to be indexed only in the outer loop. Had it been otherwise, the indexing would have needed to be done inside the innermost loop. `init` gives loops for free. Important operations such as map, rotation and reduction can be implemented in terms of init on the host (CPU) side.

Tensors themselves emulate partial application of functions. Here is how they can be indexed into.

```
inl ar = array_create string 3
Tuple.foldl (inl i x -> ar i <- x; i+1) 0 ("zero","one","two") |> ignore
inl tns = HostTensor.init (3,5,{from=2; to=5}) (inl a ->
    inl x = ar a
    inl b c -> x, b, c
    )
inl f x = x 0 2 .get
tns 0 |> f |> Console.writeline
tns 1 |> f |> Console.writeline
tns 2 |> f |> Console.writeline
```
```
[zero, 0, 2]
[one, 0, 2]
[two, 0, 2]
```

This is convenient for views. Views can take more than a single argument in which case they need to be passed as a tuple. Like application, views work on dimensions from left to right - from the outermost to the innermost.

```
inl ar = array_create string 3
Tuple.foldl (inl i x -> ar i <- x; i+1) 0 ("zero","one","two") |> ignore
inl tns = HostTensor.init (3,5,{from=2; to=5}) (inl a ->
    inl x = ar a
    inl b c -> x, b, c
    )

tns.view (1,{from=2;near_to=4})
|> HostTensor.show.all
|> Console.writeline
```
```
[|
    [|
        [|[zero, 2, 2]; [zero, 2, 3]; [zero, 2, 4]; [zero, 2, 5]|]
        [|[zero, 3, 2]; [zero, 3, 3]; [zero, 3, 4]; [zero, 3, 5]|]
    |]
|]
```
Both the tensor applications and views are done done immutably. Apart from join points which are memoized, Spiral's metalanguage is pure and there is no way of mutably updating tuples or modules.

For the sake of demonstration, here is how `.set` works. It is very similar to `.get`.

```
inl tns = HostTensor.init ({from=2; near_to=5}) id
inl modify f t = t .set (t .get |> f)
tns 2 |> modify ((*) 2)
tns 3 |> modify ((+) 22)
tns 4 |> modify (const -11)

HostTensor.show.all tns
|> Console.writeline
```
```
[|4; 25; -11|]
```
In addition to `.view`, `.view_span` is useful.
```
inl tns_a = HostTensor.init ({from=2; near_to=10}) id

HostTensor.show.all tns_a
|> string_format "tns_a = {0}"
|> Console.write

inl tns_b = tns_a.view_span {from=0;near_to=2}
HostTensor.show.all tns_b
|> string_format "tns_b = {0}"
|> Console.write

inl tns_c = tns_a.view_span {from=2;near_to=4}
HostTensor.show.all tns_c
|> string_format "tns_c = {0}"
|> Console.write

tns_c 0 .get |> Console.writeline
tns_c 1 .get |> Console.writeline
//tns_c 2 .get |> Console.writeline // Would trigger the range check assertion at compile time.
```
```
tns_a = [|2; 3; 4; 5; 6; 7; 8; 9|]
tns_b = [|2; 3|]
tns_c = [|4; 5|]
4
5
```
`.view_span` is similar to view except starts the indexing from the beginning of the dimensions of the target tensor and rebases the dimensions so they start from 0. That means that `.view_span -1` would always be an out of bounds error as would all negative values of the index. Given how Spiral specializes join points, it is useful for avoiding code bloat as well.

For the sake of machine learning, it is preferable to keep the tensor sizes as constants to get rid of as many assertion at compile time as possible. Note that in the last line, had it not been commented out the compiler would have raised a type error at compile time.

Tensors have even more to offer. By default, their layout is that of tuple of arrays. Meaning a tuple of type `float32 * int64 * int64` would be represented using 3 arrays internally each for the separate elements of the tuple. The main motivation behind this design is to make it easy to pass them through language boundaries onto the Cuda side as unless the arrays were of primitive types, it would be difficult to align them in memory, but there are performance benefits as well to allowing such a representation.

That varies from problem to problem, so it would be even better if it was easy to switch between representations at will.

```
inl tns_toa = HostTensor.init (5,5) (inl a b -> a,b)
inl tns_aot = HostTensor.init.aot (5,5) (inl a b -> tns_toa a b .get)
()
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
...
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(25L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(25L))
let (var_2: int64) = 0L
method_0((var_0: (int64 [])), (var_1: (int64 [])), (var_2: int64))
let (var_5: (Tuple0 [])) = Array.zeroCreate<Tuple0> (System.Convert.ToInt32(25L))
let (var_6: int64) = 0L
method_2((var_0: (int64 [])), (var_1: (int64 [])), (var_5: (Tuple0 [])), (var_6: int64))
```

The full thing won't be posted as it is 100 LOC, but it should be imaginable that `method_0` is `init` for `tns_toa` and `method_2` is `init` for `tns_aot`. Spiral's tensors are the perfect abstraction where layouts are concerned and it is possible to mix and match `.aot` and `.toa` layout using the `zip` function and it will still work fine. For most usecases, the default tuple of arrays is sensible.

Saying tuple of arrays does not cover it completely though. The tensors work fine with modules.

```
inl a = HostTensor.init (3,3) (inl a b -> {a b})
a 2 2 .set {a=99}
HostTensor.show a
|> Console.writeline
```
```
[|
    [|{a = 0; b = 0}; {a = 0; b = 1}; {a = 0; b = 2}|]
    [|{a = 1; b = 0}; {a = 1; b = 1}; {a = 1; b = 2}|]
    [|{a = 2; b = 0}; {a = 2; b = 1}; {a = 99; b = 2}|]
|]
```

When tensor are in `toa` form they have the added feature of allowing the module fields to be mutated individually. This is not possible in general in Spiral as modules and tuples are immutable; if they were represented as `aot` or if the modules were tuples this would not be possible. What is going on is that when they are represented as separate entities this changes their semantics to reflect that and this is the correct behavior even in a functional language.

This is the short tour of the tensors in Spiral. The next section will be on how they are implemented.

#### Under the Hood

As was demonstrated, there are two aspects of tensor polymorphism - one was that they have an arbitrary number of dimensions and the other was that are layout polymorphic. In a language with weaker type systems that would require creating specific tensor instances for both of those concerns, but Spiral can handle them naturally.

Even better, the dimensionality of the tensor is really a separate concern from its layout and so the two subjects can be taken in as separate pieces.

##### Layout Polymorphism

Creating an array of `int64 * int64 * int64` can be done like this in Spiral.

```
array_create (int64,int64,int64) 8
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
Array.zeroCreate<Tuple0> (System.Convert.ToInt32(8L))
```

The above is also known as `aot` or `array of tuples` form. The opposite of it, the `toa` or `tuple of arrays` form would be this.

```
inl ar = array_create int64 8, array_create int64 8, array_create int64 8
()
```
```
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
```

Rather than copy pasting like, it would be better if the type were mapped directly.

```
inl ar = Tuple.map (inl x -> array_create x 8) (int64,int64,int64)
()
```
```
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
```

The same output as in the above example shows up. By now, the general principle of how Spiral's tensors achieve their layout polymorphism should be becoming clearer. Of course, the above is woefully incomplete. For example, if the tuple were nested then the `toa` layout would not be achieved.

```
inl ar = Tuple.map (inl x -> array_create x 8) (int64,(int64,int64))
()
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_1: (Tuple0 [])) = Array.zeroCreate<Tuple0> (System.Convert.ToInt32(8L))
```

What should be done is to write a function capable mapping over nested tuples.

```
inl rec toa_map f = function
    | x :: x' -> toa_map f x :: toa_map f x'
    | () -> ()
    | x -> f x

inl ar = toa_map (inl x -> array_create x 8) (int64,(int64,int64))
()
```
```
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
```

Note the subtle difference between `toa_map` and a regular `map`. In `| x :: x' -> toa_map f x :: toa_map f x'` the function recurses on `x` as well, not just on the tail.

For modules, a little extra is needed in `toa_map`.

```
inl toa_map f =
    inl rec loop = function
        | x :: x' -> loop x :: loop x'
        | () -> ()
        | {} as x -> module_map (const loop) x
        | x -> f x
    loop

inl ar = toa_map (inl x -> array_create x 8) {x=int64; y=int64,int64}
()
```
```
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
```

Before the function is complete there are two more things needed. That would be to stop the function from unboxing every union type and to stop it from recursing on every module. This last one is more of a convenience than necessity.

```
inl toa_map f =
    inl rec loop = function
        | x when caseable_box_is x -> f x // This needs to be in the first position to prevent the unboxing from triggering.
        | x :: x' -> loop x :: loop x'
        | () -> ()
        | {!toa_map_block} & x -> module_map (const loop) x
        | x -> f x
    loop

inl ar = toa_map (inl x -> array_create x 8) {x=int64; y=int64,int64; o=Option.Option float32}
()
```
```
type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: float32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let (var_0: (Union0 [])) = Array.zeroCreate<Union0> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_3: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
```

With this as the basis, it is easy to make a `toa` version of array create.

```
inl toa_array_create typ size = toa_map (inl x -> array_create x size) typ
```

Indexing into such an array is quite similar to creating it. It is just a straightforward application of `toa_map`.

```
inl toa_index ar idx = toa_map (inl ar -> ar idx) ar

inl ar = toa_array_create {x=int64; y=int64,int64; o=Option.Option float32} 8
inl el = toa_index ar 0
()
```
```
type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: float32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let (var_0: (Union0 [])) = Array.zeroCreate<Union0> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_3: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_4: Union0) = var_0.[int32 0L]
let (var_5: int64) = var_1.[int32 0L]
let (var_6: int64) = var_2.[int32 0L]
let (var_7: int64) = var_3.[int32 0L]
```

Setting such an array is a bit more difficult. In order to do that, `toa_map2` would be needed first.

```
inl toa_map2 f a b =
    inl rec loop = function
        | x, y when caseable_box_is x || caseable_box_is y -> f x y
        | x :: x', y :: y' -> loop (x,y) :: loop (x',y')
        | (), () -> ()
        | (), _ | _, () -> error_type "Tuple dimensions do not match."
        | {!toa_map_block} & x, {!toa_map_block} & y -> module_map (inl k y -> loop (x k, y)) y
        | x, y -> f x y
    loop (a,b)
```

With this it is possible to implement `toa_set`.

```
inl toa_set ar idx v = toa_map2 (inl ar v -> ar idx <- v) ar v |> ignore

inl ar = toa_array_create {x=int64; y=int64,int64; o=Option.Option float32} 8
toa_set ar 0 {x=2; y=1,1; o=Option.some 2.2f32}
()
```
```
type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: float32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let (var_0: (Union0 [])) = Array.zeroCreate<Union0> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_3: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
var_0.[int32 0L] <- (Union0Case0(Tuple1(2.200000f)))
var_1.[int32 0L] <- 2L
var_2.[int32 0L] <- 1L
var_3.[int32 0L] <- 1L
```

There is an interesting design decision of whether to allow partial setting of fields in modules in `toa_map2`.

```
| {!toa_map_block} & x, {!toa_map_block} & y -> module_map (inl k y -> loop (x k, y)) y
```

The above particular line could have also been written like so.

```
| {!toa_map_block} & x, {!toa_map_block} & y -> module_map (inl k x -> loop (x, y k)) x
```

Doing it like that would have disallowed the partial module sets as the map would have gone through every field of the `toa` array instead of every field of the setter.

In this section the way to make layout polymorphic arrays was described and is how Spiral's tensors attain such a capability. The ability to reflect on the structure of everything in the language at no runtime cost is a powerful one and solves a lot of the issues currently facing persons writing numerical libraries. It also covers an aspect of polymorphism that parametric languages do not touch.

The next section will be on how to take what has been done so far and make the 1d `toa` array, a tensor capable of support arbitrary dimensions.

##### Dimensionality Polymorphism

In one of the previous chapters, it was mentioned that Spiral is not necessarily less typesafe than F#, and that in some cases the opposite is in fact the case. Whenever dynamism and therefore union types are needed, a step is made into an entirely different paradigm for languages with weaker type systems due to have to push typechecking to runtime.

```
List.take 5 [1;2;3] // An error at runtime.
```
```
Tuple.take 5 (1,2,3) // An error at compile time.
```

This comparison might seem unfair since lists in F# are explicitly runtime constructs, but that is in fact the point. Spiral's parent language as it stands now does not have any substitute for Spiral's tuples at all and has absolutely no way of making tensors arbitrary in their dimensions at compile time. All it can do is support very specific instances of them.

So back when the author was making the ML library in F#, he had `d2M` for a 2D GPU tensor, and `d4M` for 4d GPU tensors. Afterwards he found the need for a 3d tensor so he made `d3M` too and so on. There was the `Df`, a lazy scalar host tensor as well.

Layout polymorphism? Forget that. The best what was possible was having them be generic in their type.

Now, there is no doubt that making a very specific instance of a tensor (such as `d2M`) is easier than making a fully blown generic tensor, but making such a tensor type is definitely easier than having to make a specific instance for all the endless varieties of tensors. Making specific instances of the more generic type by hand gets tiresome really quickly. It is humiliating to have to use personal effort because the tool one is using is not good enough.

###### Design of the Tensor

```
{
    bodies = { ar size offset toa_map_block } structure
    dim
}
```

The above is very similar to the type of the Spiral's `HostTensor` in pseudo-code. It is actually one of its previous designs that is easier to explain as it has a more uniform structure. 

In it, `dim` is just the dimension of the tensor and might be `(2,3,4)` for a 3d tensor, `(10,20)` for a 2d tensor or `()` for a scalar tensor for example.

`size` and `offset` inside the `bodies` are directly related to it. Elements of `offset` are always to be multiples of their related `size` element.

Before the coding can start, some simple examples need to be gone though by hand so that it becomes clear what is trying to be done in the first place.

1) On tensor creation.

```
/// Creating a 1d tensor of type int64 and dim 10
inl dim = 10
inl ar = array_create int64 dim
inl tns = {
    bodies = {
        ar
        size = Tuple.singleton 1
        offset = Tuple.singleton 0
        toa_map_block = ()
        }
    dim = Tuple.singleton dim
    }
```
```
/// Creating a 2d tensor of type int64 and dim 10, 10
inl dim = 10, 10
inl ar = array_create int64 (10 * 10)
inl tns = {
    bodies = {
        ar
        size = 10, 1
        offset = 0, 0
        toa_map_block = ()
        }
    dim
    }
```
```
/// Creating a 3d tensor of type int64 and dim 10, 5, 5
inl dim = 10, 5, 5
inl ar = array_create int64 (10 * 5 * 5)
inl tns = {
    bodies = {
        ar
        size = 5*5, 5, 1
        offset = 0, 0, 0
        toa_map_block = ()
        }
    dim
    }
```

By now some patterns should be coming out. `ar` is always inserted directly into the tensor body, `size` is just the rightwards [scan product](https://stackoverflow.com/questions/23491216/f-cumulative-product-of-an-array) of `dim`, `offset` is always `dim` mapped to 0, and `dim` is always itself. The only difference is 1d when `size`, `offset` and `dim` are wrapped in a tuple.

```
/// Creating a nd tensor in the array of tuples layout.
inl tensor_aot_create typ dim =
    inl dim = match dim with _ :: _ -> dim | x -> x :: ()
    inl array_size :: size = Tuple.scanr (*) dim 1
    inl offset = Tuple.map (const 0) dim
    {
    bodies = {
        ar = array_create typ array_size
        size offset
        toa_map_block=()
        }
    dim
    }
```

Here is the pattern abstracted and codified. The tuple of arrays version is similar to the above.

```
/// Creating a nd tensor in the tuple of arrays layout.
inl tensor_toa_create typ dim =
    inl dim = match dim with _ :: _ -> dim | x -> x :: ()
    inl array_size :: size = Tuple.scanr (*) dim 1
    inl offset = Tuple.map (const 0) dim
    inl make_body typ = {
        toa_map_block=()
        ar = array_create typ array_size
        size offset
        }
    {
    bodies = toa_map make_body typ            
    dim
    }
```

The two functions have a very similar internal structure. It can be factored out like so.

```
/// Creating a nd tensor
inl tensor_create {dsc with typ dim} =
    inl dim = match dim with _ :: _ -> dim | x -> x :: ()
    inl array_size :: size = Tuple.scanr (*) dim 1
    inl offset = Tuple.map (const 0) dim
    inl make_body typ = {
        toa_map_block=()
        ar = array_create typ array_size
        size offset
        }
    {
    bodies = 
        match dsc with
        | {layout=x} -> 
            match x with
            | .aot -> make_body typ
            | .toa -> toa_map make_body typ
        | _ -> toa_map make_body typ
    dim
    }
```

The beautiful thing about this is that since all the sizes are known, Spiral can track them at compile time.

```
inl tns = tensor_create {typ=int64,string,float32; dim=10,5,5}
()
```
```
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(250L))
let (var_1: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(250L))
let (var_2: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(250L))
```

Unless the tensor is returned from a join point, or a dynamic if statement, or put into an array, those fields will never be instantiated due being tracked at the type level and the tensor will have the very minimal overhead at runtime.

Spiral's `HostTensor` actually tracks lower and upper bounds in `dim` as well, but that won't be done for this tutorial.

2) On application.

```
{
bodies = {
    ar
    size = 25, 5, 1
    offset = 0, 0, 0
    toa_map_block = ()
    }
dim = 10, 5, 5
}
```

For the purpose of explanation, the 3d tensor from the previous example will be the starting point.

How should applying 2 to the tensor transform it?

It should be into this 2d tensor.

```
{
bodies = {
    ar
    size = 5, 1
    offset = 25*2 + 0, 0 // 50
    toa_map_block = ()
    }
dim = 5, 5
}
```

Applying 3 to the above should turn it into this.

```
{
bodies = {
    ar
    size = 1 :: ()
    offset = 25*2 + 5*3 + 0 :: () // 65
    toa_map_block = ()
    }
dim = 5 :: ()
}
```

Now that it is has been applied twice, the resulting tensor has gone from 3d to 1d. Once more and it will be scalar. Here is simulating the application of 4.

```
{
bodies = {
    ar
    size = ()
    offset = 25*2 + 5*3 + 1*4 // 69
    toa_map_block = ()
    }
dim = ()
}
```

Note how now the offset it a scalar and can be used to index into an array. The rules of tensors are quite simple, only 0d (scalar) tensors can be indexed and set and cannot be applied, while the opposite holds for tensors with higher number of dimensions.

Also note that `dim` plays no role in calculating the top of the new offset.

What was omitted in the above example is the boundary checking. If the value being applied was out of range that would have triggered an error.

Here is the above intuition in code.

```
inl tensor_apply i {dim=d::dim bodies} =
    assert (i >= 0 && i < d) "Tensor application out of bounds"

    {
    dim
    bodies = 
        toa_map (inl {d with size=s::size offset=o::offset} ->
            inl o = o + i * s
            inl offset = 
                match offset with
                | o' :: offset -> o + o' :: offset
                | () -> o
            {d with size offset}
            ) bodies
    }
```

The `| o' :: offset -> o + o' :: offset` might be surprising, but that is needed because the offsets might not be zero and that should not be thrown away. That can happen in tensors whose inner dimensions were viewed.

```
inl tns = tensor_create {typ=int64,string,float32; dim=10,5,5}
tensor_apply 2 tns
|> tensor_apply 3
|> tensor_apply 4
```
```
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(250L))
let (var_1: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(250L))
let (var_2: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(250L))
(Env4(Tuple3((Env0(var_0, 69L)), (Env1(var_1, 69L)), (Env2(var_2, 69L)))))
```

The types were cut out in the above generated code. As can be seen since scalar tensors have only their offset and an array that is what gets printed. 

```
inl tns = 
    tensor_create {typ=int64,string,float32; dim=10,5,5}
    |> tensor_apply (dyn 2)
    |> tensor_apply 3
    |> tensor_apply 4
join tns
```
```
let rec method_0((var_0: (int64 [])), (var_1: int64), (var_2: (string [])), (var_3: (float32 []))): Env0 =
    (Env0(Tuple4((Env1(var_0, var_1)), (Env2(var_2, var_1)), (Env3(var_3, var_1)))))
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(250L))
let (var_1: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(250L))
let (var_2: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(250L))
let (var_3: int64) = 2L
let (var_4: bool) = (var_3 >= 0L)
let (var_6: bool) =
    if var_4 then
        (var_3 < 10L)
    else
        false
let (var_7: bool) = (var_6 = false)
if var_7 then
    (failwith "Tensor application out of bounds")
else
    ()
let (var_8: int64) = (var_3 * 25L) // 50
let (var_9: int64) = (var_8 + 15L) // 65
let (var_10: int64) = (var_9 + 4L) // 69
method_0((var_0: (int64 [])), (var_10: int64), (var_1: (string [])), (var_2: (float32 [])))
```

In the above example the first application was `dyn`ed. This makes the assertion check necessary at runtime, but the line of note is the last one. Due to common subexpression rewriting, in the end all the bodies end up with the same index variable.

This will be reflected when they are being passed through join points. 

```
met f (a,b,c) = a+b+c
inl x = dyn 3
f (x,x,x)
```
```
let rec method_0((var_0: int64)): int64 =
    let (var_1: int64) = (var_0 + var_0)
    (var_1 + var_0)
let (var_0: int64) = 3L
method_0((var_0: int64))
```

The moral of that is - for efficiency tensors should not be returned from anything apart from inlineables and should not be stored into arrays. Spiral's natural style is towards continuation passing and (mostly) functional purity. Tuples and modules should be used to store arguments whenever possible and opaque structures should be avoided.

3) On indexing and setting.

These two are easy since all the hard work has already been done by `tensor_apply`.

```
inl tensor_index {bodies dim=()} = toa_map (inl {ar offset} -> ar offset) bodies
inl tensor_set {bodies dim=()} v = toa_map2 (inl {ar offset} v -> ar offset <- v) bodies v |> ignore

inl tns = 
    tensor_create {typ=int64,string,float32; dim=10,5,5}
    |> tensor_apply 2
    |> tensor_apply 3
    |> tensor_apply 4

tensor_set tns (1,"asd",3.3f32)
```
```
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(250L))
let (var_1: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(250L))
let (var_2: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(250L))
var_0.[int32 69L] <- 1L
var_1.[int32 69L] <- "asd"
var_2.[int32 69L] <- 3.300000f
```

Here is the `aot` form for good measure.

```
inl tns = 
    tensor_create {layout=.aot; typ=int64,string,float32; dim=10,5,5}
    |> tensor_apply 2
    |> tensor_apply 3
    |> tensor_apply 4

tensor_set tns (1,"asd",3.3f32)
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: string
    val mem_2: float32
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
let (var_0: (Tuple0 [])) = Array.zeroCreate<Tuple0> (System.Convert.ToInt32(250L))
var_0.[int32 69L] <- Tuple0(1L, "asd", 3.300000f)
```
###### The Tensor Facade

Now that is is possible to create, apply, index and set the tensors the thing that remains is to make it applicable directly. To that, what is needed is to make a facade. The only thing of note in the following is that on standard application the facade rewraps itself. The rest should be straightforward.

```
inl rec tensor_facade tns = function
    | .get -> tensor_get tns
    | .set v -> tensor_set tns v
    | .(_) & x -> tns x
    | x -> tensor_apply x tns |> tensor_facade

inl tensor_create = tensor_create >> tensor_facade

inl tns = tensor_create {layout=.aot; typ=int64,string,float32; dim=10,5,5} 
tns 2 3 4 .set (1,"asd",3.3f32)
```
```
type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: string
    val mem_2: float32
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
let (var_0: (Tuple0 [])) = Array.zeroCreate<Tuple0> (System.Convert.ToInt32(250L))
var_0.[int32 69L] <- Tuple0(1L, "asd", 3.300000f)
```

#### Closing Comments

Views on tensors are similar to apply and just push the offsets without reducing the dimensionality of the tensor. It won't be covered in the tutorial and the interested should just look into the standard library implementation of them for specific details.

There is an interesting programming lesson that the author (re)experienced while making the tensor tutorial. Near the beginning there was a comment that the tensor design for the tutorial is more uniform than the one in the standard library. It is actually even more than that. The way it has been designed here is in fact how the author remembered the tensor. He knew it was not like this in the standard library, but when he looked he was actually surprised at how it was made indicating that he in fact forgot about it.

It is not the first time it happened that a piece poorly fit into memory to him and won't be the last. Memory mismatches are a sure sign that a particular piece of software should be redesigned. Having been left alone for a while, all but the most salient features of a program faded from memory indicating that in fact the rest are worthless and should be removed. Once he is done with the documentation that will surely be done.

With this all that has needed to be said in order to understand tensors has been said, but a digression needs to be made to highlight just how great they really are.

The tensor tutorial should have been rather clear and straightforward and unless something has badly gone wrong, those reading this chapter should have a clear picture of their essence.

The number of languages in which a tensor can be implemented in such a manner can at the time of writing, 2 days to 2018, be literally counted on one finger. Being able to implement tensors like this is what essentially convinced the author that now that he has Spiral, it might be a good idea challenge the other deep learning frameworks for supremacy even though they have big corporate sponsorship.

Even in language like Julia which is made for numeric computation such generic functionality would require heavy use of macros. The kind of metaprogramming Julia allows could be a lot worse.

Take PyTorch for instance, and go to the [tour of its internals](http://pytorch.org/blog/). It is essentially a tour of poor programming practices: using C macros for everything including making tensors type generic, the absolutely fearsome `static PyTypeObject py_FloatType` which is badly in need of modules or at least SML records, the friction between different components that just jumps out.

From what has been heard of PyTorch in action by the author, there has been nothing but praise.

Nevertheless, if the best tools for the job in 2018 for making tensors generic are the 1972 C macros then probably something went wrong somewhere and not just with PyTorch specifically.

Whether it be composability or performance or lack of safety, those kinds of problems exist due to the weak type systems. But it is not like type systems have to be just about solving constraints, nor do they have to be segregated from the rest of the compiler passes. Lisps had the great idea of integrating parsing with the rest of compilation passes. There is nothing preventing similar to be done with a type system.

Once that fusion is done, a piece of the power that is released can be seen in this chapter - a properly done tensor type.

### 6: The Cuda Backend

This section covers how the Cuda backend works in its entirety and is not mandatory for understanding how to program in Spiral. It can be skipped over. It does not cover GPU programming, but instead goes into some depth on what is going on under the hood when Spiral does GPU compilation.

#### Intro

After a successful compilation of a Spiral program, at the top of the file there is a `let cuda_kernel = ...` statement. When no GPU code is run, that results in an empty string, but otherwise there will be code there.

```
let kernel1 =
    "kernel1",[cuda_modules],"Does the map kernel work?",
    """
/// Initializes all the Cuda parts
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

/// Creates a host tensor with the given generator function.
inl h = HostTensor.init 32 (inl x -> x + 1) 
/// Loads the tensor on the GPU based on the host tensor
inl a1 = s.CudaTensor.from_host_tensor h
/// Makes a tensor of the same type and dimensions as `a1` and zeroes it.
inl o1 = s.CudaTensor.zero_like a1
/// Calls the map operation. `a1` is the input and `o1` is the output.
s.CudaKernel.map' (inl a _ -> a * 2) a1 o1

/// Transfers the tensor back to host.
inl a2 = s.CudaTensor.to_host_tensor o1
/// Zips the two tensors and prints them out.
HostTensor.zip (h,a2) |> HostTensor.show |> Console.writeline
    """
```

```
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_23(long long int * var_0, long long int * var_1);
    __device__ char method_24(long long int * var_0);
    
    __global__ void method_23(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_24(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 32);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 32);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = var_0[var_8];
            long long int var_17 = var_1[var_8];
            long long int var_18 = (var_16 * 2); // The actual work is done on this line.
            var_1[var_8] = var_18;
            long long int var_19 = (var_8 + 128);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __device__ char method_24(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 32);
    }
}
"""
```

What is shown above is a map kernel that multiplies all the elements of a tensor by 2. In the kernel there are a bunch of inactive range checks that can be turned on with a compiler switch.

Here is the output of the above program at runtime.

```
[|[1, 2]; [2, 4]; [3, 6]; [4, 8]; [5, 10]; [6, 12]; [7, 14]; [8, 16]; [9, 18]; [10, 20]; [11, 22]; [12, 24]; [13, 26]; [14, 28]; [15, 30]; [16, 32]; [17, 34]; [18, 36]; [19, 38]; [20, 40]; [21, 42]; [22, 44]; [23, 46]; [24, 48]; [25, 50]; [26, 52]; [27, 54]; [28, 56]; [29, 58]; [30, 60]; [31, 62]; [32, 64]|]
```

#### How Cuda Kernels Are Compiled

At runtime, the program takes everything in the `cuda_kernels` variable and writes them to disk into the `cuda_kernels.cu` file which is located in the same place as the executable. It also creates a little batch script called `nvcc_router.bat`. Here are its contents. The paths are those provided by the `cfg` argument to the Spiral compiler directly.

```
SETLOCAL
CALL "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community\VC/Auxiliary/Build/vcvarsall.bat" x64 -vcvars_ver=14.11
SET PATH=%PATH%;"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community\VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64"
"C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0\bin/nvcc.exe" -gencode=arch=compute_52,code=\"sm_52,compute_52\" --use-local-env --cl-version 2017 -I"C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0\include" -I"C:/cub-1.7.4" -I"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community\VC/Tools/MSVC/14.11.25503/include" --keep-dir "C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\bin\Release" -maxrregcount=0  --machine 64 -ptx -cudart static  -o "C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\bin\Release\cuda_kernels.ptx" "C:\Users\Marko\Source\Repos\The Spiral Language\Temporary\bin\Release\cuda_kernels.cu"
```

What this does is do some setting up and then calls NVCC (The Nvidia Cuda compiler) from the command line.

It compiles the `cuda_kernels.cu` into `cuda_kernels.ptx` which is the LLVM IR assembly Cuda natively uses. It is not the actual assembly for the GPU, but an intermediate representation that various Cuda API functions use. Here is the output of the map kernel example just for show.

```
//
// Generated by NVIDIA NVVM Compiler
//
// Compiler Build ID: CL-22781540
// Cuda compilation tools, release 9.0, V9.0.176
// Based on LLVM 3.4svn
//

.version 6.0
.target sm_52
.address_size 64

	// .globl	method_23
.global .align 1 .b8 _ZN69_INTERNAL_47_tmpxft_000171e4_00000000_7_cuda_kernels_cpp1_ii_b5c879af6thrust6system6detail10sequential3seqE[1];

.visible .entry method_23(
	.param .u64 method_23_param_0,
	.param .u64 method_23_param_1
)
{
	.reg .pred 	%p<3>;
	.reg .b32 	%r<3>;
	.reg .b64 	%rd<25>;


	ld.param.u64 	%rd10, [method_23_param_0];
	ld.param.u64 	%rd11, [method_23_param_1];
	mov.u32 	%r1, %tid.x;
	cvt.u64.u32	%rd12, %r1;
	mov.u32 	%r2, %ctaid.x;
	mul.wide.u32 	%rd13, %r2, 128;
	add.s64 	%rd24, %rd13, %rd12;
	setp.gt.s64	%p1, %rd24, 31;
	@%p1 bra 	BB0_3;

	cvta.to.global.u64 	%rd14, %rd11;
	cvta.to.global.u64 	%rd15, %rd10;
	add.s64 	%rd18, %rd13, %rd12;
	shl.b64 	%rd19, %rd18, 3;
	add.s64 	%rd23, %rd15, %rd19;
	add.s64 	%rd22, %rd14, %rd19;

BB0_2:
	ld.global.u64 	%rd20, [%rd23];
	shl.b64 	%rd21, %rd20, 1;
	st.global.u64 	[%rd22], %rd21;
	add.s64 	%rd23, %rd23, 1024;
	add.s64 	%rd22, %rd22, 1024;
	add.s64 	%rd24, %rd24, 128;
	setp.lt.s64	%p2, %rd24, 32;
	@%p2 bra 	BB0_2;

BB0_3:
	ret;
}

	// .globl	_ZN3cub11EmptyKernelIvEEvv
.visible .entry _ZN3cub11EmptyKernelIvEEvv(

)
{



	ret;
}
```

As can be seen, the useless range checks got eliminated. And the multiply by two is converted into a left shift.

```
	ld.global.u64 	%rd20, [%rd23];
	shl.b64 	%rd21, %rd20, 1;
	st.global.u64 	[%rd22], %rd21;
```

This is the meat of the loop where it loads from global memory, multiplies by 2 and then stores after that. The rest is setting up the kernel and implementing the loop.

What can be done with the `.ptx` file is load the kernels inside them using the [Cuda API functions](http://docs.nvidia.com/cuda/cuda-driver-api/group__CUDA__MODULE.html#group__CUDA__MODULE) accessed through the [ManagedCuda wrapper library](https://github.com/kunzmi/managedCuda).

#### Tour Of The Standard Library Cuda Module

The `Cuda` module is where the context is initialized and where the `run` function that actually launches the kernels resides. The kernel compilation to `.ptx` happens at runtime. It will be shown here in its entirety, but there is no need to think too deeply about what is going on. It is garden variety plumbing that can be summed in a sentence or two for each part.

```
let cuda =
    (
    "Cuda",[loops;console;array;host_tensor;extern_;object],"The Cuda module.",
    """
inl ret -> 
    open Extern
    open Console

    inl cuda_kernels = FS.Constant.cuda_kernels string

    inl cuda_constant a t = !MacroCuda(t,[text: a])

    inl cuda_constant_int constant () = cuda_constant constant int64

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
    use context = FS.Constructor context_type false
    FS.Method context .Synchronize() ()
```

The only piece of functionality that happens at runtime are the last two lines where the Cuda context is created and then synchronized. The rest are merely definitions set up for later.

```
    inl compile_kernel_using_nvcc_bat_router (kernels_dir: string) =
        inl path_type = fs [text: "System.IO.Path"]
        inl combine x = FS.StaticMethod path_type .Combine x string
    
        inl file_type = fs [text: "System.IO.File"]
        inl stream_type = fs [text: "System.IO.Stream"]
        inl streamwriter_type = fs [text: "System.IO.StreamWriter"]
        inl process_start_info_type = fs [text: "System.Diagnostics.ProcessStartInfo"]
    
        inl nvcc_router_path = combine (kernels_dir,"nvcc_router.bat")
        inl procStartInfo = FS.Constructor process_start_info_type ()
        FS.Method procStartInfo .set_RedirectStandardOutput true ()
        FS.Method procStartInfo .set_RedirectStandardError true ()
        FS.Method procStartInfo .set_UseShellExecute false ()
        FS.Method procStartInfo .set_FileName nvcc_router_path ()

        inl process_type = fs [text: "System.Diagnostics.Process"]
        use process = FS.Constructor process_type ()
        FS.Method process .set_StartInfo procStartInfo ()
        inl print_to_standard_output = 
            closure_of (inl args -> FS.Method args .get_Data() string |> writeline) 
                (fs [text: "System.Diagnostics.DataReceivedEventArgs"] => ())

        FS.Method process ."OutputDataReceived.Add" print_to_standard_output ()
        FS.Method process ."ErrorDataReceived.Add" print_to_standard_output ()

        inl concat = string_concat ""
        inl (+) a b = concat (a, b)

        /// Puts quotes around the string.
        inl quote x = ("\"",x,"\"")
        inl vc_vars_args = " x64 -vcvars_ver=14.11"
        inl quoted_vs_path_to_vcvars = combine(visual_studio_path, "VC/Auxiliary/Build/vcvarsall.bat") |> quote
        inl quoted_vs_path_to_cl = combine(visual_studio_path, "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64") |> quote
        inl quoted_cuda_toolkit_path_to_include = combine(cuda_toolkit_path,"include") |> quote
        inl quoted_vc_path_to_include = combine(visual_studio_path, "VC/Tools/MSVC/14.11.25503/include") |> quote
        inl quoted_nvcc_path = combine(cuda_toolkit_path,@"bin/nvcc.exe") |> quote
        inl quoted_cub_path_to_include = cub_path |> quote
        inl quoted_kernels_dir = kernels_dir |> quote
        inl target_path = combine(kernels_dir,"cuda_kernels.ptx")
        inl quoted_target_path = target_path |> quote
        inl input_path = combine(kernels_dir,"cuda_kernels.cu")
        inl quoted_input_path = input_path |> quote

        if FS.StaticMethod file_type .Exists input_path bool then FS.StaticMethod file_type .Delete input_path ()
        FS.StaticMethod file_type .WriteAllText(input_path,cuda_kernels) ()
   
        inl _ = 
            if FS.StaticMethod file_type .Exists nvcc_router_path bool then FS.StaticMethod file_type .Delete nvcc_router_path ()
            inl filestream_type = fs [text: "System.IO.FileStream"]

            use nvcc_router_file = FS.StaticMethod file_type .OpenWrite(nvcc_router_path) filestream_type
            use nvcc_router_stream = FS.Constructor streamwriter_type nvcc_router_file

            inl write_to_batch = concat >> inl x -> FS.Method nvcc_router_stream .WriteLine x ()

            "SETLOCAL" |> write_to_batch
            ("CALL ", quoted_vs_path_to_vcvars, vc_vars_args) |> write_to_batch
            ("SET PATH=%PATH%;", quoted_vs_path_to_cl) |> write_to_batch
            (
            quoted_nvcc_path, " -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017",
            " -I", quoted_cuda_toolkit_path_to_include,
            " -I", quoted_cub_path_to_include,
            " -I", quoted_vc_path_to_include,
            " --keep-dir ",quoted_kernels_dir,
            " -maxrregcount=0  --machine 64 -ptx -cudart static  -o ",quoted_target_path," ",quoted_input_path
            ) |> write_to_batch

        inl stopwatch_type = fs [text: "System.Diagnostics.Stopwatch"]
        inl timer = FS.StaticMethod stopwatch_type .StartNew () stopwatch_type
        if FS.Method process .Start() bool = false then failwith () "NVCC failed to run."
        FS.Method process .BeginOutputReadLine() ()
        FS.Method process .BeginErrorReadLine() ()
        FS.Method process .WaitForExit() ()

        inl exit_code = FS.Method process .get_ExitCode() int32
        assert (exit_code = 0i32) ("NVCC failed compilation.", exit_code)
    
        inl elapsed = FS.Method timer .get_Elapsed() (fs [text: "System.TimeSpan"])
        !MacroFs((),[text: "printfn \"The time it took to compile the Cuda kernels is: %A\" "; arg: elapsed])

        FS.Method context .LoadModulePTX target_path (fs [text: "ManagedCuda.BasicTypes.CUmodule"])

    inl current_directory = FS.StaticMethod env_type .get_CurrentDirectory() string
    inl modules = compile_kernel_using_nvcc_bat_router current_directory
    writeline (string_concat "" ("Compiled the kernels into the following directory: ", current_directory))
```

Here is the part the actually compiles the modules. It creates that batch script and sets up the `Process` object which it then uses to launch the script from the command line. The above code fragment is messy due to heavy use of macros, but it is straightforward.

After the above is executed successfully, a `CUmodule` object is bound to the `modules` variable which holds all the kernels in binary format. This is used in the `run` function.

```
    inl dim3 = function
        | {x y z} as m -> m
        | x,y,z -> {x=x: int64; y=y: int64; z=z: int64}
        | x,y -> {x=x: int64; y=y: int64; z=1}
        | x -> {x=x: int64; y=1; z=1}

    inl SizeT_type = fs [text: "ManagedCuda.BasicTypes.SizeT"]
    inl CUdeviceptr_type = fs [text: "ManagedCuda.BasicTypes.CUdeviceptr"]
    inl SizeT = FS.Constructor SizeT_type
    inl CUdeviceptr = FS.Constructor CUdeviceptr_type << SizeT

    met run s {blockDim gridDim kernel} =
        inl blockDim = dim3 blockDim
        inl gridDim = dim3 gridDim
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
                inl blockDim = {x=x(); y=y(); z=z()}
                inl gridDim = {x=x'(); y=y'(); z=z'()}
                kernel blockDim gridDim

        inl join_point_entry_cuda x = !JoinPointEntryCuda(x())
        inl method_name, args = join_point_entry_cuda kernel
        
        inl dim3 {x y z} = Tuple.map (to uint32) (x,y,z) |> FS.Constructor (fs [text: "ManagedCuda.VectorTypes.dim3"])
    
        inl kernel_type = fs [text: "ManagedCuda.CudaKernel"]
        inl cuda_kernel = FS.Constructor kernel_type (method_name,modules,s.data.context)
        FS.Method cuda_kernel .set_GridDimensions(dim3 gridDim) ()
        FS.Method cuda_kernel .set_BlockDimensions(dim3 blockDim) ()

        match s.data.stream with
        | () -> FS.Method cuda_kernel .Run(to_obj_ar args) float32
        | stream -> FS.Method cuda_kernel .RunAsync(stream.extract,to_obj_ar args) ()
```

Before moving forward, here is how the above function is used in practice.

```
let tutorial1 =
    "tutorial1",[cuda_modules],"The placeholder for the tutorial examples",
    """
inb s = CudaModules (1024*1024) 

inl fact to = Loops.for {from=2; to state=dyn 1; body=inl {state i} -> state * i}

s.run {
    blockDim=1
    gridDim=1
    kernel=inl blockDim gridDim -> 
        fact 3 |> ignore
    }
    """
```

This would result in the factorial function as recursive GPU code.

```
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_10();
    __device__ long long int method_11(long long int var_0, long long int var_1);
    
    __global__ void method_10() {
        long long int var_0 = 1;
        long long int var_1 = 2;
        long long int var_2 = method_11(var_0, var_1);
    }
    __device__ long long int method_11(long long int var_0, long long int var_1) {
        char var_2 = (var_1 <= 3);
        if (var_2) {
            long long int var_3 = (var_0 * var_1);
            long long int var_4 = (var_1 + 1);
            return method_11(var_3, var_4);
        } else {
            return var_0;
        }
    }
}
"""
```

In the standard library the following form would be used instead.

```
    kernel=cuda
        fact 3 |> ignore
```

`cuda` is just shorthand for `inl blockDim gridDim ->` built into the parser.

There are points of interest that need to be explained for `run` to be fully understood.

```
            inl kernel =
                inl map_to_op_if_not_static {x y z} (x', y', z') = 
                    inl f x x' = if lit_is x then const x else x' 
                    f x x', f y y', f z z'
                inl x,y,z = map_to_op_if_not_static blockDim (__blockDimX,__blockDimY,__blockDimZ)
                inl x',y',z' = map_to_op_if_not_static gridDim (__gridDimX,__gridDimY,__gridDimZ)
                inl _ -> // This convoluted way of swaping non-literals for ops is so they do not get called outside of the kernel.
                    inl blockDim = {x=x(); y=y(); z=z()}
                    inl gridDim = {x=x'(); y=y'(); z=z'()}
                    kernel blockDim gridDim
```

What the above does is make sure that if the block and grid dimension sizes are known at compile time, that they are also passed into the kernel as literals. Otherwise they are used as intrinsics directly.

In Cuda C code when `blockDim.x` is used directly, that is not a compile time constant, but a runtime variable. Spiral goes to an extra length in order to preserve information and intrinsics for substitutes literals whenever possible. The above code implements that.

This is actually necessary for interop with the Cuda Unbound library which takes in block and grid dimensions as template parameters and requires them to be literals.

```
            inl join_point_entry_cuda x = !JoinPointEntryCuda(x())
            inl method_name, args = join_point_entry_cuda kernel
```

The part directly after that is where the kernel gets executed. Cuda has a join point special to it and that is invoked using `!JoinPointEntryCuda(x())`. If this was a standard join point then that would be enough to call the function, but in Cuda's case things are a bit more complicated. Because all the calls have to go through the `ManagedCuda` library and then through the Cuda API, it would be very difficult to bake that call into the language directly.

Instead what the Cuda join point does is compile the function and returns the method name and the free variables passed into the join point. The method name is used to extract the kernel and the free variables are passed as arguments to the `Run` and `RunAsync` method.

```
            inl dim3 {x y z} = Tuple.map (to uint32) (x,y,z) |> FS.Constructor (fs [text: "ManagedCuda.VectorTypes.dim3"])
    
            inl kernel_type = fs [text: "ManagedCuda.CudaKernel"]
            inl cuda_kernel = FS.Constructor kernel_type (method_name,modules,context)
            FS.Method cuda_kernel .set_GridDimensions(dim3 gridDim) ()
            FS.Method cuda_kernel .set_BlockDimensions(dim3 blockDim) ()

            match stream with
            | () -> FS.Method cuda_kernel .Run(to_obj_ar args) float32
            | stream -> FS.Method cuda_kernel .RunAsync(stream.extract,to_obj_ar args) ()
```

Here is where the kernel is actually loaded.

```
inl cuda_kernel = FS.Constructor kernel_type (method_name,modules,context)
```

More specifically, on this line. It loads the kernel of `method_name` and uses the `modules` objects that holds all the compiled kernels from the previous step and the Cuda `context`.

```
            match stream with
            | () -> FS.Method cuda_kernel .Run(to_obj_ar args) float32
            | stream -> FS.Method cuda_kernel .RunAsync(stream.extract,to_obj_ar args) ()
```

Here is where the kernel is invoked synchronously or asynchronously depending on whether a stream was passed in.

This covers everything needed to know in order to understand the Cuda backend. This is the Cuda backend in nearly its entirety.

#### Why Spiral Was Created

The above is simple, but unless the language supports it then it is impossible to build it as a part of a library. Being able to do the above is one of the major motivators for the creation of Spiral. It simply saves such an enormous amount of work.

##### How It Used To Be Done

The Spiral language originates from ML library of the same name done by author during the 2016 period.

Here is how the map kernel used to look there.

```
/// o <- f(x)
type DeviceUnaryTransformModule(op: string, unique_name : string) = 
    let kernel_name = "Map1Kernel"+unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType x)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType* A, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(A[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a),
                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes2(x,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|ext_x x; ext_o o; n|])
```

It was used in two places.

```
let squareModule = lazy new DeviceUnaryTransformModule("x*x;","Square")
let logModule = lazy new DeviceUnaryTransformModule("logf(x);","Log")
```

Text macros are used as operations because there is not much choice apart from that for getting some generic kernel functionality. It was not much generic functionality though. Suppose I want to pass in two arguments into the map kernel instead of one.

```
/// o <- f(x,y)
type DeviceBinaryTransformModule(op: string, unique_name) = 
    let kernel_name = "Map2Kernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType x, floatType y)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType* A, const floatType* B, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(A[i],B[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""
    
    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a),
                (ext_y: ^a -> CUdeviceptr, y: ^a),
                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes3(x,y,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|ext_x x; ext_y y; ext_o o; n|])
```

This one was used only for pointwise multiplication.

```
let hadamaradMultiplicationModule = lazy new DeviceBinaryTransformModule("x*y;", "HadMult")
```

There were many more of such kernels and after 6 variation on the basic map, the author lost drive to more because once he had those he could implement the rest in terms of composition.

As an example of what that means, here is how binary cross entropy was implemented in the previous library.

```
let inline cross_entropy_cost (target: ^a) (activations: ^a) = context {
    let lt = target
    let! ll = log_ activations
    let! rt = scalar_matrix_add 1.0f -1.0f target
    let! rl = scalar_matrix_add 1.0f -1.0f activations >>= log_
    return! linear_layer_hadmult [|lt, ll; rt, rl|] 
            >>= sum
            >>= scale (-1.0f / float32 (cols target))
    }
```

The author could not write something like...

```
    inl cross_entropy = error {
        fwd = inl x, y -> -(y * log x + (one - y) * log (one - x))
        bck = 
            inl (x, y) _ -> (x - y) / (x * (one - x))
            ,inl (x, y) _ -> log (one - x) - log x
        }
```

...but he did have individual operations for log and scalar matrix addition and Hadamarad multiplication so he could piece the required operation together.

The difference between doing it directly and indirectly is the 6 intermediate allocations that the old library required to perform the same thing. Since GPUs are memory bound, that would make for a vast difference in performance.

In the old library there simply was not a middle ground between writing all the kernels by hand and having to compose very small pieces in an inefficient manner. But the issues with the old arrangement did not stop there.

Even if one is resolved to do the kernels by hand, some operations when done in composite require tracking a very large number of variables. Imagine the horror of having to deal with well over a dozen `float *` variables differentiated only by their name inside a single kernel and having no boundary or type checks to speak off. The author has had issues with swapping variables around by accident when there are just two of them of the same type in the same function. 

Mentally tracking over a dozen pointers to a tensor, their offsets and sizes with only their names to differentiate them would be simply impossible. And the author quickly realized that he could not take responsibility for such code in old library.

Machine learning code is the worst in terms of debugging difficulty. Back when he first started, the author did appreciate dimensionality checking and had errors with some matrices being incorrectly transposed. There was one particular example where he hit 96% on Mnist despite the network propagating gradients in the wrong places.

It very possible for mistakes to go unnoticed because only half the network gets updated or updated incorrectly, but the network still appears to work fine.

Hence more than anywhere else, being able to reason about all aspects of code is of vital importance in a machine learning context. In fact, it is absolutely important everywhere.

There is also one other point worth noting. All the operation in the old library have the `lazy` prefixed behind them. The reason for that is that they are compiled individually and the author found that NVRTC required around 0.5s to compile a single operation. With 20> operations in the library that made for some massive compile times if all of them are compiled every time. NVCC is not much better. It requires 0.7s to compile an empty file and about 2.1s for a 3k file, so compiling all the kernels in single batch is important for speed's sake.

This is also something that would be impossible to do without the support of a language. The assembling of information is in fact the dictionary definition for the world 'compilation'.

### 7: Object Orientation

Spiral is a functional language at its core, but it is good at doing OO despite not having specific features for it built in like other statically typed languages. Since OO is needed for passing around contexts in various key places, this chapter will be an overview of how it is done.

#### Motivation

A significant amount of complexity in the Spiral's ML library comes from needing to manage Cuda memory directly. For a that a design pattern is needed to deal with it in the absence of garbage collection. Meaning all the data needs to be packed into some kind of object and passed around.

In functional languages reader, state and writer monads are commonly used for this sort of dependency injection. An argument could be made that the reader pattern is a variant on the OO pattern except with the `self` argument on the opposite end.

```
inl f self a b = ... // OO pattern
inl f a b self = ... // reader pattern
```

For some parts of the library it is much simpler to pass context in the first place and not bother with composition. The OO pattern shines there. Monads have the disadvantage of requiring all the code to be a part of the same monadic workflow. Some languages like Haskell go through great lengths to make that ergonomic, but Spiral is not such a language and it would be preferable to avoid using monads unless they are needed.

It is easy to switch between the above patterns anyway.

One other advantage is that OO breaks the usual top down ordering of functions.

```
inl a x = ...
inl b x = ...
inl c x = ...
```

In the above fragment, `a` cannot refer to `b` or `c` as they come after it, and `b` cannot refer to `c`, but it is possible to get around that using OO in Spiral which can be useful.

The OO pattern can also be used for easy immutable updates. This is not something OO is known for.

#### The Object

```
/// Converts the argument (usually a module) to the object form.
inl obj s x = s x s
```

`obj` is defined in `Core`. In `s x s` the `s x` part selects the method from `s` and then `s` is passed into that method.

```
let object =
    (
    "Object",[],"The Object module.",
    """
{
data' = {}
data = inl {data'} -> data'
data_add = inl s v -> {s with data'=module_foldl (inl name s v -> module_add name v s) (indiv self) v |> heap} |> obj
member_add = inl s -> module_foldl (inl name s v -> module_add name (inl s -> v (obj s)) s) s >> obj
module_add = inl s name v -> module_add name (inl s name -> v name (obj s)) s |> obj
unwrap = id
} 
|> obj
    """) |> module_
```

The base Object in Spiral is implemented like this. It continually wraps its members with the `obj` function in order to emulate OO access in standard statically typed OO languages. Maybe at some point remove functions will be added.

The main thing to keep in mind when considering `data_add`, `member_add`, `module_add` is that the first argument to them is not an object, but an unwrapped module.

```
module_add name (inl s -> v (obj s)) s
```

Hence when the module `s` is being passed into the member, it is always wrapped into an object. What would happen if the fragment was written like this...

```
module_add name v s
```

...is that then the unwrapped `s` would get passed into the member. The reason why `data_add` does not wrap `v` inside the module is to allow data fields to be accessed directly.

`data_add`, `member_add`, `module_add` always return an object so their return is piped to `obj`.

```
data' = {}
data = inl {data'} -> data'
```

The actual data is stored in the `data'` field rather than `data` because trying to access an object will pass itself to its argument as the first move and result in a type error. Hence the only way to access the data directly in that case would be to call `unwrap` first or do it like it has been done and make a member that reroutes to it.

`data_add` in particular also makes sure that the `data'` is stored on the heap at all times rather than passed around as individual arguments through join points. It makes the generated code look decently nicer, speeds up compilation and improves runtime performance.

Here is an example of it in use:

```
    Object
        .member_add {run}
        .data_add {context stream=()}
    |> ret
```

`module_add` can be used similarly.

```
s.module_add .CudaTensor methods
```

Members can be accessed directly like...

```
s.allocate
```

Modules on the other hand require two type literals as arguments.

```
s.RegionMem.allocate
```

Data member are prefixed with `data`.

```
s.data.context
```

### 8: GPU Programming Basics

GPU programming is well worth learning for those interested in drawing out as most performance as is possible from the machine, and lessons from it transfer over into CPU programming. At some point Spiral will drop Cuda and switch to supporting neural computing architectures, and when that happens the lesson learning in the GPU arena can be expected to transfer. The reason for that will be because those architectures will be similar to GPUs except with a lot more local memory.

Knowing how to program effectively will never go out of date.

This chapter will cover a few select kernels from the `CudaKernel` module found in the `Learning` project. There are more than will be covered in this chapter and more yet will be made in the future, but these can be counted on to illustrate how Spiral does Cuda programming.

#### map

```
met map' w f in out = 
    inl in, out = zip in, zip out
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    assert (in.dim = out.dim) "The input and output dimensions must be equal."
    inl in = flatten in |> to_dev_tensor
    inl out = flatten out |> to_dev_tensor
    inl in_a :: () = in.dim
    
    inl blockDim = 128
    inl gridDim = min 64 (divup (s in_a) blockDim)

    w.run {
        blockDim gridDim
        kernel = cuda // Lexical scoping rocks.
            grid_for {blockDim gridDim} .x in_a {body=inl {i} ->
                inl out = out i
                inl in = in i
                out .set (f in.get out.get)
                }
        }
```

It actually more of a pain to set up the arguments before passing them into the kernel than writing the kernel itself. In fact, the actual kernel could be shortened to one line without much trouble.

```
cuda grid_for {blockDim gridDim} .x in_a {body=inl {i} -> out i .set (f (in i .get) (out i .get))}
```

Lexical scoping just buys so much in this example that it is amazing. It scoops up both of the input and output tensors and allows me to pass in `in_a` as the loop dimension in one move. Considering how wide range of a functionality Spiral's tensors have compared to arrays that makes writing kernels significantly easier.

The above example is simple as the tensors are `flatten`ed to 1d before being shipped off into the kernel, but other kernels will make use of the tensor's full functionality.

Most of the functionality in the above fragment should be obvious from reading it, but `to_dev_tensor` and `divup` require an explanation.

```
inl divup a b = (a-1)/b+1 // Integer division with rounding up. (a+b-1)/b is another variant on this.
```

So `divup 9 5 = 2` and `divup 10 5 = 2`, but `divup 11 5 = 3`.

`to_dev_tensor` on the other hand does some transformation on the tensor under the hood. `CudaTensor`s have a reference to a pointer, but the device tensors need to be raw pointers. So `to_dev_tensor` strips the reference in order to allow the tensor to cross the language boundary. In addition to that, it also adds the offset to the pointer and replaces it with 0.

In .NET land it is not possible to move pointers around - array pointers must always point at the beginning of it, but in C they can point to anywhere. By adding the offset to the pointer and replacing it with 0, that allows the offset to be passed through the join point as a literal and not manifest as an argument.

In Spiral, some types which are not blittable like strings and chars can be passed onto the Cuda side at compile time as literals. This hold true for all types fully known at compile time.

Apart from that the context is `w` in the `CudaKernel` module because `s` is taken up by the span `{near_to from} -> near_to - from` function.

The following example was already shown in the Cuda backend chapter, but here it is as a review.

```
let kernel1 =
    "kernel1",[cuda_modules],"Does the map kernel work?",
    """
/// Initializes all the Cuda parts
inb s = CudaModules (1024*1024) // The allocator takes 1Mb of memory from the heap.

/// Creates a host tensor with the given generator function.
inl h = HostTensor.init 32 (inl x -> x + 1) 
/// Loads the tensor on the GPU based on the host tensor
inl a1 = s.CudaTensor.from_host_tensor h
/// Makes a tensor of the same type and dimensions as `a1` and zeroes it.
inl o1 = s.CudaTensor.zero_like a1
/// Calls the map operation. `a1` is the input and `o1` is the output.
s.CudaKernel.map' (inl a _ -> a * 2) a1 o1

/// Transfers the tensor back to host.
inl a2 = s.CudaTensor.to_host_tensor o1
/// Zips the two tensors and prints them out.
HostTensor.zip (h,a2) |> HostTensor.show |> Console.writeline
    """
```

The kind of code this fragment produces was described in the backend chapter, so it won't be covered here.

`map'` as shown here has the notable issue of needing to have its output feed to it. It is possible to abstract that away.

```
inl map w f in =
    indiv join
        inl in = zip in
        inl out = w.CudaTensor.create {dim=in.dim; elem_type=type f in.elem_type}
        map' w (inl in _ -> f in) in out
        stack out
```

All the functions apart from `map_redo_map` in the `CudaKernel` module have a variant that automatically allocates the output provided to them.

The reason why map is written like the above instead of like...

```
inl map w f in =
    inl in = zip in
    inl out = w.CudaTensor.create {dim=in.dim; elem_type=type f in.elem_type}
    map' w (inl in _ -> f in) in out
    out
```

...is because it was found out that the variant that uses join points and layout types has significantly better compile times. This will be covered in more detail later.

What `map` does is allocate the output tensor based on the input dimension and the inferred output type and then passes that to `map'`. It also wraps around the input function so it throws away the output argument given to it.

All auxiliary kernel variants do those and only those things.

#### map_redo_map

Zips, flattens the tensor to 1d, maps it, reduces it and then maps the output scalar tensor. This particular kernel is used for cost functions in the ML library.

```
/// Zips, flattens the tensor to 1d, maps, reduces it and maps it.
/// Map is optional. Allocates a temporary tensor for the intermediary results.
inl map_redo_map w {d with redo neutral_elem} in =
    indiv join
        inl to_dev_tensor = w.CudaTensor.to_dev_tensor
   
        inl run {map_out map_in blockDim gridDim} (!to_dev_tensor in) =
            inl in_a :: () = in.dim
            inl out = w.CudaTensor.create {elem_type=type map_in in.elem_type |> map_out; dim=gridDim}
            inl out' = to_dev_tensor out

            w.run {
                blockDim gridDim
                kernel = cuda 
                    inl x = 
                        grid_for {blockDim gridDim} .x in_a {state=dyn neutral_elem; body=inl {state i} -> redo state (map_in (in i .get)) }
                        |> cub_block_reduce {blockDim redo} |> map_out
                    if threadIdx.x = 0 then out' blockIdx.x .set x
                }

            out

        inl in = zip in |> flatten
        inl map_in = match d with {map_in} -> map_in | _ -> id
        inl map_out = match d with {map_out} -> map_out | _ -> id

        inl in_a :: () = in.dim
        inl span = s in_a
        inl blockDim = lit_min span 1024
        inl gridDim = 1 //lit_min 64 (divup span blockDim)

        inl r = 
            if gridDim = 1 then
                run {map_out map_in blockDim gridDim} in
            else
                run {map_out=id; map_in blockDim gridDim} in
                |> run {map_out map_in=id; blockDim=gridDim; gridDim=1}
        r 0 |> stack
```

The actual Cuda part of the kernel is this...

```
inl x = 
    grid_for {blockDim gridDim} .x in_a {state=dyn neutral_elem; body=inl {state i} -> redo state (map_in (in i .get)) }
    |> cub_block_reduce {blockDim redo} |> map_out
if threadIdx.x = 0 then out' blockIdx.x .set x
```

The kernel can be described in 3 steps:

1) The blocks iterate over the global memory and perform the maps and reductions as they go along. This means that if there is one block of 1024 iterating over a 1024*128 array, it will perform 128 reductions before moving to the next step.
2) A block reduction. Whenever possible, Spiral offloads work to the Cuda Unbound library as writing Cuda kernels can be tricky.
3) When that is done, only the first thread has the result of the block reduce. It writes that result to global memory after mapping it.

If the `gridDim` is 1, then the actually kernel needs to be run only once, but otherwise it must be done twice in order to perform the inter block reduction.

##### flatten

```
        inl in = zip in |> flatten
```

Like in the map, the input is zipped and then flattened. Since flatten was made after the Tensor chapter was made, it will be covered here. Here it is in full from the `HostTensor` module.

```
/// Flattens the tensor to a single dimension.
inl flatten tns =
    match tns.dim with
    | () -> tns
    | !(Tuple.map span) dim ->
        tns .set_dim (product dim)
            .update_body (inl {d with size} ->
                Tuple.zip (dim,size)
                |> Tuple.reducel (inl d,s d',s' ->
                    assert (s = d' * s') "The tensor must be contiguous in order to be flattened."
                    d*s, s'
                    )
                |> inl _,s -> {d with size=s :: ()}
                )
```

The dimension of the output tensor is set to the product of its spans, but in order for a tensor to be capable of being flattened it must be contiguous.

```
                |> Tuple.reducel (inl d,s d',s' ->
                    assert (s = d' * s') "The tensor must be contiguous in order to be flattened."
                    d*s, s'
                    )
```

In order for that to hold true the size of the outer dimension must equal the span of the inner dimension times its size.

What that means is this - suppose there is a 2d tensor of dimensions (10,10) and size (10,1). That tensor could then be flattened to a 1d tensor of dimension 100 and size 1. But suppose a view of the tensor was taken along the inner dimension.

```
tns.view_span (inl a,b -> a, 5)
```

Now the resulting tensor would have dimensions of (10,5) and size of (10,1).

Since 10 <> 5 * 1 that means that the tensor is not contiguous. This also means that tensors that have been rotated cannot be flattened. Viewing the outermost dimension would be fine though.

This covers flattening.

```
        inl map_in = match d with {map_in} -> map_in | _ -> id
        inl map_out = match d with {map_out} -> map_out | _ -> id
```

Since `map_in` and `map_out` are optional, they are replaced with the identity function if they are missing inside the kernel.

```
        inl in_a :: () = in.dim
        inl span = s in_a
        inl blockDim = lit_min span 1024
        inl gridDim = 1 //lit_min 64 (divup span blockDim)
```

Here the `gridDim` is just set to 1 because the author was lazy and decided to leave the job of fiddling with the launch parameters for later.

```
/// The template for lit_min and lit_max.
inl lit_comp op a b =
    if lit_is a && lit_is b then op a b
    elif lit_is a then a
    elif lit_is b then b
    else error_type "a or b needs to be a literal"

/// Returns the compile time expressible maximum of the two expressions.
inl lit_max = lit_comp max
/// Returns the compile time expressible minimum of the two expressions.
inl lit_min = lit_comp min
```

`lit_min` is defined in `Core` like this. A standard min function would return the minimum of the two arguments. `lit_min` on the other hand does that only between two literals. If one of the arguments is not a literal, then it just returns the literal. If both are not literals then that is a type error.

```
        inl r = 
            if gridDim = 1 then
                run {map_out map_in blockDim gridDim} in
            else
                run {map_out=id; map_in blockDim gridDim} in
                |> run {map_out map_in=id; blockDim=gridDim; gridDim=1}
        r 0 |> stack
```

Here is where the kernel is launched either once or twice depending on how many reductions are needed and then returned.

```
        inl run {map_out map_in blockDim gridDim} (!to_dev_tensor in) =
            inl in_a :: () = in.dim
            inl out = w.CudaTensor.create {elem_type=type map_in in.elem_type |> map_out; dim=gridDim}
            inl out' = to_dev_tensor out
```

Here the `run` infers the type and creates the output before passing it into the kernel. 

As can be seen the scaffolding for the actual kernels has a lot of details and needs to be covered a few times.

##### Cuda Loops

```
let kernel2 =
    "kernel2",[cuda_modules],"Does the map_redo_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl h = HostTensor.init 1024 ((+) 1)
inl a1 = s.CudaTensor.from_host_tensor h

s.CudaKernel.map_redo_map {neutral_elem=0; redo=(+)} a1
|> s.CudaTensor.print // 524800
    """
```

The above sums all the numbers between [1..1024].

```
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_21(long long int * var_0, long long int * var_1);
    __device__ char method_22(long long int * var_0, long long int * var_1);
    
    __global__ void method_21(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (1024 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = 0;
        long long int var_7[1];
        long long int var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_22(var_7, var_8)) {
            long long int var_10 = var_7[0];
            long long int var_11 = var_8[0];
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 1024);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = var_0[var_10];
            long long int var_17 = (var_11 + var_16);
            long long int var_18 = (var_10 + 1024);
            var_7[0] = var_18;
            var_8[0] = var_17;
        }
        long long int var_19 = var_7[0];
        long long int var_20 = var_8[0];
        long long int var_21 = cub::BlockReduce<long long int,1024,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_20);
        long long int var_22 = threadIdx.x;
        char var_23 = (var_22 == 0);
        if (var_23) {
            long long int var_24 = blockIdx.x;
            char var_25 = (var_24 >= 0);
            char var_27;
            if (var_25) {
                var_27 = (var_24 < 1);
            } else {
                var_27 = 0;
            }
            char var_28 = (var_27 == 0);
            if (var_28) {
                // "Argument out of bounds."
            } else {
            }
            var_1[var_24] = var_21;
        } else {
        }
    }
    __device__ char method_22(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 < 1024);
    }
}
```

The produced kernel is of course a decent bit longer than 3 lines. The resulting output in whole is 745 LOC, so it can be pasted here due to its size. As this is a good opportunity to do so, Cuda loops will be covered here.

Originally these kernels used the tail recursive loops covered in an earlier chapter. It seems like a good idea at the time since the Cuda compiler appeared to be able to perform the tail recursive optimization. Nevertheless, as the author has suspected might happen since literally nobody but him would ever try compiling Cuda loops in such a manner, when tail recursive loops are combined with tuple returns, NVCC will outright produce incorrect code that will lead to local write errors. Based on the reply to the bug report he sent, the NVCC does not support tail recursion optimization and presumably the bug won't be fixed.

Hence just on the Cuda side, the language supports standard imperative loops, more specifically the while loop.

```
inl whilecd {cond state body} =
    inl r = HostTensor.create {
        array_create=array_create_cuda_local 
        elem_type=state 
        dim=()
        }
    r .set state
    /// Note: While must have a join point around it.
    !While((join cond r.get), (r.set <| body r.get))
    r .get
```

As can be seen, Spiral's tensors can be used with Cuda local arrays without any changes even in tuple of array form.

```
    inl r = HostTensor.create {
        array_create=array_create_cuda_local 
        elem_type=state 
        dim=()
        }
```

The above fragment corresponds to this one in the code...

```
        long long int var_7[1];
        long long int var_8[1];
```

Going forward.

```
r .set state
```
Is...
```
        var_7[0] = var_5;
        var_8[0] = var_6;
```
The...
```
!While((join cond r.get), (r.set <| body r.get))
```
...is everything in the while loop. Note that since C requires the conditional a single expression the easiest way to achieve that is to stick it in a join point. Compiler tends to split expressions into statements during the code generation phase which would spill out of the conditional unless it was lifted into a function.
```
r .get
```
Corresponds to after the while loop.
```
        long long int var_19 = var_7[0];
        long long int var_20 = var_8[0];
```

Of the two variables in the tensor, one is a loop counter and the other is the actual state.

```
inl forcd {d with from body} =
    inl finally =
        match d with
        | {finally} -> finally
        | _ -> id

    inl check =
        match d with
        | {near_to} from -> from < near_to 
        | {to} from -> from <= to
        | {down_to} from -> from >= down_to
        | {near_down_to} from -> from > near_down_to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` needs be present."

    inl by =
        match d with
        | {by} -> by
        | {to | near_to} -> 1
        | {down_to | near_down_to} -> -1

    inl to =
        match d with
        | {(to ^ near_to ^ down_to ^ near_down_to)=to} -> to
        | _ -> error_type "Only one of `to`,`near_to`,`down_to`,`near_down_to` is allowed."

    inl state = 
        match d with
        | {state} -> state
        | _ -> ()

    inl state = {from state}
    whilecd {
        state
        cond = inl {from state} -> check from
        body = inl {from state} -> {state=body {state i=from}; from=from+by}
        } .state
    |> finally
```

Most of this should be familiar from the loops chapter. Making a for loop from a while loop should not be much of a challenge by this point. It is a fairly straightforward extension of the concept.

From the for loop comes the Cuda specialized `grid_for` loop which makes it straightforward to iterate over a tensor in a block-strided fashion.

```
inl grid_for_template {iteration_mode} {blockDim gridDim} axis dim =
    inl from = threadIdx axis + blockDim axis * blockIdx axis - dim.from
    inl by = gridDim axis * blockDim axis
    inl near_to = dim.near_to

    match iteration_mode with
    | .items_per_thread {d with body} ->
        inl span = s dim
        inl items_per_thread = divup span by
        forcd {d with from=0;near_to=items_per_thread; body=inl {state i=item} ->
            inl i = from + by * item
            inl num_valid = span - by * item
            if i < near_to then body {span num_valid item state i} else state
            }
    | .std d -> forcd {d with from by near_to}

inl grid_for_items = grid_for_template {iteration_mode=.items_per_thread}
inl grid_for = grid_for_template {iteration_mode=.std}
```

The `axis` argument can only be `.x`, `.y` or `.z`. In Cuda examples online, they often compulsively write out...

```
int stride = gridDim.x * blockDim.x;
for {int i = threadIdx.x + blockDim.x * blockIdx.x; i < N; i += stride} {...}
```

Or something to that effect. `grid_for` is inteded to abstract that away so as to make the code more concise and reduce the chance of error. [Structured programming](https://en.wikipedia.org/wiki/Structured_programming) started the trend of using loops and if statements, but Cuda itself firmly remains stuck in the late 50s in terms of what it offers inside the kernel. `grid_for` is a slight, but a notable improvement over using the raw for loop.

The standard `grid_for` that has been shown functions like a normal loop, but the `grid_for_items` has a special purpose to it.

To understand why it is needed here is a quiz. Where are these variables allocated?

```
int a;
int b[2];
int c[var_11];
```

`a` and `b` are held in registers. This is despite `b` being an array. On the other hand since `c`'s size is not statically known, it is allocated in global memory or most likely the cache.

Whether `b` is allocated in registers or not also depends on how it is indexed.

```
b[0]; // safe
b[1]; // safe
b[var_12]; // better allocate it in global memory after all
```

So the Cuda array's type depends on how it is used and the compiler will not give any indication of what is going on under the hood the programmer.

Furthermore, one other important thing to keep in mind is that C compilers, and especially Cuda compilers are specialized for optimizing loops. If the loop boundaries are statically known, which they usually are if one is programming in Spiral, the Cuda compiler will strongly attempt to unroll it.

If it is inspected with `print_static` then `item` will show up as a runtime variable, but Cuda will know the difference after unrolling and will be able to determine at compile time what the indices into the array are.

This is important because variables held in registers can be accessed orders of magnitude more quickly than in main memory, and this particular trick is used in reduce + broadcast kernels which are needed to implement softmax error and layer normalization. It is also used in the sampler.

#### d2_replicate_map

This function replicates the first 1d tensor so it matches the 2d second. It is used for adding biases to the result of a matrix multiply.

```
/// Replicates the 1d `in` and maps it along the outer dimension as determined by `in'`.
met d2_replicate_map' w f in in' out =
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
    inl in, in', out = zip in, zip in', zip out
    inl dim_in :: () = in.dim
    inl dim_in'_a, dim_in'_b = in'.dim

    assert (dim_in = dim_in'_b) "Input's dimension must equal the second input's inner dimension."
    assert (in'.dim = out.dim) "Second input must have the same dimension as the output."

    inl blockDimX = min warp_size (s dim_in)
    inl blockDimY = min 32 (s dim_in'_a)
    inl gridDim = min 64 (divup (s dim_in) blockDimX)

    inl in = to_dev_tensor in
    inl in' = to_dev_tensor in'
    inl out = to_dev_tensor out

    w.run {
        gridDim
        blockDim=blockDimX,blockDimY
        kernel = cuda 
            inl grid_for = grid_for {gridDim blockDim}
            grid_for .x dim_in'_b {body=inl {i} ->
                inl in = in i .get
                inl in' j = in' j i
                inl out j = out j i
                grid_for .y dim_in'_a {body=inl {i} ->
                    inl in', out = in' i, out i
                    out.set (f in in'.get out.get)
                    }
                }
        }
```

The first half of the kernel is the standard fare - zips, assertions for dimension sizes, calls into `to_dev_tensor`, and determination of the block and grid dimensions. The actual kernel part is a bit more interesting than last time.

```
            inl grid_for = grid_for {gridDim blockDim}
            grid_for .x dim_in'_b {body=inl {i} ->
                inl in = in i .get
                inl in' j = in' j i
                inl out j = out j i
                grid_for .y dim_in'_a {body=inl {i} ->
                    inl in', out = in' i, out i
                    out.set (f in in'.get out.get)
                    }
                }
```

On the very first line there is an example of partial application on the loop function. `grid_for` is applied with the module holding the block and grid dimensions. Then it is used twice. First it used to iterate over the innermost dimension along the `x` axis.

```
                inl in = in i .get
                inl in' j = in' j i
                inl out j = out j i
```

Inside the loop, the 1d tensor is indexed into and bound to `in`. But `in'` and `out` are wrapped around instead which has the effect of implicitly rotating them. It is the same as saying: "apply the innermost dimension with `i` later."

```
                grid_for .y dim_in'_a {body=inl {i} ->
                    inl in', out = in' i, out i
                    out.set (f in in'.get out.get)
                    }
```

And that is what happens in the inner loop. The same `in` gets passed into `f` `dim_in'_a` number of times which has the effect of replicating it. Of course, often in Cuda programming it is not desirable to just replicate a tensor along some dimension as that would be wasteful. Instead the true benefit of having flexible kernel function is that they allow fusion which minimizes the number of intermediaries. As Cuda kernels are memory bound, that has an extreme positive effect on performance.

Compilers themselves are utterly incapable of performing such optimizations on their own, so the responsibility for it falls on the user.

That being said, the above kernel is a somewhat trivial example of this as only replicate and a map are fused, but it is possible to go significantly further.

Here is the auxiliary for it.

```
inl d2_replicate_map w f in in' =
    indiv join 
        inl in = zip in
        inl in' =
            match in' with
            | by : int64 -> 
                inl dim_in :: () = in.dim
                HostTensor.create {elem_type=(); dim=by,dim_in}
            | in' -> zip in'
        inl out = w.CudaTensor.create {elem_type=type f in.elem_type in'.elem_type; dim=in'.dim}
        d2_replicate_map' w (inl a b _ -> f a b) in in' out
        stack out
```

`in'` can also be a scalar value to indicate the size of the outermost dimension. Otherwise it is standard fare, it infers the type of the output, allocates it and passes it to the kernel, and strips the output from the mapping function.

##### Example

```
let kernel3 =
    "kernel3",[cuda_modules],"Does the d2_replicate_map kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 8
inl outer_size = 8

inl h = HostTensor.init inner_size (const 123)
inl h' = HostTensor.init (outer_size,inner_size) (inl a b -> a,b)
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.from_host_tensor h'
inl o1 = s.CudaKernel.d2_replicate_map (inl a b -> a, b) a1 a2
Tuple.iter s.CudaTensor.print (a1,a2,o1)
    """
```

```
[|123; 123; 123; 123; 123; 123; 123; 123|]

[|
    [|[0, 0]; [0, 1]; [0, 2]; [0, 3]; [0, 4]; [0, 5]; [0, 6]; [0, 7]|]
    [|[1, 0]; [1, 1]; [1, 2]; [1, 3]; [1, 4]; [1, 5]; [1, 6]; [1, 7]|]
    [|[2, 0]; [2, 1]; [2, 2]; [2, 3]; [2, 4]; [2, 5]; [2, 6]; [2, 7]|]
    [|[3, 0]; [3, 1]; [3, 2]; [3, 3]; [3, 4]; [3, 5]; [3, 6]; [3, 7]|]
    [|[4, 0]; [4, 1]; [4, 2]; [4, 3]; [4, 4]; [4, 5]; [4, 6]; [4, 7]|]
    [|[5, 0]; [5, 1]; [5, 2]; [5, 3]; [5, 4]; [5, 5]; [5, 6]; [5, 7]|]
    [|[6, 0]; [6, 1]; [6, 2]; [6, 3]; [6, 4]; [6, 5]; [6, 6]; [6, 7]|]
    [|[7, 0]; [7, 1]; [7, 2]; [7, 3]; [7, 4]; [7, 5]; [7, 6]; [7, 7]|]
|]

[|
    [|[123, [0, 0]]; [123, [0, 1]]; [123, [0, 2]]; [123, [0, 3]]; [123, [0, 4]]; [123, [0, 5]]; [123, [0, 6]]; [123, [0, 7]]|]
    [|[123, [1, 0]]; [123, [1, 1]]; [123, [1, 2]]; [123, [1, 3]]; [123, [1, 4]]; [123, [1, 5]]; [123, [1, 6]]; [123, [1, 7]]|]
    [|[123, [2, 0]]; [123, [2, 1]]; [123, [2, 2]]; [123, [2, 3]]; [123, [2, 4]]; [123, [2, 5]]; [123, [2, 6]]; [123, [2, 7]]|]
    [|[123, [3, 0]]; [123, [3, 1]]; [123, [3, 2]]; [123, [3, 3]]; [123, [3, 4]]; [123, [3, 5]]; [123, [3, 6]]; [123, [3, 7]]|]
    [|[123, [4, 0]]; [123, [4, 1]]; [123, [4, 2]]; [123, [4, 3]]; [123, [4, 4]]; [123, [4, 5]]; [123, [4, 6]]; [123, [4, 7]]|]
    [|[123, [5, 0]]; [123, [5, 1]]; [123, [5, 2]]; [123, [5, 3]]; [123, [5, 4]]; [123, [5, 5]]; [123, [5, 6]]; [123, [5, 7]]|]
    [|[123, [6, 0]]; [123, [6, 1]]; [123, [6, 2]]; [123, [6, 3]]; [123, [6, 4]]; [123, [6, 5]]; [123, [6, 6]]; [123, [6, 7]]|]
    [|[123, [7, 0]]; [123, [7, 1]]; [123, [7, 2]]; [123, [7, 3]]; [123, [7, 4]]; [123, [7, 5]]; [123, [7, 6]]; [123, [7, 7]]|]
|]
```

#### mapi_d2_redo_map

The inverse of the `d2_replicate` kernel. It reduces the outermost dimension of `in` - in other words it turns a tensor of dimensions `(a,b)` into `(b)`. It is equivalent to a transpose and then a reduce over the innermost dimension. An alternative to using this kernel would be to blast the target tensor with atomics in a regular map. That would work for some cases like in backwards step of `add_bias` at the cost of making training non-deterministic.

```
/// Maps the two inputs and then reduces the first's outer dimension.
met mapi_d2_redo_map' w {d with redo neutral_elem} in in' out =
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
    inl in, in', out = zip in, zip in', zip out
    inl dim_in_a, dim_in_b = in.dim
    inl dim_in' :: () = in'.dim

    assert (dim_in' = dim_in_b) "Input's inner dimension must equal the output's dimension."
    assert (in'.dim = out.dim) "Input and output's dimensions must be equal."

    inl blockDimX = lit_min warp_size (s dim_in')
    inl blockDimY = lit_min 32 (s dim_in_a)
    inl gridDim = min 64 (divup (s dim_in') blockDimX)

    inl in = to_dev_tensor in
    inl in' = to_dev_tensor in'
    inl out = to_dev_tensor out
    inl map_out = match d with {map_out} -> map_out | _ a _ _ -> a

    w.run {
        gridDim
        blockDim=blockDimX,blockDimY
        kernel = cuda 
            inl grid_for = grid_for {blockDim gridDim}
            grid_for .x dim_in_b {body=inl {i} ->
                inl in j = in j i
                inl in' = in' i .get
                inl out = out i
                inl finally result = out.set (map_out result out.get)

                inl state = 
                    grid_for .y dim_in_a {state=dyn neutral_elem; body=inl {state i=j} -> 
                        inl in = in j
                        match d with
                        | {map_in} -> redo state (map_in in.get in') 
                        | {mapi_in} -> redo state (mapi_in i j in.get in') 
                        | _ -> redo state in.get
                        }
                        
                if blockDim.y > 1 then
                    inl near_to = blockDim.y
                    inl ar = 
                        HostTensor.create {
                            array_create=array_create_cuda_shared
                            elem_type=state
                            dim={from=1; near_to}, blockDim.x
                            }
                        |> inl ar i -> ar i threadIdx.x

                    whilecd {
                        state={near_to state}
                        cond=inl {near_to} -> near_to >= 2
                        body=inl {near_to state} ->
                            inl by = near_to/2 // It might be worth trying `max 1 (near_to/3)`
                            if threadIdx.y < near_to && threadIdx.y >= by then ar threadIdx.y .set state
                            syncthreads()

                            {
                            near_to=by 
                            state=
                                if threadIdx.y < by then
                                    forcd {from=threadIdx.y+by; by near_to state 
                                        body=inl {state i} -> redo state (ar i .get)
                                        }
                                else
                                    state
                            }
                        }
                    |> inl {state} -> if threadIdx.y = 0 then finally state
                else
                    finally state
            }
        } |> ignore
```

Because the Cub does not have a transposed reduction, the author had to implement it on his own.

In order to understand what the kernel is doing, first it is required to visualize it. Imagine a 96x32 tensor and one block of size 32x32.

What that block does is covers [0,31]x[0,31] and loads from main memory, does the reduction in place with the neutral element, slides to [32,63]x[0,31] and loads from main memory, does the reduction in place with the previous state, slides to [64,95]x[0,31] and loads from main memory, and does the final inplace reduction.

```
                inl state = 
                    grid_for .y dim_in_a {state=dyn neutral_elem; body=inl {state i=j} -> 
                        inl in = in j
                        match d with
                        | {map_in} -> redo state (map_in in.get in') 
                        | {mapi_in} -> redo state (mapi_in i j in.get in') 
                        | _ -> redo state in.get
                        }
```

What was described above corresponds to this piece of code.

There are now 32x32 threads in a block, each having their own `state` which after blockwise reduction will be reduced to 1x32 and then stored into the output tensor.

```
                if blockDim.y > 1 then
                    ...
                else
                    finally state
```

Obviously if the number of outermost threads is 1 then the tensor is already reduced and can be outputted.

Otherwise a block wide reduction is performed.

```
                    inl near_to = blockDim.y
                    inl ar = 
                        HostTensor.create {
                            array_create=array_create_cuda_shared
                            elem_type=state
                            dim={from=1; near_to}, blockDim.x
                            }
                        |> inl ar i -> ar i threadIdx.x
```

It starts by defining a shared memory tensor. Immediately after creating it wrapped with a function that applies it with `threadIdx.x` along the innermost dimension. This simple technique of functional programming is greatly useful in facilitating reasoning.

Whereas previously it was needed to reason about a 2d tensor, it now becomes effectively a 1d tensor and that other dimension can be assumed taken care of and left out of mind.

Describing how to reduce a 1d tensor is not too complicated. Imagine the goal is to reduce a 1d tensor of size 8. At creation the tensor is uninitialized, so it will be described as thus.

```
01234567
________
```

To reduce it in shared memory, the right half of the threads would need to write their states into it.

```
01234567
____aaaa
```

Then a block synchronization is done and the left half of the threads (`0123`) reads from the tensor. They then performs the reduction with the `state` in their registers.

```
0123
____
```

No need to synchronize here. `23` store their states into shared memory.

```
0123
__bb
```

Then they synchronize. After that `01` read from `23` and perform the reduction with the state currently in their memory.

```
01
__
```

The process is then repeated again. `1` stores...

```
01
_c
```

...a block synchronization happens, and then `0` reads it and does the final reduction.

```
                    whilecd {
                        state={near_to state}
                        cond=inl {near_to} -> near_to >= 2
                        body=inl {near_to state} ->
                            inl by = near_to/2 // It might be worth trying `max 1 (near_to/3)`
                            if threadIdx.y < near_to && threadIdx.y >= by then ar threadIdx.y .set state
                            syncthreads()

                            {
                            near_to=by 
                            state=
                                if threadIdx.y < by then
                                    forcd {from=threadIdx.y+by; by near_to state 
                                        body=inl {state i} -> redo state (ar i .get)
                                        }
                                else
                                    state
                            }
                        }
```

What was described above is what essentially happens in the code above. The action only happens along the `y` axis which makes reasoning easy. Tensor as an abstraction and stateful loops provide a definite benefit in terms reasoning. If the above was Cuda C code, then the programmer would be forced to reason about offsets, indices, mutation and various other things.

```
|> inl {state} -> if threadIdx.y = 0 then finally state
```

After the reduction is done, the `state` which is the final result is shipped of to be outputted to `finally`.

```
inl finally result = out.set (map_out result out.get)
```

It was bound to the environment around 40 lines ago.

Before the explanation is done there also one subtle point that needs to be made about shared memory array sizing.

```
HostTensor.create {
    array_create=array_create_cuda_shared
    elem_type=state
    dim={from=1; near_to}, blockDim.x
    }
```

Based on the example shown...

```
01
_c
```

0 never gets used so it should be clear why it was chosen that the outer dimension should start from 1. It is a nice way of preserving a pinch of memory.

```
01234567
_cbbaaaa
```

But on closer examination the actual access pattern is like this.

Would it not be possible to reuse more memory so as to require only 4 slots instead of 7?

```
01234567
____aaaa
____bb
____c
```

Something like this? It would be possible, but it would increase the overall latency of the scheme because another call to synchronize would be needed between operations. Cuda makes very little guarantees about order of execution, so without an extra synchronize at the end what might happen is the `bb`s might be written before `aaaa`s finish reading.

It is easier to just use an extra tad of memory to not have to deal with data races.

##### Example

```
let kernel4 =
    "kernel4",[cuda_modules],"Does the mapi_d2_redo_map' kernel work?",
    """
inb s = CudaModules (1024*1024)

inl inner_size = 10
inl outer_size = 4

inl h = HostTensor.init (outer_size,inner_size) (inl _ x -> x)
inl h' = HostTensor.init inner_size id
inl a1 = s.CudaTensor.from_host_tensor h
inl a2 = s.CudaTensor.from_host_tensor h'
inl o = 
    s.CudaKernel.mapi_d2_redo_map {
        map_in=(+)
        neutral_elem=0; redo=(+)
        } a1 a2
Tuple.iter s.CudaTensor.print (a1,a2,o)
    """
```

```
[|
    [|0; 1; 2; 3; 4; 5; 6; 7; 8; 9|]
    [|0; 1; 2; 3; 4; 5; 6; 7; 8; 9|]
    [|0; 1; 2; 3; 4; 5; 6; 7; 8; 9|]
    [|0; 1; 2; 3; 4; 5; 6; 7; 8; 9|]
|]

[|0; 1; 2; 3; 4; 5; 6; 7; 8; 9|]

[|0; 8; 16; 24; 32; 40; 48; 56; 64; 72|]
```

It should be noted that the reduction kernel is also capable of replicating one of its arguments during the first map phase.

#### mapi_d1_seq_broadcast

This kernel does repeat reduction over items in registers along the inner dimension. It seems like a beast at first, but is actually simpler than the previous one since there is no need to understand how reduction works.

```
// Repeatedly reduces along the inner dimension and then maps the result of that reductions over the input in the previous step.
met mapi_d1_seq_broadcast' w {d with seq} in out = 
    inl to_dev_tensor = w.CudaTensor.to_dev_tensor
    
    inl in, out = zip in, zip out
    inl dim_in_a, dim_in_b = in.dim
    assert (in.dim = out.dim) "The input and the output dimensions need to be equal"

    inl num_valid = s dim_in_b
    inl items_per_thread, blockDim =
        assert (lit_is num_valid) "The inner dimension of the input to this kernel must be known at compile time."
        if num_valid <= 1024 then 1, num_valid
        else divup num_valid 256, 256
    inl gridDimY = min 64 (s dim_in_a)

    inl in = to_dev_tensor in
    inl out = to_dev_tensor out
```

This kernel will be unique so far in that it actually takes advantage of Spiral's significant ability to do local memory allocation. As the elements of the inner dimension must be known at compile time the kernel with raise a type error if that dimension is not known at compile time.

```
    inl items_per_thread, blockDim =
        assert (lit_is num_valid) "The inner dimension of the input to this kernel must be known at compile time."
        if num_valid <= 1024 then 1, num_valid
        else divup num_valid 256, 256
```

As usual, the number 256 is picked off the cuff and probably different problems will have different ideal best values, but for ML purposes this setting should suffice for the time being.

The actual kernel will be explained piece by piece as it is too much to take in at once.

```
    w.run {
        blockDim
        gridDim=1,gridDimY
        kernel = cuda 
            inl dims = {blockDim gridDim}
            grid_for dims .y dim_in_a {body=inl {i=j} ->
                inl in, out = in j, out j
```

Since kernel is in essence d1 reduction it begins by iterating over the outer dimension.

```
                /// Creates the tensor of items.
                inl create_items elem_type = HostTensor.create {
                    array_create = array_create_cuda_local
                    layout=.aot
                    elem_type
                    dim=items_per_thread
                    }
```

It is immediately followed by this function declaration. Notice that it is done in array of tuples format which is not the default for Spiral's tensors. The reason for that is that the Cub functions which accept arrays cannot accept Spiral's tensors in their default form.

```
inl inner_loop = grid_for_items dims .x dim_in_b
```

Just like `create_items` is often used, so is iterating over the inner dimension so the `grid_for_items` is partially applied for that purpose.

The way this kernel is used is that it does the initial `map_in` and then iterates over a tuple of `{map_in redo map_out}` executing each in turn.

```
                inl items = 
                    inl map = 
                        match d with
                        | {map_in} i -> map_in (in i .get)
                        | {mapi_in} i -> mapi_in j i (in i .get)
                        | _ i -> in i .get
                    inl items = create_items (type map (dyn 0))
                    inner_loop {body=inl {item i} -> items item .set (map i)}
                    items
```

Having to match on whether the mapping function is `map_in` or `mapi_in` or not there at all adds a lot of noise for the reader.

But what it does is create a tensor in register memory, iterates over the input here and sets the tensor to the result of mapping the input over the function. It is a map operation just as the name implies.

The `items` at the end is the tensor that has gone through the first phase the kernel.

```
                inl rec seq_loop items (d :: d') =
                    match d with
                    | {map_in} -> 
                        inl items' = create_items (type map_in items.elem_type)
                        inner_loop {body=inl {item} -> items item .get |> map_in |> items' item .set}
                        items'.bodies.ar
                    | {mapi_in} ->
                        inl items' = create_items (type mapi_in j i items.elem_type)
                        inner_loop {body=inl {item i} -> items item .get |> mapi_in j i |> items' item .set}
                        items'.bodies.ar
                    | _ -> items.bodies.ar
                    |> inl x -> 
```

This is the function that iterates through the sequence. First, if the `map_in` or `mapi_in` are present they get are applied to every element in the items tensor.

```
                        inl block_reduce redo = 
                            inl d = {blockDim redo}
                            if num_valid % blockDim.x = 0 then cub_block_reduce d
                            else cub_block_reduce {d with num_valid} 
                        match d with
                        | {redo} -> block_reduce redo x |> broadcast_zero
                        | {redo'} -> block_reduce redo' x
                    |> inl x ->
```

Then comes reduction. If the number of items does not exactly align with the block size, then a guarded reduction method is selected to make sure it does not read past the boundary. Also after the reduction is done there are two choices:

1) `redo` does the reduction and the broadcasts the element to every thread in the block using shared memory.

```
inl broadcast_zero x =
    inl ar = array_create_cuda_shared x 1
    if threadIdx.x = 0 then ar 0 <- x
    syncthreads()
    ar 0
```

The first thread which holds the reduced elements first writes to a shared memory location and then all the elements read from it after synchronizing.

2) `redo'` functions much like the above, but without the broadcast.

After that comes the final step. There are also two branching paths at this point.

```
                        match d' with
                        | () -> 
                            inner_loop {body=inl {item i} ->
                                inl out = out i
                                match d with
                                | {map_out} -> map_out (items item .get) x (out .get)
                                | {mapi_out} -> mapi_out j i (items item .get) x (out .get)
                                |> out .set
                                }
```

If the current element in the sequence is last, then the result of applying `map_out` or `mapi_out` to each element of `items` is feed directly into the output tensor.

```
                        | _ ->
                            match d with
                            | {map_out} -> 
                                inl items' = create_items type map_out items.elem_type x
                                inner_loop {body=inl {item} -> map_out (items item .get) x |> items' item .set}
                                seq_loop items' d'
                            | {mapi_out} -> 
                                inl items' = create_items type mapi_out (dyn 0) (dyn 0) items.elem_type x
                                inner_loop {body=inl {i item} -> mapi_out j i (items item .get) x |> items' item .set}
                                seq_loop items' d'
```

Otherwise, it needs to create a new intermediate tensor and then sets the result of applying `map_out` or `mapi_out` to each element of the `items` tensor to it. Then it passes that as input to the next operation in the sequence.

##### The Softmax Activation

The softmax activation will be covered here and the more complex layer normalization activation will be covered in the following chapter.

```
inl softmax x = exp x / replicate (sum (exp x))
```

The above is softmax in pseudo-code. `x` is a vector type.

Alternatively, it would be better to start with this...

```
inl softmax x = 
    inl z = exp x
    z / replicate (sum z)
```

`sum` sums up all the values of a vector into a scalar, and replicate unfolds the scalar into a vector each holding the same values.

Furthermore, for numerical stability the following trick is often employed in softmax.

```
inl softmax x = 
    inl max_x = replicate (max x)
    inl z = exp (x - max_x)
    z / replicate (sum z)
```

This has no effect on the way gradients are propagated during the backwards step. Derivative of  `x - max_x` with respect to `x` is just 1. `max_x` is considered to be a constant. Shifting the input to softmax by a constant does not affect the result during stable regimes, but if the inputs are unstable then they will trend towards 0 rather that towards infinity.

Going forward, it is important to keep in mind that `max` and `sum` are reduce operations, and `exp` is a map operation. The kernel described in this chapter makes it possible to succinctly implement both softmax's forward and backward phases.

Here is the forward phase.

```
inl z =
    s.CudaKernel.mapi_d1_seq_broadcast {
        seq = 
            {
            redo=max // max x
            map_out=inl x replicate_max_x -> exp (x - replicate_max_x)
            }
            ,
            {
            redo=(+) // sum z
            map_out=inl z replicate_sum_z -> z / replicate_sum_z
            }
        } (primal x)
```

The second argument in `map_out` is implicitly replicated. That is the softmax forward.

Assuming the output is present the backward step can be done in one step.

```
inl softmax x = exp x / replicate (sum (exp x))
```

For ease of rewriting the sum will be factored out...

```
inl softmax x = 
    inl s = replicate (sum (exp x))
    exp x / s
```

There are [tutorials](https://eli.thegreenplace.net/2016/the-softmax-function-and-its-derivative/) that show how to take the derivative analytically, but for show it will be done here by emulating how automatic differentiation would take the trace through the above. The analysis will have the benefit of not needing to branch on the value of the index used.

Here are a few simple rules.

```
o = a / b
da += do / b
db += -do * da / (b * b)
```

This is the AD rule for propagating adjoints (gradients) through division.

```
o = replicate x
dx += sum do
```

This is the rule for propagating gradients through `replicate`. It is a sumation.

```
o = sum x
dx += replicate do
```

The rule for propagating gradients through summation is the opposite of the previous one.

```
o = exp x
dx += do * exp x
```

With this last rule, we are all set to trace the derivative of the softmax with respect to its input.

```
inl v = exp x
inl s = sum v
inl r = replicate s
inl z = v / r
```

This is just the softmax split into individual pieces similarly to how the compiler would do let insertion.

```
inl z = v / r
```

Starting with this, the gradients are propagated through `v` and `r`.

```
// inl z = v / r
dv += dz / r
dr += -dz * v / (r * r)
```

AD is sensitive to the ordering of operations. The backwards pass needs to be done exactly in the opposite way of forward pass. This is why a tape is frequently used for it.

```
//inl r = replicate s
ds += sum dr
```
...
```
//inl s = sum v
dv += replicate ds
```
...
```
// inl v = exp x
dx += dv * v
```

Here are all the steps on the same page.

```
dv += dz / r
dr += -dz * v / (r * r)
ds += sum dr
dv += replicate ds
dx += dv * v
```

A naive AD implementation would do the above in 5 different steps. The goal of making Spiral was to allow fusion of the above steps into a single one. To start things off `dr` will be folded into `ds` which will then be folded into `dv`.

```
dv += dz / r
dv += replicate (sum (-dz * v / (r * r)))
dx += dv * v
```

Both of `dv`s can now be folded into `dx`.

```
dx += (dz / r + replicate (sum (-dz * v / (r * r)))) * v
```

Since `z = v / r` the above can be simplified further.

```
dx += (dz / r + replicate (sum (-dz * z / r))) * v
```

A valid operation here would be `sum (a * replicate b) = sum a / b`. `r` is `replicate s`. It is possible to take it out a level.

```
dx += (dz / r + replicate (sum (-dz * z) / s)) * v
```

A valid operation here would be `replicate (a * b) = replicate a * replicate b`.

```
dx += (dz / r + replicate (sum (-dz * z)) / replicate s) * v
```

`r = replicate s` as per original definition.

```
dx += (dz / r + replicate (sum (-dz * z)) / r) * v
```

The above can be simplified using the distributive law.

```
dx += (dz + replicate (sum (-dz * z))) * v / r
```

Since `z = v / r` the above can be simplified further.

```
dx += (dz + replicate (sum (-dz * z))) * z
```

Since the `-` is a constant it is possible to factor it out.

```
dx += (dz - replicate (sum (dz * z))) * z
```

In this simplified form, all the steps can easily be implemented in a single kernel. `er` is `replicate (sum (dz * z))`

```
s.CudaKernel.mapi_d1_seq_broadcast' {
    seq = 
        {
        map_in=inl z,dz -> z*dz
        redo=(+)
        map_out=inl (z,dz) er dx -> dx + (dz - er) * z
        }
    } (primal z, adjoint z) (adjoint x)
```

### 9: Deep Learning Basics

At the time of writing this it is almost April 2018.

Currently, the two dominant deep learning frameworks are without exception Tensorflow by Google and PyTorch by Facebook. Both are written in C++ and expose a Python front end from which the users access it. It is by no means unusual that big corporate sponsored frameworks would be widely used, but it is interesting to look at the deep learning ecosystems in other languages, or specifically the lack of such ecosystems. What is precisely interesting is that they are non-existent and most of the attempts at making frameworks have petered out.

In a broader sense, what ML capabilities non-Python ecosystems have tend to be on the shallower end of learning which does not need the extreme GPU capabilities Spiral has.

Deep learning has been popular for half a decade at least now, and had it been possible to make a great DL library in say F# (.NET), Scala (JVM), Haskell or Racket, then one can be sure that this would already have happened. The reason for that is that languages without first class staging have very deep flaws that preclude them from having effective Cuda backends and GPU abstractions. There is very little languages constructed in the classical manner whether they be static or dynamic offer in the making of a deep learning library.

Statically typed languages have type systems that are simply too weak to be useful and dynamically typed languages are simply too inefficient. And Lisp macros are not a substitute for first class staged functions and join points.

Hence it is easy to predict that great libraries will not get made in any of the aforementioned languages nor in any of the mainstream languages that aren't C++. The effort is simply too great and too strenuous in them. At best, .NET for example might get bindings for Tensorflow or CNTK if it has not already.

And though Tensorflow, CNTK and PyTorch are written in C++ that is hardly a beaming recommendation for the language. C++ is widely known enough that its quality as a language can stand for itself.

Making a machine learning library is hard enough to crush most langauges, but Spiral can make it a lot easier and the hows of that is what will be covered in this chapter. That being said, this is a language tutorial and not a deep learning tutorial so what won't be covered is to how to actual use deep learning to do interesting things. Instead it will be about library construction.

#### Primitives

At the time of writing the Spiral `Learning` library is quite small, but it has some advanced capabilities so this is the ideal point to introduce it before it gets any bigger. The one limitation it has on it is that it is restricted to first order [automatic differentiation](https://en.wikipedia.org/wiki/Automatic_differentiation). It would be possible to build a library that supports higher order AD in Spiral, but decision to support higher order AD is not a trivial one to make.

It would add very non-negligible maintenance burden on it, and it possibly make it difficult to provide effective optimization. Higher order AD does not have a particularly good track record on practical use in deep learning anyway.

For those not familiar with it, higher order AD would essentially allow adaptive learning methods and possibly metalearning methods like MAML, but while first order AD takes only a single pass per datapoint, higher order AD would require `n` passes per datapoint where the `n` is the number of parameters in the network. And approximated higher order methods require the whole dataset to be operated at once and do not allow minibatching.

Spiral's ML library is intended to be of great practical use. It needs to be simple to extend and understand. It needs to be both highly flexible and performant.

So the only dual number it uses internally is of the primal and adjoint variety.

```
inl float ->
    // #Primitives
    inl zero = to float 0
    inl one = to float 1
    inl two = to float 2
    inl infinity =
        match float with
        | _: float32 -> infinityf32
        | _: float64 -> infinityf64

    inl primal = function {primal} | primal -> primal
    inl adjoint = function {adjoint} -> adjoint | _ -> ()

    inl primals = Struct.map primal
    inl adjoints = Struct.map adjoint

    inl on_non_nil B ret =
        match B with
        | () -> ()
        | B -> ret B

    inl dr s primal = {primal adjoint=s.CudaTensor.zero_like primal; block=()}
```

The library takes the type of the floating point number it is operating on as its first argument. This is generally used to convert literals to `float32` values at compile time and such since Spiral does not allow implicit conversions. `zero`, `one`, `two` and `infinity` are just some constants set up for convenience.

`Struct.map` is just the `toa_map` from the tensor chapter. Since functions that iterate over arbitrary types are so often used in Spiral, they have their own `Struct` module now.

`dr` takes in context and the primal and creates a dual with the adjoint set to zero.

`on_non_nil` is just a utility function.

##### map

Map is useful for activation functions and pointwise operations like addition and Hadamarad multiplication.

```
    inl choose_adjoints in bck =
        Struct.choose2 (function
            | {primal adjoint} bck -> {adjoint bck block=()}
            | _ _ -> ()) in bck
        |> inl x -> Struct.map (inl x -> x.adjoint) x, Struct.map (inl x -> x.bck) x
            
    inl map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaKernel.map fwd primal |> dr s

        inl adjoint, bck = choose_adjoints in bck
        out, inl _ -> join
            inl bck (in, out) = Struct.map2 (inl bck -> bck (in, out)) bck
            s.CudaKernel.map' bck (primal, {out without block}) adjoint
```

In order to be flexible, while `fwd` is always a single function, `bck` is intended to be the same as the number of inputs. The reason for that is that not all variables will be dual numbers and hence the gradients won't be propagated to them. Example of such variables would the inputs and the labels for the cost function.

Here is an example of how the `map` primitive can be used to implement activations.

```
    inl activation d = map {d with bck = Struct.map (inl bck (in, out) adjoint -> adjoint + out.adjoint * (self in out.primal)) self}

    inl sigmoid_fwd x = one / (one + exp -x)
    inl sigmoid_bck out = out * (one - out)

    inl sigmoid = activation {
        fwd = sigmoid_fwd
        bck = inl _ -> sigmoid_bck
        }
```

The `activation` is there to make sure that in the backward step the adjoint is added to and that the adjoint of `out` multiplies whatever flows out from the function.

The above could also be implemented like.

```
inl sigmoid = map {
    fwd = inl x -> one / (one + exp -x)
    bck = inl (in,out) adjoint -> adjoint + out.adjoint * (out.primal * (one - out.primal))
    }
```

Though pretty much always, it is instead preferable to abstract what is possible in order to compress the code size, increase readability and minimize the chance of error. In this case this piece of advice only refers to the `activation` function. `sigmoid_fwd` and `sigmoid_bck` have been factored out due to being used in multiple places.

The following piece deserves a mention as it is the way AD is done.

```
        out, inl _ -> 
            inl bck (in, out) = Struct.map2 (inl bck -> bck (in, out)) bck
            s.CudaKernel.map' bck (primal, {out without block}) adjoint
```

All the primitive functions return the output and the function to run in order to trigger the backward step. At the time the output is made, the adjoint of it is always zero, but after the forward pass is done the adjoint at the top of tape is set to 1 and propagated downwards and eventually through that output.

As a short tutorial, remember the various rules used to take the derivatives of softmax. Here are the rules for division once again. It is the same for the matrix and the scalar case if one assumes the operators are overloaded.

```
c = a / b
da += dc / b
db += -dc * a / (b * b)
```

Here is how this could be implemented in code in Spiral.

```
inl div a b =
    inl primal = primal a * primal b
    inl adjoint = ref zero
    {primal adjoint block=()}, inl _ ->
        adjoint a := adjoint a + adjoint / primal b
        adjoint b := adjoint b - adjoint * primal a / (primal b * primal b)
```

The above assumes that `a` and `b` are scalars rather than tensors. Regardless, the structure is quite similar to the `map` which is intended to be a generic interface for such functions.

Being able to support aggressive inlining, Spiral is well suited for making AD libraries. That being said, this particular aspect of it - the ability to always inline the backward step is not particularly important for deep learning. Deep learning deals with large batched operations - a single matrix multiply is already on the factor of thousands scalar operations and what would take extreme optimization heroics by the compiler is generally put in by hand instead for such batched operations. 

What the `map` really offers is easy fusion of map operations.

```
    inl hadmult = activation {
        fwd = inl a,b -> a*b
        bck = (inl (_,x) _ -> x), (inl (x,_) _ -> x)
        }
```

Here is the standard Hadamarad multiplication. Should an operation like `a*b + c*d` be needed then it would be trivial to make a fresh activation.

```
    inl hadmult2 = activation {
        fwd = inl a,b,c,d -> a*b + c*d
        bck = 
            inl (_,b,_,_) _ -> b
            ,inl (a,_,_,_) _ -> a
            ,inl (_,_,_,d) _ -> d
            ,inl (_,_,c,_) _ -> c
        }
```

Admittedly, this example a bit unergonomic, but it is a vast improvement over having to write a separate function in Cuda for this sort of thing. It would not be difficult to make a more generic Hadamarad multiplication that looks something like this.

```
    inl hadmult' = activation' {
        fwd = Tuple.map (inl (a,b) -> a*b) >> Tuple.foldl (+) zero
        bck = inl x _ -> Tuple.map (inl (a,b) -> (b,a)) x
        }
```

The exercise for this will be left to the reader.

Being able to do such generic operations so directly is wonderful. In one sweep it is possible to cover an infinite space of possible map operations. And somewhat paradoxically, it is easier to prove generic code correct than it is specific instances of it. With this capability there is no need to worry whether one of the numerous float pointers are passed in the right order, dumb copy paste errors or array boundary violations which Cuda will not check for.

Spiral's ML library is intended to cover the middle ground between what mainstream frameworks offer and what naive AD implementations offer.

##### map_redo_map

This one is used for the cost functions.

```
    /// Does not return a `dr` unlike the rest. This is an optimization in order to avoid having to call too many useless kernels that 
    /// just to set the adjoint to 1. The current library is intended for a narrow purpose.
    inl map_redo_map {fwd bck} in s =
        inl primal = primals in
        inl out = s.CudaKernel.map_redo_map fwd primal

        inl adjoint, bck = choose_adjoints in bck
        out, inl _ -> join
            inl out = s.CudaTensor.to_dev_tensor out
            inl bck in = Struct.map2 (inl bck -> bck (in, out.get)) bck
            s.CudaKernel.map' bck primal adjoint
```

If the previous section was understood, then this one should not give any trouble. Here are the examples of two cost functions done using it and the generic template for them.

```
    inl error {fwd bck} label input s = 
        inl batch_size = primal input .span_outer |> to float
        inl div_by_minibatch_size x = x / batch_size
        map_redo_map {
            fwd = {
                map_in = fwd
                redo = (+)
                neutral_elem = zero
                map_out = div_by_minibatch_size
                }
            /// The adjoint in error is always assumed to be one.
            bck = Struct.map (inl bck (in, out) adjoint -> adjoint + div_by_minibatch_size (bck in out)) bck
            } (input, label) s

    inl square = error {
        fwd = inl (x,y) -> (y - x) * (y - x)
        bck = 
            inl (x,y) _ -> two * (x - y)
            ,inl (x,y) _ -> -(two * (x - y))
        }

    inl cross_entropy = error {
        fwd = inl x, y -> -(y * log x + (one - y) * log (one - x))
        bck = 
            inl (x, y) _ -> (x - y) / (x * (one - x))
            ,inl (x, y) _ -> log (one - x) - log x
        }
```

One design decision that needs to be highlighted is that the adjoint for the cost function is not seeded with one. Instead it is implicitly assumed to be that in the backward step. This is so recurrent nets do not have to make numerous redundant calls just to set the cost to one. One thing the `error` does as a service is automatically divide by the batch size.

Apart from the two above, the library also has the softmax cross entropy which has a more elaborate implementation due to how its backward step works so it won't be shown here. As a matter of fast, that particular implementation is not fully fused yet and that bit of work will be left for the future. 

There is one more primitive to be covered before the tutorial can proceed to the next step.

##### d2_replicate_map

```
    inl d2_replicate_map {fwd bck={bck_in bck_in'}} in in' s =
        inl primal, adjoint = primals in, adjoints in
        inl primal', adjoint' = primals in', adjoints in'
        inl out = s.CudaKernel.d2_replicate_map fwd primal primal' |> dr s
        out, inl _ -> join
            inl out = {out without block}
            s.CudaKernel.mapi_d2_redo_map' bck_in (primal', out) primal adjoint
            s.CudaKernel.d2_replicate_map' bck_in' primal (primal', out) adjoint'
```

This is is used for adding bias terms. It can also be used to implement multiplicative integration in a very easy manner.

In order to actually be suitable for implementing activations of that sort, a more focused helper method is derived from it.

```
    inl d2_replicate_activation {fwd bck_in bck_in'} in =
        inl neutral_elem = Struct.map (const zero) in
        inl bck = {
            bck_in={
                map_in=inl (in', out) in -> Struct.map ((*) out.adjoint) (bck_in in in' out.primal)
                neutral_elem redo=Struct.map2 (+)
                map_out=Struct.map2 (+)
                }
            bck_in'=inl in (in', out) -> Struct.map2 (inl x adjoint -> adjoint + out.adjoint*x) (bck_in' in in' out.primal)
            }
        d2_replicate_map { fwd bck } in
```

This one does the important part of multiplying the backwards returns by the output adjoint and adds to the input adjoint. It is similar to the standard `activation` shown in the previous section.

An example of it in use will be shown in the multiplicative integration section.

#### Optimizers

Only these two are here for the time being.

```
    inl sgd learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> P - learning_rate * A, zero) primal.empty (primal, adjoint)

    inl clipped_sgd max learning_rate s {primal adjoint} = 
        s.CudaKernel.map' (inl _ P, A -> 
            inl A = if A < -max then -max elif A > max then max else A
            P - learning_rate * A, zero
            ) primal.empty (primal, adjoint)
```

It is possible to do a frightening amount of stuff for deep learning with just a simple map. It covers all of the first order optimizers for one. At any rate, the implementation of optimizers is trivialized by the generic map and extending the library with Adam and RMSProp or whatever else would not be a problem.

One thing that the library does not do, but should is to fuse all the map calls into a single one during the optimization phase. That would not be hard in Spiral and will be subject of future work.

#### Operations

```
    inl apply_bck bck bck' _ = bck'(); bck()

    inl (>>=) a b s =
        inl a,a_bck = a s
        inl b,b_bck = b a s
        b, apply_bck a_bck b_bck

    inl succ x _ = x, const ()
```

These are used to combine AD operations in a monadic manner. `>>=` is just a specific instance of a writer monad here.

In essence, it relives the burden of having to deal with backwards step functions explicitly in a pure functional fashion. Remember that `inm a = b` is just syntax sugar for `b >>= inl a -> ...`

```
                    inm f = matmultb ((i,input.f),(h,state.f)) bias.f >>= sigmoid
                    inm i' = matmultb ((i,input.i),(h,state.i)) bias.i >>= sigmoid
                    inm o = matmultb ((i,input.o),(h,state.o)) bias.o >>= sigmoid
                    inm c' = matmultb ((i,input.c),(h,state.c)) bias.c >>= tanh
                    inm c =
                        inm x1 = hadmult (f,c)
                        inm x2 = hadmult (i',c')
                        add (x1, x2)
                    inm h' = tanh c
                    inm h = hadmult (o, h')
                    succ (h, (h, c))
```

Here is how the LSTM is implemented for example. Monadic computation saves a decent bit of boilerplate here. That being said, this is an example of a heavily unoptimized implementation of a LSTM. An optimized example would have only one or two steps rather than...21. 

#### Layers

##### Multiplicative Integration RNN

Finally in this section it becomes possible to give an example of the `d2_replicate` activation. This RNN variant is from the paper [On Multiplicative Integration with Recurrent Neural Networks](https://arxiv.org/abs/1606.06630).

In 2016 the author was impressed by the novel notion of replacing addition with Hadamarad multiplication and decided there that this is something he wanted to use since getting a good improvement for such a simple change seemed like a worthwhile tradeoff. It was not until just recently however that he managed to implement it properly. It was a long and arduous journey to get it into this form.

A short summary - the standard activation for a vanilla RNN is `f(Wx + Uh + b)`. Multiplicative integration replaces that `+` with `f(Wx .* Uh + b)`. It is possible to generalize that further by adding a bunch of bias terms so it becomes `f((Wx + b1) .* (Uh + b2) + b)`. This simplifies to `f(b1 .* Wx .* Uh + b2 .* Uh + b3 .* Wx + b4)`. The sheer amount of terms to be added and multiplied makes it challenging to write a custom Cuda kernel for. The backward step would double the number of variables to 12 as well due needing to pass adjoints. Not to mention, the biases need to be replicated as well.

The sheer effort that would be needed to implement what would otherwise be a trivial use of `map` is one of the main catalysts for the author abandoning the old F# library and creating Spiral.

So here it is presented, the multiplicative integration RNN in Spiral.

```
    /// The multiplicative integration RNN.
    inl mi size sublayer = 
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                {
                input = tanh (sublayer.size, size) s |> dr s
                state = tanh (size, size) s |> dr s
                b1 = bias s size one
                b2 = bias s size (to float 0.5)
                b3 = bias s size (to float 0.5)
                b4 = bias0 s size
                } |> heap

            apply = inl {b1 b2 b3 b4 input state} s i ->
                match s with
                | () ->
                    inm i = matmult (i, input)
                    d2_replicate_activation {
                        fwd=inl (b3,b4) i -> b3*i + b4 |> tanh_fwd
                        bck_in=inl (b3,b4) i out -> (i, one) |> Tuple.map ((*) (tanh_bck out))
                        bck_in'=inl (b3,b4) i out -> b3 * tanh_bck out
                        } (b3,b4) i
                | _ ->
                    inm i = matmult (i, input)
                    inm s = matmult (s, state)
                    d2_replicate_activation {
                        fwd=inl (b1,b2,b3,b4) (i,s) -> b1*i*s + b2*s + b3*i + b4 |> tanh_fwd
                        bck_in=inl (b1,b2,b3,b4) (i,s) out -> (i*s, s, i, one) |> Tuple.map ((*) (tanh_bck out))
                        bck_in'=inl (b1,b2,b3,b4) (i,s) out -> (b1*s+b3, b1*i+b2) |> Tuple.map ((*) (tanh_bck out))
                        } (b1,b2,b3,b4) (i,s)
                >>= inl x -> succ (x,x)
            }
```

The `tanh` activation is fused into the linear part. This did in fact make the network run a decent bit faster. It takes 4.6s per epoch on the `mini_shakespeare.txt` dataset. In contrast the unoptimized LSTM takes over 18s. It also trains a decent bit better than it, in terms of training error.

It is quite nice, when presented in this form. The matrix multiplications are still unoptimized in the ML library, so this is probably not yet its full performance.

##### Map + Layer Norm + Relu

Before this is presented, layer norm will be shown on its own. This particular implementation is without the affine factor and acts like an activation instead. It is from the [Normalizing the Normalizers](https://arxiv.org/abs/1611.04520) paper. It works great with Relus even in RNNs, and not at all with sigmoid activations.

Layer norm (pseudo-code): 
```
inl o x -> // o is some constant
    inl v = replicate (mean x)
    v / sqrt (o*o + replicate (mean (v*v)))
```

```
    inl layer_norm =
        inl fwd o i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast {
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n)
                    }
                } (primal i)

        inl bck o r i s =
            inl n = (primal i).dim |> snd |> HostTensor.span |> to float
            s.CudaKernel.mapi_d1_seq_broadcast' {
                seq = 
                    {
                    map_in=inl dr,i -> i
                    redo=(+)
                    map_out=inl dr,i sum -> dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl dr,v -> v*v
                    redo=(+)
                    map_out=inl dr,v vv -> dr,v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        top + bot
                    }
                    ,
                    {
                    redo=(+)
                    map_out=inl dv dv_sum adjoint -> adjoint + dv - dv_sum / n
                    }
                } (adjoint r, primal i) (adjoint i)

        inl o i s ->
            inl r = fwd o i s |> dr s
            r, inl _ -> bck o r i s
```

The `mapi_d1_seq_broadcast` is finally used to its full effect here. The backwards steps won't be elaborated like in the softmax section. As can be seen from the above on the backwards pass the LN is actually recalculated from the input. This is good as the cost of recalculation is pretty much nothing compared to having to do extra reads and writes from intermediaries.

Immediately after getting the above to work, the author fused the `layer_norm` with the `relu` and found that it gave a decent speedup in the RNN. The Relu activation is really trivial to add so that specific variant of LN won't be pasted here to prevent it from bloating the size of the tutorial any further.

But after that step he fused it with multiplicative integration. That came out as something really great. At this moment in time there isn't a single thing in the library that more exemplifies Spiral's approach than it. It also demonstrates the real benefit of `mapi` over the standard `map`.

The function is relatively big, so it will be done in chunks.

```
    /// Map + layer normalization + relu
    inl map_ln_relu {fwd bck_in bck_in'} =
        inl n bias i = 
            inl a,b = Struct.map (inl o -> {o without block}) i |> HostTensor.zip |> inl x -> x.dim
            Struct.iter (inl {primal adjoint} ->
                inl f x = 
                    inl b' :: () = x.dim
                    assert (b' = b) "The bias has to have a dimension equal to the input"
                f primal; f adjoint
                ) bias
            HostTensor.span b |> to float
```

`n` returns the span of the innermost dimension. Despite that it seems more complicated, but all it is doing there are boundary checks.

```
        inl fwd' o b i w =
            inl n = n b i
            inl b = Struct.map (inl {primal} -> w.CudaTensor.to_dev_tensor primal) b
            w.CudaKernel.mapi_d1_seq_broadcast {
                mapi_in=inl j i' i -> Struct.map (inl x -> x i' .get) b |> inl b -> fwd b i
                seq = 
                    {
                    redo=(+)
                    map_out=inl i sum -> i - sum / n
                    }
                    ,
                    {
                    map_in=inl v -> v*v
                    redo=(+)
                    map_out=inl v vv -> v / sqrt (o*o + vv / n) |> relu_fwd
                    }
                } (Struct.map primal i)
```

The brilliant part of this is how instead of creating a separate `seq_broadcast` in order to replicate the biases, they are instead captured in lexical scope and passed to `fwd`. What the above does is maps the input, and then passes it to layer norm and then relu.

The backward step is more involved, but fairly similar to the standard layer norm.

```
        inl bck' o r b i w =
            inl n = n b i
            inl b_primals = Struct.map (inl {primal} -> w.CudaTensor.to_dev_tensor primal) b
            inl b_adjoints = Struct.map (inl {adjoint} -> w.CudaTensor.to_dev_tensor adjoint) b
            w.CudaKernel.mapi_d1_seq_broadcast' {
                mapi_in=inl j i' (dr,i) -> 
                    inl b_primals = Struct.map (inl x -> x i' .get) b_primals
                    stack {b_primals i}, dr, fwd b_primals i
```

`mapi_in` allows a great deal of extensibility in the kernel. It allows the kernel to index into tensor out of its scope. Of course, what really happens is that they get dragged through the join point and indexed into there, but this is a good way of describing it in actual code.

```
                seq = 
                    {
                    map_in=inl bis,dr,i -> i
                    redo=(+)
                    map_out=inl bis,dr,i sum -> bis, dr, i - sum / n
                    }
                    ,
                    {
                    map_in=inl bis,dr,v -> v*v
                    redo=(+)
                    map_out=inl bis,dr,v vv -> bis,(if v > zero then dr else zero),v,sqrt (o*o + vv / n)
                    }
                    ,
                    {
                    map_in=inl bis,dr,v,norm -> -dr * v / (norm * norm)
                    redo=(+)
                    map_out=inl bis,dr,v,norm bot -> 
                        inl top = dr / norm
                        inl bot = (bot * v) / (norm * n)
                        bis,top + bot
                    }
                    ,
                    {
                    map_in=snd
                    redo=(+)
                    mapi_out=inl _ i' {b_primals i},dv dv_sum is_adjoints -> 
                        inl dx = dv - dv_sum / n

                        bck_in b_primals i
                        |> Struct.map ((*) dx)
                        // Note: The atomics make training non-deterministic.
                        |> Struct.iter2 (inl a -> atomic_add (a i')) b_adjoints

                        bck_in' b_primals i
                        |> Struct.map ((*) dx)
                        |> Struct.map2 (+) is_adjoints
                    }
                } (adjoint r, Struct.map primal i) (Struct.map adjoint i)

        inl o b i s ->
            inl r = fwd' o b i s |> dr s
            r, inl _ -> bck' o r b i s
```

Propagating the adjoints into the biases is achieved through atomics. This is actual the only flaw in the whole kernel. Whereas before the training would be fully deterministic, this causes wide swings from run to run. The author saw the MIRNN range from 160 to 180 on the first epoch. With the biases frozen it gets 163 every time which makes it look like a joke, but the author intends to continue believing in their theoretical advantages.

What the above function allows is using LN+Relu with any kind of map operation whether it be MI or something else, in either feedforward or recurrent networks. As a result the layer with the fully fused activation looks identical to the standard one.

```
    inl miln o size sublayer = 
        recurrent 
            {
            size sublayer
            weights = inl s ->
                open Initializer
                {
                input = relu (sublayer.size, size) s |> dr s
                state = relu (size, size) s |> dr s
                b1 = bias s size one
                b2 = bias s size (to float 0.5)
                b3 = bias s size (to float 0.5)
                b4 = bias0 s size
                } |> heap

            apply = inl {b1 b2 b3 b4 input state} s i ->
                match s with
                | () ->
                    inm i = matmult (i, input)
                    map_ln_relu {
                        fwd=inl (b3,b4) i -> b3*i + b4 
                        bck_in=inl (b3,b4) i -> (i, one) 
                        bck_in'=inl (b3,b4) i -> b3 
                        } o (b3,b4) i
                | _ ->
                    inm i = matmult (i, input)
                    inm s = matmult (s, state)
                    map_ln_relu {
                        fwd=inl (b1,b2,b3,b4) (i,s) -> b1*i*s + b2*s + b3*i + b4
                        bck_in=inl (b1,b2,b3,b4) (i,s) -> (i*s, s, i, one) 
                        bck_in'=inl (b1,b2,b3,b4) (i,s) -> (b1*s+b3, b1*i+b2)
                        } o (b1,b2,b3,b4) (i,s)
                >>= inl x -> succ (x,x)
            }
```

Since it takes only one instead of two backward steps, it takes 4.3s per epoch versus 4.6s for the standard `mi` RNN without layer norm. All those complicated steps shown above take basically nothing - the real overhead is in memory movement to and from global memory.

Implementing layer norm was one of the other great catalysts that drove the author to create Spiral. After 1.5 years of work, it is possible to present this piece - the fused map + layer norm + relu activation. It cannot be found anywhere else.

With the first part of the grand quest complete, the Spiral ML library finally exceeds the old one in scope.

#### Layer Combinators

The primary purpose of layers is to make it easy to initialize the weights and the biases. The secondary purpose is to allow their parallel evaluation.

Basic layer structure is this:

```
    inl gid _ = .(to string !GID())
    inl layer d = {d with gid=gid(); block=()}
```

Every layer has a `layer_type` field and a `gid` field. The `gid` field holds a unique integer literal field which the evaluator uses to distinguish between the layers and cache their results so parts of the graph aren't executed more than once.

```
    inl input name size = layer {
        layer_type = .input
        name
        size
        }
```

The input layer is rather simple. It has a `name` and a `size` field.

```
    inl stateful layer_type {weights apply size sublayer} = 
        layer {
            layer_type
            size
            sublayer
            weights
            apply
            }

    inl feedforward = stateful .feedforward
    inl recurrent = stateful .recurrent
```

Feedforward and recurrent layers aren't much different from each other. Only their `layer_type` field differs. There are other layer types as well apart from the three shown above.

Layer combinators are used to actually run and initialize the layers. And those combinators are derived from the `layer_map` and `layer_map_fold`.

```
    inl layer_map f network =
        inl rec layer_map r = function
            | {x with layer_type gid} ->
                match r with
                | {$gid=x} -> x, r
                | _ ->
                    inl sublayer, r =
                        match x with
                        | {sublayer} -> layer_map r sublayer
                        | _ -> (), r
                    inl x = f {x with sublayer}
                    x, {r with $gid=x}
            | x :: x' -> 
                inl x, r = layer_map r x
                inl x', r = layer_map r x'
                x :: x', r
            | () -> (), r
            | {} as x ->
                module_foldl (inl k (m,r) x ->
                    inl x,r = layer_map r x
                    module_add k x m, r
                    ) ({},r) x
            | x -> error_type ("Expected a layer. Got", x)
        layer_map {} network |> fst
```

`$` is the new injection pattern. `$` allows both matching and construction.

```
inl x = .a
{$x=5} // {a=5}
```

`layer_map` does bottom up mapping while caching the results. It is different than a standard map in that is allows the layers to access the previous result through the `sublayer` field. `r` is the module it uses to cache internal state.

`layer_map_fold` is similar except it also allows passing of state. This is useful for running recurrent networks.

```
    inl init s network = 
        layer_map (function
            | {x with weights} -> {x with weights = const (weights s)}
            | x -> x
            ) network
```

This is how `init` is made. If the layer has a `weights` field it is passed in the context `s` and that returns the network weights after the function has been evaluated. Though rather than just setting weights to that, it wraps it in a function.

This has the property that if the layer is reinitialized later, those parts that have already been initialized are not affected. The reason why this is done is that the net might have a body, but also branches that might need to be initialized separately.

```
    inl init_parallel s network = 
        layer_map (function
            | {stream} | {layer_type=.input | .parallel} as x -> x
            | {x with weights} -> {x with weights = const (weights s); stream=s.RegionStream.allocate.data.stream}
            | x -> {x with stream=s.RegionStream.allocate.data.stream}
            ) network
```

`init_parallel` extends on the standard `init` by also allocating a Cuda stream and storing it into the layer which can be used to execute layers in parallel.

```
    inl run x d s =
        layer_map_fold (inl {x with layer_type gid} d ->
            match layer_type with
            | .input -> d.input x.name, d
            | .stateless ->
                inl value, bck = indiv join
                    inl a, b = x.apply x.sublayer s
                    stack (a, term_cast b ())
                value, {d with bck = apply_bck self bck}
            | .non_differentiable ->
                inl value = indiv join x.apply x.sublayer s |> stack
                value, d
            | .parallel -> x.sublayer, d
            | .feedforward ->
                inl value, bck = indiv join
                    inl a, b = x.apply (x.weights()) x.sublayer s
                    stack (a, term_cast b ())
                value, {d with bck = apply_bck self bck}
            | .recurrent ->
                inl state = match d.state with {$gid=state} -> state | _ -> ()
                inl (value, state), bck = indiv join
                    inl a, b = x.apply (x.weights()) state x.sublayer s
                    stack (a, term_cast b ())
                value, {d with bck = apply_bck self bck; state = {self with $gid=state}}
            ) x d
```

For every layer, this function applies it and takes care to store the backward steps. It also term casts them so the compiler does not diverge for recurrent nets. Note that the results in the bottom layer are stored in the `sublayer` field as noted previously. The state on the other hand is passed through `d`.

The way to imagine the graph being executed is to think of values flowing upwards from `input` layers through the `sublayer` nodes all the way up to the single node at the top. Inputs are passed vie `d` to the input fields and are accessed by name.

##### A Note On Compilation Times

    There is some funny stuff with `indiv join` and `stack` going on. Throughout the source code of the library there will be such patterns used throughout. They have only a single purpose - to optimize compile times.

    When the author first made the LSTM work he received a shock in that it would take 4s to compile and adding another layer would add 2s to compilation. Considering that the nets he intends to train will be deep, the realization just how slow Spiral is made him lose his nerve. He first idea was to maybe rewrite the language in OCaml. He already considered it once before to do it Racket, but that fell through.

    The second idea to spread join points and layout types around more readily. As it turns out that turned out to be greatly effective at crushing the compile times to around 1s and a negligible increase for each layer added. What was surprising to him not just how effective join points were at reducing compilation times, but that some of the functions which had no effect at runtime (like the kernel auxiliaries) and only did assertions and shape checking had a large impact on compile times as well.

    The author thinks it might be possible to optimize compile times further, but he is at a loss as to how to do it past this point. He would welcome reviews from others on this part.

    Some of the things he tried like flattening the AST that he thought would have benefit made absolutely no difference to performance. Things like optimizing the way `Op`s are represented would severely undermine the ergonomics of the compiler. Parser could be sped up significantly, but it is not a overhead. Actually it is, but it is not the one that is bothersome.

    The partial evaluator is an enigma - reason tells that it is already fast for the kinds of work it is doing based on a rough comparison with other compilers. It is probably even faster than most other functional languages simply due to how simple it is. On the other hand, if the kinds of things it is doing can't be made any faster that bodes ill for not just Spiral, but for the future of programming languages.

    To put it like this - if Spiral was 10x slower than it was now, then it would be much less useful. If it was 100x slower then there would be no point in using it. This value estimate goes into the other direction as well. Spiral would be a lot more valuable if it were 10x faster. Performance simply matters everywhere and always - compilers are not the exception.

    There might be some novel kinds of abstraction in the future that will be out of reach because the compilers are too sluggish to deal with them in practice.

    The author is pessimistic on the future of software development because of this. There simply does not seem to be any replacement for the immutable data structures Spiral uses internally. They make it flexible and powerful, and they do not make it slow, but they place a ceiling on its performance.

    It is just as well that he is interested in machine learning. Compared to classical programming, optimization methods have almost limitless potential to improve from here.

```
    /// The wavefront iteration optimization.
    /// Requires the non-input layers to have preallocated streams.
    inl run_parallel x d s =
        layer_map_fold (inl {x with layer_type gid} d ->
            match layer_type with
            | .input -> {value=d.input x.name; stream=s.data.stream; block=()}, d
            | .parallel -> x.sublayer, d
            | _ ->
                inl stream = x.stream
                inl s = s.data_add {stream}
                inl values = Struct.map (inl {value} -> value) x.sublayer
                inl streams = 
                    Struct.choose (function
                        | {stream=x} -> stream.wait_on x; x
                        | _ -> ()) x.sublayer

                inl wait_bck b =
                    inl b _ =
                        b ()
                        Struct.iter (inl x -> x.wait_on stream) streams
                    term_cast b ()

                match layer_type with
                | .stateless ->
                    inl value, bck = indiv join
                        inl a, b = x.apply values s
                        stack (a, wait_bck b)
                    {value stream block=()}, {d with bck = apply_bck self bck}
                | .non_differentiable ->
                    inl value = indiv join x.apply values s |> stack
                    {value stream block=()}, d
                | .feedforward ->
                    inl value, bck = indiv join
                        inl a, b = x.apply (x.weights()) values s
                        stack (a, wait_bck b)
                    {value stream block=()}, {d with bck = apply_bck self bck}
                | .recurrent ->
                    inl state = match d.state with {$gid=state} -> state | _ -> ()
                    inl (value, state), bck = indiv join
                        inl a, b = x.apply (x.weights()) state values s
                        stack (a, wait_bck b)
                    {value stream block=()}, {d with bck = apply_bck self bck; state = {self with $gid=state}}
                ) x d
        |> inl x, d -> Struct.map (inl {value} -> value) x, d
```

The wavefront iteration is from this [NVidia blog post](https://devblogs.nvidia.com/optimizing-recurrent-neural-networks-cudnn-5/).

`run_parallel` is similar to `run`, but takes advantage of streams to perform the wavefront iteration optimization. The benefit of it is nowhere near as described in blog post - it is more like 20% in practice, but it is a good 20%. Unless there is a reason not to, `run_parallel` should be used instead of `run`.

The author also tried to stream gemms as per that post, but got absolutely horrible results. For one, it is quite more difficult to use streams inside the layer instead of between them like in the above function.

The first attempt to do is was to allocate them dynamically in order to avoid passing them around, but as it turns out, streams are insanely expensive to allocate so that plan fell through. The second plan was to preallocate and them pass them in, but that would just be too nasty - even if it worked it could potentially lead to data races for some kinds of operations so it was scrapped. It would have made the code too convoluted to bear with.

The problem with the Cublas gemm is that they are simply too inflexible, not that they need to be streamed. Resolving that will be future work.

There was an episode a month or so back when the author really wanted GC for Cuda memory and seriously considered rewriting Spiral in something else. Eventually, after trying out the above optimizations and thought about Cuda streams in more depth, he realize the problem was not just Cuda memory. Even if were possible to GC it somehow, GC cleanup and allocation might cause inadverted memory sharing in the presence of streams.

Streams are probably the most poorly designed of all the Cuda features; not only do they block potential GC, they are so hard to reason about that they are barely usable. Preallocating them and using them for the wavefront iteration like this is probably their one blessed use. In all the other cases, actually fusing the kernels would be a far better choice.

Within the confines of the ML library there is no problem in using them for the wavefront iteration, but if memory sections are shared with something else, there might be ways of causing memory corruption. In general, that should not be a worry though.

#### Loops

The loops in this context refers to the functions that run the net once. Here they are for feedforward nets.

```
        inl train {d with network} =
            inl rec loop c cost' = 
                function
                | .unwrap -> cost' / to float64 c
                | input s {on_fail on_succ} ->
                    inl cost, {bck} = run network {input state = {}; bck=const ()} s
                    inl cost' = cost' + to float64 (s.CudaTensor.get cost)
                    inl state = loop (c+1) cost'
                    if nan_is cost' then on_fail state
                    else
                        match d with
                        | {optimizer} ->
                            bck()
                            optimize network optimizer s
                        | _ -> ()
                        on_succ state
            loop (dyn 0) (dyn 0.0)
```

The loop has to do a bunch of things while it is running like abort early on nans in the cost, keep track of costs, call the backwards step and the optimizer. This is something that takes care of that.

```
        inl test {d with network} =
            inl rec loop c cost' accuracy' accuracy_max' = 
                function
                | .unwrap -> cost' / to float64 c, accuracy', accuracy_max'
                | input s {on_fail on_succ} ->
                    inl (cost, {value max}), {bck} = run network {input state = {}; bck=const ()} s
                    inl cost' = cost' + to float64 (s.CudaTensor.get cost)
                    inl accuracy' = accuracy' + s.CudaTensor.get value
                    inl accuracy_max' = accuracy_max' + max
                    inl state = loop (c+1) cost' accuracy' accuracy_max'
                    if nan_is cost' then on_fail state
                    else
                        match d with
                        | {optimizer} ->
                            bck()
                            optimize network optimizer s
                        | _ -> ()
                        on_succ state
            loop (dyn 0) (dyn 0.0) (dyn 0) (dyn 0)
```

This one takes care of accuracy and the max accuracy.

Both of `train` and `test` hold their state internally and are unwrapped at the end of the epoch. `train` and `test` are passed in as body for the `for` function.

```
    inl outer data =
        Struct.foldl (inl s x ->
            match s with
            | () -> fst x.dim
            | s -> assert (s = fst x.dim) "The data tensors need to have the same outer dimension."; s
            ) () data

    inl for {data body} s =
        inl {from near_to} = outer data
           
        Loops.for' {
            from near_to
            state=body
            body=inl {next state i} ->
                inl data = Struct.map (inl x -> x i) data
                s.refresh
                inl s = s.RegionMem.create
                state data s {
                    on_fail=inl state ->
                        s.RegionMem.clear
                        state.unwrap
                    on_succ=inl state ->
                        s.RegionMem.clear
                        next state
                    }
            finally=inl state -> state.unwrap
            }
```

Until now, no mention whatsoever has been made about how the library manages memory, so this is a good time to do it.

```
inl s = s.RegionMem.create
```

The context has `RegionMem` and `RegionStream`. When `.create` is passed into them a new region is created. That does not actually allocate any memory or streams, but instead allocates a new region. Under the hood, the region is a resizable array that holds all the references allocated through it.

```
s.RegionMem.clear
```

When this is called, all the references in that region have their count decremented by 1 and if that count is 0, they are set to null. For feedforward nets, that means the allocation always get cleared since their references are never shared with other regions.

That does not actually dispose of the memory however.

```
s.refresh
```

It is this thing that does so. It filters out all the references set to null and rebuilds the free cells. It can be thought of as the equivalent of doing a GC run. This system is nowhere as good as actual GC in terms user ease or flexibility, but it should suffice for neural network needs. It can be improved to support things like very short term allocation without having to clean up everything, but that will be future work.

```
                state data s {
                    on_fail=inl state ->
                        s.RegionMem.clear
                        state.unwrap
                    on_succ=inl state ->
                        s.RegionMem.clear
                        next state
                    }
```

Note that `state` here is either `train` or `test`. The `for` loop shown is a bit unusual in that the mapping function for it is also the state. The reason for that is because it is the easiest way of initializing the state. Rather being split into two, everything `train` and `test` need are right there where they should be.

Doing it like that is a straightforward OO pattern in Spiral, but would be untypable in other static functional languages.

The recurrent networks have their own `train` and will have `test`, but they are beyond the scope of this tutorial. They are more complicated, but have exactly the same purpose. Both feedforward and recurrent nets have their own dedicated gradient checking function which are useful for testing additions to the library.

This covers all the important parts of the library. 

Fundamentally, ML libraries are not something to be worked on forever which is the unfortunate situation author found himself in. Much like parser combinators resolve the need for external parser generators, so can a ML library be fashioned in a similar vein. The greatest feature Spiral offers to the user is that it easily makes it possible to craft pieces like `map_ln_relu`. It is in turn made out of flexible pieces like `seq_broadcast`. They free the user of the drudgery of low level C programming and allow more a direct expression of desire. They also enable a vast amount of code reuse. Furthermore, Spiral's approach to programming allows the library an absolute level of integration with the language. This will be greatly useful when the time comes to make use of it as a module in a reinforcement learning context.

`map_ln_relu` is just the tip of the iceberg and this can be considered the first unfinished release of the library. But compared to all the work that was needed to make both the language and get the library to this point, the rest should be much easier. The great up front expense has been paid in full.

#### Example - Feedforward Net On Mnist

The examples are just to give a feel for how the code looks like in practice. 

```
let learning9 =
    "learning9",[cuda_modules;learning;mnist],"Does the full training work with Mnist?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl minibatch_size = 128
inl { test_images test_labels train_images train_labels} =
    inl mnist_path = @"C:\ML Datasets\Mnist"
    Mnist.load_mnist_tensors mnist_path
    |> s.CudaTensor.from_host_tensors
    |> module_map (inl _ x -> x.round_split' minibatch_size)
```

This is a handy loader just for Mnist. Tensors have the `round_split` and `round_split'` methods in them that split the outermost dimension to `(minibatch_size,rest)` and `(rest,minibatch_size)`. So the shape of the tensors after the above would be `(rest,128,784)` after the above operation with the `rest` being statically known.

```
inl input_size = 784
inl hidden_size = 10

inl network = 
    open Feedforward.Layer

    inl label = input .label hidden_size
    inl network =
        input .input input_size 
        |> ln 0.0f32 256
        |> linear hidden_size 
        |> init s
    inl train = error Error.softmax_cross_entropy label network
    inl test = parallel (train, accuracy label network)
    {train test}
```

The layers can be easily piped using the `|>` operator. There is no danger of failing to connect layers like this and no need to write unit tests for this purpose like some other libraries require the user to do.

```
Loops.for' {from=0; near_to=10;body=inl {next} -> 
    open Feedforward.Pass
    open Body

    inl cost =
        for {
            data={input=train_images; label=train_labels}
            body=train {
                network=network.train
                optimizer=Optimizer.sgd 0.3f32
                }
            } s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        inl cost, ac, max_ac =
            for {
                data={input=test_images; label=test_labels}
                body=test { network=network.test }
                } s 

        string_format "Testing: {0}({1}/{2})" (cost, ac, max_ac) |> Console.writeline
        next ()
    }
```

Prepare the dataset, define the network and then run it. This is the part that does the last one. The really salient parts are those where it calls the `Learning` `for` function. The rest is just standard IO and checking for Nans.

```
        for {
            data={input=train_images; label=train_labels}
            body=train {
                network=network.train
                optimizer=Optimizer.sgd 0.3f32
                }
            } s
```

This is succinct enough that it actually does not need any further comment. One thing that would be good to mention is that since Spiral loves statically known dimensions, the `split_round` functions tend to throw away the excess in order to keep the tensor regular. So the test set rather than having 10k examples will have 9984 examples.

```
Training: 0.309259804475129
Testing: 0.157295000082694(9493/9984)
Training: 0.114737567477899
Testing: 0.111421216703139(9622/9984)
Training: 0.0818591211150345
Testing: 0.0956207461153658(9671/9984)
Training: 0.0638285737313553
Testing: 0.0879654984933157(9693/9984)
Training: 0.0516892505001723
Testing: 0.0810565133280575(9715/9984)
Training: 0.042687166776731
Testing: 0.0776575743668498(9724/9984)
Training: 0.0355717467236667
Testing: 0.075778437509703(9734/9984)
Training: 0.0297816385700105
Testing: 0.0741259951931007(9747/9984)
Training: 0.025186768730975
Testing: 0.0730099095739066(9750/9984)
Training: 0.0212900042135873
Testing: 0.0725844820121076(9749/9984)
```

Layer norm + relu works rather well as an activation given how they hit 95% in the first epoch. This is almost on par with batch norm. The Mnist test is useful for ensuring that new additions to the library are implemented correctly.

#### Example - Recurrent Net on tiny_shakespeare

Prepare the dataset.

```
let learning11 =
    "learning11",[cuda_modules;timer;learning],"Does the full training + sampling work with the char-RNN?",
    """
inb s = CudaModules (1024*1024*1024)

inl float = float32
open Learning float

inl size = {
    seq = 1115394
    minibatch = 64
    step = 64
    hot = 128
    }

// I got this dataset from Karpathy.
inl path = @"C:\ML Datasets\TinyShakespeare\tiny_shakespeare.txt"
inl data = 
    macro.fs (array char) [text: "System.IO.File.ReadAllText"; args: path; text: ".ToCharArray()"]
    |> Array.map (inl x -> 
        inl x = to int64 x
        assert (x < size.hot) "The inputs need to be in the [0,127] range."
        to uint8 x
        )
    |> HostTensor.array_as_tensor
    |> HostTensor.assert_size size.seq
    |> s.CudaTensor.from_host_tensor
    |> inl data -> data.round_split size.minibatch

inl minibatch,seq = data.dim

inl input =
    inl data = s.CudaTensor.to_dev_tensor data 
    s.CudaKernel
        .init {dim=seq,minibatch} (inl seq minibatch ->
            data minibatch seq .get
            )
```

This last part where the init is called transposes the dataset to the sequence of minibatches from a minibatch of sequences.

```
inl label = input.view_span (const {from=1}) .round_split' size.step
inl input = input.view_span (inl x :: _ -> x-1) .round_split' size.step
inl data = {input label}
```

The labels are just the inputs shifted one to the left. Then they are split so that the final dimensions of the tensor are `(rest,64,64)` where the middle 64 is the number of steps and the innermost 64 is the minibatch size.

Define the network.

```
inl network = 
    open Recurrent.Layer
    
    inl label = input .label 1 |> encode.one_hot size.hot
    inl input = input .input 1 |> encode.one_hot size.hot

    inl body =
        input
        |> miln 0.05f32 128
        |> Feedforward.Layer.linear size.hot
        |> init_parallel s

    inl train = 
        error Error.softmax_cross_entropy label body
        |> init_parallel s
    
    {train body}
```

The `encode.one_hot` is a layer that does encoding into the one-hot vector.

Then here is the part that runs the network. It is similar to the feedforward case.

```
inb _ = Timer.timeit "whole loop"
Loops.for' {from=0; near_to=5; body=inl {next i} -> 
    open Recurrent.Pass
    open Body

    inl cost = 
        Timer.timeit (string_format "iteration {0}" i)
        <| inl _ ->
            for {
                data
                body=train {
                    network=network.train
                    optimizer=Optimizer.sgd 0.01f32
                    }
                } s

    Console.writeline "----"

    sample 0.6f32 2048 network.body '\n' s

    string_format "Training: {0}" cost |> Console.writeline

    if nan_is cost then
        Console.writeline "Training diverged. Aborting..."
    else
        next ()
    }
```

The key differences are - there is timing code, there is the `sample 0.6f32 2048 network.body '\n' s` function in the middle and there is no test pass.

Here is a sample run.

```
Starting timing for: whole loop
Starting timing for: iteration 0
The time was 00:00:04.6501455 for: iteration 0
----
Sample:
wing somest gooteded, and, singe,
The to betith in sumese the pearated.
Whis in sallers,D you and(ed ansting the if the thou hinser, storsuld,
And of in coment not in whatss,
Ind thin bevers,ing in drain,
The trust,
And the sake thisher, and the that the deake wast,
And all of marst the thatpen and at cond waiching to thessirserent,:
Sill I here.

Thand the be thered lows,
I and you cand I and tringher,
Bre this the me that
Thenens
Anded I thingent then, sursted the peave were the whingerew the mane
The be, coeld me the wave, the cour:
I the thend bete the deact, sird you make to the at wither.

Thery oreded mors beno, ripe comering thise dore siandsure,
As::
What now the misest wearse
Thoughty,
Thouping the the ceelles ourte.
The farthersest now
And at is wither, and that hath I with in you diantaces, the wast
And all in,
And the and ast yourd the the ceeptingers
I his of the siand thend that to way, bytherest theard the not to the is thet the wime, themell the thisser:
That thees,
And the wantersed be,
Ind asenoon,Theres,
Hereest to hard wers of in the of with yishinging this the mastereds,
And cakere thes in brony and of forderselt:
Then to gout, store torate the that?

MELIR:
The will of fand the is's porto the thet save wed nothtont of thenciint, ind,
To me,
And is with in and thenesand and himing wish not strogh
And wither,
And to dearons and m| mair beast a the whinges and the whath, as tomes, of my then the the that wis;
Bing, I good, make the stoll ot I me siet stome there sught.
Thenetront,
And the to wime betore an thou lodser:
And she for the this in your to meang't, sien and hourituteround.

LARA:
I werainert
ThertedE
I laveres?
To lading inest the thend
Yould, will wionds
And the hearf in goed ther,
But our of wach, the wagk
'ot pith and not to dearse the bute.

SIINO:
And his this fore thisest note,
Hear'd ather's and mask?

KIIIIO:
Thend and the wout.y this, fave and lathers, buster.

SIO:
And pare, Hinged in the couthar yourstast the and it lingels, lard whe sith histound on ond thourd in
-----
Training: 170.018245865317
Starting timing for: iteration 1
The time was 00:00:04.6143145 for: iteration 1
----
Sample:
Now therenowerad's forthy all the distarion theeld and and and the blainise is the trues
Sire, on to be the onound our lord and betion singed lord.

PUCES:
Thenet is lord of the courteday,
The and halood a mone of the coundey countien words thou with is thou all toome sonerites ourself your with the and to there and tongues enday, of not came the of apoing to fallow and that how's it that to muding bove to beting the look of singanes
Well to beastien madys, his as to to the devend and thenese lird is bother of refore, of our to apour.
That bunder,
To fars to their the parioule.

OUCELIO:
Ore with it distlation of with so, and earded to him a worce whing the gooke to sourt that to the sontle upon the biend that be and it that with tayer hport and and to that of the to then the foold porn the po that is wither the with thenenoloue one to sonery come are parding the know lead in land you dirst the rad the tood comes have yet hare and the sire and stard to seariens and that revererow(
And of then I mare
in then the to somered his are the prother<ing thou with thy lonted, and bothing thou may horeferst
I come to the to and that am their will then deariour and bray be and betrows thou toole afere to that and and turation you way, and the stole will sindares0er:
I saye, and his beanied thou asear,
And are of too hishers
My the beis to hinging the wirl wasting the dayes, then the known the sanded, and to in not ture the wortle thou to the word.

under forterald thee this thought as pake dainice lot hast to theight hather,
Belood is ase the mahe tonest to
So thou hathous tain to there astand them of is the downatterse: moy bearsice and thou sould to thes, to are thou and not to sunatard dearce?

POUDARO:
And took, to come beating the your a may they with the eagen,
To to my that in fore to thereford,
And mare the west in to thisker. I upon the power this downiald be songert as as to th|inus to piet more nother theee and and to to to thou thou and therede then of asse,A:
To to drood,
Nobe, becain I told the will thou how
-----
Training: 130.864040150362
Starting timing for: iteration 2
The time was 00:00:04.5930354 for: iteration 2
----
Sample:
ridown of, and seeping the with of this is loved that bold that padyed and your the bedang kauch of bess thought to thou live,
The king, thou hast, thou sire of the till this thoughtders the everied,
For to shall my to to him the constance of toot and that therefore and sonronion
Thou gince,
Mard, and bard,
And dastertart the surseding the sware.

PETEN:
Your love, the sentle,
And but all the can to feres say is conferty this to but with that again, fallon that stome arm not I are the sealt forting the fored,
The tonely, them thou sine now that to the sinter, m|inger down the surtion less.

First toous are to mare Hartery forst, that soorerage, bard letten,
Have of in are with of the provedious the lord:
I other in the romaster him, art of will thy soke sound.

POUMENTIO:
Dose:
And thou will wister all seed fare
And souls to to dost that toome all
sleast us this the lick, and to doingsy head!

ANTIO:
Comence are that as the make told bear,
What hand the deal your losk to my lord!

PETCANDNO:
Ward, of the might and fortly manrrngness,
That hawe of butise Buty are mone my loves;
Here, make the vant;
And hpard, the will the good, fortows and the with to the word and not hearing of the to fartor.

ALIUS:
My that I landly comenion would what every not to lord;
These with though his ever will with father, and but with all stiding, Edward,
And down: father, with now the encition:
Sack met your hand of have is then in the thought your hearts,
As my of mander stearself oftle manion the king they well.

KING RUCHARD III:
Weres the ling my fands you on the great and hpards the sile, in their comest the say as as a ment,
The looks of soncease sir thou beangled botter'd and then throst the stant forkented to the will of hath hpard that is beit though a seem the stand the sakes of the day hearted,
Would with and the with this the west be to the doughtere you gime hath the contence.

KING IO:
Herecome,
The fard the cance ases to the word's wears,
Hend with then the erterver:
Fore fallon and the peanion'sted.

GORINGLAN:
Some th
-----
Training: 120.591899198644
Starting timing for: iteration 3
The time was 00:00:04.6190544 for: iteration 3
----
Sample:
rest worther that lork
To the seaven the pard that branch and where bray and his with the word mamallue that of the tower fast in the forsed but of is like his to the bust m|ine thy forther a thou stard thou are come to soes and but in that to with thou coot man spord and never of the world ressibing be father for the fall would were to the some stain, truch sorford,
To be so this to the wards this say the to buny of be thy sir, strut thou falled to and to be the king.

ARCISTEN:
Sir, whose fair, his day, are my last in this this but to to thou lord.
owe the it.
Mare's pardous in the confort of your have with thou to be by the backers, that thou is this litter to the can poor your fail toome heart:
And the stant should to the king of his dread of thy of the of the caunted say stay the rawell, and take thou how it that shall thou strenhon our king
Whow a sing the to me sold abeary ware, cale to my pown.

DERENTER:
Where should of the counter be toot, the hand, be prain so entrant thou carn, it the might with the purilit the will to the sucting mistruck at is to the seaver mone too lood not diest the ere his warther of the well my lord, this counst of a son, beden the fourtion of her to adiend, thoo both of his be proms the with at before of the fail the kingl| the surse thereing be chook of this of dowers seaster is sporisher returm hus a to blousing a that to denself,H:
How is but the shall m|ot come the horst both as of the strank we wife ble?
And the it resign: and thy she do think not sirtus as the world hd holl me sower the gate a farle the surve say that drantly show, and thousence
Romeos.

PETROLIO:
Thy may not some is that with tpost it that well the complain the rest mine forturess in to the to the should not mucked hpard unterding thy love is this strants of so confort did make of my lord hand the lord, lost of the shall to say the man a my lord:
And you to the coursely man all thou gran murse to the way to the king a brotce.

GLOUCESTER:
My fall you go, I say good that for and a sind to of man if yo
-----
Training: 114.656255665947
Starting timing for: iteration 4
The time was 00:00:04.6133752 for: iteration 4
----
Sample:
the king
And rothy of thou lord, my trient our hath young rest lpettard tporcious are and most a was sould hlast tpose more his tords:
The darther are to thou farsing in
Sir, their command a manis me npard tpough for.

QUEEN ELIZALUSNE:
You son,
And thou vard is fires thou worst tporst that the man well in that at hland master's son, with in his man this live.

POLARUS:
But life, word!

MENENIUS:
What where or your bear me tpought for man are th|in tpose of word and npard0ent, the deping the strunch and of happy the long widims
There of your hast of did say, and but but is consignds husbard own beseefords of seeding, thou sound of that ment,
And thou fortion thou man the courte, good of this with that lands to him, and are bring then Seevous not son; and one of the doth the stand it hand days
What my mardiomer:
And my the down that did birdured were best soining do with of therefore that kind which more thou what with you all for to than my one of minder('s sirst and with him mone to drand.
eloss better I purstian;
And name.
To make are unto thy hand that shall be so.

Thisineding thou day dood of what to him such mand his time; us bispited hlard and say is the blatten are in holy sings.

HENRY CANIE:
That with thou wpand with mistrous that words missenself!

CORINA:
Goother fdow you are thou have be come to to the wprown had tpought is meation, my life, monaster the call the ronds so such it, and surved the mast that fake that would thou re.

KING RICHARD III:
Bath the parton but rather constains, my exery as be in must,
For of ma,
this shall sir, be the promes us would and as this is to comes
And m|orant tooblain of know m|halst whose of must hd parton it it is to have lady, and how so king send thou are sear to this reason; a word to comes with and tpough, I diveress
And the sirrle sir;
Why, like the sont.

Second to tpatter, our farding is they but grace the part as some of cannot say, the falt our thou not thou lord.

ROMEO:
And to took in seaven of friar it thou propost stands thou am for from the last in
-----
Training: 110.771023666157
The time was 00:00:25.4366961 for: whole loop
```

The net does not take long to start spouting Shakespearean sounding gibberish. Better nets and bigger datasets would improve performance no doubt. But this run is just intended to be equivalent of Mnist for recurrent nets. It would be possible to shave 0.3s from the runtime of each epoch by preprocessing the dataset more, but this way is the most convenient for when sampling is done.

Based on looking at the above, it is clear even a tiny recurrent net with only 128 hidden units and a single layer is capable of learning a great deal of the structure of the dataset which is what the test intended to demonstrate.

The author is definitely curious how a net with multiple layers and dilated connections would learn. That will definitely be subject of future work.

### Known Bugs

1) Passing `nan`s through join points causes the compiler to diverge. Since join points use structural equality for memoization and `nan = nan` is always `false`. That means that they cannot be compared and will always result in a new entry to their dictionary at join point boundaries. Note to numerical standards designers - don't do this again! Comparing `nan`s should be invalid, but returning `false` is not the answer.

2) `.NET` will happily marshal non [`blittable`](https://docs.microsoft.com/en-us/dotnet/framework/interop/blittable-and-non-blittable-types) types past language boundaries corrupting memory and writing past the ends of the arrays. Spiral will give a type error at join points, but it is still possible to corrupt memory using transfer functions which aren't doing proper checking.
