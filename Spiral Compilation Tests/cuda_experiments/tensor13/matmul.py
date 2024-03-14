kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <assert.h>
#include <mma.h>
using namespace nvcuda;
#include <cuda/pipeline>
struct US0;
struct US0 {
    union {
        struct {
            long v0;
        } case1; // Some
    } v;
    char tag : 2;
};
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1(long v0) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_5(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    cuda::pipeline<cuda::thread_scope_thread> v3 = cuda::make_pipeline();
    extern __shared__ unsigned char v4[];
    float * v7;
    float * v5;
    v5 = reinterpret_cast<float *>(&v4[0ull]);
    v7 = v5;
    float * v10;
    float * v8;
    v8 = reinterpret_cast<float *>(&v4[17408ull]);
    v10 = v8;
    float * v13;
    float * v11;
    v11 = reinterpret_cast<float *>(&v4[0ull]);
    v13 = v11;
    long v14;
    v14 = threadIdx.x;
    long v15;
    v15 = v14 / 32l;
    bool v16;
    v16 = 0l <= v15;
    bool v17;
    v17 = v16 == false;
    if (v17){
        assert("The index needs to be zero or positive." && v16);
    } else {
    }
    long v19;
    v19 = v15 % 8l;
    long v20;
    v20 = v15 / 8l;
    bool v21;
    v21 = v20 < 2l;
    bool v22;
    v22 = v21 == false;
    if (v22){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v21);
    } else {
    }
    assert("Tensor range check" && 0 <= v20 && v20 < 2l);
    assert("Tensor range check" && 0 <= v19 && v19 < 8l);
    long v24;
    v24 = 16l * v19;
    long v25;
    v25 = 4352l * v20;
    long v26;
    v26 = v25 + v24;
    float * v29;
    float * v27;
    v27 = v13+v26;
    v29 = v27;
    assert("Tensor range check" && 0 <= v20 && v20 < 2l);
    long v30;
    v30 = 2176l * v20;
    long v31;
    v31 = threadIdx.x;
    long v32;
    v32 = v31 % 32l;
    bool v33;
    v33 = 0l <= v32;
    bool v34;
    v34 = v33 == false;
    if (v34){
        assert("The index needs to be zero or positive." && v33);
    } else {
    }
    long v36;
    v36 = v32 % 4l;
    long v37;
    v37 = v32 / 4l;
    bool v38;
    v38 = v37 < 8l;
    bool v39;
    v39 = v38 == false;
    if (v39){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v38);
    } else {
    }
    assert("Tensor range check" && 0 <= v37 && v37 < 8l);
    assert("Tensor range check" && 0 <= v36 && v36 < 4l);
    long v41;
    v41 = v36 + v30;
    long v42;
    v42 = 68l * v37;
    long v43;
    v43 = v42 + v41;
    float * v46;
    float * v44;
    v44 = v7+v43;
    v46 = v44;
    assert("Tensor range check" && 0 <= v19 && v19 < 8l);
    long v47;
    v47 = 1088l * v19;
    long v48;
    v48 = threadIdx.x;
    long v49;
    v49 = v48 % 32l;
    bool v50;
    v50 = 0l <= v49;
    bool v51;
    v51 = v50 == false;
    if (v51){
        assert("The index needs to be zero or positive." && v50);
    } else {
    }
    long v53;
    v53 = v49 % 4l;
    long v54;
    v54 = v49 / 4l;
    bool v55;
    v55 = v54 < 8l;
    bool v56;
    v56 = v55 == false;
    if (v56){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v55);
    } else {
    }
    assert("Tensor range check" && 0 <= v54 && v54 < 8l);
    assert("Tensor range check" && 0 <= v53 && v53 < 4l);
    long v58;
    v58 = v53 + v47;
    long v59;
    v59 = 68l * v54;
    long v60;
    v60 = v59 + v58;
    float * v63;
    float * v61;
    v61 = v10+v60;
    v63 = v61;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v64[2l];
    // Pushing the loop unrolling to: 1
    long v65;
    v65 = blockIdx.x;
    long v66;
    v66 = v65;
    #pragma unroll 1
    while (while_method_0(v66)){
        bool v68;
        v68 = 0l <= v66;
        bool v69;
        v69 = v68 == false;
        if (v69){
            assert("The index needs to be zero or positive." && v68);
        } else {
        }
        long v71;
        v71 = v66 % 4l;
        long v72;
        v72 = v66 / 4l;
        bool v73;
        v73 = v72 < 8l;
        bool v74;
        v74 = v73 == false;
        if (v74){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v73);
        } else {
        }
        assert("Tensor range check" && 0 <= v72 && v72 < 8l);
        assert("Tensor range check" && 0 <= v71 && v71 < 4l);
        long v76;
        v76 = 128l * v71;
        long v77;
        v77 = 32768l * v72;
        long v78;
        v78 = v77 + v76;
        float * v81;
        float * v79;
        v79 = v2+v78;
        v81 = v79;
        // Pushing the loop unrolling to: 0
        long v82;
        v82 = threadIdx.x;
        bool v83;
        v83 = 0l <= v82;
        bool v84;
        v84 = v83 == false;
        if (v84){
            assert("The index needs to be zero or positive." && v83);
        } else {
        }
        long v86;
        v86 = v82 % 32l;
        long v87;
        v87 = v82 / 32l;
        bool v88;
        v88 = v87 < 16l;
        bool v89;
        v89 = v88 == false;
        if (v89){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v88);
        } else {
        }
        assert("Tensor range check" && 0 <= v87 && v87 < 16l);
        assert("Tensor range check" && 0 <= v86 && v86 < 32l);
        long v91;
        v91 = 4l * v86;
        long v92;
        v92 = 136l * v87;
        long v93;
        v93 = v92 + v91;
        long v94;
        v94 = 512l * v87;
        long v95;
        v95 = v94 + v91;
        float * v98;
        float * v96;
        v96 = v13+v93;
        v98 = v96;
        float * v101;
        float * v99;
        v99 = v81+v95;
        v101 = v99;
        long v102;
        v102 = 0l;
        #pragma unroll
        while (while_method_1(v102)){
            long v104;
            v104 = 0l;
            #pragma unroll
            while (while_method_2(v104)){
                assert("Tensor range check" && 0 <= v102 && v102 < 4l);
                assert("Tensor range check" && 0 <= v104 && v104 < 1l);
                long v106;
                v106 = 128l * v104;
                long v107;
                v107 = 2176l * v102;
                long v108;
                v108 = v107 + v106;
                long v109;
                v109 = 8192l * v102;
                long v110;
                v110 = v109 + v106;
                int4* v111;
                v111 = reinterpret_cast<int4*>(v101 + v110);
                int4* v112;
                v112 = reinterpret_cast<int4*>(v98 + v108);
                assert("Pointer alignment check" && (unsigned long long)(v111) % 4l == 0 && (unsigned long long)(v112) % 4l == 0);
                *v112 = *v111;
                v104 += 1l ;
            }
            v102 += 1l ;
        }
        __syncthreads();
        long v113;
        v113 = 0l;
        #pragma unroll
        while (while_method_3(v113)){
            long v115;
            v115 = 0l;
            #pragma unroll
            while (while_method_2(v115)){
                assert("Tensor range check" && 0 <= v113 && v113 < 2l);
                assert("Tensor range check" && 0 <= v115 && v115 < 1l);
                long v117;
                v117 = v113 + v115;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v118 = v64[v117];
                assert("Tensor range check" && 0 <= v113 && v113 < 2l);
                assert("Tensor range check" && 0 <= v115 && v115 < 1l);
                long v119;
                v119 = 16l * v115;
                long v120;
                v120 = 2176l * v113;
                long v121;
                v121 = v120 + v119;
                float * v122;
                v122 = v29 + v121;
                wmma::load_matrix_sync(v118, v122, 136l, wmma::mem_row_major);
                v115 += 1l ;
            }
            v113 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        long v123;
        v123 = 0l;
        bool v124;
        v124 = v123 < 8l;
        if (v124){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v72 && v72 < 8l);
            float * v127;
            float * v125;
            v125 = v0+v77;
            v127 = v125;
            assert("Tensor range check" && 0 <= v71 && v71 < 4l);
            long v128;
            v128 = 65536l * v71;
            float * v131;
            float * v129;
            v129 = v1+v128;
            v131 = v129;
            long v132;
            v132 = threadIdx.x;
            bool v133;
            v133 = 0l <= v132;
            bool v134;
            v134 = v133 == false;
            if (v134){
                assert("The index needs to be zero or positive." && v133);
            } else {
            }
            long v136;
            v136 = v132 % 8l;
            long v137;
            v137 = v132 / 8l;
            long v138;
            v138 = v137 % 64l;
            long v139;
            v139 = v137 / 64l;
            bool v140;
            v140 = v139 < 1l;
            bool v141;
            v141 = v140 == false;
            if (v141){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v140);
            } else {
            }
            assert("Tensor range check" && 0 <= v139 && v139 < 1l);
            assert("Tensor range check" && 0 <= v138 && v138 < 64l);
            assert("Tensor range check" && 0 <= v136 && v136 < 8l);
            long v143;
            v143 = 4l * v136;
            long v144;
            v144 = 68l * v138;
            long v145;
            v145 = v144 + v143;
            long v146;
            v146 = 32l * v139;
            long v147;
            v147 = v146 + v145;
            long v148;
            v148 = 512l * v138;
            long v149;
            v149 = v148 + v143;
            long v150;
            v150 = v146 + v149;
            float * v153;
            float * v151;
            v151 = v10+v147;
            v153 = v151;
            float * v156;
            float * v154;
            v154 = v131+v150;
            v156 = v154;
            v3.producer_acquire();
            constexpr long v157 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v156 + 0l) % v157 == 0 && (unsigned long long)(v153 + 0l) % v157 == 0);
            cuda::memcpy_async(v153 + 0l, v156 + 0l, cuda::aligned_size_t<v157>(v157), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v158 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v156 + 32768l) % v158 == 0 && (unsigned long long)(v153 + 4352l) % v158 == 0);
            cuda::memcpy_async(v153 + 4352l, v156 + 32768l, cuda::aligned_size_t<v158>(v158), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v159 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v156 + 32l) % v159 == 0 && (unsigned long long)(v153 + 32l) % v159 == 0);
            cuda::memcpy_async(v153 + 32l, v156 + 32l, cuda::aligned_size_t<v159>(v159), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v160 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v156 + 32800l) % v160 == 0 && (unsigned long long)(v153 + 4384l) % v160 == 0);
            cuda::memcpy_async(v153 + 4384l, v156 + 32800l, cuda::aligned_size_t<v160>(v160), v3);
            v3.producer_commit();
            long v161;
            v161 = threadIdx.x;
            bool v162;
            v162 = 0l <= v161;
            bool v163;
            v163 = v162 == false;
            if (v163){
                assert("The index needs to be zero or positive." && v162);
            } else {
            }
            long v165;
            v165 = v161 % 8l;
            long v166;
            v166 = v161 / 8l;
            long v167;
            v167 = v166 % 64l;
            long v168;
            v168 = v166 / 64l;
            bool v169;
            v169 = v168 < 1l;
            bool v170;
            v170 = v169 == false;
            if (v170){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v169);
            } else {
            }
            assert("Tensor range check" && 0 <= v168 && v168 < 1l);
            assert("Tensor range check" && 0 <= v167 && v167 < 64l);
            assert("Tensor range check" && 0 <= v165 && v165 < 8l);
            long v172;
            v172 = 4l * v165;
            long v173;
            v173 = 68l * v167;
            long v174;
            v174 = v173 + v172;
            long v175;
            v175 = 32l * v168;
            long v176;
            v176 = v175 + v174;
            long v177;
            v177 = 512l * v167;
            long v178;
            v178 = v177 + v172;
            long v179;
            v179 = v175 + v178;
            float * v182;
            float * v180;
            v180 = v7+v176;
            v182 = v180;
            float * v185;
            float * v183;
            v183 = v127+v179;
            v185 = v183;
            v3.producer_acquire();
            constexpr long v186 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v185 + 0l) % v186 == 0 && (unsigned long long)(v182 + 0l) % v186 == 0);
            cuda::memcpy_async(v182 + 0l, v185 + 0l, cuda::aligned_size_t<v186>(v186), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v187 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v185 + 32l) % v187 == 0 && (unsigned long long)(v182 + 32l) % v187 == 0);
            cuda::memcpy_async(v182 + 32l, v185 + 32l, cuda::aligned_size_t<v187>(v187), v3);
            v3.producer_commit();
            // Poping the loop unrolling to: 0
        } else {
        }
        #pragma unroll 1
        while (while_method_4(v123)){
            long v189;
            v189 = v123 + 1l;
            bool v190;
            v190 = v189 < 8l;
            US0 v196;
            if (v190){
                bool v191;
                v191 = 0l <= v189;
                bool v192;
                v192 = v191 == false;
                if (v192){
                    assert("The index needs to be zero or positive." && v191);
                } else {
                }
                v196 = US0_1(v189);
            } else {
                v196 = US0_0();
            }
            // Pushing the loop unrolling to: 0
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v197[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v198[8l];
            cuda::pipeline_consumer_wait_prior<0>(v3);;
            __syncthreads();
            long v199;
            v199 = 0l;
            #pragma unroll
            while (while_method_3(v199)){
                long v201;
                v201 = 0l;
                #pragma unroll
                while (while_method_5(v201)){
                    assert("Tensor range check" && 0 <= v199 && v199 < 2l);
                    assert("Tensor range check" && 0 <= v201 && v201 < 8l);
                    long v203;
                    v203 = 8l * v199;
                    long v204;
                    v204 = v203 + v201;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v205 = v197[v204];
                    assert("Tensor range check" && 0 <= v199 && v199 < 2l);
                    long v206;
                    v206 = 1088l * v199;
                    assert("Tensor range check" && 0 <= v201 && v201 < 8l);
                    long v207;
                    v207 = 8l * v201;
                    long v208;
                    v208 = v207 + v206;
                    long v209;
                    v209 = 0l;
                    #pragma unroll
                    while (while_method_3(v209)){
                        long v211;
                        v211 = 0l;
                        #pragma unroll
                        while (while_method_3(v211)){
                            assert("Tensor range check" && 0 <= v209 && v209 < 2l);
                            assert("Tensor range check" && 0 <= v211 && v211 < 2l);
                            long v213;
                            v213 = 544l * v211;
                            long v214;
                            v214 = v213 + v208;
                            long v215;
                            v215 = 4l * v209;
                            long v216;
                            v216 = v215 + v214;
                            float v217;
                            v217 = v46[v216];
                            bool v218;
                            v218 = 0l <= v211;
                            bool v220;
                            if (v218){
                                bool v219;
                                v219 = v211 < 2l;
                                v220 = v219;
                            } else {
                                v220 = false;
                            }
                            bool v221;
                            v221 = v220 == false;
                            if (v221){
                                assert("The indices should be inside the range of the dimension." && v220);
                            } else {
                            }
                            bool v223;
                            v223 = 0l <= v209;
                            bool v225;
                            if (v223){
                                bool v224;
                                v224 = v209 < 2l;
                                v225 = v224;
                            } else {
                                v225 = false;
                            }
                            bool v226;
                            v226 = v225 == false;
                            if (v226){
                                assert("The indices should be inside the range of the dimension." && v225);
                            } else {
                            }
                            long v228;
                            v228 = v209 * 2l;
                            long v229;
                            v229 = v211 + v228;
                            v205.x[v229] = v217;
                            v211 += 1l ;
                        }
                        v209 += 1l ;
                    }
                    v201 += 1l ;
                }
                v199 += 1l ;
            }
            long v230;
            v230 = 0l;
            #pragma unroll
            while (while_method_2(v230)){
                long v232;
                v232 = 0l;
                #pragma unroll
                while (while_method_5(v232)){
                    assert("Tensor range check" && 0 <= v230 && v230 < 1l);
                    assert("Tensor range check" && 0 <= v232 && v232 < 8l);
                    long v234;
                    v234 = 8l * v230;
                    long v235;
                    v235 = v234 + v232;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v236 = v198[v235];
                    assert("Tensor range check" && 0 <= v230 && v230 < 1l);
                    long v237;
                    v237 = 1088l * v230;
                    assert("Tensor range check" && 0 <= v232 && v232 < 8l);
                    long v238;
                    v238 = 8l * v232;
                    long v239;
                    v239 = v238 + v237;
                    long v240;
                    v240 = 0l;
                    #pragma unroll
                    while (while_method_3(v240)){
                        long v242;
                        v242 = 0l;
                        #pragma unroll
                        while (while_method_3(v242)){
                            assert("Tensor range check" && 0 <= v240 && v240 < 2l);
                            assert("Tensor range check" && 0 <= v242 && v242 < 2l);
                            long v244;
                            v244 = 4l * v242;
                            long v245;
                            v245 = v244 + v239;
                            long v246;
                            v246 = 544l * v240;
                            long v247;
                            v247 = v246 + v245;
                            float v248;
                            v248 = v63[v247];
                            bool v249;
                            v249 = 0l <= v242;
                            bool v251;
                            if (v249){
                                bool v250;
                                v250 = v242 < 2l;
                                v251 = v250;
                            } else {
                                v251 = false;
                            }
                            bool v252;
                            v252 = v251 == false;
                            if (v252){
                                assert("The indices should be inside the range of the dimension." && v251);
                            } else {
                            }
                            bool v254;
                            v254 = 0l <= v240;
                            bool v256;
                            if (v254){
                                bool v255;
                                v255 = v240 < 2l;
                                v256 = v255;
                            } else {
                                v256 = false;
                            }
                            bool v257;
                            v257 = v256 == false;
                            if (v257){
                                assert("The indices should be inside the range of the dimension." && v256);
                            } else {
                            }
                            long v259;
                            v259 = v240 * 2l;
                            long v260;
                            v260 = v242 + v259;
                            v236.x[v260] = v248;
                            v242 += 1l ;
                        }
                        v240 += 1l ;
                    }
                    v232 += 1l ;
                }
                v230 += 1l ;
            }
            v3.consumer_release();
            __syncthreads();
            switch (v196.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    long v261 = v196.v.case1.v0;
                    // Pushing the loop unrolling to: 0
                    assert("Tensor range check" && 0 <= v72 && v72 < 8l);
                    assert("Tensor range check" && 0 <= v261 && v261 < 8l);
                    long v262;
                    v262 = 64l * v261;
                    long v263;
                    v263 = v262 + v77;
                    float * v266;
                    float * v264;
                    v264 = v0+v263;
                    v266 = v264;
                    assert("Tensor range check" && 0 <= v71 && v71 < 4l);
                    long v267;
                    v267 = 65536l * v71;
                    assert("Tensor range check" && 0 <= v261 && v261 < 8l);
                    long v268;
                    v268 = v262 + v267;
                    float * v271;
                    float * v269;
                    v269 = v1+v268;
                    v271 = v269;
                    long v272;
                    v272 = threadIdx.x;
                    bool v273;
                    v273 = 0l <= v272;
                    bool v274;
                    v274 = v273 == false;
                    if (v274){
                        assert("The index needs to be zero or positive." && v273);
                    } else {
                    }
                    long v276;
                    v276 = v272 % 8l;
                    long v277;
                    v277 = v272 / 8l;
                    long v278;
                    v278 = v277 % 64l;
                    long v279;
                    v279 = v277 / 64l;
                    bool v280;
                    v280 = v279 < 1l;
                    bool v281;
                    v281 = v280 == false;
                    if (v281){
                        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v280);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v279 && v279 < 1l);
                    assert("Tensor range check" && 0 <= v278 && v278 < 64l);
                    assert("Tensor range check" && 0 <= v276 && v276 < 8l);
                    long v283;
                    v283 = 4l * v276;
                    long v284;
                    v284 = 68l * v278;
                    long v285;
                    v285 = v284 + v283;
                    long v286;
                    v286 = 32l * v279;
                    long v287;
                    v287 = v286 + v285;
                    long v288;
                    v288 = 512l * v278;
                    long v289;
                    v289 = v288 + v283;
                    long v290;
                    v290 = v286 + v289;
                    float * v293;
                    float * v291;
                    v291 = v10+v287;
                    v293 = v291;
                    float * v296;
                    float * v294;
                    v294 = v271+v290;
                    v296 = v294;
                    v3.producer_acquire();
                    constexpr long v297 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v296 + 0l) % v297 == 0 && (unsigned long long)(v293 + 0l) % v297 == 0);
                    cuda::memcpy_async(v293 + 0l, v296 + 0l, cuda::aligned_size_t<v297>(v297), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v298 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v296 + 32768l) % v298 == 0 && (unsigned long long)(v293 + 4352l) % v298 == 0);
                    cuda::memcpy_async(v293 + 4352l, v296 + 32768l, cuda::aligned_size_t<v298>(v298), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v299 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v296 + 32l) % v299 == 0 && (unsigned long long)(v293 + 32l) % v299 == 0);
                    cuda::memcpy_async(v293 + 32l, v296 + 32l, cuda::aligned_size_t<v299>(v299), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v300 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v296 + 32800l) % v300 == 0 && (unsigned long long)(v293 + 4384l) % v300 == 0);
                    cuda::memcpy_async(v293 + 4384l, v296 + 32800l, cuda::aligned_size_t<v300>(v300), v3);
                    v3.producer_commit();
                    long v301;
                    v301 = threadIdx.x;
                    bool v302;
                    v302 = 0l <= v301;
                    bool v303;
                    v303 = v302 == false;
                    if (v303){
                        assert("The index needs to be zero or positive." && v302);
                    } else {
                    }
                    long v305;
                    v305 = v301 % 8l;
                    long v306;
                    v306 = v301 / 8l;
                    long v307;
                    v307 = v306 % 64l;
                    long v308;
                    v308 = v306 / 64l;
                    bool v309;
                    v309 = v308 < 1l;
                    bool v310;
                    v310 = v309 == false;
                    if (v310){
                        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v309);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v308 && v308 < 1l);
                    assert("Tensor range check" && 0 <= v307 && v307 < 64l);
                    assert("Tensor range check" && 0 <= v305 && v305 < 8l);
                    long v312;
                    v312 = 4l * v305;
                    long v313;
                    v313 = 68l * v307;
                    long v314;
                    v314 = v313 + v312;
                    long v315;
                    v315 = 32l * v308;
                    long v316;
                    v316 = v315 + v314;
                    long v317;
                    v317 = 512l * v307;
                    long v318;
                    v318 = v317 + v312;
                    long v319;
                    v319 = v315 + v318;
                    float * v322;
                    float * v320;
                    v320 = v7+v316;
                    v322 = v320;
                    float * v325;
                    float * v323;
                    v323 = v266+v319;
                    v325 = v323;
                    v3.producer_acquire();
                    constexpr long v326 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v325 + 0l) % v326 == 0 && (unsigned long long)(v322 + 0l) % v326 == 0);
                    cuda::memcpy_async(v322 + 0l, v325 + 0l, cuda::aligned_size_t<v326>(v326), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v327 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v325 + 32l) % v327 == 0 && (unsigned long long)(v322 + 32l) % v327 == 0);
                    cuda::memcpy_async(v322 + 32l, v325 + 32l, cuda::aligned_size_t<v327>(v327), v3);
                    v3.producer_commit();
                    // Poping the loop unrolling to: 0
                }
            }
            long v328;
            v328 = 0l;
            #pragma unroll
            while (while_method_3(v328)){
                long v330;
                v330 = 0l;
                #pragma unroll
                while (while_method_2(v330)){
                    long v332;
                    v332 = 0l;
                    #pragma unroll
                    while (while_method_5(v332)){
                        assert("Tensor range check" && 0 <= v328 && v328 < 2l);
                        assert("Tensor range check" && 0 <= v330 && v330 < 1l);
                        long v334;
                        v334 = v328 + v330;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v335 = v64[v334];
                        assert("Tensor range check" && 0 <= v328 && v328 < 2l);
                        assert("Tensor range check" && 0 <= v332 && v332 < 8l);
                        long v336;
                        v336 = 8l * v328;
                        long v337;
                        v337 = v336 + v332;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v338 = v197[v337];
                        assert("Tensor range check" && 0 <= v330 && v330 < 1l);
                        assert("Tensor range check" && 0 <= v332 && v332 < 8l);
                        long v339;
                        v339 = 8l * v330;
                        long v340;
                        v340 = v339 + v332;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v341 = v198[v340];
                        wmma::mma_sync(v335, v338, v341, v335);
                        v332 += 1l ;
                    }
                    v330 += 1l ;
                }
                v328 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v123 = v189;
        }
        // Pushing the loop unrolling to: 0
        long v342;
        v342 = 0l;
        #pragma unroll
        while (while_method_3(v342)){
            long v344;
            v344 = 0l;
            #pragma unroll
            while (while_method_2(v344)){
                assert("Tensor range check" && 0 <= v342 && v342 < 2l);
                assert("Tensor range check" && 0 <= v344 && v344 < 1l);
                long v346;
                v346 = v342 + v344;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v347 = v64[v346];
                assert("Tensor range check" && 0 <= v342 && v342 < 2l);
                assert("Tensor range check" && 0 <= v344 && v344 < 1l);
                long v348;
                v348 = 16l * v344;
                long v349;
                v349 = 2176l * v342;
                long v350;
                v350 = v349 + v348;
                float * v351;
                v351 = v29 + v350;
                wmma::store_matrix_sync(v351, v347, 136l, wmma::mem_row_major);
                v344 += 1l ;
            }
            v342 += 1l ;
        }
        __syncthreads();
        long v352;
        v352 = threadIdx.x;
        bool v353;
        v353 = 0l <= v352;
        bool v354;
        v354 = v353 == false;
        if (v354){
            assert("The index needs to be zero or positive." && v353);
        } else {
        }
        long v356;
        v356 = v352 % 32l;
        long v357;
        v357 = v352 / 32l;
        bool v358;
        v358 = v357 < 16l;
        bool v359;
        v359 = v358 == false;
        if (v359){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v358);
        } else {
        }
        assert("Tensor range check" && 0 <= v357 && v357 < 16l);
        assert("Tensor range check" && 0 <= v356 && v356 < 32l);
        long v361;
        v361 = 4l * v356;
        long v362;
        v362 = 512l * v357;
        long v363;
        v363 = v362 + v361;
        long v364;
        v364 = 136l * v357;
        long v365;
        v365 = v364 + v361;
        float * v368;
        float * v366;
        v366 = v81+v363;
        v368 = v366;
        float * v371;
        float * v369;
        v369 = v13+v365;
        v371 = v369;
        long v372;
        v372 = 0l;
        #pragma unroll
        while (while_method_1(v372)){
            long v374;
            v374 = 0l;
            #pragma unroll
            while (while_method_2(v374)){
                assert("Tensor range check" && 0 <= v372 && v372 < 4l);
                assert("Tensor range check" && 0 <= v374 && v374 < 1l);
                long v376;
                v376 = 128l * v374;
                long v377;
                v377 = 8192l * v372;
                long v378;
                v378 = v377 + v376;
                long v379;
                v379 = 2176l * v372;
                long v380;
                v380 = v379 + v376;
                int4* v381;
                v381 = reinterpret_cast<int4*>(v371 + v380);
                int4* v382;
                v382 = reinterpret_cast<int4*>(v368 + v378);
                assert("Pointer alignment check" && (unsigned long long)(v381) % 4l == 0 && (unsigned long long)(v382) % 4l == 0);
                *v382 = *v381;
                v374 += 1l ;
            }
            v372 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v66 += 24l ;
    }
    // Poping the loop unrolling to: 1
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
            max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),512,is_print=True)
        else:
            pass
        del v27
        v28 = 0
        v29 = raw_module.get_function(f"entry{v28}")
        del v28
        v29.max_dynamic_shared_size_bytes = 52224 
        v29((24,),(512,),(v10, v5, v0),shared_mem=52224)
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
