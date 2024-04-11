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
        v190 = 128l * v140;
        long v191;
        v191 = v190 + v132;
        v10[v191] = v189;
        v140 += 1l ;
    }
    __syncthreads();
    long v192;
    v192 = threadIdx.x;
    bool v193;
    v193 = 0l <= v192;
    bool v194;
    v194 = v193 == false;
    if (v194){
        assert("The index needs to be zero or positive." && v193);
    } else {
    }
    long v196;
    v196 = v192 % 4l;
    long v197;
    v197 = v192 / 4l;
    bool v198;
    v198 = v197 < 128l;
    bool v199;
    v199 = v198 == false;
    if (v199){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v198);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v201 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v197 && v197 < 128l);
    assert("Tensor range check" && 0 <= v196 && v196 < 4l);
    long v202;
    v202 = 4l * v196;
    long v203;
    v203 = 16l * v197;
    long v204;
    v204 = v203 + v202;
    assert("Tensor range check" && 0 <= v197 && v197 < 128l);
    assert("Tensor range check" && 0 <= v196 && v196 < 4l);
    long v205;
    v205 = 0l;
    while (while_method_2(v205)){
        assert("Tensor range check" && 0 <= v205 && v205 < 1l);
        long v207;
        v207 = 2048l * v205;
        long v208;
        v208 = v207 + v204;
        assert("Tensor range check" && 0 <= v205 && v205 < 1l);
        float v209[4l];
        long v210[4l];
        long v211;
        v211 = 0l;
        while (while_method_2(v211)){
            assert("Tensor range check" && 0 <= v211 && v211 < 1l);
            long v213;
            v213 = 4l * v211;
            assert("Tensor range check" && 0 <= v211 && v211 < 1l);
            long v214;
            v214 = 16l * v211;
            long v215;
            v215 = v214 + v208;
            int4* v216;
            v216 = reinterpret_cast<int4*>(v0 + v215);
            int4* v217;
            v217 = reinterpret_cast<int4*>(v209 + v213);
            assert("Pointer alignment check" && (unsigned long long)(v216) % 4l == 0 && (unsigned long long)(v217) % 4l == 0);
            *v217 = *v216;
            v211 += 1l ;
        }
        long v218;
        v218 = 0l;
        while (while_method_2(v218)){
            long v220;
            v220 = 0l;
            while (while_method_1(v220)){
                bool v222;
                v222 = 0l <= v220;
                bool v224;
                if (v222){
                    bool v223;
                    v223 = v220 < 4l;
                    v224 = v223;
                } else {
                    v224 = false;
                }
                bool v225;
                v225 = v224 == false;
                if (v225){
                    assert("The indices should be inside the range of the dimension." && v224);
                } else {
                }
                bool v227;
                v227 = 0l <= v218;
                bool v229;
                if (v227){
                    bool v228;
                    v228 = v218 < 1l;
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
                v232 = v218 * 4l;
                long v233;
                v233 = v220 + v232;
                bool v234;
                v234 = 0l <= v196;
                bool v236;
                if (v234){
                    bool v235;
                    v235 = v196 < 4l;
                    v236 = v235;
                } else {
                    v236 = false;
                }
                bool v237;
                v237 = v236 == false;
                if (v237){
                    assert("The indices should be inside the range of the dimension." && v236);
                } else {
                }
                long v239;
                v239 = v196 * 4l;
                long v240;
                v240 = v233 + v239;
                assert("Tensor range check" && 0 <= v218 && v218 < 1l);
                assert("Tensor range check" && 0 <= v220 && v220 < 4l);
                long v241;
                v241 = 4l * v218;
                long v242;
                v242 = v241 + v220;
                v210[v242] = v240;
                v220 += 1l ;
            }
            v218 += 1l ;
        }
        bool v243;
        v243 = 0l < v197;
        bool v245;
        if (v243){
            bool v244;
            v244 = v197 <= 128l;
            v245 = v244;
        } else {
            v245 = false;
        }
        bool v246;
        v246 = v245 == false;
        if (v246){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v245);
        } else {
        }
        bool v248;
        v248 = 0l < v205;
        bool v250;
        if (v248){
            bool v249;
            v249 = v205 <= 1l;
            v250 = v249;
        } else {
            v250 = false;
        }
        bool v251;
        v251 = v250 == false;
        if (v251){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v250);
        } else {
        }
        long v253;
        v253 = v205 * 128l;
        long v254;
        v254 = v253 + v197;
        float v255;
        v255 = 0.0f;
        long v256;
        v256 = 0l;
        while (while_method_2(v256)){
            long v258;
            v258 = 0l;
            while (while_method_1(v258)){
                assert("Tensor range check" && 0 <= v256 && v256 < 1l);
                assert("Tensor range check" && 0 <= v258 && v258 < 4l);
                long v260;
                v260 = 4l * v256;
                long v261;
                v261 = v260 + v258;
                float v262;
                v262 = v209[v261];
                float v263;
                v263 = v262 + v255;
                v255 = v263;
                v258 += 1l ;
            }
            v256 += 1l ;
        }
        Fun0 v264;
        v264 = ClosureMethod1;
        float v265;
        v265 = cooperative_groups::reduce(v201, v255, v264);
        float v266;
        v266 = v265 / 16.0f;
        float v267[4l];
        long v268;
        v268 = 0l;
        while (while_method_2(v268)){
            long v270;
            v270 = 0l;
            while (while_method_1(v270)){
                assert("Tensor range check" && 0 <= v268 && v268 < 1l);
                assert("Tensor range check" && 0 <= v270 && v270 < 4l);
                long v272;
                v272 = 4l * v268;
                long v273;
                v273 = v272 + v270;
                float v274;
                v274 = v209[v273];
                float v275;
                v275 = v274 - v266;
                float v276;
                v276 = exp(v275);
                assert("Tensor range check" && 0 <= v268 && v268 < 1l);
                assert("Tensor range check" && 0 <= v270 && v270 < 4l);
                v267[v273] = v276;
                v270 += 1l ;
            }
            v268 += 1l ;
        }
        float v277;
        v277 = 0.0f;
        long v278;
        v278 = 0l;
        while (while_method_2(v278)){
            long v280;
            v280 = 0l;
            while (while_method_1(v280)){
                assert("Tensor range check" && 0 <= v278 && v278 < 1l);
                assert("Tensor range check" && 0 <= v280 && v280 < 4l);
                long v282;
                v282 = 4l * v278;
                long v283;
                v283 = v282 + v280;
                float v284;
                v284 = v267[v283];
                float v285;
                v285 = v284 + v277;
                v277 = v285;
                v280 += 1l ;
            }
            v278 += 1l ;
        }
        float v286;
        v286 = cooperative_groups::reduce(v201, v277, v264);
        float v287[4l];
        long v288;
        v288 = 0l;
        while (while_method_2(v288)){
            long v290;
            v290 = 0l;
            while (while_method_1(v290)){
                assert("Tensor range check" && 0 <= v288 && v288 < 1l);
                assert("Tensor range check" && 0 <= v290 && v290 < 4l);
                long v292;
                v292 = 4l * v288;
                long v293;
                v293 = v292 + v290;
                float v294;
                v294 = v267[v293];
                float v295;
                v295 = v294 / v286;
                assert("Tensor range check" && 0 <= v288 && v288 < 1l);
                assert("Tensor range check" && 0 <= v290 && v290 < 4l);
                v287[v293] = v295;
                v290 += 1l ;
            }
            v288 += 1l ;
        }
        long v296;
        v296 = 0l;
        while (while_method_2(v296)){
            assert("Tensor range check" && 0 <= v296 && v296 < 1l);
            long v298;
            v298 = 16l * v296;
            long v299;
            v299 = v298 + v208;
            assert("Tensor range check" && 0 <= v296 && v296 < 1l);
            long v300;
            v300 = 4l * v296;
            int4* v301;
            v301 = reinterpret_cast<int4*>(v287 + v300);
            int4* v302;
            v302 = reinterpret_cast<int4*>(v3 + v299);
            assert("Pointer alignment check" && (unsigned long long)(v301) % 4l == 0 && (unsigned long long)(v302) % 4l == 0);
            *v302 = *v301;
            v296 += 1l ;
        }
        v205 += 1l ;
    }
    __syncthreads();
    long v303;
    v303 = threadIdx.x;
    bool v304;
    v304 = 0l <= v303;
    bool v305;
    v305 = v304 == false;
    if (v305){
        assert("The index needs to be zero or positive." && v304);
    } else {
    }
    long v307;
    v307 = v303 % 4l;
    long v308;
    v308 = v303 / 4l;
    bool v309;
    v309 = v308 < 128l;
    bool v310;
    v310 = v309 == false;
    if (v310){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v309);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v312 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v308 && v308 < 128l);
    assert("Tensor range check" && 0 <= v307 && v307 < 4l);
    long v313;
    v313 = 4l * v307;
    long v314;
    v314 = 16l * v308;
    long v315;
    v315 = v314 + v313;
    assert("Tensor range check" && 0 <= v308 && v308 < 128l);
    assert("Tensor range check" && 0 <= v307 && v307 < 4l);
    long v316;
    v316 = 0l;
    while (while_method_2(v316)){
        assert("Tensor range check" && 0 <= v316 && v316 < 1l);
        long v318;
        v318 = 2048l * v316;
        long v319;
        v319 = v318 + v315;
        assert("Tensor range check" && 0 <= v316 && v316 < 1l);
        float v320[4l];
        long v321[4l];
        long v322;
        v322 = 0l;
        while (while_method_2(v322)){
            assert("Tensor range check" && 0 <= v322 && v322 < 1l);
            long v324;
            v324 = 4l * v322;
            assert("Tensor range check" && 0 <= v322 && v322 < 1l);
            long v325;
            v325 = 16l * v322;
            long v326;
            v326 = v325 + v319;
            int4* v327;
            v327 = reinterpret_cast<int4*>(v0 + v326);
            int4* v328;
            v328 = reinterpret_cast<int4*>(v320 + v324);
            assert("Pointer alignment check" && (unsigned long long)(v327) % 4l == 0 && (unsigned long long)(v328) % 4l == 0);
            *v328 = *v327;
            v322 += 1l ;
        }
        long v329;
        v329 = 0l;
        while (while_method_2(v329)){
            long v331;
            v331 = 0l;
            while (while_method_1(v331)){
                bool v333;
                v333 = 0l <= v331;
                bool v335;
                if (v333){
                    bool v334;
                    v334 = v331 < 4l;
                    v335 = v334;
                } else {
                    v335 = false;
                }
                bool v336;
                v336 = v335 == false;
                if (v336){
                    assert("The indices should be inside the range of the dimension." && v335);
                } else {
                }
                bool v338;
                v338 = 0l <= v329;
                bool v340;
                if (v338){
                    bool v339;
                    v339 = v329 < 1l;
                    v340 = v339;
                } else {
                    v340 = false;
                }
                bool v341;
                v341 = v340 == false;
                if (v341){
                    assert("The indices should be inside the range of the dimension." && v340);
                } else {
                }
                long v343;
                v343 = v329 * 4l;
                long v344;
                v344 = v331 + v343;
                bool v345;
                v345 = 0l <= v307;
                bool v347;
                if (v345){
                    bool v346;
                    v346 = v307 < 4l;
                    v347 = v346;
                } else {
                    v347 = false;
                }
                bool v348;
                v348 = v347 == false;
                if (v348){
                    assert("The indices should be inside the range of the dimension." && v347);
                } else {
                }
                long v350;
                v350 = v307 * 4l;
                long v351;
                v351 = v344 + v350;
                assert("Tensor range check" && 0 <= v329 && v329 < 1l);
                assert("Tensor range check" && 0 <= v331 && v331 < 4l);
                long v352;
                v352 = 4l * v329;
                long v353;
                v353 = v352 + v331;
                v321[v353] = v351;
                v331 += 1l ;
            }
            v329 += 1l ;
        }
        bool v354;
        v354 = 0l < v308;
        bool v356;
        if (v354){
            bool v355;
            v355 = v308 <= 128l;
            v356 = v355;
        } else {
            v356 = false;
        }
        bool v357;
        v357 = v356 == false;
        if (v357){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v356);
        } else {
        }
        bool v359;
        v359 = 0l < v316;
        bool v361;
        if (v359){
            bool v360;
            v360 = v316 <= 1l;
            v361 = v360;
        } else {
            v361 = false;
        }
        bool v362;
        v362 = v361 == false;
        if (v362){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v361);
        } else {
        }
        long v364;
        v364 = v316 * 128l;
        long v365;
        v365 = v364 + v308;
        float v366[4l];
        long v367;
        v367 = 0l;
        while (while_method_2(v367)){
            long v369;
            v369 = 0l;
            while (while_method_1(v369)){
                assert("Tensor range check" && 0 <= v367 && v367 < 1l);
                assert("Tensor range check" && 0 <= v369 && v369 < 4l);
                long v371;
                v371 = 4l * v367;
                long v372;
                v372 = v371 + v369;
                float v373;
                v373 = v320[v372];
                float v374;
                v374 = v373 * v373;
                assert("Tensor range check" && 0 <= v367 && v367 < 1l);
                assert("Tensor range check" && 0 <= v369 && v369 < 4l);
                v366[v372] = v374;
                v369 += 1l ;
            }
            v367 += 1l ;
        }
        float v375;
        v375 = 0.0f;
        long v376;
        v376 = 0l;
        while (while_method_2(v376)){
            long v378;
            v378 = 0l;
            while (while_method_1(v378)){
                assert("Tensor range check" && 0 <= v376 && v376 < 1l);
                assert("Tensor range check" && 0 <= v378 && v378 < 4l);
                long v380;
                v380 = 4l * v376;
                long v381;
                v381 = v380 + v378;
                float v382;
                v382 = v366[v381];
                float v383;
                v383 = v382 + v375;
                v375 = v383;
                v378 += 1l ;
            }
            v376 += 1l ;
        }
        Fun0 v384;
        v384 = ClosureMethod1;
        float v385;
        v385 = cooperative_groups::reduce(v312, v375, v384);
        float v386[4l];
        long v387;
        v387 = 0l;
        while (while_method_2(v387)){
            long v389;
            v389 = 0l;
            while (while_method_1(v389)){
                assert("Tensor range check" && 0 <= v387 && v387 < 1l);
                assert("Tensor range check" && 0 <= v389 && v389 < 4l);
                long v391;
                v391 = 4l * v387;
                long v392;
                v392 = v391 + v389;
                float v393;
                v393 = v366[v392];
                float v394;
                v394 = v393 / v385;
                assert("Tensor range check" && 0 <= v387 && v387 < 1l);
                assert("Tensor range check" && 0 <= v389 && v389 < 4l);
                v386[v392] = v394;
                v389 += 1l ;
            }
            v387 += 1l ;
        }
        long v395;
        v395 = 0l;
        while (while_method_2(v395)){
            assert("Tensor range check" && 0 <= v395 && v395 < 1l);
            long v397;
            v397 = 16l * v395;
            long v398;
            v398 = v397 + v319;
            assert("Tensor range check" && 0 <= v395 && v395 < 1l);
            long v399;
            v399 = 4l * v395;
            int4* v400;
            v400 = reinterpret_cast<int4*>(v386 + v399);
            int4* v401;
            v401 = reinterpret_cast<int4*>(v6 + v398);
            assert("Pointer alignment check" && (unsigned long long)(v400) % 4l == 0 && (unsigned long long)(v401) % 4l == 0);
            *v401 = *v400;
            v395 += 1l ;
        }
        v316 += 1l ;
    }
    __syncthreads();
    long v402;
    v402 = threadIdx.x;
    bool v403;
    v403 = 0l <= v402;
    bool v404;
    v404 = v403 == false;
    if (v404){
        assert("The index needs to be zero or positive." && v403);
    } else {
    }
    long v406;
    v406 = v402 % 4l;
    long v407;
    v407 = v402 / 4l;
    bool v408;
    v408 = v407 < 128l;
    bool v409;
    v409 = v408 == false;
    if (v409){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v408);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v411 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v407 && v407 < 128l);
    assert("Tensor range check" && 0 <= v406 && v406 < 4l);
    long v412;
    v412 = 4l * v406;
    long v413;
    v413 = 16l * v407;
    long v414;
    v414 = v413 + v412;
    assert("Tensor range check" && 0 <= v407 && v407 < 128l);
    long v415;
    v415 = 0l;
    while (while_method_2(v415)){
        assert("Tensor range check" && 0 <= v415 && v415 < 1l);
        long v417;
        v417 = 2048l * v415;
        long v418;
        v418 = v417 + v414;
        float v419[4l];
        long v420[4l];
        long v421;
        v421 = 0l;
        while (while_method_2(v421)){
            assert("Tensor range check" && 0 <= v421 && v421 < 1l);
            long v423;
            v423 = 4l * v421;
            assert("Tensor range check" && 0 <= v421 && v421 < 1l);
            long v424;
            v424 = 16l * v421;
            long v425;
            v425 = v424 + v418;
            int4* v426;
            v426 = reinterpret_cast<int4*>(v0 + v425);
            int4* v427;
            v427 = reinterpret_cast<int4*>(v419 + v423);
            assert("Pointer alignment check" && (unsigned long long)(v426) % 4l == 0 && (unsigned long long)(v427) % 4l == 0);
            *v427 = *v426;
            v421 += 1l ;
        }
        long v428;
        v428 = 0l;
        while (while_method_2(v428)){
            long v430;
            v430 = 0l;
            while (while_method_1(v430)){
                bool v432;
                v432 = 0l <= v430;
                bool v434;
                if (v432){
                    bool v433;
                    v433 = v430 < 4l;
                    v434 = v433;
                } else {
                    v434 = false;
                }
                bool v435;
                v435 = v434 == false;
                if (v435){
                    assert("The indices should be inside the range of the dimension." && v434);
                } else {
                }
                bool v437;
                v437 = 0l <= v428;
                bool v439;
                if (v437){
                    bool v438;
                    v438 = v428 < 1l;
                    v439 = v438;
                } else {
                    v439 = false;
                }
                bool v440;
                v440 = v439 == false;
                if (v440){
                    assert("The indices should be inside the range of the dimension." && v439);
                } else {
                }
                long v442;
                v442 = v428 * 4l;
                long v443;
                v443 = v430 + v442;
                bool v444;
                v444 = 0l <= v406;
                bool v446;
                if (v444){
                    bool v445;
                    v445 = v406 < 4l;
                    v446 = v445;
                } else {
                    v446 = false;
                }
                bool v447;
                v447 = v446 == false;
                if (v447){
                    assert("The indices should be inside the range of the dimension." && v446);
                } else {
                }
                long v449;
                v449 = v406 * 4l;
                long v450;
                v450 = v443 + v449;
                assert("Tensor range check" && 0 <= v428 && v428 < 1l);
                assert("Tensor range check" && 0 <= v430 && v430 < 4l);
                long v451;
                v451 = 4l * v428;
                long v452;
                v452 = v451 + v430;
                v420[v452] = v450;
                v430 += 1l ;
            }
            v428 += 1l ;
        }
        bool v453;
        v453 = 0l < v407;
        bool v455;
        if (v453){
            bool v454;
            v454 = v407 <= 128l;
            v455 = v454;
        } else {
            v455 = false;
        }
        bool v456;
        v456 = v455 == false;
        if (v456){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v455);
        } else {
        }
        bool v458;
        v458 = 0l < v415;
        bool v460;
        if (v458){
            bool v459;
            v459 = v415 <= 1l;
            v460 = v459;
        } else {
            v460 = false;
        }
        bool v461;
        v461 = v460 == false;
        if (v461){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v460);
        } else {
        }
        long v463;
        v463 = v415 * 128l;
        long v464;
        v464 = v463 + v407;
        float v465; long v466;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v465 = tmp1.v0; v466 = tmp1.v1;
        long v467;
        v467 = 0l;
        while (while_method_2(v467)){
            long v469;
            v469 = 0l;
            while (while_method_1(v469)){
                assert("Tensor range check" && 0 <= v467 && v467 < 1l);
                assert("Tensor range check" && 0 <= v469 && v469 < 4l);
                long v471;
                v471 = 4l * v467;
                long v472;
                v472 = v471 + v469;
                float v473;
                v473 = v419[v472];
                long v474;
                v474 = v420[v472];
                bool v475;
                v475 = v473 > v465;
                float v476; long v477;
                if (v475){
                    v476 = v473; v477 = v474;
                } else {
                    v476 = v465; v477 = v466;
                }
                v465 = v476;
                v466 = v477;
                v469 += 1l ;
            }
            v467 += 1l ;
        }
        Fun1 v478;
        v478 = ClosureMethod2;
        float v479; long v480;
        Tuple1 tmp2 = cooperative_groups::reduce(v411, Tuple1(v465, v466), v478);
        v479 = tmp2.v0; v480 = tmp2.v1;
        assert("Tensor range check" && 0 <= v415 && v415 < 1l);
        long v481;
        v481 = 128l * v415;
        long v482;
        v482 = v481 + v407;
        v7[v482] = v480;
        v415 += 1l ;
    }
    __syncthreads();
    long v483;
    v483 = threadIdx.x;
    bool v484;
    v484 = 0l <= v483;
    bool v485;
    v485 = v484 == false;
    if (v485){
        assert("The index needs to be zero or positive." && v484);
    } else {
    }
    long v487;
    v487 = v483 % 4l;
    long v488;
    v488 = v483 / 4l;
    bool v489;
    v489 = v488 < 128l;
    bool v490;
    v490 = v489 == false;
    if (v490){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v489);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v492 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v488 && v488 < 128l);
    assert("Tensor range check" && 0 <= v487 && v487 < 4l);
    long v493;
    v493 = 4l * v487;
    long v494;
    v494 = 16l * v488;
    long v495;
    v495 = v494 + v493;
    assert("Tensor range check" && 0 <= v488 && v488 < 128l);
    assert("Tensor range check" && 0 <= v487 && v487 < 4l);
    long v496;
    v496 = 0l;
    while (while_method_2(v496)){
        assert("Tensor range check" && 0 <= v496 && v496 < 1l);
        long v498;
        v498 = 2048l * v496;
        long v499;
        v499 = v498 + v495;
        assert("Tensor range check" && 0 <= v496 && v496 < 1l);
        float v500[4l];
        long v501[4l];
        long v502;
        v502 = 0l;
        while (while_method_2(v502)){
            assert("Tensor range check" && 0 <= v502 && v502 < 1l);
            long v504;
            v504 = 4l * v502;
            assert("Tensor range check" && 0 <= v502 && v502 < 1l);
            long v505;
            v505 = 16l * v502;
            long v506;
            v506 = v505 + v499;
            int4* v507;
            v507 = reinterpret_cast<int4*>(v0 + v506);
            int4* v508;
            v508 = reinterpret_cast<int4*>(v500 + v504);
            assert("Pointer alignment check" && (unsigned long long)(v507) % 4l == 0 && (unsigned long long)(v508) % 4l == 0);
            *v508 = *v507;
            v502 += 1l ;
        }
        long v509;
        v509 = 0l;
        while (while_method_2(v509)){
            long v511;
            v511 = 0l;
            while (while_method_1(v511)){
                bool v513;
                v513 = 0l <= v511;
                bool v515;
                if (v513){
                    bool v514;
                    v514 = v511 < 4l;
                    v515 = v514;
                } else {
                    v515 = false;
                }
                bool v516;
                v516 = v515 == false;
                if (v516){
                    assert("The indices should be inside the range of the dimension." && v515);
                } else {
                }
                bool v518;
                v518 = 0l <= v509;
                bool v520;
                if (v518){
                    bool v519;
                    v519 = v509 < 1l;
                    v520 = v519;
                } else {
                    v520 = false;
                }
                bool v521;
                v521 = v520 == false;
                if (v521){
                    assert("The indices should be inside the range of the dimension." && v520);
                } else {
                }
                long v523;
                v523 = v509 * 4l;
                long v524;
                v524 = v511 + v523;
                bool v525;
                v525 = 0l <= v487;
                bool v527;
                if (v525){
                    bool v526;
                    v526 = v487 < 4l;
                    v527 = v526;
                } else {
                    v527 = false;
                }
                bool v528;
                v528 = v527 == false;
                if (v528){
                    assert("The indices should be inside the range of the dimension." && v527);
                } else {
                }
                long v530;
                v530 = v487 * 4l;
                long v531;
                v531 = v524 + v530;
                assert("Tensor range check" && 0 <= v509 && v509 < 1l);
                assert("Tensor range check" && 0 <= v511 && v511 < 4l);
                long v532;
                v532 = 4l * v509;
                long v533;
                v533 = v532 + v511;
                v501[v533] = v531;
                v511 += 1l ;
            }
            v509 += 1l ;
        }
        bool v534;
        v534 = 0l < v488;
        bool v536;
        if (v534){
            bool v535;
            v535 = v488 <= 128l;
            v536 = v535;
        } else {
            v536 = false;
        }
        bool v537;
        v537 = v536 == false;
        if (v537){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v536);
        } else {
        }
        bool v539;
        v539 = 0l < v496;
        bool v541;
        if (v539){
            bool v540;
            v540 = v496 <= 1l;
            v541 = v540;
        } else {
            v541 = false;
        }
        bool v542;
        v542 = v541 == false;
        if (v542){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v541);
        } else {
        }
        long v544;
        v544 = v496 * 128l;
        long v545;
        v545 = v544 + v488;
        float v546;
        v546 = 0.0f;
        long v547;
        v547 = 0l;
        while (while_method_2(v547)){
            long v549;
            v549 = 0l;
            while (while_method_1(v549)){
                assert("Tensor range check" && 0 <= v547 && v547 < 1l);
                assert("Tensor range check" && 0 <= v549 && v549 < 4l);
                long v551;
                v551 = 4l * v547;
                long v552;
                v552 = v551 + v549;
                float v553;
                v553 = v500[v552];
                float v554;
                v554 = v553 + v546;
                v546 = v554;
                v549 += 1l ;
            }
            v547 += 1l ;
        }
        Fun0 v555;
        v555 = ClosureMethod1;
        float v556;
        v556 = cooperative_groups::reduce(v492, v546, v555);
        float v557;
        v557 = v556 / 16.0f;
        float v558[4l];
        long v559;
        v559 = 0l;
        while (while_method_2(v559)){
            long v561;
            v561 = 0l;
            while (while_method_1(v561)){
                assert("Tensor range check" && 0 <= v559 && v559 < 1l);
                assert("Tensor range check" && 0 <= v561 && v561 < 4l);
                long v563;
                v563 = 4l * v559;
                long v564;
                v564 = v563 + v561;
                float v565;
                v565 = v500[v564];
                float v566;
                v566 = v565 - v557;
                float v567;
                v567 = exp(v566);
                assert("Tensor range check" && 0 <= v559 && v559 < 1l);
                assert("Tensor range check" && 0 <= v561 && v561 < 4l);
                v558[v564] = v567;
                v561 += 1l ;
            }
            v559 += 1l ;
        }
        float v568;
        v568 = 0.0f;
        long v569;
        v569 = 0l;
        while (while_method_2(v569)){
            long v571;
            v571 = 0l;
            while (while_method_1(v571)){
                assert("Tensor range check" && 0 <= v569 && v569 < 1l);
                assert("Tensor range check" && 0 <= v571 && v571 < 4l);
                long v573;
                v573 = 4l * v569;
                long v574;
                v574 = v573 + v571;
                float v575;
                v575 = v558[v574];
                float v576;
                v576 = v575 + v568;
                v568 = v576;
                v571 += 1l ;
            }
            v569 += 1l ;
        }
        float v577;
        v577 = cooperative_groups::reduce(v492, v568, v555);
        float v578[4l];
        long v579;
        v579 = 0l;
        while (while_method_2(v579)){
            long v581;
            v581 = 0l;
            while (while_method_1(v581)){
                assert("Tensor range check" && 0 <= v579 && v579 < 1l);
                assert("Tensor range check" && 0 <= v581 && v581 < 4l);
                long v583;
                v583 = 4l * v579;
                long v584;
                v584 = v583 + v581;
                float v585;
                v585 = v558[v584];
                float v586;
                v586 = v585 / v577;
                assert("Tensor range check" && 0 <= v579 && v579 < 1l);
                assert("Tensor range check" && 0 <= v581 && v581 < 4l);
                v578[v584] = v586;
                v581 += 1l ;
            }
            v579 += 1l ;
        }
        float v587[4l];
        float v588;
        v588 = 0.0f;
        long v589;
        v589 = 0l;
        while (while_method_2(v589)){
            assert("Tensor range check" && 0 <= v589 && v589 < 1l);
            long v591;
            v591 = 4l * v589;
            assert("Tensor range check" && 0 <= v589 && v589 < 1l);
            long v592; float v593;
            Tuple0 tmp3 = Tuple0(0l, 0.0f);
            v592 = tmp3.v0; v593 = tmp3.v1;
            while (while_method_1(v592)){
                assert("Tensor range check" && 0 <= v592 && v592 < 4l);
                long v595;
                v595 = v592 + v591;
                float v596;
                v596 = v578[v595];
                float v597;
                v597 = v596 + v593;
                v593 = v597;
                v592 += 1l ;
            }
            Fun0 v598;
            v598 = ClosureMethod3;
            float v599;
            v599 = cooperative_groups::inclusive_scan(v492, v593, v598);
            float v600;
            v600 = v492.shfl(v599,v492.num_threads()-1);
            bool v601;
            v601 = v492.num_threads() <= 32;
            bool v602;
            v602 = v601 == false;
            if (v602){
                assert("The thread block tile in the exclusive scan has to be less than or equal 32." && v601);
            } else {
            }
            float v604;
            v604 = v492.shfl_up(v599,1);
            bool v605;
            v605 = v492.thread_rank() == 0;
            float v606;
            if (v605){
                v606 = 0.0f;
            } else {
                v606 = v604;
            }
            float v607;
            v607 = v588 + v606;
            long v608; float v609;
            Tuple0 tmp4 = Tuple0(0l, v607);
            v608 = tmp4.v0; v609 = tmp4.v1;
            while (while_method_1(v608)){
                assert("Tensor range check" && 0 <= v608 && v608 < 4l);
                long v611;
                v611 = v608 + v591;
                float v612;
                v612 = v578[v611];
                assert("Tensor range check" && 0 <= v608 && v608 < 4l);
                v587[v611] = v609;
                float v613;
                v613 = v612 + v609;
                v609 = v613;
                v608 += 1l ;
            }
            float v614;
            v614 = v588 + v600;
            v588 = v614;
            v589 += 1l ;
        }
        long v615;
        v615 = 0l;
        while (while_method_2(v615)){
            assert("Tensor range check" && 0 <= v615 && v615 < 1l);
            long v617;
            v617 = 16l * v615;
            long v618;
            v618 = v617 + v499;
            assert("Tensor range check" && 0 <= v615 && v615 < 1l);
            long v619;
            v619 = 4l * v615;
            int4* v620;
            v620 = reinterpret_cast<int4*>(v578 + v619);
            int4* v621;
            v621 = reinterpret_cast<int4*>(v4 + v618);
            assert("Pointer alignment check" && (unsigned long long)(v620) % 4l == 0 && (unsigned long long)(v621) % 4l == 0);
            *v621 = *v620;
            int4* v622;
            v622 = reinterpret_cast<int4*>(v587 + v619);
            int4* v623;
            v623 = reinterpret_cast<int4*>(v5 + v618);
            assert("Pointer alignment check" && (unsigned long long)(v622) % 4l == 0 && (unsigned long long)(v623) % 4l == 0);
            *v623 = *v622;
            v615 += 1l ;
        }
        v496 += 1l ;
    }
    __syncthreads();
    long v624;
    v624 = threadIdx.x;
    bool v625;
    v625 = 0l <= v624;
    bool v626;
    v626 = v625 == false;
    if (v626){
        assert("The index needs to be zero or positive." && v625);
    } else {
    }
    long v628;
    v628 = v624 % 4l;
    long v629;
    v629 = v624 / 4l;
    bool v630;
    v630 = v629 < 128l;
    bool v631;
    v631 = v630 == false;
    if (v631){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v630);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v633 = cooperative_groups::tiled_partition<4l>(v11);
    assert("Tensor range check" && 0 <= v629 && v629 < 128l);
    assert("Tensor range check" && 0 <= v628 && v628 < 4l);
    long v634;
    v634 = 4l * v628;
    long v635;
    v635 = 16l * v629;
    long v636;
    v636 = v635 + v634;
    assert("Tensor range check" && 0 <= v629 && v629 < 128l);
    long v637;
    v637 = 0l;
    while (while_method_2(v637)){
        assert("Tensor range check" && 0 <= v637 && v637 < 1l);
        long v639;
        v639 = 2048l * v637;
        long v640;
        v640 = v639 + v636;
        float v641[4l];
        long v642[4l];
        long v643;
        v643 = 0l;
        while (while_method_2(v643)){
            assert("Tensor range check" && 0 <= v643 && v643 < 1l);
            long v645;
            v645 = 4l * v643;
            assert("Tensor range check" && 0 <= v643 && v643 < 1l);
            long v646;
            v646 = 16l * v643;
            long v647;
            v647 = v646 + v640;
            int4* v648;
            v648 = reinterpret_cast<int4*>(v0 + v647);
            int4* v649;
            v649 = reinterpret_cast<int4*>(v641 + v645);
            assert("Pointer alignment check" && (unsigned long long)(v648) % 4l == 0 && (unsigned long long)(v649) % 4l == 0);
            *v649 = *v648;
            v643 += 1l ;
        }
        long v650;
        v650 = 0l;
        while (while_method_2(v650)){
            long v652;
            v652 = 0l;
            while (while_method_1(v652)){
                bool v654;
                v654 = 0l <= v652;
                bool v656;
                if (v654){
                    bool v655;
                    v655 = v652 < 4l;
                    v656 = v655;
                } else {
                    v656 = false;
                }
                bool v657;
                v657 = v656 == false;
                if (v657){
                    assert("The indices should be inside the range of the dimension." && v656);
                } else {
                }
                bool v659;
                v659 = 0l <= v650;
                bool v661;
                if (v659){
                    bool v660;
                    v660 = v650 < 1l;
                    v661 = v660;
                } else {
                    v661 = false;
                }
                bool v662;
                v662 = v661 == false;
                if (v662){
                    assert("The indices should be inside the range of the dimension." && v661);
                } else {
                }
                long v664;
                v664 = v650 * 4l;
                long v665;
                v665 = v652 + v664;
                bool v666;
                v666 = 0l <= v628;
                bool v668;
                if (v666){
                    bool v667;
                    v667 = v628 < 4l;
                    v668 = v667;
                } else {
                    v668 = false;
                }
                bool v669;
                v669 = v668 == false;
                if (v669){
                    assert("The indices should be inside the range of the dimension." && v668);
                } else {
                }
                long v671;
                v671 = v628 * 4l;
                long v672;
                v672 = v665 + v671;
                assert("Tensor range check" && 0 <= v650 && v650 < 1l);
                assert("Tensor range check" && 0 <= v652 && v652 < 4l);
                long v673;
                v673 = 4l * v650;
                long v674;
                v674 = v673 + v652;
                v642[v674] = v672;
                v652 += 1l ;
            }
            v650 += 1l ;
        }
        bool v675;
        v675 = 0l < v629;
        bool v677;
        if (v675){
            bool v676;
            v676 = v629 <= 128l;
            v677 = v676;
        } else {
            v677 = false;
        }
        bool v678;
        v678 = v677 == false;
        if (v678){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v677);
        } else {
        }
        bool v680;
        v680 = 0l < v637;
        bool v682;
        if (v680){
            bool v681;
            v681 = v637 <= 1l;
            v682 = v681;
        } else {
            v682 = false;
        }
        bool v683;
        v683 = v682 == false;
        if (v683){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v682);
        } else {
        }
        long v685;
        v685 = v637 * 128l;
        long v686;
        v686 = v685 + v629;
        float v687;
        v687 = 0.0f;
        long v688;
        v688 = 0l;
        while (while_method_2(v688)){
            long v690;
            v690 = 0l;
            while (while_method_1(v690)){
                assert("Tensor range check" && 0 <= v688 && v688 < 1l);
                assert("Tensor range check" && 0 <= v690 && v690 < 4l);
                long v692;
                v692 = 4l * v688;
                long v693;
                v693 = v692 + v690;
                float v694;
                v694 = v641[v693];
                float v695;
                v695 = v694 + v687;
                v687 = v695;
                v690 += 1l ;
            }
            v688 += 1l ;
        }
        Fun0 v696;
        v696 = ClosureMethod1;
        float v697;
        v697 = cooperative_groups::reduce(v633, v687, v696);
        float v698;
        v698 = v697 / 16.0f;
        float v699[4l];
        long v700;
        v700 = 0l;
        while (while_method_2(v700)){
            long v702;
            v702 = 0l;
            while (while_method_1(v702)){
                assert("Tensor range check" && 0 <= v700 && v700 < 1l);
                assert("Tensor range check" && 0 <= v702 && v702 < 4l);
                long v704;
                v704 = 4l * v700;
                long v705;
                v705 = v704 + v702;
                float v706;
                v706 = v641[v705];
                float v707;
                v707 = v706 - v698;
                float v708;
                v708 = exp(v707);
                assert("Tensor range check" && 0 <= v700 && v700 < 1l);
                assert("Tensor range check" && 0 <= v702 && v702 < 4l);
                v699[v705] = v708;
                v702 += 1l ;
            }
            v700 += 1l ;
        }
        float v709;
        v709 = 0.0f;
        long v710;
        v710 = 0l;
        while (while_method_2(v710)){
            long v712;
            v712 = 0l;
            while (while_method_1(v712)){
                assert("Tensor range check" && 0 <= v710 && v710 < 1l);
                assert("Tensor range check" && 0 <= v712 && v712 < 4l);
                long v714;
                v714 = 4l * v710;
                long v715;
                v715 = v714 + v712;
                float v716;
                v716 = v699[v715];
                float v717;
                v717 = v716 + v709;
                v709 = v717;
                v712 += 1l ;
            }
            v710 += 1l ;
        }
        float v718;
        v718 = cooperative_groups::reduce(v633, v709, v696);
        float v719[4l];
        long v720;
        v720 = 0l;
        while (while_method_2(v720)){
            long v722;
            v722 = 0l;
            while (while_method_1(v722)){
                assert("Tensor range check" && 0 <= v720 && v720 < 1l);
                assert("Tensor range check" && 0 <= v722 && v722 < 4l);
                long v724;
                v724 = 4l * v720;
                long v725;
                v725 = v724 + v722;
                float v726;
                v726 = v699[v725];
                float v727;
                v727 = v726 / v718;
                assert("Tensor range check" && 0 <= v720 && v720 < 1l);
                assert("Tensor range check" && 0 <= v722 && v722 < 4l);
                v719[v725] = v727;
                v722 += 1l ;
            }
            v720 += 1l ;
        }
        float v728[4l];
        float v729;
        v729 = 0.0f;
        long v730;
        v730 = 0l;
        while (while_method_2(v730)){
            assert("Tensor range check" && 0 <= v730 && v730 < 1l);
            long v732;
            v732 = 4l * v730;
            assert("Tensor range check" && 0 <= v730 && v730 < 1l);
            long v733; float v734;
            Tuple0 tmp5 = Tuple0(0l, 0.0f);
            v733 = tmp5.v0; v734 = tmp5.v1;
            while (while_method_1(v733)){
                assert("Tensor range check" && 0 <= v733 && v733 < 4l);
                long v736;
                v736 = v733 + v732;
                float v737;
                v737 = v719[v736];
                float v738;
                v738 = v737 + v734;
                v734 = v738;
                v733 += 1l ;
            }
            Fun0 v739;
            v739 = ClosureMethod3;
            float v740;
            v740 = cooperative_groups::inclusive_scan(v633, v734, v739);
            float v741;
            v741 = v633.shfl(v740,v633.num_threads()-1);
            bool v742;
            v742 = v633.num_threads() <= 32;
            bool v743;
            v743 = v742 == false;
            if (v743){
                assert("The thread block tile in the exclusive scan has to be less than or equal 32." && v742);
            } else {
            }
            float v745;
            v745 = v633.shfl_up(v740,1);
            bool v746;
            v746 = v633.thread_rank() == 0;
            float v747;
            if (v746){
                v747 = 0.0f;
            } else {
                v747 = v745;
            }
            float v748;
            v748 = v729 + v747;
            long v749; float v750;
            Tuple0 tmp6 = Tuple0(0l, v748);
            v749 = tmp6.v0; v750 = tmp6.v1;
            while (while_method_1(v749)){
                assert("Tensor range check" && 0 <= v749 && v749 < 4l);
                long v752;
                v752 = v749 + v732;
                float v753;
                v753 = v719[v752];
                assert("Tensor range check" && 0 <= v749 && v749 < 4l);
                v728[v752] = v750;
                float v754;
                v754 = v753 + v750;
                v750 = v754;
                v749 += 1l ;
            }
            float v755;
            v755 = v729 + v741;
            v729 = v755;
            v730 += 1l ;
        }
        assert("Tensor range check" && 0 <= v686 && v686 < 128l);
        float v756;
        v756 = v1[v686];
        float v757[4l];
        long v758;
        v758 = 0l;
        while (while_method_2(v758)){
            long v760;
            v760 = 0l;
            while (while_method_1(v760)){
                assert("Tensor range check" && 0 <= v758 && v758 < 1l);
                assert("Tensor range check" && 0 <= v760 && v760 < 4l);
                long v762;
                v762 = 4l * v758;
                long v763;
                v763 = v762 + v760;
                float v764;
                v764 = v728[v763];
                float v765;
                v765 = v764 - v756;
                assert("Tensor range check" && 0 <= v758 && v758 < 1l);
                assert("Tensor range check" && 0 <= v760 && v760 < 4l);
                v757[v763] = v765;
                v760 += 1l ;
            }
            v758 += 1l ;
        }
        float v766; long v767;
        Tuple1 tmp7 = Tuple1(-1.0f / 0.0f, 0l);
        v766 = tmp7.v0; v767 = tmp7.v1;
        long v768;
        v768 = 0l;
        while (while_method_2(v768)){
            long v770;
            v770 = 0l;
            while (while_method_1(v770)){
                assert("Tensor range check" && 0 <= v768 && v768 < 1l);
                assert("Tensor range check" && 0 <= v770 && v770 < 4l);
                long v772;
                v772 = 4l * v768;
                long v773;
                v773 = v772 + v770;
                float v774;
                v774 = v757[v773];
                long v775;
                v775 = v642[v773];
                bool v776;
                v776 = v774 >= 0.0f;
                bool v778;
                if (v776){
                    bool v777;
                    v777 = v766 >= 0.0f;
                    v778 = v777;
                } else {
                    v778 = false;
                }
                float v787; long v788;
                if (v778){
                    bool v779;
                    v779 = v774 <= v766;
                    if (v779){
                        v787 = v774; v788 = v775;
                    } else {
                        v787 = v766; v788 = v767;
                    }
                } else {
                    if (v776){
                        v787 = v774; v788 = v775;
                    } else {
                        bool v782;
                        v782 = v766 >= 0.0f;
                        if (v782){
                            v787 = v766; v788 = v767;
                        } else {
                            v787 = v774; v788 = v775;
                        }
                    }
                }
                v766 = v787;
                v767 = v788;
                v770 += 1l ;
            }
            v768 += 1l ;
        }
        Fun1 v789;
        v789 = ClosureMethod4;
        float v790; long v791;
        Tuple1 tmp8 = cooperative_groups::reduce(v633, Tuple1(v766, v767), v789);
        v790 = tmp8.v0; v791 = tmp8.v1;
        assert("Tensor range check" && 0 <= v637 && v637 < 1l);
        long v792;
        v792 = 128l * v637;
        long v793;
        v793 = v792 + v629;
        v8[v793] = v791;
        v637 += 1l ;
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
    del v0, v5, v10, v11, v12, v13, v14, v15, v16, v20
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
    v55 = 0
    print('[', end="")
    v57 = 0
    while method0(v57):
        v59 = v55
        v60 = v59 >= 2048
        del v59
        if v60:
            v63 = " ..."
            print(v63, end="")
            del v63
            break
        else:
            pass
        del v60
        v64 = v57 == 0
        v65 = v64 != True
        del v64
        if v65:
            v68 = "; "
            print(v68, end="")
            del v68
        else:
            pass
        del v65
        v69 = v55 + 1
        v55 = v69
        del v69
        v70 = v18[v57].item()
        print(v70, end="")
        del v70
        v57 += 1 
    del v18, v55, v57
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
