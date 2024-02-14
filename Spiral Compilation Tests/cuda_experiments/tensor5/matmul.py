kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 8l;
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
    v1 = v0 < 2048l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_5(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    thread_block_tile<1l, thread_block> v4 = tiled_partition<1l>(v3);
    extern __shared__ unsigned char v5[];
    float * v8;
    float * v6;
    v6 = reinterpret_cast<float *>(&v5[0ull]);
    v8 = v6;
    float * v11;
    float * v9;
    v9 = reinterpret_cast<float *>(&v5[17408ull]);
    v11 = v9;
    float * v14;
    float * v12;
    v12 = reinterpret_cast<float *>(&v5[0ull]);
    v14 = v12;
    long v15;
    v15 = grid_group::num_blocks();
    long v16;
    v16 = grid_group::block_rank();
    long v17;
    v17 = v16;
    while (while_method_0(v17)){
        long v19;
        v19 = v17 % 2l;
        long v20;
        v20 = v17 / 2l;
        long v21;
        v21 = v20 % 4l;
        long v22;
        v22 = v20 / 4l;
        bool v23;
        v23 = v22 == 0l;
        bool v24;
        v24 = v23 == false;
        if (v24){
            assert("The index has to be in the range of the dimension." && v23);
        } else {
        }
        assert("Tensor range check" && 0 <= v21 && v21 < 4l);
        long v26;
        v26 = 16384l * v21;
        assert("Tensor range check" && 0 <= v19 && v19 < 2l);
        long v27;
        v27 = 128l * v19;
        assert("Tensor range check" && 0 <= v21 && v21 < 4l);
        assert("Tensor range check" && 0 <= v19 && v19 < 2l);
        long v28;
        v28 = v26 + v27;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v29;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v30;
        wmma::fill_fragment(v30, 0.0f);
        long v31;
        v31 = 0l;
        while (while_method_1(v31)){
            long v33;
            v33 = v31 % 4l;
            long v34;
            v34 = v31 / 4l;
            bool v35;
            v35 = v34 == 0l;
            bool v36;
            v36 = v35 == false;
            if (v36){
                assert("The index has to be in the range of the dimension." && v35);
            } else {
            }
            assert("Tensor range check" && 0 <= v33 && v33 < 4l);
            long v38;
            v38 = 64l * v33;
            long v39;
            v39 = v38 + v26;
            assert("Tensor range check" && 0 <= v33 && v33 < 4l);
            long v40;
            v40 = 16384l * v33;
            long v41;
            v41 = v40 + v27;
            long v42;
            v42 = v4.meta_group_size();
            long v43;
            v43 = v4.meta_group_rank();
            long v44;
            v44 = v43;
            while (while_method_2(v44)){
                long v46;
                v46 = v44 % 2l;
                long v47;
                v47 = v44 / 2l;
                long v48;
                v48 = v47 % 8l;
                long v49;
                v49 = v47 / 8l;
                long v50;
                v50 = v49 % 16l;
                long v51;
                v51 = v49 / 16l;
                long v52;
                v52 = v51 % 4l;
                long v53;
                v53 = v51 / 4l;
                bool v54;
                v54 = v53 == 0l;
                bool v55;
                v55 = v54 == false;
                if (v55){
                    assert("The index has to be in the range of the dimension." && v54);
                } else {
                }
                assert("Tensor range check" && 0 <= v52 && v52 < 4l);
                assert("Tensor range check" && 0 <= v50 && v50 < 16l);
                assert("Tensor range check" && 0 <= v48 && v48 < 8l);
                assert("Tensor range check" && 0 <= v46 && v46 < 2l);
                long v57;
                v57 = 4l * v46;
                long v58;
                v58 = v57 + v39;
                long v59;
                v59 = 8l * v48;
                long v60;
                v60 = v59 + v58;
                long v61;
                v61 = 256l * v50;
                long v62;
                v62 = v61 + v60;
                long v63;
                v63 = 4096l * v52;
                long v64;
                v64 = v63 + v62;
                assert("Tensor range check" && 0 <= v52 && v52 < 4l);
                assert("Tensor range check" && 0 <= v50 && v50 < 16l);
                assert("Tensor range check" && 0 <= v48 && v48 < 8l);
                assert("Tensor range check" && 0 <= v46 && v46 < 2l);
                long v65;
                v65 = 136l * v48;
                long v66;
                v66 = v65 + v57;
                long v67;
                v67 = 8l * v50;
                long v68;
                v68 = v67 + v66;
                long v69;
                v69 = 1088l * v52;
                long v70;
                v70 = v69 + v68;
                cooperative_groups::memcpy_async(v4, v8 + v70, v0 + v64, sizeof(float) * 4l);
                v44 += v42 ;
            }
            long v71;
            v71 = v4.meta_group_size();
            long v72;
            v72 = v4.meta_group_rank();
            long v73;
            v73 = v72;
            while (while_method_3(v73)){
                long v75;
                v75 = v73 % 4l;
                long v76;
                v76 = v73 / 4l;
                long v77;
                v77 = v76 % 8l;
                long v78;
                v78 = v76 / 8l;
                long v79;
                v79 = v78 % 8l;
                long v80;
                v80 = v78 / 8l;
                long v81;
                v81 = v80 % 8l;
                long v82;
                v82 = v80 / 8l;
                bool v83;
                v83 = v82 == 0l;
                bool v84;
                v84 = v83 == false;
                if (v84){
                    assert("The index has to be in the range of the dimension." && v83);
                } else {
                }
                assert("Tensor range check" && 0 <= v81 && v81 < 8l);
                assert("Tensor range check" && 0 <= v79 && v79 < 8l);
                assert("Tensor range check" && 0 <= v77 && v77 < 8l);
                assert("Tensor range check" && 0 <= v75 && v75 < 4l);
                long v86;
                v86 = 4l * v75;
                long v87;
                v87 = v86 + v41;
                long v88;
                v88 = 16l * v77;
                long v89;
                v89 = v88 + v87;
                long v90;
                v90 = 256l * v79;
                long v91;
                v91 = v90 + v89;
                long v92;
                v92 = 2048l * v81;
                long v93;
                v93 = v92 + v91;
                assert("Tensor range check" && 0 <= v81 && v81 < 8l);
                assert("Tensor range check" && 0 <= v79 && v79 < 8l);
                assert("Tensor range check" && 0 <= v77 && v77 < 8l);
                assert("Tensor range check" && 0 <= v75 && v75 < 4l);
                long v94;
                v94 = 144l * v77;
                long v95;
                v95 = v94 + v86;
                long v96;
                v96 = 16l * v79;
                long v97;
                v97 = v96 + v95;
                long v98;
                v98 = 1152l * v81;
                long v99;
                v99 = v98 + v97;
                cooperative_groups::memcpy_async(v4, v11 + v99, v1 + v93, sizeof(float) * 4l);
                v73 += v71 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v100;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v101;
            long v102;
            v102 = thread_block::num_threads() / warpSize;
            long v103;
            v103 = thread_block::thread_rank() / warpSize;
            long v104;
            v104 = v103;
            while (while_method_4(v104)){
                long v106;
                v106 = v104 % 8l;
                long v107;
                v107 = v104 / 8l;
                long v108;
                v108 = v107 % 4l;
                long v109;
                v109 = v107 / 4l;
                bool v110;
                v110 = v109 == 0l;
                bool v111;
                v111 = v110 == false;
                if (v111){
                    assert("The index has to be in the range of the dimension." && v110);
                } else {
                }
                assert("Tensor range check" && 0 <= v108 && v108 < 4l);
                long v113;
                v113 = 1088l * v108;
                assert("Tensor range check" && 0 <= v106 && v106 < 8l);
                long v114;
                v114 = 144l * v106;
                long v115;
                v115 = 0l;
                while (while_method_0(v115)){
                    long v117;
                    v117 = v115 % 8l;
                    long v118;
                    v118 = v115 / 8l;
                    bool v119;
                    v119 = v118 == 0l;
                    bool v120;
                    v120 = v119 == false;
                    if (v120){
                        assert("The index has to be in the range of the dimension." && v119);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v117 && v117 < 8l);
                    long v122;
                    v122 = 136l * v117;
                    long v123;
                    v123 = v122 + v113;
                    assert("Tensor range check" && 0 <= v117 && v117 < 8l);
                    long v124;
                    v124 = 1152l * v117;
                    long v125;
                    v125 = v124 + v114;
                    float * v126;
                    v126 = v8 + v123;
                    wmma::load_matrix_sync(v100, v126, 8l);
                    #pragma unroll
                    for (int t = 0; t < v100.num_elements; t++) { v100.x[t] = wmma::__float_to_tf32(v100.x[t]); };
                    float * v127;
                    v127 = v11 + v125;
                    wmma::load_matrix_sync(v101, v127, 16l);
                    #pragma unroll
                    for (int t = 0; t < v101.num_elements; t++) { v101.x[t] = wmma::__float_to_tf32(v101.x[t]); };
                    wmma::mma_sync(v30, v100, v101, v30);
                    v115 += 1l ;
                }
                v104 += v102 ;
            }
            v3.sync() ;
            v31 += 1l ;
        }
        long v128;
        v128 = v4.meta_group_size();
        long v129;
        v129 = v4.meta_group_rank();
        long v130;
        v130 = v129;
        while (while_method_3(v130)){
            long v132;
            v132 = v130 % 4l;
            long v133;
            v133 = v130 / 4l;
            long v134;
            v134 = v133 % 8l;
            long v135;
            v135 = v133 / 8l;
            long v136;
            v136 = v135 % 16l;
            long v137;
            v137 = v135 / 16l;
            long v138;
            v138 = v137 % 4l;
            long v139;
            v139 = v137 / 4l;
            bool v140;
            v140 = v139 == 0l;
            bool v141;
            v141 = v140 == false;
            if (v141){
                assert("The index has to be in the range of the dimension." && v140);
            } else {
            }
            assert("Tensor range check" && 0 <= v138 && v138 < 4l);
            assert("Tensor range check" && 0 <= v136 && v136 < 16l);
            assert("Tensor range check" && 0 <= v134 && v134 < 8l);
            assert("Tensor range check" && 0 <= v132 && v132 < 4l);
            long v143;
            v143 = 4l * v132;
            long v144;
            v144 = v143 + v28;
            long v145;
            v145 = 16l * v134;
            long v146;
            v146 = v145 + v144;
            long v147;
            v147 = 256l * v136;
            long v148;
            v148 = v147 + v146;
            long v149;
            v149 = 4096l * v138;
            long v150;
            v150 = v149 + v148;
            assert("Tensor range check" && 0 <= v138 && v138 < 4l);
            assert("Tensor range check" && 0 <= v136 && v136 < 16l);
            assert("Tensor range check" && 0 <= v134 && v134 < 8l);
            assert("Tensor range check" && 0 <= v132 && v132 < 4l);
            long v151;
            v151 = 272l * v134;
            long v152;
            v152 = v151 + v143;
            long v153;
            v153 = 16l * v136;
            long v154;
            v154 = v153 + v152;
            long v155;
            v155 = 2176l * v138;
            long v156;
            v156 = v155 + v154;
            cooperative_groups::memcpy_async(v4, v14 + v156, v2 + v150, sizeof(float) * 4l);
            v130 += v128 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v157;
        v157 = thread_block::num_threads() / warpSize;
        long v158;
        v158 = thread_block::thread_rank() / warpSize;
        long v159;
        v159 = v158;
        while (while_method_4(v159)){
            long v161;
            v161 = v159 % 8l;
            long v162;
            v162 = v159 / 8l;
            long v163;
            v163 = v162 % 4l;
            long v164;
            v164 = v162 / 4l;
            bool v165;
            v165 = v164 == 0l;
            bool v166;
            v166 = v165 == false;
            if (v166){
                assert("The index has to be in the range of the dimension." && v165);
            } else {
            }
            assert("Tensor range check" && 0 <= v163 && v163 < 4l);
            assert("Tensor range check" && 0 <= v161 && v161 < 8l);
            long v168;
            v168 = 272l * v161;
            long v169;
            v169 = 2176l * v163;
            long v170;
            v170 = v169 + v168;
            float * v171;
            v171 = v14 + v170;
            wmma::load_matrix_sync(v29, v171, 16l, wmma::mem_row_major);
            long v172;
            v172 = v29.num_elements;
            long v173;
            v173 = 0l;
            while (while_method_5(v172, v173)){
                float v175;
                v175 = v30.x[v173];
                float v176;
                v176 = v29.x[v173];
                float v177;
                v177 = 0.0f * v176;
                float v178;
                v178 = v175 + v177;
                v29.x[v173] = v178;
                v173 += 1l ;
            }
            float * v179;
            v179 = v14 + v170;
            wmma::store_matrix_sync(v179, v29, 16l, wmma::mem_row_major);
            v159 += v157 ;
        }
        v3.sync() ;
        long v180;
        v180 = v4.meta_group_size();
        long v181;
        v181 = v4.meta_group_rank();
        long v182;
        v182 = v181;
        while (while_method_3(v182)){
            long v184;
            v184 = v182 % 4l;
            long v185;
            v185 = v182 / 4l;
            long v186;
            v186 = v185 % 8l;
            long v187;
            v187 = v185 / 8l;
            long v188;
            v188 = v187 % 16l;
            long v189;
            v189 = v187 / 16l;
            long v190;
            v190 = v189 % 4l;
            long v191;
            v191 = v189 / 4l;
            bool v192;
            v192 = v191 == 0l;
            bool v193;
            v193 = v192 == false;
            if (v193){
                assert("The index has to be in the range of the dimension." && v192);
            } else {
            }
            assert("Tensor range check" && 0 <= v190 && v190 < 4l);
            assert("Tensor range check" && 0 <= v188 && v188 < 16l);
            assert("Tensor range check" && 0 <= v186 && v186 < 8l);
            assert("Tensor range check" && 0 <= v184 && v184 < 4l);
            long v195;
            v195 = 4l * v184;
            long v196;
            v196 = 272l * v186;
            long v197;
            v197 = v196 + v195;
            long v198;
            v198 = 16l * v188;
            long v199;
            v199 = v198 + v197;
            long v200;
            v200 = 2176l * v190;
            long v201;
            v201 = v200 + v199;
            assert("Tensor range check" && 0 <= v190 && v190 < 4l);
            assert("Tensor range check" && 0 <= v188 && v188 < 16l);
            assert("Tensor range check" && 0 <= v186 && v186 < 8l);
            assert("Tensor range check" && 0 <= v184 && v184 < 4l);
            long v202;
            v202 = v195 + v28;
            long v203;
            v203 = 16l * v186;
            long v204;
            v204 = v203 + v202;
            long v205;
            v205 = 256l * v188;
            long v206;
            v206 = v205 + v204;
            long v207;
            v207 = 4096l * v190;
            long v208;
            v208 = v207 + v206;
            cooperative_groups::memcpy_async(v4, v2 + v208, v14 + v201, sizeof(float) * 4l);
            v182 += v180 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        v17 += v15 ;
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
options.append('--define-macro=NDEBUG')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
from max_blocks_per_sm import max_blocks_per_sm
def main():
    v0 = cp.random.normal(0,1,65536,cp.float32)
    v1 = v0.size
    v2 = 65536 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,65536,cp.float32)
    v6 = v5.size
    v7 = 65536 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,65536,cp.float32)
    v11 = v10.size
    v12 = 65536 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = v10.reshape((256, 256))
    v16 = v5.reshape((256, 256))
    v17 = v0.reshape((256, 256))
    del v17
    v18 = (cp.matmul(v15,v16)).flatten()
    del v15, v16
    v19 = v18.size
    v20 = 65536 == v19
    del v19
    v21 = v20 == False
    if v21:
        v22 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v20, v22
        del v22
    else:
        pass
    del v20, v21
    v23 = 0
    v24 = raw_module.get_function(f"entry{v23}")
    del v23
    v24.max_dynamic_shared_size_bytes = 54272 
    v24((1,),(1024,),(v10, v5, v0),shared_mem=54272)
    del v5, v10, v24
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),1024,is_print=True)
    v25 = cp.max(cp.abs(v0-v18))
    del v0, v18
    return v25

if __name__ == '__main__': print(main())
