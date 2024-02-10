kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 64l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 128l;
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_5(long v0, long v1){
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
        v9 = v7 % 2l;
        long v10;
        v10 = v7 / 2l;
        long v11;
        v11 = v10 % 4l;
        long v12;
        v12 = v10 / 4l;
        bool v13;
        v13 = v12 == 0l;
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The index has to be in the range of the dimension." && v13);
        } else {
        }
        assert("Tensor range check" && 0 <= v11 && v11 < 4l);
        long v16;
        v16 = 16384l * v11;
        assert("Tensor range check" && 0 <= v9 && v9 < 2l);
        long v17;
        v17 = 32768l * v9;
        assert("Tensor range check" && 0 <= v11 && v11 < 4l);
        assert("Tensor range check" && 0 <= v9 && v9 < 2l);
        long v18;
        v18 = 128l * v9;
        long v19;
        v19 = v16 + v18;
        __shared__ float v20[8192l];
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v21;
        long v22;
        v22 = v4.meta_group_size();
        long v23;
        v23 = v4.meta_group_rank();
        long v24;
        v24 = v23;
        while (while_method_1(v24)){
            long v26;
            v26 = v24 % 64l;
            long v27;
            v27 = v24 / 64l;
            bool v28;
            v28 = v27 == 0l;
            bool v29;
            v29 = v28 == false;
            if (v29){
                assert("The index has to be in the range of the dimension." && v28);
            } else {
            }
            assert("Tensor range check" && 0 <= v26 && v26 < 64l);
            long v31;
            v31 = 256l * v26;
            long v32;
            v32 = v31 + v19;
            assert("Tensor range check" && 0 <= v26 && v26 < 64l);
            long v33;
            v33 = 128l * v26;
            cooperative_groups::memcpy_async(v4, v20 + v33, v2 + v32, sizeof(float) * 128l);
            v24 += v22 ;
        }
        long v34;
        v34 = 0l;
        while (while_method_2(v34)){
            long v36;
            v36 = v34 % 4l;
            long v37;
            v37 = v34 / 4l;
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
            assert("Tensor range check" && 0 <= v36 && v36 < 4l);
            long v43;
            v43 = 64l * v36;
            long v44;
            v44 = v43 + v16;
            __shared__ float v45[4096l];
            wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v46;
            v3.sync() ;
            long v47;
            v47 = v4.meta_group_size();
            long v48;
            v48 = v4.meta_group_rank();
            long v49;
            v49 = v48;
            while (while_method_1(v49)){
                long v51;
                v51 = v49 % 64l;
                long v52;
                v52 = v49 / 64l;
                bool v53;
                v53 = v52 == 0l;
                bool v54;
                v54 = v53 == false;
                if (v54){
                    assert("The index has to be in the range of the dimension." && v53);
                } else {
                }
                assert("Tensor range check" && 0 <= v51 && v51 < 64l);
                long v56;
                v56 = 256l * v51;
                long v57;
                v57 = v56 + v44;
                assert("Tensor range check" && 0 <= v51 && v51 < 64l);
                long v58;
                v58 = 64l * v51;
                cooperative_groups::memcpy_async(v4, v45 + v58, v0 + v57, sizeof(float) * 64l);
                v49 += v47 ;
            }
            assert("Tensor range check" && 0 <= v36 && v36 < 4l);
            long v59;
            v59 = v43 + v17;
            __shared__ float v60[8192l];
            wmma::fragment<wmma::matrix_b, 16l, 16l, 8l, wmma::precision::tf32, wmma::col_major> v61;
            long v62;
            v62 = v4.meta_group_size();
            long v63;
            v63 = v4.meta_group_rank();
            long v64;
            v64 = v63;
            while (while_method_3(v64)){
                long v66;
                v66 = v64 % 128l;
                long v67;
                v67 = v64 / 128l;
                bool v68;
                v68 = v67 == 0l;
                bool v69;
                v69 = v68 == false;
                if (v69){
                    assert("The index has to be in the range of the dimension." && v68);
                } else {
                }
                assert("Tensor range check" && 0 <= v66 && v66 < 128l);
                long v71;
                v71 = 256l * v66;
                long v72;
                v72 = v71 + v59;
                assert("Tensor range check" && 0 <= v66 && v66 < 128l);
                long v73;
                v73 = 64l * v66;
                cooperative_groups::memcpy_async(v4, v60 + v73, v1 + v72, sizeof(float) * 64l);
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
            while (while_method_4(v76)){
                long v78;
                v78 = v76 % 8l;
                long v79;
                v79 = v76 / 8l;
                long v80;
                v80 = v79 % 4l;
                long v81;
                v81 = v79 / 4l;
                bool v82;
                v82 = v81 == 0l;
                bool v83;
                v83 = v82 == false;
                if (v83){
                    assert("The index has to be in the range of the dimension." && v82);
                } else {
                }
                assert("Tensor range check" && 0 <= v80 && v80 < 4l);
                long v85;
                v85 = 1024l * v80;
                assert("Tensor range check" && 0 <= v78 && v78 < 8l);
                long v86;
                v86 = 1024l * v78;
                assert("Tensor range check" && 0 <= v80 && v80 < 4l);
                assert("Tensor range check" && 0 <= v78 && v78 < 8l);
                long v87;
                v87 = 16l * v78;
                long v88;
                v88 = 2048l * v80;
                long v89;
                v89 = v88 + v87;
                wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v90;
                wmma::fill_fragment(v90, 0.0f);
                long v91;
                v91 = 0l;
                while (while_method_0(v91)){
                    long v93;
                    v93 = v91 % 8l;
                    long v94;
                    v94 = v91 / 8l;
                    bool v95;
                    v95 = v94 == 0l;
                    bool v96;
                    v96 = v95 == false;
                    if (v96){
                        assert("The index has to be in the range of the dimension." && v95);
                    } else {
                    }
                    assert("Tensor range check" && 0 <= v93 && v93 < 8l);
                    long v98;
                    v98 = 8l * v93;
                    long v99;
                    v99 = v98 + v85;
                    assert("Tensor range check" && 0 <= v93 && v93 < 8l);
                    long v100;
                    v100 = v98 + v86;
                    float * v101;
                    v101 = v45 + v99;
                    wmma::load_matrix_sync(v46, v101, 64l);
                    #pragma unroll
                    for (int t = 0; t < v46.num_elements; t++) { v46.x[t] = wmma::__float_to_tf32(v46.x[t]); };
                    float * v102;
                    v102 = v60 + v100;
                    wmma::load_matrix_sync(v61, v102, 64l);
                    #pragma unroll
                    for (int t = 0; t < v61.num_elements; t++) { v61.x[t] = wmma::__float_to_tf32(v61.x[t]); };
                    wmma::mma_sync(v90, v46, v61, v90);
                    v91 += 1l ;
                }
                float * v103;
                v103 = v20 + v89;
                wmma::load_matrix_sync(v21, v103, 128l, wmma::mem_row_major);
                long v104;
                v104 = v21.num_elements;
                long v105;
                v105 = 0l;
                while (while_method_5(v104, v105)){
                    float v107;
                    v107 = v90.x[v105];
                    float v108;
                    v108 = v21.x[v105];
                    float v109;
                    v109 = v42 * v108;
                    float v110;
                    v110 = v107 + v109;
                    v21.x[v105] = v110;
                    v105 += 1l ;
                }
                float * v111;
                v111 = v20 + v89;
                wmma::store_matrix_sync(v111, v21, 128l, wmma::mem_row_major);
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
            v116 = v114 % 64l;
            long v117;
            v117 = v114 / 64l;
            bool v118;
            v118 = v117 == 0l;
            bool v119;
            v119 = v118 == false;
            if (v119){
                assert("The index has to be in the range of the dimension." && v118);
            } else {
            }
            assert("Tensor range check" && 0 <= v116 && v116 < 64l);
            long v121;
            v121 = 128l * v116;
            assert("Tensor range check" && 0 <= v116 && v116 < 64l);
            long v122;
            v122 = 256l * v116;
            long v123;
            v123 = v122 + v19;
            cooperative_groups::memcpy_async(v4, v2 + v123, v20 + v121, sizeof(float) * 128l);
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

options = []
options.append('--diag-suppress=550')
options.append('--define-macro=NDEBUG')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
from max_blocks_per_sm import max_blocks_per_sm
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
    v17 = cp.transpose(v16)
    del v16
    v18 = v0.reshape((256, 256))
    del v18
    v19 = (cp.matmul(v15,v17)).flatten()
    del v15, v17
    v20 = v19.size
    v21 = 65536 == v20
    del v20
    v22 = v21 == False
    if v22:
        v23 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v21, v23
        del v23
    else:
        pass
    del v21, v22
    v24 = 0
    raw_module.get_function(f"entry{v24}")((8,),(1024,),(v10, v5, v0),shared_mem=86912)
    del v5, v10, v24
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),1024,is_print=True)
    v25 = cp.max(cp.abs(v0-v19))
    del v0, v19
    return v25

if __name__ == '__main__': print(main())
