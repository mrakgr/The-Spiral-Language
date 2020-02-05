module Spiral.CoreLib
open Spiral.ParserCombinators

let core =
    {
    name="Core"
    prerequisites=[]
    description="The Core module."
    code=
    """
/// Raises a type error.
inl error_type x = !!!!ErrorType(x)
/// Prints an expression at compile time.
inl print_static x = !!!!PrintStatic(x)
/// Pushes the expression to runtime.
inl dyn x = !!!!Dynamize(x)
/// Converts module or a function to a stack RJP.
inl rjp_stack x = !!!!RJPToStack(x)
/// Converts module or a function to a heap layout type.
inl rjp_heap x = !!!!RJPToHeap(x)
/// Converts a layout type to a module or a function.
inl rjp_none x = !!!!RJPToNone(x)

/// Does unchecked conversion for primitives.
inl to forall to. from = !!!!UnsafeConvert(`to,from) 
/// Unary negation.
inl (~-) x = !!!!Neg(x)
/// Evaluates an expression and throws away the result.
inl ignore x = ()
/// Returns an expression after evaluating it.
inl id x = x
/// Throws away the second argument and returns the first.
inl const x _ = x
/// Applies the unit to the function.
/// (() -> a) -> a
inl unconst x = x()
/// Creates an array with the given type and the size.
inl array_create forall typ. size = !!!!ArrayCreate(`typ,size)
/// Returns the length of an array. Not applicable to Cuda arrays.
inl array_length ar = !!!!ArrayLength(ar)

/// Binary addition.
inl (+) a b = !!!!Add(a,b)
/// Binary subtraction.
inl (-) a b = !!!!Sub(a,b)
/// Binary multiplication.
inl (*) a b = !!!!Mult(a,b)
/// Binary power.
inl (**) a b = !!!!Pow(a,b)
/// Binary division.
inl (/) a b = !!!!Div(a,b)
/// Binary modulo.
inl (%) a b = !!!!Mod(a,b)

/// Natural Logarithm.
inl log x = !!!!Log(x)
/// Exponent.
inl exp x = !!!!Exp(x)
/// Hyperbolic tangent. 
inl tanh x = !!!!Tanh(x)
/// Square root.
inl sqrt x = !!!!Sqrt(x)

/// 64-bit float infinity
//inl infinityf64 = !!!!InfinityF64()
/// 32-bit float infinity
//inl infinityf32 = !!!!InfinityF32()

/// TODO: For the time being since only functions are allowed on the top level, I will put these two infinities directly into the environment.

// Note: Nan is not allowed as a literal because it cannot be memoized.
// Since join points use structural equality and nan = nan returns false, nans will cause the compiler to diverge.
// Note for future language & hardware designers - make nan = nan return true!

/// Applies the first argument to the second.
inl (|>) a b = b a
/// Applies the second argument to the first.
inl (<|) a b = a b
/// Applies the third argument to the first and then the result of that to the second.
inl (>>) a b x = b (a x)
/// Applies the third argument to the second and then the result of that to the first.
inl (<<) a b x = a (b x)

/// Binary less-than-or-equals.
inl (<=) a b = !!!!LTE(a,b)
/// Binary less-than.
inl (<) a b = !!!!LT(a,b)
/// Binary equals.
inl (=) a b = !!!!EQ(a,b)
/// Returns boolean whether the two values are equal in their types.
inl (`=) a b = !EqType(a,b)
/// Binary unequals.
inl (<>) a b = !!!!NEQ(a,b)
/// Binary greater-than.
inl (>) a b = !!!!GT(a,b)
/// Binary greater-than-or-equals.
inl (>=) a b = !!!!GTE(a,b)

/// Bitwise and.
inl (&&&) a b = !!!!BitwiseAnd(a,b)
/// Bitwise or.
inl (|||) a b = !!!!BitwiseOr(a,b)
/// Bitwise xor.
inl (^^^) a b = !!!!BitwiseXor(a,b)

/// Shift left.
inl (<<<) a b = !!!!ShiftLeft(a,b)
/// Shift right.
inl (>>>) a b = !!!!ShiftRight(a,b)

/// Gets the first elements of a tuple.
inl fst (a,b) = a
/// Gets the second element of a tuple.
inl snd (a,b) = b

/// Unary negation.
inl not x = x = false
/// Indexes into a string.
inl string_index x i = !!!!StringIndex(x,i)
/// Slices a string between the two endpoints.
inl string_slice x from:to: = !!!!StringSlice(x,from,to)
/// Returns the length of a string.
inl string_length x = !!!!StringLength(x)

/// Returns boolean whether the expression is a literal.
inl is_lit x = !!!!IsLit(x)
/// Returns boolean whether the expression is a primitive type.
inl is_prim x = !!!!IsPrim(x)
/// Returns boolean whether the expression is a reified join point.
inl is_rjp x = !!!!IsRJP(x)
/// Returns boolean whether the expression is a keyword.
inl is_keyword x = !!!!IsKeyword(x)
/// Returns boolean whether the float is a Nan.
inl is_nan x = !!!!IsNan(x)
/// Converts a keyword into a sequence of pairs.
inl strip_keyword x = !!!!StripKeyword(x)

/// Raises an exception at runtime.
inl failwith forall typ. msg = !!!!FailWith(`typ,msg)
/// Asserts an expression. If the conditional is a literal it raises a type error instead.
inl assert c msg = 
    inl raise = 
        if lit_is c then error_type
        else failwith ()
    
    if c = false then raise msg
/// Returns the maximum of the two expressions.
inl max a b = if a >= b then a else b
/// Returns the minimum of the two expressions.
inl min a b = if a < b then a else b
/// Returns the absolute value.
inl abs x = max x -x
/// The template for lit_min and lit_max.
inl lit_comp op a b =
    if lit_is a && lit_is b then op a b
    elif lit_is a then a
    elif lit_is b then b
    else error_type "a or b needs to be a literal"

/// Returns the compile time expressible maximum of the two expressions.
inl lit_max x = lit_comp max x
/// Returns the compile time expressible minimum of the two expressions.
inl lit_min x = lit_comp min x

/// Maps over a record.
inl record_map f a = !!!!RecordMap(f,a)
/// Iterates over a record.
inl record_iter f a = record_map (fun x -> f x; ()) a |> ignore
/// Filters a record at compile time.
inl record_filter f a = !!!!RecordFilter(f,a)
/// Folds over a record left to right.
inl record_foldl f s a = !!!!RecordFoldL(f,s,a)
/// Folds over a record right to left.
inl record_foldr f a s = !!!!RecordFoldR(f,s,a)
/// Returns the record length.
inl record_length m = !!!!RecordLength(m)

inl rec (=) a b =
    match a, b with
    | (a, a'), (b, b') -> a = b && a' = b'
    | {} & a, {} & b -> record_foldr (fun (state:next key:value:) res -> res && match b with | { $key=value'} -> next (value = value')) a id true
    | (), () -> true
    | a, b -> 
        if is_keyword a then strip_keyword a = strip_keyword b
        elif is_rjp a then rjp_none a = rjp_none b
        else !!!!EQ(a,b)

/// Structural polymorphic equality for every type in the language (apart from functions.)
inl (=) a b = if a `= b then a = b else error_type ("Trying to compare variables of two different types. Got:",a,b)

/// Structural polymorphic inequality for every type in the language (apart from functions.)
inl (<>) a b = (a = b) <> true

inl qwe x = x
    """
    }