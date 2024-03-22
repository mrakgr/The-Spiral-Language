kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
#include <cooperative_groups/reduce.h>
#include <cooperative_groups/scan.h>
struct Tuple0;
typedef float (* Fun0)(float, float);
struct Tuple1;
typedef Tuple1 (* Fun1)(Tuple1, Tuple1);
struct Tuple0 {
    long v0;
    float v1;
    __device__ Tuple0(long t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    float v0;
    long v1;
    __device__ Tuple1(float t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 512l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ float ClosureMethod0(float tup0, float tup1){
    float v0 = tup0; float v1 = tup1;
    float v2;
    v2 = v0 + v1;
    return v2;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ Tuple1 ClosureMethod1(Tuple1 tup0, Tuple1 tup1){
    float v0 = tup0.v0; long v1 = tup0.v1; float v2 = tup1.v0; long v3 = tup1.v1;
    bool v4;
    v4 = v0 > v2;
    if (v4){
        return Tuple1(v0, v1);
    } else {
        return Tuple1(v2, v3);
    }
}
__device__ float ClosureMethod2(float tup0, float tup1){
    float v0 = tup0; float v1 = tup1;
    float v2;
    v2 = v0 + v1;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3, float * v4, float * v5, long * v6) {
    auto v7 = cooperative_groups::this_thread_block();
    float v8;
    v8 = 0.0f;
    long v9;
    v9 = threadIdx.x;
    long v10;
    v10 = v9;
    while (while_method_0(v10)){
        bool v12;
        v12 = 0l <= v10;
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The index needs to be zero or positive." && v12);
        } else {
        }
        long v15;
        v15 = v10 % 256l;
        long v16;
        v16 = v10 / 256l;
        bool v17;
        v17 = v16 < 2l;
        bool v18;
        v18 = v17 == false;
        if (v18){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v17);
        } else {
        }
        assert("Tensor range check" && 0 <= v16 && v16 < 2l);
        assert("Tensor range check" && 0 <= v15 && v15 < 256l);
        long v20;
        v20 = 4l * v15;
        long v21;
        v21 = 1024l * v16;
        long v22;
        v22 = v21 + v20;
        float v23[4l];
        int4* v24;
        v24 = reinterpret_cast<int4*>(v0 + v22);
        int4* v25;
        v25 = reinterpret_cast<int4*>(v23 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v24) % 4l == 0 && (unsigned long long)(v25) % 4l == 0);
        *v25 = *v24;
        long v26; float v27;
        Tuple0 tmp0 = Tuple0(0l, v8);
        v26 = tmp0.v0; v27 = tmp0.v1;
        while (while_method_1(v26)){
            assert("Tensor range check" && 0 <= v26 && v26 < 4l);
            float v29;
            v29 = v23[v26];
            float v30;
            v30 = v29 + v27;
            v27 = v30;
            v26 += 1l ;
        }
        v8 = v27;
        v10 += 512l ;
    }
    auto v31 = cooperative_groups::coalesced_threads();
    Fun0 v32;
    v32 = ClosureMethod0;
    float v33;
    v33 = cooperative_groups::reduce(v31, v8, v32);
    long v34;
    v34 = threadIdx.x;
    long v35;
    v35 = v34 / 32l;
    __shared__ float v36[16l];
    assert("Tensor range check" && 0 <= v35 && v35 < 16l);
    v36[v35] = v33;
    __syncthreads();
    long v37;
    v37 = threadIdx.x;
    long v38;
    v38 = v37 % 32l;
    bool v39;
    v39 = v35 == 0l;
    bool v41;
    if (v39){
        bool v40;
        v40 = v38 < 16l;
        v41 = v40;
    } else {
        v41 = false;
    }
    if (v41){
        auto v42 = cooperative_groups::coalesced_threads();
        assert("Tensor range check" && 0 <= v38 && v38 < 16l);
        float v43;
        v43 = v36[v38];
        float v44;
        v44 = cooperative_groups::reduce(v42, v43, v32);
        v1[0l] = v44;
    } else {
    }
    __syncthreads();
    long v45;
    v45 = threadIdx.x;
    bool v46;
    v46 = 0l <= v45;
    bool v47;
    v47 = v46 == false;
    if (v47){
        assert("The index needs to be zero or positive." && v46);
    } else {
    }
    long v49;
    v49 = v45 % 256l;
    long v50;
    v50 = v45 / 256l;
    bool v51;
    v51 = v50 < 2l;
    bool v52;
    v52 = v51 == false;
    if (v52){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v51);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v54 = cooperative_groups::tiled_partition<256l>(v7);
    assert("Tensor range check" && 0 <= v50 && v50 < 2l);
    assert("Tensor range check" && 0 <= v49 && v49 < 256l);
    long v55;
    v55 = 4l * v49;
    long v56;
    v56 = 1024l * v50;
    long v57;
    v57 = v56 + v55;
    assert("Tensor range check" && 0 <= v50 && v50 < 2l);
    assert("Tensor range check" && 0 <= v49 && v49 < 256l);
    long v58;
    v58 = 0l;
    while (while_method_2(v58)){
        assert("Tensor range check" && 0 <= v58 && v58 < 1l);
        long v60;
        v60 = 2048l * v58;
        long v61;
        v61 = v60 + v57;
        assert("Tensor range check" && 0 <= v58 && v58 < 1l);
        float v62[4l];
        long v63[4l];
        long v64;
        v64 = 0l;
        while (while_method_2(v64)){
            assert("Tensor range check" && 0 <= v64 && v64 < 1l);
            long v66;
            v66 = 4l * v64;
            assert("Tensor range check" && 0 <= v64 && v64 < 1l);
            long v67;
            v67 = 1024l * v64;
            long v68;
            v68 = v67 + v61;
            int4* v69;
            v69 = reinterpret_cast<int4*>(v0 + v68);
            int4* v70;
            v70 = reinterpret_cast<int4*>(v62 + v66);
            assert("Pointer alignment check" && (unsigned long long)(v69) % 4l == 0 && (unsigned long long)(v70) % 4l == 0);
            *v70 = *v69;
            v64 += 1l ;
        }
        long v71;
        v71 = 0l;
        while (while_method_2(v71)){
            long v73;
            v73 = 0l;
            while (while_method_1(v73)){
                bool v75;
                v75 = 0l <= v73;
                bool v77;
                if (v75){
                    bool v76;
                    v76 = v73 < 4l;
                    v77 = v76;
                } else {
                    v77 = false;
                }
                bool v78;
                v78 = v77 == false;
                if (v78){
                    assert("The indices should be inside the range of the dimension." && v77);
                } else {
                }
                bool v80;
                v80 = 0l <= v71;
                bool v82;
                if (v80){
                    bool v81;
                    v81 = v71 < 1l;
                    v82 = v81;
                } else {
                    v82 = false;
                }
                bool v83;
                v83 = v82 == false;
                if (v83){
                    assert("The indices should be inside the range of the dimension." && v82);
                } else {
                }
                long v85;
                v85 = v71 * 4l;
                long v86;
                v86 = v73 + v85;
                bool v87;
                v87 = 0l <= v49;
                bool v89;
                if (v87){
                    bool v88;
                    v88 = v49 < 256l;
                    v89 = v88;
                } else {
                    v89 = false;
                }
                bool v90;
                v90 = v89 == false;
                if (v90){
                    assert("The indices should be inside the range of the dimension." && v89);
                } else {
                }
                long v92;
                v92 = v49 * 4l;
                long v93;
                v93 = v86 + v92;
                assert("Tensor range check" && 0 <= v71 && v71 < 1l);
                assert("Tensor range check" && 0 <= v73 && v73 < 4l);
                long v94;
                v94 = 4l * v71;
                long v95;
                v95 = v94 + v73;
                v63[v95] = v93;
                v73 += 1l ;
            }
            v71 += 1l ;
        }
        float v96;
        v96 = 0.0f;
        long v97;
        v97 = 0l;
        while (while_method_2(v97)){
            long v99;
            v99 = 0l;
            while (while_method_1(v99)){
                assert("Tensor range check" && 0 <= v97 && v97 < 1l);
                assert("Tensor range check" && 0 <= v99 && v99 < 4l);
                long v101;
                v101 = 4l * v97;
                long v102;
                v102 = v101 + v99;
                float v103;
                v103 = v62[v102];
                float v104;
                v104 = v103 + v96;
                v96 = v104;
                v99 += 1l ;
            }
            v97 += 1l ;
        }
        auto v105 = cooperative_groups::coalesced_threads();
        float v106;
        v106 = cooperative_groups::reduce(v105, v96, v32);
        long v107;
        v107 = threadIdx.x;
        long v108;
        v108 = v107 / 32l;
        __shared__ float v109[16l];
        bool v110;
        v110 = 0l <= v108;
        bool v111;
        v111 = v110 == false;
        if (v111){
            assert("The index needs to be zero or positive." && v110);
        } else {
        }
        long v113;
        v113 = v108 % 8l;
        long v114;
        v114 = v108 / 8l;
        bool v115;
        v115 = v114 < 2l;
        bool v116;
        v116 = v115 == false;
        if (v116){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v115);
        } else {
        }
        assert("Tensor range check" && 0 <= v114 && v114 < 2l);
        assert("Tensor range check" && 0 <= v113 && v113 < 8l);
        long v118;
        v118 = 8l * v114;
        long v119;
        v119 = v118 + v113;
        v109[v119] = v106;
        v54.sync() ;
        long v120;
        v120 = threadIdx.x;
        long v121;
        v121 = v120 % 32l;
        bool v122;
        v122 = v121 < 8l;
        float v125;
        if (v122){
            assert("Tensor range check" && 0 <= v114 && v114 < 2l);
            assert("Tensor range check" && 0 <= v121 && v121 < 8l);
            long v123;
            v123 = v118 + v121;
            float v124;
            v124 = v109[v123];
            v125 = v124;
        } else {
            v125 = 0.0f;
        }
        v54.sync() ;
        float v126;
        v126 = cooperative_groups::reduce(v105, v125, v32);
        float v127;
        v127 = v126 / 1024.0f;
        float v128[4l];
        long v129;
        v129 = 0l;
        while (while_method_2(v129)){
            long v131;
            v131 = 0l;
            while (while_method_1(v131)){
                assert("Tensor range check" && 0 <= v129 && v129 < 1l);
                assert("Tensor range check" && 0 <= v131 && v131 < 4l);
                long v133;
                v133 = 4l * v129;
                long v134;
                v134 = v133 + v131;
                float v135;
                v135 = v62[v134];
                float v136;
                v136 = v135 - v127;
                float v137;
                v137 = exp(v136);
                assert("Tensor range check" && 0 <= v129 && v129 < 1l);
                assert("Tensor range check" && 0 <= v131 && v131 < 4l);
                v128[v134] = v137;
                v131 += 1l ;
            }
            v129 += 1l ;
        }
        float v138;
        v138 = 0.0f;
        long v139;
        v139 = 0l;
        while (while_method_2(v139)){
            long v141;
            v141 = 0l;
            while (while_method_1(v141)){
                assert("Tensor range check" && 0 <= v139 && v139 < 1l);
                assert("Tensor range check" && 0 <= v141 && v141 < 4l);
                long v143;
                v143 = 4l * v139;
                long v144;
                v144 = v143 + v141;
                float v145;
                v145 = v128[v144];
                float v146;
                v146 = v145 + v138;
                v138 = v146;
                v141 += 1l ;
            }
            v139 += 1l ;
        }
        auto v147 = cooperative_groups::coalesced_threads();
        float v148;
        v148 = cooperative_groups::reduce(v147, v138, v32);
        long v149;
        v149 = threadIdx.x;
        long v150;
        v150 = v149 / 32l;
        __shared__ float v151[16l];
        bool v152;
        v152 = 0l <= v150;
        bool v153;
        v153 = v152 == false;
        if (v153){
            assert("The index needs to be zero or positive." && v152);
        } else {
        }
        long v155;
        v155 = v150 % 8l;
        long v156;
        v156 = v150 / 8l;
        bool v157;
        v157 = v156 < 2l;
        bool v158;
        v158 = v157 == false;
        if (v158){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v157);
        } else {
        }
        assert("Tensor range check" && 0 <= v156 && v156 < 2l);
        assert("Tensor range check" && 0 <= v155 && v155 < 8l);
        long v160;
        v160 = 8l * v156;
        long v161;
        v161 = v160 + v155;
        v151[v161] = v148;
        v54.sync() ;
        long v162;
        v162 = threadIdx.x;
        long v163;
        v163 = v162 % 32l;
        bool v164;
        v164 = v163 < 8l;
        float v167;
        if (v164){
            assert("Tensor range check" && 0 <= v156 && v156 < 2l);
            assert("Tensor range check" && 0 <= v163 && v163 < 8l);
            long v165;
            v165 = v160 + v163;
            float v166;
            v166 = v151[v165];
            v167 = v166;
        } else {
            v167 = 0.0f;
        }
        v54.sync() ;
        float v168;
        v168 = cooperative_groups::reduce(v147, v167, v32);
        float v169[4l];
        long v170;
        v170 = 0l;
        while (while_method_2(v170)){
            long v172;
            v172 = 0l;
            while (while_method_1(v172)){
                assert("Tensor range check" && 0 <= v170 && v170 < 1l);
                assert("Tensor range check" && 0 <= v172 && v172 < 4l);
                long v174;
                v174 = 4l * v170;
                long v175;
                v175 = v174 + v172;
                float v176;
                v176 = v128[v175];
                float v177;
                v177 = v176 / v168;
                assert("Tensor range check" && 0 <= v170 && v170 < 1l);
                assert("Tensor range check" && 0 <= v172 && v172 < 4l);
                v169[v175] = v177;
                v172 += 1l ;
            }
            v170 += 1l ;
        }
        long v178;
        v178 = 0l;
        while (while_method_2(v178)){
            assert("Tensor range check" && 0 <= v178 && v178 < 1l);
            long v180;
            v180 = 1024l * v178;
            long v181;
            v181 = v180 + v61;
            assert("Tensor range check" && 0 <= v178 && v178 < 1l);
            long v182;
            v182 = 4l * v178;
            int4* v183;
            v183 = reinterpret_cast<int4*>(v169 + v182);
            int4* v184;
            v184 = reinterpret_cast<int4*>(v2 + v181);
            assert("Pointer alignment check" && (unsigned long long)(v183) % 4l == 0 && (unsigned long long)(v184) % 4l == 0);
            *v184 = *v183;
            v178 += 1l ;
        }
        v58 += 1l ;
    }
    __syncthreads();
    long v185;
    v185 = threadIdx.x;
    bool v186;
    v186 = 0l <= v185;
    bool v187;
    v187 = v186 == false;
    if (v187){
        assert("The index needs to be zero or positive." && v186);
    } else {
    }
    long v189;
    v189 = v185 % 256l;
    long v190;
    v190 = v185 / 256l;
    bool v191;
    v191 = v190 < 2l;
    bool v192;
    v192 = v191 == false;
    if (v192){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v191);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v194 = cooperative_groups::tiled_partition<256l>(v7);
    assert("Tensor range check" && 0 <= v190 && v190 < 2l);
    assert("Tensor range check" && 0 <= v189 && v189 < 256l);
    long v195;
    v195 = 4l * v189;
    long v196;
    v196 = 1024l * v190;
    long v197;
    v197 = v196 + v195;
    assert("Tensor range check" && 0 <= v190 && v190 < 2l);
    assert("Tensor range check" && 0 <= v189 && v189 < 256l);
    long v198;
    v198 = 0l;
    while (while_method_2(v198)){
        assert("Tensor range check" && 0 <= v198 && v198 < 1l);
        long v200;
        v200 = 2048l * v198;
        long v201;
        v201 = v200 + v197;
        assert("Tensor range check" && 0 <= v198 && v198 < 1l);
        float v202[4l];
        long v203[4l];
        long v204;
        v204 = 0l;
        while (while_method_2(v204)){
            assert("Tensor range check" && 0 <= v204 && v204 < 1l);
            long v206;
            v206 = 4l * v204;
            assert("Tensor range check" && 0 <= v204 && v204 < 1l);
            long v207;
            v207 = 1024l * v204;
            long v208;
            v208 = v207 + v201;
            int4* v209;
            v209 = reinterpret_cast<int4*>(v0 + v208);
            int4* v210;
            v210 = reinterpret_cast<int4*>(v202 + v206);
            assert("Pointer alignment check" && (unsigned long long)(v209) % 4l == 0 && (unsigned long long)(v210) % 4l == 0);
            *v210 = *v209;
            v204 += 1l ;
        }
        long v211;
        v211 = 0l;
        while (while_method_2(v211)){
            long v213;
            v213 = 0l;
            while (while_method_1(v213)){
                bool v215;
                v215 = 0l <= v213;
                bool v217;
                if (v215){
                    bool v216;
                    v216 = v213 < 4l;
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
                bool v220;
                v220 = 0l <= v211;
                bool v222;
                if (v220){
                    bool v221;
                    v221 = v211 < 1l;
                    v222 = v221;
                } else {
                    v222 = false;
                }
                bool v223;
                v223 = v222 == false;
                if (v223){
                    assert("The indices should be inside the range of the dimension." && v222);
                } else {
                }
                long v225;
                v225 = v211 * 4l;
                long v226;
                v226 = v213 + v225;
                bool v227;
                v227 = 0l <= v189;
                bool v229;
                if (v227){
                    bool v228;
                    v228 = v189 < 256l;
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
                v232 = v189 * 4l;
                long v233;
                v233 = v226 + v232;
                assert("Tensor range check" && 0 <= v211 && v211 < 1l);
                assert("Tensor range check" && 0 <= v213 && v213 < 4l);
                long v234;
                v234 = 4l * v211;
                long v235;
                v235 = v234 + v213;
                v203[v235] = v233;
                v213 += 1l ;
            }
            v211 += 1l ;
        }
        float v236[4l];
        long v237;
        v237 = 0l;
        while (while_method_2(v237)){
            long v239;
            v239 = 0l;
            while (while_method_1(v239)){
                assert("Tensor range check" && 0 <= v237 && v237 < 1l);
                assert("Tensor range check" && 0 <= v239 && v239 < 4l);
                long v241;
                v241 = 4l * v237;
                long v242;
                v242 = v241 + v239;
                float v243;
                v243 = v202[v242];
                float v244;
                v244 = v243 * v243;
                assert("Tensor range check" && 0 <= v237 && v237 < 1l);
                assert("Tensor range check" && 0 <= v239 && v239 < 4l);
                v236[v242] = v244;
                v239 += 1l ;
            }
            v237 += 1l ;
        }
        float v245;
        v245 = 0.0f;
        long v246;
        v246 = 0l;
        while (while_method_2(v246)){
            long v248;
            v248 = 0l;
            while (while_method_1(v248)){
                assert("Tensor range check" && 0 <= v246 && v246 < 1l);
                assert("Tensor range check" && 0 <= v248 && v248 < 4l);
                long v250;
                v250 = 4l * v246;
                long v251;
                v251 = v250 + v248;
                float v252;
                v252 = v236[v251];
                float v253;
                v253 = v252 + v245;
                v245 = v253;
                v248 += 1l ;
            }
            v246 += 1l ;
        }
        auto v254 = cooperative_groups::coalesced_threads();
        float v255;
        v255 = cooperative_groups::reduce(v254, v245, v32);
        long v256;
        v256 = threadIdx.x;
        long v257;
        v257 = v256 / 32l;
        __shared__ float v258[16l];
        bool v259;
        v259 = 0l <= v257;
        bool v260;
        v260 = v259 == false;
        if (v260){
            assert("The index needs to be zero or positive." && v259);
        } else {
        }
        long v262;
        v262 = v257 % 8l;
        long v263;
        v263 = v257 / 8l;
        bool v264;
        v264 = v263 < 2l;
        bool v265;
        v265 = v264 == false;
        if (v265){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v264);
        } else {
        }
        assert("Tensor range check" && 0 <= v263 && v263 < 2l);
        assert("Tensor range check" && 0 <= v262 && v262 < 8l);
        long v267;
        v267 = 8l * v263;
        long v268;
        v268 = v267 + v262;
        v258[v268] = v255;
        v194.sync() ;
        long v269;
        v269 = threadIdx.x;
        long v270;
        v270 = v269 % 32l;
        bool v271;
        v271 = v270 < 8l;
        float v274;
        if (v271){
            assert("Tensor range check" && 0 <= v263 && v263 < 2l);
            assert("Tensor range check" && 0 <= v270 && v270 < 8l);
            long v272;
            v272 = v267 + v270;
            float v273;
            v273 = v258[v272];
            v274 = v273;
        } else {
            v274 = 0.0f;
        }
        v194.sync() ;
        float v275;
        v275 = cooperative_groups::reduce(v254, v274, v32);
        float v276[4l];
        long v277;
        v277 = 0l;
        while (while_method_2(v277)){
            long v279;
            v279 = 0l;
            while (while_method_1(v279)){
                assert("Tensor range check" && 0 <= v277 && v277 < 1l);
                assert("Tensor range check" && 0 <= v279 && v279 < 4l);
                long v281;
                v281 = 4l * v277;
                long v282;
                v282 = v281 + v279;
                float v283;
                v283 = v236[v282];
                float v284;
                v284 = v283 / v275;
                assert("Tensor range check" && 0 <= v277 && v277 < 1l);
                assert("Tensor range check" && 0 <= v279 && v279 < 4l);
                v276[v282] = v284;
                v279 += 1l ;
            }
            v277 += 1l ;
        }
        long v285;
        v285 = 0l;
        while (while_method_2(v285)){
            assert("Tensor range check" && 0 <= v285 && v285 < 1l);
            long v287;
            v287 = 1024l * v285;
            long v288;
            v288 = v287 + v201;
            assert("Tensor range check" && 0 <= v285 && v285 < 1l);
            long v289;
            v289 = 4l * v285;
            int4* v290;
            v290 = reinterpret_cast<int4*>(v276 + v289);
            int4* v291;
            v291 = reinterpret_cast<int4*>(v5 + v288);
            assert("Pointer alignment check" && (unsigned long long)(v290) % 4l == 0 && (unsigned long long)(v291) % 4l == 0);
            *v291 = *v290;
            v285 += 1l ;
        }
        v198 += 1l ;
    }
    __syncthreads();
    long v292;
    v292 = threadIdx.x;
    bool v293;
    v293 = 0l <= v292;
    bool v294;
    v294 = v293 == false;
    if (v294){
        assert("The index needs to be zero or positive." && v293);
    } else {
    }
    long v296;
    v296 = v292 % 256l;
    long v297;
    v297 = v292 / 256l;
    bool v298;
    v298 = v297 < 2l;
    bool v299;
    v299 = v298 == false;
    if (v299){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v298);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v301 = cooperative_groups::tiled_partition<256l>(v7);
    assert("Tensor range check" && 0 <= v297 && v297 < 2l);
    assert("Tensor range check" && 0 <= v296 && v296 < 256l);
    long v302;
    v302 = 4l * v296;
    long v303;
    v303 = 1024l * v297;
    long v304;
    v304 = v303 + v302;
    assert("Tensor range check" && 0 <= v297 && v297 < 2l);
    long v305;
    v305 = 0l;
    while (while_method_2(v305)){
        assert("Tensor range check" && 0 <= v305 && v305 < 1l);
        long v307;
        v307 = 2048l * v305;
        long v308;
        v308 = v307 + v304;
        float v309[4l];
        long v310[4l];
        long v311;
        v311 = 0l;
        while (while_method_2(v311)){
            assert("Tensor range check" && 0 <= v311 && v311 < 1l);
            long v313;
            v313 = 4l * v311;
            assert("Tensor range check" && 0 <= v311 && v311 < 1l);
            long v314;
            v314 = 1024l * v311;
            long v315;
            v315 = v314 + v308;
            int4* v316;
            v316 = reinterpret_cast<int4*>(v0 + v315);
            int4* v317;
            v317 = reinterpret_cast<int4*>(v309 + v313);
            assert("Pointer alignment check" && (unsigned long long)(v316) % 4l == 0 && (unsigned long long)(v317) % 4l == 0);
            *v317 = *v316;
            v311 += 1l ;
        }
        long v318;
        v318 = 0l;
        while (while_method_2(v318)){
            long v320;
            v320 = 0l;
            while (while_method_1(v320)){
                bool v322;
                v322 = 0l <= v320;
                bool v324;
                if (v322){
                    bool v323;
                    v323 = v320 < 4l;
                    v324 = v323;
                } else {
                    v324 = false;
                }
                bool v325;
                v325 = v324 == false;
                if (v325){
                    assert("The indices should be inside the range of the dimension." && v324);
                } else {
                }
                bool v327;
                v327 = 0l <= v318;
                bool v329;
                if (v327){
                    bool v328;
                    v328 = v318 < 1l;
                    v329 = v328;
                } else {
                    v329 = false;
                }
                bool v330;
                v330 = v329 == false;
                if (v330){
                    assert("The indices should be inside the range of the dimension." && v329);
                } else {
                }
                long v332;
                v332 = v318 * 4l;
                long v333;
                v333 = v320 + v332;
                bool v334;
                v334 = 0l <= v296;
                bool v336;
                if (v334){
                    bool v335;
                    v335 = v296 < 256l;
                    v336 = v335;
                } else {
                    v336 = false;
                }
                bool v337;
                v337 = v336 == false;
                if (v337){
                    assert("The indices should be inside the range of the dimension." && v336);
                } else {
                }
                long v339;
                v339 = v296 * 4l;
                long v340;
                v340 = v333 + v339;
                assert("Tensor range check" && 0 <= v318 && v318 < 1l);
                assert("Tensor range check" && 0 <= v320 && v320 < 4l);
                long v341;
                v341 = 4l * v318;
                long v342;
                v342 = v341 + v320;
                v310[v342] = v340;
                v320 += 1l ;
            }
            v318 += 1l ;
        }
        float v343; long v344;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v343 = tmp1.v0; v344 = tmp1.v1;
        long v345;
        v345 = 0l;
        while (while_method_2(v345)){
            long v347;
            v347 = 0l;
            while (while_method_1(v347)){
                assert("Tensor range check" && 0 <= v345 && v345 < 1l);
                assert("Tensor range check" && 0 <= v347 && v347 < 4l);
                long v349;
                v349 = 4l * v345;
                long v350;
                v350 = v349 + v347;
                float v351;
                v351 = v309[v350];
                long v352;
                v352 = v310[v350];
                bool v353;
                v353 = v351 > v343;
                float v354; long v355;
                if (v353){
                    v354 = v351; v355 = v352;
                } else {
                    v354 = v343; v355 = v344;
                }
                v343 = v354;
                v344 = v355;
                v347 += 1l ;
            }
            v345 += 1l ;
        }
        auto v356 = cooperative_groups::coalesced_threads();
        Fun1 v357;
        v357 = ClosureMethod1;
        float v358; long v359;
        Tuple1 tmp2 = cooperative_groups::reduce(v356, Tuple1(v343, v344), v357);
        v358 = tmp2.v0; v359 = tmp2.v1;
        long v360;
        v360 = threadIdx.x;
        long v361;
        v361 = v360 / 32l;
        __shared__ float v362[16l];
        __shared__ long v363[16l];
        bool v364;
        v364 = 0l <= v361;
        bool v365;
        v365 = v364 == false;
        if (v365){
            assert("The index needs to be zero or positive." && v364);
        } else {
        }
        long v367;
        v367 = v361 % 8l;
        long v368;
        v368 = v361 / 8l;
        bool v369;
        v369 = v368 < 2l;
        bool v370;
        v370 = v369 == false;
        if (v370){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v369);
        } else {
        }
        assert("Tensor range check" && 0 <= v368 && v368 < 2l);
        assert("Tensor range check" && 0 <= v367 && v367 < 8l);
        long v372;
        v372 = 8l * v368;
        long v373;
        v373 = v372 + v367;
        v362[v373] = v358;
        v363[v373] = v359;
        v301.sync() ;
        long v374;
        v374 = threadIdx.x;
        long v375;
        v375 = v374 % 32l;
        bool v376;
        v376 = v375 < 8l;
        float v380; long v381;
        if (v376){
            assert("Tensor range check" && 0 <= v368 && v368 < 2l);
            assert("Tensor range check" && 0 <= v375 && v375 < 8l);
            long v377;
            v377 = v372 + v375;
            float v378;
            v378 = v362[v377];
            long v379;
            v379 = v363[v377];
            v380 = v378; v381 = v379;
        } else {
            v380 = -1.0f / 0.0f; v381 = 0l;
        }
        v301.sync() ;
        float v382; long v383;
        Tuple1 tmp3 = cooperative_groups::reduce(v356, Tuple1(v380, v381), v357);
        v382 = tmp3.v0; v383 = tmp3.v1;
        assert("Tensor range check" && 0 <= v305 && v305 < 1l);
        long v384;
        v384 = v305 + v297;
        v6[v384] = v383;
        v305 += 1l ;
    }
    __syncthreads();
    long v385;
    v385 = threadIdx.x;
    bool v386;
    v386 = 0l <= v385;
    bool v387;
    v387 = v386 == false;
    if (v387){
        assert("The index needs to be zero or positive." && v386);
    } else {
    }
    long v389;
    v389 = v385 % 256l;
    long v390;
    v390 = v385 / 256l;
    bool v391;
    v391 = v390 < 2l;
    bool v392;
    v392 = v391 == false;
    if (v392){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v391);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v394 = cooperative_groups::tiled_partition<256l>(v7);
    assert("Tensor range check" && 0 <= v390 && v390 < 2l);
    assert("Tensor range check" && 0 <= v389 && v389 < 256l);
    long v395;
    v395 = 4l * v389;
    long v396;
    v396 = 1024l * v390;
    long v397;
    v397 = v396 + v395;
    assert("Tensor range check" && 0 <= v390 && v390 < 2l);
    assert("Tensor range check" && 0 <= v389 && v389 < 256l);
    long v398;
    v398 = 0l;
    while (while_method_2(v398)){
        assert("Tensor range check" && 0 <= v398 && v398 < 1l);
        long v400;
        v400 = 2048l * v398;
        long v401;
        v401 = v400 + v397;
        assert("Tensor range check" && 0 <= v398 && v398 < 1l);
        float v402[4l];
        long v403[4l];
        long v404;
        v404 = 0l;
        while (while_method_2(v404)){
            assert("Tensor range check" && 0 <= v404 && v404 < 1l);
            long v406;
            v406 = 4l * v404;
            assert("Tensor range check" && 0 <= v404 && v404 < 1l);
            long v407;
            v407 = 1024l * v404;
            long v408;
            v408 = v407 + v401;
            int4* v409;
            v409 = reinterpret_cast<int4*>(v0 + v408);
            int4* v410;
            v410 = reinterpret_cast<int4*>(v402 + v406);
            assert("Pointer alignment check" && (unsigned long long)(v409) % 4l == 0 && (unsigned long long)(v410) % 4l == 0);
            *v410 = *v409;
            v404 += 1l ;
        }
        long v411;
        v411 = 0l;
        while (while_method_2(v411)){
            long v413;
            v413 = 0l;
            while (while_method_1(v413)){
                bool v415;
                v415 = 0l <= v413;
                bool v417;
                if (v415){
                    bool v416;
                    v416 = v413 < 4l;
                    v417 = v416;
                } else {
                    v417 = false;
                }
                bool v418;
                v418 = v417 == false;
                if (v418){
                    assert("The indices should be inside the range of the dimension." && v417);
                } else {
                }
                bool v420;
                v420 = 0l <= v411;
                bool v422;
                if (v420){
                    bool v421;
                    v421 = v411 < 1l;
                    v422 = v421;
                } else {
                    v422 = false;
                }
                bool v423;
                v423 = v422 == false;
                if (v423){
                    assert("The indices should be inside the range of the dimension." && v422);
                } else {
                }
                long v425;
                v425 = v411 * 4l;
                long v426;
                v426 = v413 + v425;
                bool v427;
                v427 = 0l <= v389;
                bool v429;
                if (v427){
                    bool v428;
                    v428 = v389 < 256l;
                    v429 = v428;
                } else {
                    v429 = false;
                }
                bool v430;
                v430 = v429 == false;
                if (v430){
                    assert("The indices should be inside the range of the dimension." && v429);
                } else {
                }
                long v432;
                v432 = v389 * 4l;
                long v433;
                v433 = v426 + v432;
                assert("Tensor range check" && 0 <= v411 && v411 < 1l);
                assert("Tensor range check" && 0 <= v413 && v413 < 4l);
                long v434;
                v434 = 4l * v411;
                long v435;
                v435 = v434 + v413;
                v403[v435] = v433;
                v413 += 1l ;
            }
            v411 += 1l ;
        }
        float v436;
        v436 = 0.0f;
        long v437;
        v437 = 0l;
        while (while_method_2(v437)){
            long v439;
            v439 = 0l;
            while (while_method_1(v439)){
                assert("Tensor range check" && 0 <= v437 && v437 < 1l);
                assert("Tensor range check" && 0 <= v439 && v439 < 4l);
                long v441;
                v441 = 4l * v437;
                long v442;
                v442 = v441 + v439;
                float v443;
                v443 = v402[v442];
                float v444;
                v444 = v443 + v436;
                v436 = v444;
                v439 += 1l ;
            }
            v437 += 1l ;
        }
        auto v445 = cooperative_groups::coalesced_threads();
        float v446;
        v446 = cooperative_groups::reduce(v445, v436, v32);
        long v447;
        v447 = threadIdx.x;
        long v448;
        v448 = v447 / 32l;
        __shared__ float v449[16l];
        bool v450;
        v450 = 0l <= v448;
        bool v451;
        v451 = v450 == false;
        if (v451){
            assert("The index needs to be zero or positive." && v450);
        } else {
        }
        long v453;
        v453 = v448 % 8l;
        long v454;
        v454 = v448 / 8l;
        bool v455;
        v455 = v454 < 2l;
        bool v456;
        v456 = v455 == false;
        if (v456){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v455);
        } else {
        }
        assert("Tensor range check" && 0 <= v454 && v454 < 2l);
        assert("Tensor range check" && 0 <= v453 && v453 < 8l);
        long v458;
        v458 = 8l * v454;
        long v459;
        v459 = v458 + v453;
        v449[v459] = v446;
        v394.sync() ;
        long v460;
        v460 = threadIdx.x;
        long v461;
        v461 = v460 % 32l;
        bool v462;
        v462 = v461 < 8l;
        float v465;
        if (v462){
            assert("Tensor range check" && 0 <= v454 && v454 < 2l);
            assert("Tensor range check" && 0 <= v461 && v461 < 8l);
            long v463;
            v463 = v458 + v461;
            float v464;
            v464 = v449[v463];
            v465 = v464;
        } else {
            v465 = 0.0f;
        }
        v394.sync() ;
        float v466;
        v466 = cooperative_groups::reduce(v445, v465, v32);
        float v467;
        v467 = v466 / 1024.0f;
        float v468[4l];
        long v469;
        v469 = 0l;
        while (while_method_2(v469)){
            long v471;
            v471 = 0l;
            while (while_method_1(v471)){
                assert("Tensor range check" && 0 <= v469 && v469 < 1l);
                assert("Tensor range check" && 0 <= v471 && v471 < 4l);
                long v473;
                v473 = 4l * v469;
                long v474;
                v474 = v473 + v471;
                float v475;
                v475 = v402[v474];
                float v476;
                v476 = v475 - v467;
                float v477;
                v477 = exp(v476);
                assert("Tensor range check" && 0 <= v469 && v469 < 1l);
                assert("Tensor range check" && 0 <= v471 && v471 < 4l);
                v468[v474] = v477;
                v471 += 1l ;
            }
            v469 += 1l ;
        }
        float v478;
        v478 = 0.0f;
        long v479;
        v479 = 0l;
        while (while_method_2(v479)){
            long v481;
            v481 = 0l;
            while (while_method_1(v481)){
                assert("Tensor range check" && 0 <= v479 && v479 < 1l);
                assert("Tensor range check" && 0 <= v481 && v481 < 4l);
                long v483;
                v483 = 4l * v479;
                long v484;
                v484 = v483 + v481;
                float v485;
                v485 = v468[v484];
                float v486;
                v486 = v485 + v478;
                v478 = v486;
                v481 += 1l ;
            }
            v479 += 1l ;
        }
        auto v487 = cooperative_groups::coalesced_threads();
        float v488;
        v488 = cooperative_groups::reduce(v487, v478, v32);
        long v489;
        v489 = threadIdx.x;
        long v490;
        v490 = v489 / 32l;
        __shared__ float v491[16l];
        bool v492;
        v492 = 0l <= v490;
        bool v493;
        v493 = v492 == false;
        if (v493){
            assert("The index needs to be zero or positive." && v492);
        } else {
        }
        long v495;
        v495 = v490 % 8l;
        long v496;
        v496 = v490 / 8l;
        bool v497;
        v497 = v496 < 2l;
        bool v498;
        v498 = v497 == false;
        if (v498){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v497);
        } else {
        }
        assert("Tensor range check" && 0 <= v496 && v496 < 2l);
        assert("Tensor range check" && 0 <= v495 && v495 < 8l);
        long v500;
        v500 = 8l * v496;
        long v501;
        v501 = v500 + v495;
        v491[v501] = v488;
        v394.sync() ;
        long v502;
        v502 = threadIdx.x;
        long v503;
        v503 = v502 % 32l;
        bool v504;
        v504 = v503 < 8l;
        float v507;
        if (v504){
            assert("Tensor range check" && 0 <= v496 && v496 < 2l);
            assert("Tensor range check" && 0 <= v503 && v503 < 8l);
            long v505;
            v505 = v500 + v503;
            float v506;
            v506 = v491[v505];
            v507 = v506;
        } else {
            v507 = 0.0f;
        }
        v394.sync() ;
        float v508;
        v508 = cooperative_groups::reduce(v487, v507, v32);
        float v509[4l];
        long v510;
        v510 = 0l;
        while (while_method_2(v510)){
            long v512;
            v512 = 0l;
            while (while_method_1(v512)){
                assert("Tensor range check" && 0 <= v510 && v510 < 1l);
                assert("Tensor range check" && 0 <= v512 && v512 < 4l);
                long v514;
                v514 = 4l * v510;
                long v515;
                v515 = v514 + v512;
                float v516;
                v516 = v468[v515];
                float v517;
                v517 = v516 / v508;
                assert("Tensor range check" && 0 <= v510 && v510 < 1l);
                assert("Tensor range check" && 0 <= v512 && v512 < 4l);
                v509[v515] = v517;
                v512 += 1l ;
            }
            v510 += 1l ;
        }
        float v518[4l];
        float v519;
        v519 = 0.0f;
        long v520;
        v520 = 0l;
        while (while_method_2(v520)){
            assert("Tensor range check" && 0 <= v520 && v520 < 1l);
            long v522;
            v522 = 4l * v520;
            assert("Tensor range check" && 0 <= v520 && v520 < 1l);
            long v523; float v524;
            Tuple0 tmp4 = Tuple0(0l, 0.0f);
            v523 = tmp4.v0; v524 = tmp4.v1;
            while (while_method_1(v523)){
                assert("Tensor range check" && 0 <= v523 && v523 < 4l);
                long v526;
                v526 = v523 + v522;
                float v527;
                v527 = v509[v526];
                float v528;
                v528 = v527 + v524;
                v524 = v528;
                v523 += 1l ;
            }
            auto v529 = cooperative_groups::coalesced_threads();
            long v530;
            v530 = threadIdx.x;
            long v531;
            v531 = v530 / 32l;
            __shared__ float v532[16l];
            Fun0 v533;
            v533 = ClosureMethod2;
            float v534;
            v534 = cooperative_groups::inclusive_scan(v529, v524, v533);
            float v535;
            v535 = v529.shfl(v534,v529.num_threads()-1);
            float v536;
            v536 = v529.shfl_up(v534,1);
            bool v537;
            v537 = v529.thread_rank() == 0;
            float v538;
            if (v537){
                v538 = 0.0f;
            } else {
                v538 = v536;
            }
            bool v539;
            v539 = 0l <= v531;
            bool v540;
            v540 = v539 == false;
            if (v540){
                assert("The index needs to be zero or positive." && v539);
            } else {
            }
            long v542;
            v542 = v531 % 8l;
            long v543;
            v543 = v531 / 8l;
            bool v544;
            v544 = v543 < 2l;
            bool v545;
            v545 = v544 == false;
            if (v545){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v544);
            } else {
            }
            assert("Tensor range check" && 0 <= v543 && v543 < 2l);
            assert("Tensor range check" && 0 <= v542 && v542 < 8l);
            long v547;
            v547 = 8l * v543;
            long v548;
            v548 = v547 + v542;
            v532[v548] = v535;
            v394.sync() ;
            long v549;
            v549 = threadIdx.x;
            long v550;
            v550 = v549 % 32l;
            bool v551;
            v551 = v550 < 8l;
            float v554;
            if (v551){
                assert("Tensor range check" && 0 <= v543 && v543 < 2l);
                assert("Tensor range check" && 0 <= v550 && v550 < 8l);
                long v552;
                v552 = v547 + v550;
                float v553;
                v553 = v532[v552];
                v554 = v553;
            } else {
                v554 = 0.0f;
            }
            v394.sync() ;
            float v555;
            v555 = cooperative_groups::inclusive_scan(v529, v554, v533);
            float v556;
            v556 = v529.shfl(v555,v529.num_threads()-1);
            float v557;
            v557 = v529.shfl_up(v555,1);
            bool v558;
            v558 = v529.thread_rank() == 0;
            float v559;
            if (v558){
                v559 = 0.0f;
            } else {
                v559 = v557;
            }
            float v560;
            v560 = v529.shfl(v559,v542);
            float v561;
            v561 = v560 + v538;
            float v562;
            v562 = v519 + v561;
            long v563; float v564;
            Tuple0 tmp5 = Tuple0(0l, v562);
            v563 = tmp5.v0; v564 = tmp5.v1;
            while (while_method_1(v563)){
                assert("Tensor range check" && 0 <= v563 && v563 < 4l);
                long v566;
                v566 = v563 + v522;
                float v567;
                v567 = v509[v566];
                assert("Tensor range check" && 0 <= v563 && v563 < 4l);
                v518[v566] = v564;
                float v568;
                v568 = v567 + v564;
                v564 = v568;
                v563 += 1l ;
            }
            float v569;
            v569 = v519 + v556;
            v519 = v569;
            v520 += 1l ;
        }
        long v570;
        v570 = 0l;
        while (while_method_2(v570)){
            assert("Tensor range check" && 0 <= v570 && v570 < 1l);
            long v572;
            v572 = 1024l * v570;
            long v573;
            v573 = v572 + v401;
            assert("Tensor range check" && 0 <= v570 && v570 < 1l);
            long v574;
            v574 = 4l * v570;
            int4* v575;
            v575 = reinterpret_cast<int4*>(v509 + v574);
            int4* v576;
            v576 = reinterpret_cast<int4*>(v3 + v573);
            assert("Pointer alignment check" && (unsigned long long)(v575) % 4l == 0 && (unsigned long long)(v576) % 4l == 0);
            *v576 = *v575;
            int4* v577;
            v577 = reinterpret_cast<int4*>(v518 + v574);
            int4* v578;
            v578 = reinterpret_cast<int4*>(v4 + v573);
            assert("Pointer alignment check" && (unsigned long long)(v577) % 4l == 0 && (unsigned long long)(v578) % 4l == 0);
            *v578 = *v577;
            v570 += 1l ;
        }
        v398 += 1l ;
    }
    __syncthreads();
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method1(v0 : i32) -> bool:
    v1 = v0 < 1024
    del v0
    return v1
