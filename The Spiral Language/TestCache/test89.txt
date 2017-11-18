module SpiralExample.Main
let cuda_kernels = """
extern "C" {
    
}
"""

type EnvStack0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap1 =
    {
    mem_0: int64
    mem_1: int64
    }
and Env2 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: int64) = 1L
let (var_1: int64) = 2L
let (var_2: EnvStack0) = EnvStack0((var_0: int64), (var_1: int64))
let (var_3: int64) = var_2.mem_0
let (var_4: int64) = var_2.mem_1
let (var_5: EnvHeap1) = ({mem_0 = (var_3: int64); mem_1 = (var_4: int64)} : EnvHeap1)
let (var_6: int64) = var_5.mem_0
let (var_7: int64) = var_5.mem_1
(Env2(var_6, var_7))
