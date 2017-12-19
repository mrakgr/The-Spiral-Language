# The Spiral Language

## Overview

Statically typed functional programming language compiling to F# and Cuda C with decent integration for both. Is extremely efficient and expressive, and boasts having intensional polymorphism and first-class staging. Made for the sake of making a deep learning library which was too difficult to do in F# itself for its author.

## Dependencies

##### For the compiler:

FParsec
Visual Studio 2017 F# template (.NET desktop development)

##### For the Cuda using Spiral libraries:

ManagedCuda 8.0 + (CUBLAS,CURAND)
Cuda SDK 8.0 + 9.0 (8.0 for the libraries and 9.0 for the NVCC compiler)
The Cuda Unbound library
Visual Studio 2017 C++ tools individual component (VC++ 2017 v141 toolset (x86,x64))

## Tutorials: Introduction to Spiral

### 0: The way to use the language

The easiest way to do it right now would be to clone this repo. In the Testing project, look at `run.fs`. It has the latest example I am using for the tutorial. Select the `Testing` project as the starter one and point the output to the `output.fs` file in the `Temporary` project. Don't worry about getting it wrong - at worst you will get an exception.

You do not need deal with Cuda configuration options in the `run.fs` file unless you want to use the libraries related to that.

### 1: Inlinleables, Methods and Join Points

Spiral has great many similarities to other languages of the ML family, most notably F# with whom it shares the most similarity and a great deal of syntax, but in terms of semantics, it is different at its core.

```
inl x = 2 // Define a 64-bit integer in Spiral.
```
```
let x = 2 // Define a 32-bit integer in F#.
```

Unlike in F#, statements and function definitions in Spiral are preceded by `inl` instead of `let` which is short for `inl`inleable or `inl`ine.

```
let x = 2
()
```

If you were to take a program like the above one and disassemble it, you'd see that `x` would compile down to a public method in F#. In Spiral in contrast, you would get nothing.

```
module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""
```

It is not absolutely nothing though. If the program used Cuda kernels in it, they would gathered at the top of the file inside the `cuda_kernels` variable. For interests of brevity, the unremarkable top part will be cut out during the tutorials.

```
inl x = dyn 2
```
```
let (var_0: int64) = 2L // Generated F# code.
```

The reason Spiral is generating nothing is because `2` as defined is a literal and is gets tracked as such by the partial evaluator inside the environment. Suppose you want to have it appear in the generated code, what you would do is cast it from the type to the term level using `dyn`amize function. From here on out, the literal will be bound to a variable and the binding `x` will track `var_0` instead.

Being able to do this is useful for various reasons and without the ability to do this constructs such as runtime loops would be impossible to write in Spiral because the partial evaluator would diverge. Despite its static typing features, the language would essentially be constrained to being an interpreter for a pure dynamic functional language.

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

To get a sense of how `dyn` works, here is a slightly more complex example. The evaluator does common subexpression elimination in the local scope so it is smart enough to optimize the `x+y` into a single addition and a multiplication.

```
inl x = 2
inl y = 3
(x + y) * (x + y)
```

```
25L
```

Without `dyn`, all the arithmetic operations get evaluated at compile time. This is due to the simple fact that a variable + a literal is a variable. In general if an operation has a variable as one of its inputs, then its output will also be a variable. The evaluator term casts the literals when necessary. For an operation to be evaluated at compile time, the partial evaluator must have support for it internally.

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

Tuples are used in Spiral much in the same way as in other functional languages. As per their name, `inl`inleables are always inlined. There are no heuristics at play here in the evaluator. Spiral's staged functions are tracked at the type level and both their exact body and environments are known at every point of compilation. This is an absolute guarantee and there is no point at which they can be automatically converted into heap allocated closures.

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

That having said, Spiral is a statically typed language and any type errors for code on the execution path will get reported at compile time along with the trace for it.

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

Since in order to achieve code reuse methods are necessary, Spiral makes it possible to make use of them with the `met` keyword. It works much like `inl`.

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

The result would not be as you would expect since the methods would get specialized to the literal arguments passed to them. Instead it would be better to use `dyn` here. But rather than letting the caller `f` do the term casting operation, it would be better if the callee `mult` did it.

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

