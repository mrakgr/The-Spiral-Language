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
        array<long,14l> v8;
        array<long,14l> v6;
        v8 = v6;
        long & v11;
        long v9 = 0l;
        v11 = v9;
        long v14;
        long & v12 = v11;
        v14 = v12;
        v11 = 3l;
        long v17;
        long & v15 = v11;
        v17 = v15;
        bool v18;
        v18 = 0l < v17;
        bool v19;
        v19 = v18 == false;
        if (v19){
            assert("The set index needs to be in range." && v18);
        } else {
        }
        v8.v[0l] = 1l;
        long v23;
        long & v21 = v11;
        v23 = v21;
        bool v24;
        v24 = 1l < v23;
        bool v25;
        v25 = v24 == false;
        if (v25){
            assert("The set index needs to be in range." && v24);
        } else {
        }
        v8.v[1l] = 2l;
        long v29;
        long & v27 = v11;
        v29 = v27;
        bool v30;
        v30 = 2l < v29;
        bool v31;
        v31 = v30 == false;
        if (v31){
            assert("The set index needs to be in range." && v30);
        } else {
        }
        v8.v[2l] = 3l;
        char * v35;
        char * v33;
        v33 = (char *)(v5+0ull);
        v35 = v33;
        v35[0l] = 1;
        char * v38;
        char * v36;
        v36 = (char *)(v5+1ull);
        v38 = v36;
        v38[0l] = 2;
        long v41;
        long & v39 = v11;
        v41 = v39;
        long * v44;
        long * v42;
        v42 = (long *)(v5+4ull);
        v44 = v42;
        v44[0l] = v41;
        long v47;
        long & v45 = v11;
        v47 = v45;
        long v48;
        v48 = 0l;
        while (while_method_0(v47, v48)){
            unsigned long long v50;
            v50 = (unsigned long long)v48;
            unsigned long long v51;
            v51 = v50 * 4ull;
            unsigned long long v52;
            v52 = 8ull + v51;
            unsigned char * v55;
            unsigned char * v53;
            v53 = (unsigned char *)(v5+v52);
            v55 = v53;
            bool v56;
            v56 = 0l <= v48;
            bool v61;
            if (v56){
                long v59;
                long & v57 = v11;
                v59 = v57;
                bool v60;
                v60 = v48 < v59;
                v61 = v60;
            } else {
                v61 = false;
            }
            bool v62;
            v62 = v61 == false;
            if (v62){
                assert("The read index needs to be in range." && v61);
            } else {
            }
            bool v65;
            if (v56){
                bool v64;
                v64 = v48 < 14l;
                v65 = v64;
            } else {
                v65 = false;
            }
            bool v66;
            v66 = v65 == false;
            if (v66){
                assert("The read index needs to be in range." && v65);
            } else {
            }
            long v70;
            long v68;
            v68 = v8.v[v48];
            v70 = v68;
            long * v73;
            long * v71;
            v71 = (long *)(v55+0ull);
            v73 = v71;
            v73[0l] = v70;
            v48 += 1l ;
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
