kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 1024l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ inline bool while_method_3(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    long v4;
    v4 = grid_group::num_blocks();
    long v5;
    v5 = grid_group::block_rank();
    long v6;
    v6 = v5;
    while (while_method_0(v6)){
        long v8;
        v8 = v6 % 2l;
        long v9;
        v9 = v6 / 2l;
        long v10;
        v10 = v9 % 2l;
        long v11;
        v11 = v9 / 2l;
        bool v12;
        v12 = v11 == 0l;
        bool v13;
        v13 = v12 == false;
        if (v13){
            const char * v14;
            v14 = "The index has to be in the range of the dimension.";
            assert(v12 /* v14 */);
        } else {
        }
        assert(0 <= v10 && v10 < 2l /* Tensor range check */);
        long v16;
        v16 = 2048l * v10;
        assert(0 <= v8 && v8 < 2l /* Tensor range check */);
        long v17;
        v17 = 32l * v8;
        assert(0 <= v10 && v10 < 2l /* Tensor range check */);
        assert(0 <= v8 && v8 < 2l /* Tensor range check */);
        long v18;
        v18 = v16 + v17;
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
            v33 = 64l * v27;
            long v34;
            v34 = v33 + v18;
            assert(0 <= v27 && v27 < 32l /* Tensor range check */);
            long v35;
            v35 = 48l * v27;
            cooperative_groups::memcpy_async(v3, v20 + v35, v2 + v34, sizeof(float) * 32l);
            v23 += v21 ;
        }
        long v36;
        v36 = 0l;
        while (while_method_2(v36)){
            long v38;
            v38 = v36 % 2l;
            long v39;
            v39 = v36 / 2l;
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
            assert(0 <= v38 && v38 < 2l /* Tensor range check */);
            long v46;
            v46 = 32l * v38;
            long v47;
            v47 = v46 + v16;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v48;
            __shared__ float v49[1280l];
            long v50;
            v50 = thread_block::num_threads();
            long v51;
            v51 = thread_block::thread_rank();
            long v52;
            v52 = v51;
            while (while_method_1(v52)){
                long v54;
                v54 = v52 % 32l;
                long v55;
                v55 = v52 / 32l;
                long v56;
                v56 = v55 % 32l;
                long v57;
                v57 = v55 / 32l;
                bool v58;
                v58 = v57 == 0l;
                bool v59;
                v59 = v58 == false;
                if (v59){
                    const char * v60;
                    v60 = "The index has to be in the range of the dimension.";
                    assert(v58 /* v60 */);
                } else {
                }
                assert(0 <= v56 && v56 < 32l /* Tensor range check */);
                long v62;
                v62 = 64l * v56;
                long v63;
                v63 = v62 + v47;
                assert(0 <= v56 && v56 < 32l /* Tensor range check */);
                long v64;
                v64 = 40l * v56;
                cooperative_groups::memcpy_async(v3, v49 + v64, v0 + v63, sizeof(float) * 32l);
                v52 += v50 ;
            }
            assert(0 <= v38 && v38 < 2l /* Tensor range check */);
            long v65;
            v65 = 2048l * v38;
            long v66;
            v66 = v65 + v17;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v67;
            __shared__ float v68[1536l];
            long v69;
            v69 = thread_block::num_threads();
            long v70;
            v70 = thread_block::thread_rank();
            long v71;
            v71 = v70;
            while (while_method_1(v71)){
                long v73;
                v73 = v71 % 32l;
                long v74;
                v74 = v71 / 32l;
                long v75;
                v75 = v74 % 32l;
                long v76;
                v76 = v74 / 32l;
                bool v77;
                v77 = v76 == 0l;
                bool v78;
                v78 = v77 == false;
                if (v78){
                    const char * v79;
                    v79 = "The index has to be in the range of the dimension.";
                    assert(v77 /* v79 */);
                } else {
                }
                assert(0 <= v75 && v75 < 32l /* Tensor range check */);
                long v81;
                v81 = 64l * v75;
                long v82;
                v82 = v81 + v66;
                assert(0 <= v75 && v75 < 32l /* Tensor range check */);
                long v83;
                v83 = 48l * v75;
                cooperative_groups::memcpy_async(v3, v68 + v83, v1 + v82, sizeof(float) * 32l);
                v71 += v69 ;
            }
            cooperative_groups::wait(v3);
            long v84;
            v84 = thread_block::num_threads() / warpSize;
            long v85;
            v85 = thread_block::thread_rank() / warpSize;
            long v86;
            v86 = v85;
            while (while_method_0(v86)){
                long v88;
                v88 = v86 % 2l;
                long v89;
                v89 = v86 / 2l;
                long v90;
                v90 = v89 % 2l;
                long v91;
                v91 = v89 / 2l;
                bool v92;
                v92 = v91 == 0l;
                bool v93;
                v93 = v92 == false;
                if (v93){
                    const char * v94;
                    v94 = "The index has to be in the range of the dimension.";
                    assert(v92 /* v94 */);
                } else {
                }
                assert(0 <= v90 && v90 < 2l /* Tensor range check */);
                long v96;
                v96 = 640l * v90;
                assert(0 <= v88 && v88 < 2l /* Tensor range check */);
                long v97;
                v97 = 16l * v88;
                assert(0 <= v90 && v90 < 2l /* Tensor range check */);
                assert(0 <= v88 && v88 < 2l /* Tensor range check */);
                long v98;
                v98 = 768l * v90;
                long v99;
                v99 = v98 + v97;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v100;
                wmma::fill_fragment(v100, 0.0f);
                long v101;
                v101 = 0l;
                while (while_method_0(v101)){
                    long v103;
                    v103 = v101 % 4l;
                    long v104;
                    v104 = v101 / 4l;
                    bool v105;
                    v105 = v104 == 0l;
                    bool v106;
                    v106 = v105 == false;
                    if (v106){
                        const char * v107;
                        v107 = "The index has to be in the range of the dimension.";
                        assert(v105 /* v107 */);
                    } else {
                    }
                    assert(0 <= v103 && v103 < 4l /* Tensor range check */);
                    long v109;
                    v109 = 8l * v103;
                    long v110;
                    v110 = v109 + v96;
                    assert(0 <= v103 && v103 < 4l /* Tensor range check */);
                    long v111;
                    v111 = 384l * v103;
                    long v112;
                    v112 = v111 + v97;
                    float * v113;
                    v113 = v49 + v110;
                    wmma::load_matrix_sync(v48, v113, 40l);
                    #pragma unroll
                    for (int t = 0; t < v48.num_elements; t++) { v48.x[t] = wmma::__float_to_tf32(v48.x[t]); };
                    float * v114;
                    v114 = v68 + v112;
                    wmma::load_matrix_sync(v67, v114, 48l);
                    #pragma unroll
                    for (int t = 0; t < v67.num_elements; t++) { v67.x[t] = wmma::__float_to_tf32(v67.x[t]); };
                    wmma::mma_sync(v100, v48, v67, v100);
                    v101 += 1l ;
                }
                float * v115;
                v115 = v20 + v99;
                wmma::load_matrix_sync(v19, v115, 48l, wmma::mem_row_major);
                long v116;
                v116 = v19.num_elements;
                long v117;
                v117 = 0l;
                while (while_method_3(v116, v117)){
                    float v119;
                    v119 = v100.x[v117];
                    float v120;
                    v120 = v19.x[v117];
                    float v121;
                    v121 = v45 * v120;
                    float v122;
                    v122 = v119 + v121;
                    v19.x[v117] = v122;
                    v117 += 1l ;
                }
                float * v123;
                v123 = v20 + v99;
                wmma::store_matrix_sync(v123, v19, 48l, wmma::mem_row_major);
                v86 += v84 ;
            }
            v36 += 1l ;
        }
        cooperative_groups::wait(v3);
        long v124;
        v124 = thread_block::num_threads();
        long v125;
        v125 = thread_block::thread_rank();
        long v126;
        v126 = v125;
        while (while_method_1(v126)){
            long v128;
            v128 = v126 % 32l;
            long v129;
            v129 = v126 / 32l;
            long v130;
            v130 = v129 % 32l;
            long v131;
            v131 = v129 / 32l;
            bool v132;
            v132 = v131 == 0l;
            bool v133;
            v133 = v132 == false;
            if (v133){
                const char * v134;
                v134 = "The index has to be in the range of the dimension.";
                assert(v132 /* v134 */);
            } else {
            }
            assert(0 <= v130 && v130 < 32l /* Tensor range check */);
            long v136;
            v136 = 48l * v130;
            assert(0 <= v130 && v130 < 32l /* Tensor range check */);
            long v137;
            v137 = 64l * v130;
            long v138;
            v138 = v137 + v18;
            cooperative_groups::memcpy_async(v3, v2 + v138, v20 + v136, sizeof(float) * 32l);
            v126 += v124 ;
        }
        cooperative_groups::wait(v3);
        v6 += v4 ;
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
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
def main():
    v0 = cp.random.normal(0,1,4096,cp.float32)
    v1 = v0.size
    v2 = 4096 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,4096,cp.float32)
    v7 = v6.size
    v8 = 4096 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.random.normal(0,1,4096,cp.float32)
    v13 = v12.size
    v14 = 4096 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = v12.reshape((64, 64))
    v19 = v6.reshape((64, 64))
    v20 = v0.reshape((64, 64))
    del v20
    v21 = (cp.matmul(v18,v19)).flatten()
    del v18, v19
    v22 = v21.size
    v23 = 4096 == v22
    del v22
    v24 = v23 == False
    if v24:
        v26 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v23, v26
        del v26
    else:
        pass
    del v23, v24
    v27 = 0
    raw_module.get_function(f"entry{v27}")((24, 1, 1),(256, 1, 1),(v12, v6, v0))
    del v27
    print(v12[:50])
    del v12
    print(v6[:50])
    del v6
    v28 = cp.max(cp.abs(v0-v21))
    del v0, v21
    return v28

if __name__ == '__main__': print(main())
