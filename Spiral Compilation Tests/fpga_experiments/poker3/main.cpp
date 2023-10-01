#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
#include <cstring>
struct Tuple0;
struct Tuple1;
struct Tuple2;
Tuple1 random_ap_1(ap_uint<128l> v0);
struct Tuple3;
struct Tuple4;
struct Tuple5;
struct Tuple6;
struct Tuple7;
struct Tuple8;
Tuple8 random_ap_6(ap_uint<128l> v0);
Tuple7 random_ap_in_range_5(ap_uint<6l> v0, ap_uint<6l> v1, ap_uint<128l> v2);
struct Tuple9;
Tuple5 sample_without_4(ap_uint<52l> v0, ap_uint<128l> v1);
Tuple4 draw_card_3(ap_uint<52l> v0, ap_uint<128l> v1);
struct US0;
struct US1;
struct Tuple10;
struct US2;
struct Tuple11;
struct Tuple12;
struct Tuple13;
struct Tuple14;
struct Tuple15;
Tuple15 random_ap_10(ap_uint<128l> v0);
struct Tuple16;
Tuple16 random_ap_11(ap_uint<128l> v0);
Tuple14 random_f32_template_9(bool v0, ap_uint<128l> v1);
struct US3;
struct Tuple17;
Tuple2 sample_discrete__8(std::array<float,8l> v0, ap_uint<128l> v1);
Tuple12 sample_discrete_7(std::array<Tuple11,8l> v0, ap_uint<128l> v1);
struct Tuple18;
struct Tuple19;
struct Tuple20;
struct Tuple21;
struct US4;
struct Tuple22;
struct US5;
struct US6;
struct US7;
struct US8;
struct Tuple23;
struct Tuple24;
struct Tuple25;
struct US9;
struct US10;
struct US11;
Tuple19 score_13(std::array<Tuple18,7l> v0);
Tuple19 score_12(ap_uint<4l> v0, ap_uint<2l> v1, ap_uint<4l> v2, ap_uint<2l> v3, ap_uint<4l> v4, ap_uint<2l> v5, ap_uint<4l> v6, ap_uint<2l> v7, ap_uint<4l> v8, ap_uint<2l> v9, ap_uint<4l> v10, ap_uint<2l> v11, ap_uint<4l> v12, ap_uint<2l> v13);
struct Tuple26;
Tuple3 game_2(ap_uint<52l> v0, ap_uint<128l> v1);
int16_t game_loop_0(ap_uint<128l> v0);
struct Tuple0 {
    int32_t v0;
    int16_t v1;
};
struct Tuple1 {
    ap_uint<128l> v0;
    ap_uint<128l> v1;
};
struct Tuple2 {
    ap_uint<128l> v1;
    int32_t v0;
};
struct Tuple3 {
    ap_uint<52l> v1;
    ap_uint<128l> v2;
    int16_t v0;
};
struct Tuple4 {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
    ap_uint<52l> v2;
    ap_uint<128l> v3;
};
struct Tuple5 {
    ap_uint<6l> v0;
    ap_uint<52l> v1;
    ap_uint<128l> v2;
};
struct Tuple6 {
    int32_t v0;
    uint32_t v1;
};
struct Tuple7 {
    ap_uint<6l> v0;
    ap_uint<128l> v1;
};
struct Tuple8 {
    ap_uint<36l> v0;
    ap_uint<128l> v1;
};
struct Tuple9 {
    ap_uint<6l> v1;
    ap_uint<6l> v2;
    int32_t v0;
};
struct US0 {
    ap_uint<2> tag;
    union U {
        struct {
            ap_uint<4l> v0;
            ap_uint<2l> v1;
            ap_uint<4l> v2;
            ap_uint<2l> v3;
        } case1; // Some
        U() {}
    } v;
    US0() {}
    US0(const US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US0(const US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US0 & operator=(US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US0 & operator=(US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US1 {
    ap_uint<2> tag;
    union U {
        struct {
            ap_uint<2l> v0;
            ap_uint<1l> v1;
        } case1; // TurnOf
        U() {}
    } v;
    US1() {}
    US1(const US1 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US1(const US1 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US1 & operator=(US1 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US1 & operator=(US1 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct Tuple10 {
    ap_uint<52l> v0;
    ap_uint<128l> v1;
    US0 v3;
    US0 v5;
    US1 v7;
    int16_t v4;
    int16_t v6;
    uint8_t v2;
};
struct US2 {
    ap_uint<2> tag;
    union U {
        struct {
            int16_t v0;
        } case2; // RaiseTo
        U() {}
    } v;
    US2() {}
    US2(const US2 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 2: { this->v.case2 = x.v.case2; break; }
        }
    }
    US2(const US2 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 2: { this->v.case2 = x.v.case2; break; }
        }
    }
    US2 & operator=(US2 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 2: { this->v.case2 = x.v.case2; break; }
        }
        return *this;
    }
    US2 & operator=(US2 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 2: { this->v.case2 = x.v.case2; break; }
        }
        return *this;
    }
};
struct Tuple11 {
    US2 v0;
    float v1;
};
struct Tuple12 {
    US2 v0;
    ap_uint<128l> v1;
};
struct Tuple13 {
    std::array<float,8l> v0;
    int32_t v1;
};
struct Tuple14 {
    ap_uint<128l> v1;
    float v0;
};
struct Tuple15 {
    ap_uint<22l> v0;
    ap_uint<128l> v1;
};
struct Tuple16 {
    ap_uint<1l> v0;
    ap_uint<128l> v1;
};
struct US3 {
    ap_uint<2> tag;
    union U {
        struct {
            int32_t v0;
        } case1; // Some
        U() {}
    } v;
    US3() {}
    US3(const US3 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US3(const US3 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US3 & operator=(US3 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US3 & operator=(US3 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct Tuple17 {
    US3 v1;
    int32_t v0;
};
struct Tuple18 {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
};
struct Tuple19 {
    std::array<Tuple18,5l> v0;
    ap_uint<4l> v1;
};
struct Tuple20 {
    int32_t v1;
    bool v0;
};
struct Tuple21 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
};
struct US4 {
    ap_uint<2> tag;
    union U {
        U() {}
    } v;
    US4() {}
    US4(const US4 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US4(const US4 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US4 & operator=(US4 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
    US4 & operator=(US4 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
};
struct Tuple22 {
    ap_uint<4l> v3;
    int32_t v0;
    int32_t v1;
    int32_t v2;
};
struct US5 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple18,2l> v0;
            std::array<Tuple18,5l> v1;
        } case1; // Some
        U() {}
    } v;
    US5() {}
    US5(const US5 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US5(const US5 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US5 & operator=(US5 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US5 & operator=(US5 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US6 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple18,5l> v0;
        } case1; // Some
        U() {}
    } v;
    US6() {}
    US6(const US6 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US6(const US6 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US6 & operator=(US6 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US6 & operator=(US6 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US7 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple18,2l> v0;
            std::array<Tuple18,3l> v1;
        } case1; // Some
        U() {}
    } v;
    US7() {}
    US7(const US7 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US7(const US7 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US7 & operator=(US7 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US7 & operator=(US7 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US8 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple18,3l> v0;
            std::array<Tuple18,4l> v1;
        } case1; // Some
        U() {}
    } v;
    US8() {}
    US8(const US8 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US8(const US8 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US8 & operator=(US8 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US8 & operator=(US8 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct Tuple23 {
    ap_uint<4l> v2;
    int32_t v1;
    int32_t v0;
};
struct Tuple24 {
    int32_t v0;
    int32_t v1;
};
struct Tuple25 {
    US4 v1;
    int32_t v0;
};
struct US9 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple18,2l> v0;
            std::array<Tuple18,2l> v1;
        } case1; // Some
        U() {}
    } v;
    US9() {}
    US9(const US9 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US9(const US9 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US9 & operator=(US9 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US9 & operator=(US9 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US10 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple18,4l> v0;
            std::array<Tuple18,3l> v1;
        } case1; // Some
        U() {}
    } v;
    US10() {}
    US10(const US10 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US10(const US10 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US10 & operator=(US10 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US10 & operator=(US10 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US11 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple18,5l> v0;
            ap_uint<4l> v1;
        } case1; // Some
        U() {}
    } v;
    US11() {}
    US11(const US11 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US11(const US11 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US11 & operator=(US11 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US11 & operator=(US11 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct Tuple26 {
    US4 v0;
    int32_t v1;
};
inline Tuple0 TupleCreate0(int32_t v0, int16_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 1000000l;
    return v1;
}
inline Tuple1 TupleCreate1(ap_uint<128l> v0, ap_uint<128l> v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline Tuple2 TupleCreate2(int32_t v0, ap_uint<128l> v1){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_1(int32_t v0){
    bool v1;
    v1 = v0 < 128l;
    return v1;
}
Tuple1 random_ap_1(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<128l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple2 tmp1 = TupleCreate2(0l, v0);
    v2 = tmp1.v0; v3 = tmp1.v1;
    while (while_method_1(v2)){
        ap_uint<1l> v5;
        v5 = v3[0u];
        ap_uint<1l> v6;
        v6 = v3[1u];
        ap_uint<1l> v7;
        v7 = v5 ^ v6;
        ap_uint<1l> v8;
        v8 = v3[2u];
        ap_uint<1l> v9;
        v9 = v3[7u];
        ap_uint<1l> v10;
        v10 = v8 ^ v9;
        ap_uint<1l> v11;
        v11 = v7 ^ v10;
        v1[v2] = v11;
        ap_uint<128l> v12;
        v12 = v3 >> 1l;
        v12[127u] = v11;
        v3 = v12;
        v2++;
    }
    return TupleCreate1(v1, v3);
}
inline Tuple3 TupleCreate3(int16_t v0, ap_uint<52l> v1, ap_uint<128l> v2){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
inline Tuple4 TupleCreate4(ap_uint<4l> v0, ap_uint<2l> v1, ap_uint<52l> v2, ap_uint<128l> v3){
    Tuple4 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3;
    return x;
}
inline Tuple5 TupleCreate5(ap_uint<6l> v0, ap_uint<52l> v1, ap_uint<128l> v2){
    Tuple5 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
inline Tuple6 TupleCreate6(int32_t v0, uint32_t v1){
    Tuple6 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_2(int32_t v0){
    bool v1;
    v1 = v0 < 52l;
    return v1;
}
inline Tuple7 TupleCreate7(ap_uint<6l> v0, ap_uint<128l> v1){
    Tuple7 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline Tuple8 TupleCreate8(ap_uint<36l> v0, ap_uint<128l> v1){
    Tuple8 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_3(int32_t v0){
    bool v1;
    v1 = v0 < 36l;
    return v1;
}
Tuple8 random_ap_6(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<36l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple2 tmp4 = TupleCreate2(0l, v0);
    v2 = tmp4.v0; v3 = tmp4.v1;
    while (while_method_3(v2)){
        ap_uint<1l> v5;
        v5 = v3[0u];
        ap_uint<1l> v6;
        v6 = v3[1u];
        ap_uint<1l> v7;
        v7 = v5 ^ v6;
        ap_uint<1l> v8;
        v8 = v3[2u];
        ap_uint<1l> v9;
        v9 = v3[7u];
        ap_uint<1l> v10;
        v10 = v8 ^ v9;
        ap_uint<1l> v11;
        v11 = v7 ^ v10;
        v1[v2] = v11;
        ap_uint<128l> v12;
        v12 = v3 >> 1l;
        v12[127u] = v11;
        v3 = v12;
        v2++;
    }
    return TupleCreate8(v1, v3);
}
Tuple7 random_ap_in_range_5(ap_uint<6l> v0, ap_uint<6l> v1, ap_uint<128l> v2){
    #pragma HLS PIPELINE II=1l
    ap_uint<6l> v3;
    v3 = v0 - v1;
    ap_uint<36l> v4; ap_uint<128l> v5;
    Tuple8 tmp5 = random_ap_6(v2);
    v4 = tmp5.v0; v5 = tmp5.v1;
    ap_uint<6l> v6;
    v6 = v4 % v3;
    ap_uint<6l> v7;
    v7 = v6 + v1;
    return TupleCreate7(v7, v5);
}
inline Tuple9 TupleCreate9(int32_t v0, ap_uint<6l> v1, ap_uint<6l> v2){
    Tuple9 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple5 sample_without_4(ap_uint<52l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    int32_t v2; uint32_t v3;
    Tuple6 tmp3 = TupleCreate6(0l, 0ul);
    v2 = tmp3.v0; v3 = tmp3.v1;
    while (while_method_2(v2)){
        ap_uint<1l> v5;
        v5 = v0[v2];
        bool v6;
        v6 = v5;
        uint32_t v8;
        if (v6){
            v8 = v3;
        } else {
            uint32_t v7;
            v7 = v3 + 1ul;
            v8 = v7;
        }
        v3 = v8;
        v2++;
    }
    ap_uint<6l> v9;
    v9 = 0l;
    ap_uint<6l> v10;
    v10 = v3;
    ap_uint<6l> v11; ap_uint<128l> v12;
    Tuple7 tmp6 = random_ap_in_range_5(v10, v9, v1);
    v11 = tmp6.v0; v12 = tmp6.v1;
    ap_uint<6l> v13;
    v13 = 0l;
    ap_uint<6l> v14;
    v14 = v11 + 1;
    int32_t v15; ap_uint<6l> v16; ap_uint<6l> v17;
    Tuple9 tmp7 = TupleCreate9(0l, v13, v14);
    v15 = tmp7.v0; v16 = tmp7.v1; v17 = tmp7.v2;
    while (while_method_2(v15)){
        ap_uint<6l> v19;
        v19 = 0l;
        bool v20;
        v20 = v17 > v19;
        ap_uint<6l> v26; ap_uint<6l> v27;
        if (v20){
            ap_uint<6l> v21;
            v21 = v15;
            ap_uint<1l> v22;
            v22 = v0[v15];
            bool v23;
            v23 = v22;
            ap_uint<6l> v25;
            if (v23){
                v25 = v17;
            } else {
                ap_uint<6l> v24;
                v24 = v17 - 1;
                v25 = v24;
            }
            v26 = v21; v27 = v25;
        } else {
            v26 = v16; v27 = v17;
        }
        v16 = v26;
        v17 = v27;
        v15++;
    }
    ap_uint<52l> v28;
    v28 = 1l;
    ap_uint<52l> v29;
    v29 = v28 << v16;
    ap_uint<52l> v30;
    v30 = v0 | v29;
    return TupleCreate5(v16, v30, v12);
}
Tuple4 draw_card_3(ap_uint<52l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    ap_uint<6l> v2; ap_uint<52l> v3; ap_uint<128l> v4;
    Tuple5 tmp8 = sample_without_4(v0, v1);
    v2 = tmp8.v0; v3 = tmp8.v1; v4 = tmp8.v2;
    ap_uint<4l> v5;
    v5 = 13l;
    ap_uint<4l> v6;
    v6 = v2 % v5;
    ap_uint<6l> v7;
    v7 = 13l;
    ap_uint<2l> v8;
    v8 = v2 / v7;
    return TupleCreate4(v6, v8, v3, v4);
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(ap_uint<4l> v0, ap_uint<2l> v1, ap_uint<4l> v2, ap_uint<2l> v3) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3;
    return x;
}
US1 US1_0() { // Done
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(ap_uint<2l> v0, ap_uint<1l> v1) { // TurnOf
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
inline Tuple10 TupleCreate10(ap_uint<52l> v0, ap_uint<128l> v1, uint8_t v2, US0 v3, int16_t v4, US0 v5, int16_t v6, US1 v7){
    Tuple10 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4; x.v5 = v5; x.v6 = v6; x.v7 = v7;
    return x;
}
inline bool while_method_4(ap_uint<52l> v0, ap_uint<128l> v1, uint8_t v2, US0 v3, int16_t v4, US0 v5, int16_t v6, US1 v7){
    bool v8;
    v8 = v2 > 0u;
    if (v8){
        bool v10;
        switch (v7.tag) {
            case 0: { // Done
                v10 = true;
                break;
            }
            default: {
                v10 = false;
            }
        }
        bool v11;
        v11 = v10 != true;
        return v11;
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
inline Tuple11 TupleCreate11(US2 v0, float v1){
    Tuple11 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline Tuple12 TupleCreate12(US2 v0, ap_uint<128l> v1){
    Tuple12 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_5(int32_t v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
inline Tuple13 TupleCreate13(std::array<float,8l> v0, int32_t v1){
    Tuple13 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_6(std::array<float,8l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 8l;
    return v2;
}
inline Tuple14 TupleCreate14(float v0, ap_uint<128l> v1){
    Tuple14 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline Tuple15 TupleCreate15(ap_uint<22l> v0, ap_uint<128l> v1){
    Tuple15 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_7(int32_t v0){
    bool v1;
    v1 = v0 < 22l;
    return v1;
}
Tuple15 random_ap_10(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<22l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple2 tmp16 = TupleCreate2(0l, v0);
    v2 = tmp16.v0; v3 = tmp16.v1;
    while (while_method_7(v2)){
        ap_uint<1l> v5;
        v5 = v3[0u];
        ap_uint<1l> v6;
        v6 = v3[1u];
        ap_uint<1l> v7;
        v7 = v5 ^ v6;
        ap_uint<1l> v8;
        v8 = v3[2u];
        ap_uint<1l> v9;
        v9 = v3[7u];
        ap_uint<1l> v10;
        v10 = v8 ^ v9;
        ap_uint<1l> v11;
        v11 = v7 ^ v10;
        v1[v2] = v11;
        ap_uint<128l> v12;
        v12 = v3 >> 1l;
        v12[127u] = v11;
        v3 = v12;
        v2++;
    }
    return TupleCreate15(v1, v3);
}
inline Tuple16 TupleCreate16(ap_uint<1l> v0, ap_uint<128l> v1){
    Tuple16 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_8(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
Tuple16 random_ap_11(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<1l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple2 tmp18 = TupleCreate2(0l, v0);
    v2 = tmp18.v0; v3 = tmp18.v1;
    while (while_method_8(v2)){
        ap_uint<1l> v5;
        v5 = v3[0u];
        ap_uint<1l> v6;
        v6 = v3[1u];
        ap_uint<1l> v7;
        v7 = v5 ^ v6;
        ap_uint<1l> v8;
        v8 = v3[2u];
        ap_uint<1l> v9;
        v9 = v3[7u];
        ap_uint<1l> v10;
        v10 = v8 ^ v9;
        ap_uint<1l> v11;
        v11 = v7 ^ v10;
        v1[v2] = v11;
        ap_uint<128l> v12;
        v12 = v3 >> 1l;
        v12[127u] = v11;
        v3 = v12;
        v2++;
    }
    return TupleCreate16(v1, v3);
}
Tuple14 random_f32_template_9(bool v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    ap_uint<22l> v2; ap_uint<128l> v3;
    Tuple15 tmp17 = random_ap_10(v1);
    v2 = tmp17.v0; v3 = tmp17.v1;
    ap_uint<1l> v7; ap_uint<128l> v8;
    if (v0){
        ap_uint<1l> v4;
        v4 = 1;
        v7 = v4; v8 = v3;
    } else {
        Tuple16 tmp19 = random_ap_11(v3);
        v7 = tmp19.v0; v8 = tmp19.v1;
    }
    ap_uint<23l> v9;
    v9 = v2.concat(v7);
    ap_uint<8l> v10;
    v10 = 127;
    ap_uint<1l> v11;
    v11 = 0b0;
    ap_uint<31l> v12;
    v12 = v10.concat(v9);
    ap_uint<32l> v13;
    v13 = v11.concat(v12);
    uint32_t v14;
    v14 = static_cast<uint32_t>(v13);
    float v15;
    v15 = 0.0f;
    static_assert(sizeof(uint32_t) == sizeof(float), "float has a weird size");
    std::memcpy(&v15,&v14,sizeof(float));
    float v16;
    v16 = v15 - 1.0f;
    return TupleCreate14(v16, v8);
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
inline Tuple17 TupleCreate17(int32_t v0, US3 v1){
    Tuple17 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple2 sample_discrete__8(std::array<float,8l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    std::array<float,8l> v2;
    int32_t v3;
    v3 = 0l;
    while (while_method_5(v3)){
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
    std::array<float,8l> v8; int32_t v9;
    Tuple13 tmp15 = TupleCreate13(v2, 1l);
    v8 = tmp15.v0; v9 = tmp15.v1;
    while (while_method_6(v8, v9)){
        #pragma HLS UNROLL
        std::array<float,8l> v11;
        int32_t v12;
        v12 = 0l;
        while (while_method_5(v12)){
            int32_t v14;
            v14 = v12 - v9;
            bool v15;
            v15 = 0l <= v14;
            float v20;
            if (v15){
                float v16;
                v16 = v8[v14];
                float v17;
                v17 = v8[v12];
                float v18;
                v18 = v16 + v17;
                v20 = v18;
            } else {
                float v19;
                v19 = v8[v12];
                v20 = v19;
            }
            v11[v12] = v20;
            v12++;
        }
        int32_t v21;
        v21 = v9 * 2l;
        v8 = v11;
        v9 = v21;
    }
    float v22;
    v22 = v8[7l];
    std::array<float,8l> v23;
    int32_t v24;
    v24 = 0l;
    while (while_method_5(v24)){
        float v26;
        v26 = v8[v24];
        float v27;
        v27 = v26 / v22;
        v23[v24] = v27;
        v24++;
    }
    bool v28;
    v28 = false;
    float v29; ap_uint<128l> v30;
    Tuple14 tmp20 = random_f32_template_9(v28, v1);
    v29 = tmp20.v0; v30 = tmp20.v1;
    US3 v31;
    v31 = US3_0();
    int32_t v32; US3 v33;
    Tuple17 tmp21 = TupleCreate17(0l, v31);
    v32 = tmp21.v0; v33 = tmp21.v1;
    while (while_method_5(v32)){
        float v35;
        v35 = v23[v32];
        US3 v39;
        switch (v33.tag) {
            case 0: { // None
                bool v36;
                v36 = v29 < v35;
                if (v36){
                    v39 = US3_1(v32);
                } else {
                    v39 = v33;
                }
                break;
            }
            default: {
                v39 = v33;
            }
        }
        v33 = v39;
        v32++;
    }
    int32_t v42;
    switch (v33.tag) {
        case 0: { // None
            v42 = 0l;
            break;
        }
        default: { // Some
            int32_t v40 = v33.v.case1.v0;
            v42 = v40;
        }
    }
    return TupleCreate2(v42, v30);
}
Tuple12 sample_discrete_7(std::array<Tuple11,8l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    std::array<float,8l> v2;
    int32_t v3;
    v3 = 0l;
    while (while_method_5(v3)){
        US2 v5; float v6;
        Tuple11 tmp14 = v0[v3];
        v5 = tmp14.v0; v6 = tmp14.v1;
        v2[v3] = v6;
        v3++;
    }
    int32_t v7; ap_uint<128l> v8;
    Tuple2 tmp22 = sample_discrete__8(v2, v1);
    v7 = tmp22.v0; v8 = tmp22.v1;
    US2 v9; float v10;
    Tuple11 tmp23 = v0[v7];
    v9 = tmp23.v0; v10 = tmp23.v1;
    return TupleCreate12(v9, v8);
}
inline Tuple18 TupleCreate18(ap_uint<4l> v0, ap_uint<2l> v1){
    Tuple18 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline Tuple19 TupleCreate19(std::array<Tuple18,5l> v0, ap_uint<4l> v1){
    Tuple19 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_9(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
inline Tuple20 TupleCreate20(bool v0, int32_t v1){
    Tuple20 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_10(std::array<Tuple18,7l> v0, bool v1, int32_t v2){
    bool v3;
    v3 = v2 < 7l;
    return v3;
}
inline bool while_method_11(std::array<Tuple18,7l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 7l;
    return v2;
}
inline Tuple21 TupleCreate21(int32_t v0, int32_t v1, int32_t v2){
    Tuple21 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
inline bool while_method_12(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
US4 US4_0() { // Eq
    US4 x;
    x.tag = 0;
    return x;
}
US4 US4_1() { // Gt
    US4 x;
    x.tag = 1;
    return x;
}
US4 US4_2() { // Lt
    US4 x;
    x.tag = 2;
    return x;
}
inline bool while_method_13(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
inline Tuple22 TupleCreate22(int32_t v0, int32_t v1, int32_t v2, ap_uint<4l> v3){
    Tuple22 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(std::array<Tuple18,2l> v0, std::array<Tuple18,5l> v1) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
US6 US6_1(std::array<Tuple18,5l> v0) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
inline bool while_method_14(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
inline bool while_method_15(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
US7 US7_1(std::array<Tuple18,2l> v0, std::array<Tuple18,3l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US8 US8_0() { // None
    US8 x;
    x.tag = 0;
    return x;
}
US8 US8_1(std::array<Tuple18,3l> v0, std::array<Tuple18,4l> v1) { // Some
    US8 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
inline bool while_method_16(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
inline Tuple23 TupleCreate23(int32_t v0, int32_t v1, ap_uint<4l> v2){
    Tuple23 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
inline Tuple24 TupleCreate24(int32_t v0, int32_t v1){
    Tuple24 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline Tuple25 TupleCreate25(int32_t v0, US4 v1){
    Tuple25 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US9 US9_0() { // None
    US9 x;
    x.tag = 0;
    return x;
}
US9 US9_1(std::array<Tuple18,2l> v0, std::array<Tuple18,2l> v1) { // Some
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
US10 US10_1(std::array<Tuple18,4l> v0, std::array<Tuple18,3l> v1) { // Some
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
US11 US11_1(std::array<Tuple18,5l> v0, ap_uint<4l> v1) { // Some
    US11 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple19 score_13(std::array<Tuple18,7l> v0){
    #pragma HLS PIPELINE II=1l
    std::array<Tuple18,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_9(v2)){
        ap_uint<4l> v4; ap_uint<2l> v5;
        Tuple18 tmp36 = v0[v2];
        v4 = tmp36.v0; v5 = tmp36.v1;
        v1[v2] = TupleCreate18(v4, v5);
        v2++;
    }
    std::array<Tuple18,7l> v6;
    bool v7; int32_t v8;
    Tuple20 tmp37 = TupleCreate20(true, 1l);
    v7 = tmp37.v0; v8 = tmp37.v1;
    while (while_method_10(v1, v7, v8)){
        int32_t v10;
        v10 = 0l;
        while (while_method_11(v1, v10)){
            int32_t v12;
            v12 = v10 + v8;
            bool v13;
            v13 = v12 < 7l;
            int32_t v14;
            if (v13){
                v14 = v12;
            } else {
                v14 = 7l;
            }
            int32_t v15;
            v15 = v8 * 2l;
            int32_t v16;
            v16 = v10 + v15;
            bool v17;
            v17 = v16 < 7l;
            int32_t v18;
            if (v17){
                v18 = v16;
            } else {
                v18 = 7l;
            }
            int32_t v19; int32_t v20; int32_t v21;
            Tuple21 tmp38 = TupleCreate21(v10, v14, v10);
            v19 = tmp38.v0; v20 = tmp38.v1; v21 = tmp38.v2;
            while (while_method_12(v18, v19, v20, v21)){
                bool v23;
                v23 = v19 < v14;
                bool v25;
                if (v23){
                    bool v24;
                    v24 = v20 < v18;
                    v25 = v24;
                } else {
                    v25 = false;
                }
                ap_uint<4l> v77; ap_uint<2l> v78; int32_t v79; int32_t v80;
                if (v25){
                    ap_uint<4l> v30; ap_uint<2l> v31;
                    if (v7){
                        ap_uint<4l> v26; ap_uint<2l> v27;
                        Tuple18 tmp39 = v1[v19];
                        v26 = tmp39.v0; v27 = tmp39.v1;
                        v30 = v26; v31 = v27;
                    } else {
                        ap_uint<4l> v28; ap_uint<2l> v29;
                        Tuple18 tmp40 = v6[v19];
                        v28 = tmp40.v0; v29 = tmp40.v1;
                        v30 = v28; v31 = v29;
                    }
                    ap_uint<4l> v36; ap_uint<2l> v37;
                    if (v7){
                        ap_uint<4l> v32; ap_uint<2l> v33;
                        Tuple18 tmp41 = v1[v20];
                        v32 = tmp41.v0; v33 = tmp41.v1;
                        v36 = v32; v37 = v33;
                    } else {
                        ap_uint<4l> v34; ap_uint<2l> v35;
                        Tuple18 tmp42 = v6[v20];
                        v34 = tmp42.v0; v35 = tmp42.v1;
                        v36 = v34; v37 = v35;
                    }
                    bool v38;
                    v38 = v36 > v30;
                    US4 v44;
                    if (v38){
                        v44 = US4_1();
                    } else {
                        bool v40;
                        v40 = v36 < v30;
                        if (v40){
                            v44 = US4_2();
                        } else {
                            v44 = US4_0();
                        }
                    }
                    US4 v52;
                    switch (v44.tag) {
                        case 0: { // Eq
                            bool v45;
                            v45 = v31 > v37;
                            if (v45){
                                v52 = US4_1();
                            } else {
                                bool v47;
                                v47 = v31 < v37;
                                if (v47){
                                    v52 = US4_2();
                                } else {
                                    v52 = US4_0();
                                }
                            }
                            break;
                        }
                        default: {
                            v52 = v44;
                        }
                    }
                    switch (v52.tag) {
                        case 1: { // Gt
                            int32_t v53;
                            v53 = v20 + 1l;
                            v77 = v36; v78 = v37; v79 = v19; v80 = v53;
                            break;
                        }
                        default: {
                            int32_t v54;
                            v54 = v19 + 1l;
                            v77 = v30; v78 = v31; v79 = v54; v80 = v20;
                        }
                    }
                } else {
                    if (v23){
                        ap_uint<4l> v63; ap_uint<2l> v64;
                        if (v7){
                            ap_uint<4l> v59; ap_uint<2l> v60;
                            Tuple18 tmp43 = v1[v19];
                            v59 = tmp43.v0; v60 = tmp43.v1;
                            v63 = v59; v64 = v60;
                        } else {
                            ap_uint<4l> v61; ap_uint<2l> v62;
                            Tuple18 tmp44 = v6[v19];
                            v61 = tmp44.v0; v62 = tmp44.v1;
                            v63 = v61; v64 = v62;
                        }
                        int32_t v65;
                        v65 = v19 + 1l;
                        v77 = v63; v78 = v64; v79 = v65; v80 = v20;
                    } else {
                        ap_uint<4l> v70; ap_uint<2l> v71;
                        if (v7){
                            ap_uint<4l> v66; ap_uint<2l> v67;
                            Tuple18 tmp45 = v1[v20];
                            v66 = tmp45.v0; v67 = tmp45.v1;
                            v70 = v66; v71 = v67;
                        } else {
                            ap_uint<4l> v68; ap_uint<2l> v69;
                            Tuple18 tmp46 = v6[v20];
                            v68 = tmp46.v0; v69 = tmp46.v1;
                            v70 = v68; v71 = v69;
                        }
                        int32_t v72;
                        v72 = v20 + 1l;
                        v77 = v70; v78 = v71; v79 = v19; v80 = v72;
                    }
                }
                if (v7){
                    v6[v21] = TupleCreate18(v77, v78);
                } else {
                    v1[v21] = TupleCreate18(v77, v78);
                }
                int32_t v81;
                v81 = v21 + 1l;
                v19 = v79;
                v20 = v80;
                v21 = v81;
            }
            v10 = v16;
        }
        bool v82;
        v82 = v7 == false;
        int32_t v83;
        v83 = v8 * 2l;
        v7 = v82;
        v8 = v83;
    }
    bool v84;
    v84 = v7 == false;
    std::array<Tuple18,7l> v85;
    if (v84){
        v85 = v6;
    } else {
        v85 = v1;
    }
    std::array<Tuple18,5l> v86;
    int32_t v87;
    v87 = 0l;
    while (while_method_13(v87)){
        ap_uint<4l> v89; ap_uint<2l> v90;
        Tuple18 tmp47 = v85[v87];
        v89 = tmp47.v0; v90 = tmp47.v1;
        v86[v87] = TupleCreate18(v89, v90);
        v87++;
    }
    std::array<Tuple18,2l> v91;
    std::array<Tuple18,5l> v92;
    ap_uint<4l> v93;
    v93 = 12ul;
    int32_t v94; int32_t v95; int32_t v96; ap_uint<4l> v97;
    Tuple22 tmp48 = TupleCreate22(0l, 0l, 0l, v93);
    v94 = tmp48.v0; v95 = tmp48.v1; v96 = tmp48.v2; v97 = tmp48.v3;
    while (while_method_9(v94)){
        ap_uint<4l> v99; ap_uint<2l> v100;
        Tuple18 tmp49 = v85[v94];
        v99 = tmp49.v0; v100 = tmp49.v1;
        bool v101;
        v101 = v96 < 2l;
        int32_t v105; int32_t v106; ap_uint<4l> v107;
        if (v101){
            bool v102;
            v102 = v97 == v99;
            int32_t v103;
            if (v102){
                v103 = v96;
            } else {
                v103 = 0l;
            }
            v91[v103] = TupleCreate18(v99, v100);
            int32_t v104;
            v104 = v103 + 1l;
            v105 = v94; v106 = v104; v107 = v99;
        } else {
            v105 = v95; v106 = v96; v107 = v97;
        }
        v95 = v105;
        v96 = v106;
        v97 = v107;
        v94++;
    }
    bool v108;
    v108 = v96 == 2l;
    US5 v121;
    if (v108){
        int32_t v109;
        v109 = 0l;
        while (while_method_13(v109)){
            int32_t v111;
            v111 = v95 + 1l;
            int32_t v112;
            v112 = v111 - 2l;
            bool v113;
            v113 = v109 < v112;
            if (v113){
                ap_uint<4l> v114; ap_uint<2l> v115;
                Tuple18 tmp50 = v85[v109];
                v114 = tmp50.v0; v115 = tmp50.v1;
                v92[v109] = TupleCreate18(v114, v115);
            } else {
                int32_t v116;
                v116 = 2l + v109;
                ap_uint<4l> v117; ap_uint<2l> v118;
                Tuple18 tmp51 = v85[v116];
                v117 = tmp51.v0; v118 = tmp51.v1;
                v92[v109] = TupleCreate18(v117, v118);
            }
            v109++;
        }
        v121 = US5_1(v91, v92);
    } else {
        v121 = US5_0();
    }
    US6 v143;
    switch (v121.tag) {
        case 0: { // None
            v143 = US6_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,2l> v122 = v121.v.case1.v0; std::array<Tuple18,5l> v123 = v121.v.case1.v1;
            std::array<Tuple18,3l> v124;
            int32_t v125;
            v125 = 0l;
            while (while_method_14(v125)){
                ap_uint<4l> v127; ap_uint<2l> v128;
                Tuple18 tmp52 = v123[v125];
                v127 = tmp52.v0; v128 = tmp52.v1;
                v124[v125] = TupleCreate18(v127, v128);
                v125++;
            }
            std::array<Tuple18,0l> v129;
            std::array<Tuple18,5l> v130;
            int32_t v131;
            v131 = 0l;
            while (while_method_15(v131)){
                ap_uint<4l> v133; ap_uint<2l> v134;
                Tuple18 tmp53 = v122[v131];
                v133 = tmp53.v0; v134 = tmp53.v1;
                v130[v131] = TupleCreate18(v133, v134);
                v131++;
            }
            int32_t v135;
            v135 = 0l;
            while (while_method_14(v135)){
                ap_uint<4l> v137; ap_uint<2l> v138;
                Tuple18 tmp54 = v124[v135];
                v137 = tmp54.v0; v138 = tmp54.v1;
                int32_t v139;
                v139 = 2l + v135;
                v130[v139] = TupleCreate18(v137, v138);
                v135++;
            }
            v143 = US6_1(v130);
        }
    }
    std::array<Tuple18,2l> v144;
    std::array<Tuple18,5l> v145;
    ap_uint<4l> v146;
    v146 = 12ul;
    int32_t v147; int32_t v148; int32_t v149; ap_uint<4l> v150;
    Tuple22 tmp55 = TupleCreate22(0l, 0l, 0l, v146);
    v147 = tmp55.v0; v148 = tmp55.v1; v149 = tmp55.v2; v150 = tmp55.v3;
    while (while_method_9(v147)){
        ap_uint<4l> v152; ap_uint<2l> v153;
        Tuple18 tmp56 = v85[v147];
        v152 = tmp56.v0; v153 = tmp56.v1;
        bool v154;
        v154 = v149 < 2l;
        int32_t v158; int32_t v159; ap_uint<4l> v160;
        if (v154){
            bool v155;
            v155 = v150 == v152;
            int32_t v156;
            if (v155){
                v156 = v149;
            } else {
                v156 = 0l;
            }
            v144[v156] = TupleCreate18(v152, v153);
            int32_t v157;
            v157 = v156 + 1l;
            v158 = v147; v159 = v157; v160 = v152;
        } else {
            v158 = v148; v159 = v149; v160 = v150;
        }
        v148 = v158;
        v149 = v159;
        v150 = v160;
        v147++;
    }
    bool v161;
    v161 = v149 == 2l;
    US5 v174;
    if (v161){
        int32_t v162;
        v162 = 0l;
        while (while_method_13(v162)){
            int32_t v164;
            v164 = v148 + 1l;
            int32_t v165;
            v165 = v164 - 2l;
            bool v166;
            v166 = v162 < v165;
            if (v166){
                ap_uint<4l> v167; ap_uint<2l> v168;
                Tuple18 tmp57 = v85[v162];
                v167 = tmp57.v0; v168 = tmp57.v1;
                v145[v162] = TupleCreate18(v167, v168);
            } else {
                int32_t v169;
                v169 = 2l + v162;
                ap_uint<4l> v170; ap_uint<2l> v171;
                Tuple18 tmp58 = v85[v169];
                v170 = tmp58.v0; v171 = tmp58.v1;
                v145[v162] = TupleCreate18(v170, v171);
            }
            v162++;
        }
        v174 = US5_1(v144, v145);
    } else {
        v174 = US5_0();
    }
    US6 v236;
    switch (v174.tag) {
        case 0: { // None
            v236 = US6_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,2l> v175 = v174.v.case1.v0; std::array<Tuple18,5l> v176 = v174.v.case1.v1;
            std::array<Tuple18,2l> v177;
            std::array<Tuple18,3l> v178;
            ap_uint<4l> v179;
            v179 = 12ul;
            int32_t v180; int32_t v181; int32_t v182; ap_uint<4l> v183;
            Tuple22 tmp59 = TupleCreate22(0l, 0l, 0l, v179);
            v180 = tmp59.v0; v181 = tmp59.v1; v182 = tmp59.v2; v183 = tmp59.v3;
            while (while_method_13(v180)){
                ap_uint<4l> v185; ap_uint<2l> v186;
                Tuple18 tmp60 = v176[v180];
                v185 = tmp60.v0; v186 = tmp60.v1;
                bool v187;
                v187 = v182 < 2l;
                int32_t v191; int32_t v192; ap_uint<4l> v193;
                if (v187){
                    bool v188;
                    v188 = v183 == v185;
                    int32_t v189;
                    if (v188){
                        v189 = v182;
                    } else {
                        v189 = 0l;
                    }
                    v177[v189] = TupleCreate18(v185, v186);
                    int32_t v190;
                    v190 = v189 + 1l;
                    v191 = v180; v192 = v190; v193 = v185;
                } else {
                    v191 = v181; v192 = v182; v193 = v183;
                }
                v181 = v191;
                v182 = v192;
                v183 = v193;
                v180++;
            }
            bool v194;
            v194 = v182 == 2l;
            US7 v207;
            if (v194){
                int32_t v195;
                v195 = 0l;
                while (while_method_14(v195)){
                    int32_t v197;
                    v197 = v181 + 1l;
                    int32_t v198;
                    v198 = v197 - 2l;
                    bool v199;
                    v199 = v195 < v198;
                    if (v199){
                        ap_uint<4l> v200; ap_uint<2l> v201;
                        Tuple18 tmp61 = v176[v195];
                        v200 = tmp61.v0; v201 = tmp61.v1;
                        v178[v195] = TupleCreate18(v200, v201);
                    } else {
                        int32_t v202;
                        v202 = 2l + v195;
                        ap_uint<4l> v203; ap_uint<2l> v204;
                        Tuple18 tmp62 = v176[v202];
                        v203 = tmp62.v0; v204 = tmp62.v1;
                        v178[v195] = TupleCreate18(v203, v204);
                    }
                    v195++;
                }
                v207 = US7_1(v177, v178);
            } else {
                v207 = US7_0();
            }
            switch (v207.tag) {
                case 0: { // None
                    v236 = US6_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple18,2l> v208 = v207.v.case1.v0; std::array<Tuple18,3l> v209 = v207.v.case1.v1;
                    std::array<Tuple18,1l> v210;
                    int32_t v211;
                    v211 = 0l;
                    while (while_method_8(v211)){
                        ap_uint<4l> v213; ap_uint<2l> v214;
                        Tuple18 tmp63 = v209[v211];
                        v213 = tmp63.v0; v214 = tmp63.v1;
                        v210[v211] = TupleCreate18(v213, v214);
                        v211++;
                    }
                    std::array<Tuple18,5l> v215;
                    int32_t v216;
                    v216 = 0l;
                    while (while_method_15(v216)){
                        ap_uint<4l> v218; ap_uint<2l> v219;
                        Tuple18 tmp64 = v175[v216];
                        v218 = tmp64.v0; v219 = tmp64.v1;
                        v215[v216] = TupleCreate18(v218, v219);
                        v216++;
                    }
                    int32_t v220;
                    v220 = 0l;
                    while (while_method_15(v220)){
                        ap_uint<4l> v222; ap_uint<2l> v223;
                        Tuple18 tmp65 = v208[v220];
                        v222 = tmp65.v0; v223 = tmp65.v1;
                        int32_t v224;
                        v224 = 2l + v220;
                        v215[v224] = TupleCreate18(v222, v223);
                        v220++;
                    }
                    int32_t v225;
                    v225 = 0l;
                    while (while_method_8(v225)){
                        ap_uint<4l> v227; ap_uint<2l> v228;
                        Tuple18 tmp66 = v210[v225];
                        v227 = tmp66.v0; v228 = tmp66.v1;
                        int32_t v229;
                        v229 = 4l + v225;
                        v215[v229] = TupleCreate18(v227, v228);
                        v225++;
                    }
                    v236 = US6_1(v215);
                }
            }
        }
    }
    std::array<Tuple18,3l> v237;
    std::array<Tuple18,4l> v238;
    ap_uint<4l> v239;
    v239 = 12ul;
    int32_t v240; int32_t v241; int32_t v242; ap_uint<4l> v243;
    Tuple22 tmp67 = TupleCreate22(0l, 0l, 0l, v239);
    v240 = tmp67.v0; v241 = tmp67.v1; v242 = tmp67.v2; v243 = tmp67.v3;
    while (while_method_9(v240)){
        ap_uint<4l> v245; ap_uint<2l> v246;
        Tuple18 tmp68 = v85[v240];
        v245 = tmp68.v0; v246 = tmp68.v1;
        bool v247;
        v247 = v242 < 3l;
        int32_t v251; int32_t v252; ap_uint<4l> v253;
        if (v247){
            bool v248;
            v248 = v243 == v245;
            int32_t v249;
            if (v248){
                v249 = v242;
            } else {
                v249 = 0l;
            }
            v237[v249] = TupleCreate18(v245, v246);
            int32_t v250;
            v250 = v249 + 1l;
            v251 = v240; v252 = v250; v253 = v245;
        } else {
            v251 = v241; v252 = v242; v253 = v243;
        }
        v241 = v251;
        v242 = v252;
        v243 = v253;
        v240++;
    }
    bool v254;
    v254 = v242 == 3l;
    US8 v267;
    if (v254){
        int32_t v255;
        v255 = 0l;
        while (while_method_16(v255)){
            int32_t v257;
            v257 = v241 + 1l;
            int32_t v258;
            v258 = v257 - 3l;
            bool v259;
            v259 = v255 < v258;
            if (v259){
                ap_uint<4l> v260; ap_uint<2l> v261;
                Tuple18 tmp69 = v85[v255];
                v260 = tmp69.v0; v261 = tmp69.v1;
                v238[v255] = TupleCreate18(v260, v261);
            } else {
                int32_t v262;
                v262 = 3l + v255;
                ap_uint<4l> v263; ap_uint<2l> v264;
                Tuple18 tmp70 = v85[v262];
                v263 = tmp70.v0; v264 = tmp70.v1;
                v238[v255] = TupleCreate18(v263, v264);
            }
            v255++;
        }
        v267 = US8_1(v237, v238);
    } else {
        v267 = US8_0();
    }
    US6 v289;
    switch (v267.tag) {
        case 0: { // None
            v289 = US6_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,3l> v268 = v267.v.case1.v0; std::array<Tuple18,4l> v269 = v267.v.case1.v1;
            std::array<Tuple18,2l> v270;
            int32_t v271;
            v271 = 0l;
            while (while_method_15(v271)){
                ap_uint<4l> v273; ap_uint<2l> v274;
                Tuple18 tmp71 = v269[v271];
                v273 = tmp71.v0; v274 = tmp71.v1;
                v270[v271] = TupleCreate18(v273, v274);
                v271++;
            }
            std::array<Tuple18,0l> v275;
            std::array<Tuple18,5l> v276;
            int32_t v277;
            v277 = 0l;
            while (while_method_14(v277)){
                ap_uint<4l> v279; ap_uint<2l> v280;
                Tuple18 tmp72 = v268[v277];
                v279 = tmp72.v0; v280 = tmp72.v1;
                v276[v277] = TupleCreate18(v279, v280);
                v277++;
            }
            int32_t v281;
            v281 = 0l;
            while (while_method_15(v281)){
                ap_uint<4l> v283; ap_uint<2l> v284;
                Tuple18 tmp73 = v270[v281];
                v283 = tmp73.v0; v284 = tmp73.v1;
                int32_t v285;
                v285 = 3l + v281;
                v276[v285] = TupleCreate18(v283, v284);
                v281++;
            }
            v289 = US6_1(v276);
        }
    }
    std::array<Tuple18,5l> v290;
    ap_uint<4l> v291;
    v291 = 12ul;
    int32_t v292; int32_t v293; ap_uint<4l> v294;
    Tuple23 tmp74 = TupleCreate23(0l, 0l, v291);
    v292 = tmp74.v0; v293 = tmp74.v1; v294 = tmp74.v2;
    while (while_method_9(v292)){
        ap_uint<4l> v296; ap_uint<2l> v297;
        Tuple18 tmp75 = v85[v292];
        v296 = tmp75.v0; v297 = tmp75.v1;
        bool v298;
        v298 = v293 < 5l;
        bool v303;
        if (v298){
            ap_uint<4l> v299;
            v299 = 1ul;
            ap_uint<4l> v300;
            v300 = v296 - v299;
            bool v301;
            v301 = v294 == v300;
            bool v302;
            v302 = v301 != true;
            v303 = v302;
        } else {
            v303 = false;
        }
        int32_t v309; ap_uint<4l> v310;
        if (v303){
            bool v304;
            v304 = v294 == v296;
            int32_t v305;
            if (v304){
                v305 = v293;
            } else {
                v305 = 0l;
            }
            v290[v305] = TupleCreate18(v296, v297);
            int32_t v306;
            v306 = v305 + 1l;
            ap_uint<4l> v307;
            v307 = 1ul;
            ap_uint<4l> v308;
            v308 = v296 - v307;
            v309 = v306; v310 = v308;
        } else {
            v309 = v293; v310 = v294;
        }
        v293 = v309;
        v294 = v310;
        v292++;
    }
    bool v311;
    v311 = v293 == 4l;
    bool v322;
    if (v311){
        ap_uint<4l> v312;
        v312 = 0ul;
        ap_uint<4l> v313;
        v313 = 1ul;
        ap_uint<4l> v314;
        v314 = v312 - v313;
        bool v315;
        v315 = v294 == v314;
        if (v315){
            ap_uint<4l> v316; ap_uint<2l> v317;
            Tuple18 tmp76 = v85[0l];
            v316 = tmp76.v0; v317 = tmp76.v1;
            ap_uint<4l> v318;
            v318 = 12ul;
            bool v319;
            v319 = v316 == v318;
            if (v319){
                v290[4l] = TupleCreate18(v316, v317);
                v322 = true;
            } else {
                v322 = false;
            }
        } else {
            v322 = false;
        }
    } else {
        v322 = false;
    }
    US6 v328;
    if (v322){
        v328 = US6_1(v290);
    } else {
        bool v324;
        v324 = v293 == 5l;
        if (v324){
            v328 = US6_1(v290);
        } else {
            v328 = US6_0();
        }
    }
    std::array<Tuple18,5l> v329;
    int32_t v330; int32_t v331;
    Tuple24 tmp77 = TupleCreate24(0l, 0l);
    v330 = tmp77.v0; v331 = tmp77.v1;
    while (while_method_9(v330)){
        ap_uint<4l> v333; ap_uint<2l> v334;
        Tuple18 tmp78 = v85[v330];
        v333 = tmp78.v0; v334 = tmp78.v1;
        ap_uint<2l> v335;
        v335 = 3ul;
        bool v336;
        v336 = v334 == v335;
        bool v338;
        if (v336){
            bool v337;
            v337 = v331 < 5l;
            v338 = v337;
        } else {
            v338 = false;
        }
        int32_t v340;
        if (v338){
            v329[v331] = TupleCreate18(v333, v334);
            int32_t v339;
            v339 = v331 + 1l;
            v340 = v339;
        } else {
            v340 = v331;
        }
        v331 = v340;
        v330++;
    }
    bool v341;
    v341 = v331 == 5l;
    US6 v344;
    if (v341){
        v344 = US6_1(v329);
    } else {
        v344 = US6_0();
    }
    std::array<Tuple18,5l> v345;
    int32_t v346; int32_t v347;
    Tuple24 tmp79 = TupleCreate24(0l, 0l);
    v346 = tmp79.v0; v347 = tmp79.v1;
    while (while_method_9(v346)){
        ap_uint<4l> v349; ap_uint<2l> v350;
        Tuple18 tmp80 = v85[v346];
        v349 = tmp80.v0; v350 = tmp80.v1;
        ap_uint<2l> v351;
        v351 = 2ul;
        bool v352;
        v352 = v350 == v351;
        bool v354;
        if (v352){
            bool v353;
            v353 = v347 < 5l;
            v354 = v353;
        } else {
            v354 = false;
        }
        int32_t v356;
        if (v354){
            v345[v347] = TupleCreate18(v349, v350);
            int32_t v355;
            v355 = v347 + 1l;
            v356 = v355;
        } else {
            v356 = v347;
        }
        v347 = v356;
        v346++;
    }
    bool v357;
    v357 = v347 == 5l;
    US6 v360;
    if (v357){
        v360 = US6_1(v345);
    } else {
        v360 = US6_0();
    }
    std::array<Tuple18,5l> v361;
    int32_t v362; int32_t v363;
    Tuple24 tmp81 = TupleCreate24(0l, 0l);
    v362 = tmp81.v0; v363 = tmp81.v1;
    while (while_method_9(v362)){
        ap_uint<4l> v365; ap_uint<2l> v366;
        Tuple18 tmp82 = v85[v362];
        v365 = tmp82.v0; v366 = tmp82.v1;
        ap_uint<2l> v367;
        v367 = 1ul;
        bool v368;
        v368 = v366 == v367;
        bool v370;
        if (v368){
            bool v369;
            v369 = v363 < 5l;
            v370 = v369;
        } else {
            v370 = false;
        }
        int32_t v372;
        if (v370){
            v361[v363] = TupleCreate18(v365, v366);
            int32_t v371;
            v371 = v363 + 1l;
            v372 = v371;
        } else {
            v372 = v363;
        }
        v363 = v372;
        v362++;
    }
    bool v373;
    v373 = v363 == 5l;
    US6 v376;
    if (v373){
        v376 = US6_1(v361);
    } else {
        v376 = US6_0();
    }
    std::array<Tuple18,5l> v377;
    int32_t v378; int32_t v379;
    Tuple24 tmp83 = TupleCreate24(0l, 0l);
    v378 = tmp83.v0; v379 = tmp83.v1;
    while (while_method_9(v378)){
        ap_uint<4l> v381; ap_uint<2l> v382;
        Tuple18 tmp84 = v85[v378];
        v381 = tmp84.v0; v382 = tmp84.v1;
        ap_uint<2l> v383;
        v383 = 0ul;
        bool v384;
        v384 = v382 == v383;
        bool v386;
        if (v384){
            bool v385;
            v385 = v379 < 5l;
            v386 = v385;
        } else {
            v386 = false;
        }
        int32_t v388;
        if (v386){
            v377[v379] = TupleCreate18(v381, v382);
            int32_t v387;
            v387 = v379 + 1l;
            v388 = v387;
        } else {
            v388 = v379;
        }
        v379 = v388;
        v378++;
    }
    bool v389;
    v389 = v379 == 5l;
    US6 v392;
    if (v389){
        v392 = US6_1(v377);
    } else {
        v392 = US6_0();
    }
    US6 v417;
    switch (v392.tag) {
        case 0: { // None
            v417 = v376;
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v393 = v392.v.case1.v0;
            switch (v376.tag) {
                case 0: { // None
                    v417 = v392;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v394 = v376.v.case1.v0;
                    US4 v395;
                    v395 = US4_0();
                    int32_t v396; US4 v397;
                    Tuple25 tmp85 = TupleCreate25(0l, v395);
                    v396 = tmp85.v0; v397 = tmp85.v1;
                    while (while_method_13(v396)){
                        ap_uint<4l> v399; ap_uint<2l> v400;
                        Tuple18 tmp86 = v393[v396];
                        v399 = tmp86.v0; v400 = tmp86.v1;
                        ap_uint<4l> v401; ap_uint<2l> v402;
                        Tuple18 tmp87 = v394[v396];
                        v401 = tmp87.v0; v402 = tmp87.v1;
                        US4 v410;
                        switch (v397.tag) {
                            case 0: { // Eq
                                bool v403;
                                v403 = v399 > v401;
                                if (v403){
                                    v410 = US4_1();
                                } else {
                                    bool v405;
                                    v405 = v399 < v401;
                                    if (v405){
                                        v410 = US4_2();
                                    } else {
                                        v410 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v410 = v397;
                            }
                        }
                        v397 = v410;
                        v396++;
                    }
                    bool v411;
                    switch (v397.tag) {
                        case 1: { // Gt
                            v411 = true;
                            break;
                        }
                        default: {
                            v411 = false;
                        }
                    }
                    std::array<Tuple18,5l> v412;
                    if (v411){
                        v412 = v393;
                    } else {
                        v412 = v394;
                    }
                    v417 = US6_1(v412);
                }
            }
        }
    }
    US6 v442;
    switch (v417.tag) {
        case 0: { // None
            v442 = v360;
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v418 = v417.v.case1.v0;
            switch (v360.tag) {
                case 0: { // None
                    v442 = v417;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v419 = v360.v.case1.v0;
                    US4 v420;
                    v420 = US4_0();
                    int32_t v421; US4 v422;
                    Tuple25 tmp88 = TupleCreate25(0l, v420);
                    v421 = tmp88.v0; v422 = tmp88.v1;
                    while (while_method_13(v421)){
                        ap_uint<4l> v424; ap_uint<2l> v425;
                        Tuple18 tmp89 = v418[v421];
                        v424 = tmp89.v0; v425 = tmp89.v1;
                        ap_uint<4l> v426; ap_uint<2l> v427;
                        Tuple18 tmp90 = v419[v421];
                        v426 = tmp90.v0; v427 = tmp90.v1;
                        US4 v435;
                        switch (v422.tag) {
                            case 0: { // Eq
                                bool v428;
                                v428 = v424 > v426;
                                if (v428){
                                    v435 = US4_1();
                                } else {
                                    bool v430;
                                    v430 = v424 < v426;
                                    if (v430){
                                        v435 = US4_2();
                                    } else {
                                        v435 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v435 = v422;
                            }
                        }
                        v422 = v435;
                        v421++;
                    }
                    bool v436;
                    switch (v422.tag) {
                        case 1: { // Gt
                            v436 = true;
                            break;
                        }
                        default: {
                            v436 = false;
                        }
                    }
                    std::array<Tuple18,5l> v437;
                    if (v436){
                        v437 = v418;
                    } else {
                        v437 = v419;
                    }
                    v442 = US6_1(v437);
                }
            }
        }
    }
    US6 v467;
    switch (v442.tag) {
        case 0: { // None
            v467 = v344;
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v443 = v442.v.case1.v0;
            switch (v344.tag) {
                case 0: { // None
                    v467 = v442;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v444 = v344.v.case1.v0;
                    US4 v445;
                    v445 = US4_0();
                    int32_t v446; US4 v447;
                    Tuple25 tmp91 = TupleCreate25(0l, v445);
                    v446 = tmp91.v0; v447 = tmp91.v1;
                    while (while_method_13(v446)){
                        ap_uint<4l> v449; ap_uint<2l> v450;
                        Tuple18 tmp92 = v443[v446];
                        v449 = tmp92.v0; v450 = tmp92.v1;
                        ap_uint<4l> v451; ap_uint<2l> v452;
                        Tuple18 tmp93 = v444[v446];
                        v451 = tmp93.v0; v452 = tmp93.v1;
                        US4 v460;
                        switch (v447.tag) {
                            case 0: { // Eq
                                bool v453;
                                v453 = v449 > v451;
                                if (v453){
                                    v460 = US4_1();
                                } else {
                                    bool v455;
                                    v455 = v449 < v451;
                                    if (v455){
                                        v460 = US4_2();
                                    } else {
                                        v460 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v460 = v447;
                            }
                        }
                        v447 = v460;
                        v446++;
                    }
                    bool v461;
                    switch (v447.tag) {
                        case 1: { // Gt
                            v461 = true;
                            break;
                        }
                        default: {
                            v461 = false;
                        }
                    }
                    std::array<Tuple18,5l> v462;
                    if (v461){
                        v462 = v443;
                    } else {
                        v462 = v444;
                    }
                    v467 = US6_1(v462);
                }
            }
        }
    }
    std::array<Tuple18,3l> v468;
    std::array<Tuple18,4l> v469;
    ap_uint<4l> v470;
    v470 = 12ul;
    int32_t v471; int32_t v472; int32_t v473; ap_uint<4l> v474;
    Tuple22 tmp94 = TupleCreate22(0l, 0l, 0l, v470);
    v471 = tmp94.v0; v472 = tmp94.v1; v473 = tmp94.v2; v474 = tmp94.v3;
    while (while_method_9(v471)){
        ap_uint<4l> v476; ap_uint<2l> v477;
        Tuple18 tmp95 = v85[v471];
        v476 = tmp95.v0; v477 = tmp95.v1;
        bool v478;
        v478 = v473 < 3l;
        int32_t v482; int32_t v483; ap_uint<4l> v484;
        if (v478){
            bool v479;
            v479 = v474 == v476;
            int32_t v480;
            if (v479){
                v480 = v473;
            } else {
                v480 = 0l;
            }
            v468[v480] = TupleCreate18(v476, v477);
            int32_t v481;
            v481 = v480 + 1l;
            v482 = v471; v483 = v481; v484 = v476;
        } else {
            v482 = v472; v483 = v473; v484 = v474;
        }
        v472 = v482;
        v473 = v483;
        v474 = v484;
        v471++;
    }
    bool v485;
    v485 = v473 == 3l;
    US8 v498;
    if (v485){
        int32_t v486;
        v486 = 0l;
        while (while_method_16(v486)){
            int32_t v488;
            v488 = v472 + 1l;
            int32_t v489;
            v489 = v488 - 3l;
            bool v490;
            v490 = v486 < v489;
            if (v490){
                ap_uint<4l> v491; ap_uint<2l> v492;
                Tuple18 tmp96 = v85[v486];
                v491 = tmp96.v0; v492 = tmp96.v1;
                v469[v486] = TupleCreate18(v491, v492);
            } else {
                int32_t v493;
                v493 = 3l + v486;
                ap_uint<4l> v494; ap_uint<2l> v495;
                Tuple18 tmp97 = v85[v493];
                v494 = tmp97.v0; v495 = tmp97.v1;
                v469[v486] = TupleCreate18(v494, v495);
            }
            v486++;
        }
        v498 = US8_1(v468, v469);
    } else {
        v498 = US8_0();
    }
    US6 v551;
    switch (v498.tag) {
        case 0: { // None
            v551 = US6_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,3l> v499 = v498.v.case1.v0; std::array<Tuple18,4l> v500 = v498.v.case1.v1;
            std::array<Tuple18,2l> v501;
            std::array<Tuple18,2l> v502;
            ap_uint<4l> v503;
            v503 = 12ul;
            int32_t v504; int32_t v505; int32_t v506; ap_uint<4l> v507;
            Tuple22 tmp98 = TupleCreate22(0l, 0l, 0l, v503);
            v504 = tmp98.v0; v505 = tmp98.v1; v506 = tmp98.v2; v507 = tmp98.v3;
            while (while_method_16(v504)){
                ap_uint<4l> v509; ap_uint<2l> v510;
                Tuple18 tmp99 = v500[v504];
                v509 = tmp99.v0; v510 = tmp99.v1;
                bool v511;
                v511 = v506 < 2l;
                int32_t v515; int32_t v516; ap_uint<4l> v517;
                if (v511){
                    bool v512;
                    v512 = v507 == v509;
                    int32_t v513;
                    if (v512){
                        v513 = v506;
                    } else {
                        v513 = 0l;
                    }
                    v501[v513] = TupleCreate18(v509, v510);
                    int32_t v514;
                    v514 = v513 + 1l;
                    v515 = v504; v516 = v514; v517 = v509;
                } else {
                    v515 = v505; v516 = v506; v517 = v507;
                }
                v505 = v515;
                v506 = v516;
                v507 = v517;
                v504++;
            }
            bool v518;
            v518 = v506 == 2l;
            US9 v531;
            if (v518){
                int32_t v519;
                v519 = 0l;
                while (while_method_15(v519)){
                    int32_t v521;
                    v521 = v505 + 1l;
                    int32_t v522;
                    v522 = v521 - 2l;
                    bool v523;
                    v523 = v519 < v522;
                    if (v523){
                        ap_uint<4l> v524; ap_uint<2l> v525;
                        Tuple18 tmp100 = v500[v519];
                        v524 = tmp100.v0; v525 = tmp100.v1;
                        v502[v519] = TupleCreate18(v524, v525);
                    } else {
                        int32_t v526;
                        v526 = 2l + v519;
                        ap_uint<4l> v527; ap_uint<2l> v528;
                        Tuple18 tmp101 = v500[v526];
                        v527 = tmp101.v0; v528 = tmp101.v1;
                        v502[v519] = TupleCreate18(v527, v528);
                    }
                    v519++;
                }
                v531 = US9_1(v501, v502);
            } else {
                v531 = US9_0();
            }
            switch (v531.tag) {
                case 0: { // None
                    v551 = US6_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple18,2l> v532 = v531.v.case1.v0; std::array<Tuple18,2l> v533 = v531.v.case1.v1;
                    std::array<Tuple18,0l> v534;
                    std::array<Tuple18,5l> v535;
                    int32_t v536;
                    v536 = 0l;
                    while (while_method_14(v536)){
                        ap_uint<4l> v538; ap_uint<2l> v539;
                        Tuple18 tmp102 = v499[v536];
                        v538 = tmp102.v0; v539 = tmp102.v1;
                        v535[v536] = TupleCreate18(v538, v539);
                        v536++;
                    }
                    int32_t v540;
                    v540 = 0l;
                    while (while_method_15(v540)){
                        ap_uint<4l> v542; ap_uint<2l> v543;
                        Tuple18 tmp103 = v532[v540];
                        v542 = tmp103.v0; v543 = tmp103.v1;
                        int32_t v544;
                        v544 = 3l + v540;
                        v535[v544] = TupleCreate18(v542, v543);
                        v540++;
                    }
                    v551 = US6_1(v535);
                }
            }
        }
    }
    std::array<Tuple18,4l> v552;
    std::array<Tuple18,3l> v553;
    ap_uint<4l> v554;
    v554 = 12ul;
    int32_t v555; int32_t v556; int32_t v557; ap_uint<4l> v558;
    Tuple22 tmp104 = TupleCreate22(0l, 0l, 0l, v554);
    v555 = tmp104.v0; v556 = tmp104.v1; v557 = tmp104.v2; v558 = tmp104.v3;
    while (while_method_9(v555)){
        ap_uint<4l> v560; ap_uint<2l> v561;
        Tuple18 tmp105 = v85[v555];
        v560 = tmp105.v0; v561 = tmp105.v1;
        bool v562;
        v562 = v557 < 4l;
        int32_t v566; int32_t v567; ap_uint<4l> v568;
        if (v562){
            bool v563;
            v563 = v558 == v560;
            int32_t v564;
            if (v563){
                v564 = v557;
            } else {
                v564 = 0l;
            }
            v552[v564] = TupleCreate18(v560, v561);
            int32_t v565;
            v565 = v564 + 1l;
            v566 = v555; v567 = v565; v568 = v560;
        } else {
            v566 = v556; v567 = v557; v568 = v558;
        }
        v556 = v566;
        v557 = v567;
        v558 = v568;
        v555++;
    }
    bool v569;
    v569 = v557 == 4l;
    US10 v582;
    if (v569){
        int32_t v570;
        v570 = 0l;
        while (while_method_14(v570)){
            int32_t v572;
            v572 = v556 + 1l;
            int32_t v573;
            v573 = v572 - 4l;
            bool v574;
            v574 = v570 < v573;
            if (v574){
                ap_uint<4l> v575; ap_uint<2l> v576;
                Tuple18 tmp106 = v85[v570];
                v575 = tmp106.v0; v576 = tmp106.v1;
                v553[v570] = TupleCreate18(v575, v576);
            } else {
                int32_t v577;
                v577 = 4l + v570;
                ap_uint<4l> v578; ap_uint<2l> v579;
                Tuple18 tmp107 = v85[v577];
                v578 = tmp107.v0; v579 = tmp107.v1;
                v553[v570] = TupleCreate18(v578, v579);
            }
            v570++;
        }
        v582 = US10_1(v552, v553);
    } else {
        v582 = US10_0();
    }
    US6 v604;
    switch (v582.tag) {
        case 0: { // None
            v604 = US6_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,4l> v583 = v582.v.case1.v0; std::array<Tuple18,3l> v584 = v582.v.case1.v1;
            std::array<Tuple18,1l> v585;
            int32_t v586;
            v586 = 0l;
            while (while_method_8(v586)){
                ap_uint<4l> v588; ap_uint<2l> v589;
                Tuple18 tmp108 = v584[v586];
                v588 = tmp108.v0; v589 = tmp108.v1;
                v585[v586] = TupleCreate18(v588, v589);
                v586++;
            }
            std::array<Tuple18,0l> v590;
            std::array<Tuple18,5l> v591;
            int32_t v592;
            v592 = 0l;
            while (while_method_16(v592)){
                ap_uint<4l> v594; ap_uint<2l> v595;
                Tuple18 tmp109 = v583[v592];
                v594 = tmp109.v0; v595 = tmp109.v1;
                v591[v592] = TupleCreate18(v594, v595);
                v592++;
            }
            int32_t v596;
            v596 = 0l;
            while (while_method_8(v596)){
                ap_uint<4l> v598; ap_uint<2l> v599;
                Tuple18 tmp110 = v585[v596];
                v598 = tmp110.v0; v599 = tmp110.v1;
                int32_t v600;
                v600 = 4l + v596;
                v591[v600] = TupleCreate18(v598, v599);
                v596++;
            }
            v604 = US6_1(v591);
        }
    }
    ap_uint<2l> v605;
    v605 = 3ul;
    std::array<Tuple18,5l> v606;
    ap_uint<4l> v607;
    v607 = 12ul;
    int32_t v608; int32_t v609; ap_uint<4l> v610;
    Tuple23 tmp111 = TupleCreate23(0l, 0l, v607);
    v608 = tmp111.v0; v609 = tmp111.v1; v610 = tmp111.v2;
    while (while_method_9(v608)){
        ap_uint<4l> v612; ap_uint<2l> v613;
        Tuple18 tmp112 = v85[v608];
        v612 = tmp112.v0; v613 = tmp112.v1;
        bool v614;
        v614 = v609 < 5l;
        bool v616;
        if (v614){
            bool v615;
            v615 = v605 == v613;
            v616 = v615;
        } else {
            v616 = false;
        }
        int32_t v622; ap_uint<4l> v623;
        if (v616){
            bool v617;
            v617 = v610 == v612;
            int32_t v618;
            if (v617){
                v618 = v609;
            } else {
                v618 = 0l;
            }
            v606[v618] = TupleCreate18(v612, v613);
            int32_t v619;
            v619 = v618 + 1l;
            ap_uint<4l> v620;
            v620 = 1ul;
            ap_uint<4l> v621;
            v621 = v612 - v620;
            v622 = v619; v623 = v621;
        } else {
            v622 = v609; v623 = v610;
        }
        v609 = v622;
        v610 = v623;
        v608++;
    }
    bool v624;
    v624 = v609 == 4l;
    bool v661;
    if (v624){
        ap_uint<4l> v625;
        v625 = 0ul;
        ap_uint<4l> v626;
        v626 = 1ul;
        ap_uint<4l> v627;
        v627 = v625 - v626;
        bool v628;
        v628 = v610 == v627;
        if (v628){
            ap_uint<4l> v629; ap_uint<2l> v630;
            Tuple18 tmp113 = v85[0l];
            v629 = tmp113.v0; v630 = tmp113.v1;
            bool v631;
            v631 = v605 == v630;
            bool v635;
            if (v631){
                ap_uint<4l> v632;
                v632 = 12ul;
                bool v633;
                v633 = v629 == v632;
                if (v633){
                    v606[4l] = TupleCreate18(v629, v630);
                    v635 = true;
                } else {
                    v635 = false;
                }
            } else {
                v635 = false;
            }
            if (v635){
                v661 = true;
            } else {
                ap_uint<4l> v636; ap_uint<2l> v637;
                Tuple18 tmp114 = v85[1l];
                v636 = tmp114.v0; v637 = tmp114.v1;
                bool v638;
                v638 = v605 == v637;
                bool v642;
                if (v638){
                    ap_uint<4l> v639;
                    v639 = 12ul;
                    bool v640;
                    v640 = v636 == v639;
                    if (v640){
                        v606[4l] = TupleCreate18(v636, v637);
                        v642 = true;
                    } else {
                        v642 = false;
                    }
                } else {
                    v642 = false;
                }
                if (v642){
                    v661 = true;
                } else {
                    ap_uint<4l> v643; ap_uint<2l> v644;
                    Tuple18 tmp115 = v85[2l];
                    v643 = tmp115.v0; v644 = tmp115.v1;
                    bool v645;
                    v645 = v605 == v644;
                    bool v649;
                    if (v645){
                        ap_uint<4l> v646;
                        v646 = 12ul;
                        bool v647;
                        v647 = v643 == v646;
                        if (v647){
                            v606[4l] = TupleCreate18(v643, v644);
                            v649 = true;
                        } else {
                            v649 = false;
                        }
                    } else {
                        v649 = false;
                    }
                    if (v649){
                        v661 = true;
                    } else {
                        ap_uint<4l> v650; ap_uint<2l> v651;
                        Tuple18 tmp116 = v85[3l];
                        v650 = tmp116.v0; v651 = tmp116.v1;
                        bool v652;
                        v652 = v605 == v651;
                        if (v652){
                            ap_uint<4l> v653;
                            v653 = 12ul;
                            bool v654;
                            v654 = v650 == v653;
                            if (v654){
                                v606[4l] = TupleCreate18(v650, v651);
                                v661 = true;
                            } else {
                                v661 = false;
                            }
                        } else {
                            v661 = false;
                        }
                    }
                }
            }
        } else {
            v661 = false;
        }
    } else {
        v661 = false;
    }
    US6 v667;
    if (v661){
        v667 = US6_1(v606);
    } else {
        bool v663;
        v663 = v609 == 5l;
        if (v663){
            v667 = US6_1(v606);
        } else {
            v667 = US6_0();
        }
    }
    ap_uint<2l> v668;
    v668 = 2ul;
    std::array<Tuple18,5l> v669;
    ap_uint<4l> v670;
    v670 = 12ul;
    int32_t v671; int32_t v672; ap_uint<4l> v673;
    Tuple23 tmp117 = TupleCreate23(0l, 0l, v670);
    v671 = tmp117.v0; v672 = tmp117.v1; v673 = tmp117.v2;
    while (while_method_9(v671)){
        ap_uint<4l> v675; ap_uint<2l> v676;
        Tuple18 tmp118 = v85[v671];
        v675 = tmp118.v0; v676 = tmp118.v1;
        bool v677;
        v677 = v672 < 5l;
        bool v679;
        if (v677){
            bool v678;
            v678 = v668 == v676;
            v679 = v678;
        } else {
            v679 = false;
        }
        int32_t v685; ap_uint<4l> v686;
        if (v679){
            bool v680;
            v680 = v673 == v675;
            int32_t v681;
            if (v680){
                v681 = v672;
            } else {
                v681 = 0l;
            }
            v669[v681] = TupleCreate18(v675, v676);
            int32_t v682;
            v682 = v681 + 1l;
            ap_uint<4l> v683;
            v683 = 1ul;
            ap_uint<4l> v684;
            v684 = v675 - v683;
            v685 = v682; v686 = v684;
        } else {
            v685 = v672; v686 = v673;
        }
        v672 = v685;
        v673 = v686;
        v671++;
    }
    bool v687;
    v687 = v672 == 4l;
    bool v724;
    if (v687){
        ap_uint<4l> v688;
        v688 = 0ul;
        ap_uint<4l> v689;
        v689 = 1ul;
        ap_uint<4l> v690;
        v690 = v688 - v689;
        bool v691;
        v691 = v673 == v690;
        if (v691){
            ap_uint<4l> v692; ap_uint<2l> v693;
            Tuple18 tmp119 = v85[0l];
            v692 = tmp119.v0; v693 = tmp119.v1;
            bool v694;
            v694 = v668 == v693;
            bool v698;
            if (v694){
                ap_uint<4l> v695;
                v695 = 12ul;
                bool v696;
                v696 = v692 == v695;
                if (v696){
                    v669[4l] = TupleCreate18(v692, v693);
                    v698 = true;
                } else {
                    v698 = false;
                }
            } else {
                v698 = false;
            }
            if (v698){
                v724 = true;
            } else {
                ap_uint<4l> v699; ap_uint<2l> v700;
                Tuple18 tmp120 = v85[1l];
                v699 = tmp120.v0; v700 = tmp120.v1;
                bool v701;
                v701 = v668 == v700;
                bool v705;
                if (v701){
                    ap_uint<4l> v702;
                    v702 = 12ul;
                    bool v703;
                    v703 = v699 == v702;
                    if (v703){
                        v669[4l] = TupleCreate18(v699, v700);
                        v705 = true;
                    } else {
                        v705 = false;
                    }
                } else {
                    v705 = false;
                }
                if (v705){
                    v724 = true;
                } else {
                    ap_uint<4l> v706; ap_uint<2l> v707;
                    Tuple18 tmp121 = v85[2l];
                    v706 = tmp121.v0; v707 = tmp121.v1;
                    bool v708;
                    v708 = v668 == v707;
                    bool v712;
                    if (v708){
                        ap_uint<4l> v709;
                        v709 = 12ul;
                        bool v710;
                        v710 = v706 == v709;
                        if (v710){
                            v669[4l] = TupleCreate18(v706, v707);
                            v712 = true;
                        } else {
                            v712 = false;
                        }
                    } else {
                        v712 = false;
                    }
                    if (v712){
                        v724 = true;
                    } else {
                        ap_uint<4l> v713; ap_uint<2l> v714;
                        Tuple18 tmp122 = v85[3l];
                        v713 = tmp122.v0; v714 = tmp122.v1;
                        bool v715;
                        v715 = v668 == v714;
                        if (v715){
                            ap_uint<4l> v716;
                            v716 = 12ul;
                            bool v717;
                            v717 = v713 == v716;
                            if (v717){
                                v669[4l] = TupleCreate18(v713, v714);
                                v724 = true;
                            } else {
                                v724 = false;
                            }
                        } else {
                            v724 = false;
                        }
                    }
                }
            }
        } else {
            v724 = false;
        }
    } else {
        v724 = false;
    }
    US6 v730;
    if (v724){
        v730 = US6_1(v669);
    } else {
        bool v726;
        v726 = v672 == 5l;
        if (v726){
            v730 = US6_1(v669);
        } else {
            v730 = US6_0();
        }
    }
    ap_uint<2l> v731;
    v731 = 1ul;
    std::array<Tuple18,5l> v732;
    ap_uint<4l> v733;
    v733 = 12ul;
    int32_t v734; int32_t v735; ap_uint<4l> v736;
    Tuple23 tmp123 = TupleCreate23(0l, 0l, v733);
    v734 = tmp123.v0; v735 = tmp123.v1; v736 = tmp123.v2;
    while (while_method_9(v734)){
        ap_uint<4l> v738; ap_uint<2l> v739;
        Tuple18 tmp124 = v85[v734];
        v738 = tmp124.v0; v739 = tmp124.v1;
        bool v740;
        v740 = v735 < 5l;
        bool v742;
        if (v740){
            bool v741;
            v741 = v731 == v739;
            v742 = v741;
        } else {
            v742 = false;
        }
        int32_t v748; ap_uint<4l> v749;
        if (v742){
            bool v743;
            v743 = v736 == v738;
            int32_t v744;
            if (v743){
                v744 = v735;
            } else {
                v744 = 0l;
            }
            v732[v744] = TupleCreate18(v738, v739);
            int32_t v745;
            v745 = v744 + 1l;
            ap_uint<4l> v746;
            v746 = 1ul;
            ap_uint<4l> v747;
            v747 = v738 - v746;
            v748 = v745; v749 = v747;
        } else {
            v748 = v735; v749 = v736;
        }
        v735 = v748;
        v736 = v749;
        v734++;
    }
    bool v750;
    v750 = v735 == 4l;
    bool v787;
    if (v750){
        ap_uint<4l> v751;
        v751 = 0ul;
        ap_uint<4l> v752;
        v752 = 1ul;
        ap_uint<4l> v753;
        v753 = v751 - v752;
        bool v754;
        v754 = v736 == v753;
        if (v754){
            ap_uint<4l> v755; ap_uint<2l> v756;
            Tuple18 tmp125 = v85[0l];
            v755 = tmp125.v0; v756 = tmp125.v1;
            bool v757;
            v757 = v731 == v756;
            bool v761;
            if (v757){
                ap_uint<4l> v758;
                v758 = 12ul;
                bool v759;
                v759 = v755 == v758;
                if (v759){
                    v732[4l] = TupleCreate18(v755, v756);
                    v761 = true;
                } else {
                    v761 = false;
                }
            } else {
                v761 = false;
            }
            if (v761){
                v787 = true;
            } else {
                ap_uint<4l> v762; ap_uint<2l> v763;
                Tuple18 tmp126 = v85[1l];
                v762 = tmp126.v0; v763 = tmp126.v1;
                bool v764;
                v764 = v731 == v763;
                bool v768;
                if (v764){
                    ap_uint<4l> v765;
                    v765 = 12ul;
                    bool v766;
                    v766 = v762 == v765;
                    if (v766){
                        v732[4l] = TupleCreate18(v762, v763);
                        v768 = true;
                    } else {
                        v768 = false;
                    }
                } else {
                    v768 = false;
                }
                if (v768){
                    v787 = true;
                } else {
                    ap_uint<4l> v769; ap_uint<2l> v770;
                    Tuple18 tmp127 = v85[2l];
                    v769 = tmp127.v0; v770 = tmp127.v1;
                    bool v771;
                    v771 = v731 == v770;
                    bool v775;
                    if (v771){
                        ap_uint<4l> v772;
                        v772 = 12ul;
                        bool v773;
                        v773 = v769 == v772;
                        if (v773){
                            v732[4l] = TupleCreate18(v769, v770);
                            v775 = true;
                        } else {
                            v775 = false;
                        }
                    } else {
                        v775 = false;
                    }
                    if (v775){
                        v787 = true;
                    } else {
                        ap_uint<4l> v776; ap_uint<2l> v777;
                        Tuple18 tmp128 = v85[3l];
                        v776 = tmp128.v0; v777 = tmp128.v1;
                        bool v778;
                        v778 = v731 == v777;
                        if (v778){
                            ap_uint<4l> v779;
                            v779 = 12ul;
                            bool v780;
                            v780 = v776 == v779;
                            if (v780){
                                v732[4l] = TupleCreate18(v776, v777);
                                v787 = true;
                            } else {
                                v787 = false;
                            }
                        } else {
                            v787 = false;
                        }
                    }
                }
            }
        } else {
            v787 = false;
        }
    } else {
        v787 = false;
    }
    US6 v793;
    if (v787){
        v793 = US6_1(v732);
    } else {
        bool v789;
        v789 = v735 == 5l;
        if (v789){
            v793 = US6_1(v732);
        } else {
            v793 = US6_0();
        }
    }
    ap_uint<2l> v794;
    v794 = 0ul;
    std::array<Tuple18,5l> v795;
    ap_uint<4l> v796;
    v796 = 12ul;
    int32_t v797; int32_t v798; ap_uint<4l> v799;
    Tuple23 tmp129 = TupleCreate23(0l, 0l, v796);
    v797 = tmp129.v0; v798 = tmp129.v1; v799 = tmp129.v2;
    while (while_method_9(v797)){
        ap_uint<4l> v801; ap_uint<2l> v802;
        Tuple18 tmp130 = v85[v797];
        v801 = tmp130.v0; v802 = tmp130.v1;
        bool v803;
        v803 = v798 < 5l;
        bool v805;
        if (v803){
            bool v804;
            v804 = v794 == v802;
            v805 = v804;
        } else {
            v805 = false;
        }
        int32_t v811; ap_uint<4l> v812;
        if (v805){
            bool v806;
            v806 = v799 == v801;
            int32_t v807;
            if (v806){
                v807 = v798;
            } else {
                v807 = 0l;
            }
            v795[v807] = TupleCreate18(v801, v802);
            int32_t v808;
            v808 = v807 + 1l;
            ap_uint<4l> v809;
            v809 = 1ul;
            ap_uint<4l> v810;
            v810 = v801 - v809;
            v811 = v808; v812 = v810;
        } else {
            v811 = v798; v812 = v799;
        }
        v798 = v811;
        v799 = v812;
        v797++;
    }
    bool v813;
    v813 = v798 == 4l;
    bool v850;
    if (v813){
        ap_uint<4l> v814;
        v814 = 0ul;
        ap_uint<4l> v815;
        v815 = 1ul;
        ap_uint<4l> v816;
        v816 = v814 - v815;
        bool v817;
        v817 = v799 == v816;
        if (v817){
            ap_uint<4l> v818; ap_uint<2l> v819;
            Tuple18 tmp131 = v85[0l];
            v818 = tmp131.v0; v819 = tmp131.v1;
            bool v820;
            v820 = v794 == v819;
            bool v824;
            if (v820){
                ap_uint<4l> v821;
                v821 = 12ul;
                bool v822;
                v822 = v818 == v821;
                if (v822){
                    v795[4l] = TupleCreate18(v818, v819);
                    v824 = true;
                } else {
                    v824 = false;
                }
            } else {
                v824 = false;
            }
            if (v824){
                v850 = true;
            } else {
                ap_uint<4l> v825; ap_uint<2l> v826;
                Tuple18 tmp132 = v85[1l];
                v825 = tmp132.v0; v826 = tmp132.v1;
                bool v827;
                v827 = v794 == v826;
                bool v831;
                if (v827){
                    ap_uint<4l> v828;
                    v828 = 12ul;
                    bool v829;
                    v829 = v825 == v828;
                    if (v829){
                        v795[4l] = TupleCreate18(v825, v826);
                        v831 = true;
                    } else {
                        v831 = false;
                    }
                } else {
                    v831 = false;
                }
                if (v831){
                    v850 = true;
                } else {
                    ap_uint<4l> v832; ap_uint<2l> v833;
                    Tuple18 tmp133 = v85[2l];
                    v832 = tmp133.v0; v833 = tmp133.v1;
                    bool v834;
                    v834 = v794 == v833;
                    bool v838;
                    if (v834){
                        ap_uint<4l> v835;
                        v835 = 12ul;
                        bool v836;
                        v836 = v832 == v835;
                        if (v836){
                            v795[4l] = TupleCreate18(v832, v833);
                            v838 = true;
                        } else {
                            v838 = false;
                        }
                    } else {
                        v838 = false;
                    }
                    if (v838){
                        v850 = true;
                    } else {
                        ap_uint<4l> v839; ap_uint<2l> v840;
                        Tuple18 tmp134 = v85[3l];
                        v839 = tmp134.v0; v840 = tmp134.v1;
                        bool v841;
                        v841 = v794 == v840;
                        if (v841){
                            ap_uint<4l> v842;
                            v842 = 12ul;
                            bool v843;
                            v843 = v839 == v842;
                            if (v843){
                                v795[4l] = TupleCreate18(v839, v840);
                                v850 = true;
                            } else {
                                v850 = false;
                            }
                        } else {
                            v850 = false;
                        }
                    }
                }
            }
        } else {
            v850 = false;
        }
    } else {
        v850 = false;
    }
    US6 v856;
    if (v850){
        v856 = US6_1(v795);
    } else {
        bool v852;
        v852 = v798 == 5l;
        if (v852){
            v856 = US6_1(v795);
        } else {
            v856 = US6_0();
        }
    }
    US6 v881;
    switch (v856.tag) {
        case 0: { // None
            v881 = v793;
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v857 = v856.v.case1.v0;
            switch (v793.tag) {
                case 0: { // None
                    v881 = v856;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v858 = v793.v.case1.v0;
                    US4 v859;
                    v859 = US4_0();
                    int32_t v860; US4 v861;
                    Tuple25 tmp135 = TupleCreate25(0l, v859);
                    v860 = tmp135.v0; v861 = tmp135.v1;
                    while (while_method_13(v860)){
                        ap_uint<4l> v863; ap_uint<2l> v864;
                        Tuple18 tmp136 = v857[v860];
                        v863 = tmp136.v0; v864 = tmp136.v1;
                        ap_uint<4l> v865; ap_uint<2l> v866;
                        Tuple18 tmp137 = v858[v860];
                        v865 = tmp137.v0; v866 = tmp137.v1;
                        US4 v874;
                        switch (v861.tag) {
                            case 0: { // Eq
                                bool v867;
                                v867 = v863 > v865;
                                if (v867){
                                    v874 = US4_1();
                                } else {
                                    bool v869;
                                    v869 = v863 < v865;
                                    if (v869){
                                        v874 = US4_2();
                                    } else {
                                        v874 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v874 = v861;
                            }
                        }
                        v861 = v874;
                        v860++;
                    }
                    bool v875;
                    switch (v861.tag) {
                        case 1: { // Gt
                            v875 = true;
                            break;
                        }
                        default: {
                            v875 = false;
                        }
                    }
                    std::array<Tuple18,5l> v876;
                    if (v875){
                        v876 = v857;
                    } else {
                        v876 = v858;
                    }
                    v881 = US6_1(v876);
                }
            }
        }
    }
    US6 v906;
    switch (v881.tag) {
        case 0: { // None
            v906 = v730;
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v882 = v881.v.case1.v0;
            switch (v730.tag) {
                case 0: { // None
                    v906 = v881;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v883 = v730.v.case1.v0;
                    US4 v884;
                    v884 = US4_0();
                    int32_t v885; US4 v886;
                    Tuple25 tmp138 = TupleCreate25(0l, v884);
                    v885 = tmp138.v0; v886 = tmp138.v1;
                    while (while_method_13(v885)){
                        ap_uint<4l> v888; ap_uint<2l> v889;
                        Tuple18 tmp139 = v882[v885];
                        v888 = tmp139.v0; v889 = tmp139.v1;
                        ap_uint<4l> v890; ap_uint<2l> v891;
                        Tuple18 tmp140 = v883[v885];
                        v890 = tmp140.v0; v891 = tmp140.v1;
                        US4 v899;
                        switch (v886.tag) {
                            case 0: { // Eq
                                bool v892;
                                v892 = v888 > v890;
                                if (v892){
                                    v899 = US4_1();
                                } else {
                                    bool v894;
                                    v894 = v888 < v890;
                                    if (v894){
                                        v899 = US4_2();
                                    } else {
                                        v899 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v899 = v886;
                            }
                        }
                        v886 = v899;
                        v885++;
                    }
                    bool v900;
                    switch (v886.tag) {
                        case 1: { // Gt
                            v900 = true;
                            break;
                        }
                        default: {
                            v900 = false;
                        }
                    }
                    std::array<Tuple18,5l> v901;
                    if (v900){
                        v901 = v882;
                    } else {
                        v901 = v883;
                    }
                    v906 = US6_1(v901);
                }
            }
        }
    }
    US6 v931;
    switch (v906.tag) {
        case 0: { // None
            v931 = v667;
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v907 = v906.v.case1.v0;
            switch (v667.tag) {
                case 0: { // None
                    v931 = v906;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v908 = v667.v.case1.v0;
                    US4 v909;
                    v909 = US4_0();
                    int32_t v910; US4 v911;
                    Tuple25 tmp141 = TupleCreate25(0l, v909);
                    v910 = tmp141.v0; v911 = tmp141.v1;
                    while (while_method_13(v910)){
                        ap_uint<4l> v913; ap_uint<2l> v914;
                        Tuple18 tmp142 = v907[v910];
                        v913 = tmp142.v0; v914 = tmp142.v1;
                        ap_uint<4l> v915; ap_uint<2l> v916;
                        Tuple18 tmp143 = v908[v910];
                        v915 = tmp143.v0; v916 = tmp143.v1;
                        US4 v924;
                        switch (v911.tag) {
                            case 0: { // Eq
                                bool v917;
                                v917 = v913 > v915;
                                if (v917){
                                    v924 = US4_1();
                                } else {
                                    bool v919;
                                    v919 = v913 < v915;
                                    if (v919){
                                        v924 = US4_2();
                                    } else {
                                        v924 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v924 = v911;
                            }
                        }
                        v911 = v924;
                        v910++;
                    }
                    bool v925;
                    switch (v911.tag) {
                        case 1: { // Gt
                            v925 = true;
                            break;
                        }
                        default: {
                            v925 = false;
                        }
                    }
                    std::array<Tuple18,5l> v926;
                    if (v925){
                        v926 = v907;
                    } else {
                        v926 = v908;
                    }
                    v931 = US6_1(v926);
                }
            }
        }
    }
    ap_uint<4l> v932;
    v932 = 1ul;
    US11 v937;
    switch (v143.tag) {
        case 0: { // None
            v937 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v933 = v143.v.case1.v0;
            v937 = US11_1(v933, v932);
        }
    }
    ap_uint<4l> v938;
    v938 = 2ul;
    US11 v943;
    switch (v236.tag) {
        case 0: { // None
            v943 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v939 = v236.v.case1.v0;
            v943 = US11_1(v939, v938);
        }
    }
    ap_uint<4l> v944;
    v944 = 3ul;
    US11 v949;
    switch (v289.tag) {
        case 0: { // None
            v949 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v945 = v289.v.case1.v0;
            v949 = US11_1(v945, v944);
        }
    }
    ap_uint<4l> v950;
    v950 = 4ul;
    US11 v955;
    switch (v328.tag) {
        case 0: { // None
            v955 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v951 = v328.v.case1.v0;
            v955 = US11_1(v951, v950);
        }
    }
    ap_uint<4l> v956;
    v956 = 5ul;
    US11 v961;
    switch (v467.tag) {
        case 0: { // None
            v961 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v957 = v467.v.case1.v0;
            v961 = US11_1(v957, v956);
        }
    }
    ap_uint<4l> v962;
    v962 = 6ul;
    US11 v967;
    switch (v551.tag) {
        case 0: { // None
            v967 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v963 = v551.v.case1.v0;
            v967 = US11_1(v963, v962);
        }
    }
    ap_uint<4l> v968;
    v968 = 7ul;
    US11 v973;
    switch (v604.tag) {
        case 0: { // None
            v973 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v969 = v604.v.case1.v0;
            v973 = US11_1(v969, v968);
        }
    }
    ap_uint<4l> v974;
    v974 = 8ul;
    US11 v979;
    switch (v931.tag) {
        case 0: { // None
            v979 = US11_0();
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v975 = v931.v.case1.v0;
            v979 = US11_1(v975, v974);
        }
    }
    US11 v981;
    switch (v979.tag) {
        case 0: { // None
            v981 = US11_0();
            break;
        }
        default: {
            v981 = v979;
        }
    }
    US11 v991;
    switch (v981.tag) {
        case 1: { // Some
            std::array<Tuple18,5l> v982 = v981.v.case1.v0; ap_uint<4l> v983 = v981.v.case1.v1;
            switch (v973.tag) {
                case 0: { // None
                    v991 = v981;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v984 = v973.v.case1.v0; ap_uint<4l> v985 = v973.v.case1.v1;
                    v991 = US11_1(v982, v983);
                }
            }
            break;
        }
        default: {
            switch (v973.tag) {
                case 0: { // None
                    v991 = v981;
                    break;
                }
                default: {
                    switch (v981.tag) {
                        default: { // None
                            v991 = v973;
                        }
                    }
                }
            }
        }
    }
    US11 v1001;
    switch (v991.tag) {
        case 1: { // Some
            std::array<Tuple18,5l> v992 = v991.v.case1.v0; ap_uint<4l> v993 = v991.v.case1.v1;
            switch (v967.tag) {
                case 0: { // None
                    v1001 = v991;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v994 = v967.v.case1.v0; ap_uint<4l> v995 = v967.v.case1.v1;
                    v1001 = US11_1(v992, v993);
                }
            }
            break;
        }
        default: {
            switch (v967.tag) {
                case 0: { // None
                    v1001 = v991;
                    break;
                }
                default: {
                    switch (v991.tag) {
                        default: { // None
                            v1001 = v967;
                        }
                    }
                }
            }
        }
    }
    US11 v1011;
    switch (v1001.tag) {
        case 1: { // Some
            std::array<Tuple18,5l> v1002 = v1001.v.case1.v0; ap_uint<4l> v1003 = v1001.v.case1.v1;
            switch (v961.tag) {
                case 0: { // None
                    v1011 = v1001;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v1004 = v961.v.case1.v0; ap_uint<4l> v1005 = v961.v.case1.v1;
                    v1011 = US11_1(v1002, v1003);
                }
            }
            break;
        }
        default: {
            switch (v961.tag) {
                case 0: { // None
                    v1011 = v1001;
                    break;
                }
                default: {
                    switch (v1001.tag) {
                        default: { // None
                            v1011 = v961;
                        }
                    }
                }
            }
        }
    }
    US11 v1021;
    switch (v1011.tag) {
        case 1: { // Some
            std::array<Tuple18,5l> v1012 = v1011.v.case1.v0; ap_uint<4l> v1013 = v1011.v.case1.v1;
            switch (v955.tag) {
                case 0: { // None
                    v1021 = v1011;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v1014 = v955.v.case1.v0; ap_uint<4l> v1015 = v955.v.case1.v1;
                    v1021 = US11_1(v1012, v1013);
                }
            }
            break;
        }
        default: {
            switch (v955.tag) {
                case 0: { // None
                    v1021 = v1011;
                    break;
                }
                default: {
                    switch (v1011.tag) {
                        default: { // None
                            v1021 = v955;
                        }
                    }
                }
            }
        }
    }
    US11 v1031;
    switch (v1021.tag) {
        case 1: { // Some
            std::array<Tuple18,5l> v1022 = v1021.v.case1.v0; ap_uint<4l> v1023 = v1021.v.case1.v1;
            switch (v949.tag) {
                case 0: { // None
                    v1031 = v1021;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v1024 = v949.v.case1.v0; ap_uint<4l> v1025 = v949.v.case1.v1;
                    v1031 = US11_1(v1022, v1023);
                }
            }
            break;
        }
        default: {
            switch (v949.tag) {
                case 0: { // None
                    v1031 = v1021;
                    break;
                }
                default: {
                    switch (v1021.tag) {
                        default: { // None
                            v1031 = v949;
                        }
                    }
                }
            }
        }
    }
    US11 v1041;
    switch (v1031.tag) {
        case 1: { // Some
            std::array<Tuple18,5l> v1032 = v1031.v.case1.v0; ap_uint<4l> v1033 = v1031.v.case1.v1;
            switch (v943.tag) {
                case 0: { // None
                    v1041 = v1031;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v1034 = v943.v.case1.v0; ap_uint<4l> v1035 = v943.v.case1.v1;
                    v1041 = US11_1(v1032, v1033);
                }
            }
            break;
        }
        default: {
            switch (v943.tag) {
                case 0: { // None
                    v1041 = v1031;
                    break;
                }
                default: {
                    switch (v1031.tag) {
                        default: { // None
                            v1041 = v943;
                        }
                    }
                }
            }
        }
    }
    US11 v1051;
    switch (v1041.tag) {
        case 1: { // Some
            std::array<Tuple18,5l> v1042 = v1041.v.case1.v0; ap_uint<4l> v1043 = v1041.v.case1.v1;
            switch (v937.tag) {
                case 0: { // None
                    v1051 = v1041;
                    break;
                }
                default: { // Some
                    std::array<Tuple18,5l> v1044 = v937.v.case1.v0; ap_uint<4l> v1045 = v937.v.case1.v1;
                    v1051 = US11_1(v1042, v1043);
                }
            }
            break;
        }
        default: {
            switch (v937.tag) {
                case 0: { // None
                    v1051 = v1041;
                    break;
                }
                default: {
                    switch (v1041.tag) {
                        default: { // None
                            v1051 = v937;
                        }
                    }
                }
            }
        }
    }
    std::array<Tuple18,5l> v1057; ap_uint<4l> v1058;
    switch (v1051.tag) {
        case 0: { // None
            ap_uint<4l> v1054;
            v1054 = 0ul;
            v1057 = v86; v1058 = v1054;
            break;
        }
        default: { // Some
            std::array<Tuple18,5l> v1052 = v1051.v.case1.v0; ap_uint<4l> v1053 = v1051.v.case1.v1;
            v1057 = v1052; v1058 = v1053;
        }
    }
    return TupleCreate19(v1057, v1058);
}
Tuple19 score_12(ap_uint<4l> v0, ap_uint<2l> v1, ap_uint<4l> v2, ap_uint<2l> v3, ap_uint<4l> v4, ap_uint<2l> v5, ap_uint<4l> v6, ap_uint<2l> v7, ap_uint<4l> v8, ap_uint<2l> v9, ap_uint<4l> v10, ap_uint<2l> v11, ap_uint<4l> v12, ap_uint<2l> v13){
    std::array<Tuple18,7l> v14;
    v14[0l] = TupleCreate18(v10, v11);
    v14[1l] = TupleCreate18(v12, v13);
    v14[2l] = TupleCreate18(v0, v1);
    v14[3l] = TupleCreate18(v2, v3);
    v14[4l] = TupleCreate18(v4, v5);
    v14[5l] = TupleCreate18(v6, v7);
    v14[6l] = TupleCreate18(v8, v9);
    return score_13(v14);
}
inline Tuple26 TupleCreate26(US4 v0, int32_t v1){
    Tuple26 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_17(std::array<Tuple18,5l> v0, US4 v1, int32_t v2){
    bool v3;
    v3 = v2 < 5l;
    return v3;
}
Tuple3 game_2(ap_uint<52l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    ap_uint<1l> v2;
    v2 = 0;
    ap_uint<4l> v3; ap_uint<2l> v4; ap_uint<52l> v5; ap_uint<128l> v6;
    Tuple4 tmp9 = draw_card_3(v0, v1);
    v3 = tmp9.v0; v4 = tmp9.v1; v5 = tmp9.v2; v6 = tmp9.v3;
    ap_uint<4l> v7; ap_uint<2l> v8; ap_uint<52l> v9; ap_uint<128l> v10;
    Tuple4 tmp10 = draw_card_3(v5, v6);
    v7 = tmp10.v0; v8 = tmp10.v1; v9 = tmp10.v2; v10 = tmp10.v3;
    ap_uint<1l> v11;
    v11 = 1;
    ap_uint<4l> v12; ap_uint<2l> v13; ap_uint<52l> v14; ap_uint<128l> v15;
    Tuple4 tmp11 = draw_card_3(v0, v1);
    v12 = tmp11.v0; v13 = tmp11.v1; v14 = tmp11.v2; v15 = tmp11.v3;
    ap_uint<4l> v16; ap_uint<2l> v17; ap_uint<52l> v18; ap_uint<128l> v19;
    Tuple4 tmp12 = draw_card_3(v14, v15);
    v16 = tmp12.v0; v17 = tmp12.v1; v18 = tmp12.v2; v19 = tmp12.v3;
    ap_uint<1l> v20;
    v20 = 0;
    ap_uint<2l> v33;
    v33 = 2l;
    US0 v34;
    v34 = US0_1(v3, v4, v7, v8);
    US0 v35;
    v35 = US0_1(v12, v13, v16, v17);
    US1 v36;
    v36 = US1_1(v33, v20);
    ap_uint<52l> v37; ap_uint<128l> v38; uint8_t v39; US0 v40; int16_t v41; US0 v42; int16_t v43; US1 v44;
    Tuple10 tmp13 = TupleCreate10(v18, v19, 11u, v34, 2, v35, 1, v36);
    v37 = tmp13.v0; v38 = tmp13.v1; v39 = tmp13.v2; v40 = tmp13.v3; v41 = tmp13.v4; v42 = tmp13.v5; v43 = tmp13.v6; v44 = tmp13.v7;
    while (while_method_4(v37, v38, v39, v40, v41, v42, v43, v44)){
        US0 v146; int16_t v147; US0 v148; int16_t v149; US1 v150; ap_uint<52l> v151; ap_uint<128l> v152;
        switch (v44.tag) {
            case 0: { // Done
                US1 v46;
                v46 = US1_0();
                v146 = v40; v147 = v41; v148 = v42; v149 = v43; v150 = v46; v151 = v37; v152 = v38;
                break;
            }
            default: { // TurnOf
                ap_uint<2l> v47 = v44.v.case1.v0; ap_uint<1l> v48 = v44.v.case1.v1;
                ap_uint<1l> v49;
                v49 = 0;
                bool v50;
                v50 = v48 == v49;
                US0 v53; int16_t v54; US0 v55; int16_t v56; ap_uint<1l> v57;
                if (v50){
                    ap_uint<1l> v51;
                    v51 = 1;
                    v53 = v40; v54 = v41; v55 = v42; v56 = v43; v57 = v51;
                } else {
                    ap_uint<1l> v52;
                    v52 = 0;
                    v53 = v42; v54 = v43; v55 = v40; v56 = v41; v57 = v52;
                }
                bool v58;
                v58 = v54 >= v56;
                int16_t v59;
                if (v58){
                    v59 = v54;
                } else {
                    v59 = v56;
                }
                int16_t v60;
                v60 = v59 + v56;
                bool v61;
                v61 = v54 < v56;
                float v62;
                if (v61){
                    v62 = 1.0f;
                } else {
                    v62 = 0.0f;
                }
                int16_t v63;
                v63 = v60 / 4;
                int16_t v64;
                v64 = v60 + v63;
                int16_t v65;
                v65 = v56 + 2;
                bool v66;
                v66 = v65 <= v64;
                bool v68;
                if (v66){
                    bool v67;
                    v67 = v64 <= 100;
                    v68 = v67;
                } else {
                    v68 = false;
                }
                float v69;
                if (v68){
                    v69 = 0.25f;
                } else {
                    v69 = 0.0f;
                }
                int16_t v70;
                v70 = v60 / 3;
                int16_t v71;
                v71 = v60 + v70;
                bool v72;
                v72 = v65 <= v71;
                bool v74;
                if (v72){
                    bool v73;
                    v73 = v71 <= 100;
                    v74 = v73;
                } else {
                    v74 = false;
                }
                float v75;
                if (v74){
                    v75 = 0.25f;
                } else {
                    v75 = 0.0f;
                }
                int16_t v76;
                v76 = v60 / 2;
                int16_t v77;
                v77 = v60 + v76;
                bool v78;
                v78 = v65 <= v77;
                bool v80;
                if (v78){
                    bool v79;
                    v79 = v77 <= 100;
                    v80 = v79;
                } else {
                    v80 = false;
                }
                float v81;
                if (v80){
                    v81 = 0.25f;
                } else {
                    v81 = 0.0f;
                }
                int16_t v82;
                v82 = v60 + v60;
                bool v83;
                v83 = v65 <= v82;
                bool v85;
                if (v83){
                    bool v84;
                    v84 = v82 <= 100;
                    v85 = v84;
                } else {
                    v85 = false;
                }
                float v86;
                if (v85){
                    v86 = 0.25f;
                } else {
                    v86 = 0.0f;
                }
                int16_t v87;
                v87 = v60 * 3;
                int16_t v88;
                v88 = v87 / 2;
                int16_t v89;
                v89 = v60 + v88;
                bool v90;
                v90 = v65 <= v89;
                bool v92;
                if (v90){
                    bool v91;
                    v91 = v89 <= 100;
                    v92 = v91;
                } else {
                    v92 = false;
                }
                float v93;
                if (v92){
                    v93 = 0.25f;
                } else {
                    v93 = 0.0f;
                }
                bool v94;
                v94 = v54 < 100;
                float v95;
                if (v94){
                    v95 = 0.3f;
                } else {
                    v95 = 0.0f;
                }
                std::array<Tuple11,8l> v96;
                US2 v97;
                v97 = US2_1();
                v96[0l] = TupleCreate11(v97, v62);
                US2 v98;
                v98 = US2_0();
                v96[1l] = TupleCreate11(v98, 2.0f);
                US2 v99;
                v99 = US2_2(v64);
                v96[2l] = TupleCreate11(v99, v69);
                US2 v100;
                v100 = US2_2(v71);
                v96[3l] = TupleCreate11(v100, v75);
                US2 v101;
                v101 = US2_2(v77);
                v96[4l] = TupleCreate11(v101, v81);
                US2 v102;
                v102 = US2_2(v82);
                v96[5l] = TupleCreate11(v102, v86);
                US2 v103;
                v103 = US2_2(v89);
                v96[6l] = TupleCreate11(v103, v93);
                US2 v104;
                v104 = US2_2(100);
                v96[7l] = TupleCreate11(v104, v95);
                US2 v105; ap_uint<128l> v106;
                Tuple12 tmp24 = sample_discrete_7(v96, v38);
                v105 = tmp24.v0; v106 = tmp24.v1;
                US0 v132; int16_t v133; US1 v134;
                switch (v105.tag) {
                    case 0: { // Call
                        bool v109;
                        v109 = v56 >= v54;
                        int16_t v110;
                        if (v109){
                            v110 = v56;
                        } else {
                            v110 = v54;
                        }
                        ap_uint<2l> v111;
                        v111 = 0l;
                        bool v112;
                        v112 = v111 < v47;
                        US1 v116;
                        if (v112){
                            ap_uint<2l> v113;
                            v113 = v47 - 1;
                            v116 = US1_1(v113, v57);
                        } else {
                            v116 = US1_0();
                        }
                        v132 = v53; v133 = v110; v134 = v116;
                        break;
                    }
                    case 1: { // Fold
                        US0 v107;
                        v107 = US0_0();
                        US1 v108;
                        v108 = US1_0();
                        v132 = v107; v133 = v54; v134 = v108;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v117 = v105.v.case2.v0;
                        bool v118;
                        v118 = v117 >= v54;
                        int16_t v119;
                        if (v118){
                            v119 = v117;
                        } else {
                            v119 = v54;
                        }
                        bool v120;
                        v120 = v65 >= v119;
                        int16_t v121;
                        if (v120){
                            v121 = v65;
                        } else {
                            v121 = v119;
                        }
                        bool v122;
                        v122 = 100 < v121;
                        int16_t v123;
                        if (v122){
                            v123 = 100;
                        } else {
                            v123 = v121;
                        }
                        ap_uint<2l> v124;
                        v124 = 0l;
                        US1 v125;
                        v125 = US1_1(v124, v57);
                        v132 = v53; v133 = v123; v134 = v125;
                    }
                }
                US0 v135; int16_t v136; US0 v137; int16_t v138;
                if (v50){
                    v135 = v132; v136 = v133; v137 = v55; v138 = v56;
                } else {
                    v135 = v55; v136 = v56; v137 = v132; v138 = v133;
                }
                v146 = v135; v147 = v136; v148 = v137; v149 = v138; v150 = v134; v151 = v37; v152 = v106;
            }
        }
        uint8_t v153;
        v153 = v39 - 1u;
        v37 = v151;
        v38 = v152;
        v39 = v153;
        v40 = v146;
        v41 = v147;
        v42 = v148;
        v43 = v149;
        v44 = v150;
    }
    ap_uint<4l> v154; ap_uint<2l> v155; ap_uint<52l> v156; ap_uint<128l> v157;
    Tuple4 tmp25 = draw_card_3(v37, v38);
    v154 = tmp25.v0; v155 = tmp25.v1; v156 = tmp25.v2; v157 = tmp25.v3;
    ap_uint<4l> v158; ap_uint<2l> v159; ap_uint<52l> v160; ap_uint<128l> v161;
    Tuple4 tmp26 = draw_card_3(v156, v157);
    v158 = tmp26.v0; v159 = tmp26.v1; v160 = tmp26.v2; v161 = tmp26.v3;
    ap_uint<4l> v162; ap_uint<2l> v163; ap_uint<52l> v164; ap_uint<128l> v165;
    Tuple4 tmp27 = draw_card_3(v160, v161);
    v162 = tmp27.v0; v163 = tmp27.v1; v164 = tmp27.v2; v165 = tmp27.v3;
    ap_uint<1l> v166;
    v166 = 0;
    bool v176;
    v176 = v41 == 2;
    bool v181;
    if (v176){
        bool v179;
        v179 = v43 == 1;
        v181 = v179;
    } else {
        v181 = false;
    }
    ap_uint<2l> v184;
    if (v181){
        ap_uint<2l> v182;
        v182 = 2l;
        v184 = v182;
    } else {
        ap_uint<2l> v183;
        v183 = 1l;
        v184 = v183;
    }
    US1 v185;
    v185 = US1_1(v184, v166);
    ap_uint<52l> v186; ap_uint<128l> v187; uint8_t v188; US0 v189; int16_t v190; US0 v191; int16_t v192; US1 v193;
    Tuple10 tmp28 = TupleCreate10(v164, v165, 11u, v40, v41, v42, v43, v185);
    v186 = tmp28.v0; v187 = tmp28.v1; v188 = tmp28.v2; v189 = tmp28.v3; v190 = tmp28.v4; v191 = tmp28.v5; v192 = tmp28.v6; v193 = tmp28.v7;
    while (while_method_4(v186, v187, v188, v189, v190, v191, v192, v193)){
        US0 v295; int16_t v296; US0 v297; int16_t v298; US1 v299; ap_uint<52l> v300; ap_uint<128l> v301;
        switch (v193.tag) {
            case 0: { // Done
                US1 v195;
                v195 = US1_0();
                v295 = v189; v296 = v190; v297 = v191; v298 = v192; v299 = v195; v300 = v186; v301 = v187;
                break;
            }
            default: { // TurnOf
                ap_uint<2l> v196 = v193.v.case1.v0; ap_uint<1l> v197 = v193.v.case1.v1;
                ap_uint<1l> v198;
                v198 = 0;
                bool v199;
                v199 = v197 == v198;
                US0 v202; int16_t v203; US0 v204; int16_t v205; ap_uint<1l> v206;
                if (v199){
                    ap_uint<1l> v200;
                    v200 = 1;
                    v202 = v189; v203 = v190; v204 = v191; v205 = v192; v206 = v200;
                } else {
                    ap_uint<1l> v201;
                    v201 = 0;
                    v202 = v191; v203 = v192; v204 = v189; v205 = v190; v206 = v201;
                }
                bool v207;
                v207 = v203 >= v205;
                int16_t v208;
                if (v207){
                    v208 = v203;
                } else {
                    v208 = v205;
                }
                int16_t v209;
                v209 = v208 + v205;
                bool v210;
                v210 = v203 < v205;
                float v211;
                if (v210){
                    v211 = 1.0f;
                } else {
                    v211 = 0.0f;
                }
                int16_t v212;
                v212 = v209 / 4;
                int16_t v213;
                v213 = v209 + v212;
                int16_t v214;
                v214 = v205 + 2;
                bool v215;
                v215 = v214 <= v213;
                bool v217;
                if (v215){
                    bool v216;
                    v216 = v213 <= 100;
                    v217 = v216;
                } else {
                    v217 = false;
                }
                float v218;
                if (v217){
                    v218 = 0.25f;
                } else {
                    v218 = 0.0f;
                }
                int16_t v219;
                v219 = v209 / 3;
                int16_t v220;
                v220 = v209 + v219;
                bool v221;
                v221 = v214 <= v220;
                bool v223;
                if (v221){
                    bool v222;
                    v222 = v220 <= 100;
                    v223 = v222;
                } else {
                    v223 = false;
                }
                float v224;
                if (v223){
                    v224 = 0.25f;
                } else {
                    v224 = 0.0f;
                }
                int16_t v225;
                v225 = v209 / 2;
                int16_t v226;
                v226 = v209 + v225;
                bool v227;
                v227 = v214 <= v226;
                bool v229;
                if (v227){
                    bool v228;
                    v228 = v226 <= 100;
                    v229 = v228;
                } else {
                    v229 = false;
                }
                float v230;
                if (v229){
                    v230 = 0.25f;
                } else {
                    v230 = 0.0f;
                }
                int16_t v231;
                v231 = v209 + v209;
                bool v232;
                v232 = v214 <= v231;
                bool v234;
                if (v232){
                    bool v233;
                    v233 = v231 <= 100;
                    v234 = v233;
                } else {
                    v234 = false;
                }
                float v235;
                if (v234){
                    v235 = 0.25f;
                } else {
                    v235 = 0.0f;
                }
                int16_t v236;
                v236 = v209 * 3;
                int16_t v237;
                v237 = v236 / 2;
                int16_t v238;
                v238 = v209 + v237;
                bool v239;
                v239 = v214 <= v238;
                bool v241;
                if (v239){
                    bool v240;
                    v240 = v238 <= 100;
                    v241 = v240;
                } else {
                    v241 = false;
                }
                float v242;
                if (v241){
                    v242 = 0.25f;
                } else {
                    v242 = 0.0f;
                }
                bool v243;
                v243 = v203 < 100;
                float v244;
                if (v243){
                    v244 = 0.3f;
                } else {
                    v244 = 0.0f;
                }
                std::array<Tuple11,8l> v245;
                US2 v246;
                v246 = US2_1();
                v245[0l] = TupleCreate11(v246, v211);
                US2 v247;
                v247 = US2_0();
                v245[1l] = TupleCreate11(v247, 2.0f);
                US2 v248;
                v248 = US2_2(v213);
                v245[2l] = TupleCreate11(v248, v218);
                US2 v249;
                v249 = US2_2(v220);
                v245[3l] = TupleCreate11(v249, v224);
                US2 v250;
                v250 = US2_2(v226);
                v245[4l] = TupleCreate11(v250, v230);
                US2 v251;
                v251 = US2_2(v231);
                v245[5l] = TupleCreate11(v251, v235);
                US2 v252;
                v252 = US2_2(v238);
                v245[6l] = TupleCreate11(v252, v242);
                US2 v253;
                v253 = US2_2(100);
                v245[7l] = TupleCreate11(v253, v244);
                US2 v254; ap_uint<128l> v255;
                Tuple12 tmp29 = sample_discrete_7(v245, v187);
                v254 = tmp29.v0; v255 = tmp29.v1;
                US0 v281; int16_t v282; US1 v283;
                switch (v254.tag) {
                    case 0: { // Call
                        bool v258;
                        v258 = v205 >= v203;
                        int16_t v259;
                        if (v258){
                            v259 = v205;
                        } else {
                            v259 = v203;
                        }
                        ap_uint<2l> v260;
                        v260 = 0l;
                        bool v261;
                        v261 = v260 < v196;
                        US1 v265;
                        if (v261){
                            ap_uint<2l> v262;
                            v262 = v196 - 1;
                            v265 = US1_1(v262, v206);
                        } else {
                            v265 = US1_0();
                        }
                        v281 = v202; v282 = v259; v283 = v265;
                        break;
                    }
                    case 1: { // Fold
                        US0 v256;
                        v256 = US0_0();
                        US1 v257;
                        v257 = US1_0();
                        v281 = v256; v282 = v203; v283 = v257;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v266 = v254.v.case2.v0;
                        bool v267;
                        v267 = v266 >= v203;
                        int16_t v268;
                        if (v267){
                            v268 = v266;
                        } else {
                            v268 = v203;
                        }
                        bool v269;
                        v269 = v214 >= v268;
                        int16_t v270;
                        if (v269){
                            v270 = v214;
                        } else {
                            v270 = v268;
                        }
                        bool v271;
                        v271 = 100 < v270;
                        int16_t v272;
                        if (v271){
                            v272 = 100;
                        } else {
                            v272 = v270;
                        }
                        ap_uint<2l> v273;
                        v273 = 0l;
                        US1 v274;
                        v274 = US1_1(v273, v206);
                        v281 = v202; v282 = v272; v283 = v274;
                    }
                }
                US0 v284; int16_t v285; US0 v286; int16_t v287;
                if (v199){
                    v284 = v281; v285 = v282; v286 = v204; v287 = v205;
                } else {
                    v284 = v204; v285 = v205; v286 = v281; v287 = v282;
                }
                v295 = v284; v296 = v285; v297 = v286; v298 = v287; v299 = v283; v300 = v186; v301 = v255;
            }
        }
        uint8_t v302;
        v302 = v188 - 1u;
        v186 = v300;
        v187 = v301;
        v188 = v302;
        v189 = v295;
        v190 = v296;
        v191 = v297;
        v192 = v298;
        v193 = v299;
    }
    ap_uint<4l> v303; ap_uint<2l> v304; ap_uint<52l> v305; ap_uint<128l> v306;
    Tuple4 tmp30 = draw_card_3(v186, v187);
    v303 = tmp30.v0; v304 = tmp30.v1; v305 = tmp30.v2; v306 = tmp30.v3;
    ap_uint<1l> v307;
    v307 = 0;
    bool v317;
    v317 = v190 == 2;
    bool v322;
    if (v317){
        bool v320;
        v320 = v192 == 1;
        v322 = v320;
    } else {
        v322 = false;
    }
    ap_uint<2l> v325;
    if (v322){
        ap_uint<2l> v323;
        v323 = 2l;
        v325 = v323;
    } else {
        ap_uint<2l> v324;
        v324 = 1l;
        v325 = v324;
    }
    US1 v326;
    v326 = US1_1(v325, v307);
    ap_uint<52l> v327; ap_uint<128l> v328; uint8_t v329; US0 v330; int16_t v331; US0 v332; int16_t v333; US1 v334;
    Tuple10 tmp31 = TupleCreate10(v305, v306, 11u, v189, v190, v191, v192, v326);
    v327 = tmp31.v0; v328 = tmp31.v1; v329 = tmp31.v2; v330 = tmp31.v3; v331 = tmp31.v4; v332 = tmp31.v5; v333 = tmp31.v6; v334 = tmp31.v7;
    while (while_method_4(v327, v328, v329, v330, v331, v332, v333, v334)){
        US0 v436; int16_t v437; US0 v438; int16_t v439; US1 v440; ap_uint<52l> v441; ap_uint<128l> v442;
        switch (v334.tag) {
            case 0: { // Done
                US1 v336;
                v336 = US1_0();
                v436 = v330; v437 = v331; v438 = v332; v439 = v333; v440 = v336; v441 = v327; v442 = v328;
                break;
            }
            default: { // TurnOf
                ap_uint<2l> v337 = v334.v.case1.v0; ap_uint<1l> v338 = v334.v.case1.v1;
                ap_uint<1l> v339;
                v339 = 0;
                bool v340;
                v340 = v338 == v339;
                US0 v343; int16_t v344; US0 v345; int16_t v346; ap_uint<1l> v347;
                if (v340){
                    ap_uint<1l> v341;
                    v341 = 1;
                    v343 = v330; v344 = v331; v345 = v332; v346 = v333; v347 = v341;
                } else {
                    ap_uint<1l> v342;
                    v342 = 0;
                    v343 = v332; v344 = v333; v345 = v330; v346 = v331; v347 = v342;
                }
                bool v348;
                v348 = v344 >= v346;
                int16_t v349;
                if (v348){
                    v349 = v344;
                } else {
                    v349 = v346;
                }
                int16_t v350;
                v350 = v349 + v346;
                bool v351;
                v351 = v344 < v346;
                float v352;
                if (v351){
                    v352 = 1.0f;
                } else {
                    v352 = 0.0f;
                }
                int16_t v353;
                v353 = v350 / 4;
                int16_t v354;
                v354 = v350 + v353;
                int16_t v355;
                v355 = v346 + 2;
                bool v356;
                v356 = v355 <= v354;
                bool v358;
                if (v356){
                    bool v357;
                    v357 = v354 <= 100;
                    v358 = v357;
                } else {
                    v358 = false;
                }
                float v359;
                if (v358){
                    v359 = 0.25f;
                } else {
                    v359 = 0.0f;
                }
                int16_t v360;
                v360 = v350 / 3;
                int16_t v361;
                v361 = v350 + v360;
                bool v362;
                v362 = v355 <= v361;
                bool v364;
                if (v362){
                    bool v363;
                    v363 = v361 <= 100;
                    v364 = v363;
                } else {
                    v364 = false;
                }
                float v365;
                if (v364){
                    v365 = 0.25f;
                } else {
                    v365 = 0.0f;
                }
                int16_t v366;
                v366 = v350 / 2;
                int16_t v367;
                v367 = v350 + v366;
                bool v368;
                v368 = v355 <= v367;
                bool v370;
                if (v368){
                    bool v369;
                    v369 = v367 <= 100;
                    v370 = v369;
                } else {
                    v370 = false;
                }
                float v371;
                if (v370){
                    v371 = 0.25f;
                } else {
                    v371 = 0.0f;
                }
                int16_t v372;
                v372 = v350 + v350;
                bool v373;
                v373 = v355 <= v372;
                bool v375;
                if (v373){
                    bool v374;
                    v374 = v372 <= 100;
                    v375 = v374;
                } else {
                    v375 = false;
                }
                float v376;
                if (v375){
                    v376 = 0.25f;
                } else {
                    v376 = 0.0f;
                }
                int16_t v377;
                v377 = v350 * 3;
                int16_t v378;
                v378 = v377 / 2;
                int16_t v379;
                v379 = v350 + v378;
                bool v380;
                v380 = v355 <= v379;
                bool v382;
                if (v380){
                    bool v381;
                    v381 = v379 <= 100;
                    v382 = v381;
                } else {
                    v382 = false;
                }
                float v383;
                if (v382){
                    v383 = 0.25f;
                } else {
                    v383 = 0.0f;
                }
                bool v384;
                v384 = v344 < 100;
                float v385;
                if (v384){
                    v385 = 0.3f;
                } else {
                    v385 = 0.0f;
                }
                std::array<Tuple11,8l> v386;
                US2 v387;
                v387 = US2_1();
                v386[0l] = TupleCreate11(v387, v352);
                US2 v388;
                v388 = US2_0();
                v386[1l] = TupleCreate11(v388, 2.0f);
                US2 v389;
                v389 = US2_2(v354);
                v386[2l] = TupleCreate11(v389, v359);
                US2 v390;
                v390 = US2_2(v361);
                v386[3l] = TupleCreate11(v390, v365);
                US2 v391;
                v391 = US2_2(v367);
                v386[4l] = TupleCreate11(v391, v371);
                US2 v392;
                v392 = US2_2(v372);
                v386[5l] = TupleCreate11(v392, v376);
                US2 v393;
                v393 = US2_2(v379);
                v386[6l] = TupleCreate11(v393, v383);
                US2 v394;
                v394 = US2_2(100);
                v386[7l] = TupleCreate11(v394, v385);
                US2 v395; ap_uint<128l> v396;
                Tuple12 tmp32 = sample_discrete_7(v386, v328);
                v395 = tmp32.v0; v396 = tmp32.v1;
                US0 v422; int16_t v423; US1 v424;
                switch (v395.tag) {
                    case 0: { // Call
                        bool v399;
                        v399 = v346 >= v344;
                        int16_t v400;
                        if (v399){
                            v400 = v346;
                        } else {
                            v400 = v344;
                        }
                        ap_uint<2l> v401;
                        v401 = 0l;
                        bool v402;
                        v402 = v401 < v337;
                        US1 v406;
                        if (v402){
                            ap_uint<2l> v403;
                            v403 = v337 - 1;
                            v406 = US1_1(v403, v347);
                        } else {
                            v406 = US1_0();
                        }
                        v422 = v343; v423 = v400; v424 = v406;
                        break;
                    }
                    case 1: { // Fold
                        US0 v397;
                        v397 = US0_0();
                        US1 v398;
                        v398 = US1_0();
                        v422 = v397; v423 = v344; v424 = v398;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v407 = v395.v.case2.v0;
                        bool v408;
                        v408 = v407 >= v344;
                        int16_t v409;
                        if (v408){
                            v409 = v407;
                        } else {
                            v409 = v344;
                        }
                        bool v410;
                        v410 = v355 >= v409;
                        int16_t v411;
                        if (v410){
                            v411 = v355;
                        } else {
                            v411 = v409;
                        }
                        bool v412;
                        v412 = 100 < v411;
                        int16_t v413;
                        if (v412){
                            v413 = 100;
                        } else {
                            v413 = v411;
                        }
                        ap_uint<2l> v414;
                        v414 = 0l;
                        US1 v415;
                        v415 = US1_1(v414, v347);
                        v422 = v343; v423 = v413; v424 = v415;
                    }
                }
                US0 v425; int16_t v426; US0 v427; int16_t v428;
                if (v340){
                    v425 = v422; v426 = v423; v427 = v345; v428 = v346;
                } else {
                    v425 = v345; v426 = v346; v427 = v422; v428 = v423;
                }
                v436 = v425; v437 = v426; v438 = v427; v439 = v428; v440 = v424; v441 = v327; v442 = v396;
            }
        }
        uint8_t v443;
        v443 = v329 - 1u;
        v327 = v441;
        v328 = v442;
        v329 = v443;
        v330 = v436;
        v331 = v437;
        v332 = v438;
        v333 = v439;
        v334 = v440;
    }
    ap_uint<4l> v444; ap_uint<2l> v445; ap_uint<52l> v446; ap_uint<128l> v447;
    Tuple4 tmp33 = draw_card_3(v327, v328);
    v444 = tmp33.v0; v445 = tmp33.v1; v446 = tmp33.v2; v447 = tmp33.v3;
    ap_uint<1l> v448;
    v448 = 0;
    bool v458;
    v458 = v331 == 2;
    bool v463;
    if (v458){
        bool v461;
        v461 = v333 == 1;
        v463 = v461;
    } else {
        v463 = false;
    }
    ap_uint<2l> v466;
    if (v463){
        ap_uint<2l> v464;
        v464 = 2l;
        v466 = v464;
    } else {
        ap_uint<2l> v465;
        v465 = 1l;
        v466 = v465;
    }
    US1 v467;
    v467 = US1_1(v466, v448);
    ap_uint<52l> v468; ap_uint<128l> v469; uint8_t v470; US0 v471; int16_t v472; US0 v473; int16_t v474; US1 v475;
    Tuple10 tmp34 = TupleCreate10(v446, v447, 11u, v330, v331, v332, v333, v467);
    v468 = tmp34.v0; v469 = tmp34.v1; v470 = tmp34.v2; v471 = tmp34.v3; v472 = tmp34.v4; v473 = tmp34.v5; v474 = tmp34.v6; v475 = tmp34.v7;
    while (while_method_4(v468, v469, v470, v471, v472, v473, v474, v475)){
        US0 v577; int16_t v578; US0 v579; int16_t v580; US1 v581; ap_uint<52l> v582; ap_uint<128l> v583;
        switch (v475.tag) {
            case 0: { // Done
                US1 v477;
                v477 = US1_0();
                v577 = v471; v578 = v472; v579 = v473; v580 = v474; v581 = v477; v582 = v468; v583 = v469;
                break;
            }
            default: { // TurnOf
                ap_uint<2l> v478 = v475.v.case1.v0; ap_uint<1l> v479 = v475.v.case1.v1;
                ap_uint<1l> v480;
                v480 = 0;
                bool v481;
                v481 = v479 == v480;
                US0 v484; int16_t v485; US0 v486; int16_t v487; ap_uint<1l> v488;
                if (v481){
                    ap_uint<1l> v482;
                    v482 = 1;
                    v484 = v471; v485 = v472; v486 = v473; v487 = v474; v488 = v482;
                } else {
                    ap_uint<1l> v483;
                    v483 = 0;
                    v484 = v473; v485 = v474; v486 = v471; v487 = v472; v488 = v483;
                }
                bool v489;
                v489 = v485 >= v487;
                int16_t v490;
                if (v489){
                    v490 = v485;
                } else {
                    v490 = v487;
                }
                int16_t v491;
                v491 = v490 + v487;
                bool v492;
                v492 = v485 < v487;
                float v493;
                if (v492){
                    v493 = 1.0f;
                } else {
                    v493 = 0.0f;
                }
                int16_t v494;
                v494 = v491 / 4;
                int16_t v495;
                v495 = v491 + v494;
                int16_t v496;
                v496 = v487 + 2;
                bool v497;
                v497 = v496 <= v495;
                bool v499;
                if (v497){
                    bool v498;
                    v498 = v495 <= 100;
                    v499 = v498;
                } else {
                    v499 = false;
                }
                float v500;
                if (v499){
                    v500 = 0.25f;
                } else {
                    v500 = 0.0f;
                }
                int16_t v501;
                v501 = v491 / 3;
                int16_t v502;
                v502 = v491 + v501;
                bool v503;
                v503 = v496 <= v502;
                bool v505;
                if (v503){
                    bool v504;
                    v504 = v502 <= 100;
                    v505 = v504;
                } else {
                    v505 = false;
                }
                float v506;
                if (v505){
                    v506 = 0.25f;
                } else {
                    v506 = 0.0f;
                }
                int16_t v507;
                v507 = v491 / 2;
                int16_t v508;
                v508 = v491 + v507;
                bool v509;
                v509 = v496 <= v508;
                bool v511;
                if (v509){
                    bool v510;
                    v510 = v508 <= 100;
                    v511 = v510;
                } else {
                    v511 = false;
                }
                float v512;
                if (v511){
                    v512 = 0.25f;
                } else {
                    v512 = 0.0f;
                }
                int16_t v513;
                v513 = v491 + v491;
                bool v514;
                v514 = v496 <= v513;
                bool v516;
                if (v514){
                    bool v515;
                    v515 = v513 <= 100;
                    v516 = v515;
                } else {
                    v516 = false;
                }
                float v517;
                if (v516){
                    v517 = 0.25f;
                } else {
                    v517 = 0.0f;
                }
                int16_t v518;
                v518 = v491 * 3;
                int16_t v519;
                v519 = v518 / 2;
                int16_t v520;
                v520 = v491 + v519;
                bool v521;
                v521 = v496 <= v520;
                bool v523;
                if (v521){
                    bool v522;
                    v522 = v520 <= 100;
                    v523 = v522;
                } else {
                    v523 = false;
                }
                float v524;
                if (v523){
                    v524 = 0.25f;
                } else {
                    v524 = 0.0f;
                }
                bool v525;
                v525 = v485 < 100;
                float v526;
                if (v525){
                    v526 = 0.3f;
                } else {
                    v526 = 0.0f;
                }
                std::array<Tuple11,8l> v527;
                US2 v528;
                v528 = US2_1();
                v527[0l] = TupleCreate11(v528, v493);
                US2 v529;
                v529 = US2_0();
                v527[1l] = TupleCreate11(v529, 2.0f);
                US2 v530;
                v530 = US2_2(v495);
                v527[2l] = TupleCreate11(v530, v500);
                US2 v531;
                v531 = US2_2(v502);
                v527[3l] = TupleCreate11(v531, v506);
                US2 v532;
                v532 = US2_2(v508);
                v527[4l] = TupleCreate11(v532, v512);
                US2 v533;
                v533 = US2_2(v513);
                v527[5l] = TupleCreate11(v533, v517);
                US2 v534;
                v534 = US2_2(v520);
                v527[6l] = TupleCreate11(v534, v524);
                US2 v535;
                v535 = US2_2(100);
                v527[7l] = TupleCreate11(v535, v526);
                US2 v536; ap_uint<128l> v537;
                Tuple12 tmp35 = sample_discrete_7(v527, v469);
                v536 = tmp35.v0; v537 = tmp35.v1;
                US0 v563; int16_t v564; US1 v565;
                switch (v536.tag) {
                    case 0: { // Call
                        bool v540;
                        v540 = v487 >= v485;
                        int16_t v541;
                        if (v540){
                            v541 = v487;
                        } else {
                            v541 = v485;
                        }
                        ap_uint<2l> v542;
                        v542 = 0l;
                        bool v543;
                        v543 = v542 < v478;
                        US1 v547;
                        if (v543){
                            ap_uint<2l> v544;
                            v544 = v478 - 1;
                            v547 = US1_1(v544, v488);
                        } else {
                            v547 = US1_0();
                        }
                        v563 = v484; v564 = v541; v565 = v547;
                        break;
                    }
                    case 1: { // Fold
                        US0 v538;
                        v538 = US0_0();
                        US1 v539;
                        v539 = US1_0();
                        v563 = v538; v564 = v485; v565 = v539;
                        break;
                    }
                    default: { // RaiseTo
                        int16_t v548 = v536.v.case2.v0;
                        bool v549;
                        v549 = v548 >= v485;
                        int16_t v550;
                        if (v549){
                            v550 = v548;
                        } else {
                            v550 = v485;
                        }
                        bool v551;
                        v551 = v496 >= v550;
                        int16_t v552;
                        if (v551){
                            v552 = v496;
                        } else {
                            v552 = v550;
                        }
                        bool v553;
                        v553 = 100 < v552;
                        int16_t v554;
                        if (v553){
                            v554 = 100;
                        } else {
                            v554 = v552;
                        }
                        ap_uint<2l> v555;
                        v555 = 0l;
                        US1 v556;
                        v556 = US1_1(v555, v488);
                        v563 = v484; v564 = v554; v565 = v556;
                    }
                }
                US0 v566; int16_t v567; US0 v568; int16_t v569;
                if (v481){
                    v566 = v563; v567 = v564; v568 = v486; v569 = v487;
                } else {
                    v566 = v486; v567 = v487; v568 = v563; v569 = v564;
                }
                v577 = v566; v578 = v567; v579 = v568; v580 = v569; v581 = v565; v582 = v468; v583 = v537;
            }
        }
        uint8_t v584;
        v584 = v470 - 1u;
        v468 = v582;
        v469 = v583;
        v470 = v584;
        v471 = v577;
        v472 = v578;
        v473 = v579;
        v474 = v580;
        v475 = v581;
    }
    switch (v471.tag) {
        case 0: { // None
            switch (v473.tag) {
                case 0: { // None
                    return TupleCreate3(0, v468, v469);
                    break;
                }
                default: { // Some
                    ap_uint<4l> v641 = v473.v.case1.v0; ap_uint<2l> v642 = v473.v.case1.v1; ap_uint<4l> v643 = v473.v.case1.v2; ap_uint<2l> v644 = v473.v.case1.v3;
                    int16_t v645;
                    v645 = -v472;
                    return TupleCreate3(v645, v468, v469);
                }
            }
            break;
        }
        default: { // Some
            ap_uint<4l> v585 = v471.v.case1.v0; ap_uint<2l> v586 = v471.v.case1.v1; ap_uint<4l> v587 = v471.v.case1.v2; ap_uint<2l> v588 = v471.v.case1.v3;
            switch (v473.tag) {
                case 0: { // None
                    return TupleCreate3(v474, v468, v469);
                    break;
                }
                default: { // Some
                    ap_uint<4l> v589 = v473.v.case1.v0; ap_uint<2l> v590 = v473.v.case1.v1; ap_uint<4l> v591 = v473.v.case1.v2; ap_uint<2l> v592 = v473.v.case1.v3;
                    std::array<Tuple18,5l> v593; ap_uint<4l> v594;
                    Tuple19 tmp144 = score_12(v154, v155, v158, v159, v162, v163, v303, v304, v444, v445, v585, v586, v587, v588);
                    v593 = tmp144.v0; v594 = tmp144.v1;
                    std::array<Tuple18,5l> v595; ap_uint<4l> v596;
                    Tuple19 tmp145 = score_12(v154, v155, v158, v159, v162, v163, v303, v304, v444, v445, v589, v590, v591, v592);
                    v595 = tmp145.v0; v596 = tmp145.v1;
                    // hello;
                    bool v597;
                    v597 = v594 > v596;
                    US4 v603;
                    if (v597){
                        v603 = US4_1();
                    } else {
                        bool v599;
                        v599 = v594 < v596;
                        if (v599){
                            v603 = US4_2();
                        } else {
                            v603 = US4_0();
                        }
                    }
                    US4 v630;
                    switch (v603.tag) {
                        case 0: { // Eq
                            US4 v604;
                            v604 = US4_0();
                            US4 v605; int32_t v606;
                            Tuple26 tmp146 = TupleCreate26(v604, 0l);
                            v605 = tmp146.v0; v606 = tmp146.v1;
                            while (while_method_17(v593, v605, v606)){
                                US4 v628;
                                switch (v605.tag) {
                                    case 0: { // Eq
                                        ap_uint<4l> v608; ap_uint<2l> v609;
                                        Tuple18 tmp147 = v593[v606];
                                        v608 = tmp147.v0; v609 = tmp147.v1;
                                        ap_uint<4l> v610; ap_uint<2l> v611;
                                        Tuple18 tmp148 = v595[v606];
                                        v610 = tmp148.v0; v611 = tmp148.v1;
                                        bool v612;
                                        v612 = v608 > v610;
                                        US4 v618;
                                        if (v612){
                                            v618 = US4_1();
                                        } else {
                                            bool v614;
                                            v614 = v608 < v610;
                                            if (v614){
                                                v618 = US4_2();
                                            } else {
                                                v618 = US4_0();
                                            }
                                        }
                                        bool v619;
                                        switch (v618.tag) {
                                            case 0: { // Eq
                                                v619 = true;
                                                break;
                                            }
                                            default: {
                                                v619 = false;
                                            }
                                        }
                                        if (v619){
                                            bool v620;
                                            v620 = v609 > v611;
                                            if (v620){
                                                v628 = US4_1();
                                            } else {
                                                bool v622;
                                                v622 = v609 < v611;
                                                if (v622){
                                                    v628 = US4_2();
                                                } else {
                                                    v628 = US4_0();
                                                }
                                            }
                                        } else {
                                            v628 = v618;
                                        }
                                        break;
                                    }
                                    default: {
                                        v628 = v605;
                                    }
                                }
                                int32_t v629;
                                v629 = v606 + 1l;
                                v605 = v628;
                                v606 = v629;
                            }
                            v630 = v605;
                            break;
                        }
                        default: {
                            v630 = v603;
                        }
                    }
                    int16_t v634;
                    switch (v630.tag) {
                        case 0: { // Eq
                            v634 = 0;
                            break;
                        }
                        case 1: { // Gt
                            v634 = v474;
                            break;
                        }
                        default: { // Lt
                            int16_t v631;
                            v631 = -v472;
                            v634 = v631;
                        }
                    }
                    return TupleCreate3(v634, v468, v469);
                }
            }
        }
    }
}
int16_t game_loop_0(ap_uint<128l> v0){
    int32_t v1; int16_t v2;
    Tuple0 tmp0 = TupleCreate0(0l, 0);
    v1 = tmp0.v0; v2 = tmp0.v1;
    while (while_method_0(v1)){
        #pragma HLS PIPELINE II=1l
        ap_uint<128l> v4; ap_uint<128l> v5;
        Tuple1 tmp2 = random_ap_1(v0);
        v4 = tmp2.v0; v5 = tmp2.v1;
        v0 = v5;
        ap_uint<52l> v6;
        v6 = 0l;
        int16_t v7; ap_uint<52l> v8; ap_uint<128l> v9;
        Tuple3 tmp149 = game_2(v6, v0);
        v7 = tmp149.v0; v8 = tmp149.v1; v9 = tmp149.v2;
        int16_t v10;
        v10 = v2 + v7;
        v2 = v10;
        v1++;
    }
    return v2;
}
int32_t entry() {
    ap_uint<64l> v0;
    v0 = 0b1101011010100110111111000010111101111111100001011011100001111110;
    ap_uint<64l> v1;
    v1 = 0b1000001110011100000101101011010000000100101010110010110000110000;
    ap_uint<128l> v2;
    v2 = v0.concat(v1);
    int16_t v3;
    v3 = game_loop_0(v2);
    std::cout << v3 << std::endl;
    return 0l;
}
