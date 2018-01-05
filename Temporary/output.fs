module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

let rec method_0((var_0: (string [])), (var_1: (string [])), (var_2: (int64 [])), (var_3: (int64 [])), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 3L)
    if var_5 then
        let (var_6: bool) = (var_4 >= 0L)
        let (var_7: bool) = (var_6 = false)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: int64) = (var_4 * 20L)
        let (var_9: string) = var_0.[int32 var_4]
        let (var_10: int64) = 0L
        method_1((var_9: string), (var_1: (string [])), (var_8: int64), (var_2: (int64 [])), (var_3: (int64 [])), (var_10: int64))
        let (var_11: int64) = (var_4 + 1L)
        method_0((var_0: (string [])), (var_1: (string [])), (var_2: (int64 [])), (var_3: (int64 [])), (var_11: int64))
    else
        ()
and method_1((var_0: string), (var_1: (string [])), (var_2: int64), (var_3: (int64 [])), (var_4: (int64 [])), (var_5: int64)): unit =
    let (var_6: bool) = (var_5 < 5L)
    if var_6 then
        let (var_7: bool) = (var_5 >= 0L)
        let (var_8: bool) = (var_7 = false)
        if var_8 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_9: int64) = (var_5 * 4L)
        let (var_10: int64) = (var_2 + var_9)
        let (var_11: int64) = 2L
        method_2((var_5: int64), (var_0: string), (var_1: (string [])), (var_10: int64), (var_3: (int64 [])), (var_4: (int64 [])), (var_11: int64))
        let (var_12: int64) = (var_5 + 1L)
        method_1((var_0: string), (var_1: (string [])), (var_2: int64), (var_3: (int64 [])), (var_4: (int64 [])), (var_12: int64))
    else
        ()
and method_2((var_0: int64), (var_1: string), (var_2: (string [])), (var_3: int64), (var_4: (int64 [])), (var_5: (int64 [])), (var_6: int64)): unit =
    let (var_7: bool) = (var_6 < 6L)
    if var_7 then
        let (var_8: bool) = (var_6 >= 2L)
        let (var_9: bool) = (var_8 = false)
        if var_9 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_10: int64) = (var_6 - 2L)
        let (var_11: int64) = (var_3 + var_10)
        var_2.[int32 var_11] <- var_1
        var_4.[int32 var_11] <- var_0
        var_5.[int32 var_11] <- var_6
        let (var_12: int64) = (var_6 + 1L)
        method_2((var_0: int64), (var_1: string), (var_2: (string [])), (var_3: int64), (var_4: (int64 [])), (var_5: (int64 [])), (var_12: int64))
    else
        ()
let (var_0: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(3L))
var_0.[int32 0L] <- "zero"
var_0.[int32 1L] <- "one"
var_0.[int32 2L] <- "two"
let (var_2: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(60L))
let (var_3: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(60L))
let (var_4: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(60L))
let (var_5: int64) = 0L
method_0((var_0: (string [])), (var_2: (string [])), (var_3: (int64 [])), (var_4: (int64 [])), (var_5: int64))
let (var_6: string) = var_2.[int32 0L]
let (var_7: int64) = var_3.[int32 0L]
let (var_8: int64) = var_4.[int32 0L]
let (var_9: string) = System.String.Format("{0}",var_8)
let (var_10: string) = System.String.Format("{0}",var_7)
let (var_11: string) = System.String.Format("{0}",var_6)
let (var_12: string) = String.concat ", " [|var_11; var_10; var_9|]
let (var_13: string) = System.String.Format("[{0}]",var_12)
System.Console.WriteLine(var_13)
let (var_14: string) = var_2.[int32 20L]
let (var_15: int64) = var_3.[int32 20L]
let (var_16: int64) = var_4.[int32 20L]
let (var_17: string) = System.String.Format("{0}",var_16)
let (var_18: string) = System.String.Format("{0}",var_15)
let (var_19: string) = System.String.Format("{0}",var_14)
let (var_20: string) = String.concat ", " [|var_19; var_18; var_17|]
let (var_21: string) = System.String.Format("[{0}]",var_20)
System.Console.WriteLine(var_21)
let (var_22: string) = var_2.[int32 40L]
let (var_23: int64) = var_3.[int32 40L]
let (var_24: int64) = var_4.[int32 40L]
let (var_25: string) = System.String.Format("{0}",var_24)
let (var_26: string) = System.String.Format("{0}",var_23)
let (var_27: string) = System.String.Format("{0}",var_22)
let (var_28: string) = String.concat ", " [|var_27; var_26; var_25|]
let (var_29: string) = System.String.Format("[{0}]",var_28)
System.Console.WriteLine(var_29)

