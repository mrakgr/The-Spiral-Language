module Spiral.CoreLib

open Spiral.Types

let core: SpiralModule =
    {
    name = "Core"
    prerequisites = []
    description = "The Core module."
    code =
    """
inl Type = [
    /// Splits the union or recursive type into a tuple.
    split: x = !TypeSplit(x)
    /// Boxes a type.
    box: a to: = !TypeBox(to,a)
    /// Cast a function to the term level.
    term_cast:to: = !TermCast(to,term_cast)
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
    ]

inl Macro = [
    /// Creates a macro.
    /// type: a text: string lit -> a
    type: t text: = !Macro(text,t)
    /// Creates a macro using the string literal as its type.
    /// text: (string lit & a) text: string lit -> a macro
    string: t text: = !MacroExtern(text,t)
    ]

inl Layout = [
    /// Converts a data type to a stack layout data type.
    stack: x = !LayoutToStack(x)
    /// Converts a data type to a heap layout data type.
    heap: x = !LayoutToHeap(x)
    /// Converts a data type to a mutable heap layout data type.
    heapm: x = !LayoutToHeapMutable(x)
    /// Converts a layout data type to a standard data type.
    none: x = !LayoutToNone(x)
    ]

inl String = [
    /// Returns the length of a string.
    length: x = !StringLength(x)
    /// The .NET String.Format function.
    /// https://msdn.microsoft.com/en-us/library/system.string.format(v=vs.110).aspx
    /// When its arguments are literals, it evaluates at compile time.
    format:args: = !StringFormat(format,args)
    /// The F# String.concat function
    /// https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/string.concat-function-%5Bfsharp%5D
    /// When its arguments are literals, it evaluates at compile time.
    concat: separator args: = !StringConcat(separator,args)
    ]

inl Is = [
    /// Returns boolean whether the expression is a literal.
    lit: x = !LitIs(x)
    /// Returns boolean whether the expression is a primitive type.
    prim: x = !PrimIs(x)
    /// Returns boolean whether the expression is a layout type.
    layout: x = !LayoutIs(x)
    /// Returns boolean whether the expression is an union type.
    union: x = !UnionIs(x)
    /// Returns boolean whether the expression is a recursive union type.
    rec_union: x = !RecUnionIs(x)
    /// Returns boolean whether the expression is a runtime union type.
    runtime_union: x = !RuntimeUnionIs(x)
    /// Returns boolean whether the expression is a runtime recursive union type.
    runtime_rec_union: x = !RuntimeRecUnionIs(x)
    /// Checks whether the float is a nan.
    nan: x = !NanIs(x)
    ]

inl Record = [
    /// Maps over a record.
    map:f =inl a -> !RecordMap(f,a)
    /// Iterates over a record.
    iter:f =inl a -> 
        inl x = self (map:inl x -> f x; ()) a
        ()
    /// Filters a record at compile time.
    filter:f =inl a -> !RecordFilter(f,a)
    /// Folds over a record left to right.
    foldl:f state: = inl a -> !RecordFoldL(f,state,a)
    /// Folds over a record right to left.
    foldr:f state: = inl a -> !RecordFoldR(f,state,a)
    /// Returns the record length.
    /// record -> int64
    length: x = !RecordLength(x)
    map_fold_helper=inl f (key: state:(record:state:) value:) ->
        inl value, state = f (key:key state:state value:value)
        {record with $key = value}, state
    /// Does a map operation over a record while threading state.
    map_foldl:f state: = self (foldl: self.map_fold_helper f state:(record:{} state:state))
    /// Does a map operation (starting from the back) over a record while threading state.
    map_foldr:f state: = self (foldr: self.map_fold_helper f state:(record:{} state:state))
    /// Sets a mutable record.
    set:field:to: = !SetMutableRecord(set,field,to)
    ]

/// Prints an expression at compile time.
inl print_static x = !PrintStatic(x)
/// Pushes the expression to runtime.
inl dyn x = !Dynamize(x)
/// Unary negation.
inl neg x = !Neg(x)
/// Evaluates an expression and throws away the result.
inl ignore x = ()
/// Returns an expression after evaluating it.
inl id x = x
/// Throws away the second argument and returns the first.
inl const x _ = x
/// Applies the unit to the function.
/// (() -> a) -> a
inl unconst x = x()
/// Creates a reference.
inl ref x = 
    inl x = !ReferenceCreate(x)
    [
    get = !GetReference(x)
    set: v = !SetReference(x,v)
    ]

/// Creates a term function with the given two types.
inl (=>) a b = !TermFunctionTypeCreate(a,b)
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

/// Unsafe upcast. Unlike the F# compiler, Spiral won't check its correctness.
inl (:>) a b = !UnsafeUpcastTo(b,a)
/// Unsafe downcast. Unlike the F# compiler, Spiral won't check its correctness.
inl (:?>) a b = !UnsafeDowncastTo(b,a)

/// Gets the first elements of a tuple.
inl fst x :: _ = x
/// Gets the second element of a tuple.
inl snd _ :: x :: _ = x

/// Raises an exception at runtime.
inl failwith type: t msg: = !FailWith(t,msg)
/// Asserts an expression. If the conditional is a literal it raises a type error instead.
inl assert cond:msg: = 
    inl raise msg = 
        if Is (lit: cond) then Type (error: msg)
        else failwith (type:() msg: msg)
    
    if cond = false then raise msg
/// Returns the maximum of the two expressions.
inl max a b = if a > b then a else b
/// Returns the minimum of the two expressions.
inl min a b = if a > b then b else a
/// The template for lit_min and lit_max.
inl lit_comp op a b =
    if Is (lit: a) && Is (lit: b) then op a b
    elif Is (lit: a) then a
    elif Is (lit: b) then b
    else Type (error: "a or b needs to be a literal")
        

/// Returns the compile time expressible maximum of the two expressions.
inl lit_max = lit_comp max
/// Returns the compile time expressible minimum of the two expressions.
inl lit_min = lit_comp min
/// Unary negation.
inl not x = !EQ(x,false)
/// Natural Logarithm.
inl log x = !Log(x)
/// Exponent.
inl exp x = !Exp(x)
/// Hyperbolic tangent. 
inl tanh x = !Tanh(x)
/// Square root.
inl sqrt x = !Sqrt(x)
/// Returns the absolute value.
inl abs x = if x >= Type (convert:0 to:x) then x else neg x

inl infinity = [
    f64 = !InfinityF64()
    f32 = !InfinityF32()
    ]
// Note: Nan is not allowed as a literal because it cannot be memoized. Just use zero or something else.
// Since join points use structural equality and nan = nan returns false, nans will cause the compiler to diverge.
// Note for future language designers - make nan = nan return true!

/// Cuda constants.
inl threadIdx = [
    x = Macro (type: 0i64 text: "threadIdx.x")
    y = Macro (type: 0i64 text: "threadIdx.y")
    z = Macro (type: 0i64 text: "threadIdx.z")
    ]
inl blockIdx = [
    x = Macro (type: 0i64 text: "blockIdx.x")
    y = Macro (type: 0i64 text: "blockIdx.y")
    z = Macro (type: 0i64 text: "blockIdx.z")
    ]

/// Structural polymorphic equality for every type in the language (apart from functions, objects and keywords.)
inl (=) a b =
    inl rec (=) a b =
        match a,b with
        | a, b when Is (prim: a) -> !EQ(a,b)
        | a, b when Is (layout: a) -> Layout (none: a) = Layout (none: b)
        | a :: as', b :: bs -> a = b && as' = bs
        | (), () -> true
        | {} & a, {} & b -> 
            Record (
                foldr: inl (key:k state:next value:x) res -> res && match b with {$k=x'} -> next (x = x') 
                state: id
                ) a true
        | a, b when Is (union: a) || Is (rec_union: a) ->
            inl f a b =
                inl #a, #b = a, b
                Type (eq: a to: b) && a = b
            if Is (runtime_rec_union: a) && Is (runtime_rec_union: b) then join f a b : true
            else f a b
        | _ -> false
    if Type (eq: a to: b) then a = b
    else Type (error: "Trying to compare variables of two different types. Got:",a,b)

/// Structural polymorphic inequality.
inl (<>) a b = (a = b) <> true

{
Type Macro Layout String Is Record 
ref infinity threadIdx blockIdx
(=>) (+) (-) (*) (**) (/) (%) (:>) (:?>) (=) (|>) (<|) 
(>>) (<<) (<=) (<) (=) (<>) (>) (>=) (&&&) (|||) (^^^) (::) (<<<) (>>>)
max min lit_min lit_max abs log exp tanh sqrt neg print_static dyn
ignore id const unconst fst snd not
failwith assert 
}
    """
    }
