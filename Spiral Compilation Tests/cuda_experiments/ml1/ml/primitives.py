kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
#include <cooperative_groups/reduce.h>
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
__device__ float ClosureMethod1(float tup0, float tup1){
    float v0 = tup0; float v1 = tup1;
    float v2;
    v2 = v0 + v1;
    return v2;
}
__device__ Tuple1 ClosureMethod2(Tuple1 tup0, Tuple1 tup1){
    float v0 = tup0.v0; long v1 = tup0.v1; float v2 = tup1.v0; long v3 = tup1.v1;
    bool v4;
    v4 = v0 > v2;
    if (v4){
        return Tuple1(v0, v1);
    } else {
        return Tuple1(v2, v3);
    }
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3, long * v4) {
    auto v5 = cooperative_groups::this_thread_block();
    float v6;
    v6 = 0.0f;
    long v7;
    v7 = threadIdx.x;
    long v8;
    v8 = v7;
    while (while_method_0(v8)){
        bool v10;
        v10 = 0l <= v8;
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The index needs to be zero or positive." && v10);
        } else {
        }
        long v13;
        v13 = v8 % 4l;
        long v14;
        v14 = v8 / 4l;
        bool v15;
        v15 = v14 < 128l;
        bool v16;
        v16 = v15 == false;
        if (v16){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v15);
        } else {
        }
        assert("Tensor range check" && 0 <= v14 && v14 < 128l);
        assert("Tensor range check" && 0 <= v13 && v13 < 4l);
        long v18;
        v18 = 4l * v13;
        long v19;
        v19 = 16l * v14;
        long v20;
        v20 = v19 + v18;
        float v21[4l];
        int4* v22;
        v22 = reinterpret_cast<int4*>(v0 + v20);
        int4* v23;
        v23 = reinterpret_cast<int4*>(v21 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v22) % 4l == 0 && (unsigned long long)(v23) % 4l == 0);
        *v23 = *v22;
        long v24; float v25;
        Tuple0 tmp0 = Tuple0(0l, v6);
        v24 = tmp0.v0; v25 = tmp0.v1;
        while (while_method_1(v24)){
            assert("Tensor range check" && 0 <= v24 && v24 < 4l);
            float v27;
            v27 = v21[v24];
            float v28;
            v28 = v27 + v25;
            v25 = v28;
            v24 += 1l ;
        }
        v6 = v25;
        v8 += 512l ;
    }
    auto v29 = cooperative_groups::coalesced_threads();
    Fun0 v30;
    v30 = ClosureMethod0;
    float v31;
    v31 = cooperative_groups::reduce(v29, v6, v30);
    long v32;
    v32 = threadIdx.x;
    long v33;
    v33 = v32 / 32l;
    __shared__ float v34[16l];
    assert("Tensor range check" && 0 <= v33 && v33 < 16l);
    v34[v33] = v31;
    __syncthreads();
    long v35;
    v35 = threadIdx.x;
    long v36;
    v36 = v35 % 32l;
    bool v37;
    v37 = v33 == 0l;
    bool v39;
    if (v37){
        bool v38;
        v38 = v36 < 16l;
        v39 = v38;
    } else {
        v39 = false;
    }
    if (v39){
        auto v40 = cooperative_groups::coalesced_threads();
        assert("Tensor range check" && 0 <= v36 && v36 < 16l);
        float v41;
        v41 = v34[v36];
        float v42;
        v42 = cooperative_groups::reduce(v40, v41, v30);
        v1[0l] = v42;
    } else {
    }
    __syncthreads();
    long v43;
    v43 = threadIdx.x;
    bool v44;
    v44 = 0l <= v43;
    bool v45;
    v45 = v44 == false;
    if (v45){
        assert("The index needs to be zero or positive." && v44);
    } else {
    }
    long v47;
    v47 = v43 % 4l;
    long v48;
    v48 = v43 / 4l;
    bool v49;
    v49 = v48 < 128l;
    bool v50;
    v50 = v49 == false;
    if (v50){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v49);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v52 = cooperative_groups::tiled_partition<4l>(v5);
    assert("Tensor range check" && 0 <= v48 && v48 < 128l);
    assert("Tensor range check" && 0 <= v47 && v47 < 4l);
    long v53;
    v53 = 4l * v47;
    long v54;
    v54 = 16l * v48;
    long v55;
    v55 = v54 + v53;
    assert("Tensor range check" && 0 <= v48 && v48 < 128l);
    assert("Tensor range check" && 0 <= v47 && v47 < 4l);
    long v56;
    v56 = 0l;
    while (while_method_2(v56)){
        assert("Tensor range check" && 0 <= v56 && v56 < 1l);
        long v58;
        v58 = 2048l * v56;
        long v59;
        v59 = v58 + v55;
        assert("Tensor range check" && 0 <= v56 && v56 < 1l);
        float v60[4l];
        long v61[4l];
        long v62;
        v62 = 0l;
        while (while_method_2(v62)){
            assert("Tensor range check" && 0 <= v62 && v62 < 1l);
            long v64;
            v64 = 4l * v62;
            assert("Tensor range check" && 0 <= v62 && v62 < 1l);
            long v65;
            v65 = 16l * v62;
            long v66;
            v66 = v65 + v59;
            int4* v67;
            v67 = reinterpret_cast<int4*>(v0 + v66);
            int4* v68;
            v68 = reinterpret_cast<int4*>(v60 + v64);
            assert("Pointer alignment check" && (unsigned long long)(v67) % 4l == 0 && (unsigned long long)(v68) % 4l == 0);
            *v68 = *v67;
            v62 += 1l ;
        }
        long v69;
        v69 = 0l;
        while (while_method_2(v69)){
            long v71;
            v71 = 0l;
            while (while_method_1(v71)){
                bool v73;
                v73 = 0l <= v71;
                bool v75;
                if (v73){
                    bool v74;
                    v74 = v71 < 4l;
                    v75 = v74;
                } else {
                    v75 = false;
                }
                bool v76;
                v76 = v75 == false;
                if (v76){
                    assert("The indices should be inside the range of the dimension." && v75);
                } else {
                }
                bool v78;
                v78 = 0l <= v69;
                bool v80;
                if (v78){
                    bool v79;
                    v79 = v69 < 1l;
                    v80 = v79;
                } else {
                    v80 = false;
                }
                bool v81;
                v81 = v80 == false;
                if (v81){
                    assert("The indices should be inside the range of the dimension." && v80);
                } else {
                }
                long v83;
                v83 = v69 * 4l;
                long v84;
                v84 = v71 + v83;
                bool v85;
                v85 = 0l <= v47;
                bool v87;
                if (v85){
                    bool v86;
                    v86 = v47 < 4l;
                    v87 = v86;
                } else {
                    v87 = false;
                }
                bool v88;
                v88 = v87 == false;
                if (v88){
                    assert("The indices should be inside the range of the dimension." && v87);
                } else {
                }
                long v90;
                v90 = v47 * 4l;
                long v91;
                v91 = v84 + v90;
                assert("Tensor range check" && 0 <= v69 && v69 < 1l);
                assert("Tensor range check" && 0 <= v71 && v71 < 4l);
                long v92;
                v92 = 4l * v69;
                long v93;
                v93 = v92 + v71;
                v61[v93] = v91;
                v71 += 1l ;
            }
            v69 += 1l ;
        }
        float v94;
        v94 = 0.0f;
        long v95;
        v95 = 0l;
        while (while_method_2(v95)){
            long v97;
            v97 = 0l;
            while (while_method_1(v97)){
                assert("Tensor range check" && 0 <= v95 && v95 < 1l);
                assert("Tensor range check" && 0 <= v97 && v97 < 4l);
                long v99;
                v99 = 4l * v95;
                long v100;
                v100 = v99 + v97;
                float v101;
                v101 = v60[v100];
                float v102;
                v102 = v101 + v94;
                v94 = v102;
                v97 += 1l ;
            }
            v95 += 1l ;
        }
        Fun0 v103;
        v103 = ClosureMethod1;
        float v104;
        v104 = cooperative_groups::reduce(v52, v94, v103);
        float v105;
        v105 = v104 / 16.0f;
        float v106[4l];
        long v107;
        v107 = 0l;
        while (while_method_2(v107)){
            long v109;
            v109 = 0l;
            while (while_method_1(v109)){
                assert("Tensor range check" && 0 <= v107 && v107 < 1l);
                assert("Tensor range check" && 0 <= v109 && v109 < 4l);
                long v111;
                v111 = 4l * v107;
                long v112;
                v112 = v111 + v109;
                float v113;
                v113 = v60[v112];
                float v114;
                v114 = v113 - v105;
                float v115;
                v115 = exp(v114);
                assert("Tensor range check" && 0 <= v107 && v107 < 1l);
                assert("Tensor range check" && 0 <= v109 && v109 < 4l);
                v106[v112] = v115;
                v109 += 1l ;
            }
            v107 += 1l ;
        }
        float v116;
        v116 = 0.0f;
        long v117;
        v117 = 0l;
        while (while_method_2(v117)){
            long v119;
            v119 = 0l;
            while (while_method_1(v119)){
                assert("Tensor range check" && 0 <= v117 && v117 < 1l);
                assert("Tensor range check" && 0 <= v119 && v119 < 4l);
                long v121;
                v121 = 4l * v117;
                long v122;
                v122 = v121 + v119;
                float v123;
                v123 = v106[v122];
                float v124;
                v124 = v123 + v116;
                v116 = v124;
                v119 += 1l ;
            }
            v117 += 1l ;
        }
        float v125;
        v125 = cooperative_groups::reduce(v52, v116, v103);
        float v126[4l];
        long v127;
        v127 = 0l;
        while (while_method_2(v127)){
            long v129;
            v129 = 0l;
            while (while_method_1(v129)){
                assert("Tensor range check" && 0 <= v127 && v127 < 1l);
                assert("Tensor range check" && 0 <= v129 && v129 < 4l);
                long v131;
                v131 = 4l * v127;
                long v132;
                v132 = v131 + v129;
                float v133;
                v133 = v106[v132];
                float v134;
                v134 = v133 / v125;
                assert("Tensor range check" && 0 <= v127 && v127 < 1l);
                assert("Tensor range check" && 0 <= v129 && v129 < 4l);
                v126[v132] = v134;
                v129 += 1l ;
            }
            v127 += 1l ;
        }
        long v135;
        v135 = 0l;
        while (while_method_2(v135)){
            assert("Tensor range check" && 0 <= v135 && v135 < 1l);
            long v137;
            v137 = 16l * v135;
            long v138;
            v138 = v137 + v59;
            assert("Tensor range check" && 0 <= v135 && v135 < 1l);
            long v139;
            v139 = 4l * v135;
            int4* v140;
            v140 = reinterpret_cast<int4*>(v126 + v139);
            int4* v141;
            v141 = reinterpret_cast<int4*>(v2 + v138);
            assert("Pointer alignment check" && (unsigned long long)(v140) % 4l == 0 && (unsigned long long)(v141) % 4l == 0);
            *v141 = *v140;
            v135 += 1l ;
        }
        v56 += 1l ;
    }
    __syncthreads();
    long v142;
    v142 = threadIdx.x;
    bool v143;
    v143 = 0l <= v142;
    bool v144;
    v144 = v143 == false;
    if (v144){
        assert("The index needs to be zero or positive." && v143);
    } else {
    }
    long v146;
    v146 = v142 % 4l;
    long v147;
    v147 = v142 / 4l;
    bool v148;
    v148 = v147 < 128l;
    bool v149;
    v149 = v148 == false;
    if (v149){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v148);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v151 = cooperative_groups::tiled_partition<4l>(v5);
    assert("Tensor range check" && 0 <= v147 && v147 < 128l);
    assert("Tensor range check" && 0 <= v146 && v146 < 4l);
    long v152;
    v152 = 4l * v146;
    long v153;
    v153 = 16l * v147;
    long v154;
    v154 = v153 + v152;
    assert("Tensor range check" && 0 <= v147 && v147 < 128l);
    assert("Tensor range check" && 0 <= v146 && v146 < 4l);
    long v155;
    v155 = 0l;
    while (while_method_2(v155)){
        assert("Tensor range check" && 0 <= v155 && v155 < 1l);
        long v157;
        v157 = 2048l * v155;
        long v158;
        v158 = v157 + v154;
        assert("Tensor range check" && 0 <= v155 && v155 < 1l);
        float v159[4l];
        long v160[4l];
        long v161;
        v161 = 0l;
        while (while_method_2(v161)){
            assert("Tensor range check" && 0 <= v161 && v161 < 1l);
            long v163;
            v163 = 4l * v161;
            assert("Tensor range check" && 0 <= v161 && v161 < 1l);
            long v164;
            v164 = 16l * v161;
            long v165;
            v165 = v164 + v158;
            int4* v166;
            v166 = reinterpret_cast<int4*>(v0 + v165);
            int4* v167;
            v167 = reinterpret_cast<int4*>(v159 + v163);
            assert("Pointer alignment check" && (unsigned long long)(v166) % 4l == 0 && (unsigned long long)(v167) % 4l == 0);
            *v167 = *v166;
            v161 += 1l ;
        }
        long v168;
        v168 = 0l;
        while (while_method_2(v168)){
            long v170;
            v170 = 0l;
            while (while_method_1(v170)){
                bool v172;
                v172 = 0l <= v170;
                bool v174;
                if (v172){
                    bool v173;
                    v173 = v170 < 4l;
                    v174 = v173;
                } else {
                    v174 = false;
                }
                bool v175;
                v175 = v174 == false;
                if (v175){
                    assert("The indices should be inside the range of the dimension." && v174);
                } else {
                }
                bool v177;
                v177 = 0l <= v168;
                bool v179;
                if (v177){
                    bool v178;
                    v178 = v168 < 1l;
                    v179 = v178;
                } else {
                    v179 = false;
                }
                bool v180;
                v180 = v179 == false;
                if (v180){
                    assert("The indices should be inside the range of the dimension." && v179);
                } else {
                }
                long v182;
                v182 = v168 * 4l;
                long v183;
                v183 = v170 + v182;
                bool v184;
                v184 = 0l <= v146;
                bool v186;
                if (v184){
                    bool v185;
                    v185 = v146 < 4l;
                    v186 = v185;
                } else {
                    v186 = false;
                }
                bool v187;
                v187 = v186 == false;
                if (v187){
                    assert("The indices should be inside the range of the dimension." && v186);
                } else {
                }
                long v189;
                v189 = v146 * 4l;
                long v190;
                v190 = v183 + v189;
                assert("Tensor range check" && 0 <= v168 && v168 < 1l);
                assert("Tensor range check" && 0 <= v170 && v170 < 4l);
                long v191;
                v191 = 4l * v168;
                long v192;
                v192 = v191 + v170;
                v160[v192] = v190;
                v170 += 1l ;
            }
            v168 += 1l ;
        }
        float v193[4l];
        long v194;
        v194 = 0l;
        while (while_method_2(v194)){
            long v196;
            v196 = 0l;
            while (while_method_1(v196)){
                assert("Tensor range check" && 0 <= v194 && v194 < 1l);
                assert("Tensor range check" && 0 <= v196 && v196 < 4l);
                long v198;
                v198 = 4l * v194;
                long v199;
                v199 = v198 + v196;
                float v200;
                v200 = v159[v199];
                float v201;
                v201 = v200 * v200;
                assert("Tensor range check" && 0 <= v194 && v194 < 1l);
                assert("Tensor range check" && 0 <= v196 && v196 < 4l);
                v193[v199] = v201;
                v196 += 1l ;
            }
            v194 += 1l ;
        }
        float v202;
        v202 = 0.0f;
        long v203;
        v203 = 0l;
        while (while_method_2(v203)){
            long v205;
            v205 = 0l;
            while (while_method_1(v205)){
                assert("Tensor range check" && 0 <= v203 && v203 < 1l);
                assert("Tensor range check" && 0 <= v205 && v205 < 4l);
                long v207;
                v207 = 4l * v203;
                long v208;
                v208 = v207 + v205;
                float v209;
                v209 = v193[v208];
                float v210;
                v210 = v209 + v202;
                v202 = v210;
                v205 += 1l ;
            }
            v203 += 1l ;
        }
        Fun0 v211;
        v211 = ClosureMethod1;
        float v212;
        v212 = cooperative_groups::reduce(v151, v202, v211);
        float v213[4l];
        long v214;
        v214 = 0l;
        while (while_method_2(v214)){
            long v216;
            v216 = 0l;
            while (while_method_1(v216)){
                assert("Tensor range check" && 0 <= v214 && v214 < 1l);
                assert("Tensor range check" && 0 <= v216 && v216 < 4l);
                long v218;
                v218 = 4l * v214;
                long v219;
                v219 = v218 + v216;
                float v220;
                v220 = v193[v219];
                float v221;
                v221 = v220 / v212;
                assert("Tensor range check" && 0 <= v214 && v214 < 1l);
                assert("Tensor range check" && 0 <= v216 && v216 < 4l);
                v213[v219] = v221;
                v216 += 1l ;
            }
            v214 += 1l ;
        }
        long v222;
        v222 = 0l;
        while (while_method_2(v222)){
            assert("Tensor range check" && 0 <= v222 && v222 < 1l);
            long v224;
            v224 = 16l * v222;
            long v225;
            v225 = v224 + v158;
            assert("Tensor range check" && 0 <= v222 && v222 < 1l);
            long v226;
            v226 = 4l * v222;
            int4* v227;
            v227 = reinterpret_cast<int4*>(v213 + v226);
            int4* v228;
            v228 = reinterpret_cast<int4*>(v3 + v225);
            assert("Pointer alignment check" && (unsigned long long)(v227) % 4l == 0 && (unsigned long long)(v228) % 4l == 0);
            *v228 = *v227;
            v222 += 1l ;
        }
        v155 += 1l ;
    }
    __syncthreads();
    long v229;
    v229 = threadIdx.x;
    bool v230;
    v230 = 0l <= v229;
    bool v231;
    v231 = v230 == false;
    if (v231){
        assert("The index needs to be zero or positive." && v230);
    } else {
    }
    long v233;
    v233 = v229 % 4l;
    long v234;
    v234 = v229 / 4l;
    bool v235;
    v235 = v234 < 128l;
    bool v236;
    v236 = v235 == false;
    if (v236){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v235);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v238 = cooperative_groups::tiled_partition<4l>(v5);
    assert("Tensor range check" && 0 <= v234 && v234 < 128l);
    assert("Tensor range check" && 0 <= v233 && v233 < 4l);
    long v239;
    v239 = 4l * v233;
    long v240;
    v240 = 16l * v234;
    long v241;
    v241 = v240 + v239;
    assert("Tensor range check" && 0 <= v234 && v234 < 128l);
    long v242;
    v242 = 0l;
    while (while_method_2(v242)){
        assert("Tensor range check" && 0 <= v242 && v242 < 1l);
        long v244;
        v244 = 2048l * v242;
        long v245;
        v245 = v244 + v241;
        float v246[4l];
        long v247[4l];
        long v248;
        v248 = 0l;
        while (while_method_2(v248)){
            assert("Tensor range check" && 0 <= v248 && v248 < 1l);
            long v250;
            v250 = 4l * v248;
            assert("Tensor range check" && 0 <= v248 && v248 < 1l);
            long v251;
            v251 = 16l * v248;
            long v252;
            v252 = v251 + v245;
            int4* v253;
            v253 = reinterpret_cast<int4*>(v0 + v252);
            int4* v254;
            v254 = reinterpret_cast<int4*>(v246 + v250);
            assert("Pointer alignment check" && (unsigned long long)(v253) % 4l == 0 && (unsigned long long)(v254) % 4l == 0);
            *v254 = *v253;
            v248 += 1l ;
        }
        long v255;
        v255 = 0l;
        while (while_method_2(v255)){
            long v257;
            v257 = 0l;
            while (while_method_1(v257)){
                bool v259;
                v259 = 0l <= v257;
                bool v261;
                if (v259){
                    bool v260;
                    v260 = v257 < 4l;
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
                bool v264;
                v264 = 0l <= v255;
                bool v266;
                if (v264){
                    bool v265;
                    v265 = v255 < 1l;
                    v266 = v265;
                } else {
                    v266 = false;
                }
                bool v267;
                v267 = v266 == false;
                if (v267){
                    assert("The indices should be inside the range of the dimension." && v266);
                } else {
                }
                long v269;
                v269 = v255 * 4l;
                long v270;
                v270 = v257 + v269;
                bool v271;
                v271 = 0l <= v233;
                bool v273;
                if (v271){
                    bool v272;
                    v272 = v233 < 4l;
                    v273 = v272;
                } else {
                    v273 = false;
                }
                bool v274;
                v274 = v273 == false;
                if (v274){
                    assert("The indices should be inside the range of the dimension." && v273);
                } else {
                }
                long v276;
                v276 = v233 * 4l;
                long v277;
                v277 = v270 + v276;
                assert("Tensor range check" && 0 <= v255 && v255 < 1l);
                assert("Tensor range check" && 0 <= v257 && v257 < 4l);
                long v278;
                v278 = 4l * v255;
                long v279;
                v279 = v278 + v257;
                v247[v279] = v277;
                v257 += 1l ;
            }
            v255 += 1l ;
        }
        float v280; long v281;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v280 = tmp1.v0; v281 = tmp1.v1;
        long v282;
        v282 = 0l;
        while (while_method_2(v282)){
            long v284;
            v284 = 0l;
            while (while_method_1(v284)){
                assert("Tensor range check" && 0 <= v282 && v282 < 1l);
                assert("Tensor range check" && 0 <= v284 && v284 < 4l);
                long v286;
                v286 = 4l * v282;
                long v287;
                v287 = v286 + v284;
                float v288;
                v288 = v246[v287];
                long v289;
                v289 = v247[v287];
                bool v290;
                v290 = v288 > v280;
                float v291; long v292;
                if (v290){
                    v291 = v288; v292 = v289;
                } else {
                    v291 = v280; v292 = v281;
                }
                v280 = v291;
                v281 = v292;
                v284 += 1l ;
            }
            v282 += 1l ;
        }
        Fun1 v293;
        v293 = ClosureMethod2;
        float v294; long v295;
        Tuple1 tmp2 = cooperative_groups::reduce(v238, Tuple1(v280, v281), v293);
        v294 = tmp2.v0; v295 = tmp2.v1;
        assert("Tensor range check" && 0 <= v242 && v242 < 1l);
        long v296;
        v296 = v242 + v234;
        v4[v296] = v295;
        v242 += 1l ;
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
    v1 = v0 < 128
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
    v5 = cp.zeros(1,dtype=cp.float32)
    v6 = v5.size
    v7 = 1 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.zeros(2048,dtype=cp.float32)
    v11 = v10.size
    v12 = 2048 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = cp.zeros(2048,dtype=cp.float32)
    v16 = v15.size
    v17 = 2048 == v16
    del v16
    v18 = v17 == False
    if v18:
        v19 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v17, v19
        del v19
    else:
        pass
    del v17, v18
    pass
    v20 = cp.empty(128,dtype=cp.int32)
    v21 = 0
    v22 = raw_module.get_function(f"entry{v21}")
    del v21
    v22.max_dynamic_shared_size_bytes = 0 
    v22((1,),(512,),(v0, v5, v10, v15, v20),shared_mem=0)
    del v0, v5, v10, v15, v22
    v23 = 0
    print('[', end="")
    v25 = 0
    while method0(v25):
        v27 = v23
        v28 = v27 >= 1024
        del v27
        if v28:
            v31 = " ..."
            print(v31, end="")
            del v31
            break
        else:
            pass
        del v28
        v32 = v25 == 0
        v33 = v32 != True
        del v32
        if v33:
            v36 = "; "
            print(v36, end="")
            del v36
        else:
            pass
        del v33
        v37 = v23 + 1
        v23 = v37
        del v37
        v38 = v20[v25].item()
        print(v38, end="")
        del v38
        v25 += 1 
    del v20, v23, v25
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
