module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

let (var_0: int64) = 123L
let (var_1: bool) = (var_0 = 1L)
if var_1 then
    var_0
else
    let (var_2: bool) = (var_0 = 2L)
    if var_2 then
        var_0
    else
        3L

