kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 1l;
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
    auto v3 = this_thread_block();
    long v4;
    v4 = grid_group::num_blocks();
    long v5;
    v5 = grid_group::block_rank();
    long v6;
    v6 = v5;
    while (while_method_0(v6)){
        long v8;
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
        long v13;
        v13 = 1024l * v8;
        assert(0 <= v8 && v8 < 1l /* Tensor range check */);
        assert(0 <= v8 && v8 < 1l /* Tensor range check */);
        assert(0 <= v8 && v8 < 1l /* Tensor range check */);
        long v14;
        v14 = 32l * v8;
        long v15;
        v15 = v13 + v14;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v16;
        __shared__ float v17[1536l];
        long v18;
        v18 = thread_block::num_threads();
        long v19;
        v19 = thread_block::thread_rank();
        long v20;
        v20 = v19;
        while (while_method_1(v20)){
            long v22;
            v22 = v20 % 32l;
            long v23;
            v23 = v20 / 32l;
            long v24;
            v24 = v23 % 32l;
            long v25;
            v25 = v23 / 32l;
            bool v26;
            v26 = v25 == 0l;
            bool v27;
            v27 = v26 == false;
            if (v27){
                const char * v28;
                v28 = "The index has to be in the range of the dimension.";
                assert(v26 /* v28 */);
            } else {
            }
            assert(0 <= v24 && v24 < 32l /* Tensor range check */);
            long v30;
            v30 = 32l * v24;
            long v31;
            v31 = v30 + v15;
            assert(0 <= v24 && v24 < 32l /* Tensor range check */);
            long v32;
            v32 = 48l * v24;
            cooperative_groups::memcpy_async(v3, v17 + v32, v2 + v31, sizeof(float) * 32l);
            cooperative_groups::wait(v3);
            v20 += v18 ;
        }
        long v33;
        v33 = 0l;
        while (while_method_0(v33)){
            long v35;
            v35 = v33 % 1l;
            bool v36;
            v36 = v33 == 0l;
            bool v37;
            v37 = v36 == false;
            if (v37){
                const char * v38;
                v38 = "The index has to be in the range of the dimension.";
                assert(v36 /* v38 */);
            } else {
            }
            bool v40;
            v40 = v35 == 0l;
            float v41;
            if (v40){
                v41 = 0.0f;
            } else {
                v41 = 1.0f;
            }
            assert(0 <= v35 && v35 < 1l /* Tensor range check */);
            long v42;
            v42 = 32l * v35;
            long v43;
            v43 = v42 + v13;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v44;
            __shared__ float v45[1280l];
            long v46;
            v46 = thread_block::num_threads();
            long v47;
            v47 = thread_block::thread_rank();
            long v48;
            v48 = v47;
            while (while_method_1(v48)){
                long v50;
                v50 = v48 % 32l;
                long v51;
                v51 = v48 / 32l;
                long v52;
                v52 = v51 % 32l;
                long v53;
                v53 = v51 / 32l;
                bool v54;
                v54 = v53 == 0l;
                bool v55;
                v55 = v54 == false;
                if (v55){
                    const char * v56;
                    v56 = "The index has to be in the range of the dimension.";
                    assert(v54 /* v56 */);
                } else {
                }
                assert(0 <= v52 && v52 < 32l /* Tensor range check */);
                long v58;
                v58 = 32l * v52;
                long v59;
                v59 = v58 + v43;
                assert(0 <= v52 && v52 < 32l /* Tensor range check */);
                long v60;
                v60 = 40l * v52;
                cooperative_groups::memcpy_async(v3, v45 + v60, v0 + v59, sizeof(float) * 32l);
                cooperative_groups::wait(v3);
                v48 += v46 ;
            }
            assert(0 <= v35 && v35 < 1l /* Tensor range check */);
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v61;
            __shared__ float v62[1280l];
            long v63;
            v63 = thread_block::num_threads();
            long v64;
            v64 = thread_block::thread_rank();
            long v65;
            v65 = v64;
            while (while_method_1(v65)){
                long v67;
                v67 = v65 % 32l;
                long v68;
                v68 = v65 / 32l;
                long v69;
                v69 = v68 % 32l;
                long v70;
                v70 = v68 / 32l;
                bool v71;
                v71 = v70 == 0l;
                bool v72;
                v72 = v71 == false;
                if (v72){
                    const char * v73;
                    v73 = "The index has to be in the range of the dimension.";
                    assert(v71 /* v73 */);
                } else {
                }
                assert(0 <= v69 && v69 < 32l /* Tensor range check */);
                long v75;
                v75 = 32l * v69;
                long v76;
                v76 = v75 + v43;
                assert(0 <= v69 && v69 < 32l /* Tensor range check */);
                long v77;
                v77 = 40l * v69;
                cooperative_groups::memcpy_async(v3, v62 + v77, v1 + v76, sizeof(float) * 32l);
                cooperative_groups::wait(v3);
                v65 += v63 ;
            }
            long v78;
            v78 = grid_group::thread_rank();
            bool v79;
            v79 = v78 == 0l;
            if (v79){
                const char * v80;
                v80 = "%s";
                const char * v81;
                v81 = "[";
                printf(v80,v81);
                long v83;
                v83 = 0l;
                long v84;
                v84 = 0l;
                while (while_method_1(v84)){
                    long v86;
                    v86 = v84 % 32l;
                    long v87;
                    v87 = v84 / 32l;
                    long v88;
                    v88 = v87 % 32l;
                    long v89;
                    v89 = v87 / 32l;
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
                    assert(0 <= v88 && v88 < 32l /* Tensor range check */);
                    assert(0 <= v86 && v86 < 32l /* Tensor range check */);
                    long v94;
                    v94 = 40l * v88;
                    long v95;
                    v95 = v94 + v86;
                    float v96;
                    v96 = v45[v95];
                    float v97;
                    v97 = v62[v95];
                    const char * v98;
                    v98 = "%f";
                    printf(v98,v96);
                    const char * v99;
                    v99 = "%s";
                    const char * v100;
                    v100 = ", ";
                    printf(v99,v100);
                    const char * v102;
                    v102 = "%f";
                    printf(v102,v97);
                    long v103;
                    v103 = v83 + 1l;
                    v83 = v103;
                    bool v104;
                    v104 = v83 >= 100l;
                    if (v104){
                        const char * v105;
                        v105 = "%s";
                        const char * v106;
                        v106 = "; ...";
                        printf(v105,v106);
                        break;
                    } else {
                    }
                    bool v108;
                    v108 = v83 < 1024l;
                    if (v108){
                        const char * v109;
                        v109 = "%s";
                        const char * v110;
                        v110 = "; ";
                        printf(v109,v110);
                    } else {
                    }
                    v84 += 1l ;
                }
                const char * v112;
                v112 = "%s";
                const char * v113;
                v113 = "]";
                printf(v112,v113);
                printf("\n");
            } else {
            }
            __syncthreads();
            long v115;
            v115 = thread_block::num_threads() / warpSize;
            long v116;
            v116 = thread_block::thread_rank() / warpSize;
            long v117;
            v117 = v116;
            while (while_method_2(v117)){
                long v119;
                v119 = v117 % 2l;
                long v120;
                v120 = v117 / 2l;
                long v121;
                v121 = v120 % 2l;
                long v122;
                v122 = v120 / 2l;
                bool v123;
                v123 = v122 == 0l;
                bool v124;
                v124 = v123 == false;
                if (v124){
                    const char * v125;
                    v125 = "The index has to be in the range of the dimension.";
                    assert(v123 /* v125 */);
                } else {
                }
                assert(0 <= v121 && v121 < 2l /* Tensor range check */);
                long v127;
                v127 = 640l * v121;
                assert(0 <= v119 && v119 < 2l /* Tensor range check */);
                long v128;
                v128 = 640l * v119;
                assert(0 <= v121 && v121 < 2l /* Tensor range check */);
                assert(0 <= v119 && v119 < 2l /* Tensor range check */);
                long v129;
                v129 = 16l * v119;
                long v130;
                v130 = 768l * v121;
                long v131;
                v131 = v130 + v129;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v132;
                wmma::fill_fragment(v132, 0.0f);
                long v133;
                v133 = 0l;
                while (while_method_2(v133)){
                    long v135;
                    v135 = v133 % 4l;
                    long v136;
                    v136 = v133 / 4l;
                    bool v137;
                    v137 = v136 == 0l;
                    bool v138;
                    v138 = v137 == false;
                    if (v138){
                        const char * v139;
                        v139 = "The index has to be in the range of the dimension.";
                        assert(v137 /* v139 */);
                    } else {
                    }
                    assert(0 <= v135 && v135 < 4l /* Tensor range check */);
                    long v141;
                    v141 = 8l * v135;
                    long v142;
                    v142 = v141 + v127;
                    assert(0 <= v135 && v135 < 4l /* Tensor range check */);
                    long v143;
                    v143 = v141 + v128;
                    float * v144;
                    v144 = v45 + v142;
                    wmma::load_matrix_sync(v44, v144, 40l);
                    #pragma unroll
                    for (int t = 0; t < v44.num_elements; t++) { v44.x[t] = wmma::__float_to_tf32(v44.x[t]); };
                    float * v145;
                    v145 = v62 + v143;
                    wmma::load_matrix_sync(v61, v145, 40l);
                    #pragma unroll
                    for (int t = 0; t < v61.num_elements; t++) { v61.x[t] = wmma::__float_to_tf32(v61.x[t]); };
                    wmma::mma_sync(v132, v44, v61, v132);
                    v133 += 1l ;
                }
                float * v146;
                v146 = v17 + v131;
                wmma::load_matrix_sync(v16, v146, 48l, wmma::mem_row_major);
                long v147;
                v147 = v16.num_elements;
                long v148;
                v148 = 0l;
                while (while_method_3(v147, v148)){
                    float v150;
                    v150 = v132.x[v148];
                    float v151;
                    v151 = v16.x[v148];
                    float v152;
                    v152 = v41 * v151;
                    float v153;
                    v153 = v150 + v152;
                    v16.x[v148] = v153;
                    v148 += 1l ;
                }
                float * v154;
                v154 = v17 + v131;
                wmma::store_matrix_sync(v154, v16, 48l, wmma::mem_row_major);
                v117 += v115 ;
            }
            v33 += 1l ;
        }
        long v155;
        v155 = thread_block::num_threads();
        long v156;
        v156 = thread_block::thread_rank();
        long v157;
        v157 = v156;
        while (while_method_1(v157)){
            long v159;
            v159 = v157 % 32l;
            long v160;
            v160 = v157 / 32l;
            long v161;
            v161 = v160 % 32l;
            long v162;
            v162 = v160 / 32l;
            bool v163;
            v163 = v162 == 0l;
            bool v164;
            v164 = v163 == false;
            if (v164){
                const char * v165;
                v165 = "The index has to be in the range of the dimension.";
                assert(v163 /* v165 */);
            } else {
            }
            assert(0 <= v161 && v161 < 32l /* Tensor range check */);
            long v167;
            v167 = 48l * v161;
            assert(0 <= v161 && v161 < 32l /* Tensor range check */);
            long v168;
            v168 = 32l * v161;
            long v169;
            v169 = v168 + v15;
            cooperative_groups::memcpy_async(v3, v2 + v169, v17 + v167, sizeof(float) * 32l);
            cooperative_groups::wait(v3);
            v157 += v155 ;
        }
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
def method0(v0 : i32) -> bool:
    v1 = v0 < 1024
    del v0
    return v1
def main():
    v0 = cp.random.normal(0,1,1024,cp.float32)
    v1 = v0.size
    v2 = 1024 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,1024,cp.float32)
    v7 = v6.size
    v8 = 1024 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.random.normal(0,1,1024,cp.float32)
    v13 = v12.size
    v14 = 1024 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = v12.reshape((32, 32))
    v19 = v6.reshape((32, 32))
    v20 = cp.transpose(v19)
    del v19
    v21 = v0.reshape((32, 32))
    del v21
    v22 = (cp.matmul(v18,v20)).flatten()
    del v18, v20
    v23 = v22.size
    v24 = 1024 == v23
    del v23
    v25 = v24 == False
    if v25:
        v27 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v24, v27
        del v27
    else:
        pass
    del v24, v25
    v30 = "["
    print(v30, end="")
    del v30
    v31 = 0
    v32 = 0
    while method0(v32):
        v34 = v32 % 32
        v35 = v32 // 32
        v36 = v35 % 32
        v37 = v35 // 32
        del v35
        v38 = v37 == 0
        del v37
        v39 = v38 == False
        if v39:
            v41 = "The index has to be in the range of the dimension."
            assert v38, v41
            del v41
        else:
            pass
        del v38, v39
        assert 0 <= v36 < 32, 'Tensor range check'
        assert 0 <= v34 < 32, 'Tensor range check'
        v42 = 32 * v36
        del v36
        v43 = v42 + v34
        del v34, v42
        v44 = v12[v43].item()
        v45 = v6[v43].item()
        del v43
        print("{:.6f}".format(v44), end="")
        del v44
        v49 = ", "
        print(v49, end="")
        del v49
        print("{:.6f}".format(v45), end="")
        del v45
        v51 = v31 + 1
        v31 = v51
        del v51
        v52 = v31 >= 100
        if v52:
            v55 = "; ..."
            print(v55, end="")
            del v55
            break
        else:
            pass
        del v52
        v56 = v31 < 1024
        if v56:
            v59 = "; "
            print(v59, end="")
            del v59
        else:
            pass
        del v56
        v32 += 1 
    del v31, v32
    v62 = "]"
    print(v62, end="")
    del v62
    print()
    v63 = 0
    raw_module.get_function(f"entry{v63}")((24, 1, 1),(256, 1, 1),(v12, v6, v0))
    del v6, v12, v63
    v64 = cp.max(cp.abs(v0-v22))
    del v0, v22
    return v64

if __name__ == '__main__': print(main())
