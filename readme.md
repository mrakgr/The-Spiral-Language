<!-- TOC -->

- [News](#news)
    - [12/22/2020](#12222020)
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
    - [Bottom-Up Segment](#bottom-up-segment)
        - [The Memory Tradeoff](#the-memory-tradeoff)
        - [Types In The Bottom-Up Segment](#types-in-the-bottom-up-segment)

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

## Bottom-Up Segment

From the perspective of the written code, the bottom-up segment generally means the code in `.spir` files and in the `real` bodies. From the perspective of compilation phases, the bottom-up segment happens during partial evaluation. Parsing and the type inference would all be a part of the top-down segment.

There have been a few examples in the previous section, and in this one the advanced use cases of the Spiral language will be covered and explained.

In the previous segment, most langauge features have been covered to a degree that is enough for casual use. There are some new things, but a proficient functional programmer could be expected to pick up Spiral in a few days and make headway in it. The language has eveything a functional programmer knows and loves: first class functions, pattern matching, records, tuples, unions, static typing and so on. Spiral support the low style functional programming as much as any language without dependent types.

The real reason to use Spiral though is its support for the staged functional programming style. This should be a novelty to almost everybody. 

There is much to complain about the bottom-up segment, I've done as much in a few places earlier. It is a direct inheritance from the earlier version of Spiral where it was the only way to program. I was in love in love with it for a while, and then I dropped it in disgust, so you might thing I'd consider it a failure. But in fact it was a great success - Spiral v0.09 is a language I'd rate extremely highly on the expressiveness/performance scale. It gave me a new perspective on what both programming and functional programming is, and if I can be successful at sharing it you'll see that there is no reason to consider functional programming lesser than imperative when it comes to performance.

And as it turns out, the very same things that make the language performant are the ones which make it expressive.

### The Memory Tradeoff

Performance of a language can be boiled down to two factors:

* Understanding what the compiler is doing.
* Having the ability to express that understanding succinctly.

You do not actually have to do explicit heap allocation for it to happen. Here is how it could be done in F#.

```fs
let id x = x
id 3
```

Consider this simple F# program - `id` is of type `'a -> 'a`. Unless the compiler inlines this, or specializes it the way to compile `id` would be to let its argument pass in boxed form.

What that means is that `3` which is a 4-byte int would be turned into a heap allocated object before.

You might think this is overkill, because 3 is obviously an int here, so why waste resources by boxing it, but things aren't so simple. While it is in this situation an 4-byte int, it could be 2-byte int, or an 8-byte in another. `id` could get passed as 64-byte stack allocated struct.

How do you make a function that covers all those cases all at once in the resulting code? You compile it down to a function that takes a heap allocated object, and returns that same object. Heap allocated objects have the same footprint on the stack (24-bytes in .NET's case) so they are a bit like passing a pointer in C.

This has two important benefits, if you are doing a compiler.

* It makes generating code easy. No need to make a partial evaluator and similar optimizers.
* It is actually a good strategy for keeping code size down.

If you were doing specialization, you'd have to generate a version of the id function for every data structure...

```
let id x = x
inl main () =
    inl _ = id 1i32
    inl _ = id 2i64
    inl _ = id 3f32
    inl _ = id 5f64
    inl _ = id ("qwe",true,false,'c')
    ()
```
```fs
let rec method0 (v0 : int32) : int32 =
    v0
and method1 (v0 : int64) : int64 =
    v0
and method2 (v0 : float32) : float32 =
    v0
and method3 (v0 : float) : float =
    v0
and method4 (v0 : string, v1 : bool, v2 : bool, v3 : char) : struct (string * bool * bool * char) =
    struct (v0, v1, v2, v3)
let v0 : int32 = 1
let v1 : int32 = method0(v0)
let v2 : int64 = 2L
let v3 : int64 = method1(v2)
let v4 : float32 = 3.000000f
let v5 : float32 = method2(v4)
let v6 : float = 5.000000
let v7 : float = method3(v6)
let v8 : string = "qwe"
let v9 : bool = true
let v10 : bool = false
let v11 : char = 'c'
let struct (v12 : string, v13 : bool, v14 : bool, v15 : char) = method4(v8, v9, v10, v11)
()
```

As you can see, Spiral specialized the `id`'s join point to 5 different versions that it needed. This example might seem exagerated, but it is important is to understand the general rule of what goes into a language's performance.

It is not so much that dynamic languages are slow because they are dynamic and static languages are fast because they are static. It is not that C# is slower than C because it has garbage collection. It is not that F# is slower than C# because it is functional.

What it generally comes down to is the compilation stategy of the particular language one is using.

```fs
let id x = x
```

If you consider this function, its performance considerations should have nothing to do with memory allocation - there is no malloc, the user never told the compiler to make an object, but it happened even with static typing. This captures the essence of the problem.

If the compiler is using dynamic language compilation tricks, you get a heap allocation just for calling this function. If the compiler does specialization, you get a lot of code generated, but no heap allocation.

Since `id` is so small and simple, every moderately good optimizer would just inline it. But in practice, it does not actually take much to go beyond the capabilities of the optimizer. They generally aren't good at optimizing the data structures used.

The heap allocation and code size tradeoff actually occurs very naturally in programming. This next example is going to have a large resulting output. The programming itself is quite simple though, all I am doing is mapping an array which causes a lot of code to be generated.

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

Those maps get compiled to a bunch of tail recursive loops. Counting the lines in the above program, it comes down to 82.

It bears noting that arrays are the only heap allocated objects in the above example, but they could have just as easily been stack allocated like in the Cuda backend of previous Spiral.

I can make a one character change to the first program, and the resulting output would be a lot smaller.

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

This is 25 lines shorter then the previous one. It comes down to 57 lines.

The expense paid in lines of code is almost a third less, but now the resulting program would allocate closures on the heap. This along with the loop now requiring virtual calls to apply the closure would make the resulting program slower to execute that the first one. The first one's loops since they have the operations inlined directly might get vectorized and made even faster because of that.

Depending on the context, the fact that the program is slower might not matter. The 57 lines version would be faster to compile. If you were programming in Python or Ruby, the fully dynamic version with just a single map for every data structure that could exist would be the fastest possible way of compiling it, but would also be the slowest to actually execute.

As a general rule for reasoning about performance of languages, the more complex the programs being written in them, the more they will trend towards what their defaults are. The main reason why C is fast is because the user would never go out of your way to actually allocate closures when passing them to map functions which F#'s default. Instead the user would write out specialized loops much like those Spiral produces in the first example.

The cost of abstractions can be completely free, or they could result in heap allocated objects being juggled everywhere. The type system is a small part of that.

With that framework in place, it becomes easy to predict that performance of various languages ahead of time. Some languages might claim that they are fast, and might have flashy benchmarks comparing themselves to C. But regardless, you can look at what its defaults are - does it heap allocate basic data structures? Does it heap allocate primitives? Does it specialize like C++ or Spiral, or does it use dynamic language tricks to generate code like JVM and .NET ones do? Does it do the slow thing and then rely on the optimizer to make itself fast, or does it do the right thing from the start?

Overall though, the right thing depends on the context. If you have a very large codebase, you might not want to wait a proportionally long time to for it compile and might prefer a slower-at-runtime language on purpose.

My view, if you are doing a language that compiles to the GPU and similar restricted devices then Spiral's compilation strategy is right, period, because heap allocation that other strategies need for their abstractions is not applicable there.

### Types In The Bottom-Up Segment

In addition to quick feedback, the top-down segment does the user a great service by providing annotations to join points, functions (for closure conversion) and macros. It also fills in the type applications and inserts foralls in function bodies.

```
inl id ~x = join x
```

The above is how you would define the identity function in the top-down segment. Once the filling is done, here is how the above fragment would be written in bottom-up segment if it were done by hand.

```
inl id forall t. ~x = (join x) : t
```

The fact that `x` does not have a type annotation is intentional - annotations have completely different roles in the top-down and bottom-up segment. Join points annotations aren't strictly required unless they are recursive, but in the future they will be important for compile time performance once concurrent compilation of join points becomes a feature. This would be impossible unless their return type is provided.

In the bottom-up segments, the foralls have to be applied manually.

```
inl main () : i32 = real
    inl id forall t. ~x = (join x) : t
    id `i32 2
```
```fs
let rec method0 (v0 : int32) : int32 =
    v0
let v0 : int32 = 2
method0(v0)
```

The ` operator is used to access the type scope on the term level. It is a mistake to use it unless it is in application to a forall, and in some rare inbuilt ops.

```
inl main () : i32 = real
    inl id forall t. ~x = (join x) : t
    id `(i32 * i32) (2,3)
```
```fs
let rec method0 (v0 : int32, v1 : int32) : struct (int32 * int32) =
    struct (v0, v1)
let v0 : int32 = 2
let v1 : int32 = 3
method0(v0, v1)
```

Here is how it is possible to apply pairs. Note that the type and the term scope have completely separate environments.

```
type id t = t
inl main () : i32 = real
    inl id forall t. ~x = (join x) : t
    id `(id (i32 * i32)) (2,3)
```
```fs
let rec method0 (v0 : int32, v1 : int32) : struct (int32 * int32) =
    struct (v0, v1)
let v0 : int32 = 2
let v1 : int32 = 3
method0(v0, v1)
```

The output is same as before.

Filling in foralls (let generalization) and filling in type applications is something that is quite tedious to do by hand. In the bottom-up segment there is actually nothing preventing the user from just doing this.

```
type id t = t
inl main () : i32 = real
    inl id ~x = join x
    id (2,3)
```

This is how programming used to be done in the old Spiral. From the perspective of parametric type systems this code is complete gibberish, but to me it demonstrates that functions are the ultimate tools of abstraction, and that macros are only needed for interop.

And the language is still statically typed, there is no doubt about that. It is just that typing is processed in a bottom-up fashion.

Right here I will switch to a `.spir` file. The difference between `.spi` and `.spir` is that the later have their top level statements interpreted as bottom-up, similarly to the local statements in `real` blocks. Here is an example, written in `a.spir`.

```
inl main () : i32 = 1i32 + 2f64
```
```
Error trace on line: 2, column: 10 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
inl main () : i32 = 1i32 + 2f64
         ^
Error trace on line: 2, column: 21 in module: c:\Users\Marko\Source\Repos\The Spiral Language\Spiral Compilation Tests\compilation_tests\tutorial1\a.spir.
inl main () : i32 = 1i32 + 2f64
                    ^
The two literals must be both numeric and equal in type.
Got: 1i32 and 2.000000f64
```

You won't get an error before you try to compile it, but once you do instead getting a compiled file, you will get a trace as a fatal error in the editor. The trace displays the execution path of the partial evaluator up until the error.

TODO: In the future I might have a separate window open for it with links to specific fragments the trace points to, but now the easiest way to read it is to copy paste it somewhere. The fatal error message window does not have enough room to display it properly.

Doing things bottom up gives a natural form of dead code elimination and bundling.

One of the bad traits of it is that type errors can remain hidden until they are stepped on.

```
open real_core
inl f () = 1i32 + 2f64
inl main () : i32 = 1
```
```fs
1
```

`f` is never partially evaluated so the error never manifests and the file compiles peacefully even if would be better that it did not.

```
inl main () : i32 =
    inl id forall t. ~x = (join x) : t
    id `(i32 * i32) (2,3)
```

Let us backtrack to this previous example. It was shown that the tedium of could be avoided by ommiting the forall entirely. Another way it could be done is to infer the type. This actually possible in the bottom-up segment, but it needs to be done programmatically.

```
inl main () =
    inl id forall t. ~x = (join x) : t
    inl f x = id `(`x) x
    f (2,3)
```
```fs
let rec method0 (v0 : int32, v1 : int32) : struct (int32 * int32) =
    struct (v0, v1)
let v0 : int32 = 2
let v1 : int32 = 3
method0(v0, v1)
```

On the term level you can use ` to open the type level. You can use the same unary operator again to go back to the term scope. The term gets evaluated, then converted to a type.

This makes it possible to get a type of an expression without having to explicitly pass it using a forall.

The identity function is simple, so in the bottom up segment you'd just not put in the forall and be done with it. The trouble starts when you encounter situations that do need annotations ahead of time.

The simplest example to illustrate this would be the array map function. In the top down segment its type is `forall 'a 'b. ('a -> 'b) -> array 'a -> array 'b`.

If you were implementing it in the bottom up segment, you'd start with something like...

```
inl array_map f x = ...
```

So no foralls, because those are tedious. `x` is an array and you can extract the type of its element to get `'a`. That is not difficult. What you really need though is `'b`.

```
inl array_map f x =
    inl x' = array.create ? (array.length x)
```

You need `'b` in order to create the output array for the map function. You can't get the type from `f` directly because in the bottom up segment nothing is annotated. Because of that the partial evaluator does not know the return type of `f` unless it runs it with some input.

```
inl array_map f x =
    inl x' = array.create `(`(f ?)) (array.length x)
```

You'd do it roughly like this. Now you need to provide the input somehow. Here is how the type of the array can be extracted.

```
inl array_map f x =
    typecase `x with
    | array ~t =>
```

Spiral supports a typecase constructor for pattern matching on types. In typecase specifically `~t` can be used to make new bindings. Now the problem is that although you have `t` which is a type of the array, in order to call `f` you actually need a term.

```
inl array_map f x =
    typecase `x with
    | array ~t =>
        inl x' = array.create `(`(f ``t)) (array.length x)
```

The double grave operator can be used to do that. It creates a term out of a type. This is fine, since the code in the type scope will not get generated. If you try using that operator on the term level and the code with the `TypeToVar` op gets passed into the code generator you will get a trace + type error during code generation.

The next you need to loop over the array, mapping the inputs to the outputs. To make things simpler, let me instead use `array.init` which creates an array and loops over it.

