kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
struct US0;
struct Tuple0;
__device__ long loop_2(array<float,3l> v0, float v1, long v2);
__device__ long sample_discrete__1(array<float,3l> v0, curandStatePhilox4_32_10_t * v1);
__device__ US0 sample_discrete_0(array<Tuple0,3l> v0, curandStatePhilox4_32_10_t * v1);
struct US0 {
    union {
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    US0 v0;
    float v1;
    __device__ Tuple0(US0 t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
__device__ US0 US0_0() { // Paper
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1() { // Rock
    US0 x;
    x.tag = 1;
    return x;
}
__device__ US0 US0_2() { // Scissors
    US0 x;
    x.tag = 2;
    return x;
}
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
__device__ inline bool while_method_1(array<float,3l> v0, long v1){
    bool v2;
    v2 = v1 < 3l;
    return v2;
}
__device__ inline bool while_method_2(long v0, long v1){
    bool v2;
    v2 = v1 > v0;
    return v2;
}
__device__ long loop_2(array<float,3l> v0, float v1, long v2){
    bool v3;
    v3 = v2 < 3l;
    if (v3){
        float v4;
        v4 = v0.v[v2];
        bool v5;
        v5 = v1 <= v4;
        if (v5){
            return v2;
        } else {
            long v6;
            v6 = v2 + 1l;
            return loop_2(v0, v1, v6);
        }
    } else {
        return 2l;
    }
}
__device__ long sample_discrete__1(array<float,3l> v0, curandStatePhilox4_32_10_t * v1){
    array<float,3l> v2;
    long v3;
    v3 = 0l;
    while (while_method_0(v3)){
        float v5;
        v5 = v0.v[v3];
        v2.v[v3] = v5;
        v3 += 1l ;
    }
    long v6;
    v6 = 1l;
    while (while_method_1(v2, v6)){
        long v8;
        v8 = 3l;
        while (while_method_2(v6, v8)){
            v8 -= 1l ;
            long v10;
            v10 = v8 - v6;
            float v11;
            v11 = v2.v[v10];
            float v12;
            v12 = v2.v[v8];
            float v13;
            v13 = v11 + v12;
            v2.v[v8] = v13;
        }
        long v14;
        v14 = v6 * 2l;
        v6 = v14;
    }
    float v15;
    v15 = v2.v[2l];
    float v16;
    v16 = curand_uniform(v1);
    float v17;
    v17 = v16 * v15;
    long v18;
    v18 = 0l;
    return loop_2(v2, v17, v18);
}
__device__ US0 sample_discrete_0(array<Tuple0,3l> v0, curandStatePhilox4_32_10_t * v1){
    array<float,3l> v2;
    long v3;
    v3 = 0l;
    while (while_method_0(v3)){
        US0 v5; float v6;
        Tuple0 tmp0 = v0.v[v3];
        v5 = tmp0.v0; v6 = tmp0.v1;
        v2.v[v3] = v6;
        v3 += 1l ;
    }
    long v7;
    v7 = sample_discrete__1(v2, v1);
    US0 v8; float v9;
    Tuple0 tmp1 = v0.v[v7];
    v8 = tmp1.v0; v9 = tmp1.v1;
    return v8;
}
extern "C" __global__ void entry0(unsigned char * v0) {
    long v1;
    v1 = threadIdx.x;
    long v2;
    v2 = blockIdx.x;
    long v3;
    v3 = v2 * 512l;
    long v4;
    v4 = v1 + v3;
    unsigned long long v5;
    v5 = clock64();
    unsigned long long v6;
    v6 = (unsigned long long)v4;
    curandStatePhilox4_32_10_t v7;
    curandStatePhilox4_32_10_t * v8 = &v7;
    curand_init(v5,v6,0ull,v8);
    bool v9;
    v9 = v4 == 0l;
    if (v9){
        array<Tuple0,3l> v10;
        US0 v11;
        v11 = US0_1();
        v10.v[0l] = Tuple0(v11, 1.0f);
        US0 v12;
        v12 = US0_0();
        v10.v[1l] = Tuple0(v12, 1.0f);
        US0 v13;
        v13 = US0_2();
        v10.v[2l] = Tuple0(v13, 1.0f);
        US0 v14;
        v14 = sample_discrete_0(v10, v8);
        long v15;
        v15 = v14.tag;
        long * v18;
        long * v16;
        v16 = (long *)(v0+0ull);
        v18 = v16;
        v18[0l] = v15;
        switch (v14.tag) {
            case 0: { // Paper
                return ;
                break;
            }
            case 1: { // Rock
                return ;
                break;
            }
            default: { // Scissors
                return ;
            }
        }
    } else {
        return ;
    }
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
import collections
class US0_0(NamedTuple): # Paper
    tag = 0
class US0_1(NamedTuple): # Rock
    tag = 1
class US0_2(NamedTuple): # Scissors
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
def Closure0():
    def inner() -> string:
        v0 = cp.empty(4,dtype=cp.uint8)
        v1 = 0
        v2 = raw_module.get_function(f"entry{v1}")
        del v1
        v2.max_dynamic_shared_size_bytes = 0 
        v2((1,),(512,),v0,shared_mem=0)
        del v2
        v4 = v0[0:].view(cp.int32)
        v5 = v4
        del v0
        v6 = v5[0].item()
        del v5
        if v6 == 0:
            v11 = US0_0()
        elif v6 == 1:
            v11 = US0_1()
        elif v6 == 2:
            v11 = US0_2()
        else:
            raise Exception("Invalid tag.")
        del v6
        match v11:
            case US0_0(): # Paper
                del v11
                v13 = "Paper"
                return v13
            case US0_1(): # Rock
                del v11
                v12 = "Rock"
                return v12
            case US0_2(): # Scissors
                del v11
                v14 = "Scissors"
                return v14
    return inner
def main():
    v0 = Closure0()
    v1 = collections.namedtuple("Functions",['random_action'])(v0)
    del v0
    return v1

if __name__ == '__main__': print(main().random_action())
# if __name__ == '__main__': print(main())
