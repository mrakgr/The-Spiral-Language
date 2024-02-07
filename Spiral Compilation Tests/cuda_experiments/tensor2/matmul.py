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
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_4(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    thread_block_tile<32l, thread_block> v4 = tiled_partition<32l>(v3);
    long v5;
    v5 = grid_group::num_blocks();
    long v6;
    v6 = grid_group::block_rank();
    long v7;
    v7 = v6;
    while (while_method_0(v7)){
        long v9;
        v9 = v7 % 8l;
        long v10;
        v10 = v7 / 8l;
        long v11;
        v11 = v10 % 8l;
        long v12;
        v12 = v10 / 8l;
        bool v13;
        v13 = v12 == 0l;
        bool v14;
        v14 = v13 == false;
        if (v14){
            const char * v15;
            v15 = "The index has to be in the range of the dimension.";
            assert(v13 /* v15 */);
        } else {
        }
        assert(0 <= v11 && v11 < 8l /* Tensor range check */);
        long v17;
        v17 = 8192l * v11;
        assert(0 <= v9 && v9 < 8l /* Tensor range check */);
        long v18;
        v18 = 8192l * v9;
        assert(0 <= v11 && v11 < 8l /* Tensor range check */);
        assert(0 <= v9 && v9 < 8l /* Tensor range check */);
        long v19;
        v19 = 32l * v9;
        long v20;
        v20 = v17 + v19;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v21;
        __shared__ float v22[1536l];
        long v23;
        v23 = v4.meta_group_size();
        long v24;
        v24 = v4.meta_group_rank();
        long v25;
        v25 = v24;
        while (while_method_1(v25)){
            long v27;
            v27 = v25 % 32l;
            long v28;
            v28 = v25 / 32l;
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
            v34 = v33 + v20;
            assert(0 <= v27 && v27 < 32l /* Tensor range check */);
            long v35;
            v35 = 48l * v27;
            cooperative_groups::memcpy_async(v4, v22 + v35, v2 + v34, sizeof(float) * 32l);
            v25 += v23 ;
        }
        long v36;
        v36 = 0l;
        while (while_method_2(v36)){
            long v38;
            v38 = v36 % 8l;
            long v39;
            v39 = v36 / 8l;
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
            float v45;
            if (v44){
                v45 = 0.0f;
            } else {
                v45 = 1.0f;
            }
            assert(0 <= v38 && v38 < 8l /* Tensor range check */);
            long v46;
            v46 = 32l * v38;
            long v47;
            v47 = v46 + v17;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v48;
            __shared__ float v49[1280l];
            v3.sync() ;
            long v50;
            v50 = v4.meta_group_size();
            long v51;
            v51 = v4.meta_group_rank();
            long v52;
            v52 = v51;
            while (while_method_1(v52)){
                long v54;
                v54 = v52 % 32l;
                long v55;
                v55 = v52 / 32l;
                bool v56;
                v56 = v55 == 0l;
                bool v57;
                v57 = v56 == false;
                if (v57){
                    const char * v58;
                    v58 = "The index has to be in the range of the dimension.";
                    assert(v56 /* v58 */);
                } else {
                }
                assert(0 <= v54 && v54 < 32l /* Tensor range check */);
                long v60;
                v60 = 256l * v54;
                long v61;
                v61 = v60 + v47;
                assert(0 <= v54 && v54 < 32l /* Tensor range check */);
                long v62;
                v62 = 40l * v54;
                cooperative_groups::memcpy_async(v4, v49 + v62, v0 + v61, sizeof(float) * 32l);
                v52 += v50 ;
            }
            assert(0 <= v38 && v38 < 8l /* Tensor range check */);
            long v63;
            v63 = v46 + v18;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v64;
            __shared__ float v65[1280l];
            long v66;
            v66 = v4.meta_group_size();
            long v67;
            v67 = v4.meta_group_rank();
            long v68;
            v68 = v67;
            while (while_method_1(v68)){
                long v70;
                v70 = v68 % 32l;
                long v71;
                v71 = v68 / 32l;
                bool v72;
                v72 = v71 == 0l;
                bool v73;
                v73 = v72 == false;
                if (v73){
                    const char * v74;
                    v74 = "The index has to be in the range of the dimension.";
                    assert(v72 /* v74 */);
                } else {
                }
                assert(0 <= v70 && v70 < 32l /* Tensor range check */);
                long v76;
                v76 = 256l * v70;
                long v77;
                v77 = v76 + v63;
                assert(0 <= v70 && v70 < 32l /* Tensor range check */);
                long v78;
                v78 = 40l * v70;
                cooperative_groups::memcpy_async(v4, v65 + v78, v1 + v77, sizeof(float) * 32l);
                v68 += v66 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            long v79;
            v79 = thread_block::num_threads() / warpSize;
            long v80;
            v80 = thread_block::thread_rank() / warpSize;
            long v81;
            v81 = v80;
            while (while_method_3(v81)){
                long v83;
                v83 = v81 % 2l;
                long v84;
                v84 = v81 / 2l;
                long v85;
                v85 = v84 % 2l;
                long v86;
                v86 = v84 / 2l;
                bool v87;
                v87 = v86 == 0l;
                bool v88;
                v88 = v87 == false;
                if (v88){
                    const char * v89;
                    v89 = "The index has to be in the range of the dimension.";
                    assert(v87 /* v89 */);
                } else {
                }
                assert(0 <= v85 && v85 < 2l /* Tensor range check */);
                long v91;
                v91 = 640l * v85;
                assert(0 <= v83 && v83 < 2l /* Tensor range check */);
                long v92;
                v92 = 640l * v83;
                assert(0 <= v85 && v85 < 2l /* Tensor range check */);
                assert(0 <= v83 && v83 < 2l /* Tensor range check */);
                long v93;
                v93 = 16l * v83;
                long v94;
                v94 = 768l * v85;
                long v95;
                v95 = v94 + v93;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v96;
                wmma::fill_fragment(v96, 0.0f);
                long v97;
                v97 = 0l;
                while (while_method_3(v97)){
                    long v99;
                    v99 = v97 % 4l;
                    long v100;
                    v100 = v97 / 4l;
                    bool v101;
                    v101 = v100 == 0l;
                    bool v102;
                    v102 = v101 == false;
                    if (v102){
                        const char * v103;
                        v103 = "The index has to be in the range of the dimension.";
                        assert(v101 /* v103 */);
                    } else {
                    }
                    assert(0 <= v99 && v99 < 4l /* Tensor range check */);
                    long v105;
                    v105 = 8l * v99;
                    long v106;
                    v106 = v105 + v91;
                    assert(0 <= v99 && v99 < 4l /* Tensor range check */);
                    long v107;
                    v107 = v105 + v92;
                    float * v108;
                    v108 = v49 + v106;
                    wmma::load_matrix_sync(v48, v108, 40l);
                    #pragma unroll
                    for (int t = 0; t < v48.num_elements; t++) { v48.x[t] = wmma::__float_to_tf32(v48.x[t]); };
                    float * v109;
                    v109 = v65 + v107;
                    wmma::load_matrix_sync(v64, v109, 40l);
                    #pragma unroll
                    for (int t = 0; t < v64.num_elements; t++) { v64.x[t] = wmma::__float_to_tf32(v64.x[t]); };
                    wmma::mma_sync(v96, v48, v64, v96);
                    v97 += 1l ;
                }
                float * v110;
                v110 = v22 + v95;
                wmma::load_matrix_sync(v21, v110, 48l, wmma::mem_row_major);
                long v111;
                v111 = v21.num_elements;
                long v112;
                v112 = 0l;
                while (while_method_4(v111, v112)){
                    float v114;
                    v114 = v96.x[v112];
                    float v115;
                    v115 = v21.x[v112];
                    float v116;
                    v116 = v45 * v115;
                    float v117;
                    v117 = v114 + v116;
                    v21.x[v112] = v117;
                    v112 += 1l ;
                }
                float * v118;
                v118 = v22 + v95;
                wmma::store_matrix_sync(v118, v21, 48l, wmma::mem_row_major);
                v81 += v79 ;
            }
            v36 += 1l ;
        }
        v3.sync() ;
        long v119;
        v119 = v4.meta_group_size();
        long v120;
        v120 = v4.meta_group_rank();
        long v121;
        v121 = v120;
        while (while_method_1(v121)){
            long v123;
            v123 = v121 % 32l;
            long v124;
            v124 = v121 / 32l;
            bool v125;
            v125 = v124 == 0l;
            bool v126;
            v126 = v125 == false;
            if (v126){
                const char * v127;
                v127 = "The index has to be in the range of the dimension.";
                assert(v125 /* v127 */);
            } else {
            }
            assert(0 <= v123 && v123 < 32l /* Tensor range check */);
            long v129;
            v129 = 48l * v123;
            assert(0 <= v123 && v123 < 32l /* Tensor range check */);
            long v130;
            v130 = 256l * v123;
            long v131;
            v131 = v130 + v20;
            cooperative_groups::memcpy_async(v4, v2 + v131, v22 + v129, sizeof(float) * 32l);
            v121 += v119 ;
        }
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
options.append('--define-macro=NDEBUG')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
from max_blocks_per_sm import max_blocks_per_sm
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
    v6 = cp.random.normal(0,1,65536,cp.float32)
    v7 = v6.size
    v8 = 65536 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.random.normal(0,1,65536,cp.float32)
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
    v18 = v12.reshape((256, 256))
    v19 = v6.reshape((256, 256))
    v20 = cp.transpose(v19)
    del v19
    v21 = v0.reshape((256, 256))
    del v21
    v22 = (cp.matmul(v18,v20)).flatten()
    del v18, v20
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
    raw_module.get_function(f"entry{v28}")((24, 1, 1),(128, 1, 1),(v12, v6, v0))
    del v6, v12, v28
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),128,is_print=True)
    v29 = cp.max(cp.abs(v0-v22))
    del v0, v22
    return v29

if __name__ == '__main__': print(main())
