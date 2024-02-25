kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
struct Tuple0;
struct US0;
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
        } case1; // Some
    } v;
    char tag : 2;
};
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 64l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ inline bool while_method_2(bool v0){
    return v0;
}
__device__ US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1(long v0) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 1024l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_5(long v0, long v1){
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
    v9 = reinterpret_cast<float *>(&v5[17408ull]);
    v11 = v9;
    float * v14;
    float * v12;
    v12 = reinterpret_cast<float *>(&v5[0ull]);
    v14 = v12;
    long v15;
    v15 = grid_group::num_blocks();
    long v16;
    v16 = grid_group::block_rank();
    long v17;
    v17 = v16;
    while (while_method_0(v17)){
        long v19;
        v19 = v17 % 8l;
        long v20;
        v20 = v17 / 8l;
        long v21;
        v21 = v20 % 8l;
        long v22;
        v22 = v20 / 8l;
        bool v23;
        v23 = v22 == 0l;
        bool v24;
        v24 = v23 == false;
        if (v24){
            assert("The index has to be in the range of the dimension." && v23);
        } else {
        }
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v26[2l];
        long v27;
        v27 = 0l;
        while (while_method_1(v27)){
            long v29;
            v29 = v27 % 1l;
            long v30;
            v30 = v27 % 2l;
            long v31;
            v31 = v27 / 2l;
            bool v32;
            v32 = v31 == 0l;
            bool v33;
            v33 = v32 == false;
            if (v33){
                assert("The index has to be in the range of the dimension." && v32);
            } else {
            }
            assert("Tensor range check" && 0 <= v30 && v30 < 2l);
            assert("Tensor range check" && 0 <= v29 && v29 < 1l);
            long v35;
            v35 = v30 + v29;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v36 = v26[v35];
            wmma::fill_fragment(v36, 0.0f);
            v27 += 1l ;
        }
        assert("Tensor range check" && 0 <= v21 && v21 < 8l);
        long v37;
        v37 = 32768l * v21;
        assert("Tensor range check" && 0 <= v19 && v19 < 8l);
        long v38;
        v38 = 32768l * v19;
        assert("Tensor range check" && 0 <= v21 && v21 < 8l);
        assert("Tensor range check" && 0 <= v19 && v19 < 8l);
        long v39;
        v39 = 64l * v19;
        long v40;
        v40 = v37 + v39;
        long v41; bool v42; bool v43;
        Tuple0 tmp0 = Tuple0(0l, true, true);
        v41 = tmp0.v0; v42 = tmp0.v1; v43 = tmp0.v2;
        while (while_method_2(v42)){
            long v45;
            v45 = v41 + 1l;
            bool v46;
            v46 = v45 < 8l;
            long v47;
            v47 = v41 % 8l;
            long v48;
            v48 = v41 / 8l;
            bool v49;
            v49 = v48 == 0l;
            bool v50;
            v50 = v49 == false;
            if (v50){
                assert("The index has to be in the range of the dimension." && v49);
            } else {
            }
            US0 v59;
            if (v46){
                long v52;
                v52 = v45 % 8l;
                long v53;
                v53 = v45 / 8l;
                bool v54;
                v54 = v53 == 0l;
                bool v55;
                v55 = v54 == false;
                if (v55){
                    assert("The index has to be in the range of the dimension." && v54);
                } else {
                }
                v59 = US0_1(v52);
            } else {
                v59 = US0_0();
            }
            if (v43){
                assert("Tensor range check" && 0 <= v47 && v47 < 8l);
                long v60;
                v60 = 64l * v47;
                long v61;
                v61 = v60 + v37;
                assert("Tensor range check" && 0 <= v47 && v47 < 8l);
                long v62;
                v62 = v60 + v38;
                long v63;
                v63 = v4.meta_group_size();
                long v64;
                v64 = v4.meta_group_rank();
                long v65;
                v65 = v64;
                while (while_method_3(v65)){
                    long v67;
                    v67 = v65 % 2l;
                    long v68;
                    v68 = v65 / 2l;
                    long v69;
                    v69 = v68 % 8l;
                    long v70;
                    v70 = v68 / 8l;
                    long v71;
                    v71 = v70 % 16l;
                    long v72;
                    v72 = v70 / 16l;
                    long v73;
                    v73 = v72 % 4l;
                    long v74;
                    v74 = v72 / 4l;
                    bool v75;
                    v75 = v74 == 0l;
                    bool v76;
                    v76 = v75 == false;
                    if (v76){
                        assert("The index has to be in the range of the dimension." && v75);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v73 && v73 < 4l);
                    assert("Tensor range check" && 0 <= v71 && v71 < 16l);
                    assert("Tensor range check" && 0 <= v69 && v69 < 8l);
                    assert("Tensor range check" && 0 <= v67 && v67 < 2l);
                    long v78;
                    v78 = 4l * v67;
                    long v79;
                    v79 = v78 + v61;
                    long v80;
                    v80 = 8l * v69;
                    long v81;
                    v81 = v80 + v79;
                    long v82;
                    v82 = 512l * v71;
                    long v83;
                    v83 = v82 + v81;
                    long v84;
                    v84 = 8192l * v73;
                    long v85;
                    v85 = v84 + v83;
                    assert("Tensor range check" && 0 <= v73 && v73 < 4l);
                    assert("Tensor range check" && 0 <= v71 && v71 < 16l);
                    assert("Tensor range check" && 0 <= v69 && v69 < 8l);
                    assert("Tensor range check" && 0 <= v67 && v67 < 2l);
                    long v86;
                    v86 = 136l * v69;
                    long v87;
                    v87 = v86 + v78;
                    long v88;
                    v88 = 8l * v71;
                    long v89;
                    v89 = v88 + v87;
                    long v90;
                    v90 = 1088l * v73;
                    long v91;
                    v91 = v90 + v89;
                    cooperative_groups::memcpy_async(v4, v8 + v91, v0 + v85, sizeof(float) * 4l);
                    v65 += v63 ;
                }
                long v92;
                v92 = v4.meta_group_size();
                long v93;
                v93 = v4.meta_group_rank();
                long v94;
                v94 = v93;
                while (while_method_3(v94)){
                    long v96;
                    v96 = v94 % 2l;
                    long v97;
                    v97 = v94 / 2l;
                    long v98;
                    v98 = v97 % 8l;
                    long v99;
                    v99 = v97 / 8l;
                    long v100;
                    v100 = v99 % 16l;
                    long v101;
                    v101 = v99 / 16l;
                    long v102;
                    v102 = v101 % 4l;
                    long v103;
                    v103 = v101 / 4l;
                    bool v104;
                    v104 = v103 == 0l;
                    bool v105;
                    v105 = v104 == false;
                    if (v105){
                        assert("The index has to be in the range of the dimension." && v104);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v102 && v102 < 4l);
                    assert("Tensor range check" && 0 <= v100 && v100 < 16l);
                    assert("Tensor range check" && 0 <= v98 && v98 < 8l);
                    assert("Tensor range check" && 0 <= v96 && v96 < 2l);
                    long v107;
                    v107 = 4l * v96;
                    long v108;
                    v108 = v107 + v62;
                    long v109;
                    v109 = 8l * v98;
                    long v110;
                    v110 = v109 + v108;
                    long v111;
                    v111 = 512l * v100;
                    long v112;
                    v112 = v111 + v110;
                    long v113;
                    v113 = 8192l * v102;
                    long v114;
                    v114 = v113 + v112;
                    assert("Tensor range check" && 0 <= v102 && v102 < 4l);
                    assert("Tensor range check" && 0 <= v100 && v100 < 16l);
                    assert("Tensor range check" && 0 <= v98 && v98 < 8l);
                    assert("Tensor range check" && 0 <= v96 && v96 < 2l);
                    long v115;
                    v115 = 136l * v98;
                    long v116;
                    v116 = v115 + v107;
                    long v117;
                    v117 = 8l * v100;
                    long v118;
                    v118 = v117 + v116;
                    long v119;
                    v119 = 1088l * v102;
                    long v120;
                    v120 = v119 + v118;
                    cooperative_groups::memcpy_async(v4, v11 + v120, v1 + v114, sizeof(float) * 4l);
                    v94 += v92 ;
                }
            } else {
            }
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v121[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v122[8l];
            long v123;
            v123 = thread_block::thread_rank() / warpSize;
            long v124;
            v124 = v123 % 4l;
            long v125;
            v125 = v123 / 4l;
            long v126;
            v126 = v125 % 2l;
            long v127;
            v127 = v125 / 2l;
            bool v128;
            v128 = v127 == 0l;
            bool v129;
            v129 = v128 == false;
            if (v129){
                assert("The index has to be in the range of the dimension." && v128);
            } else {
            }
            assert("Tensor range check" && 0 <= v126 && v126 < 2l);
            long v131;
            v131 = 1088l * v126;
            assert("Tensor range check" && 0 <= v124 && v124 < 4l);
            long v132;
            v132 = 1088l * v124;
            cooperative_groups::wait(v4);
            v3.sync() ;
            long v133;
            v133 = 0l;
            while (while_method_1(v133)){
                long v135;
                v135 = v133 % 1l;
                long v136;
                v136 = v133 % 2l;
                long v137;
                v137 = v133 / 2l;
                bool v138;
                v138 = v137 == 0l;
                bool v139;
                v139 = v138 == false;
                if (v139){
                    assert("The index has to be in the range of the dimension." && v138);
                } else {
                }
                assert("Tensor range check" && 0 <= v136 && v136 < 2l);
                long v141;
                v141 = 2176l * v136;
                long v142;
                v142 = v141 + v131;
                assert("Tensor range check" && 0 <= v135 && v135 < 1l);
                long v143;
                v143 = 4352l * v135;
                long v144;
                v144 = v143 + v132;
                long v145;
                v145 = 0l;
                while (while_method_4(v145)){
                    long v147;
                    v147 = v145 % 8l;
                    long v148;
                    v148 = v145 / 8l;
                    bool v149;
                    v149 = v148 == 0l;
                    bool v150;
                    v150 = v149 == false;
                    if (v150){
                        assert("The index has to be in the range of the dimension." && v149);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v147 && v147 < 8l);
                    long v152;
                    v152 = 136l * v147;
                    long v153;
                    v153 = v152 + v142;
                    assert("Tensor range check" && 0 <= v147 && v147 < 8l);
                    long v154;
                    v154 = v152 + v144;
                    assert("Tensor range check" && 0 <= v136 && v136 < 2l);
                    assert("Tensor range check" && 0 <= v147 && v147 < 8l);
                    long v155;
                    v155 = 8l * v136;
                    long v156;
                    v156 = v155 + v147;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v157 = v121[v156];
                    float * v158;
                    v158 = v8 + v153;
                    wmma::load_matrix_sync(v157, v158, 8l);
                    #pragma unroll
                    for (int t = 0; t < v157.num_elements; t++) { v157.x[t] = wmma::__float_to_tf32(v157.x[t]); };
                    assert("Tensor range check" && 0 <= v135 && v135 < 1l);
                    assert("Tensor range check" && 0 <= v147 && v147 < 8l);
                    long v159;
                    v159 = 8l * v135;
                    long v160;
                    v160 = v159 + v147;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v161 = v122[v160];
                    float * v162;
                    v162 = v11 + v154;
                    wmma::load_matrix_sync(v161, v162, 8l);
                    #pragma unroll
                    for (int t = 0; t < v161.num_elements; t++) { v161.x[t] = wmma::__float_to_tf32(v161.x[t]); };
                    v145 += 1l ;
                }
                v133 += 1l ;
            }
            v3.sync() ;
            switch (v59.tag) {
                case 0: { // None
                    long v225;
                    v225 = v4.meta_group_size();
                    long v226;
                    v226 = v4.meta_group_rank();
                    long v227;
                    v227 = v226;
                    while (while_method_3(v227)){
                        long v229;
                        v229 = v227 % 4l;
                        long v230;
                        v230 = v227 / 4l;
                        long v231;
                        v231 = v230 % 4l;
                        long v232;
                        v232 = v230 / 4l;
                        long v233;
                        v233 = v232 % 16l;
                        long v234;
                        v234 = v232 / 16l;
                        long v235;
                        v235 = v234 % 4l;
                        long v236;
                        v236 = v234 / 4l;
                        bool v237;
                        v237 = v236 == 0l;
                        bool v238;
                        v238 = v237 == false;
                        if (v238){
                            assert("The index has to be in the range of the dimension." && v237);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v235 && v235 < 4l);
                        assert("Tensor range check" && 0 <= v233 && v233 < 16l);
                        assert("Tensor range check" && 0 <= v231 && v231 < 4l);
                        assert("Tensor range check" && 0 <= v229 && v229 < 4l);
                        long v240;
                        v240 = 4l * v229;
                        long v241;
                        v241 = v240 + v40;
                        long v242;
                        v242 = 16l * v231;
                        long v243;
                        v243 = v242 + v241;
                        long v244;
                        v244 = 512l * v233;
                        long v245;
                        v245 = v244 + v243;
                        long v246;
                        v246 = 8192l * v235;
                        long v247;
                        v247 = v246 + v245;
                        assert("Tensor range check" && 0 <= v235 && v235 < 4l);
                        assert("Tensor range check" && 0 <= v233 && v233 < 16l);
                        assert("Tensor range check" && 0 <= v231 && v231 < 4l);
                        assert("Tensor range check" && 0 <= v229 && v229 < 4l);
                        long v248;
                        v248 = 272l * v231;
                        long v249;
                        v249 = v248 + v240;
                        long v250;
                        v250 = 16l * v233;
                        long v251;
                        v251 = v250 + v249;
                        long v252;
                        v252 = 1088l * v235;
                        long v253;
                        v253 = v252 + v251;
                        cooperative_groups::memcpy_async(v4, v14 + v253, v2 + v247, sizeof(float) * 4l);
                        v227 += v225 ;
                    }
                    break;
                }
                default: { // Some
                    long v163 = v59.v.case1.v0;
                    assert("Tensor range check" && 0 <= v163 && v163 < 8l);
                    long v164;
                    v164 = 64l * v163;
                    long v165;
                    v165 = v164 + v37;
                    assert("Tensor range check" && 0 <= v163 && v163 < 8l);
                    long v166;
                    v166 = v164 + v38;
                    long v167;
                    v167 = v4.meta_group_size();
                    long v168;
                    v168 = v4.meta_group_rank();
                    long v169;
                    v169 = v168;
                    while (while_method_3(v169)){
                        long v171;
                        v171 = v169 % 2l;
                        long v172;
                        v172 = v169 / 2l;
                        long v173;
                        v173 = v172 % 8l;
                        long v174;
                        v174 = v172 / 8l;
                        long v175;
                        v175 = v174 % 16l;
                        long v176;
                        v176 = v174 / 16l;
                        long v177;
                        v177 = v176 % 4l;
                        long v178;
                        v178 = v176 / 4l;
                        bool v179;
                        v179 = v178 == 0l;
                        bool v180;
                        v180 = v179 == false;
                        if (v180){
                            assert("The index has to be in the range of the dimension." && v179);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v177 && v177 < 4l);
                        assert("Tensor range check" && 0 <= v175 && v175 < 16l);
                        assert("Tensor range check" && 0 <= v173 && v173 < 8l);
                        assert("Tensor range check" && 0 <= v171 && v171 < 2l);
                        long v182;
                        v182 = 4l * v171;
                        long v183;
                        v183 = v182 + v165;
                        long v184;
                        v184 = 8l * v173;
                        long v185;
                        v185 = v184 + v183;
                        long v186;
                        v186 = 512l * v175;
                        long v187;
                        v187 = v186 + v185;
                        long v188;
                        v188 = 8192l * v177;
                        long v189;
                        v189 = v188 + v187;
                        assert("Tensor range check" && 0 <= v177 && v177 < 4l);
                        assert("Tensor range check" && 0 <= v175 && v175 < 16l);
                        assert("Tensor range check" && 0 <= v173 && v173 < 8l);
                        assert("Tensor range check" && 0 <= v171 && v171 < 2l);
                        long v190;
                        v190 = 136l * v173;
                        long v191;
                        v191 = v190 + v182;
                        long v192;
                        v192 = 8l * v175;
                        long v193;
                        v193 = v192 + v191;
                        long v194;
                        v194 = 1088l * v177;
                        long v195;
                        v195 = v194 + v193;
                        cooperative_groups::memcpy_async(v4, v8 + v195, v0 + v189, sizeof(float) * 4l);
                        v169 += v167 ;
                    }
                    long v196;
                    v196 = v4.meta_group_size();
                    long v197;
                    v197 = v4.meta_group_rank();
                    long v198;
                    v198 = v197;
                    while (while_method_3(v198)){
                        long v200;
                        v200 = v198 % 2l;
                        long v201;
                        v201 = v198 / 2l;
                        long v202;
                        v202 = v201 % 8l;
                        long v203;
                        v203 = v201 / 8l;
                        long v204;
                        v204 = v203 % 16l;
                        long v205;
                        v205 = v203 / 16l;
                        long v206;
                        v206 = v205 % 4l;
                        long v207;
                        v207 = v205 / 4l;
                        bool v208;
                        v208 = v207 == 0l;
                        bool v209;
                        v209 = v208 == false;
                        if (v209){
                            assert("The index has to be in the range of the dimension." && v208);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v206 && v206 < 4l);
                        assert("Tensor range check" && 0 <= v204 && v204 < 16l);
                        assert("Tensor range check" && 0 <= v202 && v202 < 8l);
                        assert("Tensor range check" && 0 <= v200 && v200 < 2l);
                        long v211;
                        v211 = 4l * v200;
                        long v212;
                        v212 = v211 + v166;
                        long v213;
                        v213 = 8l * v202;
                        long v214;
                        v214 = v213 + v212;
                        long v215;
                        v215 = 512l * v204;
                        long v216;
                        v216 = v215 + v214;
                        long v217;
                        v217 = 8192l * v206;
                        long v218;
                        v218 = v217 + v216;
                        assert("Tensor range check" && 0 <= v206 && v206 < 4l);
                        assert("Tensor range check" && 0 <= v204 && v204 < 16l);
                        assert("Tensor range check" && 0 <= v202 && v202 < 8l);
                        assert("Tensor range check" && 0 <= v200 && v200 < 2l);
                        long v219;
                        v219 = 136l * v202;
                        long v220;
                        v220 = v219 + v211;
                        long v221;
                        v221 = 8l * v204;
                        long v222;
                        v222 = v221 + v220;
                        long v223;
                        v223 = 1088l * v206;
                        long v224;
                        v224 = v223 + v222;
                        cooperative_groups::memcpy_async(v4, v11 + v224, v1 + v218, sizeof(float) * 4l);
                        v198 += v196 ;
                    }
                }
            }
            long v254;
            v254 = 0l;
            while (while_method_1(v254)){
                long v256;
                v256 = v254 % 1l;
                long v257;
                v257 = v254 % 2l;
                long v258;
                v258 = v254 / 2l;
                bool v259;
                v259 = v258 == 0l;
                bool v260;
                v260 = v259 == false;
                if (v260){
                    assert("The index has to be in the range of the dimension." && v259);
                } else {
                }
                assert("Tensor range check" && 0 <= v257 && v257 < 2l);
                assert("Tensor range check" && 0 <= v256 && v256 < 1l);
                long v262;
                v262 = v257 + v256;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v263 = v26[v262];
                long v264;
                v264 = 0l;
                while (while_method_4(v264)){
                    long v266;
                    v266 = v264 % 8l;
                    long v267;
                    v267 = v264 / 8l;
                    bool v268;
                    v268 = v267 == 0l;
                    bool v269;
                    v269 = v268 == false;
                    if (v269){
                        assert("The index has to be in the range of the dimension." && v268);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v257 && v257 < 2l);
                    assert("Tensor range check" && 0 <= v266 && v266 < 8l);
                    long v271;
                    v271 = 8l * v257;
                    long v272;
                    v272 = v271 + v266;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v273 = v121[v272];
                    assert("Tensor range check" && 0 <= v256 && v256 < 1l);
                    assert("Tensor range check" && 0 <= v266 && v266 < 8l);
                    long v274;
                    v274 = 8l * v256;
                    long v275;
                    v275 = v274 + v266;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v276 = v122[v275];
                    wmma::mma_sync(v263, v273, v276, v263);
                    v264 += 1l ;
                }
                v254 += 1l ;
            }
            bool v277;
            v277 = false;
            v41 = v45;
            v42 = v46;
            v43 = v277;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v278;
        v278 = thread_block::thread_rank() / warpSize;
        long v279;
        v279 = v278 % 4l;
        long v280;
        v280 = v278 / 4l;
        long v281;
        v281 = v280 % 2l;
        long v282;
        v282 = v280 / 2l;
        bool v283;
        v283 = v282 == 0l;
        bool v284;
        v284 = v283 == false;
        if (v284){
            assert("The index has to be in the range of the dimension." && v283);
        } else {
        }
        assert("Tensor range check" && 0 <= v281 && v281 < 2l);
        assert("Tensor range check" && 0 <= v279 && v279 < 4l);
        long v286;
        v286 = 272l * v279;
        long v287;
        v287 = 1088l * v281;
        long v288;
        v288 = v287 + v286;
        long v289;
        v289 = 0l;
        while (while_method_1(v289)){
            long v291;
            v291 = v289 % 1l;
            long v292;
            v292 = v289 % 2l;
            long v293;
            v293 = v289 / 2l;
            bool v294;
            v294 = v293 == 0l;
            bool v295;
            v295 = v294 == false;
            if (v295){
                assert("The index has to be in the range of the dimension." && v294);
            } else {
            }
            assert("Tensor range check" && 0 <= v292 && v292 < 2l);
            assert("Tensor range check" && 0 <= v291 && v291 < 1l);
            long v297;
            v297 = v292 + v291;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v298 = v26[v297];
            assert("Tensor range check" && 0 <= v292 && v292 < 2l);
            assert("Tensor range check" && 0 <= v291 && v291 < 1l);
            long v299;
            v299 = 1088l * v291;
            long v300;
            v300 = v299 + v288;
            long v301;
            v301 = 2176l * v292;
            long v302;
            v302 = v301 + v300;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v303;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v304 = v303;
            float * v305;
            v305 = v14 + v302;
            wmma::load_matrix_sync(v304, v305, 16l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v306 = v298;
            long v307;
            v307 = v306.num_elements;
            long v308;
            v308 = 0l;
            while (while_method_5(v307, v308)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v310 = v298;
                float v311;
                v311 = v310.x[v308];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v312 = v304;
                float v313;
                v313 = v312.x[v308];
                float v314;
                v314 = v311 + v313;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v315 = v298;
                v315.x[v308] = v314;
                v308 += 1l ;
            }
            float * v316;
            v316 = v14 + v302;
            wmma::store_matrix_sync(v316, v298, 16l, wmma::mem_row_major);
            v289 += 1l ;
        }
        v3.sync() ;
        long v317;
        v317 = v4.meta_group_size();
        long v318;
        v318 = v4.meta_group_rank();
        long v319;
        v319 = v318;
        while (while_method_3(v319)){
            long v321;
            v321 = v319 % 4l;
            long v322;
            v322 = v319 / 4l;
            long v323;
            v323 = v322 % 4l;
            long v324;
            v324 = v322 / 4l;
            long v325;
            v325 = v324 % 16l;
            long v326;
            v326 = v324 / 16l;
            long v327;
            v327 = v326 % 4l;
            long v328;
            v328 = v326 / 4l;
            bool v329;
            v329 = v328 == 0l;
            bool v330;
            v330 = v329 == false;
            if (v330){
                assert("The index has to be in the range of the dimension." && v329);
            } else {
            }
            assert("Tensor range check" && 0 <= v327 && v327 < 4l);
            assert("Tensor range check" && 0 <= v325 && v325 < 16l);
            assert("Tensor range check" && 0 <= v323 && v323 < 4l);
            assert("Tensor range check" && 0 <= v321 && v321 < 4l);
            long v332;
            v332 = 4l * v321;
            long v333;
            v333 = 272l * v323;
            long v334;
            v334 = v333 + v332;
            long v335;
            v335 = 16l * v325;
            long v336;
            v336 = v335 + v334;
            long v337;
            v337 = 1088l * v327;
            long v338;
            v338 = v337 + v336;
            assert("Tensor range check" && 0 <= v327 && v327 < 4l);
            assert("Tensor range check" && 0 <= v325 && v325 < 16l);
            assert("Tensor range check" && 0 <= v323 && v323 < 4l);
            assert("Tensor range check" && 0 <= v321 && v321 < 4l);
            long v339;
            v339 = v332 + v40;
            long v340;
            v340 = 16l * v323;
            long v341;
            v341 = v340 + v339;
            long v342;
            v342 = 512l * v325;
            long v343;
            v343 = v342 + v341;
            long v344;
            v344 = 8192l * v327;
            long v345;
            v345 = v344 + v343;
            cooperative_groups::memcpy_async(v4, v2 + v345, v14 + v338, sizeof(float) * 4l);
            v319 += v317 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        v17 += v15 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

from max_blocks_per_sm import max_blocks_per_sm
options = []
options.append('--diag-suppress=550')
options.append('--dopt=on')
options.append('--restrict')
options.append('--define-macro=NDEBUG')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
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
        v27 = v15 == 0
        if v27:
            max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),256,is_print=True)
        else:
            pass
        del v27
        v28 = 0
        v29 = raw_module.get_function(f"entry{v28}")
        del v28
        v29.max_dynamic_shared_size_bytes = 34816 
        v29((1,),(256,),(v10, v5, v0),shared_mem=34816)
        del v29
        v30 = cp.max(cp.abs(v0-v22))
        del v22
        v31 = v30 + v16
        del v30
        v16 = v31
        del v31
        v15 += 1 
    del v0, v5, v10, v15
    return v16

if __name__ == '__main__': print(main())
