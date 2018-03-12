module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type Env0 =
    struct
    val mem_0: bool
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
(Env0(naked_type (*bool*)))
