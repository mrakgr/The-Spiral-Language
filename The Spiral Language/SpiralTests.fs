module Spiral.Tests
open Types
open Lib
open Main

let test1 = 
    "test1",[],"Does it run?",
    """
inl a = 5
inl b = 10
a + b
    """

let test2 = 
    "test2",[],"Does it run methods?",
    """
met a () = 5
met b () = 10
a () + b ()
    """

let test3 = // 
    "test3",[],"Does this method case work?",
    """
inl a = dyn 5
inl b = dyn 10
a + b
    """

let test4 = // 
    "test4",[],"Does the and pattern work correctly?",
    """
inl f (a, b) (c, d) = dyn (a+c,b+d)
inl q & (a, b) = dyn (1,2)
inl w & (c, d) = dyn (3,4)
f q w
    """

let test5 = // 
    "test5",[],"Does basic pattern matching work?",
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

let test6 = // 
    "test6",[],"Does returning type level methods from methods work?",
    """
met min n =
    met tes a =
        met b -> 
            met c ->
                met d -> a,b,c
    tes 1 2 (2.2,3,4.5)
min 10
    """
let test7 = // 
    "test7",[],"Do active patterns work?",
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
a, b, c
    """

let test8 =
    "test8",[],"Does the basic union type work?",
    """
inl option_int = .Some, 1 \/ .None

met x = box option_int .None
match x with
| .Some, x -> x
| .None -> 0
    """

let test9 = // 
    "test9",[],"Does the partial evaluator optimize unused match cases?",
    """
inl ab = .A \/ .B
inl ab = box ab
met x = (ab .A, ab .A, ab .A)
match x with
| .A, _, _ -> 1
| _, .A, _ -> 2
| _, _, .A -> 3
| _ -> 4
    """

let test10 = 
    "test10",[],"Do the join points get filtered?",
    """
inl ab = box (.A \/ .B)
met x = (ab .A, ab .A, ab .A, ab .A)
match x with
| .A, .A, _, _ -> join 1
| _, _, .A, .A -> join 2
| .A, .B, .A, .B -> join 3
| _ -> join 4
    """

let test11 = // 
    "test11",[],"Do the nested patterns work on dynamic data?",
    """
inl a = type (1,2)
inl b = type (1,a,a)
inl a,b = box a, box b
met x = b (1, a (2,3), a (4,5))
match x with
| _, (x, _), (_, y) -> x + y
| _, _, _ -> 0
| _ :: () -> 0
    """

let test12 = // 
    "test12",[],"Does recursive pattern matching work on static data?",
    """
inl rec p = function
    | .Some, x -> p x
    | .None -> 0
p (.Some, .None)
    """

let test13 = 
    "test13",[],"A more complex interpreter example on static data.",
    """
inl rec expr x = join_type
    .V, x
    \/ .Add, expr x, expr x
    \/ .Mult, expr x, expr x
inl int_expr = box (expr int64)
inl v x = int_expr (.V, x)
inl add a b = int_expr (.Add, a, b)
inl mult a b = int_expr (.Mult, a, b)
inl a = add (v 1) (v 2)
inl b = add (v 3) (v 4)
inl c = mult a b
inl rec interpreter_static x = 
    match x with
    | .V, x -> x
    | .Add, a, b -> interpreter_static a + interpreter_static b
    | .Mult, a, b -> interpreter_static a * interpreter_static b
interpreter_static c
    """

let test14 =
    "test14",[],"Does recursive pattern matching work on partially static data?",
    """
inl rec expr x = join_type
    .V, x
    \/ .Add, expr x, expr x
    \/ .Mult, expr x, expr x
inl int_expr = box (expr int64)
inl v x = int_expr (.V, x)
inl add a b = int_expr (.Add, a, b)
inl mult a b = int_expr (.Mult, a, b)
inl a = add (v 1) (v 2) |> dyn
inl b = add (v 3) (v 4) |> dyn
inl c = mult a b |> dyn

met rec inter x = 
    match x with
    | .V, x -> x
    | .Add, a, b -> inter a + inter b
    | .Mult, a, b -> inter a * inter b
    : int64

inter c
    """

let test15 =
    "test15",[extern_],"Does basic .NET interop work?",
    """
open Extern
inl builder_type = fs [text: "System.Text.StringBuilder"]
inl b = FS.Constructor builder_type ("Qwe", 128i32)
inl a x =
    FS.Method b .Append x builder_type |> ignore
    FS.Method b .AppendLine () builder_type |> ignore
a 123
a 123i16
a "qwe"
inl str = FS.Method b .ToString () string

inl console = fs [text: "System.Console"]
FS.StaticMethod console .Write str ()

inl key = 1, 1
inl value = {a=1;b=2;c=3}
inl dictionary_type = fs [text: "System.Collections.Generic.Dictionary"; types: type (key,value)]
inl dict = FS.Constructor dictionary_type 128i32
FS.Method dict .Add (key,value) ()
FS.Method dict .Item (key :: ()) value |> dyn |> ignore
0
    """

let hacker_rank_1 =
    "hacker_rank_1",[extern_],"The very first warmup exercise : https://www.hackerrank.com/challenges/solve-me-first",
    """
open Extern
inl console = fs [text: "System.Console"]
inl int32_type = fs [text: "System.Int32"]
inl parse_int32 str = FS.StaticMethod int32_type .Parse str int32
inl read_line () = FS.StaticMethod console .ReadLine() string
inl write x = FS.StaticMethod console .Write x ()
inl read_int () = read_line() |> parse_int32
inl a, b = read_int(), read_int()
write (a + b)
    """

let test16 = // 
    "test16",[],"Do var union types work?",
    """
inl t = int64 \/ float64
if dyn true then box t 0
else box t 0.0
    """

let test17 = // 
    "test17",[],"Do modules work?",
    """
inl m =
    inl x = 2
    inl y = 3.4
    inl z = "123"
    {x y z}
m.x, m.y, m.z
    """

let test18 = // 
    "test18",[],"Do arrays and references work?",
    """
inl a = ref 0
a := 5
a() |> ignore

inl a = ref () // Is not supposed to be printed due to being ().
a := ()
a()

inl a = ref <| term_cast (inl a, b -> a + b) (int64,int64)
a := term_cast (inl a, b -> a * b) (int64,int64)
a() |> ignore

inl a = array_create int64 10
a 3 <- 2
a 3 |> ignore

inl a = array_create id 3 // Is supposed to be unit and not printed.
a 1 <- id
a 1 |> ignore
    """

let test19 =
    "test19",[],"Does term casting for functions work?",
    """
inl add a b (c, (d, e), f) = a + b + c + d + e + f
inl f = term_cast (add 8 (dyn 7)) (int64,(int64,int64),int64)
f (1,(2,5),3)
    """

let test20 = // 
    "test20",[],"Does pattern matching on union non-tuple types work? Do type annotation patterns work?",
    """
inl t = int64 \/ float64
inl x = box t 3.5
match x with
| q : int64 -> x * x
| q : float64 -> x + x
    """

let test21 = // 
    "test21",[],"Does defining user operators work?",
    """
inl (.+) a b = a + b
inl x = 2 * 22 .+ 33

inl f op a b = op a b
f (*) 2 x
    """

let test22 = 
    "test22",[],"Do unary operators work?",
    """
inl t1 x = dyn <| -x
inl t3 x = .(x)
t1 2.2, t3 "asd"
    """

let test23 = // 
    "test23",[],"Do when and as patterns work?",
    """
