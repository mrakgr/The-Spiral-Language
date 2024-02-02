kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 256l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 16l;
    return v1;
}
__device__ inline bool while_method_2(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    long v3;
    v3 = grid_group::num_threads() / warpSize;
    long v4;
    v4 = grid_group::thread_rank() / warpSize;
    long v5;
    v5 = v4;
    while (while_method_0(v5)){
        long v7;
        v7 = v5 % 16l;
        long v8;
        v8 = v5 / 16l;
        long v9;
        v9 = v8 % 16l;
        long v10;
        v10 = v8 / 16l;
        bool v11;
        v11 = v10 == 0l;
        bool v12;
        v12 = v11 == false;
        if (v12){
            const char * v13;
            v13 = "The index has to be in the range of the dimension.";
            assert(v11 /* v13 */);
        } else {
        }
        assert(0 <= v9 && v9 < 16l /* Tensor range check */);
        long v15;
        v15 = 16l * v9;
        assert(0 <= v7 && v7 < 16l /* Tensor range check */);
        long v16;
        v16 = 16l * v7;
        assert(0 <= v9 && v9 < 16l /* Tensor range check */);
        assert(0 <= v7 && v7 < 16l /* Tensor range check */);
        long v17;
        v17 = 4096l * v9;
        long v18;
        v18 = v17 + v16;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v19;
        wmma::fill_fragment(v19, 0.0f);
        long v20;
        v20 = 0l;
        while (while_method_1(v20)){
            long v22;
            v22 = v20 % 16l;
            long v23;
            v23 = v20 / 16l;
            bool v24;
            v24 = v23 == 0l;
            bool v25;
            v25 = v24 == false;
            if (v25){
                const char * v26;
                v26 = "The index has to be in the range of the dimension.";
                assert(v24 /* v26 */);
            } else {
            }
            assert(0 <= v22 && v22 < 16l /* Tensor range check */);
            long v28;
            v28 = 2048l * v22;
            long v29;
            v29 = v28 + v15;
            assert(0 <= v22 && v22 < 16l /* Tensor range check */);
            long v30;
            v30 = v28 + v16;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v31;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v32;
            float * v33;
            v33 = v0 + v29;
            wmma::load_matrix_sync(v31, v33, 256l);
            #pragma unroll
            for (int t = 0; t < v31.num_elements; t++) { v31.x[t] = wmma::__float_to_tf32(v31.x[t]); };
            float * v34;
            v34 = v1 + v30;
            wmma::load_matrix_sync(v32, v34, 256l);
            #pragma unroll
            for (int t = 0; t < v32.num_elements; t++) { v32.x[t] = wmma::__float_to_tf32(v32.x[t]); };
            wmma::mma_sync(v19, v31, v32, v19);
            v20 += 1l ;
        }
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v35;
        float * v36;
        v36 = v2 + v18;
        wmma::load_matrix_sync(v35, v36, 256l, wmma::mem_row_major);
        long v37;
        v37 = v35.num_elements;
        long v38;
        v38 = 0l;
        while (while_method_2(v37, v38)){
            float v40;
            v40 = v19.x[v38];
            float v41;
            v41 = v35.x[v38];
            float v42;
            v42 = v40 + v41;
            v35.x[v38] = v42;
            v38 += 1l ;
        }
        float * v43;
        v43 = v2 + v18;
        wmma::store_matrix_sync(v43, v35, 256l, wmma::mem_row_major);
        v5 += v3 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--diag-suppress=550')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def main():
    v0 = cp.random.normal(0,1,65536,cp.float32)
    v1 = v0.size
    v2 = 65536 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,32768,cp.float32)
    v7 = v6.size
    v8 = 32768 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.random.normal(0,1,32768,cp.float32)
    v13 = v12.size
    v14 = 32768 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = v12.reshape((128, 256))
    v19 = cp.transpose(v18)
    del v18
    v20 = v6.reshape((128, 256))
    v21 = v0.reshape((256, 256))
    v22 = (cp.matmul(v19,v20)+v21).flatten()
    del v19, v20, v21
    v23 = v22.size
    v24 = 65536 == v23
    del v23
    v25 = v24 == False
    if v25:
        v27 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v24, v27
        del v27
    else:
        pass
    del v24, v25
    v28 = 0
    raw_module.get_function(f"entry{v28}")((24, 1, 1),(256, 1, 1),(v12, v6, v0))
    del v6, v12, v28
    print(v22[:20]) 
    print(v0[:20]) 
    v29 = cp.max(cp.abs(v0-v22))
    del v0, v22
    return v29

if __name__ == '__main__': print(main())
