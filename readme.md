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

#### Join points and language interop

It is a pity I cannot demostrate this benefit at the moment as Spiral is in alpha stage, but it is worth illustrating.

The previous version of Spiral, had a Cuda backend with a join point variant specific