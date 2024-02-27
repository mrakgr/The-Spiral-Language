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
    v1 = v0 < 1024l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 128l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 256l;
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
        int4* v18;
        v18 = reinterpret_cast<int4*>(v2 + v13);
        int4* v19;
        v19 = reinterpret_cast<int4*>(v14 + 0l);
        assert("Pointer alignment check" && v18 % sizeof(int4) == 0 && v19 % sizeof(int4) == 0);
        *v19 = *v18;
        int4* v20;
        v20 = reinterpret_cast<int4*>(v3 + v13);
        int4* v21;
        v21 = reinterpret_cast<int4*>(v15 + 0l);
        assert("Pointer alignment check" && v20 % sizeof(int4) == 0 && v21 % sizeof(int4) == 0);
        *v21 = *v20;
        long v22;
        v22 = 0l;
        while (while_method_1(v22)){
            long v24;
            v24 = v22 % 4l;
            long v25;
            v25 = v22 / 4l;
            bool v26;
            v26 = v25 == 0l;
            bool v27;
            v27 = v26 == false;
            if (v27){
                assert("The index has to be in the range of the dimension." && v26);
            } else {
            }
            assert("Tensor range check" && 0 <= v24 && v24 < 4l);
            float v29;
            v29 = v14[v24];
            float v30;
            v30 = v15[v24];
            float v31;
            v31 = v29 + v30;
            float v32;
            v32 = v29 - v30;
            assert("Tensor range check" && 0 <= v24 && v24 < 4l);
            v16[v24] = v31;
            v17[v24] = v32;
            v22 += 1l ;
        }
        int4* v33;
        v33 = reinterpret_cast<int4*>(v16 + 0l);
        int4* v34;
        v34 = reinterpret_cast<int4*>(v0 + v13);
        assert("Pointer alignment check" && v33 % sizeof(int4) == 0 && v34 % sizeof(int4) == 0);
        *v34 = *v33;
        int4* v35;
        v35 = reinterpret_cast<int4*>(v17 + 0l);
        int4* v36;
        v36 = reinterpret_cast<int4*>(v1 + v13);
        assert("Pointer alignment check" && v35 % sizeof(int4) == 0 && v36 % sizeof(int4) == 0);
        *v36 = *v35;
        v6 += v4 ;
    }
    return ;
}
extern "C" __global__ void entry1(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    thread_block_tile<32l, thread_block> v4 = tiled_partition<32l>(v3);
    thread_block_tile<1l, thread_block_tile<32l, thread_block>> v5 = tiled_partition<1l>(v4);
    long v6;
    v6 = grid_group::num_blocks();
    long v7;
    v7 = grid_group::block_rank();
    long v8;
    v8 = v7;
    while (while_method_2(v8)){
        long v10;
        v10 = v8 % 1024l;
        long v11;
        v11 = v8 / 1024l;
        bool v12;
        v12 = v11 == 0l;
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The index has to be in the range of the dimension." && v12);
        } else {
        }
        long v15;
        v15 = v4.meta_group_rank();
        assert("Tensor range check" && 0 <= v10 && v10 < 1024l);
        long v16;
        v16 = 1024l * v10;
        assert("Tensor range check" && 0 <= v15 && v15 < 8l);
        long v17;
        v17 = 128l * v15;
        long v18;
        v18 = v17 + v16;
        assert("Tensor range check" && 0 <= v10 && v10 < 1024l);
        assert("Tensor range check" && 0 <= v15 && v15 < 8l);
        assert("Tensor range check" && 0 <= v10 && v10 < 1024l);
        long v19;
        v19 = 2048l * v10;
        assert("Tensor range check" && 0 <= v15 && v15 < 8l);
        long v20;
        v20 = 256l * v15;
        long v21;
        v21 = v20 + v19;
        __shared__ float v22[1024l];
        assert("Tensor range check" && 0 <= v15 && v15 < 8l);
        __shared__ float v23[1024l];
        assert("Tensor range check" && 0 <= v15 && v15 < 8l);
        __shared__ float v24[2048l];
        assert("Tensor range check" && 0 <= v15 && v15 < 8l);
        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v25;
        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v26 = v25;
        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v27;
        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v28 = v27;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v29;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v30 = v29;
        long v31;
        v31 = v5.meta_group_size();
        long v32;
        v32 = v5.meta_group_rank();
        long v33;
        v33 = v32;
        while (while_method_3(v33)){
            long v35;
            v35 = v33 % 8l;
            long v36;
            v36 = v33 / 8l;
            long v37;
            v37 = v36 % 16l;
            long v38;
            v38 = v36 / 16l;
            bool v39;
            v39 = v38 == 0l;
            bool v40;
            v40 = v39 == false;
            if (v40){
                assert("The index has to be in the range of the dimension." && v39);
            } else {
            }
            assert("Tensor range check" && 0 <= v37 && v37 < 16l);
            assert("Tensor range check" && 0 <= v35 && v35 < 8l);
            long v42;
            v42 = v35 + v18;
            long v43;
            v43 = 8l * v37;
            long v44;
            v44 = v43 + v42;
            assert("Tensor range check" && 0 <= v37 && v37 < 16l);
            assert("Tensor range check" && 0 <= v35 && v35 < 8l);
            long v45;
            v45 = v35 + v17;
            long v46;
            v46 = v43 + v45;
            int* v47;
            v47 = reinterpret_cast<int*>(v0 + v44);
            int* v48;
            v48 = reinterpret_cast<int*>(v22 + v46);
            assert("Pointer alignment check" && v47 % sizeof(int) == 0 && v48 % sizeof(int) == 0);
            *v48 = *v47;
            v33 += v31 ;
        }
        long v49;
        v49 = v5.meta_group_size();
        long v50;
        v50 = v5.meta_group_rank();
        long v51;
        v51 = v50;
        while (while_method_3(v51)){
            long v53;
            v53 = v51 % 8l;
            long v54;
            v54 = v51 / 8l;
            long v55;
            v55 = v54 % 16l;
            long v56;
            v56 = v54 / 16l;
            bool v57;
            v57 = v56 == 0l;
            bool v58;
            v58 = v57 == false;
            if (v58){
                assert("The index has to be in the range of the dimension." && v57);
            } else {
            }
            assert("Tensor range check" && 0 <= v55 && v55 < 16l);
            assert("Tensor range check" && 0 <= v53 && v53 < 8l);
            long v60;
            v60 = v53 + v18;
            long v61;
            v61 = 8l * v55;
            long v62;
            v62 = v61 + v60;
            assert("Tensor range check" && 0 <= v55 && v55 < 16l);
            assert("Tensor range check" && 0 <= v53 && v53 < 8l);
            long v63;
            v63 = v53 + v17;
            long v64;
            v64 = v61 + v63;
            int* v65;
            v65 = reinterpret_cast<int*>(v1 + v62);
            int* v66;
            v66 = reinterpret_cast<int*>(v23 + v64);
            assert("Pointer alignment check" && v65 % sizeof(int) == 0 && v66 % sizeof(int) == 0);
            *v66 = *v65;
            v51 += v49 ;
        }
        v4.sync() ;
        float * v67;
        v67 = v22 + v17;
        wmma::load_matrix_sync(v26, v67, 8l);
        #pragma unroll
        for (int t = 0; t < v26.num_elements; t++) { v26.x[t] = wmma::__float_to_tf32(v26.x[t]); };
        float * v68;
        v68 = v23 + v17;
        wmma::load_matrix_sync(v28, v68, 8l);
        #pragma unroll
        for (int t = 0; t < v28.num_elements; t++) { v28.x[t] = wmma::__float_to_tf32(v28.x[t]); };
        wmma::mma_sync(v30, v26, v28, v30);
        float * v69;
        v69 = v24 + v20;
        wmma::store_matrix_sync(v69, v30, 16l, wmma::mem_row_major);
        long v70;
        v70 = v5.meta_group_size();
        long v71;
        v71 = v5.meta_group_rank();
        long v72;
        v72 = v71;
        while (while_method_4(v72)){
            long v74;
            v74 = v72 % 16l;
            long v75;
            v75 = v72 / 16l;
            long v76;
            v76 = v75 % 16l;
            long v77;
            v77 = v75 / 16l;
            bool v78;
            v78 = v77 == 0l;
            bool v79;
            v79 = v78 == false;
            if (v79){
                assert("The index has to be in the range of the dimension." && v78);
            } else {
            }
            assert("Tensor range check" && 0 <= v76 && v76 < 16l);
            assert("Tensor range check" && 0 <= v74 && v74 < 16l);
            long v81;
            v81 = v74 + v20;
            long v82;
            v82 = 16l * v76;
            long v83;
            v83 = v82 + v81;
            assert("Tensor range check" && 0 <= v76 && v76 < 16l);
            assert("Tensor range check" && 0 <= v74 && v74 < 16l);
            long v84;
            v84 = v74 + v21;
            long v85;
            v85 = v82 + v84;
            int* v86;
            v86 = reinterpret_cast<int*>(v24 + v83);
            int* v87;
            v87 = reinterpret_cast<int*>(v2 + v85);
            assert("Pointer alignment check" && v86 % sizeof(int) == 0 && v87 % sizeof(int) == 0);
            *v87 = *v86;
            v72 += v70 ;
        }
        v4.sync() ;
        v8 += v6 ;
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
