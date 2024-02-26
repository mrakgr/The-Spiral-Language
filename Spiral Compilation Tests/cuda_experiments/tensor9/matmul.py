kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
using namespace cooperative_groups;
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups/memcpy_async.h>
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
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 16l;
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
    auto v3 = this_thread_block();
    thread_block_tile<32l, thread_block> v4 = tiled_partition<32l>(v3);
    long v5;
    v5 = grid_group::num_threads() / warpSize;
    long v6;
    v6 = grid_group::thread_rank() / warpSize;
    long v7;
    v7 = v6;
    while (while_method_2(v7)){
        long v9;
        v9 = v7 % 8192l;
        long v10;
        v10 = v7 / 8192l;
        bool v11;
        v11 = v10 == 0l;
        bool v12;
        v12 = v11 == false;
        if (v12){
            assert("The index has to be in the range of the dimension." && v11);
        } else {
        }
        assert("Tensor range check" && 0 <= v9 && v9 < 8192l);
        long v14;
        v14 = 128l * v9;
        assert("Tensor range check" && 0 <= v9 && v9 < 8192l);
        assert("Tensor range check" && 0 <= v9 && v9 < 8192l);
        long v15;
        v15 = 256l * v9;
        __shared__ float v16[128l];
        __shared__ float v17[128l];
        __shared__ float v18[256l];
        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v19;
        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v20 = v19;
        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v21;
        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v22 = v21;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v23;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v24 = v23;
        long v25;
        v25 = v4.meta_group_size();
        long v26;
        v26 = v4.meta_group_rank();
        long v27;
        v27 = v26;
        while (while_method_3(v27)){
            long v29;
            v29 = v27 % 16l;
            long v30;
            v30 = v27 / 16l;
            bool v31;
            v31 = v30 == 0l;
            bool v32;
            v32 = v31 == false;
            if (v32){
                assert("The index has to be in the range of the dimension." && v31);
            } else {
            }
            assert("Tensor range check" && 0 <= v29 && v29 < 16l);
            long v34;
            v34 = 8l * v29;
            long v35;
            v35 = v34 + v14;
            assert("Tensor range check" && 0 <= v29 && v29 < 16l);
            cooperative_groups::memcpy_async(v4, v16 + v34, v0 + v35, sizeof(float) * 8l);
            v27 += v25 ;
        }
        long v36;
        v36 = v4.meta_group_size();
        long v37;
        v37 = v4.meta_group_rank();
        long v38;
        v38 = v37;
        while (while_method_3(v38)){
            long v40;
            v40 = v38 % 16l;
            long v41;
            v41 = v38 / 16l;
            bool v42;
            v42 = v41 == 0l;
            bool v43;
            v43 = v42 == false;
            if (v43){
                assert("The index has to be in the range of the dimension." && v42);
            } else {
            }
            assert("Tensor range check" && 0 <= v40 && v40 < 16l);
            long v45;
            v45 = 8l * v40;
            long v46;
            v46 = v45 + v14;
            assert("Tensor range check" && 0 <= v40 && v40 < 16l);
            cooperative_groups::memcpy_async(v4, v17 + v45, v1 + v46, sizeof(float) * 8l);
            v38 += v36 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        float * v47;
        v47 = v16 + 0l;
        wmma::load_matrix_sync(v20, v47, 8l);
        #pragma unroll
        for (int t = 0; t < v20.num_elements; t++) { v20.x[t] = wmma::__float_to_tf32(v20.x[t]); };
        float * v48;
        v48 = v17 + 0l;
        wmma::load_matrix_sync(v22, v48, 8l);
        #pragma unroll
        for (int t = 0; t < v22.num_elements; t++) { v22.x[t] = wmma::__float_to_tf32(v22.x[t]); };
        wmma::mma_sync(v24, v20, v22, v24);
        float * v49;
        v49 = v18 + 0l;
        wmma::store_matrix_sync(v49, v24, 16l, wmma::mem_row_major);
        long v50;
        v50 = v4.meta_group_size();
        long v51;
        v51 = v4.meta_group_rank();
        long v52;
        v52 = v51;
        while (while_method_3(v52)){
            long v54;
            v54 = v52 % 16l;
            long v55;
            v55 = v52 / 16l;
            bool v56;
            v56 = v55 == 0l;
            bool v57;
            v57 = v56 == false;
            if (v57){
                assert("The index has to be in the range of the dimension." && v56);
            } else {
            }
            assert("Tensor range check" && 0 <= v54 && v54 < 16l);
            long v59;
            v59 = 16l * v54;
            assert("Tensor range check" && 0 <= v54 && v54 < 16l);
            long v60;
            v60 = v59 + v15;
            cooperative_groups::memcpy_async(v4, v2 + v60, v18 + v59, sizeof(float) * 16l);
            v52 += v50 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        v7 += v5 ;
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
