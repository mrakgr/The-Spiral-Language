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
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 1l;
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
        v77 = v76 % 1l;
        long v78;
        v78 = v76 % 16l;
        long v79;
        v79 = v76 / 16l;
        bool v80;
        v80 = v79 == 0l;
        bool v81;
        v81 = v80 == false;
        if (v81){
            assert("The index has to be in the range of the dimension." && v80);
        } else {
        }
        assert("Tensor range check" && 0 <= v78 && v78 < 16l);
        assert("Tensor range check" && 0 <= v77 && v77 < 1l);
        long v83;
        v83 = 4l * v77;
        long v84;
        v84 = 136l * v78;
        long v85;
        v85 = v84 + v83;
        long v86;
        v86 = 512l * v78;
        long v87;
        v87 = v86 + v83;
        float * v90;
        float * v88;
        v88 = v12+v85;
        v90 = v88;
        float * v93;
        float * v91;
        v91 = v75+v87;
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
                assert("Tensor range check" && 0 <= v96 && v96 < 32l);
                long v98;
                v98 = 4l * v96;
                long v99;
                v99 = 2176l * v94;
                long v100;
                v100 = v99 + v98;
                long v101;
                v101 = 8192l * v94;
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
        while (while_method_1(v105)){
            long v107;
            v107 = 0l;
            #pragma unroll
            while (while_method_3(v107)){
                assert("Tensor range check" && 0 <= v105 && v105 < 8l);
                assert("Tensor range check" && 0 <= v107 && v107 < 1l);
                long v109;
                v109 = v105 + v107;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v110 = v59[v109];
                assert("Tensor range check" && 0 <= v105 && v105 < 8l);
                assert("Tensor range check" && 0 <= v107 && v107 < 1l);
                long v111;
                v111 = 16l * v107;
                long v112;
                v112 = 2176l * v105;
                long v113;
                v113 = v112 + v111;
                float * v114;
                v114 = v26 + v113;
                wmma::load_matrix_sync(v110, v114, 136l, wmma::mem_row_major);
                v107 += 1l ;
            }
            v105 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        long v115;
        v115 = 0l;
        while (while_method_1(v115)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v65 && v65 < 4l);
            assert("Tensor range check" && 0 <= v115 && v115 < 8l);
            long v117;
            v117 = 64l * v115;
            long v118;
            v118 = v117 + v71;
            float * v121;
            float * v119;
            v119 = v0+v118;
            v121 = v119;
            assert("Tensor range check" && 0 <= v63 && v63 < 4l);
            long v122;
            v122 = 65536l * v63;
            assert("Tensor range check" && 0 <= v115 && v115 < 8l);
            long v123;
            v123 = v117 + v122;
            float * v126;
            float * v124;
            v124 = v1+v123;
            v126 = v124;
            long v127;
            v127 = threadIdx.x;
            long v128;
            v128 = v127 % 1l;
            long v129;
            v129 = v127 % 8l;
            long v130;
            v130 = v127 / 8l;
            bool v131;
            v131 = v130 == 0l;
            bool v132;
            v132 = v131 == false;
            if (v132){
                assert("The index has to be in the range of the dimension." && v131);
            } else {
            }
            assert("Tensor range check" && 0 <= v129 && v129 < 8l);
            assert("Tensor range check" && 0 <= v128 && v128 < 1l);
            long v134;
            v134 = 4l * v128;
            long v135;
            v135 = 68l * v129;
            long v136;
            v136 = v135 + v134;
            long v137;
            v137 = 512l * v129;
            long v138;
            v138 = v137 + v134;
            float * v141;
            float * v139;
            v139 = v9+v136;
            v141 = v139;
            float * v144;
            float * v142;
            v142 = v126+v138;
            v144 = v142;
            long v145;
            v145 = 0l;
            #pragma unroll
            while (while_method_0(v145)){
                long v147;
                v147 = 0l;
                #pragma unroll
                while (while_method_0(v147)){
                    assert("Tensor range check" && 0 <= v145 && v145 < 16l);
                    assert("Tensor range check" && 0 <= v147 && v147 < 16l);
                    long v149;
                    v149 = 4l * v147;
                    long v150;
                    v150 = 544l * v145;
                    long v151;
                    v151 = v150 + v149;
                    long v152;
                    v152 = 4096l * v145;
                    long v153;
                    v153 = v152 + v149;
                    int4* v154;
                    v154 = reinterpret_cast<int4*>(v144 + v153);
                    int4* v155;
                    v155 = reinterpret_cast<int4*>(v141 + v151);
                    assert("Pointer alignment check" && (unsigned long long)(v154) % 4l == 0 && (unsigned long long)(v155) % 4l == 0);
                    *v155 = *v154;
                    v147 += 1l ;
                }
                v145 += 1l ;
            }
            long v156;
            v156 = threadIdx.x;
            long v157;
            v157 = v156 % 1l;
            long v158;
            v158 = v156 % 8l;
            long v159;
            v159 = v156 / 8l;
            bool v160;
            v160 = v159 == 0l;
            bool v161;
            v161 = v160 == false;
            if (v161){
                assert("The index has to be in the range of the dimension." && v160);
            } else {
            }
            assert("Tensor range check" && 0 <= v158 && v158 < 8l);
            assert("Tensor range check" && 0 <= v157 && v157 < 1l);
            long v163;
            v163 = 4l * v157;
            long v164;
            v164 = 68l * v158;
            long v165;
            v165 = v164 + v163;
            long v166;
            v166 = 512l * v158;
            long v167;
            v167 = v166 + v163;
            float * v170;
            float * v168;
            v168 = v6+v165;
            v170 = v168;
            float * v173;
            float * v171;
            v171 = v121+v167;
            v173 = v171;
            long v174;
            v174 = 0l;
            #pragma unroll
            while (while_method_0(v174)){
                long v176;
                v176 = 0l;
                #pragma unroll
                while (while_method_0(v176)){
                    assert("Tensor range check" && 0 <= v174 && v174 < 16l);
                    assert("Tensor range check" && 0 <= v176 && v176 < 16l);
                    long v178;
                    v178 = 4l * v176;
                    long v179;
                    v179 = 544l * v174;
                    long v180;
                    v180 = v179 + v178;
                    long v181;
                    v181 = 4096l * v174;
                    long v182;
                    v182 = v181 + v178;
                    int4* v183;
                    v183 = reinterpret_cast<int4*>(v173 + v182);
                    int4* v184;
                    v184 = reinterpret_cast<int4*>(v170 + v180);
                    assert("Pointer alignment check" && (unsigned long long)(v183) % 4l == 0 && (unsigned long long)(v184) % 4l == 0);
                    *v184 = *v183;
                    v176 += 1l ;
                }
                v174 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v185[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v186[8l];
            long v187;
            v187 = 0l;
            #pragma unroll
            while (while_method_1(v187)){
                long v189;
                v189 = 0l;
                #pragma unroll
                while (while_method_1(v189)){
                    assert("Tensor range check" && 0 <= v187 && v187 < 8l);
                    assert("Tensor range check" && 0 <= v189 && v189 < 8l);
                    long v191;
                    v191 = 8l * v187;
                    long v192;
                    v192 = v191 + v189;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v193 = v185[v192];
                    assert("Tensor range check" && 0 <= v187 && v187 < 8l);
                    long v194;
                    v194 = 1088l * v187;
                    assert("Tensor range check" && 0 <= v189 && v189 < 8l);
                    long v195;
                    v195 = 8l * v189;
                    long v196;
                    v196 = v195 + v194;
                    long v197;
                    v197 = 0l;
                    #pragma unroll
                    while (while_method_4(v197)){
                        long v199;
                        v199 = 0l;
                        #pragma unroll
                        while (while_method_4(v199)){
                            assert("Tensor range check" && 0 <= v197 && v197 < 2l);
                            assert("Tensor range check" && 0 <= v199 && v199 < 2l);
                            long v201;
                            v201 = 544l * v199;
                            long v202;
                            v202 = v201 + v196;
                            long v203;
                            v203 = 4l * v197;
                            long v204;
                            v204 = v203 + v202;
                            float v205;
                            v205 = v42[v204];
                            bool v206;
                            v206 = 0l <= v199;
                            bool v208;
                            if (v206){
                                bool v207;
                                v207 = v199 < 2l;
                                v208 = v207;
                            } else {
                                v208 = false;
                            }
                            bool v209;
                            v209 = v208 == false;
                            if (v209){
                                assert("The indices should be inside the range of the dimension." && v208);
                            } else {
                            }
                            bool v211;
                            v211 = 0l <= v197;
                            bool v213;
                            if (v211){
                                bool v212;
                                v212 = v197 < 2l;
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
                            long v216;
                            v216 = v197 * 2l;
                            long v217;
                            v217 = v199 + v216;
                            v193.x[v217] = v205;
                            v199 += 1l ;
                        }
                        v197 += 1l ;
                    }
                    v189 += 1l ;
                }
                v187 += 1l ;
            }
            long v218;
            v218 = 0l;
            #pragma unroll
            while (while_method_3(v218)){
                long v220;
                v220 = 0l;
                #pragma unroll
                while (while_method_1(v220)){
                    assert("Tensor range check" && 0 <= v218 && v218 < 1l);
                    assert("Tensor range check" && 0 <= v220 && v220 < 8l);
                    long v222;
                    v222 = 8l * v218;
                    long v223;
                    v223 = v222 + v220;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v224 = v186[v223];
                    assert("Tensor range check" && 0 <= v218 && v218 < 1l);
                    long v225;
                    v225 = 1088l * v218;
                    assert("Tensor range check" && 0 <= v220 && v220 < 8l);
                    long v226;
                    v226 = 8l * v220;
                    long v227;
                    v227 = v226 + v225;
                    long v228;
                    v228 = 0l;
                    #pragma unroll
                    while (while_method_4(v228)){
                        long v230;
                        v230 = 0l;
                        #pragma unroll
                        while (while_method_4(v230)){
                            assert("Tensor range check" && 0 <= v228 && v228 < 2l);
                            assert("Tensor range check" && 0 <= v230 && v230 < 2l);
                            long v232;
                            v232 = 4l * v230;
                            long v233;
                            v233 = v232 + v227;
                            long v234;
                            v234 = 544l * v228;
                            long v235;
                            v235 = v234 + v233;
                            float v236;
                            v236 = v58[v235];
                            bool v237;
                            v237 = 0l <= v230;
                            bool v239;
                            if (v237){
                                bool v238;
                                v238 = v230 < 2l;
                                v239 = v238;
                            } else {
                                v239 = false;
                            }
                            bool v240;
                            v240 = v239 == false;
                            if (v240){
                                assert("The indices should be inside the range of the dimension." && v239);
                            } else {
                            }
                            bool v242;
                            v242 = 0l <= v228;
                            bool v244;
                            if (v242){
                                bool v243;
                                v243 = v228 < 2l;
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
                            long v247;
                            v247 = v228 * 2l;
                            long v248;
                            v248 = v230 + v247;
                            v224.x[v248] = v236;
                            v230 += 1l ;
                        }
                        v228 += 1l ;
                    }
                    v220 += 1l ;
                }
                v218 += 1l ;
            }
            long v249;
            v249 = 0l;
            #pragma unroll
            while (while_method_1(v249)){
                long v251;
                v251 = 0l;
                #pragma unroll
                while (while_method_3(v251)){
                    long v253;
                    v253 = 0l;
                    #pragma unroll
                    while (while_method_1(v253)){
                        assert("Tensor range check" && 0 <= v249 && v249 < 8l);
                        assert("Tensor range check" && 0 <= v251 && v251 < 1l);
                        long v255;
                        v255 = v249 + v251;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v256 = v59[v255];
                        assert("Tensor range check" && 0 <= v249 && v249 < 8l);
                        assert("Tensor range check" && 0 <= v253 && v253 < 8l);
                        long v257;
                        v257 = 8l * v249;
                        long v258;
                        v258 = v257 + v253;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v259 = v185[v258];
                        assert("Tensor range check" && 0 <= v251 && v251 < 1l);
                        assert("Tensor range check" && 0 <= v253 && v253 < 8l);
                        long v260;
                        v260 = 8l * v251;
                        long v261;
                        v261 = v260 + v253;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v262 = v186[v261];
                        wmma::mma_sync(v256, v259, v262, v256);
                        v253 += 1l ;
                    }
                    v251 += 1l ;
                }
                v249 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v115 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v263;
        v263 = threadIdx.x;
        long v264;
        v264 = v263 % 1l;
        long v265;
        v265 = v263 % 16l;
        long v266;
        v266 = v263 / 16l;
        bool v267;
        v267 = v266 == 0l;
        bool v268;
        v268 = v267 == false;
        if (v268){
            assert("The index has to be in the range of the dimension." && v267);
        } else {
        }
        assert("Tensor range check" && 0 <= v265 && v265 < 16l);
        assert("Tensor range check" && 0 <= v264 && v264 < 1l);
        long v270;
        v270 = 4l * v264;
        long v271;
        v271 = 136l * v265;
        long v272;
        v272 = v271 + v270;
        long v273;
        v273 = 512l * v265;
        long v274;
        v274 = v273 + v270;
        float * v277;
        float * v275;
        v275 = v12+v272;
        v277 = v275;
        float * v280;
        float * v278;
        v278 = v75+v274;
        v280 = v278;
        long v281;
        v281 = 0l;
        #pragma unroll
        while (while_method_1(v281)){
            long v283;
            v283 = 0l;
            #pragma unroll
            while (while_method_2(v283)){
                assert("Tensor range check" && 0 <= v281 && v281 < 8l);
                assert("Tensor range check" && 0 <= v283 && v283 < 32l);
                long v285;
                v285 = 4l * v283;
                long v286;
                v286 = 2176l * v281;
                long v287;
                v287 = v286 + v285;
                long v288;
                v288 = 8192l * v281;
                long v289;
                v289 = v288 + v285;
                int4* v290;
                v290 = reinterpret_cast<int4*>(v280 + v289);
                int4* v291;
                v291 = reinterpret_cast<int4*>(v277 + v287);
                assert("Pointer alignment check" && (unsigned long long)(v290) % 4l == 0 && (unsigned long long)(v291) % 4l == 0);
                *v291 = *v290;
                v283 += 1l ;
            }
            v281 += 1l ;
        }
        __syncthreads();
        long v292;
        v292 = 0l;
        #pragma unroll
        while (while_method_1(v292)){
            long v294;
            v294 = 0l;
            #pragma unroll
            while (while_method_3(v294)){
                assert("Tensor range check" && 0 <= v292 && v292 < 8l);
                assert("Tensor range check" && 0 <= v294 && v294 < 1l);
                long v296;
                v296 = v292 + v294;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v297 = v59[v296];
                assert("Tensor range check" && 0 <= v292 && v292 < 8l);
                assert("Tensor range check" && 0 <= v294 && v294 < 1l);
                long v298;
                v298 = 16l * v294;
                long v299;
                v299 = 2176l * v292;
                long v300;
                v300 = v299 + v298;
                float * v301;
                v301 = v26 + v300;
                wmma::store_matrix_sync(v301, v297, 136l, wmma::mem_row_major);
                v294 += 1l ;
            }
            v292 += 1l ;
        }
        __syncthreads();
        long v302;
        v302 = threadIdx.x;
        long v303;
        v303 = v302 % 1l;
        long v304;
        v304 = v302 % 16l;
        long v305;
        v305 = v302 / 16l;
        bool v306;
        v306 = v305 == 0l;
        bool v307;
        v307 = v306 == false;
        if (v307){
            assert("The index has to be in the range of the dimension." && v306);
        } else {
        }
        assert("Tensor range check" && 0 <= v304 && v304 < 16l);
        assert("Tensor range check" && 0 <= v303 && v303 < 1l);
        long v309;
        v309 = 4l * v303;
        long v310;
        v310 = 512l * v304;
        long v311;
        v311 = v310 + v309;
        long v312;
        v312 = 136l * v304;
        long v313;
        v313 = v312 + v309;
        float * v316;
        float * v314;
        v314 = v75+v311;
        v316 = v314;
        float * v319;
        float * v317;
        v317 = v12+v313;
        v319 = v317;
        long v320;
        v320 = 0l;
        #pragma unroll
        while (while_method_1(v320)){
            long v322;
            v322 = 0l;
            #pragma unroll
            while (while_method_2(v322)){
                assert("Tensor range check" && 0 <= v320 && v320 < 8l);
                assert("Tensor range check" && 0 <= v322 && v322 < 32l);
                long v324;
                v324 = 4l * v322;
                long v325;
                v325 = 8192l * v320;
                long v326;
                v326 = v325 + v324;
                long v327;
                v327 = 2176l * v320;
                long v328;
                v328 = v327 + v324;
                int4* v329;
                v329 = reinterpret_cast<int4*>(v319 + v328);
                int4* v330;
                v330 = reinterpret_cast<int4*>(v316 + v326);
                assert("Pointer alignment check" && (unsigned long long)(v329) % 4l == 0 && (unsigned long long)(v330) % 4l == 0);
                *v330 = *v329;
                v322 += 1l ;
            }
            v320 += 1l ;
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
options.append('--generate-line-info')
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
        v27 = 0
        v28 = raw_module.get_function(f"entry{v27}")
        del v27
        v28.max_dynamic_shared_size_bytes = 69632 
        v28((24,),(256,),(v10, v5, v0),shared_mem=69632)
        del v28
        v29 = cp.max(cp.abs(v0-v22))
        del v22
        v30 = v29 + v16
        del v29
        v16 = v30
        del v30
        v15 += 1 
    del v0, v5, v10, v15
    return v16

if __name__ == '__main__': print(main())
