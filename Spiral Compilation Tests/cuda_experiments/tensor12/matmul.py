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
__device__ inline bool while_method_3(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
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
    float * v30;
    float * v28;
    v28 = v6+v27;
    v30 = v28;
    assert("Tensor range check" && 0 <= v15 && v15 < 8l);
    long v31;
    v31 = 1088l * v15;
    float * v34;
    float * v32;
    v32 = v9+v31;
    v34 = v32;
    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v35[8l];
    long v36;
    v36 = blockIdx.x;
    long v37;
    v37 = v36;
    while (while_method_0(v37)){
        long v39;
        v39 = v37 % 4l;
        long v40;
        v40 = v37 / 4l;
        long v41;
        v41 = v40 % 4l;
        long v42;
        v42 = v40 / 4l;
        bool v43;
        v43 = v42 == 0l;
        bool v44;
        v44 = v43 == false;
        if (v44){
            assert("The index has to be in the range of the dimension." && v43);
        } else {
        }
        assert("Tensor range check" && 0 <= v41 && v41 < 4l);
        assert("Tensor range check" && 0 <= v39 && v39 < 4l);
        long v46;
        v46 = 128l * v39;
        long v47;
        v47 = 65536l * v41;
        long v48;
        v48 = v47 + v46;
        float * v51;
        float * v49;
        v49 = v2+v48;
        v51 = v49;
        // Pushing the loop unrolling to: 0
        long v52;
        v52 = threadIdx.x;
        long v53;
        v53 = v52 % 32l;
        long v54;
        v54 = v52 / 32l;
        long v55;
        v55 = v54 % 8l;
        long v56;
        v56 = v54 / 8l;
        bool v57;
        v57 = v56 == 0l;
        bool v58;
        v58 = v57 == false;
        if (v58){
            assert("The index has to be in the range of the dimension." && v57);
        } else {
        }
        assert("Tensor range check" && 0 <= v55 && v55 < 8l);
        assert("Tensor range check" && 0 <= v53 && v53 < 32l);
        long v60;
        v60 = 4l * v53;
        long v61;
        v61 = 2176l * v55;
        long v62;
        v62 = v61 + v60;
        long v63;
        v63 = 8192l * v55;
        long v64;
        v64 = v63 + v60;
        float * v67;
        float * v65;
        v65 = v12+v62;
        v67 = v65;
        float * v70;
        float * v68;
        v68 = v51+v64;
        v70 = v68;
        long v71;
        v71 = 0l;
        #pragma unroll
        while (while_method_0(v71)){
            long v73;
            v73 = 0l;
            #pragma unroll
            while (while_method_1(v73)){
                assert("Tensor range check" && 0 <= v71 && v71 < 16l);
                assert("Tensor range check" && 0 <= v73 && v73 < 1l);
                long v75;
                v75 = 4l * v73;
                long v76;
                v76 = 136l * v71;
                long v77;
                v77 = v76 + v75;
                long v78;
                v78 = 512l * v71;
                long v79;
                v79 = v78 + v75;
                int4* v80;
                v80 = reinterpret_cast<int4*>(v70 + v79);
                int4* v81;
                v81 = reinterpret_cast<int4*>(v67 + v77);
                assert("Pointer alignment check" && (unsigned long long)(v80) % 4l == 0 && (unsigned long long)(v81) % 4l == 0);
                *v81 = *v80;
                v73 += 1l ;
            }
            v71 += 1l ;
        }
        __syncthreads();
        long v82;
        v82 = 0l;
        #pragma unroll
        while (while_method_2(v82)){
            long v84;
            v84 = 0l;
            #pragma unroll
            while (while_method_1(v84)){
                assert("Tensor range check" && 0 <= v82 && v82 < 8l);
                assert("Tensor range check" && 0 <= v84 && v84 < 1l);
                long v86;
                v86 = v82 + v84;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v87 = v35[v86];
                assert("Tensor range check" && 0 <= v82 && v82 < 8l);
                assert("Tensor range check" && 0 <= v84 && v84 < 1l);
                long v88;
                v88 = 16l * v84;
                long v89;
                v89 = 2176l * v82;
                long v90;
                v90 = v89 + v88;
                float * v91;
                v91 = v26 + v90;
                wmma::load_matrix_sync(v87, v91, 136l, wmma::mem_row_major);
                v84 += 1l ;
            }
            v82 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        long v92;
        v92 = 0l;
        while (while_method_2(v92)){
            // Pushing the loop unrolling to: 0
            assert("Tensor range check" && 0 <= v41 && v41 < 4l);
            assert("Tensor range check" && 0 <= v92 && v92 < 8l);
            long v94;
            v94 = 64l * v92;
            long v95;
            v95 = v94 + v47;
            float * v98;
            float * v96;
            v96 = v0+v95;
            v98 = v96;
            assert("Tensor range check" && 0 <= v39 && v39 < 4l);
            long v99;
            v99 = 65536l * v39;
            assert("Tensor range check" && 0 <= v92 && v92 < 8l);
            long v100;
            v100 = v94 + v99;
            float * v103;
            float * v101;
            v101 = v1+v100;
            v103 = v101;
            long v104;
            v104 = threadIdx.x;
            long v105;
            v105 = v104 % 16l;
            long v106;
            v106 = v104 / 16l;
            long v107;
            v107 = v106 % 16l;
            long v108;
            v108 = v106 / 16l;
            bool v109;
            v109 = v108 == 0l;
            bool v110;
            v110 = v109 == false;
            if (v110){
                assert("The index has to be in the range of the dimension." && v109);
            } else {
            }
            assert("Tensor range check" && 0 <= v107 && v107 < 16l);
            assert("Tensor range check" && 0 <= v105 && v105 < 16l);
            long v112;
            v112 = 4l * v105;
            long v113;
            v113 = 544l * v107;
            long v114;
            v114 = v113 + v112;
            long v115;
            v115 = 4096l * v107;
            long v116;
            v116 = v115 + v112;
            float * v119;
            float * v117;
            v117 = v9+v114;
            v119 = v117;
            float * v122;
            float * v120;
            v120 = v103+v116;
            v122 = v120;
            long v123;
            v123 = 0l;
            #pragma unroll
            while (while_method_2(v123)){
                long v125;
                v125 = 0l;
                #pragma unroll
                while (while_method_1(v125)){
                    assert("Tensor range check" && 0 <= v123 && v123 < 8l);
                    assert("Tensor range check" && 0 <= v125 && v125 < 1l);
                    long v127;
                    v127 = 4l * v125;
                    long v128;
                    v128 = 68l * v123;
                    long v129;
                    v129 = v128 + v127;
                    long v130;
                    v130 = 512l * v123;
                    long v131;
                    v131 = v130 + v127;
                    int4* v132;
                    v132 = reinterpret_cast<int4*>(v122 + v131);
                    int4* v133;
                    v133 = reinterpret_cast<int4*>(v119 + v129);
                    assert("Pointer alignment check" && (unsigned long long)(v132) % 4l == 0 && (unsigned long long)(v133) % 4l == 0);
                    *v133 = *v132;
                    v125 += 1l ;
                }
                v123 += 1l ;
            }
            long v134;
            v134 = threadIdx.x;
            long v135;
            v135 = v134 % 16l;
            long v136;
            v136 = v134 / 16l;
            long v137;
            v137 = v136 % 16l;
            long v138;
            v138 = v136 / 16l;
            bool v139;
            v139 = v138 == 0l;
            bool v140;
            v140 = v139 == false;
            if (v140){
                assert("The index has to be in the range of the dimension." && v139);
            } else {
            }
            assert("Tensor range check" && 0 <= v137 && v137 < 16l);
            assert("Tensor range check" && 0 <= v135 && v135 < 16l);
            long v142;
            v142 = 4l * v135;
            long v143;
            v143 = 544l * v137;
            long v144;
            v144 = v143 + v142;
            long v145;
            v145 = 4096l * v137;
            long v146;
            v146 = v145 + v142;
            float * v149;
            float * v147;
            v147 = v6+v144;
            v149 = v147;
            float * v152;
            float * v150;
            v150 = v98+v146;
            v152 = v150;
            long v153;
            v153 = 0l;
            #pragma unroll
            while (while_method_2(v153)){
                long v155;
                v155 = 0l;
                #pragma unroll
                while (while_method_1(v155)){
                    assert("Tensor range check" && 0 <= v153 && v153 < 8l);
                    assert("Tensor range check" && 0 <= v155 && v155 < 1l);
                    long v157;
                    v157 = 4l * v155;
                    long v158;
                    v158 = 68l * v153;
                    long v159;
                    v159 = v158 + v157;
                    long v160;
                    v160 = 512l * v153;
                    long v161;
                    v161 = v160 + v157;
                    int4* v162;
                    v162 = reinterpret_cast<int4*>(v152 + v161);
                    int4* v163;
                    v163 = reinterpret_cast<int4*>(v149 + v159);
                    assert("Pointer alignment check" && (unsigned long long)(v162) % 4l == 0 && (unsigned long long)(v163) % 4l == 0);
                    *v163 = *v162;
                    v155 += 1l ;
                }
                v153 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v164[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v165[8l];
            long v166;
            v166 = 0l;
            #pragma unroll
            while (while_method_2(v166)){
                long v168;
                v168 = 0l;
                #pragma unroll
                while (while_method_2(v168)){
                    assert("Tensor range check" && 0 <= v166 && v166 < 8l);
                    long v170;
                    v170 = 1088l * v166;
                    assert("Tensor range check" && 0 <= v168 && v168 < 8l);
                    long v171;
                    v171 = 8l * v168;
                    long v172;
                    v172 = v171 + v170;
                    assert("Tensor range check" && 0 <= v166 && v166 < 8l);
                    assert("Tensor range check" && 0 <= v168 && v168 < 8l);
                    long v173;
                    v173 = 8l * v166;
                    long v174;
                    v174 = v173 + v168;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v175 = v164[v174];
                    long v176;
                    v176 = threadIdx.x;
                    long v177;
                    v177 = v176 % 32l;
                    long v178;
                    v178 = v177 % 4l;
                    long v179;
                    v179 = v177 / 4l;
                    long v180;
                    v180 = v179 % 8l;
                    long v181;
                    v181 = v179 / 8l;
                    bool v182;
                    v182 = v181 == 0l;
                    bool v183;
                    v183 = v182 == false;
                    if (v183){
                        assert("The index has to be in the range of the dimension." && v182);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v180 && v180 < 8l);
                    assert("Tensor range check" && 0 <= v178 && v178 < 4l);
                    long v185;
                    v185 = v178 + v172;
                    long v186;
                    v186 = 68l * v180;
                    long v187;
                    v187 = v186 + v185;
                    float * v190;
                    float * v188;
                    v188 = v30+v187;
                    v190 = v188;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v191 = v175;
                    long v192;
                    v192 = v191.num_elements;
                    long v193;
                    v193 = 0l;
                    #pragma unroll
                    while (while_method_3(v192, v193)){
                        long v195;
                        v195 = v193 % 2l;
                        long v196;
                        v196 = v193 / 2l;
                        long v197;
                        v197 = v196 % 2l;
                        long v198;
                        v198 = v196 / 2l;
                        bool v199;
                        v199 = v198 == 0l;
                        bool v200;
                        v200 = v199 == false;
                        if (v200){
                            assert("The index has to be in the range of the dimension." && v199);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v197 && v197 < 2l);
                        assert("Tensor range check" && 0 <= v195 && v195 < 2l);
                        long v202;
                        v202 = 4l * v195;
                        long v203;
                        v203 = 544l * v197;
                        long v204;
                        v204 = v203 + v202;
                        float v205;
                        v205 = v190[v204];
                        v175.x[v193] = wmma::__float_to_tf32(v205);
                        v193 += 1l ;
                    }
                    v168 += 1l ;
                }
                v166 += 1l ;
            }
            long v206;
            v206 = 0l;
            #pragma unroll
            while (while_method_1(v206)){
                long v208;
                v208 = 0l;
                #pragma unroll
                while (while_method_2(v208)){
                    assert("Tensor range check" && 0 <= v206 && v206 < 1l);
                    long v210;
                    v210 = 1088l * v206;
                    assert("Tensor range check" && 0 <= v208 && v208 < 8l);
                    long v211;
                    v211 = 8l * v208;
                    long v212;
                    v212 = v211 + v210;
                    assert("Tensor range check" && 0 <= v206 && v206 < 1l);
                    assert("Tensor range check" && 0 <= v208 && v208 < 8l);
                    long v213;
                    v213 = 8l * v206;
                    long v214;
                    v214 = v213 + v208;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v215 = v165[v214];
                    long v216;
                    v216 = threadIdx.x;
                    long v217;
                    v217 = v216 % 32l;
                    long v218;
                    v218 = v217 % 4l;
                    long v219;
                    v219 = v217 / 4l;
                    long v220;
                    v220 = v219 % 8l;
                    long v221;
                    v221 = v219 / 8l;
                    bool v222;
                    v222 = v221 == 0l;
                    bool v223;
                    v223 = v222 == false;
                    if (v223){
                        assert("The index has to be in the range of the dimension." && v222);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v220 && v220 < 8l);
                    assert("Tensor range check" && 0 <= v218 && v218 < 4l);
                    long v225;
                    v225 = v218 + v212;
                    long v226;
                    v226 = 68l * v220;
                    long v227;
                    v227 = v226 + v225;
                    float * v230;
                    float * v228;
                    v228 = v34+v227;
                    v230 = v228;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v231 = v215;
                    long v232;
                    v232 = v231.num_elements;
                    long v233;
                    v233 = 0l;
                    #pragma unroll
                    while (while_method_3(v232, v233)){
                        long v235;
                        v235 = v233 % 2l;
                        long v236;
                        v236 = v233 / 2l;
                        long v237;
                        v237 = v236 % 2l;
                        long v238;
                        v238 = v236 / 2l;
                        bool v239;
                        v239 = v238 == 0l;
                        bool v240;
                        v240 = v239 == false;
                        if (v240){
                            assert("The index has to be in the range of the dimension." && v239);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v237 && v237 < 2l);
                        assert("Tensor range check" && 0 <= v235 && v235 < 2l);
                        long v242;
                        v242 = 4l * v235;
                        long v243;
                        v243 = 544l * v237;
                        long v244;
                        v244 = v243 + v242;
                        float v245;
                        v245 = v230[v244];
                        v215.x[v233] = wmma::__float_to_tf32(v245);
                        v233 += 1l ;
                    }
                    v208 += 1l ;
                }
                v206 += 1l ;
            }
            long v246;
            v246 = 0l;
            #pragma unroll
            while (while_method_2(v246)){
                long v248;
                v248 = 0l;
                #pragma unroll
                while (while_method_1(v248)){
                    long v250;
                    v250 = 0l;
                    #pragma unroll
                    while (while_method_2(v250)){
                        assert("Tensor range check" && 0 <= v246 && v246 < 8l);
                        assert("Tensor range check" && 0 <= v248 && v248 < 1l);
                        long v252;
                        v252 = v246 + v248;
                        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v253 = v35[v252];
                        assert("Tensor range check" && 0 <= v246 && v246 < 8l);
                        assert("Tensor range check" && 0 <= v250 && v250 < 8l);
                        long v254;
                        v254 = 8l * v246;
                        long v255;
                        v255 = v254 + v250;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v256 = v164[v255];
                        assert("Tensor range check" && 0 <= v248 && v248 < 1l);
                        assert("Tensor range check" && 0 <= v250 && v250 < 8l);
                        long v257;
                        v257 = 8l * v248;
                        long v258;
                        v258 = v257 + v250;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v259 = v165[v258];
                        wmma::mma_sync(v253, v256, v259, v253);
                        v250 += 1l ;
                    }
                    v248 += 1l ;
                }
                v246 += 1l ;
            }
            // Poping the loop unrolling to: 0
            v92 += 1l ;
        }
        // Pushing the loop unrolling to: 0
        long v260;
        v260 = threadIdx.x;
        long v261;
        v261 = v260 % 32l;
        long v262;
        v262 = v260 / 32l;
        long v263;
        v263 = v262 % 8l;
        long v264;
        v264 = v262 / 8l;
        bool v265;
        v265 = v264 == 0l;
        bool v266;
        v266 = v265 == false;
        if (v266){
            assert("The index has to be in the range of the dimension." && v265);
        } else {
        }
        assert("Tensor range check" && 0 <= v263 && v263 < 8l);
        assert("Tensor range check" && 0 <= v261 && v261 < 32l);
        long v268;
        v268 = 4l * v261;
        long v269;
        v269 = 2176l * v263;
        long v270;
        v270 = v269 + v268;
        long v271;
        v271 = 8192l * v263;
        long v272;
        v272 = v271 + v268;
        float * v275;
        float * v273;
        v273 = v12+v270;
        v275 = v273;
        float * v278;
        float * v276;
        v276 = v51+v272;
        v278 = v276;
        long v279;
        v279 = 0l;
        #pragma unroll
        while (while_method_0(v279)){
            long v281;
            v281 = 0l;
            #pragma unroll
            while (while_method_1(v281)){
                assert("Tensor range check" && 0 <= v279 && v279 < 16l);
                assert("Tensor range check" && 0 <= v281 && v281 < 1l);
                long v283;
                v283 = 4l * v281;
                long v284;
                v284 = 136l * v279;
                long v285;
                v285 = v284 + v283;
                long v286;
                v286 = 512l * v279;
                long v287;
                v287 = v286 + v283;
                int4* v288;
                v288 = reinterpret_cast<int4*>(v278 + v287);
                int4* v289;
                v289 = reinterpret_cast<int4*>(v275 + v285);
                assert("Pointer alignment check" && (unsigned long long)(v288) % 4l == 0 && (unsigned long long)(v289) % 4l == 0);
                *v289 = *v288;
                v281 += 1l ;
            }
            v279 += 1l ;
        }
        __syncthreads();
        long v290;
        v290 = 0l;
        #pragma unroll
        while (while_method_2(v290)){
            long v292;
            v292 = 0l;
            #pragma unroll
            while (while_method_1(v292)){
                assert("Tensor range check" && 0 <= v290 && v290 < 8l);
                assert("Tensor range check" && 0 <= v292 && v292 < 1l);
                long v294;
                v294 = v290 + v292;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v295 = v35[v294];
                assert("Tensor range check" && 0 <= v290 && v290 < 8l);
                assert("Tensor range check" && 0 <= v292 && v292 < 1l);
                long v296;
                v296 = 16l * v292;
                long v297;
                v297 = 2176l * v290;
                long v298;
                v298 = v297 + v296;
                float * v299;
                v299 = v26 + v298;
                wmma::store_matrix_sync(v299, v295, 136l, wmma::mem_row_major);
                v292 += 1l ;
            }
            v290 += 1l ;
        }
        __syncthreads();
        long v300;
        v300 = threadIdx.x;
        long v301;
        v301 = v300 % 32l;
        long v302;
        v302 = v300 / 32l;
        long v303;
        v303 = v302 % 8l;
        long v304;
        v304 = v302 / 8l;
        bool v305;
        v305 = v304 == 0l;
        bool v306;
        v306 = v305 == false;
        if (v306){
            assert("The index has to be in the range of the dimension." && v305);
        } else {
        }
        assert("Tensor range check" && 0 <= v303 && v303 < 8l);
        assert("Tensor range check" && 0 <= v301 && v301 < 32l);
        long v308;
        v308 = 4l * v301;
        long v309;
        v309 = 8192l * v303;
        long v310;
        v310 = v309 + v308;
        long v311;
        v311 = 2176l * v303;
        long v312;
        v312 = v311 + v308;
        float * v315;
        float * v313;
        v313 = v51+v310;
        v315 = v313;
        float * v318;
        float * v316;
        v316 = v12+v312;
        v318 = v316;
        long v319;
        v319 = 0l;
        #pragma unroll
        while (while_method_0(v319)){
            long v321;
            v321 = 0l;
            #pragma unroll
            while (while_method_1(v321)){
                assert("Tensor range check" && 0 <= v319 && v319 < 16l);
                assert("Tensor range check" && 0 <= v321 && v321 < 1l);
                long v323;
                v323 = 4l * v321;
                long v324;
                v324 = 512l * v319;
                long v325;
                v325 = v324 + v323;
                long v326;
                v326 = 136l * v319;
                long v327;
                v327 = v326 + v323;
                int4* v328;
                v328 = reinterpret_cast<int4*>(v318 + v327);
                int4* v329;
                v329 = reinterpret_cast<int4*>(v315 + v325);
                assert("Pointer alignment check" && (unsigned long long)(v328) % 4l == 0 && (unsigned long long)(v329) % 4l == 0);
                *v329 = *v328;
                v321 += 1l ;
            }
            v319 += 1l ;
        }
        __syncthreads();
        // Poping the loop unrolling to: 0
        v37 += 24l ;
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
