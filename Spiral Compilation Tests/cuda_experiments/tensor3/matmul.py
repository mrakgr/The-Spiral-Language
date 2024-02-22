kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cublasdx.hpp>
using namespace cublasdx;
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
        __shared__ float v20[1024l];
        long v21;
        v21 = v4.meta_group_size();
        long v22;
        v22 = v4.meta_group_rank();
        long v23;
        v23 = v22;
        while (while_method_1(v23)){
            long v25;
            v25 = v23 % 32l;
            long v26;
            v26 = v23 / 32l;
            bool v27;
            v27 = v26 == 0l;
            bool v28;
            v28 = v27 == false;
            if (v28){
                assert("The index has to be in the range of the dimension." && v27);
            } else {
            }
            assert("Tensor range check" && 0 <= v25 && v25 < 32l);
            long v30;
            v30 = 512l * v25;
            long v31;
            v31 = v30 + v19;
            assert("Tensor range check" && 0 <= v25 && v25 < 32l);
            long v32;
            v32 = 32l * v25;
            cooperative_groups::memcpy_async(v4, v20 + v32, v2 + v31, sizeof(float) * 32l);
            v23 += v21 ;
        }
        long v33;
        v33 = 0l;
        while (while_method_2(v33)){
            long v35;
            v35 = v33 % 16l;
            long v36;
            v36 = v33 / 16l;
            bool v37;
            v37 = v36 == 0l;
            bool v38;
            v38 = v37 == false;
            if (v38){
                assert("The index has to be in the range of the dimension." && v37);
            } else {
            }
            assert("Tensor range check" && 0 <= v35 && v35 < 16l);
            long v40;
            v40 = 32l * v35;
            long v41;
            v41 = v40 + v16;
            __shared__ float v42[1024l];
            v3.sync() ;
            long v43;
            v43 = v4.meta_group_size();
            long v44;
            v44 = v4.meta_group_rank();
            long v45;
            v45 = v44;
            while (while_method_1(v45)){
                long v47;
                v47 = v45 % 32l;
                long v48;
                v48 = v45 / 32l;
                bool v49;
                v49 = v48 == 0l;
                bool v50;
                v50 = v49 == false;
                if (v50){
                    assert("The index has to be in the range of the dimension." && v49);
                } else {
                }
                assert("Tensor range check" && 0 <= v47 && v47 < 32l);
                long v52;
                v52 = 512l * v47;
                long v53;
                v53 = v52 + v41;
                assert("Tensor range check" && 0 <= v47 && v47 < 32l);
                long v54;
                v54 = 32l * v47;
                cooperative_groups::memcpy_async(v4, v42 + v54, v0 + v53, sizeof(float) * 32l);
                v45 += v43 ;
            }
            assert("Tensor range check" && 0 <= v35 && v35 < 16l);
            long v55;
            v55 = v40 + v17;
            __shared__ float v56[1024l];
            long v57;
            v57 = v4.meta_group_size();
            long v58;
            v58 = v4.meta_group_rank();
            long v59;
            v59 = v58;
            while (while_method_1(v59)){
                long v61;
                v61 = v59 % 32l;
                long v62;
                v62 = v59 / 32l;
                bool v63;
                v63 = v62 == 0l;
                bool v64;
                v64 = v63 == false;
                if (v64){
                    assert("The index has to be in the range of the dimension." && v63);
                } else {
                }
                assert("Tensor range check" && 0 <= v61 && v61 < 32l);
                long v66;
                v66 = 512l * v61;
                long v67;
                v67 = v66 + v55;
                assert("Tensor range check" && 0 <= v61 && v61 < 32l);
                long v68;
                v68 = 32l * v61;
                cooperative_groups::memcpy_async(v4, v56 + v68, v1 + v67, sizeof(float) * 32l);
                v59 += v57 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            float * v69;
            v69 = v42 + 0l;
            float * v70;
            v70 = v56 + 0l;
            float * v71;
            v71 = v20 + 0l;
            using size_desc = Size<32l, 32l, 32l>;
            using type_desc = Type<type::real>;
            using precision = Precision<float>;
            constexpr auto v72 = transpose_mode::non_transposed;
            constexpr auto v73 = transpose_mode::transposed;
            using tm_desc = TransposeMode<v73, v72>;
            using sm = SM<890>;
            using BLAS = decltype(BlockDim<256l>() + Block() + Function<function::MM>() + size_desc() + type_desc() + tm_desc() + precision() + sm());
            long v74;
            v74 = BLAS::a_size;
            long v75;
            v75 = BLAS::b_size;
            long v76;
            v76 = BLAS::c_size;
            bool v77;
            v77 = v35 == 0l;
            float v78;
            if (v77){
                v78 = 0.0f;
            } else {
                v78 = 1.0f;
            }
            BLAS().execute(1.0f, v70, v69, v78, v71);
            v33 += 1l ;
        }
        v3.sync() ;
        long v79;
        v79 = v4.meta_group_size();
        long v80;
        v80 = v4.meta_group_rank();
        long v81;
        v81 = v80;
        while (while_method_1(v81)){
            long v83;
            v83 = v81 % 32l;
            long v84;
            v84 = v81 / 32l;
            bool v85;
            v85 = v84 == 0l;
            bool v86;
            v86 = v85 == false;
            if (v86){
                assert("The index has to be in the range of the dimension." && v85);
            } else {
            }
            assert("Tensor range check" && 0 <= v83 && v83 < 32l);
            long v88;
            v88 = 32l * v83;
            assert("Tensor range check" && 0 <= v83 && v83 < 32l);
            long v89;
            v89 = 512l * v83;
            long v90;
            v90 = v89 + v19;
            cooperative_groups::memcpy_async(v4, v2 + v90, v20 + v88, sizeof(float) * 32l);
            v81 += v79 ;
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
options.append('--maxrregcount=42')
options.append('--dopt=on')
options.append('--define-macro=NDEBUG')
options.append('-I G:/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/include')
options.append('-I G:/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/include/cublasdx/include')
options.append('-I G:/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/external/cutlass/include')
options.append('--std=c++17')
options.append('--restrict')
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
