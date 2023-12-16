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
    bool v3;
    v3 = v2 >= v1;
    if (v3){
        return v2;
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
        uint32_t v47;
        if (v15){
            uint64_t v16;
            v16 = __popcll(v13);
            uint32_t v17;
            v17 = (uint32_t)v16;
            uint32_t v18;
            v18 = 0ul - v17;
            uint32_t v19;
            v19 = v18 % v17;
            uint32_t v20;
            v20 = loop_0(v4, v19);
            uint32_t v21;
            v21 = v20 % v17;
            uint32_t v22;
            v22 = (uint32_t)v13;
            uint64_t v23;
            v23 = v13 >> 32l;
            uint32_t v24;
            v24 = (uint32_t)v23;
            uint32_t v25;
            v25 = __popc(v22);
            bool v26;
            v26 = v21 < v25;
            uint32_t v31;
            if (v26){
                uint32_t v27;
                v27 = __fns(v22,0,v21+1);
                v31 = v27;
            } else {
                uint32_t v28;
                v28 = v21 - v25;
                uint32_t v29;
                v29 = __fns(v24,0,v28+1);
                uint32_t v30;
                v30 = v29 + 32ul;
                v31 = v30;
            }
            uint32_t v32;
            v32 = v21 + 1ul;
            uint32_t v33; uint32_t v34; uint32_t v35;
            Tuple0 tmp0 = Tuple0(0ul, 0ul, v32);
            v33 = tmp0.v0; v34 = tmp0.v1; v35 = tmp0.v2;
            while (while_method_1(v33)){
                bool v37;
                v37 = v35 > 0ul;
                uint32_t v44; uint32_t v45;
                if (v37){
                    int32_t v38;
                    v38 = (int32_t)v33;
                    uint64_t v39;
                    v39 = 1ull << v38;
                    uint64_t v40;
                    v40 = v13 & v39;
                    bool v41;
                    v41 = v40 == 0ull;
                    uint32_t v43;
                    if (v41){
                        v43 = v35;
                    } else {
                        uint32_t v42;
                        v42 = v35 - 1ul;
                        v43 = v42;
                    }
                    v44 = v33; v45 = v43;
                } else {
                    v44 = v34; v45 = v35;
                }
                v34 = v44;
                v35 = v45;
                v33 += 1ul ;
            }
            uint32_t v46;
            v46 = v31 - v34;
            v47 = v46;
        } else {
            v47 = 0ul;
        }
        v0[v6] = v47;
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
