<!-- TOC -->

- [News](#news)
    - [12/22/2020](#12222020)
    - [12/24/2020](#12242020)
- [The Spiral Language](#the-spiral-language)
    - [Overview](#overview)
    - [Getting Spiral](#getting-spiral)
    - [Status in 12/24/2020](#status-in-12242020)
    - [Projects & Packages](#projects--packages)
        - [TODO](#todo)
    - [Top-down modules](#top-down-modules)
        - [Compilation](#compilation)
            - [TODO](#todo-1)
        - [Basics](#basics)
        - [Join points](#join-points)
            - [TODO - Join points and language interop](#todo---join-points-and-language-interop)
        - [Functions](#functions)
        - [What triggers dyning?](#what-triggers-dyning)
        - [Macros](#macros)
        - [Layout types](#layout-types)

<!-- /TOC -->

# News

## 12/22/2020

v0.2 is in alpha stage and I've moved development from the `v0.2` branch to `master`.

The docs from v0.9 are obsolete and will need to be redone. More to come soon. Right now I am cleaning things up and getting ready to publish the VS Code plugin + compiler on the VS Code marketplace.

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
* First class functions, pairs and records.
* Composable layouts of data structures.
* Symbols as singleton types.

Spiral is such a language.

Statically typed and with a lightweight, very powerful type system giving it expressiveness of dynamic languages and the speed of C, Spiral is the crystallization of staged functional programming. It boasts of having intensional polymorphism and first-class staging. Its primary purpose is the creation of ML libraries for novel kinds of AI hardware.

## Getting Spiral

The language is published on the VS Code marketplace. Getting it is just a matter of installing the **The Spiral Language** plugin. This will install both the VS Code editor plugin and the compiler itself. The compiler itself requires the .NET Core 3.1 rutime and is portable across platforms.

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

Besides those 4, there package file schema also supports `name` and `version` fields, but those do not affect compilation in any way at the moment.

The great thing about packages is that their processing is done concurrently. While modules are processed strictly sequentially as in F#, packages are more flexible. Circular links between packages though are not allowed and will report an error. 

As long as any of the loaded packages has an error, type inference won't work - the changes will cached until the package errors are resolved and only show the previous results.

### TODO

* Put the core library somewhere the users can get it. Right now it is buried in `Spiral Compilation Tests\compilation_tests`.
* Expand the `packages` field parser so that more elaborate paths can be provided.

## Top-down modules

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

#### TODO

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
inl main () = join heap {q = {a=1i32; n= heap {b=2i32; c=3i32}}}
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
type Heap0 = {l0 : int32; l1 : int32}
and Mut0 = {mutable l0 : int32; mutable l1 : int32}
let v0 : Mut0 = {l0 = 1; l1 = 2} : Mut0
v0.l0 <- 3
v0.l1 <- 4
```

