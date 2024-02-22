kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 1024l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 2048l;
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
        v19 = v17 % 4l;
        long v20;
        v20 = v17 / 4l;
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
        assert("Tensor range check" && 0 <= v21 && v21 < 8l);
        long v26;
        v26 = 32768l * v21;
        assert("Tensor range check" && 0 <= v19 && v19 < 4l);
        long v27;
        v27 = 65536l * v19;
        assert("Tensor range check" && 0 <= v21 && v21 < 8l);
        assert("Tensor range check" && 0 <= v19 && v19 < 4l);
        long v28;
        v28 = 128l * v19;
        long v29;
        v29 = v26 + v28;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v30;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v31;
        wmma::fill_fragment(v31, 0.0f);
        long v32;
        v32 = 0l;
        while (while_method_1(v32)){
            long v34;
            v34 = v32 % 8l;
            long v35;
            v35 = v32 / 8l;
            bool v36;
            v36 = v35 == 0l;
            bool v37;
            v37 = v36 == false;
            if (v37){
                assert("The index has to be in the range of the dimension." && v36);
            } else {
            }
            assert("Tensor range check" && 0 <= v34 && v34 < 8l);
            long v39;
            v39 = 64l * v34;
            long v40;
            v40 = v39 + v26;
            assert("Tensor range check" && 0 <= v34 && v34 < 8l);
            long v41;
            v41 = v39 + v27;
            long v42;
            v42 = v4.meta_group_size();
            long v43;
            v43 = v4.meta_group_rank();
            long v44;
            v44 = v43;
            while (while_method_2(v44)){
                long v46;
                v46 = v44 % 2l;
                long v47;
                v47 = v44 / 2l;
                long v48;
                v48 = v47 % 8l;
                long v49;
                v49 = v47 / 8l;
                long v50;
                v50 = v49 % 16l;
                long v51;
                v51 = v49 / 16l;
                long v52;
                v52 = v51 % 4l;
                long v53;
                v53 = v51 / 4l;
                bool v54;
                v54 = v53 == 0l;
                bool v55;
                v55 = v54 == false;
                if (v55){
                    assert("The index has to be in the range of the dimension." && v54);
                } else {
                }
                assert("Tensor range check" && 0 <= v52 && v52 < 4l);
                assert("Tensor range check" && 0 <= v50 && v50 < 16l);
                assert("Tensor range check" && 0 <= v48 && v48 < 8l);
                assert("Tensor range check" && 0 <= v46 && v46 < 2l);
                long v57;
                v57 = 4l * v46;
                long v58;
                v58 = v57 + v40;
                long v59;
                v59 = 8l * v48;
                long v60;
                v60 = v59 + v58;
                long v61;
                v61 = 512l * v50;
                long v62;
                v62 = v61 + v60;
                long v63;
                v63 = 8192l * v52;
                long v64;
                v64 = v63 + v62;
                assert("Tensor range check" && 0 <= v52 && v52 < 4l);
                assert("Tensor range check" && 0 <= v50 && v50 < 16l);
                assert("Tensor range check" && 0 <= v48 && v48 < 8l);
                assert("Tensor range check" && 0 <= v46 && v46 < 2l);
                long v65;
                v65 = 136l * v48;
                long v66;
                v66 = v65 + v57;
                long v67;
                v67 = 8l * v50;
                long v68;
                v68 = v67 + v66;
                long v69;
                v69 = 1088l * v52;
                long v70;
                v70 = v69 + v68;
                cooperative_groups::memcpy_async(v4, v8 + v70, v0 + v64, sizeof(float) * 4l);
                v44 += v42 ;
            }
            long v71;
            v71 = v4.meta_group_size();
            long v72;
            v72 = v4.meta_group_rank();
            long v73;
            v73 = v72;
            while (while_method_3(v73)){
                long v75;
                v75 = v73 % 2l;
                long v76;
                v76 = v73 / 2l;
                long v77;
                v77 = v76 % 8l;
                long v78;
                v78 = v76 / 8l;
                long v79;
                v79 = v78 % 16l;
                long v80;
                v80 = v78 / 16l;
                long v81;
                v81 = v80 % 8l;
                long v82;
                v82 = v80 / 8l;
                bool v83;
                v83 = v82 == 0l;
                bool v84;
                v84 = v83 == false;
                if (v84){
                    assert("The index has to be in the range of the dimension." && v83);
                } else {
                }
                assert("Tensor range check" && 0 <= v81 && v81 < 8l);
                assert("Tensor range check" && 0 <= v79 && v79 < 16l);
                assert("Tensor range check" && 0 <= v77 && v77 < 8l);
                assert("Tensor range check" && 0 <= v75 && v75 < 2l);
                long v86;
                v86 = 4l * v75;
                long v87;
                v87 = v86 + v41;
                long v88;
                v88 = 8l * v77;
                long v89;
                v89 = v88 + v87;
                long v90;
                v90 = 512l * v79;
                long v91;
                v91 = v90 + v89;
                long v92;
                v92 = 8192l * v81;
                long v93;
                v93 = v92 + v91;
                assert("Tensor range check" && 0 <= v81 && v81 < 8l);
                assert("Tensor range check" && 0 <= v79 && v79 < 16l);
                assert("Tensor range check" && 0 <= v77 && v77 < 8l);
                assert("Tensor range check" && 0 <= v75 && v75 < 2l);
                long v94;
                v94 = 136l * v77;
                long v95;
                v95 = v94 + v86;
                long v96;
                v96 = 8l * v79;
                long v97;
                v97 = v96 + v95;
                long v98;
                v98 = 1088l * v81;
                long v99;
                v99 = v98 + v97;
                cooperative_groups::memcpy_async(v4, v11 + v99, v1 + v93, sizeof(float) * 4l);
                v73 += v71 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v100;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v101;
            long v102;
            v102 = thread_block::num_threads() / warpSize;
            long v103;
            v103 = thread_block::thread_rank() / warpSize;
            long v104;
            v104 = v103;
            while (while_method_0(v104)){
                long v106;
                v106 = v104 % 8l;
                long v107;
                v107 = v104 / 8l;
                long v108;
                v108 = v107 % 4l;
                long v109;
                v109 = v107 / 4l;
                bool v110;
                v110 = v109 == 0l;
                bool v111;
                v111 = v110 == false;
                if (v111){
                    assert("The index has to be in the range of the dimension." && v110);
                } else {
                }
                assert("Tensor range check" && 0 <= v108 && v108 < 4l);
                long v113;
                v113 = 1088l * v108;
                assert("Tensor range check" && 0 <= v106 && v106 < 8l);
                long v114;
                v114 = 1088l * v106;
                long v115;
                v115 = 0l;
                while (while_method_1(v115)){
                    long v117;
                    v117 = v115 % 8l;
                    long v118;
                    v118 = v115 / 8l;
                    bool v119;
                    v119 = v118 == 0l;
                    bool v120;
                    v120 = v119 == false;
                    if (v120){
                        assert("The index has to be in the range of the dimension." && v119);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v117 && v117 < 8l);
                    long v122;
                    v122 = 136l * v117;
                    long v123;
                    v123 = v122 + v113;
                    assert("Tensor range check" && 0 <= v117 && v117 < 8l);
                    long v124;
                    v124 = v122 + v114;
                    float * v125;
                    v125 = v8 + v123;
                    wmma::load_matrix_sync(v100, v125, 8l);
                    #pragma unroll
                    for (int t = 0; t < v100.num_elements; t++) { v100.x[t] = wmma::__float_to_tf32(v100.x[t]); };
                    float * v126;
                    v126 = v11 + v124;
                    wmma::load_matrix_sync(v101, v126, 8l);
                    #pragma unroll
                    for (int t = 0; t < v101.num_elements; t++) { v101.x[t] = wmma::__float_to_tf32(v101.x[t]); };
                    wmma::mma_sync(v31, v100, v101, v31);
                    v115 += 1l ;
                }
                v104 += v102 ;
            }
            v3.sync() ;
            v32 += 1l ;
        }
        long v127;
        v127 = v4.meta_group_size();
        long v128;
        v128 = v4.meta_group_rank();
        long v129;
        v129 = v128;
        while (while_method_3(v129)){
            long v131;
            v131 = v129 % 4l;
            long v132;
            v132 = v129 / 4l;
            long v133;
            v133 = v132 % 8l;
            long v134;
            v134 = v132 / 8l;
            long v135;
            v135 = v134 % 16l;
            long v136;
            v136 = v134 / 16l;
            long v137;
            v137 = v136 % 4l;
            long v138;
            v138 = v136 / 4l;
            bool v139;
            v139 = v138 == 0l;
            bool v140;
            v140 = v139 == false;
            if (v140){
                assert("The index has to be in the range of the dimension." && v139);
            } else {
            }
            assert("Tensor range check" && 0 <= v137 && v137 < 4l);
            assert("Tensor range check" && 0 <= v135 && v135 < 16l);
            assert("Tensor range check" && 0 <= v133 && v133 < 8l);
            assert("Tensor range check" && 0 <= v131 && v131 < 4l);
            long v142;
            v142 = 4l * v131;
            long v143;
            v143 = v142 + v29;
            long v144;
            v144 = 16l * v133;
            long v145;
            v145 = v144 + v143;
            long v146;
            v146 = 512l * v135;
            long v147;
            v147 = v146 + v145;
            long v148;
            v148 = 8192l * v137;
            long v149;
            v149 = v148 + v147;
            assert("Tensor range check" && 0 <= v137 && v137 < 4l);
            assert("Tensor range check" && 0 <= v135 && v135 < 16l);
            assert("Tensor range check" && 0 <= v133 && v133 < 8l);
            assert("Tensor range check" && 0 <= v131 && v131 < 4l);
            long v150;
            v150 = 272l * v133;
            long v151;
            v151 = v150 + v142;
            long v152;
            v152 = 16l * v135;
            long v153;
            v153 = v152 + v151;
            long v154;
            v154 = 2176l * v137;
            long v155;
            v155 = v154 + v153;
            cooperative_groups::memcpy_async(v4, v14 + v155, v2 + v149, sizeof(float) * 4l);
            v129 += v127 ;
        }
        cooperative_groups::wait(v4);
        v3.sync() ;
        long v156;
        v156 = thread_block::num_threads() / warpSize;
        long v157;
        v157 = thread_block::thread_rank() / warpSize;
        long v158;
        v158 = v157;
        while (while_method_0(v158)){
            long v160;
            v160 = v158 % 8l;
            long v161;
            v161 = v158 / 8l;
            long v162;
            v162 = v161 % 4l;
            long v163;
            v163 = v161 / 4l;
            bool v164;
            v164 = v163 == 0l;
            bool v165;
            v165 = v164 == false;
            if (v165){
                assert("The index has to be in the range of the dimension." && v164);
            } else {
            }
            assert("Tensor range check" && 0 <= v162 && v162 < 4l);
            assert("Tensor range check" && 0 <= v160 && v160 < 8l);
            long v167;
            v167 = 272l * v160;
            long v168;
            v168 = 2176l * v162;
            long v169;
            v169 = v168 + v167;
            float * v170;
            v170 = v14 + v169;
            wmma::load_matrix_sync(v30, v170, 16l, wmma::mem_row_major);
            long v171;
            v171 = v30.num_elements;
            long v172;
            v172 = 0l;
            while (while_method_4(v171, v172)){
                float v174;
                v174 = v31.x[v172];
                float v175;
                v175 = v30.x[v172];
                float v176;
                v176 = 0.0f * v175;
                float v177;
                v177 = v174 + v176;
                v30.x[v172] = v177;
                v172 += 1l ;
            }
            float * v178;
            v178 = v14 + v169;
            wmma::store_matrix_sync(v178, v30, 16l, wmma::mem_row_major);
            v158 += v156 ;
        }
        v3.sync() ;
        long v179;
        v179 = v4.meta_group_size();
        long v180;
        v180 = v4.meta_group_rank();
        long v181;
        v181 = v180;
        while (while_method_3(v181)){
            long v183;
            v183 = v181 % 4l;
            long v184;
            v184 = v181 / 4l;
            long v185;
            v185 = v184 % 8l;
            long v186;
            v186 = v184 / 8l;
            long v187;
            v187 = v186 % 16l;
            long v188;
            v188 = v186 / 16l;
            long v189;
            v189 = v188 % 4l;
            long v190;
            v190 = v188 / 4l;
            bool v191;
            v191 = v190 == 0l;
            bool v192;
            v192 = v191 == false;
            if (v192){
                assert("The index has to be in the range of the dimension." && v191);
            } else {
            }
            assert("Tensor range check" && 0 <= v189 && v189 < 4l);
            assert("Tensor range check" && 0 <= v187 && v187 < 16l);
            assert("Tensor range check" && 0 <= v185 && v185 < 8l);
            assert("Tensor range check" && 0 <= v183 && v183 < 4l);
            long v194;
            v194 = 4l * v183;
            long v195;
            v195 = 272l * v185;
            long v196;
            v196 = v195 + v194;
            long v197;
            v197 = 16l * v187;
            long v198;
            v198 = v197 + v196;
            long v199;
            v199 = 2176l * v189;
            long v200;
            v200 = v199 + v198;
            assert("Tensor range check" && 0 <= v189 && v189 < 4l);
            assert("Tensor range check" && 0 <= v187 && v187 < 16l);
            assert("Tensor range check" && 0 <= v185 && v185 < 8l);
            assert("Tensor range check" && 0 <= v183 && v183 < 4l);
            long v201;
            v201 = v194 + v29;
            long v202;
            v202 = 16l * v185;
            long v203;
            v203 = v202 + v201;
            long v204;
            v204 = 512l * v187;
            long v205;
            v205 = v204 + v203;
            long v206;
            v206 = 8192l * v189;
            long v207;
            v207 = v206 + v205;
            cooperative_groups::memcpy_async(v4, v2 + v207, v14 + v200, sizeof(float) * 4l);
            v181 += v179 ;
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
options.append('--define-macro=NDEBUG')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 100
    del v0
    return v1
def main():
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),1024,is_print=True)
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
        del v21
        v22 = (cp.matmul(v18,v20)).flatten()
        del v18, v20
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
        v27 = 0
        v28 = raw_module.get_function(f"entry{v27}")
        del v27
        v28.max_dynamic_shared_size_bytes = 52224 
        v28((24,),(1024,),(v10, v5, v0),shared_mem=52224)
        del v28
        v29 = cp.max(cp.abs(v0-v22))
        del v22
        v30 = v29 + v16
        del v29
        v16 = v30
        del v30
        v15 += 1 
    del v0, v5, v10, v15
    v31 = v16 / 100.0
    del v16
    return v31

if __name__ == '__main__': print(main())
