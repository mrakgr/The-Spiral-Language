module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

let rec method_0((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 10L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_5: int64) = (var_1 * 10L)
        let (var_6: int64) = 0L
        method_1((var_1: int64), (var_0: (int64 [])), (var_5: int64), (var_6: int64))
        let (var_7: int64) = (var_1 + 1L)
        method_0((var_0: (int64 [])), (var_7: int64))
    else
        ()
and method_1((var_0: int64), (var_1: (int64 [])), (var_2: int64), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < 10L)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_2 + var_3)
        let (var_8: int64) = (var_0 * var_3)
        var_1.[int32 var_7] <- var_8
        let (var_9: int64) = (var_3 + 1L)
        method_1((var_0: int64), (var_1: (int64 [])), (var_2: int64), (var_9: int64))
    else
        ()
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(100L))
let (var_1: int64) = 0L
method_0((var_0: (int64 [])), (var_1: int64))
let (var_2: int64) = var_0.[int32 22L]
let (var_3: int64) = (var_2 + 100L)
var_0.[int32 22L] <- var_3
var_0.[int32 22L]
