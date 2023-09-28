#include <cstdint>
#include <array>
#include "ap_int.h"
#include <random>
#include <iostream>
struct Tuple0;
bool method0(uint64_t v0);
struct Tuple1;
bool method1(int32_t v0);
struct Tuple2;
struct Tuple3;
bool method4(int8_t v0);
bool method5(int8_t v0);
struct Tuple4;
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
struct Tuple5;
struct Tuple6;
bool method26(int32_t v0);
struct Tuple7;
bool method27(std::array<Tuple5,7l> v0, bool v1, int32_t v2);
bool method28(std::array<Tuple5,7l> v0, int32_t v1);
struct Tuple8;
bool method29(int32_t v0, int32_t v1, int32_t v2, int32_t v3);
struct US0;
bool method30(int32_t v0);
struct Tuple9;
struct US1;
bool method31(int32_t v0, int32_t v1);
struct US2;
bool method32(int32_t v0);
bool method33(int32_t v0);
struct US3;
bool method34(int32_t v0);
struct US4;
bool method35(int32_t v0);
struct Tuple10;
struct Tuple11;
struct Tuple12;
struct US5;
struct US6;
struct US7;
Tuple6 score25(std::array<Tuple5,7l> v0);
struct Tuple0 {
    uint64_t v0;
    int32_t v1;
};
struct Tuple1 {
    int8_t v0;
    int8_t v1;
};
struct Tuple2 {
    int8_t v0;
    int8_t v1;
    int8_t v2;
    int8_t v3;
    int8_t v4;
    int8_t v5;
};
struct Tuple3 {
    uint16_t v1;
    int8_t v0;
};
struct Tuple4 {
    uint64_t v1;
    int8_t v0;
};
struct Tuple5 {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
};
struct Tuple6 {
    std::array<Tuple5,5l> v0;
    ap_uint<4l> v1;
};
struct Tuple7 {
    int32_t v1;
    bool v0;
};
struct Tuple8 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
};
struct US0 {
    ap_uint<2> tag;
    union U {
        U() {}
    } v;
    US0() {}
    US0(const US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US0(const US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US0 & operator=(US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
    US0 & operator=(US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
};
struct Tuple9 {
    ap_uint<4l> v3;
    int32_t v0;
    int32_t v1;
    int32_t v2;
};
struct US1 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple5,2l> v0;
            std::array<Tuple5,5l> v1;
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
            std::array<Tuple5,5l> v0;
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
            std::array<Tuple5,2l> v0;
            std::array<Tuple5,3l> v1;
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
struct US4 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple5,3l> v0;
            std::array<Tuple5,4l> v1;
        } case1; // Some
        U() {}
    } v;
    US4() {}
    US4(const US4 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US4(const US4 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US4 & operator=(US4 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US4 & operator=(US4 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct Tuple10 {
    ap_uint<4l> v2;
    int32_t v1;
    int32_t v0;
};
struct Tuple11 {
    int32_t v0;
    int32_t v1;
};
struct Tuple12 {
    US0 v1;
    int32_t v0;
};
struct US5 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple5,2l> v0;
            std::array<Tuple5,2l> v1;
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
            std::array<Tuple5,4l> v0;
            std::array<Tuple5,3l> v1;
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
            std::array<Tuple5,5l> v0;
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
static inline Tuple0 TupleCreate0(uint64_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method0(uint64_t v0){
    bool v1;
    v1 = v0 < 100000ull;
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
    Tuple3 tmp8 = TupleCreate3(0, 0u);
    v1 = tmp8.v0; v2 = tmp8.v1;
    while (method4(v1)){
        int8_t v4; uint16_t v5;
        Tuple3 tmp9 = TupleCreate3(0, v2);
        v4 = tmp9.v0; v5 = tmp9.v1;
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
    Tuple4 tmp10 = TupleCreate4(0, 0ull);
    v19 = tmp10.v0; v20 = tmp10.v1;
    while (method4(v19)){
        int8_t v22; uint64_t v23;
        Tuple4 tmp11 = TupleCreate4(0, v20);
        v22 = tmp11.v0; v23 = tmp11.v1;
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
static inline Tuple6 TupleCreate6(std::array<Tuple5,5l> v0, ap_uint<4l> v1){
    Tuple6 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method26(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
static inline Tuple7 TupleCreate7(bool v0, int32_t v1){
    Tuple7 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method27(std::array<Tuple5,7l> v0, bool v1, int32_t v2){
    bool v3;
    v3 = v2 < 7l;
    return v3;
}
bool method28(std::array<Tuple5,7l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 7l;
    return v2;
}
static inline Tuple8 TupleCreate8(int32_t v0, int32_t v1, int32_t v2){
    Tuple8 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
bool method29(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
US0 US0_0() { // Eq
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1() { // Gt
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_2() { // Lt
    US0 x;
    x.tag = 2;
    return x;
}
bool method30(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
static inline Tuple9 TupleCreate9(int32_t v0, int32_t v1, int32_t v2, ap_uint<4l> v3){
    Tuple9 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3;
    return x;
}
US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(std::array<Tuple5,2l> v0, std::array<Tuple5,5l> v1) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method31(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1(std::array<Tuple5,5l> v0) { // Some
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
bool method32(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
bool method33(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1(std::array<Tuple5,2l> v0, std::array<Tuple5,3l> v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method34(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
US4 US4_1(std::array<Tuple5,3l> v0, std::array<Tuple5,4l> v1) { // Some
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method35(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
static inline Tuple10 TupleCreate10(int32_t v0, int32_t v1, ap_uint<4l> v2){
    Tuple10 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static inline Tuple11 TupleCreate11(int32_t v0, int32_t v1){
    Tuple11 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple12 TupleCreate12(int32_t v0, US0 v1){
    Tuple12 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(std::array<Tuple5,2l> v0, std::array<Tuple5,2l> v1) { // Some
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
US6 US6_1(std::array<Tuple5,4l> v0, std::array<Tuple5,3l> v1) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
US7 US7_1(std::array<Tuple5,5l> v0, ap_uint<4l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple6 score25(std::array<Tuple5,7l> v0){
    std::array<Tuple5,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (method26(v2)){
        ap_uint<4l> v4; ap_uint<2l> v5;
        Tuple5 tmp13 = v0[v2];
        v4 = tmp13.v0; v5 = tmp13.v1;
        v1[v2] = TupleCreate5(v4, v5);
        v2++;
    }
    std::array<Tuple5,7l> v6;
    bool v7; int32_t v8;
    Tuple7 tmp14 = TupleCreate7(true, 1l);
    v7 = tmp14.v0; v8 = tmp14.v1;
    while (method27(v1, v7, v8)){
        int32_t v10;
        v10 = 0l;
        while (method28(v1, v10)){
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
            Tuple8 tmp15 = TupleCreate8(v10, v14, v10);
            v19 = tmp15.v0; v20 = tmp15.v1; v21 = tmp15.v2;
            while (method29(v18, v19, v20, v21)){
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
                        Tuple5 tmp16 = v1[v19];
                        v26 = tmp16.v0; v27 = tmp16.v1;
                        v30 = v26; v31 = v27;
                    } else {
                        ap_uint<4l> v28; ap_uint<2l> v29;
                        Tuple5 tmp17 = v6[v19];
                        v28 = tmp17.v0; v29 = tmp17.v1;
                        v30 = v28; v31 = v29;
                    }
                    ap_uint<4l> v36; ap_uint<2l> v37;
                    if (v7){
                        ap_uint<4l> v32; ap_uint<2l> v33;
                        Tuple5 tmp18 = v1[v20];
                        v32 = tmp18.v0; v33 = tmp18.v1;
                        v36 = v32; v37 = v33;
                    } else {
                        ap_uint<4l> v34; ap_uint<2l> v35;
                        Tuple5 tmp19 = v6[v20];
                        v34 = tmp19.v0; v35 = tmp19.v1;
                        v36 = v34; v37 = v35;
                    }
                    bool v38;
                    v38 = v36 > v30;
                    US0 v44;
                    if (v38){
                        v44 = US0_1();
                    } else {
                        bool v40;
                        v40 = v36 < v30;
                        if (v40){
                            v44 = US0_2();
                        } else {
                            v44 = US0_0();
                        }
                    }
                    US0 v52;
                    switch (v44.tag) {
                        case 0: { // Eq
                            bool v45;
                            v45 = v31 > v37;
                            if (v45){
                                v52 = US0_1();
                            } else {
                                bool v47;
                                v47 = v31 < v37;
                                if (v47){
                                    v52 = US0_2();
                                } else {
                                    v52 = US0_0();
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
                            Tuple5 tmp20 = v1[v19];
                            v59 = tmp20.v0; v60 = tmp20.v1;
                            v63 = v59; v64 = v60;
                        } else {
                            ap_uint<4l> v61; ap_uint<2l> v62;
                            Tuple5 tmp21 = v6[v19];
                            v61 = tmp21.v0; v62 = tmp21.v1;
                            v63 = v61; v64 = v62;
                        }
                        int32_t v65;
                        v65 = v19 + 1l;
                        v77 = v63; v78 = v64; v79 = v65; v80 = v20;
                    } else {
                        ap_uint<4l> v70; ap_uint<2l> v71;
                        if (v7){
                            ap_uint<4l> v66; ap_uint<2l> v67;
                            Tuple5 tmp22 = v1[v20];
                            v66 = tmp22.v0; v67 = tmp22.v1;
                            v70 = v66; v71 = v67;
                        } else {
                            ap_uint<4l> v68; ap_uint<2l> v69;
                            Tuple5 tmp23 = v6[v20];
                            v68 = tmp23.v0; v69 = tmp23.v1;
                            v70 = v68; v71 = v69;
                        }
                        int32_t v72;
                        v72 = v20 + 1l;
                        v77 = v70; v78 = v71; v79 = v19; v80 = v72;
                    }
                }
                if (v7){
                    v6[v21] = TupleCreate5(v77, v78);
                } else {
                    v1[v21] = TupleCreate5(v77, v78);
                }
                int32_t v81;
                v81 = v21 + 1l;
                v19 = v79;
                v20 = v80;
                v21 = v81;
            }
            v10 = v16;
        }
        std::cout << "***\n" ;
        bool v82;
        v82 = v7 == false;
        int32_t v83;
        v83 = v8 * 2l;
        v7 = v82;
        v8 = v83;
    }
    bool v84;
    v84 = v7 == false;
    std::array<Tuple5,7l> v85;
    if (v84){
        v85 = v6;
    } else {
        v85 = v1;
    }
    std::array<Tuple5,5l> v86;
    int32_t v87;
    v87 = 0l;
    while (method30(v87)){
        ap_uint<4l> v89; ap_uint<2l> v90;
        Tuple5 tmp24 = v85[v87];
        v89 = tmp24.v0; v90 = tmp24.v1;
        v86[v87] = TupleCreate5(v89, v90);
        v87++;
    }
    std::array<Tuple5,2l> v91;
    std::array<Tuple5,5l> v92;
    ap_uint<4l> v93;
    v93 = 12ul;
    int32_t v94; int32_t v95; int32_t v96; ap_uint<4l> v97;
    Tuple9 tmp25 = TupleCreate9(0l, 0l, 0l, v93);
    v94 = tmp25.v0; v95 = tmp25.v1; v96 = tmp25.v2; v97 = tmp25.v3;
    while (method26(v94)){
        ap_uint<4l> v99; ap_uint<2l> v100;
        Tuple5 tmp26 = v85[v94];
        v99 = tmp26.v0; v100 = tmp26.v1;
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
            v91[v103] = TupleCreate5(v99, v100);
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
    US1 v122;
    if (v108){
        int32_t v109;
        v109 = v95 + 1l;
        int32_t v110;
        v110 = v109 - 2l;
        int32_t v111;
        v111 = 0l;
        while (method31(v110, v111)){
            ap_uint<4l> v113; ap_uint<2l> v114;
            Tuple5 tmp27 = v85[v111];
            v113 = tmp27.v0; v114 = tmp27.v1;
            v92[v111] = TupleCreate5(v113, v114);
            v111++;
        }
        int32_t v115;
        v115 = v110;
        while (method30(v115)){
            int32_t v117;
            v117 = 2l + v115;
            ap_uint<4l> v118; ap_uint<2l> v119;
            Tuple5 tmp28 = v85[v117];
            v118 = tmp28.v0; v119 = tmp28.v1;
            v92[v115] = TupleCreate5(v118, v119);
            v115++;
        }
        v122 = US1_1(v91, v92);
    } else {
        v122 = US1_0();
    }
    US2 v144;
    switch (v122.tag) {
        case 0: { // None
            v144 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,2l> v123 = v122.v.case1.v0; std::array<Tuple5,5l> v124 = v122.v.case1.v1;
            std::array<Tuple5,3l> v125;
            int32_t v126;
            v126 = 0l;
            while (method32(v126)){
                ap_uint<4l> v128; ap_uint<2l> v129;
                Tuple5 tmp29 = v124[v126];
                v128 = tmp29.v0; v129 = tmp29.v1;
                v125[v126] = TupleCreate5(v128, v129);
                v126++;
            }
            std::array<Tuple5,0l> v130;
            std::array<Tuple5,5l> v131;
            int32_t v132;
            v132 = 0l;
            while (method33(v132)){
                ap_uint<4l> v134; ap_uint<2l> v135;
                Tuple5 tmp30 = v123[v132];
                v134 = tmp30.v0; v135 = tmp30.v1;
                v131[v132] = TupleCreate5(v134, v135);
                v132++;
            }
            int32_t v136;
            v136 = 0l;
            while (method32(v136)){
                ap_uint<4l> v138; ap_uint<2l> v139;
                Tuple5 tmp31 = v125[v136];
                v138 = tmp31.v0; v139 = tmp31.v1;
                int32_t v140;
                v140 = 2l + v136;
                v131[v140] = TupleCreate5(v138, v139);
                v136++;
            }
            v144 = US2_1(v131);
        }
    }
    std::array<Tuple5,2l> v145;
    std::array<Tuple5,5l> v146;
    ap_uint<4l> v147;
    v147 = 12ul;
    int32_t v148; int32_t v149; int32_t v150; ap_uint<4l> v151;
    Tuple9 tmp32 = TupleCreate9(0l, 0l, 0l, v147);
    v148 = tmp32.v0; v149 = tmp32.v1; v150 = tmp32.v2; v151 = tmp32.v3;
    while (method26(v148)){
        ap_uint<4l> v153; ap_uint<2l> v154;
        Tuple5 tmp33 = v85[v148];
        v153 = tmp33.v0; v154 = tmp33.v1;
        bool v155;
        v155 = v150 < 2l;
        int32_t v159; int32_t v160; ap_uint<4l> v161;
        if (v155){
            bool v156;
            v156 = v151 == v153;
            int32_t v157;
            if (v156){
                v157 = v150;
            } else {
                v157 = 0l;
            }
            v145[v157] = TupleCreate5(v153, v154);
            int32_t v158;
            v158 = v157 + 1l;
            v159 = v148; v160 = v158; v161 = v153;
        } else {
            v159 = v149; v160 = v150; v161 = v151;
        }
        v149 = v159;
        v150 = v160;
        v151 = v161;
        v148++;
    }
    bool v162;
    v162 = v150 == 2l;
    US1 v176;
    if (v162){
        int32_t v163;
        v163 = v149 + 1l;
        int32_t v164;
        v164 = v163 - 2l;
        int32_t v165;
        v165 = 0l;
        while (method31(v164, v165)){
            ap_uint<4l> v167; ap_uint<2l> v168;
            Tuple5 tmp34 = v85[v165];
            v167 = tmp34.v0; v168 = tmp34.v1;
            v146[v165] = TupleCreate5(v167, v168);
            v165++;
        }
        int32_t v169;
        v169 = v164;
        while (method30(v169)){
            int32_t v171;
            v171 = 2l + v169;
            ap_uint<4l> v172; ap_uint<2l> v173;
            Tuple5 tmp35 = v85[v171];
            v172 = tmp35.v0; v173 = tmp35.v1;
            v146[v169] = TupleCreate5(v172, v173);
            v169++;
        }
        v176 = US1_1(v145, v146);
    } else {
        v176 = US1_0();
    }
    US2 v239;
    switch (v176.tag) {
        case 0: { // None
            v239 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,2l> v177 = v176.v.case1.v0; std::array<Tuple5,5l> v178 = v176.v.case1.v1;
            std::array<Tuple5,2l> v179;
            std::array<Tuple5,3l> v180;
            ap_uint<4l> v181;
            v181 = 12ul;
            int32_t v182; int32_t v183; int32_t v184; ap_uint<4l> v185;
            Tuple9 tmp36 = TupleCreate9(0l, 0l, 0l, v181);
            v182 = tmp36.v0; v183 = tmp36.v1; v184 = tmp36.v2; v185 = tmp36.v3;
            while (method30(v182)){
                ap_uint<4l> v187; ap_uint<2l> v188;
                Tuple5 tmp37 = v178[v182];
                v187 = tmp37.v0; v188 = tmp37.v1;
                bool v189;
                v189 = v184 < 2l;
                int32_t v193; int32_t v194; ap_uint<4l> v195;
                if (v189){
                    bool v190;
                    v190 = v185 == v187;
                    int32_t v191;
                    if (v190){
                        v191 = v184;
                    } else {
                        v191 = 0l;
                    }
                    v179[v191] = TupleCreate5(v187, v188);
                    int32_t v192;
                    v192 = v191 + 1l;
                    v193 = v182; v194 = v192; v195 = v187;
                } else {
                    v193 = v183; v194 = v184; v195 = v185;
                }
                v183 = v193;
                v184 = v194;
                v185 = v195;
                v182++;
            }
            bool v196;
            v196 = v184 == 2l;
            US3 v210;
            if (v196){
                int32_t v197;
                v197 = v183 + 1l;
                int32_t v198;
                v198 = v197 - 2l;
                int32_t v199;
                v199 = 0l;
                while (method31(v198, v199)){
                    ap_uint<4l> v201; ap_uint<2l> v202;
                    Tuple5 tmp38 = v178[v199];
                    v201 = tmp38.v0; v202 = tmp38.v1;
                    v180[v199] = TupleCreate5(v201, v202);
                    v199++;
                }
                int32_t v203;
                v203 = v198;
                while (method32(v203)){
                    int32_t v205;
                    v205 = 2l + v203;
                    ap_uint<4l> v206; ap_uint<2l> v207;
                    Tuple5 tmp39 = v178[v205];
                    v206 = tmp39.v0; v207 = tmp39.v1;
                    v180[v203] = TupleCreate5(v206, v207);
                    v203++;
                }
                v210 = US3_1(v179, v180);
            } else {
                v210 = US3_0();
            }
            switch (v210.tag) {
                case 0: { // None
                    v239 = US2_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple5,2l> v211 = v210.v.case1.v0; std::array<Tuple5,3l> v212 = v210.v.case1.v1;
                    std::array<Tuple5,1l> v213;
                    int32_t v214;
                    v214 = 0l;
                    while (method34(v214)){
                        ap_uint<4l> v216; ap_uint<2l> v217;
                        Tuple5 tmp40 = v212[v214];
                        v216 = tmp40.v0; v217 = tmp40.v1;
                        v213[v214] = TupleCreate5(v216, v217);
                        v214++;
                    }
                    std::array<Tuple5,5l> v218;
                    int32_t v219;
                    v219 = 0l;
                    while (method33(v219)){
                        ap_uint<4l> v221; ap_uint<2l> v222;
                        Tuple5 tmp41 = v177[v219];
                        v221 = tmp41.v0; v222 = tmp41.v1;
                        v218[v219] = TupleCreate5(v221, v222);
                        v219++;
                    }
                    int32_t v223;
                    v223 = 0l;
                    while (method33(v223)){
                        ap_uint<4l> v225; ap_uint<2l> v226;
                        Tuple5 tmp42 = v211[v223];
                        v225 = tmp42.v0; v226 = tmp42.v1;
                        int32_t v227;
                        v227 = 2l + v223;
                        v218[v227] = TupleCreate5(v225, v226);
                        v223++;
                    }
                    int32_t v228;
                    v228 = 0l;
                    while (method34(v228)){
                        ap_uint<4l> v230; ap_uint<2l> v231;
                        Tuple5 tmp43 = v213[v228];
                        v230 = tmp43.v0; v231 = tmp43.v1;
                        int32_t v232;
                        v232 = 4l + v228;
                        v218[v232] = TupleCreate5(v230, v231);
                        v228++;
                    }
                    v239 = US2_1(v218);
                }
            }
        }
    }
    std::array<Tuple5,3l> v240;
    std::array<Tuple5,4l> v241;
    ap_uint<4l> v242;
    v242 = 12ul;
    int32_t v243; int32_t v244; int32_t v245; ap_uint<4l> v246;
    Tuple9 tmp44 = TupleCreate9(0l, 0l, 0l, v242);
    v243 = tmp44.v0; v244 = tmp44.v1; v245 = tmp44.v2; v246 = tmp44.v3;
    while (method26(v243)){
        ap_uint<4l> v248; ap_uint<2l> v249;
        Tuple5 tmp45 = v85[v243];
        v248 = tmp45.v0; v249 = tmp45.v1;
        bool v250;
        v250 = v245 < 3l;
        int32_t v254; int32_t v255; ap_uint<4l> v256;
        if (v250){
            bool v251;
            v251 = v246 == v248;
            int32_t v252;
            if (v251){
                v252 = v245;
            } else {
                v252 = 0l;
            }
            v240[v252] = TupleCreate5(v248, v249);
            int32_t v253;
            v253 = v252 + 1l;
            v254 = v243; v255 = v253; v256 = v248;
        } else {
            v254 = v244; v255 = v245; v256 = v246;
        }
        v244 = v254;
        v245 = v255;
        v246 = v256;
        v243++;
    }
    bool v257;
    v257 = v245 == 3l;
    US4 v271;
    if (v257){
        int32_t v258;
        v258 = v244 + 1l;
        int32_t v259;
        v259 = v258 - 3l;
        int32_t v260;
        v260 = 0l;
        while (method31(v259, v260)){
            ap_uint<4l> v262; ap_uint<2l> v263;
            Tuple5 tmp46 = v85[v260];
            v262 = tmp46.v0; v263 = tmp46.v1;
            v241[v260] = TupleCreate5(v262, v263);
            v260++;
        }
        int32_t v264;
        v264 = v259;
        while (method35(v264)){
            int32_t v266;
            v266 = 3l + v264;
            ap_uint<4l> v267; ap_uint<2l> v268;
            Tuple5 tmp47 = v85[v266];
            v267 = tmp47.v0; v268 = tmp47.v1;
            v241[v264] = TupleCreate5(v267, v268);
            v264++;
        }
        v271 = US4_1(v240, v241);
    } else {
        v271 = US4_0();
    }
    US2 v293;
    switch (v271.tag) {
        case 0: { // None
            v293 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,3l> v272 = v271.v.case1.v0; std::array<Tuple5,4l> v273 = v271.v.case1.v1;
            std::array<Tuple5,2l> v274;
            int32_t v275;
            v275 = 0l;
            while (method33(v275)){
                ap_uint<4l> v277; ap_uint<2l> v278;
                Tuple5 tmp48 = v273[v275];
                v277 = tmp48.v0; v278 = tmp48.v1;
                v274[v275] = TupleCreate5(v277, v278);
                v275++;
            }
            std::array<Tuple5,0l> v279;
            std::array<Tuple5,5l> v280;
            int32_t v281;
            v281 = 0l;
            while (method32(v281)){
                ap_uint<4l> v283; ap_uint<2l> v284;
                Tuple5 tmp49 = v272[v281];
                v283 = tmp49.v0; v284 = tmp49.v1;
                v280[v281] = TupleCreate5(v283, v284);
                v281++;
            }
            int32_t v285;
            v285 = 0l;
            while (method33(v285)){
                ap_uint<4l> v287; ap_uint<2l> v288;
                Tuple5 tmp50 = v274[v285];
                v287 = tmp50.v0; v288 = tmp50.v1;
                int32_t v289;
                v289 = 3l + v285;
                v280[v289] = TupleCreate5(v287, v288);
                v285++;
            }
            v293 = US2_1(v280);
        }
    }
    std::array<Tuple5,5l> v294;
    ap_uint<4l> v295;
    v295 = 12ul;
    int32_t v296; int32_t v297; ap_uint<4l> v298;
    Tuple10 tmp51 = TupleCreate10(0l, 0l, v295);
    v296 = tmp51.v0; v297 = tmp51.v1; v298 = tmp51.v2;
    while (method26(v296)){
        ap_uint<4l> v300; ap_uint<2l> v301;
        Tuple5 tmp52 = v85[v296];
        v300 = tmp52.v0; v301 = tmp52.v1;
        bool v302;
        v302 = v297 < 5l;
        bool v307;
        if (v302){
            ap_uint<4l> v303;
            v303 = 1ul;
            ap_uint<4l> v304;
            v304 = v300 - v303;
            bool v305;
            v305 = v298 == v304;
            bool v306;
            v306 = v305 != true;
            v307 = v306;
        } else {
            v307 = false;
        }
        int32_t v313; ap_uint<4l> v314;
        if (v307){
            bool v308;
            v308 = v298 == v300;
            int32_t v309;
            if (v308){
                v309 = v297;
            } else {
                v309 = 0l;
            }
            v294[v309] = TupleCreate5(v300, v301);
            int32_t v310;
            v310 = v309 + 1l;
            ap_uint<4l> v311;
            v311 = 1ul;
            ap_uint<4l> v312;
            v312 = v300 - v311;
            v313 = v310; v314 = v312;
        } else {
            v313 = v297; v314 = v298;
        }
        v297 = v313;
        v298 = v314;
        v296++;
    }
    bool v315;
    v315 = v297 == 4l;
    bool v326;
    if (v315){
        ap_uint<4l> v316;
        v316 = 0ul;
        ap_uint<4l> v317;
        v317 = 1ul;
        ap_uint<4l> v318;
        v318 = v316 - v317;
        bool v319;
        v319 = v298 == v318;
        if (v319){
            ap_uint<4l> v320; ap_uint<2l> v321;
            Tuple5 tmp53 = v85[0l];
            v320 = tmp53.v0; v321 = tmp53.v1;
            ap_uint<4l> v322;
            v322 = 12ul;
            bool v323;
            v323 = v320 == v322;
            if (v323){
                v294[4l] = TupleCreate5(v320, v321);
                v326 = true;
            } else {
                v326 = false;
            }
        } else {
            v326 = false;
        }
    } else {
        v326 = false;
    }
    US2 v332;
    if (v326){
        v332 = US2_1(v294);
    } else {
        bool v328;
        v328 = v297 == 5l;
        if (v328){
            v332 = US2_1(v294);
        } else {
            v332 = US2_0();
        }
    }
    std::array<Tuple5,5l> v333;
    int32_t v334; int32_t v335;
    Tuple11 tmp54 = TupleCreate11(0l, 0l);
    v334 = tmp54.v0; v335 = tmp54.v1;
    while (method26(v334)){
        ap_uint<4l> v337; ap_uint<2l> v338;
        Tuple5 tmp55 = v85[v334];
        v337 = tmp55.v0; v338 = tmp55.v1;
        ap_uint<2l> v339;
        v339 = 3ul;
        bool v340;
        v340 = v338 == v339;
        bool v342;
        if (v340){
            bool v341;
            v341 = v335 < 5l;
            v342 = v341;
        } else {
            v342 = false;
        }
        int32_t v344;
        if (v342){
            v333[v335] = TupleCreate5(v337, v338);
            int32_t v343;
            v343 = v335 + 1l;
            v344 = v343;
        } else {
            v344 = v335;
        }
        v335 = v344;
        v334++;
    }
    bool v345;
    v345 = v335 == 5l;
    US2 v348;
    if (v345){
        v348 = US2_1(v333);
    } else {
        v348 = US2_0();
    }
    std::array<Tuple5,5l> v349;
    int32_t v350; int32_t v351;
    Tuple11 tmp56 = TupleCreate11(0l, 0l);
    v350 = tmp56.v0; v351 = tmp56.v1;
    while (method26(v350)){
        ap_uint<4l> v353; ap_uint<2l> v354;
        Tuple5 tmp57 = v85[v350];
        v353 = tmp57.v0; v354 = tmp57.v1;
        ap_uint<2l> v355;
        v355 = 2ul;
        bool v356;
        v356 = v354 == v355;
        bool v358;
        if (v356){
            bool v357;
            v357 = v351 < 5l;
            v358 = v357;
        } else {
            v358 = false;
        }
        int32_t v360;
        if (v358){
            v349[v351] = TupleCreate5(v353, v354);
            int32_t v359;
            v359 = v351 + 1l;
            v360 = v359;
        } else {
            v360 = v351;
        }
        v351 = v360;
        v350++;
    }
    bool v361;
    v361 = v351 == 5l;
    US2 v364;
    if (v361){
        v364 = US2_1(v349);
    } else {
        v364 = US2_0();
    }
    std::array<Tuple5,5l> v365;
    int32_t v366; int32_t v367;
    Tuple11 tmp58 = TupleCreate11(0l, 0l);
    v366 = tmp58.v0; v367 = tmp58.v1;
    while (method26(v366)){
        ap_uint<4l> v369; ap_uint<2l> v370;
        Tuple5 tmp59 = v85[v366];
        v369 = tmp59.v0; v370 = tmp59.v1;
        ap_uint<2l> v371;
        v371 = 1ul;
        bool v372;
        v372 = v370 == v371;
        bool v374;
        if (v372){
            bool v373;
            v373 = v367 < 5l;
            v374 = v373;
        } else {
            v374 = false;
        }
        int32_t v376;
        if (v374){
            v365[v367] = TupleCreate5(v369, v370);
            int32_t v375;
            v375 = v367 + 1l;
            v376 = v375;
        } else {
            v376 = v367;
        }
        v367 = v376;
        v366++;
    }
    bool v377;
    v377 = v367 == 5l;
    US2 v380;
    if (v377){
        v380 = US2_1(v365);
    } else {
        v380 = US2_0();
    }
    std::array<Tuple5,5l> v381;
    int32_t v382; int32_t v383;
    Tuple11 tmp60 = TupleCreate11(0l, 0l);
    v382 = tmp60.v0; v383 = tmp60.v1;
    while (method26(v382)){
        ap_uint<4l> v385; ap_uint<2l> v386;
        Tuple5 tmp61 = v85[v382];
        v385 = tmp61.v0; v386 = tmp61.v1;
        ap_uint<2l> v387;
        v387 = 0ul;
        bool v388;
        v388 = v386 == v387;
        bool v390;
        if (v388){
            bool v389;
            v389 = v383 < 5l;
            v390 = v389;
        } else {
            v390 = false;
        }
        int32_t v392;
        if (v390){
            v381[v383] = TupleCreate5(v385, v386);
            int32_t v391;
            v391 = v383 + 1l;
            v392 = v391;
        } else {
            v392 = v383;
        }
        v383 = v392;
        v382++;
    }
    bool v393;
    v393 = v383 == 5l;
    US2 v396;
    if (v393){
        v396 = US2_1(v381);
    } else {
        v396 = US2_0();
    }
    US2 v421;
    switch (v396.tag) {
        case 0: { // None
            v421 = v380;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v397 = v396.v.case1.v0;
            switch (v380.tag) {
                case 0: { // None
                    v421 = v396;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v398 = v380.v.case1.v0;
                    US0 v399;
                    v399 = US0_0();
                    int32_t v400; US0 v401;
                    Tuple12 tmp62 = TupleCreate12(0l, v399);
                    v400 = tmp62.v0; v401 = tmp62.v1;
                    while (method30(v400)){
                        ap_uint<4l> v403; ap_uint<2l> v404;
                        Tuple5 tmp63 = v397[v400];
                        v403 = tmp63.v0; v404 = tmp63.v1;
                        ap_uint<4l> v405; ap_uint<2l> v406;
                        Tuple5 tmp64 = v398[v400];
                        v405 = tmp64.v0; v406 = tmp64.v1;
                        US0 v414;
                        switch (v401.tag) {
                            case 0: { // Eq
                                bool v407;
                                v407 = v403 > v405;
                                if (v407){
                                    v414 = US0_1();
                                } else {
                                    bool v409;
                                    v409 = v403 < v405;
                                    if (v409){
                                        v414 = US0_2();
                                    } else {
                                        v414 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v414 = v401;
                            }
                        }
                        v401 = v414;
                        v400++;
                    }
                    bool v415;
                    switch (v401.tag) {
                        case 1: { // Gt
                            v415 = true;
                            break;
                        }
                        default: {
                            v415 = false;
                        }
                    }
                    std::array<Tuple5,5l> v416;
                    if (v415){
                        v416 = v397;
                    } else {
                        v416 = v398;
                    }
                    v421 = US2_1(v416);
                }
            }
        }
    }
    US2 v446;
    switch (v421.tag) {
        case 0: { // None
            v446 = v364;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v422 = v421.v.case1.v0;
            switch (v364.tag) {
                case 0: { // None
                    v446 = v421;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v423 = v364.v.case1.v0;
                    US0 v424;
                    v424 = US0_0();
                    int32_t v425; US0 v426;
                    Tuple12 tmp65 = TupleCreate12(0l, v424);
                    v425 = tmp65.v0; v426 = tmp65.v1;
                    while (method30(v425)){
                        ap_uint<4l> v428; ap_uint<2l> v429;
                        Tuple5 tmp66 = v422[v425];
                        v428 = tmp66.v0; v429 = tmp66.v1;
                        ap_uint<4l> v430; ap_uint<2l> v431;
                        Tuple5 tmp67 = v423[v425];
                        v430 = tmp67.v0; v431 = tmp67.v1;
                        US0 v439;
                        switch (v426.tag) {
                            case 0: { // Eq
                                bool v432;
                                v432 = v428 > v430;
                                if (v432){
                                    v439 = US0_1();
                                } else {
                                    bool v434;
                                    v434 = v428 < v430;
                                    if (v434){
                                        v439 = US0_2();
                                    } else {
                                        v439 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v439 = v426;
                            }
                        }
                        v426 = v439;
                        v425++;
                    }
                    bool v440;
                    switch (v426.tag) {
                        case 1: { // Gt
                            v440 = true;
                            break;
                        }
                        default: {
                            v440 = false;
                        }
                    }
                    std::array<Tuple5,5l> v441;
                    if (v440){
                        v441 = v422;
                    } else {
                        v441 = v423;
                    }
                    v446 = US2_1(v441);
                }
            }
        }
    }
    US2 v471;
    switch (v446.tag) {
        case 0: { // None
            v471 = v348;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v447 = v446.v.case1.v0;
            switch (v348.tag) {
                case 0: { // None
                    v471 = v446;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v448 = v348.v.case1.v0;
                    US0 v449;
                    v449 = US0_0();
                    int32_t v450; US0 v451;
                    Tuple12 tmp68 = TupleCreate12(0l, v449);
                    v450 = tmp68.v0; v451 = tmp68.v1;
                    while (method30(v450)){
                        ap_uint<4l> v453; ap_uint<2l> v454;
                        Tuple5 tmp69 = v447[v450];
                        v453 = tmp69.v0; v454 = tmp69.v1;
                        ap_uint<4l> v455; ap_uint<2l> v456;
                        Tuple5 tmp70 = v448[v450];
                        v455 = tmp70.v0; v456 = tmp70.v1;
                        US0 v464;
                        switch (v451.tag) {
                            case 0: { // Eq
                                bool v457;
                                v457 = v453 > v455;
                                if (v457){
                                    v464 = US0_1();
                                } else {
                                    bool v459;
                                    v459 = v453 < v455;
                                    if (v459){
                                        v464 = US0_2();
                                    } else {
                                        v464 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v464 = v451;
                            }
                        }
                        v451 = v464;
                        v450++;
                    }
                    bool v465;
                    switch (v451.tag) {
                        case 1: { // Gt
                            v465 = true;
                            break;
                        }
                        default: {
                            v465 = false;
                        }
                    }
                    std::array<Tuple5,5l> v466;
                    if (v465){
                        v466 = v447;
                    } else {
                        v466 = v448;
                    }
                    v471 = US2_1(v466);
                }
            }
        }
    }
    std::array<Tuple5,3l> v472;
    std::array<Tuple5,4l> v473;
    ap_uint<4l> v474;
    v474 = 12ul;
    int32_t v475; int32_t v476; int32_t v477; ap_uint<4l> v478;
    Tuple9 tmp71 = TupleCreate9(0l, 0l, 0l, v474);
    v475 = tmp71.v0; v476 = tmp71.v1; v477 = tmp71.v2; v478 = tmp71.v3;
    while (method26(v475)){
        ap_uint<4l> v480; ap_uint<2l> v481;
        Tuple5 tmp72 = v85[v475];
        v480 = tmp72.v0; v481 = tmp72.v1;
        bool v482;
        v482 = v477 < 3l;
        int32_t v486; int32_t v487; ap_uint<4l> v488;
        if (v482){
            bool v483;
            v483 = v478 == v480;
            int32_t v484;
            if (v483){
                v484 = v477;
            } else {
                v484 = 0l;
            }
            v472[v484] = TupleCreate5(v480, v481);
            int32_t v485;
            v485 = v484 + 1l;
            v486 = v475; v487 = v485; v488 = v480;
        } else {
            v486 = v476; v487 = v477; v488 = v478;
        }
        v476 = v486;
        v477 = v487;
        v478 = v488;
        v475++;
    }
    bool v489;
    v489 = v477 == 3l;
    US4 v503;
    if (v489){
        int32_t v490;
        v490 = v476 + 1l;
        int32_t v491;
        v491 = v490 - 3l;
        int32_t v492;
        v492 = 0l;
        while (method31(v491, v492)){
            ap_uint<4l> v494; ap_uint<2l> v495;
            Tuple5 tmp73 = v85[v492];
            v494 = tmp73.v0; v495 = tmp73.v1;
            v473[v492] = TupleCreate5(v494, v495);
            v492++;
        }
        int32_t v496;
        v496 = v491;
        while (method35(v496)){
            int32_t v498;
            v498 = 3l + v496;
            ap_uint<4l> v499; ap_uint<2l> v500;
            Tuple5 tmp74 = v85[v498];
            v499 = tmp74.v0; v500 = tmp74.v1;
            v473[v496] = TupleCreate5(v499, v500);
            v496++;
        }
        v503 = US4_1(v472, v473);
    } else {
        v503 = US4_0();
    }
    US2 v557;
    switch (v503.tag) {
        case 0: { // None
            v557 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,3l> v504 = v503.v.case1.v0; std::array<Tuple5,4l> v505 = v503.v.case1.v1;
            std::array<Tuple5,2l> v506;
            std::array<Tuple5,2l> v507;
            ap_uint<4l> v508;
            v508 = 12ul;
            int32_t v509; int32_t v510; int32_t v511; ap_uint<4l> v512;
            Tuple9 tmp75 = TupleCreate9(0l, 0l, 0l, v508);
            v509 = tmp75.v0; v510 = tmp75.v1; v511 = tmp75.v2; v512 = tmp75.v3;
            while (method35(v509)){
                ap_uint<4l> v514; ap_uint<2l> v515;
                Tuple5 tmp76 = v505[v509];
                v514 = tmp76.v0; v515 = tmp76.v1;
                bool v516;
                v516 = v511 < 2l;
                int32_t v520; int32_t v521; ap_uint<4l> v522;
                if (v516){
                    bool v517;
                    v517 = v512 == v514;
                    int32_t v518;
                    if (v517){
                        v518 = v511;
                    } else {
                        v518 = 0l;
                    }
                    v506[v518] = TupleCreate5(v514, v515);
                    int32_t v519;
                    v519 = v518 + 1l;
                    v520 = v509; v521 = v519; v522 = v514;
                } else {
                    v520 = v510; v521 = v511; v522 = v512;
                }
                v510 = v520;
                v511 = v521;
                v512 = v522;
                v509++;
            }
            bool v523;
            v523 = v511 == 2l;
            US5 v537;
            if (v523){
                int32_t v524;
                v524 = v510 + 1l;
                int32_t v525;
                v525 = v524 - 2l;
                int32_t v526;
                v526 = 0l;
                while (method31(v525, v526)){
                    ap_uint<4l> v528; ap_uint<2l> v529;
                    Tuple5 tmp77 = v505[v526];
                    v528 = tmp77.v0; v529 = tmp77.v1;
                    v507[v526] = TupleCreate5(v528, v529);
                    v526++;
                }
                int32_t v530;
                v530 = v525;
                while (method33(v530)){
                    int32_t v532;
                    v532 = 2l + v530;
                    ap_uint<4l> v533; ap_uint<2l> v534;
                    Tuple5 tmp78 = v505[v532];
                    v533 = tmp78.v0; v534 = tmp78.v1;
                    v507[v530] = TupleCreate5(v533, v534);
                    v530++;
                }
                v537 = US5_1(v506, v507);
            } else {
                v537 = US5_0();
            }
            switch (v537.tag) {
                case 0: { // None
                    v557 = US2_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple5,2l> v538 = v537.v.case1.v0; std::array<Tuple5,2l> v539 = v537.v.case1.v1;
                    std::array<Tuple5,0l> v540;
                    std::array<Tuple5,5l> v541;
                    int32_t v542;
                    v542 = 0l;
                    while (method32(v542)){
                        ap_uint<4l> v544; ap_uint<2l> v545;
                        Tuple5 tmp79 = v504[v542];
                        v544 = tmp79.v0; v545 = tmp79.v1;
                        v541[v542] = TupleCreate5(v544, v545);
                        v542++;
                    }
                    int32_t v546;
                    v546 = 0l;
                    while (method33(v546)){
                        ap_uint<4l> v548; ap_uint<2l> v549;
                        Tuple5 tmp80 = v538[v546];
                        v548 = tmp80.v0; v549 = tmp80.v1;
                        int32_t v550;
                        v550 = 3l + v546;
                        v541[v550] = TupleCreate5(v548, v549);
                        v546++;
                    }
                    v557 = US2_1(v541);
                }
            }
        }
    }
    std::array<Tuple5,4l> v558;
    std::array<Tuple5,3l> v559;
    ap_uint<4l> v560;
    v560 = 12ul;
    int32_t v561; int32_t v562; int32_t v563; ap_uint<4l> v564;
    Tuple9 tmp81 = TupleCreate9(0l, 0l, 0l, v560);
    v561 = tmp81.v0; v562 = tmp81.v1; v563 = tmp81.v2; v564 = tmp81.v3;
    while (method26(v561)){
        ap_uint<4l> v566; ap_uint<2l> v567;
        Tuple5 tmp82 = v85[v561];
        v566 = tmp82.v0; v567 = tmp82.v1;
        bool v568;
        v568 = v563 < 4l;
        int32_t v572; int32_t v573; ap_uint<4l> v574;
        if (v568){
            bool v569;
            v569 = v564 == v566;
            int32_t v570;
            if (v569){
                v570 = v563;
            } else {
                v570 = 0l;
            }
            v558[v570] = TupleCreate5(v566, v567);
            int32_t v571;
            v571 = v570 + 1l;
            v572 = v561; v573 = v571; v574 = v566;
        } else {
            v572 = v562; v573 = v563; v574 = v564;
        }
        v562 = v572;
        v563 = v573;
        v564 = v574;
        v561++;
    }
    bool v575;
    v575 = v563 == 4l;
    US6 v589;
    if (v575){
        int32_t v576;
        v576 = v562 + 1l;
        int32_t v577;
        v577 = v576 - 4l;
        int32_t v578;
        v578 = 0l;
        while (method31(v577, v578)){
            ap_uint<4l> v580; ap_uint<2l> v581;
            Tuple5 tmp83 = v85[v578];
            v580 = tmp83.v0; v581 = tmp83.v1;
            v559[v578] = TupleCreate5(v580, v581);
            v578++;
        }
        int32_t v582;
        v582 = v577;
        while (method32(v582)){
            int32_t v584;
            v584 = 4l + v582;
            ap_uint<4l> v585; ap_uint<2l> v586;
            Tuple5 tmp84 = v85[v584];
            v585 = tmp84.v0; v586 = tmp84.v1;
            v559[v582] = TupleCreate5(v585, v586);
            v582++;
        }
        v589 = US6_1(v558, v559);
    } else {
        v589 = US6_0();
    }
    US2 v611;
    switch (v589.tag) {
        case 0: { // None
            v611 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,4l> v590 = v589.v.case1.v0; std::array<Tuple5,3l> v591 = v589.v.case1.v1;
            std::array<Tuple5,1l> v592;
            int32_t v593;
            v593 = 0l;
            while (method34(v593)){
                ap_uint<4l> v595; ap_uint<2l> v596;
                Tuple5 tmp85 = v591[v593];
                v595 = tmp85.v0; v596 = tmp85.v1;
                v592[v593] = TupleCreate5(v595, v596);
                v593++;
            }
            std::array<Tuple5,0l> v597;
            std::array<Tuple5,5l> v598;
            int32_t v599;
            v599 = 0l;
            while (method35(v599)){
                ap_uint<4l> v601; ap_uint<2l> v602;
                Tuple5 tmp86 = v590[v599];
                v601 = tmp86.v0; v602 = tmp86.v1;
                v598[v599] = TupleCreate5(v601, v602);
                v599++;
            }
            int32_t v603;
            v603 = 0l;
            while (method34(v603)){
                ap_uint<4l> v605; ap_uint<2l> v606;
                Tuple5 tmp87 = v592[v603];
                v605 = tmp87.v0; v606 = tmp87.v1;
                int32_t v607;
                v607 = 4l + v603;
                v598[v607] = TupleCreate5(v605, v606);
                v603++;
            }
            v611 = US2_1(v598);
        }
    }
    ap_uint<2l> v612;
    v612 = 3ul;
    std::array<Tuple5,5l> v613;
    ap_uint<4l> v614;
    v614 = 12ul;
    int32_t v615; int32_t v616; ap_uint<4l> v617;
    Tuple10 tmp88 = TupleCreate10(0l, 0l, v614);
    v615 = tmp88.v0; v616 = tmp88.v1; v617 = tmp88.v2;
    while (method26(v615)){
        ap_uint<4l> v619; ap_uint<2l> v620;
        Tuple5 tmp89 = v85[v615];
        v619 = tmp89.v0; v620 = tmp89.v1;
        bool v621;
        v621 = v616 < 5l;
        bool v623;
        if (v621){
            bool v622;
            v622 = v612 == v620;
            v623 = v622;
        } else {
            v623 = false;
        }
        int32_t v629; ap_uint<4l> v630;
        if (v623){
            bool v624;
            v624 = v617 == v619;
            int32_t v625;
            if (v624){
                v625 = v616;
            } else {
                v625 = 0l;
            }
            v613[v625] = TupleCreate5(v619, v620);
            int32_t v626;
            v626 = v625 + 1l;
            ap_uint<4l> v627;
            v627 = 1ul;
            ap_uint<4l> v628;
            v628 = v619 - v627;
            v629 = v626; v630 = v628;
        } else {
            v629 = v616; v630 = v617;
        }
        v616 = v629;
        v617 = v630;
        v615++;
    }
    bool v631;
    v631 = v616 == 4l;
    bool v668;
    if (v631){
        ap_uint<4l> v632;
        v632 = 0ul;
        ap_uint<4l> v633;
        v633 = 1ul;
        ap_uint<4l> v634;
        v634 = v632 - v633;
        bool v635;
        v635 = v617 == v634;
        if (v635){
            ap_uint<4l> v636; ap_uint<2l> v637;
            Tuple5 tmp90 = v85[0l];
            v636 = tmp90.v0; v637 = tmp90.v1;
            bool v638;
            v638 = v612 == v637;
            bool v642;
            if (v638){
                ap_uint<4l> v639;
                v639 = 12ul;
                bool v640;
                v640 = v636 == v639;
                if (v640){
                    v613[4l] = TupleCreate5(v636, v637);
                    v642 = true;
                } else {
                    v642 = false;
                }
            } else {
                v642 = false;
            }
            if (v642){
                v668 = true;
            } else {
                ap_uint<4l> v643; ap_uint<2l> v644;
                Tuple5 tmp91 = v85[1l];
                v643 = tmp91.v0; v644 = tmp91.v1;
                bool v645;
                v645 = v612 == v644;
                bool v649;
                if (v645){
                    ap_uint<4l> v646;
                    v646 = 12ul;
                    bool v647;
                    v647 = v643 == v646;
                    if (v647){
                        v613[4l] = TupleCreate5(v643, v644);
                        v649 = true;
                    } else {
                        v649 = false;
                    }
                } else {
                    v649 = false;
                }
                if (v649){
                    v668 = true;
                } else {
                    ap_uint<4l> v650; ap_uint<2l> v651;
                    Tuple5 tmp92 = v85[2l];
                    v650 = tmp92.v0; v651 = tmp92.v1;
                    bool v652;
                    v652 = v612 == v651;
                    bool v656;
                    if (v652){
                        ap_uint<4l> v653;
                        v653 = 12ul;
                        bool v654;
                        v654 = v650 == v653;
                        if (v654){
                            v613[4l] = TupleCreate5(v650, v651);
                            v656 = true;
                        } else {
                            v656 = false;
                        }
                    } else {
                        v656 = false;
                    }
                    if (v656){
                        v668 = true;
                    } else {
                        ap_uint<4l> v657; ap_uint<2l> v658;
                        Tuple5 tmp93 = v85[3l];
                        v657 = tmp93.v0; v658 = tmp93.v1;
                        bool v659;
                        v659 = v612 == v658;
                        if (v659){
                            ap_uint<4l> v660;
                            v660 = 12ul;
                            bool v661;
                            v661 = v657 == v660;
                            if (v661){
                                v613[4l] = TupleCreate5(v657, v658);
                                v668 = true;
                            } else {
                                v668 = false;
                            }
                        } else {
                            v668 = false;
                        }
                    }
                }
            }
        } else {
            v668 = false;
        }
    } else {
        v668 = false;
    }
    US2 v674;
    if (v668){
        v674 = US2_1(v613);
    } else {
        bool v670;
        v670 = v616 == 5l;
        if (v670){
            v674 = US2_1(v613);
        } else {
            v674 = US2_0();
        }
    }
    ap_uint<2l> v675;
    v675 = 2ul;
    std::array<Tuple5,5l> v676;
    ap_uint<4l> v677;
    v677 = 12ul;
    int32_t v678; int32_t v679; ap_uint<4l> v680;
    Tuple10 tmp94 = TupleCreate10(0l, 0l, v677);
    v678 = tmp94.v0; v679 = tmp94.v1; v680 = tmp94.v2;
    while (method26(v678)){
        ap_uint<4l> v682; ap_uint<2l> v683;
        Tuple5 tmp95 = v85[v678];
        v682 = tmp95.v0; v683 = tmp95.v1;
        bool v684;
        v684 = v679 < 5l;
        bool v686;
        if (v684){
            bool v685;
            v685 = v675 == v683;
            v686 = v685;
        } else {
            v686 = false;
        }
        int32_t v692; ap_uint<4l> v693;
        if (v686){
            bool v687;
            v687 = v680 == v682;
            int32_t v688;
            if (v687){
                v688 = v679;
            } else {
                v688 = 0l;
            }
            v676[v688] = TupleCreate5(v682, v683);
            int32_t v689;
            v689 = v688 + 1l;
            ap_uint<4l> v690;
            v690 = 1ul;
            ap_uint<4l> v691;
            v691 = v682 - v690;
            v692 = v689; v693 = v691;
        } else {
            v692 = v679; v693 = v680;
        }
        v679 = v692;
        v680 = v693;
        v678++;
    }
    bool v694;
    v694 = v679 == 4l;
    bool v731;
    if (v694){
        ap_uint<4l> v695;
        v695 = 0ul;
        ap_uint<4l> v696;
        v696 = 1ul;
        ap_uint<4l> v697;
        v697 = v695 - v696;
        bool v698;
        v698 = v680 == v697;
        if (v698){
            ap_uint<4l> v699; ap_uint<2l> v700;
            Tuple5 tmp96 = v85[0l];
            v699 = tmp96.v0; v700 = tmp96.v1;
            bool v701;
            v701 = v675 == v700;
            bool v705;
            if (v701){
                ap_uint<4l> v702;
                v702 = 12ul;
                bool v703;
                v703 = v699 == v702;
                if (v703){
                    v676[4l] = TupleCreate5(v699, v700);
                    v705 = true;
                } else {
                    v705 = false;
                }
            } else {
                v705 = false;
            }
            if (v705){
                v731 = true;
            } else {
                ap_uint<4l> v706; ap_uint<2l> v707;
                Tuple5 tmp97 = v85[1l];
                v706 = tmp97.v0; v707 = tmp97.v1;
                bool v708;
                v708 = v675 == v707;
                bool v712;
                if (v708){
                    ap_uint<4l> v709;
                    v709 = 12ul;
                    bool v710;
                    v710 = v706 == v709;
                    if (v710){
                        v676[4l] = TupleCreate5(v706, v707);
                        v712 = true;
                    } else {
                        v712 = false;
                    }
                } else {
                    v712 = false;
                }
                if (v712){
                    v731 = true;
                } else {
                    ap_uint<4l> v713; ap_uint<2l> v714;
                    Tuple5 tmp98 = v85[2l];
                    v713 = tmp98.v0; v714 = tmp98.v1;
                    bool v715;
                    v715 = v675 == v714;
                    bool v719;
                    if (v715){
                        ap_uint<4l> v716;
                        v716 = 12ul;
                        bool v717;
                        v717 = v713 == v716;
                        if (v717){
                            v676[4l] = TupleCreate5(v713, v714);
                            v719 = true;
                        } else {
                            v719 = false;
                        }
                    } else {
                        v719 = false;
                    }
                    if (v719){
                        v731 = true;
                    } else {
                        ap_uint<4l> v720; ap_uint<2l> v721;
                        Tuple5 tmp99 = v85[3l];
                        v720 = tmp99.v0; v721 = tmp99.v1;
                        bool v722;
                        v722 = v675 == v721;
                        if (v722){
                            ap_uint<4l> v723;
                            v723 = 12ul;
                            bool v724;
                            v724 = v720 == v723;
                            if (v724){
                                v676[4l] = TupleCreate5(v720, v721);
                                v731 = true;
                            } else {
                                v731 = false;
                            }
                        } else {
                            v731 = false;
                        }
                    }
                }
            }
        } else {
            v731 = false;
        }
    } else {
        v731 = false;
    }
    US2 v737;
    if (v731){
        v737 = US2_1(v676);
    } else {
        bool v733;
        v733 = v679 == 5l;
        if (v733){
            v737 = US2_1(v676);
        } else {
            v737 = US2_0();
        }
    }
    ap_uint<2l> v738;
    v738 = 1ul;
    std::array<Tuple5,5l> v739;
    ap_uint<4l> v740;
    v740 = 12ul;
    int32_t v741; int32_t v742; ap_uint<4l> v743;
    Tuple10 tmp100 = TupleCreate10(0l, 0l, v740);
    v741 = tmp100.v0; v742 = tmp100.v1; v743 = tmp100.v2;
    while (method26(v741)){
        ap_uint<4l> v745; ap_uint<2l> v746;
        Tuple5 tmp101 = v85[v741];
        v745 = tmp101.v0; v746 = tmp101.v1;
        bool v747;
        v747 = v742 < 5l;
        bool v749;
        if (v747){
            bool v748;
            v748 = v738 == v746;
            v749 = v748;
        } else {
            v749 = false;
        }
        int32_t v755; ap_uint<4l> v756;
        if (v749){
            bool v750;
            v750 = v743 == v745;
            int32_t v751;
            if (v750){
                v751 = v742;
            } else {
                v751 = 0l;
            }
            v739[v751] = TupleCreate5(v745, v746);
            int32_t v752;
            v752 = v751 + 1l;
            ap_uint<4l> v753;
            v753 = 1ul;
            ap_uint<4l> v754;
            v754 = v745 - v753;
            v755 = v752; v756 = v754;
        } else {
            v755 = v742; v756 = v743;
        }
        v742 = v755;
        v743 = v756;
        v741++;
    }
    bool v757;
    v757 = v742 == 4l;
    bool v794;
    if (v757){
        ap_uint<4l> v758;
        v758 = 0ul;
        ap_uint<4l> v759;
        v759 = 1ul;
        ap_uint<4l> v760;
        v760 = v758 - v759;
        bool v761;
        v761 = v743 == v760;
        if (v761){
            ap_uint<4l> v762; ap_uint<2l> v763;
            Tuple5 tmp102 = v85[0l];
            v762 = tmp102.v0; v763 = tmp102.v1;
            bool v764;
            v764 = v738 == v763;
            bool v768;
            if (v764){
                ap_uint<4l> v765;
                v765 = 12ul;
                bool v766;
                v766 = v762 == v765;
                if (v766){
                    v739[4l] = TupleCreate5(v762, v763);
                    v768 = true;
                } else {
                    v768 = false;
                }
            } else {
                v768 = false;
            }
            if (v768){
                v794 = true;
            } else {
                ap_uint<4l> v769; ap_uint<2l> v770;
                Tuple5 tmp103 = v85[1l];
                v769 = tmp103.v0; v770 = tmp103.v1;
                bool v771;
                v771 = v738 == v770;
                bool v775;
                if (v771){
                    ap_uint<4l> v772;
                    v772 = 12ul;
                    bool v773;
                    v773 = v769 == v772;
                    if (v773){
                        v739[4l] = TupleCreate5(v769, v770);
                        v775 = true;
                    } else {
                        v775 = false;
                    }
                } else {
                    v775 = false;
                }
                if (v775){
                    v794 = true;
                } else {
                    ap_uint<4l> v776; ap_uint<2l> v777;
                    Tuple5 tmp104 = v85[2l];
                    v776 = tmp104.v0; v777 = tmp104.v1;
                    bool v778;
                    v778 = v738 == v777;
                    bool v782;
                    if (v778){
                        ap_uint<4l> v779;
                        v779 = 12ul;
                        bool v780;
                        v780 = v776 == v779;
                        if (v780){
                            v739[4l] = TupleCreate5(v776, v777);
                            v782 = true;
                        } else {
                            v782 = false;
                        }
                    } else {
                        v782 = false;
                    }
                    if (v782){
                        v794 = true;
                    } else {
                        ap_uint<4l> v783; ap_uint<2l> v784;
                        Tuple5 tmp105 = v85[3l];
                        v783 = tmp105.v0; v784 = tmp105.v1;
                        bool v785;
                        v785 = v738 == v784;
                        if (v785){
                            ap_uint<4l> v786;
                            v786 = 12ul;
                            bool v787;
                            v787 = v783 == v786;
                            if (v787){
                                v739[4l] = TupleCreate5(v783, v784);
                                v794 = true;
                            } else {
                                v794 = false;
                            }
                        } else {
                            v794 = false;
                        }
                    }
                }
            }
        } else {
            v794 = false;
        }
    } else {
        v794 = false;
    }
    US2 v800;
    if (v794){
        v800 = US2_1(v739);
    } else {
        bool v796;
        v796 = v742 == 5l;
        if (v796){
            v800 = US2_1(v739);
        } else {
            v800 = US2_0();
        }
    }
    ap_uint<2l> v801;
    v801 = 0ul;
    std::array<Tuple5,5l> v802;
    ap_uint<4l> v803;
    v803 = 12ul;
    int32_t v804; int32_t v805; ap_uint<4l> v806;
    Tuple10 tmp106 = TupleCreate10(0l, 0l, v803);
    v804 = tmp106.v0; v805 = tmp106.v1; v806 = tmp106.v2;
    while (method26(v804)){
        ap_uint<4l> v808; ap_uint<2l> v809;
        Tuple5 tmp107 = v85[v804];
        v808 = tmp107.v0; v809 = tmp107.v1;
        bool v810;
        v810 = v805 < 5l;
        bool v812;
        if (v810){
            bool v811;
            v811 = v801 == v809;
            v812 = v811;
        } else {
            v812 = false;
        }
        int32_t v818; ap_uint<4l> v819;
        if (v812){
            bool v813;
            v813 = v806 == v808;
            int32_t v814;
            if (v813){
                v814 = v805;
            } else {
                v814 = 0l;
            }
            v802[v814] = TupleCreate5(v808, v809);
            int32_t v815;
            v815 = v814 + 1l;
            ap_uint<4l> v816;
            v816 = 1ul;
            ap_uint<4l> v817;
            v817 = v808 - v816;
            v818 = v815; v819 = v817;
        } else {
            v818 = v805; v819 = v806;
        }
        v805 = v818;
        v806 = v819;
        v804++;
    }
    bool v820;
    v820 = v805 == 4l;
    bool v857;
    if (v820){
        ap_uint<4l> v821;
        v821 = 0ul;
        ap_uint<4l> v822;
        v822 = 1ul;
        ap_uint<4l> v823;
        v823 = v821 - v822;
        bool v824;
        v824 = v806 == v823;
        if (v824){
            ap_uint<4l> v825; ap_uint<2l> v826;
            Tuple5 tmp108 = v85[0l];
            v825 = tmp108.v0; v826 = tmp108.v1;
            bool v827;
            v827 = v801 == v826;
            bool v831;
            if (v827){
                ap_uint<4l> v828;
                v828 = 12ul;
                bool v829;
                v829 = v825 == v828;
                if (v829){
                    v802[4l] = TupleCreate5(v825, v826);
                    v831 = true;
                } else {
                    v831 = false;
                }
            } else {
                v831 = false;
            }
            if (v831){
                v857 = true;
            } else {
                ap_uint<4l> v832; ap_uint<2l> v833;
                Tuple5 tmp109 = v85[1l];
                v832 = tmp109.v0; v833 = tmp109.v1;
                bool v834;
                v834 = v801 == v833;
                bool v838;
                if (v834){
                    ap_uint<4l> v835;
                    v835 = 12ul;
                    bool v836;
                    v836 = v832 == v835;
                    if (v836){
                        v802[4l] = TupleCreate5(v832, v833);
                        v838 = true;
                    } else {
                        v838 = false;
                    }
                } else {
                    v838 = false;
                }
                if (v838){
                    v857 = true;
                } else {
                    ap_uint<4l> v839; ap_uint<2l> v840;
                    Tuple5 tmp110 = v85[2l];
                    v839 = tmp110.v0; v840 = tmp110.v1;
                    bool v841;
                    v841 = v801 == v840;
                    bool v845;
                    if (v841){
                        ap_uint<4l> v842;
                        v842 = 12ul;
                        bool v843;
                        v843 = v839 == v842;
                        if (v843){
                            v802[4l] = TupleCreate5(v839, v840);
                            v845 = true;
                        } else {
                            v845 = false;
                        }
                    } else {
                        v845 = false;
                    }
                    if (v845){
                        v857 = true;
                    } else {
                        ap_uint<4l> v846; ap_uint<2l> v847;
                        Tuple5 tmp111 = v85[3l];
                        v846 = tmp111.v0; v847 = tmp111.v1;
                        bool v848;
                        v848 = v801 == v847;
                        if (v848){
                            ap_uint<4l> v849;
                            v849 = 12ul;
                            bool v850;
                            v850 = v846 == v849;
                            if (v850){
                                v802[4l] = TupleCreate5(v846, v847);
                                v857 = true;
                            } else {
                                v857 = false;
                            }
                        } else {
                            v857 = false;
                        }
                    }
                }
            }
        } else {
            v857 = false;
        }
    } else {
        v857 = false;
    }
    US2 v863;
    if (v857){
        v863 = US2_1(v802);
    } else {
        bool v859;
        v859 = v805 == 5l;
        if (v859){
            v863 = US2_1(v802);
        } else {
            v863 = US2_0();
        }
    }
    US2 v888;
    switch (v863.tag) {
        case 0: { // None
            v888 = v800;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v864 = v863.v.case1.v0;
            switch (v800.tag) {
                case 0: { // None
                    v888 = v863;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v865 = v800.v.case1.v0;
                    US0 v866;
                    v866 = US0_0();
                    int32_t v867; US0 v868;
                    Tuple12 tmp112 = TupleCreate12(0l, v866);
                    v867 = tmp112.v0; v868 = tmp112.v1;
                    while (method30(v867)){
                        ap_uint<4l> v870; ap_uint<2l> v871;
                        Tuple5 tmp113 = v864[v867];
                        v870 = tmp113.v0; v871 = tmp113.v1;
                        ap_uint<4l> v872; ap_uint<2l> v873;
                        Tuple5 tmp114 = v865[v867];
                        v872 = tmp114.v0; v873 = tmp114.v1;
                        US0 v881;
                        switch (v868.tag) {
                            case 0: { // Eq
                                bool v874;
                                v874 = v870 > v872;
                                if (v874){
                                    v881 = US0_1();
                                } else {
                                    bool v876;
                                    v876 = v870 < v872;
                                    if (v876){
                                        v881 = US0_2();
                                    } else {
                                        v881 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v881 = v868;
                            }
                        }
                        v868 = v881;
                        v867++;
                    }
                    bool v882;
                    switch (v868.tag) {
                        case 1: { // Gt
                            v882 = true;
                            break;
                        }
                        default: {
                            v882 = false;
                        }
                    }
                    std::array<Tuple5,5l> v883;
                    if (v882){
                        v883 = v864;
                    } else {
                        v883 = v865;
                    }
                    v888 = US2_1(v883);
                }
            }
        }
    }
    US2 v913;
    switch (v888.tag) {
        case 0: { // None
            v913 = v737;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v889 = v888.v.case1.v0;
            switch (v737.tag) {
                case 0: { // None
                    v913 = v888;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v890 = v737.v.case1.v0;
                    US0 v891;
                    v891 = US0_0();
                    int32_t v892; US0 v893;
                    Tuple12 tmp115 = TupleCreate12(0l, v891);
                    v892 = tmp115.v0; v893 = tmp115.v1;
                    while (method30(v892)){
                        ap_uint<4l> v895; ap_uint<2l> v896;
                        Tuple5 tmp116 = v889[v892];
                        v895 = tmp116.v0; v896 = tmp116.v1;
                        ap_uint<4l> v897; ap_uint<2l> v898;
                        Tuple5 tmp117 = v890[v892];
                        v897 = tmp117.v0; v898 = tmp117.v1;
                        US0 v906;
                        switch (v893.tag) {
                            case 0: { // Eq
                                bool v899;
                                v899 = v895 > v897;
                                if (v899){
                                    v906 = US0_1();
                                } else {
                                    bool v901;
                                    v901 = v895 < v897;
                                    if (v901){
                                        v906 = US0_2();
                                    } else {
                                        v906 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v906 = v893;
                            }
                        }
                        v893 = v906;
                        v892++;
                    }
                    bool v907;
                    switch (v893.tag) {
                        case 1: { // Gt
                            v907 = true;
                            break;
                        }
                        default: {
                            v907 = false;
                        }
                    }
                    std::array<Tuple5,5l> v908;
                    if (v907){
                        v908 = v889;
                    } else {
                        v908 = v890;
                    }
                    v913 = US2_1(v908);
                }
            }
        }
    }
    US2 v938;
    switch (v913.tag) {
        case 0: { // None
            v938 = v674;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v914 = v913.v.case1.v0;
            switch (v674.tag) {
                case 0: { // None
                    v938 = v913;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v915 = v674.v.case1.v0;
                    US0 v916;
                    v916 = US0_0();
                    int32_t v917; US0 v918;
                    Tuple12 tmp118 = TupleCreate12(0l, v916);
                    v917 = tmp118.v0; v918 = tmp118.v1;
                    while (method30(v917)){
                        ap_uint<4l> v920; ap_uint<2l> v921;
                        Tuple5 tmp119 = v914[v917];
                        v920 = tmp119.v0; v921 = tmp119.v1;
                        ap_uint<4l> v922; ap_uint<2l> v923;
                        Tuple5 tmp120 = v915[v917];
                        v922 = tmp120.v0; v923 = tmp120.v1;
                        US0 v931;
                        switch (v918.tag) {
                            case 0: { // Eq
                                bool v924;
                                v924 = v920 > v922;
                                if (v924){
                                    v931 = US0_1();
                                } else {
                                    bool v926;
                                    v926 = v920 < v922;
                                    if (v926){
                                        v931 = US0_2();
                                    } else {
                                        v931 = US0_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v931 = v918;
                            }
                        }
                        v918 = v931;
                        v917++;
                    }
                    bool v932;
                    switch (v918.tag) {
                        case 1: { // Gt
                            v932 = true;
                            break;
                        }
                        default: {
                            v932 = false;
                        }
                    }
                    std::array<Tuple5,5l> v933;
                    if (v932){
                        v933 = v914;
                    } else {
                        v933 = v915;
                    }
                    v938 = US2_1(v933);
                }
            }
        }
    }
    ap_uint<4l> v939;
    v939 = 1ul;
    US7 v944;
    switch (v144.tag) {
        case 0: { // None
            v944 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v940 = v144.v.case1.v0;
            v944 = US7_1(v940, v939);
        }
    }
    ap_uint<4l> v945;
    v945 = 2ul;
    US7 v950;
    switch (v239.tag) {
        case 0: { // None
            v950 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v946 = v239.v.case1.v0;
            v950 = US7_1(v946, v945);
        }
    }
    ap_uint<4l> v951;
    v951 = 3ul;
    US7 v956;
    switch (v293.tag) {
        case 0: { // None
            v956 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v952 = v293.v.case1.v0;
            v956 = US7_1(v952, v951);
        }
    }
    ap_uint<4l> v957;
    v957 = 4ul;
    US7 v962;
    switch (v332.tag) {
        case 0: { // None
            v962 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v958 = v332.v.case1.v0;
            v962 = US7_1(v958, v957);
        }
    }
    ap_uint<4l> v963;
    v963 = 5ul;
    US7 v968;
    switch (v471.tag) {
        case 0: { // None
            v968 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v964 = v471.v.case1.v0;
            v968 = US7_1(v964, v963);
        }
    }
    ap_uint<4l> v969;
    v969 = 6ul;
    US7 v974;
    switch (v557.tag) {
        case 0: { // None
            v974 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v970 = v557.v.case1.v0;
            v974 = US7_1(v970, v969);
        }
    }
    ap_uint<4l> v975;
    v975 = 7ul;
    US7 v980;
    switch (v611.tag) {
        case 0: { // None
            v980 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v976 = v611.v.case1.v0;
            v980 = US7_1(v976, v975);
        }
    }
    ap_uint<4l> v981;
    v981 = 8ul;
    US7 v986;
    switch (v938.tag) {
        case 0: { // None
            v986 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v982 = v938.v.case1.v0;
            v986 = US7_1(v982, v981);
        }
    }
    US7 v988;
    switch (v986.tag) {
        case 0: { // None
            v988 = US7_0();
            break;
        }
        default: {
            v988 = v986;
        }
    }
    US7 v998;
    switch (v988.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v989 = v988.v.case1.v0; ap_uint<4l> v990 = v988.v.case1.v1;
            switch (v980.tag) {
                case 0: { // None
                    v998 = v988;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v991 = v980.v.case1.v0; ap_uint<4l> v992 = v980.v.case1.v1;
                    v998 = US7_1(v989, v990);
                }
            }
            break;
        }
        default: {
            switch (v980.tag) {
                case 0: { // None
                    v998 = v988;
                    break;
                }
                default: {
                    switch (v988.tag) {
                        default: { // None
                            v998 = v980;
                        }
                    }
                }
            }
        }
    }
    US7 v1008;
    switch (v998.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v999 = v998.v.case1.v0; ap_uint<4l> v1000 = v998.v.case1.v1;
            switch (v974.tag) {
                case 0: { // None
                    v1008 = v998;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1001 = v974.v.case1.v0; ap_uint<4l> v1002 = v974.v.case1.v1;
                    v1008 = US7_1(v999, v1000);
                }
            }
            break;
        }
        default: {
            switch (v974.tag) {
                case 0: { // None
                    v1008 = v998;
                    break;
                }
                default: {
                    switch (v998.tag) {
                        default: { // None
                            v1008 = v974;
                        }
                    }
                }
            }
        }
    }
    US7 v1018;
    switch (v1008.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1009 = v1008.v.case1.v0; ap_uint<4l> v1010 = v1008.v.case1.v1;
            switch (v968.tag) {
                case 0: { // None
                    v1018 = v1008;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1011 = v968.v.case1.v0; ap_uint<4l> v1012 = v968.v.case1.v1;
                    v1018 = US7_1(v1009, v1010);
                }
            }
            break;
        }
        default: {
            switch (v968.tag) {
                case 0: { // None
                    v1018 = v1008;
                    break;
                }
                default: {
                    switch (v1008.tag) {
                        default: { // None
                            v1018 = v968;
                        }
                    }
                }
            }
        }
    }
    US7 v1028;
    switch (v1018.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1019 = v1018.v.case1.v0; ap_uint<4l> v1020 = v1018.v.case1.v1;
            switch (v962.tag) {
                case 0: { // None
                    v1028 = v1018;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1021 = v962.v.case1.v0; ap_uint<4l> v1022 = v962.v.case1.v1;
                    v1028 = US7_1(v1019, v1020);
                }
            }
            break;
        }
        default: {
            switch (v962.tag) {
                case 0: { // None
                    v1028 = v1018;
                    break;
                }
                default: {
                    switch (v1018.tag) {
                        default: { // None
                            v1028 = v962;
                        }
                    }
                }
            }
        }
    }
    US7 v1038;
    switch (v1028.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1029 = v1028.v.case1.v0; ap_uint<4l> v1030 = v1028.v.case1.v1;
            switch (v956.tag) {
                case 0: { // None
                    v1038 = v1028;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1031 = v956.v.case1.v0; ap_uint<4l> v1032 = v956.v.case1.v1;
                    v1038 = US7_1(v1029, v1030);
                }
            }
            break;
        }
        default: {
            switch (v956.tag) {
                case 0: { // None
                    v1038 = v1028;
                    break;
                }
                default: {
                    switch (v1028.tag) {
                        default: { // None
                            v1038 = v956;
                        }
                    }
                }
            }
        }
    }
    US7 v1048;
    switch (v1038.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1039 = v1038.v.case1.v0; ap_uint<4l> v1040 = v1038.v.case1.v1;
            switch (v950.tag) {
                case 0: { // None
                    v1048 = v1038;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1041 = v950.v.case1.v0; ap_uint<4l> v1042 = v950.v.case1.v1;
                    v1048 = US7_1(v1039, v1040);
                }
            }
            break;
        }
        default: {
            switch (v950.tag) {
                case 0: { // None
                    v1048 = v1038;
                    break;
                }
                default: {
                    switch (v1038.tag) {
                        default: { // None
                            v1048 = v950;
                        }
                    }
                }
            }
        }
    }
    US7 v1058;
    switch (v1048.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1049 = v1048.v.case1.v0; ap_uint<4l> v1050 = v1048.v.case1.v1;
            switch (v944.tag) {
                case 0: { // None
                    v1058 = v1048;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1051 = v944.v.case1.v0; ap_uint<4l> v1052 = v944.v.case1.v1;
                    v1058 = US7_1(v1049, v1050);
                }
            }
            break;
        }
        default: {
            switch (v944.tag) {
                case 0: { // None
                    v1058 = v1048;
                    break;
                }
                default: {
                    switch (v1048.tag) {
                        default: { // None
                            v1058 = v944;
                        }
                    }
                }
            }
        }
    }
    std::array<Tuple5,5l> v1064; ap_uint<4l> v1065;
    switch (v1058.tag) {
        case 0: { // None
            ap_uint<4l> v1061;
            v1061 = 0ul;
            v1064 = v86; v1065 = v1061;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v1059 = v1058.v.case1.v0; ap_uint<4l> v1060 = v1058.v.case1.v1;
            v1064 = v1059; v1065 = v1060;
        }
    }
    return TupleCreate6(v1064, v1065);
}
int32_t entry() {
    std::random_device v0;
    std::mt19937 v1(v0());
    std::uniform_int_distribution<std::mt19937::result_type> v2(0l,51l);
    uint64_t v3; int32_t v4;
    Tuple0 tmp0 = TupleCreate0(0ull, 0l);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (method0(v3)){
        std::array<Tuple1,7l> v6;
        uint64_t v7;
        v7 = 0ull;
        int32_t v8;
        v8 = 7l;
        while (method1(v8)){
            int32_t v10;
            v10 = v2(v1);
            int8_t v11;
            v11 = (int8_t)v10;
            int32_t v12;
            v12 = (int32_t)v11;
            uint64_t v13;
            v13 = 1ull << v12;
            uint64_t v14;
            v14 = v7 & v13;
            bool v15;
            v15 = v14 == 0ull;
            bool v16;
            v16 = v15 != true;
            int32_t v23;
            if (v16){
                v23 = v8;
            } else {
                int32_t v17;
                v17 = v8 - 1l;
                int8_t v18;
                v18 = v11 % 13;
                int8_t v19;
                v19 = v11 / 13;
                v6[v17] = TupleCreate1(v18, v19);
                int32_t v20;
                v20 = (int32_t)v11;
                uint64_t v21;
                v21 = 1ull << v20;
                uint64_t v22;
                v22 = v7 | v21;
                v7 = v22;
                v23 = v17;
            }
            v8 = v23;
        }
        int8_t v24; int8_t v25;
        Tuple1 tmp1 = v6[0l];
        v24 = tmp1.v0; v25 = tmp1.v1;
        int8_t v26; int8_t v27;
        Tuple1 tmp2 = v6[1l];
        v26 = tmp2.v0; v27 = tmp2.v1;
        int8_t v28; int8_t v29;
        Tuple1 tmp3 = v6[2l];
        v28 = tmp3.v0; v29 = tmp3.v1;
        int8_t v30; int8_t v31;
        Tuple1 tmp4 = v6[3l];
        v30 = tmp4.v0; v31 = tmp4.v1;
        int8_t v32; int8_t v33;
        Tuple1 tmp5 = v6[4l];
        v32 = tmp5.v0; v33 = tmp5.v1;
        int8_t v34; int8_t v35;
        Tuple1 tmp6 = v6[5l];
        v34 = tmp6.v0; v35 = tmp6.v1;
        int8_t v36; int8_t v37;
        Tuple1 tmp7 = v6[6l];
        v36 = tmp7.v0; v37 = tmp7.v1;
        int8_t v38;
        v38 = v37 * 13;
        int8_t v39;
        v39 = v38 + v36;
        int32_t v40;
        v40 = (int32_t)v39;
        uint64_t v41;
        v41 = 1ull << v40;
        int8_t v42;
        v42 = v35 * 13;
        int8_t v43;
        v43 = v42 + v34;
        int32_t v44;
        v44 = (int32_t)v43;
        uint64_t v45;
        v45 = 1ull << v44;
        int8_t v46;
        v46 = v33 * 13;
        int8_t v47;
        v47 = v46 + v32;
        int32_t v48;
        v48 = (int32_t)v47;
        uint64_t v49;
        v49 = 1ull << v48;
        int8_t v50;
        v50 = v31 * 13;
        int8_t v51;
        v51 = v50 + v30;
        int32_t v52;
        v52 = (int32_t)v51;
        uint64_t v53;
        v53 = 1ull << v52;
        int8_t v54;
        v54 = v29 * 13;
        int8_t v55;
        v55 = v54 + v28;
        int32_t v56;
        v56 = (int32_t)v55;
        uint64_t v57;
        v57 = 1ull << v56;
        int8_t v58;
        v58 = v27 * 13;
        int8_t v59;
        v59 = v58 + v26;
        int32_t v60;
        v60 = (int32_t)v59;
        uint64_t v61;
        v61 = 1ull << v60;
        int8_t v62;
        v62 = v25 * 13;
        int8_t v63;
        v63 = v62 + v24;
        int32_t v64;
        v64 = (int32_t)v63;
        uint64_t v65;
        v65 = 1ull << v64;
        uint64_t v66;
        v66 = 0ull | v65;
        uint64_t v67;
        v67 = v66 | v61;
        uint64_t v68;
        v68 = v67 | v57;
        uint64_t v69;
        v69 = v68 | v53;
        uint64_t v70;
        v70 = v69 | v49;
        uint64_t v71;
        v71 = v70 | v45;
        uint64_t v72;
        v72 = v71 | v41;
        int8_t v73; int8_t v74; int8_t v75; int8_t v76; int8_t v77; int8_t v78;
        Tuple2 tmp12 = score_2(v72);
        v73 = tmp12.v0; v74 = tmp12.v1; v75 = tmp12.v2; v76 = tmp12.v3; v77 = tmp12.v4; v78 = tmp12.v5;
        int8_t v79;
        v79 = v73 / 13;
        int8_t v80;
        v80 = v73 % 13;
        int8_t v81;
        v81 = v74 / 13;
        int8_t v82;
        v82 = v74 % 13;
        int8_t v83;
        v83 = v75 / 13;
        int8_t v84;
        v84 = v75 % 13;
        int8_t v85;
        v85 = v76 / 13;
        int8_t v86;
        v86 = v76 % 13;
        int8_t v87;
        v87 = v77 / 13;
        int8_t v88;
        v88 = v77 % 13;
        std::array<Tuple5,7l> v89;
        uint32_t v90;
        v90 = (uint32_t)v24;
        ap_uint<4l> v91;
        v91 = v90;
        uint32_t v92;
        v92 = (uint32_t)v25;
        ap_uint<2l> v93;
        v93 = v92;
        v89[0l] = TupleCreate5(v91, v93);
        uint32_t v94;
        v94 = (uint32_t)v26;
        ap_uint<4l> v95;
        v95 = v94;
        uint32_t v96;
        v96 = (uint32_t)v27;
        ap_uint<2l> v97;
        v97 = v96;
        v89[1l] = TupleCreate5(v95, v97);
        uint32_t v98;
        v98 = (uint32_t)v28;
        ap_uint<4l> v99;
        v99 = v98;
        uint32_t v100;
        v100 = (uint32_t)v29;
        ap_uint<2l> v101;
        v101 = v100;
        v89[2l] = TupleCreate5(v99, v101);
        uint32_t v102;
        v102 = (uint32_t)v30;
        ap_uint<4l> v103;
        v103 = v102;
        uint32_t v104;
        v104 = (uint32_t)v31;
        ap_uint<2l> v105;
        v105 = v104;
        v89[3l] = TupleCreate5(v103, v105);
        uint32_t v106;
        v106 = (uint32_t)v32;
        ap_uint<4l> v107;
        v107 = v106;
        uint32_t v108;
        v108 = (uint32_t)v33;
        ap_uint<2l> v109;
        v109 = v108;
        v89[4l] = TupleCreate5(v107, v109);
        uint32_t v110;
        v110 = (uint32_t)v34;
        ap_uint<4l> v111;
        v111 = v110;
        uint32_t v112;
        v112 = (uint32_t)v35;
        ap_uint<2l> v113;
        v113 = v112;
        v89[5l] = TupleCreate5(v111, v113);
        uint32_t v114;
        v114 = (uint32_t)v36;
        ap_uint<4l> v115;
        v115 = v114;
        uint32_t v116;
        v116 = (uint32_t)v37;
        ap_uint<2l> v117;
        v117 = v116;
        v89[6l] = TupleCreate5(v115, v117);
        std::array<Tuple5,5l> v118; ap_uint<4l> v119;
        Tuple6 tmp121 = score25(v89);
        v118 = tmp121.v0; v119 = tmp121.v1;
        ap_uint<4l> v120; ap_uint<2l> v121;
        Tuple5 tmp122 = v118[0l];
        v120 = tmp122.v0; v121 = tmp122.v1;
        int8_t v122;
        v122 = v121;
        int8_t v123;
        v123 = v120;
        ap_uint<4l> v124; ap_uint<2l> v125;
        Tuple5 tmp123 = v118[1l];
        v124 = tmp123.v0; v125 = tmp123.v1;
        int8_t v126;
        v126 = v125;
        int8_t v127;
        v127 = v124;
        ap_uint<4l> v128; ap_uint<2l> v129;
        Tuple5 tmp124 = v118[2l];
        v128 = tmp124.v0; v129 = tmp124.v1;
        int8_t v130;
        v130 = v129;
        int8_t v131;
        v131 = v128;
        ap_uint<4l> v132; ap_uint<2l> v133;
        Tuple5 tmp125 = v118[3l];
        v132 = tmp125.v0; v133 = tmp125.v1;
        int8_t v134;
        v134 = v133;
        int8_t v135;
        v135 = v132;
        ap_uint<4l> v136; ap_uint<2l> v137;
        Tuple5 tmp126 = v118[4l];
        v136 = tmp126.v0; v137 = tmp126.v1;
        int8_t v138;
        v138 = v137;
        int8_t v139;
        v139 = v136;
        int8_t v140;
        v140 = v119;
        bool v141;
        v141 = v80 == v123;
        bool v143;
        if (v141){
            bool v142;
            v142 = v79 == v122;
            v143 = v142;
        } else {
            v143 = false;
        }
        bool v159;
        if (v143){
            bool v144;
            v144 = v82 == v127;
            bool v146;
            if (v144){
                bool v145;
                v145 = v81 == v126;
                v146 = v145;
            } else {
                v146 = false;
            }
            if (v146){
                bool v147;
                v147 = v84 == v131;
                bool v149;
                if (v147){
                    bool v148;
                    v148 = v83 == v130;
                    v149 = v148;
                } else {
                    v149 = false;
                }
                if (v149){
                    bool v150;
                    v150 = v86 == v135;
                    bool v152;
                    if (v150){
                        bool v151;
                        v151 = v85 == v134;
                        v152 = v151;
                    } else {
                        v152 = false;
                    }
                    if (v152){
                        bool v153;
                        v153 = v88 == v139;
                        if (v153){
                            bool v154;
                            v154 = v87 == v138;
                            v159 = v154;
                        } else {
                            v159 = false;
                        }
                    } else {
                        v159 = false;
                    }
                } else {
                    v159 = false;
                }
            } else {
                v159 = false;
            }
        } else {
            v159 = false;
        }
        bool v161;
        if (v159){
            bool v160;
            v160 = v78 == v140;
            v161 = v160;
        } else {
            v161 = false;
        }
        bool v162;
        v162 = v161 != true;
        int32_t v164;
        if (v162){
            std::cout << "{rank = " << (int) v24 << "; suit = " << (int) v25 << "}; " ;
            std::cout << "{rank = " << (int) v26 << "; suit = " << (int) v27 << "}; " ;
            std::cout << "{rank = " << (int) v28 << "; suit = " << (int) v29 << "}; " ;
            std::cout << "{rank = " << (int) v30 << "; suit = " << (int) v31 << "}; " ;
            std::cout << "{rank = " << (int) v32 << "; suit = " << (int) v33 << "}; " ;
            std::cout << "{rank = " << (int) v34 << "; suit = " << (int) v35 << "}; " ;
            std::cout << "{rank = " << (int) v36 << "; suit = " << (int) v37 << "}; " ;
            std::cout << std::endl;
            std::cout << "Score: " << (int) v78 << " " ;
            std::cout << "Card: ";
            std::cout << "(" << (int) v80 << "," << (int) v79 << ") " ;
            std::cout << "(" << (int) v82 << "," << (int) v81 << ") " ;
            std::cout << "(" << (int) v84 << "," << (int) v83 << ") " ;
            std::cout << "(" << (int) v86 << "," << (int) v85 << ") " ;
            std::cout << "(" << (int) v88 << "," << (int) v87 << ") " ;
            std::cout << std::endl;
            std::cout << "Score: " << (int) v140 << " " ;
            std::cout << "Card: ";
            std::cout << "(" << (int) v123 << "," << (int) v122 << ") " ;
            std::cout << "(" << (int) v127 << "," << (int) v126 << ") " ;
            std::cout << "(" << (int) v131 << "," << (int) v130 << ") " ;
            std::cout << "(" << (int) v135 << "," << (int) v134 << ") " ;
            std::cout << "(" << (int) v139 << "," << (int) v138 << ") " ;
            std::cout << std::endl;
            int32_t v163;
            v163 = v4 + 1l;
            v164 = v163;
        } else {
            v164 = v4;
        }
        v4 = v164;
        v3++;
    }
    return v4;
}
