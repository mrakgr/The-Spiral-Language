#include <cstdint>
#include <array>
#include "ap_int.h"
#include <random>
#include <iostream>
#include <algorithm>
struct Tuple0;
bool method0(uint64_t v0);
struct Tuple1;
bool method1(int32_t v0);
struct Tuple2;
struct Tuple3;
bool method3(int32_t v0);
typedef bool (* Fun0)(Tuple2, Tuple2);
Tuple3 score2(std::array<Tuple2,5l> v0);
struct Tuple0 {
    uint64_t v0;
    int32_t v1;
};
struct Tuple1 {
    int8_t v0;
    int8_t v1;
};
struct Tuple2 {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
};
struct Tuple3 {
    std::array<Tuple2,5l> v0;
    ap_uint<4l> v1;
};
static inline Tuple0 TupleCreate0(uint64_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method0(uint64_t v0){
    bool v1;
    v1 = v0 < 1ull;
    return v1;
}
static inline Tuple1 TupleCreate1(int8_t v0, int8_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method1(int32_t v0){
    bool v1;
    v1 = v0 > 0l;
    return v1;
}
static inline Tuple2 TupleCreate2(ap_uint<4l> v0, ap_uint<2l> v1){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple3 TupleCreate3(std::array<Tuple2,5l> v0, ap_uint<4l> v1){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method3(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
bool ClosureMethod0(Tuple2 tup0, Tuple2 tup1){
    ap_uint<4l> v0 = tup0.v0; ap_uint<2l> v1 = tup0.v1; ap_uint<4l> v2 = tup1.v0; ap_uint<2l> v3 = tup1.v1;
    bool v4;
    v4 = v0 > v2;
    if (v4){
        return true;
    } else {
        bool v5;
        v5 = v0 == v2;
        if (v5){
            bool v6;
            v6 = v1 < v3;
            return v6;
        } else {
            return false;
        }
    }
}
Tuple3 score2(std::array<Tuple2,5l> v0){
    std::array<Tuple2,5l> v1;
    int32_t v2;
    v2 = 0l;
    while (method3(v2)){
        ap_uint<4l> v4; ap_uint<2l> v5;
        Tuple2 tmp6 = v0[v2];
        v4 = tmp6.v0; v5 = tmp6.v1;
        v1[v2] = TupleCreate2(v4, v5);
        v2++;
    }
    Fun0 v6;
    v6 = ClosureMethod0;
    std::stable_sort(v1.begin(),v1.end(),v6);
    std::array<Tuple2,5l> v7;
    int32_t v8;
    v8 = 0l;
    while (method3(v8)){
        ap_uint<4l> v10; ap_uint<2l> v11;
        Tuple2 tmp7 = v1[v8];
        v10 = tmp7.v0; v11 = tmp7.v1;
        v7[v8] = TupleCreate2(v10, v11);
        v8++;
    }
    ap_uint<4l> v12;
    v12 = 0ul;
    return TupleCreate3(v7, v12);
}
int32_t entry() {
    std::random_device v0;
    std::mt19937 v1(v0());
    std::uniform_int_distribution<std::mt19937::result_type> v2(0,51);
    uint64_t v3; int32_t v4;
    Tuple0 tmp0 = TupleCreate0(0ull, 0l);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (method0(v3)){
        std::array<Tuple1,5l> v6;
        uint64_t v7;
        v7 = 0ull;
        int32_t v8;
        v8 = 5l;
        while (method1(v8)){
            int8_t v10;
            v10 = v2(v1);
            int32_t v11;
            v11 = (int32_t)v10;
            uint64_t v12;
            v12 = 1ull << v11;
            uint64_t v13;
            v13 = v7 & v12;
            bool v14;
            v14 = v13 == 0ull;
            bool v15;
            v15 = v14 != true;
            int32_t v22;
            if (v15){
                v22 = v8;
            } else {
                int32_t v16;
                v16 = v8 - 1l;
                int8_t v17;
                v17 = v10 % 13;
                int8_t v18;
                v18 = v10 / 13;
                v6[v16] = TupleCreate1(v17, v18);
                int32_t v19;
                v19 = (int32_t)v10;
                uint64_t v20;
                v20 = 1ull << v19;
                uint64_t v21;
                v21 = v7 | v20;
                v7 = v21;
                v22 = v16;
            }
            v8 = v22;
        }
        int8_t v23; int8_t v24;
        Tuple1 tmp1 = v6[0l];
        v23 = tmp1.v0; v24 = tmp1.v1;
        int8_t v25; int8_t v26;
        Tuple1 tmp2 = v6[1l];
        v25 = tmp2.v0; v26 = tmp2.v1;
        int8_t v27; int8_t v28;
        Tuple1 tmp3 = v6[2l];
        v27 = tmp3.v0; v28 = tmp3.v1;
        int8_t v29; int8_t v30;
        Tuple1 tmp4 = v6[3l];
        v29 = tmp4.v0; v30 = tmp4.v1;
        int8_t v31; int8_t v32;
        Tuple1 tmp5 = v6[4l];
        v31 = tmp5.v0; v32 = tmp5.v1;
        std::array<Tuple2,5l> v33;
        uint32_t v34;
        v34 = (uint32_t)v23;
        ap_uint<4l> v35;
        v35 = v34;
        uint32_t v36;
        v36 = (uint32_t)v24;
        ap_uint<2l> v37;
        v37 = v36;
        v33[0l] = TupleCreate2(v35, v37);
        uint32_t v38;
        v38 = (uint32_t)v25;
        ap_uint<4l> v39;
        v39 = v38;
        uint32_t v40;
        v40 = (uint32_t)v26;
        ap_uint<2l> v41;
        v41 = v40;
        v33[1l] = TupleCreate2(v39, v41);
        uint32_t v42;
        v42 = (uint32_t)v27;
        ap_uint<4l> v43;
        v43 = v42;
        uint32_t v44;
        v44 = (uint32_t)v28;
        ap_uint<2l> v45;
        v45 = v44;
        v33[2l] = TupleCreate2(v43, v45);
        uint32_t v46;
        v46 = (uint32_t)v29;
        ap_uint<4l> v47;
        v47 = v46;
        uint32_t v48;
        v48 = (uint32_t)v30;
        ap_uint<2l> v49;
        v49 = v48;
        v33[3l] = TupleCreate2(v47, v49);
        uint32_t v50;
        v50 = (uint32_t)v31;
        ap_uint<4l> v51;
        v51 = v50;
        uint32_t v52;
        v52 = (uint32_t)v32;
        ap_uint<2l> v53;
        v53 = v52;
        v33[4l] = TupleCreate2(v51, v53);
        std::array<Tuple2,5l> v54; ap_uint<4l> v55;
        Tuple3 tmp8 = score2(v33);
        v54 = tmp8.v0; v55 = tmp8.v1;
        ap_uint<4l> v56; ap_uint<2l> v57;
        Tuple2 tmp9 = v54[0l];
        v56 = tmp9.v0; v57 = tmp9.v1;
        int8_t v58;
        v58 = v57;
        int8_t v59;
        v59 = v56;
        ap_uint<4l> v60; ap_uint<2l> v61;
        Tuple2 tmp10 = v54[1l];
        v60 = tmp10.v0; v61 = tmp10.v1;
        int8_t v62;
        v62 = v61;
        int8_t v63;
        v63 = v60;
        ap_uint<4l> v64; ap_uint<2l> v65;
        Tuple2 tmp11 = v54[2l];
        v64 = tmp11.v0; v65 = tmp11.v1;
        int8_t v66;
        v66 = v65;
        int8_t v67;
        v67 = v64;
        ap_uint<4l> v68; ap_uint<2l> v69;
        Tuple2 tmp12 = v54[3l];
        v68 = tmp12.v0; v69 = tmp12.v1;
        int8_t v70;
        v70 = v69;
        int8_t v71;
        v71 = v68;
        ap_uint<4l> v72; ap_uint<2l> v73;
        Tuple2 tmp13 = v54[4l];
        v72 = tmp13.v0; v73 = tmp13.v1;
        int8_t v74;
        v74 = v73;
        int8_t v75;
        v75 = v72;
        int8_t v76;
        v76 = v55;
        int32_t v77;
        v77 = 0l;
        v4 = v77;
        v3++;
    }
    return v4;
}
