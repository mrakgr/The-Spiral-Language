module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: string
    val mem_2: float32
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
let (var_0: (Tuple0 [])) = Array.zeroCreate<Tuple0> (System.Convert.ToInt32(250L))
var_0.[int32 69L] <- Tuple0(1L, "asd", 3.300000f)

