kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 16l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 2048l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 64l;
    return v1;
}
__device__ inline bool while_method_5(long v0){
    bool v1;
    v1 = v0 < 4096l;
    return v1;
}
__device__ inline bool while_method_6(long v0, long v1){
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
        v19 = v17 % 4l;
        long v20;
        v20 = v17 / 4l;
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
        v26 = 65536l * v21;
        assert("Tensor range check" && 0 <= v19 && v19 < 4l);
        long v27;
        v27 = 65536l * v19;
        assert("Tensor range check" && 0 <= v21 && v21 < 4l);
        assert("Tensor range check" && 0 <= v19 && v19 < 4l);
        long v28;
        v28 = 128l * v19;
        long v29;
        v29 = v26 + v28;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v30[4l];
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v31[4l];
        long v32;
        v32 = 0l;
        while (while_method_1(v32)){
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
        while (while_method_2(v42)){
            long v44;
            v44 = v42 % 8l;
            long v45;
            v45 = v42 / 8l;
            bool v46;
            v46 = v45 == 0l;
            bool v47;
            v47 = v46 == false;
            if (v47){
                assert("The index has to be in the range of the dimension." && v46);
            } else {
            }
            assert("Tensor range check" && 0 <= v44 && v44 < 8l);
            long v49;
            v49 = 64l * v44;
            long v50;
            v50 = v49 + v26;
            assert("Tensor range check" && 0 <= v44 && v44 < 8l);
            long v51;
            v51 = v49 + v27;
            long v52;
            v52 = v4.meta_group_size();
            long v53;
            v53 = v4.meta_group_rank();
            long v54;
            v54 = v53;
            while (while_method_3(v54)){
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
                v68 = v67 + v50;
                long v69;
                v69 = 8l * v58;
                long v70;
                v70 = v69 + v68;
                long v71;
                v71 = 512l * v60;
                long v72;
                v72 = v71 + v70;
                long v73;
                v73 = 8192l * v62;
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
            while (while_method_3(v83)){
                long v85;
                v85 = v83 % 2l;
                long v86;
                v86 = v83 / 2l;
                long v87;
                v87 = v86 % 8l;
                long v88;
                v88 = v86 / 8l;
                long v89;
                v89 = v88 % 16l;
                long v90;
                v90 = v88 / 16l;
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
                assert("Tensor range check" && 0 <= v89 && v89 < 16l);
                assert("Tensor range check" && 0 <= v87 && v87 < 8l);
                assert("Tensor range check" && 0 <= v85 && v85 < 2l);
                long v96;
                v96 = 4l * v85;
                long v97;
                v97 = v96 + v51;
                long v98;
                v98 = 8l * v87;
                long v99;
                v99 = v98 + v97;
                long v100;
                v100 = 512l * v89;
                long v101;
                v101 = v100 + v99;
                long v102;
                v102 = 8192l * v91;
                long v103;
                v103 = v102 + v101;
                assert("Tensor range check" && 0 <= v91 && v91 < 8l);
                assert("Tensor range check" && 0 <= v89 && v89 < 16l);
                assert("Tensor range check" && 0 <= v87 && v87 < 8l);
                assert("Tensor range check" && 0 <= v85 && v85 < 2l);
                long v104;
                v104 = 136l * v87;
                long v105;
                v105 = v104 + v96;
                long v106;
                v106 = 8l * v89;
                long v107;
                v107 = v106 + v105;
                long v108;
                v108 = 1088l * v91;
                long v109;
                v109 = v108 + v107;
                cooperative_groups::memcpy_async(v4, v11 + v109, v1 + v103, sizeof(float) * 4l);
                v83 += v81 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v110;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v111 = v110;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v112;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v113 = v112;
            long v114;
            v114 = thread_block::num_threads() / warpSize;
            long v115;
            v115 = thread_block::thread_rank() / warpSize;
            long v116;
            v116 = v115;
            while (while_method_4(v116)){
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
                v126 = 1088l * v118;
                long v127;
                v127 = v120 / 2l;
                long v128;
                v128 = v118 / 8l;
                assert("Tensor range check" && 0 <= v127 && v127 < 4l);
                assert("Tensor range check" && 0 <= v128 && v128 < 1l);
                long v129;
                v129 = v127 + v128;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v130 = v31[v129];
                long v131;
                v131 = 0l;
                while (while_method_2(v131)){
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
                    v140 = v138 + v126;
                    float * v141;
                    v141 = v8 + v139;
                    wmma::load_matrix_sync(v111, v141, 8l);
                    #pragma unroll
                    for (int t = 0; t < v111.num_elements; t++) { v111.x[t] = wmma::__float_to_tf32(v111.x[t]); };
                    float * v142;
                    v142 = v11 + v140;
                    wmma::load_matrix_sync(v113, v142, 8l);
                    #pragma unroll
                    for (int t = 0; t < v113.num_elements; t++) { v113.x[t] = wmma::__float_to_tf32(v113.x[t]); };
                    wmma::mma_sync(v130, v111, v113, v130);
                    v131 += 1l ;
                }
                v116 += v114 ;
            }
            v3.sync() ;
            v42 += 1l ;
        }
        long v143;
        v143 = v4.meta_group_size();
        long v144;
        v144 = v4.meta_group_rank();
        long v145;
        v145 = v144;
        while (while_method_5(v145)){
            long v147;
            v147 = v145 % 4l;
            long v148;
            v148 = v145 / 4l;
            long v149;
            v149 = v148 % 8l;
            long v150;
            v150 = v148 / 8l;
            long v151;
            v151 = v150 % 16l;
            long v152;
            v152 = v150 / 16l;
            long v153;
            v153 = v152 % 8l;
            long v154;
            v154 = v152 / 8l;
            bool v155;
            v155 = v154 == 0l;
            bool v156;
            v156 = v155 == false;
            if (v156){
                assert("The index has to be in the range of the dimension." && v155);
            } else {
            }
            assert("Tensor range check" && 0 <= v153 && v153 < 8l);
            assert("Tensor range check" && 0 <= v151 && v151 < 16l);
            assert("Tensor range check" && 0 <= v149 && v149 < 8l);
            assert("Tensor range check" && 0 <= v147 && v147 < 4l);
            long v158;
            v158 = 4l * v147;
            long v159;
            v159 = v158 + v29;
            long v160;
            v160 = 16l * v149;
            long v161;
            v161 = v160 + v159;
            long v162;
            v162 = 512l * v151;
            long v163;
            v163 = v162 + v161;
            long v164;
            v164 = 8192l * v153;
            long v165;
            v165 = v164 + v163;
            assert("Tensor range check" && 0 <= v153 && v153 < 8l);
            assert("Tensor range check" && 0 <= v151 && v151 < 16l);
            assert("Tensor range check" && 0 <= v149 && v149 < 8l);
            assert("Tensor range check" && 0 <= v147 && v147 < 4l);
            long v166;
            v166 = 272l * v149;
            long v167;
            v167 = v166 + v158;
            long v168;
            v168 = 16l * v151;
            long v169;
            v169 = v168 + v167;
            long v170;
            v170 = 2176l * v153;
            long v171;
            v171 = v170 + v169;
            cooperative_groups::memcpy_async(v4, v14 + v171, v2 + v165, sizeof(float) * 4l);
            v145 += v143 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v172;
        v172 = thread_block::num_threads() / warpSize;
        long v173;
        v173 = thread_block::thread_rank() / warpSize;
        long v174;
        v174 = v173;
        while (while_method_4(v174)){
            long v176;
            v176 = v174 % 8l;
            long v177;
            v177 = v174 / 8l;
            long v178;
            v178 = v177 % 8l;
            long v179;
            v179 = v177 / 8l;
            bool v180;
            v180 = v179 == 0l;
            bool v181;
            v181 = v180 == false;
            if (v181){
                assert("The index has to be in the range of the dimension." && v180);
            } else {
            }
            assert("Tensor range check" && 0 <= v178 && v178 < 8l);
            assert("Tensor range check" && 0 <= v176 && v176 < 8l);
            long v183;
            v183 = 272l * v176;
            long v184;
            v184 = 2176l * v178;
            long v185;
            v185 = v184 + v183;
            long v186;
            v186 = v178 / 2l;
            long v187;
            v187 = v176 / 8l;
            assert("Tensor range check" && 0 <= v186 && v186 < 4l);
            assert("Tensor range check" && 0 <= v187 && v187 < 1l);
            long v188;
            v188 = v186 + v187;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v189 = v31[v188];
            assert("Tensor range check" && 0 <= v186 && v186 < 4l);
            assert("Tensor range check" && 0 <= v187 && v187 < 1l);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v190 = v30[v188];
            float * v191;
            v191 = v14 + v185;
            wmma::load_matrix_sync(v190, v191, 16l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v192 = v190;
            long v193;
            v193 = v192.num_elements;
            long v194;
            v194 = 0l;
            while (while_method_6(v193, v194)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v196 = v189;
                float v197;
                v197 = v196.x[v194];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v198 = v190;
                float v199;
                v199 = v198.x[v194];
                float v200;
                v200 = 0.0f * v199;
                float v201;
                v201 = v197 + v200;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v202 = v190;
                v202.x[v194] = v201;
                v194 += 1l ;
            }
            float * v203;
            v203 = v14 + v185;
            wmma::store_matrix_sync(v203, v190, 16l, wmma::mem_row_major);
            v174 += v172 ;
        }
        v3.sync() ;
        long v204;
        v204 = v4.meta_group_size();
        long v205;
        v205 = v4.meta_group_rank();
        long v206;
        v206 = v205;
        while (while_method_5(v206)){
            long v208;
            v208 = v206 % 4l;
            long v209;
            v209 = v206 / 4l;
            long v210;
            v210 = v209 % 8l;
            long v211;
            v211 = v209 / 8l;
            long v212;
            v212 = v211 % 16l;
            long v213;
            v213 = v211 / 16l;
            long v214;
            v214 = v213 % 8l;
            long v215;
            v215 = v213 / 8l;
            bool v216;
            v216 = v215 == 0l;
            bool v217;
            v217 = v216 == false;
            if (v217){
                assert("The index has to be in the range of the dimension." && v216);
            } else {
            }
            assert("Tensor range check" && 0 <= v214 && v214 < 8l);
            assert("Tensor range check" && 0 <= v212 && v212 < 16l);
            assert("Tensor range check" && 0 <= v210 && v210 < 8l);
            assert("Tensor range check" && 0 <= v208 && v208 < 4l);
            long v219;
            v219 = 4l * v208;
            long v220;
            v220 = 272l * v210;
            long v221;
            v221 = v220 + v219;
            long v222;
            v222 = 16l * v212;
            long v223;
            v223 = v222 + v221;
            long v224;
            v224 = 2176l * v214;
            long v225;
            v225 = v224 + v223;
            assert("Tensor range check" && 0 <= v214 && v214 < 8l);
            assert("Tensor range check" && 0 <= v212 && v212 < 16l);
            assert("Tensor range check" && 0 <= v210 && v210 < 8l);
            assert("Tensor range check" && 0 <= v208 && v208 < 4l);
            long v226;
            v226 = v219 + v29;
            long v227;
            v227 = 16l * v210;
            long v228;
            v228 = v227 + v226;
            long v229;
            v229 = 512l * v212;
            long v230;
            v230 = v229 + v228;
            long v231;
            v231 = 8192l * v214;
            long v232;
            v232 = v231 + v230;
            cooperative_groups::memcpy_async(v4, v2 + v232, v14 + v225, sizeof(float) * 4l);
            v206 += v204 ;
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
options.append('--dopt=on')
options.append('--define-macro=NDEBUG')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 100
    del v0
    return v1
def main():
    v0 = cp.random.normal(0,1,262144,cp.float32)
    v1 = v0.size
    v2 = 262144 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,262144,cp.float32)
    v6 = v5.size
    v7 = 262144 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,262144,cp.float32)
    v11 = v10.size
    v12 = 262144 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15, v16 = (0, 0.0)
    while method0(v15):
        v18 = v10.reshape((512, 512))
        v19 = v5.reshape((512, 512))
        v20 = cp.transpose(v19)
        del v19
        v21 = v0.reshape((512, 512))
        del v21
        v22 = (cp.matmul(v18,v20)).flatten()
        del v18, v20
        v23 = v22.size
        v24 = 262144 == v23
        del v23
        v25 = v24 == False
        if v25:
            v26 = "The total length of the reshaped tensor dimension must match that of the original one."
            assert v24, v26
            del v26
        else:
            pass
        del v24, v25
        v27 = 0
        v28 = raw_module.get_function(f"entry{v27}")
        del v27
        v28.max_dynamic_shared_size_bytes = 69632 
        v28((72,),(512,),(v10, v5, v0),shared_mem=69632)
        del v28
        v29 = cp.max(cp.abs(v0-v22))
        del v22
        v30 = v29 + v16
        del v29
        v16 = v30
        del v30
        v15 += 1 
    del v0, v5, v10, v15
    v31 = v16 / 100.0
    del v16
    return v31

if __name__ == '__main__': print(main())
