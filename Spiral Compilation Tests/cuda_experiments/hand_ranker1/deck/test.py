kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
struct Tuple0;
uint32_t loop_0(uint32_t v0, curandStatePhilox4_32_10_t * v1);
struct Tuple0 {
    uint64_t v1;
    int32_t v0;
    __device__ Tuple0(int32_t t0, uint64_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 52l;
    return v1;
}
__device__ uint32_t loop_0(uint32_t v0, curandStatePhilox4_32_10_t * v1){
    uint32_t v2;
    v2 = curand(v1);
    uint32_t v3;
    v3 = v2 % v0;
    uint32_t v4;
    v4 = v2 - v3;
    uint32_t v5;
    v5 = 0ul - v0;
    bool v6;
    v6 = v4 <= v5;
    if (v6){
        return v3;
    } else {
        return loop_0(v0, v1);
    }
}
extern "C" __global__ void entry0(uint32_t * v0) {
    int32_t v1;
    v1 = threadIdx.x + blockIdx.x * blockDim.x;
    printf("lid: %d\n", v1);
    uint64_t v2;
    v2 = (uint64_t)v1;
    curandStatePhilox4_32_10_t v3;
    curandStatePhilox4_32_10_t * v4 = &v3;
    curand_init(v2,0ull,0ull,v4);
    int32_t v5;
    v5 = gridDim.x * blockDim.x;
    int32_t v6; uint64_t v7;
    Tuple0 tmp0 = Tuple0(v1, 4503599627370495ull);
    v6 = tmp0.v0; v7 = tmp0.v1;
    while (while_method_0(v6)){
        int32_t v9;
        v9 = __popcll(v7);
        printf("%d\n", v9);
        int32_t v10;
        v10 = __popcll(v7);
        uint32_t v11;
        v11 = (uint32_t)v10;
        uint32_t v12;
        v12 = loop_0(v11, v4);
        int32_t v13;
        v13 = (int32_t)v12;
        uint32_t v14;
        v14 = (uint32_t)v7;
        uint64_t v15;
        v15 = v7 >> 32l;
        uint32_t v16;
        v16 = (uint32_t)v15;
        int32_t v17;
        v17 = __popc(v14);
        bool v18;
        v18 = v13 < v17;
        uint32_t v25;
        if (v18){
            int32_t v19;
            v19 = v13 + 1l;
            uint32_t v20;
            v20 = __fns(v14,0ul,v19);
            v25 = v20;
        } else {
            int32_t v21;
            v21 = v13 - v17;
            int32_t v22;
            v22 = v21 + 1l;
            uint32_t v23;
            v23 = __fns(v16,0ul,v22);
            uint32_t v24;
            v24 = v23 + 32ul;
            v25 = v24;
        }
        int32_t v26;
        v26 = (int32_t)v25;
        uint64_t v27;
        v27 = 1ull << v26;
        uint64_t v28;
        v28 = v7 ^ v27;
        v0[v6] = v25;
        v7 = v28;
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
    v0 = cp.empty(52,dtype=cp.uint32)
    v1 = 0
    raw_module.get_function(f"entry{v1}")((1, 1, 1),(1, 1, 1),v0)
    del v1
    print(v0.sum())
    print(cp.arange(0,52).sum())
    return v0, 52

if __name__ == '__main__': print(main())
