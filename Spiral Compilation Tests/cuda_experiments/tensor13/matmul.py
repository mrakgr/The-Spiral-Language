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
__device__ inline bool while_method_4(bool v0){
    return v0;
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
    v24 = 8704l * v18;
    long v25;
    v25 = v24 + v23;
    float * v28;
    float * v26;
    v26 = v13+v25;
    v28 = v26;
    assert("Tensor range check" && 0 <= v18 && v18 < 2l);
    long v29;
    v29 = 4352l * v18;
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
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v61[4l];
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
        v67 = v66 % 64l;
        long v68;
        v68 = v66 / 64l;
        bool v69;
        v69 = v68 == 0l;
        bool v70;
        v70 = v69 == false;
        if (v70){
            assert("The index has to be in the range of the dimension." && v69);
        } else {
        }
        assert("Tensor range check" && 0 <= v67 && v67 < 64l);
        assert("Tensor range check" && 0 <= v65 && v65 < 64l);
        long v72;
        v72 = 128l * v65;
        long v73;
        v73 = 1048576l * v67;
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
                assert("Tensor range check" && 0 <= v97 && v97 < 8l);
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
                assert("Tensor range check" && 0 <= v108 && v108 < 4l);
                assert("Tensor range check" && 0 <= v110 && v110 < 1l);
                long v112;
                v112 = v108 + v110;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v113 = v61[v112];
                assert("Tensor range check" && 0 <= v108 && v108 < 4l);
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
        bool v119;
        v119 = true;
        bool v120;
        v120 = true;
        #pragma unroll 1
        while (while_method_4(v119)){
            long v122;
            v122 = v118 + 1l;
            bool v123;
            v123 = v122 < 64l;
            long v124;
            v124 = v118 % 64l;
            long v125;
            v125 = v118 / 64l;
            bool v126;
            v126 = v125 == 0l;
            bool v127;
            v127 = v126 == false;
            if (v127){
                assert("The index has to be in the range of the dimension." && v126);
            } else {
            }
            US0 v136;
            if (v123){
                long v129;
                v129 = v122 % 64l;
                long v130;
                v130 = v122 / 64l;
                bool v131;
                v131 = v130 == 0l;
                bool v132;
                v132 = v131 == false;
                if (v132){
                    assert("The index has to be in the range of the dimension." && v131);
                } else {
                }
                v136 = US0_1(v129);
            } else {
                v136 = US0_0();
            }
            // Pushing the loop unrolling to: 0
            if (v120){
                assert("Tensor range check" && 0 <= v67 && v67 < 64l);
                long v137;
                v137 = 524288l * v67;
                assert("Tensor range check" && 0 <= v124 && v124 < 64l);
                long v138;
                v138 = 64l * v124;
                long v139;
                v139 = v138 + v137;
                float * v142;
                float * v140;
                v140 = v0+v139;
                v142 = v140;
                assert("Tensor range check" && 0 <= v65 && v65 < 64l);
                long v143;
                v143 = 524288l * v65;
                assert("Tensor range check" && 0 <= v124 && v124 < 64l);
                long v144;
                v144 = v138 + v143;
                float * v147;
                float * v145;
                v145 = v1+v144;
                v147 = v145;
                long v148;
                v148 = threadIdx.x;
                long v149;
                v149 = v148 % 16l;
                long v150;
                v150 = v148 / 16l;
                long v151;
                v151 = v150 % 32l;
                long v152;
                v152 = v150 / 32l;
                bool v153;
                v153 = v152 == 0l;
                bool v154;
                v154 = v153 == false;
                if (v154){
                    assert("The index has to be in the range of the dimension." && v153);
                } else {
                }
                assert("Tensor range check" && 0 <= v151 && v151 < 32l);
                assert("Tensor range check" && 0 <= v149 && v149 < 16l);
                long v156;
                v156 = 4l * v149;
                long v157;
                v157 = 68l * v151;
                long v158;
                v158 = v157 + v156;
                long v159;
                v159 = 4096l * v151;
                long v160;
                v160 = v159 + v156;
                float * v163;
                float * v161;
                v161 = v10+v158;
                v163 = v161;
                float * v166;
                float * v164;
                v164 = v147+v160;
                v166 = v164;
                long v167;
                v167 = 0l;
                #pragma unroll
                while (while_method_3(v167)){
                    long v169;
                    v169 = 0l;
                    #pragma unroll
                    while (while_method_2(v169)){
                        assert("Tensor range check" && 0 <= v167 && v167 < 4l);
                        assert("Tensor range check" && 0 <= v169 && v169 < 1l);
                        long v171;
                        v171 = 64l * v169;
                        long v172;
                        v172 = 2176l * v167;
                        long v173;
                        v173 = v172 + v171;
                        long v174;
                        v174 = 131072l * v167;
                        long v175;
                        v175 = v174 + v171;
                        v3.producer_acquire();
                        constexpr long v176 = sizeof(float) * 4l;
                        assert("Pointer alignment check" && (unsigned long long)(v166 + v175) % v176 == 0 && (unsigned long long)(v163 + v173) % v176 == 0);
                        cuda::memcpy_async(v163 + v173, v166 + v175, cuda::aligned_size_t<v176>(v176), v3);
                        v3.producer_commit();
                        v169 += 1l ;
                    }
                    v167 += 1l ;
                }
                long v177;
                v177 = threadIdx.x;
                long v178;
                v178 = v177 % 16l;
                long v179;
                v179 = v177 / 16l;
                long v180;
                v180 = v179 % 32l;
                long v181;
                v181 = v179 / 32l;
                bool v182;
                v182 = v181 == 0l;
                bool v183;
                v183 = v182 == false;
                if (v183){
                    assert("The index has to be in the range of the dimension." && v182);
                } else {
                }
                assert("Tensor range check" && 0 <= v180 && v180 < 32l);
                assert("Tensor range check" && 0 <= v178 && v178 < 16l);
                long v185;
                v185 = 4l * v178;
                long v186;
                v186 = 68l * v180;
                long v187;
                v187 = v186 + v185;
                long v188;
                v188 = 4096l * v180;
                long v189;
                v189 = v188 + v185;
                float * v192;
                float * v190;
                v190 = v7+v187;
                v192 = v190;
                float * v195;
                float * v193;
                v193 = v142+v189;
                v195 = v193;
                long v196;
                v196 = 0l;
                #pragma unroll
                while (while_method_3(v196)){
                    long v198;
                    v198 = 0l;
                    #pragma unroll
                    while (while_method_2(v198)){
                        assert("Tensor range check" && 0 <= v196 && v196 < 4l);
                        assert("Tensor range check" && 0 <= v198 && v198 < 1l);
                        long v200;
                        v200 = 64l * v198;
                        long v201;
                        v201 = 2176l * v196;
                        long v202;
                        v202 = v201 + v200;
                        long v203;
                        v203 = 131072l * v196;
                        long v204;
                        v204 = v203 + v200;
                        v3.producer_acquire();
                        constexpr long v205 = sizeof(float) * 4l;
                        assert("Pointer alignment check" && (unsigned long long)(v195 + v204) % v205 == 0 && (unsigned long long)(v192 + v202) % v205 == 0);
                        cuda::memcpy_async(v192 + v202, v195 + v204, cuda::aligned_size_t<v205>(v205), v3);
                        v3.producer_commit();
                        v198 += 1l ;
                    }
                    v196 += 1l ;
                }
            } else {
            }
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v206[32l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v207[8l];
            cuda::pipeline_consumer_wait_prior<0>(v3);;
            __syncthreads();
            long v208;
            v208 = 0l;
            #pragma unroll
            while (while_method_3(v208)){
                long v210;
                v210 = 0l;
                #pragma unroll
                while (while_method_1(v210)){
                    assert("Tensor range check" && 0 <= v208 && v208 < 4l);
                    assert("Tensor range check" && 0 <= v210 && v210 < 8l);
                    long v212;
                    v212 = 8l * v208;
                    long v213;
                    v213 = v212 + v210;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v214 = v206[v213];
                    assert("Tensor range check" && 0 <= v208 && v208 < 4l);
                    long v215;
                    v215 = 1088l * v208;
                    assert("Tensor range check" && 0 <= v210 && v210 < 8l);
                    long v216;
                    v216 = 8l * v210;
                    long v217;
                    v217 = v216 + v215;
                    long v218;
                    v218 = 0l;
                    #pragma unroll
                    while (while_method_5(v218)){
                        long v220;
                        v220 = 0l;
                        #pragma unroll
                        while (while_method_5(v220)){
                            assert("Tensor range check" && 0 <= v218 && v218 < 2l);
                            assert("Tensor range check" && 0 <= v220 && v220 < 2l);
                            long v222;
                            v222 = 544l * v220;
                            long v223;
                            v223 = v222 + v217;
                            long v224;
                            v224 = 4l * v218;
                            long v225;
                            v225 = v224 + v223;
                            float v226;
                            v226 = v44[v225];
                            bool v227;
                            v227 = 0l <= v220;
                            bool v229;
                            if (v227){
                                bool v228;
                                v228 = v220 < 2l;
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
                            bool v232;
                            v232 = 0l <= v218;
                            bool v234;
                            if (v232){
                                bool v233;
                                v233 = v218 < 2l;
                                v234 = v233;
                            } else {
                                v234 = false;
                            }
                            bool v235;
                            v235 = v234 == false;
                            if (v235){
                                assert("The indices should be inside the range of the dimension." && v234);
                            } else {
                            }
                            long v237;
                            v237 = v218 * 2l;
                            long v238;
                            v238 = v220 + v237;
                            v214.x[v238] = wmma::__float_to_tf32(v226);
                            v220 += 1l ;
                        }
                        v218 += 1l ;
                    }
                    v210 += 1l ;
                }
                v208 += 1l ;
            }
            long v239;
            v239 = 0l;
            #pragma unroll
            while (while_method_2(v239)){
                long v241;
                v241 = 0l;
                #pragma unroll
                while (while_method_1(v241)){
                    assert("Tensor range check" && 0 <= v239 && v239 < 1l);
                    assert("Tensor range check" && 0 <= v241 && v241 < 8l);
                    long v243;
                    v243 = 8l * v239;
                    long v244;
                    v244 = v243 + v241;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v245 = v207[v244];
                    assert("Tensor range check" && 0 <= v239 && v239 < 1l);
                    long v246;
                    v246 = 1088l * v239;
                    assert("Tensor range check" && 0 <= v241 && v241 < 8l);
                    long v247;
                    v247 = 8l * v241;
                    long v248;
                    v248 = v247 + v246;
                    long v249;
                    v249 = 0l;
                    #pragma unroll
                    while (while_method_5(v249)){
                        long v251;
                        v251 = 0l;
                        #pragma unroll
                        while (while_method_5(v251)){
                            assert("Tensor range check" && 0 <= v249 && v249 < 2l);
                            assert("Tensor range check" && 0 <= v251 && v251 < 2l);
                            long v253;
                            v253 = 4l * v251;
                            long v254;
                            v254 = v253 + v248;
                            long v255;
                            v255 = 544l * v249;
                            long v256;
                            v256 = v255 + v254;
                            float v257;
                            v257 = v60[v256];
                            bool v258;
                            v258 = 0l <= v251;
                            bool v260;
                            if (v258){
                                bool v259;
                                v259 = v251 < 2l;
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
                            bool v263;
                            v263 = 0l <= v249;
                            bool v265;
                            if (v263){
                                bool v264;
                                v264 = v249 < 2l;
                                v265 = v264;
                            } else {
                                v265 = false;
                            }
                            bool v266;
                            v266 = v265 == false;
                            if (v266){
                                assert("The indices should be inside the range of the dimension." && v265);
                            } else {
                            }
                            long v268;
                            v268 = v249 * 2l;
                            long v269;
                            v269 = v251 + v268;
                            v245.x[v269] = wmma::__float_to_tf32(v257);
                            v251 += 1l ;
                        }
                        v249 += 1l ;
                    }
                    v241 += 1l ;
                }
                v239 += 1l ;
            }
            v3.consumer_release();
            __syncthreads();
            switch (v136.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    long v270 = v136.v.case1.v0;
                    assert("Tensor range check" && 0 <= v67 && v67 < 64l);
                    long v271;
                    v271 = 524288l * v67;
                    assert("Tensor range check" && 0 <= v270 && v270 < 64l);
                    long v272;
                    v272 = 64l * v270;
                    long v273;
                    v273 = v272 + v271;
                    float * v276;
                    float * v274;
                    v274 = v0+v273;
                    v276 = v274;
                    assert("Tensor range check" && 0 <= v65 && v65 < 64l);
                    long v277;
                    v277 = 524288l * v65;
                    assert("Tensor range check" && 0 <= v270 && v270 < 64l);
                    long v278;
                    v278 = v272 + v277;
                    float * v281;
                    float * v279;
                    v279 = v1+v278;
                    v281 = v279;
                    long v282;
                    v282 = threadIdx.x;
                    long v283;
                    v283 = v282 % 16l;
                    long v284;
                    v284 = v282 / 16l;
                    long v285;
                    v285 = v284 % 32l;
                    long v286;
                    v286 = v284 / 32l;
                    bool v287;
                    v287 = v286 == 0l;
                    bool v288;
                    v288 = v287 == false;
                    if (v288){
                        assert("The index has to be in the range of the dimension." && v287);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v285 && v285 < 32l);
                    assert("Tensor range check" && 0 <= v283 && v283 < 16l);
                    long v290;
                    v290 = 4l * v283;
                    long v291;
                    v291 = 68l * v285;
                    long v292;
                    v292 = v291 + v290;
                    long v293;
                    v293 = 4096l * v285;
                    long v294;
                    v294 = v293 + v290;
                    float * v297;
                    float * v295;
                    v295 = v10+v292;
                    v297 = v295;
                    float * v300;
                    float * v298;
                    v298 = v281+v294;
                    v300 = v298;
                    long v301;
                    v301 = 0l;
                    #pragma unroll
                    while (while_method_3(v301)){
                        long v303;
                        v303 = 0l;
                        #pragma unroll
                        while (while_method_2(v303)){
                            assert("Tensor range check" && 0 <= v301 && v301 < 4l);
                            assert("Tensor range check" && 0 <= v303 && v303 < 1l);
                            long v305;
                            v305 = 64l * v303;
                            long v306;
                            v306 = 2176l * v301;
                            long v307;
                            v307 = v306 + v305;
                            long v308;
                            v308 = 131072l * v301;
                            long v309;
                            v309 = v308 + v305;
                            v3.producer_acquire();
                            constexpr long v310 = sizeof(float) * 4l;
                            assert("Pointer alignment check" && (unsigned long long)(v300 + v309) % v310 == 0 && (unsigned long long)(v297 + v307) % v310 == 0);
                            cuda::memcpy_async(v297 + v307, v300 + v309, cuda::aligned_size_t<v310>(v310), v3);
                            v3.producer_commit();
                            v303 += 1l ;
                        }
                        v301 += 1l ;
                    }
                    long v311;
                    v311 = threadIdx.x;
                    long v312;
                    v312 = v311 % 16l;
                    long v313;
                    v313 = v311 / 16l;
                    long v314;
                    v314 = v313 % 32l;
                    long v315;
                    v315 = v313 / 32l;
                    bool v316;
                    v316 = v315 == 0l;
                    bool v317;
                    v317 = v316 == false;
                    if (v317){
                        assert("The index has to be in the range of the dimension." && v316);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v314 && v314 < 32l);
                    assert("Tensor range check" && 0 <= v312 && v312 < 16l);
                    long v319;
                    v319 = 4l * v312;
                    long v320;
                    v320 = 68l * v314;
                    long v321;
                    v321 = v320 + v319;
                    long v322;
                    v322 = 4096l * v314;
                    long v323;
                    v323 = v322 + v319;
                    float * v326;
                    float * v324;
                    v324 = v7+v321;
                    v326 = v324;
                    float * v329;
                    float * v327;
                    v327 = v276+v323;
                    v329 = v327;
                    long v330;
                    v330 = 0l;
                    #pragma unroll
                    while (while_method_3(v330)){
                        long v332;
                        v332 = 0l;
                        #pragma unroll
                        while (while_method_2(v332)){
                            assert("Tensor range check" && 0 <= v330 && v330 < 4l);
                            assert("Tensor range check" && 0 <= v332 && v332 < 1l);
                            long v334;
                            v334 = 64l * v332;
                            long v335;
                            v335 = 2176l * v330;
                            long v336;
                            v336 = v335 + v334;
                            long v337;
                            v337 = 131072l * v330;
                            long v338;
                            v338 = v337 + v334;
                            v3.producer_acquire();
                            constexpr long v339 = sizeof(float) * 4l;
                            assert("Pointer alignment check" && (unsigned long long)(v329 + v338) % v339 == 0 && (unsigned long long)(v326 + v336) % v339 == 0);
                            cuda::memcpy_async(v326 + v336, v329 + v338, cuda::aligned_size_t<v339>(v339), v3);
                            v3.producer_commit();
                            v332 += 1l ;
                        }
                        v330 += 1l ;
                    }
                }
            }
            long v340;
            v340 = 0l;
            #pragma unroll
            while (while_method_3(v340)){
                long v342;
                v342 = 0l;
                #pragma unroll
                while (while_method_2(v342)){
                    long v344;
                    v344 = 0l;
                    #pragma unroll
                    while (while_method_1(v344)){
                        assert("Tensor range check" && 0 <= v340 && v340 < 4l);
                        assert("Tensor range check" && 0 <= v342 && v342 < 1l);
                        long v346;
                        v346 = v340 + v342;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v347 = v61[v346];
                        assert("Tensor range check" && 0 <= v340 && v340 < 4l);
                        assert("Tensor range check" && 0 <= v344 && v344 < 8l);
                        long v348;
                        v348 = 8l * v340;
                        long v349;
                        v349 = v348 + v344;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v350 = v206[v349];
                        assert("Tensor range check" && 0 <= v342 && v342 < 1l);
                        assert("Tensor range check" && 0 <= v344 && v344 < 8l);
                        long v351;
                        v351 = 8l * v342;
                        long v352;
                        v352 = v351 + v344;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v353 = v207[v352];
                        wmma::mma_sync(v347, v350, v353, v347);
                        v344 += 1l ;
                    }
                    v342 += 1l ;
                }
                v340 += 1l ;
            }
            // Poping the loop unrolling to: 0
            bool v354;
            v354 = false;
            v118 = v122;
            v119 = v123;
            v120 = v354;
        }
        // Pushing the loop unrolling to: 0
        long v355;
        v355 = 0l;
        #pragma unroll
        while (while_method_3(v355)){
            long v357;
            v357 = 0l;
            #pragma unroll
            while (while_method_2(v357)){
                assert("Tensor range check" && 0 <= v355 && v355 < 4l);
                assert("Tensor range check" && 0 <= v357 && v357 < 1l);
                long v359;
                v359 = v355 + v357;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v360 = v61[v359];
                assert("Tensor range check" && 0 <= v355 && v355 < 4l);
                assert("Tensor range check" && 0 <= v357 && v357 < 1l);
                long v361;
                v361 = 16l * v357;
                long v362;
                v362 = 2176l * v355;
                long v363;
                v363 = v362 + v361;
                float * v364;
                v364 = v28 + v363;
                wmma::store_matrix_sync(v364, v360, 136l, wmma::mem_row_major);
                v357 += 1l ;
            }
            v355 += 1l ;
        }
        __syncthreads();
        long v365;
        v365 = threadIdx.x;
        long v366;
        v366 = v365 % 32l;
        long v367;
        v367 = v365 / 32l;
        long v368;
        v368 = v367 % 16l;
        long v369;
        v369 = v367 / 16l;
        bool v370;
        v370 = v369 == 0l;
        bool v371;
        v371 = v370 == false;
        if (v371){
            assert("The index has to be in the range of the dimension." && v370);
        } else {
        }
        assert("Tensor range check" && 0 <= v368 && v368 < 16l);
        assert("Tensor range check" && 0 <= v366 && v366 < 32l);
        long v373;
        v373 = 4l * v366;
        long v374;
        v374 = 8192l * v368;
        long v375;
        v375 = v374 + v373;
        long v376;
        v376 = 136l * v368;
        long v377;
        v377 = v376 + v373;
        float * v380;
        float * v378;
        v378 = v77+v375;
        v380 = v378;
        float * v383;
        float * v381;
        v381 = v13+v377;
        v383 = v381;
        long v384;
        v384 = 0l;
        #pragma unroll
        while (while_method_1(v384)){
            long v386;
            v386 = 0l;
            #pragma unroll
            while (while_method_2(v386)){
                assert("Tensor range check" && 0 <= v384 && v384 < 8l);
                assert("Tensor range check" && 0 <= v386 && v386 < 1l);
                long v388;
                v388 = 128l * v386;
                long v389;
                v389 = 131072l * v384;
                long v390;
                v390 = v389 + v388;
                long v391;
                v391 = 2176l * v384;
                long v392;
                v392 = v391 + v388;
                int4* v393;
                v393 = reinterpret_cast<int4*>(v383 + v392);
                int4* v394;
                v394 = reinterpret_cast<int4*>(v380 + v390);
                assert("Pointer alignment check" && (unsigned long long)(v393) % 4l == 0 && (unsigned long long)(v394) % 4l == 0);
                *v394 = *v393;
                v386 += 1l ;
            }
            v384 += 1l ;
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
