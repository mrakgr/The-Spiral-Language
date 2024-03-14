kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <assert.h>
#include <mma.h>
using namespace nvcuda;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 4096l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 64l;
    return v1;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    extern __shared__ unsigned char v3[];
    float * v6;
    float * v4;
    v4 = reinterpret_cast<float *>(&v3[0ull]);
    v6 = v4;
    float * v9;
    float * v7;
    v7 = reinterpret_cast<float *>(&v3[34816ull]);
    v9 = v7;
    float * v12;
    float * v10;
    v10 = reinterpret_cast<float *>(&v3[0ull]);
    v12 = v10;
    long v13;
    v13 = threadIdx.x;
    long v14;
    v14 = v13 / 32l;
    bool v15;
    v15 = 0l <= v14;
    bool v16;
    v16 = v15 == false;
    if (v16){
        assert("The index needs to be zero or positive." && v15);
    } else {
    }
    long v18;
    v18 = v14 % 8l;
    long v19;
    v19 = v14 / 8l;
    bool v20;
    v20 = v19 < 2l;
    bool v21;
    v21 = v20 == false;
    if (v21){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v20);
    } else {
    }
    assert("Tensor range check" && 0 <= v19 && v19 < 2l);
    assert("Tensor range check" && 0 <= v18 && v18 < 8l);
    long v23;
    v23 = 16l * v18;
    long v24;
    v24 = 8704l * v19;
    long v25;
    v25 = v24 + v23;
    float * v28;
    float * v26;
    v26 = v12+v25;
    v28 = v26;
    assert("Tensor range check" && 0 <= v19 && v19 < 2l);
    long v29;
    v29 = 4352l * v19;
    float * v32;
    float * v30;
    v30 = v6+v29;
    v32 = v30;
    assert("Tensor range check" && 0 <= v18 && v18 < 8l);
    long v33;
    v33 = 1088l * v18;
    float * v36;
    float * v34;
    v34 = v9+v33;
    v36 = v34;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v37[4l];
    long v38;
    v38 = blockIdx.x;
    long v39;
    v39 = v38;
    while (while_method_0(v39)){
        bool v41;
        v41 = 0l <= v39;
        bool v42;
        v42 = v41 == false;
        if (v42){
            assert("The index needs to be zero or positive." && v41);
        } else {
        }
        long v44;
        v44 = v39 % 64l;
        long v45;
        v45 = v39 / 64l;
        bool v46;
        v46 = v45 < 64l;
        bool v47;
        v47 = v46 == false;
        if (v47){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v46);
        } else {
        }
        assert("Tensor range check" && 0 <= v45 && v45 < 64l);
        assert("Tensor range check" && 0 <= v44 && v44 < 64l);
        long v49;
        v49 = 128l * v44;
        long v50;
        v50 = 1048576l * v45;
        long v51;
        v51 = v50 + v49;
        float * v54;
        float * v52;
        v52 = v2+v51;
        v54 = v52;
        // Pushing the loop unrolling to: 0
        long v55;
        v55 = threadIdx.x;
        bool v56;
        v56 = 0l <= v55;
        bool v57;
        v57 = v56 == false;
        if (v57){
            assert("The index needs to be zero or positive." && v56);
        } else {
        }
        long v59;
        v59 = v55 % 32l;
        long v60;
        v60 = v55 / 32l;
        bool v61;
        v61 = v60 < 16l;
        bool v62;
        v62 = v61 == false;
        if (v62){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v61);
        } else {
        }
        assert("Tensor range check" && 0 <= v60 && v60 < 16l);
        assert("Tensor range check" && 0 <= v59 && v59 < 32l);
        long v64;
        v64 = 4l * v59;
        long v65;
        v65 = 136l * v60;
        long v66;
        v66 = v65 + v64;
        long v67;
        v67 = 8192l * v60;
        long v68;
        v68 = v67 + v64;
        float * v71;
        float * v69;
        v69 = v12+v66;
        v71 = v69;
        float * v74;
        float * v72;
        v72 = v54+v68;
        v74 = v72;
        long v75;
        v75 = 0l;
        #pragma unroll
        while (while_method_1(v75)){
            long v77;
            v77 = 0l;
            #pragma unroll
            while (while_method_2(v77)){
                assert("Tensor range check" && 0 <= v75 && v75 < 8l);
                assert("Tensor range check" && 0 <= v77 && v77 < 1l);
                long v79;
                v79 = 128l * v77;
                long v80;
                v80 = 2176l * v75;
                long v81;
                v81 = v80 + v79;
                long v82;
                v82 = 131072l * v75;
                long v83;
                v83 = v82 + v79;
                int4* v84;
                v84 = reinterpret_cast<int4*>(v74 + v83);
                int4* v85;
                v85 = reinterpret_cast<int4*>(v71 + v81);
                assert("Pointer alignment check" && (unsigned long long)(v84) % 4l == 0 && (unsigned long long)(v85) % 4l == 0);
                *v85 = *v84;
                v77 += 1l ;
            }
            v75 += 1l ;
        }
        __syncthreads();
        long v86;
        v86 = 0l;
        #pragma unroll
        while (while_method_3(v86)){
            long v88;
            v88 = 0l;
            #pragma unroll
            while (while_method_2(v88)){
                assert("Tensor range check" && 0 <= v86 && v86 < 4l);
                assert("Tensor range check" && 0 <= v88 && v88 < 1l);
                long v90;
                v90 = v86 + v88;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v91 = v37[v90];
                assert("Tensor range check" && 0 <= v86 && v86 < 4l);
                assert("Tensor range check" && 0 <= v88 && v88 < 1l);
                long v92;
                v92 = 16l * v88;
                long v93;
                v93 = 2176l * v86;
                long v94;
                v94 = v93 + v92;
                float * v95;
                v95 = v28 + v94;
                wmma::load_matrix_sync(v91, v95, 136l, wmma::mem_row_major);
                v88 += 1l ;
            }
            v86 += 1l ;
        }
        __syncthreads();
        // Pushing the loop unrolling to: 1
        long v96;
        v96 = 0l;
        #pragma unroll 1
        while (while_method_4(v96)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v45 && v45 < 64l);
            long v98;
            v98 = 524288l * v45;
            assert("Tensor range check" && 0 <= v96 && v96 < 64l);
            long v99;
            v99 = 64l * v96;
            long v100;
            v100 = v99 + v98;
            float * v103;
            float * v101;
            v101 = v0+v100;
            v103 = v101;
            assert("Tensor range check" && 0 <= v44 && v44 < 64l);
            long v104;
            v104 = 524288l * v44;
            assert("Tensor range check" && 0 <= v96 && v96 < 64l);
            long v105;
            v105 = v99 + v104;
            float * v108;
            float * v106;
            v106 = v1+v105;
            v108 = v106;
            long v109;
            v109 = threadIdx.x;
            bool v110;
            v110 = 0l <= v109;
            bool v111;
            v111 = v110 == false;
            if (v111){
                assert("The index needs to be zero or positive." && v110);
            } else {
            }
            long v113;
            v113 = v109 % 16l;
            long v114;
            v114 = v109 / 16l;
            bool v115;
            v115 = v114 < 32l;
            bool v116;
            v116 = v115 == false;
            if (v116){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v115);
            } else {
            }
            assert("Tensor range check" && 0 <= v114 && v114 < 32l);
            assert("Tensor range check" && 0 <= v113 && v113 < 16l);
            long v118;
            v118 = 4l * v113;
            long v119;
            v119 = 68l * v114;
            long v120;
            v120 = v119 + v118;
            long v121;
            v121 = 4096l * v114;
            long v122;
            v122 = v121 + v118;
            float * v125;
            float * v123;
            v123 = v9+v120;
            v125 = v123;
            float * v128;
            float * v126;
            v126 = v108+v122;
            v128 = v126;
            long v129;
            v129 = 0l;
            #pragma unroll
            while (while_method_3(v129)){
                long v131;
                v131 = 0l;
                #pragma unroll
                while (while_method_2(v131)){
                    assert("Tensor range check" && 0 <= v129 && v129 < 4l);
                    assert("Tensor range check" && 0 <= v131 && v131 < 1l);
                    long v133;
                    v133 = 64l * v131;
                    long v134;
                    v134 = 2176l * v129;
                    long v135;
                    v135 = v134 + v133;
                    long v136;
                    v136 = 131072l * v129;
                    long v137;
                    v137 = v136 + v133;
                    float v138[4l];
                    long v139;
                    v139 = 0l;
                    #pragma unroll
                    while (while_method_3(v139)){
                        assert("Tensor range check" && 0 <= v139 && v139 < 4l);
                        long v141;
                        v141 = v139 + v137;
                        float v142;
                        v142 = v128[v141];
                        float v143;
                        v143 = wmma::__float_to_tf32(v142);
                        assert("Tensor range check" && 0 <= v139 && v139 < 4l);
                        v138[v139] = v143;
                        v139 += 1l ;
                    }
                    int4* v144;
                    v144 = reinterpret_cast<int4*>(v138 + 0l);
                    int4* v145;
                    v145 = reinterpret_cast<int4*>(v125 + v135);
                    assert("Pointer alignment check" && (unsigned long long)(v144) % 4l == 0 && (unsigned long long)(v145) % 4l == 0);
                    *v145 = *v144;
                    v131 += 1l ;
                }
                v129 += 1l ;
            }
            long v146;
            v146 = threadIdx.x;
            bool v147;
            v147 = 0l <= v146;
            bool v148;
            v148 = v147 == false;
            if (v148){
                assert("The index needs to be zero or positive." && v147);
            } else {
            }
            long v150;
            v150 = v146 % 16l;
            long v151;
            v151 = v146 / 16l;
            bool v152;
            v152 = v151 < 32l;
            bool v153;
            v153 = v152 == false;
            if (v153){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v152);
            } else {
            }
            assert("Tensor range check" && 0 <= v151 && v151 < 32l);
            assert("Tensor range check" && 0 <= v150 && v150 < 16l);
            long v155;
            v155 = 4l * v150;
            long v156;
            v156 = 68l * v151;
            long v157;
            v157 = v156 + v155;
            long v158;
            v158 = 4096l * v151;
            long v159;
            v159 = v158 + v155;
            float * v162;
            float * v160;
            v160 = v6+v157;
            v162 = v160;
            float * v165;
            float * v163;
            v163 = v103+v159;
            v165 = v163;
            long v166;
            v166 = 0l;
            #pragma unroll
            while (while_method_3(v166)){
                long v168;
                v168 = 0l;
                #pragma unroll
                while (while_method_2(v168)){
                    assert("Tensor range check" && 0 <= v166 && v166 < 4l);
                    assert("Tensor range check" && 0 <= v168 && v168 < 1l);
                    long v170;
                    v170 = 64l * v168;
                    long v171;
                    v171 = 2176l * v166;
                    long v172;
                    v172 = v171 + v170;
                    long v173;
                    v173 = 131072l * v166;
                    long v174;
                    v174 = v173 + v170;
                    float v175[4l];
                    long v176;
                    v176 = 0l;
                    #pragma unroll
                    while (while_method_3(v176)){
                        assert("Tensor range check" && 0 <= v176 && v176 < 4l);
                        long v178;
                        v178 = v176 + v174;
                        float v179;
                        v179 = v165[v178];
                        float v180;
                        v180 = wmma::__float_to_tf32(v179);
                        assert("Tensor range check" && 0 <= v176 && v176 < 4l);
                        v175[v176] = v180;
                        v176 += 1l ;
                    }
                    int4* v181;
                    v181 = reinterpret_cast<int4*>(v175 + 0l);
                    int4* v182;
                    v182 = reinterpret_cast<int4*>(v162 + v172);
                    assert("Pointer alignment check" && (unsigned long long)(v181) % 4l == 0 && (unsigned long long)(v182) % 4l == 0);
                    *v182 = *v181;
                    v168 += 1l ;
                }
                v166 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v183[32l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v184[8l];
            long v185;
            v185 = 0l;
            #pragma unroll
            while (while_method_3(v185)){
                long v187;
                v187 = 0l;
                #pragma unroll
                while (while_method_1(v187)){
                    assert("Tensor range check" && 0 <= v185 && v185 < 4l);
                    assert("Tensor range check" && 0 <= v187 && v187 < 8l);
                    long v189;
                    v189 = 8l * v185;
                    long v190;
                    v190 = v189 + v187;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v191 = v183[v190];
                    assert("Tensor range check" && 0 <= v185 && v185 < 4l);
                    long v192;
                    v192 = 1088l * v185;
                    assert("Tensor range check" && 0 <= v187 && v187 < 8l);
                    long v193;
                    v193 = 8l * v187;
                    long v194;
                    v194 = v193 + v192;
                    float * v195;
                    v195 = v32 + v194;
                    wmma::load_matrix_sync(v191, v195, 68l);
                    v187 += 1l ;
                }
                v185 += 1l ;
            }
            long v196;
            v196 = 0l;
            #pragma unroll
            while (while_method_2(v196)){
                long v198;
                v198 = 0l;
                #pragma unroll
                while (while_method_1(v198)){
                    assert("Tensor range check" && 0 <= v196 && v196 < 1l);
                    assert("Tensor range check" && 0 <= v198 && v198 < 8l);
                    long v200;
                    v200 = 8l * v196;
                    long v201;
                    v201 = v200 + v198;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v202 = v184[v201];
                    assert("Tensor range check" && 0 <= v196 && v196 < 1l);
                    long v203;
                    v203 = 1088l * v196;
                    assert("Tensor range check" && 0 <= v198 && v198 < 8l);
                    long v204;
                    v204 = 8l * v198;
                    long v205;
                    v205 = v204 + v203;
                    float * v206;
                    v206 = v36 + v205;
                    wmma::load_matrix_sync(v202, v206, 68l);
                    v198 += 1l ;
                }
                v196 += 1l ;
            }
            __syncthreads();
            long v207;
            v207 = 0l;
            #pragma unroll
            while (while_method_3(v207)){
                long v209;
                v209 = 0l;
                #pragma unroll
                while (while_method_2(v209)){
                    long v211;
                    v211 = 0l;
                    #pragma unroll
                    while (while_method_1(v211)){
                        assert("Tensor range check" && 0 <= v207 && v207 < 4l);
                        assert("Tensor range check" && 0 <= v209 && v209 < 1l);
                        long v213;
                        v213 = v207 + v209;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v214 = v37[v213];
                        assert("Tensor range check" && 0 <= v207 && v207 < 4l);
                        assert("Tensor range check" && 0 <= v211 && v211 < 8l);
                        long v215;
                        v215 = 8l * v207;
                        long v216;
                        v216 = v215 + v211;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v217 = v183[v216];
                        assert("Tensor range check" && 0 <= v209 && v209 < 1l);
                        assert("Tensor range check" && 0 <= v211 && v211 < 8l);
                        long v218;
                        v218 = 8l * v209;
                        long v219;
                        v219 = v218 + v211;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v220 = v184[v219];
                        wmma::mma_sync(v214, v217, v220, v214);
                        v211 += 1l ;
                    }
                    v209 += 1l ;
                }
                v207 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v96 += 1l ;
        }
        // Poping the loop unrolling to: 1
        long v221;
        v221 = 0l;
        #pragma unroll
        while (while_method_3(v221)){
            long v223;
            v223 = 0l;
            #pragma unroll
            while (while_method_2(v223)){
                assert("Tensor range check" && 0 <= v221 && v221 < 4l);
                assert("Tensor range check" && 0 <= v223 && v223 < 1l);
                long v225;
                v225 = v221 + v223;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v226 = v37[v225];
                assert("Tensor range check" && 0 <= v221 && v221 < 4l);
                assert("Tensor range check" && 0 <= v223 && v223 < 1l);
                long v227;
                v227 = 16l * v223;
                long v228;
                v228 = 2176l * v221;
                long v229;
                v229 = v228 + v227;
                float * v230;
                v230 = v28 + v229;
                wmma::store_matrix_sync(v230, v226, 136l, wmma::mem_row_major);
                v223 += 1l ;
            }
            v221 += 1l ;
        }
        __syncthreads();
        long v231;
        v231 = threadIdx.x;
        bool v232;
        v232 = 0l <= v231;
        bool v233;
        v233 = v232 == false;
        if (v233){
            assert("The index needs to be zero or positive." && v232);
        } else {
        }
        long v235;
        v235 = v231 % 32l;
        long v236;
        v236 = v231 / 32l;
        bool v237;
        v237 = v236 < 16l;
        bool v238;
        v238 = v237 == false;
        if (v238){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v237);
        } else {
        }
        assert("Tensor range check" && 0 <= v236 && v236 < 16l);
        assert("Tensor range check" && 0 <= v235 && v235 < 32l);
        long v240;
        v240 = 4l * v235;
        long v241;
        v241 = 8192l * v236;
        long v242;
        v242 = v241 + v240;
        long v243;
        v243 = 136l * v236;
        long v244;
        v244 = v243 + v240;
        float * v247;
        float * v245;
        v245 = v54+v242;
        v247 = v245;
        float * v250;
        float * v248;
        v248 = v12+v244;
        v250 = v248;
        long v251;
        v251 = 0l;
        #pragma unroll
        while (while_method_1(v251)){
            long v253;
            v253 = 0l;
            #pragma unroll
            while (while_method_2(v253)){
                assert("Tensor range check" && 0 <= v251 && v251 < 8l);
                assert("Tensor range check" && 0 <= v253 && v253 < 1l);
                long v255;
                v255 = 128l * v253;
                long v256;
                v256 = 131072l * v251;
                long v257;
                v257 = v256 + v255;
                long v258;
                v258 = 2176l * v251;
                long v259;
                v259 = v258 + v255;
                int4* v260;
                v260 = reinterpret_cast<int4*>(v250 + v259);
                int4* v261;
                v261 = reinterpret_cast<int4*>(v247 + v257);
                assert("Pointer alignment check" && (unsigned long long)(v260) % 4l == 0 && (unsigned long long)(v261) % 4l == 0);
                *v261 = *v260;
                v253 += 1l ;
            }
            v251 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v39 += 24l ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

from max_blocks_per_sm import max_blocks_per_sm
options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550')
options.append('--dopt=on')
options.append('--restrict')
options.append('-src-in-ptx')
options.append('--generate-line-info')
options.append('-D__CUDA_NO_HALF_CONVERSIONS__')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvcc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
    del v0
    return v1
def main():
    v0 = cp.random.normal(0.0,1.0,67108864,cp.float32)
    v1 = v0.size
    v2 = 67108864 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0.0,1.0,33554432,cp.float32)
    v6 = v5.size
    v7 = 33554432 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0.0,1.0,33554432,cp.float32)
    v11 = v10.size
    v12 = 33554432 == v11
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
        v18 = v10.reshape((8192, 4096))
        v19 = v5.reshape((8192, 4096))
        v20 = cp.transpose(v19)
        del v19
        v21 = v0.reshape((8192, 8192))
        v22 = (cp.matmul(v18,v20) + v21).flatten()
        del v18, v20, v21
        v23 = v22.size
        v24 = 67108864 == v23
        del v23
        v25 = v24 == False
        if v25:
            v26 = "The total length of the reshaped tensor dimension must match that of the original one."
            assert v24, v26
            del v26
        else:
            pass
        del v24, v25
        v27 = v15 == 0
        if v27:
            max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),512,is_print=True)
        else:
            pass
        del v27
        v28 = 0
        v29 = raw_module.get_function(f"entry{v28}")
        del v28
        v29.max_dynamic_shared_size_bytes = 69632 
        v29((24,),(512,),(v10, v5, v0),shared_mem=69632)
        del v29
        v30 = cp.max(cp.abs(v0-v22))
        del v22
        v31 = v30 + v16
        del v30
        v16 = v31
        del v31
        v15 += 1 
    del v0, v5, v10, v15
    return v16

if __name__ == '__main__': print(main())
