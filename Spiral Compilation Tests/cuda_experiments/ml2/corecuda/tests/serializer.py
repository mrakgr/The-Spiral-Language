kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
struct US0;
struct Tuple0;
struct US1;
struct Tuple1;
struct US0 {
    union {
        struct {
            unsigned long long v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    US0 v1;
    long v0;
    __device__ Tuple0(long t0, US0 t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct US1 {
    union {
        struct {
            unsigned long long v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct Tuple1 {
    US1 v1;
    long v0;
    __device__ Tuple1(long t0, US1 t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
__device__ US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1(unsigned long long v0) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_0(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__device__ US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1(unsigned long long v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
extern "C" __global__ void entry0(unsigned char * v0) {
    long v1;
    v1 = threadIdx.x;
    long v2;
    v2 = blockIdx.x;
    long v3;
    v3 = v2 * 512l;
    long v4;
    v4 = v1 + v3;
    bool v5;
    v5 = v4 == 0l;
    if (v5){
        short * v6;
        v6 = (short *)(v0+0ull);
        short v7;
        v7 = v6[0l];
        unsigned long long * v8;
        v8 = (unsigned long long *)(v0+8ull);
        unsigned long long v9;
        v9 = v8[0l];
        array<Tuple0,14l> v10;
        long v11 = 0l;
        long * v12;
        v12 = (long *)(v0+16ull);
        long v13;
        v13 = v12[0l];
        long & v14 = v11;
        v11 = v13;
        long & v15 = v11;
        long v16;
        v16 = 0l;
        while (while_method_0(v15, v16)){
            unsigned long long v18;
            v18 = (unsigned long long)v16;
            unsigned long long v19;
            v19 = v18 * 16ull;
            unsigned long long v20;
            v20 = 32ull + v19;
            unsigned char * v21;
            v21 = (unsigned char *)(v0+v20);
            long * v22;
            v22 = (long *)(v21+0ull);
            long v23;
            v23 = v22[0l];
            long * v24;
            v24 = (long *)(v21+4ull);
            long v25;
            v25 = v24[0l];
            US1 v31;
            switch (v25) {
                case 0: {
                    v31 = US1_0();
                    break;
                }
                case 1: {
                    unsigned long long * v28;
                    v28 = (unsigned long long *)(v21+8ull);
                    unsigned long long v29;
                    v29 = v28[0l];
                    v31 = US1_1(v29);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v32;
            v32 = 0l <= v16;
            bool v35;
            if (v32){
                long & v33 = v11;
                bool v34;
                v34 = v16 < v33;
                v35 = v34;
            } else {
                v35 = false;
            }
            bool v36;
            v36 = v35 == false;
            if (v36){
                assert("The set index needs to be in range." && v35);
            } else {
            }
            bool v38;
            if (v32){
                bool v37;
                v37 = v16 < 14l;
                v38 = v37;
            } else {
                v38 = false;
            }
            bool v39;
            v39 = v38 == false;
            if (v39){
                assert("The read index needs to be in range." && v38);
            } else {
            }
            v10.v[v16] = Tuple1(v23, v31);
            v16 += 1l ;
        }
        const char * v40;
        v40 = "%d";
        printf(v40,v7);
        const char * v41;
        v41 = "%s";
        const char * v42;
        v42 = ", ";
        printf(v41,v42);
        const char * v43;
        v43 = "%u";
        printf(v43,v9);
        printf(v41,v42);
        const char * v44;
        v44 = "[";
        printf(v41,v44);
        long & v45 = v11;
        bool v46;
        v46 = 100l < v45;
        long v47;
        if (v46){
            v47 = 100l;
        } else {
            v47 = v45;
        }
        long v48;
        v48 = 0l;
        while (while_method_0(v47, v48)){
            bool v50;
            v50 = 0l <= v48;
            bool v53;
            if (v50){
                long & v51 = v11;
                bool v52;
                v52 = v48 < v51;
                v53 = v52;
            } else {
                v53 = false;
            }
            bool v54;
            v54 = v53 == false;
            if (v54){
                assert("The read index needs to be in range." && v53);
            } else {
            }
            bool v56;
            if (v50){
                bool v55;
                v55 = v48 < 14l;
                v56 = v55;
            } else {
                v56 = false;
            }
            bool v57;
            v57 = v56 == false;
            if (v57){
                assert("The read index needs to be in range." && v56);
            } else {
            }
            long v58; US1 v59;
            Tuple1 tmp0 = v10.v[v48];
            v58 = tmp0.v0; v59 = tmp0.v1;
            printf(v40,v58);
            printf(v41,v42);
            switch (v59.tag) {
                case 0: { // None
                    const char * v60;
                    v60 = "None";
                    printf(v41,v60);
                    break;
                }
                default: { // Some
                    unsigned long long v61 = v59.v.case1.v0;
                    const char * v62;
                    v62 = "Some";
                    printf(v41,v62);
                    const char * v63;
                    v63 = "(";
                    printf(v41,v63);
                    printf(v43,v61);
                    const char * v64;
                    v64 = ")";
                    printf(v41,v64);
                }
            }
            long v65;
            v65 = v48 + 1l;
            long & v66 = v11;
            bool v67;
            v67 = v65 < v66;
            if (v67){
                const char * v68;
                v68 = "; ";
                printf(v41,v68);
            } else {
            }
            v48 += 1l ;
        }
        long & v69 = v11;
        bool v70;
        v70 = v69 > 100l;
        if (v70){
            const char * v71;
            v71 = "; ...";
            printf(v41,v71);
        } else {
        }
        const char * v72;
        v72 = "]";
        printf(v41,v72);
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
class US0_0(NamedTuple): # None
    tag = 0
class US0_1(NamedTuple): # Some
    v0 : u64
    tag = 1
US0 = Union[US0_0, US0_1]
def method0(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def main():
    v0 = cp.empty(256,dtype=cp.uint8)
    v1 = [None] * 14
    v2 = [0]
    v3 = v2[0]
    del v3
    v2[0] = 3
    v4 = v2[0]
    v5 = 0 < v4
    del v4
    v6 = v5 == False
    if v6:
        v7 = "The set index needs to be in range."
        assert v5, v7
        del v7
    else:
        pass
    del v5, v6
    v8 = US0_1(23)
    v1[0] = (1, v8)
    del v8
    v9 = v2[0]
    v10 = 1 < v9
    del v9
    v11 = v10 == False
    if v11:
        v12 = "The set index needs to be in range."
        assert v10, v12
        del v12
    else:
        pass
    del v10, v11
    v13 = US0_1(34)
    v1[1] = (2, v13)
    del v13
    v14 = v2[0]
    v15 = 2 < v14
    del v14
    v16 = v15 == False
    if v16:
        v17 = "The set index needs to be in range."
        assert v15, v17
        del v17
    else:
        pass
    del v15, v16
    v18 = US0_0()
    v1[2] = (3, v18)
    del v18
    v19 = v0[0:].view(cp.int16)
    v19[0] = -2
    del v19
    v20 = v0[8:].view(cp.uint64)
    v20[0] = 555555555
    del v20
    v21 = v2[0]
    v22 = v0[16:].view(cp.int32)
    v22[0] = v21
    del v21, v22
    v23 = v2[0]
    v24 = 0
    while method0(v23, v24):
        v26 = u64(v24)
        v27 = v26 * 16
        del v26
        v28 = 32 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v2[0]
            v32 = v24 < v31
            del v31
            v33 = v32
        else:
            v33 = False
        v34 = v33 == False
        if v34:
            v35 = "The read index needs to be in range."
            assert v33, v35
            del v35
        else:
            pass
        del v33, v34
        if v30:
            v36 = v24 < 14
            v37 = v36
        else:
            v37 = False
        del v30
        v38 = v37 == False
        if v38:
            v39 = "The read index needs to be in range."
            assert v37, v39
            del v39
        else:
            pass
        del v37, v38
        v40, v41 = v1[v24]
        v42 = v29[0:].view(cp.int32)
        v42[0] = v40
        del v40, v42
        v43 = v41.tag
        v44 = v29[4:].view(cp.int32)
        v44[0] = v43
        del v43, v44
        match v41:
            case US0_0(): # None
                pass
            case US0_1(v45): # Some
                v46 = v29[8:].view(cp.uint64)
                v46[0] = v45
                del v45, v46
        del v29, v41
        v24 += 1 
    del v1, v2, v23, v24
    v47 = v0[0:].view(cp.int16)
    v48 = v47[0].item()
    del v47
    v49 = v0[8:].view(cp.uint64)
    v50 = v49[0].item()
    del v49
    v51 = [None] * 14
    v52 = [0]
    v53 = v0[16:].view(cp.int32)
    v54 = v53[0].item()
    del v53
    v55 = v52[0]
    del v55
    v52[0] = v54
    del v54
    v56 = v52[0]
    v57 = 0
    while method0(v56, v57):
        v59 = u64(v57)
        v60 = v59 * 16
        del v59
        v61 = 32 + v60
        del v60
        v62 = v0[v61:].view(cp.uint8)
        del v61
        v63 = v62[0:].view(cp.int32)
        v64 = v63[0].item()
        del v63
        v65 = v62[4:].view(cp.int32)
        v66 = v65[0].item()
        del v65
        if v66 == 0:
            v72 = US0_0()
        elif v66 == 1:
            v69 = v62[8:].view(cp.uint64)
            v70 = v69[0].item()
            del v69
            v72 = US0_1(v70)
        else:
            raise Exception("Invalid tag.")
        del v62, v66
        v73 = 0 <= v57
        if v73:
            v74 = v52[0]
            v75 = v57 < v74
            del v74
            v76 = v75
        else:
            v76 = False
        v77 = v76 == False
        if v77:
            v78 = "The set index needs to be in range."
            assert v76, v78
            del v78
        else:
            pass
        del v76, v77
        if v73:
            v79 = v57 < 14
            v80 = v79
        else:
            v80 = False
        del v73
        v81 = v80 == False
        if v81:
            v82 = "The read index needs to be in range."
            assert v80, v82
            del v82
        else:
            pass
        del v80, v81
        v51[v57] = (v64, v72)
        del v64, v72
        v57 += 1 
    del v56, v57
    print(v48, end="")
    del v48
    v83 = ", "
    print(v83, end="")
    print(v50, end="")
    del v50
    print(v83, end="")
    v84 = "["
    print(v84, end="")
    del v84
    v85 = v52[0]
    v86 = 100 < v85
    if v86:
        v87 = 100
    else:
        v87 = v85
    del v85, v86
    v88 = 0
    while method0(v87, v88):
        v90 = 0 <= v88
        if v90:
            v91 = v52[0]
            v92 = v88 < v91
            del v91
            v93 = v92
        else:
            v93 = False
        v94 = v93 == False
        if v94:
            v95 = "The read index needs to be in range."
            assert v93, v95
            del v95
        else:
            pass
        del v93, v94
        if v90:
            v96 = v88 < 14
            v97 = v96
        else:
            v97 = False
        del v90
        v98 = v97 == False
        if v98:
            v99 = "The read index needs to be in range."
            assert v97, v99
            del v99
        else:
            pass
        del v97, v98
        v100, v101 = v51[v88]
        print(v100, end="")
        del v100
        print(v83, end="")
        match v101:
            case US0_0(): # None
                v102 = "None"
                print(v102, end="")
                del v102
            case US0_1(v103): # Some
                v104 = "Some"
                print(v104, end="")
                del v104
                v105 = "("
                print(v105, end="")
                del v105
                print(v103, end="")
                del v103
                v106 = ")"
                print(v106, end="")
                del v106
        del v101
        v107 = v88 + 1
        v108 = v52[0]
        v109 = v107 < v108
        del v107, v108
        if v109:
            v110 = "; "
            print(v110, end="")
            del v110
        else:
            pass
        del v109
        v88 += 1 
    del v51, v83, v87, v88
    v111 = v52[0]
    del v52
    v112 = v111 > 100
    del v111
    if v112:
        v113 = "; ..."
        print(v113, end="")
        del v113
    else:
        pass
    del v112
    v114 = "]"
    print(v114, end="")
    del v114
    print()
    v115 = 0
    v116 = raw_module.get_function(f"entry{v115}")
    del v115
    v116.max_dynamic_shared_size_bytes = 0 
    v116((1,),(512,),v0,shared_mem=0)
    del v0, v116
    return 

if __name__ == '__main__': print(main())
