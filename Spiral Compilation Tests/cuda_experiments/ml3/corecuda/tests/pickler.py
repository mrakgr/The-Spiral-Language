kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
struct US0;
struct US1;
struct Tuple0;
struct Tuple1;
__device__ Tuple0 method_0(float * v0, long v1, long v2);
struct Tuple2;
struct US0 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US1 {
    union {
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    unsigned long v0;
    long v1;
    __device__ Tuple0(unsigned long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    long v0;
    long v1;
    long v2;
    __device__ Tuple1(long t0, long t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple1() = default;
};
struct Tuple2 {
    long v0;
    long v1;
    __device__ Tuple2(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple2() = default;
};
__device__ US0 US0_0() { // Call
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1() { // Fold
    US0 x;
    x.tag = 1;
    return x;
}
__device__ US0 US0_2() { // Raise
    US0 x;
    x.tag = 2;
    return x;
}
__device__ US1 US1_0() { // Jack
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1() { // King
    US1 x;
    x.tag = 1;
    return x;
}
__device__ US1 US1_2() { // Queen
    US1 x;
    x.tag = 2;
    return x;
}
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 39l;
    return v1;
}
__device__ inline bool while_method_1(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__device__ Tuple0 method_0(float * v0, long v1, long v2){
    long v3; long v4; long v5;
    Tuple1 tmp0 = Tuple1(v2, 0l, 0l);
    v3 = tmp0.v0; v4 = tmp0.v1; v5 = tmp0.v2;
    while (while_method_1(v1, v3)){
        float v7;
        v7 = v0[v3];
        bool v8;
        v8 = v7 == 1.0f;
        bool v10;
        if (v8){
            v10 = true;
        } else {
            bool v9;
            v9 = v7 == 0.0f;
            v10 = v9;
        }
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("Unpickling failure. The int type should always be either be 1 or 0." && v10);
        } else {
        }
        bool v13;
        v13 = v7 == 0.0f;
        long v15; long v16;
        if (v13){
            v15 = v4; v16 = v5;
        } else {
            long v14;
            v14 = v5 + 1l;
            v15 = v3; v16 = v14;
        }
        v4 = v15;
        v5 = v16;
        v3 += 1l ;
    }
    bool v17;
    v17 = v5 == 0l;
    bool v19;
    if (v17){
        v19 = true;
    } else {
        bool v18;
        v18 = v5 == 1l;
        v19 = v18;
    }
    bool v20;
    v20 = v19 == false;
    if (v20){
        assert("Unpickling failure. Too many active indices in the one-hot vector." && v19);
    } else {
    }
    long v22;
    v22 = v4 - v2;
    unsigned long v23;
    v23 = (unsigned long)v22;
    return Tuple0(v23, v5);
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
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
        US0 v5[3l];
        US0 v6;
        v6 = US0_2();
        v5[0l] = v6;
        US0 v7;
        v7 = US0_2();
        v5[1l] = v7;
        US0 v8;
        v8 = US0_0();
        v5[2l] = v8;
        long v9;
        v9 = 0l;
        long v10;
        v10 = 1l;
        long v11;
        v11 = 3l;
        US1 v12;
        v12 = US1_1();
        long v13;
        v13 = 8l;
        long v14;
        v14 = 5l;
        float v15[39l];
        long v16;
        v16 = 0l;
        while (while_method_0(v16)){
            assert("Tensor range check" && 0 <= v16 && v16 < 39l);
            v15[v16] = 0.0f;
            v16 += 1l ;
        }
        float * v20;
        float * v18;
        v18 = v15+0l;
        v20 = v18;
        unsigned long v21;
        v21 = (unsigned long)v14;
        long v22;
        v22 = (long)v21;
        bool v23;
        v23 = v22 < 10l;
        bool v24;
        v24 = v23 == false;
        if (v24){
            assert("Pickle failure. Int value out of bounds." && v23);
        } else {
        }
        v20[v22] = 1.0f;
        unsigned long v26;
        v26 = (unsigned long)v13;
        long v27;
        v27 = (long)v26;
        bool v28;
        v28 = v27 < 10l;
        bool v29;
        v29 = v28 == false;
        if (v29){
            assert("Pickle failure. Int value out of bounds." && v28);
        } else {
        }
        long v31;
        v31 = 10l + v27;
        v20[v31] = 1.0f;
        switch (v12.tag) {
            case 0: { // Jack
                v20[20l] = 1.0f;
                break;
            }
            case 1: { // King
                v20[21l] = 1.0f;
                break;
            }
            default: { // Queen
                v20[22l] = 1.0f;
            }
        }
        bool v32;
        v32 = v11 <= 5l;
        bool v33;
        v33 = v32 == false;
        if (v33){
            assert("Pickle failure. The given array is too large." && v32);
        } else {
        }
        bool v35;
        v35 = v11 == 0l;
        if (v35){
            v20[23l] = 1.0f;
        } else {
        }
        long v36;
        v36 = 0l;
        while (while_method_1(v11, v36)){
            assert("Tensor range check" && 0 <= v36 && v36 < v11);
            long v38;
            v38 = v10 * v36;
            long v39;
            v39 = v38 + v9;
            US0 v40;
            v40 = v5[v39];
            long v41;
            v41 = v36 * 3l;
            long v42;
            v42 = 24l + v41;
            switch (v40.tag) {
                case 0: { // Call
                    v20[v42] = 1.0f;
                    break;
                }
                case 1: { // Fold
                    long v43;
                    v43 = v42 + 1l;
                    v20[v43] = 1.0f;
                    break;
                }
                default: { // Raise
                    long v44;
                    v44 = v42 + 2l;
                    v20[v44] = 1.0f;
                }
            }
            v36 += 1l ;
        }
        long v45;
        v45 = 0l;
        long v46;
        v46 = 1l;
        long v47;
        v47 = 39l;
        float * v50;
        float * v48;
        v48 = v15+v45;
        v50 = v48;
        long v51;
        v51 = 0l;
        long v52;
        v52 = 10l;
        unsigned long v53; long v54;
        Tuple0 tmp1 = method_0(v50, v52, v51);
        v53 = tmp1.v0; v54 = tmp1.v1;
        long v55;
        v55 = (long)v53;
        long v56;
        v56 = 10l;
        long v57;
        v57 = 20l;
        unsigned long v58; long v59;
        Tuple0 tmp2 = method_0(v50, v57, v56);
        v58 = tmp2.v0; v59 = tmp2.v1;
        long v60;
        v60 = (long)v58;
        float v61;
        v61 = v50[20l];
        bool v62;
        v62 = v61 == 1.0f;
        bool v64;
        if (v62){
            v64 = true;
        } else {
            bool v63;
            v63 = v61 == 0.0f;
            v64 = v63;
        }
        bool v65;
        v65 = v64 == false;
        if (v65){
            assert("Unpickling failure. The unit type should always be either be 1 or 0." && v64);
        } else {
        }
        long v67;
        if (v62){
            v67 = 1l;
        } else {
            v67 = 0l;
        }
        float v68;
        v68 = v50[21l];
        bool v69;
        v69 = v68 == 1.0f;
        bool v71;
        if (v69){
            v71 = true;
        } else {
            bool v70;
            v70 = v68 == 0.0f;
            v71 = v70;
        }
        bool v72;
        v72 = v71 == false;
        if (v72){
            assert("Unpickling failure. The unit type should always be either be 1 or 0." && v71);
        } else {
        }
        long v74;
        if (v69){
            v74 = 1l;
        } else {
            v74 = 0l;
        }
        float v75;
        v75 = v50[22l];
        bool v76;
        v76 = v75 == 1.0f;
        bool v78;
        if (v76){
            v78 = true;
        } else {
            bool v77;
            v77 = v75 == 0.0f;
            v78 = v77;
        }
        bool v79;
        v79 = v78 == false;
        if (v79){
            assert("Unpickling failure. The unit type should always be either be 1 or 0." && v78);
        } else {
        }
        long v81;
        if (v76){
            v81 = 1l;
        } else {
            v81 = 0l;
        }
        bool v82;
        v82 = v74 == 1l;
        US1 v85;
        if (v82){
            v85 = US1_1();
        } else {
            v85 = US1_0();
        }
        long v86;
        v86 = v67 + v74;
        bool v87;
        v87 = v81 == 1l;
        US1 v89;
        if (v87){
            v89 = US1_2();
        } else {
            v89 = v85;
        }
        long v90;
        v90 = v86 + v81;
        bool v91;
        v91 = v90 == 0l;
        bool v93;
        if (v91){
            v93 = true;
        } else {
            bool v92;
            v92 = v90 == 1l;
            v93 = v92;
        }
        bool v94;
        v94 = v93 == false;
        if (v94){
            assert("Unpickling failure. Only a single case of an union type should be active at most." && v93);
        } else {
        }
        long v96;
        v96 = 23l;
        US0 v97[5l];
        float v98;
        v98 = v50[v96];
        bool v99;
        v99 = v98 == 0.0f;
        bool v101;
        if (v99){
            v101 = true;
        } else {
            bool v100;
            v100 = v98 == 1.0f;
            v101 = v100;
        }
        bool v102;
        v102 = v101 == false;
        if (v102){
            assert("Unpickle failure. The array emptiness flag should be 1 or 0." && v101);
        } else {
        }
        bool v104;
        v104 = v98 == 1.0f;
        long v105;
        v105 = v96 + 1l;
        long v106; long v107;
        Tuple2 tmp3 = Tuple2(0l, 0l);
        v106 = tmp3.v0; v107 = tmp3.v1;
        while (while_method_2(v106)){
            long v109;
            v109 = v106 * 3l;
            long v110;
            v110 = v105 + v109;
            float v111;
            v111 = v50[v110];
            bool v112;
            v112 = v111 == 1.0f;
            bool v114;
            if (v112){
                v114 = true;
            } else {
                bool v113;
                v113 = v111 == 0.0f;
                v114 = v113;
            }
            bool v115;
            v115 = v114 == false;
            if (v115){
                assert("Unpickling failure. The unit type should always be either be 1 or 0." && v114);
            } else {
            }
            long v117;
            if (v112){
                v117 = 1l;
            } else {
                v117 = 0l;
            }
            long v118;
            v118 = v110 + 1l;
            float v119;
            v119 = v50[v118];
            bool v120;
            v120 = v119 == 1.0f;
            bool v122;
            if (v120){
                v122 = true;
            } else {
                bool v121;
                v121 = v119 == 0.0f;
                v122 = v121;
            }
            bool v123;
            v123 = v122 == false;
            if (v123){
                assert("Unpickling failure. The unit type should always be either be 1 or 0." && v122);
            } else {
            }
            long v125;
            if (v120){
                v125 = 1l;
            } else {
                v125 = 0l;
            }
            long v126;
            v126 = v110 + 2l;
            float v127;
            v127 = v50[v126];
            bool v128;
            v128 = v127 == 1.0f;
            bool v130;
            if (v128){
                v130 = true;
            } else {
                bool v129;
                v129 = v127 == 0.0f;
                v130 = v129;
            }
            bool v131;
            v131 = v130 == false;
            if (v131){
                assert("Unpickling failure. The unit type should always be either be 1 or 0." && v130);
            } else {
            }
            long v133;
            if (v128){
                v133 = 1l;
            } else {
                v133 = 0l;
            }
            bool v134;
            v134 = v125 == 1l;
            US0 v137;
            if (v134){
                v137 = US0_1();
            } else {
                v137 = US0_0();
            }
            long v138;
            v138 = v117 + v125;
            bool v139;
            v139 = v133 == 1l;
            US0 v141;
            if (v139){
                v141 = US0_2();
            } else {
                v141 = v137;
            }
            long v142;
            v142 = v138 + v133;
            bool v143;
            v143 = v142 == 0l;
            bool v145;
            if (v143){
                v145 = true;
            } else {
                bool v144;
                v144 = v142 == 1l;
                v145 = v144;
            }
            bool v146;
            v146 = v145 == false;
            if (v146){
                assert("Unpickling failure. Only a single case of an union type should be active at most." && v145);
            } else {
            }
            bool v148;
            v148 = v106 == v107;
            long v154;
            if (v148){
                bool v149;
                v149 = v142 == 1l;
                if (v149){
                    assert("Tensor range check" && 0 <= v106 && v106 < 5l);
                    v97[v106] = v141;
                } else {
                }
                long v150;
                v150 = v107 + v142;
                v154 = v150;
            } else {
                bool v151;
                v151 = v107 == 0l;
                bool v152;
                v152 = v151 == false;
                if (v152){
                    assert("Unpickle failure. Expected an inactive subsequence in the array unpickler." && v151);
                } else {
                }
                v154 = v107;
            }
            v107 = v154;
            v106 += 1l ;
        }
        if (v104){
            bool v155;
            v155 = v107 == 0l;
            bool v156;
            v156 = v155 == false;
            if (v156){
                assert("Unpickle failure. Empty arrays should not have active elements." && v155);
            } else {
            }
        } else {
        }
        assert("Tensor view range check" && 0 <= 0l && 0l < v107 && 0l <= 5l);
        long v158;
        if (v104){
            v158 = 1l;
        } else {
            v158 = 0l;
        }
        long v159;
        v159 = v158 + v107;
        bool v160;
        v160 = 1l < v159;
        long v161;
        if (v160){
            v161 = 1l;
        } else {
            v161 = v159;
        }
        long v162;
        v162 = v90 + v161;
        bool v163;
        v163 = v162 == 0l;
        bool v165;
        if (v163){
            v165 = true;
        } else {
            bool v164;
            v164 = v162 == 2l;
            v165 = v164;
        }
        bool v166;
        v166 = v165 == false;
        if (v166){
            assert("Unpickling failure. Two sides of a pair should either all be active or inactive." && v165);
        } else {
        }
        long v168;
        v168 = v162 / 2l;
        long v169;
        v169 = v59 + v168;
        bool v170;
        v170 = v169 == 0l;
        bool v172;
        if (v170){
            v172 = true;
        } else {
            bool v171;
            v171 = v169 == 2l;
            v172 = v171;
        }
        bool v173;
        v173 = v172 == false;
        if (v173){
            assert("Unpickling failure. Two sides of a pair should either all be active or inactive." && v172);
        } else {
        }
        long v175;
        v175 = v169 / 2l;
        long v176;
        v176 = v54 + v175;
        bool v177;
        v177 = v176 == 0l;
        bool v179;
        if (v177){
            v179 = true;
        } else {
            bool v178;
            v178 = v176 == 2l;
            v179 = v178;
        }
        bool v180;
        v180 = v179 == false;
        if (v180){
            assert("Unpickling failure. Two sides of a pair should either all be active or inactive." && v179);
        } else {
        }
        long v182;
        v182 = v176 / 2l;
        bool v183;
        v183 = v182 == 1l;
        bool v184;
        v184 = v183 == false;
        if (v184){
            assert("Invalid format detected during deserialization." && v183);
        } else {
        }
        const char * v186;
        v186 = "%c";
        printf(v186,'{');
        const char * v187;
        v187 = "%s";
        const char * v188;
        v188 = "action_history";
        printf(v187,v188);
        const char * v190;
        v190 = "%s";
        const char * v191;
        v191 = " = ";
        printf(v190,v191);
        long v193;
        v193 = 0l;
        const char * v194;
        v194 = "%c";
        printf(v194,'[');
        long v195;
        v195 = 0l;
        while (while_method_1(v107, v195)){
            long v197;
            v197 = v193;
            bool v198;
            v198 = v197 >= 100l;
            if (v198){
                const char * v199;
                v199 = "%s";
                const char * v200;
                v200 = " ...";
                printf(v199,v200);
                break;
            } else {
            }
            bool v202;
            v202 = v195 == 0l;
            bool v203;
            v203 = v202 != true;
            if (v203){
                const char * v204;
                v204 = "%s";
                const char * v205;
                v205 = "; ";
                printf(v204,v205);
            } else {
            }
            long v207;
            v207 = v193 + 1l;
            v193 = v207;
            US0 v208;
            v208 = v97[v195];
            switch (v208.tag) {
                case 0: { // Call
                    const char * v209;
                    v209 = "%s";
                    const char * v210;
                    v210 = "Call";
                    printf(v209,v210);
                    break;
                }
                case 1: { // Fold
                    const char * v212;
                    v212 = "%s";
                    const char * v213;
                    v213 = "Fold";
                    printf(v212,v213);
                    break;
                }
                default: { // Raise
                    const char * v215;
                    v215 = "%s";
                    const char * v216;
                    v216 = "Raise";
                    printf(v215,v216);
                }
            }
            v195 += 1l ;
        }
        const char * v218;
        v218 = "%c";
        printf(v218,']');
        const char * v219;
        v219 = "%s";
        const char * v220;
        v220 = "; ";
        printf(v219,v220);
        const char * v222;
        v222 = "%s";
        const char * v223;
        v223 = "card";
        printf(v222,v223);
        const char * v225;
        v225 = "%s";
        const char * v226;
        v226 = " = ";
        printf(v225,v226);
        switch (v89.tag) {
            case 0: { // Jack
                const char * v228;
                v228 = "%s";
                const char * v229;
                v229 = "Jack";
                printf(v228,v229);
                break;
            }
            case 1: { // King
                const char * v231;
                v231 = "%s";
                const char * v232;
                v232 = "King";
                printf(v231,v232);
                break;
            }
            default: { // Queen
                const char * v234;
                v234 = "%s";
                const char * v235;
                v235 = "Queen";
                printf(v234,v235);
            }
        }
        const char * v237;
        v237 = "%s";
        const char * v238;
        v238 = "; ";
        printf(v237,v238);
        const char * v240;
        v240 = "%s";
        const char * v241;
        v241 = "pot";
        printf(v240,v241);
        const char * v243;
        v243 = "%s";
        const char * v244;
        v244 = " = ";
        printf(v243,v244);
        const char * v246;
        v246 = "%d";
        printf(v246,v60);
        const char * v247;
        v247 = "%s";
        const char * v248;
        v248 = "; ";
        printf(v247,v248);
        const char * v250;
        v250 = "%s";
        const char * v251;
        v251 = "stack";
        printf(v250,v251);
        const char * v253;
        v253 = "%s";
        const char * v254;
        v254 = " = ";
        printf(v253,v254);
        const char * v256;
        v256 = "%d";
        printf(v256,v55);
        const char * v257;
        v257 = "%c";
        printf(v257,'}');
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
