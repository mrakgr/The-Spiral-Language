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
__device__ inline bool while_method_5(long v0){
    bool v1;
    v1 = v0 < 2l;
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
    long v30;
    v30 = threadIdx.x;
    long v31;
    v31 = v30 % 32l;
    bool v32;
    v32 = 0l <= v31;
    bool v33;
    v33 = v32 == false;
    if (v33){
        assert("The index needs to be zero or positive." && v32);
    } else {
    }
    long v35;
    v35 = v31 % 4l;
    long v36;
    v36 = v31 / 4l;
    bool v37;
    v37 = v36 < 8l;
    bool v38;
    v38 = v37 == false;
    if (v38){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v37);
    } else {
    }
    assert("Tensor range check" && 0 <= v36 && v36 < 8l);
    assert("Tensor range check" && 0 <= v35 && v35 < 4l);
    long v40;
    v40 = v35 + v29;
    long v41;
    v41 = 68l * v36;
    long v42;
    v42 = v41 + v40;
    float * v45;
    float * v43;
    v43 = v6+v42;
    v45 = v43;
    assert("Tensor range check" && 0 <= v18 && v18 < 8l);
    long v46;
    v46 = 1088l * v18;
    long v47;
    v47 = threadIdx.x;
    long v48;
    v48 = v47 % 32l;
    bool v49;
    v49 = 0l <= v48;
    bool v50;
    v50 = v49 == false;
    if (v50){
        assert("The index needs to be zero or positive." && v49);
    } else {
    }
    long v52;
    v52 = v48 % 4l;
    long v53;
    v53 = v48 / 4l;
    bool v54;
    v54 = v53 < 8l;
    bool v55;
    v55 = v54 == false;
    if (v55){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v54);
    } else {
    }
    assert("Tensor range check" && 0 <= v53 && v53 < 8l);
    assert("Tensor range check" && 0 <= v52 && v52 < 4l);
    long v57;
    v57 = v52 + v46;
    long v58;
    v58 = 68l * v53;
    long v59;
    v59 = v58 + v57;
    float * v62;
    float * v60;
    v60 = v9+v59;
    v62 = v60;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v63[4l];
    long v64;
    v64 = blockIdx.x;
    long v65;
    v65 = v64;
    while (while_method_0(v65)){
        bool v67;
        v67 = 0l <= v65;
        bool v68;
        v68 = v67 == false;
        if (v68){
            assert("The index needs to be zero or positive." && v67);
        } else {
        }
        long v70;
        v70 = v65 % 64l;
        long v71;
        v71 = v65 / 64l;
        bool v72;
        v72 = v71 < 64l;
        bool v73;
        v73 = v72 == false;
        if (v73){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v72);
        } else {
        }
        assert("Tensor range check" && 0 <= v71 && v71 < 64l);
        assert("Tensor range check" && 0 <= v70 && v70 < 64l);
        long v75;
        v75 = 128l * v70;
        long v76;
        v76 = 1048576l * v71;
        long v77;
        v77 = v76 + v75;
        float * v80;
        float * v78;
        v78 = v2+v77;
        v80 = v78;
        // Pushing the loop unrolling to: 0
        long v81;
        v81 = threadIdx.x;
        bool v82;
        v82 = 0l <= v81;
        bool v83;
        v83 = v82 == false;
        if (v83){
            assert("The index needs to be zero or positive." && v82);
        } else {
        }
        long v85;
        v85 = v81 % 32l;
        long v86;
        v86 = v81 / 32l;
        bool v87;
        v87 = v86 < 16l;
        bool v88;
        v88 = v87 == false;
        if (v88){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v87);
        } else {
        }
        assert("Tensor range check" && 0 <= v86 && v86 < 16l);
        assert("Tensor range check" && 0 <= v85 && v85 < 32l);
        long v90;
        v90 = 4l * v85;
        long v91;
        v91 = 136l * v86;
        long v92;
        v92 = v91 + v90;
        long v93;
        v93 = 8192l * v86;
        long v94;
        v94 = v93 + v90;
        float * v97;
        float * v95;
        v95 = v12+v92;
        v97 = v95;
        float * v100;
        float * v98;
        v98 = v80+v94;
        v100 = v98;
        long v101;
        v101 = 0l;
        #pragma unroll
        while (while_method_1(v101)){
            long v103;
            v103 = 0l;
            #pragma unroll
            while (while_method_2(v103)){
                assert("Tensor range check" && 0 <= v101 && v101 < 8l);
                assert("Tensor range check" && 0 <= v103 && v103 < 1l);
                long v105;
                v105 = 128l * v103;
                long v106;
                v106 = 2176l * v101;
                long v107;
                v107 = v106 + v105;
                long v108;
                v108 = 131072l * v101;
                long v109;
                v109 = v108 + v105;
                int4* v110;
                v110 = reinterpret_cast<int4*>(v100 + v109);
                int4* v111;
                v111 = reinterpret_cast<int4*>(v97 + v107);
                assert("Pointer alignment check" && (unsigned long long)(v110) % 4l == 0 && (unsigned long long)(v111) % 4l == 0);
                *v111 = *v110;
                v103 += 1l ;
            }
            v101 += 1l ;
        }
        __syncthreads();
        long v112;
        v112 = 0l;
        #pragma unroll
        while (while_method_3(v112)){
            long v114;
            v114 = 0l;
            #pragma unroll
            while (while_method_2(v114)){
                assert("Tensor range check" && 0 <= v112 && v112 < 4l);
                assert("Tensor range check" && 0 <= v114 && v114 < 1l);
                long v116;
                v116 = v112 + v114;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v117 = v63[v116];
                assert("Tensor range check" && 0 <= v112 && v112 < 4l);
                assert("Tensor range check" && 0 <= v114 && v114 < 1l);
                long v118;
                v118 = 16l * v114;
                long v119;
                v119 = 2176l * v112;
                long v120;
                v120 = v119 + v118;
                float * v121;
                v121 = v28 + v120;
                wmma::load_matrix_sync(v117, v121, 136l, wmma::mem_row_major);
                v114 += 1l ;
            }
            v112 += 1l ;
        }
        __syncthreads();
        long v122;
        v122 = 0l;
        #pragma unroll
        while (while_method_4(v122)){
            assert("Tensor range check" && 0 <= v71 && v71 < 64l);
            long v124;
            v124 = 524288l * v71;
            assert("Tensor range check" && 0 <= v122 && v122 < 64l);
            long v125;
            v125 = 64l * v122;
            long v126;
            v126 = v125 + v124;
            float * v129;
            float * v127;
            v127 = v0+v126;
            v129 = v127;
            assert("Tensor range check" && 0 <= v70 && v70 < 64l);
            long v130;
            v130 = 524288l * v70;
            assert("Tensor range check" && 0 <= v122 && v122 < 64l);
            long v131;
            v131 = v125 + v130;
            float * v134;
            float * v132;
            v132 = v1+v131;
            v134 = v132;
            long v135;
            v135 = threadIdx.x;
            bool v136;
            v136 = 0l <= v135;
            bool v137;
            v137 = v136 == false;
            if (v137){
                assert("The index needs to be zero or positive." && v136);
            } else {
            }
            long v139;
            v139 = v135 % 16l;
            long v140;
            v140 = v135 / 16l;
            bool v141;
            v141 = v140 < 32l;
            bool v142;
            v142 = v141 == false;
            if (v142){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v141);
            } else {
            }
            assert("Tensor range check" && 0 <= v140 && v140 < 32l);
            assert("Tensor range check" && 0 <= v139 && v139 < 16l);
            long v144;
            v144 = 4l * v139;
            long v145;
            v145 = 68l * v140;
            long v146;
            v146 = v145 + v144;
            long v147;
            v147 = 4096l * v140;
            long v148;
            v148 = v147 + v144;
            float * v151;
            float * v149;
            v149 = v9+v146;
            v151 = v149;
            float * v154;
            float * v152;
            v152 = v134+v148;
            v154 = v152;
            long v155;
            v155 = 0l;
            #pragma unroll
            while (while_method_3(v155)){
                long v157;
                v157 = 0l;
                #pragma unroll
                while (while_method_2(v157)){
                    assert("Tensor range check" && 0 <= v155 && v155 < 4l);
                    assert("Tensor range check" && 0 <= v157 && v157 < 1l);
                    long v159;
                    v159 = 64l * v157;
                    long v160;
                    v160 = 2176l * v155;
                    long v161;
                    v161 = v160 + v159;
                    long v162;
                    v162 = 131072l * v155;
                    long v163;
                    v163 = v162 + v159;
                    float v164[4l];
                    long v165;
                    v165 = 0l;
                    #pragma unroll
                    while (while_method_3(v165)){
                        assert("Tensor range check" && 0 <= v165 && v165 < 4l);
                        long v167;
                        v167 = v165 + v163;
                        float v168;
                        v168 = v154[v167];
                        float v169;
                        v169 = wmma::__float_to_tf32(v168);
                        assert("Tensor range check" && 0 <= v165 && v165 < 4l);
                        v164[v165] = v169;
                        v165 += 1l ;
                    }
                    int4* v170;
                    v170 = reinterpret_cast<int4*>(v164 + 0l);
                    int4* v171;
                    v171 = reinterpret_cast<int4*>(v151 + v161);
                    assert("Pointer alignment check" && (unsigned long long)(v170) % 4l == 0 && (unsigned long long)(v171) % 4l == 0);
                    *v171 = *v170;
                    v157 += 1l ;
                }
                v155 += 1l ;
            }
            long v172;
            v172 = threadIdx.x;
            bool v173;
            v173 = 0l <= v172;
            bool v174;
            v174 = v173 == false;
            if (v174){
                assert("The index needs to be zero or positive." && v173);
            } else {
            }
            long v176;
            v176 = v172 % 16l;
            long v177;
            v177 = v172 / 16l;
            bool v178;
            v178 = v177 < 32l;
            bool v179;
            v179 = v178 == false;
            if (v179){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v178);
            } else {
            }
            assert("Tensor range check" && 0 <= v177 && v177 < 32l);
            assert("Tensor range check" && 0 <= v176 && v176 < 16l);
            long v181;
            v181 = 4l * v176;
            long v182;
            v182 = 68l * v177;
            long v183;
            v183 = v182 + v181;
            long v184;
            v184 = 4096l * v177;
            long v185;
            v185 = v184 + v181;
            float * v188;
            float * v186;
            v186 = v6+v183;
            v188 = v186;
            float * v191;
            float * v189;
            v189 = v129+v185;
            v191 = v189;
            long v192;
            v192 = 0l;
            #pragma unroll
            while (while_method_3(v192)){
                long v194;
                v194 = 0l;
                #pragma unroll
                while (while_method_2(v194)){
                    assert("Tensor range check" && 0 <= v192 && v192 < 4l);
                    assert("Tensor range check" && 0 <= v194 && v194 < 1l);
                    long v196;
                    v196 = 64l * v194;
                    long v197;
                    v197 = 2176l * v192;
                    long v198;
                    v198 = v197 + v196;
                    long v199;
                    v199 = 131072l * v192;
                    long v200;
                    v200 = v199 + v196;
                    float v201[4l];
                    long v202;
                    v202 = 0l;
                    #pragma unroll
                    while (while_method_3(v202)){
                        assert("Tensor range check" && 0 <= v202 && v202 < 4l);
                        long v204;
                        v204 = v202 + v200;
                        float v205;
                        v205 = v191[v204];
                        float v206;
                        v206 = wmma::__float_to_tf32(v205);
                        assert("Tensor range check" && 0 <= v202 && v202 < 4l);
                        v201[v202] = v206;
                        v202 += 1l ;
                    }
                    int4* v207;
                    v207 = reinterpret_cast<int4*>(v201 + 0l);
                    int4* v208;
                    v208 = reinterpret_cast<int4*>(v188 + v198);
                    assert("Pointer alignment check" && (unsigned long long)(v207) % 4l == 0 && (unsigned long long)(v208) % 4l == 0);
                    *v208 = *v207;
                    v194 += 1l ;
                }
                v192 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v209[32l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v210[8l];
            long v211;
            v211 = 0l;
            #pragma unroll
            while (while_method_3(v211)){
                long v213;
                v213 = 0l;
                #pragma unroll
                while (while_method_1(v213)){
                    assert("Tensor range check" && 0 <= v211 && v211 < 4l);
                    assert("Tensor range check" && 0 <= v213 && v213 < 8l);
                    long v215;
                    v215 = 8l * v211;
                    long v216;
                    v216 = v215 + v213;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v217 = v209[v216];
                    assert("Tensor range check" && 0 <= v211 && v211 < 4l);
                    long v218;
                    v218 = 1088l * v211;
                    assert("Tensor range check" && 0 <= v213 && v213 < 8l);
                    long v219;
                    v219 = 8l * v213;
                    long v220;
                    v220 = v219 + v218;
                    long v221;
                    v221 = 0l;
                    #pragma unroll
                    while (while_method_5(v221)){
                        long v223;
                        v223 = 0l;
                        #pragma unroll
                        while (while_method_5(v223)){
                            assert("Tensor range check" && 0 <= v221 && v221 < 2l);
                            assert("Tensor range check" && 0 <= v223 && v223 < 2l);
                            long v225;
                            v225 = 544l * v223;
                            long v226;
                            v226 = v225 + v220;
                            long v227;
                            v227 = 4l * v221;
                            long v228;
                            v228 = v227 + v226;
                            float v229;
                            v229 = v45[v228];
                            bool v230;
                            v230 = 0l <= v223;
                            bool v232;
                            if (v230){
                                bool v231;
                                v231 = v223 < 2l;
                                v232 = v231;
                            } else {
                                v232 = false;
                            }
                            bool v233;
                            v233 = v232 == false;
                            if (v233){
                                assert("The indices should be inside the range of the dimension." && v232);
                            } else {
                            }
                            bool v235;
                            v235 = 0l <= v221;
                            bool v237;
                            if (v235){
                                bool v236;
                                v236 = v221 < 2l;
                                v237 = v236;
                            } else {
                                v237 = false;
                            }
                            bool v238;
                            v238 = v237 == false;
                            if (v238){
                                assert("The indices should be inside the range of the dimension." && v237);
                            } else {
                            }
                            long v240;
                            v240 = v221 * 2l;
                            long v241;
                            v241 = v223 + v240;
                            v217.x[v241] = v229;
                            v223 += 1l ;
                        }
                        v221 += 1l ;
                    }
                    v213 += 1l ;
                }
                v211 += 1l ;
            }
            long v242;
            v242 = 0l;
            #pragma unroll
            while (while_method_2(v242)){
                long v244;
                v244 = 0l;
                #pragma unroll
                while (while_method_1(v244)){
                    assert("Tensor range check" && 0 <= v242 && v242 < 1l);
                    assert("Tensor range check" && 0 <= v244 && v244 < 8l);
                    long v246;
                    v246 = 8l * v242;
                    long v247;
                    v247 = v246 + v244;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v248 = v210[v247];
                    assert("Tensor range check" && 0 <= v242 && v242 < 1l);
                    long v249;
                    v249 = 1088l * v242;
                    assert("Tensor range check" && 0 <= v244 && v244 < 8l);
                    long v250;
                    v250 = 8l * v244;
                    long v251;
                    v251 = v250 + v249;
                    long v252;
                    v252 = 0l;
                    #pragma unroll
                    while (while_method_5(v252)){
                        long v254;
                        v254 = 0l;
                        #pragma unroll
                        while (while_method_5(v254)){
                            assert("Tensor range check" && 0 <= v252 && v252 < 2l);
                            assert("Tensor range check" && 0 <= v254 && v254 < 2l);
                            long v256;
                            v256 = 4l * v254;
                            long v257;
                            v257 = v256 + v251;
                            long v258;
                            v258 = 544l * v252;
                            long v259;
                            v259 = v258 + v257;
                            float v260;
                            v260 = v62[v259];
                            bool v261;
                            v261 = 0l <= v254;
                            bool v263;
                            if (v261){
                                bool v262;
                                v262 = v254 < 2l;
                                v263 = v262;
                            } else {
                                v263 = false;
                            }
                            bool v264;
                            v264 = v263 == false;
                            if (v264){
                                assert("The indices should be inside the range of the dimension." && v263);
                            } else {
                            }
                            bool v266;
                            v266 = 0l <= v252;
                            bool v268;
                            if (v266){
                                bool v267;
                                v267 = v252 < 2l;
                                v268 = v267;
                            } else {
                                v268 = false;
                            }
                            bool v269;
                            v269 = v268 == false;
                            if (v269){
                                assert("The indices should be inside the range of the dimension." && v268);
                            } else {
                            }
                            long v271;
                            v271 = v252 * 2l;
                            long v272;
                            v272 = v254 + v271;
                            v248.x[v272] = v260;
                            v254 += 1l ;
                        }
                        v252 += 1l ;
                    }
                    v244 += 1l ;
                }
                v242 += 1l ;
            }
            __syncthreads();
            long v273;
            v273 = 0l;
            #pragma unroll
            while (while_method_3(v273)){
                long v275;
                v275 = 0l;
                #pragma unroll
                while (while_method_2(v275)){
                    long v277;
                    v277 = 0l;
                    #pragma unroll
                    while (while_method_1(v277)){
                        assert("Tensor range check" && 0 <= v273 && v273 < 4l);
                        assert("Tensor range check" && 0 <= v275 && v275 < 1l);
                        long v279;
                        v279 = v273 + v275;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v280 = v63[v279];
                        assert("Tensor range check" && 0 <= v273 && v273 < 4l);
                        assert("Tensor range check" && 0 <= v277 && v277 < 8l);
                        long v281;
                        v281 = 8l * v273;
                        long v282;
                        v282 = v281 + v277;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v283 = v209[v282];
                        assert("Tensor range check" && 0 <= v275 && v275 < 1l);
                        assert("Tensor range check" && 0 <= v277 && v277 < 8l);
                        long v284;
                        v284 = 8l * v275;
                        long v285;
                        v285 = v284 + v277;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v286 = v210[v285];
                        wmma::mma_sync(v280, v283, v286, v280);
                        v277 += 1l ;
                    }
                    v275 += 1l ;
                }
                v273 += 1l ;
            }
            v122 += 1l ;
        }
        long v287;
        v287 = 0l;
        #pragma unroll
        while (while_method_3(v287)){
            long v289;
            v289 = 0l;
            #pragma unroll
            while (while_method_2(v289)){
                assert("Tensor range check" && 0 <= v287 && v287 < 4l);
                assert("Tensor range check" && 0 <= v289 && v289 < 1l);
                long v291;
                v291 = v287 + v289;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v292 = v63[v291];
                assert("Tensor range check" && 0 <= v287 && v287 < 4l);
                assert("Tensor range check" && 0 <= v289 && v289 < 1l);
                long v293;
                v293 = 16l * v289;
                long v294;
                v294 = 2176l * v287;
                long v295;
                v295 = v294 + v293;
                float * v296;
                v296 = v28 + v295;
                wmma::store_matrix_sync(v296, v292, 136l, wmma::mem_row_major);
                v289 += 1l ;
            }
            v287 += 1l ;
        }
        __syncthreads();
        long v297;
        v297 = threadIdx.x;
        bool v298;
        v298 = 0l <= v297;
        bool v299;
        v299 = v298 == false;
        if (v299){
            assert("The index needs to be zero or positive." && v298);
        } else {
        }
        long v301;
        v301 = v297 % 32l;
        long v302;
        v302 = v297 / 32l;
        bool v303;
        v303 = v302 < 16l;
        bool v304;
        v304 = v303 == false;
        if (v304){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v303);
        } else {
        }
        assert("Tensor range check" && 0 <= v302 && v302 < 16l);
        assert("Tensor range check" && 0 <= v301 && v301 < 32l);
        long v306;
        v306 = 4l * v301;
        long v307;
        v307 = 8192l * v302;
        long v308;
        v308 = v307 + v306;
        long v309;
        v309 = 136l * v302;
        long v310;
        v310 = v309 + v306;
        float * v313;
        float * v311;
        v311 = v80+v308;
        v313 = v311;
        float * v316;
        float * v314;
        v314 = v12+v310;
        v316 = v314;
        long v317;
        v317 = 0l;
        #pragma unroll
        while (while_method_1(v317)){
            long v319;
            v319 = 0l;
            #pragma unroll
            while (while_method_2(v319)){
                assert("Tensor range check" && 0 <= v317 && v317 < 8l);
                assert("Tensor range check" && 0 <= v319 && v319 < 1l);
                long v321;
                v321 = 128l * v319;
                long v322;
                v322 = 131072l * v317;
                long v323;
                v323 = v322 + v321;
                long v324;
                v324 = 2176l * v317;
                long v325;
                v325 = v324 + v321;
                int4* v326;
                v326 = reinterpret_cast<int4*>(v316 + v325);
                int4* v327;
                v327 = reinterpret_cast<int4*>(v313 + v323);
                assert("Pointer alignment check" && (unsigned long long)(v326) % 4l == 0 && (unsigned long long)(v327) % 4l == 0);
                *v327 = *v326;
                v319 += 1l ;
            }
            v317 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v65 += 24l ;
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
