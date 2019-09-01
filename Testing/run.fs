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
open Spiral.Lib

let cfg = Spiral.Types.cfg_default

let test1: SpiralModule =
    {
    name="test1"
    prerequisites=[]
    opens=[]
    description="Does it run?"
    code=
    """
inl a = 5
inl b = 10
dyn (a + b)
    """
    }

let test2: SpiralModule =
    {
    name="test2"
    prerequisites=[]
    opens=[]
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
    opens=[]
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
    opens=[]
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
    opens=[]
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
    opens=[]
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
    opens=[]
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
    opens=[]
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
    opens=[]
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
    opens=[]
    description="Do the join points get filtered?"
    code=
    """
inl ab x = Type (box: x to: (.A \/ .B))
match join (ab .A, ab .A, ab .A, ab .A) with
| #(.A), #(.A), _, _ -> join 1
| _, _, #(.A), #(.A) -> join 2
| #(.A), #(.B), #(.A), #(.B) -> join 3
| _ -> join 4
    """
    }

let test11: SpiralModule =
    {
    name="test11"
    prerequisites=[]
    opens=[]
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
|> dyn
    """
    }

let test12: SpiralModule =
    {
    name="test12"
    prerequisites=[]
    opens=[]
    description="Does recursive pattern matching work on static data?"
    code=
    """
inl rec p = function
    | .Some, x -> p x
    | .None -> 0
p (.Some, .None)
|> dyn
    """
    }

let test13: SpiralModule =
    {
    name="test13"
    prerequisites=[]
    opens=[]
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

let test15: SpiralModule =
    {
    name="test15"
    prerequisites=[]
    opens=[]
    description="Does the object with unary patterns?"
    code=
    """
inl f = 
    [
    add = inl a b -> a + b
    mult = inl a b -> a * b
    ]
    
f .add 1 2 |> dyn
    """
    }

let test16: SpiralModule =
    {
    name="test16"
    prerequisites=[]
    opens=[]
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
    opens=[]
    description="Do records work?"
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
    opens=[]
    description="Does the term casting of functions work?"
    code=
    """
inl add a b (c, (d, e), f) = a + b + c + d + e + f
inl f = Type (term_cast: add 8 (dyn 7) with: type (0,(0,0),0))
f (1,(2,5),3)
    """
    }

let test19: SpiralModule =
    {
    name="test19"
    prerequisites=[]
    opens=[]
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

let test20: SpiralModule =
    {
    name="test20"
    prerequisites=[]
    opens=[]
    description="Does defining user operators work?"
    code=
    """
inl (.+) a b = a + b
inl x = 2 * 22 .+ 33

inl f op a b = op a b
f (*) 2 x
|> dyn
    """
    }

let test21: SpiralModule =
    {
    name="test21"
    prerequisites=[]
    opens=[]
    description="Do when and as patterns work?"
    code=
    """
inl f = function
    | a,b,c as q when a < 10 -> q
    | _ -> 0,0,0
dyn (f (1,2,3))
    """
    }

let test22: SpiralModule =
    {
    name="test22"
    prerequisites=[]
    opens=[]
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

let test23: SpiralModule =
    {
    name="test23"
    prerequisites=[]
    opens=[]
    description="Does the tuple cons pattern work?"
    code=
    """
inl f = function x1 :: x2 :: x3 :: xs -> 3 | x1 :: x2 :: xs -> 2 | x1 :: xs -> 1 | () -> 0

dyn (f (), f (1 :: ()), f (1,2))
    """
    }

let test24: SpiralModule =
    {
    name="test24"
    prerequisites=[]
    opens=[]
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

let test25: SpiralModule =
    {
    name="test25"
    prerequisites=[]
    opens=[]
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

let test26: SpiralModule =
    {
    name="test26"
    prerequisites=[]
    opens=[]
    description="Does passing types into types work?"
    code=
    """
inl a = .A, (0, 0) \/ .B, ""
inl b = a \/ .Hello
inl box a #b = Type (box: b to: a)
(.A, (2,3)) |> box a |> dyn |> box b
    """
    }

let test27: SpiralModule =
    {
    name="test27"
    prerequisites=[]
    opens=[]
    description="Do the record map and fold functions work?"
    code=
    """
inl m = {a=1;b=2;c=3}
inl m' = Record.map (inl (key:value:) -> value * 2) m
dyn (m', Record.foldl (inl (key:state:value:) -> state + value) 0 m')
    """
    }

let test28: SpiralModule =
    {
    name="test28"
    prerequisites=[]
    opens=[]
    description="Does a simple stackified function work?"
    code=
    """
inl a = dyn 1
inl b = dyn 2
inl add c d = a + b + c + d
inl f g c d = join g c d
f (stack add) (dyn 3) (dyn 4)
    """
    }

let test29: SpiralModule =
    {
    name="test29"
    prerequisites=[]
    opens=[]
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

let test30: SpiralModule =
    {
    name="test30"
    prerequisites=[]
    opens=[]
    description="Does a simple heapified function work?"
    code=
    """
inl a = dyn 1
inl b = dyn 2
inl add c d = a + b + c + d
inl f g c d = join g c d
f (heap add) (dyn 3) (dyn 4)
    """
    }

let test31: SpiralModule =
    {
    name="test31"
    prerequisites=[]
    opens=[]
    description="Does a simple heapified record work?"
    code=
    """
inl m = heap { a=dyn 1; b=dyn 2 }
inl add c d = 
    inl {a b} = indiv m
    a + b + c + d
inl f g c d = join g c d
f (heap add) (dyn 3) (dyn 4)
    """
    }

let test32: SpiralModule =
    {
    name="test32"
    prerequisites=[]
    opens=[]
    description="Is type constructor of an int64 an int64?"
    code=
    """
Type (box: dyn 1 to: 0)
    """
    }

let test33: SpiralModule =
    {
    name="test33"
    prerequisites=[]
    opens=[]
    description="Does the mutable layout type get unpacked multiple times?"
    code=
    """
inl box a b = Type (box: b to: a)
inl q = heapm <| dyn {a=1;b=2;c=3} \/ heapm <| dyn {a=1;b=2} \/ heap <| dyn (1,2,3)
inl #x = {a=1;b=2;c=3} |> dyn |> heapm |> box q |> dyn
match indiv x with
| {a} as x ->
    inl {b} = x
    match x with
    | {c} -> a+b+c
    | _ -> a+b
| a,b,c -> a*b*c
    """
    }

let test34: SpiralModule =
    {
    name="test34"
    prerequisites=[]
    opens=[]
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

let test35: SpiralModule =
    {
    name="test35"
    prerequisites=[]
    opens=[]
    description="Does result in a `type ()`?"
    code=
    """
inl ty = .Up \/ .Down \/ heap <| dyn {q=1;block=(1,(),3)}
inl r =
    inl #x = dyn (Type (box: .Up to: ty))
    match x with
    | .Up -> {q=1;block=(1,(),3)}
    | .Down -> {q=2;block=(2,(),4)}
    | _ -> {q=1;block=(1,(),3)}
Type (box: heap r to: ty)
    """
    }

let test36: SpiralModule =
    {
    name="test36"
    prerequisites=[]
    opens=[]
    description="Does the record pattern work?"
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

let test37: SpiralModule =
    {
    name="test37"
    prerequisites=[]
    opens=[]
    description="Does the nested record pattern work?"
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

let test38: SpiralModule =
    {
    name="test38"
    prerequisites=[]
    opens=[]
    description="Does the nested record pattern with rebinding work?"
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

let test39: SpiralModule =
    {
    name="test39"
    prerequisites=[]
    opens=[]
    description="Does the lens pattern work? Does self work? Does the semicolon get parsed properly?"
    code=
    """
inl x = { a = { b = { c = 3 } } }

inl f {a={b={c q}}} = c,q
f {x.a.b with q = 4; c = this + 3; d = {q = 12; w = 23}}
|> dyn
    """
    }

let test40: SpiralModule =
    {
    name="test40"
    prerequisites=[]
    opens=[]
    description="Does term casting with an unit return get printed properly?"
    code=
    """
inl add a, b = ()
inl k = Type (term_cast: add with: 0,0)
k (1, 2)
    """
    }

let test41: SpiralModule =
    {
    name="test41"
    prerequisites=[]
    opens=[]
    description="Does the new record creation syntax work?"
    code=
    """
inl a = 1
inl b = 2
inl d = 4
dyn {a b c = 3; d; e = 5}
    """
    }

let test42: SpiralModule =
    {
    name="test42"
    prerequisites=[]
    opens=[]
    description="Is the trace being correctly propagated for TyTs?"
    code=
    """
inl a = dyn 1
inl b = dyn 2
inl c = dyn 3
4 + type 0
    """
    }

let test43: SpiralModule =
    {
    name="test43"
    prerequisites=[]
    opens=[]
    description="Does the partial evaluation of if statements work?"
    code=
    """
inl x = dyn false
inl _ = dyn (x && (x || x && (x || x)))
inl _ = dyn ((x && x || x) || (x || true))
inl _ = dyn (if x then false else x)
dyn (if x then false else true)

//let ((var_1 : bool)) = false
//let ((var_2 : bool)) = true
//let ((var_3 : bool)) = false
//let ((var_4 : bool)) = var_1 = false
    """
    }

let test44: SpiralModule =
    {
    name="test44"
    prerequisites=[]
    opens=[]
    description="Do && and || work correctly?"
    code=
    """
inl a,b,c,d,e = dyn (true, false, true, false, true)
a && b || c && d || e
    """
    }

let test45: SpiralModule =
    {
    name="test45"
    prerequisites=[]
    opens=[]
    description="Does the argument get printed on a type error?"
    code=
    """
inl a : 0f64 = 5
()
    """
    }

let test46: SpiralModule =
    {
    name="test46"
    prerequisites=[]
    opens=[]
    description="Does the recent change to error printing work? This one should give an error."
    code=
    """
55 + id
    """
    }

let test47: SpiralModule =
    {
    name="test47"
    prerequisites=[]
    opens=[]
    description="Does structural polymorphic equality work?"
    code=
    """
{a=1;b=dyn 2;c=dyn 3} = {a=1;b=2;c=3}
    """
    }

let test48: SpiralModule =
    {
    name="test48"
    prerequisites=[]
    opens=[]
    description="Does this destructure trigger an error?"
    code=
    """
inl q = true && dyn true
()
    """
    }

let test49: SpiralModule =
    {
    name="test49"
    prerequisites=[]
    opens=[]
    description="Does changing layout type work?"
    code=
    """
{a=1; b=2} |> dyn |> stack |> heap |> indiv
    """
    }

let test50: SpiralModule =
    {
    name="test50"
    prerequisites=[]
    opens=[]
    description="Does the CSE work as expected?"
    code=
    """
inl !dyn a,b = 2,3
(a+b)*(a+b)
    """
    }

let test51: SpiralModule =
    {
    name="test51"
    prerequisites=[]
    opens=[]
    description="Does the string format work as expected?"
    code=
    """
inl l = 2,2.3,"qwe"
inl q = 1,2
String (format: "{0,-5}{1,-5}{2,-5}" args: l) |> dyn |> ignore
String (format: "{0,-5}{1,-5}{2,-5}" args: dyn l) |> ignore
String (format: (dyn "{0} = {1}") args: dyn q) |> ignore
    """
    }

let test52: SpiralModule =
    {
    name="test52"
    prerequisites=[]
    opens=[]
    description="Does the binary . operator apply if it is directly next to an expression?"
    code=
    """
inl f = function
    | .Hello as x -> .Bye

inl g = function
    | .Bye -> "Bye"

dyn (g f.Hello)
    """
    }

let test53: SpiralModule =
    {
    name="test53"
    prerequisites=[]
    opens=[]
    description="Does the unit closure get printed correctly."
    code=
    """
inl rec loop f i =
    inl f, i = Type (term_cast: f with: ()), dyn i
    inl body _ = if i < 10 then loop (inl _ -> f() + 1) (i + 1) else f()
    join (body() : 0)

loop (inl _ -> 0) 0
    """
    }

let test54: SpiralModule =
    {
    name="test54"
    prerequisites=[]
    opens=[]
    description="Does the prepass memoization work? Intended to be looked directly without the Core library."
    code=
    """
inl f x =
    match x with
    | q,w,e,r,t,z,x,c,v,b,m -> 0
    | (((),a,b) | ({q w e r t y z a b}, _, _)) -> 
        inl f a b = !Add(a, b)
        f a b
    | a,b -> !Add(a, b)
!Dynamize (f ({q=(); w=(); e=(); r=(); t=(); y=(); z=(); a=1; b=2},2,3))
    """
    }

let test55: SpiralModule =
    {
    name="test55"
    prerequisites=[]
    opens=[]
    description="Does the injection pattern work?"
    code=
    """
inl m = {
    a = 123
    b = 456
    }
inl f i {$i=x} = x
dyn (f .a m, f .b m)
    """
    }

let test56: SpiralModule =
    {
    name="test56"
    prerequisites=[]
    opens=[]
    description="Does the injection constructor work?"
    code=
    """
inl f i v m = {m with $i=v}
{}
|> f .a 123
|> f .b 456
|> inl {a b} -> a,b
|> dyn
    """
    }

let test57: SpiralModule =
    {
    name="test57"
    prerequisites=[]
    opens=[]
    description="Does the parser give an error on an indented expression after a statement? It should."
    code=
    """
1 |> ignore
    2
    """
    }

let test58: SpiralModule =
    {
    name="test58"
    prerequisites=[]
    opens=[]
    description="Does the newline after a semicolon work correctly?"
    code=
    """
dyn
    {a=1; b=2; 
     c=3}
    """
    }

let test59: SpiralModule =
    {
    name="test59"
    prerequisites=[]
    opens=[]
    description="Does returning from join points work on nested structures?"
    code=
    """
inl q = {q=1;w=2;e=3}
inl w = {a=q;b=q}
inl e = {z=w;x=w}
inl e = join e
inl e = join e
()
    """
    }

let test60: SpiralModule =
    {
    name="test60"
    prerequisites=[]
    opens=[]
    description="Does structural equality work correctly on union types?"
    code=
    """
inl Q = 0,0 \/ 0
inl f x = join Type (box: x to: Q)
inl a, b = f 1, f 1
a = b
    """
    }

let test61: SpiralModule =
    {
    name="test61"
    prerequisites=[]
    opens=[]
    description="Does the () record-with pattern work?"
    code=
    """
inl k = .q
inl m = { $k = { b = 2 }}

{(m).(k) with a = 1}
|> dyn
    """
    }

let test62: SpiralModule =
    {
    name="test62"
    prerequisites=[]
    opens=[]
    description="Do type_catch and type_raise work?"
    code=
    """
type_catch
    dyn "a" |> ignore
    dyn "b" |> ignore
    dyn "c" |> ignore
    Type (raise: stack 3)
|> indiv |> dyn
    """
    }

let test63: SpiralModule =
    {
    name="test63"
    prerequisites=[]
    opens=[]
    description="Do the keyword arguments get parsed correctly?"
    code=
    """
inl add left:right: = left + right
add left:1 right: 2
+ add 
    left: 3 
    right: 7
|> dyn
    """
    }

let test64: SpiralModule =
    {
    name="test64"
    prerequisites=[]
    opens=[]
    description="Do the object names get printed on type errors?"
    code=
    """
1 + [name="Tensor"]
    """
    }

let test65: SpiralModule =
    {
    name="test65"
    prerequisites=[]
    opens=[]
    description="Do the unit layout type get codegened correctly?"
    code=
    """
dyn (stack {elem_type=type 1})
    """
    }

let macro_dotnet1: SpiralModule =
    {
    name="macro_dotnet1"
    prerequisites=[macro]
    opens=[]
    description="Do the macros work?"
    code=
    """
Macro 
    type: ()
    global_method: "System.Console.WriteLine"
    args: "Hello, world!"
    """
    }

let macro_dotnet2: SpiralModule =
    {
    name="macro_dotnet2"
    prerequisites=[string_builder]
    opens=[]
    description="Does the StringBuilder work?"
    code=
    """
inl b = StringBuilder("Qwe", 128i32)
inl _ = b Append: 123
inl _ = b AppendLine: ()
inl _ = b Append: 123i16
inl _ = b AppendLine: "qwe"
inl _ = b.ToString
()
    """
    }

let macro_dotnet3: SpiralModule =
    {
    name="macro_dotnet3"
    prerequisites=[dictionary]
    opens=[]
    description="Does the Dictionary work?"
    code=
    """
inl b = Dictionary (key: "" value: 0) ()
b Add: "a", 5
inl _ = b Item: "a"
()
    """
    }

let test66: SpiralModule =
    {
    name="test66"
    prerequisites=[]
    opens=[]
    description="Does the metadata for recursive algebraic datatypes work?"
    code=
    """
inl List elem_type =
    [
    raw =
        Type 
            name: "List"
            meta: elem_type
            join: inl _ -> .nil \/ cons: elem_type, self .raw
    box: = Type box: to: self.raw
    nil = self box: .nil
    cons: x, x' = self box: (cons: x, x')
    cons = inl x x' -> self cons: x, x'
    ]

