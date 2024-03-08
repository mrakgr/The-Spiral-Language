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
    v1 = v0 < 64l;
    return v1;
}
__device__ inline bool while_method_4(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
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
    long v35;
    v35 = blockIdx.x;
    long v36;
    v36 = v35;
    while (while_method_0(v36)){
        long v38;
        v38 = v36 % 4l;
        long v39;
        v39 = v36 / 4l;
        long v40;
        v40 = v39 % 4l;
        long v41;
        v41 = v39 / 4l;
        bool v42;
        v42 = v41 == 0l;
        bool v43;
        v43 = v42 == false;
        if (v43){
            assert("The index has to be in the range of the dimension." && v42);
        } else {
        }
        assert("Tensor range check" && 0 <= v40 && v40 < 4l);
        assert("Tensor range check" && 0 <= v38 && v38 < 4l);
        long v45;
        v45 = 128l * v38;
        long v46;
        v46 = 65536l * v40;
        long v47;
        v47 = v46 + v45;
        float * v50;
        float * v48;
        v48 = v2+v47;
        v50 = v48;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v51[8l];
        // Pushing the loop unrolling to: 0
        long v52;
        v52 = 0l;
        #pragma unroll
        while (while_method_1(v52)){
            long v54;
            v54 = 0l;
            #pragma unroll
            while (while_method_2(v54)){
                assert("Tensor range check" && 0 <= v52 && v52 < 8l);
                assert("Tensor range check" && 0 <= v54 && v54 < 1l);
                long v56;
                v56 = v52 + v54;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v57 = v51[v56];
                wmma::fill_fragment(v57, 0.0f);
                v54 += 1l ;
            }
            v52 += 1l ;
        }
        // Poping the loop unrolling to: 0
        long v58;
        v58 = 0l;
        while (while_method_1(v58)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v40 && v40 < 4l);
            assert("Tensor range check" && 0 <= v58 && v58 < 8l);
            long v60;
            v60 = 64l * v58;
            long v61;
            v61 = v60 + v46;
            float * v64;
            float * v62;
            v62 = v0+v61;
            v64 = v62;
            assert("Tensor range check" && 0 <= v38 && v38 < 4l);
            long v65;
            v65 = 65536l * v38;
            assert("Tensor range check" && 0 <= v58 && v58 < 8l);
            long v66;
            v66 = v60 + v65;
            float * v69;
            float * v67;
            v67 = v1+v66;
            v69 = v67;
            long v70;
            v70 = threadIdx.x;
            long v71;
            v71 = v70 % 16l;
            long v72;
            v72 = v70 / 16l;
            long v73;
            v73 = v72 % 16l;
            long v74;
            v74 = v72 / 16l;
            bool v75;
            v75 = v74 == 0l;
            bool v76;
            v76 = v75 == false;
            if (v76){
                assert("The index has to be in the range of the dimension." && v75);
            } else {
            }
            assert("Tensor range check" && 0 <= v73 && v73 < 16l);
            assert("Tensor range check" && 0 <= v71 && v71 < 16l);
            long v78;
            v78 = 4l * v71;
            long v79;
            v79 = 544l * v73;
            long v80;
            v80 = v79 + v78;
            long v81;
            v81 = 4096l * v73;
            long v82;
            v82 = v81 + v78;
            float * v85;
            float * v83;
            v83 = v9+v80;
            v85 = v83;
            float * v88;
            float * v86;
            v86 = v69+v82;
            v88 = v86;
            long v89;
            v89 = 0l;
            #pragma unroll
            while (while_method_1(v89)){
                long v91;
                v91 = 0l;
                #pragma unroll
                while (while_method_2(v91)){
                    assert("Tensor range check" && 0 <= v89 && v89 < 8l);
                    assert("Tensor range check" && 0 <= v91 && v91 < 1l);
                    long v93;
                    v93 = 4l * v91;
                    long v94;
                    v94 = 68l * v89;
                    long v95;
                    v95 = v94 + v93;
                    long v96;
                    v96 = 512l * v89;
                    long v97;
                    v97 = v96 + v93;
                    int4* v98;
                    v98 = reinterpret_cast<int4*>(v88 + v97);
                    int4* v99;
                    v99 = reinterpret_cast<int4*>(v85 + v95);
                    assert("Pointer alignment check" && (unsigned long long)(v98) % 4l == 0 && (unsigned long long)(v99) % 4l == 0);
                    *v99 = *v98;
                    v91 += 1l ;
                }
                v89 += 1l ;
            }
            long v100;
            v100 = threadIdx.x;
            long v101;
            v101 = v100 % 16l;
            long v102;
            v102 = v100 / 16l;
            long v103;
            v103 = v102 % 16l;
            long v104;
            v104 = v102 / 16l;
            bool v105;
            v105 = v104 == 0l;
            bool v106;
            v106 = v105 == false;
            if (v106){
                assert("The index has to be in the range of the dimension." && v105);
            } else {
            }
            assert("Tensor range check" && 0 <= v103 && v103 < 16l);
            assert("Tensor range check" && 0 <= v101 && v101 < 16l);
            long v108;
            v108 = 4l * v101;
            long v109;
            v109 = 544l * v103;
            long v110;
            v110 = v109 + v108;
            long v111;
            v111 = 4096l * v103;
            long v112;
            v112 = v111 + v108;
            float * v115;
            float * v113;
            v113 = v6+v110;
            v115 = v113;
            float * v118;
            float * v116;
            v116 = v64+v112;
            v118 = v116;
            long v119;
            v119 = 0l;
            #pragma unroll
            while (while_method_1(v119)){
                long v121;
                v121 = 0l;
                #pragma unroll
                while (while_method_2(v121)){
                    assert("Tensor range check" && 0 <= v119 && v119 < 8l);
                    assert("Tensor range check" && 0 <= v121 && v121 < 1l);
                    long v123;
                    v123 = 4l * v121;
                    long v124;
                    v124 = 68l * v119;
                    long v125;
                    v125 = v124 + v123;
                    long v126;
                    v126 = 512l * v119;
                    long v127;
                    v127 = v126 + v123;
                    int4* v128;
                    v128 = reinterpret_cast<int4*>(v118 + v127);
                    int4* v129;
                    v129 = reinterpret_cast<int4*>(v115 + v125);
                    assert("Pointer alignment check" && (unsigned long long)(v128) % 4l == 0 && (unsigned long long)(v129) % 4l == 0);
                    *v129 = *v128;
                    v121 += 1l ;
                }
                v119 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v130[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v131[8l];
            long v132;
            v132 = 0l;
            #pragma unroll
            while (while_method_1(v132)){
                long v134;
                v134 = 0l;
                #pragma unroll
                while (while_method_1(v134)){
                    assert("Tensor range check" && 0 <= v132 && v132 < 8l);
                    long v136;
                    v136 = 1088l * v132;
                    assert("Tensor range check" && 0 <= v134 && v134 < 8l);
                    long v137;
                    v137 = 8l * v134;
                    long v138;
                    v138 = v137 + v136;
                    assert("Tensor range check" && 0 <= v132 && v132 < 8l);
                    assert("Tensor range check" && 0 <= v134 && v134 < 8l);
                    long v139;
                    v139 = 8l * v132;
                    long v140;
                    v140 = v139 + v134;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v141 = v130[v140];
                    float * v142;
                    v142 = v30 + v138;
                    wmma::load_matrix_sync(v141, v142, 68l);
                    #pragma unroll
                    for (int t = 0; t < v141.num_elements; t++) { v141.x[t] = wmma::__float_to_tf32(v141.x[t]); };
                    v134 += 1l ;
                }
                v132 += 1l ;
            }
            long v143;
            v143 = 0l;
            #pragma unroll
            while (while_method_2(v143)){
                long v145;
                v145 = 0l;
                #pragma unroll
                while (while_method_1(v145)){
                    assert("Tensor range check" && 0 <= v143 && v143 < 1l);
                    long v147;
                    v147 = 1088l * v143;
                    assert("Tensor range check" && 0 <= v145 && v145 < 8l);
                    long v148;
                    v148 = 8l * v145;
                    long v149;
                    v149 = v148 + v147;
                    assert("Tensor range check" && 0 <= v143 && v143 < 1l);
                    assert("Tensor range check" && 0 <= v145 && v145 < 8l);
                    long v150;
                    v150 = 8l * v143;
                    long v151;
                    v151 = v150 + v145;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v152 = v131[v151];
                    float * v153;
                    v153 = v34 + v149;
                    wmma::load_matrix_sync(v152, v153, 68l);
                    #pragma unroll
                    for (int t = 0; t < v152.num_elements; t++) { v152.x[t] = wmma::__float_to_tf32(v152.x[t]); };
                    v145 += 1l ;
                }
                v143 += 1l ;
            }
            long v154;
            v154 = 0l;
            #pragma unroll
            while (while_method_1(v154)){
                long v156;
                v156 = 0l;
                #pragma unroll
                while (while_method_2(v156)){
                    long v158;
                    v158 = 0l;
                    #pragma unroll
                    while (while_method_1(v158)){
                        assert("Tensor range check" && 0 <= v154 && v154 < 8l);
                        assert("Tensor range check" && 0 <= v156 && v156 < 1l);
                        long v160;
                        v160 = v154 + v156;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v161 = v51[v160];
                        assert("Tensor range check" && 0 <= v154 && v154 < 8l);
                        assert("Tensor range check" && 0 <= v158 && v158 < 8l);
                        long v162;
                        v162 = 8l * v154;
                        long v163;
                        v163 = v162 + v158;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v164 = v130[v163];
                        assert("Tensor range check" && 0 <= v156 && v156 < 1l);
                        assert("Tensor range check" && 0 <= v158 && v158 < 8l);
                        long v165;
                        v165 = 8l * v156;
                        long v166;
                        v166 = v165 + v158;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v167 = v131[v166];
                        wmma::mma_sync(v161, v164, v167, v161);
                        v158 += 1l ;
                    }
                    v156 += 1l ;
                }
                v154 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v58 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v168;
        v168 = threadIdx.x;
        long v169;
        v169 = v168 % 128l;
        long v170;
        v170 = v168 / 128l;
        long v171;
        v171 = v170 % 2l;
        long v172;
        v172 = v170 / 2l;
        bool v173;
        v173 = v172 == 0l;
        bool v174;
        v174 = v173 == false;
        if (v174){
            assert("The index has to be in the range of the dimension." && v173);
        } else {
        }
        assert("Tensor range check" && 0 <= v171 && v171 < 2l);
        assert("Tensor range check" && 0 <= v169 && v169 < 128l);
        long v176;
        v176 = 8704l * v171;
        long v177;
        v177 = v176 + v169;
        long v178;
        v178 = 32768l * v171;
        long v179;
        v179 = v178 + v169;
        float * v182;
        float * v180;
        v180 = v12+v177;
        v182 = v180;
        float * v185;
        float * v183;
        v183 = v50+v179;
        v185 = v183;
        long v186;
        v186 = 0l;
        #pragma unroll
        while (while_method_3(v186)){
            long v188;
            v188 = 0l;
            #pragma unroll
            while (while_method_2(v188)){
                assert("Tensor range check" && 0 <= v186 && v186 < 64l);
                assert("Tensor range check" && 0 <= v188 && v188 < 1l);
                long v190;
                v190 = 136l * v186;
                long v191;
                v191 = v190 + v188;
                long v192;
                v192 = 512l * v186;
                long v193;
                v193 = v192 + v188;
                int* v194;
                v194 = reinterpret_cast<int*>(v185 + v193);
                int* v195;
                v195 = reinterpret_cast<int*>(v182 + v191);
                assert("Pointer alignment check" && (unsigned long long)(v194) % 1l == 0 && (unsigned long long)(v195) % 1l == 0);
                *v195 = *v194;
                v188 += 1l ;
            }
            v186 += 1l ;
        }
        __syncthreads();
        long v196;
        v196 = 0l;
        #pragma unroll
        while (while_method_1(v196)){
            long v198;
            v198 = 0l;
            #pragma unroll
            while (while_method_2(v198)){
                assert("Tensor range check" && 0 <= v196 && v196 < 8l);
                assert("Tensor range check" && 0 <= v198 && v198 < 1l);
                long v200;
                v200 = v196 + v198;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v201 = v51[v200];
                assert("Tensor range check" && 0 <= v196 && v196 < 8l);
                assert("Tensor range check" && 0 <= v198 && v198 < 1l);
                long v202;
                v202 = 16l * v198;
                long v203;
                v203 = 2176l * v196;
                long v204;
                v204 = v203 + v202;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v205;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v206 = v205;
                float * v207;
                v207 = v26 + v204;
                wmma::load_matrix_sync(v206, v207, 136l, wmma::mem_row_major);
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v208 = v201;
                long v209;
                v209 = v208.num_elements;
                long v210;
                v210 = 0l;
                #pragma unroll
                while (while_method_4(v209, v210)){
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v212 = v201;
                    float v213;
                    v213 = v212.x[v210];
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v214 = v206;
                    float v215;
                    v215 = v214.x[v210];
                    float v216;
                    v216 = v213 + v215;
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v217 = v201;
                    v217.x[v210] = v216;
                    v210 += 1l ;
                }
                float * v218;
                v218 = v26 + v204;
                wmma::store_matrix_sync(v218, v201, 136l, wmma::mem_row_major);
                v198 += 1l ;
            }
            v196 += 1l ;
        }
        __syncthreads();
        long v219;
        v219 = threadIdx.x;
        long v220;
        v220 = v219 % 32l;
        long v221;
        v221 = v219 / 32l;
        long v222;
        v222 = v221 % 8l;
        long v223;
        v223 = v221 / 8l;
        bool v224;
        v224 = v223 == 0l;
        bool v225;
        v225 = v224 == false;
        if (v225){
            assert("The index has to be in the range of the dimension." && v224);
        } else {
        }
        assert("Tensor range check" && 0 <= v222 && v222 < 8l);
        assert("Tensor range check" && 0 <= v220 && v220 < 32l);
        long v227;
        v227 = 4l * v220;
        long v228;
        v228 = 8192l * v222;
        long v229;
        v229 = v228 + v227;
        long v230;
        v230 = 2176l * v222;
        long v231;
        v231 = v230 + v227;
        float * v234;
        float * v232;
        v232 = v50+v229;
        v234 = v232;
        float * v237;
        float * v235;
        v235 = v12+v231;
        v237 = v235;
        long v238;
        v238 = 0l;
        #pragma unroll
        while (while_method_0(v238)){
            long v240;
            v240 = 0l;
            #pragma unroll
            while (while_method_2(v240)){
                assert("Tensor range check" && 0 <= v238 && v238 < 16l);
                assert("Tensor range check" && 0 <= v240 && v240 < 1l);
                long v242;
                v242 = 4l * v240;
                long v243;
                v243 = 512l * v238;
                long v244;
                v244 = v243 + v242;
                long v245;
                v245 = 136l * v238;
                long v246;
                v246 = v245 + v242;
                int4* v247;
                v247 = reinterpret_cast<int4*>(v237 + v246);
                int4* v248;
                v248 = reinterpret_cast<int4*>(v234 + v244);
                assert("Pointer alignment check" && (unsigned long long)(v247) % 4l == 0 && (unsigned long long)(v248) % 4l == 0);
                *v248 = *v247;
                v240 += 1l ;
            }
            v238 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v36 += 24l ;
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
        v27 = v15 == 0
        if v27:
            max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),256,is_print=True)
        else:
            pass
        del v27
        v28 = 0
        v29 = raw_module.get_function(f"entry{v28}")
        del v28
        v29.max_dynamic_shared_size_bytes = 69632 
        v29((24,),(256,),(v10, v5, v0),shared_mem=69632)
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
