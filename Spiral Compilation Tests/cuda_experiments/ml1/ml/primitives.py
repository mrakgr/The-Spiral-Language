kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <cooperative_groups.h>
#include <cooperative_groups/scan.h>
#include <cooperative_groups/reduce.h>
struct Tuple0;
typedef long (* Fun0)(long, long);
struct Tuple0 {
    long v0;
    long v1;
    __device__ Tuple0(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 108l;
    return v1;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 36l;
    return v1;
}
__device__ long ClosureMethod0(long tup0, long tup1){
    long v0 = tup0; long v1 = tup1;
    long v2;
    v2 = v0 + v1;
    return v2;
}
extern "C" __global__ void entry0(long * v0, long * v1, long * v2, long * v3) {
    long v4;
    v4 = threadIdx.x;
    long v5;
    v5 = v4;
    while (while_method_0(v5)){
        bool v7;
        v7 = 0l <= v5;
        bool v8;
        v8 = v7 == false;
        if (v8){
            assert("The index needs to be zero or positive." && v7);
        } else {
        }
        long v10;
        v10 = v5 % 36l;
        long v11;
        v11 = v5 / 36l;
        bool v12;
        v12 = v11 < 3l;
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v12);
        } else {
        }
        assert("Tensor range check" && 0 <= v11 && v11 < 3l);
        assert("Tensor range check" && 0 <= v10 && v10 < 36l);
        long v15;
        v15 = 4l * v10;
        long v16;
        v16 = 144l * v11;
        long v17;
        v17 = v16 + v15;
        assert("Tensor range check" && 0 <= v11 && v11 < 3l);
        assert("Tensor range check" && 0 <= v10 && v10 < 36l);
        long v18[4l];
        long v19[4l];
        int4* v20;
        v20 = reinterpret_cast<int4*>(v0 + v17);
        int4* v21;
        v21 = reinterpret_cast<int4*>(v18 + 0l);
        assert("Pointer alignment check" && (unsigned long long)(v20) % 4l == 0 && (unsigned long long)(v21) % 4l == 0);
        *v21 = *v20;
        // Pushing the loop unrolling to: 0
        long v22;
        v22 = 0l;
        #pragma unroll
        while (while_method_1(v22)){
            assert("Tensor range check" && 0 <= v22 && v22 < 4l);
            long v24;
            v24 = v18[v22];
            long v25;
            v25 = 1l + v24;
            assert("Tensor range check" && 0 <= v22 && v22 < 4l);
            v19[v22] = v25;
            v22 += 1l ;
        }
        // Poping the loop unrolling to: 0
        int4* v26;
        v26 = reinterpret_cast<int4*>(v19 + 0l);
        int4* v27;
        v27 = reinterpret_cast<int4*>(v0 + v17);
        assert("Pointer alignment check" && (unsigned long long)(v26) % 4l == 0 && (unsigned long long)(v27) % 4l == 0);
        *v27 = *v26;
        v5 += 512l ;
    }
    __syncthreads();
    long v28;
    v28 = threadIdx.x;
    long v29;
    v29 = v28 / 32l;
    long v30;
    v30 = v29;
    while (while_method_2(v30)){
        bool v32;
        v32 = 0l <= v30;
        bool v33;
        v33 = v32 == false;
        if (v33){
            assert("The index needs to be zero or positive." && v32);
        } else {
        }
        bool v35;
        v35 = v30 < 3l;
        bool v36;
        v36 = v35 == false;
        if (v36){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v35);
        } else {
        }
        assert("Tensor range check" && 0 <= v30 && v30 < 3l);
        long v38;
        v38 = 144l * v30;
        assert("Tensor range check" && 0 <= v30 && v30 < 3l);
        long v39;
        v39 = 0l;
        long v40;
        v40 = threadIdx.x;
        long v41;
        v41 = v40 % 32l;
        long v42;
        v42 = v41;
        while (while_method_3(v42)){
            bool v44;
            v44 = 0l <= v42;
            bool v45;
            v45 = v44 == false;
            if (v45){
                assert("The index needs to be zero or positive." && v44);
            } else {
            }
            bool v47;
            v47 = v42 < 36l;
            bool v48;
            v48 = v47 == false;
            if (v48){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v47);
            } else {
            }
            auto v50 = cooperative_groups::coalesced_threads();
            assert("Tensor range check" && 0 <= v42 && v42 < 36l);
            long v51;
            v51 = 4l * v42;
            long v52;
            v52 = v51 + v38;
            assert("Tensor range check" && 0 <= v42 && v42 < 36l);
            long v53[4l];
            int4* v54;
            v54 = reinterpret_cast<int4*>(v0 + v52);
            int4* v55;
            v55 = reinterpret_cast<int4*>(v53 + 0l);
            assert("Pointer alignment check" && (unsigned long long)(v54) % 4l == 0 && (unsigned long long)(v55) % 4l == 0);
            *v55 = *v54;
            long v56; long v57;
            Tuple0 tmp0 = Tuple0(0l, 0l);
            v56 = tmp0.v0; v57 = tmp0.v1;
            while (while_method_1(v56)){
                assert("Tensor range check" && 0 <= v56 && v56 < 4l);
                long v59;
                v59 = v53[v56];
                long v60;
                v60 = v59 + v57;
                v57 = v60;
                v56 += 1l ;
            }
            Fun0 v61;
            v61 = ClosureMethod0;
            long v62;
            v62 = cooperative_groups::inclusive_scan(v50, v57, v61);
            long v63;
            v63 = v50.shfl(v62,v50.num_threads()-1);
            long v64;
            v64 = v50.shfl_up(v62,1);
            bool v65;
            v65 = v50.thread_rank() == 0;
            long v66;
            if (v65){
                v66 = 0l;
            } else {
                v66 = v64;
            }
            long v67;
            v67 = v39 + v66;
            long v68; long v69;
            Tuple0 tmp1 = Tuple0(0l, v67);
            v68 = tmp1.v0; v69 = tmp1.v1;
            while (while_method_1(v68)){
                assert("Tensor range check" && 0 <= v68 && v68 < 4l);
                long v71;
                v71 = v53[v68];
                assert("Tensor range check" && 0 <= v68 && v68 < 4l);
                v53[v68] = v69;
                long v72;
                v72 = v71 + v69;
                v69 = v72;
                v68 += 1l ;
            }
            int4* v73;
            v73 = reinterpret_cast<int4*>(v53 + 0l);
            int4* v74;
            v74 = reinterpret_cast<int4*>(v2 + v52);
            assert("Pointer alignment check" && (unsigned long long)(v73) % 4l == 0 && (unsigned long long)(v74) % 4l == 0);
            *v74 = *v73;
            long v75;
            v75 = v39 + v63;
            v39 = v75;
            v42 += 32l ;
        }
        v30 += 16l ;
    }
    __syncthreads();
    long v76;
    v76 = threadIdx.x;
    long v77;
    v77 = v76 / 32l;
    long v78;
    v78 = v77;
    while (while_method_2(v78)){
        bool v80;
        v80 = 0l <= v78;
        bool v81;
        v81 = v80 == false;
        if (v81){
            assert("The index needs to be zero or positive." && v80);
        } else {
        }
        bool v83;
        v83 = v78 < 3l;
        bool v84;
        v84 = v83 == false;
        if (v84){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v83);
        } else {
        }
        assert("Tensor range check" && 0 <= v78 && v78 < 3l);
        long v86;
        v86 = 144l * v78;
        assert("Tensor range check" && 0 <= v78 && v78 < 3l);
        long v87;
        v87 = 0l;
        long v88;
        v88 = threadIdx.x;
        long v89;
        v89 = v88 % 32l;
        long v90;
        v90 = v89;
        while (while_method_3(v90)){
            bool v92;
            v92 = 0l <= v90;
            bool v93;
            v93 = v92 == false;
            if (v93){
                assert("The index needs to be zero or positive." && v92);
            } else {
            }
            bool v95;
            v95 = v90 < 36l;
            bool v96;
            v96 = v95 == false;
            if (v96){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v95);
            } else {
            }
            auto v98 = cooperative_groups::coalesced_threads();
            assert("Tensor range check" && 0 <= v90 && v90 < 36l);
            long v99;
            v99 = 4l * v90;
            long v100;
            v100 = v99 + v86;
            assert("Tensor range check" && 0 <= v90 && v90 < 36l);
            long v101[4l];
            int4* v102;
            v102 = reinterpret_cast<int4*>(v0 + v100);
            int4* v103;
            v103 = reinterpret_cast<int4*>(v101 + 0l);
            assert("Pointer alignment check" && (unsigned long long)(v102) % 4l == 0 && (unsigned long long)(v103) % 4l == 0);
            *v103 = *v102;
            long v104; long v105;
            Tuple0 tmp2 = Tuple0(0l, 0l);
            v104 = tmp2.v0; v105 = tmp2.v1;
            while (while_method_1(v104)){
                assert("Tensor range check" && 0 <= v104 && v104 < 4l);
                long v107;
                v107 = v101[v104];
                long v108;
                v108 = v107 + v105;
                v105 = v108;
                v104 += 1l ;
            }
            Fun0 v109;
            v109 = ClosureMethod0;
            long v110;
            v110 = cooperative_groups::inclusive_scan(v98, v105, v109);
            long v111;
            v111 = v98.shfl(v110,v98.num_threads()-1);
            long v112;
            v112 = v98.shfl_up(v110,1);
            bool v113;
            v113 = v98.thread_rank() == 0;
            long v114;
            if (v113){
                v114 = 0l;
            } else {
                v114 = v112;
            }
            long v115;
            v115 = v87 + v114;
            long v116; long v117;
            Tuple0 tmp3 = Tuple0(0l, v115);
            v116 = tmp3.v0; v117 = tmp3.v1;
            while (while_method_1(v116)){
                assert("Tensor range check" && 0 <= v116 && v116 < 4l);
                long v119;
                v119 = v101[v116];
                long v120;
                v120 = v119 + v117;
                assert("Tensor range check" && 0 <= v116 && v116 < 4l);
                v101[v116] = v120;
                v117 = v120;
                v116 += 1l ;
            }
            int4* v121;
            v121 = reinterpret_cast<int4*>(v101 + 0l);
            int4* v122;
            v122 = reinterpret_cast<int4*>(v1 + v100);
            assert("Pointer alignment check" && (unsigned long long)(v121) % 4l == 0 && (unsigned long long)(v122) % 4l == 0);
            *v122 = *v121;
            long v123;
            v123 = v87 + v111;
            v87 = v123;
            v90 += 32l ;
        }
        v78 += 16l ;
    }
    __syncthreads();
    long v124;
    v124 = threadIdx.x;
    long v125;
    v125 = v124 / 32l;
    long v126;
    v126 = v125;
    while (while_method_2(v126)){
        bool v128;
        v128 = 0l <= v126;
        bool v129;
        v129 = v128 == false;
        if (v129){
            assert("The index needs to be zero or positive." && v128);
        } else {
        }
        bool v131;
        v131 = v126 < 3l;
        bool v132;
        v132 = v131 == false;
        if (v132){
            assert("The last element of the projection dimensions needs to be greater than the index remainder." && v131);
        } else {
        }
        assert("Tensor range check" && 0 <= v126 && v126 < 3l);
        long v134;
        v134 = 144l * v126;
        long v135;
        v135 = 0l;
        long v136;
        v136 = threadIdx.x;
        long v137;
        v137 = v136 % 32l;
        long v138;
        v138 = v137;
        while (while_method_3(v138)){
            bool v140;
            v140 = 0l <= v138;
            bool v141;
            v141 = v140 == false;
            if (v141){
                assert("The index needs to be zero or positive." && v140);
            } else {
            }
            bool v143;
            v143 = v138 < 36l;
            bool v144;
            v144 = v143 == false;
            if (v144){
                assert("The last element of the projection dimensions needs to be greater than the index remainder." && v143);
            } else {
            }
            assert("Tensor range check" && 0 <= v138 && v138 < 36l);
            long v146;
            v146 = 4l * v138;
            long v147;
            v147 = v146 + v134;
            long v148[4l];
            int4* v149;
            v149 = reinterpret_cast<int4*>(v0 + v147);
            int4* v150;
            v150 = reinterpret_cast<int4*>(v148 + 0l);
            assert("Pointer alignment check" && (unsigned long long)(v149) % 4l == 0 && (unsigned long long)(v150) % 4l == 0);
            *v150 = *v149;
            long v151; long v152;
            Tuple0 tmp4 = Tuple0(0l, 0l);
            v151 = tmp4.v0; v152 = tmp4.v1;
            while (while_method_1(v151)){
                assert("Tensor range check" && 0 <= v151 && v151 < 4l);
                long v154;
                v154 = v148[v151];
                long v155;
                v155 = v154 + v152;
                v152 = v155;
                v151 += 1l ;
            }
            long v156;
            v156 = v135 + v152;
            v135 = v156;
            v138 += 32l ;
        }
        auto v157 = cooperative_groups::coalesced_threads();
        Fun0 v158;
        v158 = ClosureMethod0;
        long v159;
        v159 = cooperative_groups::reduce(v157, v135, v158);
        assert("Tensor range check" && 0 <= v126 && v126 < 3l);
        v3[v126] = v159;
        v126 += 16l ;
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
    v1 = v0 < 3
    del v0
    return v1
def method1(v0 : i32) -> bool:
    v1 = v0 < 144
    del v0
    return v1
def main():
    v0 = cp.arange(0,432,1,dtype=cp.int32)
    v1 = v0.size
    v2 = 432 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.zeros(432,dtype=cp.int32)
    v6 = v5.size
    v7 = 432 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.zeros(432,dtype=cp.int32)
    v11 = v10.size
    v12 = 432 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = cp.zeros(3,dtype=cp.int32)
    v16 = v15.size
    v17 = 3 == v16
    del v16
    v18 = v17 == False
    if v18:
        v19 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v17, v19
        del v19
    else:
        pass
    del v17, v18
    v20 = 0
    v21 = raw_module.get_function(f"entry{v20}")
    del v20
    v21.max_dynamic_shared_size_bytes = 0 
    v21((1,),(512,),(v0, v5, v10, v15),shared_mem=0)
    del v21
    v22 = 0
    print('[', end="")
    v24 = 0
    while method0(v24):
        v26 = v22
        v27 = v26 >= 1024
        del v26
        if v27:
            v30 = " ..."
            print(v30, end="")
            del v30
            break
        else:
            pass
        del v27
        v31 = v24 == 0
        v32 = v31 != True
        del v31
        if v32:
            v35 = "; "
            print(v35, end="")
            del v35
        else:
            pass
        del v32
        print('[', end="")
        v37 = 0
        while method1(v37):
            v39 = v22
            v40 = v39 >= 1024
            del v39
            if v40:
                v43 = " ..."
                print(v43, end="")
                del v43
                break
            else:
                pass
            del v40
            v44 = v37 == 0
            v45 = v44 != True
            del v44
            if v45:
                v48 = "; "
                print(v48, end="")
                del v48
            else:
                pass
            del v45
            v49 = v22 + 1
            v22 = v49
            del v49
            v50 = v24 * 144
            v51 = v50 + v37
            del v50
            v52 = v0[v51].item()
            del v51
            print(v52, end="")
            del v52
            v37 += 1 
        del v37
        print(']', end="")
        v24 += 1 
    del v0, v22, v24
    print(']', end="")
    print()
    v56 = 0
    print('[', end="")
    v58 = 0
    while method0(v58):
        v60 = v56
        v61 = v60 >= 1024
        del v60
        if v61:
            v64 = " ..."
            print(v64, end="")
            del v64
            break
        else:
            pass
        del v61
        v65 = v58 == 0
        v66 = v65 != True
        del v65
        if v66:
            v69 = "; "
            print(v69, end="")
            del v69
        else:
            pass
        del v66
        print('[', end="")
        v71 = 0
        while method1(v71):
            v73 = v56
            v74 = v73 >= 1024
            del v73
            if v74:
                v77 = " ..."
                print(v77, end="")
                del v77
                break
            else:
                pass
            del v74
            v78 = v71 == 0
            v79 = v78 != True
            del v78
            if v79:
                v82 = "; "
                print(v82, end="")
                del v82
            else:
                pass
            del v79
            v83 = v56 + 1
            v56 = v83
            del v83
            v84 = v58 * 144
            v85 = v84 + v71
            del v84
            v86 = v10[v85].item()
            del v85
            print(v86, end="")
            del v86
            v71 += 1 
        del v71
        print(']', end="")
        v58 += 1 
    del v10, v56, v58
    print(']', end="")
    print()
    v90 = 0
    print('[', end="")
    v92 = 0
    while method0(v92):
        v94 = v90
        v95 = v94 >= 1024
        del v94
        if v95:
            v98 = " ..."
            print(v98, end="")
            del v98
            break
        else:
            pass
        del v95
        v99 = v92 == 0
        v100 = v99 != True
        del v99
        if v100:
            v103 = "; "
            print(v103, end="")
            del v103
        else:
            pass
        del v100
        print('[', end="")
        v105 = 0
        while method1(v105):
            v107 = v90
            v108 = v107 >= 1024
            del v107
            if v108:
                v111 = " ..."
                print(v111, end="")
                del v111
                break
            else:
                pass
            del v108
            v112 = v105 == 0
            v113 = v112 != True
            del v112
            if v113:
                v116 = "; "
                print(v116, end="")
                del v116
            else:
                pass
            del v113
            v117 = v90 + 1
            v90 = v117
            del v117
            v118 = v92 * 144
            v119 = v118 + v105
            del v118
            v120 = v5[v119].item()
            del v119
            print(v120, end="")
            del v120
            v105 += 1 
        del v105
        print(']', end="")
        v92 += 1 
    del v5, v90, v92
    print(']', end="")
    print()
    v124 = 0
    print('[', end="")
    v126 = 0
    while method0(v126):
        v128 = v124
        v129 = v128 >= 1024
        del v128
        if v129:
            v132 = " ..."
            print(v132, end="")
            del v132
            break
        else:
            pass
        del v129
        v133 = v126 == 0
        v134 = v133 != True
        del v133
        if v134:
            v137 = "; "
            print(v137, end="")
            del v137
        else:
            pass
        del v134
        v138 = v124 + 1
        v124 = v138
        del v138
        v139 = v15[v126].item()
        print(v139, end="")
        del v139
        v126 += 1 
    del v15, v124, v126
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
