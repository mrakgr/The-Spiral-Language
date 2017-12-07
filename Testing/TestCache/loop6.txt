module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

let rec method_0((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 5L)
    if var_5 then
        let (var_6: int64) = 0L
        method_1((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_6: int64))
    else
        (failwith "Failure.")
and method_1((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64)): unit =
    let (var_6: bool) = (var_5 < 5L)
    if var_6 then
        System.Console.Write("I am at (")
        let (var_7: string) = System.String.Format("{0}",var_4)
        System.Console.Write(var_7)
        System.Console.Write(",")
        let (var_8: string) = System.String.Format("{0}",var_5)
        System.Console.Write(var_8)
        System.Console.Write(")")
        System.Console.WriteLine()
        let (var_9: bool) = (var_4 = var_0)
        let (var_11: bool) =
            if var_9 then
                (var_5 = var_1)
            else
                false
        if var_11 then
            let (var_12: int64) = (var_5 + 1L)
            method_2((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_12: int64))
        else
            let (var_13: bool) = (var_4 = var_2)
            let (var_15: bool) =
                if var_13 then
                    (var_5 = var_3)
                else
                    false
            if var_15 then
                let (var_16: int64) = (var_5 + 1L)
                method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_16: int64))
            else
                let (var_17: int64) = (var_5 + 1L)
                method_1((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_17: int64))
    else
        let (var_18: int64) = (var_4 + 1L)
        method_0((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_18: int64))
and method_2((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64)): unit =
    let (var_6: bool) = (var_5 < 5L)
    if var_6 then
        System.Console.Write("I am at (")
        let (var_7: string) = System.String.Format("{0}",var_4)
        System.Console.Write(var_7)
        System.Console.Write(",")
        let (var_8: string) = System.String.Format("{0}",var_5)
        System.Console.Write(var_8)
        System.Console.Write(")")
        System.Console.WriteLine()
        let (var_9: bool) = (var_4 = var_0)
        let (var_11: bool) =
            if var_9 then
                (var_5 = var_1)
            else
                false
        if var_11 then
            let (var_12: int64) = (var_5 + 1L)
            method_2((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_12: int64))
        else
            let (var_13: bool) = (var_4 = var_2)
            let (var_15: bool) =
                if var_13 then
                    (var_5 = var_3)
                else
                    false
            if var_15 then
                System.Console.Write("Success.")
                System.Console.WriteLine()
            else
                let (var_16: int64) = (var_5 + 1L)
                method_2((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_16: int64))
    else
        let (var_17: int64) = (var_4 + 1L)
        method_3((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_17: int64))
and method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64)): unit =
    let (var_6: bool) = (var_5 < 5L)
    if var_6 then
        System.Console.Write("I am at (")
        let (var_7: string) = System.String.Format("{0}",var_4)
        System.Console.Write(var_7)
        System.Console.Write(",")
        let (var_8: string) = System.String.Format("{0}",var_5)
        System.Console.Write(var_8)
        System.Console.Write(")")
        System.Console.WriteLine()
        let (var_9: bool) = (var_4 = var_0)
        let (var_11: bool) =
            if var_9 then
                (var_5 = var_1)
            else
                false
        if var_11 then
            System.Console.Write("Success.")
            System.Console.WriteLine()
        else
            let (var_12: bool) = (var_4 = var_2)
            let (var_14: bool) =
                if var_12 then
                    (var_5 = var_3)
                else
                    false
            if var_14 then
                let (var_15: int64) = (var_5 + 1L)
                method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_15: int64))
            else
                let (var_16: int64) = (var_5 + 1L)
                method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_16: int64))
    else
        let (var_17: int64) = (var_4 + 1L)
        method_5((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_17: int64))
and method_3((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 5L)
    if var_5 then
        let (var_6: int64) = 0L
        method_2((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_6: int64))
    else
        (failwith "Failure.")
and method_5((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 5L)
    if var_5 then
        let (var_6: int64) = 0L
        method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_6: int64))
    else
        (failwith "Failure.")
let (var_0: int64) = 0L
let (var_1: int64) = 0L
let (var_2: int64) = 1L
let (var_3: int64) = 1L
let (var_4: int64) = 0L
method_0((var_2: int64), (var_3: int64), (var_0: int64), (var_1: int64), (var_4: int64))

