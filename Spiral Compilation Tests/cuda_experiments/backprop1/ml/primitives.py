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
    v1 = v0 < 1024l;
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
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 2l;
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
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3, float * v4, float * v5, float * v6, long * v7, long * v8, long * v9, long * v10, long * v11) {
    auto v12 = cooperative_groups::this_thread_block();
    float v13;
    v13 = 0.0f;
    long v14;
    v14 = threadIdx.x;
    long v15;
    v15 = v14;
    while (while_method_0(v15)){
        bool v17;
        v17 = 0l <= v15;
        bool v18;
        v18 = v17 == false;
        if (v18){
            assert("The index needs to be zero or positive." && v17);
        } else {
        }
        long v20;
        v20 = v15 % 1024l;
        long v21;
        v21 = v15 / 1024l;
        bool v22;
        v22 = v21 < 1l;
        bool v23;
        v23 = v22 == false;
        if (v23){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v22);
        } else {
        }
        assert("Tensor range check" && 0 <= v21 && v21 < 1l);
        assert("Tensor range check" && 0 <= v20 && v20 < 1024l);
        long v25;
        v25 = 4l * v20;
        long v26;
        v26 = 4096l * v21;
        long v27;
        v27 = v26 + v25;
        float v28[4l];
        int4* v29;
        v29 = reinterpret_cast<int4*>(v0 + v27);
        int4* v30;
        v30 = reinterpret_cast<int4*>(v28 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v29) % 4l == 0 && (unsigned long long)(v30) % 4l == 0);
        *v30 = *v29;
        long v31; float v32;
        Tuple0 tmp0 = Tuple0(0l, v13);
        v31 = tmp0.v0; v32 = tmp0.v1;
        while (while_method_1(v31)){
            assert("Tensor range check" && 0 <= v31 && v31 < 4l);
            float v34;
            v34 = v28[v31];
            float v35;
            v35 = v34 + v32;
            v32 = v35;
            v31 += 1l ;
        }
        v13 = v32;
        v15 += 512l ;
    }
    auto v36 = cooperative_groups::coalesced_threads();
    Fun0 v37;
    v37 = ClosureMethod0;
    float v38;
    v38 = cooperative_groups::reduce(v36, v13, v37);
    long v39;
    v39 = threadIdx.x;
    long v40;
    v40 = v39 / 32l;
    __shared__ float v41[16l];
    assert("Tensor range check" && 0 <= v40 && v40 < 16l);
    v41[v40] = v38;
    __syncthreads();
    long v42;
    v42 = threadIdx.x;
    long v43;
    v43 = v42 % 32l;
    bool v44;
    v44 = v40 == 0l;
    bool v46;
    if (v44){
        bool v45;
        v45 = v43 < 16l;
        v46 = v45;
    } else {
        v46 = false;
    }
    if (v46){
        auto v47 = cooperative_groups::coalesced_threads();
        assert("Tensor range check" && 0 <= v43 && v43 < 16l);
        float v48;
        v48 = v41[v43];
        float v49;
        v49 = cooperative_groups::reduce(v47, v48, v37);
        v2[0l] = v49;
    } else {
    }
    __syncthreads();
    long v50;
    v50 = threadIdx.x;
    bool v51;
    v51 = 0l <= v50;
    bool v52;
    v52 = v51 == false;
    if (v52){
        assert("The index needs to be zero or positive." && v51);
    } else {
    }
    long v54;
    v54 = v50 % 512l;
    long v55;
    v55 = v50 / 512l;
    bool v56;
    v56 = v55 < 1l;
    bool v57;
    v57 = v56 == false;
    if (v57){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v56);
    } else {
    }
    auto & v59 = v12;
    assert("Tensor range check" && 0 <= v55 && v55 < 1l);
    assert("Tensor range check" && 0 <= v54 && v54 < 512l);
    long v60;
    v60 = 4l * v54;
    long v61;
    v61 = 4096l * v55;
    long v62;
    v62 = v61 + v60;
    assert("Tensor range check" && 0 <= v55 && v55 < 1l);
    assert("Tensor range check" && 0 <= v54 && v54 < 512l);
    long v63;
    v63 = 0l;
    while (while_method_2(v63)){
        assert("Tensor range check" && 0 <= v63 && v63 < 1l);
        long v65;
        v65 = 4096l * v63;
        long v66;
        v66 = v65 + v62;
        assert("Tensor range check" && 0 <= v63 && v63 < 1l);
        float v67[8l];
        long v68[8l];
        long v69;
        v69 = 0l;
        while (while_method_3(v69)){
            assert("Tensor range check" && 0 <= v69 && v69 < 2l);
            long v71;
            v71 = 4l * v69;
            assert("Tensor range check" && 0 <= v69 && v69 < 2l);
            long v72;
            v72 = 2048l * v69;
            long v73;
            v73 = v72 + v66;
            int4* v74;
            v74 = reinterpret_cast<int4*>(v0 + v73);
            int4* v75;
            v75 = reinterpret_cast<int4*>(v67 + v71);
            assert("Pointer alignment check" && (unsigned long long)(v74) % 4l == 0 && (unsigned long long)(v75) % 4l == 0);
            *v75 = *v74;
            v69 += 1l ;
        }
        long v76;
        v76 = 0l;
        while (while_method_3(v76)){
            long v78;
            v78 = 0l;
            while (while_method_1(v78)){
                bool v80;
                v80 = 0l <= v78;
                bool v82;
                if (v80){
                    bool v81;
                    v81 = v78 < 4l;
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
                bool v85;
                v85 = 0l <= v76;
                bool v87;
                if (v85){
                    bool v86;
                    v86 = v76 < 2l;
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
                v90 = v76 * 4l;
                long v91;
                v91 = v78 + v90;
                bool v92;
                v92 = 0l <= v54;
                bool v94;
                if (v92){
                    bool v93;
                    v93 = v54 < 512l;
                    v94 = v93;
                } else {
                    v94 = false;
                }
                bool v95;
                v95 = v94 == false;
                if (v95){
                    assert("The indices should be inside the range of the dimension." && v94);
                } else {
                }
                long v97;
                v97 = v54 * 8l;
                long v98;
                v98 = v91 + v97;
                assert("Tensor range check" && 0 <= v76 && v76 < 2l);
                assert("Tensor range check" && 0 <= v78 && v78 < 4l);
                long v99;
                v99 = 4l * v76;
                long v100;
                v100 = v99 + v78;
                v68[v100] = v98;
                v78 += 1l ;
            }
            v76 += 1l ;
        }
        bool v101;
        v101 = 0l < v55;
        bool v103;
        if (v101){
            bool v102;
            v102 = v55 <= 1l;
            v103 = v102;
        } else {
            v103 = false;
        }
        bool v104;
        v104 = v103 == false;
        if (v104){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v103);
        } else {
        }
        bool v106;
        v106 = 0l < v63;
        bool v108;
        if (v106){
            bool v107;
            v107 = v63 <= 1l;
            v108 = v107;
        } else {
            v108 = false;
        }
        bool v109;
        v109 = v108 == false;
        if (v109){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v108);
        } else {
        }
        long v111;
        v111 = v63 + v55;
        long v112[8l];
        long v113[8l];
        long v114;
        v114 = 0l;
        while (while_method_3(v114)){
            long v116;
            v116 = 0l;
            while (while_method_1(v116)){
                assert("Tensor range check" && 0 <= v114 && v114 < 2l);
                assert("Tensor range check" && 0 <= v116 && v116 < 4l);
                long v118;
                v118 = 4l * v114;
                long v119;
                v119 = v118 + v116;
                long v120;
                v120 = v68[v119];
                assert("Tensor range check" && 0 <= v114 && v114 < 2l);
                assert("Tensor range check" && 0 <= v116 && v116 < 4l);
                v112[v119] = v111;
                v113[v119] = v120;
                v116 += 1l ;
            }
            v114 += 1l ;
        }
        long v121;
        v121 = 0l;
        while (while_method_3(v121)){
            assert("Tensor range check" && 0 <= v121 && v121 < 2l);
            long v123;
            v123 = 2048l * v121;
            long v124;
            v124 = v123 + v66;
            assert("Tensor range check" && 0 <= v121 && v121 < 2l);
            long v125;
            v125 = 4l * v121;
            int4* v126;
            v126 = reinterpret_cast<int4*>(v112 + v125);
            int4* v127;
            v127 = reinterpret_cast<int4*>(v9 + v124);
            assert("Pointer alignment check" && (unsigned long long)(v126) % 4l == 0 && (unsigned long long)(v127) % 4l == 0);
            *v127 = *v126;
            int4* v128;
            v128 = reinterpret_cast<int4*>(v113 + v125);
            int4* v129;
            v129 = reinterpret_cast<int4*>(v10 + v124);
            assert("Pointer alignment check" && (unsigned long long)(v128) % 4l == 0 && (unsigned long long)(v129) % 4l == 0);
            *v129 = *v128;
            v121 += 1l ;
        }
        v63 += 1l ;
    }
    __syncthreads();
    long v130;
    v130 = threadIdx.x;
    bool v131;
    v131 = 0l <= v130;
    bool v132;
    v132 = v131 == false;
    if (v132){
        assert("The index needs to be zero or positive." && v131);
    } else {
    }
    long v134;
    v134 = v130 % 512l;
    long v135;
    v135 = v130 / 512l;
    bool v136;
    v136 = v135 < 1l;
    bool v137;
    v137 = v136 == false;
    if (v137){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v136);
    } else {
    }
    auto & v139 = v12;
    assert("Tensor range check" && 0 <= v135 && v135 < 1l);
    assert("Tensor range check" && 0 <= v134 && v134 < 512l);
    long v140;
    v140 = 4l * v134;
    long v141;
    v141 = 4096l * v135;
    long v142;
    v142 = v141 + v140;
    assert("Tensor range check" && 0 <= v135 && v135 < 1l);
    long v143;
    v143 = 0l;
    while (while_method_2(v143)){
        assert("Tensor range check" && 0 <= v143 && v143 < 1l);
        long v145;
        v145 = 4096l * v143;
        long v146;
        v146 = v145 + v142;
        float v147[8l];
        long v148[8l];
        long v149;
        v149 = 0l;
        while (while_method_3(v149)){
            assert("Tensor range check" && 0 <= v149 && v149 < 2l);
            long v151;
            v151 = 4l * v149;
            assert("Tensor range check" && 0 <= v149 && v149 < 2l);
            long v152;
            v152 = 2048l * v149;
            long v153;
            v153 = v152 + v146;
            int4* v154;
            v154 = reinterpret_cast<int4*>(v0 + v153);
            int4* v155;
            v155 = reinterpret_cast<int4*>(v147 + v151);
            assert("Pointer alignment check" && (unsigned long long)(v154) % 4l == 0 && (unsigned long long)(v155) % 4l == 0);
            *v155 = *v154;
            v149 += 1l ;
        }
        long v156;
        v156 = 0l;
        while (while_method_3(v156)){
            long v158;
            v158 = 0l;
            while (while_method_1(v158)){
                bool v160;
                v160 = 0l <= v158;
                bool v162;
                if (v160){
                    bool v161;
                    v161 = v158 < 4l;
                    v162 = v161;
                } else {
                    v162 = false;
                }
                bool v163;
                v163 = v162 == false;
                if (v163){
                    assert("The indices should be inside the range of the dimension." && v162);
                } else {
                }
                bool v165;
                v165 = 0l <= v156;
                bool v167;
                if (v165){
                    bool v166;
                    v166 = v156 < 2l;
                    v167 = v166;
                } else {
                    v167 = false;
                }
                bool v168;
                v168 = v167 == false;
                if (v168){
                    assert("The indices should be inside the range of the dimension." && v167);
                } else {
                }
                long v170;
                v170 = v156 * 4l;
                long v171;
                v171 = v158 + v170;
                bool v172;
                v172 = 0l <= v134;
                bool v174;
                if (v172){
                    bool v173;
                    v173 = v134 < 512l;
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
                long v177;
                v177 = v134 * 8l;
                long v178;
                v178 = v171 + v177;
                assert("Tensor range check" && 0 <= v156 && v156 < 2l);
                assert("Tensor range check" && 0 <= v158 && v158 < 4l);
                long v179;
                v179 = 4l * v156;
                long v180;
                v180 = v179 + v158;
                v148[v180] = v178;
                v158 += 1l ;
            }
            v156 += 1l ;
        }
        bool v181;
        v181 = 0l < v135;
        bool v183;
        if (v181){
            bool v182;
            v182 = v135 <= 1l;
            v183 = v182;
        } else {
            v183 = false;
        }
        bool v184;
        v184 = v183 == false;
        if (v184){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v183);
        } else {
        }
        bool v186;
        v186 = 0l < v143;
        bool v188;
        if (v186){
            bool v187;
            v187 = v143 <= 1l;
            v188 = v187;
        } else {
            v188 = false;
        }
        bool v189;
        v189 = v188 == false;
        if (v189){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v188);
        } else {
        }
        long v191;
        v191 = v143 + v135;
        assert("Tensor range check" && 0 <= v143 && v143 < 1l);
        v11[v191] = v191;
        v143 += 1l ;
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
    v196 = v192 % 512l;
    long v197;
    v197 = v192 / 512l;
    bool v198;
    v198 = v197 < 1l;
    bool v199;
    v199 = v198 == false;
    if (v199){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v198);
    } else {
    }
    auto & v201 = v12;
    assert("Tensor range check" && 0 <= v197 && v197 < 1l);
    assert("Tensor range check" && 0 <= v196 && v196 < 512l);
    long v202;
    v202 = 4l * v196;
    long v203;
    v203 = 4096l * v197;
    long v204;
    v204 = v203 + v202;
    assert("Tensor range check" && 0 <= v197 && v197 < 1l);
    assert("Tensor range check" && 0 <= v196 && v196 < 512l);
    long v205;
    v205 = 0l;
    while (while_method_2(v205)){
        assert("Tensor range check" && 0 <= v205 && v205 < 1l);
        long v207;
        v207 = 4096l * v205;
        long v208;
        v208 = v207 + v204;
        assert("Tensor range check" && 0 <= v205 && v205 < 1l);
        float v209[8l];
        long v210[8l];
        long v211;
        v211 = 0l;
        while (while_method_3(v211)){
            assert("Tensor range check" && 0 <= v211 && v211 < 2l);
            long v213;
            v213 = 4l * v211;
            assert("Tensor range check" && 0 <= v211 && v211 < 2l);
            long v214;
            v214 = 2048l * v211;
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
        while (while_method_3(v218)){
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
                    v228 = v218 < 2l;
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
                    v235 = v196 < 512l;
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
                v239 = v196 * 8l;
                long v240;
                v240 = v233 + v239;
                assert("Tensor range check" && 0 <= v218 && v218 < 2l);
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
            v244 = v197 <= 1l;
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
        v253 = v205 + v197;
        float v254;
        v254 = 0.0f;
        long v255;
        v255 = 0l;
        while (while_method_3(v255)){
            long v257;
            v257 = 0l;
            while (while_method_1(v257)){
                assert("Tensor range check" && 0 <= v255 && v255 < 2l);
                assert("Tensor range check" && 0 <= v257 && v257 < 4l);
                long v259;
                v259 = 4l * v255;
                long v260;
                v260 = v259 + v257;
                float v261;
                v261 = v209[v260];
                float v262;
                v262 = v261 + v254;
                v254 = v262;
                v257 += 1l ;
            }
            v255 += 1l ;
        }
        auto v263 = cooperative_groups::coalesced_threads();
        float v264;
        v264 = cooperative_groups::reduce(v263, v254, v37);
        long v265;
        v265 = threadIdx.x;
        long v266;
        v266 = v265 / 32l;
        __shared__ float v267[16l];
        bool v268;
        v268 = 0l <= v266;
        bool v269;
        v269 = v268 == false;
        if (v269){
            assert("The index needs to be zero or positive." && v268);
        } else {
        }
        long v271;
        v271 = v266 % 16l;
        long v272;
        v272 = v266 / 16l;
        bool v273;
        v273 = v272 < 1l;
        bool v274;
        v274 = v273 == false;
        if (v274){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v273);
        } else {
        }
        assert("Tensor range check" && 0 <= v272 && v272 < 1l);
        assert("Tensor range check" && 0 <= v271 && v271 < 16l);
        long v276;
        v276 = 16l * v272;
        long v277;
        v277 = v276 + v271;
        v267[v277] = v264;
        v201.sync() ;
        long v278;
        v278 = threadIdx.x;
        long v279;
        v279 = v278 % 32l;
        bool v280;
        v280 = v279 < 16l;
        float v283;
        if (v280){
            assert("Tensor range check" && 0 <= v272 && v272 < 1l);
            assert("Tensor range check" && 0 <= v279 && v279 < 16l);
            long v281;
            v281 = v276 + v279;
            float v282;
            v282 = v267[v281];
            v283 = v282;
        } else {
            v283 = 0.0f;
        }
        v201.sync() ;
        float v284;
        v284 = cooperative_groups::reduce(v263, v283, v37);
        float v285;
        v285 = v284 / 4096.0f;
        float v286[8l];
        long v287;
        v287 = 0l;
        while (while_method_3(v287)){
            long v289;
            v289 = 0l;
            while (while_method_1(v289)){
                assert("Tensor range check" && 0 <= v287 && v287 < 2l);
                assert("Tensor range check" && 0 <= v289 && v289 < 4l);
                long v291;
                v291 = 4l * v287;
                long v292;
                v292 = v291 + v289;
                float v293;
                v293 = v209[v292];
                float v294;
                v294 = v293 - v285;
                float v295;
                v295 = exp(v294);
                assert("Tensor range check" && 0 <= v287 && v287 < 2l);
                assert("Tensor range check" && 0 <= v289 && v289 < 4l);
                v286[v292] = v295;
                v289 += 1l ;
            }
            v287 += 1l ;
        }
        float v296;
        v296 = 0.0f;
        long v297;
        v297 = 0l;
        while (while_method_3(v297)){
            long v299;
            v299 = 0l;
            while (while_method_1(v299)){
                assert("Tensor range check" && 0 <= v297 && v297 < 2l);
                assert("Tensor range check" && 0 <= v299 && v299 < 4l);
                long v301;
                v301 = 4l * v297;
                long v302;
                v302 = v301 + v299;
                float v303;
                v303 = v286[v302];
                float v304;
                v304 = v303 + v296;
                v296 = v304;
                v299 += 1l ;
            }
            v297 += 1l ;
        }
        auto v305 = cooperative_groups::coalesced_threads();
        float v306;
        v306 = cooperative_groups::reduce(v305, v296, v37);
        long v307;
        v307 = threadIdx.x;
        long v308;
        v308 = v307 / 32l;
        __shared__ float v309[16l];
        bool v310;
        v310 = 0l <= v308;
        bool v311;
        v311 = v310 == false;
        if (v311){
            assert("The index needs to be zero or positive." && v310);
        } else {
        }
        long v313;
        v313 = v308 % 16l;
        long v314;
        v314 = v308 / 16l;
        bool v315;
        v315 = v314 < 1l;
        bool v316;
        v316 = v315 == false;
        if (v316){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v315);
        } else {
        }
        assert("Tensor range check" && 0 <= v314 && v314 < 1l);
        assert("Tensor range check" && 0 <= v313 && v313 < 16l);
        long v318;
        v318 = 16l * v314;
        long v319;
        v319 = v318 + v313;
        v309[v319] = v306;
        v201.sync() ;
        long v320;
        v320 = threadIdx.x;
        long v321;
        v321 = v320 % 32l;
        bool v322;
        v322 = v321 < 16l;
        float v325;
        if (v322){
            assert("Tensor range check" && 0 <= v314 && v314 < 1l);
            assert("Tensor range check" && 0 <= v321 && v321 < 16l);
            long v323;
            v323 = v318 + v321;
            float v324;
            v324 = v309[v323];
            v325 = v324;
        } else {
            v325 = 0.0f;
        }
        v201.sync() ;
        float v326;
        v326 = cooperative_groups::reduce(v305, v325, v37);
        float v327[8l];
        long v328;
        v328 = 0l;
        while (while_method_3(v328)){
            long v330;
            v330 = 0l;
            while (while_method_1(v330)){
                assert("Tensor range check" && 0 <= v328 && v328 < 2l);
                assert("Tensor range check" && 0 <= v330 && v330 < 4l);
                long v332;
                v332 = 4l * v328;
                long v333;
                v333 = v332 + v330;
                float v334;
                v334 = v286[v333];
                float v335;
                v335 = v334 / v326;
                assert("Tensor range check" && 0 <= v328 && v328 < 2l);
                assert("Tensor range check" && 0 <= v330 && v330 < 4l);
                v327[v333] = v335;
                v330 += 1l ;
            }
            v328 += 1l ;
        }
        long v336;
        v336 = 0l;
        while (while_method_3(v336)){
            assert("Tensor range check" && 0 <= v336 && v336 < 2l);
            long v338;
            v338 = 2048l * v336;
            long v339;
            v339 = v338 + v208;
            assert("Tensor range check" && 0 <= v336 && v336 < 2l);
            long v340;
            v340 = 4l * v336;
            int4* v341;
            v341 = reinterpret_cast<int4*>(v327 + v340);
            int4* v342;
            v342 = reinterpret_cast<int4*>(v3 + v339);
            assert("Pointer alignment check" && (unsigned long long)(v341) % 4l == 0 && (unsigned long long)(v342) % 4l == 0);
            *v342 = *v341;
            v336 += 1l ;
        }
        v205 += 1l ;
    }
    __syncthreads();
    long v343;
    v343 = threadIdx.x;
    bool v344;
    v344 = 0l <= v343;
    bool v345;
    v345 = v344 == false;
    if (v345){
        assert("The index needs to be zero or positive." && v344);
    } else {
    }
    long v347;
    v347 = v343 % 512l;
    long v348;
    v348 = v343 / 512l;
    bool v349;
    v349 = v348 < 1l;
    bool v350;
    v350 = v349 == false;
    if (v350){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v349);
    } else {
    }
    auto & v352 = v12;
    assert("Tensor range check" && 0 <= v348 && v348 < 1l);
    assert("Tensor range check" && 0 <= v347 && v347 < 512l);
    long v353;
    v353 = 4l * v347;
    long v354;
    v354 = 4096l * v348;
    long v355;
    v355 = v354 + v353;
    assert("Tensor range check" && 0 <= v348 && v348 < 1l);
    assert("Tensor range check" && 0 <= v347 && v347 < 512l);
    long v356;
    v356 = 0l;
    while (while_method_2(v356)){
        assert("Tensor range check" && 0 <= v356 && v356 < 1l);
        long v358;
        v358 = 4096l * v356;
        long v359;
        v359 = v358 + v355;
        assert("Tensor range check" && 0 <= v356 && v356 < 1l);
        float v360[8l];
        long v361[8l];
        long v362;
        v362 = 0l;
        while (while_method_3(v362)){
            assert("Tensor range check" && 0 <= v362 && v362 < 2l);
            long v364;
            v364 = 4l * v362;
            assert("Tensor range check" && 0 <= v362 && v362 < 2l);
            long v365;
            v365 = 2048l * v362;
            long v366;
            v366 = v365 + v359;
            int4* v367;
            v367 = reinterpret_cast<int4*>(v0 + v366);
            int4* v368;
            v368 = reinterpret_cast<int4*>(v360 + v364);
            assert("Pointer alignment check" && (unsigned long long)(v367) % 4l == 0 && (unsigned long long)(v368) % 4l == 0);
            *v368 = *v367;
            v362 += 1l ;
        }
        long v369;
        v369 = 0l;
        while (while_method_3(v369)){
            long v371;
            v371 = 0l;
            while (while_method_1(v371)){
                bool v373;
                v373 = 0l <= v371;
                bool v375;
                if (v373){
                    bool v374;
                    v374 = v371 < 4l;
                    v375 = v374;
                } else {
                    v375 = false;
                }
                bool v376;
                v376 = v375 == false;
                if (v376){
                    assert("The indices should be inside the range of the dimension." && v375);
                } else {
                }
                bool v378;
                v378 = 0l <= v369;
                bool v380;
                if (v378){
                    bool v379;
                    v379 = v369 < 2l;
                    v380 = v379;
                } else {
                    v380 = false;
                }
                bool v381;
                v381 = v380 == false;
                if (v381){
                    assert("The indices should be inside the range of the dimension." && v380);
                } else {
                }
                long v383;
                v383 = v369 * 4l;
                long v384;
                v384 = v371 + v383;
                bool v385;
                v385 = 0l <= v347;
                bool v387;
                if (v385){
                    bool v386;
                    v386 = v347 < 512l;
                    v387 = v386;
                } else {
                    v387 = false;
                }
                bool v388;
                v388 = v387 == false;
                if (v388){
                    assert("The indices should be inside the range of the dimension." && v387);
                } else {
                }
                long v390;
                v390 = v347 * 8l;
                long v391;
                v391 = v384 + v390;
                assert("Tensor range check" && 0 <= v369 && v369 < 2l);
                assert("Tensor range check" && 0 <= v371 && v371 < 4l);
                long v392;
                v392 = 4l * v369;
                long v393;
                v393 = v392 + v371;
                v361[v393] = v391;
                v371 += 1l ;
            }
            v369 += 1l ;
        }
        bool v394;
        v394 = 0l < v348;
        bool v396;
        if (v394){
            bool v395;
            v395 = v348 <= 1l;
            v396 = v395;
        } else {
            v396 = false;
        }
        bool v397;
        v397 = v396 == false;
        if (v397){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v396);
        } else {
        }
        bool v399;
        v399 = 0l < v356;
        bool v401;
        if (v399){
            bool v400;
            v400 = v356 <= 1l;
            v401 = v400;
        } else {
            v401 = false;
        }
        bool v402;
        v402 = v401 == false;
        if (v402){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v401);
        } else {
        }
        long v404;
        v404 = v356 + v348;
        float v405[8l];
        long v406;
        v406 = 0l;
        while (while_method_3(v406)){
            long v408;
            v408 = 0l;
            while (while_method_1(v408)){
                assert("Tensor range check" && 0 <= v406 && v406 < 2l);
                assert("Tensor range check" && 0 <= v408 && v408 < 4l);
                long v410;
                v410 = 4l * v406;
                long v411;
                v411 = v410 + v408;
                float v412;
                v412 = v360[v411];
                float v413;
                v413 = v412 * v412;
                assert("Tensor range check" && 0 <= v406 && v406 < 2l);
                assert("Tensor range check" && 0 <= v408 && v408 < 4l);
                v405[v411] = v413;
                v408 += 1l ;
            }
            v406 += 1l ;
        }
        float v414;
        v414 = 0.0f;
        long v415;
        v415 = 0l;
        while (while_method_3(v415)){
            long v417;
            v417 = 0l;
            while (while_method_1(v417)){
                assert("Tensor range check" && 0 <= v415 && v415 < 2l);
                assert("Tensor range check" && 0 <= v417 && v417 < 4l);
                long v419;
                v419 = 4l * v415;
                long v420;
                v420 = v419 + v417;
                float v421;
                v421 = v405[v420];
                float v422;
                v422 = v421 + v414;
                v414 = v422;
                v417 += 1l ;
            }
            v415 += 1l ;
        }
        auto v423 = cooperative_groups::coalesced_threads();
        float v424;
        v424 = cooperative_groups::reduce(v423, v414, v37);
        long v425;
        v425 = threadIdx.x;
        long v426;
        v426 = v425 / 32l;
        __shared__ float v427[16l];
        bool v428;
        v428 = 0l <= v426;
        bool v429;
        v429 = v428 == false;
        if (v429){
            assert("The index needs to be zero or positive." && v428);
        } else {
        }
        long v431;
        v431 = v426 % 16l;
        long v432;
        v432 = v426 / 16l;
        bool v433;
        v433 = v432 < 1l;
        bool v434;
        v434 = v433 == false;
        if (v434){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v433);
        } else {
        }
        assert("Tensor range check" && 0 <= v432 && v432 < 1l);
        assert("Tensor range check" && 0 <= v431 && v431 < 16l);
        long v436;
        v436 = 16l * v432;
        long v437;
        v437 = v436 + v431;
        v427[v437] = v424;
        v352.sync() ;
        long v438;
        v438 = threadIdx.x;
        long v439;
        v439 = v438 % 32l;
        bool v440;
        v440 = v439 < 16l;
        float v443;
        if (v440){
            assert("Tensor range check" && 0 <= v432 && v432 < 1l);
            assert("Tensor range check" && 0 <= v439 && v439 < 16l);
            long v441;
            v441 = v436 + v439;
            float v442;
            v442 = v427[v441];
            v443 = v442;
        } else {
            v443 = 0.0f;
        }
        v352.sync() ;
        float v444;
        v444 = cooperative_groups::reduce(v423, v443, v37);
        float v445[8l];
        long v446;
        v446 = 0l;
        while (while_method_3(v446)){
            long v448;
            v448 = 0l;
            while (while_method_1(v448)){
                assert("Tensor range check" && 0 <= v446 && v446 < 2l);
                assert("Tensor range check" && 0 <= v448 && v448 < 4l);
                long v450;
                v450 = 4l * v446;
                long v451;
                v451 = v450 + v448;
                float v452;
                v452 = v405[v451];
                float v453;
                v453 = v452 / v444;
                assert("Tensor range check" && 0 <= v446 && v446 < 2l);
                assert("Tensor range check" && 0 <= v448 && v448 < 4l);
                v445[v451] = v453;
                v448 += 1l ;
            }
            v446 += 1l ;
        }
        long v454;
        v454 = 0l;
        while (while_method_3(v454)){
            assert("Tensor range check" && 0 <= v454 && v454 < 2l);
            long v456;
            v456 = 2048l * v454;
            long v457;
            v457 = v456 + v359;
            assert("Tensor range check" && 0 <= v454 && v454 < 2l);
            long v458;
            v458 = 4l * v454;
            int4* v459;
            v459 = reinterpret_cast<int4*>(v445 + v458);
            int4* v460;
            v460 = reinterpret_cast<int4*>(v6 + v457);
            assert("Pointer alignment check" && (unsigned long long)(v459) % 4l == 0 && (unsigned long long)(v460) % 4l == 0);
            *v460 = *v459;
            v454 += 1l ;
        }
        v356 += 1l ;
    }
    __syncthreads();
    long v461;
    v461 = threadIdx.x;
    bool v462;
    v462 = 0l <= v461;
    bool v463;
    v463 = v462 == false;
    if (v463){
        assert("The index needs to be zero or positive." && v462);
    } else {
    }
    long v465;
    v465 = v461 % 512l;
    long v466;
    v466 = v461 / 512l;
    bool v467;
    v467 = v466 < 1l;
    bool v468;
    v468 = v467 == false;
    if (v468){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v467);
    } else {
    }
    auto & v470 = v12;
    assert("Tensor range check" && 0 <= v466 && v466 < 1l);
    assert("Tensor range check" && 0 <= v465 && v465 < 512l);
    long v471;
    v471 = 4l * v465;
    long v472;
    v472 = 4096l * v466;
    long v473;
    v473 = v472 + v471;
    assert("Tensor range check" && 0 <= v466 && v466 < 1l);
    long v474;
    v474 = 0l;
    while (while_method_2(v474)){
        assert("Tensor range check" && 0 <= v474 && v474 < 1l);
        long v476;
        v476 = 4096l * v474;
        long v477;
        v477 = v476 + v473;
        float v478[8l];
        long v479[8l];
        long v480;
        v480 = 0l;
        while (while_method_3(v480)){
            assert("Tensor range check" && 0 <= v480 && v480 < 2l);
            long v482;
            v482 = 4l * v480;
            assert("Tensor range check" && 0 <= v480 && v480 < 2l);
            long v483;
            v483 = 2048l * v480;
            long v484;
            v484 = v483 + v477;
            int4* v485;
            v485 = reinterpret_cast<int4*>(v0 + v484);
            int4* v486;
            v486 = reinterpret_cast<int4*>(v478 + v482);
            assert("Pointer alignment check" && (unsigned long long)(v485) % 4l == 0 && (unsigned long long)(v486) % 4l == 0);
            *v486 = *v485;
            v480 += 1l ;
        }
        long v487;
        v487 = 0l;
        while (while_method_3(v487)){
            long v489;
            v489 = 0l;
            while (while_method_1(v489)){
                bool v491;
                v491 = 0l <= v489;
                bool v493;
                if (v491){
                    bool v492;
                    v492 = v489 < 4l;
                    v493 = v492;
                } else {
                    v493 = false;
                }
                bool v494;
                v494 = v493 == false;
                if (v494){
                    assert("The indices should be inside the range of the dimension." && v493);
                } else {
                }
                bool v496;
                v496 = 0l <= v487;
                bool v498;
                if (v496){
                    bool v497;
                    v497 = v487 < 2l;
                    v498 = v497;
                } else {
                    v498 = false;
                }
                bool v499;
                v499 = v498 == false;
                if (v499){
                    assert("The indices should be inside the range of the dimension." && v498);
                } else {
                }
                long v501;
                v501 = v487 * 4l;
                long v502;
                v502 = v489 + v501;
                bool v503;
                v503 = 0l <= v465;
                bool v505;
                if (v503){
                    bool v504;
                    v504 = v465 < 512l;
                    v505 = v504;
                } else {
                    v505 = false;
                }
                bool v506;
                v506 = v505 == false;
                if (v506){
                    assert("The indices should be inside the range of the dimension." && v505);
                } else {
                }
                long v508;
                v508 = v465 * 8l;
                long v509;
                v509 = v502 + v508;
                assert("Tensor range check" && 0 <= v487 && v487 < 2l);
                assert("Tensor range check" && 0 <= v489 && v489 < 4l);
                long v510;
                v510 = 4l * v487;
                long v511;
                v511 = v510 + v489;
                v479[v511] = v509;
                v489 += 1l ;
            }
            v487 += 1l ;
        }
        bool v512;
        v512 = 0l < v466;
        bool v514;
        if (v512){
            bool v513;
            v513 = v466 <= 1l;
            v514 = v513;
        } else {
            v514 = false;
        }
        bool v515;
        v515 = v514 == false;
        if (v515){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v514);
        } else {
        }
        bool v517;
        v517 = 0l < v474;
        bool v519;
        if (v517){
            bool v518;
            v518 = v474 <= 1l;
            v519 = v518;
        } else {
            v519 = false;
        }
        bool v520;
        v520 = v519 == false;
        if (v520){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v519);
        } else {
        }
        long v522;
        v522 = v474 + v466;
        float v523; long v524;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v523 = tmp1.v0; v524 = tmp1.v1;
        long v525;
        v525 = 0l;
        while (while_method_3(v525)){
            long v527;
            v527 = 0l;
            while (while_method_1(v527)){
                assert("Tensor range check" && 0 <= v525 && v525 < 2l);
                assert("Tensor range check" && 0 <= v527 && v527 < 4l);
                long v529;
                v529 = 4l * v525;
                long v530;
                v530 = v529 + v527;
                float v531;
                v531 = v478[v530];
                long v532;
                v532 = v479[v530];
                bool v533;
                v533 = v531 > v523;
                float v534; long v535;
                if (v533){
                    v534 = v531; v535 = v532;
                } else {
                    v534 = v523; v535 = v524;
                }
                v523 = v534;
                v524 = v535;
                v527 += 1l ;
            }
            v525 += 1l ;
        }
        auto v536 = cooperative_groups::coalesced_threads();
        Fun1 v537;
        v537 = ClosureMethod1;
        float v538; long v539;
        Tuple1 tmp2 = cooperative_groups::reduce(v536, Tuple1(v523, v524), v537);
        v538 = tmp2.v0; v539 = tmp2.v1;
        long v540;
        v540 = threadIdx.x;
        long v541;
        v541 = v540 / 32l;
        __shared__ float v542[16l];
        __shared__ long v543[16l];
        bool v544;
        v544 = 0l <= v541;
        bool v545;
        v545 = v544 == false;
        if (v545){
            assert("The index needs to be zero or positive." && v544);
        } else {
        }
        long v547;
        v547 = v541 % 16l;
        long v548;
        v548 = v541 / 16l;
        bool v549;
        v549 = v548 < 1l;
        bool v550;
        v550 = v549 == false;
        if (v550){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v549);
        } else {
        }
        assert("Tensor range check" && 0 <= v548 && v548 < 1l);
        assert("Tensor range check" && 0 <= v547 && v547 < 16l);
        long v552;
        v552 = 16l * v548;
        long v553;
        v553 = v552 + v547;
        v542[v553] = v538;
        v543[v553] = v539;
        v470.sync() ;
        long v554;
        v554 = threadIdx.x;
        long v555;
        v555 = v554 % 32l;
        bool v556;
        v556 = v555 < 16l;
        float v560; long v561;
        if (v556){
            assert("Tensor range check" && 0 <= v548 && v548 < 1l);
            assert("Tensor range check" && 0 <= v555 && v555 < 16l);
            long v557;
            v557 = v552 + v555;
            float v558;
            v558 = v542[v557];
            long v559;
            v559 = v543[v557];
            v560 = v558; v561 = v559;
        } else {
            v560 = -1.0f / 0.0f; v561 = 0l;
        }
        v470.sync() ;
        float v562; long v563;
        Tuple1 tmp3 = cooperative_groups::reduce(v536, Tuple1(v560, v561), v537);
        v562 = tmp3.v0; v563 = tmp3.v1;
        assert("Tensor range check" && 0 <= v474 && v474 < 1l);
        v7[v522] = v563;
        v474 += 1l ;
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
    auto & v573 = v12;
    assert("Tensor range check" && 0 <= v569 && v569 < 1l);
    assert("Tensor range check" && 0 <= v568 && v568 < 512l);
    long v574;
    v574 = 4l * v568;
    long v575;
    v575 = 4096l * v569;
    long v576;
    v576 = v575 + v574;
    assert("Tensor range check" && 0 <= v569 && v569 < 1l);
    assert("Tensor range check" && 0 <= v568 && v568 < 512l);
    long v577;
    v577 = 0l;
    while (while_method_2(v577)){
        assert("Tensor range check" && 0 <= v577 && v577 < 1l);
        long v579;
        v579 = 4096l * v577;
        long v580;
        v580 = v579 + v576;
        assert("Tensor range check" && 0 <= v577 && v577 < 1l);
        float v581[8l];
        long v582[8l];
        long v583;
        v583 = 0l;
        while (while_method_3(v583)){
            assert("Tensor range check" && 0 <= v583 && v583 < 2l);
            long v585;
            v585 = 4l * v583;
            assert("Tensor range check" && 0 <= v583 && v583 < 2l);
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
                    v600 = v590 < 2l;
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
                v611 = v568 * 8l;
                long v612;
                v612 = v605 + v611;
                assert("Tensor range check" && 0 <= v590 && v590 < 2l);
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
            v621 = v577 <= 1l;
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
                assert("Tensor range check" && 0 <= v627 && v627 < 2l);
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
        v636 = cooperative_groups::reduce(v635, v626, v37);
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
        v656 = cooperative_groups::reduce(v635, v655, v37);
        float v657;
        v657 = v656 / 4096.0f;
        float v658[8l];
        long v659;
        v659 = 0l;
        while (while_method_3(v659)){
            long v661;
            v661 = 0l;
            while (while_method_1(v661)){
                assert("Tensor range check" && 0 <= v659 && v659 < 2l);
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
                assert("Tensor range check" && 0 <= v659 && v659 < 2l);
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
                assert("Tensor range check" && 0 <= v669 && v669 < 2l);
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
        v678 = cooperative_groups::reduce(v677, v668, v37);
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
        v698 = cooperative_groups::reduce(v677, v697, v37);
        float v699[8l];
        long v700;
        v700 = 0l;
        while (while_method_3(v700)){
            long v702;
            v702 = 0l;
            while (while_method_1(v702)){
                assert("Tensor range check" && 0 <= v700 && v700 < 2l);
                assert("Tensor range check" && 0 <= v702 && v702 < 4l);
                long v704;
                v704 = 4l * v700;
                long v705;
                v705 = v704 + v702;
                float v706;
                v706 = v658[v705];
                float v707;
                v707 = v706 / v698;
                assert("Tensor range check" && 0 <= v700 && v700 < 2l);
                assert("Tensor range check" && 0 <= v702 && v702 < 4l);
                v699[v705] = v707;
                v702 += 1l ;
            }
            v700 += 1l ;
        }
        float v708[8l];
        float v709;
        v709 = 0.0f;
        long v710;
        v710 = 0l;
        while (while_method_3(v710)){
            assert("Tensor range check" && 0 <= v710 && v710 < 2l);
            long v712;
            v712 = 4l * v710;
            assert("Tensor range check" && 0 <= v710 && v710 < 2l);
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
            assert("Tensor range check" && 0 <= v760 && v760 < 2l);
            long v762;
            v762 = 2048l * v760;
            long v763;
            v763 = v762 + v580;
            assert("Tensor range check" && 0 <= v760 && v760 < 2l);
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
    auto & v778 = v12;
    assert("Tensor range check" && 0 <= v774 && v774 < 1l);
    assert("Tensor range check" && 0 <= v773 && v773 < 512l);
    long v779;
    v779 = 4l * v773;
    long v780;
    v780 = 4096l * v774;
    long v781;
    v781 = v780 + v779;
    assert("Tensor range check" && 0 <= v774 && v774 < 1l);
    long v782;
    v782 = 0l;
    while (while_method_2(v782)){
        assert("Tensor range check" && 0 <= v782 && v782 < 1l);
        long v784;
        v784 = 4096l * v782;
        long v785;
        v785 = v784 + v781;
        float v786[8l];
        long v787[8l];
        long v788;
        v788 = 0l;
        while (while_method_3(v788)){
            assert("Tensor range check" && 0 <= v788 && v788 < 2l);
            long v790;
            v790 = 4l * v788;
            assert("Tensor range check" && 0 <= v788 && v788 < 2l);
            long v791;
            v791 = 2048l * v788;
            long v792;
            v792 = v791 + v785;
            int4* v793;
            v793 = reinterpret_cast<int4*>(v0 + v792);
            int4* v794;
            v794 = reinterpret_cast<int4*>(v786 + v790);
            assert("Pointer alignment check" && (unsigned long long)(v793) % 4l == 0 && (unsigned long long)(v794) % 4l == 0);
            *v794 = *v793;
            v788 += 1l ;
        }
        long v795;
        v795 = 0l;
        while (while_method_3(v795)){
            long v797;
            v797 = 0l;
            while (while_method_1(v797)){
                bool v799;
                v799 = 0l <= v797;
                bool v801;
                if (v799){
                    bool v800;
                    v800 = v797 < 4l;
                    v801 = v800;
                } else {
                    v801 = false;
                }
                bool v802;
                v802 = v801 == false;
                if (v802){
                    assert("The indices should be inside the range of the dimension." && v801);
                } else {
                }
                bool v804;
                v804 = 0l <= v795;
                bool v806;
                if (v804){
                    bool v805;
                    v805 = v795 < 2l;
                    v806 = v805;
                } else {
                    v806 = false;
                }
                bool v807;
                v807 = v806 == false;
                if (v807){
                    assert("The indices should be inside the range of the dimension." && v806);
                } else {
                }
                long v809;
                v809 = v795 * 4l;
                long v810;
                v810 = v797 + v809;
                bool v811;
                v811 = 0l <= v773;
                bool v813;
                if (v811){
                    bool v812;
                    v812 = v773 < 512l;
                    v813 = v812;
                } else {
                    v813 = false;
                }
                bool v814;
                v814 = v813 == false;
                if (v814){
                    assert("The indices should be inside the range of the dimension." && v813);
                } else {
                }
                long v816;
                v816 = v773 * 8l;
                long v817;
                v817 = v810 + v816;
                assert("Tensor range check" && 0 <= v795 && v795 < 2l);
                assert("Tensor range check" && 0 <= v797 && v797 < 4l);
                long v818;
                v818 = 4l * v795;
                long v819;
                v819 = v818 + v797;
                v787[v819] = v817;
                v797 += 1l ;
            }
            v795 += 1l ;
        }
        bool v820;
        v820 = 0l < v774;
        bool v822;
        if (v820){
            bool v821;
            v821 = v774 <= 1l;
            v822 = v821;
        } else {
            v822 = false;
        }
        bool v823;
        v823 = v822 == false;
        if (v823){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v822);
        } else {
        }
        bool v825;
        v825 = 0l < v782;
        bool v827;
        if (v825){
            bool v826;
            v826 = v782 <= 1l;
            v827 = v826;
        } else {
            v827 = false;
        }
        bool v828;
        v828 = v827 == false;
        if (v828){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v827);
        } else {
        }
        long v830;
        v830 = v782 + v774;
        float v831;
        v831 = 0.0f;
        long v832;
        v832 = 0l;
        while (while_method_3(v832)){
            long v834;
            v834 = 0l;
            while (while_method_1(v834)){
                assert("Tensor range check" && 0 <= v832 && v832 < 2l);
                assert("Tensor range check" && 0 <= v834 && v834 < 4l);
                long v836;
                v836 = 4l * v832;
                long v837;
                v837 = v836 + v834;
                float v838;
                v838 = v786[v837];
                float v839;
                v839 = v838 + v831;
                v831 = v839;
                v834 += 1l ;
            }
            v832 += 1l ;
        }
        auto v840 = cooperative_groups::coalesced_threads();
        float v841;
        v841 = cooperative_groups::reduce(v840, v831, v37);
        long v842;
        v842 = threadIdx.x;
        long v843;
        v843 = v842 / 32l;
        __shared__ float v844[16l];
        bool v845;
        v845 = 0l <= v843;
        bool v846;
        v846 = v845 == false;
        if (v846){
            assert("The index needs to be zero or positive." && v845);
        } else {
        }
        long v848;
        v848 = v843 % 16l;
        long v849;
        v849 = v843 / 16l;
        bool v850;
        v850 = v849 < 1l;
        bool v851;
        v851 = v850 == false;
        if (v851){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v850);
        } else {
        }
        assert("Tensor range check" && 0 <= v849 && v849 < 1l);
        assert("Tensor range check" && 0 <= v848 && v848 < 16l);
        long v853;
        v853 = 16l * v849;
        long v854;
        v854 = v853 + v848;
        v844[v854] = v841;
        v778.sync() ;
        long v855;
        v855 = threadIdx.x;
        long v856;
        v856 = v855 % 32l;
        bool v857;
        v857 = v856 < 16l;
        float v860;
        if (v857){
            assert("Tensor range check" && 0 <= v849 && v849 < 1l);
            assert("Tensor range check" && 0 <= v856 && v856 < 16l);
            long v858;
            v858 = v853 + v856;
            float v859;
            v859 = v844[v858];
            v860 = v859;
        } else {
            v860 = 0.0f;
        }
        v778.sync() ;
        float v861;
        v861 = cooperative_groups::reduce(v840, v860, v37);
        float v862;
        v862 = v861 / 4096.0f;
        float v863[8l];
        long v864;
        v864 = 0l;
        while (while_method_3(v864)){
            long v866;
            v866 = 0l;
            while (while_method_1(v866)){
                assert("Tensor range check" && 0 <= v864 && v864 < 2l);
                assert("Tensor range check" && 0 <= v866 && v866 < 4l);
                long v868;
                v868 = 4l * v864;
                long v869;
                v869 = v868 + v866;
                float v870;
                v870 = v786[v869];
                float v871;
                v871 = v870 - v862;
                float v872;
                v872 = exp(v871);
                assert("Tensor range check" && 0 <= v864 && v864 < 2l);
                assert("Tensor range check" && 0 <= v866 && v866 < 4l);
                v863[v869] = v872;
                v866 += 1l ;
            }
            v864 += 1l ;
        }
        float v873;
        v873 = 0.0f;
        long v874;
        v874 = 0l;
        while (while_method_3(v874)){
            long v876;
            v876 = 0l;
            while (while_method_1(v876)){
                assert("Tensor range check" && 0 <= v874 && v874 < 2l);
                assert("Tensor range check" && 0 <= v876 && v876 < 4l);
                long v878;
                v878 = 4l * v874;
                long v879;
                v879 = v878 + v876;
                float v880;
                v880 = v863[v879];
                float v881;
                v881 = v880 + v873;
                v873 = v881;
                v876 += 1l ;
            }
            v874 += 1l ;
        }
        auto v882 = cooperative_groups::coalesced_threads();
        float v883;
        v883 = cooperative_groups::reduce(v882, v873, v37);
        long v884;
        v884 = threadIdx.x;
        long v885;
        v885 = v884 / 32l;
        __shared__ float v886[16l];
        bool v887;
        v887 = 0l <= v885;
        bool v888;
        v888 = v887 == false;
        if (v888){
            assert("The index needs to be zero or positive." && v887);
        } else {
        }
        long v890;
        v890 = v885 % 16l;
        long v891;
        v891 = v885 / 16l;
        bool v892;
        v892 = v891 < 1l;
        bool v893;
        v893 = v892 == false;
        if (v893){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v892);
        } else {
        }
        assert("Tensor range check" && 0 <= v891 && v891 < 1l);
        assert("Tensor range check" && 0 <= v890 && v890 < 16l);
        long v895;
        v895 = 16l * v891;
        long v896;
        v896 = v895 + v890;
        v886[v896] = v883;
        v778.sync() ;
        long v897;
        v897 = threadIdx.x;
        long v898;
        v898 = v897 % 32l;
        bool v899;
        v899 = v898 < 16l;
        float v902;
        if (v899){
            assert("Tensor range check" && 0 <= v891 && v891 < 1l);
            assert("Tensor range check" && 0 <= v898 && v898 < 16l);
            long v900;
            v900 = v895 + v898;
            float v901;
            v901 = v886[v900];
            v902 = v901;
        } else {
            v902 = 0.0f;
        }
        v778.sync() ;
        float v903;
        v903 = cooperative_groups::reduce(v882, v902, v37);
        float v904[8l];
        long v905;
        v905 = 0l;
        while (while_method_3(v905)){
            long v907;
            v907 = 0l;
            while (while_method_1(v907)){
                assert("Tensor range check" && 0 <= v905 && v905 < 2l);
                assert("Tensor range check" && 0 <= v907 && v907 < 4l);
                long v909;
                v909 = 4l * v905;
                long v910;
                v910 = v909 + v907;
                float v911;
                v911 = v863[v910];
                float v912;
                v912 = v911 / v903;
                assert("Tensor range check" && 0 <= v905 && v905 < 2l);
                assert("Tensor range check" && 0 <= v907 && v907 < 4l);
                v904[v910] = v912;
                v907 += 1l ;
            }
            v905 += 1l ;
        }
        float v913[8l];
        float v914;
        v914 = 0.0f;
        long v915;
        v915 = 0l;
        while (while_method_3(v915)){
            assert("Tensor range check" && 0 <= v915 && v915 < 2l);
            long v917;
            v917 = 4l * v915;
            assert("Tensor range check" && 0 <= v915 && v915 < 2l);
            long v918; float v919;
            Tuple0 tmp6 = Tuple0(0l, 0.0f);
            v918 = tmp6.v0; v919 = tmp6.v1;
            while (while_method_1(v918)){
                assert("Tensor range check" && 0 <= v918 && v918 < 4l);
                long v921;
                v921 = v918 + v917;
                float v922;
                v922 = v904[v921];
                float v923;
                v923 = v922 + v919;
                v919 = v923;
                v918 += 1l ;
            }
            auto v924 = cooperative_groups::coalesced_threads();
            long v925;
            v925 = threadIdx.x;
            long v926;
            v926 = v925 / 32l;
            __shared__ float v927[16l];
            Fun0 v928;
            v928 = ClosureMethod2;
            float v929;
            v929 = cooperative_groups::inclusive_scan(v924, v919, v928);
            float v930;
            v930 = v924.shfl(v929,v924.num_threads()-1);
            float v931;
            v931 = v924.shfl_up(v929,1);
            bool v932;
            v932 = v924.thread_rank() == 0;
            float v933;
            if (v932){
                v933 = 0.0f;
            } else {
                v933 = v931;
            }
            bool v934;
            v934 = 0l <= v926;
            bool v935;
            v935 = v934 == false;
            if (v935){
                assert("The index needs to be zero or positive." && v934);
            } else {
            }
            long v937;
            v937 = v926 % 16l;
            long v938;
            v938 = v926 / 16l;
            bool v939;
            v939 = v938 < 1l;
            bool v940;
            v940 = v939 == false;
            if (v940){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v939);
            } else {
            }
            assert("Tensor range check" && 0 <= v938 && v938 < 1l);
            assert("Tensor range check" && 0 <= v937 && v937 < 16l);
            long v942;
            v942 = 16l * v938;
            long v943;
            v943 = v942 + v937;
            v927[v943] = v930;
            v778.sync() ;
            long v944;
            v944 = threadIdx.x;
            long v945;
            v945 = v944 % 32l;
            bool v946;
            v946 = v945 < 16l;
            float v949;
            if (v946){
                assert("Tensor range check" && 0 <= v938 && v938 < 1l);
                assert("Tensor range check" && 0 <= v945 && v945 < 16l);
                long v947;
                v947 = v942 + v945;
                float v948;
                v948 = v927[v947];
                v949 = v948;
            } else {
                v949 = 0.0f;
            }
            v778.sync() ;
            float v950;
            v950 = cooperative_groups::inclusive_scan(v924, v949, v928);
            float v951;
            v951 = v924.shfl(v950,v924.num_threads()-1);
            float v952;
            v952 = v924.shfl_up(v950,1);
            bool v953;
            v953 = v924.thread_rank() == 0;
            float v954;
            if (v953){
                v954 = 0.0f;
            } else {
                v954 = v952;
            }
            float v955;
            v955 = v924.shfl(v954,v937);
            float v956;
            v956 = v955 + v933;
            float v957;
            v957 = v914 + v956;
            long v958; float v959;
            Tuple0 tmp7 = Tuple0(0l, v957);
            v958 = tmp7.v0; v959 = tmp7.v1;
            while (while_method_1(v958)){
                assert("Tensor range check" && 0 <= v958 && v958 < 4l);
                long v961;
                v961 = v958 + v917;
                float v962;
                v962 = v904[v961];
                assert("Tensor range check" && 0 <= v958 && v958 < 4l);
                v913[v961] = v959;
                float v963;
                v963 = v962 + v959;
                v959 = v963;
                v958 += 1l ;
            }
            float v964;
            v964 = v914 + v951;
            v914 = v964;
            v915 += 1l ;
        }
        assert("Tensor range check" && 0 <= v830 && v830 < 1l);
        float v965;
        v965 = v1[v830];
        float v966[8l];
        long v967;
        v967 = 0l;
        while (while_method_3(v967)){
            long v969;
            v969 = 0l;
            while (while_method_1(v969)){
                assert("Tensor range check" && 0 <= v967 && v967 < 2l);
                assert("Tensor range check" && 0 <= v969 && v969 < 4l);
                long v971;
                v971 = 4l * v967;
                long v972;
                v972 = v971 + v969;
                float v973;
                v973 = v913[v972];
                float v974;
                v974 = v973 - v965;
                assert("Tensor range check" && 0 <= v967 && v967 < 2l);
                assert("Tensor range check" && 0 <= v969 && v969 < 4l);
                v966[v972] = v974;
                v969 += 1l ;
            }
            v967 += 1l ;
        }
        float v975; long v976;
        Tuple1 tmp8 = Tuple1(-1.0f / 0.0f, 0l);
        v975 = tmp8.v0; v976 = tmp8.v1;
        long v977;
        v977 = 0l;
        while (while_method_3(v977)){
            long v979;
            v979 = 0l;
            while (while_method_1(v979)){
                assert("Tensor range check" && 0 <= v977 && v977 < 2l);
                assert("Tensor range check" && 0 <= v979 && v979 < 4l);
                long v981;
                v981 = 4l * v977;
                long v982;
                v982 = v981 + v979;
                float v983;
                v983 = v966[v982];
                long v984;
                v984 = v787[v982];
                bool v985;
                v985 = v983 >= 0.0f;
                bool v987;
                if (v985){
                    bool v986;
                    v986 = v975 >= 0.0f;
                    v987 = v986;
                } else {
                    v987 = false;
                }
                float v996; long v997;
                if (v987){
                    bool v988;
                    v988 = v983 <= v975;
                    if (v988){
                        v996 = v983; v997 = v984;
                    } else {
                        v996 = v975; v997 = v976;
                    }
                } else {
                    if (v985){
                        v996 = v983; v997 = v984;
                    } else {
                        bool v991;
                        v991 = v975 >= 0.0f;
                        if (v991){
                            v996 = v975; v997 = v976;
                        } else {
                            v996 = v983; v997 = v984;
                        }
                    }
                }
                v975 = v996;
                v976 = v997;
                v979 += 1l ;
            }
            v977 += 1l ;
        }
        auto v998 = cooperative_groups::coalesced_threads();
        Fun1 v999;
        v999 = ClosureMethod3;
        float v1000; long v1001;
        Tuple1 tmp9 = cooperative_groups::reduce(v998, Tuple1(v975, v976), v999);
        v1000 = tmp9.v0; v1001 = tmp9.v1;
        long v1002;
        v1002 = threadIdx.x;
        long v1003;
        v1003 = v1002 / 32l;
        __shared__ float v1004[16l];
        __shared__ long v1005[16l];
        bool v1006;
        v1006 = 0l <= v1003;
        bool v1007;
        v1007 = v1006 == false;
        if (v1007){
            assert("The index needs to be zero or positive." && v1006);
        } else {
        }
        long v1009;
        v1009 = v1003 % 16l;
        long v1010;
        v1010 = v1003 / 16l;
        bool v1011;
        v1011 = v1010 < 1l;
        bool v1012;
        v1012 = v1011 == false;
        if (v1012){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v1011);
        } else {
        }
        assert("Tensor range check" && 0 <= v1010 && v1010 < 1l);
        assert("Tensor range check" && 0 <= v1009 && v1009 < 16l);
        long v1014;
        v1014 = 16l * v1010;
        long v1015;
        v1015 = v1014 + v1009;
        v1004[v1015] = v1000;
        v1005[v1015] = v1001;
        v778.sync() ;
        long v1016;
        v1016 = threadIdx.x;
        long v1017;
        v1017 = v1016 % 32l;
        bool v1018;
        v1018 = v1017 < 16l;
        float v1022; long v1023;
        if (v1018){
            assert("Tensor range check" && 0 <= v1010 && v1010 < 1l);
            assert("Tensor range check" && 0 <= v1017 && v1017 < 16l);
            long v1019;
            v1019 = v1014 + v1017;
            float v1020;
            v1020 = v1004[v1019];
            long v1021;
            v1021 = v1005[v1019];
            v1022 = v1020; v1023 = v1021;
        } else {
            v1022 = -1.0f / 0.0f; v1023 = 0l;
        }
        v778.sync() ;
        float v1024; long v1025;
        Tuple1 tmp10 = cooperative_groups::reduce(v998, Tuple1(v1022, v1023), v999);
        v1024 = tmp10.v0; v1025 = tmp10.v1;
        assert("Tensor range check" && 0 <= v782 && v782 < 1l);
        v8[v830] = v1025;
        v782 += 1l ;
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
    v1 = v0 < 1
    del v0
    return v1