inl f = function
    | a,b,c as q when a < 10 -> q
    | _ -> 0,0,0
f (1,2,3)
    """

let test24 = // 
    "test24",[],"Do literal pattern matchers work? Does partial evaluation of equality work?",
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
    | .5.5 -> ".5.5", x
    | .23u32 -> ".23u32",x
    | _ -> "unknown", x

f 0, f 1, f false, f true, f "asd", f 1i8,
f 5.5, f 5f64, f .5.5, f .23u32
    """

let test25 = // 
    "test25",[],"Does the tuple cons pattern work?",
    """
inl f = function | x1 :: x2 :: x3 :: xs -> 3 | x1 :: x2 :: xs -> 2 | x1 :: xs -> 1 | () -> 0

f (), f (1 :: ()), f (1,2)
    """

let test26 = // 
    "test26",[tuple],"Does tuple map work? This also tests rev and foldl.",
    """
Tuple.map (inl x -> x * 2) (1,2,3)
    """

let test27 = // 
    "test27",[tuple],"Do tuple zip and unzip work?",
    """
inl j = 2,3.3
inl k = 4.4,55
inl l = 66,77
inl m = 88,99
inl n = 123,456
Tuple.zip ((j,k),(l,m),n) |> Tuple.unzip
    """

let test28 = // 
    "test28",[extern_],"Does string indexing work?",
    """
open Extern
inl console_type = fs [text: "System.Console"]
inl a = "qwe"
inl b = FS.StaticMethod console_type .ReadLine() string
a(0),b(0)
    """

let test29 =
    "test29",[],"Does pattern matching work redux?",
    """
inl t = int64, int64 \/ int64

inl x = (1,1) |> box t |> dyn
match x with
| a,b -> 0
| c -> c
    """

let test30 = // 
    "test30",[],"Do recursive algebraic datatypes work?",
    """
inl rec List x = join_type .ListCons, (x, List x) \/ .ListNil

inl t = box (List int64)
inl nil = t .ListNil
inl cons x xs = t (.ListCons, (x, xs))

met rec sum (!dyn s) l = 
    match l with
    | .ListCons, (x, xs) -> sum (s + x) xs
    | .ListNil -> s
    : int64

nil |> cons 3 |> cons 2 |> cons 1 |> dyn |> sum 0
        """

let test31 = 
    "test31",[],"Does passing types into types work?",
    """
inl a = .A, (int64, int64) \/ .B, string
inl b = a \/ .Hello
(.A, (2,3)) |> box a |> dyn |> box b
    """

let test32 =
    "test32",[extern_],"Do the .NET methods work inside methods?",
    """
open Extern
inl convert_type = fs [text: "System.Convert"]
inl to_int64 x = FS.StaticMethod convert_type .ToInt64 x int64
met f = to_int64 (dyn 'a')
f
    """

let test33 =
    "test33",[],"Do the module map and fold functions work?",
    """
inl m = {a=1;b=2;c=3}
inl m' = module_map (const ((*) 2)) m
m', module_foldl (const (+)) 0 m'
    """

let test34 =
    "test34",[],"Does a simple stackified function work?",
    """
inl a = dyn 1
inl b = dyn 2
inl add c d = a + b + c + d
met f g c d = g c d
f (stack add) (dyn 3) (dyn 4)
    """

let test35 = // 
    "test35",[],"Does case on union types with recursive types work properly?",
    """
inl rec List x = join_type
    .Nil 
    \/ .Cons, (int64, List x)

inl Res =
    int64
    \/ int64, int64
    \/ List int64

match box Res 1 |> dyn with
| x : int64 -> 1
| (a, b) as x -> 2
| _ -> 3
    """

let test36 =
    "test36",[],"Does a simple heapified function work?",
    """
inl a = dyn 1
inl b = dyn 2
inl add c d = a + b + c + d
met f g c d = g c d
f (heap add) (dyn 3) (dyn 4)
    """

let test37 =
    "test37",[],"Does a simple heapified module work?",
    """
inl m = heap { a=dyn 1; b=dyn 2 }
inl add c d = 
    inl {a b} = m
    a + b + c + d
met f g c d = g c d
f (heap add) (dyn 3) (dyn 4)
    """

let test38 =
    "test38",[],"Is type constructor of an int64 an int64?",
    """
box int64 (dyn 1)
    """

let test39 =
    "test39",[],"Does the mutable layout type get unpacked multiple times?",
    """
inl q = type (heapm <| dyn {a=1;b=2;c=3}) \/ (heapm <| dyn {a=1;b=2}) \/ (heap <| dyn (1,2,3))
match box q (heapm <| dyn {a=1;b=2;c=3}) |> dyn with
| {x with a} ->
    inl {b} = x
    match x with
    | {c} -> a+b+c
    | _ -> a+b
| a,b,c -> a*b*c
    """

let test40 =
    "test40",[],"Does this compile into just one method? Are the arguments reversed in the method call?",
    """
met rec f a b =
    if dyn true then f b a
    else a + b
    : 0
f (dyn 1) (dyn 2)
    """

let test41 =
    "test41",[],"Does result in a `type ()`?",
    """
inl ty = .Up \/ .Down \/ heap (dyn {q=1;block=(1,(),3)})
inl x = dyn (box ty .Up)
inl r =
    match x with
    | .Up -> {q=1;block=(1,(),3)}
    | .Down -> {q=2;block=(2,(),4)}
    | _ -> {q=1;block=(1,(),3)}
box ty (heap r)
    """

let test42 =
    "test42",[],"Do partial active patterns work?",
    """
inl f x on_fail on_succ =
    match x with
    | x : int64 -> on_succ (x,"is_int64")
    | x : int32 -> on_succ (x,"is_int32",x*x)
    | x -> on_fail()

inl m m1 = function
    | @m1 (q,w,e) -> q,w,e
    | @m1 (q,w) -> q,w
    | @m1 q -> q
    | x -> error_type "The call to m1 failed."

m f 2
    """

let test43 =
    "test43",[array],"Do the Array constructors work?",
    """
open Array

empty int64, singleton 2.2
    """

let test44 =
    "test44",[],"Does the xor pattern work for empty inputs?",
    """
inl f = function 
    | {a ^ b} -> a
    | _ -> true
f {a=1}, f {}
    """

let test45 =
    "test45",[],"Does the module_add and module_remove work?",
    """
module_add .add (inl a b -> a + b) {}
|> module_add .sub (inl a b -> a - b)
|> module_add .q 5
|> module_add .w 10
|> module_remove .q
    """

let test46 =
    "test46",[],"Does the module pattern work?",
    """
inl f {a; b; c} = a + b + c
inl x =
    {
    a=1
    b=2
    c=3
    }

f {x with a = 4}
    """

let test47 =
    "test47",[],"Does the nested module pattern work?",
    """
inl f {name {p with x y}} = name,(x,y)
inl x = { name = "Coord" }

f {x with 
    p = { x = 1
          y = 2 }}
    """

let test48 =
    "test48",[],"Does the nested module pattern with rebinding work?",
    """
inl f {name {p with y=y' x=x'}} = name,(x',y')
inl x = { name = "Coord" }
f {x with 
    p = { x = 1
          y = 2 }}
    """

