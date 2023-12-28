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
__device__ uint32_t loop_3(uint32_t v0, curandStatePhilox4_32_10_t * v1);
__device__ Tuple1 draw_card_2(curandStatePhilox4_32_10_t * v0, uint64_t v1);
struct US0;
struct US1;
struct Tuple2;
struct US2;
struct Tuple3;
__device__ int32_t loop_6(array<float,8l> v0, float v1, int32_t v2);
__device__ int32_t sample_discrete__5(array<float,8l> v0, curandStatePhilox4_32_10_t * v1);
__device__ US2 sample_discrete_4(array<Tuple3,8l> v0, curandStatePhilox4_32_10_t * v1);
struct Tuple4;
struct Tuple5;
struct Tuple6;
struct US3;
struct Tuple7;
struct US4;
struct Tuple8;
struct Tuple9;
struct US5;
struct US6;
struct US7;
struct Tuple10;
struct US8;
struct US9;
__device__ Tuple4 score_8(array<Card,7l> v0);
__device__ Tuple4 score_7(Card v0, Card v1, Card v2, Card v3, Card v4, Card v5, Card v6);
struct Tuple11;
__device__ US3 method_9(array<Card,5l> v0, array<Card,5l> v1);
__device__ int16_t game_1(uint64_t * v0, curandStatePhilox4_32_10_t * v1);
__device__ int16_t game_loop_0();
struct Tuple0 {
    int32_t v0;
    int16_t v1;
    __device__ Tuple0(int32_t t0, int16_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    Card v0;
    uint64_t v1;
    __device__ Tuple1(Card t0, uint64_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
struct US0 {
    union {
        struct {
            Card v0;
            Card v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US1 {
    union {
        struct {
            int8_t v0;
            int8_t v1;
        } case1; // TurnOf
    } v;
    char tag : 2;
};
struct Tuple2 {
    US0 v1;
    US0 v3;
    US1 v5;
    int16_t v2;
    int16_t v4;
    uint8_t v0;
    __device__ Tuple2(uint8_t t0, US0 t1, int16_t t2, US0 t3, int16_t t4, US1 t5) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5) {}
    __device__ Tuple2() = default;
};
struct US2 {
    union {
        struct {
            int16_t v0;
        } case2; // RaiseTo
    } v;
    char tag : 2;
};
struct Tuple3 {
    US2 v0;
    float v1;
    __device__ Tuple3(US2 t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple3() = default;
};
struct Tuple4 {
    array<Card,5l> v0;
    int8_t v1;
    __device__ Tuple4(array<Card,5l> t0, int8_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple4() = default;
};
struct Tuple5 {
    int32_t v1;
    bool v0;
    __device__ Tuple5(bool t0, int32_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple5() = default;
};
struct Tuple6 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    __device__ Tuple6(int32_t t0, int32_t t1, int32_t t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple6() = default;
};
struct US3 {
    union {
    } v;
    char tag : 2;
};
struct Tuple7 {
    int32_t v0;
    int32_t v1;
    uint8_t v2;
    __device__ Tuple7(int32_t t0, int32_t t1, uint8_t t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple7() = default;
};
struct US4 {
    union {
        struct {
            array<Card,5l> v0;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple8 {
    US3 v1;
    int32_t v0;
    __device__ Tuple8(int32_t t0, US3 t1) : v0(t0), v1(t1) {}
    __device__ Tuple8() = default;
};
struct Tuple9 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    uint8_t v3;
    __device__ Tuple9(int32_t t0, int32_t t1, int32_t t2, uint8_t t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    __device__ Tuple9() = default;
};
struct US5 {
    union {
        struct {
            array<Card,4l> v0;
            array<Card,3l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US6 {
    union {
        struct {
            array<Card,3l> v0;
            array<Card,4l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US7 {
    union {
        struct {
            array<Card,2l> v0;
            array<Card,2l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple10 {
    int32_t v0;
    int32_t v1;
    __device__ Tuple10(int32_t t0, int32_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple10() = default;
};
struct US8 {
    union {
        struct {
            array<Card,2l> v0;
            array<Card,5l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US9 {
    union {
        struct {
            array<Card,2l> v0;
            array<Card,3l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple11 {
    US3 v0;
    int32_t v1;
    __device__ Tuple11(US3 t0, int32_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple11() = default;
};
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 100000l;
    return v1;
}
__device__ uint32_t loop_3(uint32_t v0, curandStatePhilox4_32_10_t * v1){
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
        return loop_3(v0, v1);
    }
}
__device__ Tuple1 draw_card_2(curandStatePhilox4_32_10_t * v0, uint64_t v1){
    int32_t v2;
    v2 = __popcll(v1);
    uint32_t v3;
    v3 = (uint32_t)v2;
    uint32_t v4;
    v4 = loop_3(v3, v0);
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
    return Tuple1(v21, v24);
}
__device__ US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1(Card v0, Card v1) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US1 US1_0() { // Done
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1(int8_t v0, int8_t v1) { // TurnOf
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_1(uint8_t v0, US0 v1, int16_t v2, US0 v3, int16_t v4, US1 v5){
    bool v6;
    v6 = v0 > 0u;
    if (v6){
        bool v8;
        switch (v5.tag) {
            case 0: { // Done
                v8 = true;
                break;
            }
            default: {
                v8 = false;
            }
        }
        bool v9;
        v9 = v8 != true;
        return v9;
    } else {
        return false;
    }
}
__device__ US2 US2_0() { // Call
    US2 x;
    x.tag = 0;
    return x;
}
__device__ US2 US2_1() { // Fold
    US2 x;
    x.tag = 1;
    return x;
}
__device__ US2 US2_2(int16_t v0) { // RaiseTo
    US2 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ inline bool while_method_2(int32_t v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_3(array<float,8l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 8l;
    return v2;
}
__device__ inline bool while_method_4(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 > v0;
    return v2;
}
__device__ int32_t loop_6(array<float,8l> v0, float v1, int32_t v2){
    bool v3;
    v3 = v2 < 8l;
    if (v3){
        float v4;
        v4 = v0.v[v2];
        bool v5;
        v5 = v1 <= v4;
        if (v5){
            return v2;
        } else {
            int32_t v6;
            v6 = v2 + 1l;
            return loop_6(v0, v1, v6);
        }
    } else {
        return 7l;
    }
}
__device__ int32_t sample_discrete__5(array<float,8l> v0, curandStatePhilox4_32_10_t * v1){
    array<float,8l> v2;
    int32_t v3;
    v3 = 0l;
    while (while_method_2(v3)){
        float v5;
        v5 = v0.v[v3];
        v2.v[v3] = v5;
        v3 += 1l ;
    }
    int32_t v6;
    v6 = 1l;
    while (while_method_3(v2, v6)){
        int32_t v8;
        v8 = 8l;
        while (while_method_4(v6, v8)){
            v8 -= 1l ;
            int32_t v10;
            v10 = v8 - v6;
            float v11;
            v11 = v2.v[v10];
            float v12;
            v12 = v2.v[v8];
            float v13;
            v13 = v11 + v12;
            v2.v[v8] = v13;
        }
        int32_t v14;
        v14 = v6 * 2l;
        v6 = v14;
    }
    float v15;
    v15 = v2.v[7l];
    float v16;
    v16 = curand_uniform(v1);
    float v17;
    v17 = v16 * v15;
    int32_t v18;
    v18 = 0l;
    return loop_6(v2, v17, v18);
}
__device__ US2 sample_discrete_4(array<Tuple3,8l> v0, curandStatePhilox4_32_10_t * v1){
    array<float,8l> v2;
    int32_t v3;
    v3 = 0l;
    while (while_method_2(v3)){
        US2 v5; float v6;
        Tuple3 tmp6 = v0.v[v3];
        v5 = tmp6.v0; v6 = tmp6.v1;
        v2.v[v3] = v6;
        v3 += 1l ;
    }
    int32_t v7;
    v7 = sample_discrete__5(v2, v1);
    US2 v8; float v9;
    Tuple3 tmp7 = v0.v[v7];
    v8 = tmp7.v0; v9 = tmp7.v1;
    return v8;
}
__device__ inline bool while_method_5(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
__device__ inline bool while_method_6(array<Card,7l> v0, bool v1, int32_t v2){
    bool v3;
    v3 = v2 < 7l;
    return v3;
}
__device__ inline bool while_method_7(array<Card,7l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 7l;
    return v2;
}
__device__ inline bool while_method_8(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
__device__ US3 US3_0() { // Eq
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1() { // Gt
    US3 x;
    x.tag = 1;
    return x;
}
__device__ US3 US3_2() { // Lt
    US3 x;
    x.tag = 2;
    return x;
}
__device__ US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1(array<Card,5l> v0) { // Some
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_9(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
__device__ US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
__device__ US5 US5_1(array<Card,4l> v0, array<Card,3l> v1) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_10(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
__device__ inline bool while_method_11(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ inline bool while_method_12(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
__device__ US6 US6_1(array<Card,3l> v0, array<Card,4l> v1) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
__device__ US7 US7_1(array<Card,2l> v0, array<Card,2l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_13(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ US8 US8_0() { // None
    US8 x;
    x.tag = 0;
    return x;
}
__device__ US8 US8_1(array<Card,2l> v0, array<Card,5l> v1) { // Some
    US8 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US9 US9_0() { // None
    US9 x;
    x.tag = 0;
    return x;
}
__device__ US9 US9_1(array<Card,2l> v0, array<Card,3l> v1) { // Some
    US9 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ Tuple4 score_8(array<Card,7l> v0){
    array<Card,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_5(v2)){
        Card v4;
        v4 = v0.v[v2];
        v1.v[v2] = v4;
        v2 += 1l ;
    }
    array<Card,7l> v5;
    bool v6; int32_t v7;
    Tuple5 tmp16 = Tuple5(true, 1l);
    v6 = tmp16.v0; v7 = tmp16.v1;
    while (while_method_6(v1, v6, v7)){
        int32_t v9;
        v9 = 0l;
        while (while_method_7(v1, v9)){
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
            Tuple6 tmp17 = Tuple6(v9, v13, v9);
            v18 = tmp17.v0; v19 = tmp17.v1; v20 = tmp17.v2;
            while (while_method_8(v17, v18, v19, v20)){
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
                    US3 v39;
                    if (v33){
                        v39 = US3_2();
                    } else {
                        bool v35;
                        v35 = v31 > v32;
                        if (v35){
                            v39 = US3_1();
                        } else {
                            v39 = US3_0();
                        }
                    }
                    US3 v49;
                    switch (v39.tag) {
                        case 0: { // Eq
                            uint8_t v40;
                            v40 = v27.suit;
                            uint8_t v41;
                            v41 = v30.suit;
                            bool v42;
                            v42 = v40 < v41;
                            if (v42){
                                v49 = US3_2();
                            } else {
                                bool v44;
                                v44 = v40 > v41;
                                if (v44){
                                    v49 = US3_1();
                                } else {
                                    v49 = US3_0();
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
    Tuple7 tmp18 = Tuple7(0l, 0l, 12u);
    v75 = tmp18.v0; v76 = tmp18.v1; v77 = tmp18.v2;
    while (while_method_5(v75)){
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
    US4 v136;
    if (v130){
        v136 = US4_1(v74);
    } else {
        bool v132;
        v132 = v76 == 5l;
        if (v132){
            v136 = US4_1(v74);
        } else {
            v136 = US4_0();
        }
    }
    array<Card,5l> v137;
    int32_t v138; int32_t v139; uint8_t v140;
    Tuple7 tmp19 = Tuple7(0l, 0l, 12u);
    v138 = tmp19.v0; v139 = tmp19.v1; v140 = tmp19.v2;
    while (while_method_5(v138)){
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
    US4 v199;
    if (v193){
        v199 = US4_1(v137);
    } else {
        bool v195;
        v195 = v139 == 5l;
        if (v195){
            v199 = US4_1(v137);
        } else {
            v199 = US4_0();
        }
    }
    US4 v225;
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
                    US3 v202;
                    v202 = US3_0();
                    int32_t v203; US3 v204;
                    Tuple8 tmp20 = Tuple8(0l, v202);
                    v203 = tmp20.v0; v204 = tmp20.v1;
                    while (while_method_9(v203)){
                        Card v206;
                        v206 = v200.v[v203];
                        Card v207;
                        v207 = v201.v[v203];
                        US3 v218;
                        switch (v204.tag) {
                            case 0: { // Eq
                                uint8_t v208;
                                v208 = v206.rank;
                                uint8_t v209;
                                v209 = v207.rank;
                                bool v210;
                                v210 = v208 < v209;
                                if (v210){
                                    v218 = US3_2();
                                } else {
                                    bool v212;
                                    v212 = v208 > v209;
                                    if (v212){
                                        v218 = US3_1();
                                    } else {
                                        v218 = US3_0();
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
                    v225 = US4_1(v220);
                }
            }
        }
    }
    array<Card,5l> v226;
    int32_t v227; int32_t v228; uint8_t v229;
    Tuple7 tmp21 = Tuple7(0l, 0l, 12u);
    v227 = tmp21.v0; v228 = tmp21.v1; v229 = tmp21.v2;
    while (while_method_5(v227)){
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
    US4 v288;
    if (v282){
        v288 = US4_1(v226);
    } else {
        bool v284;
        v284 = v228 == 5l;
        if (v284){
            v288 = US4_1(v226);
        } else {
            v288 = US4_0();
        }
    }
    US4 v314;
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
                    US3 v291;
                    v291 = US3_0();
                    int32_t v292; US3 v293;
                    Tuple8 tmp22 = Tuple8(0l, v291);
                    v292 = tmp22.v0; v293 = tmp22.v1;
                    while (while_method_9(v292)){
                        Card v295;
                        v295 = v289.v[v292];
                        Card v296;
                        v296 = v290.v[v292];
                        US3 v307;
                        switch (v293.tag) {
                            case 0: { // Eq
                                uint8_t v297;
                                v297 = v295.rank;
                                uint8_t v298;
                                v298 = v296.rank;
                                bool v299;
                                v299 = v297 < v298;
                                if (v299){
                                    v307 = US3_2();
                                } else {
                                    bool v301;
                                    v301 = v297 > v298;
                                    if (v301){
                                        v307 = US3_1();
                                    } else {
                                        v307 = US3_0();
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
                    v314 = US4_1(v309);
                }
            }
        }
    }
    array<Card,5l> v315;
    int32_t v316; int32_t v317; uint8_t v318;
    Tuple7 tmp23 = Tuple7(0l, 0l, 12u);
    v316 = tmp23.v0; v317 = tmp23.v1; v318 = tmp23.v2;
    while (while_method_5(v316)){
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
    US4 v377;
    if (v371){
        v377 = US4_1(v315);
    } else {
        bool v373;
        v373 = v317 == 5l;
        if (v373){
            v377 = US4_1(v315);
        } else {
            v377 = US4_0();
        }
    }
    US4 v403;
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
                    US3 v380;
                    v380 = US3_0();
                    int32_t v381; US3 v382;
                    Tuple8 tmp24 = Tuple8(0l, v380);
                    v381 = tmp24.v0; v382 = tmp24.v1;
                    while (while_method_9(v381)){
                        Card v384;
                        v384 = v378.v[v381];
                        Card v385;
                        v385 = v379.v[v381];
                        US3 v396;
                        switch (v382.tag) {
                            case 0: { // Eq
                                uint8_t v386;
                                v386 = v384.rank;
                                uint8_t v387;
                                v387 = v385.rank;
                                bool v388;
                                v388 = v386 < v387;
                                if (v388){
                                    v396 = US3_2();
                                } else {
                                    bool v390;
                                    v390 = v386 > v387;
                                    if (v390){
                                        v396 = US3_1();
                                    } else {
                                        v396 = US3_0();
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
                    v403 = US4_1(v398);
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
            Tuple9 tmp25 = Tuple9(0l, 0l, 0l, 12u);
            v407 = tmp25.v0; v408 = tmp25.v1; v409 = tmp25.v2; v410 = tmp25.v3;
            while (while_method_5(v407)){
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
            US5 v435;
            if (v425){
                int32_t v426;
                v426 = 0l;
                while (while_method_10(v426)){
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
                v435 = US5_1(v405, v406);
            } else {
                v435 = US5_0();
            }
            US4 v454;
            switch (v435.tag) {
                case 0: { // None
                    v454 = US4_0();
                    break;
                }
                default: { // Some
                    array<Card,4l> v436 = v435.v.case1.v0; array<Card,3l> v437 = v435.v.case1.v1;
                    array<Card,1l> v438;
                    int32_t v439;
                    v439 = 0l;
                    while (while_method_11(v439)){
                        Card v441;
                        v441 = v437.v[v439];
                        v438.v[v439] = v441;
                        v439 += 1l ;
                    }
                    array<Card,0l> v442;
                    array<Card,5l> v443;
                    int32_t v444;
                    v444 = 0l;
                    while (while_method_12(v444)){
                        Card v446;
                        v446 = v436.v[v444];
                        v443.v[v444] = v446;
                        v444 += 1l ;
                    }
                    int32_t v447;
                    v447 = 0l;
                    while (while_method_11(v447)){
                        Card v449;
                        v449 = v438.v[v447];
                        int32_t v450;
                        v450 = 4l + v447;
                        v443.v[v450] = v449;
                        v447 += 1l ;
                    }
                    v454 = US4_1(v443);
                }
            }
            switch (v454.tag) {
                case 0: { // None
                    array<Card,3l> v456;
                    array<Card,4l> v457;
                    int32_t v458; int32_t v459; int32_t v460; uint8_t v461;
                    Tuple9 tmp26 = Tuple9(0l, 0l, 0l, 12u);
                    v458 = tmp26.v0; v459 = tmp26.v1; v460 = tmp26.v2; v461 = tmp26.v3;
                    while (while_method_5(v458)){
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
                    US6 v486;
                    if (v476){
                        int32_t v477;
                        v477 = 0l;
                        while (while_method_12(v477)){
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
                        v486 = US6_1(v456, v457);
                    } else {
                        v486 = US6_0();
                    }
                    US4 v537;
                    switch (v486.tag) {
                        case 0: { // None
                            v537 = US4_0();
                            break;
                        }
                        default: { // Some
                            array<Card,3l> v487 = v486.v.case1.v0; array<Card,4l> v488 = v486.v.case1.v1;
                            array<Card,2l> v489;
                            array<Card,2l> v490;
                            int32_t v491; int32_t v492; int32_t v493; uint8_t v494;
                            Tuple9 tmp27 = Tuple9(0l, 0l, 0l, 12u);
                            v491 = tmp27.v0; v492 = tmp27.v1; v493 = tmp27.v2; v494 = tmp27.v3;
                            while (while_method_12(v491)){
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
                            US7 v519;
                            if (v509){
                                int32_t v510;
                                v510 = 0l;
                                while (while_method_13(v510)){
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
                                v519 = US7_1(v489, v490);
                            } else {
                                v519 = US7_0();
                            }
                            switch (v519.tag) {
                                case 0: { // None
                                    v537 = US4_0();
                                    break;
                                }
                                default: { // Some
                                    array<Card,2l> v520 = v519.v.case1.v0; array<Card,2l> v521 = v519.v.case1.v1;
                                    array<Card,0l> v522;
                                    array<Card,5l> v523;
                                    int32_t v524;
                                    v524 = 0l;
                                    while (while_method_10(v524)){
                                        Card v526;
                                        v526 = v487.v[v524];
                                        v523.v[v524] = v526;
                                        v524 += 1l ;
                                    }
                                    int32_t v527;
                                    v527 = 0l;
                                    while (while_method_13(v527)){
                                        Card v529;
                                        v529 = v520.v[v527];
                                        int32_t v530;
                                        v530 = 3l + v527;
                                        v523.v[v530] = v529;
                                        v527 += 1l ;
                                    }
                                    v537 = US4_1(v523);
                                }
                            }
                        }
                    }
                    switch (v537.tag) {
                        case 0: { // None
                            array<Card,5l> v539;
                            int32_t v540; int32_t v541;
                            Tuple10 tmp28 = Tuple10(0l, 0l);
                            v540 = tmp28.v0; v541 = tmp28.v1;
                            while (while_method_5(v540)){
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
                            US4 v553;
                            if (v550){
                                v553 = US4_1(v539);
                            } else {
                                v553 = US4_0();
                            }
                            array<Card,5l> v554;
                            int32_t v555; int32_t v556;
                            Tuple10 tmp29 = Tuple10(0l, 0l);
                            v555 = tmp29.v0; v556 = tmp29.v1;
                            while (while_method_5(v555)){
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
                            US4 v568;
                            if (v565){
                                v568 = US4_1(v554);
                            } else {
                                v568 = US4_0();
                            }
                            US4 v594;
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
                                            US3 v571;
                                            v571 = US3_0();
                                            int32_t v572; US3 v573;
                                            Tuple8 tmp30 = Tuple8(0l, v571);
                                            v572 = tmp30.v0; v573 = tmp30.v1;
                                            while (while_method_9(v572)){
                                                Card v575;
                                                v575 = v569.v[v572];
                                                Card v576;
                                                v576 = v570.v[v572];
                                                US3 v587;
                                                switch (v573.tag) {
                                                    case 0: { // Eq
                                                        uint8_t v577;
                                                        v577 = v575.rank;
                                                        uint8_t v578;
                                                        v578 = v576.rank;
                                                        bool v579;
                                                        v579 = v577 < v578;
                                                        if (v579){
                                                            v587 = US3_2();
                                                        } else {
                                                            bool v581;
                                                            v581 = v577 > v578;
                                                            if (v581){
                                                                v587 = US3_1();
                                                            } else {
                                                                v587 = US3_0();
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
                                            v594 = US4_1(v589);
                                        }
                                    }
                                }
                            }
                            array<Card,5l> v595;
                            int32_t v596; int32_t v597;
                            Tuple10 tmp31 = Tuple10(0l, 0l);
                            v596 = tmp31.v0; v597 = tmp31.v1;
                            while (while_method_5(v596)){
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
                            US4 v609;
                            if (v606){
                                v609 = US4_1(v595);
                            } else {
                                v609 = US4_0();
                            }
                            US4 v635;
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
                                            US3 v612;
                                            v612 = US3_0();
                                            int32_t v613; US3 v614;
                                            Tuple8 tmp32 = Tuple8(0l, v612);
                                            v613 = tmp32.v0; v614 = tmp32.v1;
                                            while (while_method_9(v613)){
                                                Card v616;
                                                v616 = v610.v[v613];
                                                Card v617;
                                                v617 = v611.v[v613];
                                                US3 v628;
                                                switch (v614.tag) {
                                                    case 0: { // Eq
                                                        uint8_t v618;
                                                        v618 = v616.rank;
                                                        uint8_t v619;
                                                        v619 = v617.rank;
                                                        bool v620;
                                                        v620 = v618 < v619;
                                                        if (v620){
                                                            v628 = US3_2();
                                                        } else {
                                                            bool v622;
                                                            v622 = v618 > v619;
                                                            if (v622){
                                                                v628 = US3_1();
                                                            } else {
                                                                v628 = US3_0();
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
                                            v635 = US4_1(v630);
                                        }
                                    }
                                }
                            }
                            array<Card,5l> v636;
                            int32_t v637; int32_t v638;
                            Tuple10 tmp33 = Tuple10(0l, 0l);
                            v637 = tmp33.v0; v638 = tmp33.v1;
                            while (while_method_5(v637)){
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
                            US4 v650;
                            if (v647){
                                v650 = US4_1(v636);
                            } else {
                                v650 = US4_0();
                            }
                            US4 v676;
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
                                            US3 v653;
                                            v653 = US3_0();
                                            int32_t v654; US3 v655;
                                            Tuple8 tmp34 = Tuple8(0l, v653);
                                            v654 = tmp34.v0; v655 = tmp34.v1;
                                            while (while_method_9(v654)){
                                                Card v657;
                                                v657 = v651.v[v654];
                                                Card v658;
                                                v658 = v652.v[v654];
                                                US3 v669;
                                                switch (v655.tag) {
                                                    case 0: { // Eq
                                                        uint8_t v659;
                                                        v659 = v657.rank;
                                                        uint8_t v660;
                                                        v660 = v658.rank;
                                                        bool v661;
                                                        v661 = v659 < v660;
                                                        if (v661){
                                                            v669 = US3_2();
                                                        } else {
                                                            bool v663;
                                                            v663 = v659 > v660;
                                                            if (v663){
                                                                v669 = US3_1();
                                                            } else {
                                                                v669 = US3_0();
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
                                            v676 = US4_1(v671);
                                        }
                                    }
                                }
                            }
                            switch (v676.tag) {
                                case 0: { // None
                                    array<Card,5l> v678;
                                    int32_t v679; int32_t v680; uint8_t v681;
                                    Tuple7 tmp35 = Tuple7(0l, 0l, 12u);
                                    v679 = tmp35.v0; v680 = tmp35.v1; v681 = tmp35.v2;
                                    while (while_method_5(v679)){
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
                                    US4 v715;
                                    if (v709){
                                        v715 = US4_1(v678);
                                    } else {
                                        bool v711;
                                        v711 = v680 == 5l;
                                        if (v711){
                                            v715 = US4_1(v678);
                                        } else {
                                            v715 = US4_0();
                                        }
                                    }
                                    switch (v715.tag) {
                                        case 0: { // None
                                            array<Card,3l> v717;
                                            array<Card,4l> v718;
                                            int32_t v719; int32_t v720; int32_t v721; uint8_t v722;
                                            Tuple9 tmp36 = Tuple9(0l, 0l, 0l, 12u);
                                            v719 = tmp36.v0; v720 = tmp36.v1; v721 = tmp36.v2; v722 = tmp36.v3;
                                            while (while_method_5(v719)){
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
                                            US6 v747;
                                            if (v737){
                                                int32_t v738;
                                                v738 = 0l;
                                                while (while_method_12(v738)){
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
                                                v747 = US6_1(v717, v718);
                                            } else {
                                                v747 = US6_0();
                                            }
                                            US4 v766;
                                            switch (v747.tag) {
                                                case 0: { // None
                                                    v766 = US4_0();
                                                    break;
                                                }
                                                default: { // Some
                                                    array<Card,3l> v748 = v747.v.case1.v0; array<Card,4l> v749 = v747.v.case1.v1;
                                                    array<Card,2l> v750;
                                                    int32_t v751;
                                                    v751 = 0l;
                                                    while (while_method_13(v751)){
                                                        Card v753;
                                                        v753 = v749.v[v751];
                                                        v750.v[v751] = v753;
                                                        v751 += 1l ;
                                                    }
                                                    array<Card,0l> v754;
                                                    array<Card,5l> v755;
                                                    int32_t v756;
                                                    v756 = 0l;
                                                    while (while_method_10(v756)){
                                                        Card v758;
                                                        v758 = v748.v[v756];
                                                        v755.v[v756] = v758;
                                                        v756 += 1l ;
                                                    }
                                                    int32_t v759;
                                                    v759 = 0l;
                                                    while (while_method_13(v759)){
                                                        Card v761;
                                                        v761 = v750.v[v759];
                                                        int32_t v762;
                                                        v762 = 3l + v759;
                                                        v755.v[v762] = v761;
                                                        v759 += 1l ;
                                                    }
                                                    v766 = US4_1(v755);
                                                }
                                            }
                                            switch (v766.tag) {
                                                case 0: { // None
                                                    array<Card,2l> v768;
                                                    array<Card,5l> v769;
                                                    int32_t v770; int32_t v771; int32_t v772; uint8_t v773;
                                                    Tuple9 tmp37 = Tuple9(0l, 0l, 0l, 12u);
                                                    v770 = tmp37.v0; v771 = tmp37.v1; v772 = tmp37.v2; v773 = tmp37.v3;
                                                    while (while_method_5(v770)){
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
                                                    US8 v798;
                                                    if (v788){
                                                        int32_t v789;
                                                        v789 = 0l;
                                                        while (while_method_9(v789)){
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
                                                        v798 = US8_1(v768, v769);
                                                    } else {
                                                        v798 = US8_0();
                                                    }
                                                    US4 v856;
                                                    switch (v798.tag) {
                                                        case 0: { // None
                                                            v856 = US4_0();
                                                            break;
                                                        }
                                                        default: { // Some
                                                            array<Card,2l> v799 = v798.v.case1.v0; array<Card,5l> v800 = v798.v.case1.v1;
                                                            array<Card,2l> v801;
                                                            array<Card,3l> v802;
                                                            int32_t v803; int32_t v804; int32_t v805; uint8_t v806;
                                                            Tuple9 tmp38 = Tuple9(0l, 0l, 0l, 12u);
                                                            v803 = tmp38.v0; v804 = tmp38.v1; v805 = tmp38.v2; v806 = tmp38.v3;
                                                            while (while_method_9(v803)){
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
                                                            US9 v831;
                                                            if (v821){
                                                                int32_t v822;
                                                                v822 = 0l;
                                                                while (while_method_10(v822)){
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
                                                                v831 = US9_1(v801, v802);
                                                            } else {
                                                                v831 = US9_0();
                                                            }
                                                            switch (v831.tag) {
                                                                case 0: { // None
                                                                    v856 = US4_0();
                                                                    break;
                                                                }
                                                                default: { // Some
                                                                    array<Card,2l> v832 = v831.v.case1.v0; array<Card,3l> v833 = v831.v.case1.v1;
                                                                    array<Card,1l> v834;
                                                                    int32_t v835;
                                                                    v835 = 0l;
                                                                    while (while_method_11(v835)){
                                                                        Card v837;
                                                                        v837 = v833.v[v835];
                                                                        v834.v[v835] = v837;
                                                                        v835 += 1l ;
                                                                    }
                                                                    array<Card,5l> v838;
                                                                    int32_t v839;
                                                                    v839 = 0l;
                                                                    while (while_method_13(v839)){
                                                                        Card v841;
                                                                        v841 = v799.v[v839];
                                                                        v838.v[v839] = v841;
                                                                        v839 += 1l ;
                                                                    }
                                                                    int32_t v842;
                                                                    v842 = 0l;
                                                                    while (while_method_13(v842)){
                                                                        Card v844;
                                                                        v844 = v832.v[v842];
                                                                        int32_t v845;
                                                                        v845 = 2l + v842;
                                                                        v838.v[v845] = v844;
                                                                        v842 += 1l ;
                                                                    }
                                                                    int32_t v846;
                                                                    v846 = 0l;
                                                                    while (while_method_11(v846)){
                                                                        Card v848;
                                                                        v848 = v834.v[v846];
                                                                        int32_t v849;
                                                                        v849 = 4l + v846;
                                                                        v838.v[v849] = v848;
                                                                        v846 += 1l ;
                                                                    }
                                                                    v856 = US4_1(v838);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    switch (v856.tag) {
                                                        case 0: { // None
                                                            array<Card,2l> v858;
                                                            array<Card,5l> v859;
                                                            int32_t v860; int32_t v861; int32_t v862; uint8_t v863;
                                                            Tuple9 tmp39 = Tuple9(0l, 0l, 0l, 12u);
                                                            v860 = tmp39.v0; v861 = tmp39.v1; v862 = tmp39.v2; v863 = tmp39.v3;
                                                            while (while_method_5(v860)){
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
                                                            US8 v888;
                                                            if (v878){
                                                                int32_t v879;
                                                                v879 = 0l;
                                                                while (while_method_9(v879)){
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
                                                                v888 = US8_1(v858, v859);
                                                            } else {
                                                                v888 = US8_0();
                                                            }
                                                            US4 v907;
                                                            switch (v888.tag) {
                                                                case 0: { // None
                                                                    v907 = US4_0();
                                                                    break;
                                                                }
                                                                default: { // Some
                                                                    array<Card,2l> v889 = v888.v.case1.v0; array<Card,5l> v890 = v888.v.case1.v1;
                                                                    array<Card,3l> v891;
                                                                    int32_t v892;
                                                                    v892 = 0l;
                                                                    while (while_method_10(v892)){
                                                                        Card v894;
                                                                        v894 = v890.v[v892];
                                                                        v891.v[v892] = v894;
                                                                        v892 += 1l ;
                                                                    }
                                                                    array<Card,0l> v895;
                                                                    array<Card,5l> v896;
                                                                    int32_t v897;
                                                                    v897 = 0l;
                                                                    while (while_method_13(v897)){
                                                                        Card v899;
                                                                        v899 = v889.v[v897];
                                                                        v896.v[v897] = v899;
                                                                        v897 += 1l ;
                                                                    }
                                                                    int32_t v900;
                                                                    v900 = 0l;
                                                                    while (while_method_10(v900)){
                                                                        Card v902;
                                                                        v902 = v891.v[v900];
                                                                        int32_t v903;
                                                                        v903 = 2l + v900;
                                                                        v896.v[v903] = v902;
                                                                        v900 += 1l ;
                                                                    }
                                                                    v907 = US4_1(v896);
                                                                }
                                                            }
                                                            switch (v907.tag) {
                                                                case 0: { // None
                                                                    array<Card,5l> v909;
                                                                    int32_t v910;
                                                                    v910 = 0l;
                                                                    while (while_method_9(v910)){
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
    return Tuple4(v943, v944);
}
__device__ Tuple4 score_7(Card v0, Card v1, Card v2, Card v3, Card v4, Card v5, Card v6){
    array<Card,7l> v7;
    v7.v[0l] = v5;
    v7.v[1l] = v6;
    v7.v[2l] = v0;
    v7.v[3l] = v1;
    v7.v[4l] = v2;
    v7.v[5l] = v3;
    v7.v[6l] = v4;
    return score_8(v7);
}
__device__ inline bool while_method_14(array<Card,5l> v0, US3 v1, int32_t v2){
    bool v3;
    v3 = v2 < 5l;
    return v3;
}
__device__ US3 method_9(array<Card,5l> v0, array<Card,5l> v1){
    US3 v2;
    v2 = US3_0();
    US3 v3; int32_t v4;
    Tuple11 tmp42 = Tuple11(v2, 0l);
    v3 = tmp42.v0; v4 = tmp42.v1;
    while (while_method_14(v0, v3, v4)){
        US3 v20; int32_t v21;
        switch (v3.tag) {
            case 0: { // Eq
                Card v6;
                v6 = v0.v[v4];
                Card v7;
                v7 = v1.v[v4];
                uint8_t v8;
                v8 = v6.suit * 13 + v6.rank;
                uint8_t v9;
                v9 = v7.suit * 13 + v7.rank;
                bool v10;
                v10 = v8 < v9;
                US3 v16;
                if (v10){
                    v16 = US3_2();
                } else {
                    bool v12;
                    v12 = v8 > v9;
                    if (v12){
                        v16 = US3_1();
                    } else {
                        v16 = US3_0();
                    }
                }
                int32_t v17;
                v17 = v4 + 1l;
                v20 = v16; v21 = v17;
                break;
            }
            default: {
                // hello;
                return v3;
            }
        }
        v3 = v20;
        v4 = v21;
    }
    return v3;
}
__device__ int16_t game_1(uint64_t * v0, curandStatePhilox4_32_10_t * v1){
    uint64_t v2 = *v0;
    Card v3; uint64_t v4;
    Tuple1 tmp1 = draw_card_2(v1, v2);
    v3 = tmp1.v0; v4 = tmp1.v1;
    *v0 = v4;
    uint64_t v5 = *v0;
    Card v6; uint64_t v7;
    Tuple1 tmp2 = draw_card_2(v1, v5);
    v6 = tmp2.v0; v7 = tmp2.v1;
    *v0 = v7;
    uint64_t v8 = *v0;
    Card v9; uint64_t v10;
    Tuple1 tmp3 = draw_card_2(v1, v8);
    v9 = tmp3.v0; v10 = tmp3.v1;
    *v0 = v10;
    uint64_t v11 = *v0;
    Card v12; uint64_t v13;
    Tuple1 tmp4 = draw_card_2(v1, v11);
    v12 = tmp4.v0; v13 = tmp4.v1;
    *v0 = v13;
    US0 v26;
    v26 = US0_1(v3, v6);
    US0 v27;
    v27 = US0_1(v9, v12);
    US1 v28;
    v28 = US1_1(2, 0);
    uint8_t v29; US0 v30; int16_t v31; US0 v32; int16_t v33; US1 v34;
    Tuple2 tmp5 = Tuple2(11u, v26, 2, v27, 1, v28);
    v29 = tmp5.v0; v30 = tmp5.v1; v31 = tmp5.v2; v32 = tmp5.v3; v33 = tmp5.v4; v34 = tmp5.v5;
    while (while_method_1(v29, v30, v31, v32, v33, v34)){
        US0 v128; int16_t v129; US0 v130; int16_t v131; US1 v132;
        switch (v34.tag) {
            case 0: { // Done
                US1 v36;
                v36 = US1_0();
                v128 = v30; v129 = v31; v130 = v32; v131 = v33; v132 = v36;
                break;
            }
            default: { // TurnOf
                int8_t v37 = v34.v.case1.v0; int8_t v38 = v34.v.case1.v1;
                bool v39;
                v39 = v38 == 0;
                US0 v40; int16_t v41; US0 v42; int16_t v43; int8_t v44;
                if (v39){
                    v40 = v30; v41 = v31; v42 = v32; v43 = v33; v44 = 1;
                } else {
                    v40 = v32; v41 = v33; v42 = v30; v43 = v31; v44 = 0;
                }
                bool v45;
                v45 = v41 >= v43;
                int16_t v46;
                if (v45){
                    v46 = v41;
                } else {
                    v46 = v43;
                }
                int16_t v47;
                v47 = v46 + v43;
                bool v48;
                v48 = v41 < v43;
                float v49;
                if (v48){
                    v49 = 1.0f;
                } else {
                    v49 = 0.0f;
                }
                int16_t v50;
                v50 = v47 / 4;
                int16_t v51;
                v51 = v47 + v50;
                int16_t v52;
                v52 = v43 + 2;
                bool v53;
                v53 = v52 <= v51;
                bool v55;
                if (v53){
                    bool v54;
                    v54 = v51 <= 100;
                    v55 = v54;
                } else {
                    v55 = false;
                }
                float v56;
                if (v55){
                    v56 = 0.25f;
                } else {
                    v56 = 0.0f;
                }
                int16_t v57;
                v57 = v47 / 3;
                int16_t v58;
                v58 = v47 + v57;
                bool v59;
                v59 = v52 <= v58;
                bool v61;
                if (v59){
                    bool v60;
                    v60 = v58 <= 100;
                    v61 = v60;
                } else {
                    v61 = false;
                }
                float v62;
                if (v61){
                    v62 = 0.25f;
                } else {
                    v62 = 0.0f;
                }
                int16_t v63;
                v63 = v47 / 2;
                int16_t v64;
                v64 = v47 + v63;
                bool v65;
                v65 = v52 <= v64;
                bool v67;
                if (v65){
                    bool v66;
                    v66 = v64 <= 100;
                    v67 = v66;
                } else {
                    v67 = false;
                }
                float v68;
                if (v67){
                    v68 = 0.25f;
                } else {
                    v68 = 0.0f;
                }
                int16_t v69;
                v69 = v47 + v47;
                bool v70;
                v70 = v52 <= v69;
                bool v72;
                if (v70){
                    bool v71;
                    v71 = v69 <= 100;
                    v72 = v71;
                } else {
                    v72 = false;
                }
                float v73;
                if (v72){
                    v73 = 0.25f;
                } else {
                    v73 = 0.0f;
                }
                int16_t v74;
                v74 = v47 * 3;
                int16_t v75;
                v75 = v74 / 2;
                int16_t v76;
                v76 = v47 + v75;
                bool v77;
                v77 = v52 <= v76;
                bool v79;
                if (v77){
                    bool v78;
                    v78 = v76 <= 100;
                    v79 = v78;
                } else {
                    v79 = false;
                }
                float v80;
                if (v79){
                    v80 = 0.25f;
                } else {
                    v80 = 0.0f;
                }
                bool v81;
                v81 = v41 < 100;
                float v82;
                if (v81){
                    v82 = 0.3f;
                } else {
                    v82 = 0.0f;
                }
                array<Tuple3,8l> v83;
                US2 v84;
                v84 = US2_1();
                v83.v[0l] = Tuple3(v84, v49);
                US2 v85;
                v85 = US2_0();
                v83.v[1l] = Tuple3(v85, 2.0f);
                US2 v86;
                v86 = US2_2(v51);
                v83.v[2l] = Tuple3(v86, v56);
                US2 v87;
                v87 = US2_2(v58);
                v83.v[3l] = Tuple3(v87, v62);
                US2 v88;
                v88 = US2_2(v64);
                v83.v[4l] = Tuple3(v88, v68);
                US2 v89;
                v89 = US2_2(v69);
                v83.v[5l] = Tuple3(v89, v73);
                US2 v90;
                v90 = US2_2(v76);
                v83.v[6l] = Tuple3(v90, v80);
                US2 v91;
                v91 = US2_2(100);
                v83.v[7l] = Tuple3(v91, v82);
                US2 v92;
                v92 = sample_discrete_4(v83, v1);
                US0 v116; int16_t v117; US1 v118;
                switch (v92.tag) {
                    case 0: { // Call
                        bool v95;
                        v95 = v43 >= v41;
                        int16_t v96;
                        if (v95){
                            v96 = v43;
                        } else {
                            v96 = v41;
                        }
                        bool v97;
                        v97 = 0 < v37;
                        US1 v101;
                        if (v97){
                            int8_t v98;
                            v98 = v37 - 1;
                            v101 = US1_1(v98, v44);
                        } else {
                            v101 = US1_0();
                        }
                        v116 = v40; v117 = v96; v118 = v101;
                        break;
                    }
                    case 1: { // Fold
                        US0 v93;
                        v93 = US0_0();
                        US1 v94;
                        v94 = US1_0();
                        v116 = v93; v117 = v41; v118 = v94;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v102 = v92.v.case2.v0;
                        bool v103;
                        v103 = v102 >= v41;
                        int16_t v104;
                        if (v103){
                            v104 = v102;
                        } else {
                            v104 = v41;
                        }
                        bool v105;
                        v105 = v52 >= v104;
                        int16_t v106;
                        if (v105){
                            v106 = v52;
                        } else {
                            v106 = v104;
                        }
                        bool v107;
                        v107 = 100 < v106;
                        int16_t v108;
                        if (v107){
                            v108 = 100;
                        } else {
                            v108 = v106;
                        }
                        US1 v109;
                        v109 = US1_1(0, v44);
                        v116 = v40; v117 = v108; v118 = v109;
                    }
                }
                US0 v119; int16_t v120; US0 v121; int16_t v122;
                if (v39){
                    v119 = v116; v120 = v117; v121 = v42; v122 = v43;
                } else {
                    v119 = v42; v120 = v43; v121 = v116; v122 = v117;
                }
                v128 = v119; v129 = v120; v130 = v121; v131 = v122; v132 = v118;
            }
        }
        uint8_t v133;
        v133 = v29 - 1u;
        v29 = v133;
        v30 = v128;
        v31 = v129;
        v32 = v130;
        v33 = v131;
        v34 = v132;
    }
    uint64_t v134 = *v0;
    Card v135; uint64_t v136;
    Tuple1 tmp8 = draw_card_2(v1, v134);
    v135 = tmp8.v0; v136 = tmp8.v1;
    *v0 = v136;
    uint64_t v137 = *v0;
    Card v138; uint64_t v139;
    Tuple1 tmp9 = draw_card_2(v1, v137);
    v138 = tmp9.v0; v139 = tmp9.v1;
    *v0 = v139;
    uint64_t v140 = *v0;
    Card v141; uint64_t v142;
    Tuple1 tmp10 = draw_card_2(v1, v140);
    v141 = tmp10.v0; v142 = tmp10.v1;
    *v0 = v142;
    bool v152;
    v152 = v31 == 2;
    bool v157;
    if (v152){
        bool v155;
        v155 = v33 == 1;
        v157 = v155;
    } else {
        v157 = false;
    }
    int8_t v158;
    if (v157){
        v158 = 2;
    } else {
        v158 = 1;
    }
    US1 v159;
    v159 = US1_1(v158, 0);
    uint8_t v160; US0 v161; int16_t v162; US0 v163; int16_t v164; US1 v165;
    Tuple2 tmp11 = Tuple2(11u, v30, v31, v32, v33, v159);
    v160 = tmp11.v0; v161 = tmp11.v1; v162 = tmp11.v2; v163 = tmp11.v3; v164 = tmp11.v4; v165 = tmp11.v5;
    while (while_method_1(v160, v161, v162, v163, v164, v165)){
        US0 v259; int16_t v260; US0 v261; int16_t v262; US1 v263;
        switch (v165.tag) {
            case 0: { // Done
                US1 v167;
                v167 = US1_0();
                v259 = v161; v260 = v162; v261 = v163; v262 = v164; v263 = v167;
                break;
            }
            default: { // TurnOf
                int8_t v168 = v165.v.case1.v0; int8_t v169 = v165.v.case1.v1;
                bool v170;
                v170 = v169 == 0;
                US0 v171; int16_t v172; US0 v173; int16_t v174; int8_t v175;
                if (v170){
                    v171 = v161; v172 = v162; v173 = v163; v174 = v164; v175 = 1;
                } else {
                    v171 = v163; v172 = v164; v173 = v161; v174 = v162; v175 = 0;
                }
                bool v176;
                v176 = v172 >= v174;
                int16_t v177;
                if (v176){
                    v177 = v172;
                } else {
                    v177 = v174;
                }
                int16_t v178;
                v178 = v177 + v174;
                bool v179;
                v179 = v172 < v174;
                float v180;
                if (v179){
                    v180 = 1.0f;
                } else {
                    v180 = 0.0f;
                }
                int16_t v181;
                v181 = v178 / 4;
                int16_t v182;
                v182 = v178 + v181;
                int16_t v183;
                v183 = v174 + 2;
                bool v184;
                v184 = v183 <= v182;
                bool v186;
                if (v184){
                    bool v185;
                    v185 = v182 <= 100;
                    v186 = v185;
                } else {
                    v186 = false;
                }
                float v187;
                if (v186){
                    v187 = 0.25f;
                } else {
                    v187 = 0.0f;
                }
                int16_t v188;
                v188 = v178 / 3;
                int16_t v189;
                v189 = v178 + v188;
                bool v190;
                v190 = v183 <= v189;
                bool v192;
                if (v190){
                    bool v191;
                    v191 = v189 <= 100;
                    v192 = v191;
                } else {
                    v192 = false;
                }
                float v193;
                if (v192){
                    v193 = 0.25f;
                } else {
                    v193 = 0.0f;
                }
                int16_t v194;
                v194 = v178 / 2;
                int16_t v195;
                v195 = v178 + v194;
                bool v196;
                v196 = v183 <= v195;
                bool v198;
                if (v196){
                    bool v197;
                    v197 = v195 <= 100;
                    v198 = v197;
                } else {
                    v198 = false;
                }
                float v199;
                if (v198){
                    v199 = 0.25f;
                } else {
                    v199 = 0.0f;
                }
                int16_t v200;
                v200 = v178 + v178;
                bool v201;
                v201 = v183 <= v200;
                bool v203;
                if (v201){
                    bool v202;
                    v202 = v200 <= 100;
                    v203 = v202;
                } else {
                    v203 = false;
                }
                float v204;
                if (v203){
                    v204 = 0.25f;
                } else {
                    v204 = 0.0f;
                }
                int16_t v205;
                v205 = v178 * 3;
                int16_t v206;
                v206 = v205 / 2;
                int16_t v207;
                v207 = v178 + v206;
                bool v208;
                v208 = v183 <= v207;
                bool v210;
                if (v208){
                    bool v209;
                    v209 = v207 <= 100;
                    v210 = v209;
                } else {
                    v210 = false;
                }
                float v211;
                if (v210){
                    v211 = 0.25f;
                } else {
                    v211 = 0.0f;
                }
                bool v212;
                v212 = v172 < 100;
                float v213;
                if (v212){
                    v213 = 0.3f;
                } else {
                    v213 = 0.0f;
                }
                array<Tuple3,8l> v214;
                US2 v215;
                v215 = US2_1();
                v214.v[0l] = Tuple3(v215, v180);
                US2 v216;
                v216 = US2_0();
                v214.v[1l] = Tuple3(v216, 2.0f);
                US2 v217;
                v217 = US2_2(v182);
                v214.v[2l] = Tuple3(v217, v187);
                US2 v218;
                v218 = US2_2(v189);
                v214.v[3l] = Tuple3(v218, v193);
                US2 v219;
                v219 = US2_2(v195);
                v214.v[4l] = Tuple3(v219, v199);
                US2 v220;
                v220 = US2_2(v200);
                v214.v[5l] = Tuple3(v220, v204);
                US2 v221;
                v221 = US2_2(v207);
                v214.v[6l] = Tuple3(v221, v211);
                US2 v222;
                v222 = US2_2(100);
                v214.v[7l] = Tuple3(v222, v213);
                US2 v223;
                v223 = sample_discrete_4(v214, v1);
                US0 v247; int16_t v248; US1 v249;
                switch (v223.tag) {
                    case 0: { // Call
                        bool v226;
                        v226 = v174 >= v172;
                        int16_t v227;
                        if (v226){
                            v227 = v174;
                        } else {
                            v227 = v172;
                        }
                        bool v228;
                        v228 = 0 < v168;
                        US1 v232;
                        if (v228){
                            int8_t v229;
                            v229 = v168 - 1;
                            v232 = US1_1(v229, v175);
                        } else {
                            v232 = US1_0();
                        }
                        v247 = v171; v248 = v227; v249 = v232;
                        break;
                    }
                    case 1: { // Fold
                        US0 v224;
                        v224 = US0_0();
                        US1 v225;
                        v225 = US1_0();
                        v247 = v224; v248 = v172; v249 = v225;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v233 = v223.v.case2.v0;
                        bool v234;
                        v234 = v233 >= v172;
                        int16_t v235;
                        if (v234){
                            v235 = v233;
                        } else {
                            v235 = v172;
                        }
                        bool v236;
                        v236 = v183 >= v235;
                        int16_t v237;
                        if (v236){
                            v237 = v183;
                        } else {
                            v237 = v235;
                        }
                        bool v238;
                        v238 = 100 < v237;
                        int16_t v239;
                        if (v238){
                            v239 = 100;
                        } else {
                            v239 = v237;
                        }
                        US1 v240;
                        v240 = US1_1(0, v175);
                        v247 = v171; v248 = v239; v249 = v240;
                    }
                }
                US0 v250; int16_t v251; US0 v252; int16_t v253;
                if (v170){
                    v250 = v247; v251 = v248; v252 = v173; v253 = v174;
                } else {
                    v250 = v173; v251 = v174; v252 = v247; v253 = v248;
                }
                v259 = v250; v260 = v251; v261 = v252; v262 = v253; v263 = v249;
            }
        }
        uint8_t v264;
        v264 = v160 - 1u;
        v160 = v264;
        v161 = v259;
        v162 = v260;
        v163 = v261;
        v164 = v262;
        v165 = v263;
    }
    uint64_t v265 = *v0;
    Card v266; uint64_t v267;
    Tuple1 tmp12 = draw_card_2(v1, v265);
    v266 = tmp12.v0; v267 = tmp12.v1;
    *v0 = v267;
    bool v277;
    v277 = v162 == 2;
    bool v282;
    if (v277){
        bool v280;
        v280 = v164 == 1;
        v282 = v280;
    } else {
        v282 = false;
    }
    int8_t v283;
    if (v282){
        v283 = 2;
    } else {
        v283 = 1;
    }
    US1 v284;
    v284 = US1_1(v283, 0);
    uint8_t v285; US0 v286; int16_t v287; US0 v288; int16_t v289; US1 v290;
    Tuple2 tmp13 = Tuple2(11u, v161, v162, v163, v164, v284);
    v285 = tmp13.v0; v286 = tmp13.v1; v287 = tmp13.v2; v288 = tmp13.v3; v289 = tmp13.v4; v290 = tmp13.v5;
    while (while_method_1(v285, v286, v287, v288, v289, v290)){
        US0 v384; int16_t v385; US0 v386; int16_t v387; US1 v388;
        switch (v290.tag) {
            case 0: { // Done
                US1 v292;
                v292 = US1_0();
                v384 = v286; v385 = v287; v386 = v288; v387 = v289; v388 = v292;
                break;
            }
            default: { // TurnOf
                int8_t v293 = v290.v.case1.v0; int8_t v294 = v290.v.case1.v1;
                bool v295;
                v295 = v294 == 0;
                US0 v296; int16_t v297; US0 v298; int16_t v299; int8_t v300;
                if (v295){
                    v296 = v286; v297 = v287; v298 = v288; v299 = v289; v300 = 1;
                } else {
                    v296 = v288; v297 = v289; v298 = v286; v299 = v287; v300 = 0;
                }
                bool v301;
                v301 = v297 >= v299;
                int16_t v302;
                if (v301){
                    v302 = v297;
                } else {
                    v302 = v299;
                }
                int16_t v303;
                v303 = v302 + v299;
                bool v304;
                v304 = v297 < v299;
                float v305;
                if (v304){
                    v305 = 1.0f;
                } else {
                    v305 = 0.0f;
                }
                int16_t v306;
                v306 = v303 / 4;
                int16_t v307;
                v307 = v303 + v306;
                int16_t v308;
                v308 = v299 + 2;
                bool v309;
                v309 = v308 <= v307;
                bool v311;
                if (v309){
                    bool v310;
                    v310 = v307 <= 100;
                    v311 = v310;
                } else {
                    v311 = false;
                }
                float v312;
                if (v311){
                    v312 = 0.25f;
                } else {
                    v312 = 0.0f;
                }
                int16_t v313;
                v313 = v303 / 3;
                int16_t v314;
                v314 = v303 + v313;
                bool v315;
                v315 = v308 <= v314;
                bool v317;
                if (v315){
                    bool v316;
                    v316 = v314 <= 100;
                    v317 = v316;
                } else {
                    v317 = false;
                }
                float v318;
                if (v317){
                    v318 = 0.25f;
                } else {
                    v318 = 0.0f;
                }
                int16_t v319;
                v319 = v303 / 2;
                int16_t v320;
                v320 = v303 + v319;
                bool v321;
                v321 = v308 <= v320;
                bool v323;
                if (v321){
                    bool v322;
                    v322 = v320 <= 100;
                    v323 = v322;
                } else {
                    v323 = false;
                }
                float v324;
                if (v323){
                    v324 = 0.25f;
                } else {
                    v324 = 0.0f;
                }
                int16_t v325;
                v325 = v303 + v303;
                bool v326;
                v326 = v308 <= v325;
                bool v328;
                if (v326){
                    bool v327;
                    v327 = v325 <= 100;
                    v328 = v327;
                } else {
                    v328 = false;
                }
                float v329;
                if (v328){
                    v329 = 0.25f;
                } else {
                    v329 = 0.0f;
                }
                int16_t v330;
                v330 = v303 * 3;
                int16_t v331;
                v331 = v330 / 2;
                int16_t v332;
                v332 = v303 + v331;
                bool v333;
                v333 = v308 <= v332;
                bool v335;
                if (v333){
                    bool v334;
                    v334 = v332 <= 100;
                    v335 = v334;
                } else {
                    v335 = false;
                }
                float v336;
                if (v335){
                    v336 = 0.25f;
                } else {
                    v336 = 0.0f;
                }
                bool v337;
                v337 = v297 < 100;
                float v338;
                if (v337){
                    v338 = 0.3f;
                } else {
                    v338 = 0.0f;
                }
                array<Tuple3,8l> v339;
                US2 v340;
                v340 = US2_1();
                v339.v[0l] = Tuple3(v340, v305);
                US2 v341;
                v341 = US2_0();
                v339.v[1l] = Tuple3(v341, 2.0f);
                US2 v342;
                v342 = US2_2(v307);
                v339.v[2l] = Tuple3(v342, v312);
                US2 v343;
                v343 = US2_2(v314);
                v339.v[3l] = Tuple3(v343, v318);
                US2 v344;
                v344 = US2_2(v320);
                v339.v[4l] = Tuple3(v344, v324);
                US2 v345;
                v345 = US2_2(v325);
                v339.v[5l] = Tuple3(v345, v329);
                US2 v346;
                v346 = US2_2(v332);
                v339.v[6l] = Tuple3(v346, v336);
                US2 v347;
                v347 = US2_2(100);
                v339.v[7l] = Tuple3(v347, v338);
                US2 v348;
                v348 = sample_discrete_4(v339, v1);
                US0 v372; int16_t v373; US1 v374;
                switch (v348.tag) {
                    case 0: { // Call
                        bool v351;
                        v351 = v299 >= v297;
                        int16_t v352;
                        if (v351){
                            v352 = v299;
                        } else {
                            v352 = v297;
                        }
                        bool v353;
                        v353 = 0 < v293;
                        US1 v357;
                        if (v353){
                            int8_t v354;
                            v354 = v293 - 1;
                            v357 = US1_1(v354, v300);
                        } else {
                            v357 = US1_0();
                        }
                        v372 = v296; v373 = v352; v374 = v357;
                        break;
                    }
                    case 1: { // Fold
                        US0 v349;
                        v349 = US0_0();
                        US1 v350;
                        v350 = US1_0();
                        v372 = v349; v373 = v297; v374 = v350;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v358 = v348.v.case2.v0;
                        bool v359;
                        v359 = v358 >= v297;
                        int16_t v360;
                        if (v359){
                            v360 = v358;
                        } else {
                            v360 = v297;
                        }
                        bool v361;
                        v361 = v308 >= v360;
                        int16_t v362;
                        if (v361){
                            v362 = v308;
                        } else {
                            v362 = v360;
                        }
                        bool v363;
                        v363 = 100 < v362;
                        int16_t v364;
                        if (v363){
                            v364 = 100;
                        } else {
                            v364 = v362;
                        }
                        US1 v365;
                        v365 = US1_1(0, v300);
                        v372 = v296; v373 = v364; v374 = v365;
                    }
                }
                US0 v375; int16_t v376; US0 v377; int16_t v378;
                if (v295){
                    v375 = v372; v376 = v373; v377 = v298; v378 = v299;
                } else {
                    v375 = v298; v376 = v299; v377 = v372; v378 = v373;
                }
                v384 = v375; v385 = v376; v386 = v377; v387 = v378; v388 = v374;
            }
        }
        uint8_t v389;
        v389 = v285 - 1u;
        v285 = v389;
        v286 = v384;
        v287 = v385;
        v288 = v386;
        v289 = v387;
        v290 = v388;
    }
    uint64_t v390 = *v0;
    Card v391; uint64_t v392;
    Tuple1 tmp14 = draw_card_2(v1, v390);
    v391 = tmp14.v0; v392 = tmp14.v1;
    *v0 = v392;
    bool v402;
    v402 = v287 == 2;
    bool v407;
    if (v402){
        bool v405;
        v405 = v289 == 1;
        v407 = v405;
    } else {
        v407 = false;
    }
    int8_t v408;
    if (v407){
        v408 = 2;
    } else {
        v408 = 1;
    }
    US1 v409;
    v409 = US1_1(v408, 0);
    uint8_t v410; US0 v411; int16_t v412; US0 v413; int16_t v414; US1 v415;
    Tuple2 tmp15 = Tuple2(11u, v286, v287, v288, v289, v409);
    v410 = tmp15.v0; v411 = tmp15.v1; v412 = tmp15.v2; v413 = tmp15.v3; v414 = tmp15.v4; v415 = tmp15.v5;
    while (while_method_1(v410, v411, v412, v413, v414, v415)){
        US0 v509; int16_t v510; US0 v511; int16_t v512; US1 v513;
        switch (v415.tag) {
            case 0: { // Done
                US1 v417;
                v417 = US1_0();
                v509 = v411; v510 = v412; v511 = v413; v512 = v414; v513 = v417;
                break;
            }
            default: { // TurnOf
                int8_t v418 = v415.v.case1.v0; int8_t v419 = v415.v.case1.v1;
                bool v420;
                v420 = v419 == 0;
                US0 v421; int16_t v422; US0 v423; int16_t v424; int8_t v425;
                if (v420){
                    v421 = v411; v422 = v412; v423 = v413; v424 = v414; v425 = 1;
                } else {
                    v421 = v413; v422 = v414; v423 = v411; v424 = v412; v425 = 0;
                }
                bool v426;
                v426 = v422 >= v424;
                int16_t v427;
                if (v426){
                    v427 = v422;
                } else {
                    v427 = v424;
                }
                int16_t v428;
                v428 = v427 + v424;
                bool v429;
                v429 = v422 < v424;
                float v430;
                if (v429){
                    v430 = 1.0f;
                } else {
                    v430 = 0.0f;
                }
                int16_t v431;
                v431 = v428 / 4;
                int16_t v432;
                v432 = v428 + v431;
                int16_t v433;
                v433 = v424 + 2;
                bool v434;
                v434 = v433 <= v432;
                bool v436;
                if (v434){
                    bool v435;
                    v435 = v432 <= 100;
                    v436 = v435;
                } else {
                    v436 = false;
                }
                float v437;
                if (v436){
                    v437 = 0.25f;
                } else {
                    v437 = 0.0f;
                }
                int16_t v438;
                v438 = v428 / 3;
                int16_t v439;
                v439 = v428 + v438;
                bool v440;
                v440 = v433 <= v439;
                bool v442;
                if (v440){
                    bool v441;
                    v441 = v439 <= 100;
                    v442 = v441;
                } else {
                    v442 = false;
                }
                float v443;
                if (v442){
                    v443 = 0.25f;
                } else {
                    v443 = 0.0f;
                }
                int16_t v444;
                v444 = v428 / 2;
                int16_t v445;
                v445 = v428 + v444;
                bool v446;
                v446 = v433 <= v445;
                bool v448;
                if (v446){
                    bool v447;
                    v447 = v445 <= 100;
                    v448 = v447;
                } else {
                    v448 = false;
                }
                float v449;
                if (v448){
                    v449 = 0.25f;
                } else {
                    v449 = 0.0f;
                }
                int16_t v450;
                v450 = v428 + v428;
                bool v451;
                v451 = v433 <= v450;
                bool v453;
                if (v451){
                    bool v452;
                    v452 = v450 <= 100;
                    v453 = v452;
                } else {
                    v453 = false;
                }
                float v454;
                if (v453){
                    v454 = 0.25f;
                } else {
                    v454 = 0.0f;
                }
                int16_t v455;
                v455 = v428 * 3;
                int16_t v456;
                v456 = v455 / 2;
                int16_t v457;
                v457 = v428 + v456;
                bool v458;
                v458 = v433 <= v457;
                bool v460;
                if (v458){
                    bool v459;
                    v459 = v457 <= 100;
                    v460 = v459;
                } else {
                    v460 = false;
                }
                float v461;
                if (v460){
                    v461 = 0.25f;
                } else {
                    v461 = 0.0f;
                }
                bool v462;
                v462 = v422 < 100;
                float v463;
                if (v462){
                    v463 = 0.3f;
                } else {
                    v463 = 0.0f;
                }
                array<Tuple3,8l> v464;
                US2 v465;
                v465 = US2_1();
                v464.v[0l] = Tuple3(v465, v430);
                US2 v466;
                v466 = US2_0();
                v464.v[1l] = Tuple3(v466, 2.0f);
                US2 v467;
                v467 = US2_2(v432);
                v464.v[2l] = Tuple3(v467, v437);
                US2 v468;
                v468 = US2_2(v439);
                v464.v[3l] = Tuple3(v468, v443);
                US2 v469;
                v469 = US2_2(v445);
                v464.v[4l] = Tuple3(v469, v449);
                US2 v470;
                v470 = US2_2(v450);
                v464.v[5l] = Tuple3(v470, v454);
                US2 v471;
                v471 = US2_2(v457);
                v464.v[6l] = Tuple3(v471, v461);
                US2 v472;
                v472 = US2_2(100);
                v464.v[7l] = Tuple3(v472, v463);
                US2 v473;
                v473 = sample_discrete_4(v464, v1);
                US0 v497; int16_t v498; US1 v499;
                switch (v473.tag) {
                    case 0: { // Call
                        bool v476;
                        v476 = v424 >= v422;
                        int16_t v477;
                        if (v476){
                            v477 = v424;
                        } else {
                            v477 = v422;
                        }
                        bool v478;
                        v478 = 0 < v418;
                        US1 v482;
                        if (v478){
                            int8_t v479;
                            v479 = v418 - 1;
                            v482 = US1_1(v479, v425);
                        } else {
                            v482 = US1_0();
                        }
                        v497 = v421; v498 = v477; v499 = v482;
                        break;
                    }
                    case 1: { // Fold
                        US0 v474;
                        v474 = US0_0();
                        US1 v475;
                        v475 = US1_0();
                        v497 = v474; v498 = v422; v499 = v475;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v483 = v473.v.case2.v0;
                        bool v484;
                        v484 = v483 >= v422;
                        int16_t v485;
                        if (v484){
                            v485 = v483;
                        } else {
                            v485 = v422;
                        }
                        bool v486;
                        v486 = v433 >= v485;
                        int16_t v487;
                        if (v486){
                            v487 = v433;
                        } else {
                            v487 = v485;
                        }
                        bool v488;
                        v488 = 100 < v487;
                        int16_t v489;
                        if (v488){
                            v489 = 100;
                        } else {
                            v489 = v487;
                        }
                        US1 v490;
                        v490 = US1_1(0, v425);
                        v497 = v421; v498 = v489; v499 = v490;
                    }
                }
                US0 v500; int16_t v501; US0 v502; int16_t v503;
                if (v420){
                    v500 = v497; v501 = v498; v502 = v423; v503 = v424;
                } else {
                    v500 = v423; v501 = v424; v502 = v497; v503 = v498;
                }
                v509 = v500; v510 = v501; v511 = v502; v512 = v503; v513 = v499;
            }
        }
        uint8_t v514;
        v514 = v410 - 1u;
        v410 = v514;
        v411 = v509;
        v412 = v510;
        v413 = v511;
        v414 = v512;
        v415 = v513;
    }
    switch (v411.tag) {
        case 0: { // None
            switch (v413.tag) {
                case 0: { // None
                    return 0;
                    break;
                }
                default: { // Some
                    Card v538 = v413.v.case1.v0; Card v539 = v413.v.case1.v1;
                    int16_t v540;
                    v540 = -v412;
                    return v540;
                }
            }
            break;
        }
        default: { // Some
            Card v515 = v411.v.case1.v0; Card v516 = v411.v.case1.v1;
            switch (v413.tag) {
                case 0: { // None
                    return v414;
                    break;
                }
                default: { // Some
                    Card v517 = v413.v.case1.v0; Card v518 = v413.v.case1.v1;
                    array<Card,5l> v519; int8_t v520;
                    Tuple4 tmp40 = score_7(v135, v138, v141, v266, v391, v515, v516);
                    v519 = tmp40.v0; v520 = tmp40.v1;
                    array<Card,5l> v521; int8_t v522;
                    Tuple4 tmp41 = score_7(v135, v138, v141, v266, v391, v517, v518);
                    v521 = tmp41.v0; v522 = tmp41.v1;
                    bool v523;
                    v523 = v520 < v522;
                    US3 v529;
                    if (v523){
                        v529 = US3_2();
                    } else {
                        bool v525;
                        v525 = v520 > v522;
                        if (v525){
                            v529 = US3_1();
                        } else {
                            v529 = US3_0();
                        }
                    }
                    US3 v531;
                    switch (v529.tag) {
                        case 0: { // Eq
                            v531 = method_9(v519, v521);
                            break;
                        }
                        default: {
                            v531 = v529;
                        }
                    }
                    switch (v531.tag) {
                        case 0: { // Eq
                            return 0;
                            break;
                        }
                        case 1: { // Gt
                            return v414;
                            break;
                        }
                        default: { // Lt
                            int16_t v532;
                            v532 = -v412;
                            return v532;
                        }
                    }
                }
            }
        }
    }
}
__device__ int16_t game_loop_0(){
    int32_t v0;
    v0 = threadIdx.x + blockIdx.x * blockDim.x;
    uint64_t v1;
    v1 = (uint64_t)v0;
    curandStatePhilox4_32_10_t v2;
    curandStatePhilox4_32_10_t * v3 = &v2;
    curand_init(v1,0ull,0ull,v3);
    int32_t v4; int16_t v5;
    Tuple0 tmp0 = Tuple0(0l, 0);
    v4 = tmp0.v0; v5 = tmp0.v1;
    while (while_method_0(v4)){
        uint64_t v7;
        v7 = 4503599627370495ull;
        uint64_t * v8 = &v7;
        int16_t v9;
        v9 = game_1(v8, v3);
        int32_t v10;
        v10 = v4 % 1000l;
        bool v11;
        v11 = v10 == 0l;
        if (v11){
            const char * v12;
            v12 = "%d";
            printf(v12,v4);
            printf("\n");
        } else {
        }
        int16_t v13;
        v13 = v5 + v9;
        v5 = v13;
        v4 += 1l ;
    }
    return v5;
}
extern "C" __global__ void entry0() {
    int16_t v0;
    v0 = game_loop_0();
    const char * v1;
    v1 = "%d";
    printf(v1,v0);
    printf("\n");
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