def main():
    v0 = cp.random.normal(0.0,1.0,2048,cp.float32)
    v1 = v0.size
    v2 = 2048 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    pass
    v5 = cp.empty(1,dtype=cp.float32)
    pass
    v6 = cp.empty(2048,dtype=cp.float32)
    pass
    v7 = cp.empty(2048,dtype=cp.float32)
    v8 = cp.empty(2048,dtype=cp.float32)
    pass
    v9 = cp.empty(2048,dtype=cp.float32)
    pass
    v10 = cp.empty(2,dtype=cp.int32)
    v11 = 0
    v12 = raw_module.get_function(f"entry{v11}")
    del v11
    v12.max_dynamic_shared_size_bytes = 0 
    v12((1,),(512,),(v0, v5, v6, v7, v8, v9, v10),shared_mem=0)
    del v0, v5, v6, v9, v10, v12
    v13 = 0
    print('[', end="")
    v15 = 0
    while method0(v15):
        v17 = v13
        v18 = v17 >= 2048
        del v17
        if v18:
            v21 = " ..."
            print(v21, end="")
            del v21
            break
        else:
            pass
        del v18
        v22 = v15 == 0
        v23 = v22 != True
        del v22
        if v23:
            v26 = "; "
            print(v26, end="")
            del v26
        else:
            pass
        del v23
        print('[', end="")
        v28 = 0
        while method1(v28):
            v30 = v13
            v31 = v30 >= 2048
            del v30
            if v31:
                v34 = " ..."
                print(v34, end="")
                del v34
                break
            else:
                pass
            del v31
            v35 = v28 == 0
            v36 = v35 != True
            del v35
            if v36:
                v39 = "; "
                print(v39, end="")
                del v39
            else:
                pass
            del v36
            v40 = v13 + 1
            v13 = v40
            del v40
            v41 = v15 * 1024
            v42 = v41 + v28
            del v41
            v43 = v7[v42].item()
            v44 = v8[v42].item()
            del v42
            print("{:.6f}".format(v43), end="")
            del v43
            v48 = ", "
            print(v48, end="")
            del v48
            print("{:.6f}".format(v44), end="")
            del v44
            v28 += 1 
        del v28
        print(']', end="")
        v15 += 1 
    del v7, v8, v13, v15
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
