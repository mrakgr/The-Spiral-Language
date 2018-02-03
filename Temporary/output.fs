module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

let rec method_0((var_0: (uint8 [])), (var_1: (char [])), (var_2: int64), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < var_2)
    if var_4 then
        let (var_5: char) = var_1.[int32 var_3]
        let (var_6: int64) = (int64 var_5)
        let (var_7: bool) = (var_6 < 128L)
        let (var_8: bool) = (var_7 = false)
        if var_8 then
            (failwith "The inputs need to be in the [0,127] range.")
        else
            ()
        var_0.[int32 var_3] <- (uint8 var_6)
        let (var_9: int64) = (var_3 + 1L)
        method_0((var_0: (uint8 [])), (var_1: (char [])), (var_2: int64), (var_9: int64))
    else
        ()
let (var_1: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()
let (var_2: int64) = var_1.LongLength
let (var_3: bool) = (var_2 >= 0L)
let (var_4: bool) = (var_3 = false)
if var_4 then
    (failwith "The input to init needs to be greater or equal to 0.")
else
    ()
let (var_9: (uint8 [])) = Array.zeroCreate<uint8> (System.Convert.ToInt32(var_2))
let (var_10: int64) = 0L
method_0((var_9: (uint8 [])), (var_1: (char [])), (var_2: int64), (var_10: int64))
let (var_11: int64) = var_9.LongLength
let (var_12: bool) = (var_11 > 0L)
let (var_13: bool) = (var_12 = false)
if var_13 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_14: bool) = (var_11 = 1115394L)
let (var_15: bool) = (var_14 = false)
if var_15 then
    (failwith "The dimensions must match.")
else
    ()
1114112L
