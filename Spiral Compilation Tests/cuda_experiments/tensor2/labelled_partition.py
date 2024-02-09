kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
#include <cooperative_groups/reduce.h>
using namespace cooperative_groups;
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 64l;
    return v1;
}
extern "C" __global__ void entry0(float * v0, float * v1) {
    auto v2 = this_thread_block();
    thread_block_tile<64l, thread_block> v3 = tiled_partition<64l>(v2);
    long v4;
    v4 = grid_group::num_threads() / warpSize;
    long v5;
    v5 = grid_group::thread_rank() / warpSize;
    long v6;
    v6 = v5;
    while (while_method_0(v6)){
        long v8;
        v8 = v6 % 32l;
        long v9;
        v9 = v6 / 32l;
        long v10;
        v10 = v9 % 2l;
        long v11;
        v11 = v9 / 2l;
        bool v12;
        v12 = v11 == 0l;
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The index has to be in the range of the dimension." && v12);
        } else {
        }
        assert("Tensor range check" && 0 <= v10 && v10 < 2l);
        assert("Tensor range check" && 0 <= v8 && v8 < 32l);
        long v15;
        v15 = 32l * v10;
        long v16;
        v16 = v15 + v8;
        float v17;
        v17 = v0[v16];
        auto v18 = labeled_partition(v3,v8);
        float v19;
        v19 = reduce(v18, v17, plus<float>());
        bool v20;
        v20 = v10 == 0l;
        if (v20){
            assert("Tensor range check" && 0 <= v8 && v8 < 32l);
            v1[v8] = v19;
        } else {
        }
        v6 += v4 ;
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
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
from max_blocks_per_sm import max_blocks_per_sm
def method0(v0 : i32) -> bool:
    v1 = v0 < 32
    del v0
    return v1
def main():
    v0 = cp.random.normal(0,1,32,cp.float32)
    v1 = v0.size
    v2 = 32 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,64,cp.float32)
    v6 = v5.size
    v7 = 64 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = 0
    raw_module.get_function(f"entry{v10}")((1, 1, 1),(64, 1, 1),(v5, v0))
    del v10
    print('[', end="")
    v12 = 0
    v13 = 0
    while method0(v13):
        v15 = v13 % 32
        v16 = v13 // 32
        v17 = v16 == 0
        del v16
        v18 = v17 == False
        if v18:
            v19 = "The index has to be in the range of the dimension."
            assert v17, v19
            del v19
        else:
            pass
        del v17, v18
        assert 0 <= v15 < 32, 'Tensor range check'
        v20 = v5[v15].item()
        v21 = v15 + 32
        del v15
        v22 = v5[v21].item()
        del v21
        print("{:.6f}".format(v20), end="")
        del v20
        v26 = ", "
        print(v26, end="")
        del v26
        print("{:.6f}".format(v22), end="")
        del v22
        v28 = v12 + 1
        v12 = v28
        del v28
        v29 = v12 >= 100
        if v29:
            v32 = "; ..."
            print(v32, end="")
            del v32
            break
        else:
            pass
        del v29
        v33 = v12 < 32
        if v33:
            v36 = "; "
            print(v36, end="")
            del v36
        else:
            pass
        del v33
        v13 += 1 
    del v5, v12, v13
    print(']', end="")
    print()
    print('[', end="")
    v39 = 0
    v40 = 0
    while method0(v40):
        v42 = v40 % 32
        v43 = v40 // 32
        v44 = v43 % 1
        v45 = v43 == 0
        del v43
        v46 = v45 == False
        if v46:
            v47 = "The index has to be in the range of the dimension."
            assert v45, v47
            del v47
        else:
            pass
        del v45, v46
        assert 0 <= v44 < 1, 'Tensor range check'
        assert 0 <= v42 < 32, 'Tensor range check'
        v48 = 32 * v44
        del v44
        v49 = v48 + v42
        del v42, v48
        v50 = v0[v49].item()
        del v49
        print("{:.6f}".format(v50), end="")
        del v50
        v52 = v39 + 1
        v39 = v52
        del v52
        v53 = v39 >= 100
        if v53:
            v56 = "; ..."
            print(v56, end="")
            del v56
            break
        else:
            pass
        del v53
        v57 = v39 < 32
        if v57:
            v60 = "; "
            print(v60, end="")
            del v60
        else:
            pass
        del v57
        v40 += 1 
    del v0, v39, v40
    print(']', end="")
    print()
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),128,is_print=True)
    return 

if __name__ == '__main__': print(main())
