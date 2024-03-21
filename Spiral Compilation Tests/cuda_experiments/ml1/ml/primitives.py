kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
#include <cooperative_groups/reduce.h>
struct Tuple0;
typedef float (* Fun0)(float, float);
struct Tuple0 {
    long v0;
    float v1;
    __device__ Tuple0(long t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 512l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ float ClosureMethod0(float tup0, float tup1){
    float v0 = tup0; float v1 = tup1;
    float v2;
    v2 = v0 + v1;
    return v2;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ float ClosureMethod1(float tup0, float tup1){
    float v0 = tup0; float v1 = tup1;
    float v2;
    v2 = v0 + v1;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    auto v3 = cooperative_groups::this_thread_block();
    float v4;
    v4 = 0.0f;
    long v5;
    v5 = threadIdx.x;
    long v6;
    v6 = v5;
    while (while_method_0(v6)){
        bool v8;
        v8 = 0l <= v6;
        bool v9;
        v9 = v8 == false;
        if (v9){
            assert("The index needs to be zero or positive." && v8);
        } else {
        }
        long v11;
        v11 = v6 % 4l;
        long v12;
        v12 = v6 / 4l;
        bool v13;
        v13 = v12 < 128l;
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v13);
        } else {
        }
        assert("Tensor range check" && 0 <= v12 && v12 < 128l);
        assert("Tensor range check" && 0 <= v11 && v11 < 4l);
        long v16;
        v16 = 4l * v11;
        long v17;
        v17 = 16l * v12;
        long v18;
        v18 = v17 + v16;
        float v19[4l];
        int4* v20;
        v20 = reinterpret_cast<int4*>(v0 + v18);
        int4* v21;
        v21 = reinterpret_cast<int4*>(v19 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v20) % 4l == 0 && (unsigned long long)(v21) % 4l == 0);
        *v21 = *v20;
        long v22; float v23;
        Tuple0 tmp0 = Tuple0(0l, v4);
        v22 = tmp0.v0; v23 = tmp0.v1;
        while (while_method_1(v22)){
            assert("Tensor range check" && 0 <= v22 && v22 < 4l);
            float v25;
            v25 = v19[v22];
            float v26;
            v26 = v25 + v23;
            v23 = v26;
            v22 += 1l ;
        }
        v4 = v23;
        v6 += 512l ;
    }
    auto v27 = cooperative_groups::coalesced_threads();
    Fun0 v28;
    v28 = ClosureMethod0;
    float v29;
    v29 = cooperative_groups::reduce(v27, v4, v28);
    long v30;
    v30 = threadIdx.x;
    long v31;
    v31 = v30 / 32l;
    __shared__ float v32[16l];
    assert("Tensor range check" && 0 <= v31 && v31 < 16l);
    v32[v31] = v29;
    __syncthreads();
    long v33;
    v33 = threadIdx.x;
    long v34;
    v34 = v33 % 32l;
    bool v35;
    v35 = v31 == 0l;
    bool v37;
    if (v35){
        bool v36;
        v36 = v34 < 16l;
        v37 = v36;
    } else {
        v37 = false;
    }
    if (v37){
        auto v38 = cooperative_groups::coalesced_threads();
        assert("Tensor range check" && 0 <= v34 && v34 < 16l);
        float v39;
        v39 = v32[v34];
        float v40;
        v40 = cooperative_groups::reduce(v38, v39, v28);
        v1[0l] = v40;
    } else {
    }
    __syncthreads();
    cooperative_groups::thread_block_tile<4l, cooperative_groups::thread_block> v41 = cooperative_groups::tiled_partition<4l>(v3);
    long v42;
    v42 = threadIdx.x;
    bool v43;
    v43 = 0l <= v42;
    bool v44;
    v44 = v43 == false;
    if (v44){
        assert("The index needs to be zero or positive." && v43);
    } else {
    }
    long v46;
    v46 = v42 % 4l;
    long v47;
    v47 = v42 / 4l;
    bool v48;
    v48 = v47 < 128l;
    bool v49;
    v49 = v48 == false;
    if (v49){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v48);
    } else {
    }
    assert("Tensor range check" && 0 <= v47 && v47 < 128l);
    assert("Tensor range check" && 0 <= v46 && v46 < 4l);
    long v51;
    v51 = 4l * v46;
    long v52;
    v52 = 16l * v47;
    long v53;
    v53 = v52 + v51;
    long v54;
    v54 = threadIdx.x;
    bool v55;
    v55 = 0l <= v54;
    bool v56;
    v56 = v55 == false;
    if (v56){
        assert("The index needs to be zero or positive." && v55);
    } else {
    }
    long v58;
    v58 = v54 % 4l;
    long v59;
    v59 = v54 / 4l;
    bool v60;
    v60 = v59 < 128l;
    bool v61;
    v61 = v60 == false;
    if (v61){
        assert("The last element of the projection dimensions needs to be greater than the index remainder." && v60);
    } else {
    }
    assert("Tensor range check" && 0 <= v59 && v59 < 128l);
    assert("Tensor range check" && 0 <= v58 && v58 < 4l);
    long v63;
    v63 = 4l * v58;
    long v64;
    v64 = 16l * v59;
    long v65;
    v65 = v64 + v63;
    long v66;
    v66 = 0l;
    while (while_method_2(v66)){
        assert("Tensor range check" && 0 <= v66 && v66 < 1l);
        long v68;
        v68 = 2048l * v66;
        long v69;
        v69 = v68 + v53;
        assert("Tensor range check" && 0 <= v66 && v66 < 1l);
        long v70;
        v70 = v68 + v65;
        float v71[4l];
        long v72;
        v72 = 0l;
        while (while_method_2(v72)){
            assert("Tensor range check" && 0 <= v72 && v72 < 1l);
            long v74;
            v74 = 4l * v72;
            assert("Tensor range check" && 0 <= v72 && v72 < 1l);
            long v75;
            v75 = 16l * v72;
            long v76;
            v76 = v75 + v69;
            int4* v77;
            v77 = reinterpret_cast<int4*>(v0 + v76);
            int4* v78;
            v78 = reinterpret_cast<int4*>(v71 + v74);
            assert("Pointer alignment check" && (unsigned long long)(v77) % 4l == 0 && (unsigned long long)(v78) % 4l == 0);
            *v78 = *v77;
            v72 += 1l ;
        }
        float v79;
        v79 = 0.0f;
        long v80;
        v80 = 0l;
        while (while_method_2(v80)){
            long v82;
            v82 = 0l;
            while (while_method_1(v82)){
                assert("Tensor range check" && 0 <= v80 && v80 < 1l);
                assert("Tensor range check" && 0 <= v82 && v82 < 4l);
                long v84;
                v84 = 4l * v80;
                long v85;
                v85 = v84 + v82;
                float v86;
                v86 = v71[v85];
                float v87;
                v87 = v86 + v79;
                v79 = v87;
                v82 += 1l ;
            }
            v80 += 1l ;
        }
        Fun0 v88;
        v88 = ClosureMethod1;
        float v89;
        v89 = cooperative_groups::reduce(v41, v79, v88);
        float v90[4l];
        long v91;
        v91 = 0l;
        while (while_method_2(v91)){
            long v93;
            v93 = 0l;
            while (while_method_1(v93)){
                assert("Tensor range check" && 0 <= v91 && v91 < 1l);
                assert("Tensor range check" && 0 <= v93 && v93 < 4l);
                long v95;
                v95 = 4l * v91;
                long v96;
                v96 = v95 + v93;
                float v97;
                v97 = v71[v96];
                assert("Tensor range check" && 0 <= v91 && v91 < 1l);
                assert("Tensor range check" && 0 <= v93 && v93 < 4l);
                v90[v96] = v89;
                v93 += 1l ;
            }
            v91 += 1l ;
        }
        long v98;
        v98 = 0l;
        while (while_method_2(v98)){
            assert("Tensor range check" && 0 <= v98 && v98 < 1l);
            long v100;
            v100 = 16l * v98;
            long v101;
            v101 = v100 + v70;
            assert("Tensor range check" && 0 <= v98 && v98 < 1l);
            long v102;
            v102 = 4l * v98;
            int4* v103;
            v103 = reinterpret_cast<int4*>(v90 + v102);
            int4* v104;
            v104 = reinterpret_cast<int4*>(v2 + v101);
            assert("Pointer alignment check" && (unsigned long long)(v103) % 4l == 0 && (unsigned long long)(v104) % 4l == 0);
            *v104 = *v103;
            v98 += 1l ;
        }
        v66 += 1l ;
    }
    __syncthreads();
    return ;
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
def method0(v0 : i32) -> bool:
    v1 = v0 < 128
    del v0
    return v1
