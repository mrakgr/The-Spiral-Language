kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cuda/pipeline>
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 8192l;
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
    long v16;
    v16 = v15 % 8l;
    long v17;
    v17 = v15 / 8l;
    long v18;
    v18 = v17 % 2l;
    long v19;
    v19 = v17 / 2l;
    bool v20;
    v20 = v19 == 0l;
    bool v21;
    v21 = v20 == false;
    if (v21){
        assert("The index has to be in the range of the dimension." && v20);
    } else {
    }
    assert("Tensor range check" && 0 <= v18 && v18 < 2l);
    assert("Tensor range check" && 0 <= v16 && v16 < 8l);
    long v23;
    v23 = 16l * v16;
    long v24;
    v24 = 4352l * v18;
    long v25;
    v25 = v24 + v23;
    float * v28;
    float * v26;
    v26 = v13+v25;
    v28 = v26;
    assert("Tensor range check" && 0 <= v18 && v18 < 2l);
    long v29;
    v29 = 2176l * v18;
    long v30;
    v30 = threadIdx.x;
    long v31;
    v31 = v30 % 32l;
    long v32;
    v32 = v31 % 4l;
    long v33;
    v33 = v31 / 4l;
    long v34;
    v34 = v33 % 8l;
    long v35;
    v35 = v33 / 8l;
    bool v36;
    v36 = v35 == 0l;
    bool v37;
    v37 = v36 == false;
    if (v37){
        assert("The index has to be in the range of the dimension." && v36);
    } else {
    }
    assert("Tensor range check" && 0 <= v34 && v34 < 8l);
    assert("Tensor range check" && 0 <= v32 && v32 < 4l);
    long v39;
    v39 = v32 + v29;
    long v40;
    v40 = 68l * v34;
    long v41;
    v41 = v40 + v39;
    float * v44;
    float * v42;
    v42 = v7+v41;
    v44 = v42;
    assert("Tensor range check" && 0 <= v16 && v16 < 8l);
    long v45;
    v45 = 1088l * v16;
    long v46;
    v46 = threadIdx.x;
    long v47;
    v47 = v46 % 32l;
    long v48;
    v48 = v47 % 4l;
    long v49;
    v49 = v47 / 4l;
    long v50;
    v50 = v49 % 8l;
    long v51;
    v51 = v49 / 8l;
    bool v52;
    v52 = v51 == 0l;
    bool v53;
    v53 = v52 == false;
    if (v53){
        assert("The index has to be in the range of the dimension." && v52);
    } else {
    }
    assert("Tensor range check" && 0 <= v50 && v50 < 8l);
    assert("Tensor range check" && 0 <= v48 && v48 < 4l);
    long v55;
    v55 = v48 + v45;
    long v56;
    v56 = 68l * v50;
    long v57;
    v57 = v56 + v55;
    float * v60;
    float * v58;
    v58 = v10+v57;
    v60 = v58;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v61[2l];
    // Pushing the loop unrolling to: 1
    long v62;
    v62 = blockIdx.x;
    long v63;
    v63 = v62;
    #pragma unroll 1
    while (while_method_0(v63)){
        long v65;
        v65 = v63 % 64l;
        long v66;
        v66 = v63 / 64l;
        long v67;
        v67 = v66 % 128l;
        long v68;
        v68 = v66 / 128l;
        bool v69;
        v69 = v68 == 0l;
        bool v70;
        v70 = v69 == false;
        if (v70){
            assert("The index has to be in the range of the dimension." && v69);
        } else {
        }
        assert("Tensor range check" && 0 <= v67 && v67 < 128l);
        assert("Tensor range check" && 0 <= v65 && v65 < 64l);
        long v72;
        v72 = 128l * v65;
        long v73;
        v73 = 524288l * v67;
        long v74;
        v74 = v73 + v72;
        float * v77;
        float * v75;
        v75 = v2+v74;
        v77 = v75;
        // Pushing the loop unrolling to: 0
        long v78;
        v78 = threadIdx.x;
        long v79;
        v79 = v78 % 32l;
        long v80;
        v80 = v78 / 32l;
        long v81;
        v81 = v80 % 16l;
        long v82;
        v82 = v80 / 16l;
        bool v83;
        v83 = v82 == 0l;
        bool v84;
        v84 = v83 == false;
        if (v84){
            assert("The index has to be in the range of the dimension." && v83);
        } else {
        }
        assert("Tensor range check" && 0 <= v81 && v81 < 16l);
        assert("Tensor range check" && 0 <= v79 && v79 < 32l);
        long v86;
        v86 = 4l * v79;
        long v87;
        v87 = 136l * v81;
        long v88;
        v88 = v87 + v86;
        long v89;
        v89 = 8192l * v81;
        long v90;
        v90 = v89 + v86;
        float * v93;
        float * v91;
        v91 = v13+v88;
        v93 = v91;
        float * v96;
        float * v94;
        v94 = v77+v90;
        v96 = v94;
        long v97;
        v97 = 0l;
        #pragma unroll
        while (while_method_1(v97)){
            long v99;
            v99 = 0l;
            #pragma unroll
            while (while_method_2(v99)){
                assert("Tensor range check" && 0 <= v97 && v97 < 4l);
                assert("Tensor range check" && 0 <= v99 && v99 < 1l);
                long v101;
                v101 = 128l * v99;
                long v102;
                v102 = 2176l * v97;
                long v103;
                v103 = v102 + v101;
                long v104;
                v104 = 131072l * v97;
                long v105;
                v105 = v104 + v101;
                int4* v106;
                v106 = reinterpret_cast<int4*>(v96 + v105);
                int4* v107;
                v107 = reinterpret_cast<int4*>(v93 + v103);
                assert("Pointer alignment check" && (unsigned long long)(v106) % 4l == 0 && (unsigned long long)(v107) % 4l == 0);
                *v107 = *v106;
                v99 += 1l ;
            }
            v97 += 1l ;
        }
        __syncthreads();
        long v108;
        v108 = 0l;
        #pragma unroll
        while (while_method_3(v108)){
            long v110;
            v110 = 0l;
            #pragma unroll
            while (while_method_2(v110)){
                assert("Tensor range check" && 0 <= v108 && v108 < 2l);
                assert("Tensor range check" && 0 <= v110 && v110 < 1l);
                long v112;
                v112 = v108 + v110;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v113 = v61[v112];
                assert("Tensor range check" && 0 <= v108 && v108 < 2l);
                assert("Tensor range check" && 0 <= v110 && v110 < 1l);
                long v114;
                v114 = 16l * v110;
                long v115;
                v115 = 2176l * v108;
                long v116;
                v116 = v115 + v114;
                float * v117;
                v117 = v28 + v116;
                wmma::load_matrix_sync(v113, v117, 136l, wmma::mem_row_major);
                v110 += 1l ;
            }
            v108 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        long v118;
        v118 = 0l;
        #pragma unroll 1
        while (while_method_4(v118)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v67 && v67 < 128l);
            long v120;
            v120 = 262144l * v67;
            assert("Tensor range check" && 0 <= v118 && v118 < 64l);
            long v121;
            v121 = 64l * v118;
            long v122;
            v122 = v121 + v120;
            float * v125;
            float * v123;
            v123 = v0+v122;
            v125 = v123;
            assert("Tensor range check" && 0 <= v65 && v65 < 64l);
            long v126;
            v126 = 524288l * v65;
            assert("Tensor range check" && 0 <= v118 && v118 < 64l);
            long v127;
            v127 = v121 + v126;
            float * v130;
            float * v128;
            v128 = v1+v127;
            v130 = v128;
            v3.producer_acquire();
            long v131;
            v131 = threadIdx.x;
            long v132;
            v132 = v131 % 16l;
            long v133;
            v133 = v131 / 16l;
            long v134;
            v134 = v133 % 32l;
            long v135;
            v135 = v133 / 32l;
            bool v136;
            v136 = v135 == 0l;
            bool v137;
            v137 = v136 == false;
            if (v137){
                assert("The index has to be in the range of the dimension." && v136);
            } else {
            }
            assert("Tensor range check" && 0 <= v134 && v134 < 32l);
            assert("Tensor range check" && 0 <= v132 && v132 < 16l);
            long v139;
            v139 = 4l * v132;
            long v140;
            v140 = 68l * v134;
            long v141;
            v141 = v140 + v139;
            long v142;
            v142 = 4096l * v134;
            long v143;
            v143 = v142 + v139;
            float * v146;
            float * v144;
            v144 = v10+v141;
            v146 = v144;
            float * v149;
            float * v147;
            v147 = v130+v143;
            v149 = v147;
            long v150;
            v150 = 0l;
            #pragma unroll
            while (while_method_1(v150)){
                long v152;
                v152 = 0l;
                #pragma unroll
                while (while_method_2(v152)){
                    assert("Tensor range check" && 0 <= v150 && v150 < 4l);
                    assert("Tensor range check" && 0 <= v152 && v152 < 1l);
                    long v154;
                    v154 = 64l * v152;
                    long v155;
                    v155 = 2176l * v150;
                    long v156;
                    v156 = v155 + v154;
                    long v157;
                    v157 = 131072l * v150;
                    long v158;
                    v158 = v157 + v154;
                    constexpr long v159 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v149 + v158) % v159 == 0 && (unsigned long long)(v146 + v156) % v159 == 0);
                    cuda::memcpy_async(v146 + v156, v149 + v158, cuda::aligned_size_t<v159>(v159), v3);
                    v152 += 1l ;
                }
                v150 += 1l ;
            }
            long v160;
            v160 = threadIdx.x;
            long v161;
            v161 = v160 % 16l;
            long v162;
            v162 = v160 / 16l;
            long v163;
            v163 = v162 % 32l;
            long v164;
            v164 = v162 / 32l;
            bool v165;
            v165 = v164 == 0l;
            bool v166;
            v166 = v165 == false;
            if (v166){
                assert("The index has to be in the range of the dimension." && v165);
            } else {
            }
            assert("Tensor range check" && 0 <= v163 && v163 < 32l);
            assert("Tensor range check" && 0 <= v161 && v161 < 16l);
            long v168;
            v168 = 4l * v161;
            long v169;
            v169 = 68l * v163;
            long v170;
            v170 = v169 + v168;
            long v171;
            v171 = 4096l * v163;
            long v172;
            v172 = v171 + v168;
            float * v175;
            float * v173;
            v173 = v7+v170;
            v175 = v173;
            float * v178;
            float * v176;
            v176 = v125+v172;
            v178 = v176;
            long v179;
            v179 = 0l;
            #pragma unroll
            while (while_method_3(v179)){
                long v181;
                v181 = 0l;
                #pragma unroll
                while (while_method_2(v181)){
                    assert("Tensor range check" && 0 <= v179 && v179 < 2l);
                    assert("Tensor range check" && 0 <= v181 && v181 < 1l);
                    long v183;
                    v183 = 64l * v181;
                    long v184;
                    v184 = 2176l * v179;
                    long v185;
                    v185 = v184 + v183;
                    long v186;
                    v186 = 131072l * v179;
                    long v187;
                    v187 = v186 + v183;
                    constexpr long v188 = sizeof(float) * 4l;
                    assert("Pointer alignment check" && (unsigned long long)(v178 + v187) % v188 == 0 && (unsigned long long)(v175 + v185) % v188 == 0);
                    cuda::memcpy_async(v175 + v185, v178 + v187, cuda::aligned_size_t<v188>(v188), v3);
                    v181 += 1l ;
                }
                v179 += 1l ;
            }
            v3.producer_commit();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v189[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v190[8l];
            v3.consumer_wait();
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
                            v209 = v44[v208];
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
                            v240 = v60[v239];
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
            long v253;
            v253 = 0l;
            #pragma unroll
            while (while_method_3(v253)){
                long v255;
                v255 = 0l;
                #pragma unroll
                while (while_method_2(v255)){
                    long v257;
                    v257 = 0l;
                    #pragma unroll
                    while (while_method_5(v257)){
                        assert("Tensor range check" && 0 <= v253 && v253 < 2l);
                        assert("Tensor range check" && 0 <= v255 && v255 < 1l);
                        long v259;
                        v259 = v253 + v255;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v260 = v61[v259];
                        assert("Tensor range check" && 0 <= v253 && v253 < 2l);
                        assert("Tensor range check" && 0 <= v257 && v257 < 8l);
                        long v261;
                        v261 = 8l * v253;
                        long v262;
                        v262 = v261 + v257;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v263 = v189[v262];
                        assert("Tensor range check" && 0 <= v255 && v255 < 1l);
                        assert("Tensor range check" && 0 <= v257 && v257 < 8l);
                        long v264;
                        v264 = 8l * v255;
                        long v265;
                        v265 = v264 + v257;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v266 = v190[v265];
                        wmma::mma_sync(v260, v263, v266, v260);
                        v257 += 1l ;
                    }
                    v255 += 1l ;
                }
                v253 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v118 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v267;
        v267 = 0l;
        #pragma unroll
        while (while_method_3(v267)){
            long v269;
            v269 = 0l;
            #pragma unroll
            while (while_method_2(v269)){
                assert("Tensor range check" && 0 <= v267 && v267 < 2l);
                assert("Tensor range check" && 0 <= v269 && v269 < 1l);
                long v271;
                v271 = v267 + v269;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v272 = v61[v271];
                assert("Tensor range check" && 0 <= v267 && v267 < 2l);
                assert("Tensor range check" && 0 <= v269 && v269 < 1l);
                long v273;
                v273 = 16l * v269;
                long v274;
                v274 = 2176l * v267;
                long v275;
                v275 = v274 + v273;
                float * v276;
                v276 = v28 + v275;
                wmma::store_matrix_sync(v276, v272, 136l, wmma::mem_row_major);
                v269 += 1l ;
            }
            v267 += 1l ;
        }
        __syncthreads();
        long v277;
        v277 = threadIdx.x;
        long v278;
        v278 = v277 % 32l;
        long v279;
        v279 = v277 / 32l;
        long v280;
        v280 = v279 % 16l;
        long v281;
        v281 = v279 / 16l;
        bool v282;
        v282 = v281 == 0l;
        bool v283;
        v283 = v282 == false;
        if (v283){
            assert("The index has to be in the range of the dimension." && v282);
        } else {
        }
        assert("Tensor range check" && 0 <= v280 && v280 < 16l);
        assert("Tensor range check" && 0 <= v278 && v278 < 32l);
        long v285;
        v285 = 4l * v278;
        long v286;
        v286 = 8192l * v280;
        long v287;
        v287 = v286 + v285;
        long v288;
        v288 = 136l * v280;
        long v289;
        v289 = v288 + v285;
        float * v292;
        float * v290;
        v290 = v77+v287;
        v292 = v290;
        float * v295;
        float * v293;
        v293 = v13+v289;
        v295 = v293;
        long v296;
        v296 = 0l;
        #pragma unroll
        while (while_method_1(v296)){
            long v298;
            v298 = 0l;
            #pragma unroll
            while (while_method_2(v298)){
                assert("Tensor range check" && 0 <= v296 && v296 < 4l);
                assert("Tensor range check" && 0 <= v298 && v298 < 1l);
                long v300;
                v300 = 128l * v298;
                long v301;
                v301 = 131072l * v296;
                long v302;
                v302 = v301 + v300;
                long v303;
                v303 = 2176l * v296;
                long v304;
                v304 = v303 + v300;
                int4* v305;
                v305 = reinterpret_cast<int4*>(v295 + v304);
                int4* v306;
                v306 = reinterpret_cast<int4*>(v292 + v302);
                assert("Pointer alignment check" && (unsigned long long)(v305) % 4l == 0 && (unsigned long long)(v306) % 4l == 0);
                *v306 = *v305;
                v298 += 1l ;
            }
            v296 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v63 += 24l ;
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
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
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
