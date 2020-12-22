module Spiral.Tests
open System.IO

open Spiral.ParserCombinators
open Spiral.Compile

let cfg = {
    trace_length = 20
    filter_list = []
    }

let test1: SpiralModule =
    {
    name="test1"
    prerequisites=[]
    description="Does it run?"
    code=
    """
inl main _ =
    inl a = 5
    inl b = 10
    dyn (a + b)
    """
    }

let test2: SpiralModule =
    {
    name="test2"
    prerequisites=[]
    description="Do the join points work?"
    code=
    """
inl main _ =
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
inl main _ =
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
inl main _ =
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
inl main _ =
    inl f = function
        | .(+) -> fun x y -> join (x + y)
        | .(-) -> fun x y -> join (x - y)
        | .Mult -> fun x y -> join (x * y)
    inl a = f .(+) 1 2
    inl b = f .(-) 1 2
    inl c = f .Mult 1 2
    dyn (a, b, c)
    """
    }

let test6: SpiralModule =
    {
    name="test6"
    prerequisites=[]
    description="Does returning functions from functions work?"
    code=
    """
inl main _ =
    inl tes' n = join
        inl tes a = join
            fun b -> join
                fun c -> join
                    fun d -> join a,b,c
        tes 1 2 (2.2,3,4.5)
    tes' 10
    """
    }

