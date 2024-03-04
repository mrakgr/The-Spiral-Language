kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
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
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8l;
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
        long v41;
        v41 = 0l;
        while (while_method_2(v41)){
            long v43;
            v43 = v41 % 8l;
            long v44;
            v44 = v41 / 8l;
            bool v45;
            v45 = v44 == 0l;
            bool v46;
            v46 = v45 == false;
            if (v46){
                assert("The index has to be in the range of the dimension." && v45);
            } else {
            }
            assert("Tensor range check" && 0 <= v43 && v43 < 8l);
            long v48;
            v48 = 64l * v43;
            long v49;
            v49 = v48 + v37;
            assert("Tensor range check" && 0 <= v43 && v43 < 8l);
            long v50;
            v50 = v48 + v38;
            long v51;
            v51 = v4.meta_group_size();
            long v52;
            v52 = v4.meta_group_rank();
            long v53;
            v53 = v52;
            while (while_method_3(v53)){
                long v55;
                v55 = v53 % 64l;
                long v56;
                v56 = v53 / 64l;
                long v57;
                v57 = v56 % 64l;
                long v58;
                v58 = v56 / 64l;
                bool v59;
                v59 = v58 == 0l;
                bool v60;
                v60 = v59 == false;
                if (v60){
                    assert("The index has to be in the range of the dimension." && v59);
                } else {
                }
                assert("Tensor range check" && 0 <= v57 && v57 < 64l);
                assert("Tensor range check" && 0 <= v55 && v55 < 64l);
                long v62;
                v62 = v55 + v49;
                long v63;
                v63 = 512l * v57;
                long v64;
                v64 = v63 + v62;
                assert("Tensor range check" && 0 <= v57 && v57 < 64l);
                assert("Tensor range check" && 0 <= v55 && v55 < 64l);
                long v65;
                v65 = 68l * v57;
                long v66;
                v66 = v65 + v55;
                int* v67;
                v67 = reinterpret_cast<int*>(v0 + v64);
                int* v68;
                v68 = reinterpret_cast<int*>(v8 + v66);
                assert("Pointer alignment check" && v67 % sizeof(int) == 0 && v68 % sizeof(int) == 0);
                *v68 = *v67;
                v53 += v51 ;
            }
            long v69;
            v69 = v4.meta_group_size();
            long v70;
            v70 = v4.meta_group_rank();
            long v71;
            v71 = v70;
            while (while_method_3(v71)){
                long v73;
                v73 = v71 % 64l;
                long v74;
                v74 = v71 / 64l;
                long v75;
                v75 = v74 % 64l;
                long v76;
                v76 = v74 / 64l;
                bool v77;
                v77 = v76 == 0l;
                bool v78;
                v78 = v77 == false;
                if (v78){
                    assert("The index has to be in the range of the dimension." && v77);
                } else {
                }
                assert("Tensor range check" && 0 <= v75 && v75 < 64l);
                assert("Tensor range check" && 0 <= v73 && v73 < 64l);
                long v80;
                v80 = v73 + v50;
                long v81;
                v81 = 512l * v75;
                long v82;
                v82 = v81 + v80;
                assert("Tensor range check" && 0 <= v75 && v75 < 64l);
                assert("Tensor range check" && 0 <= v73 && v73 < 64l);
                long v83;
                v83 = 68l * v75;
                long v84;
                v84 = v83 + v73;
                int* v85;
                v85 = reinterpret_cast<int*>(v1 + v82);
                int* v86;
                v86 = reinterpret_cast<int*>(v11 + v84);
                assert("Pointer alignment check" && v85 % sizeof(int) == 0 && v86 % sizeof(int) == 0);
                *v86 = *v85;
                v71 += v69 ;
            }
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v87[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v88[8l];
            long v89;
            v89 = thread_block::thread_rank();
            long v90;
            v90 = v89 / 32l;
            long v91;
            v91 = v90 % 4l;
            long v92;
            v92 = v90 / 4l;
            long v93;
            v93 = v92 % 2l;
            long v94;
            v94 = v92 / 2l;
            bool v95;
            v95 = v94 == 0l;
            bool v96;
            v96 = v95 == false;
            if (v96){
                assert("The index has to be in the range of the dimension." && v95);
            } else {
            }
            assert("Tensor range check" && 0 <= v93 && v93 < 2l);
            long v98;
            v98 = 2176l * v93;
            assert("Tensor range check" && 0 <= v91 && v91 < 4l);
            long v99;
            v99 = 1088l * v91;
            cooperative_groups::wait(v4);
            v3.sync() ;
            long v100;
            v100 = 0l;
            while (while_method_1(v100)){
                long v102;
                v102 = v100 % 1l;
                long v103;
                v103 = v100 % 2l;
                long v104;
                v104 = v100 / 2l;
                bool v105;
                v105 = v104 == 0l;
                bool v106;
                v106 = v105 == false;
                if (v106){
                    assert("The index has to be in the range of the dimension." && v105);
                } else {
                }
                assert("Tensor range check" && 0 <= v103 && v103 < 2l);
                long v108;
                v108 = 1088l * v103;
                long v109;
                v109 = v108 + v98;
                assert("Tensor range check" && 0 <= v102 && v102 < 1l);
                long v110;
                v110 = 1088l * v102;
                long v111;
                v111 = v110 + v99;
                long v112;
                v112 = 0l;
                while (while_method_2(v112)){
                    long v114;
                    v114 = v112 % 8l;
                    long v115;
                    v115 = v112 / 8l;
                    bool v116;
                    v116 = v115 == 0l;
                    bool v117;
                    v117 = v116 == false;
                    if (v117){
                        assert("The index has to be in the range of the dimension." && v116);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v114 && v114 < 8l);
                    long v119;
                    v119 = 8l * v114;
                    long v120;
                    v120 = v119 + v109;
                    assert("Tensor range check" && 0 <= v114 && v114 < 8l);
                    long v121;
                    v121 = v119 + v111;
                    assert("Tensor range check" && 0 <= v103 && v103 < 2l);
                    assert("Tensor range check" && 0 <= v114 && v114 < 8l);
                    long v122;
                    v122 = 8l * v103;
                    long v123;
                    v123 = v122 + v114;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v124 = v87[v123];
                    float * v125;
                    v125 = v8 + v120;
                    wmma::load_matrix_sync(v124, v125, 68l);
                    #pragma unroll
                    for (int t = 0; t < v124.num_elements; t++) { v124.x[t] = wmma::__float_to_tf32(v124.x[t]); };
                    assert("Tensor range check" && 0 <= v102 && v102 < 1l);
                    assert("Tensor range check" && 0 <= v114 && v114 < 8l);
                    long v126;
                    v126 = 8l * v102;
                    long v127;
                    v127 = v126 + v114;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v128 = v88[v127];
                    float * v129;
                    v129 = v11 + v121;
                    wmma::load_matrix_sync(v128, v129, 68l);
                    #pragma unroll
                    for (int t = 0; t < v128.num_elements; t++) { v128.x[t] = wmma::__float_to_tf32(v128.x[t]); };
                    v112 += 1l ;
                }
                v100 += 1l ;
            }
            v3.sync() ;
            long v130;
            v130 = 0l;
            while (while_method_1(v130)){
                long v132;
                v132 = v130 % 1l;
                long v133;
                v133 = v130 % 2l;
                long v134;
                v134 = v130 / 2l;
                bool v135;
                v135 = v134 == 0l;
                bool v136;
                v136 = v135 == false;
                if (v136){
                    assert("The index has to be in the range of the dimension." && v135);
                } else {
                }
                assert("Tensor range check" && 0 <= v133 && v133 < 2l);
                assert("Tensor range check" && 0 <= v132 && v132 < 1l);
                long v138;
                v138 = v133 + v132;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v139 = v26[v138];
                long v140;
                v140 = 0l;
                while (while_method_2(v140)){
                    long v142;
                    v142 = v140 % 8l;
                    long v143;
                    v143 = v140 / 8l;
                    bool v144;
                    v144 = v143 == 0l;
                    bool v145;
                    v145 = v144 == false;
                    if (v145){
                        assert("The index has to be in the range of the dimension." && v144);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v133 && v133 < 2l);
                    assert("Tensor range check" && 0 <= v142 && v142 < 8l);
                    long v147;
                    v147 = 8l * v133;
                    long v148;
                    v148 = v147 + v142;
                    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v149 = v87[v148];
                    assert("Tensor range check" && 0 <= v132 && v132 < 1l);
                    assert("Tensor range check" && 0 <= v142 && v142 < 8l);
                    long v150;
                    v150 = 8l * v132;
                    long v151;
                    v151 = v150 + v142;
                    wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v152 = v88[v151];
                    wmma::mma_sync(v139, v149, v152, v139);
                    v140 += 1l ;
                }
                v130 += 1l ;
            }
            v41 += 1l ;
        }
        long v153;
        v153 = v4.meta_group_size();
        long v154;
        v154 = v4.meta_group_rank();
        long v155;
        v155 = v154;
        while (while_method_3(v155)){
            long v157;
            v157 = v155 % 64l;
            long v158;
            v158 = v155 / 64l;
            long v159;
            v159 = v158 % 64l;
            long v160;
            v160 = v158 / 64l;
            bool v161;
            v161 = v160 == 0l;
            bool v162;
            v162 = v161 == false;
            if (v162){
                assert("The index has to be in the range of the dimension." && v161);
            } else {
            }
            assert("Tensor range check" && 0 <= v159 && v159 < 64l);
            assert("Tensor range check" && 0 <= v157 && v157 < 64l);
            long v164;
            v164 = v157 + v40;
            long v165;
            v165 = 512l * v159;
            long v166;
            v166 = v165 + v164;
            assert("Tensor range check" && 0 <= v159 && v159 < 64l);
            assert("Tensor range check" && 0 <= v157 && v157 < 64l);
            long v167;
            v167 = 72l * v159;
            long v168;
            v168 = v167 + v157;
            int* v169;
            v169 = reinterpret_cast<int*>(v2 + v166);
            int* v170;
            v170 = reinterpret_cast<int*>(v14 + v168);
            assert("Pointer alignment check" && v169 % sizeof(int) == 0 && v170 % sizeof(int) == 0);
            *v170 = *v169;
            v155 += v153 ;
        }
        v3.sync() ;
        long v171;
        v171 = thread_block::thread_rank();
        long v172;
        v172 = v171 / 32l;
        long v173;
        v173 = v172 % 4l;
        long v174;
        v174 = v172 / 4l;
        long v175;
        v175 = v174 % 2l;
        long v176;
        v176 = v174 / 2l;
        bool v177;
        v177 = v176 == 0l;
        bool v178;
        v178 = v177 == false;
        if (v178){
            assert("The index has to be in the range of the dimension." && v177);
        } else {
        }
        assert("Tensor range check" && 0 <= v175 && v175 < 2l);
        assert("Tensor range check" && 0 <= v173 && v173 < 4l);
        long v180;
        v180 = 16l * v173;
        long v181;
        v181 = 2304l * v175;
        long v182;
        v182 = v181 + v180;
        long v183;
        v183 = 0l;
        while (while_method_1(v183)){
            long v185;
            v185 = v183 % 1l;
            long v186;
            v186 = v183 % 2l;
            long v187;
            v187 = v183 / 2l;
            bool v188;
            v188 = v187 == 0l;
            bool v189;
            v189 = v188 == false;
            if (v189){
                assert("The index has to be in the range of the dimension." && v188);
            } else {
            }
            assert("Tensor range check" && 0 <= v186 && v186 < 2l);
            assert("Tensor range check" && 0 <= v185 && v185 < 1l);
            long v191;
            v191 = v186 + v185;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v192 = v26[v191];
            assert("Tensor range check" && 0 <= v186 && v186 < 2l);
            assert("Tensor range check" && 0 <= v185 && v185 < 1l);
            long v193;
            v193 = 16l * v185;
            long v194;
            v194 = v193 + v182;
            long v195;
            v195 = 1152l * v186;
            long v196;
            v196 = v195 + v194;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v197;
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v198 = v197;
            float * v199;
            v199 = v14 + v196;
            wmma::load_matrix_sync(v198, v199, 72l, wmma::mem_row_major);
            wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v200 = v192;
            long v201;
            v201 = v200.num_elements;
            long v202;
            v202 = 0l;
            while (while_method_4(v201, v202)){
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v204 = v192;
                float v205;
                v205 = v204.x[v202];
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v206 = v198;
                float v207;
                v207 = v206.x[v202];
                float v208;
                v208 = v205 + v207;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v209 = v192;
                v209.x[v202] = v208;
                v202 += 1l ;
            }
            float * v210;
            v210 = v14 + v196;
            wmma::store_matrix_sync(v210, v192, 72l, wmma::mem_row_major);
            v183 += 1l ;
        }
        v3.sync() ;
        long v211;
        v211 = v4.meta_group_size();
        long v212;
        v212 = v4.meta_group_rank();
        long v213;
        v213 = v212;
        while (while_method_3(v213)){
            long v215;
            v215 = v213 % 64l;
            long v216;
            v216 = v213 / 64l;
            long v217;
            v217 = v216 % 64l;
            long v218;
            v218 = v216 / 64l;
            bool v219;
            v219 = v218 == 0l;
            bool v220;
            v220 = v219 == false;
            if (v220){
                assert("The index has to be in the range of the dimension." && v219);
            } else {
            }
            assert("Tensor range check" && 0 <= v217 && v217 < 64l);
            assert("Tensor range check" && 0 <= v215 && v215 < 64l);
            long v222;
            v222 = 72l * v217;
            long v223;
            v223 = v222 + v215;
            assert("Tensor range check" && 0 <= v217 && v217 < 64l);
            assert("Tensor range check" && 0 <= v215 && v215 < 64l);
            long v224;
            v224 = v215 + v40;
            long v225;
            v225 = 512l * v217;
            long v226;
            v226 = v225 + v224;
            int* v227;
            v227 = reinterpret_cast<int*>(v14 + v223);
            int* v228;
            v228 = reinterpret_cast<int*>(v2 + v226);
            assert("Pointer alignment check" && v227 % sizeof(int) == 0 && v228 % sizeof(int) == 0);
            *v228 = *v227;
            v213 += v211 ;
        }
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
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550')
options.append('--dopt=on')
options.append('--restrict')
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
