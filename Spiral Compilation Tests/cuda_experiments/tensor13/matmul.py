kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <assert.h>
#include <mma.h>
using namespace nvcuda;
#include <cuda/pipeline>
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
__device__ inline bool while_method_5(long v0){
    bool v1;
    v1 = v0 < 2l;
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
    v8 = reinterpret_cast<float *>(&v4[34816ull]);
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
    v25 = 8704l * v20;
    long v26;
    v26 = v25 + v24;
    float * v29;
    float * v27;
    v27 = v13+v26;
    v29 = v27;
    assert("Tensor range check" && 0 <= v20 && v20 < 2l);
    long v30;
    v30 = 4352l * v20;
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
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v64[4l];
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
        v71 = v66 % 64l;
        long v72;
        v72 = v66 / 64l;
        bool v73;
        v73 = v72 < 64l;
        bool v74;
        v74 = v73 == false;
        if (v74){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v73);
        } else {
        }
        assert("Tensor range check" && 0 <= v72 && v72 < 64l);
        assert("Tensor range check" && 0 <= v71 && v71 < 64l);
        long v76;
        v76 = 128l * v71;
        long v77;
        v77 = 1048576l * v72;
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
                assert("Tensor range check" && 0 <= v102 && v102 < 8l);
                assert("Tensor range check" && 0 <= v104 && v104 < 1l);
                long v106;
                v106 = 128l * v104;
                long v107;
                v107 = 2176l * v102;
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
                assert("Tensor range check" && 0 <= v113 && v113 < 4l);
                assert("Tensor range check" && 0 <= v115 && v115 < 1l);
                long v117;
                v117 = v113 + v115;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v118 = v64[v117];
                assert("Tensor range check" && 0 <= v113 && v113 < 4l);
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
        // Pushing the loop unrolling to: 2
        long v123;
        v123 = 0l;
        #pragma unroll 2
        while (while_method_4(v123)){
            // Pushing the loop unrolling to: 0
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v72 && v72 < 64l);
            long v125;
            v125 = 524288l * v72;
            assert("Tensor range check" && 0 <= v123 && v123 < 64l);
            long v126;
            v126 = 64l * v123;
            long v127;
            v127 = v126 + v125;
            float * v130;
            float * v128;
            v128 = v0+v127;
            v130 = v128;
            assert("Tensor range check" && 0 <= v71 && v71 < 64l);
            long v131;
            v131 = 524288l * v71;
            assert("Tensor range check" && 0 <= v123 && v123 < 64l);
            long v132;
            v132 = v126 + v131;
            float * v135;
            float * v133;
            v133 = v1+v132;
            v135 = v133;
            long v136;
            v136 = threadIdx.x;
            bool v137;
            v137 = 0l <= v136;
            bool v138;
            v138 = v137 == false;
            if (v138){
                assert("The index needs to be zero or positive." && v137);
            } else {
            }
            long v140;
            v140 = v136 % 8l;
            long v141;
            v141 = v136 / 8l;
            long v142;
            v142 = v141 % 64l;
            long v143;
            v143 = v141 / 64l;
            bool v144;
            v144 = v143 < 1l;
            bool v145;
            v145 = v144 == false;
            if (v145){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v144);
            } else {
            }
            assert("Tensor range check" && 0 <= v143 && v143 < 1l);
            assert("Tensor range check" && 0 <= v142 && v142 < 64l);
            assert("Tensor range check" && 0 <= v140 && v140 < 8l);
            long v147;
            v147 = 4l * v140;
            long v148;
            v148 = 68l * v142;
            long v149;
            v149 = v148 + v147;
            long v150;
            v150 = 32l * v143;
            long v151;
            v151 = v150 + v149;
            long v152;
            v152 = 4096l * v142;
            long v153;
            v153 = v152 + v147;
            long v154;
            v154 = v150 + v153;
            float * v157;
            float * v155;
            v155 = v10+v151;
            v157 = v155;
            float * v160;
            float * v158;
            v158 = v135+v154;
            v160 = v158;
            v3.producer_acquire();
            constexpr long v161 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v160 + 0l) % v161 == 0 && (unsigned long long)(v157 + 0l) % v161 == 0);
            cuda::memcpy_async(v157 + 0l, v160 + 0l, cuda::aligned_size_t<v161>(v161), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v162 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v160 + 262144l) % v162 == 0 && (unsigned long long)(v157 + 4352l) % v162 == 0);
            cuda::memcpy_async(v157 + 4352l, v160 + 262144l, cuda::aligned_size_t<v162>(v162), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v163 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v160 + 32l) % v163 == 0 && (unsigned long long)(v157 + 32l) % v163 == 0);
            cuda::memcpy_async(v157 + 32l, v160 + 32l, cuda::aligned_size_t<v163>(v163), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v164 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v160 + 262176l) % v164 == 0 && (unsigned long long)(v157 + 4384l) % v164 == 0);
            cuda::memcpy_async(v157 + 4384l, v160 + 262176l, cuda::aligned_size_t<v164>(v164), v3);
            v3.producer_commit();
            long v165;
            v165 = threadIdx.x;
            bool v166;
            v166 = 0l <= v165;
            bool v167;
            v167 = v166 == false;
            if (v167){
                assert("The index needs to be zero or positive." && v166);
            } else {
            }
            long v169;
            v169 = v165 % 8l;
            long v170;
            v170 = v165 / 8l;
            long v171;
            v171 = v170 % 64l;
            long v172;
            v172 = v170 / 64l;
            bool v173;
            v173 = v172 < 1l;
            bool v174;
            v174 = v173 == false;
            if (v174){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v173);
            } else {
            }
            assert("Tensor range check" && 0 <= v172 && v172 < 1l);
            assert("Tensor range check" && 0 <= v171 && v171 < 64l);
            assert("Tensor range check" && 0 <= v169 && v169 < 8l);
            long v176;
            v176 = 4l * v169;
            long v177;
            v177 = 68l * v171;
            long v178;
            v178 = v177 + v176;
            long v179;
            v179 = 32l * v172;
            long v180;
            v180 = v179 + v178;
            long v181;
            v181 = 4096l * v171;
            long v182;
            v182 = v181 + v176;
            long v183;
            v183 = v179 + v182;
            float * v186;
            float * v184;
            v184 = v7+v180;
            v186 = v184;
            float * v189;
            float * v187;
            v187 = v130+v183;
            v189 = v187;
            v3.producer_acquire();
            constexpr long v190 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v189 + 0l) % v190 == 0 && (unsigned long long)(v186 + 0l) % v190 == 0);
            cuda::memcpy_async(v186 + 0l, v189 + 0l, cuda::aligned_size_t<v190>(v190), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v191 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v189 + 262144l) % v191 == 0 && (unsigned long long)(v186 + 4352l) % v191 == 0);
            cuda::memcpy_async(v186 + 4352l, v189 + 262144l, cuda::aligned_size_t<v191>(v191), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v192 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v189 + 32l) % v192 == 0 && (unsigned long long)(v186 + 32l) % v192 == 0);
            cuda::memcpy_async(v186 + 32l, v189 + 32l, cuda::aligned_size_t<v192>(v192), v3);
            v3.producer_commit();
            v3.producer_acquire();
            constexpr long v193 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v189 + 262176l) % v193 == 0 && (unsigned long long)(v186 + 4384l) % v193 == 0);
            cuda::memcpy_async(v186 + 4384l, v189 + 262176l, cuda::aligned_size_t<v193>(v193), v3);
            v3.producer_commit();
            // Poping the loop unrolling to: 0
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v194[32l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v195[8l];
            cuda::pipeline_consumer_wait_prior<0>(v3);;
            __syncthreads();
            long v196;
            v196 = 0l;
            #pragma unroll
            while (while_method_3(v196)){
                long v198;
                v198 = 0l;
                #pragma unroll
                while (while_method_1(v198)){
                    assert("Tensor range check" && 0 <= v196 && v196 < 4l);
                    assert("Tensor range check" && 0 <= v198 && v198 < 8l);
                    long v200;
                    v200 = 8l * v196;
                    long v201;
                    v201 = v200 + v198;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v202 = v194[v201];
                    assert("Tensor range check" && 0 <= v196 && v196 < 4l);
                    long v203;
                    v203 = 1088l * v196;
                    assert("Tensor range check" && 0 <= v198 && v198 < 8l);
                    long v204;
                    v204 = 8l * v198;
                    long v205;
                    v205 = v204 + v203;
                    long v206;
                    v206 = 0l;
                    #pragma unroll
                    while (while_method_5(v206)){
                        long v208;
                        v208 = 0l;
                        #pragma unroll
                        while (while_method_5(v208)){
                            assert("Tensor range check" && 0 <= v206 && v206 < 2l);
                            assert("Tensor range check" && 0 <= v208 && v208 < 2l);
                            long v210;
                            v210 = 544l * v208;
                            long v211;
                            v211 = v210 + v205;
                            long v212;
                            v212 = 4l * v206;
                            long v213;
                            v213 = v212 + v211;
                            float v214;
                            v214 = v46[v213];
                            bool v215;
                            v215 = 0l <= v208;
                            bool v217;
                            if (v215){
                                bool v216;
                                v216 = v208 < 2l;
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
                            bool v220;
                            v220 = 0l <= v206;
                            bool v222;
                            if (v220){
                                bool v221;
                                v221 = v206 < 2l;
                                v222 = v221;
                            } else {
                                v222 = false;
                            }
                            bool v223;
                            v223 = v222 == false;
                            if (v223){
                                assert("The indices should be inside the range of the dimension." && v222);
                            } else {
                            }
                            long v225;
                            v225 = v206 * 2l;
                            long v226;
                            v226 = v208 + v225;
                            v202.x[v226] = wmma::__float_to_tf32(v214);
                            v208 += 1l ;
                        }
                        v206 += 1l ;
                    }
                    v198 += 1l ;
                }
                v196 += 1l ;
            }
            long v227;
            v227 = 0l;
            #pragma unroll
            while (while_method_2(v227)){
                long v229;
                v229 = 0l;
                #pragma unroll
                while (while_method_1(v229)){
                    assert("Tensor range check" && 0 <= v227 && v227 < 1l);
                    assert("Tensor range check" && 0 <= v229 && v229 < 8l);
                    long v231;
                    v231 = 8l * v227;
                    long v232;
                    v232 = v231 + v229;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v233 = v195[v232];
                    assert("Tensor range check" && 0 <= v227 && v227 < 1l);
                    long v234;
                    v234 = 1088l * v227;
                    assert("Tensor range check" && 0 <= v229 && v229 < 8l);
                    long v235;
                    v235 = 8l * v229;
                    long v236;
                    v236 = v235 + v234;
                    long v237;
                    v237 = 0l;
                    #pragma unroll
                    while (while_method_5(v237)){
                        long v239;
                        v239 = 0l;
                        #pragma unroll
                        while (while_method_5(v239)){
                            assert("Tensor range check" && 0 <= v237 && v237 < 2l);
                            assert("Tensor range check" && 0 <= v239 && v239 < 2l);
                            long v241;
                            v241 = 4l * v239;
                            long v242;
                            v242 = v241 + v236;
                            long v243;
                            v243 = 544l * v237;
                            long v244;
                            v244 = v243 + v242;
                            float v245;
                            v245 = v63[v244];
                            bool v246;
                            v246 = 0l <= v239;
                            bool v248;
                            if (v246){
                                bool v247;
                                v247 = v239 < 2l;
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
                            bool v251;
                            v251 = 0l <= v237;
                            bool v253;
                            if (v251){
                                bool v252;
                                v252 = v237 < 2l;
                                v253 = v252;
                            } else {
                                v253 = false;
                            }
                            bool v254;
                            v254 = v253 == false;
                            if (v254){
                                assert("The indices should be inside the range of the dimension." && v253);
                            } else {
                            }
                            long v256;
                            v256 = v237 * 2l;
                            long v257;
                            v257 = v239 + v256;
                            v233.x[v257] = wmma::__float_to_tf32(v245);
                            v239 += 1l ;
                        }
                        v237 += 1l ;
                    }
                    v229 += 1l ;
                }
                v227 += 1l ;
            }
            v3.consumer_release();
            __syncthreads();
            long v258;
            v258 = 0l;
            #pragma unroll
            while (while_method_3(v258)){
                long v260;
                v260 = 0l;
                #pragma unroll
                while (while_method_2(v260)){
                    long v262;
                    v262 = 0l;
                    #pragma unroll
                    while (while_method_1(v262)){
                        assert("Tensor range check" && 0 <= v258 && v258 < 4l);
                        assert("Tensor range check" && 0 <= v260 && v260 < 1l);
                        long v264;
                        v264 = v258 + v260;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v265 = v64[v264];
                        assert("Tensor range check" && 0 <= v258 && v258 < 4l);
                        assert("Tensor range check" && 0 <= v262 && v262 < 8l);
                        long v266;
                        v266 = 8l * v258;
                        long v267;
                        v267 = v266 + v262;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v268 = v194[v267];
                        assert("Tensor range check" && 0 <= v260 && v260 < 1l);
                        assert("Tensor range check" && 0 <= v262 && v262 < 8l);
                        long v269;
                        v269 = 8l * v260;
                        long v270;
                        v270 = v269 + v262;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v271 = v195[v270];
                        wmma::mma_sync(v265, v268, v271, v265);
                        v262 += 1l ;
                    }
                    v260 += 1l ;
                }
                v258 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v123 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v272;
        v272 = 0l;
        #pragma unroll
        while (while_method_3(v272)){
            long v274;
            v274 = 0l;
            #pragma unroll
            while (while_method_2(v274)){
                assert("Tensor range check" && 0 <= v272 && v272 < 4l);
                assert("Tensor range check" && 0 <= v274 && v274 < 1l);
                long v276;
                v276 = v272 + v274;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v277 = v64[v276];
                assert("Tensor range check" && 0 <= v272 && v272 < 4l);
                assert("Tensor range check" && 0 <= v274 && v274 < 1l);
                long v278;
                v278 = 16l * v274;
                long v279;
                v279 = 2176l * v272;
                long v280;
                v280 = v279 + v278;
                float * v281;
                v281 = v29 + v280;
                wmma::store_matrix_sync(v281, v277, 136l, wmma::mem_row_major);
                v274 += 1l ;
            }
            v272 += 1l ;
        }
        __syncthreads();
        long v282;
        v282 = threadIdx.x;
        bool v283;
        v283 = 0l <= v282;
        bool v284;
        v284 = v283 == false;
        if (v284){
            assert("The index needs to be zero or positive." && v283);
        } else {
        }
        long v286;
        v286 = v282 % 32l;
        long v287;
        v287 = v282 / 32l;
        bool v288;
        v288 = v287 < 16l;
        bool v289;
        v289 = v288 == false;
        if (v289){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v288);
        } else {
        }
        assert("Tensor range check" && 0 <= v287 && v287 < 16l);
        assert("Tensor range check" && 0 <= v286 && v286 < 32l);
        long v291;
        v291 = 4l * v286;
        long v292;
        v292 = 8192l * v287;
        long v293;
        v293 = v292 + v291;
        long v294;
        v294 = 136l * v287;
        long v295;
        v295 = v294 + v291;
        float * v298;
        float * v296;
        v296 = v81+v293;
        v298 = v296;
        float * v301;
        float * v299;
        v299 = v13+v295;
        v301 = v299;
        long v302;
        v302 = 0l;
        #pragma unroll
        while (while_method_1(v302)){
            long v304;
            v304 = 0l;
            #pragma unroll
            while (while_method_2(v304)){
                assert("Tensor range check" && 0 <= v302 && v302 < 8l);
                assert("Tensor range check" && 0 <= v304 && v304 < 1l);
                long v306;
                v306 = 128l * v304;
                long v307;
                v307 = 131072l * v302;
                long v308;
                v308 = v307 + v306;
                long v309;
                v309 = 2176l * v302;
                long v310;
                v310 = v309 + v306;
                int4* v311;
                v311 = reinterpret_cast<int4*>(v301 + v310);
                int4* v312;
                v312 = reinterpret_cast<int4*>(v298 + v308);
                assert("Pointer alignment check" && (unsigned long long)(v311) % 4l == 0 && (unsigned long long)(v312) % 4l == 0);
                *v312 = *v311;
                v304 += 1l ;
            }
            v302 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        // Poping the loop unrolling to: 2
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
