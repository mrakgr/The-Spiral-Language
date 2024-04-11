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
__device__ float ClosureMethod3(float tup0, float tup1){
    float v0 = tup0; float v1 = tup1;
    float v2;
    v2 = v0 + v1;
    return v2;
}
__device__ Tuple1 ClosureMethod4(Tuple1 tup0, Tuple1 tup1){
    float v0 = tup0.v0; long v1 = tup0.v1; float v2 = tup1.v0; long v3 = tup1.v1;
    bool v4;
    v4 = v0 >= 0.0f;
    bool v6;
    if (v4){
        bool v5;
        v5 = v2 >= 0.0f;
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6){
        bool v7;
        v7 = v0 <= v2;
        if (v7){
            return Tuple1(v0, v1);
        } else {
            return Tuple1(v2, v3);
        }
    } else {
        if (v4){
            return Tuple1(v0, v1);
        } else {
            bool v10;
            v10 = v2 >= 0.0f;
            if (v10){
                return Tuple1(v2, v3);
            } else {
                return Tuple1(v0, v1);
            }
        }
    }
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3, float * v4, float * v5, float * v6, long * v7, long * v8, long * v9, long * v10) {
    auto v11 = cooperative_groups::this_thread_block();
    float v12;
    v12 = 0.0f;
    long v13;
    v13 = threadIdx.x;
    long v14;
    v14 = v13;
    while (while_method_0(v14)){
        bool v16;
        v16 = 0l <= v14;
        bool v17;
        v17 = v16 == false;
        if (v17){
            assert("The index needs to be zero or positive." && v16);
        } else {
        }
        long v19;
        v19 = v14 % 4l;
        long v20;
        v20 = v14 / 4l;
        bool v21;
        v21 = v20 < 128l;
        bool v22;
        v22 = v21 == false;
        if (v22){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v21);
        } else {
        }
        assert("Tensor range check" && 0 <= v20 && v20 < 128l);
        assert("Tensor range check" && 0 <= v19 && v19 < 4l);
        long v24;
        v24 = 4l * v19;
        long v25;
        v25 = 16l * v20;
        long v26;
        v26 = v25 + v24;
        float v27[4l];
        int4* v28;
        v28 = reinterpret_cast<int4*>(v0 + v26);
        int4* v29;
        v29 = reinterpret_cast<int4*>(v27 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v28) % 4l == 0 && (unsigned long long)(v29) % 4l == 0);
        *v29 = *v28;
        long v30; float v31;
        Tuple0 tmp0 = Tuple0(0l, v12);
        v30 = tmp0.v0; v31 = tmp0.v1;
        while (while_method_1(v30)){
            assert("Tensor range check" && 0 <= v30 && v30 < 4l);
            float v33;
            v33 = v27[v30];
            float v34;
            v34 = v33 + v31;
            v31 = v34;
            v30 += 1l ;
        }
        v12 = v31;
        v14 += 512l ;
    }
    auto v35 = cooperative_groups::coalesced_threads();
    Fun0 v36;
    v36 = ClosureMethod0;
    float v37;
    v37 = cooperative_groups::reduce(v35, v12, v36);
    long v38;
    v38 = threadIdx.x;
    long v39;
    v39 = v38 / 32l;
    __shared__ float v40[16l];
    assert("Tensor range check" && 0 <= v39 && v39 < 16l);
    v40[v39] = v37;
    __syncthreads();
    long v41;
    v41 = threadIdx.x;
    long v42;
    v42 = v41 % 32l;
    bool v43;
    v43 = v39 == 0l;
    bool v45;
    if (v43){
        bool v44;
        v44 = v42 < 16l;
        v45 = v44;
    } else {
        v45 = false;
    }
    if (v45){
        auto v46 = cooperative_groups::coalesced_threads();
        assert("Tensor range check" && 0 <= v42 && v42 < 16l);
        float v47;
        v47 = v40[v42];
        float v48;
        v48 = cooperative_groups::reduce(v46, v47, v36);
        v2[0l] = v48;
    } else {
    }
    __syncthreads();
    long v49;
    v49 = threadIdx.x;
    bool v50;
    v50 = 0l <= v49;
    bool v51;
    v51 = v50 == false;
    if (v51){
        assert("The index needs to be zero or positive." && v50);
    } else {
    }
    long v53;
    v53 = v49 % 4l;
    long v54;
    v54 = v49 / 4l;
    bool v55;
    v55 = v54 < 128l;
    bool v56;
    v56 = v55 == false;
    if (v56){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v55);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v58 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v54 && v54 < 128l);
    assert("Tensor range check" && 0 <= v53 && v53 < 4l);
    long v59;
    v59 = 4l * v53;
    long v60;
    v60 = 16l * v54;
    long v61;
    v61 = v60 + v59;
    assert("Tensor range check" && 0 <= v54 && v54 < 128l);
    assert("Tensor range check" && 0 <= v53 && v53 < 4l);
    long v62;
    v62 = 0l;
    while (while_method_2(v62)){
        assert("Tensor range check" && 0 <= v62 && v62 < 1l);
        long v64;
        v64 = 2048l * v62;
        long v65;
        v65 = v64 + v61;
        assert("Tensor range check" && 0 <= v62 && v62 < 1l);
        float v66[4l];
        long v67[4l];
        long v68;
        v68 = 0l;
        while (while_method_2(v68)){
            assert("Tensor range check" && 0 <= v68 && v68 < 1l);
            long v70;
            v70 = 4l * v68;
            assert("Tensor range check" && 0 <= v68 && v68 < 1l);
            long v71;
            v71 = 16l * v68;
            long v72;
            v72 = v71 + v65;
            int4* v73;
            v73 = reinterpret_cast<int4*>(v0 + v72);
            int4* v74;
            v74 = reinterpret_cast<int4*>(v66 + v70);
            assert("Pointer alignment check" && (unsigned long long)(v73) % 4l == 0 && (unsigned long long)(v74) % 4l == 0);
            *v74 = *v73;
            v68 += 1l ;
        }
        long v75;
        v75 = 0l;
        while (while_method_2(v75)){
            long v77;
            v77 = 0l;
            while (while_method_1(v77)){
                bool v79;
                v79 = 0l <= v77;
                bool v81;
                if (v79){
                    bool v80;
                    v80 = v77 < 4l;
                    v81 = v80;
                } else {
                    v81 = false;
                }
                bool v82;
                v82 = v81 == false;
                if (v82){
                    assert("The indices should be inside the range of the dimension." && v81);
                } else {
                }
                bool v84;
                v84 = 0l <= v75;
                bool v86;
                if (v84){
                    bool v85;
                    v85 = v75 < 1l;
                    v86 = v85;
                } else {
                    v86 = false;
                }
                bool v87;
                v87 = v86 == false;
                if (v87){
                    assert("The indices should be inside the range of the dimension." && v86);
                } else {
                }
                long v89;
                v89 = v75 * 4l;
                long v90;
                v90 = v77 + v89;
                bool v91;
                v91 = 0l <= v53;
                bool v93;
                if (v91){
                    bool v92;
                    v92 = v53 < 4l;
                    v93 = v92;
                } else {
                    v93 = false;
                }
                bool v94;
                v94 = v93 == false;
                if (v94){
                    assert("The indices should be inside the range of the dimension." && v93);
                } else {
                }
                long v96;
                v96 = v53 * 4l;
                long v97;
                v97 = v90 + v96;
                assert("Tensor range check" && 0 <= v75 && v75 < 1l);
                assert("Tensor range check" && 0 <= v77 && v77 < 4l);
                long v98;
                v98 = 4l * v75;
                long v99;
                v99 = v98 + v77;
                v67[v99] = v97;
                v77 += 1l ;
            }
            v75 += 1l ;
        }
        bool v100;
        v100 = 0l < v54;
        bool v102;
        if (v100){
            bool v101;
            v101 = v54 <= 128l;
            v102 = v101;
        } else {
            v102 = false;
        }
        bool v103;
        v103 = v102 == false;
        if (v103){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v102);
        } else {
        }
        bool v105;
        v105 = 0l < v62;
        bool v107;
        if (v105){
            bool v106;
            v106 = v62 <= 1l;
            v107 = v106;
        } else {
            v107 = false;
        }
        bool v108;
        v108 = v107 == false;
        if (v108){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v107);
        } else {
        }
        long v110;
        v110 = v62 * 128l;
        long v111;
        v111 = v110 + v54;
        long v112[4l];
        long v113;
        v113 = 0l;
        while (while_method_2(v113)){
            long v115;
            v115 = 0l;
            while (while_method_1(v115)){
                assert("Tensor range check" && 0 <= v113 && v113 < 1l);
                assert("Tensor range check" && 0 <= v115 && v115 < 4l);
                long v117;
                v117 = 4l * v113;
                long v118;
                v118 = v117 + v115;
                long v119;
                v119 = v67[v118];
                assert("Tensor range check" && 0 <= v113 && v113 < 1l);
                assert("Tensor range check" && 0 <= v115 && v115 < 4l);
                v112[v118] = v111;
                v115 += 1l ;
            }
            v113 += 1l ;
        }
        long v120;
        v120 = 0l;
        while (while_method_2(v120)){
            assert("Tensor range check" && 0 <= v120 && v120 < 1l);
            long v122;
            v122 = 16l * v120;
            long v123;
            v123 = v122 + v65;
            assert("Tensor range check" && 0 <= v120 && v120 < 1l);
            long v124;
            v124 = 4l * v120;
            int4* v125;
            v125 = reinterpret_cast<int4*>(v112 + v124);
            int4* v126;
            v126 = reinterpret_cast<int4*>(v9 + v123);
            assert("Pointer alignment check" && (unsigned long long)(v125) % 4l == 0 && (unsigned long long)(v126) % 4l == 0);
            *v126 = *v125;
            v120 += 1l ;
        }
        v62 += 1l ;
    }
    __syncthreads();
    long v127;
    v127 = threadIdx.x;
    bool v128;
    v128 = 0l <= v127;
    bool v129;
    v129 = v128 == false;
    if (v129){
        assert("The index needs to be zero or positive." && v128);
    } else {
    }
    long v131;
    v131 = v127 % 4l;
    long v132;
    v132 = v127 / 4l;
    bool v133;
    v133 = v132 < 128l;
    bool v134;
    v134 = v133 == false;
    if (v134){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v133);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v136 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v132 && v132 < 128l);
    assert("Tensor range check" && 0 <= v131 && v131 < 4l);
    long v137;
    v137 = 4l * v131;
    long v138;
    v138 = 16l * v132;
    long v139;
    v139 = v138 + v137;
    assert("Tensor range check" && 0 <= v132 && v132 < 128l);
    long v140;
    v140 = 0l;
    while (while_method_2(v140)){
        assert("Tensor range check" && 0 <= v140 && v140 < 1l);
        long v142;
        v142 = 2048l * v140;
        long v143;
        v143 = v142 + v139;
        float v144[4l];
        long v145[4l];
        long v146;
        v146 = 0l;
        while (while_method_2(v146)){
            assert("Tensor range check" && 0 <= v146 && v146 < 1l);
            long v148;
            v148 = 4l * v146;
            assert("Tensor range check" && 0 <= v146 && v146 < 1l);
            long v149;
            v149 = 16l * v146;
            long v150;
            v150 = v149 + v143;
            int4* v151;
            v151 = reinterpret_cast<int4*>(v0 + v150);
            int4* v152;
            v152 = reinterpret_cast<int4*>(v144 + v148);
            assert("Pointer alignment check" && (unsigned long long)(v151) % 4l == 0 && (unsigned long long)(v152) % 4l == 0);
            *v152 = *v151;
            v146 += 1l ;
        }
        long v153;
        v153 = 0l;
        while (while_method_2(v153)){
            long v155;
            v155 = 0l;
            while (while_method_1(v155)){
                bool v157;
                v157 = 0l <= v155;
                bool v159;
                if (v157){
                    bool v158;
                    v158 = v155 < 4l;
                    v159 = v158;
                } else {
                    v159 = false;
                }
                bool v160;
                v160 = v159 == false;
                if (v160){
                    assert("The indices should be inside the range of the dimension." && v159);
                } else {
                }
                bool v162;
                v162 = 0l <= v153;
                bool v164;
                if (v162){
                    bool v163;
                    v163 = v153 < 1l;
                    v164 = v163;
                } else {
                    v164 = false;
                }
                bool v165;
                v165 = v164 == false;
                if (v165){
                    assert("The indices should be inside the range of the dimension." && v164);
                } else {
                }
                long v167;
                v167 = v153 * 4l;
                long v168;
                v168 = v155 + v167;
                bool v169;
                v169 = 0l <= v131;
                bool v171;
                if (v169){
                    bool v170;
                    v170 = v131 < 4l;
                    v171 = v170;
                } else {
                    v171 = false;
                }
                bool v172;
                v172 = v171 == false;
                if (v172){
                    assert("The indices should be inside the range of the dimension." && v171);
                } else {
                }
                long v174;
                v174 = v131 * 4l;
                long v175;
                v175 = v168 + v174;
                assert("Tensor range check" && 0 <= v153 && v153 < 1l);
                assert("Tensor range check" && 0 <= v155 && v155 < 4l);
                long v176;
                v176 = 4l * v153;
                long v177;
                v177 = v176 + v155;
                v145[v177] = v175;
                v155 += 1l ;
            }
            v153 += 1l ;
        }
        bool v178;
        v178 = 0l < v132;
        bool v180;
        if (v178){
            bool v179;
            v179 = v132 <= 128l;
            v180 = v179;
        } else {
            v180 = false;
        }
        bool v181;
        v181 = v180 == false;
        if (v181){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v180);
        } else {
        }
        bool v183;
        v183 = 0l < v140;
        bool v185;
        if (v183){
            bool v184;
            v184 = v140 <= 1l;
            v185 = v184;
        } else {
            v185 = false;
        }
        bool v186;
        v186 = v185 == false;
        if (v186){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v185);
        } else {
        }
        long v188;
        v188 = v140 * 128l;
        long v189;
        v189 = v188 + v132;
        assert("Tensor range check" && 0 <= v140 && v140 < 1l);
        long v190;
        v190 = v140 + v132;
        v10[v190] = v189;
        v140 += 1l ;
    }
    __syncthreads();
    long v191;
    v191 = threadIdx.x;
    bool v192;
    v192 = 0l <= v191;
    bool v193;
    v193 = v192 == false;
    if (v193){
        assert("The index needs to be zero or positive." && v192);
    } else {
    }
    long v195;
    v195 = v191 % 4l;
    long v196;
    v196 = v191 / 4l;
    bool v197;
    v197 = v196 < 128l;
    bool v198;
    v198 = v197 == false;
    if (v198){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v197);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v200 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v196 && v196 < 128l);
    assert("Tensor range check" && 0 <= v195 && v195 < 4l);
    long v201;
    v201 = 4l * v195;
    long v202;
    v202 = 16l * v196;
    long v203;
    v203 = v202 + v201;
    assert("Tensor range check" && 0 <= v196 && v196 < 128l);
    assert("Tensor range check" && 0 <= v195 && v195 < 4l);
    long v204;
    v204 = 0l;
    while (while_method_2(v204)){
        assert("Tensor range check" && 0 <= v204 && v204 < 1l);
        long v206;
        v206 = 2048l * v204;
        long v207;
        v207 = v206 + v203;
        assert("Tensor range check" && 0 <= v204 && v204 < 1l);
        float v208[4l];
        long v209[4l];
        long v210;
        v210 = 0l;
        while (while_method_2(v210)){
            assert("Tensor range check" && 0 <= v210 && v210 < 1l);
            long v212;
            v212 = 4l * v210;
            assert("Tensor range check" && 0 <= v210 && v210 < 1l);
            long v213;
            v213 = 16l * v210;
            long v214;
            v214 = v213 + v207;
            int4* v215;
            v215 = reinterpret_cast<int4*>(v0 + v214);
            int4* v216;
            v216 = reinterpret_cast<int4*>(v208 + v212);
            assert("Pointer alignment check" && (unsigned long long)(v215) % 4l == 0 && (unsigned long long)(v216) % 4l == 0);
            *v216 = *v215;
            v210 += 1l ;
        }
        long v217;
        v217 = 0l;
        while (while_method_2(v217)){
            long v219;
            v219 = 0l;
            while (while_method_1(v219)){
                bool v221;
                v221 = 0l <= v219;
                bool v223;
                if (v221){
                    bool v222;
                    v222 = v219 < 4l;
                    v223 = v222;
                } else {
                    v223 = false;
                }
                bool v224;
                v224 = v223 == false;
                if (v224){
                    assert("The indices should be inside the range of the dimension." && v223);
                } else {
                }
                bool v226;
                v226 = 0l <= v217;
                bool v228;
                if (v226){
                    bool v227;
                    v227 = v217 < 1l;
                    v228 = v227;
                } else {
                    v228 = false;
                }
                bool v229;
                v229 = v228 == false;
                if (v229){
                    assert("The indices should be inside the range of the dimension." && v228);
                } else {
                }
                long v231;
                v231 = v217 * 4l;
                long v232;
                v232 = v219 + v231;
                bool v233;
                v233 = 0l <= v195;
                bool v235;
                if (v233){
                    bool v234;
                    v234 = v195 < 4l;
                    v235 = v234;
                } else {
                    v235 = false;
                }
                bool v236;
                v236 = v235 == false;
                if (v236){
                    assert("The indices should be inside the range of the dimension." && v235);
                } else {
                }
                long v238;
                v238 = v195 * 4l;
                long v239;
                v239 = v232 + v238;
                assert("Tensor range check" && 0 <= v217 && v217 < 1l);
                assert("Tensor range check" && 0 <= v219 && v219 < 4l);
                long v240;
                v240 = 4l * v217;
                long v241;
                v241 = v240 + v219;
                v209[v241] = v239;
                v219 += 1l ;
            }
            v217 += 1l ;
        }
        bool v242;
        v242 = 0l < v196;
        bool v244;
        if (v242){
            bool v243;
            v243 = v196 <= 128l;
            v244 = v243;
        } else {
            v244 = false;
        }
        bool v245;
        v245 = v244 == false;
        if (v245){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v244);
        } else {
        }
        bool v247;
        v247 = 0l < v204;
        bool v249;
        if (v247){
            bool v248;
            v248 = v204 <= 1l;
            v249 = v248;
        } else {
            v249 = false;
        }
        bool v250;
        v250 = v249 == false;
        if (v250){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v249);
        } else {
        }
        long v252;
        v252 = v204 * 128l;
        long v253;
        v253 = v252 + v196;
        float v254;
        v254 = 0.0f;
        long v255;
        v255 = 0l;
        while (while_method_2(v255)){
            long v257;
            v257 = 0l;
            while (while_method_1(v257)){
                assert("Tensor range check" && 0 <= v255 && v255 < 1l);
                assert("Tensor range check" && 0 <= v257 && v257 < 4l);
                long v259;
                v259 = 4l * v255;
                long v260;
                v260 = v259 + v257;
                float v261;
                v261 = v208[v260];
                float v262;
                v262 = v261 + v254;
                v254 = v262;
                v257 += 1l ;
            }
            v255 += 1l ;
        }
        Fun0 v263;
        v263 = ClosureMethod1;
        float v264;
        v264 = cooperative_groups::reduce(v200, v254, v263);
        float v265;
        v265 = v264 / 16.0f;
        float v266[4l];
        long v267;
        v267 = 0l;
        while (while_method_2(v267)){
            long v269;
            v269 = 0l;
            while (while_method_1(v269)){
                assert("Tensor range check" && 0 <= v267 && v267 < 1l);
                assert("Tensor range check" && 0 <= v269 && v269 < 4l);
                long v271;
                v271 = 4l * v267;
                long v272;
                v272 = v271 + v269;
                float v273;
                v273 = v208[v272];
                float v274;
                v274 = v273 - v265;
                float v275;
                v275 = exp(v274);
                assert("Tensor range check" && 0 <= v267 && v267 < 1l);
                assert("Tensor range check" && 0 <= v269 && v269 < 4l);
                v266[v272] = v275;
                v269 += 1l ;
            }
            v267 += 1l ;
        }
        float v276;
        v276 = 0.0f;
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
                v283 = v266[v282];
                float v284;
                v284 = v283 + v276;
                v276 = v284;
                v279 += 1l ;
            }
            v277 += 1l ;
        }
        float v285;
        v285 = cooperative_groups::reduce(v200, v276, v263);
        float v286[4l];
        long v287;
        v287 = 0l;
        while (while_method_2(v287)){
            long v289;
            v289 = 0l;
            while (while_method_1(v289)){
                assert("Tensor range check" && 0 <= v287 && v287 < 1l);
                assert("Tensor range check" && 0 <= v289 && v289 < 4l);
                long v291;
                v291 = 4l * v287;
                long v292;
                v292 = v291 + v289;
                float v293;
                v293 = v266[v292];
                float v294;
                v294 = v293 / v285;
                assert("Tensor range check" && 0 <= v287 && v287 < 1l);
                assert("Tensor range check" && 0 <= v289 && v289 < 4l);
                v286[v292] = v294;
                v289 += 1l ;
            }
            v287 += 1l ;
        }
        long v295;
        v295 = 0l;
        while (while_method_2(v295)){
            assert("Tensor range check" && 0 <= v295 && v295 < 1l);
            long v297;
            v297 = 16l * v295;
            long v298;
            v298 = v297 + v207;
            assert("Tensor range check" && 0 <= v295 && v295 < 1l);
            long v299;
            v299 = 4l * v295;
            int4* v300;
            v300 = reinterpret_cast<int4*>(v286 + v299);
            int4* v301;
            v301 = reinterpret_cast<int4*>(v3 + v298);
            assert("Pointer alignment check" && (unsigned long long)(v300) % 4l == 0 && (unsigned long long)(v301) % 4l == 0);
            *v301 = *v300;
            v295 += 1l ;
        }
        v204 += 1l ;
    }
    __syncthreads();
    long v302;
    v302 = threadIdx.x;
    bool v303;
    v303 = 0l <= v302;
    bool v304;
    v304 = v303 == false;
    if (v304){
        assert("The index needs to be zero or positive." && v303);
    } else {
    }
    long v306;
    v306 = v302 % 4l;
    long v307;
    v307 = v302 / 4l;
    bool v308;
    v308 = v307 < 128l;
    bool v309;
    v309 = v308 == false;
    if (v309){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v308);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v311 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v307 && v307 < 128l);
    assert("Tensor range check" && 0 <= v306 && v306 < 4l);
    long v312;
    v312 = 4l * v306;
    long v313;
    v313 = 16l * v307;
    long v314;
    v314 = v313 + v312;
    assert("Tensor range check" && 0 <= v307 && v307 < 128l);
    assert("Tensor range check" && 0 <= v306 && v306 < 4l);
    long v315;
    v315 = 0l;
    while (while_method_2(v315)){
        assert("Tensor range check" && 0 <= v315 && v315 < 1l);
        long v317;
        v317 = 2048l * v315;
        long v318;
        v318 = v317 + v314;
        assert("Tensor range check" && 0 <= v315 && v315 < 1l);
        float v319[4l];
        long v320[4l];
        long v321;
        v321 = 0l;
        while (while_method_2(v321)){
            assert("Tensor range check" && 0 <= v321 && v321 < 1l);
            long v323;
            v323 = 4l * v321;
            assert("Tensor range check" && 0 <= v321 && v321 < 1l);
            long v324;
            v324 = 16l * v321;
            long v325;
            v325 = v324 + v318;
            int4* v326;
            v326 = reinterpret_cast<int4*>(v0 + v325);
            int4* v327;
            v327 = reinterpret_cast<int4*>(v319 + v323);
            assert("Pointer alignment check" && (unsigned long long)(v326) % 4l == 0 && (unsigned long long)(v327) % 4l == 0);
            *v327 = *v326;
            v321 += 1l ;
        }
        long v328;
        v328 = 0l;
        while (while_method_2(v328)){
            long v330;
            v330 = 0l;
            while (while_method_1(v330)){
                bool v332;
                v332 = 0l <= v330;
                bool v334;
                if (v332){
                    bool v333;
                    v333 = v330 < 4l;
                    v334 = v333;
                } else {
                    v334 = false;
                }
                bool v335;
                v335 = v334 == false;
                if (v335){
                    assert("The indices should be inside the range of the dimension." && v334);
                } else {
                }
                bool v337;
                v337 = 0l <= v328;
                bool v339;
                if (v337){
                    bool v338;
                    v338 = v328 < 1l;
                    v339 = v338;
                } else {
                    v339 = false;
                }
                bool v340;
                v340 = v339 == false;
                if (v340){
                    assert("The indices should be inside the range of the dimension." && v339);
                } else {
                }
                long v342;
                v342 = v328 * 4l;
                long v343;
                v343 = v330 + v342;
                bool v344;
                v344 = 0l <= v306;
                bool v346;
                if (v344){
                    bool v345;
                    v345 = v306 < 4l;
                    v346 = v345;
                } else {
                    v346 = false;
                }
                bool v347;
                v347 = v346 == false;
                if (v347){
                    assert("The indices should be inside the range of the dimension." && v346);
                } else {
                }
                long v349;
                v349 = v306 * 4l;
                long v350;
                v350 = v343 + v349;
                assert("Tensor range check" && 0 <= v328 && v328 < 1l);
                assert("Tensor range check" && 0 <= v330 && v330 < 4l);
                long v351;
                v351 = 4l * v328;
                long v352;
                v352 = v351 + v330;
                v320[v352] = v350;
                v330 += 1l ;
            }
            v328 += 1l ;
        }
        bool v353;
        v353 = 0l < v307;
        bool v355;
        if (v353){
            bool v354;
            v354 = v307 <= 128l;
            v355 = v354;
        } else {
            v355 = false;
        }
        bool v356;
        v356 = v355 == false;
        if (v356){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v355);
        } else {
        }
        bool v358;
        v358 = 0l < v315;
        bool v360;
        if (v358){
            bool v359;
            v359 = v315 <= 1l;
            v360 = v359;
        } else {
            v360 = false;
        }
        bool v361;
        v361 = v360 == false;
        if (v361){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v360);
        } else {
        }
        long v363;
        v363 = v315 * 128l;
        long v364;
        v364 = v363 + v307;
        float v365[4l];
        long v366;
        v366 = 0l;
        while (while_method_2(v366)){
            long v368;
            v368 = 0l;
            while (while_method_1(v368)){
                assert("Tensor range check" && 0 <= v366 && v366 < 1l);
                assert("Tensor range check" && 0 <= v368 && v368 < 4l);
                long v370;
                v370 = 4l * v366;
                long v371;
                v371 = v370 + v368;
                float v372;
                v372 = v319[v371];
                float v373;
                v373 = v372 * v372;
                assert("Tensor range check" && 0 <= v366 && v366 < 1l);
                assert("Tensor range check" && 0 <= v368 && v368 < 4l);
                v365[v371] = v373;
                v368 += 1l ;
            }
            v366 += 1l ;
        }
        float v374;
        v374 = 0.0f;
        long v375;
        v375 = 0l;
        while (while_method_2(v375)){
            long v377;
            v377 = 0l;
            while (while_method_1(v377)){
                assert("Tensor range check" && 0 <= v375 && v375 < 1l);
                assert("Tensor range check" && 0 <= v377 && v377 < 4l);
                long v379;
                v379 = 4l * v375;
                long v380;
                v380 = v379 + v377;
                float v381;
                v381 = v365[v380];
                float v382;
                v382 = v381 + v374;
                v374 = v382;
                v377 += 1l ;
            }
            v375 += 1l ;
        }
        Fun0 v383;
        v383 = ClosureMethod1;
        float v384;
        v384 = cooperative_groups::reduce(v311, v374, v383);
        float v385[4l];
        long v386;
        v386 = 0l;
        while (while_method_2(v386)){
            long v388;
            v388 = 0l;
            while (while_method_1(v388)){
                assert("Tensor range check" && 0 <= v386 && v386 < 1l);
                assert("Tensor range check" && 0 <= v388 && v388 < 4l);
                long v390;
                v390 = 4l * v386;
                long v391;
                v391 = v390 + v388;
                float v392;
                v392 = v365[v391];
                float v393;
                v393 = v392 / v384;
                assert("Tensor range check" && 0 <= v386 && v386 < 1l);
                assert("Tensor range check" && 0 <= v388 && v388 < 4l);
                v385[v391] = v393;
                v388 += 1l ;
            }
            v386 += 1l ;
        }
        long v394;
        v394 = 0l;
        while (while_method_2(v394)){
            assert("Tensor range check" && 0 <= v394 && v394 < 1l);
            long v396;
            v396 = 16l * v394;
            long v397;
            v397 = v396 + v318;
            assert("Tensor range check" && 0 <= v394 && v394 < 1l);
            long v398;
            v398 = 4l * v394;
            int4* v399;
            v399 = reinterpret_cast<int4*>(v385 + v398);
            int4* v400;
            v400 = reinterpret_cast<int4*>(v6 + v397);
            assert("Pointer alignment check" && (unsigned long long)(v399) % 4l == 0 && (unsigned long long)(v400) % 4l == 0);
            *v400 = *v399;
            v394 += 1l ;
        }
        v315 += 1l ;
    }
    __syncthreads();
    long v401;
    v401 = threadIdx.x;
    bool v402;
    v402 = 0l <= v401;
    bool v403;
    v403 = v402 == false;
    if (v403){
        assert("The index needs to be zero or positive." && v402);
    } else {
    }
    long v405;
    v405 = v401 % 4l;
    long v406;
    v406 = v401 / 4l;
    bool v407;
    v407 = v406 < 128l;
    bool v408;
    v408 = v407 == false;
    if (v408){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v407);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v410 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v406 && v406 < 128l);
    assert("Tensor range check" && 0 <= v405 && v405 < 4l);
    long v411;
    v411 = 4l * v405;
    long v412;
    v412 = 16l * v406;
    long v413;
    v413 = v412 + v411;
    assert("Tensor range check" && 0 <= v406 && v406 < 128l);
    long v414;
    v414 = 0l;
    while (while_method_2(v414)){
        assert("Tensor range check" && 0 <= v414 && v414 < 1l);
        long v416;
        v416 = 2048l * v414;
        long v417;
        v417 = v416 + v413;
        float v418[4l];
        long v419[4l];
        long v420;
        v420 = 0l;
        while (while_method_2(v420)){
            assert("Tensor range check" && 0 <= v420 && v420 < 1l);
            long v422;
            v422 = 4l * v420;
            assert("Tensor range check" && 0 <= v420 && v420 < 1l);
            long v423;
            v423 = 16l * v420;
            long v424;
            v424 = v423 + v417;
            int4* v425;
            v425 = reinterpret_cast<int4*>(v0 + v424);
            int4* v426;
            v426 = reinterpret_cast<int4*>(v418 + v422);
            assert("Pointer alignment check" && (unsigned long long)(v425) % 4l == 0 && (unsigned long long)(v426) % 4l == 0);
            *v426 = *v425;
            v420 += 1l ;
        }
        long v427;
        v427 = 0l;
        while (while_method_2(v427)){
            long v429;
            v429 = 0l;
            while (while_method_1(v429)){
                bool v431;
                v431 = 0l <= v429;
                bool v433;
                if (v431){
                    bool v432;
                    v432 = v429 < 4l;
                    v433 = v432;
                } else {
                    v433 = false;
                }
                bool v434;
                v434 = v433 == false;
                if (v434){
                    assert("The indices should be inside the range of the dimension." && v433);
                } else {
                }
                bool v436;
                v436 = 0l <= v427;
                bool v438;
                if (v436){
                    bool v437;
                    v437 = v427 < 1l;
                    v438 = v437;
                } else {
                    v438 = false;
                }
                bool v439;
                v439 = v438 == false;
                if (v439){
                    assert("The indices should be inside the range of the dimension." && v438);
                } else {
                }
                long v441;
                v441 = v427 * 4l;
                long v442;
                v442 = v429 + v441;
                bool v443;
                v443 = 0l <= v405;
                bool v445;
                if (v443){
                    bool v444;
                    v444 = v405 < 4l;
                    v445 = v444;
                } else {
                    v445 = false;
                }
                bool v446;
                v446 = v445 == false;
                if (v446){
                    assert("The indices should be inside the range of the dimension." && v445);
                } else {
                }
                long v448;
                v448 = v405 * 4l;
                long v449;
                v449 = v442 + v448;
                assert("Tensor range check" && 0 <= v427 && v427 < 1l);
                assert("Tensor range check" && 0 <= v429 && v429 < 4l);
                long v450;
                v450 = 4l * v427;
                long v451;
                v451 = v450 + v429;
                v419[v451] = v449;
                v429 += 1l ;
            }
            v427 += 1l ;
        }
        bool v452;
        v452 = 0l < v406;
        bool v454;
        if (v452){
            bool v453;
            v453 = v406 <= 128l;
            v454 = v453;
        } else {
            v454 = false;
        }
        bool v455;
        v455 = v454 == false;
        if (v455){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v454);
        } else {
        }
        bool v457;
        v457 = 0l < v414;
        bool v459;
        if (v457){
            bool v458;
            v458 = v414 <= 1l;
            v459 = v458;
        } else {
            v459 = false;
        }
        bool v460;
        v460 = v459 == false;
        if (v460){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v459);
        } else {
        }
        long v462;
        v462 = v414 * 128l;
        long v463;
        v463 = v462 + v406;
        float v464; long v465;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v464 = tmp1.v0; v465 = tmp1.v1;
        long v466;
        v466 = 0l;
        while (while_method_2(v466)){
            long v468;
            v468 = 0l;
            while (while_method_1(v468)){
                assert("Tensor range check" && 0 <= v466 && v466 < 1l);
                assert("Tensor range check" && 0 <= v468 && v468 < 4l);
                long v470;
                v470 = 4l * v466;
                long v471;
                v471 = v470 + v468;
                float v472;
                v472 = v418[v471];
                long v473;
                v473 = v419[v471];
                bool v474;
                v474 = v472 > v464;
                float v475; long v476;
                if (v474){
                    v475 = v472; v476 = v473;
                } else {
                    v475 = v464; v476 = v465;
                }
                v464 = v475;
                v465 = v476;
                v468 += 1l ;
            }
            v466 += 1l ;
        }
        Fun1 v477;
        v477 = ClosureMethod2;
        float v478; long v479;
        Tuple1 tmp2 = cooperative_groups::reduce(v410, Tuple1(v464, v465), v477);
        v478 = tmp2.v0; v479 = tmp2.v1;
        assert("Tensor range check" && 0 <= v414 && v414 < 1l);
        long v480;
        v480 = v414 + v406;
        v7[v480] = v479;
        v414 += 1l ;
    }
    __syncthreads();
    long v481;
    v481 = threadIdx.x;
    bool v482;
    v482 = 0l <= v481;
    bool v483;
    v483 = v482 == false;
    if (v483){
        assert("The index needs to be zero or positive." && v482);
    } else {
    }
    long v485;
    v485 = v481 % 4l;
    long v486;
    v486 = v481 / 4l;
    bool v487;
    v487 = v486 < 128l;
    bool v488;
    v488 = v487 == false;
    if (v488){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v487);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v490 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v486 && v486 < 128l);
    assert("Tensor range check" && 0 <= v485 && v485 < 4l);
    long v491;
    v491 = 4l * v485;
    long v492;
    v492 = 16l * v486;
    long v493;
    v493 = v492 + v491;
    assert("Tensor range check" && 0 <= v486 && v486 < 128l);
    assert("Tensor range check" && 0 <= v485 && v485 < 4l);
    long v494;
    v494 = 0l;
    while (while_method_2(v494)){
        assert("Tensor range check" && 0 <= v494 && v494 < 1l);
        long v496;
        v496 = 2048l * v494;
        long v497;
        v497 = v496 + v493;
        assert("Tensor range check" && 0 <= v494 && v494 < 1l);
        float v498[4l];
        long v499[4l];
        long v500;
        v500 = 0l;
        while (while_method_2(v500)){
            assert("Tensor range check" && 0 <= v500 && v500 < 1l);
            long v502;
            v502 = 4l * v500;
            assert("Tensor range check" && 0 <= v500 && v500 < 1l);
            long v503;
            v503 = 16l * v500;
            long v504;
            v504 = v503 + v497;
            int4* v505;
            v505 = reinterpret_cast<int4*>(v0 + v504);
            int4* v506;
            v506 = reinterpret_cast<int4*>(v498 + v502);
            assert("Pointer alignment check" && (unsigned long long)(v505) % 4l == 0 && (unsigned long long)(v506) % 4l == 0);
            *v506 = *v505;
            v500 += 1l ;
        }
        long v507;
        v507 = 0l;
        while (while_method_2(v507)){
            long v509;
            v509 = 0l;
            while (while_method_1(v509)){
                bool v511;
                v511 = 0l <= v509;
                bool v513;
                if (v511){
                    bool v512;
                    v512 = v509 < 4l;
                    v513 = v512;
                } else {
                    v513 = false;
                }
                bool v514;
                v514 = v513 == false;
                if (v514){
                    assert("The indices should be inside the range of the dimension." && v513);
                } else {
                }
                bool v516;
                v516 = 0l <= v507;
                bool v518;
                if (v516){
                    bool v517;
                    v517 = v507 < 1l;
                    v518 = v517;
                } else {
                    v518 = false;
                }
                bool v519;
                v519 = v518 == false;
                if (v519){
                    assert("The indices should be inside the range of the dimension." && v518);
                } else {
                }
                long v521;
                v521 = v507 * 4l;
                long v522;
                v522 = v509 + v521;
                bool v523;
                v523 = 0l <= v485;
                bool v525;
                if (v523){
                    bool v524;
                    v524 = v485 < 4l;
                    v525 = v524;
                } else {
                    v525 = false;
                }
                bool v526;
                v526 = v525 == false;
                if (v526){
                    assert("The indices should be inside the range of the dimension." && v525);
                } else {
                }
                long v528;
                v528 = v485 * 4l;
                long v529;
                v529 = v522 + v528;
                assert("Tensor range check" && 0 <= v507 && v507 < 1l);
                assert("Tensor range check" && 0 <= v509 && v509 < 4l);
                long v530;
                v530 = 4l * v507;
                long v531;
                v531 = v530 + v509;
                v499[v531] = v529;
                v509 += 1l ;
            }
            v507 += 1l ;
        }
        bool v532;
        v532 = 0l < v486;
        bool v534;
        if (v532){
            bool v533;
            v533 = v486 <= 128l;
            v534 = v533;
        } else {
            v534 = false;
        }
        bool v535;
        v535 = v534 == false;
        if (v535){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v534);
        } else {
        }
        bool v537;
        v537 = 0l < v494;
        bool v539;
        if (v537){
            bool v538;
            v538 = v494 <= 1l;
            v539 = v538;
        } else {
            v539 = false;
        }
        bool v540;
        v540 = v539 == false;
        if (v540){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v539);
        } else {
        }
        long v542;
        v542 = v494 * 128l;
        long v543;
        v543 = v542 + v486;
        float v544;
        v544 = 0.0f;
        long v545;
        v545 = 0l;
        while (while_method_2(v545)){
            long v547;
            v547 = 0l;
            while (while_method_1(v547)){
                assert("Tensor range check" && 0 <= v545 && v545 < 1l);
                assert("Tensor range check" && 0 <= v547 && v547 < 4l);
                long v549;
                v549 = 4l * v545;
                long v550;
                v550 = v549 + v547;
                float v551;
                v551 = v498[v550];
                float v552;
                v552 = v551 + v544;
                v544 = v552;
                v547 += 1l ;
            }
            v545 += 1l ;
        }
        Fun0 v553;
        v553 = ClosureMethod1;
        float v554;
        v554 = cooperative_groups::reduce(v490, v544, v553);
        float v555;
        v555 = v554 / 16.0f;
        float v556[4l];
        long v557;
        v557 = 0l;
        while (while_method_2(v557)){
            long v559;
            v559 = 0l;
            while (while_method_1(v559)){
                assert("Tensor range check" && 0 <= v557 && v557 < 1l);
                assert("Tensor range check" && 0 <= v559 && v559 < 4l);
                long v561;
                v561 = 4l * v557;
                long v562;
                v562 = v561 + v559;
                float v563;
                v563 = v498[v562];
                float v564;
                v564 = v563 - v555;
                float v565;
                v565 = exp(v564);
                assert("Tensor range check" && 0 <= v557 && v557 < 1l);
                assert("Tensor range check" && 0 <= v559 && v559 < 4l);
                v556[v562] = v565;
                v559 += 1l ;
            }
            v557 += 1l ;
        }
        float v566;
        v566 = 0.0f;
        long v567;
        v567 = 0l;
        while (while_method_2(v567)){
            long v569;
            v569 = 0l;
            while (while_method_1(v569)){
                assert("Tensor range check" && 0 <= v567 && v567 < 1l);
                assert("Tensor range check" && 0 <= v569 && v569 < 4l);
                long v571;
                v571 = 4l * v567;
                long v572;
                v572 = v571 + v569;
                float v573;
                v573 = v556[v572];
                float v574;
                v574 = v573 + v566;
                v566 = v574;
                v569 += 1l ;
            }
            v567 += 1l ;
        }
        float v575;
        v575 = cooperative_groups::reduce(v490, v566, v553);
        float v576[4l];
        long v577;
        v577 = 0l;
        while (while_method_2(v577)){
            long v579;
            v579 = 0l;
            while (while_method_1(v579)){
                assert("Tensor range check" && 0 <= v577 && v577 < 1l);
                assert("Tensor range check" && 0 <= v579 && v579 < 4l);
                long v581;
                v581 = 4l * v577;
                long v582;
                v582 = v581 + v579;
                float v583;
                v583 = v556[v582];
                float v584;
                v584 = v583 / v575;
                assert("Tensor range check" && 0 <= v577 && v577 < 1l);
                assert("Tensor range check" && 0 <= v579 && v579 < 4l);
                v576[v582] = v584;
                v579 += 1l ;
            }
            v577 += 1l ;
        }
        float v585[4l];
        float v586;
        v586 = 0.0f;
        long v587;
        v587 = 0l;
        while (while_method_2(v587)){
            assert("Tensor range check" && 0 <= v587 && v587 < 1l);
            long v589;
            v589 = 4l * v587;
            assert("Tensor range check" && 0 <= v587 && v587 < 1l);
            long v590; float v591;
            Tuple0 tmp3 = Tuple0(0l, 0.0f);
            v590 = tmp3.v0; v591 = tmp3.v1;
            while (while_method_1(v590)){
                assert("Tensor range check" && 0 <= v590 && v590 < 4l);
                long v593;
                v593 = v590 + v589;
                float v594;
                v594 = v576[v593];
                float v595;
                v595 = v594 + v591;
                v591 = v595;
                v590 += 1l ;
            }
            Fun0 v596;
            v596 = ClosureMethod3;
            float v597;
            v597 = cooperative_groups::inclusive_scan(v490, v591, v596);
            float v598;
            v598 = v490.shfl(v597,v490.num_threads()-1);
            bool v599;
            v599 = v490.num_threads() <= 32;
            bool v600;
            v600 = v599 == false;
            if (v600){
                assert("The thread block tile in the exclusive scan has to be less than or equal 32." && v599);
            } else {
            }
            float v602;
            v602 = v490.shfl_up(v597,1);
            bool v603;
            v603 = v490.thread_rank() == 0;
            float v604;
            if (v603){
                v604 = 0.0f;
            } else {
                v604 = v602;
            }
            float v605;
            v605 = v586 + v604;
            long v606; float v607;
            Tuple0 tmp4 = Tuple0(0l, v605);
            v606 = tmp4.v0; v607 = tmp4.v1;
            while (while_method_1(v606)){
                assert("Tensor range check" && 0 <= v606 && v606 < 4l);
                long v609;
                v609 = v606 + v589;
                float v610;
                v610 = v576[v609];
                assert("Tensor range check" && 0 <= v606 && v606 < 4l);
                v585[v609] = v607;
                float v611;
                v611 = v610 + v607;
                v607 = v611;
                v606 += 1l ;
            }
            float v612;
            v612 = v586 + v598;
            v586 = v612;
            v587 += 1l ;
        }
        long v613;
        v613 = 0l;
        while (while_method_2(v613)){
            assert("Tensor range check" && 0 <= v613 && v613 < 1l);
            long v615;
            v615 = 16l * v613;
            long v616;
            v616 = v615 + v497;
            assert("Tensor range check" && 0 <= v613 && v613 < 1l);
            long v617;
            v617 = 4l * v613;
            int4* v618;
            v618 = reinterpret_cast<int4*>(v576 + v617);
            int4* v619;
            v619 = reinterpret_cast<int4*>(v4 + v616);
            assert("Pointer alignment check" && (unsigned long long)(v618) % 4l == 0 && (unsigned long long)(v619) % 4l == 0);
            *v619 = *v618;
            int4* v620;
            v620 = reinterpret_cast<int4*>(v585 + v617);
            int4* v621;
            v621 = reinterpret_cast<int4*>(v5 + v616);
            assert("Pointer alignment check" && (unsigned long long)(v620) % 4l == 0 && (unsigned long long)(v621) % 4l == 0);
            *v621 = *v620;
            v613 += 1l ;
        }
        v494 += 1l ;
    }
    __syncthreads();
    long v622;
    v622 = threadIdx.x;
    bool v623;
    v623 = 0l <= v622;
    bool v624;
    v624 = v623 == false;
    if (v624){
        assert("The index needs to be zero or positive." && v623);
    } else {
    }
    long v626;
    v626 = v622 % 4l;
    long v627;
    v627 = v622 / 4l;
    bool v628;
    v628 = v627 < 128l;
    bool v629;
    v629 = v628 == false;
    if (v629){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v628);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v631 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v627 && v627 < 128l);
    assert("Tensor range check" && 0 <= v626 && v626 < 4l);
    long v632;
    v632 = 4l * v626;
    long v633;
    v633 = 16l * v627;
    long v634;
    v634 = v633 + v632;
    assert("Tensor range check" && 0 <= v627 && v627 < 128l);
    long v635;
    v635 = 0l;
    while (while_method_2(v635)){
        assert("Tensor range check" && 0 <= v635 && v635 < 1l);
        long v637;
        v637 = 2048l * v635;
        long v638;
        v638 = v637 + v634;
        float v639[4l];
        long v640[4l];
        long v641;
        v641 = 0l;
        while (while_method_2(v641)){
            assert("Tensor range check" && 0 <= v641 && v641 < 1l);
            long v643;
            v643 = 4l * v641;
            assert("Tensor range check" && 0 <= v641 && v641 < 1l);
            long v644;
            v644 = 16l * v641;
            long v645;
            v645 = v644 + v638;
            int4* v646;
            v646 = reinterpret_cast<int4*>(v0 + v645);
            int4* v647;
            v647 = reinterpret_cast<int4*>(v639 + v643);
            assert("Pointer alignment check" && (unsigned long long)(v646) % 4l == 0 && (unsigned long long)(v647) % 4l == 0);
            *v647 = *v646;
            v641 += 1l ;
        }
        long v648;
        v648 = 0l;
        while (while_method_2(v648)){
            long v650;
            v650 = 0l;
            while (while_method_1(v650)){
                bool v652;
                v652 = 0l <= v650;
                bool v654;
                if (v652){
                    bool v653;
                    v653 = v650 < 4l;
                    v654 = v653;
                } else {
                    v654 = false;
                }
                bool v655;
                v655 = v654 == false;
                if (v655){
                    assert("The indices should be inside the range of the dimension." && v654);
                } else {
                }
                bool v657;
                v657 = 0l <= v648;
                bool v659;
                if (v657){
                    bool v658;
                    v658 = v648 < 1l;
                    v659 = v658;
                } else {
                    v659 = false;
                }
                bool v660;
                v660 = v659 == false;
                if (v660){
                    assert("The indices should be inside the range of the dimension." && v659);
                } else {
                }
                long v662;
                v662 = v648 * 4l;
                long v663;
                v663 = v650 + v662;
                bool v664;
                v664 = 0l <= v626;
                bool v666;
                if (v664){
                    bool v665;
                    v665 = v626 < 4l;
                    v666 = v665;
                } else {
                    v666 = false;
                }
                bool v667;
                v667 = v666 == false;
                if (v667){
                    assert("The indices should be inside the range of the dimension." && v666);
                } else {
                }
                long v669;
                v669 = v626 * 4l;
                long v670;
                v670 = v663 + v669;
                assert("Tensor range check" && 0 <= v648 && v648 < 1l);
                assert("Tensor range check" && 0 <= v650 && v650 < 4l);
                long v671;
                v671 = 4l * v648;
                long v672;
                v672 = v671 + v650;
                v640[v672] = v670;
                v650 += 1l ;
            }
            v648 += 1l ;
        }
        bool v673;
        v673 = 0l < v627;
        bool v675;
        if (v673){
            bool v674;
            v674 = v627 <= 128l;
            v675 = v674;
        } else {
            v675 = false;
        }
        bool v676;
        v676 = v675 == false;
        if (v676){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v675);
        } else {
        }
        bool v678;
        v678 = 0l < v635;
        bool v680;
        if (v678){
            bool v679;
            v679 = v635 <= 1l;
            v680 = v679;
        } else {
            v680 = false;
        }
        bool v681;
        v681 = v680 == false;
        if (v681){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v680);
        } else {
        }
        long v683;
        v683 = v635 * 128l;
        long v684;
        v684 = v683 + v627;
        float v685;
        v685 = 0.0f;
        long v686;
        v686 = 0l;
        while (while_method_2(v686)){
            long v688;
            v688 = 0l;
            while (while_method_1(v688)){
                assert("Tensor range check" && 0 <= v686 && v686 < 1l);
                assert("Tensor range check" && 0 <= v688 && v688 < 4l);
                long v690;
                v690 = 4l * v686;
                long v691;
                v691 = v690 + v688;
                float v692;
                v692 = v639[v691];
                float v693;
                v693 = v692 + v685;
                v685 = v693;
                v688 += 1l ;
            }
            v686 += 1l ;
        }
        Fun0 v694;
        v694 = ClosureMethod1;
        float v695;
        v695 = cooperative_groups::reduce(v631, v685, v694);
        float v696;
        v696 = v695 / 16.0f;
        float v697[4l];
        long v698;
        v698 = 0l;
        while (while_method_2(v698)){
            long v700;
            v700 = 0l;
            while (while_method_1(v700)){
                assert("Tensor range check" && 0 <= v698 && v698 < 1l);
                assert("Tensor range check" && 0 <= v700 && v700 < 4l);
                long v702;
                v702 = 4l * v698;
                long v703;
                v703 = v702 + v700;
                float v704;
                v704 = v639[v703];
                float v705;
                v705 = v704 - v696;
                float v706;
                v706 = exp(v705);
                assert("Tensor range check" && 0 <= v698 && v698 < 1l);
                assert("Tensor range check" && 0 <= v700 && v700 < 4l);
                v697[v703] = v706;
                v700 += 1l ;
            }
            v698 += 1l ;
        }
        float v707;
        v707 = 0.0f;
        long v708;
        v708 = 0l;
        while (while_method_2(v708)){
            long v710;
            v710 = 0l;
            while (while_method_1(v710)){
                assert("Tensor range check" && 0 <= v708 && v708 < 1l);
                assert("Tensor range check" && 0 <= v710 && v710 < 4l);
                long v712;
                v712 = 4l * v708;
                long v713;
                v713 = v712 + v710;
                float v714;
                v714 = v697[v713];
                float v715;
                v715 = v714 + v707;
                v707 = v715;
                v710 += 1l ;
            }
            v708 += 1l ;
        }
        float v716;
        v716 = cooperative_groups::reduce(v631, v707, v694);
        float v717[4l];
        long v718;
        v718 = 0l;
        while (while_method_2(v718)){
            long v720;
            v720 = 0l;
            while (while_method_1(v720)){
                assert("Tensor range check" && 0 <= v718 && v718 < 1l);
                assert("Tensor range check" && 0 <= v720 && v720 < 4l);
                long v722;
                v722 = 4l * v718;
                long v723;
                v723 = v722 + v720;
                float v724;
                v724 = v697[v723];
                float v725;
                v725 = v724 / v716;
                assert("Tensor range check" && 0 <= v718 && v718 < 1l);
                assert("Tensor range check" && 0 <= v720 && v720 < 4l);
                v717[v723] = v725;
                v720 += 1l ;
            }
            v718 += 1l ;
        }
        float v726[4l];
        float v727;
        v727 = 0.0f;
        long v728;
        v728 = 0l;
        while (while_method_2(v728)){
            assert("Tensor range check" && 0 <= v728 && v728 < 1l);
            long v730;
            v730 = 4l * v728;
            assert("Tensor range check" && 0 <= v728 && v728 < 1l);
            long v731; float v732;
            Tuple0 tmp5 = Tuple0(0l, 0.0f);
            v731 = tmp5.v0; v732 = tmp5.v1;
            while (while_method_1(v731)){
                assert("Tensor range check" && 0 <= v731 && v731 < 4l);
                long v734;
                v734 = v731 + v730;
                float v735;
                v735 = v717[v734];
                float v736;
                v736 = v735 + v732;
                v732 = v736;
                v731 += 1l ;
            }
            Fun0 v737;
            v737 = ClosureMethod3;
            float v738;
            v738 = cooperative_groups::inclusive_scan(v631, v732, v737);
            float v739;
            v739 = v631.shfl(v738,v631.num_threads()-1);
            bool v740;
            v740 = v631.num_threads() <= 32;
            bool v741;
            v741 = v740 == false;
            if (v741){
                assert("The thread block tile in the exclusive scan has to be less than or equal 32." && v740);
            } else {
            }
            float v743;
            v743 = v631.shfl_up(v738,1);
            bool v744;
            v744 = v631.thread_rank() == 0;
            float v745;
            if (v744){
                v745 = 0.0f;
            } else {
                v745 = v743;
            }
            float v746;
            v746 = v727 + v745;
            long v747; float v748;
            Tuple0 tmp6 = Tuple0(0l, v746);
            v747 = tmp6.v0; v748 = tmp6.v1;
            while (while_method_1(v747)){
                assert("Tensor range check" && 0 <= v747 && v747 < 4l);
                long v750;
                v750 = v747 + v730;
                float v751;
                v751 = v717[v750];
                assert("Tensor range check" && 0 <= v747 && v747 < 4l);
                v726[v750] = v748;
                float v752;
                v752 = v751 + v748;
                v748 = v752;
                v747 += 1l ;
            }
            float v753;
            v753 = v727 + v739;
            v727 = v753;
            v728 += 1l ;
        }
        assert("Tensor range check" && 0 <= v684 && v684 < 128l);
        float v754;
        v754 = v1[v684];
        float v755[4l];
        long v756;
        v756 = 0l;
        while (while_method_2(v756)){
            long v758;
            v758 = 0l;
            while (while_method_1(v758)){
                assert("Tensor range check" && 0 <= v756 && v756 < 1l);
                assert("Tensor range check" && 0 <= v758 && v758 < 4l);
                long v760;
                v760 = 4l * v756;
                long v761;
                v761 = v760 + v758;
                float v762;
                v762 = v726[v761];
                float v763;
                v763 = v762 - v754;
                assert("Tensor range check" && 0 <= v756 && v756 < 1l);
                assert("Tensor range check" && 0 <= v758 && v758 < 4l);
                v755[v761] = v763;
                v758 += 1l ;
            }
            v756 += 1l ;
        }
        float v764; long v765;
        Tuple1 tmp7 = Tuple1(-1.0f / 0.0f, 0l);
        v764 = tmp7.v0; v765 = tmp7.v1;
        long v766;
        v766 = 0l;
        while (while_method_2(v766)){
            long v768;
            v768 = 0l;
            while (while_method_1(v768)){
                assert("Tensor range check" && 0 <= v766 && v766 < 1l);
                assert("Tensor range check" && 0 <= v768 && v768 < 4l);
                long v770;
                v770 = 4l * v766;
                long v771;
                v771 = v770 + v768;
                float v772;
                v772 = v755[v771];
                long v773;
                v773 = v640[v771];
                bool v774;
                v774 = v772 >= 0.0f;
                bool v776;
                if (v774){
                    bool v775;
                    v775 = v764 >= 0.0f;
                    v776 = v775;
                } else {
                    v776 = false;
                }
                float v785; long v786;
                if (v776){
                    bool v777;
                    v777 = v772 <= v764;
                    if (v777){
                        v785 = v772; v786 = v773;
                    } else {
                        v785 = v764; v786 = v765;
                    }
                } else {
                    if (v774){
                        v785 = v772; v786 = v773;
                    } else {
                        bool v780;
                        v780 = v764 >= 0.0f;
                        if (v780){
                            v785 = v764; v786 = v765;
                        } else {
                            v785 = v772; v786 = v773;
                        }
                    }
                }
                v764 = v785;
                v765 = v786;
                v768 += 1l ;
            }
            v766 += 1l ;
        }
        Fun1 v787;
        v787 = ClosureMethod4;
        float v788; long v789;
        Tuple1 tmp8 = cooperative_groups::reduce(v631, Tuple1(v764, v765), v787);
        v788 = tmp8.v0; v789 = tmp8.v1;
        assert("Tensor range check" && 0 <= v635 && v635 < 1l);
        long v790;
        v790 = v635 + v627;
        v8[v790] = v789;
        v635 += 1l ;
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
def method1(v0 : i32) -> bool:
    v1 = v0 < 16
    del v0
    return v1