def method1(v0 : i32) -> bool:
    v1 = v0 < 16
    del v0
    return v1
def main():
    v0 = cp.arange(0,2048,1,dtype=cp.float32)
    v1 = v0.size
    v2 = 2048 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.zeros(1,dtype=cp.float32)
    v6 = v5.size
    v7 = 1 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.zeros(2048,dtype=cp.float32)
    v11 = v10.size
    v12 = 2048 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = 0
    v16 = raw_module.get_function(f"entry{v15}")
    del v15
    v16.max_dynamic_shared_size_bytes = 0 
    v16((1,),(512,),(v0, v5, v10),shared_mem=0)
    del v0, v5, v16
    v17 = 0
    print('[', end="")
    v19 = 0
    while method0(v19):
        v21 = v17
        v22 = v21 >= 1024
        del v21
        if v22:
            v25 = " ..."
            print(v25, end="")
            del v25
            break
        else:
            pass
        del v22
        v26 = v19 == 0
        v27 = v26 != True
        del v26
        if v27:
            v30 = "; "
            print(v30, end="")
            del v30
        else:
            pass
        del v27
        print('[', end="")
        v32 = 0
        while method1(v32):
            v34 = v17
            v35 = v34 >= 1024
            del v34
            if v35:
                v38 = " ..."
                print(v38, end="")
                del v38
                break
            else:
                pass
            del v35
            v39 = v32 == 0
            v40 = v39 != True
            del v39
            if v40:
                v43 = "; "
                print(v43, end="")
                del v43
            else:
                pass
            del v40
            v44 = v17 + 1
            v17 = v44
            del v44
            v45 = v19 * 16
            v46 = v45 + v32
            del v45
            v47 = v10[v46].item()
            del v46
            print("{:.6f}".format(v47), end="")
            del v47
            v32 += 1 
        del v32
        print(']', end="")
        v19 += 1 
    del v10, v17, v19
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