let test49 =
    "test49",[],"Does the lens pattern work? Does self work? Does the semicolon get parsed properly?",
    """
inl x = { a = { b = { c = 3 } } }

inl f {x.a.b with c q} = c,q
f {x.a.b with q = 4; c = self + 3; d = {q = 12; w = 23}}
    """

let test50 =
    "test50",[array],"Do the Array init and fold work?",
    """
open Array

inl ar = init 6 (inl x -> x+1)
foldl (+) (dyn 0) ar, foldr (*) ar (dyn 1)
    """

let test51 =
    "test51",[array],"Do the Array map and filter work?",
    """
open Array

inl ar = init 16 id
map ((*) 2) ar
|> filter ((<) 15)
    """

let test52 =
    "test52",[array],"Does the Array concat work?",
    """
open Array

inl ar = init 4 (inl _ -> init 8 id)
concat ar
    """

let test53 =
    "test53",[array],"Does the Array append work?",
    """
open Array

inl ar = inl _ -> init 4 id
append (ar (), ar (), ar())
    """

let test54 =
    "test54",[tuple],"Does the monadic bind `inm` work?",
    """
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

let test55 =
    "test55",[],"Does the type literal rebind pattern work?",
    """
inl f = .QWE,.66,.2.3
match f with
| .(a), .(b), .(c) -> a,b,c
    """

let test56 =
    "test56",[],"Does term casting with an unit return get printed properly?",
    """
inl add a, b = ()
inl k = term_cast add (int64,int64)
k (1, 2)
    """

let test57 =
    "test57",[],"Does the new module creation syntax work?",
    """
inl a = 1
inl b = 2
inl d = 4
{a b c = 3; d; e = 5}
    """

let test58 =
    "test58",[array],"Does the fold function get duplicated?",
    """
inl ar = array_create (int64,int64) 128
Array.foldl (inl a,b c,d -> a+c,b+d) (dyn (1,2)) ar
|> inl a,b -> a*b
    """

let test59 =
    "test59",[],"Does the new named tuple syntax work?",
    """
inl f [a:q b:w c:e] = q,w,e
f [ a : 1; b : 2; c : 3 ]
    """

let test60' =
    "test60'",[],"Is the trace being correctly propagated for TyTs?",
    """
inl a = dyn 1
inl b = dyn 2
inl c = dyn 3
4 + int64
    """

let test61 =
    "test61",[],"Does dyn act like id on already dyned variables? It should not.",
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

let test62 =
    "test62",[],"Do && and || work correctly?",
    """
inl a,b,c,d,e = dyn (true, false, true, false, true)
met f x = x
f a && f b || f c && f d || f e
    """

let test63 =
    "test63",[list],"Do the list constructors work?",
    """
open List
cons 1 (cons 2 (singleton 3))
    """

let test64 =
    "test64",[tuple],"Do the tuple foldl_map and foldr_map work?",
    """
inl l = 2,3,4
{
a = Tuple.foldl_map (inl s x -> x*x, s + x*x) 0 l
b = Tuple.foldr_map (inl x s -> x*x, s + x*x) l 0
}
    """

let test65 =
    "test65",[tuple;list],"Do the list module folds work?",
    """
open List

foldl (+) (dyn 0.0) (dyn (empty float64)),
foldr (+) (dyn (empty float64)) (dyn 0.0f64)
    """

let test66 =
    "test66",[tuple;list],"Does the list module concat (and by extension append) work?",
    """
open List

inl a = cons 3 () |> cons 2 |> cons 1 |> dyn
inl b = cons 6 () |> cons 5 |> cons 4 |> dyn
inl c = dyn (cons a (singleton b))
concat c
    """

let test67 =
    "test67",[tuple;list],"Does the list module map work?",
    """
open List

inl a = cons 3 () |> cons 2 |> cons 1 |> dyn

map ((*) 2) a
    """

let test68 =
    "test68",[tuple;list],"Is it possible to make a list of lists?",
    """
open List

inl a = empty int64 |> dyn
empty a
    """

let test69 =
    "test69",[tuple;list],"Does the list module init work?",
    """
open List

init 10 (inl x -> 2.2)
    """

let test70 =
    "test70",[],"Does the argument get printed on a type error?",
    """
inl a: float64 = 5
()
    """

let test71' =
    "test71'",[],"Does the recent change to error printing work? This one should give an error.",
    """
55 + id
    """

let test72 =
    "test72",[],"Does any kind of literal work in the named tuple syntax?",
    """
inl f = function
    | [1 : x] -> x
    | [true: x] -> x
    | [add: a,b] -> a+b
    | [3.3] -> 6.6

f [1: 1], f [true: 2], f [add: 1,2], f [3.3]
    """

let test73 =
    "test73",[],"Do the or module patterns work?",
    """
inl x = {a=1; c=3}
inl f = function
    | {(a | b)=t} -> t
inl g = function
    | {(a=t) | (b=t)} -> t
f x, g x
    """

let test74 =
    "test74",[],"Do the xor module patterns work?",
    """
inl x = {b=2; c=3}
inl f = function
    | {(((a | a) ^ (b | b)))=t} -> t
inl g = function
    | {(a=t) ^ (b=t)} -> t
f x, g x
    """

let test75 =
    "test75",[],"Does the not module pattern work?",
    """
inl x = {b=2; c=3}
inl f = function
    | {!a b} -> b
f x
    """

let test76' =
    "test76'",[],"Do the xor module patterns work? This one is supposed to fail.",
    """
inl x = {b=2; c=3}
inl f = function
    | {b ^ c} -> c
f x
    """

let test77' =
    "test77'",[],"Do the xor module patterns work? This one is supposed to fail.",
    """
inl x = {b=2; c=3}
inl f = function
    | {(!a) ^ c} -> c
f x
    """

let test78 =
    "test78",[tuple],"Do the tuple scan functions work?",
    """
inl x = 1,2,3,4
Tuple.scanl (+) 0 x, Tuple.scanr (+) x 0
    """

let test79 =
    "test79",[host_tensor],"Does the Tensor init work? Do set and index for the new array module work?",
    """
inl tns = Tensor.init (10,10) (inl a b -> a*b)
inl x = tns 2 2 .get
tns 2 2 .set (x+100)
tns 2 2 .get
    """

let test80 =
    "test80",[queue;console],"Does the Queue module work?",
    """
open Console
open Queue
inl queue = create int64 1
inl rec dequeue' n =
    if n > 0 then dequeue queue |> writeline; dequeue' (n-1)
    else ()
Tuple.iter (enqueue queue) (Tuple.range (1,4))
dequeue' 2
Tuple.iter (enqueue queue) (Tuple.range (1,4))
Tuple.iter (enqueue queue) (Tuple.range (1,4))
dequeue' 2
dequeue' 4
dequeue' 4
    """

let test81 =
    "test81",[],"Does structural polymorphic equality work?",
    """
{a=1;b=dyn 2;c=dyn 3;d=.qwe} = {a=1;b=2;c=3;d=.qwe}
    """

let test82 =
    "test82",[list],"Does structural polymorphic equality work on recursive datatypes?",
    """
inl a = List.empty int64 |> dyn
inl b = List.empty int64 |> dyn
a = b
    """

let test83 =
    "test83",[],"Does this destructure trigger an error?",
    """
inl q = true && dyn true
()
    """

let test84 =
    "test84",[host_tensor],"Does the scalar tensor work?",
    """
open Tensor
inl ar = init () 5
ar .get
    """

let test85 =
    "test85",[host_tensor],"Does the split work?",
    """
