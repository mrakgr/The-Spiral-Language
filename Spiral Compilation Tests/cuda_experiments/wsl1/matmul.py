kernel = r"""
#include <cublasdx.hpp>
extern "C" __global__ void entry0() {
    return ;
}
"""
import cupy as cp

raw_module = cp.RawModule(code=kernel, backend='nvcc', options=("-std=c++20", "-I /home/mrakgr/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/include", "-I /home/mrakgr/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/include/cublasdx/include", "-I /home/mrakgr/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/external/cutlass/include"))
raw_module.get_function("entry0")((1, 1, 1),(1, 1, 1),())

