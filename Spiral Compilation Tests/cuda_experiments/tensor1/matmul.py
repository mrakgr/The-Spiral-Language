kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 1024l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 64l;
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
        v7 = v5 % 32l;
        long v8;
        v8 = v5 / 32l;
        long v9;
        v9 = v8 % 32l;
        long v10;
        v10 = v8 / 32l;
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
        assert(0 <= v9 && v9 < 32l /* Tensor range check */);
        long v15;
        v15 = 8192l * v9;
        assert(0 <= v7 && v7 < 32l /* Tensor range check */);
        long v16;
        v16 = 8192l * v7;
        assert(0 <= v9 && v9 < 32l /* Tensor range check */);
        assert(0 <= v7 && v7 < 32l /* Tensor range check */);
        long v17;
        v17 = 16l * v7;
        long v18;
        v18 = v15 + v17;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v19;
        wmma::fill_fragment(v19, 0.0f);
        long v20;
        v20 = 0l;
        while (while_method_1(v20)){
            long v22;
            v22 = v20 % 64l;
            long v23;
            v23 = v20 / 64l;
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
            assert(0 <= v22 && v22 < 64l /* Tensor range check */);
            long v28;
            v28 = 8l * v22;
            long v29;
            v29 = v28 + v15;
            assert(0 <= v22 && v22 < 64l /* Tensor range check */);
            long v30;
            v30 = v28 + v16;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v31;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v32;
            float * v33;
            v33 = v0 + v29;
            wmma::load_matrix_sync(v31, v33, 512l);
            #pragma unroll
            for (int t = 0; t < v31.num_elements; t++) { v31.x[t] = wmma::__float_to_tf32(v31.x[t]); };
            float * v34;
            v34 = v1 + v30;
            wmma::load_matrix_sync(v32, v34, 512l);
            #pragma unroll
            for (int t = 0; t < v32.num_elements; t++) { v32.x[t] = wmma::__float_to_tf32(v32.x[t]); };
            wmma::mma_sync(v19, v31, v32, v19);
            v20 += 1l ;
        }
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v35;
        float * v36;
        v36 = v2 + v18;
        wmma::load_matrix_sync(v35, v36, 512l, wmma::mem_row_major);
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
        wmma::store_matrix_sync(v43, v35, 512l, wmma::mem_row_major);
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
def method0(v0 : i32) -> bool:
    v1 = v0 < 100
    del v0
    return v1
def main():
    v0 = cp.random.normal(0,1,262144,cp.float32)
    v1 = v0.size
    v2 = 262144 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,262144,cp.float32)
    v7 = v6.size
    v8 = 262144 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.random.normal(0,1,262144,cp.float32)
    v13 = v12.size
    v14 = 262144 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18, v19 = (0, 0.0)
    while method0(v18):
        v21 = v12.reshape((512, 512))
        v22 = v6.reshape((512, 512))
        v23 = cp.transpose(v22)
        del v22
        v24 = v0.reshape((512, 512))
        v25 = (cp.matmul(v21,v23)+v24).flatten()
        del v21, v23, v24
        v26 = v25.size
        v27 = 262144 == v26
        del v26
        v28 = v27 == False
        if v28:
            v30 = "The total length of the reshaped tensor dimension must match that of the original one."
            assert v27, v30
            del v30
        else:
            pass
        del v27, v28
        v31 = 0
        raw_module.get_function(f"entry{v31}")((144, 1, 1),(256, 1, 1),(v12, v6, v0))
        del v31
        v32 = cp.max(cp.abs(v0-v25))
        del v25
        v33 = v32 + v19
        del v32
        v19 = v33
        del v33
        v18 += 1 
    del v0, v6, v12, v18
    v34 = v19 / 100.0
    del v19
    return v34

if __name__ == '__main__': print(main())
