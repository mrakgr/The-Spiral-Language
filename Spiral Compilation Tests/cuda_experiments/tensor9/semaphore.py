kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <mma.h>
using namespace nvcuda;
#include <cooperative_groups.h>
#include <cooperative_groups/memcpy_async.h>
using namespace cooperative_groups;
#include <cuda/semaphore>
extern "C" __global__ void entry0() {
    __shared__ cuda::binary_semaphore<cuda::thread_scope_block> v0;
    long v1;
    v1 = thread_block::thread_rank();
    bool v2;
    v2 = v1 == 0l;
    if (v2){
        new(&v0) cuda::binary_semaphore<cuda::thread_scope_block>(1l);
    } else {
    }
    __syncthreads();
    v0.acquire();
    const char * v3;
    v3 = "%s";
    const char * v4;
    v4 = "hello";
    printf(v3,v4);
    printf("\n");
    long v6;
    v6 = grid_group::thread_rank();
    const char * v7;
    v7 = "%c";
    printf(v7,'{');
    const char * v8;
    v8 = "%s";
    const char * v9;
    v9 = "id";
    printf(v8,v9);
    const char * v11;
    v11 = "%s";
    const char * v12;
    v12 = " = ";
    printf(v11,v12);
    const char * v14;
    v14 = "%d";
    printf(v14,v6);
    const char * v15;
    v15 = "%c";
    printf(v15,'}');
    printf("\n");
    v0.release();
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
    v1 = v0 < 8
    del v0
    return v1
def method1(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def main():
    v0 = cp.arange(0,32,1,dtype=cp.float64)
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
    v5 = cp.zeros(32,dtype=cp.float64)
    v6 = v5.size
    v7 = 32 == v6
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
    print('[', end="")
    v12 = 0
    while method0(v12):
        v14 = v10
        v15 = v14 >= 100
        del v14
        if v15:
            v18 = " ..."
            print(v18, end="")
            del v18
            break
        else:
            pass
        del v15
        v19 = v12 == 0
        v20 = v19 != True
        del v19
        if v20:
            v23 = "; "
            print(v23, end="")
            del v23
        else:
            pass
        del v20
        print('[', end="")
        v25 = 0
        while method1(v25):
            v27 = v10
            v28 = v27 >= 100
            del v27
            if v28:
                v31 = " ..."
                print(v31, end="")
                del v31
                break
            else:
                pass
            del v28
            v32 = v25 == 0
            v33 = v32 != True
            del v32
            if v33:
                v36 = "; "
                print(v36, end="")
                del v36
            else:
                pass
            del v33
            v37 = v10 + 1
            v10 = v37
            del v37
            v38 = v12 * 4
            v39 = v38 + v25
            del v38
            v40 = v0[v39].item()
            del v39
            print("{:.6f}".format(v40), end="")
            del v40
            v25 += 1 
        del v25
        print(']', end="")
        v12 += 1 
    del v0, v10, v12
    print(']', end="")
    print()
    v44 = 0
    print('[', end="")
    v46 = 0
    while method0(v46):
        v48 = v44
        v49 = v48 >= 100
        del v48
        if v49:
            v52 = " ..."
            print(v52, end="")
            del v52
            break
        else:
            pass
        del v49
        v53 = v46 == 0
        v54 = v53 != True
        del v53
        if v54:
            v57 = "; "
            print(v57, end="")
            del v57
        else:
            pass
        del v54
        print('[', end="")
        v59 = 0
        while method1(v59):
            v61 = v44
            v62 = v61 >= 100
            del v61
            if v62:
                v65 = " ..."
                print(v65, end="")
                del v65
                break
            else:
                pass
            del v62
            v66 = v59 == 0
            v67 = v66 != True
            del v66
            if v67:
                v70 = "; "
                print(v70, end="")
                del v70
            else:
                pass
            del v67
            v71 = v44 + 1
            v44 = v71
            del v71
            v72 = v46 * 4
            v73 = v72 + v59
            del v72
            v74 = v5[v73].item()
            del v73
            print("{:.6f}".format(v74), end="")
            del v74
            v59 += 1 
        del v59
        print(']', end="")
        v46 += 1 
    del v5, v44, v46
    print(']', end="")
    print()
    v78 = 0
    v79 = raw_module.get_function(f"entry{v78}")
    del v78
    v79.max_dynamic_shared_size_bytes = 0 
    v79((1,),(32,),(),shared_mem=0)
    del v79
    return 

if __name__ == '__main__': print(main())
