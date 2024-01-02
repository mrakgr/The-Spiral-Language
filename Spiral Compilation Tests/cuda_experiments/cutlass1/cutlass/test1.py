kernel = r"""
#include <cutlass/cutlass.h>
extern "C" __global__ void entry0() {
    return ;
}
"""
import cupy as cp

raw_module = cp.RawModule(code=kernel, backend='nvcc', options=("-I G:/cutlass-3.3.0/include",))
raw_module.get_function("entry0")((1, 1, 1),(1, 1, 1),())
