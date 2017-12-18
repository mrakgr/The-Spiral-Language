module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Env0 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let (var_0: bool) = true
if var_0 then
    let (var_1: int64) = 1L
    let (var_2: int64) = 2L
    (Env0(var_1, var_2))
else
    let (var_3: int64) = 3L
    let (var_4: int64) = 4L
    (Env0(var_3, var_4))

