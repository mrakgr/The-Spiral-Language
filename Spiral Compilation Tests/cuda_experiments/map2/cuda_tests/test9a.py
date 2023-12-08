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
extern "C" __global__ void entry0(float * v0, float * v1, int64_t v2) {
    int64_t v3;
    v3 = threadIdx.x + blockIdx.x * blockDim.x;
    int64_t v4;
    v4 = gridDim.x * blockDim.x;
    int64_t v5;
    v5 = v3;
    while (while_method_0(v2, v5)){
        float v7;
        v7 = v0[v5];
        float v8;
        v8 = 100.0f + v7;
        v1[v5] = v8;
        v5 += v4 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = cp.array([1.0, 2.0, 3.0, 4.0, 5.0, 6.0],dtype=cp.float32)
    v1 = len(v0)
    v2 = cp.empty(v1,dtype=cp.float32)
    v3 = 0
    v4 = cp.RawModule(code=kernel, backend="nvcc")
    v4.get_function(f"entry{v3}")((4,),(128,),(v0, v2, v1))
    del v0, v1, v3, v4
    return v2

if __name__ == '__main__': print(main())
