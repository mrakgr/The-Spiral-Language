kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 64l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 1024l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_3(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    long v3;
    v3 = grid_group::num_blocks();
    long v4;
    v4 = grid_group::block_rank();
    long v5;
    v5 = v4;
    while (while_method_0(v5)){
        long v7;
        v7 = v5 % 8l;
        long v8;
        v8 = v5 / 8l;
        long v9;
        v9 = v8 % 8l;
        long v10;
        v10 = v8 / 8l;
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
        assert(0 <= v9 && v9 < 8l /* Tensor range check */);
        long v15;
        v15 = 32l * v9;
        assert(0 <= v7 && v7 < 8l /* Tensor range check */);
        long v16;
        v16 = 32l * v7;
        assert(0 <= v9 && v9 < 8l /* Tensor range check */);
        assert(0 <= v7 && v7 < 8l /* Tensor range check */);
        long v17;
        v17 = 8192l * v9;
        long v18;
        v18 = v17 + v16;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v19;
        __shared__ float v20[1536l];
        long v21;
        v21 = thread_block::num_threads();
        long v22;
        v22 = thread_block::thread_rank();
        long v23;
        v23 = v22;
        while (while_method_1(v23)){
            long v25;
            v25 = v23 % 32l;
            long v26;
            v26 = v23 / 32l;
            long v27;
            v27 = v26 % 32l;
            long v28;
            v28 = v26 / 32l;
            bool v29;
            v29 = v28 == 0l;
            bool v30;
            v30 = v29 == false;
            if (v30){
                const char * v31;
                v31 = "The index has to be in the range of the dimension.";
                assert(v29 /* v31 */);
            } else {
            }
            assert(0 <= v27 && v27 < 32l /* Tensor range check */);
            long v33;
            v33 = 256l * v27;
            long v34;
            v34 = v33 + v18;
            assert(0 <= v27 && v27 < 32l /* Tensor range check */);
            long v35;
            v35 = 48l * v27;
            cooperative_groups::memcpy_async(this_thread(), v20 + v35, v2 + v34, sizeof(float) * 32l);
            v23 += v21 ;
        }
        long v36;
        v36 = 0l;
        while (while_method_2(v36)){
            long v38;
            v38 = v36 % 4l;
            long v39;
            v39 = v36 / 4l;
            bool v40;
            v40 = v39 == 0l;
            bool v41;
            v41 = v40 == false;
            if (v41){
                const char * v42;
                v42 = "The index has to be in the range of the dimension.";
                assert(v40 /* v42 */);
            } else {
            }
            bool v44;
            v44 = v38 == 0l;
            assert(0 <= v38 && v38 < 4l /* Tensor range check */);
            long v45;
            v45 = 8192l * v38;
            long v46;
            v46 = v45 + v15;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v47;
            __shared__ float v48[1536l];
            long v49;
            v49 = thread_block::num_threads();
            long v50;
            v50 = thread_block::thread_rank();
            long v51;
            v51 = v50;
            while (while_method_1(v51)){
                long v53;
                v53 = v51 % 32l;
                long v54;
                v54 = v51 / 32l;
                long v55;
                v55 = v54 % 32l;
                long v56;
                v56 = v54 / 32l;
                bool v57;
                v57 = v56 == 0l;
                bool v58;
                v58 = v57 == false;
                if (v58){
                    const char * v59;
                    v59 = "The index has to be in the range of the dimension.";
                    assert(v57 /* v59 */);
                } else {
                }
                assert(0 <= v55 && v55 < 32l /* Tensor range check */);
                long v61;
                v61 = 256l * v55;
                long v62;
                v62 = v61 + v46;
                assert(0 <= v55 && v55 < 32l /* Tensor range check */);
                long v63;
                v63 = 48l * v55;
                cooperative_groups::memcpy_async(this_thread(), v48 + v63, v0 + v62, sizeof(float) * 32l);
                v51 += v49 ;
            }
            assert(0 <= v38 && v38 < 4l /* Tensor range check */);
            long v64;
            v64 = v45 + v16;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v65;
            __shared__ float v66[1536l];
            long v67;
            v67 = thread_block::num_threads();
            long v68;
            v68 = thread_block::thread_rank();
            long v69;
            v69 = v68;
            while (while_method_1(v69)){
                long v71;
                v71 = v69 % 32l;
                long v72;
                v72 = v69 / 32l;
                long v73;
                v73 = v72 % 32l;
                long v74;
                v74 = v72 / 32l;
                bool v75;
                v75 = v74 == 0l;
                bool v76;
                v76 = v75 == false;
                if (v76){
                    const char * v77;
                    v77 = "The index has to be in the range of the dimension.";
                    assert(v75 /* v77 */);
                } else {
                }
                assert(0 <= v73 && v73 < 32l /* Tensor range check */);
                long v79;
                v79 = 256l * v73;
                long v80;
                v80 = v79 + v64;
                assert(0 <= v73 && v73 < 32l /* Tensor range check */);
                long v81;
                v81 = 48l * v73;
                cooperative_groups::memcpy_async(this_thread(), v66 + v81, v1 + v80, sizeof(float) * 32l);
                v69 += v67 ;
            }
            long v82;
            v82 = thread_block::num_threads() / warpSize;
            long v83;
            v83 = thread_block::thread_rank() / warpSize;
            long v84;
            v84 = v83;
            while (while_method_2(v84)){
                long v86;
                v86 = v84 % 2l;
                long v87;
                v87 = v84 / 2l;
                long v88;
                v88 = v87 % 2l;
                long v89;
                v89 = v87 / 2l;
                bool v90;
                v90 = v89 == 0l;
                bool v91;
                v91 = v90 == false;
                if (v91){
                    const char * v92;
                    v92 = "The index has to be in the range of the dimension.";
                    assert(v90 /* v92 */);
                } else {
                }
                assert(0 <= v88 && v88 < 2l /* Tensor range check */);
                long v94;
                v94 = 16l * v88;
                assert(0 <= v86 && v86 < 2l /* Tensor range check */);
                long v95;
                v95 = 16l * v86;
                assert(0 <= v88 && v88 < 2l /* Tensor range check */);
                assert(0 <= v86 && v86 < 2l /* Tensor range check */);
                long v96;
                v96 = 768l * v88;
                long v97;
                v97 = v96 + v95;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v98;
                wmma::fill_fragment(v98, 0.0f);
                long v99;
                v99 = 0l;
                while (while_method_2(v99)){
                    long v101;
                    v101 = v99 % 4l;
                    long v102;
                    v102 = v99 / 4l;
                    bool v103;
                    v103 = v102 == 0l;
                    bool v104;
                    v104 = v103 == false;
                    if (v104){
                        const char * v105;
                        v105 = "The index has to be in the range of the dimension.";
                        assert(v103 /* v105 */);
                    } else {
                    }
                    assert(0 <= v101 && v101 < 4l /* Tensor range check */);
                    long v107;
                    v107 = 384l * v101;
                    long v108;
                    v108 = v107 + v94;
                    assert(0 <= v101 && v101 < 4l /* Tensor range check */);
                    long v109;
                    v109 = v107 + v95;
                    float * v110;
                    v110 = v48 + v108;
                    wmma::load_matrix_sync(v47, v110, 48l);
                    #pragma unroll
                    for (int t = 0; t < v47.num_elements; t++) { v47.x[t] = wmma::__float_to_tf32(v47.x[t]); };
                    float * v111;
                    v111 = v66 + v109;
                    wmma::load_matrix_sync(v65, v111, 48l);
                    #pragma unroll
                    for (int t = 0; t < v65.num_elements; t++) { v65.x[t] = wmma::__float_to_tf32(v65.x[t]); };
                    wmma::mma_sync(v98, v47, v65, v98);
                    v99 += 1l ;
                }
                float * v112;
                v112 = v20 + v97;
                wmma::load_matrix_sync(v19, v112, 48l, wmma::mem_row_major);
                long v113;
                v113 = v19.num_elements;
                long v114;
                v114 = 0l;
                while (while_method_3(v113, v114)){
                    float v116;
                    v116 = v98.x[v114];
                    float v117;
                    v117 = v19.x[v114];
                    float v118;
                    v118 = v116 + v117;
                    v19.x[v114] = v118;
                    v114 += 1l ;
                }
                float * v119;
                v119 = v20 + v97;
                wmma::store_matrix_sync(v119, v19, 48l, wmma::mem_row_major);
                v84 += v82 ;
            }
            v36 += 1l ;
        }
        long v120;
        v120 = thread_block::num_threads();
        long v121;
        v121 = thread_block::thread_rank();
        long v122;
        v122 = v121;
        while (while_method_1(v122)){
            long v124;
            v124 = v122 % 32l;
            long v125;
            v125 = v122 / 32l;
            long v126;
            v126 = v125 % 32l;
            long v127;
            v127 = v125 / 32l;
            bool v128;
            v128 = v127 == 0l;
            bool v129;
            v129 = v128 == false;
            if (v129){
                const char * v130;
                v130 = "The index has to be in the range of the dimension.";
                assert(v128 /* v130 */);
            } else {
            }
            assert(0 <= v126 && v126 < 32l /* Tensor range check */);
            long v132;
            v132 = 48l * v126;
            assert(0 <= v126 && v126 < 32l /* Tensor range check */);
            long v133;
            v133 = 256l * v126;
            long v134;
            v134 = v133 + v18;
            cooperative_groups::memcpy_async(this_thread(), v2 + v134, v20 + v132, sizeof(float) * 32l);
            v122 += v120 ;
        }
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
    v29 = cp.max(cp.abs(v0-v22))
    del v0, v22
    return v29

if __name__ == '__main__': print(main())