open Tensor
inl ar = init (32*32) id |> split (const (16,64))
(ar 0 0, ar 0 1, ar 0 2, ar 1 0, ar 1 1, ar 1 2) |> Tuple.map (inl x -> x.get)
    """

let test86 =
    "test86",[host_tensor],"Is the type of host tensor for the TOA layout correct? Does it work on the singleton dimensions?",
    """
open Tensor
inl ar = init 10 id
ar 5 .get
    """

let test87 =
    "test87",[],"Does a pack stackified function work?",
    """
inl a = dyn 1
inl b = dyn 2
inl add c d = a + b + c + d
met f g c d = g c d
f (packed_stack add) (dyn 3) (dyn 4)
    """

let test88 =
    "test88",[extern_],"Does the => related stuff work?",
    """
open Extern
inl closure_type = (int64 => int64 => int64)
inl add a b = a + b
inl clo_add = closure_of add closure_type
match clo_add with
| (a: int64) => (b: (int64 => int64)) -> clo_add 1 2
    """

let test89 =
    "test89",[],"Does changing layout type work?",
    """
{a=1;b=2} |> dyn |> stack |> heap |> indiv
    """

let test90 =
    "test90",[host_tensor],"Does the tensor map work?",
    """
open Tensor
init (2,2) (inl a b -> a*2+b)
|> map ((*) 2)
    """

let test91 =
    "test91",[array;host_tensor],"Does assert_size work? Does converting from array to tensor work?",
    """
open Tensor
inl tns =
    Array.init 6 id
    |> array_to_tensor
    |> split (dyn (2,3) |> const)
    |> assert_size (2,3)
    
tns 1 0 .get |> ignore
    """

let test92 =
    "test92",[],"Does the CSE work as expected?",
    """
inl !dyn a,b = 2,3
(a+b)*(a+b)
    """

let test93 =
    "test93",[],"Does the string format work as expected?",
    """
inl l = 2,2.3,"qwe"
inl q = 1,2
string_format "{0,-5}{1,-5}{2,-5}" l |> dyn |> ignore
string_format "{0,-5}{1,-5}{2,-5}" (dyn l) |> ignore
string_format (dyn "{0} = {1}") (dyn q) |> ignore
    """

let test94 =
    "test94",[array],"Does the string concat work as expected?",
    """
Array.init 8 (string_format "{0}") |> string_concat "; " |> string_format "[|{0}|]" |> dyn |> ignore
(2,2.3,"qwe") |> Tuple.map (string_format "{0}") |> string_concat "; " |> string_format "[{0}]" |> dyn |> ignore
    """

let test95 =
    "test95",[extern_;array],"Does the show work?",
    """
open Extern
Array.init 8 (inl i -> {x = to float64 i; y = to float64 i-30.0} |> dyn |> packed_stack) |> show
    """

let test96 =
    "test96",[host_tensor;console],"Does the show from Tensor work?",
    """
open Tensor
init (2,3,4) (inl a b c -> a*b*c)  
|> show |> Console.writeline
    """

let test97 =
    "test97",[host_tensor;console],"Does the view indexing work?",
    """
open Tensor
inl w = 2,3,4
init (2,3,4) (inl a b c -> a*b*c) (1,{from=1},{from=1; by=2})
|> show |> Console.writeline
    """

let test98 =
    "test98",[],"Do the unary operators work next to `=` and `:`?",
    """
inl x=-1
[qwe:.asd; 1:-2] |> ignore
x
    """

let test99 =
    "test99",[],"Does the binary . operator apply if it is directly next to an expression?",
    """
inl f = function
    | .Hello as x -> .Bye

inl g = function
    | .Bye -> ()

g f.Hello
    """

let test100 = 
    "test100",[],"Does the unit closure get printed correctly.",
    """
inl rec loop f i =
    inl f, i = term_cast f (), dyn i
    inl body _ = if i < 10 then loop (inl _ -> f() + 1) (i + 1) else f()
    join (body() : int64)

loop (inl _ -> 0) 0
    """

let test101 = 
    "test101",[],"Does `a` cause a hygiene violation by leaking its main argument into `inter`?",
    """
inl a = dyn 1

met rec inter x = // Does the int appear in the generated function? It should not.
    inl _ = x
    inter (dyn 2.0)
    : 2.0

inter ()
    """

let test102 = 
    "test102",[loops],"Does the unroll work?",
    """
inl f x = x ()
inl dyn = dyn >> ignore
inl x _ = 
    dyn "1" 
    inl _ ->
        dyn "2"
        inl _ ->
            dyn "3"
            inl rec loop _ = dyn "..."; loop
            loop
Loops.unroll f x
    """

let test103 = 
    "test103",[loops],"Does the foru work?",
    """
inl f x = x ()
inl dyn = dyn >> ignore
inl x _ = 
    dyn "1" 
    inl _ ->
        dyn "2"
        inl _ ->
            dyn "3"
            inl rec loop _ = dyn "..."; loop
            loop
Loops.foru {from=0; near_to=30; state = x; body = inl {state i} -> state ()}
    """

let test104 = 
    "test104",[tuple],"Does the map2 work?",
    """
inl a = 1,2,3
inl b = 4,5,6
Tuple.map2 (inl a b -> a + b) a b
    """

let test105 = 
    "test105",[tuple],"Does the foldl2 work?",
    """
inl a = 1,2,3
inl b = 4,5,6
Tuple.foldl2 (inl s a b -> s + a + b) 0 a b
    """

let test106 = 
    "test106",[],"Does the injection pattern work?",
    """
inl m = {
    a = 123
    b = 456
    }
inl f i {$i=x} = x
f .a m, f .b m
    """

let test107 = 
    "test107",[],"Does the injection constructor work?",
    """
inl f i v m = {m with $i=v}
{}
|> f .a 123
|> f .b 456
|> inl {a b} -> a,b
    """

let test108 = 
    "test108",[],"Does the parser give an error on an indented expression after a statement?",
    """
1 |> ignore
    2
    """

let test109 = 
    "test109",[],"Does the newline after a semicolon work correctly?",
    """
{a=1; b=2; 
 c=3}
    """

let test110 =
    "test110",[],"Does destructure work on nested structures?",
    """
inl q = {q=1;w=2;e=3}
inl w = {a=q;b=q}
inl e = {z=w;x=w}
inl e = join e
inl e = join e
()
    """

let test111 =
    "test111",[],"Does structural equality work correctly on bare types?",
    """
inl Q = (int64,int64) \/ int64
met f _ = box Q (3)
inl a, b = f (), f ()
a = b
    """

let test112 =
    "test112",[],"Does the () module-with pattern work?",
    """
inl k = .q
inl m = { $k = { b = 2 }}

{(m).(k) with a = 1}
    """

let test113 =
    "test113",[host_tensor_view;console],"Do the tensor range views work?",
    """
inl tns =
    Tensor.init (2,3,4) (inl a b c -> a*b*c)  
    |> View.wrap ({from=2; near_to=4},{from=2; near_to=5},{from=2; near_to=6})

inl tns = tns ((), {from=3; by=2}, {from=3})
tns .basic |> Tensor.print
    """

let test114 =
    "test114",[host_tensor_view;console],"Do the tensor tree views work?",
    """
inl tns =
    Tensor.init (2,3,4) (inl a b c -> a*b*c)  
    |> View.wrap ({a=1; b=1},{a=1; b=2},{a=1; b={q=3}})

