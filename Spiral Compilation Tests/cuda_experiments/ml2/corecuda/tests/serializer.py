kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
struct US0;
struct US0 {
    union {
        struct {
            long v0;
        } case0; // A
        struct {
            long v2;
            char v1;
            char v0;
        } case1; // B
    } v;
    unsigned long tag : 2;
};
__device__ US0 US0_0(long v0) { // A
    US0 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US0 US0_1(char v0, char v1, long v2) { // B
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2;
    return x;
}
__device__ US0 US0_2() { // C
    US0 x;
    x.tag = 2;
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
        char * v8;
        char * v6;
        v6 = (char *)(v0+0ull);
        v8 = v6;
        v8[0l] = 1;
        char * v11;
        char * v9;
        v9 = (char *)(v0+1ull);
        v11 = v9;
        v11[0l] = 2;
        long * v14;
        long * v12;
        v12 = (long *)(v0+4ull);
        v14 = v12;
        v14[0l] = 4l;
        long * v17;
        long * v15;
        v15 = (long *)(v0+8ull);
        v17 = v15;
        v17[0l] = 2l;
        float * v20;
        float * v18;
        v18 = (float *)(v0+20ull);
        v20 = v18;
        v20[0l] = 234.5f;
        double * v23;
        double * v21;
        v21 = (double *)(v0+24ull);
        v23 = v21;
        v23[0l] = 12.0;
        char * v26;
        char * v24;
        v24 = (char *)(v0+0ull);
        v26 = v24;
        char v27;
        v27 = v26[0l];
        char * v30;
        char * v28;
        v28 = (char *)(v0+1ull);
        v30 = v28;
        char v31;
        v31 = v30[0l];
        long * v34;
        long * v32;
        v32 = (long *)(v0+4ull);
        v34 = v32;
        long v35;
        v35 = v34[0l];
        long * v38;
        long * v36;
        v36 = (long *)(v0+8ull);
        v38 = v36;
        long v39;
        v39 = v38[0l];
        US0 v60;
        switch (v39) {
            case 0: {
                long * v43;
                long * v41;
                v41 = (long *)(v0+12ull);
                v43 = v41;
                long v44;
                v44 = v43[0l];
                v60 = US0_0(v44);
                break;
            }
            case 1: {
                char * v48;
                char * v46;
                v46 = (char *)(v0+12ull);
                v48 = v46;
                char v49;
                v49 = v48[0l];
                char * v52;
                char * v50;
                v50 = (char *)(v0+13ull);
                v52 = v50;
                char v53;
                v53 = v52[0l];
                long * v56;
                long * v54;
                v54 = (long *)(v0+16ull);
                v56 = v54;
                long v57;
                v57 = v56[0l];
                v60 = US0_1(v49, v53, v57);
                break;
            }
            case 2: {
                v60 = US0_2();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        float * v63;
        float * v61;
        v61 = (float *)(v0+20ull);
        v63 = v61;
        float v64;
        v64 = v63[0l];
        double * v67;
        double * v65;
        v65 = (double *)(v0+24ull);
        v67 = v65;
        double v68;
        v68 = v67[0l];
        const char * v69;
        v69 = "%d";
        printf(v69,v27);
        const char * v70;
        v70 = "%s";
        const char * v71;
        v71 = ", ";
        printf(v70,v71);
        const char * v73;
        v73 = "%d";
        printf(v73,v31);
        const char * v74;
        v74 = "%s";
        const char * v75;
        v75 = ", ";
        printf(v74,v75);
        const char * v77;
        v77 = "%d";
        printf(v77,v35);
        const char * v78;
        v78 = "%s";
        const char * v79;
        v79 = ", ";
        printf(v78,v79);
        switch (v60.tag) {
            case 0: { // A
                long v81 = v60.v.case0.v0;
                const char * v82;
                v82 = "%s";
                const char * v83;
                v83 = "A";
                printf(v82,v83);
                const char * v85;
                v85 = "%s";
                const char * v86;
                v86 = "(";
                printf(v85,v86);
                const char * v88;
                v88 = "%d";
                printf(v88,v81);
                const char * v89;
                v89 = "%s";
                const char * v90;
                v90 = ")";
                printf(v89,v90);
                break;
            }
            case 1: { // B
                char v92 = v60.v.case1.v0; char v93 = v60.v.case1.v1; long v94 = v60.v.case1.v2;
                const char * v95;
                v95 = "%s";
                const char * v96;
                v96 = "B";
                printf(v95,v96);
                const char * v98;
                v98 = "%s";
                const char * v99;
                v99 = "(";
                printf(v98,v99);
                const char * v101;
                v101 = "%d";
                printf(v101,v92);
                const char * v102;
                v102 = "%s";
                const char * v103;
                v103 = ", ";
                printf(v102,v103);
                const char * v105;
                v105 = "%d";
                printf(v105,v93);
                const char * v106;
                v106 = "%s";
                const char * v107;
                v107 = ", ";
                printf(v106,v107);
                const char * v109;
                v109 = "%d";
                printf(v109,v94);
                const char * v110;
                v110 = "%s";
                const char * v111;
                v111 = ")";
                printf(v110,v111);
                break;
            }
            default: { // C
                const char * v113;
                v113 = "%s";
                const char * v114;
                v114 = "C";
                printf(v113,v114);
            }
        }
        const char * v116;
        v116 = "%s";
        const char * v117;
        v117 = ", ";
        printf(v116,v117);
        const char * v119;
        v119 = "%c";
        printf(v119,'{');
        const char * v120;
        v120 = "%s";
        const char * v121;
        v121 = "a";
        printf(v120,v121);
        const char * v123;
        v123 = "%s";
        const char * v124;
        v124 = " = ";
        printf(v123,v124);
        const char * v126;
        v126 = "%s";
        const char * v127;
        v127 = "hello";
        printf(v126,v127);
        const char * v129;
        v129 = "%s";
        const char * v130;
        v130 = "; ";
        printf(v129,v130);
        const char * v132;
        v132 = "%s";
        const char * v133;
        v133 = "b";
        printf(v132,v133);
        const char * v135;
        v135 = "%s";
        const char * v136;
        v136 = " = ";
        printf(v135,v136);
        const char * v138;
        v138 = "%f";
        printf(v138,v64);
        const char * v139;
        v139 = "%s";
        const char * v140;
        v140 = "; ";
        printf(v139,v140);
        const char * v142;
        v142 = "%s";
        const char * v143;
        v143 = "c";
        printf(v142,v143);
        const char * v145;
        v145 = "%s";
        const char * v146;
        v146 = " = ";
        printf(v145,v146);
        const char * v148;
        v148 = "%f";
        printf(v148,v68);
        const char * v149;
        v149 = "%c";
        printf(v149,'}');
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
class US0_0(NamedTuple): # A
    v0 : i32
    tag = 0
class US0_1(NamedTuple): # B
    v0 : i8
    v1 : i8
    v2 : i32
    tag = 1
class US0_2(NamedTuple): # C
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
def main():
    v0 = cp.empty(32,dtype=cp.uint8)
    v1 = 0
    v2 = raw_module.get_function(f"entry{v1}")
    del v1
    v2.max_dynamic_shared_size_bytes = 0 
    v2((1,),(512,),v0,shared_mem=0)
    del v2
    v4 = v0[0:].view(cp.int8)
    v5 = v4
    v6 = v5[0].item()
    del v5
    v8 = v0[1:].view(cp.int8)
    v9 = v8
    v10 = v9[0].item()
    del v9
    v12 = v0[4:].view(cp.int32)
    v13 = v12
    v14 = v13[0].item()
    del v13
    v16 = v0[8:].view(cp.int32)
    v17 = v16
    v18 = v17[0].item()
    del v17
    if v18 == 0:
        v21 = v0[12:].view(cp.int32)
        v22 = v21
        v23 = v22[0].item()
        del v22
        v39 = US0_0(v23)
    elif v18 == 1:
        v26 = v0[12:].view(cp.int8)
        v27 = v26
        v28 = v27[0].item()
        del v27
        v30 = v0[13:].view(cp.int8)
        v31 = v30
        v32 = v31[0].item()
        del v31
        v34 = v0[16:].view(cp.int32)
        v35 = v34
        v36 = v35[0].item()
        del v35
        v39 = US0_1(v28, v32, v36)
    elif v18 == 2:
        v39 = US0_2()
    else:
        raise Exception("Invalid tag.")
    del v18
    v41 = v0[20:].view(cp.float32)
    v42 = v41
    v43 = v42[0].item()
    del v42
    v45 = v0[24:].view(cp.float64)
    v46 = v45
    del v0
    v47 = v46[0].item()
    del v46
    print(v6, end="")
    del v6
    v51 = ", "
    print(v51, end="")
    del v51
    print(v10, end="")
    del v10
    v55 = ", "
    print(v55, end="")
    del v55
    print(v14, end="")
    del v14
    v59 = ", "
    print(v59, end="")
    del v59
    match v39:
        case US0_0(v60): # A
            v63 = "A"
            print(v63, end="")
            del v63
            v66 = "("
            print(v66, end="")
            del v66
            print(v60, end="")
            del v60
            v70 = ")"
            print(v70, end="")
            del v70
        case US0_1(v71, v72, v73): # B
            v76 = "B"
            print(v76, end="")
            del v76
            v79 = "("
            print(v79, end="")
            del v79
            print(v71, end="")
            del v71
            v83 = ", "
            print(v83, end="")
            del v83
            print(v72, end="")
            del v72
            v87 = ", "
            print(v87, end="")
            del v87
            print(v73, end="")
            del v73
            v91 = ")"
            print(v91, end="")
            del v91
        case US0_2(): # C
            v94 = "C"
            print(v94, end="")
            del v94
    del v39
    v97 = ", "
    print(v97, end="")
    del v97
    print('{', end="")
    v101 = "a"
    print(v101, end="")
    del v101
    v104 = " = "
    print(v104, end="")
    del v104
    v107 = "hello"
    print(v107, end="")
    del v107
    v110 = "; "
    print(v110, end="")
    del v110
    v113 = "b"
    print(v113, end="")
    del v113
    v116 = " = "
    print(v116, end="")
    del v116
    print("{:.6f}".format(v43), end="")
    del v43
    v120 = "; "
    print(v120, end="")
    del v120
    v123 = "c"
    print(v123, end="")
    del v123
    v126 = " = "
    print(v126, end="")
    del v126
    print("{:.6f}".format(v47), end="")
    del v47
    print('}', end="")
    print()
    return 

if __name__ == '__main__': print(main())
