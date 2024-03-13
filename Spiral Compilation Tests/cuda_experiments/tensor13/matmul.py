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
    v1 = v0 < 16384l;
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
    v1 = v0 < 64l;
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
    v19 = v15 % 4l;
    long v20;
    v20 = v15 / 4l;
    bool v21;
    v21 = v20 < 2l;
    bool v22;
    v22 = v21 == false;
    if (v22){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v21);
    } else {
    }
    assert("Tensor range check" && 0 <= v20 && v20 < 2l);
    assert("Tensor range check" && 0 <= v19 && v19 < 4l);
    long v24;
    v24 = 16l * v19;
    long v25;
    v25 = 2304l * v20;
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
    assert("Tensor range check" && 0 <= v19 && v19 < 4l);
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
        v71 = v66 % 128l;
        long v72;
        v72 = v66 / 128l;
        bool v73;
        v73 = v72 < 128l;
        bool v74;
        v74 = v73 == false;
        if (v74){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v73);
        } else {
        }
        assert("Tensor range check" && 0 <= v72 && v72 < 128l);
        assert("Tensor range check" && 0 <= v71 && v71 < 128l);
        long v76;
        v76 = 64l * v71;
        long v77;
        v77 = 524288l * v72;
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
        v86 = v82 % 16l;
        long v87;
        v87 = v82 / 16l;
        bool v88;
        v88 = v87 < 16l;
        bool v89;
        v89 = v88 == false;
        if (v89){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v88);
        } else {
        }
        assert("Tensor range check" && 0 <= v87 && v87 < 16l);
        assert("Tensor range check" && 0 <= v86 && v86 < 16l);
        long v91;
        v91 = 4l * v86;
        long v92;
        v92 = 72l * v87;
        long v93;
        v93 = v92 + v91;
        long v94;
        v94 = 8192l * v87;
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
                v106 = 64l * v104;
                long v107;
                v107 = 1152l * v102;
                long v108;
                v108 = v107 + v106;
                long v109;
                v109 = 131072l * v102;
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
                v120 = 1152l * v113;
                long v121;
                v121 = v120 + v119;
                float * v122;
                v122 = v29 + v121;
                wmma::load_matrix_sync(v118, v122, 72l, wmma::mem_row_major);
                v115 += 1l ;
            }
            v113 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        // Pushing the loop unrolling to: 0
        assert("Tensor range check" && 0 <= v72 && v72 < 128l);
        long v123;
        v123 = 262144l * v72;
        float * v126;
        float * v124;
        v124 = v0+v123;
        v126 = v124;
        assert("Tensor range check" && 0 <= v71 && v71 < 128l);
        long v127;
        v127 = 262144l * v71;
        float * v130;
        float * v128;
        v128 = v1+v127;
        v130 = v128;
        long v131;
        v131 = threadIdx.x;
        bool v132;
        v132 = 0l <= v131;
        bool v133;
        v133 = v132 == false;
        if (v133){
            assert("The index needs to be zero or positive." && v132);
        } else {
        }
        long v135;
        v135 = v131 % 16l;
        long v136;
        v136 = v131 / 16l;
        bool v137;
        v137 = v136 < 16l;
        bool v138;
        v138 = v137 == false;
        if (v138){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v137);
        } else {
        }
        assert("Tensor range check" && 0 <= v136 && v136 < 16l);
        assert("Tensor range check" && 0 <= v135 && v135 < 16l);
        long v140;
        v140 = 4l * v135;
        long v141;
        v141 = 68l * v136;
        long v142;
        v142 = v141 + v140;
        long v143;
        v143 = 4096l * v136;
        long v144;
        v144 = v143 + v140;
        float * v147;
        float * v145;
        v145 = v10+v142;
        v147 = v145;
        float * v150;
        float * v148;
        v148 = v130+v144;
        v150 = v148;
        v3.producer_acquire();
        constexpr long v151 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v150 + 0l) % v151 == 0 && (unsigned long long)(v147 + 0l) % v151 == 0);
        cuda::memcpy_async(v147 + 0l, v150 + 0l, cuda::aligned_size_t<v151>(v151), v3);
        v3.producer_commit();
        v3.producer_acquire();
        constexpr long v152 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v150 + 65536l) % v152 == 0 && (unsigned long long)(v147 + 1088l) % v152 == 0);
        cuda::memcpy_async(v147 + 1088l, v150 + 65536l, cuda::aligned_size_t<v152>(v152), v3);
        v3.producer_commit();
        v3.producer_acquire();
        constexpr long v153 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v150 + 131072l) % v153 == 0 && (unsigned long long)(v147 + 2176l) % v153 == 0);
        cuda::memcpy_async(v147 + 2176l, v150 + 131072l, cuda::aligned_size_t<v153>(v153), v3);
        v3.producer_commit();
        v3.producer_acquire();
        constexpr long v154 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v150 + 196608l) % v154 == 0 && (unsigned long long)(v147 + 3264l) % v154 == 0);
        cuda::memcpy_async(v147 + 3264l, v150 + 196608l, cuda::aligned_size_t<v154>(v154), v3);
        v3.producer_commit();
        long v155;
        v155 = threadIdx.x;
        bool v156;
        v156 = 0l <= v155;
        bool v157;
        v157 = v156 == false;
        if (v157){
            assert("The index needs to be zero or positive." && v156);
        } else {
        }
        long v159;
        v159 = v155 % 16l;
        long v160;
        v160 = v155 / 16l;
        bool v161;
        v161 = v160 < 16l;
        bool v162;
        v162 = v161 == false;
        if (v162){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v161);
        } else {
        }
        assert("Tensor range check" && 0 <= v160 && v160 < 16l);
        assert("Tensor range check" && 0 <= v159 && v159 < 16l);
        long v164;
        v164 = 4l * v159;
        long v165;
        v165 = 68l * v160;
        long v166;
        v166 = v165 + v164;
        long v167;
        v167 = 4096l * v160;
        long v168;
        v168 = v167 + v164;
        float * v171;
        float * v169;
        v169 = v7+v166;
        v171 = v169;
        float * v174;
        float * v172;
        v172 = v126+v168;
        v174 = v172;
        v3.producer_acquire();
        constexpr long v175 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v174 + 0l) % v175 == 0 && (unsigned long long)(v171 + 0l) % v175 == 0);
        cuda::memcpy_async(v171 + 0l, v174 + 0l, cuda::aligned_size_t<v175>(v175), v3);
        v3.producer_commit();
        v3.producer_acquire();
        constexpr long v176 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v174 + 65536l) % v176 == 0 && (unsigned long long)(v171 + 1088l) % v176 == 0);
        cuda::memcpy_async(v171 + 1088l, v174 + 65536l, cuda::aligned_size_t<v176>(v176), v3);
        v3.producer_commit();
        v3.producer_acquire();
        constexpr long v177 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v174 + 131072l) % v177 == 0 && (unsigned long long)(v171 + 2176l) % v177 == 0);
        cuda::memcpy_async(v171 + 2176l, v174 + 131072l, cuda::aligned_size_t<v177>(v177), v3);
        v3.producer_commit();
        v3.producer_acquire();
        constexpr long v178 = sizeof(float) * 4l;
        assert("Pointer alignment check" && (unsigned long long)(v174 + 196608l) % v178 == 0 && (unsigned long long)(v171 + 3264l) % v178 == 0);
        cuda::memcpy_async(v171 + 3264l, v174 + 196608l, cuda::aligned_size_t<v178>(v178), v3);
        v3.producer_commit();
        // Poping the loop unrolling to: 0
        long v179;
        v179 = 0l;
        #pragma unroll 1
        while (while_method_4(v179)){
            long v181;
            v181 = v179 + 1l;
            bool v182;
            v182 = v181 < 64l;
            US0 v188;
            if (v182){
                bool v183;
                v183 = 0l <= v181;
                bool v184;
                v184 = v183 == false;
                if (v184){
                    assert("The index needs to be zero or positive." && v183);
                } else {
                }
                v188 = US0_1(v181);
            } else {
                v188 = US0_0();
            }
            // Pushing the loop unrolling to: 0
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v189[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v190[8l];
            cuda::pipeline_consumer_wait_prior<0>(v3);;
            __syncthreads();
            long v191;
            v191 = 0l;
            #pragma unroll
            while (while_method_3(v191)){
                long v193;
                v193 = 0l;
                #pragma unroll
                while (while_method_5(v193)){
                    assert("Tensor range check" && 0 <= v191 && v191 < 2l);
                    assert("Tensor range check" && 0 <= v193 && v193 < 8l);
                    long v195;
                    v195 = 8l * v191;
                    long v196;
                    v196 = v195 + v193;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v197 = v189[v196];
                    assert("Tensor range check" && 0 <= v191 && v191 < 2l);
                    long v198;
                    v198 = 1088l * v191;
                    assert("Tensor range check" && 0 <= v193 && v193 < 8l);
                    long v199;
                    v199 = 8l * v193;
                    long v200;
                    v200 = v199 + v198;
                    long v201;
                    v201 = 0l;
                    #pragma unroll
                    while (while_method_3(v201)){
                        long v203;
                        v203 = 0l;
                        #pragma unroll
                        while (while_method_3(v203)){
                            assert("Tensor range check" && 0 <= v201 && v201 < 2l);
                            assert("Tensor range check" && 0 <= v203 && v203 < 2l);
                            long v205;
                            v205 = 544l * v203;
                            long v206;
                            v206 = v205 + v200;
                            long v207;
                            v207 = 4l * v201;
                            long v208;
                            v208 = v207 + v206;
                            float v209;
                            v209 = v46[v208];
                            bool v210;
                            v210 = 0l <= v203;
                            bool v212;
                            if (v210){
                                bool v211;
                                v211 = v203 < 2l;
                                v212 = v211;
                            } else {
                                v212 = false;
                            }
                            bool v213;
                            v213 = v212 == false;
                            if (v213){
                                assert("The indices should be inside the range of the dimension." && v212);
                            } else {
                            }
                            bool v215;
                            v215 = 0l <= v201;
                            bool v217;
                            if (v215){
                                bool v216;
                                v216 = v201 < 2l;
                                v217 = v216;
                            } else {
                                v217 = false;
                            }
                            bool v218;
                            v218 = v217 == false;
                            if (v218){
                                assert("The indices should be inside the range of the dimension." && v217);
                            } else {
                            }
                            long v220;
                            v220 = v201 * 2l;
                            long v221;
                            v221 = v203 + v220;
                            v197.x[v221] = wmma::__float_to_tf32(v209);
                            v203 += 1l ;
                        }
                        v201 += 1l ;
                    }
                    v193 += 1l ;
                }
                v191 += 1l ;
            }
            long v222;
            v222 = 0l;
            #pragma unroll
            while (while_method_2(v222)){
                long v224;
                v224 = 0l;
                #pragma unroll
                while (while_method_5(v224)){
                    assert("Tensor range check" && 0 <= v222 && v222 < 1l);
                    assert("Tensor range check" && 0 <= v224 && v224 < 8l);
                    long v226;
                    v226 = 8l * v222;
                    long v227;
                    v227 = v226 + v224;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v228 = v190[v227];
                    assert("Tensor range check" && 0 <= v222 && v222 < 1l);
                    long v229;
                    v229 = 1088l * v222;
                    assert("Tensor range check" && 0 <= v224 && v224 < 8l);
                    long v230;
                    v230 = 8l * v224;
                    long v231;
                    v231 = v230 + v229;
                    long v232;
                    v232 = 0l;
                    #pragma unroll
                    while (while_method_3(v232)){
                        long v234;
                        v234 = 0l;
                        #pragma unroll
                        while (while_method_3(v234)){
                            assert("Tensor range check" && 0 <= v232 && v232 < 2l);
                            assert("Tensor range check" && 0 <= v234 && v234 < 2l);
                            long v236;
                            v236 = 4l * v234;
                            long v237;
                            v237 = v236 + v231;
                            long v238;
                            v238 = 544l * v232;
                            long v239;
                            v239 = v238 + v237;
                            float v240;
                            v240 = v63[v239];
                            bool v241;
                            v241 = 0l <= v234;
                            bool v243;
                            if (v241){
                                bool v242;
                                v242 = v234 < 2l;
                                v243 = v242;
                            } else {
                                v243 = false;
                            }
                            bool v244;
                            v244 = v243 == false;
                            if (v244){
                                assert("The indices should be inside the range of the dimension." && v243);
                            } else {
                            }
                            bool v246;
                            v246 = 0l <= v232;
                            bool v248;
                            if (v246){
                                bool v247;
                                v247 = v232 < 2l;
                                v248 = v247;
                            } else {
                                v248 = false;
                            }
                            bool v249;
                            v249 = v248 == false;
                            if (v249){
                                assert("The indices should be inside the range of the dimension." && v248);
                            } else {
                            }
                            long v251;
                            v251 = v232 * 2l;
                            long v252;
                            v252 = v234 + v251;
                            v228.x[v252] = wmma::__float_to_tf32(v240);
                            v234 += 1l ;
                        }
                        v232 += 1l ;
                    }
                    v224 += 1l ;
                }
                v222 += 1l ;
            }
            v3.consumer_release();
            __syncthreads();
            switch (v188.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    long v253 = v188.v.case1.v0;
                    // Pushing the loop unrolling to: 0
                    assert("Tensor range check" && 0 <= v72 && v72 < 128l);
                    assert("Tensor range check" && 0 <= v253 && v253 < 64l);
                    long v254;
                    v254 = 64l * v253;
                    long v255;
                    v255 = v254 + v123;
                    float * v258;
                    float * v256;
                    v256 = v0+v255;
                    v258 = v256;
                    assert("Tensor range check" && 0 <= v71 && v71 < 128l);
                    assert("Tensor range check" && 0 <= v253 && v253 < 64l);
                    long v259;
                    v259 = v254 + v127;
                    float * v262;
                    float * v260;
                    v260 = v1+v259;
                    v262 = v260;
                    long v263;
                    v263 = threadIdx.x;
                    bool v264;
                    v264 = 0l <= v263;
                    bool v265;
                    v265 = v264 == false;
                    if (v265){
                        assert("The index needs to be zero or positive." && v264);
                    } else {
                    }
                    long v267;
                    v267 = v263 % 16l;
                    long v268;
                    v268 = v263 / 16l;
                    bool v269;
                    v269 = v268 < 16l;
                    bool v270;
                    v270 = v269 == false;
                    if (v270){
                        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v269);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v268 && v268 < 16l);
                    assert("Tensor range check" && 0 <= v267 && v267 < 16l);
                    long v272;
                    v272 = 4l * v267;
                    long v273;
                    v273 = 68l * v268;
                    long v274;
                    v274 = v273 + v272;
                    long v275;
                    v275 = 4096l * v268;
                    long v276;
                    v276 = v275 + v272;
                    float * v279;
                    float * v277;
                    v277 = v10+v274;
                    v279 = v277;
                    float * v282;
                    float * v280;
                    v280 = v262+v276;
                    v282 = v280;
                    v3.producer_acquire();
                    constexpr long v283 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v282 + 0l) % v283 == 0 && (unsigned long long)(v279 + 0l) % v283 == 0);
                    cuda::memcpy_async(v279 + 0l, v282 + 0l, cuda::aligned_size_t<v283>(v283), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v284 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v282 + 65536l) % v284 == 0 && (unsigned long long)(v279 + 1088l) % v284 == 0);
                    cuda::memcpy_async(v279 + 1088l, v282 + 65536l, cuda::aligned_size_t<v284>(v284), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v285 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v282 + 131072l) % v285 == 0 && (unsigned long long)(v279 + 2176l) % v285 == 0);
                    cuda::memcpy_async(v279 + 2176l, v282 + 131072l, cuda::aligned_size_t<v285>(v285), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v286 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v282 + 196608l) % v286 == 0 && (unsigned long long)(v279 + 3264l) % v286 == 0);
                    cuda::memcpy_async(v279 + 3264l, v282 + 196608l, cuda::aligned_size_t<v286>(v286), v3);
                    v3.producer_commit();
                    long v287;
                    v287 = threadIdx.x;
                    bool v288;
                    v288 = 0l <= v287;
                    bool v289;
                    v289 = v288 == false;
                    if (v289){
                        assert("The index needs to be zero or positive." && v288);
                    } else {
                    }
                    long v291;
                    v291 = v287 % 16l;
                    long v292;
                    v292 = v287 / 16l;
                    bool v293;
                    v293 = v292 < 16l;
                    bool v294;
                    v294 = v293 == false;
                    if (v294){
                        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v293);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v292 && v292 < 16l);
                    assert("Tensor range check" && 0 <= v291 && v291 < 16l);
                    long v296;
                    v296 = 4l * v291;
                    long v297;
                    v297 = 68l * v292;
                    long v298;
                    v298 = v297 + v296;
                    long v299;
                    v299 = 4096l * v292;
                    long v300;
                    v300 = v299 + v296;
                    float * v303;
                    float * v301;
                    v301 = v7+v298;
                    v303 = v301;
                    float * v306;
                    float * v304;
                    v304 = v258+v300;
                    v306 = v304;
                    v3.producer_acquire();
                    constexpr long v307 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v306 + 0l) % v307 == 0 && (unsigned long long)(v303 + 0l) % v307 == 0);
                    cuda::memcpy_async(v303 + 0l, v306 + 0l, cuda::aligned_size_t<v307>(v307), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v308 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v306 + 65536l) % v308 == 0 && (unsigned long long)(v303 + 1088l) % v308 == 0);
                    cuda::memcpy_async(v303 + 1088l, v306 + 65536l, cuda::aligned_size_t<v308>(v308), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v309 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v306 + 131072l) % v309 == 0 && (unsigned long long)(v303 + 2176l) % v309 == 0);
                    cuda::memcpy_async(v303 + 2176l, v306 + 131072l, cuda::aligned_size_t<v309>(v309), v3);
                    v3.producer_commit();
                    v3.producer_acquire();
                    constexpr long v310 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v306 + 196608l) % v310 == 0 && (unsigned long long)(v303 + 3264l) % v310 == 0);
                    cuda::memcpy_async(v303 + 3264l, v306 + 196608l, cuda::aligned_size_t<v310>(v310), v3);
                    v3.producer_commit();
                    // Poping the loop unrolling to: 0
                }
            }
            long v311;
            v311 = 0l;
            #pragma unroll
            while (while_method_3(v311)){
                long v313;
                v313 = 0l;
                #pragma unroll
                while (while_method_2(v313)){
                    long v315;
                    v315 = 0l;
                    #pragma unroll
                    while (while_method_5(v315)){
                        assert("Tensor range check" && 0 <= v311 && v311 < 2l);
                        assert("Tensor range check" && 0 <= v313 && v313 < 1l);
                        long v317;
                        v317 = v311 + v313;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v318 = v64[v317];
                        assert("Tensor range check" && 0 <= v311 && v311 < 2l);
                        assert("Tensor range check" && 0 <= v315 && v315 < 8l);
                        long v319;
                        v319 = 8l * v311;
                        long v320;
                        v320 = v319 + v315;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v321 = v189[v320];
                        assert("Tensor range check" && 0 <= v313 && v313 < 1l);
                        assert("Tensor range check" && 0 <= v315 && v315 < 8l);
                        long v322;
                        v322 = 8l * v313;
                        long v323;
                        v323 = v322 + v315;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v324 = v190[v323];
                        wmma::mma_sync(v318, v321, v324, v318);
                        v315 += 1l ;
                    }
                    v313 += 1l ;
                }
                v311 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v179 = v181;
        }
        // Pushing the loop unrolling to: 0
        long v325;
        v325 = 0l;
        #pragma unroll
        while (while_method_3(v325)){
            long v327;
            v327 = 0l;
            #pragma unroll
            while (while_method_2(v327)){
                assert("Tensor range check" && 0 <= v325 && v325 < 2l);
                assert("Tensor range check" && 0 <= v327 && v327 < 1l);
                long v329;
                v329 = v325 + v327;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v330 = v64[v329];
                assert("Tensor range check" && 0 <= v325 && v325 < 2l);
                assert("Tensor range check" && 0 <= v327 && v327 < 1l);
                long v331;
                v331 = 16l * v327;
                long v332;
                v332 = 1152l * v325;
                long v333;
                v333 = v332 + v331;
                float * v334;
                v334 = v29 + v333;
                wmma::store_matrix_sync(v334, v330, 72l, wmma::mem_row_major);
                v327 += 1l ;
            }
            v325 += 1l ;
        }
        __syncthreads();
        long v335;
        v335 = threadIdx.x;
        bool v336;
        v336 = 0l <= v335;
        bool v337;
        v337 = v336 == false;
        if (v337){
            assert("The index needs to be zero or positive." && v336);
        } else {
        }
        long v339;
        v339 = v335 % 16l;
        long v340;
        v340 = v335 / 16l;
        bool v341;
        v341 = v340 < 16l;
        bool v342;
        v342 = v341 == false;
        if (v342){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v341);
        } else {
        }
        assert("Tensor range check" && 0 <= v340 && v340 < 16l);
        assert("Tensor range check" && 0 <= v339 && v339 < 16l);
        long v344;
        v344 = 4l * v339;
        long v345;
        v345 = 8192l * v340;
        long v346;
        v346 = v345 + v344;
        long v347;
        v347 = 72l * v340;
        long v348;
        v348 = v347 + v344;
        float * v351;
        float * v349;
        v349 = v81+v346;
        v351 = v349;
        float * v354;
        float * v352;
        v352 = v13+v348;
        v354 = v352;
        long v355;
        v355 = 0l;
        #pragma unroll
        while (while_method_1(v355)){
            long v357;
            v357 = 0l;
            #pragma unroll
            while (while_method_2(v357)){
                assert("Tensor range check" && 0 <= v355 && v355 < 4l);
                assert("Tensor range check" && 0 <= v357 && v357 < 1l);
                long v359;
                v359 = 64l * v357;
                long v360;
                v360 = 131072l * v355;
                long v361;
                v361 = v360 + v359;
                long v362;
                v362 = 1152l * v355;
                long v363;
                v363 = v362 + v359;
                int4* v364;
                v364 = reinterpret_cast<int4*>(v354 + v363);
                int4* v365;
                v365 = reinterpret_cast<int4*>(v351 + v361);
                assert("Pointer alignment check" && (unsigned long long)(v364) % 4l == 0 && (unsigned long long)(v365) % 4l == 0);
                *v365 = *v364;
                v357 += 1l ;
            }
            v355 += 1l ;
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
options.append('--maxrregcount=255')
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
            max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),256,is_print=True)
        else:
            pass
        del v27
        v28 = 0
        v29 = raw_module.get_function(f"entry{v28}")
        del v28
        v29.max_dynamic_shared_size_bytes = 34816 
        v29((24,),(256,),(v10, v5, v0),shared_mem=34816)
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
