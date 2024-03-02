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
    v1 = v0 < 16384l;
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
        v19 = v17 % 128l;
        long v20;
        v20 = v17 / 128l;
        long v21;
        v21 = v20 % 128l;
        long v22;
        v22 = v20 / 128l;
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
        assert("Tensor range check" && 0 <= v21 && v21 < 128l);
        long v37;
        v37 = 262144l * v21;
        assert("Tensor range check" && 0 <= v19 && v19 < 128l);
        long v38;
        v38 = 262144l * v19;
        assert("Tensor range check" && 0 <= v21 && v21 < 128l);
        assert("Tensor range check" && 0 <= v19 && v19 < 128l);
        long v39;
        v39 = 64l * v19;
        long v40;
        v40 = 524288l * v21;
        long v41;
        v41 = v40 + v39;
        long v42; bool v43; bool v44;
        Tuple0 tmp0 = Tuple0(0l, true, true);
        v42 = tmp0.v0; v43 = tmp0.v1; v44 = tmp0.v2;
        while (while_method_2(v43)){
            long v46;
            v46 = v42 + 1l;
            bool v47;
            v47 = v46 < 64l;
            long v48;
            v48 = v42 % 64l;
            long v49;
            v49 = v42 / 64l;
            bool v50;
            v50 = v49 == 0l;
            bool v51;
            v51 = v50 == false;
            if (v51){
                assert("The index has to be in the range of the dimension." && v50);
            } else {
            }
            US0 v60;
            if (v47){
                long v53;
                v53 = v46 % 64l;
                long v54;
                v54 = v46 / 64l;
                bool v55;
                v55 = v54 == 0l;
                bool v56;
                v56 = v55 == false;
                if (v56){
                    assert("The index has to be in the range of the dimension." && v55);
                } else {
                }
                v60 = US0_1(v53);
            } else {
                v60 = US0_0();
            }
            if (v44){
                assert("Tensor range check" && 0 <= v48 && v48 < 64l);
                long v61;
                v61 = 64l * v48;
                long v62;
                v62 = v61 + v37;
                assert("Tensor range check" && 0 <= v48 && v48 < 64l);
                long v63;
                v63 = v61 + v38;
                long v64;
                v64 = v4.meta_group_size();
                long v65;
                v65 = v4.meta_group_rank();
                long v66;
                v66 = v65;
                while (while_method_3(v66)){
                    long v68;
                    v68 = v66 % 64l;
                    long v69;
                    v69 = v66 / 64l;
                    long v70;
                    v70 = v69 % 64l;
                    long v71;
                    v71 = v69 / 64l;
                    bool v72;
                    v72 = v71 == 0l;
                    bool v73;
                    v73 = v72 == false;
                    if (v73){
                        assert("The index has to be in the range of the dimension." && v72);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v70 && v70 < 64l);
                    assert("Tensor range check" && 0 <= v68 && v68 < 64l);
                    long v75;
                    v75 = v68 + v62;
                    long v76;
                    v76 = 4096l * v70;
                    long v77;
                    v77 = v76 + v75;
                    assert("Tensor range check" && 0 <= v70 && v70 < 64l);
                    assert("Tensor range check" && 0 <= v68 && v68 < 64l);
                    long v78;
                    v78 = 68l * v70;
                    long v79;
                    v79 = v78 + v68;
                    cooperative_groups::memcpy_async(v4, v8 + v79, v0 + v77, sizeof(float) * 1l);
                    v66 += v64 ;
                }
                long v80;
                v80 = v4.meta_group_size();
                long v81;
                v81 = v4.meta_group_rank();
                long v82;
                v82 = v81;
                while (while_method_3(v82)){
                    long v84;
                    v84 = v82 % 64l;
                    long v85;
                    v85 = v82 / 64l;
                    long v86;
                    v86 = v85 % 64l;
                    long v87;
                    v87 = v85 / 64l;
                    bool v88;
                    v88 = v87 == 0l;
                    bool v89;
                    v89 = v88 == false;
                    if (v89){
                        assert("The index has to be in the range of the dimension." && v88);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v86 && v86 < 64l);
                    assert("Tensor range check" && 0 <= v84 && v84 < 64l);
                    long v91;
                    v91 = v84 + v63;
                    long v92;
                    v92 = 4096l * v86;
                    long v93;
                    v93 = v92 + v91;
                    assert("Tensor range check" && 0 <= v86 && v86 < 64l);
                    assert("Tensor range check" && 0 <= v84 && v84 < 64l);
                    long v94;
                    v94 = 68l * v86;
                    long v95;
                    v95 = v94 + v84;
                    cooperative_groups::memcpy_async(v4, v11 + v95, v1 + v93, sizeof(float) * 1l);
                    v82 += v80 ;
                }
            } else {
            }
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v96[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v97[8l];
            long v98;
            v98 = thread_block::thread_rank();
            long v99;
            v99 = v98 / 32l;
            long v100;
            v100 = v99 % 4l;
            long v101;
            v101 = v99 / 4l;
            long v102;
            v102 = v101 % 2l;
            long v103;
            v103 = v101 / 2l;
            bool v104;
            v104 = v103 == 0l;
            bool v105;
            v105 = v104 == false;
            if (v105){
                assert("The index has to be in the range of the dimension." && v104);
            } else {
            }
            assert("Tensor range check" && 0 <= v102 && v102 < 2l);
            long v107;
            v107 = 2176l * v102;
            assert("Tensor range check" && 0 <= v100 && v100 < 4l);
            long v108;
            v108 = 1088l * v100;
            cooperative_groups::wait(v4);
            v3.sync() ;
            long v109;
            v109 = 0l;
            while (while_method_1(v109)){
                long v111;
                v111 = v109 % 1l;
                long v112;
                v112 = v109 % 2l;
                long v113;
                v113 = v109 / 2l;
                bool v114;
                v114 = v113 == 0l;
                bool v115;
                v115 = v114 == false;
                if (v115){
                    assert("The index has to be in the range of the dimension." && v114);
                } else {
                }
                assert("Tensor range check" && 0 <= v112 && v112 < 2l);
                long v117;
                v117 = 1088l * v112;
                long v118;
                v118 = v117 + v107;
                assert("Tensor range check" && 0 <= v111 && v111 < 1l);
                long v119;
                v119 = 1088l * v111;
                long v120;
                v120 = v119 + v108;
                long v121;
                v121 = 0l;
                while (while_method_4(v121)){
                    long v123;
                    v123 = v121 % 8l;
                    long v124;
                    v124 = v121 / 8l;
                    bool v125;
                    v125 = v124 == 0l;
                    bool v126;
                    v126 = v125 == false;
                    if (v126){
                        assert("The index has to be in the range of the dimension." && v125);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v123 && v123 < 8l);
                    long v128;
                    v128 = 8l * v123;
                    long v129;
                    v129 = v128 + v118;
                    assert("Tensor range check" && 0 <= v123 && v123 < 8l);
                    long v130;
                    v130 = v128 + v120;
                    assert("Tensor range check" && 0 <= v112 && v112 < 2l);
                    assert("Tensor range check" && 0 <= v123 && v123 < 8l);
                    long v131;
                    v131 = 8l * v112;
                    long v132;
                    v132 = v131 + v123;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v133 = v96[v132];
                    float * v134;
                    v134 = v8 + v129;
                    wmma::load_matrix_sync(v133, v134, 68l);
                    #pragma unroll
                    for (int t = 0; t < v133.num_elements; t++) { v133.x[t] = wmma::__float_to_tf32(v133.x[t]); };
                    assert("Tensor range check" && 0 <= v111 && v111 < 1l);
                    assert("Tensor range check" && 0 <= v123 && v123 < 8l);
                    long v135;
                    v135 = 8l * v111;
                    long v136;
                    v136 = v135 + v123;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v137 = v97[v136];
                    float * v138;
                    v138 = v11 + v130;
                    wmma::load_matrix_sync(v137, v138, 68l);
                    #pragma unroll
                    for (int t = 0; t < v137.num_elements; t++) { v137.x[t] = wmma::__float_to_tf32(v137.x[t]); };
                    v121 += 1l ;
                }
                v109 += 1l ;
            }
            v3.sync() ;
            switch (v60.tag) {
                case 0: { // None
                    long v175;
                    v175 = v4.meta_group_size();
                    long v176;
                    v176 = v4.meta_group_rank();
                    long v177;
                    v177 = v176;
                    while (while_method_3(v177)){
                        long v179;
                        v179 = v177 % 64l;
                        long v180;
                        v180 = v177 / 64l;
                        long v181;
                        v181 = v180 % 64l;
                        long v182;
                        v182 = v180 / 64l;
                        bool v183;
                        v183 = v182 == 0l;
                        bool v184;
                        v184 = v183 == false;
                        if (v184){
                            assert("The index has to be in the range of the dimension." && v183);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v181 && v181 < 64l);
                        assert("Tensor range check" && 0 <= v179 && v179 < 64l);
                        long v186;
                        v186 = v179 + v41;
                        long v187;
                        v187 = 8192l * v181;
                        long v188;
                        v188 = v187 + v186;
                        assert("Tensor range check" && 0 <= v181 && v181 < 64l);
                        assert("Tensor range check" && 0 <= v179 && v179 < 64l);
                        long v189;
                        v189 = 72l * v181;
                        long v190;
                        v190 = v189 + v179;
                        cooperative_groups::memcpy_async(v4, v14 + v190, v2 + v188, sizeof(float) * 1l);
                        v177 += v175 ;
                    }
                    break;
                }
                default: { // Some
                    long v139 = v60.v.case1.v0;
                    assert("Tensor range check" && 0 <= v139 && v139 < 64l);
                    long v140;
                    v140 = 64l * v139;
                    long v141;
                    v141 = v140 + v37;
                    assert("Tensor range check" && 0 <= v139 && v139 < 64l);
                    long v142;
                    v142 = v140 + v38;
                    long v143;
                    v143 = v4.meta_group_size();
                    long v144;
                    v144 = v4.meta_group_rank();
                    long v145;
                    v145 = v144;
                    while (while_method_3(v145)){
                        long v147;
                        v147 = v145 % 64l;
                        long v148;
                        v148 = v145 / 64l;
                        long v149;
                        v149 = v148 % 64l;
                        long v150;
                        v150 = v148 / 64l;
                        bool v151;
                        v151 = v150 == 0l;
                        bool v152;
                        v152 = v151 == false;
                        if (v152){
                            assert("The index has to be in the range of the dimension." && v151);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v149 && v149 < 64l);
                        assert("Tensor range check" && 0 <= v147 && v147 < 64l);
                        long v154;
                        v154 = v147 + v141;
                        long v155;
                        v155 = 4096l * v149;
                        long v156;
                        v156 = v155 + v154;
                        assert("Tensor range check" && 0 <= v149 && v149 < 64l);
                        assert("Tensor range check" && 0 <= v147 && v147 < 64l);
                        long v157;
                        v157 = 68l * v149;
                        long v158;
                        v158 = v157 + v147;
                        cooperative_groups::memcpy_async(v4, v8 + v158, v0 + v156, sizeof(float) * 1l);
                        v145 += v143 ;
                    }
                    long v159;
                    v159 = v4.meta_group_size();
                    long v160;
                    v160 = v4.meta_group_rank();
                    long v161;
                    v161 = v160;
                    while (while_method_3(v161)){
                        long v163;
                        v163 = v161 % 64l;
                        long v164;
                        v164 = v161 / 64l;
                        long v165;
                        v165 = v164 % 64l;
                        long v166;
                        v166 = v164 / 64l;
                        bool v167;
                        v167 = v166 == 0l;
                        bool v168;
                        v168 = v167 == false;
                        if (v168){
                            assert("The index has to be in the range of the dimension." && v167);
                        } else {
                        }
                        assert("Tensor range check" && 0 <= v165 && v165 < 64l);
                        assert("Tensor range check" && 0 <= v163 && v163 < 64l);
                        long v170;
                        v170 = v163 + v142;
                        long v171;
                        v171 = 4096l * v165;
                        long v172;
                        v172 = v171 + v170;
                        assert("Tensor range check" && 0 <= v165 && v165 < 64l);
                        assert("Tensor range check" && 0 <= v163 && v163 < 64l);
                        long v173;
                        v173 = 68l * v165;
                        long v174;
                        v174 = v173 + v163;
                        cooperative_groups::memcpy_async(v4, v11 + v174, v1 + v172, sizeof(float) * 1l);
                        v161 += v159 ;
                    }
                }
            }
            long v191;
            v191 = 0l;
            while (while_method_1(v191)){
                long v193;
                v193 = v191 % 1l;
                long v194;
                v194 = v191 % 2l;
                long v195;
                v195 = v191 / 2l;
                bool v196;
                v196 = v195 == 0l;
                bool v197;
                v197 = v196 == false;
                if (v197){
                    assert("The index has to be in the range of the dimension." && v196);
                } else {
                }
                assert("Tensor range check" && 0 <= v194 && v194 < 2l);
                assert("Tensor range check" && 0 <= v193 && v193 < 1l);
                long v199;
                v199 = v194 + v193;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v200 = v26[v199];
                long v201;
                v201 = 0l;
                while (while_method_4(v201)){
                    long v203;
                    v203 = v201 % 8l;
                    long v204;
                    v204 = v201 / 8l;
                    bool v205;
                    v205 = v204 == 0l;
                    bool v206;
                    v206 = v205 == false;
                    if (v206){
                        assert("The index has to be in the range of the dimension." && v205);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v194 && v194 < 2l);
                    assert("Tensor range check" && 0 <= v203 && v203 < 8l);
                    long v208;
                    v208 = 8l * v194;
                    long v209;
                    v209 = v208 + v203;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v210 = v96[v209];
                    assert("Tensor range check" && 0 <= v193 && v193 < 1l);
                    assert("Tensor range check" && 0 <= v203 && v203 < 8l);
                    long v211;
                    v211 = 8l * v193;
                    long v212;
                    v212 = v211 + v203;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v213 = v97[v212];
                    wmma::mma_sync(v200, v210, v213, v200);
                    v201 += 1l ;
                }
                v191 += 1l ;
            }
            bool v214;
            v214 = false;
            v42 = v46;
            v43 = v47;
            v44 = v214;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v215;
        v215 = thread_block::thread_rank();
        long v216;
        v216 = v215 / 32l;
        long v217;
        v217 = v216 % 4l;
        long v218;
        v218 = v216 / 4l;
        long v219;
        v219 = v218 % 2l;
        long v220;
        v220 = v218 / 2l;
        bool v221;
        v221 = v220 == 0l;
        bool v222;
        v222 = v221 == false;
        if (v222){
            assert("The index has to be in the range of the dimension." && v221);
        } else {
        }
        assert("Tensor range check" && 0 <= v219 && v219 < 2l);
        assert("Tensor range check" && 0 <= v217 && v217 < 4l);
        long v224;
        v224 = 16l * v217;
        long v225;
        v225 = 2304l * v219;
        long v226;
        v226 = v225 + v224;
        long v227;
        v227 = 0l;
        while (while_method_1(v227)){
            long v229;
            v229 = v227 % 1l;
            long v230;
            v230 = v227 % 2l;
            long v231;
            v231 = v227 / 2l;
            bool v232;
            v232 = v231 == 0l;
            bool v233;
            v233 = v232 == false;
            if (v233){
                assert("The index has to be in the range of the dimension." && v232);
            } else {
            }
            assert("Tensor range check" && 0 <= v230 && v230 < 2l);
            assert("Tensor range check" && 0 <= v229 && v229 < 1l);
            long v235;
            v235 = v230 + v229;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v236 = v26[v235];
            assert("Tensor range check" && 0 <= v230 && v230 < 2l);
            assert("Tensor range check" && 0 <= v229 && v229 < 1l);
            long v237;
            v237 = 16l * v229;
            long v238;
            v238 = v237 + v226;
            long v239;
            v239 = 1152l * v230;
            long v240;
            v240 = v239 + v238;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v241;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v242 = v241;
            float * v243;
            v243 = v14 + v240;
            wmma::load_matrix_sync(v242, v243, 72l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v244 = v236;
            long v245;
            v245 = v244.num_elements;
            long v246;
            v246 = 0l;
            while (while_method_5(v245, v246)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v248 = v236;
                float v249;
                v249 = v248.x[v246];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v250 = v242;
                float v251;
                v251 = v250.x[v246];
                float v252;
                v252 = v249 + v251;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v253 = v236;
                v253.x[v246] = v252;
                v246 += 1l ;
            }
            float * v254;
            v254 = v14 + v240;
            wmma::store_matrix_sync(v254, v236, 72l, wmma::mem_row_major);
            v227 += 1l ;
        }
        v3.sync() ;
        long v255;
        v255 = v4.meta_group_size();
        long v256;
        v256 = v4.meta_group_rank();
        long v257;
        v257 = v256;
        while (while_method_3(v257)){
            long v259;
            v259 = v257 % 64l;
            long v260;
            v260 = v257 / 64l;
            long v261;
            v261 = v260 % 64l;
            long v262;
            v262 = v260 / 64l;
            bool v263;
            v263 = v262 == 0l;
            bool v264;
            v264 = v263 == false;
            if (v264){
                assert("The index has to be in the range of the dimension." && v263);
            } else {
            }
            assert("Tensor range check" && 0 <= v261 && v261 < 64l);
            assert("Tensor range check" && 0 <= v259 && v259 < 64l);
            long v266;
            v266 = 72l * v261;
            long v267;
            v267 = v266 + v259;
            assert("Tensor range check" && 0 <= v261 && v261 < 64l);
            assert("Tensor range check" && 0 <= v259 && v259 < 64l);
            long v268;
            v268 = v259 + v41;
            long v269;
            v269 = 8192l * v261;
            long v270;
            v270 = v269 + v268;
            cooperative_groups::memcpy_async(v4, v2 + v270, v14 + v267, sizeof(float) * 1l);
            v257 += v255 ;
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
    v0 = cp.random.normal(0,1,67108864,cp.float32)
    v1 = v0.size
    v2 = 67108864 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,33554432,cp.float32)
    v6 = v5.size
    v7 = 33554432 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,33554432,cp.float32)
    v11 = v10.size
    v12 = 33554432 == v11
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
        v18 = v10.reshape((8192, 4096))
        v19 = v5.reshape((8192, 4096))
        v20 = cp.transpose(v19)
        del v19
        v21 = v0.reshape((8192, 8192))
        v22 = (cp.matmul(v18,v20) + v21).flatten()
        del v18, v20, v21
        v23 = v22.size
        v24 = 67108864 == v23
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
        v29((256,),(256,),(v10, v5, v0),shared_mem=34816)
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