inl tns = tns ({b=()}, {b=()}, {b={q=()}})
tns .basic |> Tensor.print
    """

let test115 =
    "test115",[host_tensor_view;console],"Does the tensor view's create function work?",
    """
inl tns = View.create {dim={a=1; b=1}, {a=1; b=2}, {a=1; b={q=3}}; elem_type=float32}

inl tns = tns ({b=()}, {b=()}, {b={q=()}})
tns .basic |> Tensor.print
    """

let test116 =
    "test116",[host_tensor_view;console],"Do the tensor tree partial views work?",
    """
inl tns =
    Tensor.init (4,16) (inl a b -> a,b)
    |> View.wrap ((), {a={b=4; c=4}; d={e=4; f=4}})

tns ((),{d=()}) .basic |> Tensor.print
    """

let test117 =
    "test117",[host_tensor;console],"Do the tensor expand_singular work?",
    """
open Tensor
init (1,5) (inl a b -> a, b)
|> Tensor.expand_singular (5,5) 
|> Tensor.print
    """

let parsing1 = 
    "parsing1",[parsing;console],"Does the Parsing module work?",
    """
open Parsing
open Console

inl p = 
    succ 1
    |>> writeline

run_with_unit_ret (readall()) p
    """

let parsing2 = 
    "parsing2",[parsing;console],"Does the Parsing module work?",
    """
open Parsing
open Console

inl p = 
    pdigit
    |>> writeline

run_with_unit_ret (dyn "2") p
    """

let parsing3 = 
    "parsing3",[parsing;console],"Does the Parsing module work?",
    """
open Parsing
open Console

inl p = 
    pstring "qwe"
    |>> writeline

run_with_unit_ret (dyn "qwerty") p
    """

let parsing4 = 
    "parsing4",[parsing;console],"Does the Parsing module work?",
    """
open Parsing
open Console

inl p = 
    parse_int
    |>> writeline

run_with_unit_ret (dyn "1 2 3") p
    """

let parsing5 =
    "parsing5",[parsing;console],"Does the Parsing module work?",
    """
open Parsing
open Console

inl p = 
    parse_array {parser=parse_int; typ=int64; n=16}
    >>. succ ()

run_with_unit_ret (readall()) p
    """

let parsing6 =
    "parsing6",[parsing;console],"Do the printf's work?",
    """
open Parsing

inl a,b,c = dyn (1,2,3)
sprintf "%i + %i = %i" a b c |> ignore
    """

let parsing7 =
    "parsing7",[array;console;parsing;extern_],"Does the parsing library work? Birthday Cake Candles problem.",
    """
//https://www.hackerrank.com/challenges/birthday-cake-candles

open Extern
open Console
open Parsing

inl int64_minvalue = FS.Constant "System.Int64.MinValue" int64

inl p = 
    inm n = parse_int
    inm ar = parse_array {parser=parse_int; typ=int64; n} 
    Array.foldl (inl (min,score as s) x ->
        if x > score then (1,x)
        elif x = score then (min+1,score)
        else s
        ) (dyn (0,int64_minvalue)) ar
    |> fst
    |> writeline
    |> succ
        
run_with_unit_ret (readall()) p
    """
    
let parsing8 =
    "parsing8",[array;console;parsing],"Does the parsing library work? Diagonal Sum Difference problem.",
    """
//https://www.hackerrank.com/challenges/diagonal-difference
open Console
open Parsing

inl abs x = if x >= 0 then x else -x

inl f =
    inm n = parse_int
    inm ar = parse_array {parser=parse_int; typ=int64; n=n*n}
    inl load row col = 
        inl f x = x >= 0 || x < n
        assert (f row && f col) "Out of bounds."
        ar (n * row + col)
    met rec loop (!dyn i) (d1,d2 as s) =
        if i < n then loop (i+1) (d1 + load i i, d2 + load i (n-i-1))
        else s
        : s
    inl a,b = loop 0 (0,0)
    abs (a-b) 
    |> writeline
    |> succ

run_with_unit_ret (readall()) f
        """

let loop1 =
    "loop1",[loops;console],"Does the Loop module work?",
    """
open Console
open Loops
//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

for {from=dyn 999; down_to=dyn 3; by=dyn -1; state=dyn 0; body = inl {state i} ->
    if i % 3 = 0 || i % 5 = 0 then state+i
    else state
    }
|> writeline
    """

let loop2 =
    "loop2",[loops;console],"Does the Loop module work?",
    """
open Console
open Loops

for {from=dyn 3; to=dyn 999; state=dyn 0; body = inl {state i} ->
    if i % 3 = 0 || i % 5 = 0 then state+i
    else state
    }
|> writeline
    """

let loop3 =
    "loop3",[loops;console],"Does the Loop module work?",
    """
open Console
open Loops

for {static_from=6; down_to=3; by= -1; state=0; body = inl {state i} ->
    if i % 3 = 0 || i % 5 = 0 then state+i
    else state
    }
|> writeline
    """

let loop5 = 
    "loop5",[loops],"Does the Loop module work?",
    """
open Loops

for {static_from=2; to=2; body = inl {i} -> ()}
    """

let loop6 =
    "loop6",[loops;console],"Do state changing nested loops work?",
    """
open Loops
open Console
inl compare_pos (a_row,a_col) (b_row,b_col) = a_row = b_row && a_col = b_col
inl ret = {
    some = inl state -> printfn "Success." ()
    none = inl state -> failwith () "Failure."
    }
inl princess_pos = dyn (0,0)
inl mario_pos = dyn (1,1)
inl n = 5
for' {from=dyn 0; near_to=n; state={}; 
    body=inl {next=row i=r state} ->
        for' {from=dyn 0; near_to=n; state;
            body=inl {next=col i=c state} ->
                printfn "I am at ({0},{1})" (r, c)
                inl ret state = 
                    match state with
                    | {mario princess} -> ret .some state
                    | _ -> col state
                if compare_pos (r,c) mario_pos then ret {state with mario=mario_pos}
                elif compare_pos (r,c) princess_pos then ret {state with princess=princess_pos}
                else ret state
            finally=row
            }
    finally=ret .none
    }
    """

let loop7 =
    "loop7",[console],"Do state changing nested loops work?",
    """
open Console
inl compare_pos (a_row,a_col) (b_row,b_col) = a_row = b_row && a_col = b_col
inl ret = {
    some = inl state -> printfn "Success." ()
    none = inl state -> failwith () "Failure."
    }
inl princess_pos = dyn (0,0)
inl mario_pos = dyn (1,1)
inl n = dyn 5
met rec row {from=r near_to state} as d =
    met rec col {from=c near_to state} as d =
        if c < near_to then
            printfn "I am at ({0},{1})" (r, c)
            inl ret = function
                | {mario princess} as state -> ret .some state
                | state -> col {d with state from=c+1}
            if compare_pos (r,c) mario_pos then 
                printfn "I've found Mario." ()
                ret {state with mario=mario_pos}
            elif compare_pos (r,c) princess_pos then 
                printfn "I've found Princess." ()
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

