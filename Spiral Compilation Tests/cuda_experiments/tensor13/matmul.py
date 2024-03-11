kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
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
    long v15;
    v15 = v14 % 8l;
    long v16;
    v16 = v14 / 8l;
    long v17;
    v17 = v16 % 2l;
    long v18;
    v18 = v16 / 2l;
    bool v19;
    v19 = v18 == 0l;
    bool v20;
    v20 = v19 == false;
    if (v20){
        assert("The index has to be in the range of the dimension." && v19);
    } else {
    }
    assert("Tensor range check" && 0 <= v17 && v17 < 2l);
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v22;
    v22 = 16l * v15;
    long v23;
    v23 = 8704l * v17;
    long v24;
    v24 = v23 + v22;
    float * v27;
    float * v25;
    v25 = v12+v24;
    v27 = v25;
    assert("Tensor range check" && 0 <= v17 && v17 < 2l);
    long v28;
    v28 = 4352l * v17;
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
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v60[4l];
    // Pushing the loop unrolling to: 1
    long v61;
    v61 = blockIdx.x;
    long v62;
    v62 = v61;
    #pragma unroll 1
    while (while_method_0(v62)){
        long v64;
        v64 = v62 % 64l;
        long v65;
        v65 = v62 / 64l;
        long v66;
        v66 = v65 % 64l;
        long v67;
        v67 = v65 / 64l;
        bool v68;
        v68 = v67 == 0l;
        bool v69;
        v69 = v68 == false;
        if (v69){
            assert("The index has to be in the range of the dimension." && v68);
        } else {
        }
        assert("Tensor range check" && 0 <= v66 && v66 < 64l);
        assert("Tensor range check" && 0 <= v64 && v64 < 64l);
        long v71;
        v71 = 128l * v64;
        long v72;
        v72 = 1048576l * v66;
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
        v80 = v79 % 16l;
        long v81;
        v81 = v79 / 16l;
        bool v82;
        v82 = v81 == 0l;
        bool v83;
        v83 = v82 == false;
        if (v83){
            assert("The index has to be in the range of the dimension." && v82);
        } else {
        }
        assert("Tensor range check" && 0 <= v80 && v80 < 16l);
        assert("Tensor range check" && 0 <= v78 && v78 < 32l);
        long v85;
        v85 = 4l * v78;
        long v86;
        v86 = 136l * v80;
        long v87;
        v87 = v86 + v85;
        long v88;
        v88 = 8192l * v80;
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
                assert("Tensor range check" && 0 <= v96 && v96 < 8l);
                assert("Tensor range check" && 0 <= v98 && v98 < 1l);
                long v100;
                v100 = 128l * v98;
                long v101;
                v101 = 2176l * v96;
                long v102;
                v102 = v101 + v100;
                long v103;
                v103 = 131072l * v96;
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
                assert("Tensor range check" && 0 <= v107 && v107 < 4l);
                assert("Tensor range check" && 0 <= v109 && v109 < 1l);
                long v111;
                v111 = v107 + v109;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v112 = v60[v111];
                assert("Tensor range check" && 0 <= v107 && v107 < 4l);
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
            assert("Tensor range check" && 0 <= v66 && v66 < 64l);
            long v119;
            v119 = 524288l * v66;
            assert("Tensor range check" && 0 <= v117 && v117 < 64l);
            long v120;
            v120 = 64l * v117;
            long v121;
            v121 = v120 + v119;
            float * v124;
            float * v122;
            v122 = v0+v121;
            v124 = v122;
            assert("Tensor range check" && 0 <= v64 && v64 < 64l);
            long v125;
            v125 = 524288l * v64;
            assert("Tensor range check" && 0 <= v117 && v117 < 64l);
            long v126;
            v126 = v120 + v125;
            float * v129;
            float * v127;
            v127 = v1+v126;
            v129 = v127;
            long v130;
            v130 = threadIdx.x;
            long v131;
            v131 = v130 % 16l;
            long v132;
            v132 = v130 / 16l;
            long v133;
            v133 = v132 % 32l;
            long v134;
            v134 = v132 / 32l;
            bool v135;
            v135 = v134 == 0l;
            bool v136;
            v136 = v135 == false;
            if (v136){
                assert("The index has to be in the range of the dimension." && v135);
            } else {
            }
            assert("Tensor range check" && 0 <= v133 && v133 < 32l);
            assert("Tensor range check" && 0 <= v131 && v131 < 16l);
            long v138;
            v138 = 4l * v131;
            long v139;
            v139 = 68l * v133;
            long v140;
            v140 = v139 + v138;
            long v141;
            v141 = 4096l * v133;
            long v142;
            v142 = v141 + v138;
            float * v145;
            float * v143;
            v143 = v9+v140;
            v145 = v143;
            float * v148;
            float * v146;
            v146 = v129+v142;
            v148 = v146;
            long v149;
            v149 = 0l;
            #pragma unroll
            while (while_method_3(v149)){
                long v151;
                v151 = 0l;
                #pragma unroll
                while (while_method_2(v151)){
                    assert("Tensor range check" && 0 <= v149 && v149 < 4l);
                    assert("Tensor range check" && 0 <= v151 && v151 < 1l);
                    long v153;
                    v153 = 64l * v151;
                    long v154;
                    v154 = 2176l * v149;
                    long v155;
                    v155 = v154 + v153;
                    long v156;
                    v156 = 131072l * v149;
                    long v157;
                    v157 = v156 + v153;
                    int4* v158;
                    v158 = reinterpret_cast<int4*>(v148 + v157);
                    int4* v159;
                    v159 = reinterpret_cast<int4*>(v145 + v155);
                    assert("Pointer alignment check" && (unsigned long long)(v158) % 4l == 0 && (unsigned long long)(v159) % 4l == 0);
                    *v159 = *v158;
                    v151 += 1l ;
                }
                v149 += 1l ;
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
            v173 = v6+v170;
            v175 = v173;
            float * v178;
            float * v176;
            v176 = v124+v172;
            v178 = v176;
            long v179;
            v179 = 0l;
            #pragma unroll
            while (while_method_3(v179)){
                long v181;
                v181 = 0l;
                #pragma unroll
                while (while_method_2(v181)){
                    assert("Tensor range check" && 0 <= v179 && v179 < 4l);
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
                    int4* v188;
                    v188 = reinterpret_cast<int4*>(v178 + v187);
                    int4* v189;
                    v189 = reinterpret_cast<int4*>(v175 + v185);
                    assert("Pointer alignment check" && (unsigned long long)(v188) % 4l == 0 && (unsigned long long)(v189) % 4l == 0);
                    *v189 = *v188;
                    v181 += 1l ;
                }
                v179 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v190[32l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v191[8l];
            long v192;
            v192 = 0l;
            #pragma unroll
            while (while_method_3(v192)){
                long v194;
                v194 = 0l;
                #pragma unroll
                while (while_method_1(v194)){
                    assert("Tensor range check" && 0 <= v192 && v192 < 4l);
                    assert("Tensor range check" && 0 <= v194 && v194 < 8l);
                    long v196;
                    v196 = 8l * v192;
                    long v197;
                    v197 = v196 + v194;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v198 = v190[v197];
                    assert("Tensor range check" && 0 <= v192 && v192 < 4l);
                    long v199;
                    v199 = 1088l * v192;
                    assert("Tensor range check" && 0 <= v194 && v194 < 8l);
                    long v200;
                    v200 = 8l * v194;
                    long v201;
                    v201 = v200 + v199;
                    long v202;
                    v202 = 0l;
                    #pragma unroll
                    while (while_method_5(v202)){
                        long v204;
                        v204 = 0l;
                        #pragma unroll
                        while (while_method_5(v204)){
                            assert("Tensor range check" && 0 <= v202 && v202 < 2l);
                            assert("Tensor range check" && 0 <= v204 && v204 < 2l);
                            long v206;
                            v206 = 544l * v204;
                            long v207;
                            v207 = v206 + v201;
                            long v208;
                            v208 = 4l * v202;
                            long v209;
                            v209 = v208 + v207;
                            float v210;
                            v210 = v43[v209];
                            bool v211;
                            v211 = 0l <= v204;
                            bool v213;
                            if (v211){
                                bool v212;
                                v212 = v204 < 2l;
                                v213 = v212;
                            } else {
                                v213 = false;
                            }
                            bool v214;
                            v214 = v213 == false;
                            if (v214){
                                assert("The indices should be inside the range of the dimension." && v213);
                            } else {
                            }
                            bool v216;
                            v216 = 0l <= v202;
                            bool v218;
                            if (v216){
                                bool v217;
                                v217 = v202 < 2l;
                                v218 = v217;
                            } else {
                                v218 = false;
                            }
                            bool v219;
                            v219 = v218 == false;
                            if (v219){
                                assert("The indices should be inside the range of the dimension." && v218);
                            } else {
                            }
                            long v221;
                            v221 = v202 * 2l;
                            long v222;
                            v222 = v204 + v221;
                            v198.x[v222] = wmma::__float_to_tf32(v210);
                            v204 += 1l ;
                        }
                        v202 += 1l ;
                    }
                    v194 += 1l ;
                }
                v192 += 1l ;
            }
            long v223;
            v223 = 0l;
            #pragma unroll
            while (while_method_2(v223)){
                long v225;
                v225 = 0l;
                #pragma unroll
                while (while_method_1(v225)){
                    assert("Tensor range check" && 0 <= v223 && v223 < 1l);
                    assert("Tensor range check" && 0 <= v225 && v225 < 8l);
                    long v227;
                    v227 = 8l * v223;
                    long v228;
                    v228 = v227 + v225;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v229 = v191[v228];
                    assert("Tensor range check" && 0 <= v223 && v223 < 1l);
                    long v230;
                    v230 = 1088l * v223;
                    assert("Tensor range check" && 0 <= v225 && v225 < 8l);
                    long v231;
                    v231 = 8l * v225;
                    long v232;
                    v232 = v231 + v230;
                    long v233;
                    v233 = 0l;
                    #pragma unroll
                    while (while_method_5(v233)){
                        long v235;
                        v235 = 0l;
                        #pragma unroll
                        while (while_method_5(v235)){
                            assert("Tensor range check" && 0 <= v233 && v233 < 2l);
                            assert("Tensor range check" && 0 <= v235 && v235 < 2l);
                            long v237;
                            v237 = 4l * v235;
                            long v238;
                            v238 = v237 + v232;
                            long v239;
                            v239 = 544l * v233;
                            long v240;
                            v240 = v239 + v238;
                            float v241;
                            v241 = v59[v240];
                            bool v242;
                            v242 = 0l <= v235;
                            bool v244;
                            if (v242){
                                bool v243;
                                v243 = v235 < 2l;
                                v244 = v243;
                            } else {
                                v244 = false;
                            }
                            bool v245;
                            v245 = v244 == false;
                            if (v245){
                                assert("The indices should be inside the range of the dimension." && v244);
                            } else {
                            }
                            bool v247;
                            v247 = 0l <= v233;
                            bool v249;
                            if (v247){
                                bool v248;
                                v248 = v233 < 2l;
                                v249 = v248;
                            } else {
                                v249 = false;
                            }
                            bool v250;
                            v250 = v249 == false;
                            if (v250){
                                assert("The indices should be inside the range of the dimension." && v249);
                            } else {
                            }
                            long v252;
                            v252 = v233 * 2l;
                            long v253;
                            v253 = v235 + v252;
                            v229.x[v253] = wmma::__float_to_tf32(v241);
                            v235 += 1l ;
                        }
                        v233 += 1l ;
                    }
                    v225 += 1l ;
                }
                v223 += 1l ;
            }
            __syncthreads();
            long v254;
            v254 = 0l;
            #pragma unroll
            while (while_method_3(v254)){
                long v256;
                v256 = 0l;
                #pragma unroll
                while (while_method_2(v256)){
                    long v258;
                    v258 = 0l;
                    #pragma unroll
                    while (while_method_1(v258)){
                        assert("Tensor range check" && 0 <= v254 && v254 < 4l);
                        assert("Tensor range check" && 0 <= v256 && v256 < 1l);
                        long v260;
                        v260 = v254 + v256;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v261 = v60[v260];
                        assert("Tensor range check" && 0 <= v254 && v254 < 4l);
                        assert("Tensor range check" && 0 <= v258 && v258 < 8l);
                        long v262;
                        v262 = 8l * v254;
                        long v263;
                        v263 = v262 + v258;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v264 = v190[v263];
                        assert("Tensor range check" && 0 <= v256 && v256 < 1l);
                        assert("Tensor range check" && 0 <= v258 && v258 < 8l);
                        long v265;
                        v265 = 8l * v256;
                        long v266;
                        v266 = v265 + v258;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v267 = v191[v266];
                        wmma::mma_sync(v261, v264, v267, v261);
                        v258 += 1l ;
                    }
                    v256 += 1l ;
                }
                v254 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v117 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v268;
        v268 = 0l;
        #pragma unroll
        while (while_method_3(v268)){
            long v270;
            v270 = 0l;
            #pragma unroll
            while (while_method_2(v270)){
                assert("Tensor range check" && 0 <= v268 && v268 < 4l);
                assert("Tensor range check" && 0 <= v270 && v270 < 1l);
                long v272;
                v272 = v268 + v270;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v273 = v60[v272];
                assert("Tensor range check" && 0 <= v268 && v268 < 4l);
                assert("Tensor range check" && 0 <= v270 && v270 < 1l);
                long v274;
                v274 = 16l * v270;
                long v275;
                v275 = 2176l * v268;
                long v276;
                v276 = v275 + v274;
                float * v277;
                v277 = v27 + v276;
                wmma::store_matrix_sync(v277, v273, 136l, wmma::mem_row_major);
                v270 += 1l ;
            }
            v268 += 1l ;
        }
        __syncthreads();
        long v278;
        v278 = threadIdx.x;
        long v279;
        v279 = v278 % 32l;
        long v280;
        v280 = v278 / 32l;
        long v281;
        v281 = v280 % 16l;
        long v282;
        v282 = v280 / 16l;
        bool v283;
        v283 = v282 == 0l;
        bool v284;
        v284 = v283 == false;
        if (v284){
            assert("The index has to be in the range of the dimension." && v283);
        } else {
        }
        assert("Tensor range check" && 0 <= v281 && v281 < 16l);
        assert("Tensor range check" && 0 <= v279 && v279 < 32l);
        long v286;
        v286 = 4l * v279;
        long v287;
        v287 = 8192l * v281;
        long v288;
        v288 = v287 + v286;
        long v289;
        v289 = 136l * v281;
        long v290;
        v290 = v289 + v286;
        float * v293;
        float * v291;
        v291 = v76+v288;
        v293 = v291;
        float * v296;
        float * v294;
        v294 = v12+v290;
        v296 = v294;
        long v297;
        v297 = 0l;
        #pragma unroll
        while (while_method_1(v297)){
            long v299;
            v299 = 0l;
            #pragma unroll
            while (while_method_2(v299)){
                assert("Tensor range check" && 0 <= v297 && v297 < 8l);
                assert("Tensor range check" && 0 <= v299 && v299 < 1l);
                long v301;
                v301 = 128l * v299;
                long v302;
                v302 = 131072l * v297;
                long v303;
                v303 = v302 + v301;
                long v304;
                v304 = 2176l * v297;
                long v305;
                v305 = v304 + v301;
                int4* v306;
                v306 = reinterpret_cast<int4*>(v296 + v305);
                int4* v307;
                v307 = reinterpret_cast<int4*>(v293 + v303);
                assert("Pointer alignment check" && (unsigned long long)(v306) % 4l == 0 && (unsigned long long)(v307) % 4l == 0);
                *v307 = *v306;
                v299 += 1l ;
            }
            v297 += 1l ;
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
