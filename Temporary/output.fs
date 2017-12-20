module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

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
and method_0((var_0: (string [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: int64) = (var_1 + 1L)
        var_0.[int32 var_1] <- ""
        method_0((var_0: (string [])), (var_3: int64))
    else
        ()
let (var_6: ((((string []) []) []) [])) = Array.zeroCreate<(((string []) []) [])> (System.Convert.ToInt32(4L))
let (var_7: int64) = 0L
method_3((var_6: ((((string []) []) []) [])), (var_7: int64))
let (var_8: (((string []) []) [])) = var_6.[int32 0L]
let (var_9: ((string []) [])) = var_8.[int32 0L]
let (var_10: (string [])) = var_9.[int32 0L]
var_10.[int32 2L] <- "princess"

