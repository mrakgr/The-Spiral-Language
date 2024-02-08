kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cublasdx.hpp>
using namespace cublasdx;
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
    thread_block_tile<32l, thread_block> v4 = tiled_partition<32l>(v3);
    long v5;
    v5 = grid_group::num_blocks();
    long v6;
    v6 = grid_group::block_rank();
    long v7;
    v7 = v6;
    while (while_method_0(v7)){
        long v9;
        v9 = v7 % 1l;
        bool v10;
        v10 = v7 == 0l;
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The index has to be in the range of the dimension." && v10);
        } else {
        }
        assert("Tensor range check" && 0 <= v9 && v9 < 1l);
        long v13;
        v13 = 32l * v9;
        assert("Tensor range check" && 0 <= v9 && v9 < 1l);
        assert("Tensor range check" && 0 <= v9 && v9 < 1l);
        assert("Tensor range check" && 0 <= v9 && v9 < 1l);
        long v14;
        v14 = 1024l * v9;
        long v15;
        v15 = v14 + v13;
        __shared__ float v16[1024l];
        long v17;
        v17 = v4.meta_group_size();
        long v18;
        v18 = v4.meta_group_rank();
        long v19;
        v19 = v18;
        while (while_method_1(v19)){
            long v21;
            v21 = v19 % 32l;
            long v22;
            v22 = v19 / 32l;
            bool v23;
            v23 = v22 == 0l;
            bool v24;
            v24 = v23 == false;
            if (v24){
                assert("The index has to be in the range of the dimension." && v23);
            } else {
            }
            assert("Tensor range check" && 0 <= v21 && v21 < 32l);
            long v26;
            v26 = 32l * v21;
            long v27;
            v27 = v26 + v15;
            assert("Tensor range check" && 0 <= v21 && v21 < 32l);
            cooperative_groups::memcpy_async(v4, v16 + v26, v2 + v27, sizeof(float) * 32l);
            v19 += v17 ;
        }
        long v28;
        v28 = 0l;
        while (while_method_0(v28)){
            long v30;
            v30 = v28 % 1l;
            bool v31;
            v31 = v28 == 0l;
            bool v32;
            v32 = v31 == false;
            if (v32){
                assert("The index has to be in the range of the dimension." && v31);
            } else {
            }
            assert("Tensor range check" && 0 <= v30 && v30 < 1l);
            long v34;
            v34 = 1024l * v30;
            long v35;
            v35 = v34 + v13;
            __shared__ float v36[1024l];
            v3.sync() ;
            long v37;
            v37 = v4.meta_group_size();
            long v38;
            v38 = v4.meta_group_rank();
            long v39;
            v39 = v38;
            while (while_method_1(v39)){
                long v41;
                v41 = v39 % 32l;
                long v42;
                v42 = v39 / 32l;
                bool v43;
                v43 = v42 == 0l;
                bool v44;
                v44 = v43 == false;
                if (v44){
                    assert("The index has to be in the range of the dimension." && v43);
                } else {
                }
                assert("Tensor range check" && 0 <= v41 && v41 < 32l);
                long v46;
                v46 = 32l * v41;
                long v47;
                v47 = v46 + v35;
                assert("Tensor range check" && 0 <= v41 && v41 < 32l);
                cooperative_groups::memcpy_async(v4, v36 + v46, v0 + v47, sizeof(float) * 32l);
                v39 += v37 ;
            }
            assert("Tensor range check" && 0 <= v30 && v30 < 1l);
            __shared__ float v48[1024l];
            long v49;
            v49 = v4.meta_group_size();
            long v50;
            v50 = v4.meta_group_rank();
            long v51;
            v51 = v50;
            while (while_method_1(v51)){
                long v53;
                v53 = v51 % 32l;
                long v54;
                v54 = v51 / 32l;
                bool v55;
                v55 = v54 == 0l;
                bool v56;
                v56 = v55 == false;
                if (v56){
                    assert("The index has to be in the range of the dimension." && v55);
                } else {
                }
                assert("Tensor range check" && 0 <= v53 && v53 < 32l);
                long v58;
                v58 = 32l * v53;
                long v59;
                v59 = v58 + v35;
                assert("Tensor range check" && 0 <= v53 && v53 < 32l);
                cooperative_groups::memcpy_async(v4, v48 + v58, v1 + v59, sizeof(float) * 32l);
                v51 += v49 ;
            }
            cooperative_groups::wait(v4);
            v3.sync() ;
            float * v60;
            v60 = v36 + 0l;
            float * v61;
            v61 = v48 + 0l;
            float * v62;
            v62 = v16 + 0l;
            using size_desc = Size<32l, 32l, 32l>;
            using type_desc = Type<type::real>;
            using precision = Precision<float>;
            constexpr auto v63 = transpose_mode::transposed;
            constexpr auto v64 = transpose_mode::non_transposed;
            using tm_desc = TransposeMode<v64, v63>;
            using sm = SM<890>;
            using BLAS = decltype(BlockDim<256l>() + Block() + Function<function::MM>() + size_desc() + type_desc() + tm_desc() + precision() + sm());
            long v65;
            v65 = BLAS::a_size;
            long v66;
            v66 = BLAS::b_size;
            long v67;
            v67 = BLAS::c_size;
            long v68;
            v68 = grid_group::thread_rank();
            bool v69;
            v69 = v68 == 0l;
            if (v69){
                const char * v70;
                v70 = "%d";
                printf(v70,v65);
                printf("\n");
                const char * v71;
                v71 = "%d";
                printf(v71,v66);
                printf("\n");
                const char * v72;
                v72 = "%d";
                printf(v72,v67);
                printf("\n");
            } else {
            }
            __syncthreads();
            bool v73;
            v73 = v30 == 0l;
            float v74;
            if (v73){
                v74 = 0.0f;
            } else {
                v74 = 1.0f;
            }
            v28 += 1l ;
        }
        v3.sync() ;
        long v75;
        v75 = v4.meta_group_size();
        long v76;
        v76 = v4.meta_group_rank();
        long v77;
        v77 = v76;
        while (while_method_1(v77)){
            long v79;
            v79 = v77 % 32l;
            long v80;
            v80 = v77 / 32l;
            bool v81;
            v81 = v80 == 0l;
            bool v82;
            v82 = v81 == false;
            if (v82){
                assert("The index has to be in the range of the dimension." && v81);
            } else {
            }
            assert("Tensor range check" && 0 <= v79 && v79 < 32l);
            long v84;
            v84 = 32l * v79;
            assert("Tensor range check" && 0 <= v79 && v79 < 32l);
            long v85;
            v85 = v84 + v15;
            cooperative_groups::memcpy_async(v4, v2 + v85, v16 + v84, sizeof(float) * 32l);
            v77 += v75 ;
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
    v0 = cp.random.normal(0,1,1024,cp.float32)
    v1 = v0.size
    v2 = 1024 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,1024,cp.float32)
    v6 = v5.size
    v7 = 1024 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,1024,cp.float32)
    v11 = v10.size
    v12 = 1024 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = v10.reshape((32, 32))
    v16 = cp.transpose(v15)
    del v15
    v17 = v5.reshape((32, 32))
    v18 = v0.reshape((32, 32))
    del v18
    v19 = (cp.matmul(v16,v17)).flatten()
    del v16, v17
    v20 = v19.size
    v21 = 1024 == v20
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
