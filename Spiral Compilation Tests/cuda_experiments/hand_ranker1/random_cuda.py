kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
uint32_t loop_0(curandStatePhilox4_32_10_t * v0, uint32_t v1);
struct Tuple0;
struct Tuple0 {
    uint32_t v0;
    uint32_t v1;
    uint32_t v2;
    __device__ Tuple0(uint32_t t0, uint32_t t1, uint32_t t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple0() = default;
};
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 16448l;
    return v1;
}
__device__ uint32_t loop_0(curandStatePhilox4_32_10_t * v0, uint32_t v1){
    uint32_t v2;
    v2 = curand(v0);
    uint32_t v3;
    v3 = v2 % v1;
    uint32_t v4;
    v4 = v2 - v3;
    uint32_t v5;
    v5 = 0ul - v1;
    bool v6;
    v6 = v4 <= v5;
    if (v6){
        return v3;
    } else {
        return loop_0(v0, v1);
    }
}
__device__ inline bool while_method_1(uint32_t v0){
    bool v1;
    v1 = v0 < 64ul;
    return v1;
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
        v8 = curand(v4);
        uint64_t v9;
        v9 = (uint64_t)v8;
        uint64_t v10;
        v10 = v9 << 32l;
        uint32_t v11;
        v11 = curand(v4);
        uint64_t v12;
        v12 = (uint64_t)v11;
        uint64_t v13;
        v13 = v10 | v12;
        uint64_t v14;
        v14 = __popcll(v13);
        bool v15;
        v15 = v14 > 0ull;
        uint32_t v48;
        if (v15){
            uint64_t v16;
            v16 = __popcll(v13);
            uint32_t v17;
            v17 = (uint32_t)v16;
            uint32_t v18;
            v18 = loop_0(v4, v17);
            uint32_t v19;
            v19 = (uint32_t)v13;
            uint64_t v20;
            v20 = v13 >> 32l;
            uint32_t v21;
            v21 = (uint32_t)v20;
            uint32_t v22;
            v22 = __popc(v19);
            bool v23;
            v23 = v18 < v22;
            uint32_t v32;
            if (v23){
                int32_t v24;
                v24 = (int32_t)v18;
                int32_t v25;
                v25 = v24 + 1l;
                uint32_t v26;
                v26 = __fns(v19,0ul,v25);
                v32 = v26;
            } else {
                uint32_t v27;
                v27 = v18 - v22;
                int32_t v28;
                v28 = (int32_t)v27;
                int32_t v29;
                v29 = v28 + 1l;
                uint32_t v30;
                v30 = __fns(v21,0ul,v29);
                uint32_t v31;
                v31 = v30 + 32ul;
                v32 = v31;
            }
            uint32_t v33;
            v33 = v18 + 1ul;
            uint32_t v34; uint32_t v35; uint32_t v36;
            Tuple0 tmp0 = Tuple0(0ul, 0ul, v33);
            v34 = tmp0.v0; v35 = tmp0.v1; v36 = tmp0.v2;
            while (while_method_1(v34)){
                bool v38;
                v38 = v36 > 0ul;
                uint32_t v45; uint32_t v46;
                if (v38){
                    int32_t v39;
                    v39 = (int32_t)v34;
                    uint64_t v40;
                    v40 = 1ull << v39;
                    uint64_t v41;
                    v41 = v13 & v40;
                    bool v42;
                    v42 = v41 == 0ull;
                    uint32_t v44;
                    if (v42){
                        v44 = v36;
                    } else {
                        uint32_t v43;
                        v43 = v36 - 1ul;
                        v44 = v43;
                    }
                    v45 = v34; v46 = v44;
                } else {
                    v45 = v35; v46 = v36;
                }
                v35 = v45;
                v36 = v46;
                v34 += 1ul ;
            }
            uint32_t v47;
            v47 = v32 - v35;
            v48 = v47;
        } else {
            v48 = 0ul;
        }
        v0[v6] = v48;
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
    v0 = cp.empty(16448,dtype=cp.uint32)
    v1 = 0
    raw_module.get_function(f"entry{v1}")((8255, 1, 1),(64, 1, 1),v0)
    del v1
    print(cp.sum(v0))
    del v0
    return 

if __name__ == '__main__': print(main())
