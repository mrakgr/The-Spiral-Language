module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env1 =
    struct
    val mem_0: (uint8 [])
    val mem_1: Tuple0
    val mem_2: Tuple0
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Env2 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple3 =
    struct
    val mem_0: Env2
    val mem_1: Env2
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env4 =
    struct
    val mem_0: Env1
    val mem_1: Tuple3
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env5 =
    struct
    val mem_0: Env4
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
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
    (failwith "The dimensions do not match.")
else
    ()
let (var_16: bool) = (1115394L = var_11)
let (var_17: bool) = (var_16 = false)
if var_17 then
    (failwith "The product of dimensions of the new tensor must equal that of the previous one.")
else
    ()
(Env5((Env4((Env1(var_9, Tuple0(0L, 0L), Tuple0(8714L, 1L))), Tuple3((Env2(0L, 128L)), (Env2(0L, 8714L)))))))
1115392 / 128