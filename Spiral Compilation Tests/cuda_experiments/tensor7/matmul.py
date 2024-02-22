kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
struct Tuple0;
struct US0;
struct US1;
struct Tuple0 {
    long v0;
    bool v1;
    bool v2;
    __device__ Tuple0(long t0, bool t1, bool t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple0() = default;
};
struct US0 {
    union {
        struct {
            long v0;
            long v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US1 {
    union {
        struct {
            long v0;
        } case1; // Some
    } v;
    char tag : 2;
};
__device__ inline bool while_method_0(bool v0){
    return v0;
}
__device__ US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1(long v0, long v1) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1(long v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 2048l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 4096l;
    return v1;
}
__device__ inline bool while_method_4(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    thread_block_tile<1l, thread_block> v4 = tiled_partition<1l>(v3);
    extern __shared__ unsigned char v5[];
    float * v8;
    float * v6;
    v6 = reinterpret_cast<float *>(&v5[0ull]);
    v8 = v6;
    float * v11;
    float * v9;
    v9 = reinterpret_cast<float *>(&v5[34816ull]);
    v11 = v9;
    float * v14;
    float * v12;
    v12 = reinterpret_cast<float *>(&v5[0ull]);
    v14 = v12;
    long v15;
    v15 = grid_group::num_blocks();
    long v16;
    v16 = grid_group::block_rank();
    bool v17;
    v17 = v16 < 16l;
    long v18; bool v19; bool v20;
    Tuple0 tmp0 = Tuple0(v16, v17, true);
    v18 = tmp0.v0; v19 = tmp0.v1; v20 = tmp0.v2;
    while (while_method_0(v19)){
        long v22;
        v22 = v18 + v15;
        bool v23;
        v23 = v22 < 16l;
        long v24;
        v24 = v18 % 4l;
        long v25;
        v25 = v18 / 4l;
        long v26;
        v26 = v25 % 4l;
        long v27;
        v27 = v25 / 4l;
        bool v28;
        v28 = v27 == 0l;
        bool v29;
        v29 = v28 == false;
        if (v29){
            assert("The index has to be in the range of the dimension." && v28);
        } else {
        }
        US0 v40;
        if (v23){
            long v31;
            v31 = v22 % 4l;
            long v32;
            v32 = v22 / 4l;
            long v33;
            v33 = v32 % 4l;
            long v34;
            v34 = v32 / 4l;
            bool v35;
            v35 = v34 == 0l;
            bool v36;
            v36 = v35 == false;
            if (v36){
                assert("The index has to be in the range of the dimension." && v35);
            } else {
            }
            v40 = US0_1(v33, v31);
        } else {
            v40 = US0_0();
        }
        assert("Tensor range check" && 0 <= v26 && v26 < 4l);
        long v41;
        v41 = 65536l * v26;
        assert("Tensor range check" && 0 <= v24 && v24 < 4l);
        long v42;
        v42 = 128l * v24;
        assert("Tensor range check" && 0 <= v26 && v26 < 4l);
        assert("Tensor range check" && 0 <= v24 && v24 < 4l);
        long v43;
        v43 = v41 + v42;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v44[8l];
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v45[8l];
        long v46;
        v46 = 0l;
        while (while_method_1(v46)){
            long v48;
            v48 = v46 % 1l;
            long v49;
            v49 = v46 % 8l;
            long v50;
            v50 = v46 / 8l;
            bool v51;
            v51 = v50 == 0l;
            bool v52;
            v52 = v51 == false;
            if (v52){
                assert("The index has to be in the range of the dimension." && v51);
            } else {
            }
            assert("Tensor range check" && 0 <= v49 && v49 < 8l);
            assert("Tensor range check" && 0 <= v48 && v48 < 1l);
            long v54;
            v54 = v49 + v48;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v55 = v45[v54];
            wmma::fill_fragment(v55, 0.0f);
            v46 += 1l ;
        }
        long v56; bool v57; bool v58;
        Tuple0 tmp1 = Tuple0(0l, true, true);
        v56 = tmp1.v0; v57 = tmp1.v1; v58 = tmp1.v2;
        while (while_method_0(v57)){
            long v60;
            v60 = v56 + 1l;
            bool v61;
            v61 = v60 < 8l;
            long v62;
            v62 = v56 % 8l;
            long v63;
            v63 = v56 / 8l;
            bool v64;
            v64 = v63 == 0l;
            bool v65;
            v65 = v64 == false;
            if (v65){
                assert("The index has to be in the range of the dimension." && v64);
            } else {
            }
            US1 v74;
            if (v61){
                long v67;
                v67 = v60 % 8l;
                long v68;
                v68 = v60 / 8l;
                bool v69;
                v69 = v68 == 0l;
                bool v70;
                v70 = v69 == false;
                if (v70){
                    assert("The index has to be in the range of the dimension." && v69);
                } else {
                }
                v74 = US1_1(v67);
            } else {
                v74 = US1_0();
            }
            if (v58){
                assert("Tensor range check" && 0 <= v62 && v62 < 8l);
                long v75;
                v75 = 64l * v62;
                long v76;
                v76 = v75 + v41;
                assert("Tensor range check" && 0 <= v62 && v62 < 8l);
                long v77;
                v77 = 32768l * v62;
                long v78;
                v78 = v77 + v42;
                long v79;
                v79 = v4.meta_group_size();
                long v80;
                v80 = v4.meta_group_rank();
                long v81;
                v81 = v80;
                while (while_method_2(v81)){
                    long v83;
                    v83 = v81 % 2l;
                    long v84;
                    v84 = v81 / 2l;
                    long v85;
                    v85 = v84 % 8l;
                    long v86;
                    v86 = v84 / 8l;
                    long v87;
                    v87 = v86 % 16l;
                    long v88;
                    v88 = v86 / 16l;
                    long v89;
                    v89 = v88 % 8l;
                    long v90;
                    v90 = v88 / 8l;
                    bool v91;
                    v91 = v90 == 0l;
                    bool v92;
                    v92 = v91 == false;
                    if (v92){
                        assert("The index has to be in the range of the dimension." && v91);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v89 && v89 < 8l);
                    assert("Tensor range check" && 0 <= v87 && v87 < 16l);
                    assert("Tensor range check" && 0 <= v85 && v85 < 8l);
                    assert("Tensor range check" && 0 <= v83 && v83 < 2l);
                    long v94;
                    v94 = 4l * v83;
                    long v95;
                    v95 = v94 + v76;
                    long v96;
                    v96 = 8l * v85;
                    long v97;
                    v97 = v96 + v95;
                    long v98;
                    v98 = 512l * v87;
                    long v99;
                    v99 = v98 + v97;
                    long v100;
                    v100 = 8192l * v89;
                    long v101;
                    v101 = v100 + v99;
                    assert("Tensor range check" && 0 <= v89 && v89 < 8l);
                    assert("Tensor range check" && 0 <= v87 && v87 < 16l);
                    assert("Tensor range check" && 0 <= v85 && v85 < 8l);
                    assert("Tensor range check" && 0 <= v83 && v83 < 2l);
                    long v102;
                    v102 = 136l * v85;
                    long v103;
                    v103 = v102 + v94;
                    long v104;
                    v104 = 8l * v87;
                    long v105;
                    v105 = v104 + v103;
                    long v106;
                    v106 = 1088l * v89;
                    long v107;
                    v107 = v106 + v105;
                    cooperative_groups::memcpy_async(v4, v8 + v107, v0 + v101, sizeof(float) * 4l);
                    v81 += v79 ;
                }
                long v108;
                v108 = v4.meta_group_size();
                long v109;
                v109 = v4.meta_group_rank();
                long v110;
                v110 = v109;
                while (while_method_2(v110)){
                    long v112;
                    v112 = v110 % 4l;
                    long v113;
                    v113 = v110 / 4l;
                    long v114;
                    v114 = v113 % 8l;
                    long v115;
                    v115 = v113 / 8l;
                    long v116;
                    v116 = v115 % 8l;
                    long v117;
                    v117 = v115 / 8l;
                    long v118;
                    v118 = v117 % 8l;
                    long v119;
                    v119 = v117 / 8l;
                    bool v120;
                    v120 = v119 == 0l;
                    bool v121;
                    v121 = v120 == false;
                    if (v121){
                        assert("The index has to be in the range of the dimension." && v120);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v118 && v118 < 8l);
                    assert("Tensor range check" && 0 <= v116 && v116 < 8l);
                    assert("Tensor range check" && 0 <= v114 && v114 < 8l);
                    assert("Tensor range check" && 0 <= v112 && v112 < 4l);
                    long v123;
                    v123 = 4l * v112;
                    long v124;
                    v124 = v123 + v78;
                    long v125;
                    v125 = 16l * v114;
                    long v126;
                    v126 = v125 + v124;
                    long v127;
                    v127 = 512l * v116;
                    long v128;
                    v128 = v127 + v126;
                    long v129;
                    v129 = 4096l * v118;
                    long v130;
                    v130 = v129 + v128;
                    assert("Tensor range check" && 0 <= v118 && v118 < 8l);
                    assert("Tensor range check" && 0 <= v116 && v116 < 8l);
                    assert("Tensor range check" && 0 <= v114 && v114 < 8l);
                    assert("Tensor range check" && 0 <= v112 && v112 < 4l);
                    long v131;
                    v131 = 144l * v114;
                    long v132;
                    v132 = v131 + v123;
                    long v133;
                    v133 = 16l * v116;
                    long v134;
                    v134 = v133 + v132;
                    long v135;
                    v135 = 1152l * v118;
                    long v136;
                    v136 = v135 + v134;
                    cooperative_groups::memcpy_async(v4, v11 + v136, v1 + v130, sizeof(float) * 4l);
                    v110 += v108 ;
                }
            } else {
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v137[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v138[8l];
            long v139;
            v139 = thread_block::thread_rank() / warpSize;
            long v140;
            v140 = v139 % 8l;
            long v141;
            v141 = v139 / 8l;
            long v142;
            v142 = v141 % 1l;
            bool v143;
            v143 = v141 == 0l;
            bool v144;
            v144 = v143 == false;
            if (v144){
                assert("The index has to be in the range of the dimension." && v143);
            } else {
            }
            assert("Tensor range check" && 0 <= v142 && v142 < 1l);
            long v146;
            v146 = 1088l * v142;
            assert("Tensor range check" && 0 <= v140 && v140 < 8l);
            long v147;
            v147 = 144l * v140;
            long v148;
            v148 = 0l;
            while (while_method_1(v148)){
                long v150;
                v150 = v148 % 1l;
                long v151;
                v151 = v148 % 8l;
                long v152;
                v152 = v148 / 8l;
                bool v153;
                v153 = v152 == 0l;
                bool v154;
                v154 = v153 == false;
                if (v154){
                    assert("The index has to be in the range of the dimension." && v153);
                } else {
                }
                assert("Tensor range check" && 0 <= v151 && v151 < 8l);
                long v156;
                v156 = 1088l * v151;
                long v157;
                v157 = v156 + v146;
                assert("Tensor range check" && 0 <= v150 && v150 < 1l);
                long v158;
                v158 = 1152l * v150;
                long v159;
                v159 = v158 + v147;
                long v160;
                v160 = 0l;
                while (while_method_1(v160)){
                    long v162;
                    v162 = v160 % 8l;
                    long v163;
                    v163 = v160 / 8l;
                    bool v164;
                    v164 = v163 == 0l;
                    bool v165;
                    v165 = v164 == false;
                    if (v165){
                        assert("The index has to be in the range of the dimension." && v164);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v162 && v162 < 8l);
                    long v167;
                    v167 = 136l * v162;
                    long v168;
                    v168 = v167 + v157;
                    assert("Tensor range check" && 0 <= v162 && v162 < 8l);
                    long v169;
                    v169 = 1152l * v162;
                    long v170;
                    v170 = v169 + v159;
                    assert("Tensor range check" && 0 <= v151 && v151 < 8l);
                    assert("Tensor range check" && 0 <= v162 && v162 < 8l);
                    long v171;
                    v171 = 8l * v151;
                    long v172;
                    v172 = v171 + v162;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v173 = v137[v172];
                    float * v174;
                    v174 = v8 + v168;
                    wmma::load_matrix_sync(v173, v174, 8l);
                    #pragma unroll
                    for (int t = 0; t < v173.num_elements; t++) { v173.x[t] = wmma::__float_to_tf32(v173.x[t]); };
                    assert("Tensor range check" && 0 <= v150 && v150 < 1l);
                    assert("Tensor range check" && 0 <= v162 && v162 < 8l);
                    long v175;
                    v175 = 8l * v150;
                    long v176;
                    v176 = v175 + v162;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v177 = v138[v176];
                    float * v178;
                    v178 = v11 + v170;
                    wmma::load_matrix_sync(v177, v178, 16l);
                    #pragma unroll
                    for (int t = 0; t < v177.num_elements; t++) { v177.x[t] = wmma::__float_to_tf32(v177.x[t]); };
                    v160 += 1l ;
                }
                v148 += 1l ;
            }
            v3.sync() ;
            switch (v74.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    long v179 = v74.v.case1.v0;
                    assert("Tensor range check" && 0 <= v179 && v179 < 8l);
                    long v180;
                    v180 = 64l * v179;
                    long v181;
                    v181 = v180 + v41;
                    assert("Tensor range check" && 0 <= v179 && v179 < 8l);
                    long v182;
                    v182 = 32768l * v179;
                    long v183;
                    v183 = v182 + v42;
                    long v184;
                    v184 = v4.meta_group_size();
                    long v185;
                    v185 = v4.meta_group_rank();
                    long v186;
                    v186 = v185;
                    while (while_method_2(v186)){
                        long v188;
                        v188 = v186 % 2l;
                        long v189;
                        v189 = v186 / 2l;
                        long v190;
                        v190 = v189 % 8l;
                        long v191;
                        v191 = v189 / 8l;
                        long v192;
                        v192 = v191 % 16l;
                        long v193;
                        v193 = v191 / 16l;
                        long v194;
                        v194 = v193 % 8l;
                        long v195;
                        v195 = v193 / 8l;
                        bool v196;
                        v196 = v195 == 0l;
                        bool v197;
                        v197 = v196 == false;
                        if (v197){
                            assert("The index has to be in the range of the dimension." && v196);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v194 && v194 < 8l);
                        assert("Tensor range check" && 0 <= v192 && v192 < 16l);
                        assert("Tensor range check" && 0 <= v190 && v190 < 8l);
                        assert("Tensor range check" && 0 <= v188 && v188 < 2l);
                        long v199;
                        v199 = 4l * v188;
                        long v200;
                        v200 = v199 + v181;
                        long v201;
                        v201 = 8l * v190;
                        long v202;
                        v202 = v201 + v200;
                        long v203;
                        v203 = 512l * v192;
                        long v204;
                        v204 = v203 + v202;
                        long v205;
                        v205 = 8192l * v194;
                        long v206;
                        v206 = v205 + v204;
                        assert("Tensor range check" && 0 <= v194 && v194 < 8l);
                        assert("Tensor range check" && 0 <= v192 && v192 < 16l);
                        assert("Tensor range check" && 0 <= v190 && v190 < 8l);
                        assert("Tensor range check" && 0 <= v188 && v188 < 2l);
                        long v207;
                        v207 = 136l * v190;
                        long v208;
                        v208 = v207 + v199;
                        long v209;
                        v209 = 8l * v192;
                        long v210;
                        v210 = v209 + v208;
                        long v211;
                        v211 = 1088l * v194;
                        long v212;
                        v212 = v211 + v210;
                        cooperative_groups::memcpy_async(v4, v8 + v212, v0 + v206, sizeof(float) * 4l);
                        v186 += v184 ;
                    }
                    long v213;
                    v213 = v4.meta_group_size();
                    long v214;
                    v214 = v4.meta_group_rank();
                    long v215;
                    v215 = v214;
                    while (while_method_2(v215)){
                        long v217;
                        v217 = v215 % 4l;
                        long v218;
                        v218 = v215 / 4l;
                        long v219;
                        v219 = v218 % 8l;
                        long v220;
                        v220 = v218 / 8l;
                        long v221;
                        v221 = v220 % 8l;
                        long v222;
                        v222 = v220 / 8l;
                        long v223;
                        v223 = v222 % 8l;
                        long v224;
                        v224 = v222 / 8l;
                        bool v225;
                        v225 = v224 == 0l;
                        bool v226;
                        v226 = v225 == false;
                        if (v226){
                            assert("The index has to be in the range of the dimension." && v225);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v223 && v223 < 8l);
                        assert("Tensor range check" && 0 <= v221 && v221 < 8l);
                        assert("Tensor range check" && 0 <= v219 && v219 < 8l);
                        assert("Tensor range check" && 0 <= v217 && v217 < 4l);
                        long v228;
                        v228 = 4l * v217;
                        long v229;
                        v229 = v228 + v183;
                        long v230;
                        v230 = 16l * v219;
                        long v231;
                        v231 = v230 + v229;
                        long v232;
                        v232 = 512l * v221;
                        long v233;
                        v233 = v232 + v231;
                        long v234;
                        v234 = 4096l * v223;
                        long v235;
                        v235 = v234 + v233;
                        assert("Tensor range check" && 0 <= v223 && v223 < 8l);
                        assert("Tensor range check" && 0 <= v221 && v221 < 8l);
                        assert("Tensor range check" && 0 <= v219 && v219 < 8l);
                        assert("Tensor range check" && 0 <= v217 && v217 < 4l);
                        long v236;
                        v236 = 144l * v219;
                        long v237;
                        v237 = v236 + v228;
                        long v238;
                        v238 = 16l * v221;
                        long v239;
                        v239 = v238 + v237;
                        long v240;
                        v240 = 1152l * v223;
                        long v241;
                        v241 = v240 + v239;
                        cooperative_groups::memcpy_async(v4, v11 + v241, v1 + v235, sizeof(float) * 4l);
                        v215 += v213 ;
                    }
                }
            }
            long v242;
            v242 = 0l;
            while (while_method_1(v242)){
                long v244;
                v244 = v242 % 1l;
                long v245;
                v245 = v242 % 8l;
                long v246;
                v246 = v242 / 8l;
                bool v247;
                v247 = v246 == 0l;
                bool v248;
                v248 = v247 == false;
                if (v248){
                    assert("The index has to be in the range of the dimension." && v247);
                } else {
                }
                assert("Tensor range check" && 0 <= v245 && v245 < 8l);
                assert("Tensor range check" && 0 <= v244 && v244 < 1l);
                long v250;
                v250 = v245 + v244;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v251 = v45[v250];
                long v252;
                v252 = 0l;
                while (while_method_1(v252)){
                    long v254;
                    v254 = v252 % 8l;
                    long v255;
                    v255 = v252 / 8l;
                    bool v256;
                    v256 = v255 == 0l;
                    bool v257;
                    v257 = v256 == false;
                    if (v257){
                        assert("The index has to be in the range of the dimension." && v256);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v245 && v245 < 8l);
                    assert("Tensor range check" && 0 <= v254 && v254 < 8l);
                    long v259;
                    v259 = 8l * v245;
                    long v260;
                    v260 = v259 + v254;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v261 = v137[v260];
                    assert("Tensor range check" && 0 <= v244 && v244 < 1l);
                    assert("Tensor range check" && 0 <= v254 && v254 < 8l);
                    long v262;
                    v262 = 8l * v244;
                    long v263;
                    v263 = v262 + v254;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v264 = v138[v263];
                    wmma::mma_sync(v251, v261, v264, v251);
                    v252 += 1l ;
                }
                v242 += 1l ;
            }
            v3.sync() ;
            bool v265;
            v265 = false;
            v56 = v60;
            v57 = v61;
            v58 = v265;
        }
        long v266;
        v266 = v4.meta_group_size();
        long v267;
        v267 = v4.meta_group_rank();
        long v268;
        v268 = v267;
        while (while_method_3(v268)){
            long v270;
            v270 = v268 % 4l;
            long v271;
            v271 = v268 / 4l;
            long v272;
            v272 = v271 % 8l;
            long v273;
            v273 = v271 / 8l;
            long v274;
            v274 = v273 % 16l;
            long v275;
            v275 = v273 / 16l;
            long v276;
            v276 = v275 % 8l;
            long v277;
            v277 = v275 / 8l;
            bool v278;
            v278 = v277 == 0l;
            bool v279;
            v279 = v278 == false;
            if (v279){
                assert("The index has to be in the range of the dimension." && v278);
            } else {
            }
            assert("Tensor range check" && 0 <= v276 && v276 < 8l);
            assert("Tensor range check" && 0 <= v274 && v274 < 16l);
            assert("Tensor range check" && 0 <= v272 && v272 < 8l);
            assert("Tensor range check" && 0 <= v270 && v270 < 4l);
            long v281;
            v281 = 4l * v270;
            long v282;
            v282 = v281 + v43;
            long v283;
            v283 = 16l * v272;
            long v284;
            v284 = v283 + v282;
            long v285;
            v285 = 512l * v274;
            long v286;
            v286 = v285 + v284;
            long v287;
            v287 = 8192l * v276;
            long v288;
            v288 = v287 + v286;
            assert("Tensor range check" && 0 <= v276 && v276 < 8l);
            assert("Tensor range check" && 0 <= v274 && v274 < 16l);
            assert("Tensor range check" && 0 <= v272 && v272 < 8l);
            assert("Tensor range check" && 0 <= v270 && v270 < 4l);
            long v289;
            v289 = 272l * v272;
            long v290;
            v290 = v289 + v281;
            long v291;
            v291 = 16l * v274;
            long v292;
            v292 = v291 + v290;
            long v293;
            v293 = 2176l * v276;
            long v294;
            v294 = v293 + v292;
            cooperative_groups::memcpy_async(v4, v14 + v294, v2 + v288, sizeof(float) * 4l);
            v268 += v266 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v295;
        v295 = thread_block::thread_rank() / warpSize;
        long v296;
        v296 = v295 % 8l;
        long v297;
        v297 = v295 / 8l;
        long v298;
        v298 = v297 % 1l;
        bool v299;
        v299 = v297 == 0l;
        bool v300;
        v300 = v299 == false;
        if (v300){
            assert("The index has to be in the range of the dimension." && v299);
        } else {
        }
        assert("Tensor range check" && 0 <= v298 && v298 < 1l);
        assert("Tensor range check" && 0 <= v296 && v296 < 8l);
        long v302;
        v302 = 272l * v296;
        long v303;
        v303 = 2176l * v298;
        long v304;
        v304 = v303 + v302;
        long v305;
        v305 = 0l;
        while (while_method_1(v305)){
            long v307;
            v307 = v305 % 1l;
            long v308;
            v308 = v305 % 8l;
            long v309;
            v309 = v305 / 8l;
            bool v310;
            v310 = v309 == 0l;
            bool v311;
            v311 = v310 == false;
            if (v311){
                assert("The index has to be in the range of the dimension." && v310);
            } else {
            }
            assert("Tensor range check" && 0 <= v308 && v308 < 8l);
            assert("Tensor range check" && 0 <= v307 && v307 < 1l);
            long v313;
            v313 = 2176l * v307;
            long v314;
            v314 = v313 + v304;
            long v315;
            v315 = 2176l * v308;
            long v316;
            v316 = v315 + v314;
            assert("Tensor range check" && 0 <= v308 && v308 < 8l);
            assert("Tensor range check" && 0 <= v307 && v307 < 1l);
            long v317;
            v317 = v308 + v307;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v318 = v45[v317];
            assert("Tensor range check" && 0 <= v308 && v308 < 8l);
            assert("Tensor range check" && 0 <= v307 && v307 < 1l);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v319 = v44[v317];
            float * v320;
            v320 = v14 + v316;
            wmma::load_matrix_sync(v319, v320, 16l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v321 = v319;
            long v322;
            v322 = v321.num_elements;
            long v323;
            v323 = 0l;
            while (while_method_4(v322, v323)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v325 = v318;
                float v326;
                v326 = v325.x[v323];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v327 = v319;
                float v328;
                v328 = v327.x[v323];
                float v329;
                v329 = v326 + v328;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v330 = v319;
                v330.x[v323] = v329;
                v323 += 1l ;
            }
            float * v331;
            v331 = v14 + v316;
            wmma::store_matrix_sync(v331, v319, 16l, wmma::mem_row_major);
            v305 += 1l ;
        }
        v3.sync() ;
        long v332;
        v332 = v4.meta_group_size();
        long v333;
        v333 = v4.meta_group_rank();
        long v334;
        v334 = v333;
        while (while_method_3(v334)){
            long v336;
            v336 = v334 % 4l;
            long v337;
            v337 = v334 / 4l;
            long v338;
            v338 = v337 % 8l;
            long v339;
            v339 = v337 / 8l;
            long v340;
            v340 = v339 % 16l;
            long v341;
            v341 = v339 / 16l;
            long v342;
            v342 = v341 % 8l;
            long v343;
            v343 = v341 / 8l;
            bool v344;
            v344 = v343 == 0l;
            bool v345;
            v345 = v344 == false;
            if (v345){
                assert("The index has to be in the range of the dimension." && v344);
            } else {
            }
            assert("Tensor range check" && 0 <= v342 && v342 < 8l);
            assert("Tensor range check" && 0 <= v340 && v340 < 16l);
            assert("Tensor range check" && 0 <= v338 && v338 < 8l);
            assert("Tensor range check" && 0 <= v336 && v336 < 4l);
            long v347;
            v347 = 4l * v336;
            long v348;
            v348 = 272l * v338;
            long v349;
            v349 = v348 + v347;
            long v350;
            v350 = 16l * v340;
            long v351;
            v351 = v350 + v349;
            long v352;
            v352 = 2176l * v342;
            long v353;
            v353 = v352 + v351;
            assert("Tensor range check" && 0 <= v342 && v342 < 8l);
            assert("Tensor range check" && 0 <= v340 && v340 < 16l);
            assert("Tensor range check" && 0 <= v338 && v338 < 8l);
            assert("Tensor range check" && 0 <= v336 && v336 < 4l);
            long v354;
            v354 = v347 + v43;
            long v355;
            v355 = 16l * v338;
            long v356;
            v356 = v355 + v354;
            long v357;
            v357 = 512l * v340;
            long v358;
            v358 = v357 + v356;
            long v359;
            v359 = 8192l * v342;
            long v360;
            v360 = v359 + v358;
            cooperative_groups::memcpy_async(v4, v2 + v360, v14 + v353, sizeof(float) * 4l);
            v334 += v332 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        bool v361;
        v361 = false;
        v18 = v22;
        v19 = v23;
        v20 = v361;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--diag-suppress=550')
options.append('--dopt=on')
options.append('--restrict')
options.append('--define-macro=NDEBUG')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 100
    del v0
    return v1
def main():
    v0 = cp.random.normal(0,1,262144,cp.float32)
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
    v5 = cp.random.normal(0,1,262144,cp.float32)
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
    v10 = cp.random.normal(0,1,262144,cp.float32)
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
        v20 = v0.reshape((512, 512))
        v21 = (cp.matmul(v18,v19)+v20).flatten()
        del v18, v19, v20
        v22 = v21.size
        v23 = 262144 == v22
        del v22
        v24 = v23 == False
        if v24:
            v25 = "The total length of the reshaped tensor dimension must match that of the original one."
            assert v23, v25
            del v25
        else:
            pass
        del v23, v24
        v26 = 0
        v27 = raw_module.get_function(f"entry{v26}")
        del v26
        v27.max_dynamic_shared_size_bytes = 71680 
        v27((72,),(256,),(v10, v5, v0),shared_mem=71680)
        del v27
        v28 = cp.max(cp.abs(v0-v21))
        del v21
        v29 = v28 + v16
        del v28
        v16 = v29
        del v29
        v15 += 1 
    del v0, v5, v10, v15
    v30 = v16 / 100.0
    del v16
    return v30

if __name__ == '__main__': print(main())
