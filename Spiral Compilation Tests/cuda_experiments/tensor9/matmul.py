kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
using namespace cooperative_groups;
#include <mma.h>
using namespace nvcuda;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 262144l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8192l;
    return v1;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3) {
    long v4;
    v4 = grid_group::num_threads();
    long v5;
    v5 = grid_group::thread_rank();
    long v6;
    v6 = v5;
    while (while_method_0(v6)){
        long v8;
        v8 = v6 % 262144l;
        long v9;
        v9 = v6 / 262144l;
        bool v10;
        v10 = v9 == 0l;
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The index has to be in the range of the dimension." && v10);
        } else {
        }
        assert("Tensor range check" && 0 <= v8 && v8 < 262144l);
        long v13;
        v13 = 4l * v8;
        assert("Tensor range check" && 0 <= v8 && v8 < 262144l);
        float v14[4l];
        float v15[4l];
        float v16[4l];
        float v17[4l];
        *(reinterpret_cast<int4*>(v14 + 0l)) = *(reinterpret_cast<int4*>(v2 + v13)) ;
        *(reinterpret_cast<int4*>(v15 + 0l)) = *(reinterpret_cast<int4*>(v3 + v13)) ;
        long v18;
        v18 = 0l;
        while (while_method_1(v18)){
            long v20;
            v20 = v18 % 4l;
            long v21;
            v21 = v18 / 4l;
            bool v22;
            v22 = v21 == 0l;
            bool v23;
            v23 = v22 == false;
            if (v23){
                assert("The index has to be in the range of the dimension." && v22);
            } else {
            }
            assert("Tensor range check" && 0 <= v20 && v20 < 4l);
            float v25;
            v25 = v14[v20];
            float v26;
            v26 = v15[v20];
            float v27;
            v27 = v25 + v26;
            float v28;
            v28 = v25 - v26;
            assert("Tensor range check" && 0 <= v20 && v20 < 4l);
            v16[v20] = v27;
            v17[v20] = v28;
            v18 += 1l ;
        }
        *(reinterpret_cast<int4*>(v0 + v13)) = *(reinterpret_cast<int4*>(v16 + 0l)) ;
        *(reinterpret_cast<int4*>(v1 + v13)) = *(reinterpret_cast<int4*>(v17 + 0l)) ;
        v6 += v4 ;
    }
    return ;
}
extern "C" __global__ void entry1(float * v0, float * v1, float * v2) {
    long v3;
    v3 = grid_group::num_threads() / warpSize;
    long v4;
    v4 = grid_group::thread_rank() / warpSize;
    long v5;
    v5 = v4;
    while (while_method_2(v5)){
        long v7;
        v7 = v5 % 8192l;
        long v8;
        v8 = v5 / 8192l;
        bool v9;
        v9 = v8 == 0l;
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The index has to be in the range of the dimension." && v9);
        } else {
        }
        assert("Tensor range check" && 0 <= v7 && v7 < 8192l);
        long v12;
        v12 = 128l * v7;
        assert("Tensor range check" && 0 <= v7 && v7 < 8192l);
        assert("Tensor range check" && 0 <= v7 && v7 < 8192l);
        long v13;
        v13 = 256l * v7;
        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v14;
        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v15 = v14;
        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v16;
        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v17 = v16;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v18;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v19 = v18;
        float * v20;
        v20 = v0 + v12;
        wmma::load_matrix_sync(v15, v20, 8l);
        #pragma unroll
        for (int t = 0; t < v15.num_elements; t++) { v15.x[t] = wmma::__float_to_tf32(v15.x[t]); };
        float * v21;
        v21 = v1 + v12;
        wmma::load_matrix_sync(v17, v21, 8l);
        #pragma unroll
        for (int t = 0; t < v17.num_elements; t++) { v17.x[t] = wmma::__float_to_tf32(v17.x[t]); };
        wmma::mma_sync(v19, v15, v17, v19);
        float * v22;
        v22 = v2 + v13;
        wmma::store_matrix_sync(v22, v19, 16l, wmma::mem_row_major);
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
options.append('--dopt=on')
options.append('--restrict')
options.append('--define-macro=NDEBUG')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
    del v0
    return v1
def main():
    v0 = cp.random.normal(0,1,1048576,cp.float32)
    v1 = v0.size
    v2 = 1048576 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,1048576,cp.float32)
    v6 = v5.size
    v7 = 1048576 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,1048576,cp.float32)
    v11 = v10.size
    v12 = 1048576 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = cp.random.normal(0,1,1048576,cp.float32)
    v16 = v15.size
    v17 = 1048576 == v16
    del v16
    v18 = v17 == False
    if v18:
        v19 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v17, v19
        del v19
    else:
        pass
    del v17, v18
    v20 = cp.random.normal(0,1,1048576,cp.float32)
    v21 = v20.size
    v22 = 1048576 == v21
    del v21
    v23 = v22 == False
    if v23:
        v24 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v22, v24
        del v24
    else:
        pass
    del v22, v23
    v25 = cp.random.normal(0,1,1048576,cp.float32)
    v26 = v25.size
    v27 = 1048576 == v26
    del v26
    v28 = v27 == False
    if v28:
        v29 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v27, v29
        del v29
    else:
        pass
    del v27, v28
    v30 = cp.random.normal(0,1,1048576,cp.float32)
    v31 = v30.size
    v32 = 1048576 == v31
    del v31
    v33 = v32 == False
    if v33:
        v34 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v32, v34
        del v34
    else:
        pass
    del v32, v33
    v35 = cp.random.normal(0,1,2097152,cp.float32)
    v36 = v35.size
    v37 = 2097152 == v36
    del v36
    v38 = v37 == False
    if v38:
        v39 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v37, v39
        del v39
    else:
        pass
    del v37, v38
    v40, v41 = (0, 0.0)
    while method0(v40):
        v43 = v10.reshape((1024, 1024))
        v44 = v5.reshape((1024, 1024))
        v45 = cp.transpose(v44)
        del v44
        v46 = v0.reshape((1024, 1024))
        v47 = (cp.matmul(v43,v45) + v46).flatten()
        del v43, v45, v46
        v48 = v47.size
        del v47
        v49 = 1048576 == v48
        del v48
        v50 = v49 == False
        if v50:
            v51 = "The total length of the reshaped tensor dimension must match that of the original one."
            assert v49, v51
            del v51
        else:
            pass
        del v49, v50
        v52 = 0
        v53 = raw_module.get_function(f"entry{v52}")
        del v52
        v53.max_dynamic_shared_size_bytes = 0 
        v53((144,),(256,),(v20, v15, v30, v25),shared_mem=0)
        del v53
        v54 = 1
        v55 = raw_module.get_function(f"entry{v54}")
        del v54
        v55.max_dynamic_shared_size_bytes = 0 
        v55((144,),(256,),(v10, v5, v35),shared_mem=0)
        del v55
        v41 = v41
        v40 += 1 
    del v0, v5, v10, v15, v20, v25, v30, v35, v40
    return v41

if __name__ == '__main__': print(main())
