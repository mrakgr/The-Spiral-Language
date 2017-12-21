module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Tuple0 =
    struct
    val mem_0: string
    val mem_1: string
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0(): string =
    "qwe joined"
and method_1(): string =
    "123 joined"
let (var_0: string) = method_0()
let (var_1: string) = method_1()
Tuple0(var_0, var_1)
