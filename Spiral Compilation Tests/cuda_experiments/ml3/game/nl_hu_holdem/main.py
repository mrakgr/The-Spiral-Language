kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
#include <curand_kernel.h>
__device__ void write_0(const char * v0);
struct US1;
struct US2;
struct US0;
__device__ long f_2(unsigned char * v0);
__device__ void f_4(unsigned char * v0);
__device__ US1 f_3(unsigned char * v0);
__device__ US2 f_6(unsigned char * v0);
__device__ static_array<US2,2l> f_5(unsigned char * v0);
__device__ US0 f_1(unsigned char * v0);
struct Tuple0;
struct US3;
struct US6;
struct US5;
struct US4;
struct US7;
struct Tuple1;
__device__ unsigned long long f_8(unsigned char * v0);
__device__ long f_9(unsigned char * v0);
__device__ unsigned char f_13(unsigned char * v0);
__device__ unsigned char f_12(unsigned char * v0);
__device__ static_array_list<unsigned char,5l,long> f_11(unsigned char * v0);
struct Tuple2;
__device__ Tuple2 f_14(unsigned char * v0);
struct Tuple3;
__device__ long f_16(unsigned char * v0);
__device__ Tuple3 f_15(unsigned char * v0);
struct Tuple4;
__device__ Tuple4 f_17(unsigned char * v0);
struct Tuple5;
__device__ Tuple0 f_20(unsigned char * v0);
__device__ Tuple0 f_19(unsigned char * v0);
__device__ Tuple5 f_18(unsigned char * v0);
__device__ US3 f_10(unsigned char * v0);
__device__ long f_21(unsigned char * v0);
struct Tuple6;
__device__ static_array<unsigned char,2l> f_24(unsigned char * v0);
__device__ long f_25(unsigned char * v0);
__device__ static_array<unsigned char,3l> f_26(unsigned char * v0);
__device__ static_array<unsigned char,5l> f_27(unsigned char * v0);
__device__ static_array<unsigned char,4l> f_28(unsigned char * v0);
__device__ Tuple6 f_23(unsigned char * v0);
struct Tuple7;
__device__ long f_30(unsigned char * v0);
__device__ Tuple7 f_29(unsigned char * v0);
__device__ US5 f_22(unsigned char * v0);
__device__ long f_31(unsigned char * v0);
__device__ Tuple1 f_7(unsigned char * v0);
struct Tuple8;
struct Tuple9;
struct Tuple10;
struct Tuple11;
struct Tuple12;
__device__ unsigned long loop_36(unsigned long v0, curandStatePhilox4_32_10_t & v1);
__device__ Tuple12 draw_card_35(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ Tuple10 draw_cards_34(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ static_array_list<unsigned char,5l,long> get_community_cards_37(US6 v0, static_array<unsigned char,3l> v1);
struct Tuple13;
__device__ Tuple13 draw_cards_38(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
struct Tuple14;
__device__ Tuple14 draw_cards_39(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ static_array_list<unsigned char,5l,long> get_community_cards_40(US6 v0, static_array<unsigned char,1l> v1);
struct Tuple15;
__device__ long loop_43(static_array<float,8l> v0, float v1, long v2);
__device__ long sample_discrete__42(static_array<float,8l> v0, curandStatePhilox4_32_10_t & v1);
__device__ US1 sample_discrete_41(static_array<Tuple15,8l> v0, curandStatePhilox4_32_10_t & v1);
struct Tuple16;
struct Tuple17;
struct US8;
struct Tuple18;
struct US9;
struct Tuple19;
struct Tuple20;
struct US10;
struct US11;
struct US12;
struct US13;
struct US14;
__device__ Tuple0 score_44(static_array<unsigned char,7l> v0);
__device__ US5 play_loop_inner_33(unsigned long long & v0, static_array_list<US3,128l,long> & v1, curandStatePhilox4_32_10_t & v2, static_array<US2,2l> v3, US5 v4);
__device__ Tuple8 play_loop_32(US4 v0, static_array<US2,2l> v1, US7 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US5 v6);
__device__ void f_46(unsigned char * v0, unsigned long long v1);
__device__ void f_47(unsigned char * v0, long v1);
__device__ void f_49(unsigned char * v0, long v1);
__device__ void f_52(unsigned char * v0, unsigned char v1);
__device__ void f_51(unsigned char * v0, unsigned char v1);
__device__ void f_50(unsigned char * v0, static_array_list<unsigned char,5l,long> v1);
__device__ void f_53(unsigned char * v0, long v1, long v2);
__device__ void f_55(unsigned char * v0, long v1);
__device__ void f_56(unsigned char * v0);
__device__ void f_54(unsigned char * v0, long v1, US1 v2);
__device__ void f_57(unsigned char * v0, long v1, static_array<unsigned char,2l> v2);
__device__ void f_60(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_59(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_58(unsigned char * v0, long v1, static_array<Tuple0,2l> v2, long v3);
__device__ void f_48(unsigned char * v0, US3 v1);
__device__ void f_61(unsigned char * v0, long v1);
__device__ void f_64(unsigned char * v0, static_array<unsigned char,2l> v1);
__device__ void f_65(unsigned char * v0, long v1);
__device__ void f_66(unsigned char * v0, static_array<unsigned char,3l> v1);
__device__ void f_67(unsigned char * v0, static_array<unsigned char,5l> v1);
__device__ void f_68(unsigned char * v0, static_array<unsigned char,4l> v1);
__device__ void f_63(unsigned char * v0, long v1, bool v2, static_array<static_array<unsigned char,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US6 v7);
__device__ void f_70(unsigned char * v0, long v1);
__device__ void f_69(unsigned char * v0, long v1, bool v2, static_array<static_array<unsigned char,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US6 v7, US1 v8);
__device__ void f_62(unsigned char * v0, US5 v1);
__device__ void f_71(unsigned char * v0, US2 v1);
__device__ void f_72(unsigned char * v0, long v1);
__device__ void f_45(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US4 v3, static_array<US2,2l> v4, US7 v5);
__device__ void f_74(unsigned char * v0, long v1);
__device__ void f_73(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US7 v3);
struct US1 {
    union {
        struct {
            long v0;
        } case2; // A_Raise
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
struct Tuple0 {
    static_array<unsigned char,5l> v0;
    char v1;
    __device__ Tuple0(static_array<unsigned char,5l> t0, char t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct US3 {
    union {
        struct {
            static_array_list<unsigned char,5l,long> v0;
        } case0; // CommunityCardsAre
        struct {
            long v0;
            long v1;
        } case1; // Fold
        struct {
            US1 v1;
            long v0;
        } case2; // PlayerAction
        struct {
            static_array<unsigned char,2l> v1;
            long v0;
        } case3; // PlayerGotCards
        struct {
            static_array<Tuple0,2l> v1;
            long v0;
            long v2;
        } case4; // Showdown
    } v;
    unsigned long tag : 3;
};
struct US6 {
    union {
        struct {
            static_array<unsigned char,3l> v0;
        } case0; // Flop
        struct {
            static_array<unsigned char,5l> v0;
        } case2; // River
        struct {
            static_array<unsigned char,4l> v0;
        } case3; // Turn
    } v;
    unsigned long tag : 3;
};
struct US5 {
    union {
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case0; // G_Flop
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case1; // G_Fold
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case3; // G_River
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case4; // G_Round
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            US1 v7;
            long v0;
            long v3;
            bool v1;
        } case5; // G_Round'
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case6; // G_Showdown
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case7; // G_Turn
    } v;
    unsigned long tag : 4;
};
struct US4 {
    union {
        struct {
            US5 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US7 {
    union {
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case1; // GameOver
        struct {
            static_array<static_array<unsigned char,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US6 v6;
            long v0;
            long v3;
            bool v1;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct Tuple1 {
    unsigned long long v0;
    static_array_list<US3,128l,long> v1;
    US4 v2;
    static_array<US2,2l> v3;
    US7 v4;
    __device__ Tuple1(unsigned long long t0, static_array_list<US3,128l,long> t1, US4 t2, static_array<US2,2l> t3, US7 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
    __device__ Tuple1() = default;
};
struct Tuple2 {
    long v0;
    long v1;
    __device__ Tuple2(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple2() = default;
};
struct Tuple3 {
    US1 v1;
    long v0;
    __device__ Tuple3(long t0, US1 t1) : v0(t0), v1(t1) {}
    __device__ Tuple3() = default;
};
struct Tuple4 {
    static_array<unsigned char,2l> v1;
    long v0;
    __device__ Tuple4(long t0, static_array<unsigned char,2l> t1) : v0(t0), v1(t1) {}
    __device__ Tuple4() = default;
};
struct Tuple5 {
    static_array<Tuple0,2l> v1;
    long v0;
    long v2;
    __device__ Tuple5(long t0, static_array<Tuple0,2l> t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple5() = default;
};
struct Tuple6 {
    static_array<static_array<unsigned char,2l>,2l> v2;
    static_array<long,2l> v4;
    static_array<long,2l> v5;
    US6 v6;
    long v0;
    long v3;
    bool v1;
    __device__ Tuple6(long t0, bool t1, static_array<static_array<unsigned char,2l>,2l> t2, long t3, static_array<long,2l> t4, static_array<long,2l> t5, US6 t6) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6) {}
    __device__ Tuple6() = default;
};
struct Tuple7 {
    static_array<static_array<unsigned char,2l>,2l> v2;
    static_array<long,2l> v4;
    static_array<long,2l> v5;
    US6 v6;
    US1 v7;
    long v0;
    long v3;
    bool v1;
    __device__ Tuple7(long t0, bool t1, static_array<static_array<unsigned char,2l>,2l> t2, long t3, static_array<long,2l> t4, static_array<long,2l> t5, US6 t6, US1 t7) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6), v7(t7) {}
    __device__ Tuple7() = default;
};
struct Tuple8 {
    US4 v0;
    static_array<US2,2l> v1;
    US7 v2;
    __device__ Tuple8(US4 t0, static_array<US2,2l> t1, US7 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple8() = default;
};
struct Tuple9 {
    US5 v1;
    bool v0;
    __device__ Tuple9(bool t0, US5 t1) : v0(t0), v1(t1) {}
    __device__ Tuple9() = default;
};
struct Tuple10 {
    static_array<unsigned char,3l> v0;
    unsigned long long v1;
    __device__ Tuple10(static_array<unsigned char,3l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple10() = default;
};
struct Tuple11 {
    unsigned long long v1;
    long v0;
    __device__ Tuple11(long t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple11() = default;
};
struct Tuple12 {
    unsigned long long v1;
    unsigned char v0;
    __device__ Tuple12(unsigned char t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple12() = default;
};
struct Tuple13 {
    static_array<unsigned char,2l> v0;
    unsigned long long v1;
    __device__ Tuple13(static_array<unsigned char,2l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple13() = default;
};
struct Tuple14 {
    static_array<unsigned char,1l> v0;
    unsigned long long v1;
    __device__ Tuple14(static_array<unsigned char,1l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple14() = default;
};
struct Tuple15 {
    US1 v0;
    float v1;
    __device__ Tuple15(US1 t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple15() = default;
};
struct Tuple16 {
    long v1;
    bool v0;
    __device__ Tuple16(bool t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple16() = default;
};
struct Tuple17 {
    long v0;
    long v1;
    long v2;
    __device__ Tuple17(long t0, long t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple17() = default;
};
struct US8 {
    union {
    } v;
    unsigned long tag : 2;
};
struct Tuple18 {
    long v0;
    long v1;
    unsigned char v2;
    __device__ Tuple18(long t0, long t1, unsigned char t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple18() = default;
};
struct US9 {
    union {
        struct {
            static_array<unsigned char,5l> v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct Tuple19 {
    US8 v1;
    long v0;
    __device__ Tuple19(long t0, US8 t1) : v0(t0), v1(t1) {}
    __device__ Tuple19() = default;
};
struct Tuple20 {
    long v0;
    long v1;
    long v2;
    unsigned char v3;
    __device__ Tuple20(long t0, long t1, long t2, unsigned char t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    __device__ Tuple20() = default;
};
struct US10 {
    union {
        struct {
            static_array<unsigned char,4l> v0;
            static_array<unsigned char,3l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US11 {
    union {
        struct {
            static_array<unsigned char,3l> v0;
            static_array<unsigned char,4l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US12 {
    union {
        struct {
            static_array<unsigned char,2l> v0;
            static_array<unsigned char,2l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US13 {
    union {
        struct {
            static_array<unsigned char,2l> v0;
            static_array<unsigned char,5l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US14 {
    union {
        struct {
            static_array<unsigned char,2l> v0;
            static_array<unsigned char,3l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
__device__ void write_0(const char * v0){
    const char * v1;
    v1 = "%s";
    printf(v1,v0);
    return ;
}
__device__ US1 US1_0() { // A_Call
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1() { // A_Fold
    US1 x;
    x.tag = 1;
    return x;
}
__device__ US1 US1_2(long v0) { // A_Raise
    US1 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
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
__device__ long f_2(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ void f_4(unsigned char * v0){
    return ;
}
__device__ US1 f_3(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    switch (v1) {
        case 0: {
            f_4(v2);
            return US1_0();
            break;
        }
        case 1: {
            f_4(v2);
            return US1_1();
            break;
        }
        case 2: {
            long v6;
            v6 = f_2(v2);
            return US1_2(v6);
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
__device__ US2 f_6(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    switch (v1) {
        case 0: {
            f_4(v2);
            return US2_0();
            break;
        }
        case 1: {
            f_4(v2);
            return US2_1();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ static_array<US2,2l> f_5(unsigned char * v0){
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
        v7 = f_6(v6);
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
__device__ US0 f_1(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+8ull);
    switch (v1) {
        case 0: {
            US1 v4;
            v4 = f_3(v2);
            return US0_0(v4);
            break;
        }
        case 1: {
            static_array<US2,2l> v6;
            v6 = f_5(v2);
            return US0_1(v6);
            break;
        }
        case 2: {
            f_4(v2);
            return US0_2();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ US3 US3_0(static_array_list<unsigned char,5l,long> v0) { // CommunityCardsAre
    US3 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US3 US3_1(long v0, long v1) { // Fold
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US3 US3_2(long v0, US1 v1) { // PlayerAction
    US3 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1;
    return x;
}
__device__ US3 US3_3(long v0, static_array<unsigned char,2l> v1) { // PlayerGotCards
    US3 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1;
    return x;
}
__device__ US3 US3_4(long v0, static_array<Tuple0,2l> v1, long v2) { // Showdown
    US3 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2;
    return x;
}
__device__ US6 US6_0(static_array<unsigned char,3l> v0) { // Flop
    US6 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US6 US6_1() { // Preflop
    US6 x;
    x.tag = 1;
    return x;
}
__device__ US6 US6_2(static_array<unsigned char,5l> v0) { // River
    US6 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US6 US6_3(static_array<unsigned char,4l> v0) { // Turn
    US6 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
    return x;
}
__device__ US5 US5_0(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // G_Flop
    US5 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5; x.v.case0.v6 = v6;
    return x;
}
__device__ US5 US5_1(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // G_Fold
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5; x.v.case1.v6 = v6;
    return x;
}
__device__ US5 US5_2() { // G_Preflop
    US5 x;
    x.tag = 2;
    return x;
}
__device__ US5 US5_3(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // G_River
    US5 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5; x.v.case3.v6 = v6;
    return x;
}
__device__ US5 US5_4(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // G_Round
    US5 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5; x.v.case4.v6 = v6;
    return x;
}
__device__ US5 US5_5(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6, US1 v7) { // G_Round'
    US5 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5; x.v.case5.v6 = v6; x.v.case5.v7 = v7;
    return x;
}
__device__ US5 US5_6(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // G_Showdown
    US5 x;
    x.tag = 6;
    x.v.case6.v0 = v0; x.v.case6.v1 = v1; x.v.case6.v2 = v2; x.v.case6.v3 = v3; x.v.case6.v4 = v4; x.v.case6.v5 = v5; x.v.case6.v6 = v6;
    return x;
}
__device__ US5 US5_7(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // G_Turn
    US5 x;
    x.tag = 7;
    x.v.case7.v0 = v0; x.v.case7.v1 = v1; x.v.case7.v2 = v2; x.v.case7.v3 = v3; x.v.case7.v4 = v4; x.v.case7.v5 = v5; x.v.case7.v6 = v6;
    return x;
}
__device__ US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1(US5 v0) { // Some
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US7 US7_0() { // GameNotStarted
    US7 x;
    x.tag = 0;
    return x;
}
__device__ US7 US7_1(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // GameOver
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5; x.v.case1.v6 = v6;
    return x;
}
__device__ US7 US7_2(long v0, bool v1, static_array<static_array<unsigned char,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US6 v6) { // WaitingForActionFromPlayerId
    US7 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5; x.v.case2.v6 = v6;
    return x;
}
__device__ unsigned long long f_8(unsigned char * v0){
    unsigned long long * v1;
    v1 = (unsigned long long *)(v0+0ull);
    unsigned long long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long f_9(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+8ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ inline bool while_method_1(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__device__ unsigned char f_13(unsigned char * v0){
    unsigned char * v1;
    v1 = (unsigned char *)(v0+0ull);
    unsigned char v2;
    v2 = v1[0l];
    return v2;
}
__device__ unsigned char f_12(unsigned char * v0){
    unsigned char v1;
    v1 = f_13(v0);
    return v1;
}
__device__ static_array_list<unsigned char,5l,long> f_11(unsigned char * v0){
    static_array_list<unsigned char,5l,long> v1;
    v1.length = 0;
    long v2;
    v2 = f_2(v0);
    v1.length = v2;
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_1(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = 4ull + v6;
        unsigned char * v8;
        v8 = (unsigned char *)(v0+v7);
        unsigned char v9;
        v9 = f_12(v8);
        bool v10;
        v10 = 0l <= v4;
        bool v13;
        if (v10){
            long v11;
            v11 = v1.length;
            bool v12;
            v12 = v4 < v11;
            v13 = v12;
        } else {
            v13 = false;
        }
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The set index needs to be in range for the static array list." && v13);
        } else {
        }
        v1.v[v4] = v9;
        v4 += 1l ;
    }
    return v1;
}
__device__ Tuple2 f_14(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long * v3;
    v3 = (long *)(v0+4ull);
    long v4;
    v4 = v3[0l];
    return Tuple2(v2, v4);
}
__device__ long f_16(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+4ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple3 f_15(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long v3;
    v3 = f_16(v0);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+8ull);
    US1 v10;
    switch (v3) {
        case 0: {
            f_4(v4);
            v10 = US1_0();
            break;
        }
        case 1: {
            f_4(v4);
            v10 = US1_1();
            break;
        }
        case 2: {
            long v8;
            v8 = f_2(v4);
            v10 = US1_2(v8);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple3(v2, v10);
}
__device__ Tuple4 f_17(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<unsigned char,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = 4ull + v6;
        unsigned char * v8;
        v8 = (unsigned char *)(v0+v7);
        unsigned char v9;
        v9 = f_12(v8);
        bool v10;
        v10 = 0l <= v4;
        bool v12;
        if (v10){
            bool v11;
            v11 = v4 < 2l;
            v12 = v11;
        } else {
            v12 = false;
        }
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The read index needs to be in range for the static array." && v12);
        } else {
        }
        v3.v[v4] = v9;
        v4 += 1l ;
    }
    return Tuple4(v2, v3);
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
__device__ Tuple0 f_20(unsigned char * v0){
    static_array<unsigned char,5l> v1;
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_12(v5);
        bool v7;
        v7 = 0l <= v2;
        bool v9;
        if (v7){
            bool v8;
            v8 = v2 < 5l;
            v9 = v8;
        } else {
            v9 = false;
        }
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The read index needs to be in range for the static array." && v9);
        } else {
        }
        v1.v[v2] = v6;
        v2 += 1l ;
    }
    char * v11;
    v11 = (char *)(v0+5ull);
    char v12;
    v12 = v11[0l];
    return Tuple0(v1, v12);
}
__device__ Tuple0 f_19(unsigned char * v0){
    static_array<unsigned char,5l> v1; char v2;
    Tuple0 tmp3 = f_20(v0);
    v1 = tmp3.v0; v2 = tmp3.v1;
    return Tuple0(v1, v2);
}
__device__ Tuple5 f_18(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<Tuple0,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 8ull;
        unsigned long long v8;
        v8 = 8ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        static_array<unsigned char,5l> v10; char v11;
        Tuple0 tmp4 = f_19(v9);
        v10 = tmp4.v0; v11 = tmp4.v1;
        bool v12;
        v12 = 0l <= v4;
        bool v14;
        if (v12){
            bool v13;
            v13 = v4 < 2l;
            v14 = v13;
        } else {
            v14 = false;
        }
        bool v15;
        v15 = v14 == false;
        if (v15){
            assert("The read index needs to be in range for the static array." && v14);
        } else {
        }
        v3.v[v4] = Tuple0(v10, v11);
        v4 += 1l ;
    }
    long * v16;
    v16 = (long *)(v0+24ull);
    long v17;
    v17 = v16[0l];
    return Tuple5(v2, v3, v17);
}
__device__ US3 f_10(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            static_array_list<unsigned char,5l,long> v4;
            v4 = f_11(v2);
            return US3_0(v4);
            break;
        }
        case 1: {
            long v6; long v7;
            Tuple2 tmp0 = f_14(v2);
            v6 = tmp0.v0; v7 = tmp0.v1;
            return US3_1(v6, v7);
            break;
        }
        case 2: {
            long v9; US1 v10;
            Tuple3 tmp1 = f_15(v2);
            v9 = tmp1.v0; v10 = tmp1.v1;
            return US3_2(v9, v10);
            break;
        }
        case 3: {
            long v12; static_array<unsigned char,2l> v13;
            Tuple4 tmp2 = f_17(v2);
            v12 = tmp2.v0; v13 = tmp2.v1;
            return US3_3(v12, v13);
            break;
        }
        case 4: {
            long v15; static_array<Tuple0,2l> v16; long v17;
            Tuple5 tmp5 = f_18(v2);
            v15 = tmp5.v0; v16 = tmp5.v1; v17 = tmp5.v2;
            return US3_4(v15, v16, v17);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_21(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+6160ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ static_array<unsigned char,2l> f_24(unsigned char * v0){
    static_array<unsigned char,2l> v1;
    long v2;
    v2 = 0l;
    while (while_method_0(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_12(v5);
        bool v7;
        v7 = 0l <= v2;
        bool v9;
        if (v7){
            bool v8;
            v8 = v2 < 2l;
            v9 = v8;
        } else {
            v9 = false;
        }
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The read index needs to be in range for the static array." && v9);
        } else {
        }
        v1.v[v2] = v6;
        v2 += 1l ;
    }
    return v1;
}
__device__ long f_25(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+32ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
__device__ static_array<unsigned char,3l> f_26(unsigned char * v0){
    static_array<unsigned char,3l> v1;
    long v2;
    v2 = 0l;
    while (while_method_3(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_12(v5);
        bool v7;
        v7 = 0l <= v2;
        bool v9;
        if (v7){
            bool v8;
            v8 = v2 < 3l;
            v9 = v8;
        } else {
            v9 = false;
        }
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The read index needs to be in range for the static array." && v9);
        } else {
        }
        v1.v[v2] = v6;
        v2 += 1l ;
    }
    return v1;
}
__device__ static_array<unsigned char,5l> f_27(unsigned char * v0){
    static_array<unsigned char,5l> v1;
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_12(v5);
        bool v7;
        v7 = 0l <= v2;
        bool v9;
        if (v7){
            bool v8;
            v8 = v2 < 5l;
            v9 = v8;
        } else {
            v9 = false;
        }
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The read index needs to be in range for the static array." && v9);
        } else {
        }
        v1.v[v2] = v6;
        v2 += 1l ;
    }
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ static_array<unsigned char,4l> f_28(unsigned char * v0){
    static_array<unsigned char,4l> v1;
    long v2;
    v2 = 0l;
    while (while_method_4(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_12(v5);
        bool v7;
        v7 = 0l <= v2;
        bool v9;
        if (v7){
            bool v8;
            v8 = v2 < 4l;
            v9 = v8;
        } else {
            v9 = false;
        }
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The read index needs to be in range for the static array." && v9);
        } else {
        }
        v1.v[v2] = v6;
        v2 += 1l ;
    }
    return v1;
}
__device__ Tuple6 f_23(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    bool * v3;
    v3 = (bool *)(v0+4ull);
    bool v4;
    v4 = v3[0l];
    static_array<static_array<unsigned char,2l>,2l> v5;
    long v6;
    v6 = 0l;
    while (while_method_0(v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 2ull;
        unsigned long long v10;
        v10 = 6ull + v9;
        unsigned char * v11;
        v11 = (unsigned char *)(v0+v10);
        static_array<unsigned char,2l> v12;
        v12 = f_24(v11);
        bool v13;
        v13 = 0l <= v6;
        bool v15;
        if (v13){
            bool v14;
            v14 = v6 < 2l;
            v15 = v14;
        } else {
            v15 = false;
        }
        bool v16;
        v16 = v15 == false;
        if (v16){
            assert("The read index needs to be in range for the static array." && v15);
        } else {
        }
        v5.v[v6] = v12;
        v6 += 1l ;
    }
    long * v17;
    v17 = (long *)(v0+12ull);
    long v18;
    v18 = v17[0l];
    static_array<long,2l> v19;
    long v20;
    v20 = 0l;
    while (while_method_0(v20)){
        unsigned long long v22;
        v22 = (unsigned long long)v20;
        unsigned long long v23;
        v23 = v22 * 4ull;
        unsigned long long v24;
        v24 = 16ull + v23;
        unsigned char * v25;
        v25 = (unsigned char *)(v0+v24);
        long v26;
        v26 = f_2(v25);
        bool v27;
        v27 = 0l <= v20;
        bool v29;
        if (v27){
            bool v28;
            v28 = v20 < 2l;
            v29 = v28;
        } else {
            v29 = false;
        }
        bool v30;
        v30 = v29 == false;
        if (v30){
            assert("The read index needs to be in range for the static array." && v29);
        } else {
        }
        v19.v[v20] = v26;
        v20 += 1l ;
    }
    static_array<long,2l> v31;
    long v32;
    v32 = 0l;
    while (while_method_0(v32)){
        unsigned long long v34;
        v34 = (unsigned long long)v32;
        unsigned long long v35;
        v35 = v34 * 4ull;
        unsigned long long v36;
        v36 = 24ull + v35;
        unsigned char * v37;
        v37 = (unsigned char *)(v0+v36);
        long v38;
        v38 = f_2(v37);
        bool v39;
        v39 = 0l <= v32;
        bool v41;
        if (v39){
            bool v40;
            v40 = v32 < 2l;
            v41 = v40;
        } else {
            v41 = false;
        }
        bool v42;
        v42 = v41 == false;
        if (v42){
            assert("The read index needs to be in range for the static array." && v41);
        } else {
        }
        v31.v[v32] = v38;
        v32 += 1l ;
    }
    long v43;
    v43 = f_25(v0);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+40ull);
    US6 v53;
    switch (v43) {
        case 0: {
            static_array<unsigned char,3l> v46;
            v46 = f_26(v44);
            v53 = US6_0(v46);
            break;
        }
        case 1: {
            f_4(v44);
            v53 = US6_1();
            break;
        }
        case 2: {
            static_array<unsigned char,5l> v49;
            v49 = f_27(v44);
            v53 = US6_2(v49);
            break;
        }
        case 3: {
            static_array<unsigned char,4l> v51;
            v51 = f_28(v44);
            v53 = US6_3(v51);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple6(v2, v4, v5, v18, v19, v31, v53);
}
__device__ long f_30(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+48ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple7 f_29(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    bool * v3;
    v3 = (bool *)(v0+4ull);
    bool v4;
    v4 = v3[0l];
    static_array<static_array<unsigned char,2l>,2l> v5;
    long v6;
    v6 = 0l;
    while (while_method_0(v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 2ull;
        unsigned long long v10;
        v10 = 6ull + v9;
        unsigned char * v11;
        v11 = (unsigned char *)(v0+v10);
        static_array<unsigned char,2l> v12;
        v12 = f_24(v11);
        bool v13;
        v13 = 0l <= v6;
        bool v15;
        if (v13){
            bool v14;
            v14 = v6 < 2l;
            v15 = v14;
        } else {
            v15 = false;
        }
        bool v16;
        v16 = v15 == false;
        if (v16){
            assert("The read index needs to be in range for the static array." && v15);
        } else {
        }
        v5.v[v6] = v12;
        v6 += 1l ;
    }
    long * v17;
    v17 = (long *)(v0+12ull);
    long v18;
    v18 = v17[0l];
    static_array<long,2l> v19;
    long v20;
    v20 = 0l;
    while (while_method_0(v20)){
        unsigned long long v22;
        v22 = (unsigned long long)v20;
        unsigned long long v23;
        v23 = v22 * 4ull;
        unsigned long long v24;
        v24 = 16ull + v23;
        unsigned char * v25;
        v25 = (unsigned char *)(v0+v24);
        long v26;
        v26 = f_2(v25);
        bool v27;
        v27 = 0l <= v20;
        bool v29;
        if (v27){
            bool v28;
            v28 = v20 < 2l;
            v29 = v28;
        } else {
            v29 = false;
        }
        bool v30;
        v30 = v29 == false;
        if (v30){
            assert("The read index needs to be in range for the static array." && v29);
        } else {
        }
        v19.v[v20] = v26;
        v20 += 1l ;
    }
    static_array<long,2l> v31;
    long v32;
    v32 = 0l;
    while (while_method_0(v32)){
        unsigned long long v34;
        v34 = (unsigned long long)v32;
        unsigned long long v35;
        v35 = v34 * 4ull;
        unsigned long long v36;
        v36 = 24ull + v35;
        unsigned char * v37;
        v37 = (unsigned char *)(v0+v36);
        long v38;
        v38 = f_2(v37);
        bool v39;
        v39 = 0l <= v32;
        bool v41;
        if (v39){
            bool v40;
            v40 = v32 < 2l;
            v41 = v40;
        } else {
            v41 = false;
        }
        bool v42;
        v42 = v41 == false;
        if (v42){
            assert("The read index needs to be in range for the static array." && v41);
        } else {
        }
        v31.v[v32] = v38;
        v32 += 1l ;
    }
    long v43;
    v43 = f_25(v0);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+40ull);
    US6 v53;
    switch (v43) {
        case 0: {
            static_array<unsigned char,3l> v46;
            v46 = f_26(v44);
            v53 = US6_0(v46);
            break;
        }
        case 1: {
            f_4(v44);
            v53 = US6_1();
            break;
        }
        case 2: {
            static_array<unsigned char,5l> v49;
            v49 = f_27(v44);
            v53 = US6_2(v49);
            break;
        }
        case 3: {
            static_array<unsigned char,4l> v51;
            v51 = f_28(v44);
            v53 = US6_3(v51);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v54;
    v54 = f_30(v0);
    unsigned char * v55;
    v55 = (unsigned char *)(v0+52ull);
    US1 v61;
    switch (v54) {
        case 0: {
            f_4(v55);
            v61 = US1_0();
            break;
        }
        case 1: {
            f_4(v55);
            v61 = US1_1();
            break;
        }
        case 2: {
            long v59;
            v59 = f_2(v55);
            v61 = US1_2(v59);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple7(v2, v4, v5, v18, v19, v31, v53, v61);
}
__device__ US5 f_22(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            long v4; bool v5; static_array<static_array<unsigned char,2l>,2l> v6; long v7; static_array<long,2l> v8; static_array<long,2l> v9; US6 v10;
            Tuple6 tmp6 = f_23(v2);
            v4 = tmp6.v0; v5 = tmp6.v1; v6 = tmp6.v2; v7 = tmp6.v3; v8 = tmp6.v4; v9 = tmp6.v5; v10 = tmp6.v6;
            return US5_0(v4, v5, v6, v7, v8, v9, v10);
            break;
        }
        case 1: {
            long v12; bool v13; static_array<static_array<unsigned char,2l>,2l> v14; long v15; static_array<long,2l> v16; static_array<long,2l> v17; US6 v18;
            Tuple6 tmp7 = f_23(v2);
            v12 = tmp7.v0; v13 = tmp7.v1; v14 = tmp7.v2; v15 = tmp7.v3; v16 = tmp7.v4; v17 = tmp7.v5; v18 = tmp7.v6;
            return US5_1(v12, v13, v14, v15, v16, v17, v18);
            break;
        }
        case 2: {
            f_4(v2);
            return US5_2();
            break;
        }
        case 3: {
            long v21; bool v22; static_array<static_array<unsigned char,2l>,2l> v23; long v24; static_array<long,2l> v25; static_array<long,2l> v26; US6 v27;
            Tuple6 tmp8 = f_23(v2);
            v21 = tmp8.v0; v22 = tmp8.v1; v23 = tmp8.v2; v24 = tmp8.v3; v25 = tmp8.v4; v26 = tmp8.v5; v27 = tmp8.v6;
            return US5_3(v21, v22, v23, v24, v25, v26, v27);
            break;
        }
        case 4: {
            long v29; bool v30; static_array<static_array<unsigned char,2l>,2l> v31; long v32; static_array<long,2l> v33; static_array<long,2l> v34; US6 v35;
            Tuple6 tmp9 = f_23(v2);
            v29 = tmp9.v0; v30 = tmp9.v1; v31 = tmp9.v2; v32 = tmp9.v3; v33 = tmp9.v4; v34 = tmp9.v5; v35 = tmp9.v6;
            return US5_4(v29, v30, v31, v32, v33, v34, v35);
            break;
        }
        case 5: {
            long v37; bool v38; static_array<static_array<unsigned char,2l>,2l> v39; long v40; static_array<long,2l> v41; static_array<long,2l> v42; US6 v43; US1 v44;
            Tuple7 tmp10 = f_29(v2);
            v37 = tmp10.v0; v38 = tmp10.v1; v39 = tmp10.v2; v40 = tmp10.v3; v41 = tmp10.v4; v42 = tmp10.v5; v43 = tmp10.v6; v44 = tmp10.v7;
            return US5_5(v37, v38, v39, v40, v41, v42, v43, v44);
            break;
        }
        case 6: {
            long v46; bool v47; static_array<static_array<unsigned char,2l>,2l> v48; long v49; static_array<long,2l> v50; static_array<long,2l> v51; US6 v52;
            Tuple6 tmp11 = f_23(v2);
            v46 = tmp11.v0; v47 = tmp11.v1; v48 = tmp11.v2; v49 = tmp11.v3; v50 = tmp11.v4; v51 = tmp11.v5; v52 = tmp11.v6;
            return US5_6(v46, v47, v48, v49, v50, v51, v52);
            break;
        }
        case 7: {
            long v54; bool v55; static_array<static_array<unsigned char,2l>,2l> v56; long v57; static_array<long,2l> v58; static_array<long,2l> v59; US6 v60;
            Tuple6 tmp12 = f_23(v2);
            v54 = tmp12.v0; v55 = tmp12.v1; v56 = tmp12.v2; v57 = tmp12.v3; v58 = tmp12.v4; v59 = tmp12.v5; v60 = tmp12.v6;
            return US5_7(v54, v55, v56, v57, v58, v59, v60);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_31(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+6264ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple1 f_7(unsigned char * v0){
    unsigned long long v1;
    v1 = f_8(v0);
    static_array_list<US3,128l,long> v2;
    v2.length = 0;
    long v3;
    v3 = f_9(v0);
    v2.length = v3;
    long v4;
    v4 = v2.length;
    long v5;
    v5 = 0l;
    while (while_method_1(v4, v5)){
        unsigned long long v7;
        v7 = (unsigned long long)v5;
        unsigned long long v8;
        v8 = v7 * 48ull;
        unsigned long long v9;
        v9 = 16ull + v8;
        unsigned char * v10;
        v10 = (unsigned char *)(v0+v9);
        US3 v11;
        v11 = f_10(v10);
        bool v12;
        v12 = 0l <= v5;
        bool v15;
        if (v12){
            long v13;
            v13 = v2.length;
            bool v14;
            v14 = v5 < v13;
            v15 = v14;
        } else {
            v15 = false;
        }
        bool v16;
        v16 = v15 == false;
        if (v16){
            assert("The set index needs to be in range for the static array list." && v15);
        } else {
        }
        v2.v[v5] = v11;
        v5 += 1l ;
    }
    long v17;
    v17 = f_21(v0);
    unsigned char * v18;
    v18 = (unsigned char *)(v0+6176ull);
    US4 v23;
    switch (v17) {
        case 0: {
            f_4(v18);
            v23 = US4_0();
            break;
        }
        case 1: {
            US5 v21;
            v21 = f_22(v18);
            v23 = US4_1(v21);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    static_array<US2,2l> v24;
    long v25;
    v25 = 0l;
    while (while_method_0(v25)){
        unsigned long long v27;
        v27 = (unsigned long long)v25;
        unsigned long long v28;
        v28 = v27 * 4ull;
        unsigned long long v29;
        v29 = 6256ull + v28;
        unsigned char * v30;
        v30 = (unsigned char *)(v0+v29);
        US2 v31;
        v31 = f_6(v30);
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
    long v36;
    v36 = f_31(v0);
    unsigned char * v37;
    v37 = (unsigned char *)(v0+6272ull);
    US7 v56;
    switch (v36) {
        case 0: {
            f_4(v37);
            v56 = US7_0();
            break;
        }
        case 1: {
            long v40; bool v41; static_array<static_array<unsigned char,2l>,2l> v42; long v43; static_array<long,2l> v44; static_array<long,2l> v45; US6 v46;
            Tuple6 tmp13 = f_23(v37);
            v40 = tmp13.v0; v41 = tmp13.v1; v42 = tmp13.v2; v43 = tmp13.v3; v44 = tmp13.v4; v45 = tmp13.v5; v46 = tmp13.v6;
            v56 = US7_1(v40, v41, v42, v43, v44, v45, v46);
            break;
        }
        case 2: {
            long v48; bool v49; static_array<static_array<unsigned char,2l>,2l> v50; long v51; static_array<long,2l> v52; static_array<long,2l> v53; US6 v54;
            Tuple6 tmp14 = f_23(v37);
            v48 = tmp14.v0; v49 = tmp14.v1; v50 = tmp14.v2; v51 = tmp14.v3; v52 = tmp14.v4; v53 = tmp14.v5; v54 = tmp14.v6;
            v56 = US7_2(v48, v49, v50, v51, v52, v53, v54);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple1(v1, v2, v23, v24, v56);
}
__device__ inline bool while_method_5(bool v0, US5 v1){
    return v0;
}
__device__ unsigned long loop_36(unsigned long v0, curandStatePhilox4_32_10_t & v1){
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
        return loop_36(v0, v1);
    }
}
__device__ Tuple12 draw_card_35(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    long v2;
    v2 = __popcll(v1);
    unsigned long v3;
    v3 = (unsigned long)v2;
    unsigned long v4;
    v4 = loop_36(v3, v0);
    long v5;
    v5 = (long)v4;
    unsigned long v6;
    v6 = (unsigned long)v1;
    unsigned long long v7;
    v7 = v1 >> 32l;
    unsigned long v8;
    v8 = (unsigned long)v7;
    long v9;
    v9 = __popc(v6);
    bool v10;
    v10 = v5 < v9;
    unsigned long v17;
    if (v10){
        long v11;
        v11 = v5 + 1l;
        unsigned long v12;
        v12 = __fns(v6,0ul,v11);
        v17 = v12;
    } else {
        long v13;
        v13 = v5 - v9;
        long v14;
        v14 = v13 + 1l;
        unsigned long v15;
        v15 = __fns(v8,0ul,v14);
        unsigned long v16;
        v16 = v15 + 32ul;
        v17 = v16;
    }
    unsigned char v18;
    v18 = (unsigned char)v17;
    unsigned char v19;
    v19 = v18 / 13u;
    unsigned char v20;
    v20 = v18 % 13u;
    unsigned char v21;
    v21 = v20 << 2l;
    unsigned char v22;
    v22 = v21 | v19;
    long v23;
    v23 = (long)v17;
    unsigned long long v24;
    v24 = 1ull << v23;
    unsigned long long v25;
    v25 = v1 ^ v24;
    return Tuple12(v22, v25);
}
__device__ Tuple10 draw_cards_34(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,3l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp17 = Tuple11(0l, v1);
    v3 = tmp17.v0; v4 = tmp17.v1;
    while (while_method_3(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple12 tmp18 = draw_card_35(v0, v4);
        v6 = tmp18.v0; v7 = tmp18.v1;
        bool v8;
        v8 = 0l <= v3;
        bool v10;
        if (v8){
            bool v9;
            v9 = v3 < 3l;
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
        v2.v[v3] = v6;
        v4 = v7;
        v3 += 1l ;
    }
    return Tuple10(v2, v4);
}
__device__ static_array_list<unsigned char,5l,long> get_community_cards_37(US6 v0, static_array<unsigned char,3l> v1){
    static_array_list<unsigned char,5l,long> v2;
    v2.length = 0;
    switch (v0.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v3 = v0.v.case0.v0;
            long v4;
            v4 = 0l;
            while (while_method_3(v4)){
                bool v6;
                v6 = 0l <= v4;
                bool v8;
                if (v6){
                    bool v7;
                    v7 = v4 < 3l;
                    v8 = v7;
                } else {
                    v8 = false;
                }
                bool v9;
                v9 = v8 == false;
                if (v9){
                    assert("The read index needs to be in range for the static array." && v8);
                } else {
                }
                unsigned char v10;
                v10 = v3.v[v4];
                long v11;
                v11 = v2.length;
                bool v12;
                v12 = v11 < 5l;
                bool v13;
                v13 = v12 == false;
                if (v13){
                    assert("The length has to be less than the maximum length of the array." && v12);
                } else {
                }
                long v14;
                v14 = v11 + 1l;
                v2.length = v14;
                bool v15;
                v15 = 0l <= v11;
                bool v18;
                if (v15){
                    long v16;
                    v16 = v2.length;
                    bool v17;
                    v17 = v11 < v16;
                    v18 = v17;
                } else {
                    v18 = false;
                }
                bool v19;
                v19 = v18 == false;
                if (v19){
                    assert("The set index needs to be in range for the static array list." && v18);
                } else {
                }
                v2.v[v11] = v10;
                v4 += 1l ;
            }
            break;
        }
        case 1: { // Preflop
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v37 = v0.v.case2.v0;
            long v38;
            v38 = 0l;
            while (while_method_2(v38)){
                bool v40;
                v40 = 0l <= v38;
                bool v42;
                if (v40){
                    bool v41;
                    v41 = v38 < 5l;
                    v42 = v41;
                } else {
                    v42 = false;
                }
                bool v43;
                v43 = v42 == false;
                if (v43){
                    assert("The read index needs to be in range for the static array." && v42);
                } else {
                }
                unsigned char v44;
                v44 = v37.v[v38];
                long v45;
                v45 = v2.length;
                bool v46;
                v46 = v45 < 5l;
                bool v47;
                v47 = v46 == false;
                if (v47){
                    assert("The length has to be less than the maximum length of the array." && v46);
                } else {
                }
                long v48;
                v48 = v45 + 1l;
                v2.length = v48;
                bool v49;
                v49 = 0l <= v45;
                bool v52;
                if (v49){
                    long v50;
                    v50 = v2.length;
                    bool v51;
                    v51 = v45 < v50;
                    v52 = v51;
                } else {
                    v52 = false;
                }
                bool v53;
                v53 = v52 == false;
                if (v53){
                    assert("The set index needs to be in range for the static array list." && v52);
                } else {
                }
                v2.v[v45] = v44;
                v38 += 1l ;
            }
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v20 = v0.v.case3.v0;
            long v21;
            v21 = 0l;
            while (while_method_4(v21)){
                bool v23;
                v23 = 0l <= v21;
                bool v25;
                if (v23){
                    bool v24;
                    v24 = v21 < 4l;
                    v25 = v24;
                } else {
                    v25 = false;
                }
                bool v26;
                v26 = v25 == false;
                if (v26){
                    assert("The read index needs to be in range for the static array." && v25);
                } else {
                }
                unsigned char v27;
                v27 = v20.v[v21];
                long v28;
                v28 = v2.length;
                bool v29;
                v29 = v28 < 5l;
                bool v30;
                v30 = v29 == false;
                if (v30){
                    assert("The length has to be less than the maximum length of the array." && v29);
                } else {
                }
                long v31;
                v31 = v28 + 1l;
                v2.length = v31;
                bool v32;
                v32 = 0l <= v28;
                bool v35;
                if (v32){
                    long v33;
                    v33 = v2.length;
                    bool v34;
                    v34 = v28 < v33;
                    v35 = v34;
                } else {
                    v35 = false;
                }
                bool v36;
                v36 = v35 == false;
                if (v36){
                    assert("The set index needs to be in range for the static array list." && v35);
                } else {
                }
                v2.v[v28] = v27;
                v21 += 1l ;
            }
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v54;
    v54 = 0l;
    while (while_method_3(v54)){
        bool v56;
        v56 = 0l <= v54;
        bool v58;
        if (v56){
            bool v57;
            v57 = v54 < 3l;
            v58 = v57;
        } else {
            v58 = false;
        }
        bool v59;
        v59 = v58 == false;
        if (v59){
            assert("The read index needs to be in range for the static array." && v58);
        } else {
        }
        unsigned char v60;
        v60 = v1.v[v54];
        long v61;
        v61 = v2.length;
        bool v62;
        v62 = v61 < 5l;
        bool v63;
        v63 = v62 == false;
        if (v63){
            assert("The length has to be less than the maximum length of the array." && v62);
        } else {
        }
        long v64;
        v64 = v61 + 1l;
        v2.length = v64;
        bool v65;
        v65 = 0l <= v61;
        bool v68;
        if (v65){
            long v66;
            v66 = v2.length;
            bool v67;
            v67 = v61 < v66;
            v68 = v67;
        } else {
            v68 = false;
        }
        bool v69;
        v69 = v68 == false;
        if (v69){
            assert("The set index needs to be in range for the static array list." && v68);
        } else {
        }
        v2.v[v61] = v60;
        v54 += 1l ;
    }
    return v2;
}
__device__ Tuple13 draw_cards_38(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,2l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp20 = Tuple11(0l, v1);
    v3 = tmp20.v0; v4 = tmp20.v1;
    while (while_method_0(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple12 tmp21 = draw_card_35(v0, v4);
        v6 = tmp21.v0; v7 = tmp21.v1;
        bool v8;
        v8 = 0l <= v3;
        bool v10;
        if (v8){
            bool v9;
            v9 = v3 < 2l;
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
        v2.v[v3] = v6;
        v4 = v7;
        v3 += 1l ;
    }
    return Tuple13(v2, v4);
}
__device__ inline bool while_method_6(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ Tuple14 draw_cards_39(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,1l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp24 = Tuple11(0l, v1);
    v3 = tmp24.v0; v4 = tmp24.v1;
    while (while_method_6(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple12 tmp25 = draw_card_35(v0, v4);
        v6 = tmp25.v0; v7 = tmp25.v1;
        bool v8;
        v8 = 0l <= v3;
        bool v10;
        if (v8){
            bool v9;
            v9 = v3 < 1l;
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
        v2.v[v3] = v6;
        v4 = v7;
        v3 += 1l ;
    }
    return Tuple14(v2, v4);
}
__device__ static_array_list<unsigned char,5l,long> get_community_cards_40(US6 v0, static_array<unsigned char,1l> v1){
    static_array_list<unsigned char,5l,long> v2;
    v2.length = 0;
    switch (v0.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v3 = v0.v.case0.v0;
            long v4;
            v4 = 0l;
            while (while_method_3(v4)){
                bool v6;
                v6 = 0l <= v4;
                bool v8;
                if (v6){
                    bool v7;
                    v7 = v4 < 3l;
                    v8 = v7;
                } else {
                    v8 = false;
                }
                bool v9;
                v9 = v8 == false;
                if (v9){
                    assert("The read index needs to be in range for the static array." && v8);
                } else {
                }
                unsigned char v10;
                v10 = v3.v[v4];
                long v11;
                v11 = v2.length;
                bool v12;
                v12 = v11 < 5l;
                bool v13;
                v13 = v12 == false;
                if (v13){
                    assert("The length has to be less than the maximum length of the array." && v12);
                } else {
                }
                long v14;
                v14 = v11 + 1l;
                v2.length = v14;
                bool v15;
                v15 = 0l <= v11;
                bool v18;
                if (v15){
                    long v16;
                    v16 = v2.length;
                    bool v17;
                    v17 = v11 < v16;
                    v18 = v17;
                } else {
                    v18 = false;
                }
                bool v19;
                v19 = v18 == false;
                if (v19){
                    assert("The set index needs to be in range for the static array list." && v18);
                } else {
                }
                v2.v[v11] = v10;
                v4 += 1l ;
            }
            break;
        }
        case 1: { // Preflop
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v37 = v0.v.case2.v0;
            long v38;
            v38 = 0l;
            while (while_method_2(v38)){
                bool v40;
                v40 = 0l <= v38;
                bool v42;
                if (v40){
                    bool v41;
                    v41 = v38 < 5l;
                    v42 = v41;
                } else {
                    v42 = false;
                }
                bool v43;
                v43 = v42 == false;
                if (v43){
                    assert("The read index needs to be in range for the static array." && v42);
                } else {
                }
                unsigned char v44;
                v44 = v37.v[v38];
                long v45;
                v45 = v2.length;
                bool v46;
                v46 = v45 < 5l;
                bool v47;
                v47 = v46 == false;
                if (v47){
                    assert("The length has to be less than the maximum length of the array." && v46);
                } else {
                }
                long v48;
                v48 = v45 + 1l;
                v2.length = v48;
                bool v49;
                v49 = 0l <= v45;
                bool v52;
                if (v49){
                    long v50;
                    v50 = v2.length;
                    bool v51;
                    v51 = v45 < v50;
                    v52 = v51;
                } else {
                    v52 = false;
                }
                bool v53;
                v53 = v52 == false;
                if (v53){
                    assert("The set index needs to be in range for the static array list." && v52);
                } else {
                }
                v2.v[v45] = v44;
                v38 += 1l ;
            }
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v20 = v0.v.case3.v0;
            long v21;
            v21 = 0l;
            while (while_method_4(v21)){
                bool v23;
                v23 = 0l <= v21;
                bool v25;
                if (v23){
                    bool v24;
                    v24 = v21 < 4l;
                    v25 = v24;
                } else {
                    v25 = false;
                }
                bool v26;
                v26 = v25 == false;
                if (v26){
                    assert("The read index needs to be in range for the static array." && v25);
                } else {
                }
                unsigned char v27;
                v27 = v20.v[v21];
                long v28;
                v28 = v2.length;
                bool v29;
                v29 = v28 < 5l;
                bool v30;
                v30 = v29 == false;
                if (v30){
                    assert("The length has to be less than the maximum length of the array." && v29);
                } else {
                }
                long v31;
                v31 = v28 + 1l;
                v2.length = v31;
                bool v32;
                v32 = 0l <= v28;
                bool v35;
                if (v32){
                    long v33;
                    v33 = v2.length;
                    bool v34;
                    v34 = v28 < v33;
                    v35 = v34;
                } else {
                    v35 = false;
                }
                bool v36;
                v36 = v35 == false;
                if (v36){
                    assert("The set index needs to be in range for the static array list." && v35);
                } else {
                }
                v2.v[v28] = v27;
                v21 += 1l ;
            }
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v54;
    v54 = 0l;
    while (while_method_6(v54)){
        bool v56;
        v56 = 0l <= v54;
        bool v58;
        if (v56){
            bool v57;
            v57 = v54 < 1l;
            v58 = v57;
        } else {
            v58 = false;
        }
        bool v59;
        v59 = v58 == false;
        if (v59){
            assert("The read index needs to be in range for the static array." && v58);
        } else {
        }
        unsigned char v60;
        v60 = v1.v[v54];
        long v61;
        v61 = v2.length;
        bool v62;
        v62 = v61 < 5l;
        bool v63;
        v63 = v62 == false;
        if (v63){
            assert("The length has to be less than the maximum length of the array." && v62);
        } else {
        }
        long v64;
        v64 = v61 + 1l;
        v2.length = v64;
        bool v65;
        v65 = 0l <= v61;
        bool v68;
        if (v65){
            long v66;
            v66 = v2.length;
            bool v67;
            v67 = v61 < v66;
            v68 = v67;
        } else {
            v68 = false;
        }
        bool v69;
        v69 = v68 == false;
        if (v69){
            assert("The set index needs to be in range for the static array list." && v68);
        } else {
        }
        v2.v[v61] = v60;
        v54 += 1l ;
    }
    return v2;
}
__device__ inline bool while_method_7(long v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
__device__ inline bool while_method_8(static_array<float,8l> v0, long v1){
    bool v2;
    v2 = v1 < 8l;
    return v2;
}
__device__ inline bool while_method_9(long v0, long v1){
    bool v2;
    v2 = v1 > v0;
    return v2;
}
__device__ long loop_43(static_array<float,8l> v0, float v1, long v2){
    bool v3;
    v3 = v2 < 8l;
    if (v3){
        bool v4;
        v4 = 0l <= v2;
        bool v5;
        v5 = v4 && v3;
        bool v6;
        v6 = v5 == false;
        if (v6){
            assert("The read index needs to be in range for the static array." && v5);
        } else {
        }
        float v7;
        v7 = v0.v[v2];
        bool v8;
        v8 = v1 <= v7;
        if (v8){
            return v2;
        } else {
            long v9;
            v9 = v2 + 1l;
            return loop_43(v0, v1, v9);
        }
    } else {
        return 7l;
    }
}
__device__ long sample_discrete__42(static_array<float,8l> v0, curandStatePhilox4_32_10_t & v1){
    static_array<float,8l> v2;
    long v3;
    v3 = 0l;
    while (while_method_7(v3)){
        bool v5;
        v5 = 0l <= v3;
        bool v7;
        if (v5){
            bool v6;
            v6 = v3 < 8l;
            v7 = v6;
        } else {
            v7 = false;
        }
        bool v8;
        v8 = v7 == false;
        if (v8){
            assert("The read index needs to be in range for the static array." && v7);
        } else {
        }
        float v9;
        v9 = v0.v[v3];
        bool v11;
        if (v5){
            bool v10;
            v10 = v3 < 8l;
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
        v2.v[v3] = v9;
        v3 += 1l ;
    }
    long v13;
    v13 = 1l;
    while (while_method_8(v2, v13)){
        long v15;
        v15 = 8l;
        while (while_method_9(v13, v15)){
            v15 -= 1l ;
            long v17;
            v17 = v15 - v13;
            bool v18;
            v18 = 0l <= v17;
            bool v20;
            if (v18){
                bool v19;
                v19 = v17 < 8l;
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
            float v22;
            v22 = v2.v[v17];
            bool v23;
            v23 = 0l <= v15;
            bool v25;
            if (v23){
                bool v24;
                v24 = v15 < 8l;
                v25 = v24;
            } else {
                v25 = false;
            }
            bool v26;
            v26 = v25 == false;
            if (v26){
                assert("The read index needs to be in range for the static array." && v25);
            } else {
            }
            float v27;
            v27 = v2.v[v15];
            float v28;
            v28 = v22 + v27;
            bool v30;
            if (v23){
                bool v29;
                v29 = v15 < 8l;
                v30 = v29;
            } else {
                v30 = false;
            }
            bool v31;
            v31 = v30 == false;
            if (v31){
                assert("The read index needs to be in range for the static array." && v30);
            } else {
            }
            v2.v[v15] = v28;
        }
        long v32;
        v32 = v13 * 2l;
        v13 = v32;
    }
    float v33;
    v33 = v2.v[7l];
    float v34;
    v34 = curand_uniform(&v1);
    float v35;
    v35 = v34 * v33;
    long v36;
    v36 = 0l;
    return loop_43(v2, v35, v36);
}
__device__ US1 sample_discrete_41(static_array<Tuple15,8l> v0, curandStatePhilox4_32_10_t & v1){
    static_array<float,8l> v2;
    long v3;
    v3 = 0l;
    while (while_method_7(v3)){
        bool v5;
        v5 = 0l <= v3;
        bool v7;
        if (v5){
            bool v6;
            v6 = v3 < 8l;
            v7 = v6;
        } else {
            v7 = false;
        }
        bool v8;
        v8 = v7 == false;
        if (v8){
            assert("The read index needs to be in range for the static array." && v7);
        } else {
        }
        US1 v9; float v10;
        Tuple15 tmp29 = v0.v[v3];
        v9 = tmp29.v0; v10 = tmp29.v1;
        bool v12;
        if (v5){
            bool v11;
            v11 = v3 < 8l;
            v12 = v11;
        } else {
            v12 = false;
        }
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The read index needs to be in range for the static array." && v12);
        } else {
        }
        v2.v[v3] = v10;
        v3 += 1l ;
    }
    long v14;
    v14 = sample_discrete__42(v2, v1);
    bool v15;
    v15 = 0l <= v14;
    bool v17;
    if (v15){
        bool v16;
        v16 = v14 < 8l;
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
    US1 v19; float v20;
    Tuple15 tmp30 = v0.v[v14];
    v19 = tmp30.v0; v20 = tmp30.v1;
    return v19;
}
__device__ inline bool while_method_10(long v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
__device__ inline bool while_method_11(static_array<unsigned char,7l> v0, bool v1, long v2){
    bool v3;
    v3 = v2 < 7l;
    return v3;
}
__device__ inline bool while_method_12(static_array<unsigned char,7l> v0, long v1){
    bool v2;
    v2 = v1 < 7l;
    return v2;
}
__device__ inline bool while_method_13(long v0, long v1, long v2, long v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
__device__ US8 US8_0() { // Eq
    US8 x;
    x.tag = 0;
    return x;
}
__device__ US8 US8_1() { // Gt
    US8 x;
    x.tag = 1;
    return x;
}
__device__ US8 US8_2() { // Lt
    US8 x;
    x.tag = 2;
    return x;
}
__device__ US9 US9_0() { // None
    US9 x;
    x.tag = 0;
    return x;
}
__device__ US9 US9_1(static_array<unsigned char,5l> v0) { // Some
    US9 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US10 US10_0() { // None
    US10 x;
    x.tag = 0;
    return x;
}
__device__ US10 US10_1(static_array<unsigned char,4l> v0, static_array<unsigned char,3l> v1) { // Some
    US10 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US11 US11_0() { // None
    US11 x;
    x.tag = 0;
    return x;
}
__device__ US11 US11_1(static_array<unsigned char,3l> v0, static_array<unsigned char,4l> v1) { // Some
    US11 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US12 US12_0() { // None
    US12 x;
    x.tag = 0;
    return x;
}
__device__ US12 US12_1(static_array<unsigned char,2l> v0, static_array<unsigned char,2l> v1) { // Some
    US12 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US13 US13_0() { // None
    US13 x;
    x.tag = 0;
    return x;
}
__device__ US13 US13_1(static_array<unsigned char,2l> v0, static_array<unsigned char,5l> v1) { // Some
    US13 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US14 US14_0() { // None
    US14 x;
    x.tag = 0;
    return x;
}
__device__ US14 US14_1(static_array<unsigned char,2l> v0, static_array<unsigned char,3l> v1) { // Some
    US14 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ Tuple0 score_44(static_array<unsigned char,7l> v0){
    static_array<unsigned char,7l> v1;
    long v2;
    v2 = 0l;
    while (while_method_10(v2)){
        bool v4;
        v4 = 0l <= v2;
        bool v6;
        if (v4){
            bool v5;
            v5 = v2 < 7l;
            v6 = v5;
        } else {
            v6 = false;
        }
        bool v7;
        v7 = v6 == false;
        if (v7){
            assert("The read index needs to be in range for the static array." && v6);
        } else {
        }
        unsigned char v8;
        v8 = v0.v[v2];
        bool v10;
        if (v4){
            bool v9;
            v9 = v2 < 7l;
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
        v1.v[v2] = v8;
        v2 += 1l ;
    }
    static_array<unsigned char,7l> v12;
    bool v13; long v14;
    Tuple16 tmp35 = Tuple16(true, 1l);
    v13 = tmp35.v0; v14 = tmp35.v1;
    while (while_method_11(v1, v13, v14)){
        long v16;
        v16 = 0l;
        while (while_method_12(v1, v16)){
            long v18;
            v18 = v16 + v14;
            bool v19;
            v19 = v18 < 7l;
            long v20;
            if (v19){
                v20 = v18;
            } else {
                v20 = 7l;
            }
            long v21;
            v21 = v14 * 2l;
            long v22;
            v22 = v16 + v21;
            bool v23;
            v23 = v22 < 7l;
            long v24;
            if (v23){
                v24 = v22;
            } else {
                v24 = 7l;
            }
            long v25; long v26; long v27;
            Tuple17 tmp36 = Tuple17(v16, v20, v16);
            v25 = tmp36.v0; v26 = tmp36.v1; v27 = tmp36.v2;
            while (while_method_13(v24, v25, v26, v27)){
                bool v29;
                v29 = v25 < v20;
                bool v31;
                if (v29){
                    bool v30;
                    v30 = v26 < v24;
                    v31 = v30;
                } else {
                    v31 = false;
                }
                unsigned char v111; long v112; long v113;
                if (v31){
                    unsigned char v42;
                    if (v13){
                        bool v32;
                        v32 = 0l <= v25;
                        bool v34;
                        if (v32){
                            bool v33;
                            v33 = v25 < 7l;
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
                        unsigned char v36;
                        v36 = v1.v[v25];
                        v42 = v36;
                    } else {
                        bool v37;
                        v37 = 0l <= v25;
                        bool v39;
                        if (v37){
                            bool v38;
                            v38 = v25 < 7l;
                            v39 = v38;
                        } else {
                            v39 = false;
                        }
                        bool v40;
                        v40 = v39 == false;
                        if (v40){
                            assert("The read index needs to be in range for the static array." && v39);
                        } else {
                        }
                        unsigned char v41;
                        v41 = v12.v[v25];
                        v42 = v41;
                    }
                    unsigned char v53;
                    if (v13){
                        bool v43;
                        v43 = 0l <= v26;
                        bool v45;
                        if (v43){
                            bool v44;
                            v44 = v26 < 7l;
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
                        unsigned char v47;
                        v47 = v1.v[v26];
                        v53 = v47;
                    } else {
                        bool v48;
                        v48 = 0l <= v26;
                        bool v50;
                        if (v48){
                            bool v49;
                            v49 = v26 < 7l;
                            v50 = v49;
                        } else {
                            v50 = false;
                        }
                        bool v51;
                        v51 = v50 == false;
                        if (v51){
                            assert("The read index needs to be in range for the static array." && v50);
                        } else {
                        }
                        unsigned char v52;
                        v52 = v12.v[v26];
                        v53 = v52;
                    }
                    unsigned char v54;
                    v54 = v53 >> 2l;
                    unsigned char v55;
                    v55 = v54 & 15u;
                    unsigned char v56;
                    v56 = v42 >> 2l;
                    unsigned char v57;
                    v57 = v56 & 15u;
                    bool v58;
                    v58 = v55 < v57;
                    US8 v64;
                    if (v58){
                        v64 = US8_2();
                    } else {
                        bool v60;
                        v60 = v55 > v57;
                        if (v60){
                            v64 = US8_1();
                        } else {
                            v64 = US8_0();
                        }
                    }
                    US8 v78;
                    switch (v64.tag) {
                        case 0: { // Eq
                            unsigned char v65;
                            v65 = v42 << 2l;
                            unsigned char v66;
                            v66 = v65 - 1u;
                            unsigned char v67;
                            v67 = v42 & v66;
                            unsigned char v68;
                            v68 = v53 << 2l;
                            unsigned char v69;
                            v69 = v68 - 1u;
                            unsigned char v70;
                            v70 = v53 & v69;
                            bool v71;
                            v71 = v67 < v70;
                            if (v71){
                                v78 = US8_2();
                            } else {
                                bool v73;
                                v73 = v67 > v70;
                                if (v73){
                                    v78 = US8_1();
                                } else {
                                    v78 = US8_0();
                                }
                            }
                            break;
                        }
                        default: {
                            v78 = v64;
                        }
                    }
                    switch (v78.tag) {
                        case 1: { // Gt
                            long v79;
                            v79 = v26 + 1l;
                            v111 = v53; v112 = v25; v113 = v79;
                            break;
                        }
                        default: {
                            long v80;
                            v80 = v25 + 1l;
                            v111 = v42; v112 = v80; v113 = v26;
                        }
                    }
                } else {
                    if (v29){
                        unsigned char v94;
                        if (v13){
                            bool v84;
                            v84 = 0l <= v25;
                            bool v86;
                            if (v84){
                                bool v85;
                                v85 = v25 < 7l;
                                v86 = v85;
                            } else {
                                v86 = false;
                            }
                            bool v87;
                            v87 = v86 == false;
                            if (v87){
                                assert("The read index needs to be in range for the static array." && v86);
                            } else {
                            }
                            unsigned char v88;
                            v88 = v1.v[v25];
                            v94 = v88;
                        } else {
                            bool v89;
                            v89 = 0l <= v25;
                            bool v91;
                            if (v89){
                                bool v90;
                                v90 = v25 < 7l;
                                v91 = v90;
                            } else {
                                v91 = false;
                            }
                            bool v92;
                            v92 = v91 == false;
                            if (v92){
                                assert("The read index needs to be in range for the static array." && v91);
                            } else {
                            }
                            unsigned char v93;
                            v93 = v12.v[v25];
                            v94 = v93;
                        }
                        long v95;
                        v95 = v25 + 1l;
                        v111 = v94; v112 = v95; v113 = v26;
                    } else {
                        unsigned char v106;
                        if (v13){
                            bool v96;
                            v96 = 0l <= v26;
                            bool v98;
                            if (v96){
                                bool v97;
                                v97 = v26 < 7l;
                                v98 = v97;
                            } else {
                                v98 = false;
                            }
                            bool v99;
                            v99 = v98 == false;
                            if (v99){
                                assert("The read index needs to be in range for the static array." && v98);
                            } else {
                            }
                            unsigned char v100;
                            v100 = v1.v[v26];
                            v106 = v100;
                        } else {
                            bool v101;
                            v101 = 0l <= v26;
                            bool v103;
                            if (v101){
                                bool v102;
                                v102 = v26 < 7l;
                                v103 = v102;
                            } else {
                                v103 = false;
                            }
                            bool v104;
                            v104 = v103 == false;
                            if (v104){
                                assert("The read index needs to be in range for the static array." && v103);
                            } else {
                            }
                            unsigned char v105;
                            v105 = v12.v[v26];
                            v106 = v105;
                        }
                        long v107;
                        v107 = v26 + 1l;
                        v111 = v106; v112 = v25; v113 = v107;
                    }
                }
                if (v13){
                    bool v114;
                    v114 = 0l <= v27;
                    bool v116;
                    if (v114){
                        bool v115;
                        v115 = v27 < 7l;
                        v116 = v115;
                    } else {
                        v116 = false;
                    }
                    bool v117;
                    v117 = v116 == false;
                    if (v117){
                        assert("The read index needs to be in range for the static array." && v116);
                    } else {
                    }
                    v12.v[v27] = v111;
                } else {
                    bool v118;
                    v118 = 0l <= v27;
                    bool v120;
                    if (v118){
                        bool v119;
                        v119 = v27 < 7l;
                        v120 = v119;
                    } else {
                        v120 = false;
                    }
                    bool v121;
                    v121 = v120 == false;
                    if (v121){
                        assert("The read index needs to be in range for the static array." && v120);
                    } else {
                    }
                    v1.v[v27] = v111;
                }
                long v122;
                v122 = v27 + 1l;
                v25 = v112;
                v26 = v113;
                v27 = v122;
            }
            v16 = v22;
        }
        bool v123;
        v123 = v13 == false;
        long v124;
        v124 = v14 * 2l;
        v13 = v123;
        v14 = v124;
    }
    bool v125;
    v125 = v13 == false;
    static_array<unsigned char,7l> v126;
    if (v125){
        v126 = v12;
    } else {
        v126 = v1;
    }
    static_array<unsigned char,5l> v127;
    long v128; long v129; unsigned char v130;
    Tuple18 tmp37 = Tuple18(0l, 0l, 12u);
    v128 = tmp37.v0; v129 = tmp37.v1; v130 = tmp37.v2;
    while (while_method_10(v128)){
        bool v132;
        v132 = 0l <= v128;
        bool v134;
        if (v132){
            bool v133;
            v133 = v128 < 7l;
            v134 = v133;
        } else {
            v134 = false;
        }
        bool v135;
        v135 = v134 == false;
        if (v135){
            assert("The read index needs to be in range for the static array." && v134);
        } else {
        }
        unsigned char v136;
        v136 = v126.v[v128];
        bool v137;
        v137 = v129 < 5l;
        long v156; unsigned char v157;
        if (v137){
            unsigned char v138;
            v138 = v136 << 2l;
            unsigned char v139;
            v139 = v138 - 1u;
            unsigned char v140;
            v140 = v136 & v139;
            bool v141;
            v141 = 0u == v140;
            if (v141){
                unsigned char v142;
                v142 = v136 >> 2l;
                unsigned char v143;
                v143 = v142 & 15u;
                bool v144;
                v144 = v130 == v143;
                long v145;
                if (v144){
                    v145 = v129;
                } else {
                    v145 = 0l;
                }
                bool v146;
                v146 = 0l <= v145;
                bool v148;
                if (v146){
                    bool v147;
                    v147 = v145 < 5l;
                    v148 = v147;
                } else {
                    v148 = false;
                }
                bool v149;
                v149 = v148 == false;
                if (v149){
                    assert("The read index needs to be in range for the static array." && v148);
                } else {
                }
                v127.v[v145] = v136;
                long v150;
                v150 = v145 + 1l;
                unsigned char v151;
                v151 = v143 - 1u;
                v156 = v150; v157 = v151;
            } else {
                v156 = v129; v157 = v130;
            }
        } else {
            break;
        }
        v129 = v156;
        v130 = v157;
        v128 += 1l ;
    }
    bool v158;
    v158 = v129 == 4l;
    bool v205;
    if (v158){
        unsigned char v159;
        v159 = v130 + 1u;
        bool v160;
        v160 = v159 == 0u;
        if (v160){
            unsigned char v161;
            v161 = v126.v[0l];
            unsigned char v162;
            v162 = v161 << 2l;
            unsigned char v163;
            v163 = v162 - 1u;
            unsigned char v164;
            v164 = v161 & v163;
            bool v165;
            v165 = 0u == v164;
            bool v170;
            if (v165){
                unsigned char v166;
                v166 = v161 >> 2l;
                unsigned char v167;
                v167 = v166 & 15u;
                bool v168;
                v168 = v167 == 12u;
                if (v168){
                    v127.v[4l] = v161;
                    v170 = true;
                } else {
                    v170 = false;
                }
            } else {
                v170 = false;
            }
            if (v170){
                v205 = true;
            } else {
                unsigned char v171;
                v171 = v126.v[1l];
                unsigned char v172;
                v172 = v171 << 2l;
                unsigned char v173;
                v173 = v172 - 1u;
                unsigned char v174;
                v174 = v171 & v173;
                bool v175;
                v175 = 0u == v174;
                bool v180;
                if (v175){
                    unsigned char v176;
                    v176 = v171 >> 2l;
                    unsigned char v177;
                    v177 = v176 & 15u;
                    bool v178;
                    v178 = v177 == 12u;
                    if (v178){
                        v127.v[4l] = v171;
                        v180 = true;
                    } else {
                        v180 = false;
                    }
                } else {
                    v180 = false;
                }
                if (v180){
                    v205 = true;
                } else {
                    unsigned char v181;
                    v181 = v126.v[2l];
                    unsigned char v182;
                    v182 = v181 << 2l;
                    unsigned char v183;
                    v183 = v182 - 1u;
                    unsigned char v184;
                    v184 = v181 & v183;
                    bool v185;
                    v185 = 0u == v184;
                    bool v190;
                    if (v185){
                        unsigned char v186;
                        v186 = v181 >> 2l;
                        unsigned char v187;
                        v187 = v186 & 15u;
                        bool v188;
                        v188 = v187 == 12u;
                        if (v188){
                            v127.v[4l] = v181;
                            v190 = true;
                        } else {
                            v190 = false;
                        }
                    } else {
                        v190 = false;
                    }
                    if (v190){
                        v205 = true;
                    } else {
                        unsigned char v191;
                        v191 = v126.v[3l];
                        unsigned char v192;
                        v192 = v191 << 2l;
                        unsigned char v193;
                        v193 = v192 - 1u;
                        unsigned char v194;
                        v194 = v191 & v193;
                        bool v195;
                        v195 = 0u == v194;
                        if (v195){
                            unsigned char v196;
                            v196 = v191 >> 2l;
                            unsigned char v197;
                            v197 = v196 & 15u;
                            bool v198;
                            v198 = v197 == 12u;
                            if (v198){
                                v127.v[4l] = v191;
                                v205 = true;
                            } else {
                                v205 = false;
                            }
                        } else {
                            v205 = false;
                        }
                    }
                }
            }
        } else {
            v205 = false;
        }
    } else {
        v205 = false;
    }
    US9 v211;
    if (v205){
        v211 = US9_1(v127);
    } else {
        bool v207;
        v207 = v129 == 5l;
        if (v207){
            v211 = US9_1(v127);
        } else {
            v211 = US9_0();
        }
    }
    static_array<unsigned char,5l> v212;
    long v213; long v214; unsigned char v215;
    Tuple18 tmp38 = Tuple18(0l, 0l, 12u);
    v213 = tmp38.v0; v214 = tmp38.v1; v215 = tmp38.v2;
    while (while_method_10(v213)){
        bool v217;
        v217 = 0l <= v213;
        bool v219;
        if (v217){
            bool v218;
            v218 = v213 < 7l;
            v219 = v218;
        } else {
            v219 = false;
        }
        bool v220;
        v220 = v219 == false;
        if (v220){
            assert("The read index needs to be in range for the static array." && v219);
        } else {
        }
        unsigned char v221;
        v221 = v126.v[v213];
        bool v222;
        v222 = v214 < 5l;
        long v241; unsigned char v242;
        if (v222){
            unsigned char v223;
            v223 = v221 << 2l;
            unsigned char v224;
            v224 = v223 - 1u;
            unsigned char v225;
            v225 = v221 & v224;
            bool v226;
            v226 = 1u == v225;
            if (v226){
                unsigned char v227;
                v227 = v221 >> 2l;
                unsigned char v228;
                v228 = v227 & 15u;
                bool v229;
                v229 = v215 == v228;
                long v230;
                if (v229){
                    v230 = v214;
                } else {
                    v230 = 0l;
                }
                bool v231;
                v231 = 0l <= v230;
                bool v233;
                if (v231){
                    bool v232;
                    v232 = v230 < 5l;
                    v233 = v232;
                } else {
                    v233 = false;
                }
                bool v234;
                v234 = v233 == false;
                if (v234){
                    assert("The read index needs to be in range for the static array." && v233);
                } else {
                }
                v212.v[v230] = v221;
                long v235;
                v235 = v230 + 1l;
                unsigned char v236;
                v236 = v228 - 1u;
                v241 = v235; v242 = v236;
            } else {
                v241 = v214; v242 = v215;
            }
        } else {
            break;
        }
        v214 = v241;
        v215 = v242;
        v213 += 1l ;
    }
    bool v243;
    v243 = v214 == 4l;
    bool v290;
    if (v243){
        unsigned char v244;
        v244 = v215 + 1u;
        bool v245;
        v245 = v244 == 0u;
        if (v245){
            unsigned char v246;
            v246 = v126.v[0l];
            unsigned char v247;
            v247 = v246 << 2l;
            unsigned char v248;
            v248 = v247 - 1u;
            unsigned char v249;
            v249 = v246 & v248;
            bool v250;
            v250 = 1u == v249;
            bool v255;
            if (v250){
                unsigned char v251;
                v251 = v246 >> 2l;
                unsigned char v252;
                v252 = v251 & 15u;
                bool v253;
                v253 = v252 == 12u;
                if (v253){
                    v212.v[4l] = v246;
                    v255 = true;
                } else {
                    v255 = false;
                }
            } else {
                v255 = false;
            }
            if (v255){
                v290 = true;
            } else {
                unsigned char v256;
                v256 = v126.v[1l];
                unsigned char v257;
                v257 = v256 << 2l;
                unsigned char v258;
                v258 = v257 - 1u;
                unsigned char v259;
                v259 = v256 & v258;
                bool v260;
                v260 = 1u == v259;
                bool v265;
                if (v260){
                    unsigned char v261;
                    v261 = v256 >> 2l;
                    unsigned char v262;
                    v262 = v261 & 15u;
                    bool v263;
                    v263 = v262 == 12u;
                    if (v263){
                        v212.v[4l] = v256;
                        v265 = true;
                    } else {
                        v265 = false;
                    }
                } else {
                    v265 = false;
                }
                if (v265){
                    v290 = true;
                } else {
                    unsigned char v266;
                    v266 = v126.v[2l];
                    unsigned char v267;
                    v267 = v266 << 2l;
                    unsigned char v268;
                    v268 = v267 - 1u;
                    unsigned char v269;
                    v269 = v266 & v268;
                    bool v270;
                    v270 = 1u == v269;
                    bool v275;
                    if (v270){
                        unsigned char v271;
                        v271 = v266 >> 2l;
                        unsigned char v272;
                        v272 = v271 & 15u;
                        bool v273;
                        v273 = v272 == 12u;
                        if (v273){
                            v212.v[4l] = v266;
                            v275 = true;
                        } else {
                            v275 = false;
                        }
                    } else {
                        v275 = false;
                    }
                    if (v275){
                        v290 = true;
                    } else {
                        unsigned char v276;
                        v276 = v126.v[3l];
                        unsigned char v277;
                        v277 = v276 << 2l;
                        unsigned char v278;
                        v278 = v277 - 1u;
                        unsigned char v279;
                        v279 = v276 & v278;
                        bool v280;
                        v280 = 1u == v279;
                        if (v280){
                            unsigned char v281;
                            v281 = v276 >> 2l;
                            unsigned char v282;
                            v282 = v281 & 15u;
                            bool v283;
                            v283 = v282 == 12u;
                            if (v283){
                                v212.v[4l] = v276;
                                v290 = true;
                            } else {
                                v290 = false;
                            }
                        } else {
                            v290 = false;
                        }
                    }
                }
            }
        } else {
            v290 = false;
        }
    } else {
        v290 = false;
    }
    US9 v296;
    if (v290){
        v296 = US9_1(v212);
    } else {
        bool v292;
        v292 = v214 == 5l;
        if (v292){
            v296 = US9_1(v212);
        } else {
            v296 = US9_0();
        }
    }
    US9 v331;
    switch (v211.tag) {
        case 0: { // None
            v331 = v296;
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v297 = v211.v.case1.v0;
            switch (v296.tag) {
                case 0: { // None
                    v331 = v211;
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v298 = v296.v.case1.v0;
                    US8 v299;
                    v299 = US8_0();
                    long v300; US8 v301;
                    Tuple19 tmp39 = Tuple19(0l, v299);
                    v300 = tmp39.v0; v301 = tmp39.v1;
                    while (while_method_2(v300)){
                        bool v303;
                        v303 = 0l <= v300;
                        bool v305;
                        if (v303){
                            bool v304;
                            v304 = v300 < 5l;
                            v305 = v304;
                        } else {
                            v305 = false;
                        }
                        bool v306;
                        v306 = v305 == false;
                        if (v306){
                            assert("The read index needs to be in range for the static array." && v305);
                        } else {
                        }
                        unsigned char v307;
                        v307 = v297.v[v300];
                        bool v309;
                        if (v303){
                            bool v308;
                            v308 = v300 < 5l;
                            v309 = v308;
                        } else {
                            v309 = false;
                        }
                        bool v310;
                        v310 = v309 == false;
                        if (v310){
                            assert("The read index needs to be in range for the static array." && v309);
                        } else {
                        }
                        unsigned char v311;
                        v311 = v298.v[v300];
                        US8 v324;
                        switch (v301.tag) {
                            case 0: { // Eq
                                unsigned char v312;
                                v312 = v307 >> 2l;
                                unsigned char v313;
                                v313 = v312 & 15u;
                                unsigned char v314;
                                v314 = v311 >> 2l;
                                unsigned char v315;
                                v315 = v314 & 15u;
                                bool v316;
                                v316 = v313 < v315;
                                if (v316){
                                    v324 = US8_2();
                                } else {
                                    bool v318;
                                    v318 = v313 > v315;
                                    if (v318){
                                        v324 = US8_1();
                                    } else {
                                        v324 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v301 = v324;
                        v300 += 1l ;
                    }
                    bool v325;
                    switch (v301.tag) {
                        case 1: { // Gt
                            v325 = true;
                            break;
                        }
                        default: {
                            v325 = false;
                        }
                    }
                    static_array<unsigned char,5l> v326;
                    if (v325){
                        v326 = v297;
                    } else {
                        v326 = v298;
                    }
                    v331 = US9_1(v326);
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
    static_array<unsigned char,5l> v332;
    long v333; long v334; unsigned char v335;
    Tuple18 tmp40 = Tuple18(0l, 0l, 12u);
    v333 = tmp40.v0; v334 = tmp40.v1; v335 = tmp40.v2;
    while (while_method_10(v333)){
        bool v337;
        v337 = 0l <= v333;
        bool v339;
        if (v337){
            bool v338;
            v338 = v333 < 7l;
            v339 = v338;
        } else {
            v339 = false;
        }
        bool v340;
        v340 = v339 == false;
        if (v340){
            assert("The read index needs to be in range for the static array." && v339);
        } else {
        }
        unsigned char v341;
        v341 = v126.v[v333];
        bool v342;
        v342 = v334 < 5l;
        long v361; unsigned char v362;
        if (v342){
            unsigned char v343;
            v343 = v341 << 2l;
            unsigned char v344;
            v344 = v343 - 1u;
            unsigned char v345;
            v345 = v341 & v344;
            bool v346;
            v346 = 2u == v345;
            if (v346){
                unsigned char v347;
                v347 = v341 >> 2l;
                unsigned char v348;
                v348 = v347 & 15u;
                bool v349;
                v349 = v335 == v348;
                long v350;
                if (v349){
                    v350 = v334;
                } else {
                    v350 = 0l;
                }
                bool v351;
                v351 = 0l <= v350;
                bool v353;
                if (v351){
                    bool v352;
                    v352 = v350 < 5l;
                    v353 = v352;
                } else {
                    v353 = false;
                }
                bool v354;
                v354 = v353 == false;
                if (v354){
                    assert("The read index needs to be in range for the static array." && v353);
                } else {
                }
                v332.v[v350] = v341;
                long v355;
                v355 = v350 + 1l;
                unsigned char v356;
                v356 = v348 - 1u;
                v361 = v355; v362 = v356;
            } else {
                v361 = v334; v362 = v335;
            }
        } else {
            break;
        }
        v334 = v361;
        v335 = v362;
        v333 += 1l ;
    }
    bool v363;
    v363 = v334 == 4l;
    bool v410;
    if (v363){
        unsigned char v364;
        v364 = v335 + 1u;
        bool v365;
        v365 = v364 == 0u;
        if (v365){
            unsigned char v366;
            v366 = v126.v[0l];
            unsigned char v367;
            v367 = v366 << 2l;
            unsigned char v368;
            v368 = v367 - 1u;
            unsigned char v369;
            v369 = v366 & v368;
            bool v370;
            v370 = 2u == v369;
            bool v375;
            if (v370){
                unsigned char v371;
                v371 = v366 >> 2l;
                unsigned char v372;
                v372 = v371 & 15u;
                bool v373;
                v373 = v372 == 12u;
                if (v373){
                    v332.v[4l] = v366;
                    v375 = true;
                } else {
                    v375 = false;
                }
            } else {
                v375 = false;
            }
            if (v375){
                v410 = true;
            } else {
                unsigned char v376;
                v376 = v126.v[1l];
                unsigned char v377;
                v377 = v376 << 2l;
                unsigned char v378;
                v378 = v377 - 1u;
                unsigned char v379;
                v379 = v376 & v378;
                bool v380;
                v380 = 2u == v379;
                bool v385;
                if (v380){
                    unsigned char v381;
                    v381 = v376 >> 2l;
                    unsigned char v382;
                    v382 = v381 & 15u;
                    bool v383;
                    v383 = v382 == 12u;
                    if (v383){
                        v332.v[4l] = v376;
                        v385 = true;
                    } else {
                        v385 = false;
                    }
                } else {
                    v385 = false;
                }
                if (v385){
                    v410 = true;
                } else {
                    unsigned char v386;
                    v386 = v126.v[2l];
                    unsigned char v387;
                    v387 = v386 << 2l;
                    unsigned char v388;
                    v388 = v387 - 1u;
                    unsigned char v389;
                    v389 = v386 & v388;
                    bool v390;
                    v390 = 2u == v389;
                    bool v395;
                    if (v390){
                        unsigned char v391;
                        v391 = v386 >> 2l;
                        unsigned char v392;
                        v392 = v391 & 15u;
                        bool v393;
                        v393 = v392 == 12u;
                        if (v393){
                            v332.v[4l] = v386;
                            v395 = true;
                        } else {
                            v395 = false;
                        }
                    } else {
                        v395 = false;
                    }
                    if (v395){
                        v410 = true;
                    } else {
                        unsigned char v396;
                        v396 = v126.v[3l];
                        unsigned char v397;
                        v397 = v396 << 2l;
                        unsigned char v398;
                        v398 = v397 - 1u;
                        unsigned char v399;
                        v399 = v396 & v398;
                        bool v400;
                        v400 = 2u == v399;
                        if (v400){
                            unsigned char v401;
                            v401 = v396 >> 2l;
                            unsigned char v402;
                            v402 = v401 & 15u;
                            bool v403;
                            v403 = v402 == 12u;
                            if (v403){
                                v332.v[4l] = v396;
                                v410 = true;
                            } else {
                                v410 = false;
                            }
                        } else {
                            v410 = false;
                        }
                    }
                }
            }
        } else {
            v410 = false;
        }
    } else {
        v410 = false;
    }
    US9 v416;
    if (v410){
        v416 = US9_1(v332);
    } else {
        bool v412;
        v412 = v334 == 5l;
        if (v412){
            v416 = US9_1(v332);
        } else {
            v416 = US9_0();
        }
    }
    US9 v451;
    switch (v331.tag) {
        case 0: { // None
            v451 = v416;
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v417 = v331.v.case1.v0;
            switch (v416.tag) {
                case 0: { // None
                    v451 = v331;
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v418 = v416.v.case1.v0;
                    US8 v419;
                    v419 = US8_0();
                    long v420; US8 v421;
                    Tuple19 tmp41 = Tuple19(0l, v419);
                    v420 = tmp41.v0; v421 = tmp41.v1;
                    while (while_method_2(v420)){
                        bool v423;
                        v423 = 0l <= v420;
                        bool v425;
                        if (v423){
                            bool v424;
                            v424 = v420 < 5l;
                            v425 = v424;
                        } else {
                            v425 = false;
                        }
                        bool v426;
                        v426 = v425 == false;
                        if (v426){
                            assert("The read index needs to be in range for the static array." && v425);
                        } else {
                        }
                        unsigned char v427;
                        v427 = v417.v[v420];
                        bool v429;
                        if (v423){
                            bool v428;
                            v428 = v420 < 5l;
                            v429 = v428;
                        } else {
                            v429 = false;
                        }
                        bool v430;
                        v430 = v429 == false;
                        if (v430){
                            assert("The read index needs to be in range for the static array." && v429);
                        } else {
                        }
                        unsigned char v431;
                        v431 = v418.v[v420];
                        US8 v444;
                        switch (v421.tag) {
                            case 0: { // Eq
                                unsigned char v432;
                                v432 = v427 >> 2l;
                                unsigned char v433;
                                v433 = v432 & 15u;
                                unsigned char v434;
                                v434 = v431 >> 2l;
                                unsigned char v435;
                                v435 = v434 & 15u;
                                bool v436;
                                v436 = v433 < v435;
                                if (v436){
                                    v444 = US8_2();
                                } else {
                                    bool v438;
                                    v438 = v433 > v435;
                                    if (v438){
                                        v444 = US8_1();
                                    } else {
                                        v444 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v421 = v444;
                        v420 += 1l ;
                    }
                    bool v445;
                    switch (v421.tag) {
                        case 1: { // Gt
                            v445 = true;
                            break;
                        }
                        default: {
                            v445 = false;
                        }
                    }
                    static_array<unsigned char,5l> v446;
                    if (v445){
                        v446 = v417;
                    } else {
                        v446 = v418;
                    }
                    v451 = US9_1(v446);
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
    static_array<unsigned char,5l> v452;
    long v453; long v454; unsigned char v455;
    Tuple18 tmp42 = Tuple18(0l, 0l, 12u);
    v453 = tmp42.v0; v454 = tmp42.v1; v455 = tmp42.v2;
    while (while_method_10(v453)){
        bool v457;
        v457 = 0l <= v453;
        bool v459;
        if (v457){
            bool v458;
            v458 = v453 < 7l;
            v459 = v458;
        } else {
            v459 = false;
        }
        bool v460;
        v460 = v459 == false;
        if (v460){
            assert("The read index needs to be in range for the static array." && v459);
        } else {
        }
        unsigned char v461;
        v461 = v126.v[v453];
        bool v462;
        v462 = v454 < 5l;
        long v481; unsigned char v482;
        if (v462){
            unsigned char v463;
            v463 = v461 << 2l;
            unsigned char v464;
            v464 = v463 - 1u;
            unsigned char v465;
            v465 = v461 & v464;
            bool v466;
            v466 = 3u == v465;
            if (v466){
                unsigned char v467;
                v467 = v461 >> 2l;
                unsigned char v468;
                v468 = v467 & 15u;
                bool v469;
                v469 = v455 == v468;
                long v470;
                if (v469){
                    v470 = v454;
                } else {
                    v470 = 0l;
                }
                bool v471;
                v471 = 0l <= v470;
                bool v473;
                if (v471){
                    bool v472;
                    v472 = v470 < 5l;
                    v473 = v472;
                } else {
                    v473 = false;
                }
                bool v474;
                v474 = v473 == false;
                if (v474){
                    assert("The read index needs to be in range for the static array." && v473);
                } else {
                }
                v452.v[v470] = v461;
                long v475;
                v475 = v470 + 1l;
                unsigned char v476;
                v476 = v468 - 1u;
                v481 = v475; v482 = v476;
            } else {
                v481 = v454; v482 = v455;
            }
        } else {
            break;
        }
        v454 = v481;
        v455 = v482;
        v453 += 1l ;
    }
    bool v483;
    v483 = v454 == 4l;
    bool v530;
    if (v483){
        unsigned char v484;
        v484 = v455 + 1u;
        bool v485;
        v485 = v484 == 0u;
        if (v485){
            unsigned char v486;
            v486 = v126.v[0l];
            unsigned char v487;
            v487 = v486 << 2l;
            unsigned char v488;
            v488 = v487 - 1u;
            unsigned char v489;
            v489 = v486 & v488;
            bool v490;
            v490 = 3u == v489;
            bool v495;
            if (v490){
                unsigned char v491;
                v491 = v486 >> 2l;
                unsigned char v492;
                v492 = v491 & 15u;
                bool v493;
                v493 = v492 == 12u;
                if (v493){
                    v452.v[4l] = v486;
                    v495 = true;
                } else {
                    v495 = false;
                }
            } else {
                v495 = false;
            }
            if (v495){
                v530 = true;
            } else {
                unsigned char v496;
                v496 = v126.v[1l];
                unsigned char v497;
                v497 = v496 << 2l;
                unsigned char v498;
                v498 = v497 - 1u;
                unsigned char v499;
                v499 = v496 & v498;
                bool v500;
                v500 = 3u == v499;
                bool v505;
                if (v500){
                    unsigned char v501;
                    v501 = v496 >> 2l;
                    unsigned char v502;
                    v502 = v501 & 15u;
                    bool v503;
                    v503 = v502 == 12u;
                    if (v503){
                        v452.v[4l] = v496;
                        v505 = true;
                    } else {
                        v505 = false;
                    }
                } else {
                    v505 = false;
                }
                if (v505){
                    v530 = true;
                } else {
                    unsigned char v506;
                    v506 = v126.v[2l];
                    unsigned char v507;
                    v507 = v506 << 2l;
                    unsigned char v508;
                    v508 = v507 - 1u;
                    unsigned char v509;
                    v509 = v506 & v508;
                    bool v510;
                    v510 = 3u == v509;
                    bool v515;
                    if (v510){
                        unsigned char v511;
                        v511 = v506 >> 2l;
                        unsigned char v512;
                        v512 = v511 & 15u;
                        bool v513;
                        v513 = v512 == 12u;
                        if (v513){
                            v452.v[4l] = v506;
                            v515 = true;
                        } else {
                            v515 = false;
                        }
                    } else {
                        v515 = false;
                    }
                    if (v515){
                        v530 = true;
                    } else {
                        unsigned char v516;
                        v516 = v126.v[3l];
                        unsigned char v517;
                        v517 = v516 << 2l;
                        unsigned char v518;
                        v518 = v517 - 1u;
                        unsigned char v519;
                        v519 = v516 & v518;
                        bool v520;
                        v520 = 3u == v519;
                        if (v520){
                            unsigned char v521;
                            v521 = v516 >> 2l;
                            unsigned char v522;
                            v522 = v521 & 15u;
                            bool v523;
                            v523 = v522 == 12u;
                            if (v523){
                                v452.v[4l] = v516;
                                v530 = true;
                            } else {
                                v530 = false;
                            }
                        } else {
                            v530 = false;
                        }
                    }
                }
            }
        } else {
            v530 = false;
        }
    } else {
        v530 = false;
    }
    US9 v536;
    if (v530){
        v536 = US9_1(v452);
    } else {
        bool v532;
        v532 = v454 == 5l;
        if (v532){
            v536 = US9_1(v452);
        } else {
            v536 = US9_0();
        }
    }
    US9 v571;
    switch (v451.tag) {
        case 0: { // None
            v571 = v536;
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v537 = v451.v.case1.v0;
            switch (v536.tag) {
                case 0: { // None
                    v571 = v451;
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v538 = v536.v.case1.v0;
                    US8 v539;
                    v539 = US8_0();
                    long v540; US8 v541;
                    Tuple19 tmp43 = Tuple19(0l, v539);
                    v540 = tmp43.v0; v541 = tmp43.v1;
                    while (while_method_2(v540)){
                        bool v543;
                        v543 = 0l <= v540;
                        bool v545;
                        if (v543){
                            bool v544;
                            v544 = v540 < 5l;
                            v545 = v544;
                        } else {
                            v545 = false;
                        }
                        bool v546;
                        v546 = v545 == false;
                        if (v546){
                            assert("The read index needs to be in range for the static array." && v545);
                        } else {
                        }
                        unsigned char v547;
                        v547 = v537.v[v540];
                        bool v549;
                        if (v543){
                            bool v548;
                            v548 = v540 < 5l;
                            v549 = v548;
                        } else {
                            v549 = false;
                        }
                        bool v550;
                        v550 = v549 == false;
                        if (v550){
                            assert("The read index needs to be in range for the static array." && v549);
                        } else {
                        }
                        unsigned char v551;
                        v551 = v538.v[v540];
                        US8 v564;
                        switch (v541.tag) {
                            case 0: { // Eq
                                unsigned char v552;
                                v552 = v547 >> 2l;
                                unsigned char v553;
                                v553 = v552 & 15u;
                                unsigned char v554;
                                v554 = v551 >> 2l;
                                unsigned char v555;
                                v555 = v554 & 15u;
                                bool v556;
                                v556 = v553 < v555;
                                if (v556){
                                    v564 = US8_2();
                                } else {
                                    bool v558;
                                    v558 = v553 > v555;
                                    if (v558){
                                        v564 = US8_1();
                                    } else {
                                        v564 = US8_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v541 = v564;
                        v540 += 1l ;
                    }
                    bool v565;
                    switch (v541.tag) {
                        case 1: { // Gt
                            v565 = true;
                            break;
                        }
                        default: {
                            v565 = false;
                        }
                    }
                    static_array<unsigned char,5l> v566;
                    if (v565){
                        v566 = v537;
                    } else {
                        v566 = v538;
                    }
                    v571 = US9_1(v566);
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
    static_array<unsigned char,5l> v1411; char v1412;
    switch (v571.tag) {
        case 0: { // None
            static_array<unsigned char,4l> v573;
            static_array<unsigned char,3l> v574;
            long v575; long v576; long v577; unsigned char v578;
            Tuple20 tmp44 = Tuple20(0l, 0l, 0l, 12u);
            v575 = tmp44.v0; v576 = tmp44.v1; v577 = tmp44.v2; v578 = tmp44.v3;
            while (while_method_10(v575)){
                bool v580;
                v580 = 0l <= v575;
                bool v582;
                if (v580){
                    bool v581;
                    v581 = v575 < 7l;
                    v582 = v581;
                } else {
                    v582 = false;
                }
                bool v583;
                v583 = v582 == false;
                if (v583){
                    assert("The read index needs to be in range for the static array." && v582);
                } else {
                }
                unsigned char v584;
                v584 = v126.v[v575];
                bool v585;
                v585 = v577 < 4l;
                long v598; long v599; unsigned char v600;
                if (v585){
                    unsigned char v586;
                    v586 = v584 >> 2l;
                    unsigned char v587;
                    v587 = v586 & 15u;
                    bool v588;
                    v588 = v578 == v587;
                    long v589;
                    if (v588){
                        v589 = v577;
                    } else {
                        v589 = 0l;
                    }
                    bool v590;
                    v590 = 0l <= v589;
                    bool v592;
                    if (v590){
                        bool v591;
                        v591 = v589 < 4l;
                        v592 = v591;
                    } else {
                        v592 = false;
                    }
                    bool v593;
                    v593 = v592 == false;
                    if (v593){
                        assert("The read index needs to be in range for the static array." && v592);
                    } else {
                    }
                    v573.v[v589] = v584;
                    long v594;
                    v594 = v589 + 1l;
                    v598 = v575; v599 = v594; v600 = v587;
                } else {
                    break;
                }
                v576 = v598;
                v577 = v599;
                v578 = v600;
                v575 += 1l ;
            }
            bool v601;
            v601 = v577 == 4l;
            US10 v619;
            if (v601){
                long v602;
                v602 = 0l;
                while (while_method_3(v602)){
                    long v604;
                    v604 = v576 + -3l;
                    bool v605;
                    v605 = v602 < v604;
                    long v606;
                    if (v605){
                        v606 = 0l;
                    } else {
                        v606 = 4l;
                    }
                    long v607;
                    v607 = v606 + v602;
                    bool v608;
                    v608 = 0l <= v607;
                    bool v610;
                    if (v608){
                        bool v609;
                        v609 = v607 < 7l;
                        v610 = v609;
                    } else {
                        v610 = false;
                    }
                    bool v611;
                    v611 = v610 == false;
                    if (v611){
                        assert("The read index needs to be in range for the static array." && v610);
                    } else {
                    }
                    unsigned char v612;
                    v612 = v126.v[v607];
                    bool v613;
                    v613 = 0l <= v602;
                    bool v615;
                    if (v613){
                        bool v614;
                        v614 = v602 < 3l;
                        v615 = v614;
                    } else {
                        v615 = false;
                    }
                    bool v616;
                    v616 = v615 == false;
                    if (v616){
                        assert("The read index needs to be in range for the static array." && v615);
                    } else {
                    }
                    v574.v[v602] = v612;
                    v602 += 1l ;
                }
                v619 = US10_1(v573, v574);
            } else {
                v619 = US10_0();
            }
            US9 v659;
            switch (v619.tag) {
                case 0: { // None
                    v659 = US9_0();
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,4l> v620 = v619.v.case1.v0; static_array<unsigned char,3l> v621 = v619.v.case1.v1;
                    static_array<unsigned char,1l> v622;
                    long v623;
                    v623 = 0l;
                    while (while_method_6(v623)){
                        bool v625;
                        v625 = 0l <= v623;
                        bool v627;
                        if (v625){
                            bool v626;
                            v626 = v623 < 3l;
                            v627 = v626;
                        } else {
                            v627 = false;
                        }
                        bool v628;
                        v628 = v627 == false;
                        if (v628){
                            assert("The read index needs to be in range for the static array." && v627);
                        } else {
                        }
                        unsigned char v629;
                        v629 = v621.v[v623];
                        bool v631;
                        if (v625){
                            bool v630;
                            v630 = v623 < 1l;
                            v631 = v630;
                        } else {
                            v631 = false;
                        }
                        bool v632;
                        v632 = v631 == false;
                        if (v632){
                            assert("The read index needs to be in range for the static array." && v631);
                        } else {
                        }
                        v622.v[v623] = v629;
                        v623 += 1l ;
                    }
                    static_array<unsigned char,5l> v633;
                    long v634;
                    v634 = 0l;
                    while (while_method_4(v634)){
                        bool v636;
                        v636 = 0l <= v634;
                        bool v638;
                        if (v636){
                            bool v637;
                            v637 = v634 < 4l;
                            v638 = v637;
                        } else {
                            v638 = false;
                        }
                        bool v639;
                        v639 = v638 == false;
                        if (v639){
                            assert("The read index needs to be in range for the static array." && v638);
                        } else {
                        }
                        unsigned char v640;
                        v640 = v620.v[v634];
                        bool v642;
                        if (v636){
                            bool v641;
                            v641 = v634 < 5l;
                            v642 = v641;
                        } else {
                            v642 = false;
                        }
                        bool v643;
                        v643 = v642 == false;
                        if (v643){
                            assert("The read index needs to be in range for the static array." && v642);
                        } else {
                        }
                        v633.v[v634] = v640;
                        v634 += 1l ;
                    }
                    long v644;
                    v644 = 0l;
                    while (while_method_6(v644)){
                        bool v646;
                        v646 = 0l <= v644;
                        bool v648;
                        if (v646){
                            bool v647;
                            v647 = v644 < 1l;
                            v648 = v647;
                        } else {
                            v648 = false;
                        }
                        bool v649;
                        v649 = v648 == false;
                        if (v649){
                            assert("The read index needs to be in range for the static array." && v648);
                        } else {
                        }
                        unsigned char v650;
                        v650 = v622.v[v644];
                        long v651;
                        v651 = 4l + v644;
                        bool v652;
                        v652 = 0l <= v651;
                        bool v654;
                        if (v652){
                            bool v653;
                            v653 = v651 < 5l;
                            v654 = v653;
                        } else {
                            v654 = false;
                        }
                        bool v655;
                        v655 = v654 == false;
                        if (v655){
                            assert("The read index needs to be in range for the static array." && v654);
                        } else {
                        }
                        v633.v[v651] = v650;
                        v644 += 1l ;
                    }
                    v659 = US9_1(v633);
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            switch (v659.tag) {
                case 0: { // None
                    static_array<unsigned char,3l> v661;
                    static_array<unsigned char,4l> v662;
                    long v663; long v664; long v665; unsigned char v666;
                    Tuple20 tmp45 = Tuple20(0l, 0l, 0l, 12u);
                    v663 = tmp45.v0; v664 = tmp45.v1; v665 = tmp45.v2; v666 = tmp45.v3;
                    while (while_method_10(v663)){
                        bool v668;
                        v668 = 0l <= v663;
                        bool v670;
                        if (v668){
                            bool v669;
                            v669 = v663 < 7l;
                            v670 = v669;
                        } else {
                            v670 = false;
                        }
                        bool v671;
                        v671 = v670 == false;
                        if (v671){
                            assert("The read index needs to be in range for the static array." && v670);
                        } else {
                        }
                        unsigned char v672;
                        v672 = v126.v[v663];
                        bool v673;
                        v673 = v665 < 3l;
                        long v686; long v687; unsigned char v688;
                        if (v673){
                            unsigned char v674;
                            v674 = v672 >> 2l;
                            unsigned char v675;
                            v675 = v674 & 15u;
                            bool v676;
                            v676 = v666 == v675;
                            long v677;
                            if (v676){
                                v677 = v665;
                            } else {
                                v677 = 0l;
                            }
                            bool v678;
                            v678 = 0l <= v677;
                            bool v680;
                            if (v678){
                                bool v679;
                                v679 = v677 < 3l;
                                v680 = v679;
                            } else {
                                v680 = false;
                            }
                            bool v681;
                            v681 = v680 == false;
                            if (v681){
                                assert("The read index needs to be in range for the static array." && v680);
                            } else {
                            }
                            v661.v[v677] = v672;
                            long v682;
                            v682 = v677 + 1l;
                            v686 = v663; v687 = v682; v688 = v675;
                        } else {
                            break;
                        }
                        v664 = v686;
                        v665 = v687;
                        v666 = v688;
                        v663 += 1l ;
                    }
                    bool v689;
                    v689 = v665 == 3l;
                    US11 v707;
                    if (v689){
                        long v690;
                        v690 = 0l;
                        while (while_method_4(v690)){
                            long v692;
                            v692 = v664 + -2l;
                            bool v693;
                            v693 = v690 < v692;
                            long v694;
                            if (v693){
                                v694 = 0l;
                            } else {
                                v694 = 3l;
                            }
                            long v695;
                            v695 = v694 + v690;
                            bool v696;
                            v696 = 0l <= v695;
                            bool v698;
                            if (v696){
                                bool v697;
                                v697 = v695 < 7l;
                                v698 = v697;
                            } else {
                                v698 = false;
                            }
                            bool v699;
                            v699 = v698 == false;
                            if (v699){
                                assert("The read index needs to be in range for the static array." && v698);
                            } else {
                            }
                            unsigned char v700;
                            v700 = v126.v[v695];
                            bool v701;
                            v701 = 0l <= v690;
                            bool v703;
                            if (v701){
                                bool v702;
                                v702 = v690 < 4l;
                                v703 = v702;
                            } else {
                                v703 = false;
                            }
                            bool v704;
                            v704 = v703 == false;
                            if (v704){
                                assert("The read index needs to be in range for the static array." && v703);
                            } else {
                            }
                            v662.v[v690] = v700;
                            v690 += 1l ;
                        }
                        v707 = US11_1(v661, v662);
                    } else {
                        v707 = US11_0();
                    }
                    US9 v788;
                    switch (v707.tag) {
                        case 0: { // None
                            v788 = US9_0();
                            break;
                        }
                        case 1: { // Some
                            static_array<unsigned char,3l> v708 = v707.v.case1.v0; static_array<unsigned char,4l> v709 = v707.v.case1.v1;
                            static_array<unsigned char,2l> v710;
                            static_array<unsigned char,2l> v711;
                            long v712; long v713; long v714; unsigned char v715;
                            Tuple20 tmp46 = Tuple20(0l, 0l, 0l, 12u);
                            v712 = tmp46.v0; v713 = tmp46.v1; v714 = tmp46.v2; v715 = tmp46.v3;
                            while (while_method_4(v712)){
                                bool v717;
                                v717 = 0l <= v712;
                                bool v719;
                                if (v717){
                                    bool v718;
                                    v718 = v712 < 4l;
                                    v719 = v718;
                                } else {
                                    v719 = false;
                                }
                                bool v720;
                                v720 = v719 == false;
                                if (v720){
                                    assert("The read index needs to be in range for the static array." && v719);
                                } else {
                                }
                                unsigned char v721;
                                v721 = v709.v[v712];
                                bool v722;
                                v722 = v714 < 2l;
                                long v735; long v736; unsigned char v737;
                                if (v722){
                                    unsigned char v723;
                                    v723 = v721 >> 2l;
                                    unsigned char v724;
                                    v724 = v723 & 15u;
                                    bool v725;
                                    v725 = v715 == v724;
                                    long v726;
                                    if (v725){
                                        v726 = v714;
                                    } else {
                                        v726 = 0l;
                                    }
                                    bool v727;
                                    v727 = 0l <= v726;
                                    bool v729;
                                    if (v727){
                                        bool v728;
                                        v728 = v726 < 2l;
                                        v729 = v728;
                                    } else {
                                        v729 = false;
                                    }
                                    bool v730;
                                    v730 = v729 == false;
                                    if (v730){
                                        assert("The read index needs to be in range for the static array." && v729);
                                    } else {
                                    }
                                    v710.v[v726] = v721;
                                    long v731;
                                    v731 = v726 + 1l;
                                    v735 = v712; v736 = v731; v737 = v724;
                                } else {
                                    break;
                                }
                                v713 = v735;
                                v714 = v736;
                                v715 = v737;
                                v712 += 1l ;
                            }
                            bool v738;
                            v738 = v714 == 2l;
                            US12 v756;
                            if (v738){
                                long v739;
                                v739 = 0l;
                                while (while_method_0(v739)){
                                    long v741;
                                    v741 = v713 + -1l;
                                    bool v742;
                                    v742 = v739 < v741;
                                    long v743;
                                    if (v742){
                                        v743 = 0l;
                                    } else {
                                        v743 = 2l;
                                    }
                                    long v744;
                                    v744 = v743 + v739;
                                    bool v745;
                                    v745 = 0l <= v744;
                                    bool v747;
                                    if (v745){
                                        bool v746;
                                        v746 = v744 < 4l;
                                        v747 = v746;
                                    } else {
                                        v747 = false;
                                    }
                                    bool v748;
                                    v748 = v747 == false;
                                    if (v748){
                                        assert("The read index needs to be in range for the static array." && v747);
                                    } else {
                                    }
                                    unsigned char v749;
                                    v749 = v709.v[v744];
                                    bool v750;
                                    v750 = 0l <= v739;
                                    bool v752;
                                    if (v750){
                                        bool v751;
                                        v751 = v739 < 2l;
                                        v752 = v751;
                                    } else {
                                        v752 = false;
                                    }
                                    bool v753;
                                    v753 = v752 == false;
                                    if (v753){
                                        assert("The read index needs to be in range for the static array." && v752);
                                    } else {
                                    }
                                    v711.v[v739] = v749;
                                    v739 += 1l ;
                                }
                                v756 = US12_1(v710, v711);
                            } else {
                                v756 = US12_0();
                            }
                            switch (v756.tag) {
                                case 0: { // None
                                    v788 = US9_0();
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,2l> v757 = v756.v.case1.v0; static_array<unsigned char,2l> v758 = v756.v.case1.v1;
                                    static_array<unsigned char,5l> v759;
                                    long v760;
                                    v760 = 0l;
                                    while (while_method_3(v760)){
                                        bool v762;
                                        v762 = 0l <= v760;
                                        bool v764;
                                        if (v762){
                                            bool v763;
                                            v763 = v760 < 3l;
                                            v764 = v763;
                                        } else {
                                            v764 = false;
                                        }
                                        bool v765;
                                        v765 = v764 == false;
                                        if (v765){
                                            assert("The read index needs to be in range for the static array." && v764);
                                        } else {
                                        }
                                        unsigned char v766;
                                        v766 = v708.v[v760];
                                        bool v768;
                                        if (v762){
                                            bool v767;
                                            v767 = v760 < 5l;
                                            v768 = v767;
                                        } else {
                                            v768 = false;
                                        }
                                        bool v769;
                                        v769 = v768 == false;
                                        if (v769){
                                            assert("The read index needs to be in range for the static array." && v768);
                                        } else {
                                        }
                                        v759.v[v760] = v766;
                                        v760 += 1l ;
                                    }
                                    long v770;
                                    v770 = 0l;
                                    while (while_method_0(v770)){
                                        bool v772;
                                        v772 = 0l <= v770;
                                        bool v774;
                                        if (v772){
                                            bool v773;
                                            v773 = v770 < 2l;
                                            v774 = v773;
                                        } else {
                                            v774 = false;
                                        }
                                        bool v775;
                                        v775 = v774 == false;
                                        if (v775){
                                            assert("The read index needs to be in range for the static array." && v774);
                                        } else {
                                        }
                                        unsigned char v776;
                                        v776 = v757.v[v770];
                                        long v777;
                                        v777 = 3l + v770;
                                        bool v778;
                                        v778 = 0l <= v777;
                                        bool v780;
                                        if (v778){
                                            bool v779;
                                            v779 = v777 < 5l;
                                            v780 = v779;
                                        } else {
                                            v780 = false;
                                        }
                                        bool v781;
                                        v781 = v780 == false;
                                        if (v781){
                                            assert("The read index needs to be in range for the static array." && v780);
                                        } else {
                                        }
                                        v759.v[v777] = v776;
                                        v770 += 1l ;
                                    }
                                    v788 = US9_1(v759);
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
                    switch (v788.tag) {
                        case 0: { // None
                            static_array<unsigned char,5l> v790;
                            long v791; long v792;
                            Tuple2 tmp47 = Tuple2(0l, 0l);
                            v791 = tmp47.v0; v792 = tmp47.v1;
                            while (while_method_10(v791)){
                                bool v794;
                                v794 = 0l <= v791;
                                bool v796;
                                if (v794){
                                    bool v795;
                                    v795 = v791 < 7l;
                                    v796 = v795;
                                } else {
                                    v796 = false;
                                }
                                bool v797;
                                v797 = v796 == false;
                                if (v797){
                                    assert("The read index needs to be in range for the static array." && v796);
                                } else {
                                }
                                unsigned char v798;
                                v798 = v126.v[v791];
                                unsigned char v799;
                                v799 = v798 << 2l;
                                unsigned char v800;
                                v800 = v799 - 1u;
                                unsigned char v801;
                                v801 = v798 & v800;
                                bool v802;
                                v802 = v801 == 0u;
                                bool v804;
                                if (v802){
                                    bool v803;
                                    v803 = v792 < 5l;
                                    v804 = v803;
                                } else {
                                    v804 = false;
                                }
                                long v810;
                                if (v804){
                                    bool v805;
                                    v805 = 0l <= v792;
                                    bool v807;
                                    if (v805){
                                        bool v806;
                                        v806 = v792 < 5l;
                                        v807 = v806;
                                    } else {
                                        v807 = false;
                                    }
                                    bool v808;
                                    v808 = v807 == false;
                                    if (v808){
                                        assert("The read index needs to be in range for the static array." && v807);
                                    } else {
                                    }
                                    v790.v[v792] = v798;
                                    long v809;
                                    v809 = v792 + 1l;
                                    v810 = v809;
                                } else {
                                    v810 = v792;
                                }
                                v792 = v810;
                                v791 += 1l ;
                            }
                            bool v811;
                            v811 = v792 == 5l;
                            US9 v814;
                            if (v811){
                                v814 = US9_1(v790);
                            } else {
                                v814 = US9_0();
                            }
                            static_array<unsigned char,5l> v815;
                            long v816; long v817;
                            Tuple2 tmp48 = Tuple2(0l, 0l);
                            v816 = tmp48.v0; v817 = tmp48.v1;
                            while (while_method_10(v816)){
                                bool v819;
                                v819 = 0l <= v816;
                                bool v821;
                                if (v819){
                                    bool v820;
                                    v820 = v816 < 7l;
                                    v821 = v820;
                                } else {
                                    v821 = false;
                                }
                                bool v822;
                                v822 = v821 == false;
                                if (v822){
                                    assert("The read index needs to be in range for the static array." && v821);
                                } else {
                                }
                                unsigned char v823;
                                v823 = v126.v[v816];
                                unsigned char v824;
                                v824 = v823 << 2l;
                                unsigned char v825;
                                v825 = v824 - 1u;
                                unsigned char v826;
                                v826 = v823 & v825;
                                bool v827;
                                v827 = v826 == 1u;
                                bool v829;
                                if (v827){
                                    bool v828;
                                    v828 = v817 < 5l;
                                    v829 = v828;
                                } else {
                                    v829 = false;
                                }
                                long v835;
                                if (v829){
                                    bool v830;
                                    v830 = 0l <= v817;
                                    bool v832;
                                    if (v830){
                                        bool v831;
                                        v831 = v817 < 5l;
                                        v832 = v831;
                                    } else {
                                        v832 = false;
                                    }
                                    bool v833;
                                    v833 = v832 == false;
                                    if (v833){
                                        assert("The read index needs to be in range for the static array." && v832);
                                    } else {
                                    }
                                    v815.v[v817] = v823;
                                    long v834;
                                    v834 = v817 + 1l;
                                    v835 = v834;
                                } else {
                                    v835 = v817;
                                }
                                v817 = v835;
                                v816 += 1l ;
                            }
                            bool v836;
                            v836 = v817 == 5l;
                            US9 v839;
                            if (v836){
                                v839 = US9_1(v815);
                            } else {
                                v839 = US9_0();
                            }
                            US9 v874;
                            switch (v814.tag) {
                                case 0: { // None
                                    v874 = v839;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v840 = v814.v.case1.v0;
                                    switch (v839.tag) {
                                        case 0: { // None
                                            v874 = v814;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v841 = v839.v.case1.v0;
                                            US8 v842;
                                            v842 = US8_0();
                                            long v843; US8 v844;
                                            Tuple19 tmp49 = Tuple19(0l, v842);
                                            v843 = tmp49.v0; v844 = tmp49.v1;
                                            while (while_method_2(v843)){
                                                bool v846;
                                                v846 = 0l <= v843;
                                                bool v848;
                                                if (v846){
                                                    bool v847;
                                                    v847 = v843 < 5l;
                                                    v848 = v847;
                                                } else {
                                                    v848 = false;
                                                }
                                                bool v849;
                                                v849 = v848 == false;
                                                if (v849){
                                                    assert("The read index needs to be in range for the static array." && v848);
                                                } else {
                                                }
                                                unsigned char v850;
                                                v850 = v840.v[v843];
                                                bool v852;
                                                if (v846){
                                                    bool v851;
                                                    v851 = v843 < 5l;
                                                    v852 = v851;
                                                } else {
                                                    v852 = false;
                                                }
                                                bool v853;
                                                v853 = v852 == false;
                                                if (v853){
                                                    assert("The read index needs to be in range for the static array." && v852);
                                                } else {
                                                }
                                                unsigned char v854;
                                                v854 = v841.v[v843];
                                                US8 v867;
                                                switch (v844.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v855;
                                                        v855 = v850 >> 2l;
                                                        unsigned char v856;
                                                        v856 = v855 & 15u;
                                                        unsigned char v857;
                                                        v857 = v854 >> 2l;
                                                        unsigned char v858;
                                                        v858 = v857 & 15u;
                                                        bool v859;
                                                        v859 = v856 < v858;
                                                        if (v859){
                                                            v867 = US8_2();
                                                        } else {
                                                            bool v861;
                                                            v861 = v856 > v858;
                                                            if (v861){
                                                                v867 = US8_1();
                                                            } else {
                                                                v867 = US8_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v844 = v867;
                                                v843 += 1l ;
                                            }
                                            bool v868;
                                            switch (v844.tag) {
                                                case 1: { // Gt
                                                    v868 = true;
                                                    break;
                                                }
                                                default: {
                                                    v868 = false;
                                                }
                                            }
                                            static_array<unsigned char,5l> v869;
                                            if (v868){
                                                v869 = v840;
                                            } else {
                                                v869 = v841;
                                            }
                                            v874 = US9_1(v869);
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
                            static_array<unsigned char,5l> v875;
                            long v876; long v877;
                            Tuple2 tmp50 = Tuple2(0l, 0l);
                            v876 = tmp50.v0; v877 = tmp50.v1;
                            while (while_method_10(v876)){
                                bool v879;
                                v879 = 0l <= v876;
                                bool v881;
                                if (v879){
                                    bool v880;
                                    v880 = v876 < 7l;
                                    v881 = v880;
                                } else {
                                    v881 = false;
                                }
                                bool v882;
                                v882 = v881 == false;
                                if (v882){
                                    assert("The read index needs to be in range for the static array." && v881);
                                } else {
                                }
                                unsigned char v883;
                                v883 = v126.v[v876];
                                unsigned char v884;
                                v884 = v883 << 2l;
                                unsigned char v885;
                                v885 = v884 - 1u;
                                unsigned char v886;
                                v886 = v883 & v885;
                                bool v887;
                                v887 = v886 == 2u;
                                bool v889;
                                if (v887){
                                    bool v888;
                                    v888 = v877 < 5l;
                                    v889 = v888;
                                } else {
                                    v889 = false;
                                }
                                long v895;
                                if (v889){
                                    bool v890;
                                    v890 = 0l <= v877;
                                    bool v892;
                                    if (v890){
                                        bool v891;
                                        v891 = v877 < 5l;
                                        v892 = v891;
                                    } else {
                                        v892 = false;
                                    }
                                    bool v893;
                                    v893 = v892 == false;
                                    if (v893){
                                        assert("The read index needs to be in range for the static array." && v892);
                                    } else {
                                    }
                                    v875.v[v877] = v883;
                                    long v894;
                                    v894 = v877 + 1l;
                                    v895 = v894;
                                } else {
                                    v895 = v877;
                                }
                                v877 = v895;
                                v876 += 1l ;
                            }
                            bool v896;
                            v896 = v877 == 5l;
                            US9 v899;
                            if (v896){
                                v899 = US9_1(v875);
                            } else {
                                v899 = US9_0();
                            }
                            US9 v934;
                            switch (v874.tag) {
                                case 0: { // None
                                    v934 = v899;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v900 = v874.v.case1.v0;
                                    switch (v899.tag) {
                                        case 0: { // None
                                            v934 = v874;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v901 = v899.v.case1.v0;
                                            US8 v902;
                                            v902 = US8_0();
                                            long v903; US8 v904;
                                            Tuple19 tmp51 = Tuple19(0l, v902);
                                            v903 = tmp51.v0; v904 = tmp51.v1;
                                            while (while_method_2(v903)){
                                                bool v906;
                                                v906 = 0l <= v903;
                                                bool v908;
                                                if (v906){
                                                    bool v907;
                                                    v907 = v903 < 5l;
                                                    v908 = v907;
                                                } else {
                                                    v908 = false;
                                                }
                                                bool v909;
                                                v909 = v908 == false;
                                                if (v909){
                                                    assert("The read index needs to be in range for the static array." && v908);
                                                } else {
                                                }
                                                unsigned char v910;
                                                v910 = v900.v[v903];
                                                bool v912;
                                                if (v906){
                                                    bool v911;
                                                    v911 = v903 < 5l;
                                                    v912 = v911;
                                                } else {
                                                    v912 = false;
                                                }
                                                bool v913;
                                                v913 = v912 == false;
                                                if (v913){
                                                    assert("The read index needs to be in range for the static array." && v912);
                                                } else {
                                                }
                                                unsigned char v914;
                                                v914 = v901.v[v903];
                                                US8 v927;
                                                switch (v904.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v915;
                                                        v915 = v910 >> 2l;
                                                        unsigned char v916;
                                                        v916 = v915 & 15u;
                                                        unsigned char v917;
                                                        v917 = v914 >> 2l;
                                                        unsigned char v918;
                                                        v918 = v917 & 15u;
                                                        bool v919;
                                                        v919 = v916 < v918;
                                                        if (v919){
                                                            v927 = US8_2();
                                                        } else {
                                                            bool v921;
                                                            v921 = v916 > v918;
                                                            if (v921){
                                                                v927 = US8_1();
                                                            } else {
                                                                v927 = US8_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v904 = v927;
                                                v903 += 1l ;
                                            }
                                            bool v928;
                                            switch (v904.tag) {
                                                case 1: { // Gt
                                                    v928 = true;
                                                    break;
                                                }
                                                default: {
                                                    v928 = false;
                                                }
                                            }
                                            static_array<unsigned char,5l> v929;
                                            if (v928){
                                                v929 = v900;
                                            } else {
                                                v929 = v901;
                                            }
                                            v934 = US9_1(v929);
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
                            static_array<unsigned char,5l> v935;
                            long v936; long v937;
                            Tuple2 tmp52 = Tuple2(0l, 0l);
                            v936 = tmp52.v0; v937 = tmp52.v1;
                            while (while_method_10(v936)){
                                bool v939;
                                v939 = 0l <= v936;
                                bool v941;
                                if (v939){
                                    bool v940;
                                    v940 = v936 < 7l;
                                    v941 = v940;
                                } else {
                                    v941 = false;
                                }
                                bool v942;
                                v942 = v941 == false;
                                if (v942){
                                    assert("The read index needs to be in range for the static array." && v941);
                                } else {
                                }
                                unsigned char v943;
                                v943 = v126.v[v936];
                                unsigned char v944;
                                v944 = v943 << 2l;
                                unsigned char v945;
                                v945 = v944 - 1u;
                                unsigned char v946;
                                v946 = v943 & v945;
                                bool v947;
                                v947 = v946 == 3u;
                                bool v949;
                                if (v947){
                                    bool v948;
                                    v948 = v937 < 5l;
                                    v949 = v948;
                                } else {
                                    v949 = false;
                                }
                                long v955;
                                if (v949){
                                    bool v950;
                                    v950 = 0l <= v937;
                                    bool v952;
                                    if (v950){
                                        bool v951;
                                        v951 = v937 < 5l;
                                        v952 = v951;
                                    } else {
                                        v952 = false;
                                    }
                                    bool v953;
                                    v953 = v952 == false;
                                    if (v953){
                                        assert("The read index needs to be in range for the static array." && v952);
                                    } else {
                                    }
                                    v935.v[v937] = v943;
                                    long v954;
                                    v954 = v937 + 1l;
                                    v955 = v954;
                                } else {
                                    v955 = v937;
                                }
                                v937 = v955;
                                v936 += 1l ;
                            }
                            bool v956;
                            v956 = v937 == 5l;
                            US9 v959;
                            if (v956){
                                v959 = US9_1(v935);
                            } else {
                                v959 = US9_0();
                            }
                            US9 v994;
                            switch (v934.tag) {
                                case 0: { // None
                                    v994 = v959;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v960 = v934.v.case1.v0;
                                    switch (v959.tag) {
                                        case 0: { // None
                                            v994 = v934;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v961 = v959.v.case1.v0;
                                            US8 v962;
                                            v962 = US8_0();
                                            long v963; US8 v964;
                                            Tuple19 tmp53 = Tuple19(0l, v962);
                                            v963 = tmp53.v0; v964 = tmp53.v1;
                                            while (while_method_2(v963)){
                                                bool v966;
                                                v966 = 0l <= v963;
                                                bool v968;
                                                if (v966){
                                                    bool v967;
                                                    v967 = v963 < 5l;
                                                    v968 = v967;
                                                } else {
                                                    v968 = false;
                                                }
                                                bool v969;
                                                v969 = v968 == false;
                                                if (v969){
                                                    assert("The read index needs to be in range for the static array." && v968);
                                                } else {
                                                }
                                                unsigned char v970;
                                                v970 = v960.v[v963];
                                                bool v972;
                                                if (v966){
                                                    bool v971;
                                                    v971 = v963 < 5l;
                                                    v972 = v971;
                                                } else {
                                                    v972 = false;
                                                }
                                                bool v973;
                                                v973 = v972 == false;
                                                if (v973){
                                                    assert("The read index needs to be in range for the static array." && v972);
                                                } else {
                                                }
                                                unsigned char v974;
                                                v974 = v961.v[v963];
                                                US8 v987;
                                                switch (v964.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v975;
                                                        v975 = v970 >> 2l;
                                                        unsigned char v976;
                                                        v976 = v975 & 15u;
                                                        unsigned char v977;
                                                        v977 = v974 >> 2l;
                                                        unsigned char v978;
                                                        v978 = v977 & 15u;
                                                        bool v979;
                                                        v979 = v976 < v978;
                                                        if (v979){
                                                            v987 = US8_2();
                                                        } else {
                                                            bool v981;
                                                            v981 = v976 > v978;
                                                            if (v981){
                                                                v987 = US8_1();
                                                            } else {
                                                                v987 = US8_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v964 = v987;
                                                v963 += 1l ;
                                            }
                                            bool v988;
                                            switch (v964.tag) {
                                                case 1: { // Gt
                                                    v988 = true;
                                                    break;
                                                }
                                                default: {
                                                    v988 = false;
                                                }
                                            }
                                            static_array<unsigned char,5l> v989;
                                            if (v988){
                                                v989 = v960;
                                            } else {
                                                v989 = v961;
                                            }
                                            v994 = US9_1(v989);
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
                            switch (v994.tag) {
                                case 0: { // None
                                    static_array<unsigned char,5l> v996;
                                    long v997; long v998; unsigned char v999;
                                    Tuple18 tmp54 = Tuple18(0l, 0l, 12u);
                                    v997 = tmp54.v0; v998 = tmp54.v1; v999 = tmp54.v2;
                                    while (while_method_10(v997)){
                                        bool v1001;
                                        v1001 = 0l <= v997;
                                        bool v1003;
                                        if (v1001){
                                            bool v1002;
                                            v1002 = v997 < 7l;
                                            v1003 = v1002;
                                        } else {
                                            v1003 = false;
                                        }
                                        bool v1004;
                                        v1004 = v1003 == false;
                                        if (v1004){
                                            assert("The read index needs to be in range for the static array." && v1003);
                                        } else {
                                        }
                                        unsigned char v1005;
                                        v1005 = v126.v[v997];
                                        bool v1006;
                                        v1006 = v998 < 5l;
                                        long v1023; unsigned char v1024;
                                        if (v1006){
                                            unsigned char v1007;
                                            v1007 = v1005 >> 2l;
                                            unsigned char v1008;
                                            v1008 = v1007 & 15u;
                                            unsigned char v1009;
                                            v1009 = v1008 - 1u;
                                            bool v1010;
                                            v1010 = v999 == v1009;
                                            bool v1011;
                                            v1011 = v1010 != true;
                                            if (v1011){
                                                bool v1012;
                                                v1012 = v999 == v1008;
                                                long v1013;
                                                if (v1012){
                                                    v1013 = v998;
                                                } else {
                                                    v1013 = 0l;
                                                }
                                                bool v1014;
                                                v1014 = 0l <= v1013;
                                                bool v1016;
                                                if (v1014){
                                                    bool v1015;
                                                    v1015 = v1013 < 5l;
                                                    v1016 = v1015;
                                                } else {
                                                    v1016 = false;
                                                }
                                                bool v1017;
                                                v1017 = v1016 == false;
                                                if (v1017){
                                                    assert("The read index needs to be in range for the static array." && v1016);
                                                } else {
                                                }
                                                v996.v[v1013] = v1005;
                                                long v1018;
                                                v1018 = v1013 + 1l;
                                                v1023 = v1018; v1024 = v1009;
                                            } else {
                                                v1023 = v998; v1024 = v999;
                                            }
                                        } else {
                                            break;
                                        }
                                        v998 = v1023;
                                        v999 = v1024;
                                        v997 += 1l ;
                                    }
                                    bool v1025;
                                    v1025 = v998 == 4l;
                                    bool v1034;
                                    if (v1025){
                                        unsigned char v1026;
                                        v1026 = v999 + 1u;
                                        bool v1027;
                                        v1027 = v1026 == 0u;
                                        if (v1027){
                                            unsigned char v1028;
                                            v1028 = v126.v[0l];
                                            unsigned char v1029;
                                            v1029 = v1028 >> 2l;
                                            unsigned char v1030;
                                            v1030 = v1029 & 15u;
                                            bool v1031;
                                            v1031 = v1030 == 12u;
                                            if (v1031){
                                                v996.v[4l] = v1028;
                                                v1034 = true;
                                            } else {
                                                v1034 = false;
                                            }
                                        } else {
                                            v1034 = false;
                                        }
                                    } else {
                                        v1034 = false;
                                    }
                                    US9 v1040;
                                    if (v1034){
                                        v1040 = US9_1(v996);
                                    } else {
                                        bool v1036;
                                        v1036 = v998 == 5l;
                                        if (v1036){
                                            v1040 = US9_1(v996);
                                        } else {
                                            v1040 = US9_0();
                                        }
                                    }
                                    switch (v1040.tag) {
                                        case 0: { // None
                                            static_array<unsigned char,3l> v1042;
                                            static_array<unsigned char,4l> v1043;
                                            long v1044; long v1045; long v1046; unsigned char v1047;
                                            Tuple20 tmp55 = Tuple20(0l, 0l, 0l, 12u);
                                            v1044 = tmp55.v0; v1045 = tmp55.v1; v1046 = tmp55.v2; v1047 = tmp55.v3;
                                            while (while_method_10(v1044)){
                                                bool v1049;
                                                v1049 = 0l <= v1044;
                                                bool v1051;
                                                if (v1049){
                                                    bool v1050;
                                                    v1050 = v1044 < 7l;
                                                    v1051 = v1050;
                                                } else {
                                                    v1051 = false;
                                                }
                                                bool v1052;
                                                v1052 = v1051 == false;
                                                if (v1052){
                                                    assert("The read index needs to be in range for the static array." && v1051);
                                                } else {
                                                }
                                                unsigned char v1053;
                                                v1053 = v126.v[v1044];
                                                bool v1054;
                                                v1054 = v1046 < 3l;
                                                long v1067; long v1068; unsigned char v1069;
                                                if (v1054){
                                                    unsigned char v1055;
                                                    v1055 = v1053 >> 2l;
                                                    unsigned char v1056;
                                                    v1056 = v1055 & 15u;
                                                    bool v1057;
                                                    v1057 = v1047 == v1056;
                                                    long v1058;
                                                    if (v1057){
                                                        v1058 = v1046;
                                                    } else {
                                                        v1058 = 0l;
                                                    }
                                                    bool v1059;
                                                    v1059 = 0l <= v1058;
                                                    bool v1061;
                                                    if (v1059){
                                                        bool v1060;
                                                        v1060 = v1058 < 3l;
                                                        v1061 = v1060;
                                                    } else {
                                                        v1061 = false;
                                                    }
                                                    bool v1062;
                                                    v1062 = v1061 == false;
                                                    if (v1062){
                                                        assert("The read index needs to be in range for the static array." && v1061);
                                                    } else {
                                                    }
                                                    v1042.v[v1058] = v1053;
                                                    long v1063;
                                                    v1063 = v1058 + 1l;
                                                    v1067 = v1044; v1068 = v1063; v1069 = v1056;
                                                } else {
                                                    break;
                                                }
                                                v1045 = v1067;
                                                v1046 = v1068;
                                                v1047 = v1069;
                                                v1044 += 1l ;
                                            }
                                            bool v1070;
                                            v1070 = v1046 == 3l;
                                            US11 v1088;
                                            if (v1070){
                                                long v1071;
                                                v1071 = 0l;
                                                while (while_method_4(v1071)){
                                                    long v1073;
                                                    v1073 = v1045 + -2l;
                                                    bool v1074;
                                                    v1074 = v1071 < v1073;
                                                    long v1075;
                                                    if (v1074){
                                                        v1075 = 0l;
                                                    } else {
                                                        v1075 = 3l;
                                                    }
                                                    long v1076;
                                                    v1076 = v1075 + v1071;
                                                    bool v1077;
                                                    v1077 = 0l <= v1076;
                                                    bool v1079;
                                                    if (v1077){
                                                        bool v1078;
                                                        v1078 = v1076 < 7l;
                                                        v1079 = v1078;
                                                    } else {
                                                        v1079 = false;
                                                    }
                                                    bool v1080;
                                                    v1080 = v1079 == false;
                                                    if (v1080){
                                                        assert("The read index needs to be in range for the static array." && v1079);
                                                    } else {
                                                    }
                                                    unsigned char v1081;
                                                    v1081 = v126.v[v1076];
                                                    bool v1082;
                                                    v1082 = 0l <= v1071;
                                                    bool v1084;
                                                    if (v1082){
                                                        bool v1083;
                                                        v1083 = v1071 < 4l;
                                                        v1084 = v1083;
                                                    } else {
                                                        v1084 = false;
                                                    }
                                                    bool v1085;
                                                    v1085 = v1084 == false;
                                                    if (v1085){
                                                        assert("The read index needs to be in range for the static array." && v1084);
                                                    } else {
                                                    }
                                                    v1043.v[v1071] = v1081;
                                                    v1071 += 1l ;
                                                }
                                                v1088 = US11_1(v1042, v1043);
                                            } else {
                                                v1088 = US11_0();
                                            }
                                            US9 v1128;
                                            switch (v1088.tag) {
                                                case 0: { // None
                                                    v1128 = US9_0();
                                                    break;
                                                }
                                                case 1: { // Some
                                                    static_array<unsigned char,3l> v1089 = v1088.v.case1.v0; static_array<unsigned char,4l> v1090 = v1088.v.case1.v1;
                                                    static_array<unsigned char,2l> v1091;
                                                    long v1092;
                                                    v1092 = 0l;
                                                    while (while_method_0(v1092)){
                                                        bool v1094;
                                                        v1094 = 0l <= v1092;
                                                        bool v1096;
                                                        if (v1094){
                                                            bool v1095;
                                                            v1095 = v1092 < 4l;
                                                            v1096 = v1095;
                                                        } else {
                                                            v1096 = false;
                                                        }
                                                        bool v1097;
                                                        v1097 = v1096 == false;
                                                        if (v1097){
                                                            assert("The read index needs to be in range for the static array." && v1096);
                                                        } else {
                                                        }
                                                        unsigned char v1098;
                                                        v1098 = v1090.v[v1092];
                                                        bool v1100;
                                                        if (v1094){
                                                            bool v1099;
                                                            v1099 = v1092 < 2l;
                                                            v1100 = v1099;
                                                        } else {
                                                            v1100 = false;
                                                        }
                                                        bool v1101;
                                                        v1101 = v1100 == false;
                                                        if (v1101){
                                                            assert("The read index needs to be in range for the static array." && v1100);
                                                        } else {
                                                        }
                                                        v1091.v[v1092] = v1098;
                                                        v1092 += 1l ;
                                                    }
                                                    static_array<unsigned char,5l> v1102;
                                                    long v1103;
                                                    v1103 = 0l;
                                                    while (while_method_3(v1103)){
                                                        bool v1105;
                                                        v1105 = 0l <= v1103;
                                                        bool v1107;
                                                        if (v1105){
                                                            bool v1106;
                                                            v1106 = v1103 < 3l;
                                                            v1107 = v1106;
                                                        } else {
                                                            v1107 = false;
                                                        }
                                                        bool v1108;
                                                        v1108 = v1107 == false;
                                                        if (v1108){
                                                            assert("The read index needs to be in range for the static array." && v1107);
                                                        } else {
                                                        }
                                                        unsigned char v1109;
                                                        v1109 = v1089.v[v1103];
                                                        bool v1111;
                                                        if (v1105){
                                                            bool v1110;
                                                            v1110 = v1103 < 5l;
                                                            v1111 = v1110;
                                                        } else {
                                                            v1111 = false;
                                                        }
                                                        bool v1112;
                                                        v1112 = v1111 == false;
                                                        if (v1112){
                                                            assert("The read index needs to be in range for the static array." && v1111);
                                                        } else {
                                                        }
                                                        v1102.v[v1103] = v1109;
                                                        v1103 += 1l ;
                                                    }
                                                    long v1113;
                                                    v1113 = 0l;
                                                    while (while_method_0(v1113)){
                                                        bool v1115;
                                                        v1115 = 0l <= v1113;
                                                        bool v1117;
                                                        if (v1115){
                                                            bool v1116;
                                                            v1116 = v1113 < 2l;
                                                            v1117 = v1116;
                                                        } else {
                                                            v1117 = false;
                                                        }
                                                        bool v1118;
                                                        v1118 = v1117 == false;
                                                        if (v1118){
                                                            assert("The read index needs to be in range for the static array." && v1117);
                                                        } else {
                                                        }
                                                        unsigned char v1119;
                                                        v1119 = v1091.v[v1113];
                                                        long v1120;
                                                        v1120 = 3l + v1113;
                                                        bool v1121;
                                                        v1121 = 0l <= v1120;
                                                        bool v1123;
                                                        if (v1121){
                                                            bool v1122;
                                                            v1122 = v1120 < 5l;
                                                            v1123 = v1122;
                                                        } else {
                                                            v1123 = false;
                                                        }
                                                        bool v1124;
                                                        v1124 = v1123 == false;
                                                        if (v1124){
                                                            assert("The read index needs to be in range for the static array." && v1123);
                                                        } else {
                                                        }
                                                        v1102.v[v1120] = v1119;
                                                        v1113 += 1l ;
                                                    }
                                                    v1128 = US9_1(v1102);
                                                    break;
                                                }
                                                default: {
                                                    assert("Invalid tag." && false);
                                                }
                                            }
                                            switch (v1128.tag) {
                                                case 0: { // None
                                                    static_array<unsigned char,2l> v1130;
                                                    static_array<unsigned char,5l> v1131;
                                                    long v1132; long v1133; long v1134; unsigned char v1135;
                                                    Tuple20 tmp56 = Tuple20(0l, 0l, 0l, 12u);
                                                    v1132 = tmp56.v0; v1133 = tmp56.v1; v1134 = tmp56.v2; v1135 = tmp56.v3;
                                                    while (while_method_10(v1132)){
                                                        bool v1137;
                                                        v1137 = 0l <= v1132;
                                                        bool v1139;
                                                        if (v1137){
                                                            bool v1138;
                                                            v1138 = v1132 < 7l;
                                                            v1139 = v1138;
                                                        } else {
                                                            v1139 = false;
                                                        }
                                                        bool v1140;
                                                        v1140 = v1139 == false;
                                                        if (v1140){
                                                            assert("The read index needs to be in range for the static array." && v1139);
                                                        } else {
                                                        }
                                                        unsigned char v1141;
                                                        v1141 = v126.v[v1132];
                                                        bool v1142;
                                                        v1142 = v1134 < 2l;
                                                        long v1155; long v1156; unsigned char v1157;
                                                        if (v1142){
                                                            unsigned char v1143;
                                                            v1143 = v1141 >> 2l;
                                                            unsigned char v1144;
                                                            v1144 = v1143 & 15u;
                                                            bool v1145;
                                                            v1145 = v1135 == v1144;
                                                            long v1146;
                                                            if (v1145){
                                                                v1146 = v1134;
                                                            } else {
                                                                v1146 = 0l;
                                                            }
                                                            bool v1147;
                                                            v1147 = 0l <= v1146;
                                                            bool v1149;
                                                            if (v1147){
                                                                bool v1148;
                                                                v1148 = v1146 < 2l;
                                                                v1149 = v1148;
                                                            } else {
                                                                v1149 = false;
                                                            }
                                                            bool v1150;
                                                            v1150 = v1149 == false;
                                                            if (v1150){
                                                                assert("The read index needs to be in range for the static array." && v1149);
                                                            } else {
                                                            }
                                                            v1130.v[v1146] = v1141;
                                                            long v1151;
                                                            v1151 = v1146 + 1l;
                                                            v1155 = v1132; v1156 = v1151; v1157 = v1144;
                                                        } else {
                                                            break;
                                                        }
                                                        v1133 = v1155;
                                                        v1134 = v1156;
                                                        v1135 = v1157;
                                                        v1132 += 1l ;
                                                    }
                                                    bool v1158;
                                                    v1158 = v1134 == 2l;
                                                    US13 v1176;
                                                    if (v1158){
                                                        long v1159;
                                                        v1159 = 0l;
                                                        while (while_method_2(v1159)){
                                                            long v1161;
                                                            v1161 = v1133 + -1l;
                                                            bool v1162;
                                                            v1162 = v1159 < v1161;
                                                            long v1163;
                                                            if (v1162){
                                                                v1163 = 0l;
                                                            } else {
                                                                v1163 = 2l;
                                                            }
                                                            long v1164;
                                                            v1164 = v1163 + v1159;
                                                            bool v1165;
                                                            v1165 = 0l <= v1164;
                                                            bool v1167;
                                                            if (v1165){
                                                                bool v1166;
                                                                v1166 = v1164 < 7l;
                                                                v1167 = v1166;
                                                            } else {
                                                                v1167 = false;
                                                            }
                                                            bool v1168;
                                                            v1168 = v1167 == false;
                                                            if (v1168){
                                                                assert("The read index needs to be in range for the static array." && v1167);
                                                            } else {
                                                            }
                                                            unsigned char v1169;
                                                            v1169 = v126.v[v1164];
                                                            bool v1170;
                                                            v1170 = 0l <= v1159;
                                                            bool v1172;
                                                            if (v1170){
                                                                bool v1171;
                                                                v1171 = v1159 < 5l;
                                                                v1172 = v1171;
                                                            } else {
                                                                v1172 = false;
                                                            }
                                                            bool v1173;
                                                            v1173 = v1172 == false;
                                                            if (v1173){
                                                                assert("The read index needs to be in range for the static array." && v1172);
                                                            } else {
                                                            }
                                                            v1131.v[v1159] = v1169;
                                                            v1159 += 1l ;
                                                        }
                                                        v1176 = US13_1(v1130, v1131);
                                                    } else {
                                                        v1176 = US13_0();
                                                    }
                                                    US9 v1280;
                                                    switch (v1176.tag) {
                                                        case 0: { // None
                                                            v1280 = US9_0();
                                                            break;
                                                        }
                                                        case 1: { // Some
                                                            static_array<unsigned char,2l> v1177 = v1176.v.case1.v0; static_array<unsigned char,5l> v1178 = v1176.v.case1.v1;
                                                            static_array<unsigned char,2l> v1179;
                                                            static_array<unsigned char,3l> v1180;
                                                            long v1181; long v1182; long v1183; unsigned char v1184;
                                                            Tuple20 tmp57 = Tuple20(0l, 0l, 0l, 12u);
                                                            v1181 = tmp57.v0; v1182 = tmp57.v1; v1183 = tmp57.v2; v1184 = tmp57.v3;
                                                            while (while_method_2(v1181)){
                                                                bool v1186;
                                                                v1186 = 0l <= v1181;
                                                                bool v1188;
                                                                if (v1186){
                                                                    bool v1187;
                                                                    v1187 = v1181 < 5l;
                                                                    v1188 = v1187;
                                                                } else {
                                                                    v1188 = false;
                                                                }
                                                                bool v1189;
                                                                v1189 = v1188 == false;
                                                                if (v1189){
                                                                    assert("The read index needs to be in range for the static array." && v1188);
                                                                } else {
                                                                }
                                                                unsigned char v1190;
                                                                v1190 = v1178.v[v1181];
                                                                bool v1191;
                                                                v1191 = v1183 < 2l;
                                                                long v1204; long v1205; unsigned char v1206;
                                                                if (v1191){
                                                                    unsigned char v1192;
                                                                    v1192 = v1190 >> 2l;
                                                                    unsigned char v1193;
                                                                    v1193 = v1192 & 15u;
                                                                    bool v1194;
                                                                    v1194 = v1184 == v1193;
                                                                    long v1195;
                                                                    if (v1194){
                                                                        v1195 = v1183;
                                                                    } else {
                                                                        v1195 = 0l;
                                                                    }
                                                                    bool v1196;
                                                                    v1196 = 0l <= v1195;
                                                                    bool v1198;
                                                                    if (v1196){
                                                                        bool v1197;
                                                                        v1197 = v1195 < 2l;
                                                                        v1198 = v1197;
                                                                    } else {
                                                                        v1198 = false;
                                                                    }
                                                                    bool v1199;
                                                                    v1199 = v1198 == false;
                                                                    if (v1199){
                                                                        assert("The read index needs to be in range for the static array." && v1198);
                                                                    } else {
                                                                    }
                                                                    v1179.v[v1195] = v1190;
                                                                    long v1200;
                                                                    v1200 = v1195 + 1l;
                                                                    v1204 = v1181; v1205 = v1200; v1206 = v1193;
                                                                } else {
                                                                    break;
                                                                }
                                                                v1182 = v1204;
                                                                v1183 = v1205;
                                                                v1184 = v1206;
                                                                v1181 += 1l ;
                                                            }
                                                            bool v1207;
                                                            v1207 = v1183 == 2l;
                                                            US14 v1225;
                                                            if (v1207){
                                                                long v1208;
                                                                v1208 = 0l;
                                                                while (while_method_3(v1208)){
                                                                    long v1210;
                                                                    v1210 = v1182 + -1l;
                                                                    bool v1211;
                                                                    v1211 = v1208 < v1210;
                                                                    long v1212;
                                                                    if (v1211){
                                                                        v1212 = 0l;
                                                                    } else {
                                                                        v1212 = 2l;
                                                                    }
                                                                    long v1213;
                                                                    v1213 = v1212 + v1208;
                                                                    bool v1214;
                                                                    v1214 = 0l <= v1213;
                                                                    bool v1216;
                                                                    if (v1214){
                                                                        bool v1215;
                                                                        v1215 = v1213 < 5l;
                                                                        v1216 = v1215;
                                                                    } else {
                                                                        v1216 = false;
                                                                    }
                                                                    bool v1217;
                                                                    v1217 = v1216 == false;
                                                                    if (v1217){
                                                                        assert("The read index needs to be in range for the static array." && v1216);
                                                                    } else {
                                                                    }
                                                                    unsigned char v1218;
                                                                    v1218 = v1178.v[v1213];
                                                                    bool v1219;
                                                                    v1219 = 0l <= v1208;
                                                                    bool v1221;
                                                                    if (v1219){
                                                                        bool v1220;
                                                                        v1220 = v1208 < 3l;
                                                                        v1221 = v1220;
                                                                    } else {
                                                                        v1221 = false;
                                                                    }
                                                                    bool v1222;
                                                                    v1222 = v1221 == false;
                                                                    if (v1222){
                                                                        assert("The read index needs to be in range for the static array." && v1221);
                                                                    } else {
                                                                    }
                                                                    v1180.v[v1208] = v1218;
                                                                    v1208 += 1l ;
                                                                }
                                                                v1225 = US14_1(v1179, v1180);
                                                            } else {
                                                                v1225 = US14_0();
                                                            }
                                                            switch (v1225.tag) {
                                                                case 0: { // None
                                                                    v1280 = US9_0();
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<unsigned char,2l> v1226 = v1225.v.case1.v0; static_array<unsigned char,3l> v1227 = v1225.v.case1.v1;
                                                                    static_array<unsigned char,1l> v1228;
                                                                    long v1229;
                                                                    v1229 = 0l;
                                                                    while (while_method_6(v1229)){
                                                                        bool v1231;
                                                                        v1231 = 0l <= v1229;
                                                                        bool v1233;
                                                                        if (v1231){
                                                                            bool v1232;
                                                                            v1232 = v1229 < 3l;
                                                                            v1233 = v1232;
                                                                        } else {
                                                                            v1233 = false;
                                                                        }
                                                                        bool v1234;
                                                                        v1234 = v1233 == false;
                                                                        if (v1234){
                                                                            assert("The read index needs to be in range for the static array." && v1233);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1235;
                                                                        v1235 = v1227.v[v1229];
                                                                        bool v1237;
                                                                        if (v1231){
                                                                            bool v1236;
                                                                            v1236 = v1229 < 1l;
                                                                            v1237 = v1236;
                                                                        } else {
                                                                            v1237 = false;
                                                                        }
                                                                        bool v1238;
                                                                        v1238 = v1237 == false;
                                                                        if (v1238){
                                                                            assert("The read index needs to be in range for the static array." && v1237);
                                                                        } else {
                                                                        }
                                                                        v1228.v[v1229] = v1235;
                                                                        v1229 += 1l ;
                                                                    }
                                                                    static_array<unsigned char,5l> v1239;
                                                                    long v1240;
                                                                    v1240 = 0l;
                                                                    while (while_method_0(v1240)){
                                                                        bool v1242;
                                                                        v1242 = 0l <= v1240;
                                                                        bool v1244;
                                                                        if (v1242){
                                                                            bool v1243;
                                                                            v1243 = v1240 < 2l;
                                                                            v1244 = v1243;
                                                                        } else {
                                                                            v1244 = false;
                                                                        }
                                                                        bool v1245;
                                                                        v1245 = v1244 == false;
                                                                        if (v1245){
                                                                            assert("The read index needs to be in range for the static array." && v1244);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1246;
                                                                        v1246 = v1177.v[v1240];
                                                                        bool v1248;
                                                                        if (v1242){
                                                                            bool v1247;
                                                                            v1247 = v1240 < 5l;
                                                                            v1248 = v1247;
                                                                        } else {
                                                                            v1248 = false;
                                                                        }
                                                                        bool v1249;
                                                                        v1249 = v1248 == false;
                                                                        if (v1249){
                                                                            assert("The read index needs to be in range for the static array." && v1248);
                                                                        } else {
                                                                        }
                                                                        v1239.v[v1240] = v1246;
                                                                        v1240 += 1l ;
                                                                    }
                                                                    long v1250;
                                                                    v1250 = 0l;
                                                                    while (while_method_0(v1250)){
                                                                        bool v1252;
                                                                        v1252 = 0l <= v1250;
                                                                        bool v1254;
                                                                        if (v1252){
                                                                            bool v1253;
                                                                            v1253 = v1250 < 2l;
                                                                            v1254 = v1253;
                                                                        } else {
                                                                            v1254 = false;
                                                                        }
                                                                        bool v1255;
                                                                        v1255 = v1254 == false;
                                                                        if (v1255){
                                                                            assert("The read index needs to be in range for the static array." && v1254);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1256;
                                                                        v1256 = v1226.v[v1250];
                                                                        long v1257;
                                                                        v1257 = 2l + v1250;
                                                                        bool v1258;
                                                                        v1258 = 0l <= v1257;
                                                                        bool v1260;
                                                                        if (v1258){
                                                                            bool v1259;
                                                                            v1259 = v1257 < 5l;
                                                                            v1260 = v1259;
                                                                        } else {
                                                                            v1260 = false;
                                                                        }
                                                                        bool v1261;
                                                                        v1261 = v1260 == false;
                                                                        if (v1261){
                                                                            assert("The read index needs to be in range for the static array." && v1260);
                                                                        } else {
                                                                        }
                                                                        v1239.v[v1257] = v1256;
                                                                        v1250 += 1l ;
                                                                    }
                                                                    long v1262;
                                                                    v1262 = 0l;
                                                                    while (while_method_6(v1262)){
                                                                        bool v1264;
                                                                        v1264 = 0l <= v1262;
                                                                        bool v1266;
                                                                        if (v1264){
                                                                            bool v1265;
                                                                            v1265 = v1262 < 1l;
                                                                            v1266 = v1265;
                                                                        } else {
                                                                            v1266 = false;
                                                                        }
                                                                        bool v1267;
                                                                        v1267 = v1266 == false;
                                                                        if (v1267){
                                                                            assert("The read index needs to be in range for the static array." && v1266);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1268;
                                                                        v1268 = v1228.v[v1262];
                                                                        long v1269;
                                                                        v1269 = 4l + v1262;
                                                                        bool v1270;
                                                                        v1270 = 0l <= v1269;
                                                                        bool v1272;
                                                                        if (v1270){
                                                                            bool v1271;
                                                                            v1271 = v1269 < 5l;
                                                                            v1272 = v1271;
                                                                        } else {
                                                                            v1272 = false;
                                                                        }
                                                                        bool v1273;
                                                                        v1273 = v1272 == false;
                                                                        if (v1273){
                                                                            assert("The read index needs to be in range for the static array." && v1272);
                                                                        } else {
                                                                        }
                                                                        v1239.v[v1269] = v1268;
                                                                        v1262 += 1l ;
                                                                    }
                                                                    v1280 = US9_1(v1239);
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
                                                    switch (v1280.tag) {
                                                        case 0: { // None
                                                            static_array<unsigned char,2l> v1282;
                                                            static_array<unsigned char,5l> v1283;
                                                            long v1284; long v1285; long v1286; unsigned char v1287;
                                                            Tuple20 tmp58 = Tuple20(0l, 0l, 0l, 12u);
                                                            v1284 = tmp58.v0; v1285 = tmp58.v1; v1286 = tmp58.v2; v1287 = tmp58.v3;
                                                            while (while_method_10(v1284)){
                                                                bool v1289;
                                                                v1289 = 0l <= v1284;
                                                                bool v1291;
                                                                if (v1289){
                                                                    bool v1290;
                                                                    v1290 = v1284 < 7l;
                                                                    v1291 = v1290;
                                                                } else {
                                                                    v1291 = false;
                                                                }
                                                                bool v1292;
                                                                v1292 = v1291 == false;
                                                                if (v1292){
                                                                    assert("The read index needs to be in range for the static array." && v1291);
                                                                } else {
                                                                }
                                                                unsigned char v1293;
                                                                v1293 = v126.v[v1284];
                                                                bool v1294;
                                                                v1294 = v1286 < 2l;
                                                                long v1307; long v1308; unsigned char v1309;
                                                                if (v1294){
                                                                    unsigned char v1295;
                                                                    v1295 = v1293 >> 2l;
                                                                    unsigned char v1296;
                                                                    v1296 = v1295 & 15u;
                                                                    bool v1297;
                                                                    v1297 = v1287 == v1296;
                                                                    long v1298;
                                                                    if (v1297){
                                                                        v1298 = v1286;
                                                                    } else {
                                                                        v1298 = 0l;
                                                                    }
                                                                    bool v1299;
                                                                    v1299 = 0l <= v1298;
                                                                    bool v1301;
                                                                    if (v1299){
                                                                        bool v1300;
                                                                        v1300 = v1298 < 2l;
                                                                        v1301 = v1300;
                                                                    } else {
                                                                        v1301 = false;
                                                                    }
                                                                    bool v1302;
                                                                    v1302 = v1301 == false;
                                                                    if (v1302){
                                                                        assert("The read index needs to be in range for the static array." && v1301);
                                                                    } else {
                                                                    }
                                                                    v1282.v[v1298] = v1293;
                                                                    long v1303;
                                                                    v1303 = v1298 + 1l;
                                                                    v1307 = v1284; v1308 = v1303; v1309 = v1296;
                                                                } else {
                                                                    break;
                                                                }
                                                                v1285 = v1307;
                                                                v1286 = v1308;
                                                                v1287 = v1309;
                                                                v1284 += 1l ;
                                                            }
                                                            bool v1310;
                                                            v1310 = v1286 == 2l;
                                                            US13 v1328;
                                                            if (v1310){
                                                                long v1311;
                                                                v1311 = 0l;
                                                                while (while_method_2(v1311)){
                                                                    long v1313;
                                                                    v1313 = v1285 + -1l;
                                                                    bool v1314;
                                                                    v1314 = v1311 < v1313;
                                                                    long v1315;
                                                                    if (v1314){
                                                                        v1315 = 0l;
                                                                    } else {
                                                                        v1315 = 2l;
                                                                    }
                                                                    long v1316;
                                                                    v1316 = v1315 + v1311;
                                                                    bool v1317;
                                                                    v1317 = 0l <= v1316;
                                                                    bool v1319;
                                                                    if (v1317){
                                                                        bool v1318;
                                                                        v1318 = v1316 < 7l;
                                                                        v1319 = v1318;
                                                                    } else {
                                                                        v1319 = false;
                                                                    }
                                                                    bool v1320;
                                                                    v1320 = v1319 == false;
                                                                    if (v1320){
                                                                        assert("The read index needs to be in range for the static array." && v1319);
                                                                    } else {
                                                                    }
                                                                    unsigned char v1321;
                                                                    v1321 = v126.v[v1316];
                                                                    bool v1322;
                                                                    v1322 = 0l <= v1311;
                                                                    bool v1324;
                                                                    if (v1322){
                                                                        bool v1323;
                                                                        v1323 = v1311 < 5l;
                                                                        v1324 = v1323;
                                                                    } else {
                                                                        v1324 = false;
                                                                    }
                                                                    bool v1325;
                                                                    v1325 = v1324 == false;
                                                                    if (v1325){
                                                                        assert("The read index needs to be in range for the static array." && v1324);
                                                                    } else {
                                                                    }
                                                                    v1283.v[v1311] = v1321;
                                                                    v1311 += 1l ;
                                                                }
                                                                v1328 = US13_1(v1282, v1283);
                                                            } else {
                                                                v1328 = US13_0();
                                                            }
                                                            US9 v1368;
                                                            switch (v1328.tag) {
                                                                case 0: { // None
                                                                    v1368 = US9_0();
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<unsigned char,2l> v1329 = v1328.v.case1.v0; static_array<unsigned char,5l> v1330 = v1328.v.case1.v1;
                                                                    static_array<unsigned char,3l> v1331;
                                                                    long v1332;
                                                                    v1332 = 0l;
                                                                    while (while_method_3(v1332)){
                                                                        bool v1334;
                                                                        v1334 = 0l <= v1332;
                                                                        bool v1336;
                                                                        if (v1334){
                                                                            bool v1335;
                                                                            v1335 = v1332 < 5l;
                                                                            v1336 = v1335;
                                                                        } else {
                                                                            v1336 = false;
                                                                        }
                                                                        bool v1337;
                                                                        v1337 = v1336 == false;
                                                                        if (v1337){
                                                                            assert("The read index needs to be in range for the static array." && v1336);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1338;
                                                                        v1338 = v1330.v[v1332];
                                                                        bool v1340;
                                                                        if (v1334){
                                                                            bool v1339;
                                                                            v1339 = v1332 < 3l;
                                                                            v1340 = v1339;
                                                                        } else {
                                                                            v1340 = false;
                                                                        }
                                                                        bool v1341;
                                                                        v1341 = v1340 == false;
                                                                        if (v1341){
                                                                            assert("The read index needs to be in range for the static array." && v1340);
                                                                        } else {
                                                                        }
                                                                        v1331.v[v1332] = v1338;
                                                                        v1332 += 1l ;
                                                                    }
                                                                    static_array<unsigned char,5l> v1342;
                                                                    long v1343;
                                                                    v1343 = 0l;
                                                                    while (while_method_0(v1343)){
                                                                        bool v1345;
                                                                        v1345 = 0l <= v1343;
                                                                        bool v1347;
                                                                        if (v1345){
                                                                            bool v1346;
                                                                            v1346 = v1343 < 2l;
                                                                            v1347 = v1346;
                                                                        } else {
                                                                            v1347 = false;
                                                                        }
                                                                        bool v1348;
                                                                        v1348 = v1347 == false;
                                                                        if (v1348){
                                                                            assert("The read index needs to be in range for the static array." && v1347);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1349;
                                                                        v1349 = v1329.v[v1343];
                                                                        bool v1351;
                                                                        if (v1345){
                                                                            bool v1350;
                                                                            v1350 = v1343 < 5l;
                                                                            v1351 = v1350;
                                                                        } else {
                                                                            v1351 = false;
                                                                        }
                                                                        bool v1352;
                                                                        v1352 = v1351 == false;
                                                                        if (v1352){
                                                                            assert("The read index needs to be in range for the static array." && v1351);
                                                                        } else {
                                                                        }
                                                                        v1342.v[v1343] = v1349;
                                                                        v1343 += 1l ;
                                                                    }
                                                                    long v1353;
                                                                    v1353 = 0l;
                                                                    while (while_method_3(v1353)){
                                                                        bool v1355;
                                                                        v1355 = 0l <= v1353;
                                                                        bool v1357;
                                                                        if (v1355){
                                                                            bool v1356;
                                                                            v1356 = v1353 < 3l;
                                                                            v1357 = v1356;
                                                                        } else {
                                                                            v1357 = false;
                                                                        }
                                                                        bool v1358;
                                                                        v1358 = v1357 == false;
                                                                        if (v1358){
                                                                            assert("The read index needs to be in range for the static array." && v1357);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1359;
                                                                        v1359 = v1331.v[v1353];
                                                                        long v1360;
                                                                        v1360 = 2l + v1353;
                                                                        bool v1361;
                                                                        v1361 = 0l <= v1360;
                                                                        bool v1363;
                                                                        if (v1361){
                                                                            bool v1362;
                                                                            v1362 = v1360 < 5l;
                                                                            v1363 = v1362;
                                                                        } else {
                                                                            v1363 = false;
                                                                        }
                                                                        bool v1364;
                                                                        v1364 = v1363 == false;
                                                                        if (v1364){
                                                                            assert("The read index needs to be in range for the static array." && v1363);
                                                                        } else {
                                                                        }
                                                                        v1342.v[v1360] = v1359;
                                                                        v1353 += 1l ;
                                                                    }
                                                                    v1368 = US9_1(v1342);
                                                                    break;
                                                                }
                                                                default: {
                                                                    assert("Invalid tag." && false);
                                                                }
                                                            }
                                                            switch (v1368.tag) {
                                                                case 0: { // None
                                                                    static_array<unsigned char,5l> v1370;
                                                                    long v1371;
                                                                    v1371 = 0l;
                                                                    while (while_method_2(v1371)){
                                                                        bool v1373;
                                                                        v1373 = 0l <= v1371;
                                                                        bool v1375;
                                                                        if (v1373){
                                                                            bool v1374;
                                                                            v1374 = v1371 < 7l;
                                                                            v1375 = v1374;
                                                                        } else {
                                                                            v1375 = false;
                                                                        }
                                                                        bool v1376;
                                                                        v1376 = v1375 == false;
                                                                        if (v1376){
                                                                            assert("The read index needs to be in range for the static array." && v1375);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1377;
                                                                        v1377 = v126.v[v1371];
                                                                        bool v1379;
                                                                        if (v1373){
                                                                            bool v1378;
                                                                            v1378 = v1371 < 5l;
                                                                            v1379 = v1378;
                                                                        } else {
                                                                            v1379 = false;
                                                                        }
                                                                        bool v1380;
                                                                        v1380 = v1379 == false;
                                                                        if (v1380){
                                                                            assert("The read index needs to be in range for the static array." && v1379);
                                                                        } else {
                                                                        }
                                                                        v1370.v[v1371] = v1377;
                                                                        v1371 += 1l ;
                                                                    }
                                                                    v1411 = v1370; v1412 = 0;
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<unsigned char,5l> v1369 = v1368.v.case1.v0;
                                                                    v1411 = v1369; v1412 = 1;
                                                                    break;
                                                                }
                                                                default: {
                                                                    assert("Invalid tag." && false);
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        case 1: { // Some
                                                            static_array<unsigned char,5l> v1281 = v1280.v.case1.v0;
                                                            v1411 = v1281; v1412 = 2;
                                                            break;
                                                        }
                                                        default: {
                                                            assert("Invalid tag." && false);
                                                        }
                                                    }
                                                    break;
                                                }
                                                case 1: { // Some
                                                    static_array<unsigned char,5l> v1129 = v1128.v.case1.v0;
                                                    v1411 = v1129; v1412 = 3;
                                                    break;
                                                }
                                                default: {
                                                    assert("Invalid tag." && false);
                                                }
                                            }
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v1041 = v1040.v.case1.v0;
                                            v1411 = v1041; v1412 = 4;
                                            break;
                                        }
                                        default: {
                                            assert("Invalid tag." && false);
                                        }
                                    }
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v995 = v994.v.case1.v0;
                                    v1411 = v995; v1412 = 5;
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            break;
                        }
                        case 1: { // Some
                            static_array<unsigned char,5l> v789 = v788.v.case1.v0;
                            v1411 = v789; v1412 = 6;
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v660 = v659.v.case1.v0;
                    v1411 = v660; v1412 = 7;
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v572 = v571.v.case1.v0;
            v1411 = v572; v1412 = 8;
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    return Tuple0(v1411, v1412);
}
__device__ US5 play_loop_inner_33(unsigned long long & v0, static_array_list<US3,128l,long> & v1, curandStatePhilox4_32_10_t & v2, static_array<US2,2l> v3, US5 v4){
    static_array_list<US3,128l,long> & v5 = v1;
    unsigned long long & v6 = v0;
    bool v7; US5 v8;
    Tuple9 tmp16 = Tuple9(true, v4);
    v7 = tmp16.v0; v8 = tmp16.v1;
    while (while_method_5(v7, v8)){
        bool v806; US5 v807;
        switch (v8.tag) {
            case 0: { // G_Flop
                long v632 = v8.v.case0.v0; bool v633 = v8.v.case0.v1; static_array<static_array<unsigned char,2l>,2l> v634 = v8.v.case0.v2; long v635 = v8.v.case0.v3; static_array<long,2l> v636 = v8.v.case0.v4; static_array<long,2l> v637 = v8.v.case0.v5; US6 v638 = v8.v.case0.v6;
                static_array<unsigned char,3l> v639; unsigned long long v640;
                Tuple10 tmp19 = draw_cards_34(v2, v6);
                v639 = tmp19.v0; v640 = tmp19.v1;
                v0 = v640;
                static_array_list<unsigned char,5l,long> v641;
                v641 = get_community_cards_37(v638, v639);
                long v642;
                v642 = v5.length;
                bool v643;
                v643 = v642 < 128l;
                bool v644;
                v644 = v643 == false;
                if (v644){
                    assert("The length has to be less than the maximum length of the array." && v643);
                } else {
                }
                long v645;
                v645 = v642 + 1l;
                v5.length = v645;
                bool v646;
                v646 = 0l <= v642;
                bool v649;
                if (v646){
                    long v647;
                    v647 = v5.length;
                    bool v648;
                    v648 = v642 < v647;
                    v649 = v648;
                } else {
                    v649 = false;
                }
                bool v650;
                v650 = v649 == false;
                if (v650){
                    assert("The set index needs to be in range for the static array list." && v649);
                } else {
                }
                US3 v651;
                v651 = US3_0(v641);
                v5.v[v642] = v651;
                US6 v654;
                switch (v638.tag) {
                    case 1: { // Preflop
                        v654 = US6_0(v639);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in flop.");
                        asm("exit;");
                    }
                }
                US5 v655;
                v655 = US5_4(v632, true, v634, 0l, v636, v637, v654);
                v806 = true; v807 = v655;
                break;
            }
            case 1: { // G_Fold
                long v10 = v8.v.case1.v0; bool v11 = v8.v.case1.v1; static_array<static_array<unsigned char,2l>,2l> v12 = v8.v.case1.v2; long v13 = v8.v.case1.v3; static_array<long,2l> v14 = v8.v.case1.v4; static_array<long,2l> v15 = v8.v.case1.v5; US6 v16 = v8.v.case1.v6;
                bool v17;
                v17 = 0l <= v13;
                bool v19;
                if (v17){
                    bool v18;
                    v18 = v13 < 2l;
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
                long v21;
                v21 = v14.v[v13];
                long v22;
                v22 = v13 ^ 1l;
                long v23;
                v23 = v5.length;
                bool v24;
                v24 = v23 < 128l;
                bool v25;
                v25 = v24 == false;
                if (v25){
                    assert("The length has to be less than the maximum length of the array." && v24);
                } else {
                }
                long v26;
                v26 = v23 + 1l;
                v5.length = v26;
                bool v27;
                v27 = 0l <= v23;
                bool v30;
                if (v27){
                    long v28;
                    v28 = v5.length;
                    bool v29;
                    v29 = v23 < v28;
                    v30 = v29;
                } else {
                    v30 = false;
                }
                bool v31;
                v31 = v30 == false;
                if (v31){
                    assert("The set index needs to be in range for the static array list." && v30);
                } else {
                }
                US3 v32;
                v32 = US3_1(v21, v22);
                v5.v[v23] = v32;
                v806 = false; v807 = v8;
                break;
            }
            case 2: { // G_Preflop
                static_array<unsigned char,2l> v752; unsigned long long v753;
                Tuple13 tmp22 = draw_cards_38(v2, v6);
                v752 = tmp22.v0; v753 = tmp22.v1;
                v0 = v753;
                static_array<unsigned char,2l> v754; unsigned long long v755;
                Tuple13 tmp23 = draw_cards_38(v2, v6);
                v754 = tmp23.v0; v755 = tmp23.v1;
                v0 = v755;
                long v756;
                v756 = v5.length;
                bool v757;
                v757 = v756 < 128l;
                bool v758;
                v758 = v757 == false;
                if (v758){
                    assert("The length has to be less than the maximum length of the array." && v757);
                } else {
                }
                long v759;
                v759 = v756 + 1l;
                v5.length = v759;
                bool v760;
                v760 = 0l <= v756;
                bool v763;
                if (v760){
                    long v761;
                    v761 = v5.length;
                    bool v762;
                    v762 = v756 < v761;
                    v763 = v762;
                } else {
                    v763 = false;
                }
                bool v764;
                v764 = v763 == false;
                if (v764){
                    assert("The set index needs to be in range for the static array list." && v763);
                } else {
                }
                US3 v765;
                v765 = US3_3(0l, v752);
                v5.v[v756] = v765;
                long v766;
                v766 = v5.length;
                bool v767;
                v767 = v766 < 128l;
                bool v768;
                v768 = v767 == false;
                if (v768){
                    assert("The length has to be less than the maximum length of the array." && v767);
                } else {
                }
                long v769;
                v769 = v766 + 1l;
                v5.length = v769;
                bool v770;
                v770 = 0l <= v766;
                bool v773;
                if (v770){
                    long v771;
                    v771 = v5.length;
                    bool v772;
                    v772 = v766 < v771;
                    v773 = v772;
                } else {
                    v773 = false;
                }
                bool v774;
                v774 = v773 == false;
                if (v774){
                    assert("The set index needs to be in range for the static array list." && v773);
                } else {
                }
                US3 v775;
                v775 = US3_3(1l, v754);
                v5.v[v766] = v775;
                static_array<static_array<unsigned char,2l>,2l> v776;
                v776.v[0l] = v752;
                v776.v[1l] = v754;
                static_array<long,2l> v777;
                v777.v[0l] = 2l;
                v777.v[1l] = 1l;
                static_array<long,2l> v778;
                long v779;
                v779 = 0l;
                while (while_method_0(v779)){
                    bool v781;
                    v781 = 0l <= v779;
                    bool v783;
                    if (v781){
                        bool v782;
                        v782 = v779 < 2l;
                        v783 = v782;
                    } else {
                        v783 = false;
                    }
                    bool v784;
                    v784 = v783 == false;
                    if (v784){
                        assert("The read index needs to be in range for the static array." && v783);
                    } else {
                    }
                    long v785;
                    v785 = v777.v[v779];
                    long v786;
                    v786 = 100l - v785;
                    bool v788;
                    if (v781){
                        bool v787;
                        v787 = v779 < 2l;
                        v788 = v787;
                    } else {
                        v788 = false;
                    }
                    bool v789;
                    v789 = v788 == false;
                    if (v789){
                        assert("The read index needs to be in range for the static array." && v788);
                    } else {
                    }
                    v778.v[v779] = v786;
                    v779 += 1l ;
                }
                US6 v790;
                v790 = US6_1();
                US5 v791;
                v791 = US5_4(2l, true, v776, 0l, v777, v778, v790);
                v806 = true; v807 = v791;
                break;
            }
            case 3: { // G_River
                long v704 = v8.v.case3.v0; bool v705 = v8.v.case3.v1; static_array<static_array<unsigned char,2l>,2l> v706 = v8.v.case3.v2; long v707 = v8.v.case3.v3; static_array<long,2l> v708 = v8.v.case3.v4; static_array<long,2l> v709 = v8.v.case3.v5; US6 v710 = v8.v.case3.v6;
                static_array<unsigned char,1l> v711; unsigned long long v712;
                Tuple14 tmp26 = draw_cards_39(v2, v6);
                v711 = tmp26.v0; v712 = tmp26.v1;
                v0 = v712;
                static_array_list<unsigned char,5l,long> v713;
                v713 = get_community_cards_40(v710, v711);
                long v714;
                v714 = v5.length;
                bool v715;
                v715 = v714 < 128l;
                bool v716;
                v716 = v715 == false;
                if (v716){
                    assert("The length has to be less than the maximum length of the array." && v715);
                } else {
                }
                long v717;
                v717 = v714 + 1l;
                v5.length = v717;
                bool v718;
                v718 = 0l <= v714;
                bool v721;
                if (v718){
                    long v719;
                    v719 = v5.length;
                    bool v720;
                    v720 = v714 < v719;
                    v721 = v720;
                } else {
                    v721 = false;
                }
                bool v722;
                v722 = v721 == false;
                if (v722){
                    assert("The set index needs to be in range for the static array list." && v721);
                } else {
                }
                US3 v723;
                v723 = US3_0(v713);
                v5.v[v714] = v723;
                US6 v750;
                switch (v710.tag) {
                    case 3: { // Turn
                        static_array<unsigned char,4l> v724 = v710.v.case3.v0;
                        static_array<unsigned char,5l> v725;
                        long v726;
                        v726 = 0l;
                        while (while_method_4(v726)){
                            bool v728;
                            v728 = 0l <= v726;
                            bool v730;
                            if (v728){
                                bool v729;
                                v729 = v726 < 4l;
                                v730 = v729;
                            } else {
                                v730 = false;
                            }
                            bool v731;
                            v731 = v730 == false;
                            if (v731){
                                assert("The read index needs to be in range for the static array." && v730);
                            } else {
                            }
                            unsigned char v732;
                            v732 = v724.v[v726];
                            bool v734;
                            if (v728){
                                bool v733;
                                v733 = v726 < 5l;
                                v734 = v733;
                            } else {
                                v734 = false;
                            }
                            bool v735;
                            v735 = v734 == false;
                            if (v735){
                                assert("The read index needs to be in range for the static array." && v734);
                            } else {
                            }
                            v725.v[v726] = v732;
                            v726 += 1l ;
                        }
                        long v736;
                        v736 = 0l;
                        while (while_method_6(v736)){
                            bool v738;
                            v738 = 0l <= v736;
                            bool v740;
                            if (v738){
                                bool v739;
                                v739 = v736 < 1l;
                                v740 = v739;
                            } else {
                                v740 = false;
                            }
                            bool v741;
                            v741 = v740 == false;
                            if (v741){
                                assert("The read index needs to be in range for the static array." && v740);
                            } else {
                            }
                            unsigned char v742;
                            v742 = v711.v[v736];
                            long v743;
                            v743 = 4l + v736;
                            bool v744;
                            v744 = 0l <= v743;
                            bool v746;
                            if (v744){
                                bool v745;
                                v745 = v743 < 5l;
                                v746 = v745;
                            } else {
                                v746 = false;
                            }
                            bool v747;
                            v747 = v746 == false;
                            if (v747){
                                assert("The read index needs to be in range for the static array." && v746);
                            } else {
                            }
                            v725.v[v743] = v742;
                            v736 += 1l ;
                        }
                        v750 = US6_2(v725);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in river.");
                        asm("exit;");
                    }
                }
                US5 v751;
                v751 = US5_4(v704, true, v706, 0l, v708, v709, v750);
                v806 = true; v807 = v751;
                break;
            }
            case 4: { // G_Round
                long v146 = v8.v.case4.v0; bool v147 = v8.v.case4.v1; static_array<static_array<unsigned char,2l>,2l> v148 = v8.v.case4.v2; long v149 = v8.v.case4.v3; static_array<long,2l> v150 = v8.v.case4.v4; static_array<long,2l> v151 = v8.v.case4.v5; US6 v152 = v8.v.case4.v6;
                bool v153;
                v153 = 0l <= v149;
                bool v155;
                if (v153){
                    bool v154;
                    v154 = v149 < 2l;
                    v155 = v154;
                } else {
                    v155 = false;
                }
                bool v156;
                v156 = v155 == false;
                if (v156){
                    assert("The read index needs to be in range for the static array." && v155);
                } else {
                }
                US2 v157;
                v157 = v3.v[v149];
                switch (v157.tag) {
                    case 0: { // Computer
                        static_array<long,2l> v158;
                        long v159;
                        v159 = 0l;
                        while (while_method_0(v159)){
                            bool v161;
                            v161 = 0l <= v159;
                            bool v163;
                            if (v161){
                                bool v162;
                                v162 = v159 < 2l;
                                v163 = v162;
                            } else {
                                v163 = false;
                            }
                            bool v164;
                            v164 = v163 == false;
                            if (v164){
                                assert("The read index needs to be in range for the static array." && v163);
                            } else {
                            }
                            long v165;
                            v165 = v151.v[v159];
                            bool v167;
                            if (v161){
                                bool v166;
                                v166 = v159 < 2l;
                                v167 = v166;
                            } else {
                                v167 = false;
                            }
                            bool v168;
                            v168 = v167 == false;
                            if (v168){
                                assert("The read index needs to be in range for the static array." && v167);
                            } else {
                            }
                            long v169;
                            v169 = v150.v[v159];
                            long v170;
                            v170 = v165 + v169;
                            bool v172;
                            if (v161){
                                bool v171;
                                v171 = v159 < 2l;
                                v172 = v171;
                            } else {
                                v172 = false;
                            }
                            bool v173;
                            v173 = v172 == false;
                            if (v173){
                                assert("The read index needs to be in range for the static array." && v172);
                            } else {
                            }
                            v158.v[v159] = v170;
                            v159 += 1l ;
                        }
                        long v174;
                        v174 = v150.v[0l];
                        long v175; long v176;
                        Tuple2 tmp27 = Tuple2(1l, v174);
                        v175 = tmp27.v0; v176 = tmp27.v1;
                        while (while_method_0(v175)){
                            bool v178;
                            v178 = 0l <= v175;
                            bool v180;
                            if (v178){
                                bool v179;
                                v179 = v175 < 2l;
                                v180 = v179;
                            } else {
                                v180 = false;
                            }
                            bool v181;
                            v181 = v180 == false;
                            if (v181){
                                assert("The read index needs to be in range for the static array." && v180);
                            } else {
                            }
                            long v182;
                            v182 = v150.v[v175];
                            bool v183;
                            v183 = v176 >= v182;
                            long v184;
                            if (v183){
                                v184 = v176;
                            } else {
                                v184 = v182;
                            }
                            v176 = v184;
                            v175 += 1l ;
                        }
                        static_array<long,2l> v185;
                        long v186;
                        v186 = 0l;
                        while (while_method_0(v186)){
                            bool v188;
                            v188 = 0l <= v186;
                            bool v190;
                            if (v188){
                                bool v189;
                                v189 = v186 < 2l;
                                v190 = v189;
                            } else {
                                v190 = false;
                            }
                            bool v191;
                            v191 = v190 == false;
                            if (v191){
                                assert("The read index needs to be in range for the static array." && v190);
                            } else {
                            }
                            long v192;
                            v192 = v158.v[v186];
                            bool v193;
                            v193 = v149 == v186;
                            long v196;
                            if (v193){
                                bool v194;
                                v194 = v176 < v192;
                                if (v194){
                                    v196 = v176;
                                } else {
                                    v196 = v192;
                                }
                            } else {
                                v196 = v192;
                            }
                            bool v198;
                            if (v188){
                                bool v197;
                                v197 = v186 < 2l;
                                v198 = v197;
                            } else {
                                v198 = false;
                            }
                            bool v199;
                            v199 = v198 == false;
                            if (v199){
                                assert("The read index needs to be in range for the static array." && v198);
                            } else {
                            }
                            v185.v[v186] = v196;
                            v186 += 1l ;
                        }
                        static_array<long,2l> v200;
                        long v201;
                        v201 = 0l;
                        while (while_method_0(v201)){
                            bool v203;
                            v203 = 0l <= v201;
                            bool v205;
                            if (v203){
                                bool v204;
                                v204 = v201 < 2l;
                                v205 = v204;
                            } else {
                                v205 = false;
                            }
                            bool v206;
                            v206 = v205 == false;
                            if (v206){
                                assert("The read index needs to be in range for the static array." && v205);
                            } else {
                            }
                            long v207;
                            v207 = v158.v[v201];
                            bool v209;
                            if (v203){
                                bool v208;
                                v208 = v201 < 2l;
                                v209 = v208;
                            } else {
                                v209 = false;
                            }
                            bool v210;
                            v210 = v209 == false;
                            if (v210){
                                assert("The read index needs to be in range for the static array." && v209);
                            } else {
                            }
                            long v211;
                            v211 = v185.v[v201];
                            long v212;
                            v212 = v207 - v211;
                            bool v214;
                            if (v203){
                                bool v213;
                                v213 = v201 < 2l;
                                v214 = v213;
                            } else {
                                v214 = false;
                            }
                            bool v215;
                            v215 = v214 == false;
                            if (v215){
                                assert("The read index needs to be in range for the static array." && v214);
                            } else {
                            }
                            v200.v[v201] = v212;
                            v201 += 1l ;
                        }
                        long v216;
                        v216 = v185.v[0l];
                        long v217; long v218;
                        Tuple2 tmp28 = Tuple2(1l, v216);
                        v217 = tmp28.v0; v218 = tmp28.v1;
                        while (while_method_0(v217)){
                            bool v220;
                            v220 = 0l <= v217;
                            bool v222;
                            if (v220){
                                bool v221;
                                v221 = v217 < 2l;
                                v222 = v221;
                            } else {
                                v222 = false;
                            }
                            bool v223;
                            v223 = v222 == false;
                            if (v223){
                                assert("The read index needs to be in range for the static array." && v222);
                            } else {
                            }
                            long v224;
                            v224 = v185.v[v217];
                            long v225;
                            v225 = v218 + v224;
                            v218 = v225;
                            v217 += 1l ;
                        }
                        bool v227;
                        if (v153){
                            bool v226;
                            v226 = v149 < 2l;
                            v227 = v226;
                        } else {
                            v227 = false;
                        }
                        bool v228;
                        v228 = v227 == false;
                        if (v228){
                            assert("The read index needs to be in range for the static array." && v227);
                        } else {
                        }
                        long v229;
                        v229 = v150.v[v149];
                        long v230;
                        v230 = v149 ^ 1l;
                        bool v231;
                        v231 = 0l <= v230;
                        bool v233;
                        if (v231){
                            bool v232;
                            v232 = v230 < 2l;
                            v233 = v232;
                        } else {
                            v233 = false;
                        }
                        bool v234;
                        v234 = v233 == false;
                        if (v234){
                            assert("The read index needs to be in range for the static array." && v233);
                        } else {
                        }
                        long v235;
                        v235 = v150.v[v230];
                        bool v236;
                        v236 = v229 < v235;
                        float v237;
                        if (v236){
                            v237 = 1.0f;
                        } else {
                            v237 = 0.0f;
                        }
                        long v238;
                        v238 = v218 / 4l;
                        bool v240;
                        if (v153){
                            bool v239;
                            v239 = v149 < 2l;
                            v240 = v239;
                        } else {
                            v240 = false;
                        }
                        bool v241;
                        v241 = v240 == false;
                        if (v241){
                            assert("The read index needs to be in range for the static array." && v240);
                        } else {
                        }
                        long v242;
                        v242 = v200.v[v149];
                        bool v243;
                        v243 = v238 <= v242;
                        float v244;
                        if (v243){
                            v244 = 1.0f;
                        } else {
                            v244 = 0.0f;
                        }
                        long v245;
                        v245 = v218 / 3l;
                        bool v247;
                        if (v153){
                            bool v246;
                            v246 = v149 < 2l;
                            v247 = v246;
                        } else {
                            v247 = false;
                        }
                        bool v248;
                        v248 = v247 == false;
                        if (v248){
                            assert("The read index needs to be in range for the static array." && v247);
                        } else {
                        }
                        long v249;
                        v249 = v200.v[v149];
                        bool v250;
                        v250 = v245 <= v249;
                        float v251;
                        if (v250){
                            v251 = 1.0f;
                        } else {
                            v251 = 0.0f;
                        }
                        long v252;
                        v252 = v218 / 2l;
                        bool v254;
                        if (v153){
                            bool v253;
                            v253 = v149 < 2l;
                            v254 = v253;
                        } else {
                            v254 = false;
                        }
                        bool v255;
                        v255 = v254 == false;
                        if (v255){
                            assert("The read index needs to be in range for the static array." && v254);
                        } else {
                        }
                        long v256;
                        v256 = v200.v[v149];
                        bool v257;
                        v257 = v252 <= v256;
                        float v258;
                        if (v257){
                            v258 = 1.0f;
                        } else {
                            v258 = 0.0f;
                        }
                        bool v260;
                        if (v153){
                            bool v259;
                            v259 = v149 < 2l;
                            v260 = v259;
                        } else {
                            v260 = false;
                        }
                        bool v261;
                        v261 = v260 == false;
                        if (v261){
                            assert("The read index needs to be in range for the static array." && v260);
                        } else {
                        }
                        long v262;
                        v262 = v200.v[v149];
                        bool v263;
                        v263 = v218 <= v262;
                        float v264;
                        if (v263){
                            v264 = 1.0f;
                        } else {
                            v264 = 0.0f;
                        }
                        long v265;
                        v265 = v218 * 3l;
                        long v266;
                        v266 = v265 / 2l;
                        bool v268;
                        if (v153){
                            bool v267;
                            v267 = v149 < 2l;
                            v268 = v267;
                        } else {
                            v268 = false;
                        }
                        bool v269;
                        v269 = v268 == false;
                        if (v269){
                            assert("The read index needs to be in range for the static array." && v268);
                        } else {
                        }
                        long v270;
                        v270 = v200.v[v149];
                        bool v271;
                        v271 = v266 <= v270;
                        float v272;
                        if (v271){
                            v272 = 1.0f;
                        } else {
                            v272 = 0.0f;
                        }
                        bool v274;
                        if (v153){
                            bool v273;
                            v273 = v149 < 2l;
                            v274 = v273;
                        } else {
                            v274 = false;
                        }
                        bool v275;
                        v275 = v274 == false;
                        if (v275){
                            assert("The read index needs to be in range for the static array." && v274);
                        } else {
                        }
                        long v276;
                        v276 = v200.v[v149];
                        bool v278;
                        if (v153){
                            bool v277;
                            v277 = v149 < 2l;
                            v278 = v277;
                        } else {
                            v278 = false;
                        }
                        bool v279;
                        v279 = v278 == false;
                        if (v279){
                            assert("The read index needs to be in range for the static array." && v278);
                        } else {
                        }
                        long v280;
                        v280 = v200.v[v149];
                        bool v281;
                        v281 = v276 <= v280;
                        float v282;
                        if (v281){
                            v282 = 1.0f;
                        } else {
                            v282 = 0.0f;
                        }
                        static_array<Tuple15,8l> v283;
                        US1 v284;
                        v284 = US1_1();
                        v283.v[0l] = Tuple15(v284, v237);
                        US1 v285;
                        v285 = US1_0();
                        v283.v[1l] = Tuple15(v285, 2.0f);
                        US1 v286;
                        v286 = US1_2(v238);
                        v283.v[2l] = Tuple15(v286, v244);
                        US1 v287;
                        v287 = US1_2(v245);
                        v283.v[3l] = Tuple15(v287, v251);
                        US1 v288;
                        v288 = US1_2(v252);
                        v283.v[4l] = Tuple15(v288, v258);
                        US1 v289;
                        v289 = US1_2(v218);
                        v283.v[5l] = Tuple15(v289, v264);
                        US1 v290;
                        v290 = US1_2(v266);
                        v283.v[6l] = Tuple15(v290, v272);
                        US1 v291;
                        v291 = US1_2(v276);
                        v283.v[7l] = Tuple15(v291, v282);
                        US1 v292;
                        v292 = sample_discrete_41(v283, v2);
                        long v293;
                        v293 = v5.length;
                        bool v294;
                        v294 = v293 < 128l;
                        bool v295;
                        v295 = v294 == false;
                        if (v295){
                            assert("The length has to be less than the maximum length of the array." && v294);
                        } else {
                        }
                        long v296;
                        v296 = v293 + 1l;
                        v5.length = v296;
                        bool v297;
                        v297 = 0l <= v293;
                        bool v300;
                        if (v297){
                            long v298;
                            v298 = v5.length;
                            bool v299;
                            v299 = v293 < v298;
                            v300 = v299;
                        } else {
                            v300 = false;
                        }
                        bool v301;
                        v301 = v300 == false;
                        if (v301){
                            assert("The set index needs to be in range for the static array list." && v300);
                        } else {
                        }
                        US3 v302;
                        v302 = US3_2(v149, v292);
                        v5.v[v293] = v302;
                        US5 v454;
                        switch (v292.tag) {
                            case 0: { // A_Call
                                static_array<long,2l> v304;
                                long v305;
                                v305 = 0l;
                                while (while_method_0(v305)){
                                    bool v307;
                                    v307 = 0l <= v305;
                                    bool v309;
                                    if (v307){
                                        bool v308;
                                        v308 = v305 < 2l;
                                        v309 = v308;
                                    } else {
                                        v309 = false;
                                    }
                                    bool v310;
                                    v310 = v309 == false;
                                    if (v310){
                                        assert("The read index needs to be in range for the static array." && v309);
                                    } else {
                                    }
                                    long v311;
                                    v311 = v151.v[v305];
                                    bool v313;
                                    if (v307){
                                        bool v312;
                                        v312 = v305 < 2l;
                                        v313 = v312;
                                    } else {
                                        v313 = false;
                                    }
                                    bool v314;
                                    v314 = v313 == false;
                                    if (v314){
                                        assert("The read index needs to be in range for the static array." && v313);
                                    } else {
                                    }
                                    long v315;
                                    v315 = v150.v[v305];
                                    long v316;
                                    v316 = v311 + v315;
                                    bool v318;
                                    if (v307){
                                        bool v317;
                                        v317 = v305 < 2l;
                                        v318 = v317;
                                    } else {
                                        v318 = false;
                                    }
                                    bool v319;
                                    v319 = v318 == false;
                                    if (v319){
                                        assert("The read index needs to be in range for the static array." && v318);
                                    } else {
                                    }
                                    v304.v[v305] = v316;
                                    v305 += 1l ;
                                }
                                long v320;
                                v320 = v150.v[0l];
                                long v321; long v322;
                                Tuple2 tmp31 = Tuple2(1l, v320);
                                v321 = tmp31.v0; v322 = tmp31.v1;
                                while (while_method_0(v321)){
                                    bool v324;
                                    v324 = 0l <= v321;
                                    bool v326;
                                    if (v324){
                                        bool v325;
                                        v325 = v321 < 2l;
                                        v326 = v325;
                                    } else {
                                        v326 = false;
                                    }
                                    bool v327;
                                    v327 = v326 == false;
                                    if (v327){
                                        assert("The read index needs to be in range for the static array." && v326);
                                    } else {
                                    }
                                    long v328;
                                    v328 = v150.v[v321];
                                    bool v329;
                                    v329 = v322 >= v328;
                                    long v330;
                                    if (v329){
                                        v330 = v322;
                                    } else {
                                        v330 = v328;
                                    }
                                    v322 = v330;
                                    v321 += 1l ;
                                }
                                static_array<long,2l> v331;
                                long v332;
                                v332 = 0l;
                                while (while_method_0(v332)){
                                    bool v334;
                                    v334 = 0l <= v332;
                                    bool v336;
                                    if (v334){
                                        bool v335;
                                        v335 = v332 < 2l;
                                        v336 = v335;
                                    } else {
                                        v336 = false;
                                    }
                                    bool v337;
                                    v337 = v336 == false;
                                    if (v337){
                                        assert("The read index needs to be in range for the static array." && v336);
                                    } else {
                                    }
                                    long v338;
                                    v338 = v304.v[v332];
                                    bool v339;
                                    v339 = v149 == v332;
                                    long v342;
                                    if (v339){
                                        bool v340;
                                        v340 = v322 < v338;
                                        if (v340){
                                            v342 = v322;
                                        } else {
                                            v342 = v338;
                                        }
                                    } else {
                                        v342 = v338;
                                    }
                                    bool v344;
                                    if (v334){
                                        bool v343;
                                        v343 = v332 < 2l;
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
                                    v331.v[v332] = v342;
                                    v332 += 1l ;
                                }
                                static_array<long,2l> v346;
                                long v347;
                                v347 = 0l;
                                while (while_method_0(v347)){
                                    bool v349;
                                    v349 = 0l <= v347;
                                    bool v351;
                                    if (v349){
                                        bool v350;
                                        v350 = v347 < 2l;
                                        v351 = v350;
                                    } else {
                                        v351 = false;
                                    }
                                    bool v352;
                                    v352 = v351 == false;
                                    if (v352){
                                        assert("The read index needs to be in range for the static array." && v351);
                                    } else {
                                    }
                                    long v353;
                                    v353 = v304.v[v347];
                                    bool v355;
                                    if (v349){
                                        bool v354;
                                        v354 = v347 < 2l;
                                        v355 = v354;
                                    } else {
                                        v355 = false;
                                    }
                                    bool v356;
                                    v356 = v355 == false;
                                    if (v356){
                                        assert("The read index needs to be in range for the static array." && v355);
                                    } else {
                                    }
                                    long v357;
                                    v357 = v331.v[v347];
                                    long v358;
                                    v358 = v353 - v357;
                                    bool v360;
                                    if (v349){
                                        bool v359;
                                        v359 = v347 < 2l;
                                        v360 = v359;
                                    } else {
                                        v360 = false;
                                    }
                                    bool v361;
                                    v361 = v360 == false;
                                    if (v361){
                                        assert("The read index needs to be in range for the static array." && v360);
                                    } else {
                                    }
                                    v346.v[v347] = v358;
                                    v347 += 1l ;
                                }
                                if (v147){
                                    v454 = US5_4(v146, false, v148, v230, v331, v346, v152);
                                } else {
                                    switch (v152.tag) {
                                        case 0: { // Flop
                                            static_array<unsigned char,3l> v364 = v152.v.case0.v0;
                                            v454 = US5_7(v146, v147, v148, v149, v331, v346, v152);
                                            break;
                                        }
                                        case 1: { // Preflop
                                            v454 = US5_0(v146, v147, v148, v149, v331, v346, v152);
                                            break;
                                        }
                                        case 2: { // River
                                            static_array<unsigned char,5l> v368 = v152.v.case2.v0;
                                            v454 = US5_6(v146, v147, v148, v149, v331, v346, v152);
                                            break;
                                        }
                                        case 3: { // Turn
                                            static_array<unsigned char,4l> v366 = v152.v.case3.v0;
                                            v454 = US5_3(v146, v147, v148, v149, v331, v346, v152);
                                            break;
                                        }
                                        default: {
                                            assert("Invalid tag." && false);
                                        }
                                    }
                                }
                                break;
                            }
                            case 1: { // A_Fold
                                v454 = US5_1(v146, v147, v148, v149, v150, v151, v152);
                                break;
                            }
                            case 2: { // A_Raise
                                long v375 = v292.v.case2.v0;
                                static_array<long,2l> v376;
                                long v377;
                                v377 = 0l;
                                while (while_method_0(v377)){
                                    bool v379;
                                    v379 = 0l <= v377;
                                    bool v381;
                                    if (v379){
                                        bool v380;
                                        v380 = v377 < 2l;
                                        v381 = v380;
                                    } else {
                                        v381 = false;
                                    }
                                    bool v382;
                                    v382 = v381 == false;
                                    if (v382){
                                        assert("The read index needs to be in range for the static array." && v381);
                                    } else {
                                    }
                                    long v383;
                                    v383 = v151.v[v377];
                                    bool v385;
                                    if (v379){
                                        bool v384;
                                        v384 = v377 < 2l;
                                        v385 = v384;
                                    } else {
                                        v385 = false;
                                    }
                                    bool v386;
                                    v386 = v385 == false;
                                    if (v386){
                                        assert("The read index needs to be in range for the static array." && v385);
                                    } else {
                                    }
                                    long v387;
                                    v387 = v150.v[v377];
                                    long v388;
                                    v388 = v383 + v387;
                                    bool v390;
                                    if (v379){
                                        bool v389;
                                        v389 = v377 < 2l;
                                        v390 = v389;
                                    } else {
                                        v390 = false;
                                    }
                                    bool v391;
                                    v391 = v390 == false;
                                    if (v391){
                                        assert("The read index needs to be in range for the static array." && v390);
                                    } else {
                                    }
                                    v376.v[v377] = v388;
                                    v377 += 1l ;
                                }
                                long v392;
                                v392 = v150.v[0l];
                                long v393; long v394;
                                Tuple2 tmp32 = Tuple2(1l, v392);
                                v393 = tmp32.v0; v394 = tmp32.v1;
                                while (while_method_0(v393)){
                                    bool v396;
                                    v396 = 0l <= v393;
                                    bool v398;
                                    if (v396){
                                        bool v397;
                                        v397 = v393 < 2l;
                                        v398 = v397;
                                    } else {
                                        v398 = false;
                                    }
                                    bool v399;
                                    v399 = v398 == false;
                                    if (v399){
                                        assert("The read index needs to be in range for the static array." && v398);
                                    } else {
                                    }
                                    long v400;
                                    v400 = v150.v[v393];
                                    bool v401;
                                    v401 = v394 >= v400;
                                    long v402;
                                    if (v401){
                                        v402 = v394;
                                    } else {
                                        v402 = v400;
                                    }
                                    v394 = v402;
                                    v393 += 1l ;
                                }
                                static_array<long,2l> v403;
                                long v404;
                                v404 = 0l;
                                while (while_method_0(v404)){
                                    bool v406;
                                    v406 = 0l <= v404;
                                    bool v408;
                                    if (v406){
                                        bool v407;
                                        v407 = v404 < 2l;
                                        v408 = v407;
                                    } else {
                                        v408 = false;
                                    }
                                    bool v409;
                                    v409 = v408 == false;
                                    if (v409){
                                        assert("The read index needs to be in range for the static array." && v408);
                                    } else {
                                    }
                                    long v410;
                                    v410 = v376.v[v404];
                                    bool v411;
                                    v411 = v149 == v404;
                                    long v414;
                                    if (v411){
                                        bool v412;
                                        v412 = v394 < v410;
                                        if (v412){
                                            v414 = v394;
                                        } else {
                                            v414 = v410;
                                        }
                                    } else {
                                        v414 = v410;
                                    }
                                    bool v416;
                                    if (v406){
                                        bool v415;
                                        v415 = v404 < 2l;
                                        v416 = v415;
                                    } else {
                                        v416 = false;
                                    }
                                    bool v417;
                                    v417 = v416 == false;
                                    if (v417){
                                        assert("The read index needs to be in range for the static array." && v416);
                                    } else {
                                    }
                                    v403.v[v404] = v414;
                                    v404 += 1l ;
                                }
                                static_array<long,2l> v418;
                                long v419;
                                v419 = 0l;
                                while (while_method_0(v419)){
                                    bool v421;
                                    v421 = 0l <= v419;
                                    bool v423;
                                    if (v421){
                                        bool v422;
                                        v422 = v419 < 2l;
                                        v423 = v422;
                                    } else {
                                        v423 = false;
                                    }
                                    bool v424;
                                    v424 = v423 == false;
                                    if (v424){
                                        assert("The read index needs to be in range for the static array." && v423);
                                    } else {
                                    }
                                    long v425;
                                    v425 = v376.v[v419];
                                    bool v427;
                                    if (v421){
                                        bool v426;
                                        v426 = v419 < 2l;
                                        v427 = v426;
                                    } else {
                                        v427 = false;
                                    }
                                    bool v428;
                                    v428 = v427 == false;
                                    if (v428){
                                        assert("The read index needs to be in range for the static array." && v427);
                                    } else {
                                    }
                                    long v429;
                                    v429 = v403.v[v419];
                                    long v430;
                                    v430 = v425 - v429;
                                    bool v432;
                                    if (v421){
                                        bool v431;
                                        v431 = v419 < 2l;
                                        v432 = v431;
                                    } else {
                                        v432 = false;
                                    }
                                    bool v433;
                                    v433 = v432 == false;
                                    if (v433){
                                        assert("The read index needs to be in range for the static array." && v432);
                                    } else {
                                    }
                                    v418.v[v419] = v430;
                                    v419 += 1l ;
                                }
                                bool v435;
                                if (v231){
                                    bool v434;
                                    v434 = v230 < 2l;
                                    v435 = v434;
                                } else {
                                    v435 = false;
                                }
                                bool v436;
                                v436 = v435 == false;
                                if (v436){
                                    assert("The read index needs to be in range for the static array." && v435);
                                } else {
                                }
                                long v437;
                                v437 = v418.v[v230];
                                bool v438;
                                v438 = v437 > 0l;
                                if (v438){
                                    v454 = US5_4(v146, false, v148, v230, v403, v418, v152);
                                } else {
                                    switch (v152.tag) {
                                        case 0: { // Flop
                                            static_array<unsigned char,3l> v441 = v152.v.case0.v0;
                                            v454 = US5_7(v146, v147, v148, v149, v403, v418, v152);
                                            break;
                                        }
                                        case 1: { // Preflop
                                            v454 = US5_0(v146, v147, v148, v149, v403, v418, v152);
                                            break;
                                        }
                                        case 2: { // River
                                            static_array<unsigned char,5l> v445 = v152.v.case2.v0;
                                            v454 = US5_6(v146, v147, v148, v149, v403, v418, v152);
                                            break;
                                        }
                                        case 3: { // Turn
                                            static_array<unsigned char,4l> v443 = v152.v.case3.v0;
                                            v454 = US5_3(v146, v147, v148, v149, v403, v418, v152);
                                            break;
                                        }
                                        default: {
                                            assert("Invalid tag." && false);
                                        }
                                    }
                                }
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        v806 = true; v807 = v454;
                        break;
                    }
                    case 1: { // Human
                        v806 = false; v807 = v8;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                break;
            }
            case 5: { // G_Round'
                long v459 = v8.v.case5.v0; bool v460 = v8.v.case5.v1; static_array<static_array<unsigned char,2l>,2l> v461 = v8.v.case5.v2; long v462 = v8.v.case5.v3; static_array<long,2l> v463 = v8.v.case5.v4; static_array<long,2l> v464 = v8.v.case5.v5; US6 v465 = v8.v.case5.v6; US1 v466 = v8.v.case5.v7;
                long v467;
                v467 = v5.length;
                bool v468;
                v468 = v467 < 128l;
                bool v469;
                v469 = v468 == false;
                if (v469){
                    assert("The length has to be less than the maximum length of the array." && v468);
                } else {
                }
                long v470;
                v470 = v467 + 1l;
                v5.length = v470;
                bool v471;
                v471 = 0l <= v467;
                bool v474;
                if (v471){
                    long v472;
                    v472 = v5.length;
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
                US3 v476;
                v476 = US3_2(v462, v466);
                v5.v[v467] = v476;
                US5 v631;
                switch (v466.tag) {
                    case 0: { // A_Call
                        static_array<long,2l> v478;
                        long v479;
                        v479 = 0l;
                        while (while_method_0(v479)){
                            bool v481;
                            v481 = 0l <= v479;
                            bool v483;
                            if (v481){
                                bool v482;
                                v482 = v479 < 2l;
                                v483 = v482;
                            } else {
                                v483 = false;
                            }
                            bool v484;
                            v484 = v483 == false;
                            if (v484){
                                assert("The read index needs to be in range for the static array." && v483);
                            } else {
                            }
                            long v485;
                            v485 = v464.v[v479];
                            bool v487;
                            if (v481){
                                bool v486;
                                v486 = v479 < 2l;
                                v487 = v486;
                            } else {
                                v487 = false;
                            }
                            bool v488;
                            v488 = v487 == false;
                            if (v488){
                                assert("The read index needs to be in range for the static array." && v487);
                            } else {
                            }
                            long v489;
                            v489 = v463.v[v479];
                            long v490;
                            v490 = v485 + v489;
                            bool v492;
                            if (v481){
                                bool v491;
                                v491 = v479 < 2l;
                                v492 = v491;
                            } else {
                                v492 = false;
                            }
                            bool v493;
                            v493 = v492 == false;
                            if (v493){
                                assert("The read index needs to be in range for the static array." && v492);
                            } else {
                            }
                            v478.v[v479] = v490;
                            v479 += 1l ;
                        }
                        long v494;
                        v494 = v463.v[0l];
                        long v495; long v496;
                        Tuple2 tmp33 = Tuple2(1l, v494);
                        v495 = tmp33.v0; v496 = tmp33.v1;
                        while (while_method_0(v495)){
                            bool v498;
                            v498 = 0l <= v495;
                            bool v500;
                            if (v498){
                                bool v499;
                                v499 = v495 < 2l;
                                v500 = v499;
                            } else {
                                v500 = false;
                            }
                            bool v501;
                            v501 = v500 == false;
                            if (v501){
                                assert("The read index needs to be in range for the static array." && v500);
                            } else {
                            }
                            long v502;
                            v502 = v463.v[v495];
                            bool v503;
                            v503 = v496 >= v502;
                            long v504;
                            if (v503){
                                v504 = v496;
                            } else {
                                v504 = v502;
                            }
                            v496 = v504;
                            v495 += 1l ;
                        }
                        static_array<long,2l> v505;
                        long v506;
                        v506 = 0l;
                        while (while_method_0(v506)){
                            bool v508;
                            v508 = 0l <= v506;
                            bool v510;
                            if (v508){
                                bool v509;
                                v509 = v506 < 2l;
                                v510 = v509;
                            } else {
                                v510 = false;
                            }
                            bool v511;
                            v511 = v510 == false;
                            if (v511){
                                assert("The read index needs to be in range for the static array." && v510);
                            } else {
                            }
                            long v512;
                            v512 = v478.v[v506];
                            bool v513;
                            v513 = v462 == v506;
                            long v516;
                            if (v513){
                                bool v514;
                                v514 = v496 < v512;
                                if (v514){
                                    v516 = v496;
                                } else {
                                    v516 = v512;
                                }
                            } else {
                                v516 = v512;
                            }
                            bool v518;
                            if (v508){
                                bool v517;
                                v517 = v506 < 2l;
                                v518 = v517;
                            } else {
                                v518 = false;
                            }
                            bool v519;
                            v519 = v518 == false;
                            if (v519){
                                assert("The read index needs to be in range for the static array." && v518);
                            } else {
                            }
                            v505.v[v506] = v516;
                            v506 += 1l ;
                        }
                        static_array<long,2l> v520;
                        long v521;
                        v521 = 0l;
                        while (while_method_0(v521)){
                            bool v523;
                            v523 = 0l <= v521;
                            bool v525;
                            if (v523){
                                bool v524;
                                v524 = v521 < 2l;
                                v525 = v524;
                            } else {
                                v525 = false;
                            }
                            bool v526;
                            v526 = v525 == false;
                            if (v526){
                                assert("The read index needs to be in range for the static array." && v525);
                            } else {
                            }
                            long v527;
                            v527 = v478.v[v521];
                            bool v529;
                            if (v523){
                                bool v528;
                                v528 = v521 < 2l;
                                v529 = v528;
                            } else {
                                v529 = false;
                            }
                            bool v530;
                            v530 = v529 == false;
                            if (v530){
                                assert("The read index needs to be in range for the static array." && v529);
                            } else {
                            }
                            long v531;
                            v531 = v505.v[v521];
                            long v532;
                            v532 = v527 - v531;
                            bool v534;
                            if (v523){
                                bool v533;
                                v533 = v521 < 2l;
                                v534 = v533;
                            } else {
                                v534 = false;
                            }
                            bool v535;
                            v535 = v534 == false;
                            if (v535){
                                assert("The read index needs to be in range for the static array." && v534);
                            } else {
                            }
                            v520.v[v521] = v532;
                            v521 += 1l ;
                        }
                        if (v460){
                            long v536;
                            v536 = v462 ^ 1l;
                            v631 = US5_4(v459, false, v461, v536, v505, v520, v465);
                        } else {
                            switch (v465.tag) {
                                case 0: { // Flop
                                    static_array<unsigned char,3l> v539 = v465.v.case0.v0;
                                    v631 = US5_7(v459, v460, v461, v462, v505, v520, v465);
                                    break;
                                }
                                case 1: { // Preflop
                                    v631 = US5_0(v459, v460, v461, v462, v505, v520, v465);
                                    break;
                                }
                                case 2: { // River
                                    static_array<unsigned char,5l> v543 = v465.v.case2.v0;
                                    v631 = US5_6(v459, v460, v461, v462, v505, v520, v465);
                                    break;
                                }
                                case 3: { // Turn
                                    static_array<unsigned char,4l> v541 = v465.v.case3.v0;
                                    v631 = US5_3(v459, v460, v461, v462, v505, v520, v465);
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                        }
                        break;
                    }
                    case 1: { // A_Fold
                        v631 = US5_1(v459, v460, v461, v462, v463, v464, v465);
                        break;
                    }
                    case 2: { // A_Raise
                        long v550 = v466.v.case2.v0;
                        static_array<long,2l> v551;
                        long v552;
                        v552 = 0l;
                        while (while_method_0(v552)){
                            bool v554;
                            v554 = 0l <= v552;
                            bool v556;
                            if (v554){
                                bool v555;
                                v555 = v552 < 2l;
                                v556 = v555;
                            } else {
                                v556 = false;
                            }
                            bool v557;
                            v557 = v556 == false;
                            if (v557){
                                assert("The read index needs to be in range for the static array." && v556);
                            } else {
                            }
                            long v558;
                            v558 = v464.v[v552];
                            bool v560;
                            if (v554){
                                bool v559;
                                v559 = v552 < 2l;
                                v560 = v559;
                            } else {
                                v560 = false;
                            }
                            bool v561;
                            v561 = v560 == false;
                            if (v561){
                                assert("The read index needs to be in range for the static array." && v560);
                            } else {
                            }
                            long v562;
                            v562 = v463.v[v552];
                            long v563;
                            v563 = v558 + v562;
                            bool v565;
                            if (v554){
                                bool v564;
                                v564 = v552 < 2l;
                                v565 = v564;
                            } else {
                                v565 = false;
                            }
                            bool v566;
                            v566 = v565 == false;
                            if (v566){
                                assert("The read index needs to be in range for the static array." && v565);
                            } else {
                            }
                            v551.v[v552] = v563;
                            v552 += 1l ;
                        }
                        long v567;
                        v567 = v463.v[0l];
                        long v568; long v569;
                        Tuple2 tmp34 = Tuple2(1l, v567);
                        v568 = tmp34.v0; v569 = tmp34.v1;
                        while (while_method_0(v568)){
                            bool v571;
                            v571 = 0l <= v568;
                            bool v573;
                            if (v571){
                                bool v572;
                                v572 = v568 < 2l;
                                v573 = v572;
                            } else {
                                v573 = false;
                            }
                            bool v574;
                            v574 = v573 == false;
                            if (v574){
                                assert("The read index needs to be in range for the static array." && v573);
                            } else {
                            }
                            long v575;
                            v575 = v463.v[v568];
                            bool v576;
                            v576 = v569 >= v575;
                            long v577;
                            if (v576){
                                v577 = v569;
                            } else {
                                v577 = v575;
                            }
                            v569 = v577;
                            v568 += 1l ;
                        }
                        static_array<long,2l> v578;
                        long v579;
                        v579 = 0l;
                        while (while_method_0(v579)){
                            bool v581;
                            v581 = 0l <= v579;
                            bool v583;
                            if (v581){
                                bool v582;
                                v582 = v579 < 2l;
                                v583 = v582;
                            } else {
                                v583 = false;
                            }
                            bool v584;
                            v584 = v583 == false;
                            if (v584){
                                assert("The read index needs to be in range for the static array." && v583);
                            } else {
                            }
                            long v585;
                            v585 = v551.v[v579];
                            bool v586;
                            v586 = v462 == v579;
                            long v589;
                            if (v586){
                                bool v587;
                                v587 = v569 < v585;
                                if (v587){
                                    v589 = v569;
                                } else {
                                    v589 = v585;
                                }
                            } else {
                                v589 = v585;
                            }
                            bool v591;
                            if (v581){
                                bool v590;
                                v590 = v579 < 2l;
                                v591 = v590;
                            } else {
                                v591 = false;
                            }
                            bool v592;
                            v592 = v591 == false;
                            if (v592){
                                assert("The read index needs to be in range for the static array." && v591);
                            } else {
                            }
                            v578.v[v579] = v589;
                            v579 += 1l ;
                        }
                        static_array<long,2l> v593;
                        long v594;
                        v594 = 0l;
                        while (while_method_0(v594)){
                            bool v596;
                            v596 = 0l <= v594;
                            bool v598;
                            if (v596){
                                bool v597;
                                v597 = v594 < 2l;
                                v598 = v597;
                            } else {
                                v598 = false;
                            }
                            bool v599;
                            v599 = v598 == false;
                            if (v599){
                                assert("The read index needs to be in range for the static array." && v598);
                            } else {
                            }
                            long v600;
                            v600 = v551.v[v594];
                            bool v602;
                            if (v596){
                                bool v601;
                                v601 = v594 < 2l;
                                v602 = v601;
                            } else {
                                v602 = false;
                            }
                            bool v603;
                            v603 = v602 == false;
                            if (v603){
                                assert("The read index needs to be in range for the static array." && v602);
                            } else {
                            }
                            long v604;
                            v604 = v578.v[v594];
                            long v605;
                            v605 = v600 - v604;
                            bool v607;
                            if (v596){
                                bool v606;
                                v606 = v594 < 2l;
                                v607 = v606;
                            } else {
                                v607 = false;
                            }
                            bool v608;
                            v608 = v607 == false;
                            if (v608){
                                assert("The read index needs to be in range for the static array." && v607);
                            } else {
                            }
                            v593.v[v594] = v605;
                            v594 += 1l ;
                        }
                        long v609;
                        v609 = v462 ^ 1l;
                        bool v610;
                        v610 = 0l <= v609;
                        bool v612;
                        if (v610){
                            bool v611;
                            v611 = v609 < 2l;
                            v612 = v611;
                        } else {
                            v612 = false;
                        }
                        bool v613;
                        v613 = v612 == false;
                        if (v613){
                            assert("The read index needs to be in range for the static array." && v612);
                        } else {
                        }
                        long v614;
                        v614 = v593.v[v609];
                        bool v615;
                        v615 = v614 > 0l;
                        if (v615){
                            v631 = US5_4(v459, false, v461, v609, v578, v593, v465);
                        } else {
                            switch (v465.tag) {
                                case 0: { // Flop
                                    static_array<unsigned char,3l> v618 = v465.v.case0.v0;
                                    v631 = US5_7(v459, v460, v461, v462, v578, v593, v465);
                                    break;
                                }
                                case 1: { // Preflop
                                    v631 = US5_0(v459, v460, v461, v462, v578, v593, v465);
                                    break;
                                }
                                case 2: { // River
                                    static_array<unsigned char,5l> v622 = v465.v.case2.v0;
                                    v631 = US5_6(v459, v460, v461, v462, v578, v593, v465);
                                    break;
                                }
                                case 3: { // Turn
                                    static_array<unsigned char,4l> v620 = v465.v.case3.v0;
                                    v631 = US5_3(v459, v460, v461, v462, v578, v593, v465);
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                        }
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                v806 = true; v807 = v631;
                break;
            }
            case 6: { // G_Showdown
                long v33 = v8.v.case6.v0; bool v34 = v8.v.case6.v1; static_array<static_array<unsigned char,2l>,2l> v35 = v8.v.case6.v2; long v36 = v8.v.case6.v3; static_array<long,2l> v37 = v8.v.case6.v4; static_array<long,2l> v38 = v8.v.case6.v5; US6 v39 = v8.v.case6.v6;
                static_array<unsigned char,5l> v42;
                switch (v39.tag) {
                    case 2: { // River
                        static_array<unsigned char,5l> v40 = v39.v.case2.v0;
                        v42 = v40;
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in showdown.");
                        asm("exit;");
                    }
                }
                static_array<unsigned char,2l> v43;
                v43 = v35.v[0l];
                static_array<unsigned char,7l> v44;
                long v45;
                v45 = 0l;
                while (while_method_0(v45)){
                    bool v47;
                    v47 = 0l <= v45;
                    bool v49;
                    if (v47){
                        bool v48;
                        v48 = v45 < 2l;
                        v49 = v48;
                    } else {
                        v49 = false;
                    }
                    bool v50;
                    v50 = v49 == false;
                    if (v50){
                        assert("The read index needs to be in range for the static array." && v49);
                    } else {
                    }
                    unsigned char v51;
                    v51 = v43.v[v45];
                    bool v53;
                    if (v47){
                        bool v52;
                        v52 = v45 < 7l;
                        v53 = v52;
                    } else {
                        v53 = false;
                    }
                    bool v54;
                    v54 = v53 == false;
                    if (v54){
                        assert("The read index needs to be in range for the static array." && v53);
                    } else {
                    }
                    v44.v[v45] = v51;
                    v45 += 1l ;
                }
                long v55;
                v55 = 0l;
                while (while_method_2(v55)){
                    bool v57;
                    v57 = 0l <= v55;
                    bool v59;
                    if (v57){
                        bool v58;
                        v58 = v55 < 5l;
                        v59 = v58;
                    } else {
                        v59 = false;
                    }
                    bool v60;
                    v60 = v59 == false;
                    if (v60){
                        assert("The read index needs to be in range for the static array." && v59);
                    } else {
                    }
                    unsigned char v61;
                    v61 = v42.v[v55];
                    long v62;
                    v62 = 2l + v55;
                    bool v63;
                    v63 = 0l <= v62;
                    bool v65;
                    if (v63){
                        bool v64;
                        v64 = v62 < 7l;
                        v65 = v64;
                    } else {
                        v65 = false;
                    }
                    bool v66;
                    v66 = v65 == false;
                    if (v66){
                        assert("The read index needs to be in range for the static array." && v65);
                    } else {
                    }
                    v44.v[v62] = v61;
                    v55 += 1l ;
                }
                static_array<unsigned char,5l> v67; char v68;
                Tuple0 tmp59 = score_44(v44);
                v67 = tmp59.v0; v68 = tmp59.v1;
                static_array<unsigned char,2l> v69;
                v69 = v35.v[1l];
                static_array<unsigned char,7l> v70;
                long v71;
                v71 = 0l;
                while (while_method_0(v71)){
                    bool v73;
                    v73 = 0l <= v71;
                    bool v75;
                    if (v73){
                        bool v74;
                        v74 = v71 < 2l;
                        v75 = v74;
                    } else {
                        v75 = false;
                    }
                    bool v76;
                    v76 = v75 == false;
                    if (v76){
                        assert("The read index needs to be in range for the static array." && v75);
                    } else {
                    }
                    unsigned char v77;
                    v77 = v69.v[v71];
                    bool v79;
                    if (v73){
                        bool v78;
                        v78 = v71 < 7l;
                        v79 = v78;
                    } else {
                        v79 = false;
                    }
                    bool v80;
                    v80 = v79 == false;
                    if (v80){
                        assert("The read index needs to be in range for the static array." && v79);
                    } else {
                    }
                    v70.v[v71] = v77;
                    v71 += 1l ;
                }
                long v81;
                v81 = 0l;
                while (while_method_2(v81)){
                    bool v83;
                    v83 = 0l <= v81;
                    bool v85;
                    if (v83){
                        bool v84;
                        v84 = v81 < 5l;
                        v85 = v84;
                    } else {
                        v85 = false;
                    }
                    bool v86;
                    v86 = v85 == false;
                    if (v86){
                        assert("The read index needs to be in range for the static array." && v85);
                    } else {
                    }
                    unsigned char v87;
                    v87 = v42.v[v81];
                    long v88;
                    v88 = 2l + v81;
                    bool v89;
                    v89 = 0l <= v88;
                    bool v91;
                    if (v89){
                        bool v90;
                        v90 = v88 < 7l;
                        v91 = v90;
                    } else {
                        v91 = false;
                    }
                    bool v92;
                    v92 = v91 == false;
                    if (v92){
                        assert("The read index needs to be in range for the static array." && v91);
                    } else {
                    }
                    v70.v[v88] = v87;
                    v81 += 1l ;
                }
                static_array<unsigned char,5l> v93; char v94;
                Tuple0 tmp60 = score_44(v70);
                v93 = tmp60.v0; v94 = tmp60.v1;
                bool v95;
                v95 = 0l <= v36;
                bool v97;
                if (v95){
                    bool v96;
                    v96 = v36 < 2l;
                    v97 = v96;
                } else {
                    v97 = false;
                }
                bool v98;
                v98 = v97 == false;
                if (v98){
                    assert("The read index needs to be in range for the static array." && v97);
                } else {
                }
                long v99;
                v99 = v37.v[v36];
                bool v100;
                v100 = v68 < v94;
                US8 v106;
                if (v100){
                    v106 = US8_2();
                } else {
                    bool v102;
                    v102 = v68 > v94;
                    if (v102){
                        v106 = US8_1();
                    } else {
                        v106 = US8_0();
                    }
                }
                US8 v128;
                switch (v106.tag) {
                    case 0: { // Eq
                        US8 v107;
                        v107 = US8_0();
                        long v108;
                        v108 = 0l;
                        while (while_method_2(v108)){
                            bool v110;
                            v110 = 0l <= v108;
                            bool v112;
                            if (v110){
                                bool v111;
                                v111 = v108 < 5l;
                                v112 = v111;
                            } else {
                                v112 = false;
                            }
                            bool v113;
                            v113 = v112 == false;
                            if (v113){
                                assert("The read index needs to be in range for the static array." && v112);
                            } else {
                            }
                            unsigned char v114;
                            v114 = v67.v[v108];
                            bool v116;
                            if (v110){
                                bool v115;
                                v115 = v108 < 5l;
                                v116 = v115;
                            } else {
                                v116 = false;
                            }
                            bool v117;
                            v117 = v116 == false;
                            if (v117){
                                assert("The read index needs to be in range for the static array." && v116);
                            } else {
                            }
                            unsigned char v118;
                            v118 = v93.v[v108];
                            bool v119;
                            v119 = v114 < v118;
                            US8 v125;
                            if (v119){
                                v125 = US8_2();
                            } else {
                                bool v121;
                                v121 = v114 > v118;
                                if (v121){
                                    v125 = US8_1();
                                } else {
                                    v125 = US8_0();
                                }
                            }
                            bool v126;
                            switch (v125.tag) {
                                case 0: { // Eq
                                    v126 = true;
                                    break;
                                }
                                default: {
                                    v126 = false;
                                }
                            }
                            bool v127;
                            v127 = v126 == false;
                            if (v127){
                                v107 = v125;
                                break;
                            } else {
                            }
                            v108 += 1l ;
                        }
                        v128 = v107;
                        break;
                    }
                    default: {
                        v128 = v106;
                    }
                }
                long v133; long v134;
                switch (v128.tag) {
                    case 0: { // Eq
                        v133 = 0l; v134 = -1l;
                        break;
                    }
                    case 1: { // Gt
                        v133 = v99; v134 = 0l;
                        break;
                    }
                    case 2: { // Lt
                        v133 = v99; v134 = 1l;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                static_array<Tuple0,2l> v135;
                v135.v[0l] = Tuple0(v67, v68);
                v135.v[1l] = Tuple0(v93, v94);
                long v136;
                v136 = v5.length;
                bool v137;
                v137 = v136 < 128l;
                bool v138;
                v138 = v137 == false;
                if (v138){
                    assert("The length has to be less than the maximum length of the array." && v137);
                } else {
                }
                long v139;
                v139 = v136 + 1l;
                v5.length = v139;
                bool v140;
                v140 = 0l <= v136;
                bool v143;
                if (v140){
                    long v141;
                    v141 = v5.length;
                    bool v142;
                    v142 = v136 < v141;
                    v143 = v142;
                } else {
                    v143 = false;
                }
                bool v144;
                v144 = v143 == false;
                if (v144){
                    assert("The set index needs to be in range for the static array list." && v143);
                } else {
                }
                US3 v145;
                v145 = US3_4(v133, v135, v134);
                v5.v[v136] = v145;
                v806 = false; v807 = v8;
                break;
            }
            case 7: { // G_Turn
                long v656 = v8.v.case7.v0; bool v657 = v8.v.case7.v1; static_array<static_array<unsigned char,2l>,2l> v658 = v8.v.case7.v2; long v659 = v8.v.case7.v3; static_array<long,2l> v660 = v8.v.case7.v4; static_array<long,2l> v661 = v8.v.case7.v5; US6 v662 = v8.v.case7.v6;
                static_array<unsigned char,1l> v663; unsigned long long v664;
                Tuple14 tmp61 = draw_cards_39(v2, v6);
                v663 = tmp61.v0; v664 = tmp61.v1;
                v0 = v664;
                static_array_list<unsigned char,5l,long> v665;
                v665 = get_community_cards_40(v662, v663);
                long v666;
                v666 = v5.length;
                bool v667;
                v667 = v666 < 128l;
                bool v668;
                v668 = v667 == false;
                if (v668){
                    assert("The length has to be less than the maximum length of the array." && v667);
                } else {
                }
                long v669;
                v669 = v666 + 1l;
                v5.length = v669;
                bool v670;
                v670 = 0l <= v666;
                bool v673;
                if (v670){
                    long v671;
                    v671 = v5.length;
                    bool v672;
                    v672 = v666 < v671;
                    v673 = v672;
                } else {
                    v673 = false;
                }
                bool v674;
                v674 = v673 == false;
                if (v674){
                    assert("The set index needs to be in range for the static array list." && v673);
                } else {
                }
                US3 v675;
                v675 = US3_0(v665);
                v5.v[v666] = v675;
                US6 v702;
                switch (v662.tag) {
                    case 0: { // Flop
                        static_array<unsigned char,3l> v676 = v662.v.case0.v0;
                        static_array<unsigned char,4l> v677;
                        long v678;
                        v678 = 0l;
                        while (while_method_3(v678)){
                            bool v680;
                            v680 = 0l <= v678;
                            bool v682;
                            if (v680){
                                bool v681;
                                v681 = v678 < 3l;
                                v682 = v681;
                            } else {
                                v682 = false;
                            }
                            bool v683;
                            v683 = v682 == false;
                            if (v683){
                                assert("The read index needs to be in range for the static array." && v682);
                            } else {
                            }
                            unsigned char v684;
                            v684 = v676.v[v678];
                            bool v686;
                            if (v680){
                                bool v685;
                                v685 = v678 < 4l;
                                v686 = v685;
                            } else {
                                v686 = false;
                            }
                            bool v687;
                            v687 = v686 == false;
                            if (v687){
                                assert("The read index needs to be in range for the static array." && v686);
                            } else {
                            }
                            v677.v[v678] = v684;
                            v678 += 1l ;
                        }
                        long v688;
                        v688 = 0l;
                        while (while_method_6(v688)){
                            bool v690;
                            v690 = 0l <= v688;
                            bool v692;
                            if (v690){
                                bool v691;
                                v691 = v688 < 1l;
                                v692 = v691;
                            } else {
                                v692 = false;
                            }
                            bool v693;
                            v693 = v692 == false;
                            if (v693){
                                assert("The read index needs to be in range for the static array." && v692);
                            } else {
                            }
                            unsigned char v694;
                            v694 = v663.v[v688];
                            long v695;
                            v695 = 3l + v688;
                            bool v696;
                            v696 = 0l <= v695;
                            bool v698;
                            if (v696){
                                bool v697;
                                v697 = v695 < 4l;
                                v698 = v697;
                            } else {
                                v698 = false;
                            }
                            bool v699;
                            v699 = v698 == false;
                            if (v699){
                                assert("The read index needs to be in range for the static array." && v698);
                            } else {
                            }
                            v677.v[v695] = v694;
                            v688 += 1l ;
                        }
                        v702 = US6_3(v677);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in turn.");
                        asm("exit;");
                    }
                }
                US5 v703;
                v703 = US5_4(v656, true, v658, 0l, v660, v661, v702);
                v806 = true; v807 = v703;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        v7 = v806;
        v8 = v807;
    }
    return v8;
}
__device__ Tuple8 play_loop_32(US4 v0, static_array<US2,2l> v1, US7 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US5 v6){
    US5 v7;
    v7 = play_loop_inner_33(v3, v4, v5, v1, v6);
    switch (v7.tag) {
        case 1: { // G_Fold
            long v26 = v7.v.case1.v0; bool v27 = v7.v.case1.v1; static_array<static_array<unsigned char,2l>,2l> v28 = v7.v.case1.v2; long v29 = v7.v.case1.v3; static_array<long,2l> v30 = v7.v.case1.v4; static_array<long,2l> v31 = v7.v.case1.v5; US6 v32 = v7.v.case1.v6;
            US4 v33;
            v33 = US4_0();
            US7 v34;
            v34 = US7_1(v26, v27, v28, v29, v30, v31, v32);
            return Tuple8(v33, v1, v34);
            break;
        }
        case 4: { // G_Round
            long v8 = v7.v.case4.v0; bool v9 = v7.v.case4.v1; static_array<static_array<unsigned char,2l>,2l> v10 = v7.v.case4.v2; long v11 = v7.v.case4.v3; static_array<long,2l> v12 = v7.v.case4.v4; static_array<long,2l> v13 = v7.v.case4.v5; US6 v14 = v7.v.case4.v6;
            US4 v15;
            v15 = US4_1(v7);
            US7 v16;
            v16 = US7_2(v8, v9, v10, v11, v12, v13, v14);
            return Tuple8(v15, v1, v16);
            break;
        }
        case 6: { // G_Showdown
            long v17 = v7.v.case6.v0; bool v18 = v7.v.case6.v1; static_array<static_array<unsigned char,2l>,2l> v19 = v7.v.case6.v2; long v20 = v7.v.case6.v3; static_array<long,2l> v21 = v7.v.case6.v4; static_array<long,2l> v22 = v7.v.case6.v5; US6 v23 = v7.v.case6.v6;
            US4 v24;
            v24 = US4_0();
            US7 v25;
            v25 = US7_1(v17, v18, v19, v20, v21, v22, v23);
            return Tuple8(v24, v1, v25);
            break;
        }
        default: {
            printf("%s\n", "Unexpected node received in play_loop.");
            asm("exit;");
        }
    }
}
__device__ void f_46(unsigned char * v0, unsigned long long v1){
    unsigned long long * v2;
    v2 = (unsigned long long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_47(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_49(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_52(unsigned char * v0, unsigned char v1){
    unsigned char * v2;
    v2 = (unsigned char *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_51(unsigned char * v0, unsigned char v1){
    return f_52(v0, v1);
}
__device__ void f_50(unsigned char * v0, static_array_list<unsigned char,5l,long> v1){
    long v2;
    v2 = v1.length;
    f_49(v0, v2);
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_1(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = 4ull + v6;
        unsigned char * v8;
        v8 = (unsigned char *)(v0+v7);
        bool v9;
        v9 = 0l <= v4;
        bool v12;
        if (v9){
            long v10;
            v10 = v1.length;
            bool v11;
            v11 = v4 < v10;
            v12 = v11;
        } else {
            v12 = false;
        }
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The read index needs to be in range for the static array list." && v12);
        } else {
        }
        unsigned char v14;
        v14 = v1.v[v4];
        f_51(v8, v14);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_53(unsigned char * v0, long v1, long v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long * v4;
    v4 = (long *)(v0+4ull);
    v4[0l] = v2;
    return ;
}
__device__ void f_55(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_56(unsigned char * v0){
    return ;
}
__device__ void f_54(unsigned char * v0, long v1, US1 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_55(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // A_Call
            return f_56(v5);
            break;
        }
        case 1: { // A_Fold
            return f_56(v5);
            break;
        }
        case 2: { // A_Raise
            long v6 = v2.v.case2.v0;
            return f_49(v5, v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_57(unsigned char * v0, long v1, static_array<unsigned char,2l> v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = 4ull + v6;
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
        unsigned char v13;
        v13 = v2.v[v4];
        f_51(v8, v13);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_60(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
    long v3;
    v3 = 0l;
    while (while_method_2(v3)){
        unsigned long long v5;
        v5 = (unsigned long long)v3;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        bool v7;
        v7 = 0l <= v3;
        bool v9;
        if (v7){
            bool v8;
            v8 = v3 < 5l;
            v9 = v8;
        } else {
            v9 = false;
        }
        bool v10;
        v10 = v9 == false;
        if (v10){
            assert("The read index needs to be in range for the static array." && v9);
        } else {
        }
        unsigned char v11;
        v11 = v1.v[v3];
        f_51(v6, v11);
        v3 += 1l ;
    }
    char * v12;
    v12 = (char *)(v0+5ull);
    v12[0l] = v2;
    return ;
}
__device__ void f_59(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
    return f_60(v0, v1, v2);
}
__device__ void f_58(unsigned char * v0, long v1, static_array<Tuple0,2l> v2, long v3){
    long * v4;
    v4 = (long *)(v0+0ull);
    v4[0l] = v1;
    long v5;
    v5 = 0l;
    while (while_method_0(v5)){
        unsigned long long v7;
        v7 = (unsigned long long)v5;
        unsigned long long v8;
        v8 = v7 * 8ull;
        unsigned long long v9;
        v9 = 8ull + v8;
        unsigned char * v10;
        v10 = (unsigned char *)(v0+v9);
        bool v11;
        v11 = 0l <= v5;
        bool v13;
        if (v11){
            bool v12;
            v12 = v5 < 2l;
            v13 = v12;
        } else {
            v13 = false;
        }
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The read index needs to be in range for the static array." && v13);
        } else {
        }
        static_array<unsigned char,5l> v15; char v16;
        Tuple0 tmp64 = v2.v[v5];
        v15 = tmp64.v0; v16 = tmp64.v1;
        f_59(v10, v15, v16);
        v5 += 1l ;
    }
    long * v17;
    v17 = (long *)(v0+24ull);
    v17[0l] = v3;
    return ;
}
__device__ void f_48(unsigned char * v0, US3 v1){
    long v2;
    v2 = v1.tag;
    f_49(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // CommunityCardsAre
            static_array_list<unsigned char,5l,long> v4 = v1.v.case0.v0;
            return f_50(v3, v4);
            break;
        }
        case 1: { // Fold
            long v5 = v1.v.case1.v0; long v6 = v1.v.case1.v1;
            return f_53(v3, v5, v6);
            break;
        }
        case 2: { // PlayerAction
            long v7 = v1.v.case2.v0; US1 v8 = v1.v.case2.v1;
            return f_54(v3, v7, v8);
            break;
        }
        case 3: { // PlayerGotCards
            long v9 = v1.v.case3.v0; static_array<unsigned char,2l> v10 = v1.v.case3.v1;
            return f_57(v3, v9, v10);
            break;
        }
        case 4: { // Showdown
            long v11 = v1.v.case4.v0; static_array<Tuple0,2l> v12 = v1.v.case4.v1; long v13 = v1.v.case4.v2;
            return f_58(v3, v11, v12, v13);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_61(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6160ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_64(unsigned char * v0, static_array<unsigned char,2l> v1){
    long v2;
    v2 = 0l;
    while (while_method_0(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        bool v6;
        v6 = 0l <= v2;
        bool v8;
        if (v6){
            bool v7;
            v7 = v2 < 2l;
            v8 = v7;
        } else {
            v8 = false;
        }
        bool v9;
        v9 = v8 == false;
        if (v9){
            assert("The read index needs to be in range for the static array." && v8);
        } else {
        }
        unsigned char v10;
        v10 = v1.v[v2];
        f_51(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_65(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+32ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_66(unsigned char * v0, static_array<unsigned char,3l> v1){
    long v2;
    v2 = 0l;
    while (while_method_3(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        bool v6;
        v6 = 0l <= v2;
        bool v8;
        if (v6){
            bool v7;
            v7 = v2 < 3l;
            v8 = v7;
        } else {
            v8 = false;
        }
        bool v9;
        v9 = v8 == false;
        if (v9){
            assert("The read index needs to be in range for the static array." && v8);
        } else {
        }
        unsigned char v10;
        v10 = v1.v[v2];
        f_51(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_67(unsigned char * v0, static_array<unsigned char,5l> v1){
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        bool v6;
        v6 = 0l <= v2;
        bool v8;
        if (v6){
            bool v7;
            v7 = v2 < 5l;
            v8 = v7;
        } else {
            v8 = false;
        }
        bool v9;
        v9 = v8 == false;
        if (v9){
            assert("The read index needs to be in range for the static array." && v8);
        } else {
        }
        unsigned char v10;
        v10 = v1.v[v2];
        f_51(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_68(unsigned char * v0, static_array<unsigned char,4l> v1){
    long v2;
    v2 = 0l;
    while (while_method_4(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        bool v6;
        v6 = 0l <= v2;
        bool v8;
        if (v6){
            bool v7;
            v7 = v2 < 4l;
            v8 = v7;
        } else {
            v8 = false;
        }
        bool v9;
        v9 = v8 == false;
        if (v9){
            assert("The read index needs to be in range for the static array." && v8);
        } else {
        }
        unsigned char v10;
        v10 = v1.v[v2];
        f_51(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_63(unsigned char * v0, long v1, bool v2, static_array<static_array<unsigned char,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US6 v7){
    long * v8;
    v8 = (long *)(v0+0ull);
    v8[0l] = v1;
    bool * v9;
    v9 = (bool *)(v0+4ull);
    v9[0l] = v2;
    long v10;
    v10 = 0l;
    while (while_method_0(v10)){
        unsigned long long v12;
        v12 = (unsigned long long)v10;
        unsigned long long v13;
        v13 = v12 * 2ull;
        unsigned long long v14;
        v14 = 6ull + v13;
        unsigned char * v15;
        v15 = (unsigned char *)(v0+v14);
        bool v16;
        v16 = 0l <= v10;
        bool v18;
        if (v16){
            bool v17;
            v17 = v10 < 2l;
            v18 = v17;
        } else {
            v18 = false;
        }
        bool v19;
        v19 = v18 == false;
        if (v19){
            assert("The read index needs to be in range for the static array." && v18);
        } else {
        }
        static_array<unsigned char,2l> v20;
        v20 = v3.v[v10];
        f_64(v15, v20);
        v10 += 1l ;
    }
    long * v21;
    v21 = (long *)(v0+12ull);
    v21[0l] = v4;
    long v22;
    v22 = 0l;
    while (while_method_0(v22)){
        unsigned long long v24;
        v24 = (unsigned long long)v22;
        unsigned long long v25;
        v25 = v24 * 4ull;
        unsigned long long v26;
        v26 = 16ull + v25;
        unsigned char * v27;
        v27 = (unsigned char *)(v0+v26);
        bool v28;
        v28 = 0l <= v22;
        bool v30;
        if (v28){
            bool v29;
            v29 = v22 < 2l;
            v30 = v29;
        } else {
            v30 = false;
        }
        bool v31;
        v31 = v30 == false;
        if (v31){
            assert("The read index needs to be in range for the static array." && v30);
        } else {
        }
        long v32;
        v32 = v5.v[v22];
        f_49(v27, v32);
        v22 += 1l ;
    }
    long v33;
    v33 = 0l;
    while (while_method_0(v33)){
        unsigned long long v35;
        v35 = (unsigned long long)v33;
        unsigned long long v36;
        v36 = v35 * 4ull;
        unsigned long long v37;
        v37 = 24ull + v36;
        unsigned char * v38;
        v38 = (unsigned char *)(v0+v37);
        bool v39;
        v39 = 0l <= v33;
        bool v41;
        if (v39){
            bool v40;
            v40 = v33 < 2l;
            v41 = v40;
        } else {
            v41 = false;
        }
        bool v42;
        v42 = v41 == false;
        if (v42){
            assert("The read index needs to be in range for the static array." && v41);
        } else {
        }
        long v43;
        v43 = v6.v[v33];
        f_49(v38, v43);
        v33 += 1l ;
    }
    long v44;
    v44 = v7.tag;
    f_65(v0, v44);
    unsigned char * v45;
    v45 = (unsigned char *)(v0+40ull);
    switch (v7.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v46 = v7.v.case0.v0;
            return f_66(v45, v46);
            break;
        }
        case 1: { // Preflop
            return f_56(v45);
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v47 = v7.v.case2.v0;
            return f_67(v45, v47);
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v48 = v7.v.case3.v0;
            return f_68(v45, v48);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_70(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+48ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_69(unsigned char * v0, long v1, bool v2, static_array<static_array<unsigned char,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US6 v7, US1 v8){
    long * v9;
    v9 = (long *)(v0+0ull);
    v9[0l] = v1;
    bool * v10;
    v10 = (bool *)(v0+4ull);
    v10[0l] = v2;
    long v11;
    v11 = 0l;
    while (while_method_0(v11)){
        unsigned long long v13;
        v13 = (unsigned long long)v11;
        unsigned long long v14;
        v14 = v13 * 2ull;
        unsigned long long v15;
        v15 = 6ull + v14;
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
        static_array<unsigned char,2l> v21;
        v21 = v3.v[v11];
        f_64(v16, v21);
        v11 += 1l ;
    }
    long * v22;
    v22 = (long *)(v0+12ull);
    v22[0l] = v4;
    long v23;
    v23 = 0l;
    while (while_method_0(v23)){
        unsigned long long v25;
        v25 = (unsigned long long)v23;
        unsigned long long v26;
        v26 = v25 * 4ull;
        unsigned long long v27;
        v27 = 16ull + v26;
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
        f_49(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = 0l;
    while (while_method_0(v34)){
        unsigned long long v36;
        v36 = (unsigned long long)v34;
        unsigned long long v37;
        v37 = v36 * 4ull;
        unsigned long long v38;
        v38 = 24ull + v37;
        unsigned char * v39;
        v39 = (unsigned char *)(v0+v38);
        bool v40;
        v40 = 0l <= v34;
        bool v42;
        if (v40){
            bool v41;
            v41 = v34 < 2l;
            v42 = v41;
        } else {
            v42 = false;
        }
        bool v43;
        v43 = v42 == false;
        if (v43){
            assert("The read index needs to be in range for the static array." && v42);
        } else {
        }
        long v44;
        v44 = v6.v[v34];
        f_49(v39, v44);
        v34 += 1l ;
    }
    long v45;
    v45 = v7.tag;
    f_65(v0, v45);
    unsigned char * v46;
    v46 = (unsigned char *)(v0+40ull);
    switch (v7.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v47 = v7.v.case0.v0;
            f_66(v46, v47);
            break;
        }
        case 1: { // Preflop
            f_56(v46);
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v48 = v7.v.case2.v0;
            f_67(v46, v48);
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v49 = v7.v.case3.v0;
            f_68(v46, v49);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v50;
    v50 = v8.tag;
    f_70(v0, v50);
    unsigned char * v51;
    v51 = (unsigned char *)(v0+52ull);
    switch (v8.tag) {
        case 0: { // A_Call
            return f_56(v51);
            break;
        }
        case 1: { // A_Fold
            return f_56(v51);
            break;
        }
        case 2: { // A_Raise
            long v52 = v8.v.case2.v0;
            return f_49(v51, v52);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_62(unsigned char * v0, US5 v1){
    long v2;
    v2 = v1.tag;
    f_49(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // G_Flop
            long v4 = v1.v.case0.v0; bool v5 = v1.v.case0.v1; static_array<static_array<unsigned char,2l>,2l> v6 = v1.v.case0.v2; long v7 = v1.v.case0.v3; static_array<long,2l> v8 = v1.v.case0.v4; static_array<long,2l> v9 = v1.v.case0.v5; US6 v10 = v1.v.case0.v6;
            return f_63(v3, v4, v5, v6, v7, v8, v9, v10);
            break;
        }
        case 1: { // G_Fold
            long v11 = v1.v.case1.v0; bool v12 = v1.v.case1.v1; static_array<static_array<unsigned char,2l>,2l> v13 = v1.v.case1.v2; long v14 = v1.v.case1.v3; static_array<long,2l> v15 = v1.v.case1.v4; static_array<long,2l> v16 = v1.v.case1.v5; US6 v17 = v1.v.case1.v6;
            return f_63(v3, v11, v12, v13, v14, v15, v16, v17);
            break;
        }
        case 2: { // G_Preflop
            return f_56(v3);
            break;
        }
        case 3: { // G_River
            long v18 = v1.v.case3.v0; bool v19 = v1.v.case3.v1; static_array<static_array<unsigned char,2l>,2l> v20 = v1.v.case3.v2; long v21 = v1.v.case3.v3; static_array<long,2l> v22 = v1.v.case3.v4; static_array<long,2l> v23 = v1.v.case3.v5; US6 v24 = v1.v.case3.v6;
            return f_63(v3, v18, v19, v20, v21, v22, v23, v24);
            break;
        }
        case 4: { // G_Round
            long v25 = v1.v.case4.v0; bool v26 = v1.v.case4.v1; static_array<static_array<unsigned char,2l>,2l> v27 = v1.v.case4.v2; long v28 = v1.v.case4.v3; static_array<long,2l> v29 = v1.v.case4.v4; static_array<long,2l> v30 = v1.v.case4.v5; US6 v31 = v1.v.case4.v6;
            return f_63(v3, v25, v26, v27, v28, v29, v30, v31);
            break;
        }
        case 5: { // G_Round'
            long v32 = v1.v.case5.v0; bool v33 = v1.v.case5.v1; static_array<static_array<unsigned char,2l>,2l> v34 = v1.v.case5.v2; long v35 = v1.v.case5.v3; static_array<long,2l> v36 = v1.v.case5.v4; static_array<long,2l> v37 = v1.v.case5.v5; US6 v38 = v1.v.case5.v6; US1 v39 = v1.v.case5.v7;
            return f_69(v3, v32, v33, v34, v35, v36, v37, v38, v39);
            break;
        }
        case 6: { // G_Showdown
            long v40 = v1.v.case6.v0; bool v41 = v1.v.case6.v1; static_array<static_array<unsigned char,2l>,2l> v42 = v1.v.case6.v2; long v43 = v1.v.case6.v3; static_array<long,2l> v44 = v1.v.case6.v4; static_array<long,2l> v45 = v1.v.case6.v5; US6 v46 = v1.v.case6.v6;
            return f_63(v3, v40, v41, v42, v43, v44, v45, v46);
            break;
        }
        case 7: { // G_Turn
            long v47 = v1.v.case7.v0; bool v48 = v1.v.case7.v1; static_array<static_array<unsigned char,2l>,2l> v49 = v1.v.case7.v2; long v50 = v1.v.case7.v3; static_array<long,2l> v51 = v1.v.case7.v4; static_array<long,2l> v52 = v1.v.case7.v5; US6 v53 = v1.v.case7.v6;
            return f_63(v3, v47, v48, v49, v50, v51, v52, v53);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_71(unsigned char * v0, US2 v1){
    long v2;
    v2 = v1.tag;
    f_49(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Computer
            return f_56(v3);
            break;
        }
        case 1: { // Human
            return f_56(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_72(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6264ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_45(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US4 v3, static_array<US2,2l> v4, US7 v5){
    f_46(v0, v1);
    long v6;
    v6 = v2.length;
    f_47(v0, v6);
    long v7;
    v7 = v2.length;
    long v8;
    v8 = 0l;
    while (while_method_1(v7, v8)){
        unsigned long long v10;
        v10 = (unsigned long long)v8;
        unsigned long long v11;
        v11 = v10 * 48ull;
        unsigned long long v12;
        v12 = 16ull + v11;
        unsigned char * v13;
        v13 = (unsigned char *)(v0+v12);
        bool v14;
        v14 = 0l <= v8;
        bool v17;
        if (v14){
            long v15;
            v15 = v2.length;
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
        v19 = v2.v[v8];
        f_48(v13, v19);
        v8 += 1l ;
    }
    long v20;
    v20 = v3.tag;
    f_61(v0, v20);
    unsigned char * v21;
    v21 = (unsigned char *)(v0+6176ull);
    switch (v3.tag) {
        case 0: { // None
            f_56(v21);
            break;
        }
        case 1: { // Some
            US5 v22 = v3.v.case1.v0;
            f_62(v21, v22);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v23;
    v23 = 0l;
    while (while_method_0(v23)){
        unsigned long long v25;
        v25 = (unsigned long long)v23;
        unsigned long long v26;
        v26 = v25 * 4ull;
        unsigned long long v27;
        v27 = 6256ull + v26;
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
        US2 v33;
        v33 = v4.v[v23];
        f_71(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = v5.tag;
    f_72(v0, v34);
    unsigned char * v35;
    v35 = (unsigned char *)(v0+6272ull);
    switch (v5.tag) {
        case 0: { // GameNotStarted
            return f_56(v35);
            break;
        }
        case 1: { // GameOver
            long v36 = v5.v.case1.v0; bool v37 = v5.v.case1.v1; static_array<static_array<unsigned char,2l>,2l> v38 = v5.v.case1.v2; long v39 = v5.v.case1.v3; static_array<long,2l> v40 = v5.v.case1.v4; static_array<long,2l> v41 = v5.v.case1.v5; US6 v42 = v5.v.case1.v6;
            return f_63(v35, v36, v37, v38, v39, v40, v41, v42);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v43 = v5.v.case2.v0; bool v44 = v5.v.case2.v1; static_array<static_array<unsigned char,2l>,2l> v45 = v5.v.case2.v2; long v46 = v5.v.case2.v3; static_array<long,2l> v47 = v5.v.case2.v4; static_array<long,2l> v48 = v5.v.case2.v5; US6 v49 = v5.v.case2.v6;
            return f_63(v35, v43, v44, v45, v46, v47, v48, v49);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_74(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6168ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_73(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US7 v3){
    long v4;
    v4 = v1.length;
    f_49(v0, v4);
    long v5;
    v5 = v1.length;
    long v6;
    v6 = 0l;
    while (while_method_1(v5, v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 48ull;
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
        US3 v17;
        v17 = v1.v[v6];
        f_48(v11, v17);
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
        v22 = 6160ull + v21;
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
        f_71(v23, v28);
        v18 += 1l ;
    }
    long v29;
    v29 = v3.tag;
    f_74(v0, v29);
    unsigned char * v30;
    v30 = (unsigned char *)(v0+6176ull);
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return f_56(v30);
            break;
        }
        case 1: { // GameOver
            long v31 = v3.v.case1.v0; bool v32 = v3.v.case1.v1; static_array<static_array<unsigned char,2l>,2l> v33 = v3.v.case1.v2; long v34 = v3.v.case1.v3; static_array<long,2l> v35 = v3.v.case1.v4; static_array<long,2l> v36 = v3.v.case1.v5; US6 v37 = v3.v.case1.v6;
            return f_63(v30, v31, v32, v33, v34, v35, v36, v37);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v38 = v3.v.case2.v0; bool v39 = v3.v.case2.v1; static_array<static_array<unsigned char,2l>,2l> v40 = v3.v.case2.v2; long v41 = v3.v.case2.v3; static_array<long,2l> v42 = v3.v.case2.v4; static_array<long,2l> v43 = v3.v.case2.v5; US6 v44 = v3.v.case2.v6;
            return f_63(v30, v38, v39, v40, v41, v42, v43, v44);
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
        const char * v8;
        v8 = "going to run the event loop";
        write_0(v8);
        printf("\n");
        US0 v9;
        v9 = f_1(v1);
        unsigned long long v10; static_array_list<US3,128l,long> v11; US4 v12; static_array<US2,2l> v13; US7 v14;
        Tuple1 tmp15 = f_7(v0);
        v10 = tmp15.v0; v11 = tmp15.v1; v12 = tmp15.v2; v13 = tmp15.v3; v14 = tmp15.v4;
        unsigned long long & v15 = v10;
        static_array_list<US3,128l,long> & v16 = v11;
        unsigned long long v17;
        v17 = clock64();
        long v18;
        v18 = threadIdx.x;
        long v19;
        v19 = blockIdx.x;
        long v20;
        v20 = v19 * 512l;
        long v21;
        v21 = v18 + v20;
        unsigned long long v22;
        v22 = (unsigned long long)v21;
        curandStatePhilox4_32_10_t v23;
        curand_init(v17,v22,0ull,&v23);
        US4 v66; static_array<US2,2l> v67; US7 v68;
        switch (v9.tag) {
            case 0: { // ActionSelected
                US1 v35 = v9.v.case0.v0;
                switch (v12.tag) {
                    case 0: { // None
                        v66 = v12; v67 = v13; v68 = v14;
                        break;
                    }
                    case 1: { // Some
                        US5 v36 = v12.v.case1.v0;
                        switch (v36.tag) {
                            case 4: { // G_Round
                                long v37 = v36.v.case4.v0; bool v38 = v36.v.case4.v1; static_array<static_array<unsigned char,2l>,2l> v39 = v36.v.case4.v2; long v40 = v36.v.case4.v3; static_array<long,2l> v41 = v36.v.case4.v4; static_array<long,2l> v42 = v36.v.case4.v5; US6 v43 = v36.v.case4.v6;
                                US5 v44;
                                v44 = US5_5(v37, v38, v39, v40, v41, v42, v43, v35);
                                Tuple8 tmp62 = play_loop_32(v12, v13, v14, v15, v16, v23, v44);
                                v66 = tmp62.v0; v67 = tmp62.v1; v68 = tmp62.v2;
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
                static_array<US2,2l> v34 = v9.v.case1.v0;
                v66 = v12; v67 = v34; v68 = v14;
                break;
            }
            case 2: { // StartGame
                static_array<US2,2l> v24;
                US2 v25;
                v25 = US2_0();
                v24.v[0l] = v25;
                US2 v26;
                v26 = US2_1();
                v24.v[1l] = v26;
                static_array_list<US3,128l,long> v27;
                v27.length = 0;
                v15 = 4503599627370495ull;
                v16 = v27;
                US4 v28;
                v28 = US4_0();
                US7 v29;
                v29 = US7_0();
                US5 v30;
                v30 = US5_2();
                Tuple8 tmp63 = play_loop_32(v28, v24, v29, v15, v16, v23, v30);
                v66 = tmp63.v0; v67 = tmp63.v1; v68 = tmp63.v2;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        f_45(v0, v10, v11, v66, v67, v68);
        return f_73(v2, v11, v67, v68);
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
import collections
class US1_0(NamedTuple): # A_Call
    tag = 0
class US1_1(NamedTuple): # A_Fold
    tag = 1
class US1_2(NamedTuple): # A_Raise
    v0 : i32
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
class US5_0(NamedTuple): # Flop
    v0 : static_array
    tag = 0
class US5_1(NamedTuple): # Preflop
    tag = 1
class US5_2(NamedTuple): # River
    v0 : static_array
    tag = 2
class US5_3(NamedTuple): # Turn
    v0 : static_array
    tag = 3
US5 = Union[US5_0, US5_1, US5_2, US5_3]
class US4_0(NamedTuple): # G_Flop
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 0
class US4_1(NamedTuple): # G_Fold
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 1
class US4_2(NamedTuple): # G_Preflop
    tag = 2
class US4_3(NamedTuple): # G_River
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 3
class US4_4(NamedTuple): # G_Round
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 4
class US4_5(NamedTuple): # G_Round'
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    v7 : US1
    tag = 5
class US4_6(NamedTuple): # G_Showdown
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 6
class US4_7(NamedTuple): # G_Turn
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 7
US4 = Union[US4_0, US4_1, US4_2, US4_3, US4_4, US4_5, US4_6, US4_7]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : US4
    tag = 1
US3 = Union[US3_0, US3_1]
class US6_0(NamedTuple): # GameNotStarted
    tag = 0
class US6_1(NamedTuple): # GameOver
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 1
class US6_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 2
US6 = Union[US6_0, US6_1, US6_2]
class US7_0(NamedTuple): # CommunityCardsAre
    v0 : static_array_list
    tag = 0
class US7_1(NamedTuple): # Fold
    v0 : i32
    v1 : i32
    tag = 1
class US7_2(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 2
class US7_3(NamedTuple): # PlayerGotCards
    v0 : i32
    v1 : static_array
    tag = 3
class US7_4(NamedTuple): # Showdown
    v0 : i32
    v1 : static_array
    v2 : i32
    tag = 4
US7 = Union[US7_0, US7_1, US7_2, US7_3, US7_4]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = cp.empty(16,dtype=cp.uint8)
        v3 = cp.empty(6320,dtype=cp.uint8)
        v4 = cp.empty(6224,dtype=cp.uint8)
        v5 = "Deserializing the message and game_state from JSON."
        method0(v5)
        del v5
        print()
        v6 = method1(v0)
        v7, v8, v9, v10, v11 = method9(v1)
        v12 = "Serializing the message and game_state to the GPU."
        method0(v12)
        del v12
        print()
        method42(v2, v6)
        del v6
        method49(v3, v7, v8, v9, v10, v11)
        del v7, v8, v9, v10, v11
        v13 = "Done serializing the gpu state"
        method0(v13)
        del v13
        print()
        v14 = 0
        v15 = raw_module.get_function(f"entry{v14}")
        del v14
        v15.max_dynamic_shared_size_bytes = 0 
        v15((1,),(512,),(v3, v2, v4),shared_mem=0)
        del v2, v15
        v16, v17, v18, v19, v20 = method77(v3)
        del v3
        v21, v22, v23 = method105(v4)
        del v4
        return method107(v16, v17, v18, v19, v20, v21, v22, v23)
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
        v3 = static_array_list(128)
        v4 = 4503599627370495
        v5 = US3_0()
        v6 = US6_0()
        return method147(v4, v3, v5, v0, v6)
    return inner
def method0(v0 : string) -> None:
    print(v0, end="")
    del v0
    return 
def method4(v0 : object) -> None:
    assert v0 == [], f'Expected an unit type. Got: {v0}'
    del v0
    return 
def method5(v0 : object) -> i32:
    assert isinstance(v0,i32), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method3(v0 : object) -> US1:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "A_Call" == v1
    if v4:
        del v1, v4
        method4(v2)
        del v2
        return US1_0()
    else:
        del v4
        v7 = "A_Fold" == v1
        if v7:
            del v1, v7
            method4(v2)
            del v2
            return US1_1()
        else:
            del v7
            v10 = "A_Raise" == v1
            if v10:
                del v1, v10
                v11 = method5(v2)
                del v2
                return US1_2(v11)
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method7(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method8(v0 : object) -> US2:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Computer" == v1
    if v4:
        del v1, v4
        method4(v2)
        del v2
        return US2_0()
    else:
        del v4
        v7 = "Human" == v1
        if v7:
            del v1, v7
            method4(v2)
            del v2
            return US2_1()
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method6(v0 : object) -> static_array:
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
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method8(v8)
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
def method2(v0 : object) -> US0:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "ActionSelected" == v1
    if v4:
        del v1, v4
        v5 = method3(v2)
        del v2
        return US0_0(v5)
    else:
        del v4
        v8 = "PlayerChanged" == v1
        if v8:
            del v1, v8
            v9 = method6(v2)
            del v2
            return US0_1(v9)
        else:
            del v8
            v12 = "StartGame" == v1
            if v12:
                del v1, v12
                method4(v2)
                del v2
                return US0_2()
            else:
                del v2, v12
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method1(v0 : object) -> US0:
    return method2(v0)
def method13(v0 : object) -> u64:
    assert isinstance(v0,u64), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method12(v0 : object) -> u64:
    v1 = method13(v0)
    del v0
    return v1
def method18(v0 : object) -> u8:
    assert isinstance(v0,u8), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method17(v0 : object) -> u8:
    v1 = method18(v0)
    del v0
    return v1
def method16(v0 : object) -> static_array_list:
    v1 = len(v0) # type: ignore
    assert (5 >= v1), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 5\nGot: {v1} '
    del v1
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v2 = len(v0) # type: ignore
    v3 = 5 >= v2
    v4 = v3 == False
    if v4:
        v5 = "The type level dimension has to equal the value passed at runtime into create."
        assert v3, v5
        del v5
    else:
        pass
    del v3, v4
    v6 = static_array_list(5)
    v6.length = v2
    v7 = 0
    while method7(v2, v7):
        v9 = v0[v7]
        v10 = method17(v9)
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
def method19(v0 : object) -> Tuple[i32, i32]:
    v1 = v0["chips_won"] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0["winner_id"] # type: ignore
    del v0
    v4 = method5(v3)
    del v3
    return v2, v4
def method20(v0 : object) -> Tuple[i32, US1]:
    v1 = v0[0] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0[1] # type: ignore
    del v0
    v4 = method3(v3)
    del v3
    return v2, v4
def method22(v0 : object) -> static_array:
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
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method17(v8)
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
def method21(v0 : object) -> Tuple[i32, static_array]:
    v1 = v0[0] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0[1] # type: ignore
    del v0
    v4 = method22(v3)
    del v3
    return v2, v4
def method27(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0) # type: ignore
    v2 = 5 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(5)
    v6 = 0
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method17(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 5
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
def method28(v0 : object) -> i8:
    assert isinstance(v0,i8), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method26(v0 : object) -> Tuple[static_array, i8]:
    v1 = v0["hand"] # type: ignore
    v2 = method27(v1)
    del v1
    v3 = v0["score"] # type: ignore
    del v0
    v4 = method28(v3)
    del v3
    return v2, v4
def method25(v0 : object) -> Tuple[static_array, i8]:
    v1, v2 = method26(v0)
    del v0
    return v1, v2
def method24(v0 : object) -> static_array:
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
    while method7(v1, v6):
        v8 = v0[v6]
        v9, v10 = method25(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 2
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v5[v6] = (v9, v10)
        del v9, v10
        v6 += 1 
    del v0, v1, v6
    return v5
def method23(v0 : object) -> Tuple[i32, static_array, i32]:
    v1 = v0["chips_won"] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0["hands_shown"] # type: ignore
    v4 = method24(v3)
    del v3
    v5 = v0["winner_id"] # type: ignore
    del v0
    v6 = method5(v5)
    del v5
    return v2, v4, v6
def method15(v0 : object) -> US7:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "CommunityCardsAre" == v1
    if v4:
        del v1, v4
        v5 = method16(v2)
        del v2
        return US7_0(v5)
    else:
        del v4
        v8 = "Fold" == v1
        if v8:
            del v1, v8
            v9, v10 = method19(v2)
            del v2
            return US7_1(v9, v10)
        else:
            del v8
            v13 = "PlayerAction" == v1
            if v13:
                del v1, v13
                v14, v15 = method20(v2)
                del v2
                return US7_2(v14, v15)
            else:
                del v13
                v18 = "PlayerGotCards" == v1
                if v18:
                    del v1, v18
                    v19, v20 = method21(v2)
                    del v2
                    return US7_3(v19, v20)
                else:
                    del v18
                    v23 = "Showdown" == v1
                    if v23:
                        del v1, v23
                        v24, v25, v26 = method23(v2)
                        del v2
                        return US7_4(v24, v25, v26)
                    else:
                        del v2, v23
                        raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                        del v1
                        raise Exception("Error")
def method14(v0 : object) -> static_array_list:
    v1 = len(v0) # type: ignore
    assert (128 >= v1), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 128\nGot: {v1} '
    del v1
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v2 = len(v0) # type: ignore
    v3 = 128 >= v2
    v4 = v3 == False
    if v4:
        v5 = "The type level dimension has to equal the value passed at runtime into create."
        assert v3, v5
        del v5
    else:
        pass
    del v3, v4
    v6 = static_array_list(128)
    v6.length = v2
    v7 = 0
    while method7(v2, v7):
        v9 = v0[v7]
        v10 = method15(v9)
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
def method11(v0 : object) -> Tuple[u64, static_array_list]:
    v1 = v0["deck"] # type: ignore
    v2 = method12(v1)
    del v1
    v3 = v0["messages"] # type: ignore
    del v0
    v4 = method14(v3)
    del v3
    return v2, v4
def method33(v0 : object) -> i32:
    v1 = v0["min_raise"] # type: ignore
    del v0
    v2 = method5(v1)
    del v1
    return v2
def method34(v0 : object) -> bool:
    assert isinstance(v0,bool), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method35(v0 : object) -> static_array:
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
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method22(v8)
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
def method36(v0 : object) -> static_array:
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
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method5(v8)
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
def method38(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0) # type: ignore
    v2 = 3 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(3)
    v6 = 0
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method17(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 3
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
def method39(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0) # type: ignore
    v2 = 4 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(4)
    v6 = 0
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method17(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 4
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
def method37(v0 : object) -> US5:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Flop" == v1
    if v4:
        del v1, v4
        v5 = method38(v2)
        del v2
        return US5_0(v5)
    else:
        del v4
        v8 = "Preflop" == v1
        if v8:
            del v1, v8
            method4(v2)
            del v2
            return US5_1()
        else:
            del v8
            v11 = "River" == v1
            if v11:
                del v1, v11
                v12 = method27(v2)
                del v2
                return US5_2(v12)
            else:
                del v11
                v15 = "Turn" == v1
                if v15:
                    del v1, v15
                    v16 = method39(v2)
                    del v2
                    return US5_3(v16)
                else:
                    del v2, v15
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method32(v0 : object) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5]:
    v1 = v0["config"] # type: ignore
    v2 = method33(v1)
    del v1
    v3 = v0["is_button_s_first_move"] # type: ignore
    v4 = method34(v3)
    del v3
    v5 = v0["pl_card"] # type: ignore
    v6 = method35(v5)
    del v5
    v7 = v0["player_turn"] # type: ignore
    v8 = method5(v7)
    del v7
    v9 = v0["pot"] # type: ignore
    v10 = method36(v9)
    del v9
    v11 = v0["stack"] # type: ignore
    v12 = method36(v11)
    del v11
    v13 = v0["street"] # type: ignore
    del v0
    v14 = method37(v13)
    del v13
    return v2, v4, v6, v8, v10, v12, v14
def method40(v0 : object) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5, US1]:
    v1 = v0[0] # type: ignore
    v2, v3, v4, v5, v6, v7, v8 = method32(v1)
    del v1
    v9 = v0[1] # type: ignore
    del v0
    v10 = method3(v9)
    del v9
    return v2, v3, v4, v5, v6, v7, v8, v10
def method31(v0 : object) -> US4:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "G_Flop" == v1
    if v4:
        del v1, v4
        v5, v6, v7, v8, v9, v10, v11 = method32(v2)
        del v2
        return US4_0(v5, v6, v7, v8, v9, v10, v11)
    else:
        del v4
        v14 = "G_Fold" == v1
        if v14:
            del v1, v14
            v15, v16, v17, v18, v19, v20, v21 = method32(v2)
            del v2
            return US4_1(v15, v16, v17, v18, v19, v20, v21)
        else:
            del v14
            v24 = "G_Preflop" == v1
            if v24:
                del v1, v24
                method4(v2)
                del v2
                return US4_2()
            else:
                del v24
                v27 = "G_River" == v1
                if v27:
                    del v1, v27
                    v28, v29, v30, v31, v32, v33, v34 = method32(v2)
                    del v2
                    return US4_3(v28, v29, v30, v31, v32, v33, v34)
                else:
                    del v27
                    v37 = "G_Round" == v1
                    if v37:
                        del v1, v37
                        v38, v39, v40, v41, v42, v43, v44 = method32(v2)
                        del v2
                        return US4_4(v38, v39, v40, v41, v42, v43, v44)
                    else:
                        del v37
                        v47 = "G_Round'" == v1
                        if v47:
                            del v1, v47
                            v48, v49, v50, v51, v52, v53, v54, v55 = method40(v2)
                            del v2
                            return US4_5(v48, v49, v50, v51, v52, v53, v54, v55)
                        else:
                            del v47
                            v58 = "G_Showdown" == v1
                            if v58:
                                del v1, v58
                                v59, v60, v61, v62, v63, v64, v65 = method32(v2)
                                del v2
                                return US4_6(v59, v60, v61, v62, v63, v64, v65)
                            else:
                                del v58
                                v68 = "G_Turn" == v1
                                if v68:
                                    del v1, v68
                                    v69, v70, v71, v72, v73, v74, v75 = method32(v2)
                                    del v2
                                    return US4_7(v69, v70, v71, v72, v73, v74, v75)
                                else:
                                    del v2, v68
                                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                                    del v1
                                    raise Exception("Error")
def method30(v0 : object) -> US3:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        method4(v2)
        del v2
        return US3_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method31(v2)
            del v2
            return US3_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method41(v0 : object) -> US6:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        method4(v2)
        del v2
        return US6_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8, v9, v10, v11, v12, v13, v14 = method32(v2)
            del v2
            return US6_1(v8, v9, v10, v11, v12, v13, v14)
        else:
            del v7
            v17 = "WaitingForActionFromPlayerId" == v1
            if v17:
                del v1, v17
                v18, v19, v20, v21, v22, v23, v24 = method32(v2)
                del v2
                return US6_2(v18, v19, v20, v21, v22, v23, v24)
            else:
                del v2, v17
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method29(v0 : object) -> Tuple[US3, static_array, US6]:
    v1 = v0["game"] # type: ignore
    v2 = method30(v1)
    del v1
    v3 = v0["pl_type"] # type: ignore
    v4 = method6(v3)
    del v3
    v5 = v0["ui_game_state"] # type: ignore
    del v0
    v6 = method41(v5)
    del v5
    return v2, v4, v6
def method10(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    v1 = v0["large"] # type: ignore
    v2, v3 = method11(v1)
    del v1
    v4 = v0["small"] # type: ignore
    del v0
    v5, v6, v7 = method29(v4)
    del v4
    return v2, v3, v5, v6, v7
def method9(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    return method10(v0)
def method43(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[0:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method45(v0 : cp.ndarray) -> None:
    del v0
    return 
def method44(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method43(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US1_0(): # A_Call
            del v1
            return method45(v3)
        case US1_1(): # A_Fold
            del v1
            return method45(v3)
        case US1_2(v4): # A_Raise
            del v1
            return method43(v3, v4)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method47(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method48(v0 : cp.ndarray, v1 : US2) -> None:
    v2 = v1.tag
    method43(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US2_0(): # Computer
            del v1
            return method45(v3)
        case US2_1(): # Human
            del v1
            return method45(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method46(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method47(v2):
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
        method48(v6, v12)
        del v6, v12
        v2 += 1 
    del v0, v1, v2
    return 
def method42(v0 : cp.ndarray, v1 : US0) -> None:
    v2 = v1.tag
    method43(v0, v2)
    del v2
    v3 = v0[8:].view(cp.uint8)
    del v0
    match v1:
        case US0_0(v4): # ActionSelected
            del v1
            return method44(v3, v4)
        case US0_1(v5): # PlayerChanged
            del v1
            return method46(v3, v5)
        case US0_2(): # StartGame
            del v1
            return method45(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method50(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[0:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method51(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[8:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method55(v0 : cp.ndarray, v1 : u8) -> None:
    v2 = v0[0:].view(cp.uint8)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method54(v0 : cp.ndarray, v1 : u8) -> None:
    return method55(v0, v1)
def method53(v0 : cp.ndarray, v1 : static_array_list) -> None:
    v2 = v1.length
    method43(v0, v2)
    del v2
    v3 = v1.length
    v4 = 0
    while method7(v3, v4):
        v6 = u64(v4)
        v7 = 4 + v6
        del v6
        v8 = v0[v7:].view(cp.uint8)
        del v7
        v9 = 0 <= v4
        if v9:
            v10 = v1.length
            v11 = v4 < v10
            del v10
            v12 = v11
        else:
            v12 = False
        del v9
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array list."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v15 = v1[v4]
        method54(v8, v15)
        del v8, v15
        v4 += 1 
    del v0, v1, v3, v4
    return 
def method56(v0 : cp.ndarray, v1 : i32, v2 : i32) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v0[4:].view(cp.int32)
    del v0
    v4[0] = v2
    del v2, v4
    return 
def method58(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[4:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method57(v0 : cp.ndarray, v1 : i32, v2 : US1) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method58(v0, v4)
    del v4
    v5 = v0[8:].view(cp.uint8)
    del v0
    match v2:
        case US1_0(): # A_Call
            del v2
            return method45(v5)
        case US1_1(): # A_Fold
            del v2
            return method45(v5)
        case US1_2(v6): # A_Raise
            del v2
            return method43(v5, v6)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method59(v0 : cp.ndarray, v1 : i32, v2 : static_array) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = 0
    while method47(v4):
        v6 = u64(v4)
        v7 = 4 + v6
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
        v14 = v2[v4]
        method54(v8, v14)
        del v8, v14
        v4 += 1 
    del v0, v2, v4
    return 
def method63(v0 : i32) -> bool:
    v1 = v0 < 5
    del v0
    return v1
def method62(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    v3 = 0
    while method63(v3):
        v5 = u64(v3)
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7 = 0 <= v3
        if v7:
            v8 = v3 < 5
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
        v12 = v1[v3]
        method54(v6, v12)
        del v6, v12
        v3 += 1 
    del v1, v3
    v13 = v0[5:].view(cp.int8)
    del v0
    v13[0] = v2
    del v2, v13
    return 
def method61(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    return method62(v0, v1, v2)
def method60(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : i32) -> None:
    v4 = v0[0:].view(cp.int32)
    v4[0] = v1
    del v1, v4
    v5 = 0
    while method47(v5):
        v7 = u64(v5)
        v8 = v7 * 8
        del v7
        v9 = 8 + v8
        del v8
        v10 = v0[v9:].view(cp.uint8)
        del v9
        v11 = 0 <= v5
        if v11:
            v12 = v5 < 2
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v16, v17 = v2[v5]
        method61(v10, v16, v17)
        del v10, v16, v17
        v5 += 1 
    del v2, v5
    v18 = v0[24:].view(cp.int32)
    del v0
    v18[0] = v3
    del v3, v18
    return 
def method52(v0 : cp.ndarray, v1 : US7) -> None:
    v2 = v1.tag
    method43(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US7_0(v4): # CommunityCardsAre
            del v1
            return method53(v3, v4)
        case US7_1(v5, v6): # Fold
            del v1
            return method56(v3, v5, v6)
        case US7_2(v7, v8): # PlayerAction
            del v1
            return method57(v3, v7, v8)
        case US7_3(v9, v10): # PlayerGotCards
            del v1
            return method59(v3, v9, v10)
        case US7_4(v11, v12, v13): # Showdown
            del v1
            return method60(v3, v11, v12, v13)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method64(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[6160:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method67(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method47(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = 0 <= v2
        if v6:
            v7 = v2 < 2
            v8 = v7
        else:
            v8 = False
        del v6
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v1[v2]
        method54(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method68(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[32:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method70(v0 : i32) -> bool:
    v1 = v0 < 3
    del v0
    return v1
def method69(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method70(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = 0 <= v2
        if v6:
            v7 = v2 < 3
            v8 = v7
        else:
            v8 = False
        del v6
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v1[v2]
        method54(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method71(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method63(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = 0 <= v2
        if v6:
            v7 = v2 < 5
            v8 = v7
        else:
            v8 = False
        del v6
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v1[v2]
        method54(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method73(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def method72(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method73(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = 0 <= v2
        if v6:
            v7 = v2 < 4
            v8 = v7
        else:
            v8 = False
        del v6
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v1[v2]
        method54(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method66(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[0:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[4:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method47(v10):
        v12 = u64(v10)
        v13 = v12 * 2
        del v12
        v14 = 6 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method67(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[12:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method47(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 16 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method43(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method47(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 24 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method43(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method68(v0, v47)
    del v47
    v48 = v0[40:].view(cp.uint8)
    del v0
    match v7:
        case US5_0(v49): # Flop
            del v7
            return method69(v48, v49)
        case US5_1(): # Preflop
            del v7
            return method45(v48)
        case US5_2(v50): # River
            del v7
            return method71(v48, v50)
        case US5_3(v51): # Turn
            del v7
            return method72(v48, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method75(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[48:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method74(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[0:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[4:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method47(v11):
        v13 = u64(v11)
        v14 = v13 * 2
        del v13
        v15 = 6 + v14
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
        method67(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[12:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method47(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 16 + v27
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
        method43(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method47(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 24 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method43(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method68(v0, v48)
    del v48
    v49 = v0[40:].view(cp.uint8)
    match v7:
        case US5_0(v50): # Flop
            method69(v49, v50)
        case US5_1(): # Preflop
            method45(v49)
        case US5_2(v51): # River
            method71(v49, v51)
        case US5_3(v52): # Turn
            method72(v49, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7, v49
    v53 = v8.tag
    method75(v0, v53)
    del v53
    v54 = v0[52:].view(cp.uint8)
    del v0
    match v8:
        case US1_0(): # A_Call
            del v8
            return method45(v54)
        case US1_1(): # A_Fold
            del v8
            return method45(v54)
        case US1_2(v55): # A_Raise
            del v8
            return method43(v54, v55)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method65(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method43(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US4_0(v4, v5, v6, v7, v8, v9, v10): # G_Flop
            del v1
            return method66(v3, v4, v5, v6, v7, v8, v9, v10)
        case US4_1(v11, v12, v13, v14, v15, v16, v17): # G_Fold
            del v1
            return method66(v3, v11, v12, v13, v14, v15, v16, v17)
        case US4_2(): # G_Preflop
            del v1
            return method45(v3)
        case US4_3(v18, v19, v20, v21, v22, v23, v24): # G_River
            del v1
            return method66(v3, v18, v19, v20, v21, v22, v23, v24)
        case US4_4(v25, v26, v27, v28, v29, v30, v31): # G_Round
            del v1
            return method66(v3, v25, v26, v27, v28, v29, v30, v31)
        case US4_5(v32, v33, v34, v35, v36, v37, v38, v39): # G_Round'
            del v1
            return method74(v3, v32, v33, v34, v35, v36, v37, v38, v39)
        case US4_6(v40, v41, v42, v43, v44, v45, v46): # G_Showdown
            del v1
            return method66(v3, v40, v41, v42, v43, v44, v45, v46)
        case US4_7(v47, v48, v49, v50, v51, v52, v53): # G_Turn
            del v1
            return method66(v3, v47, v48, v49, v50, v51, v52, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method76(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[6264:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method49(v0 : cp.ndarray, v1 : u64, v2 : static_array_list, v3 : US3, v4 : static_array, v5 : US6) -> None:
    method50(v0, v1)
    del v1
    v6 = v2.length
    method51(v0, v6)
    del v6
    v7 = v2.length
    v8 = 0
    while method7(v7, v8):
        v10 = u64(v8)
        v11 = v10 * 48
        del v10
        v12 = 16 + v11
        del v11
        v13 = v0[v12:].view(cp.uint8)
        del v12
        v14 = 0 <= v8
        if v14:
            v15 = v2.length
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
        v20 = v2[v8]
        method52(v13, v20)
        del v13, v20
        v8 += 1 
    del v2, v7, v8
    v21 = v3.tag
    method64(v0, v21)
    del v21
    v22 = v0[6176:].view(cp.uint8)
    match v3:
        case US3_0(): # None
            method45(v22)
        case US3_1(v23): # Some
            method65(v22, v23)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3, v22
    v24 = 0
    while method47(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 6256 + v27
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
        v35 = v4[v24]
        method48(v29, v35)
        del v29, v35
        v24 += 1 
    del v4, v24
    v36 = v5.tag
    method76(v0, v36)
    del v36
    v37 = v0[6272:].view(cp.uint8)
    del v0
    match v5:
        case US6_0(): # GameNotStarted
            del v5
            return method45(v37)
        case US6_1(v38, v39, v40, v41, v42, v43, v44): # GameOver
            del v5
            return method66(v37, v38, v39, v40, v41, v42, v43, v44)
        case US6_2(v45, v46, v47, v48, v49, v50, v51): # WaitingForActionFromPlayerId
            del v5
            return method66(v37, v45, v46, v47, v48, v49, v50, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method78(v0 : cp.ndarray) -> u64:
    v1 = v0[0:].view(cp.uint64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method79(v0 : cp.ndarray) -> i32:
    v1 = v0[8:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method81(v0 : cp.ndarray) -> i32:
    v1 = v0[0:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method84(v0 : cp.ndarray) -> u8:
    v1 = v0[0:].view(cp.uint8)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method83(v0 : cp.ndarray) -> u8:
    v1 = method84(v0)
    del v0
    return v1
def method82(v0 : cp.ndarray) -> static_array_list:
    v1 = static_array_list(5)
    v2 = method81(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method7(v3, v4):
        v6 = u64(v4)
        v7 = 4 + v6
        del v6
        v8 = v0[v7:].view(cp.uint8)
        del v7
        v9 = method83(v8)
        del v8
        v10 = 0 <= v4
        if v10:
            v11 = v1.length
            v12 = v4 < v11
            del v11
            v13 = v12
        else:
            v13 = False
        del v10
        v14 = v13 == False
        if v14:
            v15 = "The set index needs to be in range for the static array list."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v1[v4] = v9
        del v9
        v4 += 1 
    del v0, v3, v4
    return v1
def method85(v0 : cp.ndarray) -> Tuple[i32, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.int32)
    del v0
    v4 = v3[0].item()
    del v3
    return v2, v4
def method87(v0 : cp.ndarray) -> i32:
    v1 = v0[4:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method88(v0 : cp.ndarray) -> None:
    del v0
    return 
def method86(v0 : cp.ndarray) -> Tuple[i32, US1]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = method87(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    if v3 == 0:
        method88(v4)
        v10 = US1_0()
    elif v3 == 1:
        method88(v4)
        v10 = US1_1()
    elif v3 == 2:
        v8 = method81(v4)
        v10 = US1_2(v8)
    else:
        raise Exception("Invalid tag.")
    del v3, v4
    return v2, v10
def method89(v0 : cp.ndarray) -> Tuple[i32, static_array]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method47(v4):
        v6 = u64(v4)
        v7 = 4 + v6
        del v6
        v8 = v0[v7:].view(cp.uint8)
        del v7
        v9 = method83(v8)
        del v8
        v10 = 0 <= v4
        if v10:
            v11 = v4 < 2
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
        v3[v4] = v9
        del v9
        v4 += 1 
    del v0, v4
    return v2, v3
def method92(v0 : cp.ndarray) -> Tuple[static_array, i8]:
    v1 = static_array(5)
    v2 = 0
    while method63(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method83(v5)
        del v5
        v7 = 0 <= v2
        if v7:
            v8 = v2 < 5
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
        v1[v2] = v6
        del v6
        v2 += 1 
    del v2
    v12 = v0[5:].view(cp.int8)
    del v0
    v13 = v12[0].item()
    del v12
    return v1, v13
def method91(v0 : cp.ndarray) -> Tuple[static_array, i8]:
    v1, v2 = method92(v0)
    del v0
    return v1, v2
def method90(v0 : cp.ndarray) -> Tuple[i32, static_array, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method47(v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10, v11 = method91(v9)
        del v9
        v12 = 0 <= v4
        if v12:
            v13 = v4 < 2
            v14 = v13
        else:
            v14 = False
        del v12
        v15 = v14 == False
        if v15:
            v16 = "The read index needs to be in range for the static array."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        v3[v4] = (v10, v11)
        del v10, v11
        v4 += 1 
    del v4
    v17 = v0[24:].view(cp.int32)
    del v0
    v18 = v17[0].item()
    del v17
    return v2, v3, v18
def method80(v0 : cp.ndarray) -> US7:
    v1 = method81(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4 = method82(v2)
        del v2
        return US7_0(v4)
    elif v1 == 1:
        del v1
        v6, v7 = method85(v2)
        del v2
        return US7_1(v6, v7)
    elif v1 == 2:
        del v1
        v9, v10 = method86(v2)
        del v2
        return US7_2(v9, v10)
    elif v1 == 3:
        del v1
        v12, v13 = method89(v2)
        del v2
        return US7_3(v12, v13)
    elif v1 == 4:
        del v1
        v15, v16, v17 = method90(v2)
        del v2
        return US7_4(v15, v16, v17)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method93(v0 : cp.ndarray) -> i32:
    v1 = v0[6160:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method96(v0 : cp.ndarray) -> static_array:
    v1 = static_array(2)
    v2 = 0
    while method47(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method83(v5)
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
        v1[v2] = v6
        del v6
        v2 += 1 
    del v0, v2
    return v1
def method97(v0 : cp.ndarray) -> i32:
    v1 = v0[32:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method98(v0 : cp.ndarray) -> static_array:
    v1 = static_array(3)
    v2 = 0
    while method70(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method83(v5)
        del v5
        v7 = 0 <= v2
        if v7:
            v8 = v2 < 3
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
        v1[v2] = v6
        del v6
        v2 += 1 
    del v0, v2
    return v1
def method99(v0 : cp.ndarray) -> static_array:
    v1 = static_array(5)
    v2 = 0
    while method63(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method83(v5)
        del v5
        v7 = 0 <= v2
        if v7:
            v8 = v2 < 5
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
        v1[v2] = v6
        del v6
        v2 += 1 
    del v0, v2
    return v1
def method100(v0 : cp.ndarray) -> static_array:
    v1 = static_array(4)
    v2 = 0
    while method73(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method83(v5)
        del v5
        v7 = 0 <= v2
        if v7:
            v8 = v2 < 4
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
        v1[v2] = v6
        del v6
        v2 += 1 
    del v0, v2
    return v1
def method95(v0 : cp.ndarray) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.bool_)
    v4 = v3[0].item()
    del v3
    v5 = static_array(2)
    v6 = 0
    while method47(v6):
        v8 = u64(v6)
        v9 = v8 * 2
        del v8
        v10 = 6 + v9
        del v9
        v11 = v0[v10:].view(cp.uint8)
        del v10
        v12 = method96(v11)
        del v11
        v13 = 0 <= v6
        if v13:
            v14 = v6 < 2
            v15 = v14
        else:
            v15 = False
        del v13
        v16 = v15 == False
        if v16:
            v17 = "The read index needs to be in range for the static array."
            assert v15, v17
            del v17
        else:
            pass
        del v15, v16
        v5[v6] = v12
        del v12
        v6 += 1 
    del v6
    v18 = v0[12:].view(cp.int32)
    v19 = v18[0].item()
    del v18
    v20 = static_array(2)
    v21 = 0
    while method47(v21):
        v23 = u64(v21)
        v24 = v23 * 4
        del v23
        v25 = 16 + v24
        del v24
        v26 = v0[v25:].view(cp.uint8)
        del v25
        v27 = method81(v26)
        del v26
        v28 = 0 <= v21
        if v28:
            v29 = v21 < 2
            v30 = v29
        else:
            v30 = False
        del v28
        v31 = v30 == False
        if v31:
            v32 = "The read index needs to be in range for the static array."
            assert v30, v32
            del v32
        else:
            pass
        del v30, v31
        v20[v21] = v27
        del v27
        v21 += 1 
    del v21
    v33 = static_array(2)
    v34 = 0
    while method47(v34):
        v36 = u64(v34)
        v37 = v36 * 4
        del v36
        v38 = 24 + v37
        del v37
        v39 = v0[v38:].view(cp.uint8)
        del v38
        v40 = method81(v39)
        del v39
        v41 = 0 <= v34
        if v41:
            v42 = v34 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v33[v34] = v40
        del v40
        v34 += 1 
    del v34
    v46 = method97(v0)
    v47 = v0[40:].view(cp.uint8)
    del v0
    if v46 == 0:
        v49 = method98(v47)
        v56 = US5_0(v49)
    elif v46 == 1:
        method88(v47)
        v56 = US5_1()
    elif v46 == 2:
        v52 = method99(v47)
        v56 = US5_2(v52)
    elif v46 == 3:
        v54 = method100(v47)
        v56 = US5_3(v54)
    else:
        raise Exception("Invalid tag.")
    del v46, v47
    return v2, v4, v5, v19, v20, v33, v56
def method102(v0 : cp.ndarray) -> i32:
    v1 = v0[48:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method101(v0 : cp.ndarray) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5, US1]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.bool_)
    v4 = v3[0].item()
    del v3
    v5 = static_array(2)
    v6 = 0
    while method47(v6):
        v8 = u64(v6)
        v9 = v8 * 2
        del v8
        v10 = 6 + v9
        del v9
        v11 = v0[v10:].view(cp.uint8)
        del v10
        v12 = method96(v11)
        del v11
        v13 = 0 <= v6
        if v13:
            v14 = v6 < 2
            v15 = v14
        else:
            v15 = False
        del v13
        v16 = v15 == False
        if v16:
            v17 = "The read index needs to be in range for the static array."
            assert v15, v17
            del v17
        else:
            pass
        del v15, v16
        v5[v6] = v12
        del v12
        v6 += 1 
    del v6
    v18 = v0[12:].view(cp.int32)
    v19 = v18[0].item()
    del v18
    v20 = static_array(2)
    v21 = 0
    while method47(v21):
        v23 = u64(v21)
        v24 = v23 * 4
        del v23
        v25 = 16 + v24
        del v24
        v26 = v0[v25:].view(cp.uint8)
        del v25
        v27 = method81(v26)
        del v26
        v28 = 0 <= v21
        if v28:
            v29 = v21 < 2
            v30 = v29
        else:
            v30 = False
        del v28
        v31 = v30 == False
        if v31:
            v32 = "The read index needs to be in range for the static array."
            assert v30, v32
            del v32
        else:
            pass
        del v30, v31
        v20[v21] = v27
        del v27
        v21 += 1 
    del v21
    v33 = static_array(2)
    v34 = 0
    while method47(v34):
        v36 = u64(v34)
        v37 = v36 * 4
        del v36
        v38 = 24 + v37
        del v37
        v39 = v0[v38:].view(cp.uint8)
        del v38
        v40 = method81(v39)
        del v39
        v41 = 0 <= v34
        if v41:
            v42 = v34 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v33[v34] = v40
        del v40
        v34 += 1 
    del v34
    v46 = method97(v0)
    v47 = v0[40:].view(cp.uint8)
    if v46 == 0:
        v49 = method98(v47)
        v56 = US5_0(v49)
    elif v46 == 1:
        method88(v47)
        v56 = US5_1()
    elif v46 == 2:
        v52 = method99(v47)
        v56 = US5_2(v52)
    elif v46 == 3:
        v54 = method100(v47)
        v56 = US5_3(v54)
    else:
        raise Exception("Invalid tag.")
    del v46, v47
    v57 = method102(v0)
    v58 = v0[52:].view(cp.uint8)
    del v0
    if v57 == 0:
        method88(v58)
        v64 = US1_0()
    elif v57 == 1:
        method88(v58)
        v64 = US1_1()
    elif v57 == 2:
        v62 = method81(v58)
        v64 = US1_2(v62)
    else:
        raise Exception("Invalid tag.")
    del v57, v58
    return v2, v4, v5, v19, v20, v33, v56, v64
def method94(v0 : cp.ndarray) -> US4:
    v1 = method81(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4, v5, v6, v7, v8, v9, v10 = method95(v2)
        del v2
        return US4_0(v4, v5, v6, v7, v8, v9, v10)
    elif v1 == 1:
        del v1
        v12, v13, v14, v15, v16, v17, v18 = method95(v2)
        del v2
        return US4_1(v12, v13, v14, v15, v16, v17, v18)
    elif v1 == 2:
        del v1
        method88(v2)
        del v2
        return US4_2()
    elif v1 == 3:
        del v1
        v21, v22, v23, v24, v25, v26, v27 = method95(v2)
        del v2
        return US4_3(v21, v22, v23, v24, v25, v26, v27)
    elif v1 == 4:
        del v1
        v29, v30, v31, v32, v33, v34, v35 = method95(v2)
        del v2
        return US4_4(v29, v30, v31, v32, v33, v34, v35)
    elif v1 == 5:
        del v1
        v37, v38, v39, v40, v41, v42, v43, v44 = method101(v2)
        del v2
        return US4_5(v37, v38, v39, v40, v41, v42, v43, v44)
    elif v1 == 6:
        del v1
        v46, v47, v48, v49, v50, v51, v52 = method95(v2)
        del v2
        return US4_6(v46, v47, v48, v49, v50, v51, v52)
    elif v1 == 7:
        del v1
        v54, v55, v56, v57, v58, v59, v60 = method95(v2)
        del v2
        return US4_7(v54, v55, v56, v57, v58, v59, v60)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method103(v0 : cp.ndarray) -> US2:
    v1 = method81(v0)
    v2 = v0[4:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        method88(v2)
        del v2
        return US2_0()
    elif v1 == 1:
        del v1
        method88(v2)
        del v2
        return US2_1()
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method104(v0 : cp.ndarray) -> i32:
    v1 = v0[6264:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method77(v0 : cp.ndarray) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    v1 = method78(v0)
    v2 = static_array_list(128)
    v3 = method79(v0)
    v2.length = v3
    del v3
    v4 = v2.length
    v5 = 0
    while method7(v4, v5):
        v7 = u64(v5)
        v8 = v7 * 48
        del v7
        v9 = 16 + v8
        del v8
        v10 = v0[v9:].view(cp.uint8)
        del v9
        v11 = method80(v10)
        del v10
        v12 = 0 <= v5
        if v12:
            v13 = v2.length
            v14 = v5 < v13
            del v13
            v15 = v14
        else:
            v15 = False
        del v12
        v16 = v15 == False
        if v16:
            v17 = "The set index needs to be in range for the static array list."
            assert v15, v17
            del v17
        else:
            pass
        del v15, v16
        v2[v5] = v11
        del v11
        v5 += 1 
    del v4, v5
    v18 = method93(v0)
    v19 = v0[6176:].view(cp.uint8)
    if v18 == 0:
        method88(v19)
        v24 = US3_0()
    elif v18 == 1:
        v22 = method94(v19)
        v24 = US3_1(v22)
    else:
        raise Exception("Invalid tag.")
    del v18, v19
    v25 = static_array(2)
    v26 = 0
    while method47(v26):
        v28 = u64(v26)
        v29 = v28 * 4
        del v28
        v30 = 6256 + v29
        del v29
        v31 = v0[v30:].view(cp.uint8)
        del v30
        v32 = method103(v31)
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
    v38 = method104(v0)
    v39 = v0[6272:].view(cp.uint8)
    del v0
    if v38 == 0:
        method88(v39)
        v58 = US6_0()
    elif v38 == 1:
        v42, v43, v44, v45, v46, v47, v48 = method95(v39)
        v58 = US6_1(v42, v43, v44, v45, v46, v47, v48)
    elif v38 == 2:
        v50, v51, v52, v53, v54, v55, v56 = method95(v39)
        v58 = US6_2(v50, v51, v52, v53, v54, v55, v56)
    else:
        raise Exception("Invalid tag.")
    del v38, v39
    return v1, v2, v24, v25, v58
def method106(v0 : cp.ndarray) -> i32:
    v1 = v0[6168:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method105(v0 : cp.ndarray) -> Tuple[static_array_list, static_array, US6]:
    v1 = static_array_list(128)
    v2 = method81(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method7(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 48
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method80(v9)
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
    while method47(v18):
        v20 = u64(v18)
        v21 = v20 * 4
        del v20
        v22 = 6160 + v21
        del v21
        v23 = v0[v22:].view(cp.uint8)
        del v22
        v24 = method103(v23)
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
    v30 = method106(v0)
    v31 = v0[6176:].view(cp.uint8)
    del v0
    if v30 == 0:
        method88(v31)
        v50 = US6_0()
    elif v30 == 1:
        v34, v35, v36, v37, v38, v39, v40 = method95(v31)
        v50 = US6_1(v34, v35, v36, v37, v38, v39, v40)
    elif v30 == 2:
        v42, v43, v44, v45, v46, v47, v48 = method95(v31)
        v50 = US6_2(v42, v43, v44, v45, v46, v47, v48)
    else:
        raise Exception("Invalid tag.")
    del v30, v31
    return v1, v17, v50
def method112(v0 : u64) -> object:
    v1 = v0
    del v0
    return v1
def method111(v0 : u64) -> object:
    return method112(v0)
def method117(v0 : u8) -> object:
    v1 = v0
    del v0
    return v1
def method116(v0 : u8) -> object:
    return method117(v0)
def method115(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method7(v2, v3):
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
        v12 = method116(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method119(v0 : i32) -> object:
    v1 = v0
    del v0
    return v1
def method118(v0 : i32, v1 : i32) -> object:
    v2 = method119(v0)
    del v0
    v3 = method119(v1)
    del v1
    v4 = {'chips_won': v2, 'winner_id': v3}
    del v2, v3
    return v4
def method122() -> object:
    v0 = []
    return v0
def method121(v0 : US1) -> object:
    match v0:
        case US1_0(): # A_Call
            del v0
            v1 = method122()
            v2 = "A_Call"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # A_Fold
            del v0
            v4 = method122()
            v5 = "A_Fold"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(v7): # A_Raise
            del v0
            v8 = method119(v7)
            del v7
            v9 = "A_Raise"
            v10 = [v9,v8]
            del v8, v9
            return v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method120(v0 : i32, v1 : US1) -> object:
    v2 = []
    v3 = method119(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method121(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method124(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method47(v2):
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
        v10 = method116(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method123(v0 : i32, v1 : static_array) -> object:
    v2 = []
    v3 = method119(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method124(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method129(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method63(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 5
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
        v10 = method116(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method130(v0 : i8) -> object:
    v1 = v0
    del v0
    return v1
def method128(v0 : static_array, v1 : i8) -> object:
    v2 = method129(v0)
    del v0
    v3 = method130(v1)
    del v1
    v4 = {'hand': v2, 'score': v3}
    del v2, v3
    return v4
def method127(v0 : static_array, v1 : i8) -> object:
    return method128(v0, v1)
def method126(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method47(v2):
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
        v9, v10 = v0[v2]
        v11 = method127(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method125(v0 : i32, v1 : static_array, v2 : i32) -> object:
    v3 = method119(v0)
    del v0
    v4 = method126(v1)
    del v1
    v5 = method119(v2)
    del v2
    v6 = {'chips_won': v3, 'hands_shown': v4, 'winner_id': v5}
    del v3, v4, v5
    return v6
def method114(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardsAre
            del v0
            v2 = method115(v1)
            del v1
            v3 = "CommunityCardsAre"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # Fold
            del v0
            v7 = method118(v5, v6)
            del v5, v6
            v8 = "Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US7_2(v10, v11): # PlayerAction
            del v0
            v12 = method120(v10, v11)
            del v10, v11
            v13 = "PlayerAction"
            v14 = [v13,v12]
            del v12, v13
            return v14
        case US7_3(v15, v16): # PlayerGotCards
            del v0
            v17 = method123(v15, v16)
            del v15, v16
            v18 = "PlayerGotCards"
            v19 = [v18,v17]
            del v17, v18
            return v19
        case US7_4(v20, v21, v22): # Showdown
            del v0
            v23 = method125(v20, v21, v22)
            del v20, v21, v22
            v24 = "Showdown"
            v25 = [v24,v23]
            del v23, v24
            return v25
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method113(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method7(v2, v3):
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
        v12 = method114(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method110(v0 : u64, v1 : static_array_list) -> object:
    v2 = method111(v0)
    del v0
    v3 = method113(v1)
    del v1
    v4 = {'deck': v2, 'messages': v3}
    del v2, v3
    return v4
def method135(v0 : i32) -> object:
    v1 = method119(v0)
    del v0
    v2 = {'min_raise': v1}
    del v1
    return v2
def method136(v0 : bool) -> object:
    v1 = v0
    del v0
    return v1
def method137(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method47(v2):
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
        v10 = method124(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method138(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method47(v2):
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
        v10 = method119(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method140(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method70(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 3
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
        v10 = method116(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method141(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method73(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 4
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
        v10 = method116(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method139(v0 : US5) -> object:
    match v0:
        case US5_0(v1): # Flop
            del v0
            v2 = method140(v1)
            del v1
            v3 = "Flop"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US5_1(): # Preflop
            del v0
            v5 = method122()
            v6 = "Preflop"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case US5_2(v8): # River
            del v0
            v9 = method129(v8)
            del v8
            v10 = "River"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US5_3(v12): # Turn
            del v0
            v13 = method141(v12)
            del v12
            v14 = "Turn"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method134(v0 : i32, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : static_array, v6 : US5) -> object:
    v7 = method135(v0)
    del v0
    v8 = method136(v1)
    del v1
    v9 = method137(v2)
    del v2
    v10 = method119(v3)
    del v3
    v11 = method138(v4)
    del v4
    v12 = method138(v5)
    del v5
    v13 = method139(v6)
    del v6
    v14 = {'config': v7, 'is_button_s_first_move': v8, 'pl_card': v9, 'player_turn': v10, 'pot': v11, 'stack': v12, 'street': v13}
    del v7, v8, v9, v10, v11, v12, v13
    return v14
def method142(v0 : i32, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : static_array, v6 : US5, v7 : US1) -> object:
    v8 = []
    v9 = method134(v0, v1, v2, v3, v4, v5, v6)
    del v0, v1, v2, v3, v4, v5, v6
    v8.append(v9)
    del v9
    v10 = method121(v7)
    del v7
    v8.append(v10)
    del v10
    v11 = v8
    del v8
    return v11
def method133(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6, v7): # G_Flop
            del v0
            v8 = method134(v1, v2, v3, v4, v5, v6, v7)
            del v1, v2, v3, v4, v5, v6, v7
            v9 = "G_Flop"
            v10 = [v9,v8]
            del v8, v9
            return v10
        case US4_1(v11, v12, v13, v14, v15, v16, v17): # G_Fold
            del v0
            v18 = method134(v11, v12, v13, v14, v15, v16, v17)
            del v11, v12, v13, v14, v15, v16, v17
            v19 = "G_Fold"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US4_2(): # G_Preflop
            del v0
            v21 = method122()
            v22 = "G_Preflop"
            v23 = [v22,v21]
            del v21, v22
            return v23
        case US4_3(v24, v25, v26, v27, v28, v29, v30): # G_River
            del v0
            v31 = method134(v24, v25, v26, v27, v28, v29, v30)
            del v24, v25, v26, v27, v28, v29, v30
            v32 = "G_River"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US4_4(v34, v35, v36, v37, v38, v39, v40): # G_Round
            del v0
            v41 = method134(v34, v35, v36, v37, v38, v39, v40)
            del v34, v35, v36, v37, v38, v39, v40
            v42 = "G_Round"
            v43 = [v42,v41]
            del v41, v42
            return v43
        case US4_5(v44, v45, v46, v47, v48, v49, v50, v51): # G_Round'
            del v0
            v52 = method142(v44, v45, v46, v47, v48, v49, v50, v51)
            del v44, v45, v46, v47, v48, v49, v50, v51
            v53 = "G_Round'"
            v54 = [v53,v52]
            del v52, v53
            return v54
        case US4_6(v55, v56, v57, v58, v59, v60, v61): # G_Showdown
            del v0
            v62 = method134(v55, v56, v57, v58, v59, v60, v61)
            del v55, v56, v57, v58, v59, v60, v61
            v63 = "G_Showdown"
            v64 = [v63,v62]
            del v62, v63
            return v64
        case US4_7(v65, v66, v67, v68, v69, v70, v71): # G_Turn
            del v0
            v72 = method134(v65, v66, v67, v68, v69, v70, v71)
            del v65, v66, v67, v68, v69, v70, v71
            v73 = "G_Turn"
            v74 = [v73,v72]
            del v72, v73
            return v74
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method132(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = method122()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method133(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method144(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = method122()
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = method122()
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method143(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method47(v2):
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
        v10 = method144(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method145(v0 : US6) -> object:
    match v0:
        case US6_0(): # GameNotStarted
            del v0
            v1 = method122()
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4, v5, v6, v7, v8, v9, v10): # GameOver
            del v0
            v11 = method134(v4, v5, v6, v7, v8, v9, v10)
            del v4, v5, v6, v7, v8, v9, v10
            v12 = "GameOver"
            v13 = [v12,v11]
            del v11, v12
            return v13
        case US6_2(v14, v15, v16, v17, v18, v19, v20): # WaitingForActionFromPlayerId
            del v0
            v21 = method134(v14, v15, v16, v17, v18, v19, v20)
            del v14, v15, v16, v17, v18, v19, v20
            v22 = "WaitingForActionFromPlayerId"
            v23 = [v22,v21]
            del v21, v22
            return v23
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method131(v0 : US3, v1 : static_array, v2 : US6) -> object:
    v3 = method132(v0)
    del v0
    v4 = method143(v1)
    del v1
    v5 = method145(v2)
    del v2
    v6 = {'game': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method109(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method110(v0, v1)
    del v0, v1
    v6 = method131(v2, v3, v4)
    del v2, v3, v4
    v7 = {'large': v5, 'small': v6}
    del v5, v6
    return v7
def method146(v0 : static_array_list, v1 : static_array, v2 : US6) -> object:
    v3 = method113(v0)
    del v0
    v4 = method143(v1)
    del v1
    v5 = method145(v2)
    del v2
    v6 = {'messages': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method108(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method109(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    v9 = method146(v5, v6, v7)
    del v5, v6, v7
    v10 = {'game_state': v8, 'ui_state': v9}
    del v8, v9
    return v10
def method107(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method108(v0, v1, v2, v3, v4, v5, v6, v7)
    del v0, v1, v2, v3, v4, v5, v6, v7
    return v8
def method148(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method109(v0, v1, v2, v3, v4)
    del v0, v2
    v6 = method146(v1, v3, v4)
    del v1, v3, v4
    v7 = {'game_state': v5, 'ui_state': v6}
    del v5, v6
    return v7
def method147(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method148(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    return v5
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("HU_Holdem_Game",['event_loop_gpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
