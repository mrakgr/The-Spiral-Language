#if INTERACTIVE
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsecCs.dll"
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsec.dll"
#r @"..\packages\ManagedCuda-CUBLAS.8.0.22\lib\net46\CudaBlas.dll"
#r @"..\packages\ManagedCuda-CURAND.8.0.22\lib\net46\CudaRand.dll"
#r @"Microsoft.CSharp"
#r @"..\The Spiral Language\bin\Release\The_Spiral_Language.dll"
#endif

open Spiral.Lib
open Spiral.Tests
open System.IO
open System.Diagnostics
open Spiral.Types

let cfg = Spiral.Types.cfg_testing

let example: SpiralModule =
    {
    name="example"
    prerequisites=[]
    description="Module description."
    code=
    """
// https://gist.github.com/SimonDanisch/812e01d7183681ed414932c8f7b533d0#file-unroll-jl
// This is not quite the same as the above example, but Spiral's staging optimizations
// only work when code is written in a functionally pure manner. 

// `sin` currently is not a part of the core library so I use a macro to interop with it.
// If it were then this whole program would be evaluated at compile time.
// To see that, replace sin with tanh or sqrt for example.
// Spiral's semantics allow for any functionally pure computation at compile time.
inl sin x = macro.fs float64 [text:"sin"; args: x]

inl rec unroll f i s =
    assert (lit_is i) "i must be a literal."
    if i > 0 then unroll f (i-1) (f s) else s

inl test () =
    inl box = 1.0
    unroll sin 3 box

test ()

//let (var_0: float) = sin(1.000000)
//let (var_1: float) = sin(var_0)
//sin(var_1)
    """
    }

let example2: SpiralModule =
    {
    name="example2"
    prerequisites=[tuple; console]
    description="Module description."
    code=
    """
inl rec foo n = 
    assert (lit_is n) "n must be known at compile time."
    assert (n >= 0) "n must greater or equal to zero."
    if n = 0 then ()
    else (if n % 2 = 0 then int32 else string) :: foo (n - 1)

inl stringify = function _: int32 -> "int" | _ : string -> "string"
foo 10 |> Tuple.map stringify |> Console.writeline
    """
    }

let example3: SpiralModule =
    {
    name="example3"
    prerequisites=[]
    description="Module description."
    code=
    """
inl x = .blocke
// Combination of not `!` and injection `$` patterns.
// Since the module does not have the member `blocke`, the case returns "asd" at compile time.
match {block=()} with 
| {!($x)} -> "asd"
| _ -> "qwe"
    """
    }

let example4: SpiralModule =
    {
    name="parser_test"
    prerequisites=[loops; parsing]
    description="Parser test for compilation speed."
    code=
    """
Loops.for {static_from=0; near_to=40; body=inl {i} ->
    Parsing.sprintf "%i, %i, %i" 1 2 3 |> ignore
    Parsing.sprintf "%i, %i, %i, %i" 1 2 3 4 |> ignore
    Parsing.sprintf "%i, %i, %i, %i, %i" 1 2 3 5 6 |> ignore
    Parsing.sprintf "(%s, %i, %f)" "asd" 11 3.3 |> ignore
    }
    """
    }

let test1: SpiralModule =
    {
    name="test1"
    prerequisites=[]
    description="Does it run?"
    code=
    """
inl a = 5
inl b = 10
a + b
    """
    }

let test2: SpiralModule =
    {
    name="test2"
    prerequisites=[]
    description="Do the join points work?"
    code=
    """
inl a () = join 5
inl b () = join 10
a () + b ()
    """
    }

let test3: SpiralModule =
    {
    name="test3"
    prerequisites=[]
    description="Does `dyn` work?"
    code=
    """
inl a = dyn 5
inl b = dyn 10
a + b
    """
    }

let test4: SpiralModule =
    {
    name="test4"
    prerequisites=[]
    description="Does the and pattern work correctly?"
    code=
    """
inl f (a, b) (c, d) = dyn (a+c,b+d)
inl q & (a, b) = dyn (1,2)
inl w & (c, d) = dyn (3,4)
f q w
    """
    }

