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
        v15 = 2048l * v9;
        assert(0 <= v7 && v7 < 16l /* Tensor range check */);
        long v16;
        v16 = 2048l * v7;
        assert(0 <= v9 && v9 < 16l /* Tensor range check */);
        assert(0 <= v7 && v7 < 16l /* Tensor range check */);
        long v17;
        v17 = 16l * v7;
        long v18;
        v18 = 4096l * v9;
        long v19;
        v19 = v18 + v17;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v20;
        wmma::fill_fragment(v20, 0.0f);
        long v21;
        v21 = 0l;
        while (while_method_1(v21)){
            long v23;
            v23 = v21 % 16l;
            long v24;
            v24 = v21 / 16l;
            bool v25;
            v25 = v24 == 0l;
            bool v26;
            v26 = v25 == false;
            if (v26){
                const char * v27;
                v27 = "The index has to be in the range of the dimension.";
                assert(v25 /* v27 */);
            } else {
            }
            assert(0 <= v23 && v23 < 16l /* Tensor range check */);
            long v29;
            v29 = 8l * v23;
            long v30;
            v30 = v29 + v15;
            assert(0 <= v23 && v23 < 16l /* Tensor range check */);
            long v31;
            v31 = v29 + v16;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v32;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v33;
            float * v34;
            v34 = v0 + v30;
            wmma::load_matrix_sync(v32, v34, 128l);
            #pragma unroll
            for (int t = 0; t < v32.num_elements; t++) { v32.x[t] = wmma::__float_to_tf32(v32.x[t]); };
            float * v35;
            v35 = v1 + v31;
            wmma::load_matrix_sync(v33, v35, 128l);
            #pragma unroll
            for (int t = 0; t < v33.num_elements; t++) { v33.x[t] = wmma::__float_to_tf32(v33.x[t]); };
            wmma::mma_sync(v20, v32, v33, v20);
            v21 += 1l ;
        }
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v36;
        float * v37;
        v37 = v2 + v19;
        wmma::load_matrix_sync(v36, v37, 256l, wmma::mem_row_major);
        long v38;
        v38 = v36.num_elements;
        long v39;
        v39 = 0l;
        while (while_method_2(v38, v39)){
            float v41;
            v41 = v20.x[v39];
            float v42;
            v42 = v36.x[v39];
            float v43;
            v43 = 0.0f * v42;
            float v44;
            v44 = v41 + v43;
            v36.x[v39] = v44;
            v39 += 1l ;
        }
        float * v45;
        v45 = v2 + v19;
        wmma::store_matrix_sync(v45, v36, 256l, wmma::mem_row_major);
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
    v0 = cp.random.normal(0,1,32768,cp.float32)
    v1 = v0.size
    v2 = 32768 == v1
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
    v12 = cp.matmul(v6.reshape((256, 128)),cp.transpose(v0.reshape((256, 128)))).flatten()
    v13 = v12.size
    v14 = 65536 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = cp.empty(65536,dtype=cp.float32)
    v19 = 0
    raw_module.get_function(f"entry{v19}")((24, 1, 1),(256, 1, 1),(v6, v0, v18))
    del v0, v6, v19
    v20 = cp.max(cp.abs(v18-v12))
    del v12, v18
    return v20

if __name__ == '__main__': print(main())