`!` on the left (the pattern) side of the expression is the active pattern unary operator. It takes a function as its first argument, applies the input to it and rebinds the result to second argument of the pattern (in this case `a` and `b` respectively) before the body is evaluated.

#### Recursion, destructuring and pattern matching

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
In ML languages, `::` is the list cons pattern. In Spiral it is the the tuple cons pattern. Tuple are fully fledged heterogeneous lists in Spiral and can be treated as such.

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
While language allow variant arguments, Spiral has the ability to specialize methods to their exact arguments and in combination with destructuring to implement variant arguments in a typesafe manner. 

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

By default, in Spiral all the data structures in Spiral are flattened and have their variables tracked individually. As can be seen in the generated code, when a tuple is passed into a function it is not the actual tuple that is being passed into it, but its arguments instead.

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

Tuples themselves are only manifested in the generated code on join point and branch returns. They get destructured right away and tracked by their individual variables on bindings and function applications. Had I not bound the method return to `x`, it would not have been destructured. This is the desired behavior because otherwise destructuring might block tail call optimizations.

```
met f _ = 1
```
```
inl f _ = join (1)
```
The above two code fragments are identical in Spiral. `met` is just syntax sugar for a function with a join point around its body.

Being able to do this is quite powerful as it allows more fine grained control over inlining.

```
inl rec foldl f s = function
    | x :: xs -> foldl f (f s x) xs
    | () -> s

inl rec forall f = function
    | x :: xs -> f x && forall f xs
    | () -> true

inl sum l = 
    if forall lit_is l then foldl (+) 0 l
    else join (foldl (+) 0 (dyn l))

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
The `lit_is` just like other structure testing functions always resolves at compile time to either `true` or `false`. In combination with `forall` that allows for testing of whether all the arguments of `l` are known at compile time. Then using a static if, the two branches amount to either summing them all at compile time, or term casting them and pushing the work to runtime.

This ensures that the sum function does not get specialized to every arbitrary literal passed into it.
```
if true then 1 else "qwe" // Not a type error.
```
```
if dyn true then 1 else "qwe" // A type error.
```
If statements in Spiral default to evaluating only one branch if their conditional is known at compile time. This is the bedrock of its intensional (structural) polymorphism. Under the hood, the patterns get compiled to static if statements which allow it to branch on structures and types.

I goes hand in hand with join point specialization.

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
inl int64_type = type (1)
inl float64_type = type (1.0)
inl string_type = type ("qwe")

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

Like `join`, `type` is a keyword and needs its body to be surrounded by parenthesis.

The types themselves can do more than be passed around or be matched on.

```
inl int64_type = type (1)
inl float64_type = type (1.0)
inl string_type = type ("qwe")

inl default_of = function
    | _: int64_type -> 0
    | _: float64_type -> 0.0
    | _: string_type -> ""

inl a = type (int64_type + 1)
inl b = type (float64_type + 1.0)
inl c = type (string_format "{0}, {1}" (string_type, "rty"))

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

##### Join point recursion

