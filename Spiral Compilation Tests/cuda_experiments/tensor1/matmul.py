kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_1(long v0, long v1){
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
        v7 = v5 % 1l;
        bool v8;
        v8 = v5 == 0l;
        bool v9;
        v9 = v8 == false;
        if (v9){
            const char * v10;
            v10 = "The index has to be in the range of the dimension.";
            assert(v8 /* v10 */);
        } else {
        }
        assert(0 <= v7 && v7 < 1l /* Tensor range check */);
        long v12;
        v12 = 128l * v7;
        assert(0 <= v7 && v7 < 1l /* Tensor range check */);
        assert(0 <= v7 && v7 < 1l /* Tensor range check */);
        assert(0 <= v7 && v7 < 1l /* Tensor range check */);
        long v13;
        v13 = 16l * v7;
        long v14;
        v14 = 256l * v7;
        long v15;
        v15 = v14 + v13;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v16;
        wmma::fill_fragment(v16, 0.0f);
        long v17;
        v17 = 0l;
        while (while_method_0(v17)){
            long v19;
            v19 = v17 % 1l;
            bool v20;
            v20 = v17 == 0l;
            bool v21;
            v21 = v20 == false;
            if (v21){
                const char * v22;
                v22 = "The index has to be in the range of the dimension.";
                assert(v20 /* v22 */);
            } else {
            }
            assert(0 <= v19 && v19 < 1l /* Tensor range check */);
            long v24;
            v24 = 8l * v19;
            long v25;
            v25 = v24 + v12;
            assert(0 <= v19 && v19 < 1l /* Tensor range check */);
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v26;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v27;
            float * v28;
            v28 = v0 + v25;
            wmma::load_matrix_sync(v26, v28, 8l);
            #pragma unroll
            for (int t = 0; t < v26.num_elements; t++) { v26.x[t] = wmma::__float_to_tf32(v26.x[t]); };
            float * v29;
            v29 = v1 + v25;
            wmma::load_matrix_sync(v27, v29, 8l);
            #pragma unroll
            for (int t = 0; t < v27.num_elements; t++) { v27.x[t] = wmma::__float_to_tf32(v27.x[t]); };
            wmma::mma_sync(v16, v26, v27, v16);
            v17 += 1l ;
        }
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v30;
        float * v31;
        v31 = v2 + v15;
        wmma::load_matrix_sync(v30, v31, 16l, wmma::mem_row_major);
        long v32;
        v32 = v30.num_elements;
        long v33;
        v33 = 0l;
        while (while_method_1(v32, v33)){
            float v35;
            v35 = v16.x[v33];
            float v36;
            v36 = v30.x[v33];
            float v37;
            v37 = 0.0f * v36;
            float v38;
            v38 = v35 + v37;
            v30.x[v33] = v38;
            v33 += 1l ;
        }
        float * v39;
        v39 = v2 + v15;
        wmma::store_matrix_sync(v39, v30, 16l, wmma::mem_row_major);
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
    v0 = cp.random.normal(0,1,128,cp.float32)
    v1 = v0.size
    v2 = 128 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,128,cp.float32)
    v7 = v6.size
    v8 = 128 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.matmul(v6.reshape((16, 8)),cp.transpose(v0.reshape((16, 8)))).flatten()
    v13 = v12.size
    v14 = 256 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = cp.empty(256,dtype=cp.float32)
    v19 = 0
    raw_module.get_function(f"entry{v19}")((24, 1, 1),(256, 1, 1),(v6, v0, v18))
    del v0, v6, v19
    print(v18)
    print(v12)
    v20 = cp.max(cp.abs(v18-v12))
    del v12, v18
    return v20

if __name__ == '__main__': print(main())
