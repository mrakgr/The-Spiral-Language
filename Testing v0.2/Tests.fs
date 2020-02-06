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

inl main _ = p (.Some, .None) |> dyn
    """
    }

let test17: SpiralModule =
    {
    name="test17"
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

let test20: SpiralModule =
    {
    name="test20"
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

let test21: SpiralModule =
    {
    name="test21"
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

let test22: SpiralModule =
    {
    name="test22"
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

let test23: SpiralModule =
    {
    name="test23"
    prerequisites=[]
    description="Does the pair pattern work?"
    code=
    """
inl main _ =
    inl f = function x1, x2, x3, xs -> 3 | x1, x2, xs -> 2 | x1, xs -> 1 | () -> 0

    dyn (f (), f (1, ()), f (1,2))
    """
    }

let test27: SpiralModule =
    {
    name="test27"
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

let test28: SpiralModule =
    {
    name="test28"
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

let test30: SpiralModule =
    {
    name="test30"
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

let test31: SpiralModule =
    {
    name="test31"
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

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__ , @"..\Temporary\output.fs")) test31
|> printfn "%s"
|> ignore