Spiral in general does not need type annotations. The only exception is the recursion when used in tandem with join points.

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
`:` has the lowest precedence of all Spiral's constructs so it will get applied before any of the statements. It does not necessarily have to be put directly into the function. As reminder, on the pattern side `:` is not a type annotation, but a type equality test.
```
inl rec fact x =
    inl body x = if x > 1 then x * fact (x-1) else 1
    if lit_is x then body x
    else join (body (dyn x) : int64)
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
    | .male (!dyn n) -> join (male n : int64)
    | .female (!dyn n) -> join (female n : int64)
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
Using `print_static` you can inspect what the evaluator sees at compile time.
```
print_static (dyn (.a,"b",.false,true))
```
```
[type (type_lit (a)), var (string), type (type_lit (false)), var (bool)]
```
All the information in type literals is preserved at all times.

##### Term casting of functions

Spiral's functions as flexible as they are have the notable weakness of not being able to emulate recursive datatypes. For that they need to be cast to the term level.

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
    inl body _ = if i < 10 then loop (inl _ -> f() + 1) (i + 1) else f()
    join (body() : int64)

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

Don't be fooled by the `<function>` you will see during type errors. As was repeatedly stated, functions are not at all opaque - they are fully transpared to the evaluator. The reason why they get printed like that is simply because they have a tendency to suck everything into the environment. And except for very small examples, trying to print out the raw AST of its body is worthless even for debugging as it is so convoluted.

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
If function have same bodies, they can be returned from branches of a dynamic if statement if they also have the same environments.
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

### 2: Modules, macros and interop

(Work in progress)

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
Fields can be added to them and removed arbitrarily in an immutable fashion. Using `without` on an nonexisting field will not do anything.
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
Like with tuples which are represented by immutable lists in Spiral, the modules in Spiral allow anything immutable maps might do. For example, they can be maped over(`module_map`), folded(`module_foldl`,``module_fold`), and filtered(`module_filter`). Here is the fold example.
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
Last, but not least, Spiral's modules and functions support several kinds of layouts. By default, like tuples they have a tranparent structure whose variables are tracked on an individual basis. Here is the heap layout.
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
That is the tour of them, but it does not yet demonstrate their true power. The essence of modules when combined with layout types (layout types for short) is that they capture scope.
```
inl npc = 
    {
    health = dyn 0
    mana = dyn 0
    max_health = 40
    max_mana = 30
    } |> stack

inl ar = array_create npc 3
ar 0 <- {npc with health = dyn 10; mana = dyn 20}
ar 1 <- {npc with health = dyn 20; mana = dyn 10}
//ar 2 <- {npc with health = dyn 10; mana = dyn 20; max_health = 50} // Gives a type error
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
let (var_2: EnvStack0) = EnvStack0((var_0: int64), (var_1: int64))
let (var_3: (EnvStack0 [])) = Array.zeroCreate<EnvStack0> (System.Convert.ToInt32(3L))
let (var_4: int64) = var_2.mem_0
let (var_5: int64) = var_2.mem_1
let (var_6: int64) = 10L
let (var_7: int64) = 20L
let (var_8: EnvStack0) = EnvStack0((var_6: int64), (var_7: int64))
var_3.[int32 0L] <- var_8
let (var_9: int64) = 20L
let (var_10: int64) = 10L
let (var_11: EnvStack0) = EnvStack0((var_9: int64), (var_10: int64))
var_3.[int32 1L] <- var_11
```
In layout types, literals and naked types become a part of the bigger type and are tracked at the type level. 

The `packed_stack` layout is just there in case it might be necessary to pass a tuple over to the Cuda side. In most cases though, it makes more sense to use the default (non)layout and pass them as individual arguments.

`heapm` layout is useful for mutably updating individual fields of a heap allocated module.

Layout types are there in order to allow finer control of the boxed representations of modules and functions. Without `heap` it would be impossible to heap allocate modules directly for example.

#### Warming up with macros

Modules are beautiful and elegant part of Spiral. Macros are definitely ugly, but they are the only way for Spiral to interop with other languages' libraries and are as such indispensable.

In Spiral they have the interesting property of also acting as types.

So far all the examples given in the tutorial were relatively unmotivated. With macros it is possible to do IO.

As a very basic demonstration of them, let us start with this HackerRank problem. [Solve me first.](https://www.hackerrank.com/challenges/solve-me-first/problem)

```
// The entire code is given, you can just review and submit!
open System

[<EntryPoint>]
let main argv = 
    let a = Console.ReadLine() |> int
    let b = Console.ReadLine() |> int
    printfn "%d" (a+b)
    0 // return an integer exit code
```

The above is the F# solution given directly. It just reads two ints from input, sums them and returns the sum. Doing it in Spiral without the IDE support and even direct language support for .NET constructs make it more complicated.

First we need to define the `System.Console` type.

```
//inl console = fs ((.text, "System.Console") :: ())
inl console = fs [text: "System.Console"]
print_static console
```
```
type (dotnet_type (System.Console))
```
What this has done is create the `[text: "System.Console"]` naked type. The type shown in the output is just how it gets printed - the actual type is determined by its body, namely `[text: "System.Console"]`. This is equivalent to `((.text, "System.Console") :: ())`
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
Hence mistakes with macros will have to be responsibility of the downwards langauges. But in the worst they will just lead to a type error.

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
The above program succintly captures Spiral's approach to language interop. The facilities used for defining macro-based types and printing them are intervowen with one another. One extra ingredient macros evaluation require over macro type definitions is the return type.

What `macro.fs` is saying is essentially - print

....