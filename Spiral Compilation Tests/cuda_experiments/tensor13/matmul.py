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
            v3.producer_acquire();
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
            v140 = v136 % 16l;
            long v141;
            v141 = v136 / 16l;
            bool v142;
            v142 = v141 < 32l;
            bool v143;
            v143 = v142 == false;
            if (v143){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v142);
            } else {
            }
            assert("Tensor range check" && 0 <= v141 && v141 < 32l);
            assert("Tensor range check" && 0 <= v140 && v140 < 16l);
            long v145;
            v145 = 4l * v140;
            long v146;
            v146 = 68l * v141;
            long v147;
            v147 = v146 + v145;
            long v148;
            v148 = 4096l * v141;
            long v149;
            v149 = v148 + v145;
            float * v152;
            float * v150;
            v150 = v10+v147;
            v152 = v150;
            float * v155;
            float * v153;
            v153 = v135+v149;
            v155 = v153;
            constexpr long v156 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v155 + 0l) % v156 == 0 && (unsigned long long)(v152 + 0l) % v156 == 0);
            cuda::memcpy_async(v152 + 0l, v155 + 0l, cuda::aligned_size_t<v156>(v156), v3);
            constexpr long v157 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v155 + 131072l) % v157 == 0 && (unsigned long long)(v152 + 2176l) % v157 == 0);
            cuda::memcpy_async(v152 + 2176l, v155 + 131072l, cuda::aligned_size_t<v157>(v157), v3);
            constexpr long v158 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v155 + 262144l) % v158 == 0 && (unsigned long long)(v152 + 4352l) % v158 == 0);
            cuda::memcpy_async(v152 + 4352l, v155 + 262144l, cuda::aligned_size_t<v158>(v158), v3);
            constexpr long v159 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v155 + 393216l) % v159 == 0 && (unsigned long long)(v152 + 6528l) % v159 == 0);
            cuda::memcpy_async(v152 + 6528l, v155 + 393216l, cuda::aligned_size_t<v159>(v159), v3);
            long v160;
            v160 = threadIdx.x;
            bool v161;
            v161 = 0l <= v160;
            bool v162;
            v162 = v161 == false;
            if (v162){
                assert("The index needs to be zero or positive." && v161);
            } else {
            }
            long v164;
            v164 = v160 % 16l;
            long v165;
            v165 = v160 / 16l;
            bool v166;
            v166 = v165 < 32l;
            bool v167;
            v167 = v166 == false;
            if (v167){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v166);
            } else {
            }
            assert("Tensor range check" && 0 <= v165 && v165 < 32l);
            assert("Tensor range check" && 0 <= v164 && v164 < 16l);
            long v169;
            v169 = 4l * v164;
            long v170;
            v170 = 68l * v165;
            long v171;
            v171 = v170 + v169;
            long v172;
            v172 = 4096l * v165;
            long v173;
            v173 = v172 + v169;
            float * v176;
            float * v174;
            v174 = v7+v171;
            v176 = v174;
            float * v179;
            float * v177;
            v177 = v130+v173;
            v179 = v177;
            constexpr long v180 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v179 + 0l) % v180 == 0 && (unsigned long long)(v176 + 0l) % v180 == 0);
            cuda::memcpy_async(v176 + 0l, v179 + 0l, cuda::aligned_size_t<v180>(v180), v3);
            constexpr long v181 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v179 + 131072l) % v181 == 0 && (unsigned long long)(v176 + 2176l) % v181 == 0);
            cuda::memcpy_async(v176 + 2176l, v179 + 131072l, cuda::aligned_size_t<v181>(v181), v3);
            constexpr long v182 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v179 + 262144l) % v182 == 0 && (unsigned long long)(v176 + 4352l) % v182 == 0);
            cuda::memcpy_async(v176 + 4352l, v179 + 262144l, cuda::aligned_size_t<v182>(v182), v3);
            constexpr long v183 = sizeof(float) * 4l;
            assert("Pointer alignment check" && (unsigned long long)(v179 + 393216l) % v183 == 0 && (unsigned long long)(v176 + 6528l) % v183 == 0);
            cuda::memcpy_async(v176 + 6528l, v179 + 393216l, cuda::aligned_size_t<v183>(v183), v3);
            v3.producer_commit();
            // Poping the loop unrolling to: 0
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v184[32l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v185[8l];
            cuda::pipeline_consumer_wait_prior<0>(v3);;
            __syncthreads();
            long v186;
            v186 = 0l;
            #pragma unroll
            while (while_method_3(v186)){
                long v188;
                v188 = 0l;
                #pragma unroll
                while (while_method_1(v188)){
                    assert("Tensor range check" && 0 <= v186 && v186 < 4l);
                    assert("Tensor range check" && 0 <= v188 && v188 < 8l);
                    long v190;
                    v190 = 8l * v186;
                    long v191;
                    v191 = v190 + v188;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v192 = v184[v191];
                    assert("Tensor range check" && 0 <= v186 && v186 < 4l);
                    long v193;
                    v193 = 1088l * v186;
                    assert("Tensor range check" && 0 <= v188 && v188 < 8l);
                    long v194;
                    v194 = 8l * v188;
                    long v195;
                    v195 = v194 + v193;
                    long v196;
                    v196 = 0l;
                    #pragma unroll
                    while (while_method_5(v196)){
                        long v198;
                        v198 = 0l;
                        #pragma unroll
                        while (while_method_5(v198)){
                            assert("Tensor range check" && 0 <= v196 && v196 < 2l);
                            assert("Tensor range check" && 0 <= v198 && v198 < 2l);
                            long v200;
                            v200 = 544l * v198;
                            long v201;
                            v201 = v200 + v195;
                            long v202;
                            v202 = 4l * v196;
                            long v203;
                            v203 = v202 + v201;
                            float v204;
                            v204 = v46[v203];
                            bool v205;
                            v205 = 0l <= v198;
                            bool v207;
                            if (v205){
                                bool v206;
                                v206 = v198 < 2l;
                                v207 = v206;
                            } else {
                                v207 = false;
                            }
                            bool v208;
                            v208 = v207 == false;
                            if (v208){
                                assert("The indices should be inside the range of the dimension." && v207);
                            } else {
                            }
                            bool v210;
                            v210 = 0l <= v196;
                            bool v212;
                            if (v210){
                                bool v211;
                                v211 = v196 < 2l;
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
                            long v215;
                            v215 = v196 * 2l;
                            long v216;
                            v216 = v198 + v215;
                            v192.x[v216] = wmma::__float_to_tf32(v204);
                            v198 += 1l ;
                        }
                        v196 += 1l ;
                    }
                    v188 += 1l ;
                }
                v186 += 1l ;
            }
            long v217;
            v217 = 0l;
            #pragma unroll
            while (while_method_2(v217)){
                long v219;
                v219 = 0l;
                #pragma unroll
                while (while_method_1(v219)){
                    assert("Tensor range check" && 0 <= v217 && v217 < 1l);
                    assert("Tensor range check" && 0 <= v219 && v219 < 8l);
                    long v221;
                    v221 = 8l * v217;
                    long v222;
                    v222 = v221 + v219;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v223 = v185[v222];
                    assert("Tensor range check" && 0 <= v217 && v217 < 1l);
                    long v224;
                    v224 = 1088l * v217;
                    assert("Tensor range check" && 0 <= v219 && v219 < 8l);
                    long v225;
                    v225 = 8l * v219;
                    long v226;
                    v226 = v225 + v224;
                    long v227;
                    v227 = 0l;
                    #pragma unroll
                    while (while_method_5(v227)){
                        long v229;
                        v229 = 0l;
                        #pragma unroll
                        while (while_method_5(v229)){
                            assert("Tensor range check" && 0 <= v227 && v227 < 2l);
                            assert("Tensor range check" && 0 <= v229 && v229 < 2l);
                            long v231;
                            v231 = 4l * v229;
                            long v232;
                            v232 = v231 + v226;
                            long v233;
                            v233 = 544l * v227;
                            long v234;
                            v234 = v233 + v232;
                            float v235;
                            v235 = v63[v234];
                            bool v236;
                            v236 = 0l <= v229;
                            bool v238;
                            if (v236){
                                bool v237;
                                v237 = v229 < 2l;
                                v238 = v237;
                            } else {
                                v238 = false;
                            }
                            bool v239;
                            v239 = v238 == false;
                            if (v239){
                                assert("The indices should be inside the range of the dimension." && v238);
                            } else {
                            }
                            bool v241;
                            v241 = 0l <= v227;
                            bool v243;
                            if (v241){
                                bool v242;
                                v242 = v227 < 2l;
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
                            long v246;
                            v246 = v227 * 2l;
                            long v247;
                            v247 = v229 + v246;
                            v223.x[v247] = wmma::__float_to_tf32(v235);
                            v229 += 1l ;
                        }
                        v227 += 1l ;
                    }
                    v219 += 1l ;
                }
                v217 += 1l ;
            }
            v3.consumer_release();
            __syncthreads();
            long v248;
            v248 = 0l;
            #pragma unroll
            while (while_method_3(v248)){
                long v250;
                v250 = 0l;
                #pragma unroll
                while (while_method_2(v250)){
                    long v252;
                    v252 = 0l;
                    #pragma unroll
                    while (while_method_1(v252)){
                        assert("Tensor range check" && 0 <= v248 && v248 < 4l);
                        assert("Tensor range check" && 0 <= v250 && v250 < 1l);
                        long v254;
                        v254 = v248 + v250;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v255 = v64[v254];
                        assert("Tensor range check" && 0 <= v248 && v248 < 4l);
                        assert("Tensor range check" && 0 <= v252 && v252 < 8l);
                        long v256;
                        v256 = 8l * v248;
                        long v257;
                        v257 = v256 + v252;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v258 = v184[v257];
                        assert("Tensor range check" && 0 <= v250 && v250 < 1l);
                        assert("Tensor range check" && 0 <= v252 && v252 < 8l);
                        long v259;
                        v259 = 8l * v250;
                        long v260;
                        v260 = v259 + v252;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v261 = v185[v260];
                        wmma::mma_sync(v255, v258, v261, v255);
                        v252 += 1l ;
                    }
                    v250 += 1l ;
                }
                v248 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v123 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v262;
        v262 = 0l;
        #pragma unroll
        while (while_method_3(v262)){
            long v264;
            v264 = 0l;
            #pragma unroll
            while (while_method_2(v264)){
                assert("Tensor range check" && 0 <= v262 && v262 < 4l);
                assert("Tensor range check" && 0 <= v264 && v264 < 1l);
                long v266;
                v266 = v262 + v264;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v267 = v64[v266];
                assert("Tensor range check" && 0 <= v262 && v262 < 4l);
                assert("Tensor range check" && 0 <= v264 && v264 < 1l);
                long v268;
                v268 = 16l * v264;
                long v269;
                v269 = 2176l * v262;
                long v270;
                v270 = v269 + v268;
                float * v271;
                v271 = v29 + v270;
                wmma::store_matrix_sync(v271, v267, 136l, wmma::mem_row_major);
                v264 += 1l ;
            }
            v262 += 1l ;
        }
        __syncthreads();
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
        v276 = v272 % 32l;
        long v277;
        v277 = v272 / 32l;
        bool v278;
        v278 = v277 < 16l;
        bool v279;
        v279 = v278 == false;
        if (v279){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v278);
        } else {
        }
        assert("Tensor range check" && 0 <= v277 && v277 < 16l);
        assert("Tensor range check" && 0 <= v276 && v276 < 32l);
        long v281;
        v281 = 4l * v276;
        long v282;
        v282 = 8192l * v277;
        long v283;
        v283 = v282 + v281;
        long v284;
        v284 = 136l * v277;
        long v285;
        v285 = v284 + v281;
        float * v288;
        float * v286;
        v286 = v81+v283;
        v288 = v286;
        float * v291;
        float * v289;
        v289 = v13+v285;
        v291 = v289;
        long v292;
        v292 = 0l;
        #pragma unroll
        while (while_method_1(v292)){
            long v294;
            v294 = 0l;
            #pragma unroll
            while (while_method_2(v294)){
                assert("Tensor range check" && 0 <= v292 && v292 < 8l);
                assert("Tensor range check" && 0 <= v294 && v294 < 1l);
                long v296;
                v296 = 128l * v294;
                long v297;
                v297 = 131072l * v292;
                long v298;
                v298 = v297 + v296;
                long v299;
                v299 = 2176l * v292;
                long v300;
                v300 = v299 + v296;
                int4* v301;
                v301 = reinterpret_cast<int4*>(v291 + v300);
                int4* v302;
                v302 = reinterpret_cast<int4*>(v288 + v298);
                assert("Pointer alignment check" && (unsigned long long)(v301) % 4l == 0 && (unsigned long long)(v302) % 4l == 0);
                *v302 = *v301;
                v294 += 1l ;
            }
            v292 += 1l ;
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