let test5: SpiralModule =
    {
    name="test5"
    prerequisites=[]
    description="Does basic pattern matching work?"
    code=
    """
inl f = function
    | .Add x y -> join (x + y)
    | .Sub x y -> join (x - y)
    | .Mult x y -> join (x * y)
inl a = f .Add 1 2
inl b = f .Sub 1 2
inl c = f .Mult 1 2
a, b, c
    """
    }

let test6: SpiralModule =
    {
    name="test6"
    prerequisites=[]
    description="Does returning type level methods from methods work?"
    code=
    """
inl min n = join
    inl tes a = join
        inl b -> join
            inl c -> join
                inl d -> join a,b,c
    tes 1 2 (2.2,3,4.5)
min 10
    """
    }

let test7: SpiralModule =
    {
    name="test7"
    prerequisites=[]
    description="Do active patterns work?"
    code=
    """
inl f op1 op2 op3 = function
    | !op1 (.Some, x) -> x
    | !op2 (.Some, x) -> x
    | !op3 (.Some, x) -> x

inl add = function
    | .Add -> .Some, inl x y -> x + y
    | _ -> .None
inl sub = function
    | .Sub -> .Some, inl x y -> x - y
    | _ -> .None
inl mult = function
    | .Mult -> .Some, inl x y -> x * y
    | _ -> .None

inl f = f add sub mult

inl a = f .Add 1 2
inl b = f .Sub 1 2
inl c = f .Mult 1 2
dyn (a, b, c)
    """
    }

let test8: SpiralModule =
    {
    name="test8"
    prerequisites=[]
    description="Does the basic union type work?"
    code=
    """
inl option_int = .Some, (1,2,3) \/ .None

inl x = join Type (box: .None to: option_int)
match x with
| #(.Some, x) -> x
| #(.None) -> 0,0,0
    """
    }

let test9: SpiralModule =
    {
    name="test9"
    prerequisites=[]
    description="Does the partial evaluator optimize unused match cases?"
    code=
    """
inl ab = .A \/ .B
inl ab x = Type (box: x to: ab)
inl #a,#b,#c = join (ab .A, ab .A, ab .A)
match a,b,c with
| .A, _, _ -> 1
| _, .A, _ -> 2
| _, _, .A -> 3
| _ -> 4
    """
    }

let test10: SpiralModule =
    {
    name="test10"
    prerequisites=[]
    description="Do the join points get filtered?"
    code=
    """
inl ab x = Type (box: x to: (.A \/ .B))
inl #a,#b,#c,#d = join (ab .A, ab .A, ab .A, ab .A)
match a,b,c,d with
| .A, .A, _, _ -> join 1
| _, _, .A, .A -> join 2
| .A, .B, .A, .B -> join 3
| _ -> join 4
    """
    }

let test11: SpiralModule =
    {
    name="test11"
    prerequisites=[]
    description="Do the nested patterns work?"
    code=
    """
inl a = type (1,2)
inl b = type (1,a,a)
inl a,b = (inl x -> Type (box: x to: a)), (inl x -> Type (box: x to: b))
inl x = b (1, a (2,3), a (4,5))
match x with
| _, (x, _), (_, y) -> x + y
| _, _, _ -> 0
| _ :: () -> 0
    """
    }

let test12: SpiralModule =
    {
    name="test12"
    prerequisites=[]
    description="Does recursive pattern matching work on static data?"
    code=
    """
inl rec p = function
    | .Some, x -> p x
    | .None -> 0
p (.Some, .None)
    """
    }

let test13: SpiralModule =
    {
    name="test13"
    prerequisites=[]
    description="A more complex interpreter example on static data."
    code=
    """
inl rec expr x = 
    Type (
        name: "Arith"
        join:inl _ ->
            v: x
            \/ add: expr x, expr x
            \/ mult: expr x, expr x
        )
inl int_expr x = Type (box: x to: expr 0)
inl v x = int_expr (v: x)
inl add a b = int_expr (add: a, b)
inl mult a b = int_expr (mult: a, b)
inl a = add (v 1) (v 2)
inl b = add (v 3) (v 4)
inl c = mult a b

inl rec interpreter_static #x = 
    match x with
    | v: x -> x
    | add: a, b -> interpreter_static a + interpreter_static b
    | mult: a, b -> interpreter_static a * interpreter_static b
interpreter_static c
|> dyn
    """
    }