inl rec map f l = 
    inl elem_type = type (Type meta: l) |> dyn |> f
    inl List = List elem_type
    join
        match l with
        | #(cons: x, xs) -> List cons: f x, map f xs
        | #(.nil) -> List.nil
        : List.raw

inl List = List 0.0
List.nil |> List.cons 3.0 |> List.cons 2.0 |> List.cons 1.0 |> dyn |> map (inl x -> Type type: 0i32 convert: x)
        """
    }

let test67: SpiralModule =
    {
    name="test67"
    prerequisites=[]
    opens=[]
    description="Does the String `concat:args:` work?"
    code=
    """
String concat: ", " args: "1", "2", "3" 
|> dyn |> ignore
String concat: ", " args: "1", "2", dyn "3"
    """
    }

let array1: SpiralModule =
    {
    name="array1"
    prerequisites=[array]
    opens=[]
    description="Does the Array work?"
    code=
    """
inl x = Array type: 1 size: 3
x set: 0 to: 0
x set: 1 to: 1
x set: 2 to: 2
dyn (x 0, x 1, x 2)
    """
    }

let array2: SpiralModule =
    {
    name="array2"
    prerequisites=[array]
    opens=[]
    description="Does the Array work?"
    code=
    """
inl a = ref 0
a set: 5
a.get |> ignore

