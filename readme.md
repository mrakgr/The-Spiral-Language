# The Spiral Language

Functional programming language compiling to F# and Cuda C with decent integration for both. Is extremely efficient and expressive and boasts having intensional polymorphism and first-class staging. Made for the sake of making a deep learning library which was too difficult to do in F# itself for its author.

## Tutorials

### 1: Inlinleables, Methods and Join Points

Spiral has great many similarities to other languages of the ML family, most notably F# with whom it shares the most similarity and a great deal of syntax, but in terms of semantics, it is different at its core.

`inl x = 2 // Define a 64-bit integer in Spiral.`
`let x = 2 // Define a 32-bit integer in F#.`

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

`inl x = dyn 2`
`let (var_0: int64) = 2L // Generated F# code.`

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

Besides being staged, Spiral's function allow more powerful forms of polymorphism than F#'s.