def method1(v0 : i32) -> bool:
    v1 = v0 < 4096
    del v0
    return v1
def main():
    v0 = cp.random.normal(0.0,1.0,4096,dtype=cp.float32)
    v1 = v0.size
    v2 = 4096 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.uniform(size=1,dtype=cp.float32)
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
    pass
    v10 = cp.empty(1,dtype=cp.float32)
    pass
    v11 = cp.empty(4096,dtype=cp.float32)
    pass
    v12 = cp.empty(4096,dtype=cp.float32)
    v13 = cp.empty(4096,dtype=cp.float32)
    pass
    v14 = cp.empty(4096,dtype=cp.float32)
    pass
    v15 = cp.empty(1,dtype=cp.int32)
    pass
    v16 = cp.empty(1,dtype=cp.int32)
    pass
    v17 = cp.empty(4096,dtype=cp.int32)
    v18 = cp.empty(4096,dtype=cp.int32)
    pass
    v19 = cp.empty(1,dtype=cp.int32)
    v20 = 0
    v21 = raw_module.get_function(f"entry{v20}")
    del v20
    v21.max_dynamic_shared_size_bytes = 0 
    v21((1,),(512,),(v0, v5, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19),shared_mem=0)
    del v0, v5, v10, v11, v12, v13, v14, v15, v16, v21
    v22 = 0
    print('[', end="")
    v24 = 0
    while method0(v24):
        v26 = v22
        v27 = v26 >= 4096
        del v26
        if v27:
            v30 = " ..."
            print(v30, end="")
            del v30
            break
        else:
            pass
        del v27
        v31 = v24 == 0
        v32 = v31 != True
        del v31
        if v32:
            v35 = "; "
            print(v35, end="")
            del v35
        else:
            pass
        del v32
        print('[', end="")
        v37 = 0
        while method1(v37):
            v39 = v22
            v40 = v39 >= 4096
            del v39
            if v40:
                v43 = " ..."
                print(v43, end="")
                del v43
                break
            else:
                pass
            del v40
            v44 = v37 == 0
            v45 = v44 != True
            del v44
            if v45:
                v48 = "; "
                print(v48, end="")
                del v48
            else:
                pass
            del v45
            v49 = v22 + 1
            v22 = v49
            del v49
            v50 = v24 * 4096
            v51 = v50 + v37
            del v50
            v52 = v17[v51].item()
            v53 = v18[v51].item()
            del v51
            print(v52, end="")
            del v52
            v57 = ", "
            print(v57, end="")
            del v57
            print(v53, end="")
            del v53
            v37 += 1 
        del v37
        print(']', end="")
        v24 += 1 
    del v17, v18, v22, v24
    print(']', end="")
    print()
    v61 = 0
    print('[', end="")
    v63 = 0
    while method0(v63):
        v65 = v61
        v66 = v65 >= 4096
        del v65
        if v66:
            v69 = " ..."
            print(v69, end="")
            del v69
            break
        else:
            pass
        del v66
        v70 = v63 == 0
        v71 = v70 != True
        del v70
        if v71:
            v74 = "; "
            print(v74, end="")
            del v74
        else:
            pass
        del v71
        v75 = v61 + 1
        v61 = v75
        del v75
        v76 = v19[v63].item()
        print(v76, end="")
        del v76
        v63 += 1 
    del v19, v61, v63
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
