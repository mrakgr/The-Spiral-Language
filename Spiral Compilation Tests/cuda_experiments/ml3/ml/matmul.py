kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 64l;
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
    v64 = 0l;
    while (while_method_0(v64)){
        long v66;
        v66 = 0l;
        while (while_method_0(v66)){
            assert("Tensor range check" && 0 <= v64 && v64 < 64l);
            assert("Tensor range check" && 0 <= v66 && v66 < 64l);
            long v68;
            v68 = 128l * v66;
            long v69;
            v69 = 1048576l * v64;
            long v70;
            v70 = v69 + v68;
            float * v73;
            float * v71;
            v71 = v2+v70;
            v73 = v71;
            // Pushing the loop unrolling to: 0
            long v74;
            v74 = threadIdx.x;
            bool v75;
            v75 = 0l <= v74;
            bool v76;
            v76 = v75 == false;
            if (v76){
                assert("The index needs to be zero or positive." && v75);
            } else {
            }
            long v78;
            v78 = v74 % 32l;
            long v79;
            v79 = v74 / 32l;
            bool v80;
            v80 = v79 < 16l;
            bool v81;
            v81 = v80 == false;
            if (v81){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v80);
            } else {
            }
            assert("Tensor range check" && 0 <= v79 && v79 < 16l);
            assert("Tensor range check" && 0 <= v78 && v78 < 32l);
            long v83;
            v83 = 4l * v78;
            long v84;
            v84 = 136l * v79;
            long v85;
            v85 = v84 + v83;
            long v86;
            v86 = 8192l * v79;
            long v87;
            v87 = v86 + v83;
            float * v90;
            float * v88;
            v88 = v12+v85;
            v90 = v88;
            float * v93;
            float * v91;
            v91 = v73+v87;
            v93 = v91;
            long v94;
            v94 = 0l;
            #pragma unroll
            while (while_method_1(v94)){
                long v96;
                v96 = 0l;
                #pragma unroll
                while (while_method_2(v96)){
                    assert("Tensor range check" && 0 <= v94 && v94 < 8l);
                    assert("Tensor range check" && 0 <= v96 && v96 < 1l);
                    long v98;
                    v98 = 128l * v96;
                    long v99;
                    v99 = 2176l * v94;
                    long v100;
                    v100 = v99 + v98;
                    long v101;
                    v101 = 131072l * v94;
                    long v102;
                    v102 = v101 + v98;
                    int4* v103;
                    v103 = reinterpret_cast<int4*>(v93 + v102);
                    int4* v104;
                    v104 = reinterpret_cast<int4*>(v90 + v100);
                    assert("Pointer alignment check" && (unsigned long long)(v103) % 4l == 0 && (unsigned long long)(v104) % 4l == 0);
                    *v104 = *v103;
                    v96 += 1l ;
                }
                v94 += 1l ;
            }
            __syncthreads();
            long v105;
            v105 = 0l;
            #pragma unroll
            while (while_method_3(v105)){
                long v107;
                v107 = 0l;
                #pragma unroll
                while (while_method_2(v107)){
                    assert("Tensor range check" && 0 <= v105 && v105 < 4l);
                    assert("Tensor range check" && 0 <= v107 && v107 < 1l);
                    long v109;
                    v109 = v105 + v107;
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v110 = v63[v109];
                    assert("Tensor range check" && 0 <= v105 && v105 < 4l);
                    assert("Tensor range check" && 0 <= v107 && v107 < 1l);
                    long v111;
                    v111 = 16l * v107;
                    long v112;
                    v112 = 2176l * v105;
                    long v113;
                    v113 = v112 + v111;
                    float * v114;
                    v114 = v28 + v113;
                    wmma::load_matrix_sync(v110, v114, 136l, wmma::mem_row_major);
                    v107 += 1l ;
                }
                v105 += 1l ;
            }
            __syncthreads();
            long v115;
            v115 = 0l;
            #pragma unroll
            while (while_method_0(v115)){
                assert("Tensor range check" && 0 <= v64 && v64 < 64l);
                long v117;
                v117 = 524288l * v64;
                assert("Tensor range check" && 0 <= v115 && v115 < 64l);
                long v118;
                v118 = 64l * v115;
                long v119;
                v119 = v118 + v117;
                float * v122;
                float * v120;
                v120 = v0+v119;
                v122 = v120;
                assert("Tensor range check" && 0 <= v66 && v66 < 64l);
                long v123;
                v123 = 524288l * v66;
                assert("Tensor range check" && 0 <= v115 && v115 < 64l);
                long v124;
                v124 = v118 + v123;
                float * v127;
                float * v125;
                v125 = v1+v124;
                v127 = v125;
                long v128;
                v128 = threadIdx.x;
                bool v129;
                v129 = 0l <= v128;
                bool v130;
                v130 = v129 == false;
                if (v130){
                    assert("The index needs to be zero or positive." && v129);
                } else {
                }
                long v132;
                v132 = v128 % 16l;
                long v133;
                v133 = v128 / 16l;
                bool v134;
                v134 = v133 < 32l;
                bool v135;
                v135 = v134 == false;
                if (v135){
                    assert("The last element of the projection dimensions needs to be greater than the index remainder." && v134);
                } else {
                }
                assert("Tensor range check" && 0 <= v133 && v133 < 32l);
                assert("Tensor range check" && 0 <= v132 && v132 < 16l);
                long v137;
                v137 = 4l * v132;
                long v138;
                v138 = 68l * v133;
                long v139;
                v139 = v138 + v137;
                long v140;
                v140 = 4096l * v133;
                long v141;
                v141 = v140 + v137;
                float * v144;
                float * v142;
                v142 = v9+v139;
                v144 = v142;
                float * v147;
                float * v145;
                v145 = v127+v141;
                v147 = v145;
                long v148;
                v148 = 0l;
                #pragma unroll
                while (while_method_3(v148)){
                    long v150;
                    v150 = 0l;
                    #pragma unroll
                    while (while_method_2(v150)){
                        assert("Tensor range check" && 0 <= v148 && v148 < 4l);
                        assert("Tensor range check" && 0 <= v150 && v150 < 1l);
                        long v152;
                        v152 = 64l * v150;
                        long v153;
                        v153 = 2176l * v148;
                        long v154;
                        v154 = v153 + v152;
                        long v155;
                        v155 = 131072l * v148;
                        long v156;
                        v156 = v155 + v152;
                        float v157[4l];
                        long v158;
                        v158 = 0l;
                        #pragma unroll
                        while (while_method_3(v158)){
                            assert("Tensor range check" && 0 <= v158 && v158 < 4l);
                            long v160;
                            v160 = v158 + v156;
                            float v161;
                            v161 = v147[v160];
                            float v162;
                            v162 = wmma::__float_to_tf32(v161);
                            assert("Tensor range check" && 0 <= v158 && v158 < 4l);
                            v157[v158] = v162;
                            v158 += 1l ;
                        }
                        int4* v163;
                        v163 = reinterpret_cast<int4*>(v157 + 0l);
                        int4* v164;
                        v164 = reinterpret_cast<int4*>(v144 + v154);
                        assert("Pointer alignment check" && (unsigned long long)(v163) % 4l == 0 && (unsigned long long)(v164) % 4l == 0);
                        *v164 = *v163;
                        v150 += 1l ;
                    }
                    v148 += 1l ;
                }
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
                v169 = v165 % 16l;
                long v170;
                v170 = v165 / 16l;
                bool v171;
                v171 = v170 < 32l;
                bool v172;
                v172 = v171 == false;
                if (v172){
                    assert("The last element of the projection dimensions needs to be greater than the index remainder." && v171);
                } else {
                }
                assert("Tensor range check" && 0 <= v170 && v170 < 32l);
                assert("Tensor range check" && 0 <= v169 && v169 < 16l);
                long v174;
                v174 = 4l * v169;
                long v175;
                v175 = 68l * v170;
                long v176;
                v176 = v175 + v174;
                long v177;
                v177 = 4096l * v170;
                long v178;
                v178 = v177 + v174;
                float * v181;
                float * v179;
                v179 = v6+v176;
                v181 = v179;
                float * v184;
                float * v182;
                v182 = v122+v178;
                v184 = v182;
                long v185;
                v185 = 0l;
                #pragma unroll
                while (while_method_3(v185)){
                    long v187;
                    v187 = 0l;
                    #pragma unroll
                    while (while_method_2(v187)){
                        assert("Tensor range check" && 0 <= v185 && v185 < 4l);
                        assert("Tensor range check" && 0 <= v187 && v187 < 1l);
                        long v189;
                        v189 = 64l * v187;
                        long v190;
                        v190 = 2176l * v185;
                        long v191;
                        v191 = v190 + v189;
                        long v192;
                        v192 = 131072l * v185;
                        long v193;
                        v193 = v192 + v189;
                        float v194[4l];
                        long v195;
                        v195 = 0l;
                        #pragma unroll
                        while (while_method_3(v195)){
                            assert("Tensor range check" && 0 <= v195 && v195 < 4l);
                            long v197;
                            v197 = v195 + v193;
                            float v198;
                            v198 = v184[v197];
                            float v199;
                            v199 = wmma::__float_to_tf32(v198);
                            assert("Tensor range check" && 0 <= v195 && v195 < 4l);
                            v194[v195] = v199;
                            v195 += 1l ;
                        }
                        int4* v200;
                        v200 = reinterpret_cast<int4*>(v194 + 0l);
                        int4* v201;
                        v201 = reinterpret_cast<int4*>(v181 + v191);
                        assert("Pointer alignment check" && (unsigned long long)(v200) % 4l == 0 && (unsigned long long)(v201) % 4l == 0);
                        *v201 = *v200;
                        v187 += 1l ;
                    }
                    v185 += 1l ;
                }
                __syncthreads();
                wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v202[32l];
                wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v203[8l];
                long v204;
                v204 = 0l;
                #pragma unroll
                while (while_method_3(v204)){
                    long v206;
                    v206 = 0l;
                    #pragma unroll
                    while (while_method_1(v206)){
                        assert("Tensor range check" && 0 <= v204 && v204 < 4l);
                        assert("Tensor range check" && 0 <= v206 && v206 < 8l);
                        long v208;
                        v208 = 8l * v204;
                        long v209;
                        v209 = v208 + v206;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v210 = v202[v209];
                        assert("Tensor range check" && 0 <= v204 && v204 < 4l);
                        long v211;
                        v211 = 1088l * v204;
                        assert("Tensor range check" && 0 <= v206 && v206 < 8l);
                        long v212;
                        v212 = 8l * v206;
                        long v213;
                        v213 = v212 + v211;
                        long v214;
                        v214 = 0l;
                        #pragma unroll
                        while (while_method_4(v214)){
                            long v216;
                            v216 = 0l;
                            #pragma unroll
                            while (while_method_4(v216)){
                                assert("Tensor range check" && 0 <= v214 && v214 < 2l);
                                assert("Tensor range check" && 0 <= v216 && v216 < 2l);
                                long v218;
                                v218 = 544l * v216;
                                long v219;
                                v219 = v218 + v213;
                                long v220;
                                v220 = 4l * v214;
                                long v221;
                                v221 = v220 + v219;
                                float v222;
                                v222 = v45[v221];
                                bool v223;
                                v223 = 0l <= v216;
                                bool v225;
                                if (v223){
                                    bool v224;
                                    v224 = v216 < 2l;
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
                                bool v228;
                                v228 = 0l <= v214;
                                bool v230;
                                if (v228){
                                    bool v229;
                                    v229 = v214 < 2l;
                                    v230 = v229;
                                } else {
                                    v230 = false;
                                }
                                bool v231;
                                v231 = v230 == false;
                                if (v231){
                                    assert("The indices should be inside the range of the dimension." && v230);
                                } else {
                                }
                                long v233;
                                v233 = v214 * 2l;
                                long v234;
                                v234 = v216 + v233;
                                v210.x[v234] = v222;
                                v216 += 1l ;
                            }
                            v214 += 1l ;
                        }
                        v206 += 1l ;
                    }
                    v204 += 1l ;
                }
                long v235;
                v235 = 0l;
                #pragma unroll
                while (while_method_2(v235)){
                    long v237;
                    v237 = 0l;
                    #pragma unroll
                    while (while_method_1(v237)){
                        assert("Tensor range check" && 0 <= v235 && v235 < 1l);
                        assert("Tensor range check" && 0 <= v237 && v237 < 8l);
                        long v239;
                        v239 = 8l * v235;
                        long v240;
                        v240 = v239 + v237;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v241 = v203[v240];
                        assert("Tensor range check" && 0 <= v235 && v235 < 1l);
                        long v242;
                        v242 = 1088l * v235;
                        assert("Tensor range check" && 0 <= v237 && v237 < 8l);
                        long v243;
                        v243 = 8l * v237;
                        long v244;
                        v244 = v243 + v242;
                        long v245;
                        v245 = 0l;
                        #pragma unroll
                        while (while_method_4(v245)){
                            long v247;
                            v247 = 0l;
                            #pragma unroll
                            while (while_method_4(v247)){
                                assert("Tensor range check" && 0 <= v245 && v245 < 2l);
                                assert("Tensor range check" && 0 <= v247 && v247 < 2l);
                                long v249;
                                v249 = 4l * v247;
                                long v250;
                                v250 = v249 + v244;
                                long v251;
                                v251 = 544l * v245;
                                long v252;
                                v252 = v251 + v250;
                                float v253;
                                v253 = v62[v252];
                                bool v254;
                                v254 = 0l <= v247;
                                bool v256;
                                if (v254){
                                    bool v255;
                                    v255 = v247 < 2l;
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
                                bool v259;
                                v259 = 0l <= v245;
                                bool v261;
                                if (v259){
                                    bool v260;
                                    v260 = v245 < 2l;
                                    v261 = v260;
                                } else {
                                    v261 = false;
                                }
                                bool v262;
                                v262 = v261 == false;
                                if (v262){
                                    assert("The indices should be inside the range of the dimension." && v261);
                                } else {
                                }
                                long v264;
                                v264 = v245 * 2l;
                                long v265;
                                v265 = v247 + v264;
                                v241.x[v265] = v253;
                                v247 += 1l ;
                            }
                            v245 += 1l ;
                        }
                        v237 += 1l ;
                    }
                    v235 += 1l ;
                }
                __syncthreads();
                long v266;
                v266 = 0l;
                #pragma unroll
                while (while_method_3(v266)){
                    long v268;
                    v268 = 0l;
                    #pragma unroll
                    while (while_method_2(v268)){
                        long v270;
                        v270 = 0l;
                        #pragma unroll
                        while (while_method_1(v270)){
                            assert("Tensor range check" && 0 <= v266 && v266 < 4l);
                            assert("Tensor range check" && 0 <= v268 && v268 < 1l);
                            long v272;
                            v272 = v266 + v268;
                            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v273 = v63[v272];
                            assert("Tensor range check" && 0 <= v266 && v266 < 4l);
                            assert("Tensor range check" && 0 <= v270 && v270 < 8l);
                            long v274;
                            v274 = 8l * v266;
                            long v275;
                            v275 = v274 + v270;
                            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v276 = v202[v275];
                            assert("Tensor range check" && 0 <= v268 && v268 < 1l);
                            assert("Tensor range check" && 0 <= v270 && v270 < 8l);
                            long v277;
                            v277 = 8l * v268;
                            long v278;
                            v278 = v277 + v270;
                            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v279 = v203[v278];
                            wmma::mma_sync(v273, v276, v279, v273);
                            v270 += 1l ;
                        }
                        v268 += 1l ;
                    }
                    v266 += 1l ;
                }
                v115 += 1l ;
            }
            long v280;
            v280 = 0l;
            #pragma unroll
            while (while_method_3(v280)){
                long v282;
                v282 = 0l;
                #pragma unroll
                while (while_method_2(v282)){
                    assert("Tensor range check" && 0 <= v280 && v280 < 4l);
                    assert("Tensor range check" && 0 <= v282 && v282 < 1l);
                    long v284;
                    v284 = v280 + v282;
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v285 = v63[v284];
                    assert("Tensor range check" && 0 <= v280 && v280 < 4l);
                    assert("Tensor range check" && 0 <= v282 && v282 < 1l);
                    long v286;
                    v286 = 16l * v282;
                    long v287;
                    v287 = 2176l * v280;
                    long v288;
                    v288 = v287 + v286;
                    float * v289;
                    v289 = v28 + v288;
                    wmma::store_matrix_sync(v289, v285, 136l, wmma::mem_row_major);
                    v282 += 1l ;
                }
                v280 += 1l ;
            }
            __syncthreads();
            long v290;
            v290 = threadIdx.x;
            bool v291;
            v291 = 0l <= v290;
            bool v292;
            v292 = v291 == false;
            if (v292){
                assert("The index needs to be zero or positive." && v291);
            } else {
            }
            long v294;
            v294 = v290 % 32l;
            long v295;
            v295 = v290 / 32l;
            bool v296;
            v296 = v295 < 16l;
            bool v297;
            v297 = v296 == false;
            if (v297){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v296);
            } else {
            }
            assert("Tensor range check" && 0 <= v295 && v295 < 16l);
            assert("Tensor range check" && 0 <= v294 && v294 < 32l);
            long v299;
            v299 = 4l * v294;
            long v300;
            v300 = 8192l * v295;
            long v301;
            v301 = v300 + v299;
            long v302;
            v302 = 136l * v295;
            long v303;
            v303 = v302 + v299;
            float * v306;
            float * v304;
            v304 = v73+v301;
            v306 = v304;
            float * v309;
            float * v307;
            v307 = v12+v303;
            v309 = v307;
            long v310;
            v310 = 0l;
            #pragma unroll
            while (while_method_1(v310)){
                long v312;
                v312 = 0l;
                #pragma unroll
                while (while_method_2(v312)){
                    assert("Tensor range check" && 0 <= v310 && v310 < 8l);
                    assert("Tensor range check" && 0 <= v312 && v312 < 1l);
                    long v314;
                    v314 = 128l * v312;
                    long v315;
                    v315 = 131072l * v310;
                    long v316;
                    v316 = v315 + v314;
                    long v317;
                    v317 = 2176l * v310;
                    long v318;
                    v318 = v317 + v314;
                    int4* v319;
                    v319 = reinterpret_cast<int4*>(v309 + v318);
                    int4* v320;
                    v320 = reinterpret_cast<int4*>(v306 + v316);
                    assert("Pointer alignment check" && (unsigned long long)(v319) % 4l == 0 && (unsigned long long)(v320) % 4l == 0);
                    *v320 = *v319;
                    v312 += 1l ;
                }
                v310 += 1l ;
            }
            __syncthreads();
            // Poping the loop unrolling to: 0
            v66 += 1l ;
        }
        v64 += 1l ;
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
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def main():
    v0 = cp.random.normal(0.0,1.0,67108864,dtype=cp.float32)
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
    v5 = cp.random.normal(0.0,1.0,33554432,dtype=cp.float32)
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
    v10 = cp.random.normal(0.0,1.0,33554432,dtype=cp.float32)
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
    v15 = v10.reshape((8192, 4096))
    v16 = v5.reshape((8192, 4096))
    v17 = cp.transpose(v16)
    del v16
    v18 = v0.reshape((8192, 8192))
    v19 = (cp.matmul(v15,v17) + v18).flatten()
    del v15, v17, v18
    v20 = v19.size
    v21 = 67108864 == v20
    del v20
    v22 = v21 == False
    if v22:
        v23 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v21, v23
        del v23
    else:
        pass
    del v21, v22
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),512,is_print=True)
    v24 = 0
    v25 = raw_module.get_function(f"entry{v24}")
    del v24
    v25.max_dynamic_shared_size_bytes = 69632 
    v25((1,),(512,),(v10, v5, v0),shared_mem=69632)
    del v5, v10, v25
    v26 = cp.max(cp.abs(v0-v19))
    del v0, v19
    return v26

if __name__ == '__main__': print(main())
