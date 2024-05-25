kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
#include <curand_kernel.h>
struct US1;
struct US2;
struct US0;
__device__ long f_1(unsigned char * v0);
__device__ void f_3(unsigned char * v0);
__device__ US1 f_2(unsigned char * v0);
__device__ US2 f_5(unsigned char * v0);
__device__ static_array<US2,2l> f_4(unsigned char * v0);
__device__ US0 f_0(unsigned char * v0);
struct US3;
struct US4;
struct US7;
struct US6;
struct US5;
struct US8;
struct Tuple0;
__device__ US3 f_7(unsigned char * v0);
__device__ long f_8(unsigned char * v0);
struct Tuple1;
__device__ long f_11(unsigned char * v0);
__device__ Tuple1 f_10(unsigned char * v0);
struct Tuple2;
__device__ Tuple2 f_12(unsigned char * v0);
struct Tuple3;
__device__ Tuple3 f_13(unsigned char * v0);
__device__ US4 f_9(unsigned char * v0);
__device__ long f_14(unsigned char * v0);
struct Tuple4;
__device__ Tuple4 f_16(unsigned char * v0);
struct Tuple5;
__device__ long f_18(unsigned char * v0);
__device__ Tuple5 f_17(unsigned char * v0);
__device__ US6 f_15(unsigned char * v0);
__device__ long f_19(unsigned char * v0);
__device__ Tuple0 f_6(unsigned char * v0);
struct Tuple6;
struct Tuple7;
struct Tuple8;
__device__ unsigned long loop_22(unsigned long v0, curandStatePhilox4_32_10_t & v1);
struct US9;
__device__ long tag_24(US3 v0);
__device__ bool is_pair_25(long v0, long v1);
__device__ Tuple8 order_26(long v0, long v1);
__device__ US9 compare_hands_23(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5);
__device__ US6 play_loop_inner_21(static_array_list<US3,6l,long> & v0, static_array_list<US4,32l,long> & v1, static_array<US2,2l> v2, US6 v3);
__device__ Tuple6 play_loop_20(US5 v0, static_array<US2,2l> v1, US8 v2, static_array_list<US3,6l,long> & v3, static_array_list<US4,32l,long> & v4, US6 v5);
__device__ void f_28(unsigned char * v0, long v1);
__device__ void f_30(unsigned char * v0);
__device__ void f_29(unsigned char * v0, US3 v1);
__device__ void f_31(unsigned char * v0, long v1);
__device__ void f_34(unsigned char * v0, long v1);
__device__ void f_33(unsigned char * v0, long v1, US1 v2);
__device__ void f_35(unsigned char * v0, long v1, US3 v2);
__device__ void f_36(unsigned char * v0, static_array<US3,2l> v1, long v2, long v3);
__device__ void f_32(unsigned char * v0, US4 v1);
__device__ void f_37(unsigned char * v0, long v1);
__device__ void f_39(unsigned char * v0, US7 v1, bool v2, static_array<US3,2l> v3, long v4, static_array<long,2l> v5, long v6);
__device__ void f_41(unsigned char * v0, long v1);
__device__ void f_40(unsigned char * v0, US7 v1, bool v2, static_array<US3,2l> v3, long v4, static_array<long,2l> v5, long v6, US1 v7);
__device__ void f_38(unsigned char * v0, US6 v1);
__device__ void f_42(unsigned char * v0, US2 v1);
__device__ void f_43(unsigned char * v0, long v1);
__device__ void f_27(unsigned char * v0, static_array_list<US3,6l,long> v1, static_array_list<US4,32l,long> v2, US5 v3, static_array<US2,2l> v4, US8 v5);
__device__ void f_45(unsigned char * v0, long v1);
__device__ void f_44(unsigned char * v0, static_array_list<US4,32l,long> v1, static_array<US2,2l> v2, US8 v3);
struct US1 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US2 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US0 {
    union {
        struct {
            US1 v0;
        } case0; // ActionSelected
        struct {
            static_array<US2,2l> v0;
        } case1; // PlayerChanged
    } v;
    unsigned long tag : 2;
};
struct US3 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US4 {
    union {
        struct {
            US3 v0;
        } case0; // CommunityCardIs
        struct {
            US1 v1;
            long v0;
        } case1; // PlayerAction
        struct {
            US3 v1;
            long v0;
        } case2; // PlayerGotCard
        struct {
            static_array<US3,2l> v0;
            long v1;
            long v2;
        } case3; // Showdown
    } v;
    unsigned long tag : 3;
};
struct US7 {
    union {
        struct {
            US3 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US6 {
    union {
        struct {
            US7 v0;
            static_array<US3,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case0; // ChanceCommunityCard
        struct {
            US7 v0;
            static_array<US3,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case2; // Round
        struct {
            US7 v0;
            static_array<US3,2l> v2;
            static_array<long,2l> v4;
            US1 v6;
            long v3;
            long v5;
            bool v1;
        } case3; // RoundWithAction
        struct {
            US7 v0;
            static_array<US3,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case4; // TerminalCall
        struct {
            US7 v0;
            static_array<US3,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case5; // TerminalFold
    } v;
    unsigned long tag : 3;
};
struct US5 {
    union {
        struct {
            US6 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US8 {
    union {
        struct {
            US7 v0;
            static_array<US3,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case1; // GameOver
        struct {
            US7 v0;
            static_array<US3,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    static_array_list<US3,6l,long> v0;
    static_array_list<US4,32l,long> v1;
    US5 v2;
    static_array<US2,2l> v3;
    US8 v4;
    __device__ Tuple0(static_array_list<US3,6l,long> t0, static_array_list<US4,32l,long> t1, US5 t2, static_array<US2,2l> t3, US8 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    US1 v1;
    long v0;
    __device__ Tuple1(long t0, US1 t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
struct Tuple2 {
    US3 v1;
    long v0;
    __device__ Tuple2(long t0, US3 t1) : v0(t0), v1(t1) {}
    __device__ Tuple2() = default;
};
struct Tuple3 {
    static_array<US3,2l> v0;
    long v1;
    long v2;
    __device__ Tuple3(static_array<US3,2l> t0, long t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple3() = default;
};
struct Tuple4 {
    US7 v0;
    static_array<US3,2l> v2;
    static_array<long,2l> v4;
    long v3;
    long v5;
    bool v1;
    __device__ Tuple4(US7 t0, bool t1, static_array<US3,2l> t2, long t3, static_array<long,2l> t4, long t5) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5) {}
    __device__ Tuple4() = default;
};
struct Tuple5 {
    US7 v0;
    static_array<US3,2l> v2;
    static_array<long,2l> v4;
    US1 v6;
    long v3;
    long v5;
    bool v1;
    __device__ Tuple5(US7 t0, bool t1, static_array<US3,2l> t2, long t3, static_array<long,2l> t4, long t5, US1 t6) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6) {}
    __device__ Tuple5() = default;
};
struct Tuple6 {
    US5 v0;
    static_array<US2,2l> v1;
    US8 v2;
    __device__ Tuple6(US5 t0, static_array<US2,2l> t1, US8 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple6() = default;
};
struct Tuple7 {
    US6 v1;
    bool v0;
    __device__ Tuple7(bool t0, US6 t1) : v0(t0), v1(t1) {}
    __device__ Tuple7() = default;
};
struct Tuple8 {
    long v0;
    long v1;
    __device__ Tuple8(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple8() = default;
};
struct US9 {
    union {
    } v;
    unsigned long tag : 2;
};
__device__ US1 US1_0() { // Call
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1() { // Fold
    US1 x;
    x.tag = 1;
    return x;
}
__device__ US1 US1_2() { // Raise
    US1 x;
    x.tag = 2;
    return x;
}
__device__ US2 US2_0() { // Computer
    US2 x;
    x.tag = 0;
    return x;
}
__device__ US2 US2_1() { // Human
    US2 x;
    x.tag = 1;
    return x;
}
__device__ US0 US0_0(US1 v0) { // ActionSelected
    US0 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US0 US0_1(static_array<US2,2l> v0) { // PlayerChanged
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US0 US0_2() { // StartGame
    US0 x;
    x.tag = 2;
    return x;
}
__device__ long f_1(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ void f_3(unsigned char * v0){
    return ;
}
__device__ US1 f_2(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    switch (v1) {
        case 0: {
            f_3(v2);
            return US1_0();
            break;
        }
        case 1: {
            f_3(v2);
            return US1_1();
            break;
        }
        case 2: {
            f_3(v2);
            return US1_2();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ US2 f_5(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    switch (v1) {
        case 0: {
            f_3(v2);
            return US2_0();
            break;
        }
        case 1: {
            f_3(v2);
            return US2_1();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ static_array<US2,2l> f_4(unsigned char * v0){
    static_array<US2,2l> v1;
    long v2;
    v2 = 0l;
    while (while_method_0(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 4ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        US2 v7;
        v7 = f_5(v6);
        bool v8;
        v8 = 0l <= v2;
        bool v10;
        if (v8){
            bool v9;
            v9 = v2 < 2l;
            v10 = v9;
        } else {
            v10 = false;
        }
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The read index needs to be in range for the static array." && v10);
        } else {
        }
        v1.v[v2] = v7;
        v2 += 1l ;
    }
    return v1;
}
__device__ US0 f_0(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+8ull);
    switch (v1) {
        case 0: {
            US1 v4;
            v4 = f_2(v2);
            return US0_0(v4);
            break;
        }
        case 1: {
            static_array<US2,2l> v6;
            v6 = f_4(v2);
            return US0_1(v6);
            break;
        }
        case 2: {
            f_3(v2);
            return US0_2();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ US3 US3_0() { // Jack
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1() { // King
    US3 x;
    x.tag = 1;
    return x;
}
__device__ US3 US3_2() { // Queen
    US3 x;
    x.tag = 2;
    return x;
}
__device__ US4 US4_0(US3 v0) { // CommunityCardIs
    US4 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US4 US4_1(long v0, US1 v1) { // PlayerAction
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US4 US4_2(long v0, US3 v1) { // PlayerGotCard
    US4 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1;
    return x;
}
__device__ US4 US4_3(static_array<US3,2l> v0, long v1, long v2) { // Showdown
    US4 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2;
    return x;
}
__device__ US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
__device__ US7 US7_1(US3 v0) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US6 US6_0(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5) { // ChanceCommunityCard
    US6 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5;
    return x;
}
__device__ US6 US6_1() { // ChanceInit
    US6 x;
    x.tag = 1;
    return x;
}
__device__ US6 US6_2(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5) { // Round
    US6 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ US6 US6_3(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5, US1 v6) { // RoundWithAction
    US6 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5; x.v.case3.v6 = v6;
    return x;
}
__device__ US6 US6_4(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5) { // TerminalCall
    US6 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5;
    return x;
}
__device__ US6 US6_5(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5) { // TerminalFold
    US6 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5;
    return x;
}
__device__ US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
__device__ US5 US5_1(US6 v0) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US8 US8_0() { // GameNotStarted
    US8 x;
    x.tag = 0;
    return x;
}
__device__ US8 US8_1(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5) { // GameOver
    US8 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US8 US8_2(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5) { // WaitingForActionFromPlayerId
    US8 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ inline bool while_method_1(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__device__ US3 f_7(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    switch (v1) {
        case 0: {
            f_3(v2);
            return US3_0();
            break;
        }
        case 1: {
            f_3(v2);
            return US3_1();
            break;
        }
        case 2: {
            f_3(v2);
            return US3_2();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_8(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+28ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long f_11(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+4ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple1 f_10(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long v3;
    v3 = f_11(v0);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+8ull);
    US1 v9;
    switch (v3) {
        case 0: {
            f_3(v4);
            v9 = US1_0();
            break;
        }
        case 1: {
            f_3(v4);
            v9 = US1_1();
            break;
        }
        case 2: {
            f_3(v4);
            v9 = US1_2();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple1(v2, v9);
}
__device__ Tuple2 f_12(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long v3;
    v3 = f_11(v0);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+8ull);
    US3 v9;
    switch (v3) {
        case 0: {
            f_3(v4);
            v9 = US3_0();
            break;
        }
        case 1: {
            f_3(v4);
            v9 = US3_1();
            break;
        }
        case 2: {
            f_3(v4);
            v9 = US3_2();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple2(v2, v9);
}
__device__ Tuple3 f_13(unsigned char * v0){
    static_array<US3,2l> v1;
    long v2;
    v2 = 0l;
    while (while_method_0(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 4ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        US3 v7;
        v7 = f_7(v6);
        bool v8;
        v8 = 0l <= v2;
        bool v10;
        if (v8){
            bool v9;
            v9 = v2 < 2l;
            v10 = v9;
        } else {
            v10 = false;
        }
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The read index needs to be in range for the static array." && v10);
        } else {
        }
        v1.v[v2] = v7;
        v2 += 1l ;
    }
    long * v12;
    v12 = (long *)(v0+8ull);
    long v13;
    v13 = v12[0l];
    long * v14;
    v14 = (long *)(v0+12ull);
    long v15;
    v15 = v14[0l];
    return Tuple3(v1, v13, v15);
}
__device__ US4 f_9(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            US3 v4;
            v4 = f_7(v2);
            return US4_0(v4);
            break;
        }
        case 1: {
            long v6; US1 v7;
            Tuple1 tmp0 = f_10(v2);
            v6 = tmp0.v0; v7 = tmp0.v1;
            return US4_1(v6, v7);
            break;
        }
        case 2: {
            long v9; US3 v10;
            Tuple2 tmp1 = f_12(v2);
            v9 = tmp1.v0; v10 = tmp1.v1;
            return US4_2(v9, v10);
            break;
        }
        case 3: {
            static_array<US3,2l> v12; long v13; long v14;
            Tuple3 tmp2 = f_13(v2);
            v12 = tmp2.v0; v13 = tmp2.v1; v14 = tmp2.v2;
            return US4_3(v12, v13, v14);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_14(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+1056ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple4 f_16(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    US7 v7;
    switch (v1) {
        case 0: {
            f_3(v2);
            v7 = US7_0();
            break;
        }
        case 1: {
            US3 v5;
            v5 = f_7(v2);
            v7 = US7_1(v5);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    bool * v8;
    v8 = (bool *)(v0+8ull);
    bool v9;
    v9 = v8[0l];
    static_array<US3,2l> v10;
    long v11;
    v11 = 0l;
    while (while_method_0(v11)){
        unsigned long long v13;
        v13 = (unsigned long long)v11;
        unsigned long long v14;
        v14 = v13 * 4ull;
        unsigned long long v15;
        v15 = 12ull + v14;
        unsigned char * v16;
        v16 = (unsigned char *)(v0+v15);
        US3 v17;
        v17 = f_7(v16);
        bool v18;
        v18 = 0l <= v11;
        bool v20;
        if (v18){
            bool v19;
            v19 = v11 < 2l;
            v20 = v19;
        } else {
            v20 = false;
        }
        bool v21;
        v21 = v20 == false;
        if (v21){
            assert("The read index needs to be in range for the static array." && v20);
        } else {
        }
        v10.v[v11] = v17;
        v11 += 1l ;
    }
    long * v22;
    v22 = (long *)(v0+20ull);
    long v23;
    v23 = v22[0l];
    static_array<long,2l> v24;
    long v25;
    v25 = 0l;
    while (while_method_0(v25)){
        unsigned long long v27;
        v27 = (unsigned long long)v25;
        unsigned long long v28;
        v28 = v27 * 4ull;
        unsigned long long v29;
        v29 = 24ull + v28;
        unsigned char * v30;
        v30 = (unsigned char *)(v0+v29);
        long v31;
        v31 = f_1(v30);
        bool v32;
        v32 = 0l <= v25;
        bool v34;
        if (v32){
            bool v33;
            v33 = v25 < 2l;
            v34 = v33;
        } else {
            v34 = false;
        }
        bool v35;
        v35 = v34 == false;
        if (v35){
            assert("The read index needs to be in range for the static array." && v34);
        } else {
        }
        v24.v[v25] = v31;
        v25 += 1l ;
    }
    long * v36;
    v36 = (long *)(v0+32ull);
    long v37;
    v37 = v36[0l];
    return Tuple4(v7, v9, v10, v23, v24, v37);
}
__device__ long f_18(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+36ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple5 f_17(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    US7 v7;
    switch (v1) {
        case 0: {
            f_3(v2);
            v7 = US7_0();
            break;
        }
        case 1: {
            US3 v5;
            v5 = f_7(v2);
            v7 = US7_1(v5);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    bool * v8;
    v8 = (bool *)(v0+8ull);
    bool v9;
    v9 = v8[0l];
    static_array<US3,2l> v10;
    long v11;
    v11 = 0l;
    while (while_method_0(v11)){
        unsigned long long v13;
        v13 = (unsigned long long)v11;
        unsigned long long v14;
        v14 = v13 * 4ull;
        unsigned long long v15;
        v15 = 12ull + v14;
        unsigned char * v16;
        v16 = (unsigned char *)(v0+v15);
        US3 v17;
        v17 = f_7(v16);
        bool v18;
        v18 = 0l <= v11;
        bool v20;
        if (v18){
            bool v19;
            v19 = v11 < 2l;
            v20 = v19;
        } else {
            v20 = false;
        }
        bool v21;
        v21 = v20 == false;
        if (v21){
            assert("The read index needs to be in range for the static array." && v20);
        } else {
        }
        v10.v[v11] = v17;
        v11 += 1l ;
    }
    long * v22;
    v22 = (long *)(v0+20ull);
    long v23;
    v23 = v22[0l];
    static_array<long,2l> v24;
    long v25;
    v25 = 0l;
    while (while_method_0(v25)){
        unsigned long long v27;
        v27 = (unsigned long long)v25;
        unsigned long long v28;
        v28 = v27 * 4ull;
        unsigned long long v29;
        v29 = 24ull + v28;
        unsigned char * v30;
        v30 = (unsigned char *)(v0+v29);
        long v31;
        v31 = f_1(v30);
        bool v32;
        v32 = 0l <= v25;
        bool v34;
        if (v32){
            bool v33;
            v33 = v25 < 2l;
            v34 = v33;
        } else {
            v34 = false;
        }
        bool v35;
        v35 = v34 == false;
        if (v35){
            assert("The read index needs to be in range for the static array." && v34);
        } else {
        }
        v24.v[v25] = v31;
        v25 += 1l ;
    }
    long * v36;
    v36 = (long *)(v0+32ull);
    long v37;
    v37 = v36[0l];
    long v38;
    v38 = f_18(v0);
    unsigned char * v39;
    v39 = (unsigned char *)(v0+40ull);
    US1 v44;
    switch (v38) {
        case 0: {
            f_3(v39);
            v44 = US1_0();
            break;
        }
        case 1: {
            f_3(v39);
            v44 = US1_1();
            break;
        }
        case 2: {
            f_3(v39);
            v44 = US1_2();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple5(v7, v9, v10, v23, v24, v37, v44);
}
__device__ US6 f_15(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            US7 v4; bool v5; static_array<US3,2l> v6; long v7; static_array<long,2l> v8; long v9;
            Tuple4 tmp3 = f_16(v2);
            v4 = tmp3.v0; v5 = tmp3.v1; v6 = tmp3.v2; v7 = tmp3.v3; v8 = tmp3.v4; v9 = tmp3.v5;
            return US6_0(v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: {
            f_3(v2);
            return US6_1();
            break;
        }
        case 2: {
            US7 v12; bool v13; static_array<US3,2l> v14; long v15; static_array<long,2l> v16; long v17;
            Tuple4 tmp4 = f_16(v2);
            v12 = tmp4.v0; v13 = tmp4.v1; v14 = tmp4.v2; v15 = tmp4.v3; v16 = tmp4.v4; v17 = tmp4.v5;
            return US6_2(v12, v13, v14, v15, v16, v17);
            break;
        }
        case 3: {
            US7 v19; bool v20; static_array<US3,2l> v21; long v22; static_array<long,2l> v23; long v24; US1 v25;
            Tuple5 tmp5 = f_17(v2);
            v19 = tmp5.v0; v20 = tmp5.v1; v21 = tmp5.v2; v22 = tmp5.v3; v23 = tmp5.v4; v24 = tmp5.v5; v25 = tmp5.v6;
            return US6_3(v19, v20, v21, v22, v23, v24, v25);
            break;
        }
        case 4: {
            US7 v27; bool v28; static_array<US3,2l> v29; long v30; static_array<long,2l> v31; long v32;
            Tuple4 tmp6 = f_16(v2);
            v27 = tmp6.v0; v28 = tmp6.v1; v29 = tmp6.v2; v30 = tmp6.v3; v31 = tmp6.v4; v32 = tmp6.v5;
            return US6_4(v27, v28, v29, v30, v31, v32);
            break;
        }
        case 5: {
            US7 v34; bool v35; static_array<US3,2l> v36; long v37; static_array<long,2l> v38; long v39;
            Tuple4 tmp7 = f_16(v2);
            v34 = tmp7.v0; v35 = tmp7.v1; v36 = tmp7.v2; v37 = tmp7.v3; v38 = tmp7.v4; v39 = tmp7.v5;
            return US6_5(v34, v35, v36, v37, v38, v39);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_19(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+1144ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple0 f_6(unsigned char * v0){
    static_array_list<US3,6l,long> v1;
    v1.length = 0;
    long v2;
    v2 = f_1(v0);
    v1.length = v2;
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_1(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 4ull;
        unsigned long long v8;
        v8 = 4ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        US3 v10;
        v10 = f_7(v9);
        bool v11;
        v11 = 0l <= v4;
        bool v14;
        if (v11){
            long v12;
            v12 = v1.length;
            bool v13;
            v13 = v4 < v12;
            v14 = v13;
        } else {
            v14 = false;
        }
        bool v15;
        v15 = v14 == false;
        if (v15){
            assert("The set index needs to be in range for the static array list." && v14);
        } else {
        }
        v1.v[v4] = v10;
        v4 += 1l ;
    }
    static_array_list<US4,32l,long> v16;
    v16.length = 0;
    long v17;
    v17 = f_8(v0);
    v16.length = v17;
    long v18;
    v18 = v16.length;
    long v19;
    v19 = 0l;
    while (while_method_1(v18, v19)){
        unsigned long long v21;
        v21 = (unsigned long long)v19;
        unsigned long long v22;
        v22 = v21 * 32ull;
        unsigned long long v23;
        v23 = 32ull + v22;
        unsigned char * v24;
        v24 = (unsigned char *)(v0+v23);
        US4 v25;
        v25 = f_9(v24);
        bool v26;
        v26 = 0l <= v19;
        bool v29;
        if (v26){
            long v27;
            v27 = v16.length;
            bool v28;
            v28 = v19 < v27;
            v29 = v28;
        } else {
            v29 = false;
        }
        bool v30;
        v30 = v29 == false;
        if (v30){
            assert("The set index needs to be in range for the static array list." && v29);
        } else {
        }
        v16.v[v19] = v25;
        v19 += 1l ;
    }
    long v31;
    v31 = f_14(v0);
    unsigned char * v32;
    v32 = (unsigned char *)(v0+1072ull);
    US5 v37;
    switch (v31) {
        case 0: {
            f_3(v32);
            v37 = US5_0();
            break;
        }
        case 1: {
            US6 v35;
            v35 = f_15(v32);
            v37 = US5_1(v35);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    static_array<US2,2l> v38;
    long v39;
    v39 = 0l;
    while (while_method_0(v39)){
        unsigned long long v41;
        v41 = (unsigned long long)v39;
        unsigned long long v42;
        v42 = v41 * 4ull;
        unsigned long long v43;
        v43 = 1136ull + v42;
        unsigned char * v44;
        v44 = (unsigned char *)(v0+v43);
        US2 v45;
        v45 = f_5(v44);
        bool v46;
        v46 = 0l <= v39;
        bool v48;
        if (v46){
            bool v47;
            v47 = v39 < 2l;
            v48 = v47;
        } else {
            v48 = false;
        }
        bool v49;
        v49 = v48 == false;
        if (v49){
            assert("The read index needs to be in range for the static array." && v48);
        } else {
        }
        v38.v[v39] = v45;
        v39 += 1l ;
    }
    long v50;
    v50 = f_19(v0);
    unsigned char * v51;
    v51 = (unsigned char *)(v0+1152ull);
    US8 v68;
    switch (v50) {
        case 0: {
            f_3(v51);
            v68 = US8_0();
            break;
        }
        case 1: {
            US7 v54; bool v55; static_array<US3,2l> v56; long v57; static_array<long,2l> v58; long v59;
            Tuple4 tmp8 = f_16(v51);
            v54 = tmp8.v0; v55 = tmp8.v1; v56 = tmp8.v2; v57 = tmp8.v3; v58 = tmp8.v4; v59 = tmp8.v5;
            v68 = US8_1(v54, v55, v56, v57, v58, v59);
            break;
        }
        case 2: {
            US7 v61; bool v62; static_array<US3,2l> v63; long v64; static_array<long,2l> v65; long v66;
            Tuple4 tmp9 = f_16(v51);
            v61 = tmp9.v0; v62 = tmp9.v1; v63 = tmp9.v2; v64 = tmp9.v3; v65 = tmp9.v4; v66 = tmp9.v5;
            v68 = US8_2(v61, v62, v63, v64, v65, v66);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple0(v1, v16, v37, v38, v68);
}
__device__ inline bool while_method_2(bool v0, US6 v1){
    return v0;
}
__device__ unsigned long loop_22(unsigned long v0, curandStatePhilox4_32_10_t & v1){
    unsigned long v2;
    v2 = curand(&v1);
    unsigned long v3;
    v3 = v2 % v0;
    unsigned long v4;
    v4 = v2 - v3;
    unsigned long v5;
    v5 = 0ul - v0;
    bool v6;
    v6 = v4 <= v5;
    if (v6){
        return v3;
    } else {
        return loop_22(v0, v1);
    }
}
__device__ US9 US9_0() { // Eq
    US9 x;
    x.tag = 0;
    return x;
}
__device__ US9 US9_1() { // Gt
    US9 x;
    x.tag = 1;
    return x;
}
__device__ US9 US9_2() { // Lt
    US9 x;
    x.tag = 2;
    return x;
}
__device__ long tag_24(US3 v0){
    switch (v0.tag) {
        case 0: { // Jack
            return 0l;
            break;
        }
        case 1: { // King
            return 2l;
            break;
        }
        case 2: { // Queen
            return 1l;
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ bool is_pair_25(long v0, long v1){
    bool v2;
    v2 = v1 == v0;
    return v2;
}
__device__ Tuple8 order_26(long v0, long v1){
    bool v2;
    v2 = v1 > v0;
    if (v2){
        return Tuple8(v1, v0);
    } else {
        return Tuple8(v0, v1);
    }
}
__device__ US9 compare_hands_23(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5){
    switch (v0.tag) {
        case 0: { // None
            printf("%s\n", "Expected the community card to be present in the table.");
            asm("exit;");
            break;
        }
        case 1: { // Some
            US3 v7 = v0.v.case1.v0;
            long v8;
            v8 = tag_24(v7);
            US3 v9;
            v9 = v2.v[0l];
            long v10;
            v10 = tag_24(v9);
            US3 v11;
            v11 = v2.v[1l];
            long v12;
            v12 = tag_24(v11);
            bool v13;
            v13 = is_pair_25(v8, v10);
            bool v14;
            v14 = is_pair_25(v8, v12);
            if (v13){
                if (v14){
                    bool v15;
                    v15 = v10 < v12;
                    if (v15){
                        return US9_2();
                    } else {
                        bool v17;
                        v17 = v10 > v12;
                        if (v17){
                            return US9_1();
                        } else {
                            return US9_0();
                        }
                    }
                } else {
                    return US9_1();
                }
            } else {
                if (v14){
                    return US9_2();
                } else {
                    long v25; long v26;
                    Tuple8 tmp19 = order_26(v8, v10);
                    v25 = tmp19.v0; v26 = tmp19.v1;
                    long v27; long v28;
                    Tuple8 tmp20 = order_26(v8, v12);
                    v27 = tmp20.v0; v28 = tmp20.v1;
                    bool v29;
                    v29 = v25 < v27;
                    US9 v35;
                    if (v29){
                        v35 = US9_2();
                    } else {
                        bool v31;
                        v31 = v25 > v27;
                        if (v31){
                            v35 = US9_1();
                        } else {
                            v35 = US9_0();
                        }
                    }
                    bool v36;
                    switch (v35.tag) {
                        case 0: { // Eq
                            v36 = true;
                            break;
                        }
                        default: {
                            v36 = false;
                        }
                    }
                    if (v36){
                        bool v37;
                        v37 = v26 < v28;
                        if (v37){
                            return US9_2();
                        } else {
                            bool v39;
                            v39 = v26 > v28;
                            if (v39){
                                return US9_1();
                            } else {
                                return US9_0();
                            }
                        }
                    } else {
                        return v35;
                    }
                }
            }
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ US6 play_loop_inner_21(static_array_list<US3,6l,long> & v0, static_array_list<US4,32l,long> & v1, static_array<US2,2l> v2, US6 v3){
    static_array_list<US4,32l,long> & v4 = v1;
    static_array_list<US3,6l,long> & v5 = v0;
    bool v6; US6 v7;
    Tuple7 tmp11 = Tuple7(true, v3);
    v6 = tmp11.v0; v7 = tmp11.v1;
    while (while_method_2(v6, v7)){
        bool v502; US6 v503;
        switch (v7.tag) {
            case 0: { // ChanceCommunityCard
                US7 v401 = v7.v.case0.v0; bool v402 = v7.v.case0.v1; static_array<US3,2l> v403 = v7.v.case0.v2; long v404 = v7.v.case0.v3; static_array<long,2l> v405 = v7.v.case0.v4; long v406 = v7.v.case0.v5;
                long v407;
                v407 = v5.length;
                long v408;
                v408 = v407 - 1l;
                bool v409;
                v409 = v408 >= 0l;
                bool v410;
                v410 = v409 == false;
                if (v410){
                    assert("The length before popping has to be greater than 0." && v409);
                } else {
                }
                bool v411;
                v411 = 0l <= v408;
                bool v414;
                if (v411){
                    long v412;
                    v412 = v5.length;
                    bool v413;
                    v413 = v408 < v412;
                    v414 = v413;
                } else {
                    v414 = false;
                }
                bool v415;
                v415 = v414 == false;
                if (v415){
                    assert("The read index needs to be in range for the static array list." && v414);
                } else {
                }
                US3 v416;
                v416 = v5.v[v408];
                v5.length = v408;
                long v417;
                v417 = v4.length;
                bool v418;
                v418 = v417 < 32l;
                bool v419;
                v419 = v418 == false;
                if (v419){
                    assert("The length has to be less than the maximum length of the array." && v418);
                } else {
                }
                long v420;
                v420 = v417 + 1l;
                v4.length = v420;
                bool v421;
                v421 = 0l <= v417;
                bool v424;
                if (v421){
                    long v422;
                    v422 = v4.length;
                    bool v423;
                    v423 = v417 < v422;
                    v424 = v423;
                } else {
                    v424 = false;
                }
                bool v425;
                v425 = v424 == false;
                if (v425){
                    assert("The set index needs to be in range for the static array list." && v424);
                } else {
                }
                US4 v426;
                v426 = US4_0(v416);
                v4.v[v417] = v426;
                long v427;
                v427 = 2l;
                long v428; long v429;
                Tuple8 tmp12 = Tuple8(0l, 0l);
                v428 = tmp12.v0; v429 = tmp12.v1;
                while (while_method_0(v428)){
                    bool v431;
                    v431 = 0l <= v428;
                    bool v433;
                    if (v431){
                        bool v432;
                        v432 = v428 < 2l;
                        v433 = v432;
                    } else {
                        v433 = false;
                    }
                    bool v434;
                    v434 = v433 == false;
                    if (v434){
                        assert("The read index needs to be in range for the static array." && v433);
                    } else {
                    }
                    long v435;
                    v435 = v405.v[v428];
                    bool v436;
                    v436 = v429 >= v435;
                    long v437;
                    if (v436){
                        v437 = v429;
                    } else {
                        v437 = v435;
                    }
                    v429 = v437;
                    v428 += 1l ;
                }
                static_array<long,2l> v438;
                long v439;
                v439 = 0l;
                while (while_method_0(v439)){
                    bool v441;
                    v441 = 0l <= v439;
                    bool v443;
                    if (v441){
                        bool v442;
                        v442 = v439 < 2l;
                        v443 = v442;
                    } else {
                        v443 = false;
                    }
                    bool v444;
                    v444 = v443 == false;
                    if (v444){
                        assert("The read index needs to be in range for the static array." && v443);
                    } else {
                    }
                    v438.v[v439] = v429;
                    v439 += 1l ;
                }
                US7 v445;
                v445 = US7_1(v416);
                US6 v446;
                v446 = US6_2(v445, true, v403, 0l, v438, v427);
                v502 = true; v503 = v446;
                break;
            }
            case 1: { // ChanceInit
                long v447;
                v447 = v5.length;
                long v448;
                v448 = v447 - 1l;
                bool v449;
                v449 = v448 >= 0l;
                bool v450;
                v450 = v449 == false;
                if (v450){
                    assert("The length before popping has to be greater than 0." && v449);
                } else {
                }
                bool v451;
                v451 = 0l <= v448;
                bool v454;
                if (v451){
                    long v452;
                    v452 = v5.length;
                    bool v453;
                    v453 = v448 < v452;
                    v454 = v453;
                } else {
                    v454 = false;
                }
                bool v455;
                v455 = v454 == false;
                if (v455){
                    assert("The read index needs to be in range for the static array list." && v454);
                } else {
                }
                US3 v456;
                v456 = v5.v[v448];
                v5.length = v448;
                long v457;
                v457 = v5.length;
                long v458;
                v458 = v457 - 1l;
                bool v459;
                v459 = v458 >= 0l;
                bool v460;
                v460 = v459 == false;
                if (v460){
                    assert("The length before popping has to be greater than 0." && v459);
                } else {
                }
                bool v461;
                v461 = 0l <= v458;
                bool v464;
                if (v461){
                    long v462;
                    v462 = v5.length;
                    bool v463;
                    v463 = v458 < v462;
                    v464 = v463;
                } else {
                    v464 = false;
                }
                bool v465;
                v465 = v464 == false;
                if (v465){
                    assert("The read index needs to be in range for the static array list." && v464);
                } else {
                }
                US3 v466;
                v466 = v5.v[v458];
                v5.length = v458;
                long v467;
                v467 = v4.length;
                bool v468;
                v468 = v467 < 32l;
                bool v469;
                v469 = v468 == false;
                if (v469){
                    assert("The length has to be less than the maximum length of the array." && v468);
                } else {
                }
                long v470;
                v470 = v467 + 1l;
                v4.length = v470;
                bool v471;
                v471 = 0l <= v467;
                bool v474;
                if (v471){
                    long v472;
                    v472 = v4.length;
                    bool v473;
                    v473 = v467 < v472;
                    v474 = v473;
                } else {
                    v474 = false;
                }
                bool v475;
                v475 = v474 == false;
                if (v475){
                    assert("The set index needs to be in range for the static array list." && v474);
                } else {
                }
                US4 v476;
                v476 = US4_2(0l, v456);
                v4.v[v467] = v476;
                long v477;
                v477 = v4.length;
                bool v478;
                v478 = v477 < 32l;
                bool v479;
                v479 = v478 == false;
                if (v479){
                    assert("The length has to be less than the maximum length of the array." && v478);
                } else {
                }
                long v480;
                v480 = v477 + 1l;
                v4.length = v480;
                bool v481;
                v481 = 0l <= v477;
                bool v484;
                if (v481){
                    long v482;
                    v482 = v4.length;
                    bool v483;
                    v483 = v477 < v482;
                    v484 = v483;
                } else {
                    v484 = false;
                }
                bool v485;
                v485 = v484 == false;
                if (v485){
                    assert("The set index needs to be in range for the static array list." && v484);
                } else {
                }
                US4 v486;
                v486 = US4_2(1l, v466);
                v4.v[v477] = v486;
                long v487;
                v487 = 2l;
                static_array<long,2l> v488;
                v488.v[0l] = 1l;
                v488.v[1l] = 1l;
                static_array<US3,2l> v489;
                v489.v[0l] = v456;
                v489.v[1l] = v466;
                US7 v490;
                v490 = US7_0();
                US6 v491;
                v491 = US6_2(v490, true, v489, 0l, v488, v487);
                v502 = true; v503 = v491;
                break;
            }
            case 2: { // Round
                US7 v60 = v7.v.case2.v0; bool v61 = v7.v.case2.v1; static_array<US3,2l> v62 = v7.v.case2.v2; long v63 = v7.v.case2.v3; static_array<long,2l> v64 = v7.v.case2.v4; long v65 = v7.v.case2.v5;
                bool v66;
                v66 = 0l <= v63;
                bool v68;
                if (v66){
                    bool v67;
                    v67 = v63 < 2l;
                    v68 = v67;
                } else {
                    v68 = false;
                }
                bool v69;
                v69 = v68 == false;
                if (v69){
                    assert("The read index needs to be in range for the static array." && v68);
                } else {
                }
                US2 v70;
                v70 = v2.v[v63];
                switch (v70.tag) {
                    case 0: { // Computer
                        static_array_list<US1,3l,long> v71;
                        v71.length = 0;
                        v71.length = 1l;
                        long v72;
                        v72 = v71.length;
                        bool v73;
                        v73 = 0l < v72;
                        bool v74;
                        v74 = v73 == false;
                        if (v74){
                            assert("The set index needs to be in range for the static array list." && v73);
                        } else {
                        }
                        US1 v75;
                        v75 = US1_0();
                        v71.v[0l] = v75;
                        long v76;
                        v76 = v64.v[0l];
                        long v77;
                        v77 = v64.v[1l];
                        bool v78;
                        v78 = v76 == v77;
                        bool v79;
                        v79 = v78 != true;
                        if (v79){
                            long v80;
                            v80 = v71.length;
                            bool v81;
                            v81 = v80 < 3l;
                            bool v82;
                            v82 = v81 == false;
                            if (v82){
                                assert("The length has to be less than the maximum length of the array." && v81);
                            } else {
                            }
                            long v83;
                            v83 = v80 + 1l;
                            v71.length = v83;
                            bool v84;
                            v84 = 0l <= v80;
                            bool v87;
                            if (v84){
                                long v85;
                                v85 = v71.length;
                                bool v86;
                                v86 = v80 < v85;
                                v87 = v86;
                            } else {
                                v87 = false;
                            }
                            bool v88;
                            v88 = v87 == false;
                            if (v88){
                                assert("The set index needs to be in range for the static array list." && v87);
                            } else {
                            }
                            US1 v89;
                            v89 = US1_1();
                            v71.v[v80] = v89;
                        } else {
                        }
                        bool v90;
                        v90 = v65 > 0l;
                        if (v90){
                            long v91;
                            v91 = v71.length;
                            bool v92;
                            v92 = v91 < 3l;
                            bool v93;
                            v93 = v92 == false;
                            if (v93){
                                assert("The length has to be less than the maximum length of the array." && v92);
                            } else {
                            }
                            long v94;
                            v94 = v91 + 1l;
                            v71.length = v94;
                            bool v95;
                            v95 = 0l <= v91;
                            bool v98;
                            if (v95){
                                long v96;
                                v96 = v71.length;
                                bool v97;
                                v97 = v91 < v96;
                                v98 = v97;
                            } else {
                                v98 = false;
                            }
                            bool v99;
                            v99 = v98 == false;
                            if (v99){
                                assert("The set index needs to be in range for the static array list." && v98);
                            } else {
                            }
                            US1 v100;
                            v100 = US1_2();
                            v71.v[v91] = v100;
                        } else {
                        }
                        unsigned long long v101;
                        v101 = clock64();
                        curandStatePhilox4_32_10_t v102;
                        curand_init(v101,0ull,0ull,&v102);
                        long v103;
                        v103 = v71.length;
                        long v104;
                        v104 = v103 - 1l;
                        long v105;
                        v105 = 0l;
                        while (while_method_1(v104, v105)){
                            long v107;
                            v107 = v71.length;
                            long v108;
                            v108 = v107 - v105;
                            unsigned long v109;
                            v109 = (unsigned long)v108;
                            unsigned long v110;
                            v110 = loop_22(v109, v102);
                            unsigned long v111;
                            v111 = (unsigned long)v105;
                            unsigned long v112;
                            v112 = v110 + v111;
                            long v113;
                            v113 = (long)v112;
                            bool v114;
                            v114 = 0l <= v105;
                            bool v117;
                            if (v114){
                                long v115;
                                v115 = v71.length;
                                bool v116;
                                v116 = v105 < v115;
                                v117 = v116;
                            } else {
                                v117 = false;
                            }
                            bool v118;
                            v118 = v117 == false;
                            if (v118){
                                assert("The read index needs to be in range for the static array list." && v117);
                            } else {
                            }
                            US1 v119;
                            v119 = v71.v[v105];
                            bool v120;
                            v120 = 0l <= v113;
                            bool v123;
                            if (v120){
                                long v121;
                                v121 = v71.length;
                                bool v122;
                                v122 = v113 < v121;
                                v123 = v122;
                            } else {
                                v123 = false;
                            }
                            bool v124;
                            v124 = v123 == false;
                            if (v124){
                                assert("The read index needs to be in range for the static array list." && v123);
                            } else {
                            }
                            US1 v125;
                            v125 = v71.v[v113];
                            bool v128;
                            if (v114){
                                long v126;
                                v126 = v71.length;
                                bool v127;
                                v127 = v105 < v126;
                                v128 = v127;
                            } else {
                                v128 = false;
                            }
                            bool v129;
                            v129 = v128 == false;
                            if (v129){
                                assert("The set index needs to be in range for the static array list." && v128);
                            } else {
                            }
                            v71.v[v105] = v125;
                            bool v132;
                            if (v120){
                                long v130;
                                v130 = v71.length;
                                bool v131;
                                v131 = v113 < v130;
                                v132 = v131;
                            } else {
                                v132 = false;
                            }
                            bool v133;
                            v133 = v132 == false;
                            if (v133){
                                assert("The set index needs to be in range for the static array list." && v132);
                            } else {
                            }
                            v71.v[v113] = v119;
                            v105 += 1l ;
                        }
                        long v134;
                        v134 = v71.length;
                        long v135;
                        v135 = v134 - 1l;
                        bool v136;
                        v136 = v135 >= 0l;
                        bool v137;
                        v137 = v136 == false;
                        if (v137){
                            assert("The length before popping has to be greater than 0." && v136);
                        } else {
                        }
                        bool v138;
                        v138 = 0l <= v135;
                        bool v141;
                        if (v138){
                            long v139;
                            v139 = v71.length;
                            bool v140;
                            v140 = v135 < v139;
                            v141 = v140;
                        } else {
                            v141 = false;
                        }
                        bool v142;
                        v142 = v141 == false;
                        if (v142){
                            assert("The read index needs to be in range for the static array list." && v141);
                        } else {
                        }
                        US1 v143;
                        v143 = v71.v[v135];
                        v71.length = v135;
                        long v144;
                        v144 = v4.length;
                        bool v145;
                        v145 = v144 < 32l;
                        bool v146;
                        v146 = v145 == false;
                        if (v146){
                            assert("The length has to be less than the maximum length of the array." && v145);
                        } else {
                        }
                        long v147;
                        v147 = v144 + 1l;
                        v4.length = v147;
                        bool v148;
                        v148 = 0l <= v144;
                        bool v151;
                        if (v148){
                            long v149;
                            v149 = v4.length;
                            bool v150;
                            v150 = v144 < v149;
                            v151 = v150;
                        } else {
                            v151 = false;
                        }
                        bool v152;
                        v152 = v151 == false;
                        if (v152){
                            assert("The set index needs to be in range for the static array list." && v151);
                        } else {
                        }
                        US4 v153;
                        v153 = US4_1(v63, v143);
                        v4.v[v144] = v153;
                        US6 v265;
                        switch (v60.tag) {
                            case 0: { // None
                                switch (v143.tag) {
                                    case 0: { // Call
                                        if (v61){
                                            bool v219;
                                            v219 = v63 == 0l;
                                            long v220;
                                            if (v219){
                                                v220 = 1l;
                                            } else {
                                                v220 = 0l;
                                            }
                                            v265 = US6_2(v60, false, v62, v220, v64, v65);
                                        } else {
                                            v265 = US6_0(v60, v61, v62, v63, v64, v65);
                                        }
                                        break;
                                    }
                                    case 1: { // Fold
                                        v265 = US6_5(v60, v61, v62, v63, v64, v65);
                                        break;
                                    }
                                    case 2: { // Raise
                                        if (v90){
                                            bool v224;
                                            v224 = v63 == 0l;
                                            long v225;
                                            if (v224){
                                                v225 = 1l;
                                            } else {
                                                v225 = 0l;
                                            }
                                            long v226;
                                            v226 = -1l + v65;
                                            long v227; long v228;
                                            Tuple8 tmp13 = Tuple8(0l, 0l);
                                            v227 = tmp13.v0; v228 = tmp13.v1;
                                            while (while_method_0(v227)){
                                                bool v230;
                                                v230 = 0l <= v227;
                                                bool v232;
                                                if (v230){
                                                    bool v231;
                                                    v231 = v227 < 2l;
                                                    v232 = v231;
                                                } else {
                                                    v232 = false;
                                                }
                                                bool v233;
                                                v233 = v232 == false;
                                                if (v233){
                                                    assert("The read index needs to be in range for the static array." && v232);
                                                } else {
                                                }
                                                long v234;
                                                v234 = v64.v[v227];
                                                bool v235;
                                                v235 = v228 >= v234;
                                                long v236;
                                                if (v235){
                                                    v236 = v228;
                                                } else {
                                                    v236 = v234;
                                                }
                                                v228 = v236;
                                                v227 += 1l ;
                                            }
                                            static_array<long,2l> v237;
                                            long v238;
                                            v238 = 0l;
                                            while (while_method_0(v238)){
                                                bool v240;
                                                v240 = 0l <= v238;
                                                bool v242;
                                                if (v240){
                                                    bool v241;
                                                    v241 = v238 < 2l;
                                                    v242 = v241;
                                                } else {
                                                    v242 = false;
                                                }
                                                bool v243;
                                                v243 = v242 == false;
                                                if (v243){
                                                    assert("The read index needs to be in range for the static array." && v242);
                                                } else {
                                                }
                                                v237.v[v238] = v228;
                                                v238 += 1l ;
                                            }
                                            static_array<long,2l> v244;
                                            long v245;
                                            v245 = 0l;
                                            while (while_method_0(v245)){
                                                bool v247;
                                                v247 = 0l <= v245;
                                                bool v249;
                                                if (v247){
                                                    bool v248;
                                                    v248 = v245 < 2l;
                                                    v249 = v248;
                                                } else {
                                                    v249 = false;
                                                }
                                                bool v250;
                                                v250 = v249 == false;
                                                if (v250){
                                                    assert("The read index needs to be in range for the static array." && v249);
                                                } else {
                                                }
                                                long v251;
                                                v251 = v237.v[v245];
                                                bool v252;
                                                v252 = v245 == v63;
                                                long v254;
                                                if (v252){
                                                    long v253;
                                                    v253 = v251 + 2l;
                                                    v254 = v253;
                                                } else {
                                                    v254 = v251;
                                                }
                                                bool v256;
                                                if (v247){
                                                    bool v255;
                                                    v255 = v245 < 2l;
                                                    v256 = v255;
                                                } else {
                                                    v256 = false;
                                                }
                                                bool v257;
                                                v257 = v256 == false;
                                                if (v257){
                                                    assert("The read index needs to be in range for the static array." && v256);
                                                } else {
                                                }
                                                v244.v[v245] = v254;
                                                v245 += 1l ;
                                            }
                                            v265 = US6_2(v60, false, v62, v225, v244, v226);
                                        } else {
                                            printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                            asm("exit;");
                                        }
                                        break;
                                    }
                                    default: {
                                        assert("Invalid tag." && false);
                                    }
                                }
                                break;
                            }
                            case 1: { // Some
                                US3 v154 = v60.v.case1.v0;
                                switch (v143.tag) {
                                    case 0: { // Call
                                        if (v61){
                                            bool v156;
                                            v156 = v63 == 0l;
                                            long v157;
                                            if (v156){
                                                v157 = 1l;
                                            } else {
                                                v157 = 0l;
                                            }
                                            v265 = US6_2(v60, false, v62, v157, v64, v65);
                                        } else {
                                            long v159; long v160;
                                            Tuple8 tmp14 = Tuple8(0l, 0l);
                                            v159 = tmp14.v0; v160 = tmp14.v1;
                                            while (while_method_0(v159)){
                                                bool v162;
                                                v162 = 0l <= v159;
                                                bool v164;
                                                if (v162){
                                                    bool v163;
                                                    v163 = v159 < 2l;
                                                    v164 = v163;
                                                } else {
                                                    v164 = false;
                                                }
                                                bool v165;
                                                v165 = v164 == false;
                                                if (v165){
                                                    assert("The read index needs to be in range for the static array." && v164);
                                                } else {
                                                }
                                                long v166;
                                                v166 = v64.v[v159];
                                                bool v167;
                                                v167 = v160 >= v166;
                                                long v168;
                                                if (v167){
                                                    v168 = v160;
                                                } else {
                                                    v168 = v166;
                                                }
                                                v160 = v168;
                                                v159 += 1l ;
                                            }
                                            static_array<long,2l> v169;
                                            long v170;
                                            v170 = 0l;
                                            while (while_method_0(v170)){
                                                bool v172;
                                                v172 = 0l <= v170;
                                                bool v174;
                                                if (v172){
                                                    bool v173;
                                                    v173 = v170 < 2l;
                                                    v174 = v173;
                                                } else {
                                                    v174 = false;
                                                }
                                                bool v175;
                                                v175 = v174 == false;
                                                if (v175){
                                                    assert("The read index needs to be in range for the static array." && v174);
                                                } else {
                                                }
                                                v169.v[v170] = v160;
                                                v170 += 1l ;
                                            }
                                            v265 = US6_4(v60, v61, v62, v63, v169, v65);
                                        }
                                        break;
                                    }
                                    case 1: { // Fold
                                        v265 = US6_5(v60, v61, v62, v63, v64, v65);
                                        break;
                                    }
                                    case 2: { // Raise
                                        if (v90){
                                            bool v178;
                                            v178 = v63 == 0l;
                                            long v179;
                                            if (v178){
                                                v179 = 1l;
                                            } else {
                                                v179 = 0l;
                                            }
                                            long v180;
                                            v180 = -1l + v65;
                                            long v181; long v182;
                                            Tuple8 tmp15 = Tuple8(0l, 0l);
                                            v181 = tmp15.v0; v182 = tmp15.v1;
                                            while (while_method_0(v181)){
                                                bool v184;
                                                v184 = 0l <= v181;
                                                bool v186;
                                                if (v184){
                                                    bool v185;
                                                    v185 = v181 < 2l;
                                                    v186 = v185;
                                                } else {
                                                    v186 = false;
                                                }
                                                bool v187;
                                                v187 = v186 == false;
                                                if (v187){
                                                    assert("The read index needs to be in range for the static array." && v186);
                                                } else {
                                                }
                                                long v188;
                                                v188 = v64.v[v181];
                                                bool v189;
                                                v189 = v182 >= v188;
                                                long v190;
                                                if (v189){
                                                    v190 = v182;
                                                } else {
                                                    v190 = v188;
                                                }
                                                v182 = v190;
                                                v181 += 1l ;
                                            }
                                            static_array<long,2l> v191;
                                            long v192;
                                            v192 = 0l;
                                            while (while_method_0(v192)){
                                                bool v194;
                                                v194 = 0l <= v192;
                                                bool v196;
                                                if (v194){
                                                    bool v195;
                                                    v195 = v192 < 2l;
                                                    v196 = v195;
                                                } else {
                                                    v196 = false;
                                                }
                                                bool v197;
                                                v197 = v196 == false;
                                                if (v197){
                                                    assert("The read index needs to be in range for the static array." && v196);
                                                } else {
                                                }
                                                v191.v[v192] = v182;
                                                v192 += 1l ;
                                            }
                                            static_array<long,2l> v198;
                                            long v199;
                                            v199 = 0l;
                                            while (while_method_0(v199)){
                                                bool v201;
                                                v201 = 0l <= v199;
                                                bool v203;
                                                if (v201){
                                                    bool v202;
                                                    v202 = v199 < 2l;
                                                    v203 = v202;
                                                } else {
                                                    v203 = false;
                                                }
                                                bool v204;
                                                v204 = v203 == false;
                                                if (v204){
                                                    assert("The read index needs to be in range for the static array." && v203);
                                                } else {
                                                }
                                                long v205;
                                                v205 = v191.v[v199];
                                                bool v206;
                                                v206 = v199 == v63;
                                                long v208;
                                                if (v206){
                                                    long v207;
                                                    v207 = v205 + 4l;
                                                    v208 = v207;
                                                } else {
                                                    v208 = v205;
                                                }
                                                bool v210;
                                                if (v201){
                                                    bool v209;
                                                    v209 = v199 < 2l;
                                                    v210 = v209;
                                                } else {
                                                    v210 = false;
                                                }
                                                bool v211;
                                                v211 = v210 == false;
                                                if (v211){
                                                    assert("The read index needs to be in range for the static array." && v210);
                                                } else {
                                                }
                                                v198.v[v199] = v208;
                                                v199 += 1l ;
                                            }
                                            v265 = US6_2(v60, false, v62, v179, v198, v180);
                                        } else {
                                            printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                            asm("exit;");
                                        }
                                        break;
                                    }
                                    default: {
                                        assert("Invalid tag." && false);
                                    }
                                }
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        v502 = true; v503 = v265;
                        break;
                    }
                    case 1: { // Human
                        v502 = false; v503 = v7;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                break;
            }
            case 3: { // RoundWithAction
                US7 v270 = v7.v.case3.v0; bool v271 = v7.v.case3.v1; static_array<US3,2l> v272 = v7.v.case3.v2; long v273 = v7.v.case3.v3; static_array<long,2l> v274 = v7.v.case3.v4; long v275 = v7.v.case3.v5; US1 v276 = v7.v.case3.v6;
                long v277;
                v277 = v4.length;
                bool v278;
                v278 = v277 < 32l;
                bool v279;
                v279 = v278 == false;
                if (v279){
                    assert("The length has to be less than the maximum length of the array." && v278);
                } else {
                }
                long v280;
                v280 = v277 + 1l;
                v4.length = v280;
                bool v281;
                v281 = 0l <= v277;
                bool v284;
                if (v281){
                    long v282;
                    v282 = v4.length;
                    bool v283;
                    v283 = v277 < v282;
                    v284 = v283;
                } else {
                    v284 = false;
                }
                bool v285;
                v285 = v284 == false;
                if (v285){
                    assert("The set index needs to be in range for the static array list." && v284);
                } else {
                }
                US4 v286;
                v286 = US4_1(v273, v276);
                v4.v[v277] = v286;
                US6 v400;
                switch (v270.tag) {
                    case 0: { // None
                        switch (v276.tag) {
                            case 0: { // Call
                                if (v271){
                                    bool v353;
                                    v353 = v273 == 0l;
                                    long v354;
                                    if (v353){
                                        v354 = 1l;
                                    } else {
                                        v354 = 0l;
                                    }
                                    v400 = US6_2(v270, false, v272, v354, v274, v275);
                                } else {
                                    v400 = US6_0(v270, v271, v272, v273, v274, v275);
                                }
                                break;
                            }
                            case 1: { // Fold
                                v400 = US6_5(v270, v271, v272, v273, v274, v275);
                                break;
                            }
                            case 2: { // Raise
                                bool v358;
                                v358 = v275 > 0l;
                                if (v358){
                                    bool v359;
                                    v359 = v273 == 0l;
                                    long v360;
                                    if (v359){
                                        v360 = 1l;
                                    } else {
                                        v360 = 0l;
                                    }
                                    long v361;
                                    v361 = -1l + v275;
                                    long v362; long v363;
                                    Tuple8 tmp16 = Tuple8(0l, 0l);
                                    v362 = tmp16.v0; v363 = tmp16.v1;
                                    while (while_method_0(v362)){
                                        bool v365;
                                        v365 = 0l <= v362;
                                        bool v367;
                                        if (v365){
                                            bool v366;
                                            v366 = v362 < 2l;
                                            v367 = v366;
                                        } else {
                                            v367 = false;
                                        }
                                        bool v368;
                                        v368 = v367 == false;
                                        if (v368){
                                            assert("The read index needs to be in range for the static array." && v367);
                                        } else {
                                        }
                                        long v369;
                                        v369 = v274.v[v362];
                                        bool v370;
                                        v370 = v363 >= v369;
                                        long v371;
                                        if (v370){
                                            v371 = v363;
                                        } else {
                                            v371 = v369;
                                        }
                                        v363 = v371;
                                        v362 += 1l ;
                                    }
                                    static_array<long,2l> v372;
                                    long v373;
                                    v373 = 0l;
                                    while (while_method_0(v373)){
                                        bool v375;
                                        v375 = 0l <= v373;
                                        bool v377;
                                        if (v375){
                                            bool v376;
                                            v376 = v373 < 2l;
                                            v377 = v376;
                                        } else {
                                            v377 = false;
                                        }
                                        bool v378;
                                        v378 = v377 == false;
                                        if (v378){
                                            assert("The read index needs to be in range for the static array." && v377);
                                        } else {
                                        }
                                        v372.v[v373] = v363;
                                        v373 += 1l ;
                                    }
                                    static_array<long,2l> v379;
                                    long v380;
                                    v380 = 0l;
                                    while (while_method_0(v380)){
                                        bool v382;
                                        v382 = 0l <= v380;
                                        bool v384;
                                        if (v382){
                                            bool v383;
                                            v383 = v380 < 2l;
                                            v384 = v383;
                                        } else {
                                            v384 = false;
                                        }
                                        bool v385;
                                        v385 = v384 == false;
                                        if (v385){
                                            assert("The read index needs to be in range for the static array." && v384);
                                        } else {
                                        }
                                        long v386;
                                        v386 = v372.v[v380];
                                        bool v387;
                                        v387 = v380 == v273;
                                        long v389;
                                        if (v387){
                                            long v388;
                                            v388 = v386 + 2l;
                                            v389 = v388;
                                        } else {
                                            v389 = v386;
                                        }
                                        bool v391;
                                        if (v382){
                                            bool v390;
                                            v390 = v380 < 2l;
                                            v391 = v390;
                                        } else {
                                            v391 = false;
                                        }
                                        bool v392;
                                        v392 = v391 == false;
                                        if (v392){
                                            assert("The read index needs to be in range for the static array." && v391);
                                        } else {
                                        }
                                        v379.v[v380] = v389;
                                        v380 += 1l ;
                                    }
                                    v400 = US6_2(v270, false, v272, v360, v379, v361);
                                } else {
                                    printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                    asm("exit;");
                                }
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        break;
                    }
                    case 1: { // Some
                        US3 v287 = v270.v.case1.v0;
                        switch (v276.tag) {
                            case 0: { // Call
                                if (v271){
                                    bool v289;
                                    v289 = v273 == 0l;
                                    long v290;
                                    if (v289){
                                        v290 = 1l;
                                    } else {
                                        v290 = 0l;
                                    }
                                    v400 = US6_2(v270, false, v272, v290, v274, v275);
                                } else {
                                    long v292; long v293;
                                    Tuple8 tmp17 = Tuple8(0l, 0l);
                                    v292 = tmp17.v0; v293 = tmp17.v1;
                                    while (while_method_0(v292)){
                                        bool v295;
                                        v295 = 0l <= v292;
                                        bool v297;
                                        if (v295){
                                            bool v296;
                                            v296 = v292 < 2l;
                                            v297 = v296;
                                        } else {
                                            v297 = false;
                                        }
                                        bool v298;
                                        v298 = v297 == false;
                                        if (v298){
                                            assert("The read index needs to be in range for the static array." && v297);
                                        } else {
                                        }
                                        long v299;
                                        v299 = v274.v[v292];
                                        bool v300;
                                        v300 = v293 >= v299;
                                        long v301;
                                        if (v300){
                                            v301 = v293;
                                        } else {
                                            v301 = v299;
                                        }
                                        v293 = v301;
                                        v292 += 1l ;
                                    }
                                    static_array<long,2l> v302;
                                    long v303;
                                    v303 = 0l;
                                    while (while_method_0(v303)){
                                        bool v305;
                                        v305 = 0l <= v303;
                                        bool v307;
                                        if (v305){
                                            bool v306;
                                            v306 = v303 < 2l;
                                            v307 = v306;
                                        } else {
                                            v307 = false;
                                        }
                                        bool v308;
                                        v308 = v307 == false;
                                        if (v308){
                                            assert("The read index needs to be in range for the static array." && v307);
                                        } else {
                                        }
                                        v302.v[v303] = v293;
                                        v303 += 1l ;
                                    }
                                    v400 = US6_4(v270, v271, v272, v273, v302, v275);
                                }
                                break;
                            }
                            case 1: { // Fold
                                v400 = US6_5(v270, v271, v272, v273, v274, v275);
                                break;
                            }
                            case 2: { // Raise
                                bool v311;
                                v311 = v275 > 0l;
                                if (v311){
                                    bool v312;
                                    v312 = v273 == 0l;
                                    long v313;
                                    if (v312){
                                        v313 = 1l;
                                    } else {
                                        v313 = 0l;
                                    }
                                    long v314;
                                    v314 = -1l + v275;
                                    long v315; long v316;
                                    Tuple8 tmp18 = Tuple8(0l, 0l);
                                    v315 = tmp18.v0; v316 = tmp18.v1;
                                    while (while_method_0(v315)){
                                        bool v318;
                                        v318 = 0l <= v315;
                                        bool v320;
                                        if (v318){
                                            bool v319;
                                            v319 = v315 < 2l;
                                            v320 = v319;
                                        } else {
                                            v320 = false;
                                        }
                                        bool v321;
                                        v321 = v320 == false;
                                        if (v321){
                                            assert("The read index needs to be in range for the static array." && v320);
                                        } else {
                                        }
                                        long v322;
                                        v322 = v274.v[v315];
                                        bool v323;
                                        v323 = v316 >= v322;
                                        long v324;
                                        if (v323){
                                            v324 = v316;
                                        } else {
                                            v324 = v322;
                                        }
                                        v316 = v324;
                                        v315 += 1l ;
                                    }
                                    static_array<long,2l> v325;
                                    long v326;
                                    v326 = 0l;
                                    while (while_method_0(v326)){
                                        bool v328;
                                        v328 = 0l <= v326;
                                        bool v330;
                                        if (v328){
                                            bool v329;
                                            v329 = v326 < 2l;
                                            v330 = v329;
                                        } else {
                                            v330 = false;
                                        }
                                        bool v331;
                                        v331 = v330 == false;
                                        if (v331){
                                            assert("The read index needs to be in range for the static array." && v330);
                                        } else {
                                        }
                                        v325.v[v326] = v316;
                                        v326 += 1l ;
                                    }
                                    static_array<long,2l> v332;
                                    long v333;
                                    v333 = 0l;
                                    while (while_method_0(v333)){
                                        bool v335;
                                        v335 = 0l <= v333;
                                        bool v337;
                                        if (v335){
                                            bool v336;
                                            v336 = v333 < 2l;
                                            v337 = v336;
                                        } else {
                                            v337 = false;
                                        }
                                        bool v338;
                                        v338 = v337 == false;
                                        if (v338){
                                            assert("The read index needs to be in range for the static array." && v337);
                                        } else {
                                        }
                                        long v339;
                                        v339 = v325.v[v333];
                                        bool v340;
                                        v340 = v333 == v273;
                                        long v342;
                                        if (v340){
                                            long v341;
                                            v341 = v339 + 4l;
                                            v342 = v341;
                                        } else {
                                            v342 = v339;
                                        }
                                        bool v344;
                                        if (v335){
                                            bool v343;
                                            v343 = v333 < 2l;
                                            v344 = v343;
                                        } else {
                                            v344 = false;
                                        }
                                        bool v345;
                                        v345 = v344 == false;
                                        if (v345){
                                            assert("The read index needs to be in range for the static array." && v344);
                                        } else {
                                        }
                                        v332.v[v333] = v342;
                                        v333 += 1l ;
                                    }
                                    v400 = US6_2(v270, false, v272, v313, v332, v314);
                                } else {
                                    printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                    asm("exit;");
                                }
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                v502 = true; v503 = v400;
                break;
            }
            case 4: { // TerminalCall
                US7 v32 = v7.v.case4.v0; bool v33 = v7.v.case4.v1; static_array<US3,2l> v34 = v7.v.case4.v2; long v35 = v7.v.case4.v3; static_array<long,2l> v36 = v7.v.case4.v4; long v37 = v7.v.case4.v5;
                bool v38;
                v38 = 0l <= v35;
                bool v40;
                if (v38){
                    bool v39;
                    v39 = v35 < 2l;
                    v40 = v39;
                } else {
                    v40 = false;
                }
                bool v41;
                v41 = v40 == false;
                if (v41){
                    assert("The read index needs to be in range for the static array." && v40);
                } else {
                }
                long v42;
                v42 = v36.v[v35];
                US9 v43;
                v43 = compare_hands_23(v32, v33, v34, v35, v36, v37);
                long v48; long v49;
                switch (v43.tag) {
                    case 0: { // Eq
                        v48 = 0l; v49 = -1l;
                        break;
                    }
                    case 1: { // Gt
                        v48 = v42; v49 = 0l;
                        break;
                    }
                    case 2: { // Lt
                        v48 = v42; v49 = 1l;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                long v50;
                v50 = v4.length;
                bool v51;
                v51 = v50 < 32l;
                bool v52;
                v52 = v51 == false;
                if (v52){
                    assert("The length has to be less than the maximum length of the array." && v51);
                } else {
                }
                long v53;
                v53 = v50 + 1l;
                v4.length = v53;
                bool v54;
                v54 = 0l <= v50;
                bool v57;
                if (v54){
                    long v55;
                    v55 = v4.length;
                    bool v56;
                    v56 = v50 < v55;
                    v57 = v56;
                } else {
                    v57 = false;
                }
                bool v58;
                v58 = v57 == false;
                if (v58){
                    assert("The set index needs to be in range for the static array list." && v57);
                } else {
                }
                US4 v59;
                v59 = US4_3(v34, v48, v49);
                v4.v[v50] = v59;
                v502 = false; v503 = v7;
                break;
            }
            case 5: { // TerminalFold
                US7 v9 = v7.v.case5.v0; bool v10 = v7.v.case5.v1; static_array<US3,2l> v11 = v7.v.case5.v2; long v12 = v7.v.case5.v3; static_array<long,2l> v13 = v7.v.case5.v4; long v14 = v7.v.case5.v5;
                bool v15;
                v15 = 0l <= v12;
                bool v17;
                if (v15){
                    bool v16;
                    v16 = v12 < 2l;
                    v17 = v16;
                } else {
                    v17 = false;
                }
                bool v18;
                v18 = v17 == false;
                if (v18){
                    assert("The read index needs to be in range for the static array." && v17);
                } else {
                }
                long v19;
                v19 = v13.v[v12];
                bool v20;
                v20 = v12 == 0l;
                long v21;
                if (v20){
                    v21 = 1l;
                } else {
                    v21 = 0l;
                }
                long v22;
                v22 = v4.length;
                bool v23;
                v23 = v22 < 32l;
                bool v24;
                v24 = v23 == false;
                if (v24){
                    assert("The length has to be less than the maximum length of the array." && v23);
                } else {
                }
                long v25;
                v25 = v22 + 1l;
                v4.length = v25;
                bool v26;
                v26 = 0l <= v22;
                bool v29;
                if (v26){
                    long v27;
                    v27 = v4.length;
                    bool v28;
                    v28 = v22 < v27;
                    v29 = v28;
                } else {
                    v29 = false;
                }
                bool v30;
                v30 = v29 == false;
                if (v30){
                    assert("The set index needs to be in range for the static array list." && v29);
                } else {
                }
                US4 v31;
                v31 = US4_3(v11, v19, v21);
                v4.v[v22] = v31;
                v502 = false; v503 = v7;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        v6 = v502;
        v7 = v503;
    }
    return v7;
}
__device__ Tuple6 play_loop_20(US5 v0, static_array<US2,2l> v1, US8 v2, static_array_list<US3,6l,long> & v3, static_array_list<US4,32l,long> & v4, US6 v5){
    US6 v6;
    v6 = play_loop_inner_21(v3, v4, v1, v5);
    switch (v6.tag) {
        case 2: { // Round
            US7 v7 = v6.v.case2.v0; bool v8 = v6.v.case2.v1; static_array<US3,2l> v9 = v6.v.case2.v2; long v10 = v6.v.case2.v3; static_array<long,2l> v11 = v6.v.case2.v4; long v12 = v6.v.case2.v5;
            US5 v13;
            v13 = US5_1(v6);
            US8 v14;
            v14 = US8_2(v7, v8, v9, v10, v11, v12);
            return Tuple6(v13, v1, v14);
            break;
        }
        case 4: { // TerminalCall
            US7 v15 = v6.v.case4.v0; bool v16 = v6.v.case4.v1; static_array<US3,2l> v17 = v6.v.case4.v2; long v18 = v6.v.case4.v3; static_array<long,2l> v19 = v6.v.case4.v4; long v20 = v6.v.case4.v5;
            US5 v21;
            v21 = US5_0();
            US8 v22;
            v22 = US8_1(v15, v16, v17, v18, v19, v20);
            return Tuple6(v21, v1, v22);
            break;
        }
        case 5: { // TerminalFold
            US7 v23 = v6.v.case5.v0; bool v24 = v6.v.case5.v1; static_array<US3,2l> v25 = v6.v.case5.v2; long v26 = v6.v.case5.v3; static_array<long,2l> v27 = v6.v.case5.v4; long v28 = v6.v.case5.v5;
            US5 v29;
            v29 = US5_0();
            US8 v30;
            v30 = US8_1(v23, v24, v25, v26, v27, v28);
            return Tuple6(v29, v1, v30);
            break;
        }
        default: {
            printf("%s\n", "Unexpected node received in play_loop.");
            asm("exit;");
        }
    }
}
__device__ void f_28(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_30(unsigned char * v0){
    return ;
}
__device__ void f_29(unsigned char * v0, US3 v1){
    long v2;
    v2 = v1.tag;
    f_28(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Jack
            return f_30(v3);
            break;
        }
        case 1: { // King
            return f_30(v3);
            break;
        }
        case 2: { // Queen
            return f_30(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_31(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+28ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_34(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_33(unsigned char * v0, long v1, US1 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_34(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // Call
            return f_30(v5);
            break;
        }
        case 1: { // Fold
            return f_30(v5);
            break;
        }
        case 2: { // Raise
            return f_30(v5);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_35(unsigned char * v0, long v1, US3 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_34(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // Jack
            return f_30(v5);
            break;
        }
        case 1: { // King
            return f_30(v5);
            break;
        }
        case 2: { // Queen
            return f_30(v5);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_36(unsigned char * v0, static_array<US3,2l> v1, long v2, long v3){
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 4ull;
        unsigned char * v8;
        v8 = (unsigned char *)(v0+v7);
        bool v9;
        v9 = 0l <= v4;
        bool v11;
        if (v9){
            bool v10;
            v10 = v4 < 2l;
            v11 = v10;
        } else {
            v11 = false;
        }
        bool v12;
        v12 = v11 == false;
        if (v12){
            assert("The read index needs to be in range for the static array." && v11);
        } else {
        }
        US3 v13;
        v13 = v1.v[v4];
        f_29(v8, v13);
        v4 += 1l ;
    }
    long * v14;
    v14 = (long *)(v0+8ull);
    v14[0l] = v2;
    long * v15;
    v15 = (long *)(v0+12ull);
    v15[0l] = v3;
    return ;
}
__device__ void f_32(unsigned char * v0, US4 v1){
    long v2;
    v2 = v1.tag;
    f_28(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // CommunityCardIs
            US3 v4 = v1.v.case0.v0;
            return f_29(v3, v4);
            break;
        }
        case 1: { // PlayerAction
            long v5 = v1.v.case1.v0; US1 v6 = v1.v.case1.v1;
            return f_33(v3, v5, v6);
            break;
        }
        case 2: { // PlayerGotCard
            long v7 = v1.v.case2.v0; US3 v8 = v1.v.case2.v1;
            return f_35(v3, v7, v8);
            break;
        }
        case 3: { // Showdown
            static_array<US3,2l> v9 = v1.v.case3.v0; long v10 = v1.v.case3.v1; long v11 = v1.v.case3.v2;
            return f_36(v3, v9, v10, v11);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_37(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+1056ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_39(unsigned char * v0, US7 v1, bool v2, static_array<US3,2l> v3, long v4, static_array<long,2l> v5, long v6){
    long v7;
    v7 = v1.tag;
    f_28(v0, v7);
    unsigned char * v8;
    v8 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // None
            f_30(v8);
            break;
        }
        case 1: { // Some
            US3 v9 = v1.v.case1.v0;
            f_29(v8, v9);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    bool * v10;
    v10 = (bool *)(v0+8ull);
    v10[0l] = v2;
    long v11;
    v11 = 0l;
    while (while_method_0(v11)){
        unsigned long long v13;
        v13 = (unsigned long long)v11;
        unsigned long long v14;
        v14 = v13 * 4ull;
        unsigned long long v15;
        v15 = 12ull + v14;
        unsigned char * v16;
        v16 = (unsigned char *)(v0+v15);
        bool v17;
        v17 = 0l <= v11;
        bool v19;
        if (v17){
            bool v18;
            v18 = v11 < 2l;
            v19 = v18;
        } else {
            v19 = false;
        }
        bool v20;
        v20 = v19 == false;
        if (v20){
            assert("The read index needs to be in range for the static array." && v19);
        } else {
        }
        US3 v21;
        v21 = v3.v[v11];
        f_29(v16, v21);
        v11 += 1l ;
    }
    long * v22;
    v22 = (long *)(v0+20ull);
    v22[0l] = v4;
    long v23;
    v23 = 0l;
    while (while_method_0(v23)){
        unsigned long long v25;
        v25 = (unsigned long long)v23;
        unsigned long long v26;
        v26 = v25 * 4ull;
        unsigned long long v27;
        v27 = 24ull + v26;
        unsigned char * v28;
        v28 = (unsigned char *)(v0+v27);
        bool v29;
        v29 = 0l <= v23;
        bool v31;
        if (v29){
            bool v30;
            v30 = v23 < 2l;
            v31 = v30;
        } else {
            v31 = false;
        }
        bool v32;
        v32 = v31 == false;
        if (v32){
            assert("The read index needs to be in range for the static array." && v31);
        } else {
        }
        long v33;
        v33 = v5.v[v23];
        f_28(v28, v33);
        v23 += 1l ;
    }
    long * v34;
    v34 = (long *)(v0+32ull);
    v34[0l] = v6;
    return ;
}
__device__ void f_41(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+36ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_40(unsigned char * v0, US7 v1, bool v2, static_array<US3,2l> v3, long v4, static_array<long,2l> v5, long v6, US1 v7){
    long v8;
    v8 = v1.tag;
    f_28(v0, v8);
    unsigned char * v9;
    v9 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // None
            f_30(v9);
            break;
        }
        case 1: { // Some
            US3 v10 = v1.v.case1.v0;
            f_29(v9, v10);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    bool * v11;
    v11 = (bool *)(v0+8ull);
    v11[0l] = v2;
    long v12;
    v12 = 0l;
    while (while_method_0(v12)){
        unsigned long long v14;
        v14 = (unsigned long long)v12;
        unsigned long long v15;
        v15 = v14 * 4ull;
        unsigned long long v16;
        v16 = 12ull + v15;
        unsigned char * v17;
        v17 = (unsigned char *)(v0+v16);
        bool v18;
        v18 = 0l <= v12;
        bool v20;
        if (v18){
            bool v19;
            v19 = v12 < 2l;
            v20 = v19;
        } else {
            v20 = false;
        }
        bool v21;
        v21 = v20 == false;
        if (v21){
            assert("The read index needs to be in range for the static array." && v20);
        } else {
        }
        US3 v22;
        v22 = v3.v[v12];
        f_29(v17, v22);
        v12 += 1l ;
    }
    long * v23;
    v23 = (long *)(v0+20ull);
    v23[0l] = v4;
    long v24;
    v24 = 0l;
    while (while_method_0(v24)){
        unsigned long long v26;
        v26 = (unsigned long long)v24;
        unsigned long long v27;
        v27 = v26 * 4ull;
        unsigned long long v28;
        v28 = 24ull + v27;
        unsigned char * v29;
        v29 = (unsigned char *)(v0+v28);
        bool v30;
        v30 = 0l <= v24;
        bool v32;
        if (v30){
            bool v31;
            v31 = v24 < 2l;
            v32 = v31;
        } else {
            v32 = false;
        }
        bool v33;
        v33 = v32 == false;
        if (v33){
            assert("The read index needs to be in range for the static array." && v32);
        } else {
        }
        long v34;
        v34 = v5.v[v24];
        f_28(v29, v34);
        v24 += 1l ;
    }
    long * v35;
    v35 = (long *)(v0+32ull);
    v35[0l] = v6;
    long v36;
    v36 = v7.tag;
    f_41(v0, v36);
    unsigned char * v37;
    v37 = (unsigned char *)(v0+40ull);
    switch (v7.tag) {
        case 0: { // Call
            return f_30(v37);
            break;
        }
        case 1: { // Fold
            return f_30(v37);
            break;
        }
        case 2: { // Raise
            return f_30(v37);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_38(unsigned char * v0, US6 v1){
    long v2;
    v2 = v1.tag;
    f_28(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // ChanceCommunityCard
            US7 v4 = v1.v.case0.v0; bool v5 = v1.v.case0.v1; static_array<US3,2l> v6 = v1.v.case0.v2; long v7 = v1.v.case0.v3; static_array<long,2l> v8 = v1.v.case0.v4; long v9 = v1.v.case0.v5;
            return f_39(v3, v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: { // ChanceInit
            return f_30(v3);
            break;
        }
        case 2: { // Round
            US7 v10 = v1.v.case2.v0; bool v11 = v1.v.case2.v1; static_array<US3,2l> v12 = v1.v.case2.v2; long v13 = v1.v.case2.v3; static_array<long,2l> v14 = v1.v.case2.v4; long v15 = v1.v.case2.v5;
            return f_39(v3, v10, v11, v12, v13, v14, v15);
            break;
        }
        case 3: { // RoundWithAction
            US7 v16 = v1.v.case3.v0; bool v17 = v1.v.case3.v1; static_array<US3,2l> v18 = v1.v.case3.v2; long v19 = v1.v.case3.v3; static_array<long,2l> v20 = v1.v.case3.v4; long v21 = v1.v.case3.v5; US1 v22 = v1.v.case3.v6;
            return f_40(v3, v16, v17, v18, v19, v20, v21, v22);
            break;
        }
        case 4: { // TerminalCall
            US7 v23 = v1.v.case4.v0; bool v24 = v1.v.case4.v1; static_array<US3,2l> v25 = v1.v.case4.v2; long v26 = v1.v.case4.v3; static_array<long,2l> v27 = v1.v.case4.v4; long v28 = v1.v.case4.v5;
            return f_39(v3, v23, v24, v25, v26, v27, v28);
            break;
        }
        case 5: { // TerminalFold
            US7 v29 = v1.v.case5.v0; bool v30 = v1.v.case5.v1; static_array<US3,2l> v31 = v1.v.case5.v2; long v32 = v1.v.case5.v3; static_array<long,2l> v33 = v1.v.case5.v4; long v34 = v1.v.case5.v5;
            return f_39(v3, v29, v30, v31, v32, v33, v34);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_42(unsigned char * v0, US2 v1){
    long v2;
    v2 = v1.tag;
    f_28(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Computer
            return f_30(v3);
            break;
        }
        case 1: { // Human
            return f_30(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_43(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+1144ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_27(unsigned char * v0, static_array_list<US3,6l,long> v1, static_array_list<US4,32l,long> v2, US5 v3, static_array<US2,2l> v4, US8 v5){
    long v6;
    v6 = v1.length;
    f_28(v0, v6);
    long v7;
    v7 = v1.length;
    long v8;
    v8 = 0l;
    while (while_method_1(v7, v8)){
        unsigned long long v10;
        v10 = (unsigned long long)v8;
        unsigned long long v11;
        v11 = v10 * 4ull;
        unsigned long long v12;
        v12 = 4ull + v11;
        unsigned char * v13;
        v13 = (unsigned char *)(v0+v12);
        bool v14;
        v14 = 0l <= v8;
        bool v17;
        if (v14){
            long v15;
            v15 = v1.length;
            bool v16;
            v16 = v8 < v15;
            v17 = v16;
        } else {
            v17 = false;
        }
        bool v18;
        v18 = v17 == false;
        if (v18){
            assert("The read index needs to be in range for the static array list." && v17);
        } else {
        }
        US3 v19;
        v19 = v1.v[v8];
        f_29(v13, v19);
        v8 += 1l ;
    }
    long v20;
    v20 = v2.length;
    f_31(v0, v20);
    long v21;
    v21 = v2.length;
    long v22;
    v22 = 0l;
    while (while_method_1(v21, v22)){
        unsigned long long v24;
        v24 = (unsigned long long)v22;
        unsigned long long v25;
        v25 = v24 * 32ull;
        unsigned long long v26;
        v26 = 32ull + v25;
        unsigned char * v27;
        v27 = (unsigned char *)(v0+v26);
        bool v28;
        v28 = 0l <= v22;
        bool v31;
        if (v28){
            long v29;
            v29 = v2.length;
            bool v30;
            v30 = v22 < v29;
            v31 = v30;
        } else {
            v31 = false;
        }
        bool v32;
        v32 = v31 == false;
        if (v32){
            assert("The read index needs to be in range for the static array list." && v31);
        } else {
        }
        US4 v33;
        v33 = v2.v[v22];
        f_32(v27, v33);
        v22 += 1l ;
    }
    long v34;
    v34 = v3.tag;
    f_37(v0, v34);
    unsigned char * v35;
    v35 = (unsigned char *)(v0+1072ull);
    switch (v3.tag) {
        case 0: { // None
            f_30(v35);
            break;
        }
        case 1: { // Some
            US6 v36 = v3.v.case1.v0;
            f_38(v35, v36);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v37;
    v37 = 0l;
    while (while_method_0(v37)){
        unsigned long long v39;
        v39 = (unsigned long long)v37;
        unsigned long long v40;
        v40 = v39 * 4ull;
        unsigned long long v41;
        v41 = 1136ull + v40;
        unsigned char * v42;
        v42 = (unsigned char *)(v0+v41);
        bool v43;
        v43 = 0l <= v37;
        bool v45;
        if (v43){
            bool v44;
            v44 = v37 < 2l;
            v45 = v44;
        } else {
            v45 = false;
        }
        bool v46;
        v46 = v45 == false;
        if (v46){
            assert("The read index needs to be in range for the static array." && v45);
        } else {
        }
        US2 v47;
        v47 = v4.v[v37];
        f_42(v42, v47);
        v37 += 1l ;
    }
    long v48;
    v48 = v5.tag;
    f_43(v0, v48);
    unsigned char * v49;
    v49 = (unsigned char *)(v0+1152ull);
    switch (v5.tag) {
        case 0: { // GameNotStarted
            return f_30(v49);
            break;
        }
        case 1: { // GameOver
            US7 v50 = v5.v.case1.v0; bool v51 = v5.v.case1.v1; static_array<US3,2l> v52 = v5.v.case1.v2; long v53 = v5.v.case1.v3; static_array<long,2l> v54 = v5.v.case1.v4; long v55 = v5.v.case1.v5;
            return f_39(v49, v50, v51, v52, v53, v54, v55);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            US7 v56 = v5.v.case2.v0; bool v57 = v5.v.case2.v1; static_array<US3,2l> v58 = v5.v.case2.v2; long v59 = v5.v.case2.v3; static_array<long,2l> v60 = v5.v.case2.v4; long v61 = v5.v.case2.v5;
            return f_39(v49, v56, v57, v58, v59, v60, v61);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_45(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+1048ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_44(unsigned char * v0, static_array_list<US4,32l,long> v1, static_array<US2,2l> v2, US8 v3){
    long v4;
    v4 = v1.length;
    f_28(v0, v4);
    long v5;
    v5 = v1.length;
    long v6;
    v6 = 0l;
    while (while_method_1(v5, v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 32ull;
        unsigned long long v10;
        v10 = 16ull + v9;
        unsigned char * v11;
        v11 = (unsigned char *)(v0+v10);
        bool v12;
        v12 = 0l <= v6;
        bool v15;
        if (v12){
            long v13;
            v13 = v1.length;
            bool v14;
            v14 = v6 < v13;
            v15 = v14;
        } else {
            v15 = false;
        }
        bool v16;
        v16 = v15 == false;
        if (v16){
            assert("The read index needs to be in range for the static array list." && v15);
        } else {
        }
        US4 v17;
        v17 = v1.v[v6];
        f_32(v11, v17);
        v6 += 1l ;
    }
    long v18;
    v18 = 0l;
    while (while_method_0(v18)){
        unsigned long long v20;
        v20 = (unsigned long long)v18;
        unsigned long long v21;
        v21 = v20 * 4ull;
        unsigned long long v22;
        v22 = 1040ull + v21;
        unsigned char * v23;
        v23 = (unsigned char *)(v0+v22);
        bool v24;
        v24 = 0l <= v18;
        bool v26;
        if (v24){
            bool v25;
            v25 = v18 < 2l;
            v26 = v25;
        } else {
            v26 = false;
        }
        bool v27;
        v27 = v26 == false;
        if (v27){
            assert("The read index needs to be in range for the static array." && v26);
        } else {
        }
        US2 v28;
        v28 = v2.v[v18];
        f_42(v23, v28);
        v18 += 1l ;
    }
    long v29;
    v29 = v3.tag;
    f_45(v0, v29);
    unsigned char * v30;
    v30 = (unsigned char *)(v0+1056ull);
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return f_30(v30);
            break;
        }
        case 1: { // GameOver
            US7 v31 = v3.v.case1.v0; bool v32 = v3.v.case1.v1; static_array<US3,2l> v33 = v3.v.case1.v2; long v34 = v3.v.case1.v3; static_array<long,2l> v35 = v3.v.case1.v4; long v36 = v3.v.case1.v5;
            return f_39(v30, v31, v32, v33, v34, v35, v36);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            US7 v37 = v3.v.case2.v0; bool v38 = v3.v.case2.v1; static_array<US3,2l> v39 = v3.v.case2.v2; long v40 = v3.v.case2.v3; static_array<long,2l> v41 = v3.v.case2.v4; long v42 = v3.v.case2.v5;
            return f_39(v30, v37, v38, v39, v40, v41, v42);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
extern "C" __global__ void entry0(unsigned char * v0, unsigned char * v1, unsigned char * v2) {
    long v3;
    v3 = threadIdx.x;
    long v4;
    v4 = blockIdx.x;
    long v5;
    v5 = v4 * 512l;
    long v6;
    v6 = v3 + v5;
    bool v7;
    v7 = v6 == 0l;
    if (v7){
        US0 v8;
        v8 = f_0(v1);
        static_array_list<US3,6l,long> v9; static_array_list<US4,32l,long> v10; US5 v11; static_array<US2,2l> v12; US8 v13;
        Tuple0 tmp10 = f_6(v0);
        v9 = tmp10.v0; v10 = tmp10.v1; v11 = tmp10.v2; v12 = tmp10.v3; v13 = tmp10.v4;
        static_array_list<US3,6l,long> & v14 = v9;
        static_array_list<US4,32l,long> & v15 = v10;
        US5 v115; static_array<US2,2l> v116; US8 v117;
        switch (v8.tag) {
            case 0: { // ActionSelected
                US1 v85 = v8.v.case0.v0;
                switch (v11.tag) {
                    case 0: { // None
                        v115 = v11; v116 = v12; v117 = v13;
                        break;
                    }
                    case 1: { // Some
                        US6 v86 = v11.v.case1.v0;
                        switch (v86.tag) {
                            case 2: { // Round
                                US7 v87 = v86.v.case2.v0; bool v88 = v86.v.case2.v1; static_array<US3,2l> v89 = v86.v.case2.v2; long v90 = v86.v.case2.v3; static_array<long,2l> v91 = v86.v.case2.v4; long v92 = v86.v.case2.v5;
                                US6 v93;
                                v93 = US6_3(v87, v88, v89, v90, v91, v92, v85);
                                Tuple6 tmp21 = play_loop_20(v11, v12, v13, v14, v15, v93);
                                v115 = tmp21.v0; v116 = tmp21.v1; v117 = tmp21.v2;
                                break;
                            }
                            default: {
                                printf("%s\n", "Unexpected game node in ActionSelected.");
                                asm("exit;");
                            }
                        }
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                break;
            }
            case 1: { // PlayerChanged
                static_array<US2,2l> v84 = v8.v.case1.v0;
                v115 = v11; v116 = v84; v117 = v13;
                break;
            }
            case 2: { // StartGame
                static_array<US2,2l> v16;
                US2 v17;
                v17 = US2_0();
                v16.v[0l] = v17;
                US2 v18;
                v18 = US2_1();
                v16.v[1l] = v18;
                static_array_list<US3,6l,long> v19;
                v19.length = 0;
                v19.length = 6l;
                long v20;
                v20 = v19.length;
                bool v21;
                v21 = 0l < v20;
                bool v22;
                v22 = v21 == false;
                if (v22){
                    assert("The set index needs to be in range for the static array list." && v21);
                } else {
                }
                US3 v23;
                v23 = US3_1();
                v19.v[0l] = v23;
                long v24;
                v24 = v19.length;
                bool v25;
                v25 = 1l < v24;
                bool v26;
                v26 = v25 == false;
                if (v26){
                    assert("The set index needs to be in range for the static array list." && v25);
                } else {
                }
                US3 v27;
                v27 = US3_1();
                v19.v[1l] = v27;
                long v28;
                v28 = v19.length;
                bool v29;
                v29 = 2l < v28;
                bool v30;
                v30 = v29 == false;
                if (v30){
                    assert("The set index needs to be in range for the static array list." && v29);
                } else {
                }
                US3 v31;
                v31 = US3_2();
                v19.v[2l] = v31;
                long v32;
                v32 = v19.length;
                bool v33;
                v33 = 3l < v32;
                bool v34;
                v34 = v33 == false;
                if (v34){
                    assert("The set index needs to be in range for the static array list." && v33);
                } else {
                }
                US3 v35;
                v35 = US3_2();
                v19.v[3l] = v35;
                long v36;
                v36 = v19.length;
                bool v37;
                v37 = 4l < v36;
                bool v38;
                v38 = v37 == false;
                if (v38){
                    assert("The set index needs to be in range for the static array list." && v37);
                } else {
                }
                US3 v39;
                v39 = US3_0();
                v19.v[4l] = v39;
                long v40;
                v40 = v19.length;
                bool v41;
                v41 = 5l < v40;
                bool v42;
                v42 = v41 == false;
                if (v42){
                    assert("The set index needs to be in range for the static array list." && v41);
                } else {
                }
                US3 v43;
                v43 = US3_0();
                v19.v[5l] = v43;
                unsigned long long v44;
                v44 = clock64();
                curandStatePhilox4_32_10_t v45;
                curand_init(v44,0ull,0ull,&v45);
                long v46;
                v46 = v19.length;
                long v47;
                v47 = v46 - 1l;
                long v48;
                v48 = 0l;
                while (while_method_1(v47, v48)){
                    long v50;
                    v50 = v19.length;
                    long v51;
                    v51 = v50 - v48;
                    unsigned long v52;
                    v52 = (unsigned long)v51;
                    unsigned long v53;
                    v53 = loop_22(v52, v45);
                    unsigned long v54;
                    v54 = (unsigned long)v48;
                    unsigned long v55;
                    v55 = v53 + v54;
                    long v56;
                    v56 = (long)v55;
                    bool v57;
                    v57 = 0l <= v48;
                    bool v60;
                    if (v57){
                        long v58;
                        v58 = v19.length;
                        bool v59;
                        v59 = v48 < v58;
                        v60 = v59;
                    } else {
                        v60 = false;
                    }
                    bool v61;
                    v61 = v60 == false;
                    if (v61){
                        assert("The read index needs to be in range for the static array list." && v60);
                    } else {
                    }
                    US3 v62;
                    v62 = v19.v[v48];
                    bool v63;
                    v63 = 0l <= v56;
                    bool v66;
                    if (v63){
                        long v64;
                        v64 = v19.length;
                        bool v65;
                        v65 = v56 < v64;
                        v66 = v65;
                    } else {
                        v66 = false;
                    }
                    bool v67;
                    v67 = v66 == false;
                    if (v67){
                        assert("The read index needs to be in range for the static array list." && v66);
                    } else {
                    }
                    US3 v68;
                    v68 = v19.v[v56];
                    bool v71;
                    if (v57){
                        long v69;
                        v69 = v19.length;
                        bool v70;
                        v70 = v48 < v69;
                        v71 = v70;
                    } else {
                        v71 = false;
                    }
                    bool v72;
                    v72 = v71 == false;
                    if (v72){
                        assert("The set index needs to be in range for the static array list." && v71);
                    } else {
                    }
                    v19.v[v48] = v68;
                    bool v75;
                    if (v63){
                        long v73;
                        v73 = v19.length;
                        bool v74;
                        v74 = v56 < v73;
                        v75 = v74;
                    } else {
                        v75 = false;
                    }
                    bool v76;
                    v76 = v75 == false;
                    if (v76){
                        assert("The set index needs to be in range for the static array list." && v75);
                    } else {
                    }
                    v19.v[v56] = v62;
                    v48 += 1l ;
                }
                static_array_list<US4,32l,long> v77;
                v77.length = 0;
                v14 = v19;
                v15 = v77;
                US5 v78;
                v78 = US5_0();
                US8 v79;
                v79 = US8_0();
                US6 v80;
                v80 = US6_1();
                Tuple6 tmp22 = play_loop_20(v78, v16, v79, v14, v15, v80);
                v115 = tmp22.v0; v116 = tmp22.v1; v117 = tmp22.v2;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        f_27(v0, v9, v10, v115, v116, v117);
        return f_44(v2, v10, v116, v117);
    } else {
        return ;
    }
}
"""
class static_array(list):
    def __init__(self, length):
        for _ in range(length):
            self.append(None)

class static_array_list(static_array):
    def __init__(self, length):
        super().__init__(length)
        self.length = 0
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
import random
import collections
class US1_0(NamedTuple): # Call
    tag = 0
class US1_1(NamedTuple): # Fold
    tag = 1
class US1_2(NamedTuple): # Raise
    tag = 2
US1 = Union[US1_0, US1_1, US1_2]
class US0_0(NamedTuple): # ActionSelected
    v0 : US1
    tag = 0
class US0_1(NamedTuple): # PlayerChanged
    v0 : static_array
    tag = 1
class US0_2(NamedTuple): # StartGame
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
class US2_0(NamedTuple): # Computer
    tag = 0
class US2_1(NamedTuple): # Human
    tag = 1
US2 = Union[US2_0, US2_1]
class US6_0(NamedTuple): # Jack
    tag = 0
class US6_1(NamedTuple): # King
    tag = 1
class US6_2(NamedTuple): # Queen
    tag = 2
US6 = Union[US6_0, US6_1, US6_2]
class US5_0(NamedTuple): # None
    tag = 0
class US5_1(NamedTuple): # Some
    v0 : US6
    tag = 1
US5 = Union[US5_0, US5_1]
class US4_0(NamedTuple): # ChanceCommunityCard
    v0 : US5
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 0
class US4_1(NamedTuple): # ChanceInit
    tag = 1
class US4_2(NamedTuple): # Round
    v0 : US5
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 2
class US4_3(NamedTuple): # RoundWithAction
    v0 : US5
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    v6 : US1
    tag = 3
class US4_4(NamedTuple): # TerminalCall
    v0 : US5
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 4
class US4_5(NamedTuple): # TerminalFold
    v0 : US5
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 5
US4 = Union[US4_0, US4_1, US4_2, US4_3, US4_4, US4_5]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : US4
    tag = 1
US3 = Union[US3_0, US3_1]
class US7_0(NamedTuple): # GameNotStarted
    tag = 0
class US7_1(NamedTuple): # GameOver
    v0 : US5
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 1
class US7_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : US5
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 2
US7 = Union[US7_0, US7_1, US7_2]
class US8_0(NamedTuple): # CommunityCardIs
    v0 : US6
    tag = 0
class US8_1(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 1
class US8_2(NamedTuple): # PlayerGotCard
    v0 : i32
    v1 : US6
    tag = 2
class US8_3(NamedTuple): # Showdown
    v0 : static_array
    v1 : i32
    v2 : i32
    tag = 3
US8 = Union[US8_0, US8_1, US8_2, US8_3]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = cp.empty(16,dtype=cp.uint8)
        v3 = cp.empty(1200,dtype=cp.uint8)
        v4 = cp.empty(1104,dtype=cp.uint8)
        v5 = method0(v0)
        v6, v7, v8, v9, v10 = method7(v1)
        method28(v2, v5)
        del v5
        method35(v3, v6, v7, v8, v9, v10)
        del v6, v7, v8, v9, v10
        v11 = 0
        v12 = raw_module.get_function(f"entry{v11}")
        del v11
        v12.max_dynamic_shared_size_bytes = 0 
        v12((1,),(512,),(v3, v2, v4),shared_mem=0)
        del v2, v12
        v13, v14, v15, v16, v17 = method49(v3)
        del v3
        v18, v19, v20 = method66(v4)
        del v4
        return method68(v13, v14, v15, v16, v17, v18, v19, v20)
    return inner
def Closure1():
    def inner() -> object:
        v0 = static_array(2)
        v1 = US2_0()
        v0[0] = v1
        del v1
        v2 = US2_1()
        v0[1] = v2
        del v2
        v3 = static_array_list(6)
        v3.length = 6
        v4 = v3.length
        v5 = 0 < v4
        del v4
        v6 = v5 == False
        if v6:
            v7 = "The set index needs to be in range for the static array list."
            assert v5, v7
            del v7
        else:
            pass
        del v5, v6
        v8 = US6_1()
        v3[0] = v8
        del v8
        v9 = v3.length
        v10 = 1 < v9
        del v9
        v11 = v10 == False
        if v11:
            v12 = "The set index needs to be in range for the static array list."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = US6_1()
        v3[1] = v13
        del v13
        v14 = v3.length
        v15 = 2 < v14
        del v14
        v16 = v15 == False
        if v16:
            v17 = "The set index needs to be in range for the static array list."
            assert v15, v17
            del v17
        else:
            pass
        del v15, v16
        v18 = US6_2()
        v3[2] = v18
        del v18
        v19 = v3.length
        v20 = 3 < v19
        del v19
        v21 = v20 == False
        if v21:
            v22 = "The set index needs to be in range for the static array list."
            assert v20, v22
            del v22
        else:
            pass
        del v20, v21
        v23 = US6_2()
        v3[3] = v23
        del v23
        v24 = v3.length
        v25 = 4 < v24
        del v24
        v26 = v25 == False
        if v26:
            v27 = "The set index needs to be in range for the static array list."
            assert v25, v27
            del v27
        else:
            pass
        del v25, v26
        v28 = US6_0()
        v3[4] = v28
        del v28
        v29 = v3.length
        v30 = 5 < v29
        del v29
        v31 = v30 == False
        if v31:
            v32 = "The set index needs to be in range for the static array list."
            assert v30, v32
            del v32
        else:
            pass
        del v30, v31
        v33 = US6_0()
        v3[5] = v33
        del v33
        v34 = v3.length
        v35 = v34 - 1
        del v34
        v36 = 0
        while method5(v35, v36):
            v38 = v3.length
            v39 = random.randrange(v36, v38)
            del v38
            v40 = 0 <= v36
            if v40:
                v41 = v3.length
                v42 = v36 < v41
                del v41
                v43 = v42
            else:
                v43 = False
            v44 = v43 == False
            if v44:
                v45 = "The read index needs to be in range for the static array list."
                assert v43, v45
                del v45
            else:
                pass
            del v43, v44
            v46 = v3[v36]
            v47 = 0 <= v39
            if v47:
                v48 = v3.length
                v49 = v39 < v48
                del v48
                v50 = v49
            else:
                v50 = False
            v51 = v50 == False
            if v51:
                v52 = "The read index needs to be in range for the static array list."
                assert v50, v52
                del v52
            else:
                pass
            del v50, v51
            v53 = v3[v39]
            if v40:
                v54 = v3.length
                v55 = v36 < v54
                del v54
                v56 = v55
            else:
                v56 = False
            del v40
            v57 = v56 == False
            if v57:
                v58 = "The set index needs to be in range for the static array list."
                assert v56, v58
                del v58
            else:
                pass
            del v56, v57
            v3[v36] = v53
            del v53
            if v47:
                v59 = v3.length
                v60 = v39 < v59
                del v59
                v61 = v60
            else:
                v61 = False
            del v47
            v62 = v61 == False
            if v62:
                v63 = "The set index needs to be in range for the static array list."
                assert v61, v63
                del v63
            else:
                pass
            del v61, v62
            v3[v39] = v46
            del v39, v46
            v36 += 1 
        del v35, v36
        v64 = static_array_list(32)
        v65 = US3_0()
        v66 = US7_0()
        return method95(v3, v64, v65, v0, v66)
    return inner
def method3(v0 : object) -> None:
    assert v0 == [], f'Expected an unit type. Got: {v0}'
    del v0
    return 
def method2(v0 : object) -> US1:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Call" == v1
    if v4:
        del v1, v4
        method3(v2)
        del v2
        return US1_0()
    else:
        del v4
        v7 = "Fold" == v1
        if v7:
            del v1, v7
            method3(v2)
            del v2
            return US1_1()
        else:
            del v7
            v10 = "Raise" == v1
            if v10:
                del v1, v10
                method3(v2)
                del v2
                return US1_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method5(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method6(v0 : object) -> US2:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Computer" == v1
    if v4:
        del v1, v4
        method3(v2)
        del v2
        return US2_0()
    else:
        del v4
        v7 = "Human" == v1
        if v7:
            del v1, v7
            method3(v2)
            del v2
            return US2_1()
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method4(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0) # type: ignore
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method5(v1, v6):
        v8 = v0[v6]
        v9 = method6(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v5[v6] = v9
        del v9
        v6 += 1 
    del v0, v1, v6
    return v5
def method1(v0 : object) -> US0:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "ActionSelected" == v1
    if v4:
        del v1, v4
        v5 = method2(v2)
        del v2
        return US0_0(v5)
    else:
        del v4
        v8 = "PlayerChanged" == v1
        if v8:
            del v1, v8
            v9 = method4(v2)
            del v2
            return US0_1(v9)
        else:
            del v8
            v12 = "StartGame" == v1
            if v12:
                del v1, v12
                method3(v2)
                del v2
                return US0_2()
            else:
                del v2, v12
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method0(v0 : object) -> US0:
    return method1(v0)
def method11(v0 : object) -> US6:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Jack" == v1
    if v4:
        del v1, v4
        method3(v2)
        del v2
        return US6_0()
    else:
        del v4
        v7 = "King" == v1
        if v7:
            del v1, v7
            method3(v2)
            del v2
            return US6_1()
        else:
            del v7
            v10 = "Queen" == v1
            if v10:
                del v1, v10
                method3(v2)
                del v2
                return US6_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method10(v0 : object) -> static_array_list:
    v1 = len(v0) # type: ignore
    assert (6 >= v1), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 6\nGot: {v1} '
    del v1
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v2 = len(v0) # type: ignore
    v3 = 6 >= v2
    v4 = v3 == False
    if v4:
        v5 = "The type level dimension has to equal the value passed at runtime into create."
        assert v3, v5
        del v5
    else:
        pass
    del v3, v4
    v6 = static_array_list(6)
    v6.length = v2
    v7 = 0
    while method5(v2, v7):
        v9 = v0[v7]
        v10 = method11(v9)
        del v9
        v11 = 0 <= v7
        if v11:
            v12 = v6.length
            v13 = v7 < v12
            del v12
            v14 = v13
        else:
            v14 = False
        del v11
        v15 = v14 == False
        if v15:
            v16 = "The set index needs to be in range for the static array list."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        v6[v7] = v10
        del v10
        v7 += 1 
    del v0, v2, v7
    return v6
def method15(v0 : object) -> i32:
    assert isinstance(v0,i32), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method14(v0 : object) -> Tuple[i32, US1]:
    v1 = v0[0] # type: ignore
    v2 = method15(v1)
    del v1
    v3 = v0[1] # type: ignore
    del v0
    v4 = method2(v3)
    del v3
    return v2, v4
def method16(v0 : object) -> Tuple[i32, US6]:
    v1 = v0[0] # type: ignore
    v2 = method15(v1)
    del v1
    v3 = v0[1] # type: ignore
    del v0
    v4 = method11(v3)
    del v3
    return v2, v4
def method18(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0) # type: ignore
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method5(v1, v6):
        v8 = v0[v6]
        v9 = method11(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v5[v6] = v9
        del v9
        v6 += 1 
    del v0, v1, v6
    return v5
def method17(v0 : object) -> Tuple[static_array, i32, i32]:
    v1 = v0["cards_shown"] # type: ignore
    v2 = method18(v1)
    del v1
    v3 = v0["chips_won"] # type: ignore
    v4 = method15(v3)
    del v3
    v5 = v0["winner_id"] # type: ignore
    del v0
    v6 = method15(v5)
    del v5
    return v2, v4, v6
def method13(v0 : object) -> US8:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "CommunityCardIs" == v1
    if v4:
        del v1, v4
        v5 = method11(v2)
        del v2
        return US8_0(v5)
    else:
        del v4
        v8 = "PlayerAction" == v1
        if v8:
            del v1, v8
            v9, v10 = method14(v2)
            del v2
            return US8_1(v9, v10)
        else:
            del v8
            v13 = "PlayerGotCard" == v1
            if v13:
                del v1, v13
                v14, v15 = method16(v2)
                del v2
                return US8_2(v14, v15)
            else:
                del v13
                v18 = "Showdown" == v1
                if v18:
                    del v1, v18
                    v19, v20, v21 = method17(v2)
                    del v2
                    return US8_3(v19, v20, v21)
                else:
                    del v2, v18
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method12(v0 : object) -> static_array_list:
    v1 = len(v0) # type: ignore
    assert (32 >= v1), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 32\nGot: {v1} '
    del v1
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v2 = len(v0) # type: ignore
    v3 = 32 >= v2
    v4 = v3 == False
    if v4:
        v5 = "The type level dimension has to equal the value passed at runtime into create."
        assert v3, v5
        del v5
    else:
        pass
    del v3, v4
    v6 = static_array_list(32)
    v6.length = v2
    v7 = 0
    while method5(v2, v7):
        v9 = v0[v7]
        v10 = method13(v9)
        del v9
        v11 = 0 <= v7
        if v11:
            v12 = v6.length
            v13 = v7 < v12
            del v12
            v14 = v13
        else:
            v14 = False
        del v11
        v15 = v14 == False
        if v15:
            v16 = "The set index needs to be in range for the static array list."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        v6[v7] = v10
        del v10
        v7 += 1 
    del v0, v2, v7
    return v6
def method9(v0 : object) -> Tuple[static_array_list, static_array_list]:
    v1 = v0["deck"] # type: ignore
    v2 = method10(v1)
    del v1
    v3 = v0["messages"] # type: ignore
    del v0
    v4 = method12(v3)
    del v3
    return v2, v4
def method23(v0 : object) -> US5:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        method3(v2)
        del v2
        return US5_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method11(v2)
            del v2
            return US5_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method24(v0 : object) -> bool:
    assert isinstance(v0,bool), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method25(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0) # type: ignore
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method5(v1, v6):
        v8 = v0[v6]
        v9 = method15(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v5[v6] = v9
        del v9
        v6 += 1 
    del v0, v1, v6
    return v5
def method22(v0 : object) -> Tuple[US5, bool, static_array, i32, static_array, i32]:
    v1 = v0["community_card"] # type: ignore
    v2 = method23(v1)
    del v1
    v3 = v0["is_button_s_first_move"] # type: ignore
    v4 = method24(v3)
    del v3
    v5 = v0["pl_card"] # type: ignore
    v6 = method18(v5)
    del v5
    v7 = v0["player_turn"] # type: ignore
    v8 = method15(v7)
    del v7
    v9 = v0["pot"] # type: ignore
    v10 = method25(v9)
    del v9
    v11 = v0["raises_left"] # type: ignore
    del v0
    v12 = method15(v11)
    del v11
    return v2, v4, v6, v8, v10, v12
def method26(v0 : object) -> Tuple[US5, bool, static_array, i32, static_array, i32, US1]:
    v1 = v0[0] # type: ignore
    v2, v3, v4, v5, v6, v7 = method22(v1)
    del v1
    v8 = v0[1] # type: ignore
    del v0
    v9 = method2(v8)
    del v8
    return v2, v3, v4, v5, v6, v7, v9
def method21(v0 : object) -> US4:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "ChanceCommunityCard" == v1
    if v4:
        del v1, v4
        v5, v6, v7, v8, v9, v10 = method22(v2)
        del v2
        return US4_0(v5, v6, v7, v8, v9, v10)
    else:
        del v4
        v13 = "ChanceInit" == v1
        if v13:
            del v1, v13
            method3(v2)
            del v2
            return US4_1()
        else:
            del v13
            v16 = "Round" == v1
            if v16:
                del v1, v16
                v17, v18, v19, v20, v21, v22 = method22(v2)
                del v2
                return US4_2(v17, v18, v19, v20, v21, v22)
            else:
                del v16
                v25 = "RoundWithAction" == v1
                if v25:
                    del v1, v25
                    v26, v27, v28, v29, v30, v31, v32 = method26(v2)
                    del v2
                    return US4_3(v26, v27, v28, v29, v30, v31, v32)
                else:
                    del v25
                    v35 = "TerminalCall" == v1
                    if v35:
                        del v1, v35
                        v36, v37, v38, v39, v40, v41 = method22(v2)
                        del v2
                        return US4_4(v36, v37, v38, v39, v40, v41)
                    else:
                        del v35
                        v44 = "TerminalFold" == v1
                        if v44:
                            del v1, v44
                            v45, v46, v47, v48, v49, v50 = method22(v2)
                            del v2
                            return US4_5(v45, v46, v47, v48, v49, v50)
                        else:
                            del v2, v44
                            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                            del v1
                            raise Exception("Error")
def method20(v0 : object) -> US3:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        method3(v2)
        del v2
        return US3_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method21(v2)
            del v2
            return US3_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method27(v0 : object) -> US7:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        method3(v2)
        del v2
        return US7_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8, v9, v10, v11, v12, v13 = method22(v2)
            del v2
            return US7_1(v8, v9, v10, v11, v12, v13)
        else:
            del v7
            v16 = "WaitingForActionFromPlayerId" == v1
            if v16:
                del v1, v16
                v17, v18, v19, v20, v21, v22 = method22(v2)
                del v2
                return US7_2(v17, v18, v19, v20, v21, v22)
            else:
                del v2, v16
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method19(v0 : object) -> Tuple[US3, static_array, US7]:
    v1 = v0["game"] # type: ignore
    v2 = method20(v1)
    del v1
    v3 = v0["pl_type"] # type: ignore
    v4 = method4(v3)
    del v3
    v5 = v0["ui_game_state"] # type: ignore
    del v0
    v6 = method27(v5)
    del v5
    return v2, v4, v6
def method8(v0 : object) -> Tuple[static_array_list, static_array_list, US3, static_array, US7]:
    v1 = v0["large"] # type: ignore
    v2, v3 = method9(v1)
    del v1
    v4 = v0["small"] # type: ignore
    del v0
    v5, v6, v7 = method19(v4)
    del v4
    return v2, v3, v5, v6, v7
def method7(v0 : object) -> Tuple[static_array_list, static_array_list, US3, static_array, US7]:
    return method8(v0)
def method29(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[0:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method31(v0 : cp.ndarray) -> None:
    del v0
    return 
def method30(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method29(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US1_0(): # Call
            del v1
            return method31(v3)
        case US1_1(): # Fold
            del v1
            return method31(v3)
        case US1_2(): # Raise
            del v1
            return method31(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method33(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method34(v0 : cp.ndarray, v1 : US2) -> None:
    v2 = v1.tag
    method29(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US2_0(): # Computer
            del v1
            return method31(v3)
        case US2_1(): # Human
            del v1
            return method31(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method32(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method33(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7 = 0 <= v2
        if v7:
            v8 = v2 < 2
            v9 = v8
        else:
            v9 = False
        del v7
        v10 = v9 == False
        if v10:
            v11 = "The read index needs to be in range for the static array."
            assert v9, v11
            del v11
        else:
            pass
        del v9, v10
        v12 = v1[v2]
        method34(v6, v12)
        del v6, v12
        v2 += 1 
    del v0, v1, v2
    return 
def method28(v0 : cp.ndarray, v1 : US0) -> None:
    v2 = v1.tag
    method29(v0, v2)
    del v2
    v3 = v0[8:].view(cp.uint8)
    del v0
    match v1:
        case US0_0(v4): # ActionSelected
            del v1
            return method30(v3, v4)
        case US0_1(v5): # PlayerChanged
            del v1
            return method32(v3, v5)
        case US0_2(): # StartGame
            del v1
            return method31(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method36(v0 : cp.ndarray, v1 : US6) -> None:
    v2 = v1.tag
    method29(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US6_0(): # Jack
            del v1
            return method31(v3)
        case US6_1(): # King
            del v1
            return method31(v3)
        case US6_2(): # Queen
            del v1
            return method31(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method37(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[28:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method40(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[4:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method39(v0 : cp.ndarray, v1 : i32, v2 : US1) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method40(v0, v4)
    del v4
    v5 = v0[8:].view(cp.uint8)
    del v0
    match v2:
        case US1_0(): # Call
            del v2
            return method31(v5)
        case US1_1(): # Fold
            del v2
            return method31(v5)
        case US1_2(): # Raise
            del v2
            return method31(v5)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method41(v0 : cp.ndarray, v1 : i32, v2 : US6) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method40(v0, v4)
    del v4
    v5 = v0[8:].view(cp.uint8)
    del v0
    match v2:
        case US6_0(): # Jack
            del v2
            return method31(v5)
        case US6_1(): # King
            del v2
            return method31(v5)
        case US6_2(): # Queen
            del v2
            return method31(v5)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method42(v0 : cp.ndarray, v1 : static_array, v2 : i32, v3 : i32) -> None:
    v4 = 0
    while method33(v4):
        v6 = u64(v4)
        v7 = v6 * 4
        del v6
        v8 = v0[v7:].view(cp.uint8)
        del v7
        v9 = 0 <= v4
        if v9:
            v10 = v4 < 2
            v11 = v10
        else:
            v11 = False
        del v9
        v12 = v11 == False
        if v12:
            v13 = "The read index needs to be in range for the static array."
            assert v11, v13
            del v13
        else:
            pass
        del v11, v12
        v14 = v1[v4]
        method36(v8, v14)
        del v8, v14
        v4 += 1 
    del v1, v4
    v15 = v0[8:].view(cp.int32)
    v15[0] = v2
    del v2, v15
    v16 = v0[12:].view(cp.int32)
    del v0
    v16[0] = v3
    del v3, v16
    return 
def method38(v0 : cp.ndarray, v1 : US8) -> None:
    v2 = v1.tag
    method29(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US8_0(v4): # CommunityCardIs
            del v1
            return method36(v3, v4)
        case US8_1(v5, v6): # PlayerAction
            del v1
            return method39(v3, v5, v6)
        case US8_2(v7, v8): # PlayerGotCard
            del v1
            return method41(v3, v7, v8)
        case US8_3(v9, v10, v11): # Showdown
            del v1
            return method42(v3, v9, v10, v11)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method43(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[1056:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method45(v0 : cp.ndarray, v1 : US5, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : i32) -> None:
    v7 = v1.tag
    method29(v0, v7)
    del v7
    v8 = v0[4:].view(cp.uint8)
    match v1:
        case US5_0(): # None
            method31(v8)
        case US5_1(v9): # Some
            method36(v8, v9)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1, v8
    v10 = v0[8:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method33(v11):
        v13 = u64(v11)
        v14 = v13 * 4
        del v13
        v15 = 12 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method36(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[20:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method33(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 24 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method29(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = v0[32:].view(cp.int32)
    del v0
    v36[0] = v6
    del v6, v36
    return 
def method47(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[36:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method46(v0 : cp.ndarray, v1 : US5, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : i32, v7 : US1) -> None:
    v8 = v1.tag
    method29(v0, v8)
    del v8
    v9 = v0[4:].view(cp.uint8)
    match v1:
        case US5_0(): # None
            method31(v9)
        case US5_1(v10): # Some
            method36(v9, v10)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1, v9
    v11 = v0[8:].view(cp.bool_)
    v11[0] = v2
    del v2, v11
    v12 = 0
    while method33(v12):
        v14 = u64(v12)
        v15 = v14 * 4
        del v14
        v16 = 12 + v15
        del v15
        v17 = v0[v16:].view(cp.uint8)
        del v16
        v18 = 0 <= v12
        if v18:
            v19 = v12 < 2
            v20 = v19
        else:
            v20 = False
        del v18
        v21 = v20 == False
        if v21:
            v22 = "The read index needs to be in range for the static array."
            assert v20, v22
            del v22
        else:
            pass
        del v20, v21
        v23 = v3[v12]
        method36(v17, v23)
        del v17, v23
        v12 += 1 
    del v3, v12
    v24 = v0[20:].view(cp.int32)
    v24[0] = v4
    del v4, v24
    v25 = 0
    while method33(v25):
        v27 = u64(v25)
        v28 = v27 * 4
        del v27
        v29 = 24 + v28
        del v28
        v30 = v0[v29:].view(cp.uint8)
        del v29
        v31 = 0 <= v25
        if v31:
            v32 = v25 < 2
            v33 = v32
        else:
            v33 = False
        del v31
        v34 = v33 == False
        if v34:
            v35 = "The read index needs to be in range for the static array."
            assert v33, v35
            del v35
        else:
            pass
        del v33, v34
        v36 = v5[v25]
        method29(v30, v36)
        del v30, v36
        v25 += 1 
    del v5, v25
    v37 = v0[32:].view(cp.int32)
    v37[0] = v6
    del v6, v37
    v38 = v7.tag
    method47(v0, v38)
    del v38
    v39 = v0[40:].view(cp.uint8)
    del v0
    match v7:
        case US1_0(): # Call
            del v7
            return method31(v39)
        case US1_1(): # Fold
            del v7
            return method31(v39)
        case US1_2(): # Raise
            del v7
            return method31(v39)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method44(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method29(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US4_0(v4, v5, v6, v7, v8, v9): # ChanceCommunityCard
            del v1
            return method45(v3, v4, v5, v6, v7, v8, v9)
        case US4_1(): # ChanceInit
            del v1
            return method31(v3)
        case US4_2(v10, v11, v12, v13, v14, v15): # Round
            del v1
            return method45(v3, v10, v11, v12, v13, v14, v15)
        case US4_3(v16, v17, v18, v19, v20, v21, v22): # RoundWithAction
            del v1
            return method46(v3, v16, v17, v18, v19, v20, v21, v22)
        case US4_4(v23, v24, v25, v26, v27, v28): # TerminalCall
            del v1
            return method45(v3, v23, v24, v25, v26, v27, v28)
        case US4_5(v29, v30, v31, v32, v33, v34): # TerminalFold
            del v1
            return method45(v3, v29, v30, v31, v32, v33, v34)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method48(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[1144:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method35(v0 : cp.ndarray, v1 : static_array_list, v2 : static_array_list, v3 : US3, v4 : static_array, v5 : US7) -> None:
    v6 = v1.length
    method29(v0, v6)
    del v6
    v7 = v1.length
    v8 = 0
    while method5(v7, v8):
        v10 = u64(v8)
        v11 = v10 * 4
        del v10
        v12 = 4 + v11
        del v11
        v13 = v0[v12:].view(cp.uint8)
        del v12
        v14 = 0 <= v8
        if v14:
            v15 = v1.length
            v16 = v8 < v15
            del v15
            v17 = v16
        else:
            v17 = False
        del v14
        v18 = v17 == False
        if v18:
            v19 = "The read index needs to be in range for the static array list."
            assert v17, v19
            del v19
        else:
            pass
        del v17, v18
        v20 = v1[v8]
        method36(v13, v20)
        del v13, v20
        v8 += 1 
    del v1, v7, v8
    v21 = v2.length
    method37(v0, v21)
    del v21
    v22 = v2.length
    v23 = 0
    while method5(v22, v23):
        v25 = u64(v23)
        v26 = v25 * 32
        del v25
        v27 = 32 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v2.length
            v31 = v23 < v30
            del v30
            v32 = v31
        else:
            v32 = False
        del v29
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array list."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v2[v23]
        method38(v28, v35)
        del v28, v35
        v23 += 1 
    del v2, v22, v23
    v36 = v3.tag
    method43(v0, v36)
    del v36
    v37 = v0[1072:].view(cp.uint8)
    match v3:
        case US3_0(): # None
            method31(v37)
        case US3_1(v38): # Some
            method44(v37, v38)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3, v37
    v39 = 0
    while method33(v39):
        v41 = u64(v39)
        v42 = v41 * 4
        del v41
        v43 = 1136 + v42
        del v42
        v44 = v0[v43:].view(cp.uint8)
        del v43
        v45 = 0 <= v39
        if v45:
            v46 = v39 < 2
            v47 = v46
        else:
            v47 = False
        del v45
        v48 = v47 == False
        if v48:
            v49 = "The read index needs to be in range for the static array."
            assert v47, v49
            del v49
        else:
            pass
        del v47, v48
        v50 = v4[v39]
        method34(v44, v50)
        del v44, v50
        v39 += 1 
    del v4, v39
    v51 = v5.tag
    method48(v0, v51)
    del v51
    v52 = v0[1152:].view(cp.uint8)
    del v0
    match v5:
        case US7_0(): # GameNotStarted
            del v5
            return method31(v52)
        case US7_1(v53, v54, v55, v56, v57, v58): # GameOver
            del v5
            return method45(v52, v53, v54, v55, v56, v57, v58)
        case US7_2(v59, v60, v61, v62, v63, v64): # WaitingForActionFromPlayerId
            del v5
            return method45(v52, v59, v60, v61, v62, v63, v64)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method50(v0 : cp.ndarray) -> i32:
    v1 = v0[0:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method52(v0 : cp.ndarray) -> None:
    del v0
    return 
def method51(v0 : cp.ndarray) -> US6:
    v1 = method50(v0)
    v2 = v0[4:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        method52(v2)
        del v2
        return US6_0()
    elif v1 == 1:
        del v1
        method52(v2)
        del v2
        return US6_1()
    elif v1 == 2:
        del v1
        method52(v2)
        del v2
        return US6_2()
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method53(v0 : cp.ndarray) -> i32:
    v1 = v0[28:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method56(v0 : cp.ndarray) -> i32:
    v1 = v0[4:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method55(v0 : cp.ndarray) -> Tuple[i32, US1]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = method56(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    if v3 == 0:
        method52(v4)
        v9 = US1_0()
    elif v3 == 1:
        method52(v4)
        v9 = US1_1()
    elif v3 == 2:
        method52(v4)
        v9 = US1_2()
    else:
        raise Exception("Invalid tag.")
    del v3, v4
    return v2, v9
def method57(v0 : cp.ndarray) -> Tuple[i32, US6]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = method56(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    if v3 == 0:
        method52(v4)
        v9 = US6_0()
    elif v3 == 1:
        method52(v4)
        v9 = US6_1()
    elif v3 == 2:
        method52(v4)
        v9 = US6_2()
    else:
        raise Exception("Invalid tag.")
    del v3, v4
    return v2, v9
def method58(v0 : cp.ndarray) -> Tuple[static_array, i32, i32]:
    v1 = static_array(2)
    v2 = 0
    while method33(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7 = method51(v6)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v1[v2] = v7
        del v7
        v2 += 1 
    del v2
    v13 = v0[8:].view(cp.int32)
    v14 = v13[0].item()
    del v13
    v15 = v0[12:].view(cp.int32)
    del v0
    v16 = v15[0].item()
    del v15
    return v1, v14, v16
def method54(v0 : cp.ndarray) -> US8:
    v1 = method50(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4 = method51(v2)
        del v2
        return US8_0(v4)
    elif v1 == 1:
        del v1
        v6, v7 = method55(v2)
        del v2
        return US8_1(v6, v7)
    elif v1 == 2:
        del v1
        v9, v10 = method57(v2)
        del v2
        return US8_2(v9, v10)
    elif v1 == 3:
        del v1
        v12, v13, v14 = method58(v2)
        del v2
        return US8_3(v12, v13, v14)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method59(v0 : cp.ndarray) -> i32:
    v1 = v0[1056:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method61(v0 : cp.ndarray) -> Tuple[US5, bool, static_array, i32, static_array, i32]:
    v1 = method50(v0)
    v2 = v0[4:].view(cp.uint8)
    if v1 == 0:
        method52(v2)
        v7 = US5_0()
    elif v1 == 1:
        v5 = method51(v2)
        v7 = US5_1(v5)
    else:
        raise Exception("Invalid tag.")
    del v1, v2
    v8 = v0[8:].view(cp.bool_)
    v9 = v8[0].item()
    del v8
    v10 = static_array(2)
    v11 = 0
    while method33(v11):
        v13 = u64(v11)
        v14 = v13 * 4
        del v13
        v15 = 12 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = method51(v16)
        del v16
        v18 = 0 <= v11
        if v18:
            v19 = v11 < 2
            v20 = v19
        else:
            v20 = False
        del v18
        v21 = v20 == False
        if v21:
            v22 = "The read index needs to be in range for the static array."
            assert v20, v22
            del v22
        else:
            pass
        del v20, v21
        v10[v11] = v17
        del v17
        v11 += 1 
    del v11
    v23 = v0[20:].view(cp.int32)
    v24 = v23[0].item()
    del v23
    v25 = static_array(2)
    v26 = 0
    while method33(v26):
        v28 = u64(v26)
        v29 = v28 * 4
        del v28
        v30 = 24 + v29
        del v29
        v31 = v0[v30:].view(cp.uint8)
        del v30
        v32 = method50(v31)
        del v31
        v33 = 0 <= v26
        if v33:
            v34 = v26 < 2
            v35 = v34
        else:
            v35 = False
        del v33
        v36 = v35 == False
        if v36:
            v37 = "The read index needs to be in range for the static array."
            assert v35, v37
            del v37
        else:
            pass
        del v35, v36
        v25[v26] = v32
        del v32
        v26 += 1 
    del v26
    v38 = v0[32:].view(cp.int32)
    del v0
    v39 = v38[0].item()
    del v38
    return v7, v9, v10, v24, v25, v39
def method63(v0 : cp.ndarray) -> i32:
    v1 = v0[36:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method62(v0 : cp.ndarray) -> Tuple[US5, bool, static_array, i32, static_array, i32, US1]:
    v1 = method50(v0)
    v2 = v0[4:].view(cp.uint8)
    if v1 == 0:
        method52(v2)
        v7 = US5_0()
    elif v1 == 1:
        v5 = method51(v2)
        v7 = US5_1(v5)
    else:
        raise Exception("Invalid tag.")
    del v1, v2
    v8 = v0[8:].view(cp.bool_)
    v9 = v8[0].item()
    del v8
    v10 = static_array(2)
    v11 = 0
    while method33(v11):
        v13 = u64(v11)
        v14 = v13 * 4
        del v13
        v15 = 12 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = method51(v16)
        del v16
        v18 = 0 <= v11
        if v18:
            v19 = v11 < 2
            v20 = v19
        else:
            v20 = False
        del v18
        v21 = v20 == False
        if v21:
            v22 = "The read index needs to be in range for the static array."
            assert v20, v22
            del v22
        else:
            pass
        del v20, v21
        v10[v11] = v17
        del v17
        v11 += 1 
    del v11
    v23 = v0[20:].view(cp.int32)
    v24 = v23[0].item()
    del v23
    v25 = static_array(2)
    v26 = 0
    while method33(v26):
        v28 = u64(v26)
        v29 = v28 * 4
        del v28
        v30 = 24 + v29
        del v29
        v31 = v0[v30:].view(cp.uint8)
        del v30
        v32 = method50(v31)
        del v31
        v33 = 0 <= v26
        if v33:
            v34 = v26 < 2
            v35 = v34
        else:
            v35 = False
        del v33
        v36 = v35 == False
        if v36:
            v37 = "The read index needs to be in range for the static array."
            assert v35, v37
            del v37
        else:
            pass
        del v35, v36
        v25[v26] = v32
        del v32
        v26 += 1 
    del v26
    v38 = v0[32:].view(cp.int32)
    v39 = v38[0].item()
    del v38
    v40 = method63(v0)
    v41 = v0[40:].view(cp.uint8)
    del v0
    if v40 == 0:
        method52(v41)
        v46 = US1_0()
    elif v40 == 1:
        method52(v41)
        v46 = US1_1()
    elif v40 == 2:
        method52(v41)
        v46 = US1_2()
    else:
        raise Exception("Invalid tag.")
    del v40, v41
    return v7, v9, v10, v24, v25, v39, v46
def method60(v0 : cp.ndarray) -> US4:
    v1 = method50(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4, v5, v6, v7, v8, v9 = method61(v2)
        del v2
        return US4_0(v4, v5, v6, v7, v8, v9)
    elif v1 == 1:
        del v1
        method52(v2)
        del v2
        return US4_1()
    elif v1 == 2:
        del v1
        v12, v13, v14, v15, v16, v17 = method61(v2)
        del v2
        return US4_2(v12, v13, v14, v15, v16, v17)
    elif v1 == 3:
        del v1
        v19, v20, v21, v22, v23, v24, v25 = method62(v2)
        del v2
        return US4_3(v19, v20, v21, v22, v23, v24, v25)
    elif v1 == 4:
        del v1
        v27, v28, v29, v30, v31, v32 = method61(v2)
        del v2
        return US4_4(v27, v28, v29, v30, v31, v32)
    elif v1 == 5:
        del v1
        v34, v35, v36, v37, v38, v39 = method61(v2)
        del v2
        return US4_5(v34, v35, v36, v37, v38, v39)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method64(v0 : cp.ndarray) -> US2:
    v1 = method50(v0)
    v2 = v0[4:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        method52(v2)
        del v2
        return US2_0()
    elif v1 == 1:
        del v1
        method52(v2)
        del v2
        return US2_1()
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method65(v0 : cp.ndarray) -> i32:
    v1 = v0[1144:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method49(v0 : cp.ndarray) -> Tuple[static_array_list, static_array_list, US3, static_array, US7]:
    v1 = static_array_list(6)
    v2 = method50(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method5(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 4
        del v6
        v8 = 4 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method51(v9)
        del v9
        v11 = 0 <= v4
        if v11:
            v12 = v1.length
            v13 = v4 < v12
            del v12
            v14 = v13
        else:
            v14 = False
        del v11
        v15 = v14 == False
        if v15:
            v16 = "The set index needs to be in range for the static array list."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        v1[v4] = v10
        del v10
        v4 += 1 
    del v3, v4
    v17 = static_array_list(32)
    v18 = method53(v0)
    v17.length = v18
    del v18
    v19 = v17.length
    v20 = 0
    while method5(v19, v20):
        v22 = u64(v20)
        v23 = v22 * 32
        del v22
        v24 = 32 + v23
        del v23
        v25 = v0[v24:].view(cp.uint8)
        del v24
        v26 = method54(v25)
        del v25
        v27 = 0 <= v20
        if v27:
            v28 = v17.length
            v29 = v20 < v28
            del v28
            v30 = v29
        else:
            v30 = False
        del v27
        v31 = v30 == False
        if v31:
            v32 = "The set index needs to be in range for the static array list."
            assert v30, v32
            del v32
        else:
            pass
        del v30, v31
        v17[v20] = v26
        del v26
        v20 += 1 
    del v19, v20
    v33 = method59(v0)
    v34 = v0[1072:].view(cp.uint8)
    if v33 == 0:
        method52(v34)
        v39 = US3_0()
    elif v33 == 1:
        v37 = method60(v34)
        v39 = US3_1(v37)
    else:
        raise Exception("Invalid tag.")
    del v33, v34
    v40 = static_array(2)
    v41 = 0
    while method33(v41):
        v43 = u64(v41)
        v44 = v43 * 4
        del v43
        v45 = 1136 + v44
        del v44
        v46 = v0[v45:].view(cp.uint8)
        del v45
        v47 = method64(v46)
        del v46
        v48 = 0 <= v41
        if v48:
            v49 = v41 < 2
            v50 = v49
        else:
            v50 = False
        del v48
        v51 = v50 == False
        if v51:
            v52 = "The read index needs to be in range for the static array."
            assert v50, v52
            del v52
        else:
            pass
        del v50, v51
        v40[v41] = v47
        del v47
        v41 += 1 
    del v41
    v53 = method65(v0)
    v54 = v0[1152:].view(cp.uint8)
    del v0
    if v53 == 0:
        method52(v54)
        v71 = US7_0()
    elif v53 == 1:
        v57, v58, v59, v60, v61, v62 = method61(v54)
        v71 = US7_1(v57, v58, v59, v60, v61, v62)
    elif v53 == 2:
        v64, v65, v66, v67, v68, v69 = method61(v54)
        v71 = US7_2(v64, v65, v66, v67, v68, v69)
    else:
        raise Exception("Invalid tag.")
    del v53, v54
    return v1, v17, v39, v40, v71
def method67(v0 : cp.ndarray) -> i32:
    v1 = v0[1048:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method66(v0 : cp.ndarray) -> Tuple[static_array_list, static_array, US7]:
    v1 = static_array_list(32)
    v2 = method50(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method5(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 32
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method54(v9)
        del v9
        v11 = 0 <= v4
        if v11:
            v12 = v1.length
            v13 = v4 < v12
            del v12
            v14 = v13
        else:
            v14 = False
        del v11
        v15 = v14 == False
        if v15:
            v16 = "The set index needs to be in range for the static array list."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        v1[v4] = v10
        del v10
        v4 += 1 
    del v3, v4
    v17 = static_array(2)
    v18 = 0
    while method33(v18):
        v20 = u64(v18)
        v21 = v20 * 4
        del v20
        v22 = 1040 + v21
        del v21
        v23 = v0[v22:].view(cp.uint8)
        del v22
        v24 = method64(v23)
        del v23
        v25 = 0 <= v18
        if v25:
            v26 = v18 < 2
            v27 = v26
        else:
            v27 = False
        del v25
        v28 = v27 == False
        if v28:
            v29 = "The read index needs to be in range for the static array."
            assert v27, v29
            del v29
        else:
            pass
        del v27, v28
        v17[v18] = v24
        del v24
        v18 += 1 
    del v18
    v30 = method67(v0)
    v31 = v0[1056:].view(cp.uint8)
    del v0
    if v30 == 0:
        method52(v31)
        v48 = US7_0()
    elif v30 == 1:
        v34, v35, v36, v37, v38, v39 = method61(v31)
        v48 = US7_1(v34, v35, v36, v37, v38, v39)
    elif v30 == 2:
        v41, v42, v43, v44, v45, v46 = method61(v31)
        v48 = US7_2(v41, v42, v43, v44, v45, v46)
    else:
        raise Exception("Invalid tag.")
    del v30, v31
    return v1, v17, v48
def method74() -> object:
    v0 = []
    return v0
def method73(v0 : US6) -> object:
    match v0:
        case US6_0(): # Jack
            del v0
            v1 = method74()
            v2 = "Jack"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(): # King
            del v0
            v4 = method74()
            v5 = "King"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US6_2(): # Queen
            del v0
            v7 = method74()
            v8 = "Queen"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method72(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method5(v2, v3):
        v5 = 0 <= v3
        if v5:
            v6 = v0.length
            v7 = v3 < v6
            del v6
            v8 = v7
        else:
            v8 = False
        del v5
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array list."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v0[v3]
        v12 = method73(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method78(v0 : i32) -> object:
    v1 = v0
    del v0
    return v1
def method79(v0 : US1) -> object:
    match v0:
        case US1_0(): # Call
            del v0
            v1 = method74()
            v2 = "Call"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # Fold
            del v0
            v4 = method74()
            v5 = "Fold"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(): # Raise
            del v0
            v7 = method74()
            v8 = "Raise"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method77(v0 : i32, v1 : US1) -> object:
    v2 = []
    v3 = method78(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method79(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method80(v0 : i32, v1 : US6) -> object:
    v2 = []
    v3 = method78(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method73(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method82(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method33(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = method73(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method81(v0 : static_array, v1 : i32, v2 : i32) -> object:
    v3 = method82(v0)
    del v0
    v4 = method78(v1)
    del v1
    v5 = method78(v2)
    del v2
    v6 = {'cards_shown': v3, 'chips_won': v4, 'winner_id': v5}
    del v3, v4, v5
    return v6
def method76(v0 : US8) -> object:
    match v0:
        case US8_0(v1): # CommunityCardIs
            del v0
            v2 = method73(v1)
            del v1
            v3 = "CommunityCardIs"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US8_1(v5, v6): # PlayerAction
            del v0
            v7 = method77(v5, v6)
            del v5, v6
            v8 = "PlayerAction"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US8_2(v10, v11): # PlayerGotCard
            del v0
            v12 = method80(v10, v11)
            del v10, v11
            v13 = "PlayerGotCard"
            v14 = [v13,v12]
            del v12, v13
            return v14
        case US8_3(v15, v16, v17): # Showdown
            del v0
            v18 = method81(v15, v16, v17)
            del v15, v16, v17
            v19 = "Showdown"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method75(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method5(v2, v3):
        v5 = 0 <= v3
        if v5:
            v6 = v0.length
            v7 = v3 < v6
            del v6
            v8 = v7
        else:
            v8 = False
        del v5
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array list."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v0[v3]
        v12 = method76(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method71(v0 : static_array_list, v1 : static_array_list) -> object:
    v2 = method72(v0)
    del v0
    v3 = method75(v1)
    del v1
    v4 = {'deck': v2, 'messages': v3}
    del v2, v3
    return v4
def method87(v0 : US5) -> object:
    match v0:
        case US5_0(): # None
            del v0
            v1 = method74()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US5_1(v4): # Some
            del v0
            v5 = method73(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method88(v0 : bool) -> object:
    v1 = v0
    del v0
    return v1
def method89(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method33(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = method78(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method86(v0 : US5, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : i32) -> object:
    v6 = method87(v0)
    del v0
    v7 = method88(v1)
    del v1
    v8 = method82(v2)
    del v2
    v9 = method78(v3)
    del v3
    v10 = method89(v4)
    del v4
    v11 = method78(v5)
    del v5
    v12 = {'community_card': v6, 'is_button_s_first_move': v7, 'pl_card': v8, 'player_turn': v9, 'pot': v10, 'raises_left': v11}
    del v6, v7, v8, v9, v10, v11
    return v12
def method90(v0 : US5, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : i32, v6 : US1) -> object:
    v7 = []
    v8 = method86(v0, v1, v2, v3, v4, v5)
    del v0, v1, v2, v3, v4, v5
    v7.append(v8)
    del v8
    v9 = method79(v6)
    del v6
    v7.append(v9)
    del v9
    v10 = v7
    del v7
    return v10
def method85(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
            del v0
            v7 = method86(v1, v2, v3, v4, v5, v6)
            del v1, v2, v3, v4, v5, v6
            v8 = "ChanceCommunityCard"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US4_1(): # ChanceInit
            del v0
            v10 = method74()
            v11 = "ChanceInit"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US4_2(v13, v14, v15, v16, v17, v18): # Round
            del v0
            v19 = method86(v13, v14, v15, v16, v17, v18)
            del v13, v14, v15, v16, v17, v18
            v20 = "Round"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case US4_3(v22, v23, v24, v25, v26, v27, v28): # RoundWithAction
            del v0
            v29 = method90(v22, v23, v24, v25, v26, v27, v28)
            del v22, v23, v24, v25, v26, v27, v28
            v30 = "RoundWithAction"
            v31 = [v30,v29]
            del v29, v30
            return v31
        case US4_4(v32, v33, v34, v35, v36, v37): # TerminalCall
            del v0
            v38 = method86(v32, v33, v34, v35, v36, v37)
            del v32, v33, v34, v35, v36, v37
            v39 = "TerminalCall"
            v40 = [v39,v38]
            del v38, v39
            return v40
        case US4_5(v41, v42, v43, v44, v45, v46): # TerminalFold
            del v0
            v47 = method86(v41, v42, v43, v44, v45, v46)
            del v41, v42, v43, v44, v45, v46
            v48 = "TerminalFold"
            v49 = [v48,v47]
            del v47, v48
            return v49
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method84(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = method74()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method85(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method92(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = method74()
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = method74()
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method91(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method33(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = method92(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method93(v0 : US7) -> object:
    match v0:
        case US7_0(): # GameNotStarted
            del v0
            v1 = method74()
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US7_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method86(v4, v5, v6, v7, v8, v9)
            del v4, v5, v6, v7, v8, v9
            v11 = "GameOver"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US7_2(v13, v14, v15, v16, v17, v18): # WaitingForActionFromPlayerId
            del v0
            v19 = method86(v13, v14, v15, v16, v17, v18)
            del v13, v14, v15, v16, v17, v18
            v20 = "WaitingForActionFromPlayerId"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method83(v0 : US3, v1 : static_array, v2 : US7) -> object:
    v3 = method84(v0)
    del v0
    v4 = method91(v1)
    del v1
    v5 = method93(v2)
    del v2
    v6 = {'game': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method70(v0 : static_array_list, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US7) -> object:
    v5 = method71(v0, v1)
    del v0, v1
    v6 = method83(v2, v3, v4)
    del v2, v3, v4
    v7 = {'large': v5, 'small': v6}
    del v5, v6
    return v7
def method94(v0 : static_array_list, v1 : static_array, v2 : US7) -> object:
    v3 = method75(v0)
    del v0
    v4 = method91(v1)
    del v1
    v5 = method93(v2)
    del v2
    v6 = {'messages': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method69(v0 : static_array_list, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US7, v5 : static_array_list, v6 : static_array, v7 : US7) -> object:
    v8 = method70(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    v9 = method94(v5, v6, v7)
    del v5, v6, v7
    v10 = {'game_state': v8, 'ui_state': v9}
    del v8, v9
    return v10
def method68(v0 : static_array_list, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US7, v5 : static_array_list, v6 : static_array, v7 : US7) -> object:
    v8 = method69(v0, v1, v2, v3, v4, v5, v6, v7)
    del v0, v1, v2, v3, v4, v5, v6, v7
    return v8
def method96(v0 : static_array_list, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US7) -> object:
    v5 = method70(v0, v1, v2, v3, v4)
    del v0, v2
    v6 = method94(v1, v3, v4)
    del v1, v3, v4
    v7 = {'game_state': v5, 'ui_state': v6}
    del v5, v6
    return v7
def method95(v0 : static_array_list, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US7) -> object:
    v5 = method96(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    return v5
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("Leduc_Game",['event_loop_gpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