inl a = ref () // Is not supposed to be printed due to being ().
a set: ()
a.get

inl a = ref <| Type term_cast: (inl a, b -> a + b) with: 0,0
a set: 
    Type term_cast: (inl a, b -> a * b) with: 0,0
a.get |> ignore

inl a = Array type: 0 size: 10
a set: 3 to: 2
a 3 |> ignore

inl a = Array type: id size: 3 // Is supposed to be unit and not printed.
a set: 1 to: id
a 1 |> ignore
    """
    }

let array3: SpiralModule =
    {
    name="array3"
    prerequisites=[array]
    opens=[]
    description="Does the Array init work?"
    code=
    """
Array.init 6 (inl x -> x+1)
    """
    }

let array4: SpiralModule =
    {
    name="array4"
    prerequisites=[array]
    opens=[]
    description="Do the Array foldl and foldr work?"
    code=
    """
inl ar = Array.init 6 (inl x -> x+1)
Array.foldl (+) (dyn 0) ar, Array.foldr (*) ar (dyn 1)
    """
    }

let array5: SpiralModule =
    {
    name="array5"
    prerequisites=[array]
    opens=[]
    description="Do the Array map and filter work?"
    code=
    """
inl ar = Array.init 16 id
Array.map ((*) 2) ar
|> Array.filter ((<) 15)
    """
    }

let array6: SpiralModule =
    {
    name="array6"
    prerequisites=[array]
    opens=[]
    description="Does the Array iter work?"
    code=
    """
