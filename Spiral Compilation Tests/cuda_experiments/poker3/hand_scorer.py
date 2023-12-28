kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
struct Card { uint8_t rank : 4; uint8_t suit : 2; };
struct Tuple0;
struct Tuple1;
struct Tuple2;
__device__ uint32_t loop_2(uint32_t v0, curandStatePhilox4_32_10_t * v1);
__device__ Tuple2 draw_card_1(curandStatePhilox4_32_10_t * v0, uint64_t v1);
__device__ Tuple0 draw_cards_0(curandStatePhilox4_32_10_t * v0, uint64_t v1);
struct Tuple3;
struct Tuple4;
struct Tuple5;
struct US0;
struct Tuple6;
struct US1;
struct Tuple7;
struct Tuple8;
struct US2;
struct US3;
struct US4;
struct Tuple9;
struct US5;
struct US6;
__device__ Tuple3 score_3(array<Card,7l> v0);
struct US7;
__device__ Tuple3 score_4(array<Card,7l> v0);
struct Tuple0 {
    array<Card,7l> v0;
    uint64_t v1;
    __device__ Tuple0(array<Card,7l> t0, uint64_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    uint64_t v1;
    int32_t v0;
    __device__ Tuple1(int32_t t0, uint64_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
struct Tuple2 {
    Card v0;
    uint64_t v1;
    __device__ Tuple2(Card t0, uint64_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple2() = default;
};
struct Tuple3 {
    array<Card,5l> v0;
    int8_t v1;
    __device__ Tuple3(array<Card,5l> t0, int8_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple3() = default;
};
struct Tuple4 {
    int32_t v1;
    bool v0;
    __device__ Tuple4(bool t0, int32_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple4() = default;
};
struct Tuple5 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    __device__ Tuple5(int32_t t0, int32_t t1, int32_t t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple5() = default;
};
struct US0 {
    union {
    } v;
    char tag : 2;
};
struct Tuple6 {
    int32_t v0;
    int32_t v1;
    uint8_t v2;
    __device__ Tuple6(int32_t t0, int32_t t1, uint8_t t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple6() = default;
};
struct US1 {
    union {
        struct {
            array<Card,5l> v0;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple7 {
    US0 v1;
    int32_t v0;
    __device__ Tuple7(int32_t t0, US0 t1) : v0(t0), v1(t1) {}
    __device__ Tuple7() = default;
};
struct Tuple8 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    uint8_t v3;
    __device__ Tuple8(int32_t t0, int32_t t1, int32_t t2, uint8_t t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    __device__ Tuple8() = default;
};
struct US2 {
    union {
        struct {
            array<Card,4l> v0;
            array<Card,3l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US3 {
    union {
        struct {
            array<Card,3l> v0;
            array<Card,4l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US4 {
    union {
        struct {
            array<Card,2l> v0;
            array<Card,2l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple9 {
    int32_t v0;
    int32_t v1;
    __device__ Tuple9(int32_t t0, int32_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple9() = default;
};
struct US5 {
    union {
        struct {
            array<Card,2l> v0;
            array<Card,5l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US6 {
    union {
        struct {
            array<Card,2l> v0;
            array<Card,3l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US7 {
    union {
        struct {
            array<Card,5l> v0;
            int8_t v1;
        } case1; // Some
    } v;
    char tag : 2;
};
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 1000000l;
    return v1;
}
__device__ inline bool while_method_1(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
__device__ uint32_t loop_2(uint32_t v0, curandStatePhilox4_32_10_t * v1){
    uint32_t v2;
    v2 = curand(v1);
    uint32_t v3;
    v3 = v2 % v0;
    uint32_t v4;
    v4 = v2 - v3;
    uint32_t v5;
    v5 = 0ul - v0;
    bool v6;
    v6 = v4 <= v5;
    if (v6){
        return v3;
    } else {
        return loop_2(v0, v1);
    }
}
__device__ Tuple2 draw_card_1(curandStatePhilox4_32_10_t * v0, uint64_t v1){
    int32_t v2;
    v2 = __popcll(v1);
    uint32_t v3;
    v3 = (uint32_t)v2;
    uint32_t v4;
    v4 = loop_2(v3, v0);
    int32_t v5;
    v5 = (int32_t)v4;
    uint32_t v6;
    v6 = (uint32_t)v1;
    uint64_t v7;
    v7 = v1 >> 32l;
    uint32_t v8;
    v8 = (uint32_t)v7;
    int32_t v9;
    v9 = __popc(v6);
    bool v10;
    v10 = v5 < v9;
    uint32_t v17;
    if (v10){
        int32_t v11;
        v11 = v5 + 1l;
        uint32_t v12;
        v12 = __fns(v6,0ul,v11);
        v17 = v12;
    } else {
        int32_t v13;
        v13 = v5 - v9;
        int32_t v14;
        v14 = v13 + 1l;
        uint32_t v15;
        v15 = __fns(v8,0ul,v14);
        uint32_t v16;
        v16 = v15 + 32ul;
        v17 = v16;
    }
    uint8_t v18;
    v18 = (uint8_t)v17;
    uint8_t v19;
    v19 = v18 / 13u;
    uint8_t v20;
    v20 = v18 % 13u;
    Card v21;
    v21 = {v20, v19};
    int32_t v22;
    v22 = (int32_t)v17;
    uint64_t v23;
    v23 = 1ull << v22;
    uint64_t v24;
    v24 = v1 ^ v23;
    return Tuple2(v21, v24);
}
__device__ Tuple0 draw_cards_0(curandStatePhilox4_32_10_t * v0, uint64_t v1){
    array<Card,7l> v2;
    int32_t v3; uint64_t v4;
    Tuple1 tmp0 = Tuple1(0l, v1);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (while_method_1(v3)){
        Card v6; uint64_t v7;
        Tuple2 tmp1 = draw_card_1(v0, v4);
        v6 = tmp1.v0; v7 = tmp1.v1;
        v2.v[v3] = v6;
        v4 = v7;
        v3 += 1l ;
    }
    return Tuple0(v2, v4);
}
__device__ inline bool while_method_2(array<Card,7l> v0, bool v1, int32_t v2){
    bool v3;
    v3 = v2 < 7l;
    return v3;
}
__device__ inline bool while_method_3(array<Card,7l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 7l;
    return v2;
}
__device__ inline bool while_method_4(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
__device__ US0 US0_0() { // Eq
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1() { // Gt
    US0 x;
    x.tag = 1;
    return x;
}
__device__ US0 US0_2() { // Lt
    US0 x;
    x.tag = 2;
    return x;
}
__device__ US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1(array<Card,5l> v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_5(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
__device__ US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
__device__ US2 US2_1(array<Card,4l> v0, array<Card,3l> v1) { // Some
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_6(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
__device__ inline bool while_method_7(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_8(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1(array<Card,3l> v0, array<Card,4l> v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1(array<Card,2l> v0, array<Card,2l> v1) { // Some
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_9(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
__device__ US5 US5_1(array<Card,2l> v0, array<Card,5l> v1) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
__device__ US6 US6_1(array<Card,2l> v0, array<Card,3l> v1) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ Tuple3 score_3(array<Card,7l> v0){
    array<Card,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_1(v2)){
        Card v4;
        v4 = v0.v[v2];
        v1.v[v2] = v4;
        v2 += 1l ;
    }
    array<Card,7l> v5;
    bool v6; int32_t v7;
    Tuple4 tmp3 = Tuple4(true, 1l);
    v6 = tmp3.v0; v7 = tmp3.v1;
    while (while_method_2(v1, v6, v7)){
        int32_t v9;
        v9 = 0l;
        while (while_method_3(v1, v9)){
            int32_t v11;
            v11 = v9 + v7;
            bool v12;
            v12 = v11 < 7l;
            int32_t v13;
            if (v12){
                v13 = v11;
            } else {
                v13 = 7l;
            }
            int32_t v14;
            v14 = v7 * 2l;
            int32_t v15;
            v15 = v9 + v14;
            bool v16;
            v16 = v15 < 7l;
            int32_t v17;
            if (v16){
                v17 = v15;
            } else {
                v17 = 7l;
            }
            int32_t v18; int32_t v19; int32_t v20;
            Tuple5 tmp4 = Tuple5(v9, v13, v9);
            v18 = tmp4.v0; v19 = tmp4.v1; v20 = tmp4.v2;
            while (while_method_4(v17, v18, v19, v20)){
                bool v22;
                v22 = v18 < v13;
                bool v24;
                if (v22){
                    bool v23;
                    v23 = v19 < v17;
                    v24 = v23;
                } else {
                    v24 = false;
                }
                Card v66; int32_t v67; int32_t v68;
                if (v24){
                    Card v27;
                    if (v6){
                        Card v25;
                        v25 = v1.v[v18];
                        v27 = v25;
                    } else {
                        Card v26;
                        v26 = v5.v[v18];
                        v27 = v26;
                    }
                    Card v30;
                    if (v6){
                        Card v28;
                        v28 = v1.v[v19];
                        v30 = v28;
                    } else {
                        Card v29;
                        v29 = v5.v[v19];
                        v30 = v29;
                    }
                    uint8_t v31;
                    v31 = v30.rank;
                    uint8_t v32;
                    v32 = v27.rank;
                    bool v33;
                    v33 = v31 < v32;
                    US0 v39;
                    if (v33){
                        v39 = US0_2();
                    } else {
                        bool v35;
                        v35 = v31 > v32;
                        if (v35){
                            v39 = US0_1();
                        } else {
                            v39 = US0_0();
                        }
                    }
                    US0 v49;
                    switch (v39.tag) {
                        case 0: { // Eq
                            uint8_t v40;
                            v40 = v27.suit;
                            uint8_t v41;
                            v41 = v30.suit;
                            bool v42;
                            v42 = v40 < v41;
                            if (v42){
                                v49 = US0_2();
                            } else {
                                bool v44;
                                v44 = v40 > v41;
                                if (v44){
                                    v49 = US0_1();
                                } else {
                                    v49 = US0_0();
                                }
                            }
                            break;
                        }
                        default: {
                            v49 = v39;
                        }
                    }
                    switch (v49.tag) {
                        case 1: { // Gt
                            int32_t v50;
                            v50 = v19 + 1l;
                            v66 = v30; v67 = v18; v68 = v50;
                            break;
                        }
                        default: {
                            int32_t v51;
                            v51 = v18 + 1l;
                            v66 = v27; v67 = v51; v68 = v19;
                        }
                    }
                } else {
                    if (v22){
                        Card v57;
                        if (v6){
                            Card v55;
                            v55 = v1.v[v18];
                            v57 = v55;
                        } else {
                            Card v56;
                            v56 = v5.v[v18];
                            v57 = v56;
                        }
                        int32_t v58;
                        v58 = v18 + 1l;
                        v66 = v57; v67 = v58; v68 = v19;
                    } else {
                        Card v61;
                        if (v6){
                            Card v59;
                            v59 = v1.v[v19];
                            v61 = v59;
                        } else {
                            Card v60;
                            v60 = v5.v[v19];
                            v61 = v60;
                        }
                        int32_t v62;
                        v62 = v19 + 1l;
                        v66 = v61; v67 = v18; v68 = v62;
                    }
                }
                if (v6){
                    v5.v[v20] = v66;
                } else {
                    v1.v[v20] = v66;
                }
                int32_t v69;
                v69 = v20 + 1l;
                v18 = v67;
                v19 = v68;
                v20 = v69;
            }
            v9 = v15;
        }
        bool v70;
        v70 = v6 == false;
        int32_t v71;
        v71 = v7 * 2l;
        v6 = v70;
        v7 = v71;
    }
    bool v72;
    v72 = v6 == false;
    array<Card,7l> v73;
    if (v72){
        v73 = v5;
    } else {
        v73 = v1;
    }
    array<Card,5l> v74;
    int32_t v75; int32_t v76; uint8_t v77;
    Tuple6 tmp5 = Tuple6(0l, 0l, 12u);
    v75 = tmp5.v0; v76 = tmp5.v1; v77 = tmp5.v2;
    while (while_method_1(v75)){
        Card v79;
        v79 = v73.v[v75];
        bool v80;
        v80 = v76 < 5l;
        int32_t v93; uint8_t v94;
        if (v80){
            uint8_t v81;
            v81 = v79.suit;
            bool v82;
            v82 = 0u == v81;
            if (v82){
                uint8_t v83;
                v83 = v79.rank;
                bool v84;
                v84 = v77 == v83;
                int32_t v85;
                if (v84){
                    v85 = v76;
                } else {
                    v85 = 0l;
                }
                v74.v[v85] = v79;
                int32_t v86;
                v86 = v85 + 1l;
                uint8_t v87;
                v87 = v79.rank;
                uint8_t v88;
                v88 = v87 - 1u;
                v93 = v86; v94 = v88;
            } else {
                v93 = v76; v94 = v77;
            }
        } else {
            break;
        }
        v76 = v93;
        v77 = v94;
        v75 += 1l ;
    }
    bool v95;
    v95 = v76 == 4l;
    bool v130;
    if (v95){
        uint8_t v96;
        v96 = v77 + 1u;
        bool v97;
        v97 = v96 == 0u;
        if (v97){
            Card v98;
            v98 = v73.v[0l];
            uint8_t v99;
            v99 = v98.suit;
            bool v100;
            v100 = 0u == v99;
            bool v104;
            if (v100){
                uint8_t v101;
                v101 = v98.rank;
                bool v102;
                v102 = v101 == 12u;
                if (v102){
                    v74.v[4l] = v98;
                    v104 = true;
                } else {
                    v104 = false;
                }
            } else {
                v104 = false;
            }
            if (v104){
                v130 = true;
            } else {
                Card v105;
                v105 = v73.v[1l];
                uint8_t v106;
                v106 = v105.suit;
                bool v107;
                v107 = 0u == v106;
                bool v111;
                if (v107){
                    uint8_t v108;
                    v108 = v105.rank;
                    bool v109;
                    v109 = v108 == 12u;
                    if (v109){
                        v74.v[4l] = v105;
                        v111 = true;
                    } else {
                        v111 = false;
                    }
                } else {
                    v111 = false;
                }
                if (v111){
                    v130 = true;
                } else {
                    Card v112;
                    v112 = v73.v[2l];
                    uint8_t v113;
                    v113 = v112.suit;
                    bool v114;
                    v114 = 0u == v113;
                    bool v118;
                    if (v114){
                        uint8_t v115;
                        v115 = v112.rank;
                        bool v116;
                        v116 = v115 == 12u;
                        if (v116){
                            v74.v[4l] = v112;
                            v118 = true;
                        } else {
                            v118 = false;
                        }
                    } else {
                        v118 = false;
                    }
                    if (v118){
                        v130 = true;
                    } else {
                        Card v119;
                        v119 = v73.v[3l];
                        uint8_t v120;
                        v120 = v119.suit;
                        bool v121;
                        v121 = 0u == v120;
                        if (v121){
                            uint8_t v122;
                            v122 = v119.rank;
                            bool v123;
                            v123 = v122 == 12u;
                            if (v123){
                                v74.v[4l] = v119;
                                v130 = true;
                            } else {
                                v130 = false;
                            }
                        } else {
                            v130 = false;
                        }
                    }
                }
            }
        } else {
            v130 = false;
        }
    } else {
        v130 = false;
    }
    US1 v136;
    if (v130){
        v136 = US1_1(v74);
    } else {
        bool v132;
        v132 = v76 == 5l;
        if (v132){
            v136 = US1_1(v74);
        } else {
            v136 = US1_0();
        }
    }
    array<Card,5l> v137;
    int32_t v138; int32_t v139; uint8_t v140;
    Tuple6 tmp6 = Tuple6(0l, 0l, 12u);
    v138 = tmp6.v0; v139 = tmp6.v1; v140 = tmp6.v2;
    while (while_method_1(v138)){
        Card v142;
        v142 = v73.v[v138];
        bool v143;
        v143 = v139 < 5l;
        int32_t v156; uint8_t v157;
        if (v143){
            uint8_t v144;
            v144 = v142.suit;
            bool v145;
            v145 = 1u == v144;
            if (v145){
                uint8_t v146;
                v146 = v142.rank;
                bool v147;
                v147 = v140 == v146;
                int32_t v148;
                if (v147){
                    v148 = v139;
                } else {
                    v148 = 0l;
                }
                v137.v[v148] = v142;
                int32_t v149;
                v149 = v148 + 1l;
                uint8_t v150;
                v150 = v142.rank;
                uint8_t v151;
                v151 = v150 - 1u;
                v156 = v149; v157 = v151;
            } else {
                v156 = v139; v157 = v140;
            }
        } else {
            break;
        }
        v139 = v156;
        v140 = v157;
        v138 += 1l ;
    }
    bool v158;
    v158 = v139 == 4l;
    bool v193;
    if (v158){
        uint8_t v159;
        v159 = v140 + 1u;
        bool v160;
        v160 = v159 == 0u;
        if (v160){
            Card v161;
            v161 = v73.v[0l];
            uint8_t v162;
            v162 = v161.suit;
            bool v163;
            v163 = 1u == v162;
            bool v167;
            if (v163){
                uint8_t v164;
                v164 = v161.rank;
                bool v165;
                v165 = v164 == 12u;
                if (v165){
                    v137.v[4l] = v161;
                    v167 = true;
                } else {
                    v167 = false;
                }
            } else {
                v167 = false;
            }
            if (v167){
                v193 = true;
            } else {
                Card v168;
                v168 = v73.v[1l];
                uint8_t v169;
                v169 = v168.suit;
                bool v170;
                v170 = 1u == v169;
                bool v174;
                if (v170){
                    uint8_t v171;
                    v171 = v168.rank;
                    bool v172;
                    v172 = v171 == 12u;
                    if (v172){
                        v137.v[4l] = v168;
                        v174 = true;
                    } else {
                        v174 = false;
                    }
                } else {
                    v174 = false;
                }
                if (v174){
                    v193 = true;
                } else {
                    Card v175;
                    v175 = v73.v[2l];
                    uint8_t v176;
                    v176 = v175.suit;
                    bool v177;
                    v177 = 1u == v176;
                    bool v181;
                    if (v177){
                        uint8_t v178;
                        v178 = v175.rank;
                        bool v179;
                        v179 = v178 == 12u;
                        if (v179){
                            v137.v[4l] = v175;
                            v181 = true;
                        } else {
                            v181 = false;
                        }
                    } else {
                        v181 = false;
                    }
                    if (v181){
                        v193 = true;
                    } else {
                        Card v182;
                        v182 = v73.v[3l];
                        uint8_t v183;
                        v183 = v182.suit;
                        bool v184;
                        v184 = 1u == v183;
                        if (v184){
                            uint8_t v185;
                            v185 = v182.rank;
                            bool v186;
                            v186 = v185 == 12u;
                            if (v186){
                                v137.v[4l] = v182;
                                v193 = true;
                            } else {
                                v193 = false;
                            }
                        } else {
                            v193 = false;
                        }
                    }
                }
            }
        } else {
            v193 = false;
        }
    } else {
        v193 = false;
    }
    US1 v199;
    if (v193){
        v199 = US1_1(v137);
    } else {
        bool v195;
        v195 = v139 == 5l;
        if (v195){
            v199 = US1_1(v137);
        } else {
            v199 = US1_0();
        }
    }
    US1 v225;
    switch (v136.tag) {
        case 0: { // None
            v225 = v199;
            break;
        }
        default: { // Some
            array<Card,5l> v200 = v136.v.case1.v0;
            switch (v199.tag) {
                case 0: { // None
                    v225 = v136;
                    break;
                }
                default: { // Some
                    array<Card,5l> v201 = v199.v.case1.v0;
                    US0 v202;
                    v202 = US0_0();
                    int32_t v203; US0 v204;
                    Tuple7 tmp7 = Tuple7(0l, v202);
                    v203 = tmp7.v0; v204 = tmp7.v1;
                    while (while_method_5(v203)){
                        Card v206;
                        v206 = v200.v[v203];
                        Card v207;
                        v207 = v201.v[v203];
                        US0 v218;
                        switch (v204.tag) {
                            case 0: { // Eq
                                uint8_t v208;
                                v208 = v206.rank;
                                uint8_t v209;
                                v209 = v207.rank;
                                bool v210;
                                v210 = v208 < v209;
                                if (v210){
                                    v218 = US0_2();
                                } else {
                                    bool v212;
                                    v212 = v208 > v209;
                                    if (v212){
                                        v218 = US0_1();
                                    } else {
                                        v218 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v204 = v218;
                        v203 += 1l ;
                    }
                    bool v219;
                    switch (v204.tag) {
                        case 1: { // Gt
                            v219 = true;
                            break;
                        }
                        default: {
                            v219 = false;
                        }
                    }
                    array<Card,5l> v220;
                    if (v219){
                        v220 = v200;
                    } else {
                        v220 = v201;
                    }
                    v225 = US1_1(v220);
                }
            }
        }
    }
    array<Card,5l> v226;
    int32_t v227; int32_t v228; uint8_t v229;
    Tuple6 tmp8 = Tuple6(0l, 0l, 12u);
    v227 = tmp8.v0; v228 = tmp8.v1; v229 = tmp8.v2;
    while (while_method_1(v227)){
        Card v231;
        v231 = v73.v[v227];
        bool v232;
        v232 = v228 < 5l;
        int32_t v245; uint8_t v246;
        if (v232){
            uint8_t v233;
            v233 = v231.suit;
            bool v234;
            v234 = 2u == v233;
            if (v234){
                uint8_t v235;
                v235 = v231.rank;
                bool v236;
                v236 = v229 == v235;
                int32_t v237;
                if (v236){
                    v237 = v228;
                } else {
                    v237 = 0l;
                }
                v226.v[v237] = v231;
                int32_t v238;
                v238 = v237 + 1l;
                uint8_t v239;
                v239 = v231.rank;
                uint8_t v240;
                v240 = v239 - 1u;
                v245 = v238; v246 = v240;
            } else {
                v245 = v228; v246 = v229;
            }
        } else {
            break;
        }
        v228 = v245;
        v229 = v246;
        v227 += 1l ;
    }
    bool v247;
    v247 = v228 == 4l;
    bool v282;
    if (v247){
        uint8_t v248;
        v248 = v229 + 1u;
        bool v249;
        v249 = v248 == 0u;
        if (v249){
            Card v250;
            v250 = v73.v[0l];
            uint8_t v251;
            v251 = v250.suit;
            bool v252;
            v252 = 2u == v251;
            bool v256;
            if (v252){
                uint8_t v253;
                v253 = v250.rank;
                bool v254;
                v254 = v253 == 12u;
                if (v254){
                    v226.v[4l] = v250;
                    v256 = true;
                } else {
                    v256 = false;
                }
            } else {
                v256 = false;
            }
            if (v256){
                v282 = true;
            } else {
                Card v257;
                v257 = v73.v[1l];
                uint8_t v258;
                v258 = v257.suit;
                bool v259;
                v259 = 2u == v258;
                bool v263;
                if (v259){
                    uint8_t v260;
                    v260 = v257.rank;
                    bool v261;
                    v261 = v260 == 12u;
                    if (v261){
                        v226.v[4l] = v257;
                        v263 = true;
                    } else {
                        v263 = false;
                    }
                } else {
                    v263 = false;
                }
                if (v263){
                    v282 = true;
                } else {
                    Card v264;
                    v264 = v73.v[2l];
                    uint8_t v265;
                    v265 = v264.suit;
                    bool v266;
                    v266 = 2u == v265;
                    bool v270;
                    if (v266){
                        uint8_t v267;
                        v267 = v264.rank;
                        bool v268;
                        v268 = v267 == 12u;
                        if (v268){
                            v226.v[4l] = v264;
                            v270 = true;
                        } else {
                            v270 = false;
                        }
                    } else {
                        v270 = false;
                    }
                    if (v270){
                        v282 = true;
                    } else {
                        Card v271;
                        v271 = v73.v[3l];
                        uint8_t v272;
                        v272 = v271.suit;
                        bool v273;
                        v273 = 2u == v272;
                        if (v273){
                            uint8_t v274;
                            v274 = v271.rank;
                            bool v275;
                            v275 = v274 == 12u;
                            if (v275){
                                v226.v[4l] = v271;
                                v282 = true;
                            } else {
                                v282 = false;
                            }
                        } else {
                            v282 = false;
                        }
                    }
                }
            }
        } else {
            v282 = false;
        }
    } else {
        v282 = false;
    }
    US1 v288;
    if (v282){
        v288 = US1_1(v226);
    } else {
        bool v284;
        v284 = v228 == 5l;
        if (v284){
            v288 = US1_1(v226);
        } else {
            v288 = US1_0();
        }
    }
    US1 v314;
    switch (v225.tag) {
        case 0: { // None
            v314 = v288;
            break;
        }
        default: { // Some
            array<Card,5l> v289 = v225.v.case1.v0;
            switch (v288.tag) {
                case 0: { // None
                    v314 = v225;
                    break;
                }
                default: { // Some
                    array<Card,5l> v290 = v288.v.case1.v0;
                    US0 v291;
                    v291 = US0_0();
                    int32_t v292; US0 v293;
                    Tuple7 tmp9 = Tuple7(0l, v291);
                    v292 = tmp9.v0; v293 = tmp9.v1;
                    while (while_method_5(v292)){
                        Card v295;
                        v295 = v289.v[v292];
                        Card v296;
                        v296 = v290.v[v292];
                        US0 v307;
                        switch (v293.tag) {
                            case 0: { // Eq
                                uint8_t v297;
                                v297 = v295.rank;
                                uint8_t v298;
                                v298 = v296.rank;
                                bool v299;
                                v299 = v297 < v298;
                                if (v299){
                                    v307 = US0_2();
                                } else {
                                    bool v301;
                                    v301 = v297 > v298;
                                    if (v301){
                                        v307 = US0_1();
                                    } else {
                                        v307 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v293 = v307;
                        v292 += 1l ;
                    }
                    bool v308;
                    switch (v293.tag) {
                        case 1: { // Gt
                            v308 = true;
                            break;
                        }
                        default: {
                            v308 = false;
                        }
                    }
                    array<Card,5l> v309;
                    if (v308){
                        v309 = v289;
                    } else {
                        v309 = v290;
                    }
                    v314 = US1_1(v309);
                }
            }
        }
    }
    array<Card,5l> v315;
    int32_t v316; int32_t v317; uint8_t v318;
    Tuple6 tmp10 = Tuple6(0l, 0l, 12u);
    v316 = tmp10.v0; v317 = tmp10.v1; v318 = tmp10.v2;
    while (while_method_1(v316)){
        Card v320;
        v320 = v73.v[v316];
        bool v321;
        v321 = v317 < 5l;
        int32_t v334; uint8_t v335;
        if (v321){
            uint8_t v322;
            v322 = v320.suit;
            bool v323;
            v323 = 3u == v322;
            if (v323){
                uint8_t v324;
                v324 = v320.rank;
                bool v325;
                v325 = v318 == v324;
                int32_t v326;
                if (v325){
                    v326 = v317;
                } else {
                    v326 = 0l;
                }
                v315.v[v326] = v320;
                int32_t v327;
                v327 = v326 + 1l;
                uint8_t v328;
                v328 = v320.rank;
                uint8_t v329;
                v329 = v328 - 1u;
                v334 = v327; v335 = v329;
            } else {
                v334 = v317; v335 = v318;
            }
        } else {
            break;
        }
        v317 = v334;
        v318 = v335;
        v316 += 1l ;
    }
    bool v336;
    v336 = v317 == 4l;
    bool v371;
    if (v336){
        uint8_t v337;
        v337 = v318 + 1u;
        bool v338;
        v338 = v337 == 0u;
        if (v338){
            Card v339;
            v339 = v73.v[0l];
            uint8_t v340;
            v340 = v339.suit;
            bool v341;
            v341 = 3u == v340;
            bool v345;
            if (v341){
                uint8_t v342;
                v342 = v339.rank;
                bool v343;
                v343 = v342 == 12u;
                if (v343){
                    v315.v[4l] = v339;
                    v345 = true;
                } else {
                    v345 = false;
                }
            } else {
                v345 = false;
            }
            if (v345){
                v371 = true;
            } else {
                Card v346;
                v346 = v73.v[1l];
                uint8_t v347;
                v347 = v346.suit;
                bool v348;
                v348 = 3u == v347;
                bool v352;
                if (v348){
                    uint8_t v349;
                    v349 = v346.rank;
                    bool v350;
                    v350 = v349 == 12u;
                    if (v350){
                        v315.v[4l] = v346;
                        v352 = true;
                    } else {
                        v352 = false;
                    }
                } else {
                    v352 = false;
                }
                if (v352){
                    v371 = true;
                } else {
                    Card v353;
                    v353 = v73.v[2l];
                    uint8_t v354;
                    v354 = v353.suit;
                    bool v355;
                    v355 = 3u == v354;
                    bool v359;
                    if (v355){
                        uint8_t v356;
                        v356 = v353.rank;
                        bool v357;
                        v357 = v356 == 12u;
                        if (v357){
                            v315.v[4l] = v353;
                            v359 = true;
                        } else {
                            v359 = false;
                        }
                    } else {
                        v359 = false;
                    }
                    if (v359){
                        v371 = true;
                    } else {
                        Card v360;
                        v360 = v73.v[3l];
                        uint8_t v361;
                        v361 = v360.suit;
                        bool v362;
                        v362 = 3u == v361;
                        if (v362){
                            uint8_t v363;
                            v363 = v360.rank;
                            bool v364;
                            v364 = v363 == 12u;
                            if (v364){
                                v315.v[4l] = v360;
                                v371 = true;
                            } else {
                                v371 = false;
                            }
                        } else {
                            v371 = false;
                        }
                    }
                }
            }
        } else {
            v371 = false;
        }
    } else {
        v371 = false;
    }
    US1 v377;
    if (v371){
        v377 = US1_1(v315);
    } else {
        bool v373;
        v373 = v317 == 5l;
        if (v373){
            v377 = US1_1(v315);
        } else {
            v377 = US1_0();
        }
    }
    US1 v403;
    switch (v314.tag) {
        case 0: { // None
            v403 = v377;
            break;
        }
        default: { // Some
            array<Card,5l> v378 = v314.v.case1.v0;
            switch (v377.tag) {
                case 0: { // None
                    v403 = v314;
                    break;
                }
                default: { // Some
                    array<Card,5l> v379 = v377.v.case1.v0;
                    US0 v380;
                    v380 = US0_0();
                    int32_t v381; US0 v382;
                    Tuple7 tmp11 = Tuple7(0l, v380);
                    v381 = tmp11.v0; v382 = tmp11.v1;
                    while (while_method_5(v381)){
                        Card v384;
                        v384 = v378.v[v381];
                        Card v385;
                        v385 = v379.v[v381];
                        US0 v396;
                        switch (v382.tag) {
                            case 0: { // Eq
                                uint8_t v386;
                                v386 = v384.rank;
                                uint8_t v387;
                                v387 = v385.rank;
                                bool v388;
                                v388 = v386 < v387;
                                if (v388){
                                    v396 = US0_2();
                                } else {
                                    bool v390;
                                    v390 = v386 > v387;
                                    if (v390){
                                        v396 = US0_1();
                                    } else {
                                        v396 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v382 = v396;
                        v381 += 1l ;
                    }
                    bool v397;
                    switch (v382.tag) {
                        case 1: { // Gt
                            v397 = true;
                            break;
                        }
                        default: {
                            v397 = false;
                        }
                    }
                    array<Card,5l> v398;
                    if (v397){
                        v398 = v378;
                    } else {
                        v398 = v379;
                    }
                    v403 = US1_1(v398);
                }
            }
        }
    }
    array<Card,5l> v943; int8_t v944;
    switch (v403.tag) {
        case 0: { // None
            array<Card,4l> v405;
            array<Card,3l> v406;
            int32_t v407; int32_t v408; int32_t v409; uint8_t v410;
            Tuple8 tmp12 = Tuple8(0l, 0l, 0l, 12u);
            v407 = tmp12.v0; v408 = tmp12.v1; v409 = tmp12.v2; v410 = tmp12.v3;
            while (while_method_1(v407)){
                Card v412;
                v412 = v73.v[v407];
                bool v413;
                v413 = v409 < 4l;
                int32_t v422; int32_t v423; uint8_t v424;
                if (v413){
                    uint8_t v414;
                    v414 = v412.rank;
                    bool v415;
                    v415 = v410 == v414;
                    int32_t v416;
                    if (v415){
                        v416 = v409;
                    } else {
                        v416 = 0l;
                    }
                    v405.v[v416] = v412;
                    int32_t v417;
                    v417 = v416 + 1l;
                    uint8_t v418;
                    v418 = v412.rank;
                    v422 = v407; v423 = v417; v424 = v418;
                } else {
                    break;
                }
                v408 = v422;
                v409 = v423;
                v410 = v424;
                v407 += 1l ;
            }
            bool v425;
            v425 = v409 == 4l;
            US2 v435;
            if (v425){
                int32_t v426;
                v426 = 0l;
                while (while_method_6(v426)){
                    int32_t v428;
                    v428 = v408 + -3l;
                    bool v429;
                    v429 = v426 < v428;
                    int32_t v430;
                    if (v429){
                        v430 = 0l;
                    } else {
                        v430 = 4l;
                    }
                    int32_t v431;
                    v431 = v430 + v426;
                    Card v432;
                    v432 = v73.v[v431];
                    v406.v[v426] = v432;
                    v426 += 1l ;
                }
                v435 = US2_1(v405, v406);
            } else {
                v435 = US2_0();
            }
            US1 v454;
            switch (v435.tag) {
                case 0: { // None
                    v454 = US1_0();
                    break;
                }
                default: { // Some
                    array<Card,4l> v436 = v435.v.case1.v0; array<Card,3l> v437 = v435.v.case1.v1;
                    array<Card,1l> v438;
                    int32_t v439;
                    v439 = 0l;
                    while (while_method_7(v439)){
                        Card v441;
                        v441 = v437.v[v439];
                        v438.v[v439] = v441;
                        v439 += 1l ;
                    }
                    array<Card,0l> v442;
                    array<Card,5l> v443;
                    int32_t v444;
                    v444 = 0l;
                    while (while_method_8(v444)){
                        Card v446;
                        v446 = v436.v[v444];
                        v443.v[v444] = v446;
                        v444 += 1l ;
                    }
                    int32_t v447;
                    v447 = 0l;
                    while (while_method_7(v447)){
                        Card v449;
                        v449 = v438.v[v447];
                        int32_t v450;
                        v450 = 4l + v447;
                        v443.v[v450] = v449;
                        v447 += 1l ;
                    }
                    v454 = US1_1(v443);
                }
            }
            switch (v454.tag) {
                case 0: { // None
                    array<Card,3l> v456;
                    array<Card,4l> v457;
                    int32_t v458; int32_t v459; int32_t v460; uint8_t v461;
                    Tuple8 tmp13 = Tuple8(0l, 0l, 0l, 12u);
                    v458 = tmp13.v0; v459 = tmp13.v1; v460 = tmp13.v2; v461 = tmp13.v3;
                    while (while_method_1(v458)){
                        Card v463;
                        v463 = v73.v[v458];
                        bool v464;
                        v464 = v460 < 3l;
                        int32_t v473; int32_t v474; uint8_t v475;
                        if (v464){
                            uint8_t v465;
                            v465 = v463.rank;
                            bool v466;
                            v466 = v461 == v465;
                            int32_t v467;
                            if (v466){
                                v467 = v460;
                            } else {
                                v467 = 0l;
                            }
                            v456.v[v467] = v463;
                            int32_t v468;
                            v468 = v467 + 1l;
                            uint8_t v469;
                            v469 = v463.rank;
                            v473 = v458; v474 = v468; v475 = v469;
                        } else {
                            break;
                        }
                        v459 = v473;
                        v460 = v474;
                        v461 = v475;
                        v458 += 1l ;
                    }
                    bool v476;
                    v476 = v460 == 3l;
                    US3 v486;
                    if (v476){
                        int32_t v477;
                        v477 = 0l;
                        while (while_method_8(v477)){
                            int32_t v479;
                            v479 = v459 + -2l;
                            bool v480;
                            v480 = v477 < v479;
                            int32_t v481;
                            if (v480){
                                v481 = 0l;
                            } else {
                                v481 = 3l;
                            }
                            int32_t v482;
                            v482 = v481 + v477;
                            Card v483;
                            v483 = v73.v[v482];
                            v457.v[v477] = v483;
                            v477 += 1l ;
                        }
                        v486 = US3_1(v456, v457);
                    } else {
                        v486 = US3_0();
                    }
                    US1 v537;
                    switch (v486.tag) {
                        case 0: { // None
                            v537 = US1_0();
                            break;
                        }
                        default: { // Some
                            array<Card,3l> v487 = v486.v.case1.v0; array<Card,4l> v488 = v486.v.case1.v1;
                            array<Card,2l> v489;
                            array<Card,2l> v490;
                            int32_t v491; int32_t v492; int32_t v493; uint8_t v494;
                            Tuple8 tmp14 = Tuple8(0l, 0l, 0l, 12u);
                            v491 = tmp14.v0; v492 = tmp14.v1; v493 = tmp14.v2; v494 = tmp14.v3;
                            while (while_method_8(v491)){
                                Card v496;
                                v496 = v488.v[v491];
                                bool v497;
                                v497 = v493 < 2l;
                                int32_t v506; int32_t v507; uint8_t v508;
                                if (v497){
                                    uint8_t v498;
                                    v498 = v496.rank;
                                    bool v499;
                                    v499 = v494 == v498;
                                    int32_t v500;
                                    if (v499){
                                        v500 = v493;
                                    } else {
                                        v500 = 0l;
                                    }
                                    v489.v[v500] = v496;
                                    int32_t v501;
                                    v501 = v500 + 1l;
                                    uint8_t v502;
                                    v502 = v496.rank;
                                    v506 = v491; v507 = v501; v508 = v502;
                                } else {
                                    break;
                                }
                                v492 = v506;
                                v493 = v507;
                                v494 = v508;
                                v491 += 1l ;
                            }
                            bool v509;
                            v509 = v493 == 2l;
                            US4 v519;
                            if (v509){
                                int32_t v510;
                                v510 = 0l;
                                while (while_method_9(v510)){
                                    int32_t v512;
                                    v512 = v492 + -1l;
                                    bool v513;
                                    v513 = v510 < v512;
                                    int32_t v514;
                                    if (v513){
                                        v514 = 0l;
                                    } else {
                                        v514 = 2l;
                                    }
                                    int32_t v515;
                                    v515 = v514 + v510;
                                    Card v516;
                                    v516 = v488.v[v515];
                                    v490.v[v510] = v516;
                                    v510 += 1l ;
                                }
                                v519 = US4_1(v489, v490);
                            } else {
                                v519 = US4_0();
                            }
                            switch (v519.tag) {
                                case 0: { // None
                                    v537 = US1_0();
                                    break;
                                }
                                default: { // Some
                                    array<Card,2l> v520 = v519.v.case1.v0; array<Card,2l> v521 = v519.v.case1.v1;
                                    array<Card,0l> v522;
                                    array<Card,5l> v523;
                                    int32_t v524;
                                    v524 = 0l;
                                    while (while_method_6(v524)){
                                        Card v526;
                                        v526 = v487.v[v524];
                                        v523.v[v524] = v526;
                                        v524 += 1l ;
                                    }
                                    int32_t v527;
                                    v527 = 0l;
                                    while (while_method_9(v527)){
                                        Card v529;
                                        v529 = v520.v[v527];
                                        int32_t v530;
                                        v530 = 3l + v527;
                                        v523.v[v530] = v529;
                                        v527 += 1l ;
                                    }
                                    v537 = US1_1(v523);
                                }
                            }
                        }
                    }
                    switch (v537.tag) {
                        case 0: { // None
                            array<Card,5l> v539;
                            int32_t v540; int32_t v541;
                            Tuple9 tmp15 = Tuple9(0l, 0l);
                            v540 = tmp15.v0; v541 = tmp15.v1;
                            while (while_method_1(v540)){
                                Card v543;
                                v543 = v73.v[v540];
                                uint8_t v544;
                                v544 = v543.suit;
                                bool v545;
                                v545 = v544 == 0u;
                                bool v547;
                                if (v545){
                                    bool v546;
                                    v546 = v541 < 5l;
                                    v547 = v546;
                                } else {
                                    v547 = false;
                                }
                                int32_t v549;
                                if (v547){
                                    v539.v[v541] = v543;
                                    int32_t v548;
                                    v548 = v541 + 1l;
                                    v549 = v548;
                                } else {
                                    v549 = v541;
                                }
                                v541 = v549;
                                v540 += 1l ;
                            }
                            bool v550;
                            v550 = v541 == 5l;
                            US1 v553;
                            if (v550){
                                v553 = US1_1(v539);
                            } else {
                                v553 = US1_0();
                            }
                            array<Card,5l> v554;
                            int32_t v555; int32_t v556;
                            Tuple9 tmp16 = Tuple9(0l, 0l);
                            v555 = tmp16.v0; v556 = tmp16.v1;
                            while (while_method_1(v555)){
                                Card v558;
                                v558 = v73.v[v555];
                                uint8_t v559;
                                v559 = v558.suit;
                                bool v560;
                                v560 = v559 == 1u;
                                bool v562;
                                if (v560){
                                    bool v561;
                                    v561 = v556 < 5l;
                                    v562 = v561;
                                } else {
                                    v562 = false;
                                }
                                int32_t v564;
                                if (v562){
                                    v554.v[v556] = v558;
                                    int32_t v563;
                                    v563 = v556 + 1l;
                                    v564 = v563;
                                } else {
                                    v564 = v556;
                                }
                                v556 = v564;
                                v555 += 1l ;
                            }
                            bool v565;
                            v565 = v556 == 5l;
                            US1 v568;
                            if (v565){
                                v568 = US1_1(v554);
                            } else {
                                v568 = US1_0();
                            }
                            US1 v594;
                            switch (v553.tag) {
                                case 0: { // None
                                    v594 = v568;
                                    break;
                                }
                                default: { // Some
                                    array<Card,5l> v569 = v553.v.case1.v0;
                                    switch (v568.tag) {
                                        case 0: { // None
                                            v594 = v553;
                                            break;
                                        }
                                        default: { // Some
                                            array<Card,5l> v570 = v568.v.case1.v0;
                                            US0 v571;
                                            v571 = US0_0();
                                            int32_t v572; US0 v573;
                                            Tuple7 tmp17 = Tuple7(0l, v571);
                                            v572 = tmp17.v0; v573 = tmp17.v1;
                                            while (while_method_5(v572)){
                                                Card v575;
                                                v575 = v569.v[v572];
                                                Card v576;
                                                v576 = v570.v[v572];
                                                US0 v587;
                                                switch (v573.tag) {
                                                    case 0: { // Eq
                                                        uint8_t v577;
                                                        v577 = v575.rank;
                                                        uint8_t v578;
                                                        v578 = v576.rank;
                                                        bool v579;
                                                        v579 = v577 < v578;
                                                        if (v579){
                                                            v587 = US0_2();
                                                        } else {
                                                            bool v581;
                                                            v581 = v577 > v578;
                                                            if (v581){
                                                                v587 = US0_1();
                                                            } else {
                                                                v587 = US0_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v573 = v587;
                                                v572 += 1l ;
                                            }
                                            bool v588;
                                            switch (v573.tag) {
                                                case 1: { // Gt
                                                    v588 = true;
                                                    break;
                                                }
                                                default: {
                                                    v588 = false;
                                                }
                                            }
                                            array<Card,5l> v589;
                                            if (v588){
                                                v589 = v569;
                                            } else {
                                                v589 = v570;
                                            }
                                            v594 = US1_1(v589);
                                        }
                                    }
                                }
                            }
                            array<Card,5l> v595;
                            int32_t v596; int32_t v597;
                            Tuple9 tmp18 = Tuple9(0l, 0l);
                            v596 = tmp18.v0; v597 = tmp18.v1;
                            while (while_method_1(v596)){
                                Card v599;
                                v599 = v73.v[v596];
                                uint8_t v600;
                                v600 = v599.suit;
                                bool v601;
                                v601 = v600 == 2u;
                                bool v603;
                                if (v601){
                                    bool v602;
                                    v602 = v597 < 5l;
                                    v603 = v602;
                                } else {
                                    v603 = false;
                                }
                                int32_t v605;
                                if (v603){
                                    v595.v[v597] = v599;
                                    int32_t v604;
                                    v604 = v597 + 1l;
                                    v605 = v604;
                                } else {
                                    v605 = v597;
                                }
                                v597 = v605;
                                v596 += 1l ;
                            }
                            bool v606;
                            v606 = v597 == 5l;
                            US1 v609;
                            if (v606){
                                v609 = US1_1(v595);
                            } else {
                                v609 = US1_0();
                            }
                            US1 v635;
                            switch (v594.tag) {
                                case 0: { // None
                                    v635 = v609;
                                    break;
                                }
                                default: { // Some
                                    array<Card,5l> v610 = v594.v.case1.v0;
                                    switch (v609.tag) {
                                        case 0: { // None
                                            v635 = v594;
                                            break;
                                        }
                                        default: { // Some
                                            array<Card,5l> v611 = v609.v.case1.v0;
                                            US0 v612;
                                            v612 = US0_0();
                                            int32_t v613; US0 v614;
                                            Tuple7 tmp19 = Tuple7(0l, v612);
                                            v613 = tmp19.v0; v614 = tmp19.v1;
                                            while (while_method_5(v613)){
                                                Card v616;
                                                v616 = v610.v[v613];
                                                Card v617;
                                                v617 = v611.v[v613];
                                                US0 v628;
                                                switch (v614.tag) {
                                                    case 0: { // Eq
                                                        uint8_t v618;
                                                        v618 = v616.rank;
                                                        uint8_t v619;
                                                        v619 = v617.rank;
                                                        bool v620;
                                                        v620 = v618 < v619;
                                                        if (v620){
                                                            v628 = US0_2();
                                                        } else {
                                                            bool v622;
                                                            v622 = v618 > v619;
                                                            if (v622){
                                                                v628 = US0_1();
                                                            } else {
                                                                v628 = US0_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v614 = v628;
                                                v613 += 1l ;
                                            }
                                            bool v629;
                                            switch (v614.tag) {
                                                case 1: { // Gt
                                                    v629 = true;
                                                    break;
                                                }
                                                default: {
                                                    v629 = false;
                                                }
                                            }
                                            array<Card,5l> v630;
                                            if (v629){
                                                v630 = v610;
                                            } else {
                                                v630 = v611;
                                            }
                                            v635 = US1_1(v630);
                                        }
                                    }
                                }
                            }
                            array<Card,5l> v636;
                            int32_t v637; int32_t v638;
                            Tuple9 tmp20 = Tuple9(0l, 0l);
                            v637 = tmp20.v0; v638 = tmp20.v1;
                            while (while_method_1(v637)){
                                Card v640;
                                v640 = v73.v[v637];
                                uint8_t v641;
                                v641 = v640.suit;
                                bool v642;
                                v642 = v641 == 3u;
                                bool v644;
                                if (v642){
                                    bool v643;
                                    v643 = v638 < 5l;
                                    v644 = v643;
                                } else {
                                    v644 = false;
                                }
                                int32_t v646;
                                if (v644){
                                    v636.v[v638] = v640;
                                    int32_t v645;
                                    v645 = v638 + 1l;
                                    v646 = v645;
                                } else {
                                    v646 = v638;
                                }
                                v638 = v646;
                                v637 += 1l ;
                            }
                            bool v647;
                            v647 = v638 == 5l;
                            US1 v650;
                            if (v647){
                                v650 = US1_1(v636);
                            } else {
                                v650 = US1_0();
                            }
                            US1 v676;
                            switch (v635.tag) {
                                case 0: { // None
                                    v676 = v650;
                                    break;
                                }
                                default: { // Some
                                    array<Card,5l> v651 = v635.v.case1.v0;
                                    switch (v650.tag) {
                                        case 0: { // None
                                            v676 = v635;
                                            break;
                                        }
                                        default: { // Some
                                            array<Card,5l> v652 = v650.v.case1.v0;
                                            US0 v653;
                                            v653 = US0_0();
                                            int32_t v654; US0 v655;
                                            Tuple7 tmp21 = Tuple7(0l, v653);
                                            v654 = tmp21.v0; v655 = tmp21.v1;
                                            while (while_method_5(v654)){
                                                Card v657;
                                                v657 = v651.v[v654];
                                                Card v658;
                                                v658 = v652.v[v654];
                                                US0 v669;
                                                switch (v655.tag) {
                                                    case 0: { // Eq
                                                        uint8_t v659;
                                                        v659 = v657.rank;
                                                        uint8_t v660;
                                                        v660 = v658.rank;
                                                        bool v661;
                                                        v661 = v659 < v660;
                                                        if (v661){
                                                            v669 = US0_2();
                                                        } else {
                                                            bool v663;
                                                            v663 = v659 > v660;
                                                            if (v663){
                                                                v669 = US0_1();
                                                            } else {
                                                                v669 = US0_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v655 = v669;
                                                v654 += 1l ;
                                            }
                                            bool v670;
                                            switch (v655.tag) {
                                                case 1: { // Gt
                                                    v670 = true;
                                                    break;
                                                }
                                                default: {
                                                    v670 = false;
                                                }
                                            }
                                            array<Card,5l> v671;
                                            if (v670){
                                                v671 = v651;
                                            } else {
                                                v671 = v652;
                                            }
                                            v676 = US1_1(v671);
                                        }
                                    }
                                }
                            }
                            switch (v676.tag) {
                                case 0: { // None
                                    array<Card,5l> v678;
                                    int32_t v679; int32_t v680; uint8_t v681;
                                    Tuple6 tmp22 = Tuple6(0l, 0l, 12u);
                                    v679 = tmp22.v0; v680 = tmp22.v1; v681 = tmp22.v2;
                                    while (while_method_1(v679)){
                                        Card v683;
                                        v683 = v73.v[v679];
                                        bool v684;
                                        v684 = v680 < 5l;
                                        int32_t v699; uint8_t v700;
                                        if (v684){
                                            uint8_t v685;
                                            v685 = v683.rank;
                                            uint8_t v686;
                                            v686 = v685 - 1u;
                                            bool v687;
                                            v687 = v681 == v686;
                                            bool v688;
                                            v688 = v687 != true;
                                            if (v688){
                                                uint8_t v689;
                                                v689 = v683.rank;
                                                bool v690;
                                                v690 = v681 == v689;
                                                int32_t v691;
                                                if (v690){
                                                    v691 = v680;
                                                } else {
                                                    v691 = 0l;
                                                }
                                                v678.v[v691] = v683;
                                                int32_t v692;
                                                v692 = v691 + 1l;
                                                uint8_t v693;
                                                v693 = v683.rank;
                                                uint8_t v694;
                                                v694 = v693 - 1u;
                                                v699 = v692; v700 = v694;
                                            } else {
                                                v699 = v680; v700 = v681;
                                            }
                                        } else {
                                            break;
                                        }
                                        v680 = v699;
                                        v681 = v700;
                                        v679 += 1l ;
                                    }
                                    bool v701;
                                    v701 = v680 == 4l;
                                    bool v709;
                                    if (v701){
                                        uint8_t v702;
                                        v702 = v681 + 1u;
                                        bool v703;
                                        v703 = v702 == 0u;
                                        if (v703){
                                            Card v704;
                                            v704 = v73.v[0l];
                                            uint8_t v705;
                                            v705 = v704.rank;
                                            bool v706;
                                            v706 = v705 == 12u;
                                            if (v706){
                                                v678.v[4l] = v704;
                                                v709 = true;
                                            } else {
                                                v709 = false;
                                            }
                                        } else {
                                            v709 = false;
                                        }
                                    } else {
                                        v709 = false;
                                    }
                                    US1 v715;
                                    if (v709){
                                        v715 = US1_1(v678);
                                    } else {
                                        bool v711;
                                        v711 = v680 == 5l;
                                        if (v711){
                                            v715 = US1_1(v678);
                                        } else {
                                            v715 = US1_0();
                                        }
                                    }
                                    switch (v715.tag) {
                                        case 0: { // None
                                            array<Card,3l> v717;
                                            array<Card,4l> v718;
                                            int32_t v719; int32_t v720; int32_t v721; uint8_t v722;
                                            Tuple8 tmp23 = Tuple8(0l, 0l, 0l, 12u);
                                            v719 = tmp23.v0; v720 = tmp23.v1; v721 = tmp23.v2; v722 = tmp23.v3;
                                            while (while_method_1(v719)){
                                                Card v724;
                                                v724 = v73.v[v719];
                                                bool v725;
                                                v725 = v721 < 3l;
                                                int32_t v734; int32_t v735; uint8_t v736;
                                                if (v725){
                                                    uint8_t v726;
                                                    v726 = v724.rank;
                                                    bool v727;
                                                    v727 = v722 == v726;
                                                    int32_t v728;
                                                    if (v727){
                                                        v728 = v721;
                                                    } else {
                                                        v728 = 0l;
                                                    }
                                                    v717.v[v728] = v724;
                                                    int32_t v729;
                                                    v729 = v728 + 1l;
                                                    uint8_t v730;
                                                    v730 = v724.rank;
                                                    v734 = v719; v735 = v729; v736 = v730;
                                                } else {
                                                    break;
                                                }
                                                v720 = v734;
                                                v721 = v735;
                                                v722 = v736;
                                                v719 += 1l ;
                                            }
                                            bool v737;
                                            v737 = v721 == 3l;
                                            US3 v747;
                                            if (v737){
                                                int32_t v738;
                                                v738 = 0l;
                                                while (while_method_8(v738)){
                                                    int32_t v740;
                                                    v740 = v720 + -2l;
                                                    bool v741;
                                                    v741 = v738 < v740;
                                                    int32_t v742;
                                                    if (v741){
                                                        v742 = 0l;
                                                    } else {
                                                        v742 = 3l;
                                                    }
                                                    int32_t v743;
                                                    v743 = v742 + v738;
                                                    Card v744;
                                                    v744 = v73.v[v743];
                                                    v718.v[v738] = v744;
                                                    v738 += 1l ;
                                                }
                                                v747 = US3_1(v717, v718);
                                            } else {
                                                v747 = US3_0();
                                            }
                                            US1 v766;
                                            switch (v747.tag) {
                                                case 0: { // None
                                                    v766 = US1_0();
                                                    break;
                                                }
                                                default: { // Some
                                                    array<Card,3l> v748 = v747.v.case1.v0; array<Card,4l> v749 = v747.v.case1.v1;
                                                    array<Card,2l> v750;
                                                    int32_t v751;
                                                    v751 = 0l;
                                                    while (while_method_9(v751)){
                                                        Card v753;
                                                        v753 = v749.v[v751];
                                                        v750.v[v751] = v753;
                                                        v751 += 1l ;
                                                    }
                                                    array<Card,0l> v754;
                                                    array<Card,5l> v755;
                                                    int32_t v756;
                                                    v756 = 0l;
                                                    while (while_method_6(v756)){
                                                        Card v758;
                                                        v758 = v748.v[v756];
                                                        v755.v[v756] = v758;
                                                        v756 += 1l ;
                                                    }
                                                    int32_t v759;
                                                    v759 = 0l;
                                                    while (while_method_9(v759)){
                                                        Card v761;
                                                        v761 = v750.v[v759];
                                                        int32_t v762;
                                                        v762 = 3l + v759;
                                                        v755.v[v762] = v761;
                                                        v759 += 1l ;
                                                    }
                                                    v766 = US1_1(v755);
                                                }
                                            }
                                            switch (v766.tag) {
                                                case 0: { // None
                                                    array<Card,2l> v768;
                                                    array<Card,5l> v769;
                                                    int32_t v770; int32_t v771; int32_t v772; uint8_t v773;
                                                    Tuple8 tmp24 = Tuple8(0l, 0l, 0l, 12u);
                                                    v770 = tmp24.v0; v771 = tmp24.v1; v772 = tmp24.v2; v773 = tmp24.v3;
                                                    while (while_method_1(v770)){
                                                        Card v775;
                                                        v775 = v73.v[v770];
                                                        bool v776;
                                                        v776 = v772 < 2l;
                                                        int32_t v785; int32_t v786; uint8_t v787;
                                                        if (v776){
                                                            uint8_t v777;
                                                            v777 = v775.rank;
                                                            bool v778;
                                                            v778 = v773 == v777;
                                                            int32_t v779;
                                                            if (v778){
                                                                v779 = v772;
                                                            } else {
                                                                v779 = 0l;
                                                            }
                                                            v768.v[v779] = v775;
                                                            int32_t v780;
                                                            v780 = v779 + 1l;
                                                            uint8_t v781;
                                                            v781 = v775.rank;
                                                            v785 = v770; v786 = v780; v787 = v781;
                                                        } else {
                                                            break;
                                                        }
                                                        v771 = v785;
                                                        v772 = v786;
                                                        v773 = v787;
                                                        v770 += 1l ;
                                                    }
                                                    bool v788;
                                                    v788 = v772 == 2l;
                                                    US5 v798;
                                                    if (v788){
                                                        int32_t v789;
                                                        v789 = 0l;
                                                        while (while_method_5(v789)){
                                                            int32_t v791;
                                                            v791 = v771 + -1l;
                                                            bool v792;
                                                            v792 = v789 < v791;
                                                            int32_t v793;
                                                            if (v792){
                                                                v793 = 0l;
                                                            } else {
                                                                v793 = 2l;
                                                            }
                                                            int32_t v794;
                                                            v794 = v793 + v789;
                                                            Card v795;
                                                            v795 = v73.v[v794];
                                                            v769.v[v789] = v795;
                                                            v789 += 1l ;
                                                        }
                                                        v798 = US5_1(v768, v769);
                                                    } else {
                                                        v798 = US5_0();
                                                    }
                                                    US1 v856;
                                                    switch (v798.tag) {
                                                        case 0: { // None
                                                            v856 = US1_0();
                                                            break;
                                                        }
                                                        default: { // Some
                                                            array<Card,2l> v799 = v798.v.case1.v0; array<Card,5l> v800 = v798.v.case1.v1;
                                                            array<Card,2l> v801;
                                                            array<Card,3l> v802;
                                                            int32_t v803; int32_t v804; int32_t v805; uint8_t v806;
                                                            Tuple8 tmp25 = Tuple8(0l, 0l, 0l, 12u);
                                                            v803 = tmp25.v0; v804 = tmp25.v1; v805 = tmp25.v2; v806 = tmp25.v3;
                                                            while (while_method_5(v803)){
                                                                Card v808;
                                                                v808 = v800.v[v803];
                                                                bool v809;
                                                                v809 = v805 < 2l;
                                                                int32_t v818; int32_t v819; uint8_t v820;
                                                                if (v809){
                                                                    uint8_t v810;
                                                                    v810 = v808.rank;
                                                                    bool v811;
                                                                    v811 = v806 == v810;
                                                                    int32_t v812;
                                                                    if (v811){
                                                                        v812 = v805;
                                                                    } else {
                                                                        v812 = 0l;
                                                                    }
                                                                    v801.v[v812] = v808;
                                                                    int32_t v813;
                                                                    v813 = v812 + 1l;
                                                                    uint8_t v814;
                                                                    v814 = v808.rank;
                                                                    v818 = v803; v819 = v813; v820 = v814;
                                                                } else {
                                                                    break;
                                                                }
                                                                v804 = v818;
                                                                v805 = v819;
                                                                v806 = v820;
                                                                v803 += 1l ;
                                                            }
                                                            bool v821;
                                                            v821 = v805 == 2l;
                                                            US6 v831;
                                                            if (v821){
                                                                int32_t v822;
                                                                v822 = 0l;
                                                                while (while_method_6(v822)){
                                                                    int32_t v824;
                                                                    v824 = v804 + -1l;
                                                                    bool v825;
                                                                    v825 = v822 < v824;
                                                                    int32_t v826;
                                                                    if (v825){
                                                                        v826 = 0l;
                                                                    } else {
                                                                        v826 = 2l;
                                                                    }
                                                                    int32_t v827;
                                                                    v827 = v826 + v822;
                                                                    Card v828;
                                                                    v828 = v800.v[v827];
                                                                    v802.v[v822] = v828;
                                                                    v822 += 1l ;
                                                                }
                                                                v831 = US6_1(v801, v802);
                                                            } else {
                                                                v831 = US6_0();
                                                            }
                                                            switch (v831.tag) {
                                                                case 0: { // None
                                                                    v856 = US1_0();
                                                                    break;
                                                                }
                                                                default: { // Some
                                                                    array<Card,2l> v832 = v831.v.case1.v0; array<Card,3l> v833 = v831.v.case1.v1;
                                                                    array<Card,1l> v834;
                                                                    int32_t v835;
                                                                    v835 = 0l;
                                                                    while (while_method_7(v835)){
                                                                        Card v837;
                                                                        v837 = v833.v[v835];
                                                                        v834.v[v835] = v837;
                                                                        v835 += 1l ;
                                                                    }
                                                                    array<Card,5l> v838;
                                                                    int32_t v839;
                                                                    v839 = 0l;
                                                                    while (while_method_9(v839)){
                                                                        Card v841;
                                                                        v841 = v799.v[v839];
                                                                        v838.v[v839] = v841;
                                                                        v839 += 1l ;
                                                                    }
                                                                    int32_t v842;
                                                                    v842 = 0l;
                                                                    while (while_method_9(v842)){
                                                                        Card v844;
                                                                        v844 = v832.v[v842];
                                                                        int32_t v845;
                                                                        v845 = 2l + v842;
                                                                        v838.v[v845] = v844;
                                                                        v842 += 1l ;
                                                                    }
                                                                    int32_t v846;
                                                                    v846 = 0l;
                                                                    while (while_method_7(v846)){
                                                                        Card v848;
                                                                        v848 = v834.v[v846];
                                                                        int32_t v849;
                                                                        v849 = 4l + v846;
                                                                        v838.v[v849] = v848;
                                                                        v846 += 1l ;
                                                                    }
                                                                    v856 = US1_1(v838);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    switch (v856.tag) {
                                                        case 0: { // None
                                                            array<Card,2l> v858;
                                                            array<Card,5l> v859;
                                                            int32_t v860; int32_t v861; int32_t v862; uint8_t v863;
                                                            Tuple8 tmp26 = Tuple8(0l, 0l, 0l, 12u);
                                                            v860 = tmp26.v0; v861 = tmp26.v1; v862 = tmp26.v2; v863 = tmp26.v3;
                                                            while (while_method_1(v860)){
                                                                Card v865;
                                                                v865 = v73.v[v860];
                                                                bool v866;
                                                                v866 = v862 < 2l;
                                                                int32_t v875; int32_t v876; uint8_t v877;
                                                                if (v866){
                                                                    uint8_t v867;
                                                                    v867 = v865.rank;
                                                                    bool v868;
                                                                    v868 = v863 == v867;
                                                                    int32_t v869;
                                                                    if (v868){
                                                                        v869 = v862;
                                                                    } else {
                                                                        v869 = 0l;
                                                                    }
                                                                    v858.v[v869] = v865;
                                                                    int32_t v870;
                                                                    v870 = v869 + 1l;
                                                                    uint8_t v871;
                                                                    v871 = v865.rank;
                                                                    v875 = v860; v876 = v870; v877 = v871;
                                                                } else {
                                                                    break;
                                                                }
                                                                v861 = v875;
                                                                v862 = v876;
                                                                v863 = v877;
                                                                v860 += 1l ;
                                                            }
                                                            bool v878;
                                                            v878 = v862 == 2l;
                                                            US5 v888;
                                                            if (v878){
                                                                int32_t v879;
                                                                v879 = 0l;
                                                                while (while_method_5(v879)){
                                                                    int32_t v881;
                                                                    v881 = v861 + -1l;
                                                                    bool v882;
                                                                    v882 = v879 < v881;
                                                                    int32_t v883;
                                                                    if (v882){
                                                                        v883 = 0l;
                                                                    } else {
                                                                        v883 = 2l;
                                                                    }
                                                                    int32_t v884;
                                                                    v884 = v883 + v879;
                                                                    Card v885;
                                                                    v885 = v73.v[v884];
                                                                    v859.v[v879] = v885;
                                                                    v879 += 1l ;
                                                                }
                                                                v888 = US5_1(v858, v859);
                                                            } else {
                                                                v888 = US5_0();
                                                            }
                                                            US1 v907;
                                                            switch (v888.tag) {
                                                                case 0: { // None
                                                                    v907 = US1_0();
                                                                    break;
                                                                }
                                                                default: { // Some
                                                                    array<Card,2l> v889 = v888.v.case1.v0; array<Card,5l> v890 = v888.v.case1.v1;
                                                                    array<Card,3l> v891;
                                                                    int32_t v892;
                                                                    v892 = 0l;
                                                                    while (while_method_6(v892)){
                                                                        Card v894;
                                                                        v894 = v890.v[v892];
                                                                        v891.v[v892] = v894;
                                                                        v892 += 1l ;
                                                                    }
                                                                    array<Card,0l> v895;
                                                                    array<Card,5l> v896;
                                                                    int32_t v897;
                                                                    v897 = 0l;
                                                                    while (while_method_9(v897)){
                                                                        Card v899;
                                                                        v899 = v889.v[v897];
                                                                        v896.v[v897] = v899;
                                                                        v897 += 1l ;
                                                                    }
                                                                    int32_t v900;
                                                                    v900 = 0l;
                                                                    while (while_method_6(v900)){
                                                                        Card v902;
                                                                        v902 = v891.v[v900];
                                                                        int32_t v903;
                                                                        v903 = 2l + v900;
                                                                        v896.v[v903] = v902;
                                                                        v900 += 1l ;
                                                                    }
                                                                    v907 = US1_1(v896);
                                                                }
                                                            }
                                                            switch (v907.tag) {
                                                                case 0: { // None
                                                                    array<Card,5l> v909;
                                                                    int32_t v910;
                                                                    v910 = 0l;
                                                                    while (while_method_5(v910)){
                                                                        Card v912;
                                                                        v912 = v73.v[v910];
                                                                        v909.v[v910] = v912;
                                                                        v910 += 1l ;
                                                                    }
                                                                    v943 = v909; v944 = 0;
                                                                    break;
                                                                }
                                                                default: { // Some
                                                                    array<Card,5l> v908 = v907.v.case1.v0;
                                                                    v943 = v908; v944 = 1;
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        default: { // Some
                                                            array<Card,5l> v857 = v856.v.case1.v0;
                                                            v943 = v857; v944 = 2;
                                                        }
                                                    }
                                                    break;
                                                }
                                                default: { // Some
                                                    array<Card,5l> v767 = v766.v.case1.v0;
                                                    v943 = v767; v944 = 3;
                                                }
                                            }
                                            break;
                                        }
                                        default: { // Some
                                            array<Card,5l> v716 = v715.v.case1.v0;
                                            v943 = v716; v944 = 4;
                                        }
                                    }
                                    break;
                                }
                                default: { // Some
                                    array<Card,5l> v677 = v676.v.case1.v0;
                                    v943 = v677; v944 = 5;
                                }
                            }
                            break;
                        }
                        default: { // Some
                            array<Card,5l> v538 = v537.v.case1.v0;
                            v943 = v538; v944 = 6;
                        }
                    }
                    break;
                }
                default: { // Some
                    array<Card,5l> v455 = v454.v.case1.v0;
                    v943 = v455; v944 = 7;
                }
            }
            break;
        }
        default: { // Some
            array<Card,5l> v404 = v403.v.case1.v0;
            v943 = v404; v944 = 8;
        }
    }
    return Tuple3(v943, v944);
}
__device__ US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
__device__ US7 US7_1(array<Card,5l> v0, int8_t v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ Tuple3 score_4(array<Card,7l> v0){
    array<Card,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_1(v2)){
        Card v4;
        v4 = v0.v[v2];
        v1.v[v2] = v4;
        v2 += 1l ;
    }
    array<Card,7l> v5;
    bool v6; int32_t v7;
    Tuple4 tmp28 = Tuple4(true, 1l);
    v6 = tmp28.v0; v7 = tmp28.v1;
    while (while_method_2(v1, v6, v7)){
        int32_t v9;
        v9 = 0l;
        while (while_method_3(v1, v9)){
            int32_t v11;
            v11 = v9 + v7;
            bool v12;
            v12 = v11 < 7l;
            int32_t v13;
            if (v12){
                v13 = v11;
            } else {
                v13 = 7l;
            }
            int32_t v14;
            v14 = v7 * 2l;
            int32_t v15;
            v15 = v9 + v14;
            bool v16;
            v16 = v15 < 7l;
            int32_t v17;
            if (v16){
                v17 = v15;
            } else {
                v17 = 7l;
            }
            int32_t v18; int32_t v19; int32_t v20;
            Tuple5 tmp29 = Tuple5(v9, v13, v9);
            v18 = tmp29.v0; v19 = tmp29.v1; v20 = tmp29.v2;
            while (while_method_4(v17, v18, v19, v20)){
                bool v22;
                v22 = v18 < v13;
                bool v24;
                if (v22){
                    bool v23;
                    v23 = v19 < v17;
                    v24 = v23;
                } else {
                    v24 = false;
                }
                Card v66; int32_t v67; int32_t v68;
                if (v24){
                    Card v27;
                    if (v6){
                        Card v25;
                        v25 = v1.v[v18];
                        v27 = v25;
                    } else {
                        Card v26;
                        v26 = v5.v[v18];
                        v27 = v26;
                    }
                    Card v30;
                    if (v6){
                        Card v28;
                        v28 = v1.v[v19];
                        v30 = v28;
                    } else {
                        Card v29;
                        v29 = v5.v[v19];
                        v30 = v29;
                    }
                    uint8_t v31;
                    v31 = v30.rank;
                    uint8_t v32;
                    v32 = v27.rank;
                    bool v33;
                    v33 = v31 < v32;
                    US0 v39;
                    if (v33){
                        v39 = US0_2();
                    } else {
                        bool v35;
                        v35 = v31 > v32;
                        if (v35){
                            v39 = US0_1();
                        } else {
                            v39 = US0_0();
                        }
                    }
                    US0 v49;
                    switch (v39.tag) {
                        case 0: { // Eq
                            uint8_t v40;
                            v40 = v27.suit;
                            uint8_t v41;
                            v41 = v30.suit;
                            bool v42;
                            v42 = v40 < v41;
                            if (v42){
                                v49 = US0_2();
                            } else {
                                bool v44;
                                v44 = v40 > v41;
                                if (v44){
                                    v49 = US0_1();
                                } else {
                                    v49 = US0_0();
                                }
                            }
                            break;
                        }
                        default: {
                            v49 = v39;
                        }
                    }
                    switch (v49.tag) {
                        case 1: { // Gt
                            int32_t v50;
                            v50 = v19 + 1l;
                            v66 = v30; v67 = v18; v68 = v50;
                            break;
                        }
                        default: {
                            int32_t v51;
                            v51 = v18 + 1l;
                            v66 = v27; v67 = v51; v68 = v19;
                        }
                    }
                } else {
                    if (v22){
                        Card v57;
                        if (v6){
                            Card v55;
                            v55 = v1.v[v18];
                            v57 = v55;
                        } else {
                            Card v56;
                            v56 = v5.v[v18];
                            v57 = v56;
                        }
                        int32_t v58;
                        v58 = v18 + 1l;
                        v66 = v57; v67 = v58; v68 = v19;
                    } else {
                        Card v61;
                        if (v6){
                            Card v59;
                            v59 = v1.v[v19];
                            v61 = v59;
                        } else {
                            Card v60;
                            v60 = v5.v[v19];
                            v61 = v60;
                        }
                        int32_t v62;
                        v62 = v19 + 1l;
                        v66 = v61; v67 = v18; v68 = v62;
                    }
                }
                if (v6){
                    v5.v[v20] = v66;
                } else {
                    v1.v[v20] = v66;
                }
                int32_t v69;
                v69 = v20 + 1l;
                v18 = v67;
                v19 = v68;
                v20 = v69;
            }
            v9 = v15;
        }
        bool v70;
        v70 = v6 == false;
        int32_t v71;
        v71 = v7 * 2l;
        v6 = v70;
        v7 = v71;
    }
    bool v72;
    v72 = v6 == false;
    array<Card,7l> v73;
    if (v72){
        v73 = v5;
    } else {
        v73 = v1;
    }
    array<Card,5l> v74;
    int32_t v75;
    v75 = 0l;
    while (while_method_5(v75)){
        Card v77;
        v77 = v73.v[v75];
        v74.v[v75] = v77;
        v75 += 1l ;
    }
    array<Card,2l> v78;
    array<Card,5l> v79;
    int32_t v80; int32_t v81; int32_t v82; uint8_t v83;
    Tuple8 tmp30 = Tuple8(0l, 0l, 0l, 12u);
    v80 = tmp30.v0; v81 = tmp30.v1; v82 = tmp30.v2; v83 = tmp30.v3;
    while (while_method_1(v80)){
        Card v85;
        v85 = v73.v[v80];
        bool v86;
        v86 = v82 < 2l;
        int32_t v95; int32_t v96; uint8_t v97;
        if (v86){
            uint8_t v87;
            v87 = v85.rank;
            bool v88;
            v88 = v83 == v87;
            int32_t v89;
            if (v88){
                v89 = v82;
            } else {
                v89 = 0l;
            }
            v78.v[v89] = v85;
            int32_t v90;
            v90 = v89 + 1l;
            uint8_t v91;
            v91 = v85.rank;
            v95 = v80; v96 = v90; v97 = v91;
        } else {
            break;
        }
        v81 = v95;
        v82 = v96;
        v83 = v97;
        v80 += 1l ;
    }
    bool v98;
    v98 = v82 == 2l;
    US5 v108;
    if (v98){
        int32_t v99;
        v99 = 0l;
        while (while_method_5(v99)){
            int32_t v101;
            v101 = v81 + -1l;
            bool v102;
            v102 = v99 < v101;
            int32_t v103;
            if (v102){
                v103 = 0l;
            } else {
                v103 = 2l;
            }
            int32_t v104;
            v104 = v103 + v99;
            Card v105;
            v105 = v73.v[v104];
            v79.v[v99] = v105;
            v99 += 1l ;
        }
        v108 = US5_1(v78, v79);
    } else {
        v108 = US5_0();
    }
    US1 v127;
    switch (v108.tag) {
        case 0: { // None
            v127 = US1_0();
            break;
        }
        default: { // Some
            array<Card,2l> v109 = v108.v.case1.v0; array<Card,5l> v110 = v108.v.case1.v1;
            array<Card,3l> v111;
            int32_t v112;
            v112 = 0l;
            while (while_method_6(v112)){
                Card v114;
                v114 = v110.v[v112];
                v111.v[v112] = v114;
                v112 += 1l ;
            }
            array<Card,0l> v115;
            array<Card,5l> v116;
            int32_t v117;
            v117 = 0l;
            while (while_method_9(v117)){
                Card v119;
                v119 = v109.v[v117];
                v116.v[v117] = v119;
                v117 += 1l ;
            }
            int32_t v120;
            v120 = 0l;
            while (while_method_6(v120)){
                Card v122;
                v122 = v111.v[v120];
                int32_t v123;
                v123 = 2l + v120;
                v116.v[v123] = v122;
                v120 += 1l ;
            }
            v127 = US1_1(v116);
        }
    }
    array<Card,2l> v128;
    array<Card,5l> v129;
    int32_t v130; int32_t v131; int32_t v132; uint8_t v133;
    Tuple8 tmp31 = Tuple8(0l, 0l, 0l, 12u);
    v130 = tmp31.v0; v131 = tmp31.v1; v132 = tmp31.v2; v133 = tmp31.v3;
    while (while_method_1(v130)){
        Card v135;
        v135 = v73.v[v130];
        bool v136;
        v136 = v132 < 2l;
        int32_t v145; int32_t v146; uint8_t v147;
        if (v136){
            uint8_t v137;
            v137 = v135.rank;
            bool v138;
            v138 = v133 == v137;
            int32_t v139;
            if (v138){
                v139 = v132;
            } else {
                v139 = 0l;
            }
            v128.v[v139] = v135;
            int32_t v140;
            v140 = v139 + 1l;
            uint8_t v141;
            v141 = v135.rank;
            v145 = v130; v146 = v140; v147 = v141;
        } else {
            break;
        }
        v131 = v145;
        v132 = v146;
        v133 = v147;
        v130 += 1l ;
    }
    bool v148;
    v148 = v132 == 2l;
    US5 v158;
    if (v148){
        int32_t v149;
        v149 = 0l;
        while (while_method_5(v149)){
            int32_t v151;
            v151 = v131 + -1l;
            bool v152;
            v152 = v149 < v151;
            int32_t v153;
            if (v152){
                v153 = 0l;
            } else {
                v153 = 2l;
            }
            int32_t v154;
            v154 = v153 + v149;
            Card v155;
            v155 = v73.v[v154];
            v129.v[v149] = v155;
            v149 += 1l ;
        }
        v158 = US5_1(v128, v129);
    } else {
        v158 = US5_0();
    }
    US1 v216;
    switch (v158.tag) {
        case 0: { // None
            v216 = US1_0();
            break;
        }
        default: { // Some
            array<Card,2l> v159 = v158.v.case1.v0; array<Card,5l> v160 = v158.v.case1.v1;
            array<Card,2l> v161;
            array<Card,3l> v162;
            int32_t v163; int32_t v164; int32_t v165; uint8_t v166;
            Tuple8 tmp32 = Tuple8(0l, 0l, 0l, 12u);
            v163 = tmp32.v0; v164 = tmp32.v1; v165 = tmp32.v2; v166 = tmp32.v3;
            while (while_method_5(v163)){
                Card v168;
                v168 = v160.v[v163];
                bool v169;
                v169 = v165 < 2l;
                int32_t v178; int32_t v179; uint8_t v180;
                if (v169){
                    uint8_t v170;
                    v170 = v168.rank;
                    bool v171;
                    v171 = v166 == v170;
                    int32_t v172;
                    if (v171){
                        v172 = v165;
                    } else {
                        v172 = 0l;
                    }
                    v161.v[v172] = v168;
                    int32_t v173;
                    v173 = v172 + 1l;
                    uint8_t v174;
                    v174 = v168.rank;
                    v178 = v163; v179 = v173; v180 = v174;
                } else {
                    break;
                }
                v164 = v178;
                v165 = v179;
                v166 = v180;
                v163 += 1l ;
            }
            bool v181;
            v181 = v165 == 2l;
            US6 v191;
            if (v181){
                int32_t v182;
                v182 = 0l;
                while (while_method_6(v182)){
                    int32_t v184;
                    v184 = v164 + -1l;
                    bool v185;
                    v185 = v182 < v184;
                    int32_t v186;
                    if (v185){
                        v186 = 0l;
                    } else {
                        v186 = 2l;
                    }
                    int32_t v187;
                    v187 = v186 + v182;
                    Card v188;
                    v188 = v160.v[v187];
                    v162.v[v182] = v188;
                    v182 += 1l ;
                }
                v191 = US6_1(v161, v162);
            } else {
                v191 = US6_0();
            }
            switch (v191.tag) {
                case 0: { // None
                    v216 = US1_0();
                    break;
                }
                default: { // Some
                    array<Card,2l> v192 = v191.v.case1.v0; array<Card,3l> v193 = v191.v.case1.v1;
                    array<Card,1l> v194;
                    int32_t v195;
                    v195 = 0l;
                    while (while_method_7(v195)){
                        Card v197;
                        v197 = v193.v[v195];
                        v194.v[v195] = v197;
                        v195 += 1l ;
                    }
                    array<Card,5l> v198;
                    int32_t v199;
                    v199 = 0l;
                    while (while_method_9(v199)){
                        Card v201;
                        v201 = v159.v[v199];
                        v198.v[v199] = v201;
                        v199 += 1l ;
                    }
                    int32_t v202;
                    v202 = 0l;
                    while (while_method_9(v202)){
                        Card v204;
                        v204 = v192.v[v202];
                        int32_t v205;
                        v205 = 2l + v202;
                        v198.v[v205] = v204;
                        v202 += 1l ;
                    }
                    int32_t v206;
                    v206 = 0l;
                    while (while_method_7(v206)){
                        Card v208;
                        v208 = v194.v[v206];
                        int32_t v209;
                        v209 = 4l + v206;
                        v198.v[v209] = v208;
                        v206 += 1l ;
                    }
                    v216 = US1_1(v198);
                }
            }
        }
    }
    array<Card,3l> v217;
    array<Card,4l> v218;
    int32_t v219; int32_t v220; int32_t v221; uint8_t v222;
    Tuple8 tmp33 = Tuple8(0l, 0l, 0l, 12u);
    v219 = tmp33.v0; v220 = tmp33.v1; v221 = tmp33.v2; v222 = tmp33.v3;
    while (while_method_1(v219)){
        Card v224;
        v224 = v73.v[v219];
        bool v225;
        v225 = v221 < 3l;
        int32_t v234; int32_t v235; uint8_t v236;
        if (v225){
            uint8_t v226;
            v226 = v224.rank;
            bool v227;
            v227 = v222 == v226;
            int32_t v228;
            if (v227){
                v228 = v221;
            } else {
                v228 = 0l;
            }
            v217.v[v228] = v224;
            int32_t v229;
            v229 = v228 + 1l;
            uint8_t v230;
            v230 = v224.rank;
            v234 = v219; v235 = v229; v236 = v230;
        } else {
            break;
        }
        v220 = v234;
        v221 = v235;
        v222 = v236;
        v219 += 1l ;
    }
    bool v237;
    v237 = v221 == 3l;
    US3 v247;
    if (v237){
        int32_t v238;
        v238 = 0l;
        while (while_method_8(v238)){
            int32_t v240;
            v240 = v220 + -2l;
            bool v241;
            v241 = v238 < v240;
            int32_t v242;
            if (v241){
                v242 = 0l;
            } else {
                v242 = 3l;
            }
            int32_t v243;
            v243 = v242 + v238;
            Card v244;
            v244 = v73.v[v243];
            v218.v[v238] = v244;
            v238 += 1l ;
        }
        v247 = US3_1(v217, v218);
    } else {
        v247 = US3_0();
    }
    US1 v266;
    switch (v247.tag) {
        case 0: { // None
            v266 = US1_0();
            break;
        }
        default: { // Some
            array<Card,3l> v248 = v247.v.case1.v0; array<Card,4l> v249 = v247.v.case1.v1;
            array<Card,2l> v250;
            int32_t v251;
            v251 = 0l;
            while (while_method_9(v251)){
                Card v253;
                v253 = v249.v[v251];
                v250.v[v251] = v253;
                v251 += 1l ;
            }
            array<Card,0l> v254;
            array<Card,5l> v255;
            int32_t v256;
            v256 = 0l;
            while (while_method_6(v256)){
                Card v258;
                v258 = v248.v[v256];
                v255.v[v256] = v258;
                v256 += 1l ;
            }
            int32_t v259;
            v259 = 0l;
            while (while_method_9(v259)){
                Card v261;
                v261 = v250.v[v259];
                int32_t v262;
                v262 = 3l + v259;
                v255.v[v262] = v261;
                v259 += 1l ;
            }
            v266 = US1_1(v255);
        }
    }
    array<Card,5l> v267;
    int32_t v268; int32_t v269; uint8_t v270;
    Tuple6 tmp34 = Tuple6(0l, 0l, 12u);
    v268 = tmp34.v0; v269 = tmp34.v1; v270 = tmp34.v2;
    while (while_method_1(v268)){
        Card v272;
        v272 = v73.v[v268];
        bool v273;
        v273 = v269 < 5l;
        int32_t v288; uint8_t v289;
        if (v273){
            uint8_t v274;
            v274 = v272.rank;
            uint8_t v275;
            v275 = v274 - 1u;
            bool v276;
            v276 = v270 == v275;
            bool v277;
            v277 = v276 != true;
            if (v277){
                uint8_t v278;
                v278 = v272.rank;
                bool v279;
                v279 = v270 == v278;
                int32_t v280;
                if (v279){
                    v280 = v269;
                } else {
                    v280 = 0l;
                }
                v267.v[v280] = v272;
                int32_t v281;
                v281 = v280 + 1l;
                uint8_t v282;
                v282 = v272.rank;
                uint8_t v283;
                v283 = v282 - 1u;
                v288 = v281; v289 = v283;
            } else {
                v288 = v269; v289 = v270;
            }
        } else {
            break;
        }
        v269 = v288;
        v270 = v289;
        v268 += 1l ;
    }
    bool v290;
    v290 = v269 == 4l;
    bool v298;
    if (v290){
        uint8_t v291;
        v291 = v270 + 1u;
        bool v292;
        v292 = v291 == 0u;
        if (v292){
            Card v293;
            v293 = v73.v[0l];
            uint8_t v294;
            v294 = v293.rank;
            bool v295;
            v295 = v294 == 12u;
            if (v295){
                v267.v[4l] = v293;
                v298 = true;
            } else {
                v298 = false;
            }
        } else {
            v298 = false;
        }
    } else {
        v298 = false;
    }
    US1 v304;
    if (v298){
        v304 = US1_1(v267);
    } else {
        bool v300;
        v300 = v269 == 5l;
        if (v300){
            v304 = US1_1(v267);
        } else {
            v304 = US1_0();
        }
    }
    array<Card,5l> v305;
    int32_t v306; int32_t v307;
    Tuple9 tmp35 = Tuple9(0l, 0l);
    v306 = tmp35.v0; v307 = tmp35.v1;
    while (while_method_1(v306)){
        Card v309;
        v309 = v73.v[v306];
        uint8_t v310;
        v310 = v309.suit;
        bool v311;
        v311 = v310 == 3u;
        bool v313;
        if (v311){
            bool v312;
            v312 = v307 < 5l;
            v313 = v312;
        } else {
            v313 = false;
        }
        int32_t v315;
        if (v313){
            v305.v[v307] = v309;
            int32_t v314;
            v314 = v307 + 1l;
            v315 = v314;
        } else {
            v315 = v307;
        }
        v307 = v315;
        v306 += 1l ;
    }
    bool v316;
    v316 = v307 == 5l;
    US1 v319;
    if (v316){
        v319 = US1_1(v305);
    } else {
        v319 = US1_0();
    }
    array<Card,5l> v320;
    int32_t v321; int32_t v322;
    Tuple9 tmp36 = Tuple9(0l, 0l);
    v321 = tmp36.v0; v322 = tmp36.v1;
    while (while_method_1(v321)){
        Card v324;
        v324 = v73.v[v321];
        uint8_t v325;
        v325 = v324.suit;
        bool v326;
        v326 = v325 == 2u;
        bool v328;
        if (v326){
            bool v327;
            v327 = v322 < 5l;
            v328 = v327;
        } else {
            v328 = false;
        }
        int32_t v330;
        if (v328){
            v320.v[v322] = v324;
            int32_t v329;
            v329 = v322 + 1l;
            v330 = v329;
        } else {
            v330 = v322;
        }
        v322 = v330;
        v321 += 1l ;
    }
    bool v331;
    v331 = v322 == 5l;
    US1 v334;
    if (v331){
        v334 = US1_1(v320);
    } else {
        v334 = US1_0();
    }
    array<Card,5l> v335;
    int32_t v336; int32_t v337;
    Tuple9 tmp37 = Tuple9(0l, 0l);
    v336 = tmp37.v0; v337 = tmp37.v1;
    while (while_method_1(v336)){
        Card v339;
        v339 = v73.v[v336];
        uint8_t v340;
        v340 = v339.suit;
        bool v341;
        v341 = v340 == 1u;
        bool v343;
        if (v341){
            bool v342;
            v342 = v337 < 5l;
            v343 = v342;
        } else {
            v343 = false;
        }
        int32_t v345;
        if (v343){
            v335.v[v337] = v339;
            int32_t v344;
            v344 = v337 + 1l;
            v345 = v344;
        } else {
            v345 = v337;
        }
        v337 = v345;
        v336 += 1l ;
    }
    bool v346;
    v346 = v337 == 5l;
    US1 v349;
    if (v346){
        v349 = US1_1(v335);
    } else {
        v349 = US1_0();
    }
    array<Card,5l> v350;
    int32_t v351; int32_t v352;
    Tuple9 tmp38 = Tuple9(0l, 0l);
    v351 = tmp38.v0; v352 = tmp38.v1;
    while (while_method_1(v351)){
        Card v354;
        v354 = v73.v[v351];
        uint8_t v355;
        v355 = v354.suit;
        bool v356;
        v356 = v355 == 0u;
        bool v358;
        if (v356){
            bool v357;
            v357 = v352 < 5l;
            v358 = v357;
        } else {
            v358 = false;
        }
        int32_t v360;
        if (v358){
            v350.v[v352] = v354;
            int32_t v359;
            v359 = v352 + 1l;
            v360 = v359;
        } else {
            v360 = v352;
        }
        v352 = v360;
        v351 += 1l ;
    }
    bool v361;
    v361 = v352 == 5l;
    US1 v364;
    if (v361){
        v364 = US1_1(v350);
    } else {
        v364 = US1_0();
    }
    US1 v390;
    switch (v364.tag) {
        case 0: { // None
            v390 = v349;
            break;
        }
        default: { // Some
            array<Card,5l> v365 = v364.v.case1.v0;
            switch (v349.tag) {
                case 0: { // None
                    v390 = v364;
                    break;
                }
                default: { // Some
                    array<Card,5l> v366 = v349.v.case1.v0;
                    US0 v367;
                    v367 = US0_0();
                    int32_t v368; US0 v369;
                    Tuple7 tmp39 = Tuple7(0l, v367);
                    v368 = tmp39.v0; v369 = tmp39.v1;
                    while (while_method_5(v368)){
                        Card v371;
                        v371 = v365.v[v368];
                        Card v372;
                        v372 = v366.v[v368];
                        US0 v383;
                        switch (v369.tag) {
                            case 0: { // Eq
                                uint8_t v373;
                                v373 = v371.rank;
                                uint8_t v374;
                                v374 = v372.rank;
                                bool v375;
                                v375 = v373 < v374;
                                if (v375){
                                    v383 = US0_2();
                                } else {
                                    bool v377;
                                    v377 = v373 > v374;
                                    if (v377){
                                        v383 = US0_1();
                                    } else {
                                        v383 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v369 = v383;
                        v368 += 1l ;
                    }
                    bool v384;
                    switch (v369.tag) {
                        case 1: { // Gt
                            v384 = true;
                            break;
                        }
                        default: {
                            v384 = false;
                        }
                    }
                    array<Card,5l> v385;
                    if (v384){
                        v385 = v365;
                    } else {
                        v385 = v366;
                    }
                    v390 = US1_1(v385);
                }
            }
        }
    }
    US1 v416;
    switch (v390.tag) {
        case 0: { // None
            v416 = v334;
            break;
        }
        default: { // Some
            array<Card,5l> v391 = v390.v.case1.v0;
            switch (v334.tag) {
                case 0: { // None
                    v416 = v390;
                    break;
                }
                default: { // Some
                    array<Card,5l> v392 = v334.v.case1.v0;
                    US0 v393;
                    v393 = US0_0();
                    int32_t v394; US0 v395;
                    Tuple7 tmp40 = Tuple7(0l, v393);
                    v394 = tmp40.v0; v395 = tmp40.v1;
                    while (while_method_5(v394)){
                        Card v397;
                        v397 = v391.v[v394];
                        Card v398;
                        v398 = v392.v[v394];
                        US0 v409;
                        switch (v395.tag) {
                            case 0: { // Eq
                                uint8_t v399;
                                v399 = v397.rank;
                                uint8_t v400;
                                v400 = v398.rank;
                                bool v401;
                                v401 = v399 < v400;
                                if (v401){
                                    v409 = US0_2();
                                } else {
                                    bool v403;
                                    v403 = v399 > v400;
                                    if (v403){
                                        v409 = US0_1();
                                    } else {
                                        v409 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v395 = v409;
                        v394 += 1l ;
                    }
                    bool v410;
                    switch (v395.tag) {
                        case 1: { // Gt
                            v410 = true;
                            break;
                        }
                        default: {
                            v410 = false;
                        }
                    }
                    array<Card,5l> v411;
                    if (v410){
                        v411 = v391;
                    } else {
                        v411 = v392;
                    }
                    v416 = US1_1(v411);
                }
            }
        }
    }
    US1 v442;
    switch (v416.tag) {
        case 0: { // None
            v442 = v319;
            break;
        }
        default: { // Some
            array<Card,5l> v417 = v416.v.case1.v0;
            switch (v319.tag) {
                case 0: { // None
                    v442 = v416;
                    break;
                }
                default: { // Some
                    array<Card,5l> v418 = v319.v.case1.v0;
                    US0 v419;
                    v419 = US0_0();
                    int32_t v420; US0 v421;
                    Tuple7 tmp41 = Tuple7(0l, v419);
                    v420 = tmp41.v0; v421 = tmp41.v1;
                    while (while_method_5(v420)){
                        Card v423;
                        v423 = v417.v[v420];
                        Card v424;
                        v424 = v418.v[v420];
                        US0 v435;
                        switch (v421.tag) {
                            case 0: { // Eq
                                uint8_t v425;
                                v425 = v423.rank;
                                uint8_t v426;
                                v426 = v424.rank;
                                bool v427;
                                v427 = v425 < v426;
                                if (v427){
                                    v435 = US0_2();
                                } else {
                                    bool v429;
                                    v429 = v425 > v426;
                                    if (v429){
                                        v435 = US0_1();
                                    } else {
                                        v435 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v421 = v435;
                        v420 += 1l ;
                    }
                    bool v436;
                    switch (v421.tag) {
                        case 1: { // Gt
                            v436 = true;
                            break;
                        }
                        default: {
                            v436 = false;
                        }
                    }
                    array<Card,5l> v437;
                    if (v436){
                        v437 = v417;
                    } else {
                        v437 = v418;
                    }
                    v442 = US1_1(v437);
                }
            }
        }
    }
    array<Card,3l> v443;
    array<Card,4l> v444;
    int32_t v445; int32_t v446; int32_t v447; uint8_t v448;
    Tuple8 tmp42 = Tuple8(0l, 0l, 0l, 12u);
    v445 = tmp42.v0; v446 = tmp42.v1; v447 = tmp42.v2; v448 = tmp42.v3;
    while (while_method_1(v445)){
        Card v450;
        v450 = v73.v[v445];
        bool v451;
        v451 = v447 < 3l;
        int32_t v460; int32_t v461; uint8_t v462;
        if (v451){
            uint8_t v452;
            v452 = v450.rank;
            bool v453;
            v453 = v448 == v452;
            int32_t v454;
            if (v453){
                v454 = v447;
            } else {
                v454 = 0l;
            }
            v443.v[v454] = v450;
            int32_t v455;
            v455 = v454 + 1l;
            uint8_t v456;
            v456 = v450.rank;
            v460 = v445; v461 = v455; v462 = v456;
        } else {
            break;
        }
        v446 = v460;
        v447 = v461;
        v448 = v462;
        v445 += 1l ;
    }
    bool v463;
    v463 = v447 == 3l;
    US3 v473;
    if (v463){
        int32_t v464;
        v464 = 0l;
        while (while_method_8(v464)){
            int32_t v466;
            v466 = v446 + -2l;
            bool v467;
            v467 = v464 < v466;
            int32_t v468;
            if (v467){
                v468 = 0l;
            } else {
                v468 = 3l;
            }
            int32_t v469;
            v469 = v468 + v464;
            Card v470;
            v470 = v73.v[v469];
            v444.v[v464] = v470;
            v464 += 1l ;
        }
        v473 = US3_1(v443, v444);
    } else {
        v473 = US3_0();
    }
    US1 v524;
    switch (v473.tag) {
        case 0: { // None
            v524 = US1_0();
            break;
        }
        default: { // Some
            array<Card,3l> v474 = v473.v.case1.v0; array<Card,4l> v475 = v473.v.case1.v1;
            array<Card,2l> v476;
            array<Card,2l> v477;
            int32_t v478; int32_t v479; int32_t v480; uint8_t v481;
            Tuple8 tmp43 = Tuple8(0l, 0l, 0l, 12u);
            v478 = tmp43.v0; v479 = tmp43.v1; v480 = tmp43.v2; v481 = tmp43.v3;
            while (while_method_8(v478)){
                Card v483;
                v483 = v475.v[v478];
                bool v484;
                v484 = v480 < 2l;
                int32_t v493; int32_t v494; uint8_t v495;
                if (v484){
                    uint8_t v485;
                    v485 = v483.rank;
                    bool v486;
                    v486 = v481 == v485;
                    int32_t v487;
                    if (v486){
                        v487 = v480;
                    } else {
                        v487 = 0l;
                    }
                    v476.v[v487] = v483;
                    int32_t v488;
                    v488 = v487 + 1l;
                    uint8_t v489;
                    v489 = v483.rank;
                    v493 = v478; v494 = v488; v495 = v489;
                } else {
                    break;
                }
                v479 = v493;
                v480 = v494;
                v481 = v495;
                v478 += 1l ;
            }
            bool v496;
            v496 = v480 == 2l;
            US4 v506;
            if (v496){
                int32_t v497;
                v497 = 0l;
                while (while_method_9(v497)){
                    int32_t v499;
                    v499 = v479 + -1l;
                    bool v500;
                    v500 = v497 < v499;
                    int32_t v501;
                    if (v500){
                        v501 = 0l;
                    } else {
                        v501 = 2l;
                    }
                    int32_t v502;
                    v502 = v501 + v497;
                    Card v503;
                    v503 = v475.v[v502];
                    v477.v[v497] = v503;
                    v497 += 1l ;
                }
                v506 = US4_1(v476, v477);
            } else {
                v506 = US4_0();
            }
            switch (v506.tag) {
                case 0: { // None
                    v524 = US1_0();
                    break;
                }
                default: { // Some
                    array<Card,2l> v507 = v506.v.case1.v0; array<Card,2l> v508 = v506.v.case1.v1;
                    array<Card,0l> v509;
                    array<Card,5l> v510;
                    int32_t v511;
                    v511 = 0l;
                    while (while_method_6(v511)){
                        Card v513;
                        v513 = v474.v[v511];
                        v510.v[v511] = v513;
                        v511 += 1l ;
                    }
                    int32_t v514;
                    v514 = 0l;
                    while (while_method_9(v514)){
                        Card v516;
                        v516 = v507.v[v514];
                        int32_t v517;
                        v517 = 3l + v514;
                        v510.v[v517] = v516;
                        v514 += 1l ;
                    }
                    v524 = US1_1(v510);
                }
            }
        }
    }
    array<Card,4l> v525;
    array<Card,3l> v526;
    int32_t v527; int32_t v528; int32_t v529; uint8_t v530;
    Tuple8 tmp44 = Tuple8(0l, 0l, 0l, 12u);
    v527 = tmp44.v0; v528 = tmp44.v1; v529 = tmp44.v2; v530 = tmp44.v3;
    while (while_method_1(v527)){
        Card v532;
        v532 = v73.v[v527];
        bool v533;
        v533 = v529 < 4l;
        int32_t v542; int32_t v543; uint8_t v544;
        if (v533){
            uint8_t v534;
            v534 = v532.rank;
            bool v535;
            v535 = v530 == v534;
            int32_t v536;
            if (v535){
                v536 = v529;
            } else {
                v536 = 0l;
            }
            v525.v[v536] = v532;
            int32_t v537;
            v537 = v536 + 1l;
            uint8_t v538;
            v538 = v532.rank;
            v542 = v527; v543 = v537; v544 = v538;
        } else {
            break;
        }
        v528 = v542;
        v529 = v543;
        v530 = v544;
        v527 += 1l ;
    }
    bool v545;
    v545 = v529 == 4l;
    US2 v555;
    if (v545){
        int32_t v546;
        v546 = 0l;
        while (while_method_6(v546)){
            int32_t v548;
            v548 = v528 + -3l;
            bool v549;
            v549 = v546 < v548;
            int32_t v550;
            if (v549){
                v550 = 0l;
            } else {
                v550 = 4l;
            }
            int32_t v551;
            v551 = v550 + v546;
            Card v552;
            v552 = v73.v[v551];
            v526.v[v546] = v552;
            v546 += 1l ;
        }
        v555 = US2_1(v525, v526);
    } else {
        v555 = US2_0();
    }
    US1 v574;
    switch (v555.tag) {
        case 0: { // None
            v574 = US1_0();
            break;
        }
        default: { // Some
            array<Card,4l> v556 = v555.v.case1.v0; array<Card,3l> v557 = v555.v.case1.v1;
            array<Card,1l> v558;
            int32_t v559;
            v559 = 0l;
            while (while_method_7(v559)){
                Card v561;
                v561 = v557.v[v559];
                v558.v[v559] = v561;
                v559 += 1l ;
            }
            array<Card,0l> v562;
            array<Card,5l> v563;
            int32_t v564;
            v564 = 0l;
            while (while_method_8(v564)){
                Card v566;
                v566 = v556.v[v564];
                v563.v[v564] = v566;
                v564 += 1l ;
            }
            int32_t v567;
            v567 = 0l;
            while (while_method_7(v567)){
                Card v569;
                v569 = v558.v[v567];
                int32_t v570;
                v570 = 4l + v567;
                v563.v[v570] = v569;
                v567 += 1l ;
            }
            v574 = US1_1(v563);
        }
    }
    array<Card,5l> v575;
    int32_t v576; int32_t v577; uint8_t v578;
    Tuple6 tmp45 = Tuple6(0l, 0l, 12u);
    v576 = tmp45.v0; v577 = tmp45.v1; v578 = tmp45.v2;
    while (while_method_1(v576)){
        Card v580;
        v580 = v73.v[v576];
        bool v581;
        v581 = v577 < 5l;
        int32_t v594; uint8_t v595;
        if (v581){
            uint8_t v582;
            v582 = v580.suit;
            bool v583;
            v583 = 3u == v582;
            if (v583){
                uint8_t v584;
                v584 = v580.rank;
                bool v585;
                v585 = v578 == v584;
                int32_t v586;
                if (v585){
                    v586 = v577;
                } else {
                    v586 = 0l;
                }
                v575.v[v586] = v580;
                int32_t v587;
                v587 = v586 + 1l;
                uint8_t v588;
                v588 = v580.rank;
                uint8_t v589;
                v589 = v588 - 1u;
                v594 = v587; v595 = v589;
            } else {
                v594 = v577; v595 = v578;
            }
        } else {
            break;
        }
        v577 = v594;
        v578 = v595;
        v576 += 1l ;
    }
    bool v596;
    v596 = v577 == 4l;
    bool v631;
    if (v596){
        uint8_t v597;
        v597 = v578 + 1u;
        bool v598;
        v598 = v597 == 0u;
        if (v598){
            Card v599;
            v599 = v73.v[0l];
            uint8_t v600;
            v600 = v599.suit;
            bool v601;
            v601 = 3u == v600;
            bool v605;
            if (v601){
                uint8_t v602;
                v602 = v599.rank;
                bool v603;
                v603 = v602 == 12u;
                if (v603){
                    v575.v[4l] = v599;
                    v605 = true;
                } else {
                    v605 = false;
                }
            } else {
                v605 = false;
            }
            if (v605){
                v631 = true;
            } else {
                Card v606;
                v606 = v73.v[1l];
                uint8_t v607;
                v607 = v606.suit;
                bool v608;
                v608 = 3u == v607;
                bool v612;
                if (v608){
                    uint8_t v609;
                    v609 = v606.rank;
                    bool v610;
                    v610 = v609 == 12u;
                    if (v610){
                        v575.v[4l] = v606;
                        v612 = true;
                    } else {
                        v612 = false;
                    }
                } else {
                    v612 = false;
                }
                if (v612){
                    v631 = true;
                } else {
                    Card v613;
                    v613 = v73.v[2l];
                    uint8_t v614;
                    v614 = v613.suit;
                    bool v615;
                    v615 = 3u == v614;
                    bool v619;
                    if (v615){
                        uint8_t v616;
                        v616 = v613.rank;
                        bool v617;
                        v617 = v616 == 12u;
                        if (v617){
                            v575.v[4l] = v613;
                            v619 = true;
                        } else {
                            v619 = false;
                        }
                    } else {
                        v619 = false;
                    }
                    if (v619){
                        v631 = true;
                    } else {
                        Card v620;
                        v620 = v73.v[3l];
                        uint8_t v621;
                        v621 = v620.suit;
                        bool v622;
                        v622 = 3u == v621;
                        if (v622){
                            uint8_t v623;
                            v623 = v620.rank;
                            bool v624;
                            v624 = v623 == 12u;
                            if (v624){
                                v575.v[4l] = v620;
                                v631 = true;
                            } else {
                                v631 = false;
                            }
                        } else {
                            v631 = false;
                        }
                    }
                }
            }
        } else {
            v631 = false;
        }
    } else {
        v631 = false;
    }
    US1 v637;
    if (v631){
        v637 = US1_1(v575);
    } else {
        bool v633;
        v633 = v577 == 5l;
        if (v633){
            v637 = US1_1(v575);
        } else {
            v637 = US1_0();
        }
    }
    array<Card,5l> v638;
    int32_t v639; int32_t v640; uint8_t v641;
    Tuple6 tmp46 = Tuple6(0l, 0l, 12u);
    v639 = tmp46.v0; v640 = tmp46.v1; v641 = tmp46.v2;
    while (while_method_1(v639)){
        Card v643;
        v643 = v73.v[v639];
        bool v644;
        v644 = v640 < 5l;
        int32_t v657; uint8_t v658;
        if (v644){
            uint8_t v645;
            v645 = v643.suit;
            bool v646;
            v646 = 2u == v645;
            if (v646){
                uint8_t v647;
                v647 = v643.rank;
                bool v648;
                v648 = v641 == v647;
                int32_t v649;
                if (v648){
                    v649 = v640;
                } else {
                    v649 = 0l;
                }
                v638.v[v649] = v643;
                int32_t v650;
                v650 = v649 + 1l;
                uint8_t v651;
                v651 = v643.rank;
                uint8_t v652;
                v652 = v651 - 1u;
                v657 = v650; v658 = v652;
            } else {
                v657 = v640; v658 = v641;
            }
        } else {
            break;
        }
        v640 = v657;
        v641 = v658;
        v639 += 1l ;
    }
    bool v659;
    v659 = v640 == 4l;
    bool v694;
    if (v659){
        uint8_t v660;
        v660 = v641 + 1u;
        bool v661;
        v661 = v660 == 0u;
        if (v661){
            Card v662;
            v662 = v73.v[0l];
            uint8_t v663;
            v663 = v662.suit;
            bool v664;
            v664 = 2u == v663;
            bool v668;
            if (v664){
                uint8_t v665;
                v665 = v662.rank;
                bool v666;
                v666 = v665 == 12u;
                if (v666){
                    v638.v[4l] = v662;
                    v668 = true;
                } else {
                    v668 = false;
                }
            } else {
                v668 = false;
            }
            if (v668){
                v694 = true;
            } else {
                Card v669;
                v669 = v73.v[1l];
                uint8_t v670;
                v670 = v669.suit;
                bool v671;
                v671 = 2u == v670;
                bool v675;
                if (v671){
                    uint8_t v672;
                    v672 = v669.rank;
                    bool v673;
                    v673 = v672 == 12u;
                    if (v673){
                        v638.v[4l] = v669;
                        v675 = true;
                    } else {
                        v675 = false;
                    }
                } else {
                    v675 = false;
                }
                if (v675){
                    v694 = true;
                } else {
                    Card v676;
                    v676 = v73.v[2l];
                    uint8_t v677;
                    v677 = v676.suit;
                    bool v678;
                    v678 = 2u == v677;
                    bool v682;
                    if (v678){
                        uint8_t v679;
                        v679 = v676.rank;
                        bool v680;
                        v680 = v679 == 12u;
                        if (v680){
                            v638.v[4l] = v676;
                            v682 = true;
                        } else {
                            v682 = false;
                        }
                    } else {
                        v682 = false;
                    }
                    if (v682){
                        v694 = true;
                    } else {
                        Card v683;
                        v683 = v73.v[3l];
                        uint8_t v684;
                        v684 = v683.suit;
                        bool v685;
                        v685 = 2u == v684;
                        if (v685){
                            uint8_t v686;
                            v686 = v683.rank;
                            bool v687;
                            v687 = v686 == 12u;
                            if (v687){
                                v638.v[4l] = v683;
                                v694 = true;
                            } else {
                                v694 = false;
                            }
                        } else {
                            v694 = false;
                        }
                    }
                }
            }
        } else {
            v694 = false;
        }
    } else {
        v694 = false;
    }
    US1 v700;
    if (v694){
        v700 = US1_1(v638);
    } else {
        bool v696;
        v696 = v640 == 5l;
        if (v696){
            v700 = US1_1(v638);
        } else {
            v700 = US1_0();
        }
    }
    array<Card,5l> v701;
    int32_t v702; int32_t v703; uint8_t v704;
    Tuple6 tmp47 = Tuple6(0l, 0l, 12u);
    v702 = tmp47.v0; v703 = tmp47.v1; v704 = tmp47.v2;
    while (while_method_1(v702)){
        Card v706;
        v706 = v73.v[v702];
        bool v707;
        v707 = v703 < 5l;
        int32_t v720; uint8_t v721;
        if (v707){
            uint8_t v708;
            v708 = v706.suit;
            bool v709;
            v709 = 1u == v708;
            if (v709){
                uint8_t v710;
                v710 = v706.rank;
                bool v711;
                v711 = v704 == v710;
                int32_t v712;
                if (v711){
                    v712 = v703;
                } else {
                    v712 = 0l;
                }
                v701.v[v712] = v706;
                int32_t v713;
                v713 = v712 + 1l;
                uint8_t v714;
                v714 = v706.rank;
                uint8_t v715;
                v715 = v714 - 1u;
                v720 = v713; v721 = v715;
            } else {
                v720 = v703; v721 = v704;
            }
        } else {
            break;
        }
        v703 = v720;
        v704 = v721;
        v702 += 1l ;
    }
    bool v722;
    v722 = v703 == 4l;
    bool v757;
    if (v722){
        uint8_t v723;
        v723 = v704 + 1u;
        bool v724;
        v724 = v723 == 0u;
        if (v724){
            Card v725;
            v725 = v73.v[0l];
            uint8_t v726;
            v726 = v725.suit;
            bool v727;
            v727 = 1u == v726;
            bool v731;
            if (v727){
                uint8_t v728;
                v728 = v725.rank;
                bool v729;
                v729 = v728 == 12u;
                if (v729){
                    v701.v[4l] = v725;
                    v731 = true;
                } else {
                    v731 = false;
                }
            } else {
                v731 = false;
            }
            if (v731){
                v757 = true;
            } else {
                Card v732;
                v732 = v73.v[1l];
                uint8_t v733;
                v733 = v732.suit;
                bool v734;
                v734 = 1u == v733;
                bool v738;
                if (v734){
                    uint8_t v735;
                    v735 = v732.rank;
                    bool v736;
                    v736 = v735 == 12u;
                    if (v736){
                        v701.v[4l] = v732;
                        v738 = true;
                    } else {
                        v738 = false;
                    }
                } else {
                    v738 = false;
                }
                if (v738){
                    v757 = true;
                } else {
                    Card v739;
                    v739 = v73.v[2l];
                    uint8_t v740;
                    v740 = v739.suit;
                    bool v741;
                    v741 = 1u == v740;
                    bool v745;
                    if (v741){
                        uint8_t v742;
                        v742 = v739.rank;
                        bool v743;
                        v743 = v742 == 12u;
                        if (v743){
                            v701.v[4l] = v739;
                            v745 = true;
                        } else {
                            v745 = false;
                        }
                    } else {
                        v745 = false;
                    }
                    if (v745){
                        v757 = true;
                    } else {
                        Card v746;
                        v746 = v73.v[3l];
                        uint8_t v747;
                        v747 = v746.suit;
                        bool v748;
                        v748 = 1u == v747;
                        if (v748){
                            uint8_t v749;
                            v749 = v746.rank;
                            bool v750;
                            v750 = v749 == 12u;
                            if (v750){
                                v701.v[4l] = v746;
                                v757 = true;
                            } else {
                                v757 = false;
                            }
                        } else {
                            v757 = false;
                        }
                    }
                }
            }
        } else {
            v757 = false;
        }
    } else {
        v757 = false;
    }
    US1 v763;
    if (v757){
        v763 = US1_1(v701);
    } else {
        bool v759;
        v759 = v703 == 5l;
        if (v759){
            v763 = US1_1(v701);
        } else {
            v763 = US1_0();
        }
    }
    array<Card,5l> v764;
    int32_t v765; int32_t v766; uint8_t v767;
    Tuple6 tmp48 = Tuple6(0l, 0l, 12u);
    v765 = tmp48.v0; v766 = tmp48.v1; v767 = tmp48.v2;
    while (while_method_1(v765)){
        Card v769;
        v769 = v73.v[v765];
        bool v770;
        v770 = v766 < 5l;
        int32_t v783; uint8_t v784;
        if (v770){
            uint8_t v771;
            v771 = v769.suit;
            bool v772;
            v772 = 0u == v771;
            if (v772){
                uint8_t v773;
                v773 = v769.rank;
                bool v774;
                v774 = v767 == v773;
                int32_t v775;
                if (v774){
                    v775 = v766;
                } else {
                    v775 = 0l;
                }
                v764.v[v775] = v769;
                int32_t v776;
                v776 = v775 + 1l;
                uint8_t v777;
                v777 = v769.rank;
                uint8_t v778;
                v778 = v777 - 1u;
                v783 = v776; v784 = v778;
            } else {
                v783 = v766; v784 = v767;
            }
        } else {
            break;
        }
        v766 = v783;
        v767 = v784;
        v765 += 1l ;
    }
    bool v785;
    v785 = v766 == 4l;
    bool v820;
    if (v785){
        uint8_t v786;
        v786 = v767 + 1u;
        bool v787;
        v787 = v786 == 0u;
        if (v787){
            Card v788;
            v788 = v73.v[0l];
            uint8_t v789;
            v789 = v788.suit;
            bool v790;
            v790 = 0u == v789;
            bool v794;
            if (v790){
                uint8_t v791;
                v791 = v788.rank;
                bool v792;
                v792 = v791 == 12u;
                if (v792){
                    v764.v[4l] = v788;
                    v794 = true;
                } else {
                    v794 = false;
                }
            } else {
                v794 = false;
            }
            if (v794){
                v820 = true;
            } else {
                Card v795;
                v795 = v73.v[1l];
                uint8_t v796;
                v796 = v795.suit;
                bool v797;
                v797 = 0u == v796;
                bool v801;
                if (v797){
                    uint8_t v798;
                    v798 = v795.rank;
                    bool v799;
                    v799 = v798 == 12u;
                    if (v799){
                        v764.v[4l] = v795;
                        v801 = true;
                    } else {
                        v801 = false;
                    }
                } else {
                    v801 = false;
                }
                if (v801){
                    v820 = true;
                } else {
                    Card v802;
                    v802 = v73.v[2l];
                    uint8_t v803;
                    v803 = v802.suit;
                    bool v804;
                    v804 = 0u == v803;
                    bool v808;
                    if (v804){
                        uint8_t v805;
                        v805 = v802.rank;
                        bool v806;
                        v806 = v805 == 12u;
                        if (v806){
                            v764.v[4l] = v802;
                            v808 = true;
                        } else {
                            v808 = false;
                        }
                    } else {
                        v808 = false;
                    }
                    if (v808){
                        v820 = true;
                    } else {
                        Card v809;
                        v809 = v73.v[3l];
                        uint8_t v810;
                        v810 = v809.suit;
                        bool v811;
                        v811 = 0u == v810;
                        if (v811){
                            uint8_t v812;
                            v812 = v809.rank;
                            bool v813;
                            v813 = v812 == 12u;
                            if (v813){
                                v764.v[4l] = v809;
                                v820 = true;
                            } else {
                                v820 = false;
                            }
                        } else {
                            v820 = false;
                        }
                    }
                }
            }
        } else {
            v820 = false;
        }
    } else {
        v820 = false;
    }
    US1 v826;
    if (v820){
        v826 = US1_1(v764);
    } else {
        bool v822;
        v822 = v766 == 5l;
        if (v822){
            v826 = US1_1(v764);
        } else {
            v826 = US1_0();
        }
    }
    US1 v852;
    switch (v826.tag) {
        case 0: { // None
            v852 = v763;
            break;
        }
        default: { // Some
            array<Card,5l> v827 = v826.v.case1.v0;
            switch (v763.tag) {
                case 0: { // None
                    v852 = v826;
                    break;
                }
                default: { // Some
                    array<Card,5l> v828 = v763.v.case1.v0;
                    US0 v829;
                    v829 = US0_0();
                    int32_t v830; US0 v831;
                    Tuple7 tmp49 = Tuple7(0l, v829);
                    v830 = tmp49.v0; v831 = tmp49.v1;
                    while (while_method_5(v830)){
                        Card v833;
                        v833 = v827.v[v830];
                        Card v834;
                        v834 = v828.v[v830];
                        US0 v845;
                        switch (v831.tag) {
                            case 0: { // Eq
                                uint8_t v835;
                                v835 = v833.rank;
                                uint8_t v836;
                                v836 = v834.rank;
                                bool v837;
                                v837 = v835 < v836;
                                if (v837){
                                    v845 = US0_2();
                                } else {
                                    bool v839;
                                    v839 = v835 > v836;
                                    if (v839){
                                        v845 = US0_1();
                                    } else {
                                        v845 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v831 = v845;
                        v830 += 1l ;
                    }
                    bool v846;
                    switch (v831.tag) {
                        case 1: { // Gt
                            v846 = true;
                            break;
                        }
                        default: {
                            v846 = false;
                        }
                    }
                    array<Card,5l> v847;
                    if (v846){
                        v847 = v827;
                    } else {
                        v847 = v828;
                    }
                    v852 = US1_1(v847);
                }
            }
        }
    }
    US1 v878;
    switch (v852.tag) {
        case 0: { // None
            v878 = v700;
            break;
        }
        default: { // Some
            array<Card,5l> v853 = v852.v.case1.v0;
            switch (v700.tag) {
                case 0: { // None
                    v878 = v852;
                    break;
                }
                default: { // Some
                    array<Card,5l> v854 = v700.v.case1.v0;
                    US0 v855;
                    v855 = US0_0();
                    int32_t v856; US0 v857;
                    Tuple7 tmp50 = Tuple7(0l, v855);
                    v856 = tmp50.v0; v857 = tmp50.v1;
                    while (while_method_5(v856)){
                        Card v859;
                        v859 = v853.v[v856];
                        Card v860;
                        v860 = v854.v[v856];
                        US0 v871;
                        switch (v857.tag) {
                            case 0: { // Eq
                                uint8_t v861;
                                v861 = v859.rank;
                                uint8_t v862;
                                v862 = v860.rank;
                                bool v863;
                                v863 = v861 < v862;
                                if (v863){
                                    v871 = US0_2();
                                } else {
                                    bool v865;
                                    v865 = v861 > v862;
                                    if (v865){
                                        v871 = US0_1();
                                    } else {
                                        v871 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v857 = v871;
                        v856 += 1l ;
                    }
                    bool v872;
                    switch (v857.tag) {
                        case 1: { // Gt
                            v872 = true;
                            break;
                        }
                        default: {
                            v872 = false;
                        }
                    }
                    array<Card,5l> v873;
                    if (v872){
                        v873 = v853;
                    } else {
                        v873 = v854;
                    }
                    v878 = US1_1(v873);
                }
            }
        }
    }
    US1 v904;
    switch (v878.tag) {
        case 0: { // None
            v904 = v637;
            break;
        }
        default: { // Some
            array<Card,5l> v879 = v878.v.case1.v0;
            switch (v637.tag) {
                case 0: { // None
                    v904 = v878;
                    break;
                }
                default: { // Some
                    array<Card,5l> v880 = v637.v.case1.v0;
                    US0 v881;
                    v881 = US0_0();
                    int32_t v882; US0 v883;
                    Tuple7 tmp51 = Tuple7(0l, v881);
                    v882 = tmp51.v0; v883 = tmp51.v1;
                    while (while_method_5(v882)){
                        Card v885;
                        v885 = v879.v[v882];
                        Card v886;
                        v886 = v880.v[v882];
                        US0 v897;
                        switch (v883.tag) {
                            case 0: { // Eq
                                uint8_t v887;
                                v887 = v885.rank;
                                uint8_t v888;
                                v888 = v886.rank;
                                bool v889;
                                v889 = v887 < v888;
                                if (v889){
                                    v897 = US0_2();
                                } else {
                                    bool v891;
                                    v891 = v887 > v888;
                                    if (v891){
                                        v897 = US0_1();
                                    } else {
                                        v897 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v883 = v897;
                        v882 += 1l ;
                    }
                    bool v898;
                    switch (v883.tag) {
                        case 1: { // Gt
                            v898 = true;
                            break;
                        }
                        default: {
                            v898 = false;
                        }
                    }
                    array<Card,5l> v899;
                    if (v898){
                        v899 = v879;
                    } else {
                        v899 = v880;
                    }
                    v904 = US1_1(v899);
                }
            }
        }
    }
    US7 v909;
    switch (v127.tag) {
        case 0: { // None
            v909 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v905 = v127.v.case1.v0;
            v909 = US7_1(v905, 1);
        }
    }
    US7 v914;
    switch (v216.tag) {
        case 0: { // None
            v914 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v910 = v216.v.case1.v0;
            v914 = US7_1(v910, 2);
        }
    }
    US7 v919;
    switch (v266.tag) {
        case 0: { // None
            v919 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v915 = v266.v.case1.v0;
            v919 = US7_1(v915, 3);
        }
    }
    US7 v924;
    switch (v304.tag) {
        case 0: { // None
            v924 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v920 = v304.v.case1.v0;
            v924 = US7_1(v920, 4);
        }
    }
    US7 v929;
    switch (v442.tag) {
        case 0: { // None
            v929 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v925 = v442.v.case1.v0;
            v929 = US7_1(v925, 5);
        }
    }
    US7 v934;
    switch (v524.tag) {
        case 0: { // None
            v934 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v930 = v524.v.case1.v0;
            v934 = US7_1(v930, 6);
        }
    }
    US7 v939;
    switch (v574.tag) {
        case 0: { // None
            v939 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v935 = v574.v.case1.v0;
            v939 = US7_1(v935, 7);
        }
    }
    US7 v944;
    switch (v904.tag) {
        case 0: { // None
            v944 = US7_0();
            break;
        }
        default: { // Some
            array<Card,5l> v940 = v904.v.case1.v0;
            v944 = US7_1(v940, 8);
        }
    }
    US7 v946;
    switch (v944.tag) {
        case 0: { // None
            v946 = US7_0();
            break;
        }
        default: {
            v946 = v944;
        }
    }
    US7 v956;
    switch (v946.tag) {
        case 1: { // Some
            array<Card,5l> v947 = v946.v.case1.v0; int8_t v948 = v946.v.case1.v1;
            switch (v939.tag) {
                case 0: { // None
                    v956 = v946;
                    break;
                }
                default: { // Some
                    array<Card,5l> v949 = v939.v.case1.v0; int8_t v950 = v939.v.case1.v1;
                    v956 = US7_1(v947, v948);
                }
            }
            break;
        }
        default: {
            switch (v939.tag) {
                case 0: { // None
                    v956 = v946;
                    break;
                }
                default: {
                    switch (v946.tag) {
                        default: { // None
                            v956 = v939;
                        }
                    }
                }
            }
        }
    }
    US7 v966;
    switch (v956.tag) {
        case 1: { // Some
            array<Card,5l> v957 = v956.v.case1.v0; int8_t v958 = v956.v.case1.v1;
            switch (v934.tag) {
                case 0: { // None
                    v966 = v956;
                    break;
                }
                default: { // Some
                    array<Card,5l> v959 = v934.v.case1.v0; int8_t v960 = v934.v.case1.v1;
                    v966 = US7_1(v957, v958);
                }
            }
            break;
        }
        default: {
            switch (v934.tag) {
                case 0: { // None
                    v966 = v956;
                    break;
                }
                default: {
                    switch (v956.tag) {
                        default: { // None
                            v966 = v934;
                        }
                    }
                }
            }
        }
    }
    US7 v976;
    switch (v966.tag) {
        case 1: { // Some
            array<Card,5l> v967 = v966.v.case1.v0; int8_t v968 = v966.v.case1.v1;
            switch (v929.tag) {
                case 0: { // None
                    v976 = v966;
                    break;
                }
                default: { // Some
                    array<Card,5l> v969 = v929.v.case1.v0; int8_t v970 = v929.v.case1.v1;
                    v976 = US7_1(v967, v968);
                }
            }
            break;
        }
        default: {
            switch (v929.tag) {
                case 0: { // None
                    v976 = v966;
                    break;
                }
                default: {
                    switch (v966.tag) {
                        default: { // None
                            v976 = v929;
                        }
                    }
                }
            }
        }
    }
    US7 v986;
    switch (v976.tag) {
        case 1: { // Some
            array<Card,5l> v977 = v976.v.case1.v0; int8_t v978 = v976.v.case1.v1;
            switch (v924.tag) {
                case 0: { // None
                    v986 = v976;
                    break;
                }
                default: { // Some
                    array<Card,5l> v979 = v924.v.case1.v0; int8_t v980 = v924.v.case1.v1;
                    v986 = US7_1(v977, v978);
                }
            }
            break;
        }
        default: {
            switch (v924.tag) {
                case 0: { // None
                    v986 = v976;
                    break;
                }
                default: {
                    switch (v976.tag) {
                        default: { // None
                            v986 = v924;
                        }
                    }
                }
            }
        }
    }
    US7 v996;
    switch (v986.tag) {
        case 1: { // Some
            array<Card,5l> v987 = v986.v.case1.v0; int8_t v988 = v986.v.case1.v1;
            switch (v919.tag) {
                case 0: { // None
                    v996 = v986;
                    break;
                }
                default: { // Some
                    array<Card,5l> v989 = v919.v.case1.v0; int8_t v990 = v919.v.case1.v1;
                    v996 = US7_1(v987, v988);
                }
            }
            break;
        }
        default: {
            switch (v919.tag) {
                case 0: { // None
                    v996 = v986;
                    break;
                }
                default: {
                    switch (v986.tag) {
                        default: { // None
                            v996 = v919;
                        }
                    }
                }
            }
        }
    }
    US7 v1006;
    switch (v996.tag) {
        case 1: { // Some
            array<Card,5l> v997 = v996.v.case1.v0; int8_t v998 = v996.v.case1.v1;
            switch (v914.tag) {
                case 0: { // None
                    v1006 = v996;
                    break;
                }
                default: { // Some
                    array<Card,5l> v999 = v914.v.case1.v0; int8_t v1000 = v914.v.case1.v1;
                    v1006 = US7_1(v997, v998);
                }
            }
            break;
        }
        default: {
            switch (v914.tag) {
                case 0: { // None
                    v1006 = v996;
                    break;
                }
                default: {
                    switch (v996.tag) {
                        default: { // None
                            v1006 = v914;
                        }
                    }
                }
            }
        }
    }
    US7 v1016;
    switch (v1006.tag) {
        case 1: { // Some
            array<Card,5l> v1007 = v1006.v.case1.v0; int8_t v1008 = v1006.v.case1.v1;
            switch (v909.tag) {
                case 0: { // None
                    v1016 = v1006;
                    break;
                }
                default: { // Some
                    array<Card,5l> v1009 = v909.v.case1.v0; int8_t v1010 = v909.v.case1.v1;
                    v1016 = US7_1(v1007, v1008);
                }
            }
            break;
        }
        default: {
            switch (v909.tag) {
                case 0: { // None
                    v1016 = v1006;
                    break;
                }
                default: {
                    switch (v1006.tag) {
                        default: { // None
                            v1016 = v909;
                        }
                    }
                }
            }
        }
    }
    array<Card,5l> v1021; int8_t v1022;
    switch (v1016.tag) {
        case 0: { // None
            v1021 = v74; v1022 = 0;
            break;
        }
        default: { // Some
            array<Card,5l> v1017 = v1016.v.case1.v0; int8_t v1018 = v1016.v.case1.v1;
            v1021 = v1017; v1022 = v1018;
        }
    }
    return Tuple3(v1021, v1022);
}
__device__ inline bool while_method_10(array<Card,5l> v0, bool v1, int32_t v2){
    bool v3;
    v3 = v2 < 5l;
    return v3;
}
extern "C" __global__ void entry0() {
    int32_t v0;
    v0 = threadIdx.x + blockIdx.x * blockDim.x;
    uint64_t v1;
    v1 = (uint64_t)v0;
    curandStatePhilox4_32_10_t v2;
    curandStatePhilox4_32_10_t * v3 = &v2;
    curand_init(v1,0ull,0ull,v3);
    int32_t v4;
    v4 = gridDim.x * blockDim.x;
    int32_t v5;
    v5 = v0;
    while (while_method_0(v5)){
        uint64_t v7;
        v7 = 4503599627370495ull;
        array<Card,7l> v8; uint64_t v9;
        Tuple0 tmp2 = draw_cards_0(v3, v7);
        v8 = tmp2.v0; v9 = tmp2.v1;
        array<Card,5l> v10; int8_t v11;
        Tuple3 tmp27 = score_3(v8);
        v10 = tmp27.v0; v11 = tmp27.v1;
        array<Card,5l> v12; int8_t v13;
        Tuple3 tmp52 = score_4(v8);
        v12 = tmp52.v0; v13 = tmp52.v1;
        bool v14; int32_t v15;
        Tuple4 tmp53 = Tuple4(true, 0l);
        v14 = tmp53.v0; v15 = tmp53.v1;
        while (while_method_10(v10, v14, v15)){
            bool v25; int32_t v26;
            if (v14){
                Card v17;
                v17 = v10.v[v15];
                Card v18;
                v18 = v12.v[v15];
                uint8_t v19;
                v19 = v17.suit * 13 + v17.rank;
                uint8_t v20;
                v20 = v18.suit * 13 + v18.rank;
                bool v21;
                v21 = v19 == v20;
                int32_t v22;
                v22 = v15 + 1l;
                v25 = v21; v26 = v22;
            } else {
                break;
            }
            v14 = v25;
            v15 = v26;
        }
        bool v28;
        if (v14){
            bool v27;
            v27 = v11 == v13;
            v28 = v27;
        } else {
            v28 = false;
        }
        bool v29;
        v29 = v28 != true;
        if (v29){
            const char * v30;
            v30 = "%s";
            const char * v31;
            v31 = "error";
            printf(v30,v31);
            printf("\n");
        } else {
        }
        v5 += v4 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

raw_module = cp.RawModule(code=kernel, backend="nvcc")
def main():
    v0 = 0
    raw_module.get_function(f"entry{v0}")((1, 1, 1),(1, 1, 1),())
    del v0
    return 

if __name__ == '__main__': print(main())
