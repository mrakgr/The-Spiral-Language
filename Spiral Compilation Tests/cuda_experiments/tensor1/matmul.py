kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
#include <assert.h>
#include <mma.h>
#include <cooperative_groups.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_1(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    grid_group v3 = this_grid();
    int32_t v4;
    v4 = v3.num_treads();
    int32_t v5;
    v5 = v3.thread_rank();
    int32_t v6;
    v6 = v5;
    while (while_method_0(v6)){
        int32_t v8;
        v8 = v6 % 1l;
        bool v9;
        v9 = v6 == 0l;
        bool v10;
        v10 = v9 == false;
        if (v10){
            const char * v11;
            v11 = "The index has to be in the range of the dimension.";
            assert(v9 /* v11 */);
        } else {
        }
        assert(0 <= v8 && v8 < 1l /* Tensor range check */);
        int32_t v13;
        v13 = 128l * v8;
        assert(0 <= v8 && v8 < 1l /* Tensor range check */);
        assert(0 <= v8 && v8 < 1l /* Tensor range check */);
        assert(0 <= v8 && v8 < 1l /* Tensor range check */);
        int32_t v14;
        v14 = 16l * v8;
        int32_t v15;
        v15 = 256l * v8;
        int32_t v16;
        v16 = v15 + v14;
        nvcuda::wmma::fragment<nvcuda::wmma::accumulator, 16l, 16l, 8l, float, nvcuda::wmma::mem_row_major> v17;
        nvcuda::wmma::fill_fragment(v17, 0.0f);
        int32_t v18;
        v18 = 0l;
        while (while_method_0(v18)){
            int32_t v20;
            v20 = v18 % 1l;
            bool v21;
            v21 = v18 == 0l;
            bool v22;
            v22 = v21 == false;
            if (v22){
                const char * v23;
                v23 = "The index has to be in the range of the dimension.";
                assert(v21 /* v23 */);
            } else {
            }
            assert(0 <= v20 && v20 < 1l /* Tensor range check */);
            int32_t v25;
            v25 = 8l * v20;
            int32_t v26;
            v26 = v25 + v13;
            assert(0 <= v20 && v20 < 1l /* Tensor range check */);
            nvcuda::wmma::fragment<nvcuda::wmma::matrix_a, 16l, 16l, 8l, nvcuda::wmma::precision::tf32, nvcuda::wmma::mem_row_major> v27;
            nvcuda::wmma::fragment<nvcuda::wmma::matrix_b, 16l, 16l, 8l, nvcuda::wmma::precision::tf32, nvcuda::wmma::mem_col_major> v28;
            float * v29;
            v29 = v0 + v26;
            nvcuda::wmma::load_matrix_sync(v27, v29, 8l, nvcuda::wmma::mem_row_major);
            #pragma unroll
            for (int t = 0; t < v27.num_elements; t++) { v27.x[t] =  nvcuda::wmma::__float_to_tf32(v27.x[t]); };
            float * v30;
            v30 = v1 + v26;
            nvcuda::wmma::load_matrix_sync(v28, v30, 8l, nvcuda::wmma::mem_col_major);
            #pragma unroll
            for (int t = 0; t < v28.num_elements; t++) { v28.x[t] =  nvcuda::wmma::__float_to_tf32(v28.x[t]); };
            nvcuda::wmma::mma_sync(v17, v27, v28, v17);
            v18 += 1l ;
        }
        nvcuda::wmma::fragment<nvcuda::wmma::accumulator, 16l, 16l, 8l, float, nvcuda::wmma::mem_row_major> v31;
        float * v32;
        v32 = v2 + v16;
        nvcuda::wmma::load_matrix_sync(v31, v32, 16l, nvcuda::wmma::mem_row_major);
        int32_t v33;
        v33 = v31.num_elements;
        int32_t v34;
        v34 = 0l;
        while (while_method_1(v33, v34)){
            float v36;
            v36 = v17.x[v34];
            float v37;
            v37 = v31.x[v34];
            float v38;
            v38 = 0.0f * v37;
            float v39;
            v39 = v36 + v38;
            v31.x[v34] = v39;
            v34 += 1l ;
        }
        float * v40;
        v40 = v2 + v16;
        nvcuda::wmma::store_matrix_sync(v40, v31, 16l, nvcuda::wmma::mem_row_major);
        v6 += v4 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

raw_module = cp.RawModule(code=kernel, backend='nvrtc', jitify=True, enable_cooperative_groups=True))
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
    v20 = cp.max(cp.abs(v18-v12))
    del v12, v18
    return v20

if __name__ == '__main__': print(main())
