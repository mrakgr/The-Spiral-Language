module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

let rec method_0((var_0: (int64 [])), (var_1: (int64 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 32L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = 0L
        method_1((var_2: int64), (var_0: (int64 [])), (var_1: (int64 [])), (var_6: int64))
        let (var_7: int64) = (var_2 + 1L)
        method_0((var_0: (int64 [])), (var_1: (int64 [])), (var_7: int64))
    else
        ()
and method_2((var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
    let (var_12: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_13: string) = ""
    let (var_14: int64) = 0L
    let (var_15: int64) = 0L
    method_3((var_12: System.Text.StringBuilder), (var_15: int64))
    let (var_16: System.Text.StringBuilder) = var_12.AppendLine("[|")
    let (var_17: int64) = method_4((var_12: System.Text.StringBuilder), (var_13: string), (var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_14: int64))
    let (var_18: int64) = 0L
    method_3((var_12: System.Text.StringBuilder), (var_18: int64))
    let (var_19: System.Text.StringBuilder) = var_12.AppendLine("|]")
    let (var_20: string) = var_12.ToString()
    let (var_21: string) = System.String.Format("{0}",var_20)
    System.Console.WriteLine(var_21)
and method_1((var_0: int64), (var_1: (int64 [])), (var_2: (int64 [])), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < 1L)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_0 + var_3)
        var_1.[int32 var_7] <- var_0
        var_2.[int32 var_7] <- var_3
        let (var_8: int64) = (var_3 + 1L)
        method_1((var_0: int64), (var_1: (int64 [])), (var_2: (int64 [])), (var_8: int64))
    else
        ()
and method_3((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_3((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_4((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64)): int64 =
    let (var_15: bool) = (var_10 < var_11)
    if var_15 then
        let (var_16: bool) = (var_14 < 1000L)
        if var_16 then
            let (var_17: bool) = (var_10 >= var_10)
            let (var_18: bool) = (var_17 = false)
            if var_18 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_19: int64) = 0L
            method_5((var_0: System.Text.StringBuilder), (var_19: int64))
            let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_21: int64) = method_6((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_3: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_9: int64), (var_12: int64), (var_13: int64), (var_1: string), (var_14: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_23: int64) = (var_10 + 1L)
            method_8((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_21: int64), (var_23: int64))
        else
            let (var_25: int64) = 0L
            method_3((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_14
    else
        var_14
and method_5((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_5((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_6((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64)): int64 =
    let (var_11: bool) = (var_7 < var_8)
    if var_11 then
        let (var_12: string) = System.String.Format("{0}",var_7)
        System.Console.WriteLine(var_12)
        let (var_13: bool) = (var_10 < 1000L)
        if var_13 then
            let (var_14: System.Text.StringBuilder) = var_0.Append(var_9)
            let (var_15: bool) = (var_7 >= var_7)
            let (var_16: bool) = (var_15 = false)
            if var_16 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_17: int64) = var_1.[int32 var_2]
            let (var_18: int64) = var_4.[int32 var_5]
            let (var_19: string) = System.String.Format("{0}",var_18)
            let (var_20: string) = System.String.Format("{0}",var_17)
            let (var_21: string) = String.concat ", " [|var_20; var_19|]
            let (var_22: string) = System.String.Format("[{0}]",var_21)
            let (var_23: System.Text.StringBuilder) = var_0.Append(var_22)
            let (var_24: string) = "; "
            let (var_25: int64) = (var_10 + 1L)
            let (var_26: int64) = (var_7 + 1L)
            method_7((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_24: string), (var_25: int64), (var_26: int64))
        else
            let (var_28: System.Text.StringBuilder) = var_0.Append("...")
            var_10
    else
        var_10
and method_8((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64)): int64 =
    let (var_16: bool) = (var_15 < var_11)
    if var_16 then
        let (var_17: bool) = (var_14 < 1000L)
        if var_17 then
            let (var_18: bool) = (var_15 >= var_10)
            let (var_19: bool) = (var_18 = false)
            if var_19 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_20: int64) = (var_15 - var_10)
            let (var_21: int64) = (var_20 * var_4)
            let (var_22: int64) = (var_3 + var_21)
            let (var_23: int64) = (var_20 * var_8)
            let (var_24: int64) = (var_7 + var_23)
            let (var_25: int64) = 0L
            method_5((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_27: int64) = method_6((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_22: int64), (var_5: int64), (var_6: (int64 [])), (var_24: int64), (var_9: int64), (var_12: int64), (var_13: int64), (var_1: string), (var_14: int64))
            let (var_28: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_29: int64) = (var_15 + 1L)
            method_8((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_27: int64), (var_29: int64))
        else
            let (var_31: int64) = 0L
            method_3((var_0: System.Text.StringBuilder), (var_31: int64))
            let (var_32: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_14
    else
        var_14
and method_7((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64), (var_11: int64)): int64 =
    let (var_12: bool) = (var_11 < var_8)
    if var_12 then
        let (var_13: string) = System.String.Format("{0}",var_11)
        System.Console.WriteLine(var_13)
        let (var_14: bool) = (var_10 < 1000L)
        if var_14 then
            let (var_15: System.Text.StringBuilder) = var_0.Append(var_9)
            let (var_16: bool) = (var_11 >= var_7)
            let (var_17: bool) = (var_16 = false)
            if var_17 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_18: int64) = (var_11 - var_7)
            let (var_19: int64) = (var_18 * var_3)
            let (var_20: int64) = (var_2 + var_19)
            let (var_21: int64) = (var_18 * var_6)
            let (var_22: int64) = (var_5 + var_21)
            let (var_23: int64) = var_1.[int32 var_20]
            let (var_24: int64) = var_4.[int32 var_22]
            let (var_25: string) = System.String.Format("{0}",var_24)
            let (var_26: string) = System.String.Format("{0}",var_23)
            let (var_27: string) = String.concat ", " [|var_26; var_25|]
            let (var_28: string) = System.String.Format("[{0}]",var_27)
            let (var_29: System.Text.StringBuilder) = var_0.Append(var_28)
            let (var_30: string) = "; "
            let (var_31: int64) = (var_10 + 1L)
            let (var_32: int64) = (var_11 + 1L)
            method_7((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_30: string), (var_31: int64), (var_32: int64))
        else
            let (var_34: System.Text.StringBuilder) = var_0.Append("...")
            var_10
    else
        var_10
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(32L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(32L))
let (var_2: int64) = 0L
method_0((var_0: (int64 [])), (var_1: (int64 [])), (var_2: int64))
let (var_3: int64) = 0L
let (var_4: int64) = 1L
let (var_5: int64) = 1L
let (var_6: int64) = 0L
let (var_7: int64) = 1L
let (var_8: int64) = 1L
let (var_9: int64) = 0L
let (var_10: int64) = 32L
let (var_11: int64) = 0L
let (var_12: int64) = 1L
method_2((var_0: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_1: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64))

