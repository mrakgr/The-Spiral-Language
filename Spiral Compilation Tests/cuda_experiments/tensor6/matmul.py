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
    thread_block_tile<1l, thread_block> v4 = tiled_partition<1l>(v3);
    extern __shared__ unsigned char v5[];
    float * v8;
    float * v6;
    v6 = reinterpret_cast<float *>(&v5[0ull]);
    v8 = v6;
    float * v11;
    float * v9;
    v9 = reinterpret_cast<float *>(&v5[34816ull]);
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
        v21 = v20 % 2l;
        long v22;
        v22 = v20 / 2l;
        bool v23;
        v23 = v22 == 0l;
        bool v24;
        v24 = v23 == false;
        if (v24){
            assert("The index has to be in the range of the dimension." && v23);
        } else {
        }
        assert("Tensor range check" && 0 <= v21 && v21 < 2l);
        long v26;
        v26 = 32768l * v21;
        assert("Tensor range check" && 0 <= v19 && v19 < 2l);
        long v27;
        v27 = 128l * v19;
        assert("Tensor range check" && 0 <= v21 && v21 < 2l);
        assert("Tensor range check" && 0 <= v19 && v19 < 2l);
        long v28;
        v28 = v26 + v27;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v29[4l];
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v30[4l];
        long v31;
        v31 = 0l;
        while (while_method_0(v31)){
            long v33;
            v33 = v31 % 1l;
            long v34;
            v34 = v31 % 4l;
            long v35;
            v35 = v31 / 4l;
            bool v36;
            v36 = v35 == 0l;
            bool v37;
            v37 = v36 == false;
            if (v37){
                assert("The index has to be in the range of the dimension." && v36);
            } else {
            }
            assert("Tensor range check" && 0 <= v34 && v34 < 4l);
            assert("Tensor range check" && 0 <= v33 && v33 < 1l);
            long v39;
            v39 = v34 + v33;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v40 = v30[v39];
            wmma::fill_fragment(v40, 0.0f);
            v31 += 1l ;
        }
        long v41;
        v41 = 0l;
        while (while_method_0(v41)){
            long v43;
            v43 = v41 % 4l;
            long v44;
            v44 = v41 / 4l;
            bool v45;
            v45 = v44 == 0l;
            bool v46;
            v46 = v45 == false;
            if (v46){
                assert("The index has to be in the range of the dimension." && v45);
            } else {
            }
            assert("Tensor range check" && 0 <= v43 && v43 < 4l);
            long v48;
            v48 = 64l * v43;
            long v49;
            v49 = v48 + v26;
            assert("Tensor range check" && 0 <= v43 && v43 < 4l);
            long v50;
            v50 = 16384l * v43;
            long v51;
            v51 = v50 + v27;
            long v52;
            v52 = v4.meta_group_size();
            long v53;
            v53 = v4.meta_group_rank();
            long v54;
            v54 = v53;
            while (while_method_1(v54)){
                long v56;
                v56 = v54 % 2l;
                long v57;
                v57 = v54 / 2l;
                long v58;
                v58 = v57 % 8l;
                long v59;
                v59 = v57 / 8l;
                long v60;
                v60 = v59 % 16l;
                long v61;
                v61 = v59 / 16l;
                long v62;
                v62 = v61 % 8l;
                long v63;
                v63 = v61 / 8l;
                bool v64;
                v64 = v63 == 0l;
                bool v65;
                v65 = v64 == false;
                if (v65){
                    assert("The index has to be in the range of the dimension." && v64);
                } else {
                }
                assert("Tensor range check" && 0 <= v62 && v62 < 8l);
                assert("Tensor range check" && 0 <= v60 && v60 < 16l);
                assert("Tensor range check" && 0 <= v58 && v58 < 8l);
                assert("Tensor range check" && 0 <= v56 && v56 < 2l);
                long v67;
                v67 = 4l * v56;
                long v68;
                v68 = v67 + v49;
                long v69;
                v69 = 8l * v58;
                long v70;
                v70 = v69 + v68;
                long v71;
                v71 = 256l * v60;
                long v72;
                v72 = v71 + v70;
                long v73;
                v73 = 4096l * v62;
                long v74;
                v74 = v73 + v72;
                assert("Tensor range check" && 0 <= v62 && v62 < 8l);
                assert("Tensor range check" && 0 <= v60 && v60 < 16l);
                assert("Tensor range check" && 0 <= v58 && v58 < 8l);
                assert("Tensor range check" && 0 <= v56 && v56 < 2l);
                long v75;
                v75 = 136l * v58;
                long v76;
                v76 = v75 + v67;
                long v77;
                v77 = 8l * v60;
                long v78;
                v78 = v77 + v76;
                long v79;
                v79 = 1088l * v62;
                long v80;
                v80 = v79 + v78;
                cooperative_groups::memcpy_async(v4, v8 + v80, v0 + v74, sizeof(float) * 4l);
                v54 += v52 ;
            }
            long v81;
            v81 = v4.meta_group_size();
            long v82;
            v82 = v4.meta_group_rank();
            long v83;
            v83 = v82;
            while (while_method_1(v83)){
                long v85;
                v85 = v83 % 4l;
                long v86;
                v86 = v83 / 4l;
                long v87;
                v87 = v86 % 8l;
                long v88;
                v88 = v86 / 8l;
                long v89;
                v89 = v88 % 8l;
                long v90;
                v90 = v88 / 8l;
                long v91;
                v91 = v90 % 8l;
                long v92;
                v92 = v90 / 8l;
                bool v93;
                v93 = v92 == 0l;
                bool v94;
                v94 = v93 == false;
                if (v94){
                    assert("The index has to be in the range of the dimension." && v93);
                } else {
                }
                assert("Tensor range check" && 0 <= v91 && v91 < 8l);
                assert("Tensor range check" && 0 <= v89 && v89 < 8l);
                assert("Tensor range check" && 0 <= v87 && v87 < 8l);
                assert("Tensor range check" && 0 <= v85 && v85 < 4l);
                long v96;
                v96 = 4l * v85;
                long v97;
                v97 = v96 + v51;
                long v98;
                v98 = 16l * v87;
                long v99;
                v99 = v98 + v97;
                long v100;
                v100 = 256l * v89;
                long v101;
                v101 = v100 + v99;
                long v102;
                v102 = 2048l * v91;
                long v103;
                v103 = v102 + v101;
                assert("Tensor range check" && 0 <= v91 && v91 < 8l);
                assert("Tensor range check" && 0 <= v89 && v89 < 8l);
                assert("Tensor range check" && 0 <= v87 && v87 < 8l);
                assert("Tensor range check" && 0 <= v85 && v85 < 4l);
                long v104;
                v104 = 144l * v87;
                long v105;
                v105 = v104 + v96;
                long v106;
                v106 = 16l * v89;
                long v107;
                v107 = v106 + v105;
                long v108;
                v108 = 1152l * v91;
                long v109;
                v109 = v108 + v107;
                cooperative_groups::memcpy_async(v4, v11 + v109, v1 + v103, sizeof(float) * 4l);
                v83 += v81 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v110;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v111 = v110;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v112;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v113 = v112;
            long v114;
            v114 = thread_block::num_threads() / warpSize;
            long v115;
            v115 = thread_block::thread_rank() / warpSize;
            long v116;
            v116 = v115;
            while (while_method_2(v116)){
                long v118;
                v118 = v116 % 8l;
                long v119;
                v119 = v116 / 8l;
                long v120;
                v120 = v119 % 8l;
                long v121;
                v121 = v119 / 8l;
                bool v122;
                v122 = v121 == 0l;
                bool v123;
                v123 = v122 == false;
                if (v123){
                    assert("The index has to be in the range of the dimension." && v122);
                } else {
                }
                assert("Tensor range check" && 0 <= v120 && v120 < 8l);
                long v125;
                v125 = 1088l * v120;
                assert("Tensor range check" && 0 <= v118 && v118 < 8l);
                long v126;
                v126 = 144l * v118;
                long v127;
                v127 = v120 / 2l;
                long v128;
                v128 = v118 / 8l;
                assert("Tensor range check" && 0 <= v127 && v127 < 4l);
                assert("Tensor range check" && 0 <= v128 && v128 < 1l);
                long v129;
                v129 = v127 + v128;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v130 = v30[v129];
                long v131;
                v131 = 0l;
                while (while_method_3(v131)){
                    long v133;
                    v133 = v131 % 8l;
                    long v134;
                    v134 = v131 / 8l;
                    bool v135;
                    v135 = v134 == 0l;
                    bool v136;
                    v136 = v135 == false;
                    if (v136){
                        assert("The index has to be in the range of the dimension." && v135);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v133 && v133 < 8l);
                    long v138;
                    v138 = 136l * v133;
                    long v139;
                    v139 = v138 + v125;
                    assert("Tensor range check" && 0 <= v133 && v133 < 8l);
                    long v140;
                    v140 = 1152l * v133;
                    long v141;
                    v141 = v140 + v126;
                    float * v142;
                    v142 = v8 + v139;
                    wmma::load_matrix_sync(v111, v142, 8l);
                    #pragma unroll
                    for (int t = 0; t < v111.num_elements; t++) { v111.x[t] = wmma::__float_to_tf32(v111.x[t]); };
                    float * v143;
                    v143 = v11 + v141;
                    wmma::load_matrix_sync(v113, v143, 16l);
                    #pragma unroll
                    for (int t = 0; t < v113.num_elements; t++) { v113.x[t] = wmma::__float_to_tf32(v113.x[t]); };
                    wmma::mma_sync(v130, v111, v113, v130);
                    v131 += 1l ;
                }
                v116 += v114 ;
            }
            v3.sync() ;
            v41 += 1l ;
        }
        long v144;
        v144 = v4.meta_group_size();
        long v145;
        v145 = v4.meta_group_rank();
        long v146;
        v146 = v145;
        while (while_method_4(v146)){
            long v148;
            v148 = v146 % 4l;
            long v149;
            v149 = v146 / 4l;
            long v150;
            v150 = v149 % 8l;
            long v151;
            v151 = v149 / 8l;
            long v152;
            v152 = v151 % 16l;
            long v153;
            v153 = v151 / 16l;
            long v154;
            v154 = v153 % 8l;
            long v155;
            v155 = v153 / 8l;
            bool v156;
            v156 = v155 == 0l;
            bool v157;
            v157 = v156 == false;
            if (v157){
                assert("The index has to be in the range of the dimension." && v156);
            } else {
            }
            assert("Tensor range check" && 0 <= v154 && v154 < 8l);
            assert("Tensor range check" && 0 <= v152 && v152 < 16l);
            assert("Tensor range check" && 0 <= v150 && v150 < 8l);
            assert("Tensor range check" && 0 <= v148 && v148 < 4l);
            long v159;
            v159 = 4l * v148;
            long v160;
            v160 = v159 + v28;
            long v161;
            v161 = 16l * v150;
            long v162;
            v162 = v161 + v160;
            long v163;
            v163 = 256l * v152;
            long v164;
            v164 = v163 + v162;
            long v165;
            v165 = 4096l * v154;
            long v166;
            v166 = v165 + v164;
            assert("Tensor range check" && 0 <= v154 && v154 < 8l);
            assert("Tensor range check" && 0 <= v152 && v152 < 16l);
            assert("Tensor range check" && 0 <= v150 && v150 < 8l);
            assert("Tensor range check" && 0 <= v148 && v148 < 4l);
            long v167;
            v167 = 272l * v150;
            long v168;
            v168 = v167 + v159;
            long v169;
            v169 = 16l * v152;
            long v170;
            v170 = v169 + v168;
            long v171;
            v171 = 2176l * v154;
            long v172;
            v172 = v171 + v170;
            cooperative_groups::memcpy_async(v4, v14 + v172, v2 + v166, sizeof(float) * 4l);
            v146 += v144 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v173;
        v173 = thread_block::num_threads() / warpSize;
        long v174;
        v174 = thread_block::thread_rank() / warpSize;
        long v175;
        v175 = v174;
        while (while_method_2(v175)){
            long v177;
            v177 = v175 % 8l;
            long v178;
            v178 = v175 / 8l;
            long v179;
            v179 = v178 % 8l;
            long v180;
            v180 = v178 / 8l;
            bool v181;
            v181 = v180 == 0l;
            bool v182;
            v182 = v181 == false;
            if (v182){
                assert("The index has to be in the range of the dimension." && v181);
            } else {
            }
            assert("Tensor range check" && 0 <= v179 && v179 < 8l);
            assert("Tensor range check" && 0 <= v177 && v177 < 8l);
            long v184;
            v184 = 272l * v177;
            long v185;
            v185 = 2176l * v179;
            long v186;
            v186 = v185 + v184;
            long v187;
            v187 = v179 / 2l;
            long v188;
            v188 = v177 / 8l;
            assert("Tensor range check" && 0 <= v187 && v187 < 4l);
            assert("Tensor range check" && 0 <= v188 && v188 < 1l);
            long v189;
            v189 = v187 + v188;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v190 = v30[v189];
            assert("Tensor range check" && 0 <= v187 && v187 < 4l);
            assert("Tensor range check" && 0 <= v188 && v188 < 1l);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v191 = v29[v189];
            float * v192;
            v192 = v14 + v186;
            wmma::load_matrix_sync(v191, v192, 16l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v193 = v191;
            long v194;
            v194 = v193.num_elements;
            long v195;
            v195 = 0l;
            while (while_method_5(v194, v195)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v197 = v190;
                float v198;
                v198 = v197.x[v195];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v199 = v191;
                float v200;
                v200 = v199.x[v195];
                float v201;
                v201 = 0.0f * v200;
                float v202;
                v202 = v198 + v201;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v203 = v191;
                v203.x[v195] = v202;
                v195 += 1l ;
            }
            float * v204;
            v204 = v14 + v186;
            wmma::store_matrix_sync(v204, v191, 16l, wmma::mem_row_major);
            v175 += v173 ;
        }
        v3.sync() ;
        long v205;
        v205 = v4.meta_group_size();
        long v206;
        v206 = v4.meta_group_rank();
        long v207;
        v207 = v206;
        while (while_method_4(v207)){
            long v209;
            v209 = v207 % 4l;
            long v210;
            v210 = v207 / 4l;
            long v211;
            v211 = v210 % 8l;
            long v212;
            v212 = v210 / 8l;
            long v213;
            v213 = v212 % 16l;
            long v214;
            v214 = v212 / 16l;
            long v215;
            v215 = v214 % 8l;
            long v216;
            v216 = v214 / 8l;
            bool v217;
            v217 = v216 == 0l;
            bool v218;
            v218 = v217 == false;
            if (v218){
                assert("The index has to be in the range of the dimension." && v217);
            } else {
            }
            assert("Tensor range check" && 0 <= v215 && v215 < 8l);
            assert("Tensor range check" && 0 <= v213 && v213 < 16l);
            assert("Tensor range check" && 0 <= v211 && v211 < 8l);
            assert("Tensor range check" && 0 <= v209 && v209 < 4l);
            long v220;
            v220 = 4l * v209;
            long v221;
            v221 = 272l * v211;
            long v222;
            v222 = v221 + v220;
            long v223;
            v223 = 16l * v213;
            long v224;
            v224 = v223 + v222;
            long v225;
            v225 = 2176l * v215;
            long v226;
            v226 = v225 + v224;
            assert("Tensor range check" && 0 <= v215 && v215 < 8l);
            assert("Tensor range check" && 0 <= v213 && v213 < 16l);
            assert("Tensor range check" && 0 <= v211 && v211 < 8l);
            assert("Tensor range check" && 0 <= v209 && v209 < 4l);
            long v227;
            v227 = v220 + v28;
            long v228;
            v228 = 16l * v211;
            long v229;
            v229 = v228 + v227;
            long v230;
            v230 = 256l * v213;
            long v231;
            v231 = v230 + v229;
            long v232;
            v232 = 4096l * v215;
            long v233;
            v233 = v232 + v231;
            cooperative_groups::memcpy_async(v4, v2 + v233, v14 + v226, sizeof(float) * 4l);
            v207 += v205 ;
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
    v24((8,),(512,),(v10, v5, v0),shared_mem=71680)
    del v5, v10, v24
    v25 = cp.max(cp.abs(v0-v18))
    del v0, v18
    return v25

if __name__ == '__main__': print(main())
