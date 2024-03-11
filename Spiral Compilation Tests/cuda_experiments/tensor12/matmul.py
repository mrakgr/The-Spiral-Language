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
    v17 = v16 % 4l;
    long v18;
    v18 = v16 / 4l;
    bool v19;
    v19 = v18 == 0l;
    bool v20;
    v20 = v19 == false;
    if (v20){
        assert("The index has to be in the range of the dimension." && v19);
    } else {
    }
    assert("Tensor range check" && 0 <= v17 && v17 < 4l);
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v22;
    v22 = 16l * v15;
    long v23;
    v23 = 4352l * v17;
    long v24;
    v24 = v23 + v22;
    float * v27;
    float * v25;
    v25 = v12+v24;
    v27 = v25;
    assert("Tensor range check" && 0 <= v17 && v17 < 4l);
    long v28;
    v28 = 2176l * v17;
    long v29;
    v29 = threadIdx.x;
    long v30;
    v30 = v29 % 32l;
    long v31;
    v31 = v30 % 4l;
    long v32;
    v32 = v30 / 4l;
    long v33;
    v33 = v32 % 8l;
    long v34;
    v34 = v32 / 8l;
    bool v35;
    v35 = v34 == 0l;
    bool v36;
    v36 = v35 == false;
    if (v36){
        assert("The index has to be in the range of the dimension." && v35);
    } else {
    }
    assert("Tensor range check" && 0 <= v33 && v33 < 8l);
    assert("Tensor range check" && 0 <= v31 && v31 < 4l);
    long v38;
    v38 = v31 + v28;
    long v39;
    v39 = 68l * v33;
    long v40;
    v40 = v39 + v38;
    float * v43;
    float * v41;
    v41 = v6+v40;
    v43 = v41;
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v44;
    v44 = 1088l * v15;
    long v45;
    v45 = threadIdx.x;
    long v46;
    v46 = v45 % 32l;
    long v47;
    v47 = v46 % 4l;
    long v48;
    v48 = v46 / 4l;
    long v49;
    v49 = v48 % 8l;
    long v50;
    v50 = v48 / 8l;
    bool v51;
    v51 = v50 == 0l;
    bool v52;
    v52 = v51 == false;
    if (v52){
        assert("The index has to be in the range of the dimension." && v51);
    } else {
    }
    assert("Tensor range check" && 0 <= v49 && v49 < 8l);
    assert("Tensor range check" && 0 <= v47 && v47 < 4l);
    long v54;
    v54 = v47 + v44;
    long v55;
    v55 = 68l * v49;
    long v56;
    v56 = v55 + v54;
    float * v59;
    float * v57;
    v57 = v9+v56;
    v59 = v57;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v60[2l];
    // Pushing the loop unrolling to: 1
    long v61;
    v61 = blockIdx.x;
    long v62;
    v62 = v61;
    #pragma unroll 1
    while (while_method_0(v62)){
        long v64;
        v64 = v62 % 4l;
        long v65;
        v65 = v62 / 4l;
        long v66;
        v66 = v65 % 4l;
        long v67;
        v67 = v65 / 4l;
        bool v68;
        v68 = v67 == 0l;
        bool v69;
        v69 = v68 == false;
        if (v69){
            assert("The index has to be in the range of the dimension." && v68);
        } else {
        }
        assert("Tensor range check" && 0 <= v66 && v66 < 4l);
        assert("Tensor range check" && 0 <= v64 && v64 < 4l);
        long v71;
        v71 = 128l * v64;
        long v72;
        v72 = 65536l * v66;
        long v73;
        v73 = v72 + v71;
        float * v76;
        float * v74;
        v74 = v2+v73;
        v76 = v74;
        // Pushing the loop unrolling to: 0
        long v77;
        v77 = threadIdx.x;
        long v78;
        v78 = v77 % 32l;
        long v79;
        v79 = v77 / 32l;
        long v80;
        v80 = v79 % 32l;
        long v81;
        v81 = v79 / 32l;
        bool v82;
        v82 = v81 == 0l;
        bool v83;
        v83 = v82 == false;
        if (v83){
            assert("The index has to be in the range of the dimension." && v82);
        } else {
        }
        assert("Tensor range check" && 0 <= v80 && v80 < 32l);
        assert("Tensor range check" && 0 <= v78 && v78 < 32l);
        long v85;
        v85 = 4l * v78;
        long v86;
        v86 = 136l * v80;
        long v87;
        v87 = v86 + v85;
        long v88;
        v88 = 512l * v80;
        long v89;
        v89 = v88 + v85;
        float * v92;
        float * v90;
        v90 = v12+v87;
        v92 = v90;
        float * v95;
        float * v93;
        v93 = v76+v89;
        v95 = v93;
        long v96;
        v96 = 0l;
        #pragma unroll
        while (while_method_1(v96)){
            long v98;
            v98 = 0l;
            #pragma unroll
            while (while_method_2(v98)){
                assert("Tensor range check" && 0 <= v96 && v96 < 4l);
                assert("Tensor range check" && 0 <= v98 && v98 < 1l);
                long v100;
                v100 = 128l * v98;
                long v101;
                v101 = 4352l * v96;
                long v102;
                v102 = v101 + v100;
                long v103;
                v103 = 16384l * v96;
                long v104;
                v104 = v103 + v100;
                int4* v105;
                v105 = reinterpret_cast<int4*>(v95 + v104);
                int4* v106;
                v106 = reinterpret_cast<int4*>(v92 + v102);
                assert("Pointer alignment check" && (unsigned long long)(v105) % 4l == 0 && (unsigned long long)(v106) % 4l == 0);
                *v106 = *v105;
                v98 += 1l ;
            }
            v96 += 1l ;
        }
        __syncthreads();
        long v107;
        v107 = 0l;
        #pragma unroll
        while (while_method_3(v107)){
            long v109;
            v109 = 0l;
            #pragma unroll
            while (while_method_2(v109)){
                assert("Tensor range check" && 0 <= v107 && v107 < 2l);
                assert("Tensor range check" && 0 <= v109 && v109 < 1l);
                long v111;
                v111 = v107 + v109;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v112 = v60[v111];
                assert("Tensor range check" && 0 <= v107 && v107 < 2l);
                assert("Tensor range check" && 0 <= v109 && v109 < 1l);
                long v113;
                v113 = 16l * v109;
                long v114;
                v114 = 2176l * v107;
                long v115;
                v115 = v114 + v113;
                float * v116;
                v116 = v27 + v115;
                wmma::load_matrix_sync(v112, v116, 136l, wmma::mem_row_major);
                v109 += 1l ;
            }
            v107 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        long v117;
        v117 = 0l;
        #pragma unroll 1
        while (while_method_4(v117)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v66 && v66 < 4l);
            assert("Tensor range check" && 0 <= v117 && v117 < 8l);
            long v119;
            v119 = 64l * v117;
            long v120;
            v120 = v119 + v72;
            float * v123;
            float * v121;
            v121 = v0+v120;
            v123 = v121;
            assert("Tensor range check" && 0 <= v64 && v64 < 4l);
            long v124;
            v124 = 65536l * v64;
            assert("Tensor range check" && 0 <= v117 && v117 < 8l);
            long v125;
            v125 = v119 + v124;
            float * v128;
            float * v126;
            v126 = v1+v125;
            v128 = v126;
            long v129;
            v129 = threadIdx.x;
            long v130;
            v130 = v129 % 16l;
            long v131;
            v131 = v129 / 16l;
            long v132;
            v132 = v131 % 64l;
            long v133;
            v133 = v131 / 64l;
            bool v134;
            v134 = v133 == 0l;
            bool v135;
            v135 = v134 == false;
            if (v135){
                assert("The index has to be in the range of the dimension." && v134);
            } else {
            }
            assert("Tensor range check" && 0 <= v132 && v132 < 64l);
            assert("Tensor range check" && 0 <= v130 && v130 < 16l);
            long v137;
            v137 = 4l * v130;
            long v138;
            v138 = 68l * v132;
            long v139;
            v139 = v138 + v137;
            long v140;
            v140 = 512l * v132;
            long v141;
            v141 = v140 + v137;
            float * v144;
            float * v142;
            v142 = v9+v139;
            v144 = v142;
            float * v147;
            float * v145;
            v145 = v128+v141;
            v147 = v145;
            long v148;
            v148 = 0l;
            #pragma unroll
            while (while_method_3(v148)){
                long v150;
                v150 = 0l;
                #pragma unroll
                while (while_method_2(v150)){
                    assert("Tensor range check" && 0 <= v148 && v148 < 2l);
                    assert("Tensor range check" && 0 <= v150 && v150 < 1l);
                    long v152;
                    v152 = 64l * v150;
                    long v153;
                    v153 = 4352l * v148;
                    long v154;
                    v154 = v153 + v152;
                    long v155;
                    v155 = 32768l * v148;
                    long v156;
                    v156 = v155 + v152;
                    int4* v157;
                    v157 = reinterpret_cast<int4*>(v147 + v156);
                    int4* v158;
                    v158 = reinterpret_cast<int4*>(v144 + v154);
                    assert("Pointer alignment check" && (unsigned long long)(v157) % 4l == 0 && (unsigned long long)(v158) % 4l == 0);
                    *v158 = *v157;
                    v150 += 1l ;
                }
                v148 += 1l ;
            }
            long v159;
            v159 = threadIdx.x;
            long v160;
            v160 = v159 % 16l;
            long v161;
            v161 = v159 / 16l;
            long v162;
            v162 = v161 % 64l;
            long v163;
            v163 = v161 / 64l;
            bool v164;
            v164 = v163 == 0l;
            bool v165;
            v165 = v164 == false;
            if (v165){
                assert("The index has to be in the range of the dimension." && v164);
            } else {
            }
            assert("Tensor range check" && 0 <= v162 && v162 < 64l);
            assert("Tensor range check" && 0 <= v160 && v160 < 16l);
            long v167;
            v167 = 4l * v160;
            long v168;
            v168 = 68l * v162;
            long v169;
            v169 = v168 + v167;
            long v170;
            v170 = 512l * v162;
            long v171;
            v171 = v170 + v167;
            float * v174;
            float * v172;
            v172 = v6+v169;
            v174 = v172;
            float * v177;
            float * v175;
            v175 = v123+v171;
            v177 = v175;
            long v178;
            v178 = 0l;
            #pragma unroll
            while (while_method_3(v178)){
                long v180;
                v180 = 0l;
                #pragma unroll
                while (while_method_2(v180)){
                    assert("Tensor range check" && 0 <= v178 && v178 < 2l);
                    assert("Tensor range check" && 0 <= v180 && v180 < 1l);
                    long v182;
                    v182 = 64l * v180;
                    long v183;
                    v183 = 4352l * v178;
                    long v184;
                    v184 = v183 + v182;
                    long v185;
                    v185 = 32768l * v178;
                    long v186;
                    v186 = v185 + v182;
                    int4* v187;
                    v187 = reinterpret_cast<int4*>(v177 + v186);
                    int4* v188;
                    v188 = reinterpret_cast<int4*>(v174 + v184);
                    assert("Pointer alignment check" && (unsigned long long)(v187) % 4l == 0 && (unsigned long long)(v188) % 4l == 0);
                    *v188 = *v187;
                    v180 += 1l ;
                }
                v178 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v189[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v190[8l];
            long v191;
            v191 = 0l;
            #pragma unroll
            while (while_method_3(v191)){
                long v193;
                v193 = 0l;
                #pragma unroll
                while (while_method_4(v193)){
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
                            v209 = v43[v208];
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
                while (while_method_4(v224)){
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
                            v240 = v59[v239];
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
                    while (while_method_4(v257)){
                        assert("Tensor range check" && 0 <= v253 && v253 < 2l);
                        assert("Tensor range check" && 0 <= v255 && v255 < 1l);
                        long v259;
                        v259 = v253 + v255;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v260 = v60[v259];
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
            v117 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v267;
        v267 = threadIdx.x;
        long v268;
        v268 = v267 % 32l;
        long v269;
        v269 = v267 / 32l;
        long v270;
        v270 = v269 % 32l;
        long v271;
        v271 = v269 / 32l;
        bool v272;
        v272 = v271 == 0l;
        bool v273;
        v273 = v272 == false;
        if (v273){
            assert("The index has to be in the range of the dimension." && v272);
        } else {
        }
        assert("Tensor range check" && 0 <= v270 && v270 < 32l);
        assert("Tensor range check" && 0 <= v268 && v268 < 32l);
        long v275;
        v275 = 4l * v268;
        long v276;
        v276 = 136l * v270;
        long v277;
        v277 = v276 + v275;
        long v278;
        v278 = 512l * v270;
        long v279;
        v279 = v278 + v275;
        float * v282;
        float * v280;
        v280 = v12+v277;
        v282 = v280;
        float * v285;
        float * v283;
        v283 = v76+v279;
        v285 = v283;
        long v286;
        v286 = 0l;
        #pragma unroll
        while (while_method_1(v286)){
            long v288;
            v288 = 0l;
            #pragma unroll
            while (while_method_2(v288)){
                assert("Tensor range check" && 0 <= v286 && v286 < 4l);
                assert("Tensor range check" && 0 <= v288 && v288 < 1l);
                long v290;
                v290 = 128l * v288;
                long v291;
                v291 = 4352l * v286;
                long v292;
                v292 = v291 + v290;
                long v293;
                v293 = 16384l * v286;
                long v294;
                v294 = v293 + v290;
                int4* v295;
                v295 = reinterpret_cast<int4*>(v285 + v294);
                int4* v296;
                v296 = reinterpret_cast<int4*>(v282 + v292);
                assert("Pointer alignment check" && (unsigned long long)(v295) % 4l == 0 && (unsigned long long)(v296) % 4l == 0);
                *v296 = *v295;
                v288 += 1l ;
            }
            v286 += 1l ;
        }
        __syncthreads();
        long v297;
        v297 = 0l;
        #pragma unroll
        while (while_method_3(v297)){
            long v299;
            v299 = 0l;
            #pragma unroll
            while (while_method_2(v299)){
                assert("Tensor range check" && 0 <= v297 && v297 < 2l);
                assert("Tensor range check" && 0 <= v299 && v299 < 1l);
                long v301;
                v301 = v297 + v299;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v302 = v60[v301];
                assert("Tensor range check" && 0 <= v297 && v297 < 2l);
                assert("Tensor range check" && 0 <= v299 && v299 < 1l);
                long v303;
                v303 = 16l * v299;
                long v304;
                v304 = 2176l * v297;
                long v305;
                v305 = v304 + v303;
                float * v306;
                v306 = v27 + v305;
                wmma::store_matrix_sync(v306, v302, 136l, wmma::mem_row_major);
                v299 += 1l ;
            }
            v297 += 1l ;
        }
        __syncthreads();
        long v307;
        v307 = threadIdx.x;
        long v308;
        v308 = v307 % 32l;
        long v309;
        v309 = v307 / 32l;
        long v310;
        v310 = v309 % 32l;
        long v311;
        v311 = v309 / 32l;
        bool v312;
        v312 = v311 == 0l;
        bool v313;
        v313 = v312 == false;
        if (v313){
            assert("The index has to be in the range of the dimension." && v312);
        } else {
        }
        assert("Tensor range check" && 0 <= v310 && v310 < 32l);
        assert("Tensor range check" && 0 <= v308 && v308 < 32l);
        long v315;
        v315 = 4l * v308;
        long v316;
        v316 = 512l * v310;
        long v317;
        v317 = v316 + v315;
        long v318;
        v318 = 136l * v310;
        long v319;
        v319 = v318 + v315;
        float * v322;
        float * v320;
        v320 = v76+v317;
        v322 = v320;
        float * v325;
        float * v323;
        v323 = v12+v319;
        v325 = v323;
        long v326;
        v326 = 0l;
        #pragma unroll
        while (while_method_1(v326)){
            long v328;
            v328 = 0l;
            #pragma unroll
            while (while_method_2(v328)){
                assert("Tensor range check" && 0 <= v326 && v326 < 4l);
                assert("Tensor range check" && 0 <= v328 && v328 < 1l);
                long v330;
                v330 = 128l * v328;
                long v331;
                v331 = 16384l * v326;
                long v332;
                v332 = v331 + v330;
                long v333;
                v333 = 4352l * v326;
                long v334;
                v334 = v333 + v330;
                int4* v335;
                v335 = reinterpret_cast<int4*>(v325 + v334);
                int4* v336;
                v336 = reinterpret_cast<int4*>(v322 + v332);
                assert("Pointer alignment check" && (unsigned long long)(v335) % 4l == 0 && (unsigned long long)(v336) % 4l == 0);
                *v336 = *v335;
                v328 += 1l ;
            }
            v326 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v62 += 24l ;
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
            max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),1024,is_print=True)
        else:
            pass
        del v27
        v28 = 0
        v29 = raw_module.get_function(f"entry{v28}")
        del v28
        v29.max_dynamic_shared_size_bytes = 69632 
        v29((24,),(1024,),(v10, v5, v0),shared_mem=69632)
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