inl ar = Array.init 16 id
Array.iter (inl x ->
    Macro
        type: ()
        global_method: "System.Console.WriteLine"
        args: x
    ) ar
    """
    }

let array7: SpiralModule =
    {
    name="array7"
    prerequisites=[array]
    opens=[]
    description="Does the Array concat work?"
    code=
    """
Array.init 4 (inl _ -> Array.init 8 id)
|> Array.concat
    """
    }

let array8: SpiralModule =
    {
    name="array8"
    prerequisites=[array]
    opens=[]
    description="Does the Array append work?"
    code=
    """
inl ar = inl _ -> Array.init 4 id
Array.append (ar (), ar (), ar())
    """
    }

let tuple1: SpiralModule =
    {
    name="tuple1"
    prerequisites=[tuple]
    opens=[]
    description="Does tuple map work? This also tests rev and foldl."
    code=
    """
Tuple.map (inl x -> x * 2) (1,2,3) |> dyn
    """
    }

let tuple3: SpiralModule =
    {
    name="tuple3"
    prerequisites=[tuple]
    opens=[]
    description="Do the tuple foldl_map and foldr_map work?"
    code=
    """
inl l = 2,3,4
{
a = Tuple.map_foldl (inl s x -> x*x, s + x*x) 0 l
b = Tuple.map_foldr (inl x s -> x*x, s + x*x) l 0
}
|> dyn
    """
    }

let tuple4: SpiralModule =
    {
    name="tuple4"
    prerequisites=[tuple]
    opens=[]
    description="Do the tuple scan functions work?"
    code=
    """
