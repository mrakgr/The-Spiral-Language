<!-- TOC -->

- [News](#news)
    - [12/24/2020](#12242020)
- [The Spiral Language](#the-spiral-language)
    - [Overview](#overview)
    - [Getting Spiral](#getting-spiral)
    - [Status in 12/24/2020](#status-in-12242020)
    - [Projects & Packages](#projects--packages)
    - [Top-Down Segment](#top-down-segment)
        - [Compilation](#compilation)
            - [TODO - Expand the compilation options](#todo---expand-the-compilation-options)
        - [Basics](#basics)
        - [Join points](#join-points)
            - [TODO - Join points and language interop](#todo---join-points-and-language-interop)
        - [Functions](#functions)
        - [What triggers dyning?](#what-triggers-dyning)
        - [Macros](#macros)
        - [Layout types](#layout-types)
        - [Nominals](#nominals)
        - [Symbols](#symbols)
            - [Symbols And Records](#symbols-and-records)
            - [Symbols And Pairs](#symbols-and-pairs)
                - [Symbols And Unions](#symbols-and-unions)
        - [Prototypes](#prototypes)
    - [Heap Allocation vs Code Size](#heap-allocation-vs-code-size)
    - [Bottom-Up Segment](#bottom-up-segment)
        - [Functions](#functions-1)
        - [Branching](#branching)
            - [Loop Unrolling](#loop-unrolling)
            - [Compiler Crash](#compiler-crash)
            - [Print Static](#print-static)
        - [Type Inference](#type-inference)
        - [Real Nominals](#real-nominals)
        - [Serialization](#serialization)
            - [Pickler Combinators](#pickler-combinators)

<!-- /TOC -->

# News

## 12/24/2020

Spiral 2 has been released on the VS Code marketplace yesterday!

v0.2 is now just v2.0. This way of versioning will work better with the way VS Code marketplace does it, namely `<major>.<minor>.<patch>`. I want to retain the option to move up the minor versions in the future. That won't work if `0.2` freezes the major and the minor fields in place.

The next are the docs. In truth, the testing phase for the language should have been done for a while longer, but I decided to push up the publication. It is better this way. Rather than trying to force tests, I'll find and resolve bugs organically as I go along. Doing the docs will also force me to cover the features of the language in depth.

Let me start with the overview.

# The Spiral Language

## Overview

As the world inexorably hurls towards the black maw of tomorrow, the power to face it is needed.

Throughout the history of programming languages, the choice was between fast or expressive; the two traditions are crystallized by the C and the Lisp family of languages. There has been a lot of effort into this, but always as languages developed and moved forward they stepped away from the bare metal and in turn lost some of that core vitality that is needed for performance.

The culprit for this is the heap allocation by default dogma introduced by Lisp decades ago. It is a crutch for languages with weak type systems.

Abstraction by heap allocation is a dead end. It works moderately well on the current generation of computers where CPU is still the dominant driver of computation.

It cannot work for devices like GPUs and the rest coming down the line. Many of the most important computational devices of the future won't support heap allocation so an alternative is needed to draw out their full power. It is of absolute importance that a language for that task have excellent control over inlining. Inlining, therefore, must come as a guarantee in the language and be a part of the type system.

Inlining is a trade-off that expresses the exchange of memory for computation. It should be the default instead of heap allocating.

A language good enough at propagating information so as to be capable of expressing inlining guarantees is also powerful enough for expressing a lot of other things well - without any abstraction overhead.

* Structural introspection through pattern matching not just for unions, but for all core types.
* Seamless interoperability between different language backends.
* First class functions, pairs, records and unions.
* Composable layouts of data structures.
* Symbols as singleton types.
* Top-down type inference via unification
* Extensibility via prototypes.

Spiral is such a language.

Statically typed and with a lightweight, very powerful type system giving it expressiveness of dynamic languages and the speed of C, Spiral is the crystallization of staged functional programming. It boasts of having intensional polymorphism and first-class staging. Its primary purpose is the creation of ML libraries for novel kinds of AI hardware.

## Getting Spiral

The language is published on the VS Code marketplace. Getting it is just a matter of installing the **The Spiral Language** plugin. This will install both the VS Code editor plugin and the compiler itself. The compiler itself requires the .NET Core 3.1 rutime and is portable across platforms. The language server uses TCP to communicate with the editor so allow it in the firewall.

## Status in 12/24/2020

Alpha - the language needs more testing before it can be considered roboust. It only has the F# backend at present. More will be added assuming I can get sponsors for novel kinds of hardware. If you are a AI hardware company interested in sponsoring Spiral please get in touch.

Besides lacking backends and libraries, it only has rudimentary package management and some important partial evaluator optimizations to improve compile times for large codebases have been left for later until the need for them arises. But overall, and even just considering compilation times, the situation is way better than it was during the v0.09 era already.

In terms of features that I wanted v2 to have the language is complete.

## Projects & Packages

The hierarchy of Spiral programs is a graph of packages, who internally have a sequence of modules, who internally have a sequence of top level statements such as type definitions and functions, who internally have a sequence of their own local statements.

Spiral files (either `.spi` or `.spir`) can be parsed without a dependency on any other file, but in order for type inference to work, they have to have an owner `package.spiproj` (both the name and suffix has to match) file and be a part of the sequence. The package file that is their owner is the first one that is found when searching outwards from the folder the `.spi`/`.spir` file is in. And on the flip side, `package.spiproj` files can only refer to files that they own - if any of the subdirectories have another package file, then that will be an error.

The way to start a Spiral project, is to create an empty `package.spiproj` file in some folder.

This is its content if you want a project with the file `a.spi`.

```
modules:
    a
```

Now, if the folder does not have `a.spi` you should see an error in the editor indicating as much. The project files are interactive - instead of creating the file in the editor's tree explorer, you can place the cursor on `a` and select the code action `Create file.` in order to actually create it. The files and packages that exist will also have links to them in the package file.

Here are all the forms allowed for the `modules` field.

```
modules:
    a
    b-
    c*
    d*-
    some_folder/
        z
        x
    y
```

`a` and `b-` when created are `a.spi` and `b.spi` respectively. `b-` however has special behavior in that it inlines the module into the enclosing scope. While everything in `a` will have its file name as its module name, `b`'s statements will get included directly into the enclosing one.

`c*` and `d*-` when created are `c.spir` and `d.spir` respectively. Similarly as for `b-`, the `-` in `d*-` acts as the include postfix. `.spi` and `.spir` files have important differences in their processing that will be covered in later sections - for now the documentation will be covering regular top-down `.spi` modules.

`some_folder/` is in fact a folder, and `z` and `x` are its submodules.

The parsing for the `modules` field in the package file is indentation sensitive so `y` won't be considered as part of the `some_folder` folder.

You can delete and rename files and folders from the package file using a code action. Renaming will change the file or folder name on the disk, but it won't actually rename the references to it.

Besides modules, it is also possible to provide packages.

Suppose you have a folder with subfolders `a`, `b` and `c`, each of which have their own `package.spiproj` file. If you want `c` to refer to `a` and `b` here is how it should be done.

```
packages:
    a
    b
```

Packages also support the include the postfix `-`. This is useful for including the core library for example (assuming it is there in the directory.)

```
packages:
    core-
    a
    b
```

By default, the module directory is current, and the package directory is the parent, but it is possible to set them explicitly.

```
packageDir: e:/spiral_packages
moduleDir: src
```

`packageDir` and `moduleDir` fields both support relative and absolute paths.

Package names also support the | prefix. Most tests import the core like this...

```
packages: |core-
```

Instead of looking for the package in the parent folder of the package file, the | unary operator instructs the compiler to look in the parent folder of its own executable - in other words, the plugin folder itself. This is a convenience for bundling the core library with the plugin.

Besides those 4, there package file schema also supports `name` and `version` fields, but those do not affect compilation in any way at the moment.

The great thing about packages is that their processing is done concurrently. While modules are processed strictly sequentially as in F#, packages are more flexible. Circular links between packages though are not allowed and will report an error. 

As long as any of the loaded packages has an error, type inference won't work - the changes will cached until the package errors are resolved and only show the previous results.

## Top-Down Segment

The Spiral language is split into the top-down (`.spi`) and the bottom-up (`.spir`) segments. The difference between the two is that the top-down actually has an ML-styled type system based on unification while the bottom-up does type propagation via partial evaluation.

This is a major innovation in v2 of Spiral. In its previous version, Spiral did not have a top-down segment. 

I spent a year programming like that, but after a while I got tired of it. After a year of it, I started to realize that expressiveness and power, while worthy and necessary goals in themselves are not all there is. I was in love with it for a while as it was such a new perspective on both programming and static typing, but in the end I came to know the truth - just because the partial evaluator can do anything it does not mean it should do everything. 

The bottom-up has high expressiveness and power, but the user has to pay a cost for that even when such a power is not needed so there is great benefit to putting a weaker, but easier to use type system on top of it. I expect that at least 95% of the time the programming in Spiral will be done with the help of the top-down type system. The top-down segment is the easy part of Spiral.

### Compilation

For the following part I will be using a `package.spiproj` file with the core library and an arbitrary module to write things in.

```
packages: core-
modules: a
```

The way to compile a module is to have it open in the editor and then use `Spiral: Build File` from the command palette.

Here is an example module `a.spi`:

```
inl main () = 1i32
```

Using the build command will partially evaluate the `main` function. This will create `a.fsx` with the following residual program as output.

```
1
```

#### TODO - Expand the compilation options

Right now the `main` function takes in an `unit` type as an argument. In the future this might change so it takes in an array of strings, in addition there will be more compilation options available - rather than just compiling `main`, I want Spiral to be usable for compiling libraries. But right now, the status is early alpha and the language is still in the testing phase.

### Basics

In its top level segment, Spiral is fairly similar to F# and various ML-family languages like OCaml. It is an eager and impure statically typed functional language without a doubt. So whatever skills you pick up in those languages will be directly transferable to Spiral. F# in particular has many learning resources whose breadth would be too much for me to cover in this document, so I'd recommend it, especially for beginners. This document is intended for those already proficient in functional languages and people who know how to program, and want to take their skills to the next level.

My goals from here on out will be as follows:

* Cover all the language features with examples.
* Talk about the design considerations of Spiral and why it is designed the way it is.

In particular when I get to join points and inlineables, the material will get hard to follow for a beginner. This next segment though should be straightforward.

Here are some rudimentary examples of programs and their output.

```
inl main () =
    inl x = 1
    inl y = 2
    x + y
```

If you try to compile the above you will actually get an error that the `main` function should not be a forall. If you hover the mouse cursor over the `main` you will see that its type is `forall 'a {number}. () -> 'a`. Here `'a` is the type variable with the `number` constraint. `()` is the unit type and `() -> 'a` indicates it is a function from unit to `a`.

Spiral most closely resembles F# its design, and here is the first difference. Like Haskell it supports polymorphic number literals. In fact if you hover over `1` or `2` you will see that they are of type `'a`.

In order to compile this segment what needs to be done is have the literals be concrete.

```
inl main () =
    inl x = 1i32
    inl y = 2
    x + y
```

```fs
3
```

Now, the compiled output program is just a single int `3`.

```
inl main () =
    inl x = 1f64
    inl y = 2
    x + y
```

```fs
3.000000
```

It is easy enough to change the constant to a float. An alternative is to just provide a type annotation somewhere.

```
inl main () : u16 =
    inl x = 1
    inl y = 2
    x + y
```

```fs
3us
```

Now the literal is inferred to be a 16-bit unsigned int. Here is one more...

```
inl main () =
    inl x = 1 : i64
    inl y = 2
    x + y
```

```fs
3L
```

Here the literal is now an 64-bit signed int. Primitive number types in Spiral consist of signed ints (`i8`,`i16`,`i32`,`i64`), unsigned ints (`u8`,`u16`,`u32`,`u64`) and floats (`f32`,`f64`). Other primitive types are `bool`, `string` and `char`. 

Unlike mutable heap layout types (think references) and arrays, the primitive types are tracked exactly at compile time. The reason why the output program comes up to 3, is because the partial evaluator will keep 1 and 2 in memory and add them together.

In regular languages, whether something happens at compile time or runtime is vague and indistinct, but Spiral is a lot more careful about such considerations. Performance is one of the reasons, but language interop is just as important as well.

Using `~` it is easy to instruct the partial evaluator to push the variable tracking to runtime.

```
inl main () =
    inl ~x = 1 : i64
    inl y = 2
    x + y
```

```fs
let v0 : int64 = 1L
v0 + 2L
```

`~` is called the dyn pattern. Whenever a variable is passed through the dyn pattern during a bind, it gets pushed to runtime. In the above example, only `x` has been dyned so only the `let` statement for it has been generated in the compiled code.

```
inl main () =
    inl ~x = 1 : i64
    inl ~y = 2
    x + y
```

```fs
let v0 : int64 = 1L
let v1 : int64 = 2L
v0 + v1
```

### Join points

The above capability to push compile time data to runtime is hugely important for functions. In languages without exposure to partial evaluation such as F#, you might have ordinary `let` statements and `let inline` requivalents and that is it. You can define a function and then give a suggestion to the compiler to inline it, and that is the whole story when it comes to inlining in most languages.

Spiral is more flexible.

The following example is equivalent to the first one.

```
inl add a b = a + b
inl main () =
    inl x = 1i32
    inl y = 2
    add x y
```

```fs
3
```

It is possible to use the dyn pattern on function arguments.

```
inl add ~a ~b = a + b
inl main () =
    inl x = 1i32
    inl y = 2
    add x y
```

```fs
let v0 : int32 = 1
let v1 : int32 = 2
v0 + v1
```

Here is an example that performs several additions.

```
inl add ~a ~b : i32 = a + b
inl main () = add 1 2, add 3 4, add 5 6
```

```
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = v0 + v1
let v3 : int32 = 3
let v4 : int32 = 4
let v5 : int32 = v3 + v4
let v6 : int32 = 5
let v7 : int32 = 6
let v8 : int32 = v6 + v7
struct (v2, v5, v8)
```

It convient to have the function itself be the one to decide whether it wants runtime or compile time variables.

The above example is trivial, but for larger functions it would be better if they could be compiled to actual methods. The way to accomplish that is to wrap the body of the expression in a join point.

```
inl add ~a ~b : i32 = join a + b
inl main () = add 1 2, add 3 4, add 5 6
```

```fs
let rec method0 (v0 : int32, v1 : int32) : int32 =
    v0 + v1
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = method0(v0, v1)
let v3 : int32 = 3
let v4 : int32 = 4
let v5 : int32 = method0(v3, v4)
let v6 : int32 = 5
let v7 : int32 = 6
let v8 : int32 = method0(v6, v7)
struct (v2, v5, v8)
```

The join point converts all the runtime variables passed into its scope into method arguments in the resulting compiled code. During partial evaluation after making the environment as a part of its key, it then partially evaluates the method body which in the above case is just `a + b`.

In order to understand join points better, it would be instructive to show what happens when arguments aren't being dyned.

```
inl add ~a b : i32 = join a + b
inl main () = add 1 2, add 3 4, add 5 6
```

```fs
let rec method0 (v0 : int32) : int32 =
    v0 + 2
and method1 (v0 : int32) : int32 =
    v0 + 4
and method2 (v0 : int32) : int32 =
    v0 + 6
let v0 : int32 = 1
let v1 : int32 = method0(v0)
let v2 : int32 = 3
let v3 : int32 = method1(v2)
let v4 : int32 = 5
let v5 : int32 = method2(v4)
struct (v1, v3, v5)
```

The constants are different so the join point gets compiled to different methods.

```
inl add ~a b : i32 = join a + b
inl main () = add 1 10, add 3 10, add 5 10
```

```fs
let rec method0 (v0 : int32) : int32 =
    v0 + 10
let v0 : int32 = 1
let v1 : int32 = method0(v0)
let v2 : int32 = 3
let v3 : int32 = method0(v2)
let v4 : int32 = 5
let v5 : int32 = method0(v4)
struct (v1, v3, v5)
```

If the constant `b` happened to be the same, then the join point would end up needing only a single method in the compiled code. Without any dyning at all, here is what would happen.

```
inl add a b : i32 = join a + b
inl main () = add 1 2, add 3 4, add 5 6
```
```fs
let rec method0 () : int32 =
    3
and method1 () : int32 =
    7
and method2 () : int32 =
    11
let v0 : int32 = method0()
let v1 : int32 = method1()
let v2 : int32 = method2()
struct (v0, v1, v2)
```

This is just for illustration of what join points are doing. In actual programming practice, you'd generally want to either inline everything or dyn all the arguments and wrap them in a join point. To do the later, `let` is a convenient shorthand.

```
let add a b : i32 = a + b
inl main () = add 1 2, add 3 4, add 5 6
```
```fs
let rec method0 (v0 : int32, v1 : int32) : int32 =
    v0 + v1
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = method0(v0, v1)
let v3 : int32 = 3
let v4 : int32 = 4
let v5 : int32 = method0(v3, v4)
let v6 : int32 = 5
let v7 : int32 = 6
let v8 : int32 = method0(v6, v7)
struct (v2, v5, v8)
```

`inl add ~a ~b : i32 = join a + b` is equivalent to `let add a b : i32 = a + b`.

These examples cover the essence of join points. All they do is specialize the body of their expressions with respect to their environment.

While their essence of their functionality is easy to understand, these examples are just scratching the surface of their usefulness. If it was just performance, they would not be useless, but they would not be enough to motivate me to make a language with them as one of the most essential features.

#### TODO - Join points and language interop

It is a pity I cannot demostrate this benefit at the moment as Spiral is in alpha stage, but it is worth describing how it used to work in the previous version.

The previous version of Spiral, had a Cuda backend with a join point variant specific to it.

The way the whole thing worked is that the compiler would produce an F# file, similar to how it is done now, and in addition to that, there would also be a C file with the methods specialized by Cuda join points. This C file would further be processed by the Cuda compiler into a `.ptx` one which is the high level assembly language used by LLVM.

The Cuda join point itself would not necessarily return a type like regular ones do, because the F# codegen would not be able to actually run it, and generating the code to run it would be too complex for it. Instead what the Cuda join point would do is return a runtime string with the name of the specialized method along with the array of runtime vars passed into it.

This is exactly the data you need in order to call Cuda kernels through the Cuda library functions that expose that functionality for other platforms. Calling the Cuda kernel from .NET was not as simple as simply wrapping the expression in an join point like for regular methods, instead it was necessary to pass a lambda to some `run` function, which is almost as easy. The Cuda join point was an integral part of connecting the F# to the Cuda backend.

Having this machinery in place made it trivial to make all sort of complex Cuda kernels and call them from the .NET land. And as an example, because of Spiral's inlining capabilities it was possible to have map functions that are autodifferentiated on the GPU. Before working on Spiral, in 2016 I tried making a ML library in raw F# and completely got stuck on how to move beyond the Cuda kernels being raw text strings. Compared to that the ML library I wrote in previous Spiral was a major leap in quality and extensibility compared to the one in F#, afforded completely thanks to the novel abstraction capabilities of the language.

### Functions

In Spiral, inlining is composable. It is not necessarly the case that one is restricted to putting join points at function body starts.

```
inl add a b : i32 = a + b
inl main () = 
    inl ~x = true
    if x then join add 1 2
    else add 3 4
```
```fs
let rec method0 () : int32 =
    3
let v0 : bool = true
if v0 then
    method0()
else
    7
```

Join points can be put everywhere an expression can. Here is some more of their magic.

```
inl add a b : i32 = a + b
inl main () = 
    inl f g = join g()
    inl x = 1
    inl y = 2
    f (fun () => add x y)
```
```fs
let rec method0 () : int32 =
    3
method0()
```

Functions are also partially evaluated in Spiral.

Suppose `1` and `2` were runtime variables.

```
inl add a b : i32 = a + b
inl main () = 
    inl f g = join g()
    inl ~x = 1
    inl ~y = 2
    f (fun () => add x y)
```
```fs
let rec method0 (v0 : int32, v1 : int32) : int32 =
    v0 + v1
let v0 : int32 = 1
let v1 : int32 = 2
method0(v0, v1)
```

This example demonstrates how functions interact with join point specialization. As long as functions aren't dyned, the partial evaluator tracks them by their body and environment.

Here is what happens when functions are dyned.

```
inl add a b : i32 = a + b
inl main () = 
    inl ~x = 1
    inl ~y = 2
    inl f z = add x y + z
    inl ~g = f
    g 3, g 4, g 5
```
```fs
let rec closure0 (v0 : int32, v1 : int32) (v2 : int32) : int32 =
    let v3 : int32 = v0 + v1
    v3 + v2
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : (int32 -> int32) = closure0(v0, v1)
let v3 : int32 = v2 3
let v4 : int32 = v2 4
let v5 : int32 = v2 5
struct (v3, v4, v5)
```

Dyning does closure conversion of relevant functions. At runtime it creates a heap allocated object with the nessary runtime variables and specializes the function body. After that the object can be passed around and applied at runtime in multiple places.

### What triggers dyning?

* The dyn pattern.
* Join point returns.
* If branch and match case returns when their conditional is not known.
* Stores to runtime data structures such as arrays.

As a language, Spiral is designed to be sensible about when various abstractions such as functions should be heap allocated and not. F# and other functional languages provide no guarantees when a function will get inlined or not. This is important for performance as much as it is for interop.

```
inl main () = 
    inl f g = join g()
```

This was a part of one of the previous examples. Suppose `g` was dyned, like in the following example.

```
inl add a b : i32 = a + b
inl main () = 
    inl f ~g = join g()
    inl ~x = 1
    inl ~y = 2
    f (fun () => add x y)
```
```fs
let rec closure0 (v0 : int32, v1 : int32) () : int32 =
    v0 + v1
and method0 (v0 : (unit -> int32)) : int32 =
    v0 ()
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : (unit -> int32) = closure0(v0, v1)
method0(v2)
```

Then the join point would get passed a closure.

Closures are troublesome for interop because they cannot be sent past language boundaries.

In the Cuda backend for example, very little could go past it, namely:

* Primitive number types.
* Arrays of them.

Runtime strings cannot. Chars would give memory corruption errors. .NET booleans aren't blittable either.

Arrays of compound structures like tuples or records aren't blittable either. The fact that I could use tensors which arranged arrays of tuples into tuples of arrays was a major benefit when it came to interop.

Spiral tracks runtime variables in data structures individually so passing them through backend boundaries is not a problem, but in .NET languages this is something that takes special care. .NET structs for example have their order and padding automated by the compiler, while C structs are sequential, but the C compiler also has leeway to insert padding into them for some reason.

Non-recursive union types could be serialized in theory, but it has not been implemented as I did not require that functionality at the time. The Cuda backend itself supported non-recursive union types though.

The lesson from all of this is - the simpler the runtime representations the language uses the better it is at interop.

F# or Scala or Haskell, or any similar language with advanced type systems do not have this focus on making inlining composable. I do not think it would be possible to take any of those languages and make them a serious C competitor.

But with Spiral, suppose you picked a backend that did not have garbage collection and you disallowed its ability to do closure conversion. It would still retain the vast majority of its expressive power.

My years of experience tell me that the situations where you actually want to heap allocate a function and store it in an array or a reference are actually fairly rare. And the situations where you are abstracting some repeated functionality through higher order functions are quite distinct from those.

Compared to other functional languages, Spiral has added complexity because of all of its partial evaluation magic. That is true. But if you forget the dyn pattern and the inl statements, and only use `let` the language can essentially be treated as any other ML variant.

### Macros

Since all the examples so far compiled to F#, you'd be forgiven for thinking that Spiral is a .NET language. That is not necessarily the case. The reason I picked F# as the compilation target is partly familiarity - up to that point F# was my primary language, and party platform specific reasons. JVM for example does not support tail call optimization (TCO). Neither do the various Javascript engines.

Compiling to Python directly would just throw away too many of Spiral's inate performance advantages in addition to not having TCO. C compilers are pretty good these days, so I think they would support TCO. A C backend that interfaces with Python's runtime system would give all the advantages of Python and Spiral with none of the disadvantages, so if there is demand for this I would be willing to work on this.

Back in 2017 during the work on the first Spiral, I actually tried making Spiral a proper .NET language, but in the end realized that .NET is huge. It was really quite difficult to make progress in this direction, and to make matters worse, on the Cuda side I also needed a system to interface with its C++ libraries. I asked around and tried looking for ways of getting the types from C++ header files, but that quickly turned into a dead end as C++ was too complex as a language. Parsing C++ actually requires a full C++ compiler.

So for language interop, I ended up settling on macros. This is actually fairly similar to how ReasonML and Fable interface with Javascript. The new Spiral also uses macros for interop, but they got a refresh. The old Spiral had fairly flexible and powerful macros, that were ugly to write and look at. The new Spiral has nice and elegant string-interpolated ones.

This is the general theme of the move from v0.09 to v2 - the language has been redesigned from the ground up in order to improve its ergonimics and compilation times.

Here is an example of them.

```
inl main () = 
    inl ~x = "asd"
    $"// This is a comment"
    inl ~y = "qwe"
    $"printfn \"x=%s, y=%s\" !x !y"
    ()
```
```fs
let v0 : string = "asd"
// This is a comment
let v1 : string = "qwe"
printfn "x=%s, y=%s" v0 v1
```

Using ! it is possible to splice in the term variables, and ` can be used to do the same for type variables.

Here is how it is possible to create .NET objects. Note that these examples are easier to read in the editor as it provides semantic highlighting.

```
type resize_array a = $"ResizeArray<`a>"
inl resize_array_create forall a. : resize_array a = $"ResizeArray<`a>()"
inl resize_array_add forall a. (x : resize_array a) (v : a) : () = $"!x.Add(!v)"

inl main () = 
    inl ~x = resize_array_create
    resize_array_add x 1i32
    resize_array_add x 2
    resize_array_add x 3
```
```fs
let v0 : ResizeArray<int32> = ResizeArray<int32>()
v0.Add(1)
v0.Add(2)
v0.Add(3)
```

This is not as nice as having direct interop with .NET that F# gives you. If one wanted to program purely on the .NET platform, and the task did not require composable inlining or heavy serialization I would not recommend Spiral over F#. But the system shown here does have an advantage in that it makes the creation of a language backend easy.

The F# one is a bit less than 400 lines of code, and macros give us access to all the .NET libraries right away. The situation would be the same if Spiral were compiling to Cuda, Java, Python or anything else.

### Layout types

F# would say that `let id x = x` is just a function, and according to the previous section, Spiral would contribute to the conversation by saying: 'No, no, this is a function with a dyn pattern on its argument and a join point wrapped around its body.' It shows a more nuanced way of thinking by pointing out a reasonable decomposition for a function into several orthogonal concepts.

When it comes to data structures, many languages mix various orthogonal concepts to arrive at their foundation.

For example, consider an F# record.

```fs
type R = { a : int; b : string }
```

In F# this is a record, but in Spiral the equivalent would be a nominal type + heap layout type + a record type.

In Spiral, compund types such as pairs and records do not have a runtime footprint. 

```
inl main () = join 1i32, 2i32, 3i32
```
```fs
let rec method0 () : struct (int32 * int32 * int32) =
    struct (1, 2, 3)
method0()
```

This is convenient as heap allocation are not necessary for them. If the target was a C backend, the obvious benefit is that the user would never need to hesitate when using records or pairs. F# tuples and records are heap allocated by default and it is up to the compiler to optimize the heap allocations away if it can.

Spiral on the other hand gives a hard guarantee on what their runtime representation will be. Much like for inlining, what you see is what you get. `inl` statements aren't a suggestion to the compiler - it will always inline.

Here is the same example, except with a record.

```
inl main () = join {a=1i32; b=2i32; c=3i32}
```
```fs
let rec method0 () : struct (int32 * int32 * int32) =
    struct (1, 2, 3)
method0()
```

Spiral records are lexically ordered, and they get compiled down to ordinary stack allocated structs. Their keys get erased. A benefit of this is that it becomes possible to nest records without any penalty.

```
inl main () = join {q = {a=1i32; n={b=2i32; c=3i32}}}
```
```fs
let rec method0 () : struct (int32 * int32 * int32) =
    struct (1, 2, 3)
method0()
```

The same applies to pairs. In fact `1,2,3` is equivalent to `1,(2,3)` in Spiral. In F# though these would be distinct.

A motivation for having pairs as opposed to tuples in Spiral is that later on when I implement tensors, this will make it possible to easily partially apply their outermost dimension. If you have a 3d tensor for example, typically you need to apply it all at once in various languages, but in Spiral I want to make it easy to write something like `t ! 0` which would then apply the outermost dimension and return a 2d tensor.

In F#, function arrows are right associative `a -> b -> c` is equivalent to `a -> (b -> c)`. The pairs being that way as well gives them a symmetry that can be exploited to make data structures applicable.

At any rate, heap allocation is desirable in some scenarios and Spiral makes it easy to change the layout of its types.

```
inl main () = join heap {q = {a=1i32; n={b=2i32; c=3i32}}}
```
```fs
type Heap0 = {l0 : int32; l1 : int32; l2 : int32}
let rec method0 () : Heap0 =
    {l0 = 1; l1 = 2; l2 = 3} : Heap0
method0()
```

`heap` is a core library function of type `forall a. a -> heap a`. It will dyn the input and construct a runtime heap allocated object consisting of them.

Heap allocated objects can be nested.

```
inl main () = join heap {q = {a=1i32; n = heap {b=2i32; c=3i32}}}
```
```fs
type Heap1 = {l0 : int32; l1 : int32}
and Heap0 = {l0 : int32; l1 : Heap1}
let rec method0 () : Heap0 =
    let v0 : Heap1 = {l0 = 2; l1 = 3} : Heap1
    {l0 = 1; l1 = v0} : Heap0
method0()
```

They can be used on primitive types.

```
inl main () = join heap {q = {a=1i32; n={b=heap 2i32; c=3i32}}}
```
```fs
type Heap1 = {l0 : int32}
and Heap0 = {l0 : int32; l1 : Heap1; l2 : int32}
let rec method0 () : Heap0 =
    let v0 : Heap1 = {l0 = 2} : Heap1
    {l0 = 1; l1 = v0; l2 = 3} : Heap0
method0()
```

This is useful as Spiral does not have references, but it does have heap mutable types.

```
inl main () = 
    inl a = mut {q=1i32; w=2i32}
    a <- {q=3; w=4}
```
```fs
type Mut0 = {mutable l0 : int32; mutable l1 : int32}
let v0 : Mut0 = {l0 = 1; l1 = 2} : Mut0
v0.l0 <- 3
v0.l1 <- 4
```

The same flattening semantics work for heap mutable types as for regular heap types.

```
inl main () = 
    inl a = mut {q = {a=1i32; n = {b=2i32; c=3i32}}}
    a <- {q={a=4; n={b=5; c=6}}}
```
```fs
type Mut0 = {mutable l0 : int32; mutable l1 : int32; mutable l2 : int32}
let v0 : Mut0 = {l0 = 1; l1 = 2; l2 = 3} : Mut0
v0.l0 <- 4
v0.l1 <- 5
v0.l2 <- 6
```

Heap mutables when combined with records do have some extra benefits.

```
inl main () = 
    inl a = mut {q = {a=1i32; n = {b=2i32; c=3i32}}}
    a.q.n <- {b=5; c=6}
```
```fs
type Mut0 = {mutable l0 : int32; mutable l1 : int32; mutable l2 : int32}
let v0 : Mut0 = {l0 = 1; l1 = 2; l2 = 3} : Mut0
v0.l1 <- 5
v0.l2 <- 6
```

This nested indexing on the left side is specific to records, there is no way to get the same effect for pairs for example.

With this, the functionality of layout types has been covered. Here is how to turn layout types into regular ones.

```
inl main () = 
    inl a = heap 1i32
    inl b = mut 2i32
    !a, *b
```
```fs
type Heap0 = {l0 : int32}
and Mut0 = {mutable l0 : int32}
let v0 : Heap0 = {l0 = 1} : Heap0
let v1 : Mut0 = {l0 = 2} : Mut0
let v2 : int32 = v0.l0
let v3 : int32 = v1.l0
struct (v2, v3)
```

`!` and `*` are unary operators defined in the core library.

### Nominals

In Spiral, nominals are just compile time wrappers around some underlying type. They are similar to type aliases in that they are type level functions, but they also retain the arguments applied to them. Their unboxing needs to be forced. As mentioned in the previous section, here is what an F# records equivalent would be in Spiral.

```
nominal t = heap {a : i32; b : i32}
inl main () = t (heap {a=1; b=2})
```
```fs
type Heap0 = {l0 : int32; l1 : int32}
let v0 : Heap0 = {l0 = 1; l1 = 2} : Heap0
v0
```

As can be seen, the wrapper never appears in the compiled code. It bears mentioning that the generated code samples are in fact perfectly predictable. Spiral does not do any black box or speculative optimization, so you can count on this behavior to happen every time.

Here is how nominals can be destructured in patterns.

```
nominal t = heap {a : i32; b : i32}
inl main () = 
    inl x = t (heap {a=1; b=2})
    match x with
    | t p => p.a + p.b
```
```fs
type Heap0 = {l0 : int32; l1 : int32}
let v0 : Heap0 = {l0 = 1; l1 = 2} : Heap0
let v1 : int32 = v0.l0
let v2 : int32 = v0.l1
v1 + v2
```

### Symbols

In F# and most statically typed languages it is not possible to bind member accessors. In Spiral that is not a problem.

```
inl main () = 
    inl x = .asd
    x
```
```fs
()
```

It is possible to use `x` to access a record or a module field like so.

```
inl main () = 
    inl x = .asd
    {asd = "qwe"} x
```
```fs
"qwe"
```

If you hover the cursor over `x`, you will see that the type is `.asd`. Symbols are a bit like strings, except their type happens to be whatever their value is.

In the top-down segment this is of limited use. Suppose you wrote a program like this...

```
inl main () = 
    inl x = {a="asd"; b=true}
    inl f k = x k
    f .a, f .b
```
```
Expected symbol as a record key.
Got: 'a
```

It is expecting a symbol key known at compile time, but it is instead getting a type variable. The top down system is not powerful enough to deal with this. The `real` bottom up one is however.

```
inl main () : () = real
    inl x = {a="asd"; b=true}
    inl f k = x k
    f .a, f .b
```
```fs
struct ("asd", true)
```

The disadvantage of using the bottom up system is that you lose the top down benefits of type inference. Not only will the type errors get deferred to the partial evaluation stage, type application and type annotations for closures and recursive join points have to be set manually. This is tedious or difficult depending on the approach and more details will be provided in a later segment. For now, let us stick to the top-down part of Spiral

#### Symbols And Records

An amazing number of functional languages have crappy records, but in Spiral they really come into their own.

For example, they support nested (lensic) updates.

```
inl main () =
    inl x = {q = 1i32; w={a="asd"; b=true}}
    {x.w with b=false}
```
```fs
struct (1, "asd", false)
```

The above code fragment is not actually the behavior you'd get in F#. In F#, what would happen is that `x.w` would grab the nested record and update only that one instead.

```fs
let x = {|q=1; w={|a="asd"; b=true|}|}
{|x with w={|x.w with b=false|}|}
```

This is what the record update code fragment would be equivalent to in F#. That F# does not do this is actually fairly annoying at times. One thing I've found that eases record handling significantly that F# does not support is record punning.

```
inl main () =
    inl x = {q = 1i32; w={a="asd"; b=true}}
    inl b = false
    {x.w with b}
```
```fs
struct (1, "asd", false)
```

Spiral can do more, here is how key removal can be done.

```
inl main () =
    inl x = {q = 1i32; w={a="asd"; b=true}}
    {x.w without b}
```
```fs
struct (1, "asd")
```

It supports key injection for removals.

```
inl main () =
    inl k = .b
    inl x = {q = 1i32; w={a="asd"; b=true}}
    {x.w without $k}
```
```fs
struct (1, "asd")
```

Key injection also works for updates.

```
inl main () =
    inl k = .b
    inl x = {q = 1i32; w={a="asd"; b=true}}
    {x.w with $k=false}
```
```fs
struct (1, "asd", false)
```

The above only demonstrates set-updates. There are also the modify-updates. Instead of writing `a = b`, use the `#=` operator instead.

```
inl main () =
    inl k = .b
    inl flip x = x = false
    inl x = {q = 1i32; w={a="asd"; b=true}}
    {x.w with $k#=flip}
```
```fs
struct (1, "asd", false)
```

The above is the injecting version of the modify update. `b #= flip` would work just as fine.

Just like in updates, injection and punning works in patterns. Here are a few examples.

```
inl main () : i32 =
    inl f {a=a b=b} = a + b
    f {a=1; b=2}
```
```fs
3
```

The above is equivalent to...

```
inl main () : i32 =
    inl f {a b} = a + b
    f {a=1; b=2}
```
```fs
3
```

Here are two record injection examples. First is the regular one that does explicit rebinding.

```
inl main () : i32 =
    inl k, k' = .q, .w
    inl f {$k=a $k'=b} = a + b
    f {q=1; w=2}
```
```fs
3
```

Here is the punny record injection pattern.

```
inl main () : i32 =
    inl k, k' = .q, .w
    inl f {$k $k'} = k + k'
    f {q=1; w=2}
```
```fs
3
```

The record injection patterns aren't too useful in the top down segment, but in the bottom up segment which was the entirety of Spiral in the previous version, I often used them.

```
inl main () =
    inl k, k' = .b, .w
    inl flip x = x = false
    inl x = {q = 1i32; w={a="asd"; b=true}}
    {x$k' with $k#=flip}
```

Also, it is possible to use the injection pattern on the left side of with.

There is one other bit of special record syntax worth mentioning.

```
inl main () : i32 =
    inl r = {a = fun x => x * 2}
    r (.a, 5)
```
```fs
10
```

When you apply a record with a pair whose first element is a symbol, it will do a nested application with the result of that an the right side.

```
inl main () : i32 =
    inl r = {q = {a = fun x => x * 2}}
    r (.q, .a, 5)
```
```fs
10
```

It is not just a double application, but a nested one, so it works when there are nested pairs.

I originally wanted to allow this for modules as well, but automated filling of type applications cannot work with that so modules are restricted to being applied with individual symbols. This restriction only applies in the top down segment. The bottom up treats them as regular records.

The nested record application will be useful if the language ever gets OO-styled interfaces - I consider those one of the rare good OO ideas.

#### Symbols And Pairs

You'd imagine this part would be short since how much could there be to say about pairs, but there is a decent amount to cover. Spiral v0.2 has a lot of experimental syntax surrounding symbols that draws inspiration from Smalltalk.

Seen from the perspective of the top-down segment a lot of what I am going to show here might seem superflous. You would be able to substitute the various symbol patterns with records to get the same effect. The problem with records though is that they leak and can cause unused arguments to be passed through join points.

Here is an example of that.

```
open real_core
inl main () : i32 = real
    inl f x = join x.a.a + x.a.b
    inl r _ = inl ~x = {a=1; b=2; c=3} in x
    f {a=r(); b=r()}
```
```fs
let rec method0 (v0 : int32, v1 : int32, v2 : int32, v3 : int32, v4 : int32, v5 : int32) : int32 =
    v0 + v1
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = 3
let v3 : int32 = 1
let v4 : int32 = 2
let v5 : int32 = 3
method0(v0, v1, v2, v3, v4, v5)
```

You want to operate on only a few fields of a record, but end up dragging the whole thing through the join point by accident.

The bottom up segment is troublesome - you do not get handholding from the type system when applying functions, so you have even more incentive to use records just in care you miss because the error messages would be better. Since Spiral does function nesting where other languages would use multiple arguments, it is easy to miss one and not realize it until much later when the whole thing is done. The bottom-up segment forces you to go like a ping pong ball through the codebase fixing type errors much after they have been made, similarly how it would be in a dynamic language.

Records are leaky. Here is another way that they can leak by misspeling optional fields.

```
open real_core
inl main () : i32 = real
    inl r = {name="John"; surname="Smith"; aeg = 18}
    inl get_age = function
        | {age} => age
        | _ => -1
    get_age r
```
```fs
-1
```

This is the kind of problem you'd more often encounter in dynamic languages than static ones like Spiral.

Since overuse of records was one of my regrets from the earlier version of Spiral, it is what set my mind towards smoothing out some of the rough edges from it. As a programming pattern, looking up optional record fields is simply something that should not be done. There is no fixing it.

But the first one can be butressed by adding more nuance to the language. You want to express the same thing as with records, but in a more elegant fashion.

```
inl add (left: a right: b) = a + b
inl main () : i32 = add (left: 1 right: 2)
```
```fs
3
```

`(left: a right: b)` is equivalent to `(.left_right_, a, b)`. This holds for both the pattern and the constructor.

```
inl add (.left_right_, a, b) = a + b
inl main () : i32 = add (left: 1 right: 2)
```
```
inl add (.left_right_, a, b) = a + b
inl main () : i32 = add (.left_right_, 1, 2)
```
```
inl add (left: a right: b) = a + b
inl main () : i32 = add (.left_right_, 1, 2)
```

All of these are valid and equivalent ways of writing the same thing.

Punning can also be used with symbolic pairs.

```
inl add (left: right:) = left + right
inl main () : i32 = inl left, right = 1,2 in add (left: right:)
```

Like with records, the punning patterns can be mixed with regular ones.

The type of `add` here is a bit interesting. It is `forall 'a {number}. (Left: 'a right: 'a) -> 'a`.

You'd expect it to be `(left: 'a right: 'a)` instead of `(Left: 'a right: 'a)`. The reason for the first letter is capitalized are the union constructors and destructors.

##### Symbols And Unions

Here is how union types are defined and constructed.

```
union t =
    | A: i32 // .a_ * i32
    | B: f64 // .b_ * f64
    | C: string // .c_ * string

inl main () = C: "asd"
```
```fs
type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
    | US0_1 of f1_0 : float
    | US0_2 of f2_0 : string
US0_2("asd")
```

`C: "asd"` in the `main` function body is equivalent to writing `c_ "asd"`. It is not necessarily special union constructor syntax.

```
inl c_ x = x
inl main () = C: "asd"
```
```fs
"asd"
```

In fact, it is possible to define the function as so...

```
inl (C: x) = x
inl main () = C: "asd"
```
```fs
"asd"
```

Here is a more elaborate example of what is possible.

```
inl (Add: to:) = add + to
inl main () = Add: 1 to: 2
```

This is the same as...

```
inl (Add: to:) = add + to
inl main () = add_to_ (1, 2)
```

Note how in the function body (on the first line) the `add` is lowercase. This is the general pattern when it comes to symbols - the first capitalized letter gets converted to lower case, and then there is special behavior depending on the context. On the term level, that would turning it into a function call, and in a pattern, that would be union destructuring.

There is one bit of special syntax left.

```
union t =
    | A: i32
    | B // .b * ()

inl main () = B
```

`B` is equivalent to `b ()` in the `main` function body.

```
inl B = "asd"
inl main () = B
```
```fs
"asd"
```

All top level `inl` and `let` statements in Spiral have to be functions known at parse time, and one obvious use of this kind of syntax is for defining constants at the top level.

Now that this bit has been introduced, it should be a bit more clear why changing the first letter of a paired symbol pattern is being done.

For example, if...

```
inl (A: x) = x
```

...was compiled to something like...

```
inl A_ x = x
```

...then it would conflict with big name pattern that was just introduced. The way it is done now meshes well with the way union types are defined.

For completeness, here is an example of how union destructuring works in Spiral.

```
union t =
    | A: i32
    | C: string

inl main () = 
    inl ~x = C: "Hello"
    match x with
    | A: x => A: x * 2
    | C: x => C: "zxc"
```
```fs
type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
    | US0_1 of f1_0 : string
let v0 : string = "Hello"
let v1 : US0 = US0_1(v0)
match v1 with
| US0_0(v2) -> (* a_ *)
    let v3 : int32 = v2 * 2
    US0_0(v3)
| US0_1(v2) -> (* c_ *)
    US0_1("zxc")
```

One final thing, Spiral makes a distinction between recursive and non-recursive unions. Lists for example need to be defined with `union rec`.

```
union rec list a =
    | Nil
    | Cons: a * list a
```

Only `union rec` can be a mutually recursive type definition in Spiral. 

```
union rec a =
    | A: b
    | StopA
and union b =
    | B: a
    | StopB
```

### Prototypes

Spiral supports a form of ad-hoc polymorhism even in the top-down segment. Functionally, they are equivalent to Haskell's single parameter typeclasses. It is possible to use them to implement the monad typeclass for example. Here is a simpler example to start things off.

```
nominal a = i32
nominal b = f64
prototype is_bigger_than_five t : t -> bool
instance is_bigger_than_five a = fun (a x) => 5 <= x
instance is_bigger_than_five b = fun (b x) => 5 <= x
inl main () = is_bigger_than_five (a 1), is_bigger_than_five (b 6)
```
```fs
struct (false, true)
```

The above is a similar to writing the following using the bottom-up segment.

```
nominal a = i32
nominal b = f64
inl is_bigger_than_five x : bool = real
    open real_core
    match x with
    | a x => 5i32 <= x
    | b x => 5f64 <= x
inl main () = is_bigger_than_five (a 1), is_bigger_than_five (b 6)
```
```fs
struct (false, true)
```

To go deeper into depth, the `prototype is_bigger_than_five t : t -> bool` provides the type signature for the `is_bigger_than_five` function.

```
instance is_bigger_than_five a = fun (a x) => 5 <= x
instance is_bigger_than_five b = fun (b x) => 5 <= x
```

After that, the prototype instances act as match cases. This a convenient way of providing ad-hoc overloading during the top-down segment.

```
nominal a = i32
nominal b = f64
nominal c = i64
prototype is_bigger_than_five a : a -> bool
instance is_bigger_than_five a = fun (a x) => 5 <= x
instance is_bigger_than_five b = fun (b x) => 5 <= x
inl main () = is_bigger_than_five (a 1), is_bigger_than_five (b 6), is_bigger_than_five (c 7)
```

Since the instance for nominal `c` does not exist, the above example is erroneous and the error message says as much.

Besides the benefit of being inferable during the top-down segment, the prototype instances can be defined in different modules than the prototype as long as the nominal is defined there.

```
prototype (>>=) m a : forall b. m a -> (a -> m b) -> m b
prototype on_succ m a : a -> m a
```

Here is how the monadic bind `>>=` is defined in Spiral. The first element following the prototype is the name, followed by at least one type variable which acts as a type selector. During partial evaluation, the matching is done on the type itself rather than one of the values, which allows for return polymorphism as `on_succ` demonstrates.

The type variables after the first one are the ones related to it, the kind of the selector is derived from them.

In Spiral, the kinds of the foralls are not automatically derived, instead when an anotation is not provided they are assumed to be `*`.

```
prototype is_bigger_than_five a : a -> bool
```

In this simple prototype for example, the kind of `a` is `*`. In the more complex monadic bind the kind of `m` is `* -> *`.

In...

```
prototype (>>=) m a : forall b. m a -> (a -> m b) -> m b
prototype on_succ m a : a -> m a
```

...the `m a` is purposely made to resemble destructuring. When writing instances, you'd imagine substituting `m a` with `list a` or some other nominal that matches the signature.

It should be mentioned - all union types are always wrapped in a nominal which is why prototype instances can be defined for them. It has been mentioned that language's sometimes mix multiple concepts in order to establish their foundational data structures. In Spiral's case, its unions are nominals + raw unions under the hood. The language does not allow taking off the nominal wrapper from unions during destructuring.

## Heap Allocation vs Code Size

In today's statically typed languages, type systems span a wide range from weak and monomorphic like C's, to polymorphic like F#'s, to dependently typed ones like Agda's. It is really remarkable that increasing type system sophistication seems to result decreasing performance of languages.

It is a widespread meme that compared to, say Python, Java is faster because it is statically typed. But C is considered faster than Java, but there is no doubt that Java has a superior type system.

To illustrate the trouble that abstractions cause, consider the identity function. Here is how it would be written in F#.

```fs
let id x = x
```

In the editor the type shows up as `'a -> 'a`, but with the foralls made explicit its type is `forall 'a. 'a -> 'a`. The forall is troublesome, it is not something that can be executed in assembly. There are two different compilation strategies that compilers can use to deal with the forall.

1) The first is to use uniform representations for every data type. Dynamic languages use this by default, and in .NET languages that corresponds to upcasting a variable to heap allocated base type.

```fs
let id (x : obj) = x
```

As a way of illustration in F#, this would in essence compile the identity function to something that is equivalent to `obj -> obj`.

Dynamic languages follow this strategy. Also JVM languages, and Haskell and Ocaml.

The advantage of this approach is that one single identity function can be used for any kind of data type. The disadvantage of it is that primitives like ints, and stack allocated structs would need to be heap allocated and passed via reference into that function. This heap allocation happens under the hood and is invisible to the user, but is a real source of memory traffic.

2) Monomorphization. Spiral uses this, as does C++ for its templates, and Rust for example.

```
inl main () =
    let id x = x
    inl _ = id 1i32
    inl _ = id 2f64
    inl _ = id 3i8
    inl _ = id true
    ()
```
```
let rec method0 (v0 : int32) : int32 =
    v0
and method1 (v0 : float) : float =
    v0
and method2 (v0 : int8) : int8 =
    v0
and method3 (v0 : bool) : bool =
    v0
let v0 : int32 = 1
let v1 : int32 = method0(v0)
let v2 : float = 2.000000
let v3 : float = method1(v2)
let v4 : int8 = 3y
let v5 : int8 = method2(v4)
let v6 : bool = true
let v7 : bool = method3(v6)
()
```

Now the primitives no longer require boxing in order to be passed into the identity function - the compiler specializes it for each datatype, but the disadvantage is that this requires more work at compile time, and it produces more code at runtime.

This is the memory tradeoff between heap allocation and code size.

This tradeoff is a very real phenomenon that users often unwittingly make, and it explains most of the performance difference between different languages.

Dynamic languages are all the way on the heap allocation side of the axis. Their primitives and data structures are all heap allocated **by default**. **By default** should mean, unless the optimizer gets to them. But dynamic languages tend to have very flexible semantics that frequently inhibits that.

For dynamic languages with good optimizers like Javascript for example, it is well known that to get optimized code in it the way to do it is to write it as if it had a static type system.

That is why semi-dynamic languages like .NET ones, which have a dynamic runtime and GC and heap allocate by default, but static type systems generally have better performance than dynamic ones.

Spiral does stack allocation by default for all its primitives (except strings) and errs on the side of too much inlining, but this tradeoff does occur internally as well.

```
inl map f = array.map f
inl main () =
    array.init 10 id
    |> map ((+) 2)
    |> map ((*) 10)
    |> map ((/) 2)
    |> map ((-) 5)
    |> map ((%) 4)
```
```fs
let rec method0 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 10
    if v2 then
        let v3 : int32 = v1 + 1
        v0.[v1] <- v1
        method0(v0, v3)
    else
        ()
and method1 (v0 : int32, v1 : (int32 []), v2 : (int32 []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : int32 = v1.[v3]
        let v7 : int32 = 2 + v6
        v2.[v3] <- v7
        method1(v0, v1, v2, v5)
    else
        ()
and method2 (v0 : int32, v1 : (int32 []), v2 : (int32 []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : int32 = v1.[v3]
        let v7 : int32 = 10 * v6
        v2.[v3] <- v7
        method2(v0, v1, v2, v5)
    else
        ()
and method3 (v0 : int32, v1 : (int32 []), v2 : (int32 []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : int32 = v1.[v3]
        let v7 : int32 = 2 / v6
        v2.[v3] <- v7
        method3(v0, v1, v2, v5)
    else
        ()
and method4 (v0 : int32, v1 : (int32 []), v2 : (int32 []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : int32 = v1.[v3]
        let v7 : int32 = 5 - v6
        v2.[v3] <- v7
        method4(v0, v1, v2, v5)
    else
        ()
and method5 (v0 : int32, v1 : (int32 []), v2 : (int32 []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : int32 = v1.[v3]
        let v7 : int32 = 4 % v6
        v2.[v3] <- v7
        method5(v0, v1, v2, v5)
    else
        ()
let v0 : (int32 []) = Array.zeroCreate<int32> 10
let v1 : int32 = 0
method0(v0, v1)
let v2 : int32 = v0.Length
let v3 : (int32 []) = Array.zeroCreate<int32> v2
let v4 : int32 = 0
method1(v2, v0, v3, v4)
let v5 : int32 = v3.Length
let v6 : (int32 []) = Array.zeroCreate<int32> v5
let v7 : int32 = 0
method2(v5, v3, v6, v7)
let v8 : int32 = v6.Length
let v9 : (int32 []) = Array.zeroCreate<int32> v8
let v10 : int32 = 0
method3(v8, v6, v9, v10)
let v11 : int32 = v9.Length
let v12 : (int32 []) = Array.zeroCreate<int32> v11
let v13 : int32 = 0
method4(v11, v9, v12, v13)
let v14 : int32 = v12.Length
let v15 : (int32 []) = Array.zeroCreate<int32> v14
let v16 : int32 = 0
method5(v14, v12, v15, v16)
v15
```

The above program demonstrate how a bunch of maps get compiled to separate loops. In total, the output comes to 82 lines of code. But there is a lot of duplicate code in the loops.

It is easy to lower the resulting output size by doing more heap allocation at runtime. All it takes is a single character change. Instead of inlining the function, the following example passes them as closures at runtime.

```
inl map ~f = array.map f
inl main () =
    array.init 10 id
    |> map ((+) 2)
    |> map ((*) 10)
    |> map ((/) 2)
    |> map ((-) 5)
    |> map ((%) 4)
```
```fs
let rec method0 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 10
    if v2 then
        let v3 : int32 = v1 + 1
        v0.[v1] <- v1
        method0(v0, v3)
    else
        ()
and closure0 () (v0 : int32) : int32 =
    2 + v0
and method1 (v0 : int32, v1 : (int32 -> int32), v2 : (int32 []), v3 : (int32 []), v4 : int32) : unit =
    let v5 : bool = v4 < v0
    if v5 then
        let v6 : int32 = v4 + 1
        let v7 : int32 = v2.[v4]
        let v8 : int32 = v1 v7
        v3.[v4] <- v8
        method1(v0, v1, v2, v3, v6)
    else
        ()
and closure1 () (v0 : int32) : int32 =
    10 * v0
and closure2 () (v0 : int32) : int32 =
    2 / v0
and closure3 () (v0 : int32) : int32 =
    5 - v0
and closure4 () (v0 : int32) : int32 =
    4 % v0
let v0 : (int32 []) = Array.zeroCreate<int32> 10
let v1 : int32 = 0
method0(v0, v1)
let v2 : (int32 -> int32) = closure0()
let v3 : int32 = v0.Length
let v4 : (int32 []) = Array.zeroCreate<int32> v3
let v5 : int32 = 0
method1(v3, v2, v0, v4, v5)
let v6 : (int32 -> int32) = closure1()
let v7 : int32 = v4.Length
let v8 : (int32 []) = Array.zeroCreate<int32> v7
let v9 : int32 = 0
method1(v7, v6, v4, v8, v9)
let v10 : (int32 -> int32) = closure2()
let v11 : int32 = v8.Length
let v12 : (int32 []) = Array.zeroCreate<int32> v11
let v13 : int32 = 0
method1(v11, v10, v8, v12, v13)
let v14 : (int32 -> int32) = closure3()
let v15 : int32 = v12.Length
let v16 : (int32 []) = Array.zeroCreate<int32> v15
let v17 : int32 = 0
method1(v15, v14, v12, v16, v17)
let v18 : (int32 -> int32) = closure4()
let v19 : int32 = v16.Length
let v20 : (int32 []) = Array.zeroCreate<int32> v19
let v21 : int32 = 0
method1(v19, v18, v16, v20, v21)
v20
```

With the change, the output is 25 lines shorter then the previous one. It comes down to 57 lines.

The expense paid in lines of code is almost a third less, but now the resulting program would allocate closures on the heap. This along with the loop now requiring virtual calls to apply the closure would make the resulting program slower to execute that the first one. The first one's loops since they have the operations inlined directly might get vectorized and made even faster because of that.

It is not the case that performance is maximized by being all the way on the right side of the axis - too much inlining and specialization can hurt performance, but in general the place to look for the optimized spot would be best done by starting from there.

There is a saying that there are no fast or slow languages, only fast or slow implementations, but speaking as a language designer I do not agree with this. It is fairly obvious looking at the real world that some languages are very hard to optimize, and it I do not think it is the case that the reason Python or Ruby are slow is because not enough money was thrown at them by Google or Microsoft.

The heap allocation vs code size presents a framework for thinking about the performance of languages. Some languages might claim that they are fast, and might have flashy benchmarks comparing themselves to C. But regardless, you can look at what its defaults are - does it heap allocate basic data structures? Does it heap allocate primitives? Does it specialize like C++ or Spiral, or does it use dynamic language tricks to generate code like JVM and .NET ones do? Does it do the slow thing and then rely on the optimizer to make itself fast, or does it do the right thing from the start?

I feel confident about stating that Spiral is a performant language even without providing bechmarks, and the examples in the previous section were all demonstration of what its compilation defaults are. They are the lead into this framework. Spiral has sensible defaults and gives user the partial evaluation tools to make the heap allocation/code size tradeoff in a sensible manner.

Languages with dependent types are an interesting case study, they are further on the heap allocation side. They are slow because they are hard to compile, meaning they require dynamic runtimes. Idris for example compiles to Scheme. This is not exceptional among high level languages, but they require them much more severely. Since I like to push into extremities and am familiar with dependently typed languages, I did try to come up with top down type system with dependent types for Spiral, but I failed. I could not figure out something that meshes well with the partial evaluator.

Here is an example that demonstrates what I got hung up on in pseudo-code. Imagine if F# or Spiral had dependent types and as a thought experiment try to imagine how this would be compiled.

```fs
let (y : (if x < 10 then int else string)) = if x < 10 then 0 else "asd"
if x < 10 then x + 10 else x + "qwe"
```

In Spiral, F# and other statically typed languages with strong, but not dependent type systems, the types actually do have a 1:1 correspondence with their underlying representation.

How exactly the type `if x < 10 then int else string` be compiled? Is it some kind of union type? That seems to be a reasonable avenue to go down on at first, but the difficulties of that become apparent very quickly.

In the branches of `if x < 10 then x + 10 else x + "qwe"` how should `x` be destructured if it is an union type under the hood? Thinking about it logically, we know that `x` is an `int` in the *then* branch, and a `string` in the *else* branch, but where is the hook to actually unbox the union? This kind of thinking does not really make sense to me.

As if it were a force of nature, there is an inexorable pull towards admiting that despite being statically typed, the types in dependently typed languages are unmoored from their underlying representation. Much like in dynamically typed languages. And the most natural way of compiling the above fragment would be to forget the type signatures and just execute it in a computational context that has uniform representation for all its datatypes.

The way to performant compile dependently typed languages is a mystery to me. Whereas the simpler type system of Spiral has great synergy with the partial evaluator and is easy to compile.

## Bottom-Up Segment

The partial evaluator for Spiral v0.09 originally started off as a type system. I only realized that I was working on a partial evaluator after a few months. In 2016 while working on a ML library I got stuck on how exactly to propagate information to Cuda kernels. If the deep learning wave of the 2010s did not need GPUs, F# would have been entirely sufficient as a language, but it was just not powerful enough and I blamed the type system.

So in 2017, when I started work on Spiral I made F# the base and the first thing I got rid of was the type system. I read academic papers and books on type systems, but they were useless so I realized I had to do it on my own. Of course, I wanted the language to be statically typed - it had to be. Because how could GPUs possibly handle uniform representation that dynamic languages use? And rather than just suggestions, I need inlining to be guaranteed, otherwise how could first class function be compiled on the GPU? The same goes for other abstractions like tuples and records.

My earliest memory of working on it was trying to memoize a function's evaluation. I realized that it was possible to split running the function from actually evaluating it and that was how the concept of join points came to be. Along those lines most of what is in the bottom up segment I actually discovered myself, though I am sure the concepts are strewn throughout language implementations and academic papers.

In this section what I would like to impress is that the bottom-up Spiral is really a great language in its own right. It is the **real** Spiral, the top down type inferencer is just a wrapper, albeit a very useful one. It is the bottom-up Spiral that gets to the heart of what computation is really about.

If you picked C as the starting point, and tried to evolve it so that it gets all of the advantages of functional languages without any of disadvantages, the bottom-up Spiral is what you would get.

These next examples will be in a `.spir` file. Here is how the `package.spiproj` file should look like.

```
packages: |core-
modules: a*
```

From the perspective of the written code, the bottom-up segment generally means the code in `.spir` files and in the `real` bodies. From the perspective of compilation phases, the bottom-up segment happens during partial evaluation. Parsing and the type inference would all be a part of the top-down segment.

### Functions

The most important feature of the bottom-up Spiral are its first class functions and join points. From the perspective of a C level language, they are an incredible leap in expressiveness and power and they require zero runtime footprint, essentially allowing the use of regular functions for what would be metaprogramming in any other language.

They are what makes Spiral very suitable for systems programming. First class functions aren't a novelty themselves - they were discovered in the early 20th century as a part of lambda calculus. The way Spiral presents them though is novel.

In the top-down segment I demonstrated how functions can be dyned and converted into a runtime closure, but this capability is not fundamental to them. In Spiral that is an addon; closure conversion is just another kind of join point which has fake arguments passed through it. Whereas in heap allocation by default kind of languages, closure conversion is fundamental and inlining is something that happens optionally.

In the bottom-up segment annotations have to be provided manually.

```
inl main () =
    inl id = (fun x => x) : i32 -> i32
    inl ~x = id
    ()
```
```fs
let rec closure0 () (v0 : int32) : int32 =
    v0
let v0 : (int32 -> int32) = closure0()
()
```

It is possible to give the wrong annotation in which case a trace would show up.

```
inl main () =
    inl id = (fun x => x) : i32 -> i32
    inl ~x = id
    ()
```
```
Error trace on line: 1, column: 10 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
inl main () =
         ^
Error trace on line: 2, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl id = (fun x => x) : i32 -> f32
    ^
Error trace on line: 3, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = id
    ^
Error trace on line: 3, column: 9 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = id
        ^
The annotation of the function does not match its body's type.Got: i32
Expected: f32
```

The way the annotations have to be provided is fairly dumb - anybody seriously using closures will most likely do it from the top down segment which will fill in the annotations automatically. Here is a more complex with two nested functions.

```
inl main () =
    inl const = (fun x => (fun _ => x) : () -> i32) : i32 -> () -> i32
    inl ~x = const
    ()
```
```fs
let rec closure1 (v0 : int32) () : int32 =
    v0
and closure0 () (v0 : int32) : (unit -> int32) =
    closure1(v0)
let v0 : (int32 -> (unit -> int32)) = closure0()
()
```

It is tempting to ommit the inner annotation, but that won't work.

```
inl main () =
    inl const = (fun x _ => x) : i32 -> () -> i32
    inl ~x = const
    ()
```
```
Error trace on line: 1, column: 10 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
inl main () =
         ^
Error trace on line: 2, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl const = (fun x _ => x) : i32 -> () -> i32
    ^
Error trace on line: 3, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = const
    ^
Error trace on line: 3, column: 9 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = const
        ^
Cannot convert a function that is not annotated into a type.
```

This is how v2 works, there isn't some iron rule that the language has to be designed like this. A language that uses partial evaluation for everything could do more processing in order to distribute the annotation if it is possible. Or it could be possible to ommit the return type like it was the case in Spiral v0.09.

In general though, this fanciness is not necessary. Speaking from experience, whenever I've used closures in F#, they tended to be a lot simpler than functions I would use to structure the program. Having closures that return other closures is not the kind of situation I've had to come across. Functions, yes, I use that technique all the time. It is a large part of what makes functional programming so expressive. Closures, no. It is easier to bundle their arguments into a tuple, and it a practice I'd recommend doing in Spiral.

So this kind of design is perfectly fine from my point of view.

It was not the case in v0.09 where closure conversion worked differently, but in v2 the annotation has to be direct and cannot be changed once set.

```
inl main () =
    inl id = (fun x => x)
    inl ~x = id : i32 -> i32
    ()
```
```
Error trace on line: 1, column: 10 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
inl main () =
         ^
Error trace on line: 2, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl id = (fun x => x)
    ^
Error trace on line: 3, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = id : i32 -> i32
    ^
Error trace on line: 3, column: 14 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = id : i32 -> i32
             ^
Cannot convert a function that is not annotated into a type.
```

The compiler tries converting the left side of the annotation into a type, but it encounters an unannotated function and raises a type error.

The following also does not work. Annotations in arguments, aren't actually annotations, but type patterns.

```
inl main () =
    inl id (x : i32) : i32 = x
    inl ~x = id
    ()
```
```
Error trace on line: 1, column: 10 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
inl main () =
         ^
Error trace on line: 2, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl id (x : i32) : i32 = x
    ^
Error trace on line: 3, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = id
    ^
Error trace on line: 3, column: 9 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl ~x = id
        ^
Cannot convert a function that is not annotated into a type.
```

### Branching

The top-down type inferencer will treat type patterns as annotations, but in the bottom-up segment they have an entirely different role to play.

```
inl main () =
    inl f = function
        | (x : i32) => "int"
        | (x : f64) => "float"
        | _ => "something else"
    f 1, f 2f64, f true
```
```fs
struct ("int", "float", "something else")
```

Top-down this would be an invalid program. Originally, I wanted top-down to be more flexible and tried designing a top-down type system that could cover the full range of bottom-up Spiral's features, but in the end decided it was too difficult and settled on the current top-down system that can only compile a restricted subset of the bottom-up Spiral programs.

The bottom-up gives you so much power and expressiveness up front for such a light implementation load that it is astonishing. You could wrap the above in a join point and it would be specialized.

Something as simple as overloading could be done with prototypes which are a straight rip of Haskell's typeclasses. Haskell's typeclasses have accumulated a bevy of extensions over the years making them a lot more capable than Spiral's. Spiral's prototypes are the simplest possible implementation of them. Spiral does give the guarante that it will always inline them though.

The way Spiral's prototypes are implemented is by direct matching on the type during partial evaluation, not by passing a dictionary of closures at compile time.

Haskell's typeclasses are capable indeed, but they pale in comparison to what you can easily do in bottom-up Spiral. Suppose you wanted to count the number elements in a tuple, here is how that could be done in Spiral.

```fs
open real_core
inl main () =
    inl rec f = function
        | (a,b) => f a + f b
        | _ => 1
    f (1,2,3)
```

I am thinking whether this could be done with typeclasses in Haskell, and I think that if the scenario was just restricted to pairs you could iterate over them using the typeclass machinery, but the real problem is the `| _ => 1` branch. Typeclasses have no good way of expressing that. But even that was somehow possible these are just the pairs, things would only get more troublesome from there. Here is how to count the number of elements in a record. There is no good way of expressing this within the language of typeclasses.

```
open real_core
inl main () =
    inl rec f = function
        | (a,b) => f a + f b
        | {} as x => record_foldl (fun (state:key:value:) => state + f value) 0 x
        | _ => 1
    f (1,2,3,{q=(4,5); w=(6,7)})
```
```fs
7
```

This is one of the program examples that I tried wrapping my head around from a top-down perspective and in the end gave up. How could this be typed top-down? Bottom-up it is quite clear, but even the most advanced top-down type systems to date cannot cover this particular example.

Spiral's top down type inferencer is 1.5k LOC, while Haskell's is over 70k making it 10x the size of the entire Spiral compiler, so it clearly cannot compare in terms of sophistication. And the bottom-up cannot compete with top-down type infering languages in terms of ease of use and ergonomics. But together the two sides can achieve amazing synergy and get the best of both worlds.

It is not just the shape of the data that can be matched on. As long as the values are known at compile time, it is possible to use some tricks from dependently typed languages. In the top-down segment the following would give a type error because the branches are different. During the bottom-up segment the type checking is deferred until the last moment and the compilation succeeds because there is enough information to completely ignore one of the branches.

```
open real_core
inl main () =
    inl x = 1
    if x < 10 then x + 10
```
```fs
11
```

It is possible to raise type errors during partial evaluation manually.

```
open real_core
inl main () =
    inl f = function
        | (x : i32) => "int"
        | (x : f64) => "float"
        | _ => error_type "Expected an i32 or f64."
    f "qwe"
```
```
Error trace on line: 3, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl f = function
    ^
Error trace on line: 7, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    f "qwe"
    ^
Error trace on line: 4, column: 12 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
        | (x : i32) => "int"
           ^
Error trace on line: 5, column: 12 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
        | (x : f64) => "float"
           ^
Error trace on line: 6, column: 16 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
        | _ => error_type "Expected an i32 or f64."
               ^
Expected an i32 or f64.
```

The `real_core` module has a large number of primitives for testing types. Pattern matching can test for specific symbols or nominals, but cannot test whether a variable is a symbol or a nominal so there are various inbuilt ops for that. It is possible to test whether something is a compile time literal using `lit_is`. Together with `error_type` that makes it possible to implement an assert that raises a type error if both the conditional and the message are strings, otherwise it compiles to an runtime exception.

This is how it is implemented in `real_core`.

```
// Asserts an expression. If the conditional and the message are literals it raises a type error instead.
inl assert c msg = 
    if c = false then 
        if lit_is c && lit_is msg then error_type msg
        else failwith `(()) msg
```

Here is an example of it in use.

```
open real_core
inl main () =
    inl assert_less_than_ten x = assert (x < 10) "The argument must be less than 10."
    assert_less_than_ten 11
```
```
Error trace on line: 4, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    assert_less_than_ten 11
    ^
Error trace on line: 3, column: 34 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
    inl assert_less_than_ten x = assert (x < 10) "The argument must be less than 10."
                                 ^
Error trace on line: 128, column: 5 in module: c:\Users\Marko\Source\Repos\The Spiral Language\VS Code Plugin\core\real_core.spir.
    if c = false then 
    ^
Error trace on line: 129, column: 9 in module: c:\Users\Marko\Source\Repos\The Spiral Language\VS Code Plugin\core\real_core.spir.
        if lit_is c && lit_is msg then error_type msg
        ^
Error trace on line: 129, column: 40 in module: c:\Users\Marko\Source\Repos\The Spiral Language\VS Code Plugin\core\real_core.spir.
        if lit_is c && lit_is msg then error_type msg
                                       ^
The argument must be less than 10.
```

And when the argument is dyned, it compiles to a panic.

```
open real_core
inl main () =
    inl assert_less_than_ten x = assert (x < 10) "The argument must be less than 10."
    assert_less_than_ten (dyn 11)
```
```fs
let v0 : int32 = 11
let v1 : bool = v0 < 10
let v2 : bool = v1 = false
if v2 then
    failwith<unit> "The argument must be less than 10."
else
    ()
```

It could be done using macros if absolutely necessary, but otherwise right now Spiral does not have any exception catching mechanisms. It might have in the future, but right now catching exceptions goes beyond the immediate scope of what the language is intended for.

#### Loop Unrolling

Some languages need pragmas or macros to do loop unrolling, but it is fairly easy to do it naturally in Spiral. In Spiral the `.` operator is similar to `;` in F#. It can be used to separate statements on the same line.

```
open real_core
inl main () =
    inl rec loop f i = 
        if lit_is i = false then error_type "Expected i to be a literal."
        if 0 < i then f i . loop f (i-1) else ()
    loop (fun i => $"// line !i" : ()) 5
```
```fs
// line 5
// line 4
// line 3
// line 2
// line 1
```

#### Compiler Crash

Now that all the prerequisites have been met it is a good time to highlight that the Spiral compiler does not do any checks beforehand to make sure some piece of code at compile time does not cause it to stack overflow. Consider the following.

```
open real_core
inl main () =
    inl rec f () = 1 + f()
    f()
```
```
Spiral: The server has aborted with an error.
```

When you get this error message that can only mean there was a stack overflow. There is a very, very small chance it is a compiler bug and the server aborted due to an uncaught exception, but that shouldn't happen. This is not because Spiral it solid - at the time of writing it is still in alpha stage, but because all the unchaught exceptions should be caught by the Hopac concurrency library and outputted to the standard error.

In either case the background server has terminated and the editor won't be able to have type inference nor semantic tokenization until the server has been restarted. In the command palette there are `Spiral: Start Server` and `Spiral: Start Server In Shell` commands which can be used to do so. By default during plugin startup Spiral executes the first command. All it does is run the compiler executable stealthily in the background. The second one shows a visible window in the foreground. The option which one to trigger on startup can be accessed in settings.

As I said, languages generally take care to prevent user code from crashing them, but based on all my experience of programming in the old Spiral, I can state that these kinds of errors are very rare and are easy to isolate when they do happen by selectively cutting out pieces until the program compiles. The vast majority of my bug fixing time during the v0.09 was taken up by regular ones. So in my view this kind of language design is not a problem.

---

Note: If you do a build, but nothing is happening, bring up the shell and try it again. If an exception gets thrown then that is a compiler error. On the [Spiral issues page](https://github.com/mrakgr/The-Spiral-Language/issues), please report it along with a minimal example so that it can be fixed. Thank you.

#### Print Static

Being able to see the console information can be useful in some cases.

```
open real_core
inl main () =
    inl x = 1f64
    print_static x
    inl ~y = x
    print_static y
```
```
Server bound to: tcp://*:13805
1.000000f64
f64
```

The above output shows in the shell window, not the compiled file. The last two lines are from the `print_static`.  You can see how `x` is known to the partial evaluator as a compile time literal, but after it has been dyned, it gets tracked as a runtime variable.

```
open real_core
inl main () =
    inl rec loop f i = 
        if lit_is i = false then error_type "Expected i to be a literal."
        if 0 < i then f i . loop f (i-1) else ()
    loop (fun i => print_static {got = i}) 5
```
```
Server bound to: tcp://*:13805
{got : 5i32}
{got : 4i32}
{got : 3i32}
{got : 2i32}
{got : 1i32}
```

The `print_static` statements get executed as a part of partial evaluation. When the codebase gets bigger they are good for ensuring whether the partial evaluator is tracing a particular segment. They might be good for experimentation to get a better sense for how the system works. Keyed comment macros and doing a find in the output file for them is also a good fit for this purpose.

### Type Inference

The top-down segment does a great service to the user by doing type inference and filling in the annotations for functions and join points where necessary. It might be surprising to that it is actually possible to do inference in a bottom-up fashion programatically.

Here is how the identity function could be written in the bottom-up segment. Since the type inferencer is not filling in the foralls or type application, it is necessary to do that by hand. This shows how the type inferencer would compile `let id x = x`. The type inferencer in addition to filling in the types, also removes the non-essential ones such as in function arguments.

```
inl main () =
    inl id forall t. ~x = (join x) : t
    id `i32 1
```
```fs
let rec method0 (v0 : int32) : int32 =
    v0
let v0 : int32 = 1
method0(v0)
```

The ` unary operator can be used to access the type scope. Otherwise the term and the type scopes are segregated.

Since the above is in the bottom-up segment, instead of passing in the type, it is possible to omit the need to pass the forall entirely.

```
inl main () =
    inl id x = join x
    id 1
```
```fs
let rec method0 () : int32 =
    1
method0()
```

Alternatively, here is how to infer the type bottom up style. It is necessary to instruct the compiler to how to derive it, and since we have the element itself using it to get its type is a natural choice.

```
inl main () =
    inl id' forall t. ~x = (join x) : t
    inl id x = id' `(`x) x
    id 1
```
```fs
let rec method0 (v0 : int32) : int32 =
    v0
let v0 : int32 = 1
method0(v0)
```

While in the type scope, using the ` operator opens the term scope again. The partial evaluator processes the term and converts the resulting expression into a type. This illustrates the essence of bottom-up type inference using the simplest possible example.

When doing bottom-up programming implementing identity as `inl id x = x` is a natural choice. But sometimes having the type ahead of time is necessary.

A good example are the various array function like `map`.

```
inl map f ar = init (length ar) (fun i => f (index ar i))
```

Here is how it is implemented in the core library. Its type is `forall 'a 'b. ('a -> 'b) -> array 'a -> array 'b`. How would such a function be callable from the bottom up segment assuming we only had the unannotated `f` and the array?

First, it is necessary to extract the element from the array itself. The `typecase` construct allows matching on a type, but its body can be opened into the term scope. The `?` is meant to be seen as pseudo-code in the following examples.

```
inl map f ar =
    typecase `ar with
    | array ~a => array.map `a ? f ar
```

Here we are matching on the type of `ar`, and `~a` is the metavar to which the array's element gets bound to. Unlike in regular pattern matching it is possible to use repeat metavars to do equality checking. `~t * ~t` for example would test whether the both sides of a pair unify to the same type.

The `?` is troublesome here.

We need a type, so we must open the type scope.

```
inl map f ar =
    typecase `ar with
    | array ~a => array.map `a `(?) f ar
```

We don't actually have any convenient data structure to extract `b` from, but we can get it by running `b`. For that we need to use `f`, so we should open the term scope again.

```
inl map f ar =
    typecase `ar with
    | array ~a => array.map `a `(`(f ?)) f ar
```

We can't apply `f` with `a` here because that is a type and `f` wants a term. What we can do is turn it into a term however using the double grave unary operator.

```
inl map f ar =
    typecase `ar with
    | array ~a => array.map `a `(`(f ``a)) f ar
```

It creates a term out of a type. This is fine, since the code in the type scope will not get generated. If you try using that operator on the term level and the code with the `TypeToVar` op gets passed into the code generator you will get a trace + type error during code generation.

The compiler cannot possibly know how to create a value from an arbitrary type so this move can only ever be used for type inference.

Here is the full example.

```
inl map f ar =
    typecase `ar with
    | array ~a => array.map `a `(`(f ``a)) f ar

inl main () =
    inl x = array.init `i32 10 (fun x => x)
    map (fun x => x,x) x
```
```fs
let rec method0 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 10
    if v2 then
        let v3 : int32 = v1 + 1
        v0.[v1] <- v1
        method0(v0, v3)
    else
        ()
and method1 (v0 : int32, v1 : (int32 []), v2 : (struct (int32 * int32) []), v3 : int32) : unit =
    let v4 : bool = v3 < v0
    if v4 then
        let v5 : int32 = v3 + 1
        let v6 : int32 = v1.[v3]
        v2.[v3] <- struct (v6, v6)
        method1(v0, v1, v2, v5)
    else
        ()
let v0 : (int32 []) = Array.zeroCreate<int32> 10
let v1 : int32 = 0
method0(v0, v1)
let v2 : int32 = v0.Length
let v3 : (struct (int32 * int32) []) = Array.zeroCreate<struct (int32 * int32)> v2
let v4 : int32 = 0
method1(v2, v0, v3, v4)
v3
```

I had to implement `array.map` similarly to this in old Spiral. The reason why doing infering the type is needed is because the output array needs its type to be known ahead of time. It is not possible to do something like set it to some metavariable and unify it with its first use because of join points. In order to do their specialization, they need to have concrete terms ahead of time.

This general approach to type inference is what I followed in the old Spiral. I went into it far further than this; I experimented with all sorts of tricks there. For one Cuda kernel for example, I was raising an exception with the thrown type and catching it. I had special ops just to do that.

Consider the following function. How would it be possible to infer the type of the following?

```
inl main () =
    inl f = function
        | (a,b,c) => (a,b,c)
        | (a,b) => (a,b,b)
        | a => (a,a)
    f (f (f (f 1)))
```
```fs
struct (1, 1, 1)
```

If I ran it only once, I'd get `struct (1, 1)`. So the type of its input argument should be an union of `i32`, `i32 * i32` and `i32 * i32 * i32`. In order to infer the type of this what is necessary is to keep running the function until its type stabilizes. For this purpose, the old Spiral had particularly flexible union types that could be built up during partial evaluation instead of just specified at the top level like in v2.

This is not an academic exercise either, I had to use this technique to infer the types of the internal state of an RNN used as the model for a poker agent otherwise I would not be able to store it. It is fairly remarkable how far it is possible to get without any type annotations in a static language, Spiral v0.09 is definitely a record setter in that regard.

Today, I consider these techniques better off sealed. They are an anti-pattern. If bottom-up type inference sounds difficult, don't worry because it in fact is. The top-down is here for a reason in v2.

Besides taking a lot programming effort to be used, I suspect it was one of the reasons why towards the end the compile times were so poor on that agent.

To demonstrate why consider the previous example again.

```
inl map f ar =
    typecase `ar with
    | array ~a => array.map `a `(`(f ``a)) f ar
```

The part here where `f` is applied here is not free. Having to evaluate it twice, once to infer its return type, and once to actually generate its code, will in fact take twice as much time during compilation than just having to do it once.

It is possible to reduce this cost by wrapping `f` in a join point.

```
inl map f ar =
    inl f x = join f x
    typecase `ar with
    | array ~a => array.map `a `(`(f ``a)) f ar
```

This would reduce the compile time to about the cost of a single run, but now there will be a function call in generated code. You can only hope that whatever compiler is consuming it after that decides to inline it.

I do not like this. Spiral is all about giving the user guarantees - for when functions are inlined, for how the values are propagated, and when data structures are heap allocated. The language being predictable is what will make hitting performance targets tractable for the user.

Bottom-up programming just does not scale well to large codebases. It is very useful when you need all the power a statically typed programming language can give you, but most of the time you don't and would rather have instant editor feedback instead. When I first discovered all these bottom-up type inference techniques I felt very clever for breaking new ground, but using them where top-down type inference would suffice is just a waste of time.

### Real Nominals

I previously mentioned that very few things can go past language boundaries. One of the structures that can was an array of primitives. The trouble is that the regular arrays gets compiled to tuples. Consider the following top-down program.

```
inl main () =
    inl x : array (i32 * i32 * i32) = array.create 10
    ()
```
```fs
let v0 : (struct (int32 * int32 * int32) []) = Array.zeroCreate<struct (int32 * int32 * int32)> 10
()
```

For the sake of language interop, it would be better if this got compiled to three separate arrays and got tracked that way. It could be built into the language, but some things are more easily done as a library. Spiral's bottom-up introspection makes it possible.

Back in the very early days of old Spiral, it became quickly obvious to me that keeping the partial evaluator's operations simple, and leaving the harder tasks to be done in the language itself is a good practice. Not only would would the hard tasks be so hard as to be practically untenable - programming in the raw AST scales really poorly, doing it in the language itself means that the components can be reused elsewhere.

This example is going to be more complex as it involves making a small library. Here is how the complete `package.spiproj` file will look like.

```
packages: |core-
modules: 
    real_array_inv*
    array_inv_type-
    array_inv
    a
```

Let us move to the contents of the `real_array_inv.spir` file. Before the inverse array can be indexed and set, it needs to be created. Given a type like `i32 * i32` and a size argument, we need to compile it down to something like...

```
array.create `i32 10, array.create `i32 10
```

The resulting type of this term would be `array i32 * array i32`.

In other words, for a given type, we need to map over it and turn each element into an array. The bottom-up segment is necessary for this. In non-primitive type systems, it is easy to take some type `'a` and apply a function to it. Going in the constructive direction, it is then easy to get data structures like arrays of `a`, or sets of `a`, or dictionaries whose values are `a`.

But going the other way is very hard. I am yet to see a coherent scheme for doing this in a top-down type system. Dependently typed languages cannot do it either.

It is a pity, as these inverse arrays are probably the most underrated data structure in all of computer science. They have huge value, but they aren't present in any of the general purpose languages that I'd want to use. In the wild, they are often referred as struct-of-arrays or tuple-of-array datatypes as opposed to array-of-structs or array-of-tuples that are regular arrays.

Here is how `create` can be done in Spiral. Mapping over types is similar to mapping over regular structures using pattern matching.

```
open real_core
inl rec create forall t. size =
    typecase t with
    | ~a * ~b => create `a size, create `b size
    | {} => record_type_map (fun k => forall v. => create `v size) `t
    | _ => !!!!ArrayCreate(`t, size)
```

`typecase` unification has some differences from top-down unification. Rather than being strict, it unifies records loosely similarly to regular record patterns, meaning that it only checks whether they keys in the pattern are present. Since there are no keys, it just checks whether the type is a record.

`record_type_map` is a built in that maps over the elements of a type record. Unlike in the top-down, in the bottom-up segment it is possible to use `forall` freely on the term level. Writing `fun k => forall v. =>` is somewhat awkward, but is is necessary because the key is a term while the value is a type.

On the last line instead of ```!!!!ArrayCreate(`t, size)``` it would have been possible to use ```array.create `t size```. In fact, `array.create` is a straightforward binding to this built in op.

```
inl create forall t. (size : i32) : array t = !!!!ArrayCreate(`t,size)
inl index forall t. (ar : array t) (i : i32) : t = !!!!ArrayIndex(ar,i)
inl set forall t. (ar : array t) (i : i32) (v : t) : () = !!!!ArrayIndexSet(ar,i,v)
```

One advantage of using built in ops for this purpose instead of macros is interop. C for example is wonky when it comes to type signatures, and creating arrays needs special care there. It is not possible to create arrays in arbitrary expression like in F#. Also, C arrays can have various annotations tacked on that aren't properly a part of the type. Using built in ops ensures consistency across languages.

Another benefit is having better error messages in the bottom-up segment during partial evaluation. `ArrayCreate` for example, requires a 32-bit int as the size. Doing this type checking in the language directly would slow down partial evaluation.

Many built in ops simply need access to internal state of the partial evaluator and cannot be implemented using macros at all.

```
inl rec index ar i = 
    match ar with
    | a,b => index a i, index b i
    | {} => record_map (fun (key:value:) => index value i) ar
    | ar => !!!!ArrayIndex(ar,i)

inl rec set ar i v =
    match ar, v with
    | (a,b), (va,vb) => set a i va . set b i vb
    | {}, {} => record_iter (fun (key:value:) => set (ar key) i value) v
    | _ => !!!!ArrayIndexSet(ar,i,v)
```

`index` and `set` are mirrors of create. Rather than mapping over a type, they map (or iter) over a term.

The next module on the list is `array_inv_type.spi`. That `-` postfix after its name in the package file is there to eliminate the module wrapping.

```
nominal array' t = `(real_array_inv.create `t ``i32)
```

In the previous section how it is possible to go from the term to the type segment, and then to the term segment by nesting the ` uses.

This is the same thing. Nominals start out in the type scope and can do bottom-up style of type inference by directly evaluating an expression in term scope. If the nominal with these term fields are destructured, in the editor they will be shown as the symbol `.<term>`, but this is just an illusion. During partial evaluation they are the real thing.

`array_inv.spi` are just the bindings to the `real_array_inv` functions.

```
inl create forall t. (size : i32) : array' t = array' (real real_array_inv.create `t size)
inl index forall t. ((array' ar) : array' t) (i : i32) : t = real real_array_inv.index ar i
inl set forall t. ((array' ar) : array' t) (i : i32) (v : t) : () = real real_array_inv.set ar i v
```

Here is a small test for the library.

```
inl main () =
    open array_inv
    $"// create"
    inl x : array' _ = create 10
    $"// set 0"
    set x 0 (true, "qwe", 2i32, {q=false; w=true})
    $"// set 1 - note how record fields can be omitted in the real segment"
    real set `(bool * string * i32 * {q : bool; w : bool}) x 1 (false, "zxc", -2i32, {w=false})
    $"// index 0"
    index x 0
```
```fs
// create
let v0 : (bool []) = Array.zeroCreate<bool> 10
let v1 : (string []) = Array.zeroCreate<string> 10
let v2 : (int32 []) = Array.zeroCreate<int32> 10
let v3 : (bool []) = Array.zeroCreate<bool> 10
let v4 : (bool []) = Array.zeroCreate<bool> 10
// set 0
v0.[0] <- true
v1.[0] <- "qwe"
v2.[0] <- 2
v3.[0] <- false
v4.[0] <- true
// set 1 - note how record fields can be omitted in the real segment
v0.[1] <- false
v1.[1] <- "zxc"
v2.[1] <- -2
v4.[1] <- false
// index 0
let v5 : bool = v0.[0]
let v6 : string = v1.[0]
let v7 : int32 = v2.[0]
let v8 : bool = v3.[0]
let v9 : bool = v4.[0]
struct (v5, v6, v7, v8, v9)
```

The only function that is really missing from `real_array_inv.spir` is the length function. Implementing it and then the corresponding binding would allow the `array.spi` module function to be copy pasted and used verbatim with the new arrays.

### Serialization

Serialization comes in many guises and happens at boundaries. It involves making an isomorphic mapping that the two sides can interpret. It is about commnication through a protocol.

In the old Spiral, once had to serialize tuple one of whose fields was an union to a binary format of 32-bit floats that a NN could consume. This is remarkable because this kind of task would be fairly difficult to do in F#. .NET reflection is nasty to work with and is slow because it has to be done at runtime. Just for the Spiral plugin I had to download a library and it has quirks like raising errors at runtime for invalid JSON objects. The C# ZeroMQ library (NetMQ) which I am using to communicate with the editor is a straight up foray into assembly style programming - it is not even C style in terms of type safety.

More broadly, having to cross language boundaries in the old F# ML library that I did was the main reason why I embarked on creating Spiral. For all its performance advantages, the real reason to create a language has always been to raise one's productivity in a particular domain. A good way to raise productivity is to drive assembly style and C style programming to a minimum.

#### Pickler Combinators

It is tempting to dive right using typecase and doing bottom-up programming right away, but right now I am not actually sure how I want to do things myself. A part of the reason is that I am going to have to put in a few extra ops into the partial evaluator so that union types can be serialized.

In such a situation a good practice will be to prototype first. Another benefit of doing the combinator library first is that I'll be able to reuse its primitives in the introspective library.

This will also be a good chance to showcase the difference between SML level (F#,Ocaml,Haskell,Scala) and Spiral level programming. The general technique of [pickler combinators](https://www.microsoft.com/en-us/research/publication/functional-pearl-pickler-combinators/) is easy to grasp, is useful and might be new to even experienced functional programmers reading this.

In general, the SML level can be surpassed through hacks like runtime reflection, but that has the disadvantage of deferring type checking to runtime and slowness. Runtime code generation can be fast if not optimal, but is even harder to implement and still has the first issue. Some languages can use macros to do it at compile time, but macros are top-down and not composable. Some particularly weak programming languages use code generation to get around their lack of expressiveness, but that misses the point that programming languages are in fact just fancy code generators.

The way to start with making a pickler combinator library is to define its type first.

```
open result

type resize_array a = $"ResizeArray<`a>"
nominal pu a = {
    pickle : a -> resize_array i8 -> ()
    unpickle : mut i32 * resize_array i8 -> result a string
    }
```

There are other ways to do it, it would be possible for example to do...

```
nominal pu a = {
    pickle : a -> array i8
    unpickle : i32 -> array i8 -> result a string * i32
    }
```

This would be more functional in nature, but I've found that using references where they are appropriate rather than monadic passing of variables results in more readable code. Using resizable arrays instead of fixed arrays is also a design choice, and just adding to resizable arrays would be more performant than concatenating fixed arrays.

The choice of `i32 -> array i8` vs `i32 * array i8` as `unpickle`'s first argument would matter if the functions were doing closure conversion at any point, but that is not the case here. Using pairs would be a tad faster at compile time.

