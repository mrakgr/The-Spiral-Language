kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
uint32_t loop_0(curandStatePhilox4_32_10_t * v0);
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 512l;
    return v1;
}
__device__ uint32_t loop_0(curandStatePhilox4_32_10_t * v0){
    uint32_t v1;
    v1 = curand(v0);
    bool v2;
    v2 = v1 >= 48ul;
    if (v2){
        return v1;
    } else {
        return loop_0(v0);
    }
}
extern "C" __global__ void entry0(uint32_t * v0) {
    int32_t v1;
    v1 = threadIdx.x + blockIdx.x * blockDim.x;
    uint64_t v2;
    v2 = (uint64_t)v1;
    curandStatePhilox4_32_10_t v3;
    curandStatePhilox4_32_10_t * v4 = &v3;
    curand_init(v2,0ull,0ull,v4);
    int32_t v5;
    v5 = gridDim.x * blockDim.x;
    int32_t v6;
    v6 = v1;
    while (while_method_0(v6)){
        uint32_t v8;
        v8 = loop_0(v4);
        uint32_t v9;
        v9 = v8 % 52ul;
        v0[v6] = v9;
        v6 += v5 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

raw_module = cp.RawModule(code=kernel, backend="nvcc")
def main():
    v0 = cp.empty(512,dtype=cp.uint32)
    v1 = 0
    raw_module.get_function(f"entry{v1}")((263, 1, 1),(16, 1, 1),v0)
    del v1
    return v0, 512

if __name__ == '__main__': print(main())
