kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cublasdx.hpp>
using namespace cublasdx;
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
    v1 = v0 < 32l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8l;
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
        v9 = v7 % 8l;
        long v10;
        v10 = v7 / 8l;
        long v11;
        v11 = v10 % 8l;
        long v12;
        v12 = v10 / 8l;
        bool v13;
        v13 = v12 == 0l;
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The index has to be in the range of the dimension." && v13);
        } else {
        }
        assert("Tensor range check" && 0 <= v11 && v11 < 8l);
        long v16;
        v16 = 32l * v11;
        assert("Tensor range check" && 0 <= v9 && v9 < 8l);
        long v17;
        v17 = 32l * v9;
        assert("Tensor range check" && 0 <= v11 && v11 < 8l);
        assert("Tensor range check" && 0 <= v9 && v9 < 8l);
        long v18;
        v18 = 8192l * v11;
        long v19;
        v19 = v18 + v17;
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
            v30 = 256l * v25;
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
            v35 = v33 % 8l;
            long v36;
            v36 = v33 / 8l;
            bool v37;
            v37 = v36 == 0l;
            bool v38;
            v38 = v37 == false;
            if (v38){
                assert("The index has to be in the range of the dimension." && v37);
            } else {
            }
            assert("Tensor range check" && 0 <= v35 && v35 < 8l);
            long v40;
            v40 = 8192l * v35;
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
                v52 = 256l * v47;
                long v53;
                v53 = v52 + v41;
                assert("Tensor range check" && 0 <= v47 && v47 < 32l);
                long v54;
                v54 = 32l * v47;
                cooperative_groups::memcpy_async(v4, v42 + v54, v0 + v53, sizeof(float) * 32l);
                v45 += v43 ;
            }
            assert("Tensor range check" && 0 <= v35 && v35 < 8l);
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
                v66 = 256l * v61;
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
            using ld_desc = cublasdx::LeadingDimension<32l, 32l, 32l>;
            using type_desc = Type<type::real>;
            using precision = Precision<float>;
            constexpr auto v72 = transpose_mode::transposed;
            constexpr auto v73 = transpose_mode::non_transposed;
            using tm_desc = TransposeMode<v73, v72>;
            using sm = SM<890>;
            using BLAS = decltype(BlockDim<256l>() + Block() + Function<function::MM>() + size_desc() + ld_desc() + type_desc() + tm_desc() + precision() + sm());
            bool v74;
            v74 = v35 == 0l;
            float v75;
            if (v74){
                v75 = 0.0f;
            } else {
                v75 = 1.0f;
            }
            BLAS().execute(1.0f, v70, v69, v75, v71);
            v33 += 1l ;
        }
        v3.sync() ;
        long v76;
        v76 = v4.meta_group_size();
        long v77;
        v77 = v4.meta_group_rank();
        long v78;
        v78 = v77;
        while (while_method_1(v78)){
            long v80;
            v80 = v78 % 32l;
            long v81;
            v81 = v78 / 32l;
            bool v82;
            v82 = v81 == 0l;
            bool v83;
            v83 = v82 == false;
            if (v83){
                assert("The index has to be in the range of the dimension." && v82);
            } else {
            }
            assert("Tensor range check" && 0 <= v80 && v80 < 32l);
            long v85;
            v85 = 32l * v80;
            assert("Tensor range check" && 0 <= v80 && v80 < 32l);
            long v86;
            v86 = 256l * v80;
            long v87;
            v87 = v86 + v19;
            cooperative_groups::memcpy_async(v4, v2 + v87, v20 + v85, sizeof(float) * 32l);
            v78 += v76 ;
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
options.append('-I G:/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/include')
options.append('-I G:/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/include/cublasdx/include')
options.append('-I G:/nvidia-mathdx-24.01.0/nvidia/mathdx/24.01/external/cutlass/include')
options.append('--std=c++17')
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
    v16 = cp.transpose(v15)
    del v15
    v17 = v5.reshape((256, 256))
    v18 = v0.reshape((256, 256))
    del v18
    v19 = (cp.matmul(v16,v17)).flatten()
    del v16, v17
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
    raw_module.get_function(f"entry{v24}")((1, 1, 1),(256, 1, 1),(v10, v5, v0))
    del v5, v10, v24
    v25 = cp.max(cp.abs(v0-v19))
    del v0, v19
    return v25

if __name__ == '__main__': print(main())