inl x = 1,2,3,4
(Tuple.scanl (+) 0 x, Tuple.scanr (+) x 0)
|> dyn
    """
    }

let tuple5: SpiralModule =
    {
    name="tuple5"
    prerequisites=[tuple]
    opens=[]
    description="Does the map2 work?"
    code=
    """
inl a = 1,2,3
inl b = 4,5,6
Tuple.map2 (inl a b -> a + b) a b |> dyn
    """
    }

let tuple6: SpiralModule =
    {
    name="tuple6"
    prerequisites=[tuple]
    opens=[]
    description="Does the foldl2 work?"
    code=
    """
inl a = 1,2,3
inl b = 4,5,6
Tuple.foldl2 (inl s a b -> s + a + b) 0 a b |> dyn
    """
    }

let tuple7: SpiralModule =
    {
    name="tuple7"
    prerequisites=[tuple]
    opens=[]
    description="Does the append work?"
    code=
    """
inl a = 1,2,3
inl b = 4,5,6
Tuple.append a b |> dyn
    """
    }

let test68: SpiralModule =
    {
    name="test68"
    prerequisites=[]
    opens=[]
    description="Does the monadic bind `inm` work?"
    code=
    """
inl add x y s = x + y |> inl x -> x, x+s
inl (>>=) a b s =
    inl a, s = a s
    inl b, s = b a s
    b,s
inl on_succ x s = x,s
inl f =
    inm x = add 1 2
    inm y = add 3 4
    on_succ 0
f 0 |> dyn
    """
    }

let test69: SpiralModule =
    {
    name="test69"
    prerequisites=[]
    opens=[]
    description="Does the `inb` statement work?"
    code=
    """