let test14: SpiralModule =
    {
    name="test14"
    prerequisites=[]
    description="Does recursive pattern matching work on partially static data?"
    code=
    """
inl rec expr x = 
    Type (
        name: "Arith"
        join:inl _ ->
            v: x
            \/ add: expr x, expr x
            \/ mult: expr x, expr x
        )
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

let test15: SpiralModule =
    {
    name="test15"
    prerequisites=[extern_]
    description="Does basic .NET interop work?"
    code=
    """
() // TODO
//open Extern
//inl builder_type = fs [text: "System.Text.StringBuilder"]
//inl b = FS.Constructor builder_type ("Qwe", 128i32)
//inl a x =
//    FS.Method b .Append x builder_type |> ignore
//    FS.Method b .AppendLine () builder_type |> ignore
//a 123
//a 123i16
//a "qwe"
//inl str = FS.Method b .ToString () string

//inl console = fs [text: "System.Console"]
//FS.StaticMethod console .Write str ()

//inl key = 1, 1
//inl value = {a=1;b=2;c=3}
//inl dictionary_type = fs [text: "System.Collections.Generic.Dictionary"; types: type (key,value)]
//inl dict = FS.Constructor dictionary_type 128i32
//FS.Method dict .Add (key,value) ()
//FS.Method dict .Item (key :: ()) value |> dyn |> ignore
//0
    """
    }

let test16: SpiralModule =
    {
    name="test16"
    prerequisites=[]
    description="Do var union types work?"
    code=
    """
inl t = 0 \/ 0.0
if dyn true then Type (box: 0 to: t)
else Type (box: 0.0 to: t)
    """
    }

let test17: SpiralModule =
    {
    name="test17"
    prerequisites=[]
    description="Do modules work?"
    code=
    """
inl m =
    inl x = 2
    inl y = 3.4
    inl z = "123"
    {x y z}
dyn (m.x, m.y, m.z)
    """
    }

let test18: SpiralModule =
    {
    name="test18"
    prerequisites=[]
    description="Do arrays and references work?"
    code=
    """
() // TODO
//inl a = ref 0
//a := 5
//a() |> ignore

//inl a = ref () // Is not supposed to be printed due to being ().
//a := ()
//a()

//inl a = ref <| term_cast (inl a, b -> a + b) (int64,int64)
//a := term_cast (inl a, b -> a * b) (int64,int64)
//a() |> ignore

//inl a = array_create int64 10
//a 3 <- 2
//a 3 |> ignore

//inl a = array_create id 3 // Is supposed to be unit and not printed.
//a 1 <- id
//a 1 |> ignore
    """
    }

let test19: SpiralModule =
    {
    name="test19"
    prerequisites=[]
    description="Does the term casting of functions work?"
    code=
    """
inl add a b (c, (d, e), f) = a + b + c + d + e + f
inl f = Type (term_cast: add 8 (dyn 7) with: type (0,(0,0),0))
f (1,(2,5),3)
    """
    }

let test20: SpiralModule =
    {
    name="test20"
    prerequisites=[]
    description="Does pattern matching on union non-tuple types work? Do type annotation patterns work?"
    code=
    """
inl t = 0 \/ 0.0
inl #x = Type (box: 3.5 to: t)
match x with
| x : 0 -> x * x
| x : 0.0 -> x + x
|> dyn
    """
    }

let test21: SpiralModule =
    {
    name="test21"
    prerequisites=[]
    description="Does defining user operators work?"
    code=
    """
inl (.+) a b = a + b
inl x = 2 * 22 .+ 33

inl f op a b = op a b
f (*) 2 x
    """
    }

let test22: SpiralModule =
    {
    name="test22"
    prerequisites=[]
    description="Do unary operators work?"
    code=
    """
() // TODO: Slated for removal.
//inl t1 x = dyn <| -x
//inl t3 x = .(x)
//t1 2.2, t3 "asd"
    """
    }

let test23: SpiralModule =
    {
    name="test23"
    prerequisites=[]
    description="Do when and as patterns work?"
    code=
    """
inl f = function
    | a,b,c as q when a < 10 -> q
    | _ -> 0,0,0
dyn (f (1,2,3))
    """
    }

let test24: SpiralModule =
    {
    name="test24"
    prerequisites=[]
    description="Do literal pattern matchers work? Does partial evaluation of equality work?"
    code=
    """
inl f x = 
    match x with
    | 0 -> "0", x
    | 1 -> "1", x
    | false -> "false", x
    | true -> "true", x
    | "asd" -> "asd", x
    | 1i8 -> "1i8", x
    | 5.5 -> "5.5", x
    | _ -> "unknown", x

dyn (f 0, f 1, f false, f true, f "asd", f 1i8, f 5.5, f 5f64)
    """
    }

let test25: SpiralModule =
    {
    name="test25"
    prerequisites=[]
    description="Does the tuple cons pattern work?"
    code=
    """
inl f = function x1 :: x2 :: x3 :: xs -> 3 | x1 :: x2 :: xs -> 2 | x1 :: xs -> 1 | () -> 0

dyn (f (), f (1 :: ()), f (1,2))
    """
    }

let test26: SpiralModule =
    {
    name="test26"
    prerequisites=[tuple]
    description="Does tuple map work? This also tests rev and foldl."
    code=
    """
// TODO
//Tuple.map (inl x -> x * 2) (1,2,3)
    """
    }

let test27: SpiralModule =
    {
    name="test27"
    prerequisites=[tuple]
    description="Do tuple zip and unzip work?"
    code=
    """
// TODO
//inl j = 2,3.3
//inl k = 4.4,55
//inl l = 66,77
//inl m = 88,99
//inl n = 123,456
//Tuple.zip ((j,k),(l,m),n) |> Tuple.unzip
    """
    }

let test28: SpiralModule =
    {
    name="test28"
    prerequisites=[extern_]
    description="Does string indexing work?"
    code=
    """
// TODO
//open Extern
//inl console_type = fs [text: "System.Console"]
//inl a = "qwe"
//inl b = FS.StaticMethod console_type .ReadLine() string
//a(0),b(0)
    """
    }

let test29: SpiralModule =
    {
    name="test29"
    prerequisites=[]
    description="Does pattern matching work redux?"
    code=
    """
inl t = 0, 0 \/ 0

inl #x = Type (box: 1,1 to: t) |> dyn
match x with
| a,b -> 0
| c -> c
    """
    }

let test30: SpiralModule =
    {
    name="test30"
    prerequisites=[]
    description="Do recursive algebraic datatypes work?"
    code=
    """
inl rec List x = 
    Type (
        name: "List"
        join: inl _ -> .nil \/ cons: x, List x
        )

inl t x = Type (box: x to: List 0)
inl nil = t .nil
inl cons x xs = t (cons: x, xs)

inl rec sum (!dyn s) l = join
    inl #l = l
    match l with
    | cons: x, xs -> sum (s + x) xs
    | .nil -> s
    : 0

nil |> cons 3 |> cons 2 |> cons 1 |> dyn |> sum 0
        """
    }

let test31: SpiralModule =
    {
    name="test31"
    prerequisites=[]
    description="Does passing types into types work?"
    code=
    """
inl a = .A, (0, 0) \/ .B, ""
inl b = a \/ .Hello
inl box a #b = Type (box: b to: a)
(.A, (2,3)) |> box a |> dyn |> box b
    """
    }

let test32: SpiralModule =
    {
    name="test32"
    prerequisites=[extern_]
    description="Do the .NET methods work inside methods?"
    code=
    """
() TODO
//open Extern
//inl convert_type = fs [text: "System.Convert"]
//inl to_int64 x = FS.StaticMethod convert_type .ToInt64 x int64
//met f = to_int64 (dyn 'a')
//f
    """
    }

let test33: SpiralModule =
    {
    name="test33"
    prerequisites=[]
    description="Do the module map and fold functions work?"
    code=
    """
inl m = {a=1;b=2;c=3}
inl m' = Record (map:inl (key:value:) -> value * 2) m
dyn (m', Record (foldl: inl (key:state:value:) -> state + value) 0 m')
    """
    }

let test34: SpiralModule =
    {
    name="test34"
    prerequisites=[]
    description="Does a simple stackified function work?"
    code=
    """
inl a = dyn 1
inl b = dyn 2
inl add c d = a + b + c + d
inl f g c d = join g c d
f (Layout (stack: add)) (dyn 3) (dyn 4)
    """
    }

let test35: SpiralModule =
    {
    name="test35"
    prerequisites=[]
    description="Does case on union types with recursive types work properly?"
    code=
    """
inl rec List x = 
    Type (
        name: "List"
        join: inl _ -> .nil \/ cons: x, List x
        )

inl Res =
    0
    \/ 0, 0
    \/ List 0

inl #x = Type (box: 1 to:Res) |> dyn
match x with
| _ : 0 -> 1
| (a, b) -> 2
| _ : (List 0) -> 3
    """
    }

let test36: SpiralModule =
    {
    name="test36"
    prerequisites=[]
    description="Does a simple heapified function work?"
    code=
    """
inl a = dyn 1
inl b = dyn 2
inl add c d = a + b + c + d
inl f g c d = join g c d
f (Layout (heap: add)) (dyn 3) (dyn 4)
    """
    }

let test37: SpiralModule =
    {
    name="test37"
    prerequisites=[]
    description="Does a simple heapified module work?"
    code=
    """
inl m = Layout (heap: { a=dyn 1; b=dyn 2 })
inl add c d = 
    inl {a b} = Layout (none: m)
    a + b + c + d
inl f g c d = join g c d
f (Layout (heap: add)) (dyn 3) (dyn 4)
    """
    }

let test38: SpiralModule =
    {
    name="test38"
    prerequisites=[]
    description="Is type constructor of an int64 an int64?"
    code=
    """
Type (box: dyn 1 to: 0)
    """
    }

let test39: SpiralModule =
    {
    name="test39"
    prerequisites=[]
    description="Does the mutable layout type get unpacked multiple times?"
    code=
    """
inl heapm x = Layout (heapm: x)
inl heap x = Layout (heap: x)
inl box a b = Type (box: b to: a)
inl q = heapm <| dyn {a=1;b=2;c=3} \/ heapm <| dyn {a=1;b=2} \/ heap <| dyn (1,2,3)
inl #x = {a=1;b=2;c=3} |> dyn |> heapm |> box q |> dyn
match Layout (none: x) with
| {a} as x ->
    inl {b} = x
    match x with
    | {c} -> a+b+c
    | _ -> a+b
| a,b,c -> a*b*c
    """
    }

let test40: SpiralModule =
    {
    name="test40"
    prerequisites=[]
    description="Does this compile into just one method? Are the arguments reversed in the method call?"
    code=
    """
inl rec f a b = join
    if dyn true then f b a
    else a + b
    : 0
f (dyn 1) (dyn 2)
    """
    }

let test41: SpiralModule =
    {
    name="test41"
    prerequisites=[]
    description="Does result in a `type ()`?"
    code=
    """
inl ty = .Up \/ .Down \/ Layout (heap: dyn {q=1;block=(1,(),3)})
inl r =
    inl #x = dyn (Type (box: .Up to: ty))
    match x with
    | .Up -> {q=1;block=(1,(),3)}
    | .Down -> {q=2;block=(2,(),4)}
    | _ -> {q=1;block=(1,(),3)}
Type (box: Layout (heap: r) to: ty)
    """
    }

let test43: SpiralModule =
    {
    name="test43"
    prerequisites=[array]
    description="Do the Array constructors work?"
    code=
    """
// TODO
//open Array

//empty int64, singleton 2.2
    """
    }

let test46: SpiralModule =
    {
    name="test46"
    prerequisites=[]
    description="Does the module pattern work?"
    code=
    """
inl f {a b c} = a + b + c
inl x =
    {
    a=1
    b=2
    c=3
    }

dyn (f {x with a = 4})
    """
    }

let test47: SpiralModule =
    {
    name="test47"
    prerequisites=[]
    description="Does the nested module pattern work?"
    code=
    """
inl f {name p={x y}} = name,(x,y)
inl x = { name = "Coord" }

f {x with 
    p = { x = 1
          y = 2 }}
|> dyn
    """
    }

let test48: SpiralModule =
    {
    name="test48"
    prerequisites=[]
    description="Does the nested module pattern with rebinding work?"
    code=
    """
inl f {name p={y=y' x=x'}} = name,(x',y')
inl x = { name = "Coord" }
f {x with 
    p = { x = 1
          y = 2 }}
|> dyn
    """
    }

let test49: SpiralModule =
    {
    name="test49"
    prerequisites=[]
    description="Does the lens pattern work? Does self work? Does the semicolon get parsed properly?"
    code=
    """
inl x = { a = { b = { c = 3 } } }

inl f {a={b={c q}}} = c,q
f {x.a.b with q = 4; c = this + 3; d = {q = 12; w = 23}}
|> dyn
    """
    }

let test50: SpiralModule =
    {
    name="test50"
    prerequisites=[array]
    description="Do the Array init and fold work?"
    code=
    """
// TODO
open Array

inl ar = init 6 (inl x -> x+1)
foldl (+) (dyn 0) ar, foldr (*) ar (dyn 1)
    """
    }

let test51: SpiralModule =
    {
    name="test51"
    prerequisites=[array]
    description="Do the Array map and filter work?"
    code=
    """
// TODO
open Array

inl ar = init 16 id
map ((*) 2) ar
|> filter ((<) 15)
    """
    }

let test52: SpiralModule =
    {
    name="test52"
    prerequisites=[array]
    description="Does the Array concat work?"
    code=
    """
// TODO
open Array

inl ar = init 4 (inl _ -> init 8 id)
concat ar
    """
    }

let test53: SpiralModule =
    {
    name="test53"
    prerequisites=[array]
    description="Does the Array append work?"
    code=
    """
// TODO
open Array

inl ar = inl _ -> init 4 id
append (ar (), ar (), ar())
    """
    }

let test54: SpiralModule =
    {
    name="test54"
    prerequisites=[tuple]
    description="Does the monadic bind `inm` work?"
    code=
    """
// TODO
inl on_succ a = (a,())
inl on_log x = ((),Tuple.singleton x)
inl (>>=) (a,w) f = // The writer monad.
    inl a',w' = f a
    (a',Tuple.append w w')

inl add x y = x + y |> on_succ

inm x = add 1 1
inm _ = on_log x
inm y = add 3 4
inm _ = on_log y
inm z = add 5 6
inm _ = on_log z
on_succ (x+y+z) // Tuple2(20L, Tuple1(2L, 7L, 11L))
    """
    }

let test56: SpiralModule =
    {
    name="test56"
    prerequisites=[]
    description="Does term casting with an unit return get printed properly?"
    code=
    """
inl add a, b = ()
inl k = Type (term_cast: add with: 0,0)
k (1, 2)
    """
    }

let test57: SpiralModule =
    {
    name="test57"
    prerequisites=[]
    description="Does the new module creation syntax work?"
    code=
    """
inl a = 1
inl b = 2
inl d = 4
{a b c = 3; d; e = 5}
    """
    }

let test58: SpiralModule =
    {
    name="test58"
    prerequisites=[array]
    description="Does the fold function get duplicated?"
    code=
    """
inl ar = array_create (int64,int64) 128
Array.foldl (inl a,b c,d -> a+c,b+d) (dyn (1,2)) ar
|> inl a,b -> a*b
    """
    }

let test59: SpiralModule =
    {
    name="test59"
    prerequisites=[]
    description="Does the new named tuple syntax work?"
    code=
    """
inl f [a:q b:w c:e] = q,w,e
f [ a : 1; b : 2; c : 3 ]
    """
    }

let test60': SpiralModule =
    {
    name="test60'"
    prerequisites=[]
    description="Is the trace being correctly propagated for TyTs?"
    code=
    """
inl a = dyn 1
inl b = dyn 2
inl c = dyn 3
4 + int64
    """
    }

let test61: SpiralModule =
    {
    name="test61"
    prerequisites=[]
    description="Does dyn act like id on already dyned variables? It should not."
    code=
    """
inl x = dyn false
dyn x || dyn x || dyn x

// The following is in fact the correct behavior. What happens is that x gets assumed to be true or false
// in one of the branches and then rewritten before being passed into dyn again and turned into a new variable.

//let (var_16: bool) = false
//if var_16 then
//    true
//else
//    let (var_17: bool) = false
//    if var_17 then
//        true
//    else
//        false
    """
    }

let test62: SpiralModule =
    {
    name="test62"
    prerequisites=[]
    description="Do && and || work correctly?"
    code=
    """
inl a,b,c,d,e = dyn (true, false, true, false, true)
met f x = x
f a && f b || f c && f d || f e
    """
    }

let test63: SpiralModule =
    {
    name="test63"
    prerequisites=[list]
    description="Do the list constructors work?"
    code=
    """
open List
cons 1 (cons 2 (singleton 3))
    """
    }

let test64: SpiralModule =
    {
    name="test64"
    prerequisites=[tuple]
    description="Do the tuple foldl_map and foldr_map work?"
    code=
    """
inl l = 2,3,4
{
a = Tuple.foldl_map (inl s x -> x*x, s + x*x) 0 l
b = Tuple.foldr_map (inl x s -> x*x, s + x*x) l 0
}
    """
    }

let test65: SpiralModule =
    {
    name="test65"
    prerequisites=[tuple; list]
    description="Do the list module folds work?"
    code=
    """
open List

foldl (+) (dyn 0.0) (dyn (empty float64)),
foldr (+) (dyn (empty float64)) (dyn 0.0f64)
    """
    }

let test66: SpiralModule =
    {
    name="test66"
    prerequisites=[tuple; list]
    description="Does the list module concat (and by extension append) work?"
    code=
    """
open List

inl a = cons 3 () |> cons 2 |> cons 1 |> dyn
inl b = cons 6 () |> cons 5 |> cons 4 |> dyn
inl c = dyn (cons a (singleton b))
concat c
    """
    }

let test67: SpiralModule =
    {
    name="test67"
    prerequisites=[tuple; list]
    description="Does the list module map work?"
    code=
    """
open List

inl a = cons 3 () |> cons 2 |> cons 1 |> dyn

map ((*) 2) a
    """
    }

let test68: SpiralModule =
    {
    name="test68"
    prerequisites=[tuple; list]
    description="Is it possible to make a list of lists?"
    code=
    """
open List

inl a = empty int64 |> dyn
empty a
    """
    }

let test69: SpiralModule =
    {
    name="test69"
    prerequisites=[tuple; list]
    description="Does the list module init work?"
    code=
    """
open List

init 10 (inl x -> 2.2)
    """
    }

let test70: SpiralModule =
    {
    name="test70"
    prerequisites=[]
    description="Does the argument get printed on a type error?"
    code=
    """
inl a: float64 = 5
()
    """
    }

let test71': SpiralModule =
    {
    name="test71'"
    prerequisites=[]
    description="Does the recent change to error printing work? This one should give an error."
    code=
    """
55 + id
    """
    }

let test72: SpiralModule =
    {
    name="test72"
    prerequisites=[]
    description="Does any kind of literal work in the named tuple syntax?"
    code=
    """
inl f = function
    | [1 : x] -> x
    | [true: x] -> x
    | [add: a,b] -> a+b
    | [3.3] -> 6.6

f [1: 1], f [true: 2], f [add: 1,2], f [3.3]
    """
    }

let test73: SpiralModule =
    {
    name="test73"
    prerequisites=[]
    description="Do the or module patterns work?"
    code=
    """
inl x = {a=1; c=3}
inl f = function
    | {(a | b)=t} -> t
inl g = function
    | {(a=t) | (b=t)} -> t
f x, g x
    """
    }

let test74: SpiralModule =
    {
    name="test74"
    prerequisites=[]
    description="Do the xor module patterns work?"
    code=
    """
inl x = {b=2; c=3}
inl f = function
    | {(((a | a) ^ (b | b)))=t} -> t
inl g = function
    | {(a=t) ^ (b=t)} -> t
f x, g x
    """
    }

let test75: SpiralModule =
    {
    name="test75"
    prerequisites=[]
    description="Does the not module pattern work?"
    code=
    """
inl x = {b=2; c=3}
inl f = function
    | {!a b} -> b
f x
    """
    }


//rewrite_test_cache tests cfg None //(Some(0,40))
output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) test57
|> printfn "%s"
|> ignore

