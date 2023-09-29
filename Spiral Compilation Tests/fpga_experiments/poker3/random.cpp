#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
#include <cstring>
bool method0(int32_t v0);
struct Tuple0;
bool method1(int32_t v0);
struct Tuple1;
bool method3(std::array<float,3l> v0, int32_t v1);
struct Tuple2;
struct Tuple3;
bool method6(int32_t v0);
Tuple3 random_ap5(ap_uint<128l> v0);
struct Tuple4;
bool method8(int32_t v0);
Tuple4 random_ap7(ap_uint<128l> v0);
Tuple2 random_f32_template4(bool v0, ap_uint<128l> v1);
struct US0;
struct Tuple5;
Tuple0 sample_discrete_2(std::array<float,3l> v0, ap_uint<128l> v1);
struct Tuple0 {
    ap_uint<128l> v1;
    int32_t v0;
};
struct Tuple1 {
    std::array<float,3l> v0;
    int32_t v1;
};
struct Tuple2 {
    ap_uint<128l> v1;
    float v0;
};
struct Tuple3 {
    ap_uint<22l> v0;
    ap_uint<128l> v1;
};
struct Tuple4 {
    ap_uint<1l> v0;
    ap_uint<128l> v1;
};
struct US0 {
    ap_uint<2> tag;
    union U {
        struct {
            int32_t v0;
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
struct Tuple5 {
    US0 v1;
    int32_t v0;
};
bool method0(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
static inline Tuple0 TupleCreate0(int32_t v0, ap_uint<128l> v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method1(int32_t v0){
    bool v1;
    v1 = v0 < 10000l;
    return v1;
}
static inline Tuple1 TupleCreate1(std::array<float,3l> v0, int32_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method3(std::array<float,3l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 3l;
    return v2;
}
static inline Tuple2 TupleCreate2(float v0, ap_uint<128l> v1){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple3 TupleCreate3(ap_uint<22l> v0, ap_uint<128l> v1){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method6(int32_t v0){
    bool v1;
    v1 = v0 < 22l;
    return v1;
}
Tuple3 random_ap5(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<22l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple0 tmp2 = TupleCreate0(0l, v0);
    v2 = tmp2.v0; v3 = tmp2.v1;
    while (method6(v2)){
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
    return TupleCreate3(v1, v3);
}
static inline Tuple4 TupleCreate4(ap_uint<1l> v0, ap_uint<128l> v1){
    Tuple4 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method8(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
Tuple4 random_ap7(ap_uint<128l> v0){
    #pragma HLS PIPELINE II=1l
    ap_uint<1l> v1;
    v1 = 0;
    int32_t v2; ap_uint<128l> v3;
    Tuple0 tmp4 = TupleCreate0(0l, v0);
    v2 = tmp4.v0; v3 = tmp4.v1;
    while (method8(v2)){
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
    return TupleCreate4(v1, v3);
}
Tuple2 random_f32_template4(bool v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    ap_uint<22l> v2; ap_uint<128l> v3;
    Tuple3 tmp3 = random_ap5(v1);
    v2 = tmp3.v0; v3 = tmp3.v1;
    ap_uint<1l> v7; ap_uint<128l> v8;
    if (v0){
        ap_uint<1l> v4;
        v4 = 1;
        v7 = v4; v8 = v3;
    } else {
        Tuple4 tmp5 = random_ap7(v3);
        v7 = tmp5.v0; v8 = tmp5.v1;
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
    return TupleCreate2(v16, v8);
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(int32_t v0) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
static inline Tuple5 TupleCreate5(int32_t v0, US0 v1){
    Tuple5 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 sample_discrete_2(std::array<float,3l> v0, ap_uint<128l> v1){
    #pragma HLS PIPELINE II=1l
    std::array<float,3l> v2;
    int32_t v3;
    v3 = 0l;
    while (method0(v3)){
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
    std::array<float,3l> v8; int32_t v9;
    Tuple1 tmp1 = TupleCreate1(v2, 1l);
    v8 = tmp1.v0; v9 = tmp1.v1;
    while (method3(v8, v9)){
        #pragma HLS UNROLL
        std::array<float,3l> v11;
        int32_t v12;
        v12 = 0l;
        while (method0(v12)){
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
    v22 = v8[2l];
    std::array<float,3l> v23;
    int32_t v24;
    v24 = 0l;
    while (method0(v24)){
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
    Tuple2 tmp6 = random_f32_template4(v28, v1);
    v29 = tmp6.v0; v30 = tmp6.v1;
    US0 v31;
    v31 = US0_0();
    int32_t v32; US0 v33;
    Tuple5 tmp7 = TupleCreate5(0l, v31);
    v32 = tmp7.v0; v33 = tmp7.v1;
    while (method0(v32)){
        float v35;
        v35 = v23[v32];
        US0 v39;
        switch (v33.tag) {
            case 0: { // None
                bool v36;
                v36 = v29 < v35;
                if (v36){
                    v39 = US0_1(v32);
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
    return TupleCreate0(v42, v30);
}
int32_t entry() {
    std::array<float,3l> v0;
    int32_t v1;
    v1 = 0l;
    while (method0(v1)){
        float v3;
        v3 = v1+1;
        v0[v1] = v3;
        v1++;
    }
    ap_uint<64l> v4;
    v4 = 0b1101011010100110111111000010111101111111100001011011100001111110;
    ap_uint<64l> v5;
    v5 = 0b1000001110011100000101101011010000000100101010110010110000110000;
    ap_uint<128l> v6;
    v6 = v4.concat(v5);
    int32_t v7; ap_uint<128l> v8;
    Tuple0 tmp0 = TupleCreate0(0l, v6);
    v7 = tmp0.v0; v8 = tmp0.v1;
    while (method1(v7)){
        int32_t v10; ap_uint<128l> v11;
        Tuple0 tmp8 = sample_discrete_2(v0, v8);
        v10 = tmp8.v0; v11 = tmp8.v1;
        std::cout << v10 << std::endl;
        v8 = v11;
        v7++;
    }
    return 0l;
}
