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
    pass: message args:a,b = self message a b
    ]
f .add 1 2
```

Inside the method body, the `self` variable holds the object's instance. This makes it easy to use objects for a role that would have needed a mutually recursive block of functions.

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

## The direct `open`

```
open Array

map sqrt ar // Identical to `Array.map sqrt ar`
```

Previously `open` was used to export the contents of a module into the environment.

No longer is that possible. After some deliberation, I decided that the benefits of simplifying the prepass outweight having such a complex feature in the language. The issue is that opening a variable requires knowledge of what is in it and in Spiral that is impossible without doing partial evaluation to that point. A lesser version of `open` that only accepts modules in the global namespace is possible, but would make it impossible to parallelize the parsing and the prepass in some future version of the Spiral language. 

```
let example: SpiralModule =
    {
    name="example"
    prerequisites=[module1; module2]
    opens=[["Module1"]; ["Module2"; "Submodule1"]]
    description="Do the keyword arguments get parsed correctly."
    code=
    """
()
    """
    }
```

As an alternative to that, the opens are done at the module level now. The above is how opening will be done. Other languages can afford it as they have separate typechecking and partial evaluation passes, but in Spiral this is the best way.

Even in v0.09 I've always been hesitant about `open` since it lead to ambiguity as to the correct scope of variable.

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

## The User Guide

It covers the internals of 0.09 and is completely obsolete now. I was really proud of Spiral when I wrote the user guide, but I feel that despite the language size growing in terms of lines of code, the actual implementation itself has been significantly simplified compared to back then. There is significantly less useless recursion (like in `destructure`) and I feel that my grip on memoization has significantly improved compared to a year ago. This should be reflected throughout the implementation.

