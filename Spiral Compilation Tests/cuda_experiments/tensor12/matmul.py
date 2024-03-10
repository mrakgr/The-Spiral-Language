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
    v27 = 128l * v17;
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
    v37 = 136l * v30;
    long v38;
    v38 = v37 + v27;
    long v39;
    v39 = v32 + v38;
    float * v42;
    float * v40;
    v40 = v6+v39;
    v42 = v40;
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v43;
    v43 = threadIdx.x;
    long v44;
    v44 = v43 % 32l;
    long v45;
    v45 = v44 % 4l;
    long v46;
    v46 = v44 / 4l;
    long v47;
    v47 = v46 % 8l;
    long v48;
    v48 = v46 / 8l;
    bool v49;
    v49 = v48 == 0l;
    bool v50;
    v50 = v49 == false;
    if (v50){
        assert("The index has to be in the range of the dimension." && v49);
    } else {
    }
    assert("Tensor range check" && 0 <= v47 && v47 < 8l);
    assert("Tensor range check" && 0 <= v45 && v45 < 4l);
    long v52;
    v52 = 136l * v45;
    long v53;
    v53 = v52 + v21;
    long v54;
    v54 = v47 + v53;
    float * v57;
    float * v55;
    v55 = v9+v54;
    v57 = v55;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v58[8l];
    long v59;
    v59 = blockIdx.x;
    long v60;
    v60 = v59;
    while (while_method_0(v60)){
        long v62;
        v62 = v60 % 4l;
        long v63;
        v63 = v60 / 4l;
        long v64;
        v64 = v63 % 4l;
        long v65;
        v65 = v63 / 4l;
        bool v66;
        v66 = v65 == 0l;
        bool v67;
        v67 = v66 == false;
        if (v67){
            assert("The index has to be in the range of the dimension." && v66);
        } else {
        }
        assert("Tensor range check" && 0 <= v64 && v64 < 4l);
        assert("Tensor range check" && 0 <= v62 && v62 < 4l);
        long v69;
        v69 = 128l * v62;
        long v70;
        v70 = 65536l * v64;
        long v71;
        v71 = v70 + v69;
        float * v74;
        float * v72;
        v72 = v2+v71;
        v74 = v72;
        // Pushing the loop unrolling to: 0
        long v75;
        v75 = threadIdx.x;
        long v76;
        v76 = v75 % 32l;
        long v77;
        v77 = v75 / 32l;
        long v78;
        v78 = v77 % 8l;
        long v79;
        v79 = v77 / 8l;
        bool v80;
        v80 = v79 == 0l;
        bool v81;
        v81 = v80 == false;
        if (v81){
            assert("The index has to be in the range of the dimension." && v80);
        } else {
        }
        assert("Tensor range check" && 0 <= v78 && v78 < 8l);
        assert("Tensor range check" && 0 <= v76 && v76 < 32l);
        long v83;
        v83 = 4l * v76;
        long v84;
        v84 = 2176l * v78;
        long v85;
        v85 = v84 + v83;
        long v86;
        v86 = 8192l * v78;
        long v87;
        v87 = v86 + v83;
        float * v90;
        float * v88;
        v88 = v12+v85;
        v90 = v88;
        float * v93;
        float * v91;
        v91 = v74+v87;
        v93 = v91;
        long v94;
        v94 = 0l;
        #pragma unroll
        while (while_method_0(v94)){
            long v96;
            v96 = 0l;
            #pragma unroll
            while (while_method_1(v96)){
                assert("Tensor range check" && 0 <= v94 && v94 < 16l);
                assert("Tensor range check" && 0 <= v96 && v96 < 1l);
                long v98;
                v98 = 4l * v96;
                long v99;
                v99 = 136l * v94;
                long v100;
                v100 = v99 + v98;
                long v101;
                v101 = 512l * v94;
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
        while (while_method_2(v105)){
            long v107;
            v107 = 0l;
            #pragma unroll
            while (while_method_1(v107)){
                assert("Tensor range check" && 0 <= v105 && v105 < 8l);
                assert("Tensor range check" && 0 <= v107 && v107 < 1l);
                long v109;
                v109 = v105 + v107;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v110 = v58[v109];
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
        while (while_method_2(v115)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v64 && v64 < 4l);
            long v117;
            v117 = 128l * v64;
            assert("Tensor range check" && 0 <= v115 && v115 < 8l);
            long v118;
            v118 = 32768l * v115;
            long v119;
            v119 = v118 + v117;
            float * v122;
            float * v120;
            v120 = v0+v119;
            v122 = v120;
            assert("Tensor range check" && 0 <= v62 && v62 < 4l);
            assert("Tensor range check" && 0 <= v115 && v115 < 8l);
            long v123;
            v123 = v118 + v69;
            float * v126;
            float * v124;
            v124 = v1+v123;
            v126 = v124;
            long v127;
            v127 = threadIdx.x;
            long v128;
            v128 = v127 % 32l;
            long v129;
            v129 = v127 / 32l;
            long v130;
            v130 = v129 % 8l;
            long v131;
            v131 = v129 / 8l;
            bool v132;
            v132 = v131 == 0l;
            bool v133;
            v133 = v132 == false;
            if (v133){
                assert("The index has to be in the range of the dimension." && v132);
            } else {
            }
            assert("Tensor range check" && 0 <= v130 && v130 < 8l);
            assert("Tensor range check" && 0 <= v128 && v128 < 32l);
            long v135;
            v135 = 4l * v128;
            long v136;
            v136 = 1088l * v130;
            long v137;
            v137 = v136 + v135;
            long v138;
            v138 = 4096l * v130;
            long v139;
            v139 = v138 + v135;
            float * v142;
            float * v140;
            v140 = v9+v137;
            v142 = v140;
            float * v145;
            float * v143;
            v143 = v126+v139;
            v145 = v143;
            long v146;
            v146 = 0l;
            #pragma unroll
            while (while_method_2(v146)){
                long v148;
                v148 = 0l;
                #pragma unroll
                while (while_method_1(v148)){
                    assert("Tensor range check" && 0 <= v146 && v146 < 8l);
                    assert("Tensor range check" && 0 <= v148 && v148 < 1l);
                    long v150;
                    v150 = 4l * v148;
                    long v151;
                    v151 = 136l * v146;
                    long v152;
                    v152 = v151 + v150;
                    long v153;
                    v153 = 512l * v146;
                    long v154;
                    v154 = v153 + v150;
                    int4* v155;
                    v155 = reinterpret_cast<int4*>(v145 + v154);
                    int4* v156;
                    v156 = reinterpret_cast<int4*>(v142 + v152);
                    assert("Pointer alignment check" && (unsigned long long)(v155) % 4l == 0 && (unsigned long long)(v156) % 4l == 0);
                    *v156 = *v155;
                    v148 += 1l ;
                }
                v146 += 1l ;
            }
            long v157;
            v157 = threadIdx.x;
            long v158;
            v158 = v157 % 32l;
            long v159;
            v159 = v157 / 32l;
            long v160;
            v160 = v159 % 8l;
            long v161;
            v161 = v159 / 8l;
            bool v162;
            v162 = v161 == 0l;
            bool v163;
            v163 = v162 == false;
            if (v163){
                assert("The index has to be in the range of the dimension." && v162);
            } else {
            }
            assert("Tensor range check" && 0 <= v160 && v160 < 8l);
            assert("Tensor range check" && 0 <= v158 && v158 < 32l);
            long v165;
            v165 = 4l * v158;
            long v166;
            v166 = 1088l * v160;
            long v167;
            v167 = v166 + v165;
            long v168;
            v168 = 4096l * v160;
            long v169;
            v169 = v168 + v165;
            float * v172;
            float * v170;
            v170 = v6+v167;
            v172 = v170;
            float * v175;
            float * v173;
            v173 = v122+v169;
            v175 = v173;
            long v176;
            v176 = 0l;
            #pragma unroll
            while (while_method_2(v176)){
                long v178;
                v178 = 0l;
                #pragma unroll
                while (while_method_1(v178)){
                    assert("Tensor range check" && 0 <= v176 && v176 < 8l);
                    assert("Tensor range check" && 0 <= v178 && v178 < 1l);
                    long v180;
                    v180 = 4l * v178;
                    long v181;
                    v181 = 136l * v176;
                    long v182;
                    v182 = v181 + v180;
                    long v183;
                    v183 = 512l * v176;
                    long v184;
                    v184 = v183 + v180;
                    int4* v185;
                    v185 = reinterpret_cast<int4*>(v175 + v184);
                    int4* v186;
                    v186 = reinterpret_cast<int4*>(v172 + v182);
                    assert("Pointer alignment check" && (unsigned long long)(v185) % 4l == 0 && (unsigned long long)(v186) % 4l == 0);
                    *v186 = *v185;
                    v178 += 1l ;
                }
                v176 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v187[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v188[8l];
            long v189;
            v189 = 0l;
            #pragma unroll
            while (while_method_2(v189)){
                long v191;
                v191 = 0l;
                #pragma unroll
                while (while_method_2(v191)){
                    assert("Tensor range check" && 0 <= v189 && v189 < 8l);
                    assert("Tensor range check" && 0 <= v191 && v191 < 8l);
                    long v193;
                    v193 = 8l * v189;
                    long v194;
                    v194 = v193 + v191;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v195 = v187[v194];
                    assert("Tensor range check" && 0 <= v189 && v189 < 8l);
                    long v196;
                    v196 = 16l * v189;
                    assert("Tensor range check" && 0 <= v191 && v191 < 8l);
                    long v197;
                    v197 = 1088l * v191;
                    long v198;
                    v198 = v197 + v196;
                    long v199;
                    v199 = 0l;
                    #pragma unroll
                    while (while_method_3(v199)){
                        long v201;
                        v201 = 0l;
                        #pragma unroll
                        while (while_method_3(v201)){
                            assert("Tensor range check" && 0 <= v199 && v199 < 2l);
                            assert("Tensor range check" && 0 <= v201 && v201 < 2l);
                            long v203;
                            v203 = 8l * v201;
                            long v204;
                            v204 = v203 + v198;
                            long v205;
                            v205 = 544l * v199;
                            long v206;
                            v206 = v205 + v204;
                            float v207;
                            v207 = v42[v206];
                            bool v208;
                            v208 = 0l <= v201;
                            bool v210;
                            if (v208){
                                bool v209;
                                v209 = v201 < 2l;
                                v210 = v209;
                            } else {
                                v210 = false;
                            }
                            bool v211;
                            v211 = v210 == false;
                            if (v211){
                                assert("The indices should be inside the range of the dimension." && v210);
                            } else {
                            }
                            bool v213;
                            v213 = 0l <= v199;
                            bool v215;
                            if (v213){
                                bool v214;
                                v214 = v199 < 2l;
                                v215 = v214;
                            } else {
                                v215 = false;
                            }
                            bool v216;
                            v216 = v215 == false;
                            if (v216){
                                assert("The indices should be inside the range of the dimension." && v215);
                            } else {
                            }
                            long v218;
                            v218 = v199 * 2l;
                            long v219;
                            v219 = v201 + v218;
                            v195.x[v219] = wmma::__float_to_tf32(v207);
                            v201 += 1l ;
                        }
                        v199 += 1l ;
                    }
                    __syncthreads();
                    v191 += 1l ;
                }
                v189 += 1l ;
            }
            long v220;
            v220 = 0l;
            #pragma unroll
            while (while_method_1(v220)){
                long v222;
                v222 = 0l;
                #pragma unroll
                while (while_method_2(v222)){
                    assert("Tensor range check" && 0 <= v220 && v220 < 1l);
                    assert("Tensor range check" && 0 <= v222 && v222 < 8l);
                    long v224;
                    v224 = 8l * v220;
                    long v225;
                    v225 = v224 + v222;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v226 = v188[v225];
                    assert("Tensor range check" && 0 <= v220 && v220 < 1l);
                    long v227;
                    v227 = 16l * v220;
                    assert("Tensor range check" && 0 <= v222 && v222 < 8l);
                    long v228;
                    v228 = 1088l * v222;
                    long v229;
                    v229 = v228 + v227;
                    long v230;
                    v230 = 0l;
                    #pragma unroll
                    while (while_method_3(v230)){
                        long v232;
                        v232 = 0l;
                        #pragma unroll
                        while (while_method_3(v232)){
                            assert("Tensor range check" && 0 <= v230 && v230 < 2l);
                            assert("Tensor range check" && 0 <= v232 && v232 < 2l);
                            long v234;
                            v234 = 544l * v232;
                            long v235;
                            v235 = v234 + v229;
                            long v236;
                            v236 = 8l * v230;
                            long v237;
                            v237 = v236 + v235;
                            float v238;
                            v238 = v57[v237];
                            bool v239;
                            v239 = 0l <= v232;
                            bool v241;
                            if (v239){
                                bool v240;
                                v240 = v232 < 2l;
                                v241 = v240;
                            } else {
                                v241 = false;
                            }
                            bool v242;
                            v242 = v241 == false;
                            if (v242){
                                assert("The indices should be inside the range of the dimension." && v241);
                            } else {
                            }
                            bool v244;
                            v244 = 0l <= v230;
                            bool v246;
                            if (v244){
                                bool v245;
                                v245 = v230 < 2l;
                                v246 = v245;
                            } else {
                                v246 = false;
                            }
                            bool v247;
                            v247 = v246 == false;
                            if (v247){
                                assert("The indices should be inside the range of the dimension." && v246);
                            } else {
                            }
                            long v249;
                            v249 = v230 * 2l;
                            long v250;
                            v250 = v232 + v249;
                            v226.x[v250] = wmma::__float_to_tf32(v238);
                            v232 += 1l ;
                        }
                        v230 += 1l ;
                    }
                    __syncthreads();
                    v222 += 1l ;
                }
                v220 += 1l ;
            }
            long v251;
            v251 = 0l;
            #pragma unroll
            while (while_method_2(v251)){
                long v253;
                v253 = 0l;
                #pragma unroll
                while (while_method_1(v253)){
                    long v255;
                    v255 = 0l;
                    #pragma unroll
                    while (while_method_2(v255)){
                        assert("Tensor range check" && 0 <= v251 && v251 < 8l);
                        assert("Tensor range check" && 0 <= v253 && v253 < 1l);
                        long v257;
                        v257 = v251 + v253;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v258 = v58[v257];
                        assert("Tensor range check" && 0 <= v251 && v251 < 8l);
                        assert("Tensor range check" && 0 <= v255 && v255 < 8l);
                        long v259;
                        v259 = 8l * v251;
                        long v260;
                        v260 = v259 + v255;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v261 = v187[v260];
                        assert("Tensor range check" && 0 <= v253 && v253 < 1l);
                        assert("Tensor range check" && 0 <= v255 && v255 < 8l);
                        long v262;
                        v262 = 8l * v253;
                        long v263;
                        v263 = v262 + v255;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v264 = v188[v263];
                        wmma::mma_sync(v258, v261, v264, v258);
                        v255 += 1l ;
                    }
                    v253 += 1l ;
                }
                v251 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v115 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v265;
        v265 = threadIdx.x;
        long v266;
        v266 = v265 % 32l;
        long v267;
        v267 = v265 / 32l;
        long v268;
        v268 = v267 % 8l;
        long v269;
        v269 = v267 / 8l;
        bool v270;
        v270 = v269 == 0l;
        bool v271;
        v271 = v270 == false;
        if (v271){
            assert("The index has to be in the range of the dimension." && v270);
        } else {
        }
        assert("Tensor range check" && 0 <= v268 && v268 < 8l);
        assert("Tensor range check" && 0 <= v266 && v266 < 32l);
        long v273;
        v273 = 4l * v266;
        long v274;
        v274 = 2176l * v268;
        long v275;
        v275 = v274 + v273;
        long v276;
        v276 = 8192l * v268;
        long v277;
        v277 = v276 + v273;
        float * v280;
        float * v278;
        v278 = v12+v275;
        v280 = v278;
        float * v283;
        float * v281;
        v281 = v74+v277;
        v283 = v281;
        long v284;
        v284 = 0l;
        #pragma unroll
        while (while_method_0(v284)){
            long v286;
            v286 = 0l;
            #pragma unroll
            while (while_method_1(v286)){
                assert("Tensor range check" && 0 <= v284 && v284 < 16l);
                assert("Tensor range check" && 0 <= v286 && v286 < 1l);
                long v288;
                v288 = 4l * v286;
                long v289;
                v289 = 136l * v284;
                long v290;
                v290 = v289 + v288;
                long v291;
                v291 = 512l * v284;
                long v292;
                v292 = v291 + v288;
                int4* v293;
                v293 = reinterpret_cast<int4*>(v283 + v292);
                int4* v294;
                v294 = reinterpret_cast<int4*>(v280 + v290);
                assert("Pointer alignment check" && (unsigned long long)(v293) % 4l == 0 && (unsigned long long)(v294) % 4l == 0);
                *v294 = *v293;
                v286 += 1l ;
            }
            v284 += 1l ;
        }
        __syncthreads();
        long v295;
        v295 = 0l;
        #pragma unroll
        while (while_method_2(v295)){
            long v297;
            v297 = 0l;
            #pragma unroll
            while (while_method_1(v297)){
                assert("Tensor range check" && 0 <= v295 && v295 < 8l);
                assert("Tensor range check" && 0 <= v297 && v297 < 1l);
                long v299;
                v299 = v295 + v297;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v300 = v58[v299];
                assert("Tensor range check" && 0 <= v295 && v295 < 8l);
                assert("Tensor range check" && 0 <= v297 && v297 < 1l);
                long v301;
                v301 = 16l * v297;
                long v302;
                v302 = 2176l * v295;
                long v303;
                v303 = v302 + v301;
                float * v304;
                v304 = v26 + v303;
                wmma::store_matrix_sync(v304, v300, 136l, wmma::mem_row_major);
                v297 += 1l ;
            }
            v295 += 1l ;
        }
        __syncthreads();
        long v305;
        v305 = threadIdx.x;
        long v306;
        v306 = v305 % 32l;
        long v307;
        v307 = v305 / 32l;
        long v308;
        v308 = v307 % 8l;
        long v309;
        v309 = v307 / 8l;
        bool v310;
        v310 = v309 == 0l;
        bool v311;
        v311 = v310 == false;
        if (v311){
            assert("The index has to be in the range of the dimension." && v310);
        } else {
        }
        assert("Tensor range check" && 0 <= v308 && v308 < 8l);
        assert("Tensor range check" && 0 <= v306 && v306 < 32l);
        long v313;
        v313 = 4l * v306;
        long v314;
        v314 = 8192l * v308;
        long v315;
        v315 = v314 + v313;
        long v316;
        v316 = 2176l * v308;
        long v317;
        v317 = v316 + v313;
        float * v320;
        float * v318;
        v318 = v74+v315;
        v320 = v318;
        float * v323;
        float * v321;
        v321 = v12+v317;
        v323 = v321;
        long v324;
        v324 = 0l;
        #pragma unroll
        while (while_method_0(v324)){
            long v326;
            v326 = 0l;
            #pragma unroll
            while (while_method_1(v326)){
                assert("Tensor range check" && 0 <= v324 && v324 < 16l);
                assert("Tensor range check" && 0 <= v326 && v326 < 1l);
                long v328;
                v328 = 4l * v326;
                long v329;
                v329 = 512l * v324;
                long v330;
                v330 = v329 + v328;
                long v331;
                v331 = 136l * v324;
                long v332;
                v332 = v331 + v328;
                int4* v333;
                v333 = reinterpret_cast<int4*>(v323 + v332);
                int4* v334;
                v334 = reinterpret_cast<int4*>(v320 + v330);
                assert("Pointer alignment check" && (unsigned long long)(v333) % 4l == 0 && (unsigned long long)(v334) % 4l == 0);
                *v334 = *v333;
                v326 += 1l ;
            }
            v324 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v60 += 24l ;
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
        v19 = cp.transpose(v18)
        del v18
        v20 = v5.reshape((512, 512))
        v21 = v0.reshape((512, 512))
        v22 = (cp.matmul(v19,v20) + v21).flatten()
        del v19, v20, v21
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
