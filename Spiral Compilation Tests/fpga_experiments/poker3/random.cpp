#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
#include <bitset>
struct Tuple0;
bool method0(int32_t v0);
struct Tuple1;
bool method1(int32_t v0);
struct Tuple2;
struct Tuple3;
struct Tuple4;
bool method4(int32_t v0);
struct Tuple5;
struct Tuple6;
bool method7(int32_t v0);
Tuple6 random_ap6(ap_uint<128l> v0);
Tuple5 random_ap_in_range5(ap_uint<6l> v0, ap_uint<6l> v1, ap_uint<128l> v2);
struct Tuple7;
Tuple3 sample3(ap_uint<52l> v0, ap_uint<128l> v1);
Tuple2 draw_card2(ap_uint<52l> v0, ap_uint<128l> v1);
struct Tuple0 {
    ap_uint<128l> v1;
    int32_t v0;
};
struct Tuple1 {
    ap_uint<52l> v1;
    ap_uint<128l> v2;
    int32_t v0;
};
struct Tuple2 {
    ap_uint<52l> v0;
    ap_uint<4l> v1;
    ap_uint<2l> v2;
    ap_uint<128l> v3;
};
struct Tuple3 {
    ap_uint<52l> v0;
    ap_uint<6l> v1;
    ap_uint<128l> v2;
};
struct Tuple4 {
    int32_t v0;
    uint32_t v1;
};
struct Tuple5 {
    ap_uint<6l> v0;
    ap_uint<128l> v1;
};
struct Tuple6 {
    ap_uint<60l> v0;
    ap_uint<128l> v1;
};
struct Tuple7 {
    ap_uint<6l> v1;
    ap_uint<6l> v2;
    int32_t v0;
};
static inline Tuple0 TupleCreate0(int32_t v0, ap_uint<128l> v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method0(int32_t v0){
    bool v1;
    v1 = v0 < 1000l;
    return v1;
}
static inline Tuple1 TupleCreate1(int32_t v0, ap_uint<52l> v1, ap_uint<128l> v2){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
bool method1(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
static inline Tuple2 TupleCreate2(ap_uint<52l> v0, ap_uint<4l> v1, ap_uint<2l> v2, ap_uint<128l> v3){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3;
    return x;
}
static inline Tuple3 TupleCreate3(ap_uint<52l> v0, ap_uint<6l> v1, ap_uint<128l> v2){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static inline Tuple4 TupleCreate4(int32_t v0, uint32_t v1){
    Tuple4 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method4(int32_t v0){
    bool v1;
    v1 = v0 < 52l;
    return v1;
}
static inline Tuple5 TupleCreate5(ap_uint<6l> v0, ap_uint<128l> v1){
    Tuple5 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple6 TupleCreate6(ap_uint<60l> v0, ap_uint<128l> v1){
    Tuple6 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method7(int32_t v0){
    bool v1;
    v1 = v0 < 60l;
    return v1;
}
Tuple6 random_ap6(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<60l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple0 tmp3 = TupleCreate0(0l, v0);
    v2 = tmp3.v0; v3 = tmp3.v1;
    while (method7(v2)){
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
    return TupleCreate6(v1, v3);
}
Tuple5 random_ap_in_range5(ap_uint<6l> v0, ap_uint<6l> v1, ap_uint<128l> v2){
    #pragma HLS PIPELINE II=1l
    ap_uint<6l> v3;
    v3 = v0 - v1;
    ap_uint<60l> v4; ap_uint<128l> v5;
    Tuple6 tmp4 = random_ap6(v2);
    v4 = tmp4.v0; v5 = tmp4.v1;
    ap_uint<6l> v6;
    v6 = v4 % v3;
    ap_uint<6l> v7;
    v7 = v6 + v1;
    return TupleCreate5(v7, v5);
}
static inline Tuple7 TupleCreate7(int32_t v0, ap_uint<6l> v1, ap_uint<6l> v2){
    Tuple7 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple3 sample3(ap_uint<52l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    int32_t v2; uint32_t v3;
    Tuple4 tmp2 = TupleCreate4(0l, 0ul);
    v2 = tmp2.v0; v3 = tmp2.v1;
    while (method4(v2)){
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
    v9 = 0;
    ap_uint<6l> v10;
    v10 = v3;
    ap_uint<6l> v11; ap_uint<128l> v12;
    Tuple5 tmp5 = random_ap_in_range5(v10, v9, v1);
    v11 = tmp5.v0; v12 = tmp5.v1;
    ap_uint<6l> v13;
    v13 = 0ul;
    ap_uint<6l> v14;
    v14 = v11 + 1;
    int32_t v15; ap_uint<6l> v16; ap_uint<6l> v17;
    Tuple7 tmp6 = TupleCreate7(0l, v13, v14);
    v15 = tmp6.v0; v16 = tmp6.v1; v17 = tmp6.v2;
    while (method4(v15)){
        ap_uint<6l> v19;
        v19 = 0ul;
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
    v28 = 1;
    ap_uint<52l> v29;
    v29 = v28 << v16;
    ap_uint<52l> v30;
    v30 = v0 | v29;
    return TupleCreate3(v30, v16, v12);
}
Tuple2 draw_card2(ap_uint<52l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    ap_uint<52l> v2; ap_uint<6l> v3; ap_uint<128l> v4;
    Tuple3 tmp7 = sample3(v0, v1);
    v2 = tmp7.v0; v3 = tmp7.v1; v4 = tmp7.v2;
    ap_uint<4l> v5;
    v5 = 13;
    ap_uint<4l> v6;
    v6 = v3 % v5;
    ap_uint<6l> v7;
    v7 = 13;
    ap_uint<2l> v8;
    v8 = v3 / v7;
    return TupleCreate2(v2, v6, v8, v4);
}
int32_t entry() {
    ap_uint<64l> v0;
    v0 = 0b1101011010100110111111000010111101111111100001011011100001111110;
    ap_uint<64l> v1;
    v1 = 0b1000001110011100000101101011010000000100101010110010110000110000;
    ap_uint<128l> v2;
    v2 = v0.concat(v1);
    int32_t v3; ap_uint<128l> v4;
    Tuple0 tmp0 = TupleCreate0(0l, v2);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (method0(v3)){
        ap_uint<52l> v6;
        v6 = 0;
        int32_t v7; ap_uint<52l> v8; ap_uint<128l> v9;
        Tuple1 tmp1 = TupleCreate1(0l, v6, v4);
        v7 = tmp1.v0; v8 = tmp1.v1; v9 = tmp1.v2;
        while (method1(v7)){
            ap_uint<52l> v11; ap_uint<4l> v12; ap_uint<2l> v13; ap_uint<128l> v14;
            Tuple2 tmp8 = draw_card2(v8, v9);
            v11 = tmp8.v0; v12 = tmp8.v1; v13 = tmp8.v2; v14 = tmp8.v3;
            std::cout << std::bitset<52l>(v11) << std::endl;
            std::cout << "Suit: " << v13 << " Rank: " << v12 << std::endl;
            std::cout << "---" << std::endl;
            v8 = v11;
            v9 = v14;
            v7++;
        }
        std::cout << "***" << std::endl;
        v4 = v9;
        v3++;
    }
    return 0l;
}
