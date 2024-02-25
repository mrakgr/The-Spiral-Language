kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 65536l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
extern "C" __global__ void entry0(float __align__(16) * v0, float __align__(16) * v1, float __align__(16) * v2) {
    long v3;
    v3 = grid_group::num_threads();
    long v4;
    v4 = grid_group::thread_rank();
    long v5;
    v5 = v4;
    while (while_method_0(v5)){
        long v7;
        v7 = v5 % 65536l;
        long v8;
        v8 = v5 / 65536l;
        bool v9;
        v9 = v8 == 0l;
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The index has to be in the range of the dimension." && v9);
        } else {
        }
        long v12;
        v12 = 0l;
        while (while_method_1(v12)){
            long v14;
            v14 = v12 % 4l;
            long v15;
            v15 = v12 / 4l;
            bool v16;
            v16 = v15 == 0l;
            bool v17;
            v17 = v16 == false;
            if (v17){
                assert("The index has to be in the range of the dimension." && v16);
            } else {
            }
            assert("Tensor range check" && 0 <= v7 && v7 < 65536l);
            assert("Tensor range check" && 0 <= v14 && v14 < 4l);
            long v19;
            v19 = 4l * v7;
            long v20;
            v20 = v19 + v14;
            float v21;
            v21 = v1[v20];
            float v22;
            v22 = v2[v20];
            float v23;
            v23 = v21 + v22;
            assert("Tensor range check" && 0 <= v7 && v7 < 65536l);
            assert("Tensor range check" && 0 <= v14 && v14 < 4l);
            v0[v20] = v23;
            v12 += 1l ;
        }
        v5 += v3 ;
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
options.append('--define-macro=NDEBUG')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def method0(v0 : i32) -> bool:
    v1 = v0 < 1
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
    v15 = cp.random.normal(0,1,262144,cp.float32)
    v16 = v15.size
    v17 = 262144 == v16
    del v16
    v18 = v17 == False
    if v18:
        v19 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v17, v19
        del v19
    else:
        pass
    del v17, v18
    v20 = cp.random.normal(0,1,262144,cp.float32)
    v21 = v20.size
    v22 = 262144 == v21
    del v21
    v23 = v22 == False
    if v23:
        v24 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v22, v24
        del v24
    else:
        pass
    del v22, v23
    v25 = cp.random.normal(0,1,262144,cp.float32)
    v26 = v25.size
    v27 = 262144 == v26
    del v26
    v28 = v27 == False
    if v28:
        v29 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v27, v29
        del v29
    else:
        pass
    del v27, v28
    v30, v31 = (0, 0.0)
    while method0(v30):
        v33 = v10.reshape((512, 512))
        v34 = v5.reshape((512, 512))
        v35 = cp.transpose(v34)
        del v34
        v36 = v0.reshape((512, 512))
        v37 = (cp.matmul(v33,v35) + v36).flatten()
        del v33, v35, v36
        v38 = v37.size
        v39 = 262144 == v38
        del v38
        v40 = v39 == False
        if v40:
            v41 = "The total length of the reshaped tensor dimension must match that of the original one."
            assert v39, v41
            del v41
        else:
            pass
        del v39, v40
        v42 = 0
        v43 = raw_module.get_function(f"entry{v42}")
        del v42
        v43.max_dynamic_shared_size_bytes = 0 
        v43((24,),(256,),(v15, v25, v20),shared_mem=0)
        del v43
        v44 = cp.max(cp.abs(v0-v37))
        del v37
        v45 = v44 + v31
        del v44
        v31 = v45
        del v45
        v30 += 1 
    del v0, v5, v10, v15, v20, v25, v30
    return v31

if __name__ == '__main__': print(main())
