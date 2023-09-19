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
bool method25(int32_t v0);
typedef bool (* Fun0)(Tuple5, Tuple5);
struct Tuple6;
struct Tuple7;
struct US0;
bool method27(int32_t v0, int32_t v1);
bool method28(int32_t v0);
struct US1;
bool method29(int32_t v0);
struct US2;
bool method30(int32_t v0);
struct US3;
struct Tuple8;
struct Tuple9;
struct US4;
struct Tuple10;
struct US5;
bool method31(int32_t v0);
struct US6;
bool method32(int32_t v0);
struct US7;
Tuple6 score26(std::array<Tuple5,5l> v0);
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
    ap_uint<4l> v3;
    int32_t v0;
    int32_t v1;
    int32_t v2;
};
struct US0 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple5,2l> v0;
            std::array<Tuple5,3l> v1;
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
            std::array<Tuple5,5l> v0;
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
            std::array<Tuple5,2l> v0;
            std::array<Tuple5,1l> v1;
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
            std::array<Tuple5,3l> v0;
            std::array<Tuple5,2l> v1;
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
struct Tuple8 {
    ap_uint<4l> v2;
    int32_t v1;
    int32_t v0;
};
struct Tuple9 {
    int32_t v0;
    int32_t v1;
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
struct Tuple10 {
    US4 v1;
    int32_t v0;
};
struct US5 {
    ap_uint<2> tag;
    union U {
        struct {
            std::array<Tuple5,2l> v0;
            std::array<Tuple5,0l> v1;
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
            std::array<Tuple5,1l> v1;
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
bool method25(int32_t v0){
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
static inline Tuple6 TupleCreate6(std::array<Tuple5,5l> v0, ap_uint<4l> v1){
    Tuple6 x;
    x.v0 = v0; x.v1 = v1;
    return x;
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
US0 US0_1(std::array<Tuple5,2l> v0, std::array<Tuple5,3l> v1) { // Some
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
US1 US1_1(std::array<Tuple5,5l> v0) { // Some
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
US2 US2_1(std::array<Tuple5,2l> v0, std::array<Tuple5,1l> v1) { // Some
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
US3 US3_1(std::array<Tuple5,3l> v0, std::array<Tuple5,2l> v1) { // Some
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
US5 US5_1(std::array<Tuple5,2l> v0, std::array<Tuple5,0l> v1) { // Some
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
US6 US6_1(std::array<Tuple5,4l> v0, std::array<Tuple5,1l> v1) { // Some
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
US7 US7_1(std::array<Tuple5,5l> v0, ap_uint<4l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple6 score26(std::array<Tuple5,5l> v0){
    std::array<Tuple5,5l> v1;
    int32_t v2;
    v2 = 0l;
    while (method25(v2)){
        ap_uint<4l> v4; ap_uint<2l> v5;
        Tuple5 tmp12 = v0[v2];
        v4 = tmp12.v0; v5 = tmp12.v1;
        v1[v2] = TupleCreate5(v4, v5);
        v2++;
    }
    std::array<Tuple5,5l> v6;
    int32_t v7;
    v7 = 0l;
    while (method25(v7)){
        ap_uint<4l> v9; ap_uint<2l> v10;
        Tuple5 tmp13 = v1[v7];
        v9 = tmp13.v0; v10 = tmp13.v1;
        v6[v7] = TupleCreate5(v9, v10);
        v7++;
    }
    std::array<Tuple5,2l> v11;
    std::array<Tuple5,3l> v12;
    ap_uint<4l> v13;
    v13 = 12ul;
    int32_t v14; int32_t v15; int32_t v16; ap_uint<4l> v17;
    Tuple7 tmp14 = TupleCreate7(0l, 0l, 0l, v13);
    v14 = tmp14.v0; v15 = tmp14.v1; v16 = tmp14.v2; v17 = tmp14.v3;
    while (method25(v14)){
        ap_uint<4l> v19; ap_uint<2l> v20;
        Tuple5 tmp15 = v1[v14];
        v19 = tmp15.v0; v20 = tmp15.v1;
        bool v21;
        v21 = v16 < 2l;
        int32_t v25; int32_t v26; ap_uint<4l> v27;
        if (v21){
            bool v22;
            v22 = v17 == v19;
            int32_t v23;
            if (v22){
                v23 = v16;
            } else {
                v23 = 0l;
            }
            v11[v23] = TupleCreate5(v19, v20);
            int32_t v24;
            v24 = v23 + 1l;
            v25 = v14; v26 = v24; v27 = v19;
        } else {
            v25 = v15; v26 = v16; v27 = v17;
        }
        v15 = v25;
        v16 = v26;
        v17 = v27;
        v14++;
    }
    bool v28;
    v28 = v16 == 2l;
    US0 v42;
    if (v28){
        int32_t v29;
        v29 = v15 + 1l;
        int32_t v30;
        v30 = v29 - 2l;
        int32_t v31;
        v31 = 0l;
        while (method27(v30, v31)){
            ap_uint<4l> v33; ap_uint<2l> v34;
            Tuple5 tmp16 = v1[v31];
            v33 = tmp16.v0; v34 = tmp16.v1;
            v12[v31] = TupleCreate5(v33, v34);
            v31++;
        }
        int32_t v35;
        v35 = v30;
        while (method28(v35)){
            int32_t v37;
            v37 = 2l + v35;
            ap_uint<4l> v38; ap_uint<2l> v39;
            Tuple5 tmp17 = v1[v37];
            v38 = tmp17.v0; v39 = tmp17.v1;
            v12[v35] = TupleCreate5(v38, v39);
            v35++;
        }
        v42 = US0_1(v11, v12);
    } else {
        v42 = US0_0();
    }
    US1 v64;
    switch (v42.tag) {
        case 0: { // None
            v64 = US1_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,2l> v43 = v42.v.case1.v0; std::array<Tuple5,3l> v44 = v42.v.case1.v1;
            std::array<Tuple5,3l> v45;
            int32_t v46;
            v46 = 0l;
            while (method28(v46)){
                ap_uint<4l> v48; ap_uint<2l> v49;
                Tuple5 tmp18 = v44[v46];
                v48 = tmp18.v0; v49 = tmp18.v1;
                v45[v46] = TupleCreate5(v48, v49);
                v46++;
            }
            std::array<Tuple5,0l> v50;
            std::array<Tuple5,5l> v51;
            int32_t v52;
            v52 = 0l;
            while (method29(v52)){
                ap_uint<4l> v54; ap_uint<2l> v55;
                Tuple5 tmp19 = v43[v52];
                v54 = tmp19.v0; v55 = tmp19.v1;
                v51[v52] = TupleCreate5(v54, v55);
                v52++;
            }
            int32_t v56;
            v56 = 0l;
            while (method28(v56)){
                ap_uint<4l> v58; ap_uint<2l> v59;
                Tuple5 tmp20 = v45[v56];
                v58 = tmp20.v0; v59 = tmp20.v1;
                int32_t v60;
                v60 = 2l + v56;
                v51[v60] = TupleCreate5(v58, v59);
                v56++;
            }
            v64 = US1_1(v51);
        }
    }
    std::array<Tuple5,2l> v65;
    std::array<Tuple5,3l> v66;
    ap_uint<4l> v67;
    v67 = 12ul;
    int32_t v68; int32_t v69; int32_t v70; ap_uint<4l> v71;
    Tuple7 tmp21 = TupleCreate7(0l, 0l, 0l, v67);
    v68 = tmp21.v0; v69 = tmp21.v1; v70 = tmp21.v2; v71 = tmp21.v3;
    while (method25(v68)){
        ap_uint<4l> v73; ap_uint<2l> v74;
        Tuple5 tmp22 = v1[v68];
        v73 = tmp22.v0; v74 = tmp22.v1;
        bool v75;
        v75 = v70 < 2l;
        int32_t v79; int32_t v80; ap_uint<4l> v81;
        if (v75){
            bool v76;
            v76 = v71 == v73;
            int32_t v77;
            if (v76){
                v77 = v70;
            } else {
                v77 = 0l;
            }
            v65[v77] = TupleCreate5(v73, v74);
            int32_t v78;
            v78 = v77 + 1l;
            v79 = v68; v80 = v78; v81 = v73;
        } else {
            v79 = v69; v80 = v70; v81 = v71;
        }
        v69 = v79;
        v70 = v80;
        v71 = v81;
        v68++;
    }
    bool v82;
    v82 = v70 == 2l;
    US0 v96;
    if (v82){
        int32_t v83;
        v83 = v69 + 1l;
        int32_t v84;
        v84 = v83 - 2l;
        int32_t v85;
        v85 = 0l;
        while (method27(v84, v85)){
            ap_uint<4l> v87; ap_uint<2l> v88;
            Tuple5 tmp23 = v1[v85];
            v87 = tmp23.v0; v88 = tmp23.v1;
            v66[v85] = TupleCreate5(v87, v88);
            v85++;
        }
        int32_t v89;
        v89 = v84;
        while (method28(v89)){
            int32_t v91;
            v91 = 2l + v89;
            ap_uint<4l> v92; ap_uint<2l> v93;
            Tuple5 tmp24 = v1[v91];
            v92 = tmp24.v0; v93 = tmp24.v1;
            v66[v89] = TupleCreate5(v92, v93);
            v89++;
        }
        v96 = US0_1(v65, v66);
    } else {
        v96 = US0_0();
    }
    US1 v159;
    switch (v96.tag) {
        case 0: { // None
            v159 = US1_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,2l> v97 = v96.v.case1.v0; std::array<Tuple5,3l> v98 = v96.v.case1.v1;
            std::array<Tuple5,2l> v99;
            std::array<Tuple5,1l> v100;
            ap_uint<4l> v101;
            v101 = 12ul;
            int32_t v102; int32_t v103; int32_t v104; ap_uint<4l> v105;
            Tuple7 tmp25 = TupleCreate7(0l, 0l, 0l, v101);
            v102 = tmp25.v0; v103 = tmp25.v1; v104 = tmp25.v2; v105 = tmp25.v3;
            while (method28(v102)){
                ap_uint<4l> v107; ap_uint<2l> v108;
                Tuple5 tmp26 = v98[v102];
                v107 = tmp26.v0; v108 = tmp26.v1;
                bool v109;
                v109 = v104 < 2l;
                int32_t v113; int32_t v114; ap_uint<4l> v115;
                if (v109){
                    bool v110;
                    v110 = v105 == v107;
                    int32_t v111;
                    if (v110){
                        v111 = v104;
                    } else {
                        v111 = 0l;
                    }
                    v99[v111] = TupleCreate5(v107, v108);
                    int32_t v112;
                    v112 = v111 + 1l;
                    v113 = v102; v114 = v112; v115 = v107;
                } else {
                    v113 = v103; v114 = v104; v115 = v105;
                }
                v103 = v113;
                v104 = v114;
                v105 = v115;
                v102++;
            }
            bool v116;
            v116 = v104 == 2l;
            US2 v130;
            if (v116){
                int32_t v117;
                v117 = v103 + 1l;
                int32_t v118;
                v118 = v117 - 2l;
                int32_t v119;
                v119 = 0l;
                while (method27(v118, v119)){
                    ap_uint<4l> v121; ap_uint<2l> v122;
                    Tuple5 tmp27 = v98[v119];
                    v121 = tmp27.v0; v122 = tmp27.v1;
                    v100[v119] = TupleCreate5(v121, v122);
                    v119++;
                }
                int32_t v123;
                v123 = v118;
                while (method30(v123)){
                    int32_t v125;
                    v125 = 2l + v123;
                    ap_uint<4l> v126; ap_uint<2l> v127;
                    Tuple5 tmp28 = v98[v125];
                    v126 = tmp28.v0; v127 = tmp28.v1;
                    v100[v123] = TupleCreate5(v126, v127);
                    v123++;
                }
                v130 = US2_1(v99, v100);
            } else {
                v130 = US2_0();
            }
            switch (v130.tag) {
                case 0: { // None
                    v159 = US1_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple5,2l> v131 = v130.v.case1.v0; std::array<Tuple5,1l> v132 = v130.v.case1.v1;
                    std::array<Tuple5,1l> v133;
                    int32_t v134;
                    v134 = 0l;
                    while (method30(v134)){
                        ap_uint<4l> v136; ap_uint<2l> v137;
                        Tuple5 tmp29 = v132[v134];
                        v136 = tmp29.v0; v137 = tmp29.v1;
                        v133[v134] = TupleCreate5(v136, v137);
                        v134++;
                    }
                    std::array<Tuple5,5l> v138;
                    int32_t v139;
                    v139 = 0l;
                    while (method29(v139)){
                        ap_uint<4l> v141; ap_uint<2l> v142;
                        Tuple5 tmp30 = v97[v139];
                        v141 = tmp30.v0; v142 = tmp30.v1;
                        v138[v139] = TupleCreate5(v141, v142);
                        v139++;
                    }
                    int32_t v143;
                    v143 = 0l;
                    while (method29(v143)){
                        ap_uint<4l> v145; ap_uint<2l> v146;
                        Tuple5 tmp31 = v131[v143];
                        v145 = tmp31.v0; v146 = tmp31.v1;
                        int32_t v147;
                        v147 = 2l + v143;
                        v138[v147] = TupleCreate5(v145, v146);
                        v143++;
                    }
                    int32_t v148;
                    v148 = 0l;
                    while (method30(v148)){
                        ap_uint<4l> v150; ap_uint<2l> v151;
                        Tuple5 tmp32 = v133[v148];
                        v150 = tmp32.v0; v151 = tmp32.v1;
                        int32_t v152;
                        v152 = 4l + v148;
                        v138[v152] = TupleCreate5(v150, v151);
                        v148++;
                    }
                    v159 = US1_1(v138);
                }
            }
        }
    }
    std::array<Tuple5,3l> v160;
    std::array<Tuple5,2l> v161;
    ap_uint<4l> v162;
    v162 = 12ul;
    int32_t v163; int32_t v164; int32_t v165; ap_uint<4l> v166;
    Tuple7 tmp33 = TupleCreate7(0l, 0l, 0l, v162);
    v163 = tmp33.v0; v164 = tmp33.v1; v165 = tmp33.v2; v166 = tmp33.v3;
    while (method25(v163)){
        ap_uint<4l> v168; ap_uint<2l> v169;
        Tuple5 tmp34 = v1[v163];
        v168 = tmp34.v0; v169 = tmp34.v1;
        bool v170;
        v170 = v165 < 3l;
        int32_t v174; int32_t v175; ap_uint<4l> v176;
        if (v170){
            bool v171;
            v171 = v166 == v168;
            int32_t v172;
            if (v171){
                v172 = v165;
            } else {
                v172 = 0l;
            }
            v160[v172] = TupleCreate5(v168, v169);
            int32_t v173;
            v173 = v172 + 1l;
            v174 = v163; v175 = v173; v176 = v168;
        } else {
            v174 = v164; v175 = v165; v176 = v166;
        }
        v164 = v174;
        v165 = v175;
        v166 = v176;
        v163++;
    }
    bool v177;
    v177 = v165 == 3l;
    US3 v191;
    if (v177){
        int32_t v178;
        v178 = v164 + 1l;
        int32_t v179;
        v179 = v178 - 3l;
        int32_t v180;
        v180 = 0l;
        while (method27(v179, v180)){
            ap_uint<4l> v182; ap_uint<2l> v183;
            Tuple5 tmp35 = v1[v180];
            v182 = tmp35.v0; v183 = tmp35.v1;
            v161[v180] = TupleCreate5(v182, v183);
            v180++;
        }
        int32_t v184;
        v184 = v179;
        while (method29(v184)){
            int32_t v186;
            v186 = 3l + v184;
            ap_uint<4l> v187; ap_uint<2l> v188;
            Tuple5 tmp36 = v1[v186];
            v187 = tmp36.v0; v188 = tmp36.v1;
            v161[v184] = TupleCreate5(v187, v188);
            v184++;
        }
        v191 = US3_1(v160, v161);
    } else {
        v191 = US3_0();
    }
    US1 v213;
    switch (v191.tag) {
        case 0: { // None
            v213 = US1_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,3l> v192 = v191.v.case1.v0; std::array<Tuple5,2l> v193 = v191.v.case1.v1;
            std::array<Tuple5,2l> v194;
            int32_t v195;
            v195 = 0l;
            while (method29(v195)){
                ap_uint<4l> v197; ap_uint<2l> v198;
                Tuple5 tmp37 = v193[v195];
                v197 = tmp37.v0; v198 = tmp37.v1;
                v194[v195] = TupleCreate5(v197, v198);
                v195++;
            }
            std::array<Tuple5,0l> v199;
            std::array<Tuple5,5l> v200;
            int32_t v201;
            v201 = 0l;
            while (method28(v201)){
                ap_uint<4l> v203; ap_uint<2l> v204;
                Tuple5 tmp38 = v192[v201];
                v203 = tmp38.v0; v204 = tmp38.v1;
                v200[v201] = TupleCreate5(v203, v204);
                v201++;
            }
            int32_t v205;
            v205 = 0l;
            while (method29(v205)){
                ap_uint<4l> v207; ap_uint<2l> v208;
                Tuple5 tmp39 = v194[v205];
                v207 = tmp39.v0; v208 = tmp39.v1;
                int32_t v209;
                v209 = 3l + v205;
                v200[v209] = TupleCreate5(v207, v208);
                v205++;
            }
            v213 = US1_1(v200);
        }
    }
    std::array<Tuple5,5l> v214;
    ap_uint<4l> v215;
    v215 = 12ul;
    int32_t v216; int32_t v217; ap_uint<4l> v218;
    Tuple8 tmp40 = TupleCreate8(0l, 0l, v215);
    v216 = tmp40.v0; v217 = tmp40.v1; v218 = tmp40.v2;
    while (method25(v216)){
        ap_uint<4l> v220; ap_uint<2l> v221;
        Tuple5 tmp41 = v1[v216];
        v220 = tmp41.v0; v221 = tmp41.v1;
        bool v222;
        v222 = v217 < 5l;
        bool v227;
        if (v222){
            ap_uint<4l> v223;
            v223 = 1ul;
            ap_uint<4l> v224;
            v224 = v220 - v223;
            bool v225;
            v225 = v218 == v224;
            bool v226;
            v226 = v225 != true;
            v227 = v226;
        } else {
            v227 = false;
        }
        int32_t v233; ap_uint<4l> v234;
        if (v227){
            bool v228;
            v228 = v218 == v220;
            int32_t v229;
            if (v228){
                v229 = v217;
            } else {
                v229 = 0l;
            }
            v214[v229] = TupleCreate5(v220, v221);
            int32_t v230;
            v230 = v229 + 1l;
            ap_uint<4l> v231;
            v231 = 1ul;
            ap_uint<4l> v232;
            v232 = v220 - v231;
            v233 = v230; v234 = v232;
        } else {
            v233 = v217; v234 = v218;
        }
        v217 = v233;
        v218 = v234;
        v216++;
    }
    bool v235;
    v235 = v217 == 4l;
    bool v246;
    if (v235){
        ap_uint<4l> v236;
        v236 = 0ul;
        ap_uint<4l> v237;
        v237 = 1ul;
        ap_uint<4l> v238;
        v238 = v236 - v237;
        bool v239;
        v239 = v218 == v238;
        if (v239){
            ap_uint<4l> v240; ap_uint<2l> v241;
            Tuple5 tmp42 = v1[0l];
            v240 = tmp42.v0; v241 = tmp42.v1;
            ap_uint<4l> v242;
            v242 = 12ul;
            bool v243;
            v243 = v240 == v242;
            if (v243){
                v214[4l] = TupleCreate5(v240, v241);
                v246 = true;
            } else {
                v246 = false;
            }
        } else {
            v246 = false;
        }
    } else {
        v246 = false;
    }
    US1 v252;
    if (v246){
        v252 = US1_1(v214);
    } else {
        bool v248;
        v248 = v217 == 5l;
        if (v248){
            v252 = US1_1(v214);
        } else {
            v252 = US1_0();
        }
    }
    std::array<Tuple5,5l> v253;
    int32_t v254; int32_t v255;
    Tuple9 tmp43 = TupleCreate9(0l, 0l);
    v254 = tmp43.v0; v255 = tmp43.v1;
    while (method25(v254)){
        ap_uint<4l> v257; ap_uint<2l> v258;
        Tuple5 tmp44 = v1[v254];
        v257 = tmp44.v0; v258 = tmp44.v1;
        ap_uint<2l> v259;
        v259 = 3ul;
        bool v260;
        v260 = v258 == v259;
        bool v262;
        if (v260){
            bool v261;
            v261 = v255 < 5l;
            v262 = v261;
        } else {
            v262 = false;
        }
        int32_t v264;
        if (v262){
            v253[v255] = TupleCreate5(v257, v258);
            int32_t v263;
            v263 = v255 + 1l;
            v264 = v263;
        } else {
            v264 = v255;
        }
        v255 = v264;
        v254++;
    }
    bool v265;
    v265 = v255 == 5l;
    US1 v268;
    if (v265){
        v268 = US1_1(v253);
    } else {
        v268 = US1_0();
    }
    std::array<Tuple5,5l> v269;
    int32_t v270; int32_t v271;
    Tuple9 tmp45 = TupleCreate9(0l, 0l);
    v270 = tmp45.v0; v271 = tmp45.v1;
    while (method25(v270)){
        ap_uint<4l> v273; ap_uint<2l> v274;
        Tuple5 tmp46 = v1[v270];
        v273 = tmp46.v0; v274 = tmp46.v1;
        ap_uint<2l> v275;
        v275 = 2ul;
        bool v276;
        v276 = v274 == v275;
        bool v278;
        if (v276){
            bool v277;
            v277 = v271 < 5l;
            v278 = v277;
        } else {
            v278 = false;
        }
        int32_t v280;
        if (v278){
            v269[v271] = TupleCreate5(v273, v274);
            int32_t v279;
            v279 = v271 + 1l;
            v280 = v279;
        } else {
            v280 = v271;
        }
        v271 = v280;
        v270++;
    }
    bool v281;
    v281 = v271 == 5l;
    US1 v284;
    if (v281){
        v284 = US1_1(v269);
    } else {
        v284 = US1_0();
    }
    std::array<Tuple5,5l> v285;
    int32_t v286; int32_t v287;
    Tuple9 tmp47 = TupleCreate9(0l, 0l);
    v286 = tmp47.v0; v287 = tmp47.v1;
    while (method25(v286)){
        ap_uint<4l> v289; ap_uint<2l> v290;
        Tuple5 tmp48 = v1[v286];
        v289 = tmp48.v0; v290 = tmp48.v1;
        ap_uint<2l> v291;
        v291 = 1ul;
        bool v292;
        v292 = v290 == v291;
        bool v294;
        if (v292){
            bool v293;
            v293 = v287 < 5l;
            v294 = v293;
        } else {
            v294 = false;
        }
        int32_t v296;
        if (v294){
            v285[v287] = TupleCreate5(v289, v290);
            int32_t v295;
            v295 = v287 + 1l;
            v296 = v295;
        } else {
            v296 = v287;
        }
        v287 = v296;
        v286++;
    }
    bool v297;
    v297 = v287 == 5l;
    US1 v300;
    if (v297){
        v300 = US1_1(v285);
    } else {
        v300 = US1_0();
    }
    std::array<Tuple5,5l> v301;
    int32_t v302; int32_t v303;
    Tuple9 tmp49 = TupleCreate9(0l, 0l);
    v302 = tmp49.v0; v303 = tmp49.v1;
    while (method25(v302)){
        ap_uint<4l> v305; ap_uint<2l> v306;
        Tuple5 tmp50 = v1[v302];
        v305 = tmp50.v0; v306 = tmp50.v1;
        ap_uint<2l> v307;
        v307 = 0ul;
        bool v308;
        v308 = v306 == v307;
        bool v310;
        if (v308){
            bool v309;
            v309 = v303 < 5l;
            v310 = v309;
        } else {
            v310 = false;
        }
        int32_t v312;
        if (v310){
            v301[v303] = TupleCreate5(v305, v306);
            int32_t v311;
            v311 = v303 + 1l;
            v312 = v311;
        } else {
            v312 = v303;
        }
        v303 = v312;
        v302++;
    }
    bool v313;
    v313 = v303 == 5l;
    US1 v316;
    if (v313){
        v316 = US1_1(v301);
    } else {
        v316 = US1_0();
    }
    US1 v341;
    switch (v316.tag) {
        case 0: { // None
            v341 = v300;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v317 = v316.v.case1.v0;
            switch (v300.tag) {
                case 0: { // None
                    v341 = v316;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v318 = v300.v.case1.v0;
                    US4 v319;
                    v319 = US4_0();
                    int32_t v320; US4 v321;
                    Tuple10 tmp51 = TupleCreate10(0l, v319);
                    v320 = tmp51.v0; v321 = tmp51.v1;
                    while (method25(v320)){
                        ap_uint<4l> v323; ap_uint<2l> v324;
                        Tuple5 tmp52 = v317[v320];
                        v323 = tmp52.v0; v324 = tmp52.v1;
                        ap_uint<4l> v325; ap_uint<2l> v326;
                        Tuple5 tmp53 = v318[v320];
                        v325 = tmp53.v0; v326 = tmp53.v1;
                        US4 v334;
                        switch (v321.tag) {
                            case 0: { // Eq
                                bool v327;
                                v327 = v323 > v325;
                                if (v327){
                                    v334 = US4_1();
                                } else {
                                    bool v329;
                                    v329 = v323 < v325;
                                    if (v329){
                                        v334 = US4_2();
                                    } else {
                                        v334 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v334 = v321;
                            }
                        }
                        v321 = v334;
                        v320++;
                    }
                    bool v335;
                    switch (v321.tag) {
                        case 1: { // Gt
                            v335 = true;
                            break;
                        }
                        default: {
                            v335 = false;
                        }
                    }
                    std::array<Tuple5,5l> v336;
                    if (v335){
                        v336 = v317;
                    } else {
                        v336 = v318;
                    }
                    v341 = US1_1(v336);
                }
            }
        }
    }
    US1 v366;
    switch (v341.tag) {
        case 0: { // None
            v366 = v284;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v342 = v341.v.case1.v0;
            switch (v284.tag) {
                case 0: { // None
                    v366 = v341;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v343 = v284.v.case1.v0;
                    US4 v344;
                    v344 = US4_0();
                    int32_t v345; US4 v346;
                    Tuple10 tmp54 = TupleCreate10(0l, v344);
                    v345 = tmp54.v0; v346 = tmp54.v1;
                    while (method25(v345)){
                        ap_uint<4l> v348; ap_uint<2l> v349;
                        Tuple5 tmp55 = v342[v345];
                        v348 = tmp55.v0; v349 = tmp55.v1;
                        ap_uint<4l> v350; ap_uint<2l> v351;
                        Tuple5 tmp56 = v343[v345];
                        v350 = tmp56.v0; v351 = tmp56.v1;
                        US4 v359;
                        switch (v346.tag) {
                            case 0: { // Eq
                                bool v352;
                                v352 = v348 > v350;
                                if (v352){
                                    v359 = US4_1();
                                } else {
                                    bool v354;
                                    v354 = v348 < v350;
                                    if (v354){
                                        v359 = US4_2();
                                    } else {
                                        v359 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v359 = v346;
                            }
                        }
                        v346 = v359;
                        v345++;
                    }
                    bool v360;
                    switch (v346.tag) {
                        case 1: { // Gt
                            v360 = true;
                            break;
                        }
                        default: {
                            v360 = false;
                        }
                    }
                    std::array<Tuple5,5l> v361;
                    if (v360){
                        v361 = v342;
                    } else {
                        v361 = v343;
                    }
                    v366 = US1_1(v361);
                }
            }
        }
    }
    US1 v391;
    switch (v366.tag) {
        case 0: { // None
            v391 = v268;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v367 = v366.v.case1.v0;
            switch (v268.tag) {
                case 0: { // None
                    v391 = v366;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v368 = v268.v.case1.v0;
                    US4 v369;
                    v369 = US4_0();
                    int32_t v370; US4 v371;
                    Tuple10 tmp57 = TupleCreate10(0l, v369);
                    v370 = tmp57.v0; v371 = tmp57.v1;
                    while (method25(v370)){
                        ap_uint<4l> v373; ap_uint<2l> v374;
                        Tuple5 tmp58 = v367[v370];
                        v373 = tmp58.v0; v374 = tmp58.v1;
                        ap_uint<4l> v375; ap_uint<2l> v376;
                        Tuple5 tmp59 = v368[v370];
                        v375 = tmp59.v0; v376 = tmp59.v1;
                        US4 v384;
                        switch (v371.tag) {
                            case 0: { // Eq
                                bool v377;
                                v377 = v373 > v375;
                                if (v377){
                                    v384 = US4_1();
                                } else {
                                    bool v379;
                                    v379 = v373 < v375;
                                    if (v379){
                                        v384 = US4_2();
                                    } else {
                                        v384 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v384 = v371;
                            }
                        }
                        v371 = v384;
                        v370++;
                    }
                    bool v385;
                    switch (v371.tag) {
                        case 1: { // Gt
                            v385 = true;
                            break;
                        }
                        default: {
                            v385 = false;
                        }
                    }
                    std::array<Tuple5,5l> v386;
                    if (v385){
                        v386 = v367;
                    } else {
                        v386 = v368;
                    }
                    v391 = US1_1(v386);
                }
            }
        }
    }
    std::array<Tuple5,3l> v392;
    std::array<Tuple5,2l> v393;
    ap_uint<4l> v394;
    v394 = 12ul;
    int32_t v395; int32_t v396; int32_t v397; ap_uint<4l> v398;
    Tuple7 tmp60 = TupleCreate7(0l, 0l, 0l, v394);
    v395 = tmp60.v0; v396 = tmp60.v1; v397 = tmp60.v2; v398 = tmp60.v3;
    while (method25(v395)){
        ap_uint<4l> v400; ap_uint<2l> v401;
        Tuple5 tmp61 = v1[v395];
        v400 = tmp61.v0; v401 = tmp61.v1;
        bool v402;
        v402 = v397 < 3l;
        int32_t v406; int32_t v407; ap_uint<4l> v408;
        if (v402){
            bool v403;
            v403 = v398 == v400;
            int32_t v404;
            if (v403){
                v404 = v397;
            } else {
                v404 = 0l;
            }
            v392[v404] = TupleCreate5(v400, v401);
            int32_t v405;
            v405 = v404 + 1l;
            v406 = v395; v407 = v405; v408 = v400;
        } else {
            v406 = v396; v407 = v397; v408 = v398;
        }
        v396 = v406;
        v397 = v407;
        v398 = v408;
        v395++;
    }
    bool v409;
    v409 = v397 == 3l;
    US3 v423;
    if (v409){
        int32_t v410;
        v410 = v396 + 1l;
        int32_t v411;
        v411 = v410 - 3l;
        int32_t v412;
        v412 = 0l;
        while (method27(v411, v412)){
            ap_uint<4l> v414; ap_uint<2l> v415;
            Tuple5 tmp62 = v1[v412];
            v414 = tmp62.v0; v415 = tmp62.v1;
            v393[v412] = TupleCreate5(v414, v415);
            v412++;
        }
        int32_t v416;
        v416 = v411;
        while (method29(v416)){
            int32_t v418;
            v418 = 3l + v416;
            ap_uint<4l> v419; ap_uint<2l> v420;
            Tuple5 tmp63 = v1[v418];
            v419 = tmp63.v0; v420 = tmp63.v1;
            v393[v416] = TupleCreate5(v419, v420);
            v416++;
        }
        v423 = US3_1(v392, v393);
    } else {
        v423 = US3_0();
    }
    US1 v477;
    switch (v423.tag) {
        case 0: { // None
            v477 = US1_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,3l> v424 = v423.v.case1.v0; std::array<Tuple5,2l> v425 = v423.v.case1.v1;
            std::array<Tuple5,2l> v426;
            std::array<Tuple5,0l> v427;
            ap_uint<4l> v428;
            v428 = 12ul;
            int32_t v429; int32_t v430; int32_t v431; ap_uint<4l> v432;
            Tuple7 tmp64 = TupleCreate7(0l, 0l, 0l, v428);
            v429 = tmp64.v0; v430 = tmp64.v1; v431 = tmp64.v2; v432 = tmp64.v3;
            while (method29(v429)){
                ap_uint<4l> v434; ap_uint<2l> v435;
                Tuple5 tmp65 = v425[v429];
                v434 = tmp65.v0; v435 = tmp65.v1;
                bool v436;
                v436 = v431 < 2l;
                int32_t v440; int32_t v441; ap_uint<4l> v442;
                if (v436){
                    bool v437;
                    v437 = v432 == v434;
                    int32_t v438;
                    if (v437){
                        v438 = v431;
                    } else {
                        v438 = 0l;
                    }
                    v426[v438] = TupleCreate5(v434, v435);
                    int32_t v439;
                    v439 = v438 + 1l;
                    v440 = v429; v441 = v439; v442 = v434;
                } else {
                    v440 = v430; v441 = v431; v442 = v432;
                }
                v430 = v440;
                v431 = v441;
                v432 = v442;
                v429++;
            }
            bool v443;
            v443 = v431 == 2l;
            US5 v457;
            if (v443){
                int32_t v444;
                v444 = v430 + 1l;
                int32_t v445;
                v445 = v444 - 2l;
                int32_t v446;
                v446 = 0l;
                while (method27(v445, v446)){
                    ap_uint<4l> v448; ap_uint<2l> v449;
                    Tuple5 tmp66 = v425[v446];
                    v448 = tmp66.v0; v449 = tmp66.v1;
                    v427[v446] = TupleCreate5(v448, v449);
                    v446++;
                }
                int32_t v450;
                v450 = v445;
                while (method31(v450)){
                    int32_t v452;
                    v452 = 2l + v450;
                    ap_uint<4l> v453; ap_uint<2l> v454;
                    Tuple5 tmp67 = v425[v452];
                    v453 = tmp67.v0; v454 = tmp67.v1;
                    v427[v450] = TupleCreate5(v453, v454);
                    v450++;
                }
                v457 = US5_1(v426, v427);
            } else {
                v457 = US5_0();
            }
            switch (v457.tag) {
                case 0: { // None
                    v477 = US1_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple5,2l> v458 = v457.v.case1.v0; std::array<Tuple5,0l> v459 = v457.v.case1.v1;
                    std::array<Tuple5,0l> v460;
                    std::array<Tuple5,5l> v461;
                    int32_t v462;
                    v462 = 0l;
                    while (method28(v462)){
                        ap_uint<4l> v464; ap_uint<2l> v465;
                        Tuple5 tmp68 = v424[v462];
                        v464 = tmp68.v0; v465 = tmp68.v1;
                        v461[v462] = TupleCreate5(v464, v465);
                        v462++;
                    }
                    int32_t v466;
                    v466 = 0l;
                    while (method29(v466)){
                        ap_uint<4l> v468; ap_uint<2l> v469;
                        Tuple5 tmp69 = v458[v466];
                        v468 = tmp69.v0; v469 = tmp69.v1;
                        int32_t v470;
                        v470 = 3l + v466;
                        v461[v470] = TupleCreate5(v468, v469);
                        v466++;
                    }
                    v477 = US1_1(v461);
                }
            }
        }
    }
    std::array<Tuple5,4l> v478;
    std::array<Tuple5,1l> v479;
    ap_uint<4l> v480;
    v480 = 12ul;
    int32_t v481; int32_t v482; int32_t v483; ap_uint<4l> v484;
    Tuple7 tmp70 = TupleCreate7(0l, 0l, 0l, v480);
    v481 = tmp70.v0; v482 = tmp70.v1; v483 = tmp70.v2; v484 = tmp70.v3;
    while (method25(v481)){
        ap_uint<4l> v486; ap_uint<2l> v487;
        Tuple5 tmp71 = v1[v481];
        v486 = tmp71.v0; v487 = tmp71.v1;
        bool v488;
        v488 = v483 < 4l;
        int32_t v492; int32_t v493; ap_uint<4l> v494;
        if (v488){
            bool v489;
            v489 = v484 == v486;
            int32_t v490;
            if (v489){
                v490 = v483;
            } else {
                v490 = 0l;
            }
            v478[v490] = TupleCreate5(v486, v487);
            int32_t v491;
            v491 = v490 + 1l;
            v492 = v481; v493 = v491; v494 = v486;
        } else {
            v492 = v482; v493 = v483; v494 = v484;
        }
        v482 = v492;
        v483 = v493;
        v484 = v494;
        v481++;
    }
    bool v495;
    v495 = v483 == 4l;
    US6 v509;
    if (v495){
        int32_t v496;
        v496 = v482 + 1l;
        int32_t v497;
        v497 = v496 - 4l;
        int32_t v498;
        v498 = 0l;
        while (method27(v497, v498)){
            ap_uint<4l> v500; ap_uint<2l> v501;
            Tuple5 tmp72 = v1[v498];
            v500 = tmp72.v0; v501 = tmp72.v1;
            v479[v498] = TupleCreate5(v500, v501);
            v498++;
        }
        int32_t v502;
        v502 = v497;
        while (method30(v502)){
            int32_t v504;
            v504 = 4l + v502;
            ap_uint<4l> v505; ap_uint<2l> v506;
            Tuple5 tmp73 = v1[v504];
            v505 = tmp73.v0; v506 = tmp73.v1;
            v479[v502] = TupleCreate5(v505, v506);
            v502++;
        }
        v509 = US6_1(v478, v479);
    } else {
        v509 = US6_0();
    }
    US1 v531;
    switch (v509.tag) {
        case 0: { // None
            v531 = US1_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,4l> v510 = v509.v.case1.v0; std::array<Tuple5,1l> v511 = v509.v.case1.v1;
            std::array<Tuple5,1l> v512;
            int32_t v513;
            v513 = 0l;
            while (method30(v513)){
                ap_uint<4l> v515; ap_uint<2l> v516;
                Tuple5 tmp74 = v511[v513];
                v515 = tmp74.v0; v516 = tmp74.v1;
                v512[v513] = TupleCreate5(v515, v516);
                v513++;
            }
            std::array<Tuple5,0l> v517;
            std::array<Tuple5,5l> v518;
            int32_t v519;
            v519 = 0l;
            while (method32(v519)){
                ap_uint<4l> v521; ap_uint<2l> v522;
                Tuple5 tmp75 = v510[v519];
                v521 = tmp75.v0; v522 = tmp75.v1;
                v518[v519] = TupleCreate5(v521, v522);
                v519++;
            }
            int32_t v523;
            v523 = 0l;
            while (method30(v523)){
                ap_uint<4l> v525; ap_uint<2l> v526;
                Tuple5 tmp76 = v512[v523];
                v525 = tmp76.v0; v526 = tmp76.v1;
                int32_t v527;
                v527 = 4l + v523;
                v518[v527] = TupleCreate5(v525, v526);
                v523++;
            }
            v531 = US1_1(v518);
        }
    }
    ap_uint<2l> v532;
    v532 = 3ul;
    std::array<Tuple5,5l> v533;
    ap_uint<4l> v534;
    v534 = 12ul;
    int32_t v535; int32_t v536; ap_uint<4l> v537;
    Tuple8 tmp77 = TupleCreate8(0l, 0l, v534);
    v535 = tmp77.v0; v536 = tmp77.v1; v537 = tmp77.v2;
    while (method25(v535)){
        ap_uint<4l> v539; ap_uint<2l> v540;
        Tuple5 tmp78 = v1[v535];
        v539 = tmp78.v0; v540 = tmp78.v1;
        bool v541;
        v541 = v536 < 5l;
        bool v543;
        if (v541){
            bool v542;
            v542 = v532 == v540;
            v543 = v542;
        } else {
            v543 = false;
        }
        int32_t v549; ap_uint<4l> v550;
        if (v543){
            bool v544;
            v544 = v537 == v539;
            int32_t v545;
            if (v544){
                v545 = v536;
            } else {
                v545 = 0l;
            }
            v533[v545] = TupleCreate5(v539, v540);
            int32_t v546;
            v546 = v545 + 1l;
            ap_uint<4l> v547;
            v547 = 1ul;
            ap_uint<4l> v548;
            v548 = v539 - v547;
            v549 = v546; v550 = v548;
        } else {
            v549 = v536; v550 = v537;
        }
        v536 = v549;
        v537 = v550;
        v535++;
    }
    bool v551;
    v551 = v536 == 4l;
    bool v588;
    if (v551){
        ap_uint<4l> v552;
        v552 = 0ul;
        ap_uint<4l> v553;
        v553 = 1ul;
        ap_uint<4l> v554;
        v554 = v552 - v553;
        bool v555;
        v555 = v537 == v554;
        if (v555){
            ap_uint<4l> v556; ap_uint<2l> v557;
            Tuple5 tmp79 = v1[0l];
            v556 = tmp79.v0; v557 = tmp79.v1;
            bool v558;
            v558 = v532 == v557;
            bool v562;
            if (v558){
                ap_uint<4l> v559;
                v559 = 12ul;
                bool v560;
                v560 = v556 == v559;
                if (v560){
                    v533[4l] = TupleCreate5(v556, v557);
                    v562 = true;
                } else {
                    v562 = false;
                }
            } else {
                v562 = false;
            }
            if (v562){
                v588 = true;
            } else {
                ap_uint<4l> v563; ap_uint<2l> v564;
                Tuple5 tmp80 = v1[1l];
                v563 = tmp80.v0; v564 = tmp80.v1;
                bool v565;
                v565 = v532 == v564;
                bool v569;
                if (v565){
                    ap_uint<4l> v566;
                    v566 = 12ul;
                    bool v567;
                    v567 = v563 == v566;
                    if (v567){
                        v533[4l] = TupleCreate5(v563, v564);
                        v569 = true;
                    } else {
                        v569 = false;
                    }
                } else {
                    v569 = false;
                }
                if (v569){
                    v588 = true;
                } else {
                    ap_uint<4l> v570; ap_uint<2l> v571;
                    Tuple5 tmp81 = v1[2l];
                    v570 = tmp81.v0; v571 = tmp81.v1;
                    bool v572;
                    v572 = v532 == v571;
                    bool v576;
                    if (v572){
                        ap_uint<4l> v573;
                        v573 = 12ul;
                        bool v574;
                        v574 = v570 == v573;
                        if (v574){
                            v533[4l] = TupleCreate5(v570, v571);
                            v576 = true;
                        } else {
                            v576 = false;
                        }
                    } else {
                        v576 = false;
                    }
                    if (v576){
                        v588 = true;
                    } else {
                        ap_uint<4l> v577; ap_uint<2l> v578;
                        Tuple5 tmp82 = v1[3l];
                        v577 = tmp82.v0; v578 = tmp82.v1;
                        bool v579;
                        v579 = v532 == v578;
                        if (v579){
                            ap_uint<4l> v580;
                            v580 = 12ul;
                            bool v581;
                            v581 = v577 == v580;
                            if (v581){
                                v533[4l] = TupleCreate5(v577, v578);
                                v588 = true;
                            } else {
                                v588 = false;
                            }
                        } else {
                            v588 = false;
                        }
                    }
                }
            }
        } else {
            v588 = false;
        }
    } else {
        v588 = false;
    }
    US1 v594;
    if (v588){
        v594 = US1_1(v533);
    } else {
        bool v590;
        v590 = v536 == 5l;
        if (v590){
            v594 = US1_1(v533);
        } else {
            v594 = US1_0();
        }
    }
    ap_uint<2l> v595;
    v595 = 2ul;
    std::array<Tuple5,5l> v596;
    ap_uint<4l> v597;
    v597 = 12ul;
    int32_t v598; int32_t v599; ap_uint<4l> v600;
    Tuple8 tmp83 = TupleCreate8(0l, 0l, v597);
    v598 = tmp83.v0; v599 = tmp83.v1; v600 = tmp83.v2;
    while (method25(v598)){
        ap_uint<4l> v602; ap_uint<2l> v603;
        Tuple5 tmp84 = v1[v598];
        v602 = tmp84.v0; v603 = tmp84.v1;
        bool v604;
        v604 = v599 < 5l;
        bool v606;
        if (v604){
            bool v605;
            v605 = v595 == v603;
            v606 = v605;
        } else {
            v606 = false;
        }
        int32_t v612; ap_uint<4l> v613;
        if (v606){
            bool v607;
            v607 = v600 == v602;
            int32_t v608;
            if (v607){
                v608 = v599;
            } else {
                v608 = 0l;
            }
            v596[v608] = TupleCreate5(v602, v603);
            int32_t v609;
            v609 = v608 + 1l;
            ap_uint<4l> v610;
            v610 = 1ul;
            ap_uint<4l> v611;
            v611 = v602 - v610;
            v612 = v609; v613 = v611;
        } else {
            v612 = v599; v613 = v600;
        }
        v599 = v612;
        v600 = v613;
        v598++;
    }
    bool v614;
    v614 = v599 == 4l;
    bool v651;
    if (v614){
        ap_uint<4l> v615;
        v615 = 0ul;
        ap_uint<4l> v616;
        v616 = 1ul;
        ap_uint<4l> v617;
        v617 = v615 - v616;
        bool v618;
        v618 = v600 == v617;
        if (v618){
            ap_uint<4l> v619; ap_uint<2l> v620;
            Tuple5 tmp85 = v1[0l];
            v619 = tmp85.v0; v620 = tmp85.v1;
            bool v621;
            v621 = v595 == v620;
            bool v625;
            if (v621){
                ap_uint<4l> v622;
                v622 = 12ul;
                bool v623;
                v623 = v619 == v622;
                if (v623){
                    v596[4l] = TupleCreate5(v619, v620);
                    v625 = true;
                } else {
                    v625 = false;
                }
            } else {
                v625 = false;
            }
            if (v625){
                v651 = true;
            } else {
                ap_uint<4l> v626; ap_uint<2l> v627;
                Tuple5 tmp86 = v1[1l];
                v626 = tmp86.v0; v627 = tmp86.v1;
                bool v628;
                v628 = v595 == v627;
                bool v632;
                if (v628){
                    ap_uint<4l> v629;
                    v629 = 12ul;
                    bool v630;
                    v630 = v626 == v629;
                    if (v630){
                        v596[4l] = TupleCreate5(v626, v627);
                        v632 = true;
                    } else {
                        v632 = false;
                    }
                } else {
                    v632 = false;
                }
                if (v632){
                    v651 = true;
                } else {
                    ap_uint<4l> v633; ap_uint<2l> v634;
                    Tuple5 tmp87 = v1[2l];
                    v633 = tmp87.v0; v634 = tmp87.v1;
                    bool v635;
                    v635 = v595 == v634;
                    bool v639;
                    if (v635){
                        ap_uint<4l> v636;
                        v636 = 12ul;
                        bool v637;
                        v637 = v633 == v636;
                        if (v637){
                            v596[4l] = TupleCreate5(v633, v634);
                            v639 = true;
                        } else {
                            v639 = false;
                        }
                    } else {
                        v639 = false;
                    }
                    if (v639){
                        v651 = true;
                    } else {
                        ap_uint<4l> v640; ap_uint<2l> v641;
                        Tuple5 tmp88 = v1[3l];
                        v640 = tmp88.v0; v641 = tmp88.v1;
                        bool v642;
                        v642 = v595 == v641;
                        if (v642){
                            ap_uint<4l> v643;
                            v643 = 12ul;
                            bool v644;
                            v644 = v640 == v643;
                            if (v644){
                                v596[4l] = TupleCreate5(v640, v641);
                                v651 = true;
                            } else {
                                v651 = false;
                            }
                        } else {
                            v651 = false;
                        }
                    }
                }
            }
        } else {
            v651 = false;
        }
    } else {
        v651 = false;
    }
    US1 v657;
    if (v651){
        v657 = US1_1(v596);
    } else {
        bool v653;
        v653 = v599 == 5l;
        if (v653){
            v657 = US1_1(v596);
        } else {
            v657 = US1_0();
        }
    }
    ap_uint<2l> v658;
    v658 = 1ul;
    std::array<Tuple5,5l> v659;
    ap_uint<4l> v660;
    v660 = 12ul;
    int32_t v661; int32_t v662; ap_uint<4l> v663;
    Tuple8 tmp89 = TupleCreate8(0l, 0l, v660);
    v661 = tmp89.v0; v662 = tmp89.v1; v663 = tmp89.v2;
    while (method25(v661)){
        ap_uint<4l> v665; ap_uint<2l> v666;
        Tuple5 tmp90 = v1[v661];
        v665 = tmp90.v0; v666 = tmp90.v1;
        bool v667;
        v667 = v662 < 5l;
        bool v669;
        if (v667){
            bool v668;
            v668 = v658 == v666;
            v669 = v668;
        } else {
            v669 = false;
        }
        int32_t v675; ap_uint<4l> v676;
        if (v669){
            bool v670;
            v670 = v663 == v665;
            int32_t v671;
            if (v670){
                v671 = v662;
            } else {
                v671 = 0l;
            }
            v659[v671] = TupleCreate5(v665, v666);
            int32_t v672;
            v672 = v671 + 1l;
            ap_uint<4l> v673;
            v673 = 1ul;
            ap_uint<4l> v674;
            v674 = v665 - v673;
            v675 = v672; v676 = v674;
        } else {
            v675 = v662; v676 = v663;
        }
        v662 = v675;
        v663 = v676;
        v661++;
    }
    bool v677;
    v677 = v662 == 4l;
    bool v714;
    if (v677){
        ap_uint<4l> v678;
        v678 = 0ul;
        ap_uint<4l> v679;
        v679 = 1ul;
        ap_uint<4l> v680;
        v680 = v678 - v679;
        bool v681;
        v681 = v663 == v680;
        if (v681){
            ap_uint<4l> v682; ap_uint<2l> v683;
            Tuple5 tmp91 = v1[0l];
            v682 = tmp91.v0; v683 = tmp91.v1;
            bool v684;
            v684 = v658 == v683;
            bool v688;
            if (v684){
                ap_uint<4l> v685;
                v685 = 12ul;
                bool v686;
                v686 = v682 == v685;
                if (v686){
                    v659[4l] = TupleCreate5(v682, v683);
                    v688 = true;
                } else {
                    v688 = false;
                }
            } else {
                v688 = false;
            }
            if (v688){
                v714 = true;
            } else {
                ap_uint<4l> v689; ap_uint<2l> v690;
                Tuple5 tmp92 = v1[1l];
                v689 = tmp92.v0; v690 = tmp92.v1;
                bool v691;
                v691 = v658 == v690;
                bool v695;
                if (v691){
                    ap_uint<4l> v692;
                    v692 = 12ul;
                    bool v693;
                    v693 = v689 == v692;
                    if (v693){
                        v659[4l] = TupleCreate5(v689, v690);
                        v695 = true;
                    } else {
                        v695 = false;
                    }
                } else {
                    v695 = false;
                }
                if (v695){
                    v714 = true;
                } else {
                    ap_uint<4l> v696; ap_uint<2l> v697;
                    Tuple5 tmp93 = v1[2l];
                    v696 = tmp93.v0; v697 = tmp93.v1;
                    bool v698;
                    v698 = v658 == v697;
                    bool v702;
                    if (v698){
                        ap_uint<4l> v699;
                        v699 = 12ul;
                        bool v700;
                        v700 = v696 == v699;
                        if (v700){
                            v659[4l] = TupleCreate5(v696, v697);
                            v702 = true;
                        } else {
                            v702 = false;
                        }
                    } else {
                        v702 = false;
                    }
                    if (v702){
                        v714 = true;
                    } else {
                        ap_uint<4l> v703; ap_uint<2l> v704;
                        Tuple5 tmp94 = v1[3l];
                        v703 = tmp94.v0; v704 = tmp94.v1;
                        bool v705;
                        v705 = v658 == v704;
                        if (v705){
                            ap_uint<4l> v706;
                            v706 = 12ul;
                            bool v707;
                            v707 = v703 == v706;
                            if (v707){
                                v659[4l] = TupleCreate5(v703, v704);
                                v714 = true;
                            } else {
                                v714 = false;
                            }
                        } else {
                            v714 = false;
                        }
                    }
                }
            }
        } else {
            v714 = false;
        }
    } else {
        v714 = false;
    }
    US1 v720;
    if (v714){
        v720 = US1_1(v659);
    } else {
        bool v716;
        v716 = v662 == 5l;
        if (v716){
            v720 = US1_1(v659);
        } else {
            v720 = US1_0();
        }
    }
    ap_uint<2l> v721;
    v721 = 0ul;
    std::array<Tuple5,5l> v722;
    ap_uint<4l> v723;
    v723 = 12ul;
    int32_t v724; int32_t v725; ap_uint<4l> v726;
    Tuple8 tmp95 = TupleCreate8(0l, 0l, v723);
    v724 = tmp95.v0; v725 = tmp95.v1; v726 = tmp95.v2;
    while (method25(v724)){
        ap_uint<4l> v728; ap_uint<2l> v729;
        Tuple5 tmp96 = v1[v724];
        v728 = tmp96.v0; v729 = tmp96.v1;
        bool v730;
        v730 = v725 < 5l;
        bool v732;
        if (v730){
            bool v731;
            v731 = v721 == v729;
            v732 = v731;
        } else {
            v732 = false;
        }
        int32_t v738; ap_uint<4l> v739;
        if (v732){
            bool v733;
            v733 = v726 == v728;
            int32_t v734;
            if (v733){
                v734 = v725;
            } else {
                v734 = 0l;
            }
            v722[v734] = TupleCreate5(v728, v729);
            int32_t v735;
            v735 = v734 + 1l;
            ap_uint<4l> v736;
            v736 = 1ul;
            ap_uint<4l> v737;
            v737 = v728 - v736;
            v738 = v735; v739 = v737;
        } else {
            v738 = v725; v739 = v726;
        }
        v725 = v738;
        v726 = v739;
        v724++;
    }
    bool v740;
    v740 = v725 == 4l;
    bool v777;
    if (v740){
        ap_uint<4l> v741;
        v741 = 0ul;
        ap_uint<4l> v742;
        v742 = 1ul;
        ap_uint<4l> v743;
        v743 = v741 - v742;
        bool v744;
        v744 = v726 == v743;
        if (v744){
            ap_uint<4l> v745; ap_uint<2l> v746;
            Tuple5 tmp97 = v1[0l];
            v745 = tmp97.v0; v746 = tmp97.v1;
            bool v747;
            v747 = v721 == v746;
            bool v751;
            if (v747){
                ap_uint<4l> v748;
                v748 = 12ul;
                bool v749;
                v749 = v745 == v748;
                if (v749){
                    v722[4l] = TupleCreate5(v745, v746);
                    v751 = true;
                } else {
                    v751 = false;
                }
            } else {
                v751 = false;
            }
            if (v751){
                v777 = true;
            } else {
                ap_uint<4l> v752; ap_uint<2l> v753;
                Tuple5 tmp98 = v1[1l];
                v752 = tmp98.v0; v753 = tmp98.v1;
                bool v754;
                v754 = v721 == v753;
                bool v758;
                if (v754){
                    ap_uint<4l> v755;
                    v755 = 12ul;
                    bool v756;
                    v756 = v752 == v755;
                    if (v756){
                        v722[4l] = TupleCreate5(v752, v753);
                        v758 = true;
                    } else {
                        v758 = false;
                    }
                } else {
                    v758 = false;
                }
                if (v758){
                    v777 = true;
                } else {
                    ap_uint<4l> v759; ap_uint<2l> v760;
                    Tuple5 tmp99 = v1[2l];
                    v759 = tmp99.v0; v760 = tmp99.v1;
                    bool v761;
                    v761 = v721 == v760;
                    bool v765;
                    if (v761){
                        ap_uint<4l> v762;
                        v762 = 12ul;
                        bool v763;
                        v763 = v759 == v762;
                        if (v763){
                            v722[4l] = TupleCreate5(v759, v760);
                            v765 = true;
                        } else {
                            v765 = false;
                        }
                    } else {
                        v765 = false;
                    }
                    if (v765){
                        v777 = true;
                    } else {
                        ap_uint<4l> v766; ap_uint<2l> v767;
                        Tuple5 tmp100 = v1[3l];
                        v766 = tmp100.v0; v767 = tmp100.v1;
                        bool v768;
                        v768 = v721 == v767;
                        if (v768){
                            ap_uint<4l> v769;
                            v769 = 12ul;
                            bool v770;
                            v770 = v766 == v769;
                            if (v770){
                                v722[4l] = TupleCreate5(v766, v767);
                                v777 = true;
                            } else {
                                v777 = false;
                            }
                        } else {
                            v777 = false;
                        }
                    }
                }
            }
        } else {
            v777 = false;
        }
    } else {
        v777 = false;
    }
    US1 v783;
    if (v777){
        v783 = US1_1(v722);
    } else {
        bool v779;
        v779 = v725 == 5l;
        if (v779){
            v783 = US1_1(v722);
        } else {
            v783 = US1_0();
        }
    }
    US1 v808;
    switch (v783.tag) {
        case 0: { // None
            v808 = v720;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v784 = v783.v.case1.v0;
            switch (v720.tag) {
                case 0: { // None
                    v808 = v783;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v785 = v720.v.case1.v0;
                    US4 v786;
                    v786 = US4_0();
                    int32_t v787; US4 v788;
                    Tuple10 tmp101 = TupleCreate10(0l, v786);
                    v787 = tmp101.v0; v788 = tmp101.v1;
                    while (method25(v787)){
                        ap_uint<4l> v790; ap_uint<2l> v791;
                        Tuple5 tmp102 = v784[v787];
                        v790 = tmp102.v0; v791 = tmp102.v1;
                        ap_uint<4l> v792; ap_uint<2l> v793;
                        Tuple5 tmp103 = v785[v787];
                        v792 = tmp103.v0; v793 = tmp103.v1;
                        US4 v801;
                        switch (v788.tag) {
                            case 0: { // Eq
                                bool v794;
                                v794 = v790 > v792;
                                if (v794){
                                    v801 = US4_1();
                                } else {
                                    bool v796;
                                    v796 = v790 < v792;
                                    if (v796){
                                        v801 = US4_2();
                                    } else {
                                        v801 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v801 = v788;
                            }
                        }
                        v788 = v801;
                        v787++;
                    }
                    bool v802;
                    switch (v788.tag) {
                        case 1: { // Gt
                            v802 = true;
                            break;
                        }
                        default: {
                            v802 = false;
                        }
                    }
                    std::array<Tuple5,5l> v803;
                    if (v802){
                        v803 = v784;
                    } else {
                        v803 = v785;
                    }
                    v808 = US1_1(v803);
                }
            }
        }
    }
    US1 v833;
    switch (v808.tag) {
        case 0: { // None
            v833 = v657;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v809 = v808.v.case1.v0;
            switch (v657.tag) {
                case 0: { // None
                    v833 = v808;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v810 = v657.v.case1.v0;
                    US4 v811;
                    v811 = US4_0();
                    int32_t v812; US4 v813;
                    Tuple10 tmp104 = TupleCreate10(0l, v811);
                    v812 = tmp104.v0; v813 = tmp104.v1;
                    while (method25(v812)){
                        ap_uint<4l> v815; ap_uint<2l> v816;
                        Tuple5 tmp105 = v809[v812];
                        v815 = tmp105.v0; v816 = tmp105.v1;
                        ap_uint<4l> v817; ap_uint<2l> v818;
                        Tuple5 tmp106 = v810[v812];
                        v817 = tmp106.v0; v818 = tmp106.v1;
                        US4 v826;
                        switch (v813.tag) {
                            case 0: { // Eq
                                bool v819;
                                v819 = v815 > v817;
                                if (v819){
                                    v826 = US4_1();
                                } else {
                                    bool v821;
                                    v821 = v815 < v817;
                                    if (v821){
                                        v826 = US4_2();
                                    } else {
                                        v826 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v826 = v813;
                            }
                        }
                        v813 = v826;
                        v812++;
                    }
                    bool v827;
                    switch (v813.tag) {
                        case 1: { // Gt
                            v827 = true;
                            break;
                        }
                        default: {
                            v827 = false;
                        }
                    }
                    std::array<Tuple5,5l> v828;
                    if (v827){
                        v828 = v809;
                    } else {
                        v828 = v810;
                    }
                    v833 = US1_1(v828);
                }
            }
        }
    }
    US1 v858;
    switch (v833.tag) {
        case 0: { // None
            v858 = v594;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v834 = v833.v.case1.v0;
            switch (v594.tag) {
                case 0: { // None
                    v858 = v833;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v835 = v594.v.case1.v0;
                    US4 v836;
                    v836 = US4_0();
                    int32_t v837; US4 v838;
                    Tuple10 tmp107 = TupleCreate10(0l, v836);
                    v837 = tmp107.v0; v838 = tmp107.v1;
                    while (method25(v837)){
                        ap_uint<4l> v840; ap_uint<2l> v841;
                        Tuple5 tmp108 = v834[v837];
                        v840 = tmp108.v0; v841 = tmp108.v1;
                        ap_uint<4l> v842; ap_uint<2l> v843;
                        Tuple5 tmp109 = v835[v837];
                        v842 = tmp109.v0; v843 = tmp109.v1;
                        US4 v851;
                        switch (v838.tag) {
                            case 0: { // Eq
                                bool v844;
                                v844 = v840 > v842;
                                if (v844){
                                    v851 = US4_1();
                                } else {
                                    bool v846;
                                    v846 = v840 < v842;
                                    if (v846){
                                        v851 = US4_2();
                                    } else {
                                        v851 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                v851 = v838;
                            }
                        }
                        v838 = v851;
                        v837++;
                    }
                    bool v852;
                    switch (v838.tag) {
                        case 1: { // Gt
                            v852 = true;
                            break;
                        }
                        default: {
                            v852 = false;
                        }
                    }
                    std::array<Tuple5,5l> v853;
                    if (v852){
                        v853 = v834;
                    } else {
                        v853 = v835;
                    }
                    v858 = US1_1(v853);
                }
            }
        }
    }
    ap_uint<4l> v859;
    v859 = 1ul;
    US7 v864;
    switch (v64.tag) {
        case 0: { // None
            v864 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v860 = v64.v.case1.v0;
            v864 = US7_1(v860, v859);
        }
    }
    ap_uint<4l> v865;
    v865 = 2ul;
    US7 v870;
    switch (v159.tag) {
        case 0: { // None
            v870 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v866 = v159.v.case1.v0;
            v870 = US7_1(v866, v865);
        }
    }
    ap_uint<4l> v871;
    v871 = 3ul;
    US7 v876;
    switch (v213.tag) {
        case 0: { // None
            v876 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v872 = v213.v.case1.v0;
            v876 = US7_1(v872, v871);
        }
    }
    ap_uint<4l> v877;
    v877 = 4ul;
    US7 v882;
    switch (v252.tag) {
        case 0: { // None
            v882 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v878 = v252.v.case1.v0;
            v882 = US7_1(v878, v877);
        }
    }
    ap_uint<4l> v883;
    v883 = 5ul;
    US7 v888;
    switch (v391.tag) {
        case 0: { // None
            v888 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v884 = v391.v.case1.v0;
            v888 = US7_1(v884, v883);
        }
    }
    ap_uint<4l> v889;
    v889 = 6ul;
    US7 v894;
    switch (v477.tag) {
        case 0: { // None
            v894 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v890 = v477.v.case1.v0;
            v894 = US7_1(v890, v889);
        }
    }
    ap_uint<4l> v895;
    v895 = 7ul;
    US7 v900;
    switch (v531.tag) {
        case 0: { // None
            v900 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v896 = v531.v.case1.v0;
            v900 = US7_1(v896, v895);
        }
    }
    ap_uint<4l> v901;
    v901 = 8ul;
    US7 v906;
    switch (v858.tag) {
        case 0: { // None
            v906 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v902 = v858.v.case1.v0;
            v906 = US7_1(v902, v901);
        }
    }
    US7 v908;
    switch (v906.tag) {
        case 0: { // None
            v908 = US7_0();
            break;
        }
        default: {
            v908 = v906;
        }
    }
    US7 v918;
    switch (v908.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v909 = v908.v.case1.v0; ap_uint<4l> v910 = v908.v.case1.v1;
            switch (v900.tag) {
                case 0: { // None
                    v918 = v908;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v911 = v900.v.case1.v0; ap_uint<4l> v912 = v900.v.case1.v1;
                    v918 = US7_1(v909, v910);
                }
            }
            break;
        }
        default: {
            switch (v900.tag) {
                case 0: { // None
                    v918 = v908;
                    break;
                }
                default: {
                    switch (v908.tag) {
                        default: { // None
                            v918 = v900;
                        }
                    }
                }
            }
        }
    }
    US7 v928;
    switch (v918.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v919 = v918.v.case1.v0; ap_uint<4l> v920 = v918.v.case1.v1;
            switch (v894.tag) {
                case 0: { // None
                    v928 = v918;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v921 = v894.v.case1.v0; ap_uint<4l> v922 = v894.v.case1.v1;
                    v928 = US7_1(v919, v920);
                }
            }
            break;
        }
        default: {
            switch (v894.tag) {
                case 0: { // None
                    v928 = v918;
                    break;
                }
                default: {
                    switch (v918.tag) {
                        default: { // None
                            v928 = v894;
                        }
                    }
                }
            }
        }
    }
    US7 v938;
    switch (v928.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v929 = v928.v.case1.v0; ap_uint<4l> v930 = v928.v.case1.v1;
            switch (v888.tag) {
                case 0: { // None
                    v938 = v928;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v931 = v888.v.case1.v0; ap_uint<4l> v932 = v888.v.case1.v1;
                    v938 = US7_1(v929, v930);
                }
            }
            break;
        }
        default: {
            switch (v888.tag) {
                case 0: { // None
                    v938 = v928;
                    break;
                }
                default: {
                    switch (v928.tag) {
                        default: { // None
                            v938 = v888;
                        }
                    }
                }
            }
        }
    }
    US7 v948;
    switch (v938.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v939 = v938.v.case1.v0; ap_uint<4l> v940 = v938.v.case1.v1;
            switch (v882.tag) {
                case 0: { // None
                    v948 = v938;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v941 = v882.v.case1.v0; ap_uint<4l> v942 = v882.v.case1.v1;
                    v948 = US7_1(v939, v940);
                }
            }
            break;
        }
        default: {
            switch (v882.tag) {
                case 0: { // None
                    v948 = v938;
                    break;
                }
                default: {
                    switch (v938.tag) {
                        default: { // None
                            v948 = v882;
                        }
                    }
                }
            }
        }
    }
    US7 v958;
    switch (v948.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v949 = v948.v.case1.v0; ap_uint<4l> v950 = v948.v.case1.v1;
            switch (v876.tag) {
                case 0: { // None
                    v958 = v948;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v951 = v876.v.case1.v0; ap_uint<4l> v952 = v876.v.case1.v1;
                    v958 = US7_1(v949, v950);
                }
            }
            break;
        }
        default: {
            switch (v876.tag) {
                case 0: { // None
                    v958 = v948;
                    break;
                }
                default: {
                    switch (v948.tag) {
                        default: { // None
                            v958 = v876;
                        }
                    }
                }
            }
        }
    }
    US7 v968;
    switch (v958.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v959 = v958.v.case1.v0; ap_uint<4l> v960 = v958.v.case1.v1;
            switch (v870.tag) {
                case 0: { // None
                    v968 = v958;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v961 = v870.v.case1.v0; ap_uint<4l> v962 = v870.v.case1.v1;
                    v968 = US7_1(v959, v960);
                }
            }
            break;
        }
        default: {
            switch (v870.tag) {
                case 0: { // None
                    v968 = v958;
                    break;
                }
                default: {
                    switch (v958.tag) {
                        default: { // None
                            v968 = v870;
                        }
                    }
                }
            }
        }
    }
    US7 v978;
    switch (v968.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v969 = v968.v.case1.v0; ap_uint<4l> v970 = v968.v.case1.v1;
            switch (v864.tag) {
                case 0: { // None
                    v978 = v968;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v971 = v864.v.case1.v0; ap_uint<4l> v972 = v864.v.case1.v1;
                    v978 = US7_1(v969, v970);
                }
            }
            break;
        }
        default: {
            switch (v864.tag) {
                case 0: { // None
                    v978 = v968;
                    break;
                }
                default: {
                    switch (v968.tag) {
                        default: { // None
                            v978 = v864;
                        }
                    }
                }
            }
        }
    }
    switch (v978.tag) {
        case 0: { // None
            ap_uint<4l> v981;
            v981 = 0ul;
            return TupleCreate6(v6, v981);
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v979 = v978.v.case1.v0; ap_uint<4l> v980 = v978.v.case1.v1;
            return TupleCreate6(v979, v980);
        }
    }
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
        std::array<Tuple5,5l> v74;
        uint32_t v75;
        v75 = (uint32_t)v23;
        ap_uint<4l> v76;
        v76 = v75;
        uint32_t v77;
        v77 = (uint32_t)v24;
        ap_uint<2l> v78;
        v78 = v77;
        v74[0l] = TupleCreate5(v76, v78);
        uint32_t v79;
        v79 = (uint32_t)v25;
        ap_uint<4l> v80;
        v80 = v79;
        uint32_t v81;
        v81 = (uint32_t)v26;
        ap_uint<2l> v82;
        v82 = v81;
        v74[1l] = TupleCreate5(v80, v82);
        uint32_t v83;
        v83 = (uint32_t)v27;
        ap_uint<4l> v84;
        v84 = v83;
        uint32_t v85;
        v85 = (uint32_t)v28;
        ap_uint<2l> v86;
        v86 = v85;
        v74[2l] = TupleCreate5(v84, v86);
        uint32_t v87;
        v87 = (uint32_t)v29;
        ap_uint<4l> v88;
        v88 = v87;
        uint32_t v89;
        v89 = (uint32_t)v30;
        ap_uint<2l> v90;
        v90 = v89;
        v74[3l] = TupleCreate5(v88, v90);
        uint32_t v91;
        v91 = (uint32_t)v31;
        ap_uint<4l> v92;
        v92 = v91;
        uint32_t v93;
        v93 = (uint32_t)v32;
        ap_uint<2l> v94;
        v94 = v93;
        v74[4l] = TupleCreate5(v92, v94);
        std::array<Tuple5,5l> v95;
        int32_t v96;
        v96 = 0l;
        while (method25(v96)){
            ap_uint<4l> v98; ap_uint<2l> v99;
            Tuple5 tmp11 = v74[v96];
            v98 = tmp11.v0; v99 = tmp11.v1;
            v95[v96] = TupleCreate5(v98, v99);
            v96++;
        }
        Fun0 v100;
        v100 = ClosureMethod0;
        std::stable_sort(v95.begin(),v95.end(),v100);
        std::array<Tuple5,5l> v101; ap_uint<4l> v102;
        Tuple6 tmp110 = score26(v95);
        v101 = tmp110.v0; v102 = tmp110.v1;
        ap_uint<4l> v103; ap_uint<2l> v104;
        Tuple5 tmp111 = v101[0l];
        v103 = tmp111.v0; v104 = tmp111.v1;
        int8_t v105;
        v105 = v104;
        int8_t v106;
        v106 = v103;
        ap_uint<4l> v107; ap_uint<2l> v108;
        Tuple5 tmp112 = v101[1l];
        v107 = tmp112.v0; v108 = tmp112.v1;
        int8_t v109;
        v109 = v108;
        int8_t v110;
        v110 = v107;
        ap_uint<4l> v111; ap_uint<2l> v112;
        Tuple5 tmp113 = v101[2l];
        v111 = tmp113.v0; v112 = tmp113.v1;
        int8_t v113;
        v113 = v112;
        int8_t v114;
        v114 = v111;
        ap_uint<4l> v115; ap_uint<2l> v116;
        Tuple5 tmp114 = v101[3l];
        v115 = tmp114.v0; v116 = tmp114.v1;
        int8_t v117;
        v117 = v116;
        int8_t v118;
        v118 = v115;
        ap_uint<4l> v119; ap_uint<2l> v120;
        Tuple5 tmp115 = v101[4l];
        v119 = tmp115.v0; v120 = tmp115.v1;
        int8_t v121;
        v121 = v120;
        int8_t v122;
        v122 = v119;
        int8_t v123;
        v123 = v102;
        bool v124;
        v124 = v65 == v106;
        bool v126;
        if (v124){
            bool v125;
            v125 = v64 == v105;
            v126 = v125;
        } else {
            v126 = false;
        }
        bool v142;
        if (v126){
            bool v127;
            v127 = v67 == v110;
            bool v129;
            if (v127){
                bool v128;
                v128 = v66 == v109;
                v129 = v128;
            } else {
                v129 = false;
            }
            if (v129){
                bool v130;
                v130 = v69 == v114;
                bool v132;
                if (v130){
                    bool v131;
                    v131 = v68 == v113;
                    v132 = v131;
                } else {
                    v132 = false;
                }
                if (v132){
                    bool v133;
                    v133 = v71 == v118;
                    bool v135;
                    if (v133){
                        bool v134;
                        v134 = v70 == v117;
                        v135 = v134;
                    } else {
                        v135 = false;
                    }
                    if (v135){
                        bool v136;
                        v136 = v73 == v122;
                        if (v136){
                            bool v137;
                            v137 = v72 == v121;
                            v142 = v137;
                        } else {
                            v142 = false;
                        }
                    } else {
                        v142 = false;
                    }
                } else {
                    v142 = false;
                }
            } else {
                v142 = false;
            }
        } else {
            v142 = false;
        }
        bool v144;
        if (v142){
            bool v143;
            v143 = v63 == v123;
            v144 = v143;
        } else {
            v144 = false;
        }
        bool v145;
        v145 = v144 != true;
        int32_t v147;
        if (v145){
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
            std::cout << "Score: " << (int) v123 << " " ;
            std::cout << "Card: ";
            std::cout << "(" << (int) v106 << "," << (int) v105 << ") " ;
            std::cout << "(" << (int) v110 << "," << (int) v109 << ") " ;
            std::cout << "(" << (int) v114 << "," << (int) v113 << ") " ;
            std::cout << "(" << (int) v118 << "," << (int) v117 << ") " ;
            std::cout << "(" << (int) v122 << "," << (int) v121 << ") " ;
            std::cout << std::endl;
            int32_t v146;
            v146 = v4 + 1l;
            v147 = v146;
        } else {
            v147 = v4;
        }
        v4 = v147;
        v3++;
    }
    return v4;
}