inl f g ret = 
    dyn 0 |> ignore
    ret g
    dyn 2

inb x = f 1
dyn x |> ignore
    """
    }

let test70: SpiralModule =
    {
    name="test70"
    prerequisites=[]
    opens=[]
    description="Does setting the heap mutable types work?"
    code=
    """
inl m = heapm {a=type ""; b=1; c=heap {a=dyn 1; b=type ""}}
Record set: m field: .c to: heap {a=dyn 2; b=type ""}
    """
    }

let loop1: SpiralModule =
    {
    name="loop1"
    prerequisites=[loop; console]
    opens=[]
    description="Does the Loop module work?"
    code=
    """
//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

Console 
    writeline:
        Loop.for (from_down: dyn 999 to: dyn 3 by:dyn -1)
            (state:dyn 0 body: inl state: i: ->
                if i % 3 = 0 || i % 5 = 0 then state+i
                else state
                )
    """
    }

let loop2: SpiralModule =
    {
    name="loop2"
    prerequisites=[loop; console]
    opens=[]
    description="Do state changing nested loops work?"
    code=
    """
inl compare_pos (a_row,a_col) (b_row,b_col) = a_row = b_row && a_col = b_col
inl ret = {
    some = inl state -> Console.printfn "Success." ()
    none = inl state -> failwith type:() msg: "Failure."
    }
inl princess_pos = dyn (0,0)
inl mario_pos = dyn (1,1)
inl n = 5
Loop.for' (from: dyn 0 near_to:n)
    (
    state:{} 
    body:inl next:row state: i:r ->
        Loop.for' (from:dyn 0 near_to:n)
            (
            state:
            body:inl next:col state: i:c ->
                Console.printfn "I am at ({0},{1})" (r, c)
                inl ret state = 
                    match state with
                    | {mario princess} -> ret .some state
                    | _ -> col state
                if compare_pos (r,c) mario_pos then ret {state with mario=mario_pos}
                elif compare_pos (r,c) princess_pos then ret {state with princess=princess_pos}
                else ret state
            finally: row
            )
    finally: ret.none
    )
    """
    }

let loop3: SpiralModule =
    {
    name="loop3"
    prerequisites=[console]
    opens=[]
    description="Do state changing nested loops work?"
    code=
    """
inl compare_pos (a_row,a_col) (b_row,b_col) = a_row = b_row && a_col = b_col
inl ret = {
    some = inl state -> Console.printfn "Success." ()
    none = inl state -> failwith type: () msg: "Failure."
    }
inl princess_pos = dyn (0,0)
inl mario_pos = dyn (1,1)
inl n = dyn 5
inl rec row {from=r near_to state} as d = join
    inl rec col {from=c near_to state} as d = join
        if c < near_to then
            Console.printfn "I am at ({0},{1})" (r, c)
            inl ret = function
                | {mario princess} as state -> ret .some state
                | state -> col {d with state from=c+1}
            if compare_pos (r,c) mario_pos then 
                Console.printfn "I've found Mario." ()
                ret {state with mario=mario_pos}
            elif compare_pos (r,c) princess_pos then 
                Console.printfn "I've found Princess." ()
                ret {state with princess=princess_pos}
            else ret state
        else 
            row {d with from=r+1}
        : ()
    if r < near_to then col {from=dyn 0; near_to state}
    else ret .none () 
    : ()
row {from=dyn 0; near_to=dyn n; state={}}
    """
    }

let loop4: SpiralModule =
    {
    name="loop4"
    prerequisites=[console]
    opens=[]
    description="Do state changing nested loops work?"
    code=
    """
inl rec for {from=(!dyn from) near_to state body finally} = join
    if from < near_to then 
        inl next state = for {from=from+1; near_to state body finally} 
        body {next state i=from}
    else finally state
    : finally state

inl compare_pos (a_row,a_col) (b_row,b_col) = a_row = b_row && a_col = b_col
inl ret = {
    some = inl state -> Console.printfn "Success." ()
    none = inl state -> failwith type: () msg: "Failure."
    }
inl princess_pos = dyn (0,0)
inl mario_pos = dyn (1,1)
inl n = dyn 5
for {from=0; near_to=n; state={};
    body = inl {next=row i=r state} ->
        for {from=0; near_to=n; state;
            body = inl {next=col i=c state} ->
                Console.printfn "I am at ({0},{1})" (r, c)
                inl ret = function
                    | {mario princess} as state -> ret .some state
                    | state -> col state
                if compare_pos (r,c) mario_pos then 
                    Console.printfn "I've found Mario." ()
                    ret {state with mario=mario_pos}
                elif compare_pos (r,c) princess_pos then 
                    Console.printfn "I've found Princess." ()
                    ret {state with princess=princess_pos}
                else ret state
            finally = row
            }
    finally = ret.none
    }
    """
    }

let list1: SpiralModule =
    {
    name="list1"
    prerequisites=[list]
    opens=[]
    description="Do the list constructors work?"
    code=
    """
