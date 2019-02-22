### (Work in progress)

# Motivation

Date: 2/22/2019

Previously in development for over a year, in April 2018 the Spiral language came to maturity and I've had good nine months or so to experience what it is like to programming in a like to program in my a making of my own design. There is now a not insignificant amount of code written in Spiral itself, and my goal of making a ML library has been attained. The language has some of the best GPU programming capabilities out there and the tensor datatype is still a pride point for Spiral.

While the Spiral language itself is highly expressive and powerful enough to meet my performance requirements the previous version of Spiral is amateurishly implemented. Some things, in particularly the way I was filtering the free variables for the environment (which was an immutable map under the hood) was clearly crazy from a performance standpoint even to the me of a year ago. It was done on every function creation and to make things worse, the `inl` bindings were actually done in lambda calculus style rather than having explicit `let` constructs in the language.

This and various other issues were something that was well known to me for a long time now. In fact, I tried dealing with them then and failed due to not knowing how.

Perhaps due to the accumulation of experience the attempt this time was a success.

Not only is the environment handled sanely thanks to the new prepass, but added to the language are the Smalltalk inspired keyword arguments and inbuilt objects. In addition to that the language internals have been greatly simplified. v0.09 of Spiral is a good example of how a static language with partial evaluation should look. v0.1 of Spiral is a good example of how such a language should be implemented. Standing at 4.1k LOC without the libraries, it is a little package filled with power.

# Additions to the language

## Keyword pattern and arguments

```
inl add (left: a right: b) = a + b
add (left: 1 right: 2)
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

Like tuples and records (previously called modules), the keywords can be used on a first class basis. Their precedence is higher than type union `\/`, but lower than tuples. 

```
inl add (left: a right: b) = a + b
add left: 1 right: 2 // syntax error
```

They need to be in the first place of a expression, so code like the above is not valid.

```
inl add left:right: = left + right
add (left: 1 right: 2)
```

Similarly to records, the pattern's right sides can be omitted in which case they will default to the keyword's argument names.

## Objects

Though all the functionality of objects at compile time can be gotten through functions + pattern matching in Spiral, there are some definite issues with that sort of arrangement.

```
inl f = function
    | .add a b -> a + b
    | .mult a b -> a * b
    ...
f .add 1 2
```

The above does exactly what one would expect and is similar to having an object that has method fields. The key difference from an object is rather than using a quick dictionary lookup


```
inl Type = [
    /// Splits the union or recursive type into a tuple.
    split: x = !TypeSplit(x)
    /// Boxes a type.
    box: a to: = !TypeBox(to,a)
    /// Cast a function to the term level.
    term_cast: a with: b = !TermCast(a,b)
    /// Returns boolean whether the two expressions are equal in their types.
    eq: a to: b = !EqType(a,b)
    /// Returns the size a type.
    sizeof: x = !SizeOf(x)
    /// Raises an uncatchable type error.
    error: x = !ErrorType(x)
    /// Raises an exception at the type level. `type_catch` should be used to contain and extract the type within it.
    raise: x = !TypeRaise(x)
    /// Does unchecked conversion for primitives.
    convert:from to: = !UnsafeConvert(to,from) 
    /// The type join point
    name: join: body = !JoinPointEntryType(body(),name)
    ]
```

