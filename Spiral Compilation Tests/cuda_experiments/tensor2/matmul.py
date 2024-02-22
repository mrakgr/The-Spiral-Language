kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 256l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 16l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_4(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    thread_block_tile<32l, thread_block> v4 = tiled_partition<32l>(v3);
    long v5;
    v5 = grid_group::num_blocks();
    long v6;
    v6 = grid_group::block_rank();
    long v7;
    v7 = v6;
    while (while_method_0(v7)){
        long v9;
        v9 = v7 % 16l;
        long v10;
        v10 = v7 / 16l;
        long v11;
        v11 = v10 % 16l;
        long v12;
        v12 = v10 / 16l;
        bool v13;
        v13 = v12 == 0l;
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The index has to be in the range of the dimension." && v13);
        } else {
        }
        assert("Tensor range check" && 0 <= v11 && v11 < 16l);
        long v16;
        v16 = 16384l * v11;
        assert("Tensor range check" && 0 <= v9 && v9 < 16l);
        long v17;
        v17 = 16384l * v9;
        assert("Tensor range check" && 0 <= v11 && v11 < 16l);
        assert("Tensor range check" && 0 <= v9 && v9 < 16l);
        long v18;
        v18 = 32l * v9;
        long v19;
        v19 = v16 + v18;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v20;
        __shared__ float v21[1536l];
        long v22;
        v22 = v4.meta_group_size();
        long v23;
        v23 = v4.meta_group_rank();
        long v24;
        v24 = v23;
        while (while_method_1(v24)){
            long v26;
            v26 = v24 % 32l;
            long v27;
            v27 = v24 / 32l;
            bool v28;
            v28 = v27 == 0l;
            bool v29;
            v29 = v28 == false;
            if (v29){
                assert("The index has to be in the range of the dimension." && v28);
            } else {
            }
            assert("Tensor range check" && 0 <= v26 && v26 < 32l);
            long v31;
            v31 = 512l * v26;
            long v32;
            v32 = v31 + v19;
            assert("Tensor range check" && 0 <= v26 && v26 < 32l);
            long v33;
            v33 = 48l * v26;
            cooperative_groups::memcpy_async(v4, v21 + v33, v2 + v32, sizeof(float) * 32l);
            v24 += v22 ;
        }
        long v34;
        v34 = 0l;
        while (while_method_2(v34)){
            long v36;
            v36 = v34 % 16l;
            long v37;
            v37 = v34 / 16l;
            bool v38;
            v38 = v37 == 0l;
            bool v39;
            v39 = v38 == false;
            if (v39){
                assert("The index has to be in the range of the dimension." && v38);
            } else {
            }
            bool v41;
            v41 = v36 == 0l;
            float v42;
            if (v41){
                v42 = 0.0f;
            } else {
                v42 = 1.0f;
            }
            assert("Tensor range check" && 0 <= v36 && v36 < 16l);
            long v43;
            v43 = 32l * v36;
            long v44;
            v44 = v43 + v16;
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v45;
            __shared__ float v46[1280l];
            v3.sync() ;
            long v47;
            v47 = v4.meta_group_size();
            long v48;
            v48 = v4.meta_group_rank();
            long v49;
            v49 = v48;
            while (while_method_1(v49)){
                long v51;
                v51 = v49 % 32l;
                long v52;
                v52 = v49 / 32l;
                bool v53;
                v53 = v52 == 0l;
                bool v54;
                v54 = v53 == false;
                if (v54){
                    assert("The index has to be in the range of the dimension." && v53);
                } else {
                }
                assert("Tensor range check" && 0 <= v51 && v51 < 32l);
                long v56;
                v56 = 512l * v51;
                long v57;
                v57 = v56 + v44;
                assert("Tensor range check" && 0 <= v51 && v51 < 32l);
                long v58;
                v58 = 40l * v51;
                cooperative_groups::memcpy_async(v4, v46 + v58, v0 + v57, sizeof(float) * 32l);
                v49 += v47 ;
            }
            assert("Tensor range check" && 0 <= v36 && v36 < 16l);
            long v59;
            v59 = v43 + v17;
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v60;
            __shared__ float v61[1280l];
            long v62;
            v62 = v4.meta_group_size();
            long v63;
            v63 = v4.meta_group_rank();
            long v64;
            v64 = v63;
            while (while_method_1(v64)){
                long v66;
                v66 = v64 % 32l;
                long v67;
                v67 = v64 / 32l;
                bool v68;
                v68 = v67 == 0l;
                bool v69;
                v69 = v68 == false;
                if (v69){
                    assert("The index has to be in the range of the dimension." && v68);
                } else {
                }
                assert("Tensor range check" && 0 <= v66 && v66 < 32l);
                long v71;
                v71 = 512l * v66;
                long v72;
                v72 = v71 + v59;
                assert("Tensor range check" && 0 <= v66 && v66 < 32l);
                long v73;
                v73 = 40l * v66;
                cooperative_groups::memcpy_async(v4, v61 + v73, v1 + v72, sizeof(float) * 32l);
                v64 += v62 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            long v74;
            v74 = thread_block::num_threads() / warpSize;
            long v75;
            v75 = thread_block::thread_rank() / warpSize;
            long v76;
            v76 = v75;
            while (while_method_3(v76)){
                long v78;
                v78 = v76 % 2l;
                long v79;
                v79 = v76 / 2l;
                long v80;
                v80 = v79 % 2l;
                long v81;
                v81 = v79 / 2l;
                bool v82;
                v82 = v81 == 0l;
                bool v83;
                v83 = v82 == false;
                if (v83){
                    assert("The index has to be in the range of the dimension." && v82);
                } else {
                }
                assert("Tensor range check" && 0 <= v80 && v80 < 2l);
                long v85;
                v85 = 640l * v80;
                assert("Tensor range check" && 0 <= v78 && v78 < 2l);
                long v86;
                v86 = 640l * v78;
                assert("Tensor range check" && 0 <= v80 && v80 < 2l);
                assert("Tensor range check" && 0 <= v78 && v78 < 2l);
                long v87;
                v87 = 16l * v78;
                long v88;
                v88 = 768l * v80;
                long v89;
                v89 = v88 + v87;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v90;
                wmma::fill_fragment(v90, 0.0f);
                long v91;
                v91 = 0l;
                while (while_method_3(v91)){
                    long v93;
                    v93 = v91 % 4l;
                    long v94;
                    v94 = v91 / 4l;
                    bool v95;
                    v95 = v94 == 0l;
                    bool v96;
                    v96 = v95 == false;
                    if (v96){
                        assert("The index has to be in the range of the dimension." && v95);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v93 && v93 < 4l);
                    long v98;
                    v98 = 8l * v93;
                    long v99;
                    v99 = v98 + v85;
                    assert("Tensor range check" && 0 <= v93 && v93 < 4l);
                    long v100;
                    v100 = v98 + v86;
                    float * v101;
                    v101 = v46 + v99;
                    wmma::load_matrix_sync(v45, v101, 40l);
                    #pragma unroll
                    for (int t = 0; t < v45.num_elements; t++) { v45.x[t] = wmma::__float_to_tf32(v45.x[t]); };
                    float * v102;
                    v102 = v61 + v100;
                    wmma::load_matrix_sync(v60, v102, 40l);
                    #pragma unroll
                    for (int t = 0; t < v60.num_elements; t++) { v60.x[t] = wmma::__float_to_tf32(v60.x[t]); };
                    wmma::mma_sync(v90, v45, v60, v90);
                    v91 += 1l ;
                }
                float * v103;
                v103 = v21 + v89;
                wmma::load_matrix_sync(v20, v103, 48l, wmma::mem_row_major);
                long v104;
                v104 = v20.num_elements;
                long v105;
                v105 = 0l;
                while (while_method_4(v104, v105)){
                    float v107;
                    v107 = v90.x[v105];
                    float v108;
                    v108 = v20.x[v105];
                    float v109;
                    v109 = v42 * v108;
                    float v110;
                    v110 = v107 + v109;
                    v20.x[v105] = v110;
                    v105 += 1l ;
                }
                float * v111;
                v111 = v21 + v89;
                wmma::store_matrix_sync(v111, v20, 48l, wmma::mem_row_major);
                v76 += v74 ;
            }
            v34 += 1l ;
        }
        v3.sync() ;
        long v112;
        v112 = v4.meta_group_size();
        long v113;
        v113 = v4.meta_group_rank();
        long v114;
        v114 = v113;
        while (while_method_1(v114)){
            long v116;
            v116 = v114 % 32l;
            long v117;
            v117 = v114 / 32l;
            bool v118;
            v118 = v117 == 0l;
            bool v119;
            v119 = v118 == false;
            if (v119){
                assert("The index has to be in the range of the dimension." && v118);
            } else {
            }
            assert("Tensor range check" && 0 <= v116 && v116 < 32l);
            long v121;
            v121 = 48l * v116;
            assert("Tensor range check" && 0 <= v116 && v116 < 32l);
            long v122;
            v122 = 512l * v116;
            long v123;
            v123 = v122 + v19;
            cooperative_groups::memcpy_async(v4, v2 + v123, v21 + v121, sizeof(float) * 32l);
            v114 += v112 ;
        }
        v7 += v5 ;
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
options.append('--maxrregcount=42')
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
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),256,is_print=True)
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
        raw_module.get_function(f"entry{v27}")((144, 1, 1),(256, 1, 1),(v10, v5, v0))
        del v27
        v28 = cp.max(cp.abs(v0-v22))
        del v22
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
