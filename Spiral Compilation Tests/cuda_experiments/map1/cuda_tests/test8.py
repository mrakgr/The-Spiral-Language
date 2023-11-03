kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
__device__ inline bool while_method_0(int64_t v0, int64_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, int64_t v1) {
    int64_t v2;
    v2 = threadIdx.x + blockIdx.x * blockDim.x;
    int64_t v3;
    v3 = gridDim.x * blockDim.x;
    int64_t v4;
    v4 = v2;
    while (while_method_0(v1, v4)){
        float v6;
        v6 = v0[v4];
        float v7;
        v7 = 100.0f + v6;
        v0[v4] = v7;
        v4 += v3 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = cp.array([1.0, 2.0, 3.0, 4.0, 5.0],dtype=cp.float32)
    v1 = len(v0)
    v2 = 0
    v3 = cp.RawModule(code=kernel, backend="nvcc")
    v3.get_function(f"entry{v2}")((4,),(128,),(v0, v1))
    del v1, v2, v3
    return v0

if __name__ == '__main__': print(main())
