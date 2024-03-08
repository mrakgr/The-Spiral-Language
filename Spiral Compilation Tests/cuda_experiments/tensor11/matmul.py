kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
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
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_5(long v0){
    bool v1;
    v1 = v0 < 16l;
    return v1;
}
__device__ inline bool while_method_6(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    extern __shared__ unsigned char v3[];
    float * v6;
    float * v4;
    v4 = reinterpret_cast<float *>(&v3[0ull]);
    v6 = v4;
    float * v9;
    float * v7;
    v7 = reinterpret_cast<float *>(&v3[17408ull]);
    v9 = v7;
    float * v12;
    float * v10;
    v10 = reinterpret_cast<float *>(&v3[0ull]);
    v12 = v10;
    long v13;
    v13 = threadIdx.x;
    long v14;
    v14 = v13 / 32l;
    long v15;
    v15 = v14 % 4l;
    long v16;
    v16 = v14 / 4l;
    long v17;
    v17 = v16 % 2l;
    long v18;
    v18 = v16 / 2l;
    bool v19;
    v19 = v18 == 0l;
    bool v20;
    v20 = v19 == false;
    if (v20){
        assert("The index has to be in the range of the dimension." && v19);
    } else {
    }
    assert("Tensor range check" && 0 <= v17 && v17 < 2l);
    assert("Tensor range check" && 0 <= v15 && v15 < 4l);
    long v22;
    v22 = 16l * v15;
    long v23;
    v23 = 2304l * v17;
    long v24;
    v24 = v23 + v22;
    float * v27;
    float * v25;
    v25 = v12+v24;
    v27 = v25;
    assert("Tensor range check" && 0 <= v17 && v17 < 2l);
    long v28;
    v28 = 2176l * v17;
    float * v31;
    float * v29;
    v29 = v6+v28;
    v31 = v29;
    assert("Tensor range check" && 0 <= v15 && v15 < 4l);
    long v32;
    v32 = 1088l * v15;
    float * v35;
    float * v33;
    v33 = v9+v32;
    v35 = v33;
    long v36;
    v36 = blockIdx.x;
    long v37;
    v37 = v36;
    while (while_method_0(v37)){
        long v39;
        v39 = v37 % 8l;
        long v40;
        v40 = v37 / 8l;
        long v41;
        v41 = v40 % 8l;
        long v42;
        v42 = v40 / 8l;
        bool v43;
        v43 = v42 == 0l;
        bool v44;
        v44 = v43 == false;
        if (v44){
            assert("The index has to be in the range of the dimension." && v43);
        } else {
        }
        assert("Tensor range check" && 0 <= v41 && v41 < 8l);
        assert("Tensor range check" && 0 <= v39 && v39 < 8l);
        long v46;
        v46 = 64l * v39;
        long v47;
        v47 = 32768l * v41;
        long v48;
        v48 = v47 + v46;
        float * v51;
        float * v49;
        v49 = v2+v48;
        v51 = v49;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v52[2l];
        long v53;
        v53 = 0l;
        while (while_method_1(v53)){
            long v55;
            v55 = 0l;
            while (while_method_2(v55)){
                assert("Tensor range check" && 0 <= v53 && v53 < 2l);
                assert("Tensor range check" && 0 <= v55 && v55 < 1l);
                long v57;
                v57 = v53 + v55;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v58 = v52[v57];
                wmma::fill_fragment(v58, 0.0f);
                v55 += 1l ;
            }
            v53 += 1l ;
        }
        long v59;
        v59 = 0l;
        while (while_method_3(v59)){
            assert("Tensor range check" && 0 <= v41 && v41 < 8l);
            assert("Tensor range check" && 0 <= v59 && v59 < 8l);
            long v61;
            v61 = 64l * v59;
            long v62;
            v62 = v61 + v47;
            float * v65;
            float * v63;
            v63 = v0+v62;
            v65 = v63;
            assert("Tensor range check" && 0 <= v39 && v39 < 8l);
            long v66;
            v66 = 32768l * v39;
            assert("Tensor range check" && 0 <= v59 && v59 < 8l);
            long v67;
            v67 = v61 + v66;
            float * v70;
            float * v68;
            v68 = v1+v67;
            v70 = v68;
            long v71;
            v71 = threadIdx.x;
            long v72;
            v72 = v71 % 16l;
            long v73;
            v73 = v71 / 16l;
            long v74;
            v74 = v73 % 16l;
            long v75;
            v75 = v73 / 16l;
            bool v76;
            v76 = v75 == 0l;
            bool v77;
            v77 = v76 == false;
            if (v77){
                assert("The index has to be in the range of the dimension." && v76);
            } else {
            }
            assert("Tensor range check" && 0 <= v74 && v74 < 16l);
            assert("Tensor range check" && 0 <= v72 && v72 < 16l);
            long v79;
            v79 = 4l * v72;
            long v80;
            v80 = 272l * v74;
            long v81;
            v81 = v80 + v79;
            long v82;
            v82 = 2048l * v74;
            long v83;
            v83 = v82 + v79;
            float * v86;
            float * v84;
            v84 = v9+v81;
            v86 = v84;
            float * v89;
            float * v87;
            v87 = v70+v83;
            v89 = v87;
            long v90;
            v90 = 0l;
            while (while_method_4(v90)){
                long v92;
                v92 = 0l;
                while (while_method_2(v92)){
                    assert("Tensor range check" && 0 <= v90 && v90 < 4l);
                    assert("Tensor range check" && 0 <= v92 && v92 < 1l);
                    long v94;
                    v94 = 4l * v92;
                    long v95;
                    v95 = 68l * v90;
                    long v96;
                    v96 = v95 + v94;
                    long v97;
                    v97 = 512l * v90;
                    long v98;
                    v98 = v97 + v94;
                    int4* v99;
                    v99 = reinterpret_cast<int4*>(v89 + v98);
                    int4* v100;
                    v100 = reinterpret_cast<int4*>(v86 + v96);
                    assert("Pointer alignment check" && (unsigned long long)(v99) % 4l == 0 && (unsigned long long)(v100) % 4l == 0);
                    *v100 = *v99;
                    v92 += 1l ;
                }
                v90 += 1l ;
            }
            long v101;
            v101 = threadIdx.x;
            long v102;
            v102 = v101 % 16l;
            long v103;
            v103 = v101 / 16l;
            long v104;
            v104 = v103 % 16l;
            long v105;
            v105 = v103 / 16l;
            bool v106;
            v106 = v105 == 0l;
            bool v107;
            v107 = v106 == false;
            if (v107){
                assert("The index has to be in the range of the dimension." && v106);
            } else {
            }
            assert("Tensor range check" && 0 <= v104 && v104 < 16l);
            assert("Tensor range check" && 0 <= v102 && v102 < 16l);
            long v109;
            v109 = 4l * v102;
            long v110;
            v110 = 272l * v104;
            long v111;
            v111 = v110 + v109;
            long v112;
            v112 = 2048l * v104;
            long v113;
            v113 = v112 + v109;
            float * v116;
            float * v114;
            v114 = v6+v111;
            v116 = v114;
            float * v119;
            float * v117;
            v117 = v65+v113;
            v119 = v117;
            long v120;
            v120 = 0l;
            while (while_method_4(v120)){
                long v122;
                v122 = 0l;
                while (while_method_2(v122)){
                    assert("Tensor range check" && 0 <= v120 && v120 < 4l);
                    assert("Tensor range check" && 0 <= v122 && v122 < 1l);
                    long v124;
                    v124 = 4l * v122;
                    long v125;
                    v125 = 68l * v120;
                    long v126;
                    v126 = v125 + v124;
                    long v127;
                    v127 = 512l * v120;
                    long v128;
                    v128 = v127 + v124;
                    int4* v129;
                    v129 = reinterpret_cast<int4*>(v119 + v128);
                    int4* v130;
                    v130 = reinterpret_cast<int4*>(v116 + v126);
                    assert("Pointer alignment check" && (unsigned long long)(v129) % 4l == 0 && (unsigned long long)(v130) % 4l == 0);
                    *v130 = *v129;
                    v122 += 1l ;
                }
                v120 += 1l ;
            }
            __syncthreads();
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v131[16l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v132[8l];
            long v133;
            v133 = 0l;
            while (while_method_1(v133)){
                long v135;
                v135 = 0l;
                while (while_method_2(v135)){
                    assert("Tensor range check" && 0 <= v133 && v133 < 2l);
                    long v137;
                    v137 = 1088l * v133;
                    assert("Tensor range check" && 0 <= v135 && v135 < 1l);
                    long v138;
                    v138 = 1088l * v135;
                    long v139;
                    v139 = 0l;
                    while (while_method_3(v139)){
                        assert("Tensor range check" && 0 <= v139 && v139 < 8l);
                        long v141;
                        v141 = 8l * v139;
                        long v142;
                        v142 = v141 + v137;
                        assert("Tensor range check" && 0 <= v139 && v139 < 8l);
                        long v143;
                        v143 = v141 + v138;
                        assert("Tensor range check" && 0 <= v133 && v133 < 2l);
                        assert("Tensor range check" && 0 <= v139 && v139 < 8l);
                        long v144;
                        v144 = 8l * v133;
                        long v145;
                        v145 = v144 + v139;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v146 = v131[v145];
                        float * v147;
                        v147 = v31 + v142;
                        wmma::load_matrix_sync(v146, v147, 68l);
                        #pragma unroll
                        for (int t = 0; t < v146.num_elements; t++) { v146.x[t] = wmma::__float_to_tf32(v146.x[t]); };
                        assert("Tensor range check" && 0 <= v135 && v135 < 1l);
                        assert("Tensor range check" && 0 <= v139 && v139 < 8l);
                        long v148;
                        v148 = 8l * v135;
                        long v149;
                        v149 = v148 + v139;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v150 = v132[v149];
                        float * v151;
                        v151 = v35 + v143;
                        wmma::load_matrix_sync(v150, v151, 68l);
                        #pragma unroll
                        for (int t = 0; t < v150.num_elements; t++) { v150.x[t] = wmma::__float_to_tf32(v150.x[t]); };
                        v139 += 1l ;
                    }
                    v135 += 1l ;
                }
                v133 += 1l ;
            }
            __syncthreads();
            long v152;
            v152 = 0l;
            while (while_method_1(v152)){
                long v154;
                v154 = 0l;
                while (while_method_2(v154)){
                    assert("Tensor range check" && 0 <= v152 && v152 < 2l);
                    assert("Tensor range check" && 0 <= v154 && v154 < 1l);
                    long v156;
                    v156 = v152 + v154;
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v157 = v52[v156];
                    long v158;
                    v158 = 0l;
                    while (while_method_3(v158)){
                        assert("Tensor range check" && 0 <= v152 && v152 < 2l);
                        assert("Tensor range check" && 0 <= v158 && v158 < 8l);
                        long v160;
                        v160 = 8l * v152;
                        long v161;
                        v161 = v160 + v158;
                        wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v162 = v131[v161];
                        assert("Tensor range check" && 0 <= v154 && v154 < 1l);
                        assert("Tensor range check" && 0 <= v158 && v158 < 8l);
                        long v163;
                        v163 = 8l * v154;
                        long v164;
                        v164 = v163 + v158;
                        wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> & v165 = v132[v164];
                        wmma::mma_sync(v157, v162, v165, v157);
                        v158 += 1l ;
                    }
                    v154 += 1l ;
                }
                v152 += 1l ;
            }
            v59 += 1l ;
        }
        long v166;
        v166 = threadIdx.x;
        long v167;
        v167 = v166 % 64l;
        long v168;
        v168 = v166 / 64l;
        long v169;
        v169 = v168 % 4l;
        long v170;
        v170 = v168 / 4l;
        bool v171;
        v171 = v170 == 0l;
        bool v172;
        v172 = v171 == false;
        if (v172){
            assert("The index has to be in the range of the dimension." && v171);
        } else {
        }
        assert("Tensor range check" && 0 <= v169 && v169 < 4l);
        assert("Tensor range check" && 0 <= v167 && v167 < 64l);
        long v174;
        v174 = 1152l * v169;
        long v175;
        v175 = v174 + v167;
        long v176;
        v176 = 8192l * v169;
        long v177;
        v177 = v176 + v167;
        float * v180;
        float * v178;
        v178 = v12+v175;
        v180 = v178;
        float * v183;
        float * v181;
        v181 = v51+v177;
        v183 = v181;
        long v184;
        v184 = 0l;
        while (while_method_5(v184)){
            long v186;
            v186 = 0l;
            while (while_method_2(v186)){
                assert("Tensor range check" && 0 <= v184 && v184 < 16l);
                assert("Tensor range check" && 0 <= v186 && v186 < 1l);
                long v188;
                v188 = 72l * v184;
                long v189;
                v189 = v188 + v186;
                long v190;
                v190 = 512l * v184;
                long v191;
                v191 = v190 + v186;
                int* v192;
                v192 = reinterpret_cast<int*>(v183 + v191);
                int* v193;
                v193 = reinterpret_cast<int*>(v180 + v189);
                assert("Pointer alignment check" && (unsigned long long)(v192) % 1l == 0 && (unsigned long long)(v193) % 1l == 0);
                *v193 = *v192;
                v186 += 1l ;
            }
            v184 += 1l ;
        }
        __syncthreads();
        long v194;
        v194 = 0l;
        while (while_method_1(v194)){
            long v196;
            v196 = 0l;
            while (while_method_2(v196)){
                assert("Tensor range check" && 0 <= v194 && v194 < 2l);
                assert("Tensor range check" && 0 <= v196 && v196 < 1l);
                long v198;
                v198 = v194 + v196;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v199 = v52[v198];
                assert("Tensor range check" && 0 <= v194 && v194 < 2l);
                assert("Tensor range check" && 0 <= v196 && v196 < 1l);
                long v200;
                v200 = 16l * v196;
                long v201;
                v201 = 1152l * v194;
                long v202;
                v202 = v201 + v200;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v203;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v204 = v203;
                float * v205;
                v205 = v27 + v202;
                wmma::load_matrix_sync(v204, v205, 72l, wmma::mem_row_major);
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v206 = v199;
                long v207;
                v207 = v206.num_elements;
                long v208;
                v208 = 0l;
                while (while_method_6(v207, v208)){
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v210 = v199;
                    float v211;
                    v211 = v210.x[v208];
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v212 = v204;
                    float v213;
                    v213 = v212.x[v208];
                    float v214;
                    v214 = v211 + v213;
                    wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> & v215 = v199;
                    v215.x[v208] = v214;
                    v208 += 1l ;
                }
                float * v216;
                v216 = v27 + v202;
                wmma::store_matrix_sync(v216, v199, 72l, wmma::mem_row_major);
                v196 += 1l ;
            }
            v194 += 1l ;
        }
        __syncthreads();
        long v217;
        v217 = threadIdx.x;
        long v218;
        v218 = v217 % 16l;
        long v219;
        v219 = v217 / 16l;
        long v220;
        v220 = v219 % 16l;
        long v221;
        v221 = v219 / 16l;
        bool v222;
        v222 = v221 == 0l;
        bool v223;
        v223 = v222 == false;
        if (v223){
            assert("The index has to be in the range of the dimension." && v222);
        } else {
        }
        assert("Tensor range check" && 0 <= v220 && v220 < 16l);
        assert("Tensor range check" && 0 <= v218 && v218 < 16l);
        long v225;
        v225 = 4l * v218;
        long v226;
        v226 = 2048l * v220;
        long v227;
        v227 = v226 + v225;
        long v228;
        v228 = 288l * v220;
        long v229;
        v229 = v228 + v225;
        float * v232;
        float * v230;
        v230 = v51+v227;
        v232 = v230;
        float * v235;
        float * v233;
        v233 = v12+v229;
        v235 = v233;
        long v236;
        v236 = 0l;
        while (while_method_4(v236)){
            long v238;
            v238 = 0l;
            while (while_method_2(v238)){
                assert("Tensor range check" && 0 <= v236 && v236 < 4l);
                assert("Tensor range check" && 0 <= v238 && v238 < 1l);
                long v240;
                v240 = 4l * v238;
                long v241;
                v241 = 512l * v236;
                long v242;
                v242 = v241 + v240;
                long v243;
                v243 = 72l * v236;
                long v244;
                v244 = v243 + v240;
                int4* v245;
                v245 = reinterpret_cast<int4*>(v235 + v244);
                int4* v246;
                v246 = reinterpret_cast<int4*>(v232 + v242);
                assert("Pointer alignment check" && (unsigned long long)(v245) % 4l == 0 && (unsigned long long)(v246) % 4l == 0);
                *v246 = *v245;
                v238 += 1l ;
            }
            v236 += 1l ;
        }
        __syncthreads();
        v37 += 48l ;
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
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
    del v0
    return v1
def main():
    v0 = cp.random.normal(0.0,1.0,262144,cp.float32)
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
    v5 = cp.random.normal(0.0,1.0,262144,cp.float32)
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
    v10 = cp.random.normal(0.0,1.0,262144,cp.float32)
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
        v27 = 0
        v28 = raw_module.get_function(f"entry{v27}")
        del v27
        v28.max_dynamic_shared_size_bytes = 34816 
        v28((48,),(256,),(v10, v5, v0),shared_mem=34816)
        del v28
        v29 = cp.max(cp.abs(v0-v22))
        del v22
        v30 = v29 + v16
        del v29
        v16 = v30
        del v30
        v15 += 1 
    del v0, v5, v10, v15
    return v16

if __name__ == '__main__': print(main())