let loop8 =
    "loop8",[loops;console],"Do state changing nested loops work?",
    """
open Console

met rec for {from=(!dyn from) near_to state body finally} =
    if from < near_to then 
        inl next state = for {from=from+1; near_to state body finally} 
        body {next state i=from}
    else finally state
    : finally state

inl compare_pos (a_row,a_col) (b_row,b_col) = a_row = b_row && a_col = b_col
inl ret = {
    some = inl state -> printfn "Success." ()
    none = inl state -> failwith () "Failure."
    }
inl princess_pos = dyn (0,0)
inl mario_pos = dyn (1,1)
inl n = dyn 5
for {from=0; near_to=n; state={};
    body = inl {next=row i=r state} ->
        for {from=0; near_to=n; state;
            body = inl {next=col i=c state} ->
                printfn "I am at ({0},{1})" (r, c)
                inl ret = function
                    | {mario princess} as state -> ret .some state
                    | state -> col state
                if compare_pos (r,c) mario_pos then 
                    printfn "I've found Mario." ()
                    ret {state with mario=mario_pos}
                elif compare_pos (r,c) princess_pos then 
                    printfn "I've found Princess." ()
                    ret {state with princess=princess_pos}
                else ret state
            finally = row
            }
    finally = ret .none
    }
    """


let euler2 = 
    "euler2",[loops;console],"Even Fibonacci Numbers.",
    """
open Loops
open Console

while {
    state={sum=dyn 0; a=dyn 1; b=dyn 2}
    cond=inl {b} -> if b <= 4*1000*1000 then true else false
    body=inl {sum a b} -> {sum=if b % 2 = 0 then sum+b else sum; a=b; b=a+b}
    }
|> inl {sum} -> writeline sum
    """

let euler3 = 
    "euler3",[array;loops;console;option;extern_],"Largest prime factor",
    """
open Extern
open Loops
open Console
open Array
open Option

// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?

inl math_type = fs [text: "System.Math"]

inl target = dyn 600851475143

inl sieve_length = 
    FS.StaticMethod math_type .Sqrt(to float64 target) float64
    |> to int64

inl sieve = Array.init (sieve_length+1) (inl _ -> true)
for {from=2; to=sieve_length; body = inl {i} ->
    if sieve i = true then
        for {from=i+i; to=sieve_length; by=i; body = inl {i} -> 
            sieve i <- false
            }
    }

for' {from=sieve_length; to=2; by= -1; state=none int64; body = inl {next state i} ->
    if sieve i = true && target % i = 0 then some i
    else next state
    }
|>  function
    | .Some, result -> writeline result // 6857
    | .None -> failwith () "No prime factor found!"
    """

let euler4 = 
    "euler4",[array;loops;console],"Largest palindrome product",
    """
//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//Find the largest palindrome made from the product of two 3-digit numbers.

open Loops
open Console

inl reverse_number x =
    while {
        cond=inl {x} -> x > 0 
        state={x x' = dyn 0}
        body=inl {x x'} -> {x=x/10; x'= x'*10+x%10}
        }
    |> inl {x'} -> x'
inl is_palindrome x = x = reverse_number x
for {from=dyn 100; to=dyn 999; state={highest_palindrome=dyn 0}; body=inl {state i} ->
    for {from=i; to=dyn 999; state; body=inl {{state with highest_palindrome} i=j} ->
        inl x = i*j
        if is_palindrome x && highest_palindrome < x then {highest_palindrome=x} else state
        }
    } 
|> inl {highest_palindrome} -> writeline highest_palindrome
    """

let euler5 =
    "euler5",[tuple;loops;console;extern_],"Smallest multiple",
    """
//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

open Extern
open Loops
open Console

inl primes = 2,3,5,11,13,17,19
inl non_primes = Tuple.range (2,20) |> Tuple.filter (Tuple.contains primes >> not)
inl step = Tuple.foldl (*) 1 primes
inl int64_maxvalue = FS.Constant "System.Int64.MaxValue" int64
for' {from=step; to=int64_maxvalue; by=step; state= -1; body=inl {next state i} ->
    if Tuple.forall (inl x -> i % x = 0) non_primes then i
    else next state
    }
|> writeline
    """

let hacker_rank_2 =
    "hacker_rank_2",[tuple;array;host_tensor;loops;list;option;parsing;console],"Save The Princess",
    """
// https://www.hackerrank.com/challenges/saveprincess
// A simple dynamic programming problem. It wouldn't be hard to do in F#, but Spiral
// gives some novel challenges regarding it.
open Parsing
open Console
open Option
open Array
open Loops

inl Cell = .Empty \/ .Princess \/ .Mario

inl empty = pchar '-' >>% box Cell .Empty
inl princess = pchar 'p' >>% box Cell .Princess
inl mario = pchar 'm' >>% box Cell .Mario

inl cell = empty <|> princess <|> mario

inl parse_cols n = parse_array {parser=cell; typ=Cell; n} .>> spaces
inl parse_field n = parse_array {parser=parse_cols n; typ=type (array_create Cell 0); n}
inl parser = 
    inm n = parse_int 
    inm field = parse_field n
    inl no_pos = none (int64,int64)
    for' {from = 0; near_to=n; state={princess=no_pos; mario=no_pos}; body = inl {next=row state i=r} ->
        for' {from = 0; near_to=n; state; 
            body = inl {next=col state i=c} ->
                match field r c with
                | .Mario -> 
                    inl state = {state with mario=some (r,c)}
                    match state with
                    | {princess=.Some, _} -> state
                    | _ -> col state
                | .Princess -> 
                    inl state = {state with princess=some (r,c)}
                    match state with
                    | {mario=.Some, _} -> state
                    | _ -> col state
                | _ -> col state
            finally = row
            }
        }
    |> function
        | {mario=.Some, (mario_row, mario_col as mario_pos) princess=.Some, (princess_row, princess_col as princess_pos)} ->
            inl cells_visited = Tensor.init (n,n) (inl _ _ -> false)
            cells_visited mario_row mario_col .set true

            inl up_string = dyn "UP"
            inl down_string = dyn "DOWN"
            inl left_string = dyn "LEFT"
            inl right_string = dyn "RIGHT"

            inl up (row,col), prev_moves = (row-1,col), List.cons up_string prev_moves
            inl down (row,col), prev_moves = (row+1,col), List.cons down_string prev_moves
            inl left (row,col), prev_moves = (row,col-1), List.cons left_string prev_moves
            inl right (row,col), prev_moves = (row,col+1), List.cons right_string prev_moves

            inl next_moves = up,down,left,right

            inl is_valid x = x >= 0 && x < n
            inl is_in_range (row,col), _ = is_valid row && is_valid col
            inl is_princess_in_state (row,col), _ = row = princess_row && col = princess_col

            inl start_queue = Array.singleton (mario_pos, List.empty string)
            inl state_type = start_queue.elem_type

            inl solution = ref (none state_type)
            met rec loop queue =
                inl queue =
                    Array.map (inl mario_pos, prev_moves as state ->
                        inl potential_new_states = 
                            Tuple.map (inl move -> 
                                inl (pos_row, pos_col),_ as new_state = move state
                                inl is_valid =
                                    if is_in_range new_state && cells_visited pos_row pos_col .get = false then 
                                        if is_princess_in_state new_state then solution := some new_state
                                        cells_visited pos_row pos_col .set true
                                        true
                                    else false
                                new_state, is_valid
                                ) next_moves
                        inl bool_to_int x = if x then 1 else 0
                        inl number_of_valid_states = Tuple.foldl (inl s (_,!bool_to_int x) -> s + x) 0 potential_new_states
                        inl new_states = array_create state_type number_of_valid_states
                        Tuple.foldl (inl i (state,is_valid) -> 
                            if is_valid then new_states i <- state; i+1
                            else i
                            ) 0 potential_new_states |> ignore
                        new_states
                        ) queue
                    |> Array.concat
                match solution() with
                | .None -> loop queue
                | .Some, (_, path) -> List.foldr (inl x _ -> Console.writeline x) path ()
                : ()
            loop start_queue
        | _ -> failwith () "Current position not found."
    |> succ

//inl str = dyn "3
//---
//-m-
//p--
//    "
run_with_unit_ret (readall()) parser
    """