inl (::) = List.cons
1 :: 2 :: 3 :: List.singleton 4
|> dyn
    """
    }

let list2: SpiralModule =
    {
    name="list2"
    prerequisites=[list]
    opens=[]
    description="Do the list module folds work?"
    code=
    """
inl (::) = List.cons
inl l = 1.0 :: 2.0 :: 3.0 :: List.singleton 4.0
inl f l = List.foldl (+) (dyn 0.0) l, List.foldr (+) l (dyn 0.0)
(f l, f (dyn l))
|> dyn
    """
    }

let list3: SpiralModule =
    {
    name="list3"
    prerequisites=[list]
    opens=[]
    description="Does the list module concat (and by extension append) work?"
    code=
    """
inl (::) = List.cons
inl a = 1.0 :: 2.0 :: 3.0 :: List.singleton 4.0 |> dyn
inl b = 5.0 :: 6.0 :: 7.0 :: List.singleton 8.0 |> dyn
dyn (a :: List.singleton b)
|> List.concat
    """
    }

let list4: SpiralModule =
    {
    name="list4"
    prerequisites=[list]
    opens=[]
    description="Does the list module map work?"
    code=
    """
inl (::) = List.cons

inl a = 1.0 :: 2.0 :: 3.0 :: List.singleton 4.0
inl f = List.map ((*) 2.0)
f a, f (dyn a)
    """
    }

let list5: SpiralModule =
    {
    name="list5"
    prerequisites=[list]
    opens=[]
    description="Is it possible to make a list of lists?"
    code=
    """
List.nil (List.nil 0) |> dyn
    """
    }

let list6: SpiralModule =
    {
    name="list6"
    prerequisites=[list]
    opens=[]
    description="Does the list module init work?"
    code=
    """
List.init 10 (inl x -> 2.2)
    """
    }

let list7: SpiralModule =
    {
    name="list7"
    prerequisites=[list]
    opens=[]
    description="Does structural polymorphic equality work on recursive datatypes?"
    code=
    """
inl a = List.singleton 1 |> dyn
inl b = List.singleton 1 |> dyn
a = b
    """
    }

let euler1: SpiralModule =
    {
    name="euler1"
    prerequisites=[loop; console]
    opens=[]
    description="Even Fibonacci Numbers."
    code=
    """
Loop 
    while: inl {b} -> if b <= 4*1000*1000 then true else false
    state: {sum=dyn 0; a=dyn 1; b=dyn 2}
    body: inl {sum a b} -> {sum=if b % 2 = 0 then sum+b else sum; a=b; b=a+b}
|> inl {sum} -> Console writeline: sum
    """
    }

let euler2: SpiralModule =
    {
    name="euler2"
    prerequisites=[array; loop; console; option]
    opens=[]
    description="Largest prime factor"
    code=
    """
// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?

inl target = 600851475143
inl sieve_length =
    Type 
        type: 0
        convert:
            Type type: 0.0 convert: target
            |> sqrt

inl sieve = Array.init (sieve_length+1) (inl _ -> true)
Loop.for from:2 to:sieve_length
    body: inl i: ->
        if sieve i = true then
            Loop.for from:i+i to:sieve_length by:i
                body: inl i: -> 
                    sieve set: i to: false

Loop.for' from_down:sieve_length to:2
    state: Option.none 0
    body: inl next: state: i: ->
        if sieve i = true && target % i = 0 then Option.some i
        else next state
|>  function
    | #(some: result) -> Console writeline: result // 6857
    | #(.none) -> failwith type:() msg:"No prime factor found!"
    """
    }

let euler3: SpiralModule =
    {
    name="euler3"
    prerequisites=[array; loop; console]
    opens=[]
    description="Largest palindrome product"
    code=
    """
//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 � 99.
//Find the largest palindrome made from the product of two 3-digit numbers.

