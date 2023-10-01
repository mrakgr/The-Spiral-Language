#include <cstdint>
#include <array>
#include "ap_int.h"
#include <random>
#include <iostream>
struct Tuple0;
bool while_method_0(uint64_t v0);
struct Tuple1;
bool while_method_1(int32_t v0);
struct Tuple2;
struct Tuple3;
bool while_method_2(int8_t v0);
bool while_method_3(int8_t v0);
struct Tuple4;
uint32_t loop_ranks_3(uint64_t v0, int8_t v1, int8_t v2);
uint32_t try_suit_2(uint64_t v0, uint16_t v1, int8_t v2);
uint32_t loop_5(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_suits_7(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5);
uint32_t loop_ranks_6(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_ranks_11(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t try_suit_10(uint64_t v0, uint16_t v1, int8_t v2);
uint32_t loop_suits_17(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5, uint32_t v6);
uint32_t loop_ranks_16(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5);
uint32_t loop_suits_20(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4);
uint32_t loop_ranks_19(uint64_t v0, int8_t v1, int8_t v2, uint32_t v3);
uint64_t loop_pair_18(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_pair_15(uint64_t v0, uint64_t v1, int8_t v2, uint32_t v3, int8_t v4);
uint64_t loop_pair__14(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_triple_13(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_12(uint64_t v0, uint64_t v1, int8_t v2);
uint64_t loop_pair_9(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3, uint32_t v4, int8_t v5);
uint64_t loop_triple_8(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3);
uint64_t loop_ranks_4(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3);
uint64_t score_1(uint64_t v0);
Tuple2 score__0(uint64_t v0);
struct Tuple5;
struct Tuple6;
bool while_method_4(int32_t v0);
struct Tuple7;
bool while_method_5(std::array<Tuple5,7l> v0, bool v1, int32_t v2);
bool while_method_6(std::array<Tuple5,7l> v0, int32_t v1);
struct Tuple8;
bool while_method_7(int32_t v0, int32_t v1, int32_t v2, int32_t v3);
struct US0;
bool while_method_8(int32_t v0);
struct Tuple9;
struct US1;
struct US2;
bool while_method_9(int32_t v0);
bool while_method_10(int32_t v0);
struct US3;
bool while_method_11(int32_t v0);
struct US4;
bool while_method_12(int32_t v0);
struct Tuple10;
struct Tuple11;
struct Tuple12;
struct US5;
struct US6;
struct US7;
Tuple6 score_21(std::array<Tuple5,7l> v0);
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
bool while_method_0(uint64_t v0){
#pragma HLS INLINE
    bool v1;
    v1 = v0 < 100000ull;
    return v1;
}
static inline Tuple1 TupleCreate1(int8_t v0, int8_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool while_method_1(int32_t v0){
#pragma HLS INLINE
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
bool while_method_2(int8_t v0){
#pragma HLS INLINE
    bool v1;
    v1 = v0 < 13;
    return v1;
}
bool while_method_3(int8_t v0){
#pragma HLS INLINE
    bool v1;
    v1 = v0 < 4;
    return v1;
}
static inline Tuple4 TupleCreate4(int8_t v0, uint64_t v1){
    Tuple4 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
uint32_t loop_ranks_3(uint64_t v0, int8_t v1, int8_t v2){
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
            return loop_ranks_3(v0, v1, v58);
        }
    } else {
        return 0ul;
    }
}
uint32_t try_suit_2(uint64_t v0, uint16_t v1, int8_t v2){
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
        return loop_ranks_3(v0, v2, v9);
    } else {
        return 0ul;
    }
}
uint32_t loop_5(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
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
            return loop_5(v0, v1, v15, v16, v19);
        } else {
            int8_t v21;
            v21 = v2 + 1;
            return loop_5(v0, v1, v21, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_suits_7(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5){
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
                return loop_suits_7(v0, v1, v2, v15, v16, v19);
            } else {
                int8_t v21;
                v21 = v3 + 1;
                return loop_suits_7(v0, v1, v2, v21, v4, v5);
            }
        } else {
            int8_t v24;
            v24 = v2 - 1;
            return loop_ranks_6(v0, v1, v24, v4, v5);
        }
    } else {
        return v5;
    }
}
uint32_t loop_ranks_6(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
    bool v5;
    v5 = 0 <= v2;
    if (v5){
        bool v6;
        v6 = v1 == v2;
        if (v6){
            int8_t v7;
            v7 = v2 - 1;
            return loop_ranks_6(v0, v1, v7, v3, v4);
        } else {
            int8_t v9;
            v9 = 0;
            return loop_suits_7(v0, v1, v2, v9, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_ranks_11(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
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
            return loop_ranks_11(v0, v1, v15, v16, v19);
        } else {
            int8_t v21;
            v21 = v2 - 1;
            return loop_ranks_11(v0, v1, v21, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t try_suit_10(uint64_t v0, uint16_t v1, int8_t v2){
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
        return loop_ranks_11(v0, v2, v9, v10, v11);
    } else {
        return 0ul;
    }
}
uint32_t loop_suits_17(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5, uint32_t v6){
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
                return loop_suits_17(v0, v1, v2, v3, v16, v17, v20);
            } else {
                int8_t v22;
                v22 = v4 + 1;
                return loop_suits_17(v0, v1, v2, v3, v22, v5, v6);
            }
        } else {
            int8_t v25;
            v25 = v3 - 1;
            return loop_ranks_16(v0, v1, v2, v25, v5, v6);
        }
    } else {
        return v6;
    }
}
uint32_t loop_ranks_16(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, uint32_t v5){
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
            return loop_ranks_16(v0, v1, v2, v10, v4, v5);
        } else {
            int8_t v12;
            v12 = 0;
            return loop_suits_17(v0, v1, v2, v3, v12, v4, v5);
        }
    } else {
        return v5;
    }
}
uint32_t loop_suits_20(uint64_t v0, int8_t v1, int8_t v2, int8_t v3, uint32_t v4){
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
                return loop_suits_20(v0, v1, v14, v15, v18);
            } else {
                int8_t v20;
                v20 = v2 + 1;
                return loop_suits_20(v0, v1, v20, v3, v4);
            }
        } else {
            int8_t v23;
            v23 = v1 - 1;
            return loop_ranks_19(v0, v23, v3, v4);
        }
    } else {
        return v4;
    }
}
uint32_t loop_ranks_19(uint64_t v0, int8_t v1, int8_t v2, uint32_t v3){
    bool v4;
    v4 = 0 <= v1;
    if (v4){
        int8_t v5;
        v5 = 0;
        return loop_suits_20(v0, v1, v5, v2, v3);
    } else {
        return v3;
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
            v13 = loop_5(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            int8_t v15;
            v15 = 3;
            uint32_t v16;
            v16 = loop_ranks_6(v1, v2, v14, v15, v13);
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
            return loop_pair_18(v0, v1, v21);
        }
    } else {
        int8_t v24;
        v24 = 12;
        int8_t v25;
        v25 = 5;
        uint32_t v26;
        v26 = 0ul;
        uint32_t v27;
        v27 = loop_ranks_19(v1, v24, v25, v26);
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
uint64_t loop_pair_15(uint64_t v0, uint64_t v1, int8_t v2, uint32_t v3, int8_t v4){
    bool v5;
    v5 = v2 == v4;
    if (v5){
        int8_t v6;
        v6 = v4 - 1;
        return loop_pair_15(v0, v1, v2, v3, v6);
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
                v17 = loop_5(v1, v4, v15, v16, v3);
                int8_t v18;
                v18 = 12;
                int8_t v19;
                v19 = 1;
                uint32_t v20;
                v20 = loop_ranks_16(v1, v2, v4, v18, v19, v17);
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
                return loop_pair_15(v0, v1, v2, v3, v25);
            }
        } else {
            int8_t v28;
            v28 = 12;
            return loop_pair_18(v0, v1, v28);
        }
    }
}
uint64_t loop_pair__14(uint64_t v0, uint64_t v1, int8_t v2){
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
            v13 = loop_5(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            return loop_pair_15(v0, v1, v2, v13, v14);
        } else {
            int8_t v16;
            v16 = v2 - 1;
            return loop_pair__14(v0, v1, v16);
        }
    } else {
        int8_t v19;
        v19 = 12;
        return loop_pair_18(v0, v1, v19);
    }
}
uint64_t loop_triple_13(uint64_t v0, uint64_t v1, int8_t v2){
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
            v13 = loop_5(v1, v2, v10, v11, v12);
            int8_t v14;
            v14 = 12;
            int8_t v15;
            v15 = 2;
            uint32_t v16;
            v16 = loop_ranks_6(v1, v2, v14, v15, v13);
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
            return loop_triple_13(v0, v1, v21);
        }
    } else {
        int8_t v24;
        v24 = 12;
        return loop_pair__14(v0, v1, v24);
    }
}
uint64_t loop_12(uint64_t v0, uint64_t v1, int8_t v2){
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
            v54 = loop_5(v1, v4, v51, v52, v53);
            int8_t v55;
            v55 = 0;
            int8_t v56;
            v56 = 1;
            uint32_t v57;
            v57 = loop_5(v1, v12, v55, v56, v54);
            int8_t v58;
            v58 = 0;
            int8_t v59;
            v59 = 1;
            uint32_t v60;
            v60 = loop_5(v1, v21, v58, v59, v57);
            int8_t v61;
            v61 = 0;
            int8_t v62;
            v62 = 1;
            uint32_t v63;
            v63 = loop_5(v1, v30, v61, v62, v60);
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
            v68 = loop_5(v1, v65, v66, v67, v63);
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
            return loop_12(v0, v1, v73);
        }
    } else {
        int8_t v76;
        v76 = 12;
        return loop_triple_13(v0, v1, v76);
    }
}
uint64_t loop_pair_9(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3, uint32_t v4, int8_t v5){
    bool v6;
    v6 = 0 <= v5;
    if (v6){
        bool v7;
        v7 = v3 == v5;
        if (v7){
            int8_t v8;
            v8 = v5 - 1;
            return loop_pair_9(v0, v1, v2, v3, v4, v8);
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
                v18 = loop_5(v1, v5, v16, v17, v4);
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
                return loop_pair_9(v0, v1, v2, v3, v4, v23);
            }
        }
    } else {
        int8_t v27;
        v27 = 0;
        uint32_t v28;
        v28 = try_suit_10(v1, v2, v27);
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
        v32 = try_suit_10(v1, v2, v31);
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
        v36 = try_suit_10(v1, v2, v35);
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
        v40 = try_suit_10(v1, v2, v39);
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
            return loop_12(v0, v1, v48);
        }
    }
}
uint64_t loop_triple_8(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3){
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
            v14 = loop_5(v1, v3, v11, v12, v13);
            int8_t v15;
            v15 = 12;
            return loop_pair_9(v0, v1, v2, v3, v14, v15);
        } else {
            int8_t v17;
            v17 = v3 - 1;
            return loop_triple_8(v0, v1, v2, v17);
        }
    } else {
        int8_t v20;
        v20 = 0;
        uint32_t v21;
        v21 = try_suit_10(v1, v2, v20);
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
        v25 = try_suit_10(v1, v2, v24);
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
        v29 = try_suit_10(v1, v2, v28);
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
        v33 = try_suit_10(v1, v2, v32);
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
            return loop_12(v0, v1, v41);
        }
    }
}
uint64_t loop_ranks_4(uint64_t v0, uint64_t v1, uint16_t v2, int8_t v3){
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
            v14 = loop_5(v1, v3, v11, v12, v13);
            int8_t v15;
            v15 = 12;
            int8_t v16;
            v16 = 1;
            uint32_t v17;
            v17 = loop_ranks_6(v1, v3, v15, v16, v14);
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
            return loop_ranks_4(v0, v1, v2, v22);
        }
    } else {
        int8_t v25;
        v25 = 12;
        return loop_triple_8(v0, v1, v2, v25);
    }
}
uint64_t score_1(uint64_t v0){
    int8_t v1; uint16_t v2;
    Tuple3 tmp8 = TupleCreate3(0, 0u);
    v1 = tmp8.v0; v2 = tmp8.v1;
    while (while_method_2(v1)){
        int8_t v4; uint16_t v5;
        Tuple3 tmp9 = TupleCreate3(0, v2);
        v4 = tmp9.v0; v5 = tmp9.v1;
        while (while_method_3(v4)){
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
    while (while_method_2(v19)){
        int8_t v22; uint64_t v23;
        Tuple4 tmp11 = TupleCreate4(0, v20);
        v22 = tmp11.v0; v23 = tmp11.v1;
        while (while_method_3(v22)){
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
    v38 = try_suit_2(v0, v2, v37);
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
    v42 = try_suit_2(v0, v2, v41);
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
    v46 = try_suit_2(v0, v2, v45);
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
    v50 = try_suit_2(v0, v2, v49);
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
        return loop_ranks_4(v20, v0, v2, v58);
    }
}
Tuple2 score__0(uint64_t v0){
    uint64_t v1;
    v1 = score_1(v0);
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
bool while_method_4(int32_t v0){
#pragma HLS INLINE
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
static inline Tuple7 TupleCreate7(bool v0, int32_t v1){
    Tuple7 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool while_method_5(std::array<Tuple5,7l> v0, bool v1, int32_t v2){
#pragma HLS INLINE
    bool v3;
    v3 = v2 < 7l;
    return v3;
}
bool while_method_6(std::array<Tuple5,7l> v0, int32_t v1){
#pragma HLS INLINE
    bool v2;
    v2 = v1 < 7l;
    return v2;
}
static inline Tuple8 TupleCreate8(int32_t v0, int32_t v1, int32_t v2){
    Tuple8 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
bool while_method_7(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
#pragma HLS INLINE
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
bool while_method_8(int32_t v0){
#pragma HLS INLINE
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
bool while_method_9(int32_t v0){
#pragma HLS INLINE
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
bool while_method_10(int32_t v0){
#pragma HLS INLINE
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
bool while_method_11(int32_t v0){
#pragma HLS INLINE
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
bool while_method_12(int32_t v0){
#pragma HLS INLINE
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
Tuple6 score_21(std::array<Tuple5,7l> v0){
    #pragma HLS PIPELINE II=1l
    std::array<Tuple5,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_4(v2)){
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
    while (while_method_5(v1, v7, v8)){
        int32_t v10;
        v10 = 0l;
        while (while_method_6(v1, v10)){
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
            while (while_method_7(v18, v19, v20, v21)){
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
    while (while_method_8(v87)){
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
    while (while_method_4(v94)){
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
    US1 v121;
    if (v108){
        int32_t v109;
        v109 = 0l;
        while (while_method_8(v109)){
            int32_t v111;
            v111 = v95 + 1l;
            int32_t v112;
            v112 = v111 - 2l;
            bool v113;
            v113 = v109 < v112;
            if (v113){
                ap_uint<4l> v114; ap_uint<2l> v115;
                Tuple5 tmp27 = v85[v109];
                v114 = tmp27.v0; v115 = tmp27.v1;
                v92[v109] = TupleCreate5(v114, v115);
            } else {
                int32_t v116;
                v116 = 2l + v109;
                ap_uint<4l> v117; ap_uint<2l> v118;
                Tuple5 tmp28 = v85[v116];
                v117 = tmp28.v0; v118 = tmp28.v1;
                v92[v109] = TupleCreate5(v117, v118);
            }
            v109++;
        }
        v121 = US1_1(v91, v92);
    } else {
        v121 = US1_0();
    }
    US2 v143;
    switch (v121.tag) {
        case 0: { // None
            v143 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,2l> v122 = v121.v.case1.v0; std::array<Tuple5,5l> v123 = v121.v.case1.v1;
            std::array<Tuple5,3l> v124;
            int32_t v125;
            v125 = 0l;
            while (while_method_9(v125)){
                ap_uint<4l> v127; ap_uint<2l> v128;
                Tuple5 tmp29 = v123[v125];
                v127 = tmp29.v0; v128 = tmp29.v1;
                v124[v125] = TupleCreate5(v127, v128);
                v125++;
            }
            std::array<Tuple5,0l> v129;
            std::array<Tuple5,5l> v130;
            int32_t v131;
            v131 = 0l;
            while (while_method_10(v131)){
                ap_uint<4l> v133; ap_uint<2l> v134;
                Tuple5 tmp30 = v122[v131];
                v133 = tmp30.v0; v134 = tmp30.v1;
                v130[v131] = TupleCreate5(v133, v134);
                v131++;
            }
            int32_t v135;
            v135 = 0l;
            while (while_method_9(v135)){
                ap_uint<4l> v137; ap_uint<2l> v138;
                Tuple5 tmp31 = v124[v135];
                v137 = tmp31.v0; v138 = tmp31.v1;
                int32_t v139;
                v139 = 2l + v135;
                v130[v139] = TupleCreate5(v137, v138);
                v135++;
            }
            v143 = US2_1(v130);
        }
    }
    std::array<Tuple5,2l> v144;
    std::array<Tuple5,5l> v145;
    ap_uint<4l> v146;
    v146 = 12ul;
    int32_t v147; int32_t v148; int32_t v149; ap_uint<4l> v150;
    Tuple9 tmp32 = TupleCreate9(0l, 0l, 0l, v146);
    v147 = tmp32.v0; v148 = tmp32.v1; v149 = tmp32.v2; v150 = tmp32.v3;
    while (while_method_4(v147)){
        ap_uint<4l> v152; ap_uint<2l> v153;
        Tuple5 tmp33 = v85[v147];
        v152 = tmp33.v0; v153 = tmp33.v1;
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
            v144[v156] = TupleCreate5(v152, v153);
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
    US1 v174;
    if (v161){
        int32_t v162;
        v162 = 0l;
        while (while_method_8(v162)){
            int32_t v164;
            v164 = v148 + 1l;
            int32_t v165;
            v165 = v164 - 2l;
            bool v166;
            v166 = v162 < v165;
            if (v166){
                ap_uint<4l> v167; ap_uint<2l> v168;
                Tuple5 tmp34 = v85[v162];
                v167 = tmp34.v0; v168 = tmp34.v1;
                v145[v162] = TupleCreate5(v167, v168);
            } else {
                int32_t v169;
                v169 = 2l + v162;
                ap_uint<4l> v170; ap_uint<2l> v171;
                Tuple5 tmp35 = v85[v169];
                v170 = tmp35.v0; v171 = tmp35.v1;
                v145[v162] = TupleCreate5(v170, v171);
            }
            v162++;
        }
        v174 = US1_1(v144, v145);
    } else {
        v174 = US1_0();
    }
    US2 v236;
    switch (v174.tag) {
        case 0: { // None
            v236 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,2l> v175 = v174.v.case1.v0; std::array<Tuple5,5l> v176 = v174.v.case1.v1;
            std::array<Tuple5,2l> v177;
            std::array<Tuple5,3l> v178;
            ap_uint<4l> v179;
            v179 = 12ul;
            int32_t v180; int32_t v181; int32_t v182; ap_uint<4l> v183;
            Tuple9 tmp36 = TupleCreate9(0l, 0l, 0l, v179);
            v180 = tmp36.v0; v181 = tmp36.v1; v182 = tmp36.v2; v183 = tmp36.v3;
            while (while_method_8(v180)){
                ap_uint<4l> v185; ap_uint<2l> v186;
                Tuple5 tmp37 = v176[v180];
                v185 = tmp37.v0; v186 = tmp37.v1;
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
                    v177[v189] = TupleCreate5(v185, v186);
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
            US3 v207;
            if (v194){
                int32_t v195;
                v195 = 0l;
                while (while_method_9(v195)){
                    int32_t v197;
                    v197 = v181 + 1l;
                    int32_t v198;
                    v198 = v197 - 2l;
                    bool v199;
                    v199 = v195 < v198;
                    if (v199){
                        ap_uint<4l> v200; ap_uint<2l> v201;
                        Tuple5 tmp38 = v176[v195];
                        v200 = tmp38.v0; v201 = tmp38.v1;
                        v178[v195] = TupleCreate5(v200, v201);
                    } else {
                        int32_t v202;
                        v202 = 2l + v195;
                        ap_uint<4l> v203; ap_uint<2l> v204;
                        Tuple5 tmp39 = v176[v202];
                        v203 = tmp39.v0; v204 = tmp39.v1;
                        v178[v195] = TupleCreate5(v203, v204);
                    }
                    v195++;
                }
                v207 = US3_1(v177, v178);
            } else {
                v207 = US3_0();
            }
            switch (v207.tag) {
                case 0: { // None
                    v236 = US2_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple5,2l> v208 = v207.v.case1.v0; std::array<Tuple5,3l> v209 = v207.v.case1.v1;
                    std::array<Tuple5,1l> v210;
                    int32_t v211;
                    v211 = 0l;
                    while (while_method_11(v211)){
                        ap_uint<4l> v213; ap_uint<2l> v214;
                        Tuple5 tmp40 = v209[v211];
                        v213 = tmp40.v0; v214 = tmp40.v1;
                        v210[v211] = TupleCreate5(v213, v214);
                        v211++;
                    }
                    std::array<Tuple5,5l> v215;
                    int32_t v216;
                    v216 = 0l;
                    while (while_method_10(v216)){
                        ap_uint<4l> v218; ap_uint<2l> v219;
                        Tuple5 tmp41 = v175[v216];
                        v218 = tmp41.v0; v219 = tmp41.v1;
                        v215[v216] = TupleCreate5(v218, v219);
                        v216++;
                    }
                    int32_t v220;
                    v220 = 0l;
                    while (while_method_10(v220)){
                        ap_uint<4l> v222; ap_uint<2l> v223;
                        Tuple5 tmp42 = v208[v220];
                        v222 = tmp42.v0; v223 = tmp42.v1;
                        int32_t v224;
                        v224 = 2l + v220;
                        v215[v224] = TupleCreate5(v222, v223);
                        v220++;
                    }
                    int32_t v225;
                    v225 = 0l;
                    while (while_method_11(v225)){
                        ap_uint<4l> v227; ap_uint<2l> v228;
                        Tuple5 tmp43 = v210[v225];
                        v227 = tmp43.v0; v228 = tmp43.v1;
                        int32_t v229;
                        v229 = 4l + v225;
                        v215[v229] = TupleCreate5(v227, v228);
                        v225++;
                    }
                    v236 = US2_1(v215);
                }
            }
        }
    }
    std::array<Tuple5,3l> v237;
    std::array<Tuple5,4l> v238;
    ap_uint<4l> v239;
    v239 = 12ul;
    int32_t v240; int32_t v241; int32_t v242; ap_uint<4l> v243;
    Tuple9 tmp44 = TupleCreate9(0l, 0l, 0l, v239);
    v240 = tmp44.v0; v241 = tmp44.v1; v242 = tmp44.v2; v243 = tmp44.v3;
    while (while_method_4(v240)){
        ap_uint<4l> v245; ap_uint<2l> v246;
        Tuple5 tmp45 = v85[v240];
        v245 = tmp45.v0; v246 = tmp45.v1;
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
            v237[v249] = TupleCreate5(v245, v246);
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
    US4 v267;
    if (v254){
        int32_t v255;
        v255 = 0l;
        while (while_method_12(v255)){
            int32_t v257;
            v257 = v241 + 1l;
            int32_t v258;
            v258 = v257 - 3l;
            bool v259;
            v259 = v255 < v258;
            if (v259){
                ap_uint<4l> v260; ap_uint<2l> v261;
                Tuple5 tmp46 = v85[v255];
                v260 = tmp46.v0; v261 = tmp46.v1;
                v238[v255] = TupleCreate5(v260, v261);
            } else {
                int32_t v262;
                v262 = 3l + v255;
                ap_uint<4l> v263; ap_uint<2l> v264;
                Tuple5 tmp47 = v85[v262];
                v263 = tmp47.v0; v264 = tmp47.v1;
                v238[v255] = TupleCreate5(v263, v264);
            }
            v255++;
        }
        v267 = US4_1(v237, v238);
    } else {
        v267 = US4_0();
    }
    US2 v289;
    switch (v267.tag) {
        case 0: { // None
            v289 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,3l> v268 = v267.v.case1.v0; std::array<Tuple5,4l> v269 = v267.v.case1.v1;
            std::array<Tuple5,2l> v270;
            int32_t v271;
            v271 = 0l;
            while (while_method_10(v271)){
                ap_uint<4l> v273; ap_uint<2l> v274;
                Tuple5 tmp48 = v269[v271];
                v273 = tmp48.v0; v274 = tmp48.v1;
                v270[v271] = TupleCreate5(v273, v274);
                v271++;
            }
            std::array<Tuple5,0l> v275;
            std::array<Tuple5,5l> v276;
            int32_t v277;
            v277 = 0l;
            while (while_method_9(v277)){
                ap_uint<4l> v279; ap_uint<2l> v280;
                Tuple5 tmp49 = v268[v277];
                v279 = tmp49.v0; v280 = tmp49.v1;
                v276[v277] = TupleCreate5(v279, v280);
                v277++;
            }
            int32_t v281;
            v281 = 0l;
            while (while_method_10(v281)){
                ap_uint<4l> v283; ap_uint<2l> v284;
                Tuple5 tmp50 = v270[v281];
                v283 = tmp50.v0; v284 = tmp50.v1;
                int32_t v285;
                v285 = 3l + v281;
                v276[v285] = TupleCreate5(v283, v284);
                v281++;
            }
            v289 = US2_1(v276);
        }
    }
    std::array<Tuple5,5l> v290;
    ap_uint<4l> v291;
    v291 = 12ul;
    int32_t v292; int32_t v293; ap_uint<4l> v294;
    Tuple10 tmp51 = TupleCreate10(0l, 0l, v291);
    v292 = tmp51.v0; v293 = tmp51.v1; v294 = tmp51.v2;
    while (while_method_4(v292)){
        ap_uint<4l> v296; ap_uint<2l> v297;
        Tuple5 tmp52 = v85[v292];
        v296 = tmp52.v0; v297 = tmp52.v1;
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
            v290[v305] = TupleCreate5(v296, v297);
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
            Tuple5 tmp53 = v85[0l];
            v316 = tmp53.v0; v317 = tmp53.v1;
            ap_uint<4l> v318;
            v318 = 12ul;
            bool v319;
            v319 = v316 == v318;
            if (v319){
                v290[4l] = TupleCreate5(v316, v317);
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
    US2 v328;
    if (v322){
        v328 = US2_1(v290);
    } else {
        bool v324;
        v324 = v293 == 5l;
        if (v324){
            v328 = US2_1(v290);
        } else {
            v328 = US2_0();
        }
    }
    std::array<Tuple5,5l> v329;
    int32_t v330; int32_t v331;
    Tuple11 tmp54 = TupleCreate11(0l, 0l);
    v330 = tmp54.v0; v331 = tmp54.v1;
    while (while_method_4(v330)){
        ap_uint<4l> v333; ap_uint<2l> v334;
        Tuple5 tmp55 = v85[v330];
        v333 = tmp55.v0; v334 = tmp55.v1;
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
            v329[v331] = TupleCreate5(v333, v334);
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
    US2 v344;
    if (v341){
        v344 = US2_1(v329);
    } else {
        v344 = US2_0();
    }
    std::array<Tuple5,5l> v345;
    int32_t v346; int32_t v347;
    Tuple11 tmp56 = TupleCreate11(0l, 0l);
    v346 = tmp56.v0; v347 = tmp56.v1;
    while (while_method_4(v346)){
        ap_uint<4l> v349; ap_uint<2l> v350;
        Tuple5 tmp57 = v85[v346];
        v349 = tmp57.v0; v350 = tmp57.v1;
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
            v345[v347] = TupleCreate5(v349, v350);
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
    US2 v360;
    if (v357){
        v360 = US2_1(v345);
    } else {
        v360 = US2_0();
    }
    std::array<Tuple5,5l> v361;
    int32_t v362; int32_t v363;
    Tuple11 tmp58 = TupleCreate11(0l, 0l);
    v362 = tmp58.v0; v363 = tmp58.v1;
    while (while_method_4(v362)){
        ap_uint<4l> v365; ap_uint<2l> v366;
        Tuple5 tmp59 = v85[v362];
        v365 = tmp59.v0; v366 = tmp59.v1;
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
            v361[v363] = TupleCreate5(v365, v366);
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
    US2 v376;
    if (v373){
        v376 = US2_1(v361);
    } else {
        v376 = US2_0();
    }
    std::array<Tuple5,5l> v377;
    int32_t v378; int32_t v379;
    Tuple11 tmp60 = TupleCreate11(0l, 0l);
    v378 = tmp60.v0; v379 = tmp60.v1;
    while (while_method_4(v378)){
        ap_uint<4l> v381; ap_uint<2l> v382;
        Tuple5 tmp61 = v85[v378];
        v381 = tmp61.v0; v382 = tmp61.v1;
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
            v377[v379] = TupleCreate5(v381, v382);
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
    US2 v392;
    if (v389){
        v392 = US2_1(v377);
    } else {
        v392 = US2_0();
    }
    US2 v417;
    switch (v392.tag) {
        case 0: { // None
            v417 = v376;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v393 = v392.v.case1.v0;
            switch (v376.tag) {
                case 0: { // None
                    v417 = v392;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v394 = v376.v.case1.v0;
                    US0 v395;
                    v395 = US0_0();
                    int32_t v396; US0 v397;
                    Tuple12 tmp62 = TupleCreate12(0l, v395);
                    v396 = tmp62.v0; v397 = tmp62.v1;
                    while (while_method_8(v396)){
                        ap_uint<4l> v399; ap_uint<2l> v400;
                        Tuple5 tmp63 = v393[v396];
                        v399 = tmp63.v0; v400 = tmp63.v1;
                        ap_uint<4l> v401; ap_uint<2l> v402;
                        Tuple5 tmp64 = v394[v396];
                        v401 = tmp64.v0; v402 = tmp64.v1;
                        US0 v410;
                        switch (v397.tag) {
                            case 0: { // Eq
                                bool v403;
                                v403 = v399 > v401;
                                if (v403){
                                    v410 = US0_1();
                                } else {
                                    bool v405;
                                    v405 = v399 < v401;
                                    if (v405){
                                        v410 = US0_2();
                                    } else {
                                        v410 = US0_0();
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
                    std::array<Tuple5,5l> v412;
                    if (v411){
                        v412 = v393;
                    } else {
                        v412 = v394;
                    }
                    v417 = US2_1(v412);
                }
            }
        }
    }
    US2 v442;
    switch (v417.tag) {
        case 0: { // None
            v442 = v360;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v418 = v417.v.case1.v0;
            switch (v360.tag) {
                case 0: { // None
                    v442 = v417;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v419 = v360.v.case1.v0;
                    US0 v420;
                    v420 = US0_0();
                    int32_t v421; US0 v422;
                    Tuple12 tmp65 = TupleCreate12(0l, v420);
                    v421 = tmp65.v0; v422 = tmp65.v1;
                    while (while_method_8(v421)){
                        ap_uint<4l> v424; ap_uint<2l> v425;
                        Tuple5 tmp66 = v418[v421];
                        v424 = tmp66.v0; v425 = tmp66.v1;
                        ap_uint<4l> v426; ap_uint<2l> v427;
                        Tuple5 tmp67 = v419[v421];
                        v426 = tmp67.v0; v427 = tmp67.v1;
                        US0 v435;
                        switch (v422.tag) {
                            case 0: { // Eq
                                bool v428;
                                v428 = v424 > v426;
                                if (v428){
                                    v435 = US0_1();
                                } else {
                                    bool v430;
                                    v430 = v424 < v426;
                                    if (v430){
                                        v435 = US0_2();
                                    } else {
                                        v435 = US0_0();
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
                    std::array<Tuple5,5l> v437;
                    if (v436){
                        v437 = v418;
                    } else {
                        v437 = v419;
                    }
                    v442 = US2_1(v437);
                }
            }
        }
    }
    US2 v467;
    switch (v442.tag) {
        case 0: { // None
            v467 = v344;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v443 = v442.v.case1.v0;
            switch (v344.tag) {
                case 0: { // None
                    v467 = v442;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v444 = v344.v.case1.v0;
                    US0 v445;
                    v445 = US0_0();
                    int32_t v446; US0 v447;
                    Tuple12 tmp68 = TupleCreate12(0l, v445);
                    v446 = tmp68.v0; v447 = tmp68.v1;
                    while (while_method_8(v446)){
                        ap_uint<4l> v449; ap_uint<2l> v450;
                        Tuple5 tmp69 = v443[v446];
                        v449 = tmp69.v0; v450 = tmp69.v1;
                        ap_uint<4l> v451; ap_uint<2l> v452;
                        Tuple5 tmp70 = v444[v446];
                        v451 = tmp70.v0; v452 = tmp70.v1;
                        US0 v460;
                        switch (v447.tag) {
                            case 0: { // Eq
                                bool v453;
                                v453 = v449 > v451;
                                if (v453){
                                    v460 = US0_1();
                                } else {
                                    bool v455;
                                    v455 = v449 < v451;
                                    if (v455){
                                        v460 = US0_2();
                                    } else {
                                        v460 = US0_0();
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
                    std::array<Tuple5,5l> v462;
                    if (v461){
                        v462 = v443;
                    } else {
                        v462 = v444;
                    }
                    v467 = US2_1(v462);
                }
            }
        }
    }
    std::array<Tuple5,3l> v468;
    std::array<Tuple5,4l> v469;
    ap_uint<4l> v470;
    v470 = 12ul;
    int32_t v471; int32_t v472; int32_t v473; ap_uint<4l> v474;
    Tuple9 tmp71 = TupleCreate9(0l, 0l, 0l, v470);
    v471 = tmp71.v0; v472 = tmp71.v1; v473 = tmp71.v2; v474 = tmp71.v3;
    while (while_method_4(v471)){
        ap_uint<4l> v476; ap_uint<2l> v477;
        Tuple5 tmp72 = v85[v471];
        v476 = tmp72.v0; v477 = tmp72.v1;
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
            v468[v480] = TupleCreate5(v476, v477);
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
    US4 v498;
    if (v485){
        int32_t v486;
        v486 = 0l;
        while (while_method_12(v486)){
            int32_t v488;
            v488 = v472 + 1l;
            int32_t v489;
            v489 = v488 - 3l;
            bool v490;
            v490 = v486 < v489;
            if (v490){
                ap_uint<4l> v491; ap_uint<2l> v492;
                Tuple5 tmp73 = v85[v486];
                v491 = tmp73.v0; v492 = tmp73.v1;
                v469[v486] = TupleCreate5(v491, v492);
            } else {
                int32_t v493;
                v493 = 3l + v486;
                ap_uint<4l> v494; ap_uint<2l> v495;
                Tuple5 tmp74 = v85[v493];
                v494 = tmp74.v0; v495 = tmp74.v1;
                v469[v486] = TupleCreate5(v494, v495);
            }
            v486++;
        }
        v498 = US4_1(v468, v469);
    } else {
        v498 = US4_0();
    }
    US2 v551;
    switch (v498.tag) {
        case 0: { // None
            v551 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,3l> v499 = v498.v.case1.v0; std::array<Tuple5,4l> v500 = v498.v.case1.v1;
            std::array<Tuple5,2l> v501;
            std::array<Tuple5,2l> v502;
            ap_uint<4l> v503;
            v503 = 12ul;
            int32_t v504; int32_t v505; int32_t v506; ap_uint<4l> v507;
            Tuple9 tmp75 = TupleCreate9(0l, 0l, 0l, v503);
            v504 = tmp75.v0; v505 = tmp75.v1; v506 = tmp75.v2; v507 = tmp75.v3;
            while (while_method_12(v504)){
                ap_uint<4l> v509; ap_uint<2l> v510;
                Tuple5 tmp76 = v500[v504];
                v509 = tmp76.v0; v510 = tmp76.v1;
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
                    v501[v513] = TupleCreate5(v509, v510);
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
            US5 v531;
            if (v518){
                int32_t v519;
                v519 = 0l;
                while (while_method_10(v519)){
                    int32_t v521;
                    v521 = v505 + 1l;
                    int32_t v522;
                    v522 = v521 - 2l;
                    bool v523;
                    v523 = v519 < v522;
                    if (v523){
                        ap_uint<4l> v524; ap_uint<2l> v525;
                        Tuple5 tmp77 = v500[v519];
                        v524 = tmp77.v0; v525 = tmp77.v1;
                        v502[v519] = TupleCreate5(v524, v525);
                    } else {
                        int32_t v526;
                        v526 = 2l + v519;
                        ap_uint<4l> v527; ap_uint<2l> v528;
                        Tuple5 tmp78 = v500[v526];
                        v527 = tmp78.v0; v528 = tmp78.v1;
                        v502[v519] = TupleCreate5(v527, v528);
                    }
                    v519++;
                }
                v531 = US5_1(v501, v502);
            } else {
                v531 = US5_0();
            }
            switch (v531.tag) {
                case 0: { // None
                    v551 = US2_0();
                    break;
                }
                default: { // Some
                    std::array<Tuple5,2l> v532 = v531.v.case1.v0; std::array<Tuple5,2l> v533 = v531.v.case1.v1;
                    std::array<Tuple5,0l> v534;
                    std::array<Tuple5,5l> v535;
                    int32_t v536;
                    v536 = 0l;
                    while (while_method_9(v536)){
                        ap_uint<4l> v538; ap_uint<2l> v539;
                        Tuple5 tmp79 = v499[v536];
                        v538 = tmp79.v0; v539 = tmp79.v1;
                        v535[v536] = TupleCreate5(v538, v539);
                        v536++;
                    }
                    int32_t v540;
                    v540 = 0l;
                    while (while_method_10(v540)){
                        ap_uint<4l> v542; ap_uint<2l> v543;
                        Tuple5 tmp80 = v532[v540];
                        v542 = tmp80.v0; v543 = tmp80.v1;
                        int32_t v544;
                        v544 = 3l + v540;
                        v535[v544] = TupleCreate5(v542, v543);
                        v540++;
                    }
                    v551 = US2_1(v535);
                }
            }
        }
    }
    std::array<Tuple5,4l> v552;
    std::array<Tuple5,3l> v553;
    ap_uint<4l> v554;
    v554 = 12ul;
    int32_t v555; int32_t v556; int32_t v557; ap_uint<4l> v558;
    Tuple9 tmp81 = TupleCreate9(0l, 0l, 0l, v554);
    v555 = tmp81.v0; v556 = tmp81.v1; v557 = tmp81.v2; v558 = tmp81.v3;
    while (while_method_4(v555)){
        ap_uint<4l> v560; ap_uint<2l> v561;
        Tuple5 tmp82 = v85[v555];
        v560 = tmp82.v0; v561 = tmp82.v1;
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
            v552[v564] = TupleCreate5(v560, v561);
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
    US6 v582;
    if (v569){
        int32_t v570;
        v570 = 0l;
        while (while_method_9(v570)){
            int32_t v572;
            v572 = v556 + 1l;
            int32_t v573;
            v573 = v572 - 4l;
            bool v574;
            v574 = v570 < v573;
            if (v574){
                ap_uint<4l> v575; ap_uint<2l> v576;
                Tuple5 tmp83 = v85[v570];
                v575 = tmp83.v0; v576 = tmp83.v1;
                v553[v570] = TupleCreate5(v575, v576);
            } else {
                int32_t v577;
                v577 = 4l + v570;
                ap_uint<4l> v578; ap_uint<2l> v579;
                Tuple5 tmp84 = v85[v577];
                v578 = tmp84.v0; v579 = tmp84.v1;
                v553[v570] = TupleCreate5(v578, v579);
            }
            v570++;
        }
        v582 = US6_1(v552, v553);
    } else {
        v582 = US6_0();
    }
    US2 v604;
    switch (v582.tag) {
        case 0: { // None
            v604 = US2_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,4l> v583 = v582.v.case1.v0; std::array<Tuple5,3l> v584 = v582.v.case1.v1;
            std::array<Tuple5,1l> v585;
            int32_t v586;
            v586 = 0l;
            while (while_method_11(v586)){
                ap_uint<4l> v588; ap_uint<2l> v589;
                Tuple5 tmp85 = v584[v586];
                v588 = tmp85.v0; v589 = tmp85.v1;
                v585[v586] = TupleCreate5(v588, v589);
                v586++;
            }
            std::array<Tuple5,0l> v590;
            std::array<Tuple5,5l> v591;
            int32_t v592;
            v592 = 0l;
            while (while_method_12(v592)){
                ap_uint<4l> v594; ap_uint<2l> v595;
                Tuple5 tmp86 = v583[v592];
                v594 = tmp86.v0; v595 = tmp86.v1;
                v591[v592] = TupleCreate5(v594, v595);
                v592++;
            }
            int32_t v596;
            v596 = 0l;
            while (while_method_11(v596)){
                ap_uint<4l> v598; ap_uint<2l> v599;
                Tuple5 tmp87 = v585[v596];
                v598 = tmp87.v0; v599 = tmp87.v1;
                int32_t v600;
                v600 = 4l + v596;
                v591[v600] = TupleCreate5(v598, v599);
                v596++;
            }
            v604 = US2_1(v591);
        }
    }
    ap_uint<2l> v605;
    v605 = 3ul;
    std::array<Tuple5,5l> v606;
    ap_uint<4l> v607;
    v607 = 12ul;
    int32_t v608; int32_t v609; ap_uint<4l> v610;
    Tuple10 tmp88 = TupleCreate10(0l, 0l, v607);
    v608 = tmp88.v0; v609 = tmp88.v1; v610 = tmp88.v2;
    while (while_method_4(v608)){
        ap_uint<4l> v612; ap_uint<2l> v613;
        Tuple5 tmp89 = v85[v608];
        v612 = tmp89.v0; v613 = tmp89.v1;
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
            v606[v618] = TupleCreate5(v612, v613);
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
            Tuple5 tmp90 = v85[0l];
            v629 = tmp90.v0; v630 = tmp90.v1;
            bool v631;
            v631 = v605 == v630;
            bool v635;
            if (v631){
                ap_uint<4l> v632;
                v632 = 12ul;
                bool v633;
                v633 = v629 == v632;
                if (v633){
                    v606[4l] = TupleCreate5(v629, v630);
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
                Tuple5 tmp91 = v85[1l];
                v636 = tmp91.v0; v637 = tmp91.v1;
                bool v638;
                v638 = v605 == v637;
                bool v642;
                if (v638){
                    ap_uint<4l> v639;
                    v639 = 12ul;
                    bool v640;
                    v640 = v636 == v639;
                    if (v640){
                        v606[4l] = TupleCreate5(v636, v637);
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
                    Tuple5 tmp92 = v85[2l];
                    v643 = tmp92.v0; v644 = tmp92.v1;
                    bool v645;
                    v645 = v605 == v644;
                    bool v649;
                    if (v645){
                        ap_uint<4l> v646;
                        v646 = 12ul;
                        bool v647;
                        v647 = v643 == v646;
                        if (v647){
                            v606[4l] = TupleCreate5(v643, v644);
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
                        Tuple5 tmp93 = v85[3l];
                        v650 = tmp93.v0; v651 = tmp93.v1;
                        bool v652;
                        v652 = v605 == v651;
                        if (v652){
                            ap_uint<4l> v653;
                            v653 = 12ul;
                            bool v654;
                            v654 = v650 == v653;
                            if (v654){
                                v606[4l] = TupleCreate5(v650, v651);
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
    US2 v667;
    if (v661){
        v667 = US2_1(v606);
    } else {
        bool v663;
        v663 = v609 == 5l;
        if (v663){
            v667 = US2_1(v606);
        } else {
            v667 = US2_0();
        }
    }
    ap_uint<2l> v668;
    v668 = 2ul;
    std::array<Tuple5,5l> v669;
    ap_uint<4l> v670;
    v670 = 12ul;
    int32_t v671; int32_t v672; ap_uint<4l> v673;
    Tuple10 tmp94 = TupleCreate10(0l, 0l, v670);
    v671 = tmp94.v0; v672 = tmp94.v1; v673 = tmp94.v2;
    while (while_method_4(v671)){
        ap_uint<4l> v675; ap_uint<2l> v676;
        Tuple5 tmp95 = v85[v671];
        v675 = tmp95.v0; v676 = tmp95.v1;
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
            v669[v681] = TupleCreate5(v675, v676);
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
            Tuple5 tmp96 = v85[0l];
            v692 = tmp96.v0; v693 = tmp96.v1;
            bool v694;
            v694 = v668 == v693;
            bool v698;
            if (v694){
                ap_uint<4l> v695;
                v695 = 12ul;
                bool v696;
                v696 = v692 == v695;
                if (v696){
                    v669[4l] = TupleCreate5(v692, v693);
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
                Tuple5 tmp97 = v85[1l];
                v699 = tmp97.v0; v700 = tmp97.v1;
                bool v701;
                v701 = v668 == v700;
                bool v705;
                if (v701){
                    ap_uint<4l> v702;
                    v702 = 12ul;
                    bool v703;
                    v703 = v699 == v702;
                    if (v703){
                        v669[4l] = TupleCreate5(v699, v700);
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
                    Tuple5 tmp98 = v85[2l];
                    v706 = tmp98.v0; v707 = tmp98.v1;
                    bool v708;
                    v708 = v668 == v707;
                    bool v712;
                    if (v708){
                        ap_uint<4l> v709;
                        v709 = 12ul;
                        bool v710;
                        v710 = v706 == v709;
                        if (v710){
                            v669[4l] = TupleCreate5(v706, v707);
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
                        Tuple5 tmp99 = v85[3l];
                        v713 = tmp99.v0; v714 = tmp99.v1;
                        bool v715;
                        v715 = v668 == v714;
                        if (v715){
                            ap_uint<4l> v716;
                            v716 = 12ul;
                            bool v717;
                            v717 = v713 == v716;
                            if (v717){
                                v669[4l] = TupleCreate5(v713, v714);
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
    US2 v730;
    if (v724){
        v730 = US2_1(v669);
    } else {
        bool v726;
        v726 = v672 == 5l;
        if (v726){
            v730 = US2_1(v669);
        } else {
            v730 = US2_0();
        }
    }
    ap_uint<2l> v731;
    v731 = 1ul;
    std::array<Tuple5,5l> v732;
    ap_uint<4l> v733;
    v733 = 12ul;
    int32_t v734; int32_t v735; ap_uint<4l> v736;
    Tuple10 tmp100 = TupleCreate10(0l, 0l, v733);
    v734 = tmp100.v0; v735 = tmp100.v1; v736 = tmp100.v2;
    while (while_method_4(v734)){
        ap_uint<4l> v738; ap_uint<2l> v739;
        Tuple5 tmp101 = v85[v734];
        v738 = tmp101.v0; v739 = tmp101.v1;
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
            v732[v744] = TupleCreate5(v738, v739);
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
            Tuple5 tmp102 = v85[0l];
            v755 = tmp102.v0; v756 = tmp102.v1;
            bool v757;
            v757 = v731 == v756;
            bool v761;
            if (v757){
                ap_uint<4l> v758;
                v758 = 12ul;
                bool v759;
                v759 = v755 == v758;
                if (v759){
                    v732[4l] = TupleCreate5(v755, v756);
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
                Tuple5 tmp103 = v85[1l];
                v762 = tmp103.v0; v763 = tmp103.v1;
                bool v764;
                v764 = v731 == v763;
                bool v768;
                if (v764){
                    ap_uint<4l> v765;
                    v765 = 12ul;
                    bool v766;
                    v766 = v762 == v765;
                    if (v766){
                        v732[4l] = TupleCreate5(v762, v763);
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
                    Tuple5 tmp104 = v85[2l];
                    v769 = tmp104.v0; v770 = tmp104.v1;
                    bool v771;
                    v771 = v731 == v770;
                    bool v775;
                    if (v771){
                        ap_uint<4l> v772;
                        v772 = 12ul;
                        bool v773;
                        v773 = v769 == v772;
                        if (v773){
                            v732[4l] = TupleCreate5(v769, v770);
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
                        Tuple5 tmp105 = v85[3l];
                        v776 = tmp105.v0; v777 = tmp105.v1;
                        bool v778;
                        v778 = v731 == v777;
                        if (v778){
                            ap_uint<4l> v779;
                            v779 = 12ul;
                            bool v780;
                            v780 = v776 == v779;
                            if (v780){
                                v732[4l] = TupleCreate5(v776, v777);
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
    US2 v793;
    if (v787){
        v793 = US2_1(v732);
    } else {
        bool v789;
        v789 = v735 == 5l;
        if (v789){
            v793 = US2_1(v732);
        } else {
            v793 = US2_0();
        }
    }
    ap_uint<2l> v794;
    v794 = 0ul;
    std::array<Tuple5,5l> v795;
    ap_uint<4l> v796;
    v796 = 12ul;
    int32_t v797; int32_t v798; ap_uint<4l> v799;
    Tuple10 tmp106 = TupleCreate10(0l, 0l, v796);
    v797 = tmp106.v0; v798 = tmp106.v1; v799 = tmp106.v2;
    while (while_method_4(v797)){
        ap_uint<4l> v801; ap_uint<2l> v802;
        Tuple5 tmp107 = v85[v797];
        v801 = tmp107.v0; v802 = tmp107.v1;
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
            v795[v807] = TupleCreate5(v801, v802);
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
            Tuple5 tmp108 = v85[0l];
            v818 = tmp108.v0; v819 = tmp108.v1;
            bool v820;
            v820 = v794 == v819;
            bool v824;
            if (v820){
                ap_uint<4l> v821;
                v821 = 12ul;
                bool v822;
                v822 = v818 == v821;
                if (v822){
                    v795[4l] = TupleCreate5(v818, v819);
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
                Tuple5 tmp109 = v85[1l];
                v825 = tmp109.v0; v826 = tmp109.v1;
                bool v827;
                v827 = v794 == v826;
                bool v831;
                if (v827){
                    ap_uint<4l> v828;
                    v828 = 12ul;
                    bool v829;
                    v829 = v825 == v828;
                    if (v829){
                        v795[4l] = TupleCreate5(v825, v826);
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
                    Tuple5 tmp110 = v85[2l];
                    v832 = tmp110.v0; v833 = tmp110.v1;
                    bool v834;
                    v834 = v794 == v833;
                    bool v838;
                    if (v834){
                        ap_uint<4l> v835;
                        v835 = 12ul;
                        bool v836;
                        v836 = v832 == v835;
                        if (v836){
                            v795[4l] = TupleCreate5(v832, v833);
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
                        Tuple5 tmp111 = v85[3l];
                        v839 = tmp111.v0; v840 = tmp111.v1;
                        bool v841;
                        v841 = v794 == v840;
                        if (v841){
                            ap_uint<4l> v842;
                            v842 = 12ul;
                            bool v843;
                            v843 = v839 == v842;
                            if (v843){
                                v795[4l] = TupleCreate5(v839, v840);
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
    US2 v856;
    if (v850){
        v856 = US2_1(v795);
    } else {
        bool v852;
        v852 = v798 == 5l;
        if (v852){
            v856 = US2_1(v795);
        } else {
            v856 = US2_0();
        }
    }
    US2 v881;
    switch (v856.tag) {
        case 0: { // None
            v881 = v793;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v857 = v856.v.case1.v0;
            switch (v793.tag) {
                case 0: { // None
                    v881 = v856;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v858 = v793.v.case1.v0;
                    US0 v859;
                    v859 = US0_0();
                    int32_t v860; US0 v861;
                    Tuple12 tmp112 = TupleCreate12(0l, v859);
                    v860 = tmp112.v0; v861 = tmp112.v1;
                    while (while_method_8(v860)){
                        ap_uint<4l> v863; ap_uint<2l> v864;
                        Tuple5 tmp113 = v857[v860];
                        v863 = tmp113.v0; v864 = tmp113.v1;
                        ap_uint<4l> v865; ap_uint<2l> v866;
                        Tuple5 tmp114 = v858[v860];
                        v865 = tmp114.v0; v866 = tmp114.v1;
                        US0 v874;
                        switch (v861.tag) {
                            case 0: { // Eq
                                bool v867;
                                v867 = v863 > v865;
                                if (v867){
                                    v874 = US0_1();
                                } else {
                                    bool v869;
                                    v869 = v863 < v865;
                                    if (v869){
                                        v874 = US0_2();
                                    } else {
                                        v874 = US0_0();
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
                    std::array<Tuple5,5l> v876;
                    if (v875){
                        v876 = v857;
                    } else {
                        v876 = v858;
                    }
                    v881 = US2_1(v876);
                }
            }
        }
    }
    US2 v906;
    switch (v881.tag) {
        case 0: { // None
            v906 = v730;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v882 = v881.v.case1.v0;
            switch (v730.tag) {
                case 0: { // None
                    v906 = v881;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v883 = v730.v.case1.v0;
                    US0 v884;
                    v884 = US0_0();
                    int32_t v885; US0 v886;
                    Tuple12 tmp115 = TupleCreate12(0l, v884);
                    v885 = tmp115.v0; v886 = tmp115.v1;
                    while (while_method_8(v885)){
                        ap_uint<4l> v888; ap_uint<2l> v889;
                        Tuple5 tmp116 = v882[v885];
                        v888 = tmp116.v0; v889 = tmp116.v1;
                        ap_uint<4l> v890; ap_uint<2l> v891;
                        Tuple5 tmp117 = v883[v885];
                        v890 = tmp117.v0; v891 = tmp117.v1;
                        US0 v899;
                        switch (v886.tag) {
                            case 0: { // Eq
                                bool v892;
                                v892 = v888 > v890;
                                if (v892){
                                    v899 = US0_1();
                                } else {
                                    bool v894;
                                    v894 = v888 < v890;
                                    if (v894){
                                        v899 = US0_2();
                                    } else {
                                        v899 = US0_0();
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
                    std::array<Tuple5,5l> v901;
                    if (v900){
                        v901 = v882;
                    } else {
                        v901 = v883;
                    }
                    v906 = US2_1(v901);
                }
            }
        }
    }
    US2 v931;
    switch (v906.tag) {
        case 0: { // None
            v931 = v667;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v907 = v906.v.case1.v0;
            switch (v667.tag) {
                case 0: { // None
                    v931 = v906;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v908 = v667.v.case1.v0;
                    US0 v909;
                    v909 = US0_0();
                    int32_t v910; US0 v911;
                    Tuple12 tmp118 = TupleCreate12(0l, v909);
                    v910 = tmp118.v0; v911 = tmp118.v1;
                    while (while_method_8(v910)){
                        ap_uint<4l> v913; ap_uint<2l> v914;
                        Tuple5 tmp119 = v907[v910];
                        v913 = tmp119.v0; v914 = tmp119.v1;
                        ap_uint<4l> v915; ap_uint<2l> v916;
                        Tuple5 tmp120 = v908[v910];
                        v915 = tmp120.v0; v916 = tmp120.v1;
                        US0 v924;
                        switch (v911.tag) {
                            case 0: { // Eq
                                bool v917;
                                v917 = v913 > v915;
                                if (v917){
                                    v924 = US0_1();
                                } else {
                                    bool v919;
                                    v919 = v913 < v915;
                                    if (v919){
                                        v924 = US0_2();
                                    } else {
                                        v924 = US0_0();
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
                    std::array<Tuple5,5l> v926;
                    if (v925){
                        v926 = v907;
                    } else {
                        v926 = v908;
                    }
                    v931 = US2_1(v926);
                }
            }
        }
    }
    ap_uint<4l> v932;
    v932 = 1ul;
    US7 v937;
    switch (v143.tag) {
        case 0: { // None
            v937 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v933 = v143.v.case1.v0;
            v937 = US7_1(v933, v932);
        }
    }
    ap_uint<4l> v938;
    v938 = 2ul;
    US7 v943;
    switch (v236.tag) {
        case 0: { // None
            v943 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v939 = v236.v.case1.v0;
            v943 = US7_1(v939, v938);
        }
    }
    ap_uint<4l> v944;
    v944 = 3ul;
    US7 v949;
    switch (v289.tag) {
        case 0: { // None
            v949 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v945 = v289.v.case1.v0;
            v949 = US7_1(v945, v944);
        }
    }
    ap_uint<4l> v950;
    v950 = 4ul;
    US7 v955;
    switch (v328.tag) {
        case 0: { // None
            v955 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v951 = v328.v.case1.v0;
            v955 = US7_1(v951, v950);
        }
    }
    ap_uint<4l> v956;
    v956 = 5ul;
    US7 v961;
    switch (v467.tag) {
        case 0: { // None
            v961 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v957 = v467.v.case1.v0;
            v961 = US7_1(v957, v956);
        }
    }
    ap_uint<4l> v962;
    v962 = 6ul;
    US7 v967;
    switch (v551.tag) {
        case 0: { // None
            v967 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v963 = v551.v.case1.v0;
            v967 = US7_1(v963, v962);
        }
    }
    ap_uint<4l> v968;
    v968 = 7ul;
    US7 v973;
    switch (v604.tag) {
        case 0: { // None
            v973 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v969 = v604.v.case1.v0;
            v973 = US7_1(v969, v968);
        }
    }
    ap_uint<4l> v974;
    v974 = 8ul;
    US7 v979;
    switch (v931.tag) {
        case 0: { // None
            v979 = US7_0();
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v975 = v931.v.case1.v0;
            v979 = US7_1(v975, v974);
        }
    }
    US7 v981;
    switch (v979.tag) {
        case 0: { // None
            v981 = US7_0();
            break;
        }
        default: {
            v981 = v979;
        }
    }
    US7 v991;
    switch (v981.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v982 = v981.v.case1.v0; ap_uint<4l> v983 = v981.v.case1.v1;
            switch (v973.tag) {
                case 0: { // None
                    v991 = v981;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v984 = v973.v.case1.v0; ap_uint<4l> v985 = v973.v.case1.v1;
                    v991 = US7_1(v982, v983);
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
    US7 v1001;
    switch (v991.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v992 = v991.v.case1.v0; ap_uint<4l> v993 = v991.v.case1.v1;
            switch (v967.tag) {
                case 0: { // None
                    v1001 = v991;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v994 = v967.v.case1.v0; ap_uint<4l> v995 = v967.v.case1.v1;
                    v1001 = US7_1(v992, v993);
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
    US7 v1011;
    switch (v1001.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1002 = v1001.v.case1.v0; ap_uint<4l> v1003 = v1001.v.case1.v1;
            switch (v961.tag) {
                case 0: { // None
                    v1011 = v1001;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1004 = v961.v.case1.v0; ap_uint<4l> v1005 = v961.v.case1.v1;
                    v1011 = US7_1(v1002, v1003);
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
    US7 v1021;
    switch (v1011.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1012 = v1011.v.case1.v0; ap_uint<4l> v1013 = v1011.v.case1.v1;
            switch (v955.tag) {
                case 0: { // None
                    v1021 = v1011;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1014 = v955.v.case1.v0; ap_uint<4l> v1015 = v955.v.case1.v1;
                    v1021 = US7_1(v1012, v1013);
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
    US7 v1031;
    switch (v1021.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1022 = v1021.v.case1.v0; ap_uint<4l> v1023 = v1021.v.case1.v1;
            switch (v949.tag) {
                case 0: { // None
                    v1031 = v1021;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1024 = v949.v.case1.v0; ap_uint<4l> v1025 = v949.v.case1.v1;
                    v1031 = US7_1(v1022, v1023);
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
    US7 v1041;
    switch (v1031.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1032 = v1031.v.case1.v0; ap_uint<4l> v1033 = v1031.v.case1.v1;
            switch (v943.tag) {
                case 0: { // None
                    v1041 = v1031;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1034 = v943.v.case1.v0; ap_uint<4l> v1035 = v943.v.case1.v1;
                    v1041 = US7_1(v1032, v1033);
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
    US7 v1051;
    switch (v1041.tag) {
        case 1: { // Some
            std::array<Tuple5,5l> v1042 = v1041.v.case1.v0; ap_uint<4l> v1043 = v1041.v.case1.v1;
            switch (v937.tag) {
                case 0: { // None
                    v1051 = v1041;
                    break;
                }
                default: { // Some
                    std::array<Tuple5,5l> v1044 = v937.v.case1.v0; ap_uint<4l> v1045 = v937.v.case1.v1;
                    v1051 = US7_1(v1042, v1043);
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
    std::array<Tuple5,5l> v1057; ap_uint<4l> v1058;
    switch (v1051.tag) {
        case 0: { // None
            ap_uint<4l> v1054;
            v1054 = 0ul;
            v1057 = v86; v1058 = v1054;
            break;
        }
        default: { // Some
            std::array<Tuple5,5l> v1052 = v1051.v.case1.v0; ap_uint<4l> v1053 = v1051.v.case1.v1;
            v1057 = v1052; v1058 = v1053;
        }
    }
    return TupleCreate6(v1057, v1058);
}
int32_t entry() {
    std::random_device v0;
    std::mt19937 v1(v0());
    std::uniform_int_distribution<std::mt19937::result_type> v2(0l,51l);
    uint64_t v3; int32_t v4;
    Tuple0 tmp0 = TupleCreate0(0ull, 0l);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (while_method_0(v3)){
        std::array<Tuple1,7l> v6;
        uint64_t v7;
        v7 = 0ull;
        int32_t v8;
        v8 = 7l;
        while (while_method_1(v8)){
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
        Tuple2 tmp12 = score__0(v72);
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
        Tuple6 tmp121 = score_21(v89);
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
