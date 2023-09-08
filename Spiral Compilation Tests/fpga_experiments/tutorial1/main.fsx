type UH0 =
    | UH0_0 of int32
    | UH0_1 of float32
    | UH0_2 of string
    | UH0_3 of char
let v0 : string = "qwe"
let v1 : UH0 = UH0_2(v0)
match v1 with
| UH0_0(v2) -> (* A *)
    printfn "%A" v2 
    ()
| UH0_1(v3) -> (* B *)
    printfn "%A" v3 
    ()
| UH0_2(v4) -> (* C *)
    printfn "%A" v4 
    ()
| UH0_3(v5) -> (* D *)
    printfn "%A" v5 
    ()
