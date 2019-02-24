(Work in progress)

# Motivation

Date: 2/22/2019

Previously in development for over a year, in April 2018 the Spiral language came to maturity and I've had good nine months or so to experience what it is like to programming in a like to program in my a making of my own design. There is now a not insignificant amount of code written in Spiral itself, and my goal of making a ML library has been attained. The language has some of the best GPU programming capabilities out there and the tensor datatype is still a pride point for Spiral.

While the Spiral language itself is highly expressive and powerful enough to meet my performance requirements the previous version of Spiral is amateurishly implemented. Some things, in particularly the way I was filtering the free variables for the environment (which was an immutable map under the hood) was clearly crazy from a performance standpoint even to the me of a year ago. It was done on every function creation and to make things worse, the `inl` bindings were actually done in lambda calculus style rather than having explicit `let` constructs in the language.

This and various other issues were something that was well known to me for a long time now. In fact, I tried dealing with them then and failed due to not knowing how.

Perhaps due to the accumulation of experience the attempt this time was a success.

Not only is the environment handled sanely in the partial evaluator thanks to the new prepass, but added to the language are the Smalltalk inspired keyword arguments and inbuilt objects. In addition to that the language internals have been greatly simplified. v0.09 of Spiral is a good example of how a static language with partial evaluation should look. v0.1 of Spiral is a good example of how such a language should be implemented. Standing at 4.35k LOC without the libraries, it is a neat little package filled with power.

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

I have a dichotomy in my mind about union types - on one hand I see statically typed languages that do not support them as simply not getting **it** where **it** means **abstraction**. There is simply not a reason for a statically typed language to not have pattern matching + union types apart from either stupidity or laziness.

But on other hand, Spiral's compile time features are so powerful that I've come to think of actually using union types as defeat. I had to use them in places in Spiral though. A thought growing in me is that if the task is so complex that their use is actually needed, then rather than writing an interpreter for the task maybe using an actual dynamic language would be a better choice.

# Removals from the language

## The third person language in the manual

It takes too much effort to write in a disembodied fashion. Let the 'I' rule from here on out.

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

