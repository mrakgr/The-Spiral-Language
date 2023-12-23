kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
struct Card { uint8_t rank : 4; uint8_t suit : 2; };
struct Tuple0;
struct Tuple1;
uint32_t loop_1(uint32_t v0, curandStatePhilox4_32_10_t * v1);
Tuple1 draw_card_0(curandStatePhilox4_32_10_t * v0, uint64_t v1);
struct Tuple0 {
    uint64_t v1;
    int32_t v0;
    __device__ Tuple0(int32_t t0, uint64_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    Card v0;
    uint64_t v1;
    __device__ Tuple1(Card t0, uint64_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 50l;
    return v1;
}
__device__ inline bool while_method_1(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
__device__ uint32_t loop_1(uint32_t v0, curandStatePhilox4_32_10_t * v1){
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
        return loop_1(v0, v1);
    }
}
__device__ Tuple1 draw_card_0(curandStatePhilox4_32_10_t * v0, uint64_t v1){
    int32_t v2;
    v2 = __popcll(v1);
    uint32_t v3;
    v3 = (uint32_t)v2;
    uint32_t v4;
    v4 = loop_1(v3, v0);
    int32_t v5;
    v5 = (int32_t)v4;
    uint32_t v6;
    v6 = (uint32_t)v1;
    uint64_t v7;
    v7 = v1 >> 32l;
    uint32_t v8;
    v8 = (uint32_t)v7;
    int32_t v9;
    v9 = __popc(v6);
    bool v10;
    v10 = v5 < v9;
    uint32_t v17;
    if (v10){
        int32_t v11;
        v11 = v5 + 1l;
        uint32_t v12;
        v12 = __fns(v6,0ul,v11);
        v17 = v12;
    } else {
        int32_t v13;
        v13 = v5 - v9;
        int32_t v14;
        v14 = v13 + 1l;
        uint32_t v15;
        v15 = __fns(v8,0ul,v14);
        uint32_t v16;
        v16 = v15 + 32ul;
        v17 = v16;
    }
    uint8_t v18;
    v18 = (uint8_t)v17;
    uint8_t v19;
    v19 = v18 / 13u;
    uint8_t v20;
    v20 = v18 % 13u;
    Card v21;
    v21 = {v20, v19};
    int32_t v22;
    v22 = (int32_t)v17;
    uint64_t v23;
    v23 = 1ull << v22;
    uint64_t v24;
    v24 = v1 ^ v23;
    return Tuple1(v21, v24);
}
extern "C" __global__ void entry0() {
    int32_t v0;
    v0 = threadIdx.x + blockIdx.x * blockDim.x;
    uint64_t v1;
    v1 = (uint64_t)v0;
    curandStatePhilox4_32_10_t v2;
    curandStatePhilox4_32_10_t * v3 = &v2;
    curand_init(v1,0ull,0ull,v3);
    int32_t v4;
    v4 = gridDim.x * blockDim.x;
    int32_t v5;
    v5 = v0;
    while (while_method_0(v5)){
        array<Card,7l> v7;
        int32_t v8; uint64_t v9;
        Tuple0 tmp0 = Tuple0(0l, 4503599627370495ull);
        v8 = tmp0.v0; v9 = tmp0.v1;
        while (while_method_1(v8)){
            Card v11; uint64_t v12;
            Tuple1 tmp1 = draw_card_0(v3, v9);
            v11 = tmp1.v0; v12 = tmp1.v1;
            v7.v[v8] = v11;
            v9 = v12;
            v8 += 1l ;
        }
        const char * v13;
        v13 = "%s";
        const char * v14;
        v14 = "[";
        printf(v13,v14);
        int32_t v15;
        v15 = 0l;
        while (while_method_1(v15)){
            Card v17;
            v17 = v7.v[v15];
            uint8_t v18;
            v18 = v17.rank;
            bool v19;
            v19 = 12u == v18;
            char v44;
            if (v19){
                v44 = 'A';
            } else {
                bool v20;
                v20 = 11u == v18;
                if (v20){
                    v44 = 'K';
                } else {
                    bool v21;
                    v21 = 10u == v18;
                    if (v21){
                        v44 = 'Q';
                    } else {
                        bool v22;
                        v22 = 9u == v18;
                        if (v22){
                            v44 = 'J';
                        } else {
                            bool v23;
                            v23 = 8u == v18;
                            if (v23){
                                v44 = 'T';
                            } else {
                                bool v24;
                                v24 = 7u == v18;
                                if (v24){
                                    v44 = '9';
                                } else {
                                    bool v25;
                                    v25 = 6u == v18;
                                    if (v25){
                                        v44 = '8';
                                    } else {
                                        bool v26;
                                        v26 = 5u == v18;
                                        if (v26){
                                            v44 = '7';
                                        } else {
                                            bool v27;
                                            v27 = 4u == v18;
                                            if (v27){
                                                v44 = '6';
                                            } else {
                                                bool v28;
                                                v28 = 3u == v18;
                                                if (v28){
                                                    v44 = '5';
                                                } else {
                                                    bool v29;
                                                    v29 = 2u == v18;
                                                    if (v29){
                                                        v44 = '4';
                                                    } else {
                                                        bool v30;
                                                        v30 = 1u == v18;
                                                        if (v30){
                                                            v44 = '3';
                                                        } else {
                                                            bool v31;
                                                            v31 = 0u == v18;
                                                            if (v31){
                                                                v44 = '2';
                                                            } else {
                                                                v44 = '?';
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            uint8_t v45;
            v45 = v17.suit;
            bool v46;
            v46 = 3u == v45;
            char v53;
            if (v46){
                v53 = 'H';
            } else {
                bool v47;
                v47 = 2u == v45;
                if (v47){
                    v53 = 'S';
                } else {
                    bool v48;
                    v48 = 1u == v45;
                    if (v48){
                        v53 = 'C';
                    } else {
                        bool v49;
                        v49 = 0u == v45;
                        if (v49){
                            v53 = 'D';
                        } else {
                            v53 = '?';
                        }
                    }
                }
            }
            const char * v54;
            v54 = "%c";
            printf(v54,v44);
            printf(v54,v53);
            int32_t v55;
            v55 = v15 + 1l;
            bool v56;
            v56 = v55 < 7l;
            if (v56){
                const char * v57;
                v57 = ", ";
                printf(v13,v57);
            } else {
            }
            v15 += 1l ;
        }
        const char * v58;
        v58 = "]";
        printf(v13,v58);
        printf("\n");
        v5 += v4 ;
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
    v0 = 0
    raw_module.get_function(f"entry{v0}")((1, 1, 1),(1, 1, 1),())
    del v0
    return 

if __name__ == '__main__': print(main())