inl reverse_number x =
    Loop 
        while: inl {x} -> x > 0 
        state: {x x' = dyn 0}
        body:inl {x x'} -> {x=x/10; x'= x'*10+x%10}
    |> inl {x'} -> x'

inl is_palindrome x = x = reverse_number x

Loop.for from:dyn 100 to:dyn 999 
    state:dyn 0
    body:inl state: i: ->
        Loop.for from:i to:dyn 999
            state:
            body:inl state: i:j ->
                inl x = i*j
                if is_palindrome x then max x state
                else state
|> Console.writeline
    """
    }

let euler4: SpiralModule =
    {
    name="euler4"
    prerequisites=[tuple; loop; console]
    opens=[]
    description="Smallest multiple"
    code=
    """
//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

inl primes = 2,3,5,11,13,17,19
inl non_primes = Tuple (min: 2 max: 20) |> Tuple.filter (Tuple.contains primes >> not)
inl step = Tuple.foldl (*) 1 primes
inl to = Macro type: 0i64 text: "System.Int64.MaxValue"
Loop.for' from:step to: by:step
    state: -1 
    body: inl next: state: i: ->
        if Tuple.forall (inl x -> i % x = 0) non_primes then i
        else next state
|> Console.writeline
    """
    }

let cfr1: SpiralModule =
    {
    name="cfr1"
    prerequisites=[tuple; loop; console; random; time_it; resize_array]
    opens=[]
    description="Blotto Vs Fett CFR example"
    code=
    """
// From the 'An Introduction to Counterfactual Regret Minimization' paper by TW Neller.
inl rng = Random()

inl utility (action_one, action_two) =
    Array.map2 (inl a b -> if a > b then 1 elif a < b then -1 else 0) action_one action_two
    |> Array.sum |> inl convert -> Type type: 0.0 convert:

inl init d =
    inl temp = Array.replicate d.num_fields 0
    inl ar = ResizeArray type: temp
    inl rec loop field soldiers_left = join
        if field < d.num_fields then
            Loop.for from: 0 to: soldiers_left
                body: inl i:soldier ->
                    temp at: field put: soldier
                    loop (field+1) (soldiers_left-soldier)
        elif soldiers_left = 0 then ar Add: Array.copy temp
        : ()
    
    loop 0 d.num_soldiers
    ar.ToArray

inl actions = init {num_fields=3; num_soldiers=5}
   
inl normalize array = join
    inl temp = Array.map (max (dyn 0.0)) array
    inl normalizingSum = Array.sum temp

    if normalizingSum > 0.0 then Array.map (inl x -> x / normalizingSum) temp
    else Array.replicate temp.length (1.0 / Type type: 0.0 convert: actions.length)

inl add_sum sum x = Array.iteri (inl i x -> sum at: i add: x) x
inl add_regret sum f = Array.iteri (inl i x -> sum at: i add: f x) actions

inl sample dist =
    inl r = rng.NextDouble
    inl rec loop a cumulativeProbability = join
        if a < actions.length then 
            inl cumulativeProbability = cumulativeProbability + dist at: a
            if r <= cumulativeProbability then actions at: a
            else loop (a+1) cumulativeProbability
        else 
            failwith type: actions.elem_type msg: "impossible"
        : actions.elem_type
    loop (dyn 0) (dyn 0.0)

inl sample_and_update player = 
    inl action_distribution = normalize player.regret_sum
    add_sum player.strategy_sum action_distribution
    sample action_distribution

inl update_regret one (action_one, action_two) =
    inl self_utility = utility(action_one, action_two)
    add_regret one.regret_sum (inl a -> utility (a, action_two) - self_utility)

inl vs (one, two as players) =
    inl action_one = sample_and_update one
    inl action_two = sample_and_update two
    update_regret one (action_one, action_two)
    update_regret two (action_two, action_one)

inl train (one, two as players) to = Loop.for (from:1 to:) (body: inl i: -> vs players)

inl player = 
    { 
    regret_sum = Array.replicate actions.length 0.0
    strategy_sum = Array.replicate actions.length 0.0
    }

TimeIt
    message: "loop"
    body: inl _ -> train (player,player) 10000000

inl print player =
    Array.iter2 (inl a b -> Console.writeline b) actions (normalize player.strategy_sum)
    Console.writeline "---"

print player
    """
    }


let tests =
    [|
    test1; test2; test3; test4; test5; test6; test7; test8; test9
    test10; test11; test12; test13; test14; test15; test16; test17; test18; test19
    test20; test21; test22; test23; test24; test25; test26; test27; test28; test29
    test30; test31; test32; test33; test34; test35; test36; test37; test38; test39
    test40; test41; test42; test43; test44; test45; test46; test47; test48; test49
    test50; test51; test52; test53; test54; test55; test56; test57; test58; test59
    test60; test61; test62; test63; test64; test65; test66; test67; test68; test69
    test70

    macro_dotnet1; macro_dotnet2; macro_dotnet3

    array1; array2; array3; array4; array5; array6; array7; array8
    tuple1;         tuple3; tuple4; tuple5; tuple6; tuple7
    loop1; loop2; loop3; loop4
    list1; list2; list3; list4; list5; list6; list7 
    euler1; euler2; euler3; euler4
    |]

//rewrite_test_cache tests cfg None //(Some(63,64))
output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) cfr1
|> printfn "%s"
|> ignore

