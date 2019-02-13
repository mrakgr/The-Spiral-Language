module Spiral.CoreLib

open Spiral.Types

let core: SpiralModule =
    {
    name = "Core"
    prerequisites = []
    description = "The Core module."
    code =
    """
/// Raises a type error.
inl error_type x = !ErrorType(x)
/// Prints an expression at compile time.
inl print_static x = !PrintStatic(x)
/// Pushes the expression to runtime.
inl dyn x = !Dynamize(x)
/// Creates a term function with the given two types.
inl (=>) a b = !TermFunctionTypeCreate(a,b)
/// Splits the union or recursive type into a tuple.
inl split x = !TypeSplit(x)
/// Boxes a type.
inl box a b = !TypeBox(a,b)
/// Converts a data type to a stack layout data type.
inl stack x = !LayoutToStack(x)
/// Converts a data type to a heap layout data type.
inl heap x = !LayoutToHeap(x)
/// Converts a data type to a mutable heap layout data type.
inl heapm x = !LayoutToHeapMutable(x)
/// Converts a layout data type to a standard data type.
inl indiv x = !LayoutToNone(x)

/// Cast a function to the term level.
inl term_cast from:to: = !TermCast(to,from)
/// Does unchecked conversion for primitives.
inl to from:to: = !UnsafeConvert(to,from) 
/// Unary negation.
inl negate x = !Neg(x)
/// Evaluates an expression and throws away the result.
inl ignore x = ()
/// Returns an expression after evaluating it.
inl id x = x
/// Throws away the second argument and returns the first.
inl const x _ = x
/// Creates a reference.
inl ref x = !ReferenceCreate(x)

inl array = 
    inl facade ar = [
        /// Returns the length of an array. Not applicable to Cuda arrays.
        length = !ArrayLength(ar)
        /// Gets the value from the array at index `get`.
        get: = !GetArray(ar, get)
        /// Sets the value `to` the array at index `set`
        set:to: = !SetArray(ar, set, to)
        /// Gets the value from the array at index `apply`.
        apply: = !GetArray(ar, apply)
        ]

    inl x -> 
        facade ([
            /// Creates an array with the given type and the size.
            type: t size: = !ArrayCreateDotNet(t,size)
            type: t = type !ArrayCreateDotNet(t,1)
            cuda = [
                /// Creates a Cuda local memory array with the given type and the size.
                local = [
                    type: t size: -> !ArrayCreateCudaLocal(t,size)
                    type: t -> type !ArrayCreateCudaLocal(t,1)
                    ]
                /// Creates a Cuda shared memory array with the given type and the size.
                shared = [
                    type: t size: -> !ArrayCreateCudaShared(t,size)
                    type: t -> type !ArrayCreateCudaShared(t,1)
                    ]
                ]
            ] x)

/// Binary addition.
inl (+) a b = !Add(a,b)
/// Binary subtraction.
inl (-) a b = !Sub(a,b)
/// Binary multiplication.
inl (*) a b = !Mult(a,b)
/// Binary power.
inl (**) a b = !Pow(a,b)
/// Binary division.
inl (/) a b = !Div(a,b)
/// Binary modulo.
inl (%) a b = !Mod(a,b)

/// Applies the first argument to the second.
inl (|>) a b = b a
/// Applies the second argument to the first.
inl (<|) a b = a b
/// Applies the third argument to the first and then the result of that to the second.
inl (>>) a b x = b (a x)
/// Applies the third argument to the second and then the result of that to the first.
inl (<<) a b x = a (b x)

/// Binary less-than-or-equals.
inl (<=) a b = !LTE(a,b)
/// Binary less-than.
inl (<) a b = !LT(a,b)
/// Binary equals.
inl (=) a b = !EQ(a,b)
/// Binary unequals.
inl (<>) a b = !NEQ(a,b)
/// Binary greater-than.
inl (>) a b = !GT(a,b)
/// Binary greater-than-or-equals.
inl (>=) a b = !GTE(a,b)

/// Bitwise and.
inl (&&&) a b = !BitwiseAnd(a,b)
/// Bitwise or.
inl (|||) a b = !BitwiseOr(a,b)
/// Bitwise xor.
inl (^^^) a b = !BitwiseXor(a,b)

/// Tuple cons.
inl (::) a b = !ListCons(a,b)
/// Shift left.
inl (<<<) a b = !ShiftLeft(a,b)
/// Shift right.
inl (>>>) a b = !ShiftRight(a,b)

/// Gets the first elements of a tuple.
inl fst x :: _ = x
/// Gets the second element of a tuple.
inl snd _ :: x :: _ = x

/// Unary negation.
inl not x = x = false
/// Returns the length of a string.
inl string_length x = !StringLength(x)
/// The .NET String.Format function.
/// https://msdn.microsoft.com/en-us/library/system.string.format(v=vs.110).aspx
/// When its arguments are literals, it evaluates at compile time.
inl string_format a b = !StringFormat(a,b)
/// The F# String.concat function
/// https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/string.concat-function-%5Bfsharp%5D
/// When its arguments are literals, it evaluates at compile time.
inl string_concat a b = !StringConcat(a,b)
/// Returns boolean whether the expression is a literal.
inl lit_is x = !LitIs(x)
/// Returns boolean whether the expression is a layout type.
inl layout_is x = !LayoutIs(x)
/// Returns boolean whether the expression is an union type.
inl union_is x = !UnionIs(x)
/// Returns boolean whether the expression is a recursive union type.
inl rec_union_is x = !RecUnionIs(x)
/// Returns boolean whether the expression is a runtime union type.
inl runtime_union_is x = !RuntimeUnionIs(x)
/// Returns boolean whether the expression is a runtime recursive union type.
inl runtime_rec_union_is x = !RuntimeRecUnionIs(x)
/// Raises an exception at runtime.
inl failwith type: t msg: = !FailWith(t,msg)
/// Asserts an expression. If the conditional is a literal it raises a type error instead.
inl assert cond:msg: = 
    inl raise = 
        if lit_is cond then error_type
        else failwith ()
    
    if cond = false then raise msg
/// Returns the maximum of the two expressions.
inl max a b = if a > b then a else b
/// Returns the minimum of the two expressions.
inl min a b = if a > b then b else a
/// The template for lit_min and lit_max.
inl lit_comp op a b =
    if lit_is a && lit_is b then op a b
    elif lit_is a then a
    elif lit_is b then b
    else error_type "a or b needs to be a literal"

/// Returns the compile time expressible maximum of the two expressions.
inl lit_max = lit_comp max
/// Returns the compile time expressible minimum of the two expressions.
inl lit_min = lit_comp min

/// Returns boolean whether the two expressions are equal in their types.
inl eq_type a b = !EqType(a,b)

/// Maps over a record.
/// (unary_keyword -> a -> b) -> a record -> b record
inl record_map f a = !recordMap(f,a)
/// Iterates over a record.
/// (unary_keyword -> a -> ()) -> a record -> ()
inl record_iter f a = record_map (inl k a -> f k a; ()) a |> ignore
/// Filters a record at compile time.
/// (unary_keyword -> a -> bool) -> a record -> a record
inl record_filter f a = !recordFilter(f,a)
/// Folds over a record left to right.
/// (unary_keyword -> state -> a -> state) -> state -> a record -> state
inl record_foldl f s a = !recordFoldL(f,s,a)
/// Folds over a record right to left.
/// (unary_keyword -> a -> state -> state) -> a record -> state -> state
inl record_foldr f a s = !recordFoldR(f,s,a)
/// Returns the record length.
/// record -> int64
inl record_length m = !recordLength(m)
/// Unsafe upcast. Unlike the F# compiler, Spiral won't check its correctness.
inl (:>) a b = !UnsafeUpcastTo(b,a)
/// Unsafe downcast. Unlike the F# compiler, Spiral won't check its correctness.
inl (:?>) a b = !UnsafeDowncastTo(b,a)

/// Structural polymorphic equality for every type in the language (apart from functions, objects and keywords.)
inl (=) a b =
    inl rec (=) a b =
        match a,b with
        | a, b when prim_is a -> !EQ(a,b)
        | a, b when layout_is a -> indiv a = indiv b
        | a :: as', b :: bs -> a = b && as' = bs
        | (), () -> true
        | {} & a, {} & b -> record_foldr (fun k x next res -> res && (match b with {$k=x'} -> next (x = x'))) a id true
        | a, b when union_is a || rec_union_is a ->
            inl f a b =
                inl #a, #b = a, b
                eq_type a b && a = b
            if runtime_rec_union a && runtime_rec_union b then join f a b : true
            else f a b
        | _ -> false
    if eq_type a b then a = b
    else error_type ("Trying to compare variables of two different types. Got:",a,b)

/// Structural polymorphic inequality.
inl (<>) a b = (a = b) <> true

/// Returns the size a type.
/// type -> int64
inl sizeof x = !SizeOf(x)

/// Creates a macro.
/// type: a body: string lit -> a
inl macro type: t text: = !Macro(body,t)
/// Creates a macro type.
/// type: (string lit & a) body: string lit -> a macro
inl macro_extern type: t text: = !MacroExtern(body,t)

/// Natural Logarithm.
inl log x = !Log(x)
/// Exponent.
inl exp x = !Exp(x)
/// Hyperbolic tangent. 
inl tanh x = !Tanh(x)
/// Square root.
inl sqrt x = !Sqrt(x)

inl infinityf64 = !InfinityF64()
inl infinityf32 = !InfinityF32()
// Note: Nan is not allowed as a literal because it cannot be memoized. Just use zero or something else.
// Since join points use structural equality and nan = nan returns false, nans will cause the compiler to diverge.
// Note for future language designers - make nan = nan return true!

/// Returns the absolute value.
inl abs x = if x >= to x 0 then x else -x

/// Cuda constants.
inl threadIdx = [
    x = macro (type: 0i64 text: "threadIdx.x")
    y = macro (type: 0i64 text: "threadIdx.y")
    x = macro (type: 0i64 text: "threadIdx.z")
    ]
inl blockIdx = [
    x = macro (type: 0i64 text: "blockIdx.x")
    y = macro (type: 0i64 text: "blockIdx.y")
    x = macro (type: 0i64 text: "blockIdx.z")
    ]

/// Checks whether the float is a nan.
inl nan_is x = !NanIs(x)

/// Does a map operation over a module while threading state.
inl record_map_foldl f s =
    record_foldl (inl k (m,s) x ->
        inl x, s = f k s x
        {m with $k = x}, s
        ) ({}, s)

/// Applies the unit to the function.
/// (() -> a) -> a
inl unconst x = x()

/// Raises an exception at the type level. `type_catch` should be used to contain and extract the type within it.
inl type_raise x = !TypeRaise(x)

{
array ref // TODO: Deal with ref tomorrow. Also `mutable_record_set`. Make `record_map_foldr`.
(=>) (+) (-) (*) (**) (/) (%) (:>) (:?>) (=) (|>) (<|) 
(>>) (<<) (<=) (<) (=) (<>) (>) (>=) (&&&) (|||) (^^^) (::) (<<<) (>>>)
log exp tanh sqrt negate to error_type print_static dyn
split box stack heap heapm indiv term_cast ignore id const fst snd not macro  
lit_is layout_is union_is rec_union_is runtime_union_is runtime_rec_union_is failwith assert max min eq_type 
sizeof string_length string_format string_concat infinityf64 infinityf32 abs threadIdx blockIdx
lit_min lit_max nan_is unconst type_raise
record_map record_filter record_foldl record_foldr record_map_foldl record_length record_iter
}
    """
    }
