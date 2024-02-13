kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = this_thread_block();
    thread_block_tile<1l, thread_block> v4 = tiled_partition<1l>(v3);
    extern __shared__ unsigned char * v5;
    float * v8;
    float * v6;
    v6 = reinterpret_cast<float *>(v5+0ull);
    v8 = v6;
    float * v11;
    float * v9;
    v9 = reinterpret_cast<float *>(v5+544ull);
    v11 = v9;
    float * v14;
    float * v12;
    v12 = reinterpret_cast<float *>(v5+0ull);
    v14 = v12;
    long v15;
    v15 = grid_group::num_blocks();
    long v16;
    v16 = grid_group::block_rank();
    long v17;
    v17 = v16;
    while (while_method_0(v17)){
        long v19;
        v19 = v17 % 1l;
        bool v20;
        v20 = v17 == 0l;
        bool v21;
        v21 = v20 == false;
        if (v21){
            assert("The index has to be in the range of the dimension." && v20);
        } else {
        }
        assert("Tensor range check" && 0 <= v19 && v19 < 1l);
        long v23;
        v23 = 128l * v19;
        assert("Tensor range check" && 0 <= v19 && v19 < 1l);
        long v24;
        v24 = 16l * v19;
        assert("Tensor range check" && 0 <= v19 && v19 < 1l);
        assert("Tensor range check" && 0 <= v19 && v19 < 1l);
        long v25;
        v25 = 256l * v19;
        long v26;
        v26 = v25 + v24;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v27;
        wmma::fragment<wmma::accumulator, 16l, 16l, 8l, float> v28;
        wmma::fill_fragment(v28, 0.0f);
        long v29;
        v29 = 0l;
        while (while_method_0(v29)){
            long v31;
            v31 = v29 % 1l;
            bool v32;
            v32 = v29 == 0l;
            bool v33;
            v33 = v32 == false;
            if (v33){
                assert("The index has to be in the range of the dimension." && v32);
            } else {
            }
            assert("Tensor range check" && 0 <= v31 && v31 < 1l);
            long v35;
            v35 = 8l * v31;
            long v36;
            v36 = v35 + v23;
            assert("Tensor range check" && 0 <= v31 && v31 < 1l);
            long v37;
            v37 = 128l * v31;
            long v38;
            v38 = v37 + v24;
            long v39;
            v39 = v4.meta_group_size();
            long v40;
            v40 = v4.meta_group_rank();
            long v41;
            v41 = v40;
            while (while_method_1(v41)){
                long v43;
                v43 = v41 % 2l;
                long v44;
                v44 = v41 / 2l;
                long v45;
                v45 = v44 % 1l;
                long v46;
                v46 = v44 % 16l;
                long v47;
                v47 = v44 / 16l;
                long v48;
                v48 = v47 % 1l;
                bool v49;
                v49 = v47 == 0l;
                bool v50;
                v50 = v49 == false;
                if (v50){
                    assert("The index has to be in the range of the dimension." && v49);
                } else {
                }
                assert("Tensor range check" && 0 <= v48 && v48 < 1l);
                assert("Tensor range check" && 0 <= v46 && v46 < 16l);
                assert("Tensor range check" && 0 <= v45 && v45 < 1l);
                assert("Tensor range check" && 0 <= v43 && v43 < 2l);
                long v52;
                v52 = 4l * v43;
                long v53;
                v53 = v52 + v36;
                long v54;
                v54 = 8l * v45;
                long v55;
                v55 = v54 + v53;
                long v56;
                v56 = 8l * v46;
                long v57;
                v57 = v56 + v55;
                long v58;
                v58 = 128l * v48;
                long v59;
                v59 = v58 + v57;
                assert("Tensor range check" && 0 <= v48 && v48 < 1l);
                assert("Tensor range check" && 0 <= v46 && v46 < 16l);
                assert("Tensor range check" && 0 <= v45 && v45 < 1l);
                assert("Tensor range check" && 0 <= v43 && v43 < 2l);
                long v60;
                v60 = 136l * v45;
                long v61;
                v61 = v60 + v52;
                long v62;
                v62 = v56 + v61;
                long v63;
                v63 = 136l * v48;
                long v64;
                v64 = v63 + v62;
                long v65;
                v65 = grid_group::thread_rank();
                bool v66;
                v66 = v65 < 1l;
                if (v66){
                    cooperative_groups::memcpy_async(v4, v8 + v64, v0 + v59, sizeof(float) * 4l);
                } else {
                }
                v41 += v39 ;
            }
            v29 += 1l ;
        }
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
options.append('--define-macro=NDEBUG')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
from max_blocks_per_sm import max_blocks_per_sm
def main():
    v0 = cp.random.normal(0,1,256,cp.float32)
    v1 = v0.size
    v2 = 256 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,128,cp.float32)
    v6 = v5.size
    v7 = 128 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,128,cp.float32)
    v11 = v10.size
    v12 = 128 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = v10.reshape((16, 8))
    v16 = v5.reshape((8, 16))
    v17 = v0.reshape((16, 16))
    del v17
    v18 = (cp.matmul(v15,v16)).flatten()
    del v15, v16
    v19 = v18.size
    v20 = 256 == v19
    del v19
    v21 = v20 == False
    if v21:
        v22 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v20, v22
        del v22
    else:
        pass
    del v20, v21
    v23 = 0
    v24 = raw_module.get_function(f"entry{v23}")
    del v23
    v24.max_dynamic_shared_size_bytes = 1120 
    v24((1,),(32,),(v10, v5, v0),shared_mem=1120)
    del v5, v10, v24
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),1024,is_print=True)
    v25 = cp.max(cp.abs(v0-v18))
    del v0, v18
    return v25

if __name__ == '__main__': print(main())
