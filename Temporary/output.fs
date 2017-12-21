module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
let rec method_3((var_0: ((((string []) []) []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_8: (((string []) []) [])) = Array.zeroCreate<((string []) [])> (System.Convert.ToInt32(4L))
        let (var_9: int64) = 0L
        method_2((var_8: (((string []) []) [])), (var_9: int64))
        var_0.[int32 var_1] <- var_8
        method_3((var_0: ((((string []) []) []) [])), (var_3: int64))
    else
        ()
and method_4((var_0: ((((string []) []) []) [])), (var_1: int64), (var_2: int64)): Tuple0 =
    let (var_3: bool) = (var_2 < var_1)
    if var_3 then
        let (var_4: (((string []) []) [])) = var_0.[int32 var_2]
        let (var_5: int64) = var_4.LongLength
        let (var_6: int64) = 0L
        method_5((var_4: (((string []) []) [])), (var_2: int64), (var_5: int64), (var_0: ((((string []) []) []) [])), (var_1: int64), (var_6: int64))
    else
        (failwith "The princess is in another castle.")
and method_2((var_0: (((string []) []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_6: ((string []) [])) = Array.zeroCreate<(string [])> (System.Convert.ToInt32(4L))
        let (var_7: int64) = 0L
        method_1((var_6: ((string []) [])), (var_7: int64))
        var_0.[int32 var_1] <- var_6
        method_2((var_0: (((string []) []) [])), (var_3: int64))
    else
        ()
and method_5((var_0: (((string []) []) [])), (var_1: int64), (var_2: int64), (var_3: ((((string []) []) []) [])), (var_4: int64), (var_5: int64)): Tuple0 =
    let (var_6: bool) = (var_5 < var_2)
    if var_6 then
        let (var_7: ((string []) [])) = var_0.[int32 var_5]
        let (var_8: int64) = var_7.LongLength
        let (var_9: int64) = 0L
        method_6((var_7: ((string []) [])), (var_5: int64), (var_1: int64), (var_8: int64), (var_0: (((string []) []) [])), (var_2: int64), (var_3: ((((string []) []) []) [])), (var_4: int64), (var_9: int64))
    else
        let (var_11: int64) = (var_1 + 1L)
        method_4((var_3: ((((string []) []) []) [])), (var_4: int64), (var_11: int64))
and method_1((var_0: ((string []) [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        let (var_4: (string [])) = Array.zeroCreate<string> (System.Convert.ToInt32(4L))
        let (var_5: int64) = 0L
        method_0((var_4: (string [])), (var_5: int64))
        var_0.[int32 var_1] <- var_4
        method_1((var_0: ((string []) [])), (var_3: int64))
    else
        ()
and method_6((var_0: ((string []) [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: (((string []) []) [])), (var_5: int64), (var_6: ((((string []) []) []) [])), (var_7: int64), (var_8: int64)): Tuple0 =
    let (var_9: bool) = (var_8 < var_3)
    if var_9 then
        let (var_10: (string [])) = var_0.[int32 var_8]
        let (var_11: int64) = var_10.LongLength
        let (var_12: int64) = 0L
        method_7((var_10: (string [])), (var_8: int64), (var_1: int64), (var_2: int64), (var_11: int64), (var_0: ((string []) [])), (var_3: int64), (var_4: (((string []) []) [])), (var_5: int64), (var_6: ((((string []) []) []) [])), (var_7: int64), (var_12: int64))
    else
        let (var_14: int64) = (var_1 + 1L)
        method_5((var_4: (((string []) []) [])), (var_2: int64), (var_5: int64), (var_6: ((((string []) []) []) [])), (var_7: int64), (var_14: int64))
and method_0((var_0: (string [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        var_0.[int32 var_1] <- ""
        method_0((var_0: (string [])), (var_3: int64))
    else
        ()
and method_7((var_0: (string [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: ((string []) [])), (var_6: int64), (var_7: (((string []) []) [])), (var_8: int64), (var_9: ((((string []) []) []) [])), (var_10: int64), (var_11: int64)): Tuple0 =
    let (var_12: bool) = (var_11 < var_4)
    if var_12 then
        let (var_13: string) = var_0.[int32 var_11]
        let (var_14: bool) = (var_13 = "princess")
        if var_14 then
            Tuple0(var_3, var_2, var_1, var_11)
        else
            let (var_15: int64) = (var_11 + 1L)
            method_7((var_0: (string [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: ((string []) [])), (var_6: int64), (var_7: (((string []) []) [])), (var_8: int64), (var_9: ((((string []) []) []) [])), (var_10: int64), (var_15: int64))
    else
        let (var_18: int64) = (var_1 + 1L)
        method_6((var_5: ((string []) [])), (var_2: int64), (var_3: int64), (var_6: int64), (var_7: (((string []) []) [])), (var_8: int64), (var_9: ((((string []) []) []) [])), (var_10: int64), (var_18: int64))
let (var_6: ((((string []) []) []) [])) = Array.zeroCreate<(((string []) []) [])> (System.Convert.ToInt32(4L))
let (var_7: int64) = 0L
method_3((var_6: ((((string []) []) []) [])), (var_7: int64))
let (var_8: (((string []) []) [])) = var_6.[int32 0L]
let (var_9: ((string []) [])) = var_8.[int32 0L]
let (var_10: (string [])) = var_9.[int32 0L]
var_10.[int32 2L] <- "princess"
let (var_11: int64) = var_6.LongLength
let (var_12: int64) = 0L
method_4((var_6: ((((string []) []) []) [])), (var_11: int64), (var_12: int64))
