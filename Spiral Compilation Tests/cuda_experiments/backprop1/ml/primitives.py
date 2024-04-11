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
extern "C" __global__ void entry0(long * v0, float * v1, float * v2, float * v3, float * v4, float * v5, float * v6, float * v7, long * v8, long * v9, long * v10, long * v11, long * v12, long * v13) {
    auto v14 = cooperative_groups::this_thread_block();
    float v15;
    v15 = 0.0f;
    long v16;
    v16 = threadIdx.x;
    long v17;
    v17 = v16;
    while (while_method_0(v17)){
        bool v19;
        v19 = 0l <= v17;
        bool v20;
        v20 = v19 == false;
        if (v20){
            assert("The index needs to be zero or positive." && v19);
        } else {
        }
        long v22;
        v22 = v17 % 4l;
        long v23;
        v23 = v17 / 4l;
        bool v24;
        v24 = v23 < 128l;
        bool v25;
        v25 = v24 == false;
        if (v25){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v24);
        } else {
        }
        assert("Tensor range check" && 0 <= v23 && v23 < 128l);
        assert("Tensor range check" && 0 <= v22 && v22 < 4l);
        long v27;
        v27 = 4l * v22;
        long v28;
        v28 = 16l * v23;
        long v29;
        v29 = v28 + v27;
        float v30[4l];
        int4* v31;
        v31 = reinterpret_cast<int4*>(v1 + v29);
        int4* v32;
        v32 = reinterpret_cast<int4*>(v30 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v31) % 4l == 0 && (unsigned long long)(v32) % 4l == 0);
        *v32 = *v31;
        long v33; float v34;
        Tuple0 tmp0 = Tuple0(0l, v15);
        v33 = tmp0.v0; v34 = tmp0.v1;
        while (while_method_1(v33)){
            assert("Tensor range check" && 0 <= v33 && v33 < 4l);
            float v36;
            v36 = v30[v33];
            float v37;
            v37 = v36 + v34;
            v34 = v37;
            v33 += 1l ;
        }
        v15 = v34;
        v17 += 512l ;
    }
    auto v38 = cooperative_groups::coalesced_threads();
    Fun0 v39;
    v39 = ClosureMethod0;
    float v40;
    v40 = cooperative_groups::reduce(v38, v15, v39);
    long v41;
    v41 = threadIdx.x;
    long v42;
    v42 = v41 / 32l;
    __shared__ float v43[16l];
    assert("Tensor range check" && 0 <= v42 && v42 < 16l);
    v43[v42] = v40;
    __syncthreads();
    long v44;
    v44 = threadIdx.x;
    long v45;
    v45 = v44 % 32l;
    bool v46;
    v46 = v42 == 0l;
    bool v48;
    if (v46){
        bool v47;
        v47 = v45 < 16l;
        v48 = v47;
    } else {
        v48 = false;
    }
    if (v48){
        auto v49 = cooperative_groups::coalesced_threads();
        assert("Tensor range check" && 0 <= v45 && v45 < 16l);
        float v50;
        v50 = v43[v45];
        float v51;
        v51 = cooperative_groups::reduce(v49, v50, v39);
        v3[0l] = v51;
    } else {
    }
    __syncthreads();
    long v52;
    v52 = threadIdx.x;
    bool v53;
    v53 = 0l <= v52;
    bool v54;
    v54 = v53 == false;
    if (v54){
        assert("The index needs to be zero or positive." && v53);
    } else {
    }
    long v56;
    v56 = v52 % 4l;
    long v57;
    v57 = v52 / 4l;
    bool v58;
    v58 = v57 < 128l;
    bool v59;
    v59 = v58 == false;
    if (v59){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v58);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v61 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v57 && v57 < 128l);
    assert("Tensor range check" && 0 <= v56 && v56 < 4l);
    long v62;
    v62 = 4l * v56;
    long v63;
    v63 = 16l * v57;
    long v64;
    v64 = v63 + v62;
    assert("Tensor range check" && 0 <= v57 && v57 < 128l);
    assert("Tensor range check" && 0 <= v56 && v56 < 4l);
    long v65;
    v65 = 0l;
    while (while_method_2(v65)){
        assert("Tensor range check" && 0 <= v65 && v65 < 1l);
        long v67;
        v67 = 2048l * v65;
        long v68;
        v68 = v67 + v64;
        assert("Tensor range check" && 0 <= v65 && v65 < 1l);
        long v69[4l];
        long v70[4l];
        long v71;
        v71 = 0l;
        while (while_method_2(v71)){
            assert("Tensor range check" && 0 <= v71 && v71 < 1l);
            long v73;
            v73 = 4l * v71;
            assert("Tensor range check" && 0 <= v71 && v71 < 1l);
            long v74;
            v74 = 16l * v71;
            long v75;
            v75 = v74 + v68;
            int4* v76;
            v76 = reinterpret_cast<int4*>(v0 + v75);
            int4* v77;
            v77 = reinterpret_cast<int4*>(v69 + v73);
            assert("Pointer alignment check" && (unsigned long long)(v76) % 4l == 0 && (unsigned long long)(v77) % 4l == 0);
            *v77 = *v76;
            v71 += 1l ;
        }
        long v78;
        v78 = 0l;
        while (while_method_2(v78)){
            long v80;
            v80 = 0l;
            while (while_method_1(v80)){
                bool v82;
                v82 = 0l <= v80;
                bool v84;
                if (v82){
                    bool v83;
                    v83 = v80 < 4l;
                    v84 = v83;
                } else {
                    v84 = false;
                }
                bool v85;
                v85 = v84 == false;
                if (v85){
                    assert("The indices should be inside the range of the dimension." && v84);
                } else {
                }
                bool v87;
                v87 = 0l <= v56;
                bool v89;
                if (v87){
                    bool v88;
                    v88 = v56 < 4l;
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
                v92 = v56 * 4l;
                long v93;
                v93 = v80 + v92;
                bool v94;
                v94 = 0l <= v78;
                bool v96;
                if (v94){
                    bool v95;
                    v95 = v78 < 1l;
                    v96 = v95;
                } else {
                    v96 = false;
                }
                bool v97;
                v97 = v96 == false;
                if (v97){
                    assert("The indices should be inside the range of the dimension." && v96);
                } else {
                }
                long v99;
                v99 = v78 * 16l;
                long v100;
                v100 = v93 + v99;
                assert("Tensor range check" && 0 <= v78 && v78 < 1l);
                assert("Tensor range check" && 0 <= v80 && v80 < 4l);
                long v101;
                v101 = 4l * v78;
                long v102;
                v102 = v101 + v80;
                v70[v102] = v100;
                v80 += 1l ;
            }
            v78 += 1l ;
        }
        bool v103;
        v103 = 0l < v57;
        bool v105;
        if (v103){
            bool v104;
            v104 = v57 <= 128l;
            v105 = v104;
        } else {
            v105 = false;
        }
        bool v106;
        v106 = v105 == false;
        if (v106){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v105);
        } else {
        }
        bool v108;
        v108 = 0l < v65;
        bool v110;
        if (v108){
            bool v109;
            v109 = v65 <= 1l;
            v110 = v109;
        } else {
            v110 = false;
        }
        bool v111;
        v111 = v110 == false;
        if (v111){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v110);
        } else {
        }
        long v113;
        v113 = v65 * 128l;
        long v114;
        v114 = v113 + v57;
        long v115;
        v115 = 0l;
        while (while_method_2(v115)){
            assert("Tensor range check" && 0 <= v115 && v115 < 1l);
            long v117;
            v117 = 16l * v115;
            long v118;
            v118 = v117 + v68;
            assert("Tensor range check" && 0 <= v115 && v115 < 1l);
            long v119;
            v119 = 4l * v115;
            int4* v120;
            v120 = reinterpret_cast<int4*>(v69 + v119);
            int4* v121;
            v121 = reinterpret_cast<int4*>(v10 + v118);
            assert("Pointer alignment check" && (unsigned long long)(v120) % 4l == 0 && (unsigned long long)(v121) % 4l == 0);
            *v121 = *v120;
            v115 += 1l ;
        }
        v65 += 1l ;
    }
    __syncthreads();
    long v122;
    v122 = threadIdx.x;
    bool v123;
    v123 = 0l <= v122;
    bool v124;
    v124 = v123 == false;
    if (v124){
        assert("The index needs to be zero or positive." && v123);
    } else {
    }
    long v126;
    v126 = v122 % 4l;
    long v127;
    v127 = v122 / 4l;
    bool v128;
    v128 = v127 < 128l;
    bool v129;
    v129 = v128 == false;
    if (v129){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v128);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v131 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v127 && v127 < 128l);
    assert("Tensor range check" && 0 <= v126 && v126 < 4l);
    long v132;
    v132 = 4l * v126;
    long v133;
    v133 = 16l * v127;
    long v134;
    v134 = v133 + v132;
    assert("Tensor range check" && 0 <= v127 && v127 < 128l);
    assert("Tensor range check" && 0 <= v126 && v126 < 4l);
    long v135;
    v135 = 0l;
    while (while_method_2(v135)){
        assert("Tensor range check" && 0 <= v135 && v135 < 1l);
        long v137;
        v137 = 2048l * v135;
        long v138;
        v138 = v137 + v134;
        assert("Tensor range check" && 0 <= v135 && v135 < 1l);
        float v139[4l];
        long v140[4l];
        long v141;
        v141 = 0l;
        while (while_method_2(v141)){
            assert("Tensor range check" && 0 <= v141 && v141 < 1l);
            long v143;
            v143 = 4l * v141;
            assert("Tensor range check" && 0 <= v141 && v141 < 1l);
            long v144;
            v144 = 16l * v141;
            long v145;
            v145 = v144 + v138;
            int4* v146;
            v146 = reinterpret_cast<int4*>(v1 + v145);
            int4* v147;
            v147 = reinterpret_cast<int4*>(v139 + v143);
            assert("Pointer alignment check" && (unsigned long long)(v146) % 4l == 0 && (unsigned long long)(v147) % 4l == 0);
            *v147 = *v146;
            v141 += 1l ;
        }
        long v148;
        v148 = 0l;
        while (while_method_2(v148)){
            long v150;
            v150 = 0l;
            while (while_method_1(v150)){
                bool v152;
                v152 = 0l <= v150;
                bool v154;
                if (v152){
                    bool v153;
                    v153 = v150 < 4l;
                    v154 = v153;
                } else {
                    v154 = false;
                }
                bool v155;
                v155 = v154 == false;
                if (v155){
                    assert("The indices should be inside the range of the dimension." && v154);
                } else {
                }
                bool v157;
                v157 = 0l <= v126;
                bool v159;
                if (v157){
                    bool v158;
                    v158 = v126 < 4l;
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
                long v162;
                v162 = v126 * 4l;
                long v163;
                v163 = v150 + v162;
                bool v164;
                v164 = 0l <= v148;
                bool v166;
                if (v164){
                    bool v165;
                    v165 = v148 < 1l;
                    v166 = v165;
                } else {
                    v166 = false;
                }
                bool v167;
                v167 = v166 == false;
                if (v167){
                    assert("The indices should be inside the range of the dimension." && v166);
                } else {
                }
                long v169;
                v169 = v148 * 16l;
                long v170;
                v170 = v163 + v169;
                assert("Tensor range check" && 0 <= v148 && v148 < 1l);
                assert("Tensor range check" && 0 <= v150 && v150 < 4l);
                long v171;
                v171 = 4l * v148;
                long v172;
                v172 = v171 + v150;
                v140[v172] = v170;
                v150 += 1l ;
            }
            v148 += 1l ;
        }
        bool v173;
        v173 = 0l < v127;
        bool v175;
        if (v173){
            bool v174;
            v174 = v127 <= 128l;
            v175 = v174;
        } else {
            v175 = false;
        }
        bool v176;
        v176 = v175 == false;
        if (v176){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v175);
        } else {
        }
        bool v178;
        v178 = 0l < v135;
        bool v180;
        if (v178){
            bool v179;
            v179 = v135 <= 1l;
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
        long v183;
        v183 = v135 * 128l;
        long v184;
        v184 = v183 + v127;
        long v185[4l];
        long v186[4l];
        long v187;
        v187 = 0l;
        while (while_method_2(v187)){
            long v189;
            v189 = 0l;
            while (while_method_1(v189)){
                assert("Tensor range check" && 0 <= v187 && v187 < 1l);
                assert("Tensor range check" && 0 <= v189 && v189 < 4l);
                long v191;
                v191 = 4l * v187;
                long v192;
                v192 = v191 + v189;
                long v193;
                v193 = v140[v192];
                assert("Tensor range check" && 0 <= v187 && v187 < 1l);
                assert("Tensor range check" && 0 <= v189 && v189 < 4l);
                v185[v192] = v184;
                v186[v192] = v193;
                v189 += 1l ;
            }
            v187 += 1l ;
        }
        long v194;
        v194 = 0l;
        while (while_method_2(v194)){
            assert("Tensor range check" && 0 <= v194 && v194 < 1l);
            long v196;
            v196 = 16l * v194;
            long v197;
            v197 = v196 + v138;
            assert("Tensor range check" && 0 <= v194 && v194 < 1l);
            long v198;
            v198 = 4l * v194;
            int4* v199;
            v199 = reinterpret_cast<int4*>(v185 + v198);
            int4* v200;
            v200 = reinterpret_cast<int4*>(v11 + v197);
            assert("Pointer alignment check" && (unsigned long long)(v199) % 4l == 0 && (unsigned long long)(v200) % 4l == 0);
            *v200 = *v199;
            int4* v201;
            v201 = reinterpret_cast<int4*>(v186 + v198);
            int4* v202;
            v202 = reinterpret_cast<int4*>(v12 + v197);
            assert("Pointer alignment check" && (unsigned long long)(v201) % 4l == 0 && (unsigned long long)(v202) % 4l == 0);
            *v202 = *v201;
            v194 += 1l ;
        }
        v135 += 1l ;
    }
    __syncthreads();
    long v203;
    v203 = threadIdx.x;
    bool v204;
    v204 = 0l <= v203;
    bool v205;
    v205 = v204 == false;
    if (v205){
        assert("The index needs to be zero or positive." && v204);
    } else {
    }
    long v207;
    v207 = v203 % 4l;
    long v208;
    v208 = v203 / 4l;
    bool v209;
    v209 = v208 < 128l;
    bool v210;
    v210 = v209 == false;
    if (v210){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v209);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v212 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v208 && v208 < 128l);
    assert("Tensor range check" && 0 <= v207 && v207 < 4l);
    long v213;
    v213 = 4l * v207;
    long v214;
    v214 = 16l * v208;
    long v215;
    v215 = v214 + v213;
    assert("Tensor range check" && 0 <= v208 && v208 < 128l);
    long v216;
    v216 = 0l;
    while (while_method_2(v216)){
        assert("Tensor range check" && 0 <= v216 && v216 < 1l);
        long v218;
        v218 = 2048l * v216;
        long v219;
        v219 = v218 + v215;
        float v220[4l];
        long v221[4l];
        long v222;
        v222 = 0l;
        while (while_method_2(v222)){
            assert("Tensor range check" && 0 <= v222 && v222 < 1l);
            long v224;
            v224 = 4l * v222;
            assert("Tensor range check" && 0 <= v222 && v222 < 1l);
            long v225;
            v225 = 16l * v222;
            long v226;
            v226 = v225 + v219;
            int4* v227;
            v227 = reinterpret_cast<int4*>(v1 + v226);
            int4* v228;
            v228 = reinterpret_cast<int4*>(v220 + v224);
            assert("Pointer alignment check" && (unsigned long long)(v227) % 4l == 0 && (unsigned long long)(v228) % 4l == 0);
            *v228 = *v227;
            v222 += 1l ;
        }
        long v229;
        v229 = 0l;
        while (while_method_2(v229)){
            long v231;
            v231 = 0l;
            while (while_method_1(v231)){
                bool v233;
                v233 = 0l <= v231;
                bool v235;
                if (v233){
                    bool v234;
                    v234 = v231 < 4l;
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
                bool v238;
                v238 = 0l <= v229;
                bool v240;
                if (v238){
                    bool v239;
                    v239 = v229 < 1l;
                    v240 = v239;
                } else {
                    v240 = false;
                }
                bool v241;
                v241 = v240 == false;
                if (v241){
                    assert("The indices should be inside the range of the dimension." && v240);
                } else {
                }
                long v243;
                v243 = v229 * 4l;
                long v244;
                v244 = v231 + v243;
                bool v245;
                v245 = 0l <= v207;
                bool v247;
                if (v245){
                    bool v246;
                    v246 = v207 < 4l;
                    v247 = v246;
                } else {
                    v247 = false;
                }
                bool v248;
                v248 = v247 == false;
                if (v248){
                    assert("The indices should be inside the range of the dimension." && v247);
                } else {
                }
                long v250;
                v250 = v207 * 4l;
                long v251;
                v251 = v244 + v250;
                assert("Tensor range check" && 0 <= v229 && v229 < 1l);
                assert("Tensor range check" && 0 <= v231 && v231 < 4l);
                long v252;
                v252 = 4l * v229;
                long v253;
                v253 = v252 + v231;
                v221[v253] = v251;
                v231 += 1l ;
            }
            v229 += 1l ;
        }
        bool v254;
        v254 = 0l < v208;
        bool v256;
        if (v254){
            bool v255;
            v255 = v208 <= 128l;
            v256 = v255;
        } else {
            v256 = false;
        }
        bool v257;
        v257 = v256 == false;
        if (v257){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v256);
        } else {
        }
        bool v259;
        v259 = 0l < v216;
        bool v261;
        if (v259){
            bool v260;
            v260 = v216 <= 1l;
            v261 = v260;
        } else {
            v261 = false;
        }
        bool v262;
        v262 = v261 == false;
        if (v262){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v261);
        } else {
        }
        long v264;
        v264 = v216 * 128l;
        long v265;
        v265 = v264 + v208;
        assert("Tensor range check" && 0 <= v216 && v216 < 1l);
        long v266;
        v266 = 128l * v216;
        long v267;
        v267 = v266 + v208;
        v13[v267] = v265;
        v216 += 1l ;
    }
    __syncthreads();
    long v268;
    v268 = threadIdx.x;
    bool v269;
    v269 = 0l <= v268;
    bool v270;
    v270 = v269 == false;
    if (v270){
        assert("The index needs to be zero or positive." && v269);
    } else {
    }
    long v272;
    v272 = v268 % 4l;
    long v273;
    v273 = v268 / 4l;
    bool v274;
    v274 = v273 < 128l;
    bool v275;
    v275 = v274 == false;
    if (v275){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v274);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v277 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v273 && v273 < 128l);
    assert("Tensor range check" && 0 <= v272 && v272 < 4l);
    long v278;
    v278 = 4l * v272;
    long v279;
    v279 = 16l * v273;
    long v280;
    v280 = v279 + v278;
    assert("Tensor range check" && 0 <= v273 && v273 < 128l);
    assert("Tensor range check" && 0 <= v272 && v272 < 4l);
    long v281;
    v281 = 0l;
    while (while_method_2(v281)){
        assert("Tensor range check" && 0 <= v281 && v281 < 1l);
        long v283;
        v283 = 2048l * v281;
        long v284;
        v284 = v283 + v280;
        assert("Tensor range check" && 0 <= v281 && v281 < 1l);
        float v285[4l];
        long v286[4l];
        long v287;
        v287 = 0l;
        while (while_method_2(v287)){
            assert("Tensor range check" && 0 <= v287 && v287 < 1l);
            long v289;
            v289 = 4l * v287;
            assert("Tensor range check" && 0 <= v287 && v287 < 1l);
            long v290;
            v290 = 16l * v287;
            long v291;
            v291 = v290 + v284;
            int4* v292;
            v292 = reinterpret_cast<int4*>(v1 + v291);
            int4* v293;
            v293 = reinterpret_cast<int4*>(v285 + v289);
            assert("Pointer alignment check" && (unsigned long long)(v292) % 4l == 0 && (unsigned long long)(v293) % 4l == 0);
            *v293 = *v292;
            v287 += 1l ;
        }
        long v294;
        v294 = 0l;
        while (while_method_2(v294)){
            long v296;
            v296 = 0l;
            while (while_method_1(v296)){
                bool v298;
                v298 = 0l <= v296;
                bool v300;
                if (v298){
                    bool v299;
                    v299 = v296 < 4l;
                    v300 = v299;
                } else {
                    v300 = false;
                }
                bool v301;
                v301 = v300 == false;
                if (v301){
                    assert("The indices should be inside the range of the dimension." && v300);
                } else {
                }
                bool v303;
                v303 = 0l <= v272;
                bool v305;
                if (v303){
                    bool v304;
                    v304 = v272 < 4l;
                    v305 = v304;
                } else {
                    v305 = false;
                }
                bool v306;
                v306 = v305 == false;
                if (v306){
                    assert("The indices should be inside the range of the dimension." && v305);
                } else {
                }
                long v308;
                v308 = v272 * 4l;
                long v309;
                v309 = v296 + v308;
                bool v310;
                v310 = 0l <= v294;
                bool v312;
                if (v310){
                    bool v311;
                    v311 = v294 < 1l;
                    v312 = v311;
                } else {
                    v312 = false;
                }
                bool v313;
                v313 = v312 == false;
                if (v313){
                    assert("The indices should be inside the range of the dimension." && v312);
                } else {
                }
                long v315;
                v315 = v294 * 16l;
                long v316;
                v316 = v309 + v315;
                assert("Tensor range check" && 0 <= v294 && v294 < 1l);
                assert("Tensor range check" && 0 <= v296 && v296 < 4l);
                long v317;
                v317 = 4l * v294;
                long v318;
                v318 = v317 + v296;
                v286[v318] = v316;
                v296 += 1l ;
            }
            v294 += 1l ;
        }
        bool v319;
        v319 = 0l < v273;
        bool v321;
        if (v319){
            bool v320;
            v320 = v273 <= 128l;
            v321 = v320;
        } else {
            v321 = false;
        }
        bool v322;
        v322 = v321 == false;
        if (v322){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v321);
        } else {
        }
        bool v324;
        v324 = 0l < v281;
        bool v326;
        if (v324){
            bool v325;
            v325 = v281 <= 1l;
            v326 = v325;
        } else {
            v326 = false;
        }
        bool v327;
        v327 = v326 == false;
        if (v327){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v326);
        } else {
        }
        long v329;
        v329 = v281 * 128l;
        long v330;
        v330 = v329 + v273;
        float v331;
        v331 = 0.0f;
        long v332;
        v332 = 0l;
        while (while_method_2(v332)){
            long v334;
            v334 = 0l;
            while (while_method_1(v334)){
                assert("Tensor range check" && 0 <= v332 && v332 < 1l);
                assert("Tensor range check" && 0 <= v334 && v334 < 4l);
                long v336;
                v336 = 4l * v332;
                long v337;
                v337 = v336 + v334;
                float v338;
                v338 = v285[v337];
                float v339;
                v339 = v338 + v331;
                v331 = v339;
                v334 += 1l ;
            }
            v332 += 1l ;
        }
        Fun0 v340;
        v340 = ClosureMethod1;
        float v341;
        v341 = cooperative_groups::reduce(v277, v331, v340);
        float v342;
        v342 = v341 / 16.0f;
        float v343[4l];
        long v344;
        v344 = 0l;
        while (while_method_2(v344)){
            long v346;
            v346 = 0l;
            while (while_method_1(v346)){
                assert("Tensor range check" && 0 <= v344 && v344 < 1l);
                assert("Tensor range check" && 0 <= v346 && v346 < 4l);
                long v348;
                v348 = 4l * v344;
                long v349;
                v349 = v348 + v346;
                float v350;
                v350 = v285[v349];
                float v351;
                v351 = v350 - v342;
                float v352;
                v352 = exp(v351);
                assert("Tensor range check" && 0 <= v344 && v344 < 1l);
                assert("Tensor range check" && 0 <= v346 && v346 < 4l);
                v343[v349] = v352;
                v346 += 1l ;
            }
            v344 += 1l ;
        }
        float v353;
        v353 = 0.0f;
        long v354;
        v354 = 0l;
        while (while_method_2(v354)){
            long v356;
            v356 = 0l;
            while (while_method_1(v356)){
                assert("Tensor range check" && 0 <= v354 && v354 < 1l);
                assert("Tensor range check" && 0 <= v356 && v356 < 4l);
                long v358;
                v358 = 4l * v354;
                long v359;
                v359 = v358 + v356;
                float v360;
                v360 = v343[v359];
                float v361;
                v361 = v360 + v353;
                v353 = v361;
                v356 += 1l ;
            }
            v354 += 1l ;
        }
        float v362;
        v362 = cooperative_groups::reduce(v277, v353, v340);
        float v363[4l];
        long v364;
        v364 = 0l;
        while (while_method_2(v364)){
            long v366;
            v366 = 0l;
            while (while_method_1(v366)){
                assert("Tensor range check" && 0 <= v364 && v364 < 1l);
                assert("Tensor range check" && 0 <= v366 && v366 < 4l);
                long v368;
                v368 = 4l * v364;
                long v369;
                v369 = v368 + v366;
                float v370;
                v370 = v343[v369];
                float v371;
                v371 = v370 / v362;
                assert("Tensor range check" && 0 <= v364 && v364 < 1l);
                assert("Tensor range check" && 0 <= v366 && v366 < 4l);
                v363[v369] = v371;
                v366 += 1l ;
            }
            v364 += 1l ;
        }
        long v372;
        v372 = 0l;
        while (while_method_2(v372)){
            assert("Tensor range check" && 0 <= v372 && v372 < 1l);
            long v374;
            v374 = 16l * v372;
            long v375;
            v375 = v374 + v284;
            assert("Tensor range check" && 0 <= v372 && v372 < 1l);
            long v376;
            v376 = 4l * v372;
            int4* v377;
            v377 = reinterpret_cast<int4*>(v363 + v376);
            int4* v378;
            v378 = reinterpret_cast<int4*>(v4 + v375);
            assert("Pointer alignment check" && (unsigned long long)(v377) % 4l == 0 && (unsigned long long)(v378) % 4l == 0);
            *v378 = *v377;
            v372 += 1l ;
        }
        v281 += 1l ;
    }
    __syncthreads();
    long v379;
    v379 = threadIdx.x;
    bool v380;
    v380 = 0l <= v379;
    bool v381;
    v381 = v380 == false;
    if (v381){
        assert("The index needs to be zero or positive." && v380);
    } else {
    }
    long v383;
    v383 = v379 % 4l;
    long v384;
    v384 = v379 / 4l;
    bool v385;
    v385 = v384 < 128l;
    bool v386;
    v386 = v385 == false;
    if (v386){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v385);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v388 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v384 && v384 < 128l);
    assert("Tensor range check" && 0 <= v383 && v383 < 4l);
    long v389;
    v389 = 4l * v383;
    long v390;
    v390 = 16l * v384;
    long v391;
    v391 = v390 + v389;
    assert("Tensor range check" && 0 <= v384 && v384 < 128l);
    assert("Tensor range check" && 0 <= v383 && v383 < 4l);
    long v392;
    v392 = 0l;
    while (while_method_2(v392)){
        assert("Tensor range check" && 0 <= v392 && v392 < 1l);
        long v394;
        v394 = 2048l * v392;
        long v395;
        v395 = v394 + v391;
        assert("Tensor range check" && 0 <= v392 && v392 < 1l);
        float v396[4l];
        long v397[4l];
        long v398;
        v398 = 0l;
        while (while_method_2(v398)){
            assert("Tensor range check" && 0 <= v398 && v398 < 1l);
            long v400;
            v400 = 4l * v398;
            assert("Tensor range check" && 0 <= v398 && v398 < 1l);
            long v401;
            v401 = 16l * v398;
            long v402;
            v402 = v401 + v395;
            int4* v403;
            v403 = reinterpret_cast<int4*>(v1 + v402);
            int4* v404;
            v404 = reinterpret_cast<int4*>(v396 + v400);
            assert("Pointer alignment check" && (unsigned long long)(v403) % 4l == 0 && (unsigned long long)(v404) % 4l == 0);
            *v404 = *v403;
            v398 += 1l ;
        }
        long v405;
        v405 = 0l;
        while (while_method_2(v405)){
            long v407;
            v407 = 0l;
            while (while_method_1(v407)){
                bool v409;
                v409 = 0l <= v407;
                bool v411;
                if (v409){
                    bool v410;
                    v410 = v407 < 4l;
                    v411 = v410;
                } else {
                    v411 = false;
                }
                bool v412;
                v412 = v411 == false;
                if (v412){
                    assert("The indices should be inside the range of the dimension." && v411);
                } else {
                }
                bool v414;
                v414 = 0l <= v383;
                bool v416;
                if (v414){
                    bool v415;
                    v415 = v383 < 4l;
                    v416 = v415;
                } else {
                    v416 = false;
                }
                bool v417;
                v417 = v416 == false;
                if (v417){
                    assert("The indices should be inside the range of the dimension." && v416);
                } else {
                }
                long v419;
                v419 = v383 * 4l;
                long v420;
                v420 = v407 + v419;
                bool v421;
                v421 = 0l <= v405;
                bool v423;
                if (v421){
                    bool v422;
                    v422 = v405 < 1l;
                    v423 = v422;
                } else {
                    v423 = false;
                }
                bool v424;
                v424 = v423 == false;
                if (v424){
                    assert("The indices should be inside the range of the dimension." && v423);
                } else {
                }
                long v426;
                v426 = v405 * 16l;
                long v427;
                v427 = v420 + v426;
                assert("Tensor range check" && 0 <= v405 && v405 < 1l);
                assert("Tensor range check" && 0 <= v407 && v407 < 4l);
                long v428;
                v428 = 4l * v405;
                long v429;
                v429 = v428 + v407;
                v397[v429] = v427;
                v407 += 1l ;
            }
            v405 += 1l ;
        }
        bool v430;
        v430 = 0l < v384;
        bool v432;
        if (v430){
            bool v431;
            v431 = v384 <= 128l;
            v432 = v431;
        } else {
            v432 = false;
        }
        bool v433;
        v433 = v432 == false;
        if (v433){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v432);
        } else {
        }
        bool v435;
        v435 = 0l < v392;
        bool v437;
        if (v435){
            bool v436;
            v436 = v392 <= 1l;
            v437 = v436;
        } else {
            v437 = false;
        }
        bool v438;
        v438 = v437 == false;
        if (v438){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v437);
        } else {
        }
        long v440;
        v440 = v392 * 128l;
        long v441;
        v441 = v440 + v384;
        float v442[4l];
        long v443;
        v443 = 0l;
        while (while_method_2(v443)){
            long v445;
            v445 = 0l;
            while (while_method_1(v445)){
                assert("Tensor range check" && 0 <= v443 && v443 < 1l);
                assert("Tensor range check" && 0 <= v445 && v445 < 4l);
                long v447;
                v447 = 4l * v443;
                long v448;
                v448 = v447 + v445;
                float v449;
                v449 = v396[v448];
                float v450;
                v450 = v449 * v449;
                assert("Tensor range check" && 0 <= v443 && v443 < 1l);
                assert("Tensor range check" && 0 <= v445 && v445 < 4l);
                v442[v448] = v450;
                v445 += 1l ;
            }
            v443 += 1l ;
        }
        float v451;
        v451 = 0.0f;
        long v452;
        v452 = 0l;
        while (while_method_2(v452)){
            long v454;
            v454 = 0l;
            while (while_method_1(v454)){
                assert("Tensor range check" && 0 <= v452 && v452 < 1l);
                assert("Tensor range check" && 0 <= v454 && v454 < 4l);
                long v456;
                v456 = 4l * v452;
                long v457;
                v457 = v456 + v454;
                float v458;
                v458 = v442[v457];
                float v459;
                v459 = v458 + v451;
                v451 = v459;
                v454 += 1l ;
            }
            v452 += 1l ;
        }
        Fun0 v460;
        v460 = ClosureMethod1;
        float v461;
        v461 = cooperative_groups::reduce(v388, v451, v460);
        float v462[4l];
        long v463;
        v463 = 0l;
        while (while_method_2(v463)){
            long v465;
            v465 = 0l;
            while (while_method_1(v465)){
                assert("Tensor range check" && 0 <= v463 && v463 < 1l);
                assert("Tensor range check" && 0 <= v465 && v465 < 4l);
                long v467;
                v467 = 4l * v463;
                long v468;
                v468 = v467 + v465;
                float v469;
                v469 = v442[v468];
                float v470;
                v470 = v469 / v461;
                assert("Tensor range check" && 0 <= v463 && v463 < 1l);
                assert("Tensor range check" && 0 <= v465 && v465 < 4l);
                v462[v468] = v470;
                v465 += 1l ;
            }
            v463 += 1l ;
        }
        long v471;
        v471 = 0l;
        while (while_method_2(v471)){
            assert("Tensor range check" && 0 <= v471 && v471 < 1l);
            long v473;
            v473 = 16l * v471;
            long v474;
            v474 = v473 + v395;
            assert("Tensor range check" && 0 <= v471 && v471 < 1l);
            long v475;
            v475 = 4l * v471;
            int4* v476;
            v476 = reinterpret_cast<int4*>(v462 + v475);
            int4* v477;
            v477 = reinterpret_cast<int4*>(v7 + v474);
            assert("Pointer alignment check" && (unsigned long long)(v476) % 4l == 0 && (unsigned long long)(v477) % 4l == 0);
            *v477 = *v476;
            v471 += 1l ;
        }
        v392 += 1l ;
    }
    __syncthreads();
    long v478;
    v478 = threadIdx.x;
    bool v479;
    v479 = 0l <= v478;
    bool v480;
    v480 = v479 == false;
    if (v480){
        assert("The index needs to be zero or positive." && v479);
    } else {
    }
    long v482;
    v482 = v478 % 4l;
    long v483;
    v483 = v478 / 4l;
    bool v484;
    v484 = v483 < 128l;
    bool v485;
    v485 = v484 == false;
    if (v485){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v484);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v487 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v483 && v483 < 128l);
    assert("Tensor range check" && 0 <= v482 && v482 < 4l);
    long v488;
    v488 = 4l * v482;
    long v489;
    v489 = 16l * v483;
    long v490;
    v490 = v489 + v488;
    assert("Tensor range check" && 0 <= v483 && v483 < 128l);
    long v491;
    v491 = 0l;
    while (while_method_2(v491)){
        assert("Tensor range check" && 0 <= v491 && v491 < 1l);
        long v493;
        v493 = 2048l * v491;
        long v494;
        v494 = v493 + v490;
        float v495[4l];
        long v496[4l];
        long v497;
        v497 = 0l;
        while (while_method_2(v497)){
            assert("Tensor range check" && 0 <= v497 && v497 < 1l);
            long v499;
            v499 = 4l * v497;
            assert("Tensor range check" && 0 <= v497 && v497 < 1l);
            long v500;
            v500 = 16l * v497;
            long v501;
            v501 = v500 + v494;
            int4* v502;
            v502 = reinterpret_cast<int4*>(v1 + v501);
            int4* v503;
            v503 = reinterpret_cast<int4*>(v495 + v499);
            assert("Pointer alignment check" && (unsigned long long)(v502) % 4l == 0 && (unsigned long long)(v503) % 4l == 0);
            *v503 = *v502;
            v497 += 1l ;
        }
        long v504;
        v504 = 0l;
        while (while_method_2(v504)){
            long v506;
            v506 = 0l;
            while (while_method_1(v506)){
                bool v508;
                v508 = 0l <= v506;
                bool v510;
                if (v508){
                    bool v509;
                    v509 = v506 < 4l;
                    v510 = v509;
                } else {
                    v510 = false;
                }
                bool v511;
                v511 = v510 == false;
                if (v511){
                    assert("The indices should be inside the range of the dimension." && v510);
                } else {
                }
                bool v513;
                v513 = 0l <= v504;
                bool v515;
                if (v513){
                    bool v514;
                    v514 = v504 < 1l;
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
                long v518;
                v518 = v504 * 4l;
                long v519;
                v519 = v506 + v518;
                bool v520;
                v520 = 0l <= v482;
                bool v522;
                if (v520){
                    bool v521;
                    v521 = v482 < 4l;
                    v522 = v521;
                } else {
                    v522 = false;
                }
                bool v523;
                v523 = v522 == false;
                if (v523){
                    assert("The indices should be inside the range of the dimension." && v522);
                } else {
                }
                long v525;
                v525 = v482 * 4l;
                long v526;
                v526 = v519 + v525;
                assert("Tensor range check" && 0 <= v504 && v504 < 1l);
                assert("Tensor range check" && 0 <= v506 && v506 < 4l);
                long v527;
                v527 = 4l * v504;
                long v528;
                v528 = v527 + v506;
                v496[v528] = v526;
                v506 += 1l ;
            }
            v504 += 1l ;
        }
        bool v529;
        v529 = 0l < v483;
        bool v531;
        if (v529){
            bool v530;
            v530 = v483 <= 128l;
            v531 = v530;
        } else {
            v531 = false;
        }
        bool v532;
        v532 = v531 == false;
        if (v532){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v531);
        } else {
        }
        bool v534;
        v534 = 0l < v491;
        bool v536;
        if (v534){
            bool v535;
            v535 = v491 <= 1l;
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
        long v539;
        v539 = v491 * 128l;
        long v540;
        v540 = v539 + v483;
        float v541; long v542;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v541 = tmp1.v0; v542 = tmp1.v1;
        long v543;
        v543 = 0l;
        while (while_method_2(v543)){
            long v545;
            v545 = 0l;
            while (while_method_1(v545)){
                assert("Tensor range check" && 0 <= v543 && v543 < 1l);
                assert("Tensor range check" && 0 <= v545 && v545 < 4l);
                long v547;
                v547 = 4l * v543;
                long v548;
                v548 = v547 + v545;
                float v549;
                v549 = v495[v548];
                long v550;
                v550 = v496[v548];
                bool v551;
                v551 = v549 > v541;
                float v552; long v553;
                if (v551){
                    v552 = v549; v553 = v550;
                } else {
                    v552 = v541; v553 = v542;
                }
                v541 = v552;
                v542 = v553;
                v545 += 1l ;
            }
            v543 += 1l ;
        }
        Fun1 v554;
        v554 = ClosureMethod2;
        float v555; long v556;
        Tuple1 tmp2 = cooperative_groups::reduce(v487, Tuple1(v541, v542), v554);
        v555 = tmp2.v0; v556 = tmp2.v1;
        assert("Tensor range check" && 0 <= v491 && v491 < 1l);
        long v557;
        v557 = 128l * v491;
        long v558;
        v558 = v557 + v483;
        v8[v558] = v556;
        v491 += 1l ;
    }
    __syncthreads();
    long v559;
    v559 = threadIdx.x;
    bool v560;
    v560 = 0l <= v559;
    bool v561;
    v561 = v560 == false;
    if (v561){
        assert("The index needs to be zero or positive." && v560);
    } else {
    }
    long v563;
    v563 = v559 % 4l;
    long v564;
    v564 = v559 / 4l;
    bool v565;
    v565 = v564 < 128l;
    bool v566;
    v566 = v565 == false;
    if (v566){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v565);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v568 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v564 && v564 < 128l);
    assert("Tensor range check" && 0 <= v563 && v563 < 4l);
    long v569;
    v569 = 4l * v563;
    long v570;
    v570 = 16l * v564;
    long v571;
    v571 = v570 + v569;
    assert("Tensor range check" && 0 <= v564 && v564 < 128l);
    assert("Tensor range check" && 0 <= v563 && v563 < 4l);
    long v572;
    v572 = 0l;
    while (while_method_2(v572)){
        assert("Tensor range check" && 0 <= v572 && v572 < 1l);
        long v574;
        v574 = 2048l * v572;
        long v575;
        v575 = v574 + v571;
        assert("Tensor range check" && 0 <= v572 && v572 < 1l);
        float v576[4l];
        long v577[4l];
        long v578;
        v578 = 0l;
        while (while_method_2(v578)){
            assert("Tensor range check" && 0 <= v578 && v578 < 1l);
            long v580;
            v580 = 4l * v578;
            assert("Tensor range check" && 0 <= v578 && v578 < 1l);
            long v581;
            v581 = 16l * v578;
            long v582;
            v582 = v581 + v575;
            int4* v583;
            v583 = reinterpret_cast<int4*>(v1 + v582);
            int4* v584;
            v584 = reinterpret_cast<int4*>(v576 + v580);
            assert("Pointer alignment check" && (unsigned long long)(v583) % 4l == 0 && (unsigned long long)(v584) % 4l == 0);
            *v584 = *v583;
            v578 += 1l ;
        }
        long v585;
        v585 = 0l;
        while (while_method_2(v585)){
            long v587;
            v587 = 0l;
            while (while_method_1(v587)){
                bool v589;
                v589 = 0l <= v587;
                bool v591;
                if (v589){
                    bool v590;
                    v590 = v587 < 4l;
                    v591 = v590;
                } else {
                    v591 = false;
                }
                bool v592;
                v592 = v591 == false;
                if (v592){
                    assert("The indices should be inside the range of the dimension." && v591);
                } else {
                }
                bool v594;
                v594 = 0l <= v563;
                bool v596;
                if (v594){
                    bool v595;
                    v595 = v563 < 4l;
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
                long v599;
                v599 = v563 * 4l;
                long v600;
                v600 = v587 + v599;
                bool v601;
                v601 = 0l <= v585;
                bool v603;
                if (v601){
                    bool v602;
                    v602 = v585 < 1l;
                    v603 = v602;
                } else {
                    v603 = false;
                }
                bool v604;
                v604 = v603 == false;
                if (v604){
                    assert("The indices should be inside the range of the dimension." && v603);
                } else {
                }
                long v606;
                v606 = v585 * 16l;
                long v607;
                v607 = v600 + v606;
                assert("Tensor range check" && 0 <= v585 && v585 < 1l);
                assert("Tensor range check" && 0 <= v587 && v587 < 4l);
                long v608;
                v608 = 4l * v585;
                long v609;
                v609 = v608 + v587;
                v577[v609] = v607;
                v587 += 1l ;
            }
            v585 += 1l ;
        }
        bool v610;
        v610 = 0l < v564;
        bool v612;
        if (v610){
            bool v611;
            v611 = v564 <= 128l;
            v612 = v611;
        } else {
            v612 = false;
        }
        bool v613;
        v613 = v612 == false;
        if (v613){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v612);
        } else {
        }
        bool v615;
        v615 = 0l < v572;
        bool v617;
        if (v615){
            bool v616;
            v616 = v572 <= 1l;
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
        long v620;
        v620 = v572 * 128l;
        long v621;
        v621 = v620 + v564;
        float v622;
        v622 = 0.0f;
        long v623;
        v623 = 0l;
        while (while_method_2(v623)){
            long v625;
            v625 = 0l;
            while (while_method_1(v625)){
                assert("Tensor range check" && 0 <= v623 && v623 < 1l);
                assert("Tensor range check" && 0 <= v625 && v625 < 4l);
                long v627;
                v627 = 4l * v623;
                long v628;
                v628 = v627 + v625;
                float v629;
                v629 = v576[v628];
                float v630;
                v630 = v629 + v622;
                v622 = v630;
                v625 += 1l ;
            }
            v623 += 1l ;
        }
        Fun0 v631;
        v631 = ClosureMethod1;
        float v632;
        v632 = cooperative_groups::reduce(v568, v622, v631);
        float v633;
        v633 = v632 / 16.0f;
        float v634[4l];
        long v635;
        v635 = 0l;
        while (while_method_2(v635)){
            long v637;
            v637 = 0l;
            while (while_method_1(v637)){
                assert("Tensor range check" && 0 <= v635 && v635 < 1l);
                assert("Tensor range check" && 0 <= v637 && v637 < 4l);
                long v639;
                v639 = 4l * v635;
                long v640;
                v640 = v639 + v637;
                float v641;
                v641 = v576[v640];
                float v642;
                v642 = v641 - v633;
                float v643;
                v643 = exp(v642);
                assert("Tensor range check" && 0 <= v635 && v635 < 1l);
                assert("Tensor range check" && 0 <= v637 && v637 < 4l);
                v634[v640] = v643;
                v637 += 1l ;
            }
            v635 += 1l ;
        }
        float v644;
        v644 = 0.0f;
        long v645;
        v645 = 0l;
        while (while_method_2(v645)){
            long v647;
            v647 = 0l;
            while (while_method_1(v647)){
                assert("Tensor range check" && 0 <= v645 && v645 < 1l);
                assert("Tensor range check" && 0 <= v647 && v647 < 4l);
                long v649;
                v649 = 4l * v645;
                long v650;
                v650 = v649 + v647;
                float v651;
                v651 = v634[v650];
                float v652;
                v652 = v651 + v644;
                v644 = v652;
                v647 += 1l ;
            }
            v645 += 1l ;
        }
        float v653;
        v653 = cooperative_groups::reduce(v568, v644, v631);
        float v654[4l];
        long v655;
        v655 = 0l;
        while (while_method_2(v655)){
            long v657;
            v657 = 0l;
            while (while_method_1(v657)){
                assert("Tensor range check" && 0 <= v655 && v655 < 1l);
                assert("Tensor range check" && 0 <= v657 && v657 < 4l);
                long v659;
                v659 = 4l * v655;
                long v660;
                v660 = v659 + v657;
                float v661;
                v661 = v634[v660];
                float v662;
                v662 = v661 / v653;
                assert("Tensor range check" && 0 <= v655 && v655 < 1l);
                assert("Tensor range check" && 0 <= v657 && v657 < 4l);
                v654[v660] = v662;
                v657 += 1l ;
            }
            v655 += 1l ;
        }
        float v663[4l];
        float v664;
        v664 = 0.0f;
        long v665;
        v665 = 0l;
        while (while_method_2(v665)){
            assert("Tensor range check" && 0 <= v665 && v665 < 1l);
            long v667;
            v667 = 4l * v665;
            assert("Tensor range check" && 0 <= v665 && v665 < 1l);
            long v668; float v669;
            Tuple0 tmp3 = Tuple0(0l, 0.0f);
            v668 = tmp3.v0; v669 = tmp3.v1;
            while (while_method_1(v668)){
                assert("Tensor range check" && 0 <= v668 && v668 < 4l);
                long v671;
                v671 = v668 + v667;
                float v672;
                v672 = v654[v671];
                float v673;
                v673 = v672 + v669;
                v669 = v673;
                v668 += 1l ;
            }
            Fun0 v674;
            v674 = ClosureMethod3;
            float v675;
            v675 = cooperative_groups::inclusive_scan(v568, v669, v674);
            float v676;
            v676 = v568.shfl(v675,v568.num_threads()-1);
            bool v677;
            v677 = v568.num_threads() <= 32;
            bool v678;
            v678 = v677 == false;
            if (v678){
                assert("The thread block tile in the exclusive scan has to be less than or equal 32." && v677);
            } else {
            }
            float v680;
            v680 = v568.shfl_up(v675,1);
            bool v681;
            v681 = v568.thread_rank() == 0;
            float v682;
            if (v681){
                v682 = 0.0f;
            } else {
                v682 = v680;
            }
            float v683;
            v683 = v664 + v682;
            long v684; float v685;
            Tuple0 tmp4 = Tuple0(0l, v683);
            v684 = tmp4.v0; v685 = tmp4.v1;
            while (while_method_1(v684)){
                assert("Tensor range check" && 0 <= v684 && v684 < 4l);
                long v687;
                v687 = v684 + v667;
                float v688;
                v688 = v654[v687];
                assert("Tensor range check" && 0 <= v684 && v684 < 4l);
                v663[v687] = v685;
                float v689;
                v689 = v688 + v685;
                v685 = v689;
                v684 += 1l ;
            }
            float v690;
            v690 = v664 + v676;
            v664 = v690;
            v665 += 1l ;
        }
        long v691;
        v691 = 0l;
        while (while_method_2(v691)){
            assert("Tensor range check" && 0 <= v691 && v691 < 1l);
            long v693;
            v693 = 16l * v691;
            long v694;
            v694 = v693 + v575;
            assert("Tensor range check" && 0 <= v691 && v691 < 1l);
            long v695;
            v695 = 4l * v691;
            int4* v696;
            v696 = reinterpret_cast<int4*>(v654 + v695);
            int4* v697;
            v697 = reinterpret_cast<int4*>(v5 + v694);
            assert("Pointer alignment check" && (unsigned long long)(v696) % 4l == 0 && (unsigned long long)(v697) % 4l == 0);
            *v697 = *v696;
            int4* v698;
            v698 = reinterpret_cast<int4*>(v663 + v695);
            int4* v699;
            v699 = reinterpret_cast<int4*>(v6 + v694);
            assert("Pointer alignment check" && (unsigned long long)(v698) % 4l == 0 && (unsigned long long)(v699) % 4l == 0);
            *v699 = *v698;
            v691 += 1l ;
        }
        v572 += 1l ;
    }
    __syncthreads();
    long v700;
    v700 = threadIdx.x;
    bool v701;
    v701 = 0l <= v700;
    bool v702;
    v702 = v701 == false;
    if (v702){
        assert("The index needs to be zero or positive." && v701);
    } else {
    }
    long v704;
    v704 = v700 % 4l;
    long v705;
    v705 = v700 / 4l;
    bool v706;
    v706 = v705 < 128l;
    bool v707;
    v707 = v706 == false;
    if (v707){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v706);
    } else {
    }
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v709 = cooperative_groups::tiled_partition<4l>(v14);
    assert("Tensor range check" && 0 <= v705 && v705 < 128l);
    assert("Tensor range check" && 0 <= v704 && v704 < 4l);
    long v710;
    v710 = 4l * v704;
    long v711;
    v711 = 16l * v705;
    long v712;
    v712 = v711 + v710;
    assert("Tensor range check" && 0 <= v705 && v705 < 128l);
    long v713;
    v713 = 0l;
    while (while_method_2(v713)){
        assert("Tensor range check" && 0 <= v713 && v713 < 1l);
        long v715;
        v715 = 2048l * v713;
        long v716;
        v716 = v715 + v712;
        float v717[4l];
        long v718[4l];
        long v719;
        v719 = 0l;
        while (while_method_2(v719)){
            assert("Tensor range check" && 0 <= v719 && v719 < 1l);
            long v721;
            v721 = 4l * v719;
            assert("Tensor range check" && 0 <= v719 && v719 < 1l);
            long v722;
            v722 = 16l * v719;
            long v723;
            v723 = v722 + v716;
            int4* v724;
            v724 = reinterpret_cast<int4*>(v1 + v723);
            int4* v725;
            v725 = reinterpret_cast<int4*>(v717 + v721);
            assert("Pointer alignment check" && (unsigned long long)(v724) % 4l == 0 && (unsigned long long)(v725) % 4l == 0);
            *v725 = *v724;
            v719 += 1l ;
        }
        long v726;
        v726 = 0l;
        while (while_method_2(v726)){
            long v728;
            v728 = 0l;
            while (while_method_1(v728)){
                bool v730;
                v730 = 0l <= v728;
                bool v732;
                if (v730){
                    bool v731;
                    v731 = v728 < 4l;
                    v732 = v731;
                } else {
                    v732 = false;
                }
                bool v733;
                v733 = v732 == false;
                if (v733){
                    assert("The indices should be inside the range of the dimension." && v732);
                } else {
                }
                bool v735;
                v735 = 0l <= v726;
                bool v737;
                if (v735){
                    bool v736;
                    v736 = v726 < 1l;
                    v737 = v736;
                } else {
                    v737 = false;
                }
                bool v738;
                v738 = v737 == false;
                if (v738){
                    assert("The indices should be inside the range of the dimension." && v737);
                } else {
                }
                long v740;
                v740 = v726 * 4l;
                long v741;
                v741 = v728 + v740;
                bool v742;
                v742 = 0l <= v704;
                bool v744;
                if (v742){
                    bool v743;
                    v743 = v704 < 4l;
                    v744 = v743;
                } else {
                    v744 = false;
                }
                bool v745;
                v745 = v744 == false;
                if (v745){
                    assert("The indices should be inside the range of the dimension." && v744);
                } else {
                }
                long v747;
                v747 = v704 * 4l;
                long v748;
                v748 = v741 + v747;
                assert("Tensor range check" && 0 <= v726 && v726 < 1l);
                assert("Tensor range check" && 0 <= v728 && v728 < 4l);
                long v749;
                v749 = 4l * v726;
                long v750;
                v750 = v749 + v728;
                v718[v750] = v748;
                v728 += 1l ;
            }
            v726 += 1l ;
        }
        bool v751;
        v751 = 0l < v705;
        bool v753;
        if (v751){
            bool v752;
            v752 = v705 <= 128l;
            v753 = v752;
        } else {
            v753 = false;
        }
        bool v754;
        v754 = v753 == false;
        if (v754){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v753);
        } else {
        }
        bool v756;
        v756 = 0l < v713;
        bool v758;
        if (v756){
            bool v757;
            v757 = v713 <= 1l;
            v758 = v757;
        } else {
            v758 = false;
        }
        bool v759;
        v759 = v758 == false;
        if (v759){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v758);
        } else {
        }
        long v761;
        v761 = v713 * 128l;
        long v762;
        v762 = v761 + v705;
        float v763;
        v763 = 0.0f;
        long v764;
        v764 = 0l;
        while (while_method_2(v764)){
            long v766;
            v766 = 0l;
            while (while_method_1(v766)){
                assert("Tensor range check" && 0 <= v764 && v764 < 1l);
                assert("Tensor range check" && 0 <= v766 && v766 < 4l);
                long v768;
                v768 = 4l * v764;
                long v769;
                v769 = v768 + v766;
                float v770;
                v770 = v717[v769];
                float v771;
                v771 = v770 + v763;
                v763 = v771;
                v766 += 1l ;
            }
            v764 += 1l ;
        }
        Fun0 v772;
        v772 = ClosureMethod1;
        float v773;
        v773 = cooperative_groups::reduce(v709, v763, v772);
        float v774;
        v774 = v773 / 16.0f;
        float v775[4l];
        long v776;
        v776 = 0l;
        while (while_method_2(v776)){
            long v778;
            v778 = 0l;
            while (while_method_1(v778)){
                assert("Tensor range check" && 0 <= v776 && v776 < 1l);
                assert("Tensor range check" && 0 <= v778 && v778 < 4l);
                long v780;
                v780 = 4l * v776;
                long v781;
                v781 = v780 + v778;
                float v782;
                v782 = v717[v781];
                float v783;
                v783 = v782 - v774;
                float v784;
                v784 = exp(v783);
                assert("Tensor range check" && 0 <= v776 && v776 < 1l);
                assert("Tensor range check" && 0 <= v778 && v778 < 4l);
                v775[v781] = v784;
                v778 += 1l ;
            }
            v776 += 1l ;
        }
        float v785;
        v785 = 0.0f;
        long v786;
        v786 = 0l;
        while (while_method_2(v786)){
            long v788;
            v788 = 0l;
            while (while_method_1(v788)){
                assert("Tensor range check" && 0 <= v786 && v786 < 1l);
                assert("Tensor range check" && 0 <= v788 && v788 < 4l);
                long v790;
                v790 = 4l * v786;
                long v791;
                v791 = v790 + v788;
                float v792;
                v792 = v775[v791];
                float v793;
                v793 = v792 + v785;
                v785 = v793;
                v788 += 1l ;
            }
            v786 += 1l ;
        }
        float v794;
        v794 = cooperative_groups::reduce(v709, v785, v772);
        float v795[4l];
        long v796;
        v796 = 0l;
        while (while_method_2(v796)){
            long v798;
            v798 = 0l;
            while (while_method_1(v798)){
                assert("Tensor range check" && 0 <= v796 && v796 < 1l);
                assert("Tensor range check" && 0 <= v798 && v798 < 4l);
                long v800;
                v800 = 4l * v796;
                long v801;
                v801 = v800 + v798;
                float v802;
                v802 = v775[v801];
                float v803;
                v803 = v802 / v794;
                assert("Tensor range check" && 0 <= v796 && v796 < 1l);
                assert("Tensor range check" && 0 <= v798 && v798 < 4l);
                v795[v801] = v803;
                v798 += 1l ;
            }
            v796 += 1l ;
        }
        float v804[4l];
        float v805;
        v805 = 0.0f;
        long v806;
        v806 = 0l;
        while (while_method_2(v806)){
            assert("Tensor range check" && 0 <= v806 && v806 < 1l);
            long v808;
            v808 = 4l * v806;
            assert("Tensor range check" && 0 <= v806 && v806 < 1l);
            long v809; float v810;
            Tuple0 tmp5 = Tuple0(0l, 0.0f);
            v809 = tmp5.v0; v810 = tmp5.v1;
            while (while_method_1(v809)){
                assert("Tensor range check" && 0 <= v809 && v809 < 4l);
                long v812;
                v812 = v809 + v808;
                float v813;
                v813 = v795[v812];
                float v814;
                v814 = v813 + v810;
                v810 = v814;
                v809 += 1l ;
            }
            Fun0 v815;
            v815 = ClosureMethod3;
            float v816;
            v816 = cooperative_groups::inclusive_scan(v709, v810, v815);
            float v817;
            v817 = v709.shfl(v816,v709.num_threads()-1);
            bool v818;
            v818 = v709.num_threads() <= 32;
            bool v819;
            v819 = v818 == false;
            if (v819){
                assert("The thread block tile in the exclusive scan has to be less than or equal 32." && v818);
            } else {
            }
            float v821;
            v821 = v709.shfl_up(v816,1);
            bool v822;
            v822 = v709.thread_rank() == 0;
            float v823;
            if (v822){
                v823 = 0.0f;
            } else {
                v823 = v821;
            }
            float v824;
            v824 = v805 + v823;
            long v825; float v826;
            Tuple0 tmp6 = Tuple0(0l, v824);
            v825 = tmp6.v0; v826 = tmp6.v1;
            while (while_method_1(v825)){
                assert("Tensor range check" && 0 <= v825 && v825 < 4l);
                long v828;
                v828 = v825 + v808;
                float v829;
                v829 = v795[v828];
                assert("Tensor range check" && 0 <= v825 && v825 < 4l);
                v804[v828] = v826;
                float v830;
                v830 = v829 + v826;
                v826 = v830;
                v825 += 1l ;
            }
            float v831;
            v831 = v805 + v817;
            v805 = v831;
            v806 += 1l ;
        }
        assert("Tensor range check" && 0 <= v762 && v762 < 128l);
        float v832;
        v832 = v2[v762];
        float v833[4l];
        long v834;
        v834 = 0l;
        while (while_method_2(v834)){
            long v836;
            v836 = 0l;
            while (while_method_1(v836)){
                assert("Tensor range check" && 0 <= v834 && v834 < 1l);
                assert("Tensor range check" && 0 <= v836 && v836 < 4l);
                long v838;
                v838 = 4l * v834;
                long v839;
                v839 = v838 + v836;
                float v840;
                v840 = v804[v839];
                float v841;
                v841 = v840 - v832;
                assert("Tensor range check" && 0 <= v834 && v834 < 1l);
                assert("Tensor range check" && 0 <= v836 && v836 < 4l);
                v833[v839] = v841;
                v836 += 1l ;
            }
            v834 += 1l ;
        }
        float v842; long v843;
        Tuple1 tmp7 = Tuple1(-1.0f / 0.0f, 0l);
        v842 = tmp7.v0; v843 = tmp7.v1;
        long v844;
        v844 = 0l;
        while (while_method_2(v844)){
            long v846;
            v846 = 0l;
            while (while_method_1(v846)){
                assert("Tensor range check" && 0 <= v844 && v844 < 1l);
                assert("Tensor range check" && 0 <= v846 && v846 < 4l);
                long v848;
                v848 = 4l * v844;
                long v849;
                v849 = v848 + v846;
                float v850;
                v850 = v833[v849];
                long v851;
                v851 = v718[v849];
                bool v852;
                v852 = v850 >= 0.0f;
                bool v854;
                if (v852){
                    bool v853;
                    v853 = v842 >= 0.0f;
                    v854 = v853;
                } else {
                    v854 = false;
                }
                float v863; long v864;
                if (v854){
                    bool v855;
                    v855 = v850 <= v842;
                    if (v855){
                        v863 = v850; v864 = v851;
                    } else {
                        v863 = v842; v864 = v843;
                    }
                } else {
                    if (v852){
                        v863 = v850; v864 = v851;
                    } else {
                        bool v858;
                        v858 = v842 >= 0.0f;
                        if (v858){
                            v863 = v842; v864 = v843;
                        } else {
                            v863 = v850; v864 = v851;
                        }
                    }
                }
                v842 = v863;
                v843 = v864;
                v846 += 1l ;
            }
            v844 += 1l ;
        }
        Fun1 v865;
        v865 = ClosureMethod4;
        float v866; long v867;
        Tuple1 tmp8 = cooperative_groups::reduce(v709, Tuple1(v842, v843), v865);
        v866 = tmp8.v0; v867 = tmp8.v1;
        assert("Tensor range check" && 0 <= v713 && v713 < 1l);
        long v868;
        v868 = 128l * v713;
        long v869;
        v869 = v868 + v705;
        v9[v869] = v867;
        v713 += 1l ;
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
    v0 = cp.arange(0,2048,1,dtype=cp.int32)
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
    v5 = cp.random.normal(0.0,1.0,2048,dtype=cp.float32)
    v6 = v5.size
    v7 = 2048 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.uniform(size=128,dtype=cp.float32)
    v11 = v10.size
    v12 = 128 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    pass
    v15 = cp.empty(1,dtype=cp.float32)
    pass
    v16 = cp.empty(2048,dtype=cp.float32)
    pass
    v17 = cp.empty(2048,dtype=cp.float32)
    v18 = cp.empty(2048,dtype=cp.float32)
    pass
    v19 = cp.empty(2048,dtype=cp.float32)
    pass
    v20 = cp.empty(128,dtype=cp.int32)
    pass
    v21 = cp.empty(128,dtype=cp.int32)
    pass
    v22 = cp.empty(2048,dtype=cp.int32)
    pass
    v23 = cp.empty(2048,dtype=cp.int32)
    v24 = cp.empty(2048,dtype=cp.int32)
    pass
    v25 = cp.empty(128,dtype=cp.int32)
    v26 = 0
    v27 = raw_module.get_function(f"entry{v26}")
    del v26
    v27.max_dynamic_shared_size_bytes = 0 
    v27((1,),(512,),(v0, v5, v10, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25),shared_mem=0)
    del v0, v5, v10, v15, v16, v17, v18, v19, v20, v21, v22, v25, v27
    v28 = 0
    print('[', end="")
    v30 = 0
    while method0(v30):
        v32 = v28
        v33 = v32 >= 2048
        del v32
        if v33:
            v36 = " ..."
            print(v36, end="")
            del v36
            break
        else:
            pass
        del v33
        v37 = v30 == 0
        v38 = v37 != True
        del v37
        if v38:
            v41 = "; "
            print(v41, end="")
            del v41
        else:
            pass
        del v38
        print('[', end="")
        v43 = 0
        while method1(v43):
            v45 = v28
            v46 = v45 >= 2048
            del v45
            if v46:
                v49 = " ..."
                print(v49, end="")
                del v49
                break
            else:
                pass
            del v46
            v50 = v43 == 0
            v51 = v50 != True
            del v50
            if v51:
                v54 = "; "
                print(v54, end="")
                del v54
            else:
                pass
            del v51
            v55 = v28 + 1
            v28 = v55
            del v55
            v56 = v30 * 16
            v57 = v56 + v43
            del v56
            v58 = v23[v57].item()
            v59 = v24[v57].item()
            del v57
            print(v58, end="")
            del v58
            v63 = ", "
            print(v63, end="")
            del v63
            print(v59, end="")
            del v59
            v43 += 1 
        del v43
        print(']', end="")
        v30 += 1 
    del v23, v24, v28, v30
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
