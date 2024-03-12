kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
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
    v1 = v0 < 2l;
    return v1;
}
__device__ inline bool while_method_5(long v0){
    bool v1;
    v1 = v0 < 128l;
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
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    cuda::pipeline<cuda::thread_scope_thread> v3 = cuda::make_pipeline();
    extern __shared__ unsigned char v4[];
    float * v7;
    float * v5;
    v5 = reinterpret_cast<float *>(&v4[0ull]);
    v7 = v5;
    float * v10;
    float * v8;
    v8 = reinterpret_cast<float *>(&v4[18432ull]);
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
    v30 = 2304l * v20;
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
    v42 = 36l * v37;
    long v43;
    v43 = v42 + v41;
    float * v46;
    float * v44;
    v44 = v7+v43;
    v46 = v44;
    assert("Tensor range check" && 0 <= v19 && v19 < 8l);
    long v47;
    v47 = 576l * v19;
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
    v59 = 36l * v54;
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
        assert("Tensor range check" && 0 <= v72 && v72 < 64l);
        long v123;
        v123 = 524288l * v72;
        float * v126;
        float * v124;
        v124 = v0+v123;
        v126 = v124;
        assert("Tensor range check" && 0 <= v71 && v71 < 64l);
        long v127;
        v127 = 524288l * v71;
        float * v130;
        float * v128;
        v128 = v1+v127;
        v130 = v128;
        // Pushing the loop unrolling to: 0
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
        v135 = v131 % 8l;
        long v136;
        v136 = v131 / 8l;
        bool v137;
        v137 = v136 < 64l;
        bool v138;
        v138 = v137 == false;
        if (v138){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v137);
        } else {
        }
        assert("Tensor range check" && 0 <= v136 && v136 < 64l);
        assert("Tensor range check" && 0 <= v135 && v135 < 8l);
        long v140;
        v140 = 4l * v135;
        long v141;
        v141 = 36l * v136;
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
        long v151;
        v151 = 0l;
        #pragma unroll
        while (while_method_4(v151)){
            long v153;
            v153 = 0l;
            #pragma unroll
            while (while_method_2(v153)){
                assert("Tensor range check" && 0 <= v151 && v151 < 2l);
                assert("Tensor range check" && 0 <= v153 && v153 < 1l);
                long v155;
                v155 = 32l * v153;
                long v156;
                v156 = 2304l * v151;
                long v157;
                v157 = v156 + v155;
                long v158;
                v158 = 262144l * v151;
                long v159;
                v159 = v158 + v155;
                v3.producer_acquire();
                constexpr long v160 = sizeof(float) * 4l;
                assert("Pointer alignment check" && (unsigned long long)(v150 + v159) % v160 == 0 && (unsigned long long)(v147 + v157) % v160 == 0);
                cuda::memcpy_async(v147 + v157, v150 + v159, cuda::aligned_size_t<v160>(v160), v3);
                v3.producer_commit();
                v153 += 1l ;
            }
            v151 += 1l ;
        }
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
        bool v167;
        v167 = v166 < 64l;
        bool v168;
        v168 = v167 == false;
        if (v168){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v167);
        } else {
        }
        assert("Tensor range check" && 0 <= v166 && v166 < 64l);
        assert("Tensor range check" && 0 <= v165 && v165 < 8l);
        long v170;
        v170 = 4l * v165;
        long v171;
        v171 = 36l * v166;
        long v172;
        v172 = v171 + v170;
        long v173;
        v173 = 4096l * v166;
        long v174;
        v174 = v173 + v170;
        float * v177;
        float * v175;
        v175 = v7+v172;
        v177 = v175;
        float * v180;
        float * v178;
        v178 = v126+v174;
        v180 = v178;
        long v181;
        v181 = 0l;
        #pragma unroll
        while (while_method_4(v181)){
            long v183;
            v183 = 0l;
            #pragma unroll
            while (while_method_2(v183)){
                assert("Tensor range check" && 0 <= v181 && v181 < 2l);
                assert("Tensor range check" && 0 <= v183 && v183 < 1l);
                long v185;
                v185 = 32l * v183;
                long v186;
                v186 = 2304l * v181;
                long v187;
                v187 = v186 + v185;
                long v188;
                v188 = 262144l * v181;
                long v189;
                v189 = v188 + v185;
                v3.producer_acquire();
                constexpr long v190 = sizeof(float) * 4l;
                assert("Pointer alignment check" && (unsigned long long)(v180 + v189) % v190 == 0 && (unsigned long long)(v177 + v187) % v190 == 0);
                cuda::memcpy_async(v177 + v187, v180 + v189, cuda::aligned_size_t<v190>(v190), v3);
                v3.producer_commit();
                v183 += 1l ;
            }
            v181 += 1l ;
        }
        // Poping the loop unrolling to: 0
        long v191;
        v191 = 0l;
        #pragma unroll 1
        while (while_method_5(v191)){
            long v193;
            v193 = v191 + 1l;
            bool v194;
            v194 = v193 < 128l;
            US0 v200;
            if (v194){
                bool v195;
                v195 = 0l <= v193;
                bool v196;
                v196 = v195 == false;
                if (v196){
                    assert("The index needs to be zero or positive." && v195);
                } else {
                }
                v200 = US0_1(v193);
            } else {
                v200 = US0_0();
            }
            // Pushing the loop unrolling to: 0
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v201[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v202[4l];
            cuda::pipeline_consumer_wait_prior<0>(v3);;
            __syncthreads();
            long v203;
            v203 = 0l;
            #pragma unroll
            while (while_method_3(v203)){
                long v205;
                v205 = 0l;
                #pragma unroll
                while (while_method_3(v205)){
                    assert("Tensor range check" && 0 <= v203 && v203 < 4l);
                    assert("Tensor range check" && 0 <= v205 && v205 < 4l);
                    long v207;
                    v207 = 4l * v203;
                    long v208;
                    v208 = v207 + v205;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v209 = v201[v208];
                    assert("Tensor range check" && 0 <= v203 && v203 < 4l);
                    long v210;
                    v210 = 576l * v203;
                    assert("Tensor range check" && 0 <= v205 && v205 < 4l);
                    long v211;
                    v211 = 8l * v205;
                    long v212;
                    v212 = v211 + v210;
                    long v213;
                    v213 = 0l;
                    #pragma unroll
                    while (while_method_4(v213)){
                        long v215;
                        v215 = 0l;
                        #pragma unroll
                        while (while_method_4(v215)){
                            assert("Tensor range check" && 0 <= v213 && v213 < 2l);
                            assert("Tensor range check" && 0 <= v215 && v215 < 2l);
                            long v217;
                            v217 = 288l * v215;
                            long v218;
                            v218 = v217 + v212;
                            long v219;
                            v219 = 4l * v213;
                            long v220;
                            v220 = v219 + v218;
                            float v221;
                            v221 = v46[v220];
                            bool v222;
                            v222 = 0l <= v215;
                            bool v224;
                            if (v222){
                                bool v223;
                                v223 = v215 < 2l;
                                v224 = v223;
                            } else {
                                v224 = false;
                            }
                            bool v225;
                            v225 = v224 == false;
                            if (v225){
                                assert("The indices should be inside the range of the dimension." && v224);
                            } else {
                            }
                            bool v227;
                            v227 = 0l <= v213;
                            bool v229;
                            if (v227){
                                bool v228;
                                v228 = v213 < 2l;
                                v229 = v228;
                            } else {
                                v229 = false;
                            }
                            bool v230;
                            v230 = v229 == false;
                            if (v230){
                                assert("The indices should be inside the range of the dimension." && v229);
                            } else {
                            }
                            long v232;
                            v232 = v213 * 2l;
                            long v233;
                            v233 = v215 + v232;
                            v209.x[v233] = wmma::__float_to_tf32(v221);
                            v215 += 1l ;
                        }
                        v213 += 1l ;
                    }
                    v205 += 1l ;
                }
                v203 += 1l ;
            }
            long v234;
            v234 = 0l;
            #pragma unroll
            while (while_method_2(v234)){
                long v236;
                v236 = 0l;
                #pragma unroll
                while (while_method_3(v236)){
                    assert("Tensor range check" && 0 <= v234 && v234 < 1l);
                    assert("Tensor range check" && 0 <= v236 && v236 < 4l);
                    long v238;
                    v238 = 4l * v234;
                    long v239;
                    v239 = v238 + v236;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v240 = v202[v239];
                    assert("Tensor range check" && 0 <= v234 && v234 < 1l);
                    long v241;
                    v241 = 576l * v234;
                    assert("Tensor range check" && 0 <= v236 && v236 < 4l);
                    long v242;
                    v242 = 8l * v236;
                    long v243;
                    v243 = v242 + v241;
                    long v244;
                    v244 = 0l;
                    #pragma unroll
                    while (while_method_4(v244)){
                        long v246;
                        v246 = 0l;
                        #pragma unroll
                        while (while_method_4(v246)){
                            assert("Tensor range check" && 0 <= v244 && v244 < 2l);
                            assert("Tensor range check" && 0 <= v246 && v246 < 2l);
                            long v248;
                            v248 = 4l * v246;
                            long v249;
                            v249 = v248 + v243;
                            long v250;
                            v250 = 288l * v244;
                            long v251;
                            v251 = v250 + v249;
                            float v252;
                            v252 = v63[v251];
                            bool v253;
                            v253 = 0l <= v246;
                            bool v255;
                            if (v253){
                                bool v254;
                                v254 = v246 < 2l;
                                v255 = v254;
                            } else {
                                v255 = false;
                            }
                            bool v256;
                            v256 = v255 == false;
                            if (v256){
                                assert("The indices should be inside the range of the dimension." && v255);
                            } else {
                            }
                            bool v258;
                            v258 = 0l <= v244;
                            bool v260;
                            if (v258){
                                bool v259;
                                v259 = v244 < 2l;
                                v260 = v259;
                            } else {
                                v260 = false;
                            }
                            bool v261;
                            v261 = v260 == false;
                            if (v261){
                                assert("The indices should be inside the range of the dimension." && v260);
                            } else {
                            }
                            long v263;
                            v263 = v244 * 2l;
                            long v264;
                            v264 = v246 + v263;
                            v240.x[v264] = wmma::__float_to_tf32(v252);
                            v246 += 1l ;
                        }
                        v244 += 1l ;
                    }
                    v236 += 1l ;
                }
                v234 += 1l ;
            }
            v3.consumer_release();
            __syncthreads();
            switch (v200.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    long v265 = v200.v.case1.v0;
                    assert("Tensor range check" && 0 <= v72 && v72 < 64l);
                    assert("Tensor range check" && 0 <= v265 && v265 < 128l);
                    long v266;
                    v266 = 32l * v265;
                    long v267;
                    v267 = v266 + v123;
                    float * v270;
                    float * v268;
                    v268 = v0+v267;
                    v270 = v268;
                    assert("Tensor range check" && 0 <= v71 && v71 < 64l);
                    assert("Tensor range check" && 0 <= v265 && v265 < 128l);
                    long v271;
                    v271 = v266 + v127;
                    float * v274;
                    float * v272;
                    v272 = v1+v271;
                    v274 = v272;
                    // Pushing the loop unrolling to: 0
                    long v275;
                    v275 = threadIdx.x;
                    bool v276;
                    v276 = 0l <= v275;
                    bool v277;
                    v277 = v276 == false;
                    if (v277){
                        assert("The index needs to be zero or positive." && v276);
                    } else {
                    }
                    long v279;
                    v279 = v275 % 8l;
                    long v280;
                    v280 = v275 / 8l;
                    bool v281;
                    v281 = v280 < 64l;
                    bool v282;
                    v282 = v281 == false;
                    if (v282){
                        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v281);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v280 && v280 < 64l);
                    assert("Tensor range check" && 0 <= v279 && v279 < 8l);
                    long v284;
                    v284 = 4l * v279;
                    long v285;
                    v285 = 36l * v280;
                    long v286;
                    v286 = v285 + v284;
                    long v287;
                    v287 = 4096l * v280;
                    long v288;
                    v288 = v287 + v284;
                    float * v291;
                    float * v289;
                    v289 = v10+v286;
                    v291 = v289;
                    float * v294;
                    float * v292;
                    v292 = v274+v288;
                    v294 = v292;
                    long v295;
                    v295 = 0l;
                    #pragma unroll
                    while (while_method_4(v295)){
                        long v297;
                        v297 = 0l;
                        #pragma unroll
                        while (while_method_2(v297)){
                            assert("Tensor range check" && 0 <= v295 && v295 < 2l);
                            assert("Tensor range check" && 0 <= v297 && v297 < 1l);
                            long v299;
                            v299 = 32l * v297;
                            long v300;
                            v300 = 2304l * v295;
                            long v301;
                            v301 = v300 + v299;
                            long v302;
                            v302 = 262144l * v295;
                            long v303;
                            v303 = v302 + v299;
                            v3.producer_acquire();
                            constexpr long v304 = sizeof(float) * 4l;
                            assert("Pointer alignment check" && (unsigned long long)(v294 + v303) % v304 == 0 && (unsigned long long)(v291 + v301) % v304 == 0);
                            cuda::memcpy_async(v291 + v301, v294 + v303, cuda::aligned_size_t<v304>(v304), v3);
                            v3.producer_commit();
                            v297 += 1l ;
                        }
                        v295 += 1l ;
                    }
                    long v305;
                    v305 = threadIdx.x;
                    bool v306;
                    v306 = 0l <= v305;
                    bool v307;
                    v307 = v306 == false;
                    if (v307){
                        assert("The index needs to be zero or positive." && v306);
                    } else {
                    }
                    long v309;
                    v309 = v305 % 8l;
                    long v310;
                    v310 = v305 / 8l;
                    bool v311;
                    v311 = v310 < 64l;
                    bool v312;
                    v312 = v311 == false;
                    if (v312){
                        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v311);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v310 && v310 < 64l);
                    assert("Tensor range check" && 0 <= v309 && v309 < 8l);
                    long v314;
                    v314 = 4l * v309;
                    long v315;
                    v315 = 36l * v310;
                    long v316;
                    v316 = v315 + v314;
                    long v317;
                    v317 = 4096l * v310;
                    long v318;
                    v318 = v317 + v314;
                    float * v321;
                    float * v319;
                    v319 = v7+v316;
                    v321 = v319;
                    float * v324;
                    float * v322;
                    v322 = v270+v318;
                    v324 = v322;
                    long v325;
                    v325 = 0l;
                    #pragma unroll
                    while (while_method_4(v325)){
                        long v327;
                        v327 = 0l;
                        #pragma unroll
                        while (while_method_2(v327)){
                            assert("Tensor range check" && 0 <= v325 && v325 < 2l);
                            assert("Tensor range check" && 0 <= v327 && v327 < 1l);
                            long v329;
                            v329 = 32l * v327;
                            long v330;
                            v330 = 2304l * v325;
                            long v331;
                            v331 = v330 + v329;
                            long v332;
                            v332 = 262144l * v325;
                            long v333;
                            v333 = v332 + v329;
                            v3.producer_acquire();
                            constexpr long v334 = sizeof(float) * 4l;
                            assert("Pointer alignment check" && (unsigned long long)(v324 + v333) % v334 == 0 && (unsigned long long)(v321 + v331) % v334 == 0);
                            cuda::memcpy_async(v321 + v331, v324 + v333, cuda::aligned_size_t<v334>(v334), v3);
                            v3.producer_commit();
                            v327 += 1l ;
                        }
                        v325 += 1l ;
                    }
                    // Poping the loop unrolling to: 0
                }
            }
            long v335;
            v335 = 0l;
            #pragma unroll
            while (while_method_3(v335)){
                long v337;
                v337 = 0l;
                #pragma unroll
                while (while_method_2(v337)){
                    long v339;
                    v339 = 0l;
                    #pragma unroll
                    while (while_method_3(v339)){
                        assert("Tensor range check" && 0 <= v335 && v335 < 4l);
                        assert("Tensor range check" && 0 <= v337 && v337 < 1l);
                        long v341;
                        v341 = v335 + v337;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v342 = v64[v341];
                        assert("Tensor range check" && 0 <= v335 && v335 < 4l);
                        assert("Tensor range check" && 0 <= v339 && v339 < 4l);
                        long v343;
                        v343 = 4l * v335;
                        long v344;
                        v344 = v343 + v339;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v345 = v201[v344];
                        assert("Tensor range check" && 0 <= v337 && v337 < 1l);
                        assert("Tensor range check" && 0 <= v339 && v339 < 4l);
                        long v346;
                        v346 = 4l * v337;
                        long v347;
                        v347 = v346 + v339;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v348 = v202[v347];
                        wmma::mma_sync(v342, v345, v348, v342);
                        v339 += 1l ;
                    }
                    v337 += 1l ;
                }
                v335 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v191 = v193;
        }
        // Pushing the loop unrolling to: 0
        long v349;
        v349 = 0l;
        #pragma unroll
        while (while_method_3(v349)){
            long v351;
            v351 = 0l;
            #pragma unroll
            while (while_method_2(v351)){
                assert("Tensor range check" && 0 <= v349 && v349 < 4l);
                assert("Tensor range check" && 0 <= v351 && v351 < 1l);
                long v353;
                v353 = v349 + v351;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v354 = v64[v353];
                assert("Tensor range check" && 0 <= v349 && v349 < 4l);
                assert("Tensor range check" && 0 <= v351 && v351 < 1l);
                long v355;
                v355 = 16l * v351;
                long v356;
                v356 = 2176l * v349;
                long v357;
                v357 = v356 + v355;
                float * v358;
                v358 = v29 + v357;
                wmma::store_matrix_sync(v358, v354, 136l, wmma::mem_row_major);
                v351 += 1l ;
            }
            v349 += 1l ;
        }
        __syncthreads();
        long v359;
        v359 = threadIdx.x;
        bool v360;
        v360 = 0l <= v359;
        bool v361;
        v361 = v360 == false;
        if (v361){
            assert("The index needs to be zero or positive." && v360);
        } else {
        }
        long v363;
        v363 = v359 % 32l;
        long v364;
        v364 = v359 / 32l;
        bool v365;
        v365 = v364 < 16l;
        bool v366;
        v366 = v365 == false;
        if (v366){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v365);
        } else {
        }
        assert("Tensor range check" && 0 <= v364 && v364 < 16l);
        assert("Tensor range check" && 0 <= v363 && v363 < 32l);
        long v368;
        v368 = 4l * v363;
        long v369;
        v369 = 8192l * v364;
        long v370;
        v370 = v369 + v368;
        long v371;
        v371 = 136l * v364;
        long v372;
        v372 = v371 + v368;
        float * v375;
        float * v373;
        v373 = v81+v370;
        v375 = v373;
        float * v378;
        float * v376;
        v376 = v13+v372;
        v378 = v376;
        long v379;
        v379 = 0l;
        #pragma unroll
        while (while_method_1(v379)){
            long v381;
            v381 = 0l;
            #pragma unroll
            while (while_method_2(v381)){
                assert("Tensor range check" && 0 <= v379 && v379 < 8l);
                assert("Tensor range check" && 0 <= v381 && v381 < 1l);
                long v383;
                v383 = 128l * v381;
                long v384;
                v384 = 131072l * v379;
                long v385;
                v385 = v384 + v383;
                long v386;
                v386 = 2176l * v379;
                long v387;
                v387 = v386 + v383;
                int4* v388;
                v388 = reinterpret_cast<int4*>(v378 + v387);
                int4* v389;
                v389 = reinterpret_cast<int4*>(v375 + v385);
                assert("Pointer alignment check" && (unsigned long long)(v388) % 4l == 0 && (unsigned long long)(v389) % 4l == 0);
                *v389 = *v388;
                v381 += 1l ;
            }
            v379 += 1l ;
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
