kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
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
        array<Tuple0,14l> v6;
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
        US0 v12;
        v12 = US0_1(23ull);
        US3 v13;
        v13 = US3_1(555.0f);
        US2 v14;
        v14 = US2_0(5, 55u, v13);
        US1 v15;
        v15 = US1_1(v14);
        v6.v[0l] = Tuple0(1l, v12, v15);
        long & v16 = v7;
        bool v17;
        v17 = 1l < v16;
        bool v18;
        v18 = v17 == false;
        if (v18){
            assert("The set index needs to be in range." && v17);
        } else {
        }
        US0 v19;
        v19 = US0_1(34ull);
        US4 v20;
        v20 = US4_1(222.222);
        US2 v21;
        v21 = US2_1(2u, v20);
        US1 v22;
        v22 = US1_1(v21);
        v6.v[1l] = Tuple0(2l, v19, v22);
        long & v23 = v7;
        bool v24;
        v24 = 2l < v23;
        bool v25;
        v25 = v24 == false;
        if (v25){
            assert("The set index needs to be in range." && v24);
        } else {
        }
        US0 v26;
        v26 = US0_0();
        US3 v27;
        v27 = US3_1(890.876f);
        US2 v28;
        v28 = US2_0(88, 80u, v27);
        US1 v29;
        v29 = US1_1(v28);
        v6.v[2l] = Tuple0(3l, v26, v29);
        short * v30;
        v30 = (short *)(v0+0ull);
        v30[0l] = -2;
        unsigned long long * v31;
        v31 = (unsigned long long *)(v0+8ull);
        v31[0l] = 555555555ull;
        long & v32 = v7;
        long * v33;
        v33 = (long *)(v0+16ull);
        v33[0l] = v32;
        long & v34 = v7;
        long v35;
        v35 = 0l;
        while (while_method_0(v34, v35)){
            unsigned long long v37;
            v37 = (unsigned long long)v35;
            unsigned long long v38;
            v38 = v37 * 48ull;
            unsigned long long v39;
            v39 = 32ull + v38;
            unsigned char * v40;
            v40 = (unsigned char *)(v0+v39);
            bool v41;
            v41 = 0l <= v35;
            bool v44;
            if (v41){
                long & v42 = v7;
                bool v43;
                v43 = v35 < v42;
                v44 = v43;
            } else {
                v44 = false;
            }
            bool v45;
            v45 = v44 == false;
            if (v45){
                assert("The read index needs to be in range." && v44);
            } else {
            }
            bool v47;
            if (v41){
                bool v46;
                v46 = v35 < 14l;
                v47 = v46;
            } else {
                v47 = false;
            }
            bool v48;
            v48 = v47 == false;
            if (v48){
                assert("The read index needs to be in range." && v47);
            } else {
            }
            long v49; US0 v50; US1 v51;
            Tuple0 tmp0 = v6.v[v35];
            v49 = tmp0.v0; v50 = tmp0.v1; v51 = tmp0.v2;
            long * v52;
            v52 = (long *)(v40+0ull);
            v52[0l] = v49;
            long v53;
            v53 = v50.tag;
            long * v54;
            v54 = (long *)(v40+4ull);
            v54[0l] = v53;
            switch (v50.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    unsigned long long v55 = v50.v.case1.v0;
                    unsigned long long * v56;
                    v56 = (unsigned long long *)(v40+8ull);
                    v56[0l] = v55;
                }
            }
            long v57;
            v57 = v51.tag;
            long * v58;
            v58 = (long *)(v40+16ull);
            v58[0l] = v57;
            switch (v51.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    US2 v59 = v51.v.case1.v0;
                    long v60;
                    v60 = v59.tag;
                    long * v61;
                    v61 = (long *)(v40+20ull);
                    v61[0l] = v60;
                    switch (v59.tag) {
                        case 0: { // Q
                            char v62 = v59.v.case0.v0; unsigned char v63 = v59.v.case0.v1; US3 v64 = v59.v.case0.v2;
                            char * v65;
                            v65 = (char *)(v40+24ull);
                            v65[0l] = v62;
                            unsigned char * v66;
                            v66 = (unsigned char *)(v40+25ull);
                            v66[0l] = v63;
                            long v67;
                            v67 = v64.tag;
                            long * v68;
                            v68 = (long *)(v40+28ull);
                            v68[0l] = v67;
                            switch (v64.tag) {
                                case 0: { // None
                                    break;
                                }
                                default: { // Some
                                    float v69 = v64.v.case1.v0;
                                    float * v70;
                                    v70 = (float *)(v40+32ull);
                                    v70[0l] = v69;
                                }
                            }
                            break;
                        }
                        default: { // W
                            unsigned short v71 = v59.v.case1.v0; US4 v72 = v59.v.case1.v1;
                            unsigned short * v73;
                            v73 = (unsigned short *)(v40+24ull);
                            v73[0l] = v71;
                            long v74;
                            v74 = v72.tag;
                            long * v75;
                            v75 = (long *)(v40+28ull);
                            v75[0l] = v74;
                            switch (v72.tag) {
                                case 0: { // None
                                    break;
                                }
                                default: { // Some
                                    double v76 = v72.v.case1.v0;
                                    double * v77;
                                    v77 = (double *)(v40+32ull);
                                    v77[0l] = v76;
                                }
                            }
                        }
                    }
                }
            }
            v35 += 1l ;
        }
        unsigned short * v78;
        v78 = (unsigned short *)(v0+704ull);
        v78[0l] = 3412u;
        short * v79;
        v79 = (short *)(v0+0ull);
        short v80;
        v80 = v79[0l];
        unsigned long long * v81;
        v81 = (unsigned long long *)(v0+8ull);
        unsigned long long v82;
        v82 = v81[0l];
        array<Tuple0,14l> v83;
        long v84 = 0l;
        long * v85;
        v85 = (long *)(v0+16ull);
        long v86;
        v86 = v85[0l];
        long & v87 = v84;
        v84 = v86;
        long & v88 = v84;
        long v89;
        v89 = 0l;
        while (while_method_0(v88, v89)){
            unsigned long long v91;
            v91 = (unsigned long long)v89;
            unsigned long long v92;
            v92 = v91 * 48ull;
            unsigned long long v93;
            v93 = 32ull + v92;
            unsigned char * v94;
            v94 = (unsigned char *)(v0+v93);
            long * v95;
            v95 = (long *)(v94+0ull);
            long v96;
            v96 = v95[0l];
            long * v97;
            v97 = (long *)(v94+4ull);
            long v98;
            v98 = v97[0l];
            US0 v104;
            switch (v98) {
                case 0: {
                    v104 = US0_0();
                    break;
                }
                case 1: {
                    unsigned long long * v101;
                    v101 = (unsigned long long *)(v94+8ull);
                    unsigned long long v102;
                    v102 = v101[0l];
                    v104 = US0_1(v102);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            long * v105;
            v105 = (long *)(v94+16ull);
            long v106;
            v106 = v105[0l];
            US1 v138;
            switch (v106) {
                case 0: {
                    v138 = US1_0();
                    break;
                }
                case 1: {
                    long * v109;
                    v109 = (long *)(v94+20ull);
                    long v110;
                    v110 = v109[0l];
                    US2 v136;
                    switch (v110) {
                        case 0: {
                            char * v112;
                            v112 = (char *)(v94+24ull);
                            char v113;
                            v113 = v112[0l];
                            unsigned char * v114;
                            v114 = (unsigned char *)(v94+25ull);
                            unsigned char v115;
                            v115 = v114[0l];
                            long * v116;
                            v116 = (long *)(v94+28ull);
                            long v117;
                            v117 = v116[0l];
                            US3 v123;
                            switch (v117) {
                                case 0: {
                                    v123 = US3_0();
                                    break;
                                }
                                case 1: {
                                    float * v120;
                                    v120 = (float *)(v94+32ull);
                                    float v121;
                                    v121 = v120[0l];
                                    v123 = US3_1(v121);
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v136 = US2_0(v113, v115, v123);
                            break;
                        }
                        case 1: {
                            unsigned short * v125;
                            v125 = (unsigned short *)(v94+24ull);
                            unsigned short v126;
                            v126 = v125[0l];
                            long * v127;
                            v127 = (long *)(v94+28ull);
                            long v128;
                            v128 = v127[0l];
                            US4 v134;
                            switch (v128) {
                                case 0: {
                                    v134 = US4_0();
                                    break;
                                }
                                case 1: {
                                    double * v131;
                                    v131 = (double *)(v94+32ull);
                                    double v132;
                                    v132 = v131[0l];
                                    v134 = US4_1(v132);
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v136 = US2_1(v126, v134);
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v138 = US1_1(v136);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v139;
            v139 = 0l <= v89;
            bool v142;
            if (v139){
                long & v140 = v84;
                bool v141;
                v141 = v89 < v140;
                v142 = v141;
            } else {
                v142 = false;
            }
            bool v143;
            v143 = v142 == false;
            if (v143){
                assert("The set index needs to be in range." && v142);
            } else {
            }
            bool v145;
            if (v139){
                bool v144;
                v144 = v89 < 14l;
                v145 = v144;
            } else {
                v145 = false;
            }
            bool v146;
            v146 = v145 == false;
            if (v146){
                assert("The read index needs to be in range." && v145);
            } else {
            }
            v83.v[v89] = Tuple0(v96, v104, v138);
            v89 += 1l ;
        }
        unsigned short * v147;
        v147 = (unsigned short *)(v0+704ull);
        unsigned short v148;
        v148 = v147[0l];
        const char * v149;
        v149 = "%d";
        printf(v149,v80);
        const char * v150;
        v150 = "%s";
        const char * v151;
        v151 = ", ";
        printf(v150,v151);
        const char * v152;
        v152 = "%u";
        printf(v152,v82);
        printf(v150,v151);
        const char * v153;
        v153 = "[";
        printf(v150,v153);
        long & v154 = v84;
        bool v155;
        v155 = 100l < v154;
        long v156;
        if (v155){
            v156 = 100l;
        } else {
            v156 = v154;
        }
        long v157;
        v157 = 0l;
        while (while_method_0(v156, v157)){
            bool v159;
            v159 = 0l <= v157;
            bool v162;
            if (v159){
                long & v160 = v84;
                bool v161;
                v161 = v157 < v160;
                v162 = v161;
            } else {
                v162 = false;
            }
            bool v163;
            v163 = v162 == false;
            if (v163){
                assert("The read index needs to be in range." && v162);
            } else {
            }
            bool v165;
            if (v159){
                bool v164;
                v164 = v157 < 14l;
                v165 = v164;
            } else {
                v165 = false;
            }
            bool v166;
            v166 = v165 == false;
            if (v166){
                assert("The read index needs to be in range." && v165);
            } else {
            }
            long v167; US0 v168; US1 v169;
            Tuple0 tmp1 = v83.v[v157];
            v167 = tmp1.v0; v168 = tmp1.v1; v169 = tmp1.v2;
            printf(v149,v167);
            printf(v150,v151);
            switch (v168.tag) {
                case 0: { // None
                    const char * v170;
                    v170 = "None";
                    printf(v150,v170);
                    break;
                }
                default: { // Some
                    unsigned long long v171 = v168.v.case1.v0;
                    const char * v172;
                    v172 = "Some";
                    printf(v150,v172);
                    const char * v173;
                    v173 = "(";
                    printf(v150,v173);
                    printf(v152,v171);
                    const char * v174;
                    v174 = ")";
                    printf(v150,v174);
                }
            }
            printf(v150,v151);
            switch (v169.tag) {
                case 0: { // None
                    const char * v175;
                    v175 = "None";
                    printf(v150,v175);
                    break;
                }
                default: { // Some
                    US2 v176 = v169.v.case1.v0;
                    const char * v177;
                    v177 = "Some";
                    printf(v150,v177);
                    const char * v178;
                    v178 = "(";
                    printf(v150,v178);
                    switch (v176.tag) {
                        case 0: { // Q
                            char v179 = v176.v.case0.v0; unsigned char v180 = v176.v.case0.v1; US3 v181 = v176.v.case0.v2;
                            const char * v182;
                            v182 = "Q";
                            printf(v150,v182);
                            printf(v150,v178);
                            printf(v149,v179);
                            printf(v150,v151);
                            printf(v152,v180);
                            printf(v150,v151);
                            switch (v181.tag) {
                                case 0: { // None
                                    const char * v183;
                                    v183 = "None";
                                    printf(v150,v183);
                                    break;
                                }
                                default: { // Some
                                    float v184 = v181.v.case1.v0;
                                    printf(v150,v177);
                                    printf(v150,v178);
                                    const char * v185;
                                    v185 = "%f";
                                    printf(v185,v184);
                                    const char * v186;
                                    v186 = ")";
                                    printf(v150,v186);
                                }
                            }
                            const char * v187;
                            v187 = ")";
                            printf(v150,v187);
                            break;
                        }
                        default: { // W
                            unsigned short v188 = v176.v.case1.v0; US4 v189 = v176.v.case1.v1;
                            const char * v190;
                            v190 = "W";
                            printf(v150,v190);
                            printf(v150,v178);
                            printf(v152,v188);
                            printf(v150,v151);
                            switch (v189.tag) {
                                case 0: { // None
                                    const char * v191;
                                    v191 = "None";
                                    printf(v150,v191);
                                    break;
                                }
                                default: { // Some
                                    double v192 = v189.v.case1.v0;
                                    printf(v150,v177);
                                    printf(v150,v178);
                                    const char * v193;
                                    v193 = "%f";
                                    printf(v193,v192);
                                    const char * v194;
                                    v194 = ")";
                                    printf(v150,v194);
                                }
                            }
                            const char * v195;
                            v195 = ")";
                            printf(v150,v195);
                        }
                    }
                    const char * v196;
                    v196 = ")";
                    printf(v150,v196);
                }
            }
            long v197;
            v197 = v157 + 1l;
            long & v198 = v84;
            bool v199;
            v199 = v197 < v198;
            if (v199){
                const char * v200;
                v200 = "; ";
                printf(v150,v200);
            } else {
            }
            v157 += 1l ;
        }
        long & v201 = v84;
        bool v202;
        v202 = v201 > 100l;
        if (v202){
            const char * v203;
            v203 = "; ...";
            printf(v150,v203);
        } else {
        }
        const char * v204;
        v204 = "]";
        printf(v150,v204);
        printf(v150,v151);
        printf(v152,v148);
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
    v7 = [None] * 14
    v8 = [0]
    v9 = v0[16:].view(cp.int32)
    v10 = v9[0].item()
    del v9
    v11 = v8[0]
    del v11
    v8[0] = v10
    del v10
    v12 = v8[0]
    v13 = 0
    while method0(v12, v13):
        v15 = u64(v13)
        v16 = v15 * 48
        del v15
        v17 = 32 + v16
        del v16
        v18 = v0[v17:].view(cp.uint8)
        del v17
        v19 = v18[0:].view(cp.int32)
        v20 = v19[0].item()
        del v19
        v21 = v18[4:].view(cp.int32)
        v22 = v21[0].item()
        del v21
        if v22 == 0:
            v28 = US0_0()
        elif v22 == 1:
            v25 = v18[8:].view(cp.uint64)
            v26 = v25[0].item()
            del v25
            v28 = US0_1(v26)
        else:
            raise Exception("Invalid tag.")
        del v22
        v29 = v18[16:].view(cp.int32)
        v30 = v29[0].item()
        del v29
        if v30 == 0:
            v62 = US1_0()
        elif v30 == 1:
            v33 = v18[20:].view(cp.int32)
            v34 = v33[0].item()
            del v33
            if v34 == 0:
                v36 = v18[24:].view(cp.int8)
                v37 = v36[0].item()
                del v36
                v38 = v18[25:].view(cp.uint8)
                v39 = v38[0].item()
                del v38
                v40 = v18[28:].view(cp.int32)
                v41 = v40[0].item()
                del v40
                if v41 == 0:
                    v47 = US3_0()
                elif v41 == 1:
                    v44 = v18[32:].view(cp.float32)
                    v45 = v44[0].item()
                    del v44
                    v47 = US3_1(v45)
                else:
                    raise Exception("Invalid tag.")
                del v41
                v60 = US2_0(v37, v39, v47)
            elif v34 == 1:
                v49 = v18[24:].view(cp.uint16)
                v50 = v49[0].item()
                del v49
                v51 = v18[28:].view(cp.int32)
                v52 = v51[0].item()
                del v51
                if v52 == 0:
                    v58 = US4_0()
                elif v52 == 1:
                    v55 = v18[32:].view(cp.float64)
                    v56 = v55[0].item()
                    del v55
                    v58 = US4_1(v56)
                else:
                    raise Exception("Invalid tag.")
                del v52
                v60 = US2_1(v50, v58)
            else:
                raise Exception("Invalid tag.")
            del v34
            v62 = US1_1(v60)
        else:
            raise Exception("Invalid tag.")
        del v18, v30
        v63 = 0 <= v13
        if v63:
            v64 = v8[0]
            v65 = v13 < v64
            del v64
            v66 = v65
        else:
            v66 = False
        v67 = v66 == False
        if v67:
            v68 = "The set index needs to be in range."
            assert v66, v68
            del v68
        else:
            pass
        del v66, v67
        if v63:
            v69 = v13 < 14
            v70 = v69
        else:
            v70 = False
        del v63
        v71 = v70 == False
        if v71:
            v72 = "The read index needs to be in range."
            assert v70, v72
            del v72
        else:
            pass
        del v70, v71
        v7[v13] = (v20, v28, v62)
        del v20, v28, v62
        v13 += 1 
    del v12, v13
    v73 = v0[704:].view(cp.uint16)
    del v0
    v74 = v73[0].item()
    del v73
    print(v4, end="")
    del v4
    v75 = ", "
    print(v75, end="")
    print(v6, end="")
    del v6
    print(v75, end="")
    v76 = "["
    print(v76, end="")
    del v76
    v77 = v8[0]
    v78 = 100 < v77
    if v78:
        v79 = 100
    else:
        v79 = v77
    del v77, v78
    v80 = 0
    while method0(v79, v80):
        v82 = 0 <= v80
        if v82:
            v83 = v8[0]
            v84 = v80 < v83
            del v83
            v85 = v84
        else:
            v85 = False
        v86 = v85 == False
        if v86:
            v87 = "The read index needs to be in range."
            assert v85, v87
            del v87
        else:
            pass
        del v85, v86
        if v82:
            v88 = v80 < 14
            v89 = v88
        else:
            v89 = False
        del v82
        v90 = v89 == False
        if v90:
            v91 = "The read index needs to be in range."
            assert v89, v91
            del v91
        else:
            pass
        del v89, v90
        v92, v93, v94 = v7[v80]
        print(v92, end="")
        del v92
        print(v75, end="")
        match v93:
            case US0_0(): # None
                v95 = "None"
                print(v95, end="")
                del v95
            case US0_1(v96): # Some
                v97 = "Some"
                print(v97, end="")
                del v97
                v98 = "("
                print(v98, end="")
                del v98
                print(v96, end="")
                del v96
                v99 = ")"
                print(v99, end="")
                del v99
        del v93
        print(v75, end="")
        match v94:
            case US1_0(): # None
                v100 = "None"
                print(v100, end="")
                del v100
            case US1_1(v101): # Some
                v102 = "Some"
                print(v102, end="")
                v103 = "("
                print(v103, end="")
                match v101:
                    case US2_0(v104, v105, v106): # Q
                        v107 = "Q"
                        print(v107, end="")
                        del v107
                        print(v103, end="")
                        print(v104, end="")
                        del v104
                        print(v75, end="")
                        print(v105, end="")
                        del v105
                        print(v75, end="")
                        match v106:
                            case US3_0(): # None
                                v108 = "None"
                                print(v108, end="")
                                del v108
                            case US3_1(v109): # Some
                                print(v102, end="")
                                print(v103, end="")
                                print("{:.6f}".format(v109), end="")
                                del v109
                                v110 = ")"
                                print(v110, end="")
                                del v110
                        del v106
                        v111 = ")"
                        print(v111, end="")
                        del v111
                    case US2_1(v112, v113): # W
                        v114 = "W"
                        print(v114, end="")
                        del v114
                        print(v103, end="")
                        print(v112, end="")
                        del v112
                        print(v75, end="")
                        match v113:
                            case US4_0(): # None
                                v115 = "None"
                                print(v115, end="")
                                del v115
                            case US4_1(v116): # Some
                                print(v102, end="")
                                print(v103, end="")
                                print("{:.6f}".format(v116), end="")
                                del v116
                                v117 = ")"
                                print(v117, end="")
                                del v117
                        del v113
                        v118 = ")"
                        print(v118, end="")
                        del v118
                del v101, v102, v103
                v119 = ")"
                print(v119, end="")
                del v119
        del v94
        v120 = v80 + 1
        v121 = v8[0]
        v122 = v120 < v121
        del v120, v121
        if v122:
            v123 = "; "
            print(v123, end="")
            del v123
        else:
            pass
        del v122
        v80 += 1 
    del v7, v79, v80
    v124 = v8[0]
    del v8
    v125 = v124 > 100
    del v124
    if v125:
        v126 = "; ..."
        print(v126, end="")
        del v126
    else:
        pass
    del v125
    v127 = "]"
    print(v127, end="")
    del v127
    print(v75, end="")
    del v75
    print(v74, end="")
    del v74
    print()
    return 

if __name__ == '__main__': print(main())