let hacker_rank_3 =
    "hacker_rank_3",[tuple;array;host_tensor;loops;list;parsing;console;queue],"Save The Princess 2",
    """
// https://www.hackerrank.com/challenges/saveprincess2
// A version of this similar to the previous one made in order to test the new queue.
open Parsing
open Console
open Array
open Loops

inl Cell = .Empty \/ .Princess \/ .Mario

inl empty = pchar '-' >>% box Cell .Empty
inl princess = pchar 'p' >>% box Cell .Princess
inl mario = pchar 'm' >>% box Cell .Mario

inl cell = empty <|> princess <|> mario

inl parse_cols n = parse_array {parser=cell; typ=Cell; n} .>> spaces
inl parse_field n = parse_array {parser=parse_cols n; typ=type (array_create Cell 0); n}
inl parser ret = 
    inm n = parse_int .>> parse_int .>> parse_int
    inm field = parse_field n
    for' {from = 0; near_to=n; state={n field}; 
        body = inl {next=row state i=r} ->
            for' {from = 0; near_to=n; state; 
                body = inl {next=col state i=c} ->
                    inl ret = function
                        | {mario princess} as state -> ret .some state
                        | state -> col state
                    match field r c with
                    | .Mario -> ret {state with mario=r,c}
                    | .Princess -> ret {state with princess=r,c}
                    | _ -> col state
                finally = row
                }
        finally = ret .none
        }
    |> succ

inl main = {
    some = met {n field mario=(mario_row, mario_col as mario_pos) princess=(princess_row, princess_col as princess_pos)} ->
        inl cells_visited = Tensor.init (n,n) (inl _ _ -> false)
        cells_visited mario_row mario_col .set true

        inl up_string = dyn "UP"
        inl down_string = dyn "DOWN"
        inl left_string = dyn "LEFT"
        inl right_string = dyn "RIGHT"

        inl up (row,col), prev_moves = (row-1,col), List.cons up_string prev_moves
        inl down (row,col), prev_moves = (row+1,col), List.cons down_string prev_moves
        inl left (row,col), prev_moves = (row,col-1), List.cons left_string prev_moves
        inl right (row,col), prev_moves = (row,col+1), List.cons right_string prev_moves

        inl is_valid x = x >= 0 && x < n
        inl is_in_range (row,col), _ = is_valid row && is_valid col
        inl is_princess_in_state (row,col), _ = row = princess_row && col = princess_col

        inl init_state = (mario_pos, List.empty string)
        inl state_type = type init_state 

        open Queue
        inl queue = create state_type ()
        enqueue queue init_state

        met print_solution _, path = //List.foldr (inl x _ -> Console.writeline x) path ()
            match List.last path with
            | .Some, x -> Console.writeline x
            | .None -> failwith () "Error: No moves taken."

        met evaluate_move state move on_fail =
            inl (pos_row, pos_col),_ as new_state = move state
            if is_in_range new_state && cells_visited pos_row pos_col .get = false then 
                if is_princess_in_state new_state then print_solution new_state
                else
                    cells_visited pos_row pos_col .set true
                    enqueue queue new_state
                    on_fail ()
            else on_fail ()
            
        met rec loop () =
            inl next_moves = up, down, left, right
            inl state = dequeue queue
            Tuple.foldr (inl move next () -> evaluate_move state move next) next_moves loop ()
            : ()

        loop ()
    none = inl _ -> failwith () "Current position not found."
    }

run_with_unit_ret (readall()) (parser main)
    """

let hacker_rank_4 =
    "hacker_rank_4",[tuple;array;parsing;console;option],"Game of Stones",
    """
// https://www.hackerrank.com/challenges/game-of-stones-1
open Parsing
open Console
open Loops
open Option

inl Player = .First \/ .Second

inl first = box Player .First
inl second = box Player .Second
inl not_visited = none Player

inl max_n = 100
inl solutions = Array.init (max_n+1) (const not_visited)

met rec solve (!dyn player, !dyn opposing_player) (!dyn n) =
    inl take amount on_fail = 
        if n >= amount && solve (opposing_player,player) (n-amount) = player then player
        else on_fail ()

    met run () = Tuple.foldr (inl take on_fail _ -> take on_fail) (take 2, take 3, take 5) (const opposing_player) () 

    if player = first then
        match solutions n with
        | .None -> 
            inl x = run()
            solutions n <- some x
            x
        | .Some, x -> x
    else run()
    : player

inl show .(x) = writeline x
inl parser = 
    inm t = parse_int
    repeat t (inl i -> parse_int |>> (solve (first,second) >> show))

run_with_unit_ret (readall()) parser
    """

let hacker_rank_5 =
    "hacker_rank_5",[parsing;console],"Game of Stones",
    """
// https://www.hackerrank.com/challenges/tower-breakers-1
open Parsing
open Console

// This is the solution from the discussion forum that I've been spoilered on.
inl solve n,m = if m = 1 || n % 2 = 0 then 2 else 1

inl parser = 
    inm t = parse_int
    repeat t (inl i -> parse_int .>>. parse_int |>> (solve >> writeline))

run_with_unit_ret (readall()) parser
    """

let hacker_rank_6 =
    "hacker_rank_6",[tuple;array;host_tensor;parsing;console;option],"A Chessboard Game",
    """
// https://www.hackerrank.com/challenges/a-chessboard-game-1
open Parsing
open Console
open Option

inl num_players = 2
inl first = 0
inl second = 1

inl max_t = 15

inl cache = 
    inl cache = Tensor.init (max_t,max_t,num_players) (inl _ _ _ -> none first)
    inl op (x,y,player_one,player_two) -> cache (x-1) (y-1) player_one op

met rec solve !dyn (x,y,player_one,player_two) as d = 
    inl new_positions = (x-2,y+1),(x-2,y-1),(x+1,y-2),(x-1,y-2)
    inl is_in_range x = x >= 1 && x <= 15
    inl try x,y on_fail =
        if is_in_range x && is_in_range y && solve (x,y,player_two,player_one) = player_one then player_one
        else on_fail()
    match cache.get d with
    | .None -> Tuple.foldr (inl pos next () -> try pos next) new_positions (const player_two) () |> inl x -> some x |> cache.set d; x
    | .Some, x -> x
    : player_one

inl show = function
    | x when x = first -> writeline "First"
    | _ -> writeline "Second"

inl parser = 
    inm t = parse_int
    repeat t (inl i -> parse_int .>>. parse_int |>> inl x,y -> solve (x,y,first,second) |> show)

run_with_unit_ret (readall()) parser
    """