def main():
    v0 = cp.random.normal(0.0,1.0,2048,dtype=cp.float32)
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
    v5 = cp.random.uniform(size=128,dtype=cp.float32)
    v6 = v5.size
    v7 = 128 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    pass
    v10 = cp.empty(1,dtype=cp.float32)
    pass
    v11 = cp.empty(2048,dtype=cp.float32)
    pass
    v12 = cp.empty(2048,dtype=cp.float32)
    v13 = cp.empty(2048,dtype=cp.float32)
    pass
    v14 = cp.empty(2048,dtype=cp.float32)
    pass
    v15 = cp.empty(128,dtype=cp.int32)
    pass
    v16 = cp.empty(128,dtype=cp.int32)
    pass
    v17 = cp.empty(2048,dtype=cp.int32)
    pass
    v18 = cp.empty(128,dtype=cp.int32)
    v19 = 0
    v20 = raw_module.get_function(f"entry{v19}")
    del v19
    v20.max_dynamic_shared_size_bytes = 0 
    v20((1,),(512,),(v0, v5, v10, v11, v12, v13, v14, v15, v16, v17, v18),shared_mem=0)
    del v0, v5, v10, v11, v12, v13, v14, v15, v16, v18, v20
    v21 = 0
    print('[', end="")
    v23 = 0
    while method0(v23):
        v25 = v21
        v26 = v25 >= 2048
        del v25
        if v26:
            v29 = " ..."
            print(v29, end="")
            del v29
            break
        else:
            pass
        del v26
        v30 = v23 == 0
        v31 = v30 != True
        del v30
        if v31:
            v34 = "; "
            print(v34, end="")
            del v34
        else:
            pass
        del v31
        print('[', end="")
        v36 = 0
        while method1(v36):
            v38 = v21
            v39 = v38 >= 2048
            del v38
            if v39:
                v42 = " ..."
                print(v42, end="")
                del v42
                break
            else:
                pass
            del v39
            v43 = v36 == 0
            v44 = v43 != True
            del v43
            if v44:
                v47 = "; "
                print(v47, end="")
                del v47
            else:
                pass
            del v44
            v48 = v21 + 1
            v21 = v48
            del v48
            v49 = v23 * 16
            v50 = v49 + v36
            del v49
            v51 = v17[v50].item()
            del v50
            print(v51, end="")
            del v51
            v36 += 1 
        del v36
        print(']', end="")
        v23 += 1 
    del v17, v21, v23
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
