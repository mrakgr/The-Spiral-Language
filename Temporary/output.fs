module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

let rec method_0((var_0: (int64 [])), (var_1: (int64 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 8L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        var_0.[int32 var_2] <- 2L
        var_1.[int32 var_2] <- 2L
        let (var_6: int64) = (var_2 + 1L)
        method_0((var_0: (int64 [])), (var_1: (int64 [])), (var_6: int64))
    else
        ()
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_1: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_2: int64) = 0L
method_0((var_0: (int64 [])), (var_1: (int64 [])), (var_2: int64))

