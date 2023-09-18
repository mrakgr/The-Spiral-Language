#ifndef _ENTRY
#define _ENTRY
#include <cstdint>
#include "ap_int.h"
template <int dim, typename el> struct array { el v[dim]; };
#include <iostream>
#include <algorithm>
typedef struct {
    int8_t v0;
    int8_t v1;
    int8_t v2;
    int8_t v3;
    int8_t v4;
    int8_t v5;
} Tuple0;
typedef struct {
    uint16_t v1;
    int8_t v0;
} Tuple1;
typedef struct {
    uint64_t v1;
    int8_t v0;
} Tuple2;
typedef struct {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
} Tuple3;
typedef struct {
    array<5l,Tuple3> v0;
    ap_uint<4l> v1;
} Tuple4;
typedef bool (* Fun0)(Tuple3, Tuple3);
typedef struct {
    ap_uint<4l> v2;
    int32_t v1;
    int32_t v0;
} Tuple5;
struct US0 {
    ap_uint<2> tag;
    union U {
        struct {
            array<2l,Tuple3> v0;
            array<11l,Tuple3> v1;
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
            array<5l,Tuple3> v0;
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
            array<2l,Tuple3> v0;
            array<9l,Tuple3> v1;
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
            array<3l,Tuple3> v0;
            array<10l,Tuple3> v1;
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
    int32_t v0;
    int32_t v1;
} Tuple6;
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
} Tuple7;
struct US5 {
    ap_uint<2> tag;
    union U {
        struct {
            array<2l,Tuple3> v0;
            array<8l,Tuple3> v1;
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
            array<4l,Tuple3> v0;
            array<9l,Tuple3> v1;
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
            array<5l,Tuple3> v0;
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
bool method2(int8_t v0);
bool method3(int8_t v0);
uint32_t loop_ranks5(uint64_t v0, int8_t v1, int8_t v2);
uint32_t try_suit4(uint64_t v0, uint16_t v1, int8_t v2);
uint32_t loop7(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_suits9(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5);
uint32_t loop_ranks8(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_ranks13(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t try_suit12(uint64_t v0, uint16_t v1, int8_t v2);
uint32_t loop_suits19(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5, uint32_t v6);
uint32_t loop_ranks18(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5);
uint32_t loop_suits22(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_ranks21(uint64_t v0, int8_t v1, int8_t v2, uint32_t v3);
uint64_t loop_pair20(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_pair17(uint64_t v0, uint64_t v1, int8_t v2, uint32_t v3, int8_t v4);
uint64_t loop_pair_16(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_triple15(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop14(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_pair11(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3, uint32_t v4, int8_t v5);
uint64_t loop_triple10(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3);
uint64_t loop_ranks6(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3);
uint64_t method1(uint64_t v0);
Tuple0 score_0(uint64_t v0);
bool method24(int32_t v0);
bool method25(int32_t v0);
bool method26(int32_t v0, int32_t v1);
bool method27(int32_t v0);
bool method28(int32_t v0);
bool method29(int32_t v0);
bool method30(int32_t v0);
bool method31(int32_t v0);
bool method32(int32_t v0);
bool method33(int32_t v0);
bool method34(int32_t v0);
Tuple4 score23(array<13l,Tuple3> v0);
static inline Tuple0 TupleCreate0(int8_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4; x.v5 = v5;
    return x;
}
static inline Tuple1 TupleCreate1(int8_t v0, uint16_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method2(int8_t v0){
    bool v1;
    v1 = v0 < 13;
    return v1;
}
bool method3(int8_t v0){
    bool v1;
    v1 = v0 < 4;
    return v1;
}
static inline Tuple2 TupleCreate2(int8_t v0, uint64_t v1){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
uint32_t loop_ranks5(uint64_t v0, int8_t v1, int8_t v2){
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
            return loop_ranks5(v0, v1, v58);
        }
    } else {
        return 0ul;
    }
}
uint32_t try_suit4(uint64_t v0, uint16_t v1, int8_t v2){
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
        return loop_ranks5(v0, v2, v9);
    } else {
        return 0ul;
    }
}
uint32_t loop7(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
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
            return loop7(v0, v1, v15, v16, v19);
        } else {
            int8_t v21;
            v21 = v2 + 1;
            return loop7(v0, v1, v21, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_suits9(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5){
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
                return loop_suits9(v0, v1, v2, v15, v16, v19);
            } else {
                int8_t v21;
                v21 = v3 + 1;
                return loop_suits9(v0, v1, v2, v21, v4, v5);
            }
        } else {
            int8_t v24;
            v24 = v2 - 1;
            return loop_ranks8(v0, v1, v24, v4, v5);
        }
    } else {
        return v5;
    }
}
uint32_t loop_ranks8(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
    bool v5;
    v5 = 0 <= v2;
    if (v5){
        bool v6;
        v6 = v1 == v2;
        if (v6){
            int8_t v7;
            v7 = v2 - 1;
            return loop_ranks8(v0, v1, v7, v3, v4);
        } else {
            int8_t v9;
            v9 = 0;
            return loop_suits9(v0, v1, v2, v9, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_ranks13(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
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
            return loop_ranks13(v0, v1, v15, v16, v19);
        } else {
            int8_t v21;
            v21 = v2 - 1;
            return loop_ranks13(v0, v1, v21, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t try_suit12(uint64_t v0, uint16_t v1, int8_t v2){
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
        return loop_ranks13(v0, v2, v9, v10, v11);
    } else {
        return 0ul;
    }
}
uint32_t loop_suits19(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5, uint32_t v6){
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
                return loop_suits19(v0, v1, v2, v3, v16, v17, v20);
            } else {
                int8_t v22;
                v22 = v4 + 1;
                return loop_suits19(v0, v1, v2, v3, v22, v5, v6);
            }
        } else {
            int8_t v25;
            v25 = v3 - 1;
            return loop_ranks18(v0, v1, v2, v25, v5, v6);
        }
    } else {
        return v6;
    }
}
uint32_t loop_ranks18(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5){
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
            return loop_ranks18(v0, v1, v2, v10, v4, v5);
        } else {
            int8_t v12;
            v12 = 0;
            return loop_suits19(v0, v1, v2, v3, v12, v4, v5);
        }
    } else {
        return v5;
    }
}
uint32_t loop_suits22(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
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
                return loop_suits22(v0, v1, v14, v15, v18);
            } else {
                int8_t v20;
                v20 = v2 + 1;
                return loop_suits22(v0, v1, v20, v3, v4);
            }
        } else {
            int8_t v23;
            v23 = v1 - 1;
            return loop_ranks21(v0, v23, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_ranks21(uint64_t v0, int8_t v1, int8_t v2, uint32_t v3){
    bool v4;
    v4 = 0 <= v1;
    if (v4){
        int8_t v5;
        v5 = 0;
        return loop_suits22(v0, v1, v5, v2, v3);
    } else {
        return v3;
    }
}
uint64_t loop_pair20(uint64_t v0, uint64_t v1, int8_t v2){
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
            v13 = loop7(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            int8_t v15;
            v15 = 3;
            uint32_t v16;
            v16 = loop_ranks8(v1, v2, v14, v15, v13);
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
            return loop_pair20(v0, v1, v21);
        }
    } else {
        int8_t v24;
        v24 = 12;
        int8_t v25;
        v25 = 5;
        uint32_t v26;
        v26 = 0ul;
        uint32_t v27;
        v27 = loop_ranks21(v1, v24, v25, v26);
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
uint64_t loop_pair17(uint64_t v0, uint64_t v1, int8_t v2, uint32_t v3, int8_t v4){
    bool v5;
    v5 = v2 == v4;
    if (v5){
        int8_t v6;
        v6 = v4 - 1;
        return loop_pair17(v0, v1, v2, v3, v6);
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
                v17 = loop7(v1, v4, v15, v16, v3);
                int8_t v18;
                v18 = 12;
                int8_t v19;
                v19 = 1;
                uint32_t v20;
                v20 = loop_ranks18(v1, v2, v4, v18, v19, v17);
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
                return loop_pair17(v0, v1, v2, v3, v25);
            }
        } else {
            int8_t v28;
            v28 = 12;
            return loop_pair20(v0, v1, v28);
        }
    }
}
uint64_t loop_pair_16(uint64_t v0, uint64_t v1, int8_t v2){
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
            v13 = loop7(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            return loop_pair17(v0, v1, v2, v13, v14);
        } else {
            int8_t v16;
            v16 = v2 - 1;
            return loop_pair_16(v0, v1, v16);
        }
    } else {
        int8_t v19;
        v19 = 12;
        return loop_pair20(v0, v1, v19);
    }
}
uint64_t loop_triple15(uint64_t v0, uint64_t v1, int8_t v2){
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
            v13 = loop7(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            int8_t v15;
            v15 = 2;
            uint32_t v16;
            v16 = loop_ranks8(v1, v2, v14, v15, v13);
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
            return loop_triple15(v0, v1, v21);
        }
    } else {
        int8_t v24;
        v24 = 12;
        return loop_pair_16(v0, v1, v24);
    }
}
uint64_t loop14(uint64_t v0, uint64_t v1, int8_t v2){
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
            v54 = loop7(v1, v4, v51, v52, v53);
            int8_t v55;
            v55 = 0;
            int8_t v56;
            v56 = 1;
            uint32_t v57;
            v57 = loop7(v1, v12, v55, v56, v54);
            int8_t v58;
            v58 = 0;
            int8_t v59;
            v59 = 1;
            uint32_t v60;
            v60 = loop7(v1, v21, v58, v59, v57);
            int8_t v61;
            v61 = 0;
            int8_t v62;
            v62 = 1;
            uint32_t v63;
            v63 = loop7(v1, v30, v61, v62, v60);
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
            v68 = loop7(v1, v65, v66, v67, v63);
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
            return loop14(v0, v1, v73);
        }
    } else {
        int8_t v76;
        v76 = 12;
        return loop_triple15(v0, v1, v76);
    }
}
uint64_t loop_pair11(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3, uint32_t v4, int8_t v5){
    bool v6;
    v6 = 0 <= v5;
    if (v6){
        bool v7;
        v7 = v3 == v5;
        if (v7){
            int8_t v8;
            v8 = v5 - 1;
            return loop_pair11(v0, v1, v2, v3, v4, v8);
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
                v18 = loop7(v1, v5, v16, v17, v4);
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
                return loop_pair11(v0, v1, v2, v3, v4, v23);
            }
        }
    } else {
        int8_t v27;
        v27 = 0;
        uint32_t v28;
        v28 = try_suit12(v1, v2, v27);
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
        v32 = try_suit12(v1, v2, v31);
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
        v36 = try_suit12(v1, v2, v35);
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
        v40 = try_suit12(v1, v2, v39);
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
            return loop14(v0, v1, v48);
        }
    }
}
uint64_t loop_triple10(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3){
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
            v14 = loop7(v1, v3, v11, v12, v13);
            int8_t v15;
            v15 = 12;
            return loop_pair11(v0, v1, v2, v3, v14, v15);
        } else {
            int8_t v17;
            v17 = v3 - 1;
            return loop_triple10(v0, v1, v2, v17);
        }
    } else {
        int8_t v20;
        v20 = 0;
        uint32_t v21;
        v21 = try_suit12(v1, v2, v20);
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
        v25 = try_suit12(v1, v2, v24);
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
        v29 = try_suit12(v1, v2, v28);
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
        v33 = try_suit12(v1, v2, v32);
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
            return loop14(v0, v1, v41);
        }
    }
}
uint64_t loop_ranks6(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3){
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
            v14 = loop7(v1, v3, v11, v12, v13);
            int8_t v15;
            v15 = 12;
            int8_t v16;
            v16 = 1;
            uint32_t v17;
            v17 = loop_ranks8(v1, v3, v15, v16, v14);
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
            return loop_ranks6(v0, v1, v2, v22);
        }
    } else {
        int8_t v25;
        v25 = 12;
        return loop_triple10(v0, v1, v2, v25);
    }
}
uint64_t method1(uint64_t v0){
    int8_t v1; uint16_t v2;
    Tuple1 tmp0 = TupleCreate1(0, 0u);
    v1 = tmp0.v0; v2 = tmp0.v1;
    while (method2(v1)){
        int8_t v4; uint16_t v5;
        Tuple1 tmp1 = TupleCreate1(0, v2);
        v4 = tmp1.v0; v5 = tmp1.v1;
        while (method3(v4)){
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
    Tuple2 tmp2 = TupleCreate2(0, 0ull);
    v19 = tmp2.v0; v20 = tmp2.v1;
    while (method2(v19)){
        int8_t v22; uint64_t v23;
        Tuple2 tmp3 = TupleCreate2(0, v20);
        v22 = tmp3.v0; v23 = tmp3.v1;
        while (method3(v22)){
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
    v38 = try_suit4(v0, v2, v37);
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
    v42 = try_suit4(v0, v2, v41);
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
    v46 = try_suit4(v0, v2, v45);
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
    v50 = try_suit4(v0, v2, v49);
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
        return loop_ranks6(v20, v0, v2, v58);
    }
}
Tuple0 score_0(uint64_t v0){
    uint64_t v1;
    v1 = method1(v0);
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
    return TupleCreate0(v17, v16, v13, v10, v7, v3);
}
static inline Tuple3 TupleCreate3(ap_uint<4l> v0, ap_uint<2l> v1){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple4 TupleCreate4(array<5l,Tuple3> v0, ap_uint<4l> v1){
    Tuple4 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method24(int32_t v0){
    bool v1;
    v1 = v0 < 13l;
    return v1;
}
bool ClosureMethod0(Tuple3 tup0, Tuple3 tup1){
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
bool method25(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
static inline Tuple5 TupleCreate5(int32_t v0, int32_t v1, ap_uint<4l> v2){
    Tuple5 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(array<2l,Tuple3> v0, array<11l,Tuple3> v1) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method26(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
bool method27(int32_t v0){
    bool v1;
    v1 = v0 < 11l;
    return v1;
}
US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(array<5l,Tuple3> v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
bool method28(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
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
US2 US2_1(array<2l,Tuple3> v0, array<9l,Tuple3> v1) { // Some
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method30(int32_t v0){
    bool v1;
    v1 = v0 < 9l;
    return v1;
}
bool method31(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1(array<3l,Tuple3> v0, array<10l,Tuple3> v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method32(int32_t v0){
    bool v1;
    v1 = v0 < 10l;
    return v1;
}
static inline Tuple6 TupleCreate6(int32_t v0, int32_t v1){
    Tuple6 x;
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
static inline Tuple7 TupleCreate7(int32_t v0, US4 v1){
    Tuple7 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(array<2l,Tuple3> v0, array<8l,Tuple3> v1) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method33(int32_t v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
US6 US6_1(array<4l,Tuple3> v0, array<9l,Tuple3> v1) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method34(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
US7 US7_1(array<5l,Tuple3> v0, ap_uint<4l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple4 score23(array<13l,Tuple3> v0){
    array<13l,Tuple3> v1;
    int32_t v2;
    v2 = 0l;
    while (method24(v2)){
        ap_uint<4l> v4; ap_uint<2l> v5;
        Tuple3 tmp5 = v0.v[v2];
        v4 = tmp5.v0; v5 = tmp5.v1;
        v1.v[v2] = TupleCreate3(v4, v5);
        v2++;
    }
    Fun0 v6;
    v6 = ClosureMethod0;
    std::sort(v1.v,v1.v+13l,v6);
    array<5l,Tuple3> v7;
    int32_t v8;
    v8 = 0l;
    while (method25(v8)){
        ap_uint<4l> v10; ap_uint<2l> v11;
        Tuple3 tmp6 = v1.v[v8];
        v10 = tmp6.v0; v11 = tmp6.v1;
        v7.v[v8] = TupleCreate3(v10, v11);
        v8++;
    }
    array<2l,Tuple3> v12;
    array<11l,Tuple3> v13;
    ap_uint<4l> v14;
    v14 = 12ul;
    int32_t v15; int32_t v16; ap_uint<4l> v17;
    Tuple5 tmp7 = TupleCreate5(0l, 0l, v14);
    v15 = tmp7.v0; v16 = tmp7.v1; v17 = tmp7.v2;
    while (method24(v15)){
        ap_uint<4l> v19; ap_uint<2l> v20;
        Tuple3 tmp8 = v1.v[v15];
        v19 = tmp8.v0; v20 = tmp8.v1;
        bool v21;
        v21 = v16 < 2l;
        int32_t v25; ap_uint<4l> v26;
        if (v21){
            bool v22;
            v22 = v17 == v19;
            int32_t v23;
            if (v22){
                v23 = v16;
            } else {
                v23 = 0l;
            }
            v12.v[v23] = TupleCreate3(v19, v20);
            int32_t v24;
            v24 = v23 + 1l;
            v25 = v24; v26 = v19;
        } else {
            v25 = v16; v26 = v17;
        }
        v16 = v25;
        v17 = v26;
        v15++;
    }
    bool v27;
    v27 = v16 == 2l;
    US0 v40;
    if (v27){
        int32_t v28;
        v28 = v16 - 2l;
        int32_t v29;
        v29 = 0l;
        while (method26(v28, v29)){
            ap_uint<4l> v31; ap_uint<2l> v32;
            Tuple3 tmp9 = v1.v[v29];
            v31 = tmp9.v0; v32 = tmp9.v1;
            v13.v[v29] = TupleCreate3(v31, v32);
            v29++;
        }
        int32_t v33;
        v33 = v28;
        while (method27(v33)){
            int32_t v35;
            v35 = 2l + v33;
            ap_uint<4l> v36; ap_uint<2l> v37;
            Tuple3 tmp10 = v1.v[v35];
            v36 = tmp10.v0; v37 = tmp10.v1;
            v13.v[v33] = TupleCreate3(v36, v37);
            v33++;
        }
        v40 = US0_1(v12, v13);
    } else {
        v40 = US0_0();
    }
    US1 v62;
    switch (v40.tag) {
        case 0: { // None
            v62 = US1_0();
            break;
        }
        case 1: { // Some
            array<2l,Tuple3> v41 = v40.v.case1.v0; array<11l,Tuple3> v42 = v40.v.case1.v1;
            array<3l,Tuple3> v43;
            int32_t v44;
            v44 = 0l;
            while (method28(v44)){
                ap_uint<4l> v46; ap_uint<2l> v47;
                Tuple3 tmp11 = v42.v[v44];
                v46 = tmp11.v0; v47 = tmp11.v1;
                v43.v[v44] = TupleCreate3(v46, v47);
                v44++;
            }
            array<0l,Tuple3> v48;
            array<5l,Tuple3> v49;
            int32_t v50;
            v50 = 0l;
            while (method29(v50)){
                ap_uint<4l> v52; ap_uint<2l> v53;
                Tuple3 tmp12 = v41.v[v50];
                v52 = tmp12.v0; v53 = tmp12.v1;
                v49.v[v50] = TupleCreate3(v52, v53);
                v50++;
            }
            int32_t v54;
            v54 = 0l;
            while (method28(v54)){
                ap_uint<4l> v56; ap_uint<2l> v57;
                Tuple3 tmp13 = v43.v[v54];
                v56 = tmp13.v0; v57 = tmp13.v1;
                int32_t v58;
                v58 = 2l + v54;
                v49.v[v58] = TupleCreate3(v56, v57);
                v54++;
            }
            v62 = US1_1(v49);
            break;
        }
    }
    array<2l,Tuple3> v63;
    array<11l,Tuple3> v64;
    ap_uint<4l> v65;
    v65 = 12ul;
    int32_t v66; int32_t v67; ap_uint<4l> v68;
    Tuple5 tmp14 = TupleCreate5(0l, 0l, v65);
    v66 = tmp14.v0; v67 = tmp14.v1; v68 = tmp14.v2;
    while (method24(v66)){
        ap_uint<4l> v70; ap_uint<2l> v71;
        Tuple3 tmp15 = v1.v[v66];
        v70 = tmp15.v0; v71 = tmp15.v1;
        bool v72;
        v72 = v67 < 2l;
        int32_t v76; ap_uint<4l> v77;
        if (v72){
            bool v73;
            v73 = v68 == v70;
            int32_t v74;
            if (v73){
                v74 = v67;
            } else {
                v74 = 0l;
            }
            v63.v[v74] = TupleCreate3(v70, v71);
            int32_t v75;
            v75 = v74 + 1l;
            v76 = v75; v77 = v70;
        } else {
            v76 = v67; v77 = v68;
        }
        v67 = v76;
        v68 = v77;
        v66++;
    }
    bool v78;
    v78 = v67 == 2l;
    US0 v91;
    if (v78){
        int32_t v79;
        v79 = v67 - 2l;
        int32_t v80;
        v80 = 0l;
        while (method26(v79, v80)){
            ap_uint<4l> v82; ap_uint<2l> v83;
            Tuple3 tmp16 = v1.v[v80];
            v82 = tmp16.v0; v83 = tmp16.v1;
            v64.v[v80] = TupleCreate3(v82, v83);
            v80++;
        }
        int32_t v84;
        v84 = v79;
        while (method27(v84)){
            int32_t v86;
            v86 = 2l + v84;
            ap_uint<4l> v87; ap_uint<2l> v88;
            Tuple3 tmp17 = v1.v[v86];
            v87 = tmp17.v0; v88 = tmp17.v1;
            v64.v[v84] = TupleCreate3(v87, v88);
            v84++;
        }
        v91 = US0_1(v63, v64);
    } else {
        v91 = US0_0();
    }
    US1 v151;
    switch (v91.tag) {
        case 0: { // None
            v151 = US1_0();
            break;
        }
        case 1: { // Some
            array<2l,Tuple3> v92 = v91.v.case1.v0; array<11l,Tuple3> v93 = v91.v.case1.v1;
            array<2l,Tuple3> v94;
            array<9l,Tuple3> v95;
            ap_uint<4l> v96;
            v96 = 12ul;
            int32_t v97; int32_t v98; ap_uint<4l> v99;
            Tuple5 tmp18 = TupleCreate5(0l, 0l, v96);
            v97 = tmp18.v0; v98 = tmp18.v1; v99 = tmp18.v2;
            while (method27(v97)){
                ap_uint<4l> v101; ap_uint<2l> v102;
                Tuple3 tmp19 = v93.v[v97];
                v101 = tmp19.v0; v102 = tmp19.v1;
                bool v103;
                v103 = v98 < 2l;
                int32_t v107; ap_uint<4l> v108;
                if (v103){
                    bool v104;
                    v104 = v99 == v101;
                    int32_t v105;
                    if (v104){
                        v105 = v98;
                    } else {
                        v105 = 0l;
                    }
                    v94.v[v105] = TupleCreate3(v101, v102);
                    int32_t v106;
                    v106 = v105 + 1l;
                    v107 = v106; v108 = v101;
                } else {
                    v107 = v98; v108 = v99;
                }
                v98 = v107;
                v99 = v108;
                v97++;
            }
            bool v109;
            v109 = v98 == 2l;
            US2 v122;
            if (v109){
                int32_t v110;
                v110 = v98 - 2l;
                int32_t v111;
                v111 = 0l;
                while (method26(v110, v111)){
                    ap_uint<4l> v113; ap_uint<2l> v114;
                    Tuple3 tmp20 = v93.v[v111];
                    v113 = tmp20.v0; v114 = tmp20.v1;
                    v95.v[v111] = TupleCreate3(v113, v114);
                    v111++;
                }
                int32_t v115;
                v115 = v110;
                while (method30(v115)){
                    int32_t v117;
                    v117 = 2l + v115;
                    ap_uint<4l> v118; ap_uint<2l> v119;
                    Tuple3 tmp21 = v93.v[v117];
                    v118 = tmp21.v0; v119 = tmp21.v1;
                    v95.v[v115] = TupleCreate3(v118, v119);
                    v115++;
                }
                v122 = US2_1(v94, v95);
            } else {
                v122 = US2_0();
            }
            switch (v122.tag) {
                case 0: { // None
                    v151 = US1_0();
                    break;
                }
                case 1: { // Some
                    array<2l,Tuple3> v123 = v122.v.case1.v0; array<9l,Tuple3> v124 = v122.v.case1.v1;
                    array<1l,Tuple3> v125;
                    int32_t v126;
                    v126 = 0l;
                    while (method31(v126)){
                        ap_uint<4l> v128; ap_uint<2l> v129;
                        Tuple3 tmp22 = v124.v[v126];
                        v128 = tmp22.v0; v129 = tmp22.v1;
                        v125.v[v126] = TupleCreate3(v128, v129);
                        v126++;
                    }
                    array<5l,Tuple3> v130;
                    int32_t v131;
                    v131 = 0l;
                    while (method29(v131)){
                        ap_uint<4l> v133; ap_uint<2l> v134;
                        Tuple3 tmp23 = v92.v[v131];
                        v133 = tmp23.v0; v134 = tmp23.v1;
                        v130.v[v131] = TupleCreate3(v133, v134);
                        v131++;
                    }
                    int32_t v135;
                    v135 = 0l;
                    while (method29(v135)){
                        ap_uint<4l> v137; ap_uint<2l> v138;
                        Tuple3 tmp24 = v123.v[v135];
                        v137 = tmp24.v0; v138 = tmp24.v1;
                        int32_t v139;
                        v139 = 2l + v135;
                        v130.v[v139] = TupleCreate3(v137, v138);
                        v135++;
                    }
                    int32_t v140;
                    v140 = 0l;
                    while (method31(v140)){
                        ap_uint<4l> v142; ap_uint<2l> v143;
                        Tuple3 tmp25 = v125.v[v140];
                        v142 = tmp25.v0; v143 = tmp25.v1;
                        int32_t v144;
                        v144 = 4l + v140;
                        v130.v[v144] = TupleCreate3(v142, v143);
                        v140++;
                    }
                    v151 = US1_1(v130);
                    break;
                }
            }
            break;
        }
    }
    array<3l,Tuple3> v152;
    array<10l,Tuple3> v153;
    ap_uint<4l> v154;
    v154 = 12ul;
    int32_t v155; int32_t v156; ap_uint<4l> v157;
    Tuple5 tmp26 = TupleCreate5(0l, 0l, v154);
    v155 = tmp26.v0; v156 = tmp26.v1; v157 = tmp26.v2;
    while (method24(v155)){
        ap_uint<4l> v159; ap_uint<2l> v160;
        Tuple3 tmp27 = v1.v[v155];
        v159 = tmp27.v0; v160 = tmp27.v1;
        bool v161;
        v161 = v156 < 3l;
        int32_t v165; ap_uint<4l> v166;
        if (v161){
            bool v162;
            v162 = v157 == v159;
            int32_t v163;
            if (v162){
                v163 = v156;
            } else {
                v163 = 0l;
            }
            v152.v[v163] = TupleCreate3(v159, v160);
            int32_t v164;
            v164 = v163 + 1l;
            v165 = v164; v166 = v159;
        } else {
            v165 = v156; v166 = v157;
        }
        v156 = v165;
        v157 = v166;
        v155++;
    }
    bool v167;
    v167 = v156 == 3l;
    US3 v180;
    if (v167){
        int32_t v168;
        v168 = v156 - 3l;
        int32_t v169;
        v169 = 0l;
        while (method26(v168, v169)){
            ap_uint<4l> v171; ap_uint<2l> v172;
            Tuple3 tmp28 = v1.v[v169];
            v171 = tmp28.v0; v172 = tmp28.v1;
            v153.v[v169] = TupleCreate3(v171, v172);
            v169++;
        }
        int32_t v173;
        v173 = v168;
        while (method32(v173)){
            int32_t v175;
            v175 = 3l + v173;
            ap_uint<4l> v176; ap_uint<2l> v177;
            Tuple3 tmp29 = v1.v[v175];
            v176 = tmp29.v0; v177 = tmp29.v1;
            v153.v[v173] = TupleCreate3(v176, v177);
            v173++;
        }
        v180 = US3_1(v152, v153);
    } else {
        v180 = US3_0();
    }
    US1 v202;
    switch (v180.tag) {
        case 0: { // None
            v202 = US1_0();
            break;
        }
        case 1: { // Some
            array<3l,Tuple3> v181 = v180.v.case1.v0; array<10l,Tuple3> v182 = v180.v.case1.v1;
            array<2l,Tuple3> v183;
            int32_t v184;
            v184 = 0l;
            while (method29(v184)){
                ap_uint<4l> v186; ap_uint<2l> v187;
                Tuple3 tmp30 = v182.v[v184];
                v186 = tmp30.v0; v187 = tmp30.v1;
                v183.v[v184] = TupleCreate3(v186, v187);
                v184++;
            }
            array<0l,Tuple3> v188;
            array<5l,Tuple3> v189;
            int32_t v190;
            v190 = 0l;
            while (method28(v190)){
                ap_uint<4l> v192; ap_uint<2l> v193;
                Tuple3 tmp31 = v181.v[v190];
                v192 = tmp31.v0; v193 = tmp31.v1;
                v189.v[v190] = TupleCreate3(v192, v193);
                v190++;
            }
            int32_t v194;
            v194 = 0l;
            while (method29(v194)){
                ap_uint<4l> v196; ap_uint<2l> v197;
                Tuple3 tmp32 = v183.v[v194];
                v196 = tmp32.v0; v197 = tmp32.v1;
                int32_t v198;
                v198 = 3l + v194;
                v189.v[v198] = TupleCreate3(v196, v197);
                v194++;
            }
            v202 = US1_1(v189);
            break;
        }
    }
    array<5l,Tuple3> v203;
    ap_uint<4l> v204;
    v204 = 12ul;
    int32_t v205; int32_t v206; ap_uint<4l> v207;
    Tuple5 tmp33 = TupleCreate5(0l, 0l, v204);
    v205 = tmp33.v0; v206 = tmp33.v1; v207 = tmp33.v2;
    while (method24(v205)){
        ap_uint<4l> v209; ap_uint<2l> v210;
        Tuple3 tmp34 = v1.v[v205];
        v209 = tmp34.v0; v210 = tmp34.v1;
        bool v211;
        v211 = v206 < 5l;
        bool v216;
        if (v211){
            ap_uint<4l> v212;
            v212 = 1ul;
            ap_uint<4l> v213;
            v213 = v209 - v212;
            bool v214;
            v214 = v207 == v213;
            bool v215;
            v215 = v214 != true;
            v216 = v215;
        } else {
            v216 = false;
        }
        int32_t v222; ap_uint<4l> v223;
        if (v216){
            bool v217;
            v217 = v207 == v209;
            int32_t v218;
            if (v217){
                v218 = v206;
            } else {
                v218 = 0l;
            }
            v203.v[v218] = TupleCreate3(v209, v210);
            int32_t v219;
            v219 = v218 + 1l;
            ap_uint<4l> v220;
            v220 = 1ul;
            ap_uint<4l> v221;
            v221 = v209 - v220;
            v222 = v219; v223 = v221;
        } else {
            v222 = v206; v223 = v207;
        }
        v206 = v222;
        v207 = v223;
        v205++;
    }
    bool v224;
    v224 = v206 == 4l;
    bool v235;
    if (v224){
        ap_uint<4l> v225;
        v225 = 0ul;
        ap_uint<4l> v226;
        v226 = 1ul;
        ap_uint<4l> v227;
        v227 = v225 - v226;
        bool v228;
        v228 = v207 == v227;
        if (v228){
            ap_uint<4l> v229; ap_uint<2l> v230;
            Tuple3 tmp35 = v1.v[0l];
            v229 = tmp35.v0; v230 = tmp35.v1;
            ap_uint<4l> v231;
            v231 = 12ul;
            bool v232;
            v232 = v229 == v231;
            if (v232){
                v203.v[4l] = TupleCreate3(v229, v230);
                v235 = true;
            } else {
                v235 = false;
            }
        } else {
            v235 = false;
        }
    } else {
        v235 = false;
    }
    US1 v241;
    if (v235){
        v241 = US1_1(v203);
    } else {
        bool v237;
        v237 = v206 == 5l;
        if (v237){
            v241 = US1_1(v203);
        } else {
            v241 = US1_0();
        }
    }
    array<5l,Tuple3> v242;
    int32_t v243; int32_t v244;
    Tuple6 tmp36 = TupleCreate6(0l, 0l);
    v243 = tmp36.v0; v244 = tmp36.v1;
    while (method24(v243)){
        ap_uint<4l> v246; ap_uint<2l> v247;
        Tuple3 tmp37 = v1.v[v243];
        v246 = tmp37.v0; v247 = tmp37.v1;
        ap_uint<2l> v248;
        v248 = 3ul;
        bool v249;
        v249 = v247 == v248;
        bool v251;
        if (v249){
            bool v250;
            v250 = v244 < 5l;
            v251 = v250;
        } else {
            v251 = false;
        }
        int32_t v253;
        if (v251){
            v242.v[v244] = TupleCreate3(v246, v247);
            int32_t v252;
            v252 = v244 + 1l;
            v253 = v252;
        } else {
            v253 = v244;
        }
        v244 = v253;
        v243++;
    }
    bool v254;
    v254 = v244 == 5l;
    US1 v257;
    if (v254){
        v257 = US1_1(v242);
    } else {
        v257 = US1_0();
    }
    array<5l,Tuple3> v258;
    int32_t v259; int32_t v260;
    Tuple6 tmp38 = TupleCreate6(0l, 0l);
    v259 = tmp38.v0; v260 = tmp38.v1;
    while (method24(v259)){
        ap_uint<4l> v262; ap_uint<2l> v263;
        Tuple3 tmp39 = v1.v[v259];
        v262 = tmp39.v0; v263 = tmp39.v1;
        ap_uint<2l> v264;
        v264 = 2ul;
        bool v265;
        v265 = v263 == v264;
        bool v267;
        if (v265){
            bool v266;
            v266 = v260 < 5l;
            v267 = v266;
        } else {
            v267 = false;
        }
        int32_t v269;
        if (v267){
            v258.v[v260] = TupleCreate3(v262, v263);
            int32_t v268;
            v268 = v260 + 1l;
            v269 = v268;
        } else {
            v269 = v260;
        }
        v260 = v269;
        v259++;
    }
    bool v270;
    v270 = v260 == 5l;
    US1 v273;
    if (v270){
        v273 = US1_1(v258);
    } else {
        v273 = US1_0();
    }
    array<5l,Tuple3> v274;
    int32_t v275; int32_t v276;
    Tuple6 tmp40 = TupleCreate6(0l, 0l);
    v275 = tmp40.v0; v276 = tmp40.v1;
    while (method24(v275)){
        ap_uint<4l> v278; ap_uint<2l> v279;
        Tuple3 tmp41 = v1.v[v275];
        v278 = tmp41.v0; v279 = tmp41.v1;
        ap_uint<2l> v280;
        v280 = 1ul;
        bool v281;
        v281 = v279 == v280;
        bool v283;
        if (v281){
            bool v282;
            v282 = v276 < 5l;
            v283 = v282;
        } else {
            v283 = false;
        }
        int32_t v285;
        if (v283){
            v274.v[v276] = TupleCreate3(v278, v279);
            int32_t v284;
            v284 = v276 + 1l;
            v285 = v284;
        } else {
            v285 = v276;
        }
        v276 = v285;
        v275++;
    }
    bool v286;
    v286 = v276 == 5l;
    US1 v289;
    if (v286){
        v289 = US1_1(v274);
    } else {
        v289 = US1_0();
    }
    array<5l,Tuple3> v290;
    int32_t v291; int32_t v292;
    Tuple6 tmp42 = TupleCreate6(0l, 0l);
    v291 = tmp42.v0; v292 = tmp42.v1;
    while (method24(v291)){
        ap_uint<4l> v294; ap_uint<2l> v295;
        Tuple3 tmp43 = v1.v[v291];
        v294 = tmp43.v0; v295 = tmp43.v1;
        ap_uint<2l> v296;
        v296 = 0ul;
        bool v297;
        v297 = v295 == v296;
        bool v299;
        if (v297){
            bool v298;
            v298 = v292 < 5l;
            v299 = v298;
        } else {
            v299 = false;
        }
        int32_t v301;
        if (v299){
            v290.v[v292] = TupleCreate3(v294, v295);
            int32_t v300;
            v300 = v292 + 1l;
            v301 = v300;
        } else {
            v301 = v292;
        }
        v292 = v301;
        v291++;
    }
    bool v302;
    v302 = v292 == 5l;
    US1 v305;
    if (v302){
        v305 = US1_1(v290);
    } else {
        v305 = US1_0();
    }
    US1 v330;
    switch (v305.tag) {
        case 0: { // None
            v330 = v289;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v306 = v305.v.case1.v0;
            switch (v289.tag) {
                case 0: { // None
                    v330 = v305;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v307 = v289.v.case1.v0;
                    US4 v308;
                    v308 = US4_0();
                    int32_t v309; US4 v310;
                    Tuple7 tmp44 = TupleCreate7(0l, v308);
                    v309 = tmp44.v0; v310 = tmp44.v1;
                    while (method25(v309)){
                        ap_uint<4l> v312; ap_uint<2l> v313;
                        Tuple3 tmp45 = v306.v[v309];
                        v312 = tmp45.v0; v313 = tmp45.v1;
                        ap_uint<4l> v314; ap_uint<2l> v315;
                        Tuple3 tmp46 = v307.v[v309];
                        v314 = tmp46.v0; v315 = tmp46.v1;
                        US4 v323;
                        switch (v310.tag) {
                            case 0: { // Eq
                                bool v316;
                                v316 = v312 > v314;
                                if (v316){
                                    v323 = US4_1();
                                } else {
                                    bool v318;
                                    v318 = v312 < v314;
                                    if (v318){
                                        v323 = US4_2();
                                    } else {
                                        v323 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v323 = v310;
                            }
                        }
                        v310 = v323;
                        v309++;
                    }
                    bool v324;
                    switch (v310.tag) {
                        case 1: { // Gt
                            v324 = true;
                            break;
                        }
                        default: {
                            v324 = false;
                        }
                    }
                    array<5l,Tuple3> v325;
                    if (v324){
                        v325 = v306;
                    } else {
                        v325 = v307;
                    }
                    v330 = US1_1(v325);
                    break;
                }
            }
            break;
        }
    }
    US1 v355;
    switch (v330.tag) {
        case 0: { // None
            v355 = v273;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v331 = v330.v.case1.v0;
            switch (v273.tag) {
                case 0: { // None
                    v355 = v330;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v332 = v273.v.case1.v0;
                    US4 v333;
                    v333 = US4_0();
                    int32_t v334; US4 v335;
                    Tuple7 tmp47 = TupleCreate7(0l, v333);
                    v334 = tmp47.v0; v335 = tmp47.v1;
                    while (method25(v334)){
                        ap_uint<4l> v337; ap_uint<2l> v338;
                        Tuple3 tmp48 = v331.v[v334];
                        v337 = tmp48.v0; v338 = tmp48.v1;
                        ap_uint<4l> v339; ap_uint<2l> v340;
                        Tuple3 tmp49 = v332.v[v334];
                        v339 = tmp49.v0; v340 = tmp49.v1;
                        US4 v348;
                        switch (v335.tag) {
                            case 0: { // Eq
                                bool v341;
                                v341 = v337 > v339;
                                if (v341){
                                    v348 = US4_1();
                                } else {
                                    bool v343;
                                    v343 = v337 < v339;
                                    if (v343){
                                        v348 = US4_2();
                                    } else {
                                        v348 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v348 = v335;
                            }
                        }
                        v335 = v348;
                        v334++;
                    }
                    bool v349;
                    switch (v335.tag) {
                        case 1: { // Gt
                            v349 = true;
                            break;
                        }
                        default: {
                            v349 = false;
                        }
                    }
                    array<5l,Tuple3> v350;
                    if (v349){
                        v350 = v331;
                    } else {
                        v350 = v332;
                    }
                    v355 = US1_1(v350);
                    break;
                }
            }
            break;
        }
    }
    US1 v380;
    switch (v355.tag) {
        case 0: { // None
            v380 = v257;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v356 = v355.v.case1.v0;
            switch (v257.tag) {
                case 0: { // None
                    v380 = v355;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v357 = v257.v.case1.v0;
                    US4 v358;
                    v358 = US4_0();
                    int32_t v359; US4 v360;
                    Tuple7 tmp50 = TupleCreate7(0l, v358);
                    v359 = tmp50.v0; v360 = tmp50.v1;
                    while (method25(v359)){
                        ap_uint<4l> v362; ap_uint<2l> v363;
                        Tuple3 tmp51 = v356.v[v359];
                        v362 = tmp51.v0; v363 = tmp51.v1;
                        ap_uint<4l> v364; ap_uint<2l> v365;
                        Tuple3 tmp52 = v357.v[v359];
                        v364 = tmp52.v0; v365 = tmp52.v1;
                        US4 v373;
                        switch (v360.tag) {
                            case 0: { // Eq
                                bool v366;
                                v366 = v362 > v364;
                                if (v366){
                                    v373 = US4_1();
                                } else {
                                    bool v368;
                                    v368 = v362 < v364;
                                    if (v368){
                                        v373 = US4_2();
                                    } else {
                                        v373 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v373 = v360;
                            }
                        }
                        v360 = v373;
                        v359++;
                    }
                    bool v374;
                    switch (v360.tag) {
                        case 1: { // Gt
                            v374 = true;
                            break;
                        }
                        default: {
                            v374 = false;
                        }
                    }
                    array<5l,Tuple3> v375;
                    if (v374){
                        v375 = v356;
                    } else {
                        v375 = v357;
                    }
                    v380 = US1_1(v375);
                    break;
                }
            }
            break;
        }
    }
    array<3l,Tuple3> v381;
    array<10l,Tuple3> v382;
    ap_uint<4l> v383;
    v383 = 12ul;
    int32_t v384; int32_t v385; ap_uint<4l> v386;
    Tuple5 tmp53 = TupleCreate5(0l, 0l, v383);
    v384 = tmp53.v0; v385 = tmp53.v1; v386 = tmp53.v2;
    while (method24(v384)){
        ap_uint<4l> v388; ap_uint<2l> v389;
        Tuple3 tmp54 = v1.v[v384];
        v388 = tmp54.v0; v389 = tmp54.v1;
        bool v390;
        v390 = v385 < 3l;
        int32_t v394; ap_uint<4l> v395;
        if (v390){
            bool v391;
            v391 = v386 == v388;
            int32_t v392;
            if (v391){
                v392 = v385;
            } else {
                v392 = 0l;
            }
            v381.v[v392] = TupleCreate3(v388, v389);
            int32_t v393;
            v393 = v392 + 1l;
            v394 = v393; v395 = v388;
        } else {
            v394 = v385; v395 = v386;
        }
        v385 = v394;
        v386 = v395;
        v384++;
    }
    bool v396;
    v396 = v385 == 3l;
    US3 v409;
    if (v396){
        int32_t v397;
        v397 = v385 - 3l;
        int32_t v398;
        v398 = 0l;
        while (method26(v397, v398)){
            ap_uint<4l> v400; ap_uint<2l> v401;
            Tuple3 tmp55 = v1.v[v398];
            v400 = tmp55.v0; v401 = tmp55.v1;
            v382.v[v398] = TupleCreate3(v400, v401);
            v398++;
        }
        int32_t v402;
        v402 = v397;
        while (method32(v402)){
            int32_t v404;
            v404 = 3l + v402;
            ap_uint<4l> v405; ap_uint<2l> v406;
            Tuple3 tmp56 = v1.v[v404];
            v405 = tmp56.v0; v406 = tmp56.v1;
            v382.v[v402] = TupleCreate3(v405, v406);
            v402++;
        }
        v409 = US3_1(v381, v382);
    } else {
        v409 = US3_0();
    }
    US1 v460;
    switch (v409.tag) {
        case 0: { // None
            v460 = US1_0();
            break;
        }
        case 1: { // Some
            array<3l,Tuple3> v410 = v409.v.case1.v0; array<10l,Tuple3> v411 = v409.v.case1.v1;
            array<2l,Tuple3> v412;
            array<8l,Tuple3> v413;
            ap_uint<4l> v414;
            v414 = 12ul;
            int32_t v415; int32_t v416; ap_uint<4l> v417;
            Tuple5 tmp57 = TupleCreate5(0l, 0l, v414);
            v415 = tmp57.v0; v416 = tmp57.v1; v417 = tmp57.v2;
            while (method32(v415)){
                ap_uint<4l> v419; ap_uint<2l> v420;
                Tuple3 tmp58 = v411.v[v415];
                v419 = tmp58.v0; v420 = tmp58.v1;
                bool v421;
                v421 = v416 < 2l;
                int32_t v425; ap_uint<4l> v426;
                if (v421){
                    bool v422;
                    v422 = v417 == v419;
                    int32_t v423;
                    if (v422){
                        v423 = v416;
                    } else {
                        v423 = 0l;
                    }
                    v412.v[v423] = TupleCreate3(v419, v420);
                    int32_t v424;
                    v424 = v423 + 1l;
                    v425 = v424; v426 = v419;
                } else {
                    v425 = v416; v426 = v417;
                }
                v416 = v425;
                v417 = v426;
                v415++;
            }
            bool v427;
            v427 = v416 == 2l;
            US5 v440;
            if (v427){
                int32_t v428;
                v428 = v416 - 2l;
                int32_t v429;
                v429 = 0l;
                while (method26(v428, v429)){
                    ap_uint<4l> v431; ap_uint<2l> v432;
                    Tuple3 tmp59 = v411.v[v429];
                    v431 = tmp59.v0; v432 = tmp59.v1;
                    v413.v[v429] = TupleCreate3(v431, v432);
                    v429++;
                }
                int32_t v433;
                v433 = v428;
                while (method33(v433)){
                    int32_t v435;
                    v435 = 2l + v433;
                    ap_uint<4l> v436; ap_uint<2l> v437;
                    Tuple3 tmp60 = v411.v[v435];
                    v436 = tmp60.v0; v437 = tmp60.v1;
                    v413.v[v433] = TupleCreate3(v436, v437);
                    v433++;
                }
                v440 = US5_1(v412, v413);
            } else {
                v440 = US5_0();
            }
            switch (v440.tag) {
                case 0: { // None
                    v460 = US1_0();
                    break;
                }
                case 1: { // Some
                    array<2l,Tuple3> v441 = v440.v.case1.v0; array<8l,Tuple3> v442 = v440.v.case1.v1;
                    array<0l,Tuple3> v443;
                    array<5l,Tuple3> v444;
                    int32_t v445;
                    v445 = 0l;
                    while (method28(v445)){
                        ap_uint<4l> v447; ap_uint<2l> v448;
                        Tuple3 tmp61 = v410.v[v445];
                        v447 = tmp61.v0; v448 = tmp61.v1;
                        v444.v[v445] = TupleCreate3(v447, v448);
                        v445++;
                    }
                    int32_t v449;
                    v449 = 0l;
                    while (method29(v449)){
                        ap_uint<4l> v451; ap_uint<2l> v452;
                        Tuple3 tmp62 = v441.v[v449];
                        v451 = tmp62.v0; v452 = tmp62.v1;
                        int32_t v453;
                        v453 = 3l + v449;
                        v444.v[v453] = TupleCreate3(v451, v452);
                        v449++;
                    }
                    v460 = US1_1(v444);
                    break;
                }
            }
            break;
        }
    }
    array<4l,Tuple3> v461;
    array<9l,Tuple3> v462;
    ap_uint<4l> v463;
    v463 = 12ul;
    int32_t v464; int32_t v465; ap_uint<4l> v466;
    Tuple5 tmp63 = TupleCreate5(0l, 0l, v463);
    v464 = tmp63.v0; v465 = tmp63.v1; v466 = tmp63.v2;
    while (method24(v464)){
        ap_uint<4l> v468; ap_uint<2l> v469;
        Tuple3 tmp64 = v1.v[v464];
        v468 = tmp64.v0; v469 = tmp64.v1;
        bool v470;
        v470 = v465 < 4l;
        int32_t v474; ap_uint<4l> v475;
        if (v470){
            bool v471;
            v471 = v466 == v468;
            int32_t v472;
            if (v471){
                v472 = v465;
            } else {
                v472 = 0l;
            }
            v461.v[v472] = TupleCreate3(v468, v469);
            int32_t v473;
            v473 = v472 + 1l;
            v474 = v473; v475 = v468;
        } else {
            v474 = v465; v475 = v466;
        }
        v465 = v474;
        v466 = v475;
        v464++;
    }
    bool v476;
    v476 = v465 == 4l;
    US6 v489;
    if (v476){
        int32_t v477;
        v477 = v465 - 4l;
        int32_t v478;
        v478 = 0l;
        while (method26(v477, v478)){
            ap_uint<4l> v480; ap_uint<2l> v481;
            Tuple3 tmp65 = v1.v[v478];
            v480 = tmp65.v0; v481 = tmp65.v1;
            v462.v[v478] = TupleCreate3(v480, v481);
            v478++;
        }
        int32_t v482;
        v482 = v477;
        while (method30(v482)){
            int32_t v484;
            v484 = 4l + v482;
            ap_uint<4l> v485; ap_uint<2l> v486;
            Tuple3 tmp66 = v1.v[v484];
            v485 = tmp66.v0; v486 = tmp66.v1;
            v462.v[v482] = TupleCreate3(v485, v486);
            v482++;
        }
        v489 = US6_1(v461, v462);
    } else {
        v489 = US6_0();
    }
    US1 v511;
    switch (v489.tag) {
        case 0: { // None
            v511 = US1_0();
            break;
        }
        case 1: { // Some
            array<4l,Tuple3> v490 = v489.v.case1.v0; array<9l,Tuple3> v491 = v489.v.case1.v1;
            array<1l,Tuple3> v492;
            int32_t v493;
            v493 = 0l;
            while (method31(v493)){
                ap_uint<4l> v495; ap_uint<2l> v496;
                Tuple3 tmp67 = v491.v[v493];
                v495 = tmp67.v0; v496 = tmp67.v1;
                v492.v[v493] = TupleCreate3(v495, v496);
                v493++;
            }
            array<0l,Tuple3> v497;
            array<5l,Tuple3> v498;
            int32_t v499;
            v499 = 0l;
            while (method34(v499)){
                ap_uint<4l> v501; ap_uint<2l> v502;
                Tuple3 tmp68 = v490.v[v499];
                v501 = tmp68.v0; v502 = tmp68.v1;
                v498.v[v499] = TupleCreate3(v501, v502);
                v499++;
            }
            int32_t v503;
            v503 = 0l;
            while (method31(v503)){
                ap_uint<4l> v505; ap_uint<2l> v506;
                Tuple3 tmp69 = v492.v[v503];
                v505 = tmp69.v0; v506 = tmp69.v1;
                int32_t v507;
                v507 = 4l + v503;
                v498.v[v507] = TupleCreate3(v505, v506);
                v503++;
            }
            v511 = US1_1(v498);
            break;
        }
    }
    ap_uint<2l> v512;
    v512 = 3ul;
    array<5l,Tuple3> v513;
    ap_uint<4l> v514;
    v514 = 12ul;
    int32_t v515; int32_t v516; ap_uint<4l> v517;
    Tuple5 tmp70 = TupleCreate5(0l, 0l, v514);
    v515 = tmp70.v0; v516 = tmp70.v1; v517 = tmp70.v2;
    while (method24(v515)){
        ap_uint<4l> v519; ap_uint<2l> v520;
        Tuple3 tmp71 = v1.v[v515];
        v519 = tmp71.v0; v520 = tmp71.v1;
        bool v521;
        v521 = v516 < 5l;
        bool v523;
        if (v521){
            bool v522;
            v522 = v512 == v520;
            v523 = v522;
        } else {
            v523 = false;
        }
        int32_t v529; ap_uint<4l> v530;
        if (v523){
            bool v524;
            v524 = v517 == v519;
            int32_t v525;
            if (v524){
                v525 = v516;
            } else {
                v525 = 0l;
            }
            v513.v[v525] = TupleCreate3(v519, v520);
            int32_t v526;
            v526 = v525 + 1l;
            ap_uint<4l> v527;
            v527 = 1ul;
            ap_uint<4l> v528;
            v528 = v519 - v527;
            v529 = v526; v530 = v528;
        } else {
            v529 = v516; v530 = v517;
        }
        v516 = v529;
        v517 = v530;
        v515++;
    }
    bool v531;
    v531 = v516 == 4l;
    bool v568;
    if (v531){
        ap_uint<4l> v532;
        v532 = 0ul;
        ap_uint<4l> v533;
        v533 = 1ul;
        ap_uint<4l> v534;
        v534 = v532 - v533;
        bool v535;
        v535 = v517 == v534;
        if (v535){
            ap_uint<4l> v536; ap_uint<2l> v537;
            Tuple3 tmp72 = v1.v[0l];
            v536 = tmp72.v0; v537 = tmp72.v1;
            bool v538;
            v538 = v512 == v537;
            bool v542;
            if (v538){
                ap_uint<4l> v539;
                v539 = 12ul;
                bool v540;
                v540 = v536 == v539;
                if (v540){
                    v513.v[4l] = TupleCreate3(v536, v537);
                    v542 = true;
                } else {
                    v542 = false;
                }
            } else {
                v542 = false;
            }
            if (v542){
                v568 = true;
            } else {
                ap_uint<4l> v543; ap_uint<2l> v544;
                Tuple3 tmp73 = v1.v[1l];
                v543 = tmp73.v0; v544 = tmp73.v1;
                bool v545;
                v545 = v512 == v544;
                bool v549;
                if (v545){
                    ap_uint<4l> v546;
                    v546 = 12ul;
                    bool v547;
                    v547 = v543 == v546;
                    if (v547){
                        v513.v[4l] = TupleCreate3(v543, v544);
                        v549 = true;
                    } else {
                        v549 = false;
                    }
                } else {
                    v549 = false;
                }
                if (v549){
                    v568 = true;
                } else {
                    ap_uint<4l> v550; ap_uint<2l> v551;
                    Tuple3 tmp74 = v1.v[2l];
                    v550 = tmp74.v0; v551 = tmp74.v1;
                    bool v552;
                    v552 = v512 == v551;
                    bool v556;
                    if (v552){
                        ap_uint<4l> v553;
                        v553 = 12ul;
                        bool v554;
                        v554 = v550 == v553;
                        if (v554){
                            v513.v[4l] = TupleCreate3(v550, v551);
                            v556 = true;
                        } else {
                            v556 = false;
                        }
                    } else {
                        v556 = false;
                    }
                    if (v556){
                        v568 = true;
                    } else {
                        ap_uint<4l> v557; ap_uint<2l> v558;
                        Tuple3 tmp75 = v1.v[3l];
                        v557 = tmp75.v0; v558 = tmp75.v1;
                        bool v559;
                        v559 = v512 == v558;
                        if (v559){
                            ap_uint<4l> v560;
                            v560 = 12ul;
                            bool v561;
                            v561 = v557 == v560;
                            if (v561){
                                v513.v[4l] = TupleCreate3(v557, v558);
                                v568 = true;
                            } else {
                                v568 = false;
                            }
                        } else {
                            v568 = false;
                        }
                    }
                }
            }
        } else {
            v568 = false;
        }
    } else {
        v568 = false;
    }
    US1 v574;
    if (v568){
        v574 = US1_1(v513);
    } else {
        bool v570;
        v570 = v516 == 5l;
        if (v570){
            v574 = US1_1(v513);
        } else {
            v574 = US1_0();
        }
    }
    ap_uint<2l> v575;
    v575 = 2ul;
    array<5l,Tuple3> v576;
    ap_uint<4l> v577;
    v577 = 12ul;
    int32_t v578; int32_t v579; ap_uint<4l> v580;
    Tuple5 tmp76 = TupleCreate5(0l, 0l, v577);
    v578 = tmp76.v0; v579 = tmp76.v1; v580 = tmp76.v2;
    while (method24(v578)){
        ap_uint<4l> v582; ap_uint<2l> v583;
        Tuple3 tmp77 = v1.v[v578];
        v582 = tmp77.v0; v583 = tmp77.v1;
        bool v584;
        v584 = v579 < 5l;
        bool v586;
        if (v584){
            bool v585;
            v585 = v575 == v583;
            v586 = v585;
        } else {
            v586 = false;
        }
        int32_t v592; ap_uint<4l> v593;
        if (v586){
            bool v587;
            v587 = v580 == v582;
            int32_t v588;
            if (v587){
                v588 = v579;
            } else {
                v588 = 0l;
            }
            v576.v[v588] = TupleCreate3(v582, v583);
            int32_t v589;
            v589 = v588 + 1l;
            ap_uint<4l> v590;
            v590 = 1ul;
            ap_uint<4l> v591;
            v591 = v582 - v590;
            v592 = v589; v593 = v591;
        } else {
            v592 = v579; v593 = v580;
        }
        v579 = v592;
        v580 = v593;
        v578++;
    }
    bool v594;
    v594 = v579 == 4l;
    bool v631;
    if (v594){
        ap_uint<4l> v595;
        v595 = 0ul;
        ap_uint<4l> v596;
        v596 = 1ul;
        ap_uint<4l> v597;
        v597 = v595 - v596;
        bool v598;
        v598 = v580 == v597;
        if (v598){
            ap_uint<4l> v599; ap_uint<2l> v600;
            Tuple3 tmp78 = v1.v[0l];
            v599 = tmp78.v0; v600 = tmp78.v1;
            bool v601;
            v601 = v575 == v600;
            bool v605;
            if (v601){
                ap_uint<4l> v602;
                v602 = 12ul;
                bool v603;
                v603 = v599 == v602;
                if (v603){
                    v576.v[4l] = TupleCreate3(v599, v600);
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
                ap_uint<4l> v606; ap_uint<2l> v607;
                Tuple3 tmp79 = v1.v[1l];
                v606 = tmp79.v0; v607 = tmp79.v1;
                bool v608;
                v608 = v575 == v607;
                bool v612;
                if (v608){
                    ap_uint<4l> v609;
                    v609 = 12ul;
                    bool v610;
                    v610 = v606 == v609;
                    if (v610){
                        v576.v[4l] = TupleCreate3(v606, v607);
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
                    ap_uint<4l> v613; ap_uint<2l> v614;
                    Tuple3 tmp80 = v1.v[2l];
                    v613 = tmp80.v0; v614 = tmp80.v1;
                    bool v615;
                    v615 = v575 == v614;
                    bool v619;
                    if (v615){
                        ap_uint<4l> v616;
                        v616 = 12ul;
                        bool v617;
                        v617 = v613 == v616;
                        if (v617){
                            v576.v[4l] = TupleCreate3(v613, v614);
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
                        ap_uint<4l> v620; ap_uint<2l> v621;
                        Tuple3 tmp81 = v1.v[3l];
                        v620 = tmp81.v0; v621 = tmp81.v1;
                        bool v622;
                        v622 = v575 == v621;
                        if (v622){
                            ap_uint<4l> v623;
                            v623 = 12ul;
                            bool v624;
                            v624 = v620 == v623;
                            if (v624){
                                v576.v[4l] = TupleCreate3(v620, v621);
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
        v637 = US1_1(v576);
    } else {
        bool v633;
        v633 = v579 == 5l;
        if (v633){
            v637 = US1_1(v576);
        } else {
            v637 = US1_0();
        }
    }
    ap_uint<2l> v638;
    v638 = 1ul;
    array<5l,Tuple3> v639;
    ap_uint<4l> v640;
    v640 = 12ul;
    int32_t v641; int32_t v642; ap_uint<4l> v643;
    Tuple5 tmp82 = TupleCreate5(0l, 0l, v640);
    v641 = tmp82.v0; v642 = tmp82.v1; v643 = tmp82.v2;
    while (method24(v641)){
        ap_uint<4l> v645; ap_uint<2l> v646;
        Tuple3 tmp83 = v1.v[v641];
        v645 = tmp83.v0; v646 = tmp83.v1;
        bool v647;
        v647 = v642 < 5l;
        bool v649;
        if (v647){
            bool v648;
            v648 = v638 == v646;
            v649 = v648;
        } else {
            v649 = false;
        }
        int32_t v655; ap_uint<4l> v656;
        if (v649){
            bool v650;
            v650 = v643 == v645;
            int32_t v651;
            if (v650){
                v651 = v642;
            } else {
                v651 = 0l;
            }
            v639.v[v651] = TupleCreate3(v645, v646);
            int32_t v652;
            v652 = v651 + 1l;
            ap_uint<4l> v653;
            v653 = 1ul;
            ap_uint<4l> v654;
            v654 = v645 - v653;
            v655 = v652; v656 = v654;
        } else {
            v655 = v642; v656 = v643;
        }
        v642 = v655;
        v643 = v656;
        v641++;
    }
    bool v657;
    v657 = v642 == 4l;
    bool v694;
    if (v657){
        ap_uint<4l> v658;
        v658 = 0ul;
        ap_uint<4l> v659;
        v659 = 1ul;
        ap_uint<4l> v660;
        v660 = v658 - v659;
        bool v661;
        v661 = v643 == v660;
        if (v661){
            ap_uint<4l> v662; ap_uint<2l> v663;
            Tuple3 tmp84 = v1.v[0l];
            v662 = tmp84.v0; v663 = tmp84.v1;
            bool v664;
            v664 = v638 == v663;
            bool v668;
            if (v664){
                ap_uint<4l> v665;
                v665 = 12ul;
                bool v666;
                v666 = v662 == v665;
                if (v666){
                    v639.v[4l] = TupleCreate3(v662, v663);
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
                ap_uint<4l> v669; ap_uint<2l> v670;
                Tuple3 tmp85 = v1.v[1l];
                v669 = tmp85.v0; v670 = tmp85.v1;
                bool v671;
                v671 = v638 == v670;
                bool v675;
                if (v671){
                    ap_uint<4l> v672;
                    v672 = 12ul;
                    bool v673;
                    v673 = v669 == v672;
                    if (v673){
                        v639.v[4l] = TupleCreate3(v669, v670);
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
                    ap_uint<4l> v676; ap_uint<2l> v677;
                    Tuple3 tmp86 = v1.v[2l];
                    v676 = tmp86.v0; v677 = tmp86.v1;
                    bool v678;
                    v678 = v638 == v677;
                    bool v682;
                    if (v678){
                        ap_uint<4l> v679;
                        v679 = 12ul;
                        bool v680;
                        v680 = v676 == v679;
                        if (v680){
                            v639.v[4l] = TupleCreate3(v676, v677);
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
                        ap_uint<4l> v683; ap_uint<2l> v684;
                        Tuple3 tmp87 = v1.v[3l];
                        v683 = tmp87.v0; v684 = tmp87.v1;
                        bool v685;
                        v685 = v638 == v684;
                        if (v685){
                            ap_uint<4l> v686;
                            v686 = 12ul;
                            bool v687;
                            v687 = v683 == v686;
                            if (v687){
                                v639.v[4l] = TupleCreate3(v683, v684);
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
        v700 = US1_1(v639);
    } else {
        bool v696;
        v696 = v642 == 5l;
        if (v696){
            v700 = US1_1(v639);
        } else {
            v700 = US1_0();
        }
    }
    ap_uint<2l> v701;
    v701 = 0ul;
    array<5l,Tuple3> v702;
    ap_uint<4l> v703;
    v703 = 12ul;
    int32_t v704; int32_t v705; ap_uint<4l> v706;
    Tuple5 tmp88 = TupleCreate5(0l, 0l, v703);
    v704 = tmp88.v0; v705 = tmp88.v1; v706 = tmp88.v2;
    while (method24(v704)){
        ap_uint<4l> v708; ap_uint<2l> v709;
        Tuple3 tmp89 = v1.v[v704];
        v708 = tmp89.v0; v709 = tmp89.v1;
        bool v710;
        v710 = v705 < 5l;
        bool v712;
        if (v710){
            bool v711;
            v711 = v701 == v709;
            v712 = v711;
        } else {
            v712 = false;
        }
        int32_t v718; ap_uint<4l> v719;
        if (v712){
            bool v713;
            v713 = v706 == v708;
            int32_t v714;
            if (v713){
                v714 = v705;
            } else {
                v714 = 0l;
            }
            v702.v[v714] = TupleCreate3(v708, v709);
            int32_t v715;
            v715 = v714 + 1l;
            ap_uint<4l> v716;
            v716 = 1ul;
            ap_uint<4l> v717;
            v717 = v708 - v716;
            v718 = v715; v719 = v717;
        } else {
            v718 = v705; v719 = v706;
        }
        v705 = v718;
        v706 = v719;
        v704++;
    }
    bool v720;
    v720 = v705 == 4l;
    bool v757;
    if (v720){
        ap_uint<4l> v721;
        v721 = 0ul;
        ap_uint<4l> v722;
        v722 = 1ul;
        ap_uint<4l> v723;
        v723 = v721 - v722;
        bool v724;
        v724 = v706 == v723;
        if (v724){
            ap_uint<4l> v725; ap_uint<2l> v726;
            Tuple3 tmp90 = v1.v[0l];
            v725 = tmp90.v0; v726 = tmp90.v1;
            bool v727;
            v727 = v701 == v726;
            bool v731;
            if (v727){
                ap_uint<4l> v728;
                v728 = 12ul;
                bool v729;
                v729 = v725 == v728;
                if (v729){
                    v702.v[4l] = TupleCreate3(v725, v726);
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
                ap_uint<4l> v732; ap_uint<2l> v733;
                Tuple3 tmp91 = v1.v[1l];
                v732 = tmp91.v0; v733 = tmp91.v1;
                bool v734;
                v734 = v701 == v733;
                bool v738;
                if (v734){
                    ap_uint<4l> v735;
                    v735 = 12ul;
                    bool v736;
                    v736 = v732 == v735;
                    if (v736){
                        v702.v[4l] = TupleCreate3(v732, v733);
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
                    ap_uint<4l> v739; ap_uint<2l> v740;
                    Tuple3 tmp92 = v1.v[2l];
                    v739 = tmp92.v0; v740 = tmp92.v1;
                    bool v741;
                    v741 = v701 == v740;
                    bool v745;
                    if (v741){
                        ap_uint<4l> v742;
                        v742 = 12ul;
                        bool v743;
                        v743 = v739 == v742;
                        if (v743){
                            v702.v[4l] = TupleCreate3(v739, v740);
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
                        ap_uint<4l> v746; ap_uint<2l> v747;
                        Tuple3 tmp93 = v1.v[3l];
                        v746 = tmp93.v0; v747 = tmp93.v1;
                        bool v748;
                        v748 = v701 == v747;
                        if (v748){
                            ap_uint<4l> v749;
                            v749 = 12ul;
                            bool v750;
                            v750 = v746 == v749;
                            if (v750){
                                v702.v[4l] = TupleCreate3(v746, v747);
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
        v763 = US1_1(v702);
    } else {
        bool v759;
        v759 = v705 == 5l;
        if (v759){
            v763 = US1_1(v702);
        } else {
            v763 = US1_0();
        }
    }
    US1 v788;
    switch (v763.tag) {
        case 0: { // None
            v788 = v700;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v764 = v763.v.case1.v0;
            switch (v700.tag) {
                case 0: { // None
                    v788 = v763;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v765 = v700.v.case1.v0;
                    US4 v766;
                    v766 = US4_0();
                    int32_t v767; US4 v768;
                    Tuple7 tmp94 = TupleCreate7(0l, v766);
                    v767 = tmp94.v0; v768 = tmp94.v1;
                    while (method25(v767)){
                        ap_uint<4l> v770; ap_uint<2l> v771;
                        Tuple3 tmp95 = v764.v[v767];
                        v770 = tmp95.v0; v771 = tmp95.v1;
                        ap_uint<4l> v772; ap_uint<2l> v773;
                        Tuple3 tmp96 = v765.v[v767];
                        v772 = tmp96.v0; v773 = tmp96.v1;
                        US4 v781;
                        switch (v768.tag) {
                            case 0: { // Eq
                                bool v774;
                                v774 = v770 > v772;
                                if (v774){
                                    v781 = US4_1();
                                } else {
                                    bool v776;
                                    v776 = v770 < v772;
                                    if (v776){
                                        v781 = US4_2();
                                    } else {
                                        v781 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v781 = v768;
                            }
                        }
                        v768 = v781;
                        v767++;
                    }
                    bool v782;
                    switch (v768.tag) {
                        case 1: { // Gt
                            v782 = true;
                            break;
                        }
                        default: {
                            v782 = false;
                        }
                    }
                    array<5l,Tuple3> v783;
                    if (v782){
                        v783 = v764;
                    } else {
                        v783 = v765;
                    }
                    v788 = US1_1(v783);
                    break;
                }
            }
            break;
        }
    }
    US1 v813;
    switch (v788.tag) {
        case 0: { // None
            v813 = v637;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v789 = v788.v.case1.v0;
            switch (v637.tag) {
                case 0: { // None
                    v813 = v788;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v790 = v637.v.case1.v0;
                    US4 v791;
                    v791 = US4_0();
                    int32_t v792; US4 v793;
                    Tuple7 tmp97 = TupleCreate7(0l, v791);
                    v792 = tmp97.v0; v793 = tmp97.v1;
                    while (method25(v792)){
                        ap_uint<4l> v795; ap_uint<2l> v796;
                        Tuple3 tmp98 = v789.v[v792];
                        v795 = tmp98.v0; v796 = tmp98.v1;
                        ap_uint<4l> v797; ap_uint<2l> v798;
                        Tuple3 tmp99 = v790.v[v792];
                        v797 = tmp99.v0; v798 = tmp99.v1;
                        US4 v806;
                        switch (v793.tag) {
                            case 0: { // Eq
                                bool v799;
                                v799 = v795 > v797;
                                if (v799){
                                    v806 = US4_1();
                                } else {
                                    bool v801;
                                    v801 = v795 < v797;
                                    if (v801){
                                        v806 = US4_2();
                                    } else {
                                        v806 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v806 = v793;
                            }
                        }
                        v793 = v806;
                        v792++;
                    }
                    bool v807;
                    switch (v793.tag) {
                        case 1: { // Gt
                            v807 = true;
                            break;
                        }
                        default: {
                            v807 = false;
                        }
                    }
                    array<5l,Tuple3> v808;
                    if (v807){
                        v808 = v789;
                    } else {
                        v808 = v790;
                    }
                    v813 = US1_1(v808);
                    break;
                }
            }
            break;
        }
    }
    US1 v838;
    switch (v813.tag) {
        case 0: { // None
            v838 = v574;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v814 = v813.v.case1.v0;
            switch (v574.tag) {
                case 0: { // None
                    v838 = v813;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v815 = v574.v.case1.v0;
                    US4 v816;
                    v816 = US4_0();
                    int32_t v817; US4 v818;
                    Tuple7 tmp100 = TupleCreate7(0l, v816);
                    v817 = tmp100.v0; v818 = tmp100.v1;
                    while (method25(v817)){
                        ap_uint<4l> v820; ap_uint<2l> v821;
                        Tuple3 tmp101 = v814.v[v817];
                        v820 = tmp101.v0; v821 = tmp101.v1;
                        ap_uint<4l> v822; ap_uint<2l> v823;
                        Tuple3 tmp102 = v815.v[v817];
                        v822 = tmp102.v0; v823 = tmp102.v1;
                        US4 v831;
                        switch (v818.tag) {
                            case 0: { // Eq
                                bool v824;
                                v824 = v820 > v822;
                                if (v824){
                                    v831 = US4_1();
                                } else {
                                    bool v826;
                                    v826 = v820 < v822;
                                    if (v826){
                                        v831 = US4_2();
                                    } else {
                                        v831 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v831 = v818;
                            }
                        }
                        v818 = v831;
                        v817++;
                    }
                    bool v832;
                    switch (v818.tag) {
                        case 1: { // Gt
                            v832 = true;
                            break;
                        }
                        default: {
                            v832 = false;
                        }
                    }
                    array<5l,Tuple3> v833;
                    if (v832){
                        v833 = v814;
                    } else {
                        v833 = v815;
                    }
                    v838 = US1_1(v833);
                    break;
                }
            }
            break;
        }
    }
    switch (v838.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v839 = v838.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    switch (v511.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v840 = v511.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    switch (v460.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v841 = v460.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    switch (v380.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v842 = v380.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    switch (v241.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v843 = v241.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    switch (v202.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v844 = v202.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    switch (v151.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v845 = v151.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    switch (v62.tag) {
        case 0: { // None
            std::cout << "false" << std::endl;
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v846 = v62.v.case1.v0;
            std::cout << "true" << std::endl;
            break;
        }
    }
    ap_uint<4l> v847;
    v847 = 1ul;
    US7 v852;
    switch (v62.tag) {
        case 0: { // None
            v852 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v848 = v62.v.case1.v0;
            v852 = US7_1(v848, v847);
            break;
        }
    }
    ap_uint<4l> v853;
    v853 = 2ul;
    US7 v858;
    switch (v151.tag) {
        case 0: { // None
            v858 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v854 = v151.v.case1.v0;
            v858 = US7_1(v854, v853);
            break;
        }
    }
    ap_uint<4l> v859;
    v859 = 3ul;
    US7 v864;
    switch (v202.tag) {
        case 0: { // None
            v864 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v860 = v202.v.case1.v0;
            v864 = US7_1(v860, v859);
            break;
        }
    }
    ap_uint<4l> v865;
    v865 = 4ul;
    US7 v870;
    switch (v241.tag) {
        case 0: { // None
            v870 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v866 = v241.v.case1.v0;
            v870 = US7_1(v866, v865);
            break;
        }
    }
    ap_uint<4l> v871;
    v871 = 5ul;
    US7 v876;
    switch (v380.tag) {
        case 0: { // None
            v876 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v872 = v380.v.case1.v0;
            v876 = US7_1(v872, v871);
            break;
        }
    }
    ap_uint<4l> v877;
    v877 = 6ul;
    US7 v882;
    switch (v460.tag) {
        case 0: { // None
            v882 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v878 = v460.v.case1.v0;
            v882 = US7_1(v878, v877);
            break;
        }
    }
    ap_uint<4l> v883;
    v883 = 7ul;
    US7 v888;
    switch (v511.tag) {
        case 0: { // None
            v888 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v884 = v511.v.case1.v0;
            v888 = US7_1(v884, v883);
            break;
        }
    }
    ap_uint<4l> v889;
    v889 = 8ul;
    US7 v894;
    switch (v838.tag) {
        case 0: { // None
            v894 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v890 = v838.v.case1.v0;
            v894 = US7_1(v890, v889);
            break;
        }
    }
    US7 v896;
    switch (v894.tag) {
        case 0: { // None
            v896 = US7_0();
            break;
        }
        default: {
            v896 = v894;
        }
    }
    US7 v906;
    switch (v896.tag) {
        case 1: { // Some
            array<5l,Tuple3> v897 = v896.v.case1.v0; ap_uint<4l> v898 = v896.v.case1.v1;
            switch (v888.tag) {
                case 0: { // None
                    v906 = v896;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v899 = v888.v.case1.v0; ap_uint<4l> v900 = v888.v.case1.v1;
                    v906 = US7_1(v897, v898);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v888.tag) {
                case 0: { // None
                    v906 = v896;
                    break;
                }
                default: {
                    switch (v896.tag) {
                        case 0: { // None
                            v906 = v888;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v916;
    switch (v906.tag) {
        case 1: { // Some
            array<5l,Tuple3> v907 = v906.v.case1.v0; ap_uint<4l> v908 = v906.v.case1.v1;
            switch (v882.tag) {
                case 0: { // None
                    v916 = v906;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v909 = v882.v.case1.v0; ap_uint<4l> v910 = v882.v.case1.v1;
                    v916 = US7_1(v907, v908);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v882.tag) {
                case 0: { // None
                    v916 = v906;
                    break;
                }
                default: {
                    switch (v906.tag) {
                        case 0: { // None
                            v916 = v882;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v926;
    switch (v916.tag) {
        case 1: { // Some
            array<5l,Tuple3> v917 = v916.v.case1.v0; ap_uint<4l> v918 = v916.v.case1.v1;
            switch (v876.tag) {
                case 0: { // None
                    v926 = v916;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v919 = v876.v.case1.v0; ap_uint<4l> v920 = v876.v.case1.v1;
                    v926 = US7_1(v917, v918);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v876.tag) {
                case 0: { // None
                    v926 = v916;
                    break;
                }
                default: {
                    switch (v916.tag) {
                        case 0: { // None
                            v926 = v876;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v936;
    switch (v926.tag) {
        case 1: { // Some
            array<5l,Tuple3> v927 = v926.v.case1.v0; ap_uint<4l> v928 = v926.v.case1.v1;
            switch (v870.tag) {
                case 0: { // None
                    v936 = v926;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v929 = v870.v.case1.v0; ap_uint<4l> v930 = v870.v.case1.v1;
                    v936 = US7_1(v927, v928);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v870.tag) {
                case 0: { // None
                    v936 = v926;
                    break;
                }
                default: {
                    switch (v926.tag) {
                        case 0: { // None
                            v936 = v870;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v946;
    switch (v936.tag) {
        case 1: { // Some
            array<5l,Tuple3> v937 = v936.v.case1.v0; ap_uint<4l> v938 = v936.v.case1.v1;
            switch (v864.tag) {
                case 0: { // None
                    v946 = v936;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v939 = v864.v.case1.v0; ap_uint<4l> v940 = v864.v.case1.v1;
                    v946 = US7_1(v937, v938);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v864.tag) {
                case 0: { // None
                    v946 = v936;
                    break;
                }
                default: {
                    switch (v936.tag) {
                        case 0: { // None
                            v946 = v864;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v956;
    switch (v946.tag) {
        case 1: { // Some
            array<5l,Tuple3> v947 = v946.v.case1.v0; ap_uint<4l> v948 = v946.v.case1.v1;
            switch (v858.tag) {
                case 0: { // None
                    v956 = v946;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v949 = v858.v.case1.v0; ap_uint<4l> v950 = v858.v.case1.v1;
                    v956 = US7_1(v947, v948);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v858.tag) {
                case 0: { // None
                    v956 = v946;
                    break;
                }
                default: {
                    switch (v946.tag) {
                        case 0: { // None
                            v956 = v858;
                            break;
                        }
                    }
                }
            }
        }
    }
    US7 v966;
    switch (v956.tag) {
        case 1: { // Some
            array<5l,Tuple3> v957 = v956.v.case1.v0; ap_uint<4l> v958 = v956.v.case1.v1;
            switch (v852.tag) {
                case 0: { // None
                    v966 = v956;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple3> v959 = v852.v.case1.v0; ap_uint<4l> v960 = v852.v.case1.v1;
                    v966 = US7_1(v957, v958);
                    break;
                }
            }
            break;
        }
        default: {
            switch (v852.tag) {
                case 0: { // None
                    v966 = v956;
                    break;
                }
                default: {
                    switch (v956.tag) {
                        case 0: { // None
                            v966 = v852;
                            break;
                        }
                    }
                }
            }
        }
    }
    switch (v966.tag) {
        case 0: { // None
            ap_uint<4l> v969;
            v969 = 0ul;
            return TupleCreate4(v7, v969);
            break;
        }
        case 1: { // Some
            array<5l,Tuple3> v967 = v966.v.case1.v0; ap_uint<4l> v968 = v966.v.case1.v1;
            return TupleCreate4(v967, v968);
            break;
        }
    }
}
int32_t entry(){
    int32_t v0;
    v0 = (int32_t)33;
    uint64_t v1;
    v1 = 1ull << v0;
    int32_t v2;
    v2 = (int32_t)32;
    uint64_t v3;
    v3 = 1ull << v2;
    int32_t v4;
    v4 = (int32_t)31;
    uint64_t v5;
    v5 = 1ull << v4;
    int32_t v6;
    v6 = (int32_t)30;
    uint64_t v7;
    v7 = 1ull << v6;
    int32_t v8;
    v8 = (int32_t)29;
    uint64_t v9;
    v9 = 1ull << v8;
    int32_t v10;
    v10 = (int32_t)20;
    uint64_t v11;
    v11 = 1ull << v10;
    int32_t v12;
    v12 = (int32_t)19;
    uint64_t v13;
    v13 = 1ull << v12;
    int32_t v14;
    v14 = (int32_t)18;
    uint64_t v15;
    v15 = 1ull << v14;
    int32_t v16;
    v16 = (int32_t)17;
    uint64_t v17;
    v17 = 1ull << v16;
    int32_t v18;
    v18 = (int32_t)16;
    uint64_t v19;
    v19 = 1ull << v18;
    int32_t v20;
    v20 = (int32_t)15;
    uint64_t v21;
    v21 = 1ull << v20;
    int32_t v22;
    v22 = (int32_t)1;
    uint64_t v23;
    v23 = 1ull << v22;
    int32_t v24;
    v24 = (int32_t)0;
    uint64_t v25;
    v25 = 1ull << v24;
    uint64_t v26;
    v26 = 0ull | v25;
    uint64_t v27;
    v27 = v26 | v23;
    uint64_t v28;
    v28 = v27 | v21;
    uint64_t v29;
    v29 = v28 | v19;
    uint64_t v30;
    v30 = v29 | v17;
    uint64_t v31;
    v31 = v30 | v15;
    uint64_t v32;
    v32 = v31 | v13;
    uint64_t v33;
    v33 = v32 | v11;
    uint64_t v34;
    v34 = v33 | v9;
    uint64_t v35;
    v35 = v34 | v7;
    uint64_t v36;
    v36 = v35 | v5;
    uint64_t v37;
    v37 = v36 | v3;
    uint64_t v38;
    v38 = v37 | v1;
    int8_t v39; int8_t v40; int8_t v41; int8_t v42; int8_t v43; int8_t v44;
    Tuple0 tmp4 = score_0(v38);
    v39 = tmp4.v0; v40 = tmp4.v1; v41 = tmp4.v2; v42 = tmp4.v3; v43 = tmp4.v4; v44 = tmp4.v5;
    int8_t v45;
    v45 = v39 / 13;
    int8_t v46;
    v46 = v39 % 13;
    int8_t v47;
    v47 = v40 / 13;
    int8_t v48;
    v48 = v40 % 13;
    int8_t v49;
    v49 = v41 / 13;
    int8_t v50;
    v50 = v41 % 13;
    int8_t v51;
    v51 = v42 / 13;
    int8_t v52;
    v52 = v42 % 13;
    int8_t v53;
    v53 = v43 / 13;
    int8_t v54;
    v54 = v43 % 13;
    array<13l,Tuple3> v55;
    uint32_t v56;
    v56 = (uint32_t)0;
    ap_uint<4l> v57;
    v57 = v56;
    uint32_t v58;
    v58 = (uint32_t)0;
    ap_uint<2l> v59;
    v59 = v58;
    v55.v[0l] = TupleCreate3(v57, v59);
    uint32_t v60;
    v60 = (uint32_t)1;
    ap_uint<4l> v61;
    v61 = v60;
    uint32_t v62;
    v62 = (uint32_t)0;
    ap_uint<2l> v63;
    v63 = v62;
    v55.v[1l] = TupleCreate3(v61, v63);
    uint32_t v64;
    v64 = (uint32_t)2;
    ap_uint<4l> v65;
    v65 = v64;
    uint32_t v66;
    v66 = (uint32_t)1;
    ap_uint<2l> v67;
    v67 = v66;
    v55.v[2l] = TupleCreate3(v65, v67);
    uint32_t v68;
    v68 = (uint32_t)3;
    ap_uint<4l> v69;
    v69 = v68;
    uint32_t v70;
    v70 = (uint32_t)1;
    ap_uint<2l> v71;
    v71 = v70;
    v55.v[3l] = TupleCreate3(v69, v71);
    uint32_t v72;
    v72 = (uint32_t)4;
    ap_uint<4l> v73;
    v73 = v72;
    uint32_t v74;
    v74 = (uint32_t)1;
    ap_uint<2l> v75;
    v75 = v74;
    v55.v[4l] = TupleCreate3(v73, v75);
    uint32_t v76;
    v76 = (uint32_t)5;
    ap_uint<4l> v77;
    v77 = v76;
    uint32_t v78;
    v78 = (uint32_t)1;
    ap_uint<2l> v79;
    v79 = v78;
    v55.v[5l] = TupleCreate3(v77, v79);
    uint32_t v80;
    v80 = (uint32_t)6;
    ap_uint<4l> v81;
    v81 = v80;
    uint32_t v82;
    v82 = (uint32_t)1;
    ap_uint<2l> v83;
    v83 = v82;
    v55.v[6l] = TupleCreate3(v81, v83);
    uint32_t v84;
    v84 = (uint32_t)7;
    ap_uint<4l> v85;
    v85 = v84;
    uint32_t v86;
    v86 = (uint32_t)1;
    ap_uint<2l> v87;
    v87 = v86;
    v55.v[7l] = TupleCreate3(v85, v87);
    uint32_t v88;
    v88 = (uint32_t)3;
    ap_uint<4l> v89;
    v89 = v88;
    uint32_t v90;
    v90 = (uint32_t)2;
    ap_uint<2l> v91;
    v91 = v90;
    v55.v[8l] = TupleCreate3(v89, v91);
    uint32_t v92;
    v92 = (uint32_t)4;
    ap_uint<4l> v93;
    v93 = v92;
    uint32_t v94;
    v94 = (uint32_t)2;
    ap_uint<2l> v95;
    v95 = v94;
    v55.v[9l] = TupleCreate3(v93, v95);
    uint32_t v96;
    v96 = (uint32_t)5;
    ap_uint<4l> v97;
    v97 = v96;
    uint32_t v98;
    v98 = (uint32_t)2;
    ap_uint<2l> v99;
    v99 = v98;
    v55.v[10l] = TupleCreate3(v97, v99);
    uint32_t v100;
    v100 = (uint32_t)6;
    ap_uint<4l> v101;
    v101 = v100;
    uint32_t v102;
    v102 = (uint32_t)2;
    ap_uint<2l> v103;
    v103 = v102;
    v55.v[11l] = TupleCreate3(v101, v103);
    uint32_t v104;
    v104 = (uint32_t)7;
    ap_uint<4l> v105;
    v105 = v104;
    uint32_t v106;
    v106 = (uint32_t)2;
    ap_uint<2l> v107;
    v107 = v106;
    v55.v[12l] = TupleCreate3(v105, v107);
    array<5l,Tuple3> v108; ap_uint<4l> v109;
    Tuple4 tmp103 = score23(v55);
    v108 = tmp103.v0; v109 = tmp103.v1;
    ap_uint<4l> v110; ap_uint<2l> v111;
    Tuple3 tmp104 = v108.v[0l];
    v110 = tmp104.v0; v111 = tmp104.v1;
    int8_t v112;
    v112 = v111;
    int8_t v113;
    v113 = v110;
    ap_uint<4l> v114; ap_uint<2l> v115;
    Tuple3 tmp105 = v108.v[1l];
    v114 = tmp105.v0; v115 = tmp105.v1;
    int8_t v116;
    v116 = v115;
    int8_t v117;
    v117 = v114;
    ap_uint<4l> v118; ap_uint<2l> v119;
    Tuple3 tmp106 = v108.v[2l];
    v118 = tmp106.v0; v119 = tmp106.v1;
    int8_t v120;
    v120 = v119;
    int8_t v121;
    v121 = v118;
    ap_uint<4l> v122; ap_uint<2l> v123;
    Tuple3 tmp107 = v108.v[3l];
    v122 = tmp107.v0; v123 = tmp107.v1;
    int8_t v124;
    v124 = v123;
    int8_t v125;
    v125 = v122;
    ap_uint<4l> v126; ap_uint<2l> v127;
    Tuple3 tmp108 = v108.v[4l];
    v126 = tmp108.v0; v127 = tmp108.v1;
    int8_t v128;
    v128 = v127;
    int8_t v129;
    v129 = v126;
    int8_t v130;
    v130 = v109;
    bool v131;
    v131 = v46 == v113;
    bool v133;
    if (v131){
        bool v132;
        v132 = v45 == v112;
        v133 = v132;
    } else {
        v133 = false;
    }
    bool v149;
    if (v133){
        bool v134;
        v134 = v48 == v117;
        bool v136;
        if (v134){
            bool v135;
            v135 = v47 == v116;
            v136 = v135;
        } else {
            v136 = false;
        }
        if (v136){
            bool v137;
            v137 = v50 == v121;
            bool v139;
            if (v137){
                bool v138;
                v138 = v49 == v120;
                v139 = v138;
            } else {
                v139 = false;
            }
            if (v139){
                bool v140;
                v140 = v52 == v125;
                bool v142;
                if (v140){
                    bool v141;
                    v141 = v51 == v124;
                    v142 = v141;
                } else {
                    v142 = false;
                }
                if (v142){
                    bool v143;
                    v143 = v54 == v129;
                    if (v143){
                        bool v144;
                        v144 = v53 == v128;
                        v149 = v144;
                    } else {
                        v149 = false;
                    }
                } else {
                    v149 = false;
                }
            } else {
                v149 = false;
            }
        } else {
            v149 = false;
        }
    } else {
        v149 = false;
    }
    bool v151;
    if (v149){
        bool v150;
        v150 = v44 == v130;
        v151 = v150;
    } else {
        v151 = false;
    }
    bool v152;
    v152 = v151 != true;
    if (v152){
        std::cout << "Score: " << (int) v44 << " " ;
        std::cout << "Card: ";
        std::cout << "(" << (int) v46 << "," << (int) v45 << ") " ;
        std::cout << "(" << (int) v48 << "," << (int) v47 << ") " ;
        std::cout << "(" << (int) v50 << "," << (int) v49 << ") " ;
        std::cout << "(" << (int) v52 << "," << (int) v51 << ") " ;
        std::cout << "(" << (int) v54 << "," << (int) v53 << ") " ;
        std::cout << std::endl;
        std::cout << "Score: " << (int) v130 << " " ;
        std::cout << "Card: ";
        std::cout << "(" << (int) v113 << "," << (int) v112 << ") " ;
        std::cout << "(" << (int) v117 << "," << (int) v116 << ") " ;
        std::cout << "(" << (int) v121 << "," << (int) v120 << ") " ;
        std::cout << "(" << (int) v125 << "," << (int) v124 << ") " ;
        std::cout << "(" << (int) v129 << "," << (int) v128 << ") " ;
        std::cout << std::endl;
        return -1l;
    } else {
        return 0l;
    }
}
#endif
