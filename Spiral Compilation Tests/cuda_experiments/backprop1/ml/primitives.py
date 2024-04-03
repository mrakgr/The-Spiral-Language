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
    v1 = v0 < 4096l;
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
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
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
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3, float * v4, float * v5, float * v6, long * v7, long * v8) {
    auto v9 = cooperative_groups::this_thread_block();
    float v10;
    v10 = 0.0f;
    long v11;
    v11 = threadIdx.x;
    long v12;
    v12 = v11;
    while (while_method_0(v12)){
        bool v14;
        v14 = 0l <= v12;
        bool v15;
        v15 = v14 == false;
        if (v15){
            assert("The index needs to be zero or positive." && v14);
        } else {
        }
        long v17;
        v17 = v12 % 256l;
        long v18;
        v18 = v12 / 256l;
        bool v19;
        v19 = v18 < 16l;
        bool v20;
        v20 = v19 == false;
        if (v20){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v19);
        } else {
        }
        assert("Tensor range check" && 0 <= v18 && v18 < 16l);
        assert("Tensor range check" && 0 <= v17 && v17 < 256l);
        long v22;
        v22 = 4l * v17;
        long v23;
        v23 = 1024l * v18;
        long v24;
        v24 = v23 + v22;
        float v25[4l];
        int4* v26;
        v26 = reinterpret_cast<int4*>(v0 + v24);
        int4* v27;
        v27 = reinterpret_cast<int4*>(v25 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v26) % 4l == 0 && (unsigned long long)(v27) % 4l == 0);
        *v27 = *v26;
        long v28; float v29;
        Tuple0 tmp0 = Tuple0(0l, v10);
        v28 = tmp0.v0; v29 = tmp0.v1;
        while (while_method_1(v28)){
            assert("Tensor range check" && 0 <= v28 && v28 < 4l);
            float v31;
            v31 = v25[v28];
            float v32;
            v32 = v31 + v29;
            v29 = v32;
            v28 += 1l ;
        }
        v10 = v29;
        v12 += 512l ;
    }
    auto v33 = cooperative_groups::coalesced_threads();
    Fun0 v34;
    v34 = ClosureMethod0;
    float v35;
    v35 = cooperative_groups::reduce(v33, v10, v34);
    long v36;
    v36 = threadIdx.x;
    long v37;
    v37 = v36 / 32l;
    __shared__ float v38[16l];
    assert("Tensor range check" && 0 <= v37 && v37 < 16l);
    v38[v37] = v35;
    __syncthreads();
    long v39;
    v39 = threadIdx.x;
    long v40;
    v40 = v39 % 32l;
    bool v41;
    v41 = v37 == 0l;
    bool v43;
    if (v41){
        bool v42;
        v42 = v40 < 16l;
        v43 = v42;
    } else {
        v43 = false;
    }
    if (v43){
        auto v44 = cooperative_groups::coalesced_threads();
        assert("Tensor range check" && 0 <= v40 && v40 < 16l);
        float v45;
        v45 = v38[v40];
        float v46;
        v46 = cooperative_groups::reduce(v44, v45, v34);
        v2[0l] = v46;
    } else {
    }
    __syncthreads();
    long v47;
    v47 = threadIdx.x;
    bool v48;
    v48 = 0l <= v47;
    bool v49;
    v49 = v48 == false;
    if (v49){
        assert("The index needs to be zero or positive." && v48);
    } else {
    }
    long v51;
    v51 = v47 % 256l;
    long v52;
    v52 = v47 / 256l;
    bool v53;
    v53 = v52 < 2l;
    bool v54;
    v54 = v53 == false;
    if (v54){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v53);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v56 = cooperative_groups::tiled_partition<256l>(v9);
    assert("Tensor range check" && 0 <= v52 && v52 < 2l);
    assert("Tensor range check" && 0 <= v51 && v51 < 256l);
    long v57;
    v57 = 4l * v51;
    long v58;
    v58 = 1024l * v52;
    long v59;
    v59 = v58 + v57;
    assert("Tensor range check" && 0 <= v52 && v52 < 2l);
    assert("Tensor range check" && 0 <= v51 && v51 < 256l);
    long v60;
    v60 = 0l;
    while (while_method_2(v60)){
        assert("Tensor range check" && 0 <= v60 && v60 < 8l);
        long v62;
        v62 = 2048l * v60;
        long v63;
        v63 = v62 + v59;
        assert("Tensor range check" && 0 <= v60 && v60 < 8l);
        float v64[4l];
        long v65[4l];
        long v66;
        v66 = 0l;
        while (while_method_3(v66)){
            assert("Tensor range check" && 0 <= v66 && v66 < 1l);
            long v68;
            v68 = 4l * v66;
            assert("Tensor range check" && 0 <= v66 && v66 < 1l);
            long v69;
            v69 = 1024l * v66;
            long v70;
            v70 = v69 + v63;
            int4* v71;
            v71 = reinterpret_cast<int4*>(v0 + v70);
            int4* v72;
            v72 = reinterpret_cast<int4*>(v64 + v68);
            assert("Pointer alignment check" && (unsigned long long)(v71) % 4l == 0 && (unsigned long long)(v72) % 4l == 0);
            *v72 = *v71;
            v66 += 1l ;
        }
        long v73;
        v73 = 0l;
        while (while_method_3(v73)){
            long v75;
            v75 = 0l;
            while (while_method_1(v75)){
                bool v77;
                v77 = 0l <= v75;
                bool v79;
                if (v77){
                    bool v78;
                    v78 = v75 < 4l;
                    v79 = v78;
                } else {
                    v79 = false;
                }
                bool v80;
                v80 = v79 == false;
                if (v80){
                    assert("The indices should be inside the range of the dimension." && v79);
                } else {
                }
                bool v82;
                v82 = 0l <= v73;
                bool v84;
                if (v82){
                    bool v83;
                    v83 = v73 < 1l;
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
                long v87;
                v87 = v73 * 4l;
                long v88;
                v88 = v75 + v87;
                bool v89;
                v89 = 0l <= v51;
                bool v91;
                if (v89){
                    bool v90;
                    v90 = v51 < 256l;
                    v91 = v90;
                } else {
                    v91 = false;
                }
                bool v92;
                v92 = v91 == false;
                if (v92){
                    assert("The indices should be inside the range of the dimension." && v91);
                } else {
                }
                long v94;
                v94 = v51 * 4l;
                long v95;
                v95 = v88 + v94;
                assert("Tensor range check" && 0 <= v73 && v73 < 1l);
                assert("Tensor range check" && 0 <= v75 && v75 < 4l);
                long v96;
                v96 = 4l * v73;
                long v97;
                v97 = v96 + v75;
                v65[v97] = v95;
                v75 += 1l ;
            }
            v73 += 1l ;
        }
        bool v98;
        v98 = 0l < v52;
        bool v100;
        if (v98){
            bool v99;
            v99 = v52 <= 2l;
            v100 = v99;
        } else {
            v100 = false;
        }
        bool v101;
        v101 = v100 == false;
        if (v101){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v100);
        } else {
        }
        bool v103;
        v103 = 0l < v60;
        bool v105;
        if (v103){
            bool v104;
            v104 = v60 <= 8l;
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
        long v108;
        v108 = v52 * 8l;
        long v109;
        v109 = v108 + v60;
        float v110;
        v110 = 0.0f;
        long v111;
        v111 = 0l;
        while (while_method_3(v111)){
            long v113;
            v113 = 0l;
            while (while_method_1(v113)){
                assert("Tensor range check" && 0 <= v111 && v111 < 1l);
                assert("Tensor range check" && 0 <= v113 && v113 < 4l);
                long v115;
                v115 = 4l * v111;
                long v116;
                v116 = v115 + v113;
                float v117;
                v117 = v64[v116];
                float v118;
                v118 = v117 + v110;
                v110 = v118;
                v113 += 1l ;
            }
            v111 += 1l ;
        }
        auto v119 = cooperative_groups::coalesced_threads();
        float v120;
        v120 = cooperative_groups::reduce(v119, v110, v34);
        long v121;
        v121 = threadIdx.x;
        long v122;
        v122 = v121 / 32l;
        __shared__ float v123[16l];
        bool v124;
        v124 = 0l <= v122;
        bool v125;
        v125 = v124 == false;
        if (v125){
            assert("The index needs to be zero or positive." && v124);
        } else {
        }
        long v127;
        v127 = v122 % 8l;
        long v128;
        v128 = v122 / 8l;
        bool v129;
        v129 = v128 < 2l;
        bool v130;
        v130 = v129 == false;
        if (v130){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v129);
        } else {
        }
        assert("Tensor range check" && 0 <= v128 && v128 < 2l);
        assert("Tensor range check" && 0 <= v127 && v127 < 8l);
        long v132;
        v132 = 8l * v128;
        long v133;
        v133 = v132 + v127;
        v123[v133] = v120;
        v56.sync() ;
        long v134;
        v134 = threadIdx.x;
        long v135;
        v135 = v134 % 32l;
        bool v136;
        v136 = v135 < 8l;
        float v139;
        if (v136){
            assert("Tensor range check" && 0 <= v128 && v128 < 2l);
            assert("Tensor range check" && 0 <= v135 && v135 < 8l);
            long v137;
            v137 = v132 + v135;
            float v138;
            v138 = v123[v137];
            v139 = v138;
        } else {
            v139 = 0.0f;
        }
        v56.sync() ;
        float v140;
        v140 = cooperative_groups::reduce(v119, v139, v34);
        float v141;
        v141 = v140 / 1024.0f;
        float v142[4l];
        long v143;
        v143 = 0l;
        while (while_method_3(v143)){
            long v145;
            v145 = 0l;
            while (while_method_1(v145)){
                assert("Tensor range check" && 0 <= v143 && v143 < 1l);
                assert("Tensor range check" && 0 <= v145 && v145 < 4l);
                long v147;
                v147 = 4l * v143;
                long v148;
                v148 = v147 + v145;
                float v149;
                v149 = v64[v148];
                float v150;
                v150 = v149 - v141;
                float v151;
                v151 = exp(v150);
                assert("Tensor range check" && 0 <= v143 && v143 < 1l);
                assert("Tensor range check" && 0 <= v145 && v145 < 4l);
                v142[v148] = v151;
                v145 += 1l ;
            }
            v143 += 1l ;
        }
        float v152;
        v152 = 0.0f;
        long v153;
        v153 = 0l;
        while (while_method_3(v153)){
            long v155;
            v155 = 0l;
            while (while_method_1(v155)){
                assert("Tensor range check" && 0 <= v153 && v153 < 1l);
                assert("Tensor range check" && 0 <= v155 && v155 < 4l);
                long v157;
                v157 = 4l * v153;
                long v158;
                v158 = v157 + v155;
                float v159;
                v159 = v142[v158];
                float v160;
                v160 = v159 + v152;
                v152 = v160;
                v155 += 1l ;
            }
            v153 += 1l ;
        }
        auto v161 = cooperative_groups::coalesced_threads();
        float v162;
        v162 = cooperative_groups::reduce(v161, v152, v34);
        long v163;
        v163 = threadIdx.x;
        long v164;
        v164 = v163 / 32l;
        __shared__ float v165[16l];
        bool v166;
        v166 = 0l <= v164;
        bool v167;
        v167 = v166 == false;
        if (v167){
            assert("The index needs to be zero or positive." && v166);
        } else {
        }
        long v169;
        v169 = v164 % 8l;
        long v170;
        v170 = v164 / 8l;
        bool v171;
        v171 = v170 < 2l;
        bool v172;
        v172 = v171 == false;
        if (v172){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v171);
        } else {
        }
        assert("Tensor range check" && 0 <= v170 && v170 < 2l);
        assert("Tensor range check" && 0 <= v169 && v169 < 8l);
        long v174;
        v174 = 8l * v170;
        long v175;
        v175 = v174 + v169;
        v165[v175] = v162;
        v56.sync() ;
        long v176;
        v176 = threadIdx.x;
        long v177;
        v177 = v176 % 32l;
        bool v178;
        v178 = v177 < 8l;
        float v181;
        if (v178){
            assert("Tensor range check" && 0 <= v170 && v170 < 2l);
            assert("Tensor range check" && 0 <= v177 && v177 < 8l);
            long v179;
            v179 = v174 + v177;
            float v180;
            v180 = v165[v179];
            v181 = v180;
        } else {
            v181 = 0.0f;
        }
        v56.sync() ;
        float v182;
        v182 = cooperative_groups::reduce(v161, v181, v34);
        float v183[4l];
        long v184;
        v184 = 0l;
        while (while_method_3(v184)){
            long v186;
            v186 = 0l;
            while (while_method_1(v186)){
                assert("Tensor range check" && 0 <= v184 && v184 < 1l);
                assert("Tensor range check" && 0 <= v186 && v186 < 4l);
                long v188;
                v188 = 4l * v184;
                long v189;
                v189 = v188 + v186;
                float v190;
                v190 = v142[v189];
                float v191;
                v191 = v190 / v182;
                assert("Tensor range check" && 0 <= v184 && v184 < 1l);
                assert("Tensor range check" && 0 <= v186 && v186 < 4l);
                v183[v189] = v191;
                v186 += 1l ;
            }
            v184 += 1l ;
        }
        long v192;
        v192 = 0l;
        while (while_method_3(v192)){
            assert("Tensor range check" && 0 <= v192 && v192 < 1l);
            long v194;
            v194 = 1024l * v192;
            long v195;
            v195 = v194 + v63;
            assert("Tensor range check" && 0 <= v192 && v192 < 1l);
            long v196;
            v196 = 4l * v192;
            int4* v197;
            v197 = reinterpret_cast<int4*>(v183 + v196);
            int4* v198;
            v198 = reinterpret_cast<int4*>(v3 + v195);
            assert("Pointer alignment check" && (unsigned long long)(v197) % 4l == 0 && (unsigned long long)(v198) % 4l == 0);
            *v198 = *v197;
            v192 += 1l ;
        }
        v60 += 1l ;
    }
    __syncthreads();
    long v199;
    v199 = threadIdx.x;
    bool v200;
    v200 = 0l <= v199;
    bool v201;
    v201 = v200 == false;
    if (v201){
        assert("The index needs to be zero or positive." && v200);
    } else {
    }
    long v203;
    v203 = v199 % 256l;
    long v204;
    v204 = v199 / 256l;
    bool v205;
    v205 = v204 < 2l;
    bool v206;
    v206 = v205 == false;
    if (v206){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v205);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v208 = cooperative_groups::tiled_partition<256l>(v9);
    assert("Tensor range check" && 0 <= v204 && v204 < 2l);
    assert("Tensor range check" && 0 <= v203 && v203 < 256l);
    long v209;
    v209 = 4l * v203;
    long v210;
    v210 = 1024l * v204;
    long v211;
    v211 = v210 + v209;
    assert("Tensor range check" && 0 <= v204 && v204 < 2l);
    assert("Tensor range check" && 0 <= v203 && v203 < 256l);
    long v212;
    v212 = 0l;
    while (while_method_2(v212)){
        assert("Tensor range check" && 0 <= v212 && v212 < 8l);
        long v214;
        v214 = 2048l * v212;
        long v215;
        v215 = v214 + v211;
        assert("Tensor range check" && 0 <= v212 && v212 < 8l);
        float v216[4l];
        long v217[4l];
        long v218;
        v218 = 0l;
        while (while_method_3(v218)){
            assert("Tensor range check" && 0 <= v218 && v218 < 1l);
            long v220;
            v220 = 4l * v218;
            assert("Tensor range check" && 0 <= v218 && v218 < 1l);
            long v221;
            v221 = 1024l * v218;
            long v222;
            v222 = v221 + v215;
            int4* v223;
            v223 = reinterpret_cast<int4*>(v0 + v222);
            int4* v224;
            v224 = reinterpret_cast<int4*>(v216 + v220);
            assert("Pointer alignment check" && (unsigned long long)(v223) % 4l == 0 && (unsigned long long)(v224) % 4l == 0);
            *v224 = *v223;
            v218 += 1l ;
        }
        long v225;
        v225 = 0l;
        while (while_method_3(v225)){
            long v227;
            v227 = 0l;
            while (while_method_1(v227)){
                bool v229;
                v229 = 0l <= v227;
                bool v231;
                if (v229){
                    bool v230;
                    v230 = v227 < 4l;
                    v231 = v230;
                } else {
                    v231 = false;
                }
                bool v232;
                v232 = v231 == false;
                if (v232){
                    assert("The indices should be inside the range of the dimension." && v231);
                } else {
                }
                bool v234;
                v234 = 0l <= v225;
                bool v236;
                if (v234){
                    bool v235;
                    v235 = v225 < 1l;
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
                v239 = v225 * 4l;
                long v240;
                v240 = v227 + v239;
                bool v241;
                v241 = 0l <= v203;
                bool v243;
                if (v241){
                    bool v242;
                    v242 = v203 < 256l;
                    v243 = v242;
                } else {
                    v243 = false;
                }
                bool v244;
                v244 = v243 == false;
                if (v244){
                    assert("The indices should be inside the range of the dimension." && v243);
                } else {
                }
                long v246;
                v246 = v203 * 4l;
                long v247;
                v247 = v240 + v246;
                assert("Tensor range check" && 0 <= v225 && v225 < 1l);
                assert("Tensor range check" && 0 <= v227 && v227 < 4l);
                long v248;
                v248 = 4l * v225;
                long v249;
                v249 = v248 + v227;
                v217[v249] = v247;
                v227 += 1l ;
            }
            v225 += 1l ;
        }
        bool v250;
        v250 = 0l < v204;
        bool v252;
        if (v250){
            bool v251;
            v251 = v204 <= 2l;
            v252 = v251;
        } else {
            v252 = false;
        }
        bool v253;
        v253 = v252 == false;
        if (v253){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v252);
        } else {
        }
        bool v255;
        v255 = 0l < v212;
        bool v257;
        if (v255){
            bool v256;
            v256 = v212 <= 8l;
            v257 = v256;
        } else {
            v257 = false;
        }
        bool v258;
        v258 = v257 == false;
        if (v258){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v257);
        } else {
        }
        long v260;
        v260 = v204 * 8l;
        long v261;
        v261 = v260 + v212;
        float v262[4l];
        long v263;
        v263 = 0l;
        while (while_method_3(v263)){
            long v265;
            v265 = 0l;
            while (while_method_1(v265)){
                assert("Tensor range check" && 0 <= v263 && v263 < 1l);
                assert("Tensor range check" && 0 <= v265 && v265 < 4l);
                long v267;
                v267 = 4l * v263;
                long v268;
                v268 = v267 + v265;
                float v269;
                v269 = v216[v268];
                float v270;
                v270 = v269 * v269;
                assert("Tensor range check" && 0 <= v263 && v263 < 1l);
                assert("Tensor range check" && 0 <= v265 && v265 < 4l);
                v262[v268] = v270;
                v265 += 1l ;
            }
            v263 += 1l ;
        }
        float v271;
        v271 = 0.0f;
        long v272;
        v272 = 0l;
        while (while_method_3(v272)){
            long v274;
            v274 = 0l;
            while (while_method_1(v274)){
                assert("Tensor range check" && 0 <= v272 && v272 < 1l);
                assert("Tensor range check" && 0 <= v274 && v274 < 4l);
                long v276;
                v276 = 4l * v272;
                long v277;
                v277 = v276 + v274;
                float v278;
                v278 = v262[v277];
                float v279;
                v279 = v278 + v271;
                v271 = v279;
                v274 += 1l ;
            }
            v272 += 1l ;
        }
        auto v280 = cooperative_groups::coalesced_threads();
        float v281;
        v281 = cooperative_groups::reduce(v280, v271, v34);
        long v282;
        v282 = threadIdx.x;
        long v283;
        v283 = v282 / 32l;
        __shared__ float v284[16l];
        bool v285;
        v285 = 0l <= v283;
        bool v286;
        v286 = v285 == false;
        if (v286){
            assert("The index needs to be zero or positive." && v285);
        } else {
        }
        long v288;
        v288 = v283 % 8l;
        long v289;
        v289 = v283 / 8l;
        bool v290;
        v290 = v289 < 2l;
        bool v291;
        v291 = v290 == false;
        if (v291){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v290);
        } else {
        }
        assert("Tensor range check" && 0 <= v289 && v289 < 2l);
        assert("Tensor range check" && 0 <= v288 && v288 < 8l);
        long v293;
        v293 = 8l * v289;
        long v294;
        v294 = v293 + v288;
        v284[v294] = v281;
        v208.sync() ;
        long v295;
        v295 = threadIdx.x;
        long v296;
        v296 = v295 % 32l;
        bool v297;
        v297 = v296 < 8l;
        float v300;
        if (v297){
            assert("Tensor range check" && 0 <= v289 && v289 < 2l);
            assert("Tensor range check" && 0 <= v296 && v296 < 8l);
            long v298;
            v298 = v293 + v296;
            float v299;
            v299 = v284[v298];
            v300 = v299;
        } else {
            v300 = 0.0f;
        }
        v208.sync() ;
        float v301;
        v301 = cooperative_groups::reduce(v280, v300, v34);
        float v302[4l];
        long v303;
        v303 = 0l;
        while (while_method_3(v303)){
            long v305;
            v305 = 0l;
            while (while_method_1(v305)){
                assert("Tensor range check" && 0 <= v303 && v303 < 1l);
                assert("Tensor range check" && 0 <= v305 && v305 < 4l);
                long v307;
                v307 = 4l * v303;
                long v308;
                v308 = v307 + v305;
                float v309;
                v309 = v262[v308];
                float v310;
                v310 = v309 / v301;
                assert("Tensor range check" && 0 <= v303 && v303 < 1l);
                assert("Tensor range check" && 0 <= v305 && v305 < 4l);
                v302[v308] = v310;
                v305 += 1l ;
            }
            v303 += 1l ;
        }
        long v311;
        v311 = 0l;
        while (while_method_3(v311)){
            assert("Tensor range check" && 0 <= v311 && v311 < 1l);
            long v313;
            v313 = 1024l * v311;
            long v314;
            v314 = v313 + v215;
            assert("Tensor range check" && 0 <= v311 && v311 < 1l);
            long v315;
            v315 = 4l * v311;
            int4* v316;
            v316 = reinterpret_cast<int4*>(v302 + v315);
            int4* v317;
            v317 = reinterpret_cast<int4*>(v6 + v314);
            assert("Pointer alignment check" && (unsigned long long)(v316) % 4l == 0 && (unsigned long long)(v317) % 4l == 0);
            *v317 = *v316;
            v311 += 1l ;
        }
        v212 += 1l ;
    }
    __syncthreads();
    long v318;
    v318 = threadIdx.x;
    bool v319;
    v319 = 0l <= v318;
    bool v320;
    v320 = v319 == false;
    if (v320){
        assert("The index needs to be zero or positive." && v319);
    } else {
    }
    long v322;
    v322 = v318 % 256l;
    long v323;
    v323 = v318 / 256l;
    bool v324;
    v324 = v323 < 2l;
    bool v325;
    v325 = v324 == false;
    if (v325){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v324);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v327 = cooperative_groups::tiled_partition<256l>(v9);
    assert("Tensor range check" && 0 <= v323 && v323 < 2l);
    assert("Tensor range check" && 0 <= v322 && v322 < 256l);
    long v328;
    v328 = 4l * v322;
    long v329;
    v329 = 1024l * v323;
    long v330;
    v330 = v329 + v328;
    assert("Tensor range check" && 0 <= v323 && v323 < 2l);
    long v331;
    v331 = 8l * v323;
    long v332;
    v332 = 0l;
    while (while_method_2(v332)){
        assert("Tensor range check" && 0 <= v332 && v332 < 8l);
        long v334;
        v334 = 2048l * v332;
        long v335;
        v335 = v334 + v330;
        float v336[4l];
        long v337[4l];
        long v338;
        v338 = 0l;
        while (while_method_3(v338)){
            assert("Tensor range check" && 0 <= v338 && v338 < 1l);
            long v340;
            v340 = 4l * v338;
            assert("Tensor range check" && 0 <= v338 && v338 < 1l);
            long v341;
            v341 = 1024l * v338;
            long v342;
            v342 = v341 + v335;
            int4* v343;
            v343 = reinterpret_cast<int4*>(v0 + v342);
            int4* v344;
            v344 = reinterpret_cast<int4*>(v336 + v340);
            assert("Pointer alignment check" && (unsigned long long)(v343) % 4l == 0 && (unsigned long long)(v344) % 4l == 0);
            *v344 = *v343;
            v338 += 1l ;
        }
        long v345;
        v345 = 0l;
        while (while_method_3(v345)){
            long v347;
            v347 = 0l;
            while (while_method_1(v347)){
                bool v349;
                v349 = 0l <= v347;
                bool v351;
                if (v349){
                    bool v350;
                    v350 = v347 < 4l;
                    v351 = v350;
                } else {
                    v351 = false;
                }
                bool v352;
                v352 = v351 == false;
                if (v352){
                    assert("The indices should be inside the range of the dimension." && v351);
                } else {
                }
                bool v354;
                v354 = 0l <= v345;
                bool v356;
                if (v354){
                    bool v355;
                    v355 = v345 < 1l;
                    v356 = v355;
                } else {
                    v356 = false;
                }
                bool v357;
                v357 = v356 == false;
                if (v357){
                    assert("The indices should be inside the range of the dimension." && v356);
                } else {
                }
                long v359;
                v359 = v345 * 4l;
                long v360;
                v360 = v347 + v359;
                bool v361;
                v361 = 0l <= v322;
                bool v363;
                if (v361){
                    bool v362;
                    v362 = v322 < 256l;
                    v363 = v362;
                } else {
                    v363 = false;
                }
                bool v364;
                v364 = v363 == false;
                if (v364){
                    assert("The indices should be inside the range of the dimension." && v363);
                } else {
                }
                long v366;
                v366 = v322 * 4l;
                long v367;
                v367 = v360 + v366;
                assert("Tensor range check" && 0 <= v345 && v345 < 1l);
                assert("Tensor range check" && 0 <= v347 && v347 < 4l);
                long v368;
                v368 = 4l * v345;
                long v369;
                v369 = v368 + v347;
                v337[v369] = v367;
                v347 += 1l ;
            }
            v345 += 1l ;
        }
        bool v370;
        v370 = 0l < v323;
        bool v372;
        if (v370){
            bool v371;
            v371 = v323 <= 2l;
            v372 = v371;
        } else {
            v372 = false;
        }
        bool v373;
        v373 = v372 == false;
        if (v373){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v372);
        } else {
        }
        bool v375;
        v375 = 0l < v332;
        bool v377;
        if (v375){
            bool v376;
            v376 = v332 <= 8l;
            v377 = v376;
        } else {
            v377 = false;
        }
        bool v378;
        v378 = v377 == false;
        if (v378){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v377);
        } else {
        }
        long v380;
        v380 = v323 * 8l;
        long v381;
        v381 = v380 + v332;
        float v382; long v383;
        Tuple1 tmp1 = Tuple1(-1.0f / 0.0f, 0l);
        v382 = tmp1.v0; v383 = tmp1.v1;
        long v384;
        v384 = 0l;
        while (while_method_3(v384)){
            long v386;
            v386 = 0l;
            while (while_method_1(v386)){
                assert("Tensor range check" && 0 <= v384 && v384 < 1l);
                assert("Tensor range check" && 0 <= v386 && v386 < 4l);
                long v388;
                v388 = 4l * v384;
                long v389;
                v389 = v388 + v386;
                float v390;
                v390 = v336[v389];
                long v391;
                v391 = v337[v389];
                bool v392;
                v392 = v390 > v382;
                float v393; long v394;
                if (v392){
                    v393 = v390; v394 = v391;
                } else {
                    v393 = v382; v394 = v383;
                }
                v382 = v393;
                v383 = v394;
                v386 += 1l ;
            }
            v384 += 1l ;
        }
        auto v395 = cooperative_groups::coalesced_threads();
        Fun1 v396;
        v396 = ClosureMethod1;
        float v397; long v398;
        Tuple1 tmp2 = cooperative_groups::reduce(v395, Tuple1(v382, v383), v396);
        v397 = tmp2.v0; v398 = tmp2.v1;
        long v399;
        v399 = threadIdx.x;
        long v400;
        v400 = v399 / 32l;
        __shared__ float v401[16l];
        __shared__ long v402[16l];
        bool v403;
        v403 = 0l <= v400;
        bool v404;
        v404 = v403 == false;
        if (v404){
            assert("The index needs to be zero or positive." && v403);
        } else {
        }
        long v406;
        v406 = v400 % 8l;
        long v407;
        v407 = v400 / 8l;
        bool v408;
        v408 = v407 < 2l;
        bool v409;
        v409 = v408 == false;
        if (v409){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v408);
        } else {
        }
        assert("Tensor range check" && 0 <= v407 && v407 < 2l);
        assert("Tensor range check" && 0 <= v406 && v406 < 8l);
        long v411;
        v411 = 8l * v407;
        long v412;
        v412 = v411 + v406;
        v401[v412] = v397;
        v402[v412] = v398;
        v327.sync() ;
        long v413;
        v413 = threadIdx.x;
        long v414;
        v414 = v413 % 32l;
        bool v415;
        v415 = v414 < 8l;
        float v419; long v420;
        if (v415){
            assert("Tensor range check" && 0 <= v407 && v407 < 2l);
            assert("Tensor range check" && 0 <= v414 && v414 < 8l);
            long v416;
            v416 = v411 + v414;
            float v417;
            v417 = v401[v416];
            long v418;
            v418 = v402[v416];
            v419 = v417; v420 = v418;
        } else {
            v419 = -1.0f / 0.0f; v420 = 0l;
        }
        v327.sync() ;
        float v421; long v422;
        Tuple1 tmp3 = cooperative_groups::reduce(v395, Tuple1(v419, v420), v396);
        v421 = tmp3.v0; v422 = tmp3.v1;
        assert("Tensor range check" && 0 <= v332 && v332 < 8l);
        long v423;
        v423 = v332 + v331;
        v7[v423] = v422;
        v332 += 1l ;
    }
    __syncthreads();
    long v424;
    v424 = threadIdx.x;
    bool v425;
    v425 = 0l <= v424;
    bool v426;
    v426 = v425 == false;
    if (v426){
        assert("The index needs to be zero or positive." && v425);
    } else {
    }
    long v428;
    v428 = v424 % 256l;
    long v429;
    v429 = v424 / 256l;
    bool v430;
    v430 = v429 < 2l;
    bool v431;
    v431 = v430 == false;
    if (v431){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v430);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v433 = cooperative_groups::tiled_partition<256l>(v9);
    assert("Tensor range check" && 0 <= v429 && v429 < 2l);
    assert("Tensor range check" && 0 <= v428 && v428 < 256l);
    long v434;
    v434 = 4l * v428;
    long v435;
    v435 = 1024l * v429;
    long v436;
    v436 = v435 + v434;
    assert("Tensor range check" && 0 <= v429 && v429 < 2l);
    assert("Tensor range check" && 0 <= v428 && v428 < 256l);
    long v437;
    v437 = 0l;
    while (while_method_2(v437)){
        assert("Tensor range check" && 0 <= v437 && v437 < 8l);
        long v439;
        v439 = 2048l * v437;
        long v440;
        v440 = v439 + v436;
        assert("Tensor range check" && 0 <= v437 && v437 < 8l);
        float v441[4l];
        long v442[4l];
        long v443;
        v443 = 0l;
        while (while_method_3(v443)){
            assert("Tensor range check" && 0 <= v443 && v443 < 1l);
            long v445;
            v445 = 4l * v443;
            assert("Tensor range check" && 0 <= v443 && v443 < 1l);
            long v446;
            v446 = 1024l * v443;
            long v447;
            v447 = v446 + v440;
            int4* v448;
            v448 = reinterpret_cast<int4*>(v0 + v447);
            int4* v449;
            v449 = reinterpret_cast<int4*>(v441 + v445);
            assert("Pointer alignment check" && (unsigned long long)(v448) % 4l == 0 && (unsigned long long)(v449) % 4l == 0);
            *v449 = *v448;
            v443 += 1l ;
        }
        long v450;
        v450 = 0l;
        while (while_method_3(v450)){
            long v452;
            v452 = 0l;
            while (while_method_1(v452)){
                bool v454;
                v454 = 0l <= v452;
                bool v456;
                if (v454){
                    bool v455;
                    v455 = v452 < 4l;
                    v456 = v455;
                } else {
                    v456 = false;
                }
                bool v457;
                v457 = v456 == false;
                if (v457){
                    assert("The indices should be inside the range of the dimension." && v456);
                } else {
                }
                bool v459;
                v459 = 0l <= v450;
                bool v461;
                if (v459){
                    bool v460;
                    v460 = v450 < 1l;
                    v461 = v460;
                } else {
                    v461 = false;
                }
                bool v462;
                v462 = v461 == false;
                if (v462){
                    assert("The indices should be inside the range of the dimension." && v461);
                } else {
                }
                long v464;
                v464 = v450 * 4l;
                long v465;
                v465 = v452 + v464;
                bool v466;
                v466 = 0l <= v428;
                bool v468;
                if (v466){
                    bool v467;
                    v467 = v428 < 256l;
                    v468 = v467;
                } else {
                    v468 = false;
                }
                bool v469;
                v469 = v468 == false;
                if (v469){
                    assert("The indices should be inside the range of the dimension." && v468);
                } else {
                }
                long v471;
                v471 = v428 * 4l;
                long v472;
                v472 = v465 + v471;
                assert("Tensor range check" && 0 <= v450 && v450 < 1l);
                assert("Tensor range check" && 0 <= v452 && v452 < 4l);
                long v473;
                v473 = 4l * v450;
                long v474;
                v474 = v473 + v452;
                v442[v474] = v472;
                v452 += 1l ;
            }
            v450 += 1l ;
        }
        bool v475;
        v475 = 0l < v429;
        bool v477;
        if (v475){
            bool v476;
            v476 = v429 <= 2l;
            v477 = v476;
        } else {
            v477 = false;
        }
        bool v478;
        v478 = v477 == false;
        if (v478){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v477);
        } else {
        }
        bool v480;
        v480 = 0l < v437;
        bool v482;
        if (v480){
            bool v481;
            v481 = v437 <= 8l;
            v482 = v481;
        } else {
            v482 = false;
        }
        bool v483;
        v483 = v482 == false;
        if (v483){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v482);
        } else {
        }
        long v485;
        v485 = v429 * 8l;
        long v486;
        v486 = v485 + v437;
        float v487;
        v487 = 0.0f;
        long v488;
        v488 = 0l;
        while (while_method_3(v488)){
            long v490;
            v490 = 0l;
            while (while_method_1(v490)){
                assert("Tensor range check" && 0 <= v488 && v488 < 1l);
                assert("Tensor range check" && 0 <= v490 && v490 < 4l);
                long v492;
                v492 = 4l * v488;
                long v493;
                v493 = v492 + v490;
                float v494;
                v494 = v441[v493];
                float v495;
                v495 = v494 + v487;
                v487 = v495;
                v490 += 1l ;
            }
            v488 += 1l ;
        }
        auto v496 = cooperative_groups::coalesced_threads();
        float v497;
        v497 = cooperative_groups::reduce(v496, v487, v34);
        long v498;
        v498 = threadIdx.x;
        long v499;
        v499 = v498 / 32l;
        __shared__ float v500[16l];
        bool v501;
        v501 = 0l <= v499;
        bool v502;
        v502 = v501 == false;
        if (v502){
            assert("The index needs to be zero or positive." && v501);
        } else {
        }
        long v504;
        v504 = v499 % 8l;
        long v505;
        v505 = v499 / 8l;
        bool v506;
        v506 = v505 < 2l;
        bool v507;
        v507 = v506 == false;
        if (v507){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v506);
        } else {
        }
        assert("Tensor range check" && 0 <= v505 && v505 < 2l);
        assert("Tensor range check" && 0 <= v504 && v504 < 8l);
        long v509;
        v509 = 8l * v505;
        long v510;
        v510 = v509 + v504;
        v500[v510] = v497;
        v433.sync() ;
        long v511;
        v511 = threadIdx.x;
        long v512;
        v512 = v511 % 32l;
        bool v513;
        v513 = v512 < 8l;
        float v516;
        if (v513){
            assert("Tensor range check" && 0 <= v505 && v505 < 2l);
            assert("Tensor range check" && 0 <= v512 && v512 < 8l);
            long v514;
            v514 = v509 + v512;
            float v515;
            v515 = v500[v514];
            v516 = v515;
        } else {
            v516 = 0.0f;
        }
        v433.sync() ;
        float v517;
        v517 = cooperative_groups::reduce(v496, v516, v34);
        float v518;
        v518 = v517 / 1024.0f;
        float v519[4l];
        long v520;
        v520 = 0l;
        while (while_method_3(v520)){
            long v522;
            v522 = 0l;
            while (while_method_1(v522)){
                assert("Tensor range check" && 0 <= v520 && v520 < 1l);
                assert("Tensor range check" && 0 <= v522 && v522 < 4l);
                long v524;
                v524 = 4l * v520;
                long v525;
                v525 = v524 + v522;
                float v526;
                v526 = v441[v525];
                float v527;
                v527 = v526 - v518;
                float v528;
                v528 = exp(v527);
                assert("Tensor range check" && 0 <= v520 && v520 < 1l);
                assert("Tensor range check" && 0 <= v522 && v522 < 4l);
                v519[v525] = v528;
                v522 += 1l ;
            }
            v520 += 1l ;
        }
        float v529;
        v529 = 0.0f;
        long v530;
        v530 = 0l;
        while (while_method_3(v530)){
            long v532;
            v532 = 0l;
            while (while_method_1(v532)){
                assert("Tensor range check" && 0 <= v530 && v530 < 1l);
                assert("Tensor range check" && 0 <= v532 && v532 < 4l);
                long v534;
                v534 = 4l * v530;
                long v535;
                v535 = v534 + v532;
                float v536;
                v536 = v519[v535];
                float v537;
                v537 = v536 + v529;
                v529 = v537;
                v532 += 1l ;
            }
            v530 += 1l ;
        }
        auto v538 = cooperative_groups::coalesced_threads();
        float v539;
        v539 = cooperative_groups::reduce(v538, v529, v34);
        long v540;
        v540 = threadIdx.x;
        long v541;
        v541 = v540 / 32l;
        __shared__ float v542[16l];
        bool v543;
        v543 = 0l <= v541;
        bool v544;
        v544 = v543 == false;
        if (v544){
            assert("The index needs to be zero or positive." && v543);
        } else {
        }
        long v546;
        v546 = v541 % 8l;
        long v547;
        v547 = v541 / 8l;
        bool v548;
        v548 = v547 < 2l;
        bool v549;
        v549 = v548 == false;
        if (v549){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v548);
        } else {
        }
        assert("Tensor range check" && 0 <= v547 && v547 < 2l);
        assert("Tensor range check" && 0 <= v546 && v546 < 8l);
        long v551;
        v551 = 8l * v547;
        long v552;
        v552 = v551 + v546;
        v542[v552] = v539;
        v433.sync() ;
        long v553;
        v553 = threadIdx.x;
        long v554;
        v554 = v553 % 32l;
        bool v555;
        v555 = v554 < 8l;
        float v558;
        if (v555){
            assert("Tensor range check" && 0 <= v547 && v547 < 2l);
            assert("Tensor range check" && 0 <= v554 && v554 < 8l);
            long v556;
            v556 = v551 + v554;
            float v557;
            v557 = v542[v556];
            v558 = v557;
        } else {
            v558 = 0.0f;
        }
        v433.sync() ;
        float v559;
        v559 = cooperative_groups::reduce(v538, v558, v34);
        float v560[4l];
        long v561;
        v561 = 0l;
        while (while_method_3(v561)){
            long v563;
            v563 = 0l;
            while (while_method_1(v563)){
                assert("Tensor range check" && 0 <= v561 && v561 < 1l);
                assert("Tensor range check" && 0 <= v563 && v563 < 4l);
                long v565;
                v565 = 4l * v561;
                long v566;
                v566 = v565 + v563;
                float v567;
                v567 = v519[v566];
                float v568;
                v568 = v567 / v559;
                assert("Tensor range check" && 0 <= v561 && v561 < 1l);
                assert("Tensor range check" && 0 <= v563 && v563 < 4l);
                v560[v566] = v568;
                v563 += 1l ;
            }
            v561 += 1l ;
        }
        float v569[4l];
        float v570;
        v570 = 0.0f;
        long v571;
        v571 = 0l;
        while (while_method_3(v571)){
            assert("Tensor range check" && 0 <= v571 && v571 < 1l);
            long v573;
            v573 = 4l * v571;
            assert("Tensor range check" && 0 <= v571 && v571 < 1l);
            long v574; float v575;
            Tuple0 tmp4 = Tuple0(0l, 0.0f);
            v574 = tmp4.v0; v575 = tmp4.v1;
            while (while_method_1(v574)){
                assert("Tensor range check" && 0 <= v574 && v574 < 4l);
                long v577;
                v577 = v574 + v573;
                float v578;
                v578 = v560[v577];
                float v579;
                v579 = v578 + v575;
                v575 = v579;
                v574 += 1l ;
            }
            auto v580 = cooperative_groups::coalesced_threads();
            long v581;
            v581 = threadIdx.x;
            long v582;
            v582 = v581 / 32l;
            __shared__ float v583[16l];
            Fun0 v584;
            v584 = ClosureMethod2;
            float v585;
            v585 = cooperative_groups::inclusive_scan(v580, v575, v584);
            float v586;
            v586 = v580.shfl(v585,v580.num_threads()-1);
            float v587;
            v587 = v580.shfl_up(v585,1);
            bool v588;
            v588 = v580.thread_rank() == 0;
            float v589;
            if (v588){
                v589 = 0.0f;
            } else {
                v589 = v587;
            }
            bool v590;
            v590 = 0l <= v582;
            bool v591;
            v591 = v590 == false;
            if (v591){
                assert("The index needs to be zero or positive." && v590);
            } else {
            }
            long v593;
            v593 = v582 % 8l;
            long v594;
            v594 = v582 / 8l;
            bool v595;
            v595 = v594 < 2l;
            bool v596;
            v596 = v595 == false;
            if (v596){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v595);
            } else {
            }
            assert("Tensor range check" && 0 <= v594 && v594 < 2l);
            assert("Tensor range check" && 0 <= v593 && v593 < 8l);
            long v598;
            v598 = 8l * v594;
            long v599;
            v599 = v598 + v593;
            v583[v599] = v586;
            v433.sync() ;
            long v600;
            v600 = threadIdx.x;
            long v601;
            v601 = v600 % 32l;
            bool v602;
            v602 = v601 < 8l;
            float v605;
            if (v602){
                assert("Tensor range check" && 0 <= v594 && v594 < 2l);
                assert("Tensor range check" && 0 <= v601 && v601 < 8l);
                long v603;
                v603 = v598 + v601;
                float v604;
                v604 = v583[v603];
                v605 = v604;
            } else {
                v605 = 0.0f;
            }
            v433.sync() ;
            float v606;
            v606 = cooperative_groups::inclusive_scan(v580, v605, v584);
            float v607;
            v607 = v580.shfl(v606,v580.num_threads()-1);
            float v608;
            v608 = v580.shfl_up(v606,1);
            bool v609;
            v609 = v580.thread_rank() == 0;
            float v610;
            if (v609){
                v610 = 0.0f;
            } else {
                v610 = v608;
            }
            float v611;
            v611 = v580.shfl(v610,v593);
            float v612;
            v612 = v611 + v589;
            float v613;
            v613 = v570 + v612;
            long v614; float v615;
            Tuple0 tmp5 = Tuple0(0l, v613);
            v614 = tmp5.v0; v615 = tmp5.v1;
            while (while_method_1(v614)){
                assert("Tensor range check" && 0 <= v614 && v614 < 4l);
                long v617;
                v617 = v614 + v573;
                float v618;
                v618 = v560[v617];
                assert("Tensor range check" && 0 <= v614 && v614 < 4l);
                v569[v617] = v615;
                float v619;
                v619 = v618 + v615;
                v615 = v619;
                v614 += 1l ;
            }
            float v620;
            v620 = v570 + v607;
            v570 = v620;
            v571 += 1l ;
        }
        long v621;
        v621 = 0l;
        while (while_method_3(v621)){
            assert("Tensor range check" && 0 <= v621 && v621 < 1l);
            long v623;
            v623 = 1024l * v621;
            long v624;
            v624 = v623 + v440;
            assert("Tensor range check" && 0 <= v621 && v621 < 1l);
            long v625;
            v625 = 4l * v621;
            int4* v626;
            v626 = reinterpret_cast<int4*>(v560 + v625);
            int4* v627;
            v627 = reinterpret_cast<int4*>(v4 + v624);
            assert("Pointer alignment check" && (unsigned long long)(v626) % 4l == 0 && (unsigned long long)(v627) % 4l == 0);
            *v627 = *v626;
            int4* v628;
            v628 = reinterpret_cast<int4*>(v569 + v625);
            int4* v629;
            v629 = reinterpret_cast<int4*>(v5 + v624);
            assert("Pointer alignment check" && (unsigned long long)(v628) % 4l == 0 && (unsigned long long)(v629) % 4l == 0);
            *v629 = *v628;
            v621 += 1l ;
        }
        v437 += 1l ;
    }
    __syncthreads();
    long v630;
    v630 = threadIdx.x;
    bool v631;
    v631 = 0l <= v630;
    bool v632;
    v632 = v631 == false;
    if (v632){
        assert("The index needs to be zero or positive." && v631);
    } else {
    }
    long v634;
    v634 = v630 % 256l;
    long v635;
    v635 = v630 / 256l;
    bool v636;
    v636 = v635 < 2l;
    bool v637;
    v637 = v636 == false;
    if (v637){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v636);
    } else {
    }
    cooperative_groups::thread_block_tile<256l, cooperative_groups::thread_block> v639 = cooperative_groups::tiled_partition<256l>(v9);
    assert("Tensor range check" && 0 <= v635 && v635 < 2l);
    assert("Tensor range check" && 0 <= v634 && v634 < 256l);
    long v640;
    v640 = 4l * v634;
    long v641;
    v641 = 1024l * v635;
    long v642;
    v642 = v641 + v640;
    assert("Tensor range check" && 0 <= v635 && v635 < 2l);
    long v643;
    v643 = 8l * v635;
    long v644;
    v644 = 0l;
    while (while_method_2(v644)){
        assert("Tensor range check" && 0 <= v644 && v644 < 8l);
        long v646;
        v646 = 2048l * v644;
        long v647;
        v647 = v646 + v642;
        float v648[4l];
        long v649[4l];
        long v650;
        v650 = 0l;
        while (while_method_3(v650)){
            assert("Tensor range check" && 0 <= v650 && v650 < 1l);
            long v652;
            v652 = 4l * v650;
            assert("Tensor range check" && 0 <= v650 && v650 < 1l);
            long v653;
            v653 = 1024l * v650;
            long v654;
            v654 = v653 + v647;
            int4* v655;
            v655 = reinterpret_cast<int4*>(v0 + v654);
            int4* v656;
            v656 = reinterpret_cast<int4*>(v648 + v652);
            assert("Pointer alignment check" && (unsigned long long)(v655) % 4l == 0 && (unsigned long long)(v656) % 4l == 0);
            *v656 = *v655;
            v650 += 1l ;
        }
        long v657;
        v657 = 0l;
        while (while_method_3(v657)){
            long v659;
            v659 = 0l;
            while (while_method_1(v659)){
                bool v661;
                v661 = 0l <= v659;
                bool v663;
                if (v661){
                    bool v662;
                    v662 = v659 < 4l;
                    v663 = v662;
                } else {
                    v663 = false;
                }
                bool v664;
                v664 = v663 == false;
                if (v664){
                    assert("The indices should be inside the range of the dimension." && v663);
                } else {
                }
                bool v666;
                v666 = 0l <= v657;
                bool v668;
                if (v666){
                    bool v667;
                    v667 = v657 < 1l;
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
                v671 = v657 * 4l;
                long v672;
                v672 = v659 + v671;
                bool v673;
                v673 = 0l <= v634;
                bool v675;
                if (v673){
                    bool v674;
                    v674 = v634 < 256l;
                    v675 = v674;
                } else {
                    v675 = false;
                }
                bool v676;
                v676 = v675 == false;
                if (v676){
                    assert("The indices should be inside the range of the dimension." && v675);
                } else {
                }
                long v678;
                v678 = v634 * 4l;
                long v679;
                v679 = v672 + v678;
                assert("Tensor range check" && 0 <= v657 && v657 < 1l);
                assert("Tensor range check" && 0 <= v659 && v659 < 4l);
                long v680;
                v680 = 4l * v657;
                long v681;
                v681 = v680 + v659;
                v649[v681] = v679;
                v659 += 1l ;
            }
            v657 += 1l ;
        }
        bool v682;
        v682 = 0l < v635;
        bool v684;
        if (v682){
            bool v683;
            v683 = v635 <= 2l;
            v684 = v683;
        } else {
            v684 = false;
        }
        bool v685;
        v685 = v684 == false;
        if (v685){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v684);
        } else {
        }
        bool v687;
        v687 = 0l < v644;
        bool v689;
        if (v687){
            bool v688;
            v688 = v644 <= 8l;
            v689 = v688;
        } else {
            v689 = false;
        }
        bool v690;
        v690 = v689 == false;
        if (v690){
            assert("The rigid merge indices have to be positive and less or equal than the dimensions." && v689);
        } else {
        }
        long v692;
        v692 = v635 * 8l;
        long v693;
        v693 = v692 + v644;
        float v694;
        v694 = 0.0f;
        long v695;
        v695 = 0l;
        while (while_method_3(v695)){
            long v697;
            v697 = 0l;
            while (while_method_1(v697)){
                assert("Tensor range check" && 0 <= v695 && v695 < 1l);
                assert("Tensor range check" && 0 <= v697 && v697 < 4l);
                long v699;
                v699 = 4l * v695;
                long v700;
                v700 = v699 + v697;
                float v701;
                v701 = v648[v700];
                float v702;
                v702 = v701 + v694;
                v694 = v702;
                v697 += 1l ;
            }
            v695 += 1l ;
        }
        auto v703 = cooperative_groups::coalesced_threads();
        float v704;
        v704 = cooperative_groups::reduce(v703, v694, v34);
        long v705;
        v705 = threadIdx.x;
        long v706;
        v706 = v705 / 32l;
        __shared__ float v707[16l];
        bool v708;
        v708 = 0l <= v706;
        bool v709;
        v709 = v708 == false;
        if (v709){
            assert("The index needs to be zero or positive." && v708);
        } else {
        }
        long v711;
        v711 = v706 % 8l;
        long v712;
        v712 = v706 / 8l;
        bool v713;
        v713 = v712 < 2l;
        bool v714;
        v714 = v713 == false;
        if (v714){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v713);
        } else {
        }
        assert("Tensor range check" && 0 <= v712 && v712 < 2l);
        assert("Tensor range check" && 0 <= v711 && v711 < 8l);
        long v716;
        v716 = 8l * v712;
        long v717;
        v717 = v716 + v711;
        v707[v717] = v704;
        v639.sync() ;
        long v718;
        v718 = threadIdx.x;
        long v719;
        v719 = v718 % 32l;
        bool v720;
        v720 = v719 < 8l;
        float v723;
        if (v720){
            assert("Tensor range check" && 0 <= v712 && v712 < 2l);
            assert("Tensor range check" && 0 <= v719 && v719 < 8l);
            long v721;
            v721 = v716 + v719;
            float v722;
            v722 = v707[v721];
            v723 = v722;
        } else {
            v723 = 0.0f;
        }
        v639.sync() ;
        float v724;
        v724 = cooperative_groups::reduce(v703, v723, v34);
        float v725;
        v725 = v724 / 1024.0f;
        float v726[4l];
        long v727;
        v727 = 0l;
        while (while_method_3(v727)){
            long v729;
            v729 = 0l;
            while (while_method_1(v729)){
                assert("Tensor range check" && 0 <= v727 && v727 < 1l);
                assert("Tensor range check" && 0 <= v729 && v729 < 4l);
                long v731;
                v731 = 4l * v727;
                long v732;
                v732 = v731 + v729;
                float v733;
                v733 = v648[v732];
                float v734;
                v734 = v733 - v725;
                float v735;
                v735 = exp(v734);
                assert("Tensor range check" && 0 <= v727 && v727 < 1l);
                assert("Tensor range check" && 0 <= v729 && v729 < 4l);
                v726[v732] = v735;
                v729 += 1l ;
            }
            v727 += 1l ;
        }
        float v736;
        v736 = 0.0f;
        long v737;
        v737 = 0l;
        while (while_method_3(v737)){
            long v739;
            v739 = 0l;
            while (while_method_1(v739)){
                assert("Tensor range check" && 0 <= v737 && v737 < 1l);
                assert("Tensor range check" && 0 <= v739 && v739 < 4l);
                long v741;
                v741 = 4l * v737;
                long v742;
                v742 = v741 + v739;
                float v743;
                v743 = v726[v742];
                float v744;
                v744 = v743 + v736;
                v736 = v744;
                v739 += 1l ;
            }
            v737 += 1l ;
        }
        auto v745 = cooperative_groups::coalesced_threads();
        float v746;
        v746 = cooperative_groups::reduce(v745, v736, v34);
        long v747;
        v747 = threadIdx.x;
        long v748;
        v748 = v747 / 32l;
        __shared__ float v749[16l];
        bool v750;
        v750 = 0l <= v748;
        bool v751;
        v751 = v750 == false;
        if (v751){
            assert("The index needs to be zero or positive." && v750);
        } else {
        }
        long v753;
        v753 = v748 % 8l;
        long v754;
        v754 = v748 / 8l;
        bool v755;
        v755 = v754 < 2l;
        bool v756;
        v756 = v755 == false;
        if (v756){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v755);
        } else {
        }
        assert("Tensor range check" && 0 <= v754 && v754 < 2l);
        assert("Tensor range check" && 0 <= v753 && v753 < 8l);
        long v758;
        v758 = 8l * v754;
        long v759;
        v759 = v758 + v753;
        v749[v759] = v746;
        v639.sync() ;
        long v760;
        v760 = threadIdx.x;
        long v761;
        v761 = v760 % 32l;
        bool v762;
        v762 = v761 < 8l;
        float v765;
        if (v762){
            assert("Tensor range check" && 0 <= v754 && v754 < 2l);
            assert("Tensor range check" && 0 <= v761 && v761 < 8l);
            long v763;
            v763 = v758 + v761;
            float v764;
            v764 = v749[v763];
            v765 = v764;
        } else {
            v765 = 0.0f;
        }
        v639.sync() ;
        float v766;
        v766 = cooperative_groups::reduce(v745, v765, v34);
        float v767[4l];
        long v768;
        v768 = 0l;
        while (while_method_3(v768)){
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
                v774 = v726[v773];
                float v775;
                v775 = v774 / v766;
                assert("Tensor range check" && 0 <= v768 && v768 < 1l);
                assert("Tensor range check" && 0 <= v770 && v770 < 4l);
                v767[v773] = v775;
                v770 += 1l ;
            }
            v768 += 1l ;
        }
        float v776[4l];
        float v777;
        v777 = 0.0f;
        long v778;
        v778 = 0l;
        while (while_method_3(v778)){
            assert("Tensor range check" && 0 <= v778 && v778 < 1l);
            long v780;
            v780 = 4l * v778;
            assert("Tensor range check" && 0 <= v778 && v778 < 1l);
            long v781; float v782;
            Tuple0 tmp6 = Tuple0(0l, 0.0f);
            v781 = tmp6.v0; v782 = tmp6.v1;
            while (while_method_1(v781)){
                assert("Tensor range check" && 0 <= v781 && v781 < 4l);
                long v784;
                v784 = v781 + v780;
                float v785;
                v785 = v767[v784];
                float v786;
                v786 = v785 + v782;
                v782 = v786;
                v781 += 1l ;
            }
            auto v787 = cooperative_groups::coalesced_threads();
            long v788;
            v788 = threadIdx.x;
            long v789;
            v789 = v788 / 32l;
            __shared__ float v790[16l];
            Fun0 v791;
            v791 = ClosureMethod2;
            float v792;
            v792 = cooperative_groups::inclusive_scan(v787, v782, v791);
            float v793;
            v793 = v787.shfl(v792,v787.num_threads()-1);
            float v794;
            v794 = v787.shfl_up(v792,1);
            bool v795;
            v795 = v787.thread_rank() == 0;
            float v796;
            if (v795){
                v796 = 0.0f;
            } else {
                v796 = v794;
            }
            bool v797;
            v797 = 0l <= v789;
            bool v798;
            v798 = v797 == false;
            if (v798){
                assert("The index needs to be zero or positive." && v797);
            } else {
            }
            long v800;
            v800 = v789 % 8l;
            long v801;
            v801 = v789 / 8l;
            bool v802;
            v802 = v801 < 2l;
            bool v803;
            v803 = v802 == false;
            if (v803){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v802);
            } else {
            }
            assert("Tensor range check" && 0 <= v801 && v801 < 2l);
            assert("Tensor range check" && 0 <= v800 && v800 < 8l);
            long v805;
            v805 = 8l * v801;
            long v806;
            v806 = v805 + v800;
            v790[v806] = v793;
            v639.sync() ;
            long v807;
            v807 = threadIdx.x;
            long v808;
            v808 = v807 % 32l;
            bool v809;
            v809 = v808 < 8l;
            float v812;
            if (v809){
                assert("Tensor range check" && 0 <= v801 && v801 < 2l);
                assert("Tensor range check" && 0 <= v808 && v808 < 8l);
                long v810;
                v810 = v805 + v808;
                float v811;
                v811 = v790[v810];
                v812 = v811;
            } else {
                v812 = 0.0f;
            }
            v639.sync() ;
            float v813;
            v813 = cooperative_groups::inclusive_scan(v787, v812, v791);
            float v814;
            v814 = v787.shfl(v813,v787.num_threads()-1);
            float v815;
            v815 = v787.shfl_up(v813,1);
            bool v816;
            v816 = v787.thread_rank() == 0;
            float v817;
            if (v816){
                v817 = 0.0f;
            } else {
                v817 = v815;
            }
            float v818;
            v818 = v787.shfl(v817,v800);
            float v819;
            v819 = v818 + v796;
            float v820;
            v820 = v777 + v819;
            long v821; float v822;
            Tuple0 tmp7 = Tuple0(0l, v820);
            v821 = tmp7.v0; v822 = tmp7.v1;
            while (while_method_1(v821)){
                assert("Tensor range check" && 0 <= v821 && v821 < 4l);
                long v824;
                v824 = v821 + v780;
                float v825;
                v825 = v767[v824];
                assert("Tensor range check" && 0 <= v821 && v821 < 4l);
                v776[v824] = v822;
                float v826;
                v826 = v825 + v822;
                v822 = v826;
                v821 += 1l ;
            }
            float v827;
            v827 = v777 + v814;
            v777 = v827;
            v778 += 1l ;
        }
        assert("Tensor range check" && 0 <= v693 && v693 < 16l);
        float v828;
        v828 = v1[v693];
        float v829[4l];
        long v830;
        v830 = 0l;
        while (while_method_3(v830)){
            long v832;
            v832 = 0l;
            while (while_method_1(v832)){
                assert("Tensor range check" && 0 <= v830 && v830 < 1l);
                assert("Tensor range check" && 0 <= v832 && v832 < 4l);
                long v834;
                v834 = 4l * v830;
                long v835;
                v835 = v834 + v832;
                float v836;
                v836 = v776[v835];
                float v837;
                v837 = v836 - v828;
                assert("Tensor range check" && 0 <= v830 && v830 < 1l);
                assert("Tensor range check" && 0 <= v832 && v832 < 4l);
                v829[v835] = v837;
                v832 += 1l ;
            }
            v830 += 1l ;
        }
        float v838; long v839;
        Tuple1 tmp8 = Tuple1(-1.0f / 0.0f, 0l);
        v838 = tmp8.v0; v839 = tmp8.v1;
        long v840;
        v840 = 0l;
        while (while_method_3(v840)){
            long v842;
            v842 = 0l;
            while (while_method_1(v842)){
                assert("Tensor range check" && 0 <= v840 && v840 < 1l);
                assert("Tensor range check" && 0 <= v842 && v842 < 4l);
                long v844;
                v844 = 4l * v840;
                long v845;
                v845 = v844 + v842;
                float v846;
                v846 = v829[v845];
                long v847;
                v847 = v649[v845];
                bool v848;
                v848 = v846 >= 0.0f;
                bool v850;
                if (v848){
                    bool v849;
                    v849 = v838 >= 0.0f;
                    v850 = v849;
                } else {
                    v850 = false;
                }
                float v859; long v860;
                if (v850){
                    bool v851;
                    v851 = v846 <= v838;
                    if (v851){
                        v859 = v846; v860 = v847;
                    } else {
                        v859 = v838; v860 = v839;
                    }
                } else {
                    if (v848){
                        v859 = v846; v860 = v847;
                    } else {
                        bool v854;
                        v854 = v838 >= 0.0f;
                        if (v854){
                            v859 = v838; v860 = v839;
                        } else {
                            v859 = v846; v860 = v847;
                        }
                    }
                }
                v838 = v859;
                v839 = v860;
                v842 += 1l ;
            }
            v840 += 1l ;
        }
        auto v861 = cooperative_groups::coalesced_threads();
        Fun1 v862;
        v862 = ClosureMethod3;
        float v863; long v864;
        Tuple1 tmp9 = cooperative_groups::reduce(v861, Tuple1(v838, v839), v862);
        v863 = tmp9.v0; v864 = tmp9.v1;
        long v865;
        v865 = threadIdx.x;
        long v866;
        v866 = v865 / 32l;
        __shared__ float v867[16l];
        __shared__ long v868[16l];
        bool v869;
        v869 = 0l <= v866;
        bool v870;
        v870 = v869 == false;
        if (v870){
            assert("The index needs to be zero or positive." && v869);
        } else {
        }
        long v872;
        v872 = v866 % 8l;
        long v873;
        v873 = v866 / 8l;
        bool v874;
        v874 = v873 < 2l;
        bool v875;
        v875 = v874 == false;
        if (v875){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v874);
        } else {
        }
        assert("Tensor range check" && 0 <= v873 && v873 < 2l);
        assert("Tensor range check" && 0 <= v872 && v872 < 8l);
        long v877;
        v877 = 8l * v873;
        long v878;
        v878 = v877 + v872;
        v867[v878] = v863;
        v868[v878] = v864;
        v639.sync() ;
        long v879;
        v879 = threadIdx.x;
        long v880;
        v880 = v879 % 32l;
        bool v881;
        v881 = v880 < 8l;
        float v885; long v886;
        if (v881){
            assert("Tensor range check" && 0 <= v873 && v873 < 2l);
            assert("Tensor range check" && 0 <= v880 && v880 < 8l);
            long v882;
            v882 = v877 + v880;
            float v883;
            v883 = v867[v882];
            long v884;
            v884 = v868[v882];
            v885 = v883; v886 = v884;
        } else {
            v885 = -1.0f / 0.0f; v886 = 0l;
        }
        v639.sync() ;
        float v887; long v888;
        Tuple1 tmp10 = cooperative_groups::reduce(v861, Tuple1(v885, v886), v862);
        v887 = tmp10.v0; v888 = tmp10.v1;
        assert("Tensor range check" && 0 <= v644 && v644 < 8l);
        long v889;
        v889 = v644 + v643;
        v8[v889] = v888;
        v644 += 1l ;
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
    v1 = v0 < 16
    del v0
    return v1
