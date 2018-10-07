module Spiral.CoreLib

let module_ = Types.module_
let core =
    (
    "Core",[],"The Core module.",
    """
/// Lifts a literal to the type level.
inl type_lit_lift x = !TypeLitCreate(x)

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
/// Converts module or a function to a stack layout type.
inl stack x = !LayoutToStack(x)
/// Converts module or a function to a packed stack layout type.
inl packed_stack x = !LayoutToPackedStack(x)
/// Converts module or a function to a heap layout type.
inl heap x = !LayoutToHeap(x)
/// Converts module or a function to a mutable heap layout type.
inl heapm x = !LayoutToHeapMutable(x)
/// Converts a layout type to a module or a function.
inl indiv x = !LayoutToNone(x)

/// The type of a boolean.
inl bool = type true 

/// The type of a int64.
inl int64 = type 0i64 
/// The type of a int32.
inl int32 = type 0i32 
/// The type of a int16.
inl int16 = type 0i16 
/// The type of a int8.
inl int8 = type 0i8 

/// The type of a uint64.
inl uint64 = type 0u64 
/// The type of a uint32.
inl uint32 = type 0u32 
/// The type of a uint16.
inl uint16 = type 0u16 
/// The type of a uint8.
inl uint8 = type 0u8

/// The type of a float64.
inl float64 = type 0f64
/// The type of a float32.
inl float32 = type 0f32

/// The type of a string.
inl string = type ""
/// The type of a char.
inl char = type ' '

/// Casts a type literal to the term level.
inl type_lit_cast x = !TypeLitCast(x)
/// Returns whether the expression is a type literal as a bool.
inl type_lit_is x = !TypeLitIs(x)
/// Cast a function to the term level.
inl term_cast to from = !TermCast(to,from)
/// Does unchecked conversion for primitives.
inl to to from = !UnsafeConvert(to,from) 
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

/// Creates an array with the given type and the size.
inl array_create typ size = !ArrayCreate(size,typ)
/// Creates a Cuda shared memory array with the given type and the size.
inl array_create_cuda_shared typ size = !ArrayCreate(.cuda_shared,size,typ)
/// Creates a Cuda local memory array with the given type and the size.
inl array_create_cuda_local typ size = !ArrayCreate(.cuda_local,size,typ)
/// Returns the length of an array. Not applicable to Cuda arrays.
inl array_length ar = !ArrayLength(ar)
/// Partial active pattern. In `on_succ` it also passes the type of the array as a type string.
inl array_is x on_fail on_succ = !ArrayIs(x,on_fail,on_succ)
/// Type of an array with the given type.
inl array t = type (array_create t 1)

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
/// Returns boolean whether the expression is a box (but not an union type.)
inl box_is x = !BoxIs(x)
/// Returns boolean whether the expression is a union or a recursive type (excluding boxes.)
inl caseable_is x = !CaseableIs(x)
/// Returns boolean whether the expression is a union or a recursive type.
inl caseable_box_is x = !CaseableBoxIs(x)
/// Raises an exception at runtime.
inl failwith typ msg = !FailWith(typ,msg)
/// Asserts an expression. If the conditional is a literal it raises a type error instead.
inl assert c msg = 
    inl raise = 
        if lit_is c then error_type
        else failwith ()
    
    if c = false then raise msg
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
/// Returns the values of a module in a tuple.
inl module_values x = !ModuleValues(x)
/// Maps over a module.
/// (string type_lit -> a -> b) -> a module -> b module
inl module_map f a = !ModuleMap(f,a)
/// Filters a module at compile time.
/// (string type_lit -> a -> bool) -> a module -> a module
inl module_filter f a = !ModuleFilter(f,a)
/// Folds over a module left to right.
/// (string type_lit -> state -> a -> state) -> state -> a module -> state
inl module_foldl f s a = !ModuleFoldL(f,s,a)
/// Folds over a module right to left.
/// (string type_lit -> a -> state -> state) -> a module -> state -> state
inl module_foldr f a s = !ModuleFoldR(f,s,a)
/// Returns boolean whether the module has a member.
/// string type_lit -> a module -> bool
inl module_has_member x m = !ModuleHasMember(x,m)
/// Returns the module length.
/// module -> int64
inl module_length m = !ModuleLength(m)
/// Unsafe upcast. Unlike the F# compiler, Spiral won't check its correctness.
inl (:>) a b = !UnsafeUpcastTo(b,a)
/// Unsafe downcast. Unlike the F# compiler, Spiral won't check its correctness.
inl (:?>) a b = !UnsafeDowncastTo(b,a)

/// Structural polymorphic equality for every type in the language (apart from functions.)
inl (=) a b =
    inl rec (=) a b =
        inl body a,b = 
            match a,b with
            | .(a), .(b) -> a = b
            | a :: as', b :: bs -> a = b && as' = bs
            | {} & a, {} & b -> module_values a = module_values b
            | (), () -> true
            | a, () -> false // Just in case `b` has not been `Case`d up to this point. This can happen for `(int64, int64) \/ int64` kind of types.
            | a, b when eq_type a b -> !EQ(a, b) // This repeat eq_type check is because unboxed union types might lead to variables of different types to be compared.
            | _ -> false
        if caseable_is a && caseable_is b then join (body (a, b) : true)
        else body (a, b)
    if eq_type a b then a = b
    else error_type ("Trying to compare variables of two different types. Got:",a,b)

/// Structural polymorphic unequality for every type in the language (apart from functions.)
inl (<>) a b = (a = b) <> true

/// Returns the size a type.
/// type -> int64
inl sizeof x = !SizeOf(x)

/// Creates a .NET type from a macro.
inl fs x = !DotNetTypeCreate(x)
/// Creates a Cuda type from a macro.
inl cd x = !CudaTypeCreate(x)

/// Natural Logarithm.
inl log x = !Log(x)
/// Exponent.
inl exp x = !Exp(x)
/// Hyperbolic tangent. 
inl tanh x = !Tanh(x)
/// Square root.
inl sqrt x = !Sqrt(x)

/// Macros.
inl macro = {
    /// F# macro.
    fs = inl typ expr -> !MacroFs(typ,expr)
    /// Cuda macro.
    cd = inl typ expr -> !MacroCuda(typ,expr)
    }

inl infinityf64 = !InfinityF64()
inl infinityf32 = !InfinityF32()
// Note: Nan is not allowed as a literal because it cannot be memoized. Just use zero or something else.
// Since join points use structural equality and nan = nan returns false, nans will cause it to diverge.
// Note for future language designers - make nan = nan return true!

/// Returns the absolute value.
inl abs x = if x >= to x 0 then x else -x

/// Checks whether the type can move past language boundaries.
inl blittable_is x = !BlittableIs(x)

inl threadIdx (.x | .y | .z) as x = macro.cd int64 [text: "threadIdx."; text: x]
inl blockIdx (.x | .y | .z) as x = macro.cd int64 [text: "blockIdx."; text: x]

/// Converts a type to a variable. Not to be used on the term level.
inl var x = !ToVar(x)

/// Adds a variable to the module.
inl module_add name v s = !ModuleAdd(name,v,s)
/// Removes a variable from the module. Does nothing if the variable is not present.
inl module_remove name s = !ModuleRemove(name,s)

/// Converts the argument (usually a module) to the object form.
inl obj s x = s x s

/// Checks whether the float is a nan.
inl nan_is x = !NanIs(x)

/// Stackifies a module.
inl stackify = module_map (const stack) >> stack

/// Case that folds a literal through its branches.
inl case_foldl_map f s x = !CaseFoldLMap(f,s,x)

/// Does a map operation over a module while threading state.
inl module_foldl_map f s =
    module_foldl (inl k (m,s) x ->
        inl x, s = f k s x
        inl m = module_add k x m
        m, s
        ) ({}, s)

/// Maps the leaves of the intersection of the two modules.
inl module_intersect f a b = 
    inl rec loop = function
        | {} & a, {} & b ->
            module_foldl (inl k m a ->
                match b with
                | {$k=b} -> {m with $k=loop (a,b)}
                | _ -> m
                ) {} a
        | a,b -> f a b
    loop (a,b)

{
type_lit_lift error_type print_static dyn (=>) cd fs log exp tanh sqrt array_create array_length array_is array
split box stack packed_stack heap heapm indiv bool int64 int32 int16 int8 uint64 uint32 uint16 uint8 float64 float32
string char type_lit_cast type_lit_is term_cast to negate ignore id const ref (+) (-) (*) (**) (/) (%)
(|>) (<|) (>>) (<<) (<=) (<) (=) (<>) (>) (>=) (&&&) (|||) (^^^) (::) (<<<) (>>>) fst snd not macro
string_length lit_is box_is failwith assert max min eq_type module_values caseable_is caseable_box_is (:>)
(:?>) (=) module_map module_filter module_foldl module_foldr module_has_member sizeof string_format string_concat
array_create_cuda_shared array_create_cuda_local infinityf64 infinityf32 abs blittable_is threadIdx blockIdx
lit_min lit_max var module_add module_remove obj nan_is stackify case_foldl_map module_foldl_map module_length
module_intersect
}
|> module_map (const stack)
    """) |> module_
