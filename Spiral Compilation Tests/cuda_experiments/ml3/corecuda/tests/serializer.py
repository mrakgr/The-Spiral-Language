kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
struct US0;
struct US3;
struct US4;
struct US2;
struct US1;
struct Tuple0;
struct US0 {
    union {
        struct {
            unsigned long long v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US3 {
    union {
        struct {
            float v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US4 {
    union {
        struct {
            double v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US2 {
    union {
        struct {
            US3 v2;
            unsigned char v1;
            char v0;
        } case0; // Q
        struct {
            US4 v1;
            unsigned short v0;
        } case1; // W
    } v;
    unsigned long tag : 2;
};
struct US1 {
    union {
        struct {
            US2 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    US0 v1;
    US1 v2;
    long v0;
    __device__ Tuple0(long t0, US0 t1, US1 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple0() = default;
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
__device__ US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1(float v0) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1(double v0) { // Some
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US2 US2_0(char v0, unsigned char v1, US3 v2) { // Q
    US2 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2;
    return x;
}
__device__ US2 US2_1(unsigned short v0, US4 v1) { // W
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1(US2 v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_0(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
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
        static_array_list<Tuple0,14l,long> v6;
        v6.length = 0;
        v6.length = 3l;
        long v7;
        v7 = v6.length;
        bool v8;
        v8 = 0l < v7;
        bool v9;
        v9 = v8 == false;
        if (v9){
            assert("The set index needs to be in range." && v8);
        } else {
        }
        US0 v10;
        v10 = US0_1(23ull);
        US3 v11;
        v11 = US3_1(555.0f);
        US2 v12;
        v12 = US2_0(5, 55u, v11);
        US1 v13;
        v13 = US1_1(v12);
        v6.v[0l] = Tuple0(1l, v10, v13);
        long v14;
        v14 = v6.length;
        bool v15;
        v15 = 1l < v14;
        bool v16;
        v16 = v15 == false;
        if (v16){
            assert("The set index needs to be in range." && v15);
        } else {
        }
        US0 v17;
        v17 = US0_1(34ull);
        US4 v18;
        v18 = US4_1(222.222);
        US2 v19;
        v19 = US2_1(2u, v18);
        US1 v20;
        v20 = US1_1(v19);
        v6.v[1l] = Tuple0(2l, v17, v20);
        long v21;
        v21 = v6.length;
        bool v22;
        v22 = 2l < v21;
        bool v23;
        v23 = v22 == false;
        if (v23){
            assert("The set index needs to be in range." && v22);
        } else {
        }
        US0 v24;
        v24 = US0_0();
        US3 v25;
        v25 = US3_1(890.876f);
        US2 v26;
        v26 = US2_0(88, 80u, v25);
        US1 v27;
        v27 = US1_1(v26);
        v6.v[2l] = Tuple0(3l, v24, v27);
        short * v28;
        v28 = (short *)(v0+0ull);
        v28[0l] = -2;
        unsigned long long * v29;
        v29 = (unsigned long long *)(v0+8ull);
        v29[0l] = 555555555ull;
        long v30;
        v30 = v6.length;
        long * v31;
        v31 = (long *)(v0+16ull);
        v31[0l] = v30;
        long v32;
        v32 = v6.length;
        long v33;
        v33 = 0l;
        while (while_method_0(v32, v33)){
            unsigned long long v35;
            v35 = (unsigned long long)v33;
            unsigned long long v36;
            v36 = v35 * 48ull;
            unsigned long long v37;
            v37 = 32ull + v36;
            unsigned char * v38;
            v38 = (unsigned char *)(v0+v37);
            bool v39;
            v39 = 0l <= v33;
            bool v42;
            if (v39){
                long v40;
                v40 = v6.length;
                bool v41;
                v41 = v33 < v40;
                v42 = v41;
            } else {
                v42 = false;
            }
            bool v43;
            v43 = v42 == false;
            if (v43){
                assert("The read index needs to be in range." && v42);
            } else {
            }
            long v44; US0 v45; US1 v46;
            Tuple0 tmp0 = v6.v[v33];
            v44 = tmp0.v0; v45 = tmp0.v1; v46 = tmp0.v2;
            long * v47;
            v47 = (long *)(v38+0ull);
            v47[0l] = v44;
            long v48;
            v48 = v45.tag;
            long * v49;
            v49 = (long *)(v38+4ull);
            v49[0l] = v48;
            switch (v45.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    unsigned long long v50 = v45.v.case1.v0;
                    unsigned long long * v51;
                    v51 = (unsigned long long *)(v38+8ull);
                    v51[0l] = v50;
                }
            }
            long v52;
            v52 = v46.tag;
            long * v53;
            v53 = (long *)(v38+16ull);
            v53[0l] = v52;
            switch (v46.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    US2 v54 = v46.v.case1.v0;
                    long v55;
                    v55 = v54.tag;
                    long * v56;
                    v56 = (long *)(v38+20ull);
                    v56[0l] = v55;
                    switch (v54.tag) {
                        case 0: { // Q
                            char v57 = v54.v.case0.v0; unsigned char v58 = v54.v.case0.v1; US3 v59 = v54.v.case0.v2;
                            char * v60;
                            v60 = (char *)(v38+24ull);
                            v60[0l] = v57;
                            unsigned char * v61;
                            v61 = (unsigned char *)(v38+25ull);
                            v61[0l] = v58;
                            long v62;
                            v62 = v59.tag;
                            long * v63;
                            v63 = (long *)(v38+28ull);
                            v63[0l] = v62;
                            switch (v59.tag) {
                                case 0: { // None
                                    break;
                                }
                                default: { // Some
                                    float v64 = v59.v.case1.v0;
                                    float * v65;
                                    v65 = (float *)(v38+32ull);
                                    v65[0l] = v64;
                                }
                            }
                            break;
                        }
                        default: { // W
                            unsigned short v66 = v54.v.case1.v0; US4 v67 = v54.v.case1.v1;
                            unsigned short * v68;
                            v68 = (unsigned short *)(v38+24ull);
                            v68[0l] = v66;
                            long v69;
                            v69 = v67.tag;
                            long * v70;
                            v70 = (long *)(v38+28ull);
                            v70[0l] = v69;
                            switch (v67.tag) {
                                case 0: { // None
                                    break;
                                }
                                default: { // Some
                                    double v71 = v67.v.case1.v0;
                                    double * v72;
                                    v72 = (double *)(v38+32ull);
                                    v72[0l] = v71;
                                }
                            }
                        }
                    }
                }
            }
            v33 += 1l ;
        }
        unsigned short * v73;
        v73 = (unsigned short *)(v0+704ull);
        v73[0l] = 3412u;
        short * v74;
        v74 = (short *)(v0+0ull);
        short v75;
        v75 = v74[0l];
        unsigned long long * v76;
        v76 = (unsigned long long *)(v0+8ull);
        unsigned long long v77;
        v77 = v76[0l];
        static_array_list<Tuple0,14l,long> v78;
        v78.length = 0;
        long * v79;
        v79 = (long *)(v0+16ull);
        long v80;
        v80 = v79[0l];
        v78.length = v80;
        long v81;
        v81 = v78.length;
        long v82;
        v82 = 0l;
        while (while_method_0(v81, v82)){
            unsigned long long v84;
            v84 = (unsigned long long)v82;
            unsigned long long v85;
            v85 = v84 * 48ull;
            unsigned long long v86;
            v86 = 32ull + v85;
            unsigned char * v87;
            v87 = (unsigned char *)(v0+v86);
            long * v88;
            v88 = (long *)(v87+0ull);
            long v89;
            v89 = v88[0l];
            long * v90;
            v90 = (long *)(v87+4ull);
            long v91;
            v91 = v90[0l];
            US0 v97;
            switch (v91) {
                case 0: {
                    v97 = US0_0();
                    break;
                }
                case 1: {
                    unsigned long long * v94;
                    v94 = (unsigned long long *)(v87+8ull);
                    unsigned long long v95;
                    v95 = v94[0l];
                    v97 = US0_1(v95);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            long * v98;
            v98 = (long *)(v87+16ull);
            long v99;
            v99 = v98[0l];
            US1 v131;
            switch (v99) {
                case 0: {
                    v131 = US1_0();
                    break;
                }
                case 1: {
                    long * v102;
                    v102 = (long *)(v87+20ull);
                    long v103;
                    v103 = v102[0l];
                    US2 v129;
                    switch (v103) {
                        case 0: {
                            char * v105;
                            v105 = (char *)(v87+24ull);
                            char v106;
                            v106 = v105[0l];
                            unsigned char * v107;
                            v107 = (unsigned char *)(v87+25ull);
                            unsigned char v108;
                            v108 = v107[0l];
                            long * v109;
                            v109 = (long *)(v87+28ull);
                            long v110;
                            v110 = v109[0l];
                            US3 v116;
                            switch (v110) {
                                case 0: {
                                    v116 = US3_0();
                                    break;
                                }
                                case 1: {
                                    float * v113;
                                    v113 = (float *)(v87+32ull);
                                    float v114;
                                    v114 = v113[0l];
                                    v116 = US3_1(v114);
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v129 = US2_0(v106, v108, v116);
                            break;
                        }
                        case 1: {
                            unsigned short * v118;
                            v118 = (unsigned short *)(v87+24ull);
                            unsigned short v119;
                            v119 = v118[0l];
                            long * v120;
                            v120 = (long *)(v87+28ull);
                            long v121;
                            v121 = v120[0l];
                            US4 v127;
                            switch (v121) {
                                case 0: {
                                    v127 = US4_0();
                                    break;
                                }
                                case 1: {
                                    double * v124;
                                    v124 = (double *)(v87+32ull);
                                    double v125;
                                    v125 = v124[0l];
                                    v127 = US4_1(v125);
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v129 = US2_1(v119, v127);
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v131 = US1_1(v129);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v132;
            v132 = 0l <= v82;
            bool v135;
            if (v132){
                long v133;
                v133 = v78.length;
                bool v134;
                v134 = v82 < v133;
                v135 = v134;
            } else {
                v135 = false;
            }
            bool v136;
            v136 = v135 == false;
            if (v136){
                assert("The set index needs to be in range." && v135);
            } else {
            }
            v78.v[v82] = Tuple0(v89, v97, v131);
            v82 += 1l ;
        }
        unsigned short * v137;
        v137 = (unsigned short *)(v0+704ull);
        unsigned short v138;
        v138 = v137[0l];
        const char * v139;
        v139 = "%d";
        printf(v139,v75);
        const char * v140;
        v140 = "%s";
        const char * v141;
        v141 = ", ";
        printf(v140,v141);
        const char * v142;
        v142 = "%u";
        printf(v142,v77);
        printf(v140,v141);
        const char * v143;
        v143 = "[";
        printf(v140,v143);
        long v144;
        v144 = v78.length;
        bool v145;
        v145 = 100l < v144;
        long v146;
        if (v145){
            v146 = 100l;
        } else {
            v146 = v144;
        }
        long v147;
        v147 = 0l;
        while (while_method_0(v146, v147)){
            bool v149;
            v149 = 0l <= v147;
            bool v152;
            if (v149){
                long v150;
                v150 = v78.length;
                bool v151;
                v151 = v147 < v150;
                v152 = v151;
            } else {
                v152 = false;
            }
            bool v153;
            v153 = v152 == false;
            if (v153){
                assert("The read index needs to be in range." && v152);
            } else {
            }
            long v154; US0 v155; US1 v156;
            Tuple0 tmp1 = v78.v[v147];
            v154 = tmp1.v0; v155 = tmp1.v1; v156 = tmp1.v2;
            printf(v139,v154);
            printf(v140,v141);
            switch (v155.tag) {
                case 0: { // None
                    const char * v157;
                    v157 = "None";
                    printf(v140,v157);
                    break;
                }
                default: { // Some
                    unsigned long long v158 = v155.v.case1.v0;
                    const char * v159;
                    v159 = "Some";
                    printf(v140,v159);
                    const char * v160;
                    v160 = "(";
                    printf(v140,v160);
                    printf(v142,v158);
                    const char * v161;
                    v161 = ")";
                    printf(v140,v161);
                }
            }
            printf(v140,v141);
            switch (v156.tag) {
                case 0: { // None
                    const char * v162;
                    v162 = "None";
                    printf(v140,v162);
                    break;
                }
                default: { // Some
                    US2 v163 = v156.v.case1.v0;
                    const char * v164;
                    v164 = "Some";
                    printf(v140,v164);
                    const char * v165;
                    v165 = "(";
                    printf(v140,v165);
                    switch (v163.tag) {
                        case 0: { // Q
                            char v166 = v163.v.case0.v0; unsigned char v167 = v163.v.case0.v1; US3 v168 = v163.v.case0.v2;
                            const char * v169;
                            v169 = "Q";
                            printf(v140,v169);
                            printf(v140,v165);
                            printf(v139,v166);
                            printf(v140,v141);
                            printf(v142,v167);
                            printf(v140,v141);
                            switch (v168.tag) {
                                case 0: { // None
                                    const char * v170;
                                    v170 = "None";
                                    printf(v140,v170);
                                    break;
                                }
                                default: { // Some
                                    float v171 = v168.v.case1.v0;
                                    printf(v140,v164);
                                    printf(v140,v165);
                                    const char * v172;
                                    v172 = "%f";
                                    printf(v172,v171);
                                    const char * v173;
                                    v173 = ")";
                                    printf(v140,v173);
                                }
                            }
                            const char * v174;
                            v174 = ")";
                            printf(v140,v174);
                            break;
                        }
                        default: { // W
                            unsigned short v175 = v163.v.case1.v0; US4 v176 = v163.v.case1.v1;
                            const char * v177;
                            v177 = "W";
                            printf(v140,v177);
                            printf(v140,v165);
                            printf(v142,v175);
                            printf(v140,v141);
                            switch (v176.tag) {
                                case 0: { // None
                                    const char * v178;
                                    v178 = "None";
                                    printf(v140,v178);
                                    break;
                                }
                                default: { // Some
                                    double v179 = v176.v.case1.v0;
                                    printf(v140,v164);
                                    printf(v140,v165);
                                    const char * v180;
                                    v180 = "%f";
                                    printf(v180,v179);
                                    const char * v181;
                                    v181 = ")";
                                    printf(v140,v181);
                                }
                            }
                            const char * v182;
                            v182 = ")";
                            printf(v140,v182);
                        }
                    }
                    const char * v183;
                    v183 = ")";
                    printf(v140,v183);
                }
            }
            long v184;
            v184 = v147 + 1l;
            long v185;
            v185 = v78.length;
            bool v186;
            v186 = v184 < v185;
            if (v186){
                const char * v187;
                v187 = "; ";
                printf(v140,v187);
            } else {
            }
            v147 += 1l ;
        }
        long v188;
        v188 = v78.length;
        bool v189;
        v189 = v188 > 100l;
        if (v189){
            const char * v190;
            v190 = "; ...";
            printf(v140,v190);
        } else {
        }
        const char * v191;
        v191 = "]";
        printf(v140,v191);
        printf(v140,v141);
        printf(v142,v138);
        printf("\n");
        return ;
    } else {
        return ;
    }
}
"""
class static_array(list):
    def __init__(self, length):
        for _ in range(length):
            self.append(None)

class static_array_list(static_array):
    def __init__(self, length):
        super().__init__(length)
        self.length = length
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
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : f32
    tag = 1
US3 = Union[US3_0, US3_1]
class US4_0(NamedTuple): # None
    tag = 0
class US4_1(NamedTuple): # Some
    v0 : f64
    tag = 1
US4 = Union[US4_0, US4_1]
class US2_0(NamedTuple): # Q
    v0 : i8
    v1 : u8
    v2 : US3
    tag = 0
class US2_1(NamedTuple): # W
    v0 : u16
    v1 : US4
    tag = 1
US2 = Union[US2_0, US2_1]
class US1_0(NamedTuple): # None
    tag = 0
class US1_1(NamedTuple): # Some
    v0 : US2
    tag = 1
US1 = Union[US1_0, US1_1]
def method0(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def main():
    v0 = cp.empty(720,dtype=cp.uint8)
    v1 = 0
    v2 = raw_module.get_function(f"entry{v1}")
    del v1
    v2.max_dynamic_shared_size_bytes = 0 
    v2((1,),(512,),v0,shared_mem=0)
    del v2
    v3 = v0[0:].view(cp.int16)
    v4 = v3[0].item()
    del v3
    v5 = v0[8:].view(cp.uint64)
    v6 = v5[0].item()
    del v5
    v7 = static_array_list(14)
    v8 = v0[16:].view(cp.int32)
    v9 = v8[0].item()
    del v8
    v7.length = v9
    del v9
    v10 = v7.length
    v11 = 0
    while method0(v10, v11):
        v13 = u64(v11)
        v14 = v13 * 48
        del v13
        v15 = 32 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = v16[0:].view(cp.int32)
        v18 = v17[0].item()
        del v17
        v19 = v16[4:].view(cp.int32)
        v20 = v19[0].item()
        del v19
        if v20 == 0:
            v26 = US0_0()
        elif v20 == 1:
            v23 = v16[8:].view(cp.uint64)
            v24 = v23[0].item()
            del v23
            v26 = US0_1(v24)
        else:
            raise Exception("Invalid tag.")
        del v20
        v27 = v16[16:].view(cp.int32)
        v28 = v27[0].item()
        del v27
        if v28 == 0:
            v60 = US1_0()
        elif v28 == 1:
            v31 = v16[20:].view(cp.int32)
            v32 = v31[0].item()
            del v31
            if v32 == 0:
                v34 = v16[24:].view(cp.int8)
                v35 = v34[0].item()
                del v34
                v36 = v16[25:].view(cp.uint8)
                v37 = v36[0].item()
                del v36
                v38 = v16[28:].view(cp.int32)
                v39 = v38[0].item()
                del v38
                if v39 == 0:
                    v45 = US3_0()
                elif v39 == 1:
                    v42 = v16[32:].view(cp.float32)
                    v43 = v42[0].item()
                    del v42
                    v45 = US3_1(v43)
                else:
                    raise Exception("Invalid tag.")
                del v39
                v58 = US2_0(v35, v37, v45)
            elif v32 == 1:
                v47 = v16[24:].view(cp.uint16)
                v48 = v47[0].item()
                del v47
                v49 = v16[28:].view(cp.int32)
                v50 = v49[0].item()
                del v49
                if v50 == 0:
                    v56 = US4_0()
                elif v50 == 1:
                    v53 = v16[32:].view(cp.float64)
                    v54 = v53[0].item()
                    del v53
                    v56 = US4_1(v54)
                else:
                    raise Exception("Invalid tag.")
                del v50
                v58 = US2_1(v48, v56)
            else:
                raise Exception("Invalid tag.")
            del v32
            v60 = US1_1(v58)
        else:
            raise Exception("Invalid tag.")
        del v16, v28
        v61 = 0 <= v11
        if v61:
            v62 = v7.length
            v63 = v11 < v62
            del v62
            v64 = v63
        else:
            v64 = False
        del v61
        v65 = v64 == False
        if v65:
            v66 = "The set index needs to be in range."
            assert v64, v66
            del v66
        else:
            pass
        del v64, v65
        v7[v11] = (v18, v26, v60)
        del v18, v26, v60
        v11 += 1 
    del v10, v11
    v67 = v0[704:].view(cp.uint16)
    del v0
    v68 = v67[0].item()
    del v67
    print(v4, end="")
    del v4
    v69 = ", "
    print(v69, end="")
    print(v6, end="")
    del v6
    print(v69, end="")
    v70 = "["
    print(v70, end="")
    del v70
    v71 = v7.length
    v72 = 100 < v71
    if v72:
        v73 = 100
    else:
        v73 = v71
    del v71, v72
    v74 = 0
    while method0(v73, v74):
        v76 = 0 <= v74
        if v76:
            v77 = v7.length
            v78 = v74 < v77
            del v77
            v79 = v78
        else:
            v79 = False
        del v76
        v80 = v79 == False
        if v80:
            v81 = "The read index needs to be in range."
            assert v79, v81
            del v81
        else:
            pass
        del v79, v80
        v82, v83, v84 = v7[v74]
        print(v82, end="")
        del v82
        print(v69, end="")
        match v83:
            case US0_0(): # None
                v85 = "None"
                print(v85, end="")
                del v85
            case US0_1(v86): # Some
                v87 = "Some"
                print(v87, end="")
                del v87
                v88 = "("
                print(v88, end="")
                del v88
                print(v86, end="")
                del v86
                v89 = ")"
                print(v89, end="")
                del v89
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v83
        print(v69, end="")
        match v84:
            case US1_0(): # None
                v90 = "None"
                print(v90, end="")
                del v90
            case US1_1(v91): # Some
                v92 = "Some"
                print(v92, end="")
                v93 = "("
                print(v93, end="")
                match v91:
                    case US2_0(v94, v95, v96): # Q
                        v97 = "Q"
                        print(v97, end="")
                        del v97
                        print(v93, end="")
                        print(v94, end="")
                        del v94
                        print(v69, end="")
                        print(v95, end="")
                        del v95
                        print(v69, end="")
                        match v96:
                            case US3_0(): # None
                                v98 = "None"
                                print(v98, end="")
                                del v98
                            case US3_1(v99): # Some
                                print(v92, end="")
                                print(v93, end="")
                                print("{:.6f}".format(v99), end="")
                                del v99
                                v100 = ")"
                                print(v100, end="")
                                del v100
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v96
                        v101 = ")"
                        print(v101, end="")
                        del v101
                    case US2_1(v102, v103): # W
                        v104 = "W"
                        print(v104, end="")
                        del v104
                        print(v93, end="")
                        print(v102, end="")
                        del v102
                        print(v69, end="")
                        match v103:
                            case US4_0(): # None
                                v105 = "None"
                                print(v105, end="")
                                del v105
                            case US4_1(v106): # Some
                                print(v92, end="")
                                print(v93, end="")
                                print("{:.6f}".format(v106), end="")
                                del v106
                                v107 = ")"
                                print(v107, end="")
                                del v107
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v103
                        v108 = ")"
                        print(v108, end="")
                        del v108
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v91, v92, v93
                v109 = ")"
                print(v109, end="")
                del v109
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v84
        v110 = v74 + 1
        v111 = v7.length
        v112 = v110 < v111
        del v110, v111
        if v112:
            v113 = "; "
            print(v113, end="")
            del v113
        else:
            pass
        del v112
        v74 += 1 
    del v73, v74
    v114 = v7.length
    del v7
    v115 = v114 > 100
    del v114
    if v115:
        v116 = "; ..."
        print(v116, end="")
        del v116
    else:
        pass
    del v115
    v117 = "]"
    print(v117, end="")
    del v117
    print(v69, end="")
    del v69
    print(v68, end="")
    del v68
    print()
    return 

if __name__ == '__main__': print(main())
