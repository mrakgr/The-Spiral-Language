module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type Env0 =
    struct
    val mem_0: Env1
    val mem_1: Env1
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env1 =
    struct
    val mem_0: Env2
    val mem_1: Env2
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env2 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
let rec method_0(): Env0 =
    (Env0((Env1((Env2(3L, 1L, 2L)), (Env2(3L, 1L, 2L)))), (Env1((Env2(3L, 1L, 2L)), (Env2(3L, 1L, 2L))))))
and method_1((var_0: Env1), (var_1: Env1)): Env0 =
    (Env0(var_0, var_1))
let (var_0: Env0) = method_0()
let (var_1: Env1) = var_0.mem_0
let (var_2: Env1) = var_0.mem_1
let (var_3: Env0) = method_1((var_1: Env1), (var_2: Env1))
let (var_4: Env1) = var_3.mem_0
let (var_5: Env1) = var_3.mem_1

