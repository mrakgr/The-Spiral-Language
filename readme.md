# The Spiral Language

Functional programming language compiling to F# and Cuda C with decent integration for both. Is extremely efficient and expressive and boasts having intensional polymorphism and first-class staging. Made for the sake of making a deep learning library which was too difficult to do in F# itself for its author.

## Tutorials

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

Being able to do this is useful for various reasons and without the ability to do this constructs such as runtime loops would be impossible to write in Spiral because the partial evaluator would diverge. The language would essentially be constrained to being an interpreter for a pure dynamic functional language.

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
In ML languages, `::` is the list cons pattern. In Spiral it is the the tuple cons pattern. Tuple are fully fledged heterognous lists in Spiral and can be treated as such.

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
The `lit_is` just like other structure testing functions always resolves at compile time to either `true` or `false`. In combination with `forall` that allows for testing of whether all the arguments of `l` are known at compile time. Then using a static if, the two braches amount to either summing them all at compile time, or term casting them and pushing the work to runtime.

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
Unlike ML languages which use Hindley-Milner global type inference, Spiral does not infer as much as propagate. A consequence of that besides undecideability is that it knowns the exact structure and type of everything at all times. When done on non-union types as done up to now, this sort of branching has no runtime overhead whatsoever and can be readily seen by looking into the generated code.

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
`:` has the lowest precedence of all Spiral's constructs so it will get applied before any of the statements. It does not necessarily have to be put directly into the function.
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











