#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
#include <iostream>
#include <random>
#include <bitset>
struct Card { uint8_t rank : 4; uint8_t suit : 2; };
#include <cmath>
#include <limits>
#include <algorithm>
struct Tuple0;
int32_t random_int_4(int32_t v0, int32_t v1, std::mt19937 & v2);
struct Tuple1;
int32_t sample_without_3(std::bitset<52l> & v0, std::mt19937 & v1);
Card draw_card_2(std::bitset<52l> & v0, std::mt19937 & v1);
struct US0;
struct US1;
struct Tuple2;
struct US2;
struct Tuple3;
float random_f32_template_7(bool v0, std::mt19937 & v1);
struct US3;
struct Tuple4;
int32_t sample_discrete__6(std::array<float,8l> v0, std::mt19937 & v1);
US2 sample_discrete_5(std::array<Tuple3,8l> v0, std::mt19937 & v1);
struct Tuple5;
typedef bool (* Fun0)(Card, Card);
struct Tuple6;
struct US4;
struct US5;
struct US6;
struct US7;
struct Tuple7;
struct Tuple8;
struct US8;
struct Tuple9;
struct US9;
struct US10;
struct US11;
Tuple5 score_9(std::array<Card,7l> v0);
Tuple5 score_8(Card v0, Card v1, Card v2, Card v3, Card v4, Card v5, Card v6);
struct Tuple10;
US8 method_10(std::array<Card,5l> v0, std::array<Card,5l> v1);
int16_t game_1(std::bitset<52l> & v0, std::mt19937 & v1);
int16_t game_loop_0();
struct Tuple0 {
    int32_t v0;
    int16_t v1;
    Tuple0(int32_t t0, int16_t t1) : v0(t0), v1(t1) {}
    Tuple0() = default;
};
struct Tuple1 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    Tuple1(int32_t t0, int32_t t1, int32_t t2) : v0(t0), v1(t1), v2(t2) {}
    Tuple1() = default;
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
    Tuple2(uint8_t t0, US0 t1, int16_t t2, US0 t3, int16_t t4, US1 t5) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5) {}
    Tuple2() = default;
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
    Tuple3(US2 t0, float t1) : v0(t0), v1(t1) {}
    Tuple3() = default;
};
struct US3 {
    union {
        struct {
            int32_t v0;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple4 {
    US3 v1;
    int32_t v0;
    Tuple4(int32_t t0, US3 t1) : v0(t0), v1(t1) {}
    Tuple4() = default;
};
struct Tuple5 {
    std::array<Card,5l> v0;
    int8_t v1;
    Tuple5(std::array<Card,5l> t0, int8_t t1) : v0(t0), v1(t1) {}
    Tuple5() = default;
};
struct Tuple6 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    uint8_t v3;
    Tuple6(int32_t t0, int32_t t1, int32_t t2, uint8_t t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    Tuple6() = default;
};
struct US4 {
    union {
        struct {
            std::array<Card,2l> v0;
            std::array<Card,5l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US5 {
    union {
        struct {
            std::array<Card,5l> v0;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US6 {
    union {
        struct {
            std::array<Card,2l> v0;
            std::array<Card,3l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US7 {
    union {
        struct {
            std::array<Card,3l> v0;
            std::array<Card,4l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple7 {
    int32_t v0;
    int32_t v1;
    uint8_t v2;
    Tuple7(int32_t t0, int32_t t1, uint8_t t2) : v0(t0), v1(t1), v2(t2) {}
    Tuple7() = default;
};
struct Tuple8 {
    int32_t v0;
    int32_t v1;
    Tuple8(int32_t t0, int32_t t1) : v0(t0), v1(t1) {}
    Tuple8() = default;
};
struct US8 {
    union {
    } v;
    char tag : 2;
};
struct Tuple9 {
    US8 v1;
    int32_t v0;
    Tuple9(int32_t t0, US8 t1) : v0(t0), v1(t1) {}
    Tuple9() = default;
};
struct US9 {
    union {
        struct {
            std::array<Card,2l> v0;
            std::array<Card,2l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US10 {
    union {
        struct {
            std::array<Card,4l> v0;
            std::array<Card,3l> v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct US11 {
    union {
        struct {
            std::array<Card,5l> v0;
            int8_t v1;
        } case1; // Some
    } v;
    char tag : 2;
};
struct Tuple10 {
    US8 v0;
    int32_t v1;
    Tuple10(US8 t0, int32_t t1) : v0(t0), v1(t1) {}
    Tuple10() = default;
};
inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 10000000l;
    return v1;
}
int32_t random_int_4(int32_t v0, int32_t v1, std::mt19937 & v2){
    std::uniform_int_distribution<int32_t> v3(v0, v1);
    int32_t v4;
    v4 = v3(v2);
    return v4;
}
inline bool while_method_1(int32_t v0){
    bool v1;
    v1 = v0 < 52l;
    return v1;
}
int32_t sample_without_3(std::bitset<52l> & v0, std::mt19937 & v1){
    int32_t v2;
    v2 = v0.count();
    int32_t v3;
    v3 = 52l - v2;
    int32_t v4;
    v4 = v3 - 1l;
    int32_t v5;
    v5 = 0l;
    int32_t v6;
    v6 = random_int_4(v5, v4, v1);
    int32_t v7;
    v7 = v6 + 1l;
    int32_t v8; int32_t v9; int32_t v10;
    Tuple1 tmp1 = Tuple1(0l, 0l, v7);
    v8 = tmp1.v0; v9 = tmp1.v1; v10 = tmp1.v2;
    while (while_method_1(v8)){
        bool v12;
        v12 = v10 > 0l;
        int32_t v18; int32_t v19;
        if (v12){
            bool v13;
            v13 = v0[v8];
            int32_t v15;
            if (v13){
                v15 = v10;
            } else {
                int32_t v14;
                v14 = v10 - 1l;
                v15 = v14;
            }
            v18 = v8; v19 = v15;
        } else {
            break;
        }
        v9 = v18;
        v10 = v19;
        v8++;
    }
    v0.set(v9,true);
    return v9;
}
Card draw_card_2(std::bitset<52l> & v0, std::mt19937 & v1){
    int32_t v2;
    v2 = sample_without_3(v0, v1);
    int32_t v3;
    v3 = v2 % 13l;
    uint8_t v4;
    v4 = (uint8_t)v3;
    int32_t v5;
    v5 = v2 / 13l;
    uint8_t v6;
    v6 = (uint8_t)v5;
    Card v7;
    v7 = {v4, v6};
    return v7;
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(Card v0, Card v1) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US1 US1_0() { // Done
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(int8_t v0, int8_t v1) { // TurnOf
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
inline bool while_method_2(uint8_t v0, US0 v1, int16_t v2, US0 v3, int16_t v4, US1 v5){
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
US2 US2_0() { // Call
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1() { // Fold
    US2 x;
    x.tag = 1;
    return x;
}
US2 US2_2(int16_t v0) { // RaiseTo
    US2 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
inline bool while_method_3(int32_t v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
inline bool while_method_4(std::array<float,8l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 8l;
    return v2;
}
inline bool while_method_5(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 > v0;
    return v2;
}
float random_f32_template_7(bool v0, std::mt19937 & v1){
    float v3;
    if (v0){
        float v2;
        v2 = std::nextafter(0.0f, std::numeric_limits<float>::max());
        v3 = v2;
    } else {
        v3 = 0.0f;
    }
    std::uniform_real_distribution<float> v4(v3, 1.0f);
    float v5;
    v5 = v4(v1);
    return v5;
}
US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1(int32_t v0) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
int32_t sample_discrete__6(std::array<float,8l> v0, std::mt19937 & v1){
    std::array<float,8l> v2;
    int32_t v3;
    v3 = 0l;
    while (while_method_3(v3)){
        float v5;
        v5 = v0[v3];
        bool v6;
        v6 = 0.0f >= v5;
        float v7;
        if (v6){
            v7 = 0.0f;
        } else {
            v7 = v5;
        }
        v2[v3] = v7;
        v3++;
    }
    std::array<float,8l> v8;
    int32_t v9;
    v9 = 0l;
    while (while_method_3(v9)){
        float v11;
        v11 = v2[v9];
        v8[v9] = v11;
        v9++;
    }
    int32_t v12;
    v12 = 1l;
    while (while_method_4(v8, v12)){
        int32_t v14;
        v14 = 8l;
        while (while_method_5(v12, v14)){
            v14--;
            int32_t v16;
            v16 = v14 - v12;
            float v17;
            v17 = v8[v16];
            float v18;
            v18 = v8[v14];
            float v19;
            v19 = v17 + v18;
            v8[v14] = v19;
        }
        int32_t v20;
        v20 = v12 * 2l;
        v12 = v20;
    }
    float v21;
    v21 = v8[7l];
    std::array<float,8l> v22;
    int32_t v23;
    v23 = 0l;
    while (while_method_3(v23)){
        float v25;
        v25 = v8[v23];
        float v26;
        v26 = v25 / v21;
        v22[v23] = v26;
        v23++;
    }
    bool v27;
    v27 = false;
    float v28;
    v28 = random_f32_template_7(v27, v1);
    US3 v29;
    v29 = US3_0();
    int32_t v30; US3 v31;
    Tuple4 tmp4 = Tuple4(0l, v29);
    v30 = tmp4.v0; v31 = tmp4.v1;
    while (while_method_3(v30)){
        float v33;
        v33 = v22[v30];
        US3 v37;
        switch (v31.tag) {
            case 0: { // None
                bool v34;
                v34 = v28 < v33;
                if (v34){
                    v37 = US3_1(v30);
                } else {
                    v37 = v31;
                }
                break;
            }
            default: {
                v37 = v31;
            }
        }
        v31 = v37;
        v30++;
    }
    switch (v31.tag) {
        case 0: { // None
            return 0l;
            break;
        }
        default: { // Some
            int32_t v38 = v31.v.case1.v0;
            return v38;
        }
    }
}
US2 sample_discrete_5(std::array<Tuple3,8l> v0, std::mt19937 & v1){
    std::array<float,8l> v2;
    int32_t v3;
    v3 = 0l;
    while (while_method_3(v3)){
        US2 v5; float v6;
        Tuple3 tmp3 = v0[v3];
        v5 = tmp3.v0; v6 = tmp3.v1;
        v2[v3] = v6;
        v3++;
    }
    int32_t v7;
    v7 = sample_discrete__6(v2, v1);
    US2 v8; float v9;
    Tuple3 tmp5 = v0[v7];
    v8 = tmp5.v0; v9 = tmp5.v1;
    return v8;
}
inline bool while_method_6(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
bool ClosureMethod0(Card tup0, Card tup1){
    Card v0 = tup0; Card v1 = tup1;
    uint8_t v2;
    v2 = v0.rank;
    uint8_t v3;
    v3 = v1.rank;
    bool v4;
    v4 = v2 > v3;
    if (v4){
        return true;
    } else {
        uint8_t v5;
        v5 = v0.rank;
        uint8_t v6;
        v6 = v1.rank;
        bool v7;
        v7 = v5 == v6;
        if (v7){
            uint8_t v8;
            v8 = v0.suit;
            uint8_t v9;
            v9 = v1.suit;
            bool v10;
            v10 = v8 < v9;
            return v10;
        } else {
            return false;
        }
    }
}
inline bool while_method_7(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
US4 US4_1(std::array<Card,2l> v0, std::array<Card,5l> v1) { // Some
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(std::array<Card,5l> v0) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
inline bool while_method_8(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
inline bool while_method_9(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
US6 US6_1(std::array<Card,2l> v0, std::array<Card,3l> v1) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
inline bool while_method_10(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
US7 US7_1(std::array<Card,3l> v0, std::array<Card,4l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
inline bool while_method_11(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
US8 US8_0() { // Eq
    US8 x;
    x.tag = 0;
    return x;
}
US8 US8_1() { // Gt
    US8 x;
    x.tag = 1;
    return x;
}
US8 US8_2() { // Lt
    US8 x;
    x.tag = 2;
    return x;
}
US9 US9_0() { // None
    US9 x;
    x.tag = 0;
    return x;
}
US9 US9_1(std::array<Card,2l> v0, std::array<Card,2l> v1) { // Some
    US9 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US10 US10_0() { // None
    US10 x;
    x.tag = 0;
    return x;
}
US10 US10_1(std::array<Card,4l> v0, std::array<Card,3l> v1) { // Some
    US10 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US11 US11_0() { // None
    US11 x;
    x.tag = 0;
    return x;
}
US11 US11_1(std::array<Card,5l> v0, int8_t v1) { // Some
    US11 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple5 score_9(std::array<Card,7l> v0){
    std::array<Card,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_6(v2)){
        Card v4;
        v4 = v0[v2];
        v1[v2] = v4;
        v2++;
    }
    Fun0 v5;
    v5 = ClosureMethod0;
    std::sort(v1.begin(),v1.end(),v5);
    std::array<Card,5l> v6;
    int32_t v7;
    v7 = 0l;
    while (while_method_7(v7)){
        Card v9;
        v9 = v1[v7];
        v6[v7] = v9;
        v7++;
    }
    std::array<Card,2l> v10;
    std::array<Card,5l> v11;
    int32_t v12; int32_t v13; int32_t v14; uint8_t v15;
    Tuple6 tmp9 = Tuple6(0l, 0l, 0l, 12u);
    v12 = tmp9.v0; v13 = tmp9.v1; v14 = tmp9.v2; v15 = tmp9.v3;
    while (while_method_6(v12)){
        Card v17;
        v17 = v1[v12];
        bool v18;
        v18 = v14 < 2l;
        int32_t v27; int32_t v28; uint8_t v29;
        if (v18){
            uint8_t v19;
            v19 = v17.rank;
            bool v20;
            v20 = v15 == v19;
            int32_t v21;
            if (v20){
                v21 = v14;
            } else {
                v21 = 0l;
            }
            v10[v21] = v17;
            int32_t v22;
            v22 = v21 + 1l;
            uint8_t v23;
            v23 = v17.rank;
            v27 = v12; v28 = v22; v29 = v23;
        } else {
            break;
        }
        v13 = v27;
        v14 = v28;
        v15 = v29;
        v12++;
    }
    bool v30;
    v30 = v14 == 2l;
    US4 v40;
    if (v30){
        int32_t v31;
        v31 = 0l;
        while (while_method_7(v31)){
            int32_t v33;
            v33 = v13 + -1l;
            bool v34;
            v34 = v31 < v33;
            int32_t v35;
            if (v34){
                v35 = 0l;
            } else {
                v35 = 2l;
            }
            int32_t v36;
            v36 = v35 + v31;
            Card v37;
            v37 = v1[v36];
            v11[v31] = v37;
            v31++;
        }
        v40 = US4_1(v10, v11);
    } else {
        v40 = US4_0();
    }
    US5 v59;
    switch (v40.tag) {
        case 0: { // None
            v59 = US5_0();
            break;
        }
        default: { // Some
            std::array<Card,2l> v41 = v40.v.case1.v0; std::array<Card,5l> v42 = v40.v.case1.v1;
            std::array<Card,3l> v43;
            int32_t v44;
            v44 = 0l;
            while (while_method_8(v44)){
                Card v46;
                v46 = v42[v44];
                v43[v44] = v46;
                v44++;
            }
            std::array<Card,0l> v47;
            std::array<Card,5l> v48;
            int32_t v49;
            v49 = 0l;
            while (while_method_9(v49)){
                Card v51;
                v51 = v41[v49];
                v48[v49] = v51;
                v49++;
            }
            int32_t v52;
            v52 = 0l;
            while (while_method_8(v52)){
                Card v54;
                v54 = v43[v52];
                int32_t v55;
                v55 = 2l + v52;
                v48[v55] = v54;
                v52++;
            }
            v59 = US5_1(v48);
        }
    }
    std::array<Card,2l> v60;
    std::array<Card,5l> v61;
    int32_t v62; int32_t v63; int32_t v64; uint8_t v65;
    Tuple6 tmp10 = Tuple6(0l, 0l, 0l, 12u);
    v62 = tmp10.v0; v63 = tmp10.v1; v64 = tmp10.v2; v65 = tmp10.v3;
    while (while_method_6(v62)){
        Card v67;
        v67 = v1[v62];
        bool v68;
        v68 = v64 < 2l;
        int32_t v77; int32_t v78; uint8_t v79;
        if (v68){
            uint8_t v69;
            v69 = v67.rank;
            bool v70;
            v70 = v65 == v69;
            int32_t v71;
            if (v70){
                v71 = v64;
            } else {
                v71 = 0l;
            }
            v60[v71] = v67;
            int32_t v72;
            v72 = v71 + 1l;
            uint8_t v73;
            v73 = v67.rank;
            v77 = v62; v78 = v72; v79 = v73;
        } else {
            break;
        }
        v63 = v77;
        v64 = v78;
        v65 = v79;
        v62++;
    }
    bool v80;
    v80 = v64 == 2l;
    US4 v90;
    if (v80){
        int32_t v81;
        v81 = 0l;
        while (while_method_7(v81)){
            int32_t v83;
            v83 = v63 + -1l;
            bool v84;
            v84 = v81 < v83;
            int32_t v85;
            if (v84){
                v85 = 0l;
            } else {
                v85 = 2l;
            }
            int32_t v86;
            v86 = v85 + v81;
            Card v87;
            v87 = v1[v86];
            v61[v81] = v87;
            v81++;
        }
        v90 = US4_1(v60, v61);
    } else {
        v90 = US4_0();
    }
    US5 v148;
    switch (v90.tag) {
        case 0: { // None
            v148 = US5_0();
            break;
        }
        default: { // Some
            std::array<Card,2l> v91 = v90.v.case1.v0; std::array<Card,5l> v92 = v90.v.case1.v1;
            std::array<Card,2l> v93;
            std::array<Card,3l> v94;
            int32_t v95; int32_t v96; int32_t v97; uint8_t v98;
            Tuple6 tmp11 = Tuple6(0l, 0l, 0l, 12u);
            v95 = tmp11.v0; v96 = tmp11.v1; v97 = tmp11.v2; v98 = tmp11.v3;
            while (while_method_7(v95)){
                Card v100;
                v100 = v92[v95];
                bool v101;
                v101 = v97 < 2l;
                int32_t v110; int32_t v111; uint8_t v112;
                if (v101){
                    uint8_t v102;
                    v102 = v100.rank;
                    bool v103;
                    v103 = v98 == v102;
                    int32_t v104;
                    if (v103){
                        v104 = v97;
                    } else {
                        v104 = 0l;
                    }
                    v93[v104] = v100;
                    int32_t v105;
                    v105 = v104 + 1l;
                    uint8_t v106;
                    v106 = v100.rank;
                    v110 = v95; v111 = v105; v112 = v106;
                } else {
                    break;
                }
                v96 = v110;
                v97 = v111;
                v98 = v112;
                v95++;
            }
            bool v113;
            v113 = v97 == 2l;
            US6 v123;
            if (v113){
                int32_t v114;
                v114 = 0l;
                while (while_method_8(v114)){
                    int32_t v116;
                    v116 = v96 + -1l;
                    bool v117;
                    v117 = v114 < v116;
                    int32_t v118;
                    if (v117){
                        v118 = 0l;
                    } else {
                        v118 = 2l;
                    }
                    int32_t v119;
                    v119 = v118 + v114;
                    Card v120;
                    v120 = v92[v119];
                    v94[v114] = v120;
                    v114++;
                }
                v123 = US6_1(v93, v94);
            } else {
                v123 = US6_0();
            }
            switch (v123.tag) {
                case 0: { // None
                    v148 = US5_0();
                    break;
                }
                default: { // Some
                    std::array<Card,2l> v124 = v123.v.case1.v0; std::array<Card,3l> v125 = v123.v.case1.v1;
                    std::array<Card,1l> v126;
                    int32_t v127;
                    v127 = 0l;
                    while (while_method_10(v127)){
                        Card v129;
                        v129 = v125[v127];
                        v126[v127] = v129;
                        v127++;
                    }
                    std::array<Card,5l> v130;
                    int32_t v131;
                    v131 = 0l;
                    while (while_method_9(v131)){
                        Card v133;
                        v133 = v91[v131];
                        v130[v131] = v133;
                        v131++;
                    }
                    int32_t v134;
                    v134 = 0l;
                    while (while_method_9(v134)){
                        Card v136;
                        v136 = v124[v134];
                        int32_t v137;
                        v137 = 2l + v134;
                        v130[v137] = v136;
                        v134++;
                    }
                    int32_t v138;
                    v138 = 0l;
                    while (while_method_10(v138)){
                        Card v140;
                        v140 = v126[v138];
                        int32_t v141;
                        v141 = 4l + v138;
                        v130[v141] = v140;
                        v138++;
                    }
                    v148 = US5_1(v130);
                }
            }
        }
    }
    std::array<Card,3l> v149;
    std::array<Card,4l> v150;
    int32_t v151; int32_t v152; int32_t v153; uint8_t v154;
    Tuple6 tmp12 = Tuple6(0l, 0l, 0l, 12u);
    v151 = tmp12.v0; v152 = tmp12.v1; v153 = tmp12.v2; v154 = tmp12.v3;
    while (while_method_6(v151)){
        Card v156;
        v156 = v1[v151];
        bool v157;
        v157 = v153 < 3l;
        int32_t v166; int32_t v167; uint8_t v168;
        if (v157){
            uint8_t v158;
            v158 = v156.rank;
            bool v159;
            v159 = v154 == v158;
            int32_t v160;
            if (v159){
                v160 = v153;
            } else {
                v160 = 0l;
            }
            v149[v160] = v156;
            int32_t v161;
            v161 = v160 + 1l;
            uint8_t v162;
            v162 = v156.rank;
            v166 = v151; v167 = v161; v168 = v162;
        } else {
            break;
        }
        v152 = v166;
        v153 = v167;
        v154 = v168;
        v151++;
    }
    bool v169;
    v169 = v153 == 3l;
    US7 v179;
    if (v169){
        int32_t v170;
        v170 = 0l;
        while (while_method_11(v170)){
            int32_t v172;
            v172 = v152 + -2l;
            bool v173;
            v173 = v170 < v172;
            int32_t v174;
            if (v173){
                v174 = 0l;
            } else {
                v174 = 3l;
            }
            int32_t v175;
            v175 = v174 + v170;
            Card v176;
            v176 = v1[v175];
            v150[v170] = v176;
            v170++;
        }
        v179 = US7_1(v149, v150);
    } else {
        v179 = US7_0();
    }
    US5 v198;
    switch (v179.tag) {
        case 0: { // None
            v198 = US5_0();
            break;
        }
        default: { // Some
            std::array<Card,3l> v180 = v179.v.case1.v0; std::array<Card,4l> v181 = v179.v.case1.v1;
            std::array<Card,2l> v182;
            int32_t v183;
            v183 = 0l;
            while (while_method_9(v183)){
                Card v185;
                v185 = v181[v183];
                v182[v183] = v185;
                v183++;
            }
            std::array<Card,0l> v186;
            std::array<Card,5l> v187;
            int32_t v188;
            v188 = 0l;
            while (while_method_8(v188)){
                Card v190;
                v190 = v180[v188];
                v187[v188] = v190;
                v188++;
            }
            int32_t v191;
            v191 = 0l;
            while (while_method_9(v191)){
                Card v193;
                v193 = v182[v191];
                int32_t v194;
                v194 = 3l + v191;
                v187[v194] = v193;
                v191++;
            }
            v198 = US5_1(v187);
        }
    }
    std::array<Card,5l> v199;
    int32_t v200; int32_t v201; uint8_t v202;
    Tuple7 tmp13 = Tuple7(0l, 0l, 12u);
    v200 = tmp13.v0; v201 = tmp13.v1; v202 = tmp13.v2;
    while (while_method_6(v200)){
        Card v204;
        v204 = v1[v200];
        bool v205;
        v205 = v201 < 5l;
        int32_t v220; uint8_t v221;
        if (v205){
            uint8_t v206;
            v206 = v204.rank;
            uint8_t v207;
            v207 = v206 - 1u;
            bool v208;
            v208 = v202 == v207;
            bool v209;
            v209 = v208 != true;
            if (v209){
                uint8_t v210;
                v210 = v204.rank;
                bool v211;
                v211 = v202 == v210;
                int32_t v212;
                if (v211){
                    v212 = v201;
                } else {
                    v212 = 0l;
                }
                v199[v212] = v204;
                int32_t v213;
                v213 = v212 + 1l;
                uint8_t v214;
                v214 = v204.rank;
                uint8_t v215;
                v215 = v214 - 1u;
                v220 = v213; v221 = v215;
            } else {
                v220 = v201; v221 = v202;
            }
        } else {
            break;
        }
        v201 = v220;
        v202 = v221;
        v200++;
    }
    bool v222;
    v222 = v201 == 4l;
    bool v230;
    if (v222){
        uint8_t v223;
        v223 = v202 + 1u;
        bool v224;
        v224 = v223 == 0u;
        if (v224){
            Card v225;
            v225 = v1[0l];
            uint8_t v226;
            v226 = v225.rank;
            bool v227;
            v227 = v226 == 12u;
            if (v227){
                v199[4l] = v225;
                v230 = true;
            } else {
                v230 = false;
            }
        } else {
            v230 = false;
        }
    } else {
        v230 = false;
    }
    US5 v236;
    if (v230){
        v236 = US5_1(v199);
    } else {
        bool v232;
        v232 = v201 == 5l;
        if (v232){
            v236 = US5_1(v199);
        } else {
            v236 = US5_0();
        }
    }
    std::array<Card,5l> v237;
    int32_t v238; int32_t v239;
    Tuple8 tmp14 = Tuple8(0l, 0l);
    v238 = tmp14.v0; v239 = tmp14.v1;
    while (while_method_6(v238)){
        Card v241;
        v241 = v1[v238];
        uint8_t v242;
        v242 = v241.suit;
        bool v243;
        v243 = v242 == 3u;
        bool v245;
        if (v243){
            bool v244;
            v244 = v239 < 5l;
            v245 = v244;
        } else {
            v245 = false;
        }
        int32_t v247;
        if (v245){
            v237[v239] = v241;
            int32_t v246;
            v246 = v239 + 1l;
            v247 = v246;
        } else {
            v247 = v239;
        }
        v239 = v247;
        v238++;
    }
    bool v248;
    v248 = v239 == 5l;
    US5 v251;
    if (v248){
        v251 = US5_1(v237);
    } else {
        v251 = US5_0();
    }
    std::array<Card,5l> v252;
    int32_t v253; int32_t v254;
    Tuple8 tmp15 = Tuple8(0l, 0l);
    v253 = tmp15.v0; v254 = tmp15.v1;
    while (while_method_6(v253)){
        Card v256;
        v256 = v1[v253];
        uint8_t v257;
        v257 = v256.suit;
        bool v258;
        v258 = v257 == 2u;
        bool v260;
        if (v258){
            bool v259;
            v259 = v254 < 5l;
            v260 = v259;
        } else {
            v260 = false;
        }
        int32_t v262;
        if (v260){
            v252[v254] = v256;
            int32_t v261;
            v261 = v254 + 1l;
            v262 = v261;
        } else {
            v262 = v254;
        }
        v254 = v262;
        v253++;
    }
    bool v263;
    v263 = v254 == 5l;
    US5 v266;
    if (v263){
        v266 = US5_1(v252);
    } else {
        v266 = US5_0();
    }
    std::array<Card,5l> v267;
    int32_t v268; int32_t v269;
    Tuple8 tmp16 = Tuple8(0l, 0l);
    v268 = tmp16.v0; v269 = tmp16.v1;
    while (while_method_6(v268)){
        Card v271;
        v271 = v1[v268];
        uint8_t v272;
        v272 = v271.suit;
        bool v273;
        v273 = v272 == 1u;
        bool v275;
        if (v273){
            bool v274;
            v274 = v269 < 5l;
            v275 = v274;
        } else {
            v275 = false;
        }
        int32_t v277;
        if (v275){
            v267[v269] = v271;
            int32_t v276;
            v276 = v269 + 1l;
            v277 = v276;
        } else {
            v277 = v269;
        }
        v269 = v277;
        v268++;
    }
    bool v278;
    v278 = v269 == 5l;
    US5 v281;
    if (v278){
        v281 = US5_1(v267);
    } else {
        v281 = US5_0();
    }
    std::array<Card,5l> v282;
    int32_t v283; int32_t v284;
    Tuple8 tmp17 = Tuple8(0l, 0l);
    v283 = tmp17.v0; v284 = tmp17.v1;
    while (while_method_6(v283)){
        Card v286;
        v286 = v1[v283];
        uint8_t v287;
        v287 = v286.suit;
        bool v288;
        v288 = v287 == 0u;
        bool v290;
        if (v288){
            bool v289;
            v289 = v284 < 5l;
            v290 = v289;
        } else {
            v290 = false;
        }
        int32_t v292;
        if (v290){
            v282[v284] = v286;
            int32_t v291;
            v291 = v284 + 1l;
            v292 = v291;
        } else {
            v292 = v284;
        }
        v284 = v292;
        v283++;
    }
    bool v293;
    v293 = v284 == 5l;
    US5 v296;
    if (v293){
        v296 = US5_1(v282);
    } else {
        v296 = US5_0();
    }
    US5 v322;
    switch (v296.tag) {
        case 0: { // None
            v322 = v281;
            break;
        }
        default: { // Some
            std::array<Card,5l> v297 = v296.v.case1.v0;
            switch (v281.tag) {
                case 0: { // None
                    v322 = v296;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v298 = v281.v.case1.v0;
                    US8 v299;
                    v299 = US8_0();
                    int32_t v300; US8 v301;
                    Tuple9 tmp18 = Tuple9(0l, v299);
                    v300 = tmp18.v0; v301 = tmp18.v1;
                    while (while_method_7(v300)){
                        Card v303;
                        v303 = v297[v300];
                        Card v304;
                        v304 = v298[v300];
                        US8 v315;
                        switch (v301.tag) {
                            case 0: { // Eq
                                uint8_t v305;
                                v305 = v303.rank;
                                uint8_t v306;
                                v306 = v304.rank;
                                bool v307;
                                v307 = v305 < v306;
                                if (v307){
                                    v315 = US8_2();
                                } else {
                                    bool v309;
                                    v309 = v305 > v306;
                                    if (v309){
                                        v315 = US8_1();
                                    } else {
                                        v315 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v301 = v315;
                        v300++;
                    }
                    bool v316;
                    switch (v301.tag) {
                        case 1: { // Gt
                            v316 = true;
                            break;
                        }
                        default: {
                            v316 = false;
                        }
                    }
                    std::array<Card,5l> v317;
                    if (v316){
                        v317 = v297;
                    } else {
                        v317 = v298;
                    }
                    v322 = US5_1(v317);
                }
            }
        }
    }
    US5 v348;
    switch (v322.tag) {
        case 0: { // None
            v348 = v266;
            break;
        }
        default: { // Some
            std::array<Card,5l> v323 = v322.v.case1.v0;
            switch (v266.tag) {
                case 0: { // None
                    v348 = v322;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v324 = v266.v.case1.v0;
                    US8 v325;
                    v325 = US8_0();
                    int32_t v326; US8 v327;
                    Tuple9 tmp19 = Tuple9(0l, v325);
                    v326 = tmp19.v0; v327 = tmp19.v1;
                    while (while_method_7(v326)){
                        Card v329;
                        v329 = v323[v326];
                        Card v330;
                        v330 = v324[v326];
                        US8 v341;
                        switch (v327.tag) {
                            case 0: { // Eq
                                uint8_t v331;
                                v331 = v329.rank;
                                uint8_t v332;
                                v332 = v330.rank;
                                bool v333;
                                v333 = v331 < v332;
                                if (v333){
                                    v341 = US8_2();
                                } else {
                                    bool v335;
                                    v335 = v331 > v332;
                                    if (v335){
                                        v341 = US8_1();
                                    } else {
                                        v341 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v327 = v341;
                        v326++;
                    }
                    bool v342;
                    switch (v327.tag) {
                        case 1: { // Gt
                            v342 = true;
                            break;
                        }
                        default: {
                            v342 = false;
                        }
                    }
                    std::array<Card,5l> v343;
                    if (v342){
                        v343 = v323;
                    } else {
                        v343 = v324;
                    }
                    v348 = US5_1(v343);
                }
            }
        }
    }
    US5 v374;
    switch (v348.tag) {
        case 0: { // None
            v374 = v251;
            break;
        }
        default: { // Some
            std::array<Card,5l> v349 = v348.v.case1.v0;
            switch (v251.tag) {
                case 0: { // None
                    v374 = v348;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v350 = v251.v.case1.v0;
                    US8 v351;
                    v351 = US8_0();
                    int32_t v352; US8 v353;
                    Tuple9 tmp20 = Tuple9(0l, v351);
                    v352 = tmp20.v0; v353 = tmp20.v1;
                    while (while_method_7(v352)){
                        Card v355;
                        v355 = v349[v352];
                        Card v356;
                        v356 = v350[v352];
                        US8 v367;
                        switch (v353.tag) {
                            case 0: { // Eq
                                uint8_t v357;
                                v357 = v355.rank;
                                uint8_t v358;
                                v358 = v356.rank;
                                bool v359;
                                v359 = v357 < v358;
                                if (v359){
                                    v367 = US8_2();
                                } else {
                                    bool v361;
                                    v361 = v357 > v358;
                                    if (v361){
                                        v367 = US8_1();
                                    } else {
                                        v367 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v353 = v367;
                        v352++;
                    }
                    bool v368;
                    switch (v353.tag) {
                        case 1: { // Gt
                            v368 = true;
                            break;
                        }
                        default: {
                            v368 = false;
                        }
                    }
                    std::array<Card,5l> v369;
                    if (v368){
                        v369 = v349;
                    } else {
                        v369 = v350;
                    }
                    v374 = US5_1(v369);
                }
            }
        }
    }
    std::array<Card,3l> v375;
    std::array<Card,4l> v376;
    int32_t v377; int32_t v378; int32_t v379; uint8_t v380;
    Tuple6 tmp21 = Tuple6(0l, 0l, 0l, 12u);
    v377 = tmp21.v0; v378 = tmp21.v1; v379 = tmp21.v2; v380 = tmp21.v3;
    while (while_method_6(v377)){
        Card v382;
        v382 = v1[v377];
        bool v383;
        v383 = v379 < 3l;
        int32_t v392; int32_t v393; uint8_t v394;
        if (v383){
            uint8_t v384;
            v384 = v382.rank;
            bool v385;
            v385 = v380 == v384;
            int32_t v386;
            if (v385){
                v386 = v379;
            } else {
                v386 = 0l;
            }
            v375[v386] = v382;
            int32_t v387;
            v387 = v386 + 1l;
            uint8_t v388;
            v388 = v382.rank;
            v392 = v377; v393 = v387; v394 = v388;
        } else {
            break;
        }
        v378 = v392;
        v379 = v393;
        v380 = v394;
        v377++;
    }
    bool v395;
    v395 = v379 == 3l;
    US7 v405;
    if (v395){
        int32_t v396;
        v396 = 0l;
        while (while_method_11(v396)){
            int32_t v398;
            v398 = v378 + -2l;
            bool v399;
            v399 = v396 < v398;
            int32_t v400;
            if (v399){
                v400 = 0l;
            } else {
                v400 = 3l;
            }
            int32_t v401;
            v401 = v400 + v396;
            Card v402;
            v402 = v1[v401];
            v376[v396] = v402;
            v396++;
        }
        v405 = US7_1(v375, v376);
    } else {
        v405 = US7_0();
    }
    US5 v456;
    switch (v405.tag) {
        case 0: { // None
            v456 = US5_0();
            break;
        }
        default: { // Some
            std::array<Card,3l> v406 = v405.v.case1.v0; std::array<Card,4l> v407 = v405.v.case1.v1;
            std::array<Card,2l> v408;
            std::array<Card,2l> v409;
            int32_t v410; int32_t v411; int32_t v412; uint8_t v413;
            Tuple6 tmp22 = Tuple6(0l, 0l, 0l, 12u);
            v410 = tmp22.v0; v411 = tmp22.v1; v412 = tmp22.v2; v413 = tmp22.v3;
            while (while_method_11(v410)){
                Card v415;
                v415 = v407[v410];
                bool v416;
                v416 = v412 < 2l;
                int32_t v425; int32_t v426; uint8_t v427;
                if (v416){
                    uint8_t v417;
                    v417 = v415.rank;
                    bool v418;
                    v418 = v413 == v417;
                    int32_t v419;
                    if (v418){
                        v419 = v412;
                    } else {
                        v419 = 0l;
                    }
                    v408[v419] = v415;
                    int32_t v420;
                    v420 = v419 + 1l;
                    uint8_t v421;
                    v421 = v415.rank;
                    v425 = v410; v426 = v420; v427 = v421;
                } else {
                    break;
                }
                v411 = v425;
                v412 = v426;
                v413 = v427;
                v410++;
            }
            bool v428;
            v428 = v412 == 2l;
            US9 v438;
            if (v428){
                int32_t v429;
                v429 = 0l;
                while (while_method_9(v429)){
                    int32_t v431;
                    v431 = v411 + -1l;
                    bool v432;
                    v432 = v429 < v431;
                    int32_t v433;
                    if (v432){
                        v433 = 0l;
                    } else {
                        v433 = 2l;
                    }
                    int32_t v434;
                    v434 = v433 + v429;
                    Card v435;
                    v435 = v407[v434];
                    v409[v429] = v435;
                    v429++;
                }
                v438 = US9_1(v408, v409);
            } else {
                v438 = US9_0();
            }
            switch (v438.tag) {
                case 0: { // None
                    v456 = US5_0();
                    break;
                }
                default: { // Some
                    std::array<Card,2l> v439 = v438.v.case1.v0; std::array<Card,2l> v440 = v438.v.case1.v1;
                    std::array<Card,0l> v441;
                    std::array<Card,5l> v442;
                    int32_t v443;
                    v443 = 0l;
                    while (while_method_8(v443)){
                        Card v445;
                        v445 = v406[v443];
                        v442[v443] = v445;
                        v443++;
                    }
                    int32_t v446;
                    v446 = 0l;
                    while (while_method_9(v446)){
                        Card v448;
                        v448 = v439[v446];
                        int32_t v449;
                        v449 = 3l + v446;
                        v442[v449] = v448;
                        v446++;
                    }
                    v456 = US5_1(v442);
                }
            }
        }
    }
    std::array<Card,4l> v457;
    std::array<Card,3l> v458;
    int32_t v459; int32_t v460; int32_t v461; uint8_t v462;
    Tuple6 tmp23 = Tuple6(0l, 0l, 0l, 12u);
    v459 = tmp23.v0; v460 = tmp23.v1; v461 = tmp23.v2; v462 = tmp23.v3;
    while (while_method_6(v459)){
        Card v464;
        v464 = v1[v459];
        bool v465;
        v465 = v461 < 4l;
        int32_t v474; int32_t v475; uint8_t v476;
        if (v465){
            uint8_t v466;
            v466 = v464.rank;
            bool v467;
            v467 = v462 == v466;
            int32_t v468;
            if (v467){
                v468 = v461;
            } else {
                v468 = 0l;
            }
            v457[v468] = v464;
            int32_t v469;
            v469 = v468 + 1l;
            uint8_t v470;
            v470 = v464.rank;
            v474 = v459; v475 = v469; v476 = v470;
        } else {
            break;
        }
        v460 = v474;
        v461 = v475;
        v462 = v476;
        v459++;
    }
    bool v477;
    v477 = v461 == 4l;
    US10 v487;
    if (v477){
        int32_t v478;
        v478 = 0l;
        while (while_method_8(v478)){
            int32_t v480;
            v480 = v460 + -3l;
            bool v481;
            v481 = v478 < v480;
            int32_t v482;
            if (v481){
                v482 = 0l;
            } else {
                v482 = 4l;
            }
            int32_t v483;
            v483 = v482 + v478;
            Card v484;
            v484 = v1[v483];
            v458[v478] = v484;
            v478++;
        }
        v487 = US10_1(v457, v458);
    } else {
        v487 = US10_0();
    }
    US5 v506;
    switch (v487.tag) {
        case 0: { // None
            v506 = US5_0();
            break;
        }
        default: { // Some
            std::array<Card,4l> v488 = v487.v.case1.v0; std::array<Card,3l> v489 = v487.v.case1.v1;
            std::array<Card,1l> v490;
            int32_t v491;
            v491 = 0l;
            while (while_method_10(v491)){
                Card v493;
                v493 = v489[v491];
                v490[v491] = v493;
                v491++;
            }
            std::array<Card,0l> v494;
            std::array<Card,5l> v495;
            int32_t v496;
            v496 = 0l;
            while (while_method_11(v496)){
                Card v498;
                v498 = v488[v496];
                v495[v496] = v498;
                v496++;
            }
            int32_t v499;
            v499 = 0l;
            while (while_method_10(v499)){
                Card v501;
                v501 = v490[v499];
                int32_t v502;
                v502 = 4l + v499;
                v495[v502] = v501;
                v499++;
            }
            v506 = US5_1(v495);
        }
    }
    std::array<Card,5l> v507;
    int32_t v508; int32_t v509; uint8_t v510;
    Tuple7 tmp24 = Tuple7(0l, 0l, 12u);
    v508 = tmp24.v0; v509 = tmp24.v1; v510 = tmp24.v2;
    while (while_method_6(v508)){
        Card v512;
        v512 = v1[v508];
        bool v513;
        v513 = v509 < 5l;
        int32_t v526; uint8_t v527;
        if (v513){
            uint8_t v514;
            v514 = v512.suit;
            bool v515;
            v515 = 3u == v514;
            if (v515){
                uint8_t v516;
                v516 = v512.rank;
                bool v517;
                v517 = v510 == v516;
                int32_t v518;
                if (v517){
                    v518 = v509;
                } else {
                    v518 = 0l;
                }
                v507[v518] = v512;
                int32_t v519;
                v519 = v518 + 1l;
                uint8_t v520;
                v520 = v512.rank;
                uint8_t v521;
                v521 = v520 - 1u;
                v526 = v519; v527 = v521;
            } else {
                v526 = v509; v527 = v510;
            }
        } else {
            break;
        }
        v509 = v526;
        v510 = v527;
        v508++;
    }
    bool v528;
    v528 = v509 == 4l;
    bool v563;
    if (v528){
        uint8_t v529;
        v529 = v510 + 1u;
        bool v530;
        v530 = v529 == 0u;
        if (v530){
            Card v531;
            v531 = v1[0l];
            uint8_t v532;
            v532 = v531.suit;
            bool v533;
            v533 = 3u == v532;
            bool v537;
            if (v533){
                uint8_t v534;
                v534 = v531.rank;
                bool v535;
                v535 = v534 == 12u;
                if (v535){
                    v507[4l] = v531;
                    v537 = true;
                } else {
                    v537 = false;
                }
            } else {
                v537 = false;
            }
            if (v537){
                v563 = true;
            } else {
                Card v538;
                v538 = v1[1l];
                uint8_t v539;
                v539 = v538.suit;
                bool v540;
                v540 = 3u == v539;
                bool v544;
                if (v540){
                    uint8_t v541;
                    v541 = v538.rank;
                    bool v542;
                    v542 = v541 == 12u;
                    if (v542){
                        v507[4l] = v538;
                        v544 = true;
                    } else {
                        v544 = false;
                    }
                } else {
                    v544 = false;
                }
                if (v544){
                    v563 = true;
                } else {
                    Card v545;
                    v545 = v1[2l];
                    uint8_t v546;
                    v546 = v545.suit;
                    bool v547;
                    v547 = 3u == v546;
                    bool v551;
                    if (v547){
                        uint8_t v548;
                        v548 = v545.rank;
                        bool v549;
                        v549 = v548 == 12u;
                        if (v549){
                            v507[4l] = v545;
                            v551 = true;
                        } else {
                            v551 = false;
                        }
                    } else {
                        v551 = false;
                    }
                    if (v551){
                        v563 = true;
                    } else {
                        Card v552;
                        v552 = v1[3l];
                        uint8_t v553;
                        v553 = v552.suit;
                        bool v554;
                        v554 = 3u == v553;
                        if (v554){
                            uint8_t v555;
                            v555 = v552.rank;
                            bool v556;
                            v556 = v555 == 12u;
                            if (v556){
                                v507[4l] = v552;
                                v563 = true;
                            } else {
                                v563 = false;
                            }
                        } else {
                            v563 = false;
                        }
                    }
                }
            }
        } else {
            v563 = false;
        }
    } else {
        v563 = false;
    }
    US5 v569;
    if (v563){
        v569 = US5_1(v507);
    } else {
        bool v565;
        v565 = v509 == 5l;
        if (v565){
            v569 = US5_1(v507);
        } else {
            v569 = US5_0();
        }
    }
    std::array<Card,5l> v570;
    int32_t v571; int32_t v572; uint8_t v573;
    Tuple7 tmp25 = Tuple7(0l, 0l, 12u);
    v571 = tmp25.v0; v572 = tmp25.v1; v573 = tmp25.v2;
    while (while_method_6(v571)){
        Card v575;
        v575 = v1[v571];
        bool v576;
        v576 = v572 < 5l;
        int32_t v589; uint8_t v590;
        if (v576){
            uint8_t v577;
            v577 = v575.suit;
            bool v578;
            v578 = 2u == v577;
            if (v578){
                uint8_t v579;
                v579 = v575.rank;
                bool v580;
                v580 = v573 == v579;
                int32_t v581;
                if (v580){
                    v581 = v572;
                } else {
                    v581 = 0l;
                }
                v570[v581] = v575;
                int32_t v582;
                v582 = v581 + 1l;
                uint8_t v583;
                v583 = v575.rank;
                uint8_t v584;
                v584 = v583 - 1u;
                v589 = v582; v590 = v584;
            } else {
                v589 = v572; v590 = v573;
            }
        } else {
            break;
        }
        v572 = v589;
        v573 = v590;
        v571++;
    }
    bool v591;
    v591 = v572 == 4l;
    bool v626;
    if (v591){
        uint8_t v592;
        v592 = v573 + 1u;
        bool v593;
        v593 = v592 == 0u;
        if (v593){
            Card v594;
            v594 = v1[0l];
            uint8_t v595;
            v595 = v594.suit;
            bool v596;
            v596 = 2u == v595;
            bool v600;
            if (v596){
                uint8_t v597;
                v597 = v594.rank;
                bool v598;
                v598 = v597 == 12u;
                if (v598){
                    v570[4l] = v594;
                    v600 = true;
                } else {
                    v600 = false;
                }
            } else {
                v600 = false;
            }
            if (v600){
                v626 = true;
            } else {
                Card v601;
                v601 = v1[1l];
                uint8_t v602;
                v602 = v601.suit;
                bool v603;
                v603 = 2u == v602;
                bool v607;
                if (v603){
                    uint8_t v604;
                    v604 = v601.rank;
                    bool v605;
                    v605 = v604 == 12u;
                    if (v605){
                        v570[4l] = v601;
                        v607 = true;
                    } else {
                        v607 = false;
                    }
                } else {
                    v607 = false;
                }
                if (v607){
                    v626 = true;
                } else {
                    Card v608;
                    v608 = v1[2l];
                    uint8_t v609;
                    v609 = v608.suit;
                    bool v610;
                    v610 = 2u == v609;
                    bool v614;
                    if (v610){
                        uint8_t v611;
                        v611 = v608.rank;
                        bool v612;
                        v612 = v611 == 12u;
                        if (v612){
                            v570[4l] = v608;
                            v614 = true;
                        } else {
                            v614 = false;
                        }
                    } else {
                        v614 = false;
                    }
                    if (v614){
                        v626 = true;
                    } else {
                        Card v615;
                        v615 = v1[3l];
                        uint8_t v616;
                        v616 = v615.suit;
                        bool v617;
                        v617 = 2u == v616;
                        if (v617){
                            uint8_t v618;
                            v618 = v615.rank;
                            bool v619;
                            v619 = v618 == 12u;
                            if (v619){
                                v570[4l] = v615;
                                v626 = true;
                            } else {
                                v626 = false;
                            }
                        } else {
                            v626 = false;
                        }
                    }
                }
            }
        } else {
            v626 = false;
        }
    } else {
        v626 = false;
    }
    US5 v632;
    if (v626){
        v632 = US5_1(v570);
    } else {
        bool v628;
        v628 = v572 == 5l;
        if (v628){
            v632 = US5_1(v570);
        } else {
            v632 = US5_0();
        }
    }
    std::array<Card,5l> v633;
    int32_t v634; int32_t v635; uint8_t v636;
    Tuple7 tmp26 = Tuple7(0l, 0l, 12u);
    v634 = tmp26.v0; v635 = tmp26.v1; v636 = tmp26.v2;
    while (while_method_6(v634)){
        Card v638;
        v638 = v1[v634];
        bool v639;
        v639 = v635 < 5l;
        int32_t v652; uint8_t v653;
        if (v639){
            uint8_t v640;
            v640 = v638.suit;
            bool v641;
            v641 = 1u == v640;
            if (v641){
                uint8_t v642;
                v642 = v638.rank;
                bool v643;
                v643 = v636 == v642;
                int32_t v644;
                if (v643){
                    v644 = v635;
                } else {
                    v644 = 0l;
                }
                v633[v644] = v638;
                int32_t v645;
                v645 = v644 + 1l;
                uint8_t v646;
                v646 = v638.rank;
                uint8_t v647;
                v647 = v646 - 1u;
                v652 = v645; v653 = v647;
            } else {
                v652 = v635; v653 = v636;
            }
        } else {
            break;
        }
        v635 = v652;
        v636 = v653;
        v634++;
    }
    bool v654;
    v654 = v635 == 4l;
    bool v689;
    if (v654){
        uint8_t v655;
        v655 = v636 + 1u;
        bool v656;
        v656 = v655 == 0u;
        if (v656){
            Card v657;
            v657 = v1[0l];
            uint8_t v658;
            v658 = v657.suit;
            bool v659;
            v659 = 1u == v658;
            bool v663;
            if (v659){
                uint8_t v660;
                v660 = v657.rank;
                bool v661;
                v661 = v660 == 12u;
                if (v661){
                    v633[4l] = v657;
                    v663 = true;
                } else {
                    v663 = false;
                }
            } else {
                v663 = false;
            }
            if (v663){
                v689 = true;
            } else {
                Card v664;
                v664 = v1[1l];
                uint8_t v665;
                v665 = v664.suit;
                bool v666;
                v666 = 1u == v665;
                bool v670;
                if (v666){
                    uint8_t v667;
                    v667 = v664.rank;
                    bool v668;
                    v668 = v667 == 12u;
                    if (v668){
                        v633[4l] = v664;
                        v670 = true;
                    } else {
                        v670 = false;
                    }
                } else {
                    v670 = false;
                }
                if (v670){
                    v689 = true;
                } else {
                    Card v671;
                    v671 = v1[2l];
                    uint8_t v672;
                    v672 = v671.suit;
                    bool v673;
                    v673 = 1u == v672;
                    bool v677;
                    if (v673){
                        uint8_t v674;
                        v674 = v671.rank;
                        bool v675;
                        v675 = v674 == 12u;
                        if (v675){
                            v633[4l] = v671;
                            v677 = true;
                        } else {
                            v677 = false;
                        }
                    } else {
                        v677 = false;
                    }
                    if (v677){
                        v689 = true;
                    } else {
                        Card v678;
                        v678 = v1[3l];
                        uint8_t v679;
                        v679 = v678.suit;
                        bool v680;
                        v680 = 1u == v679;
                        if (v680){
                            uint8_t v681;
                            v681 = v678.rank;
                            bool v682;
                            v682 = v681 == 12u;
                            if (v682){
                                v633[4l] = v678;
                                v689 = true;
                            } else {
                                v689 = false;
                            }
                        } else {
                            v689 = false;
                        }
                    }
                }
            }
        } else {
            v689 = false;
        }
    } else {
        v689 = false;
    }
    US5 v695;
    if (v689){
        v695 = US5_1(v633);
    } else {
        bool v691;
        v691 = v635 == 5l;
        if (v691){
            v695 = US5_1(v633);
        } else {
            v695 = US5_0();
        }
    }
    std::array<Card,5l> v696;
    int32_t v697; int32_t v698; uint8_t v699;
    Tuple7 tmp27 = Tuple7(0l, 0l, 12u);
    v697 = tmp27.v0; v698 = tmp27.v1; v699 = tmp27.v2;
    while (while_method_6(v697)){
        Card v701;
        v701 = v1[v697];
        bool v702;
        v702 = v698 < 5l;
        int32_t v715; uint8_t v716;
        if (v702){
            uint8_t v703;
            v703 = v701.suit;
            bool v704;
            v704 = 0u == v703;
            if (v704){
                uint8_t v705;
                v705 = v701.rank;
                bool v706;
                v706 = v699 == v705;
                int32_t v707;
                if (v706){
                    v707 = v698;
                } else {
                    v707 = 0l;
                }
                v696[v707] = v701;
                int32_t v708;
                v708 = v707 + 1l;
                uint8_t v709;
                v709 = v701.rank;
                uint8_t v710;
                v710 = v709 - 1u;
                v715 = v708; v716 = v710;
            } else {
                v715 = v698; v716 = v699;
            }
        } else {
            break;
        }
        v698 = v715;
        v699 = v716;
        v697++;
    }
    bool v717;
    v717 = v698 == 4l;
    bool v752;
    if (v717){
        uint8_t v718;
        v718 = v699 + 1u;
        bool v719;
        v719 = v718 == 0u;
        if (v719){
            Card v720;
            v720 = v1[0l];
            uint8_t v721;
            v721 = v720.suit;
            bool v722;
            v722 = 0u == v721;
            bool v726;
            if (v722){
                uint8_t v723;
                v723 = v720.rank;
                bool v724;
                v724 = v723 == 12u;
                if (v724){
                    v696[4l] = v720;
                    v726 = true;
                } else {
                    v726 = false;
                }
            } else {
                v726 = false;
            }
            if (v726){
                v752 = true;
            } else {
                Card v727;
                v727 = v1[1l];
                uint8_t v728;
                v728 = v727.suit;
                bool v729;
                v729 = 0u == v728;
                bool v733;
                if (v729){
                    uint8_t v730;
                    v730 = v727.rank;
                    bool v731;
                    v731 = v730 == 12u;
                    if (v731){
                        v696[4l] = v727;
                        v733 = true;
                    } else {
                        v733 = false;
                    }
                } else {
                    v733 = false;
                }
                if (v733){
                    v752 = true;
                } else {
                    Card v734;
                    v734 = v1[2l];
                    uint8_t v735;
                    v735 = v734.suit;
                    bool v736;
                    v736 = 0u == v735;
                    bool v740;
                    if (v736){
                        uint8_t v737;
                        v737 = v734.rank;
                        bool v738;
                        v738 = v737 == 12u;
                        if (v738){
                            v696[4l] = v734;
                            v740 = true;
                        } else {
                            v740 = false;
                        }
                    } else {
                        v740 = false;
                    }
                    if (v740){
                        v752 = true;
                    } else {
                        Card v741;
                        v741 = v1[3l];
                        uint8_t v742;
                        v742 = v741.suit;
                        bool v743;
                        v743 = 0u == v742;
                        if (v743){
                            uint8_t v744;
                            v744 = v741.rank;
                            bool v745;
                            v745 = v744 == 12u;
                            if (v745){
                                v696[4l] = v741;
                                v752 = true;
                            } else {
                                v752 = false;
                            }
                        } else {
                            v752 = false;
                        }
                    }
                }
            }
        } else {
            v752 = false;
        }
    } else {
        v752 = false;
    }
    US5 v758;
    if (v752){
        v758 = US5_1(v696);
    } else {
        bool v754;
        v754 = v698 == 5l;
        if (v754){
            v758 = US5_1(v696);
        } else {
            v758 = US5_0();
        }
    }
    US5 v784;
    switch (v758.tag) {
        case 0: { // None
            v784 = v695;
            break;
        }
        default: { // Some
            std::array<Card,5l> v759 = v758.v.case1.v0;
            switch (v695.tag) {
                case 0: { // None
                    v784 = v758;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v760 = v695.v.case1.v0;
                    US8 v761;
                    v761 = US8_0();
                    int32_t v762; US8 v763;
                    Tuple9 tmp28 = Tuple9(0l, v761);
                    v762 = tmp28.v0; v763 = tmp28.v1;
                    while (while_method_7(v762)){
                        Card v765;
                        v765 = v759[v762];
                        Card v766;
                        v766 = v760[v762];
                        US8 v777;
                        switch (v763.tag) {
                            case 0: { // Eq
                                uint8_t v767;
                                v767 = v765.rank;
                                uint8_t v768;
                                v768 = v766.rank;
                                bool v769;
                                v769 = v767 < v768;
                                if (v769){
                                    v777 = US8_2();
                                } else {
                                    bool v771;
                                    v771 = v767 > v768;
                                    if (v771){
                                        v777 = US8_1();
                                    } else {
                                        v777 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v763 = v777;
                        v762++;
                    }
                    bool v778;
                    switch (v763.tag) {
                        case 1: { // Gt
                            v778 = true;
                            break;
                        }
                        default: {
                            v778 = false;
                        }
                    }
                    std::array<Card,5l> v779;
                    if (v778){
                        v779 = v759;
                    } else {
                        v779 = v760;
                    }
                    v784 = US5_1(v779);
                }
            }
        }
    }
    US5 v810;
    switch (v784.tag) {
        case 0: { // None
            v810 = v632;
            break;
        }
        default: { // Some
            std::array<Card,5l> v785 = v784.v.case1.v0;
            switch (v632.tag) {
                case 0: { // None
                    v810 = v784;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v786 = v632.v.case1.v0;
                    US8 v787;
                    v787 = US8_0();
                    int32_t v788; US8 v789;
                    Tuple9 tmp29 = Tuple9(0l, v787);
                    v788 = tmp29.v0; v789 = tmp29.v1;
                    while (while_method_7(v788)){
                        Card v791;
                        v791 = v785[v788];
                        Card v792;
                        v792 = v786[v788];
                        US8 v803;
                        switch (v789.tag) {
                            case 0: { // Eq
                                uint8_t v793;
                                v793 = v791.rank;
                                uint8_t v794;
                                v794 = v792.rank;
                                bool v795;
                                v795 = v793 < v794;
                                if (v795){
                                    v803 = US8_2();
                                } else {
                                    bool v797;
                                    v797 = v793 > v794;
                                    if (v797){
                                        v803 = US8_1();
                                    } else {
                                        v803 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v789 = v803;
                        v788++;
                    }
                    bool v804;
                    switch (v789.tag) {
                        case 1: { // Gt
                            v804 = true;
                            break;
                        }
                        default: {
                            v804 = false;
                        }
                    }
                    std::array<Card,5l> v805;
                    if (v804){
                        v805 = v785;
                    } else {
                        v805 = v786;
                    }
                    v810 = US5_1(v805);
                }
            }
        }
    }
    US5 v836;
    switch (v810.tag) {
        case 0: { // None
            v836 = v569;
            break;
        }
        default: { // Some
            std::array<Card,5l> v811 = v810.v.case1.v0;
            switch (v569.tag) {
                case 0: { // None
                    v836 = v810;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v812 = v569.v.case1.v0;
                    US8 v813;
                    v813 = US8_0();
                    int32_t v814; US8 v815;
                    Tuple9 tmp30 = Tuple9(0l, v813);
                    v814 = tmp30.v0; v815 = tmp30.v1;
                    while (while_method_7(v814)){
                        Card v817;
                        v817 = v811[v814];
                        Card v818;
                        v818 = v812[v814];
                        US8 v829;
                        switch (v815.tag) {
                            case 0: { // Eq
                                uint8_t v819;
                                v819 = v817.rank;
                                uint8_t v820;
                                v820 = v818.rank;
                                bool v821;
                                v821 = v819 < v820;
                                if (v821){
                                    v829 = US8_2();
                                } else {
                                    bool v823;
                                    v823 = v819 > v820;
                                    if (v823){
                                        v829 = US8_1();
                                    } else {
                                        v829 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v815 = v829;
                        v814++;
                    }
                    bool v830;
                    switch (v815.tag) {
                        case 1: { // Gt
                            v830 = true;
                            break;
                        }
                        default: {
                            v830 = false;
                        }
                    }
                    std::array<Card,5l> v831;
                    if (v830){
                        v831 = v811;
                    } else {
                        v831 = v812;
                    }
                    v836 = US5_1(v831);
                }
            }
        }
    }
    US11 v841;
    switch (v59.tag) {
        case 0: { // None
            v841 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v837 = v59.v.case1.v0;
            v841 = US11_1(v837, 1);
        }
    }
    US11 v846;
    switch (v148.tag) {
        case 0: { // None
            v846 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v842 = v148.v.case1.v0;
            v846 = US11_1(v842, 2);
        }
    }
    US11 v851;
    switch (v198.tag) {
        case 0: { // None
            v851 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v847 = v198.v.case1.v0;
            v851 = US11_1(v847, 3);
        }
    }
    US11 v856;
    switch (v236.tag) {
        case 0: { // None
            v856 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v852 = v236.v.case1.v0;
            v856 = US11_1(v852, 4);
        }
    }
    US11 v861;
    switch (v374.tag) {
        case 0: { // None
            v861 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v857 = v374.v.case1.v0;
            v861 = US11_1(v857, 5);
        }
    }
    US11 v866;
    switch (v456.tag) {
        case 0: { // None
            v866 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v862 = v456.v.case1.v0;
            v866 = US11_1(v862, 6);
        }
    }
    US11 v871;
    switch (v506.tag) {
        case 0: { // None
            v871 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v867 = v506.v.case1.v0;
            v871 = US11_1(v867, 7);
        }
    }
    US11 v876;
    switch (v836.tag) {
        case 0: { // None
            v876 = US11_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v872 = v836.v.case1.v0;
            v876 = US11_1(v872, 8);
        }
    }
    US11 v878;
    switch (v876.tag) {
        case 0: { // None
            v878 = US11_0();
            break;
        }
        default: {
            v878 = v876;
        }
    }
    US11 v888;
    switch (v878.tag) {
        case 1: { // Some
            std::array<Card,5l> v879 = v878.v.case1.v0; int8_t v880 = v878.v.case1.v1;
            switch (v871.tag) {
                case 0: { // None
                    v888 = v878;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v881 = v871.v.case1.v0; int8_t v882 = v871.v.case1.v1;
                    v888 = US11_1(v879, v880);
                }
            }
            break;
        }
        default: {
            switch (v871.tag) {
                case 0: { // None
                    v888 = v878;
                    break;
                }
                default: {
                    switch (v878.tag) {
                        default: { // None
                            v888 = v871;
                        }
                    }
                }
            }
        }
    }
    US11 v898;
    switch (v888.tag) {
        case 1: { // Some
            std::array<Card,5l> v889 = v888.v.case1.v0; int8_t v890 = v888.v.case1.v1;
            switch (v866.tag) {
                case 0: { // None
                    v898 = v888;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v891 = v866.v.case1.v0; int8_t v892 = v866.v.case1.v1;
                    v898 = US11_1(v889, v890);
                }
            }
            break;
        }
        default: {
            switch (v866.tag) {
                case 0: { // None
                    v898 = v888;
                    break;
                }
                default: {
                    switch (v888.tag) {
                        default: { // None
                            v898 = v866;
                        }
                    }
                }
            }
        }
    }
    US11 v908;
    switch (v898.tag) {
        case 1: { // Some
            std::array<Card,5l> v899 = v898.v.case1.v0; int8_t v900 = v898.v.case1.v1;
            switch (v861.tag) {
                case 0: { // None
                    v908 = v898;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v901 = v861.v.case1.v0; int8_t v902 = v861.v.case1.v1;
                    v908 = US11_1(v899, v900);
                }
            }
            break;
        }
        default: {
            switch (v861.tag) {
                case 0: { // None
                    v908 = v898;
                    break;
                }
                default: {
                    switch (v898.tag) {
                        default: { // None
                            v908 = v861;
                        }
                    }
                }
            }
        }
    }
    US11 v918;
    switch (v908.tag) {
        case 1: { // Some
            std::array<Card,5l> v909 = v908.v.case1.v0; int8_t v910 = v908.v.case1.v1;
            switch (v856.tag) {
                case 0: { // None
                    v918 = v908;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v911 = v856.v.case1.v0; int8_t v912 = v856.v.case1.v1;
                    v918 = US11_1(v909, v910);
                }
            }
            break;
        }
        default: {
            switch (v856.tag) {
                case 0: { // None
                    v918 = v908;
                    break;
                }
                default: {
                    switch (v908.tag) {
                        default: { // None
                            v918 = v856;
                        }
                    }
                }
            }
        }
    }
    US11 v928;
    switch (v918.tag) {
        case 1: { // Some
            std::array<Card,5l> v919 = v918.v.case1.v0; int8_t v920 = v918.v.case1.v1;
            switch (v851.tag) {
                case 0: { // None
                    v928 = v918;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v921 = v851.v.case1.v0; int8_t v922 = v851.v.case1.v1;
                    v928 = US11_1(v919, v920);
                }
            }
            break;
        }
        default: {
            switch (v851.tag) {
                case 0: { // None
                    v928 = v918;
                    break;
                }
                default: {
                    switch (v918.tag) {
                        default: { // None
                            v928 = v851;
                        }
                    }
                }
            }
        }
    }
    US11 v938;
    switch (v928.tag) {
        case 1: { // Some
            std::array<Card,5l> v929 = v928.v.case1.v0; int8_t v930 = v928.v.case1.v1;
            switch (v846.tag) {
                case 0: { // None
                    v938 = v928;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v931 = v846.v.case1.v0; int8_t v932 = v846.v.case1.v1;
                    v938 = US11_1(v929, v930);
                }
            }
            break;
        }
        default: {
            switch (v846.tag) {
                case 0: { // None
                    v938 = v928;
                    break;
                }
                default: {
                    switch (v928.tag) {
                        default: { // None
                            v938 = v846;
                        }
                    }
                }
            }
        }
    }
    US11 v948;
    switch (v938.tag) {
        case 1: { // Some
            std::array<Card,5l> v939 = v938.v.case1.v0; int8_t v940 = v938.v.case1.v1;
            switch (v841.tag) {
                case 0: { // None
                    v948 = v938;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v941 = v841.v.case1.v0; int8_t v942 = v841.v.case1.v1;
                    v948 = US11_1(v939, v940);
                }
            }
            break;
        }
        default: {
            switch (v841.tag) {
                case 0: { // None
                    v948 = v938;
                    break;
                }
                default: {
                    switch (v938.tag) {
                        default: { // None
                            v948 = v841;
                        }
                    }
                }
            }
        }
    }
    std::array<Card,5l> v953; int8_t v954;
    switch (v948.tag) {
        case 0: { // None
            v953 = v6; v954 = 0;
            break;
        }
        default: { // Some
            std::array<Card,5l> v949 = v948.v.case1.v0; int8_t v950 = v948.v.case1.v1;
            v953 = v949; v954 = v950;
        }
    }
    return Tuple5(v953, v954);
}
Tuple5 score_8(Card v0, Card v1, Card v2, Card v3, Card v4, Card v5, Card v6){
    std::array<Card,7l> v7;
    v7[0l] = v5;
    v7[1l] = v6;
    v7[2l] = v0;
    v7[3l] = v1;
    v7[4l] = v2;
    v7[5l] = v3;
    v7[6l] = v4;
    return score_9(v7);
}
inline bool while_method_12(std::array<Card,5l> v0, US8 v1, int32_t v2){
    bool v3;
    v3 = v2 < 5l;
    return v3;
}
US8 method_10(std::array<Card,5l> v0, std::array<Card,5l> v1){
    US8 v2;
    v2 = US8_0();
    US8 v3; int32_t v4;
    Tuple10 tmp33 = Tuple10(v2, 0l);
    v3 = tmp33.v0; v4 = tmp33.v1;
    while (while_method_12(v0, v3, v4)){
        US8 v20; int32_t v21;
        switch (v3.tag) {
            case 0: { // Eq
                Card v6;
                v6 = v0[v4];
                Card v7;
                v7 = v1[v4];
                uint8_t v8;
                v8 = v6.rank;
                uint8_t v9;
                v9 = v7.rank;
                bool v10;
                v10 = v8 < v9;
                US8 v16;
                if (v10){
                    v16 = US8_2();
                } else {
                    bool v12;
                    v12 = v8 > v9;
                    if (v12){
                        v16 = US8_1();
                    } else {
                        v16 = US8_0();
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
        v4 = v21;~
    }
    return v3;
}
int16_t game_1(std::bitset<52l> & v0, std::mt19937 & v1){
    Card v2;
    v2 = draw_card_2(v0, v1);
    Card v3;
    v3 = draw_card_2(v0, v1);
    Card v4;
    v4 = draw_card_2(v0, v1);
    Card v5;
    v5 = draw_card_2(v0, v1);
    US0 v18;
    v18 = US0_1(v2, v3);
    US0 v19;
    v19 = US0_1(v4, v5);
    US1 v20;
    v20 = US1_1(2, 0);
    uint8_t v21; US0 v22; int16_t v23; US0 v24; int16_t v25; US1 v26;
    Tuple2 tmp2 = Tuple2(11u, v18, 2, v19, 1, v20);
    v21 = tmp2.v0; v22 = tmp2.v1; v23 = tmp2.v2; v24 = tmp2.v3; v25 = tmp2.v4; v26 = tmp2.v5;
    while (while_method_2(v21, v22, v23, v24, v25, v26)){
        US0 v120; int16_t v121; US0 v122; int16_t v123; US1 v124;
        switch (v26.tag) {
            case 0: { // Done
                US1 v28;
                v28 = US1_0();
                v120 = v22; v121 = v23; v122 = v24; v123 = v25; v124 = v28;
                break;
            }
            default: { // TurnOf
                int8_t v29 = v26.v.case1.v0; int8_t v30 = v26.v.case1.v1;
                bool v31;
                v31 = v30 == 0;
                US0 v32; int16_t v33; US0 v34; int16_t v35; int8_t v36;
                if (v31){
                    v32 = v22; v33 = v23; v34 = v24; v35 = v25; v36 = 1;
                } else {
                    v32 = v24; v33 = v25; v34 = v22; v35 = v23; v36 = 0;
                }
                bool v37;
                v37 = v33 >= v35;
                int16_t v38;
                if (v37){
                    v38 = v33;
                } else {
                    v38 = v35;
                }
                int16_t v39;
                v39 = v38 + v35;
                bool v40;
                v40 = v33 < v35;
                float v41;
                if (v40){
                    v41 = 1.0f;
                } else {
                    v41 = 0.0f;
                }
                int16_t v42;
                v42 = v39 / 4;
                int16_t v43;
                v43 = v39 + v42;
                int16_t v44;
                v44 = v35 + 2;
                bool v45;
                v45 = v44 <= v43;
                bool v47;
                if (v45){
                    bool v46;
                    v46 = v43 <= 100;
                    v47 = v46;
                } else {
                    v47 = false;
                }
                float v48;
                if (v47){
                    v48 = 0.25f;
                } else {
                    v48 = 0.0f;
                }
                int16_t v49;
                v49 = v39 / 3;
                int16_t v50;
                v50 = v39 + v49;
                bool v51;
                v51 = v44 <= v50;
                bool v53;
                if (v51){
                    bool v52;
                    v52 = v50 <= 100;
                    v53 = v52;
                } else {
                    v53 = false;
                }
                float v54;
                if (v53){
                    v54 = 0.25f;
                } else {
                    v54 = 0.0f;
                }
                int16_t v55;
                v55 = v39 / 2;
                int16_t v56;
                v56 = v39 + v55;
                bool v57;
                v57 = v44 <= v56;
                bool v59;
                if (v57){
                    bool v58;
                    v58 = v56 <= 100;
                    v59 = v58;
                } else {
                    v59 = false;
                }
                float v60;
                if (v59){
                    v60 = 0.25f;
                } else {
                    v60 = 0.0f;
                }
                int16_t v61;
                v61 = v39 + v39;
                bool v62;
                v62 = v44 <= v61;
                bool v64;
                if (v62){
                    bool v63;
                    v63 = v61 <= 100;
                    v64 = v63;
                } else {
                    v64 = false;
                }
                float v65;
                if (v64){
                    v65 = 0.25f;
                } else {
                    v65 = 0.0f;
                }
                int16_t v66;
                v66 = v39 * 3;
                int16_t v67;
                v67 = v66 / 2;
                int16_t v68;
                v68 = v39 + v67;
                bool v69;
                v69 = v44 <= v68;
                bool v71;
                if (v69){
                    bool v70;
                    v70 = v68 <= 100;
                    v71 = v70;
                } else {
                    v71 = false;
                }
                float v72;
                if (v71){
                    v72 = 0.25f;
                } else {
                    v72 = 0.0f;
                }
                bool v73;
                v73 = v33 < 100;
                float v74;
                if (v73){
                    v74 = 0.3f;
                } else {
                    v74 = 0.0f;
                }
                std::array<Tuple3,8l> v75;
                US2 v76;
                v76 = US2_1();
                v75[0l] = Tuple3(v76, v41);
                US2 v77;
                v77 = US2_0();
                v75[1l] = Tuple3(v77, 2.0f);
                US2 v78;
                v78 = US2_2(v43);
                v75[2l] = Tuple3(v78, v48);
                US2 v79;
                v79 = US2_2(v50);
                v75[3l] = Tuple3(v79, v54);
                US2 v80;
                v80 = US2_2(v56);
                v75[4l] = Tuple3(v80, v60);
                US2 v81;
                v81 = US2_2(v61);
                v75[5l] = Tuple3(v81, v65);
                US2 v82;
                v82 = US2_2(v68);
                v75[6l] = Tuple3(v82, v72);
                US2 v83;
                v83 = US2_2(100);
                v75[7l] = Tuple3(v83, v74);
                US2 v84;
                v84 = sample_discrete_5(v75, v1);
                US0 v108; int16_t v109; US1 v110;
                switch (v84.tag) {
                    case 0: { // Call
                        bool v87;
                        v87 = v35 >= v33;
                        int16_t v88;
                        if (v87){
                            v88 = v35;
                        } else {
                            v88 = v33;
                        }
                        bool v89;
                        v89 = 0 < v29;
                        US1 v93;
                        if (v89){
                            int8_t v90;
                            v90 = v29 - 1;
                            v93 = US1_1(v90, v36);
                        } else {
                            v93 = US1_0();
                        }
                        v108 = v32; v109 = v88; v110 = v93;
                        break;
                    }
                    case 1: { // Fold
                        US0 v85;
                        v85 = US0_0();
                        US1 v86;
                        v86 = US1_0();
                        v108 = v85; v109 = v33; v110 = v86;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v94 = v84.v.case2.v0;
                        bool v95;
                        v95 = v94 >= v33;
                        int16_t v96;
                        if (v95){
                            v96 = v94;
                        } else {
                            v96 = v33;
                        }
                        bool v97;
                        v97 = v44 >= v96;
                        int16_t v98;
                        if (v97){
                            v98 = v44;
                        } else {
                            v98 = v96;
                        }
                        bool v99;
                        v99 = 100 < v98;
                        int16_t v100;
                        if (v99){
                            v100 = 100;
                        } else {
                            v100 = v98;
                        }
                        US1 v101;
                        v101 = US1_1(0, v36);
                        v108 = v32; v109 = v100; v110 = v101;
                    }
                }
                US0 v111; int16_t v112; US0 v113; int16_t v114;
                if (v31){
                    v111 = v108; v112 = v109; v113 = v34; v114 = v35;
                } else {
                    v111 = v34; v112 = v35; v113 = v108; v114 = v109;
                }
                v120 = v111; v121 = v112; v122 = v113; v123 = v114; v124 = v110;
            }
        }
        uint8_t v125;
        v125 = v21 - 1u;
        v21 = v125;
        v22 = v120;
        v23 = v121;
        v24 = v122;
        v25 = v123;
        v26 = v124;
    }
    Card v126;
    v126 = draw_card_2(v0, v1);
    Card v127;
    v127 = draw_card_2(v0, v1);
    Card v128;
    v128 = draw_card_2(v0, v1);
    bool v138;
    v138 = v23 == 2;
    bool v143;
    if (v138){
        bool v141;
        v141 = v25 == 1;
        v143 = v141;
    } else {
        v143 = false;
    }
    int8_t v144;
    if (v143){
        v144 = 2;
    } else {
        v144 = 1;
    }
    US1 v145;
    v145 = US1_1(v144, 0);
    uint8_t v146; US0 v147; int16_t v148; US0 v149; int16_t v150; US1 v151;
    Tuple2 tmp6 = Tuple2(11u, v22, v23, v24, v25, v145);
    v146 = tmp6.v0; v147 = tmp6.v1; v148 = tmp6.v2; v149 = tmp6.v3; v150 = tmp6.v4; v151 = tmp6.v5;
    while (while_method_2(v146, v147, v148, v149, v150, v151)){
        US0 v245; int16_t v246; US0 v247; int16_t v248; US1 v249;
        switch (v151.tag) {
            case 0: { // Done
                US1 v153;
                v153 = US1_0();
                v245 = v147; v246 = v148; v247 = v149; v248 = v150; v249 = v153;
                break;
            }
            default: { // TurnOf
                int8_t v154 = v151.v.case1.v0; int8_t v155 = v151.v.case1.v1;
                bool v156;
                v156 = v155 == 0;
                US0 v157; int16_t v158; US0 v159; int16_t v160; int8_t v161;
                if (v156){
                    v157 = v147; v158 = v148; v159 = v149; v160 = v150; v161 = 1;
                } else {
                    v157 = v149; v158 = v150; v159 = v147; v160 = v148; v161 = 0;
                }
                bool v162;
                v162 = v158 >= v160;
                int16_t v163;
                if (v162){
                    v163 = v158;
                } else {
                    v163 = v160;
                }
                int16_t v164;
                v164 = v163 + v160;
                bool v165;
                v165 = v158 < v160;
                float v166;
                if (v165){
                    v166 = 1.0f;
                } else {
                    v166 = 0.0f;
                }
                int16_t v167;
                v167 = v164 / 4;
                int16_t v168;
                v168 = v164 + v167;
                int16_t v169;
                v169 = v160 + 2;
                bool v170;
                v170 = v169 <= v168;
                bool v172;
                if (v170){
                    bool v171;
                    v171 = v168 <= 100;
                    v172 = v171;
                } else {
                    v172 = false;
                }
                float v173;
                if (v172){
                    v173 = 0.25f;
                } else {
                    v173 = 0.0f;
                }
                int16_t v174;
                v174 = v164 / 3;
                int16_t v175;
                v175 = v164 + v174;
                bool v176;
                v176 = v169 <= v175;
                bool v178;
                if (v176){
                    bool v177;
                    v177 = v175 <= 100;
                    v178 = v177;
                } else {
                    v178 = false;
                }
                float v179;
                if (v178){
                    v179 = 0.25f;
                } else {
                    v179 = 0.0f;
                }
                int16_t v180;
                v180 = v164 / 2;
                int16_t v181;
                v181 = v164 + v180;
                bool v182;
                v182 = v169 <= v181;
                bool v184;
                if (v182){
                    bool v183;
                    v183 = v181 <= 100;
                    v184 = v183;
                } else {
                    v184 = false;
                }
                float v185;
                if (v184){
                    v185 = 0.25f;
                } else {
                    v185 = 0.0f;
                }
                int16_t v186;
                v186 = v164 + v164;
                bool v187;
                v187 = v169 <= v186;
                bool v189;
                if (v187){
                    bool v188;
                    v188 = v186 <= 100;
                    v189 = v188;
                } else {
                    v189 = false;
                }
                float v190;
                if (v189){
                    v190 = 0.25f;
                } else {
                    v190 = 0.0f;
                }
                int16_t v191;
                v191 = v164 * 3;
                int16_t v192;
                v192 = v191 / 2;
                int16_t v193;
                v193 = v164 + v192;
                bool v194;
                v194 = v169 <= v193;
                bool v196;
                if (v194){
                    bool v195;
                    v195 = v193 <= 100;
                    v196 = v195;
                } else {
                    v196 = false;
                }
                float v197;
                if (v196){
                    v197 = 0.25f;
                } else {
                    v197 = 0.0f;
                }
                bool v198;
                v198 = v158 < 100;
                float v199;
                if (v198){
                    v199 = 0.3f;
                } else {
                    v199 = 0.0f;
                }
                std::array<Tuple3,8l> v200;
                US2 v201;
                v201 = US2_1();
                v200[0l] = Tuple3(v201, v166);
                US2 v202;
                v202 = US2_0();
                v200[1l] = Tuple3(v202, 2.0f);
                US2 v203;
                v203 = US2_2(v168);
                v200[2l] = Tuple3(v203, v173);
                US2 v204;
                v204 = US2_2(v175);
                v200[3l] = Tuple3(v204, v179);
                US2 v205;
                v205 = US2_2(v181);
                v200[4l] = Tuple3(v205, v185);
                US2 v206;
                v206 = US2_2(v186);
                v200[5l] = Tuple3(v206, v190);
                US2 v207;
                v207 = US2_2(v193);
                v200[6l] = Tuple3(v207, v197);
                US2 v208;
                v208 = US2_2(100);
                v200[7l] = Tuple3(v208, v199);
                US2 v209;
                v209 = sample_discrete_5(v200, v1);
                US0 v233; int16_t v234; US1 v235;
                switch (v209.tag) {
                    case 0: { // Call
                        bool v212;
                        v212 = v160 >= v158;
                        int16_t v213;
                        if (v212){
                            v213 = v160;
                        } else {
                            v213 = v158;
                        }
                        bool v214;
                        v214 = 0 < v154;
                        US1 v218;
                        if (v214){
                            int8_t v215;
                            v215 = v154 - 1;
                            v218 = US1_1(v215, v161);
                        } else {
                            v218 = US1_0();
                        }
                        v233 = v157; v234 = v213; v235 = v218;
                        break;
                    }
                    case 1: { // Fold
                        US0 v210;
                        v210 = US0_0();
                        US1 v211;
                        v211 = US1_0();
                        v233 = v210; v234 = v158; v235 = v211;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v219 = v209.v.case2.v0;
                        bool v220;
                        v220 = v219 >= v158;
                        int16_t v221;
                        if (v220){
                            v221 = v219;
                        } else {
                            v221 = v158;
                        }
                        bool v222;
                        v222 = v169 >= v221;
                        int16_t v223;
                        if (v222){
                            v223 = v169;
                        } else {
                            v223 = v221;
                        }
                        bool v224;
                        v224 = 100 < v223;
                        int16_t v225;
                        if (v224){
                            v225 = 100;
                        } else {
                            v225 = v223;
                        }
                        US1 v226;
                        v226 = US1_1(0, v161);
                        v233 = v157; v234 = v225; v235 = v226;
                    }
                }
                US0 v236; int16_t v237; US0 v238; int16_t v239;
                if (v156){
                    v236 = v233; v237 = v234; v238 = v159; v239 = v160;
                } else {
                    v236 = v159; v237 = v160; v238 = v233; v239 = v234;
                }
                v245 = v236; v246 = v237; v247 = v238; v248 = v239; v249 = v235;
            }
        }
        uint8_t v250;
        v250 = v146 - 1u;
        v146 = v250;
        v147 = v245;
        v148 = v246;
        v149 = v247;
        v150 = v248;
        v151 = v249;
    }
    Card v251;
    v251 = draw_card_2(v0, v1);
    bool v261;
    v261 = v148 == 2;
    bool v266;
    if (v261){
        bool v264;
        v264 = v150 == 1;
        v266 = v264;
    } else {
        v266 = false;
    }
    int8_t v267;
    if (v266){
        v267 = 2;
    } else {
        v267 = 1;
    }
    US1 v268;
    v268 = US1_1(v267, 0);
    uint8_t v269; US0 v270; int16_t v271; US0 v272; int16_t v273; US1 v274;
    Tuple2 tmp7 = Tuple2(11u, v147, v148, v149, v150, v268);
    v269 = tmp7.v0; v270 = tmp7.v1; v271 = tmp7.v2; v272 = tmp7.v3; v273 = tmp7.v4; v274 = tmp7.v5;
    while (while_method_2(v269, v270, v271, v272, v273, v274)){
        US0 v368; int16_t v369; US0 v370; int16_t v371; US1 v372;
        switch (v274.tag) {
            case 0: { // Done
                US1 v276;
                v276 = US1_0();
                v368 = v270; v369 = v271; v370 = v272; v371 = v273; v372 = v276;
                break;
            }
            default: { // TurnOf
                int8_t v277 = v274.v.case1.v0; int8_t v278 = v274.v.case1.v1;
                bool v279;
                v279 = v278 == 0;
                US0 v280; int16_t v281; US0 v282; int16_t v283; int8_t v284;
                if (v279){
                    v280 = v270; v281 = v271; v282 = v272; v283 = v273; v284 = 1;
                } else {
                    v280 = v272; v281 = v273; v282 = v270; v283 = v271; v284 = 0;
                }
                bool v285;
                v285 = v281 >= v283;
                int16_t v286;
                if (v285){
                    v286 = v281;
                } else {
                    v286 = v283;
                }
                int16_t v287;
                v287 = v286 + v283;
                bool v288;
                v288 = v281 < v283;
                float v289;
                if (v288){
                    v289 = 1.0f;
                } else {
                    v289 = 0.0f;
                }
                int16_t v290;
                v290 = v287 / 4;
                int16_t v291;
                v291 = v287 + v290;
                int16_t v292;
                v292 = v283 + 2;
                bool v293;
                v293 = v292 <= v291;
                bool v295;
                if (v293){
                    bool v294;
                    v294 = v291 <= 100;
                    v295 = v294;
                } else {
                    v295 = false;
                }
                float v296;
                if (v295){
                    v296 = 0.25f;
                } else {
                    v296 = 0.0f;
                }
                int16_t v297;
                v297 = v287 / 3;
                int16_t v298;
                v298 = v287 + v297;
                bool v299;
                v299 = v292 <= v298;
                bool v301;
                if (v299){
                    bool v300;
                    v300 = v298 <= 100;
                    v301 = v300;
                } else {
                    v301 = false;
                }
                float v302;
                if (v301){
                    v302 = 0.25f;
                } else {
                    v302 = 0.0f;
                }
                int16_t v303;
                v303 = v287 / 2;
                int16_t v304;
                v304 = v287 + v303;
                bool v305;
                v305 = v292 <= v304;
                bool v307;
                if (v305){
                    bool v306;
                    v306 = v304 <= 100;
                    v307 = v306;
                } else {
                    v307 = false;
                }
                float v308;
                if (v307){
                    v308 = 0.25f;
                } else {
                    v308 = 0.0f;
                }
                int16_t v309;
                v309 = v287 + v287;
                bool v310;
                v310 = v292 <= v309;
                bool v312;
                if (v310){
                    bool v311;
                    v311 = v309 <= 100;
                    v312 = v311;
                } else {
                    v312 = false;
                }
                float v313;
                if (v312){
                    v313 = 0.25f;
                } else {
                    v313 = 0.0f;
                }
                int16_t v314;
                v314 = v287 * 3;
                int16_t v315;
                v315 = v314 / 2;
                int16_t v316;
                v316 = v287 + v315;
                bool v317;
                v317 = v292 <= v316;
                bool v319;
                if (v317){
                    bool v318;
                    v318 = v316 <= 100;
                    v319 = v318;
                } else {
                    v319 = false;
                }
                float v320;
                if (v319){
                    v320 = 0.25f;
                } else {
                    v320 = 0.0f;
                }
                bool v321;
                v321 = v281 < 100;
                float v322;
                if (v321){
                    v322 = 0.3f;
                } else {
                    v322 = 0.0f;
                }
                std::array<Tuple3,8l> v323;
                US2 v324;
                v324 = US2_1();
                v323[0l] = Tuple3(v324, v289);
                US2 v325;
                v325 = US2_0();
                v323[1l] = Tuple3(v325, 2.0f);
                US2 v326;
                v326 = US2_2(v291);
                v323[2l] = Tuple3(v326, v296);
                US2 v327;
                v327 = US2_2(v298);
                v323[3l] = Tuple3(v327, v302);
                US2 v328;
                v328 = US2_2(v304);
                v323[4l] = Tuple3(v328, v308);
                US2 v329;
                v329 = US2_2(v309);
                v323[5l] = Tuple3(v329, v313);
                US2 v330;
                v330 = US2_2(v316);
                v323[6l] = Tuple3(v330, v320);
                US2 v331;
                v331 = US2_2(100);
                v323[7l] = Tuple3(v331, v322);
                US2 v332;
                v332 = sample_discrete_5(v323, v1);
                US0 v356; int16_t v357; US1 v358;
                switch (v332.tag) {
                    case 0: { // Call
                        bool v335;
                        v335 = v283 >= v281;
                        int16_t v336;
                        if (v335){
                            v336 = v283;
                        } else {
                            v336 = v281;
                        }
                        bool v337;
                        v337 = 0 < v277;
                        US1 v341;
                        if (v337){
                            int8_t v338;
                            v338 = v277 - 1;
                            v341 = US1_1(v338, v284);
                        } else {
                            v341 = US1_0();
                        }
                        v356 = v280; v357 = v336; v358 = v341;
                        break;
                    }
                    case 1: { // Fold
                        US0 v333;
                        v333 = US0_0();
                        US1 v334;
                        v334 = US1_0();
                        v356 = v333; v357 = v281; v358 = v334;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v342 = v332.v.case2.v0;
                        bool v343;
                        v343 = v342 >= v281;
                        int16_t v344;
                        if (v343){
                            v344 = v342;
                        } else {
                            v344 = v281;
                        }
                        bool v345;
                        v345 = v292 >= v344;
                        int16_t v346;
                        if (v345){
                            v346 = v292;
                        } else {
                            v346 = v344;
                        }
                        bool v347;
                        v347 = 100 < v346;
                        int16_t v348;
                        if (v347){
                            v348 = 100;
                        } else {
                            v348 = v346;
                        }
                        US1 v349;
                        v349 = US1_1(0, v284);
                        v356 = v280; v357 = v348; v358 = v349;
                    }
                }
                US0 v359; int16_t v360; US0 v361; int16_t v362;
                if (v279){
                    v359 = v356; v360 = v357; v361 = v282; v362 = v283;
                } else {
                    v359 = v282; v360 = v283; v361 = v356; v362 = v357;
                }
                v368 = v359; v369 = v360; v370 = v361; v371 = v362; v372 = v358;
            }
        }
        uint8_t v373;
        v373 = v269 - 1u;
        v269 = v373;
        v270 = v368;
        v271 = v369;
        v272 = v370;
        v273 = v371;
        v274 = v372;
    }
    Card v374;
    v374 = draw_card_2(v0, v1);
    bool v384;
    v384 = v271 == 2;
    bool v389;
    if (v384){
        bool v387;
        v387 = v273 == 1;
        v389 = v387;
    } else {
        v389 = false;
    }
    int8_t v390;
    if (v389){
        v390 = 2;
    } else {
        v390 = 1;
    }
    US1 v391;
    v391 = US1_1(v390, 0);
    uint8_t v392; US0 v393; int16_t v394; US0 v395; int16_t v396; US1 v397;
    Tuple2 tmp8 = Tuple2(11u, v270, v271, v272, v273, v391);
    v392 = tmp8.v0; v393 = tmp8.v1; v394 = tmp8.v2; v395 = tmp8.v3; v396 = tmp8.v4; v397 = tmp8.v5;
    while (while_method_2(v392, v393, v394, v395, v396, v397)){
        US0 v491; int16_t v492; US0 v493; int16_t v494; US1 v495;
        switch (v397.tag) {
            case 0: { // Done
                US1 v399;
                v399 = US1_0();
                v491 = v393; v492 = v394; v493 = v395; v494 = v396; v495 = v399;
                break;
            }
            default: { // TurnOf
                int8_t v400 = v397.v.case1.v0; int8_t v401 = v397.v.case1.v1;
                bool v402;
                v402 = v401 == 0;
                US0 v403; int16_t v404; US0 v405; int16_t v406; int8_t v407;
                if (v402){
                    v403 = v393; v404 = v394; v405 = v395; v406 = v396; v407 = 1;
                } else {
                    v403 = v395; v404 = v396; v405 = v393; v406 = v394; v407 = 0;
                }
                bool v408;
                v408 = v404 >= v406;
                int16_t v409;
                if (v408){
                    v409 = v404;
                } else {
                    v409 = v406;
                }
                int16_t v410;
                v410 = v409 + v406;
                bool v411;
                v411 = v404 < v406;
                float v412;
                if (v411){
                    v412 = 1.0f;
                } else {
                    v412 = 0.0f;
                }
                int16_t v413;
                v413 = v410 / 4;
                int16_t v414;
                v414 = v410 + v413;
                int16_t v415;
                v415 = v406 + 2;
                bool v416;
                v416 = v415 <= v414;
                bool v418;
                if (v416){
                    bool v417;
                    v417 = v414 <= 100;
                    v418 = v417;
                } else {
                    v418 = false;
                }
                float v419;
                if (v418){
                    v419 = 0.25f;
                } else {
                    v419 = 0.0f;
                }
                int16_t v420;
                v420 = v410 / 3;
                int16_t v421;
                v421 = v410 + v420;
                bool v422;
                v422 = v415 <= v421;
                bool v424;
                if (v422){
                    bool v423;
                    v423 = v421 <= 100;
                    v424 = v423;
                } else {
                    v424 = false;
                }
                float v425;
                if (v424){
                    v425 = 0.25f;
                } else {
                    v425 = 0.0f;
                }
                int16_t v426;
                v426 = v410 / 2;
                int16_t v427;
                v427 = v410 + v426;
                bool v428;
                v428 = v415 <= v427;
                bool v430;
                if (v428){
                    bool v429;
                    v429 = v427 <= 100;
                    v430 = v429;
                } else {
                    v430 = false;
                }
                float v431;
                if (v430){
                    v431 = 0.25f;
                } else {
                    v431 = 0.0f;
                }
                int16_t v432;
                v432 = v410 + v410;
                bool v433;
                v433 = v415 <= v432;
                bool v435;
                if (v433){
                    bool v434;
                    v434 = v432 <= 100;
                    v435 = v434;
                } else {
                    v435 = false;
                }
                float v436;
                if (v435){
                    v436 = 0.25f;
                } else {
                    v436 = 0.0f;
                }
                int16_t v437;
                v437 = v410 * 3;
                int16_t v438;
                v438 = v437 / 2;
                int16_t v439;
                v439 = v410 + v438;
                bool v440;
                v440 = v415 <= v439;
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
                bool v444;
                v444 = v404 < 100;
                float v445;
                if (v444){
                    v445 = 0.3f;
                } else {
                    v445 = 0.0f;
                }
                std::array<Tuple3,8l> v446;
                US2 v447;
                v447 = US2_1();
                v446[0l] = Tuple3(v447, v412);
                US2 v448;
                v448 = US2_0();
                v446[1l] = Tuple3(v448, 2.0f);
                US2 v449;
                v449 = US2_2(v414);
                v446[2l] = Tuple3(v449, v419);
                US2 v450;
                v450 = US2_2(v421);
                v446[3l] = Tuple3(v450, v425);
                US2 v451;
                v451 = US2_2(v427);
                v446[4l] = Tuple3(v451, v431);
                US2 v452;
                v452 = US2_2(v432);
                v446[5l] = Tuple3(v452, v436);
                US2 v453;
                v453 = US2_2(v439);
                v446[6l] = Tuple3(v453, v443);
                US2 v454;
                v454 = US2_2(100);
                v446[7l] = Tuple3(v454, v445);
                US2 v455;
                v455 = sample_discrete_5(v446, v1);
                US0 v479; int16_t v480; US1 v481;
                switch (v455.tag) {
                    case 0: { // Call
                        bool v458;
                        v458 = v406 >= v404;
                        int16_t v459;
                        if (v458){
                            v459 = v406;
                        } else {
                            v459 = v404;
                        }
                        bool v460;
                        v460 = 0 < v400;
                        US1 v464;
                        if (v460){
                            int8_t v461;
                            v461 = v400 - 1;
                            v464 = US1_1(v461, v407);
                        } else {
                            v464 = US1_0();
                        }
                        v479 = v403; v480 = v459; v481 = v464;
                        break;
                    }
                    case 1: { // Fold
                        US0 v456;
                        v456 = US0_0();
                        US1 v457;
                        v457 = US1_0();
                        v479 = v456; v480 = v404; v481 = v457;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v465 = v455.v.case2.v0;
                        bool v466;
                        v466 = v465 >= v404;
                        int16_t v467;
                        if (v466){
                            v467 = v465;
                        } else {
                            v467 = v404;
                        }
                        bool v468;
                        v468 = v415 >= v467;
                        int16_t v469;
                        if (v468){
                            v469 = v415;
                        } else {
                            v469 = v467;
                        }
                        bool v470;
                        v470 = 100 < v469;
                        int16_t v471;
                        if (v470){
                            v471 = 100;
                        } else {
                            v471 = v469;
                        }
                        US1 v472;
                        v472 = US1_1(0, v407);
                        v479 = v403; v480 = v471; v481 = v472;
                    }
                }
                US0 v482; int16_t v483; US0 v484; int16_t v485;
                if (v402){
                    v482 = v479; v483 = v480; v484 = v405; v485 = v406;
                } else {
                    v482 = v405; v483 = v406; v484 = v479; v485 = v480;
                }
                v491 = v482; v492 = v483; v493 = v484; v494 = v485; v495 = v481;
            }
        }
        uint8_t v496;
        v496 = v392 - 1u;
        v392 = v496;
        v393 = v491;
        v394 = v492;
        v395 = v493;
        v396 = v494;
        v397 = v495;
    }
    switch (v393.tag) {
        case 0: { // None
            switch (v395.tag) {
                case 0: { // None
                    return 0;
                    break;
                }
                default: { // Some
                    Card v520 = v395.v.case1.v0; Card v521 = v395.v.case1.v1;
                    int16_t v522;
                    v522 = -v394;
                    return v522;
                }
            }
            break;
        }
        default: { // Some
            Card v497 = v393.v.case1.v0; Card v498 = v393.v.case1.v1;
            switch (v395.tag) {
                case 0: { // None
                    return v396;
                    break;
                }
                default: { // Some
                    Card v499 = v395.v.case1.v0; Card v500 = v395.v.case1.v1;
                    std::array<Card,5l> v501; int8_t v502;
                    Tuple5 tmp31 = score_8(v126, v127, v128, v251, v374, v497, v498);
                    v501 = tmp31.v0; v502 = tmp31.v1;
                    std::array<Card,5l> v503; int8_t v504;
                    Tuple5 tmp32 = score_8(v126, v127, v128, v251, v374, v499, v500);
                    v503 = tmp32.v0; v504 = tmp32.v1;
                    bool v505;
                    v505 = v502 < v504;
                    US8 v511;
                    if (v505){
                        v511 = US8_2();
                    } else {
                        bool v507;
                        v507 = v502 > v504;
                        if (v507){
                            v511 = US8_1();
                        } else {
                            v511 = US8_0();
                        }
                    }
                    US8 v513;
                    switch (v511.tag) {
                        case 0: { // Eq
                            v513 = method_10(v501, v503);
                            break;
                        }
                        default: {
                            v513 = v511;
                        }
                    }
                    switch (v513.tag) {
                        case 0: { // Eq
                            return 0;
                            break;
                        }
                        case 1: { // Gt
                            return v396;
                            break;
                        }
                        default: { // Lt
                            int16_t v514;
                            v514 = -v394;
                            return v514;
                        }
                    }
                }
            }
        }
    }
}
int16_t game_loop_0(){
    std::random_device v0;
    std::mt19937 v1(v0());
    std::mt19937 & v2 = v1;
    int32_t v3; int16_t v4;
    Tuple0 tmp0 = Tuple0(0l, 0);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (while_method_0(v3)){
        std::bitset<52l> v6;
        std::bitset<52l> & v7 = v6;
        int16_t v8;
        v8 = game_1(v7, v2);
        int32_t v9;
        v9 = v3 % 10000l;
        bool v10;
        v10 = v9 == 0l;
        if (v10){
            std::cout << v3 << std::endl;
        } else {
        }
        int16_t v11;
        v11 = v4 + v8;
        v4 = v11;
        v3++;
    }
    return v4;
}
int32_t main() {
    int16_t v0;
    v0 = game_loop_0();
    std::cout << v0 << std::endl;
    return 0l;
}
