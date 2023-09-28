#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
#include <cstring>
#include <cmath>
struct Tuple0;
bool method0(int32_t v0);
struct Tuple1;
struct Tuple2;
bool method4(int32_t v0);
Tuple2 random_ap3(ap_uint<128l> v0);
struct Tuple3;
bool method6(int32_t v0);
Tuple3 random_ap5(ap_uint<128l> v0);
Tuple1 random_f32_template2(bool v0, ap_uint<128l> v1);
Tuple1 random_gaussian_f321(float v0, float v1, ap_uint<128l> v2);
struct Tuple0 {
    ap_uint<128l> v1;
    int32_t v0;
};
struct Tuple1 {
    ap_uint<128l> v1;
    float v0;
};
struct Tuple2 {
    ap_uint<22l> v0;
    ap_uint<128l> v1;
};
struct Tuple3 {
    ap_uint<1l> v0;
    ap_uint<128l> v1;
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
static inline Tuple1 TupleCreate1(float v0, ap_uint<128l> v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple2 TupleCreate2(ap_uint<22l> v0, ap_uint<128l> v1){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method4(int32_t v0){
    bool v1;
    v1 = v0 < 22l;
    return v1;
}
Tuple2 random_ap3(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<22l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple0 tmp1 = TupleCreate0(0l, v0);
    v2 = tmp1.v0; v3 = tmp1.v1;
    while (method4(v2)){
        ap_uint<1l> v5;
        v5 = v3[0l];
        ap_uint<1l> v6;
        v6 = v3[1l];
        ap_uint<1l> v7;
        v7 = v5 ^ v6;
        ap_uint<1l> v8;
        v8 = v3[2l];
        ap_uint<1l> v9;
        v9 = v3[7l];
        ap_uint<1l> v10;
        v10 = v8 ^ v9;
        ap_uint<1l> v11;
        v11 = v7 ^ v10;
        v1[v2] = v11;
        ap_uint<128l> v12;
        v12 = v3 >> 1l;
        v12[127l] = v11;
        v3 = v12;
        v2++;
    }
    return TupleCreate2(v1, v3);
}
static inline Tuple3 TupleCreate3(ap_uint<1l> v0, ap_uint<128l> v1){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method6(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
Tuple3 random_ap5(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<1l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple0 tmp3 = TupleCreate0(0l, v0);
    v2 = tmp3.v0; v3 = tmp3.v1;
    while (method6(v2)){
        ap_uint<1l> v5;
        v5 = v3[0l];
        ap_uint<1l> v6;
        v6 = v3[1l];
        ap_uint<1l> v7;
        v7 = v5 ^ v6;
        ap_uint<1l> v8;
        v8 = v3[2l];
        ap_uint<1l> v9;
        v9 = v3[7l];
        ap_uint<1l> v10;
        v10 = v8 ^ v9;
        ap_uint<1l> v11;
        v11 = v7 ^ v10;
        v1[v2] = v11;
        ap_uint<128l> v12;
        v12 = v3 >> 1l;
        v12[127l] = v11;
        v3 = v12;
        v2++;
    }
    return TupleCreate3(v1, v3);
}
Tuple1 random_f32_template2(bool v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    ap_uint<22l> v2; ap_uint<128l> v3;
    Tuple2 tmp2 = random_ap3(v1);
    v2 = tmp2.v0; v3 = tmp2.v1;
    ap_uint<1l> v7; ap_uint<128l> v8;
    if (v0){
        ap_uint<1l> v4;
        v4 = 1;
        v7 = v4; v8 = v3;
    } else {
        Tuple3 tmp4 = random_ap5(v3);
        v7 = tmp4.v0; v8 = tmp4.v1;
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
    return TupleCreate1(v16, v8);
}
Tuple1 random_gaussian_f321(float v0, float v1, ap_uint<128l> v2){
    #pragma HLS PIPELINE II=1l
    bool v3;
    v3 = true;
    float v4; ap_uint<128l> v5;
    Tuple1 tmp5 = random_f32_template2(v3, v2);
    v4 = tmp5.v0; v5 = tmp5.v1;
    bool v6;
    v6 = false;
    float v7; ap_uint<128l> v8;
    Tuple1 tmp6 = random_f32_template2(v6, v5);
    v7 = tmp6.v0; v8 = tmp6.v1;
    float v9;
    v9 = log(v4);
    float v10;
    v10 = -2.0f * v9;
    float v11;
    v11 = sqrt(v10);
    float v12;
    v12 = v0 * v11;
    float v13;
    v13 = 6.2831855f * v7;
    float v14;
    v14 = cos(v13);
    float v15;
    v15 = v12 * v14;
    float v16;
    v16 = v15 + v1;
    return TupleCreate1(v16, v8);
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
        float v6;
        v6 = 0.0f;
        float v7;
        v7 = 1.0f;
        float v8; ap_uint<128l> v9;
        Tuple1 tmp7 = random_gaussian_f321(v7, v6, v4);
        v8 = tmp7.v0; v9 = tmp7.v1;
        std::cout << v8 << std::endl;
        v4 = v9;
        v3++;
    }
    return 0l;
}
