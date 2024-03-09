kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 16l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8l;
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
    long v15;
    v15 = v14 % 8l;
    long v16;
    v16 = v14 / 8l;
    long v17;
    v17 = v16 % 1l;
    bool v18;
    v18 = v16 == 0l;
    bool v19;
    v19 = v18 == false;
    if (v19){
        assert("The index has to be in the range of the dimension." && v18);
    } else {
    }
    assert("Tensor range check" && 0 <= v17 && v17 < 1l);
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v21;
    v21 = 16l * v15;
    long v22;
    v22 = 17408l * v17;
    long v23;
    v23 = v22 + v21;
    float * v26;
    float * v24;
    v24 = v12+v23;
    v26 = v24;
    assert("Tensor range check" && 0 <= v17 && v17 < 1l);
    long v27;
    v27 = 8704l * v17;
    float * v30;
    float * v28;
    v28 = v6+v27;
    v30 = v28;
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v31;
    v31 = 1088l * v15;
    float * v34;
    float * v32;
    v32 = v9+v31;
    v34 = v32;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v35[8l];
    long v36;
    v36 = blockIdx.x;
    long v37;
    v37 = v36;
    while (while_method_0(v37)){
        long v39;
        v39 = v37 % 4l;
        long v40;
        v40 = v37 / 4l;
        long v41;
        v41 = v40 % 4l;
        long v42;
        v42 = v40 / 4l;
        bool v43;
        v43 = v42 == 0l;
        bool v44;
        v44 = v43 == false;
        if (v44){
            assert("The index has to be in the range of the dimension." && v43);
        } else {
        }
        assert("Tensor range check" && 0 <= v41 && v41 < 4l);
        assert("Tensor range check" && 0 <= v39 && v39 < 4l);
        long v46;
        v46 = 128l * v39;
        long v47;
        v47 = 65536l * v41;
        long v48;
        v48 = v47 + v46;
        float * v51;
        float * v49;
        v49 = v2+v48;
        v51 = v49;
        // Pushing the loop unrolling to: 0
        long v52;
        v52 = threadIdx.x;
        long v53;
        v53 = v52 % 32l;
        long v54;
        v54 = v52 / 32l;
        long v55;
        v55 = v54 % 8l;
        long v56;
        v56 = v54 / 8l;
        bool v57;
        v57 = v56 == 0l;
        bool v58;
        v58 = v57 == false;
        if (v58){
            assert("The index has to be in the range of the dimension." && v57);
        } else {
        }
        assert("Tensor range check" && 0 <= v55 && v55 < 8l);
        assert("Tensor range check" && 0 <= v53 && v53 < 32l);
        long v60;
        v60 = 4l * v53;
        long v61;
        v61 = 2176l * v55;
        long v62;
        v62 = v61 + v60;
        long v63;
        v63 = 8192l * v55;
        long v64;
        v64 = v63 + v60;
        float * v67;
        float * v65;
        v65 = v12+v62;
        v67 = v65;
        float * v70;
        float * v68;
        v68 = v51+v64;
        v70 = v68;
        long v71;
        v71 = 0l;
        #pragma unroll
        while (while_method_0(v71)){
            long v73;
            v73 = 0l;
            #pragma unroll
            while (while_method_1(v73)){
                assert("Tensor range check" && 0 <= v71 && v71 < 16l);
                assert("Tensor range check" && 0 <= v73 && v73 < 1l);
                long v75;
                v75 = 4l * v73;
                long v76;
                v76 = 136l * v71;
                long v77;
                v77 = v76 + v75;
                long v78;
                v78 = 512l * v71;
                long v79;
                v79 = v78 + v75;
                int4* v80;
                v80 = reinterpret_cast<int4*>(v70 + v79);
                int4* v81;
                v81 = reinterpret_cast<int4*>(v67 + v77);
                assert("Pointer alignment check" && (unsigned long long)(v80) % 4l == 0 && (unsigned long long)(v81) % 4l == 0);
                *v81 = *v80;
                v73 += 1l ;
            }
            v71 += 1l ;
        }
        __syncthreads();
        long v82;
        v82 = 0l;
        #pragma unroll
        while (while_method_2(v82)){
            long v84;
            v84 = 0l;
            #pragma unroll
            while (while_method_1(v84)){
                assert("Tensor range check" && 0 <= v82 && v82 < 8l);
                assert("Tensor range check" && 0 <= v84 && v84 < 1l);
                long v86;
                v86 = v82 + v84;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v87 = v35[v86];
                assert("Tensor range check" && 0 <= v82 && v82 < 8l);
                assert("Tensor range check" && 0 <= v84 && v84 < 1l);
                long v88;
                v88 = 16l * v84;
                long v89;
                v89 = 2176l * v82;
                long v90;
                v90 = v89 + v88;
                float * v91;
                v91 = v26 + v90;
                wmma::load_matrix_sync(v87, v91, 136l, wmma::mem_row_major);
                v84 += 1l ;
            }
            v82 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        long v92;
        v92 = 0l;
        while (while_method_2(v92)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v41 && v41 < 4l);
            assert("Tensor range check" && 0 <= v92 && v92 < 8l);
            long v94;
            v94 = 64l * v92;
            long v95;
            v95 = v94 + v47;
            float * v98;
            float * v96;
            v96 = v0+v95;
            v98 = v96;
            assert("Tensor range check" && 0 <= v39 && v39 < 4l);
            long v99;
            v99 = 65536l * v39;
            assert("Tensor range check" && 0 <= v92 && v92 < 8l);
            long v100;
            v100 = v94 + v99;
            float * v103;
            float * v101;
            v101 = v1+v100;
            v103 = v101;
            long v104;
            v104 = threadIdx.x;
            long v105;
            v105 = v104 % 16l;
            long v106;
            v106 = v104 / 16l;
            long v107;
            v107 = v106 % 16l;
            long v108;
            v108 = v106 / 16l;
            bool v109;
            v109 = v108 == 0l;
            bool v110;
            v110 = v109 == false;
            if (v110){
                assert("The index has to be in the range of the dimension." && v109);
            } else {
            }
            assert("Tensor range check" && 0 <= v107 && v107 < 16l);
            assert("Tensor range check" && 0 <= v105 && v105 < 16l);
            long v112;
            v112 = 4l * v105;
            long v113;
            v113 = 544l * v107;
            long v114;
            v114 = v113 + v112;
            long v115;
            v115 = 4096l * v107;
            long v116;
            v116 = v115 + v112;
            float * v119;
            float * v117;
            v117 = v9+v114;
            v119 = v117;
            float * v122;
            float * v120;
            v120 = v103+v116;
            v122 = v120;
            long v123;
            v123 = 0l;
            #pragma unroll
            while (while_method_2(v123)){
                long v125;
                v125 = 0l;
                #pragma unroll
                while (while_method_1(v125)){
                    assert("Tensor range check" && 0 <= v123 && v123 < 8l);
                    assert("Tensor range check" && 0 <= v125 && v125 < 1l);
                    long v127;
                    v127 = 4l * v125;
                    long v128;
                    v128 = 68l * v123;
                    long v129;
                    v129 = v128 + v127;
                    long v130;
                    v130 = 512l * v123;
                    long v131;
                    v131 = v130 + v127;
                    int4* v132;
                    v132 = reinterpret_cast<int4*>(v122 + v131);
                    int4* v133;
                    v133 = reinterpret_cast<int4*>(v119 + v129);
                    assert("Pointer alignment check" && (unsigned long long)(v132) % 4l == 0 && (unsigned long long)(v133) % 4l == 0);
                    *v133 = *v132;
                    v125 += 1l ;
                }
                v123 += 1l ;
            }
            long v134;
            v134 = threadIdx.x;
            long v135;
            v135 = v134 % 16l;
            long v136;
            v136 = v134 / 16l;
            long v137;
            v137 = v136 % 16l;
            long v138;
            v138 = v136 / 16l;
            bool v139;
            v139 = v138 == 0l;
            bool v140;
            v140 = v139 == false;
            if (v140){
                assert("The index has to be in the range of the dimension." && v139);
            } else {
            }
            assert("Tensor range check" && 0 <= v137 && v137 < 16l);
            assert("Tensor range check" && 0 <= v135 && v135 < 16l);
            long v142;
            v142 = 4l * v135;
            long v143;
            v143 = 544l * v137;
            long v144;
            v144 = v143 + v142;
            long v145;
            v145 = 4096l * v137;
            long v146;
            v146 = v145 + v142;
            float * v149;
            float * v147;
            v147 = v6+v144;
            v149 = v147;
            float * v152;
            float * v150;
            v150 = v98+v146;
            v152 = v150;
            long v153;
            v153 = 0l;
            #pragma unroll
            while (while_method_2(v153)){
                long v155;
                v155 = 0l;
                #pragma unroll
                while (while_method_1(v155)){
                    assert("Tensor range check" && 0 <= v153 && v153 < 8l);
                    assert("Tensor range check" && 0 <= v155 && v155 < 1l);
                    long v157;
                    v157 = 4l * v155;
                    long v158;
                    v158 = 68l * v153;
                    long v159;
                    v159 = v158 + v157;
                    long v160;
                    v160 = 512l * v153;
                    long v161;
                    v161 = v160 + v157;
                    int4* v162;
                    v162 = reinterpret_cast<int4*>(v152 + v161);
                    int4* v163;
                    v163 = reinterpret_cast<int4*>(v149 + v159);
                    assert("Pointer alignment check" && (unsigned long long)(v162) % 4l == 0 && (unsigned long long)(v163) % 4l == 0);
                    *v163 = *v162;
                    v155 += 1l ;
                }
                v153 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v164[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v165[8l];
            long v166;
            v166 = 0l;
            #pragma unroll
            while (while_method_2(v166)){
                long v168;
                v168 = 0l;
                #pragma unroll
                while (while_method_2(v168)){
                    assert("Tensor range check" && 0 <= v166 && v166 < 8l);
                    long v170;
                    v170 = 1088l * v166;
                    assert("Tensor range check" && 0 <= v168 && v168 < 8l);
                    long v171;
                    v171 = 8l * v168;
                    long v172;
                    v172 = v171 + v170;
                    assert("Tensor range check" && 0 <= v166 && v166 < 8l);
                    assert("Tensor range check" && 0 <= v168 && v168 < 8l);
                    long v173;
                    v173 = 8l * v166;
                    long v174;
                    v174 = v173 + v168;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v175 = v164[v174];
                    float * v176;
                    v176 = v30 + v172;
                    wmma::load_matrix_sync(v175, v176, 68l);
                    #pragma unroll
                    for (int t = 0; t < v175.num_elements; t++) { v175.x[t] = wmma::__float_to_tf32(v175.x[t]); };
                    v168 += 1l ;
                }
                v166 += 1l ;
            }
            long v177;
            v177 = 0l;
            #pragma unroll
            while (while_method_1(v177)){
                long v179;
                v179 = 0l;
                #pragma unroll
                while (while_method_2(v179)){
                    assert("Tensor range check" && 0 <= v177 && v177 < 1l);
                    long v181;
                    v181 = 1088l * v177;
                    assert("Tensor range check" && 0 <= v179 && v179 < 8l);
                    long v182;
                    v182 = 8l * v179;
                    long v183;
                    v183 = v182 + v181;
                    assert("Tensor range check" && 0 <= v177 && v177 < 1l);
                    assert("Tensor range check" && 0 <= v179 && v179 < 8l);
                    long v184;
                    v184 = 8l * v177;
                    long v185;
                    v185 = v184 + v179;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v186 = v165[v185];
                    float * v187;
                    v187 = v34 + v183;
                    wmma::load_matrix_sync(v186, v187, 68l);
                    #pragma unroll
                    for (int t = 0; t < v186.num_elements; t++) { v186.x[t] = wmma::__float_to_tf32(v186.x[t]); };
                    v179 += 1l ;
                }
                v177 += 1l ;
            }
            long v188;
            v188 = 0l;
            #pragma unroll
            while (while_method_2(v188)){
                long v190;
                v190 = 0l;
                #pragma unroll
                while (while_method_1(v190)){
                    long v192;
                    v192 = 0l;
                    #pragma unroll
                    while (while_method_2(v192)){
                        assert("Tensor range check" && 0 <= v188 && v188 < 8l);
                        assert("Tensor range check" && 0 <= v190 && v190 < 1l);
                        long v194;
                        v194 = v188 + v190;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v195 = v35[v194];
                        assert("Tensor range check" && 0 <= v188 && v188 < 8l);
                        assert("Tensor range check" && 0 <= v192 && v192 < 8l);
                        long v196;
                        v196 = 8l * v188;
                        long v197;
                        v197 = v196 + v192;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v198 = v164[v197];
                        assert("Tensor range check" && 0 <= v190 && v190 < 1l);
                        assert("Tensor range check" && 0 <= v192 && v192 < 8l);
                        long v199;
                        v199 = 8l * v190;
                        long v200;
                        v200 = v199 + v192;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v201 = v165[v200];
                        wmma::mma_sync(v195, v198, v201, v195);
                        v192 += 1l ;
                    }
                    v190 += 1l ;
                }
                v188 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v92 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v202;
        v202 = threadIdx.x;
        long v203;
        v203 = v202 % 32l;
        long v204;
        v204 = v202 / 32l;
        long v205;
        v205 = v204 % 8l;
        long v206;
        v206 = v204 / 8l;
        bool v207;
        v207 = v206 == 0l;
        bool v208;
        v208 = v207 == false;
        if (v208){
            assert("The index has to be in the range of the dimension." && v207);
        } else {
        }
        assert("Tensor range check" && 0 <= v205 && v205 < 8l);
        assert("Tensor range check" && 0 <= v203 && v203 < 32l);
        long v210;
        v210 = 4l * v203;
        long v211;
        v211 = 2176l * v205;
        long v212;
        v212 = v211 + v210;
        long v213;
        v213 = 8192l * v205;
        long v214;
        v214 = v213 + v210;
        float * v217;
        float * v215;
        v215 = v12+v212;
        v217 = v215;
        float * v220;
        float * v218;
        v218 = v51+v214;
        v220 = v218;
        long v221;
        v221 = 0l;
        #pragma unroll
        while (while_method_0(v221)){
            long v223;
            v223 = 0l;
            #pragma unroll
            while (while_method_1(v223)){
                assert("Tensor range check" && 0 <= v221 && v221 < 16l);
                assert("Tensor range check" && 0 <= v223 && v223 < 1l);
                long v225;
                v225 = 4l * v223;
                long v226;
                v226 = 136l * v221;
                long v227;
                v227 = v226 + v225;
                long v228;
                v228 = 512l * v221;
                long v229;
                v229 = v228 + v225;
                int4* v230;
                v230 = reinterpret_cast<int4*>(v220 + v229);
                int4* v231;
                v231 = reinterpret_cast<int4*>(v217 + v227);
                assert("Pointer alignment check" && (unsigned long long)(v230) % 4l == 0 && (unsigned long long)(v231) % 4l == 0);
                *v231 = *v230;
                v223 += 1l ;
            }
            v221 += 1l ;
        }
        __syncthreads();
        long v232;
        v232 = 0l;
        #pragma unroll
        while (while_method_2(v232)){
            long v234;
            v234 = 0l;
            #pragma unroll
            while (while_method_1(v234)){
                assert("Tensor range check" && 0 <= v232 && v232 < 8l);
                assert("Tensor range check" && 0 <= v234 && v234 < 1l);
                long v236;
                v236 = v232 + v234;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v237 = v35[v236];
                assert("Tensor range check" && 0 <= v232 && v232 < 8l);
                assert("Tensor range check" && 0 <= v234 && v234 < 1l);
                long v238;
                v238 = 16l * v234;
                long v239;
                v239 = 2176l * v232;
                long v240;
                v240 = v239 + v238;
                float * v241;
                v241 = v26 + v240;
                wmma::store_matrix_sync(v241, v237, 136l, wmma::mem_row_major);
                v234 += 1l ;
            }
            v232 += 1l ;
        }
        __syncthreads();
        long v242;
        v242 = threadIdx.x;
        long v243;
        v243 = v242 % 32l;
        long v244;
        v244 = v242 / 32l;
        long v245;
        v245 = v244 % 8l;
        long v246;
        v246 = v244 / 8l;
        bool v247;
        v247 = v246 == 0l;
        bool v248;
        v248 = v247 == false;
        if (v248){
            assert("The index has to be in the range of the dimension." && v247);
        } else {
        }
        assert("Tensor range check" && 0 <= v245 && v245 < 8l);
        assert("Tensor range check" && 0 <= v243 && v243 < 32l);
        long v250;
        v250 = 4l * v243;
        long v251;
        v251 = 8192l * v245;
        long v252;
        v252 = v251 + v250;
        long v253;
        v253 = 2176l * v245;
        long v254;
        v254 = v253 + v250;
        float * v257;
        float * v255;
        v255 = v51+v252;
        v257 = v255;
        float * v260;
        float * v258;
        v258 = v12+v254;
        v260 = v258;
        long v261;
        v261 = 0l;
        #pragma unroll
        while (while_method_0(v261)){
            long v263;
            v263 = 0l;
            #pragma unroll
            while (while_method_1(v263)){
                assert("Tensor range check" && 0 <= v261 && v261 < 16l);
                assert("Tensor range check" && 0 <= v263 && v263 < 1l);
                long v265;
                v265 = 4l * v263;
                long v266;
                v266 = 512l * v261;
                long v267;
                v267 = v266 + v265;
                long v268;
                v268 = 136l * v261;
                long v269;
                v269 = v268 + v265;
                int4* v270;
                v270 = reinterpret_cast<int4*>(v260 + v269);
                int4* v271;
                v271 = reinterpret_cast<int4*>(v257 + v267);
                assert("Pointer alignment check" && (unsigned long long)(v270) % 4l == 0 && (unsigned long long)(v271) % 4l == 0);
                *v271 = *v270;
                v263 += 1l ;
            }
            v261 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v37 += 24l ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550')
options.append('--dopt=on')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
    del v0
    return v1
def main():
    v0 = cp.random.normal(0.0,1.0,262144,cp.float32)
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
    v5 = cp.random.normal(0.0,1.0,262144,cp.float32)
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
    v10 = cp.random.normal(0.0,1.0,262144,cp.float32)
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
        v22 = (cp.matmul(v18,v20) + v21).flatten()
        del v18, v20, v21
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
        v28((24,),(256,),(v10, v5, v0),shared_mem=69632)
        del v28
        v29 = cp.max(cp.abs(v0-v22))
        del v22
        v30 = v29 + v16
        del v29
        v16 = v30
        del v30
        v15 += 1 
    del v0, v5, v10, v15
    return v16

if __name__ == '__main__': print(main())
