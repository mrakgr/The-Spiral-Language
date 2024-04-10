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
    v1 = v0 < 524288l;
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
    v1 = v0 < 128l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 8l;
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
__device__ Tuple1 ClosureMethod3(Tuple1 tup0, Tuple1 tup1){
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
        v19 = v14 % 4096l;
        long v20;
        v20 = v14 / 4096l;
        bool v21;
        v21 = v20 < 128l;
        bool v22;
        v22 = v21 == false;
        if (v22){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v21);
        } else {
        }
        assert("Tensor range check" && 0 <= v20 && v20 < 128l);
        assert("Tensor range check" && 0 <= v19 && v19 < 4096l);
        long v24;
        v24 = 4l * v19;
        long v25;
        v25 = 16384l * v20;
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
    v53 = v49 % 512l;
    long v54;
    v54 = v49 / 512l;
    bool v55;
    v55 = v54 < 1l;
    bool v56;
    v56 = v55 == false;
    if (v56){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v55);
    } else {
    }
    auto & v58 = v11;
    assert("Tensor range check" && 0 <= v54 && v54 < 1l);
    assert("Tensor range check" && 0 <= v53 && v53 < 512l);
    long v59;
    v59 = 4l * v53;
    long v60;
    v60 = 16384l * v54;
    long v61;
    v61 = v60 + v59;
    assert("Tensor range check" && 0 <= v54 && v54 < 1l);
    assert("Tensor range check" && 0 <= v53 && v53 < 512l);
    long v62;
    v62 = 0l;
    while (while_method_2(v62)){
        assert("Tensor range check" && 0 <= v62 && v62 < 128l);
        long v64;
        v64 = 16384l * v62;
        long v65;
        v65 = v64 + v61;
        assert("Tensor range check" && 0 <= v62 && v62 < 128l);
        float v66[32l];
        long v67[32l];
        long v68;
        v68 = 0l;
        while (while_method_3(v68)){
            assert("Tensor range check" && 0 <= v68 && v68 < 8l);
            long v70;
            v70 = 4l * v68;
            assert("Tensor range check" && 0 <= v68 && v68 < 8l);
            long v71;
            v71 = 2048l * v68;
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
        while (while_method_3(v75)){
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
                    v85 = v75 < 8l;
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
                    v92 = v53 < 512l;
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
                v96 = v53 * 32l;
                long v97;
                v97 = v90 + v96;
                assert("Tensor range check" && 0 <= v75 && v75 < 8l);
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
            v101 = v54 <= 1l;
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
            v106 = v62 <= 128l;
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
        v110 = v62 + v54;
        long v111[32l];
        long v112;
        v112 = 0l;
        while (while_method_3(v112)){
            long v114;
            v114 = 0l;
            while (while_method_1(v114)){
                assert("Tensor range check" && 0 <= v112 && v112 < 8l);
                assert("Tensor range check" && 0 <= v114 && v114 < 4l);
                long v116;
                v116 = 4l * v112;
                long v117;
                v117 = v116 + v114;
                long v118;
                v118 = v67[v117];
                assert("Tensor range check" && 0 <= v112 && v112 < 8l);
                assert("Tensor range check" && 0 <= v114 && v114 < 4l);
                v111[v117] = v110;
                v114 += 1l ;
            }
            v112 += 1l ;
        }
        long v119;
        v119 = 0l;
        while (while_method_3(v119)){
            assert("Tensor range check" && 0 <= v119 && v119 < 8l);
            long v121;
            v121 = 2048l * v119;
            long v122;
            v122 = v121 + v65;
            assert("Tensor range check" && 0 <= v119 && v119 < 8l);
            long v123;
            v123 = 4l * v119;
            int4* v124;
            v124 = reinterpret_cast<int4*>(v111 + v123);
            int4* v125;
            v125 = reinterpret_cast<int4*>(v9 + v122);
            assert("Pointer alignment check" && (unsigned long long)(v124) % 4l == 0 && (unsigned long long)(v125) % 4l == 0);
            *v125 = *v124;
            v119 += 1l ;
        }
        v62 += 1l ;
    }
    __syncthreads();
    long v126;
    v126 = threadIdx.x;
    bool v127;
    v127 = 0l <= v126;
    bool v128;
    v128 = v127 == false;
    if (v128){
        assert("The index needs to be zero or positive." && v127);
    } else {
    }
    long v130;
    v130 = v126 % 512l;
    long v131;
    v131 = v126 / 512l;
    bool v132;
    v132 = v131 < 1l;
    bool v133;
    v133 = v132 == false;
    if (v133){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v132);
    } else {
    }
    auto & v135 = v11;
    assert("Tensor range check" && 0 <= v131 && v131 < 1l);
    assert("Tensor range check" && 0 <= v130 && v130 < 512l);
    long v136;
    v136 = 4l * v130;
    long v137;
    v137 = 16384l * v131;
    long v138;
    v138 = v137 + v136;
    assert("Tensor range check" && 0 <= v131 && v131 < 1l);
    long v139;
    v139 = 128l * v131;
    long v140;
    v140 = 0l;
    while (while_method_2(v140)){
        assert("Tensor range check" && 0 <= v140 && v140 < 128l);
        long v142;
        v142 = 16384l * v140;
        long v143;
        v143 = v142 + v138;
        float v144[32l];
        long v145[32l];
        long v146;
        v146 = 0l;
        while (while_method_3(v146)){
            assert("Tensor range check" && 0 <= v146 && v146 < 8l);
            long v148;
            v148 = 4l * v146;
            assert("Tensor range check" && 0 <= v146 && v146 < 8l);
            long v149;
            v149 = 2048l * v146;
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
        while (while_method_3(v153)){
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
                    v163 = v153 < 8l;
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
                v169 = 0l <= v130;
                bool v171;
                if (v169){
                    bool v170;
                    v170 = v130 < 512l;
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
                v174 = v130 * 32l;
                long v175;
                v175 = v168 + v174;
                assert("Tensor range check" && 0 <= v153 && v153 < 8l);
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
        v178 = 0l < v131;
        bool v180;
        if (v178){
            bool v179;
            v179 = v131 <= 1l;
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
            v184 = v140 <= 128l;
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
        v188 = v140 + v131;
        assert("Tensor range check" && 0 <= v140 && v140 < 128l);
        long v189;
        v189 = v140 + v139;
        v10[v189] = v188;
        v140 += 1l ;
    }
    __syncthreads();
    long v190;
    v190 = threadIdx.x;
    bool v191;
    v191 = 0l <= v190;
    bool v192;
    v192 = v191 == false;
    if (v192){
        assert("The index needs to be zero or positive." && v191);
    } else {
    }
    long v194;
    v194 = v190 % 512l;
    long v195;
    v195 = v190 / 512l;
    bool v196;
    v196 = v195 < 1l;
    bool v197;
    v197 = v196 == false;
    if (v197){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v196);
    } else {
    }
    auto & v199 = v11;
    assert("Tensor range check" && 0 <= v195 && v195 < 1l);
    assert("Tensor range check" && 0 <= v194 && v194 < 512l);
    long v200;
    v200 = 4l * v194;
    long v201;
    v201 = 16384l * v195;
    long v202;
    v202 = v201 + v200;
    assert("Tensor range check" && 0 <= v195 && v195 < 1l);
    assert("Tensor range check" && 0 <= v194 && v194 < 512l);
    long v203;
    v203 = 0l;
    while (while_method_2(v203)){
        assert("Tensor range check" && 0 <= v203 && v203 < 128l);
        long v205;
        v205 = 16384l * v203;
        long v206;
        v206 = v205 + v202;
        assert("Tensor range check" && 0 <= v203 && v203 < 128l);
        float v207[32l];
        long v208[32l];
        long v209;
        v209 = 0l;
        while (while_method_3(v209)){
            assert("Tensor range check" && 0 <= v209 && v209 < 8l);
            long v211;
            v211 = 4l * v209;
            assert("Tensor range check" && 0 <= v209 && v209 < 8l);
            long v212;
            v212 = 2048l * v209;
            long v213;
            v213 = v212 + v206;
            int4* v214;
            v214 = reinterpret_cast<int4*>(v0 + v213);
            int4* v215;
            v215 = reinterpret_cast<int4*>(v207 + v211);
            assert("Pointer alignment check" && (unsigned long long)(v214) % 4l == 0 && (unsigned long long)(v215) % 4l == 0);
            *v215 = *v214;
            v209 += 1l ;
        }
        long v216;
        v216 = 0l;
        while (while_method_3(v216)){
            long v218;
            v218 = 0l;
            while (while_method_1(v218)){
                bool v220;
                v220 = 0l <= v218;
                bool v222;
                if (v220){
                    bool v221;
                    v221 = v218 < 4l;
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
                bool v225;
                v225 = 0l <= v216;
                bool v227;
                if (v225){
                    bool v226;
                    v226 = v216 < 8l;
                    v227 = v226;
                } else {
                    v227 = false;
                }
                bool v228;
                v228 = v227 == false;
                if (v228){
                    assert("The indices should be inside the range of the dimension." && v227);
                } else {
                }
                long v230;
                v230 = v216 * 4l;
                long v231;
                v231 = v218 + v230;
                bool v232;
                v232 = 0l <= v194;
                bool v234;
                if (v232){
                    bool v233;
                    v233 = v194 < 512l;
                    v234 = v233;
                } else {
                    v234 = false;
                }
                bool v235;
                v235 = v234 == false;
                if (v235){
                    assert("The indices should be inside the range of the dimension." && v234);
                } else {
                }
                long v237;
                v237 = v194 * 32l;
                long v238;
                v238 = v231 + v237;
                assert("Tensor range check" && 0 <= v216 && v216 < 8l);
                assert("Tensor range check" && 0 <= v218 && v218 < 4l);
                long v239;
                v239 = 4l * v216;
                long v240;
                v240 = v239 + v218;
                v208[v240] = v238;
                v218 += 1l ;
            }
            v216 += 1l ;
        }
        bool v241;
        v241 = 0l < v195;
        bool v243;
        if (v241){
            bool v242;
            v242 = v195 <= 1l;
            v243 = v242;
        } else {
            v243 = false;
        }
        bool v244;
        v244 = v243 == false;
        if (v244){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v243);
        } else {
        }
        bool v246;
        v246 = 0l < v203;
        bool v248;
        if (v246){
            bool v247;
            v247 = v203 <= 128l;
            v248 = v247;
        } else {
            v248 = false;
        }
        bool v249;
        v249 = v248 == false;
        if (v249){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v248);
        } else {
        }
        long v251;
        v251 = v203 + v195;
        float v252;
        v252 = 0.0f;
        long v253;
        v253 = 0l;
        while (while_method_3(v253)){
            long v255;
            v255 = 0l;
            while (while_method_1(v255)){
                assert("Tensor range check" && 0 <= v253 && v253 < 8l);
                assert("Tensor range check" && 0 <= v255 && v255 < 4l);
                long v257;
                v257 = 4l * v253;
                long v258;
                v258 = v257 + v255;
                float v259;
                v259 = v207[v258];
                float v260;
                v260 = v259 + v252;
                v252 = v260;
                v255 += 1l ;
            }
            v253 += 1l ;
        }
        auto v261 = cooperative_groups::coalesced_threads();
        float v262;
        v262 = cooperative_groups::reduce(v261, v252, v36);
        long v263;
        v263 = threadIdx.x;
        long v264;
        v264 = v263 / 32l;
        __shared__ float v265[16l];
        bool v266;
        v266 = 0l <= v264;
        bool v267;
        v267 = v266 == false;
        if (v267){
            assert("The index needs to be zero or positive." && v266);
        } else {
        }
        long v269;
        v269 = v264 % 16l;
        long v270;
        v270 = v264 / 16l;
        bool v271;
        v271 = v270 < 1l;
        bool v272;
        v272 = v271 == false;
        if (v272){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v271);
        } else {
        }
        assert("Tensor range check" && 0 <= v270 && v270 < 1l);
        assert("Tensor range check" && 0 <= v269 && v269 < 16l);
        long v274;
        v274 = 16l * v270;
        long v275;
        v275 = v274 + v269;
        v265[v275] = v262;
        v199.sync() ;
        long v276;
        v276 = threadIdx.x;
        long v277;
        v277 = v276 % 32l;
        bool v278;
        v278 = v277 < 16l;
        float v281;
        if (v278){
            assert("Tensor range check" && 0 <= v270 && v270 < 1l);
            assert("Tensor range check" && 0 <= v277 && v277 < 16l);
            long v279;
            v279 = v274 + v277;
            float v280;
            v280 = v265[v279];
            v281 = v280;
        } else {
            v281 = 0.0f;
        }
        v199.sync() ;
        float v282;
        v282 = cooperative_groups::reduce(v261, v281, v36);
        float v283;
        v283 = v282 / 2048.0f;
        float v284[32l];
        long v285;
        v285 = 0l;
        while (while_method_3(v285)){
            long v287;
            v287 = 0l;
            while (while_method_1(v287)){
                assert("Tensor range check" && 0 <= v285 && v285 < 8l);
                assert("Tensor range check" && 0 <= v287 && v287 < 4l);
                long v289;
                v289 = 4l * v285;
                long v290;
                v290 = v289 + v287;
                float v291;
                v291 = v207[v290];
                float v292;
                v292 = v291 - v283;
                float v293;
                v293 = exp(v292);
                assert("Tensor range check" && 0 <= v285 && v285 < 8l);
                assert("Tensor range check" && 0 <= v287 && v287 < 4l);
                v284[v290] = v293;
                v287 += 1l ;
            }
            v285 += 1l ;
        }
        float v294;
        v294 = 0.0f;
        long v295;
        v295 = 0l;
        while (while_method_3(v295)){
            long v297;
            v297 = 0l;
            while (while_method_1(v297)){
                assert("Tensor range check" && 0 <= v295 && v295 < 8l);
                assert("Tensor range check" && 0 <= v297 && v297 < 4l);
                long v299;
                v299 = 4l * v295;
                long v300;
                v300 = v299 + v297;
                float v301;
                v301 = v284[v300];
                float v302;
                v302 = v301 + v294;
                v294 = v302;
                v297 += 1l ;
            }
            v295 += 1l ;
        }
        auto v303 = cooperative_groups::coalesced_threads();
        float v304;
        v304 = cooperative_groups::reduce(v303, v294, v36);
        long v305;
        v305 = threadIdx.x;
        long v306;
        v306 = v305 / 32l;
        __shared__ float v307[16l];
        bool v308;
        v308 = 0l <= v306;
        bool v309;
        v309 = v308 == false;
        if (v309){
            assert("The index needs to be zero or positive." && v308);
        } else {
        }
        long v311;
        v311 = v306 % 16l;
        long v312;
        v312 = v306 / 16l;
        bool v313;
        v313 = v312 < 1l;
        bool v314;
        v314 = v313 == false;
        if (v314){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v313);
        } else {
        }
        assert("Tensor range check" && 0 <= v312 && v312 < 1l);
        assert("Tensor range check" && 0 <= v311 && v311 < 16l);
        long v316;
        v316 = 16l * v312;
        long v317;
        v317 = v316 + v311;
        v307[v317] = v304;
        v199.sync() ;
        long v318;
        v318 = threadIdx.x;
        long v319;
        v319 = v318 % 32l;
        bool v320;
        v320 = v319 < 16l;
        float v323;
        if (v320){
            assert("Tensor range check" && 0 <= v312 && v312 < 1l);
            assert("Tensor range check" && 0 <= v319 && v319 < 16l);
            long v321;
            v321 = v316 + v319;
            float v322;
            v322 = v307[v321];
            v323 = v322;
        } else {
            v323 = 0.0f;
        }
        v199.sync() ;
        float v324;
        v324 = cooperative_groups::reduce(v303, v323, v36);
        float v325[32l];
        long v326;
        v326 = 0l;
        while (while_method_3(v326)){
            long v328;
            v328 = 0l;
            while (while_method_1(v328)){
                assert("Tensor range check" && 0 <= v326 && v326 < 8l);
                assert("Tensor range check" && 0 <= v328 && v328 < 4l);
                long v330;
                v330 = 4l * v326;
                long v331;
                v331 = v330 + v328;
                float v332;
                v332 = v284[v331];
                float v333;
                v333 = v332 / v324;
                assert("Tensor range check" && 0 <= v326 && v326 < 8l);
                assert("Tensor range check" && 0 <= v328 && v328 < 4l);
                v325[v331] = v333;
                v328 += 1l ;
            }
            v326 += 1l ;
        }
        long v334;
        v334 = 0l;
        while (while_method_3(v334)){
            assert("Tensor range check" && 0 <= v334 && v334 < 8l);
            long v336;
            v336 = 2048l * v334;
            long v337;
            v337 = v336 + v206;
            assert("Tensor range check" && 0 <= v334 && v334 < 8l);
            long v338;
            v338 = 4l * v334;
            int4* v339;
            v339 = reinterpret_cast<int4*>(v325 + v338);
            int4* v340;
            v340 = reinterpret_cast<int4*>(v3 + v337);
            assert("Pointer alignment check" && (unsigned long long)(v339) % 4l == 0 && (unsigned long long)(v340) % 4l == 0);
            *v340 = *v339;
            v334 += 1l ;
        }
        v203 += 1l ;
    }
    __syncthreads();
    long v341;
    v341 = threadIdx.x;
    bool v342;
    v342 = 0l <= v341;
    bool v343;
    v343 = v342 == false;
    if (v343){
        assert("The index needs to be zero or positive." && v342);
    } else {
    }
    long v345;
    v345 = v341 % 512l;
    long v346;
    v346 = v341 / 512l;
    bool v347;
    v347 = v346 < 1l;
    bool v348;
    v348 = v347 == false;
    if (v348){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v347);
    } else {
    }
    auto & v350 = v11;
    assert("Tensor range check" && 0 <= v346 && v346 < 1l);
    assert("Tensor range check" && 0 <= v345 && v345 < 512l);
    long v351;
    v351 = 4l * v345;
    long v352;
    v352 = 16384l * v346;
    long v353;
    v353 = v352 + v351;
    assert("Tensor range check" && 0 <= v346 && v346 < 1l);
    assert("Tensor range check" && 0 <= v345 && v345 < 512l);
    long v354;
    v354 = 0l;
    while (while_method_2(v354)){
        assert("Tensor range check" && 0 <= v354 && v354 < 128l);
        long v356;
        v356 = 16384l * v354;
        long v357;
        v357 = v356 + v353;
        assert("Tensor range check" && 0 <= v354 && v354 < 128l);
        float v358[32l];
        long v359[32l];
        long v360;
        v360 = 0l;
        while (while_method_3(v360)){
            assert("Tensor range check" && 0 <= v360 && v360 < 8l);
            long v362;
            v362 = 4l * v360;
            assert("Tensor range check" && 0 <= v360 && v360 < 8l);
            long v363;
            v363 = 2048l * v360;
            long v364;
            v364 = v363 + v357;
            int4* v365;
            v365 = reinterpret_cast<int4*>(v0 + v364);
            int4* v366;
            v366 = reinterpret_cast<int4*>(v358 + v362);
            assert("Pointer alignment check" && (unsigned long long)(v365) % 4l == 0 && (unsigned long long)(v366) % 4l == 0);
            *v366 = *v365;
            v360 += 1l ;
        }
        long v367;
        v367 = 0l;
        while (while_method_3(v367)){
            long v369;
            v369 = 0l;
            while (while_method_1(v369)){
                bool v371;
                v371 = 0l <= v369;
                bool v373;
                if (v371){
                    bool v372;
                    v372 = v369 < 4l;
                    v373 = v372;
                } else {
                    v373 = false;
                }
                bool v374;
                v374 = v373 == false;
                if (v374){
                    assert("The indices should be inside the range of the dimension." && v373);
                } else {
                }
                bool v376;
                v376 = 0l <= v367;
                bool v378;
                if (v376){
                    bool v377;
                    v377 = v367 < 8l;
                    v378 = v377;
                } else {
                    v378 = false;
                }
                bool v379;
                v379 = v378 == false;
                if (v379){
                    assert("The indices should be inside the range of the dimension." && v378);
                } else {
                }
                long v381;
                v381 = v367 * 4l;
                long v382;
                v382 = v369 + v381;
                bool v383;
                v383 = 0l <= v345;
                bool v385;
                if (v383){
                    bool v384;
                    v384 = v345 < 512l;
                    v385 = v384;
                } else {
                    v385 = false;
                }
                bool v386;
                v386 = v385 == false;
                if (v386){
                    assert("The indices should be inside the range of the dimension." && v385);
                } else {
                }
                long v388;
                v388 = v345 * 32l;
                long v389;
                v389 = v382 + v388;
                assert("Tensor range check" && 0 <= v367 && v367 < 8l);
                assert("Tensor range check" && 0 <= v369 && v369 < 4l);
                long v390;
                v390 = 4l * v367;
                long v391;
                v391 = v390 + v369;
                v359[v391] = v389;
                v369 += 1l ;
            }
            v367 += 1l ;
        }
        bool v392;
        v392 = 0l < v346;
        bool v394;
        if (v392){
            bool v393;
            v393 = v346 <= 1l;
            v394 = v393;
        } else {
            v394 = false;
        }
        bool v395;
        v395 = v394 == false;
        if (v395){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v394);
        } else {
        }
        bool v397;
        v397 = 0l < v354;
        bool v399;
        if (v397){
            bool v398;
            v398 = v354 <= 128l;
            v399 = v398;
        } else {
            v399 = false;
        }
        bool v400;
        v400 = v399 == false;
        if (v400){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v399);
        } else {
        }
        long v402;
        v402 = v354 + v346;
        float v403[32l];
        long v404;
        v404 = 0l;
        while (while_method_3(v404)){
            long v406;
            v406 = 0l;
            while (while_method_1(v406)){
                assert("Tensor range check" && 0 <= v404 && v404 < 8l);
                assert("Tensor range check" && 0 <= v406 && v406 < 4l);
                long v408;
                v408 = 4l * v404;
                long v409;
                v409 = v408 + v406;
                float v410;
                v410 = v358[v409];
                float v411;
                v411 = v410 * v410;
                assert("Tensor range check" && 0 <= v404 && v404 < 8l);
                assert("Tensor range check" && 0 <= v406 && v406 < 4l);
                v403[v409] = v411;
                v406 += 1l ;
            }
            v404 += 1l ;
        }
        float v412;
        v412 = 0.0f;
        long v413;
        v413 = 0l;
        while (while_method_3(v413)){
            long v415;
            v415 = 0l;
            while (while_method_1(v415)){
                assert("Tensor range check" && 0 <= v413 && v413 < 8l);
                assert("Tensor range check" && 0 <= v415 && v415 < 4l);
                long v417;
                v417 = 4l * v413;
                long v418;
                v418 = v417 + v415;
                float v419;
                v419 = v403[v418];
                float v420;
                v420 = v419 + v412;
                v412 = v420;
                v415 += 1l ;
            }
            v413 += 1l ;
        }
        auto v421 = cooperative_groups::coalesced_threads();
        float v422;
        v422 = cooperative_groups::reduce(v421, v412, v36);
        long v423;
        v423 = threadIdx.x;
        long v424;
        v424 = v423 / 32l;
        __shared__ float v425[16l];
        bool v426;
        v426 = 0l <= v424;
        bool v427;
        v427 = v426 == false;
        if (v427){
            assert("The index needs to be zero or positive." && v426);
        } else {
        }
        long v429;
        v429 = v424 % 16l;
        long v430;
        v430 = v424 / 16l;
        bool v431;
        v431 = v430 < 1l;
        bool v432;
        v432 = v431 == false;
        if (v432){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v431);
        } else {
        }
        assert("Tensor range check" && 0 <= v430 && v430 < 1l);
        assert("Tensor range check" && 0 <= v429 && v429 < 16l);
        long v434;
        v434 = 16l * v430;
        long v435;
        v435 = v434 + v429;
        v425[v435] = v422;
        v350.sync() ;
        long v436;
        v436 = threadIdx.x;
        long v437;
        v437 = v436 % 32l;
        bool v438;
        v438 = v437 < 16l;
        float v441;
        if (v438){
            assert("Tensor range check" && 0 <= v430 && v430 < 1l);
            assert("Tensor range check" && 0 <= v437 && v437 < 16l);
            long v439;
            v439 = v434 + v437;
            float v440;
            v440 = v425[v439];
            v441 = v440;
        } else {
            v441 = 0.0f;
        }
        v350.sync() ;
        float v442;
        v442 = cooperative_groups::reduce(v421, v441, v36);
        float v443[32l];
        long v444;
        v444 = 0l;
        while (while_method_3(v444)){
            long v446;
            v446 = 0l;
            while (while_method_1(v446)){
                assert("Tensor range check" && 0 <= v444 && v444 < 8l);
                assert("Tensor range check" && 0 <= v446 && v446 < 4l);
                long v448;
                v448 = 4l * v444;
                long v449;
                v449 = v448 + v446;
                float v450;
                v450 = v403[v449];
                float v451;
                v451 = v450 / v442;
                assert("Tensor range check" && 0 <= v444 && v444 < 8l);
                assert("Tensor range check" && 0 <= v446 && v446 < 4l);
                v443[v449] = v451;
                v446 += 1l ;
            }
            v444 += 1l ;
        }
        long v452;
        v452 = 0l;
        while (while_method_3(v452)){
            assert("Tensor range check" && 0 <= v452 && v452 < 8l);
            long v454;
            v454 = 2048l * v452;
            long v455;
            v455 = v454 + v357;
            assert("Tensor range check" && 0 <= v452 && v452 < 8l);
            long v456;
            v456 = 4l * v452;
            int4* v457;
            v457 = reinterpret_cast<int4*>(v443 + v456);
            int4* v458;
            v458 = reinterpret_cast<int4*>(v6 + v455);
            assert("Pointer alignment check" && (unsigned long long)(v457) % 4l == 0 && (unsigned long long)(v458) % 4l == 0);
            *v458 = *v457;
            v452 += 1l ;
        }
        v354 += 1l ;
    }
    __syncthreads();
    long v459;
    v459 = threadIdx.x;
    bool v460;
    v460 = 0l <= v459;
    bool v461;
    v461 = v460 == false;
    if (v461){
        assert("The index needs to be zero or positive." && v460);
    } else {
    }
    long v463;
    v463 = v459 % 512l;
    long v464;
    v464 = v459 / 512l;
    bool v465;
    v465 = v464 < 1l;
    bool v466;
    v466 = v465 == false;
    if (v466){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v465);
    } else {
    }
    auto & v468 = v11;
    assert("Tensor range check" && 0 <= v464 && v464 < 1l);
    assert("Tensor range check" && 0 <= v463 && v463 < 512l);
    long v469;
    v469 = 4l * v463;
    long v470;
    v470 = 16384l * v464;
    long v471;
    v471 = v470 + v469;
    assert("Tensor range check" && 0 <= v464 && v464 < 1l);
    long v472;
    v472 = 128l * v464;
    long v473;
    v473 = 0l;
    while (while_method_2(v473)){
        assert("Tensor range check" && 0 <= v473 && v473 < 128l);
        long v475;
        v475 = 16384l * v473;
        long v476;
        v476 = v475 + v471;
        float v477[32l];
        long v478[32l];
        long v479;
        v479 = 0l;
        while (while_method_3(v479)){
            assert("Tensor range check" && 0 <= v479 && v479 < 8l);
            long v481;
            v481 = 4l * v479;
            assert("Tensor range check" && 0 <= v479 && v479 < 8l);
            long v482;
            v482 = 2048l * v479;
            long v483;
            v483 = v482 + v476;
            int4* v484;
            v484 = reinterpret_cast<int4*>(v0 + v483);
            int4* v485;
            v485 = reinterpret_cast<int4*>(v477 + v481);
            assert("Pointer alignment check" && (unsigned long long)(v484) % 4l == 0 && (unsigned long long)(v485) % 4l == 0);
            *v485 = *v484;
            v479 += 1l ;
        }
        long v486;
        v486 = 0l;
        while (while_method_3(v486)){
            long v488;
            v488 = 0l;
            while (while_method_1(v488)){
                bool v490;
                v490 = 0l <= v488;
                bool v492;
                if (v490){
                    bool v491;
                    v491 = v488 < 4l;
                    v492 = v491;
                } else {
                    v492 = false;
                }
                bool v493;
                v493 = v492 == false;
                if (v493){
                    assert("The indices should be inside the range of the dimension." && v492);
                } else {
                }
                bool v495;
                v495 = 0l <= v486;
                bool v497;
                if (v495){
                    bool v496;
                    v496 = v486 < 8l;
                    v497 = v496;
                } else {
                    v497 = false;
                }
                bool v498;
                v498 = v497 == false;
                if (v498){
                    assert("The indices should be inside the range of the dimension." && v497);
                } else {
                }
                long v500;
                v500 = v486 * 4l;
                long v501;
                v501 = v488 + v500;
                bool v502;
                v502 = 0l <= v463;
                bool v504;
                if (v502){
                    bool v503;
                    v503 = v463 < 512l;
                    v504 = v503;
                } else {
                    v504 = false;
                }
                bool v505;
                v505 = v504 == false;
                if (v505){
                    assert("The indices should be inside the range of the dimension." && v504);
                } else {
                }
                long v507;
                v507 = v463 * 32l;
                long v508;
                v508 = v501 + v507;
                assert("Tensor range check" && 0 <= v486 && v486 < 8l);
                assert("Tensor range check" && 0 <= v488 && v488 < 4l);
                long v509;
                v509 = 4l * v486;
                long v510;
                v510 = v509 + v488;
                v478[v510] = v508;
                v488 += 1l ;
            }
            v486 += 1l ;
        }
        bool v511;
        v511 = 0l < v464;
        bool v513;
        if (v511){
            bool v512;
            v512 = v464 <= 1l;
            v513 = v512;
        } else {
            v513 = false;
        }
        bool v514;
        v514 = v513 == false;
        if (v514){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v513);
        } else {
        }
        bool v516;
        v516 = 0l < v473;
        bool v518;
        if (v516){
            bool v517;
            v517 = v473 <= 128l;
            v518 = v517;
        } else {
            v518 = false;
        }
        bool v519;
        v519 = v518 == false;
        if (v519){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v518);
        } else {
        }
        long v521;
        v521 = v473 + v464;
        float v522; long v523;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v522 = tmp1.v0; v523 = tmp1.v1;
        long v524;
        v524 = 0l;
        while (while_method_3(v524)){
            long v526;
            v526 = 0l;
            while (while_method_1(v526)){
                assert("Tensor range check" && 0 <= v524 && v524 < 8l);
                assert("Tensor range check" && 0 <= v526 && v526 < 4l);
                long v528;
                v528 = 4l * v524;
                long v529;
                v529 = v528 + v526;
                float v530;
                v530 = v477[v529];
                long v531;
                v531 = v478[v529];
                bool v532;
                v532 = v530 > v522;
                float v533; long v534;
                if (v532){
                    v533 = v530; v534 = v531;
                } else {
                    v533 = v522; v534 = v523;
                }
                v522 = v533;
                v523 = v534;
                v526 += 1l ;
            }
            v524 += 1l ;
        }
        auto v535 = cooperative_groups::coalesced_threads();
        Fun1 v536;
        v536 = ClosureMethod1;
        float v537; long v538;
        Tuple1 tmp2 = cooperative_groups::reduce(v535, Tuple1(v522, v523), v536);
        v537 = tmp2.v0; v538 = tmp2.v1;
        long v539;
        v539 = threadIdx.x;
        long v540;
        v540 = v539 / 32l;
        __shared__ float v541[16l];
        __shared__ long v542[16l];
        bool v543;
        v543 = 0l <= v540;
        bool v544;
        v544 = v543 == false;
        if (v544){
            assert("The index needs to be zero or positive." && v543);
        } else {
        }
        long v546;
        v546 = v540 % 16l;
        long v547;
        v547 = v540 / 16l;
        bool v548;
        v548 = v547 < 1l;
        bool v549;
        v549 = v548 == false;
        if (v549){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v548);
        } else {
        }
        assert("Tensor range check" && 0 <= v547 && v547 < 1l);
        assert("Tensor range check" && 0 <= v546 && v546 < 16l);
        long v551;
        v551 = 16l * v547;
        long v552;
        v552 = v551 + v546;
        v541[v552] = v537;
        v542[v552] = v538;
        v468.sync() ;
        long v553;
        v553 = threadIdx.x;
        long v554;
        v554 = v553 % 32l;
        bool v555;
        v555 = v554 < 16l;
        float v559; long v560;
        if (v555){
            assert("Tensor range check" && 0 <= v547 && v547 < 1l);
            assert("Tensor range check" && 0 <= v554 && v554 < 16l);
            long v556;
            v556 = v551 + v554;
            float v557;
            v557 = v541[v556];
            long v558;
            v558 = v542[v556];
            v559 = v557; v560 = v558;
        } else {
            v559 = -1.0f / 0.0f; v560 = 0l;
        }
        v468.sync() ;
        float v561; long v562;
        Tuple1 tmp3 = cooperative_groups::reduce(v535, Tuple1(v559, v560), v536);
        v561 = tmp3.v0; v562 = tmp3.v1;
        assert("Tensor range check" && 0 <= v473 && v473 < 128l);
        long v563;
        v563 = v473 + v472;
        v7[v563] = v562;
        v473 += 1l ;
    }
    __syncthreads();
    long v564;
    v564 = threadIdx.x;
    bool v565;
    v565 = 0l <= v564;
    bool v566;
    v566 = v565 == false;
    if (v566){
        assert("The index needs to be zero or positive." && v565);
    } else {
    }
    long v568;
    v568 = v564 % 512l;
    long v569;
    v569 = v564 / 512l;
    bool v570;
    v570 = v569 < 1l;
    bool v571;
    v571 = v570 == false;
    if (v571){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v570);
    } else {
    }
    auto & v573 = v11;
    assert("Tensor range check" && 0 <= v569 && v569 < 1l);
    assert("Tensor range check" && 0 <= v568 && v568 < 512l);
    long v574;
    v574 = 4l * v568;
    long v575;
    v575 = 16384l * v569;
    long v576;
    v576 = v575 + v574;
    assert("Tensor range check" && 0 <= v569 && v569 < 1l);
    assert("Tensor range check" && 0 <= v568 && v568 < 512l);
    long v577;
    v577 = 0l;
    while (while_method_2(v577)){
        assert("Tensor range check" && 0 <= v577 && v577 < 128l);
        long v579;
        v579 = 16384l * v577;
        long v580;
        v580 = v579 + v576;
        assert("Tensor range check" && 0 <= v577 && v577 < 128l);
        float v581[32l];
        long v582[32l];
        long v583;
        v583 = 0l;
        while (while_method_3(v583)){
            assert("Tensor range check" && 0 <= v583 && v583 < 8l);
            long v585;
            v585 = 4l * v583;
            assert("Tensor range check" && 0 <= v583 && v583 < 8l);
            long v586;
            v586 = 2048l * v583;
            long v587;
            v587 = v586 + v580;
            int4* v588;
            v588 = reinterpret_cast<int4*>(v0 + v587);
            int4* v589;
            v589 = reinterpret_cast<int4*>(v581 + v585);
            assert("Pointer alignment check" && (unsigned long long)(v588) % 4l == 0 && (unsigned long long)(v589) % 4l == 0);
            *v589 = *v588;
            v583 += 1l ;
        }
        long v590;
        v590 = 0l;
        while (while_method_3(v590)){
            long v592;
            v592 = 0l;
            while (while_method_1(v592)){
                bool v594;
                v594 = 0l <= v592;
                bool v596;
                if (v594){
                    bool v595;
                    v595 = v592 < 4l;
                    v596 = v595;
                } else {
                    v596 = false;
                }
                bool v597;
                v597 = v596 == false;
                if (v597){
                    assert("The indices should be inside the range of the dimension." && v596);
                } else {
                }
                bool v599;
                v599 = 0l <= v590;
                bool v601;
                if (v599){
                    bool v600;
                    v600 = v590 < 8l;
                    v601 = v600;
                } else {
                    v601 = false;
                }
                bool v602;
                v602 = v601 == false;
                if (v602){
                    assert("The indices should be inside the range of the dimension." && v601);
                } else {
                }
                long v604;
                v604 = v590 * 4l;
                long v605;
                v605 = v592 + v604;
                bool v606;
                v606 = 0l <= v568;
                bool v608;
                if (v606){
                    bool v607;
                    v607 = v568 < 512l;
                    v608 = v607;
                } else {
                    v608 = false;
                }
                bool v609;
                v609 = v608 == false;
                if (v609){
                    assert("The indices should be inside the range of the dimension." && v608);
                } else {
                }
                long v611;
                v611 = v568 * 32l;
                long v612;
                v612 = v605 + v611;
                assert("Tensor range check" && 0 <= v590 && v590 < 8l);
                assert("Tensor range check" && 0 <= v592 && v592 < 4l);
                long v613;
                v613 = 4l * v590;
                long v614;
                v614 = v613 + v592;
                v582[v614] = v612;
                v592 += 1l ;
            }
            v590 += 1l ;
        }
        bool v615;
        v615 = 0l < v569;
        bool v617;
        if (v615){
            bool v616;
            v616 = v569 <= 1l;
            v617 = v616;
        } else {
            v617 = false;
        }
        bool v618;
        v618 = v617 == false;
        if (v618){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v617);
        } else {
        }
        bool v620;
        v620 = 0l < v577;
        bool v622;
        if (v620){
            bool v621;
            v621 = v577 <= 128l;
            v622 = v621;
        } else {
            v622 = false;
        }
        bool v623;
        v623 = v622 == false;
        if (v623){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v622);
        } else {
        }
        long v625;
        v625 = v577 + v569;
        float v626;
        v626 = 0.0f;
        long v627;
        v627 = 0l;
        while (while_method_3(v627)){
            long v629;
            v629 = 0l;
            while (while_method_1(v629)){
                assert("Tensor range check" && 0 <= v627 && v627 < 8l);
                assert("Tensor range check" && 0 <= v629 && v629 < 4l);
                long v631;
                v631 = 4l * v627;
                long v632;
                v632 = v631 + v629;
                float v633;
                v633 = v581[v632];
                float v634;
                v634 = v633 + v626;
                v626 = v634;
                v629 += 1l ;
            }
            v627 += 1l ;
        }
        auto v635 = cooperative_groups::coalesced_threads();
        float v636;
        v636 = cooperative_groups::reduce(v635, v626, v36);
        long v637;
        v637 = threadIdx.x;
        long v638;
        v638 = v637 / 32l;
        __shared__ float v639[16l];
        bool v640;
        v640 = 0l <= v638;
        bool v641;
        v641 = v640 == false;
        if (v641){
            assert("The index needs to be zero or positive." && v640);
        } else {
        }
        long v643;
        v643 = v638 % 16l;
        long v644;
        v644 = v638 / 16l;
        bool v645;
        v645 = v644 < 1l;
        bool v646;
        v646 = v645 == false;
        if (v646){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v645);
        } else {
        }
        assert("Tensor range check" && 0 <= v644 && v644 < 1l);
        assert("Tensor range check" && 0 <= v643 && v643 < 16l);
        long v648;
        v648 = 16l * v644;
        long v649;
        v649 = v648 + v643;
        v639[v649] = v636;
        v573.sync() ;
        long v650;
        v650 = threadIdx.x;
        long v651;
        v651 = v650 % 32l;
        bool v652;
        v652 = v651 < 16l;
        float v655;
        if (v652){
            assert("Tensor range check" && 0 <= v644 && v644 < 1l);
            assert("Tensor range check" && 0 <= v651 && v651 < 16l);
            long v653;
            v653 = v648 + v651;
            float v654;
            v654 = v639[v653];
            v655 = v654;
        } else {
            v655 = 0.0f;
        }
        v573.sync() ;
        float v656;
        v656 = cooperative_groups::reduce(v635, v655, v36);
        float v657;
        v657 = v656 / 2048.0f;
        float v658[32l];
        long v659;
        v659 = 0l;
        while (while_method_3(v659)){
            long v661;
            v661 = 0l;
            while (while_method_1(v661)){
                assert("Tensor range check" && 0 <= v659 && v659 < 8l);
                assert("Tensor range check" && 0 <= v661 && v661 < 4l);
                long v663;
                v663 = 4l * v659;
                long v664;
                v664 = v663 + v661;
                float v665;
                v665 = v581[v664];
                float v666;
                v666 = v665 - v657;
                float v667;
                v667 = exp(v666);
                assert("Tensor range check" && 0 <= v659 && v659 < 8l);
                assert("Tensor range check" && 0 <= v661 && v661 < 4l);
                v658[v664] = v667;
                v661 += 1l ;
            }
            v659 += 1l ;
        }
        float v668;
        v668 = 0.0f;
        long v669;
        v669 = 0l;
        while (while_method_3(v669)){
            long v671;
            v671 = 0l;
            while (while_method_1(v671)){
                assert("Tensor range check" && 0 <= v669 && v669 < 8l);
                assert("Tensor range check" && 0 <= v671 && v671 < 4l);
                long v673;
                v673 = 4l * v669;
                long v674;
                v674 = v673 + v671;
                float v675;
                v675 = v658[v674];
                float v676;
                v676 = v675 + v668;
                v668 = v676;
                v671 += 1l ;
            }
            v669 += 1l ;
        }
        auto v677 = cooperative_groups::coalesced_threads();
        float v678;
        v678 = cooperative_groups::reduce(v677, v668, v36);
        long v679;
        v679 = threadIdx.x;
        long v680;
        v680 = v679 / 32l;
        __shared__ float v681[16l];
        bool v682;
        v682 = 0l <= v680;
        bool v683;
        v683 = v682 == false;
        if (v683){
            assert("The index needs to be zero or positive." && v682);
        } else {
        }
        long v685;
        v685 = v680 % 16l;
        long v686;
        v686 = v680 / 16l;
        bool v687;
        v687 = v686 < 1l;
        bool v688;
        v688 = v687 == false;
        if (v688){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v687);
        } else {
        }
        assert("Tensor range check" && 0 <= v686 && v686 < 1l);
        assert("Tensor range check" && 0 <= v685 && v685 < 16l);
        long v690;
        v690 = 16l * v686;
        long v691;
        v691 = v690 + v685;
        v681[v691] = v678;
        v573.sync() ;
        long v692;
        v692 = threadIdx.x;
        long v693;
        v693 = v692 % 32l;
        bool v694;
        v694 = v693 < 16l;
        float v697;
        if (v694){
            assert("Tensor range check" && 0 <= v686 && v686 < 1l);
            assert("Tensor range check" && 0 <= v693 && v693 < 16l);
            long v695;
            v695 = v690 + v693;
            float v696;
            v696 = v681[v695];
            v697 = v696;
        } else {
            v697 = 0.0f;
        }
        v573.sync() ;
        float v698;
        v698 = cooperative_groups::reduce(v677, v697, v36);
        float v699[32l];
        long v700;
        v700 = 0l;
        while (while_method_3(v700)){
            long v702;
            v702 = 0l;
            while (while_method_1(v702)){
                assert("Tensor range check" && 0 <= v700 && v700 < 8l);
                assert("Tensor range check" && 0 <= v702 && v702 < 4l);
                long v704;
                v704 = 4l * v700;
                long v705;
                v705 = v704 + v702;
                float v706;
                v706 = v658[v705];
                float v707;
                v707 = v706 / v698;
                assert("Tensor range check" && 0 <= v700 && v700 < 8l);
                assert("Tensor range check" && 0 <= v702 && v702 < 4l);
                v699[v705] = v707;
                v702 += 1l ;
            }
            v700 += 1l ;
        }
        float v708[32l];
        float v709;
        v709 = 0.0f;
        long v710;
        v710 = 0l;
        while (while_method_3(v710)){
            assert("Tensor range check" && 0 <= v710 && v710 < 8l);
            long v712;
            v712 = 4l * v710;
            assert("Tensor range check" && 0 <= v710 && v710 < 8l);
            long v713; float v714;
            Tuple0 tmp4 = Tuple0(0l, 0.0f);
            v713 = tmp4.v0; v714 = tmp4.v1;
            while (while_method_1(v713)){
                assert("Tensor range check" && 0 <= v713 && v713 < 4l);
                long v716;
                v716 = v713 + v712;
                float v717;
                v717 = v699[v716];
                float v718;
                v718 = v717 + v714;
                v714 = v718;
                v713 += 1l ;
            }
            auto v719 = cooperative_groups::coalesced_threads();
            long v720;
            v720 = threadIdx.x;
            long v721;
            v721 = v720 / 32l;
            __shared__ float v722[16l];
            Fun0 v723;
            v723 = ClosureMethod2;
            float v724;
            v724 = cooperative_groups::inclusive_scan(v719, v714, v723);
            float v725;
            v725 = v719.shfl(v724,v719.num_threads()-1);
            float v726;
            v726 = v719.shfl_up(v724,1);
            bool v727;
            v727 = v719.thread_rank() == 0;
            float v728;
            if (v727){
                v728 = 0.0f;
            } else {
                v728 = v726;
            }
            bool v729;
            v729 = 0l <= v721;
            bool v730;
            v730 = v729 == false;
            if (v730){
                assert("The index needs to be zero or positive." && v729);
            } else {
            }
            long v732;
            v732 = v721 % 16l;
            long v733;
            v733 = v721 / 16l;
            bool v734;
            v734 = v733 < 1l;
            bool v735;
            v735 = v734 == false;
            if (v735){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v734);
            } else {
            }
            assert("Tensor range check" && 0 <= v733 && v733 < 1l);
            assert("Tensor range check" && 0 <= v732 && v732 < 16l);
            long v737;
            v737 = 16l * v733;
            long v738;
            v738 = v737 + v732;
            v722[v738] = v725;
            v573.sync() ;
            long v739;
            v739 = threadIdx.x;
            long v740;
            v740 = v739 % 32l;
            bool v741;
            v741 = v740 < 16l;
            float v744;
            if (v741){
                assert("Tensor range check" && 0 <= v733 && v733 < 1l);
                assert("Tensor range check" && 0 <= v740 && v740 < 16l);
                long v742;
                v742 = v737 + v740;
                float v743;
                v743 = v722[v742];
                v744 = v743;
            } else {
                v744 = 0.0f;
            }
            v573.sync() ;
            float v745;
            v745 = cooperative_groups::inclusive_scan(v719, v744, v723);
            float v746;
            v746 = v719.shfl(v745,v719.num_threads()-1);
            float v747;
            v747 = v719.shfl_up(v745,1);
            bool v748;
            v748 = v719.thread_rank() == 0;
            float v749;
            if (v748){
                v749 = 0.0f;
            } else {
                v749 = v747;
            }
            float v750;
            v750 = v719.shfl(v749,v732);
            float v751;
            v751 = v750 + v728;
            float v752;
            v752 = v709 + v751;
            long v753; float v754;
            Tuple0 tmp5 = Tuple0(0l, v752);
            v753 = tmp5.v0; v754 = tmp5.v1;
            while (while_method_1(v753)){
                assert("Tensor range check" && 0 <= v753 && v753 < 4l);
                long v756;
                v756 = v753 + v712;
                float v757;
                v757 = v699[v756];
                assert("Tensor range check" && 0 <= v753 && v753 < 4l);
                v708[v756] = v754;
                float v758;
                v758 = v757 + v754;
                v754 = v758;
                v753 += 1l ;
            }
            float v759;
            v759 = v709 + v746;
            v709 = v759;
            v710 += 1l ;
        }
        long v760;
        v760 = 0l;
        while (while_method_3(v760)){
            assert("Tensor range check" && 0 <= v760 && v760 < 8l);
            long v762;
            v762 = 2048l * v760;
            long v763;
            v763 = v762 + v580;
            assert("Tensor range check" && 0 <= v760 && v760 < 8l);
            long v764;
            v764 = 4l * v760;
            int4* v765;
            v765 = reinterpret_cast<int4*>(v699 + v764);
            int4* v766;
            v766 = reinterpret_cast<int4*>(v4 + v763);
            assert("Pointer alignment check" && (unsigned long long)(v765) % 4l == 0 && (unsigned long long)(v766) % 4l == 0);
            *v766 = *v765;
            int4* v767;
            v767 = reinterpret_cast<int4*>(v708 + v764);
            int4* v768;
            v768 = reinterpret_cast<int4*>(v5 + v763);
            assert("Pointer alignment check" && (unsigned long long)(v767) % 4l == 0 && (unsigned long long)(v768) % 4l == 0);
            *v768 = *v767;
            v760 += 1l ;
        }
        v577 += 1l ;
    }
    __syncthreads();
    long v769;
    v769 = threadIdx.x;
    bool v770;
    v770 = 0l <= v769;
    bool v771;
    v771 = v770 == false;
    if (v771){
        assert("The index needs to be zero or positive." && v770);
    } else {
    }
    long v773;
    v773 = v769 % 512l;
    long v774;
    v774 = v769 / 512l;
    bool v775;
    v775 = v774 < 1l;
    bool v776;
    v776 = v775 == false;
    if (v776){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v775);
    } else {
    }
    auto & v778 = v11;
    assert("Tensor range check" && 0 <= v774 && v774 < 1l);
    assert("Tensor range check" && 0 <= v773 && v773 < 512l);
    long v779;
    v779 = 4l * v773;
    long v780;
    v780 = 16384l * v774;
    long v781;
    v781 = v780 + v779;
    assert("Tensor range check" && 0 <= v774 && v774 < 1l);
    long v782;
    v782 = 128l * v774;
    long v783;
    v783 = 0l;
    while (while_method_2(v783)){
        assert("Tensor range check" && 0 <= v783 && v783 < 128l);
        long v785;
        v785 = 16384l * v783;
        long v786;
        v786 = v785 + v781;
        float v787[32l];
        long v788[32l];
        long v789;
        v789 = 0l;
        while (while_method_3(v789)){
            assert("Tensor range check" && 0 <= v789 && v789 < 8l);
            long v791;
            v791 = 4l * v789;
            assert("Tensor range check" && 0 <= v789 && v789 < 8l);
            long v792;
            v792 = 2048l * v789;
            long v793;
            v793 = v792 + v786;
            int4* v794;
            v794 = reinterpret_cast<int4*>(v0 + v793);
            int4* v795;
            v795 = reinterpret_cast<int4*>(v787 + v791);
            assert("Pointer alignment check" && (unsigned long long)(v794) % 4l == 0 && (unsigned long long)(v795) % 4l == 0);
            *v795 = *v794;
            v789 += 1l ;
        }
        long v796;
        v796 = 0l;
        while (while_method_3(v796)){
            long v798;
            v798 = 0l;
            while (while_method_1(v798)){
                bool v800;
                v800 = 0l <= v798;
                bool v802;
                if (v800){
                    bool v801;
                    v801 = v798 < 4l;
                    v802 = v801;
                } else {
                    v802 = false;
                }
                bool v803;
                v803 = v802 == false;
                if (v803){
                    assert("The indices should be inside the range of the dimension." && v802);
                } else {
                }
                bool v805;
                v805 = 0l <= v796;
                bool v807;
                if (v805){
                    bool v806;
                    v806 = v796 < 8l;
                    v807 = v806;
                } else {
                    v807 = false;
                }
                bool v808;
                v808 = v807 == false;
                if (v808){
                    assert("The indices should be inside the range of the dimension." && v807);
                } else {
                }
                long v810;
                v810 = v796 * 4l;
                long v811;
                v811 = v798 + v810;
                bool v812;
                v812 = 0l <= v773;
                bool v814;
                if (v812){
                    bool v813;
                    v813 = v773 < 512l;
                    v814 = v813;
                } else {
                    v814 = false;
                }
                bool v815;
                v815 = v814 == false;
                if (v815){
                    assert("The indices should be inside the range of the dimension." && v814);
                } else {
                }
                long v817;
                v817 = v773 * 32l;
                long v818;
                v818 = v811 + v817;
                assert("Tensor range check" && 0 <= v796 && v796 < 8l);
                assert("Tensor range check" && 0 <= v798 && v798 < 4l);
                long v819;
                v819 = 4l * v796;
                long v820;
                v820 = v819 + v798;
                v788[v820] = v818;
                v798 += 1l ;
            }
            v796 += 1l ;
        }
        bool v821;
        v821 = 0l < v774;
        bool v823;
        if (v821){
            bool v822;
            v822 = v774 <= 1l;
            v823 = v822;
        } else {
            v823 = false;
        }
        bool v824;
        v824 = v823 == false;
        if (v824){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v823);
        } else {
        }
        bool v826;
        v826 = 0l < v783;
        bool v828;
        if (v826){
            bool v827;
            v827 = v783 <= 128l;
            v828 = v827;
        } else {
            v828 = false;
        }
        bool v829;
        v829 = v828 == false;
        if (v829){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v828);
        } else {
        }
        long v831;
        v831 = v783 + v774;
        float v832;
        v832 = 0.0f;
        long v833;
        v833 = 0l;
        while (while_method_3(v833)){
            long v835;
            v835 = 0l;
            while (while_method_1(v835)){
                assert("Tensor range check" && 0 <= v833 && v833 < 8l);
                assert("Tensor range check" && 0 <= v835 && v835 < 4l);
                long v837;
                v837 = 4l * v833;
                long v838;
                v838 = v837 + v835;
                float v839;
                v839 = v787[v838];
                float v840;
                v840 = v839 + v832;
                v832 = v840;
                v835 += 1l ;
            }
            v833 += 1l ;
        }
        auto v841 = cooperative_groups::coalesced_threads();
        float v842;
        v842 = cooperative_groups::reduce(v841, v832, v36);
        long v843;
        v843 = threadIdx.x;
        long v844;
        v844 = v843 / 32l;
        __shared__ float v845[16l];
        bool v846;
        v846 = 0l <= v844;
        bool v847;
        v847 = v846 == false;
        if (v847){
            assert("The index needs to be zero or positive." && v846);
        } else {
        }
        long v849;
        v849 = v844 % 16l;
        long v850;
        v850 = v844 / 16l;
        bool v851;
        v851 = v850 < 1l;
        bool v852;
        v852 = v851 == false;
        if (v852){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v851);
        } else {
        }
        assert("Tensor range check" && 0 <= v850 && v850 < 1l);
        assert("Tensor range check" && 0 <= v849 && v849 < 16l);
        long v854;
        v854 = 16l * v850;
        long v855;
        v855 = v854 + v849;
        v845[v855] = v842;
        v778.sync() ;
        long v856;
        v856 = threadIdx.x;
        long v857;
        v857 = v856 % 32l;
        bool v858;
        v858 = v857 < 16l;
        float v861;
        if (v858){
            assert("Tensor range check" && 0 <= v850 && v850 < 1l);
            assert("Tensor range check" && 0 <= v857 && v857 < 16l);
            long v859;
            v859 = v854 + v857;
            float v860;
            v860 = v845[v859];
            v861 = v860;
        } else {
            v861 = 0.0f;
        }
        v778.sync() ;
        float v862;
        v862 = cooperative_groups::reduce(v841, v861, v36);
        float v863;
        v863 = v862 / 16384.0f;
        float v864[32l];
        long v865;
        v865 = 0l;
        while (while_method_3(v865)){
            long v867;
            v867 = 0l;
            while (while_method_1(v867)){
                assert("Tensor range check" && 0 <= v865 && v865 < 8l);
                assert("Tensor range check" && 0 <= v867 && v867 < 4l);
                long v869;
                v869 = 4l * v865;
                long v870;
                v870 = v869 + v867;
                float v871;
                v871 = v787[v870];
                float v872;
                v872 = v871 - v863;
                float v873;
                v873 = exp(v872);
                assert("Tensor range check" && 0 <= v865 && v865 < 8l);
                assert("Tensor range check" && 0 <= v867 && v867 < 4l);
                v864[v870] = v873;
                v867 += 1l ;
            }
            v865 += 1l ;
        }
        float v874;
        v874 = 0.0f;
        long v875;
        v875 = 0l;
        while (while_method_3(v875)){
            long v877;
            v877 = 0l;
            while (while_method_1(v877)){
                assert("Tensor range check" && 0 <= v875 && v875 < 8l);
                assert("Tensor range check" && 0 <= v877 && v877 < 4l);
                long v879;
                v879 = 4l * v875;
                long v880;
                v880 = v879 + v877;
                float v881;
                v881 = v864[v880];
                float v882;
                v882 = v881 + v874;
                v874 = v882;
                v877 += 1l ;
            }
            v875 += 1l ;
        }
        auto v883 = cooperative_groups::coalesced_threads();
        float v884;
        v884 = cooperative_groups::reduce(v883, v874, v36);
        long v885;
        v885 = threadIdx.x;
        long v886;
        v886 = v885 / 32l;
        __shared__ float v887[16l];
        bool v888;
        v888 = 0l <= v886;
        bool v889;
        v889 = v888 == false;
        if (v889){
            assert("The index needs to be zero or positive." && v888);
        } else {
        }
        long v891;
        v891 = v886 % 16l;
        long v892;
        v892 = v886 / 16l;
        bool v893;
        v893 = v892 < 1l;
        bool v894;
        v894 = v893 == false;
        if (v894){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v893);
        } else {
        }
        assert("Tensor range check" && 0 <= v892 && v892 < 1l);
        assert("Tensor range check" && 0 <= v891 && v891 < 16l);
        long v896;
        v896 = 16l * v892;
        long v897;
        v897 = v896 + v891;
        v887[v897] = v884;
        v778.sync() ;
        long v898;
        v898 = threadIdx.x;
        long v899;
        v899 = v898 % 32l;
        bool v900;
        v900 = v899 < 16l;
        float v903;
        if (v900){
            assert("Tensor range check" && 0 <= v892 && v892 < 1l);
            assert("Tensor range check" && 0 <= v899 && v899 < 16l);
            long v901;
            v901 = v896 + v899;
            float v902;
            v902 = v887[v901];
            v903 = v902;
        } else {
            v903 = 0.0f;
        }
        v778.sync() ;
        float v904;
        v904 = cooperative_groups::reduce(v883, v903, v36);
        float v905[32l];
        long v906;
        v906 = 0l;
        while (while_method_3(v906)){
            long v908;
            v908 = 0l;
            while (while_method_1(v908)){
                assert("Tensor range check" && 0 <= v906 && v906 < 8l);
                assert("Tensor range check" && 0 <= v908 && v908 < 4l);
                long v910;
                v910 = 4l * v906;
                long v911;
                v911 = v910 + v908;
                float v912;
                v912 = v864[v911];
                float v913;
                v913 = v912 / v904;
                assert("Tensor range check" && 0 <= v906 && v906 < 8l);
                assert("Tensor range check" && 0 <= v908 && v908 < 4l);
                v905[v911] = v913;
                v908 += 1l ;
            }
            v906 += 1l ;
        }
        float v914[32l];
        float v915;
        v915 = 0.0f;
        long v916;
        v916 = 0l;
        while (while_method_3(v916)){
            assert("Tensor range check" && 0 <= v916 && v916 < 8l);
            long v918;
            v918 = 4l * v916;
            assert("Tensor range check" && 0 <= v916 && v916 < 8l);
            long v919; float v920;
            Tuple0 tmp6 = Tuple0(0l, 0.0f);
            v919 = tmp6.v0; v920 = tmp6.v1;
            while (while_method_1(v919)){
                assert("Tensor range check" && 0 <= v919 && v919 < 4l);
                long v922;
                v922 = v919 + v918;
                float v923;
                v923 = v905[v922];
                float v924;
                v924 = v923 + v920;
                v920 = v924;
                v919 += 1l ;
            }
            auto v925 = cooperative_groups::coalesced_threads();
            long v926;
            v926 = threadIdx.x;
            long v927;
            v927 = v926 / 32l;
            __shared__ float v928[16l];
            Fun0 v929;
            v929 = ClosureMethod2;
            float v930;
            v930 = cooperative_groups::inclusive_scan(v925, v920, v929);
            float v931;
            v931 = v925.shfl(v930,v925.num_threads()-1);
            float v932;
            v932 = v925.shfl_up(v930,1);
            bool v933;
            v933 = v925.thread_rank() == 0;
            float v934;
            if (v933){
                v934 = 0.0f;
            } else {
                v934 = v932;
            }
            bool v935;
            v935 = 0l <= v927;
            bool v936;
            v936 = v935 == false;
            if (v936){
                assert("The index needs to be zero or positive." && v935);
            } else {
            }
            long v938;
            v938 = v927 % 16l;
            long v939;
            v939 = v927 / 16l;
            bool v940;
            v940 = v939 < 1l;
            bool v941;
            v941 = v940 == false;
            if (v941){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v940);
            } else {
            }
            assert("Tensor range check" && 0 <= v939 && v939 < 1l);
            assert("Tensor range check" && 0 <= v938 && v938 < 16l);
            long v943;
            v943 = 16l * v939;
            long v944;
            v944 = v943 + v938;
            v928[v944] = v931;
            v778.sync() ;
            long v945;
            v945 = threadIdx.x;
            long v946;
            v946 = v945 % 32l;
            bool v947;
            v947 = v946 < 16l;
            float v950;
            if (v947){
                assert("Tensor range check" && 0 <= v939 && v939 < 1l);
                assert("Tensor range check" && 0 <= v946 && v946 < 16l);
                long v948;
                v948 = v943 + v946;
                float v949;
                v949 = v928[v948];
                v950 = v949;
            } else {
                v950 = 0.0f;
            }
            v778.sync() ;
            float v951;
            v951 = cooperative_groups::inclusive_scan(v925, v950, v929);
            float v952;
            v952 = v925.shfl(v951,v925.num_threads()-1);
            float v953;
            v953 = v925.shfl_up(v951,1);
            bool v954;
            v954 = v925.thread_rank() == 0;
            float v955;
            if (v954){
                v955 = 0.0f;
            } else {
                v955 = v953;
            }
            float v956;
            v956 = v925.shfl(v955,v938);
            float v957;
            v957 = v956 + v934;
            float v958;
            v958 = v915 + v957;
            long v959; float v960;
            Tuple0 tmp7 = Tuple0(0l, v958);
            v959 = tmp7.v0; v960 = tmp7.v1;
            while (while_method_1(v959)){
                assert("Tensor range check" && 0 <= v959 && v959 < 4l);
                long v962;
                v962 = v959 + v918;
                float v963;
                v963 = v905[v962];
                assert("Tensor range check" && 0 <= v959 && v959 < 4l);
                v914[v962] = v960;
                float v964;
                v964 = v963 + v960;
                v960 = v964;
                v959 += 1l ;
            }
            float v965;
            v965 = v915 + v952;
            v915 = v965;
            v916 += 1l ;
        }
        assert("Tensor range check" && 0 <= v831 && v831 < 128l);
        float v966;
        v966 = v1[v831];
        float v967[32l];
        long v968;
        v968 = 0l;
        while (while_method_3(v968)){
            long v970;
            v970 = 0l;
            while (while_method_1(v970)){
                assert("Tensor range check" && 0 <= v968 && v968 < 8l);
                assert("Tensor range check" && 0 <= v970 && v970 < 4l);
                long v972;
                v972 = 4l * v968;
                long v973;
                v973 = v972 + v970;
                float v974;
                v974 = v914[v973];
                float v975;
                v975 = v974 - v966;
                assert("Tensor range check" && 0 <= v968 && v968 < 8l);
                assert("Tensor range check" && 0 <= v970 && v970 < 4l);
                v967[v973] = v975;
                v970 += 1l ;
            }
            v968 += 1l ;
        }
        float v976; long v977;
        Tuple1 tmp8 = Tuple1(-1.0f / 0.0f, 0l);
        v976 = tmp8.v0; v977 = tmp8.v1;
        long v978;
        v978 = 0l;
        while (while_method_3(v978)){
            long v980;
            v980 = 0l;
            while (while_method_1(v980)){
                assert("Tensor range check" && 0 <= v978 && v978 < 8l);
                assert("Tensor range check" && 0 <= v980 && v980 < 4l);
                long v982;
                v982 = 4l * v978;
                long v983;
                v983 = v982 + v980;
                float v984;
                v984 = v967[v983];
                long v985;
                v985 = v788[v983];
                bool v986;
                v986 = v984 >= 0.0f;
                bool v988;
                if (v986){
                    bool v987;
                    v987 = v976 >= 0.0f;
                    v988 = v987;
                } else {
                    v988 = false;
                }
                float v997; long v998;
                if (v988){
                    bool v989;
                    v989 = v984 <= v976;
                    if (v989){
                        v997 = v984; v998 = v985;
                    } else {
                        v997 = v976; v998 = v977;
                    }
                } else {
                    if (v986){
                        v997 = v984; v998 = v985;
                    } else {
                        bool v992;
                        v992 = v976 >= 0.0f;
                        if (v992){
                            v997 = v976; v998 = v977;
                        } else {
                            v997 = v984; v998 = v985;
                        }
                    }
                }
                v976 = v997;
                v977 = v998;
                v980 += 1l ;
            }
            v978 += 1l ;
        }
        auto v999 = cooperative_groups::coalesced_threads();
        Fun1 v1000;
        v1000 = ClosureMethod3;
        float v1001; long v1002;
        Tuple1 tmp9 = cooperative_groups::reduce(v999, Tuple1(v976, v977), v1000);
        v1001 = tmp9.v0; v1002 = tmp9.v1;
        long v1003;
        v1003 = threadIdx.x;
        long v1004;
        v1004 = v1003 / 32l;
        __shared__ float v1005[16l];
        __shared__ long v1006[16l];
        bool v1007;
        v1007 = 0l <= v1004;
        bool v1008;
        v1008 = v1007 == false;
        if (v1008){
            assert("The index needs to be zero or positive." && v1007);
        } else {
        }
        long v1010;
        v1010 = v1004 % 16l;
        long v1011;
        v1011 = v1004 / 16l;
        bool v1012;
        v1012 = v1011 < 1l;
        bool v1013;
        v1013 = v1012 == false;
        if (v1013){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v1012);
        } else {
        }
        assert("Tensor range check" && 0 <= v1011 && v1011 < 1l);
        assert("Tensor range check" && 0 <= v1010 && v1010 < 16l);
        long v1015;
        v1015 = 16l * v1011;
        long v1016;
        v1016 = v1015 + v1010;
        v1005[v1016] = v1001;
        v1006[v1016] = v1002;
        v778.sync() ;
        long v1017;
        v1017 = threadIdx.x;
        long v1018;
        v1018 = v1017 % 32l;
        bool v1019;
        v1019 = v1018 < 16l;
        float v1023; long v1024;
        if (v1019){
            assert("Tensor range check" && 0 <= v1011 && v1011 < 1l);
            assert("Tensor range check" && 0 <= v1018 && v1018 < 16l);
            long v1020;
            v1020 = v1015 + v1018;
            float v1021;
            v1021 = v1005[v1020];
            long v1022;
            v1022 = v1006[v1020];
            v1023 = v1021; v1024 = v1022;
        } else {
            v1023 = -1.0f / 0.0f; v1024 = 0l;
        }
        v778.sync() ;
        float v1025; long v1026;
        Tuple1 tmp10 = cooperative_groups::reduce(v999, Tuple1(v1023, v1024), v1000);
        v1025 = tmp10.v0; v1026 = tmp10.v1;
        assert("Tensor range check" && 0 <= v783 && v783 < 128l);
        long v1027;
        v1027 = v783 + v782;
        v8[v1027] = v1026;
        v783 += 1l ;
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
    v0 = cp.random.normal(0.0,1.0,2097152,dtype=cp.float32)
    v1 = v0.size
    v2 = 2097152 == v1
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
    v11 = cp.empty(2097152,dtype=cp.float32)
    pass
    v12 = cp.empty(2097152,dtype=cp.float32)
    v13 = cp.empty(2097152,dtype=cp.float32)
    pass
    v14 = cp.empty(2097152,dtype=cp.float32)
    pass
    v15 = cp.empty(128,dtype=cp.int32)
    pass
    v16 = cp.empty(128,dtype=cp.int32)
    pass
    v17 = cp.empty(2097152,dtype=cp.int32)
    pass
    v18 = cp.empty(128,dtype=cp.int32)
    v19 = 0
    v20 = raw_module.get_function(f"entry{v19}")
    del v19
    v20.max_dynamic_shared_size_bytes = 0 
    v20((1,),(512,),(v0, v5, v10, v11, v12, v13, v14, v15, v16, v17, v18),shared_mem=0)
    del v0, v5, v10, v11, v12, v13, v14, v15, v16, v17, v20
    v21 = 0
    print('[', end="")
    v23 = 0
    while method0(v23):
        v25 = v21
        v26 = v25 >= 2097152
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
        v35 = v21 + 1
        v21 = v35
        del v35
        v36 = v18[v23].item()
        print(v36, end="")
        del v36
        v23 += 1 
    del v18, v21, v23
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
