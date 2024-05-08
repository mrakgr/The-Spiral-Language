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
        char * v39;
        v39 = (char *)(v5+0ull);
        char v40;
        v40 = v39[0l];
        char * v41;
        v41 = (char *)(v5+1ull);
        char v42;
        v42 = v41[0l];
        array<long,14l> v43;
        long v44 = 0l;
        long * v45;
        v45 = (long *)(v5+4ull);
        long v46;
        v46 = v45[0l];
        long & v47 = v44;
        v44 = v46;
        long & v48 = v44;
        long v49;
        v49 = 0l;
        while (while_method_0(v48, v49)){
            unsigned long long v51;
            v51 = (unsigned long long)v49;
            unsigned long long v52;
            v52 = v51 * 4ull;
            unsigned long long v53;
            v53 = 8ull + v52;
            unsigned char * v54;
            v54 = (unsigned char *)(v5+v53);
            long * v55;
            v55 = (long *)(v54+0ull);
            long v56;
            v56 = v55[0l];
            bool v57;
            v57 = 0l <= v49;
            bool v60;
            if (v57){
                long & v58 = v44;
                bool v59;
                v59 = v49 < v58;
                v60 = v59;
            } else {
                v60 = false;
            }
            bool v61;
            v61 = v60 == false;
            if (v61){
                assert("The set index needs to be in range." && v60);
            } else {
            }
            bool v63;
            if (v57){
                bool v62;
                v62 = v49 < 14l;
                v63 = v62;
            } else {
                v63 = false;
            }
            bool v64;
            v64 = v63 == false;
            if (v64){
                assert("The read index needs to be in range." && v63);
            } else {
            }
            v43.v[v49] = v56;
            v49 += 1l ;
        }
        const char * v65;
        v65 = "%d";
        printf(v65,v40);
        const char * v66;
        v66 = "%s";
        const char * v67;
        v67 = ", ";
        printf(v66,v67);
        printf(v65,v42);
        printf(v66,v67);
        const char * v68;
        v68 = "[";
        printf(v66,v68);
        long & v69 = v44;
        bool v70;
        v70 = 100l < v69;
        long v71;
        if (v70){
            v71 = 100l;
        } else {
            v71 = v69;
        }
        long v72;
        v72 = 0l;
        while (while_method_0(v71, v72)){
            bool v74;
            v74 = 0l <= v72;
            bool v77;
            if (v74){
                long & v75 = v44;
                bool v76;
                v76 = v72 < v75;
                v77 = v76;
            } else {
                v77 = false;
            }
            bool v78;
            v78 = v77 == false;
            if (v78){
                assert("The read index needs to be in range." && v77);
            } else {
            }
            bool v80;
            if (v74){
                bool v79;
                v79 = v72 < 14l;
                v80 = v79;
            } else {
                v80 = false;
            }
            bool v81;
            v81 = v80 == false;
            if (v81){
                assert("The read index needs to be in range." && v80);
            } else {
            }
            long v82;
            v82 = v43.v[v72];
            printf(v65,v82);
            long v83;
            v83 = v72 + 1l;
            long & v84 = v44;
            bool v85;
            v85 = v83 < v84;
            if (v85){
                const char * v86;
                v86 = "; ";
                printf(v66,v86);
            } else {
            }
            v72 += 1l ;
        }
        long & v87 = v44;
        bool v88;
        v88 = v87 > 100l;
        if (v88){
            const char * v89;
            v89 = "; ...";
            printf(v66,v89);
        } else {
        }
        const char * v90;
        v90 = "]";
        printf(v66,v90);
        printf("\n");
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
