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
    v1 = v0 < 2048l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 64l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 4096l;
    return v1;
}
__device__ inline bool while_method_5(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    thread_block_tile<32l, thread_block> v4 = tiled_partition<32l>(v3);
    thread_block_tile<1l, thread_block> v5 = tiled_partition<1l>(v3);
    extern __shared__ unsigned char v6[];
    float * v9;
    float * v7;
    v7 = reinterpret_cast<float *>(&v6[0ull]);
    v9 = v7;
    float * v12;
    float * v10;
    v10 = reinterpret_cast<float *>(&v6[34816ull]);
    v12 = v10;
    float * v15;
    float * v13;
    v13 = reinterpret_cast<float *>(&v6[0ull]);
    v15 = v13;
    long v16;
    v16 = grid_group::num_blocks();
    long v17;
    v17 = grid_group::block_rank();
    long v18;
    v18 = v17;
    while (while_method_0(v18)){
        long v20;
        v20 = v18 % 2l;
        long v21;
        v21 = v18 / 2l;
        long v22;
        v22 = v21 % 2l;
        long v23;
        v23 = v21 / 2l;
        bool v24;
        v24 = v23 == 0l;
        bool v25;
        v25 = v24 == false;
        if (v25){
            assert("The index has to be in the range of the dimension." && v24);
        } else {
        }
        assert("Tensor range check" && 0 <= v22 && v22 < 2l);
        long v27;
        v27 = 32768l * v22;
        assert("Tensor range check" && 0 <= v20 && v20 < 2l);
        long v28;
        v28 = 128l * v20;
        assert("Tensor range check" && 0 <= v22 && v22 < 2l);
        assert("Tensor range check" && 0 <= v20 && v20 < 2l);
        long v29;
        v29 = v27 + v28;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v30[4l];
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v31[4l];
        long v32;
        v32 = 0l;
        while (while_method_0(v32)){
            long v34;
            v34 = v32 % 1l;
            long v35;
            v35 = v32 % 4l;
            long v36;
            v36 = v32 / 4l;
            bool v37;
            v37 = v36 == 0l;
            bool v38;
            v38 = v37 == false;
            if (v38){
                assert("The index has to be in the range of the dimension." && v37);
            } else {
            }
            assert("Tensor range check" && 0 <= v35 && v35 < 4l);
            assert("Tensor range check" && 0 <= v34 && v34 < 1l);
            long v40;
            v40 = v35 + v34;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v41 = v31[v40];
            wmma::fill_fragment(v41, 0.0f);
            v32 += 1l ;
        }
        long v42;
        v42 = 0l;
        while (while_method_0(v42)){
            long v44;
            v44 = v42 % 4l;
            long v45;
            v45 = v42 / 4l;
            bool v46;
            v46 = v45 == 0l;
            bool v47;
            v47 = v46 == false;
            if (v47){
                assert("The index has to be in the range of the dimension." && v46);
            } else {
            }
            assert("Tensor range check" && 0 <= v44 && v44 < 4l);
            long v49;
            v49 = 64l * v44;
            long v50;
            v50 = v49 + v27;
            assert("Tensor range check" && 0 <= v44 && v44 < 4l);
            long v51;
            v51 = 16384l * v44;
            long v52;
            v52 = v51 + v28;
            long v53;
            v53 = v5.meta_group_size();
            long v54;
            v54 = v5.meta_group_rank();
            long v55;
            v55 = v54;
            while (while_method_1(v55)){
                long v57;
                v57 = v55 % 2l;
                long v58;
                v58 = v55 / 2l;
                long v59;
                v59 = v58 % 8l;
                long v60;
                v60 = v58 / 8l;
                long v61;
                v61 = v60 % 16l;
                long v62;
                v62 = v60 / 16l;
                long v63;
                v63 = v62 % 8l;
                long v64;
                v64 = v62 / 8l;
                bool v65;
                v65 = v64 == 0l;
                bool v66;
                v66 = v65 == false;
                if (v66){
                    assert("The index has to be in the range of the dimension." && v65);
                } else {
                }
                assert("Tensor range check" && 0 <= v63 && v63 < 8l);
                assert("Tensor range check" && 0 <= v61 && v61 < 16l);
                assert("Tensor range check" && 0 <= v59 && v59 < 8l);
                assert("Tensor range check" && 0 <= v57 && v57 < 2l);
                long v68;
                v68 = 4l * v57;
                long v69;
                v69 = v68 + v50;
                long v70;
                v70 = 8l * v59;
                long v71;
                v71 = v70 + v69;
                long v72;
                v72 = 256l * v61;
                long v73;
                v73 = v72 + v71;
                long v74;
                v74 = 4096l * v63;
                long v75;
                v75 = v74 + v73;
                assert("Tensor range check" && 0 <= v63 && v63 < 8l);
                assert("Tensor range check" && 0 <= v61 && v61 < 16l);
                assert("Tensor range check" && 0 <= v59 && v59 < 8l);
                assert("Tensor range check" && 0 <= v57 && v57 < 2l);
                long v76;
                v76 = 136l * v59;
                long v77;
                v77 = v76 + v68;
                long v78;
                v78 = 8l * v61;
                long v79;
                v79 = v78 + v77;
                long v80;
                v80 = 1088l * v63;
                long v81;
                v81 = v80 + v79;
                cooperative_groups::memcpy_async(v5, v9 + v81, v0 + v75, sizeof(float) * 4l);
                v55 += v53 ;
            }
            long v82;
            v82 = v5.meta_group_size();
            long v83;
            v83 = v5.meta_group_rank();
            long v84;
            v84 = v83;
            while (while_method_1(v84)){
                long v86;
                v86 = v84 % 4l;
                long v87;
                v87 = v84 / 4l;
                long v88;
                v88 = v87 % 8l;
                long v89;
                v89 = v87 / 8l;
                long v90;
                v90 = v89 % 8l;
                long v91;
                v91 = v89 / 8l;
                long v92;
                v92 = v91 % 8l;
                long v93;
                v93 = v91 / 8l;
                bool v94;
                v94 = v93 == 0l;
                bool v95;
                v95 = v94 == false;
                if (v95){
                    assert("The index has to be in the range of the dimension." && v94);
                } else {
                }
                assert("Tensor range check" && 0 <= v92 && v92 < 8l);
                assert("Tensor range check" && 0 <= v90 && v90 < 8l);
                assert("Tensor range check" && 0 <= v88 && v88 < 8l);
                assert("Tensor range check" && 0 <= v86 && v86 < 4l);
                long v97;
                v97 = 4l * v86;
                long v98;
                v98 = v97 + v52;
                long v99;
                v99 = 16l * v88;
                long v100;
                v100 = v99 + v98;
                long v101;
                v101 = 256l * v90;
                long v102;
                v102 = v101 + v100;
                long v103;
                v103 = 2048l * v92;
                long v104;
                v104 = v103 + v102;
                assert("Tensor range check" && 0 <= v92 && v92 < 8l);
                assert("Tensor range check" && 0 <= v90 && v90 < 8l);
                assert("Tensor range check" && 0 <= v88 && v88 < 8l);
                assert("Tensor range check" && 0 <= v86 && v86 < 4l);
                long v105;
                v105 = 144l * v88;
                long v106;
                v106 = v105 + v97;
                long v107;
                v107 = 16l * v90;
                long v108;
                v108 = v107 + v106;
                long v109;
                v109 = 1152l * v92;
                long v110;
                v110 = v109 + v108;
                cooperative_groups::memcpy_async(v5, v12 + v110, v1 + v104, sizeof(float) * 4l);
                v84 += v82 ;
            }
            cooperative_groups::wait(v5);
            v3.sync() ;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v111;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v112 = v111;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v113;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v114 = v113;
            long v115;
            v115 = thread_block::num_threads() / warpSize;
            long v116;
            v116 = thread_block::thread_rank() / warpSize;
            long v117;
            v117 = v116;
            while (while_method_2(v117)){
                long v119;
                v119 = v117 % 8l;
                long v120;
                v120 = v117 / 8l;
                long v121;
                v121 = v120 % 8l;
                long v122;
                v122 = v120 / 8l;
                bool v123;
                v123 = v122 == 0l;
                bool v124;
                v124 = v123 == false;
                if (v124){
                    assert("The index has to be in the range of the dimension." && v123);
                } else {
                }
                assert("Tensor range check" && 0 <= v121 && v121 < 8l);
                long v126;
                v126 = 1088l * v121;
                assert("Tensor range check" && 0 <= v119 && v119 < 8l);
                long v127;
                v127 = 144l * v119;
                long v128;
                v128 = v121 / 2l;
                long v129;
                v129 = v119 / 8l;
                assert("Tensor range check" && 0 <= v128 && v128 < 4l);
                assert("Tensor range check" && 0 <= v129 && v129 < 1l);
                long v130;
                v130 = v128 + v129;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v131 = v31[v130];
                long v132;
                v132 = 0l;
                while (while_method_3(v132)){
                    long v134;
                    v134 = v132 % 8l;
                    long v135;
                    v135 = v132 / 8l;
                    bool v136;
                    v136 = v135 == 0l;
                    bool v137;
                    v137 = v136 == false;
                    if (v137){
                        assert("The index has to be in the range of the dimension." && v136);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v134 && v134 < 8l);
                    long v139;
                    v139 = 136l * v134;
                    long v140;
                    v140 = v139 + v126;
                    assert("Tensor range check" && 0 <= v134 && v134 < 8l);
                    long v141;
                    v141 = 1152l * v134;
                    long v142;
                    v142 = v141 + v127;
                    float * v143;
                    v143 = v9 + v140;
                    wmma::load_matrix_sync(v112, v143, 8l);
                    #pragma unroll
                    for (int t = 0; t < v112.num_elements; t++) { v112.x[t] = wmma::__float_to_tf32(v112.x[t]); };
                    float * v144;
                    v144 = v12 + v142;
                    wmma::load_matrix_sync(v114, v144, 16l);
                    #pragma unroll
                    for (int t = 0; t < v114.num_elements; t++) { v114.x[t] = wmma::__float_to_tf32(v114.x[t]); };
                    wmma::mma_sync(v131, v112, v114, v131);
                    v132 += 1l ;
                }
                v117 += v115 ;
            }
            v3.sync() ;
            v42 += 1l ;
        }
        long v145;
        v145 = v5.meta_group_size();
        long v146;
        v146 = v5.meta_group_rank();
        long v147;
        v147 = v146;
        while (while_method_4(v147)){
            long v149;
            v149 = v147 % 4l;
            long v150;
            v150 = v147 / 4l;
            long v151;
            v151 = v150 % 8l;
            long v152;
            v152 = v150 / 8l;
            long v153;
            v153 = v152 % 16l;
            long v154;
            v154 = v152 / 16l;
            long v155;
            v155 = v154 % 8l;
            long v156;
            v156 = v154 / 8l;
            bool v157;
            v157 = v156 == 0l;
            bool v158;
            v158 = v157 == false;
            if (v158){
                assert("The index has to be in the range of the dimension." && v157);
            } else {
            }
            assert("Tensor range check" && 0 <= v155 && v155 < 8l);
            assert("Tensor range check" && 0 <= v153 && v153 < 16l);
            assert("Tensor range check" && 0 <= v151 && v151 < 8l);
            assert("Tensor range check" && 0 <= v149 && v149 < 4l);
            long v160;
            v160 = 4l * v149;
            long v161;
            v161 = v160 + v29;
            long v162;
            v162 = 16l * v151;
            long v163;
            v163 = v162 + v161;
            long v164;
            v164 = 256l * v153;
            long v165;
            v165 = v164 + v163;
            long v166;
            v166 = 4096l * v155;
            long v167;
            v167 = v166 + v165;
            assert("Tensor range check" && 0 <= v155 && v155 < 8l);
            assert("Tensor range check" && 0 <= v153 && v153 < 16l);
            assert("Tensor range check" && 0 <= v151 && v151 < 8l);
            assert("Tensor range check" && 0 <= v149 && v149 < 4l);
            long v168;
            v168 = 272l * v151;
            long v169;
            v169 = v168 + v160;
            long v170;
            v170 = 16l * v153;
            long v171;
            v171 = v170 + v169;
            long v172;
            v172 = 2176l * v155;
            long v173;
            v173 = v172 + v171;
            cooperative_groups::memcpy_async(v5, v15 + v173, v2 + v167, sizeof(float) * 4l);
            v147 += v145 ;
        }
        cooperative_groups::wait(v5);
        v3.sync() ;
        long v174;
        v174 = thread_block::num_threads() / warpSize;
        long v175;
        v175 = thread_block::thread_rank() / warpSize;
        long v176;
        v176 = v175;
        while (while_method_2(v176)){
            long v178;
            v178 = v176 % 8l;
            long v179;
            v179 = v176 / 8l;
            long v180;
            v180 = v179 % 8l;
            long v181;
            v181 = v179 / 8l;
            bool v182;
            v182 = v181 == 0l;
            bool v183;
            v183 = v182 == false;
            if (v183){
                assert("The index has to be in the range of the dimension." && v182);
            } else {
            }
            assert("Tensor range check" && 0 <= v180 && v180 < 8l);
            assert("Tensor range check" && 0 <= v178 && v178 < 8l);
            long v185;
            v185 = 272l * v178;
            long v186;
            v186 = 2176l * v180;
            long v187;
            v187 = v186 + v185;
            long v188;
            v188 = v180 / 2l;
            long v189;
            v189 = v178 / 8l;
            assert("Tensor range check" && 0 <= v188 && v188 < 4l);
            assert("Tensor range check" && 0 <= v189 && v189 < 1l);
            long v190;
            v190 = v188 + v189;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v191 = v31[v190];
            assert("Tensor range check" && 0 <= v188 && v188 < 4l);
            assert("Tensor range check" && 0 <= v189 && v189 < 1l);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v192 = v30[v190];
            float * v193;
            v193 = v15 + v187;
            wmma::load_matrix_sync(v192, v193, 16l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v194 = v192;
            long v195;
            v195 = v194.num_elements;
            long v196;
            v196 = 0l;
            while (while_method_5(v195, v196)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v198 = v191;
                float v199;
                v199 = v198.x[v196];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v200 = v192;
                float v201;
                v201 = v200.x[v196];
                float v202;
                v202 = 0.0f * v201;
                float v203;
                v203 = v199 + v202;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v204 = v192;
                v204.x[v196] = v203;
                v196 += 1l ;
            }
            float * v205;
            v205 = v15 + v187;
            wmma::store_matrix_sync(v205, v192, 16l, wmma::mem_row_major);
            v176 += v174 ;
        }
        v3.sync() ;
        long v206;
        v206 = v5.meta_group_size();
        long v207;
        v207 = v5.meta_group_rank();
        long v208;
        v208 = v207;
        while (while_method_4(v208)){
            long v210;
            v210 = v208 % 4l;
            long v211;
            v211 = v208 / 4l;
            long v212;
            v212 = v211 % 8l;
            long v213;
            v213 = v211 / 8l;
            long v214;
            v214 = v213 % 16l;
            long v215;
            v215 = v213 / 16l;
            long v216;
            v216 = v215 % 8l;
            long v217;
            v217 = v215 / 8l;
            bool v218;
            v218 = v217 == 0l;
            bool v219;
            v219 = v218 == false;
            if (v219){
                assert("The index has to be in the range of the dimension." && v218);
            } else {
            }
            assert("Tensor range check" && 0 <= v216 && v216 < 8l);
            assert("Tensor range check" && 0 <= v214 && v214 < 16l);
            assert("Tensor range check" && 0 <= v212 && v212 < 8l);
            assert("Tensor range check" && 0 <= v210 && v210 < 4l);
            long v221;
            v221 = 4l * v210;
            long v222;
            v222 = 272l * v212;
            long v223;
            v223 = v222 + v221;
            long v224;
            v224 = 16l * v214;
            long v225;
            v225 = v224 + v223;
            long v226;
            v226 = 2176l * v216;
            long v227;
            v227 = v226 + v225;
            assert("Tensor range check" && 0 <= v216 && v216 < 8l);
            assert("Tensor range check" && 0 <= v214 && v214 < 16l);
            assert("Tensor range check" && 0 <= v212 && v212 < 8l);
            assert("Tensor range check" && 0 <= v210 && v210 < 4l);
            long v228;
            v228 = v221 + v29;
            long v229;
            v229 = 16l * v212;
            long v230;
            v230 = v229 + v228;
            long v231;
            v231 = 256l * v214;
            long v232;
            v232 = v231 + v230;
            long v233;
            v233 = 4096l * v216;
            long v234;
            v234 = v233 + v232;
            cooperative_groups::memcpy_async(v5, v2 + v234, v15 + v227, sizeof(float) * 4l);
            v208 += v206 ;
        }
        cooperative_groups::wait(v5);
        v3.sync() ;
        v18 += v16 ;
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
    v24.max_dynamic_shared_size_bytes = 71680 
    v24((1,),(512,),(v10, v5, v0),shared_mem=71680)
    del v5, v10, v24
    v25 = cp.max(cp.abs(v0-v18))
    del v0, v18
    return v25

if __name__ == '__main__': print(main())