let hacker_rank_7 =
    "hacker_rank_7",[tuple;array;parsing;console;option],"Introduction to Nim Game",
    """
// https://www.hackerrank.com/challenges/nim-game-1/problem

open Parsing
open Console
open Array

inl solve = Array.foldl (^^^) 0
inl show = function
    | 0 -> writeline "Second"
    | _ -> writeline "First"

inl parser = 
    inm t = parse_int
    repeat t (inl _ -> 
        inm n = parse_int 
        parse_array {n parser=parse_int; typ=int64} |>> (solve >> show)
        )

run_with_unit_ret (readall()) parser
    """

let hacker_rank_8 =
    "hacker_rank_8",[tuple;array;parsing;console;option],"Misere Nim",
    """
// https://www.hackerrank.com/challenges/misere-nim-1

open Parsing
open Console
open Array

// https://mathoverflow.net/questions/71802/analysis-of-misere-nim
inl solve ar = 
    inl r = Array.foldl (^^^) 0 ar
    if Array.forall ((=) 1) ar then r ^^^ 1
    else r
    
inl show = function
    | 0 -> writeline "Second"
    | _ -> writeline "First"

inl parser = 
    inm t = parse_int
    repeat t (inl _ -> 
        inm n = parse_int 
        parse_array {n parser=parse_int; typ=int64} |>> (solve >> show)
        )

run_with_unit_ret (readall()) parser
    """

let hacker_rank_9 =
    "hacker_rank_9",[tuple;array;host_tensor_view;parsing;console;option],"The Power Sum",
    """
// https://www.hackerrank.com/challenges/the-power-sum

open Parsing
open Console
open Array
open Loops

inl x_range = {from=1; to=1000}
inl n_range = {from=2; to=10}

inl x_to_n = 
    inl cache = View.create {dim=x_range,n_range; elem_type=int64}
    for {x_range with body=inl {i=x} ->
        for {n_range with body=inl {i=n} ->
            for {from=2; to=n; state=x; body=inl {state=x'} -> x*x'}
            |> cache x n .set
            }
        }
    inl (x, n) -> cache x n .get

met rec solve !dyn state !dyn sum !dyn from to,n =
    for' {from to state body=inl {next state i=x} ->
        inl sum = sum + x_to_n (x,n)
        if sum = to then state + 1
        elif sum < to then next (solve state sum (x+1) (to,n))
        else state
        }
    : state

inl parser = parse_int .>>. parse_int |>> (solve 0 0 1 >> writeline)
run_with_unit_ret (readall()) parser 
    """

let tests =
    [|
    test1;test2;test3;test4;test5;test6;test7;test8;test9
    test10;test11;test12;test13;test14;test15;test16;test17;test18;test19
    test20;test21;test22;test23;test24;test25;test26;test27;test28;test29
    test30;test31;test32;test33;test34;test35;test36;test37;test38;test39
    test40;test41;test42;test43;test44;test45;test46;test47;test48;test49
    test50;test51;test52;test53;test54;test55;test56;test57;test58;test59
    test60';test61;test62;test63;test64;test65;test66;test67;test68;test69
    test70;test71';test72;test73;test74;test75;test76';test77';test78;test79
    test80;test81;test82;test83;test84;test85;test86;test87;test88;test89
    test90;test91;test92;test93;test94;test95;test96;test97;test98;test99
    test100;test101;test102;test103;test104;test105;test106;test107;test108;test109
    test110;test111;test112;test113;test114;test115;test116;test117
    hacker_rank_1;hacker_rank_2;hacker_rank_3;hacker_rank_4;hacker_rank_5;hacker_rank_6;hacker_rank_7;hacker_rank_8;hacker_rank_9
    parsing1;parsing2;parsing3;parsing4;parsing5;parsing6;parsing7;parsing8
    loop1;loop2;loop3;     loop5;loop6;loop7;loop8
    euler2;euler3;euler4;euler5
    |]

open System.IO
open System

let run_test_and_store_it_to_stream cfg stream (name,aux,desc,body as m) =
    let main_module = module_ m
    sprintf "%s - %s:\n%s\n\n" name desc (body.Trim()) |> stream
    match spiral_peval cfg main_module with
    | Succ (x,_) | Fail x -> stream x

let output_test_to_string cfg test = 
    match spiral_peval cfg (module_ test) with
    | Succ (x,_) | Fail x -> x

let output_test_to_temp cfg path test = 
    match spiral_peval cfg (module_ test) with
    | Succ (x,_) | Fail x -> 
        if Directory.Exists <| Path.GetDirectoryName path then File.WriteAllText(path,x)
        else failwithf "File %s not found.\nNote to new users: In order to prevent files being made in the middle of nowhere this check was inserted.\nWhat you should do is create a new F# project and point the compiler to a file in that directory instead." path
        x

let make_test_path_from_name name =
    let dir = Environment.CurrentDirectory |> DirectoryInfo
    let path = Path.Combine(dir.Parent.Parent.FullName,"TestCache")
    Directory.CreateDirectory path |> ignore
    Path.Combine(path,name+".txt")

let cache_test cfg ({parsing_time=a; prepass_time=b; peval_time=c; codegen_time=d} as time) (name,aux,desc,body as m) = 
    let write x = File.WriteAllText(make_test_path_from_name name, x)
    match spiral_peval cfg (module_ m) with
    | Fail x -> write x; time
    | Succ(x, {parsing_time=a'; prepass_time=b'; peval_time=c'; codegen_time=d'}) -> write x; {parsing_time=a+a'; prepass_time=b+b'; peval_time=c+c'; codegen_time=d+d'}
    
let rewrite_test_cache tests cfg x = 
    let time = {parsing_time=TimeSpan.Zero; prepass_time=TimeSpan.Zero; peval_time=TimeSpan.Zero; codegen_time=TimeSpan.Zero}
    match x with
    | None -> Array.fold (cache_test cfg) time tests
    | Some (min, max) -> Array.fold (cache_test cfg) time tests.[min..max-1]
    |> fun ({parsing_time=a; prepass_time=b; peval_time=c; codegen_time=d} as time) -> 
        printfn "The timings are: %A" time
        printfn "The time it took to run all the tests is: %A" (a+b+c+d)

//let speed1 = // Note: Trying to load this example in the IDE after it has compiled will crush it. Better output it to txt.
//    "speed1",[parsing;console],"Does the Parsing module work?",
//    """
//open Parsing
//open Console
//
//inl p = 
//    tuple (Tuple.repeat 240 <| (pint64 .>> spaces))
//    |>> (Tuple.foldl (+) 0 >> writeline)
//
//run_with_unit_ret (readall()) p
//    """
//
//let speed2 = // ~0.42s~ 1s
//    "speed2",[],"Does a simple loop have superlinear scaling?",
//    """
//inl rec loop = function
//    | i when i > 0 -> loop (i-1)
//    | 0 -> ()
//loop 50000
//    """
//
//let speed3 = // Minus the startup, this takes 0.05s to peval versus 1.5s for the previous version of the compiler.
//    let code =
//        let var i = sprintf "var_%i" i
//        let bnd (a, b) = sprintf "inl %s = %s" a b
//        let vars = [|0..900|] |> Array.map var // Any more than this and it will stack overflow.
//        let bnds = 
//            vars |> Array.pairwise |> Array.map (fun (a,b) -> b,a) 
//            |> Array.map bnd |> String.concat "\n"
//        let adds = String.concat " + " vars
//        String.concat "\n" [|bnd (var 0, "dyn 0");bnds;adds|]

//    "speed3",([] : Module list),"Does the linear sequence of bindings get compiled in linear time?",code
    

