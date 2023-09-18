#ifndef _ENTRY
#define _ENTRY
#include <cstdint>
#include "ap_int.h"
template <int dim, typename el> struct array { el v[dim]; };
#include <random>
#include <iostream>
#include <algorithm>
typedef struct {
    uint64_t v0;
    int32_t v1;
} Tuple0;
typedef struct {
    int8_t v0;
    int8_t v1;
} Tuple1;
typedef struct {
    int8_t v0;
    int8_t v1;
    int8_t v2;
    int8_t v3;
    int8_t v4;
    int8_t v5;
} Tuple2;
typedef struct {
    uint16_t v1;
    int8_t v0;
} Tuple3;
typedef struct {
    uint64_t v1;
    int8_t v0;
} Tuple4;
typedef struct {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
} Tuple5;
typedef struct {
    array<5l,Tuple5> v0;
    ap_uint<4l> v1;
} Tuple6;
typedef bool (* Fun0)(Tuple5, Tuple5);
typedef struct {
    ap_uint<4l> v3;
    int32_t v0;
    int32_t v1;
    int32_t v2;
} Tuple7;
struct US0 {
    ap_uint<2> tag;
    union U {
        struct {
            array<2l,Tuple5> v0;
            array<3l,Tuple5> v1;
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
            array<5l,Tuple5> v0;
        } case1; // Some
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
struct US2 {
    ap_uint<2> tag;
    union U {
        struct {
            array<2l,Tuple5> v0;
            array<1l,Tuple5> v1;
        } case1; // Some
        U() {}
    } v;
    US2() {}
    US2(const US2 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US2(const US2 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US2 & operator=(US2 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US2 & operator=(US2 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US3 {
    ap_uint<2> tag;
    union U {
        struct {
            array<3l,Tuple5> v0;
            array<2l,Tuple5> v1;
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
typedef struct {
    ap_uint<4l> v2;
    int32_t v1;
    int32_t v0;
} Tuple8;
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple9;
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
typedef struct {
    US4 v1;
    int32_t v0;
} Tuple10;
struct US5 {
    ap_uint<2> tag;
    union U {
        struct {
            array<2l,Tuple5> v0;
            array<0l,Tuple5> v1;
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
            array<4l,Tuple5> v0;
            array<1l,Tuple5> v1;
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
            array<5l,Tuple5> v0;
            ap_uint<4l> v1;
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
bool method0(uint64_t v0);
bool method1(int32_t v0);
bool method4(int8_t v0);
bool method5(int8_t v0);
uint32_t loop_ranks7(uint64_t v0, int8_t v1, int8_t v2);
uint32_t try_suit6(uint64_t v0, uint16_t v1, int8_t v2);
uint32_t loop9(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_suits11(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5);
uint32_t loop_ranks10(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_ranks15(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t try_suit14(uint64_t v0, uint16_t v1, int8_t v2);
uint32_t loop_suits21(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5, uint32_t v6);
uint32_t loop_ranks20(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5);
uint32_t loop_suits24(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_ranks23(uint64_t v0, int8_t v1, int8_t v2, uint32_t v3);
uint64_t loop_pair22(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_pair19(uint64_t v0, uint64_t v1, int8_t v2, uint32_t v3, int8_t v4);
uint64_t loop_pair_18(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_triple17(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop16(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_pair13(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3, uint32_t v4, int8_t v5);
uint64_t loop_triple12(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3);
uint64_t loop_ranks8(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3);
uint64_t method3(uint64_t v0);
Tuple2 score_2(uint64_t v0);
bool method26(int32_t v0);
bool method27(int32_t v0, int32_t v1);
bool method28(int32_t v0);
bool method29(int32_t v0);
bool method30(int32_t v0);
bool method31(int32_t v0);
bool method32(int32_t v0);
Tuple6 score25(array<5l,Tuple5> v0);
static inline Tuple0 TupleCreate0(uint64_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method0(uint64_t v0){
    bool v1;
    v1 = v0 < 10000000ull;
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
static inline Tuple2 TupleCreate2(int8_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4; x.v5 = v5;
    return x;
}
static inline Tuple3 TupleCreate3(int8_t v0, uint16_t v1){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method4(int8_t v0){
    bool v1;
    v1 = v0 < 13;
    return v1;
}
bool method5(int8_t v0){
    bool v1;
    v1 = v0 < 4;
    return v1;
}
static inline Tuple4 TupleCreate4(int8_t v0, uint64_t v1){
    Tuple4 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
uint32_t loop_ranks7(uint64_t v0, int8_t v1, int8_t v2){
    bool v3;
    v3 = -1 <= v2;
    if (v3){
        int8_t v4;
        v4 = v2 + 4;
        int8_t v5;
        v5 = v1 * 13;
        int8_t v6;
        v6 = v5 + v4;
        int32_t v7;
        v7 = (int32_t)v6;
        uint64_t v8;
        v8 = v0 >> v7;
        uint8_t v9;
        v9 = (uint8_t)v8;
        uint8_t v10;
        v10 = v9 & 1u;
        int8_t v11;
        v11 = v2 + 3;
        int8_t v12;
        v12 = v5 + v11;
        int32_t v13;
        v13 = (int32_t)v12;
        uint64_t v14;
        v14 = v0 >> v13;
        uint8_t v15;
        v15 = (uint8_t)v14;
        uint8_t v16;
        v16 = v15 & 1u;
        uint8_t v17;
        v17 = v10 & v16;
        int8_t v18;
        v18 = v2 + 2;
        int8_t v19;
        v19 = v5 + v18;
        int32_t v20;
        v20 = (int32_t)v19;
        uint64_t v21;
        v21 = v0 >> v20;
        uint8_t v22;
        v22 = (uint8_t)v21;
        uint8_t v23;
        v23 = v22 & 1u;
        uint8_t v24;
        v24 = v17 & v23;
        int8_t v25;
        v25 = v2 + 1;
        int8_t v26;
        v26 = v5 + v25;
        int32_t v27;
        v27 = (int32_t)v26;
        uint64_t v28;
        v28 = v0 >> v27;
        uint8_t v29;
        v29 = (uint8_t)v28;
        uint8_t v30;
        v30 = v29 & 1u;
        uint8_t v31;
        v31 = v24 & v30;
        bool v32;
        v32 = v2 < 0;
        int8_t v34;
        if (v32){
            int8_t v33;
            v33 = v2 + 13;
            v34 = v33;
        } else {
            v34 = v2;
        }
        int8_t v35;
        v35 = v5 + v34;
        int32_t v36;
        v36 = (int32_t)v35;
        uint64_t v37;
        v37 = v0 >> v36;
        uint8_t v38;
        v38 = (uint8_t)v37;
        uint8_t v39;
        v39 = v38 & 1u;
        uint8_t v40;
        v40 = v31 & v39;
        bool v41;
        v41 = (bool)v40;
        if (v41){
            uint32_t v42;
            v42 = (uint32_t)v6;
            uint32_t v43;
            v43 = v42 << 6l;
            uint32_t v44;
            v44 = (uint32_t)v12;
            uint32_t v45;
            v45 = v43 + v44;
            uint32_t v46;
            v46 = v45 << 6l;
            uint32_t v47;
            v47 = (uint32_t)v19;
            uint32_t v48;
            v48 = v46 + v47;
            uint32_t v49;
            v49 = v48 << 6l;
            uint32_t v50;
            v50 = (uint32_t)v26;
            uint32_t v51;
            v51 = v49 + v50;
            int8_t v53;
            if (v32){
                int8_t v52;
                v52 = v2 + 13;
                v53 = v52;
            } else {
                v53 = v2;
            }
            uint32_t v54;
            v54 = v51 << 6l;
            int8_t v55;
            v55 = v5 + v53;
            uint32_t v56;
            v56 = (uint32_t)v55;
            uint32_t v57;
            v57 = v54 + v56;
            return v57;
        } else {
            int8_t v58;
            v58 = v2 - 1;
            return loop_ranks7(v0, v1, v58);
        }
    } else {
        return 0ul;
    }
}
uint32_t try_suit6(uint64_t v0, uint16_t v1, int8_t v2){
    int8_t v3;
    v3 = 4 * v2;
    int32_t v4;
    v4 = (int32_t)v3;
    uint16_t v5;
    v5 = v1 >> v4;
    int8_t v6;
    v6 = (int8_t)v5;
    int8_t v7;
    v7 = v6 & 15;
    bool v8;
    v8 = 5 <= v7;
    if (v8){
        int8_t v9;
        v9 = 8;
        return loop_ranks7(v0, v2, v9);
    } else {
        return 0ul;
    }
}
uint32_t loop9(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
    bool v5;
    v5 = v2 < 4;
    bool v7;
    if (v5){
        bool v6;
        v6 = 0 < v3;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7){
        int8_t v8;
        v8 = v2 * 13;
        int8_t v9;
        v9 = v8 + v1;
        int32_t v10;
        v10 = (int32_t)v9;
        uint64_t v11;
        v11 = v0 >> v10;
        uint8_t v12;
        v12 = (uint8_t)v11;
        uint8_t v13;
        v13 = v12 & 1u;
        bool v14;
        v14 = (bool)v13;
        if (v14){
            int8_t v15;
            v15 = v2 + 1;
            int8_t v16;
            v16 = v3 - 1;
            uint32_t v17;
            v17 = v4 << 6l;
            uint32_t v18;
            v18 = (uint32_t)v9;
            uint32_t v19;
            v19 = v17 + v18;
            return loop9(v0, v1, v15, v16, v19);
        } else {
            int8_t v21;
            v21 = v2 + 1;
            return loop9(v0, v1, v21, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_suits11(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5){
    bool v6;
    v6 = 0 < v4;
    if (v6){
        bool v7;
        v7 = v3 < 4;
        if (v7){
            int8_t v8;
            v8 = v3 * 13;
            int8_t v9;
            v9 = v8 + v2;
            int32_t v10;
            v10 = (int32_t)v9;
            uint64_t v11;
            v11 = v0 >> v10;
            uint8_t v12;
            v12 = (uint8_t)v11;
            uint8_t v13;
            v13 = v12 & 1u;
            bool v14;
            v14 = (bool)v13;
            if (v14){
                int8_t v15;
                v15 = v3 + 1;
                int8_t v16;
                v16 = v4 - 1;
                uint32_t v17;
                v17 = v5 << 6l;
                uint32_t v18;
                v18 = (uint32_t)v9;
                uint32_t v19;
                v19 = v17 + v18;
                return loop_suits11(v0, v1, v2, v15, v16, v19);
            } else {
                int8_t v21;
                v21 = v3 + 1;
                return loop_suits11(v0, v1, v2, v21, v4, v5);
            }
        } else {
            int8_t v24;
            v24 = v2 - 1;
            return loop_ranks10(v0, v1, v24, v4, v5);
        }
    } else {
        return v5;
    }
}
uint32_t loop_ranks10(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
    bool v5;
    v5 = 0 <= v2;
    if (v5){
        bool v6;
        v6 = v1 == v2;
        if (v6){
            int8_t v7;
            v7 = v2 - 1;
            return loop_ranks10(v0, v1, v7, v3, v4);
        } else {
            int8_t v9;
            v9 = 0;
            return loop_suits11(v0, v1, v2, v9, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_ranks15(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
    bool v5;
    v5 = 0 <= v2;
    bool v7;
    if (v5){
        bool v6;
        v6 = 0 < v3;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7){
        int8_t v8;
        v8 = v1 * 13;
        int8_t v9;
        v9 = v8 + v2;
        int32_t v10;
        v10 = (int32_t)v9;
        uint64_t v11;
        v11 = v0 >> v10;
        uint8_t v12;
        v12 = (uint8_t)v11;
        uint8_t v13;
        v13 = v12 & 1u;
        bool v14;
        v14 = (bool)v13;
        if (v14){
            int8_t v15;
            v15 = v2 - 1;
            int8_t v16;
            v16 = v3 - 1;
            uint32_t v17;
            v17 = v4 << 6l;
            uint32_t v18;
            v18 = (uint32_t)v9;
            uint32_t v19;
            v19 = v17 + v18;
            return loop_ranks15(v0, v1, v15, v16, v19);
        } else {
            int8_t v21;
            v21 = v2 - 1;
            return loop_ranks15(v0, v1, v21, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t try_suit14(uint64_t v0, uint16_t v1, int8_t v2){
    int8_t v3;
    v3 = 4 * v2;
    int32_t v4;
    v4 = (int32_t)v3;
    uint16_t v5;
    v5 = v1 >> v4;
    int8_t v6;
    v6 = (int8_t)v5;
    int8_t v7;
    v7 = v6 & 15;
    bool v8;
    v8 = 5 <= v7;
    if (v8){
        int8_t v9;
        v9 = 12;
        int8_t v10;
        v10 = 5;
        uint32_t v11;
        v11 = 0ul;
        return loop_ranks15(v0, v2, v9, v10, v11);
    } else {
        return 0ul;
    }
}
uint32_t loop_suits21(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5, uint32_t v6){
    bool v7;
    v7 = 0 < v5;
    if (v7){
        bool v8;
        v8 = v4 < 4;
        if (v8){
            int8_t v9;
            v9 = v4 * 13;
            int8_t v10;
            v10 = v9 + v3;
            int32_t v11;
            v11 = (int32_t)v10;
            uint64_t v12;
            v12 = v0 >> v11;
            uint8_t v13;
            v13 = (uint8_t)v12;
            uint8_t v14;
            v14 = v13 & 1u;
            bool v15;
            v15 = (bool)v14;
            if (v15){
                int8_t v16;
                v16 = v4 + 1;
                int8_t v17;
                v17 = v5 - 1;
                uint32_t v18;
                v18 = v6 << 6l;
                uint32_t v19;
                v19 = (uint32_t)v10;
                uint32_t v20;
                v20 = v18 + v19;
                return loop_suits21(v0, v1, v2, v3, v16, v17, v20);
            } else {
                int8_t v22;
                v22 = v4 + 1;
                return loop_suits21(v0, v1, v2, v3, v22, v5, v6);
            }
        } else {
            int8_t v25;
            v25 = v3 - 1;
            return loop_ranks20(v0, v1, v2, v25, v5, v6);
        }
    } else {
        return v6;
    }
}
uint32_t loop_ranks20(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5){
    bool v6;
    v6 = 0 <= v3;
    if (v6){
        bool v7;
        v7 = v1 == v3;
        bool v9;
        if (v7){
            v9 = true;
        } else {
            bool v8;
            v8 = v2 == v3;
            v9 = v8;
        }
        if (v9){
            int8_t v10;
            v10 = v3 - 1;
            return loop_ranks20(v0, v1, v2, v10, v4, v5);
        } else {
            int8_t v12;
            v12 = 0;
            return loop_suits21(v0, v1, v2, v3, v12, v4, v5);
        }
    } else {
        return v5;
    }
}
uint32_t loop_suits24(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
    bool v5;
    v5 = 0 < v3;
    if (v5){
        bool v6;
        v6 = v2 < 4;
        if (v6){
            int8_t v7;
            v7 = v2 * 13;
            int8_t v8;
            v8 = v7 + v1;
            int32_t v9;
            v9 = (int32_t)v8;
            uint64_t v10;
            v10 = v0 >> v9;
            uint8_t v11;
            v11 = (uint8_t)v10;
            uint8_t v12;
            v12 = v11 & 1u;
            bool v13;
            v13 = (bool)v12;
            if (v13){
                int8_t v14;
                v14 = v2 + 1;
                int8_t v15;
                v15 = v3 - 1;
                uint32_t v16;
                v16 = v4 << 6l;
                uint32_t v17;
                v17 = (uint32_t)v8;
                uint32_t v18;
                v18 = v16 + v17;
                return loop_suits24(v0, v1, v14, v15, v18);
            } else {
                int8_t v20;
                v20 = v2 + 1;
                return loop_suits24(v0, v1, v20, v3, v4);
            }
        } else {
            int8_t v23;
            v23 = v1 - 1;
            return loop_ranks23(v0, v23, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_ranks23(uint64_t v0, int8_t v1, int8_t v2, uint32_t v3){
    bool v4;
    v4 = 0 <= v1;
    if (v4){
        int8_t v5;
        v5 = 0;
        return loop_suits24(v0, v1, v5, v2, v3);
    } else {
        return v3;
    }
}
uint64_t loop_pair22(uint64_t v0, uint64_t v1, int8_t v2){
    bool v3;
    v3 = 0 <= v2;
    if (v3){
        int8_t v4;
        v4 = 3 * v2;
        int32_t v5;
        v5 = (int32_t)v4;
        uint64_t v6;
        v6 = v0 >> v5;
        int8_t v7;
        v7 = (int8_t)v6;
        int8_t v8;
        v8 = v7 & 7;
        bool v9;
        v9 = v8 == 2;
        if (v9){
            int8_t v10;
            v10 = 0;
            int8_t v11;
            v11 = 2;
            uint32_t v12;
            v12 = 0ul;
            uint32_t v13;
            v13 = loop9(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            int8_t v15;
            v15 = 3;
            uint32_t v16;
            v16 = loop_ranks10(v1, v2, v14, v15, v13);
            uint64_t v17;
            v17 = (uint64_t)1;
            uint64_t v18;
            v18 = v17 << 32l;
            uint64_t v19;
            v19 = (uint64_t)v16;
            uint64_t v20;
            v20 = v18 | v19;
            return v20;
        } else {
            int8_t v21;
            v21 = v2 - 1;
            return loop_pair22(v0, v1, v21);
        }
    } else {
        int8_t v24;
        v24 = 12;
        int8_t v25;
        v25 = 5;
        uint32_t v26;
        v26 = 0ul;
        uint32_t v27;
        v27 = loop_ranks23(v1, v24, v25, v26);
        uint64_t v28;
        v28 = (uint64_t)0;
        uint64_t v29;
        v29 = v28 << 32l;
        uint64_t v30;
        v30 = (uint64_t)v27;
        uint64_t v31;
        v31 = v29 | v30;
        return v31;
    }
}
uint64_t loop_pair19(uint64_t v0, uint64_t v1, int8_t v2, uint32_t v3, int8_t v4){
    bool v5;
    v5 = v2 == v4;
    if (v5){
        int8_t v6;
        v6 = v4 - 1;
        return loop_pair19(v0, v1, v2, v3, v6);
    } else {
        bool v8;
        v8 = 0 <= v4;
        if (v8){
            int8_t v9;
            v9 = 3 * v4;
            int32_t v10;
            v10 = (int32_t)v9;
            uint64_t v11;
            v11 = v0 >> v10;
            int8_t v12;
            v12 = (int8_t)v11;
            int8_t v13;
            v13 = v12 & 7;
            bool v14;
            v14 = v13 == 2;
            if (v14){
                int8_t v15;
                v15 = 0;
                int8_t v16;
                v16 = 2;
                uint32_t v17;
                v17 = loop9(v1, v4, v15, v16, v3);
                int8_t v18;
                v18 = 12;
                int8_t v19;
                v19 = 1;
                uint32_t v20;
                v20 = loop_ranks20(v1, v2, v4, v18, v19, v17);
                uint64_t v21;
                v21 = (uint64_t)2;
                uint64_t v22;
                v22 = v21 << 32l;
                uint64_t v23;
                v23 = (uint64_t)v20;
                uint64_t v24;
                v24 = v22 | v23;
                return v24;
            } else {
                int8_t v25;
                v25 = v4 - 1;
                return loop_pair19(v0, v1, v2, v3, v25);
            }
        } else {
            int8_t v28;
            v28 = 12;
            return loop_pair22(v0, v1, v28);
        }
    }
}
uint64_t loop_pair_18(uint64_t v0, uint64_t v1, int8_t v2){
    bool v3;
    v3 = 0 <= v2;
    if (v3){
        int8_t v4;
        v4 = 3 * v2;
        int32_t v5;
        v5 = (int32_t)v4;
        uint64_t v6;
        v6 = v0 >> v5;
        int8_t v7;
        v7 = (int8_t)v6;
        int8_t v8;
        v8 = v7 & 7;
        bool v9;
        v9 = v8 == 2;
        if (v9){
            int8_t v10;
            v10 = 0;
            int8_t v11;
            v11 = 2;
            uint32_t v12;
            v12 = 0ul;
            uint32_t v13;
            v13 = loop9(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            return loop_pair19(v0, v1, v2, v13, v14);
        } else {
            int8_t v16;
            v16 = v2 - 1;
            return loop_pair_18(v0, v1, v16);
        }
    } else {
        int8_t v19;
        v19 = 12;
        return loop_pair22(v0, v1, v19);
    }
}
uint64_t loop_triple17(uint64_t v0, uint64_t v1, int8_t v2){
    bool v3;
    v3 = 0 <= v2;
    if (v3){
        int8_t v4;
        v4 = 3 * v2;
        int32_t v5;
        v5 = (int32_t)v4;
        uint64_t v6;
        v6 = v0 >> v5;
        int8_t v7;
        v7 = (int8_t)v6;
        int8_t v8;
        v8 = v7 & 7;
        bool v9;
        v9 = v8 == 3;
        if (v9){
            int8_t v10;
            v10 = 0;
            int8_t v11;
            v11 = 3;
            uint32_t v12;
            v12 = 0ul;
            uint32_t v13;
            v13 = loop9(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            int8_t v15;
            v15 = 2;
            uint32_t v16;
            v16 = loop_ranks10(v1, v2, v14, v15, v13);
            uint64_t v17;
            v17 = (uint64_t)3;
            uint64_t v18;
            v18 = v17 << 32l;
            uint64_t v19;
            v19 = (uint64_t)v16;
            uint64_t v20;
            v20 = v18 | v19;
            return v20;
        } else {
            int8_t v21;
            v21 = v2 - 1;
            return loop_triple17(v0, v1, v21);
        }
    } else {
        int8_t v24;
        v24 = 12;
        return loop_pair_18(v0, v1, v24);
    }
}
uint64_t loop16(uint64_t v0, uint64_t v1, int8_t v2){
    bool v3;
    v3 = -1 <= v2;
    if (v3){
        int8_t v4;
        v4 = v2 + 4;
        int8_t v5;
        v5 = 3 * v4;
        int32_t v6;
        v6 = (int32_t)v5;
        uint64_t v7;
        v7 = v0 >> v6;
        int8_t v8;
        v8 = (int8_t)v7;
        int8_t v9;
        v9 = v8 & 7;
        bool v10;
        v10 = 0 < v9;
        int8_t v11;
        if (v10){
            v11 = 1;
        } else {
            v11 = 0;
        }
        int8_t v12;
        v12 = v2 + 3;
        int8_t v13;
        v13 = 3 * v12;
        int32_t v14;
        v14 = (int32_t)v13;
        uint64_t v15;
        v15 = v0 >> v14;
        int8_t v16;
        v16 = (int8_t)v15;
        int8_t v17;
        v17 = v16 & 7;
        bool v18;
        v18 = 0 < v17;
        int8_t v19;
        if (v18){
            v19 = 1;
        } else {
            v19 = 0;
        }
        int8_t v20;
        v20 = v11 & v19;
        int8_t v21;
        v21 = v2 + 2;
        int8_t v22;
        v22 = 3 * v21;
        int32_t v23;
        v23 = (int32_t)v22;
        uint64_t v24;
        v24 = v0 >> v23;
        int8_t v25;
        v25 = (int8_t)v24;
        int8_t v26;
        v26 = v25 & 7;
        bool v27;
        v27 = 0 < v26;
        int8_t v28;
        if (v27){
            v28 = 1;
        } else {
            v28 = 0;
        }
        int8_t v29;
        v29 = v20 & v28;
        int8_t v30;
        v30 = v2 + 1;
        int8_t v31;
        v31 = 3 * v30;
        int32_t v32;
        v32 = (int32_t)v31;
        uint64_t v33;
        v33 = v0 >> v32;
        int8_t v34;
        v34 = (int8_t)v33;
        int8_t v35;
        v35 = v34 & 7;
        bool v36;
        v36 = 0 < v35;
        int8_t v37;
        if (v36){
            v37 = 1;
        } else {
            v37 = 0;
        }
        int8_t v38;
        v38 = v29 & v37;
        bool v39;
        v39 = v2 < 0;
        int8_t v41;
        if (v39){
            int8_t v40;
            v40 = v2 + 13;
            v41 = v40;
        } else {
            v41 = v2;
        }
        int8_t v42;
        v42 = 3 * v41;
        int32_t v43;
        v43 = (int32_t)v42;
        uint64_t v44;
        v44 = v0 >> v43;
        int8_t v45;
        v45 = (int8_t)v44;
        int8_t v46;
        v46 = v45 & 7;
        bool v47;
        v47 = 0 < v46;
        int8_t v48;
        if (v47){
            v48 = 1;
        } else {
            v48 = 0;
        }
        int8_t v49;
        v49 = v38 & v48;
        bool v50;
        v50 = (bool)v49;
        if (v50){
            int8_t v51;
            v51 = 0;
            int8_t v52;
            v52 = 1;
            uint32_t v53;
            v53 = 0ul;
            uint32_t v54;
            v54 = loop9(v1, v4, v51, v52, v53);
            int8_t v55;
            v55 = 0;
            int8_t v56;
            v56 = 1;
            uint32_t v57;
            v57 = loop9(v1, v12, v55, v56, v54);
            int8_t v58;
            v58 = 0;
            int8_t v59;
            v59 = 1;
            uint32_t v60;
            v60 = loop9(v1, v21, v58, v59, v57);
            int8_t v61;
            v61 = 0;
            int8_t v62;
            v62 = 1;
            uint32_t v63;
            v63 = loop9(v1, v30, v61, v62, v60);
            int8_t v65;
            if (v39){
                int8_t v64;
                v64 = v2 + 13;
                v65 = v64;
            } else {
                v65 = v2;
            }
            int8_t v66;
            v66 = 0;
            int8_t v67;
            v67 = 1;
            uint32_t v68;
            v68 = loop9(v1, v65, v66, v67, v63);
            uint64_t v69;
            v69 = (uint64_t)4;
            uint64_t v70;
            v70 = v69 << 32l;
            uint64_t v71;
            v71 = (uint64_t)v68;
            uint64_t v72;
            v72 = v70 | v71;
            return v72;
        } else {
            int8_t v73;
            v73 = v2 - 1;
            return loop16(v0, v1, v73);
        }
    } else {
        int8_t v76;
        v76 = 12;
        return loop_triple17(v0, v1, v76);
    }
}
uint64_t loop_pair13(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3, uint32_t v4, int8_t v5){
    bool v6;
    v6 = 0 <= v5;
    if (v6){
        bool v7;
        v7 = v3 == v5;
        if (v7){
            int8_t v8;
            v8 = v5 - 1;
            return loop_pair13(v0, v1, v2, v3, v4, v8);
        } else {
            int8_t v10;
            v10 = 3 * v5;
            int32_t v11;
            v11 = (int32_t)v10;
            uint64_t v12;
            v12 = v0 >> v11;
            int8_t v13;
            v13 = (int8_t)v12;
            int8_t v14;
            v14 = v13 & 7;
            bool v15;
            v15 = 2 <= v14;
            if (v15){
                int8_t v16;
                v16 = 0;
                int8_t v17;
                v17 = 2;
                uint32_t v18;
                v18 = loop9(v1, v5, v16, v17, v4);
                uint64_t v19;
                v19 = (uint64_t)6;
                uint64_t v20;
                v20 = v19 << 32l;
                uint64_t v21;
                v21 = (uint64_t)v18;
                uint64_t v22;
                v22 = v20 | v21;
                return v22;
            } else {
                int8_t v23;
                v23 = v5 - 1;
                return loop_pair13(v0, v1, v2, v3, v4, v23);
            }
        }
    } else {
        int8_t v27;
        v27 = 0;
        uint32_t v28;
        v28 = try_suit14(v1, v2, v27);
        bool v29;
        v29 = v28 >= 0ul;
        uint32_t v30;
        if (v29){
            v30 = v28;
        } else {
            v30 = 0ul;
        }
        int8_t v31;
        v31 = 1;
        uint32_t v32;
        v32 = try_suit14(v1, v2, v31);
        bool v33;
        v33 = v32 >= v30;
        uint32_t v34;
        if (v33){
            v34 = v32;
        } else {
            v34 = v30;
        }
        int8_t v35;
        v35 = 2;
        uint32_t v36;
        v36 = try_suit14(v1, v2, v35);
        bool v37;
        v37 = v36 >= v34;
        uint32_t v38;
        if (v37){
            v38 = v36;
        } else {
            v38 = v34;
        }
        int8_t v39;
        v39 = 3;
        uint32_t v40;
        v40 = try_suit14(v1, v2, v39);
        bool v41;
        v41 = v40 >= v38;
        uint32_t v42;
        if (v41){
            v42 = v40;
        } else {
            v42 = v38;
        }
        bool v43;
        v43 = 0ul < v42;
        if (v43){
            uint64_t v44;
            v44 = (uint64_t)5;
            uint64_t v45;
            v45 = v44 << 32l;
            uint64_t v46;
            v46 = (uint64_t)v42;
            uint64_t v47;
            v47 = v45 | v46;
            return v47;
        } else {
            int8_t v48;
            v48 = 8;
            return loop16(v0, v1, v48);
        }
    }
}
uint64_t loop_triple12(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3){
    bool v4;
    v4 = 0 <= v3;
    if (v4){
        int8_t v5;
        v5 = 3 * v3;
        int32_t v6;
        v6 = (int32_t)v5;
        uint64_t v7;
        v7 = v0 >> v6;
        int8_t v8;
        v8 = (int8_t)v7;
        int8_t v9;
        v9 = v8 & 7;
        bool v10;
        v10 = v9 == 3;
        if (v10){
            int8_t v11;
            v11 = 0;
            int8_t v12;
            v12 = 3;
            uint32_t v13;
            v13 = 0ul;
            uint32_t v14;
            v14 = loop9(v1, v3, v11, v12, v13);
            int8_t v15;
            v15 = 12;
            return loop_pair13(v0, v1, v2, v3, v14, v15);
        } else {
            int8_t v17;
            v17 = v3 - 1;
            return loop_triple12(v0, v1, v2, v17);
        }
    } else {
        int8_t v20;
        v20 = 0;
        uint32_t v21;
        v21 = try_suit14(v1, v2, v20);
        bool v22;
        v22 = v21 >= 0ul;
        uint32_t v23;
        if (v22){
            v23 = v21;
        } else {
            v23 = 0ul;
        }
        int8_t v24;
        v24 = 1;
        uint32_t v25;
        v25 = try_suit14(v1, v2, v24);
        bool v26;
        v26 = v25 >= v23;
        uint32_t v27;
        if (v26){
            v27 = v25;
        } else {
            v27 = v23;
        }
        int8_t v28;
        v28 = 2;
        uint32_t v29;
        v29 = try_suit14(v1, v2, v28);
        bool v30;
        v30 = v29 >= v27;
        uint32_t v31;
        if (v30){
            v31 = v29;
        } else {
            v31 = v27;
        }
        int8_t v32;
        v32 = 3;
        uint32_t v33;
        v33 = try_suit14(v1, v2, v32);
        bool v34;
        v34 = v33 >= v31;
        uint32_t v35;
        if (v34){
            v35 = v33;
        } else {
            v35 = v31;
        }
        bool v36;
        v36 = 0ul < v35;
        if (v36){
            uint64_t v37;
            v37 = (uint64_t)5;
            uint64_t v38;
            v38 = v37 << 32l;
            uint64_t v39;
            v39 = (uint64_t)v35;
            uint64_t v40;
            v40 = v38 | v39;
            return v40;
        } else {
            int8_t v41;
            v41 = 8;
            return loop16(v0, v1, v41);
        }
    }
}
uint64_t loop_ranks8(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3){
    bool v4;
    v4 = 0 <= v3;
    if (v4){
        int8_t v5;
        v5 = 3 * v3;
        int32_t v6;
        v6 = (int32_t)v5;
        uint64_t v7;
        v7 = v0 >> v6;
        int8_t v8;
        v8 = (int8_t)v7;
        int8_t v9;
        v9 = v8 & 7;
        bool v10;
        v10 = v9 == 4;
        if (v10){
            int8_t v11;
            v11 = 0;
            int8_t v12;
            v12 = 4;
            uint32_t v13;
            v13 = 0ul;
            uint32_t v14;
            v14 = loop9(v1, v3, v11, v12, v13);
            int8_t v15;
            v15 = 12;
            int8_t v16;
            v16 = 1;
            uint32_t v17;
            v17 = loop_ranks10(v1, v3, v15, v16, v14);
            uint64_t v18;
            v18 = (uint64_t)7;
            uint64_t v19;
            v19 = v18 << 32l;
            uint64_t v20;
            v20 = (uint64_t)v17;
            uint64_t v21;
            v21 = v19 | v20;
            return v21;
        } else {
            int8_t v22;
            v22 = v3 - 1;
            return loop_ranks8(v0, v1, v2, v22);
        }
    } else {
        int8_t v25;
        v25 = 12;
        return loop_triple12(v0, v1, v2, v25);
    }
}
uint64_t method3(uint64_t v0){
    int8_t v1; uint16_t v2;
    Tuple3 tmp6 = TupleCreate3(0, 0u);
    v1 = tmp6.v0; v2 = tmp6.v1;
    while (method4(v1)){
        int8_t v4; uint16_t v5;
        Tuple3 tmp7 = TupleCreate3(0, v2);
        v4 = tmp7.v0; v5 = tmp7.v1;
        while (method5(v4)){
            int8_t v7;
            v7 = v4 * 13;
            int8_t v8;
            v8 = v7 + v1;
            int32_t v9;
            v9 = (int32_t)v8;
            uint64_t v10;
            v10 = v0 >> v9;
            uint8_t v11;
            v11 = (uint8_t)v10;
            uint8_t v12;
            v12 = v11 & 1u;
            uint8_t v13;
            v13 = (uint8_t)v4;
            uint16_t v14;
            v14 = (uint16_t)v12;
            uint8_t v15;
            v15 = 4u * v13;
            int32_t v16;
            v16 = (int32_t)v15;
            uint16_t v17;
            v17 = v14 << v16;
            uint16_t v18;
            v18 = v5 + v17;
            v5 = v18;
            v4++;
        }
        v2 = v5;
        v1++;
    }
    int8_t v19; uint64_t v20;
    Tuple4 tmp8 = TupleCreate4(0, 0ull);
    v19 = tmp8.v0; v20 = tmp8.v1;
    while (method4(v19)){
        int8_t v22; uint64_t v23;
        Tuple4 tmp9 = TupleCreate4(0, v20);
        v22 = tmp9.v0; v23 = tmp9.v1;
        while (method5(v22)){
            int8_t v25;
            v25 = v22 * 13;
            int8_t v26;
            v26 = v25 + v19;
            int32_t v27;
            v27 = (int32_t)v26;
            uint64_t v28;
            v28 = v0 >> v27;
            uint8_t v29;
            v29 = (uint8_t)v28;
            uint8_t v30;
            v30 = v29 & 1u;
            uint8_t v31;
            v31 = (uint8_t)v19;
            uint64_t v32;
            v32 = (uint64_t)v30;
            uint8_t v33;
            v33 = 3u * v31;
            int32_t v34;
            v34 = (int32_t)v33;
            uint64_t v35;
            v35 = v32 << v34;
            uint64_t v36;
            v36 = v23 + v35;
            v23 = v36;
            v22++;
        }
        v20 = v23;
        v19++;
    }
    int8_t v37;
    v37 = 0;
    uint32_t v38;
    v38 = try_suit6(v0, v2, v37);
    bool v39;
    v39 = v38 >= 0ul;
    uint32_t v40;
    if (v39){
        v40 = v38;
    } else {
        v40 = 0ul;
    }
    int8_t v41;
    v41 = 1;
    uint32_t v42;
    v42 = try_suit6(v0, v2, v41);
    bool v43;
    v43 = v42 >= v40;
    uint32_t v44;
    if (v43){
        v44 = v42;
    } else {
        v44 = v40;
    }
    int8_t v45;
    v45 = 2;
    uint32_t v46;
    v46 = try_suit6(v0, v2, v45);
    bool v47;
    v47 = v46 >= v44;
    uint32_t v48;
    if (v47){
        v48 = v46;
    } else {
        v48 = v44;
    }
    int8_t v49;
    v49 = 3;
    uint32_t v50;
    v50 = try_suit6(v0, v2, v49);
    bool v51;
    v51 = v50 >= v48;
    uint32_t v52;
    if (v51){
        v52 = v50;
    } else {
        v52 = v48;
    }
    bool v53;
    v53 = 0ul < v52;
    if (v53){
        uint64_t v54;
        v54 = (uint64_t)8;
        uint64_t v55;
        v55 = v54 << 32l;
        uint64_t v56;
        v56 = (uint64_t)v52;
        uint64_t v57;
        v57 = v55 | v56;
        return v57;
    } else {
        int8_t v58;
        v58 = 12;
        return loop_ranks8(v20, v0, v2, v58);
    }
}
Tuple2 score_2(uint64_t v0){
    uint64_t v1;
    v1 = method3(v0);
    uint64_t v2;
    v2 = v1 >> 32l;
    int8_t v3;
    v3 = (int8_t)v2;
    uint32_t v4;
    v4 = (uint32_t)v1;
    uint32_t v5;
    v5 = v4 >> 6l;
    uint32_t v6;
    v6 = v4 & 63ul;
    int8_t v7;
    v7 = (int8_t)v6;
    uint32_t v8;
    v8 = v5 >> 6l;
    uint32_t v9;
    v9 = v5 & 63ul;
    int8_t v10;
    v10 = (int8_t)v9;
    uint32_t v11;
    v11 = v8 >> 6l;
    uint32_t v12;
    v12 = v8 & 63ul;
    int8_t v13;
    v13 = (int8_t)v12;
    uint32_t v14;
    v14 = v11 >> 6l;
    uint32_t v15;
    v15 = v11 & 63ul;
    int8_t v16;
    v16 = (int8_t)v15;
    int8_t v17;
    v17 = (int8_t)v14;
    return TupleCreate2(v17, v16, v13, v10, v7, v3);
}
static inline Tuple5 TupleCreate5(ap_uint<4l> v0, ap_uint<2l> v1){
    Tuple5 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple6 TupleCreate6(array<5l,Tuple5> v0, ap_uint<4l> v1){
    Tuple6 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method26(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
bool ClosureMethod0(Tuple5 tup0, Tuple5 tup1){
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
static inline Tuple7 TupleCreate7(int32_t v0, int32_t v1, int32_t v2, ap_uint<4l> v3){
    Tuple7 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3;
    return x;
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(array<2l,Tuple5> v0, array<3l,Tuple5> v1) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method27(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
bool method28(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(array<5l,Tuple5> v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
bool method29(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1(array<2l,Tuple5> v0, array<1l,Tuple5> v1) { // Some
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method30(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1(array<3l,Tuple5> v0, array<2l,Tuple5> v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
static inline Tuple8 TupleCreate8(int32_t v0, int32_t v1, ap_uint<4l> v2){
    Tuple8 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static inline Tuple9 TupleCreate9(int32_t v0, int32_t v1){
    Tuple9 x;
    x.v0 = v0; x.v1 = v1;
    return x;
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
static inline Tuple10 TupleCreate10(int32_t v0, US4 v1){
    Tuple10 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(array<2l,Tuple5> v0, array<0l,Tuple5> v1) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method31(int32_t v0){
    bool v1;
    v1 = v0 < 0l;
    return v1;
}
US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
US6 US6_1(array<4l,Tuple5> v0, array<1l,Tuple5> v1) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method32(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
US7 US7_1(array<5l,Tuple5> v0, ap_uint<4l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple6 score25(array<5l,Tuple5> v0){
    array<5l,Tuple5> v1;
    int32_t v2;
    v2 = 0l;
    while (method26(v2)){
        ap_uint<4l> v4; ap_uint<2l> v5;
        Tuple5 tmp11 = v0.v[v2];
        v4 = tmp11.v0; v5 = tmp11.v1;
        v1.v[v2] = TupleCreate5(v4, v5);
        v2++;
    }
    Fun0 v6;
    v6 = ClosureMethod0;
    std::sort(v1.v,v1.v+5l,v6);
    array<5l,Tuple5> v7;
    int32_t v8;
    v8 = 0l;
    while (method26(v8)){
        ap_uint<4l> v10; ap_uint<2l> v11;
        Tuple5 tmp12 = v1.v[v8];
        v10 = tmp12.v0; v11 = tmp12.v1;
        v7.v[v8] = TupleCreate5(v10, v11);
        v8++;
    }
    array<2l,Tuple5> v12;
    array<3l,Tuple5> v13;
    ap_uint<4l> v14;
    v14 = 12ul;
    int32_t v15; int32_t v16; int32_t v17; ap_uint<4l> v18;
    Tuple7 tmp13 = TupleCreate7(0l, 0l, 0l, v14);
    v15 = tmp13.v0; v16 = tmp13.v1; v17 = tmp13.v2; v18 = tmp13.v3;
    while (method26(v15)){
        ap_uint<4l> v20; ap_uint<2l> v21;
        Tuple5 tmp14 = v1.v[v15];
        v20 = tmp14.v0; v21 = tmp14.v1;
        bool v22;
        v22 = v17 < 2l;
        int32_t v26; int32_t v27; ap_uint<4l> v28;
        if (v22){
            bool v23;
            v23 = v18 == v20;
            int32_t v24;
            if (v23){
                v24 = v17;
            } else {
                v24 = 0l;
            }
            v12.v[v24] = TupleCreate5(v20, v21);
            int32_t v25;
            v25 = v24 + 1l;
            v26 = v15; v27 = v25; v28 = v20;
        } else {
            v26 = v16; v27 = v17; v28 = v18;
        }
        v16 = v26;
        v17 = v27;
        v18 = v28;
        v15++;
    }
    bool v29;
    v29 = v17 == 2l;
    US0 v43;
    if (v29){
        int32_t v30;
        v30 = v16 + 1l;
        int32_t v31;
        v31 = v30 - 2l;
        int32_t v32;
        v32 = 0l;
        while (method27(v31, v32)){
            ap_uint<4l> v34; ap_uint<2l> v35;
            Tuple5 tmp15 = v1.v[v32];
            v34 = tmp15.v0; v35 = tmp15.v1;
            v13.v[v32] = TupleCreate5(v34, v35);
            v32++;
        }
        int32_t v36;
        v36 = v31;
        while (method28(v36)){
            int32_t v38;
            v38 = 2l + v36;
            ap_uint<4l> v39; ap_uint<2l> v40;
            Tuple5 tmp16 = v1.v[v38];
            v39 = tmp16.v0; v40 = tmp16.v1;
            v13.v[v36] = TupleCreate5(v39, v40);
            v36++;
        }
        v43 = US0_1(v12, v13);
    } else {
        v43 = US0_0();
    }
    US1 v65;
    switch (v43.tag) {
        case 0: { // None
            v65 = US1_0();
            break;
        }
        case 1: { // Some
            array<2l,Tuple5> v44 = v43.v.case1.v0; array<3l,Tuple5> v45 = v43.v.case1.v1;
            array<3l,Tuple5> v46;
            int32_t v47;
            v47 = 0l;
            while (method28(v47)){
                ap_uint<4l> v49; ap_uint<2l> v50;
                Tuple5 tmp17 = v45.v[v47];
                v49 = tmp17.v0; v50 = tmp17.v1;
                v46.v[v47] = TupleCreate5(v49, v50);
                v47++;
            }
            array<0l,Tuple5> v51;
            array<5l,Tuple5> v52;
            int32_t v53;
            v53 = 0l;
            while (method29(v53)){
                ap_uint<4l> v55; ap_uint<2l> v56;
                Tuple5 tmp18 = v44.v[v53];
                v55 = tmp18.v0; v56 = tmp18.v1;
                v52.v[v53] = TupleCreate5(v55, v56);
                v53++;
            }
            int32_t v57;
            v57 = 0l;
            while (method28(v57)){
                ap_uint<4l> v59; ap_uint<2l> v60;
                Tuple5 tmp19 = v46.v[v57];
                v59 = tmp19.v0; v60 = tmp19.v1;
                int32_t v61;
                v61 = 2l + v57;
                v52.v[v61] = TupleCreate5(v59, v60);
                v57++;
            }
            v65 = US1_1(v52);
            break;
        }
    }
    array<2l,Tuple5> v66;
    array<3l,Tuple5> v67;
    ap_uint<4l> v68;
    v68 = 12ul;
    int32_t v69; int32_t v70; int32_t v71; ap_uint<4l> v72;
    Tuple7 tmp20 = TupleCreate7(0l, 0l, 0l, v68);
    v69 = tmp20.v0; v70 = tmp20.v1; v71 = tmp20.v2; v72 = tmp20.v3;
    while (method26(v69)){
        ap_uint<4l> v74; ap_uint<2l> v75;
        Tuple5 tmp21 = v1.v[v69];
        v74 = tmp21.v0; v75 = tmp21.v1;
        bool v76;
        v76 = v71 < 2l;
        int32_t v80; int32_t v81; ap_uint<4l> v82;
        if (v76){
            bool v77;
            v77 = v72 == v74;
            int32_t v78;
            if (v77){
                v78 = v71;
            } else {
                v78 = 0l;
            }
            v66.v[v78] = TupleCreate5(v74, v75);
            int32_t v79;
            v79 = v78 + 1l;
            v80 = v69; v81 = v79; v82 = v74;
        } else {
            v80 = v70; v81 = v71; v82 = v72;
        }
        v70 = v80;
        v71 = v81;
        v72 = v82;
        v69++;
    }
    bool v83;
    v83 = v71 == 2l;
    US0 v97;
    if (v83){
        int32_t v84;
        v84 = v70 + 1l;
        int32_t v85;
        v85 = v84 - 2l;
        int32_t v86;
        v86 = 0l;
        while (method27(v85, v86)){
            ap_uint<4l> v88; ap_uint<2l> v89;
            Tuple5 tmp22 = v1.v[v86];
            v88 = tmp22.v0; v89 = tmp22.v1;
            v67.v[v86] = TupleCreate5(v88, v89);
            v86++;
        }
        int32_t v90;
        v90 = v85;
        while (method28(v90)){
            int32_t v92;
            v92 = 2l + v90;
            ap_uint<4l> v93; ap_uint<2l> v94;
            Tuple5 tmp23 = v1.v[v92];
            v93 = tmp23.v0; v94 = tmp23.v1;
            v67.v[v90] = TupleCreate5(v93, v94);
            v90++;
        }
        v97 = US0_1(v66, v67);
    } else {
        v97 = US0_0();
    }
    US1 v160;
    switch (v97.tag) {
        case 0: { // None
            v160 = US1_0();
            break;
        }
        case 1: { // Some
            array<2l,Tuple5> v98 = v97.v.case1.v0; array<3l,Tuple5> v99 = v97.v.case1.v1;
            array<2l,Tuple5> v100;
            array<1l,Tuple5> v101;
            ap_uint<4l> v102;
            v102 = 12ul;
            int32_t v103; int32_t v104; int32_t v105; ap_uint<4l> v106;
            Tuple7 tmp24 = TupleCreate7(0l, 0l, 0l, v102);
            v103 = tmp24.v0; v104 = tmp24.v1; v105 = tmp24.v2; v106 = tmp24.v3;
            while (method28(v103)){
                ap_uint<4l> v108; ap_uint<2l> v109;
                Tuple5 tmp25 = v99.v[v103];
                v108 = tmp25.v0; v109 = tmp25.v1;
                bool v110;
                v110 = v105 < 2l;
                int32_t v114; int32_t v115; ap_uint<4l> v116;
                if (v110){
                    bool v111;
                    v111 = v106 == v108;
                    int32_t v112;
                    if (v111){
                        v112 = v105;
                    } else {
                        v112 = 0l;
                    }
                    v100.v[v112] = TupleCreate5(v108, v109);
                    int32_t v113;
                    v113 = v112 + 1l;
                    v114 = v103; v115 = v113; v116 = v108;
                } else {
                    v114 = v104; v115 = v105; v116 = v106;
                }
                v104 = v114;
                v105 = v115;
                v106 = v116;
                v103++;
            }
            bool v117;
            v117 = v105 == 2l;
            US2 v131;
            if (v117){
                int32_t v118;
                v118 = v104 + 1l;
                int32_t v119;
                v119 = v118 - 2l;
                int32_t v120;
                v120 = 0l;
                while (method27(v119, v120)){
                    ap_uint<4l> v122; ap_uint<2l> v123;
                    Tuple5 tmp26 = v99.v[v120];
                    v122 = tmp26.v0; v123 = tmp26.v1;
                    v101.v[v120] = TupleCreate5(v122, v123);
                    v120++;
                }
                int32_t v124;
                v124 = v119;
                while (method30(v124)){
                    int32_t v126;
                    v126 = 2l + v124;
                    ap_uint<4l> v127; ap_uint<2l> v128;
                    Tuple5 tmp27 = v99.v[v126];
                    v127 = tmp27.v0; v128 = tmp27.v1;
                    v101.v[v124] = TupleCreate5(v127, v128);
                    v124++;
                }
                v131 = US2_1(v100, v101);
            } else {
                v131 = US2_0();
            }
            switch (v131.tag) {
                case 0: { // None
                    v160 = US1_0();
                    break;
                }
                case 1: { // Some
                    array<2l,Tuple5> v132 = v131.v.case1.v0; array<1l,Tuple5> v133 = v131.v.case1.v1;
                    array<1l,Tuple5> v134;
                    int32_t v135;
                    v135 = 0l;
                    while (method30(v135)){
                        ap_uint<4l> v137; ap_uint<2l> v138;
                        Tuple5 tmp28 = v133.v[v135];
                        v137 = tmp28.v0; v138 = tmp28.v1;
                        v134.v[v135] = TupleCreate5(v137, v138);
                        v135++;
                    }
                    array<5l,Tuple5> v139;
                    int32_t v140;
                    v140 = 0l;
                    while (method29(v140)){
                        ap_uint<4l> v142; ap_uint<2l> v143;
                        Tuple5 tmp29 = v98.v[v140];
                        v142 = tmp29.v0; v143 = tmp29.v1;
                        v139.v[v140] = TupleCreate5(v142, v143);
                        v140++;
                    }
                    int32_t v144;
                    v144 = 0l;
                    while (method29(v144)){
                        ap_uint<4l> v146; ap_uint<2l> v147;
                        Tuple5 tmp30 = v132.v[v144];
                        v146 = tmp30.v0; v147 = tmp30.v1;
                        int32_t v148;
                        v148 = 2l + v144;
                        v139.v[v148] = TupleCreate5(v146, v147);
                        v144++;
                    }
                    int32_t v149;
                    v149 = 0l;
                    while (method30(v149)){
                        ap_uint<4l> v151; ap_uint<2l> v152;
                        Tuple5 tmp31 = v134.v[v149];
                        v151 = tmp31.v0; v152 = tmp31.v1;
                        int32_t v153;
                        v153 = 4l + v149;
                        v139.v[v153] = TupleCreate5(v151, v152);
                        v149++;
                    }
                    v160 = US1_1(v139);
                    break;
                }
            }
            break;
        }
    }
    array<3l,Tuple5> v161;
    array<2l,Tuple5> v162;
    ap_uint<4l> v163;
    v163 = 12ul;
    int32_t v164; int32_t v165; int32_t v166; ap_uint<4l> v167;
    Tuple7 tmp32 = TupleCreate7(0l, 0l, 0l, v163);
    v164 = tmp32.v0; v165 = tmp32.v1; v166 = tmp32.v2; v167 = tmp32.v3;
    while (method26(v164)){
        ap_uint<4l> v169; ap_uint<2l> v170;
        Tuple5 tmp33 = v1.v[v164];
        v169 = tmp33.v0; v170 = tmp33.v1;
        bool v171;
        v171 = v166 < 3l;
        int32_t v175; int32_t v176; ap_uint<4l> v177;
        if (v171){
            bool v172;
            v172 = v167 == v169;
            int32_t v173;
            if (v172){
                v173 = v166;
            } else {
                v173 = 0l;
            }
            v161.v[v173] = TupleCreate5(v169, v170);
            int32_t v174;
            v174 = v173 + 1l;
            v175 = v164; v176 = v174; v177 = v169;
        } else {
            v175 = v165; v176 = v166; v177 = v167;
        }
        v165 = v175;
        v166 = v176;
        v167 = v177;
        v164++;
    }
    bool v178;
    v178 = v166 == 3l;
    US3 v192;
    if (v178){
        int32_t v179;
        v179 = v165 + 1l;
        int32_t v180;
        v180 = v179 - 3l;
        int32_t v181;
        v181 = 0l;
        while (method27(v180, v181)){
            ap_uint<4l> v183; ap_uint<2l> v184;
            Tuple5 tmp34 = v1.v[v181];
            v183 = tmp34.v0; v184 = tmp34.v1;
            v162.v[v181] = TupleCreate5(v183, v184);
            v181++;
        }
        int32_t v185;
        v185 = v180;
        while (method29(v185)){
            int32_t v187;
            v187 = 3l + v185;
            ap_uint<4l> v188; ap_uint<2l> v189;
            Tuple5 tmp35 = v1.v[v187];
            v188 = tmp35.v0; v189 = tmp35.v1;
            v162.v[v185] = TupleCreate5(v188, v189);
            v185++;
        }
        v192 = US3_1(v161, v162);
    } else {
        v192 = US3_0();
    }
    US1 v214;
    switch (v192.tag) {
        case 0: { // None
            v214 = US1_0();
            break;
        }
        case 1: { // Some
            array<3l,Tuple5> v193 = v192.v.case1.v0; array<2l,Tuple5> v194 = v192.v.case1.v1;
            array<2l,Tuple5> v195;
            int32_t v196;
            v196 = 0l;
            while (method29(v196)){
                ap_uint<4l> v198; ap_uint<2l> v199;
                Tuple5 tmp36 = v194.v[v196];
                v198 = tmp36.v0; v199 = tmp36.v1;
                v195.v[v196] = TupleCreate5(v198, v199);
                v196++;
            }
            array<0l,Tuple5> v200;
            array<5l,Tuple5> v201;
            int32_t v202;
            v202 = 0l;
            while (method28(v202)){
                ap_uint<4l> v204; ap_uint<2l> v205;
                Tuple5 tmp37 = v193.v[v202];
                v204 = tmp37.v0; v205 = tmp37.v1;
                v201.v[v202] = TupleCreate5(v204, v205);
                v202++;
            }
            int32_t v206;
            v206 = 0l;
            while (method29(v206)){
                ap_uint<4l> v208; ap_uint<2l> v209;
                Tuple5 tmp38 = v195.v[v206];
                v208 = tmp38.v0; v209 = tmp38.v1;
                int32_t v210;
                v210 = 3l + v206;
                v201.v[v210] = TupleCreate5(v208, v209);
                v206++;
            }
            v214 = US1_1(v201);
            break;
        }
    }
    array<5l,Tuple5> v215;
    ap_uint<4l> v216;
    v216 = 12ul;
    int32_t v217; int32_t v218; ap_uint<4l> v219;
    Tuple8 tmp39 = TupleCreate8(0l, 0l, v216);
    v217 = tmp39.v0; v218 = tmp39.v1; v219 = tmp39.v2;
    while (method26(v217)){
        ap_uint<4l> v221; ap_uint<2l> v222;
        Tuple5 tmp40 = v1.v[v217];
        v221 = tmp40.v0; v222 = tmp40.v1;
        bool v223;
        v223 = v218 < 5l;
        bool v228;
        if (v223){
            ap_uint<4l> v224;
            v224 = 1ul;
            ap_uint<4l> v225;
            v225 = v221 - v224;
            bool v226;
            v226 = v219 == v225;
            bool v227;
            v227 = v226 != true;
            v228 = v227;
        } else {
            v228 = false;
        }
        int32_t v234; ap_uint<4l> v235;
        if (v228){
            bool v229;
            v229 = v219 == v221;
            int32_t v230;
            if (v229){
                v230 = v218;
            } else {
                v230 = 0l;
            }
            v215.v[v230] = TupleCreate5(v221, v222);
            int32_t v231;
            v231 = v230 + 1l;
            ap_uint<4l> v232;
            v232 = 1ul;
            ap_uint<4l> v233;
            v233 = v221 - v232;
            v234 = v231; v235 = v233;
        } else {
            v234 = v218; v235 = v219;
        }
        v218 = v234;
        v219 = v235;
        v217++;
    }
    bool v236;
    v236 = v218 == 4l;
    bool v247;
    if (v236){
        ap_uint<4l> v237;
        v237 = 0ul;
        ap_uint<4l> v238;
        v238 = 1ul;
        ap_uint<4l> v239;
        v239 = v237 - v238;
        bool v240;
        v240 = v219 == v239;
        if (v240){
            ap_uint<4l> v241; ap_uint<2l> v242;
            Tuple5 tmp41 = v1.v[0l];
            v241 = tmp41.v0; v242 = tmp41.v1;
            ap_uint<4l> v243;
            v243 = 12ul;
            bool v244;
            v244 = v241 == v243;
            if (v244){
                v215.v[4l] = TupleCreate5(v241, v242);
                v247 = true;
            } else {
                v247 = false;
            }
        } else {
            v247 = false;
        }
    } else {
        v247 = false;
    }
    US1 v253;
    if (v247){
        v253 = US1_1(v215);
    } else {
        bool v249;
        v249 = v218 == 5l;
        if (v249){
            v253 = US1_1(v215);
        } else {
            v253 = US1_0();
        }
    }
    array<5l,Tuple5> v254;
    int32_t v255; int32_t v256;
    Tuple9 tmp42 = TupleCreate9(0l, 0l);
    v255 = tmp42.v0; v256 = tmp42.v1;
    while (method26(v255)){
        ap_uint<4l> v258; ap_uint<2l> v259;
        Tuple5 tmp43 = v1.v[v255];
        v258 = tmp43.v0; v259 = tmp43.v1;
        ap_uint<2l> v260;
        v260 = 3ul;
        bool v261;
        v261 = v259 == v260;
        bool v263;
        if (v261){
            bool v262;
            v262 = v256 < 5l;
            v263 = v262;
        } else {
            v263 = false;
        }
        int32_t v265;
        if (v263){
            v254.v[v256] = TupleCreate5(v258, v259);
            int32_t v264;
            v264 = v256 + 1l;
            v265 = v264;
        } else {
            v265 = v256;
        }
        v256 = v265;
        v255++;
    }
    bool v266;
    v266 = v256 == 5l;
    US1 v269;
    if (v266){
        v269 = US1_1(v254);
    } else {
        v269 = US1_0();
    }
    array<5l,Tuple5> v270;
    int32_t v271; int32_t v272;
    Tuple9 tmp44 = TupleCreate9(0l, 0l);
    v271 = tmp44.v0; v272 = tmp44.v1;
    while (method26(v271)){
        ap_uint<4l> v274; ap_uint<2l> v275;
        Tuple5 tmp45 = v1.v[v271];
        v274 = tmp45.v0; v275 = tmp45.v1;
        ap_uint<2l> v276;
        v276 = 2ul;
        bool v277;
        v277 = v275 == v276;
        bool v279;
        if (v277){
            bool v278;
            v278 = v272 < 5l;
            v279 = v278;
        } else {
            v279 = false;
        }
        int32_t v281;
        if (v279){
            v270.v[v272] = TupleCreate5(v274, v275);
            int32_t v280;
            v280 = v272 + 1l;
            v281 = v280;
        } else {
            v281 = v272;
        }
        v272 = v281;
        v271++;
    }
    bool v282;
    v282 = v272 == 5l;
    US1 v285;
    if (v282){
        v285 = US1_1(v270);
    } else {
        v285 = US1_0();
    }
    array<5l,Tuple5> v286;
    int32_t v287; int32_t v288;
    Tuple9 tmp46 = TupleCreate9(0l, 0l);
    v287 = tmp46.v0; v288 = tmp46.v1;
    while (method26(v287)){
        ap_uint<4l> v290; ap_uint<2l> v291;
        Tuple5 tmp47 = v1.v[v287];
        v290 = tmp47.v0; v291 = tmp47.v1;
        ap_uint<2l> v292;
        v292 = 1ul;
        bool v293;
        v293 = v291 == v292;
        bool v295;
        if (v293){
            bool v294;
            v294 = v288 < 5l;
            v295 = v294;
        } else {
            v295 = false;
        }
        int32_t v297;
        if (v295){
            v286.v[v288] = TupleCreate5(v290, v291);
            int32_t v296;
            v296 = v288 + 1l;
            v297 = v296;
        } else {
            v297 = v288;
        }
        v288 = v297;
        v287++;
    }
    bool v298;
    v298 = v288 == 5l;
    US1 v301;
    if (v298){
        v301 = US1_1(v286);
    } else {
        v301 = US1_0();
    }
    array<5l,Tuple5> v302;
    int32_t v303; int32_t v304;
    Tuple9 tmp48 = TupleCreate9(0l, 0l);
    v303 = tmp48.v0; v304 = tmp48.v1;
    while (method26(v303)){
        ap_uint<4l> v306; ap_uint<2l> v307;
        Tuple5 tmp49 = v1.v[v303];
        v306 = tmp49.v0; v307 = tmp49.v1;
        ap_uint<2l> v308;
        v308 = 0ul;
        bool v309;
        v309 = v307 == v308;
        bool v311;
        if (v309){
            bool v310;
            v310 = v304 < 5l;
            v311 = v310;
        } else {
            v311 = false;
        }
        int32_t v313;
        if (v311){
            v302.v[v304] = TupleCreate5(v306, v307);
            int32_t v312;
            v312 = v304 + 1l;
            v313 = v312;
        } else {
            v313 = v304;
        }
        v304 = v313;
        v303++;
    }
    bool v314;
    v314 = v304 == 5l;
    US1 v317;
    if (v314){
        v317 = US1_1(v302);
    } else {
        v317 = US1_0();
    }
    US1 v342;
    switch (v317.tag) {
        case 0: { // None
            v342 = v301;
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v318 = v317.v.case1.v0;
            switch (v301.tag) {
                case 0: { // None
                    v342 = v317;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v319 = v301.v.case1.v0;
                    US4 v320;
                    v320 = US4_0();
                    int32_t v321; US4 v322;
                    Tuple10 tmp50 = TupleCreate10(0l, v320);
                    v321 = tmp50.v0; v322 = tmp50.v1;
                    while (method26(v321)){
                        ap_uint<4l> v324; ap_uint<2l> v325;
                        Tuple5 tmp51 = v318.v[v321];
                        v324 = tmp51.v0; v325 = tmp51.v1;
                        ap_uint<4l> v326; ap_uint<2l> v327;
                        Tuple5 tmp52 = v319.v[v321];
                        v326 = tmp52.v0; v327 = tmp52.v1;
                        US4 v335;
                        switch (v322.tag) {
                            case 0: { // Eq
                                bool v328;
                                v328 = v324 > v326;
                                if (v328){
                                    v335 = US4_1();
                                } else {
                                    bool v330;
                                    v330 = v324 < v326;
                                    if (v330){
                                        v335 = US4_2();
                                    } else {
                                        v335 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v335 = v322;
                            }
                        }
                        v322 = v335;
                        v321++;
                    }
                    bool v336;
                    switch (v322.tag) {
                        case 1: { // Gt
                            v336 = true;
                            break;
                        }
                        default: {
                            v336 = false;
                        }
                    }
                    array<5l,Tuple5> v337;
                    if (v336){
                        v337 = v318;
                    } else {
                        v337 = v319;
                    }
                    v342 = US1_1(v337);
                    break;
                }
            }
            break;
        }
    }
    US1 v367;
    switch (v342.tag) {
        case 0: { // None
            v367 = v285;
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v343 = v342.v.case1.v0;
            switch (v285.tag) {
                case 0: { // None
                    v367 = v342;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v344 = v285.v.case1.v0;
                    US4 v345;
                    v345 = US4_0();
                    int32_t v346; US4 v347;
                    Tuple10 tmp53 = TupleCreate10(0l, v345);
                    v346 = tmp53.v0; v347 = tmp53.v1;
                    while (method26(v346)){
                        ap_uint<4l> v349; ap_uint<2l> v350;
                        Tuple5 tmp54 = v343.v[v346];
                        v349 = tmp54.v0; v350 = tmp54.v1;
                        ap_uint<4l> v351; ap_uint<2l> v352;
                        Tuple5 tmp55 = v344.v[v346];
                        v351 = tmp55.v0; v352 = tmp55.v1;
                        US4 v360;
                        switch (v347.tag) {
                            case 0: { // Eq
                                bool v353;
                                v353 = v349 > v351;
                                if (v353){
                                    v360 = US4_1();
                                } else {
                                    bool v355;
                                    v355 = v349 < v351;
                                    if (v355){
                                        v360 = US4_2();
                                    } else {
                                        v360 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v360 = v347;
                            }
                        }
                        v347 = v360;
                        v346++;
                    }
                    bool v361;
                    switch (v347.tag) {
                        case 1: { // Gt
                            v361 = true;
                            break;
                        }
                        default: {
                            v361 = false;
                        }
                    }
                    array<5l,Tuple5> v362;
                    if (v361){
                        v362 = v343;
                    } else {
                        v362 = v344;
                    }
                    v367 = US1_1(v362);
                    break;
                }
            }
            break;
        }
    }
    US1 v392;
    switch (v367.tag) {
        case 0: { // None
            v392 = v269;
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v368 = v367.v.case1.v0;
            switch (v269.tag) {
                case 0: { // None
                    v392 = v367;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v369 = v269.v.case1.v0;
                    US4 v370;
                    v370 = US4_0();
                    int32_t v371; US4 v372;
                    Tuple10 tmp56 = TupleCreate10(0l, v370);
                    v371 = tmp56.v0; v372 = tmp56.v1;
                    while (method26(v371)){
                        ap_uint<4l> v374; ap_uint<2l> v375;
                        Tuple5 tmp57 = v368.v[v371];
                        v374 = tmp57.v0; v375 = tmp57.v1;
                        ap_uint<4l> v376; ap_uint<2l> v377;
                        Tuple5 tmp58 = v369.v[v371];
                        v376 = tmp58.v0; v377 = tmp58.v1;
                        US4 v385;
                        switch (v372.tag) {
                            case 0: { // Eq
                                bool v378;
                                v378 = v374 > v376;
                                if (v378){
                                    v385 = US4_1();
                                } else {
                                    bool v380;
                                    v380 = v374 < v376;
                                    if (v380){
                                        v385 = US4_2();
                                    } else {
                                        v385 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v385 = v372;
                            }
                        }
                        v372 = v385;
                        v371++;
                    }
                    bool v386;
                    switch (v372.tag) {
                        case 1: { // Gt
                            v386 = true;
                            break;
                        }
                        default: {
                            v386 = false;
                        }
                    }
                    array<5l,Tuple5> v387;
                    if (v386){
                        v387 = v368;
                    } else {
                        v387 = v369;
                    }
                    v392 = US1_1(v387);
                    break;
                }
            }
            break;
        }
    }
    array<3l,Tuple5> v393;
    array<2l,Tuple5> v394;
    ap_uint<4l> v395;
    v395 = 12ul;
    int32_t v396; int32_t v397; int32_t v398; ap_uint<4l> v399;
    Tuple7 tmp59 = TupleCreate7(0l, 0l, 0l, v395);
    v396 = tmp59.v0; v397 = tmp59.v1; v398 = tmp59.v2; v399 = tmp59.v3;
    while (method26(v396)){
        ap_uint<4l> v401; ap_uint<2l> v402;
        Tuple5 tmp60 = v1.v[v396];
        v401 = tmp60.v0; v402 = tmp60.v1;
        bool v403;
        v403 = v398 < 3l;
        int32_t v407; int32_t v408; ap_uint<4l> v409;
        if (v403){
            bool v404;
            v404 = v399 == v401;
            int32_t v405;
            if (v404){
                v405 = v398;
            } else {
                v405 = 0l;
            }
            v393.v[v405] = TupleCreate5(v401, v402);
            int32_t v406;
            v406 = v405 + 1l;
            v407 = v396; v408 = v406; v409 = v401;
        } else {
            v407 = v397; v408 = v398; v409 = v399;
        }
        v397 = v407;
        v398 = v408;
        v399 = v409;
        v396++;
    }
    bool v410;
    v410 = v398 == 3l;
    US3 v424;
    if (v410){
        int32_t v411;
        v411 = v397 + 1l;
        int32_t v412;
        v412 = v411 - 3l;
        int32_t v413;
        v413 = 0l;
        while (method27(v412, v413)){
            ap_uint<4l> v415; ap_uint<2l> v416;
            Tuple5 tmp61 = v1.v[v413];
            v415 = tmp61.v0; v416 = tmp61.v1;
            v394.v[v413] = TupleCreate5(v415, v416);
            v413++;
        }
        int32_t v417;
        v417 = v412;
        while (method29(v417)){
            int32_t v419;
            v419 = 3l + v417;
            ap_uint<4l> v420; ap_uint<2l> v421;
            Tuple5 tmp62 = v1.v[v419];
            v420 = tmp62.v0; v421 = tmp62.v1;
            v394.v[v417] = TupleCreate5(v420, v421);
            v417++;
        }
        v424 = US3_1(v393, v394);
    } else {
        v424 = US3_0();
    }
    US1 v478;
    switch (v424.tag) {
        case 0: { // None
            v478 = US1_0();
            break;
        }
        case 1: { // Some
            array<3l,Tuple5> v425 = v424.v.case1.v0; array<2l,Tuple5> v426 = v424.v.case1.v1;
            array<2l,Tuple5> v427;
            array<0l,Tuple5> v428;
            ap_uint<4l> v429;
            v429 = 12ul;
            int32_t v430; int32_t v431; int32_t v432; ap_uint<4l> v433;
            Tuple7 tmp63 = TupleCreate7(0l, 0l, 0l, v429);
            v430 = tmp63.v0; v431 = tmp63.v1; v432 = tmp63.v2; v433 = tmp63.v3;
            while (method29(v430)){
                ap_uint<4l> v435; ap_uint<2l> v436;
                Tuple5 tmp64 = v426.v[v430];
                v435 = tmp64.v0; v436 = tmp64.v1;
                bool v437;
                v437 = v432 < 2l;
                int32_t v441; int32_t v442; ap_uint<4l> v443;
                if (v437){
                    bool v438;
                    v438 = v433 == v435;
                    int32_t v439;
                    if (v438){
                        v439 = v432;
                    } else {
                        v439 = 0l;
                    }
                    v427.v[v439] = TupleCreate5(v435, v436);
                    int32_t v440;
                    v440 = v439 + 1l;
                    v441 = v430; v442 = v440; v443 = v435;
                } else {
                    v441 = v431; v442 = v432; v443 = v433;
                }
                v431 = v441;
                v432 = v442;
                v433 = v443;
                v430++;
            }
            bool v444;
            v444 = v432 == 2l;
            US5 v458;
            if (v444){
                int32_t v445;
                v445 = v431 + 1l;
                int32_t v446;
                v446 = v445 - 2l;
                int32_t v447;
                v447 = 0l;
                while (method27(v446, v447)){
                    ap_uint<4l> v449; ap_uint<2l> v450;
                    Tuple5 tmp65 = v426.v[v447];
                    v449 = tmp65.v0; v450 = tmp65.v1;
                    v428.v[v447] = TupleCreate5(v449, v450);
                    v447++;
                }
                int32_t v451;
                v451 = v446;
                while (method31(v451)){
                    int32_t v453;
                    v453 = 2l + v451;
                    ap_uint<4l> v454; ap_uint<2l> v455;
                    Tuple5 tmp66 = v426.v[v453];
                    v454 = tmp66.v0; v455 = tmp66.v1;
                    v428.v[v451] = TupleCreate5(v454, v455);
                    v451++;
                }
                v458 = US5_1(v427, v428);
            } else {
                v458 = US5_0();
            }
            switch (v458.tag) {
                case 0: { // None
                    v478 = US1_0();
                    break;
                }
                case 1: { // Some
                    array<2l,Tuple5> v459 = v458.v.case1.v0; array<0l,Tuple5> v460 = v458.v.case1.v1;
                    array<0l,Tuple5> v461;
                    array<5l,Tuple5> v462;
                    int32_t v463;
                    v463 = 0l;
                    while (method28(v463)){
                        ap_uint<4l> v465; ap_uint<2l> v466;
                        Tuple5 tmp67 = v425.v[v463];
                        v465 = tmp67.v0; v466 = tmp67.v1;
                        v462.v[v463] = TupleCreate5(v465, v466);
                        v463++;
                    }
                    int32_t v467;
                    v467 = 0l;
                    while (method29(v467)){
                        ap_uint<4l> v469; ap_uint<2l> v470;
                        Tuple5 tmp68 = v459.v[v467];
                        v469 = tmp68.v0; v470 = tmp68.v1;
                        int32_t v471;
                        v471 = 3l + v467;
                        v462.v[v471] = TupleCreate5(v469, v470);
                        v467++;
                    }
                    v478 = US1_1(v462);
                    break;
                }
            }
            break;
        }
    }
    array<4l,Tuple5> v479;
    array<1l,Tuple5> v480;
    ap_uint<4l> v481;
    v481 = 12ul;
    int32_t v482; int32_t v483; int32_t v484; ap_uint<4l> v485;
    Tuple7 tmp69 = TupleCreate7(0l, 0l, 0l, v481);
    v482 = tmp69.v0; v483 = tmp69.v1; v484 = tmp69.v2; v485 = tmp69.v3;
    while (method26(v482)){
        ap_uint<4l> v487; ap_uint<2l> v488;
        Tuple5 tmp70 = v1.v[v482];
        v487 = tmp70.v0; v488 = tmp70.v1;
        bool v489;
        v489 = v484 < 4l;
        int32_t v493; int32_t v494; ap_uint<4l> v495;
        if (v489){
            bool v490;
            v490 = v485 == v487;
            int32_t v491;
            if (v490){
                v491 = v484;
            } else {
                v491 = 0l;
            }
            v479.v[v491] = TupleCreate5(v487, v488);
            int32_t v492;
            v492 = v491 + 1l;
            v493 = v482; v494 = v492; v495 = v487;
        } else {
            v493 = v483; v494 = v484; v495 = v485;
        }
        v483 = v493;
        v484 = v494;
        v485 = v495;
        v482++;
    }
    bool v496;
    v496 = v484 == 4l;
    US6 v510;
    if (v496){
        int32_t v497;
        v497 = v483 + 1l;
        int32_t v498;
        v498 = v497 - 4l;
        int32_t v499;
        v499 = 0l;
        while (method27(v498, v499)){
            ap_uint<4l> v501; ap_uint<2l> v502;
            Tuple5 tmp71 = v1.v[v499];
            v501 = tmp71.v0; v502 = tmp71.v1;
            v480.v[v499] = TupleCreate5(v501, v502);
            v499++;
        }
        int32_t v503;
        v503 = v498;
        while (method30(v503)){
            int32_t v505;
            v505 = 4l + v503;
            ap_uint<4l> v506; ap_uint<2l> v507;
            Tuple5 tmp72 = v1.v[v505];
            v506 = tmp72.v0; v507 = tmp72.v1;
            v480.v[v503] = TupleCreate5(v506, v507);
            v503++;
        }
        v510 = US6_1(v479, v480);
    } else {
        v510 = US6_0();
    }
    US1 v532;
    switch (v510.tag) {
        case 0: { // None
            v532 = US1_0();
            break;
        }
        case 1: { // Some
            array<4l,Tuple5> v511 = v510.v.case1.v0; array<1l,Tuple5> v512 = v510.v.case1.v1;
            array<1l,Tuple5> v513;
            int32_t v514;
            v514 = 0l;
            while (method30(v514)){
                ap_uint<4l> v516; ap_uint<2l> v517;
                Tuple5 tmp73 = v512.v[v514];
                v516 = tmp73.v0; v517 = tmp73.v1;
                v513.v[v514] = TupleCreate5(v516, v517);
                v514++;
            }
            array<0l,Tuple5> v518;
            array<5l,Tuple5> v519;
            int32_t v520;
            v520 = 0l;
            while (method32(v520)){
                ap_uint<4l> v522; ap_uint<2l> v523;
                Tuple5 tmp74 = v511.v[v520];
                v522 = tmp74.v0; v523 = tmp74.v1;
                v519.v[v520] = TupleCreate5(v522, v523);
                v520++;
            }
            int32_t v524;
            v524 = 0l;
            while (method30(v524)){
                ap_uint<4l> v526; ap_uint<2l> v527;
                Tuple5 tmp75 = v513.v[v524];
                v526 = tmp75.v0; v527 = tmp75.v1;
                int32_t v528;
                v528 = 4l + v524;
                v519.v[v528] = TupleCreate5(v526, v527);
                v524++;
            }
            v532 = US1_1(v519);
            break;
        }
    }
    ap_uint<2l> v533;
    v533 = 3ul;
    array<5l,Tuple5> v534;
    ap_uint<4l> v535;
    v535 = 12ul;
    int32_t v536; int32_t v537; ap_uint<4l> v538;
    Tuple8 tmp76 = TupleCreate8(0l, 0l, v535);
    v536 = tmp76.v0; v537 = tmp76.v1; v538 = tmp76.v2;
    while (method26(v536)){
        ap_uint<4l> v540; ap_uint<2l> v541;
        Tuple5 tmp77 = v1.v[v536];
        v540 = tmp77.v0; v541 = tmp77.v1;
        bool v542;
        v542 = v537 < 5l;
        bool v544;
        if (v542){
            bool v543;
            v543 = v533 == v541;
            v544 = v543;
        } else {
            v544 = false;
        }
        int32_t v550; ap_uint<4l> v551;
        if (v544){
            bool v545;
            v545 = v538 == v540;
            int32_t v546;
            if (v545){
                v546 = v537;
            } else {
                v546 = 0l;
            }
            v534.v[v546] = TupleCreate5(v540, v541);
            int32_t v547;
            v547 = v546 + 1l;
            ap_uint<4l> v548;
            v548 = 1ul;
            ap_uint<4l> v549;
            v549 = v540 - v548;
            v550 = v547; v551 = v549;
        } else {
            v550 = v537; v551 = v538;
        }
        v537 = v550;
        v538 = v551;
        v536++;
    }
    bool v552;
    v552 = v537 == 4l;
    bool v589;
    if (v552){
        ap_uint<4l> v553;
        v553 = 0ul;
        ap_uint<4l> v554;
        v554 = 1ul;
        ap_uint<4l> v555;
        v555 = v553 - v554;
        bool v556;
        v556 = v538 == v555;
        if (v556){
            ap_uint<4l> v557; ap_uint<2l> v558;
            Tuple5 tmp78 = v1.v[0l];
            v557 = tmp78.v0; v558 = tmp78.v1;
            bool v559;
            v559 = v533 == v558;
            bool v563;
            if (v559){
                ap_uint<4l> v560;
                v560 = 12ul;
                bool v561;
                v561 = v557 == v560;
                if (v561){
                    v534.v[4l] = TupleCreate5(v557, v558);
                    v563 = true;
                } else {
                    v563 = false;
                }
            } else {
                v563 = false;
            }
            if (v563){
                v589 = true;
            } else {
                ap_uint<4l> v564; ap_uint<2l> v565;
                Tuple5 tmp79 = v1.v[1l];
                v564 = tmp79.v0; v565 = tmp79.v1;
                bool v566;
                v566 = v533 == v565;
                bool v570;
                if (v566){
                    ap_uint<4l> v567;
                    v567 = 12ul;
                    bool v568;
                    v568 = v564 == v567;
                    if (v568){
                        v534.v[4l] = TupleCreate5(v564, v565);
                        v570 = true;
                    } else {
                        v570 = false;
                    }
                } else {
                    v570 = false;
                }
                if (v570){
                    v589 = true;
                } else {
                    ap_uint<4l> v571; ap_uint<2l> v572;
                    Tuple5 tmp80 = v1.v[2l];
                    v571 = tmp80.v0; v572 = tmp80.v1;
                    bool v573;
                    v573 = v533 == v572;
                    bool v577;
                    if (v573){
                        ap_uint<4l> v574;
                        v574 = 12ul;
                        bool v575;
                        v575 = v571 == v574;
                        if (v575){
                            v534.v[4l] = TupleCreate5(v571, v572);
                            v577 = true;
                        } else {
                            v577 = false;
                        }
                    } else {
                        v577 = false;
                    }
                    if (v577){
                        v589 = true;
                    } else {
                        ap_uint<4l> v578; ap_uint<2l> v579;
                        Tuple5 tmp81 = v1.v[3l];
                        v578 = tmp81.v0; v579 = tmp81.v1;
                        bool v580;
                        v580 = v533 == v579;
                        if (v580){
                            ap_uint<4l> v581;
                            v581 = 12ul;
                            bool v582;
                            v582 = v578 == v581;
                            if (v582){
                                v534.v[4l] = TupleCreate5(v578, v579);
                                v589 = true;
                            } else {
                                v589 = false;
                            }
                        } else {
                            v589 = false;
                        }
                    }
                }
            }
        } else {
            v589 = false;
        }
    } else {
        v589 = false;
    }
    US1 v595;
    if (v589){
        v595 = US1_1(v534);
    } else {
        bool v591;
        v591 = v537 == 5l;
        if (v591){
            v595 = US1_1(v534);
        } else {
            v595 = US1_0();
        }
    }
    ap_uint<2l> v596;
    v596 = 2ul;
    array<5l,Tuple5> v597;
    ap_uint<4l> v598;
    v598 = 12ul;
    int32_t v599; int32_t v600; ap_uint<4l> v601;
    Tuple8 tmp82 = TupleCreate8(0l, 0l, v598);
    v599 = tmp82.v0; v600 = tmp82.v1; v601 = tmp82.v2;
    while (method26(v599)){
        ap_uint<4l> v603; ap_uint<2l> v604;
        Tuple5 tmp83 = v1.v[v599];
        v603 = tmp83.v0; v604 = tmp83.v1;
        bool v605;
        v605 = v600 < 5l;
        bool v607;
        if (v605){
            bool v606;
            v606 = v596 == v604;
            v607 = v606;
        } else {
            v607 = false;
        }
        int32_t v613; ap_uint<4l> v614;
        if (v607){
            bool v608;
            v608 = v601 == v603;
            int32_t v609;
            if (v608){
                v609 = v600;
            } else {
                v609 = 0l;
            }
            v597.v[v609] = TupleCreate5(v603, v604);
            int32_t v610;
            v610 = v609 + 1l;
            ap_uint<4l> v611;
            v611 = 1ul;
            ap_uint<4l> v612;
            v612 = v603 - v611;
            v613 = v610; v614 = v612;
        } else {
            v613 = v600; v614 = v601;
        }
        v600 = v613;
        v601 = v614;
        v599++;
    }
    bool v615;
    v615 = v600 == 4l;
    bool v652;
    if (v615){
        ap_uint<4l> v616;
        v616 = 0ul;
        ap_uint<4l> v617;
        v617 = 1ul;
        ap_uint<4l> v618;
        v618 = v616 - v617;
        bool v619;
        v619 = v601 == v618;
        if (v619){
            ap_uint<4l> v620; ap_uint<2l> v621;
            Tuple5 tmp84 = v1.v[0l];
            v620 = tmp84.v0; v621 = tmp84.v1;
            bool v622;
            v622 = v596 == v621;
            bool v626;
            if (v622){
                ap_uint<4l> v623;
                v623 = 12ul;
                bool v624;
                v624 = v620 == v623;
                if (v624){
                    v597.v[4l] = TupleCreate5(v620, v621);
                    v626 = true;
                } else {
                    v626 = false;
                }
            } else {
                v626 = false;
            }
            if (v626){
                v652 = true;
            } else {
                ap_uint<4l> v627; ap_uint<2l> v628;
                Tuple5 tmp85 = v1.v[1l];
                v627 = tmp85.v0; v628 = tmp85.v1;
                bool v629;
                v629 = v596 == v628;
                bool v633;
                if (v629){
                    ap_uint<4l> v630;
                    v630 = 12ul;
                    bool v631;
                    v631 = v627 == v630;
                    if (v631){
                        v597.v[4l] = TupleCreate5(v627, v628);
                        v633 = true;
                    } else {
                        v633 = false;
                    }
                } else {
                    v633 = false;
                }
                if (v633){
                    v652 = true;
                } else {
                    ap_uint<4l> v634; ap_uint<2l> v635;
                    Tuple5 tmp86 = v1.v[2l];
                    v634 = tmp86.v0; v635 = tmp86.v1;
                    bool v636;
                    v636 = v596 == v635;
                    bool v640;
                    if (v636){
                        ap_uint<4l> v637;
                        v637 = 12ul;
                        bool v638;
                        v638 = v634 == v637;
                        if (v638){
                            v597.v[4l] = TupleCreate5(v634, v635);
                            v640 = true;
                        } else {
                            v640 = false;
                        }
                    } else {
                        v640 = false;
                    }
                    if (v640){
                        v652 = true;
                    } else {
                        ap_uint<4l> v641; ap_uint<2l> v642;
                        Tuple5 tmp87 = v1.v[3l];
                        v641 = tmp87.v0; v642 = tmp87.v1;
                        bool v643;
                        v643 = v596 == v642;
                        if (v643){
                            ap_uint<4l> v644;
                            v644 = 12ul;
                            bool v645;
                            v645 = v641 == v644;
                            if (v645){
                                v597.v[4l] = TupleCreate5(v641, v642);
                                v652 = true;
                            } else {
                                v652 = false;
                            }
                        } else {
                            v652 = false;
                        }
                    }
                }
            }
        } else {
            v652 = false;
        }
    } else {
        v652 = false;
    }
    US1 v658;
    if (v652){
        v658 = US1_1(v597);
    } else {
        bool v654;
        v654 = v600 == 5l;
        if (v654){
            v658 = US1_1(v597);
        } else {
            v658 = US1_0();
        }
    }
    ap_uint<2l> v659;
    v659 = 1ul;
    array<5l,Tuple5> v660;
    ap_uint<4l> v661;
    v661 = 12ul;
    int32_t v662; int32_t v663; ap_uint<4l> v664;
    Tuple8 tmp88 = TupleCreate8(0l, 0l, v661);
    v662 = tmp88.v0; v663 = tmp88.v1; v664 = tmp88.v2;
    while (method26(v662)){
        ap_uint<4l> v666; ap_uint<2l> v667;
        Tuple5 tmp89 = v1.v[v662];
        v666 = tmp89.v0; v667 = tmp89.v1;
        bool v668;
        v668 = v663 < 5l;
        bool v670;
        if (v668){
            bool v669;
            v669 = v659 == v667;
            v670 = v669;
        } else {
            v670 = false;
        }
        int32_t v676; ap_uint<4l> v677;
        if (v670){
            bool v671;
            v671 = v664 == v666;
            int32_t v672;
            if (v671){
                v672 = v663;
            } else {
                v672 = 0l;
            }
            v660.v[v672] = TupleCreate5(v666, v667);
            int32_t v673;
            v673 = v672 + 1l;
            ap_uint<4l> v674;
            v674 = 1ul;
            ap_uint<4l> v675;
            v675 = v666 - v674;
            v676 = v673; v677 = v675;
        } else {
            v676 = v663; v677 = v664;
        }
        v663 = v676;
        v664 = v677;
        v662++;
    }
    bool v678;
    v678 = v663 == 4l;
    bool v715;
    if (v678){
        ap_uint<4l> v679;
        v679 = 0ul;
        ap_uint<4l> v680;
        v680 = 1ul;
        ap_uint<4l> v681;
        v681 = v679 - v680;
        bool v682;
        v682 = v664 == v681;
        if (v682){
            ap_uint<4l> v683; ap_uint<2l> v684;
            Tuple5 tmp90 = v1.v[0l];
            v683 = tmp90.v0; v684 = tmp90.v1;
            bool v685;
            v685 = v659 == v684;
            bool v689;
            if (v685){
                ap_uint<4l> v686;
                v686 = 12ul;
                bool v687;
                v687 = v683 == v686;
                if (v687){
                    v660.v[4l] = TupleCreate5(v683, v684);
                    v689 = true;
                } else {
                    v689 = false;
                }
            } else {
                v689 = false;
            }
            if (v689){
                v715 = true;
            } else {
                ap_uint<4l> v690; ap_uint<2l> v691;
                Tuple5 tmp91 = v1.v[1l];
                v690 = tmp91.v0; v691 = tmp91.v1;
                bool v692;
                v692 = v659 == v691;
                bool v696;
                if (v692){
                    ap_uint<4l> v693;
                    v693 = 12ul;
                    bool v694;
                    v694 = v690 == v693;
                    if (v694){
                        v660.v[4l] = TupleCreate5(v690, v691);
                        v696 = true;
                    } else {
                        v696 = false;
                    }
                } else {
                    v696 = false;
                }
                if (v696){
                    v715 = true;
                } else {
                    ap_uint<4l> v697; ap_uint<2l> v698;
                    Tuple5 tmp92 = v1.v[2l];
                    v697 = tmp92.v0; v698 = tmp92.v1;
                    bool v699;
                    v699 = v659 == v698;
                    bool v703;
                    if (v699){
                        ap_uint<4l> v700;
                        v700 = 12ul;
                        bool v701;
                        v701 = v697 == v700;
                        if (v701){
                            v660.v[4l] = TupleCreate5(v697, v698);
                            v703 = true;
                        } else {
                            v703 = false;
                        }
                    } else {
                        v703 = false;
                    }
                    if (v703){
                        v715 = true;
                    } else {
                        ap_uint<4l> v704; ap_uint<2l> v705;
                        Tuple5 tmp93 = v1.v[3l];
                        v704 = tmp93.v0; v705 = tmp93.v1;
                        bool v706;
                        v706 = v659 == v705;
                        if (v706){
                            ap_uint<4l> v707;
                            v707 = 12ul;
                            bool v708;
                            v708 = v704 == v707;
                            if (v708){
                                v660.v[4l] = TupleCreate5(v704, v705);
                                v715 = true;
                            } else {
                                v715 = false;
                            }
                        } else {
                            v715 = false;
                        }
                    }
                }
            }
        } else {
            v715 = false;
        }
    } else {
        v715 = false;
    }
    US1 v721;
    if (v715){
        v721 = US1_1(v660);
    } else {
        bool v717;
        v717 = v663 == 5l;
        if (v717){
            v721 = US1_1(v660);
        } else {
            v721 = US1_0();
        }
    }
    ap_uint<2l> v722;
    v722 = 0ul;
    array<5l,Tuple5> v723;
    ap_uint<4l> v724;
    v724 = 12ul;
    int32_t v725; int32_t v726; ap_uint<4l> v727;
    Tuple8 tmp94 = TupleCreate8(0l, 0l, v724);
    v725 = tmp94.v0; v726 = tmp94.v1; v727 = tmp94.v2;
    while (method26(v725)){
        ap_uint<4l> v729; ap_uint<2l> v730;
        Tuple5 tmp95 = v1.v[v725];
        v729 = tmp95.v0; v730 = tmp95.v1;
        bool v731;
        v731 = v726 < 5l;
        bool v733;
        if (v731){
            bool v732;
            v732 = v722 == v730;
            v733 = v732;
        } else {
            v733 = false;
        }
        int32_t v739; ap_uint<4l> v740;
        if (v733){
            bool v734;
            v734 = v727 == v729;
            int32_t v735;
            if (v734){
                v735 = v726;
            } else {
                v735 = 0l;
            }
            v723.v[v735] = TupleCreate5(v729, v730);
            int32_t v736;
            v736 = v735 + 1l;
            ap_uint<4l> v737;
            v737 = 1ul;
            ap_uint<4l> v738;
            v738 = v729 - v737;
            v739 = v736; v740 = v738;
        } else {
            v739 = v726; v740 = v727;
        }
        v726 = v739;
        v727 = v740;
        v725++;
    }
    bool v741;
    v741 = v726 == 4l;
    bool v778;
    if (v741){
        ap_uint<4l> v742;
        v742 = 0ul;
        ap_uint<4l> v743;
        v743 = 1ul;
        ap_uint<4l> v744;
        v744 = v742 - v743;
        bool v745;
        v745 = v727 == v744;
        if (v745){
            ap_uint<4l> v746; ap_uint<2l> v747;
            Tuple5 tmp96 = v1.v[0l];
            v746 = tmp96.v0; v747 = tmp96.v1;
            bool v748;
            v748 = v722 == v747;
            bool v752;
            if (v748){
                ap_uint<4l> v749;
                v749 = 12ul;
                bool v750;
                v750 = v746 == v749;
                if (v750){
                    v723.v[4l] = TupleCreate5(v746, v747);
                    v752 = true;
                } else {
                    v752 = false;
                }
            } else {
                v752 = false;
            }
            if (v752){
                v778 = true;
            } else {
                ap_uint<4l> v753; ap_uint<2l> v754;
                Tuple5 tmp97 = v1.v[1l];
                v753 = tmp97.v0; v754 = tmp97.v1;
                bool v755;
                v755 = v722 == v754;
                bool v759;
                if (v755){
                    ap_uint<4l> v756;
                    v756 = 12ul;
                    bool v757;
                    v757 = v753 == v756;
                    if (v757){
                        v723.v[4l] = TupleCreate5(v753, v754);
                        v759 = true;
                    } else {
                        v759 = false;
                    }
                } else {
                    v759 = false;
                }
                if (v759){
                    v778 = true;
                } else {
                    ap_uint<4l> v760; ap_uint<2l> v761;
                    Tuple5 tmp98 = v1.v[2l];
                    v760 = tmp98.v0; v761 = tmp98.v1;
                    bool v762;
                    v762 = v722 == v761;
                    bool v766;
                    if (v762){
                        ap_uint<4l> v763;
                        v763 = 12ul;
                        bool v764;
                        v764 = v760 == v763;
                        if (v764){
                            v723.v[4l] = TupleCreate5(v760, v761);
                            v766 = true;
                        } else {
                            v766 = false;
                        }
                    } else {
                        v766 = false;
                    }
                    if (v766){
                        v778 = true;
                    } else {
                        ap_uint<4l> v767; ap_uint<2l> v768;
                        Tuple5 tmp99 = v1.v[3l];
                        v767 = tmp99.v0; v768 = tmp99.v1;
                        bool v769;
                        v769 = v722 == v768;
                        if (v769){
                            ap_uint<4l> v770;
                            v770 = 12ul;
                            bool v771;
                            v771 = v767 == v770;
                            if (v771){
                                v723.v[4l] = TupleCreate5(v767, v768);
                                v778 = true;
                            } else {
                                v778 = false;
                            }
                        } else {
                            v778 = false;
                        }
                    }
                }
            }
        } else {
            v778 = false;
        }
    } else {
        v778 = false;
    }
    US1 v784;
    if (v778){
        v784 = US1_1(v723);
    } else {
        bool v780;
        v780 = v726 == 5l;
        if (v780){
            v784 = US1_1(v723);
        } else {
            v784 = US1_0();
        }
    }
    US1 v809;
    switch (v784.tag) {
        case 0: { // None
            v809 = v721;
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v785 = v784.v.case1.v0;
            switch (v721.tag) {
                case 0: { // None
                    v809 = v784;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v786 = v721.v.case1.v0;
                    US4 v787;
                    v787 = US4_0();
                    int32_t v788; US4 v789;
                    Tuple10 tmp100 = TupleCreate10(0l, v787);
                    v788 = tmp100.v0; v789 = tmp100.v1;
                    while (method26(v788)){
                        ap_uint<4l> v791; ap_uint<2l> v792;
                        Tuple5 tmp101 = v785.v[v788];
                        v791 = tmp101.v0; v792 = tmp101.v1;
                        ap_uint<4l> v793; ap_uint<2l> v794;
                        Tuple5 tmp102 = v786.v[v788];
                        v793 = tmp102.v0; v794 = tmp102.v1;
                        US4 v802;
                        switch (v789.tag) {
                            case 0: { // Eq
                                bool v795;
                                v795 = v791 > v793;
                                if (v795){
                                    v802 = US4_1();
                                } else {
                                    bool v797;
                                    v797 = v791 < v793;
                                    if (v797){
                                        v802 = US4_2();
                                    } else {
                                        v802 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v802 = v789;
                            }
                        }
                        v789 = v802;
                        v788++;
                    }
                    bool v803;
                    switch (v789.tag) {
                        case 1: { // Gt
                            v803 = true;
                            break;
                        }
                        default: {
                            v803 = false;
                        }
                    }
                    array<5l,Tuple5> v804;
                    if (v803){
                        v804 = v785;
                    } else {
                        v804 = v786;
                    }
                    v809 = US1_1(v804);
                    break;
                }
            }
            break;
        }
    }
    US1 v834;
    switch (v809.tag) {
        case 0: { // None
            v834 = v658;
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v810 = v809.v.case1.v0;
            switch (v658.tag) {
                case 0: { // None
                    v834 = v809;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v811 = v658.v.case1.v0;
                    US4 v812;
                    v812 = US4_0();
                    int32_t v813; US4 v814;
                    Tuple10 tmp103 = TupleCreate10(0l, v812);
                    v813 = tmp103.v0; v814 = tmp103.v1;
                    while (method26(v813)){
                        ap_uint<4l> v816; ap_uint<2l> v817;
                        Tuple5 tmp104 = v810.v[v813];
                        v816 = tmp104.v0; v817 = tmp104.v1;
                        ap_uint<4l> v818; ap_uint<2l> v819;
                        Tuple5 tmp105 = v811.v[v813];
                        v818 = tmp105.v0; v819 = tmp105.v1;
                        US4 v827;
                        switch (v814.tag) {
                            case 0: { // Eq
                                bool v820;
                                v820 = v816 > v818;
                                if (v820){
                                    v827 = US4_1();
                                } else {
                                    bool v822;
                                    v822 = v816 < v818;
                                    if (v822){
                                        v827 = US4_2();
                                    } else {
                                        v827 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v827 = v814;
                            }
                        }
                        v814 = v827;
                        v813++;
                    }
                    bool v828;
                    switch (v814.tag) {
                        case 1: { // Gt
                            v828 = true;
                            break;
                        }
                        default: {
                            v828 = false;
                        }
                    }
                    array<5l,Tuple5> v829;
                    if (v828){
                        v829 = v810;
                    } else {
                        v829 = v811;
                    }
                    v834 = US1_1(v829);
                    break;
                }
            }
            break;
        }
    }
    US1 v859;
    switch (v834.tag) {
        case 0: { // None
            v859 = v595;
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v835 = v834.v.case1.v0;
            switch (v595.tag) {
                case 0: { // None
                    v859 = v834;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v836 = v595.v.case1.v0;
                    US4 v837;
                    v837 = US4_0();
                    int32_t v838; US4 v839;
                    Tuple10 tmp106 = TupleCreate10(0l, v837);
                    v838 = tmp106.v0; v839 = tmp106.v1;
                    while (method26(v838)){
                        ap_uint<4l> v841; ap_uint<2l> v842;
                        Tuple5 tmp107 = v835.v[v838];
                        v841 = tmp107.v0; v842 = tmp107.v1;
                        ap_uint<4l> v843; ap_uint<2l> v844;
                        Tuple5 tmp108 = v836.v[v838];
                        v843 = tmp108.v0; v844 = tmp108.v1;
                        US4 v852;
                        switch (v839.tag) {
                            case 0: { // Eq
                                bool v845;
                                v845 = v841 > v843;
                                if (v845){
                                    v852 = US4_1();
                                } else {
                                    bool v847;
                                    v847 = v841 < v843;
                                    if (v847){
                                        v852 = US4_2();
                                    } else {
                                        v852 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v852 = v839;
                            }
                        }
                        v839 = v852;
                        v838++;
                    }
                    bool v853;
                    switch (v839.tag) {
                        case 1: { // Gt
                            v853 = true;
                            break;
                        }
                        default: {
                            v853 = false;
                        }
                    }
                    array<5l,Tuple5> v854;
                    if (v853){
                        v854 = v835;
                    } else {
                        v854 = v836;
                    }
                    v859 = US1_1(v854);
                    break;
                }
            }
            break;
        }
    }
    ap_uint<4l> v860;
    v860 = 1ul;
    US7 v865;
    switch (v65.tag) {
        case 0: { // None
            v865 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v861 = v65.v.case1.v0;
            v865 = US7_1(v861, v860);
            break;
        }
    }
    ap_uint<4l> v866;
    v866 = 2ul;
    US7 v871;
    switch (v160.tag) {
        case 0: { // None
            v871 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v867 = v160.v.case1.v0;
            v871 = US7_1(v867, v866);
            break;
        }
    }
    ap_uint<4l> v872;
    v872 = 3ul;
    US7 v877;
    switch (v214.tag) {
        case 0: { // None
            v877 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v873 = v214.v.case1.v0;
            v877 = US7_1(v873, v872);
            break;
        }
    }
    ap_uint<4l> v878;
    v878 = 4ul;
    US7 v883;
    switch (v253.tag) {
        case 0: { // None
            v883 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v879 = v253.v.case1.v0;
            v883 = US7_1(v879, v878);
            break;
        }
    }
    ap_uint<4l> v884;
    v884 = 5ul;
    US7 v889;
    switch (v392.tag) {
        case 0: { // None
            v889 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v885 = v392.v.case1.v0;
            v889 = US7_1(v885, v884);
            break;
        }
    }
    ap_uint<4l> v890;
    v890 = 6ul;
    US7 v895;
    switch (v478.tag) {
        case 0: { // None
            v895 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v891 = v478.v.case1.v0;
            v895 = US7_1(v891, v890);
            break;
        }
    }
    ap_uint<4l> v896;
    v896 = 7ul;
    US7 v901;
    switch (v532.tag) {
        case 0: { // None
            v901 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v897 = v532.v.case1.v0;
            v901 = US7_1(v897, v896);
            break;
        }
    }
    ap_uint<4l> v902;
    v902 = 8ul;
    US7 v907;
    switch (v859.tag) {
        case 0: { // None
            v907 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v903 = v859.v.case1.v0;
            v907 = US7_1(v903, v902);
            break;
        }
    }
    US7 v909;
    switch (v907.tag) {
        case 0: { // None
            v909 = US7_0();
            break;
        }
        default: {
            v909 = v907;
        }
    }
    US7 v919;
    switch (v909.tag) {
        case 1: { // Some
            array<5l,Tuple5> v910 = v909.v.case1.v0; ap_uint<4l> v911 = v909.v.case1.v1;
            switch (v901.tag) {
                case 0: { // None
                    v919 = v909;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v912 = v901.v.case1.v0; ap_uint<4l> v913 = v901.v.case1.v1;
                    v919 = US7_1(v910, v911);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v901.tag) {
                case 0: { // None
                    v919 = v909;
                    break;
                }
                default: {
                    switch (v909.tag) {
                        case 0: { // None
                            v919 = v901;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v929;
    switch (v919.tag) {
        case 1: { // Some
            array<5l,Tuple5> v920 = v919.v.case1.v0; ap_uint<4l> v921 = v919.v.case1.v1;
            switch (v895.tag) {
                case 0: { // None
                    v929 = v919;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v922 = v895.v.case1.v0; ap_uint<4l> v923 = v895.v.case1.v1;
                    v929 = US7_1(v920, v921);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v895.tag) {
                case 0: { // None
                    v929 = v919;
                    break;
                }
                default: {
                    switch (v919.tag) {
                        case 0: { // None
                            v929 = v895;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v939;
    switch (v929.tag) {
        case 1: { // Some
            array<5l,Tuple5> v930 = v929.v.case1.v0; ap_uint<4l> v931 = v929.v.case1.v1;
            switch (v889.tag) {
                case 0: { // None
                    v939 = v929;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v932 = v889.v.case1.v0; ap_uint<4l> v933 = v889.v.case1.v1;
                    v939 = US7_1(v930, v931);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v889.tag) {
                case 0: { // None
                    v939 = v929;
                    break;
                }
                default: {
                    switch (v929.tag) {
                        case 0: { // None
                            v939 = v889;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v949;
    switch (v939.tag) {
        case 1: { // Some
            array<5l,Tuple5> v940 = v939.v.case1.v0; ap_uint<4l> v941 = v939.v.case1.v1;
            switch (v883.tag) {
                case 0: { // None
                    v949 = v939;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v942 = v883.v.case1.v0; ap_uint<4l> v943 = v883.v.case1.v1;
                    v949 = US7_1(v940, v941);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v883.tag) {
                case 0: { // None
                    v949 = v939;
                    break;
                }
                default: {
                    switch (v939.tag) {
                        case 0: { // None
                            v949 = v883;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v959;
    switch (v949.tag) {
        case 1: { // Some
            array<5l,Tuple5> v950 = v949.v.case1.v0; ap_uint<4l> v951 = v949.v.case1.v1;
            switch (v877.tag) {
                case 0: { // None
                    v959 = v949;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v952 = v877.v.case1.v0; ap_uint<4l> v953 = v877.v.case1.v1;
                    v959 = US7_1(v950, v951);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v877.tag) {
                case 0: { // None
                    v959 = v949;
                    break;
                }
                default: {
                    switch (v949.tag) {
                        case 0: { // None
                            v959 = v877;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v969;
    switch (v959.tag) {
        case 1: { // Some
            array<5l,Tuple5> v960 = v959.v.case1.v0; ap_uint<4l> v961 = v959.v.case1.v1;
            switch (v871.tag) {
                case 0: { // None
                    v969 = v959;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v962 = v871.v.case1.v0; ap_uint<4l> v963 = v871.v.case1.v1;
                    v969 = US7_1(v960, v961);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v871.tag) {
                case 0: { // None
                    v969 = v959;
                    break;
                }
                default: {
                    switch (v959.tag) {
                        case 0: { // None
                            v969 = v871;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v979;
    switch (v969.tag) {
        case 1: { // Some
            array<5l,Tuple5> v970 = v969.v.case1.v0; ap_uint<4l> v971 = v969.v.case1.v1;
            switch (v865.tag) {
                case 0: { // None
                    v979 = v969;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple5> v972 = v865.v.case1.v0; ap_uint<4l> v973 = v865.v.case1.v1;
                    v979 = US7_1(v970, v971);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v865.tag) {
                case 0: { // None
                    v979 = v969;
                    break;
                }
                default: {
                    switch (v969.tag) {
                        case 0: { // None
                            v979 = v865;
                            break;
                        }
                    }
                }
            }
        }
    }
    switch (v979.tag) {
        case 0: { // None
            ap_uint<4l> v982;
            v982 = 0ul;
            return TupleCreate6(v7, v982);
            break;
        }
        case 1: { // Some
            array<5l,Tuple5> v980 = v979.v.case1.v0; ap_uint<4l> v981 = v979.v.case1.v1;
            return TupleCreate6(v980, v981);
            break;
        }
    }
}
int32_t entry(){
    std::random_device v0;
    std::mt19937 v1(v0());
    std::uniform_int_distribution<std::mt19937::result_type> v2(0,51);
    uint64_t v3; int32_t v4;
    Tuple0 tmp0 = TupleCreate0(0ull, 0l);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (method0(v3)){
        array<5l,Tuple1> v6;
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
                v6.v[v16] = TupleCreate1(v17, v18);
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
        Tuple1 tmp1 = v6.v[0l];
        v23 = tmp1.v0; v24 = tmp1.v1;
        int8_t v25; int8_t v26;
        Tuple1 tmp2 = v6.v[1l];
        v25 = tmp2.v0; v26 = tmp2.v1;
        int8_t v27; int8_t v28;
        Tuple1 tmp3 = v6.v[2l];
        v27 = tmp3.v0; v28 = tmp3.v1;
        int8_t v29; int8_t v30;
        Tuple1 tmp4 = v6.v[3l];
        v29 = tmp4.v0; v30 = tmp4.v1;
        int8_t v31; int8_t v32;
        Tuple1 tmp5 = v6.v[4l];
        v31 = tmp5.v0; v32 = tmp5.v1;
        int8_t v33;
        v33 = v32 * 13;
        int8_t v34;
        v34 = v33 + v31;
        int32_t v35;
        v35 = (int32_t)v34;
        uint64_t v36;
        v36 = 1ull << v35;
        int8_t v37;
        v37 = v30 * 13;
        int8_t v38;
        v38 = v37 + v29;
        int32_t v39;
        v39 = (int32_t)v38;
        uint64_t v40;
        v40 = 1ull << v39;
        int8_t v41;
        v41 = v28 * 13;
        int8_t v42;
        v42 = v41 + v27;
        int32_t v43;
        v43 = (int32_t)v42;
        uint64_t v44;
        v44 = 1ull << v43;
        int8_t v45;
        v45 = v26 * 13;
        int8_t v46;
        v46 = v45 + v25;
        int32_t v47;
        v47 = (int32_t)v46;
        uint64_t v48;
        v48 = 1ull << v47;
        int8_t v49;
        v49 = v24 * 13;
        int8_t v50;
        v50 = v49 + v23;
        int32_t v51;
        v51 = (int32_t)v50;
        uint64_t v52;
        v52 = 1ull << v51;
        uint64_t v53;
        v53 = 0ull | v52;
        uint64_t v54;
        v54 = v53 | v48;
        uint64_t v55;
        v55 = v54 | v44;
        uint64_t v56;
        v56 = v55 | v40;
        uint64_t v57;
        v57 = v56 | v36;
        int8_t v58; int8_t v59; int8_t v60; int8_t v61; int8_t v62; int8_t v63;
        Tuple2 tmp10 = score_2(v57);
        v58 = tmp10.v0; v59 = tmp10.v1; v60 = tmp10.v2; v61 = tmp10.v3; v62 = tmp10.v4; v63 = tmp10.v5;
        int8_t v64;
        v64 = v58 / 13;
        int8_t v65;
        v65 = v58 % 13;
        int8_t v66;
        v66 = v59 / 13;
        int8_t v67;
        v67 = v59 % 13;
        int8_t v68;
        v68 = v60 / 13;
        int8_t v69;
        v69 = v60 % 13;
        int8_t v70;
        v70 = v61 / 13;
        int8_t v71;
        v71 = v61 % 13;
        int8_t v72;
        v72 = v62 / 13;
        int8_t v73;
        v73 = v62 % 13;
        array<5l,Tuple5> v74;
        uint32_t v75;
        v75 = (uint32_t)v23;
        ap_uint<4l> v76;
        v76 = v75;
        uint32_t v77;
        v77 = (uint32_t)v24;
        ap_uint<2l> v78;
        v78 = v77;
        v74.v[0l] = TupleCreate5(v76, v78);
        uint32_t v79;
        v79 = (uint32_t)v25;
        ap_uint<4l> v80;
        v80 = v79;
        uint32_t v81;
        v81 = (uint32_t)v26;
        ap_uint<2l> v82;
        v82 = v81;
        v74.v[1l] = TupleCreate5(v80, v82);
        uint32_t v83;
        v83 = (uint32_t)v27;
        ap_uint<4l> v84;
        v84 = v83;
        uint32_t v85;
        v85 = (uint32_t)v28;
        ap_uint<2l> v86;
        v86 = v85;
        v74.v[2l] = TupleCreate5(v84, v86);
        uint32_t v87;
        v87 = (uint32_t)v29;
        ap_uint<4l> v88;
        v88 = v87;
        uint32_t v89;
        v89 = (uint32_t)v30;
        ap_uint<2l> v90;
        v90 = v89;
        v74.v[3l] = TupleCreate5(v88, v90);
        uint32_t v91;
        v91 = (uint32_t)v31;
        ap_uint<4l> v92;
        v92 = v91;
        uint32_t v93;
        v93 = (uint32_t)v32;
        ap_uint<2l> v94;
        v94 = v93;
        v74.v[4l] = TupleCreate5(v92, v94);
        array<5l,Tuple5> v95; ap_uint<4l> v96;
        Tuple6 tmp109 = score25(v74);
        v95 = tmp109.v0; v96 = tmp109.v1;
        ap_uint<4l> v97; ap_uint<2l> v98;
        Tuple5 tmp110 = v95.v[0l];
        v97 = tmp110.v0; v98 = tmp110.v1;
        int8_t v99;
        v99 = v98;
        int8_t v100;
        v100 = v97;
        ap_uint<4l> v101; ap_uint<2l> v102;
        Tuple5 tmp111 = v95.v[1l];
        v101 = tmp111.v0; v102 = tmp111.v1;
        int8_t v103;
        v103 = v102;
        int8_t v104;
        v104 = v101;
        ap_uint<4l> v105; ap_uint<2l> v106;
        Tuple5 tmp112 = v95.v[2l];
        v105 = tmp112.v0; v106 = tmp112.v1;
        int8_t v107;
        v107 = v106;
        int8_t v108;
        v108 = v105;
        ap_uint<4l> v109; ap_uint<2l> v110;
        Tuple5 tmp113 = v95.v[3l];
        v109 = tmp113.v0; v110 = tmp113.v1;
        int8_t v111;
        v111 = v110;
        int8_t v112;
        v112 = v109;
        ap_uint<4l> v113; ap_uint<2l> v114;
        Tuple5 tmp114 = v95.v[4l];
        v113 = tmp114.v0; v114 = tmp114.v1;
        int8_t v115;
        v115 = v114;
        int8_t v116;
        v116 = v113;
        int8_t v117;
        v117 = v96;
        bool v118;
        v118 = v65 == v100;
        bool v120;
        if (v118){
            bool v119;
            v119 = v64 == v99;
            v120 = v119;
        } else {
            v120 = false;
        }
        bool v136;
        if (v120){
            bool v121;
            v121 = v67 == v104;
            bool v123;
            if (v121){
                bool v122;
                v122 = v66 == v103;
                v123 = v122;
            } else {
                v123 = false;
            }
            if (v123){
                bool v124;
                v124 = v69 == v108;
                bool v126;
                if (v124){
                    bool v125;
                    v125 = v68 == v107;
                    v126 = v125;
                } else {
                    v126 = false;
                }
                if (v126){
                    bool v127;
                    v127 = v71 == v112;
                    bool v129;
                    if (v127){
                        bool v128;
                        v128 = v70 == v111;
                        v129 = v128;
                    } else {
                        v129 = false;
                    }
                    if (v129){
                        bool v130;
                        v130 = v73 == v116;
                        if (v130){
                            bool v131;
                            v131 = v72 == v115;
                            v136 = v131;
                        } else {
                            v136 = false;
                        }
                    } else {
                        v136 = false;
                    }
                } else {
                    v136 = false;
                }
            } else {
                v136 = false;
            }
        } else {
            v136 = false;
        }
        bool v138;
        if (v136){
            bool v137;
            v137 = v63 == v117;
            v138 = v137;
        } else {
            v138 = false;
        }
        bool v139;
        v139 = v138 != true;
        int32_t v141;
        if (v139){
            std::cout << "{rank = " << (int) v23 << "; suit = " << (int) v24 << "}; " ;
            std::cout << "{rank = " << (int) v25 << "; suit = " << (int) v26 << "}; " ;
            std::cout << "{rank = " << (int) v27 << "; suit = " << (int) v28 << "}; " ;
            std::cout << "{rank = " << (int) v29 << "; suit = " << (int) v30 << "}; " ;
            std::cout << "{rank = " << (int) v31 << "; suit = " << (int) v32 << "}; " ;
            std::cout << std::endl;
            std::cout << "Score: " << (int) v63 << " " ;
            std::cout << "Card: ";
            std::cout << "(" << (int) v65 << "," << (int) v64 << ") " ;
            std::cout << "(" << (int) v67 << "," << (int) v66 << ") " ;
            std::cout << "(" << (int) v69 << "," << (int) v68 << ") " ;
            std::cout << "(" << (int) v71 << "," << (int) v70 << ") " ;
            std::cout << "(" << (int) v73 << "," << (int) v72 << ") " ;
            std::cout << std::endl;
            std::cout << "Score: " << (int) v117 << " " ;
            std::cout << "Card: ";
            std::cout << "(" << (int) v100 << "," << (int) v99 << ") " ;
            std::cout << "(" << (int) v104 << "," << (int) v103 << ") " ;
            std::cout << "(" << (int) v108 << "," << (int) v107 << ") " ;
            std::cout << "(" << (int) v112 << "," << (int) v111 << ") " ;
            std::cout << "(" << (int) v116 << "," << (int) v115 << ") " ;
            std::cout << std::endl;
            int32_t v140;
            v140 = v4 + 1l;
            v141 = v140;
        } else {
            v141 = v4;
        }
        v4 = v141;
        v3++;
    }
    return v4;
}
#endif