let test7: SpiralModule =
    {
    name="test7"
    prerequisites=[]
    description="Do active patterns work?"
    code=
    """
inl main _ =
    inl f op1 op2 op3 = function
        | !op1 (.Some, x) -> x
        | !op2 (.Some, x) -> x
        | !op3 (.Some, x) -> x

    inl add = function
        | .Add -> .Some, fun x y -> x + y
        | _ -> .None
    inl sub = function
        | .Sub -> .Some, fun x y -> x - y
        | _ -> .None
    inl mult = function
        | .Mult -> .Some, fun x y -> x * y
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
    description="Does recursive pattern matching work on static data?"
    code=
    """
inl rec p = function
    | .Some, x -> p x
    | .None -> 0

inl main _ = p (.Some, .None) |> dyn
    """
    }

let test9: SpiralModule =
    {
    name="test9"
    prerequisites=[]
    description="Do records work?"
    code=
    """
inl main _ =
    inl m =
        inl x = 2
        inl y = 3.4
        inl z = "123"
        {x y z}
    dyn (m.x, m.y, m.z)
    """
    }

let test10: SpiralModule =
    {
    name="test10"
    prerequisites=[]
    description="Does defining user operators work?"
    code=
    """
inl main _ =
    inl (.+) a b = a + b
    inl x = 2 * 22 .+ 33

    inl f op a b = op a b
    f (*) 2 x
    |> dyn
    """
    }

let test11: SpiralModule =
    {
    name="test11"
    prerequisites=[]
    description="Do when and as patterns work?"
    code=
    """
inl main _ =
    inl f = function
        | a,b,c as q when a < 10 -> q
        | _ -> 0,0,0
    dyn (f (1,2,3))
    """
    }

let test12: SpiralModule =
    {
    name="test12"
    prerequisites=[]
    description="Do literal pattern matchers work? Does partial evaluation of equality work?"
    code=
    """
inl main _ =
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

let test13: SpiralModule =
    {
    name="test13"
    prerequisites=[]
    description="Does the pair pattern work?"
    code=
    """
inl main _ =
    inl f = function x1, x2, x3, xs -> 3 | x1, x2, xs -> 2 | x1, xs -> 1 | () -> 0

    dyn (f (), f (1, ()), f (1,2))
    """
    }

let test14: SpiralModule =
    {
    name="test14"
    prerequisites=[]
    description="Do the record map and fold functions work?"
    code=
    """
inl main _ =
    inl m = {a=1;b=2;c=3}
    inl m' = record_map (fun (key:value:) -> value * 2) m
    dyn (m', record_foldl (fun (state:key:value:) -> state + value) 0 m')
    """
    }

let test15: SpiralModule =
    {
    name="test15"
    prerequisites=[]
    description="Does the stack reified join point work?"
    code=
    """
inl main _ =
    inl a = dyn 1
    inl b = dyn 2
    inl add c d = a + b + c + d
    inl f g c d = join g c d
    f (rjp_stack add) (dyn 3) (dyn 4)
    """
    }

let test16: SpiralModule =
    {
    name="test16"
    prerequisites=[]
    description="Does the heap reified join point work?"
    code=
    """
inl main _ =
    inl a = dyn 1
    inl b = dyn 2
    inl add c d = a + b + c + d
    inl f g c d = join g c d
    f (rjp_heap add) (dyn 3) (dyn 4)
    """
    }

let test17: SpiralModule =
    {
    name="test17"
    prerequisites=[]
    description="Does the heap reified join point work with records?"
    code=
    """
inl main _ =
    inl m = rjp_heap { a=dyn 1; b=dyn 2 }
    inl add c d = 
        inl {a b} = rjp_none m
        a + b + c + d
    inl f g c d = join g c d
    f (rjp_heap add) (dyn 3) (dyn 4)
    """
    }

let test18: SpiralModule =
    {
    name="test18"
    prerequisites=[]
    description="Does this compile into just one method? Are the arguments reversed in the method call?"
    code=
    """
inl rec f a b = join
    if dyn true then f b a
    else a + b
    : i64
inl main _ = f (dyn 1) (dyn 2)
    """
    }

let test19: SpiralModule =
    {
    name="test19"
    prerequisites=[]
    description="Does the record pattern work?"
    code=
    """
inl main _ =
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

let test20: SpiralModule =
    {
    name="test20"
    prerequisites=[]
    description="Does the nested record pattern work?"
    code=
    """
inl main _ =
    inl f {name p={x y}} = name,(x,y)
    inl x = { name = "Coord" }

    f {x with 
        p = { x = 1
              y = 2 }}
    |> dyn
    """
    }

let test21: SpiralModule =
    {
    name="test21"
    prerequisites=[]
    description="Does the nested record pattern with rebinding work?"
    code=
    """
inl main _ =
    inl f {name p={y=y' x=x'}} = name,(x',y')
    inl x = { name = "Coord" }
    f {x with 
        p = { x = 1
              y = 2 }}
    |> dyn
    """
    }

let test22: SpiralModule =
    {
    name="test22"
    prerequisites=[]
    description="Does the record lens pattern work? Does 'this' work? Does the semicolon get parsed properly?"
    code=
    """
inl main _ =
    inl x = { a = { b = { c = 3 } } }

    inl f {a={b={c q}}} = c,q
    f {x.a.b with q = 4; c = this + 3; d = {q = 12; w = 23}}
    |> dyn
    """
    }

let test23: SpiralModule =
    {
    name="test23"
    prerequisites=[]
    description="Does the new record creation syntax work?"
    code=
    """
inl main _ =
    inl a = 1
    inl b = 2
    inl d = 4
    dyn {a b c = 3; d; e = 5}
    """
    }

let test24: SpiralModule =
    {
    name="test24"
    prerequisites=[]
    description="Does the partial evaluation of if statements work?"
    code=
    """
inl main _ =
    inl x = dyn false
    inl _ = dyn (x && (x || x && (x || x)))
    inl _ = dyn ((x && x || x) || (x || true))
    inl _ = dyn (if x then false else x)
    dyn (if x then false else true)

//let ((var_0 : bool)) = false
//let ((var_1 : bool)) = true
//let ((var_2 : bool)) = false
//let ((var_3 : bool)) = var_1 = false
    """
    }

let test25: SpiralModule =
    {
    name="test25"
    prerequisites=[]
    description="Do && and || work correctly?"
    code=
    """
inl main _ =
    inl a,b,c,d,e = dyn (true, false, true, false, true)
    a && b || c && d || e

//let ((var_0 : bool)) = true
//let ((var_1 : bool)) = false
//let ((var_2 : bool)) = true
//let ((var_3 : bool)) = false
//let ((var_4 : bool)) = true
//let ((var_5 : bool)) = var_0 && var_1
//let ((var_6 : bool)) =
//    if var_5 then
//        true
//    else
//        let ((var_6 : bool)) = var_2 && var_3
//        var_6 || var_4
    """
    }

let test26: SpiralModule =
    {
    name="test26"
    prerequisites=[]
    description="Does the argument get printed on a type error?"
    code=
    """
inl main _ =
    inl a : f64 = 5
    ()
    """
    }

let test27: SpiralModule =
    {
    name="test27"
    prerequisites=[]
    description="Does the error printing work? This one should give an error."
    code=
    """
inl main _ = 55 + id
    """
    }

let test28: SpiralModule =
    {
    name="test28"
    prerequisites=[]
    description="Does structural polymorphic equality work?"
    code=
    """
inl main _ = {a=1;b=dyn 2;c=dyn 3} = {a=1;b=2;c=3}

//let ((var_1 : int64)) = 2L
//let ((var_2 : int64)) = 3L
//let ((var_3 : bool)) = var_1 = 2L
//let ((var_5 : bool)) =
//    if var_3 then
//        var_2 = 3L
//    else
//        false
    """
    }

let test29: SpiralModule =
    {
    name="test29"
    prerequisites=[]
    description="Does this destructure trigger an error?"
    code=
    """
inl main _ =
    inl q = true && dyn true
    ()
    """
    }

let test30: SpiralModule =
    {
    name="test30"
    prerequisites=[]
    description="Does changing layout type work?"
    code=
    """
inl main _ = {a=1; b=2} |> dyn |> rjp_stack |> rjp_heap |> rjp_none
    """
    }

let test31: SpiralModule =
    {
    name="test31"
    prerequisites=[]
    description="Does the CSE work as expected?"
    code=
    """
inl main _ =
    inl (!dyn a,b) = 2,3
    (a+b)*(a+b)
    """
    }

let test32: SpiralModule =
    {
    name="test32"
    prerequisites=[]
    description="Does the binary . operator apply if it is directly next to an expression?"
    code=
    """
inl main _ =
    inl f = function
        | .Hello as x -> .Bye

    inl g = function
        | .Bye -> "Bye"

    dyn (g f.Hello)
    """
    }

let test33: SpiralModule =
    {
    name="test33"
    prerequisites=[]
    description="Does the prepass memoization work? Intended to be looked directly without the Core library."
    code=
    """
inl main _ =
    inl f x =
        match x with
        | q,w,e,r,t,z,x,c,v,b,m -> 0
        | (((),a,b) | ({q w e r t y z a b}, _, _)) -> 
            inl f a b = !!!!Add(a, b)
            f a b
        | a,b -> !!!!Add(a, b)
    !!!!Dynamize((f ({q=(); w=(); e=(); r=(); t=(); y=(); z=(); a=1; b=2},2,3)))
    """
    }

let test34: SpiralModule =
    {
    name="test34"
    prerequisites=[]
    description="Does the injection pattern work?"
    code=
    """
inl main _ =
    inl m = {
        a = 123
        b = 456
        }
    inl f i {$i=x} = x
    dyn (f .a m, f .b m)
    """
    }

let test35: SpiralModule =
    {
    name="test35"
    prerequisites=[]
    description="Does the injection constructor work?"
    code=
    """
inl main _ =
    inl f i v m = {m with $i=v}
    {}
    |> f .a 123
    |> f .b 456
    |> fun {a b c} -> a,b
    |> dyn
    """
    }

let test36: SpiralModule =
    {
    name="test36"
    prerequisites=[]
    description="Does the parser give an error on an indented expression after a statement? It should."
    code=
    """
inl main _ =
    1 |> ignore
        2
    """
    }

let test37: SpiralModule =
    {
    name="test37"
    prerequisites=[]
    description="Does the newline after a semicolon work correctly?"
    code=
    """
inl main _ =
    dyn
        {a=1; b=2; 
         c=3}
    """
    }

let test38: SpiralModule =
    {
    name="test38"
    prerequisites=[]
    description="Does returning from join points work on nested structures?"
    code=
    """
inl main _ =
    inl q = {q=1;w=2;e=3}
    inl w = {a=q;b=q}
    inl e = {z=w;x=w}
    inl e = join e
    inl e = join e
    ()
    """
    }

let test39: SpiralModule =
    {
    name="test39"
    prerequisites=[]
    description="Does the $ record-with pattern work?"
    code=
    """
inl main _ =
    inl k = .q
    inl m = { $k = { b = 2 }}

    {m$k with a = 1}
    |> dyn
    """
    }

let test40: SpiralModule =
    {
    name="test40"
    prerequisites=[]
    description="Do the keyword arguments get parsed correctly?"
    code=
    """
inl main _ =
    inl add left:right: = left + right
    add left:1 right: 2
    + add 
        left: 3 
        right: 7
    |> dyn
    """
    }

let test41: SpiralModule =
    {
    name="test41"
    prerequisites=[]
    description="Does the let statement work?"
    code=
    """
inl main _ =
    let f (x : i64) = x
    f 3
    """
    }

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) test40
|> printfn "%s"
|> ignore

