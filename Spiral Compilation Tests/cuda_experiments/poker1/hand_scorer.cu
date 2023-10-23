#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177
#include <cstdint>
#include <array>
#include <random>
#include <iostream>
struct Card { uint8_t rank : 4; uint8_t suit : 2; };
#include <algorithm>
struct Tuple0;
struct Tuple1;
struct Tuple2;
struct Tuple3;
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
typedef bool (* Fun0)(Card, Card);
struct Tuple6;
struct US0;
struct US1;
struct US2;
struct US3;
struct Tuple7;
struct Tuple8;
struct US4;
struct Tuple9;
struct US5;
struct US6;
struct US7;
Tuple5 score_21(std::array<Card,7l> v0);
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
    std::array<Card,5l> v0;
    int8_t v1;
};
struct Tuple6 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    uint8_t v3;
};
struct US0 {
    union U {
        struct {
            std::array<Card,2l> v0;
            std::array<Card,5l> v1;
        } case1; // Some
        U() {}
    } v;
    char tag : 2;
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
    union U {
        struct {
            std::array<Card,5l> v0;
        } case1; // Some
        U() {}
    } v;
    char tag : 2;
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
    union U {
        struct {
            std::array<Card,2l> v0;
            std::array<Card,3l> v1;
        } case1; // Some
        U() {}
    } v;
    char tag : 2;
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
    union U {
        struct {
            std::array<Card,3l> v0;
            std::array<Card,4l> v1;
        } case1; // Some
        U() {}
    } v;
    char tag : 2;
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
struct Tuple7 {
    int32_t v0;
    int32_t v1;
    uint8_t v2;
};
struct Tuple8 {
    int32_t v0;
    int32_t v1;
};
struct US4 {
    union U {
        U() {}
    } v;
    char tag : 2;
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
struct Tuple9 {
    US4 v1;
    int32_t v0;
};
struct US5 {
    union U {
        struct {
            std::array<Card,2l> v0;
            std::array<Card,2l> v1;
        } case1; // Some
        U() {}
    } v;
    char tag : 2;
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
    union U {
        struct {
            std::array<Card,4l> v0;
            std::array<Card,3l> v1;
        } case1; // Some
        U() {}
    } v;
    char tag : 2;
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
    union U {
        struct {
            std::array<Card,5l> v0;
            int8_t v1;
        } case1; // Some
        U() {}
    } v;
    char tag : 2;
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
inline Tuple0 TupleCreate0(uint64_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_0(uint64_t v0){
    bool v1;
    v1 = v0 < 100000ull;
    return v1;
}
inline Tuple1 TupleCreate1(int8_t v0, int8_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_1(int32_t v0){
    bool v1;
    v1 = v0 > 0l;
    return v1;
}
inline Tuple2 TupleCreate2(int8_t v0, int8_t v1, int8_t v2, int8_t v3, int8_t v4, int8_t v5){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4; x.v5 = v5;
    return x;
}
inline Tuple3 TupleCreate3(int8_t v0, uint16_t v1){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_2(int8_t v0){
    bool v1;
    v1 = v0 < 13;
    return v1;
}
inline bool while_method_3(int8_t v0){
    bool v1;
    v1 = v0 < 4;
    return v1;
}
inline Tuple4 TupleCreate4(int8_t v0, uint64_t v1){
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
            v17 = (uint64_t)v16;
            uint64_t v18;
            v18 = 4294967296ull | v17;
            return v18;
        } else {
            int8_t v19;
            v19 = v2 - 1;
            return loop_pair_18(v0, v1, v19);
        }
    } else {
        int8_t v22;
        v22 = 12;
        int8_t v23;
        v23 = 5;
        uint32_t v24;
        v24 = 0ul;
        uint32_t v25;
        v25 = loop_ranks_19(v1, v22, v23, v24);
        uint64_t v26;
        v26 = (uint64_t)v25;
        uint64_t v27;
        v27 = 0ull | v26;
        return v27;
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
                v21 = (uint64_t)v20;
                uint64_t v22;
                v22 = 8589934592ull | v21;
                return v22;
            } else {
                int8_t v23;
                v23 = v4 - 1;
                return loop_pair_15(v0, v1, v2, v3, v23);
            }
        } else {
            int8_t v26;
            v26 = 12;
            return loop_pair_18(v0, v1, v26);
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
            v17 = (uint64_t)v16;
            uint64_t v18;
            v18 = 12884901888ull | v17;
            return v18;
        } else {
            int8_t v19;
            v19 = v2 - 1;
            return loop_triple_13(v0, v1, v19);
        }
    } else {
        int8_t v22;
        v22 = 12;
        return loop_pair__14(v0, v1, v22);
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
            v69 = (uint64_t)v68;
            uint64_t v70;
            v70 = 17179869184ull | v69;
            return v70;
        } else {
            int8_t v71;
            v71 = v2 - 1;
            return loop_12(v0, v1, v71);
        }
    } else {
        int8_t v74;
        v74 = 12;
        return loop_triple_13(v0, v1, v74);
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
                v19 = (uint64_t)v18;
                uint64_t v20;
                v20 = 25769803776ull | v19;
                return v20;
            } else {
                int8_t v21;
                v21 = v5 - 1;
                return loop_pair_9(v0, v1, v2, v3, v4, v21);
            }
        }
    } else {
        int8_t v25;
        v25 = 0;
        uint32_t v26;
        v26 = try_suit_10(v1, v2, v25);
        bool v27;
        v27 = v26 >= 0ul;
        uint32_t v28;
        if (v27){
            v28 = v26;
        } else {
            v28 = 0ul;
        }
        int8_t v29;
        v29 = 1;
        uint32_t v30;
        v30 = try_suit_10(v1, v2, v29);
        bool v31;
        v31 = v30 >= v28;
        uint32_t v32;
        if (v31){
            v32 = v30;
        } else {
            v32 = v28;
        }
        int8_t v33;
        v33 = 2;
        uint32_t v34;
        v34 = try_suit_10(v1, v2, v33);
        bool v35;
        v35 = v34 >= v32;
        uint32_t v36;
        if (v35){
            v36 = v34;
        } else {
            v36 = v32;
        }
        int8_t v37;
        v37 = 3;
        uint32_t v38;
        v38 = try_suit_10(v1, v2, v37);
        bool v39;
        v39 = v38 >= v36;
        uint32_t v40;
        if (v39){
            v40 = v38;
        } else {
            v40 = v36;
        }
        bool v41;
        v41 = 0ul < v40;
        if (v41){
            uint64_t v42;
            v42 = (uint64_t)v40;
            uint64_t v43;
            v43 = 21474836480ull | v42;
            return v43;
        } else {
            int8_t v44;
            v44 = 8;
            return loop_12(v0, v1, v44);
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
            v37 = (uint64_t)v35;
            uint64_t v38;
            v38 = 21474836480ull | v37;
            return v38;
        } else {
            int8_t v39;
            v39 = 8;
            return loop_12(v0, v1, v39);
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
            v18 = (uint64_t)v17;
            uint64_t v19;
            v19 = 30064771072ull | v18;
            return v19;
        } else {
            int8_t v20;
            v20 = v3 - 1;
            return loop_ranks_4(v0, v1, v2, v20);
        }
    } else {
        int8_t v23;
        v23 = 12;
        return loop_triple_8(v0, v1, v2, v23);
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
        v54 = (uint64_t)v52;
        uint64_t v55;
        v55 = 34359738368ull | v54;
        return v55;
    } else {
        int8_t v56;
        v56 = 12;
        return loop_ranks_4(v20, v0, v2, v56);
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
inline Tuple5 TupleCreate5(std::array<Card,5l> v0, int8_t v1){
    Tuple5 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_4(int32_t v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
bool ClosureMethod0(Card tup0, Card tup1){
    Card v0 = tup0; Card v1 = tup1;
    uint8_t v2;
    v2 = v0.rank;
    uint8_t v3;
    v3 = v1.rank;
    bool v4;
    v4 = v2 > v3;
    if (v4){
        return true;
    } else {
        uint8_t v5;
        v5 = v0.rank;
        uint8_t v6;
        v6 = v1.rank;
        bool v7;
        v7 = v5 == v6;
        if (v7){
            uint8_t v8;
            v8 = v0.suit;
            uint8_t v9;
            v9 = v1.suit;
            bool v10;
            v10 = v8 < v9;
            return v10;
        } else {
            return false;
        }
    }
}
inline bool while_method_5(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
inline Tuple6 TupleCreate6(int32_t v0, int32_t v1, int32_t v2, uint8_t v3){
    Tuple6 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3;
    return x;
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(std::array<Card,2l> v0, std::array<Card,5l> v1) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(std::array<Card,5l> v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
inline bool while_method_6(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
inline bool while_method_7(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1(std::array<Card,2l> v0, std::array<Card,3l> v1) { // Some
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
inline bool while_method_8(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1(std::array<Card,3l> v0, std::array<Card,4l> v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
inline bool while_method_9(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
inline Tuple7 TupleCreate7(int32_t v0, int32_t v1, uint8_t v2){
    Tuple7 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
inline Tuple8 TupleCreate8(int32_t v0, int32_t v1){
    Tuple8 x;
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
inline Tuple9 TupleCreate9(int32_t v0, US4 v1){
    Tuple9 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(std::array<Card,2l> v0, std::array<Card,2l> v1) { // Some
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
US6 US6_1(std::array<Card,4l> v0, std::array<Card,3l> v1) { // Some
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
US7 US7_1(std::array<Card,5l> v0, int8_t v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple5 score_21(std::array<Card,7l> v0){
    std::array<Card,7l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_4(v2)){
        Card v4;
        v4 = v0[v2];
        v1[v2] = v4;
        v2++;
    }
    Fun0 v5;
    v5 = ClosureMethod0;
    std::sort(v1.begin(),v1.end(),v5);
    std::array<Card,5l> v6;
    int32_t v7;
    v7 = 0l;
    while (while_method_5(v7)){
        Card v9;
        v9 = v1[v7];
        v6[v7] = v9;
        v7++;
    }
    std::array<Card,2l> v10;
    std::array<Card,5l> v11;
    int32_t v12; int32_t v13; int32_t v14; uint8_t v15;
    Tuple6 tmp13 = TupleCreate6(0l, 0l, 0l, 12u);
    v12 = tmp13.v0; v13 = tmp13.v1; v14 = tmp13.v2; v15 = tmp13.v3;
    while (while_method_4(v12)){
        Card v17;
        v17 = v1[v12];
        bool v18;
        v18 = v14 < 2l;
        int32_t v27; int32_t v28; uint8_t v29;
        if (v18){
            uint8_t v19;
            v19 = v17.rank;
            bool v20;
            v20 = v15 == v19;
            int32_t v21;
            if (v20){
                v21 = v14;
            } else {
                v21 = 0l;
            }
            v10[v21] = v17;
            int32_t v22;
            v22 = v21 + 1l;
            uint8_t v23;
            v23 = v17.rank;
            v27 = v12; v28 = v22; v29 = v23;
        } else {
            break;
        }
        v13 = v27;
        v14 = v28;
        v15 = v29;
        v12++;
    }
    bool v30;
    v30 = v14 == 2l;
    US0 v40;
    if (v30){
        int32_t v31;
        v31 = 0l;
        while (while_method_5(v31)){
            int32_t v33;
            v33 = v13 + -1l;
            bool v34;
            v34 = v31 < v33;
            int32_t v35;
            if (v34){
                v35 = 0l;
            } else {
                v35 = 2l;
            }
            int32_t v36;
            v36 = v35 + v31;
            Card v37;
            v37 = v1[v36];
            v11[v31] = v37;
            v31++;
        }
        v40 = US0_1(v10, v11);
    } else {
        v40 = US0_0();
    }
    US1 v59;
    switch (v40.tag) {
        case 0: { // None
            v59 = US1_0();
            break;
        }
        default: { // Some
            std::array<Card,2l> v41 = v40.v.case1.v0; std::array<Card,5l> v42 = v40.v.case1.v1;
            std::array<Card,3l> v43;
            int32_t v44;
            v44 = 0l;
            while (while_method_6(v44)){
                Card v46;
                v46 = v42[v44];
                v43[v44] = v46;
                v44++;
            }
            std::array<Card,0l> v47;
            std::array<Card,5l> v48;
            int32_t v49;
            v49 = 0l;
            while (while_method_7(v49)){
                Card v51;
                v51 = v41[v49];
                v48[v49] = v51;
                v49++;
            }
            int32_t v52;
            v52 = 0l;
            while (while_method_6(v52)){
                Card v54;
                v54 = v43[v52];
                int32_t v55;
                v55 = 2l + v52;
                v48[v55] = v54;
                v52++;
            }
            v59 = US1_1(v48);
        }
    }
    std::array<Card,2l> v60;
    std::array<Card,5l> v61;
    int32_t v62; int32_t v63; int32_t v64; uint8_t v65;
    Tuple6 tmp14 = TupleCreate6(0l, 0l, 0l, 12u);
    v62 = tmp14.v0; v63 = tmp14.v1; v64 = tmp14.v2; v65 = tmp14.v3;
    while (while_method_4(v62)){
        Card v67;
        v67 = v1[v62];
        bool v68;
        v68 = v64 < 2l;
        int32_t v77; int32_t v78; uint8_t v79;
        if (v68){
            uint8_t v69;
            v69 = v67.rank;
            bool v70;
            v70 = v65 == v69;
            int32_t v71;
            if (v70){
                v71 = v64;
            } else {
                v71 = 0l;
            }
            v60[v71] = v67;
            int32_t v72;
            v72 = v71 + 1l;
            uint8_t v73;
            v73 = v67.rank;
            v77 = v62; v78 = v72; v79 = v73;
        } else {
            break;
        }
        v63 = v77;
        v64 = v78;
        v65 = v79;
        v62++;
    }
    bool v80;
    v80 = v64 == 2l;
    US0 v90;
    if (v80){
        int32_t v81;
        v81 = 0l;
        while (while_method_5(v81)){
            int32_t v83;
            v83 = v63 + -1l;
            bool v84;
            v84 = v81 < v83;
            int32_t v85;
            if (v84){
                v85 = 0l;
            } else {
                v85 = 2l;
            }
            int32_t v86;
            v86 = v85 + v81;
            Card v87;
            v87 = v1[v86];
            v61[v81] = v87;
            v81++;
        }
        v90 = US0_1(v60, v61);
    } else {
        v90 = US0_0();
    }
    US1 v148;
    switch (v90.tag) {
        case 0: { // None
            v148 = US1_0();
            break;
        }
        default: { // Some
            std::array<Card,2l> v91 = v90.v.case1.v0; std::array<Card,5l> v92 = v90.v.case1.v1;
            std::array<Card,2l> v93;
            std::array<Card,3l> v94;
            int32_t v95; int32_t v96; int32_t v97; uint8_t v98;
            Tuple6 tmp15 = TupleCreate6(0l, 0l, 0l, 12u);
            v95 = tmp15.v0; v96 = tmp15.v1; v97 = tmp15.v2; v98 = tmp15.v3;
            while (while_method_5(v95)){
                Card v100;
                v100 = v92[v95];
                bool v101;
                v101 = v97 < 2l;
                int32_t v110; int32_t v111; uint8_t v112;
                if (v101){
                    uint8_t v102;
                    v102 = v100.rank;
                    bool v103;
                    v103 = v98 == v102;
                    int32_t v104;
                    if (v103){
                        v104 = v97;
                    } else {
                        v104 = 0l;
                    }
                    v93[v104] = v100;
                    int32_t v105;
                    v105 = v104 + 1l;
                    uint8_t v106;
                    v106 = v100.rank;
                    v110 = v95; v111 = v105; v112 = v106;
                } else {
                    break;
                }
                v96 = v110;
                v97 = v111;
                v98 = v112;
                v95++;
            }
            bool v113;
            v113 = v97 == 2l;
            US2 v123;
            if (v113){
                int32_t v114;
                v114 = 0l;
                while (while_method_6(v114)){
                    int32_t v116;
                    v116 = v96 + -1l;
                    bool v117;
                    v117 = v114 < v116;
                    int32_t v118;
                    if (v117){
                        v118 = 0l;
                    } else {
                        v118 = 2l;
                    }
                    int32_t v119;
                    v119 = v118 + v114;
                    Card v120;
                    v120 = v92[v119];
                    v94[v114] = v120;
                    v114++;
                }
                v123 = US2_1(v93, v94);
            } else {
                v123 = US2_0();
            }
            switch (v123.tag) {
                case 0: { // None
                    v148 = US1_0();
                    break;
                }
                default: { // Some
                    std::array<Card,2l> v124 = v123.v.case1.v0; std::array<Card,3l> v125 = v123.v.case1.v1;
                    std::array<Card,1l> v126;
                    int32_t v127;
                    v127 = 0l;
                    while (while_method_8(v127)){
                        Card v129;
                        v129 = v125[v127];
                        v126[v127] = v129;
                        v127++;
                    }
                    std::array<Card,5l> v130;
                    int32_t v131;
                    v131 = 0l;
                    while (while_method_7(v131)){
                        Card v133;
                        v133 = v91[v131];
                        v130[v131] = v133;
                        v131++;
                    }
                    int32_t v134;
                    v134 = 0l;
                    while (while_method_7(v134)){
                        Card v136;
                        v136 = v124[v134];
                        int32_t v137;
                        v137 = 2l + v134;
                        v130[v137] = v136;
                        v134++;
                    }
                    int32_t v138;
                    v138 = 0l;
                    while (while_method_8(v138)){
                        Card v140;
                        v140 = v126[v138];
                        int32_t v141;
                        v141 = 4l + v138;
                        v130[v141] = v140;
                        v138++;
                    }
                    v148 = US1_1(v130);
                }
            }
        }
    }
    std::array<Card,3l> v149;
    std::array<Card,4l> v150;
    int32_t v151; int32_t v152; int32_t v153; uint8_t v154;
    Tuple6 tmp16 = TupleCreate6(0l, 0l, 0l, 12u);
    v151 = tmp16.v0; v152 = tmp16.v1; v153 = tmp16.v2; v154 = tmp16.v3;
    while (while_method_4(v151)){
        Card v156;
        v156 = v1[v151];
        bool v157;
        v157 = v153 < 3l;
        int32_t v166; int32_t v167; uint8_t v168;
        if (v157){
            uint8_t v158;
            v158 = v156.rank;
            bool v159;
            v159 = v154 == v158;
            int32_t v160;
            if (v159){
                v160 = v153;
            } else {
                v160 = 0l;
            }
            v149[v160] = v156;
            int32_t v161;
            v161 = v160 + 1l;
            uint8_t v162;
            v162 = v156.rank;
            v166 = v151; v167 = v161; v168 = v162;
        } else {
            break;
        }
        v152 = v166;
        v153 = v167;
        v154 = v168;
        v151++;
    }
    bool v169;
    v169 = v153 == 3l;
    US3 v179;
    if (v169){
        int32_t v170;
        v170 = 0l;
        while (while_method_9(v170)){
            int32_t v172;
            v172 = v152 + -2l;
            bool v173;
            v173 = v170 < v172;
            int32_t v174;
            if (v173){
                v174 = 0l;
            } else {
                v174 = 3l;
            }
            int32_t v175;
            v175 = v174 + v170;
            Card v176;
            v176 = v1[v175];
            v150[v170] = v176;
            v170++;
        }
        v179 = US3_1(v149, v150);
    } else {
        v179 = US3_0();
    }
    US1 v198;
    switch (v179.tag) {
        case 0: { // None
            v198 = US1_0();
            break;
        }
        default: { // Some
            std::array<Card,3l> v180 = v179.v.case1.v0; std::array<Card,4l> v181 = v179.v.case1.v1;
            std::array<Card,2l> v182;
            int32_t v183;
            v183 = 0l;
            while (while_method_7(v183)){
                Card v185;
                v185 = v181[v183];
                v182[v183] = v185;
                v183++;
            }
            std::array<Card,0l> v186;
            std::array<Card,5l> v187;
            int32_t v188;
            v188 = 0l;
            while (while_method_6(v188)){
                Card v190;
                v190 = v180[v188];
                v187[v188] = v190;
                v188++;
            }
            int32_t v191;
            v191 = 0l;
            while (while_method_7(v191)){
                Card v193;
                v193 = v182[v191];
                int32_t v194;
                v194 = 3l + v191;
                v187[v194] = v193;
                v191++;
            }
            v198 = US1_1(v187);
        }
    }
    std::array<Card,5l> v199;
    int32_t v200; int32_t v201; uint8_t v202;
    Tuple7 tmp17 = TupleCreate7(0l, 0l, 12u);
    v200 = tmp17.v0; v201 = tmp17.v1; v202 = tmp17.v2;
    while (while_method_4(v200)){
        Card v204;
        v204 = v1[v200];
        bool v205;
        v205 = v201 < 5l;
        int32_t v220; uint8_t v221;
        if (v205){
            uint8_t v206;
            v206 = v204.rank;
            uint8_t v207;
            v207 = v206 - 1u;
            bool v208;
            v208 = v202 == v207;
            bool v209;
            v209 = v208 != true;
            if (v209){
                uint8_t v210;
                v210 = v204.rank;
                bool v211;
                v211 = v202 == v210;
                int32_t v212;
                if (v211){
                    v212 = v201;
                } else {
                    v212 = 0l;
                }
                v199[v212] = v204;
                int32_t v213;
                v213 = v212 + 1l;
                uint8_t v214;
                v214 = v204.rank;
                uint8_t v215;
                v215 = v214 - 1u;
                v220 = v213; v221 = v215;
            } else {
                v220 = v201; v221 = v202;
            }
        } else {
            break;
        }
        v201 = v220;
        v202 = v221;
        v200++;
    }
    bool v222;
    v222 = v201 == 4l;
    bool v230;
    if (v222){
        uint8_t v223;
        v223 = v202 + 1u;
        bool v224;
        v224 = v223 == 0u;
        if (v224){
            Card v225;
            v225 = v1[0l];
            uint8_t v226;
            v226 = v225.rank;
            bool v227;
            v227 = v226 == 12u;
            if (v227){
                v199[4l] = v225;
                v230 = true;
            } else {
                v230 = false;
            }
        } else {
            v230 = false;
        }
    } else {
        v230 = false;
    }
    US1 v236;
    if (v230){
        v236 = US1_1(v199);
    } else {
        bool v232;
        v232 = v201 == 5l;
        if (v232){
            v236 = US1_1(v199);
        } else {
            v236 = US1_0();
        }
    }
    std::array<Card,5l> v237;
    int32_t v238; int32_t v239;
    Tuple8 tmp18 = TupleCreate8(0l, 0l);
    v238 = tmp18.v0; v239 = tmp18.v1;
    while (while_method_4(v238)){
        Card v241;
        v241 = v1[v238];
        uint8_t v242;
        v242 = v241.suit;
        bool v243;
        v243 = v242 == 3u;
        bool v245;
        if (v243){
            bool v244;
            v244 = v239 < 5l;
            v245 = v244;
        } else {
            v245 = false;
        }
        int32_t v247;
        if (v245){
            v237[v239] = v241;
            int32_t v246;
            v246 = v239 + 1l;
            v247 = v246;
        } else {
            v247 = v239;
        }
        v239 = v247;
        v238++;
    }
    bool v248;
    v248 = v239 == 5l;
    US1 v251;
    if (v248){
        v251 = US1_1(v237);
    } else {
        v251 = US1_0();
    }
    std::array<Card,5l> v252;
    int32_t v253; int32_t v254;
    Tuple8 tmp19 = TupleCreate8(0l, 0l);
    v253 = tmp19.v0; v254 = tmp19.v1;
    while (while_method_4(v253)){
        Card v256;
        v256 = v1[v253];
        uint8_t v257;
        v257 = v256.suit;
        bool v258;
        v258 = v257 == 2u;
        bool v260;
        if (v258){
            bool v259;
            v259 = v254 < 5l;
            v260 = v259;
        } else {
            v260 = false;
        }
        int32_t v262;
        if (v260){
            v252[v254] = v256;
            int32_t v261;
            v261 = v254 + 1l;
            v262 = v261;
        } else {
            v262 = v254;
        }
        v254 = v262;
        v253++;
    }
    bool v263;
    v263 = v254 == 5l;
    US1 v266;
    if (v263){
        v266 = US1_1(v252);
    } else {
        v266 = US1_0();
    }
    std::array<Card,5l> v267;
    int32_t v268; int32_t v269;
    Tuple8 tmp20 = TupleCreate8(0l, 0l);
    v268 = tmp20.v0; v269 = tmp20.v1;
    while (while_method_4(v268)){
        Card v271;
        v271 = v1[v268];
        uint8_t v272;
        v272 = v271.suit;
        bool v273;
        v273 = v272 == 1u;
        bool v275;
        if (v273){
            bool v274;
            v274 = v269 < 5l;
            v275 = v274;
        } else {
            v275 = false;
        }
        int32_t v277;
        if (v275){
            v267[v269] = v271;
            int32_t v276;
            v276 = v269 + 1l;
            v277 = v276;
        } else {
            v277 = v269;
        }
        v269 = v277;
        v268++;
    }
    bool v278;
    v278 = v269 == 5l;
    US1 v281;
    if (v278){
        v281 = US1_1(v267);
    } else {
        v281 = US1_0();
    }
    std::array<Card,5l> v282;
    int32_t v283; int32_t v284;
    Tuple8 tmp21 = TupleCreate8(0l, 0l);
    v283 = tmp21.v0; v284 = tmp21.v1;
    while (while_method_4(v283)){
        Card v286;
        v286 = v1[v283];
        uint8_t v287;
        v287 = v286.suit;
        bool v288;
        v288 = v287 == 0u;
        bool v290;
        if (v288){
            bool v289;
            v289 = v284 < 5l;
            v290 = v289;
        } else {
            v290 = false;
        }
        int32_t v292;
        if (v290){
            v282[v284] = v286;
            int32_t v291;
            v291 = v284 + 1l;
            v292 = v291;
        } else {
            v292 = v284;
        }
        v284 = v292;
        v283++;
    }
    bool v293;
    v293 = v284 == 5l;
    US1 v296;
    if (v293){
        v296 = US1_1(v282);
    } else {
        v296 = US1_0();
    }
    US1 v322;
    switch (v296.tag) {
        case 0: { // None
            v322 = v281;
            break;
        }
        default: { // Some
            std::array<Card,5l> v297 = v296.v.case1.v0;
            switch (v281.tag) {
                case 0: { // None
                    v322 = v296;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v298 = v281.v.case1.v0;
                    US4 v299;
                    v299 = US4_0();
                    int32_t v300; US4 v301;
                    Tuple9 tmp22 = TupleCreate9(0l, v299);
                    v300 = tmp22.v0; v301 = tmp22.v1;
                    while (while_method_5(v300)){
                        Card v303;
                        v303 = v297[v300];
                        Card v304;
                        v304 = v298[v300];
                        US4 v315;
                        switch (v301.tag) {
                            case 0: { // Eq
                                uint8_t v305;
                                v305 = v303.rank;
                                uint8_t v306;
                                v306 = v304.rank;
                                bool v307;
                                v307 = v305 < v306;
                                if (v307){
                                    v315 = US4_2();
                                } else {
                                    bool v309;
                                    v309 = v305 > v306;
                                    if (v309){
                                        v315 = US4_1();
                                    } else {
                                        v315 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v301 = v315;
                        v300++;
                    }
                    bool v316;
                    switch (v301.tag) {
                        case 1: { // Gt
                            v316 = true;
                            break;
                        }
                        default: {
                            v316 = false;
                        }
                    }
                    std::array<Card,5l> v317;
                    if (v316){
                        v317 = v297;
                    } else {
                        v317 = v298;
                    }
                    v322 = US1_1(v317);
                }
            }
        }
    }
    US1 v348;
    switch (v322.tag) {
        case 0: { // None
            v348 = v266;
            break;
        }
        default: { // Some
            std::array<Card,5l> v323 = v322.v.case1.v0;
            switch (v266.tag) {
                case 0: { // None
                    v348 = v322;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v324 = v266.v.case1.v0;
                    US4 v325;
                    v325 = US4_0();
                    int32_t v326; US4 v327;
                    Tuple9 tmp23 = TupleCreate9(0l, v325);
                    v326 = tmp23.v0; v327 = tmp23.v1;
                    while (while_method_5(v326)){
                        Card v329;
                        v329 = v323[v326];
                        Card v330;
                        v330 = v324[v326];
                        US4 v341;
                        switch (v327.tag) {
                            case 0: { // Eq
                                uint8_t v331;
                                v331 = v329.rank;
                                uint8_t v332;
                                v332 = v330.rank;
                                bool v333;
                                v333 = v331 < v332;
                                if (v333){
                                    v341 = US4_2();
                                } else {
                                    bool v335;
                                    v335 = v331 > v332;
                                    if (v335){
                                        v341 = US4_1();
                                    } else {
                                        v341 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v327 = v341;
                        v326++;
                    }
                    bool v342;
                    switch (v327.tag) {
                        case 1: { // Gt
                            v342 = true;
                            break;
                        }
                        default: {
                            v342 = false;
                        }
                    }
                    std::array<Card,5l> v343;
                    if (v342){
                        v343 = v323;
                    } else {
                        v343 = v324;
                    }
                    v348 = US1_1(v343);
                }
            }
        }
    }
    US1 v374;
    switch (v348.tag) {
        case 0: { // None
            v374 = v251;
            break;
        }
        default: { // Some
            std::array<Card,5l> v349 = v348.v.case1.v0;
            switch (v251.tag) {
                case 0: { // None
                    v374 = v348;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v350 = v251.v.case1.v0;
                    US4 v351;
                    v351 = US4_0();
                    int32_t v352; US4 v353;
                    Tuple9 tmp24 = TupleCreate9(0l, v351);
                    v352 = tmp24.v0; v353 = tmp24.v1;
                    while (while_method_5(v352)){
                        Card v355;
                        v355 = v349[v352];
                        Card v356;
                        v356 = v350[v352];
                        US4 v367;
                        switch (v353.tag) {
                            case 0: { // Eq
                                uint8_t v357;
                                v357 = v355.rank;
                                uint8_t v358;
                                v358 = v356.rank;
                                bool v359;
                                v359 = v357 < v358;
                                if (v359){
                                    v367 = US4_2();
                                } else {
                                    bool v361;
                                    v361 = v357 > v358;
                                    if (v361){
                                        v367 = US4_1();
                                    } else {
                                        v367 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v353 = v367;
                        v352++;
                    }
                    bool v368;
                    switch (v353.tag) {
                        case 1: { // Gt
                            v368 = true;
                            break;
                        }
                        default: {
                            v368 = false;
                        }
                    }
                    std::array<Card,5l> v369;
                    if (v368){
                        v369 = v349;
                    } else {
                        v369 = v350;
                    }
                    v374 = US1_1(v369);
                }
            }
        }
    }
    std::array<Card,3l> v375;
    std::array<Card,4l> v376;
    int32_t v377; int32_t v378; int32_t v379; uint8_t v380;
    Tuple6 tmp25 = TupleCreate6(0l, 0l, 0l, 12u);
    v377 = tmp25.v0; v378 = tmp25.v1; v379 = tmp25.v2; v380 = tmp25.v3;
    while (while_method_4(v377)){
        Card v382;
        v382 = v1[v377];
        bool v383;
        v383 = v379 < 3l;
        int32_t v392; int32_t v393; uint8_t v394;
        if (v383){
            uint8_t v384;
            v384 = v382.rank;
            bool v385;
            v385 = v380 == v384;
            int32_t v386;
            if (v385){
                v386 = v379;
            } else {
                v386 = 0l;
            }
            v375[v386] = v382;
            int32_t v387;
            v387 = v386 + 1l;
            uint8_t v388;
            v388 = v382.rank;
            v392 = v377; v393 = v387; v394 = v388;
        } else {
            break;
        }
        v378 = v392;
        v379 = v393;
        v380 = v394;
        v377++;
    }
    bool v395;
    v395 = v379 == 3l;
    US3 v405;
    if (v395){
        int32_t v396;
        v396 = 0l;
        while (while_method_9(v396)){
            int32_t v398;
            v398 = v378 + -2l;
            bool v399;
            v399 = v396 < v398;
            int32_t v400;
            if (v399){
                v400 = 0l;
            } else {
                v400 = 3l;
            }
            int32_t v401;
            v401 = v400 + v396;
            Card v402;
            v402 = v1[v401];
            v376[v396] = v402;
            v396++;
        }
        v405 = US3_1(v375, v376);
    } else {
        v405 = US3_0();
    }
    US1 v456;
    switch (v405.tag) {
        case 0: { // None
            v456 = US1_0();
            break;
        }
        default: { // Some
            std::array<Card,3l> v406 = v405.v.case1.v0; std::array<Card,4l> v407 = v405.v.case1.v1;
            std::array<Card,2l> v408;
            std::array<Card,2l> v409;
            int32_t v410; int32_t v411; int32_t v412; uint8_t v413;
            Tuple6 tmp26 = TupleCreate6(0l, 0l, 0l, 12u);
            v410 = tmp26.v0; v411 = tmp26.v1; v412 = tmp26.v2; v413 = tmp26.v3;
            while (while_method_9(v410)){
                Card v415;
                v415 = v407[v410];
                bool v416;
                v416 = v412 < 2l;
                int32_t v425; int32_t v426; uint8_t v427;
                if (v416){
                    uint8_t v417;
                    v417 = v415.rank;
                    bool v418;
                    v418 = v413 == v417;
                    int32_t v419;
                    if (v418){
                        v419 = v412;
                    } else {
                        v419 = 0l;
                    }
                    v408[v419] = v415;
                    int32_t v420;
                    v420 = v419 + 1l;
                    uint8_t v421;
                    v421 = v415.rank;
                    v425 = v410; v426 = v420; v427 = v421;
                } else {
                    break;
                }
                v411 = v425;
                v412 = v426;
                v413 = v427;
                v410++;
            }
            bool v428;
            v428 = v412 == 2l;
            US5 v438;
            if (v428){
                int32_t v429;
                v429 = 0l;
                while (while_method_7(v429)){
                    int32_t v431;
                    v431 = v411 + -1l;
                    bool v432;
                    v432 = v429 < v431;
                    int32_t v433;
                    if (v432){
                        v433 = 0l;
                    } else {
                        v433 = 2l;
                    }
                    int32_t v434;
                    v434 = v433 + v429;
                    Card v435;
                    v435 = v407[v434];
                    v409[v429] = v435;
                    v429++;
                }
                v438 = US5_1(v408, v409);
            } else {
                v438 = US5_0();
            }
            switch (v438.tag) {
                case 0: { // None
                    v456 = US1_0();
                    break;
                }
                default: { // Some
                    std::array<Card,2l> v439 = v438.v.case1.v0; std::array<Card,2l> v440 = v438.v.case1.v1;
                    std::array<Card,0l> v441;
                    std::array<Card,5l> v442;
                    int32_t v443;
                    v443 = 0l;
                    while (while_method_6(v443)){
                        Card v445;
                        v445 = v406[v443];
                        v442[v443] = v445;
                        v443++;
                    }
                    int32_t v446;
                    v446 = 0l;
                    while (while_method_7(v446)){
                        Card v448;
                        v448 = v439[v446];
                        int32_t v449;
                        v449 = 3l + v446;
                        v442[v449] = v448;
                        v446++;
                    }
                    v456 = US1_1(v442);
                }
            }
        }
    }
    std::array<Card,4l> v457;
    std::array<Card,3l> v458;
    int32_t v459; int32_t v460; int32_t v461; uint8_t v462;
    Tuple6 tmp27 = TupleCreate6(0l, 0l, 0l, 12u);
    v459 = tmp27.v0; v460 = tmp27.v1; v461 = tmp27.v2; v462 = tmp27.v3;
    while (while_method_4(v459)){
        Card v464;
        v464 = v1[v459];
        bool v465;
        v465 = v461 < 4l;
        int32_t v474; int32_t v475; uint8_t v476;
        if (v465){
            uint8_t v466;
            v466 = v464.rank;
            bool v467;
            v467 = v462 == v466;
            int32_t v468;
            if (v467){
                v468 = v461;
            } else {
                v468 = 0l;
            }
            v457[v468] = v464;
            int32_t v469;
            v469 = v468 + 1l;
            uint8_t v470;
            v470 = v464.rank;
            v474 = v459; v475 = v469; v476 = v470;
        } else {
            break;
        }
        v460 = v474;
        v461 = v475;
        v462 = v476;
        v459++;
    }
    bool v477;
    v477 = v461 == 4l;
    US6 v487;
    if (v477){
        int32_t v478;
        v478 = 0l;
        while (while_method_6(v478)){
            int32_t v480;
            v480 = v460 + -3l;
            bool v481;
            v481 = v478 < v480;
            int32_t v482;
            if (v481){
                v482 = 0l;
            } else {
                v482 = 4l;
            }
            int32_t v483;
            v483 = v482 + v478;
            Card v484;
            v484 = v1[v483];
            v458[v478] = v484;
            v478++;
        }
        v487 = US6_1(v457, v458);
    } else {
        v487 = US6_0();
    }
    US1 v506;
    switch (v487.tag) {
        case 0: { // None
            v506 = US1_0();
            break;
        }
        default: { // Some
            std::array<Card,4l> v488 = v487.v.case1.v0; std::array<Card,3l> v489 = v487.v.case1.v1;
            std::array<Card,1l> v490;
            int32_t v491;
            v491 = 0l;
            while (while_method_8(v491)){
                Card v493;
                v493 = v489[v491];
                v490[v491] = v493;
                v491++;
            }
            std::array<Card,0l> v494;
            std::array<Card,5l> v495;
            int32_t v496;
            v496 = 0l;
            while (while_method_9(v496)){
                Card v498;
                v498 = v488[v496];
                v495[v496] = v498;
                v496++;
            }
            int32_t v499;
            v499 = 0l;
            while (while_method_8(v499)){
                Card v501;
                v501 = v490[v499];
                int32_t v502;
                v502 = 4l + v499;
                v495[v502] = v501;
                v499++;
            }
            v506 = US1_1(v495);
        }
    }
    std::array<Card,5l> v507;
    int32_t v508; int32_t v509; uint8_t v510;
    Tuple7 tmp28 = TupleCreate7(0l, 0l, 12u);
    v508 = tmp28.v0; v509 = tmp28.v1; v510 = tmp28.v2;
    while (while_method_4(v508)){
        Card v512;
        v512 = v1[v508];
        bool v513;
        v513 = v509 < 5l;
        int32_t v526; uint8_t v527;
        if (v513){
            uint8_t v514;
            v514 = v512.suit;
            bool v515;
            v515 = 3u == v514;
            if (v515){
                uint8_t v516;
                v516 = v512.rank;
                bool v517;
                v517 = v510 == v516;
                int32_t v518;
                if (v517){
                    v518 = v509;
                } else {
                    v518 = 0l;
                }
                v507[v518] = v512;
                int32_t v519;
                v519 = v518 + 1l;
                uint8_t v520;
                v520 = v512.rank;
                uint8_t v521;
                v521 = v520 - 1u;
                v526 = v519; v527 = v521;
            } else {
                v526 = v509; v527 = v510;
            }
        } else {
            break;
        }
        v509 = v526;
        v510 = v527;
        v508++;
    }
    bool v528;
    v528 = v509 == 4l;
    bool v563;
    if (v528){
        uint8_t v529;
        v529 = v510 + 1u;
        bool v530;
        v530 = v529 == 0u;
        if (v530){
            Card v531;
            v531 = v1[0l];
            uint8_t v532;
            v532 = v531.suit;
            bool v533;
            v533 = 3u == v532;
            bool v537;
            if (v533){
                uint8_t v534;
                v534 = v531.rank;
                bool v535;
                v535 = v534 == 12u;
                if (v535){
                    v507[4l] = v531;
                    v537 = true;
                } else {
                    v537 = false;
                }
            } else {
                v537 = false;
            }
            if (v537){
                v563 = true;
            } else {
                Card v538;
                v538 = v1[1l];
                uint8_t v539;
                v539 = v538.suit;
                bool v540;
                v540 = 3u == v539;
                bool v544;
                if (v540){
                    uint8_t v541;
                    v541 = v538.rank;
                    bool v542;
                    v542 = v541 == 12u;
                    if (v542){
                        v507[4l] = v538;
                        v544 = true;
                    } else {
                        v544 = false;
                    }
                } else {
                    v544 = false;
                }
                if (v544){
                    v563 = true;
                } else {
                    Card v545;
                    v545 = v1[2l];
                    uint8_t v546;
                    v546 = v545.suit;
                    bool v547;
                    v547 = 3u == v546;
                    bool v551;
                    if (v547){
                        uint8_t v548;
                        v548 = v545.rank;
                        bool v549;
                        v549 = v548 == 12u;
                        if (v549){
                            v507[4l] = v545;
                            v551 = true;
                        } else {
                            v551 = false;
                        }
                    } else {
                        v551 = false;
                    }
                    if (v551){
                        v563 = true;
                    } else {
                        Card v552;
                        v552 = v1[3l];
                        uint8_t v553;
                        v553 = v552.suit;
                        bool v554;
                        v554 = 3u == v553;
                        if (v554){
                            uint8_t v555;
                            v555 = v552.rank;
                            bool v556;
                            v556 = v555 == 12u;
                            if (v556){
                                v507[4l] = v552;
                                v563 = true;
                            } else {
                                v563 = false;
                            }
                        } else {
                            v563 = false;
                        }
                    }
                }
            }
        } else {
            v563 = false;
        }
    } else {
        v563 = false;
    }
    US1 v569;
    if (v563){
        v569 = US1_1(v507);
    } else {
        bool v565;
        v565 = v509 == 5l;
        if (v565){
            v569 = US1_1(v507);
        } else {
            v569 = US1_0();
        }
    }
    std::array<Card,5l> v570;
    int32_t v571; int32_t v572; uint8_t v573;
    Tuple7 tmp29 = TupleCreate7(0l, 0l, 12u);
    v571 = tmp29.v0; v572 = tmp29.v1; v573 = tmp29.v2;
    while (while_method_4(v571)){
        Card v575;
        v575 = v1[v571];
        bool v576;
        v576 = v572 < 5l;
        int32_t v589; uint8_t v590;
        if (v576){
            uint8_t v577;
            v577 = v575.suit;
            bool v578;
            v578 = 2u == v577;
            if (v578){
                uint8_t v579;
                v579 = v575.rank;
                bool v580;
                v580 = v573 == v579;
                int32_t v581;
                if (v580){
                    v581 = v572;
                } else {
                    v581 = 0l;
                }
                v570[v581] = v575;
                int32_t v582;
                v582 = v581 + 1l;
                uint8_t v583;
                v583 = v575.rank;
                uint8_t v584;
                v584 = v583 - 1u;
                v589 = v582; v590 = v584;
            } else {
                v589 = v572; v590 = v573;
            }
        } else {
            break;
        }
        v572 = v589;
        v573 = v590;
        v571++;
    }
    bool v591;
    v591 = v572 == 4l;
    bool v626;
    if (v591){
        uint8_t v592;
        v592 = v573 + 1u;
        bool v593;
        v593 = v592 == 0u;
        if (v593){
            Card v594;
            v594 = v1[0l];
            uint8_t v595;
            v595 = v594.suit;
            bool v596;
            v596 = 2u == v595;
            bool v600;
            if (v596){
                uint8_t v597;
                v597 = v594.rank;
                bool v598;
                v598 = v597 == 12u;
                if (v598){
                    v570[4l] = v594;
                    v600 = true;
                } else {
                    v600 = false;
                }
            } else {
                v600 = false;
            }
            if (v600){
                v626 = true;
            } else {
                Card v601;
                v601 = v1[1l];
                uint8_t v602;
                v602 = v601.suit;
                bool v603;
                v603 = 2u == v602;
                bool v607;
                if (v603){
                    uint8_t v604;
                    v604 = v601.rank;
                    bool v605;
                    v605 = v604 == 12u;
                    if (v605){
                        v570[4l] = v601;
                        v607 = true;
                    } else {
                        v607 = false;
                    }
                } else {
                    v607 = false;
                }
                if (v607){
                    v626 = true;
                } else {
                    Card v608;
                    v608 = v1[2l];
                    uint8_t v609;
                    v609 = v608.suit;
                    bool v610;
                    v610 = 2u == v609;
                    bool v614;
                    if (v610){
                        uint8_t v611;
                        v611 = v608.rank;
                        bool v612;
                        v612 = v611 == 12u;
                        if (v612){
                            v570[4l] = v608;
                            v614 = true;
                        } else {
                            v614 = false;
                        }
                    } else {
                        v614 = false;
                    }
                    if (v614){
                        v626 = true;
                    } else {
                        Card v615;
                        v615 = v1[3l];
                        uint8_t v616;
                        v616 = v615.suit;
                        bool v617;
                        v617 = 2u == v616;
                        if (v617){
                            uint8_t v618;
                            v618 = v615.rank;
                            bool v619;
                            v619 = v618 == 12u;
                            if (v619){
                                v570[4l] = v615;
                                v626 = true;
                            } else {
                                v626 = false;
                            }
                        } else {
                            v626 = false;
                        }
                    }
                }
            }
        } else {
            v626 = false;
        }
    } else {
        v626 = false;
    }
    US1 v632;
    if (v626){
        v632 = US1_1(v570);
    } else {
        bool v628;
        v628 = v572 == 5l;
        if (v628){
            v632 = US1_1(v570);
        } else {
            v632 = US1_0();
        }
    }
    std::array<Card,5l> v633;
    int32_t v634; int32_t v635; uint8_t v636;
    Tuple7 tmp30 = TupleCreate7(0l, 0l, 12u);
    v634 = tmp30.v0; v635 = tmp30.v1; v636 = tmp30.v2;
    while (while_method_4(v634)){
        Card v638;
        v638 = v1[v634];
        bool v639;
        v639 = v635 < 5l;
        int32_t v652; uint8_t v653;
        if (v639){
            uint8_t v640;
            v640 = v638.suit;
            bool v641;
            v641 = 1u == v640;
            if (v641){
                uint8_t v642;
                v642 = v638.rank;
                bool v643;
                v643 = v636 == v642;
                int32_t v644;
                if (v643){
                    v644 = v635;
                } else {
                    v644 = 0l;
                }
                v633[v644] = v638;
                int32_t v645;
                v645 = v644 + 1l;
                uint8_t v646;
                v646 = v638.rank;
                uint8_t v647;
                v647 = v646 - 1u;
                v652 = v645; v653 = v647;
            } else {
                v652 = v635; v653 = v636;
            }
        } else {
            break;
        }
        v635 = v652;
        v636 = v653;
        v634++;
    }
    bool v654;
    v654 = v635 == 4l;
    bool v689;
    if (v654){
        uint8_t v655;
        v655 = v636 + 1u;
        bool v656;
        v656 = v655 == 0u;
        if (v656){
            Card v657;
            v657 = v1[0l];
            uint8_t v658;
            v658 = v657.suit;
            bool v659;
            v659 = 1u == v658;
            bool v663;
            if (v659){
                uint8_t v660;
                v660 = v657.rank;
                bool v661;
                v661 = v660 == 12u;
                if (v661){
                    v633[4l] = v657;
                    v663 = true;
                } else {
                    v663 = false;
                }
            } else {
                v663 = false;
            }
            if (v663){
                v689 = true;
            } else {
                Card v664;
                v664 = v1[1l];
                uint8_t v665;
                v665 = v664.suit;
                bool v666;
                v666 = 1u == v665;
                bool v670;
                if (v666){
                    uint8_t v667;
                    v667 = v664.rank;
                    bool v668;
                    v668 = v667 == 12u;
                    if (v668){
                        v633[4l] = v664;
                        v670 = true;
                    } else {
                        v670 = false;
                    }
                } else {
                    v670 = false;
                }
                if (v670){
                    v689 = true;
                } else {
                    Card v671;
                    v671 = v1[2l];
                    uint8_t v672;
                    v672 = v671.suit;
                    bool v673;
                    v673 = 1u == v672;
                    bool v677;
                    if (v673){
                        uint8_t v674;
                        v674 = v671.rank;
                        bool v675;
                        v675 = v674 == 12u;
                        if (v675){
                            v633[4l] = v671;
                            v677 = true;
                        } else {
                            v677 = false;
                        }
                    } else {
                        v677 = false;
                    }
                    if (v677){
                        v689 = true;
                    } else {
                        Card v678;
                        v678 = v1[3l];
                        uint8_t v679;
                        v679 = v678.suit;
                        bool v680;
                        v680 = 1u == v679;
                        if (v680){
                            uint8_t v681;
                            v681 = v678.rank;
                            bool v682;
                            v682 = v681 == 12u;
                            if (v682){
                                v633[4l] = v678;
                                v689 = true;
                            } else {
                                v689 = false;
                            }
                        } else {
                            v689 = false;
                        }
                    }
                }
            }
        } else {
            v689 = false;
        }
    } else {
        v689 = false;
    }
    US1 v695;
    if (v689){
        v695 = US1_1(v633);
    } else {
        bool v691;
        v691 = v635 == 5l;
        if (v691){
            v695 = US1_1(v633);
        } else {
            v695 = US1_0();
        }
    }
    std::array<Card,5l> v696;
    int32_t v697; int32_t v698; uint8_t v699;
    Tuple7 tmp31 = TupleCreate7(0l, 0l, 12u);
    v697 = tmp31.v0; v698 = tmp31.v1; v699 = tmp31.v2;
    while (while_method_4(v697)){
        Card v701;
        v701 = v1[v697];
        bool v702;
        v702 = v698 < 5l;
        int32_t v715; uint8_t v716;
        if (v702){
            uint8_t v703;
            v703 = v701.suit;
            bool v704;
            v704 = 0u == v703;
            if (v704){
                uint8_t v705;
                v705 = v701.rank;
                bool v706;
                v706 = v699 == v705;
                int32_t v707;
                if (v706){
                    v707 = v698;
                } else {
                    v707 = 0l;
                }
                v696[v707] = v701;
                int32_t v708;
                v708 = v707 + 1l;
                uint8_t v709;
                v709 = v701.rank;
                uint8_t v710;
                v710 = v709 - 1u;
                v715 = v708; v716 = v710;
            } else {
                v715 = v698; v716 = v699;
            }
        } else {
            break;
        }
        v698 = v715;
        v699 = v716;
        v697++;
    }
    bool v717;
    v717 = v698 == 4l;
    bool v752;
    if (v717){
        uint8_t v718;
        v718 = v699 + 1u;
        bool v719;
        v719 = v718 == 0u;
        if (v719){
            Card v720;
            v720 = v1[0l];
            uint8_t v721;
            v721 = v720.suit;
            bool v722;
            v722 = 0u == v721;
            bool v726;
            if (v722){
                uint8_t v723;
                v723 = v720.rank;
                bool v724;
                v724 = v723 == 12u;
                if (v724){
                    v696[4l] = v720;
                    v726 = true;
                } else {
                    v726 = false;
                }
            } else {
                v726 = false;
            }
            if (v726){
                v752 = true;
            } else {
                Card v727;
                v727 = v1[1l];
                uint8_t v728;
                v728 = v727.suit;
                bool v729;
                v729 = 0u == v728;
                bool v733;
                if (v729){
                    uint8_t v730;
                    v730 = v727.rank;
                    bool v731;
                    v731 = v730 == 12u;
                    if (v731){
                        v696[4l] = v727;
                        v733 = true;
                    } else {
                        v733 = false;
                    }
                } else {
                    v733 = false;
                }
                if (v733){
                    v752 = true;
                } else {
                    Card v734;
                    v734 = v1[2l];
                    uint8_t v735;
                    v735 = v734.suit;
                    bool v736;
                    v736 = 0u == v735;
                    bool v740;
                    if (v736){
                        uint8_t v737;
                        v737 = v734.rank;
                        bool v738;
                        v738 = v737 == 12u;
                        if (v738){
                            v696[4l] = v734;
                            v740 = true;
                        } else {
                            v740 = false;
                        }
                    } else {
                        v740 = false;
                    }
                    if (v740){
                        v752 = true;
                    } else {
                        Card v741;
                        v741 = v1[3l];
                        uint8_t v742;
                        v742 = v741.suit;
                        bool v743;
                        v743 = 0u == v742;
                        if (v743){
                            uint8_t v744;
                            v744 = v741.rank;
                            bool v745;
                            v745 = v744 == 12u;
                            if (v745){
                                v696[4l] = v741;
                                v752 = true;
                            } else {
                                v752 = false;
                            }
                        } else {
                            v752 = false;
                        }
                    }
                }
            }
        } else {
            v752 = false;
        }
    } else {
        v752 = false;
    }
    US1 v758;
    if (v752){
        v758 = US1_1(v696);
    } else {
        bool v754;
        v754 = v698 == 5l;
        if (v754){
            v758 = US1_1(v696);
        } else {
            v758 = US1_0();
        }
    }
    US1 v784;
    switch (v758.tag) {
        case 0: { // None
            v784 = v695;
            break;
        }
        default: { // Some
            std::array<Card,5l> v759 = v758.v.case1.v0;
            switch (v695.tag) {
                case 0: { // None
                    v784 = v758;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v760 = v695.v.case1.v0;
                    US4 v761;
                    v761 = US4_0();
                    int32_t v762; US4 v763;
                    Tuple9 tmp32 = TupleCreate9(0l, v761);
                    v762 = tmp32.v0; v763 = tmp32.v1;
                    while (while_method_5(v762)){
                        Card v765;
                        v765 = v759[v762];
                        Card v766;
                        v766 = v760[v762];
                        US4 v777;
                        switch (v763.tag) {
                            case 0: { // Eq
                                uint8_t v767;
                                v767 = v765.rank;
                                uint8_t v768;
                                v768 = v766.rank;
                                bool v769;
                                v769 = v767 < v768;
                                if (v769){
                                    v777 = US4_2();
                                } else {
                                    bool v771;
                                    v771 = v767 > v768;
                                    if (v771){
                                        v777 = US4_1();
                                    } else {
                                        v777 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v763 = v777;
                        v762++;
                    }
                    bool v778;
                    switch (v763.tag) {
                        case 1: { // Gt
                            v778 = true;
                            break;
                        }
                        default: {
                            v778 = false;
                        }
                    }
                    std::array<Card,5l> v779;
                    if (v778){
                        v779 = v759;
                    } else {
                        v779 = v760;
                    }
                    v784 = US1_1(v779);
                }
            }
        }
    }
    US1 v810;
    switch (v784.tag) {
        case 0: { // None
            v810 = v632;
            break;
        }
        default: { // Some
            std::array<Card,5l> v785 = v784.v.case1.v0;
            switch (v632.tag) {
                case 0: { // None
                    v810 = v784;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v786 = v632.v.case1.v0;
                    US4 v787;
                    v787 = US4_0();
                    int32_t v788; US4 v789;
                    Tuple9 tmp33 = TupleCreate9(0l, v787);
                    v788 = tmp33.v0; v789 = tmp33.v1;
                    while (while_method_5(v788)){
                        Card v791;
                        v791 = v785[v788];
                        Card v792;
                        v792 = v786[v788];
                        US4 v803;
                        switch (v789.tag) {
                            case 0: { // Eq
                                uint8_t v793;
                                v793 = v791.rank;
                                uint8_t v794;
                                v794 = v792.rank;
                                bool v795;
                                v795 = v793 < v794;
                                if (v795){
                                    v803 = US4_2();
                                } else {
                                    bool v797;
                                    v797 = v793 > v794;
                                    if (v797){
                                        v803 = US4_1();
                                    } else {
                                        v803 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v789 = v803;
                        v788++;
                    }
                    bool v804;
                    switch (v789.tag) {
                        case 1: { // Gt
                            v804 = true;
                            break;
                        }
                        default: {
                            v804 = false;
                        }
                    }
                    std::array<Card,5l> v805;
                    if (v804){
                        v805 = v785;
                    } else {
                        v805 = v786;
                    }
                    v810 = US1_1(v805);
                }
            }
        }
    }
    US1 v836;
    switch (v810.tag) {
        case 0: { // None
            v836 = v569;
            break;
        }
        default: { // Some
            std::array<Card,5l> v811 = v810.v.case1.v0;
            switch (v569.tag) {
                case 0: { // None
                    v836 = v810;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v812 = v569.v.case1.v0;
                    US4 v813;
                    v813 = US4_0();
                    int32_t v814; US4 v815;
                    Tuple9 tmp34 = TupleCreate9(0l, v813);
                    v814 = tmp34.v0; v815 = tmp34.v1;
                    while (while_method_5(v814)){
                        Card v817;
                        v817 = v811[v814];
                        Card v818;
                        v818 = v812[v814];
                        US4 v829;
                        switch (v815.tag) {
                            case 0: { // Eq
                                uint8_t v819;
                                v819 = v817.rank;
                                uint8_t v820;
                                v820 = v818.rank;
                                bool v821;
                                v821 = v819 < v820;
                                if (v821){
                                    v829 = US4_2();
                                } else {
                                    bool v823;
                                    v823 = v819 > v820;
                                    if (v823){
                                        v829 = US4_1();
                                    } else {
                                        v829 = US4_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v815 = v829;
                        v814++;
                    }
                    bool v830;
                    switch (v815.tag) {
                        case 1: { // Gt
                            v830 = true;
                            break;
                        }
                        default: {
                            v830 = false;
                        }
                    }
                    std::array<Card,5l> v831;
                    if (v830){
                        v831 = v811;
                    } else {
                        v831 = v812;
                    }
                    v836 = US1_1(v831);
                }
            }
        }
    }
    US7 v841;
    switch (v59.tag) {
        case 0: { // None
            v841 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v837 = v59.v.case1.v0;
            v841 = US7_1(v837, 1);
        }
    }
    US7 v846;
    switch (v148.tag) {
        case 0: { // None
            v846 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v842 = v148.v.case1.v0;
            v846 = US7_1(v842, 2);
        }
    }
    US7 v851;
    switch (v198.tag) {
        case 0: { // None
            v851 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v847 = v198.v.case1.v0;
            v851 = US7_1(v847, 3);
        }
    }
    US7 v856;
    switch (v236.tag) {
        case 0: { // None
            v856 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v852 = v236.v.case1.v0;
            v856 = US7_1(v852, 4);
        }
    }
    US7 v861;
    switch (v374.tag) {
        case 0: { // None
            v861 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v857 = v374.v.case1.v0;
            v861 = US7_1(v857, 5);
        }
    }
    US7 v866;
    switch (v456.tag) {
        case 0: { // None
            v866 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v862 = v456.v.case1.v0;
            v866 = US7_1(v862, 6);
        }
    }
    US7 v871;
    switch (v506.tag) {
        case 0: { // None
            v871 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v867 = v506.v.case1.v0;
            v871 = US7_1(v867, 7);
        }
    }
    US7 v876;
    switch (v836.tag) {
        case 0: { // None
            v876 = US7_0();
            break;
        }
        default: { // Some
            std::array<Card,5l> v872 = v836.v.case1.v0;
            v876 = US7_1(v872, 8);
        }
    }
    US7 v878;
    switch (v876.tag) {
        case 0: { // None
            v878 = US7_0();
            break;
        }
        default: {
            v878 = v876;
        }
    }
    US7 v888;
    switch (v878.tag) {
        case 1: { // Some
            std::array<Card,5l> v879 = v878.v.case1.v0; int8_t v880 = v878.v.case1.v1;
            switch (v871.tag) {
                case 0: { // None
                    v888 = v878;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v881 = v871.v.case1.v0; int8_t v882 = v871.v.case1.v1;
                    v888 = US7_1(v879, v880);
                }
            }
            break;
        }
        default: {
            switch (v871.tag) {
                case 0: { // None
                    v888 = v878;
                    break;
                }
                default: {
                    switch (v878.tag) {
                        default: { // None
                            v888 = v871;
                        }
                    }
                }
            }
        }
    }
    US7 v898;
    switch (v888.tag) {
        case 1: { // Some
            std::array<Card,5l> v889 = v888.v.case1.v0; int8_t v890 = v888.v.case1.v1;
            switch (v866.tag) {
                case 0: { // None
                    v898 = v888;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v891 = v866.v.case1.v0; int8_t v892 = v866.v.case1.v1;
                    v898 = US7_1(v889, v890);
                }
            }
            break;
        }
        default: {
            switch (v866.tag) {
                case 0: { // None
                    v898 = v888;
                    break;
                }
                default: {
                    switch (v888.tag) {
                        default: { // None
                            v898 = v866;
                        }
                    }
                }
            }
        }
    }
    US7 v908;
    switch (v898.tag) {
        case 1: { // Some
            std::array<Card,5l> v899 = v898.v.case1.v0; int8_t v900 = v898.v.case1.v1;
            switch (v861.tag) {
                case 0: { // None
                    v908 = v898;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v901 = v861.v.case1.v0; int8_t v902 = v861.v.case1.v1;
                    v908 = US7_1(v899, v900);
                }
            }
            break;
        }
        default: {
            switch (v861.tag) {
                case 0: { // None
                    v908 = v898;
                    break;
                }
                default: {
                    switch (v898.tag) {
                        default: { // None
                            v908 = v861;
                        }
                    }
                }
            }
        }
    }
    US7 v918;
    switch (v908.tag) {
        case 1: { // Some
            std::array<Card,5l> v909 = v908.v.case1.v0; int8_t v910 = v908.v.case1.v1;
            switch (v856.tag) {
                case 0: { // None
                    v918 = v908;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v911 = v856.v.case1.v0; int8_t v912 = v856.v.case1.v1;
                    v918 = US7_1(v909, v910);
                }
            }
            break;
        }
        default: {
            switch (v856.tag) {
                case 0: { // None
                    v918 = v908;
                    break;
                }
                default: {
                    switch (v908.tag) {
                        default: { // None
                            v918 = v856;
                        }
                    }
                }
            }
        }
    }
    US7 v928;
    switch (v918.tag) {
        case 1: { // Some
            std::array<Card,5l> v919 = v918.v.case1.v0; int8_t v920 = v918.v.case1.v1;
            switch (v851.tag) {
                case 0: { // None
                    v928 = v918;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v921 = v851.v.case1.v0; int8_t v922 = v851.v.case1.v1;
                    v928 = US7_1(v919, v920);
                }
            }
            break;
        }
        default: {
            switch (v851.tag) {
                case 0: { // None
                    v928 = v918;
                    break;
                }
                default: {
                    switch (v918.tag) {
                        default: { // None
                            v928 = v851;
                        }
                    }
                }
            }
        }
    }
    US7 v938;
    switch (v928.tag) {
        case 1: { // Some
            std::array<Card,5l> v929 = v928.v.case1.v0; int8_t v930 = v928.v.case1.v1;
            switch (v846.tag) {
                case 0: { // None
                    v938 = v928;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v931 = v846.v.case1.v0; int8_t v932 = v846.v.case1.v1;
                    v938 = US7_1(v929, v930);
                }
            }
            break;
        }
        default: {
            switch (v846.tag) {
                case 0: { // None
                    v938 = v928;
                    break;
                }
                default: {
                    switch (v928.tag) {
                        default: { // None
                            v938 = v846;
                        }
                    }
                }
            }
        }
    }
    US7 v948;
    switch (v938.tag) {
        case 1: { // Some
            std::array<Card,5l> v939 = v938.v.case1.v0; int8_t v940 = v938.v.case1.v1;
            switch (v841.tag) {
                case 0: { // None
                    v948 = v938;
                    break;
                }
                default: { // Some
                    std::array<Card,5l> v941 = v841.v.case1.v0; int8_t v942 = v841.v.case1.v1;
                    v948 = US7_1(v939, v940);
                }
            }
            break;
        }
        default: {
            switch (v841.tag) {
                case 0: { // None
                    v948 = v938;
                    break;
                }
                default: {
                    switch (v938.tag) {
                        default: { // None
                            v948 = v841;
                        }
                    }
                }
            }
        }
    }
    std::array<Card,5l> v953; int8_t v954;
    switch (v948.tag) {
        case 0: { // None
            v953 = v6; v954 = 0;
            break;
        }
        default: { // Some
            std::array<Card,5l> v949 = v948.v.case1.v0; int8_t v950 = v948.v.case1.v1;
            v953 = v949; v954 = v950;
        }
    }
    return TupleCreate5(v953, v954);
}
int32_t main() {
    std::random_device v0;
    std::mt19937 v1(v0());
    std::mt19937 & v2 = v1;
    std::uniform_int_distribution<int32_t> v3(0l, 51l);
    uint64_t v4; int32_t v5;
    Tuple0 tmp0 = TupleCreate0(0ull, 0l);
    v4 = tmp0.v0; v5 = tmp0.v1;
    while (while_method_0(v4)){
        std::array<Tuple1,7l> v7;
        uint64_t v8;
        v8 = 0ull;
        int32_t v9;
        v9 = 7l;
        while (while_method_1(v9)){
            int32_t v11;
            v11 = v3(v2);
            int8_t v12;
            v12 = (int8_t)v11;
            int32_t v13;
            v13 = (int32_t)v12;
            uint64_t v14;
            v14 = 1ull << v13;
            uint64_t v15;
            v15 = v8 & v14;
            bool v16;
            v16 = v15 == 0ull;
            bool v17;
            v17 = v16 != true;
            int32_t v22;
            if (v17){
                v22 = v9;
            } else {
                int32_t v18;
                v18 = v9 - 1l;
                int8_t v19;
                v19 = v12 % 13;
                int8_t v20;
                v20 = v12 / 13;
                v7[v18] = TupleCreate1(v19, v20);
                uint64_t v21;
                v21 = v8 | v14;
                v8 = v21;
                v22 = v18;
            }
            v9 = v22;
        }
        int8_t v23; int8_t v24;
        Tuple1 tmp1 = v7[0l];
        v23 = tmp1.v0; v24 = tmp1.v1;
        int8_t v25; int8_t v26;
        Tuple1 tmp2 = v7[1l];
        v25 = tmp2.v0; v26 = tmp2.v1;
        int8_t v27; int8_t v28;
        Tuple1 tmp3 = v7[2l];
        v27 = tmp3.v0; v28 = tmp3.v1;
        int8_t v29; int8_t v30;
        Tuple1 tmp4 = v7[3l];
        v29 = tmp4.v0; v30 = tmp4.v1;
        int8_t v31; int8_t v32;
        Tuple1 tmp5 = v7[4l];
        v31 = tmp5.v0; v32 = tmp5.v1;
        int8_t v33; int8_t v34;
        Tuple1 tmp6 = v7[5l];
        v33 = tmp6.v0; v34 = tmp6.v1;
        int8_t v35; int8_t v36;
        Tuple1 tmp7 = v7[6l];
        v35 = tmp7.v0; v36 = tmp7.v1;
        int8_t v37;
        v37 = v36 * 13;
        int8_t v38;
        v38 = v37 + v35;
        int32_t v39;
        v39 = (int32_t)v38;
        uint64_t v40;
        v40 = 1ull << v39;
        int8_t v41;
        v41 = v34 * 13;
        int8_t v42;
        v42 = v41 + v33;
        int32_t v43;
        v43 = (int32_t)v42;
        uint64_t v44;
        v44 = 1ull << v43;
        int8_t v45;
        v45 = v32 * 13;
        int8_t v46;
        v46 = v45 + v31;
        int32_t v47;
        v47 = (int32_t)v46;
        uint64_t v48;
        v48 = 1ull << v47;
        int8_t v49;
        v49 = v30 * 13;
        int8_t v50;
        v50 = v49 + v29;
        int32_t v51;
        v51 = (int32_t)v50;
        uint64_t v52;
        v52 = 1ull << v51;
        int8_t v53;
        v53 = v28 * 13;
        int8_t v54;
        v54 = v53 + v27;
        int32_t v55;
        v55 = (int32_t)v54;
        uint64_t v56;
        v56 = 1ull << v55;
        int8_t v57;
        v57 = v26 * 13;
        int8_t v58;
        v58 = v57 + v25;
        int32_t v59;
        v59 = (int32_t)v58;
        uint64_t v60;
        v60 = 1ull << v59;
        int8_t v61;
        v61 = v24 * 13;
        int8_t v62;
        v62 = v61 + v23;
        int32_t v63;
        v63 = (int32_t)v62;
        uint64_t v64;
        v64 = 1ull << v63;
        uint64_t v65;
        v65 = 0ull | v64;
        uint64_t v66;
        v66 = v65 | v60;
        uint64_t v67;
        v67 = v66 | v56;
        uint64_t v68;
        v68 = v67 | v52;
        uint64_t v69;
        v69 = v68 | v48;
        uint64_t v70;
        v70 = v69 | v44;
        uint64_t v71;
        v71 = v70 | v40;
        int8_t v72; int8_t v73; int8_t v74; int8_t v75; int8_t v76; int8_t v77;
        Tuple2 tmp12 = score__0(v71);
        v72 = tmp12.v0; v73 = tmp12.v1; v74 = tmp12.v2; v75 = tmp12.v3; v76 = tmp12.v4; v77 = tmp12.v5;
        int8_t v78;
        v78 = v72 / 13;
        int8_t v79;
        v79 = v72 % 13;
        int8_t v80;
        v80 = v73 / 13;
        int8_t v81;
        v81 = v73 % 13;
        int8_t v82;
        v82 = v74 / 13;
        int8_t v83;
        v83 = v74 % 13;
        int8_t v84;
        v84 = v75 / 13;
        int8_t v85;
        v85 = v75 % 13;
        int8_t v86;
        v86 = v76 / 13;
        int8_t v87;
        v87 = v76 % 13;
        std::array<Card,7l> v88;
        uint8_t v89;
        v89 = (uint8_t)v23;
        uint8_t v90;
        v90 = (uint8_t)v24;
        Card v91;
        v91 = {v89, v90};
        v88[0l] = v91;
        uint8_t v92;
        v92 = (uint8_t)v25;
        uint8_t v93;
        v93 = (uint8_t)v26;
        Card v94;
        v94 = {v92, v93};
        v88[1l] = v94;
        uint8_t v95;
        v95 = (uint8_t)v27;
        uint8_t v96;
        v96 = (uint8_t)v28;
        Card v97;
        v97 = {v95, v96};
        v88[2l] = v97;
        uint8_t v98;
        v98 = (uint8_t)v29;
        uint8_t v99;
        v99 = (uint8_t)v30;
        Card v100;
        v100 = {v98, v99};
        v88[3l] = v100;
        uint8_t v101;
        v101 = (uint8_t)v31;
        uint8_t v102;
        v102 = (uint8_t)v32;
        Card v103;
        v103 = {v101, v102};
        v88[4l] = v103;
        uint8_t v104;
        v104 = (uint8_t)v33;
        uint8_t v105;
        v105 = (uint8_t)v34;
        Card v106;
        v106 = {v104, v105};
        v88[5l] = v106;
        uint8_t v107;
        v107 = (uint8_t)v35;
        uint8_t v108;
        v108 = (uint8_t)v36;
        Card v109;
        v109 = {v107, v108};
        v88[6l] = v109;
        std::array<Card,5l> v110; int8_t v111;
        Tuple5 tmp35 = score_21(v88);
        v110 = tmp35.v0; v111 = tmp35.v1;
        Card v112;
        v112 = v110[0l];
        uint8_t v113;
        v113 = v112.suit;
        int8_t v114;
        v114 = (int8_t)v113;
        uint8_t v115;
        v115 = v112.rank;
        int8_t v116;
        v116 = (int8_t)v115;
        Card v117;
        v117 = v110[1l];
        uint8_t v118;
        v118 = v117.suit;
        int8_t v119;
        v119 = (int8_t)v118;
        uint8_t v120;
        v120 = v117.rank;
        int8_t v121;
        v121 = (int8_t)v120;
        Card v122;
        v122 = v110[2l];
        uint8_t v123;
        v123 = v122.suit;
        int8_t v124;
        v124 = (int8_t)v123;
        uint8_t v125;
        v125 = v122.rank;
        int8_t v126;
        v126 = (int8_t)v125;
        Card v127;
        v127 = v110[3l];
        uint8_t v128;
        v128 = v127.suit;
        int8_t v129;
        v129 = (int8_t)v128;
        uint8_t v130;
        v130 = v127.rank;
        int8_t v131;
        v131 = (int8_t)v130;
        Card v132;
        v132 = v110[4l];
        uint8_t v133;
        v133 = v132.suit;
        int8_t v134;
        v134 = (int8_t)v133;
        uint8_t v135;
        v135 = v132.rank;
        int8_t v136;
        v136 = (int8_t)v135;
        bool v137;
        v137 = v79 == v116;
        bool v139;
        if (v137){
            bool v138;
            v138 = v78 == v114;
            v139 = v138;
        } else {
            v139 = false;
        }
        bool v155;
        if (v139){
            bool v140;
            v140 = v81 == v121;
            bool v142;
            if (v140){
                bool v141;
                v141 = v80 == v119;
                v142 = v141;
            } else {
                v142 = false;
            }
            if (v142){
                bool v143;
                v143 = v83 == v126;
                bool v145;
                if (v143){
                    bool v144;
                    v144 = v82 == v124;
                    v145 = v144;
                } else {
                    v145 = false;
                }
                if (v145){
                    bool v146;
                    v146 = v85 == v131;
                    bool v148;
                    if (v146){
                        bool v147;
                        v147 = v84 == v129;
                        v148 = v147;
                    } else {
                        v148 = false;
                    }
                    if (v148){
                        bool v149;
                        v149 = v87 == v136;
                        if (v149){
                            bool v150;
                            v150 = v86 == v134;
                            v155 = v150;
                        } else {
                            v155 = false;
                        }
                    } else {
                        v155 = false;
                    }
                } else {
                    v155 = false;
                }
            } else {
                v155 = false;
            }
        } else {
            v155 = false;
        }
        bool v157;
        if (v155){
            bool v156;
            v156 = v77 == v111;
            v157 = v156;
        } else {
            v157 = false;
        }
        bool v158;
        v158 = v157 != true;
        int32_t v160;
        if (v158){
            std::cout << "{rank = " << (int) v23 << "; suit = " << (int) v24 << "}; " ;
            std::cout << "{rank = " << (int) v25 << "; suit = " << (int) v26 << "}; " ;
            std::cout << "{rank = " << (int) v27 << "; suit = " << (int) v28 << "}; " ;
            std::cout << "{rank = " << (int) v29 << "; suit = " << (int) v30 << "}; " ;
            std::cout << "{rank = " << (int) v31 << "; suit = " << (int) v32 << "}; " ;
            std::cout << "{rank = " << (int) v33 << "; suit = " << (int) v34 << "}; " ;
            std::cout << "{rank = " << (int) v35 << "; suit = " << (int) v36 << "}; " ;
            std::cout << std::endl;
            std::cout << "Score: " << (int) v77 << " " ;
            std::cout << "Card: ";
            std::cout << "(" << (int) v79 << "," << (int) v78 << ") " ;
            std::cout << "(" << (int) v81 << "," << (int) v80 << ") " ;
            std::cout << "(" << (int) v83 << "," << (int) v82 << ") " ;
            std::cout << "(" << (int) v85 << "," << (int) v84 << ") " ;
            std::cout << "(" << (int) v87 << "," << (int) v86 << ") " ;
            std::cout << std::endl;
            std::cout << "Score: " << (int) v111 << " " ;
            std::cout << "Card: ";
            std::cout << "(" << (int) v116 << "," << (int) v114 << ") " ;
            std::cout << "(" << (int) v121 << "," << (int) v119 << ") " ;
            std::cout << "(" << (int) v126 << "," << (int) v124 << ") " ;
            std::cout << "(" << (int) v131 << "," << (int) v129 << ") " ;
            std::cout << "(" << (int) v136 << "," << (int) v134 << ") " ;
            std::cout << std::endl;
            int32_t v159;
            v159 = v5 + 1l;
            v160 = v159;
        } else {
            v160 = v5;
        }
        v5 = v160;
        v4++;
    }
    std::cout << "The number of errors is: " << v5 << std::endl;
    return v5;
}
