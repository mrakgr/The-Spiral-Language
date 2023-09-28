#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
#include <cstring>
struct Tuple0;
bool method0(int32_t v0);
struct Tuple1;
struct Tuple2;
bool method3(int32_t v0);
Tuple2 random_ap2(ap_uint<128l> v0);
Tuple1 random_f321(ap_uint<128l> v0);
struct Tuple0 {
    ap_uint<128l> v1;
    int32_t v0;
};
struct Tuple1 {
    ap_uint<128l> v1;
    float v0;
};
struct Tuple2 {
    ap_uint<23l> v0;
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
static inline Tuple2 TupleCreate2(ap_uint<23l> v0, ap_uint<128l> v1){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method3(int32_t v0){
    bool v1;
    v1 = v0 < 23l;
    return v1;
}
Tuple2 random_ap2(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<23l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple0 tmp1 = TupleCreate0(0l, v0);
    v2 = tmp1.v0; v3 = tmp1.v1;
    while (method3(v2)){
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
Tuple1 random_f321(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<23l> v1; ap_uint<128l> v2;
    Tuple2 tmp2 = random_ap2(v0);
    v1 = tmp2.v0; v2 = tmp2.v1;
    ap_uint<8l> v3;
    v3 = 127;
    ap_uint<1l> v4;
    v4 = 0b0;
    ap_uint<31l> v5;
    v5 = v3.concat(v1);
    ap_uint<32l> v6;
    v6 = v4.concat(v5);
    uint32_t v7;
    v7 = static_cast<uint32_t>(v6);
    float v8;
    v8 = 0.0f;
    static_assert(sizeof(uint32_t) == sizeof(float), "float has a weird size");
    std::memcpy(&v8,&v7,sizeof(float));
    float v9;
    v9 = v8 - 1.0f;
    return TupleCreate1(v9, v2);
}
void entry() {
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
        float v6; ap_uint<128l> v7;
        Tuple1 tmp3 = random_f321(v4);
        v6 = tmp3.v0; v7 = tmp3.v1;
        std::cout << v6 << std::endl;
        v4 = v7;
        v3++;
    }
    return ;
}
