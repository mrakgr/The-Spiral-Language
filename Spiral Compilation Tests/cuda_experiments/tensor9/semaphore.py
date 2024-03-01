kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
#include <cuda/semaphore>
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 128l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 16l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_3(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0) {
    auto v1 = this_thread_block();
    thread_block_tile<32l, thread_block> v2 = tiled_partition<32l>(v1);
    thread_block_tile<1l, thread_block_tile<32l, thread_block>> v3 = tiled_partition<1l>(v2);
    __shared__ float v4[128l];
    long v5;
    v5 = v3.meta_group_size();
    long v6;
    v6 = v3.meta_group_rank();
    long v7;
    v7 = v6;
    while (while_method_0(v7)){
        long v9;
        v9 = v7 % 8l;
        long v10;
        v10 = v7 / 8l;
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
        assert("Tensor range check" && 0 <= v9 && v9 < 8l);
        long v16;
        v16 = 8l * v11;
        long v17;
        v17 = v16 + v9;
        assert("Tensor range check" && 0 <= v11 && v11 < 16l);
        assert("Tensor range check" && 0 <= v9 && v9 < 8l);
        int* v18;
        v18 = reinterpret_cast<int*>(v0 + v17);
        int* v19;
        v19 = reinterpret_cast<int*>(v4 + v17);
        assert("Pointer alignment check" && v18 % sizeof(int) == 0 && v19 % sizeof(int) == 0);
        *v19 = *v18;
        v7 += v5 ;
    }
    long v20;
    v20 = grid_group::thread_rank();
    bool v21;
    v21 = v20 == 0l;
    if (v21){
        long v22;
        v22 = 0l;
        const char * v23;
        v23 = "%c";
        printf(v23,'[');
        long v24;
        v24 = 0l;
        while (while_method_1(v24)){
            long v26;
            v26 = v22;
            bool v27;
            v27 = v26 >= 100l;
            if (v27){
                const char * v28;
                v28 = "%s";
                const char * v29;
                v29 = " ...";
                printf(v28,v29);
                break;
            } else {
            }
            bool v31;
            v31 = v24 == 0l;
            bool v32;
            v32 = v31 != true;
            if (v32){
                const char * v33;
                v33 = "%s";
                const char * v34;
                v34 = "; ";
                printf(v33,v34);
            } else {
            }
            const char * v36;
            v36 = "%c";
            printf(v36,'[');
            long v37;
            v37 = 0l;
            while (while_method_2(v37)){
                long v39;
                v39 = v22;
                bool v40;
                v40 = v39 >= 100l;
                if (v40){
                    const char * v41;
                    v41 = "%s";
                    const char * v42;
                    v42 = " ...";
                    printf(v41,v42);
                    break;
                } else {
                }
                bool v44;
                v44 = v37 == 0l;
                bool v45;
                v45 = v44 != true;
                if (v45){
                    const char * v46;
                    v46 = "%s";
                    const char * v47;
                    v47 = "; ";
                    printf(v46,v47);
                } else {
                }
                long v49;
                v49 = v22 + 1l;
                v22 = v49;
                long v50;
                v50 = v24 * 8l;
                long v51;
                v51 = v50 + v37;
                float v52;
                v52 = v4[v51];
                const char * v53;
                v53 = "%f";
                printf(v53,v52);
                v37 += 1l ;
            }
            const char * v54;
            v54 = "%c";
            printf(v54,']');
            v24 += 1l ;
        }
        const char * v55;
        v55 = "%c";
        printf(v55,']');
        printf("\n");
    } else {
    }
    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v56;
    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v57 = v56;
    long v58;
    v58 = v3.meta_group_size();
    long v59;
    v59 = v3.meta_group_rank();
    long v60;
    v60 = v59;
    while (while_method_0(v60)){
        long v62;
        v62 = v60 % 8l;
        long v63;
        v63 = v60 / 8l;
        long v64;
        v64 = v63 % 16l;
        long v65;
        v65 = v63 / 16l;
        bool v66;
        v66 = v65 == 0l;
        bool v67;
        v67 = v66 == false;
        if (v67){
            assert("The index has to be in the range of the dimension." && v66);
        } else {
        }
        assert("Tensor range check" && 0 <= v64 && v64 < 16l);
        assert("Tensor range check" && 0 <= v62 && v62 < 8l);
        long v69;
        v69 = 8l * v64;
        long v70;
        v70 = v69 + v62;
        assert("Tensor range check" && 0 <= v64 && v64 < 16l);
        assert("Tensor range check" && 0 <= v62 && v62 < 8l);
        int* v71;
        v71 = reinterpret_cast<int*>(v0 + v70);
        int* v72;
        v72 = reinterpret_cast<int*>(v4 + v70);
        assert("Pointer alignment check" && v71 % sizeof(int) == 0 && v72 % sizeof(int) == 0);
        *v72 = *v71;
        v60 += v58 ;
    }
    v2.sync() ;
    float * v73;
    v73 = v4 + 0l;
    wmma::load_matrix_sync(v57, v73, 8l);
    #pragma unroll
    for (int t = 0; t < v57.num_elements; t++) { v57.x[t] = wmma::__float_to_tf32(v57.x[t]); };
    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v74 = v57;
    long v75;
    v75 = v74.num_elements;
    long v76;
    v76 = 0l;
    while (while_method_3(v75, v76)){
        bool v78;
        v78 = v76 == 0l;
        if (v78){
            double v79;
            v79 = (double) v57.x[v76];
            long v80;
            v80 = grid_group::thread_rank();
            static cuda::binary_semaphore<cuda::thread_scope_system> v81(1l);
            v81.acquire();
            const char * v82;
            v82 = "%c";
            printf(v82,'{');
            const char * v83;
            v83 = "%s";
            const char * v84;
            v84 = "i";
            printf(v83,v84);
            const char * v86;
            v86 = "%s";
            const char * v87;
            v87 = " = ";
            printf(v86,v87);
            const char * v89;
            v89 = "%d";
            printf(v89,v76);
            const char * v90;
            v90 = "%s";
            const char * v91;
            v91 = "; ";
            printf(v90,v91);
            const char * v93;
            v93 = "%s";
            const char * v94;
            v94 = "id";
            printf(v93,v94);
            const char * v96;
            v96 = "%s";
            const char * v97;
            v97 = " = ";
            printf(v96,v97);
            const char * v99;
            v99 = "%d";
            printf(v99,v80);
            const char * v100;
            v100 = "%s";
            const char * v101;
            v101 = "; ";
            printf(v100,v101);
            const char * v103;
            v103 = "%s";
            const char * v104;
            v104 = "value";
            printf(v103,v104);
            const char * v106;
            v106 = "%s";
            const char * v107;
            v107 = " = ";
            printf(v106,v107);
            const char * v109;
            v109 = "%f";
            printf(v109,v79);
            const char * v110;
            v110 = "%c";
            printf(v110,'}');
            printf("\n");
            v81.release();
        } else {
        }
        v76 += 1l ;
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
def main():
    v0 = cp.arange(0,128,1,dtype=cp.float32)
    v1 = v0.size
    v2 = 128 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.zeros(128,dtype=cp.float32)
    v6 = v5.size
    del v5
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
    v10 = 0
    v11 = raw_module.get_function(f"entry{v10}")
    del v10
    v11.max_dynamic_shared_size_bytes = 0 
    v11((1,),(32,),v0,shared_mem=0)
    del v0, v11
    return 

if __name__ == '__main__': print(main())
