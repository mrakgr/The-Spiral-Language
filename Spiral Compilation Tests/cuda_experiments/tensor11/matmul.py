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
    v1 = v0 < 4096l;
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
                    v67 = v65 % 64l;
                    long v68;
                    v68 = v65 / 64l;
                    long v69;
                    v69 = v68 % 64l;
                    long v70;
                    v70 = v68 / 64l;
                    bool v71;
                    v71 = v70 == 0l;
                    bool v72;
                    v72 = v71 == false;
                    if (v72){
                        assert("The index has to be in the range of the dimension." && v71);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v69 && v69 < 64l);
                    assert("Tensor range check" && 0 <= v67 && v67 < 64l);
                    long v74;
                    v74 = v67 + v61;
                    long v75;
                    v75 = 512l * v69;
                    long v76;
                    v76 = v75 + v74;
                    assert("Tensor range check" && 0 <= v69 && v69 < 64l);
                    assert("Tensor range check" && 0 <= v67 && v67 < 64l);
                    long v77;
                    v77 = 68l * v69;
                    long v78;
                    v78 = v77 + v67;
                    cooperative_groups::memcpy_async(v4, v8 + v78, v0 + v76, sizeof(float) * 1l);
                    v65 += v63 ;
                }
                long v79;
                v79 = v4.meta_group_size();
                long v80;
                v80 = v4.meta_group_rank();
                long v81;
                v81 = v80;
                while (while_method_3(v81)){
                    long v83;
                    v83 = v81 % 64l;
                    long v84;
                    v84 = v81 / 64l;
                    long v85;
                    v85 = v84 % 64l;
                    long v86;
                    v86 = v84 / 64l;
                    bool v87;
                    v87 = v86 == 0l;
                    bool v88;
                    v88 = v87 == false;
                    if (v88){
                        assert("The index has to be in the range of the dimension." && v87);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v85 && v85 < 64l);
                    assert("Tensor range check" && 0 <= v83 && v83 < 64l);
                    long v90;
                    v90 = v83 + v62;
                    long v91;
                    v91 = 512l * v85;
                    long v92;
                    v92 = v91 + v90;
                    assert("Tensor range check" && 0 <= v85 && v85 < 64l);
                    assert("Tensor range check" && 0 <= v83 && v83 < 64l);
                    long v93;
                    v93 = 68l * v85;
                    long v94;
                    v94 = v93 + v83;
                    cooperative_groups::memcpy_async(v4, v11 + v94, v1 + v92, sizeof(float) * 1l);
                    v81 += v79 ;
                }
            } else {
            }
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v95[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v96[8l];
            long v97;
            v97 = thread_block::thread_rank();
            long v98;
            v98 = v97 / 32l;
            long v99;
            v99 = v98 % 4l;
            long v100;
            v100 = v98 / 4l;
            long v101;
            v101 = v100 % 2l;
            long v102;
            v102 = v100 / 2l;
            bool v103;
            v103 = v102 == 0l;
            bool v104;
            v104 = v103 == false;
            if (v104){
                assert("The index has to be in the range of the dimension." && v103);
            } else {
            }
            assert("Tensor range check" && 0 <= v101 && v101 < 2l);
            long v106;
            v106 = 2176l * v101;
            assert("Tensor range check" && 0 <= v99 && v99 < 4l);
            long v107;
            v107 = 1088l * v99;
            cooperative_groups::wait(v4);
            v3.sync() ;
            long v108;
            v108 = 0l;
            while (while_method_1(v108)){
                long v110;
                v110 = v108 % 1l;
                long v111;
                v111 = v108 % 2l;
                long v112;
                v112 = v108 / 2l;
                bool v113;
                v113 = v112 == 0l;
                bool v114;
                v114 = v113 == false;
                if (v114){
                    assert("The index has to be in the range of the dimension." && v113);
                } else {
                }
                assert("Tensor range check" && 0 <= v111 && v111 < 2l);
                long v116;
                v116 = 1088l * v111;
                long v117;
                v117 = v116 + v106;
                assert("Tensor range check" && 0 <= v110 && v110 < 1l);
                long v118;
                v118 = 1088l * v110;
                long v119;
                v119 = v118 + v107;
                long v120;
                v120 = 0l;
                while (while_method_4(v120)){
                    long v122;
                    v122 = v120 % 8l;
                    long v123;
                    v123 = v120 / 8l;
                    bool v124;
                    v124 = v123 == 0l;
                    bool v125;
                    v125 = v124 == false;
                    if (v125){
                        assert("The index has to be in the range of the dimension." && v124);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v122 && v122 < 8l);
                    long v127;
                    v127 = 8l * v122;
                    long v128;
                    v128 = v127 + v117;
                    assert("Tensor range check" && 0 <= v122 && v122 < 8l);
                    long v129;
                    v129 = v127 + v119;
                    assert("Tensor range check" && 0 <= v111 && v111 < 2l);
                    assert("Tensor range check" && 0 <= v122 && v122 < 8l);
                    long v130;
                    v130 = 8l * v111;
                    long v131;
                    v131 = v130 + v122;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v132 = v95[v131];
                    float * v133;
                    v133 = v8 + v128;
                    wmma::load_matrix_sync(v132, v133, 68l);
                    #pragma unroll
                    for (int t = 0; t < v132.num_elements; t++) { v132.x[t] = wmma::__float_to_tf32(v132.x[t]); };
                    assert("Tensor range check" && 0 <= v110 && v110 < 1l);
                    assert("Tensor range check" && 0 <= v122 && v122 < 8l);
                    long v134;
                    v134 = 8l * v110;
                    long v135;
                    v135 = v134 + v122;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v136 = v96[v135];
                    float * v137;
                    v137 = v11 + v129;
                    wmma::load_matrix_sync(v136, v137, 68l);
                    #pragma unroll
                    for (int t = 0; t < v136.num_elements; t++) { v136.x[t] = wmma::__float_to_tf32(v136.x[t]); };
                    v120 += 1l ;
                }
                v108 += 1l ;
            }
            v3.sync() ;
            switch (v59.tag) {
                case 0: { // None
                    long v174;
                    v174 = v4.meta_group_size();
                    long v175;
                    v175 = v4.meta_group_rank();
                    long v176;
                    v176 = v175;
                    while (while_method_3(v176)){
                        long v178;
                        v178 = v176 % 64l;
                        long v179;
                        v179 = v176 / 64l;
                        long v180;
                        v180 = v179 % 64l;
                        long v181;
                        v181 = v179 / 64l;
                        bool v182;
                        v182 = v181 == 0l;
                        bool v183;
                        v183 = v182 == false;
                        if (v183){
                            assert("The index has to be in the range of the dimension." && v182);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v180 && v180 < 64l);
                        assert("Tensor range check" && 0 <= v178 && v178 < 64l);
                        long v185;
                        v185 = v178 + v40;
                        long v186;
                        v186 = 512l * v180;
                        long v187;
                        v187 = v186 + v185;
                        assert("Tensor range check" && 0 <= v180 && v180 < 64l);
                        assert("Tensor range check" && 0 <= v178 && v178 < 64l);
                        long v188;
                        v188 = 72l * v180;
                        long v189;
                        v189 = v188 + v178;
                        cooperative_groups::memcpy_async(v4, v14 + v189, v2 + v187, sizeof(float) * 1l);
                        v176 += v174 ;
                    }
                    break;
                }
                default: { // Some
                    long v138 = v59.v.case1.v0;
                    assert("Tensor range check" && 0 <= v138 && v138 < 8l);
                    long v139;
                    v139 = 64l * v138;
                    long v140;
                    v140 = v139 + v37;
                    assert("Tensor range check" && 0 <= v138 && v138 < 8l);
                    long v141;
                    v141 = v139 + v38;
                    long v142;
                    v142 = v4.meta_group_size();
                    long v143;
                    v143 = v4.meta_group_rank();
                    long v144;
                    v144 = v143;
                    while (while_method_3(v144)){
                        long v146;
                        v146 = v144 % 64l;
                        long v147;
                        v147 = v144 / 64l;
                        long v148;
                        v148 = v147 % 64l;
                        long v149;
                        v149 = v147 / 64l;
                        bool v150;
                        v150 = v149 == 0l;
                        bool v151;
                        v151 = v150 == false;
                        if (v151){
                            assert("The index has to be in the range of the dimension." && v150);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v148 && v148 < 64l);
                        assert("Tensor range check" && 0 <= v146 && v146 < 64l);
                        long v153;
                        v153 = v146 + v140;
                        long v154;
                        v154 = 512l * v148;
                        long v155;
                        v155 = v154 + v153;
                        assert("Tensor range check" && 0 <= v148 && v148 < 64l);
                        assert("Tensor range check" && 0 <= v146 && v146 < 64l);
                        long v156;
                        v156 = 68l * v148;
                        long v157;
                        v157 = v156 + v146;
                        cooperative_groups::memcpy_async(v4, v8 + v157, v0 + v155, sizeof(float) * 1l);
                        v144 += v142 ;
                    }
                    long v158;
                    v158 = v4.meta_group_size();
                    long v159;
                    v159 = v4.meta_group_rank();
                    long v160;
                    v160 = v159;
                    while (while_method_3(v160)){
                        long v162;
                        v162 = v160 % 64l;
                        long v163;
                        v163 = v160 / 64l;
                        long v164;
                        v164 = v163 % 64l;
                        long v165;
                        v165 = v163 / 64l;
                        bool v166;
                        v166 = v165 == 0l;
                        bool v167;
                        v167 = v166 == false;
                        if (v167){
                            assert("The index has to be in the range of the dimension." && v166);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v164 && v164 < 64l);
                        assert("Tensor range check" && 0 <= v162 && v162 < 64l);
                        long v169;
                        v169 = v162 + v141;
                        long v170;
                        v170 = 512l * v164;
                        long v171;
                        v171 = v170 + v169;
                        assert("Tensor range check" && 0 <= v164 && v164 < 64l);
                        assert("Tensor range check" && 0 <= v162 && v162 < 64l);
                        long v172;
                        v172 = 68l * v164;
                        long v173;
                        v173 = v172 + v162;
                        cooperative_groups::memcpy_async(v4, v11 + v173, v1 + v171, sizeof(float) * 1l);
                        v160 += v158 ;
                    }
                }
            }
            long v190;
            v190 = 0l;
            while (while_method_1(v190)){
                long v192;
                v192 = v190 % 1l;
                long v193;
                v193 = v190 % 2l;
                long v194;
                v194 = v190 / 2l;
                bool v195;
                v195 = v194 == 0l;
                bool v196;
                v196 = v195 == false;
                if (v196){
                    assert("The index has to be in the range of the dimension." && v195);
                } else {
                }
                assert("Tensor range check" && 0 <= v193 && v193 < 2l);
                assert("Tensor range check" && 0 <= v192 && v192 < 1l);
                long v198;
                v198 = v193 + v192;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v199 = v26[v198];
                long v200;
                v200 = 0l;
                while (while_method_4(v200)){
                    long v202;
                    v202 = v200 % 8l;
                    long v203;
                    v203 = v200 / 8l;
                    bool v204;
                    v204 = v203 == 0l;
                    bool v205;
                    v205 = v204 == false;
                    if (v205){
                        assert("The index has to be in the range of the dimension." && v204);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v193 && v193 < 2l);
                    assert("Tensor range check" && 0 <= v202 && v202 < 8l);
                    long v207;
                    v207 = 8l * v193;
                    long v208;
                    v208 = v207 + v202;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v209 = v95[v208];
                    assert("Tensor range check" && 0 <= v192 && v192 < 1l);
                    assert("Tensor range check" && 0 <= v202 && v202 < 8l);
                    long v210;
                    v210 = 8l * v192;
                    long v211;
                    v211 = v210 + v202;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v212 = v96[v211];
                    wmma::mma_sync(v199, v209, v212, v199);
                    v200 += 1l ;
                }
                v190 += 1l ;
            }
            bool v213;
            v213 = false;
            v41 = v45;
            v42 = v46;
            v43 = v213;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v214;
        v214 = thread_block::thread_rank();
        long v215;
        v215 = v214 / 32l;
        long v216;
        v216 = v215 % 4l;
        long v217;
        v217 = v215 / 4l;
        long v218;
        v218 = v217 % 2l;
        long v219;
        v219 = v217 / 2l;
        bool v220;
        v220 = v219 == 0l;
        bool v221;
        v221 = v220 == false;
        if (v221){
            assert("The index has to be in the range of the dimension." && v220);
        } else {
        }
        assert("Tensor range check" && 0 <= v218 && v218 < 2l);
        assert("Tensor range check" && 0 <= v216 && v216 < 4l);
        long v223;
        v223 = 16l * v216;
        long v224;
        v224 = 2304l * v218;
        long v225;
        v225 = v224 + v223;
        long v226;
        v226 = 0l;
        while (while_method_1(v226)){
            long v228;
            v228 = v226 % 1l;
            long v229;
            v229 = v226 % 2l;
            long v230;
            v230 = v226 / 2l;
            bool v231;
            v231 = v230 == 0l;
            bool v232;
            v232 = v231 == false;
            if (v232){
                assert("The index has to be in the range of the dimension." && v231);
            } else {
            }
            assert("Tensor range check" && 0 <= v229 && v229 < 2l);
            assert("Tensor range check" && 0 <= v228 && v228 < 1l);
            long v234;
            v234 = v229 + v228;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v235 = v26[v234];
            assert("Tensor range check" && 0 <= v229 && v229 < 2l);
            assert("Tensor range check" && 0 <= v228 && v228 < 1l);
            long v236;
            v236 = 16l * v228;
            long v237;
            v237 = v236 + v225;
            long v238;
            v238 = 1152l * v229;
            long v239;
            v239 = v238 + v237;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v240;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v241 = v240;
            float * v242;
            v242 = v14 + v239;
            wmma::load_matrix_sync(v241, v242, 72l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v243 = v235;
            long v244;
            v244 = v243.num_elements;
            long v245;
            v245 = 0l;
            while (while_method_5(v244, v245)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v247 = v235;
                float v248;
                v248 = v247.x[v245];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v249 = v241;
                float v250;
                v250 = v249.x[v245];
                float v251;
                v251 = v248 + v250;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v252 = v235;
                v252.x[v245] = v251;
                v245 += 1l ;
            }
            float * v253;
            v253 = v14 + v239;
            wmma::store_matrix_sync(v253, v235, 72l, wmma::mem_row_major);
            v226 += 1l ;
        }
        v3.sync() ;
        long v254;
        v254 = v4.meta_group_size();
        long v255;
        v255 = v4.meta_group_rank();
        long v256;
        v256 = v255;
        while (while_method_3(v256)){
            long v258;
            v258 = v256 % 64l;
            long v259;
            v259 = v256 / 64l;
            long v260;
            v260 = v259 % 64l;
            long v261;
            v261 = v259 / 64l;
            bool v262;
            v262 = v261 == 0l;
            bool v263;
            v263 = v262 == false;
            if (v263){
                assert("The index has to be in the range of the dimension." && v262);
            } else {
            }
            assert("Tensor range check" && 0 <= v260 && v260 < 64l);
            assert("Tensor range check" && 0 <= v258 && v258 < 64l);
            long v265;
            v265 = 72l * v260;
            long v266;
            v266 = v265 + v258;
            assert("Tensor range check" && 0 <= v260 && v260 < 64l);
            assert("Tensor range check" && 0 <= v258 && v258 < 64l);
            long v267;
            v267 = v258 + v40;
            long v268;
            v268 = 512l * v260;
            long v269;
            v269 = v268 + v267;
            cooperative_groups::memcpy_async(v4, v2 + v269, v14 + v266, sizeof(float) * 1l);
            v256 += v254 ;
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

options = []
options.append('--diag-suppress=550')
options.append('--dopt=on')
options.append('--restrict')
options.append('--define-macro=NDEBUG')
options.append('--extra-device-vectorization')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
    del v0
    return v1
def main():
    v0 = cp.zeros(262144,dtype=cp.float32)
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
    v5 = cp.zeros(262144,dtype=cp.float32)
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
    v10 = cp.zeros(262144,dtype=cp.float32)
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
        v18 = 0
        v19 = raw_module.get_function(f"entry{v18}")
        del v18
        v19.max_dynamic_shared_size_bytes = 34816 
        v19((256,),(256,),(v10, v5, v0),shared_mem=34816)
        del v19
        v16 = v16
        v15 += 1 
    del v0, v5, v10, v15
    return v16

if __name__ == '__main__': print(main())
