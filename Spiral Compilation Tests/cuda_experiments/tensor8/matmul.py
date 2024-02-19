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
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 8l;
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
    v1 = v0 < 2048l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 4096l;
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
    long v17;
    v17 = v16;
    while (while_method_0(v17)){
        long v19;
        v19 = v17 % 2l;
        long v20;
        v20 = v17 / 2l;
        long v21;
        v21 = v20 % 2l;
        long v22;
        v22 = v20 / 2l;
        bool v23;
        v23 = v22 == 0l;
        bool v24;
        v24 = v23 == false;
        if (v24){
            assert("The index has to be in the range of the dimension." && v23);
        } else {
        }
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v26[8l];
        long v27;
        v27 = 0l;
        while (while_method_1(v27)){
            long v29;
            v29 = v27 % 1l;
            long v30;
            v30 = v27 % 8l;
            long v31;
            v31 = v27 / 8l;
            bool v32;
            v32 = v31 == 0l;
            bool v33;
            v33 = v32 == false;
            if (v33){
                assert("The index has to be in the range of the dimension." && v32);
            } else {
            }
            assert("Tensor range check" && 0 <= v30 && v30 < 8l);
            assert("Tensor range check" && 0 <= v29 && v29 < 1l);
            long v35;
            v35 = v30 + v29;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v36 = v26[v35];
            wmma::fill_fragment(v36, 0.0f);
            v27 += 1l ;
        }
        assert("Tensor range check" && 0 <= v21 && v21 < 2l);
        long v37;
        v37 = 32768l * v21;
        assert("Tensor range check" && 0 <= v19 && v19 < 2l);
        long v38;
        v38 = 128l * v19;
        assert("Tensor range check" && 0 <= v21 && v21 < 2l);
        assert("Tensor range check" && 0 <= v19 && v19 < 2l);
        long v39;
        v39 = v37 + v38;
        long v40; bool v41; bool v42;
        Tuple0 tmp0 = Tuple0(0l, true, true);
        v40 = tmp0.v0; v41 = tmp0.v1; v42 = tmp0.v2;
        while (while_method_2(v41)){
            long v44;
            v44 = v40 + 1l;
            bool v45;
            v45 = v44 < 4l;
            long v46;
            v46 = v40 % 4l;
            long v47;
            v47 = v40 / 4l;
            bool v48;
            v48 = v47 == 0l;
            bool v49;
            v49 = v48 == false;
            if (v49){
                assert("The index has to be in the range of the dimension." && v48);
            } else {
            }
            US0 v58;
            if (v45){
                long v51;
                v51 = v44 % 4l;
                long v52;
                v52 = v44 / 4l;
                bool v53;
                v53 = v52 == 0l;
                bool v54;
                v54 = v53 == false;
                if (v54){
                    assert("The index has to be in the range of the dimension." && v53);
                } else {
                }
                v58 = US0_1(v51);
            } else {
                v58 = US0_0();
            }
            if (v42){
                assert("Tensor range check" && 0 <= v46 && v46 < 4l);
                long v59;
                v59 = 64l * v46;
                long v60;
                v60 = v59 + v37;
                assert("Tensor range check" && 0 <= v46 && v46 < 4l);
                long v61;
                v61 = 16384l * v46;
                long v62;
                v62 = v61 + v38;
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
                    v73 = v72 % 8l;
                    long v74;
                    v74 = v72 / 8l;
                    bool v75;
                    v75 = v74 == 0l;
                    bool v76;
                    v76 = v75 == false;
                    if (v76){
                        assert("The index has to be in the range of the dimension." && v75);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v73 && v73 < 8l);
                    assert("Tensor range check" && 0 <= v71 && v71 < 16l);
                    assert("Tensor range check" && 0 <= v69 && v69 < 8l);
                    assert("Tensor range check" && 0 <= v67 && v67 < 2l);
                    long v78;
                    v78 = 4l * v67;
                    long v79;
                    v79 = v78 + v60;
                    long v80;
                    v80 = 8l * v69;
                    long v81;
                    v81 = v80 + v79;
                    long v82;
                    v82 = 256l * v71;
                    long v83;
                    v83 = v82 + v81;
                    long v84;
                    v84 = 4096l * v73;
                    long v85;
                    v85 = v84 + v83;
                    assert("Tensor range check" && 0 <= v73 && v73 < 8l);
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
                    v96 = v94 % 4l;
                    long v97;
                    v97 = v94 / 4l;
                    long v98;
                    v98 = v97 % 8l;
                    long v99;
                    v99 = v97 / 8l;
                    long v100;
                    v100 = v99 % 8l;
                    long v101;
                    v101 = v99 / 8l;
                    long v102;
                    v102 = v101 % 8l;
                    long v103;
                    v103 = v101 / 8l;
                    bool v104;
                    v104 = v103 == 0l;
                    bool v105;
                    v105 = v104 == false;
                    if (v105){
                        assert("The index has to be in the range of the dimension." && v104);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v102 && v102 < 8l);
                    assert("Tensor range check" && 0 <= v100 && v100 < 8l);
                    assert("Tensor range check" && 0 <= v98 && v98 < 8l);
                    assert("Tensor range check" && 0 <= v96 && v96 < 4l);
                    long v107;
                    v107 = 4l * v96;
                    long v108;
                    v108 = v107 + v62;
                    long v109;
                    v109 = 16l * v98;
                    long v110;
                    v110 = v109 + v108;
                    long v111;
                    v111 = 256l * v100;
                    long v112;
                    v112 = v111 + v110;
                    long v113;
                    v113 = 2048l * v102;
                    long v114;
                    v114 = v113 + v112;
                    assert("Tensor range check" && 0 <= v102 && v102 < 8l);
                    assert("Tensor range check" && 0 <= v100 && v100 < 8l);
                    assert("Tensor range check" && 0 <= v98 && v98 < 8l);
                    assert("Tensor range check" && 0 <= v96 && v96 < 4l);
                    long v115;
                    v115 = 144l * v98;
                    long v116;
                    v116 = v115 + v107;
                    long v117;
                    v117 = 16l * v100;
                    long v118;
                    v118 = v117 + v116;
                    long v119;
                    v119 = 1152l * v102;
                    long v120;
                    v120 = v119 + v118;
                    cooperative_groups::memcpy_async(v4, v11 + v120, v1 + v114, sizeof(float) * 4l);
                    v94 += v92 ;
                }
                cooperative_groups::wait(v4);
                v3.sync() ;
            } else {
            }
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v121[64l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v122[8l];
            long v123;
            v123 = thread_block::thread_rank() / warpSize;
            long v124;
            v124 = v123 % 8l;
            long v125;
            v125 = v123 / 8l;
            long v126;
            v126 = v125 % 1l;
            bool v127;
            v127 = v125 == 0l;
            bool v128;
            v128 = v127 == false;
            if (v128){
                assert("The index has to be in the range of the dimension." && v127);
            } else {
            }
            assert("Tensor range check" && 0 <= v126 && v126 < 1l);
            long v130;
            v130 = 1088l * v126;
            assert("Tensor range check" && 0 <= v124 && v124 < 8l);
            long v131;
            v131 = 144l * v124;
            long v132;
            v132 = 0l;
            while (while_method_1(v132)){
                long v134;
                v134 = v132 % 1l;
                long v135;
                v135 = v132 % 8l;
                long v136;
                v136 = v132 / 8l;
                bool v137;
                v137 = v136 == 0l;
                bool v138;
                v138 = v137 == false;
                if (v138){
                    assert("The index has to be in the range of the dimension." && v137);
                } else {
                }
                assert("Tensor range check" && 0 <= v135 && v135 < 8l);
                long v140;
                v140 = 1088l * v135;
                long v141;
                v141 = v140 + v130;
                assert("Tensor range check" && 0 <= v134 && v134 < 1l);
                long v142;
                v142 = 1152l * v134;
                long v143;
                v143 = v142 + v131;
                long v144;
                v144 = 0l;
                while (while_method_1(v144)){
                    long v146;
                    v146 = v144 % 8l;
                    long v147;
                    v147 = v144 / 8l;
                    bool v148;
                    v148 = v147 == 0l;
                    bool v149;
                    v149 = v148 == false;
                    if (v149){
                        assert("The index has to be in the range of the dimension." && v148);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v146 && v146 < 8l);
                    long v151;
                    v151 = 136l * v146;
                    long v152;
                    v152 = v151 + v141;
                    assert("Tensor range check" && 0 <= v146 && v146 < 8l);
                    long v153;
                    v153 = 1152l * v146;
                    long v154;
                    v154 = v153 + v143;
                    assert("Tensor range check" && 0 <= v135 && v135 < 8l);
                    assert("Tensor range check" && 0 <= v146 && v146 < 8l);
                    long v155;
                    v155 = 8l * v135;
                    long v156;
                    v156 = v155 + v146;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v157 = v121[v156];
                    float * v158;
                    v158 = v8 + v152;
                    wmma::load_matrix_sync(v157, v158, 8l);
                    #pragma unroll
                    for (int t = 0; t < v157.num_elements; t++) { v157.x[t] = wmma::__float_to_tf32(v157.x[t]); };
                    assert("Tensor range check" && 0 <= v134 && v134 < 1l);
                    assert("Tensor range check" && 0 <= v146 && v146 < 8l);
                    long v159;
                    v159 = 8l * v134;
                    long v160;
                    v160 = v159 + v146;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v161 = v122[v160];
                    float * v162;
                    v162 = v11 + v154;
                    wmma::load_matrix_sync(v161, v162, 16l);
                    #pragma unroll
                    for (int t = 0; t < v161.num_elements; t++) { v161.x[t] = wmma::__float_to_tf32(v161.x[t]); };
                    v144 += 1l ;
                }
                v132 += 1l ;
            }
            v3.sync() ;
            switch (v58.tag) {
                case 0: { // None
                    long v226;
                    v226 = v4.meta_group_size();
                    long v227;
                    v227 = v4.meta_group_rank();
                    long v228;
                    v228 = v227;
                    while (while_method_4(v228)){
                        long v230;
                        v230 = v228 % 4l;
                        long v231;
                        v231 = v228 / 4l;
                        long v232;
                        v232 = v231 % 8l;
                        long v233;
                        v233 = v231 / 8l;
                        long v234;
                        v234 = v233 % 16l;
                        long v235;
                        v235 = v233 / 16l;
                        long v236;
                        v236 = v235 % 8l;
                        long v237;
                        v237 = v235 / 8l;
                        bool v238;
                        v238 = v237 == 0l;
                        bool v239;
                        v239 = v238 == false;
                        if (v239){
                            assert("The index has to be in the range of the dimension." && v238);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v236 && v236 < 8l);
                        assert("Tensor range check" && 0 <= v234 && v234 < 16l);
                        assert("Tensor range check" && 0 <= v232 && v232 < 8l);
                        assert("Tensor range check" && 0 <= v230 && v230 < 4l);
                        long v241;
                        v241 = 4l * v230;
                        long v242;
                        v242 = v241 + v39;
                        long v243;
                        v243 = 16l * v232;
                        long v244;
                        v244 = v243 + v242;
                        long v245;
                        v245 = 256l * v234;
                        long v246;
                        v246 = v245 + v244;
                        long v247;
                        v247 = 4096l * v236;
                        long v248;
                        v248 = v247 + v246;
                        assert("Tensor range check" && 0 <= v236 && v236 < 8l);
                        assert("Tensor range check" && 0 <= v234 && v234 < 16l);
                        assert("Tensor range check" && 0 <= v232 && v232 < 8l);
                        assert("Tensor range check" && 0 <= v230 && v230 < 4l);
                        long v249;
                        v249 = 272l * v232;
                        long v250;
                        v250 = v249 + v241;
                        long v251;
                        v251 = 16l * v234;
                        long v252;
                        v252 = v251 + v250;
                        long v253;
                        v253 = 2176l * v236;
                        long v254;
                        v254 = v253 + v252;
                        cooperative_groups::memcpy_async(v4, v14 + v254, v2 + v248, sizeof(float) * 4l);
                        v228 += v226 ;
                    }
                    break;
                }
                default: { // Some
                    long v163 = v58.v.case1.v0;
                    assert("Tensor range check" && 0 <= v163 && v163 < 4l);
                    long v164;
                    v164 = 64l * v163;
                    long v165;
                    v165 = v164 + v37;
                    assert("Tensor range check" && 0 <= v163 && v163 < 4l);
                    long v166;
                    v166 = 16384l * v163;
                    long v167;
                    v167 = v166 + v38;
                    long v168;
                    v168 = v4.meta_group_size();
                    long v169;
                    v169 = v4.meta_group_rank();
                    long v170;
                    v170 = v169;
                    while (while_method_3(v170)){
                        long v172;
                        v172 = v170 % 2l;
                        long v173;
                        v173 = v170 / 2l;
                        long v174;
                        v174 = v173 % 8l;
                        long v175;
                        v175 = v173 / 8l;
                        long v176;
                        v176 = v175 % 16l;
                        long v177;
                        v177 = v175 / 16l;
                        long v178;
                        v178 = v177 % 8l;
                        long v179;
                        v179 = v177 / 8l;
                        bool v180;
                        v180 = v179 == 0l;
                        bool v181;
                        v181 = v180 == false;
                        if (v181){
                            assert("The index has to be in the range of the dimension." && v180);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v178 && v178 < 8l);
                        assert("Tensor range check" && 0 <= v176 && v176 < 16l);
                        assert("Tensor range check" && 0 <= v174 && v174 < 8l);
                        assert("Tensor range check" && 0 <= v172 && v172 < 2l);
                        long v183;
                        v183 = 4l * v172;
                        long v184;
                        v184 = v183 + v165;
                        long v185;
                        v185 = 8l * v174;
                        long v186;
                        v186 = v185 + v184;
                        long v187;
                        v187 = 256l * v176;
                        long v188;
                        v188 = v187 + v186;
                        long v189;
                        v189 = 4096l * v178;
                        long v190;
                        v190 = v189 + v188;
                        assert("Tensor range check" && 0 <= v178 && v178 < 8l);
                        assert("Tensor range check" && 0 <= v176 && v176 < 16l);
                        assert("Tensor range check" && 0 <= v174 && v174 < 8l);
                        assert("Tensor range check" && 0 <= v172 && v172 < 2l);
                        long v191;
                        v191 = 136l * v174;
                        long v192;
                        v192 = v191 + v183;
                        long v193;
                        v193 = 8l * v176;
                        long v194;
                        v194 = v193 + v192;
                        long v195;
                        v195 = 1088l * v178;
                        long v196;
                        v196 = v195 + v194;
                        cooperative_groups::memcpy_async(v4, v8 + v196, v0 + v190, sizeof(float) * 4l);
                        v170 += v168 ;
                    }
                    long v197;
                    v197 = v4.meta_group_size();
                    long v198;
                    v198 = v4.meta_group_rank();
                    long v199;
                    v199 = v198;
                    while (while_method_3(v199)){
                        long v201;
                        v201 = v199 % 4l;
                        long v202;
                        v202 = v199 / 4l;
                        long v203;
                        v203 = v202 % 8l;
                        long v204;
                        v204 = v202 / 8l;
                        long v205;
                        v205 = v204 % 8l;
                        long v206;
                        v206 = v204 / 8l;
                        long v207;
                        v207 = v206 % 8l;
                        long v208;
                        v208 = v206 / 8l;
                        bool v209;
                        v209 = v208 == 0l;
                        bool v210;
                        v210 = v209 == false;
                        if (v210){
                            assert("The index has to be in the range of the dimension." && v209);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v207 && v207 < 8l);
                        assert("Tensor range check" && 0 <= v205 && v205 < 8l);
                        assert("Tensor range check" && 0 <= v203 && v203 < 8l);
                        assert("Tensor range check" && 0 <= v201 && v201 < 4l);
                        long v212;
                        v212 = 4l * v201;
                        long v213;
                        v213 = v212 + v167;
                        long v214;
                        v214 = 16l * v203;
                        long v215;
                        v215 = v214 + v213;
                        long v216;
                        v216 = 256l * v205;
                        long v217;
                        v217 = v216 + v215;
                        long v218;
                        v218 = 2048l * v207;
                        long v219;
                        v219 = v218 + v217;
                        assert("Tensor range check" && 0 <= v207 && v207 < 8l);
                        assert("Tensor range check" && 0 <= v205 && v205 < 8l);
                        assert("Tensor range check" && 0 <= v203 && v203 < 8l);
                        assert("Tensor range check" && 0 <= v201 && v201 < 4l);
                        long v220;
                        v220 = 144l * v203;
                        long v221;
                        v221 = v220 + v212;
                        long v222;
                        v222 = 16l * v205;
                        long v223;
                        v223 = v222 + v221;
                        long v224;
                        v224 = 1152l * v207;
                        long v225;
                        v225 = v224 + v223;
                        cooperative_groups::memcpy_async(v4, v11 + v225, v1 + v219, sizeof(float) * 4l);
                        v199 += v197 ;
                    }
                }
            }
            long v255;
            v255 = 0l;
            while (while_method_1(v255)){
                long v257;
                v257 = v255 % 1l;
                long v258;
                v258 = v255 % 8l;
                long v259;
                v259 = v255 / 8l;
                bool v260;
                v260 = v259 == 0l;
                bool v261;
                v261 = v260 == false;
                if (v261){
                    assert("The index has to be in the range of the dimension." && v260);
                } else {
                }
                assert("Tensor range check" && 0 <= v258 && v258 < 8l);
                assert("Tensor range check" && 0 <= v257 && v257 < 1l);
                long v263;
                v263 = v258 + v257;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v264 = v26[v263];
                long v265;
                v265 = 0l;
                while (while_method_1(v265)){
                    long v267;
                    v267 = v265 % 8l;
                    long v268;
                    v268 = v265 / 8l;
                    bool v269;
                    v269 = v268 == 0l;
                    bool v270;
                    v270 = v269 == false;
                    if (v270){
                        assert("The index has to be in the range of the dimension." && v269);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v258 && v258 < 8l);
                    assert("Tensor range check" && 0 <= v267 && v267 < 8l);
                    long v272;
                    v272 = 8l * v258;
                    long v273;
                    v273 = v272 + v267;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v274 = v121[v273];
                    assert("Tensor range check" && 0 <= v257 && v257 < 1l);
                    assert("Tensor range check" && 0 <= v267 && v267 < 8l);
                    long v275;
                    v275 = 8l * v257;
                    long v276;
                    v276 = v275 + v267;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v277 = v122[v276];
                    wmma::mma_sync(v264, v274, v277, v264);
                    v265 += 1l ;
                }
                v255 += 1l ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            bool v278;
            v278 = false;
            v40 = v44;
            v41 = v45;
            v42 = v278;
        }
        long v279;
        v279 = thread_block::thread_rank() / warpSize;
        long v280;
        v280 = v279 % 8l;
        long v281;
        v281 = v279 / 8l;
        long v282;
        v282 = v281 % 1l;
        bool v283;
        v283 = v281 == 0l;
        bool v284;
        v284 = v283 == false;
        if (v284){
            assert("The index has to be in the range of the dimension." && v283);
        } else {
        }
        assert("Tensor range check" && 0 <= v282 && v282 < 1l);
        assert("Tensor range check" && 0 <= v280 && v280 < 8l);
        long v286;
        v286 = 272l * v280;
        long v287;
        v287 = 2176l * v282;
        long v288;
        v288 = v287 + v286;
        long v289;
        v289 = 0l;
        while (while_method_1(v289)){
            long v291;
            v291 = v289 % 1l;
            long v292;
            v292 = v289 % 8l;
            long v293;
            v293 = v289 / 8l;
            bool v294;
            v294 = v293 == 0l;
            bool v295;
            v295 = v294 == false;
            if (v295){
                assert("The index has to be in the range of the dimension." && v294);
            } else {
            }
            assert("Tensor range check" && 0 <= v292 && v292 < 8l);
            assert("Tensor range check" && 0 <= v291 && v291 < 1l);
            long v297;
            v297 = v292 + v291;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v298 = v26[v297];
            assert("Tensor range check" && 0 <= v292 && v292 < 8l);
            assert("Tensor range check" && 0 <= v291 && v291 < 1l);
            long v299;
            v299 = 2176l * v291;
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
        long v317;
        v317 = v4.meta_group_size();
        long v318;
        v318 = v4.meta_group_rank();
        long v319;
        v319 = v318;
        while (while_method_4(v319)){
            long v321;
            v321 = v319 % 4l;
            long v322;
            v322 = v319 / 4l;
            long v323;
            v323 = v322 % 8l;
            long v324;
            v324 = v322 / 8l;
            long v325;
            v325 = v324 % 16l;
            long v326;
            v326 = v324 / 16l;
            long v327;
            v327 = v326 % 8l;
            long v328;
            v328 = v326 / 8l;
            bool v329;
            v329 = v328 == 0l;
            bool v330;
            v330 = v329 == false;
            if (v330){
                assert("The index has to be in the range of the dimension." && v329);
            } else {
            }
            assert("Tensor range check" && 0 <= v327 && v327 < 8l);
            assert("Tensor range check" && 0 <= v325 && v325 < 16l);
            assert("Tensor range check" && 0 <= v323 && v323 < 8l);
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
            v337 = 2176l * v327;
            long v338;
            v338 = v337 + v336;
            assert("Tensor range check" && 0 <= v327 && v327 < 8l);
            assert("Tensor range check" && 0 <= v325 && v325 < 16l);
            assert("Tensor range check" && 0 <= v323 && v323 < 8l);
            assert("Tensor range check" && 0 <= v321 && v321 < 4l);
            long v339;
            v339 = v332 + v39;
            long v340;
            v340 = 16l * v323;
            long v341;
            v341 = v340 + v339;
            long v342;
            v342 = 256l * v325;
            long v343;
            v343 = v342 + v341;
            long v344;
            v344 = 4096l * v327;
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
options.append('--maxrregcount=255')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
def main():
    v0 = cp.random.normal(0,1,65536,cp.float32)
    v1 = v0.size
    v2 = 65536 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,65536,cp.float32)
    v6 = v5.size
    v7 = 65536 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,65536,cp.float32)
    v11 = v10.size
    v12 = 65536 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = v10.reshape((256, 256))
    v16 = v5.reshape((256, 256))
    v17 = v0.reshape((256, 256))
    v18 = (cp.matmul(v15,v16) + v17).flatten()
    del v15, v16, v17
    v19 = v18.size
    v20 = 65536 == v19
    del v19
    v21 = v20 == False
    if v21:
        v22 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v20, v22
        del v22
    else:
        pass
    del v20, v21
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),256,is_print=True)
    v23 = 0
    v24 = raw_module.get_function(f"entry{v23}")
    del v23
    v24.max_dynamic_shared_size_bytes = 71680 
    v24((8,),(256,),(v10, v5, v0),shared_mem=71680)
    del v5, v10, v24
    v25 = cp.max(cp.abs(v0-v18))
    del v0, v18
    return v25

if __name__ == '__main__': print(main())
