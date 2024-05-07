kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
__device__ inline bool while_method_0(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0() {
    long v0;
    v0 = threadIdx.x;
    long v1;
    v1 = blockIdx.x;
    long v2;
    v2 = v1 * 512l;
    long v3;
    v3 = v0 + v2;
    bool v4;
    v4 = v3 == 0l;
    if (v4){
        unsigned char v5[64l];
        array<long,14l> v6;
        long v7 = 0l;
        long & v8 = v7;
        v7 = 3l;
        long & v9 = v7;
        bool v10;
        v10 = 0l < v9;
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The set index needs to be in range." && v10);
        } else {
        }
        v6.v[0l] = 1l;
        long & v12 = v7;
        bool v13;
        v13 = 1l < v12;
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The set index needs to be in range." && v13);
        } else {
        }
        v6.v[1l] = 2l;
        long & v15 = v7;
        bool v16;
        v16 = 2l < v15;
        bool v17;
        v17 = v16 == false;
        if (v17){
            assert("The set index needs to be in range." && v16);
        } else {
        }
        v6.v[2l] = 3l;
        char * v18;
        v18 = (char *)(v5+0ull);
        v18[0l] = 1;
        char * v19;
        v19 = (char *)(v5+1ull);
        v19[0l] = 2;
        long & v20 = v7;
        long * v21;
        v21 = (long *)(v5+4ull);
        v21[0l] = v20;
        long & v22 = v7;
        long v23;
        v23 = 0l;
        while (while_method_0(v22, v23)){
            unsigned long long v25;
            v25 = (unsigned long long)v23;
            unsigned long long v26;
            v26 = v25 * 4ull;
            unsigned long long v27;
            v27 = 8ull + v26;
            unsigned char * v28;
            v28 = (unsigned char *)(v5+v27);
            bool v29;
            v29 = 0l <= v23;
            bool v32;
            if (v29){
                long & v30 = v7;
                bool v31;
                v31 = v23 < v30;
                v32 = v31;
            } else {
                v32 = false;
            }
            bool v33;
            v33 = v32 == false;
            if (v33){
                assert("The read index needs to be in range." && v32);
            } else {
            }
            bool v35;
            if (v29){
                bool v34;
                v34 = v23 < 14l;
                v35 = v34;
            } else {
                v35 = false;
            }
            bool v36;
            v36 = v35 == false;
            if (v36){
                assert("The read index needs to be in range." && v35);
            } else {
            }
            long v37;
            v37 = v6.v[v23];
            long * v38;
            v38 = (long *)(v28+0ull);
            v38[0l] = v37;
            v23 += 1l ;
        }
        return ;
    } else {
        return ;
    }
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def main():
    v0 = 0
    v1 = raw_module.get_function(f"entry{v0}")
    del v0
    v1.max_dynamic_shared_size_bytes = 0 
    v1((1,),(512,),(),shared_mem=0)
    del v1
    return 

if __name__ == '__main__': print(main())
