kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <assert.h>
#include <mma.h>
using namespace nvcuda;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 16l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
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
    long v15;
    v15 = v14 % 8l;
    long v16;
    v16 = v14 / 8l;
    long v17;
    v17 = v16 % 1l;
    bool v18;
    v18 = v16 == 0l;
    bool v19;
    v19 = v18 == false;
    if (v19){
        assert("The index has to be in the range of the dimension." && v18);
    } else {
    }
    assert("Tensor range check" && 0 <= v17 && v17 < 1l);
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v21;
    v21 = 16l * v15;
    long v22;
    v22 = 17408l * v17;
    long v23;
    v23 = v22 + v21;
    float * v26;
    float * v24;
    v24 = v12+v23;
    v26 = v24;
    assert("Tensor range check" && 0 <= v17 && v17 < 1l);
    long v27;
    v27 = 8704l * v17;
    long v28;
    v28 = threadIdx.x;
    long v29;
    v29 = v28 % 32l;
    long v30;
    v30 = v29 % 4l;
    long v31;
    v31 = v29 / 4l;
    long v32;
    v32 = v31 % 8l;
    long v33;
    v33 = v31 / 8l;
    bool v34;
    v34 = v33 == 0l;
    bool v35;
    v35 = v34 == false;
    if (v35){
        assert("The index has to be in the range of the dimension." && v34);
    } else {
    }
    assert("Tensor range check" && 0 <= v32 && v32 < 8l);
    assert("Tensor range check" && 0 <= v30 && v30 < 4l);
    long v37;
    v37 = v30 + v27;
    long v38;
    v38 = 68l * v32;
    long v39;
    v39 = v38 + v37;
    float * v42;
    float * v40;
    v40 = v6+v39;
    v42 = v40;
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v43;
    v43 = 1088l * v15;
    long v44;
    v44 = threadIdx.x;
    long v45;
    v45 = v44 % 32l;
    long v46;
    v46 = v45 % 4l;
    long v47;
    v47 = v45 / 4l;
    long v48;
    v48 = v47 % 8l;
    long v49;
    v49 = v47 / 8l;
    bool v50;
    v50 = v49 == 0l;
    bool v51;
    v51 = v50 == false;
    if (v51){
        assert("The index has to be in the range of the dimension." && v50);
    } else {
    }
    assert("Tensor range check" && 0 <= v48 && v48 < 8l);
    assert("Tensor range check" && 0 <= v46 && v46 < 4l);
    long v53;
    v53 = v46 + v43;
    long v54;
    v54 = 68l * v48;
    long v55;
    v55 = v54 + v53;
    float * v58;
    float * v56;
    v56 = v9+v55;
    v58 = v56;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v59[8l];
    long v60;
    v60 = blockIdx.x;
    long v61;
    v61 = v60;
    while (while_method_0(v61)){
        long v63;
        v63 = v61 % 4l;
        long v64;
        v64 = v61 / 4l;
        long v65;
        v65 = v64 % 4l;
        long v66;
        v66 = v64 / 4l;
        bool v67;
        v67 = v66 == 0l;
        bool v68;
        v68 = v67 == false;
        if (v68){
            assert("The index has to be in the range of the dimension." && v67);
        } else {
        }
        assert("Tensor range check" && 0 <= v65 && v65 < 4l);
        assert("Tensor range check" && 0 <= v63 && v63 < 4l);
        long v70;
        v70 = 128l * v63;
        long v71;
        v71 = 65536l * v65;
        long v72;
        v72 = v71 + v70;
        float * v75;
        float * v73;
        v73 = v2+v72;
        v75 = v73;
        // Pushing the loop unrolling to: 0
        long v76;
        v76 = threadIdx.x;
        long v77;
        v77 = v76 % 32l;
        long v78;
        v78 = v76 / 32l;
        long v79;
        v79 = v78 % 8l;
        long v80;
        v80 = v78 / 8l;
        bool v81;
        v81 = v80 == 0l;
        bool v82;
        v82 = v81 == false;
        if (v82){
            assert("The index has to be in the range of the dimension." && v81);
        } else {
        }
        assert("Tensor range check" && 0 <= v79 && v79 < 8l);
        assert("Tensor range check" && 0 <= v77 && v77 < 32l);
        long v84;
        v84 = 4l * v77;
        long v85;
        v85 = 2176l * v79;
        long v86;
        v86 = v85 + v84;
        long v87;
        v87 = 8192l * v79;
        long v88;
        v88 = v87 + v84;
        float * v91;
        float * v89;
        v89 = v12+v86;
        v91 = v89;
        float * v94;
        float * v92;
        v92 = v75+v88;
        v94 = v92;
        long v95;
        v95 = 0l;
        #pragma unroll
        while (while_method_0(v95)){
            long v97;
            v97 = 0l;
            #pragma unroll
            while (while_method_1(v97)){
                assert("Tensor range check" && 0 <= v95 && v95 < 16l);
                assert("Tensor range check" && 0 <= v97 && v97 < 1l);
                long v99;
                v99 = 4l * v97;
                long v100;
                v100 = 136l * v95;
                long v101;
                v101 = v100 + v99;
                long v102;
                v102 = 512l * v95;
                long v103;
                v103 = v102 + v99;
                int4* v104;
                v104 = reinterpret_cast<int4*>(v94 + v103);
                int4* v105;
                v105 = reinterpret_cast<int4*>(v91 + v101);
                assert("Pointer alignment check" && (unsigned long long)(v104) % 4l == 0 && (unsigned long long)(v105) % 4l == 0);
                *v105 = *v104;
                v97 += 1l ;
            }
            v95 += 1l ;
        }
        __syncthreads();
        long v106;
        v106 = 0l;
        #pragma unroll
        while (while_method_2(v106)){
            long v108;
            v108 = 0l;
            #pragma unroll
            while (while_method_1(v108)){
                assert("Tensor range check" && 0 <= v106 && v106 < 8l);
                assert("Tensor range check" && 0 <= v108 && v108 < 1l);
                long v110;
                v110 = v106 + v108;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v111 = v59[v110];
                assert("Tensor range check" && 0 <= v106 && v106 < 8l);
                assert("Tensor range check" && 0 <= v108 && v108 < 1l);
                long v112;
                v112 = 16l * v108;
                long v113;
                v113 = 2176l * v106;
                long v114;
                v114 = v113 + v112;
                float * v115;
                v115 = v26 + v114;
                wmma::load_matrix_sync(v111, v115, 136l, wmma::mem_row_major);
                v108 += 1l ;
            }
            v106 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        long v116;
        v116 = 0l;
        while (while_method_2(v116)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v65 && v65 < 4l);
            assert("Tensor range check" && 0 <= v116 && v116 < 8l);
            long v118;
            v118 = 64l * v116;
            long v119;
            v119 = v118 + v71;
            float * v122;
            float * v120;
            v120 = v0+v119;
            v122 = v120;
            assert("Tensor range check" && 0 <= v63 && v63 < 4l);
            long v123;
            v123 = 65536l * v63;
            assert("Tensor range check" && 0 <= v116 && v116 < 8l);
            long v124;
            v124 = v118 + v123;
            float * v127;
            float * v125;
            v125 = v1+v124;
            v127 = v125;
            long v128;
            v128 = threadIdx.x;
            long v129;
            v129 = v128 % 16l;
            long v130;
            v130 = v128 / 16l;
            long v131;
            v131 = v130 % 16l;
            long v132;
            v132 = v130 / 16l;
            bool v133;
            v133 = v132 == 0l;
            bool v134;
            v134 = v133 == false;
            if (v134){
                assert("The index has to be in the range of the dimension." && v133);
            } else {
            }
            assert("Tensor range check" && 0 <= v131 && v131 < 16l);
            assert("Tensor range check" && 0 <= v129 && v129 < 16l);
            long v136;
            v136 = 4l * v129;
            long v137;
            v137 = 544l * v131;
            long v138;
            v138 = v137 + v136;
            long v139;
            v139 = 4096l * v131;
            long v140;
            v140 = v139 + v136;
            float * v143;
            float * v141;
            v141 = v9+v138;
            v143 = v141;
            float * v146;
            float * v144;
            v144 = v127+v140;
            v146 = v144;
            long v147;
            v147 = 0l;
            #pragma unroll
            while (while_method_2(v147)){
                long v149;
                v149 = 0l;
                #pragma unroll
                while (while_method_1(v149)){
                    assert("Tensor range check" && 0 <= v147 && v147 < 8l);
                    assert("Tensor range check" && 0 <= v149 && v149 < 1l);
                    long v151;
                    v151 = 4l * v149;
                    long v152;
                    v152 = 68l * v147;
                    long v153;
                    v153 = v152 + v151;
                    long v154;
                    v154 = 512l * v147;
                    long v155;
                    v155 = v154 + v151;
                    int4* v156;
                    v156 = reinterpret_cast<int4*>(v146 + v155);
                    int4* v157;
                    v157 = reinterpret_cast<int4*>(v143 + v153);
                    assert("Pointer alignment check" && (unsigned long long)(v156) % 4l == 0 && (unsigned long long)(v157) % 4l == 0);
                    *v157 = *v156;
                    v149 += 1l ;
                }
                v147 += 1l ;
            }
            long v158;
            v158 = threadIdx.x;
            long v159;
            v159 = v158 % 16l;
            long v160;
            v160 = v158 / 16l;
            long v161;
            v161 = v160 % 16l;
            long v162;
            v162 = v160 / 16l;
            bool v163;
            v163 = v162 == 0l;
            bool v164;
            v164 = v163 == false;
            if (v164){
                assert("The index has to be in the range of the dimension." && v163);
            } else {
            }
            assert("Tensor range check" && 0 <= v161 && v161 < 16l);
            assert("Tensor range check" && 0 <= v159 && v159 < 16l);
            long v166;
            v166 = 4l * v159;
            long v167;
            v167 = 544l * v161;
            long v168;
            v168 = v167 + v166;
            long v169;
            v169 = 4096l * v161;
            long v170;
            v170 = v169 + v166;
            float * v173;
            float * v171;
            v171 = v6+v168;
            v173 = v171;
            float * v176;
            float * v174;
            v174 = v122+v170;
            v176 = v174;
            long v177;
            v177 = 0l;
            #pragma unroll
            while (while_method_2(v177)){
                long v179;
                v179 = 0l;
                #pragma unroll
                while (while_method_1(v179)){
                    assert("Tensor range check" && 0 <= v177 && v177 < 8l);
                    assert("Tensor range check" && 0 <= v179 && v179 < 1l);
                    long v181;
                    v181 = 4l * v179;
                    long v182;
                    v182 = 68l * v177;
                    long v183;
                    v183 = v182 + v181;
                    long v184;
                    v184 = 512l * v177;
                    long v185;
                    v185 = v184 + v181;
                    int4* v186;
                    v186 = reinterpret_cast<int4*>(v176 + v185);
                    int4* v187;
                    v187 = reinterpret_cast<int4*>(v173 + v183);
                    assert("Pointer alignment check" && (unsigned long long)(v186) % 4l == 0 && (unsigned long long)(v187) % 4l == 0);
                    *v187 = *v186;
                    v179 += 1l ;
                }
                v177 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v188[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v189[8l];
            long v190;
            v190 = 0l;
            #pragma unroll
            while (while_method_2(v190)){
                long v192;
                v192 = 0l;
                #pragma unroll
                while (while_method_2(v192)){
                    assert("Tensor range check" && 0 <= v190 && v190 < 8l);
                    long v194;
                    v194 = 1088l * v190;
                    assert("Tensor range check" && 0 <= v192 && v192 < 8l);
                    long v195;
                    v195 = 8l * v192;
                    long v196;
                    v196 = v195 + v194;
                    assert("Tensor range check" && 0 <= v190 && v190 < 8l);
                    assert("Tensor range check" && 0 <= v192 && v192 < 8l);
                    long v197;
                    v197 = 8l * v190;
                    long v198;
                    v198 = v197 + v192;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v199 = v188[v198];
                    long v200;
                    v200 = 0l;
                    #pragma unroll
                    while (while_method_3(v200)){
                        long v202;
                        v202 = 0l;
                        #pragma unroll
                        while (while_method_3(v202)){
                            assert("Tensor range check" && 0 <= v200 && v200 < 2l);
                            assert("Tensor range check" && 0 <= v202 && v202 < 2l);
                            long v204;
                            v204 = 4l * v202;
                            long v205;
                            v205 = v204 + v196;
                            long v206;
                            v206 = 544l * v200;
                            long v207;
                            v207 = v206 + v205;
                            float v208;
                            v208 = v42[v207];
                            bool v209;
                            v209 = 0l <= v202;
                            bool v211;
                            if (v209){
                                bool v210;
                                v210 = v202 < 2l;
                                v211 = v210;
                            } else {
                                v211 = false;
                            }
                            bool v212;
                            v212 = v211 == false;
                            if (v212){
                                assert("The indices should be inside the range of the dimension." && v211);
                            } else {
                            }
                            bool v214;
                            v214 = 0l <= v200;
                            bool v216;
                            if (v214){
                                bool v215;
                                v215 = v200 < 2l;
                                v216 = v215;
                            } else {
                                v216 = false;
                            }
                            bool v217;
                            v217 = v216 == false;
                            if (v217){
                                assert("The indices should be inside the range of the dimension." && v216);
                            } else {
                            }
                            long v219;
                            v219 = v200 * 2l;
                            long v220;
                            v220 = v202 + v219;
                            v199.x[v220] = wmma::__float_to_tf32(v208);
                            v202 += 1l ;
                        }
                        v200 += 1l ;
                    }
                    v192 += 1l ;
                }
                v190 += 1l ;
            }
            long v221;
            v221 = 0l;
            #pragma unroll
            while (while_method_1(v221)){
                long v223;
                v223 = 0l;
                #pragma unroll
                while (while_method_2(v223)){
                    assert("Tensor range check" && 0 <= v221 && v221 < 1l);
                    long v225;
                    v225 = 1088l * v221;
                    assert("Tensor range check" && 0 <= v223 && v223 < 8l);
                    long v226;
                    v226 = 8l * v223;
                    long v227;
                    v227 = v226 + v225;
                    assert("Tensor range check" && 0 <= v221 && v221 < 1l);
                    assert("Tensor range check" && 0 <= v223 && v223 < 8l);
                    long v228;
                    v228 = 8l * v221;
                    long v229;
                    v229 = v228 + v223;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v230 = v189[v229];
                    long v231;
                    v231 = 0l;
                    #pragma unroll
                    while (while_method_3(v231)){
                        long v233;
                        v233 = 0l;
                        #pragma unroll
                        while (while_method_3(v233)){
                            assert("Tensor range check" && 0 <= v231 && v231 < 2l);
                            assert("Tensor range check" && 0 <= v233 && v233 < 2l);
                            long v235;
                            v235 = 4l * v233;
                            long v236;
                            v236 = v235 + v227;
                            long v237;
                            v237 = 544l * v231;
                            long v238;
                            v238 = v237 + v236;
                            float v239;
                            v239 = v58[v238];
                            bool v240;
                            v240 = 0l <= v233;
                            bool v242;
                            if (v240){
                                bool v241;
                                v241 = v233 < 2l;
                                v242 = v241;
                            } else {
                                v242 = false;
                            }
                            bool v243;
                            v243 = v242 == false;
                            if (v243){
                                assert("The indices should be inside the range of the dimension." && v242);
                            } else {
                            }
                            bool v245;
                            v245 = 0l <= v231;
                            bool v247;
                            if (v245){
                                bool v246;
                                v246 = v231 < 2l;
                                v247 = v246;
                            } else {
                                v247 = false;
                            }
                            bool v248;
                            v248 = v247 == false;
                            if (v248){
                                assert("The indices should be inside the range of the dimension." && v247);
                            } else {
                            }
                            long v250;
                            v250 = v231 * 2l;
                            long v251;
                            v251 = v233 + v250;
                            v230.x[v251] = wmma::__float_to_tf32(v239);
                            v233 += 1l ;
                        }
                        v231 += 1l ;
                    }
                    v223 += 1l ;
                }
                v221 += 1l ;
            }
            long v252;
            v252 = 0l;
            #pragma unroll
            while (while_method_2(v252)){
                long v254;
                v254 = 0l;
                #pragma unroll
                while (while_method_1(v254)){
                    long v256;
                    v256 = 0l;
                    #pragma unroll
                    while (while_method_2(v256)){
                        assert("Tensor range check" && 0 <= v252 && v252 < 8l);
                        assert("Tensor range check" && 0 <= v254 && v254 < 1l);
                        long v258;
                        v258 = v252 + v254;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v259 = v59[v258];
                        assert("Tensor range check" && 0 <= v252 && v252 < 8l);
                        assert("Tensor range check" && 0 <= v256 && v256 < 8l);
                        long v260;
                        v260 = 8l * v252;
                        long v261;
                        v261 = v260 + v256;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v262 = v188[v261];
                        assert("Tensor range check" && 0 <= v254 && v254 < 1l);
                        assert("Tensor range check" && 0 <= v256 && v256 < 8l);
                        long v263;
                        v263 = 8l * v254;
                        long v264;
                        v264 = v263 + v256;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v265 = v189[v264];
                        wmma::mma_sync(v259, v262, v265, v259);
                        v256 += 1l ;
                    }
                    v254 += 1l ;
                }
                v252 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v116 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v266;
        v266 = threadIdx.x;
        long v267;
        v267 = v266 % 32l;
        long v268;
        v268 = v266 / 32l;
        long v269;
        v269 = v268 % 8l;
        long v270;
        v270 = v268 / 8l;
        bool v271;
        v271 = v270 == 0l;
        bool v272;
        v272 = v271 == false;
        if (v272){
            assert("The index has to be in the range of the dimension." && v271);
        } else {
        }
        assert("Tensor range check" && 0 <= v269 && v269 < 8l);
        assert("Tensor range check" && 0 <= v267 && v267 < 32l);
        long v274;
        v274 = 4l * v267;
        long v275;
        v275 = 2176l * v269;
        long v276;
        v276 = v275 + v274;
        long v277;
        v277 = 8192l * v269;
        long v278;
        v278 = v277 + v274;
        float * v281;
        float * v279;
        v279 = v12+v276;
        v281 = v279;
        float * v284;
        float * v282;
        v282 = v75+v278;
        v284 = v282;
        long v285;
        v285 = 0l;
        #pragma unroll
        while (while_method_0(v285)){
            long v287;
            v287 = 0l;
            #pragma unroll
            while (while_method_1(v287)){
                assert("Tensor range check" && 0 <= v285 && v285 < 16l);
                assert("Tensor range check" && 0 <= v287 && v287 < 1l);
                long v289;
                v289 = 4l * v287;
                long v290;
                v290 = 136l * v285;
                long v291;
                v291 = v290 + v289;
                long v292;
                v292 = 512l * v285;
                long v293;
                v293 = v292 + v289;
                int4* v294;
                v294 = reinterpret_cast<int4*>(v284 + v293);
                int4* v295;
                v295 = reinterpret_cast<int4*>(v281 + v291);
                assert("Pointer alignment check" && (unsigned long long)(v294) % 4l == 0 && (unsigned long long)(v295) % 4l == 0);
                *v295 = *v294;
                v287 += 1l ;
            }
            v285 += 1l ;
        }
        __syncthreads();
        long v296;
        v296 = 0l;
        #pragma unroll
        while (while_method_2(v296)){
            long v298;
            v298 = 0l;
            #pragma unroll
            while (while_method_1(v298)){
                assert("Tensor range check" && 0 <= v296 && v296 < 8l);
                assert("Tensor range check" && 0 <= v298 && v298 < 1l);
                long v300;
                v300 = v296 + v298;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v301 = v59[v300];
                assert("Tensor range check" && 0 <= v296 && v296 < 8l);
                assert("Tensor range check" && 0 <= v298 && v298 < 1l);
                long v302;
                v302 = 16l * v298;
                long v303;
                v303 = 2176l * v296;
                long v304;
                v304 = v303 + v302;
                float * v305;
                v305 = v26 + v304;
                wmma::store_matrix_sync(v305, v301, 136l, wmma::mem_row_major);
                v298 += 1l ;
            }
            v296 += 1l ;
        }
        __syncthreads();
        long v306;
        v306 = threadIdx.x;
        long v307;
        v307 = v306 % 32l;
        long v308;
        v308 = v306 / 32l;
        long v309;
        v309 = v308 % 8l;
        long v310;
        v310 = v308 / 8l;
        bool v311;
        v311 = v310 == 0l;
        bool v312;
        v312 = v311 == false;
        if (v312){
            assert("The index has to be in the range of the dimension." && v311);
        } else {
        }
        assert("Tensor range check" && 0 <= v309 && v309 < 8l);
        assert("Tensor range check" && 0 <= v307 && v307 < 32l);
        long v314;
        v314 = 4l * v307;
        long v315;
        v315 = 8192l * v309;
        long v316;
        v316 = v315 + v314;
        long v317;
        v317 = 2176l * v309;
        long v318;
        v318 = v317 + v314;
        float * v321;
        float * v319;
        v319 = v75+v316;
        v321 = v319;
        float * v324;
        float * v322;
        v322 = v12+v318;
        v324 = v322;
        long v325;
        v325 = 0l;
        #pragma unroll
        while (while_method_0(v325)){
            long v327;
            v327 = 0l;
            #pragma unroll
            while (while_method_1(v327)){
                assert("Tensor range check" && 0 <= v325 && v325 < 16l);
                assert("Tensor range check" && 0 <= v327 && v327 < 1l);
                long v329;
                v329 = 4l * v327;
                long v330;
                v330 = 512l * v325;
                long v331;
                v331 = v330 + v329;
                long v332;
                v332 = 136l * v325;
                long v333;
                v333 = v332 + v329;
                int4* v334;
                v334 = reinterpret_cast<int4*>(v324 + v333);
                int4* v335;
                v335 = reinterpret_cast<int4*>(v321 + v331);
                assert("Pointer alignment check" && (unsigned long long)(v334) % 4l == 0 && (unsigned long long)(v335) % 4l == 0);
                *v335 = *v334;
                v327 += 1l ;
            }
            v325 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v61 += 24l ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550')
options.append('--dopt=on')
options.append('--restrict')
options.append('-D__CUDA_NO_HALF_CONVERSIONS__')
options.append('--ptxas-options=-v')
options.append('--device-debug')
options.append('--generate-line-info')
raw_module = cp.RawModule(code=kernel, backend='nvcc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
    del v0
    return v1
def main():
    v0 = cp.zeros(262144,dtype=cp.float32)
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
    v5 = cp.zeros(262144,dtype=cp.float32)
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
    v10 = cp.zeros(262144,dtype=cp.float32)
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
        v18 = 0
        v19 = raw_module.get_function(f"entry{v18}")
        del v18
        v19.max_dynamic_shared_size_bytes = 69632 
        v19((24,),(256,),(v10, v5, v0),shared_mem=69632)
        del v19
        v16 = v16
        v15 += 1 
    del v0, v5, v10, v15
    return v16

if __name__ == '__main__': print(main())