def main():
    v0 = cp.random.normal(0.0,1.0,16384,dtype=cp.float32)
    v1 = v0.size
    v2 = 16384 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.uniform(size=16,dtype=cp.float32)
    v6 = v5.size
    v7 = 16 == v6
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
    v11 = cp.empty(16384,dtype=cp.float32)
    pass
    v12 = cp.empty(16384,dtype=cp.float32)
    v13 = cp.empty(16384,dtype=cp.float32)
    pass
    v14 = cp.empty(16384,dtype=cp.float32)
    pass
    v15 = cp.empty(16,dtype=cp.int32)
    pass
    v16 = cp.empty(16,dtype=cp.int32)
    v17 = 0
    v18 = raw_module.get_function(f"entry{v17}")
    del v17
    v18.max_dynamic_shared_size_bytes = 0 
    v18((1,),(512,),(v0, v5, v10, v11, v12, v13, v14, v15, v16),shared_mem=0)
    del v0, v5, v10, v11, v12, v13, v14, v15, v18
    v19 = 0
    print('[', end="")
    v21 = 0
    while method0(v21):
        v23 = v19
        v24 = v23 >= 16384
        del v23
        if v24:
            v27 = " ..."
            print(v27, end="")
            del v27
            break
        else:
            pass
        del v24
        v28 = v21 == 0
        v29 = v28 != True
        del v28
        if v29:
            v32 = "; "
            print(v32, end="")
            del v32
        else:
            pass
        del v29
        v33 = v19 + 1
        v19 = v33
        del v33
        v34 = v16[v21].item()
        print(v34, end="")
        del v34
        v21 += 1 
    del v16, v19, v21
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
